"""Pinned files -> pre-input examples + separate observed component targets.

Includes acknowledged actions without effects and aborted inputs. Never reads
the game, infers missing damage, fits coefficients or changes the adviser.
"""
from collections import Counter, defaultdict
from copy import deepcopy
from pathlib import Path
import argparse
import hashlib
import json
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.damage_evaluation import (DATASET_SCHEMA,FEATURE_SCHEMA,TARGET,SETTINGS,GEMS,
    canonical,digest,validate_features,input_complete,dataset_identity,evaluate)
from pokiguard_v2.combat_outcome_evidence import actor_identity
from pokiguard_v2.board_simulator import SimulatedCell,SwapMove,_match_through,_tallies
from pokiguard_v2.demon_aegis import _swapped_grid,_passive_geometry
from pokiguard_v2.state import GemType
from tools.normalize_action_outcomes import extract,source_of,hash_value
from tools.audit_demon_damage_context import stats_context,full_power_state

MANIFEST_SCHEMA='pokiguard.damage_corpus_manifest.v1'
CASE_KEYS={'name','combat_path','combat_sha256','match_id','source_sha256','game_build_sha256',
    'account_sha256','cohort_id','seen_in_research'}


def read_json(path,limit=64*1024*1024):
    path=Path(path)
    if path.stat().st_size>limit:raise ValueError('BOUNDED_JSON_REQUIRED')
    raw=path.read_bytes()
    if len(raw)>limit:raise ValueError('BOUNDED_JSON_REQUIRED')
    return json.loads(raw)


def first_wave_features(board,move,target):
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in board)
    swap=SwapMove(*(tuple(p) for p in move));swapped=_swapped_grid(grid,swap)
    direct=_match_through(swapped,swap.first)|_match_through(swapped,swap.second)
    if not direct or grid[swap.first[0]][swap.first[1]].gem is grid[swap.second[0]][swap.second[1]].gem:
        raise ValueError('ILLEGAL_PRE_INPUT_SWAP')
    matched,blast,_,_=_passive_geometry(grid,swap,GemType(target))
    tally=_tallies(swapped,direct|set(blast))
    return dict(status='KNOWN',passive_triggered=bool(matched),
        physical={g:tally.cells(GemType(g)) for g in sorted(GEMS)},
        effective={g:tally.effective(GemType(g)) for g in sorted(GEMS)},
        scope='FIRST_WAVE_ONLY_NO_REFILL_OR_CASCADE')


def pre_features(sent,config):
    move=deepcopy(sent['identity']['target']);s=source_of(sent)
    if (sent.get('selectedAction')!='swap' or sent['identity'].get('action')!='swap'
            or sent.get('boardSnapshotOrder')!='screen_rows_top_to_bottom_columns_left_to_right'
            or sent.get('turn')!=s['turn'] or type(sent.get('move')) is not dict
            or [sent['move'].get('first'),sent['move'].get('second')]!=move):
        raise ValueError('PRE_INPUT_ACTION_OR_BOARD_BINDING')
    f=dict(schema=FEATURE_SCHEMA,board=deepcopy(sent.get('boardSnapshot')),move=move,
        self_stats=stats_context(sent,'player')['observed'],boss_stats=stats_context(sent,'boss')['observed'],
        settings={k:config.get(k) for k in sorted(SETTINGS)},first_wave=dict(status='UNKNOWN',reason='NOT_EVALUATED'))
    try:
        validate_features(f)
    except (ValueError,TypeError):
        # No unvalidated raw board or stats enter the feature contract.
        f['board']=None
        validate_features(f)
    if f['board'] is not None:
        try:f['first_wave']=first_wave_features(f['board'],move,config['demon_target_gem'])
        except (ValueError,TypeError,KeyError):f['first_wave']=dict(status='UNKNOWN',reason='NO_VERIFIED_FIRST_WAVE')
    validate_features(f)
    return f


def target_observation(obs,execution):
    result=dict(kind=TARGET,status='MISSING_TYPED_RESPONSE',amount=None,whole_action_coverage='UNKNOWN',
        damage_components=[],response_sequence=None,raw_response_sha256=None,
        full_power_states=[],post_response_context_used_as_feature=False)
    if execution!='ACKNOWLEDGED':result['status']='NO_EXACT_ACK';return result
    if obs is None:return result
    result.update(response_sequence=obs['server_sequence'],raw_response_sha256=obs['provenance']['raw_response_sha256'])
    damage=[s for s in obs['steps'] if s['kind']=='DAMAGE' and s['source']==obs['actor_identity'] and s['target']=='BOSS']
    if not damage:result['status']='NO_RECORDED_COMPONENT';return result
    if any(s['amount']<0 for s in damage):result['status']='INVALID_COMPONENT';return result
    result.update(status='CENSORED_TARGET' if 'BOSS' in obs['zero_hp_targets'] else 'RECORDED_COMPONENT',
        amount=sum(s['amount'] for s in damage),damage_components=[dict(index=s['idx'],amount=s['amount'],damage_source=s.get('damage_source')) for s in damage],
        full_power_states=[full_power_state(s) for s in damage])
    return result


def build_case(case):
    if type(case) is not dict or set(case)!=CASE_KEYS or any(not hash_value(case[k]) for k in (
            'combat_sha256','source_sha256','game_build_sha256','account_sha256')) or type(case['seen_in_research']) is not bool:
        raise ValueError('PINNED_CASE_MANIFEST_REQUIRED')
    for k in ('name','match_id','cohort_id'):
        if type(case[k]) is not str or not 0<len(case[k])<=256:raise ValueError('CASE_SCOPE_FIELDS')
    path=Path(case['combat_path']);path=path if path.is_absolute() else ROOT/path
    if path.stat().st_size>64*1024*1024:raise ValueError('BOUNDED_COMBAT_REQUIRED')
    raw=path.read_bytes()
    if len(raw)>64*1024*1024 or hashlib.sha256(raw).hexdigest()!=case['combat_sha256']:
        raise ValueError('COMBAT_FILE_PIN_MISMATCH')
    rows={n:json.loads(s) for n,s in enumerate(raw.decode('utf-8-sig').splitlines(),1) if s.strip()}
    configs=[r.get('config') for r in rows.values() if r.get('event')=='auto_controller_started']
    if (len(configs)!=1 or type(configs[0]) is not dict or configs[0].get('play_style')!='demon_aegis_farm'
            or configs[0].get('damage_card')!='pet_passive' or configs[0].get('demon_target_gem') not in GEMS-{'sword'}):
        raise ValueError('ONE_DECLARED_DEMON_PASSIVE_CONFIGURATION_REQUIRED')
    config=configs[0];normalized=extract(path)
    if normalized['sha256']!=case['combat_sha256']:raise ValueError('INPUT_CHANGED_DURING_BUILD')
    by_line=defaultdict(list)
    for o in normalized['observations']:
        binding=o['action_binding']
        if binding.get('action_line') is not None:by_line[binding['action_line']].append(o)
    results=[r for r in rows.values() if r.get('event')=='action_result'];samples=[];excluded=[]
    for line,sent in rows.items():
        if sent.get('event')!='action_sent':continue
        try:
            s=source_of(sent)
            if s['session']['match_id']!=case['match_id'] or actor_identity(s['current_turn_player'])!='sha256:'+case['account_sha256']:
                raise ValueError('DECLARED_MATCH_OR_OWNED_ACTOR_MISMATCH')
            f=pre_features(sent,config)
            outcomes={r.get('result') for r in results if type(r.get('action')) is dict and r['action'].get('identity')==sent['identity']}
            execution=('CONFLICTING_RESULTS' if 'SWAP_ACKNOWLEDGED' in outcomes and len(outcomes)>1 else
                'ACKNOWLEDGED' if 'SWAP_ACKNOWLEDGED' in outcomes else 'UNACKNOWLEDGED')
            observations=by_line.get(line,[])
            obs=observations[0] if len(observations)==1 and observations[0]['action_binding']['status']=='EXACT_SWAP_SENT_ACK' else None
            identity=dict(match_id=case['match_id'],actor_identity=actor_identity(s['current_turn_player']),
                source_sequence=s['srv_seq'],turn=s['turn'],board_hash=s['board_hash'],critical_state_hash=s['critical_state_hash'],move=f['move'])
            samples.append(dict(sample_id=digest(identity),match_id=case['match_id'],cohort_id=case['cohort_id'],
                group_id=digest(dict(match_id=case['match_id'],cohort_id=case['cohort_id'],build=case['game_build_sha256'],account=case['account_sha256'])),
                seen_in_research=case['seen_in_research'],execution_status=execution,features=f,feature_sha256=digest(f),
                input_complete=input_complete(f),target_observation=target_observation(obs,execution),
                scope=dict(source_sha256=case['source_sha256'],game_build_sha256=case['game_build_sha256'],
                    account_sha256=case['account_sha256'],cohort_origin='MANIFEST_DECLARATION_NOT_COMPLETE_RUNTIME_LOADOUT'),
                provenance=[dict(path=str(path.resolve()),sha256=case['combat_sha256'],action_line=line,action_identity=identity)],
                training_eligible=False,calibration_eligible=False,input_authority=False))
        except (ValueError,KeyError,TypeError) as exc:excluded.append(dict(line=line,reason=str(exc)[:100]))
    if hashlib.sha256(path.read_bytes()).hexdigest()!=case['combat_sha256']:raise ValueError('INPUT_CHANGED_DURING_BUILD')
    return dict(name=case['name'],samples=samples,excluded=excluded,
        pass_wait_records=sum(r.get('event')=='pass_wait_started' for r in rows.values()),
        normalization_exclusions=normalized['excluded'])


def build(manifest):
    if (type(manifest) is not dict or set(manifest)!={'schema','cases'} or manifest['schema']!=MANIFEST_SCHEMA
            or type(manifest['cases']) is not list or not 1<=len(manifest['cases'])<=256):
        raise ValueError('PINNED_CORPUS_MANIFEST_REQUIRED')
    cases=[build_case(c) for c in manifest['cases']];unique={};conflicts=set();duplicates=0
    for case in cases:
        for s in case['samples']:
            key=s['sample_id'];semantic={k:v for k,v in s.items() if k!='provenance'}
            if key in unique:
                duplicates+=1
                if {k:v for k,v in unique[key].items() if k!='provenance'}!=semantic:conflicts.add(key)
                else:
                    for ref in s['provenance']:
                        if ref not in unique[key]['provenance']:unique[key]['provenance'].append(ref)
            else:unique[key]=deepcopy(s)
    samples=sorted((s for k,s in unique.items() if k not in conflicts),key=lambda s:(s['match_id'],s['provenance'][0]['action_identity']['turn']))
    result=dict(schema=DATASET_SCHEMA,target=TARGET,samples=samples,
        summary=dict(files=len(cases),actions=len(samples),matches=len({s['match_id'] for s in samples}),
            executions=dict(Counter(s['execution_status'] for s in samples)),targets=dict(Counter(s['target_observation']['status'] for s in samples)),
            complete_pre_inputs=sum(s['input_complete'] for s in samples),duplicates=duplicates,conflicting_actions=len(conflicts),
            excluded_actions=sum(len(c['excluded']) for c in cases),pass_wait_records=sum(c['pass_wait_records'] for c in cases)),
        file_diagnostics=[{k:v for k,v in c.items() if k!='samples'} for c in cases],manifest_sha256=digest(manifest),
        independent_holdout=False,training_eligible=False,input_authority=False,models_fitted=0,training=False,
        target_scope='RECORDED_COMPONENT_ONLY_NOT_WHOLE_ACTION_DAMAGE_OR_KILL',post_response_features=False)
    result['dataset_sha256']=dataset_identity(result)
    return result


def write_new(path,value):
    path=Path(path).resolve()
    if not path.is_relative_to(ROOT):raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2,allow_nan=False)


def main():
    p=argparse.ArgumentParser(__doc__);sub=p.add_subparsers(dest='command',required=True)
    b=sub.add_parser('build');b.add_argument('--manifest',type=Path,required=True);b.add_argument('--out',type=Path,required=True)
    e=sub.add_parser('evaluate');e.add_argument('--dataset',type=Path,required=True);e.add_argument('--predictions',type=Path,required=True)
    e.add_argument('--partition-plan',type=Path,required=True);e.add_argument('--out',type=Path,required=True)
    a=p.parse_args()
    if a.command=='build':result=build(read_json(a.manifest));summary=result['summary']
    else:
        result=evaluate(read_json(a.dataset),read_json(a.predictions),read_json(a.partition_plan))
        summary={k:v for k,v in result.items() if k not in ('rows','groups')}
    write_new(a.out,result);print(json.dumps(summary))


if __name__=='__main__':main()
