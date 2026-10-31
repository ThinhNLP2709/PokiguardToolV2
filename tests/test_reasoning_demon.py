"""D3 exact-board replay and synthetic boundary tests. Never native input."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import threading
import tempfile
import time
import unittest
from unittest.mock import patch
from tests.game_update_fixture import historical_test_view, before_game_update_path

from pokiguard_v2.basic_policy import BasicPolicyEngine, _candidate_trace
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.board_simulator import SwapMove, simulate_move
from pokiguard_v2.reasoning_demon import MODEL, VERSION, bind_snapshot, plan_demon
from pokiguard_v2.reasoning_operational import OperationalPilotAuthority, command_wait_ms
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge, snapshot_from_state
from pokiguard_v2.reasoning_pilot_contract import runtime_witness
from pokiguard_v2.reasoning_planner import plan
from pokiguard_v2.reasoning_runner import make_job, _reply_for, _decision_summary, JOB_SCHEMA
from pokiguard_v2.reasoning_selection import (Capability, CompletedProposal, GuardedSelectionAdapter,
    select_safely, revalidate_safely)
from pokiguard_v2.reasoning_snapshot import FrozenJSON, Action, canonical_json, digest
from pokiguard_v2.state import BoardState, CellState, CombatSessionKey, GemType, ParticipantState
from tests.test_basic_policy import combat_state
from tests.test_demon_aegis_farm import demon_policy
from tests.test_reasoning_pilot import MemorySink

ROOT=Path(__file__).resolve().parents[1]
ART=ROOT/'docs/phase5/artifacts/5d3_lieyun_basic3_live_20261018_021056'
PARAMS=dict(cursor_settle_seconds=.06,mouse_button_hold_seconds=.075)


def native_row(turn=9):
    rows=json.loads((ART/'native_replay_inputs.json').read_text(encoding='utf-8'))
    return next(r for r in rows if r['attempt']==2 and r['turn']==turn)


def fixture(turn=9, *, board=None, rage=None, hp=None, baseline=None):
    """Observed board/stats, explicitly reconstructed FAKE GameState/authority."""
    row=native_row(turn)
    cells=board or row['board']
    board=BoardState(tuple(tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(line))
        for r,line in enumerate(cells)))
    s=combat_state(board=board)
    player=ParticipantState(**row['player']);boss=ParticipantState(**row['boss'])
    if rage is not None:player=replace(player,power=rage)
    if hp is not None:player=replace(player,hp=hp)
    session=CombatSessionKey(**dict(lifecycle_epoch=2,board_instance=12345,match_id='SYNTHETIC_D3_REPLAY'))
    battle=replace(s.battle,session_key=session,board_instance=session.board_instance,match_id=session.match_id,
        local_username='SYNTHETIC_D3',current_turn_player='SYNTHETIC_D3',turn_number=turn,srv_seq=turn,
        board_hash=digest(cells),turn_time_remaining_seconds=13,turn_timer_source='MatchService.server_tick')
    s=replace(s,battle=battle,player=player,opponents=(boss,),participants=(player,boss),fusion=None,cards=())
    c=replace(demon_policy(threshold=4).config,minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1)
    # Preserve the historical physical-count BASIC counterfactual for the old
    # D3 experiment. Current weighted BASIC behavior has its own replay tests.
    from tests.game_update_fixture import archived_demon_engine
    b=archived_demon_engine(ROOT,'demon_effective_sword_20261022',c).decide(s)
    if baseline is not None:
        move=baseline if isinstance(baseline,SwapMove) else SwapMove(tuple(row['baseline_move']['first']),tuple(row['baseline_move']['second']))
        v=simulate_move(board,move)
        b=replace(b,move=move,trace=replace(b.trace,selected_candidate=_candidate_trace(v,board=board)))
    witness=runtime_witness(s,c)
    profile=FrozenJSON.of(dict(MODEL,account_sha256=witness.plain()['account_username_sha256'],
        player_stats=[getattr(s.player,k) for k in ('max_hp','max_mana','max_power','attack')]))
    from pokiguard_v2.reasoning_root_policy import POLICY
    from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
    a=OperationalPilotAuthority('demon_aegis_farm',canonical_json(jsonable(c)),
        FrozenJSON.of(dict(account_binding=witness.plain()['account_username_sha256'],boss='1436',
            loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77')),witness,
        FrozenJSON.of(dict(version='5b2.scoped_inputs.v1')),'1'*64,'2'*64,'3'*64,'4'*64,'5'*64,'6'*64,
        FrozenJSON.of(dict(controller_tail_ms=206,final_input_ms=3010,selector_extra_ms=20,
            command_wait_ms=command_wait_ms(**PARAMS),host_guard_ms=250)),FrozenJSON.of(PARAMS),100,9,
        time.perf_counter_ns()+60_000_000_000,root_read_policy=FrozenJSON.of(POLICY),
        component_guard_policy=GUARD,demon_profile=profile)
    now=time.perf_counter_ns()
    snap=bind_snapshot(snapshot_from_state(s,c,b,a,'SYNTHETIC_D3',1,now,now),a)
    return s,c,b,a,snap


def completed_fixture(turn=9, **kw):
    s,c,b,a,snap=fixture(turn,**kw)
    now=time.perf_counter_ns();job=make_job(snap,deadline=now+2_000_000_000,generation=1)
    wire=dict(schema=JOB_SCHEMA,snapshot=snap.to_dict(),binding=vars(job.binding),job_id=job.job_id,
        generation=job.generation,refinement=False,budget_ns=2_000_000_000)
    raw=_reply_for(wire,threading.Event())
    cap=Capability(a.profile,digest(a.model.plain()),a.scope.text,a.reserve_ms,
        snap.recorded.plain()['observed_ns'],13000,context=a.context,pilot_authority=a)
    kwargs=dict(job=job,raw_reply=canonical_json(raw).encode(),state=s,config=c,capability=cap,
        completed_ns=time.perf_counter_ns())
    offer=CompletedProposal.prepare(**kwargs)
    return s,c,b,a,snap,raw,kwargs,offer


class DemonMinimumTests(unittest.TestCase):
    def test_observed_turn9_turn11_turn13_each_override_setup(self):
        for turn in (9,11,13):
            with self.subTest(turn=turn):
                s,c,b,a,snap=fixture(turn,baseline=True)
                result=plan(snap)
                self.assertIsNotNone(result.proposal,result.to_dict())
                chosen=next(v for v in result.scores if v.action==result.proposal)
                self.assertEqual(chosen.details.plain()['physical_swords'],3)
                self.assertGreaterEqual(chosen.details.plain()['effective_swords'],3)
                self.assertNotEqual(result.proposal,snap.baseline)
                self.assertEqual(c.pet_skill_fire_value,4)

    def test_effective4_is_independent_of_rage(self):
        for turn in (9,11):
            result=plan(fixture(turn,rage=0,baseline=True)[-1])
            self.assertIsNotNone(result.proposal,result.to_dict())
            chosen=next(c for c in result.scores if c.action==result.proposal)
            self.assertEqual(chosen.details.plain()['certificate']['ids'],['OPERATOR_EFFECTIVE4_PHYSICAL_FLOOR2'])

    def test_preexisting_rage100_without_multiplier_and_99_control(self):
        cells=[[list(x) for x in line] for line in native_row(13)['board']]
        for line in cells:
            for cell in line:cell[1]=1
        yes=plan(fixture(13,board=cells,rage=100,baseline=True)[-1])
        no=plan(fixture(13,board=cells,rage=99,baseline=True)[-1])
        self.assertIsNotNone(yes.proposal);self.assertIsNone(no.proposal)

    def test_joint_only_does_not_invent_gain_before_burst(self):
        result=plan(fixture(5,baseline=True)[-1])
        self.assertIsNone(result.proposal)
        self.assertTrue(all(not c.details.plain()['certificate']['ids'] for c in result.scores))

    def test_turn7_rage135_but_only_two_swords_is_not_current_certificate(self):
        self.assertIsNone(plan(fixture(7,baseline=True)[-1]).proposal)

    def test_one_sword_x7_is_not_enough_and_two_x2_are_distinct(self):
        from tools.evaluate_reasoning_planner import demon_board,TARGET
        for count,multiplier,expected in ((1,7,False),(2,2,True),(2,1,False),(3,1,False)):
            result=plan(fixture(board=demon_board(swords=count,multiplier=multiplier,rage_cells=0),
                rage=0,baseline=None)[-1])
            self.assertEqual(result.proposal is not None,expected,(count,multiplier,result.to_dict()))

    def test_x2_outside_sweep_no_credit(self):
        from tools.evaluate_reasoning_planner import demon_board
        cells=[[list(x) for x in line] for line in demon_board(swords=3,rage_cells=0)]
        cells[0][7]=['sword',7]
        self.assertIsNone(plan(fixture(board=cells,rage=0)[-1]).proposal)

    def test_low_hp_pressure_may_retain_basic_and_never_claims_safe(self):
        result=plan(fixture(11,hp=1,baseline=True)[-1])
        self.assertIsNone(result.proposal)

    def test_scope_or_model_tampering_retains_or_rejects(self):
        snap=fixture()[-1];record=snap.recorded.plain();record['d3_demon']['scope']['boss']='OTHER'
        self.assertIsNone(plan(replace(snap,recorded=FrozenJSON.of(record))).proposal)
        s,c,b,a,snap=fixture()
        self.assertFalse(a.matches(replace(s,player=replace(s.player,attack=s.player.attack+1)),c))
        record=snap.recorded.plain();record['d3_demon']['profile']['physical_floor']=1
        self.assertIsNone(plan(replace(snap,recorded=FrozenJSON.of(record))).proposal)

    @historical_test_view()
    def test_actual_basic_and_core_source_are_unchanged(self):
        # This is the historical D3 assertion, on its audited source view.
        # Current b10 runtime preservation is independently checked by b10 tests.
        old=json.loads((ROOT/'docs/phase5/artifacts/5d3_demon_reasoning_20261018/before_source.json').read_text())['files']
        for name in ('src/pokiguard_v2/basic_policy.py','src/pokiguard_v2/demon_aegis.py',
                'src/pokiguard_v2/board_simulator.py','tools/basic_auto_bot.py','tools/farm_run.py',
                'src/pokiguard_v2/win32_input.py'):
            self.assertEqual(hashlib.sha256(before_game_update_path(ROOT,name).read_bytes()).hexdigest(),old[name],name)

    def test_completed_worker_reply_is_bound_at_all_checkpoints(self):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(baseline=True)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(selected.receipt,offer);self.assertNotEqual(selected.decision.move,b.move)
        for final in (False,True):
            self.assertIsNone(revalidate_safely(adapter,offer,s,b,c,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=a.context,final=final,final_remaining_seconds=13))
        altered=replace(s,player=replace(s.player,power=99))
        self.assertIsNotNone(revalidate_safely(adapter,offer,altered,b,c,now_ns=time.perf_counter_ns(),
            input_allowed=True,context=a.context))
        raw['summary']['candidates'][0]['utility']['low']+=1
        with self.assertRaises(ValueError):CompletedProposal.prepare(**(kwargs|dict(raw_reply=canonical_json(raw).encode())))

    def test_deadline_stop_sink_and_missing_result_keep_original_incumbent(self):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(baseline=True)
        for reason in ('missing','expired','stop','sink'):
            sink=MemorySink();adapter=GuardedSelectionAdapter(None if reason=='missing' else offer,
                diagnostics=sink.buffer,enabled=True,pilot_authority=a)
            if reason=='stop':adapter.stop()
            if reason=='sink':sink.buffer.disable('SYNTHETIC')
            now=offer.job.deadline_ns if reason=='expired' else time.perf_counter_ns()
            self.assertIs(select_safely(adapter,s,b,c,now_ns=now,input_allowed=True,context=a.context).decision,b)

    def test_agreement_is_completed_retention_not_forced_override(self):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(15)
        self.assertIsNone(offer.reply.proposal)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.decision,b);self.assertIs(result.receipt,offer)
        self.assertEqual(result.reason,'VALID_COMPLETED_R1_RETENTION')

    def test_existing_native_guard_can_veto_without_stopping_basic(self):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(baseline=True)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.native_policy_guard=lambda proposed:True
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.decision,b);self.assertIsNone(result.receipt)
        self.assertEqual(result.reason,'D3_NATIVE_POLICY_GUARD_RETAIN_BASIC')

    def test_capability_cannot_reset_original_observation_budget(self):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(baseline=True)
        for cap in (replace(kwargs['capability'],observed_ns=kwargs['capability'].observed_ns+1),
                replace(kwargs['capability'],remaining_ms=14000)):
            with self.assertRaisesRegex(ValueError,'original observation'):
                CompletedProposal.prepare(**(kwargs|dict(capability=cap)))

    def test_real_isolated_worker_roundtrip_on_fake_state(self):
        s,c,b,a,snap=fixture(9,baseline=True);sink=MemorySink()
        bridge=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=True,decision_budget=True)
        try:
            now=time.perf_counter_ns();self.assertTrue(bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context))
            self.assertEqual(bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False),'COMPLETED')
            self.assertIsNotNone(bridge.completed)
            self.assertIsNotNone(bridge.completed.reply.proposal)
        finally:self.assertTrue(bridge.close())

    def test_real_controller_keeps_improved_basic_and_existing_input_ack_order(self):
        from tests.reasoning_controller_fixture import controller_trace
        from pokiguard_v2.reasoning_calibration import decode_config
        s,c,b,a,snap=fixture(9,baseline=True)
        cfg=decode_config(dict(json.loads((ART/'request.json').read_text())['config'],demon_target_gem='shield'))
        bridges=[]
        def factory(state,config):
            w=runtime_witness(state,config);p=a.demon_profile.plain();p['account_sha256']=w.plain()['account_username_sha256']
            scope=a.scope.plain();scope['account_binding']=p['account_sha256']
            authority=replace(a,policy_json=canonical_json(jsonable(config)),witness=w,
                scope=FrozenJSON.of(scope),demon_profile=FrozenJSON.of(p))
            bridge=PilotSelectionBridge(authority=authority,diagnostics=MemorySink(),
                verified_build_sha256=authority.game_build_sha256,enabled=True,warm_worker=True,decision_budget=True)
            bridges.append(bridge);return bridge
        with tempfile.TemporaryDirectory(dir=ROOT) as tmp:
            kw=dict(initial_combat=s,profile='demon_aegis_farm',target_pid=123,real_processing_clock=True,
                timer_source='MatchService.server_tick',gameplay_config=cfg)
            ordinary=controller_trace(Path(tmp)/'basic.jsonl',**kw)
            try:reasoned=controller_trace(Path(tmp)/'reasoning.jsonl',selection_factory=factory,**kw)
            finally:
                for bridge in bridges:self.assertTrue(bridge.close())
        for result in (ordinary,reasoned):
            summary=next(r for r in result[2] if r['event']=='auto_controller_summary')
            self.assertEqual(summary['counters']['swap_sent'],1)
            self.assertEqual(summary['counters']['swap_acknowledged'],1)
            self.assertTrue(all(v==0 for v in summary['safetyTelemetry'].values()))
        filtered=lambda calls:[x for x in calls if x!='clock.sleep']
        self.assertEqual(filtered(ordinary[1]),filtered(reasoned[1]))
        old=next(r for r in ordinary[2] if r['event']=='action_sent')['identity']['target']
        new=next(r for r in reasoned[2] if r['event']=='action_sent')['identity']['target']
        self.assertEqual(old,new)


class DemonNativeReviewTests(unittest.TestCase):
    def setUp(self):
        from tests.game_update_fixture import historical_config_shape
        self.enterContext(historical_config_shape())
        from tools.prepare_d3_reasoning import copy_native
        self.temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(self.temp.cleanup)
        self.directory=Path(self.temp.name);self.cal=copy_native(self.directory)

    def alter(self,ref,fn,lines=False):
        path=self.directory/ref['path']
        value=([json.loads(x) for x in path.read_text().splitlines()] if lines else json.loads(path.read_text()))
        fn(value);path.write_text('\n'.join(json.dumps(x) for x in value)+'\n' if lines else json.dumps(value),encoding='utf-8')
        ref['sha256']=hashlib.sha256(path.read_bytes()).hexdigest()

    def test_all_native_controls_revalidate_with_narrow_terminal_exclusions(self):
        from pokiguard_v2.reasoning_demon_native import verify_native
        result=verify_native(self.directory,self.cal)
        self.assertEqual((result['ack_samples'],result['terminal_excluded'],result['total_sent']),(9,3,12))
        self.assertEqual(result['H_ms'],205.4147);self.assertEqual(result['I_ms'],3009.7115)
        self.assertEqual(result['player_stats'],[109491,2771,250,1819])

    def test_watermark_loss_rejected_after_rehash(self):
        from pokiguard_v2.reasoning_demon_native import verify_native
        self.alter(self.cal['watermarks'],lambda v:v.update(collector_dropped=1))
        with self.assertRaises(ValueError):verify_native(self.directory,self.cal)

    def test_missing_ack_cannot_use_terminal_exception(self):
        from pokiguard_v2.reasoning_demon_native import verify_native
        def mutate(rows):
            r=next(x for x in rows if x['event']=='action_result' and x.get('result')=='SWAP_ACKNOWLEDGED')
            r['result']='UNKNOWN'
        self.alter(self.cal['combats'][0],mutate,True)
        with self.assertRaises(ValueError):verify_native(self.directory,self.cal)

    def test_terminal_hp_must_prove_actual_ending(self):
        from pokiguard_v2.reasoning_demon_native import verify_native
        def mutate(rows):
            next(x for x in rows if x['event']=='auto_controller_summary')['terminalCombatSnapshot']['boss_hp']=1
        self.alter(self.cal['combats'][0],mutate,True)
        with self.assertRaises(ValueError):verify_native(self.directory,self.cal)

    def test_clock_and_native_identity_rejected_after_rehash(self):
        from pokiguard_v2.reasoning_demon_native import verify_native
        self.alter(self.cal['records'],lambda r:r[0]['payload'].update(clock='OTHER_CLOCK'),True)
        with self.assertRaises(ValueError):verify_native(self.directory,self.cal)

    def test_drifted_cohort_or_attempt_cap_rejected(self):
        from pokiguard_v2.reasoning_demon_native import check_config
        from pokiguard_v2.reasoning_calibration import decode_config
        c=decode_config(dict(json.loads((ART/'request.json').read_text())['config'],demon_target_gem='shield'));check_config(c)
        for updates in (dict(boss_id='1289'),dict(pet_skill_fire_value=3),dict(max_match_attempts=4),
                dict(target_completed_matches=2)):
            with self.assertRaises(ValueError):check_config(replace(c,**updates))

    def test_twenty_requires_its_own_protocol_and_exact_config(self):
        from pokiguard_v2.reasoning_demon_native import check_config, MULTIPLIER20_PROTOCOL
        from pokiguard_v2.reasoning_calibration import decode_config
        c=decode_config(dict(json.loads((ART/'request.json').read_text())['config'],demon_target_gem='shield'))
        twenty=replace(c,target_completed_matches=20,max_match_attempts=20)
        check_config(c)
        check_config(twenty,protocol=MULTIPLIER20_PROTOCOL)
        with self.assertRaises(ValueError):check_config(twenty)
        with self.assertRaises(ValueError):check_config(c,protocol=MULTIPLIER20_PROTOCOL)
        for count in (1,2,6,12,19,21):
            with self.subTest(count=count),self.assertRaises(ValueError):
                check_config(replace(twenty,target_completed_matches=count,max_match_attempts=count),
                    protocol=MULTIPLIER20_PROTOCOL)
        with self.assertRaises(ValueError):check_config(replace(twenty,boss_id='1289'),protocol=MULTIPLIER20_PROTOCOL)

    def test_twenty_extension_pins_closed_nine_and_direct_authorization(self):
        from pokiguard_v2.reasoning_demon_native import verify_multiplier20_extension, PREVIOUS9_LEDGER_SHA
        import copy
        def write(name,value):
            path=self.directory/name;path.write_text(canonical_json(value),encoding='utf-8')
            return dict(path=name,sha256=hashlib.sha256(path.read_bytes()).hexdigest())
        old=ROOT/'docs/phase5/artifacts/5d3_multiplier_targeted_live_20261018_031504/cumulative_ledger.json'
        (self.directory/'previous.json').write_bytes(old.read_bytes())
        extension=dict(schema='5d3.multiplier20.extension.v1',accepted=True,
            scope='USER_REQUESTED_D3_MULTIPLIER20',operator_authorization='SYNTHETIC_TEST_ONLY_NOT_LIVE',
            previous_cumulative=dict(path='previous.json',sha256=PREVIOUS9_LEDGER_SHA),
            previous_attempts_consumed=9,attempt_cap=20,maximum_cumulative_attempts=29,
            failed_entry_abort_included=True,no_automatic_extension=True,source_sha256='1'*64)
        data=dict(batch_extension=write('extension.json',extension),runtime_sha256='1'*64,total_attempt_cap=20)
        activation=dict(batch_extension_sha256=data['batch_extension']['sha256'],total_attempt_cap=20,
            manual_start_only=True,operator_authorization='SYNTHETIC_TEST_ONLY_NOT_LIVE')
        self.assertEqual(verify_multiplier20_extension(self.directory,data,activation),extension)
        for change in (dict(attempt_cap=21),dict(previous_attempts_consumed=8),dict(accepted=False),
                dict(maximum_cumulative_attempts=30),dict(no_automatic_extension=False),
                dict(failed_entry_abort_included=False),dict(operator_authorization=''),dict(source_sha256='2'*64)):
            modified=copy.deepcopy(extension);modified.update(change)
            changed=dict(data,batch_extension=write('modified.json',modified))
            approved=dict(activation,batch_extension_sha256=changed['batch_extension']['sha256'])
            with self.subTest(change=change),self.assertRaises(ValueError):
                verify_multiplier20_extension(self.directory,changed,approved)
        with self.assertRaises(ValueError):verify_multiplier20_extension(self.directory,data,
            dict(activation,operator_authorization=''))

    def test_non_demon_and_legacy_protocol_cannot_expand_generic_cap(self):
        from tests.test_reasoning_operational import OperationalLoaderTests
        from pokiguard_v2.reasoning_demon import PROTOCOL
        helper=OperationalLoaderTests()
        for protocol in (None,PROTOCOL,'D1_SIMPLE_CAREFUL_CURRENT_NATIVE_V1','D2_HT7_FULL_ACTION_CURRENT_NATIVE_V1'):
            with tempfile.TemporaryDirectory(dir=ROOT) as name:
                data,_=helper.package(Path(name));data['total_attempt_cap']=20
                if protocol:data['pilot_protocol']=protocol
                with self.subTest(protocol=protocol),self.assertRaisesRegex(ValueError,'bounded run required'):
                    helper.load(Path(name),data)

    def test_twenty_source_change_is_setup_only_and_native_flow_exact(self):
        import ast
        before=ROOT/'docs/phase5/artifacts/5d3_multiplier20_20261018/before_source'
        changes={
            'src/pokiguard_v2/reasoning_operational.py':{'load_operational_authority'},
            'src/pokiguard_v2/reasoning_operational_launch.py':{'OperationalPilotLaunch.__init__'},
        }
        def functions(path):
            tree=ast.parse(path.read_text(encoding='utf-8'))
            values={n.name:ast.dump(n,include_attributes=False) for n in tree.body
                if isinstance(n,(ast.FunctionDef,ast.AsyncFunctionDef))}
            for node in tree.body:
                if isinstance(node,ast.ClassDef):
                    for method in node.body:
                        if isinstance(method,(ast.FunctionDef,ast.AsyncFunctionDef)):
                            values[node.name+'.'+method.name]=ast.dump(method,include_attributes=False)
            return values
        for path,allowed in changes.items():
            # D4 is a later reasoning successor. Check D3 against its exact
            # saved after-source, while D4 separately checks the current core.
            frozen=ROOT/'docs/phase5/artifacts/5d4_mega_acceptance_20261018/before_source'
            old=functions(before/path);new=functions(frozen/path)
            self.assertEqual(set(old),set(new))
            self.assertEqual({key for key in old if old[key]!=new[key]},allowed)
        manifest=json.loads((before.parent/'before_source.json').read_text(encoding='utf-8'))
        allowed=set(changes)|{'src/pokiguard_v2/reasoning_demon_native.py',
            'tools/prepare_d3_reasoning.py','tests/test_reasoning_demon.py','tests/reasoning_controller_fixture.py'}
        historical=ROOT/'docs/phase5/artifacts/5d4_mega_acceptance_20261018'
        predecessor=json.loads((historical/'before_source.json').read_text(encoding='utf-8'))
        self.assertEqual(predecessor['fingerprint'],'00b19780f78fae906b84df47d4d67af6f085abc0df834822f4c9c6ce15a09702')
        for name,sha in manifest['files'].items():
            path=historical/'before_source'/name
            self.assertEqual(hashlib.sha256(path.read_bytes()).hexdigest(),predecessor['files'][name],name)
            if name not in allowed:self.assertEqual(hashlib.sha256(path.read_bytes()).hexdigest(),sha,name)


if __name__=='__main__':unittest.main()
