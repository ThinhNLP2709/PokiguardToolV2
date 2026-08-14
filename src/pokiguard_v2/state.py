"""Immutable provider-neutral state at the V2 solver boundary.

The model deliberately distinguishes an unavailable value (``None``) from a
real zero.  Memory, CV and a future bridge provider may populate different
subsets without changing the solver-facing shape.
"""

from __future__ import annotations

from abc import ABC, abstractmethod
from dataclasses import dataclass, field
from enum import Enum
from typing import Callable, TypeVar

from .combat_lifecycle import CombatLifecycleState


class GemType(str, Enum):
    """Values intentionally match PokiguardAuto V1's ``Token`` enum."""

    SWORD = "sword"
    MANA = "mana"
    RAGE = "rage"
    SHIELD = "shield"
    HEALTH = "health"
    DRAIN = "drain"
    UNKNOWN = "unknown"


class GamePhase(str, Enum):
    LOBBY = "lobby"
    COMBAT = "combat"
    UNKNOWN = "unknown"


class GameOwnedIdleStatus(str, Enum):
    """Decision status derived only from server idle/reset evidence."""

    UNKNOWN = "unknown"
    RESET_BASELINE_CONFIRMED = "reset_baseline_confirmed"
    PASS_ALLOWED = "pass_allowed"
    PASS_FORBIDDEN_MANDATORY_ACTION = "pass_forbidden_mandatory_action"


class PossibleAction(str, Enum):
    """Action vocabulary only; this is not a new card strategy."""

    SWAP = "swap"
    USE_CARD = "use_card"
    FUSION = "fusion"
    NONE = "none"


Board = tuple[tuple[GemType, ...], ...]
MultiplierBoard = tuple[tuple[int, ...], ...]
TEnum = TypeVar("TEnum")


def _validate_8x8(name: str, value: tuple[tuple[object, ...], ...]) -> None:
    if len(value) != 8 or any(len(row) != 8 for row in value):
        shape = (len(value), tuple(len(row) for row in value))
        raise ValueError(f"{name} must be exactly 8x8; got {shape}")


@dataclass(frozen=True)
class CellState:
    """One immutable cell using the proven gameplay multiplier values x1..x4."""

    row: int
    col: int
    gem: GemType
    multiplier: int

    def __post_init__(self) -> None:
        if not 0 <= self.row < 8 or not 0 <= self.col < 8:
            raise ValueError("cell coordinate must be inside the 8x8 board")
        if self.multiplier not in (1, 2, 3, 4):
            raise ValueError("cell multiplier must be one of the proven values 1..4")

    @property
    def gem_type(self) -> GemType:
        """Compatibility alias used by the Phase 2A.5 helpers."""

        return self.gem


CellGrid = tuple[tuple[CellState, ...], ...]


@dataclass(frozen=True)
class BoardState:
    """Exact 8x8 cell grid. Coordinates are zero-based and row-major here."""

    cells: CellGrid

    def __post_init__(self) -> None:
        _validate_8x8("cells", self.cells)
        for row, values in enumerate(self.cells):
            for col, cell in enumerate(values):
                if (cell.row, cell.col) != (row, col):
                    raise ValueError(
                        "CellState coordinates must match their BoardState position"
                    )

    @property
    def board(self) -> Board:
        return tuple(tuple(cell.gem for cell in row) for row in self.cells)

    @property
    def multipliers(self) -> MultiplierBoard:
        return tuple(tuple(cell.multiplier for cell in row) for row in self.cells)

    @property
    def production_ready(self) -> bool:
        return all(
            cell.gem is not GemType.UNKNOWN
            and cell.multiplier in (1, 2, 3, 4)
            for row in self.cells
            for cell in row
        )


@dataclass(frozen=True)
class CombatSessionKey:
    """Restart-safe identity for one live combat session.

    ``srvSeq`` is deliberately absent: reverse evidence shows that it orders
    batches, but it is not a match identity.  The local epoch also protects us
    if Unity reuses a managed Board address in a later combat.
    """

    lifecycle_epoch: int
    board_instance: int
    match_id: str

    def __post_init__(self) -> None:
        if self.lifecycle_epoch <= 0:
            raise ValueError("lifecycle_epoch must be positive")
        if self.board_instance <= 0:
            raise ValueError("board_instance must be a positive runtime pointer")
        if not self.match_id.strip():
            raise ValueError("match_id is required for a combat session")


@dataclass(frozen=True)
class BattleState:
    combat_lifecycle: CombatLifecycleState = CombatLifecycleState.UNKNOWN
    board_instance: int | None = None
    srv_seq: int | None = None
    turn_number: int | None = None
    current_turn_player: str | None = None
    stable: bool = False
    board_hash: str | None = None
    sources: tuple[str, ...] = ()
    session_key: CombatSessionKey | None = None
    match_id: str | None = None
    acknowledged: bool = False
    latest: bool = False
    is_board_ready: bool | None = None
    is_cascade_running: bool | None = None
    board_current_state: int | None = None
    board_has_destroyed_this_turn: bool | None = None
    board_is_processing_ui: bool | None = None
    board_is_game_over: bool | None = None
    board_modal_open: bool | None = None
    board_is_resuming: bool | None = None
    match_over: bool | None = None
    deferred_game_over: bool | None = None
    start_gate_paused: bool | None = None
    clock_paused: bool | None = None
    clock_pause_reason: str | None = None
    turn_duration_seconds: int | None = None
    turn_time_remaining_seconds: int | None = None
    turn_timer_source: str | None = None
    consecutive_passes: int | None = None
    consecutive_pass_threshold: int | None = None
    consecutive_pass_source: str | None = None
    consecutive_pass_status: GameOwnedIdleStatus = GameOwnedIdleStatus.UNKNOWN
    consecutive_pass_reset_evidence: str | None = None
    consecutive_pass_confidence: str | None = None
    connection_ready: bool | None = None
    reconnecting: bool | None = None
    match_resyncing: bool | None = None
    presentation_busy: bool | None = None
    local_username: str | None = None
    is_local_turn: bool | None = None
    local_actor_number: int | None = None
    client_move_allowed: bool | None = None
    local_move_sequence: int | None = None
    last_move_from_col: int | None = None
    last_move_from_row: int | None = None
    last_move_to_col: int | None = None
    last_move_to_row: int | None = None
    last_move_sequence: int | None = None

    def __post_init__(self) -> None:
        if self.board_instance is not None and self.board_instance <= 0:
            raise ValueError("board_instance must be a positive runtime pointer")
        if self.srv_seq is not None and self.srv_seq < 0:
            raise ValueError("srv_seq cannot be negative")
        if self.turn_number is not None and self.turn_number < 0:
            raise ValueError("turn_number cannot be negative")
        if self.board_current_state is not None and self.board_current_state not in (0, 1):
            raise ValueError("board_current_state must be wait(0) or move(1)")
        if self.local_actor_number is not None and self.local_actor_number <= 0:
            raise ValueError("local_actor_number must be positive when known")
        if self.local_move_sequence is not None and self.local_move_sequence < 0:
            raise ValueError("local_move_sequence cannot be negative")
        if self.last_move_sequence is not None and self.last_move_sequence < -1:
            raise ValueError("last_move_sequence cannot be below the -1 sentinel")
        move_coordinates = (
            self.last_move_from_col,
            self.last_move_from_row,
            self.last_move_to_col,
            self.last_move_to_row,
        )
        if any(value is not None and not 0 <= value < 8 for value in move_coordinates):
            raise ValueError("last move coordinates must be inside the 8x8 board")
        if (
            self.last_move_sequence is not None
            and self.last_move_sequence <= 0
            and any(value is not None for value in move_coordinates)
        ):
            raise ValueError("unset last move sequence cannot carry coordinates")
        if (
            self.turn_duration_seconds is not None
            and self.turn_duration_seconds <= 0
        ):
            raise ValueError("turn_duration_seconds must be positive when known")
        if (
            self.turn_time_remaining_seconds is not None
            and self.turn_time_remaining_seconds < 0
        ):
            raise ValueError("turn_time_remaining_seconds cannot be negative")
        if (
            self.turn_duration_seconds is not None
            and self.turn_time_remaining_seconds is not None
            and self.turn_time_remaining_seconds > self.turn_duration_seconds
        ):
            raise ValueError("turn time remaining cannot exceed turn duration")
        if self.turn_timer_source is not None and not self.turn_timer_source.strip():
            raise ValueError("turn_timer_source cannot be blank")
        if self.consecutive_passes is not None and self.consecutive_passes < 0:
            raise ValueError("consecutive_passes cannot be negative")
        if (
            self.consecutive_pass_threshold is not None
            and self.consecutive_pass_threshold <= 0
        ):
            raise ValueError("consecutive_pass_threshold must be positive")
        if (
            self.consecutive_passes is not None
            and self.consecutive_pass_threshold is not None
            and self.consecutive_passes > self.consecutive_pass_threshold
        ):
            raise ValueError("consecutive passes cannot exceed its threshold")
        if (
            self.consecutive_pass_source is not None
            and not self.consecutive_pass_source.strip()
        ):
            raise ValueError("consecutive_pass_source cannot be blank")
        if (
            self.consecutive_pass_reset_evidence is not None
            and not self.consecutive_pass_reset_evidence.strip()
        ):
            raise ValueError("consecutive_pass_reset_evidence cannot be blank")
        if (
            self.consecutive_pass_confidence is not None
            and not self.consecutive_pass_confidence.strip()
        ):
            raise ValueError("consecutive_pass_confidence cannot be blank")
        if self.session_key is not None:
            if self.board_instance != self.session_key.board_instance:
                raise ValueError("session Board does not match battle Board")
            if self.match_id != self.session_key.match_id:
                raise ValueError("session match_id does not match battle match_id")

    @property
    def is_first_local_turn(self) -> bool | None:
        """Runtime-derived opening state; Board appearance is never used.

        Server snapshots default ``turnNumber`` to zero and live captures use
        one-based turns.  While the proven current player is local, either 0
        or 1 therefore denotes the opening server turn.  A missing identity or
        turn number remains UNKNOWN instead of being guessed from lifecycle.
        """

        if self.combat_lifecycle is not CombatLifecycleState.ACTIVE:
            return None
        if self.is_local_turn is not True or self.turn_number is None:
            if self.is_local_turn is None or self.turn_number is None:
                return None
            return False
        return self.turn_number in (0, 1)

    @property
    def first_local_turn(self) -> bool | None:
        """Compatibility alias for the runtime-accepted opening signal."""

        return self.is_first_local_turn


@dataclass(frozen=True)
class ParticipantState:
    """One decoded Active.PlayerStats record.

    ``is_local`` remains ``None`` when ownership cannot be proven.  This is
    important for co-op matches where "the only non-boss actor" is not safe.
    """

    actor_number: int
    is_local: bool | None = None
    is_boss: bool | None = None
    hp: int | None = None
    max_hp: int | None = None
    mana: int | None = None
    max_mana: int | None = None
    power: int | None = None
    max_power: int | None = None
    attack: int | None = None
    shield: int | None = None
    source: str | None = None


@dataclass(frozen=True)
class CardState:
    """Current equipped/rendered card and exact recovered CardData metadata."""

    object_address: int
    data_address: int
    data_id: int
    card_id: int
    name: str | None
    description: str | None
    element_type: str
    skill_type: str | None
    interactable: bool
    has_used_this_match: bool
    has_used_this_turn: bool
    last_turn_used: int
    action_pending: bool
    is_placeholder: bool
    mana_cost: int
    power_cost: int
    cooldown_turns: int
    need_perfection: bool
    value: int | None = None
    max_level: int | None = None
    count: int | None = None
    level: int | None = None
    condition_use: int | None = None
    power: int | None = None
    damage_multiplier: float | None = None
    color_requirements: tuple[tuple[str, int], ...] = ()
    quality_values: tuple[tuple[str, int], ...] = ()

    @property
    def is_attack(self) -> bool:
        return self.element_type.upper() in {
            "ATTACK",
            "ATTACK_LEGEND",
            "ATTACK_LEGEND_",
            "MEGA1",
        }


@dataclass(frozen=True)
class FusionState:
    enabled: bool
    available: bool
    used: bool
    locked_this_turn: bool
    last_attempt_turn: int | None = None
    mana_cost: int | None = None
    stat_bonus_percent: int | None = None
    selected_user_pet_id: int | None = None
    selected_pet_id: int | None = None
    skill_card_data_address: int | None = None
    drop_reason: str | None = None
    ui_address: int | None = None
    ui_interactable: bool | None = None


@dataclass(frozen=True)
class GameState:
    """One immutable, source-timestamped snapshot of the game lifecycle."""

    phase: GamePhase
    timestamp: str
    board: BoardState | None = None
    battle: BattleState = field(default_factory=BattleState)
    player: ParticipantState | None = None
    opponents: tuple[ParticipantState, ...] = ()
    participants: tuple[ParticipantState, ...] = ()
    cards: tuple[CardState, ...] = ()
    fusion: FusionState | None = None

    def __post_init__(self) -> None:
        if not self.timestamp:
            raise ValueError("timestamp is required")
        if self.phase is GamePhase.COMBAT:
            if self.board is None or not self.board.production_ready:
                raise ValueError("combat GameState requires a production-ready board")
            if not self.battle.stable:
                raise ValueError("combat GameState must represent a stable board")
            if self.battle.board_instance is None or self.battle.srv_seq is None:
                raise ValueError("combat GameState requires Board.Instance and srvSeq")
        elif self.board is not None:
            raise ValueError("non-combat GameState cannot publish a board")

    @property
    def dedup_key(self) -> tuple[object, int, str] | None:
        if (
            self.battle.board_instance is None
            or self.battle.srv_seq is None
            or self.battle.board_hash is None
        ):
            return None
        return (
            self.battle.session_key or self.battle.board_instance,
            self.battle.srv_seq,
            self.battle.board_hash,
        )


class BoardStateProvider(ABC):
    """Read one provider-neutral snapshot or raise without publishing bad state."""

    @abstractmethod
    def read(self) -> GameState:
        raise NotImplementedError


def adapt_board_to_enum(
    board: Board, enum_factory: Callable[[str], TEnum]
) -> tuple[tuple[TEnum, ...], ...]:
    """Map V2 gems to V1 ``Token`` (or another value-compatible enum)."""

    _validate_8x8("board", board)
    return tuple(tuple(enum_factory(gem.value) for gem in row) for row in board)
