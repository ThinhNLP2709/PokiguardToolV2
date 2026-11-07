"""User strategy examples: synthetic boards/capabilities, no live game IO."""
from dataclasses import replace
import json,time,unittest
from pokiguard_v2.board_simulator import ResourceResult,ResourceTally,SimulatedCell,SwapMove,evaluate_all_moves
from pokiguard_v2.reasoning_common_planner import Step,_features,_score,_setup,Work,CommonLimits,plan_common
from pokiguard_v2.reasoning_common_problem import EffectChoice
from pokiguard_v2.reasoning_common_tactics import evaluate_context,demon_damage_reference
from pokiguard_v2.reasoning_common_evidence import build_problem,packet
from pokiguard_v2.reasoning_snapshot import Action,FrozenJSON
from pokiguard_v2.state import GemType,BoardState,CellState
from tests.test_reasoning_common import problem,R1
from tests.test_reasoning_common_evidence import fixture
from tools.evaluate_reasoning_planner import demon_board


def context(profile='simple',**facts):
    own=dict(hp=100,max_hp=100,mana=300,max_mana=300,rage=100,max_rage=250,attack=100,shield=100)
    boss=dict(hp=200000,max_hp=200000,mana=300,max_mana=300,rage=100,max_rage=250,attack=100)
    return problem(profile,facts=dict(self=own,opponent=boss,**facts))


def step(value,*,family='swap',heal=False,mana_cost=0,rage_cost=0,**gems):
    resources=ResourceResult(tuple((GemType(g),ResourceTally(n,n)) for g,n in gems.items()))
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in value.board)
    action=Action('pass') if family=='pass' else Action('pet_skill',card_source='SYNTHETIC') if family=='pet_skill' else value.baseline
    return Step(action,resources,grid,'SYNTHETIC_KNOWN_FIRST_WAVE',mana_cost=mana_cost,rage_cost=rage_cost,heals_self=heal)


def direct_sword_problem(target='shield',transpose=False):
    from tools.evaluate_reasoning_planner import board_data
    data=[[('rage' if g==target else g,m) for g,m in row] for row in board_data('generated')]
    # A legal match of 3 physical Sword yields 7 effective Sword (2+2+3).
    for col,gem,mult in ((2,'sword',2),(3,'sword',2),(4,'health' if target=='mana' else 'mana',1),(5,'sword',3)):
        data[3][col]=(gem,mult)
    board=tuple(tuple(row) for row in data)
    if transpose:board=tuple(zip(*board))
    owned_pass=EffectChoice(Action('pass'),True,'SYNTHETIC_CURRENT_GAME_PASS_PROOF',(),
        'UNCHANGED_BOARD','VERIFIED_FOR_SCOPE')
    return problem('demon_aegis_farm',board=board,baseline=Action('pass'),effects=(owned_pass,),
        settings=dict(demon_target_gem=target),facts=dict(
        self=dict(hp=20000,max_hp=100000,mana=300,max_mana=300,rage=120,max_rage=250,attack=10000,shield=0),
        opponent=dict(hp=10000,max_hp=200000,mana=100,max_mana=300,rage=100,max_rage=250,attack=10000)))


class StrategyIntentTests(unittest.TestCase):
    def test_full_rage_values_mana_then_full_mana_values_needed_health(self):
        v=context();facts=v.facts.plain();facts['self'].update(mana=100,hp=50)
        v=replace(v,facts=FrozenJSON.of(facts))
        mana,md,_=evaluate_context(v,step(v,mana=3),[],0)
        rage,rd,_=evaluate_context(v,step(v,rage=3),[],0)
        self.assertGreater(mana['R'],rage['R']);self.assertTrue(rd['resource_value']['rage']['saturated'])
        facts['self']['mana']=300;v=replace(v,facts=FrozenJSON.of(facts))
        full,_,_=evaluate_context(v,step(v,mana=3),[],0)
        health,_,_=evaluate_context(v,step(v,health=3),[],0)
        self.assertEqual(0,full['R']);self.assertGreater(health['P'],0)
        facts['self']['hp']=100;v=replace(v,facts=FrozenJSON.of(facts))
        self.assertEqual(0,evaluate_context(v,step(v,health=3),[],0)[0]['P'])

    def test_fewer_swords_can_be_more_valuable_when_it_denies_boss_swords(self):
        for profile in ('simple','careful','dinosaur'):
            v=context(profile)
            many=step(v,sword=5);reply=step(v,sword=6)
            safe=step(v,sword=3)
            f,w,d=_features(v,many,[reply],6);a=_score(v,many,f,w,d)
            f,w,d=_features(v,safe,[],0);b=_score(v,safe,f,w,d)
            self.assertGreater(b.utility.low,a.utility.high)

    def test_legal_pass_beats_useless_swap_when_full_and_no_offensive_or_denial_opportunity(self):
        source=demon_board(swords=0,rage_cells=0)
        data=tuple(tuple(('health' if g in ('shield','drain') else g,m) for g,m in row) for row in source)
        v=context();v=replace(v,board=data,baseline=Action('swap',evaluate_all_moves(BoardState(tuple(
            tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(row)) for r,row in enumerate(data))))[0].move),
            effects=(EffectChoice(Action('pass'),True,'SYNTHETIC_CURRENT_PASS_PROOF',(),
                'UNCHANGED_BOARD','VERIFIED_FOR_SCOPE'),))
        result=plan_common(v,R1)
        self.assertEqual(Action('pass'),result.proposal,result.reason)
        blocked=replace(v,effects=(replace(v.effects[0],eligible=False,reason='THIRD_PASS_FORBIDDEN'),))
        self.assertFalse(any(c.action.family=='pass' for c in plan_common(blocked,R1).scores))

    def test_boss_mana_rage_hp_and_own_resources_change_protection_and_risk(self):
        v=context();facts=v.facts.plain()
        loaded=evaluate_context(v,step(v,drain=3),[],0)[0]['P']
        facts['opponent']['mana']=0;empty=replace(v,facts=FrozenJSON.of(facts))
        self.assertGreater(loaded,evaluate_context(empty,step(empty,drain=3),[],0)[0]['P'])
        sword_reply=step(v,sword=2)
        high=evaluate_context(v,step(v,mana=3),[sword_reply],2)[0]['T']
        facts['opponent']['rage']=0;low=replace(v,facts=FrozenJSON.of(facts))
        self.assertGreater(high,evaluate_context(low,step(low,mana=3),[sword_reply],2)[0]['T'])
        facts['opponent'].update(hp=1000,mana=300);hurt=replace(v,facts=FrozenJSON.of(facts))
        heal_reply=step(v,health=3)
        self.assertGreater(evaluate_context(hurt,step(hurt,mana=3),[heal_reply],0)[0]['T'],
            evaluate_context(v,step(v,mana=3),[heal_reply],0)[0]['T'])
        drain_reply=step(v,drain=3)
        rich=evaluate_context(v,step(v,mana=3),[drain_reply],0)[0]['T']
        facts['self']['mana']=0;poor=replace(v,facts=FrozenJSON.of(facts))
        self.assertGreater(rich,evaluate_context(poor,step(poor,mana=3),[drain_reply],0)[0]['T'])

    def test_boss_threat_uses_one_possible_reply_instead_of_combining_ties(self):
        v=context('careful');facts=v.facts.plain();facts['opponent']['hp']=50000
        v=replace(v,facts=FrozenJSON.of(facts))
        own=step(v,mana=3)
        replies=[step(v,sword=2,drain=3),step(v,sword=2,health=5)]
        risk,details,_=evaluate_context(v,own,replies,2)
        self.assertAlmostEqual(max(evaluate_context(v,own,[r],2)[0]['T'] for r in replies),risk['T'])
        self.assertEqual('WORST_SINGLE_REPLY',details['boss_reply_proxy']['aggregation'])
        self.assertEqual(0,details['boss_reply_proxy']['health'])

    def test_missing_reply_with_refill_does_not_certify_zero_threat(self):
        v=context()
        chosen=step(v,mana=3)
        changed=(tuple([SimulatedCell(GemType.UNKNOWN,None),*chosen.after[0][1:]]),*chosen.after[1:])
        f,w,d=_features(v,replace(chosen,after=changed),[],0)
        self.assertEqual('UNSUPPORTED',dict(_score(v,chosen,f,w,d).features)['T'].status)
        self.assertIn('NO_KNOWN_REPLY_WITH_UNRESOLVED_REFILL',d['unknown_effects'])

    def test_mega_prepares_actual_evolution_cost_before_farming_extra_rage(self):
        v=context('mega_icarus_spam_skill');facts=v.facts.plain()
        facts['self'].update(mana=200,rage=80)
        facts['evolution']=dict(pending=True,mana_cost=240)
        v=replace(v,facts=FrozenJSON.of(facts))
        mana,details,_=evaluate_context(v,step(v,mana=2),[],0)
        rage,_,_=evaluate_context(v,step(v,rage=3),[],0)
        self.assertGreater(mana['R'],rage['R'])
        self.assertEqual(240,details['resource_value']['mana']['goal'])
        self.assertEqual('EVOLUTION_PREPARATION',details['objective_phase'])
        self.assertIsNone(plan_common(replace(v,baseline=Action('evolve')),R1).proposal)

    def test_skill_rush_builds_ready_skill_and_preserves_a_following_cycle(self):
        v=context('skill_rush');facts=v.facts.plain()
        facts['self'].update(mana=80,rage=80);facts['resource_requirements']=dict(mana=100,rage=100)
        v=replace(v,facts=FrozenJSON.of(facts))
        result,details,_=evaluate_context(v,step(v,mana=1),[],0)
        self.assertGreater(result['R'],0);self.assertEqual(200,details['resource_value']['mana']['goal'])
        facts['self']['mana']=120;buffer=replace(v,facts=FrozenJSON.of(facts))
        self.assertGreater(evaluate_context(buffer,step(buffer,mana=1),[],0)[0]['R'],0)

    def test_skill_readiness_checks_both_costs_and_retains_later_cycle_priority(self):
        v=context('skill_rush',resource_requirements=dict(mana=100,rage=100),past_skill_successes=1)
        facts=v.facts.plain();facts['self'].update(mana=80,rage=80)
        v=replace(v,facts=FrozenJSON.of(facts))
        incomplete=step(v,mana=1)
        f,w,d=_features(v,incomplete,[],0)
        self.assertEqual(7,w['R'])
        self.assertEqual(0,d['tactical_context']['skill_resource_readiness']['unlock_bonus'])
        _,complete,_=evaluate_context(v,step(v,mana=1,rage=1),[],0)
        self.assertEqual(1,complete['skill_resource_readiness']['after'])
        self.assertGreater(complete['skill_resource_readiness']['unlock_bonus'],0)
        self.assertEqual(200,complete['resource_value']['rage']['goal'])
        facts['self'].update(mana=220,rage=165)
        one_short=replace(v,facts=FrozenJSON.of(facts))
        extra_mana=evaluate_context(one_short,step(one_short,mana=5),[],0)[0]['R']
        missing_rage=evaluate_context(one_short,step(one_short,rage=2),[],0)[0]['R']
        self.assertGreater(missing_rage,extra_mana)
        facts['self'].update(mana=100,rage=100)
        ready=replace(v,facts=FrozenJSON.of(facts))
        _,ready_weights,_=_features(ready,step(ready,mana=1),[],0)
        self.assertEqual(3,ready_weights['R'])
        skill=step(ready,family='pet_skill',mana_cost=100,rage_cost=100,rage=5)
        score,details,_=evaluate_context(ready,skill,[],0)
        self.assertEqual(0,score['R'])
        self.assertIsNone(details['skill_resource_readiness']['after'])

    def test_demon_future_sweep_uses_its_own_known_rage(self):
        from pokiguard_v2.reasoning_common_models import DEMON_RAGE_REFERENCE
        settings=dict(demon_strategy=dict(rage_reference=DEMON_RAGE_REFERENCE.plain()),operator_demon_rage_discount=1)
        def setup(rage_cells, **facts):
            v=problem('demon_aegis_farm',board=demon_board(swords=3,rage_cells=rage_cells),facts=dict(settings,**facts))
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in v.board)
            return _setup(v,grid,Work(CommonLimits(),lambda:0,lambda:False,None))
        self.assertEqual(1.,setup(5))
        self.assertEqual(.75,setup(4))
        self.assertEqual(.75,setup(5,operator_demon_rage_discount=None))

    def test_mega_heal_can_override_sword_setting_but_not_be_rewarded_at_full_hp(self):
        v=context('mega_icarus_spam_skill');facts=v.facts.plain()
        facts['self']['hp']=10;v=replace(v,facts=FrozenJSON.of(facts))
        skill=step(v,family='pet_skill',heal=True,sword=1,mana_cost=100,rage_cost=100)
        swap=step(v,sword=3)
        def score(problem,action):
            f,w,d=_features(problem,action,[],0);return _score(problem,action,f,w,d)
        self.assertGreater(score(v,skill).utility.low,score(v,swap).utility.high)
        facts['self']['hp']=100;full=replace(v,facts=FrozenJSON.of(facts))
        self.assertLess(score(full,skill).utility.high,score(full,swap).utility.low)
        self.assertEqual('UNKNOWN',score(v,skill).details.plain()['tactical_context']['self_heal_amount'])

    def test_settings_for_non_sword_skill_goals_are_not_silently_dropped(self):
        v=problem('skill_rush',settings=dict(pet_skill_fire_condition='mana_gem_count',pet_skill_fire_value=3))
        grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in v.board)
        self.assertIsNotNone(_setup(v,grid,Work(CommonLimits(),lambda:0,lambda:False,None)))

    def test_demon_nominal_damage_is_scoped_to_account_loadout_match_and_counter(self):
        v=context('demon_aegis_farm');facts=v.facts.plain()
        facts.update(account_sha256='a'*64,damage_session='SYNTHETIC_SESSION')
        facts['opponent']['max_hp']=300000
        signature=lambda a:[a[k] for k in ('max_hp','max_mana','max_rage','attack')]
        model=dict(kind='USER_SCOPED_DEMON_NOMINAL_DAMAGE',session=facts['damage_session'],
            account_sha256=facts['account_sha256'],player_stats=signature(facts['self']),
            opponent_stats=signature(facts['opponent']),counter_confirmed=True,nominal_two_sword_damage=100000)
        facts['demon_damage_model']=model
        burst=replace(step(v,sword=2),passive_swords=2,passive_physical=2,coverage='CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY')
        for hp,expected in ((90000,2),(125000,3),(175000,4),(250000,5)):
            facts['opponent']['hp']=hp
            target,details=demon_damage_reference(facts,burst,4)
            self.assertEqual(expected,target);self.assertFalse(details['kill_certified'])
        for key,value in (('counter_confirmed',False),('account_sha256','b'*64),('session','OTHER_MATCH')):
            altered=dict(facts,demon_damage_model=dict(model,**{key:value}))
            self.assertIsNone(demon_damage_reference(altered,burst,4)[0])
        self.assertIsNone(demon_damage_reference(dict(facts,demon_damage_model=None),burst,4)[0])

    def test_builder_publishes_evolution_and_actual_mega_heal_without_extra_reads(self):
        from pokiguard_v2.state import FusionState
        value=list(fixture());value[0]=replace(value[0],fusion=FusionState(True,False,False,False,mana_cost=240))
        now=time.perf_counter_ns()
        p=build_problem(tuple(value),run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)
        self.assertEqual(240,p.facts.plain()['evolution']['mana_cost'])
        self.assertEqual(dict(mana=30,rage=20),p.facts.plain()['conversion'])

    def test_worker_host_select_two_sword_demon_goal_only_with_matching_context(self):
        from tests.test_reasoning_common_models import demon_packet
        from tests.test_reasoning_pilot import MemorySink
        from pokiguard_v2.basic_policy import BasicPolicyEngine
        from pokiguard_v2.reasoning_common_selection import CommonAdmission,CommonSelectionBridge,CONTEXT
        from pokiguard_v2.reasoning_common_evidence import policy_json
        from pokiguard_v2.reasoning_full_actions import publish_context_safely
        from pokiguard_v2.reasoning_selection import select_safely
        state,cfg,*_=demon_packet()
        data=demon_board(swords=2,rage_cells=0,multiplier=1)
        board=BoardState(tuple(tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(row)) for r,row in enumerate(data)))
        state=replace(state,board=board,player=replace(state.player,power=100,attack=100),
            battle=replace(state.battle,local_username='SYNTHETIC_SCOPE_USER',current_turn_player='SYNTHETIC_SCOPE_USER'),
            opponents=tuple(replace(a,hp=90000,max_hp=200000,max_mana=300,max_power=250,attack=100)
                if a.is_boss else a for a in state.opponents))
        base=BasicPolicyEngine(cfg).decide(state);value=packet(state,cfg,base,None,None,True)
        now=time.perf_counter_ns();probe=build_problem(value,run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)
        facts=probe.facts.plain();sig=lambda a:[a[k] for k in ('max_hp','max_mana','max_rage','attack')]
        model=dict(kind='USER_SCOPED_DEMON_NOMINAL_DAMAGE',session=facts['damage_session'],account_sha256=facts['account_sha256'],
            player_stats=sig(facts['self']),opponent_stats=sig(facts['opponent']),counter_confirmed=True,nominal_two_sword_damage=100000)
        admission=CommonAdmission(policy_json(cfg),FrozenJSON.of(dict(swap=100)),FrozenJSON.of(dict(demon_damage_model=model)))
        b=CommonSelectionBridge(admission=admission,diagnostics=MemorySink(),enabled=True)
        try:
            now=time.perf_counter_ns();self.assertTrue(b.observe(state,cfg,observed_ns=now,read_end_ns=now,context=CONTEXT))
            publish_context_safely(b,*value)
            self.assertEqual('COMPLETED',b.await_decision(state,base,cfg,context=CONTEXT,stop_requested=lambda:False),b.preparation_reason)
            chosen=select_safely(b,state,base,cfg,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
            self.assertIsNotNone(chosen.receipt)
            summary=json.loads(chosen.receipt.reply.summary_json)
            # The host verified the same conditional model; no native input is owned here.
            self.assertIn('USER_SCOPED_NOMINAL_ESTIMATE',json.dumps(summary))
            self.assertIsNotNone(chosen.receipt.reply.proposal)
        finally:self.assertTrue(b.close())

    def test_real_mega_capability_exposes_heal_opportunity_without_changing_qte(self):
        from pokiguard_v2.basic_policy import BasicPolicyEngine,PlayStyle
        from pokiguard_v2.pet_configuration import MainPetType,EvolutionTarget,DamageCardMode
        from pokiguard_v2.pet_skill_shadow import PetSkillFamily
        value=list(fixture());state=value[0]
        value[0]=replace(state,player=replace(state.player,hp=state.player.max_hp//2),fusion=replace(state.fusion,used=True))
        value[1]=replace(value[1],play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL,main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.MEGA,damage_card=DamageCardMode.PET_SKILL)
        value[3]=replace(value[3],card_id=22,skill_card_id=22,pet_id=2524,source_pet_skill_card_id=22,
            skill_family=PetSkillFamily.MEGA_ICARUS_CLICK_ONLY)
        value[2]=BasicPolicyEngine(value[1]).decide(value[0],pet_skill_capability=value[3])
        now=time.perf_counter_ns();p=build_problem(tuple(value),run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)
        effect=next(c for c in p.effects if c.action.family=='pet_skill')
        self.assertTrue(effect.eligible);self.assertTrue(effect.facts.plain()['self_heal_present'])
        self.assertEqual('UNCHANGED_EXISTING_OWNER',effect.facts.plain()['QTE_executor'])
        result=plan_common(p,R1);score=next(c for c in result.scores if c.action.family=='pet_skill')
        self.assertGreater(score.details.plain()['tactical_context']['protection_proxy']['self_heal_opportunity'],0)

    def test_demon_can_take_direct_sword_without_target_instead_of_waiting(self):
        from pokiguard_v2.board_simulator import SwapMove
        for target in ('shield','health','mana','drain','rage'):
            for transpose in (False,True):
                with self.subTest(target=target,transpose=transpose):
                    p=direct_sword_problem(target,transpose)
                    self.assertFalse(any(g==target for row in p.board for g,m in row))
                    expected=SwapMove((4,3),(5,3)) if transpose else SwapMove((3,4),(3,5))
                    result=plan_common(p,R1)
                    # Gravity remains downward after a transpose; resource cascades
                    # can make another consuming move better than this Sword match.
                    if not transpose:self.assertEqual(Action('swap',expected),result.proposal,result.reason)
                    self.assertIsNotNone(result.proposal);self.assertNotEqual('pass',result.proposal.family)
                    score=next(c for c in result.scores if c.action==Action('swap',expected))
                    passed=next(c for c in result.scores if c.action.family=='pass')
                    self.assertGreater(score.utility.low,passed.utility.high)
                    self.assertEqual(7,score.details.plain()['normal_sword_effective'])
                    self.assertEqual(0,score.details.plain()['passive_sword_effective'])
                    self.assertGreater(dict(score.features)['D'].low,0)
                    self.assertFalse(score.details.plain()['offensive_opportunity']['kill_certified'])
        # Exercise the production bounded lookahead as well as the completed root pass.
        self.assertEqual(Action('swap',SwapMove((3,4),(3,5))),plan_common(direct_sword_problem()).proposal)

    def test_direct_sword_credit_has_no_seven_sword_gate(self):
        p=direct_sword_problem()
        for count in (3,4,5,7):
            f,w,d=_features(p,replace(step(p,sword=count),ordinary_swords=count),[],0)
            self.assertGreater(f['D'],0)
            self.assertEqual(count,d['offensive_opportunity']['effective_swords'])
        f,_,_=_features(p,step(p),[],0)
        self.assertEqual(0,f['D'])

    def test_attack_opportunity_changes_with_hp_and_rage_without_damage_claim(self):
        p=direct_sword_problem()
        def value(facts):
            q=replace(p,facts=FrozenJSON.of(facts));f,w,d=_features(q,step(q,sword=5),[],0)
            return f['D']*w['D'],d['offensive_opportunity']
        facts=p.facts.plain();urgent,detail=value(facts)
        facts['opponent']['hp']=facts['opponent']['max_hp'];healthy_boss,_=value(facts)
        self.assertGreater(urgent,healthy_boss)
        facts['self']['rage']=0;no_rage,_=value(facts)
        self.assertGreater(healthy_boss,no_rage)
        self.assertIsNone(detail['estimated_damage']);self.assertFalse(detail['kill_certified'])
        missing=p.facts.plain();missing['opponent'].pop('hp');missing['self'].pop('rage')
        _,detail=value(missing)
        self.assertEqual(0,detail['urgency']);self.assertEqual(1,detail['weight_multiplier'])

    def test_direct_sword_is_not_forced_over_a_better_boss_denial(self):
        p=direct_sword_problem()
        greedy=replace(step(p,sword=7),ordinary_swords=7)
        safer=replace(step(p,sword=5),ordinary_swords=5)
        boss_reply=step(p,sword=7)
        f,w,d=_features(p,greedy,[boss_reply],7);a=_score(p,greedy,f,w,d)
        f,w,d=_features(p,safer,[],0);b=_score(p,safer,f,w,d)
        self.assertGreater(b.utility.low,a.utility.high)

    def test_bu_win_keeps_its_opponent_sword_objective(self):
        p=direct_sword_problem();p=problem('bu_win',board=p.board,facts=p.facts.plain())
        f,w,d=_features(p,step(p,sword=7),[],0)
        self.assertEqual(0,w['D']);self.assertEqual(1,d['offensive_opportunity']['weight_multiplier'])

    def test_worker_host_replaces_actual_demon_setup_with_direct_sword(self):
        from tests.test_reasoning_common_models import demon_packet
        from tests.test_reasoning_pilot import MemorySink
        from pokiguard_v2.basic_policy import BasicPolicyEngine
        from pokiguard_v2.reasoning_common_selection import CommonAdmission,CommonSelectionBridge,CONTEXT
        from pokiguard_v2.reasoning_common_evidence import policy_json
        from pokiguard_v2.reasoning_full_actions import publish_context_safely
        from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
        from pokiguard_v2.board_simulator import SwapMove
        p=direct_sword_problem();state,cfg,_,_,history,_,_=demon_packet()
        state=replace(state,board=p.board_state(),player=replace(state.player,
            hp=20000,max_hp=100000,mana=300,max_mana=300,power=120,max_power=250,attack=10000,shield=0),
            opponents=tuple(replace(a,hp=10000,max_hp=200000,mana=100,max_mana=300,power=100,max_power=250,attack=10000)
                if a.is_boss else a for a in state.opponents))
        base=BasicPolicyEngine(cfg).decide(state);expected=Action('swap',SwapMove((3,4),(3,5)))
        self.assertNotEqual(expected.move,base.move)
        value=packet(state,cfg,base,None,history,True)
        admission=CommonAdmission(policy_json(cfg),FrozenJSON.of({'swap':100,'pass':100}),FrozenJSON.of({}))
        bridge=CommonSelectionBridge(admission=admission,diagnostics=MemorySink(),enabled=True)
        try:
            now=time.perf_counter_ns();self.assertTrue(bridge.observe(state,cfg,observed_ns=now,read_end_ns=now,context=CONTEXT))
            publish_context_safely(bridge,*value)
            self.assertEqual('COMPLETED',bridge.await_decision(state,base,cfg,context=CONTEXT,stop_requested=lambda:False),bridge.preparation_reason)
            chosen=select_safely(bridge,state,base,cfg,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
            self.assertIsNotNone(chosen.receipt)
            self.assertEqual(expected,chosen.receipt.reply.proposal)
            self.assertIsNone(revalidate_safely(bridge,chosen.receipt,state,base,cfg,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT))
            self.assertIsNone(revalidate_safely(bridge,chosen.receipt,state,base,cfg,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT,final=True,final_remaining_seconds=14))
        finally:self.assertTrue(bridge.close())

    def test_worker_change_only_adds_common_summary_attribution(self):
        import ast
        from pathlib import Path
        root=Path(__file__).resolve().parents[1]
        before=ast.parse((root/'tests/fixtures/reasoning_strategy_alignment_20261103/reasoning_runner.before.py.txt').read_text('utf-8'))
        after=ast.parse((root/'src/pokiguard_v2/reasoning_runner.py').read_text('utf-8'))
        fn=next(n for n in after.body if isinstance(n,ast.FunctionDef) and n.name=='_decision_summary')
        gate=next(n for n in fn.body if isinstance(n,ast.If) and ast.unparse(n.test)=='common')
        loop=next(n for n in gate.body if isinstance(n,ast.For))
        self.assertEqual("score = by_id.get(candidate['candidate_id'])",ast.unparse(loop.body[0]))
        self.assertEqual('score is not None',ast.unparse(loop.body[1].test))
        loop.body=loop.body[2:]
        self.assertEqual(ast.dump(before,include_attributes=False),ast.dump(after,include_attributes=False))


if __name__=='__main__':unittest.main()
