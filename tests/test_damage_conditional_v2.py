"""Raw component evidence, exact Sword support and no future-data authority."""
from copy import deepcopy
from pathlib import Path
import hashlib,json,tempfile,unittest
from pokiguard_v2.damage_conditional_v2 import POLICY,fit_exploratory,predict,validate_model
from pokiguard_v2.damage_evaluation import digest,dataset_identity,prediction_request,numeric_stratum
from pokiguard_v2.reasoning_calibration import source_fingerprint
from tests.test_damage_conditional import synthetic,plan,refresh,refresh_request
from tests.reasoning_test_paths import reasoning_temp_root
from tools.prepare_demon_damage_dataset import first_wave_features
from tools.run_component_damage_v2 import run
ROOT=Path(__file__).resolve().parents[1]
def fit(data):return fit_exploratory(data,plan(data),allow_uncalibrated_component_experiment=True)
def forecast(model,s,mode='guarded'):return predict(model,prediction_request(s),scope_id=numeric_stratum(s),mode=mode)
def rehash(model):model['model_sha256']=digest({k:v for k,v in model.items() if k!='model_sha256'});return model

class ComponentV2Tests(unittest.TestCase):
    def test_explicit_offline_only_and_raw_amount_rows(self):
        d=synthetic();original=deepcopy(d)
        with self.assertRaisesRegex(ValueError,'EXPLICIT_OFFLINE'):fit_exploratory(d,plan(d))
        m=fit(d);self.assertEqual(original,d);self.assertEqual(m,validate_model(m))
        self.assertTrue(all(not m[k] for k in ('input_authority','calibration_eligible','deployment_eligible')))
        rows=[r for g in m['parameters'] for r in g['rows']]
        self.assertEqual({300,600},{r['amount'] for r in rows});self.assertTrue(all('ratio' not in r for r in rows))
        low,ld=forecast(m,d['samples'][6]);high,hd=forecast(m,d['samples'][7])
        self.assertEqual((300,600),(low['point'],high['point']));self.assertFalse(ld['sword_rescale_applied']);self.assertIsNone(ld['per_sword_coefficient'])
        self.assertIn('CRIT',ld['latent_effects']);self.assertIsNone(hd['critical_prediction'])

    def test_reference_never_rescales_to_a_different_sword_vector(self):
        d=synthetic();m=fit(d);sample=deepcopy(d['samples'][6]);old=sample['features']['first_wave']['effective']['sword'];changed=None
        for i,row in enumerate(sample['features']['board']):
            for j,cell in enumerate(row):
                if cell[0]!='sword':continue
                candidate=deepcopy(sample);candidate['features']['board'][i][j][0]='health'
                try:r=refresh_request(prediction_request(dict(candidate,feature_sha256=digest(candidate['features']))))
                except ValueError:continue
                if r['features']['first_wave']['effective']['sword']!=old:changed=r;break
            if changed is not None:break
        self.assertIsNotNone(changed)
        p,diag=predict(m,changed,scope_id=numeric_stratum(sample),mode='reference')
        self.assertEqual('UNSEEN_SCOPE_OR_SWORD_VECTOR',p['abstention_reason']);self.assertIsNone(p['point']);self.assertFalse(diag['sword_rescale_applied'])

    def test_crit_and_unknown_refill_variation_stays_in_empirical_range(self):
        d=synthetic(tied=True);d['samples'][5]['target_observation']['amount']=10000
        d['samples'][5]['target_observation']['full_power_states']=['WIRE_TRUE'];d['samples'][5]['post_crit']=True;refresh(d)
        m=fit(d);p,diag=forecast(m,d['samples'][6]);self.assertEqual((300,10000),(p['lower'],p['upper']))
        self.assertEqual(6,diag['neighbors']);self.assertFalse(diag['whole_action_complete']);self.assertEqual(6,m['training_summary']['component_samples'])
        self.assertIn('NOT_CALIBRATED',diag['interval_semantics'])

    def test_duplicate_board_has_one_neighbor_weight_and_cannot_manufacture_support(self):
        d=synthetic(tied=True)
        for index in (1,2):
            d['samples'][index]['features']=deepcopy(d['samples'][0]['features']);d['samples'][index]['feature_sha256']=digest(d['samples'][index]['features'])
        refresh(d);m=fit(d);p,diag=forecast(m,d['samples'][6]);self.assertEqual(4,diag['neighbors']);self.assertIsNotNone(p['point'])
        for index in range(1,6):
            d['samples'][index]['features']=deepcopy(d['samples'][0]['features']);d['samples'][index]['feature_sha256']=digest(d['samples'][index]['features'])
        refresh(d);m=fit(d);self.assertEqual('INSUFFICIENT_UNIQUE_TRAINING_BOARDS',forecast(m,d['samples'][6])[0]['abstention_reason'])

    def test_no_training_action_or_training_board_is_validation(self):
        d=synthetic();m=fit(d)
        self.assertEqual('IN_SAMPLE_REQUEST_NOT_VALIDATION',forecast(m,d['samples'][0])[0]['abstention_reason'])
        s=deepcopy(d['samples'][6]);s['features']['board']=deepcopy(d['samples'][0]['features']['board']);s['feature_sha256']=digest(s['features'])
        self.assertEqual('TRAINING_BOARD_NOT_VALIDATION',forecast(m,s)[0]['abstention_reason'])

    def test_outside_context_and_joint_guard_are_not_clipped(self):
        d=synthetic();m=fit(d);s=deepcopy(d['samples'][6]);s['features']['boss_stats']['shield']=1;s['feature_sha256']=digest(s['features'])
        p,diag=forecast(m,s);self.assertEqual('OUTSIDE_TRAINING_CONTEXT',p['abstention_reason']);self.assertIn('boss_shield',diag['outside_training_domain'])
        self.assertIsNotNone(forecast(m,s,'reference')[0]['point'])

    def test_account_build_and_source_never_pool(self):
        d=synthetic();m=fit(d)
        for field in ('account_sha256','source_sha256','game_build_sha256'):
            s=deepcopy(d['samples'][6]);s['scope'][field]='f'*64
            self.assertEqual('UNSEEN_SCOPE_OR_SWORD_VECTOR',forecast(m,s,'reference')[0]['abstention_reason'])

    def test_post_fields_never_filter_train_or_change_pre_input_predictions(self):
        d=synthetic();m=fit(d);poison=deepcopy(d)
        for s in poison['samples']:
            s['post_crit']=True;s['post_sword_count']=999;s['response_context']={'power':999};s['target_observation']['full_power_states']=['POISON']
            if s['match_id']=='VALIDATION':s['target_observation']['amount']=99999999
        poison['dataset_sha256']=dataset_identity(poison);new=fit(poison)
        self.assertEqual(m['parameters'],new['parameters']);self.assertEqual(m['training_payload_sha256'],new['training_payload_sha256'])
        for a,b in zip(d['samples'][6:],poison['samples'][6:],strict=True):self.assertEqual(forecast(m,a)[0],forecast(new,b)[0])
        request=prediction_request(poison['samples'][6]);request['post_crit']=True
        with self.assertRaisesRegex(ValueError,'EXACT_PRE_INPUT'):predict(m,request,scope_id=numeric_stratum(poison['samples'][6]))

    def test_missing_censored_unacknowledged_are_never_zero_training_components(self):
        d=synthetic()
        for index,status in enumerate(('MISSING_TYPED_RESPONSE','CENSORED_TARGET','NO_RECORDED_COMPONENT')):d['samples'][index]['target_observation']['status']=status
        d['samples'][3]['execution_status']='UNACKNOWLEDGED';refresh(d);m=fit(d)
        self.assertEqual(2,m['training_summary']['component_samples']);self.assertEqual(4,sum(m['training_summary']['skipped'].values()))

    def test_all_five_demon_targets_share_the_same_algorithm(self):
        for target in ('shield','health','mana','drain','rage'):
            d=synthetic()
            for s in d['samples']:
                f=s['features']
                for row in f['board']:
                    for cell in row:
                        if cell[0]=='shield':cell[0]=target
                        elif cell[0]==target:cell[0]='shield'
                f['settings']['demon_target_gem']=target;f['first_wave']=first_wave_features(f['board'],f['move'],target);s['feature_sha256']=digest(f)
            refresh(d);m=fit(d);self.assertEqual((300,600),tuple(forecast(m,s)[0]['point'] for s in d['samples'][6:]))

    def test_tampered_amount_group_domain_or_authority_is_rejected(self):
        m=fit(synthetic())
        bad=deepcopy(m);bad['parameters'][0]['rows'][0]['amount']+=1
        with self.assertRaises(ValueError):validate_model(bad)
        for mutate in (lambda b:b.update(input_authority=True),lambda b:b['parameters'][0]['domain'][0].update(high=999),
                       lambda b:b['parameters'][0]['rows'][0]['vector'].__setitem__(0,999),
                       lambda b:b['parameters'][0]['rows'].append(deepcopy(b['parameters'][0]['rows'][0]))):
            bad=deepcopy(m);mutate(bad)
            with self.assertRaises(ValueError):validate_model(rehash(bad))

    def test_runner_seals_both_controls_and_model_before_scoring(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            root=Path(folder);d=synthetic();dp=root/'data.json';dp.write_text(json.dumps(d),encoding='utf-8')
            pp=root/'policy_frozen.json';pp.write_text(json.dumps(POLICY),encoding='utf-8')
            frozen=dict(schema='pokiguard.component_v2_experiment.v1',source_sha256=source_fingerprint(ROOT),policy=POLICY,
                policy_file_sha256=hashlib.sha256(pp.read_bytes()).hexdigest(),data_already_examined=True,independent_holdout=False,hyperparameter_search=False,live_inputs=False,
                experiments=[dict(id='SYNTHETIC',cohort_id='SYNTHETIC',purpose='UNIT_TEST_ONLY',dataset_path=str(dp),dataset_file_sha256=hashlib.sha256(dp.read_bytes()).hexdigest(),
                    folds=[dict(id='ONE',matches={'TRAIN':'TRAIN','VALIDATION':'VALIDATION'})],validation_match_ids=['VALIDATION'])])
            fp=root/'plan.json';fp.write_text(json.dumps(frozen),encoding='utf-8');out=root/'experiment';result=run(fp,out)
            self.assertEqual(3,result['models_fitted']);self.assertFalse(result['model_deployed']);self.assertFalse(result['independent_holdout'])
            info=result['experiments'][0];self.assertEqual(2,info['scored_actions']);self.assertEqual(2,info['metrics']['v2']['guarded']['scored'])
            seal=json.loads((out/'SYNTHETIC/all_forecasts_before_scoring.json').read_bytes())
            for rel,h in seal['prediction_files_sha256'].items():self.assertEqual(h,hashlib.sha256((out/'SYNTHETIC'/rel).read_bytes()).hexdigest())
            with self.assertRaisesRegex(ValueError,'FRESH_OUTPUT'):run(fp,out)

if __name__=='__main__':unittest.main()
