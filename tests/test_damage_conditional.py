"""Conditional learning, support and evaluation isolation, synthetic only."""
from copy import deepcopy
import hashlib
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.damage_conditional import POLICY, fit_exploratory, predict, validate_model
from pokiguard_v2.damage_evaluation import digest, dataset_identity, prediction_request, numeric_stratum, input_complete, TARGET
from tools.prepare_demon_damage_dataset import first_wave_features
from tools.run_conditional_damage import paired, run
from tools.run_damage_baseline import run as run_baseline
from pokiguard_v2.damage_baseline import POLICY as BASELINE_POLICY
from tests import test_damage_dataset as dataset_fixture
from tests.reasoning_test_paths import reasoning_temp_root


def refresh_request(r):
    f = r['features']; f['first_wave'] = first_wave_features(f['board'], f['move'], f['settings']['demon_target_gem'])
    r['feature_sha256'] = digest(f); r['input_complete'] = input_complete(f)
    return r


def synthetic(*, ordinary=False, tied=False):
    """One exact mechanism, low/high pre-Power rates; no server-formula claim."""
    data = dataset_fixture.DatasetTests().run_rows(dataset_fixture.rows())
    cases = json.loads((Path(__file__).parent/'fixtures/damage_action_context_20261121.json').read_bytes())['cases']
    template = next(c['request']['features'] for c in cases if c['name'] == ('M_ef4bd854:13' if ordinary else 'M_ef4bd854:1'))
    samples = []
    for i, power in enumerate((0,25,50,150,175,200,25,175)):
        s = deepcopy(data['samples'][0]); f = deepcopy(template)
        # Different pre-input boards without changing Sword/Rage/Drain geometry.
        cells = [c for row in f['board'] for c in row if c[0] in ('health','mana')]
        cells[0][1] = 1 + i % 7; cells[1][1] = 1 + i // 7
        f['self_stats']['power'] = 100 if tied else power
        f['first_wave'] = first_wave_features(f['board'], f['move'], f['settings']['demon_target_gem'])
        match = 'TRAIN' if i < 6 else 'VALIDATION'
        amount = 300 if i in (0,1,2,6) else 600
        s.update(sample_id=digest('conditional-synthetic-'+str(i)),match_id=match,group_id=digest(match),
            features=f,feature_sha256=digest(f),input_complete=True)
        s['target_observation'].update(amount=amount,damage_components=[dict(index=0,amount=amount,damage_source='SYNTHETIC')])
        samples.append(s)
    data.update(samples=samples);data['summary'].update(actions=8,matches=2)
    data['dataset_sha256'] = dataset_identity(data)
    return data


def plan(data):
    return dict(dataset_sha256=data['dataset_sha256'],matches={'TRAIN':'TRAIN','VALIDATION':'VALIDATION'},independent_holdout=False)


def fit(data): return fit_exploratory(data,plan(data),allow_uncalibrated_component_experiment=True)
def refresh(data): data['dataset_sha256']=dataset_identity(data);return data
def forecast(model,sample,mode='guarded'):
    return predict(model,prediction_request(sample),scope_id=numeric_stratum(sample),mode=mode)


class ConditionalTests(unittest.TestCase):
    def test_requires_explicit_experiment_and_keeps_original_ineligible_flags(self):
        d=synthetic();before=deepcopy(d)
        with self.assertRaisesRegex(ValueError,'EXPLICIT_OFFLINE'):fit_exploratory(d,plan(d))
        model=fit(d);self.assertEqual(before,d)
        for field in ('calibration_eligible','deployment_eligible','input_authority'):self.assertFalse(model[field])
        self.assertTrue(all(s['training_eligible'] is False for s in d['samples']))
        self.assertIsNone(model['policy']['full_power_threshold']);self.assertIsNone(model['policy']['rage_gain_per_gem'])

    def test_learns_different_rates_for_same_swords_from_pre_input_context(self):
        d=synthetic();model=fit(d)
        low,ld=forecast(model,d['samples'][6]);high,hd=forecast(model,d['samples'][7])
        self.assertEqual((300,600),(low['point'],high['point']))
        self.assertEqual((300,300),(low['lower'],low['upper']))
        self.assertEqual(3,ld['neighbors']);self.assertEqual(3,hd['neighbors'])
        self.assertFalse(ld['deployment_eligible']);self.assertIsNone(ld['full_power_prediction'])

    def test_zero_first_wave_swords_can_learn_known_ordinary_cascade_mechanism(self):
        d=synthetic(ordinary=True);model=fit(d)
        self.assertEqual(0,d['samples'][6]['features']['first_wave']['effective']['sword'])
        prediction,diagnostic=forecast(model,d['samples'][6])
        self.assertEqual(300,prediction['point']);self.assertEqual([0,0,1],diagnostic['signature'])

    def test_validation_labels_and_all_future_flags_do_not_change_parameters_or_predictions(self):
        a=synthetic();b=deepcopy(a)
        for s in b['samples']:
            s['target_observation']['full_power_states']=['FUTURE_FAKE']
            s.update(response_context={'attack':999},damage_operations={'crit':True})
            if s['match_id']=='VALIDATION':s['target_observation']['amount']=987654321
        refresh(b);ma,mb=fit(a),fit(b)
        self.assertEqual(ma['parameters'],mb['parameters']);self.assertEqual(ma['training_payload_sha256'],mb['training_payload_sha256'])
        for sa,sb in zip(a['samples'][6:],b['samples'][6:],strict=True):
            self.assertEqual(forecast(ma,sa)[0],forecast(mb,sb)[0])

    def test_training_damage_labels_actually_change_the_learned_model(self):
        a=synthetic();b=deepcopy(a)
        for s in b['samples'][:3]:s['target_observation']['amount']=100
        refresh(b);ma,mb=fit(a),fit(b)
        self.assertNotEqual(ma['training_payload_sha256'],mb['training_payload_sha256'])
        self.assertEqual(300,forecast(ma,a['samples'][6])[0]['point'])
        self.assertEqual(100,forecast(mb,b['samples'][6])[0]['point'])

    def test_joint_guard_rejects_unseen_gap_inside_individual_training_ranges(self):
        d=synthetic();model=fit(d);s=deepcopy(d['samples'][6]);s['features']['self_stats']['power']=100
        s['feature_sha256']=digest(s['features'])
        p,diag=forecast(model,s);self.assertEqual([],diag['outside_training_domain'])
        self.assertIsNone(p['point']);self.assertEqual('JOINT_CONTEXT_UNSUPPORTED',p['abstention_reason'])
        self.assertGreater(diag['nearest_distance'],diag['joint_radius'])
        ref,rd=forecast(model,s,'reference');self.assertIsNotNone(ref['point']);self.assertTrue(rd['joint_context_outside'])

    def test_constant_and_outside_context_are_not_silently_clipped_or_extrapolated(self):
        d=synthetic();model=fit(d);s=deepcopy(d['samples'][6]);s['features']['boss_stats']['shield']=1
        s['feature_sha256']=digest(s['features']);p,diag=forecast(model,s)
        self.assertEqual('OUTSIDE_TRAINING_CONTEXT',p['abstention_reason']);self.assertIn('boss_shield',diag['outside_training_domain'])
        ref,_=forecast(model,s,'reference');self.assertIsNotNone(ref['point'])

    def test_nearest_distance_ties_include_all_records_and_keep_empirical_range(self):
        d=synthetic(tied=True);model=fit(d);p,diag=forecast(model,d['samples'][6])
        self.assertEqual(6,diag['neighbors']);self.assertEqual((300,600),(p['lower'],p['upper']))
        self.assertGreaterEqual(p['point'],p['lower']);self.assertLessEqual(p['point'],p['upper'])
        self.assertFalse(diag['whole_action_complete'])

    def test_copies_of_one_training_board_cannot_satisfy_minimum_support(self):
        d=synthetic()
        for s in d['samples'][1:6]:
            s['features']['board']=deepcopy(d['samples'][0]['features']['board'])
            s['features']['first_wave']=deepcopy(d['samples'][0]['features']['first_wave'])
            s['feature_sha256']=digest(s['features'])
        refresh(d);model=fit(d)
        p,diag=forecast(model,d['samples'][7]);self.assertEqual(1,diag['unique_training_boards'])
        self.assertEqual('INSUFFICIENT_UNIQUE_TRAINING_BOARDS',p['abstention_reason'])

    def test_in_sample_action_and_training_board_are_never_validation(self):
        d=synthetic();model=fit(d)
        self.assertEqual('IN_SAMPLE_REQUEST_NOT_VALIDATION',forecast(model,d['samples'][0])[0]['abstention_reason'])
        s=deepcopy(d['samples'][6]);s['features']['board']=deepcopy(d['samples'][0]['features']['board'])
        r=refresh_request(prediction_request(dict(s,feature_sha256=digest(s['features']))))
        self.assertEqual('TRAINING_BOARD_NOT_VALIDATION',predict(model,r,scope_id=numeric_stratum(s))[0]['abstention_reason'])

    def test_never_pool_account_source_target_or_different_mechanisms(self):
        d=synthetic();model=fit(d)
        for key in ('account_sha256','source_sha256','game_build_sha256'):
            s=deepcopy(d['samples'][6]);s['scope'][key]='f'*64
            self.assertEqual('UNSEEN_SCOPE_OR_MECHANISM',forecast(model,s)[0]['abstention_reason'])
        other=synthetic(ordinary=True)['samples'][6]
        self.assertEqual('UNSEEN_SCOPE_OR_MECHANISM',forecast(model,other)[0]['abstention_reason'])

    def test_all_five_targets_use_the_same_learning_algorithm(self):
        for target in ('shield','health','mana','drain','rage'):
            d=synthetic()
            for s in d['samples']:
                f=s['features']
                for row in f['board']:
                    for cell in row:
                        if cell[0]=='shield':cell[0]=target
                        elif cell[0]==target:cell[0]='shield'
                f['settings']['demon_target_gem']=target
                f['first_wave']=first_wave_features(f['board'],f['move'],target);s['feature_sha256']=digest(f)
            refresh(d);model=fit(d)
            self.assertEqual((300,600),tuple(forecast(model,s)[0]['point'] for s in d['samples'][6:]))

    def test_missing_censored_unacknowledged_targets_never_become_zero_training_labels(self):
        d=synthetic()
        for i,s in enumerate(d['samples'][:6]):
            if i<2:s['target_observation'].update(status='NO_RECORDED_COMPONENT',amount=None)
            elif i<4:s['target_observation'].update(status='CENSORED_TARGET',amount=100)
            else:s['execution_status']='UNACKNOWLEDGED'
        refresh(d);model=fit(d);self.assertFalse(model['parameters']);self.assertEqual(0,model['training_summary']['component_samples'])
        self.assertIsNone(forecast(model,d['samples'][6])[0]['point'])

    def test_missing_stats_and_later_passive_return_model_abstention_not_input_authority(self):
        d=synthetic();model=fit(d);r=prediction_request(d['samples'][6]);r['features']['self_stats']=None
        r['feature_sha256']=digest(r['features']);r['input_complete']=False
        p,diag=predict(model,r,scope_id=numeric_stratum(d['samples'][6]))
        self.assertEqual('INCOMPLETE_PRE_INPUT',p['abstention_reason']);self.assertFalse(diag['input_authority'])
        r=prediction_request(synthetic(ordinary=True)['samples'][6])
        for row in r['features']['board']:
            for cell in row:
                if cell[0]=='sword':cell[0]='shield'
                elif cell[0]=='shield':cell[0]='sword'
        refresh_request(r);p,_=predict(model,r,scope_id=numeric_stratum(d['samples'][6]))
        self.assertEqual('UNMODELED_LATER_PASSIVE',p['abstention_reason'])

    def test_hash_policy_scope_and_derived_support_cannot_be_forged(self):
        model=fit(synthetic())
        for mutate,reason in ((lambda m:m['parameters'][0].update(joint_radius=999),'SUPPORT_DERIVATION'),
                (lambda m:m.update(deployment_eligible=True),'IDENTITY_OR_SCOPE'),
                (lambda m:m['parameters'][0]['rows'][0]['vector'].__setitem__(0,True),'TRAINING_ROW')):
            m=deepcopy(model);mutate(m);m['model_sha256']=digest({k:v for k,v in m.items() if k!='model_sha256'})
            with self.assertRaisesRegex(ValueError,reason):validate_model(m)


class EvaluationTests(unittest.TestCase):
    def test_paired_comparison_exposes_lost_coverage_instead_of_claiming_better_average(self):
        def row(sid,point):return dict(sample_id=sid,match_id='M',numeric_stratum='S',point=point,observed=100,lower=0,upper=600)
        base=dict(dataset_sha256='a'*64,target=TARGET,rows=[row('A',100),row('B',500)])
        new=dict(dataset_sha256='a'*64,target=TARGET,rows=[row('A',100)])
        result=paired(new,base);self.assertEqual(1,result['common_targets']);self.assertEqual(['B'],result['baseline_only_ids'])
        self.assertEqual(0,result['baseline_common_metrics']['mae']);self.assertEqual(0,result['conditional_common_metrics']['mae'])
        self.assertEqual({'TIED':1},result['verdicts'])

    def test_frozen_runner_reproduces_baseline_and_seals_predictions_before_scoring(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            root=Path(folder);data=synthetic();dp=root/'dataset.json';dp.write_text(json.dumps(data),encoding='utf-8')
            base_plan=dict(schema='pokiguard.damage_baseline_experiment.v1',dataset_path=str(dp),dataset_file_sha256=hashlib.sha256(dp.read_bytes()).hexdigest(),dataset_sha256=data['dataset_sha256'],policy=BASELINE_POLICY,data_already_examined=True,independent_holdout=False,hyperparameter_search=False,live_inputs=False,
                folds=[dict(id='ONE',matches={'TRAIN':'TRAIN','VALIDATION':'VALIDATION'}),dict(id='TWO',matches={'TRAIN':'VALIDATION','VALIDATION':'TRAIN'})])
            bp=root/'baseline_plan.json';bp.write_text(json.dumps(base_plan),encoding='utf-8');base=root/'baseline';run_baseline(bp,base)
            policy=root/'policy_frozen.json';policy.write_text(json.dumps(dict(policy=POLICY)),encoding='utf-8')
            entry=dict(id='SYNTHETIC',cohort_id='SYNTHETIC',dataset_path=str(dp),dataset_file_sha256=hashlib.sha256(dp.read_bytes()).hexdigest(),baseline_plan_path=str(bp),baseline_plan_sha256=hashlib.sha256(bp.read_bytes()).hexdigest(),baseline_directory=str(base),baseline_pins={str(p):hashlib.sha256(p.read_bytes()).hexdigest() for p in base.glob('*.json')})
            frozen=root/'plan.json';frozen.write_text(json.dumps(dict(schema='pokiguard.conditional_damage_experiment.v1',policy=POLICY,policy_file_sha256=hashlib.sha256(policy.read_bytes()).hexdigest(),experiments=[entry],data_already_examined=True,independent_holdout=False,hyperparameter_search=False,live_inputs=False)),encoding='utf-8')
            result=run(frozen,root/'new')
            self.assertEqual(2,result['models_fitted']);self.assertFalse(result['model_deployed']);self.assertIsNone(result['pooled_metrics'])
            p=result['cohorts'][0]['modes']['guarded']['paired']
            self.assertEqual(2,p['common_targets']);self.assertEqual(150,p['baseline_common_metrics']['mae']);self.assertEqual(0,p['conditional_common_metrics']['mae'])
            sealed=json.loads((root/'new/SYNTHETIC/ONE/guarded_before_scoring.json').read_bytes())
            self.assertEqual(sealed['predictions_sha256'],hashlib.sha256((root/'new/SYNTHETIC/ONE/guarded_predictions.json').read_bytes()).hexdigest())
            with self.assertRaisesRegex(ValueError,'FRESH_OUTPUT'):run(frozen,root/'new')


if __name__ == '__main__': unittest.main()
