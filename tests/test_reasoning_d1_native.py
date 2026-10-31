"""Main D1 offline tests. Synthetic native provenance is never live evidence."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import PolicyConfig,PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint
from pokiguard_v2.reasoning_operational import host_fingerprint
from pokiguard_v2.reasoning_operational_launch import operational_policy_json,OperationalPilotLaunch
from pokiguard_v2.reasoning_snapshot import canonical_json,digest,FrozenJSON
from pokiguard_v2.reasoning_d1_native import SCHEMA,PROTOCOL,SOURCE_POLICY,check_config,verify_native,validate_costs
from pokiguard_v2.reasoning_config_projection import VERSION
from pokiguard_v2.reasoning_root_policy import POLICY
from tests.test_reasoning_operational import operational_authority,native_state,PARAMS
from tests import test_reasoning_operational as native_fixtures
from tests.test_reasoning_pilot import MemorySink
from tests.reasoning_controller_fixture import controller_trace

ROOT=Path(__file__).resolve().parents[1]


class D1NativeTests(unittest.TestCase):
    def setUp(self):
        temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(temp.cleanup);self.directory=Path(temp.name)
        self.fixture=native_fixtures.OperationalLoaderTests()
        from pokiguard_v2.state import CardState
        card=CardState(1,2,64647,4,None,None,'ATTACK',None,True,False,False,-1,False,False,0,0,0,False)
        full=replace(native_state(),cards=(card,))
        with patch.object(native_fixtures,'native_state',return_value=full):
            self.data,self.doc=self.fixture.package(self.directory)
        self.source=source_fingerprint(ROOT);self.host=host_fingerprint()
        self.costs=dict(selector_extra_ms=10,checkpoint_admission_max_ms=7,full_pipeline_max_ms=3,
            raw_values=61000,measured_values=51000,stress_evidence='RECEIPT_ONLY_NO_PER_CYCLE_TRACE',
            completed_branch='RETENTION_ONLY_NO_OVERRIDE_QUOTA')
        self.convert('simple')

    def get(self,ref):return json.loads((self.directory/ref['path']).read_text(encoding='utf-8'))
    def update(self,key,value):self.data[key]=self.doc('UPDATED_'+key+'.json',value)

    def convert(self,profile):
        from pokiguard_v2.gameplay_profile import MainPetType,EvolutionTarget,DamageCardMode
        d=self.data
        config=replace(DesktopConfig(),play_style=PlayStyle(profile),boss_id='1289',boss_name='SYNTHETIC',
            main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.NORMAL,damage_card=DamageCardMode.DEFAULT_ATTACK,
            target_completed_matches=3,max_match_attempts=3)
        check_config(config);policy=operational_policy_json(config)
        self.config=config
        d.update(runtime_sha256=self.source,host_sha256=self.host,policy_json=policy,pilot_protocol=PROTOCOL,
            root_read_policy=POLICY,config_projection_policy=VERSION,source_projection_policy=SOURCE_POLICY,
            max_read_span_ms=100,host_guard_ms=250,return_margin_ms=100,component_monitor='POST_RETURN_COMPONENTS_V1',
            command_ceiling_version='TWO_CLICKS_TWO_SETTLES_V1',input_parameters=PARAMS,
            full_config=jsonable(config),full_config_sha256=digest(jsonable(config)))
        cal=self.get(d['calibration']);cal.update(schema=SCHEMA,runtime_sha256=self.source,host_sha256=self.host,
            game_build_sha256=d['game_build_sha256'],policy_json=policy)
        cal['source_manifest']=self.doc('CURRENT_SOURCE.json',dict(files=source_files(ROOT),fingerprint=self.source))
        farm=self.get(cal['farm_export']);farm.update(source_sha256=self.source,host_sha256=self.host)
        cal['farm_export']=self.doc('CURRENT_FARM_EXPORT.json',farm)
        request=dict(schema='pokiguard.basic_calibration_request.v1',reasoning_enabled=False,run_id='b'*32,
            source_sha256=self.source,host_sha256=self.host,game_build_sha256=d['game_build_sha256'],
            total_attempt_cap=3,config=jsonable(config))
        cal['native_request']=self.doc('CURRENT_NATIVE_REQUEST.json',request)
        cal['native_session']=self.doc('CURRENT_NATIVE_SESSION.json',dict(run_id='b'*32,farm_run_id='SYNTHETIC_FARM',
            total_attempt_cap=3,config_json=canonical_json(jsonable(config))))
        cal['farm_run']=self.doc('CURRENT_FARM_RUN.json',dict(snapshot=dict(farm_run_id='SYNTHETIC_FARM',
            limits=dict(max_match_attempts=3),match_attempts=1,attempts=farm['all_attempts'])))
        records=[json.loads(s) for s in (self.directory/cal['records']['path']).read_text().splitlines()]
        for row in records:
            row['payload']['policy_sha256']=digest(json.loads(policy));row['correlation']['run_id']='b'*32
        p=self.directory/'CURRENT_TIMING.jsonl';p.write_text('\n'.join(canonical_json(x) for x in records),encoding='utf-8')
        import hashlib
        cal['records']=dict(path=p.name,sha256=hashlib.sha256(p.read_bytes()).hexdigest())
        water=self.get(cal['watermarks']);water['run_id']='b'*32;cal['watermarks']=self.doc('CURRENT_WATER.json',water)
        d['calibration']=self.doc('CURRENT_CAL.json',cal)
        allowance=dict(scope='CURRENT_NATIVE_D1_SELECTOR',runtime_sha256=self.source,host_sha256=self.host,
            costs=self.costs,qualification=self.doc('SYNTHETIC_COST.json',dict(profile=profile)))
        d['selector_allowance']=self.doc('CURRENT_ALLOWANCE.json',allowance)
        self.approve()

    def approve(self):
        d=self.data;activation={k:d[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
            'host_sha256','contract_sha256','decision_sha256','pilot_protocol','root_read_policy',
            'config_projection_policy','source_projection_policy')}
        activation.update(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT',calibration_sha256=d['calibration']['sha256'],
            selector_allowance_sha256=d['selector_allowance']['sha256'])
        d['activation_review']=self.doc('CURRENT_ACTIVATION.json',activation);d['activation_sha256']=d['activation_review']['sha256']

    def load(self):
        with patch('pokiguard_v2.reasoning_d1_native.validate_costs',return_value=self.costs):
            return self.fixture.load(self.directory,self.data)

    def test_current_native_supports_each_profile_with_exact_read_policy(self):
        for profile in ('simple','careful'):
            self.convert(profile);a=self.load()
            self.assertEqual(a.profile,profile);self.assertEqual((a.max_root_poll_span_ms,a.max_read_span_ms),(250,100))
            self.assertEqual(a.config_projection_policy,VERSION);self.assertIsNone(a.native_U_ms)

    def test_draft_or_missing_independent_pins_cannot_activate(self):
        activation=self.get(self.data['activation_review']);activation['accepted']=False
        self.update('activation_review',activation);self.data['activation_sha256']=self.data['activation_review']['sha256']
        with self.assertRaises(ValueError):self.load()
        self.approve();activation=self.get(self.data['activation_review']);activation['calibration_sha256']='0'*64
        self.update('activation_review',activation);self.data['activation_sha256']=self.data['activation_review']['sha256']
        with self.assertRaises(ValueError):self.load()

    def test_source_host_policy_raw_ledger_watermark_tampering_rejected(self):
        original=deepcopy(self.data);cal=self.get(self.data['calibration'])
        for key,value in [('runtime_sha256','0'*64),('host_sha256','0'*64),('game_build_sha256','0'*64),
                          ('policy_json','{}'),('total_attempt_cap',4)]:
            self.data=deepcopy(original);self.update('calibration',cal|{key:value});self.approve()
            with self.subTest(key=key),self.assertRaises(ValueError):self.load()
        for role,change in [('watermarks',lambda x:x.update(collector_dropped=1)),
                            ('attempt_ledger',lambda x:x.clear()),
                            ('source_manifest',lambda x:x['files'].update({'unreviewed':'0'*64})),
                            ('native_session',lambda x:x.update(run_id='other')),
                            ('farm_run',lambda x:x['snapshot'].update(match_attempts=2))]:
            self.data=deepcopy(original);altered=deepcopy(cal);v=self.get(altered[role]);change(v)
            altered[role]=self.doc('BAD_'+role+'.json',v);self.update('calibration',altered);self.approve()
            with self.subTest(role=role),self.assertRaises(ValueError):self.load()

    def test_wrong_turn_source_duplicate_and_missing_ACK_rejected(self):
        original=deepcopy(self.data);cal=self.get(self.data['calibration']);p=self.directory/cal['records']['path']
        raw=p.read_text();row=json.loads(raw)
        for change in ('source','clock','parameter'):
            v=deepcopy(row)
            if change=='source':v['payload']['source_hash']='wrong'
            elif change=='clock':v['payload']['decision_exit_ns']=v['payload']['executor_return_ns']+1
            else:v['payload']['input_parameters']={}
            path=self.directory/'BAD_TIMING.jsonl';path.write_text(canonical_json(v),encoding='utf-8')
            import hashlib
            self.data=deepcopy(original);bad=deepcopy(cal);bad['records']=dict(path=path.name,sha256=hashlib.sha256(path.read_bytes()).hexdigest())
            self.update('calibration',bad);self.approve()
            with self.subTest(change=change),self.assertRaises(ValueError):self.load()
        self.data=deepcopy(original);bad=deepcopy(cal);bad['combat_records']=[self.doc('EMPTY_COMBAT.jsonl',{})]
        self.update('calibration',bad);self.approve()
        with self.assertRaises(ValueError):self.load()

    def test_failed_costs_remain_rejected_before_authority(self):
        with patch('pokiguard_v2.reasoning_d1_native.validate_costs',side_effect=ValueError('SYNTHETIC_GATE_FAIL')):
            with self.assertRaisesRegex(ValueError,'SYNTHETIC_GATE_FAIL'):self.fixture.load(self.directory,self.data)

    def test_terminal_return_requires_strong_same_source_proof_and_keeps_all_costs(self):
        cal=self.get(self.data['calibration']);row=self.get(cal['records'])
        source=deepcopy(row['payload']['autonomous_source']);source['turn']+=1;source['srv_seq']+=1
        source['critical_state_hash']='f'*64
        second=deepcopy(row);second['event_seq']=2;p=second['payload']
        p.update(autonomous_source=source,turn=source['turn'],source_hash='f'*64,decision_source_hash='f'*64)
        rows=[json.loads(s) for s in (self.directory/cal['combat_records'][0]['path']).read_text().splitlines()]
        snapshot=dict(session_key=source['session'],match_id=source['session']['match_id'],turn_number=source['turn'],
            srv_seq=source['srv_seq'],result='WIN',confidence='STRONG',boss_hp=0,captured_before_cleanup=True)
        rows.extend([dict(event='action_sent',action='SWAP',identity=dict(source=source)),
            dict(event='action_result',result='ACTION_ABORTED_STATE_CHANGED',reason='COMBAT_LIFECYCLE_ENDED',
                action=dict(identity=dict(source=source))),
            dict(event='auto_controller_summary',stopReason='COMBAT_LIFECYCLE_ENDED',terminalCombatSnapshot=snapshot)])
        import hashlib
        timing=self.directory/'TWO_TIMING.jsonl';timing.write_text(canonical_json(row)+'\n'+canonical_json(second),encoding='utf-8')
        cal['records']=dict(path=timing.name,sha256=hashlib.sha256(timing.read_bytes()).hexdigest())
        combat=self.directory/'TERMINAL_COMBAT.jsonl';combat.write_text('\n'.join(canonical_json(x) for x in rows),encoding='utf-8')
        cal['combat_records']=[dict(path=combat.name,sha256=hashlib.sha256(combat.read_bytes()).hexdigest())]
        farm=self.get(cal['farm_export']);farm['all_attempts'][0].update(session_key=source['session'],
            match_id=source['session']['match_id'],terminal_snapshot=snapshot,result='WIN',normal_postmatch=True)
        cal['farm_export']=self.doc('TERMINAL_FARM_EXPORT.json',farm)
        run=self.get(cal['farm_run']);run['snapshot']['attempts']=farm['all_attempts'];cal['farm_run']=self.doc('TERMINAL_RUN.json',run)
        water=self.get(cal['watermarks']);water['sequence']=2;water['before_close'].update(eligible=2,written=2)
        cal['watermarks']=self.doc('TWO_WATER.json',water)
        self.update('calibration',cal);self.approve();a=self.load()
        self.assertEqual(a.calibration_samples,1)
        evidence=verify_native(self.directory,cal,SimpleNamespace(runtime_sha256=self.source,
            host_sha256=self.host,verified_build_sha256=self.data['game_build_sha256']),
            policy_json=self.data['policy_json'],witness=self.data['witness'])
        self.assertEqual((evidence['returns'],evidence['anchors']),(2,1))
        self.assertEqual(evidence['intervals'][1]['classification'],'TERMINAL_PROVED')
        farm['all_attempts'][0]['terminal_snapshot']['srv_seq']+=1
        cal['farm_export']=self.doc('WRONG_TERMINAL.json',farm)
        run['snapshot']['attempts']=farm['all_attempts'];cal['farm_run']=self.doc('WRONG_TERMINAL_RUN.json',run)
        self.update('calibration',cal);self.approve()
        with self.assertRaisesRegex(ValueError,'sent/ACK or terminal'):self.load()

    def test_qualification_of_other_profile_is_rejected(self):
        allowance=self.get(self.data['selector_allowance'])
        allowance['qualification']=self.doc('OTHER_PROFILE.json',dict(profile='careful'))
        self.update('selector_allowance',allowance);self.approve()
        with self.assertRaisesRegex(ValueError,'qualification profile differs'):self.load()

    def test_package_completed_controls_is_false_draft_without_claim(self):
        import shutil
        from tools.prepare_d1_pilot import prepare
        cal=self.get(self.data['calibration']);timing=self.directory/'timing';farm=self.directory/'farm'
        timing.mkdir();(farm/'matches/attempt_001').mkdir(parents=True)
        native=self.get(cal['native_request']);native.update(game_executable=str(self.directory/'SYNTHETIC.exe'),
            game_executable_sha256='e'*64)
        request=self.directory/'request.json';request.write_text(canonical_json(native),encoding='utf-8')
        session=self.get(cal['native_session']);session['farm_directory']=str(farm.resolve())
        (timing/'session.json').write_text(canonical_json(session),encoding='utf-8')
        shutil.copyfile(self.directory/cal['watermarks']['path'],timing/'watermarks.json')
        shutil.copyfile(self.directory/cal['records']['path'],timing/'reasoning.jsonl')
        shutil.copyfile(self.directory/cal['farm_run']['path'],farm/'run.json')
        shutil.copyfile(self.directory/cal['combat_records'][0]['path'],farm/'matches/attempt_001/combat.jsonl')
        qdir=self.directory/'q';qdir.mkdir();q=qdir/'qualification.json';q.write_text('{"profile":"simple"}',encoding='utf-8')
        with patch('tools.prepare_d1_pilot.validate_costs',return_value=self.costs):
            draft=prepare(request,timing,farm,q,self.directory/'draft')
        self.assertFalse(draft['accepted']);self.assertFalse(draft['live_acceptance']);self.assertFalse(draft['claim_created'])
        self.assertEqual(draft['operational_supplement_samples'],0)
        self.assertNotIn('P15_MISSING_16_TIMINGS',draft['limitations'])
        self.assertIsNone(draft['request_template']['run_id']);self.assertIsNone(draft['request_template']['expires_at'])
        self.assertIsNone(draft['request_template']['activation_review'])

    def test_default_scope_rejects_demon_mega_coop_and_extra_attempts(self):
        from pokiguard_v2.gameplay_profile import GameMode
        base=DesktopConfig()
        for changes in (dict(play_style=PlayStyle.DEMON_AEGIS_FARM),dict(play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL),
                        dict(max_match_attempts=4),dict(game_mode=GameMode.COOP)):
            with self.assertRaises(ValueError):check_config(replace(base,**changes))

    def test_both_profile_launch_previews_require_native_and_costs_without_worker_or_claim(self):
        import hashlib
        for profile in ('simple','careful'):
            self.convert(profile);d=self.data;d['game_executable']=str(self.directory/'SYNTHETIC.exe')
            d['game_executable_sha256']='e'*64;self.approve()
            p=self.directory/'CURRENT_LAUNCH.json';p.write_text(canonical_json(d),encoding='utf-8')
            with patch('pokiguard_v2.reasoning_d1_native.validate_costs',return_value=self.costs), \
                    patch('pokiguard_v2.reasoning_operational_launch.source_fingerprint',return_value=self.source), \
                    patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value=d['game_build_sha256']), \
                    patch('pokiguard_v2.game_location.game_assembly_sha256',return_value='e'*64), \
                    patch('pokiguard_v2.reasoning_pilot.create_pilot_bridge',side_effect=AssertionError('worker')):
                gate=OperationalPilotLaunch(p,hashlib.sha256(p.read_bytes()).hexdigest(),root=self.directory,
                    directory=self.directory/'pilot',game_executable=lambda:d['game_executable'],now=150)
                self.assertIsNone(gate.session);self.assertFalse(gate.claim_path.exists())
                self.assertEqual(gate.config.play_style.value,profile)
            with patch('pokiguard_v2.reasoning_d1_native.validate_costs',side_effect=ValueError('COST_FAIL')):
                with self.assertRaises(ValueError):self.fixture.load(self.directory,self.data)

    def test_source_projection_matches_legacy_current_state_without_alias(self):
        from pokiguard_v2.autonomous_control import AutonomousSource
        from pokiguard_v2.reasoning_source_projection import project_source
        source=AutonomousSource.from_state(native_state())
        for turn in (None,True,0,1,2**60,'x',[],{'x':1},float('inf')):
            value=replace(source,turn=turn)
            self.assertEqual(project_source(value),jsonable(value))
        a=project_source(source);a['session']['match_id']='mutation'
        self.assertEqual(project_source(source),jsonable(source))


class D1FlowTests(unittest.TestCase):
    def test_both_profiles_read_input_ACK_and_AI_fault_fallback(self):
        from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
        from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
        for profile in ('simple','careful'):
            for fault in (False,True):
                box={}
                def bridge(s,c):
                    a=operational_authority(s,c,max_read_span_ms=100,root_read_policy=FrozenJSON.of(POLICY),
                        config_projection_policy=VERSION)
                    b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                        enabled=True,decision_budget=True,warm_worker=True);box['b']=b;self.addCleanup(b.close);return b
                def timing(s,c):return SwapTimingCollector(sink=box['b'].timing_diagnostics,
                    operational_authority=box['b'].pilot_authority,component_monitor=True)
                with tempfile.TemporaryDirectory() as name:
                    d=Path(name);kw=dict(profile=profile,initial_combat=native_state(),real_processing_clock=True,
                        timer_source='MatchService.server_tick')
                    base=controller_trace(d/'basic.jsonl',**kw)
                    with patch('pokiguard_v2.reasoning_source_projection.project_source',
                        side_effect=RuntimeError('SYNTHETIC_AI_ONLY') if fault else None,
                        wraps=None if fault else __import__('pokiguard_v2.reasoning_source_projection',fromlist=['project_source']).project_source):
                        ai=controller_trace(d/'reasoning.jsonl',**kw,target_pid=7,selection_factory=bridge,timing_factory=timing)
                    self.assertEqual(base[1],ai[1]);self.assertEqual(ai[1].count('FAKE_NORMAL_INPUT'),1)
                    self.assertEqual(ai[1].count('executor.ack'),1);self.assertTrue(box['b'].close())


if __name__=='__main__':unittest.main()
