"""Optional, bounded board evidence from objects the controller already read.

No process reader, input, policy or model lives here. A retained response board
is not a published game state; only the existing provider can publish one.
"""
from dataclasses import asdict
import hashlib
import json

from .combat_lifecycle import CombatLifecycleState
from .combat_outcome_evidence import actor_identity
from .live_state import board_state_hash, canonical_cell_values, dto_rejection_reasons
from .state import GamePhase, GemType, SUPPORTED_CELL_MULTIPLIERS


BOARD_SCHEMA = 'pokiguard.retained_board_evidence.v1'
STATE_SCHEMA = 'pokiguard.published_combat_state_evidence.v1'
BOARD_ORDER = 'screen_rows_top_to_bottom_columns_left_to_right'
MAX_STATE_RECORDS = 256


def canonical(value):
    return json.dumps(value, sort_keys=True, ensure_ascii=True, separators=(',', ':'))


def semantic_board_hash(board):
    return hashlib.sha256(canonical(board).encode('utf-8')).hexdigest()


def valid_screen_board(board):
    return (type(board) in (list, tuple) and len(board) == 8
        and all(type(row) in (list, tuple) and len(row) == 8 and all(
            type(cell) in (list, tuple) and len(cell) == 2
            and type(cell[0]) is str and cell[0] in {g.value for g in GemType if g is not GemType.UNKNOWN}
            and type(cell[1]) is int and cell[1] in SUPPORTED_CELL_MULTIPLIERS
            for cell in row) for row in board))


def retained_board_fields(cells, *, match_id, lifecycle_epoch, sequence, source, accepted):
    """Copy the exact 64-cell DTO already offered; never upgrade its authority."""
    try:
        if (accepted is not True or not match_id or type(lifecycle_epoch) is not int
                or lifecycle_epoch < 1 or type(sequence) is not int or not 0 <= sequence <= 10000000
                or source not in ('TRANSPORT_BOARD', 'MatchService.PendingCombat', 'BoardWsApplier._pendingBatches')):
            return {}
        # Reject bool/string coordinates before helpers that intentionally cast DTO ints.
        values = tuple(cells)
        if (len(values) != 64 or any(type(c.row) is not int or type(c.col) is not int
                or type(c.multiplier) is not int or type(c.tag) is not str or len(c.tag) > 64
                for c in values) or dto_rejection_reasons(values)):
            return {}
        return dict(boardEvidence=dict(schema=BOARD_SCHEMA, status='CAPTURED',
            match_id=match_id, lifecycle_epoch=lifecycle_epoch, server_sequence=sequence,
            source=source, native_cells=canonical_cell_values(values),
            native_order='row_col_tag_multiplier_bottom_origin', board_hash=board_state_hash(values),
            scope='RETAINED_SESSION_BOUND_NOT_PROOF_OF_ACK_OR_CURRENT_TURN',
            input_authority=False, training_eligible=False))
    except Exception:
        # Diagnostics must never interrupt the controller or valid board delivery.
        return {}


class PublishedStateRecorder:
    """Deduplicate up to 256 immutable provider states in one controller session."""

    def __init__(self):
        self._session = None
        self._seen = set()
        self._limit_reported = False

    def observe(self, state):
        try:
            return self._observe(state)
        except Exception:
            return {}

    def _observe(self, state):
        if state is None or state.phase is not GamePhase.COMBAT:
            return {}
        b = state.battle
        if (b.combat_lifecycle is not CombatLifecycleState.ACTIVE or b.session_key is None
                or b.stable is not True or b.latest is not True or b.acknowledged is not True
                or type(b.turn_number) is not int or b.turn_number < 1
                or type(b.srv_seq) is not int or not 0 <= b.srv_seq <= 10000000
                or type(b.board_hash) is not str or len(b.board_hash) != 64
                or any(c not in '0123456789abcdef' for c in b.board_hash)
                or not b.sources or b.match_id != b.session_key.match_id
                or b.board_instance != b.session_key.board_instance
                or b.is_board_ready is not True
                or any(value is not False for value in (
                    b.is_cascade_running, b.board_is_processing_ui, b.board_is_game_over,
                    b.board_modal_open, b.reconnecting, b.match_resyncing, b.presentation_busy))):
            return {}
        current = actor_identity(b.current_turn_player)
        local = actor_identity(b.local_username)
        if current != 'BOSS' and current != local:
            return {}  # Co-op peer ownership is outside this Solo evidence join.
        if b.is_local_turn is not (current == local) or local == 'BOSS':
            return {}
        session = (b.session_key.match_id, b.session_key.lifecycle_epoch, b.session_key.board_instance)
        if self._session is None:
            self._session = session
        if self._session != session:
            return {}  # Never recycle this controller's cap on a stale/new session.
        board = [[[cell.gem.value, cell.multiplier] for cell in row] for row in state.board.cells]
        if not valid_screen_board(board):
            return {}
        record = dict(schema=STATE_SCHEMA, status='CAPTURED', match_id=b.match_id,
            lifecycle_epoch=b.session_key.lifecycle_epoch, board_instance=b.board_instance,
            server_sequence=b.srv_seq, turn=b.turn_number, actor_identity=current,
            local_identity=local, acknowledged=True, stable=True, latest=True,
            board_hash=b.board_hash, semantic_board_sha256=semantic_board_hash(board),
            board=board, board_order=BOARD_ORDER, sources=list(b.sources),
            player=asdict(state.player) if state.player is not None else None,
            bosses=[asdict(p) for p in state.opponents if p.is_boss is True],
            scope='PUBLISHED_PROVIDER_STATE_NOT_A_NEW_ACTION_OR_OPTIMAL_LABEL',
            training_eligible=False, input_authority=False)
        key = semantic_board_hash(record)
        if key in self._seen:
            return {}
        if len(self._seen) >= MAX_STATE_RECORDS:
            if self._limit_reported:
                return {}
            self._limit_reported = True
            return dict(stateEvidence=dict(schema=STATE_SCHEMA, status='UNAVAILABLE',
                reason='STATE_RECORD_LIMIT_REACHED', match_id=b.match_id,
                lifecycle_epoch=b.session_key.lifecycle_epoch, input_authority=False))
        self._seen.add(key)
        return dict(stateEvidence=record)
