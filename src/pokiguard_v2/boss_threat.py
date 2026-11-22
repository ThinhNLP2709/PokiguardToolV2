"""Shared boss knowledge and snapshot proxies, never a server skill simulator.

The operator confirms bosses from Ancient Island onwards can self-charge Mana/
Rage and cast skills. Native Raijin evidence also records a large boss HP gain.
The state does not identify an island, skill cost, cooldown or next cast. General
capabilities cannot become a per-boss certainty, damage proof or safe stop.
"""


def _fraction(current, capacity):
    if type(current) is int and current == 0 and type(capacity) is int and capacity == 0:
        return 0.
    if type(current) is int and current >= 0 and type(capacity) is int and capacity > 0:
        return min(1., current / capacity)
    return None


def assess_boss_threat(own, boss):
    """Dictionaries use hp/max_hp, mana/max_mana, rage/max_rage and shield.

    Fractions are storage references, not skill affordability. Empty storage
    cannot exclude an immediate self-charge/cast sequence.
    """
    hp = _fraction(own.get('hp'), own.get('max_hp'))
    mana = _fraction(boss.get('mana'), boss.get('max_mana'))
    rage = _fraction(boss.get('rage'), boss.get('max_rage'))
    # The existing common adviser uses 100 as a Rage comparison reference.
    # Keep storage fraction separate: neither reference reveals a skill cost.
    rage_capacity = boss.get('max_rage')
    rage_reference = _fraction(boss.get('rage'), min(rage_capacity, 100)
        if type(rage_capacity) is int and rage_capacity >= 0 else None)
    known = [v for v in (mana, rage_reference) if v is not None]
    stockpile = max(known) if known else None
    deficit = 1-hp if hp is not None else 1.
    # Heuristic buffers, not probabilities, damage bounds or user HP settings.
    buffer = max(deficit, .5*stockpile if stockpile is not None else 0.)
    alert = hp is not None and (hp <= .30 or
        (hp <= .80 and stockpile is not None and stockpile >= .80))
    return dict(knowledge_version='boss_threat.v1',
        capability_support='USER_CONFIRMED_ADVANCED_ISLAND_BOSSES_20261123',
        capability_scope='FROM_ANCIENT_ISLAND_ONWARD_AFTER_ALLIANCE_II',
        current_boss_scope='UNKNOWN_NO_ISLAND_OR_SKILL_ID_IN_SNAPSHOT',
        self_charge_mana_possible=True, self_charge_rage_possible=True,
        skill_cast_possible=True, boss_heal_possible=True,
        boss_heal_support='RAIJIN_NATIVE_HP_GAIN_NOT_A_GENERAL_HEAL_FORMULA',
        snapshot_mana_fraction=mana, snapshot_rage_fraction=rage,
        rage_reference_fraction=rage_reference, rage_comparison_reference=100,
        stored_resource_pressure=stockpile,
        missing_resources=[name for name, value in (('mana', mana), ('rage', rage)) if value is None],
        shield_buffer_pressure=buffer, protection_requested=alert,
        pressure_kind='SNAPSHOT_HEURISTIC_NOT_SKILL_READINESS',
        skill_ready=None, skill_cost=None, skill_cooldown=None,
        self_charge_amount=None, heal_trigger=None, heal_recurrence=None,
        next_skill_damage=None, low_resources_exclude_skill=False,
        no_known_sword_certifies_safety=False, drain_prevents_skill_certified=False,
        low_boss_hp_certifies_kill=False, survival_certified=False,
        stop_for_unknown_skill=False)


def state_boss_threat(state):
    """Adapter over already published read-only participant fields only."""
    def actor(value):
        return {name: getattr(value, source, None) for name, source in (
            ('hp', 'hp'), ('max_hp', 'max_hp'), ('mana', 'mana'),
            ('max_mana', 'max_mana'), ('rage', 'power'), ('max_rage', 'max_power'),
            ('shield', 'shield'))}
    boss = next((a for a in state.opponents if a.is_boss), None)
    return assess_boss_threat(actor(state.player), actor(boss))
