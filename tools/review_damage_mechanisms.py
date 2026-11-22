"""Pinned files -> separate pre-input mechanisms and post-response diagnostics.

No fit, target correction, causal step attribution, process access or input.
"""
from collections import Counter
from copy import deepcopy
from pathlib import Path
import argparse
import hashlib
import json
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.damage_action_context import describe_action
from pokiguard_v2.damage_evaluation import prediction_request
from pokiguard_v2.damage_operation_context import SCHEMA as OPERATION_SCHEMA
from tools.prepare_demon_damage_dataset import build, read_json, write_new
from tools.audit_damage_sequences import analyze
from tools.normalize_action_outcomes import extract


def response_key(value):
    return tuple(value[k] for k in ('match_id', 'event_type', 'server_sequence', 'raw_sha256'))


def operation_contexts(path):
    """An exact response identity only; never join by time or nearby sequence."""
    result = {}
    for text in path.read_text(encoding='utf-8-sig').splitlines():
        if not text.strip(): continue
        row = json.loads(text); parent = row.get('combatOutcome')
        if type(parent) is not dict or 'damage_operations' not in parent: continue
        context = parent['damage_operations']
        identity = parent.get('evidence') or parent.get('response_identity')
        if (type(context) is not dict or context.get('schema') != OPERATION_SCHEMA
                or context.get('calibration_eligible') is not False
                or context.get('input_authority') is not False or identity is None
                or response_key(context) != response_key(identity)):
            raise ValueError('OPERATION_CONTEXT_IDENTITY_OR_SCOPE')
        if (context.get('status') == 'CAPTURED' and parent.get('evidence') is not None
                and context.get('response_actor_identity') != identity['actor_identity']):
            raise ValueError('OPERATION_CONTEXT_ACTOR_MISMATCH')
        key = response_key(context)
        if key in result and result[key] != context:
            raise ValueError('CONFLICTING_OPERATION_CONTEXT')
        result[key] = context
    return result


def ratio_support(descriptor, target, diagnostic, context):
    """Explain why a response/known-sword ratio is descriptive, not causal.

    Post-response counts/crit must never enter the pre-input request or become
    an implicit correction to an observed target. In particular, division by
    a known prefix does not attribute damage from unknown later waves to it.
    """
    prefix=descriptor.get('known_prefix');known=None if prefix is None else prefix['effective']['sword']
    reported=None if diagnostic is None or diagnostic['post_response_tags'] is None else diagnostic['post_response_tags'].get('sword')
    flags=[];critical=[]
    if context is not None and context.get('status')=='CAPTURED':
        critical=[dict(operation_index=o['operation_index'],type=o['type'],presence=o['crit_presence'],value=o['crit_value'])
            for o in context['operations'] if o['type']=='BOSS_HP']
    if target['status']!='RECORDED_COMPONENT':flags.append('NO_RECORDED_UNCENSORED_COMPONENT')
    if not known:flags.append('NO_KNOWN_PREFIX_SWORDS')
    if reported is None:flags.append('POST_SWORD_TAG_COUNT_UNKNOWN')
    elif known is not None and reported!=known:flags.append('POST_SWORD_TAG_COUNT_DIFFERS_FROM_KNOWN_PREFIX')
    if any(c['presence']=='BOOL' and c['value'] is True for c in critical):flags.append('CRITICAL_OPERATION_OBSERVED_NOT_STEP_ATTRIBUTED')
    # Missing crit is UNKNOWN, including when a fullPower step was present.
    if not critical or any(c['presence']!='BOOL' for c in critical):flags.append('CRITICAL_STATE_UNKNOWN_FOR_ONE_OR_MORE_BOSS_HP_OPERATIONS')
    if diagnostic is not None and diagnostic['multiple_destroy_operations_observed']:flags.append('MULTIPLE_DESTROY_OPERATIONS_NOT_COMPLETE_REFILL_TRAJECTORY')
    amount=target['amount'] if target['status']=='RECORDED_COMPONENT' else None
    return dict(known_prefix_swords=known,reported_post_sword_tags=reported,
        post_tag_units='RAW_AGGREGATED_TAG_COUNTS_NOT_WAVE_ATTRIBUTION',
        recorded_component=amount,descriptive_component_per_known_sword=amount/known if amount is not None and known else None,
        flags=flags,boss_hp_crit_observations=critical,full_power_states=target['full_power_states'],
        ratio_causal_attribution='UNKNOWN',clean_per_sword_coefficient_established=False,
        pre_input_feature=False,training_target_rewritten=False,input_authority=False)


def review(manifest):
    dataset = build(manifest); observations = {}; contexts = {}; pins = {}
    for case in manifest['cases']:
        path = Path(case['combat_path']); path = path if path.is_absolute() else ROOT/path
        normalized = extract(path)
        if normalized['sha256'] != case['combat_sha256']:
            raise ValueError('RAW_INPUT_PIN_CHANGED')
        pins[str(path.resolve())] = case['combat_sha256']
        contexts[str(path.resolve())] = operation_contexts(path)
        for obs in normalized['observations']:
            line = obs['action_binding'].get('action_line')
            if line is not None: observations[str(path.resolve()), line] = obs
    records = []
    for sample in dataset['samples']:
        request = prediction_request(sample)
        descriptor = describe_action(request)
        candidates = []
        for ref in sample['provenance']:
            obs = observations.get((ref['path'], ref['action_line']))
            if obs is not None: candidates.append((ref['path'], obs))
        post = dict(status='NO_UNIQUE_TYPED_RESPONSE', target=deepcopy(sample['target_observation']),
                    diagnostic=None, critical_operation_context=None, local_power_operations=[])
        if candidates and len({o['provenance']['raw_response_sha256'] for _, o in candidates}) == 1:
            path, obs = candidates[0]
            diagnostic = analyze(sample, obs)
            key = (obs['match_id'], obs['event_type'], obs['server_sequence'], obs['provenance']['raw_response_sha256'])
            ctx = contexts[path].get(key)
            local_power = [o for o in obs.get('resource_operations') or []
                if o['type'] == 'STAT_CHANGE' and o.get('stat_type') == 'POWER'
                and o.get('target') == obs['actor_identity']]
            prefix = descriptor.get('known_prefix')
            observed = diagnostic['post_response_tags']
            first = sample['features']['first_wave']
            post.update(status='EXACT_TYPED_SEQUENCE_NOT_WHOLE_ACTION', diagnostic=diagnostic,
                critical_operation_context=ctx, local_power_operations=local_power,
                prefix_counts_match_observed_tags=(prefix['effective'] == observed)
                    if prefix is not None and observed is not None else None,
                first_wave_sword_count_matches_tags=(first['effective']['sword'] == observed['sword'])
                    if first['status'] == 'KNOWN' and observed is not None else None,
                known_prefix_sword_count_matches_tags=(prefix['effective']['sword'] == observed['sword'])
                    if prefix is not None and observed is not None else None,
                response_crit_status='NOT_RECORDED_IN_LEGACY_CAPTURE' if ctx is None else ctx['status'],
                post_response_used_as_feature=False)
        records.append(dict(sample_id=sample['sample_id'], match_id=sample['match_id'],
            turn=sample['provenance'][0]['action_identity']['turn'], scope=sample['scope'],
            execution_status=sample['execution_status'], pre_input=descriptor, post_response=post,
            ratio_support=ratio_support(descriptor,sample['target_observation'],post['diagnostic'],post['critical_operation_context']),
            calibration_eligible=False, input_authority=False))
    for name, expected in pins.items():
        if hashlib.sha256(Path(name).read_bytes()).hexdigest() != expected:
            raise ValueError('RAW_INPUT_CHANGED_DURING_REVIEW')
    known = [r for r in records if r['pre_input']['known_prefix'] is not None]
    return dict(schema='pokiguard.damage_mechanism_review.v1', dataset_sha256=dataset['dataset_sha256'],
        summary=dict(actions=len(records), descriptor_statuses=dict(Counter(r['pre_input']['status'] for r in records)),
            targets=dict(Counter(r['post_response']['target']['status'] for r in records)),
            coverage=dict(Counter(r['pre_input']['known_prefix']['coverage'] for r in known)),
            known_cascade_sword_actions=sum(r['pre_input']['known_ordinary_cascade_effective_swords'] > 0 for r in known),
            zero_first_wave_with_known_cascade_swords=sum(r['pre_input']['known_ordinary_cascade_effective_swords'] > 0
                and r['pre_input']['first_wave_sweep_effective_swords'] == r['pre_input']['first_wave_direct_effective_swords'] == 0 for r in known),
            later_passive_unmodeled=sum(r['pre_input']['known_prefix']['later_passive_unmodeled'] for r in known),
            ratio_support_flags=dict(Counter(flag for r in records for flag in r['ratio_support']['flags']))),
        records=records, input_sha256=pins, new_game_inputs=0, process_attachment=False, models_fitted=0,
        target_rewritten=False, whole_action_damage_forecast=False, calibration_eligible=False, input_authority=False)


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--manifest', type=Path, required=True); p.add_argument('--out', type=Path, required=True)
    args = p.parse_args(); result = review(read_json(args.manifest)); write_new(args.out, result)
    print(json.dumps(result['summary']))


if __name__ == '__main__': main()
