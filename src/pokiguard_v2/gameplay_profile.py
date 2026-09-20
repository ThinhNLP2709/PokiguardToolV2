"""Canonical operator-selected Pet/loadout profile values.

This small module is intentionally independent of policy and runtime readers so
configuration, policy, and FarmRunner can share the same enum identities without
creating import cycles.
"""

from __future__ import annotations

from enum import Enum


class MainPetType(str, Enum):
    NORMAL = "normal"
    LEGENDARY = "legendary"
    EVOLVED = "evolved"
    MEGA = "mega"


class EvolutionTarget(str, Enum):
    NONE = "none"
    NORMAL = "normal"
    LEGENDARY = "legendary"
    EVOLVED = "evolved"
    MEGA = "mega"


class DamageCardMode(str, Enum):
    DEFAULT_ATTACK = "default_attack"
    PET_SKILL = "pet_skill"


class PetSkillFireCondition(str, Enum):
    """Stable machine identity for the normal Pet Skill fire condition."""

    SKILL_COST_READY = "skill_cost_ready"
    SWORD_COUNT = "sword_count"
    MANA_GEM_COUNT = "mana_gem_count"
    RAGE_GEM_COUNT = "rage_gem_count"
    DRAIN_GEM_COUNT = "drain_gem_count"
    SHIELD_GEM_COUNT = "shield_gem_count"

    @property
    def uses_board_count(self) -> bool:
        return self is not PetSkillFireCondition.SKILL_COST_READY


class AuditionMode(str, Enum):
    """Operator-selected Pet Skill QTE generation.

    V3 is the current two-direction ``LR`` protocol.  V2 keeps the accepted
    four-direction CardUI observer available as an explicit compatibility
    choice; one action never mixes fields from the two generations.
    """

    V3_TWO_DIRECTION = "audition_v3"
    V2_FOUR_DIRECTION = "audition_v2"


__all__ = [
    "AuditionMode",
    "DamageCardMode",
    "EvolutionTarget",
    "MainPetType",
    "PetSkillFireCondition",
]
