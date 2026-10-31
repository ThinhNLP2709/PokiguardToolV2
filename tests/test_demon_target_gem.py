"""Demon Farm target selection across geometry, config and runtime plumbing."""
from dataclasses import replace
import json
from pathlib import Path
import hashlib
import importlib.util
import sys
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction, PlayStyle
from pokiguard_v2.board_simulator import evaluate_all_moves, simulate_move
from pokiguard_v2.boss_entry import FarmTarget
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.farm_checkpoint import load_checkpoint, write_checkpoint
from pokiguard_v2.farm_run import FarmRun
from pokiguard_v2.gameplay_profile import DemonTargetGem
from pokiguard_v2.pet_configuration import (
    DEMON_TARGET_GEM_LABELS, PLAY_STYLE_LABELS, GameplayConfig,
    basic_policy_config, gameplay_config_from_args,
)
from pokiguard_v2.state import BoardState, GemType
from tests.test_basic_policy import combat_state
from tests.test_demon_aegis_farm import (
    TARGET_MOVE, VERTICAL_TARGET_MOVE, demon_policy, passive_board,
    vertical_passive_board,
)
from tests.test_board_simulator import fixture_board
from tools.farm_run import build_parser
from tools.farm_cycle import _combat_args
from tools.basic_auto_bot import build_parser as combat_parser


def relabel(board, target):
    """Bijective relabel: preserve all geometry, Sword and multiplier identities."""
    if target is GemType.SHIELD:
        return board
    return BoardState(tuple(tuple(replace(cell, gem=(
        target if cell.gem is GemType.SHIELD else
        GemType.SHIELD if cell.gem is target else cell.gem
    )) for cell in row) for row in board.cells))


def config(target=DemonTargetGem.SHIELD):
    return GameplayConfig.from_dict({
        **GameplayConfig().to_dict(), 'play_style':'demon_aegis_farm',
        'main_pet':'normal', 'evolution':'none', 'damage_card':'pet_passive',
        'pet_skill_fire_value':3, 'demon_target_gem':target.value,
    })


class DemonTargetGemTests(unittest.TestCase):
    def test_production_desktop_adapter_forwards_target_to_farm_and_combat(self):
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, ControllerLaunch
        from pokiguard_v2.win32_input import FarmControlHotkeyEdges
        with tempfile.TemporaryDirectory() as folder:
            manager=DesktopFarmControllerManager(Path(folder))
            for target in DemonTargetGem:
                c=replace(DesktopConfig().with_gameplay_config(config(target)),boss_id='1436')
                with patch('tools.farm_run.run',return_value=0) as run:
                    code=manager._run_production(ControllerLaunch(c,None),FarmControlHotkeyEdges(),lambda *a:None)
                self.assertEqual(code,0)
                args=run.call_args.args[0]
                self.assertEqual(args.demon_target_gem,target.value)
                self.assertEqual(_combat_args(args,Path('unused.jsonl')).demon_target_gem,target.value)

    def test_real_calibration_decoder_rejects_old_request_and_scoped_gates_refuse_other_targets(self):
        from pokiguard_v2.reasoning_calibration import decode_config, check_config, D3_CONTROL_PROTOCOL
        from pokiguard_v2.reasoning_demon_native import check_config as check_demon
        from pokiguard_v2.reasoning_comparison import check_config as check_e1
        root=Path(__file__).resolve().parents[1]
        raw=json.loads((root/'docs/phase5/artifacts/5d3_lieyun_basic3_live_20261018_021056/request.json').read_text('utf-8'))['config']
        with self.assertRaises(ValueError):decode_config(raw)
        current=decode_config(dict(raw,demon_target_gem='shield'))
        check_config(current,3,profile_protocol=D3_CONTROL_PROTOCOL)
        check_demon(current)
        e1=replace(current,target_completed_matches=20,max_match_attempts=20,max_technical_recoveries=0)
        check_e1(e1)
        for target in tuple(DemonTargetGem)[1:]:
            with self.subTest(target=target):
                with self.assertRaises(ValueError):check_config(replace(current,demon_target_gem=target),3,profile_protocol=D3_CONTROL_PROTOCOL)
                with self.assertRaises(ValueError):check_demon(replace(current,demon_target_gem=target))
                with self.assertRaises(ValueError):check_e1(replace(e1,demon_target_gem=target))

    def test_historical_target_change_preserved_default_shield_policy(self):
        root=Path(__file__).resolve().parents[1]
        from tests.game_update_fixture import archived_demon_engine
        for board in (passive_board(),vertical_passive_board(),fixture_board()):
            for threshold in (3,4):
                for hp in (None,20,100):
                    state=combat_state(board=board)
                    state=replace(state,player=replace(state.player,hp=hp))
                    c=basic_policy_config(replace(config(),pet_skill_fire_value=threshold))
                    a=archived_demon_engine(root,'demon_effective_sword_20261022',c).decide(state)
                    b=archived_demon_engine(root,'demon_target_gem_20261022',c).decide(state)
                    self.assertEqual((a.action.value,a.move,a.trace.policy_step),
                        (b.action.value,b.move,b.trace.policy_step),(threshold,hp))

    def test_shadow_planner_geometry_uses_target_and_old_live_certificates_refuse_it(self):
        from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON
        from pokiguard_v2.reasoning_planner import plan
        from pokiguard_v2.reasoning_demon import plan_demon
        from tests.test_reasoning_demon import fixture
        from tools.evaluate_reasoning_planner import snapshot
        for target in DemonTargetGem:
            board=relabel(passive_board(),GemType(target.value))
            data=tuple(tuple((c.gem.value,c.multiplier) for c in row) for row in board.cells)
            s=snapshot(profile='demon_aegis_farm',board=data,baseline=Action('swap',TARGET_MOVE))
            s=replace(s,intent=replace(s.intent,settings=FrozenJSON.of({
                **s.intent.settings.plain(),'demon_target_gem':target.value})))
            score=next(c for c in plan(s).scores if c.action.move==TARGET_MOVE)
            self.assertEqual(score.details.plain()['ledger']['passive_swords'],{'physical':3,'effective':6})
        _,_,_,_,s=fixture()
        for target in tuple(DemonTargetGem)[1:]:
            changed=replace(s,intent=replace(s.intent,settings=FrozenJSON.of({
                **s.intent.settings.plain(),'demon_target_gem':target.value})))
            with self.assertRaisesRegex(ValueError,'Shield target only'):
                plan_demon(changed)

    def test_exact_five_choices_and_stable_profile_identity(self):
        self.assertEqual(PLAY_STYLE_LABELS[PlayStyle.DEMON_AEGIS_FARM], 'Demon Farm')
        self.assertEqual(tuple(DEMON_TARGET_GEM_LABELS.values()), ('Khiên','Máu','Mana','Hút','Nộ'))
        for bad in ('sword','unknown','',None,1):
            with self.subTest(bad=bad), self.assertRaises(ValueError):
                DemonTargetGem(bad)

    def test_all_targets_horizontal_and_vertical_blast_keep_sword_multipliers(self):
        for target in DemonTargetGem:
            gem=GemType(target.value)
            for original,move in ((passive_board(),TARGET_MOVE),
                                  (vertical_passive_board(),VERTICAL_TARGET_MOVE)):
                with self.subTest(target=target,move=move):
                    board=relabel(original,gem)
                    expected=evaluate_demon_aegis_move(original,simulate_move(original,move),include_next_turn=False)
                    actual=evaluate_demon_aegis_move(board,simulate_move(board,move),target_gem=gem,include_next_turn=False)
                    self.assertEqual(actual,expected)
                    self.assertEqual(len(actual.blast_cells),24)
                    self.assertEqual(actual.sword_cells,3)
                    if gem is not GemType.SHIELD:
                        wrong=evaluate_demon_aegis_move(board,simulate_move(board,move),include_next_turn=False)
                        self.assertFalse(wrong.activates_passive)

    def test_policy_fires_selected_target_with_effective_sword_threshold(self):
        for target in DemonTargetGem:
            with self.subTest(target=target):
                board=relabel(passive_board(),GemType(target.value))
                c=basic_policy_config(config(target))
                result=BasicPolicyEngine(c).decide(combat_state(board=board))
                self.assertEqual((result.action,result.move,result.trace.policy_step),
                    (PolicyAction.SWAP,TARGET_MOVE,'DEMON_AEGIS_PASSIVE_FIRE'))
                self.assertIn('targetGem='+target.value,result.trace.why_selected)
                # Three physical Swords, effective six: BASIC meets setting4.
                result=BasicPolicyEngine(replace(c,pet_skill_fire_value=4)).decide(combat_state(board=board))
                self.assertEqual(result.trace.policy_step,'DEMON_AEGIS_PASSIVE_FIRE')

    def test_setup_forecast_uses_selected_target(self):
        original=passive_board()
        for target in DemonTargetGem:
            board=relabel(original,GemType(target.value))
            for value in evaluate_all_moves(original):
                if value.total.cells(GemType.SWORD):
                    continue
                expected=evaluate_demon_aegis_move(original,value)
                actual=evaluate_demon_aegis_move(board,simulate_move(board,value.move),target_gem=GemType(target.value))
                self.assertEqual(actual,expected,(target,value.move))

    def test_geometry_rejects_sword_unknown_and_untyped_target(self):
        board=passive_board(); value=simulate_move(board,TARGET_MOVE)
        for bad in (GemType.SWORD,GemType.UNKNOWN,'mana',None):
            with self.subTest(bad=bad), self.assertRaises(ValueError):
                evaluate_demon_aegis_move(board,value,target_gem=bad)

    def test_legacy_preferences_default_shield_and_new_choice_roundtrips(self):
        with tempfile.TemporaryDirectory() as folder:
            store=DesktopPreferenceStore(Path(folder)/'preferences.json')
            for target in DemonTargetGem:
                c=DesktopConfig().with_gameplay_config(config(target))
                store.save(c)
                self.assertEqual(store.load().config.gameplay_config,c.gameplay_config)
            raw=json.loads(store.path.read_text('utf-8')); raw['config'].pop('demon_target_gem')
            store.path.write_text(json.dumps(raw),encoding='utf-8')
            self.assertIs(store.load().config.demon_target_gem,DemonTargetGem.SHIELD)
            raw['config']['demon_target_gem']='sword'
            store.path.write_text(json.dumps(raw),encoding='utf-8')
            self.assertFalse(store.load().loaded)

    def test_cli_to_combat_to_policy_carries_each_choice(self):
        for target in DemonTargetGem:
            args=build_parser().parse_args(['--stage-b2-farm','--play-style','demon_aegis_farm',
                '--main-pet','normal','--evolution-target','none','--damage-card','pet_passive',
                '--demon-target-gem',target.value,'--pet-skill-fire-value','3'])
            c=gameplay_config_from_args(args)
            self.assertIs(c.demon_target_gem,target)
            combat=_combat_args(args,Path('unused.jsonl'))
            self.assertEqual(combat.demon_target_gem,target.value)
            combat_config=GameplayConfig.from_dict({**c.to_dict(),'demon_target_gem':combat.demon_target_gem})
            self.assertIs(basic_policy_config(combat_config).demon_target_gem,target)
            self.assertEqual(combat_parser().parse_args(['--watch','--reset-evidence','unused.json',
                '--demon-target-gem',target.value]).demon_target_gem,target.value)

    def test_checkpoint_keeps_target_and_missing_legacy_field_defaults_shield(self):
        with tempfile.TemporaryDirectory() as folder:
            path=Path(folder)/'checkpoint.json'
            for target in DemonTargetGem:
                run=FarmRun(FarmTarget('1436','Lieyun'),gameplay_config=config(target))
                write_checkpoint(path,run.checkpoint_payload())
                self.assertEqual(load_checkpoint(path).gameplay_config,config(target))
            raw=json.loads(path.read_text('utf-8')); raw['gameplay_config'].pop('demon_target_gem')
            path.write_text(json.dumps(raw),encoding='utf-8')
            self.assertIs(load_checkpoint(path).gameplay_config.demon_target_gem,DemonTargetGem.SHIELD)
