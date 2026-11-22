"""Synthetic scalar relation and fold isolation; no native/game execution."""
from copy import deepcopy
import hashlib,json
from pathlib import Path
import tempfile
import unittest

from tests.reasoning_test_paths import reasoning_temp_root
from tests import test_damage_dataset as dataset_fixture
from tests.test_damage_dataset import rows
from pokiguard_v2.damage_evaluation import (digest,dataset_identity,prediction_request,numeric_stratum)
from pokiguard_v2.damage_baseline import POLICY,fit_exploratory,predict,validate_model
from tools.run_damage_baseline import run


def synthetic():
    """Controlled y=100*effective swords, all sources explicitly synthetic."""
    base=dataset_fixture.DatasetTests().run_rows(rows())
    template=base['samples'][0];samples=[]
    for i,(match,swords,power) in enumerate([('TRAIN',2,10),('TRAIN',3,20),('TRAIN',4,30),
            ('VALIDATION',3,20),('VALIDATION',5,20),('VALIDATION',3,50)]):
        s=deepcopy(template);s.update(sample_id=digest('synthetic-'+str(i)),match_id=match,group_id=digest(match))
        f=s['features'];f['board'][0][0][1]=i+1;f['self_stats']['power']=power
        f['first_wave'].update(passive_triggered=True,
            physical={g:swords if g=='sword' else 0 for g in f['first_wave']['physical']},
            effective={g:swords if g=='sword' else 0 for g in f['first_wave']['effective']})
        s['feature_sha256']=digest(f);s['target_observation']['amount']=100*swords
        samples.append(s)
    base['samples']=samples;base['summary'].update(actions=6,matches=2)
    base['dataset_sha256']=dataset_identity(base)
    return base


def plan(d):return dict(dataset_sha256=d['dataset_sha256'],matches={'TRAIN':'TRAIN','VALIDATION':'VALIDATION'},independent_holdout=False)
def fit(d):return fit_exploratory(d,plan(d),allow_uncalibrated_component_experiment=True)
def refresh(d):d['dataset_sha256']=dataset_identity(d);return d
def forecast(model,s,mode='guarded'):return predict(model,prediction_request(s),scope_id=numeric_stratum(s),mode=mode)


class BaselineTests(unittest.TestCase):
    def test_explicit_experiment_keeps_original_ineligible_flags_and_source_immutable(self):
        d=synthetic();before=deepcopy(d)
        with self.assertRaisesRegex(ValueError,'EXPLICIT_OFFLINE'):fit_exploratory(d,plan(d))
        m=fit(d);self.assertEqual(before,d);self.assertFalse(m['calibration_eligible']);self.assertFalse(m['deployment_eligible'])
        self.assertTrue(all(s['training_eligible'] is False for s in d['samples']))
        self.assertEqual(['TRAIN'],m['training_match_ids']);self.assertEqual(3,m['training_summary']['component_samples'])

    def test_known_synthetic_relation_and_empirical_interval(self):
        d=synthetic();m=fit(d);p,diag=forecast(m,d['samples'][3])
        self.assertEqual((300,300,300),(p['point'],p['lower'],p['upper']))
        self.assertIsNone(p['abstention_reason']);self.assertEqual([],diag['outside_training_domain'])
        self.assertIn('NOT_COVERAGE_GUARANTEE',diag['interval_semantics'])

    def test_validation_labels_and_wire_flags_do_not_change_parameters_or_forecasts(self):
        a=synthetic();b=deepcopy(a)
        for s in b['samples'][3:]:s['target_observation'].update(amount=999999,full_power_states=['FUTURE_POISON'])
        refresh(b);ma,mb=fit(a),fit(b)
        self.assertEqual(ma['parameters'],mb['parameters']);self.assertEqual(ma['training_payload_sha256'],mb['training_payload_sha256'])
        for sa,sb in zip(a['samples'][3:],b['samples'][3:],strict=True):
            self.assertEqual(forecast(ma,sa)[0],forecast(mb,sb)[0])
        self.assertNotEqual(ma['dataset_sha256'],mb['dataset_sha256'])

    def test_training_label_change_is_not_ignored(self):
        d=synthetic();a=fit(d);d['samples'][1]['target_observation']['amount']=900;refresh(d);b=fit(d)
        self.assertNotEqual(a['training_payload_sha256'],b['training_payload_sha256'])
        self.assertNotEqual(a['parameters'],b['parameters'])

    def test_guard_rejects_sword_and_power_extrapolation_reference_marks_them(self):
        d=synthetic();m=fit(d)
        for index,field,value in ((4,'effective_swords',500),(5,'pre_power',300)):
            p,diag=forecast(m,d['samples'][index]);self.assertIsNone(p['point'])
            self.assertEqual('OUTSIDE_TRAINING_DOMAIN',p['abstention_reason']);self.assertIn(field,diag['outside_training_domain'])
            ref,rd=forecast(m,d['samples'][index],'reference');self.assertEqual(value,ref['point']);self.assertIn(field,rd['outside_training_domain'])
            self.assertFalse(rd['domain_guard_applied']);self.assertFalse(rd['deployment_eligible'])

    def test_shield_outside_support_and_unknown_scope_abstain(self):
        d=synthetic();m=fit(d);s=deepcopy(d['samples'][3]);s['features']['boss_stats']['shield']=1;s['feature_sha256']=digest(s['features'])
        p,diag=forecast(m,s);self.assertEqual('OUTSIDE_TRAINING_DOMAIN',p['abstention_reason']);self.assertIn('boss_shield',diag['outside_training_domain'])
        s=deepcopy(d['samples'][3]);s['scope']['game_build_sha256']='f'*64
        p,_=forecast(m,s);self.assertEqual('UNSEEN_SCOPE_OR_REGIME',p['abstention_reason'])

    def test_never_pool_direct_and_passive_and_no_target_is_hardcoded(self):
        d=synthetic();m=fit(d);s=deepcopy(d['samples'][3]);s['features']['first_wave']['passive_triggered']=False;s['feature_sha256']=digest(s['features'])
        self.assertEqual('UNSEEN_SCOPE_OR_REGIME',forecast(m,s)[0]['abstention_reason'])
        for target in ('shield','health','mana','drain','rage'):
            d=synthetic()
            for s in d['samples']:s['features']['settings']['demon_target_gem']=target;s['feature_sha256']=digest(s['features'])
            refresh(d);self.assertEqual(300,forecast(fit(d),d['samples'][3])[0]['point'])

    def test_no_known_sword_is_not_predicted_as_zero_and_x7_is_bounded(self):
        d=synthetic();m=fit(d);s=deepcopy(d['samples'][3])
        s['features']['first_wave']['physical']['sword']=0;s['features']['first_wave']['effective']['sword']=0;s['feature_sha256']=digest(s['features'])
        p,_=forecast(m,s);self.assertEqual('NO_KNOWN_FIRST_WAVE_SWORDS',p['abstention_reason']);self.assertIsNone(p['point'])
        s=deepcopy(d['samples'][3]);s['features']['first_wave']['effective']['sword']=21;s['feature_sha256']=digest(s['features'])
        self.assertEqual('OUTSIDE_TRAINING_DOMAIN',forecast(m,s)[0]['abstention_reason']);self.assertEqual(2100,forecast(m,s,'reference')[0]['point'])

    def test_missing_censored_unacknowledged_targets_never_fit_as_zero(self):
        for status in ('MISSING_TYPED_RESPONSE','NO_RECORDED_COMPONENT','CENSORED_TARGET'):
            d=synthetic();d['samples'][0]['target_observation']['status']=status;refresh(d);m=fit(d)
            self.assertEqual(2,m['training_summary']['component_samples'])
            self.assertEqual('INSUFFICIENT_TRAINING_COMPONENTS',forecast(m,d['samples'][3])[0]['abstention_reason'])
        d=synthetic();d['samples'][0]['execution_status']='UNACKNOWLEDGED';refresh(d)
        self.assertEqual(2,fit(d)['training_summary']['component_samples'])

    def test_incomplete_features_and_in_sample_request_do_not_predict(self):
        d=synthetic();m=fit(d)
        self.assertEqual('IN_SAMPLE_REQUEST_NOT_VALIDATION',forecast(m,d['samples'][0])[0]['abstention_reason'])
        s=deepcopy(d['samples'][3]);s['features']['self_stats']=None;s['feature_sha256']=digest(s['features'])
        self.assertEqual('INCOMPLETE_PRE_INPUT',forecast(m,s)[0]['abstention_reason'])

    def test_no_uncontrolled_policy_or_authority_flags_on_model_or_request(self):
        d=synthetic();m=fit(d)
        for mutate in (lambda v:v['parameters'][0].update(ratio_median=999),lambda v:v.update(input_authority=True),
                lambda v:v['policy'].update(minimum_group_samples=1)):
            bad=deepcopy(m);mutate(bad)
            with self.assertRaises(ValueError):validate_model(bad)
        bad=deepcopy(m);bad['parameters'][0]['domain']['pre_power'].update(low=100,high=0)
        bad['model_sha256']=digest({k:v for k,v in bad.items() if k!='model_sha256'})
        with self.assertRaisesRegex(ValueError,'SUPPORT'):validate_model(bad)
        req=prediction_request(d['samples'][3]);req['target_observation']={'amount':300}
        with self.assertRaisesRegex(ValueError,'REQUEST'):predict(m,req,scope_id=numeric_stratum(d['samples'][3]))

    def test_model_and_pre_input_request_json_roundtrip_and_hash_fences(self):
        d=synthetic();m=fit(d);p,_=forecast(m,d['samples'][3])
        restored=json.loads(json.dumps(m));self.assertEqual(p,forecast(restored,d['samples'][3])[0])
        req=prediction_request(d['samples'][3]);req['features']['self_stats']['power']=25
        with self.assertRaisesRegex(ValueError,'FEATURE_IDENTITY'):predict(m,req,scope_id=numeric_stratum(d['samples'][3]))
        req=prediction_request(d['samples'][3]);req['input_complete']=False
        with self.assertRaisesRegex(ValueError,'FEATURE_IDENTITY'):predict(m,req,scope_id=numeric_stratum(d['samples'][3]))

    def test_split_and_duplicate_fences_before_fitting(self):
        d=synthetic();p=plan(d);p['matches']['VALIDATION']='TRAIN'
        with self.assertRaisesRegex(ValueError,'SEPARATE_TRAIN'):fit_exploratory(d,p,allow_uncalibrated_component_experiment=True)
        d=synthetic();d['samples'][3]['features']['board']=deepcopy(d['samples'][0]['features']['board'])
        d['samples'][3]['feature_sha256']=digest(d['samples'][3]['features']);refresh(d)
        with self.assertRaisesRegex(ValueError,'BOARD_LEAKAGE'):fit(d)
        d=synthetic();d['samples'].append(deepcopy(d['samples'][0]));refresh(d)
        with self.assertRaisesRegex(ValueError,'DUPLICATE_DATASET'):fit(d)

    def test_runner_freezes_models_forecasts_and_two_fold_sources_without_overwrite(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            folder=Path(directory);d=synthetic();data=folder/'dataset.json';data.write_text(json.dumps(d),encoding='utf-8')
            p=dict(schema='pokiguard.damage_baseline_experiment.v1',dataset_path=str(data),dataset_file_sha256=hashlib.sha256(data.read_bytes()).hexdigest(),
                dataset_sha256=d['dataset_sha256'],policy=POLICY,data_already_examined=True,independent_holdout=False,hyperparameter_search=False,live_inputs=False,
                folds=[dict(id='F1',matches={'TRAIN':'TRAIN','VALIDATION':'VALIDATION'}),dict(id='F2',matches={'TRAIN':'VALIDATION','VALIDATION':'TRAIN'})])
            spec=folder/'plan.json';spec.write_text(json.dumps(p),encoding='utf-8');raw=data.read_bytes()
            result=run(spec,folder/'out');self.assertEqual(2,result['models_fitted']);self.assertEqual(raw,data.read_bytes())
            self.assertFalse(result['independent_holdout']);self.assertFalse(result['deployment_eligible'])
            for fold in ('F1','F2'):
                seal=json.loads((folder/'out'/fold/'guarded_before_scoring.json').read_bytes())
                model=json.loads((folder/'out'/fold/'model.json').read_bytes())
                self.assertFalse(set(seal['validation_match_ids'])&set(model['training_match_ids']))
                self.assertEqual(seal['prediction_file_sha256'],hashlib.sha256((folder/'out'/fold/'guarded_predictions.json').read_bytes()).hexdigest())
            with self.assertRaisesRegex(ValueError,'FRESH_OUTPUT'):run(spec,folder/'out')
            data.write_text(json.dumps(d)+'\n',encoding='utf-8')
            with self.assertRaisesRegex(ValueError,'FILE_PIN'):run(spec,folder/'out2')


if __name__=='__main__':unittest.main()
