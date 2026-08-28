"""Pure pre-entry rules for the minimum required Attack-card loadout.

``ManagerRoom.selectedCards`` is authoritative for the next combat.  A stale
``RoomDTO.cards`` list is inventory/comparison evidence only, but it provides
the exact ordered card identity used to build the room's Toggle row.  This
module decides whether one unambiguous normal Attack-card Toggle must be
selected; it never sends input.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
from typing import Any


ATTACK_ELEMENTS = frozenset({"ATTACK"})


class AttackSelectionStatus(str, Enum):
    ALREADY_SELECTED = "ALREADY_SELECTED"
    NOT_AVAILABLE = "NOT_AVAILABLE"
    REQUIRED = "REQUIRED"
    AMBIGUOUS = "AMBIGUOUS"


@dataclass(frozen=True)
class AttackSelectionPlan:
    status: AttackSelectionStatus
    room_card_index: int | None = None
    data_id: int | None = None
    card_id: int | None = None
    element_type: str | None = None
    reason: str = ""

    @property
    def identity(self) -> tuple[int, int, str] | None:
        if self.data_id is None or self.card_id is None or self.element_type is None:
            return None
        return self.data_id, self.card_id, self.element_type


def plan_required_attack_selection(loadout: Any) -> AttackSelectionPlan:
    """Return a fail-closed plan from both lobby-owned card sources."""

    selected = tuple(
        card
        for card in getattr(loadout, "manager_cards", ())
        if str(getattr(card, "element_type", "")).upper() in ATTACK_ELEMENTS
    )
    if selected:
        card = selected[0]
        selected_identity = (
            int(card.data_id),
            int(card.card_id),
            str(card.element_type).upper(),
        )
        matching_room_indexes = tuple(
            index
            for index, room_card in enumerate(
                getattr(loadout, "room_cards", ())
            )
            if (
                int(room_card.data_id),
                int(room_card.card_id),
                str(room_card.element_type).upper(),
            )
            == selected_identity
        )
        return AttackSelectionPlan(
            AttackSelectionStatus.ALREADY_SELECTED,
            room_card_index=(
                matching_room_indexes[0]
                if len(matching_room_indexes) == 1
                else None
            ),
            data_id=int(card.data_id),
            card_id=int(card.card_id),
            element_type=str(card.element_type).upper(),
            reason="ManagerRoom.selectedCards already contains Attack",
        )

    available = tuple(
        (index, card)
        for index, card in enumerate(getattr(loadout, "room_cards", ()))
        if str(getattr(card, "element_type", "")).upper() in ATTACK_ELEMENTS
        and int(getattr(card, "count", 0) or 0) > 0
    )
    if not available:
        return AttackSelectionPlan(
            AttackSelectionStatus.NOT_AVAILABLE,
            reason="RoomDTO.cards contains no owned Attack card",
        )
    if len(available) != 1:
        return AttackSelectionPlan(
            AttackSelectionStatus.AMBIGUOUS,
            reason=f"RoomDTO.cards contains {len(available)} owned Attack cards",
        )
    index, card = available[0]
    return AttackSelectionPlan(
        AttackSelectionStatus.REQUIRED,
        room_card_index=index,
        data_id=int(card.data_id),
        card_id=int(card.card_id),
        element_type=str(card.element_type).upper(),
        reason="unique owned Attack card is absent from ManagerRoom.selectedCards",
    )


def attack_selection_satisfied_by_rehydration(
    original: AttackSelectionPlan,
    current: AttackSelectionPlan,
) -> bool:
    """Accept only the same Attack becoming authoritative without our click.

    Unity/server room refresh may repopulate ``ManagerRoom.selectedCards``
    while the Toggle row is still animating.  That exact REQUIRED ->
    ALREADY_SELECTED transition is already the desired postcondition and must
    not be treated as a changed target.  Different identities and every other
    transition remain fail-closed.
    """

    return bool(
        original.status is AttackSelectionStatus.REQUIRED
        and current.status is AttackSelectionStatus.ALREADY_SELECTED
        and original.identity is not None
        and current.identity == original.identity
    )


__all__ = [
    "AttackSelectionPlan",
    "AttackSelectionStatus",
    "attack_selection_satisfied_by_rehydration",
    "plan_required_attack_selection",
]
