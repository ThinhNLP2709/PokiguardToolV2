"""Leakage, missing/censored targets and grouped error protocol, file-only."""
from copy import deepcopy
import hashlib
import json
from pathlib import Path
import tempfile
import unittest

from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_action_outcome_normalization import fixture
from tools.prepare_demon_damage_dataset import build,MANIFEST_SCHEMA,first_wave_features
from tools.normalize_combat_observations import first_wave
from pokiguard_v2.combat_outcome_evidence import actor_identity
from pokiguard_v2.damage_evaluation import (TARGET,PREDICTION_SCHEMA,digest,dataset_identity,
    prediction_request,partitions_for,evaluate,validate_features)


def rows(*,ack=True,capture=True,amount=100,match='M_SYNTHETIC_DATASET'):
    sent,outcome=fixture();who=actor_identity(sent['identity']['source']['current_turn_player'])
    sent['matchId']=sent['identity']['source']['session']['match_id']=match
    outcome['evidence']['match_id']=match
    sent['player'].update(is_local=True,is_boss=False,actor_number=1,
        source='Active.playerStatsMap/ObfuscatedInt.Value',hp=500,max_hp=1000,mana=10,max_mana=100,power=50,max_power=250,attack=1819,shield=0)
    sent['boss'].update(is_local=False,is_boss=True,actor_number=99,
        source='Active.playerStatsMap/ObfuscatedInt.Value',hp=2000,max_hp=5000,mana=10,max_mana=100,power=50,max_power=250,attack=766,shield=0)
    outcome['evidence']['steps']=[dict(idx=0,kind='DAMAGE',amount=amount,source=who,target='BOSS',after={'HP':2000-amount},
        damage_source='SYNTHETIC_DAMAGE',full_power=True,full_power_presence='VALUE',steal_type=None)]
    config=dict(play_style='demon_aegis_farm',damage_card='pet_passive',demon_target_gem='shield',main_pet='normal',evolution_target='none')
    result=[dict(event='auto_controller_started',config=config),sent]
    if capture:result.append(dict(event='dispatcher_combat_outcome',combatOutcome=outcome))
    if ack:result.append(dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=deepcopy(sent['identity']))))
    return result


def manifest_case(path,records,name='synthetic'):
    sent=next(r for r in records if r.get('event')=='action_sent')
    return dict(name=name,combat_path=str(path),combat_sha256=hashlib.sha256(path.read_bytes()).hexdigest(),
        match_id=sent['matchId'],source_sha256='a'*64,game_build_sha256='b'*64,
        account_sha256=actor_identity(sent['identity']['source']['current_turn_player'])[7:],cohort_id='SYNTHETIC_NOT_NATIVE',seen_in_research=True)


class DatasetTests(unittest.TestCase):
    def run_rows(self,*groups,extra_cases=()):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            cases=[];pins={}
            for i,records in enumerate(groups):
                p=Path(d)/f'combat{i}.jsonl'
                p.write_text('\n'+'\n'.join(json.dumps(r) for r in records)+'\n',encoding='utf-8')
                pins[p]=p.read_bytes();cases.append(manifest_case(p,records,str(i)))
            cases.extend(extra_cases(cases) if callable(extra_cases) else extra_cases)
            result=build(dict(schema=MANIFEST_SCHEMA,cases=cases))
            for p,raw in pins.items():self.assertEqual(raw,p.read_bytes())
            return result

    def predictions(self,d,values=None):
        values=values or [100]*len(d['samples'])
        return dict(schema=PREDICTION_SCHEMA,dataset_sha256=d['dataset_sha256'],model_id='SYNTHETIC_FIXED_FORECAST_NOT_FITTED',target=TARGET,
            predictions=[dict(sample_id=s['sample_id'],feature_sha256=s['feature_sha256'],point=v,lower=max(0,v-30),upper=v+30,abstention_reason=None)
                for s,v in zip(d['samples'],values,strict=True)])

    def plan(self,d,partition='DEVELOPMENT'):
        return dict(dataset_sha256=d['dataset_sha256'],matches={s['match_id']:partition for s in d['samples']},independent_holdout=False)

    def test_model_request_contains_only_pre_input_fields_and_changes_no_source(self):
        raw=rows();original=deepcopy(raw);d=self.run_rows(raw);s=d['samples'][0]
        request=prediction_request(s)
        self.assertEqual(original,raw);self.assertTrue(request['input_complete'])
        self.assertEqual(1819,request['features']['self_stats']['attack'])
        self.assertFalse(d['training_eligible']);self.assertFalse(s['calibration_eligible'])
        self.assertEqual('RECORDED_COMPONENT',s['target_observation']['status'])
        for key in ('target_observation','full_power_states','response_sequence','raw_response_sha256','weaknessVsBoss','equipCounterPct','after'):
            self.assertNotIn(key,json.dumps(request))

    def test_future_damage_power_and_context_cannot_change_feature_hash(self):
        a=rows(amount=100);b=deepcopy(a)
        b[2]['combatOutcome']['evidence']['steps'][0].update(amount=900,after={'HP':1100},full_power=False)
        b[2]['combatOutcome']['player_context']={'hp':999999,'petId':123,'weaknessVsBoss':99}
        x=self.run_rows(a)['samples'][0];y=self.run_rows(b)['samples'][0]
        self.assertEqual(x['feature_sha256'],y['feature_sha256'])
        self.assertEqual(prediction_request(x),prediction_request(y))
        self.assertNotEqual(x['target_observation']['amount'],y['target_observation']['amount'])

    def test_ack_without_effect_and_no_damage_component_are_not_zero_targets(self):
        missing=self.run_rows(rows(capture=False));s=missing['samples'][0]
        self.assertEqual('ACKNOWLEDGED',s['execution_status'])
        self.assertEqual('MISSING_TYPED_RESPONSE',s['target_observation']['status']);self.assertIsNone(s['target_observation']['amount'])
        report=evaluate(missing,self.predictions(missing),self.plan(missing))
        self.assertEqual(1,report['acknowledged_actions']);self.assertEqual(0,report['scored']);self.assertIsNone(report['metrics']['mae'])
        self.assertEqual({'MISSING_TYPED_RESPONSE':1},report['data_readiness']);self.assertIsNone(report['coverage_of_recorded_component_targets'])
        a=rows();a[2]['combatOutcome']['evidence']['steps'][0].update(kind='POWER',target=actor_identity(a[1]['identity']['source']['current_turn_player']))
        s=self.run_rows(a)['samples'][0];self.assertEqual('NO_RECORDED_COMPONENT',s['target_observation']['status']);self.assertIsNone(s['target_observation']['amount'])

    def test_explicit_zero_can_be_scored_without_mape_or_division_by_zero(self):
        d=self.run_rows(rows(amount=0));p=self.predictions(d);p['predictions'][0].update(point=0,lower=0,upper=0)
        r=evaluate(d,p,self.plan(d));self.assertEqual(1,r['scored']);self.assertEqual(0,r['metrics']['mae']);self.assertNotIn('mape',r['metrics'])

    def test_unacknowledged_and_conflicting_execution_never_supply_exact_targets(self):
        for records in (rows(ack=False),rows()):
            if len(records)>3:
                records.append(dict(event='action_result',result='SWAP_ABORTED_STATE_CHANGED',action=deepcopy(records[-1]['action'])))
            d=self.run_rows(records);s=d['samples'][0]
            self.assertNotEqual('ACKNOWLEDGED',s['execution_status']);self.assertIsNone(s['target_observation']['amount'])
            self.assertEqual(0,evaluate(d,self.predictions(d),self.plan(d))['scored'])

    def test_negative_and_hp_zero_are_kept_but_not_exact_metric_labels(self):
        for amount,status in ((-1,'INVALID_COMPONENT'),(3000,'CENSORED_TARGET')):
            a=rows(amount=amount)
            if amount>0:a[2]['combatOutcome']['evidence']['steps'][0]['after']['HP']=0
            d=self.run_rows(a);self.assertEqual(status,d['samples'][0]['target_observation']['status'])
            self.assertEqual(0,evaluate(d,self.predictions(d),self.plan(d))['scored'])

    def test_ownership_missing_stats_and_invalid_board_are_not_repaired(self):
        a=rows();a[1]['player']['is_local']=None
        d=self.run_rows(a);self.assertIsNone(d['samples'][0]['features']['self_stats']);self.assertFalse(d['samples'][0]['input_complete'])
        self.assertEqual(0,evaluate(d,self.predictions(d),self.plan(d))['scored'])
        a=rows();a[1]['boardSnapshot'][0][0]=['unknown',1]
        d=self.run_rows(a);self.assertIsNone(d['samples'][0]['features']['board']);self.assertFalse(d['samples'][0]['input_complete'])

    def test_pin_actor_and_source_fences_and_blank_physical_lines(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            p=Path(folder)/'combat.jsonl';a=rows();p.write_text('\n\n'+'\n'.join(json.dumps(r) for r in a),encoding='utf-8')
            case=manifest_case(p,a);m=dict(schema=MANIFEST_SCHEMA,cases=[case])
            d=build(m);self.assertEqual(4,d['samples'][0]['provenance'][0]['action_line'])
            case['account_sha256']='c'*64
            other=build(m);self.assertFalse(other['samples']);self.assertEqual(1,other['summary']['excluded_actions'])
            p.write_text(p.read_text()+'\n',encoding='utf-8')
            with self.assertRaisesRegex(ValueError,'PIN_MISMATCH'):build(m)
        a=rows();a[1]['boardHash']='f'*64
        d=self.run_rows(a);self.assertFalse(d['samples']);self.assertEqual(1,d['summary']['excluded_actions'])

    def test_copy_dedup_and_conflict_quarantine_do_not_create_extra_samples(self):
        a=rows();d=self.run_rows(a,deepcopy(a))
        self.assertEqual(1,len(d['samples']));self.assertEqual(1,d['summary']['duplicates'])
        self.assertEqual(2,len(d['samples'][0]['provenance']))
        b=deepcopy(a);b[1]['player']['hp']-=1
        d=self.run_rows(a,b);self.assertFalse(d['samples']);self.assertEqual(1,d['summary']['conflicting_actions'])

    def test_geometry_reuses_existing_solver_for_five_targets_and_x7(self):
        sent=rows()[1];board=sent['boardSnapshot'];move=sent['identity']['target']
        for target in ('shield','health','mana','drain','rage'):
            mapped=deepcopy(board)
            for row in mapped:
                for c in row:
                    if c[0]=='shield':c[0]=target
                    elif c[0]==target:c[0]='shield'
            old=first_wave(mapped,move,target);new=first_wave_features(mapped,move,target)
            self.assertEqual(old['physical'],new['physical']);self.assertEqual(old['effective'],new['effective'])
            self.assertTrue(new['passive_triggered'])
        a=rows()
        for row in a[1]['boardSnapshot']:
            for c in row:
                if c[0]=='sword':c[1]=7
        d=self.run_rows(a);s=d['samples'][0];self.assertTrue(s['input_complete'])
        wave=s['features']['first_wave'];self.assertEqual(7*wave['physical']['sword'],wave['effective']['sword'])
        ordinary=first_wave_features(board,move,'mana');self.assertFalse(ordinary['passive_triggered'])

    def test_group_split_refuses_seen_holdout_and_same_board_in_different_matches(self):
        d=self.run_rows(rows(match='M_ONE'),rows(match='M_TWO'))
        plan=self.plan(d);plan['matches'].update(M_ONE='TRAIN',M_TWO='VALIDATION')
        with self.assertRaisesRegex(ValueError,'BOARD_LEAKAGE'):partitions_for(d,plan)
        with self.assertRaisesRegex(ValueError,'ALREADY_SEEN'):partitions_for(d,self.plan(d,'TEST'))
        plan=self.plan(d);plan['matches'].pop('M_TWO')
        with self.assertRaisesRegex(ValueError,'PARTITION_PLAN'):partitions_for(d,plan)

    def test_synthetic_metric_math_and_abstentions_keep_denominators_visible(self):
        d=self.run_rows(rows(amount=100,match='M_ONE'),rows(amount=200,match='M_TWO'))
        p=self.predictions(d,[120,180]);p['predictions'][0].update(lower=90,upper=130);p['predictions'][1].update(lower=160,upper=210)
        r=evaluate(d,p,self.plan(d));self.assertEqual(2,r['scored']);self.assertEqual(20,r['metrics']['mae']);self.assertEqual(20,r['metrics']['rmse'])
        self.assertEqual(0,r['metrics']['mean_signed_error']);self.assertEqual(1,r['metrics']['interval_coverage']);self.assertEqual(45,r['metrics']['mean_interval_width'])
        self.assertFalse(r['deployment_eligible']);self.assertFalse(r['prospective_prediction_provenance_verified'])
        p['predictions'][0].update(point=None,lower=None,upper=None,abstention_reason='NO_MODEL')
        r=evaluate(d,p,self.plan(d));self.assertEqual(1,r['scored']);self.assertEqual(1,r['skipped']['MODEL_ABSTAINED'])
        p['predictions']=[];r=evaluate(d,p,self.plan(d));self.assertEqual(2,r['total_actions']);self.assertEqual(2,r['skipped']['NO_PREDICTION_SUPPLIED'])

    def test_wrong_prediction_identity_duplicates_nan_boolean_and_interval_rejected(self):
        d=self.run_rows(rows());plan=self.plan(d)
        for mutation in (lambda p:p.update(dataset_sha256='f'*64),lambda p:p.update(target='WHOLE_ACTION_DAMAGE'),
                lambda p:p['predictions'][0].update(feature_sha256='f'*64),lambda p:p['predictions'].append(deepcopy(p['predictions'][0])),
                lambda p:p['predictions'][0].update(point=float('nan')),lambda p:p['predictions'][0].update(point=True),
                lambda p:p['predictions'][0].update(lower=999),lambda p:p['predictions'][0].update(point=10**1000)):
            p=self.predictions(d);mutation(p)
            with self.assertRaises(ValueError):evaluate(d,p,plan)

    def test_feature_whitelist_and_dataset_digest_block_post_input_injection(self):
        d=self.run_rows(rows());s=deepcopy(d['samples'][0]);s['features']['self_stats']['after_hp']=999
        with self.assertRaisesRegex(ValueError,'STATS_FIELDS'):prediction_request(s)
        s=deepcopy(d['samples'][0]);s['features']['fullPower']=True
        with self.assertRaisesRegex(ValueError,'FEATURE_SCHEMA'):prediction_request(s)
        corrupted=deepcopy(d);corrupted['samples'][0]['target_observation']['amount']=999
        with self.assertRaisesRegex(ValueError,'DATASET_IDENTITY'):evaluate(corrupted,self.predictions(d),self.plan(d))

    def test_error_groups_separate_build_and_numeric_loadout_and_never_attest_holdout(self):
        d=self.run_rows(rows(amount=100,match='M_ONE'),rows(amount=200,match='M_TWO'))
        d['samples'][1]['scope']['game_build_sha256']='e'*64
        d['samples'][0]['seen_in_research']=d['samples'][1]['seen_in_research']=False
        d['dataset_sha256']=dataset_identity(d)
        plan=self.plan(d,'TEST');plan['independent_holdout']=True
        r=evaluate(d,self.predictions(d,[100,200]),plan)
        self.assertEqual(2,len(r['groups']));self.assertTrue(r['independent_holdout_declared'])
        self.assertFalse(r['independent_holdout']);self.assertFalse(r['prospective_prediction_provenance_verified'])


if __name__=='__main__':unittest.main()
