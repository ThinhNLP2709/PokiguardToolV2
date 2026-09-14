from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.gameplay_profile import AuditionMode  # noqa: E402
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    AUDITION_CHALLENGE_CHALLENGE_ID_OFFSET,
    AUDITION_CHALLENGE_DISPLAY_OFFSET,
    AUDITION_CHALLENGE_DURATION_MS_OFFSET,
    AUDITION_CHALLENGE_EXPECTED_OFFSET,
    AUDITION_CHALLENGE_READ_SIZE,
    AUDITION_STAGE_CHALLENGE_OFFSET,
    AUDITION_STAGE_CORRECT_COUNT_OFFSET,
    AUDITION_STAGE_DURATION_MS_OFFSET,
    AUDITION_STAGE_DURATION_SECONDS_OFFSET,
    AUDITION_STAGE_GRADE_OFFSET,
    AUDITION_STAGE_HOST_OFFSET,
    AUDITION_STAGE_QTE_ELAPSED_OFFSET,
    AUDITION_STAGE_READ_SIZE,
    AUDITION_STAGE_TAP_ELAPSED_MS_OFFSET,
    AUDITION_STAGE_TAPPED_OFFSET,
    AUDITION_STAGE_CURSOR_OFFSET,
    AUDITION_STAGE_WAS_PERFECT_OFFSET,
    CARD_UI_ACTIVE_OFFSET,
    CARD_UI_AUDITION_V3_ELAPSED_MS_OFFSET,
    CARD_UI_AUDITION_V3_OFFSET,
    CARD_UI_BOARD_OFFSET,
    CARD_UI_BUTTON_OFFSET,
    CARD_UI_CARD_DATA_OFFSET,
    CARD_UI_CURRENT_ACTOR_OFFSET,
    CARD_UI_QTE_PRESSES_OFFSET,
    CARD_UI_READ_SIZE,
    MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_CHALLENGE_ID_OFFSET,
    MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_GREAT_MS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_LAYOUT_OFFSET,
    MATCH_SERVICE_SERVER_QTE_MULTIPLIERS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_READ_SIZE,
    MATCH_SERVICE_SERVER_QTE_REVERSE_FROM_OFFSET,
    MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET,
    QteBindingContext,
    QteBindingStatus,
    QteSessionTracker,
    QteWindowSnapshot,
    ServerQteChallengeSnapshot,
    read_audition_v3_qte,
    read_server_qte_challenge,
)
from pokiguard_v2.state import CombatSessionKey  # noqa: E402


class FakeMemory:
    def __init__(self) -> None:
        self.data: dict[int, int] = {}

    def map(self, address: int, value: bytes | bytearray) -> None:
        self.data.update({address + index: byte for index, byte in enumerate(value)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.data[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.data for index in range(size))


class AuditionFixture:
    BASE = 0x0000023000000000
    STAGE = BASE + 0x1000
    STAGE_CLASS = BASE + 0x2000
    CHALLENGE = BASE + 0x3000
    CHALLENGE_CLASS = BASE + 0x4000
    CARD_UI = BASE + 0x5000
    CARD_UI_CLASS = BASE + 0x6000
    CARD_NATIVE = BASE + 0x7000
    CARD_DATA = BASE + 0x8000
    BOARD = BASE + 0x9000
    ACTIVE = BASE + 0xA000
    BUTTON = BASE + 0xB000
    DISPLAY_LIST = BASE + 0xC000
    DISPLAY_ITEMS = BASE + 0xD000
    EXPECTED_LIST = BASE + 0xE000
    EXPECTED_ITEMS = BASE + 0xF000
    PRESS_LIST = BASE + 0x10000
    PRESS_ITEMS = BASE + 0x11000
    STRING_CLASS = BASE + 0x12000

    def __init__(self) -> None:
        self.memory = FakeMemory()
        for address in (
            self.STAGE_CLASS,
            self.CHALLENGE_CLASS,
            self.CARD_UI_CLASS,
            self.CARD_NATIVE,
            self.CARD_DATA,
            self.BOARD,
            self.ACTIVE,
            self.STRING_CLASS,
        ):
            self.memory.map(address, bytearray(8))
        button = bytearray(0xD9)
        button[0xD8] = 1
        self.memory.map(self.BUTTON, button)
        self.next_string = self.BASE + 0x20000

    def string(self, value: str) -> int:
        address = self.next_string
        self.next_string += 0x400
        raw = bytearray(0x14 + len(value) * 2)
        struct.pack_into("<Q", raw, 0, self.STRING_CLASS)
        struct.pack_into("<i", raw, 0x10, len(value))
        raw[0x14:] = value.encode("utf-16-le")
        self.memory.map(address, raw)
        return address

    def string_list(self, address: int, items: int, values: tuple[str, ...]) -> None:
        pointers = tuple(self.string(value) for value in values)
        raw = bytearray(0x20)
        struct.pack_into("<Qii", raw, 0x10, items, len(values), 1)
        self.memory.map(address, raw)
        array = bytearray(0x20 + 8 * len(values))
        struct.pack_into("<Q", array, 0x18, len(values))
        if pointers:
            struct.pack_into(f"<{len(pointers)}Q", array, 0x20, *pointers)
        self.memory.map(items, array)

    def build(
        self,
        *,
        display: tuple[str, ...] = ("nutLeft", "nutRight", "nutLeft"),
        expected: tuple[str, ...] = ("nutLeft", "nutLeft", "nutRight"),
        presses: tuple[str, ...] = ("nutLeft",),
        cursor: int = 1,
        correct: int = 1,
        elapsed_ms: int = 2800,
        tapped: bool = False,
        host_elapsed_ms: int | None = None,
        was_perfect: bool | None = None,
        grade: str | None = None,
    ):
        self.string_list(self.DISPLAY_LIST, self.DISPLAY_ITEMS, display)
        self.string_list(self.EXPECTED_LIST, self.EXPECTED_ITEMS, expected)
        self.string_list(self.PRESS_LIST, self.PRESS_ITEMS, presses)
        window = (5000, 2500, 3000, 2000, 2500, 3000, 3500)
        challenge = bytearray(AUDITION_CHALLENGE_READ_SIZE)
        struct.pack_into("<Q", challenge, 0, self.CHALLENGE_CLASS)
        struct.pack_into("<Q", challenge, AUDITION_CHALLENGE_DISPLAY_OFFSET, self.DISPLAY_LIST)
        struct.pack_into("<Q", challenge, AUDITION_CHALLENGE_EXPECTED_OFFSET, self.EXPECTED_LIST)
        struct.pack_into(
            "<9i",
            challenge,
            AUDITION_CHALLENGE_DURATION_MS_OFFSET,
            *window,
            1,
            450,
        )
        struct.pack_into("<3f", challenge, 0x44, 1.5, 1.2, 0.8)
        struct.pack_into(
            "<q", challenge, AUDITION_CHALLENGE_CHALLENGE_ID_OFFSET, 7001
        )
        self.memory.map(self.CHALLENGE, challenge)

        card = bytearray(CARD_UI_READ_SIZE)
        struct.pack_into("<Q", card, 0, self.CARD_UI_CLASS)
        struct.pack_into("<Q", card, 0x10, self.CARD_NATIVE)
        struct.pack_into("<Q", card, CARD_UI_CARD_DATA_OFFSET, self.CARD_DATA)
        struct.pack_into("<Q", card, CARD_UI_BUTTON_OFFSET, self.BUTTON)
        struct.pack_into("<Q", card, CARD_UI_BOARD_OFFSET, self.BOARD)
        struct.pack_into("<Q", card, CARD_UI_ACTIVE_OFFSET, self.ACTIVE)
        struct.pack_into("<i", card, CARD_UI_CURRENT_ACTOR_OFFSET, 7)
        card[CARD_UI_AUDITION_V3_OFFSET] = 1
        struct.pack_into(
            "<i",
            card,
            CARD_UI_AUDITION_V3_ELAPSED_MS_OFFSET,
            (
                host_elapsed_ms
                if host_elapsed_ms is not None
                else elapsed_ms if tapped else -1
            ),
        )
        struct.pack_into("<Q", card, CARD_UI_QTE_PRESSES_OFFSET, self.PRESS_LIST)
        self.memory.map(self.CARD_UI, card)

        stage = bytearray(AUDITION_STAGE_READ_SIZE)
        struct.pack_into("<Q", stage, 0, self.STAGE_CLASS)
        struct.pack_into("<Q", stage, AUDITION_STAGE_HOST_OFFSET, self.CARD_UI)
        stage[AUDITION_STAGE_TAPPED_OFFSET] = int(tapped)
        struct.pack_into(
            "<i", stage, AUDITION_STAGE_TAP_ELAPSED_MS_OFFSET, elapsed_ms if tapped else 0
        )
        struct.pack_into("<i", stage, AUDITION_STAGE_CORRECT_COUNT_OFFSET, correct)
        struct.pack_into("<Q", stage, AUDITION_STAGE_CHALLENGE_OFFSET, self.CHALLENGE)
        struct.pack_into("<i", stage, AUDITION_STAGE_CURSOR_OFFSET, cursor)
        struct.pack_into("<f", stage, AUDITION_STAGE_QTE_ELAPSED_OFFSET, elapsed_ms / 1000)
        struct.pack_into("<f", stage, AUDITION_STAGE_DURATION_SECONDS_OFFSET, 5.0)
        struct.pack_into("<i", stage, AUDITION_STAGE_DURATION_MS_OFFSET, 5000)
        stage[AUDITION_STAGE_WAS_PERFECT_OFFSET] = int(
            was_perfect
            if was_perfect is not None
            else not tapped and window[1] <= elapsed_ms <= window[2]
        )
        if grade is not None:
            struct.pack_into("<Q", stage, AUDITION_STAGE_GRADE_OFFSET, self.string(grade))
        self.memory.map(self.STAGE, stage)

        server = ServerQteChallengeSnapshot(
            match_id="M_V3",
            sequence_list_address=self.DISPLAY_LIST,
            raw_sequence=display,
            normalized_sequence=display,
            window=QteWindowSnapshot(*window),
            challenge_id=7001,
            layout="LR",
            reverse_from=1,
            great_ms=450,
            mult_perfect=1.5,
            mult_good=1.2,
            mult_bad=0.8,
            display_sequence=display,
        )
        return read_audition_v3_qte(
            self.memory,
            self.STAGE,
            server_challenge=server,
            expected_stage_class=self.STAGE_CLASS,
            expected_challenge_class=self.CHALLENGE_CLASS,
            expected_card_ui_class=self.CARD_UI_CLASS,
            expected_card_ui_address=self.CARD_UI,
            expected_board=self.BOARD,
            expected_active=self.ACTIVE,
            require_button=True,
        )


class AuditionV3Tests(unittest.TestCase):
    def test_server_challenge_accepts_native_no_reverse_sentinel(self) -> None:
        fixture = AuditionFixture()
        fixture.string_list(
            fixture.DISPLAY_LIST,
            fixture.DISPLAY_ITEMS,
            ("nutLeft", "nutRight", "nutLeft"),
        )
        match_service = fixture.BASE + 0x13000
        raw = bytearray(MATCH_SERVICE_SERVER_QTE_READ_SIZE)
        window = (5000, 3000, 3300, 2500, 3000, 3300, 4200)
        struct.pack_into(
            "<Q",
            raw,
            MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET,
            fixture.DISPLAY_LIST,
        )
        struct.pack_into(
            "<i", raw, MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET, window[0]
        )
        struct.pack_into(
            "<7i", raw, MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET, *window
        )
        struct.pack_into(
            "<Q",
            raw,
            MATCH_SERVICE_SERVER_QTE_LAYOUT_OFFSET,
            fixture.string("LR"),
        )
        struct.pack_into(
            "<i", raw, MATCH_SERVICE_SERVER_QTE_REVERSE_FROM_OFFSET, -1
        )
        struct.pack_into(
            "<i", raw, MATCH_SERVICE_SERVER_QTE_GREAT_MS_OFFSET, 150
        )
        struct.pack_into(
            "<3f", raw, MATCH_SERVICE_SERVER_QTE_MULTIPLIERS_OFFSET, 1.5, 1.2, 0.8
        )
        struct.pack_into(
            "<q", raw, MATCH_SERVICE_SERVER_QTE_CHALLENGE_ID_OFFSET, 7001
        )
        fixture.memory.map(match_service, raw)

        challenge = read_server_qte_challenge(
            fixture.memory,
            match_service,
            match_id="M_V3",
        )

        self.assertEqual(challenge.reverse_from, -1)
        self.assertEqual(challenge.layout, "LR")

        struct.pack_into(
            "<i", raw, MATCH_SERVICE_SERVER_QTE_REVERSE_FROM_OFFSET, -2
        )
        fixture.memory.map(match_service, raw)
        with self.assertRaisesRegex(LayoutValidationError, "reverseFrom.*-2"):
            read_server_qte_challenge(
                fixture.memory,
                match_service,
                match_id="M_V3",
            )

    def test_reader_uses_game_built_expected_sequence_and_stage_progress(self) -> None:
        fixture = AuditionFixture()
        qte, challenge = fixture.build()
        self.assertEqual(challenge.display_sequence, ("nutLeft", "nutRight", "nutLeft"))
        self.assertEqual(challenge.raw_sequence, ("nutLeft", "nutLeft", "nutRight"))
        self.assertEqual(qte.current_index, 1)
        self.assertEqual(qte.correct_count, 1)
        self.assertEqual(qte.qte_presses, ("nutLeft",))
        self.assertEqual(qte.qte_elapsed_ms, 2800)
        self.assertEqual(qte.audition_mode, AuditionMode.V3_TWO_DIRECTION.value)
        self.assertEqual(qte.runtime_owner_address, fixture.STAGE)

    def test_reader_accepts_native_untapped_host_elapsed_sentinel_only(self) -> None:
        fixture = AuditionFixture()
        qte, _challenge = fixture.build(presses=(), cursor=0, correct=0)
        self.assertFalse(qte.finished)
        self.assertEqual(qte.qte_elapsed_ms, 2800)

        with self.assertRaisesRegex(LayoutValidationError, "hostTapElapsedMs=-2"):
            fixture.build(
                presses=(), cursor=0, correct=0, host_elapsed_ms=-2
            )

    def test_untapped_perfect_zone_highlight_does_not_require_result_grade(self) -> None:
        fixture = AuditionFixture()
        qte, _challenge = fixture.build(
            presses=("nutLeft", "nutLeft", "nutRight"),
            cursor=3,
            correct=3,
            elapsed_ms=2800,
            tapped=False,
            was_perfect=True,
            grade=None,
        )
        self.assertFalse(qte.finished)
        self.assertIsNone(qte.displayed_timing_result)
        self.assertEqual(qte.qte_elapsed_ms, 2800)

    def test_v3_tracker_binds_lr_stage_and_rejects_v2_mode(self) -> None:
        fixture = AuditionFixture()
        qte, challenge = fixture.build(presses=(), cursor=0, correct=0)
        context = QteBindingContext(
            CombatSessionKey(1, fixture.BOARD, "M_V3"),
            7,
            321,
            fixture.CARD_DATA,
            4,
        )
        tracker = QteSessionTracker(AuditionMode.V3_TWO_DIRECTION)
        tracker.observe(context, (), challenge, element_type="ATTACK_LEGEND_")
        bound = tracker.observe(context, (qte,), challenge, element_type="ATTACK_LEGEND_")
        self.assertIs(bound.status, QteBindingStatus.BOUND_CURRENT)
        self.assertEqual(bound.identity.runtime_owner_address, fixture.STAGE)
        legacy = QteSessionTracker(AuditionMode.V2_FOUR_DIRECTION)
        legacy.observe(context, (), challenge, element_type="ATTACK_LEGEND_")
        rejected = legacy.observe(context, (qte,), challenge, element_type="ATTACK_LEGEND_")
        self.assertIs(rejected.status, QteBindingStatus.UNKNOWN_DIRECTION)

    def test_tapped_stage_exposes_exact_perfect_and_tap_elapsed(self) -> None:
        fixture = AuditionFixture()
        qte, _challenge = fixture.build(
            presses=("nutLeft", "nutLeft", "nutRight"),
            cursor=3,
            correct=3,
            tapped=True,
            grade="PERFECT",
        )
        self.assertTrue(qte.finished)
        self.assertEqual(qte.displayed_timing_result, "PERFECT!")
        self.assertEqual(qte.qte_elapsed_ms, 2800)

    def test_non_lr_expected_direction_fails_closed(self) -> None:
        fixture = AuditionFixture()
        with self.assertRaisesRegex(LayoutValidationError, "LR challenge"):
            fixture.build(expected=("nutLeft", "nutUp", "nutRight"))


if __name__ == "__main__":
    unittest.main()
