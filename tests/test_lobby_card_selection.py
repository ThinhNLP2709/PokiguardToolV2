from __future__ import annotations

from types import SimpleNamespace
import unittest

from pokiguard_v2.lobby_card_selection import (
    AttackSelectionStatus,
    attack_selection_satisfied_by_rehydration,
    plan_required_attack_selection,
)


def card(
    data_id: int,
    card_id: int,
    element_type: str,
    *,
    count: int = 1,
) -> SimpleNamespace:
    return SimpleNamespace(
        data_id=data_id,
        card_id=card_id,
        element_type=element_type,
        count=count,
    )


class LobbyAttackSelectionTests(unittest.TestCase):
    def test_unique_owned_room_attack_is_required_when_manager_is_empty(self) -> None:
        loadout = SimpleNamespace(
            manager_cards=(),
            room_cards=(
                card(64644, 1, "MANA", count=80),
                card(64645, 2, "POWER", count=25),
                card(64646, 3, "HEALTH", count=58),
                card(64647, 4, "ATTACK", count=1),
            ),
        )
        plan = plan_required_attack_selection(loadout)
        self.assertEqual(plan.status, AttackSelectionStatus.REQUIRED)
        self.assertEqual(plan.room_card_index, 3)
        self.assertEqual(plan.identity, (64647, 4, "ATTACK"))

    def test_manager_attack_is_authoritative_even_when_room_dto_disagrees(self) -> None:
        attack = card(64647, 4, "ATTACK")
        plan = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(attack,), room_cards=(attack,))
        )
        self.assertEqual(plan.status, AttackSelectionStatus.ALREADY_SELECTED)
        self.assertEqual(plan.identity, (64647, 4, "ATTACK"))
        self.assertEqual(plan.room_card_index, 0)

        no_room_telemetry = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(attack,), room_cards=())
        )
        self.assertEqual(
            no_room_telemetry.status,
            AttackSelectionStatus.ALREADY_SELECTED,
        )
        self.assertIsNone(no_room_telemetry.room_card_index)

    def test_missing_and_ambiguous_attack_never_choose_a_toggle(self) -> None:
        missing = plan_required_attack_selection(
            SimpleNamespace(
                manager_cards=(),
                room_cards=(card(1, 1, "MANA"), card(2, 2, "ATTACK", count=0)),
            )
        )
        self.assertEqual(missing.status, AttackSelectionStatus.NOT_AVAILABLE)
        ambiguous = plan_required_attack_selection(
            SimpleNamespace(
                manager_cards=(),
                room_cards=(card(2, 2, "ATTACK"), card(3, 3, "ATTACK")),
            )
        )
        self.assertEqual(ambiguous.status, AttackSelectionStatus.AMBIGUOUS)
        self.assertIsNone(ambiguous.room_card_index)

    def test_same_attack_rehydration_satisfies_required_selection(self) -> None:
        attack = card(64647, 4, "ATTACK")
        original = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(), room_cards=(attack,))
        )
        current = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(attack,), room_cards=(attack,))
        )
        self.assertTrue(
            attack_selection_satisfied_by_rehydration(original, current)
        )

    def test_rehydration_rejects_changed_identity_or_non_required_origin(self) -> None:
        attack = card(64647, 4, "ATTACK")
        changed = card(70000, 9, "ATTACK")
        required = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(), room_cards=(attack,))
        )
        changed_selected = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(changed,), room_cards=(attack, changed))
        )
        already_selected = plan_required_attack_selection(
            SimpleNamespace(manager_cards=(attack,), room_cards=(attack,))
        )
        self.assertFalse(
            attack_selection_satisfied_by_rehydration(required, changed_selected)
        )
        self.assertFalse(
            attack_selection_satisfied_by_rehydration(
                already_selected, already_selected
            )
        )


if __name__ == "__main__":
    unittest.main()
