"""Common model replay: synthetic boards, no game/profile/native fixture access."""
from dataclasses import replace
import unittest
from pokiguard_v2.board_simulator import evaluate_all_moves,SimulatedCell
from pokiguard_v2.state import GemType
from pokiguard_v2.reasoning_common_problem import CommonProblem,CommonIntent,EffectChoice,PROFILES
from pokiguard_v2.reasoning_common_planner import plan_common,CommonLimits,_root_step,Work
from pokiguard_v2.reasoning_snapshot import Action,FrozenJSON,SourceIdentity,SourceRecord,digest
from tools.evaluate_reasoning_planner import board_data,demon_board,TARGET


def problem(profile='simple',*,board=None,baseline=None,settings=None,facts=None,effects=()):
    board=board or board_data('generated')
    own=dict(hp=50,max_hp=100,mana=30,max_mana=300,rage=0,max_rage=250)
    data=dict(root_allowed=True,pending=False,self=own,opponent=dict(mana=100),
        conversion=dict(mana=30,rage=20),demon_geometry='USER_DECLARED_PERPENDICULAR',
        boss_policy='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD')
    data.update(facts or {})
    config=dict(play_style=profile,pet_skill_fire_value=4,pet_skill_fire_condition='sword_count',demon_target_gem='shield')
    config.update(settings or {})
    source=SourceIdentity('SYNTHETIC_COMMON','SESSION','MATCH',1,2,digest(board),1,1)
    provenance=SourceRecord('synthetic/common.json',1,'a'*64,'a'*64)
    intent=CommonIntent(profile,FrozenJSON.of(config),FrozenJSON.of(dict(engine='common_reasoning.v1')),
        FrozenJSON.of(dict(provenance='SYNTHETIC_NO_NATIVE_AUTHORITY')))
    placeholder=baseline or Action('none')
    value=CommonProblem(source,provenance,intent,board,placeholder,'SYNTHETIC_INCUMBENT',FrozenJSON.of(data),effects)
    if baseline is None:
        moves=evaluate_all_moves(value.board_state())
        value=replace(value,baseline=Action('swap',moves[0].move))
    return value


R1=CommonLimits(lookahead=False,nodes=50000)


class CommonModelTests(unittest.TestCase):
    def test_every_demon_target_both_orientations_x2_and_x3(self):
        from pokiguard_v2.board_simulator import SwapMove
        for target in ('shield','health','mana','drain','rage'):
            for multiplier in (2,3):
                source=demon_board(swords=2,rage_cells=0,multiplier=multiplier)
                board=tuple(tuple((target if g=='shield' else 'shield' if g==target else g,m) for g,m in row) for row in source)
                for transpose in (False,True):
                    b=tuple(zip(*board)) if transpose else board
                    move=SwapMove(*(tuple(reversed(p)) for p in (TARGET.first,TARGET.second))) if transpose else TARGET
                    value=problem('demon_aegis_farm',board=b,baseline=Action('swap',move),settings=dict(demon_target_gem=target))
                    step=_root_step(value,tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in b),
                        move,Work(R1,lambda:0,lambda:False,None))
                    self.assertEqual((2,2*multiplier),(step.passive_physical,step.passive_swords))

    def test_setup_after_all_sword_ties_and_unknown_secondary_policy(self):
        import json
        from pathlib import Path
        from pokiguard_v2.board_simulator import SwapMove
        from pokiguard_v2.reasoning_common_planner import _replies,_setup
        raw=json.loads((Path(__file__).resolve().parents[1]/'docs/phase5/datasets/5b3_synthetic_boards_v1.json').read_text('utf-8'))
        for target in ('shield','health','mana','drain','rage'):
            data=raw['cases']['positive_sword_tie']
            board=tuple(tuple((target if g=='shield' else 'shield' if g==target else g,m) for g,m in row) for row in data['board'])
            move=SwapMove(*(tuple(c) for c in data['root']))
            value=problem('demon_aegis_farm',board=board,baseline=Action('swap',move),settings=dict(demon_target_gem=target))
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in board)
            work=Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None)
            root=_root_step(value,grid,move,work)
            all_replies,nominal,maximum=_replies(root.after,work,True)
            self.assertEqual((3,4),(len(nominal),maximum))
            # One favorable boss tie cannot certify the setup is ours next turn.
            qualities=[_setup(value,r.after,work) for r in nominal]
            self.assertEqual([0,0,1],sorted(qualities));self.assertEqual(0,min(qualities))
            _,unknown_policy,_=_replies(root.after,work,False)
            self.assertEqual(len(all_replies),len(unknown_policy))

    def test_all_seven_styles_share_exhaustive_swap_enumeration(self):
        for profile in sorted(PROFILES):
            with self.subTest(profile=profile):
                value=problem(profile)
                result=plan_common(value,R1)
                self.assertEqual(len(evaluate_all_moves(value.board_state())),len(result.scores))
                self.assertEqual(112,result.diagnostics.plain()['adjacent_pairs'])
                self.assertTrue(any(c.baseline_member for c in result.scores))
                self.assertTrue(all(c.details.plain()['settings_are_advisory'] for c in result.scores))
                self.assertFalse(result.to_dict()['input_authority'])

    def test_immutable_roundtrip_and_best_baseline_is_valid_retention(self):
        value=problem()
        restored=CommonProblem.from_dict(value.to_dict())
        self.assertEqual(value.snapshot_id,restored.snapshot_id)
        first=plan_common(value,R1);winner=first.proposal or value.baseline
        again=plan_common(replace(value,baseline=winner),R1)
        self.assertIsNone(again.proposal)
        self.assertEqual('COMMON_COMPLETED_RETENTION',again.reason)
        self.assertEqual(again.to_dict(),plan_common(replace(value,baseline=winner),R1).to_dict())

    def test_all_five_demon_targets_use_existing_geometry_and_weighted_swords(self):
        source=demon_board(swords=2,rage_cells=0,multiplier=2)
        results=[]
        for target in ('shield','health','mana','drain','rage'):
            board=tuple(tuple((target if g=='shield' else 'shield' if g==target else g,m) for g,m in row) for row in source)
            value=problem('demon_aegis_farm',board=board,baseline=Action('swap',TARGET),settings=dict(demon_target_gem=target))
            step=_root_step(value,tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in board),
                TARGET,Work(R1,lambda:0,lambda:False,None))
            self.assertEqual((2,4),(step.passive_physical,step.passive_swords))
            results.append(step.original_cells)
            result=plan_common(value,R1)
            scored=next(c for c in result.scores if c.action==value.baseline)
            self.assertEqual(1,dict(scored.features)['F'].low)
        self.assertTrue(all(cells==results[0] for cells in results))

    def test_preexisting_rage_relaxes_reference_without_same_burst_invention(self):
        own=dict(hp=50,max_hp=100,mana=30,max_mana=300,rage=100,max_rage=250)
        for rage,expected in ((100,1),(99,0)):
            value=problem('demon_aegis_farm',board=demon_board(swords=3,rage_cells=5),baseline=Action('swap',TARGET),
                facts=dict(self=dict(own,rage=rage),operator_demon_rage_discount=1))
            scored=next(c for c in plan_common(value,R1).scores if c.baseline_member)
            self.assertEqual(expected,dict(scored.features)['F'].low)
            self.assertEqual('UNKNOWN_NO_CREDIT',scored.details.plain()['same_burst_rage_sufficiency'])

    def test_pending_deadline_cancel_and_opaque_baseline_retain_without_authority(self):
        for value,limits,cancel,reason in ((problem(facts=dict(pending=True)),R1,False,'PENDING'),
            (problem(),CommonLimits(duration_ms=0),False,'DEADLINE'),(problem(),R1,True,'CANCELLED'),
            (problem(baseline=Action('evolve')),R1,False,'ACTION_OWNER'),
            (problem(baseline=Action('pet_skill',card_source='SYNTHETIC')),R1,False,'INCUMBENT'),
            (problem('demon_aegis_farm',facts=dict(demon_geometry=None)),R1,False,'UNCONFIRMED')):
            with self.subTest(reason=reason):
                result=plan_common(value,limits,cancelled=lambda:cancel)
                self.assertIsNone(result.proposal);self.assertIn(reason,result.reason)

    def test_skill_and_pass_use_same_chooser_actual_costs_not_setting_threshold(self):
        board=demon_board(swords=4,rage_cells=5)
        cells=tuple((r,c) for r,row in enumerate(board) for c,(g,m) in enumerate(row) if g in ('sword','rage','health'))
        skill=EffectChoice(Action('pet_skill',card_source='SYNTHETIC_CARD'),True,'OWNED_SOURCE_READY',cells,
            'CONDITIONAL_PERFECT_FIRST_WAVE','USER_CALIBRATED',10,0)
        passive=EffectChoice(Action('pass'),True,'CURRENT_SERVER_PASS_ALLOWED',(),
            'UNCHANGED_BOARD','VERIFIED_FOR_SCOPE')
        value=problem('skill_rush',board=board,settings=dict(pet_skill_fire_value=50),effects=(skill,passive))
        result=plan_common(value,R1)
        self.assertTrue(any(c.action==skill.action for c in result.scores))
        self.assertTrue(any(c.action==passive.action for c in result.scores))
        blocked=replace(value,effects=(replace(skill,mana_cost=500),replace(passive,eligible=False,reason='THIRD_PASS_FORBIDDEN')))
        checked=plan_common(blocked,R1)
        self.assertFalse(any(c.action in (skill.action,passive.action) for c in checked.scores))
        self.assertEqual(2,len(checked.diagnostics.plain()['excluded_actions']))

    def test_missing_conversion_is_an_interval_not_a_fake_zero(self):
        result=plan_common(problem(facts=dict(conversion={})),R1)
        self.assertTrue(any(dict(c.features)['R'].status=='UNSUPPORTED' and
            dict(c.features)['R'].high>dict(c.features)['R'].low for c in result.scores))

    def test_partial_future_does_not_commit_optimistic_credit(self):
        value=problem();one=plan_common(value,R1)
        result=plan_common(value,CommonLimits(nodes=50000,scenarios=1))
        self.assertEqual(one.proposal,result.proposal)
        self.assertIn(result.reason,('COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1','COMMON_LOOKAHEAD_NODE_CAP_USE_COMPLETED_R1'))


class CommonWorkerTests(unittest.TestCase):
    def test_existing_warm_worker_runs_common_dinosaur_and_cleans_up(self):
        import time
        from pokiguard_v2.reasoning_runner import make_job
        from pokiguard_v2.reasoning_warm_runner import WarmIsolatedRunner
        value=problem('dinosaur')
        runner=WarmIsolatedRunner()
        try:
            job=make_job(value,deadline=time.perf_counter_ns()+4_000_000_000)
            self.assertTrue(runner.submit(job))
            until=time.perf_counter()+5
            while runner.outcome is None and time.perf_counter()<until:time.sleep(.005)
            self.assertIsNotNone(runner.outcome)
            reply,reason=runner.outcome
            self.assertIsNotNone(reply,reason)
            selected=runner.disposition(job,current_binding=job.binding)
            self.assertFalse(selected.input_authority)
            self.assertEqual('common_reasoning.v1',__import__('json').loads(reply.summary_json)['common_engine'])
        finally:self.assertTrue(runner.close())
        self.assertEqual(runner.counters['processes'],runner.counters['reaped'])

    def test_common_wire_cannot_forge_an_ineligible_pass_or_alias_profile(self):
        import time,threading
        from pokiguard_v2.reasoning_runner import make_job,_reply_for,_validate_reply
        from pokiguard_v2.reasoning_snapshot import canonical_json
        value=problem('simple')
        job=make_job(value,deadline=time.perf_counter_ns()+4_000_000_000)
        wire=dict(job_id=job.job_id,generation=job.generation,binding=vars(job.binding),
            snapshot=value.to_dict(),refinement=False,budget_ns=4_000_000_000)
        reply=_reply_for(wire,threading.Event())
        reply.update(disposition='USE_CANDIDATE',proposal=Action('pass').to_dict())
        with self.assertRaises(ValueError):_validate_reply(canonical_json(reply).encode(),job)
        wire['binding']=dict(wire['binding'],profile='bu_win')
        with self.assertRaises(ValueError):_reply_for(wire,threading.Event())


if __name__=='__main__':unittest.main()
