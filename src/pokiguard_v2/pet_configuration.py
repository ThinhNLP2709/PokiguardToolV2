"""Operator loadout intent, never runtime CardUI or input authority.

The legacy BASIC adapter is temporary plumbing for removal in Phase 3C.1.
Runtime PetSkillCapability remains the source of observed card/cost/QTE data.
"""

from __future__ import annotations

from dataclasses import dataclass, fields
from enum import Enum
from typing import Any, Mapping

from .basic_policy import Intelligence, ManaPriority, PlayStyle, PolicyConfig
from .win32_input import BoardInputMode


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


class SkillSource(str, Enum):
    MAIN_PET = "main_pet"
    EVOLUTION_TARGET = "evolution_target"


class SkillSourceStatus(str, Enum):
    NO_SKILL = "no_skill"
    MAIN_PET_SKILL = "main_pet_skill"
    EVOLUTION_TARGET_SKILL = "evolution_target_skill"
    MULTIPLE_SKILL_SOURCES = "multiple_skill_sources"
    UNKNOWN = "unknown"


MAIN_PET_LABELS = {
    MainPetType.NORMAL: "Pet thường", MainPetType.LEGENDARY: "Huyền thoại",
    MainPetType.EVOLVED: "Tiến hóa", MainPetType.MEGA: "Mega",
}
EVOLUTION_LABELS = {
    EvolutionTarget.NONE: "Không tiến hóa",
    EvolutionTarget.NORMAL: "Tiến hóa pet thường",
    EvolutionTarget.LEGENDARY: "Tiến hóa pet huyền thoại",
    EvolutionTarget.EVOLVED: "Tiến hóa pet tiến hóa",
    EvolutionTarget.MEGA: "Tiến hóa pet Mega",
}
DAMAGE_LABELS = {
    DamageCardMode.DEFAULT_ATTACK: "Thẻ chưởng mặc định",
    DamageCardMode.PET_SKILL: "Thẻ skill của pet",
}
SUPPORTED_MAIN_PETS = frozenset({MainPetType.NORMAL, MainPetType.LEGENDARY})
SUPPORTED_EVOLUTIONS = frozenset({
    EvolutionTarget.NONE, EvolutionTarget.NORMAL, EvolutionTarget.LEGENDARY,
})


class FarmPolicyUnavailable(ValueError):
    """A valid staged profile has no accepted gameplay integration yet."""

    def __init__(self, reason: str) -> None:
        self.reason = reason
        super().__init__(reason)


@dataclass(frozen=True)
class PetLoadoutCapability:
    main_pet: MainPetType
    evolution: EvolutionTarget
    skill_sources: tuple[SkillSource, ...]
    source_status: SkillSourceStatus
    option_supported: bool
    config_valid: bool
    pet_skill_selectable: bool
    farm_policy_supported: bool
    blocker_reason: str | None

    @property
    def skill_source_count(self) -> int:
        return len(self.skill_sources)

    @property
    def multiple_skill_sources(self) -> bool:
        return len(self.skill_sources) > 1


def loadout_capability(
    main_pet: MainPetType,
    evolution: EvolutionTarget,
    damage_card: DamageCardMode = DamageCardMode.DEFAULT_ATTACK,
) -> PetLoadoutCapability:
    main_pet, evolution, damage_card = (
        MainPetType(main_pet), EvolutionTarget(evolution), DamageCardMode(damage_card)
    )
    sources = tuple(source for present, source in (
        (main_pet is MainPetType.LEGENDARY, SkillSource.MAIN_PET),
        (evolution is EvolutionTarget.LEGENDARY, SkillSource.EVOLUTION_TARGET),
    ) if present)
    supported = main_pet in SUPPORTED_MAIN_PETS and evolution in SUPPORTED_EVOLUTIONS
    status = (
        SkillSourceStatus.UNKNOWN if not supported else
        SkillSourceStatus.MULTIPLE_SKILL_SOURCES if len(sources) > 1 else
        SkillSourceStatus.MAIN_PET_SKILL if sources == (SkillSource.MAIN_PET,) else
        SkillSourceStatus.EVOLUTION_TARGET_SKILL if sources else
        SkillSourceStatus.NO_SKILL
    )
    selectable = supported and bool(sources)
    valid = supported and (damage_card is DamageCardMode.DEFAULT_ATTACK or selectable)
    runnable = valid and main_pet is MainPetType.NORMAL and evolution in {
        EvolutionTarget.NORMAL, EvolutionTarget.NONE,
    } and damage_card is DamageCardMode.DEFAULT_ATTACK
    reason = (
        "PET_OPTION_UNSUPPORTED" if not supported else
        "PET_SKILL_SOURCE_MISSING" if not valid else
        "PET_SKILL_SOURCE_SELECTION_UNDEFINED" if damage_card is DamageCardMode.PET_SKILL and len(sources) > 1 else
        "PET_SKILL_POLICY_NOT_IMPLEMENTED" if damage_card is DamageCardMode.PET_SKILL else
        "FARM_PROFILE_NOT_IMPLEMENTED" if not runnable else None
    )
    return PetLoadoutCapability(main_pet, evolution, sources, status, supported,
                                valid, selectable, runnable, reason)


def normalize_damage(main_pet: MainPetType, evolution: EvolutionTarget,
                     damage_card: DamageCardMode) -> DamageCardMode:
    """UI-only normalization after an operator changes Pet/Evolution."""
    return (DamageCardMode(damage_card) if loadout_capability(main_pet, evolution).pet_skill_selectable
            else DamageCardMode.DEFAULT_ATTACK)


@dataclass(frozen=True)
class GameplayConfig:
    play_style: PlayStyle = PlayStyle.SIMPLE
    intelligence: Intelligence = Intelligence.BASIC
    main_pet: MainPetType = MainPetType.NORMAL
    evolution: EvolutionTarget = EvolutionTarget.NORMAL
    damage_card: DamageCardMode = DamageCardMode.DEFAULT_ATTACK
    board_input_mode: BoardInputMode = BoardInputMode.DRAG
    cast_when_boss_hp_below: int = 30_000
    cast_mana_stockpile: int = 480
    rage_target: int = 100

    def __post_init__(self) -> None:
        for name, enum in (("play_style", PlayStyle), ("intelligence", Intelligence),
                           ("main_pet", MainPetType), ("evolution", EvolutionTarget),
                           ("damage_card", DamageCardMode), ("board_input_mode", BoardInputMode)):
            if not isinstance(getattr(self, name), enum):
                raise ValueError(f"{name} must be {enum.__name__}")
        if self.intelligence is not Intelligence.BASIC:
            raise ValueError("REASONING is not implemented")
        if not self.capability.config_valid:
            raise ValueError(self.capability.blocker_reason)
        for name in ("cast_when_boss_hp_below", "cast_mana_stockpile", "rage_target"):
            value = getattr(self, name)
            if type(value) is not int or value < 0:
                raise ValueError(f"{name} must be a nonnegative integer")

    @property
    def capability(self) -> PetLoadoutCapability:
        return loadout_capability(self.main_pet, self.evolution, self.damage_card)

    def require_farm_policy(self) -> None:
        if not self.capability.farm_policy_supported:
            raise FarmPolicyUnavailable(self.capability.blocker_reason or "FARM_PROFILE_NOT_IMPLEMENTED")

    def to_dict(self) -> dict[str, Any]:
        return {f.name: (value.value if isinstance(value, Enum) else value)
                for f in fields(GameplayConfig) for value in (getattr(self, f.name),)}

    @classmethod
    def from_dict(cls, raw: Mapping[str, Any], *, legacy: bool = False) -> GameplayConfig:
        if not isinstance(raw, dict):
            raise ValueError("gameplay configuration must be an object")
        if legacy:
            # Explicit legacy schema: never infer Pet Skill from old fields.
            pet_fields = legacy_pet_fields(raw["mana_priority"])
        else:
            # Canonical schema requires all three; stale legacy keys cannot win.
            pet_fields = {"main_pet": MainPetType(raw["main_pet"]),
                          "evolution": EvolutionTarget(raw["evolution"]),
                          "damage_card": DamageCardMode(raw["damage_card"])}
        return cls(**pet_fields, play_style=PlayStyle(raw.get("play_style", "simple")),
                   intelligence=Intelligence(raw.get("intelligence", "basic")),
                   board_input_mode=BoardInputMode(raw.get("board_input_mode", "drag")),
                   **{name: raw.get(name, getattr(cls(), name)) for name in
                      ("cast_when_boss_hp_below", "cast_mana_stockpile", "rage_target")})


def legacy_pet_fields(value: str | ManaPriority) -> dict[str, Any]:
    priority = ManaPriority(value)
    return {"main_pet": MainPetType.NORMAL,
            "evolution": EvolutionTarget.NORMAL if priority is ManaPriority.EVOLUTION else EvolutionTarget.NONE,
            "damage_card": DamageCardMode.DEFAULT_ATTACK}


def legacy_basic_policy(config: GameplayConfig) -> PolicyConfig:
    """Temporary Phase 3A.2 adapter; remove when Phase 3C.1 is accepted."""
    config.require_farm_policy()
    return PolicyConfig(
        play_style=config.play_style, intelligence=config.intelligence,
        mana_priority=(ManaPriority.EVOLUTION if config.evolution is EvolutionTarget.NORMAL else ManaPriority.ATTACK),
        cast_when_boss_hp_below=config.cast_when_boss_hp_below,
        cast_mana_stockpile_threshold=config.cast_mana_stockpile,
        rage_target=config.rage_target,
    )


def add_pet_arguments(parser: Any) -> None:
    parser.add_argument("--main-pet", choices=[v.value for v in MainPetType])
    parser.add_argument("--evolution-target", choices=[v.value for v in EvolutionTarget])
    parser.add_argument("--damage-card", choices=[v.value for v in DamageCardMode])
    parser.add_argument("--mana-priority", choices=[v.value for v in ManaPriority],
                        help="deprecated compatibility alias; cannot be combined with Pet flags")


def gameplay_config_from_args(args: Any) -> GameplayConfig:
    legacy = getattr(args, "mana_priority", None)
    new = {"main_pet": getattr(args, "main_pet", None),
           "evolution": getattr(args, "evolution_target", None),
           "damage_card": getattr(args, "damage_card", None)}
    if legacy is not None and any(value is not None for value in new.values()):
        raise ValueError("--mana-priority conflicts with canonical Pet flags")
    raw = GameplayConfig().to_dict()
    raw.update({k: v for k, v in new.items() if v is not None})
    for name in ("play_style", "intelligence", "board_input_mode", "cast_when_boss_hp_below",
                 "cast_mana_stockpile", "rage_target"):
        if hasattr(args, name):
            raw[name] = getattr(args, name)
    if legacy is not None:
        raw["mana_priority"] = legacy
    return GameplayConfig.from_dict(raw, legacy=legacy is not None)
