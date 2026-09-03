#!/usr/bin/env python3
"""Production Phase 3B.1 Pet Skill/QTE shadow observer (RPM only, no input)."""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
from typing import Any


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_DOT_SKILL_CARD,
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    ACTIVE_SINGLETON,
    BOARD_SINGLETON,
    CARD_DATA_TYPE_INFO_RVA,
    CARD_UI_TYPE_INFO_RVA,
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    MATCH_SERVICE_SINGLETON,
    PET_USER_DTO_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    bounded_private_writable_regions,
    regions_containing_addresses,
    scan_aligned_qwords,
)
from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    BoundQteObservation,
    DOT_SKILL_ELEMENT_TYPES,
    QTE_RESULT_TYPES,
    QteBindingContext,
    QteBindingStatus,
    QteSessionTracker,
    correlate_qte_response_envelope,
    read_card_ui_qte,
    read_player_pet_skill,
    read_qte_card_data,
    read_server_qte_challenge,
)
from pokiguard_v2.pet_skill_shadow import (  # noqa: E402
    LivePetSkillCard,
    PetSkillCapabilityProvider,
    PetSkillCapabilityStatus,
    QteEvidenceStatus,
    QteObserver,
    live_pet_skill_card_from_state,
)
from pokiguard_v2.player_stats import read_active_participants  # noqa: E402
from pokiguard_v2.state import GamePhase  # noqa: E402
from tools.idle_state_watch import read_match_runtime, read_server_message  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_jsonable(item) for item in value]
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    payload = {
        "timestamp": time.strftime("%Y-%m-%dT%H:%M:%S", time.gmtime())
        + f".{int(time.time_ns() / 1_000_000) % 1000:03d}Z",
        "event": event,
        **fields,
    }
    log.write(
        json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
        + "\n"
    )
    log.flush()


def _session_text(session: Any) -> str | None:
    if session is None:
        return None
    return (
        f"epoch={session.lifecycle_epoch}|board=0x{session.board_instance:016X}"
        f"|match={session.match_id}"
    )


def _regions(target: Any, max_region_mib: int) -> tuple[Any, ...]:
    return bounded_private_writable_regions(
        target.memory.iter_readable_regions(),
        max_region_size=max_region_mib * 1024 * 1024,
    )


def _scan_qte_results(
    target: Any,
    *,
    dto_class: int,
    match_id: str,
    all_regions: tuple[Any, ...],
    learned_regions: set[Any],
    full: bool,
    chunk_mib: int,
) -> tuple[Any, ...]:
    values = []
    primary: tuple[Any, ...] = (
        tuple(sorted(learned_regions, key=lambda item: item.base))
        if learned_regions
        else all_regions
    )
    scan_sets = [primary]
    if full and primary != all_regions:
        # Always inspect the already learned ChatMessageDTO regions first.
        # MATCH_SKILL_USE_RES can be short-lived, while a full private-memory
        # scan is comparatively expensive.  The broad scan remains a bounded
        # discovery fallback and never changes correlation authority.
        scan_sets.append(all_regions)
    seen_addresses: set[int] = set()
    for selected in scan_sets:
        scan = scan_aligned_qwords(
            target.memory,
            selected,
            {"qte_result": dto_class},
            chunk_size=chunk_mib * 1024 * 1024,
        )
        learned_regions.update(
            regions_containing_addresses(all_regions, scan.matches["qte_result"])
        )
        for address in scan.matches["qte_result"]:
            if address in seen_addresses:
                continue
            seen_addresses.add(address)
            try:
                message = read_server_message(
                    target.memory,
                    address,
                    expected_class=dto_class,
                    expected_match_id=match_id,
                )
                if message.event_type in QTE_RESULT_TYPES:
                    values.append(message)
            except (ExternalReadError, OSError, LayoutValidationError):
                continue
        if values:
            break
    return tuple(values)


def _server_timestamp_epoch(value: str | None) -> float | None:
    """Convert the game's ISO timestamp to epoch using local time if naive."""

    if not value:
        return None
    try:
        parsed = datetime.fromisoformat(value.replace("Z", "+00:00"))
    except ValueError:
        return None
    if parsed.tzinfo is not None:
        return parsed.timestamp()
    return time.mktime(parsed.timetuple()) + parsed.microsecond / 1_000_000.0


def _participant_snapshot(
    target: Any,
    *,
    active_instance: int,
    stats_class: int | None,
    local_actor_number: int,
    fallback_state: Any,
) -> dict[str, Any]:
    """Take a fresh participant sample without requiring a stable board frame."""

    local = None
    boss = None
    if stats_class is not None:
        try:
            participants = read_active_participants(
                target.memory,
                active_instance,
                expected_class=stats_class,
                local_actor_number=local_actor_number,
            )
            local = next((item for item in participants if item.is_local), None)
            boss = next((item for item in participants if item.is_boss), None)
        except (ExternalReadError, OSError, LayoutValidationError):
            pass
    fallback_player = fallback_state.player
    fallback_boss = next(
        (item for item in fallback_state.opponents if item.is_boss),
        None,
    )
    return {
        "localActor": local_actor_number,
        "localHp": local.hp if local is not None else fallback_player.hp,
        "localMaxHp": local.max_hp if local is not None else fallback_player.max_hp,
        "mana": local.mana if local is not None else fallback_player.mana,
        "power": local.power if local is not None else fallback_player.power,
        "bossActor": boss.actor_number if boss is not None else (
            fallback_boss.actor_number if fallback_boss is not None else None
        ),
        "bossHp": boss.hp if boss is not None else (
            fallback_boss.hp if fallback_boss is not None else None
        ),
        "bossMaxHp": boss.max_hp if boss is not None else (
            fallback_boss.max_hp if fallback_boss is not None else None
        ),
        "boardHash": fallback_state.battle.board_hash,
    }


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", help="required safety switch")
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--interval", type=float, default=0.05)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--qtes", type=int, default=3)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="diagnostic recovery only; starting in lobby is safer",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("start the observer with --watch")
    if not 0.02 <= args.interval <= 1.0:
        raise ValueError("--interval must be between 0.02 and 1.0 seconds")
    if args.timeout < 0 or not 0 <= args.qtes <= 20:
        raise ValueError("timeout/qtes is outside the allowed range")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size is outside the allowed range")

    log_path = (args.log or default_log_path("phase3b1_qte_shadow")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                full_rescan_interval=8,
                require_lobby_start=not args.allow_combat_start,
            ),
        )
        tracker = QteSessionTracker()
        capability_provider = PetSkillCapabilityProvider()
        shadow_observer = QteObserver()
        started = time.monotonic()
        last_state = None
        previous_pet_signature = None
        previous_skill_signature = None
        previous_qte_signature = None
        previous_capability_signature = None
        previous_shadow_generation = None
        previous_shadow_direction_signature = None
        previous_shadow_progress_signature = None
        previous_shadow_timing_signature = None
        previous_shadow_runtime_result_signature = None
        previous_shadow_rejection_signature = None
        previous_match_id = None
        pending: BoundQteObservation | None = None
        pending_before = None
        pending_completion_epoch: float | None = None
        closed_identities: set[Any] = set()
        seen_results: set[int] = set()
        learned_result_regions: set[Any] = set()
        result_scan_number = 0
        last_result_scan = 0.0
        completed_qtes = 0

        pet_class = target.resolver.resolve_type_info_class(PET_USER_DTO_TYPE_INFO_RVA)
        card_data_class = target.resolver.resolve_type_info_class(
            CARD_DATA_TYPE_INFO_RVA
        )
        card_ui_class = target.resolver.resolve_type_info_class(CARD_UI_TYPE_INFO_RVA)
        stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        _write(
            log,
            "observer_started",
            pid=target.pid,
            architecture=target.architecture,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            noInput=True,
            noProcessWrite=True,
            noIl2CppInvocation=True,
            requiredBoundary="current MatchId + lifecycle epoch + local actor + skill card + inactive edge",
            qteTarget=args.qtes,
            lobbyBaselineRequired=not args.allow_combat_start,
        )
        print(f"Phase 3B.1 production shadow observer READ-ONLY; log: {log_path}", flush=True)
        print("NO INPUT: perform every Pet Skill/QTE action manually.", flush=True)

        while target.is_running():
            now = time.monotonic()
            if args.timeout and now - started >= args.timeout:
                _write(log, "observer_timeout", completedQtes=completed_qtes)
                break
            if args.qtes and completed_qtes >= args.qtes:
                _write(log, "observer_target_reached", completedQtes=completed_qtes)
                break
            try:
                poll = provider.poll()
            except (ExternalReadError, OSError, LayoutValidationError, RuntimeError) as exc:
                poll = None
                _write(log, "provider_error", detail=str(exc))
            if poll is not None and poll.state is not None:
                if poll.state.phase is GamePhase.COMBAT:
                    last_state = poll.state
                elif poll.state.phase is not GamePhase.COMBAT:
                    last_state = None

            try:
                match_service_resolution = target.resolver.resolve_singleton(
                    MATCH_SERVICE_SINGLETON
                )
                active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
                board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
                _match_service, runtime = read_match_runtime(target)
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                _write(log, "runtime_error", detail=str(exc))
                time.sleep(args.interval)
                continue

            if runtime.match_id != previous_match_id:
                _write(
                    log,
                    "match_changed",
                    before=previous_match_id,
                    after=runtime.match_id,
                    turn=runtime.turn,
                )
                tracker.invalidate()
                shadow_observer.invalidate("match_changed")
                previous_match_id = runtime.match_id
                pending = None
                pending_before = None
                pending_completion_epoch = None
                closed_identities.clear()
                seen_results.clear()
                learned_result_regions.clear()
                previous_capability_signature = None
                previous_shadow_generation = None
                previous_shadow_direction_signature = None
                previous_shadow_progress_signature = None
                previous_shadow_timing_signature = None
                previous_shadow_runtime_result_signature = None
                previous_shadow_rejection_signature = None

            if (
                last_state is None
                or last_state.battle.session_key is None
                or runtime.match_id != last_state.battle.session_key.match_id
                or not match_service_resolution.resolved
                or not active_resolution.resolved
                or not board_resolution.resolved
            ):
                time.sleep(args.interval)
                continue
            session = last_state.battle.session_key
            actor = last_state.battle.local_actor_number
            if actor is None or last_state.player is None:
                time.sleep(args.interval)
                continue

            if pet_class is None:
                pet_class = target.resolver.resolve_type_info_class(
                    PET_USER_DTO_TYPE_INFO_RVA
                )
            if card_data_class is None:
                card_data_class = target.resolver.resolve_type_info_class(
                    CARD_DATA_TYPE_INFO_RVA
                )
            if card_ui_class is None:
                card_ui_class = target.resolver.resolve_type_info_class(
                    CARD_UI_TYPE_INFO_RVA
                )
            if dto_class is None:
                dto_class = target.resolver.resolve_type_info_class(
                    CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                )
            if stats_class is None:
                stats_class = target.resolver.resolve_type_info_class(
                    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
                )

            current_resource = _participant_snapshot(
                target,
                active_instance=int(active_resolution.instance),
                stats_class=stats_class,
                local_actor_number=actor,
                fallback_state=last_state,
            )

            # A 1.7.4 skill response is a generic ChatMessageDTO envelope and
            # normally appears after ActiveDotSkillCard has already become
            # null.  Scan from the retained completed observation instead of
            # requiring the QTE object to remain active.
            should_scan_result = bool(
                pending is not None
                and pending.status is QteBindingStatus.COMPLETED_CURRENT
                and pending_completion_epoch is not None
                and dto_class is not None
                and now - last_result_scan >= 0.1
            )
            if should_scan_result:
                last_result_scan = now
                result_scan_number += 1
                all_regions = _regions(target, args.max_region_mib)
                learned_result_regions.update(provider.transport_region_hints)
                results = _scan_qte_results(
                    target,
                    dto_class=dto_class,
                    match_id=session.match_id,
                    all_regions=all_regions,
                    learned_regions=learned_result_regions,
                    full=(
                        not learned_result_regions
                        or result_scan_number % 8 == 0
                    ),
                    chunk_mib=args.chunk_mib,
                )
                observed_epoch = time.time()
                for result in results:
                    if result.address in seen_results:
                        continue
                    seen_results.add(result.address)
                    payload_ints = dict(result.payload_ints)
                    response_skill_card_id = (
                        result.skill_card_id
                        if result.skill_card_id is not None
                        else payload_ints.get("skillCardId")
                    )
                    correlation = correlate_qte_response_envelope(
                        pending,
                        event_type=result.event_type,
                        match_id=result.match_id,
                        skill_card_id=response_skill_card_id,
                        reject_reason=result.reject_reason,
                        payload_bools=result.payload_bools,
                        server_timestamp_epoch=_server_timestamp_epoch(result.timestamp),
                        completion_epoch=pending_completion_epoch,
                        observed_epoch=observed_epoch,
                    )
                    _write(
                        log,
                        "qte_result_message",
                        session=_session_text(session),
                        result=result,
                        correlation=correlation,
                        predicted=pending.predicted_timing_result,
                        displayed=(
                            pending.qte.displayed_timing_result
                            if pending.qte is not None
                            else None
                        ),
                        before=pending_before,
                        after={
                            "turn": runtime.turn,
                            "currentTurnPlayer": runtime.current_player,
                            **current_resource,
                        },
                    )
                    if correlation.current:
                        completed_qtes += 1
                        identity = pending.identity
                        shadow_result = None
                        resource_turn = None
                        if identity is not None:
                            closed_identities.add(identity)
                            server_timing = dict(result.payload_strings).get(
                                "timingResult"
                            )
                            shadow_result = shadow_observer.correlate_server_response(
                                generation=identity.observer_generation,
                                response_key=f"0x{result.address:016X}",
                                match_id=result.match_id,
                                skill_card_id=response_skill_card_id,
                                correlation=correlation,
                                server_timing_result=server_timing,
                            )
                            post_actor = (
                                actor
                                if runtime.current_player == runtime.local_username
                                else current_resource.get("bossActor")
                                if runtime.current_player
                                else None
                            )
                            automatic_effect_overlap = bool(
                                shadow_result is not None
                                and shadow_result.qte_family.value
                                == "AUTOMATIC_DOT_DESTRUCTION"
                                and pending_before is not None
                                and (
                                    current_resource["localHp"]
                                    != pending_before["localHp"]
                                    or current_resource["bossHp"]
                                    != pending_before["bossHp"]
                                    or current_resource["boardHash"]
                                    != pending_before["boardHash"]
                                    or runtime.turn != identity.turn_number
                                    or post_actor != identity.local_actor_number
                                )
                            )
                            resource_turn = shadow_observer.observe_resolution(
                                generation=identity.observer_generation,
                                mana_after=current_resource["mana"],
                                power_after=current_resource["power"],
                                post_resolution_turn=runtime.turn,
                                post_resolution_local_actor=post_actor,
                                concurrent_resource_change=automatic_effect_overlap,
                            )
                            _write(
                                log,
                                "qte_server_result_correlated",
                                session=_session_text(session),
                                generation=identity.observer_generation,
                                responseAddress=hex_pointer(result.address),
                                correlation=correlation,
                                serverResult=(
                                    shadow_result.server_resolved_result
                                    if shadow_result is not None
                                    else None
                                ),
                                serverResultRaw=server_timing,
                                timingEchoAvailable=server_timing is not None,
                            )
                            if resource_turn is not None:
                                resource_delta, turn_semantics = resource_turn
                                _write(
                                    log,
                                    "pet_skill_resource_delta",
                                    session=_session_text(session),
                                    generation=identity.observer_generation,
                                    resourceDelta=resource_delta,
                                )
                                _write(
                                    log,
                                    "pet_skill_turn_semantics_observed",
                                    session=_session_text(session),
                                    generation=identity.observer_generation,
                                    turnSemantics=turn_semantics,
                                )
                        _write(
                            log,
                            "qte_closed",
                            completedQtes=completed_qtes,
                            session=_session_text(session),
                            generation=(
                                identity.observer_generation
                                if identity is not None
                                else None
                            ),
                            correlationProvenance=correlation.provenance,
                            predictedTiming=pending.predicted_timing_result,
                            displayedTiming=(
                                pending.qte.displayed_timing_result
                                if pending.qte is not None
                                else None
                            ),
                            rawDisplayedTiming=(
                                pending.qte.displayed_timing_text
                                if pending.qte is not None
                                else None
                            ),
                            resourceDelta={
                                "mana": (
                                    None
                                    if pending_before is None
                                    or pending_before["mana"] is None
                                    or current_resource["mana"] is None
                                    else current_resource["mana"]
                                    - pending_before["mana"]
                                ),
                                "power": (
                                    None
                                    if pending_before is None
                                    or pending_before["power"] is None
                                    or current_resource["power"] is None
                                    else current_resource["power"]
                                    - pending_before["power"]
                                ),
                                "localHp": (
                                    None
                                    if pending_before is None
                                    or pending_before["localHp"] is None
                                    or current_resource["localHp"] is None
                                    else current_resource["localHp"]
                                    - pending_before["localHp"]
                                ),
                                "bossHp": (
                                    None
                                    if pending_before is None
                                    or pending_before["bossHp"] is None
                                    or current_resource["bossHp"] is None
                                    else current_resource["bossHp"]
                                    - pending_before["bossHp"]
                                ),
                            },
                            boardHashBefore=(
                                pending_before["boardHash"]
                                if pending_before is not None
                                else None
                            ),
                            boardHashAfter=current_resource["boardHash"],
                            turnBefore=(
                                pending_before["turn"]
                                if pending_before is not None
                                else None
                            ),
                            turnAfter=runtime.turn,
                            currentPlayerAfter=runtime.current_player,
                        )
                        pending = None
                        pending_before = None
                        pending_completion_epoch = None
                        break
            try:
                pet = read_player_pet_skill(
                    target.memory,
                    int(active_resolution.instance),
                    expected_pet_class=pet_class,
                    expected_card_class=card_data_class,
                )
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                _write(log, "pet_read_rejected", detail=str(exc), session=_session_text(session))
                pet = None
            pet_skill_valid = bool(
                pet is not None
                and pet.skill_card_id is not None
                and pet.card_data is not None
                and pet.card_identity_matches is True
            )
            if not pet_skill_valid:
                # A live evolution does not replace Active.playerPets: it can
                # remain the ordinary source pet with no skillCardId.  Keep
                # observing CardUI instead of blocking the QTE path here.
                signature = (
                    pet.address if pet else None,
                    pet.pet_id if pet else None,
                    "source_pet_skill_missing",
                )
                if signature != previous_pet_signature:
                    _write(
                        log,
                        "source_pet_skill_unavailable",
                        session=_session_text(session),
                        pet=pet,
                        nonBlocking=True,
                    )
                    previous_pet_signature = signature

            runtime_skill_cards = tuple(
                card
                for card in last_state.cards
                if card.element_type.upper() in DOT_SKILL_ELEMENT_TYPES
            )
            live_skill_candidates = [
                live_pet_skill_card_from_state(
                    card,
                    session_key=session,
                    active_instance=int(active_resolution.instance),
                )
                for card in runtime_skill_cards
            ]
            if len(runtime_skill_cards) == 1:
                runtime_card = runtime_skill_cards[0]
                skill_signature = (
                    session,
                    runtime_card.card_id,
                    runtime_card.data_address,
                    runtime_card.element_type,
                    runtime_card.skill_type,
                    runtime_card.mana_cost,
                    runtime_card.power_cost,
                    runtime_card.interactable,
                )
                if skill_signature != previous_skill_signature:
                    _write(
                        log,
                        "evolved_skill_card_available",
                        session=_session_text(session),
                        turn=runtime.turn,
                        localActor=actor,
                        sourcePet=pet,
                        card=runtime_card,
                        resource={
                            "mana": current_resource["mana"],
                            "power": current_resource["power"],
                        },
                    )
                    previous_skill_signature = skill_signature
            elif len(runtime_skill_cards) > 1:
                skill_signature = (
                    session,
                    "ambiguous",
                    tuple(
                        (card.card_id, card.data_address)
                        for card in runtime_skill_cards
                    ),
                )
                if skill_signature != previous_skill_signature:
                    _write(
                        log,
                        "evolved_skill_card_ambiguous",
                        session=_session_text(session),
                        cards=runtime_skill_cards,
                    )
                    previous_skill_signature = skill_signature

            if pet_skill_valid:
                matching_card = next(
                    (
                        card
                        for card in last_state.cards
                        if card.card_id == pet.skill_card_id
                        or card.data_address == pet.card_data_address
                    ),
                    None,
                )
                pet_signature = (
                    session,
                    pet.pet_id,
                    pet.skill_card_id,
                    pet.card_data.card_id,
                    pet.card_data.skill_type,
                    pet.card_data.mana_cost,
                    pet.card_data.power_cost,
                    matching_card.interactable if matching_card else None,
                )
                if pet_signature != previous_pet_signature:
                    _write(
                        log,
                        "pet_skill_identity",
                        session=_session_text(session),
                        turn=runtime.turn,
                        localActor=actor,
                        pet=pet,
                        currentCardUi=(
                            {
                                "address": hex_pointer(matching_card.object_address),
                                "interactable": matching_card.interactable,
                                "pending": matching_card.action_pending,
                                "usedThisTurn": matching_card.has_used_this_turn,
                                "usedThisMatch": matching_card.has_used_this_match,
                            }
                            if matching_card is not None
                            else None
                        ),
                        resource={
                            "mana": current_resource["mana"],
                            "power": current_resource["power"],
                        },
                    )
                    previous_pet_signature = pet_signature

            try:
                challenge = read_server_qte_challenge(
                    target.memory,
                    int(match_service_resolution.instance),
                    match_id=runtime.match_id or "",
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                challenge = None
            candidates = []
            active_qte_card = None
            active_qte_resolution = target.resolver.resolve_singleton(
                ACTIVE_DOT_SKILL_CARD
            )
            if (
                active_qte_resolution.resolved
                and active_qte_resolution.instance is not None
                and card_ui_class is not None
            ):
                try:
                    qte = read_card_ui_qte(
                        target.memory,
                        int(active_qte_resolution.instance),
                        expected_class=card_ui_class,
                        expected_board=session.board_instance,
                        expected_active=int(active_resolution.instance),
                        expected_card_data=None,
                        require_button=True,
                    )
                    active_qte_card = read_qte_card_data(
                        target.memory,
                        qte,
                        expected_card_class=card_data_class,
                    )
                    candidates.append(qte)
                    live_skill_candidates.append(
                        LivePetSkillCard(
                            session_key=session,
                            card_data=active_qte_card,
                            card_ui_address=qte.address,
                            board_instance=qte.board_instance,
                            active_instance=qte.active_instance,
                            button_address=qte.button_address,
                            button_interactable=qte.button_interactable,
                            button_validated=qte.button_validated,
                            source="CardUI.ActiveDotSkillCard",
                        )
                    )
                except (ExternalReadError, OSError, LayoutValidationError) as exc:
                    _write(
                        log,
                        "active_qte_rejected",
                        session=_session_text(session),
                        object=hex_pointer(active_qte_resolution.instance),
                        detail=str(exc),
                    )
            capability = capability_provider.observe(
                observed_at=time.time(),
                current_session=session,
                source_pet=pet,
                candidates=live_skill_candidates,
            )
            capability_signature = (
                capability.status,
                capability.session_key,
                capability.card_data_address,
                capability.live_card_address,
                capability.live_card_actionable,
                capability.effective_mana_cost,
                capability.effective_power_cost,
                capability.stale_reason,
            )
            if capability_signature != previous_capability_signature:
                _write(
                    log,
                    "pet_skill_capability_observed",
                    session=_session_text(session),
                    capability=capability,
                )
                if capability.live_card_present:
                    _write(
                        log,
                        "pet_skill_live_card_observed",
                        session=_session_text(session),
                        cardUi=hex_pointer(capability.live_card_address),
                        button=hex_pointer(capability.live_button_address),
                        interactable=capability.live_card_actionable,
                        observationOnly=True,
                    )
                elif capability.status in {
                    PetSkillCapabilityStatus.AMBIGUOUS,
                    PetSkillCapabilityStatus.STALE,
                    PetSkillCapabilityStatus.INVALID,
                }:
                    _write(
                        log,
                        "qte_ambiguous"
                        if capability.status is PetSkillCapabilityStatus.AMBIGUOUS
                        else "qte_stale_rejected",
                        session=_session_text(session),
                        capabilityStatus=capability.status,
                        detail=capability.stale_reason,
                    )
                previous_capability_signature = capability_signature
            if not candidates or active_qte_card is None:
                # Only a proven null singleton is an inactive edge.  A failed
                # or torn read must not manufacture freshness mid-QTE.
                if (
                    active_qte_resolution.status == "instance_null"
                    and active_qte_resolution.instance is None
                ):
                    tracker.note_inactive(session)
                    shadow_observer.note_inactive(session)
                time.sleep(args.interval)
                continue

            qte_card_signature = (
                session,
                active_qte_card.card_id,
                active_qte_card.address,
                active_qte_card.element_type,
                active_qte_card.skill_type,
                active_qte_card.mana_cost,
                active_qte_card.power_cost,
            )
            if qte_card_signature != previous_skill_signature:
                _write(
                    log,
                    "active_qte_skill_identity",
                    session=_session_text(session),
                    turn=runtime.turn,
                    localActor=actor,
                    sourcePet=pet,
                    card=active_qte_card,
                    resource={
                        "mana": current_resource["mana"],
                        "power": current_resource["power"],
                    },
                )
                previous_skill_signature = qte_card_signature

            if runtime.turn is None:
                rejection_signature = (session, "TURN_UNKNOWN")
                if rejection_signature != previous_shadow_rejection_signature:
                    _write(
                        log,
                        "qte_stale_rejected",
                        session=_session_text(session),
                        status="TURN_UNKNOWN",
                        detail="current MatchService turn is unavailable",
                    )
                    previous_shadow_rejection_signature = rejection_signature
                time.sleep(args.interval)
                continue

            context = QteBindingContext(
                session_key=session,
                local_actor_number=actor,
                skill_card_id=int(active_qte_card.card_id),
                card_data_address=int(active_qte_card.address),
                turn_number=int(runtime.turn),
                player_mana=current_resource["mana"],
                player_power=current_resource["power"],
            )
            observation = tracker.observe(
                context,
                candidates,
                challenge,
                element_type=active_qte_card.element_type,
            )
            shadow = shadow_observer.observe(
                observed_at=time.time(),
                session_key=session,
                observation=observation,
                capability=capability,
                player_mana=current_resource["mana"],
                player_power=current_resource["power"],
            )
            if shadow.observationally_current:
                if shadow.qte_generation != previous_shadow_generation:
                    _write(
                        log,
                        "qte_generation_started",
                        session=_session_text(session),
                        snapshot=shadow,
                    )
                    _write(
                        log,
                        "qte_perfect_window_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        perfectStart=shadow.perfect_start,
                        perfectEnd=shadow.perfect_end,
                        recommendedConfirmElapsed=shadow.recommended_confirm_elapsed,
                        source="MatchService.ServerQteWindow+CardUI",
                    )
                    previous_shadow_generation = shadow.qte_generation
                    previous_shadow_direction_signature = None
                    previous_shadow_progress_signature = None
                    previous_shadow_timing_signature = None
                    previous_shadow_runtime_result_signature = None
                direction_signature = (
                    shadow.qte_generation,
                    shadow.current_index,
                    shadow.expected_direction,
                )
                if direction_signature != previous_shadow_direction_signature:
                    _write(
                        log,
                        "qte_shadow_direction",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        index=shadow.current_index,
                        expectedDirection=shadow.expected_direction,
                        shadowOnly=True,
                    )
                    previous_shadow_direction_signature = direction_signature
                progress_signature = (
                    shadow.qte_generation,
                    shadow.current_index,
                    shadow.correct_count,
                    shadow.raw_presses,
                    shadow.completed,
                )
                if progress_signature != previous_shadow_progress_signature:
                    _write(
                        log,
                        "qte_progress_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        currentIndex=shadow.current_index,
                        correctCount=shadow.correct_count,
                        rawPresses=shadow.raw_presses,
                        normalizedPresses=shadow.presses,
                        completed=shadow.completed,
                    )
                    if shadow.completed:
                        compared = min(len(shadow.sequence), len(shadow.presses))
                        direction_matches = sum(
                            1
                            for expected, pressed in zip(
                                shadow.sequence, shadow.presses
                            )
                            if expected == pressed
                        )
                        _write(
                            log,
                            "qte_generation_completed",
                            session=_session_text(session),
                            generation=shadow.qte_generation,
                            qteElapsedMs=shadow.qte_elapsed_ms,
                            predicted=shadow.predicted_timing_result,
                            runtimeDisplay=shadow.runtime_display_result,
                            expectedDirections=shadow.sequence,
                            recordedPresses=shadow.presses,
                            comparedDirections=compared,
                            shadowDirectionMatches=direction_matches,
                            shadowDirectionMismatches=compared - direction_matches,
                            completeSequenceAgreement=(
                                shadow.sequence == shadow.presses
                            ),
                        )
                    previous_shadow_progress_signature = progress_signature
                timing_signature = (
                    shadow.qte_generation,
                    shadow.timing_region,
                    shadow.predicted_timing_result,
                )
                if timing_signature != previous_shadow_timing_signature:
                    _write(
                        log,
                        "qte_shadow_timing_prediction",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        elapsed=shadow.current_elapsed,
                        timingRegion=shadow.timing_region,
                        prediction=shadow.predicted_timing_result,
                        recommendedConfirmElapsed=shadow.recommended_confirm_elapsed,
                        shadowOnly=True,
                    )
                    previous_shadow_timing_signature = timing_signature
                runtime_result_signature = (
                    shadow.qte_generation,
                    shadow.runtime_result_text,
                    shadow.runtime_display_result,
                )
                if (
                    shadow.runtime_display_result is not None
                    and runtime_result_signature
                    != previous_shadow_runtime_result_signature
                ):
                    _write(
                        log,
                        "qte_runtime_result_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        rawText=shadow.runtime_result_text,
                        runtimeResult=shadow.runtime_display_result,
                        prediction=shadow.predicted_timing_result,
                        consistent=shadow.prediction_runtime_consistent,
                    )
                    previous_shadow_runtime_result_signature = runtime_result_signature
            elif shadow.evidence_status in {
                QteEvidenceStatus.STALE,
                QteEvidenceStatus.AMBIGUOUS,
            }:
                rejection_signature = (
                    session,
                    shadow.evidence_status,
                    shadow.ownership_status,
                    shadow.stale_reason,
                )
                if rejection_signature != previous_shadow_rejection_signature:
                    _write(
                        log,
                        "qte_ambiguous"
                        if shadow.evidence_status is QteEvidenceStatus.AMBIGUOUS
                        else "qte_stale_rejected",
                        session=_session_text(session),
                        status=shadow.ownership_status,
                        detail=shadow.stale_reason,
                    )
                    previous_shadow_rejection_signature = rejection_signature
            qte_signature = (
                observation.status,
                observation.identity,
                observation.qte.current_index if observation.qte else None,
                observation.qte.correct_count if observation.qte else None,
                observation.qte.finished if observation.qte else None,
                observation.qte.qte_presses if observation.qte else (),
                observation.qte.displayed_timing_text if observation.qte else None,
                observation.qte.displayed_timing_result if observation.qte else None,
                observation.predicted_timing_result,
            )
            if qte_signature != previous_qte_signature:
                _write(
                    log,
                    "qte_observation",
                    session=_session_text(session),
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    observation=observation,
                    playerResource=current_resource,
                )
                previous_qte_signature = qte_signature

            if (
                observation.current
                and observation.identity not in closed_identities
            ):
                if pending is None or pending.identity != observation.identity:
                    pending_before = {
                        "turn": runtime.turn,
                        "currentTurnPlayer": runtime.current_player,
                        **current_resource,
                    }
                    result_scan_number = 0
                    last_result_scan = 0.0
                pending = observation
                if (
                    observation.status is QteBindingStatus.COMPLETED_CURRENT
                    and pending_completion_epoch is None
                ):
                    pending_completion_epoch = time.time()

            time.sleep(args.interval)

        _write(log, "observer_stopped", completedQtes=completed_qtes)
        print(f"Observer stopped; QTE correlated: {completed_qtes}", flush=True)
        return 0


def main() -> int:
    try:
        return run(build_parser().parse_args())
    except (ProcessProbeError, OSError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
