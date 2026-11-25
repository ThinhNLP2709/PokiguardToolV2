"""U4a: boss knowledge is declaration-only; situation labels carry evidence or UNKNOWN."""
import unittest
from types import SimpleNamespace

from pokiguard_v2.boss_knowledge import knowledge_for
from pokiguard_v2.reasoning_situations import situations


def codes(labels, status=None):
    return {x['code'] for x in labels if status is None or x['status'] == status}


class BossKnowledgeTests(unittest.TestCase):
    def test_declared_island_tiers_only(self):
        self.assertEqual('SELF_PUMP_AND_SKILL', knowledge_for(dict(island='Đảo Cổ Đại')).tier)
        self.assertEqual('BEFORE_ANCIENT_ISLAND', knowledge_for(dict(island='Đảo Liên Minh')).tier)
        unknown = knowledge_for(dict(island='Thập nhị tinh', level=77, name='X', pet_id=5))
        self.assertEqual(('UNKNOWN', 'NO_DECLARATION_FOR_ISLAND'), (unknown.tier, unknown.tier_source))
        self.assertEqual('UNKNOWN', knowledge_for(None).tier)

    def test_no_invented_numbers(self):
        plain = knowledge_for(dict(island='Đảo Sấm Sét')).plain()
        self.assertEqual((None, None, None), (plain['damage_model'], plain['heal_threshold'], plain['skill_threshold']))
        self.assertEqual('OBSERVED_U2_20261124', plain['shield_blocks_drain_source'])


class SituationTests(unittest.TestCase):
    FACTS = dict(self=dict(hp=50, max_hp=100, mana=200, max_mana=200, rage=150, max_rage=250),
        opponent=dict(hp=20, max_hp=100, shield=3), resource_requirements=dict(mana=200, rage=150),
        evolution=dict(pending=True, mana_cost=150))

    def test_active_labels_have_evidence(self):
        labels = situations('mega_icarus_spam_skill', self.FACTS)
        self.assertTrue({'S07', 'S09', 'S10', 'S18', 'S20', 'S21', 'K6'} <= codes(labels, 'ACTIVE'))
        k6 = next(x for x in labels if x['code'] == 'K6')
        self.assertEqual(150, k6['evidence']['rage'])
        self.assertTrue(all(x['reason_vi'] for x in labels))

    def test_model_dependent_situations_stay_unknown(self):
        labels = situations('simple', {})
        self.assertTrue({'S01', 'S02', 'S05', 'S06', 'S07', 'S20'} <= codes(labels, 'UNKNOWN'))
        self.assertNotIn('K6', codes(labels))

    def test_all_moves_leave_sword(self):
        move = lambda left: SimpleNamespace(sword_risk=SimpleNamespace(opponent_sword_reply_effective_max=left))
        self.assertIn('S12', codes(situations('simple', {}, [move(3), move(1)]), 'ACTIVE'))
        self.assertIn('S12', codes(situations('simple', {}, [move(3), move(0)]), 'INACTIVE'))

    def test_demon_has_no_rage_lock(self):
        facts = dict(self=dict(rage=200, max_rage=250))
        self.assertNotIn('K6', codes(situations('demon_aegis_farm', facts)))


if __name__ == '__main__':
    unittest.main()
