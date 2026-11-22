"""G4 uses real solver cascades; controller/native input surfaces are fakes."""
from dataclasses import replace
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction
from pokiguard_v2.board_simulator import ResourceResult, ResourceTally, SwapMove, evaluate_all_moves, simulate_move
from pokiguard_v2.gameplay_profile import AuditionMode, DamageCardMode, EvolutionTarget, MainPetType, PetSkillFireCondition
from pokiguard_v2.galaxy_shadow_sword import _Budget, _future, _options, milestone, plan_g4, projection
from pokiguard_v2.pet_configuration import GameplayConfig, basic_policy_config, gameplay_config_from_args, requires_attack_card_preparation
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_swap_timing import prepare_reasoning_options_safely
from pokiguard_v2.state import BoardState, CellState, GemType
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_phase3c1_pet_skill_policy import capability, session_state

FIXTURE=Path(__file__).parent/'fixtures/g4_combo_cases_20261122.json'


def config(**changes):
    return GameplayConfig.from_dict({**dict(play_style='galaxy_shadow_sword',main_pet='galaxy',
        evolution='none',damage_card='pet_passive'),**changes})


def board(case, multiplier=1):
    return BoardState(tuple(tuple(CellState(r,c,GemType(g),multiplier) for c,g in enumerate(row))
        for r,row in enumerate(case['board'])))


def cases():
    return json.loads(FIXTURE.read_bytes())['cases']


def mixed_three(multiplier):
    # This stable fixture clears three Health cells, with no cascade. The weighted
    # cell is outside the swap endpoints, so its source coordinate is unchanged.
    source=board(cases()[0])
    source=replace(source,cells=tuple(tuple(replace(c,multiplier=multiplier)
        if (c.row,c.col)==(3,5) else c for c in row) for row in source.cells))
    return source,SwapMove((2,4),(3,4))


def native_board(turn):
    case=next(c for c in json.loads((FIXTURE.parent/'g4_native_denial_20261122.json').read_bytes())['cases'] if c['turn']==turn)
    return BoardState(tuple(tuple(CellState(r,c,GemType(g),n)
        for c,(g,n) in enumerate(row)) for r,row in enumerate(case['board'])))


class G4ConfigTests(unittest.TestCase):
    def test_passive_profile_roundtrips_preferences_and_cli_without_card_preparation(self):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
        from tools.farm_run import build_parser
        cfg=config()
        self.assertIs(cfg.pet_skill_fire_condition,PetSkillFireCondition.AUTO_COMBO)
        self.assertIsNone(cfg.pet_skill_fire_value)
        self.assertIs(cfg.audition_mode,AuditionMode.NO_ACTION)
        self.assertFalse(cfg.capability.pet_skill_selectable)
        self.assertFalse(requires_attack_card_preparation(cfg))
        self.assertEqual(cfg,GameplayConfig.from_dict(cfg.to_dict()))
        args=build_parser().parse_args(['--stage-b2-farm','--play-style','galaxy_shadow_sword',
            '--main-pet','galaxy','--evolution-target','none','--damage-card','pet_passive'])
        self.assertEqual(cfg,gameplay_config_from_args(args))
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            store=DesktopPreferenceStore(Path(d)/'preferences.json')
            desktop=DesktopConfig().with_gameplay_config(cfg)
            store.save(desktop);loaded=store.load()
            self.assertTrue(loaded.loaded);self.assertFalse(loaded.warnings)
            self.assertEqual(cfg,loaded.config.gameplay_config)

    def test_incompatible_skill_evolution_and_cost_condition_are_rejected(self):
        good=config().to_dict()
        for change in (dict(main_pet='normal'),dict(evolution='galaxy'),dict(evolution='legendary'),
            dict(damage_card='pet_skill'),dict(audition_mode='audition_v3'),
            dict(pet_skill_fire_condition='skill_cost_ready')):
            with self.subTest(change=change),self.assertRaises(ValueError):
                GameplayConfig.from_dict(dict(good,**change))
        with self.assertRaisesRegex(ValueError,'AUTO_COMBO_REQUIRES_G4'):
            GameplayConfig.from_dict(dict(GameplayConfig().to_dict(),pet_skill_fire_condition='auto_combo',pet_skill_fire_value=None))

    def test_ui_reasoning_owner_preserves_budget_without_common_profile_or_active_card(self):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.reasoning_ui_session import create_ui_reasoning_session
        from pokiguard_v2.reasoning_galaxy import GalaxyReasoningSession
        cfg=replace(DesktopConfig().with_gameplay_config(config()),ai=AISettings(False,50,True))
        events=[]
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            with patch('pokiguard_v2.reasoning_ui_profile.load_session_authority',side_effect=AssertionError('no common migration')):
                session=create_ui_reasoning_session(cfg,paths=None,game_executable=None,
                    directory=Path(d)/'ai',observer=lambda s,*_:events.append(s))
            self.assertIsInstance(session,GalaxyReasoningSession)
            session.bind_run('SYNTHETIC_G4',Path(d)/'farm')
            self.assertEqual(dict(galaxy_reasoning=True,g4_reasoning_budget_ms=50),prepare_reasoning_options_safely(session))
            self.assertEqual('UI_REASONING_G4_READY',events[-1].reason)
            session.stop();self.assertTrue(session.wait_closed())
            self.assertEqual({},prepare_reasoning_options_safely(session))
        for value in (True,0,251,'100'):
            invalid=SimpleNamespace(prepare_options=lambda:dict(galaxy_reasoning=True,g4_reasoning_budget_ms=value))
            self.assertEqual({},prepare_reasoning_options_safely(invalid))


class G4SolverTests(unittest.TestCase):
    def test_real_cascades_cover_every_tier_and_keep_physical_diagnostics(self):
        for case in cases():
            with self.subTest(count=case['expected_physical']):
                move=SwapMove(*(tuple(p) for p in case['move']))
                value=simulate_move(board(case),move)
                self.assertIsNotNone(value)
                p=projection(value)
                self.assertEqual(case['expected_physical'],p['known_destroyed_cells'])
                self.assertEqual(case['expected_direct'],p['direct_cells'])
                self.assertEqual(case['expected_cascade'],p['cascade_cells'])
                self.assertEqual(p['known_destroyed_cells'],sum(len(wave) for wave in value.clear_rounds))
                self.assertEqual(case['expected_physical'],p['known_combo_units'])
                self.assertEqual(min(13,case['expected_physical']) if case['expected_physical']>=9 else 0,p['declared_milestone'])
                self.assertFalse(p['actual_refill_used']);self.assertIsNone(p['actual_damage'])
                self.assertFalse(p['kill_certified']);self.assertFalse(p['survival_certified'])

    def test_every_multiplier_counts_in_direct_and_cascade_activation_units(self):
        case=cases()[0];move=SwapMove(*(tuple(p) for p in case['move']))
        low=projection(simulate_move(board(case),move))
        self.assertGreater(low['cascade_cells'],0)
        for multiplier in range(1,8):
            with self.subTest(multiplier=multiplier):
                high=projection(simulate_move(board(case,multiplier),move))
                self.assertEqual(8,high['known_destroyed_cells'])
                self.assertEqual(8*multiplier,high['known_combo_units'])
                self.assertEqual(low['direct_cells']*multiplier,high['direct_combo_units'])
                self.assertEqual(low['cascade_cells']*multiplier,high['cascade_combo_units'])
                self.assertEqual(high['known_combo_units'],high['direct_combo_units']+high['cascade_combo_units'])
                self.assertEqual(milestone(8*multiplier),high['declared_milestone'])
                self.assertEqual('MULTIPLIER_WEIGHTED_ALL_GEMS_PER_SWAP',high['trigger_counting'])
                self.assertFalse(high['actual_refill_used'])

    def test_mixed_seven_plus_one_plus_one_reaches_nine_from_three_cells(self):
        for multiplier,expected_tier in ((6,0),(7,9)):
            source,swap=mixed_three(multiplier)
            p=projection(simulate_move(source,swap))
            self.assertEqual(3,p['known_destroyed_cells']);self.assertEqual(0,p['cascade_cells'])
            self.assertEqual(multiplier+2,p['known_combo_units'])
            self.assertEqual(expected_tier,p['declared_milestone'])

    def test_weighted_trigger_cannot_outrank_a_move_with_zero_known_sword_reply(self):
        source,swap=mixed_three(7)
        state=replace(session_state(mana=0,rage=0),board=source)
        moves=evaluate_all_moves(source)
        self.assertEqual(8,max(m.total.total_cells for m in moves))
        for reasoning in (False,True):
            plan=plan_g4(state,moves,reasoning=reasoning,clock=lambda:0)
            self.assertNotEqual(swap,plan.selected.move)
            self.assertEqual(0,plan.selected.sword_risk.opponent_sword_reply_effective_max)
            self.assertEqual(9,projection(simulate_move(source,swap))['known_combo_units'])

    def test_future_options_use_weighted_cascades_without_refill(self):
        source=board(cases()[0],3)
        expected={m.move:m.total.total_effective for m in evaluate_all_moves(source)}
        options=_options(source.cells,_Budget(250,lambda:0))
        self.assertEqual(expected,{swap:units for swap,units,_swords,_after in options})
        self.assertTrue(any(units>13 for _swap,units,_swords,_after in options))

    def test_basic_prefers_highest_reachable_tier_and_does_not_chase_extra_above_thirteen(self):
        for case in cases():
            state=replace(session_state(mana=0,rage=0),board=board(case))
            moves=evaluate_all_moves(state.board)
            plan=plan_g4(state,moves)
            floor=min(m.sword_risk.opponent_sword_reply_effective_max for m in moves)
            pool=[m for m in moves if m.sword_risk.opponent_sword_reply_effective_max==floor]
            self.assertEqual(max(milestone(m.total.total_effective) for m in pool),plan.facts['selected']['declared_milestone'])
            self.assertIn(plan.selected,moves)

    def test_conditional_setup_retains_all_sword_first_ties_and_never_sums_replies(self):
        # Pure solver surfaces isolate the boss-response aggregation contract.
        move=SimpleNamespace(result='start')
        responses=[('A',3,6,'afterA'),('B',4,6,'afterB'),('C',12,3,'afterC')]
        with patch('pokiguard_v2.galaxy_shadow_sword._options',side_effect=[responses,[('a',13,0,None)],[('b',8,0,None)]]) as resolve:
            future=_future(move,_Budget(150,lambda:0))
        self.assertEqual(8,future['conditional_floor']);self.assertEqual(13,future['conditional_ceiling'])
        self.assertEqual(2,future['reply_count']);self.assertEqual(3,resolve.call_count)
        with patch('pokiguard_v2.galaxy_shadow_sword._options',return_value=responses[:1]*5):
            many=_future(move,_Budget(150,lambda:0))
        self.assertFalse(many['complete']);self.assertEqual(0,many['conditional_floor'])

    def test_setup_timeout_returns_a_legal_current_move_without_stop_or_invented_floor(self):
        state=session_state(mana=0,rage=0)
        state=replace(state,player=replace(state.player,hp=state.player.max_hp))
        moves=tuple(m for m in evaluate_all_moves(state.board) if m.total.total_effective<9 and m.sword_effective==0)
        clock=iter([0,1000000000]).__next__
        plan=plan_g4(state,moves,reasoning=True,budget_ms=50,clock=clock)
        self.assertIn(plan.selected,moves);self.assertTrue(plan.facts['setup_budget_exhausted'])
        self.assertIsNone(plan.facts['setup']);self.assertFalse(plan.facts['auto_stop_for_danger'])

    def test_pressure_prefers_known_health_and_denial_over_risky_activation(self):
        case=json.loads(FIXTURE.read_bytes())['pressure_case']
        state=replace(session_state(mana=0,rage=0),board=board(case))
        state=replace(state,player=replace(state.player,hp=state.player.max_hp))
        moves=evaluate_all_moves(state.board)
        healthy=plan_g4(state,moves,reasoning=True)
        critical=replace(state,player=replace(state.player,hp=state.player.max_hp//10))
        protected=plan_g4(critical,moves,reasoning=True)
        self.assertEqual(0,healthy.selected.sword_risk.opponent_sword_reply_effective_max)
        self.assertEqual('PROTECT',protected.step)
        self.assertEqual(0,protected.selected.sword_risk.opponent_sword_reply_effective_max)
        self.assertGreater(protected.selected.total.effective(GemType.HEALTH),0)
        self.assertFalse(protected.facts['selected']['survival_certified'])

    def test_combo_setup_can_replace_small_sword_without_increasing_known_reply(self):
        case=json.loads(FIXTURE.read_bytes())['setup_case']
        state=replace(session_state(mana=0,rage=0),board=board(case))
        state=replace(state,player=replace(state.player,hp=state.player.max_hp))
        moves=evaluate_all_moves(state.board)
        self.assertLess(max(m.total.total_effective for m in moves),9)
        plan=plan_g4(state,moves,reasoning=True,budget_ms=250,clock=lambda:0)
        self.assertEqual('CONDITIONAL_SETUP',plan.step)
        self.assertTrue(any(m.sword_effective for m in moves))
        self.assertEqual(min(m.sword_risk.opponent_sword_reply_effective_max for m in moves),
            plan.selected.sword_risk.opponent_sword_reply_effective_max)
        self.assertGreaterEqual(plan.facts['setup']['conditional_floor'],9)
        self.assertTrue(plan.facts['setup']['complete']);self.assertLessEqual(plan.facts['setup_nodes'],1800)
        self.assertFalse(plan.facts['actual_refill_used'])

    def test_subthreshold_combo_does_not_accumulate_across_turns(self):
        case=cases()[0];state=replace(session_state(mana=0,rage=0),board=board(case))
        moves=evaluate_all_moves(state.board)
        for turn in (1,3,5):
            plan=plan_g4(replace(state,battle=replace(state.battle,turn_number=turn)),moves)
            self.assertEqual(8,plan.facts['selected']['known_destroyed_cells'])
            self.assertEqual(8,plan.facts['selected']['known_combo_units'])
            self.assertEqual(0,plan.facts['selected']['declared_milestone'])

    def test_thirteen_is_a_tier_plateau_and_healing_is_not_inferred_from_boss_hp(self):
        self.assertEqual(13,milestone(14));self.assertEqual(13,milestone(64*7))
        case=json.loads((FIXTURE.parent/'g4_native_denial_20261122.json').read_bytes())['cases'][-1]
        source=BoardState(tuple(tuple(CellState(r,c,GemType(g),n)
            for c,(g,n) in enumerate(row)) for r,row in enumerate(case['board'])))
        state=replace(session_state(mana=0,rage=250,boss_hp=1),board=source)
        p=plan_g4(state,evaluate_all_moves(state.board),reasoning=True).facts['selected']
        self.assertGreaterEqual(p['declared_milestone'],11)
        self.assertTrue(p['lifesteal_opportunity']);self.assertIsNone(p['actual_heal'])
        self.assertIsNone(p['actual_damage']);self.assertFalse(p['kill_certified'])


class G4PolicyTests(unittest.TestCase):
    def test_both_evolution_routes_roundtrip_and_use_the_existing_evolution_action(self):
        for main,evolution in (('normal','galaxy'),('galaxy','normal')):
            with self.subTest(route=(main,evolution)):
                cfg=config(main_pet=main,evolution=evolution)
                self.assertEqual(cfg,GameplayConfig.from_dict(cfg.to_dict()))
                self.assertFalse(requires_attack_card_preparation(cfg))
                engine=BasicPolicyEngine(basic_policy_config(cfg))
                state=session_state(mana=250,rage=0)
                state=replace(state,fusion=replace(state.fusion,available=True,mana_cost=200))
                decision=engine.decide(state,pet_skill_capability=capability())
                self.assertIs(decision.action,PolicyAction.EVOLVE)
                self.assertTrue(decision.requires_state_reread)
                self.assertIsNone(decision.trace.g4_combo)
                fused=replace(state,fusion=replace(state.fusion,used=True,available=False))
                after=engine.decide(fused,pet_skill_capability=capability())
                self.assertIs(after.action,PolicyAction.SWAP)
                self.assertTrue(after.trace.g4_combo['passive_active'])

    def test_normal_to_g4_does_not_credit_passive_before_confirmed_evolution(self):
        cfg=basic_policy_config(config(main_pet='normal',evolution='galaxy'))
        source,_=mixed_three(7)
        state=replace(session_state(mana=0,rage=0),board=source)
        for fusion in (None,state.fusion,replace(state.fusion,mana_cost=None),
                replace(state.fusion,available=True,mana_cost=200)):
            for reasoning in (False,True):
                decision=BasicPolicyEngine(cfg,galaxy_reasoning=reasoning).decide(replace(state,fusion=fusion))
                self.assertIs(decision.action,PolicyAction.SWAP)
                facts=decision.trace.g4_combo
                self.assertFalse(facts['passive_active'])
                self.assertEqual(0,facts['trigger_candidates'])
                self.assertEqual(0,facts['selected']['declared_milestone'])
                self.assertIsNone(facts['selected']['declared_damage_reference'])
                self.assertFalse(decision.trace.selected_fire_condition_ready)
                self.assertIsNone(decision.skill_card_id)

    def test_g4_primary_keeps_passive_while_normal_evolution_is_unavailable(self):
        engine=BasicPolicyEngine(basic_policy_config(config(evolution='normal')))
        decision=engine.decide(session_state(mana=0,rage=0))
        self.assertIs(decision.action,PolicyAction.SWAP)
        self.assertTrue(decision.trace.g4_combo['passive_active'])

    def test_policy_logs_physical_and_effective_counts_separately(self):
        case=json.loads((FIXTURE.parent/'g4_native_denial_20261122.json').read_bytes())['cases'][-1]
        source=BoardState(tuple(tuple(CellState(r,c,GemType(g),n)
            for c,(g,n) in enumerate(row)) for r,row in enumerate(case['board'])))
        swap=SwapMove((1,2),(1,3))
        state=replace(session_state(mana=0,rage=0),board=source)
        decision=BasicPolicyEngine(basic_policy_config(config())).decide(state)
        self.assertIs(decision.action,PolicyAction.SWAP);self.assertEqual(swap,decision.move)
        self.assertEqual(3,decision.trace.selected_known_gem_count)
        self.assertEqual(12,decision.trace.selected_known_gem_effective_count)
        self.assertTrue(decision.trace.selected_fire_condition_ready)
        self.assertEqual('PER_SWAP_EFFECTIVE_CLEAR_LOWER_BOUND',decision.trace.fire_condition_scope)

    def test_no_card_cost_or_rage_requirement_and_no_evolve_cast_or_pet_skill(self):
        cfg=basic_policy_config(config())
        for mana,rage in ((0,0),(250,250),(None,None)):
            state=session_state(mana=0,rage=0)
            state=replace(state,player=replace(state.player,mana=mana,power=rage))
            d=BasicPolicyEngine(cfg).decide(state,pet_skill_capability=capability(element='GALAXY_RICKY',mana_cost=0,rage_cost=0))
            self.assertIs(d.action,PolicyAction.SWAP)
            self.assertIsNone(d.skill_card_id);self.assertIsNone(d.card_object_address)
            self.assertEqual(dict(mana=0,rage=0),d.trace.g4_combo['resource_cost'])
            self.assertFalse(d.trace.g4_combo['skill_card_click'])

    def test_every_legal_move_dangerous_still_acts_and_does_not_override_idle_rules(self):
        state=session_state(mana=0,rage=0)
        moves=evaluate_all_moves(state.board)
        risky=tuple(replace(m,sword_risk=replace(m.sword_risk,safe=False,
            opponent_sword_reply_effective_max=7,danger_score=999)) for m in moves)
        for reasoning in (False,True):
            policy=BasicPolicyEngine(basic_policy_config(config()),galaxy_reasoning=reasoning)
            for count in (None,0,1,2):
                s=replace(state,battle=replace(state.battle,consecutive_passes=count))
                with patch('pokiguard_v2.basic_policy.evaluate_all_moves',return_value=risky):d=policy.decide(s)
                self.assertIs(d.action,PolicyAction.SWAP);self.assertIsNone(d.trace.blocker)

    def test_local_turn_timer_and_move_permission_still_gate_g4(self):
        state=session_state(mana=0,rage=0);policy=BasicPolicyEngine(basic_policy_config(config()))
        for change in (dict(is_local_turn=False),dict(client_move_allowed=False),dict(turn_timer_source=None),dict(turn_time_remaining_seconds=0)):
            with self.subTest(change=change):
                d=policy.decide(replace(state,battle=replace(state.battle,**change)))
                self.assertIs(d.action,PolicyAction.NONE);self.assertIsNone(d.trace.g4_combo)

    def test_real_controller_keeps_final_read_swap_and_ack_with_no_skill_dispatch(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            code,calls,rows=controller_trace(Path(d)/'combat.jsonl',profile='galaxy_shadow_sword',gameplay_config=config())
        self.assertEqual(0,code)
        self.assertEqual(1,calls.count('FAKE_NORMAL_INPUT'))
        decisions=[r for r in rows if r.get('event')=='policy_decision']
        self.assertTrue(decisions);self.assertTrue(decisions[0]['trace']['policy_step'].startswith('G4_COMBO_'))
        self.assertEqual(1,sum(r.get('event')=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED' for r in rows))

    def test_reasoning_controller_reruns_g4_and_final_turn_change_still_blocks_input(self):
        from tests.reasoning_controller_fixture import controller_trace
        from tools import basic_auto_bot as bot
        original=bot.run
        def reasoning(*args,**kwargs):
            return original(*args,**kwargs,galaxy_reasoning=True,g4_reasoning_budget_ms=50)
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d,patch.object(bot,'run',side_effect=reasoning):
            code,calls,rows=controller_trace(Path(d)/'r.jsonl',profile='galaxy_shadow_sword',gameplay_config=config())
            self.assertEqual(0,code);self.assertEqual(1,calls.count('FAKE_NORMAL_INPUT'))
            self.assertEqual('REASONING',next(r for r in rows if r.get('event')=='policy_decision')['trace']['g4_combo']['mode'])
            _,blocked,_=controller_trace(Path(d)/'changed.jsonl',profile='galaxy_shadow_sword',gameplay_config=config(),case='wrong_turn')
            self.assertEqual(0,blocked.count('FAKE_NORMAL_INPUT'))


class G4NativeDenialTests(unittest.TestCase):
    """Previously lost match: frozen pre-action boards only, no later refill."""

    def states(self):
        fixture=json.loads((FIXTURE.parent/'g4_native_denial_20261122.json').read_bytes())
        for case in fixture['cases']:
            source=BoardState(tuple(tuple(CellState(r,c,GemType(g),n)
                for c,(g,n) in enumerate(row)) for r,row in enumerate(case['board'])))
            state=SimpleNamespace(player=SimpleNamespace(**case['player']),
                opponents=(SimpleNamespace(**case['boss']),))
            yield case,state,evaluate_all_moves(source)

    def test_all_eleven_native_boards_avoid_every_avoidable_known_sword_reply(self):
        changed=0
        for case,state,moves in self.states():
            for reasoning in (False,True):
                with self.subTest(turn=case['turn'],reasoning=reasoning):
                    plan=plan_g4(state,moves,reasoning=reasoning,clock=lambda:0)
                    self.assertEqual(0,plan.selected.sword_risk.opponent_sword_reply_effective_max)
                    self.assertEqual(0,plan.facts['minimum_known_boss_sword_reply'])
                    self.assertFalse(plan.facts['refill_safety_certified'])
                    self.assertFalse(plan.facts['actual_refill_used'])
                    if not reasoning and case['turn'] in (1,3,5,7,11,13):
                        self.assertNotEqual(case['old_selected'],dict(first=list(plan.selected.move.first),second=list(plan.selected.move.second)))
                        changed+=1
        self.assertEqual(6,changed)

    def test_native_opening_takes_safe_sword_instead_of_trigger_that_feeds_boss(self):
        case,state,moves=next(self.states())
        plan=plan_g4(state,moves)
        self.assertEqual('BEST_AVAILABLE',plan.step)
        self.assertEqual(SwapMove((5,4),(5,5)),plan.selected.move)
        self.assertEqual(3,plan.selected.sword_effective)
        self.assertEqual(6,plan.facts['selected']['known_combo_units'])
        self.assertEqual(0,plan.facts['selected']['declared_milestone'])

    def test_safe_native_trigger_is_still_preferred_when_it_leaves_no_sword(self):
        for case,state,moves in self.states():
            if case['turn'] not in (15,17,21):continue
            plan=plan_g4(state,moves)
            self.assertGreaterEqual(plan.facts['selected']['declared_milestone'],11)
            self.assertEqual(0,plan.selected.sword_risk.opponent_sword_reply_effective_max)

    def test_no_zero_reply_still_plays_least_exposure_without_danger_stop(self):
        _case,state,moves=next(self.states())
        varied=tuple(replace(m,sword_risk=replace(m.sword_risk,safe=False,
            opponent_sword_reply_effective_max=3 if i==0 else 7)) for i,m in enumerate(moves))
        for reasoning in (False,True):
            plan=plan_g4(state,varied,reasoning=reasoning,clock=lambda:0)
            self.assertEqual(varied[0],plan.selected)
            self.assertEqual(3,plan.facts['minimum_known_boss_sword_reply'])
            self.assertFalse(plan.facts['auto_stop_for_danger'])


class G4RouteGoalTests(unittest.TestCase):
    def test_no_evolution_does_not_force_small_sword_over_larger_subthreshold_combo(self):
        # Controlled ranking inputs isolate this user rule from refill/geometry.
        state=session_state(mana=0,rage=0)
        moves=evaluate_all_moves(state.board)
        empty=ResourceResult()
        def outcome(gem,units):
            return ResourceResult(((gem,ResourceTally(3,units)),))
        sword=replace(moves[0],direct=outcome(GemType.SWORD,3),cascade=empty,
            total=outcome(GemType.SWORD,3),sword_risk=replace(moves[0].sword_risk,opponent_sword_reply_effective_max=0))
        combo=replace(moves[1],direct=outcome(GemType.MANA,5),cascade=empty,
            total=outcome(GemType.MANA,5),sword_risk=replace(moves[1].sword_risk,opponent_sword_reply_effective_max=0))
        for reasoning in (False,True):
            with patch('pokiguard_v2.galaxy_shadow_sword._future',return_value=dict(complete=False,conditional_floor=0)):
                plan=plan_g4(state,(sword,combo),reasoning=reasoning)
            self.assertEqual(combo,plan.selected)
            self.assertEqual('PASSIVE_COMBO',plan.facts['goal'])
            self.assertEqual(5,plan.facts['selected']['known_combo_units'])

    def test_both_routes_prioritize_mana_over_current_skill_combo_even_when_hp_is_low(self):
        source=native_board(17)
        for main,evolution in (('galaxy','normal'),('normal','galaxy')):
            for reasoning in (False,True):
                state=replace(session_state(mana=0,rage=250),board=source)
                state=replace(state,player=replace(state.player,hp=state.player.max_hp//10),
                    fusion=replace(state.fusion,available=True,mana_cost=200))
                policy=BasicPolicyEngine(basic_policy_config(config(main_pet=main,evolution=evolution)),galaxy_reasoning=reasoning)
                decision=policy.decide(state)
                self.assertIs(decision.action,PolicyAction.SWAP)
                self.assertEqual(SwapMove((3,2),(3,3)),decision.move)
                facts=decision.trace.g4_combo
                self.assertEqual('G4_COMBO_EVOLUTION_MANA',decision.trace.policy_step)
                self.assertEqual('EVOLUTION',facts['goal']);self.assertEqual(200,facts['evolution_missing_mana'])
                self.assertEqual(5,facts['evolution_mana_progress_units'])
                self.assertEqual(0,facts['boss_reply_sword_max']);self.assertEqual(0,facts['setup_nodes'])
                self.assertEqual(main=='galaxy',facts['passive_active'])

    def test_enough_mana_evolves_first_then_same_turn_fresh_state_uses_combo(self):
        for main,evolution in (('galaxy','normal'),('normal','galaxy')):
            for reasoning in (False,True):
                state=replace(session_state(mana=250,rage=250),board=native_board(17))
                state=replace(state,fusion=replace(state.fusion,available=True,mana_cost=200))
                policy=BasicPolicyEngine(basic_policy_config(config(main_pet=main,evolution=evolution)),galaxy_reasoning=reasoning)
                before=policy.decide(state)
                self.assertIs(before.action,PolicyAction.EVOLVE);self.assertTrue(before.requires_state_reread)
                after=policy.decide(replace(state,fusion=replace(state.fusion,used=True,available=False)))
                self.assertIs(after.action,PolicyAction.SWAP)
                self.assertEqual('PASSIVE_COMBO',after.trace.g4_combo['goal'])
                self.assertFalse(after.trace.g4_combo['evolution_pending'])
                self.assertGreaterEqual(after.trace.g4_combo['selected']['declared_milestone'],11)

    def test_no_evolution_configuration_ignores_runtime_fusion_and_plays_combo(self):
        state=replace(session_state(mana=250,rage=250),board=native_board(17))
        state=replace(state,fusion=replace(state.fusion,available=True,mana_cost=200))
        for reasoning in (False,True):
            decision=BasicPolicyEngine(basic_policy_config(config()),galaxy_reasoning=reasoning).decide(state)
            self.assertIs(decision.action,PolicyAction.SWAP)
            self.assertEqual('PASSIVE_COMBO',decision.trace.g4_combo['goal'])
            self.assertGreaterEqual(decision.trace.g4_combo['selected']['declared_milestone'],11)

    def test_ready_mana_with_unavailable_card_keeps_evolution_goal_without_more_mana_priority(self):
        for main,evolution in (('galaxy','normal'),('normal','galaxy')):
            state=replace(session_state(mana=250,rage=250),board=native_board(17))
            state=replace(state,fusion=replace(state.fusion,available=False,mana_cost=200,locked_this_turn=True))
            decision=BasicPolicyEngine(basic_policy_config(config(main_pet=main,evolution=evolution)),galaxy_reasoning=True).decide(state)
            self.assertIs(decision.action,PolicyAction.SWAP)
            facts=decision.trace.g4_combo
            self.assertEqual('EVOLUTION',facts['goal']);self.assertEqual(0,facts['evolution_missing_mana'])
            self.assertEqual('WAIT_EVOLUTION_ACTION',facts['phase'])
            self.assertNotEqual('G4_COMBO_EVOLUTION_MANA',decision.trace.policy_step)
            self.assertEqual(main=='galaxy',facts['passive_active'])

    def test_unknown_evolution_cost_is_not_replaced_with_a_fixed_cost(self):
        state=replace(session_state(mana=0,rage=250),board=native_board(17))
        state=replace(state,fusion=replace(state.fusion,available=True,mana_cost=None))
        decision=BasicPolicyEngine(basic_policy_config(config(evolution='normal'))).decide(state)
        self.assertIs(decision.action,PolicyAction.SWAP)
        facts=decision.trace.g4_combo
        self.assertEqual('EVOLUTION',facts['goal']);self.assertIsNone(facts['evolution_missing_mana'])
        self.assertFalse(facts['evolution_cost_known']);self.assertIsNone(facts['evolution_mana_cost'])
        self.assertEqual(5,facts['evolution_mana_progress_units'])

    def test_full_mana_and_unknown_cost_do_not_invent_readiness_or_farm_mana_forever(self):
        state=replace(session_state(mana=0,rage=250),board=native_board(17))
        state=replace(state,player=replace(state.player,mana=state.player.max_mana),
            fusion=replace(state.fusion,available=True,mana_cost=None))
        decision=BasicPolicyEngine(basic_policy_config(config(evolution='normal'))).decide(state)
        self.assertIs(decision.action,PolicyAction.SWAP)
        facts=decision.trace.g4_combo
        self.assertEqual('EVOLUTION_MANA_CAPPED',facts['phase']);self.assertFalse(facts['evolution_cost_known'])
        self.assertNotEqual('G4_COMBO_EVOLUTION_MANA',decision.trace.policy_step)

    def test_evolution_mana_progress_never_bypasses_a_zero_known_sword_reply(self):
        state=session_state(mana=0,rage=0)
        moves=evaluate_all_moves(native_board(17))
        risky=next(m for m in moves if m.total.effective(GemType.MANA)==5)
        risky=replace(risky,sword_risk=replace(risky.sword_risk,opponent_sword_reply_effective_max=7))
        safer=next(m for m in moves if m.total.effective(GemType.MANA)==3 and m.sword_risk.opponent_sword_reply_effective_max==0)
        for reasoning in (False,True):
            plan=plan_g4(state,(risky,safer),reasoning=reasoning,evolution_pending=True,evolution_mana_cost=200)
            self.assertEqual(safer,plan.selected);self.assertEqual(3,plan.facts['evolution_mana_progress_units'])
            self.assertFalse(plan.facts['auto_stop_for_danger'])


class G4BossSkillThreatTests(unittest.TestCase):
    def native(self, turn):
        case=next(c for c in json.loads((FIXTURE.parent/'g4_reasoning_threat_20261123.json').read_bytes())['cases'] if c['turn']==turn)
        source=BoardState(tuple(tuple(CellState(r,c,GemType(g),n)
            for c,(g,n) in enumerate(line)) for r,line in enumerate(case['board'])))
        state=SimpleNamespace(player=SimpleNamespace(**case['player']),
            opponents=(SimpleNamespace(**case['boss']),))
        return state,evaluate_all_moves(source)

    def test_pressure_keeps_a_trigger_with_shield_instead_of_small_health_only(self):
        state,moves=self.native(9)
        plan=plan_g4(state,moves,reasoning=True,clock=lambda:0)
        self.assertEqual('PROTECTING_TRIGGER',plan.step)
        self.assertGreaterEqual(plan.facts['selected']['declared_milestone'],9)
        self.assertEqual(4,plan.selected.total.effective(GemType.SHIELD))
        self.assertTrue(any(m.total.effective(GemType.HEALTH)>0 for m in moves))

    def test_high_boss_resources_recognize_the_health_and_drain_defense(self):
        state,moves=self.native(11)
        plan=plan_g4(state,moves,reasoning=True,clock=lambda:0)
        self.assertEqual('PROTECT',plan.step)
        self.assertEqual(5,plan.selected.total.effective(GemType.HEALTH))
        self.assertEqual(3,plan.selected.total.effective(GemType.DRAIN))
        self.assertIsNone(plan.facts['boss_skill_threat']['skill_ready'])
        self.assertFalse(plan.facts['boss_skill_threat']['drain_prevents_skill_certified'])

    def test_last_board_without_defense_still_attacks_without_safe_stop(self):
        state,moves=self.native(19)
        plan=plan_g4(state,moves,reasoning=True,clock=lambda:0)
        self.assertIn(plan.selected,moves)
        self.assertEqual(10,plan.facts['selected']['known_combo_units'])
        self.assertEqual(0,plan.facts['minimum_known_boss_sword_reply'])
        self.assertFalse(plan.facts['selected']['survival_certified'])
        self.assertFalse(plan.facts['auto_stop_for_danger'])

    def test_every_loss_board_keeps_known_sword_denial_and_never_guesses_win(self):
        for turn in (1,3,5,7,9,11,15,17,19):
            state,moves=self.native(turn)
            plan=plan_g4(state,moves,reasoning=True,clock=lambda:0)
            with self.subTest(turn=turn):
                self.assertEqual(0,plan.facts['boss_reply_sword_max'])
                self.assertFalse(plan.facts['boss_skill_threat']['low_resources_exclude_skill'])
                self.assertFalse(plan.facts['selected']['kill_certified'])
                self.assertFalse(plan.facts['auto_stop_for_danger'])

    def test_mana_evolution_goal_still_precedes_passive_combo_under_skill_threat(self):
        state,moves=self.native(15)
        plan=plan_g4(state,moves,reasoning=True,evolution_pending=True,evolution_mana_cost=9999)
        self.assertEqual('EVOLUTION',plan.facts['goal'])
        self.assertEqual('EVOLUTION_MANA',plan.step)
        self.assertGreater(plan.selected.total.effective(GemType.MANA),0)
        self.assertFalse(plan.facts['auto_stop_for_danger'])


if __name__=='__main__':unittest.main()
