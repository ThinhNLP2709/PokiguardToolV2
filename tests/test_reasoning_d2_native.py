"""Offline verification of existing D2 raw logs; never attaches to the game."""
import copy
import hashlib
import json
from pathlib import Path
import shutil
import tempfile
import unittest

from pokiguard_v2.reasoning_d2_native import verify_native,SCHEMA,check_remaining_attempt,check_config

ROOT=Path(__file__).resolve().parents[1]
ART=ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1'


def native_fixture(out):
    batches=[]
    for i,(base,manifest) in enumerate(((ART/'basic_control/relaunch_sword7_20261016_223657',ART/'source_freeze.json'),
            (ART/'skill_timing_probe_proposal',ART/'action_source_freeze.json'))):
        cal=base/'ui_session/basic_calibration'
        session=json.loads((cal/'session.json').read_text(encoding='utf-8'))
        farm=Path(session['farm_directory'])
        def cp(path,name):
            target=out/(str(i)+'_'+name);shutil.copyfile(path,target)
            return dict(path=target.name,sha256=hashlib.sha256(target.read_bytes()).hexdigest())
        batches.append(dict(request=cp(base/'request.json','request.json'),session=cp(cal/'session.json','session.json'),
            run=cp(farm/'run.json','run.json'),watermarks=cp(cal/'watermarks.json','watermarks.json'),
            records=cp(next(cal.glob('reasoning.*.jsonl')),'records.jsonl'),source_manifest=cp(manifest,'source.json'),
            pet_skills=[cp(p,'skill_'+str(n)+'.jsonl') for n,p in enumerate(sorted((farm/'matches').glob('*/pet_skill*.jsonl')))],
            combats=[cp(p,'combat_'+str(n)+'.jsonl') for n,p in enumerate(sorted((farm/'matches').glob('*/combat.jsonl')))]))
    return dict(schema=SCHEMA,batches=batches)


class D2NativeTests(unittest.TestCase):
    def test_remaining_one_requires_exact_closed_cap_and_never_grants_more_attempts(self):
        from dataclasses import replace
        from pokiguard_v2.reasoning_calibration import decode_config
        original=json.loads((ART/'basic_control/relaunch_sword7_20261016_223657/request.json').read_text(encoding='utf-8'))
        config=decode_config(original['config'])
        check_config(config);check_config(replace(config,target_completed_matches=1,max_match_attempts=1))
        for cap in (0,2,4):
            with self.assertRaises(ValueError):check_config(replace(config,target_completed_matches=cap,max_match_attempts=cap))
        base=ART/'reasoning_remediation_live_20261017_123439'
        ledger=json.loads((base/'attempt_ledger.json').read_text(encoding='utf-8'))
        closure=json.loads((base/'closure.json').read_text(encoding='utf-8'))
        def store(name,value):
            path=self.out/name;path.write_text(json.dumps(value),encoding='utf-8')
            return dict(path=name,sha256=hashlib.sha256(path.read_bytes()).hexdigest())
        def request(value):
            review=dict(scope='REMAINING_ONE_OF_AUTHORIZED_TEN',ledger=store('remaining_ledger.json',value),
                closure=store('closed_batch.json',closure))
            return dict(total_attempt_cap=1,remaining_attempt_review=store('remaining_review.json',review))
        check_remaining_attempt(self.out,request(ledger))
        for field,value in (('combined_started',8),('combined_authorized_cap',11),('remaining_authorized_attempts',2),('request_consumed',False)):
            with self.subTest(field=field):
                bad=dict(ledger);bad[field]=value
                with self.assertRaises(ValueError):check_remaining_attempt(self.out,request(bad))
        with self.assertRaises(KeyError):check_remaining_attempt(self.out,dict(total_attempt_cap=1))

    def setUp(self):
        self.temp=tempfile.TemporaryDirectory();self.addCleanup(self.temp.cleanup)
        self.out=Path(self.temp.name);self.cal=native_fixture(self.out)

    def alter(self,ref,fn,lines=False):
        p=self.out/ref['path']
        value=([json.loads(x) for x in p.read_text(encoding='utf-8').splitlines()] if lines
            else json.loads(p.read_text(encoding='utf-8')))
        fn(value)
        raw=('\n'.join(json.dumps(x) for x in value)+'\n' if lines else json.dumps(value))
        p.write_text(raw,encoding='utf-8');ref['sha256']=hashlib.sha256(p.read_bytes()).hexdigest()

    def test_all_three_controls_and_one_probe_revalidate_exactly(self):
        result=verify_native(self.out,self.cal)
        self.assertEqual((result['attempts'],result['skills'],result['swap_samples'],result['skill_samples']),(4,4,27,1))
        self.assertEqual(result['H_ms'],297.855)
        self.assertEqual(result['I_ms'],4688.1916)
        self.assertTrue(result['sample_maxima_not_future_bound'])

    def test_clock_source_duration_and_missing_skill_rejected_after_rehash(self):
        cases=(lambda p:p.update(clock='host.monotonic'),
            lambda p:p.update(source_hash='0'*64),lambda p:p.update(full_primitive_ns=1))
        original=copy.deepcopy(self.cal)
        for change in cases:
            with self.subTest(change=change):
                self.cal=native_fixture(self.out)
                def mutate(rows):
                    sample=next(x['payload'] for x in rows if x['event_type']=='reasoning.skill_timing');change(sample)
                self.alter(self.cal['batches'][1]['records'],mutate,lines=True)
                with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_dropped_diagnostics_or_unaccounted_attempt_rejected(self):
        self.alter(self.cal['batches'][1]['watermarks'],lambda x:x.update(collector_dropped=1))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)
        self.cal=native_fixture(self.out)
        self.alter(self.cal['batches'][0]['run'],lambda x:x['snapshot'].update(match_attempts=4))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_omitted_native_dispatch_cannot_be_covered_by_timing_claim(self):
        ref=self.cal['batches'][1]['combats'][0]
        self.alter(ref,lambda rows:rows.__setitem__(slice(None),[r for r in rows if r['event']!='pet_skill_dispatch_result']),lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_foreign_loadout_witness_cannot_be_pooled(self):
        def mutate(rows):
            x=next(r['payload'] for r in rows if r['event_type']=='reasoning.swap_timing')
            x['witness']['loadout']['config'][0]='normal'
        self.alter(self.cal['batches'][1]['records'],mutate,lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_same_skill_number_cannot_hide_a_different_pet_or_cost_source(self):
        def mutate(rows):
            for row in rows:
                if row['event']=='pet_skill_capability_observed':row['capability']['pet_id']=999
        self.alter(self.cal['batches'][1]['pet_skills'][0],mutate,lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)


if __name__=='__main__':unittest.main()
