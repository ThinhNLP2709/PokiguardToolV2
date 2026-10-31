"""Uncached P26 projection for the separately reviewed successor collector.

No loader creates this authority yet: native timing source binding is pending.
Legacy operational authorities cannot opt in by adding a request field.
"""
from dataclasses import fields

from .basic_policy import PolicyConfig, PlayStyle, ManaPriority, Intelligence
from .gameplay_profile import (
    MainPetType, EvolutionTarget, DamageCardMode, PetSkillFireCondition, DemonTargetGem,
)
from .board_diagnostics import jsonable

VERSION = "UNCACHED_POLICY_CONFIG_PROJECTION_V1"
EXPECTED_FIELDS = (
    'play_style', 'mana_priority', 'intelligence', 'main_pet', 'evolution',
    'damage_card', 'minimum_turn_time_seconds', 'minimum_evolve_time_seconds',
    'cast_when_boss_hp_below', 'cast_mana_stockpile_threshold', 'rage_target',
    'low_hp_ratio_simple', 'low_hp_ratio_careful', 'boss_high_mana',
    'boss_high_rage', 'boss_low_resource', 'pet_skill_fire_condition',
    'pet_skill_fire_value', 'demon_target_gem',
)
ENUM_TYPES = (
    PlayStyle, ManaPriority, Intelligence, MainPetType, EvolutionTarget,
    DamageCardMode, PetSkillFireCondition, DemonTargetGem,
)
SCALAR_TYPES = (str, int, bool, float, type(None))


def project_config(config):
    if type(config) is not PolicyConfig:
        return jsonable(config)
    current_fields = fields(config)
    if tuple(field.name for field in current_fields) != EXPECTED_FIELDS:
        return jsonable(config)
    result = {}
    for field in current_fields:
        value = getattr(config, field.name)
        value_type = type(value)
        if value_type in ENUM_TYPES:
            value = value.value
            if type(value) not in SCALAR_TYPES:
                return jsonable(config)
        elif value_type not in SCALAR_TYPES:
            return jsonable(config)
        result[field.name] = value
    return result
