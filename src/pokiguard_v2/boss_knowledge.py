"""Shared boss knowledge: user declarations and observed evidence only, never invented numbers.

Each entry names its source. A boss or island that no declaration covers stays
UNKNOWN; the tier is never inferred from HP, level or name. Not a planner input
until a reviewed phase enables it.
"""
from dataclasses import dataclass

SCHEMA = 'pokiguard.boss_knowledge.v1'
UNKNOWN = 'UNKNOWN'

# docs/boss_skill_knowledge.md (user 23/11/2026): islands after Đảo Liên Minh II, from Đảo Cổ Đại on,
# have bosses that self-pump Mana/Nộ and use skills. Only islands the user placed are listed.
ISLAND_TIER = {
    'Đảo Cổ Đại': ('SELF_PUMP_AND_SKILL', 'USER_DECLARED_20261123'),
    'Đảo Liên Minh': ('BEFORE_ANCIENT_ISLAND', 'USER_DECLARED_20261123'),
    'Đảo Liên Minh II': ('BEFORE_ANCIENT_ISLAND', 'USER_DECLARED_20261123'),
    'Đảo Sấm Sét': ('SELF_PUMP_AND_SKILL', 'USER_SELECTED_AS_ANCIENT_OR_LATER_L0_20261125'),
}
# U2 observation (176 logs, DECISIONS D-U2): Drain took no resources while the boss kept Shield,
# unless the boss was hit earlier in the same move.
SHIELD_BLOCKS_DRAIN = ('UNLESS_BOSS_HIT_EARLIER_IN_SAME_MOVE', 'OBSERVED_U2_20261124')


@dataclass(frozen=True)
class BossKnowledge:
    pet_id: int | None
    name: str | None
    island: str | None
    level: int | None
    tier: str
    tier_source: str
    shield_blocks_drain: str
    shield_blocks_drain_source: str

    def plain(self):
        return dict(schema=SCHEMA, pet_id=self.pet_id, name=self.name, island=self.island, level=self.level,
            tier=self.tier, tier_source=self.tier_source, shield_blocks_drain=self.shield_blocks_drain,
            shield_blocks_drain_source=self.shield_blocks_drain_source, damage_model=None,
            heal_threshold=None, skill_threshold=None)


def knowledge_for(identity):
    """`identity` is the pinned run target (facts.boss_identity or the UI target)."""
    identity = identity if type(identity) is dict else {}
    island = identity.get('island') if type(identity.get('island')) is str else None
    tier, source = ISLAND_TIER.get(island, (UNKNOWN, 'NO_DECLARATION_FOR_ISLAND'))
    pet_id = identity.get('pet_id') if type(identity.get('pet_id')) is int else None
    level = identity.get('level') if type(identity.get('level')) is int else None
    name = identity.get('name') if type(identity.get('name')) is str else None
    return BossKnowledge(pet_id, name, island, level, tier, source, *SHIELD_BLOCKS_DRAIN)
