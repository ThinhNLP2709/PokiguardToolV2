"""Derived recorded boards and explicitly synthetic capabilities; no game IO."""
from dataclasses import replace
import hashlib,json,threading,time,unittest
from pathlib import Path
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine,PolicyAction,SkillRushMatchContext
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.gameplay_profile import MainPetType,EvolutionTarget
from pokiguard_v2.reasoning_mega import VERSION,profile_for,choices,seal_geometry,reply_view,current_source_binding
from pokiguard_v2.reasoning_full_actions import (context_packet,bind_snapshot,publish_context_safely,
    plan_full_actions,current_action_allowed,apply_action)
from pokiguard_v2.reasoning_operational import OperationalPilotAuthority,command_wait_ms
from pokiguard_v2.reasoning_pilot import snapshot_from_state,PilotSelectionBridge
from pokiguard_v2.reasoning_pilot_contract import runtime_witness
from pokiguard_v2.reasoning_snapshot import FrozenJSON,canonical_json,digest,Action
from pokiguard_v2.reasoning_planner import plan
from pokiguard_v2.reasoning_runner import make_job,_reply_for,JOB_SCHEMA
from pokiguard_v2.reasoning_selection import Capability,CompletedProposal,GuardedSelectionAdapter,select_safely,revalidate_safely
from pokiguard_v2.state import BoardState,CellState,GemType,ParticipantState,CombatSessionKey
from tests.test_basic_policy import combat_state
from tests.test_mega_icarus_policy import mega_policy
from tests.test_phase3c1_pet_skill_policy import capability
from tests.test_reasoning_action_candidates import confirmed_reset_view
from tests.test_reasoning_pilot import MemorySink

ROOT=Path(__file__).resolve().parents[1]
NATIVE=ROOT/'docs/phase5/artifacts/5d4_input_repeat1_live_20261018_143456'
PARAMS=dict(cursor_settle_seconds=.06,mouse_button_hold_seconds=.075)


def native_rows():
    p=ROOT/'logs/farm_runs/b5e66cb14607410989c8057290a63cc8/matches/attempt_001/combat.jsonl'
    return [r for r in (json.loads(l) for l in p.read_text('utf-8').splitlines()) if r['event']=='policy_decision']


def fixture(turn=11,*,hp_ratio=None,mana=None,rage=None,threshold=6,pet_unknown=True,force_baseline=None,board_override=None,row_override=None):
    row=row_override if row_override is not None else next(r for r in native_rows() if r['turn']==turn and r['selectedAction']!='evolve')
    board=BoardState(tuple(tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(line))
        for r,line in enumerate(row['boardSnapshot'])))
    if board_override is not None:board=board_override
    s=combat_state(board=board);player=ParticipantState(**row['player']);boss=ParticipantState(**row['boss'])
    if hp_ratio is not None:player=replace(player,hp=max(1,int(player.max_hp*hp_ratio)))
    if mana is not None:player=replace(player,mana=mana)
    if rage is not None:player=replace(player,power=rage)
    session=CombatSessionKey(1,0x22000000000,'SYNTHETIC_D4_MATCH')
    s=replace(s,player=player,opponents=(boss,),participants=(player,boss),cards=(),
        fusion=replace(s.fusion,used=True,available=False,selected_user_pet_id=258990,selected_pet_id=2257),
        battle=replace(s.battle,session_key=session,match_id=session.match_id,board_instance=session.board_instance,
            local_username='SYNTHETIC_D4_REPLAY',current_turn_player='SYNTHETIC_D4_REPLAY',
            turn_number=turn,srv_seq=row['srvSeq'],board_hash=row['boardHash'],
            turn_time_remaining_seconds=13,turn_timer_source='MatchService.server_tick'))
    s,_=confirmed_reset_view(s)
    engine=mega_policy(main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.MEGA,threshold=threshold)
    c=replace(engine.config,minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1)
    cap=replace(capability(element='MEGA_ICARUS',card_id=22,mana_cost=200,rage_cost=150),
        session_key=s.battle.session_key,pet_id=None if pet_unknown else 2524,
        source_pet_skill_card_id=None,need_perfection=False)
    h=SkillRushMatchContext(s.battle.session_key,0,None)
    b=BasicPolicyEngine(c).decide(s,pet_skill_capability=cap,skill_rush_match_context=h)
    if force_baseline is not None:
        action=force_baseline
        b=replace(b,action=PolicyAction(action.family),move=action.move,
            skill_card_id=22 if action.family=='pet_skill' else None,
            skill_session_key=s.battle.session_key if action.family=='pet_skill' else None)
    w=runtime_witness(s,c)
    from pokiguard_v2.reasoning_root_policy import POLICY
    from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
    a=OperationalPilotAuthority(c.play_style.value,canonical_json(jsonable(c)),
        FrozenJSON.of(dict(account_binding='SYNTHETIC',boss='SYNTHETIC',loadout='SYNTHETIC')),
        w,FrozenJSON.of(dict(version='5b2.scoped_inputs.v1')),'1'*64,'2'*64,'3'*64,'4'*64,'5'*64,'6'*64,
        FrozenJSON.of(dict(controller_tail_ms=300,final_input_ms=3000,selector_extra_ms=30,
            command_wait_ms=command_wait_ms(**PARAMS),host_guard_ms=250)),FrozenJSON.of(PARAMS),100,15,
        time.perf_counter_ns()+60_000_000_000,action_profile=FrozenJSON.of(profile_for(w.plain())),
        root_read_policy=FrozenJSON.of(POLICY),component_guard_policy=GUARD)
    packet=context_packet(s,c,b,cap,h,True);now=time.perf_counter_ns()
    snap=bind_snapshot(snapshot_from_state(s,c,b,a,'SYNTHETIC_D4',1,now,now),packet,a)
    return s,c,b,cap,h,a,packet,snap


def completed_fixture(**kwargs):
    data=fixture(**kwargs);s,c,b,cap,h,a,packet,snap=data;now=time.perf_counter_ns()
    job=make_job(snap,deadline=now+2_000_000_000,generation=1)
    wire=dict(schema=JOB_SCHEMA,snapshot=snap.to_dict(),binding=vars(job.binding),job_id=job.job_id,
        generation=job.generation,refinement=False,budget_ns=2_000_000_000)
    raw=_reply_for(wire,threading.Event())
    context=Capability(a.profile,digest(a.model.plain()),a.scope.text,a.reserve_ms,
        snap.recorded.plain()['observed_ns'],13000,context=a.context,pilot_authority=a,action_context=packet)
    args=dict(job=job,raw_reply=canonical_json(raw).encode(),state=s,config=c,capability=context,
        completed_ns=time.perf_counter_ns())
    offer=CompletedProposal.prepare(**args)
    return data,raw,args,offer


def all_risk_board():
    # Explicit synthetic stable board, seed0/no initial horizontal or vertical
    # triple. All23 real legal SWAPs leave a known Sword reply; no fake scores.
    raw=[['health','health','sword','mana','drain','shield','health','mana'],
        ['shield','rage','sword','drain','sword','mana','sword','sword'],
        ['mana','drain','drain','sword','mana','sword','sword','health'],
        ['shield','drain','sword','rage','health','rage','drain','sword'],
        ['drain','shield','shield','mana','sword','drain','sword','sword'],
        ['health','sword','shield','rage','sword','rage','sword','rage'],
        ['sword','sword','rage','drain','shield','sword','mana','rage'],
        ['drain','shield','sword','mana','drain','mana','sword','health']]
    return BoardState(tuple(tuple(CellState(r,c,GemType(g),1) for c,g in enumerate(row)) for r,row in enumerate(raw)))


def native_pass_policy_row():
    # Board/participants from the sealed native failed reply. Session/current
    # capability/history/PASS proof stay explicitly synthetic in fixture().
    p=ROOT/'logs/farm_runs/93d2ed459b5e4ec596e8cfc33b2c7b7a/matches/attempt_001/combat.jsonl'
    return next(r for r in (json.loads(l) for l in p.read_text('utf-8').splitlines())
        if r.get('event')=='policy_decision' and r.get('turn')==49)


class MegaTests(unittest.TestCase):
    def test_native_derived_pass_is_validated_through_real_worker_reply(self):
        data,raw,args,offer=completed_fixture(turn=49,row_override=native_pass_policy_row())
        self.assertEqual(raw['proposal']['family'],'pass')
        self.assertEqual(offer.reply.proposal.family,'pass')
        s,c,b,cap,h,a,packet,snap=data
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        chosen=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(chosen.receipt,offer);self.assertIs(chosen.decision.action,PolicyAction.PASS)
        adapter.action_context=context_packet(s,c,b,cap,h,True,False)
        rejected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(rejected.decision,b);self.assertIsNone(rejected.receipt)

    def test_actual_isolated_worker_can_return_mega_pass_and_close(self):
        s,c,b,cap,h,a,packet,snap=fixture(turn=49,row_override=native_pass_policy_row())
        bridge=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=True,decision_budget=True)
        try:
            now=time.perf_counter_ns();self.assertTrue(bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context))
            publish_context_safely(bridge,s,c,b,cap,h,True)
            self.assertEqual(bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False),'COMPLETED')
            self.assertEqual(bridge.completed.reply.proposal.family,'pass')
        finally:self.assertTrue(bridge.close())

    def test_pass_wire_rejects_unknown_context_and_foreign_profile(self):
        from pokiguard_v2.reasoning_runner import _validate_reply
        data,raw,args,offer=completed_fixture(turn=49,row_override=native_pass_policy_row())
        *_,snap=data
        for case in ('unknown_version','foreign_profile','absent_context'):
            recorded=snap.recorded.plain();intent=snap.intent
            if case=='unknown_version':recorded['d2_actions']['version']='UNVERIFIED_MEGA'
            if case=='foreign_profile':intent=replace(intent,profile='simple')
            if case=='absent_context':recorded.pop('d2_actions')
            changed=replace(snap,intent=intent,recorded=FrozenJSON.of(recorded))
            job=make_job(changed,deadline=time.perf_counter_ns()+2_000_000_000,generation=1)
            wire=dict(raw,job_id=job.job_id,generation=job.generation,binding=vars(job.binding),summary={})
            with self.subTest(case=case),self.assertRaisesRegex(ValueError,'unsupported proposal family'):
                _validate_reply(canonical_json(wire).encode(),job)

    def test_same_board_setting_healthy_retains_setup_but_pressure_fires_before30percent(self):
        healthy=fixture(turn=23,hp_ratio=1,mana=300,rage=200)
        pressured=fixture(turn=23,hp_ratio=.6,mana=300,rage=200)
        self.assertEqual(healthy[0].board,pressured[0].board)
        self.assertEqual(healthy[1],pressured[1])
        self.assertEqual(healthy[2].action,pressured[2].action)
        self.assertIsNone(plan(healthy[-1]).proposal)
        result=plan(pressured[-1]);self.assertEqual(result.proposal.family,'pet_skill')
        facts=next(x['facts'] for x in pressured[-1].recorded.plain()['d2_actions']['choices'] if x['action']['family']=='pet_skill')
        self.assertLess(facts['seal_effective'],6)
        self.assertGreater(pressured[0].player.hp/pressured[0].player.max_hp,.3)
        chosen=next(x for x in result.scores if x.action==result.proposal)
        self.assertEqual(chosen.details.plain()['actual_heal_points'],'UNKNOWN')

    def test_ready_skill_can_wait_when_healthy_and_is_retained_when_pressured(self):
        healthy=fixture(turn=13,hp_ratio=1,mana=300,rage=200)
        pressured=fixture(turn=13,hp_ratio=.6,mana=300,rage=200)
        self.assertEqual(healthy[2].action,PolicyAction.PET_SKILL)
        self.assertEqual(plan(healthy[-1]).proposal.family,'swap')
        self.assertIsNone(plan(pressured[-1]).proposal)

    def test_native_board_geometry_and_all_families_are_own_mega(self):
        s,c,b,cap,h,a,packet,snap=fixture()
        ctx=snap.recorded.plain()['d2_actions'];self.assertEqual(ctx['version'],VERSION)
        self.assertEqual(len(ctx['seal_geometry']['original_cells']),30)
        self.assertNotIn('perfect_geometry',ctx)
        self.assertFalse(ctx['conditional_perfect'])
        self.assertEqual(sum(x['action']['family']=='swap' for x in ctx['choices']),len(evaluate_all_moves(s.board)))
        self.assertTrue(any(x['eligible'] and x['action']['family']=='pet_skill' for x in ctx['choices']))
        result=plan(snap);self.assertNotEqual(result.reason,'INVALID_OR_UNSUPPORTED_INPUT',result.diagnostics.plain())
        self.assertTrue(all(x.details.plain()['actual_heal_points']=='UNKNOWN' for x in result.scores))

    def test_optional_pet_metadata_never_discards_conflicting_identity(self):
        *_,cap,h,a,packet,snap=fixture()
        self.assertIsNotNone(current_source_binding(cap))
        for bad in (replace(cap,pet_id=999),replace(cap,source_pet_skill_card_id=7),
                replace(cap,card_id=7),replace(cap,live_button_address=None),replace(cap,ownership_current=False)):
            self.assertIsNone(current_source_binding(bad))

    def test_completed_worker_result_recomputes_own_model(self):
        data,raw,args,offer=completed_fixture();s,c,b,cap,h,a,packet,snap=data
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.receipt,offer,result.reason)
        self.assertIsNone(revalidate_safely(adapter,offer,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context))
        forged=dict(raw,reason='FORGED')
        with self.assertRaises(ValueError):CompletedProposal.prepare(**dict(args,raw_reply=canonical_json(forged).encode()))

    def test_actual_cost_cooldown_and_owner_are_hard_gates_not_settings(self):
        s,c,b,cap,h,a,packet,snap=fixture(turn=23,hp_ratio=.4,mana=300,rage=200)
        for changed,card in [(replace(s,player=replace(s.player,mana=199)),cap),
                (replace(s,player=replace(s.player,power=149)),cap),(s,replace(cap,cooldown_turns=1)),
                (s,replace(cap,effective_mana_cost=None)),(s,replace(cap,live_card_actionable=False)),
                (s,replace(cap,ownership_current=False))]:
            choice=next(v for v in choices(changed,c,b,card,h,True,True) if v.action.family=='pet_skill')
            self.assertFalse(choice.eligible,choice)
        closed=SkillRushMatchContext(s.battle.session_key,1,s.battle.turn_number)
        self.assertTrue(all(not x.eligible for x in choices(s,c,b,cap,closed,True,True)))
        self.assertFalse(current_action_allowed(Action('swap',evaluate_all_moves(s.board)[0].move),
            context_packet(s,c,b,cap,closed,True)))
        self.assertTrue(all(not x.eligible for x in choices(s,c,b,cap,h,False,True)))

    def test_seal_multiplier_scope_and_unknown_refill_are_separate(self):
        from pokiguard_v2.mega_icarus import MEGA_ICARUS_SEAL_CELLS
        s,c,b,cap,h,a,packet,snap=fixture()
        old=seal_geometry(s.board)
        outside=next((r,col) for r in range(8) for col in range(8) if (r,col) not in MEGA_ICARUS_SEAL_CELLS)
        changed=BoardState(tuple(tuple(replace(cell,gem=GemType.SWORD,multiplier=7) if (cell.row,cell.col)==outside else cell
            for cell in row) for row in s.board.cells))
        self.assertEqual(old['quantities']['sword'],seal_geometry(changed)['quantities']['sword'])
        sword=next((r,col) for r,col in MEGA_ICARUS_SEAL_CELLS if s.board.cells[r][col].gem is GemType.SWORD)
        changed=BoardState(tuple(tuple(replace(cell,multiplier=cell.multiplier+1) if (cell.row,cell.col)==sword else cell
            for cell in row) for row in s.board.cells))
        new=seal_geometry(changed)
        self.assertEqual(new['quantities']['sword']['physical'],old['quantities']['sword']['physical'])
        self.assertEqual(new['quantities']['sword']['effective'],old['quantities']['sword']['effective']+1)
        self.assertGreaterEqual(new['unknown_cells'],30)
        self.assertEqual(len(set(map(tuple,new['original_cells']))),30)

    def test_pass_requires_published_owner_and_reset_or_counter_proof(self):
        from pokiguard_v2.state import GameOwnedIdleStatus
        s,c,b,cap,h,a,packet,snap=fixture()
        self.assertTrue(next(x.eligible for x in choices(s,c,b,cap,h,True,True) if x.action.family=='pass'))
        for blocked,allowed in [(s,False),(replace(s,battle=replace(s.battle,consecutive_pass_reset_evidence=None)),True),
                (replace(s,battle=replace(s.battle,turn_number=1)),True),
                (replace(s,battle=replace(s.battle,consecutive_pass_status=GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION,
                    consecutive_passes=2,consecutive_pass_threshold=3)),True)]:
            self.assertFalse(next(x.eligible for x in choices(blocked,c,b,cap,h,True,allowed) if x.action.family=='pass'))

    def test_same_board_pass_permission_change_rejects_completed_result(self):
        data,raw,args,offer=completed_fixture();s,c,b,cap,h,a,packet,snap=data
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=context_packet(s,c,b,cap,h,True,False)
        selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(selected.decision,b);self.assertIsNone(selected.receipt)
        self.assertEqual(selected.reason,'D2_CAPABILITY_OR_HISTORY_CHANGED')

    def test_native_guard_rejects_proposal_without_replacing_the_incumbent_contract(self):
        data,raw,args,offer=completed_fixture(turn=23,hp_ratio=.6,mana=300,rage=200);s,c,b,cap,h,a,packet,snap=data
        self.assertIsNotNone(offer.reply.proposal)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet;adapter.native_policy_guard=lambda decision:True
        selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(selected.decision,b);self.assertIsNone(selected.receipt)
        self.assertEqual(selected.reason,'D4_NATIVE_POLICY_GUARD_RETAIN_BASIC')

    def test_deterministic_order_without_override_quota(self):
        s,c,b,cap,h,a,packet,snap=fixture(turn=23,hp_ratio=.6,mana=300,rage=200)
        original=plan(snap)
        ctx=snap.recorded.plain();ctx['d2_actions']['choices'].reverse()
        result=plan(replace(snap,recorded=FrozenJSON.of(ctx)))
        self.assertEqual(original.proposal,result.proposal)
        for score in result.scores:self.assertNotIn('win_probability',score.details.plain())

    def test_disabled_stopped_late_stale_or_failed_diagnostics_keep_exact_basic(self):
        data,raw,args,offer=completed_fixture(turn=23,hp_ratio=.6,mana=300,rage=200)
        s,c,b,cap,h,a,packet,snap=data
        self.assertIsNotNone(offer.reply.proposal)
        for case in ('disabled','stopped','late','stale','log_failure','not_completed','exception'):
            with self.subTest(case=case):
                sink=MemorySink()
                adapter=GuardedSelectionAdapter(offer,diagnostics=sink.buffer,enabled=True,pilot_authority=a)
                adapter.action_context=packet;current=s;now=offer.completed_ns+1
                if case=='disabled':adapter.enabled=False
                if case=='stopped':adapter.stopped=True
                if case=='late':now=offer.job.deadline_ns
                if case=='not_completed':now=offer.completed_ns-1
                if case=='stale':current=replace(s,battle=replace(s.battle,turn_number=s.battle.turn_number+1))
                if case=='log_failure':sink.buffer.disable('SYNTHETIC_DISK_FAILURE')
                if case=='exception':adapter.native_policy_guard=lambda decision:1/0
                selected=select_safely(adapter,current,b,c,now_ns=now,input_allowed=True,context=a.context)
                self.assertIs(selected.decision,b)
                self.assertIsNone(selected.receipt)
                self.assertEqual(selected.decision.trace,b.trace)

    def test_missing_hp_cannot_create_healing_or_survival_evidence(self):
        *_,snap=fixture(turn=23,hp_ratio=.6,mana=300,rage=200)
        observations=tuple((name,replace(value,value=FrozenJSON.of(None),availability='MISSING',support='UNKNOWN',reason='SYNTHETIC_UNAVAILABLE') if name=='self.max_hp' else value)
            for name,value in snap.observations)
        result=plan(replace(snap,observations=observations))
        self.assertIsNone(result.proposal)
        self.assertEqual(result.reason,'INVALID_OR_UNSUPPORTED_INPUT')

    def test_low_hp_all_swaps_risky_never_becomes_a_survival_certificate(self):
        board=all_risk_board();moves=evaluate_all_moves(board)
        self.assertEqual(len(moves),23);self.assertTrue(all(not v.sword_risk.safe for v in moves))
        for mana,rage in ((300,200),(199,149)):
            s,c,b,cap,h,a,packet,snap=fixture(turn=23,hp_ratio=.2,mana=mana,rage=rage,board_override=board)
            result=plan(snap)
            self.assertTrue(result.scores)
            self.assertTrue(all(x.details.plain()['actual_damage_survival']=='UNKNOWN' for x in result.scores))
            skill=next(x for x in snap.recorded.plain()['d2_actions']['choices'] if x['action']['family']=='pet_skill')
            self.assertEqual(skill['eligible'],mana>=200 and rage>=150)
            if result.proposal is not None:self.assertTrue(any(x.action==result.proposal for x in result.scores))

    def test_missing_boss_resources_stay_intervals_and_full_hp_gets_no_health_credit(self):
        *_,snap=fixture(turn=23,hp_ratio=1,mana=300,rage=200)
        observations=tuple((name,replace(value,value=FrozenJSON.of(None),availability='MISSING',support='UNKNOWN',reason='SYNTHETIC_UNAVAILABLE')
            if name in ('boss.rage','boss.max_rage','boss.mana','boss.max_mana') else value)
            for name,value in snap.observations)
        result=plan(replace(snap,observations=observations))
        self.assertNotEqual(result.reason,'INVALID_OR_UNSUPPORTED_INPUT')
        skill=next(x for x in result.scores if x.action.family=='pet_skill')
        lo,hi=skill.details.plain()['pressure_interval'];self.assertGreater(hi,lo)
        self.assertEqual(skill.details.plain()['post_skill_resource_balance'],'UNKNOWN_NOT_CREDITED')
        self.assertEqual(skill.details.plain()['actual_heal_points'],'UNKNOWN')


if __name__=='__main__':unittest.main()
