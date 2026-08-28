from __future__ import annotations

from pathlib import Path
from types import SimpleNamespace
import unittest

from pokiguard_v2.boss_entry import (
    BossCandidate,
    BossLobbyState,
    BossTargetIdentity,
    FarmTarget,
    TargetResolutionStatus,
    TargetSelectionState,
    normalize_exact_name,
    resolve_target,
)
from pokiguard_v2.boss_entry_ui import (
    locate_chinh_phuc_attack_card_toggle,
    locate_chinh_phuc_start,
    locate_detached_chinh_phuc_room_shell_exit,
)
from pokiguard_v2.state import CombatSessionKey
from pokiguard_v2.win32_screenshot import read_png_rgb
from tools.boss_entry import (
    ATTACK_CARD_RENDER_PROOF_WINDOW_SECONDS,
    ATTACK_CARD_SELECTION_VERIFY_WINDOW_SECONDS,
    _attack_toggle_visuals_stable,
    _entry_opening_timeout_recovery_required,
    _entry_retry_runtime_valid,
    _entry_preflight_runtime_valid,
    _jsonable,
    _preentry_optional_card_mode,
    _retryable_board_messages,
)


V1_SCREENSHOTS = Path(r"D:\PokiguardAuto\GameScreenShoot")


def candidate(index: int, boss_id: str, name: str) -> BossCandidate:
    return BossCandidate(
        index,
        BossTargetIdentity(
            boss_id,
            name,
            room_id="Coop_fixture",
            pet_id=int(boss_id),
            source="fixture",
        ),
        TargetSelectionState.SELECTED,
        True,
        True,
        entry_control_address=0x100000 + index * 0x100,
    )


def synthetic_button_image(
    rects: tuple[tuple[float, float, float, float], ...],
    *,
    width: int = 960,
    height: int = 540,
) -> bytes:
    rgb = bytearray(bytes((18, 52, 105)) * width * height)

    def set_pixel(x: int, y: int, color: tuple[int, int, int]) -> None:
        offset = (y * width + x) * 3
        rgb[offset : offset + 3] = bytes(color)

    for left_n, top_n, right_n, bottom_n in rects:
        left, right = round(left_n * width), round(right_n * width)
        top, bottom = round(top_n * height), round(bottom_n * height)
        thickness = 6
        for y in range(top, bottom):
            for x in range(left, right):
                if (
                    x < left + thickness
                    or x >= right - thickness
                    or y < top + thickness
                    or y >= bottom - thickness
                ):
                    set_pixel(x, y, (28, 225, 250))
        text_left, text_right = left + (right - left) // 4, right - (right - left) // 4
        text_top = (top + bottom) // 2 - 5
        for y in range(text_top, text_top + 10):
            for x in range(text_left, text_right):
                set_pixel(x, y, (250, 170, 45))
    return bytes(rgb)


class BossEntryLoggingTests(unittest.TestCase):
    def test_postmatch_card_render_and_selection_waits_are_bounded(self) -> None:
        self.assertEqual(ATTACK_CARD_RENDER_PROOF_WINDOW_SECONDS, 15.0)
        self.assertEqual(ATTACK_CARD_SELECTION_VERIFY_WINDOW_SECONDS, 10.0)

    def test_attack_toggle_requires_two_consecutive_complete_frames(self) -> None:
        capture = SimpleNamespace(width=960, height=540)
        incomplete = SimpleNamespace(found=False, normalized_point=None)
        complete = SimpleNamespace(found=True, normalized_point=(0.5, 0.79))

        self.assertFalse(
            _attack_toggle_visuals_stable(
                capture, incomplete, capture, complete
            )
        )
        self.assertTrue(
            _attack_toggle_visuals_stable(
                capture, complete, capture, complete
            )
        )

    def test_attack_toggle_rejects_geometry_or_slot_change(self) -> None:
        complete = SimpleNamespace(found=True, normalized_point=(0.5, 0.79))
        changed_slot = SimpleNamespace(found=True, normalized_point=(0.6, 0.79))
        self.assertFalse(
            _attack_toggle_visuals_stable(
                SimpleNamespace(width=960, height=540),
                complete,
                SimpleNamespace(width=1280, height=720),
                complete,
            )
        )
        self.assertFalse(
            _attack_toggle_visuals_stable(
                SimpleNamespace(width=960, height=540),
                complete,
                SimpleNamespace(width=960, height=540),
                changed_slot,
            )
        )

    def test_advanced_current_board_routes_only_to_recovery_not_opening(self) -> None:
        active = CombatSessionKey(14, 0x22220000, "M_31f7fb40")
        exact = {
            "session": active,
            "matchId": active.match_id,
            "turn": 3,
            "firstLocalTurn": False,
            "localMoveSequence": 0,
            "srvSeq": 7,
            "boardHash": "f" * 64,
            "boardSource": "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board",
        }

        self.assertTrue(
            _entry_opening_timeout_recovery_required(
                active_session=active,
                current=exact,
                entry_clicks=1,
                gameplay_inputs=0,
            )
        )
        for changes in (
            {"active_session": CombatSessionKey(15, 0x22220008, "M_other")},
            {"current": {**exact, "turn": 1}},
            {"current": {**exact, "firstLocalTurn": True}},
            {"current": {**exact, "localMoveSequence": 1}},
            {"current": {**exact, "srvSeq": 0}},
            {"current": {**exact, "boardHash": ""}},
            {
                "current": {
                    **exact,
                    "boardSource": "ChatMessageDTO.MATCH_START.matchPayload.board",
                }
            },
            {"entry_clicks": 0},
            {"entry_clicks": 3},
            {"gameplay_inputs": 1},
        ):
            with self.subTest(changes=changes):
                kwargs = {
                    "active_session": active,
                    "current": exact,
                    "entry_clicks": 1,
                    "gameplay_inputs": 0,
                }
                kwargs.update(changes)
                self.assertFalse(
                    _entry_opening_timeout_recovery_required(**kwargs)
                )
        self.assertTrue(
            _entry_opening_timeout_recovery_required(
                active_session=active,
                current=exact,
                entry_clicks=2,
                gameplay_inputs=0,
            )
        )

    def test_entry_retry_requires_same_clean_room_target_button_and_no_owner(self) -> None:
        ready_candidate = candidate(0, "1289", "Starburst")
        ready_lobby = SimpleNamespace(
            chinh_phuc=SimpleNamespace(
                current_room_id="Coop_1",
                enemy_pet_id=1289,
                button_start=0x1234,
            )
        )
        ready = SimpleNamespace(
            resolution=SimpleNamespace(candidate=ready_candidate),
            lobby=ready_lobby,
        )
        current_candidate = candidate(0, "1289", "Starburst")
        current_lobby = SimpleNamespace(
            state=BossLobbyState.BOSS_LOBBY,
            branch="CHINH_PHUC_ROOM",
            chinh_phuc=SimpleNamespace(
                clean=True,
                current_room_id="Coop_1",
                enemy_pet_id=1289,
                button_start=0x1234,
                button_interactable=True,
                button_groups_allow=True,
                is_opening_flow=False,
            ),
        )
        resolution = SimpleNamespace(
            resolved=True,
            candidate=current_candidate,
        )
        self.assertTrue(
            _entry_retry_runtime_valid(
                current_lobby,
                resolution,
                ready,
                provider_session=None,
            )
        )
        self.assertFalse(
            _entry_retry_runtime_valid(
                current_lobby,
                resolution,
                ready,
                provider_session=object(),
            )
        )
        current_lobby.chinh_phuc.current_room_id = "Coop_other"
        self.assertFalse(
            _entry_retry_runtime_valid(
                current_lobby,
                resolution,
                ready,
                provider_session=None,
            )
        )

    def test_missing_optional_attack_uses_board_only_mode(self) -> None:
        self.assertEqual(
            _preentry_optional_card_mode(
                SimpleNamespace(manager_attack_card_count=0)
            ),
            "BOARD_ONLY_NO_ATTACK_CARD",
        )
        self.assertEqual(
            _preentry_optional_card_mode(
                SimpleNamespace(manager_attack_card_count=1)
            ),
            "ATTACK_CARD_AVAILABLE",
        )

    def test_binary_capture_is_summarized_instead_of_serialized(self) -> None:
        self.assertEqual(_jsonable(b"rgb"), {"byteLength": 3})
        self.assertEqual(_jsonable(bytearray(b"rgba")), {"byteLength": 4})

    def test_incomplete_board_dto_remains_retryable_until_decode_succeeds(self) -> None:
        start = SimpleNamespace(
            address=0x1000,
            event_type="MATCH_START",
            payload_address=0x2000,
        )
        move = SimpleNamespace(
            address=0x3000,
            event_type="MATCH_MOVE_RES",
            payload_address=0x4000,
        )
        unrelated = SimpleNamespace(
            address=0x5000,
            event_type="MATCH_TURN_END",
            payload_address=0x6000,
        )
        observation = SimpleNamespace(board_messages=(start, move, unrelated))

        first = _retryable_board_messages(observation, set())
        self.assertEqual(first, (start, move))
        # A failed decode does not mutate the successful-address set, so the
        # same still-live MATCH_START pointer must be retried next scan.
        self.assertEqual(_retryable_board_messages(observation, set()), first)
        self.assertEqual(
            _retryable_board_messages(observation, {start.address}),
            (move,),
        )

    def test_preflight_loadout_change_does_not_veto_same_target_and_button(self) -> None:
        ready_candidate = candidate(0, "1289", "Starburst")
        current_candidate = candidate(0, "1289", "Starburst")
        ready = SimpleNamespace(
            resolution=SimpleNamespace(candidate=ready_candidate),
            lobby=SimpleNamespace(
                chinh_phuc=SimpleNamespace(card_loadout=SimpleNamespace(identity=((1,),)))
            ),
        )
        current_lobby = SimpleNamespace(
            state=BossLobbyState.BOSS_LOBBY,
            branch="CHINH_PHUC_ROOM",
            chinh_phuc=SimpleNamespace(
                card_loadout=SimpleNamespace(identity=((1,), (2,)))
            ),
        )
        current_resolution = SimpleNamespace(
            resolved=True,
            candidate=current_candidate,
        )

        self.assertTrue(
            _entry_preflight_runtime_valid(current_lobby, current_resolution, ready)
        )

        current_candidate = BossCandidate(
            current_candidate.index,
            current_candidate.identity,
            current_candidate.selection,
            current_candidate.available,
            current_candidate.active,
            entry_control_address=current_candidate.entry_control_address + 8,
        )
        current_resolution.candidate = current_candidate
        self.assertFalse(
            _entry_preflight_runtime_valid(current_lobby, current_resolution, ready)
        )


class BossTargetResolutionTests(unittest.TestCase):
    def test_single_exact_id_target(self) -> None:
        result = resolve_target(
            FarmTarget(boss_id="1289"),
            (candidate(0, "1289", "Starburst"), candidate(1, "1300", "Other")),
        )
        self.assertEqual(result.status, TargetResolutionStatus.RESOLVED)
        self.assertEqual(result.candidate.identity.boss_name, "Starburst")

    def test_target_missing(self) -> None:
        result = resolve_target(
            FarmTarget(boss_name="Starburst"),
            (candidate(0, "1300", "Other"),),
        )
        self.assertEqual(result.status, TargetResolutionStatus.MISSING)
        self.assertIsNone(result.candidate)

    def test_multiple_exact_matches_are_ambiguous(self) -> None:
        result = resolve_target(
            FarmTarget(boss_id="1289"),
            (candidate(0, "1289", "Starburst"), candidate(1, "1289", "Clone")),
        )
        self.assertEqual(result.status, TargetResolutionStatus.AMBIGUOUS)
        self.assertEqual(len(result.matches), 2)

    def test_name_normalization_is_exact_nfc_casefold_only(self) -> None:
        self.assertEqual(normalize_exact_name("  TIẾN HÓA  "), "tiến hóa")
        result = resolve_target(
            FarmTarget(boss_name="STARburst"),
            (candidate(0, "1289", "Starburst"),),
        )
        self.assertEqual(result.status, TargetResolutionStatus.RESOLVED)
        fuzzy = resolve_target(
            FarmTarget(boss_name="Star burst"),
            (candidate(0, "1289", "Starburst"),),
        )
        self.assertEqual(fuzzy.status, TargetResolutionStatus.MISSING)


class BossEntryButtonLocatorTests(unittest.TestCase):
    def test_runtime_indexed_attack_toggle_requires_attack_visual_signature(self) -> None:
        width, height = 960, 540
        rgb = bytearray(bytes((18, 52, 105)) * width * height)
        center_x = 0.284 + 0.072 * 3
        left, right = round(width * (center_x - 0.030)), round(
            width * (center_x + 0.030)
        )
        top, header_bottom, bottom = (
            round(height * 0.715),
            round(height * 0.760),
            round(height * 0.860),
        )
        for y in range(top, header_bottom):
            for x in range(left, right):
                offset = (y * width + x) * 3
                rgb[offset : offset + 3] = bytes((30, 175, 225))
        for y in range(header_bottom, bottom):
            for x in range(left, right):
                offset = (y * width + x) * 3
                rgb[offset : offset + 3] = bytes((225, 105, 35))
        for y in range(header_bottom + 5, bottom - 5):
            for x in range(left + 18, left + 31):
                offset = (y * width + x) * 3
                rgb[offset : offset + 3] = bytes((45, 35, 25))

        located = locate_chinh_phuc_attack_card_toggle(
            bytes(rgb),
            width,
            height,
            room_card_count=4,
            attack_card_index=3,
        )
        self.assertTrue(located.found, located)
        self.assertAlmostEqual(located.normalized_point[0], 0.5, delta=0.005)  # type: ignore[index]
        wrong_slot = locate_chinh_phuc_attack_card_toggle(
            bytes(rgb),
            width,
            height,
            room_card_count=4,
            attack_card_index=0,
        )
        self.assertFalse(wrong_slot.found)
        unsupported = locate_chinh_phuc_attack_card_toggle(
            bytes(rgb),
            width,
            height,
            room_card_count=5,
            attack_card_index=3,
        )
        self.assertFalse(unsupported.found)

    def test_correct_single_button(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(((0.54, 0.76, 0.75, 0.86),))
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertTrue(located.found)
        self.assertEqual(located.metrics["candidateCount"], 1)
        self.assertGreaterEqual(located.confidence, 0.80)

    def test_button_missing(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(())
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertFalse(located.found)
        self.assertEqual(located.reason, "start_button_missing")

    def test_button_ambiguous(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(
            ((0.47, 0.77, 0.61, 0.85), (0.66, 0.77, 0.80, 0.85))
        )
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertFalse(located.found)
        self.assertEqual(located.reason, "start_button_ambiguous")
        self.assertEqual(len(located.candidates), 2)

    def test_detached_room_shell_requires_ready_control_and_circular_exit(self) -> None:
        width, height = 960, 540
        rgb = bytearray(
            synthetic_button_image(
                ((0.55, 0.75, 0.82, 0.87),), width=width, height=height
            )
        )
        center_x, center_y = round(width * 0.10), round(height * 0.08)
        radius_x, radius_y = round(width * 0.033), round(height * 0.052)

        def paint(x: int, y: int, color: tuple[int, int, int]) -> None:
            offset = (y * width + x) * 3
            rgb[offset : offset + 3] = bytes(color)

        for y in range(center_y - radius_y, center_y + radius_y + 1):
            for x in range(center_x - radius_x, center_x + radius_x + 1):
                if (
                    ((x - center_x) / radius_x) ** 2
                    + ((y - center_y) / radius_y) ** 2
                    <= 1.0
                ):
                    paint(x, y, (35, 205, 245))
        for delta in range(-12, 13):
            for thickness in range(-2, 3):
                paint(center_x + delta, center_y + delta + thickness, (245, 245, 245))
                paint(center_x + delta, center_y - delta + thickness, (245, 245, 245))

        located = locate_detached_chinh_phuc_room_shell_exit(
            bytes(rgb), width, height
        )
        self.assertTrue(located.found, located)
        self.assertEqual(
            located.reason, "single_room_start_plus_top_left_circular_exit"
        )
        self.assertAlmostEqual(located.normalized_point[0], 0.10, delta=0.015)  # type: ignore[index]
        self.assertAlmostEqual(located.normalized_point[1], 0.08, delta=0.015)  # type: ignore[index]

        map_without_room_control = bytearray(bytes((18, 52, 105)) * width * height)
        map_without_room_control[:] = rgb
        # Remove only the lower room Start/Ready proof; the same X by itself
        # must never authorize leaving the real island map.
        for y in range(round(height * 0.72), height):
            for x in range(round(width * 0.38), round(width * 0.88)):
                offset = (y * width + x) * 3
                map_without_room_control[offset : offset + 3] = bytes((18, 52, 105))
        rejected = locate_detached_chinh_phuc_room_shell_exit(
            bytes(map_without_room_control), width, height
        )
        self.assertFalse(rejected.found)
        self.assertEqual(rejected.reason, "room_shell_start_control_missing")

    @unittest.skipUnless(
        (V1_SCREENSHOTS / "waiting_room.png").exists(),
        "read-only PokiguardAuto reference is unavailable",
    )
    def test_v1_waiting_room_reference(self) -> None:
        image = read_png_rgb(V1_SCREENSHOTS / "waiting_room.png")
        located = locate_chinh_phuc_start(image.rgb, image.width, image.height)
        self.assertTrue(located.found)
        self.assertGreaterEqual(located.confidence, 0.90)

    @unittest.skipUnless(
        (V1_SCREENSHOTS / "waiting_room_with_selected_support_card.png").exists(),
        "read-only PokiguardAuto reference is unavailable",
    )
    def test_v1_selected_card_waiting_room_reference(self) -> None:
        image = read_png_rgb(
            V1_SCREENSHOTS / "waiting_room_with_selected_support_card.png"
        )
        located = locate_chinh_phuc_start(image.rgb, image.width, image.height)
        self.assertTrue(located.found)
        self.assertGreaterEqual(located.confidence, 0.90)


if __name__ == "__main__":
    unittest.main()
