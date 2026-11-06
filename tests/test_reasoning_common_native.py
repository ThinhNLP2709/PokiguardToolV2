"""Shared native setup/selection with fabricated records and fake native IO."""
from copy import deepcopy
from dataclasses import replace
import hashlib,json,tempfile,time,unittest
from pathlib import Path
from types import SimpleNamespace
from unittest.mock import Mock,patch

from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_calibration import COMMON_DEMON_CONTROL_PROTOCOL
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_common_native import (CommonNativeAuthority,CONTEXT,SCHEMA,REQUIRED_GATES,
    review_bundle,load_common_authority)
from pokiguard_v2.reasoning_common_selection import CommonAdmission,create_common_native_bridge
from pokiguard_v2.reasoning_common_evidence import policy_json
from pokiguard_v2.reasoning_full_actions import publish_context_safely
from pokiguard_v2.reasoning_operational import command_wait_ms
from pokiguard_v2.reasoning_snapshot import FrozenJSON,canonical_json,digest
from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
from tests.test_reasoning_common_evidence import fixture
from tests.test_reasoning_pilot import MemorySink
from tests.test_reasoning_ui_delivery import config as desktop_config,wait


def authority(config):
    return CommonNativeAuthority(policy_json(config),FrozenJSON.of(dict(controller_tail_ms=5,final_input_ms=10,
        selector_extra_ms=5,command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)),
        *['a'*64,'b'*64,'c'*64,'d'*64],time.perf_counter_ns()+60_000_000_000,4000,1)


def bundle(directory,exe_sha='e'*64,absolute=False):
    """All evidence here is synthetic; never install it or label it native acceptance."""
    directory=Path(directory);inputs={};archive={}
    def save(name,value,lines=False):
        raw=('\n'.join(canonical_json(x) for x in value)+'\n').encode() if lines else canonical_json(value).encode()
        (directory/name).write_bytes(raw);opaque=str((directory/name).resolve()) if absolute else 'original/'+name;sha=hashlib.sha256(raw).hexdigest()
        inputs[opaque]=sha;archive[opaque]=dict(path=name,sha256=sha)
        return opaque
    def ref(name,line):return dict(path=name,sha256=inputs[name],line=line)
    cfg=desktop_config(target_completed_matches=3,max_match_attempts=3)
    cfg=replace(cfg,ai=replace(cfg.ai,reasoning_enabled=False))
    source_files={'src/synthetic_no_native.py':'0'*64};source_sha=digest(source_files)
    request=dict(config=jsonable(cfg),total_attempt_cap=3,run_id='1'*32,
        profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL,reasoning_enabled=False,
        source_sha256=source_sha,host_sha256='c'*64,game_build_sha256='b'*64,game_executable_sha256=exe_sha)
    request_name=save('request.json',request)
    binding_name=save('session.json',dict(run_id=request['run_id'],farm_run_id='2'*32,
        config_json=canonical_json(request['config']),total_attempt_cap=3))
    stats=dict(accounting_valid=True,eligible=1,written=1,dropped_before_enqueue=0,
        failed_write=0,discarded_after_enqueue=0,queued=0,in_writer=0)
    watermark_name=save('watermarks.json',dict(run_id=request['run_id'],flushed=True,closed=True,
        collector_dropped=0,collector_disabled=False,before_close=stats,after_close=stats))
    attempts=[dict(attempt_index=i) for i in range(1,4)]
    run_name=save('run.json',dict(snapshot=dict(farm_run_id='2'*32,limits=dict(max_match_attempts=3),
        attempts=attempts,match_attempts=3,completed_matches=3,technical_aborts=0,stop_reason='FARM_TARGET_COMPLETED')))
    source=dict(critical_state_hash='f'*64,session=dict(lifecycle_epoch=1,board_instance=123,match_id='SYNTHETIC_MATCH'),
        srv_seq=2,board_hash='9'*64,turn=2,current_turn_player='SYNTHETIC_PLAYER')
    combat_name=save('combat.jsonl',[dict(event='action_sent',action='SWAP',identity=dict(source=source)),
        dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=dict(source=source)))],True)
    payload=dict(observed_ns=0,observation_read_end_ns=1_000_000,decision_exit_ns=2_000_000,
        preflight_start_ns=3_000_000,read_end_ns=4_000_000,validation_end_ns=5_000_000,
        executor_return_ns=8_000_000,elapsed_upper_bound_ns=5_000_000,controller_tail_ns=1_000_000,
        full_tail_ns=6_000_000,status='RETURNED',required_input_completed=True,sent_clicks=2,click_status='SENT',
        preflight_failure=None,input_mode='foreground',board_input_mode='two_click',timer_source='MatchService.server_tick',
        input_parameters=PARAMETERS,autonomous_source=source,source_hash='f'*64,decision_source_hash='f'*64,
        raw_remaining_seconds=12,remaining=11)
    timing_name=save('timing.jsonl',[dict(event_type='reasoning.swap_timing',
        correlation=dict(run_id=request['run_id']),payload=payload)],True)
    sample=dict(ref(timing_name,1),payload=payload,eligible_for_descriptive_R=True,
        sent=[ref(combat_name,1)],ack=[ref(combat_name,2)])
    export=dict(schema='pokiguard.basic_calibration_export.v1',finalized=True,errors=[],reasoning_authority=False,
        inputs=inputs,request_sha256=inputs[request_name],run_id=request['run_id'],total_attempt_cap=3,
        all_attempts=attempts,all_attempt_count=3,samples=[sample],source_sha256=source_sha,
        host_sha256='c'*64,game_build_sha256='b'*64)
    qualification=dict(source_sha256=source_sha,source_files=source_files,live_attempts=0,input_authority=False,
        host_sha256='c'*64,gates=dict.fromkeys(REQUIRED_GATES,True),
        measurements=[dict(root_ms=.1,fresh_ms=.1,final_ms=.1,triple_ms=.3)]*100)
    def external(name,data):
        raw=canonical_json(data).encode();(directory/name).write_bytes(raw)
        return dict(path=name,sha256=hashlib.sha256(raw).hexdigest())
    data=dict(schema=SCHEMA,source_sha256=source_sha,host_sha256='c'*64,game_build_sha256='b'*64,
        game_executable_sha256=exe_sha,control_export=external('export.json',export),
        qualification=external('qualification.json',qualification),archive=archive,
        roles=dict(request=request_name,binding=binding_name,watermark=watermark_name,run=run_name),max_attempts=3)
    return data,export,external


class CommonNativeTests(unittest.TestCase):
    def test_raw_control_recomputes_components_and_rejects_mutated_source_ack_and_costs(self):
        with tempfile.TemporaryDirectory() as temp:
            data,export,external=bundle(temp)
            c,n=review_bundle(Path(temp),data)
            self.assertEqual((dict(controller_tail_ms=1,final_input_ms=5,selector_extra_ms=.3),1),(c,n))
            mutations=(lambda e:e['samples'][0].update(payload=dict(e['samples'][0]['payload'],source_hash='0'*64)),
                lambda e:e['samples'][0].update(ack=[]),lambda e:e['samples'].append(e['samples'][0]),
                lambda e:e.update(source_sha256='0'*64),lambda e:e.update(errors=['MISSING_ACK']))
            for mutate in mutations:
                changed=deepcopy(export);mutate(changed)
                d=dict(data,control_export=external('mutated_export.json',changed))
                with self.subTest(mutate=mutate),self.assertRaises(ValueError):review_bundle(Path(temp),d)
            q=json.loads((Path(temp)/'qualification.json').read_text('utf-8'));q['gates']={'imagined_pass':True}
            with self.assertRaises(ValueError):review_bundle(Path(temp),dict(data,qualification=external('bad_q.json',q)))

    def test_archive_raw_change_traversal_and_unbound_clock_are_rejected(self):
        with tempfile.TemporaryDirectory() as temp:
            data,export,external=bundle(temp)
            for archive in (dict(data['archive'],**{'original/timing.jsonl':dict(path='../outside',sha256='0'*64)}),
                    {k:v for k,v in data['archive'].items() if k!='original/run.json'}):
                with self.assertRaises(ValueError):review_bundle(Path(temp),dict(data,archive=archive))
            p=Path(temp)/'timing.jsonl';p.write_bytes(p.read_bytes()+b' ')
            with self.assertRaises(ValueError):review_bundle(Path(temp),data)

    def test_plain_offline_context_stays_blocked_for_real_pid_and_native_admission_is_exact(self):
        from tests.test_reasoning_common_selection import admission
        value=fixture();a=authority(value[1]);sink=MemorySink()
        with self.assertRaises(ValueError):CommonAdmission(a.policy_json,FrozenJSON.of(dict(swap=1)),FrozenJSON.of({}),
            context=CONTEXT,native_authority=a)
        b=create_common_native_bridge(enabled=True,authority=a,verified_build_sha256=a.game_build_sha256,diagnostics=sink)
        try:
            self.assertEqual(CONTEXT,b.controller_context(target_pid=123,shared_runtime=True))
            self.assertEqual('PRODUCTION_GATED',b.controller_context(target_pid=0,shared_runtime=True))
            self.assertEqual('PRODUCTION_GATED',b.controller_context(target_pid=123,shared_runtime=False))
            self.assertEqual({'swap','pass'},set(b.admission.reserves.plain()))
            self.assertEqual(b.admission.reserves.plain()['swap'],b.admission.reserves.plain()['pass'])
            now=time.perf_counter_ns()
            problem=b.admission.problem(value,run_id='SYNTHETIC_NATIVE_CONTEXT',generation=1,observed_ns=now,read_end_ns=now)
            self.assertTrue(all(not c.eligible for c in problem.effects if c.action.family!='pass'))
            self.assertTrue(next(c.eligible for c in problem.effects if c.action.family=='pass'))
        finally:self.assertTrue(b.close())

    def test_real_worker_and_host_keep_existing_root_fresh_final_for_native_context(self):
        # Native surfaces are not opened; this exercises only the typed context and worker.
        from pokiguard_v2.basic_policy import BasicPolicyEngine,PlayStyle
        from pokiguard_v2.pet_configuration import MainPetType,EvolutionTarget,DamageCardMode
        value=list(fixture());value[1]=replace(value[1],play_style=PlayStyle.SIMPLE,main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.DEFAULT_ATTACK)
        value[2]=BasicPolicyEngine(value[1]).decide(value[0]);value[3]=None;value=tuple(value)
        state,config,base,*_=value;a=authority(config)
        b=create_common_native_bridge(enabled=True,authority=a,verified_build_sha256=a.game_build_sha256,diagnostics=MemorySink())
        try:
            now=time.perf_counter_ns();self.assertTrue(b.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT))
            publish_context_safely(b,*value)
            self.assertEqual('COMPLETED',b.await_decision(state,base,config,context=CONTEXT,stop_requested=lambda:False),b.preparation_reason)
            selected=select_safely(b,state,base,config,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
            self.assertIsNotNone(selected.receipt)
            for final in (False,True):
                self.assertIsNone(revalidate_safely(b,selected.receipt,state,base,config,
                    now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT,final=final,final_remaining_seconds=12))
            b.admission=replace(b.admission,native_authority=replace(a,valid_until_ns=1))
            rejected=select_safely(b,state,base,config,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
            self.assertEqual(base,rejected.decision);self.assertIn('EXPIRED',rejected.reason)
        finally:self.assertTrue(b.close())

    def test_source_profile_cannot_be_promoted_to_packaged_binary(self):
        with tempfile.TemporaryDirectory() as temp:
            p=Path(temp)/'preferences/reasoning_acceptance';p.mkdir(parents=True)
            (p/'common.json').write_text('{}',encoding='utf-8')
            paths=SimpleNamespace(data_root=Path(temp),frozen=True)
            with patch('pokiguard_v2.reasoning_ui_profile.runtime_source_identity',return_value=('a'*64,{},dict(binary='fake'))):
                with self.assertRaisesRegex(ValueError,'PACKAGE_PENDING'):
                    load_common_authority(desktop_config(),paths=paths,game_executable=Path(temp)/'not_opened.exe')

    def test_file_only_loader_binds_current_source_build_host_and_attempt_cap(self):
        with tempfile.TemporaryDirectory() as temp:
            root=Path(temp);p=root/'preferences/reasoning_acceptance';p.mkdir(parents=True)
            exe=root/'test-only.exe';exe.write_bytes(b'SYNTHETIC_NOT_A_GAME')
            data,export,_=bundle(p,hashlib.sha256(exe.read_bytes()).hexdigest())
            (p/'common.json').write_text(canonical_json(data),encoding='utf-8')
            paths=SimpleNamespace(data_root=root,frozen=False)
            cfg=desktop_config(target_completed_matches=3,max_match_attempts=3)
            with (patch('pokiguard_v2.reasoning_ui_profile.runtime_source_identity',
                    return_value=(data['source_sha256'],{},None)),
                patch('pokiguard_v2.reasoning_operational.host_fingerprint',return_value=data['host_sha256']),
                patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value=data['game_build_sha256'])):
                a=load_common_authority(cfg,paths=paths,game_executable=exe)
                self.assertEqual(1,a.calibration_samples);self.assertGreater(a.reserve_ms,3000)
                with self.assertRaisesRegex(ValueError,'ATTEMPT_CAP'):
                    load_common_authority(replace(cfg,max_match_attempts=4),paths=paths,game_executable=exe)
                exe.write_bytes(b'CHANGED_TEST_FILE')
                with self.assertRaisesRegex(ValueError,'GAME_CHANGED'):
                    load_common_authority(cfg,paths=paths,game_executable=exe)

    def test_common_ui_session_hands_over_two_workers_and_timing_log_without_native_calls(self):
        from pokiguard_v2.basic_policy import BasicPolicyEngine,PlayStyle
        from pokiguard_v2.pet_configuration import MainPetType,EvolutionTarget,DamageCardMode
        from pokiguard_v2.reasoning_ui_session import UIReasoningSession
        from pokiguard_v2.autonomous_control import AutonomousSource
        from pokiguard_v2.win32_input import ClickStatus
        value=list(fixture());value[1]=replace(value[1],play_style=PlayStyle.SIMPLE,main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.DEFAULT_ATTACK)
        value[2]=BasicPolicyEngine(value[1]).decide(value[0]);value[3]=None;value=tuple(value)
        state,config,base,*_=value;a=authority(config)
        with tempfile.TemporaryDirectory() as temp:
            cfg=desktop_config(target_completed_matches=2,max_match_attempts=2)
            session=UIReasoningSession(cfg,a,directory=Path(temp)/'ai',observer=Mock())
            try:
                session.bind_run('SYNTHETIC_FARM',Path(temp)/'farm')
                for _ in range(2):
                    options=session.prepare_options();self.assertIn('selection_adapter',options)
                    b=options['selection_adapter'];c=options['swap_timing_adapter']
                    now=time.perf_counter_ns();self.assertTrue(b.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT))
                    publish_context_safely(b,*value)
                    self.assertEqual('COMPLETED',b.await_decision(state,base,config,context=CONTEXT,stop_requested=lambda:False))
                    c.observe_start();c.observe_end(state=state)
                    c.decision(state=state,config=config,input_parameters=PARAMETERS)
                    c.start(state=state,config=config,input_mode='foreground',source_hash=AutonomousSource.from_state(state).critical_state_hash)
                    c.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
                    c.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
                    c.stop();b.stop();wait(lambda:session.bundle is None)
                self.assertEqual(2,len(session.retired));self.assertFalse(session.faulted,session.first_fault)
            finally:
                session.stop();self.assertTrue(session.wait_closed())
            self.assertEqual(session.totals['processes'],session.totals['reaped'])

    def test_profile_assembly_does_not_install_or_start_and_rechecks_every_raw_pin(self):
        from tools.prepare_common_runtime import prepare,ROOT
        with tempfile.TemporaryDirectory(dir=ROOT/'docs/phase5/artifacts/common_ai_assistant_20261101') as temp:
            root=Path(temp);raw=root/'raw_control';raw.mkdir()
            data,export,_=bundle(raw,absolute=True)
            with patch('tools.prepare_common_runtime.source_fingerprint',return_value=data['source_sha256']):
                result=prepare(raw/'export.json',raw/'qualification.json',root/'assembled')
                self.assertFalse(result['installed']);self.assertFalse(result['automatic_start'])
                self.assertFalse(result['live_acceptance']);self.assertEqual(1,result['samples'])
                with self.assertRaises(ValueError):prepare(raw/'export.json',raw/'qualification.json',root/'too_many',max_attempts=4)


    def test_reviewed_input_timing_reuse_keeps_original_raw_source_and_fourteen_acks(self):
        # Fixture qualification is synthetic here; real launch requires the
        # independently executed current-source qualification, not these values.
        from tools.prepare_common_runtime import prepare_compatible,ROOT
        from pokiguard_v2.reasoning_calibration import source_files
        old=ROOT/'docs/phase5/artifacts/adviser_reasoning_1_20261104_010336/data/preferences/reasoning_acceptance/common.json'
        original=json.loads(old.read_text('utf-8'))
        q=json.loads((old.parent/'qualification.json').read_text('utf-8'))
        b14_manifest=ROOT/'docs/artifacts/rebuild_v1_3_1_20261105/source_manifest.json'
        q['source_files']=json.loads(b14_manifest.read_text('utf-8'))['files']
        q['source_sha256']=digest(q['source_files'])
        current_files=source_files(ROOT)
        with tempfile.TemporaryDirectory(dir=ROOT/'docs/phase5/artifacts') as temp:
            root=Path(temp);qpath=root/'synthetic_qualification.json';qpath.write_text(canonical_json(q),encoding='utf-8')
            out=root/'profile'
            with patch('tools.prepare_common_runtime.source_fingerprint',return_value=q['source_sha256']):
                result=prepare_compatible(old,qpath,out,max_attempts=1)
            data=json.loads((out/'common.json').read_text('utf-8'))
            self.assertEqual(result['samples'],14)
            self.assertEqual(data['control_source_sha256'],original['source_sha256'])
            self.assertNotEqual(data['source_sha256'],data['control_source_sha256'])
            self.assertEqual((out/'control_export.json').read_bytes(),(old.parent/'control_export.json').read_bytes())
            self.assertEqual(original['archive'],data['archive'])
            self.assertFalse(result['automatic_start']);self.assertFalse(result['installed'])
            c,n=review_bundle(out,data)
            self.assertEqual(n,14);self.assertGreater(c['final_input_ms'],2000)
            def mutated_source(name):
                changed=deepcopy(q);changed['source_files'][name]='f'*64
                changed['source_sha256']=digest(changed['source_files'])
                raw=canonical_json(changed).encode();(out/'mutated.json').write_bytes(raw)
                return dict(data,source_sha256=changed['source_sha256'],qualification=dict(
                    path='mutated.json',sha256=hashlib.sha256(raw).hexdigest()))
            for name in ('src/pokiguard_v2/win32_input.py','tools/basic_auto_bot.py',
                    'src/pokiguard_v2/memory_board_provider.py','src/pokiguard_v2/reasoning_common_planner.py',
                    'src/pokiguard_v2/room_invite.py','src/pokiguard_v2/farm_checkpoint.py','src/pokiguard_v2/version.py'):
                with self.subTest(protected=name),self.assertRaisesRegex(ValueError,'IMPLEMENTATION_CHANGED'):
                    review_bundle(out,mutated_source(name))
            if current_files['src/pokiguard_v2/game_location.py']!=q['source_files']['src/pokiguard_v2/game_location.py']:
                current_q=dict(q,source_files=current_files,source_sha256=digest(current_files))
                raw=canonical_json(current_q).encode()
                (out/'current_game_qualification.json').write_bytes(raw)
                with self.assertRaisesRegex(ValueError,'IMPLEMENTATION_CHANGED'):
                    review_bundle(out,dict(data,source_sha256=current_q['source_sha256'],
                        qualification=dict(path='current_game_qualification.json',sha256=hashlib.sha256(raw).hexdigest())))
            with self.assertRaisesRegex(ValueError,'CONTROL_IDENTITY_CHANGED'):
                review_bundle(out,dict(data,control_source_sha256='0'*64))
            with self.assertRaises(ValueError):
                prepare_compatible(old,qpath,root/'too_many',max_attempts=4)
            changed=deepcopy(q);changed['gates']['protected_source']=False
            raw=canonical_json(changed).encode();(out/'failed.json').write_bytes(raw)
            with self.assertRaisesRegex(ValueError,'QUALIFICATION_INVALID'):
                review_bundle(out,dict(data,qualification=dict(path='failed.json',sha256=hashlib.sha256(raw).hexdigest())))


if __name__=='__main__':unittest.main()
