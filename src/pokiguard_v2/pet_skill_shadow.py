"""Production read-only Pet Skill/QTE shadow primitives.

The low-level IL2CPP decoders live in :mod:`pokiguard_v2.pet_qte_observer`.
This module deliberately sits above them: it turns current-session evidence
into immutable capability and QTE snapshots without importing any Windows
input implementation or granting gameplay authority.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum
import math
from typing import Iterable

from .combat_cards import CardDataState
from .pet_qte_observer import (
    BoundQteObservation,
    CardUiQteSnapshot,
    PetSkillSnapshot,
    QteBindingStatus,
    QteGenerationIdentity,
    QteResponseCorrelation,
)
from .state import CardState, CombatSessionKey


class PetSkillCapabilityStatus(str, Enum):
    NO_CAPABILITY = "NO_CAPABILITY"
    METADATA_ONLY = "METADATA_ONLY"
    CURRENT = "CURRENT"
    STALE = "STALE"
    AMBIGUOUS = "AMBIGUOUS"
    INVALID = "INVALID"


class PetSkillCostSource(str, Enum):
    CONDITION_USE = "CONDITION_USE"
    MANA_COST = "MANA_COST"
    POWER = "POWER"
    POWER_COST = "POWER_COST"
    FAMILY_RULE = "FAMILY_RULE"
    UNKNOWN = "UNKNOWN"


class PetSkillFamily(str, Enum):
    AUTOMATIC_DOT_DESTRUCTION = "AUTOMATIC_DOT_DESTRUCTION"
    DOT_QTE_OTHER = "DOT_QTE_OTHER"
    UNKNOWN = "UNKNOWN"


class PetSkillTargetMode(str, Enum):
    AUTOMATIC = "AUTOMATIC"
    UNKNOWN = "UNKNOWN"


class QteDirection(str, Enum):
    UP = "UP"
    DOWN = "DOWN"
    LEFT = "LEFT"
    RIGHT = "RIGHT"
    UNKNOWN = "UNKNOWN"


class QteTimingRegion(str, Enum):
    BEFORE_PERFECT = "BEFORE_PERFECT"
    INSIDE_PERFECT = "INSIDE_PERFECT"
    AFTER_PERFECT = "AFTER_PERFECT"
    UNKNOWN = "UNKNOWN"


class QteTimingResult(str, Enum):
    PERFECT = "PERFECT"
    GOOD = "GOOD"
    BAD = "BAD"
    UNKNOWN = "UNKNOWN"


class QteEvidenceStatus(str, Enum):
    CURRENT = "CURRENT"
    INACTIVE = "INACTIVE"
    STALE = "STALE"
    AMBIGUOUS = "AMBIGUOUS"
    UNKNOWN = "UNKNOWN"


class DeltaVerification(str, Enum):
    AGREES = "AGREES"
    MISMATCH = "MISMATCH"
    AMBIGUOUS = "AMBIGUOUS"
    UNKNOWN = "UNKNOWN"


@dataclass(frozen=True)
class PetSkillCostResolution:
    effective_mana_cost: int | None
    effective_mana_cost_source: PetSkillCostSource
    effective_power_cost: int | None
    effective_power_cost_source: PetSkillCostSource
    evidence: tuple[str, ...] = ()


@dataclass(frozen=True)
class LivePetSkillCard:
    """One candidate tied to a proven combat session.

    ``button_validated`` means that the read-only decoder validated the Unity
    Button/component.  It is observation evidence only, never permission to
    click the card.
    """

    session_key: CombatSessionKey
    card_data: CardDataState
    card_ui_address: int | None
    board_instance: int
    active_instance: int | None
    button_address: int | None
    button_interactable: bool | None
    button_validated: bool
    source: str

    def __post_init__(self) -> None:
        if self.board_instance <= 0:
            raise ValueError("board_instance must be positive")
        if self.card_ui_address is not None and self.card_ui_address <= 0:
            raise ValueError("card_ui_address must be positive when known")
        if self.button_address is not None and self.button_address <= 0:
            raise ValueError("button_address must be positive when known")
        if not self.source.strip():
            raise ValueError("source is required")


@dataclass(frozen=True)
class PetSkillCapability:
    observed_at: float
    status: PetSkillCapabilityStatus
    session_key: CombatSessionKey | None
    pet_id: int | None
    pet_name: str | None
    source_pet_skill_card_id: int | None
    skill_card_id: int | None
    card_data_id: int | None
    card_data_address: int | None
    card_id: int | None
    card_name: str | None
    skill_type: str | None
    element_type: str | None
    effective_mana_cost: int | None
    effective_mana_cost_source: PetSkillCostSource
    effective_power_cost: int | None
    effective_power_cost_source: PetSkillCostSource
    raw_condition_use: int | None
    raw_power: int | None
    raw_mana_cost: int | None
    raw_power_cost: int | None
    cooldown_turns: int | None
    need_perfection: bool | None
    eat_perfect: int | None
    eat_good: int | None
    eat_bad: int | None
    skill_family: PetSkillFamily
    target_mode: PetSkillTargetMode
    live_card_present: bool
    live_card_actionable: bool | None
    live_card_address: int | None
    live_button_address: int | None
    ownership_current: bool
    source: str
    evidence: tuple[str, ...] = ()
    stale_reason: str | None = None

    @property
    def current(self) -> bool:
        return self.status is PetSkillCapabilityStatus.CURRENT and self.ownership_current


def pet_skill_family(element_type: str | None) -> tuple[PetSkillFamily, PetSkillTargetMode]:
    value = (element_type or "").strip().upper()
    if value == "ATTACK_LEGEND_":
        return (
            PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION,
            PetSkillTargetMode.AUTOMATIC,
        )
    if value == "ATTACK_LEGEND":
        return PetSkillFamily.DOT_QTE_OTHER, PetSkillTargetMode.UNKNOWN
    return PetSkillFamily.UNKNOWN, PetSkillTargetMode.UNKNOWN


def resolve_pet_skill_cost(card: CardDataState) -> PetSkillCostResolution:
    """Resolve only the family semantics proven in Phase 3A.1.

    Live fixtures prove the same raw-field contract for both Dot-QTE families:
    ``conditionUse`` is consumed Mana and ``power`` is consumed Rage/Power,
    while raw ``manaCost``/``powerCost`` remain zero.  Huyền Thoại 7 observed
    200/200 and Huyền Thoại 2 observed 200/150.  Values are always read from
    the exact card; no card/pet identity or numeric cost is encoded here.
    Other shapes remain UNKNOWN.
    """

    family, _ = pet_skill_family(card.element_type)
    proven_shape = (
        family in {
            PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION,
            PetSkillFamily.DOT_QTE_OTHER,
        }
        and card.mana_cost == 0
        and card.power_cost == 0
    )
    mana = card.condition_use if proven_shape and card.condition_use > 0 else None
    power = card.power if proven_shape and card.power > 0 else None
    evidence: list[str] = []
    if mana is not None:
        evidence.append(f"{card.element_type}:conditionUse_is_mana_cost")
    if power is not None:
        evidence.append(f"{card.element_type}:power_is_rage_cost")
    if not evidence:
        evidence.append("no_proven_cost_rule_for_current_card_shape")
    return PetSkillCostResolution(
        effective_mana_cost=mana,
        effective_mana_cost_source=(
            PetSkillCostSource.CONDITION_USE
            if mana is not None
            else PetSkillCostSource.UNKNOWN
        ),
        effective_power_cost=power,
        effective_power_cost_source=(
            PetSkillCostSource.POWER
            if power is not None
            else PetSkillCostSource.UNKNOWN
        ),
        evidence=tuple(evidence),
    )


def _quality(card: CardState, name: str) -> int | None:
    values = dict(card.quality_values)
    value = values.get(name)
    return int(value) if value is not None else None


def card_data_from_state(card: CardState) -> CardDataState:
    colors = dict(card.color_requirements)
    return CardDataState(
        address=card.data_address,
        data_id=card.data_id,
        card_id=card.card_id,
        name=card.name,
        description=card.description,
        element_type=card.element_type,
        skill_type=card.skill_type,
        value=int(card.value or 0),
        max_level=int(card.max_level or 0),
        count=int(card.count or 0),
        level=int(card.level or 0),
        condition_use=int(card.condition_use or 0),
        power=int(card.power or 0),
        green=int(colors.get("green", 0)),
        blue=int(colors.get("blue", 0)),
        red=int(colors.get("red", 0)),
        yellow=int(colors.get("yellow", 0)),
        white=int(colors.get("white", 0)),
        purple=int(colors.get("purple", 0)),
        damage_multiplier=float(card.damage_multiplier or 0.0),
        mana_cost=card.mana_cost,
        power_cost=card.power_cost,
        cooldown_turns=card.cooldown_turns,
        need_perfection=card.need_perfection,
        eat_perfect=int(_quality(card, "perfect") or 0),
        eat_good=int(_quality(card, "good") or 0),
        eat_bad=int(_quality(card, "bad") or 0),
    )


def live_pet_skill_card_from_state(
    card: CardState,
    *,
    session_key: CombatSessionKey,
    active_instance: int | None,
) -> LivePetSkillCard:
    live_wrapper = card.interaction_authority == "CARD_UI_BUTTON"
    return LivePetSkillCard(
        session_key=session_key,
        card_data=card_data_from_state(card),
        card_ui_address=card.object_address if live_wrapper else None,
        board_instance=session_key.board_instance,
        active_instance=active_instance,
        button_address=None,
        button_interactable=card.interactable if live_wrapper else None,
        button_validated=live_wrapper,
        source=card.interaction_authority,
    )


class PetSkillCapabilityProvider:
    """Resolve zero/one/ambiguous current Pet Skill capabilities fail-closed."""

    @staticmethod
    def _empty(
        *,
        observed_at: float,
        status: PetSkillCapabilityStatus,
        session_key: CombatSessionKey | None,
        source_pet: PetSkillSnapshot | None,
        source: str,
        reason: str | None = None,
        evidence: tuple[str, ...] = (),
    ) -> PetSkillCapability:
        return PetSkillCapability(
            observed_at=observed_at,
            status=status,
            session_key=session_key,
            pet_id=source_pet.pet_id if source_pet else None,
            pet_name=source_pet.name if source_pet else None,
            source_pet_skill_card_id=(source_pet.skill_card_id if source_pet else None),
            skill_card_id=None,
            card_data_id=None,
            card_data_address=None,
            card_id=None,
            card_name=None,
            skill_type=None,
            element_type=None,
            effective_mana_cost=None,
            effective_mana_cost_source=PetSkillCostSource.UNKNOWN,
            effective_power_cost=None,
            effective_power_cost_source=PetSkillCostSource.UNKNOWN,
            raw_condition_use=None,
            raw_power=None,
            raw_mana_cost=None,
            raw_power_cost=None,
            cooldown_turns=None,
            need_perfection=None,
            eat_perfect=None,
            eat_good=None,
            eat_bad=None,
            skill_family=PetSkillFamily.UNKNOWN,
            target_mode=PetSkillTargetMode.UNKNOWN,
            live_card_present=False,
            live_card_actionable=None,
            live_card_address=None,
            live_button_address=None,
            ownership_current=False,
            source=source,
            evidence=evidence,
            stale_reason=reason,
        )

    def observe(
        self,
        *,
        observed_at: float,
        current_session: CombatSessionKey | None,
        source_pet: PetSkillSnapshot | None,
        candidates: Iterable[LivePetSkillCard],
    ) -> PetSkillCapability:
        if not math.isfinite(observed_at):
            raise ValueError("observed_at must be finite")
        values = tuple(candidates)
        if current_session is None:
            return self._empty(
                observed_at=observed_at,
                status=PetSkillCapabilityStatus.NO_CAPABILITY,
                session_key=None,
                source_pet=source_pet,
                source="no_current_combat_session",
            )

        current: dict[tuple[int, int], LivePetSkillCard] = {}
        duplicate_live_conflict = False
        stale_seen = False
        invalid_seen = False
        for candidate in values:
            family, _ = pet_skill_family(candidate.card_data.element_type)
            if candidate.session_key != current_session:
                stale_seen = True
                continue
            if candidate.board_instance != current_session.board_instance:
                invalid_seen = True
                continue
            if family is PetSkillFamily.UNKNOWN:
                continue
            key = (candidate.card_data.address, candidate.card_data.card_id)
            existing = current.get(key)
            if (
                existing is not None
                and existing.card_ui_address is not None
                and candidate.card_ui_address is not None
                and existing.card_ui_address != candidate.card_ui_address
            ):
                duplicate_live_conflict = True
                continue
            if existing is None or (
                candidate.card_ui_address is not None
                and candidate.button_validated
                and not (
                    existing.card_ui_address is not None and existing.button_validated
                )
            ):
                current[key] = candidate

        if len(current) > 1 or duplicate_live_conflict:
            return self._empty(
                observed_at=observed_at,
                status=PetSkillCapabilityStatus.AMBIGUOUS,
                session_key=current_session,
                source_pet=source_pet,
                source="multiple_current_pet_skill_cards",
                reason="more than one distinct current-session Pet Skill card",
                evidence=tuple(
                    f"cardData=0x{item.card_data.address:X}|cardUI={item.card_ui_address}"
                    for item in current.values()
                ),
            )
        if not current:
            if source_pet and source_pet.card_data and source_pet.card_identity_matches is True:
                card = source_pet.card_data
                family, target = pet_skill_family(card.element_type)
                if family is not PetSkillFamily.UNKNOWN:
                    return self._capability(
                        observed_at=observed_at,
                        status=PetSkillCapabilityStatus.METADATA_ONLY,
                        session_key=current_session,
                        source_pet=source_pet,
                        card=card,
                        candidate=None,
                        family=family,
                        target=target,
                        evidence=("PetUserDTO.cardDTO_only", "live_CardUI_not_observed"),
                    )
            status = (
                PetSkillCapabilityStatus.INVALID
                if invalid_seen
                else PetSkillCapabilityStatus.STALE
                if stale_seen
                else PetSkillCapabilityStatus.NO_CAPABILITY
            )
            reason = (
                "candidate Board ownership disagrees with current session"
                if invalid_seen
                else "only prior-session Pet Skill CardUI candidates were observed"
                if stale_seen
                else None
            )
            return self._empty(
                observed_at=observed_at,
                status=status,
                session_key=current_session,
                source_pet=source_pet,
                source="current_runtime_pet_skill_discovery",
                reason=reason,
            )

        candidate = next(iter(current.values()))
        card = candidate.card_data
        if (
            source_pet is not None
            and source_pet.skill_card_id is not None
            and source_pet.skill_card_id != card.card_id
        ):
            return self._empty(
                observed_at=observed_at,
                status=PetSkillCapabilityStatus.INVALID,
                session_key=current_session,
                source_pet=source_pet,
                source="pet_and_live_card_identity_conflict",
                reason="PetUserDTO skillCardId disagrees with live CardData.cardId",
            )
        family, target = pet_skill_family(card.element_type)
        status = (
            PetSkillCapabilityStatus.CURRENT
            if candidate.card_ui_address is not None and candidate.button_validated
            else PetSkillCapabilityStatus.METADATA_ONLY
        )
        evidence = (
            "exact_CombatSessionKey",
            "Board_instance_matches_session",
            f"source={candidate.source}",
        ) + (("Unity_Button_validated",) if candidate.button_validated else ())
        return self._capability(
            observed_at=observed_at,
            status=status,
            session_key=current_session,
            source_pet=source_pet,
            card=card,
            candidate=candidate,
            family=family,
            target=target,
            evidence=evidence,
        )

    @staticmethod
    def _capability(
        *,
        observed_at: float,
        status: PetSkillCapabilityStatus,
        session_key: CombatSessionKey,
        source_pet: PetSkillSnapshot | None,
        card: CardDataState,
        candidate: LivePetSkillCard | None,
        family: PetSkillFamily,
        target: PetSkillTargetMode,
        evidence: tuple[str, ...],
    ) -> PetSkillCapability:
        cost = resolve_pet_skill_cost(card)
        live = bool(candidate and candidate.card_ui_address and candidate.button_validated)
        return PetSkillCapability(
            observed_at=observed_at,
            status=status,
            session_key=session_key,
            pet_id=source_pet.pet_id if source_pet else None,
            pet_name=source_pet.name if source_pet else None,
            source_pet_skill_card_id=(source_pet.skill_card_id if source_pet else None),
            skill_card_id=card.card_id,
            card_data_id=card.data_id,
            card_data_address=card.address,
            card_id=card.card_id,
            card_name=card.name,
            skill_type=card.skill_type,
            element_type=card.element_type,
            effective_mana_cost=cost.effective_mana_cost,
            effective_mana_cost_source=cost.effective_mana_cost_source,
            effective_power_cost=cost.effective_power_cost,
            effective_power_cost_source=cost.effective_power_cost_source,
            raw_condition_use=card.condition_use,
            raw_power=card.power,
            raw_mana_cost=card.mana_cost,
            raw_power_cost=card.power_cost,
            cooldown_turns=card.cooldown_turns,
            need_perfection=card.need_perfection,
            eat_perfect=card.eat_perfect,
            eat_good=card.eat_good,
            eat_bad=card.eat_bad,
            skill_family=family,
            target_mode=target,
            live_card_present=live,
            live_card_actionable=(
                candidate.button_interactable if live and candidate is not None else None
            ),
            live_card_address=(candidate.card_ui_address if live and candidate else None),
            live_button_address=(candidate.button_address if live and candidate else None),
            ownership_current=status is PetSkillCapabilityStatus.CURRENT,
            source=(candidate.source if candidate else "PetUserDTO.cardDTO"),
            evidence=(*evidence, *cost.evidence),
        )


def direction_from_runtime(value: str | None) -> QteDirection:
    normalized = (value or "").strip().casefold()
    return {
        "nutup": QteDirection.UP,
        "up": QteDirection.UP,
        "nutdown": QteDirection.DOWN,
        "down": QteDirection.DOWN,
        "nutleft": QteDirection.LEFT,
        "left": QteDirection.LEFT,
        "nutright": QteDirection.RIGHT,
        "right": QteDirection.RIGHT,
    }.get(normalized, QteDirection.UNKNOWN)


def timing_result_from_runtime(value: str | None) -> QteTimingResult | None:
    normalized = (value or "").strip().upper().replace(" ", "")
    if "PERFECT" in normalized:
        return QteTimingResult.PERFECT
    if "GOOD" in normalized:
        return QteTimingResult.GOOD
    if "BAD" in normalized:
        return QteTimingResult.BAD
    return None


@dataclass(frozen=True)
class PetSkillResourceDelta:
    mana_before: int | None
    mana_after: int | None
    observed_mana_delta: int | None
    expected_mana_cost: int | None
    power_before: int | None
    power_after: int | None
    observed_power_delta: int | None
    expected_power_cost: int | None
    verification: DeltaVerification


@dataclass(frozen=True)
class PetSkillTurnSemantics:
    source_turn: int | None
    post_resolution_turn: int | None
    source_local_actor: int | None
    post_resolution_local_actor: int | None
    turn_consumed_observed: bool | None
    evidence_status: QteEvidenceStatus


@dataclass(frozen=True)
class QteSnapshot:
    observed_at: float
    match_id: str | None
    session_key: CombatSessionKey | None
    turn_number: int | None
    local_actor: int | None
    skill_card_id: int | None
    qte_generation: int | None
    qte_family: PetSkillFamily
    active: bool
    raw_sequence: tuple[str, ...]
    sequence: tuple[QteDirection, ...]
    sequence_length: int
    current_index: int | None
    correct_count: int | None
    completed: bool
    raw_presses: tuple[str, ...]
    presses: tuple[QteDirection, ...]
    qte_start_time: float | None
    current_elapsed: float | None
    perfect_start: float | None
    perfect_end: float | None
    recommended_confirm_elapsed: float | None
    timing_region: QteTimingRegion
    expected_direction: QteDirection | None
    predicted_timing_result: QteTimingResult | None
    runtime_result_text: str | None
    runtime_display_result: QteTimingResult | None
    server_result_text: str | None
    server_resolved_result: QteTimingResult | None
    server_response_correlated: bool
    server_correlation_provenance: str | None
    prediction_runtime_consistent: bool | None
    prediction_server_consistent: bool | None
    qte_elapsed_ms: int | None
    ownership_status: QteBindingStatus
    stale_reason: str | None
    evidence_status: QteEvidenceStatus
    identity: QteGenerationIdentity | None
    resource_delta: PetSkillResourceDelta | None = None
    turn_semantics: PetSkillTurnSemantics | None = None

    @property
    def observationally_current(self) -> bool:
        return self.evidence_status is QteEvidenceStatus.CURRENT and self.identity is not None


def _timing_region(qte: CardUiQteSnapshot | None) -> QteTimingRegion:
    if qte is None or not qte.timing_window_valid:
        return QteTimingRegion.UNKNOWN
    elapsed = qte.elapsed_seconds
    if elapsed < qte.perfect_start_seconds:
        return QteTimingRegion.BEFORE_PERFECT
    if elapsed <= qte.perfect_end_seconds:
        return QteTimingRegion.INSIDE_PERFECT
    return QteTimingRegion.AFTER_PERFECT


class QteObserver:
    """Session-safe projection/correlation state for read-only QTE evidence."""

    def __init__(self) -> None:
        self._session_key: CombatSessionKey | None = None
        self._current: QteSnapshot | None = None
        self._pending_completed: QteSnapshot | None = None
        self._capability_by_generation: dict[int, PetSkillCapability] = {}
        self._resource_baseline: dict[int, tuple[int | None, int | None]] = {}
        self._seen_response_keys: set[str] = set()
        self._last_invalidation_reason: str | None = None

    @property
    def current(self) -> QteSnapshot | None:
        return self._current

    @property
    def pending_completed(self) -> QteSnapshot | None:
        return self._pending_completed

    def invalidate(self, reason: str) -> None:
        self._session_key = None
        self._current = None
        self._pending_completed = None
        self._capability_by_generation.clear()
        self._resource_baseline.clear()
        self._seen_response_keys.clear()
        self._last_invalidation_reason = reason

    def note_inactive(self, session_key: CombatSessionKey) -> None:
        if self._session_key is not None and self._session_key != session_key:
            self.invalidate("combat_session_changed")
        self._session_key = session_key
        self._current = None

    def observe(
        self,
        *,
        observed_at: float,
        session_key: CombatSessionKey,
        observation: BoundQteObservation,
        capability: PetSkillCapability,
        player_mana: int | None,
        player_power: int | None,
    ) -> QteSnapshot:
        if not math.isfinite(observed_at):
            raise ValueError("observed_at must be finite")
        if self._session_key is not None and self._session_key != session_key:
            self.invalidate("combat_session_changed")
        self._session_key = session_key

        if not observation.current or observation.identity is None or observation.qte is None:
            if observation.status is QteBindingStatus.INACTIVE:
                self.note_inactive(session_key)
            else:
                self._current = None
            return self._noncurrent_snapshot(observed_at, session_key, observation)

        identity = observation.identity
        if (
            not capability.current
            or capability.session_key != session_key
            or capability.skill_card_id != identity.skill_card_id
            or identity.session_key != session_key
        ):
            self._current = None
            return self._noncurrent_snapshot(
                observed_at,
                session_key,
                observation,
                override_status=QteBindingStatus.WRONG_CARD,
                override_reason="current Pet Skill capability does not bind this QTE",
            )

        generation = identity.observer_generation
        previous_generation = (
            self._current.qte_generation if self._current is not None else None
        )
        prior_same_generation = (
            self._pending_completed
            if self._pending_completed is not None
            and self._pending_completed.qte_generation == generation
            else self._current
            if self._current is not None
            and self._current.qte_generation == generation
            else None
        )
        if previous_generation != generation:
            self._current = None
            self._pending_completed = None
            self._capability_by_generation = {generation: capability}
            self._resource_baseline = {generation: (player_mana, player_power)}
            self._seen_response_keys.clear()
        else:
            self._capability_by_generation[generation] = capability
            self._resource_baseline.setdefault(generation, (player_mana, player_power))

        qte = observation.qte
        raw_sequence = observation.challenge.raw_sequence if observation.challenge else ()
        sequence = tuple(direction_from_runtime(item) for item in observation.normalized_sequence)
        presses = tuple(direction_from_runtime(item) for item in qte.qte_presses)
        directions_known = bool(sequence) and all(
            item is not QteDirection.UNKNOWN for item in sequence
        )
        expected = (
            sequence[qte.current_index]
            if directions_known and 0 <= qte.current_index < len(sequence)
            else None
        )
        predicted = timing_result_from_runtime(observation.predicted_timing_result)
        # CardUI reuses the same managed object and can retain the preceding
        # generation's result text while the next QTE is already active.  The
        # text is evidence for this generation only after its own finished
        # flag/status becomes terminal.
        runtime_result_current = bool(
            qte.finished
            and observation.status is QteBindingStatus.COMPLETED_CURRENT
        )
        runtime_text = qte.displayed_timing_text if runtime_result_current else None
        runtime = (
            timing_result_from_runtime(qte.displayed_timing_result)
            if runtime_result_current
            else None
        )
        snapshot = QteSnapshot(
            observed_at=observed_at,
            match_id=session_key.match_id,
            session_key=session_key,
            turn_number=identity.turn_number,
            local_actor=identity.local_actor_number,
            skill_card_id=identity.skill_card_id,
            qte_generation=generation,
            qte_family=capability.skill_family,
            active=qte.active,
            raw_sequence=raw_sequence,
            sequence=sequence,
            sequence_length=len(sequence),
            current_index=qte.current_index,
            correct_count=qte.correct_count,
            completed=observation.status is QteBindingStatus.COMPLETED_CURRENT,
            raw_presses=qte.qte_presses,
            presses=presses,
            qte_start_time=observed_at - qte.elapsed_seconds,
            current_elapsed=qte.elapsed_seconds,
            perfect_start=qte.perfect_start_seconds,
            perfect_end=qte.perfect_end_seconds,
            recommended_confirm_elapsed=(
                qte.perfect_start_seconds
                + (qte.perfect_end_seconds - qte.perfect_start_seconds) / 2.0
            ),
            timing_region=_timing_region(qte),
            expected_direction=expected,
            predicted_timing_result=predicted,
            runtime_result_text=runtime_text,
            runtime_display_result=runtime,
            server_result_text=(
                prior_same_generation.server_result_text
                if prior_same_generation is not None
                else None
            ),
            server_resolved_result=(
                prior_same_generation.server_resolved_result
                if prior_same_generation is not None
                else None
            ),
            server_response_correlated=(
                prior_same_generation.server_response_correlated
                if prior_same_generation is not None
                else False
            ),
            server_correlation_provenance=(
                prior_same_generation.server_correlation_provenance
                if prior_same_generation is not None
                else None
            ),
            prediction_runtime_consistent=(
                predicted == runtime if predicted is not None and runtime is not None else None
            ),
            prediction_server_consistent=(
                prior_same_generation.prediction_server_consistent
                if prior_same_generation is not None
                else None
            ),
            qte_elapsed_ms=qte.qte_elapsed_ms,
            ownership_status=observation.status,
            stale_reason=None,
            evidence_status=QteEvidenceStatus.CURRENT,
            identity=identity,
            resource_delta=(
                prior_same_generation.resource_delta
                if prior_same_generation is not None
                else None
            ),
            turn_semantics=(
                prior_same_generation.turn_semantics
                if prior_same_generation is not None
                else None
            ),
        )
        self._current = snapshot
        if snapshot.completed:
            self._pending_completed = snapshot
        return snapshot

    def correlate_server_response(
        self,
        *,
        generation: int,
        response_key: str,
        match_id: str,
        skill_card_id: int | None,
        correlation: QteResponseCorrelation,
        server_timing_result: str | None,
    ) -> QteSnapshot | None:
        snapshot = self._pending_completed
        if (
            snapshot is None
            or snapshot.qte_generation != generation
            or snapshot.session_key != self._session_key
            or snapshot.match_id != match_id
            or (skill_card_id is not None and skill_card_id != snapshot.skill_card_id)
            or not correlation.current
            or response_key in self._seen_response_keys
        ):
            return None
        self._seen_response_keys.add(response_key)
        server_result = timing_result_from_runtime(server_timing_result)
        updated = replace(
            snapshot,
            server_result_text=server_timing_result,
            server_resolved_result=server_result,
            server_response_correlated=True,
            server_correlation_provenance=correlation.provenance,
            prediction_server_consistent=(
                snapshot.predicted_timing_result == server_result
                if snapshot.predicted_timing_result is not None and server_result is not None
                else None
            ),
        )
        self._pending_completed = updated
        if self._current is not None and self._current.qte_generation == generation:
            self._current = updated
        return updated

    def observe_resolution(
        self,
        *,
        generation: int,
        mana_after: int | None,
        power_after: int | None,
        post_resolution_turn: int | None,
        post_resolution_local_actor: int | None,
        concurrent_resource_change: bool = False,
    ) -> tuple[PetSkillResourceDelta, PetSkillTurnSemantics] | None:
        snapshot = self._pending_completed
        capability = self._capability_by_generation.get(generation)
        baseline = self._resource_baseline.get(generation)
        if (
            snapshot is None
            or capability is None
            or baseline is None
            or snapshot.qte_generation != generation
        ):
            return None
        mana_before, power_before = baseline
        mana_delta = (
            mana_after - mana_before
            if mana_after is not None and mana_before is not None
            else None
        )
        power_delta = (
            power_after - power_before
            if power_after is not None and power_before is not None
            else None
        )
        expected_known = (
            capability.effective_mana_cost is not None
            and capability.effective_power_cost is not None
            and mana_delta is not None
            and power_delta is not None
        )
        if concurrent_resource_change:
            verification = DeltaVerification.AMBIGUOUS
        elif not expected_known:
            verification = DeltaVerification.UNKNOWN
        elif (
            mana_delta == -capability.effective_mana_cost
            and power_delta == -capability.effective_power_cost
        ):
            verification = DeltaVerification.AGREES
        else:
            verification = DeltaVerification.MISMATCH
        resource = PetSkillResourceDelta(
            mana_before=mana_before,
            mana_after=mana_after,
            observed_mana_delta=mana_delta,
            expected_mana_cost=capability.effective_mana_cost,
            power_before=power_before,
            power_after=power_after,
            observed_power_delta=power_delta,
            expected_power_cost=capability.effective_power_cost,
            verification=verification,
        )
        consumed: bool | None
        evidence = QteEvidenceStatus.UNKNOWN
        if snapshot.turn_number is None or post_resolution_turn is None:
            consumed = None
        elif post_resolution_local_actor is None:
            consumed = None
        else:
            consumed = not (
                post_resolution_turn == snapshot.turn_number
                and post_resolution_local_actor == snapshot.local_actor
            )
            evidence = QteEvidenceStatus.CURRENT
        turn = PetSkillTurnSemantics(
            source_turn=snapshot.turn_number,
            post_resolution_turn=post_resolution_turn,
            source_local_actor=snapshot.local_actor,
            post_resolution_local_actor=post_resolution_local_actor,
            turn_consumed_observed=consumed,
            evidence_status=evidence,
        )
        updated = replace(snapshot, resource_delta=resource, turn_semantics=turn)
        self._pending_completed = updated
        if self._current is not None and self._current.qte_generation == generation:
            self._current = updated
        return resource, turn

    @staticmethod
    def _noncurrent_snapshot(
        observed_at: float,
        session_key: CombatSessionKey,
        observation: BoundQteObservation,
        *,
        override_status: QteBindingStatus | None = None,
        override_reason: str | None = None,
    ) -> QteSnapshot:
        status = override_status or observation.status
        evidence = (
            QteEvidenceStatus.INACTIVE
            if status is QteBindingStatus.INACTIVE
            else QteEvidenceStatus.AMBIGUOUS
            if status is QteBindingStatus.AMBIGUOUS_QTE_CANDIDATES
            else QteEvidenceStatus.STALE
            if status
            in {
                QteBindingStatus.WRONG_SESSION,
                QteBindingStatus.WRONG_OWNER,
                QteBindingStatus.WRONG_CARD,
                QteBindingStatus.STALE_OR_CHANGED_QTE,
                QteBindingStatus.UNBOUND_MIDSTREAM,
            }
            else QteEvidenceStatus.UNKNOWN
        )
        return QteSnapshot(
            observed_at=observed_at,
            match_id=session_key.match_id,
            session_key=session_key,
            turn_number=None,
            local_actor=None,
            skill_card_id=None,
            qte_generation=None,
            qte_family=PetSkillFamily.UNKNOWN,
            active=False,
            raw_sequence=(),
            sequence=(),
            sequence_length=0,
            current_index=None,
            correct_count=None,
            completed=False,
            raw_presses=(),
            presses=(),
            qte_start_time=None,
            current_elapsed=None,
            perfect_start=None,
            perfect_end=None,
            recommended_confirm_elapsed=None,
            timing_region=QteTimingRegion.UNKNOWN,
            expected_direction=None,
            predicted_timing_result=None,
            runtime_result_text=None,
            runtime_display_result=None,
            server_result_text=None,
            server_resolved_result=None,
            server_response_correlated=False,
            server_correlation_provenance=None,
            prediction_runtime_consistent=None,
            prediction_server_consistent=None,
            qte_elapsed_ms=None,
            ownership_status=status,
            stale_reason=override_reason or observation.reason,
            evidence_status=evidence,
            identity=None,
        )
