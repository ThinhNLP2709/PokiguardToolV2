from copy import deepcopy
import unittest
from pokiguard_v2.damage_uncertainty import assess,compare_references
from pokiguard_v2.damage_evaluation import digest,prediction_request
from tests.test_damage_conditional import synthetic

class DamageUncertaintyTests(unittest.TestCase):
    def setUp(self):self.sample=deepcopy(synthetic()['samples'][6])
    def request(self):
        self.sample['feature_sha256']=digest(self.sample['features']);return prediction_request(self.sample)
    def forecast(self,request,lower=100,point=200,upper=300):
        return dict(sample_id=request['sample_id'],feature_sha256=request['feature_sha256'],lower=lower,point=point,upper=upper,abstention_reason=None)

    def test_empirical_min_above_hp_never_certifies_kill_or_causes_stop(self):
        self.sample['features']['boss_stats']['hp']=50;r=self.request();a=assess(r,self.forecast(r))
        self.assertIn('REACHES_HP',a['hp_relation']);self.assertFalse(a['kill_certified']);self.assertFalse(a['stop_requested'])
        self.assertIsNone(a['certified_damage_lower']);self.assertIsNone(a['crit_probability'])
        self.assertEqual('EXISTING_ADVISER',a['runtime_fallback'])

    def test_component_upper_below_hp_is_not_proof_unknown_continuation_cannot_kill(self):
        self.sample['features']['boss_stats']['hp']=10000;r=self.request();a=assess(r,self.forecast(r))
        self.assertIn('FURTHER_EFFECTS_UNKNOWN',a['hp_relation'])
        self.assertIn('REFILL_AND_FURTHER_EFFECTS_UNOBSERVED',a['uncertainties'])

    def test_pre_shield_is_disclosed_without_subtracting_entire_shield_from_reference(self):
        self.sample['features']['boss_stats']['shield']=999;r=self.request();forecast=self.forecast(r);a=assess(r,forecast)
        self.assertEqual(forecast,a['reference']);self.assertIn('SHIELD_ABSORPTION_AND_EFFECT_ORDER_UNKNOWN',a['uncertainties'])
        self.assertFalse(a['net_resource_prediction'])

    def test_missing_forecast_and_abstention_preserve_tactical_fallback(self):
        r=self.request();a=assess(r)
        self.assertEqual('UNESTIMATED',a['status']);self.assertFalse(a['stop_requested'])
        value=self.forecast(r,lower=None,point=None,upper=None);value['abstention_reason']='OUTSIDE_DOMAIN'
        b=assess(r,value);self.assertEqual('ABSTAINED',b['status']);self.assertFalse(b['stop_requested'])

    def test_separated_empirical_ranges_are_not_a_certain_better_action(self):
        r=self.request();a=compare_references(r,r,self.forecast(r,400,500,600),self.forecast(r))
        self.assertEqual('FIRST_ABOVE',a['empirical_range_separation']);self.assertEqual('FIRST',a['empirical_point_preference'])
        self.assertIsNone(a['certain_better_action']);self.assertFalse(a['input_authority'])

    def test_different_board_context_and_forecast_identity_are_rejected(self):
        r=self.request();other=deepcopy(r);other['features']['boss_stats']['hp']+=1;other['feature_sha256']=digest(other['features'])
        with self.assertRaisesRegex(ValueError,'SAME_BOARD'):compare_references(r,other)
        bad=self.forecast(r);bad['feature_sha256']='0'*64
        with self.assertRaisesRegex(ValueError,'FORECAST_PRE_INPUT_IDENTITY'):assess(r,bad)

    def test_poison_future_fields_do_not_change_assessment(self):
        r=self.request();before=deepcopy(r);a=assess(r,self.forecast(r))
        self.sample['target_observation']['amount']=999999999;self.sample['post_crit']=True;self.sample['response_context']={'shield':999}
        self.assertEqual(a,assess(self.request(),self.forecast(r)));self.assertEqual(before,r)
        bad=deepcopy(r);bad['post_crit']=True
        with self.assertRaises(ValueError):assess(bad)

    def test_malformed_intervals_cannot_be_used_as_confidence(self):
        r=self.request()
        for args in ((300,200,100),(0,True,300),(0,float('inf'),300)):
            with self.subTest(args=args),self.assertRaises(ValueError):assess(r,self.forecast(r,*args))

if __name__=='__main__':unittest.main()
