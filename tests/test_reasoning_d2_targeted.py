"""File-only DarkQueen native review. No game discovery, worker or input."""
import copy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_calibration import decode_config
from pokiguard_v2.reasoning_d2_native import check_config
from pokiguard_v2.reasoning_d2_targeted import verify_native,verify_source_boundary
from pokiguard_v2.reasoning_snapshot import digest
from tools.prepare_d2_targeted import copy_native,ROOT


class TargetedD2Tests(unittest.TestCase):
    def setUp(self):
        tmp=tempfile.TemporaryDirectory(dir=ROOT,prefix='d2_targeted_test_')
        self.addCleanup(tmp.cleanup);self.out=Path(tmp.name)
        self.cal=copy_native(self.out)
        # This is a historical D2 source review, not acceptance of a D3
        # successor. Reconstruct its pinned bytes, including saved predecessors,
        # and run the real strict verifier against that separate source tree.
        d3=ROOT/'docs/phase5/artifacts/5d3_demon_acceptance_20261018'
        parent=json.loads((d3/'before_source.json').read_text(encoding='utf-8'))
        assert parent['fingerprint']=='41dd8b30a899b8cf69b7a5aab1dba7b948dae29c4011fbf2b77826c142c65933'
        self.source_root=self.out/'frozen_d2_source'
        for name,sha in parent['files'].items():
            path=ROOT/name;raw=path.read_bytes()
            if hashlib.sha256(raw).hexdigest()!=sha:
                prior=ROOT/'docs/phase5/artifacts/5d3_demon_reasoning_20261018/before_source'/name
                if prior.exists():raw=prior.read_bytes()
                if hashlib.sha256(raw).hexdigest()!=sha:
                    raw=(d3/'before_source'/Path(name).name).read_bytes()
            assert hashlib.sha256(raw).hexdigest()==sha,name
            target=self.source_root/name;target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(raw)
        manifest=self.out/self.cal['source_manifest']['path']
        manifest.write_text(json.dumps(dict(fingerprint=parent['fingerprint'],files=parent['files'])),encoding='utf-8')
        self.cal['source_manifest']['sha256']=hashlib.sha256(manifest.read_bytes()).hexdigest()
        self.cal['runtime_sha256']=parent['fingerprint']
        self.original=copy.deepcopy(self.cal)
        self.saved={p.relative_to(self.out):p.read_bytes() for p in self.out.rglob('*') if p.is_file()}

    def reset(self):
        for name,raw in self.saved.items():(self.out/name).write_bytes(raw)
        self.cal=copy.deepcopy(self.original)

    def alter(self,ref,fn,*,lines=False):
        path=self.out/ref['path']
        value=([json.loads(l) for l in path.read_text(encoding='utf-8').splitlines()] if lines
            else json.loads(path.read_text(encoding='utf-8')))
        fn(value)
        raw=('\n'.join(json.dumps(r) for r in value)+'\n' if lines else json.dumps(value))
        path.write_text(raw,encoding='utf-8');ref['sha256']=hashlib.sha256(path.read_bytes()).hexdigest()

    def test_own_native_probe_accounts_all_rows_and_three_continuations(self):
        value=verify_native(self.out,self.cal)
        self.assertEqual((value['attempts'],value['swap_samples'],value['skill_samples']),(1,12,3))
        self.assertEqual((value['accounted_swap_spans'],value['excluded_terminal_swap_spans'],value['native_records']),(13,1,17))
        self.assertEqual([x['later_ack_turn'] for x in value['continuation_chains']],[17,21,29])
        self.assertEqual(value['I_ms'],4717.924)
        self.assertTrue(value['sample_maxima_not_future_bound'])
        self.assertEqual(value['witness']['boss'],[99,395523,485,250,535])

    def test_targeted_config_is_only_darkqueen_two_and_legacy_starburst_is_unchanged(self):
        raw=json.loads((self.out/self.cal['native']['request']['path']).read_text(encoding='utf-8'))
        config=replace(decode_config(raw['config']),target_completed_matches=2,max_match_attempts=2)
        check_config(config)
        for changes in (dict(boss_id='1289'),dict(boss_id='9999'),dict(pet_skill_fire_value=4),
                dict(target_completed_matches=3,max_match_attempts=3),dict(target_completed_matches=1,max_match_attempts=1)):
            with self.subTest(changes=changes),self.assertRaises(ValueError):check_config(replace(config,**changes))
        check_config(replace(config,boss_id='1289',target_completed_matches=3,max_match_attempts=3))

    def test_exact_source_boundary_preserves_every_native_execution_file(self):
        proof=verify_source_boundary(self.out,self.cal,self.source_root)
        self.assertTrue(proof['native_execution_files_byte_exact'])
        self.assertTrue(proof['legacy_d2_setup_ast_exact'])

    def test_d3_successor_cannot_reuse_historical_d2_source_authority(self):
        with self.assertRaisesRegex(ValueError,'native execution or unreviewed'):
            verify_source_boundary(self.out,self.cal,ROOT)

    def test_source_review_cannot_allow_an_extra_basic_policy_change(self):
        ref=self.cal['source_manifest'];value=json.loads((self.out/ref['path']).read_text(encoding='utf-8'))
        changed=dict(value['files']);changed['src/pokiguard_v2/basic_policy.py']='0'*64
        self.alter(ref,lambda v:v.update(files=changed,fingerprint=digest(changed)))
        self.cal['runtime_sha256']=digest(changed)
        with patch('pokiguard_v2.reasoning_calibration.source_files',return_value=changed),\
             patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value=digest(changed)):
            with self.assertRaisesRegex(ValueError,'native execution or unreviewed'):verify_source_boundary(self.out,self.cal,self.source_root)

    def test_changed_predecessor_loader_is_rejected_even_when_ref_rehashed(self):
        ref=self.cal['before_native_loader'];path=self.out/ref['path'];path.write_bytes(path.read_bytes()+b'\n')
        ref['sha256']=hashlib.sha256(path.read_bytes()).hexdigest()
        with self.assertRaisesRegex(ValueError,'predecessor'):verify_source_boundary(self.out,self.cal,self.source_root)

    def test_dropped_rows_or_watermark_loss_never_become_calibration(self):
        for change in (lambda v:v.update(collector_dropped=1),lambda v:v.update(flushed=False),
                lambda v:v['before_close'].update(written=16)):
            self.reset();self.alter(self.cal['native']['watermarks'],change)
            with self.assertRaises(ValueError):verify_native(self.out,self.cal)
        self.reset();self.alter(self.cal['native']['records'],lambda v:v.pop(0),lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_missing_ordinary_ack_is_not_covered_by_terminal_exclusion(self):
        def change(rows):
            index=next(i for i,r in enumerate(rows) if r['event']=='action_terminal' and r['result']=='SWAP_ACKNOWLEDGED')
            rows.pop(index)
        self.alter(self.cal['native']['combat'],change,lines=True)
        with self.assertRaisesRegex(ValueError,'swap/ACK'):verify_native(self.out,self.cal)

    def test_terminal_exception_needs_exact_reason_and_terminal_hp_evidence(self):
        def change(rows):
            r=next(r for r in rows if r['event']=='action_terminal' and r['result']=='ACTION_ABORTED_STATE_CHANGED')
            r['reason']='UNKNOWN'
        self.alter(self.cal['native']['combat'],change,lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)
        self.reset();self.alter(self.cal['native']['run'],lambda r:r['snapshot']['attempts'][0]['terminal_snapshot'].update(boss_hp=1))
        with self.assertRaisesRegex(ValueError,'terminal exclusion'):verify_native(self.out,self.cal)

    def test_wrong_clock_source_or_duration_rejected_after_rehash(self):
        for change in (dict(clock='host.monotonic'),dict(source_hash='0'*64),dict(full_primitive_ns=1)):
            self.reset()
            def mutate(rows):next(r['payload'] for r in rows if r['event_type']=='reasoning.skill_timing').update(change)
            self.alter(self.cal['native']['records'],mutate,lines=True)
            with self.subTest(change=change),self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_superceded_before_input_record_cannot_be_claimed_as_an_action(self):
        def mutate(rows):next(r['payload'] for r in rows if r['event_type']=='reasoning.decision_timing')['status']='RETURNED'
        self.alter(self.cal['native']['records'],mutate,lines=True)
        with self.assertRaisesRegex(ValueError,'pre-input'):verify_native(self.out,self.cal)

    def test_missing_continuation_or_foreign_session_ack_is_rejected(self):
        for kind in ('missing','foreign'):
            self.reset()
            def mutate(rows):
                if kind=='missing':
                    rows[:]=[r for r in rows if not (r['event']=='pet_skill_turn_resolved' and r['sourceTurn']==15 and r['kind']=='LOCAL_TURN_RETURNED')]
                else:
                    r=next(r for r in rows if r['event']=='action_terminal' and r['result']=='SWAP_ACKNOWLEDGED' and r['action']['identity']['source']['turn']==17)
                    r['action']['identity']['source']['session']['match_id']='FOREIGN'
            self.alter(self.cal['native']['combat'],mutate,lines=True)
            with self.subTest(kind=kind),self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_pet_source_or_cost_provenance_cannot_be_substituted(self):
        for change in (dict(pet_id=999),dict(effective_power_cost_source='UNKNOWN')):
            self.reset()
            def mutate(rows):
                for r in rows:
                    if r['event']=='pet_skill_capability_observed':r['capability'].update(change)
            self.alter(self.cal['native']['pet_skills'][0],mutate,lines=True)
            with self.subTest(change=change),self.assertRaisesRegex(ValueError,'source/cost'):verify_native(self.out,self.cal)

    def test_foreign_boss_witness_or_noncurrent_native_request_rejected(self):
        def mutate(rows):next(r['payload'] for r in rows if r['event_type']=='reasoning.swap_timing')['witness']['boss'][1]=84180
        self.alter(self.cal['native']['records'],mutate,lines=True)
        with self.assertRaisesRegex(ValueError,'cohort/witness'):verify_native(self.out,self.cal)
        self.reset();self.alter(self.cal['native']['request'],lambda r:r.update(source_sha256='0'*64))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)


if __name__=='__main__':unittest.main()
