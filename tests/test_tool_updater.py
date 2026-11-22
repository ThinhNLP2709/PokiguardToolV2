from __future__ import annotations
import base64
import copy
import hashlib
import json
import os
from pathlib import Path
import shutil
import struct
import tempfile
import threading
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch
import uuid
import zipfile

from tests.reasoning_test_paths import reasoning_temp_root
from pokiguard_v2.updater import protocol as p
from pokiguard_v2.updater import transaction as tx
from pokiguard_v2.updater.package import extract
from pokiguard_v2.compatibility.profile import atomic_json, file_hash, load_json


def make_bundle(folder, build=1):
    folder.mkdir(parents=True, exist_ok=True)
    exe = bytearray(256); exe[:2] = b'MZ'
    struct.pack_into('<I', exe, 0x3C, 0x80); exe[0x80:0x86] = b'PE\0\0\x64\x86'
    (folder / p.EXE_NAME).write_bytes(exe)
    resources = folder / '_internal/pokiguard_v2/resources'
    resources.mkdir(parents=True)
    atomic_json(resources / 'update_build.json', {'schema':1,'version':'v1.3.6','build':build,'platform':p.PLATFORM})
    atomic_json(resources / 'package_build.json', {'version':'v1.3.6','source_sha256':'a'*64,'contains_account_data':False})
    (folder / '_internal/runtime.dll').write_bytes(b'old-runtime' if build == 1 else b'new-runtime')
    return folder


def snapshot(folder):
    return {f.relative_to(folder).as_posix():file_hash(f) for f in folder.rglob('*') if f.is_file()}


class UpdateFixture(unittest.TestCase):
    def setUp(self):
        from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PrivateKey
        from cryptography.hazmat.primitives.serialization import Encoding, PublicFormat
        self.temp = tempfile.TemporaryDirectory(dir=reasoning_temp_root())
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name).resolve()
        self.key = Ed25519PrivateKey.generate()
        public = self.key.public_key().public_bytes(Encoding.Raw, PublicFormat.Raw)
        self.trust = {'schema':1,'repository':'owner/tool','manifest_url':'https://github.com/owner/tool/releases/latest/download/update.json',
                      'public_keys':{'test':base64.b64encode(public).decode()}}
        self.install = make_bundle(self.root / 'install',1)
        self.new = make_bundle(self.root / 'new/PokiguardToolV2',2)
        self.archive = self.root / 'new.zip'
        self.zip_bundle()
        self.payload = {'schema':1,'platform':p.PLATFORM,'channel':'stable','version':'v1.3.6','build':2,
            'url':'https://github.com/owner/tool/releases/download/v1.3.6-build.2/new.zip',
            'size':self.archive.stat().st_size,'sha256':file_hash(self.archive),'source_sha256':'a'*64,'notes':'release'}
        self.document = self.sign(self.payload)
        self.release = p.verify(self.document,self.trust)
        self.job = self.root / 'data/updates/jobs' / uuid.uuid4().hex
        self.job.mkdir(parents=True)
        atomic_json(self.job/'manifest.json',self.document)
        shutil.copyfile(self.archive,self.job/'package.zip')
        self.data = self.root / 'data'
        (self.data/'preferences').mkdir()
        (self.data/'preferences/prefs.json').write_text('private preferences')
        (self.data/'compatibility').mkdir()
        (self.data/'compatibility/profile.json').write_text('historical profile')
        self.pref_snapshot = snapshot(self.data/'preferences')
        self.profile_snapshot = snapshot(self.data/'compatibility')
        tx.prepare_handoff(self.job,self.install,self.data)
        self.trust_patch = patch('pokiguard_v2.updater.protocol.config',return_value=self.trust)
        self.trust_patch.start(); self.addCleanup(self.trust_patch.stop)
        # This synthetic v1.3.6 bundle is independent of the checkout's label.
        installed = patch('pokiguard_v2.updater.service.installed_build',
                          return_value=p.installed_build(self.install))
        installed.start(); self.addCleanup(installed.stop)

    def sign(self,row):
        return {'key_id':'test','payload':copy.deepcopy(row),
                'signature':base64.b64encode(self.key.sign(p.DOMAIN+p.canonical(row))).decode()}

    def zip_bundle(self, extras=()):
        with zipfile.ZipFile(self.archive,'w',zipfile.ZIP_DEFLATED) as z:
            for f in self.new.rglob('*'):
                if f.is_file(): z.write(f,f.relative_to(self.new.parent).as_posix())
            for name,data in extras: z.writestr(name,data)

    def apply(self, **kwargs):
        return tx.apply(self.job,wait=lambda *_: None,health=kwargs.pop('health',lambda *_:None),
                        start=kwargs.pop('start',lambda *_:None),**kwargs)


class ProtocolTests(UpdateFixture):
    def test_signature_and_build_order(self):
        self.assertTrue(p.newer(self.release,p.installed_build(self.install)))
        self.assertFalse(p.newer(self.release,{'version':'v1.3.7','build':0}))
        self.assertFalse(p.newer(self.release,{'version':'v1.3.6','build':2}))
        self.assertEqual(self.release,p.verify(self.document))

    def test_payload_tampering_and_unknown_key_rejected(self):
        bad = copy.deepcopy(self.document); bad['payload']['url'] += '?malicious'
        with self.assertRaisesRegex(p.UpdateError,'SIGNATURE_INVALID'): p.verify(bad)
        bad = copy.deepcopy(self.document); bad['key_id'] = 'other'
        with self.assertRaisesRegex(p.UpdateError,'KEY_UNTRUSTED'): p.verify(bad)

    def test_signed_but_invalid_platform_url_size_and_versions_rejected(self):
        for field,value in [('platform','linux'),('url','https://evil.test/file.zip'),
                            ('url','https://github.com/owner/tool/releases/download/../else.zip'),
                            ('size',True),('size',-1),('version','1.2'),('build',-1),('build',True),('sha256','0')]:
            row=dict(self.payload); row[field]=value
            with self.subTest(field=field,value=value),self.assertRaises(p.UpdateError):p.verify(self.sign(row))

    def test_key_and_domain_are_separate_from_game_catalog(self):
        bad=copy.deepcopy(self.document)
        bad['signature']=base64.b64encode(self.key.sign(b'PokiguardV2.compatibility.catalog.v1\n'+p.canonical(bad['payload']))).decode()
        with self.assertRaisesRegex(p.UpdateError,'SIGNATURE_INVALID'):p.verify(bad)


class PackageTests(UpdateFixture):
    def test_complete_package_extracts(self):
        folder=extract(self.archive,self.root/'stage',self.release)
        self.assertEqual(2,p.installed_build(folder)['build'])
        self.assertEqual(snapshot(self.new),snapshot(folder))

    def test_truncated_download_does_not_extract(self):
        self.archive.write_bytes(self.archive.read_bytes()[:-1])
        with self.assertRaisesRegex(p.UpdateError,'HASH_MISMATCH'):extract(self.archive,self.root/'stage',self.release)
        self.assertFalse((self.root/'stage').exists())

    def test_traversal_duplicate_case_ads_and_symlink_rejected(self):
        for index,name in enumerate(('PokiguardToolV2/../escape','/absolute','PokiguardToolV2/file:stream',
                                     'PokiguardToolV2/con.txt','PokiguardToolV2/pokiguardtoolv2.exe')):
            self.zip_bundle([(name,b'x')])
            row=dict(self.payload,size=self.archive.stat().st_size,sha256=file_hash(self.archive))
            release=p.verify(self.sign(row))
            with self.subTest(name=name),self.assertRaises((p.UpdateError,FileExistsError)):
                extract(self.archive,self.root/f'stage-{index}',release)
        self.assertFalse((self.root/'escape').exists())
        self.zip_bundle()
        with zipfile.ZipFile(self.archive,'a') as z:
            info=zipfile.ZipInfo('PokiguardToolV2/link');info.create_system=3;info.external_attr=0o120777<<16
            z.writestr(info,b'../../outside')
        release=p.verify(self.sign(dict(self.payload,size=self.archive.stat().st_size,sha256=file_hash(self.archive))))
        with self.assertRaisesRegex(p.UpdateError,'LINK_INVALID'):extract(self.archive,self.root/'links',release)

    def test_wrong_packaged_version_is_rejected_even_with_valid_signature(self):
        row=dict(self.payload,build=3)
        with self.assertRaisesRegex(p.UpdateError,'VERSION_MISMATCH'):
            extract(self.archive,self.root/'stage',p.verify(self.sign(row)))


class TransactionTests(UpdateFixture):
    def test_success_replaces_whole_bundle_and_preserves_user_data(self):
        before=snapshot(self.install); starts=[]
        self.assertEqual('committed',self.apply(start=lambda i:starts.append(p.installed_build(i)['build'])))
        self.assertEqual([2],starts)
        self.assertEqual(snapshot(self.new),snapshot(self.install))
        backup=self.install.parent/f'.Pokiguard-update-{self.job.name}'/'previous'
        self.assertEqual(before,snapshot(backup))
        self.assertEqual(self.pref_snapshot,snapshot(self.data/'preferences'))
        self.assertEqual(self.profile_snapshot,snapshot(self.data/'compatibility'))
        self.assertEqual('committed',load_json(self.job/'transaction.json')['status'])

    def test_health_failure_restores_exact_old_bundle_then_restarts_old(self):
        before=snapshot(self.install); starts=[]
        def bad(*_):raise p.UpdateError('UPDATE_HEALTH_FAILED')
        with self.assertRaisesRegex(p.UpdateError,'HEALTH_FAILED'):
            self.apply(health=bad,start=lambda i:starts.append(p.installed_build(i)['build']))
        self.assertEqual(before,snapshot(self.install)); self.assertEqual([1],starts)
        self.assertEqual('rolled_back',load_json(self.job/'transaction.json')['status'])

    def test_failed_second_rename_rolls_back(self):
        before=snapshot(self.install); original=tx.rename; calls=[]
        def fail(source,destination):
            calls.append((source,destination))
            if len(calls)==2:raise PermissionError('injected locked file')
            original(source,destination)
        with patch.object(tx,'rename',side_effect=fail),self.assertRaises(PermissionError):self.apply()
        self.assertEqual(before,snapshot(self.install))

    def test_interrupted_swap_recovery_restores_old(self):
        area=self.install.parent/f'.Pokiguard-update-{self.job.name}';area.mkdir()
        before=snapshot(self.install)
        self.install.rename(area/'previous')
        shutil.copytree(self.new,self.install)
        atomic_json(self.job/'transaction.json',{'status':'checking'})
        self.assertEqual('rolled_back',self.apply())
        self.assertEqual(before,snapshot(self.install))

    def test_external_controller_blocks_install_before_any_rename(self):
        from pokiguard_v2.controller_lease import AutomationControllerLease,ControllerLeaseError
        before=snapshot(self.install)
        with AutomationControllerLease(self.data/'logs/.automation_controller.lock'):
            with self.assertRaises(ControllerLeaseError):self.apply()
        self.assertEqual(before,snapshot(self.install))

    def test_install_changed_since_handoff_is_rejected(self):
        (self.install/p.EXE_NAME).write_bytes(b'changed by another update')
        with self.assertRaisesRegex(p.UpdateError,'OLD_INSTALL_CHANGED'):self.apply()

    def test_signed_archive_rechecked_at_apply_boundary(self):
        (self.job/'package.zip').write_bytes(b'modified after download')
        before=snapshot(self.install)
        with self.assertRaisesRegex(p.UpdateError,'HASH_MISMATCH'):self.apply()
        self.assertEqual(before,snapshot(self.install))

    def test_game_directory_and_source_checkout_are_never_install_targets(self):
        game=self.root/'game';game.mkdir();(game/'GameAssembly.dll').write_bytes(b'game')
        tool=make_bundle(game/'tool')
        with self.assertRaisesRegex(p.UpdateError,'PATH_INSIDE_GAME'):tx.prepare_handoff(self.job,tool,self.data)
        (self.install/'AGENTS.md').write_text('workspace')
        with self.assertRaisesRegex(p.UpdateError,'NOT_ISOLATED'):tx.validate_install(self.install)
        self.assertEqual(b'game',(game/'GameAssembly.dll').read_bytes())

    def test_receipt_must_be_fresh_and_identify_the_signed_build(self):
        child=Mock();child.wait.return_value=0
        with patch('subprocess.Popen',return_value=child),self.assertRaisesRegex(p.UpdateError,'HEALTH_FAILED'):
            tx.run_health(self.new,self.job,self.release)
        def launch(*args,**kwargs):
            receipt={'nonce':kwargs['env']['POKIGUARD_UPDATE_HEALTH_NONCE'],'version':self.release.version,
                     'build':self.release.build,'source_sha256':self.release.source_sha256,'game_inputs':0}
            atomic_json(self.job/'health-data/update-health.json',receipt)
            return child
        with patch('subprocess.Popen',side_effect=launch):tx.run_health(self.new,self.job,self.release)


class WorkerAndWorkflowTests(UpdateFixture):
    def test_download_stages_verified_helper_and_holds_controller_lease(self):
        from pokiguard_v2.updater import service
        from pokiguard_v2.controller_lease import AutomationControllerLease,ControllerLeaseError
        paths=SimpleNamespace(frozen=True,data_root=self.data,install_root=self.install,
                              controller_lock=self.data/'logs/.automation_controller.lock')
        response=Mock();response.__enter__=Mock(return_value=response);response.__exit__=Mock(return_value=False)
        response.geturl.return_value=self.payload['url']
        blocks=iter([self.archive.read_bytes(),b''])
        def read(_):
            with self.assertRaises(ControllerLeaseError):
                with AutomationControllerLease(paths.controller_lock):pass
            return next(blocks)
        response.read.side_effect=read
        before=snapshot(self.install)
        with patch.object(service,'current_app_paths',return_value=paths),patch.object(service,'open_url',return_value=response):
            job=service.prepare(self.release,threading.Event())
        self.assertEqual('prepared',load_json(job/'state.json')['status'])
        self.assertEqual(before,snapshot(self.install))
        self.assertEqual(before,snapshot(job/'helper'))

    def test_cancelled_download_never_prepares_handoff(self):
        from pokiguard_v2.updater import service
        paths=SimpleNamespace(frozen=True,data_root=self.data,install_root=self.install,
                              controller_lock=self.data/'logs/.automation_controller.lock')
        cancel=threading.Event()
        response=Mock();response.__enter__=Mock(return_value=response);response.__exit__=Mock(return_value=False)
        response.geturl.return_value=self.payload['url']
        def read(_):cancel.set();return self.archive.read_bytes()[:10]
        response.read.side_effect=read
        before=snapshot(self.install)
        with patch.object(service,'current_app_paths',return_value=paths),patch.object(service,'open_url',return_value=response), \
             self.assertRaisesRegex(p.UpdateError,'CANCELLED'):
            service.prepare(self.release,cancel)
        jobs=list((self.data/'updates/jobs').iterdir())
        self.assertEqual(2,len(jobs))
        created=next(j for j in jobs if j!=self.job)
        self.assertFalse((created/'handoff.json').exists())
        self.assertEqual(before,snapshot(self.install))

    def test_check_missing_or_old_release_never_installs(self):
        from pokiguard_v2.updater import service
        response=Mock();response.__enter__=Mock(return_value=response);response.__exit__=Mock(return_value=False)
        response.geturl.return_value=self.payload['url'];response.read.return_value=p.canonical(self.document)
        with patch.object(service,'config',return_value=self.trust),patch.object(service,'open_url',return_value=response):
            self.assertIsNotNone(service.check(threading.Event()))
            with patch.object(service,'installed_build',return_value={'version':'v2.0.0','build':0}):
                self.assertIsNone(service.check(threading.Event()))
        self.assertEqual(1,p.installed_build(self.install)['build'])

    def test_close_and_start_resume_are_fenced_during_update(self):
        from pokiguard_v2.desktop_ui import DesktopApplication
        app=DesktopApplication.__new__(DesktopApplication)
        app._closed=app._shutdown_started=False;app._update_running=True
        app.command_feedback=Mock();app.update_status=Mock();app._update_worker=Mock();app.view_model=Mock()
        app._start_farm();app._resume_checkpoint();app.close()
        self.assertEqual([],app.view_model.mock_calls)
        app._update_worker.cancel.set.assert_called_once()
        self.assertTrue(app._update_close_requested)

    def test_source_mode_cannot_replace_a_source_checkout(self):
        from pokiguard_v2.updater import service
        with patch.object(service,'current_app_paths',return_value=SimpleNamespace(frozen=False)), \
             self.assertRaisesRegex(p.UpdateError,'SOURCE_MODE'):
            service.prepare(self.release,threading.Event())

    def test_ci_uses_pinned_actions_and_only_draft_release(self):
        import yaml
        path=Path(__file__).resolve().parents[1]/'.github/workflows/windows-release.yml'
        workflow=yaml.load(path.read_text(),Loader=yaml.BaseLoader)
        self.assertIn('pull_request',workflow['on'])
        self.assertIn('workflow_dispatch',workflow['on'])
        self.assertEqual('read',workflow['permissions']['contents'])
        self.assertEqual('verify',workflow['jobs']['draft-release']['needs'])
        for job in workflow['jobs'].values():
            for step in job['steps']:
                if 'uses' in step:self.assertRegex(step['uses'],r'@[0-9a-f]{40}$')
        text=path.read_text()
        self.assertIn('--draft',text);self.assertNotIn('release publish',text)
        self.assertNotIn('pull_request_target',text)
        self.assertNotIn('secrets.',str(workflow['jobs']['verify']))
        # The signing job consumes a flat artifact root. Mixing a report from
        # another directory changes upload-artifact's common ancestor.
        payloads=[s['with']['path'] for s in workflow['jobs']['verify']['steps']
                  if s.get('with',{}).get('name')=='windows-verified']
        self.assertEqual(['build/ci/*.zip'],payloads)


if __name__=='__main__':unittest.main()
