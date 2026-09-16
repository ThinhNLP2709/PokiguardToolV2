"""Operator loadout intent, never runtime CardUI or input authority.

The legacy BASIC adapter is temporary plumbing for removal in Phase 3C.1.
Runtime PetSkillCapability remains the source of observed card/cost/QTE data.
"""

from __future__ import annotations

from dataclasses import dataclass, fields
from enum import Enum
from typing import Any, Mapping

from .basic_policy import Intelligence, ManaPriority, PlayStyle, PolicyConfig
from .gameplay_profile import AuditionMode, DamageCardMode, EvolutionTarget, MainPetType
from .win32_input import BoardInputMode


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
AUDITION_LABELS = {
    AuditionMode.V3_TWO_DIRECTION: "Audition V3 (2 hướng — mặc định)",
    AuditionMode.V2_FOUR_DIRECTION: "Audition V2 (4 hướng — tương thích)",
}
PLAY_STYLE_LABELS = {
    PlayStyle.SIMPLE: "simple",
    PlayStyle.CAREFUL: "careful",
    PlayStyle.SKILL_RUSH: "Chịu đấm ăn xôi",
}
SUPPORTED_MAIN_PETS = frozenset({MainPetType.NORMAL, MainPetType.LEGENDARY})
SUPPORTED_EVOLUTIONS = frozenset({
    EvolutionTarget.NONE, EvolutionTarget.NORMAL, EvolutionTarget.LEGENDARY,
})
# Phase 3C.1 policy/backend and Phase 3C.2 normal Desktop routing are integrated.
# The current V3 path remains read-only for state and uses only the accepted
# bounded foreground keyboard/mouse input boundary.
PET_SKILL_RUNTIME_ENABLED = True


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
    def desktop_policy_supported(self) -> bool:
        """Desktop and CLI share the same accepted FarmRunner profiles."""
        return self.farm_policy_supported

    @property
    def desktop_blocker_reason(self) -> str | None:
        if self.desktop_policy_supported:
            return None
        return self.blocker_reason

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
    default_runnable = (
        valid
        and main_pet is MainPetType.NORMAL
        and evolution in {EvolutionTarget.NORMAL, EvolutionTarget.NONE}
        and damage_card is DamageCardMode.DEFAULT_ATTACK
    )
    unique_main_pet_skill_runnable = (
        PET_SKILL_RUNTIME_ENABLED
        and valid
        and main_pet is MainPetType.LEGENDARY
        and evolution is EvolutionTarget.NONE
        and damage_card is DamageCardMode.PET_SKILL
        and sources == (SkillSource.MAIN_PET,)
    )
    runnable = default_runnable or unique_main_pet_skill_runnable
    reason = (
        "PET_OPTION_UNSUPPORTED" if not supported else
        "PET_SKILL_SOURCE_MISSING" if not valid else
        "PET_SKILL_SOURCE_SELECTION_UNDEFINED" if damage_card is DamageCardMode.PET_SKILL and len(sources) > 1 else
        "PET_SKILL_AUDITION_V3_NOT_IMPLEMENTED" if damage_card is DamageCardMode.PET_SKILL and not PET_SKILL_RUNTIME_ENABLED else
        "PET_SKILL_POLICY_PROFILE_NOT_IMPLEMENTED" if damage_card is DamageCardMode.PET_SKILL and not runnable else
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
    audition_mode: AuditionMode = AuditionMode.V3_TWO_DIRECTION
    board_input_mode: BoardInputMode = BoardInputMode.DRAG
    cast_when_boss_hp_below: int = 30_000
    cast_mana_stockpile: int = 480
    rage_target: int = 100

    def __post_init__(self) -> None:
        for name, enum in (("play_style", PlayStyle), ("intelligence", Intelligence),
                           ("main_pet", MainPetType), ("evolution", EvolutionTarget),
                           ("damage_card", DamageCardMode), ("audition_mode", AuditionMode),
                           ("board_input_mode", BoardInputMode)):
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

    @property
    def farm_policy_blocker_reason(self) -> str | None:
        if self.play_style is PlayStyle.SKILL_RUSH and not (
            self.main_pet is MainPetType.LEGENDARY
            and self.evolution is EvolutionTarget.NONE
            and self.damage_card is DamageCardMode.PET_SKILL
            and self.intelligence is Intelligence.BASIC
        ):
            return "SKILL_RUSH_PROFILE_NOT_IMPLEMENTED"
        if not self.capability.farm_policy_supported:
            return self.capability.blocker_reason or "FARM_PROFILE_NOT_IMPLEMENTED"
        return None

    @property
    def farm_policy_supported(self) -> bool:
        return self.farm_policy_blocker_reason is None

    def require_farm_policy(self) -> None:
        reason = self.farm_policy_blocker_reason
        if reason is not None:
            raise FarmPolicyUnavailable(reason)

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
                   audition_mode=AuditionMode(
                       raw.get("audition_mode", AuditionMode.V3_TWO_DIRECTION.value)
                   ),
                   board_input_mode=BoardInputMode(raw.get("board_input_mode", "drag")),
                   **{name: raw.get(name, getattr(cls(), name)) for name in
                      ("cast_when_boss_hp_below", "cast_mana_stockpile", "rage_target")})


def legacy_pet_fields(value: str | ManaPriority) -> dict[str, Any]:
    priority = ManaPriority(value)
    return {"main_pet": MainPetType.NORMAL,
            "evolution": EvolutionTarget.NORMAL if priority is ManaPriority.EVOLUTION else EvolutionTarget.NONE,
            "damage_card": DamageCardMode.DEFAULT_ATTACK}


def basic_policy_config(config: GameplayConfig) -> PolicyConfig:
    """Build BASIC policy from the canonical three-field gameplay profile."""
    config.require_farm_policy()
    return PolicyConfig(
        play_style=config.play_style, intelligence=config.intelligence,
        mana_priority=None,
        main_pet=config.main_pet,
        evolution=config.evolution,
        damage_card=config.damage_card,
        cast_when_boss_hp_below=config.cast_when_boss_hp_below,
        cast_mana_stockpile_threshold=config.cast_mana_stockpile,
        rage_target=config.rage_target,
    )


def requires_attack_card_preparation(config: GameplayConfig) -> bool:
    """Only ordinary-Attack profiles may mutate the pre-entry Attack loadout."""

    return config.damage_card is DamageCardMode.DEFAULT_ATTACK


def legacy_basic_policy(config: GameplayConfig) -> PolicyConfig:
    """Legacy default-Attack bridge retained for old checkpoint/test callers."""

    config.require_farm_policy()
    if config.damage_card is DamageCardMode.PET_SKILL:
        raise FarmPolicyUnavailable("LEGACY_MANA_PRIORITY_CANNOT_EXPRESS_PET_SKILL")
    return PolicyConfig(
        play_style=config.play_style,
        intelligence=config.intelligence,
        mana_priority=(
            ManaPriority.EVOLUTION
            if config.evolution is EvolutionTarget.NORMAL
            else ManaPriority.ATTACK
        ),
        cast_when_boss_hp_below=config.cast_when_boss_hp_below,
        cast_mana_stockpile_threshold=config.cast_mana_stockpile,
        rage_target=config.rage_target,
    )


def add_pet_arguments(parser: Any) -> None:
    parser.add_argument("--main-pet", choices=[v.value for v in MainPetType])
    parser.add_argument("--evolution-target", choices=[v.value for v in EvolutionTarget])
    parser.add_argument("--damage-card", choices=[v.value for v in DamageCardMode])
    parser.add_argument(
        "--audition-mode",
        choices=[v.value for v in AuditionMode],
        default=AuditionMode.V3_TWO_DIRECTION.value,
    )
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
    for name in ("play_style", "intelligence", "audition_mode", "board_input_mode", "cast_when_boss_hp_below",
                 "cast_mana_stockpile", "rage_target"):
        if hasattr(args, name):
            raw[name] = getattr(args, name)
    if legacy is not None:
        raw["mana_priority"] = legacy
    return GameplayConfig.from_dict(raw, legacy=legacy is not None)
