"""Old raw can be replayed without granting source, loadout or input authority."""
from contextlib import contextmanager
from copy import deepcopy
from pathlib import Path
import json,tempfile,unittest
from pokiguard_v2.damage_evaluation import digest,dataset_identity
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_damage_dataset import rows,manifest_case
from tools.prepare_demon_damage_dataset import build,MANIFEST_SCHEMA
from tools.audit_damage_data_reuse import replay_dataset,compare_sources,checked_source,audit,FEATURE_FILES,TARGET_FILES,PUBLISHER_FILES

@contextmanager
def corpus():
    with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
        root=Path(folder);p=root/'combat.jsonl';records=rows()
        p.write_text('\n'.join(json.dumps(r) for r in records)+'\n',encoding='utf-8')
        manifest=dict(schema=MANIFEST_SCHEMA,cases=[manifest_case(p,records)])
        yield root,p,build(manifest)
def snapshot(files):return dict(source_sha256=digest(files),files=files)
def full_source():return {n:digest(n) for n in set(FEATURE_FILES+TARGET_FILES+PUBLISHER_FILES)}
def refresh(d):d['dataset_sha256']=dataset_identity(d);return d

class DamageDataReuseTests(unittest.TestCase):
    def test_entire_sample_replays_without_mutating_raw_or_declarations(self):
        with corpus() as (_,p,data):
            original=deepcopy(data);raw=p.read_bytes();r=replay_dataset(data)
            self.assertTrue(r['replay_compatible']);self.assertEqual(1,r['entire_samples_exact'])
            self.assertEqual(1,r['original_scopes_exact']);self.assertFalse(r['source_rewritten']);self.assertFalse(r['cohort_rewritten'])
            self.assertFalse(r['statistical_pooling_authorized']);self.assertFalse(r['input_authority'])
            self.assertEqual(original,data);self.assertEqual(raw,p.read_bytes())

    def test_poisoned_target_is_reported_incompatible_and_never_replaced(self):
        with corpus() as (_,_,data):
            data['samples'][0]['target_observation']['amount']+=1;refresh(data);before=deepcopy(data);r=replay_dataset(data)
            self.assertFalse(r['replay_compatible']);self.assertEqual(0,r['targets_and_execution_exact']);self.assertEqual(1,r['pre_input_exact'])
            self.assertEqual(before,data)

    def test_poisoned_pre_input_is_not_accepted_because_raw_has_a_valid_hash(self):
        with corpus() as (_,_,data):
            s=data['samples'][0];s['features']['self_stats']['hp']+=1;s['feature_sha256']=digest(s['features']);refresh(data)
            r=replay_dataset(data);self.assertFalse(r['replay_compatible']);self.assertEqual(0,r['pre_input_exact']);self.assertEqual(1,r['targets_and_execution_exact'])

    def test_changed_raw_is_rejected_before_replay(self):
        with corpus() as (_,p,data):
            p.write_bytes(p.read_bytes()+b'\n')
            with self.assertRaisesRegex(ValueError,'PINNED_RAW_CHANGED'):replay_dataset(data)

    def test_missing_raw_and_missing_provenance_fail_closed(self):
        with corpus() as (_,p,data):
            original=deepcopy(data);data['samples'][0]['provenance']=[];refresh(data)
            with self.assertRaisesRegex(ValueError,'PROVENANCE'):replay_dataset(data)
            p.unlink()
            with self.assertRaisesRegex(ValueError,'RAW_CHANGED_OR_MISSING'):replay_dataset(original)

    def test_replay_does_not_attest_a_declared_source_or_seen_flag(self):
        with corpus() as (_,_,data):
            data['samples'][0]['scope']['source_sha256']='f'*64;data['samples'][0]['seen_in_research']=False;refresh(data)
            r=replay_dataset(data);self.assertTrue(r['replay_compatible'])
            self.assertFalse(r['historical_seen_status_attested']);self.assertFalse(r['statistical_pooling_authorized'])
            self.assertIn('NOT_RUNTIME_ATTESTATION',r['scope_identity_status']);self.assertFalse(r['seen_flags_rewritten'])

    def test_additive_source_identity_is_separate_from_statistical_or_native_authority(self):
        files=full_source();other=dict(files,**{'tests/test_new.py':digest('new')})
        r=compare_sources(snapshot(files),snapshot(other));self.assertTrue(r['all_existing_python_byte_equal'])
        self.assertTrue(r['feature_extractor']['byte_equal']);self.assertTrue(r['target_extractor']['byte_equal'])
        self.assertEqual(['tests/test_new.py'],r['added']);self.assertFalse(r['native_timing_reuse_authorized']);self.assertFalse(r['statistical_pooling_authorized'])

    def test_changed_target_or_missing_producer_never_becomes_a_blanket_whitelist(self):
        files=full_source();other=deepcopy(files);other[TARGET_FILES[-1]]=digest('changed')
        r=compare_sources(snapshot(files),snapshot(other));self.assertFalse(r['target_extractor']['byte_equal']);self.assertFalse(r['all_existing_python_byte_equal'])
        other=deepcopy(files);del other[FEATURE_FILES[0]]
        r=compare_sources(snapshot(files),snapshot(other));self.assertFalse(r['feature_extractor']['byte_equal']);self.assertTrue(r['deleted'])

    def test_forged_or_invalid_source_manifests_are_rejected(self):
        s=snapshot(full_source());s['source_sha256']='0'*64
        with self.assertRaisesRegex(ValueError,'SOURCE_MANIFEST_IDENTITY'):checked_source(s)
        for name in ('../outside.py','src/../outside.py','src\\mixed.py','other/file.py'):
            with self.assertRaisesRegex(ValueError,'SOURCE_FILE_IDENTITY'):checked_source(snapshot({name:'a'*64}))

    def test_same_pinned_action_cannot_be_counted_twice_via_two_datasets(self):
        with corpus() as (root,_,data):
            paths=[root/'first.json',root/'copy.json']
            for p in paths:p.write_text(json.dumps(data),encoding='utf-8')
            with self.assertRaisesRegex(ValueError,'DUPLICATE_PRIMARY_ACTIONS'):audit(paths,[])

    def test_cache_key_binds_pipeline_and_raw_without_creating_a_model(self):
        with corpus() as (root,_,data):
            p=root/'dataset.json';p.write_text(json.dumps(data),encoding='utf-8')
            r=audit([p],[]);self.assertEqual('PASS',r['status']);self.assertEqual(1,r['unique_actions'])
            self.assertEqual(digest(r['replay_pipeline_files']),r['replay_pipeline_sha256'])
            self.assertEqual(0,r['new_models_fitted']);self.assertEqual(0,r['new_live_attempts']);self.assertFalse(r['process_attachment'])
            self.assertEqual('UNKNOWN_NOT_INFERRED_FROM_ATTACK_OR_HP',r['loadout_equivalence'])

if __name__=='__main__':unittest.main()
