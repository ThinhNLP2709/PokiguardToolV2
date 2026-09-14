from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    ACTIVE_PLAYER_PET_OFFSET,
    CARD_UI_ACTIVE_FLAG_OFFSET,
    CARD_UI_CORRECT_COUNT_OFFSET,
    CARD_UI_CURRENT_ACTOR_OFFSET,
    CARD_UI_CURRENT_ARROW_SEED_OFFSET,
    CARD_UI_CURRENT_ARROWS_OFFSET,
    CARD_UI_CURRENT_INDEX_OFFSET,
    CARD_UI_CURRENT_TIME_VALUE_OFFSET,
    CARD_UI_DAMAGE_MULTIPLIER_OFFSET,
    CARD_UI_DURATION_OFFSET,
    CARD_UI_FINISHED_OFFSET,
    CARD_UI_GOOD_END_1_OFFSET,
    CARD_UI_GOOD_END_2_OFFSET,
    CARD_UI_GOOD_START_1_OFFSET,
    CARD_UI_GOOD_START_2_OFFSET,
    CARD_UI_PERFECT_START_OFFSET,
    CARD_UI_QTE_PRESSES_OFFSET,
    CARD_UI_QTE_ARROWS_FROM_SERVER_OFFSET,
    CARD_UI_READ_SIZE,
    CARD_UI_TIMING_BONUS_OFFSET,
    CARD_UI_TIMING_TEXT_OFFSET,
    CHAT_MESSAGE_QTE_RESULT_READ_SIZE,
    CHAT_MESSAGE_TYPE_OFFSET,
    CHAT_MESSAGE_MATCH_ID_OFFSET,
    CHAT_MESSAGE_SKILL_CARD_ID_OFFSET,
    CHAT_MESSAGE_CORRECT_DOT_COUNT_OFFSET,
    CHAT_MESSAGE_TIMING_RESULT_OFFSET,
    CHAT_MESSAGE_DOTS_TO_DESTROY_OFFSET,
    CHAT_MESSAGE_QTE_PRESSES_OFFSET,
    CHAT_MESSAGE_QTE_ELAPSED_MS_OFFSET,
    CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET,
    MATCH_SERVICE_SERVER_QTE_READ_SIZE,
    MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET,
    MATCH_SERVICE_SERVER_QTE_CHALLENGE_ID_OFFSET,
    MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET,
    PET_USER_READ_SIZE,
    CardUiQteSnapshot,
    QteBindingContext,
    QteBindingStatus,
    QteSessionTracker,
    QteWindowSnapshot,
    ServerQteChallengeSnapshot,
    classify_qte_timing,
    correlate_qte_response_envelope,
    correlate_qte_result,
    normalize_displayed_timing_result,
    normalize_qte_direction,
    read_card_ui_qte,
    read_player_pet_skill,
    read_qte_card_data,
    read_qte_result_message,
    read_server_qte_challenge,
    select_single_qte_candidate,
)
from pokiguard_v2.state import CombatSessionKey  # noqa: E402


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


class MutatingQteMemory(FakeMemory):
    def __init__(self, qte_address: int, offset: int, replacement: bytes) -> None:
        super().__init__()
        self.qte_address = qte_address
        self.offset = offset
        self.replacement = replacement
        self.qte_reads = 0

    def read(self, address: int, size: int) -> bytes:
        if address == self.qte_address and size == CARD_UI_READ_SIZE:
            self.qte_reads += 1
            if self.qte_reads == 2:
                self.map(self.qte_address + self.offset, self.replacement)
        return super().read(address, size)


class Fixture:
    BASE = 0x0000021000000000
    ACTIVE = BASE + 0x1000
    PET = BASE + 0x2000
    PET_CLASS = BASE + 0x3000
    CARD = BASE + 0x4000
    CARD_CLASS = BASE + 0x5000
    STRING_CLASS = BASE + 0x6000
    ELEMENT = BASE + 0x7000
    SKILL = BASE + 0x8000
    MATCH_SERVICE = BASE + 0x9000
    SERVER_LIST = BASE + 0xA000
    SERVER_ITEMS = BASE + 0xB000
    QTE = BASE + 0xC000
    QTE_CLASS = BASE + 0xD000
    QTE_NATIVE = BASE + 0xE000
    BOARD = BASE + 0xF000
    QTE_LIST = BASE + 0x10000
    QTE_ITEMS = BASE + 0x11000
    RESULT = BASE + 0x12000
    RESULT_CLASS = BASE + 0x13000
    ARROW_LIST = BASE + 0x14000
    ARROW_ITEMS = BASE + 0x15000
    TIMING_TEXT = BASE + 0x16000
    BUTTON = BASE + 0x17000

    def __init__(self) -> None:
        self.memory = FakeMemory()
        for pointer in (
            self.PET_CLASS,
            self.CARD_CLASS,
            self.STRING_CLASS,
            self.QTE_CLASS,
            self.QTE_NATIVE,
            self.RESULT_CLASS,
        ):
            self.memory.map(pointer, bytearray(8))
        self._next_string = self.BASE + 0x20000

    def string(self, value: str) -> int:
        address = self._next_string
        self._next_string += 0x400
        raw = bytearray(0x14 + len(value) * 2)
        struct.pack_into("<Q", raw, 0, self.STRING_CLASS)
        struct.pack_into("<i", raw, 0x10, len(value))
        raw[0x14:] = value.encode("utf-16-le")
        self.memory.map(address, raw)
        return address

    def string_list(
        self, list_address: int, items_address: int, values: tuple[str, ...]
    ) -> None:
        pointers = tuple(self.string(value) for value in values)
        raw_list = bytearray(0x20)
        struct.pack_into("<Qii", raw_list, 0x10, items_address, len(values), 1)
        self.memory.map(list_address, raw_list)
        raw_items = bytearray(0x20 + len(values) * 8)
        struct.pack_into("<Q", raw_items, 0x18, len(values))
        if pointers:
            struct.pack_into(f"<{len(pointers)}Q", raw_items, 0x20, *pointers)
        self.memory.map(items_address, raw_items)

    def map_pet(
        self,
        *,
        skill_card_id: int = 321,
        mana_cost: int = 200,
        power_cost: int = 150,
    ) -> None:
        active = bytearray(ACTIVE_PLAYER_PET_OFFSET + 8)
        struct.pack_into("<Q", active, ACTIVE_PLAYER_PET_OFFSET, self.PET)
        self.memory.map(self.ACTIVE, active)
        pet = bytearray(PET_USER_READ_SIZE)
        struct.pack_into("<Q", pet, 0, self.PET_CLASS)
        struct.pack_into("<i", pet, 0x10, 91)
        pet[0x14] = 1
        struct.pack_into("<i", pet, 0x18, 77)
        struct.pack_into("<i", pet, 0x1C, 1289)
        struct.pack_into("<i", pet, 0x20, skill_card_id)
        struct.pack_into("<ii", pet, 0x50, 73, 100)
        struct.pack_into("<i", pet, 0x70, 200)
        struct.pack_into("<i", pet, 0x78, 3)
        if skill_card_id:
            struct.pack_into("<Q", pet, 0x98, self.CARD)
        self.memory.map(self.PET, pet)
        if not skill_card_id:
            return
        element = self.string("ATTACK_LEGEND_")
        skill = self.string("ATTACK_LEGEND_")
        name = self.string("Legendary Pet Skill")
        card = bytearray(0x9C)
        struct.pack_into("<Q", card, 0, self.CARD_CLASS)
        struct.pack_into("<qq", card, 0x10, 9001, skill_card_id)
        struct.pack_into("<Q", card, 0x20, name)
        struct.pack_into("<Q", card, 0x30, element)
        struct.pack_into("<Q", card, 0x78, skill)
        struct.pack_into("<iii", card, 0x80, mana_cost, power_cost, 2)
        card[0x8C] = 1
        struct.pack_into("<iii", card, 0x90, 12, 8, 4)
        self.memory.map(self.CARD, card)

    def map_server(
        self,
        sequence: tuple[str, ...] = ("up", "nutLeft", "RIGHT"),
        *,
        window: tuple[int, ...] = (5000, 2500, 3000, 2000, 2500, 3000, 3500),
        challenge_id: int = 7001,
    ) -> None:
        self.string_list(self.SERVER_LIST, self.SERVER_ITEMS, sequence)
        raw = bytearray(MATCH_SERVICE_SERVER_QTE_READ_SIZE)
        struct.pack_into(
            "<Q", raw, MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET, self.SERVER_LIST
        )
        struct.pack_into(
            "<i", raw, MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET, window[0]
        )
        struct.pack_into(
            "<7i", raw, MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET, *window
        )
        struct.pack_into(
            "<q", raw, MATCH_SERVICE_SERVER_QTE_CHALLENGE_ID_OFFSET, challenge_id
        )
        self.memory.map(self.MATCH_SERVICE, raw)

    def map_qte(
        self,
        *,
        address: int | None = None,
        active: bool = True,
        finished: bool = False,
        index: int = 1,
        correct: int = 1,
        actor: int = 7,
        card: int | None = None,
        board: int | None = None,
        perfect_start: float = 2.5,
        perfect_end: float = 3.0,
        presses: tuple[str, ...] = ("nutUp",),
        displayed_timing: str | None = None,
        with_button: bool = False,
        arrows_from_server: bool = True,
    ) -> int:
        address = address or self.QTE
        native = self.QTE_NATIVE if address == self.QTE else address + 0x500
        self.memory.map(native, bytearray(8))
        self.string_list(self.QTE_LIST, self.QTE_ITEMS, presses)
        arrow_list = bytearray(0x20)
        struct.pack_into("<Qii", arrow_list, 0x10, self.ARROW_ITEMS, 3, 1)
        self.memory.map(self.ARROW_LIST, arrow_list)
        arrow_items = bytearray(0x20)
        struct.pack_into("<Q", arrow_items, 0x18, 3)
        self.memory.map(self.ARROW_ITEMS, arrow_items)
        raw = bytearray(CARD_UI_READ_SIZE)
        struct.pack_into("<Q", raw, 0, self.QTE_CLASS)
        struct.pack_into("<Q", raw, 0x10, native)
        struct.pack_into("<Q", raw, 0x20, card or self.CARD)
        if with_button:
            button = bytearray(0xD9)
            button[0xD8] = 1
            self.memory.map(self.BUTTON, button)
            struct.pack_into("<Q", raw, 0x28, self.BUTTON)
        struct.pack_into("<Q", raw, 0x30, board or self.BOARD)
        struct.pack_into("<Q", raw, 0x38, self.ACTIVE)
        struct.pack_into("<i", raw, CARD_UI_CURRENT_ACTOR_OFFSET, actor)
        struct.pack_into("<f", raw, CARD_UI_DURATION_OFFSET, 5.0)
        if displayed_timing is not None:
            timing_text = bytearray(0xF0)
            struct.pack_into("<Q", timing_text, 0xE8, self.string(displayed_timing))
            self.memory.map(self.TIMING_TEXT, timing_text)
            struct.pack_into("<Q", raw, CARD_UI_TIMING_TEXT_OFFSET, self.TIMING_TEXT)
        struct.pack_into("<Q", raw, CARD_UI_CURRENT_ARROWS_OFFSET, self.ARROW_LIST)
        struct.pack_into("<i", raw, CARD_UI_CURRENT_INDEX_OFFSET, index)
        struct.pack_into("<i", raw, CARD_UI_CORRECT_COUNT_OFFSET, correct)
        raw[CARD_UI_ACTIVE_FLAG_OFFSET] = int(active)
        struct.pack_into(
            "<f", raw, CARD_UI_CURRENT_TIME_VALUE_OFFSET, 0.44
        )  # elapsed = 2.8 seconds
        struct.pack_into("<f", raw, CARD_UI_DAMAGE_MULTIPLIER_OFFSET, 1.5)
        raw[CARD_UI_FINISHED_OFFSET] = int(finished)
        struct.pack_into(
            "<6f",
            raw,
            CARD_UI_PERFECT_START_OFFSET,
            perfect_start,
            perfect_end,
            2.0,
            2.5,
            3.0,
            3.5,
        )
        struct.pack_into("<i", raw, CARD_UI_TIMING_BONUS_OFFSET, 2)
        struct.pack_into("<i", raw, CARD_UI_CURRENT_ARROW_SEED_OFFSET, 7009)
        struct.pack_into("<Q", raw, CARD_UI_QTE_PRESSES_OFFSET, self.QTE_LIST)
        raw[CARD_UI_QTE_ARROWS_FROM_SERVER_OFFSET] = int(arrows_from_server)
        self.memory.map(address, raw)
        return address

    def read_qte(self, **kwargs: object) -> CardUiQteSnapshot:
        address = self.map_qte(**kwargs)
        return read_card_ui_qte(
            self.memory,
            address,
            expected_class=self.QTE_CLASS,
            expected_board=self.BOARD,
            expected_active=self.ACTIVE,
            expected_card_data=self.CARD,
        )

    def challenge(self, match_id: str = "M_A") -> ServerQteChallengeSnapshot:
        return read_server_qte_challenge(
            self.memory, self.MATCH_SERVICE, match_id=match_id
        )


def context(match_id: str = "M_A", epoch: int = 1) -> QteBindingContext:
    return QteBindingContext(
        CombatSessionKey(epoch, Fixture.BOARD, match_id),
        local_actor_number=7,
        skill_card_id=321,
        card_data_address=Fixture.CARD,
        turn_number=9,
        player_mana=500,
        player_power=200,
    )


def bind(
    tracker: QteSessionTracker,
    ctx: QteBindingContext,
    qte: CardUiQteSnapshot,
    challenge: ServerQteChallengeSnapshot,
):
    tracker.observe(ctx, (), challenge, element_type="ATTACK_LEGEND_")
    return tracker.observe(ctx, (qte,), challenge, element_type="ATTACK_LEGEND_")


class PetQteObserverTests(unittest.TestCase):
    def test_card_data_extraction_uses_current_pet_card(self) -> None:
        fixture = Fixture()
        fixture.map_pet()
        pet = read_player_pet_skill(
            fixture.memory,
            fixture.ACTIVE,
            expected_pet_class=fixture.PET_CLASS,
            expected_card_class=fixture.CARD_CLASS,
        )
        self.assertIsNotNone(pet)
        self.assertEqual((pet.pet_id, pet.skill_card_id), (1289, 321))
        self.assertEqual((pet.card_data.mana_cost, pet.card_data.power_cost), (200, 150))
        self.assertEqual(pet.card_data.skill_type, "ATTACK_LEGEND_")
        self.assertTrue(pet.card_identity_matches)

    def test_missing_skill_card_id_remains_none(self) -> None:
        fixture = Fixture()
        fixture.map_pet(skill_card_id=0)
        pet = read_player_pet_skill(fixture.memory, fixture.ACTIVE)
        self.assertIsNone(pet.skill_card_id)
        self.assertIsNone(pet.card_data)
        self.assertIsNone(pet.card_identity_matches)

    def test_post_evolution_qte_binds_from_runtime_card_when_source_pet_has_no_skill(
        self,
    ) -> None:
        fixture = Fixture()
        fixture.map_pet()
        fixture.map_pet(skill_card_id=0)
        fixture.map_server()
        source_pet = read_player_pet_skill(fixture.memory, fixture.ACTIVE)
        self.assertIsNone(source_pet.skill_card_id)

        qte = fixture.read_qte()
        runtime_card = read_qte_card_data(
            fixture.memory,
            qte,
            expected_card_class=fixture.CARD_CLASS,
        )
        ctx = QteBindingContext(
            CombatSessionKey(1, fixture.BOARD, "M_A"),
            local_actor_number=7,
            skill_card_id=runtime_card.card_id,
            card_data_address=runtime_card.address,
            turn_number=9,
            player_mana=500,
            player_power=200,
        )
        tracker = QteSessionTracker()
        tracker.note_inactive(ctx.session_key)
        result = tracker.observe(
            ctx,
            (qte,),
            fixture.challenge(),
            element_type=runtime_card.element_type,
        )
        self.assertEqual(runtime_card.element_type, "ATTACK_LEGEND_")
        self.assertIs(result.status, QteBindingStatus.BOUND_CURRENT)

    def test_zero_cost_is_preserved_and_negative_cost_is_rejected(self) -> None:
        fixture = Fixture()
        fixture.map_pet(mana_cost=0, power_cost=0)
        pet = read_player_pet_skill(fixture.memory, fixture.ACTIVE)
        self.assertEqual((pet.card_data.mana_cost, pet.card_data.power_cost), (0, 0))
        fixture.map_pet(mana_cost=-1, power_cost=0)
        with self.assertRaises(LayoutValidationError):
            read_player_pet_skill(fixture.memory, fixture.ACTIVE)

    def test_qte_object_missing_is_not_a_candidate(self) -> None:
        value, status = select_single_qte_candidate(())
        self.assertIsNone(value)
        self.assertIs(status, QteBindingStatus.QTE_MISSING)

    def test_stale_qte_object_change_after_bind_is_rejected(self) -> None:
        fixture = Fixture()
        fixture.map_pet()
        fixture.map_server()
        first = fixture.read_qte()
        tracker = QteSessionTracker()
        observation = bind(tracker, context(), first, fixture.challenge())
        self.assertTrue(observation.current)
        second_address = fixture.BASE + 0x50000
        second = fixture.read_qte(address=second_address)
        changed = tracker.observe(
            context(), (second,), fixture.challenge(), element_type="ATTACK_LEGEND_"
        )
        self.assertIs(changed.status, QteBindingStatus.STALE_OR_CHANGED_QTE)

    def test_wrong_match_id_challenge_is_rejected(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        tracker.observe(context(), (), fixture.challenge("M_OLD"), element_type="ATTACK_LEGEND_")
        result = tracker.observe(
            context(),
            (fixture.read_qte(),),
            fixture.challenge("M_OLD"),
            element_type="ATTACK_LEGEND_",
        )
        self.assertIs(result.status, QteBindingStatus.WRONG_SESSION)

    def test_ambiguous_multiple_qte_candidates_fail_closed(self) -> None:
        fixture = Fixture()
        first = fixture.read_qte()
        second = fixture.read_qte(address=fixture.BASE + 0x50000)
        value, status = select_single_qte_candidate((first, second))
        self.assertIsNone(value)
        self.assertIs(status, QteBindingStatus.AMBIGUOUS_QTE_CANDIDATES)

    def test_sequence_extraction_matches_native_normalization(self) -> None:
        fixture = Fixture()
        fixture.map_server((" up ", "NUTdown", "Left", "nutRight"))
        challenge = fixture.challenge()
        self.assertEqual(
            challenge.normalized_sequence,
            ("nutUp", "nutDown", "nutLeft", "nutRight"),
        )
        self.assertEqual(challenge.challenge_id, 7001)
        self.assertTrue(challenge.sequence_known)
        self.assertEqual(normalize_qte_direction("  NuTUP "), "nutUp")

    def test_unknown_direction_remains_unknown(self) -> None:
        fixture = Fixture()
        fixture.map_server(("up", "diagonal"))
        challenge = fixture.challenge()
        self.assertEqual(challenge.normalized_sequence, ("nutUp", None))
        tracker = QteSessionTracker()
        tracker.observe(context(), (), challenge, element_type="ATTACK_LEGEND_")
        result = tracker.observe(
            context(), (fixture.read_qte(),), challenge, element_type="ATTACK_LEGEND_"
        )
        self.assertIs(result.status, QteBindingStatus.UNKNOWN_DIRECTION)

    def test_local_fallback_arrows_are_not_authoritative(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        result = bind(
            tracker,
            context(),
            fixture.read_qte(arrows_from_server=False),
            fixture.challenge(),
        )
        self.assertIs(result.status, QteBindingStatus.SEQUENCE_UNAVAILABLE)

    def test_active_server_qte_requires_current_challenge_id(self) -> None:
        fixture = Fixture()
        fixture.map_server(challenge_id=0)
        tracker = QteSessionTracker()
        result = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertIs(result.status, QteBindingStatus.SEQUENCE_UNAVAILABLE)

    def test_changed_server_challenge_id_invalidates_bound_generation(self) -> None:
        fixture = Fixture()
        fixture.map_server(challenge_id=7001)
        tracker = QteSessionTracker()
        first = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertTrue(first.current)
        fixture.map_server(challenge_id=7002)
        changed = tracker.observe(
            context(),
            (fixture.read_qte(),),
            fixture.challenge(),
            element_type="ATTACK_LEGEND_",
        )
        self.assertIs(changed.status, QteBindingStatus.STALE_OR_CHANGED_QTE)

    def test_one_torn_server_challenge_read_retains_exact_bound_prefix(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        first = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertTrue(first.current)

        bridged = tracker.observe_after_server_challenge_read_failure(
            context(),
            (
                fixture.read_qte(
                    index=2,
                    correct=2,
                    presses=("nutUp", "nutLeft"),
                ),
            ),
            element_type="ATTACK_LEGEND_",
            read_error="LayoutValidationError: changed during read",
        )

        self.assertIs(bridged.status, QteBindingStatus.BOUND_CURRENT)
        self.assertEqual(bridged.identity, first.identity)
        self.assertIn("bridged", bridged.reason)

    def test_torn_read_bridge_rejects_wrong_prefix_and_consecutive_failure(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        first = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertTrue(first.current)

        wrong = tracker.observe_after_server_challenge_read_failure(
            context(),
            (fixture.read_qte(index=2, correct=2, presses=("nutUp", "nutRight")),),
            element_type="ATTACK_LEGEND_",
            read_error="torn",
        )
        self.assertIs(wrong.status, QteBindingStatus.STALE_OR_CHANGED_QTE)

        tracker = QteSessionTracker()
        bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        accepted = tracker.observe_after_server_challenge_read_failure(
            context(),
            (fixture.read_qte(index=1, correct=1, presses=("nutUp",)),),
            element_type="ATTACK_LEGEND_",
            read_error="first",
        )
        self.assertTrue(accepted.current)
        rejected = tracker.observe_after_server_challenge_read_failure(
            context(),
            (fixture.read_qte(index=1, correct=1, presses=("nutUp",)),),
            element_type="ATTACK_LEGEND_",
            read_error="second",
        )
        self.assertIs(rejected.status, QteBindingStatus.STALE_OR_CHANGED_QTE)

    def test_fresh_server_read_resets_single_read_bridge_budget(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        first_bridge = tracker.observe_after_server_challenge_read_failure(
            context(),
            (fixture.read_qte(index=1, correct=1, presses=("nutUp",)),),
            element_type="ATTACK_LEGEND_",
            read_error="first",
        )
        self.assertTrue(first_bridge.current)
        fresh = tracker.observe(
            context(),
            (fixture.read_qte(index=1, correct=1, presses=("nutUp",)),),
            fixture.challenge(),
            element_type="ATTACK_LEGEND_",
        )
        self.assertTrue(fresh.current)
        second_bridge = tracker.observe_after_server_challenge_read_failure(
            context(),
            (fixture.read_qte(index=2, correct=2, presses=("nutUp", "nutLeft")),),
            element_type="ATTACK_LEGEND_",
            read_error="later",
        )
        self.assertTrue(second_bridge.current)

    def test_completed_bound_qte_survives_native_challenge_clear(self) -> None:
        fixture = Fixture()
        fixture.map_server(challenge_id=7001)
        tracker = QteSessionTracker()
        first = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertTrue(first.current)
        fixture.map_server(challenge_id=0)
        completed = tracker.observe(
            context(),
            (fixture.read_qte(finished=True, index=3, correct=7),),
            fixture.challenge(),
            element_type="ATTACK_LEGEND_",
        )
        self.assertIs(completed.status, QteBindingStatus.COMPLETED_CURRENT)
        self.assertEqual(completed.identity.server_challenge_id, 7001)

    def test_missing_timing_fields_are_invalid(self) -> None:
        fixture = Fixture()
        fixture.map_server(window=(0, 0, 0, 0, 0, 0, 0))
        tracker = QteSessionTracker()
        result = bind(tracker, context(), fixture.read_qte(), fixture.challenge())
        self.assertIs(result.status, QteBindingStatus.INVALID_TIMING)

    def test_inverted_perfect_interval_is_invalid(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        qte = fixture.read_qte(perfect_start=3.0, perfect_end=2.0)
        tracker = QteSessionTracker()
        result = bind(tracker, context(), qte, fixture.challenge())
        self.assertIs(result.status, QteBindingStatus.INVALID_TIMING)
        self.assertIsNone(
            classify_qte_timing(
                element_type="ATTACK_LEGEND_",
                correct_count=7,
                elapsed_seconds=2.8,
                perfect_start_seconds=3.0,
                perfect_end_seconds=2.0,
                good_start_1_seconds=1.0,
                good_end_1_seconds=2.0,
                good_start_2_seconds=3.0,
                good_end_2_seconds=4.0,
            )
        )

    def test_current_index_outside_sequence_is_rejected(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        result = bind(tracker, context(), fixture.read_qte(index=4), fixture.challenge())
        self.assertIs(result.status, QteBindingStatus.INVALID_PROGRESS)

    def test_completed_current_qte_is_explicit(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        result = bind(
            tracker,
            context(),
            fixture.read_qte(finished=True, index=3, correct=7),
            fixture.challenge(),
        )
        self.assertIs(result.status, QteBindingStatus.COMPLETED_CURRENT)
        self.assertEqual(result.predicted_timing_result, "PERFECT!")

    def test_displayed_timing_result_is_read_from_unity_text(self) -> None:
        fixture = Fixture()
        qte = fixture.read_qte(displayed_timing="  Bad! ")
        self.assertEqual(qte.displayed_timing_text, "  Bad! ")
        self.assertEqual(qte.displayed_timing_result, "BAD")
        self.assertEqual(normalize_displayed_timing_result("Perfect!"), "PERFECT!")
        self.assertIsNone(normalize_displayed_timing_result("waiting"))

    def test_production_live_card_requires_and_reads_button(self) -> None:
        fixture = Fixture()
        fixture.map_pet()
        address = fixture.map_qte(with_button=True)
        qte = read_card_ui_qte(
            fixture.memory,
            address,
            expected_class=fixture.QTE_CLASS,
            expected_board=fixture.BOARD,
            expected_active=fixture.ACTIVE,
            expected_card_data=fixture.CARD,
            require_button=True,
        )
        self.assertTrue(qte.button_validated)
        self.assertTrue(qte.button_interactable)
        self.assertEqual(qte.button_address, fixture.BUTTON)

        fixture_without_button = Fixture()
        fixture_without_button.map_pet()
        address = fixture_without_button.map_qte()
        with self.assertRaises(LayoutValidationError):
            read_card_ui_qte(
                fixture_without_button.memory,
                address,
                expected_class=fixture_without_button.QTE_CLASS,
                expected_board=fixture_without_button.BOARD,
                expected_active=fixture_without_button.ACTIVE,
                expected_card_data=fixture_without_button.CARD,
                require_button=True,
            )

    def test_qte_clock_drift_during_read_is_coherent(self) -> None:
        fixture = Fixture()
        fixture.map_qte()
        memory = MutatingQteMemory(
            fixture.QTE,
            CARD_UI_CURRENT_TIME_VALUE_OFFSET,
            struct.pack("<f", 0.40),
        )
        memory.bytes.update(fixture.memory.bytes)
        snapshot = read_card_ui_qte(
            memory,
            fixture.QTE,
            expected_class=fixture.QTE_CLASS,
            expected_board=fixture.BOARD,
            expected_active=fixture.ACTIVE,
            expected_card_data=fixture.CARD,
        )
        self.assertAlmostEqual(snapshot.current_time_value, 0.44)

    def test_qte_progress_change_during_read_is_rejected(self) -> None:
        fixture = Fixture()
        fixture.map_qte(index=1, correct=1)
        memory = MutatingQteMemory(
            fixture.QTE,
            CARD_UI_CURRENT_INDEX_OFFSET,
            struct.pack("<ii", 2, 2),
        )
        memory.bytes.update(fixture.memory.bytes)
        with self.assertRaisesRegex(LayoutValidationError, "changed during read"):
            read_card_ui_qte(
                memory,
                fixture.QTE,
                expected_class=fixture.QTE_CLASS,
                expected_board=fixture.BOARD,
                expected_active=fixture.ACTIVE,
                expected_card_data=fixture.CARD,
            )

    def test_proven_inactive_edge_starts_a_fresh_reused_card_ui_generation(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        qte = fixture.read_qte()
        tracker = QteSessionTracker()
        first = bind(tracker, context(), qte, fixture.challenge())
        tracker.note_inactive(context().session_key)
        second = tracker.observe(
            context(), (qte,), fixture.challenge(), element_type="ATTACK_LEGEND_"
        )
        self.assertTrue(second.current)
        self.assertEqual(
            second.identity.observer_generation,
            first.identity.observer_generation + 1,
        )

    def test_generic_response_envelope_needs_current_session_and_bounded_time(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        observation = bind(
            QteSessionTracker(),
            context(),
            fixture.read_qte(finished=True, index=3, correct=7),
            fixture.challenge(),
        )
        current = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=None,
            reject_reason=None,
            payload_bools=(),
            server_timestamp_epoch=100.5,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        stale = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=None,
            reject_reason=None,
            payload_bools=(),
            server_timestamp_epoch=70.0,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        rejected = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=321,
            reject_reason="denied",
            payload_bools=(),
            server_timestamp_epoch=None,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        stale_reject = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=None,
            reject_reason="old denial",
            payload_bools=(),
            server_timestamp_epoch=70.0,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        wrong_skill_reject = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=999,
            reject_reason="denied",
            payload_bools=(),
            server_timestamp_epoch=100.5,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        exact_challenge = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=None,
            qte_challenge_id=7001,
            reject_reason=None,
            payload_bools=(),
            server_timestamp_epoch=None,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        wrong_challenge = correlate_qte_response_envelope(
            observation,
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            skill_card_id=321,
            qte_challenge_id=9999,
            reject_reason=None,
            payload_bools=(),
            server_timestamp_epoch=100.5,
            completion_epoch=100.0,
            observed_epoch=101.0,
        )
        self.assertTrue(current.current)
        self.assertEqual(current.provenance, "CURRENT_ENVELOPE_TEMPORAL_SESSION")
        self.assertFalse(stale.current)
        self.assertEqual(rejected.provenance, "EXPLICIT_REJECT")
        self.assertEqual(stale_reject.provenance, "NONE")
        self.assertEqual(wrong_skill_reject.provenance, "NONE")
        self.assertTrue(exact_challenge.current)
        self.assertEqual(exact_challenge.provenance, "EXACT_QTE_CHALLENGE_ID")
        self.assertFalse(wrong_challenge.current)

    def test_old_active_challenge_after_new_match_needs_new_inactive_edge(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        tracker = QteSessionTracker()
        qte = fixture.read_qte()
        self.assertTrue(bind(tracker, context("M_A", 1), qte, fixture.challenge("M_A")).current)
        result = tracker.observe(
            context("M_B", 2),
            (qte,),
            fixture.challenge("M_A"),
            element_type="ATTACK_LEGEND_",
        )
        self.assertIs(result.status, QteBindingStatus.UNBOUND_MIDSTREAM)

    def test_result_requires_exact_session_card_progress_and_presses(self) -> None:
        fixture = Fixture()
        fixture.map_server()
        qte = fixture.read_qte(finished=True, index=3, correct=7)
        observation = bind(QteSessionTracker(), context(), qte, fixture.challenge())
        fixture.string_list(fixture.QTE_LIST, fixture.QTE_ITEMS, ("nutUp",))
        raw = bytearray(CHAT_MESSAGE_QTE_RESULT_READ_SIZE)
        struct.pack_into("<Q", raw, 0, fixture.RESULT_CLASS)
        struct.pack_into("<Q", raw, CHAT_MESSAGE_TYPE_OFFSET, fixture.string("MATCH_SKILL_USE_RES"))
        struct.pack_into("<Q", raw, CHAT_MESSAGE_MATCH_ID_OFFSET, fixture.string("M_A"))
        for offset in (
            CHAT_MESSAGE_SKILL_CARD_ID_OFFSET,
            CHAT_MESSAGE_CORRECT_DOT_COUNT_OFFSET,
            CHAT_MESSAGE_DOTS_TO_DESTROY_OFFSET,
            CHAT_MESSAGE_QTE_ELAPSED_MS_OFFSET,
            CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET,
        ):
            raw[offset] = 1
        struct.pack_into("<i", raw, CHAT_MESSAGE_SKILL_CARD_ID_OFFSET + 4, 321)
        struct.pack_into("<i", raw, CHAT_MESSAGE_CORRECT_DOT_COUNT_OFFSET + 4, 7)
        struct.pack_into("<Q", raw, CHAT_MESSAGE_TIMING_RESULT_OFFSET, fixture.string("PERFECT!"))
        struct.pack_into("<i", raw, CHAT_MESSAGE_DOTS_TO_DESTROY_OFFSET + 4, 12)
        struct.pack_into("<Q", raw, CHAT_MESSAGE_QTE_PRESSES_OFFSET, fixture.QTE_LIST)
        struct.pack_into("<i", raw, CHAT_MESSAGE_QTE_ELAPSED_MS_OFFSET + 4, qte.qte_elapsed_ms)
        struct.pack_into(
            "<q", raw, CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET + 8, 7001
        )
        fixture.memory.map(fixture.RESULT, raw)
        result = read_qte_result_message(
            fixture.memory,
            fixture.RESULT,
            expected_class=fixture.RESULT_CLASS,
            expected_match_id="M_A",
        )
        self.assertTrue(correlate_qte_result(observation, result))
        self.assertEqual(result.dots_to_destroy, 12)

    def test_probe_contains_zero_input_authority(self) -> None:
        source = (PROJECT_ROOT / "tools" / "pet_qte_observer.py").read_text(
            encoding="utf-8"
        )
        forbidden = ("win32_input", "SendInput", "mouse_event", "keybd_event")
        self.assertFalse(any(value in source for value in forbidden))

    def test_probe_contains_no_process_memory_write_path(self) -> None:
        source = (PROJECT_ROOT / "tools" / "pet_qte_observer.py").read_text(
            encoding="utf-8"
        )
        model = (
            PROJECT_ROOT / "src" / "pokiguard_v2" / "pet_qte_observer.py"
        ).read_text(encoding="utf-8")
        forbidden = ("WriteProcessMemory", "target.memory.write", "VirtualProtectEx")
        self.assertFalse(any(value in source or value in model for value in forbidden))

    def test_static_timing_boundaries_match_attack_legend_variant(self) -> None:
        common = dict(
            element_type="ATTACK_LEGEND_",
            correct_count=7,
            perfect_start_seconds=2.5,
            perfect_end_seconds=3.0,
            good_start_1_seconds=2.0,
            good_end_1_seconds=2.5,
            good_start_2_seconds=3.0,
            good_end_2_seconds=3.5,
        )
        self.assertEqual(classify_qte_timing(elapsed_seconds=2.5, **common), "PERFECT!")
        self.assertEqual(classify_qte_timing(elapsed_seconds=3.0, **common), "PERFECT!")
        self.assertEqual(classify_qte_timing(elapsed_seconds=4.0, **common), "GOOD!")
        self.assertEqual(
            classify_qte_timing(elapsed_seconds=2.8, **{**common, "correct_count": 6}),
            "BAD",
        )


if __name__ == "__main__":
    unittest.main()
