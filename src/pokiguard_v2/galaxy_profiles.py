"""User-supplied Galaxy card effects, bound to verified live card types.

Descriptions were also captured from the B15 CardData in the user's logs.
These declarations do not establish server damage, RNG probabilities or active
buff timers. Current resource costs always come from the owned CardUI.
"""
from dataclasses import dataclass

from .pet_skill_shadow import current_click_only_card_type


@dataclass(frozen=True)
class GalaxyProfile:
    alias: str
    name: str
    element_type: str
    cycle_length: int | None


PROFILES = {
    "GALAXY_RICKY": GalaxyProfile("G1", "Galaxy Risky", "GALAXY_RICKY", 4),
    "GALAXY_2": GalaxyProfile("G2", "Galaxy Glank", "GALAXY_2", None),
    "GALAXY_DRAGON_KNIGHT": GalaxyProfile("G3", "Galaxy Dragon Knight", "GALAXY_DRAGON_KNIGHT", 3),
}

G1_OPTIONS = (
    dict(card="BLUE", mana_refund=500, rage_refund=0),
    dict(card="RED", mana_refund=0, rage_refund=200, lifesteal_fraction=.05),
    dict(card="YELLOW", mana_refund=0, rage_refund=0, stun_turns=1),
)
G3_STAGES = {
    1: dict(name="Long Thương Khắc Ấn", skill_damage_multiplier=170, mana_refund=250,
            rage_refund=0, starts_mark=True, anti_drain_turns=2),
    2: dict(name="Long Hống Hồi Âm", skill_damage_multiplier=125, mana_refund=0,
            rage_refund=150, echo_fraction=.30, mark_continues=True),
    3: dict(name="Thiên Hà Long Xung", skill_damage_multiplier=100, mana_refund=150,
            rage_refund=50, detonation_fraction=.42, ends_mark=True),
}


def current_profile(capability, session):
    return PROFILES.get(current_click_only_card_type(capability, session))
