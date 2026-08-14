"""Read-only, fail-closed combat lifecycle classification.

``MatchService.CurrentMatchId`` is server-session state and is deliberately
not sufficient here.  ACTIVE requires the local Unity match rig, scene state,
Hub suspension, and the Board/Active/ManagerMatch ownership cycle to agree.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum, IntEnum

from .il2cpp_external import (
    ACTIVE_SINGLETON,
    HUB_SUSPEND_MANAGER_IS_SUSPENDED_STATIC_OFFSET,
    HUB_SUSPEND_MANAGER_TYPE_INFO_RVA,
    IL2CPP_CLASS_STATIC_FIELDS_OFFSET,
    MANAGER_MATCH_ACTIVE_OFFSET,
    MANAGER_MATCH_IS_BOSS_BATTLE_OFFSET,
    MANAGER_MATCH_SINGLETON,
    MATCH_HOST_CURRENT_RIG_STATIC_OFFSET,
    MATCH_HOST_STATE_STATIC_OFFSET,
    MATCH_HOST_TYPE_INFO_RVA,
    MATCH_SCENE_LOADER_IS_LOADING_STATIC_OFFSET,
    MATCH_SCENE_LOADER_IS_UNLOADING_STATIC_OFFSET,
    MATCH_SCENE_LOADER_TYPE_INFO_RVA,
    POINTER_SIZE,
    BoardRuntimeState,
    ExternalReadError,
    checked_address,
    is_canonical_user_pointer,
)


UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10


class MatchHostState(IntEnum):
    IDLE = 0
    PREPARING = 1
    BUILDING = 2
    RUNNING = 3
    RELEASING = 4


class CombatLifecycleState(str, Enum):
    LOBBY = "lobby"
    ENTERING = "entering_combat"
    ACTIVE = "active_combat"
    LEAVING = "leaving_combat"
    POSTMATCH = "postmatch"
    STALE_SERVER_MATCH = "stale_server_match"
    UNKNOWN = "unknown"


@dataclass(frozen=True)
class CombatLifecycleSignals:
    """One atomic-ish observation; ``None`` always means not proven."""

    match_host_state: MatchHostState | None = None
    current_rig: int | None = None
    current_rig_native: int | None = None
    current_rig_alive: bool | None = None
    scene_loading: bool | None = None
    scene_unloading: bool | None = None
    hub_suspended: bool | None = None
    board_instance: int | None = None
    active_instance: int | None = None
    manager_match_instance: int | None = None
    manager_active: int | None = None
    manager_is_boss_battle: bool | None = None
    objects_consistent: bool | None = None
    match_id: str | None = None
    board_ready: bool | None = None
    board_game_over: bool | None = None
    match_over: bool | None = None
    deferred_game_over: bool | None = None
    read_errors: tuple[str, ...] = ()


@dataclass(frozen=True)
class CombatLifecycleObservation:
    state: CombatLifecycleState
    signals: CombatLifecycleSignals
    reason: str


def classify_combat_lifecycle(
    signals: CombatLifecycleSignals,
) -> CombatLifecycleObservation:
    """Classify using only positive evidence; ambiguous combinations fail closed."""

    s = signals
    ended = any(
        value is True
        for value in (s.board_game_over, s.match_over, s.deferred_game_over)
    )
    if ended and (
        s.current_rig_alive is True
        or s.board_instance is not None
        or s.manager_match_instance is not None
    ):
        return CombatLifecycleObservation(
            CombatLifecycleState.POSTMATCH, s, "local_match_end_flag"
        )

    if s.scene_unloading is True or s.match_host_state is MatchHostState.RELEASING:
        return CombatLifecycleObservation(
            CombatLifecycleState.LEAVING, s, "match_rig_releasing_or_scene_unloading"
        )

    if s.scene_loading is True or s.match_host_state in {
        MatchHostState.PREPARING,
        MatchHostState.BUILDING,
    }:
        return CombatLifecycleObservation(
            CombatLifecycleState.ENTERING, s, "match_rig_preparing_or_scene_loading"
        )

    active_checks = (
        s.match_host_state is MatchHostState.RUNNING,
        s.current_rig_alive is True,
        s.scene_loading is False,
        s.scene_unloading is False,
        s.hub_suspended is True,
        s.board_instance is not None,
        s.active_instance is not None,
        s.manager_match_instance is not None,
        s.objects_consistent is True,
        bool(s.match_id),
        s.board_ready is True,
        not ended,
    )
    if all(active_checks):
        return CombatLifecycleObservation(
            CombatLifecycleState.ACTIVE, s, "local_rig_and_combat_ownership_agree"
        )

    local_absent = (
        s.match_host_state is MatchHostState.IDLE
        and s.current_rig_alive is False
        and s.scene_loading is False
        and s.scene_unloading is False
        and s.hub_suspended is False
        and s.board_instance is None
        and s.active_instance is None
        and s.manager_match_instance is None
    )
    if s.match_id and local_absent:
        return CombatLifecycleObservation(
            CombatLifecycleState.STALE_SERVER_MATCH,
            s,
            "server_match_id_without_local_combat_rig",
        )
    if not s.match_id and local_absent:
        return CombatLifecycleObservation(
            CombatLifecycleState.LOBBY, s, "local_match_rig_and_combat_objects_absent"
        )
    return CombatLifecycleObservation(
        CombatLifecycleState.UNKNOWN,
        s,
        "lifecycle_signals_missing_or_disagree",
    )


def _static_fields(resolver: object, type_info_rva: int, size: int) -> int | None:
    klass = resolver.resolve_type_info_class(type_info_rva)
    if klass is None:
        return None
    fields = resolver.read_pointer(checked_address(klass, IL2CPP_CLASS_STATIC_FIELDS_OFFSET))
    if fields == 0:
        return None
    if not is_canonical_user_pointer(fields) or not resolver.memory.is_readable(fields, size):
        raise ExternalReadError("static-fields range is invalid")
    return fields


def _read_rig(resolver: object, fields: int | None) -> tuple[int | None, int | None, bool | None]:
    if fields is None:
        return None, None, None
    value = resolver.read_pointer(fields + MATCH_HOST_CURRENT_RIG_STATIC_OFFSET)
    if value == 0:
        return None, None, False
    if not is_canonical_user_pointer(value) or not resolver.memory.is_readable(value, 0x18):
        return value, None, False
    native = resolver.read_pointer(value + UNITY_OBJECT_CACHED_PTR_OFFSET)
    alive = bool(
        is_canonical_user_pointer(native)
        and resolver.memory.is_readable(native, 1)
    )
    return value, native or None, alive


def read_combat_lifecycle(
    resolver: object,
    *,
    board: BoardRuntimeState | None,
    match_id: str | None,
    match_over: bool | None = None,
    deferred_game_over: bool | None = None,
) -> CombatLifecycleObservation:
    """Read native-proven fields through RPM only; errors stay in provenance."""

    errors: list[str] = []
    host_state: MatchHostState | None = None
    rig = rig_native = None
    rig_alive: bool | None = None
    loading = unloading = hub = None

    try:
        fields = _static_fields(resolver, MATCH_HOST_TYPE_INFO_RVA, 0x18)
        if fields is not None:
            raw_state = resolver.read_i32(fields + MATCH_HOST_STATE_STATIC_OFFSET)
            host_state = MatchHostState(raw_state)
        rig, rig_native, rig_alive = _read_rig(resolver, fields)
    except (ExternalReadError, OSError, ValueError) as exc:
        errors.append(f"MatchHost:{exc}")

    try:
        fields = _static_fields(resolver, MATCH_SCENE_LOADER_TYPE_INFO_RVA, 0x02)
        if fields is not None:
            loading = resolver.read_bool(
                fields + MATCH_SCENE_LOADER_IS_LOADING_STATIC_OFFSET
            )
            unloading = resolver.read_bool(
                fields + MATCH_SCENE_LOADER_IS_UNLOADING_STATIC_OFFSET
            )
    except (ExternalReadError, OSError, ValueError) as exc:
        errors.append(f"MatchSceneLoader:{exc}")

    try:
        fields = _static_fields(resolver, HUB_SUSPEND_MANAGER_TYPE_INFO_RVA, 0x09)
        if fields is not None:
            hub = resolver.read_bool(
                fields + HUB_SUSPEND_MANAGER_IS_SUSPENDED_STATIC_OFFSET
            )
    except (ExternalReadError, OSError, ValueError) as exc:
        errors.append(f"HubSuspendManager:{exc}")

    active = manager = manager_active = None
    manager_boss: bool | None = None
    try:
        resolution = resolver.resolve_singleton(ACTIVE_SINGLETON)
        active = resolution.instance if resolution.resolved else None
    except (ExternalReadError, OSError, ValueError) as exc:
        errors.append(f"Active:{exc}")
    try:
        resolution = resolver.resolve_singleton(MANAGER_MATCH_SINGLETON)
        manager = resolution.instance if resolution.resolved else None
        if manager is not None:
            manager_active_raw = resolver.read_pointer(manager + MANAGER_MATCH_ACTIVE_OFFSET)
            manager_active = manager_active_raw or None
            manager_boss = resolver.read_bool(
                manager + MANAGER_MATCH_IS_BOSS_BATTLE_OFFSET
            )
    except (ExternalReadError, OSError, ValueError) as exc:
        errors.append(f"ManagerMatch:{exc}")

    board_instance = board.board_instance if board is not None else None
    consistent: bool | None
    if board is None or active is None or manager is None:
        consistent = None
    else:
        consistent = bool(
            board.active == active
            and board.active_board == board.board_instance
            and board.active_back_reference is True
            and board.board_active_matches_singleton is True
            and manager_active == active
        )

    signals = CombatLifecycleSignals(
        match_host_state=host_state,
        current_rig=rig,
        current_rig_native=rig_native,
        current_rig_alive=rig_alive,
        scene_loading=loading,
        scene_unloading=unloading,
        hub_suspended=hub,
        board_instance=board_instance,
        active_instance=active,
        manager_match_instance=manager,
        manager_active=manager_active,
        manager_is_boss_battle=manager_boss,
        objects_consistent=consistent,
        match_id=match_id,
        board_ready=board.is_board_ready if board is not None else None,
        board_game_over=board.is_game_over if board is not None else None,
        match_over=match_over,
        deferred_game_over=deferred_game_over,
        read_errors=tuple(errors),
    )
    return classify_combat_lifecycle(signals)


class CombatSessionTracker:
    """Issue a session only while ACTIVE; invalidate it on the first exit sample."""

    def __init__(self) -> None:
        self._epoch = 0
        self._identity: tuple[int, str] | None = None
        self._session = None

    @property
    def epoch(self) -> int:
        return self._epoch

    @property
    def session(self):
        return self._session

    def observe(self, lifecycle: CombatLifecycleState, board: int | None, match_id: str | None):
        # Import here to keep state.py -> combat_lifecycle.py one-way at module load.
        from .state import CombatSessionKey

        if lifecycle is not CombatLifecycleState.ACTIVE or board is None or not match_id:
            self.invalidate()
            return None
        identity = (board, match_id)
        if self._identity != identity or self._session is None:
            self._epoch += 1
            self._identity = identity
            self._session = CombatSessionKey(self._epoch, board, match_id)
        return self._session

    def invalidate(self) -> None:
        self._identity = None
        self._session = None
