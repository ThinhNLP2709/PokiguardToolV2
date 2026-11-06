"""One AI intent and declared Demon objectives; synthetic data, no game IO."""
from dataclasses import replace
from pathlib import Path
import tempfile,time,unittest
from unittest.mock import Mock,patch

from pokiguard_v2.basic_policy import BasicPolicyEngine,PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_ui_scope import ui_reasoning_intent_reason,ui_reasoning_scope_reason
from pokiguard_v2.reasoning_ui_session import create_ui_reasoning_session
from pokiguard_v2.reasoning_common_evidence import build_problem,packet
from pokiguard_v2.reasoning_common_models import DEMON_TARGETS,DEMON_RAGE_REFERENCE
from pokiguard_v2.reasoning_common_planner import plan_common,CommonLimits
from pokiguard_v2.reasoning_snapshot import Action
from pokiguard_v2.state import BoardState,CellState,GemType
from tests.test_reasoning_common_models import demon_packet
from tools.evaluate_reasoning_planner import demon_board,TARGET


def demon_case(target='shield',*,swords=3,rage_cells=5,rage=0,reference=4,multiplier=1,transpose=False,outside_rage_cells=0,**options):
    state,config,*_=demon_packet(target)
    source=demon_board(swords=swords,rage_cells=rage_cells,multiplier=multiplier)
    data=tuple(tuple((target if g=='shield' else 'shield' if g==target else g,m) for g,m in row) for row in source)
    if target=='rage':
        # Activation already supplies three Rage; preserve the requested total,
        # rather than renaming Rage into Shield and assuming resource symmetry.
        data=[list(row) for row in data]
        for r,c in ((0,2),(0,3),(1,1),(1,3),(2,1))[:max(0,rage_cells-3)]:data[r][c]=('rage',1)
        data=tuple(tuple(row) for row in data)
    if outside_rage_cells:
        data=[list(row) for row in data]
        for r,c in ((0,0),(1,4),(2,5),(3,6),(4,7))[:outside_rage_cells]:data[r][c]=('rage',1)
        data=tuple(tuple(row) for row in data)
    if transpose:data=tuple(zip(*data))
    board=BoardState(tuple(tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(row)) for r,row in enumerate(data)))
    state=replace(state,board=board,player=replace(state.player,power=rage,max_power=250))
    config=replace(config,pet_skill_fire_value=reference)
    baseline=BasicPolicyEngine(config).decide(state)
    now=time.perf_counter_ns()
    problem=build_problem(packet(state,config,baseline,None,None,True),run_id='SYNTHETIC_DECLARED',
        generation=1,observed_ns=now,read_end_ns=now,**options)
    move=type(TARGET)(tuple(reversed(TARGET.first)),tuple(reversed(TARGET.second))) if transpose else TARGET
    result=plan_common(problem,CommonLimits(lookahead=False,nodes=50000))
    score=next(c for c in result.scores if c.action==Action('swap',move))
    return problem,result,score


class CommonAssistantTests(unittest.TestCase):
    def test_one_intent_for_all_styles_targets_bosses_and_thresholds(self):
        from tests.test_reasoning_ui_delivery import config
        from pokiguard_v2.gameplay_profile import DemonTargetGem
        from pokiguard_v2.pet_configuration import MainPetType,EvolutionTarget,DamageCardMode,AuditionMode,GameMode
        for style in PlayStyle:
            changes=dict(play_style=style,ai=AISettings(False,6000,True))
            if style is PlayStyle.MEGA_ICARUS_SPAM_SKILL:
                changes.update(evolution=EvolutionTarget.MEGA,damage_card=DamageCardMode.PET_SKILL,audition_mode=AuditionMode.NO_ACTION)
            if style is PlayStyle.SKILL_RUSH:
                changes.update(main_pet=MainPetType.LEGENDARY,evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_SKILL)
            if style is PlayStyle.DEMON_AEGIS_FARM:
                changes.update(evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE)
            if style is PlayStyle.BU_WIN:
                changes.update(game_mode=GameMode.COOP,evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.NONE)
            cfg=replace(DesktopConfig(),**changes)
            self.assertIsNone(ui_reasoning_intent_reason(cfg))
        for target in DEMON_TARGETS:
            cfg=config(demon_target_gem=DemonTargetGem(target),pet_skill_fire_value=3,boss_id='99999')
            self.assertIsNone(ui_reasoning_intent_reason(cfg))
            self.assertIsNotNone(ui_reasoning_scope_reason(cfg,require_target=True))

    def test_missing_runtime_proof_preserves_basic_without_allocating_worker(self):
        events=[]
        paths=Mock(data_root=Path('never_created_common_test'))
        with patch('pokiguard_v2.reasoning_ui_profile.load_session_authority',
                side_effect=ValueError('UI_REASONING_COMMON_CALIBRATION_REQUIRED')) as loader:
            result=create_ui_reasoning_session(replace(DesktopConfig(),ai=AISettings(False,4000,True)),
                paths=paths,game_executable=None,directory=Path('never_created_common_test'),
                observer=lambda status,*_:events.append(status))
        self.assertIsNone(result);loader.assert_called_once()
        self.assertEqual('UI_REASONING_COMMON_CALIBRATION_REQUIRED',events[0].reason)
        self.assertFalse(Path('never_created_common_test').exists())

    def test_same_burst_uses_the_actual_configured_target_for_both_orientations(self):
        for target in DEMON_TARGETS:
            for transpose in (False,True):
                problem,result,score=demon_case(target,transpose=transpose)
                d=score.details.plain()
                self.assertEqual(3,d['nominal_sword_reference'],(target,transpose,d))
                self.assertEqual(5,d['passive_rage_effective'])
                self.assertEqual('USER_DECLARED_NOMINAL_REFERENCE_ONLY',d['same_burst_rage_sufficiency'])
                self.assertFalse(d['automatic_kill_claim'])
                self.assertEqual(DEMON_RAGE_REFERENCE.plain(),d['strategy_provenance']['rage_reference'])
                self.assertEqual(dict(mana=30,rage=20),problem.facts.plain()['conversion'])
                self.assertFalse(result.to_dict()['input_authority'])

    def test_existing_rage_multipliers_and_two_physical_sword_floor(self):
        for target in DEMON_TARGETS:
            for rage,count,reference,expected in ((100,0,4,3),(0,4,4,4),(20,4,4,3),(100,0,3,2)):
                _,_,score=demon_case(target,rage=rage,rage_cells=count,reference=reference)
                self.assertEqual(expected,score.details.plain()['nominal_sword_reference'])
            for multiplier in (2,3):
                _,_,score=demon_case(target,swords=2,multiplier=multiplier,rage_cells=0)
                self.assertEqual(2*multiplier,score.details.plain()['passive_sword_effective'])
            _,_,score=demon_case(target,swords=1,multiplier=3,rage=100,rage_cells=0,reference=3)
            self.assertEqual(0,dict(score.features)['F'].low)
            self.assertIsNone(score.details.plain()['nominal_sword_reference'])

    def test_explicit_missing_rates_or_discount_keep_nominal_goal(self):
        for options in (dict(conversion={}),dict(operator_demon_rage_discount=None)):
            _,_,score=demon_case(**options)
            self.assertEqual(4,score.details.plain()['nominal_sword_reference'])
            self.assertNotEqual('USER_DECLARED_NOMINAL_REFERENCE_ONLY',score.details.plain()['same_burst_rage_sufficiency'])

    def test_rage_elsewhere_on_board_is_not_available_in_this_passive_sweep(self):
        for target in DEMON_TARGETS:
            _,_,score=demon_case(target,rage_cells=0,outside_rage_cells=5)
            details=score.details.plain()
            self.assertEqual(4,details['nominal_sword_reference'])
            self.assertLess(details['passive_rage_effective']*20,100)

    def test_dinosaur_uses_the_same_optional_session_and_basic_fallback(self):
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager,ControllerLaunch
        from pokiguard_v2.win32_input import FarmControlHotkeyEdges
        with tempfile.TemporaryDirectory() as temp:
            cfg=replace(DesktopConfig(play_style=PlayStyle.DINOSAUR),ai=AISettings(False,4000,True))
            manager=DesktopFarmControllerManager(Path(temp),runner=lambda *_:0)
            session=Mock();manager._reasoning_session_factory=Mock(return_value=session)
            with patch('tools.dinosaur_run.run',return_value=5) as run:
                self.assertEqual(5,manager._run_production(ControllerLaunch(cfg,None),FarmControlHotkeyEdges(),Mock()))
                self.assertIs(session,run.call_args.kwargs['reasoning_session']);session.stop.assert_called_once()
            manager._reasoning_session_factory=Mock(side_effect=ValueError('synthetic setup'))
            with patch('tools.dinosaur_run.run',return_value=6) as run:
                self.assertEqual(6,manager._run_production(ControllerLaunch(cfg,None),FarmControlHotkeyEdges(),Mock()))
                self.assertNotIn('reasoning_session',run.call_args.kwargs)


if __name__=='__main__':unittest.main()
