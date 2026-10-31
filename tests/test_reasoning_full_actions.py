"""D2 software only. All game state/capabilities/input surfaces are fakes."""
from dataclasses import replace
import json
from pathlib import Path
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import PolicyAction, SkillRushMatchContext
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_full_actions import (VERSION, SOURCE_BINDING, context_packet, context_hash,
    bind_snapshot, plan_full_actions, current_action_allowed, apply_action, publish_context_safely)
from pokiguard_v2.reasoning_operational import OperationalPilotAuthority, command_wait_ms
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge, snapshot_from_state
from pokiguard_v2.reasoning_pilot_contract import runtime_witness
from pokiguard_v2.reasoning_runner import make_job, _reply_for, _validate_reply, JOB_SCHEMA
from pokiguard_v2.reasoning_selection import Capability, CompletedProposal, select_safely, revalidate_safely
from pokiguard_v2.reasoning_snapshot import FrozenJSON, canonical_json, digest, Action
from pokiguard_v2.reasoning_d2_native import controller_boundary
from pokiguard_v2.state import GameOwnedIdleStatus
from tests.test_reasoning_pilot import MemorySink
from tests.test_reasoning_operational import PARAMS
from tests.test_phase3c1_pet_skill_policy import session_state, capability
from tests.test_phase3c3_skill_rush_policy import rush_policy, with_idle_status
from tests.test_reasoning_action_candidates import confirmed_reset_view

ROOT=Path(__file__).resolve().parents[1]


def full_fixture(mana=200, rage=200, threshold=7, *, native_source=False):
    s=session_state(mana=mana,rage=rage)
    s=replace(s,battle=replace(s.battle,local_username='D2_SYNTHETIC_ACCOUNT',
        turn_timer_source='MatchService.server_tick',turn_time_remaining_seconds=14),
        opponents=tuple(replace(b,max_mana=445,max_power=250,attack=325) for b in s.opponents))
    s,_=confirmed_reset_view(s)
    c=capability(card_id=7)
    if not native_source:
        c=replace(c,pet_id=2035,source_pet_skill_card_id=7)
    engine=rush_policy(threshold=threshold);config=engine.config
    base=engine.decide(s,pet_skill_capability=c)
    witness=runtime_witness(s,config)
    model=FrozenJSON.of(dict(version='5b2.scoped_inputs.v1'))
    profile=FrozenJSON.of(dict(version=VERSION,
        account_sha256=witness.plain()['account_username_sha256'],pet_id=2035,skill_card_id=7,
        condition='PERFECT_ONLY',resource_conversion=dict(mana=30,rage=20),source_binding=SOURCE_BINDING))
    from pokiguard_v2.reasoning_root_policy import POLICY
    from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
    a=OperationalPilotAuthority('skill_rush',canonical_json(jsonable(config)),
        FrozenJSON.of(dict(account_binding='SYNTHETIC',boss='SYNTHETIC',loadout='SYNTHETIC')),
        witness,model,'1'*64,'2'*64,'3'*64,'4'*64,'5'*64,'6'*64,
        FrozenJSON.of(dict(controller_tail_ms=300,final_input_ms=4700,selector_extra_ms=20,
            command_wait_ms=command_wait_ms(**PARAMS),host_guard_ms=250)),FrozenJSON.of(PARAMS),
        100,1,time.perf_counter_ns()+60_000_000_000,action_profile=profile,
        root_read_policy=FrozenJSON.of(POLICY),component_guard_policy=GUARD)
    history=SkillRushMatchContext(s.battle.session_key,0,None)
    packet=context_packet(s,config,base,c,history,True)
    now=time.perf_counter_ns()
    snap=bind_snapshot(snapshot_from_state(s,config,base,a,'TEST',1,now,now),packet,a)
    return s,config,base,c,history,a,packet,snap


def completed_fixture(*, native_source=False):
    s,config,base,c,h,a,packet,snap=full_fixture(native_source=native_source)
    now=time.perf_counter_ns();job=make_job(snap,deadline=now+2_000_000_000,generation=1)
    wire=dict(snapshot=snap.to_dict(),binding=vars(job.binding),job_id=job.job_id,
        generation=job.generation,refinement=False,budget_ns=2_000_000_000,schema=JOB_SCHEMA)
    raw=_reply_for(wire,threading.Event())
    cap=Capability('skill_rush',digest(a.model.plain()),a.scope.text,a.reserve_ms,
        snap.recorded.plain()['observed_ns'],14000,context=a.context,pilot_authority=a,action_context=packet)
    kwargs=dict(job=job,raw_reply=canonical_json(raw).encode(),state=s,config=config,
        capability=cap,completed_ns=time.perf_counter_ns())
    return (s,config,base,c,h,a,packet,snap),raw,kwargs


def native_guard_fixture():
    """Derived observed-board replay; never a new native capability capture."""
    import runpy
    replay=ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/reproduce.py'
    s,c,b,selected,guard=runpy.run_path(str(replay))['fixture']()
    cap=replace(capability(card_id=7),session_key=s.battle.session_key,live_card_actionable=False)
    h=SkillRushMatchContext(s.battle.session_key,0,None)
    *_,a,_,_=full_fixture(native_source=True)
    witness=runtime_witness(s,c)
    profile=a.action_profile.plain();profile['account_sha256']=witness.plain()['account_username_sha256']
    a=replace(a,policy_json=canonical_json(jsonable(c)),witness=witness,action_profile=FrozenJSON.of(profile))
    packet=context_packet(s,c,b,cap,h,True,pass_owner_allowed=False)
    now=time.perf_counter_ns()
    snap=bind_snapshot(snapshot_from_state(s,c,b,a,'DERIVED_NATIVE_GUARD_REPLAY',1,now,now),packet,a)
    job=make_job(snap,deadline=now+2_000_000_000,generation=1)
    raw=_reply_for(dict(snapshot=snap.to_dict(),binding=vars(job.binding),job_id=job.job_id,
        generation=job.generation,refinement=False,budget_ns=2_000_000_000,schema=JOB_SCHEMA),threading.Event())
    capability_context=Capability('skill_rush',digest(a.model.plain()),a.scope.text,a.reserve_ms,
        now,14000,context=a.context,pilot_authority=a,action_context=packet)
    offer=CompletedProposal.prepare(job=job,raw_reply=canonical_json(raw).encode(),state=s,config=c,
        capability=capability_context,completed_ns=time.perf_counter_ns())
    return s,c,b,selected,guard,a,packet,offer


class FullActionsTests(unittest.TestCase):
    def test_observed_no_safe_board_worker_proposal_falls_back_through_real_native_guard(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        s,c,b,selected,guard,a,packet,offer=native_guard_fixture()
        self.assertEqual(b.move.first,(2,4));self.assertEqual(b.move.second,(2,5))
        self.assertEqual(offer.reply.proposal.move,selected.move)
        self.assertFalse(guard(b));self.assertTrue(guard(selected))
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet;adapter.native_policy_guard=guard
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.decision,b);self.assertIsNone(result.receipt)
        self.assertEqual(result.reason,'D2_NATIVE_POLICY_GUARD_RETAIN_BASIC')
        self.assertFalse(guard(result.decision));self.assertFalse(adapter.disabled)
        self.assertEqual(adapter.counts[result.reason],1)

    def test_native_guard_compatibility_does_not_ban_all_risky_proposals(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        from tools.basic_auto_bot import _must_pause_for_no_safe_move
        s,c,b,selected,guard,a,packet,offer=native_guard_fixture()
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        adapter.native_policy_guard=lambda d:_must_pause_for_no_safe_move(d,
            legal_move_count=10,safe_move_count=1,first_local_turn=False)
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertEqual(result.decision.move,selected.move);self.assertIs(result.receipt,offer)
        self.assertEqual(result.reason,'VALID_COMPLETED_R1')

    def test_completed_swap_retention_preserves_native_risk_branch_and_receipt(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        s,c,b,selected,guard,a,packet,offer=native_guard_fixture()
        # Prevalidated retention injection tests the adapter contract, not
        # whether this observed board should receive a different model score.
        offer=replace(offer,reply=replace(offer.reply,proposal=None,reason='BASELINE_TOP_IN_TOTAL_ORDER'))
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet;adapter.native_policy_guard=guard
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.decision,b);self.assertIs(result.receipt,offer)
        self.assertFalse(guard(result.decision))
        self.assertEqual(result.reason,'VALID_COMPLETED_R1_RETENTION')

    def test_native_compatibility_exception_keeps_basic_and_disables_selector(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        s,c,b,selected,guard,a,packet,offer=native_guard_fixture()
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        def failed_guard(_):raise ValueError('synthetic pure guard failure')
        adapter.native_policy_guard=failed_guard
        result=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(result.decision,b);self.assertIsNone(result.receipt)
        self.assertTrue(adapter.disabled);self.assertEqual(result.reason,'SELECTOR_EXCEPTION')

    def test_native_no_safe_guard_itself_is_unchanged_after_remediation(self):
        import ast
        before=ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/before/tools/basic_auto_bot.py'
        def guard_ast(path):
            return ast.dump(next(x for x in ast.parse(path.read_text(encoding='utf-8-sig')).body
                if isinstance(x,ast.FunctionDef) and x.name=='_must_pause_for_no_safe_move'))
        self.assertEqual(guard_ast(before),guard_ast(ROOT/'tools/basic_auto_bot.py'))

    def test_existing_controller_capability_shape_compares_skill_without_inventing_pet_id(self):
        s,c,b,cap,h,a,packet,snap=full_fixture(native_source=True)
        self.assertIsNone(cap.pet_id)
        self.assertIsNone(cap.source_pet_skill_card_id)
        self.assertEqual(b.action,PolicyAction.PET_SKILL)
        choice=next(x for x in snap.recorded.plain()['d2_actions']['choices']
            if x['action']['family']=='pet_skill')
        self.assertTrue(choice['eligible']);self.assertTrue(choice['baseline_member'])
        self.assertEqual(choice['facts']['source_binding'],'CURRENT_OWNED_CARD_PET_ID_UNKNOWN')
        scope=snap.recorded.plain()['d2_actions']['perfect_geometry']['scope']
        self.assertIsNone(scope['pet_id'])
        self.assertEqual(scope['calibration_pet_id'],2035)
        result=plan_full_actions(snap)
        self.assertIsNone(result.proposal)
        self.assertTrue(any(x.action.family=='pet_skill' for x in result.scores))

    def test_real_controller_helper_has_no_source_pet_and_requires_no_extra_provider_call(self):
        from types import SimpleNamespace
        from tools.basic_auto_bot import _current_pet_skill_capability
        from pokiguard_v2.pet_skill_shadow import PetSkillCapabilityProvider
        s,c,b,cap,h,a,packet,snap=full_fixture()
        card=replace(s.cards[0],object_address=cap.live_card_address,data_address=cap.card_data_address,
            data_id=0,card_id=7,name='HT7',element_type='ATTACK_LEGEND_',condition_use=200,power=200,
            mana_cost=0,power_cost=0,interactable=True,cooldown_turns=0,
            interaction_authority='CARD_UI_BUTTON',button_address=cap.live_button_address)
        provider=SimpleNamespace(refresh_pet_skill_cards=lambda *args,**kwargs:(card,))
        actual=_current_pet_skill_capability(provider,s,PetSkillCapabilityProvider())
        self.assertIsNone(actual.pet_id);self.assertIsNone(actual.source_pet_skill_card_id)
        packet=context_packet(s,c,b,actual,h,True)
        bound=bind_snapshot(snapshot_from_state(s,c,b,a,'ACTUAL_HELPER_FAKE_PROVIDER',1,
            time.perf_counter_ns(),time.perf_counter_ns()),packet,a)
        self.assertTrue(any(x['eligible'] and x['baseline_member']
            for x in bound.recorded.plain()['d2_actions']['choices']))

    def test_card_only_mode_rejects_conflicting_metadata_or_missing_current_ui(self):
        s,c,b,cap,h,a,packet,snap=full_fixture(native_source=True)
        action=snap.baseline
        for bad in (replace(cap,pet_id=999),replace(cap,source_pet_skill_card_id=8),
                replace(cap,pet_id=2035),replace(cap,card_id=8),
                replace(cap,live_card_address=None),replace(cap,live_button_address=None),
                replace(cap,card_data_address=None),replace(cap,source='METADATA_ONLY'),
                replace(cap,ownership_current=False),replace(cap,live_card_present=False),
                replace(cap,session_key=replace(cap.session_key,match_id='OTHER'))):
            with self.subTest(bad=bad):
                self.assertFalse(current_action_allowed(action,context_packet(s,c,b,bad,h,True)))

    def test_current_card_worker_result_is_independently_validated(self):
        fixture,raw,kwargs=completed_fixture(native_source=True)
        offer=CompletedProposal.prepare(**kwargs)
        scope=raw['summary']['skill_model_source']
        self.assertIsNone(scope['pet_id'])
        self.assertEqual(scope['source_binding'],'CURRENT_OWNED_CARD_PET_ID_UNKNOWN')
        self.assertIsNone(offer.reply.proposal)

    def test_missing_comparison_evidence_is_job_fallback_and_does_not_kill_bridge(self):
        s,c,b,cap,h,a,packet,snap=full_fixture(native_source=True)
        cap=replace(cap,source='MISSING_CURRENT_UI_BINDING')
        bridge=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
            verified_build_sha256=a.game_build_sha256,enabled=True,warm_worker=True,decision_budget=True)
        try:
            now=time.perf_counter_ns();bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
            publish_context_safely(bridge,s,c,b,cap,h,True)
            self.assertEqual(bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False),'FALLBACK')
            self.assertFalse(bridge.disabled)
            self.assertEqual(bridge.preparation_reason,'D2_BASELINE_EVIDENCE_UNAVAILABLE')
            selected=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
            self.assertIs(selected.decision,b);self.assertIsNone(selected.receipt)
        finally:self.assertTrue(bridge.close())

    def test_skill_and_pass_represented_even_below_advisory_threshold(self):
        *_,snap=full_fixture(threshold=64)
        result=plan_full_actions(snap)
        self.assertEqual({s.action.family for s in result.scores},{'swap','pet_skill','pass'})
        self.assertTrue(any(s.baseline_member for s in result.scores))
        skill=next(s for s in result.scores if s.action.family=='pet_skill')
        self.assertEqual(dict(skill.features)['T'].reason,'CONDITIONAL_NO_ORIGINAL_SWORD_SURVIVES_REFILL_THREAT_UNKNOWN')
        self.assertEqual(skill.details.plain()['actual_post_skill_threat'],'UNKNOWN_REFILL_AND_BOSS_POLICY')
        self.assertIn('PERFECT_ONLY_NOT_GUARANTEED',skill.details.plain()['assumptions'])

    def test_all_costs_saturated_have_no_unlimited_progress_credit(self):
        *_,snap=full_fixture(mana=400,rage=250)
        for score in plan_full_actions(snap).scores:
            self.assertEqual(dict(score.features)['R'].high,0)

    def test_same_snapshot_has_deterministic_best_or_completed_retention(self):
        *_,snap=full_fixture()
        self.assertEqual(plan_full_actions(snap).dumps(),plan_full_actions(snap).dumps())

    def test_real_comparison_can_choose_skill_under_advisory_setting_without_forced_override(self):
        s,c,b,cap,h,a,packet,snap=full_fixture(threshold=64)
        result=plan_full_actions(snap)
        self.assertEqual(result.proposal.family,'pet_skill')
        self.assertFalse(next(x for x in snap.recorded.plain()['d2_actions']['choices']
            if x['action']['family']=='pet_skill')['facts']['advisory_condition_ready'])
        chosen=apply_action(b,result.proposal,s,packet)
        self.assertEqual(chosen.action,PolicyAction.PET_SKILL)
        *_,ordinary=full_fixture(threshold=7)
        self.assertIsNone(plan_full_actions(ordinary).proposal)  # Agreement with BASIC is successful retention.

    def test_unknown_effect_retains_opaque_baseline(self):
        *_,snap=full_fixture()
        ctx=snap.recorded.plain();ctx['d2_actions']['perfect_geometry']=None
        result=plan_full_actions(replace(snap,recorded=FrozenJSON.of(ctx)))
        self.assertIsNone(result.proposal)
        self.assertEqual(result.reason,'OPAQUE_SKILL_COMPARISON')

    def test_affordability_source_cooldown_and_authoritative_pass_are_hard(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        skill=next(Action.from_dict(x['action']) for x in snap.recorded.plain()['d2_actions']['choices']
            if x['action']['family']=='pet_skill')
        self.assertTrue(current_action_allowed(skill,packet))
        for bad in (replace(cap,effective_mana_cost=999),replace(cap,cooldown_turns=1),
            replace(cap,live_card_actionable=False),replace(cap,source_pet_skill_card_id=999),
            replace(cap,card_id=99),replace(cap,effective_mana_cost_source=type(cap.effective_mana_cost_source).UNKNOWN)):
            self.assertFalse(current_action_allowed(skill,context_packet(s,c,b,bad,h,True)))
        mandatory=replace(s,battle=replace(s.battle,consecutive_passes=2,
            consecutive_pass_status=GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION))
        self.assertFalse(current_action_allowed(Action('pass'),context_packet(mandatory,c,b,cap,h,True)))
        closed=SkillRushMatchContext(s.battle.session_key,1,s.battle.turn_number)
        self.assertFalse(current_action_allowed(skill,context_packet(s,c,b,cap,closed,True)))

    def test_family_recipe_preserves_only_correct_source_and_clears_other_targets(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        for action in (Action('pass'),next(Action.from_dict(x['action']) for x in
                snap.recorded.plain()['d2_actions']['choices'] if x['action']['family']=='pet_skill')):
            d=apply_action(b,action,s,packet)
            self.assertIsNone(d.move);self.assertIsNone(d.card_object_address)
            if action.family=='pet_skill':
                self.assertEqual(d.skill_card_id,7);self.assertEqual(d.skill_session_key,s.battle.session_key)
            else:self.assertIsNone(d.skill_card_id)

    def test_pass_is_excluded_when_existing_coordinator_is_disabled_even_with_server_permission(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        closed=context_packet(s,c,b,cap,h,True,pass_owner_allowed=False)
        self.assertFalse(current_action_allowed(Action('pass'),closed))
        self.assertNotEqual(context_hash(packet),context_hash(closed))
        snap=bind_snapshot(snapshot_from_state(s,c,b,a,'OWNER_TEST',1,time.perf_counter_ns(),time.perf_counter_ns()),closed,a)
        self.assertFalse(any(x.action.family=='pass' for x in plan_full_actions(snap).scores))

    def test_worker_reply_roundtrip_and_independent_validator(self):
        fixture,raw,kwargs=completed_fixture()
        offer=CompletedProposal.prepare(**kwargs)
        self.assertEqual(offer.reply.reason,raw['reason'])
        poisoned=json.loads(json.dumps(raw));poisoned['summary']['candidates'][0]['utility']['low']+=1
        with self.assertRaises(ValueError):
            CompletedProposal.prepare(**(kwargs|dict(raw_reply=canonical_json(poisoned).encode())))

    def test_completed_retention_has_receipt_and_preserves_action_fields(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        fixture,raw,kwargs=completed_fixture();s,c,b,cap,h,a,packet,snap=fixture
        offer=CompletedProposal.prepare(**kwargs)
        self.assertIsNone(offer.reply.proposal)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(selected.receipt,offer)
        self.assertEqual(selected.reason,'VALID_COMPLETED_R1_RETENTION')
        self.assertIs(selected.decision,b)
        self.assertEqual(replace(selected.decision,trace=b.trace),b)
        self.assertIsNone(revalidate_safely(adapter,offer,s,b,c,now_ns=time.perf_counter_ns(),
            input_allowed=True,context=a.context,final=True,final_remaining_seconds=14))

    def test_foreign_history_has_no_post_skill_credit(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        foreign=SkillRushMatchContext(replace(s.battle.session_key,match_id='FOREIGN'),1,1)
        packet=context_packet(s,c,b,cap,foreign,True)
        now=time.perf_counter_ns()
        snapshot=bind_snapshot(snapshot_from_state(s,c,b,a,'FOREIGN_HISTORY',1,now,now),packet,a)
        self.assertEqual(snapshot.recorded.plain()['d2_actions']['past_success_count'],0)

    def test_forged_context_fact_with_unchanged_context_hash_is_not_trusted(self):
        fixture,raw,kwargs=completed_fixture()
        snap=kwargs['job'].snapshot;record=snap.recorded.plain()
        record['d2_actions']['perfect_geometry']['quantities']['sword']['effective']+=1
        job=replace(kwargs['job'],snapshot=replace(snap,recorded=FrozenJSON.of(record)),
            binding=replace(kwargs['job'].binding,snapshot_id=replace(snap,recorded=FrozenJSON.of(record)).snapshot_id))
        wire=dict(snapshot=job.snapshot.to_dict(),binding=vars(job.binding),job_id=job.job_id,
            generation=job.generation,refinement=False,budget_ns=1_000_000_000,schema=JOB_SCHEMA)
        reply=_reply_for(wire,threading.Event())
        with self.assertRaisesRegex(ValueError,'derived eligibility/effect'):
            CompletedProposal.prepare(**(kwargs|dict(job=job,raw_reply=canonical_json(reply).encode())))

    def test_wire_pass_only_admitted_for_d2_and_packer_rechecks_decision(self):
        fixture,raw,kwargs=completed_fixture();job=kwargs['job']
        poisoned=json.loads(json.dumps(raw));poisoned['proposal']=Action('pass').to_dict()
        poisoned['disposition']='USE_CANDIDATE';poisoned['summary']['proposed_candidate_id']=job.candidate_id(Action('pass'))
        _validate_reply(canonical_json(poisoned).encode(),job)
        if raw['proposal']!=poisoned['proposal']:
            with self.assertRaises(ValueError):
                CompletedProposal.prepare(**(kwargs|dict(raw_reply=canonical_json(poisoned).encode())))

    def test_late_reply_and_changed_context_rejected_before_input(self):
        fixture,raw,kwargs=completed_fixture()
        with self.assertRaises(ValueError):CompletedProposal.prepare(**(kwargs|dict(completed_ns=kwargs['job'].deadline_ns)))
        s,c,b,cap,h,a,packet,snap=fixture
        offer=CompletedProposal.prepare(**kwargs)
        bridge=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=False,decision_budget=True)
        try:
            bridge.completed=offer;bridge.action_context=context_packet(s,c,b,replace(cap,cooldown_turns=1),h,True)
            chosen=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
            self.assertEqual(chosen.reason,'D2_CAPABILITY_OR_HISTORY_CHANGED');self.assertIs(chosen.decision,b)
        finally:self.assertTrue(bridge.close())

    def test_fresh_observation_timestamp_alone_not_a_capability_change(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        self.assertEqual(context_hash(packet),context_hash(context_packet(s,c,b,replace(cap,observed_at=99),h,True)))

    def test_idle_permission_change_binds_same_board_context(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        changed=replace(s,battle=replace(s.battle,
            consecutive_pass_status=GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION))
        from pokiguard_v2.autonomous_control import AutonomousSource
        self.assertEqual(AutonomousSource.from_state(s),AutonomousSource.from_state(changed))
        self.assertNotEqual(context_hash(packet),context_hash(context_packet(changed,c,b,cap,h,True)))

    def test_each_idle_proof_field_is_bound_without_changing_common_source_identity(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        for change in (dict(consecutive_passes=0), dict(consecutive_pass_threshold=3),
                dict(consecutive_pass_source='OTHER'), dict(consecutive_pass_reset_evidence='OTHER'),
                dict(consecutive_pass_confidence='reset_unknown'), dict(turn_number=1)):
            with self.subTest(change=change):
                changed=replace(s,battle=replace(s.battle,**change))
                self.assertNotEqual(context_hash(packet),context_hash(context_packet(changed,c,b,cap,h,True)))

    def test_changed_idle_authority_vetoes_completed_comparison_at_every_checkpoint(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        fixture,raw,kwargs=completed_fixture(native_source=True)
        s,c,b,cap,h,a,packet,snap=fixture
        offer=CompletedProposal.prepare(**kwargs)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet
        selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(selected.receipt,offer)
        changed=replace(s,battle=replace(s.battle,consecutive_pass_status=GameOwnedIdleStatus.UNKNOWN))
        adapter.action_context=context_packet(changed,c,b,cap,h,True)
        root=select_safely(adapter,changed,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(root.decision,b);self.assertIsNone(root.receipt)
        self.assertEqual(root.reason,'D2_CAPABILITY_OR_HISTORY_CHANGED')
        for final in (False,True):
            with self.subTest(final=final):
                self.assertEqual(revalidate_safely(adapter,offer,changed,b,c,now_ns=time.perf_counter_ns(),
                    input_allowed=True,context=a.context,final=final,final_remaining_seconds=14),
                    'D2_CAPABILITY_OR_HISTORY_CHANGED')
        self.assertFalse(adapter.disabled)

    def test_stale_packet_cannot_mask_changed_current_idle_proof(self):
        from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
        fixture,raw,kwargs=completed_fixture(native_source=True)
        s,c,b,cap,h,a,packet,snap=fixture
        changed=replace(s,battle=replace(s.battle,consecutive_pass_reset_evidence=None))
        with self.assertRaisesRegex(ValueError,'action context changed'):
            CompletedProposal.prepare(**(kwargs|dict(state=changed)))
        offer=CompletedProposal.prepare(**kwargs)
        adapter=GuardedSelectionAdapter(offer,diagnostics=MemorySink().buffer,enabled=True,pilot_authority=a)
        adapter.action_context=packet  # Deliberately keep the old published view.
        root=select_safely(adapter,changed,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        self.assertIs(root.decision,b);self.assertIsNone(root.receipt)
        for final in (False,True):
            with self.subTest(final=final):
                self.assertEqual(revalidate_safely(adapter,offer,changed,b,c,now_ns=time.perf_counter_ns(),
                    input_allowed=True,context=a.context,final=final,final_remaining_seconds=14),
                    'D2_CAPABILITY_OR_HISTORY_CHANGED')
        self.assertFalse(adapter.disabled)

    def test_real_isolated_worker_completes_all_action_snapshot_and_stop_closes(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        bridge=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=True,decision_budget=True)
        try:
            now=time.perf_counter_ns()
            self.assertTrue(bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context))
            publish_context_safely(bridge,s,c,b,cap,h,True)
            outcome=bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False)
            self.assertEqual(outcome,'COMPLETED',dict(bridge.bridge_counts))
            self.assertIsNotNone(bridge.completed)
            self.assertEqual({x['action']['family'] for x in bridge.last_snapshot.recorded.plain()['d2_actions']['choices']},
                {'swap','pet_skill','pass'})
        finally:self.assertTrue(bridge.close())

    def test_exact_previous_controller_after_removing_only_optional_d2_seams(self):
        # D3's sealed predecessor is the D2 controller. Later game geometry
        # updates are not part of this historical optional-seam assertion.
        import hashlib
        from pokiguard_v2.reasoning_demon_native import NATIVE_SOURCE
        previous=ROOT/'docs/phase5/artifacts/5d3_demon_reasoning_20261018'
        manifest=json.loads((previous/'before_source.json').read_text('utf-8'))
        self.assertEqual(manifest['fingerprint'],NATIVE_SOURCE)
        current=previous/'before_source/tools/basic_auto_bot.py'
        self.assertEqual(hashlib.sha256(current.read_bytes()).hexdigest(),manifest['files']['tools/basic_auto_bot.py'])
        proof=controller_boundary(ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1/offline_completion_v1/before/tools/basic_auto_bot.py',
            current)
        self.assertTrue(proof['legacy_ast_exact'])

    def test_stop_interrupts_new_family_decision_slice_without_worker_wait(self):
        s,c,b,cap,h,a,packet,snap=full_fixture()
        bridge=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=True,decision_budget=True)
        try:
            now=time.perf_counter_ns();bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
            publish_context_safely(bridge,s,c,b,cap,h,True)
            begin=time.perf_counter_ns()
            self.assertEqual(bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:True),'STOPPED')
            self.assertLess((time.perf_counter_ns()-begin)/1e6,25)
        finally:self.assertTrue(bridge.close())

    def test_new_skill_recipe_uses_unchanged_one_shot_dispatch_and_source_fence(self):
        from pokiguard_v2.pet_skill_farm import PetSkillFarmDispatcher
        from pokiguard_v2.pet_skill_action import PetSkillActionResultKind
        from pokiguard_v2.autonomous_control import AutonomousActionIdentity
        from tests.test_phase3c1_pet_skill_dispatch import FakeLease,result
        s,c,b,cap,h,a,packet,snap=full_fixture(threshold=64)
        skill=next(Action.from_dict(x['action']) for x in snap.recorded.plain()['d2_actions']['choices']
            if x['action']['family']=='pet_skill')
        recipe=apply_action(b,skill,s,packet)
        identity=AutonomousActionIdentity.from_decision(s,recipe)
        self.assertEqual(identity.action,PolicyAction.PET_SKILL)
        dispatcher=PetSkillFarmDispatcher();lease=FakeLease();calls=[]
        primitive=lambda:(calls.append('EXISTING_QTE'),result(PetSkillActionResultKind.SUCCESS_PERFECT,clicks=1))[1]
        source=(s.battle.session_key,s.battle.turn_number)
        first=dispatcher.dispatch(source=source,acquire=lease.acquire,primitive=primitive,
            complete=lease.complete,abandon=lease.abandon)
        second=dispatcher.dispatch(source=source,acquire=lease.acquire,primitive=primitive,
            complete=lease.complete,abandon=lease.abandon)
        self.assertTrue(first.source_turn_closed);self.assertFalse(first.allow_same_turn_fallback)
        self.assertEqual(calls,['EXISTING_QTE']);self.assertEqual(lease.acquired,1)


if __name__=='__main__':unittest.main()
