"""Prepare the D2 BASIC3 control request from files only; never starts a game.

This is observation authority, not Skill Rush reasoning activation. Runtime
Pet Skill capability/costs and the existing QTE/turn owner remain authoritative.
"""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
from pokiguard_v2.basic_policy import Intelligence, PlayStyle
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import (
    DamageCardMode, EvolutionTarget, GameMode, MainPetType, PetSkillFireCondition,
)
from pokiguard_v2.reasoning_calibration import (
    build_request, D2_CONTROL_PROTOCOL, D2_TIMING_PROTOCOL,
)
from pokiguard_v2.reasoning_settings import AISettings


def prepare(preferences, game, boss_id, boss_name, out, *, fire_value=7, timing_probe=False):
    out = out.resolve()
    if not out.is_relative_to(ROOT) or out.exists():
        raise ValueError('fresh output inside V2 required')
    loaded = DesktopPreferenceStore(preferences).load()
    if not loaded.loaded or loaded.warnings:
        raise ValueError('valid existing preferences required')
    cap = 1 if timing_probe else 3
    config = replace(loaded.config, play_style=PlayStyle.SKILL_RUSH,
        intelligence=Intelligence.BASIC, ai=AISettings(False, 4000),
        game_mode=GameMode.SOLO, main_pet=MainPetType.LEGENDARY,
        evolution=EvolutionTarget.NONE, damage_card=DamageCardMode.PET_SKILL,
        pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,
        pet_skill_fire_value=fire_value, target_completed_matches=cap, max_match_attempts=cap,
        max_technical_recoveries=1, boss_id=boss_id, boss_name=boss_name,
        input_delivery_mode=type(loaded.config.input_delivery_mode)('foreground'),
        board_input_mode=type(loaded.config.board_input_mode)('two_click'))
    request = build_request(ROOT, config, game,
        cohort='D2_SKILL_RUSH_HT7_SKILL_TIMING1' if timing_probe else 'D2_SKILL_RUSH_HT7_BASIC3_CONTROL',
        profile_protocol=D2_TIMING_PROTOCOL if timing_probe else D2_CONTROL_PROTOCOL)
    out.parent.mkdir(parents=True, exist_ok=True)
    with out.open('x', encoding='utf-8') as stream:
        json.dump(request, stream, ensure_ascii=False, indent=2)
        stream.write('\n')
    return request


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    for name in ('preferences', 'out'):
        parser.add_argument('--' + name, type=Path, required=True)
    for name in ('game', 'boss-id', 'boss-name'):
        parser.add_argument('--' + name, required=True)
    parser.add_argument('--fire-value', type=int, default=7)
    parser.add_argument('--timing-probe', action='store_true')
    args = parser.parse_args()
    prepare(args.preferences, args.game, args.boss_id, args.boss_name, args.out,
        fire_value=args.fire_value, timing_probe=args.timing_probe)
    print(json.dumps(dict(request_created=True, reasoning_enabled=False,
        claim_created=False, automatic_start=False,
        sha256=hashlib.sha256(args.out.read_bytes()).hexdigest())))


if __name__ == '__main__':
    main()
