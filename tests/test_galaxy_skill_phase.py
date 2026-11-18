"""Read-only phase decoding and exact match/card/actor ownership."""
from dataclasses import replace
import struct
from types import SimpleNamespace
import unittest
from unittest.mock import Mock

from pokiguard_v2.galaxy_skill_phase import read_local_skill_phase, SkillPhaseObservation
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.memory_board_provider import MemoryBoardStateProvider
from pokiguard_v2.pet_skill_shadow import PetSkillCapabilityProvider
from tests.test_galaxy_pet_reasoning import cap, state
from tests.test_player_stats import BASE, FakeMemory, install_match_players
from tools.basic_auto_bot import _current_pet_skill_capability


SERVICE = BASE + 0xB000
SNAPSHOT = BASE + 0xF000


def memory_phase(*, phase=2, maximum=3, card=3347):
    memory = FakeMemory()
    install_match_players(memory, SERVICE, (("local-user", 1),))
    klass = BASE + 0x3000
    memory.map(klass, bytes(8))
    raw = bytearray(0x184)
    struct.pack_into("<Q", raw, 0, klass)
    struct.pack_into("<i", raw, 0x18, 1)
    struct.pack_into("<i", raw, 0x15C, phase)
    struct.pack_into("<ii", raw, 0x17C, maximum, card)
    memory.map(SNAPSHOT, raw)
    return memory


def read(memory, *, card=3347, actor=1, username="local-user"):
    return read_local_skill_phase(memory, SERVICE, username, local_actor=actor, card_id=card)


class PhaseDecoderTests(unittest.TestCase):
    def test_reads_exact_current_card_phase_instead_of_display_clamping(self):
        for phase in (1, 2, 3):
            with self.subTest(phase=phase):
                result = read(memory_phase(phase=phase))
                self.assertEqual((result.card_id, result.next_phase, result.maximum), (3347, phase, 3))
        fourth = read(memory_phase(phase=4, maximum=4, card=24), card=24)
        self.assertEqual((fourth.next_phase, fourth.maximum), (4, 4))

    def test_wrong_card_and_unpublished_phase_stay_unknown(self):
        self.assertIsNone(read(memory_phase(card=24)))
        self.assertIsNone(read(memory_phase(maximum=0)))
        self.assertIsNone(read(memory_phase(), username="other-user"))

    def test_invalid_phase_ranges_fail_closed(self):
        for phase, maximum in ((0, 3), (4, 3), (-1, 3), (1, 1), (1, 10), (1, -1)):
            with self.subTest(phase=phase, maximum=maximum), self.assertRaises(LayoutValidationError):
                read(memory_phase(phase=phase, maximum=maximum))

    def test_other_actor_and_duplicate_local_user_cannot_supply_a_phase(self):
        with self.assertRaisesRegex(LayoutValidationError, "actor mismatch"):
            read(memory_phase(), actor=2)
        memory = memory_phase()
        install_match_players(memory, SERVICE, (("local-user", 1), ("LOCAL-USER", 2)))
        with self.assertRaisesRegex(LayoutValidationError, "ambiguous"):
            read(memory)

    def test_changed_phase_and_replaced_dictionary_root_are_rejected(self):
        memory = memory_phase()
        original = memory.read
        calls = 0
        def changing(address, size):
            nonlocal calls
            raw = original(address, size)
            if address == SNAPSHOT and size == 0x184:
                calls += 1
                if calls == 2:
                    raw = bytearray(raw)
                    struct.pack_into("<i", raw, 0x15C, 3)
                    return bytes(raw)
            return raw
        memory.read = changing
        with self.assertRaisesRegex(LayoutValidationError, "changed"):
            read(memory)
        memory = memory_phase()
        original = memory.read
        calls = 0
        def replaced_root(address, size):
            nonlocal calls
            if address == SERVICE + 0x118:
                calls += 1
                if calls > 1:
                    return struct.pack("<Q", BASE + 0x8000)
            return original(address, size)
        memory.read = replaced_root
        with self.assertRaisesRegex(LayoutValidationError, "root changed"):
            read(memory)


class PhaseProviderTests(unittest.TestCase):
    def provider(self):
        s = state()
        p = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        p.target = SimpleNamespace(memory=memory_phase(), is_running=lambda: True)
        p._lifecycle_tracker = SimpleNamespace(session=s.battle.session_key)
        board = SimpleNamespace(accepted=True, board_instance=s.battle.session_key.board_instance, active=BASE)
        p._resolve_board = Mock(return_value=board)
        p._resolve_match_service = Mock(return_value=SERVICE)
        before = (s.battle.match_id, s.battle.turn_number, "local-user", None, None)
        p._read_match_state = Mock(return_value=before)
        return p, s

    def observe(self, p, s):
        return p.read_pet_skill_phase(s.battle.session_key, local_username="local-user",
            local_actor=1, card_id=3347, source_turn=s.battle.turn_number)

    def test_provider_binds_phase_to_both_reads_of_current_match_and_turn(self):
        p, s = self.provider()
        self.assertEqual(self.observe(p, s).next_phase, 2)
        self.assertEqual(p._pet_skill_phase_reason, "current_local_phase")
        p, s = self.provider()
        p._read_match_state.side_effect = [
            (s.battle.match_id, s.battle.turn_number, "local-user", None, None),
            (s.battle.match_id, s.battle.turn_number+1, "local-user", None, None)]
        self.assertIsNone(self.observe(p, s))
        self.assertIn("source changed", p._pet_skill_phase_reason)

    def test_unowned_session_never_reads_a_phase(self):
        p, s = self.provider()
        p._lifecycle_tracker.session = None
        self.assertIsNone(self.observe(p, s))
        p._resolve_board.assert_not_called()

    def test_controller_helper_attaches_phase_to_the_current_owned_capability(self):
        s = state(200, 200)
        c = cap()
        card = replace(s.cards[0], object_address=c.live_card_address, data_address=c.card_data_address,
            card_id=c.card_id, data_id=0, element_type=c.element_type, condition_use=200, power=200,
            mana_cost=0, power_cost=0, interactable=True, cooldown_turns=0,
            button_address=c.live_button_address, interaction_authority="CARD_UI_BUTTON")
        p = SimpleNamespace(refresh_pet_skill_cards=Mock(return_value=(card,)),
            read_pet_skill_phase=Mock(return_value=SkillPhaseObservation(c.card_id, 2, 3)))
        actual = _current_pet_skill_capability(p, s, PetSkillCapabilityProvider())
        self.assertEqual((actual.skill_phase_next, actual.skill_phase_max), (2, 3))
        self.assertTrue(actual.current)
        p.refresh_pet_skill_cards.assert_called_once_with(s.battle.session_key, require_fusion_success=False)
        p.read_pet_skill_phase.assert_called_once_with(s.battle.session_key,
            local_username=s.battle.local_username, local_actor=s.player.actor_number,
            card_id=c.card_id, source_turn=s.battle.turn_number)


if __name__ == "__main__":
    unittest.main()
