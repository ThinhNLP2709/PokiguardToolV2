"""Pre-input geometry, separation of mechanisms and missingness; no game IO."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.damage_action_context import describe_action
from pokiguard_v2.damage_evaluation import digest, input_complete, prediction_request
from tools.prepare_demon_damage_dataset import first_wave_features, MANIFEST_SCHEMA
from tools.review_damage_mechanisms import review
from tests import test_damage_dataset as dataset_fixture
from tests.test_damage_dataset import rows, manifest_case
from tests.reasoning_test_paths import reasoning_temp_root

FIXTURE = Path(__file__).parent/'fixtures/damage_action_context_20261121.json'


def requests():
    return {c['name']: c['request'] for c in json.loads(FIXTURE.read_bytes())['cases']}


def refresh(request):
    f = request['features']
    f['first_wave'] = first_wave_features(f['board'], f['move'], f['settings']['demon_target_gem'])
    request['feature_sha256'] = digest(f); request['input_complete'] = input_complete(f)
    return request


class ActionContextTests(unittest.TestCase):
    def test_known_sword_cascade_was_already_on_the_pre_input_board(self):
        r = requests()['M_ef4bd854:13']; before = deepcopy(r); c = describe_action(r)
        self.assertEqual(before, r)
        self.assertEqual(0, r['features']['first_wave']['effective']['sword'])
        self.assertEqual(3, c['known_ordinary_cascade_effective_swords'])
        self.assertEqual(3, c['known_prefix']['effective']['sword'])
        self.assertEqual(0, c['known_prefix']['effective']['health'])
        self.assertEqual(1, c['known_prefix']['ordinary_cascade_rounds'])
        self.assertFalse(c['actual_refill_used']); self.assertFalse(c['known_prefix']['continuation_complete'])

    def test_known_mana_and_drain_cascades_reuse_the_existing_solver(self):
        for name, first, later in (('M_3e16d5ee:1', 'drain', 'mana'), ('M_ef4bd854:15', 'health', 'drain')):
            r = requests()[name]; c = describe_action(r)
            self.assertEqual(3, c['known_prefix']['effective'][first])
            self.assertEqual(3, c['known_prefix']['effective'][later])
            self.assertEqual(0, c['known_ordinary_cascade_effective_swords'])

    def test_sweep_and_direct_partition_are_disjoint_and_reconstruct_first_wave(self):
        r = requests()['M_ef4bd854:1']; c = describe_action(r); p = c['first_wave_partition']
        self.assertEqual(3, c['first_wave_sweep_effective_swords'])
        self.assertEqual(0, c['first_wave_direct_effective_swords'])
        for unit in ('physical','effective'):
            self.assertEqual(r['features']['first_wave'][unit],
                {g:p['sweep'][unit][g]+p['direct_outside_sweep'][unit][g] for g in p['sweep'][unit]})
        self.assertEqual('DECLARED_DEMON_FIRST_WAVE_ONLY', c['known_prefix']['coverage'])
        self.assertEqual(0, c['known_prefix']['ordinary_cascade_rounds'])

    def test_all_five_activation_targets_preserve_geometry_without_shield_constants(self):
        for target in ('shield','health','mana','drain','rage'):
            r = deepcopy(requests()['M_ef4bd854:1']); f = r['features']
            for row in f['board']:
                for cell in row:
                    if cell[0]=='shield':cell[0]=target
                    elif cell[0]==target:cell[0]='shield'
            f['settings']['demon_target_gem']=target; c=describe_action(refresh(r))
            self.assertEqual(3,c['first_wave_sweep_effective_swords'])
            self.assertEqual(24,sum(c['known_prefix']['physical'].values()))

    def test_x1_through_x7_are_effective_units_not_physical_cell_counts(self):
        for multiplier in range(1,8):
            r=deepcopy(requests()['M_ef4bd854:13'])
            for row in r['features']['board']:
                for cell in row:
                    if cell[0]=='sword':cell[1]=multiplier
            c=describe_action(refresh(r))
            self.assertEqual(3,c['known_prefix']['physical']['sword'])
            self.assertEqual(3*multiplier,c['known_ordinary_cascade_effective_swords'])

    def test_later_activation_cascade_stops_at_first_wave_without_inventing_a_sweep(self):
        r=deepcopy(requests()['M_ef4bd854:13'])
        for row in r['features']['board']:
            for cell in row:
                if cell[0]=='sword':cell[0]='shield'
                elif cell[0]=='shield':cell[0]='sword'
        c=describe_action(refresh(r))
        self.assertTrue(c['known_prefix']['later_passive_unmodeled'])
        self.assertEqual('FIRST_WAVE_ONLY_LATER_PASSIVE_UNMODELED',c['known_prefix']['coverage'])
        self.assertEqual(0,c['known_prefix']['effective']['shield'])
        self.assertEqual(0,c['known_ordinary_cascade_effective_swords'])

    def test_power_and_drain_are_raw_context_not_full_power_or_net_balance_predictions(self):
        r=requests()['M_ef4bd854:1']; c=describe_action(r)
        self.assertEqual(0,c['pre_resource_context']['power'])
        self.assertEqual(5,c['pre_resource_context']['first_wave_effective_rage'])
        self.assertEqual(5,c['pre_resource_context']['known_prefix_effective_drain'])
        self.assertEqual('UNKNOWN',c['pre_resource_context']['server_resource_order'])
        for key in ('damage_prediction','full_power_prediction','critical_prediction'):self.assertIsNone(c[key])
        for key in ('net_resource_prediction','calibration_eligible','input_authority'):self.assertFalse(c[key])

    def test_missing_owned_stats_are_not_filled_with_zero(self):
        r=deepcopy(requests()['M_ef4bd854:13']); r['features']['self_stats']=None
        r['feature_sha256']=digest(r['features']);r['input_complete']=False;c=describe_action(r)
        self.assertIsNone(c['pre_resource_context']['power']);self.assertIsNone(c['pre_resource_context']['max_power'])
        self.assertFalse(c['input_complete']);self.assertEqual(3,c['known_prefix']['effective']['sword'])

    def test_missing_board_or_unsupported_configuration_stays_unknown(self):
        r=deepcopy(requests()['M_ef4bd854:13']);r['features']['board']=None
        r['feature_sha256']=digest(r['features']);r['input_complete']=False
        self.assertEqual('UNKNOWN',describe_action(r)['status'])
        r=deepcopy(requests()['M_ef4bd854:13']);r['features']['settings']['play_style']='galaxy'
        r['feature_sha256']=digest(r['features'])
        self.assertEqual('UNKNOWN',describe_action(r)['status'])

    def test_exact_request_hash_cached_geometry_and_completeness_are_enforced(self):
        for mutate,reason in ((lambda r:r.update(after={}), 'EXACT_PRE_INPUT'),
                (lambda r:r.update(feature_sha256='f'*64),'PRE_INPUT_IDENTITY'),
                (lambda r:r.update(input_complete=False),'PRE_INPUT_IDENTITY')):
            r=deepcopy(requests()['M_ef4bd854:1']);mutate(r)
            with self.assertRaisesRegex(ValueError,reason):describe_action(r)
        r=deepcopy(requests()['M_ef4bd854:1']);r['features']['first_wave']['effective']['sword']=4
        r['feature_sha256']=digest(r['features'])
        with self.assertRaisesRegex(ValueError,'FEATURE_BOARD_MISMATCH'):describe_action(r)

    def test_future_damage_flags_and_after_context_cannot_change_descriptors(self):
        a=rows(); b=deepcopy(a);b[2]['combatOutcome']['evidence']['steps'][0].update(amount=999,full_power=False,after={'HP':1001})
        b[2]['combatOutcome']['damage_operations']={'future':'ignored'}
        b[2]['combatOutcome']['player_context']={'attack':999999}
        x=dataset_fixture.DatasetTests().run_rows(a)['samples'][0];y=dataset_fixture.DatasetTests().run_rows(b)['samples'][0]
        self.assertEqual(describe_action(prediction_request(x)),describe_action(prediction_request(y)))

    def test_file_review_keeps_targets_raw_and_never_rewrites_inputs_or_adds_authority(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            p=Path(folder)/'combat.jsonl';records=rows();p.write_text('\n'.join(json.dumps(r) for r in records)+'\n',encoding='utf-8')
            raw=p.read_bytes();r=review(dict(schema=MANIFEST_SCHEMA,cases=[manifest_case(p,records)]))
            self.assertEqual(raw,p.read_bytes());self.assertEqual(100,r['records'][0]['post_response']['target']['amount'])
            self.assertFalse(r['target_rewritten']);self.assertFalse(r['input_authority']);self.assertEqual(0,r['models_fitted'])


if __name__ == '__main__': unittest.main()
