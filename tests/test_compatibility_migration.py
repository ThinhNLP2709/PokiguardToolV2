from __future__ import annotations

import copy
from dataclasses import replace
import json
from pathlib import Path
import struct
import tempfile
import threading
import time
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch
import zipfile

from tests.reasoning_test_paths import reasoning_temp_root
from pokiguard_v2.compatibility import profile as p
from pokiguard_v2.compatibility.audit import NativeAudit, audit_candidate
from pokiguard_v2.compatibility.service import migrate
from pokiguard_v2.compatibility.toolchain import extract_verified, fetch_archive
from pokiguard_v2.compatibility.worker import MigrationWorker
from pokiguard_v2.il2cpp_external import Il2CppExternalResolver, BOARD_SINGLETON
from pokiguard_v2.native_card_ui import NativeCardUiReader, _COMPONENT_GO_ICALL, _UNMARSHAL_SIGNATURE
from tests.test_il2cpp_external import FakeMemory
from tests import test_il2cpp_external as external_fixture
from tests.test_native_card_ui import NativeFixture


def baseline_profile(contract=None, identity=None):
    contract = contract or p.load_contract()
    cache, rva, code = contract['native_bridge']
    return p.RuntimeProfile.from_dict({'schema': 1, 'contract_sha256': p.digest(contract),
        'identity': identity or contract['identity'], 'bindings': [[r['rva'], r['rva']] for r in contract['roots']],
        'component_cache': cache, 'unmarshal': [rva, code]}, contract)


class ProfileTests(unittest.TestCase):
    def setUp(self):
        self.contract = p.load_contract()
        self.profile = baseline_profile(self.contract)

    def test_reviewed_baseline_inventory(self):
        self.assertEqual(39, len(self.profile.bindings))
        self.assertEqual(55, len(self.contract['types']))
        self.assertEqual(69, len(self.contract['native_methods']))
        self.assertGreater(len(self.contract['header']), 2400)
        self.assertEqual(1722, len(self.contract['enums']))

    def test_roundtrip_is_immutable(self):
        data = self.profile.to_dict()
        data['identity']['files']['assembly']['sha256'] = 'a' * 64
        self.assertNotEqual(data['identity'], self.profile.identity)
        self.assertEqual(self.profile, p.RuntimeProfile.from_dict(self.profile.to_dict(), self.contract))

    def test_rejects_partial_duplicate_or_guessed_bindings(self):
        for kind in ('missing', 'duplicate', 'unaligned', 'bool', 'foreign'):
            data = self.profile.to_dict()
            if kind == 'missing': data['bindings'].pop()
            if kind == 'duplicate': data['bindings'][1][1] = data['bindings'][0][1]
            if kind == 'unaligned': data['bindings'][0][1] += 1
            if kind == 'bool': data['bindings'][0][1] = True
            if kind == 'foreign': data['bindings'][0][0] = 0x12345678
            with self.subTest(kind=kind), self.assertRaises(p.CompatibilityError):
                p.RuntimeProfile.from_dict(data, self.contract)

    def test_rejects_wrong_contract_unity_metadata_or_extra_fields(self):
        for field in ('contract_sha256', 'unity', 'metadata', 'extra'):
            data = self.profile.to_dict()
            if field == 'contract_sha256': data[field] = 'a' * 64
            if field == 'unity': data['identity']['files']['unity']['sha256'] = 'a' * 64
            if field == 'metadata': data['identity']['metadata_version'] = 112
            if field == 'extra': data['code'] = 'untrusted'
            with self.subTest(field=field), self.assertRaises(p.CompatibilityError):
                p.RuntimeProfile.from_dict(data, self.contract)

    def test_resolver_maps_roots_and_singletons_per_attachment(self):
        fixture = external_fixture.Il2CppExternalResolverTests()
        original = BOARD_SINGLETON.type_info_rva
        memories = []
        for delta in (0x1000, 0x7000):
            memory = FakeMemory()
            pairs = tuple((a, b + delta) for a, b in self.profile.bindings)
            memory.runtime_profile = replace(self.profile, bindings=pairs)
            fixture.map_singleton(memory, original + delta, BOARD_SINGLETON.static_field_offset,
                                  fixture.CLASS, fixture.STATIC_FIELDS, fixture.BOARD)
            resolver = fixture.make_resolver(memory)
            memories.append((memory, resolver, delta))
        for memory, resolver, delta in reversed(memories):
            self.assertEqual(fixture.CLASS, resolver.resolve_type_info_class(original))
            found = resolver.resolve_singleton(BOARD_SINGLETON)
            self.assertEqual(fixture.BOARD, found.instance)
            self.assertEqual(fixture.MODULE_BASE + original + delta, found.type_info_slot)
            self.assertIs(memory.runtime_profile, resolver.runtime_profile)
        self.assertEqual(original, BOARD_SINGLETON.type_info_rva)

    def test_native_bridge_uses_same_profile_and_preserves_geometry(self):
        fixture = NativeFixture()
        old = NativeCardUiReader(fixture.memory, fixture.ga)
        before = old.read_button_geometry(fixture.cards[0].button.managed)
        profile = replace(self.profile, component_cache=_COMPONENT_GO_ICALL + 0x1000,
                          unmarshal_rva=_UNMARSHAL_SIGNATURE[0] + 0x3000)
        fixture.memory.runtime_profile = profile
        fixture.q(fixture.ga + profile.component_cache, fixture.unity + 0x1197500)
        fixture.memory.map(fixture.ga + profile.unmarshal_rva, bytes.fromhex(profile.unmarshal_hex))
        fixture.q(fixture.ga + _COMPONENT_GO_ICALL, 0)
        fixture.memory.map(fixture.ga + _UNMARSHAL_SIGNATURE[0], b'\0' * 24)
        current = NativeCardUiReader(fixture.memory, fixture.ga)
        self.assertIs(current.runtime_profile, profile)
        self.assertEqual(before, current.read_button_geometry(fixture.cards[0].button.managed))


class TransactionTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(dir=reasoning_temp_root())
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        game = self.base / 'game'
        game.mkdir()
        self.exe = game / 'PetPuzzle-1.7.4.exe'
        self.exe.write_bytes(b'launcher')
        (game / 'GameAssembly.dll').write_bytes(b'new assembly')
        (game / 'UnityPlayer.dll').write_bytes(b'unity')
        data = game / (self.exe.stem + '_Data')
        metadata = data / 'il2cpp_data/Metadata/global-metadata.dat'
        metadata.parent.mkdir(parents=True)
        metadata.write_bytes(struct.pack('<II', 0xFAB11BAF, 111) + b'metadata')
        (data / 'app.info').write_text('Pet Puzzle\nPet Puzzle')
        (data / 'resources.assets').write_bytes(b'unchanged serialized UI')
        self.identity = p.install_identity(self.exe)
        self.contract = p.load_contract()
        self.contract['identity'] = self.identity
        self.profile = baseline_profile(self.contract, self.identity)
        self.root = self.base / 'compatibility'
        self.build = self.identity['files']['assembly']['sha256']
        self.active = self.root / 'profiles' / (self.build + '.json')
        self.audit = patch('pokiguard_v2.compatibility.audit.audit_candidate', return_value=self.profile).start()
        self.addCleanup(patch.stopall)
        patch('pokiguard_v2.compatibility.service.load_contract', return_value=self.contract).start()
        patch('pokiguard_v2.compatibility.catalog.fetch_profile', return_value=None).start()
        patch('pokiguard_v2.game_location.SUPPORTED_GAME_ASSEMBLY_SHA256', frozenset()).start()
        from pokiguard_v2.app_paths import resolve_app_paths
        paths = resolve_app_paths(environ={'POKIGUARD_V2_DATA_ROOT': str(self.base / 'data')})
        patch('pokiguard_v2.app_paths.current_app_paths', return_value=paths).start()
        self.paths = paths

    def run_job(self, **kwargs):
        return migrate(self.exe, root=self.root, reverse=self.base / 'exports',
                       probe=kwargs.pop('probe', self.probe), **kwargs)

    def probe(self, exe, profile):
        self.assertFalse(self.active.exists())
        return {'status': 'verified', 'game_inputs': 0, 'profile_id': profile.profile_id}

    def test_prepare_never_activates(self):
        result = self.run_job(prepare_only=True)
        self.assertEqual('pending', result.status)
        self.assertFalse(self.active.exists())
        self.assertTrue((self.root / 'candidates' / (self.build + '.json')).is_file())

    def test_verified_activates_exact_profile_atomically(self):
        result = self.run_job()
        self.assertEqual('verified', result.status)
        self.assertEqual(self.profile.profile_id, p.load_json(self.active)['profile_id'])
        with patch('pokiguard_v2.compatibility.profile.load_contract', return_value=self.contract):
            self.assertEqual(self.profile, p.active_profile(self.exe, root=self.root))

    def test_probe_failure_keeps_previous_profile_bytes(self):
        self.active.parent.mkdir(parents=True)
        self.active.write_bytes(b'previous known profile')
        with self.assertRaisesRegex(p.CompatibilityError, 'LIVE_PROBE_FAILED'):
            self.run_job(probe=lambda *_: {'status': 'verified', 'game_inputs': 1})
        self.assertEqual(b'previous known profile', self.active.read_bytes())

    def test_missing_scene_is_pending(self):
        def unavailable(*_): raise p.CompatibilityError('SCENE_NOT_READY')
        result = self.run_job(probe=unavailable)
        self.assertEqual('pending', result.status)
        self.assertFalse(self.active.exists())

    def test_install_updated_during_probe_never_activates(self):
        def changed(*_):
            (self.exe.parent / 'GameAssembly.dll').write_bytes(b'another build')
            return {'status': 'verified', 'game_inputs': 0, 'profile_id': self.profile.profile_id}
        with self.assertRaisesRegex(p.CompatibilityError, 'INSTALL_CHANGED_DURING_PROBE'):
            self.run_job(probe=changed)
        self.assertFalse(self.active.exists())

    def test_profile_tampering_is_rejected(self):
        self.run_job()
        record = p.load_json(self.active)
        record['profile']['bindings'][0][1] += 8
        p.atomic_json(self.active, record)
        with patch('pokiguard_v2.compatibility.profile.load_contract', return_value=self.contract), \
             self.assertRaisesRegex(p.CompatibilityError, 'PROFILE_CHECKSUM_MISMATCH'):
            p.active_profile(self.exe, root=self.root)

    def test_serialized_ui_change_blocks_before_reverse(self):
        (self.exe.parent / (self.exe.stem + '_Data') / 'resources.assets').write_bytes(b'changed prefab rect')
        with self.assertRaisesRegex(p.CompatibilityError, 'UI_ASSETS_CHANGED'):
            self.run_job()
        self.audit.assert_not_called()

    def test_changed_metadata_cannot_reuse_a_verified_profile(self):
        self.run_job()
        metadata = self.exe.parent / (self.exe.stem + '_Data') / 'il2cpp_data/Metadata/global-metadata.dat'
        metadata.write_bytes(metadata.read_bytes() + b'changed')
        with patch('pokiguard_v2.compatibility.profile.load_contract', return_value=self.contract), \
             self.assertRaisesRegex(p.CompatibilityError, 'INSTALL_CHANGED'):
            p.active_profile(self.exe, root=self.root)

    def test_atomic_replace_failure_preserves_previous_record(self):
        self.active.parent.mkdir(parents=True)
        self.active.write_bytes(b'previous')
        original = p.os.replace
        def failed(source, target):
            if Path(target) == self.active:
                raise PermissionError('injected sharing conflict')
            return original(source, target)
        with patch('pokiguard_v2.compatibility.profile.os.replace', side_effect=failed), \
             self.assertRaises(PermissionError):
            self.run_job(probe=lambda *_: {'status':'verified', 'game_inputs':0, 'profile_id':self.profile.profile_id})
        self.assertEqual(b'previous', self.active.read_bytes())

    def test_lease_blocks_migration_while_controller_owns_game(self):
        from pokiguard_v2.controller_lease import AutomationControllerLease, ControllerLeaseError
        with AutomationControllerLease(self.paths.controller_lock):
            with self.assertRaises(ControllerLeaseError): self.run_job()
        self.audit.assert_not_called()

    def test_cancel_before_work_and_storage_under_game_are_rejected(self):
        cancel = threading.Event(); cancel.set()
        with self.assertRaisesRegex(p.CompatibilityError, 'MIGRATION_CANCELLED'):
            self.run_job(cancel=cancel)
        with self.assertRaisesRegex(p.CompatibilityError, 'STORAGE_INSIDE_GAME'):
            migrate(self.exe, root=self.exe.parent / 'compatibility')
        self.assertFalse(self.active.exists())

    def test_bad_static_contract_never_reaches_probe(self):
        self.audit.side_effect = p.CompatibilityError('MANAGED_CONTRACT_CHANGED')
        probe = Mock()
        with self.assertRaises(p.CompatibilityError): self.run_job(probe=probe)
        probe.assert_not_called()
        self.assertFalse(self.active.exists())

    def test_old_checkpoint_is_never_rebound(self):
        from pokiguard_v2.compatibility.checkpoint import record_scope, resume_error
        self.run_job()
        path = self.base / 'checkpoint.json'
        payload = SimpleNamespace(created_at=0, farm_run_id='old', checkpoint_seq=2)
        with patch('pokiguard_v2.compatibility.checkpoint._scope', return_value=self.profile), \
             patch('pokiguard_v2.compatibility.checkpoint.compatibility_root', return_value=self.root):
            self.assertEqual('CHECKPOINT_BUILD_SCOPE_UNKNOWN', resume_error(path, payload))
            with self.assertRaises(p.CompatibilityError): record_scope(path, payload)
            payload.created_at = time.time() + 1
            record_scope(path, payload)
            self.assertIsNone(resume_error(path, payload))
            other = replace(self.profile, component_cache=self.profile.component_cache + 8)
            with patch('pokiguard_v2.compatibility.checkpoint._scope', return_value=other):
                self.assertEqual('CHECKPOINT_BUILD_MISMATCH', resume_error(path, payload))
        with patch('pokiguard_v2.compatibility.checkpoint._scope', return_value=None):
            self.assertEqual('CHECKPOINT_BUILD_MISMATCH', resume_error(path, payload))


class ToolchainTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(dir=reasoning_temp_root())
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)

    def test_traversal_zip_rejected_and_changed_cached_tool_restored(self):
        archive = self.root / 'tools.zip'
        with zipfile.ZipFile(archive, 'w') as z: z.writestr('../escape.exe', b'bad')
        with self.assertRaisesRegex(p.CompatibilityError, 'ARCHIVE_PATH_INVALID'):
            extract_verified(archive, self.root / 'out', threading.Event())
        self.assertFalse((self.root / 'escape.exe').exists())
        with zipfile.ZipFile(archive, 'w') as z: z.writestr('tool.exe', b'pinned binary')
        extract_verified(archive, self.root / 'out', threading.Event())
        (self.root / 'out/tool.exe').write_bytes(b'changed')
        extract_verified(archive, self.root / 'out', threading.Event())
        self.assertEqual(b'pinned binary', (self.root / 'out/tool.exe').read_bytes())

    def test_reverse_export_is_reread_after_same_folder_is_replaced(self):
        from pokiguard_v2.compatibility.exports import dumper_script
        path = self.root / 'script.json'
        first = {'ScriptMethod': [], 'ScriptMetadata': [{'Name':'Board_TypeInfo', 'Address':4096}], 'Addresses': []}
        path.write_text(json.dumps(first))
        self.assertEqual(4096, dumper_script(str(self.root))['ScriptMetadata'][0]['Address'])
        first['ScriptMetadata'][0]['Address'] = 8192
        path.write_text(json.dumps(first))
        self.assertEqual(8192, dumper_script(str(self.root))['ScriptMetadata'][0]['Address'])

    def test_bad_download_hash_removes_partial_archive(self):
        response = Mock()
        response.__enter__ = Mock(return_value=response)
        response.__exit__ = Mock(return_value=False)
        response.geturl.return_value = 'https://example.test/tool.zip'
        response.read.side_effect = [b'wrong', b'']
        with patch('urllib.request.urlopen', return_value=response), \
             self.assertRaisesRegex(p.CompatibilityError, 'DOWNLOAD_CHECKSUM_MISMATCH'):
            fetch_archive('https://example.test/tool.zip', '0' * 64, 'sha256',
                          self.root / 'tool.zip', threading.Event())
        self.assertEqual([], list(self.root.iterdir()))

    def test_cancelled_child_is_killed_and_reaped(self):
        from pokiguard_v2.compatibility.toolchain import dump
        child = Mock(); child.poll.return_value = None
        cancel = threading.Event(); cancel.set()
        with patch('pokiguard_v2.compatibility.toolchain.acquire', return_value=(Path('tool.exe'), {})), \
             patch('subprocess.Popen', return_value=child), \
             self.assertRaisesRegex(p.CompatibilityError, 'MIGRATION_CANCELLED'):
            dump(Path('D:/game/PetPuzzle.exe'), self.root, self.root / 'tools', cancel, lambda *_: None)
        child.kill.assert_called_once()
        child.wait.assert_called_once()

    def test_worker_events_and_cancellation(self):
        entered = threading.Event()
        def engine(location, *, cancel, progress):
            progress('working'); entered.set()
            cancel.wait(2)
            raise p.CompatibilityError('MIGRATION_CANCELLED')
        worker = MigrationWorker(engine)
        self.assertTrue(worker.start('game'))
        self.assertTrue(entered.wait(2))
        self.assertFalse(worker.start('another game'))
        worker.cancel.set(); worker.thread.join(2)
        self.assertFalse(worker.busy)
        self.assertEqual('progress', worker.events.get_nowait()[0])
        self.assertEqual('error', worker.events.get_nowait()[0])


class CatalogTests(unittest.TestCase):
    def test_signature_expiry_key_and_payload_tampering(self):
        import base64
        from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PrivateKey
        from cryptography.hazmat.primitives.serialization import Encoding, PublicFormat
        from pokiguard_v2.compatibility.catalog import DOMAIN, verify_catalog
        key = Ed25519PrivateKey.generate()
        config = {'public_keys': {'release': base64.b64encode(key.public_key().public_bytes(
            Encoding.Raw, PublicFormat.Raw)).decode()}}
        payload = {'schema': 1, 'issued_at': 1000, 'expires_at': 5000, 'profiles': {}}
        document = {'key_id': 'release', 'payload': payload,
                    'signature': base64.b64encode(key.sign(DOMAIN + p.canonical(payload))).decode()}
        self.assertEqual(payload, verify_catalog(document, config, now=1200))
        with self.assertRaisesRegex(p.CompatibilityError, 'EXPIRED'):
            verify_catalog(document, config, now=6000)
        bad = copy.deepcopy(document); bad['payload']['profiles']['evil'] = {}
        with self.assertRaisesRegex(p.CompatibilityError, 'SIGNATURE_INVALID'):
            verify_catalog(bad, config, now=1200)
        bad = copy.deepcopy(document); bad['key_id'] = 'unknown'
        with self.assertRaisesRegex(p.CompatibilityError, 'KEY_UNTRUSTED'):
            verify_catalog(bad, config, now=1200)


class DesktopIsolationTests(unittest.TestCase):
    def test_gameplay_modules_match_pre_feature_checkpoint(self):
        import hashlib
        root = Path(__file__).resolve().parents[1]
        manifest = p.load_json(root / 'tests/fixtures/compatibility/b17_gameplay_manifest.json')
        for name, expected in manifest['files'].items():
            current = (root / name).read_bytes().replace(b'\r\n', b'\n')
            self.assertEqual(expected, hashlib.sha256(current).hexdigest(), name)

    def test_start_and_resume_cannot_race_migration(self):
        from pokiguard_v2.desktop_ui import DesktopApplication
        app = DesktopApplication.__new__(DesktopApplication)
        app._migration_running = True
        app.command_feedback = Mock(); app.view_model = Mock()
        app._start_farm(); app._resume_checkpoint()
        app.view_model.assert_not_called()
        self.assertEqual([], app.view_model.mock_calls)

    def test_close_cancels_worker_before_ui_shutdown(self):
        from pokiguard_v2.desktop_ui import DesktopApplication
        app = DesktopApplication.__new__(DesktopApplication)
        app._closed = app._shutdown_started = False
        app._migration_running = True; app._migration_worker = Mock()
        app.command_feedback = Mock()
        app.close()
        app._migration_worker.cancel.set.assert_called_once()
        self.assertTrue(app._migration_close_requested)
        self.assertFalse(app._shutdown_started)

    def test_aslr_relocations_are_normalized_without_changing_target_memory(self):
        from pokiguard_v2.compatibility.probe import verify_loaded_image
        preferred, base = 0x180000000, 0x220000000
        section = SimpleNamespace(Characteristics=0x20000000, VirtualAddress=0x1000,
                                  get_data=lambda: struct.pack('<Q', preferred + 0x1234) + b'CODE')
        pe = Mock()
        pe.OPTIONAL_HEADER.ImageBase = preferred; pe.sections = [section]
        pe.DIRECTORY_ENTRY_BASERELOC = [SimpleNamespace(entries=[SimpleNamespace(rva=0x1000, type=10)])]
        memory = Mock()
        memory.read.return_value = struct.pack('<Q', base + 0x1234) + b'CODE'
        with patch('pefile.PE', return_value=pe):
            verify_loaded_image(memory, base, Path('fake.dll'))
        memory.read.assert_called_once_with(base + 0x1000, 12)
        self.assertEqual(['read'], [c[0] for c in memory.mock_calls])


class RealB17AuditTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.directory = Path(__file__).resolve().parents[1] / 'reverse/reverse_1.7.4-b17'
        cls.exe = Path('D:/pc/PetPuzzle-1.7.4.exe')
        if not cls.exe.is_file() or not cls.directory.is_dir():
            raise unittest.SkipTest('local B17 evidence is not installed')
        cls.contract = p.load_contract()
        cls.identity = p.install_identity(cls.exe)
        if cls.identity != cls.contract['identity']:
            raise unittest.SkipTest('the real game has moved past B17')

    def test_real_dump_and_binary_reproduce_all_baseline_bindings(self):
        profile = audit_candidate(self.directory, self.exe, self.identity, self.contract)
        self.assertEqual(baseline_profile(self.contract), profile)

    def test_changed_managed_offset_and_static_ownership_are_rejected(self):
        from pokiguard_v2.compatibility.exports import dumper_types
        types = copy.deepcopy(dumper_types(str(self.directory)))
        field = next(iter(types['Assembly-CSharp', 'Board']['fields'].values()))
        field['offset'] += 8
        with patch('pokiguard_v2.compatibility.audit.dumper_types', return_value=types), \
             self.assertRaisesRegex(p.CompatibilityError, 'MANAGED_CONTRACT_CHANGED'):
            audit_candidate(self.directory, self.exe, self.identity, self.contract)
        field['offset'] -= 8; field['type'] = 'static ' + field['type']
        with patch('pokiguard_v2.compatibility.audit.dumper_types', return_value=types), \
             self.assertRaisesRegex(p.CompatibilityError, 'MANAGED_CONTRACT_CHANGED'):
            audit_candidate(self.directory, self.exe, self.identity, self.contract)

    def test_geometry_native_code_change_is_detected(self):
        from pokiguard_v2.compatibility.exports import dumper_script, unique
        script = dumper_script(str(self.directory))
        audit = NativeAudit(self.exe.parent / 'GameAssembly.dll', script)
        try:
            name = 'Poki.MatchHud.MatchHudV2$$SolveBoard'
            before = audit.fingerprint(name)
            start = unique(script['ScriptMethod'], name)['Address']
            audit.pe.set_bytes_at_rva(start, b'\x90')
            try:
                self.assertNotEqual(before, audit.fingerprint(name))
            except p.CompatibilityError:
                pass  # Invalid decoding is also a closed rejection.
        finally:
            audit.close()

    def test_loaded_code_matches_disk_and_rejects_stale_process(self):
        import pefile
        from pokiguard_v2.compatibility.probe import verify_loaded_image
        path = self.exe.parent / 'GameAssembly.dll'
        pe = pefile.PE(str(path), fast_load=True)
        base = pe.OPTIONAL_HEADER.ImageBase
        class Memory:
            corrupt = False
            def read(self, address, size):
                raw = pe.get_data(address - base, size)
                return bytes([raw[0] ^ 1]) + raw[1:] if self.corrupt else raw
        memory = Memory()
        try:
            verify_loaded_image(memory, base, path)
            memory.corrupt = True
            with self.assertRaisesRegex(p.CompatibilityError, 'RUNNING_GAME_DIFFERS_FROM_DISK'):
                verify_loaded_image(memory, base, path)
        finally:
            pe.close()


if __name__ == '__main__':
    unittest.main()
