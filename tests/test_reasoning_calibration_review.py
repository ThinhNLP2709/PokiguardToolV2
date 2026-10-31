from tests.game_update_fixture import historical_test_view
"""P13 file-only verifier and fake-worker tests; no game capability."""
from collections import Counter
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import tempfile
import threading
from types import SimpleNamespace
import unittest
from unittest.mock import Mock

from pokiguard_v2.basic_policy import PolicyConfig
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from tests.test_reasoning_operational import native_state, operational_authority
from tests import test_reasoning_operational as operational_tests
from tests.test_reasoning_operational import PARAMS
from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.reasoning_calibration_review import (recompute, verify_review, WITNESS,
    source_compatibility, read_ref)
from pokiguard_v2.reasoning_snapshot import canonical_json, digest, FrozenJSON
from pokiguard_v2.reasoning_pilot_contract import runtime_witness
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector, operational_preflight_failure
from tests.test_reasoning_pilot import MemorySink
from tools.review_reasoning_calibration import export_review, ROOT


class ReviewPackageTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.base=tempfile.TemporaryDirectory(dir=ROOT)
        cls.template=Path(cls.base.name)/'package'
        # Keep P13/P14 semantic tests on their sealed reviewed source. Current
        # P16 runtime is intentionally not accepted by that old source gate.
        shutil.copytree(ROOT/'docs/phase5/artifacts/5d1_operational_launch_p14_v1/review_final',cls.template)
        cls.native=json.loads((cls.template/'calibration_review.json').read_text(encoding='utf-8'))

    @classmethod
    def tearDownClass(cls): cls.base.cleanup()

    def setUp(self):
        self.temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(self.temp.cleanup)
        self.directory=Path(self.temp.name)/'package';shutil.copytree(self.template,self.directory)
        self.data=deepcopy(self.native)

    def verify(self):
        d=self.data
        return verify_review(self.directory,d,runtime_sha256=d['target_runtime_sha256'],
            host_sha256=d['host_sha256'],game_build_sha256=d['game_build_sha256'],
            policy_json=d['policy_json'],witness=d['proposed_scope_witness'])

    def write(self,ref,value,*,lines=False):
        path=self.directory/ref['path']
        path.write_text(('\n'.join(canonical_json(x) for x in value) if lines else canonical_json(value))+'\n',encoding='utf-8')
        ref['sha256']=hashlib.sha256(path.read_bytes()).hexdigest()

    def change(self,role,mutation,*,index=None):
        identity=self.data['roles'][role]
        if index is not None: identity=identity[index]
        ref=self.data['archive_mapping'][identity]
        lines=role in ('records','combats')
        text=(self.directory/ref['path']).read_text(encoding='utf-8')
        value=[json.loads(l) for l in text.splitlines()] if lines else json.loads(text)
        mutation(value);self.write(ref,value,lines=lines)
        # Re-pin all containers to exercise semantic verification, not only SHA.
        export_ref=self.data['raw_export'];export=json.loads((self.directory/export_ref['path']).read_text(encoding='utf-8'))
        if identity in export['inputs']:export['inputs'][identity]=ref['sha256']
        for sample in export['samples']:
            if sample['path']==identity:
                sample['sha256']=ref['sha256']
                if sample['line']<=len(value):sample['payload']=deepcopy(value[sample['line']-1]['payload'])
            for item in sample['sent']+sample['ack']:
                if item['path']==identity:item['sha256']=ref['sha256']
        self.write(export_ref,export)
        archive_ref=self.data['native_archive_manifest']
        archive=json.loads((self.directory/archive_ref['path']).read_text(encoding='utf-8'))
        for name,item in archive['files'].items():
            if identity.endswith(name):item['sha256']=ref['sha256']
        self.write(archive_ref,archive)

    def assert_rejected(self):
        with self.assertRaises((ValueError,KeyError,IndexError,TypeError)): self.verify()

    def test_p13_01_raw_positive_preserves_errors_and_never_activates(self):
        result=self.verify()
        self.assertEqual(result['calibration_samples'],26);self.assertEqual(result['anchor_samples'],20)
        self.assertEqual(result['original_errors'],['MISSING_OR_MIXED_RUNTIME_WITNESS'])
        self.assertFalse(self.data['reasoning_authority']);self.assertFalse(self.data['live_acceptance'])
        self.assertEqual(result['maxima_ms']['I_ms'],2972.325)

    def test_p13_02_opening_is_retained_outside_full_observed_scope(self):
        result=self.verify();opening=[x for x in result['row_classification'] if x['kind']=='opening_deferred']
        self.assertEqual(len(opening),3)
        state=native_state();config=PolicyConfig()
        from pokiguard_v2.state import CardState
        card=CardState(1,2,64647,4,None,None,'ATTACK',None,True,False,False,-1,False,False,0,0,0,False)
        full=replace(state,cards=(card,));a=operational_authority(full,config)
        self.assertTrue(a.matches(full,config))
        self.assertFalse(a.matches(state,config))  # Only cards[] changed.

    def test_p13_03_unexplained_midmatch_empty_rejected(self):
        self.change('records',lambda rows:rows[1]['payload']['witness']['loadout'].update(cards=[]));self.assert_rejected()

    def test_p13_04_extra_card_rejected(self):
        self.change('records',lambda rows:rows[1]['payload']['witness']['loadout']['cards'].append([1,2,'ATTACK',0,0,0]))
        self.assert_rejected()

    def test_p13_05_cost_cooldown_fusion_account_boss_config_drift(self):
        mutations=[lambda p:p['witness']['loadout']['cards'][0].__setitem__(3,1),
                   lambda p:p['witness']['loadout']['cards'][0].__setitem__(5,1),
                   lambda p:p['witness']['loadout']['fusion'].__setitem__(0,1),
                   lambda p:p['witness'].__setitem__('account_username_sha256','f'*64),
                   lambda p:p['witness']['boss'].__setitem__(1,1),
                   lambda p:p['witness']['loadout']['config'].__setitem__(0,'mega_icarus')]
        for mutation in mutations:
            with self.subTest(mutation=mutation):
                self.change('records',lambda rows:mutation(rows[1]['payload']));self.assert_rejected()

    def test_p13_06_terminal_intervals_retained_without_fake_ack(self):
        result=self.verify();terminal=[r for r in result['row_classification'] if r['kind']=='terminal_no_ack']
        self.assertEqual(len(terminal),3)
        self.assertTrue(all(r['event_seq'] not in result['anchor_rows'] for r in terminal))
        self.assertTrue(all(r['evidence']['result']=='ACTION_ABORTED_STATE_CHANGED' for r in terminal))

    def test_p13_07_unexplained_missing_ack_rejected(self):
        def mutate(rows):
            r=next(r for r in rows if r.get('event')=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED')
            r.update(result='ACTION_ABORTED_STATE_CHANGED',reason='COMBAT_LIFECYCLE_ENDED')
        self.change('combats',mutate,index=0);self.assert_rejected()

    def test_p13_08_duplicate_ack_or_source_rejected(self):
        def mutate(rows): rows.append(deepcopy(next(r for r in rows if r.get('result')=='SWAP_ACKNOWLEDGED')))
        self.change('combats',mutate,index=0);self.assert_rejected()
        self.change('records',lambda rows:rows[1]['payload'].update(autonomous_source=deepcopy(rows[0]['payload']['autonomous_source'])))
        self.assert_rejected()

    def test_p13_09_all_evolve_decisions_include_failed_attempt(self):
        rows=[r for r in self.verify()['row_classification'] if r['kind']=='superseded_evolve']
        self.assertEqual(len(rows),4);self.assertEqual(sum(r['evidence']['outcome']=='EVOLVE_FAILED' for r in rows),1)
        self.change('records',lambda rows:next(r for r in rows if r['event_type']=='reasoning.decision_timing')['payload'].update(decision_source_hash='f'*64))
        self.assert_rejected()

    def test_p13_10_row_removal_reorder_and_omitted_attempt(self):
        self.change('records',lambda rows:rows.reverse());self.assert_rejected()
        self.change('run',lambda run:run['snapshot']['attempts'].pop());self.assert_rejected()

    def test_p13_11_declared_classification_forgery(self):
        self.data['review']['anchor_rows'].append(1);self.assert_rejected()

    def test_p13_12_nonmonotonic_missing_or_stale_timestamps(self):
        self.change('records',lambda rows:rows[1]['payload'].update(executor_return_ns=0));self.assert_rejected()
        self.change('records',lambda rows:rows[1]['payload'].pop('decision_exit_ns'));self.assert_rejected()

    def test_p13_13_partial_input_cannot_supply_envelope(self):
        self.change('records',lambda rows:rows[1]['payload'].update(sent_clicks=1,required_input_completed=False))
        self.assert_rejected()

    def test_p13_14_non_anchor_maximum_is_included(self):
        def mutate(rows):
            p=rows[0]['payload'];p['executor_return_ns']+=4_000_000_000
            p['elapsed_upper_bound_ns']+=4_000_000_000;p['full_tail_ns']+=4_000_000_000
        self.change('records',mutate)
        result=recompute(self.directory,self.data)
        self.assertGreater(result['maxima_ms']['I_ms'],5000)
        self.assertNotIn(1,result['anchor_rows'])

    def test_p13_15_watermark_loss_unclosed_or_mismatch(self):
        self.change('watermarks',lambda w:w.update(collector_dropped=1));self.assert_rejected()
        self.change('watermarks',lambda w:w.update(collector_dropped=0,closed=False));self.assert_rejected()

    def test_p13_16_sha_path_alias_and_size_rejected(self):
        ref=self.data['raw_export'];ref['sha256']='f'*64;self.assert_rejected()
        for name in ('../escape.json','D:/pc/file','/absolute','raw\\bad'):
            with self.subTest(name=name), self.assertRaises(ValueError):
                read_ref(self.directory,dict(path=name,sha256='0'*64))
        with self.assertRaises(ValueError):read_ref(self.directory,self.data['native_archive_manifest'],cap=1)
        self.data=deepcopy(self.native)
        keys=list(self.data['archive_mapping'])
        self.data['archive_mapping'][keys[1]]=deepcopy(self.data['archive_mapping'][keys[0]])
        self.assert_rejected()

    def test_p13_17_legacy_mixed_export_still_rejected(self):
        helper=operational_tests.OperationalLoaderTests();d=self.directory;data,doc=helper.package(d)
        cal=json.loads((d/data['calibration']['path']).read_text(encoding='utf-8'))
        raw=json.loads((d/self.data['raw_export']['path']).read_text(encoding='utf-8'))
        cal['farm_export']=doc('MIXED_P11.json',raw);data['calibration']=doc('MIXED_CAL.json',cal)
        with self.assertRaises(ValueError):helper.load(d,data)

    def test_p13_18_missing_dependency_review_or_relabel_rejected(self):
        self.data['native_runtime_sha256']=self.data['target_runtime_sha256'];self.assert_rejected()

    def test_p13_19_changed_native_input_dependency_rejected(self):
        ref=self.data['source_compatibility'];c=json.loads((self.directory/ref['path']).read_text(encoding='utf-8'))
        c['target_files']['src/pokiguard_v2/win32_input.py']='0'*64
        c['target_runtime_sha256']=digest(c['target_files']);self.data['target_runtime_sha256']=c['target_runtime_sha256']
        self.write(ref,c);self.assert_rejected()

    def test_p13_20_old_selector_pin_rejected(self):
        helper=operational_tests.OperationalLoaderTests();data,doc=helper.package(self.directory)
        data['selector_allowance']=doc('OLD_ALLOWANCE.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
            runtime_sha256='0'*64,host_sha256=data['host_sha256'],paths=dict(completed=1,timeout=1,error=1,fallback=1)))
        with self.assertRaises(ValueError):helper.load(self.directory,data)

    def test_p13_21_independent_activation_remains_required(self):
        helper=operational_tests.OperationalLoaderTests();data,doc=helper.package(self.directory)
        for change in ('approval','expiry','cap','host','build','config'):
            current=deepcopy(data)
            if change=='approval':
                current['activation_review']=doc('UNAPPROVED.json',dict(accepted=False))
                current['activation_sha256']=current['activation_review']['sha256']
            elif change=='expiry':current['expires_at']=140
            elif change=='cap':current['total_attempt_cap']=13
            elif change=='host':current['host_sha256']='0'*64
            elif change=='build':current['game_build_sha256']='0'*64
            else:current['full_config_sha256']='0'*64
            with self.subTest(change=change),self.assertRaises((ValueError,KeyError)):helper.load(self.directory,current)

    def test_p13_23_read_span_boundary_veto_only_operational(self):
        state=native_state();config=PolicyConfig();a=operational_authority(state,config,max_read_span_ms=100)
        for span,accepted in ((100_000_000,True),(100_000_001,False),(-1,False)):
            bridge=object.__new__(PilotSelectionBridge)
            bridge.enabled=True;bridge.stopped=False;bridge.disabled=False;bridge.pilot_authority=a
            bridge.bridge_counts=Counter();bridge.request_lock=threading.Lock();bridge.request=None
            bridge.decision_budget=True;bridge.wake=threading.Event()
            self.assertEqual(bridge.observe(state,config,observed_ns=100,
                read_end_ns=100+span,context=a.context),accepted)
        for span,expected in ((100_000_000,None),(100_000_001,'OPERATIONAL_READ_SPAN_EXCEEDED'),(-1,'OPERATIONAL_READ_SPAN_EXCEEDED')):
            b=SwapTimingCollector(sink=MemorySink(),operational_authority=a)
            b.observe_start();b.observe_end(state=state);b.decision(state=state,config=config,input_parameters=PARAMS)
            b.start(state=state,config=config,input_mode='foreground',source_hash=AutonomousSource.from_state(state).critical_state_hash)
            failure=operational_preflight_failure(b,read_end_ns=b.pending['preflight_start_ns']+span,input_parameters=PARAMS)
            self.assertEqual(failure,expected)
        basic=SwapTimingCollector(sink=MemorySink())
        self.assertIsNone(operational_preflight_failure(basic,read_end_ns=-1,input_parameters={}))

    def test_reviewed_loader_uses_all_26_intervals_with_independent_fake_activation(self):
        helper=operational_tests.OperationalLoaderTests();data,doc=helper.package(self.directory)
        for field in ('runtime_sha256','host_sha256','game_build_sha256','policy_json'):
            data[field]=self.data['target_runtime_sha256' if field=='runtime_sha256' else field]
        data['witness']=deepcopy(WITNESS);data['max_read_span_ms']=100
        data['calibration']=doc('SYNTHETIC_REVIEWED_CAL.json',self.data)
        review={k:data[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
            'host_sha256','contract_sha256','decision_sha256')}
        data['activation_review']=doc('SYNTHETIC_REVIEWED_ACTIVATION.json',review|dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT'))
        data['activation_sha256']=data['activation_review']['sha256']
        paths=dict(completed=2,timeout=1,error=1,fallback=1)
        q=doc('SYNTHETIC_QUALIFICATION.json',dict(pass_all=True,gates=dict(fake_only=True),
            runtime_sha256=data['runtime_sha256'],host_sha256=data['host_sha256'],
            selector_paths_ms={k:dict(max=v) for k,v in paths.items()}))
        data['selector_allowance']=doc('SYNTHETIC_FRESH_ALLOWANCE.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
            runtime_sha256=data['runtime_sha256'],host_sha256=data['host_sha256'],paths=paths,qualification=q))
        authority=helper.load(self.directory,data)
        self.assertEqual(authority.calibration_samples,26);self.assertEqual(authority.max_read_span_ms,100)
        self.assertEqual(authority.reserve_components.plain()['final_input_ms'],2972.325)
        self.assertIsNone(authority.native_U_ms)
        data['selector_allowance']=doc('STALE_REVIEWED_ALLOWANCE.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
            runtime_sha256='0'*64,host_sha256=data['host_sha256'],paths=paths,qualification=q))
        with self.assertRaises(ValueError):helper.load(self.directory,data)

    @historical_test_view()
    def test_p13_26_historical_sources_rewind_exactly(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        assert_c3_source_compatibility(self)

    def test_p13_24_disabled_controller_keeps_sequence(self):
        from tests.reasoning_controller_fixture import controller_trace
        from tests.test_reasoning_selection import original_controller
        for case in ('normal','pending','stale','wrong_turn','stop'):
            with self.subTest(case=case):
                before=controller_trace(self.directory/(case+'_before.jsonl'),case=case,controller_module=original_controller())
                after=controller_trace(self.directory/(case+'_after.jsonl'),case=case)
                self.assertEqual(before,after)


class CalibrationReviewTests(unittest.TestCase):
    def test_old_active_mismatch_releases_owner_and_signals_without_deadline_wait(self):
        state = native_state(); config = PolicyConfig()
        bridge = object.__new__(PilotSelectionBridge)
        bridge.pilot_authority = operational_authority(state, config)
        bridge.active = object(); bridge.completed = object()
        bridge.runner = Mock(); bridge.bridge_counts = Counter()
        changed = replace(state, battle=replace(state.battle, local_username='UNSUPPORTED'))
        bridge.shutdown=threading.Event();bridge.request_lock=threading.Lock()
        bridge.wake=Mock();bridge.request=(changed,config,1,1)
        bridge.disabled=False;bridge.runner.breaker.disabled=False
        bridge.runner.close.return_value=True;bridge.owns_sink=False
        bridge.sink=SimpleNamespace(buffer=SimpleNamespace(disabled=False))
        bridge.result_ready=Mock();bridge._drain=Mock()
        bridge._complete=Mock(side_effect=bridge.shutdown.set)  # One owner iteration.
        bridge._serve()
        self.assertIsNone(bridge.active)
        self.assertIsNone(bridge.completed)
        bridge.result_ready.set.assert_called_once_with()
        bridge.runner.invalidate.assert_called_once_with()


if __name__ == '__main__':
    unittest.main()
