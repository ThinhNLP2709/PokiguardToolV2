"""Pinned response/ACK shield ledger, operation alignment and wave diagnostics.

All post-response fields remain diagnostic. No new target, damage formula,
step-subtype attribution, future feature, fitting, process access or input.
"""
from collections import Counter,defaultdict
from pathlib import Path
import argparse,json,sys,hashlib
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from tools.prepare_demon_damage_dataset import build,read_json,write_new
from tools.normalize_action_outcomes import extract
from pokiguard_v2.live_state import gem_for_tag
from pokiguard_v2.state import GemType


def analyze(sample,observation):
    f=sample['features'];w=f['first_wave'];steps=observation['steps']
    if (sample['match_id']!=observation['match_id'] or observation['actor_identity']=='BOSS'
            or observation['action_binding'].get('action_line') not in {p['action_line'] for p in sample['provenance']}):
        raise ValueError('EXACT_SAMPLE_OBSERVATION_REQUIRED')
    declared=sample['target_observation']['raw_response_sha256']
    if declared is not None and declared!=observation['provenance']['raw_response_sha256']:
        raise ValueError('RESPONSE_RAW_HASH_MISMATCH')
    observed=None;tag_status='MISSING_OR_UNVERIFIED_TAGS';tags=observation.get('destroyed_by_tag')
    if type(tags) is dict:
        observed={g:0 for g in w.get('physical',{})}
        for tag,n in tags.items():
            gem=gem_for_tag(tag)
            if gem is GemType.UNKNOWN or type(n) is not int or n<0 or gem.value not in observed:
                observed=None;break
            observed[gem.value]+=n
        if observed is not None and w['status']=='KNOWN':
            tag_status=('MATCHES_EFFECTIVE_FIRST_WAVE' if observed==w['effective'] else
                'MATCHES_PHYSICAL_FIRST_WAVE' if observed==w['physical'] else 'DIFFERS_FROM_FIRST_WAVE')
    operations=observation.get('resource_operations')
    destroys=[dict(operation_index=o['operation_index'],position_count=len(o['native_positions']) if o['native_positions'] is not None else None,
        position_status=o.get('positions_status'),unmodeled_trailing_values=o.get('unmodeled_trailing_values')) for o in operations or [] if o['type']=='DESTROY']
    blocks=[s for s in steps if s['kind']=='BLOCK' and s['source']==observation['actor_identity'] and s['target']=='BOSS']
    alignments=[]
    for b in blocks:
        after=(b.get('after') or {}).get('SHIELD')
        matches=[o for o in operations or [] if o['type']=='STAT_CHANGE' and o.get('target')=='BOSS'
            and o.get('stat_type')=='SHIELD' and o.get('source_label')=='BLOCK' and type(after) is int
            and o.get('delta')==-b['amount'] and o.get('new_value')==after]
        alignments.append(dict(step_index=b['idx'],amount=b['amount'],after_shield=after,
            status='UNIQUE_VALUE_SIGNATURE' if len(matches)==1 else 'AMBIGUOUS_OR_MISSING',
            candidate_operation_indices=[o['operation_index'] for o in matches]))
    mapped=[a['candidate_operation_indices'][0] for a in alignments if a['status']=='UNIQUE_VALUE_SIGNATURE']
    ordered=(len(mapped)==len(alignments) and len(set(mapped))==len(mapped) and mapped==sorted(mapped))
    damage=[]
    for i,s in enumerate(steps):
        if s['kind']!='DAMAGE' or s['source']!=observation['actor_identity'] or s['target']!='BOSS':continue
        prior=steps[i-1] if i else None
        adjacent=(prior is not None and prior['idx']+1==s['idx'] and prior['kind']=='BLOCK'
            and prior['source']==s['source'] and prior['target']==s['target'] and prior['amount']>=0)
        damage.append(dict(step_index=s['idx'],recorded_hp_component=s['amount'],after_hp=(s.get('after') or {}).get('HP'),
            damage_source=s.get('damage_source'),full_power=s.get('full_power'),
            adjacent_block_index=prior['idx'] if adjacent else None,adjacent_block_amount=prior['amount'] if adjacent else None,
            arithmetic_hp_plus_adjacent_block=s['amount']+prior['amount'] if adjacent else None,
            attribution_status='ADJACENCY_ONLY_NOT_A_VERIFIED_ATTACK_COMPONENT_PAIR' if adjacent else 'NO_ADJACENT_BLOCK'))
    native=observation.get('swap_operations');expected=[7-f['move'][0][0],f['move'][0][1],7-f['move'][1][0],f['move'][1][1]]
    swap_agrees=(native[0]['native_swap']==expected) if native is not None and len(native)==1 else None
    return dict(sample_id=sample['sample_id'],match_id=sample['match_id'],source_turn=sample['provenance'][0]['action_identity']['turn'],
        response_sequence=observation['server_sequence'],raw_response_sha256=observation['provenance']['raw_response_sha256'],
        execution_status=sample['execution_status'],binding_status=observation['action_binding']['status'],
        first_wave=f['first_wave'],post_response_tags=observed,tag_comparison=tag_status,destroy_operations=destroys,
        multiple_destroy_operations_observed=len(destroys)>1,swap_agrees_with_observed_row_flip=swap_agrees,
        coordinate_transform_status='OBSERVATIONAL_DIAGNOSTIC_NOT_RUNTIME_ADMISSION_OR_NEW_BINDING',
        pre_boss_shield=None if f['boss_stats'] is None else f['boss_stats']['shield'],
        shield_raw_ledger=[r for r in observation['raw_ledger'] if r.get('field')=='SHIELD' and r['target']=='BOSS'],
        block_stat_alignments=alignments,aligned_order_consistent=ordered if alignments else None,
        full_power_stat_operations=[dict(index=o['operation_index'],delta=o.get('delta'),new_value=o.get('new_value')) for o in operations or []
            if o['type']=='STAT_CHANGE' and o.get('reason')=='FULL_POWER'],damage_components=damage,
        crit_status='NOT_RECORDED_IN_LEGACY_OPERATION_PROJECTION',cross_list_causality='UNKNOWN',
        before_action_features_added=False,whole_action_complete=False,training_target_rewritten=False,calibration_eligible=False,input_authority=False)


def audit(manifest):
    dataset=build(manifest);observations={};pins={}
    for c in manifest['cases']:
        p=Path(c['combat_path']);p=p if p.is_absolute() else ROOT/p
        result=extract(p)
        if result['sha256']!=c['combat_sha256']:raise ValueError('RAW_INPUT_PIN_CHANGED')
        pins[str(p.resolve())]=c['combat_sha256']
        for o in result['observations']:
            b=o['action_binding']
            if b.get('action_line') is not None:observations[str(p.resolve()),b['action_line']]=o
    records=[];missing=[]
    for s in dataset['samples']:
        candidates=[]
        for p in s['provenance']:
            o=observations.get((p['path'],p['action_line']))
            if o is not None:candidates.append(o)
        if not candidates:
            missing.append(dict(sample_id=s['sample_id'],match_id=s['match_id'],status='NO_UNIQUE_TYPED_ACTION_RESPONSE'));continue
        if len({o['provenance']['raw_response_sha256'] for o in candidates})!=1:
            missing.append(dict(sample_id=s['sample_id'],match_id=s['match_id'],status='CONFLICTING_TYPED_ACTION_RESPONSE'));continue
        records.append(analyze(s,candidates[0]))
    for p,h in pins.items():
        if hashlib.sha256(Path(p).read_bytes()).hexdigest()!=h:raise ValueError('RAW_INPUT_CHANGED_DURING_AUDIT')
    return dict(scope='POST_RESPONSE_SHIELD_ORDER_AND_WAVE_DIAGNOSTICS_NOT_FEATURES_OR_DAMAGE_FORMULA',
        dataset_sha256=dataset['dataset_sha256'],records=records,missing=missing,
        summary=dict(actions=len(dataset['samples']),typed_sequences=len(records),missing=len(missing),
            tag_comparison=dict(Counter(r['tag_comparison'] for r in records)),
            multiple_destroy_sequences=sum(r['multiple_destroy_operations_observed'] for r in records),
            block_sequences=sum(bool(r['block_stat_alignments']) for r in records),
            all_block_alignments_unique_and_ordered=sum(r['aligned_order_consistent'] is True for r in records),
            adjacent_block_damage_pairs=sum(d['adjacent_block_amount'] is not None for r in records for d in r['damage_components'])),
        input_sha256=pins,new_game_inputs=0,process_attachment=False,models_fitted=0,training_target_rewritten=False)


def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--manifest',type=Path,required=True);p.add_argument('--out',type=Path,required=True)
    a=p.parse_args();result=audit(read_json(a.manifest));write_new(a.out,result);print(json.dumps(result['summary']))


if __name__=='__main__':main()
