"""Post-response evidence must not be mistaken for a clean known-sword coefficient."""
from copy import deepcopy
import unittest
from tools.review_damage_mechanisms import ratio_support

def support(*,known=3,reported=7,crit='ABSENT',status='RECORDED_COMPONENT',multiple=True):
    descriptor=dict(known_prefix=dict(effective=dict(sword=known)))
    target=dict(status=status,amount=267393,full_power_states=['WIRE_TRUE'])
    diagnostic=dict(post_response_tags=None if reported is None else dict(sword=reported),multiple_destroy_operations_observed=multiple)
    operations=[] if crit=='ABSENT' else [dict(operation_index=35,type='BOSS_HP',crit_presence='BOOL',crit_value=crit)]
    context=dict(status='CAPTURED',operations=operations)
    inputs=deepcopy((descriptor,target,diagnostic,context));r=ratio_support(descriptor,target,diagnostic,context)
    assert inputs==(descriptor,target,diagnostic,context)
    return r

class DamageRatioSupportTests(unittest.TestCase):
    def test_three_known_swords_and_seven_reported_are_not_a_clean_coefficient(self):
        r=support()
        self.assertEqual(89131,r['descriptive_component_per_known_sword'])
        self.assertIn('POST_SWORD_TAG_COUNT_DIFFERS_FROM_KNOWN_PREFIX',r['flags'])
        self.assertFalse(r['clean_per_sword_coefficient_established']);self.assertFalse(r['training_target_rewritten'])
        self.assertFalse(r['pre_input_feature']);self.assertFalse(r['input_authority'])

    def test_critical_operation_is_retained_without_assigning_a_damage_step(self):
        r=support(reported=3,crit=True,multiple=False)
        self.assertIn('CRITICAL_OPERATION_OBSERVED_NOT_STEP_ATTRIBUTED',r['flags'])
        self.assertEqual(True,r['boss_hp_crit_observations'][0]['value'])
        self.assertEqual('UNKNOWN',r['ratio_causal_attribution'])

    def test_absent_crit_never_becomes_false_or_full_power_inference(self):
        r=support(reported=3)
        self.assertIn('CRITICAL_STATE_UNKNOWN_FOR_ONE_OR_MORE_BOSS_HP_OPERATIONS',r['flags'])
        self.assertEqual([],r['boss_hp_crit_observations']);self.assertEqual(['WIRE_TRUE'],r['full_power_states'])
        self.assertFalse(r['clean_per_sword_coefficient_established'])

    def test_explicit_false_is_a_wire_observation_and_still_not_a_coefficient_certificate(self):
        r=support(reported=3,crit=False,multiple=False)
        self.assertEqual(False,r['boss_hp_crit_observations'][0]['value'])
        self.assertNotIn('CRITICAL_STATE_UNKNOWN_FOR_ONE_OR_MORE_BOSS_HP_OPERATIONS',r['flags'])
        self.assertFalse(r['clean_per_sword_coefficient_established'])

    def test_missing_censored_or_zero_prefix_does_not_create_zero_damage(self):
        for status in ('MISSING_TYPED_RESPONSE','CENSORED_TARGET','NO_EXACT_ACK','NO_RECORDED_COMPONENT'):
            r=support(status=status);self.assertIsNone(r['recorded_component']);self.assertIsNone(r['descriptive_component_per_known_sword'])
        r=support(known=0,reported=None)
        self.assertIsNone(r['descriptive_component_per_known_sword']);self.assertIn('POST_SWORD_TAG_COUNT_UNKNOWN',r['flags'])

if __name__=='__main__':unittest.main()
