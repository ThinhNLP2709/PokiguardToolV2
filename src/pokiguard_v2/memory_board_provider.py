"""Read-only DTO-first state provider for the current hashed build.

Publishable batches must be tied to the current match's persistent render-ACK
set and must not exist in the pre-match lobby heap baseline. Dot is independent
telemetry; incomplete Dot discovery cannot veto a valid 64-cell DTO snapshot.
"""

from __future__ import annotations

from dataclasses import dataclass, field, replace
from datetime import datetime, timezone
import struct
from typing import Any, Protocol

from .acked_sequences import AckedSequenceSnapshot, read_acked_sequences
from .combat_cards import (
    CombatCardState as MemoryCardState,
    FusionState as MemoryFusionState,
    FusionUiState as MemoryFusionUiState,
    read_fusion_state,
    validate_combat_card_hits,
    validate_fusion_card_ui_hits,
)
from .combat_lifecycle import (
    CombatLifecycleObservation,
    CombatLifecycleState,
    CombatSessionTracker,
    read_combat_lifecycle,
)
from .il2cpp_external import (
    ACTIVE_SINGLETON,
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    BOARD_SINGLETON,
    CHAT_SERVICE_CONNECTING_OFFSET,
    CHAT_SERVICE_EXPLICIT_DISCONNECT_OFFSET,
    CHAT_SERVICE_IS_CONNECTED_OFFSET,
    CHAT_SERVICE_RECONNECT_COROUTINE_OFFSET,
    CHAT_SERVICE_SINGLETON,
    CHAT_SERVICE_USERNAME_OFFSET,
    BOARD_WS_APPLIER_BOARD_OFFSET,
    BOARD_WS_APPLIER_BOOTSTRAPPED_MATCH_ID_OFFSET,
    BOARD_WS_APPLIER_PENDING_BATCHES_OFFSET,
    BOARD_WS_APPLIER_RENDER_RUNNING_OFFSET,
    BOARD_WS_APPLIER_TYPE_INFO_RVA,
    CARD_UI_TYPE_INFO_RVA,
    DOT_TYPE_INFO_RVA,
    FUSION_CARD_UI_TYPE_INFO_RVA,
    MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET,
    MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET,
    MATCH_SERVICE_PENDING_COMBAT_OFFSET,
    MATCH_SERVICE_CLOCK_PAUSED_OFFSET,
    MATCH_SERVICE_CLOCK_PAUSE_REASON_OFFSET,
    MATCH_SERVICE_HAS_DEFERRED_GAME_OVER_OFFSET,
    MATCH_SERVICE_HAS_SERVER_CLOCK_OFFSET,
    MATCH_SERVICE_IN_FLIGHT_BATCHES_OFFSET,
    MATCH_SERVICE_LAST_MOVE_FROM_COL_OFFSET,
    MATCH_SERVICE_LAST_MOVE_FROM_ROW_OFFSET,
    MATCH_SERVICE_LAST_MOVE_SEQ_NUM_OFFSET,
    MATCH_SERVICE_LAST_MOVE_TO_COL_OFFSET,
    MATCH_SERVICE_LAST_MOVE_TO_ROW_OFFSET,
    MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET,
    MATCH_SERVICE_MATCH_OVER_OFFSET,
    MATCH_SERVICE_RESYNC_COROUTINE_OFFSET,
    MATCH_SERVICE_SINGLETON,
    MATCH_SERVICE_TURN_NUMBER_OFFSET,
    MATCH_SERVICE_TURN_DURATION_SEC_OFFSET,
    MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
    is_canonical_user_pointer,
)
from .il2cpp_layout import (
    CombatBatchSnapshot,
    LayoutValidationError,
    observe_rectangular_reference_array,
    read_combat_batch,
    read_il2cpp_string,
)
from .live_state import (
    EVIDENCED_MULTIPLIERS,
    StableSnapshotGate,
    board_state_hash,
    dto_rejection_reasons,
    gem_for_tag,
    to_board_state,
)
from .memory_scan import (
    MEM_PRIVATE,
    WRITABLE_PAGE_TYPES,
    DotCandidateResult,
    bounded_private_writable_regions,
    regions_containing_addresses,
    scan_aligned_qwords,
    validate_combat_batch_hits,
    validate_dot_pointer_hits,
)
from .player_stats import read_active_participants
from .opening_snapshot import OpeningBoardSnapshot
from .state import (
    BattleState,
    BoardStateProvider,
    CardState,
    CombatSessionKey,
    FusionState,
    GamePhase,
    GameState,
    ParticipantState,
)


UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10
QUEUE_ARRAY_OFFSET = 0x10
QUEUE_HEAD_OFFSET = 0x18
QUEUE_TAIL_OFFSET = 0x1C
QUEUE_SIZE_OFFSET = 0x20
QUEUE_VERSION_OFFSET = 0x24
ARRAY_DATA_OFFSET = 0x20
PENDING_TUPLE_SIZE = 0x18
PENDING_TUPLE_BATCH_OFFSET = 0x08
OWNER_ADDRESS_MISS_GRACE_POLLS = 4
# Live provider polls include validated owner/card/state reads and are not a
# cheap 100 ms spin. One complete poll still gives BoardWsApplier a bounded
# direct-owner publication window. Retry 12 proved that two polls followed by
# learned-region miss + next-poll full fallback consumed the 14-second turn.
DIRECT_OWNER_BATCH_GRACE_POLLS = 1


class RuntimeTargetLike(Protocol):
    memory: Any
    resolver: Any

    def is_running(self) -> bool: ...


class StateUnavailableError(RuntimeError):
    pass


class ProviderSetupError(RuntimeError):
    pass


@dataclass(frozen=True)
class MemoryProviderConfig:
    max_region_mib: int = 8
    chunk_mib: int = 2
    required_confirmations: int = 2
    require_lobby_start: bool = True
    full_rescan_interval: int = 24
    max_anchor_region_mib: int = 128
    max_anchor_total_mib: int = 256
    allow_ack_heap_scan: bool = True
    ack_heap_region_mib: int | None = None
    extended_fusion_ui_region_mib: int | None = None

    def __post_init__(self) -> None:
        if not 1 <= self.max_region_mib <= 32:
            raise ValueError("max_region_mib must be between 1 and 32")
        if not 1 <= self.chunk_mib <= 16:
            raise ValueError("chunk_mib must be between 1 and 16")
        if self.required_confirmations < 2:
            raise ValueError("required_confirmations must be at least two")
        if self.full_rescan_interval < 2:
            raise ValueError("full_rescan_interval must be at least two")
        if not 8 <= self.max_anchor_region_mib <= 128:
            raise ValueError("max_anchor_region_mib must be between 8 and 128")
        if not self.max_anchor_region_mib <= self.max_anchor_total_mib <= 512:
            raise ValueError(
                "max_anchor_total_mib must cover one anchor region and be <= 512"
            )
        if (
            self.ack_heap_region_mib is not None
            and not self.max_region_mib <= self.ack_heap_region_mib <= 32
        ):
            raise ValueError(
                "ack_heap_region_mib must cover max_region_mib and be <= 32"
            )
        if (
            self.extended_fusion_ui_region_mib is not None
            and not self.max_region_mib
            <= self.extended_fusion_ui_region_mib
            <= 32
        ):
            raise ValueError(
                "extended_fusion_ui_region_mib must be between "
                "max_region_mib and 32"
            )


def _region_size_band(
    regions: tuple[Any, ...],
    *,
    minimum_exclusive_mib: int,
    maximum_inclusive_mib: int,
) -> tuple[Any, ...]:
    """Select only the evidenced extension beyond the normal scan envelope."""

    minimum = minimum_exclusive_mib * 1024 * 1024
    maximum = maximum_inclusive_mib * 1024 * 1024
    return tuple(region for region in regions if minimum < region.size <= maximum)


def _extended_fusion_scan_relevant(
    memory_fusion: MemoryFusionState | None,
    participants: tuple[ParticipantState, ...],
    *,
    is_local_turn: bool | None,
    turn: int,
    last_scanned_turn: int | None,
) -> bool:
    """Require game-owned availability, turn ownership and sufficient mana."""

    if (
        memory_fusion is None
        or not memory_fusion.candidate_available
        or memory_fusion.mana_cost <= 0
        or is_local_turn is not True
        or turn == last_scanned_turn
    ):
        return False
    local = next(
        (participant for participant in participants if participant.is_local is True),
        None,
    )
    return bool(
        local is not None
        and local.mana is not None
        and local.mana >= memory_fusion.mana_cost
    )


@dataclass
class ProviderMetrics:
    polls: int = 0
    memory_scans: int = 0
    board_lifecycles: int = 0
    board_losses: int = 0
    server_transitions: int = 0
    stable_published: int = 0
    duplicate_skips: int = 0
    stale_skips: int = 0
    unstable_skips: int = 0
    ambiguous_latest_skips: int = 0
    read_errors: int = 0
    dot_anchor_scans: int = 0
    dot_anchor_bytes: int = 0
    owner_batches_seen: int = 0
    unowned_batches_seen: int = 0
    dot_complete_polls: int = 0
    dot_incomplete_polls: int = 0
    dto_rejections: int = 0
    lobby_baseline_scans: int = 0
    ack_reads: int = 0
    ack_batch_scans: int = 0
    highest_acked_sequence: int | None = None
    opening_snapshots_offered: int = 0
    opening_snapshots_accepted: int = 0
    opening_snapshot_rejections: int = 0
    transient_capture_polls: int = 0
    transient_batches_captured: int = 0
    extended_fusion_ui_scans: int = 0
    extended_fusion_ui_bytes: int = 0


@dataclass(frozen=True)
class BoardWsObservation:
    address: int
    queue: int
    render_running: bool
    bootstrapped_match_id: str | None


@dataclass(frozen=True)
class QueueObservation:
    address: int
    capacity: int
    head: int
    tail: int
    size: int
    version: int
    batch_addresses: tuple[int, ...]


@dataclass(frozen=True)
class RenderCrosscheck:
    matches: int
    mismatches: tuple[tuple[int, int, int, int], ...]
    missing: tuple[tuple[int, int], ...]
    ambiguous: tuple[tuple[int, int], ...]

    @property
    def exact(self) -> bool:
        return (
            self.matches == 64
            and not self.mismatches
            and not self.missing
            and not self.ambiguous
        )


@dataclass(frozen=True)
class ProviderPoll:
    state: GameState | None
    publish: bool
    reason: str
    lifecycle_event: str | None = None
    cards_changed: bool = False
    fusion_changed: bool = False
    render_crosscheck: RenderCrosscheck | None = None
    confirmations: int = 0
    session_key: CombatSessionKey | None = None
    dto_rejections: tuple[str, ...] = ()
    combat_lifecycle: CombatLifecycleObservation | None = None


@dataclass(frozen=True)
class ActionRuntimeSignals:
    """Durable fields used to reproduce the game's own move permission checks."""

    local_username: str | None
    connection_ready: bool | None
    reconnecting: bool | None
    match_over: bool
    deferred_game_over: bool
    match_resyncing: bool
    in_flight_batches: int
    clock_paused: bool
    clock_pause_reason: str | None
    start_gate_paused: bool
    local_move_sequence: int
    last_move_from_col: int | None
    last_move_from_row: int | None
    last_move_to_col: int | None
    last_move_to_row: int | None
    last_move_sequence: int | None

    def is_local_turn(self, current_turn_player: str | None) -> bool | None:
        if not self.local_username or not current_turn_player:
            return None
        # MatchService.IsLocalTurn uses StringComparison.OrdinalIgnoreCase (5).
        return self.local_username.casefold() == current_turn_player.casefold()


def _normalize_last_move_telemetry(
    local_sequence: int,
    last_sequence: int,
    coordinates: tuple[int, int, int, int],
) -> tuple[int | None, tuple[int | None, int | None, int | None, int | None]]:
    """Fail only stale optional LastMove telemetry closed during match entry."""

    valid = -1 <= last_sequence <= local_sequence
    if last_sequence > 0 and any(not 0 <= value < 8 for value in coordinates):
        valid = False
    if not valid:
        return None, (None, None, None, None)
    return last_sequence, coordinates


@dataclass(frozen=True)
class TurnTimerObservation:
    """Latest integer countdown tick stored by MatchService.

    This is deliberately not described as a smooth local countdown.  The game
    getter additionally uses Unity ``Time.unscaledTime``; an external reader
    does not currently have a proven pointer to that clock.
    """

    duration_seconds: int
    remaining_seconds: int
    source: str = "MatchService.server_tick"


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def batch_identity(batch: CombatBatchSnapshot) -> tuple[int, int, str]:
    return (batch.address, batch.sequence, board_state_hash(batch.cells))


def _combat_type_info_blocker(
    *,
    batch_class: int | None,
    board_ws_class: int | None,
    opening_snapshot_available: bool,
) -> str | None:
    """Return the exact type-info gate that prevents a safe publication.

    A clean game process does not initialize ``WsCombatBatch`` until after the
    first move.  The fully decoded, current-match MATCH_START board does not
    depend on that class, but it still requires the live BoardWsApplier owner
    for the normal presentation-idle and Board ownership checks.
    """

    if board_ws_class is None:
        return "board_ws_type_info_not_initialized"
    if batch_class is None and not opening_snapshot_available:
        return "combat_batch_type_info_not_initialized"
    return None


def _presentation_idle_for_publication(
    *,
    opening_authoritative: bool,
    owner_idle: bool,
    pending_before: int | None,
    pending_after: int | None,
    in_flight_before: int,
    in_flight_after: int | None,
) -> bool:
    """Prove presentation idle, with a narrow clean-process opening path.

    BoardWsApplier may not have a live managed owner before the first move in a
    freshly started game.  Only an authoritative MATCH_START opening may use
    the equivalent durable MatchService idle signals; every later DTO still
    requires the validated owner/queue path.
    """

    return bool(
        owner_idle
        or (
            opening_authoritative
            and pending_before is None
            and pending_after is None
            and in_flight_before == 0
            and in_flight_after == 0
        )
    )


def _owner_batches_confirmed_by_ack(
    tracked: dict[tuple[int, int, str], CombatBatchSnapshot],
    owner_attested: set[tuple[int, int, str]],
    ack_sequences: set[int],
) -> set[tuple[int, int, str]]:
    """Intersect current-owner captures with the game's durable ACK set."""

    return {
        identity
        for identity in owner_attested
        if identity in tracked and identity[1] in ack_sequences
    }


def _select_latest_identity(
    latest: list[tuple[int, int, str]],
    owner_attested: set[tuple[int, int, str]],
) -> tuple[int, int, str] | None:
    """Resolve one latest DTO hash, preferring exact current-owner evidence.

    Heap duplicates with one common hash are equivalent. If hashes conflict,
    only a non-conflicting subset previously observed through PendingCombat or
    BoardWsApplier._pendingBatches may resolve the ambiguity. Conflicting or
    absent owner evidence fails closed.
    """

    if not latest:
        return None
    if len({identity[2] for identity in latest}) == 1:
        return max(latest, key=lambda identity: identity[0])
    owned = [identity for identity in latest if identity in owner_attested]
    if not owned or len({identity[2] for identity in owned}) != 1:
        return None
    return max(owned, key=lambda identity: identity[0])


def _next_direct_owner_grace(
    *,
    acked_highest: int | None,
    have_highest: bool,
    valid_owner_count: int,
    previous_sequence: int | None,
    previous_polls: int,
    limit: int = DIRECT_OWNER_BATCH_GRACE_POLLS,
) -> tuple[int | None, int, bool]:
    """Give a validated direct owner a short non-blocking capture window."""

    if (
        acked_highest is None
        or have_highest
        or valid_owner_count != 1
        or limit <= 0
    ):
        return None, 0, False
    polls = previous_polls + 1 if previous_sequence == acked_highest else 1
    return acked_highest, polls, polls <= limit


def _needs_immediate_full_ack_rescan(
    *,
    acked_highest: int | None,
    ack_attested: set[tuple[int, int, str]],
    prior_scan_was_full: bool,
) -> bool:
    """Escalate a learned-region miss without spending another loop/turn tick."""

    return bool(
        acked_highest is not None
        and not prior_scan_was_full
        and not any(identity[1] == acked_highest for identity in ack_attested)
    )


def _durable_non_board_fusion_transition(
    *,
    acked_highest: int | None,
    last_accepted_sequence: int | None,
    last_accepted_turn: int | None,
    current_turn: int | None,
    last_local_move_sequence: int | None,
    action: ActionRuntimeSignals,
    previous_fusion: FusionState | None,
    current_fusion: MemoryFusionState | None,
    last_all_dots: tuple[int, ...] | None,
    current_all_dots: tuple[int, ...] | None,
    pending_batch: int | None,
    current_turn_player: str | None,
    retained_sequence: int | None = None,
) -> int | None:
    """Recognize an exact terminal EVOLVE ACK that leaves Board unchanged.

    Both success and failure advance ``LocalFusionLastAttemptTurn``. A failed
    attempt keeps ``LocalFusionUsed`` false, but it is still a durable
    non-board transition and must not make the controller wait for a Board DTO
    that the server never sends.
    """

    common = bool(
        acked_highest is None
        or last_accepted_sequence is None
        or last_accepted_turn is None
        or current_turn != last_accepted_turn
        or last_local_move_sequence is None
        or action.local_move_sequence != last_local_move_sequence
        or action.is_local_turn(current_turn_player) is not True
        or pending_batch is not None
        or action.in_flight_batches != 0
        or current_fusion is None
        or current_fusion.last_attempt_turn != current_turn
        or last_all_dots is None
        or current_all_dots != last_all_dots
    )
    if common:
        return None
    fusion_attempt_advanced = bool(
        previous_fusion is not None
        and current_fusion.last_attempt_turn
        != previous_fusion.last_attempt_turn
    )
    success_transition = bool(
        previous_fusion is not None
        and previous_fusion.used is False
        and current_fusion.used_successfully is True
    )
    new_transition = bool(
        acked_highest > last_accepted_sequence
        and (fusion_attempt_advanced or success_transition)
    )
    retained_transition = bool(
        retained_sequence is not None
        and acked_highest == retained_sequence == last_accepted_sequence
    )
    return acked_highest if new_transition or retained_transition else None


def batch_semantics_valid(batch: CombatBatchSnapshot) -> bool:
    return all(
        gem_for_tag(cell.tag).value != "unknown"
        and cell.multiplier in EVIDENCED_MULTIPLIERS
        for cell in batch.cells
    )


def sequence_rejection_reason(
    last_sequence: int | None,
    last_hash: str | None,
    candidate_sequence: int,
    candidate_hash: str,
) -> str | None:
    """Classify per-session ordering without treating sequence as identity."""

    if candidate_sequence < 0:
        return "negative_sequence"
    if last_sequence is None:
        return None
    if candidate_sequence < last_sequence:
        return "stale_sequence"
    if candidate_sequence == last_sequence and candidate_hash != last_hash:
        return "sequence_hash_changed"
    if candidate_sequence == last_sequence:
        return "duplicate_sequence"
    return None


def dot_crosscheck(
    batch: CombatBatchSnapshot, dots: DotCandidateResult
) -> RenderCrosscheck:
    matches = 0
    mismatches: list[tuple[int, int, int, int]] = []
    missing: list[tuple[int, int]] = []
    ambiguous: list[tuple[int, int]] = []
    for cell in batch.cells:
        candidates = dots.by_coordinate.get((cell.row, cell.col), ())
        if not candidates:
            missing.append((cell.row, cell.col))
        elif len(candidates) != 1:
            ambiguous.append((cell.row, cell.col))
        elif candidates[0].multiplier == cell.multiplier:
            matches += 1
        else:
            mismatches.append(
                (cell.row, cell.col, cell.multiplier, candidates[0].multiplier)
            )
    return RenderCrosscheck(
        matches,
        tuple(mismatches),
        tuple(missing),
        tuple(ambiguous),
    )


def read_board_ws_candidate(
    memory: Any,
    address: int,
    *,
    expected_class: int,
    expected_board: int,
) -> BoardWsObservation:
    raw = memory.read(address, BOARD_WS_APPLIER_RENDER_RUNNING_OFFSET + 1)
    class_pointer = struct.unpack_from("<Q", raw, 0)[0]
    cached_pointer = struct.unpack_from("<Q", raw, UNITY_OBJECT_CACHED_PTR_OFFSET)[0]
    board_pointer = struct.unpack_from("<Q", raw, BOARD_WS_APPLIER_BOARD_OFFSET)[0]
    queue_pointer = struct.unpack_from(
        "<Q", raw, BOARD_WS_APPLIER_PENDING_BATCHES_OFFSET
    )[0]
    match_id_pointer = struct.unpack_from(
        "<Q", raw, BOARD_WS_APPLIER_BOOTSTRAPPED_MATCH_ID_OFFSET
    )[0]
    render_raw = raw[BOARD_WS_APPLIER_RENDER_RUNNING_OFFSET]
    if class_pointer != expected_class or board_pointer != expected_board:
        raise LayoutValidationError("BoardWsApplier class/Board owner mismatch")
    if not is_canonical_user_pointer(cached_pointer):
        raise LayoutValidationError("BoardWsApplier native pointer is invalid")
    if not is_canonical_user_pointer(queue_pointer) or not memory.is_readable(
        queue_pointer, 0x30
    ):
        raise LayoutValidationError("BoardWsApplier queue is invalid")
    if render_raw not in (0, 1):
        raise LayoutValidationError("BoardWsApplier render flag is invalid")
    match_id = (
        read_il2cpp_string(memory, match_id_pointer, max_length=256)
        if is_canonical_user_pointer(match_id_pointer)
        else None
    )
    return BoardWsObservation(
        address, queue_pointer, bool(render_raw), match_id or None
    )


def read_pending_queue(memory: Any, address: int) -> QueueObservation:
    """Decode the runtime-validated Queue<ValueTuple<...,WsCombatBatch,...>>."""

    raw = memory.read(address, 0x30)
    array = struct.unpack_from("<Q", raw, QUEUE_ARRAY_OFFSET)[0]
    head = struct.unpack_from("<i", raw, QUEUE_HEAD_OFFSET)[0]
    tail = struct.unpack_from("<i", raw, QUEUE_TAIL_OFFSET)[0]
    size = struct.unpack_from("<i", raw, QUEUE_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", raw, QUEUE_VERSION_OFFSET)[0]
    if not is_canonical_user_pointer(array) or not memory.is_readable(array, 0x20):
        raise LayoutValidationError("pending queue array is invalid")
    array_header = memory.read(array, 0x20)
    array_class, _monitor, bounds, capacity = struct.unpack("<4Q", array_header)
    if (
        not is_canonical_user_pointer(array_class)
        or not memory.is_readable(array_class, 8)
        or bounds != 0
        or not 1 <= capacity <= 128
        or not 0 <= size <= capacity
        or not 0 <= head < capacity
        or not 0 <= tail < capacity
        or version < 0
    ):
        raise LayoutValidationError("pending queue shape failed validation")
    addresses: list[int] = []
    for offset in range(size):
        index = (head + offset) % capacity
        item = array + ARRAY_DATA_OFFSET + index * PENDING_TUPLE_SIZE
        batch = struct.unpack(
            "<Q", memory.read(item + PENDING_TUPLE_BATCH_OFFSET, 8)
        )[0]
        if not is_canonical_user_pointer(batch):
            raise LayoutValidationError("pending queue contains an invalid batch")
        addresses.append(batch)
    return QueueObservation(
        address, capacity, head, tail, size, version, tuple(addresses)
    )


def _canonical_card(card: MemoryCardState) -> CardState:
    return CardState(
        object_address=card.address,
        data_address=card.card_data,
        data_id=card.data_id,
        card_id=card.card_id,
        name=card.name,
        description=card.description,
        element_type=card.element_type,
        skill_type=card.skill_type,
        interactable=card.ui_interactable,
        has_used_this_match=card.has_used_this_match,
        has_used_this_turn=card.has_used_this_turn,
        last_turn_used=card.last_turn_used,
        action_pending=card.action_pending,
        is_placeholder=card.is_placeholder,
        mana_cost=card.mana_cost,
        power_cost=card.power_cost,
        cooldown_turns=card.cooldown_turns,
        need_perfection=card.need_perfection,
        value=card.value,
        max_level=card.max_level,
        count=card.count,
        level=card.level,
        condition_use=card.condition_use,
        power=card.power,
        damage_multiplier=card.damage_multiplier,
        color_requirements=(
            ("green", card.green),
            ("blue", card.blue),
            ("red", card.red),
            ("yellow", card.yellow),
            ("white", card.white),
            ("purple", card.purple),
        ),
        quality_values=(
            ("perfect", card.eat_perfect),
            ("good", card.eat_good),
            ("bad", card.eat_bad),
        ),
    )


def _canonical_fusion(
    state: MemoryFusionState | None,
    ui: MemoryFusionUiState | None,
) -> FusionState | None:
    if state is None:
        return None
    return FusionState(
        enabled=state.enabled,
        available=state.candidate_available,
        used=state.used_successfully,
        locked_this_turn=state.locked_this_turn,
        last_attempt_turn=state.last_attempt_turn,
        mana_cost=state.mana_cost,
        stat_bonus_percent=state.stat_percent,
        selected_user_pet_id=state.selected_user_pet_id,
        selected_pet_id=state.selected_pet_id,
        skill_card_data_address=state.skill_card,
        drop_reason=state.drop_reason,
        ui_address=ui.address if ui is not None else None,
        ui_interactable=ui.interactable if ui is not None else None,
    )


class MemoryBoardStateProvider(BoardStateProvider):
    """Stateful lobby-to-combat provider with currentness and dedup guards."""

    def __init__(
        self,
        target: RuntimeTargetLike,
        config: MemoryProviderConfig | None = None,
    ) -> None:
        self.target = target
        self.config = config or MemoryProviderConfig()
        self.metrics = ProviderMetrics()
        self._batch_class = target.resolver.resolve_type_info_class(
            WS_COMBAT_BATCH_TYPE_INFO_RVA
        )
        self._dot_class = target.resolver.resolve_type_info_class(DOT_TYPE_INFO_RVA)
        self._board_ws_class = target.resolver.resolve_type_info_class(
            BOARD_WS_APPLIER_TYPE_INFO_RVA
        )
        self._card_ui_class = target.resolver.resolve_type_info_class(
            CARD_UI_TYPE_INFO_RVA
        )
        self._fusion_ui_class = target.resolver.resolve_type_info_class(
            FUSION_CARD_UI_TYPE_INFO_RVA
        )
        self._player_stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        board = self._resolve_board()
        if self.config.require_lobby_start and board is not None:
            raise ProviderSetupError(
                "start MemoryBoardStateProvider in the lobby before Board.Instance exists"
            )
        self._learned_regions: dict[str, set[Any]] = {}
        self._last_scan_was_full = False
        self._force_full_scan = False
        self._scan_number = 0
        self._lifecycle_epoch = 0
        self._lifecycle_tracker = CombatSessionTracker()
        self._last_combat_lifecycle = CombatLifecycleState.UNKNOWN
        self._current_board: int | None = None
        self._current_match_id: str | None = None
        self._session_key: CombatSessionKey | None = None
        self._tracked: dict[tuple[int, int, str], CombatBatchSnapshot] = {}
        self._sources: dict[tuple[int, int, str], set[str]] = {}
        self._owner_attested: set[tuple[int, int, str]] = set()
        self._transport_attested: set[tuple[int, int, str]] = set()
        self._ack_attested: set[tuple[int, int, str]] = set()
        self._lobby_batch_baseline: set[tuple[int, int, str]] = set()
        self._session_batch_baseline: set[tuple[int, int, str]] = set()
        self._lobby_baseline_ready = False
        self._needs_lobby_baseline = True
        self._batch_scan_miss_seq: int | None = None
        self._latest_identity: tuple[int, int, str] | None = None
        self._last_accepted_seq: int | None = None
        self._last_accepted_hash: str | None = None
        self._last_accepted_turn: int | None = None
        self._last_accepted_local_move_sequence: int | None = None
        self._last_accepted_all_dots: tuple[int, ...] | None = None
        self._non_board_fusion_sequence: int | None = None
        self._opening_snapshot: OpeningBoardSnapshot | None = None
        self._gate = StableSnapshotGate(self.config.required_confirmations)
        self._published: set[tuple[CombatSessionKey, int, str]] = set()
        self._last_phase = GamePhase.UNKNOWN
        self._last_cards: tuple[CardState, ...] = ()
        self._last_fusion: FusionState | None = None
        self._last_published_state: GameState | None = None
        self._dot_pointer_hits: set[int] = set()
        self._card_addresses: set[int] = set()
        self._fusion_ui_addresses: set[int] = set()
        self._extended_fusion_scan_turn: int | None = None
        self._batch_addresses: set[int] = set()
        self._board_ws_addresses: set[int] = set()
        self._board_ws_address_misses: dict[int, int] = {}
        self._direct_owner_grace_seq: int | None = None
        self._direct_owner_grace_polls = 0
        self._last_dot_anchor_regions: tuple[Any, ...] = ()
        self._last_dot_anchor_bytes = 0
        if board is None:
            self._refresh_lobby_baseline()

    def _refresh_type_info(self) -> bool:
        """Resolve combat-only classes lazily after Unity initializes them.

        A clean process can sit in the lobby with these global type-info slots
        still encoded/uninitialized.  That is a waiting state, not a setup
        failure, because the watcher is required to start before combat.
        """

        if self._batch_class is None:
            self._batch_class = self.target.resolver.resolve_type_info_class(
                WS_COMBAT_BATCH_TYPE_INFO_RVA
            )
        if self._board_ws_class is None:
            self._board_ws_class = self.target.resolver.resolve_type_info_class(
                BOARD_WS_APPLIER_TYPE_INFO_RVA
            )
        if self._dot_class is None:
            self._dot_class = self.target.resolver.resolve_type_info_class(
                DOT_TYPE_INFO_RVA
            )
        if self._fusion_ui_class is None:
            self._fusion_ui_class = self.target.resolver.resolve_type_info_class(
                FUSION_CARD_UI_TYPE_INFO_RVA
            )
        return self._batch_class is not None and self._board_ws_class is not None

    def _regions(self) -> tuple[Any, ...]:
        return bounded_private_writable_regions(
            self.target.memory.iter_readable_regions(),
            max_region_size=self.config.max_region_mib * 1024 * 1024,
        )

    def _refresh_lobby_baseline(self) -> bool:
        """Fingerprint every complete pre-match batch and learn source regions."""

        if self._batch_class is None:
            # A clean process before its first combat cannot contain an
            # initialized/allocated WsCombatBatch while that class's type-info
            # slot is still unavailable. BoardWsApplier can initialize earlier
            # in the boss lobby, so it must not prevent this empty baseline.
            self._lobby_batch_baseline.clear()
            self._lobby_baseline_ready = True
            self._needs_lobby_baseline = False
            return True
        # WsCombatBatch is the only class required to fingerprint stale DTOs.
        # BoardWsApplier is a useful region-learning needle, but on a clean
        # process its type-info may remain uninitialized until combat starts.
        # Requiring it here prevents a valid boss-lobby baseline forever.
        try:
            needles = {"batch": int(self._batch_class)}
            if self._board_ws_class is not None:
                needles["board_ws"] = int(self._board_ws_class)
            scan = self._scan(
                needles,
                force_full=True,
            )
            batches = validate_combat_batch_hits(
                self.target.memory,
                scan.matches["batch"],
                batch_class=int(self._batch_class),
            )
        except (ExternalReadError, OSError):
            self.metrics.read_errors += 1
            return False
        self._lobby_batch_baseline = {batch_identity(batch) for batch in batches}
        self._lobby_baseline_ready = True
        self._needs_lobby_baseline = False
        self.metrics.lobby_baseline_scans += 1
        return True

    def _scan(self, needles: dict[str, int], *, force_full: bool = False) -> Any:
        self.metrics.memory_scans += 1
        all_regions = self._regions()
        learned_complete = all(
            bool(self._learned_regions.get(name)) for name in needles
        )
        periodic_full = (
            self.metrics.memory_scans % self.config.full_rescan_interval == 0
        )
        self._last_scan_was_full = bool(
            force_full or not learned_complete or periodic_full
        )
        if self._last_scan_was_full:
            regions = all_regions
        else:
            selected = {
                region
                for name in needles
                for region in self._learned_regions.get(name, ())
            }
            regions = tuple(sorted(selected, key=lambda region: region.base))
        result = scan_aligned_qwords(
            self.target.memory,
            regions,
            needles,
            chunk_size=self.config.chunk_mib * 1024 * 1024,
        )
        for name, hits in result.matches.items():
            learned = regions_containing_addresses(regions, hits)
            if learned:
                self._learned_regions.setdefault(name, set()).update(learned)
        return result

    def _scan_extended_fusion_ui(self) -> Any:
        """Scan only the 8--16 MiB band evidenced for live FusionCardUI.

        This is deliberately separate from the board/DTO scanner.  It runs at
        most once per eligible local turn and never teaches the normal bounded
        scanner to traverse an out-of-envelope region.
        """

        maximum_mib = self.config.extended_fusion_ui_region_mib
        if maximum_mib is None or self._fusion_ui_class is None:
            raise RuntimeError("extended FusionCardUI scan is not configured")
        all_regions = bounded_private_writable_regions(
            self.target.memory.iter_readable_regions(),
            max_region_size=maximum_mib * 1024 * 1024,
        )
        regions = _region_size_band(
            all_regions,
            minimum_exclusive_mib=self.config.max_region_mib,
            maximum_inclusive_mib=maximum_mib,
        )
        result = scan_aligned_qwords(
            self.target.memory,
            regions,
            {"fusion_ui": int(self._fusion_ui_class)},
            chunk_size=self.config.chunk_mib * 1024 * 1024,
        )
        self.metrics.extended_fusion_ui_scans += 1
        self.metrics.extended_fusion_ui_bytes += result.bytes_read
        return result

    def _scan_ack_heap(self, *, force_full: bool) -> Any:
        """Scan only the bounded allocation envelope evidenced for live batches.

        This is deliberately separate from the normal provider envelope. Live
        retry-8 measurement found the newest WsCombatBatch in a 8--16 MiB
        managed region: the bounded 16 MiB scan took about 1.94 seconds, while
        an unrestricted 3.36 GiB process scan took 14.5 seconds. Exact ACK and
        DTO validation remain downstream requirements.
        """

        maximum_mib = (
            self.config.ack_heap_region_mib
            if self.config.ack_heap_region_mib is not None
            else self.config.max_region_mib
        )
        all_regions = bounded_private_writable_regions(
            self.target.memory.iter_readable_regions(),
            max_region_size=maximum_mib * 1024 * 1024,
        )
        learned = tuple(self._learned_regions.get("batch", ()))
        current_learned = tuple(
            region
            for region in all_regions
            if any(
                region.base < old.end and old.base < region.end
                for old in learned
            )
        )
        regions = all_regions if force_full or not current_learned else current_learned
        self.metrics.memory_scans += 1
        self._last_scan_was_full = regions is all_regions
        result = scan_aligned_qwords(
            self.target.memory,
            regions,
            {"batch": int(self._batch_class)},
            chunk_size=self.config.chunk_mib * 1024 * 1024,
        )
        evidenced = regions_containing_addresses(
            all_regions, result.matches.get("batch", ())
        )
        if evidenced:
            self._learned_regions.setdefault("batch", set()).update(evidenced)
        return result

    def _dot_anchor_regions(self, addresses: set[int]) -> tuple[Any, ...]:
        """Resolve only allocation regions evidenced by live allDots objects."""

        if not addresses:
            return ()
        writable = tuple(
            region
            for region in self.target.memory.iter_readable_regions()
            if region.memory_type == MEM_PRIVATE
            and (region.protection & 0xFF) in WRITABLE_PAGE_TYPES
        )
        regions = regions_containing_addresses(writable, addresses)
        per_region_limit = self.config.max_anchor_region_mib * 1024 * 1024
        total_limit = self.config.max_anchor_total_mib * 1024 * 1024
        if (
            not regions
            or any(region.size > per_region_limit for region in regions)
            or sum(region.size for region in regions) > total_limit
        ):
            return ()
        return regions

    def _current_dots(
        self,
        board_instance: int,
        array_before: Any | None,
        batch: CombatBatchSnapshot,
        bounded_pointer_hits: set[int],
    ) -> DotCandidateResult:
        # Revalidate cached object addresses first. A settled board normally
        # needs no region scan after the initial 64 objects have been learned.
        cached = validate_dot_pointer_hits(
            self.target.memory,
            self._dot_pointer_hits | bounded_pointer_hits,
            board_pointer=board_instance,
            dot_class=int(self._dot_class),
        )
        if (
            len(cached.by_coordinate) == 64
            and not cached.duplicate_coordinates
            and dot_crosscheck(batch, cached).exact
        ):
            self._last_dot_anchor_regions = ()
            self._last_dot_anchor_bytes = 0
            return cached

        anchor_addresses = {
            address
            for address in (
                array_before.elements
                if array_before is not None
                and array_before.layout_verified
                and array_before.elements is not None
                else ()
            )
        }
        anchor_addresses.update(
            hit - 0x48 for hit in self._dot_pointer_hits if hit >= 0x48
        )
        regions = self._dot_anchor_regions(anchor_addresses)
        self._last_dot_anchor_regions = regions
        self._last_dot_anchor_bytes = sum(region.size for region in regions)
        if not regions:
            return cached
        self.metrics.memory_scans += 1
        self.metrics.dot_anchor_scans += 1
        self.metrics.dot_anchor_bytes += self._last_dot_anchor_bytes
        scan = scan_aligned_qwords(
            self.target.memory,
            regions,
            {"board": board_instance},
            chunk_size=self.config.chunk_mib * 1024 * 1024,
        )
        return validate_dot_pointer_hits(
            self.target.memory,
            set(scan.matches["board"])
            | self._dot_pointer_hits
            | bounded_pointer_hits,
            board_pointer=board_instance,
            dot_class=int(self._dot_class),
        )

    def _resolve_board(self) -> Any | None:
        board_resolution = self.target.resolver.resolve_singleton(BOARD_SINGLETON)
        if not board_resolution.resolved or board_resolution.instance is None:
            return None
        active_resolution = self.target.resolver.resolve_singleton(ACTIVE_SINGLETON)
        active = active_resolution.instance if active_resolution.resolved else None
        board = self.target.resolver.read_board(board_resolution.instance, active)
        return board if board.accepted else None

    def _resolve_match_service(self) -> int | None:
        value = self.target.resolver.resolve_singleton(MATCH_SERVICE_SINGLETON)
        return value.instance if value.resolved else None

    def _resolve_chat_service(self) -> int | None:
        value = self.target.resolver.resolve_singleton(CHAT_SERVICE_SINGLETON)
        return value.instance if value.resolved else None

    def _read_string_field(
        self, instance: int, offset: int, *, max_length: int = 256
    ) -> str | None:
        pointer = self.target.resolver.read_pointer(instance + offset)
        if pointer == 0:
            return None
        if not is_canonical_user_pointer(pointer):
            raise LayoutValidationError("string field pointer is not canonical")
        value = read_il2cpp_string(
            self.target.memory, pointer, max_length=max_length
        )
        return value or None

    def _read_action_signals(self, match_service: int) -> ActionRuntimeSignals:
        """Read only native-proven fields; unavailable identity fails closed later."""

        resolver = self.target.resolver
        match_over = resolver.read_bool(
            match_service + MATCH_SERVICE_MATCH_OVER_OFFSET
        )
        deferred = resolver.read_bool(
            match_service + MATCH_SERVICE_HAS_DEFERRED_GAME_OVER_OFFSET
        )
        has_clock = resolver.read_bool(
            match_service + MATCH_SERVICE_HAS_SERVER_CLOCK_OFFSET
        )
        clock_paused = resolver.read_bool(
            match_service + MATCH_SERVICE_CLOCK_PAUSED_OFFSET
        )
        clock_reason = self._read_string_field(
            match_service, MATCH_SERVICE_CLOCK_PAUSE_REASON_OFFSET
        )
        in_flight = resolver.read_i32(
            match_service + MATCH_SERVICE_IN_FLIGHT_BATCHES_OFFSET
        )
        if not 0 <= in_flight <= 1_000:
            raise LayoutValidationError("MatchService in-flight count is invalid")
        local_move_sequence = resolver.read_i64(
            match_service + MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET
        )
        last_move_sequence = resolver.read_i64(
            match_service + MATCH_SERVICE_LAST_MOVE_SEQ_NUM_OFFSET
        )
        if not 0 <= local_move_sequence <= 10_000_000:
            raise LayoutValidationError("MatchService local move sequence is invalid")
        last_move_coordinates = (
            resolver.read_i32(match_service + MATCH_SERVICE_LAST_MOVE_FROM_COL_OFFSET),
            resolver.read_i32(match_service + MATCH_SERVICE_LAST_MOVE_FROM_ROW_OFFSET),
            resolver.read_i32(match_service + MATCH_SERVICE_LAST_MOVE_TO_COL_OFFSET),
            resolver.read_i32(match_service + MATCH_SERVICE_LAST_MOVE_TO_ROW_OFFSET),
        )
        # MatchService publishes the new CurrentMatchId/turn before it resets
        # LastMove* from the previous match. This transition was already
        # runtime-proven and handled by idle_state_watch.read_match_runtime.
        # LastMove* is optional request telemetry, so make only that evidence
        # UNKNOWN until it is internally consistent; never reinterpret it as
        # an ACK or discard the otherwise current combat sample.
        last_move_sequence, last_move_coordinates = _normalize_last_move_telemetry(
            local_move_sequence, last_move_sequence, last_move_coordinates
        )
        resync_pointer = resolver.read_pointer(
            match_service + MATCH_SERVICE_RESYNC_COROUTINE_OFFSET
        )
        if resync_pointer and not is_canonical_user_pointer(resync_pointer):
            raise LayoutValidationError("MatchService resync pointer is invalid")

        local_username: str | None = None
        connected: bool | None = None
        reconnecting: bool | None = None
        chat_service = self._resolve_chat_service()
        if chat_service is not None:
            local_username = self._read_string_field(
                chat_service, CHAT_SERVICE_USERNAME_OFFSET
            )
            connected = resolver.read_bool(
                chat_service + CHAT_SERVICE_IS_CONNECTED_OFFSET
            )
            explicit_disconnect = resolver.read_bool(
                chat_service + CHAT_SERVICE_EXPLICIT_DISCONNECT_OFFSET
            )
            connecting = resolver.read_bool(
                chat_service + CHAT_SERVICE_CONNECTING_OFFSET
            )
            reconnect_pointer = resolver.read_pointer(
                chat_service + CHAT_SERVICE_RECONNECT_COROUTINE_OFFSET
            )
            if reconnect_pointer and not is_canonical_user_pointer(reconnect_pointer):
                raise LayoutValidationError("ChatService reconnect pointer is invalid")
            reconnecting = bool(
                explicit_disconnect or connecting or reconnect_pointer or resync_pointer
            )

        return ActionRuntimeSignals(
            local_username=local_username,
            connection_ready=(
                bool(connected and not reconnecting)
                if connected is not None and reconnecting is not None
                else None
            ),
            reconnecting=reconnecting,
            match_over=match_over,
            deferred_game_over=deferred,
            match_resyncing=bool(resync_pointer),
            in_flight_batches=in_flight,
            clock_paused=bool(has_clock and clock_paused),
            clock_pause_reason=clock_reason,
            start_gate_paused=bool(
                has_clock and clock_paused and clock_reason == "START_GATE"
            ),
            local_move_sequence=local_move_sequence,
            last_move_from_col=last_move_coordinates[0],
            last_move_from_row=last_move_coordinates[1],
            last_move_to_col=last_move_coordinates[2],
            last_move_to_row=last_move_coordinates[3],
            last_move_sequence=last_move_sequence,
        )

    def _read_turn_timer(self, match_service: int) -> TurnTimerObservation:
        resolver = self.target.resolver
        duration = resolver.read_i32(
            match_service + MATCH_SERVICE_TURN_DURATION_SEC_OFFSET
        )
        remaining = resolver.read_i32(
            match_service + MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET
        )
        if not 1 <= duration <= 300:
            raise LayoutValidationError("MatchService turn duration is implausible")
        if not 0 <= remaining <= duration:
            raise LayoutValidationError("MatchService remaining turn time is invalid")
        return TurnTimerObservation(duration, remaining)

    def _reset_lifecycle(
        self,
        board_instance: int,
        match_id: str,
        session_key: CombatSessionKey,
    ) -> None:
        """Start a new combat and discard every prior batch/sequence cache."""

        self._lifecycle_epoch = session_key.lifecycle_epoch
        self._current_board = board_instance
        self._current_match_id = match_id
        self._session_key = session_key
        self._session_batch_baseline = set(self._lobby_batch_baseline)
        self._tracked.clear()
        self._sources.clear()
        self._owner_attested.clear()
        self._transport_attested.clear()
        self._ack_attested.clear()
        self._batch_scan_miss_seq = None
        self._latest_identity = None
        self._last_accepted_seq = None
        self._last_accepted_hash = None
        self._last_accepted_turn = None
        self._last_accepted_local_move_sequence = None
        self._last_accepted_all_dots = None
        self._non_board_fusion_sequence = None
        self._opening_snapshot = None
        self._gate = StableSnapshotGate(self.config.required_confirmations)
        self._published.clear()
        self._last_cards = ()
        self._last_fusion = None
        self._last_published_state = None
        self._dot_pointer_hits.clear()
        self._card_addresses.clear()
        self._fusion_ui_addresses.clear()
        self._extended_fusion_scan_turn = None
        self._batch_addresses.clear()
        self._board_ws_addresses.clear()
        self._board_ws_address_misses.clear()
        self._direct_owner_grace_seq = None
        self._direct_owner_grace_polls = 0
        self._force_full_scan = not bool(self._learned_regions.get("board_ws"))
        self.metrics.board_lifecycles += 1

    def _clear_lifecycle(self) -> None:
        """Fail closed on Board loss; no state may cross into the next room."""

        self._current_board = None
        self._current_match_id = None
        self._session_key = None
        self._session_batch_baseline.clear()
        self._tracked.clear()
        self._sources.clear()
        self._owner_attested.clear()
        self._transport_attested.clear()
        self._ack_attested.clear()
        self._batch_scan_miss_seq = None
        self._latest_identity = None
        self._last_accepted_seq = None
        self._last_accepted_hash = None
        self._last_accepted_turn = None
        self._last_accepted_local_move_sequence = None
        self._last_accepted_all_dots = None
        self._non_board_fusion_sequence = None
        self._opening_snapshot = None
        self._published.clear()
        self._batch_addresses.clear()
        self._board_ws_addresses.clear()
        self._board_ws_address_misses.clear()
        self._direct_owner_grace_seq = None
        self._direct_owner_grace_polls = 0
        self._dot_pointer_hits.clear()
        self._card_addresses.clear()
        self._fusion_ui_addresses.clear()
        self._extended_fusion_scan_turn = None
        self._gate = StableSnapshotGate(self.config.required_confirmations)
        self._last_cards = ()
        self._last_fusion = None
        self._last_published_state = None
        self._force_full_scan = not bool(self._learned_regions.get("board_ws"))
        self._needs_lobby_baseline = True
        self._lobby_baseline_ready = False

    def _register(
        self, batch: CombatBatchSnapshot, source: str
    ) -> tuple[int, int, str]:
        identity = batch_identity(batch)
        self._tracked[identity] = batch
        self._sources.setdefault(identity, set()).add(source)
        if source in {
            "MatchService.PendingCombat",
            "BoardWsApplier._pendingBatches",
        }:
            if identity not in self._owner_attested:
                self.metrics.owner_batches_seen += 1
            self._owner_attested.add(identity)
        return identity

    def offer_opening_snapshot(self, snapshot: OpeningBoardSnapshot) -> bool:
        """Bind a decoded MATCH_START board to the current combat session.

        This is deliberately separate from heap discovery. The caller must
        first decode the current-match ``ChatMessageDTO.matchPayload['board']``
        through :mod:`opening_snapshot`; this method then enforces session,
        sequence and replacement rules. No unowned or cross-match snapshot is
        retained.
        """

        self.metrics.opening_snapshots_offered += 1
        session = self._session_key
        if (
            session is None
            or snapshot.match_id != session.match_id
            or not 0 <= snapshot.sequence <= 10_000_000
            or dto_rejection_reasons(snapshot.cells)
        ):
            self.metrics.opening_snapshot_rejections += 1
            return False
        existing = self._opening_snapshot
        if existing is not None:
            if (
                existing.match_id != snapshot.match_id
                or board_state_hash(existing.cells) != board_state_hash(snapshot.cells)
            ):
                self.metrics.opening_snapshot_rejections += 1
                return False
            # A match may leave more than one MATCH_START DTO in the managed
            # heap. Live evidence showed identical 64-cell boards at srvSeq 1
            # and 3. Retain the newest transport sequence deterministically;
            # never replace it with an older duplicate found by scan order.
            if snapshot.sequence > existing.sequence:
                self._opening_snapshot = snapshot
            return True
        self._opening_snapshot = snapshot
        self.metrics.opening_snapshots_accepted += 1
        return True

    def offer_transport_board_snapshot(
        self, snapshot: OpeningBoardSnapshot, *, event_type: str
    ) -> bool:
        """Retain a decoded current-match board until its exact ACK is seen.

        The enclosing ChatMessageDTO and payload are validated by the caller's
        transport decoder.  This method binds the snapshot to the provider's
        current combat session, but deliberately does not make it publishable:
        ``poll`` must later observe the same ``srvSeq`` in MatchService._ackedSeqs.
        """

        if event_type != "MATCH_MOVE_RES":
            return False
        session = self._session_key
        if (
            session is None
            or snapshot.match_id != session.match_id
            or snapshot.sequence < 0
            or dto_rejection_reasons(snapshot.cells)
        ):
            return False
        candidate = CombatBatchSnapshot(
            snapshot.message_address,
            snapshot.sequence,
            snapshot.board_token_address,
            snapshot.cells,
        )
        identity = self._register(
            candidate, "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board"
        )
        self._transport_attested.add(identity)
        return True

    def capture_transient_batches(self) -> tuple[tuple[int, int, str], ...]:
        """Capture current-owner batches before their transient roots vanish.

        Captures are retained but remain ineligible until their exact sequence
        later appears in MatchService._ackedSeqs. No heap scan, target write or
        target method call occurs here.
        """

        self.metrics.transient_capture_polls += 1
        session = self._session_key
        if session is None or self._current_board is None or not self.target.is_running():
            return ()
        try:
            board = self._resolve_board()
            match_service = self._resolve_match_service()
            if (
                board is None
                or board.board_instance != self._current_board
                or match_service is None
            ):
                return ()
            match_id, _turn, _player, pending, _fusion = self._read_match_state(
                match_service
            )
            if match_id != session.match_id:
                return ()
            self._refresh_type_info()
        except (ExternalReadError, OSError, LayoutValidationError):
            return ()
        if self._batch_class is None:
            return ()

        before = set(self._tracked)

        def retain(candidate: CombatBatchSnapshot, source: str) -> None:
            identity = batch_identity(candidate)
            if (
                identity not in self._session_batch_baseline
                and not dto_rejection_reasons(candidate.cells)
            ):
                self._register(candidate, source)

        if pending is not None:
            try:
                retain(
                    read_combat_batch(
                        self.target.memory,
                        pending,
                        expected_class=int(self._batch_class),
                    ),
                    "MatchService.PendingCombat",
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                pass

        if self._board_ws_class is not None:
            for address in tuple(self._board_ws_addresses):
                try:
                    owner = read_board_ws_candidate(
                        self.target.memory,
                        address,
                        expected_class=int(self._board_ws_class),
                        expected_board=board.board_instance,
                    )
                    if owner.bootstrapped_match_id != match_id:
                        continue
                    queue = read_pending_queue(self.target.memory, owner.queue)
                    for batch_address in queue.batch_addresses:
                        retain(
                            read_combat_batch(
                                self.target.memory,
                                batch_address,
                                expected_class=int(self._batch_class),
                            ),
                            "BoardWsApplier._pendingBatches",
                        )
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue

        captured = tuple(
            sorted(set(self._tracked) - before, key=lambda value: (value[1], value[0]))
        )
        self.metrics.transient_batches_captured += len(captured)
        return captured

    def _read_match_state(
        self, match_service: int | None
    ) -> tuple[str | None, int | None, str | None, int | None, MemoryFusionState | None]:
        if match_service is None:
            return None, None, None, None, None
        match_id_pointer = struct.unpack(
            "<Q",
            self.target.memory.read(
                match_service + MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET, 8
            ),
        )[0]
        match_id = (
            read_il2cpp_string(
                self.target.memory, match_id_pointer, max_length=256
            )
            if is_canonical_user_pointer(match_id_pointer)
            else None
        )
        turn = struct.unpack(
            "<i",
            self.target.memory.read(
                match_service + MATCH_SERVICE_TURN_NUMBER_OFFSET, 4
            ),
        )[0]
        if not 0 <= turn <= 1_000_000:
            raise LayoutValidationError("MatchService.TurnNumber is implausible")
        username_pointer = struct.unpack(
            "<Q",
            self.target.memory.read(
                match_service + MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET, 8
            ),
        )[0]
        username = (
            read_il2cpp_string(self.target.memory, username_pointer, max_length=256)
            if is_canonical_user_pointer(username_pointer)
            else None
        )
        pending_raw = struct.unpack(
            "<Q",
            self.target.memory.read(
                match_service + MATCH_SERVICE_PENDING_COMBAT_OFFSET, 8
            ),
        )[0]
        pending = pending_raw if is_canonical_user_pointer(pending_raw) else None
        try:
            fusion = read_fusion_state(self.target.memory, match_service)
        except (ExternalReadError, OSError, LayoutValidationError):
            fusion = None
        return match_id or None, turn, username, pending, fusion

    def _publish_non_board_fusion_transition(
        self,
        *,
        acked_highest: int | None,
        board: Any,
        match_service: int,
        match_id: str,
        turn: int,
        current_turn_player: str | None,
        pending: int | None,
        memory_fusion: MemoryFusionState | None,
        action_before: ActionRuntimeSignals,
        array_before: Any,
        lifecycle: str | None,
        lifecycle_observation: CombatLifecycleObservation,
        session_key: CombatSessionKey,
    ) -> ProviderPoll | None:
        """Publish a double-sampled terminal EVOLVE without inventing a Board DTO."""

        current_all_dots = (
            array_before.elements
            if array_before is not None and array_before.layout_verified
            else None
        )
        sequence = _durable_non_board_fusion_transition(
            acked_highest=acked_highest,
            last_accepted_sequence=self._last_accepted_seq,
            last_accepted_turn=self._last_accepted_turn,
            current_turn=turn,
            last_local_move_sequence=self._last_accepted_local_move_sequence,
            action=action_before,
            previous_fusion=(
                self._last_published_state.fusion
                if self._last_published_state is not None
                else self._last_fusion
            ),
            current_fusion=memory_fusion,
            last_all_dots=self._last_accepted_all_dots,
            current_all_dots=current_all_dots,
            pending_batch=pending,
            current_turn_player=current_turn_player,
            retained_sequence=self._non_board_fusion_sequence,
        )
        if sequence is None or self._last_published_state is None:
            return None

        try:
            board_after = self._resolve_board()
            array_after = (
                observe_rectangular_reference_array(
                    self.target.memory, board_after.all_dots, (8, 8)
                )
                if board_after is not None
                and board_after.board_instance == board.board_instance
                else None
            )
            match_id_after, turn_after, player_after, pending_after, fusion_after = (
                self._read_match_state(match_service)
            )
            action_after = self._read_action_signals(match_service)
            timer = self._read_turn_timer(match_service)
            lifecycle_after = read_combat_lifecycle(
                self.target.resolver,
                board=board_after,
                match_id=match_id_after,
                match_over=action_after.match_over,
                deferred_game_over=action_after.deferred_game_over,
            )
        except (ExternalReadError, OSError, LayoutValidationError):
            return ProviderPoll(
                None,
                False,
                "non_board_fusion_transition_unstable",
                lifecycle,
                fusion_changed=True,
                session_key=session_key,
                combat_lifecycle=lifecycle_observation,
            )

        stable = bool(
            board_after is not None
            and match_id_after == match_id
            and turn_after == turn
            and player_after == current_turn_player
            and pending_after is None
            and fusion_after is not None
            and fusion_after.last_attempt_turn == turn
            and (
                fusion_after.used_successfully
                == memory_fusion.used_successfully
            )
            and action_after == action_before
            and lifecycle_after.state is CombatLifecycleState.ACTIVE
            and array_after is not None
            and array_after.layout_verified
            and array_after.elements == current_all_dots
            and board.is_board_ready
            and board_after.is_board_ready
            and not board.is_cascade_running
            and not board_after.is_cascade_running
            and board.current_state == board_after.current_state == 1
            and not board.has_destroyed_this_turn
            and not board_after.has_destroyed_this_turn
            and not board.is_processing_ui
            and not board_after.is_processing_ui
            and not board.is_game_over
            and not board_after.is_game_over
            and not board.is_mega2_panel_open
            and not board_after.is_mega2_panel_open
            and not board.is_mega1_panel_open
            and not board_after.is_mega1_panel_open
            and not board.is_using_legend_card
            and not board_after.is_using_legend_card
            and not board.is_using_mega
            and not board_after.is_using_mega
            and not board.is_resuming
            and not board_after.is_resuming
        )
        if not stable:
            return ProviderPoll(
                None,
                False,
                "non_board_fusion_transition_unstable",
                lifecycle,
                fusion_changed=True,
                session_key=session_key,
                combat_lifecycle=lifecycle_observation,
            )

        fusion = _canonical_fusion(fusion_after, None)
        if fusion is None:  # pragma: no cover - narrowed by stable
            return None
        participants = self._participants(board.active)
        player = next(
            (
                participant
                for participant in participants
                if participant.is_local is True
            ),
            None,
        )
        opponents = tuple(
            participant
            for participant in participants
            if player is None or participant.actor_number != player.actor_number
        )
        local_turn = action_after.is_local_turn(current_turn_player)
        modal_open = bool(
            board_after.is_mega2_panel_open
            or board_after.is_mega1_panel_open
            or board_after.is_using_legend_card
            or board_after.is_using_mega
        )
        client_move_allowed = bool(
            not board_after.is_game_over
            and board_after.active is not None
            and bool(match_id)
            and not action_after.start_gate_paused
            and local_turn is True
            and not board_after.is_processing_ui
            and not board_after.has_destroyed_this_turn
            and board_after.current_state == 1
        )
        state = replace(
            self._last_published_state,
            timestamp=utc_timestamp(),
            battle=replace(
                self._last_published_state.battle,
                srv_seq=sequence,
                turn_number=turn,
                current_turn_player=current_turn_player,
                acknowledged=True,
                latest=True,
                # The board itself is still the exact previously published
                # ACK-attested DTO; Fusion changed no Dot pointer and both
                # allDots samples matched. Preserve that authoritative board
                # provenance while adding the non-board Fusion witness.
                sources=tuple(
                    dict.fromkeys(
                        self._last_published_state.battle.sources
                        + (
                            "MatchService.LocalFusionAttempt+unchanged_Board.allDots",
                        )
                    )
                ),
                is_board_ready=board_after.is_board_ready,
                is_cascade_running=board_after.is_cascade_running,
                board_current_state=board_after.current_state,
                board_has_destroyed_this_turn=board_after.has_destroyed_this_turn,
                board_is_processing_ui=board_after.is_processing_ui,
                board_is_game_over=board_after.is_game_over,
                board_modal_open=modal_open,
                board_is_resuming=board_after.is_resuming,
                match_over=action_after.match_over,
                deferred_game_over=action_after.deferred_game_over,
                start_gate_paused=action_after.start_gate_paused,
                clock_paused=action_after.clock_paused,
                clock_pause_reason=action_after.clock_pause_reason,
                turn_duration_seconds=timer.duration_seconds,
                turn_time_remaining_seconds=timer.remaining_seconds,
                turn_timer_source=timer.source,
                connection_ready=action_after.connection_ready,
                reconnecting=action_after.reconnecting,
                match_resyncing=action_after.match_resyncing,
                presentation_busy=False,
                local_username=action_after.local_username,
                is_local_turn=local_turn,
                local_actor_number=(
                    player.actor_number if player is not None else None
                ),
                client_move_allowed=client_move_allowed,
                local_move_sequence=action_after.local_move_sequence,
                last_move_from_col=action_after.last_move_from_col,
                last_move_from_row=action_after.last_move_from_row,
                last_move_to_col=action_after.last_move_to_col,
                last_move_to_row=action_after.last_move_to_row,
                last_move_sequence=action_after.last_move_sequence,
            ),
            player=player,
            opponents=opponents,
            participants=participants,
            cards=self._last_cards,
            fusion=fusion,
        )
        if sequence != self._last_accepted_seq:
            self.metrics.server_transitions += 1
            self.metrics.stable_published += 1
        self._last_fusion = fusion
        self._last_accepted_seq = sequence
        self._last_accepted_turn = turn
        self._last_accepted_local_move_sequence = action_after.local_move_sequence
        self._last_accepted_all_dots = current_all_dots
        self._non_board_fusion_sequence = sequence
        self._last_published_state = state
        return ProviderPoll(
            state,
            True,
            "stable_non_board_fusion_transition",
            lifecycle,
            fusion_changed=True,
            confirmations=2,
            session_key=session_key,
            combat_lifecycle=lifecycle_observation,
        )

    def _participants(
        self, active: int | None
    ) -> tuple[ParticipantState, ...]:
        if active is None or self._player_stats_class is None:
            return ()
        try:
            return read_active_participants(
                self.target.memory,
                active,
                expected_class=self._player_stats_class,
            )
        except (ExternalReadError, OSError, LayoutValidationError, ValueError):
            return ()

    def poll(self) -> ProviderPoll:
        self.metrics.polls += 1
        if not self.target.is_running():
            return ProviderPoll(None, False, "process_exited", "process_exited")
        try:
            board = self._resolve_board()
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            self.metrics.read_errors += 1
            return ProviderPoll(None, False, f"board_read_error:{exc}")
        match_service = self._resolve_match_service()
        lifecycle_match_id: str | None = None
        lifecycle_match_over: bool | None = None
        lifecycle_deferred: bool | None = None
        if match_service is not None:
            try:
                lifecycle_match_id = self._read_string_field(
                    match_service, MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET
                )
                lifecycle_match_over = self.target.resolver.read_bool(
                    match_service + MATCH_SERVICE_MATCH_OVER_OFFSET
                )
                lifecycle_deferred = self.target.resolver.read_bool(
                    match_service + MATCH_SERVICE_HAS_DEFERRED_GAME_OVER_OFFSET
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                lifecycle_match_id = None
                lifecycle_match_over = None
                lifecycle_deferred = None
        lifecycle_observation = read_combat_lifecycle(
            self.target.resolver,
            board=board,
            match_id=lifecycle_match_id,
            match_over=lifecycle_match_over,
            deferred_game_over=lifecycle_deferred,
        )
        lifecycle_state = lifecycle_observation.state
        candidate_session = self._lifecycle_tracker.observe(
            lifecycle_state,
            board.board_instance if board is not None else None,
            lifecycle_match_id,
        )

        if lifecycle_state is not CombatLifecycleState.ACTIVE:
            # POSTMATCH may still retain the exact Board -> Active ownership
            # long enough to expose the server-applied terminal PlayerStats.
            # Capture it before _clear_lifecycle() deliberately invalidates all
            # session-scoped pointers.  Empty/ambiguous evidence remains
            # UNKNOWN; never reuse the last ACTIVE stats as a terminal result.
            terminal_participants: tuple[ParticipantState, ...] = ()
            if (
                lifecycle_state is CombatLifecycleState.POSTMATCH
                and board is not None
                and board.active is not None
            ):
                terminal_participants = self._participants(board.active)
            terminal_player = next(
                (
                    participant
                    for participant in terminal_participants
                    if participant.is_local is True
                ),
                None,
            )
            terminal_opponents = tuple(
                participant
                for participant in terminal_participants
                if terminal_player is None
                or participant.actor_number != terminal_player.actor_number
            )
            lifecycle = (
                lifecycle_state.value
                if lifecycle_state is not self._last_combat_lifecycle
                else None
            )
            if self._current_board is not None:
                if board is None:
                    self.metrics.board_losses += 1
                self._clear_lifecycle()
            if (
                board is None
                and lifecycle_state in {
                    CombatLifecycleState.LOBBY,
                    CombatLifecycleState.STALE_SERVER_MATCH,
                }
                and self._needs_lobby_baseline
            ):
                self._refresh_type_info()
                self._refresh_lobby_baseline()
            phase = (
                GamePhase.LOBBY
                if lifecycle_state is CombatLifecycleState.LOBBY
                else GamePhase.UNKNOWN
            )
            self._last_phase = phase
            self._last_combat_lifecycle = lifecycle_state
            signals = lifecycle_observation.signals
            return ProviderPoll(
                GameState(
                    phase,
                    utc_timestamp(),
                    battle=BattleState(
                        combat_lifecycle=lifecycle_state,
                        board_instance=signals.board_instance,
                        match_id=signals.match_id,
                        is_board_ready=signals.board_ready,
                        board_is_game_over=signals.board_game_over,
                        match_over=signals.match_over,
                        deferred_game_over=signals.deferred_game_over,
                    ),
                    player=terminal_player,
                    opponents=terminal_opponents,
                    participants=terminal_participants,
                ),
                False,
                lifecycle_observation.reason,
                lifecycle,
                combat_lifecycle=lifecycle_observation,
            )

        if not self._lobby_baseline_ready:
            return ProviderPoll(
                None,
                False,
                "lobby_batch_baseline_unavailable",
                combat_lifecycle=lifecycle_observation,
            )

        if self._card_ui_class is None:
            self._card_ui_class = self.target.resolver.resolve_type_info_class(
                CARD_UI_TYPE_INFO_RVA
            )
        if self._fusion_ui_class is None:
            self._fusion_ui_class = self.target.resolver.resolve_type_info_class(
                FUSION_CARD_UI_TYPE_INFO_RVA
            )
        if self._player_stats_class is None:
            self._player_stats_class = self.target.resolver.resolve_type_info_class(
                ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
            )
        if match_service is None:
            self._gate.observe(("match_service_missing",), False)
            return ProviderPoll(None, False, "match_service_unavailable")
        try:
            match_id, turn, current_turn_player, pending, memory_fusion = (
                self._read_match_state(match_service)
            )
            action_before = self._read_action_signals(match_service)
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            self.metrics.read_errors += 1
            return ProviderPoll(None, False, f"match_state_read_error:{exc}")
        if match_id is None:
            self._gate.observe(("match_id_missing",), False)
            return ProviderPoll(None, False, "current_match_id_unavailable")

        if match_id != lifecycle_match_id:
            self._lifecycle_tracker.invalidate()
            if self._current_board is not None:
                self._clear_lifecycle()
            return ProviderPoll(
                None,
                False,
                "match_id_changed_during_lifecycle_sample",
                combat_lifecycle=lifecycle_observation,
            )
        session_from_tracker = candidate_session
        if session_from_tracker is None:
            raise AssertionError("ACTIVE lifecycle must issue a combat session")
        lifecycle = None
        if self._session_key != session_from_tracker:
            self._reset_lifecycle(board.board_instance, match_id, session_from_tracker)
            lifecycle = "board_found"
        session_key = self._session_key
        if session_key is None:
            raise AssertionError("combat session must be initialized")
        self._last_phase = GamePhase.COMBAT
        self._last_combat_lifecycle = CombatLifecycleState.ACTIVE
        self._scan_number += 1

        try:
            self._refresh_type_info()
        except (ExternalReadError, OSError) as exc:
            self.metrics.read_errors += 1
            return ProviderPoll(
                None,
                False,
                f"type_info_read_error:{exc}",
                lifecycle,
                session_key=session_key,
            )
        type_info_blocker = _combat_type_info_blocker(
            batch_class=self._batch_class,
            board_ws_class=self._board_ws_class,
            opening_snapshot_available=bool(
                self._opening_snapshot is not None
                and self._opening_snapshot.match_id == match_id
            ),
        )
        if type_info_blocker is not None:
            self._gate.observe(("type_info_unavailable",), False)
            return ProviderPoll(
                None,
                False,
                type_info_blocker,
                lifecycle,
                session_key=session_key,
            )

        try:
            array_before = observe_rectangular_reference_array(
                self.target.memory, board.all_dots, (8, 8)
            )
        except (ExternalReadError, OSError, LayoutValidationError):
            array_before = None

        # The current BoardWsApplier is a validated, Board/match-owned direct
        # anchor. Once learned, poll it without a heap scan so the short-lived
        # PendingCombat/queue references are sampled at the configured 0.15 s
        # rate. Phase 2B.5 runtime evidence showed 2.1--2.5 s telemetry scans
        # consistently missed every transient owner in three full lifecycles.
        scan_matches: dict[str, tuple[int, ...]] = {
            "board_ws": tuple(self._board_ws_addresses),
            "board": (),
            "card_ui": tuple(self._card_addresses),
            "fusion_ui": tuple(self._fusion_ui_addresses),
        }
        needs_owner_scan = not self._board_ws_addresses
        needs_card_scan = bool(
            self._card_ui_class is not None
            and not self._card_addresses
            and (self._scan_number in (1, 4, 12) or self._scan_number % 24 == 0)
        )
        needs_fusion_ui_scan = bool(
            self._fusion_ui_class is not None
            and not self._fusion_ui_addresses
            and (self._scan_number in (1, 4, 12) or self._scan_number % 24 == 0)
        )
        participants_hint = self._participants(board.active)
        needs_extended_fusion_ui_scan = bool(
            self.config.extended_fusion_ui_region_mib is not None
            and self._fusion_ui_class is not None
            and not self._fusion_ui_addresses
            and _extended_fusion_scan_relevant(
                memory_fusion,
                participants_hint,
                is_local_turn=action_before.is_local_turn(current_turn_player),
                turn=turn,
                last_scanned_turn=self._extended_fusion_scan_turn,
            )
        )
        if needs_owner_scan or needs_card_scan or needs_fusion_ui_scan:
            try:
                needles = {}
                if needs_owner_scan:
                    needles["board_ws"] = int(self._board_ws_class)
                if needs_card_scan:
                    needles["card_ui"] = int(self._card_ui_class)
                if needs_fusion_ui_scan:
                    needles["fusion_ui"] = int(self._fusion_ui_class)
                scan = self._scan(needles, force_full=self._force_full_scan)
                self._force_full_scan = False
                for name in needles:
                    scan_matches[name] = scan.matches[name]
            except (ExternalReadError, OSError) as exc:
                self.metrics.read_errors += 1
                return ProviderPoll(
                    None,
                    False,
                    f"candidate_scan_error:{exc}",
                    lifecycle,
                    session_key=session_key,
                )
        if needs_extended_fusion_ui_scan:
            # Record before scanning so a partially unreadable region cannot
            # produce an unbounded retry loop during the same 14-second turn.
            self._extended_fusion_scan_turn = turn
            try:
                extended_scan = self._scan_extended_fusion_ui()
                scan_matches["fusion_ui"] = tuple(
                    sorted(
                        set(scan_matches.get("fusion_ui", ()))
                        | set(extended_scan.matches.get("fusion_ui", ()))
                    )
                )
            except (ExternalReadError, OSError) as exc:
                self.metrics.read_errors += 1
                return ProviderPoll(
                    None,
                    False,
                    f"extended_fusion_ui_scan_error:{exc}",
                    lifecycle,
                    session_key=session_key,
                )

        rejection_details: list[str] = []
        active_pending: set[tuple[int, int, str]] = set()
        if pending is not None:
            if self._batch_class is None:
                self._gate.observe(("batch_type_info_unavailable",), False)
                return ProviderPoll(
                    None,
                    False,
                    "combat_batch_type_info_not_initialized",
                    lifecycle,
                    session_key=session_key,
                )
            try:
                candidate = read_combat_batch(
                    self.target.memory, pending, expected_class=int(self._batch_class)
                )
                reasons = dto_rejection_reasons(candidate.cells)
                if reasons:
                    rejection_details.extend(
                        f"PendingCombat:{reason}" for reason in reasons
                    )
                else:
                    active_pending.add(
                        self._register(candidate, "MatchService.PendingCombat")
                    )
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                rejection_details.append(f"PendingCombat:layout:{exc}")

        valid_owners: list[tuple[BoardWsObservation, QueueObservation]] = []
        queue_active: set[tuple[int, int, str]] = set()
        owner_addresses = set(scan_matches["board_ws"]) | self._board_ws_addresses
        refreshed_owner_addresses: set[int] = set()
        cached_owner_addresses = set(self._board_ws_addresses)
        for address in owner_addresses:
            try:
                owner = read_board_ws_candidate(
                    self.target.memory,
                    address,
                    expected_class=int(self._board_ws_class),
                    expected_board=board.board_instance,
                )
                if owner.bootstrapped_match_id != match_id:
                    continue
                queue = read_pending_queue(self.target.memory, owner.queue)
                refreshed_owner_addresses.add(address)
                self._board_ws_address_misses[address] = 0
                valid_owners.append((owner, queue))
                for batch_address in queue.batch_addresses:
                    try:
                        candidate = read_combat_batch(
                            self.target.memory,
                            batch_address,
                            expected_class=int(self._batch_class),
                        )
                        reasons = dto_rejection_reasons(candidate.cells)
                        if reasons:
                            rejection_details.extend(
                                f"pendingQueue:{reason}" for reason in reasons
                            )
                            continue
                        queue_active.add(
                            self._register(
                                candidate, "BoardWsApplier._pendingBatches"
                            )
                        )
                    except (ExternalReadError, OSError, LayoutValidationError) as exc:
                        rejection_details.append(f"pendingQueue:layout:{exc}")
            except (ExternalReadError, OSError, LayoutValidationError):
                continue
        retained_owner_addresses: set[int] = set()
        for address in cached_owner_addresses - refreshed_owner_addresses:
            misses = self._board_ws_address_misses.get(address, 0) + 1
            self._board_ws_address_misses[address] = misses
            if misses <= OWNER_ADDRESS_MISS_GRACE_POLLS:
                retained_owner_addresses.add(address)
            else:
                self._board_ws_address_misses.pop(address, None)
        self._board_ws_addresses = (
            refreshed_owner_addresses | retained_owner_addresses
        )
        if len(valid_owners) > 1:
            rejection_details.append(
                f"ambiguous_board_ws_owners:{len(valid_owners)}"
            )

        try:
            acked: AckedSequenceSnapshot = read_acked_sequences(
                self.target.memory, int(match_service)
            )
            self.metrics.ack_reads += 1
            self.metrics.highest_acked_sequence = acked.highest
        except (ExternalReadError, OSError, LayoutValidationError, TypeError) as exc:
            self.metrics.read_errors += 1
            self._gate.observe(("ack_read_error",), False)
            return ProviderPoll(
                None,
                False,
                f"acked_sequence_read_error:{exc}",
                lifecycle,
                session_key=session_key,
            )

        non_board_fusion_poll = self._publish_non_board_fusion_transition(
            acked_highest=acked.highest,
            board=board,
            match_service=int(match_service),
            match_id=match_id,
            turn=int(turn),
            current_turn_player=current_turn_player,
            pending=pending,
            memory_fusion=memory_fusion,
            action_before=action_before,
            array_before=array_before,
            lifecycle=lifecycle,
            lifecycle_observation=lifecycle_observation,
            session_key=session_key,
        )
        if non_board_fusion_poll is not None:
            return non_board_fusion_poll

        ack_values = set(acked.sequences)
        for identity in self._transport_attested:
            if identity in self._tracked and identity[1] in ack_values:
                self._ack_attested.add(identity)
                self._sources.setdefault(identity, set()).add(
                    "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board+"
                    "MatchService._ackedSeqs"
                )
        self._ack_attested.update(
            _owner_batches_confirmed_by_ack(
                self._tracked,
                self._owner_attested,
                ack_values,
            )
        )
        if acked.highest is not None:
            if self._batch_class is None:
                self._gate.observe(("batch_type_info_unavailable",), False)
                return ProviderPoll(
                    None,
                    False,
                    "combat_batch_type_info_not_initialized",
                    lifecycle,
                    session_key=session_key,
                )
            have_highest = any(
                identity[1] == acked.highest
                for identity in self._ack_attested
            )
            (
                self._direct_owner_grace_seq,
                self._direct_owner_grace_polls,
                defer_heap_scan,
            ) = _next_direct_owner_grace(
                acked_highest=acked.highest,
                have_highest=have_highest,
                valid_owner_count=len(valid_owners),
                previous_sequence=self._direct_owner_grace_seq,
                previous_polls=self._direct_owner_grace_polls,
            )
            if defer_heap_scan:
                self.metrics.unstable_skips += 1
                self._gate.observe(("await_direct_owner_batch", acked.highest), False)
                return ProviderPoll(
                    None,
                    False,
                    "awaiting_direct_owner_batch_capture",
                    lifecycle,
                    session_key=session_key,
                )
            if not have_highest:
                if not self.config.allow_ack_heap_scan:
                    self.metrics.unstable_skips += 1
                    self._gate.observe(
                        ("await_transport_board", acked.highest), False
                    )
                    return ProviderPoll(
                        None,
                        False,
                        "awaiting_transport_board_capture",
                        lifecycle,
                        session_key=session_key,
                    )
                force_batch_full = self._batch_scan_miss_seq == acked.highest
                try:
                    batch_scan = self._scan_ack_heap(
                        force_full=force_batch_full,
                    )
                    self.metrics.ack_batch_scans += 1
                    prior_scan_was_full = self._last_scan_was_full
                    batch_hits = set(batch_scan.matches["batch"])
                    heap_batches = validate_combat_batch_hits(
                        self.target.memory,
                        batch_hits | self._batch_addresses,
                        batch_class=int(self._batch_class),
                    )
                except (ExternalReadError, OSError) as exc:
                    self.metrics.read_errors += 1
                    return ProviderPoll(
                        None,
                        False,
                        f"acked_batch_scan_error:{exc}",
                        lifecycle,
                        session_key=session_key,
                    )
                self._batch_addresses = {
                    candidate.address
                    for candidate in heap_batches
                    if batch_identity(candidate) not in self._session_batch_baseline
                }
                for candidate in heap_batches:
                    identity = batch_identity(candidate)
                    if identity in self._session_batch_baseline:
                        continue
                    self.metrics.unowned_batches_seen += 1
                    reasons = dto_rejection_reasons(candidate.cells)
                    if reasons:
                        rejection_details.extend(
                            f"ackedHeap:{reason}" for reason in reasons
                        )
                        continue
                    if candidate.sequence in ack_values:
                        registered = self._register(
                            candidate,
                            "MatchService._ackedSeqs+postLobbyHeap",
                        )
                        self._ack_attested.add(registered)
                if _needs_immediate_full_ack_rescan(
                    acked_highest=acked.highest,
                    ack_attested=self._ack_attested,
                    prior_scan_was_full=prior_scan_was_full,
                ):
                    try:
                        full_batch_scan = self._scan_ack_heap(force_full=True)
                        self.metrics.ack_batch_scans += 1
                        full_heap_batches = validate_combat_batch_hits(
                            self.target.memory,
                            set(full_batch_scan.matches["batch"])
                            | self._batch_addresses,
                            batch_class=int(self._batch_class),
                        )
                    except (ExternalReadError, OSError) as exc:
                        self.metrics.read_errors += 1
                        return ProviderPoll(
                            None,
                            False,
                            f"acked_batch_scan_error:{exc}",
                            lifecycle,
                            session_key=session_key,
                        )
                    self._batch_addresses.update(
                        candidate.address
                        for candidate in full_heap_batches
                        if batch_identity(candidate)
                        not in self._session_batch_baseline
                    )
                    for candidate in full_heap_batches:
                        identity = batch_identity(candidate)
                        if identity in self._session_batch_baseline:
                            continue
                        self.metrics.unowned_batches_seen += 1
                        reasons = dto_rejection_reasons(candidate.cells)
                        if reasons:
                            rejection_details.extend(
                                f"ackedHeapFull:{reason}" for reason in reasons
                            )
                            continue
                        if candidate.sequence in ack_values:
                            registered = self._register(
                                candidate,
                                "MatchService._ackedSeqs+postLobbyHeapFull",
                            )
                            self._ack_attested.add(registered)
                if any(
                    identity[1] == acked.highest
                    for identity in self._ack_attested
                ):
                    self._batch_scan_miss_seq = None
                else:
                    self._batch_scan_miss_seq = acked.highest

        cards: tuple[CardState, ...] = ()
        if self._card_ui_class is not None and board.active is not None:
            card_candidates = validate_combat_card_hits(
                self.target.memory,
                set(scan_matches.get("card_ui", ())) | self._card_addresses,
                expected_class=self._card_ui_class,
                expected_board=board.board_instance,
                expected_active=board.active,
            )
            self._card_addresses = {card.address for card in card_candidates}
            cards = tuple(_canonical_card(card) for card in card_candidates)
        fusion_ui = None
        if self._fusion_ui_class is not None:
            fusion_ui_candidates = validate_fusion_card_ui_hits(
                self.target.memory,
                set(scan_matches.get("fusion_ui", ())) | self._fusion_ui_addresses,
                expected_class=self._fusion_ui_class,
            )
            self._fusion_ui_addresses = {
                candidate.address for candidate in fusion_ui_candidates
            }
            if len(fusion_ui_candidates) == 1:
                fusion_ui = fusion_ui_candidates[0]
        fusion = _canonical_fusion(memory_fusion, fusion_ui)
        cards_changed = cards != self._last_cards
        fusion_changed = fusion != self._last_fusion
        self._last_cards = cards
        self._last_fusion = fusion

        opening_hash = (
            board_state_hash(self._opening_snapshot.cells)
            if self._opening_snapshot is not None
            and self._opening_snapshot.match_id == match_id
            else None
        )
        latest_ack_hashes = {
            identity[2]
            for identity in self._ack_attested
            if acked.highest is not None and identity[1] == acked.highest
        }
        opening_current_at_latest_ack = bool(
            opening_hash is not None
            and len(latest_ack_hashes) == 1
            and opening_hash in latest_ack_hashes
        )
        opening_authoritative = bool(
            self._opening_snapshot is not None
            and self._opening_snapshot.match_id == match_id
            and action_before.local_move_sequence == 0
            and action_before.last_move_sequence in (None, -1, 0)
            and turn in (0, 1)
            and (acked.highest is None or opening_current_at_latest_ack)
        )
        if opening_authoritative:
            opening = self._opening_snapshot
            if opening is None:  # pragma: no cover - narrowed by the predicate
                raise AssertionError("opening snapshot unexpectedly absent")
            opening_batch = CombatBatchSnapshot(
                opening.message_address,
                opening.sequence,
                opening.board_token_address,
                opening.cells,
            )
            opening_identity = self._register(
                opening_batch,
                "ChatMessageDTO.MATCH_START.matchPayload.board",
            )
            eligible = [opening_identity]
        else:
            eligible = [
                identity
                for identity in self._ack_attested
                if identity[1] in ack_values
                and identity not in self._session_batch_baseline
                and not dto_rejection_reasons(self._tracked[identity].cells)
            ]
        if rejection_details:
            self.metrics.dto_rejections += len(rejection_details)
        if not eligible:
            self.metrics.unstable_skips += 1
            self._gate.observe(("missing_owner_batch",), False)
            return ProviderPoll(
                None,
                False,
                "no_current_ack_attested_complete_batch",
                lifecycle,
                cards_changed,
                fusion_changed,
                session_key=session_key,
                dto_rejections=tuple(rejection_details),
            )

        highest = max(identity[1] for identity in eligible)
        if not opening_authoritative and highest != acked.highest:
            self.metrics.unstable_skips += 1
            self._gate.observe(("acked_batch_lag",), False)
            return ProviderPoll(
                None,
                False,
                "latest_acked_batch_not_resolved",
                lifecycle,
                cards_changed,
                fusion_changed,
                session_key=session_key,
                dto_rejections=tuple(rejection_details),
            )
        latest = [identity for identity in eligible if identity[1] == highest]
        selected = _select_latest_identity(
            latest, self._owner_attested | self._transport_attested
        )
        if selected is None:
            self.metrics.ambiguous_latest_skips += 1
            self._gate.observe(("ambiguous",), False)
            return ProviderPoll(
                None,
                False,
                "ambiguous_latest_sequence",
                lifecycle,
                cards_changed,
                fusion_changed,
                session_key=session_key,
                dto_rejections=tuple(rejection_details),
            )
        sequence_reason = sequence_rejection_reason(
            self._last_accepted_seq,
            self._last_accepted_hash,
            highest,
            selected[2],
        )
        if sequence_reason == "stale_sequence":
            self.metrics.stale_skips += 1
            self._gate.observe(("stale",), False)
            return ProviderPoll(
                None,
                False,
                "stale_sequence",
                lifecycle,
                cards_changed,
                fusion_changed,
                session_key=session_key,
            )
        if sequence_reason == "sequence_hash_changed":
            self.metrics.ambiguous_latest_skips += 1
            self._gate.observe(("sequence_reused",), False)
            return ProviderPoll(
                None,
                False,
                "sequence_hash_changed",
                lifecycle,
                cards_changed,
                fusion_changed,
                session_key=session_key,
            )
        if self._latest_identity is None or (
            selected[1], selected[2]
        ) != (self._latest_identity[1], self._latest_identity[2]):
            self.metrics.server_transitions += 1
        self._latest_identity = selected
        batch = self._tracked[selected]

        # Dot discovery is audit-only in Phase 2B.5.  Bounded hits explain how
        # much of the component population is discoverable without making it a
        # hidden production dependency.
        dots = (
            validate_dot_pointer_hits(
                self.target.memory,
                self._dot_pointer_hits | set(scan_matches.get("board", ())),
                board_pointer=board.board_instance,
                dot_class=int(self._dot_class),
            )
            if self._dot_class is not None
            else DotCandidateResult(
                0,
                (),
                {},
                tuple((row, col) for row in range(8) for col in range(8)),
                {},
            )
        )
        self._dot_pointer_hits = {
            candidate.address + 0x48 for candidate in dots.candidates
        }
        check = dot_crosscheck(batch, dots)
        if len(dots.by_coordinate) == 64 and not dots.duplicate_coordinates:
            self.metrics.dot_complete_polls += 1
        else:
            self.metrics.dot_incomplete_polls += 1

        owner_after_idle = False
        try:
            board_after = self._resolve_board()
            array_after = (
                observe_rectangular_reference_array(
                    self.target.memory, board_after.all_dots, (8, 8)
                )
                if board_after is not None
                and board_after.board_instance == board.board_instance
                else None
            )
            match_id_after, turn_after, player_after, pending_after, _fusion_after = (
                self._read_match_state(match_service)
            )
            action_after = self._read_action_signals(match_service)
            lifecycle_after = read_combat_lifecycle(
                self.target.resolver,
                board=board_after,
                match_id=match_id_after,
                match_over=action_after.match_over,
                deferred_game_over=action_after.deferred_game_over,
            )
            if len(valid_owners) == 1:
                owner_after = read_board_ws_candidate(
                    self.target.memory,
                    valid_owners[0][0].address,
                    expected_class=int(self._board_ws_class),
                    expected_board=board.board_instance,
                )
                queue_after = read_pending_queue(
                    self.target.memory, owner_after.queue
                )
                owner_after_idle = bool(
                    owner_after.bootstrapped_match_id == match_id
                    and not owner_after.render_running
                    and queue_after.size == 0
                )
        except (ExternalReadError, OSError, LayoutValidationError):
            board_after = None
            array_after = None
            match_id_after = None
            turn_after = None
            player_after = None
            pending_after = None
            action_after = None
            lifecycle_after = None
        owner_idle = bool(
            len(valid_owners) == 1
            and not valid_owners[0][0].render_running
            and valid_owners[0][1].size == 0
            and owner_after_idle
            and selected not in queue_active
            and selected not in active_pending
            and pending_after is None
        )
        presentation_idle = _presentation_idle_for_publication(
            opening_authoritative=opening_authoritative,
            owner_idle=owner_idle,
            pending_before=pending,
            pending_after=pending_after,
            in_flight_before=action_before.in_flight_batches,
            in_flight_after=(
                action_after.in_flight_batches if action_after is not None else None
            ),
        )
        array_stable = bool(
            array_before is not None
            and array_after is not None
            and array_before.layout_verified
            and array_after.layout_verified
            and array_before.elements == array_after.elements
        )
        flags_stable = bool(
            board_after is not None
            and match_id_after == match_id
            and turn_after == turn
            and player_after == current_turn_player
            and action_after == action_before
            and lifecycle_after is not None
            and lifecycle_after.state is CombatLifecycleState.ACTIVE
            and lifecycle_after.signals.current_rig
            == lifecycle_observation.signals.current_rig
            and board.is_board_ready
            and board_after.is_board_ready
            and not board.is_cascade_running
            and not board_after.is_cascade_running
            and board.current_state == board_after.current_state
            and board.has_destroyed_this_turn
            == board_after.has_destroyed_this_turn
            and board.is_processing_ui == board_after.is_processing_ui
            and board.is_game_over == board_after.is_game_over
            and board.is_mega2_panel_open == board_after.is_mega2_panel_open
            and board.is_mega1_panel_open == board_after.is_mega1_panel_open
            and board.is_using_legend_card == board_after.is_using_legend_card
            and board.is_using_mega == board_after.is_using_mega
            and board.is_resuming == board_after.is_resuming
        )
        try:
            model = to_board_state(batch.cells)
        except ValueError as exc:
            model = None
            rejection_details.append(f"model:{exc}")
        signals_valid = bool(
            presentation_idle and flags_stable and array_stable and model is not None
        )
        stable, confirmations = self._gate.observe(
            (
                session_key,
                batch.sequence,
                selected[2],
                array_before.elements if array_before is not None else None,
            ),
            signals_valid,
        )
        if not stable or model is None:
            self.metrics.unstable_skips += 1
            if not presentation_idle and len(valid_owners) != 1:
                reason = "presentation_owner_unavailable"
            elif not presentation_idle:
                reason = "presentation_busy_or_batch_pending"
            elif not flags_stable:
                reason = "board_flags_or_session_changed"
            elif not array_stable:
                reason = "all_dots_array_changed"
            else:
                reason = "awaiting_stability_confirmation"
            return ProviderPoll(
                None,
                False,
                reason,
                lifecycle,
                cards_changed,
                fusion_changed,
                check,
                confirmations,
                session_key,
                tuple(rejection_details),
            )

        participants = self._participants(board.active)
        player = next(
            (participant for participant in participants if participant.is_local is True),
            None,
        )
        opponents = tuple(
            participant
            for participant in participants
            if player is None or participant.actor_number != player.actor_number
        )
        local_turn = action_before.is_local_turn(current_turn_player)
        modal_open = bool(
            board.is_mega2_panel_open
            or board.is_mega1_panel_open
            or board.is_using_legend_card
            or board.is_using_mega
        )
        client_move_allowed = bool(
            not board.is_game_over
            and board.active is not None
            and bool(match_id)
            and not action_before.start_gate_paused
            and local_turn is True
            and not board.is_processing_ui
            and not board.has_destroyed_this_turn
            and board.current_state == 1
        )
        try:
            timer = self._read_turn_timer(match_service)
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            self.metrics.read_errors += 1
            return ProviderPoll(
                None,
                False,
                f"turn_timer_read_error:{exc}",
                lifecycle,
                cards_changed,
                fusion_changed,
                check,
                confirmations,
                session_key,
                tuple(rejection_details),
            )
        state = GameState(
            phase=GamePhase.COMBAT,
            timestamp=utc_timestamp(),
            board=model,
            battle=BattleState(
                combat_lifecycle=CombatLifecycleState.ACTIVE,
                board_instance=board.board_instance,
                srv_seq=batch.sequence,
                turn_number=turn,
                current_turn_player=current_turn_player,
                stable=True,
                board_hash=selected[2],
                sources=tuple(sorted(self._sources[selected])),
                session_key=session_key,
                match_id=match_id,
                acknowledged=not opening_authoritative,
                latest=True,
                is_board_ready=board.is_board_ready,
                is_cascade_running=board.is_cascade_running,
                board_current_state=board.current_state,
                board_has_destroyed_this_turn=board.has_destroyed_this_turn,
                board_is_processing_ui=board.is_processing_ui,
                board_is_game_over=board.is_game_over,
                board_modal_open=modal_open,
                board_is_resuming=board.is_resuming,
                match_over=action_before.match_over,
                deferred_game_over=action_before.deferred_game_over,
                start_gate_paused=action_before.start_gate_paused,
                clock_paused=action_before.clock_paused,
                clock_pause_reason=action_before.clock_pause_reason,
                turn_duration_seconds=timer.duration_seconds,
                turn_time_remaining_seconds=timer.remaining_seconds,
                turn_timer_source=timer.source,
                # MATCH_AFK_WARN exposes idleCount only in a transient event.
                # No durable game-owned backing field is proven in this build.
                # AFK/idle values are transient server-payload fields.  The
                # provider must not synthesize the commonly observed 3 limit.
                consecutive_passes=None,
                consecutive_pass_threshold=None,
                consecutive_pass_source=None,
                connection_ready=action_before.connection_ready,
                reconnecting=action_before.reconnecting,
                match_resyncing=action_before.match_resyncing,
                presentation_busy=action_before.in_flight_batches > 0,
                local_username=action_before.local_username,
                is_local_turn=local_turn,
                local_actor_number=(
                    player.actor_number if player is not None else None
                ),
                client_move_allowed=client_move_allowed,
                local_move_sequence=action_before.local_move_sequence,
                last_move_from_col=(
                    action_before.last_move_from_col
                    if action_before.last_move_sequence is not None
                    and action_before.last_move_sequence > 0
                    else None
                ),
                last_move_from_row=(
                    action_before.last_move_from_row
                    if action_before.last_move_sequence is not None
                    and action_before.last_move_sequence > 0
                    else None
                ),
                last_move_to_col=(
                    action_before.last_move_to_col
                    if action_before.last_move_sequence is not None
                    and action_before.last_move_sequence > 0
                    else None
                ),
                last_move_to_row=(
                    action_before.last_move_to_row
                    if action_before.last_move_sequence is not None
                    and action_before.last_move_sequence > 0
                    else None
                ),
                last_move_sequence=action_before.last_move_sequence,
            ),
            player=player,
            opponents=opponents,
            participants=participants,
            cards=cards,
            fusion=fusion,
        )
        key = state.dedup_key
        if key is None:
            raise AssertionError("stable combat state must have a dedup key")
        if key in self._published:
            self.metrics.duplicate_skips += 1
            return ProviderPoll(
                state,
                False,
                "duplicate_state",
                lifecycle,
                cards_changed,
                fusion_changed,
                check,
                confirmations,
                session_key,
                tuple(rejection_details),
            )
        if self._last_accepted_seq is not None and highest <= self._last_accepted_seq:
            self.metrics.duplicate_skips += 1
            return ProviderPoll(
                state,
                False,
                "sequence_not_newer",
                lifecycle,
                cards_changed,
                fusion_changed,
                check,
                confirmations,
                session_key,
            )
        self._published.add(key)
        self._last_accepted_seq = highest
        self._last_accepted_hash = selected[2]
        self._last_accepted_turn = turn
        self._last_accepted_local_move_sequence = action_before.local_move_sequence
        self._last_accepted_all_dots = (
            array_before.elements if array_before is not None else None
        )
        self._non_board_fusion_sequence = None
        self._last_published_state = state
        self.metrics.stable_published += 1
        return ProviderPoll(
            state,
            True,
            (
                "stable_match_start_opening_dto"
                if opening_authoritative
                else "stable_ack_attested_dto"
            ),
            lifecycle,
            cards_changed,
            fusion_changed,
            check,
            confirmations,
            session_key,
            tuple(rejection_details),
        )

    def read(self) -> GameState:
        result = self.poll()
        if result.state is None:
            raise StateUnavailableError(result.reason)
        if result.state.phase is GamePhase.COMBAT and not result.publish:
            raise StateUnavailableError(result.reason)
        return result.state

    @property
    def observed_cards(self) -> tuple[CardState, ...]:
        return self._last_cards

    def read_current_combat_evidence(
        self,
    ) -> tuple[tuple[ParticipantState, ...], tuple[CardState, ...]]:
        """Re-read current owned stats/cards without a heap scan.

        This narrow read is used while a CAST input lock is held.  It resolves
        the exact Board/Active singleton cycle again, reads the structurally
        validated ``Active.playerStatsList`` and revalidates only the already
        discovered CardUI addresses against the current Board and Active.
        Missing or conflicting ownership returns empty evidence; it never
        falls back to a stale published GameState or broadens the scan.
        """

        board = self._resolve_board()
        if (
            board is None
            or self._session_key is None
            or self._current_board is None
            or board.board_instance != self._current_board
            or board.active is None
        ):
            return (), ()
        participants = self._participants(board.active)
        cards: tuple[CardState, ...] = ()
        if self._card_ui_class is not None and self._card_addresses:
            try:
                candidates = validate_combat_card_hits(
                    self.target.memory,
                    self._card_addresses,
                    expected_class=self._card_ui_class,
                    expected_board=board.board_instance,
                    expected_active=board.active,
                )
                cards = tuple(_canonical_card(card) for card in candidates)
            except (ExternalReadError, OSError, LayoutValidationError, ValueError):
                cards = ()
        return participants, cards

    @property
    def observed_fusion(self) -> FusionState | None:
        return self._last_fusion

    @property
    def current_board_instance(self) -> int | None:
        return self._current_board

    @property
    def current_session_key(self) -> CombatSessionKey | None:
        return self._session_key

    @property
    def scan_diagnostics(self) -> dict[str, Any]:
        tracked_batches = []
        for identity, batch in sorted(
            self._tracked.items(), key=lambda item: (item[0][1], item[0][0], item[0][2])
        ):
            tracked_batches.append(
                {
                    "address": batch.address,
                    "srvSeq": batch.sequence,
                    "boardHash": identity[2],
                    "sources": tuple(sorted(self._sources.get(identity, ()))),
                    "ownerAttested": identity in self._owner_attested,
                    "ackAttested": identity in self._ack_attested,
                }
            )
        return {
            "lastScanWasFull": self._last_scan_was_full,
            "forceFullNext": self._force_full_scan,
            "learnedRegions": {
                name: len(regions)
                for name, regions in sorted(self._learned_regions.items())
            },
            "cachedBatchAddresses": len(self._batch_addresses),
            "ownerAttestedBatches": len(self._owner_attested),
            "transportAttestedBatches": len(self._transport_attested),
            "ackAttestedBatches": len(self._ack_attested),
            "lobbyBaselineBatches": len(self._lobby_batch_baseline),
            "sessionBaselineBatches": len(self._session_batch_baseline),
            "lobbyBaselineReady": self._lobby_baseline_ready,
            "batchScanMissSeq": self._batch_scan_miss_seq,
            "directOwnerGraceSeq": self._direct_owner_grace_seq,
            "directOwnerGracePolls": self._direct_owner_grace_polls,
            "directOwnerGraceLimit": DIRECT_OWNER_BATCH_GRACE_POLLS,
            "ackHeapEnabled": self.config.allow_ack_heap_scan,
            "ackHeapScans": self.metrics.ack_batch_scans,
            "ackHeapRegionMiB": (
                self.config.ack_heap_region_mib
                if self.config.ack_heap_region_mib is not None
                else self.config.max_region_mib
            ),
            "cachedBoardWsOwners": len(self._board_ws_addresses),
            "cachedDotHits": len(self._dot_pointer_hits),
            "cachedCardAddresses": len(self._card_addresses),
            "cachedFusionUiAddresses": len(self._fusion_ui_addresses),
            "extendedFusionUiScanTurn": self._extended_fusion_scan_turn,
            "extendedFusionUiScans": self.metrics.extended_fusion_ui_scans,
            "extendedFusionUiBytes": self.metrics.extended_fusion_ui_bytes,
            # Raw acceptance instrumentation only.  These observations expose
            # the milestones already used internally; they do not relax any
            # currentness, ACK or stable-publication gate.
            "trackedBatches": tuple(tracked_batches),
            "highestAckedSequence": self.metrics.highest_acked_sequence,
            "lastAcceptedSeq": self._last_accepted_seq,
            "lastAcceptedHash": self._last_accepted_hash,
            "openingSnapshotAccepted": self._opening_snapshot is not None,
            "sessionKey": self._session_key,
            "dotAnchorRegions": len(self._last_dot_anchor_regions),
            "dotAnchorBytes": self._last_dot_anchor_bytes,
        }
