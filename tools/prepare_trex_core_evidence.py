"""Legacy T-Rex click logs -> offline common-core inputs, never skill targets.

No memory reads, game input, fitting or current-build/native authority. Missing
fresh contexts, response effects and historical source/build remain UNKNOWN.
"""
from collections import Counter
from copy import deepcopy
import argparse
import json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.combat_board_evidence import valid_screen_board, semantic_board_hash
from pokiguard_v2.combat_outcome_evidence import actor_identity
from pokiguard_v2.mega_icarus import mega_seal_for_type,count_seal_gems
from pokiguard_v2.reasoning_common_models import RESOURCE_DECLARATION
from pokiguard_v2.reasoning_common_problem import CommonProblem,CommonIntent,EffectChoice,VERSION
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_planner import order_key
from pokiguard_v2.reasoning_snapshot import Action,FrozenJSON,SourceIdentity,SourceRecord,canonical_json,digest,require
from pokiguard_v2.state import GemType
from tools.audit_active_skill_inventory import read_rows,sha_file,analyze_rows,combat_index,controller_join
from tools.compare_same_state_decisions import compare,project_action
from tools.prepare_icarus_core_evidence import stats

SCHEMA='pokiguard.trex_common_core_evidence.v1'


def pre_view(row):
    trace=row.get('trace') or {}
    return dict(board=row.get('boardSnapshot'),player=row.get('player'),boss=row.get('boss'),
        selected=row.get('selectedAction'),profile=row.get('playStyle'),skill={k:trace.get(k) for k in (
            'skill_ready','skill_actionable','skill_capability_status','required_mana','required_rage',
            'current_mana','current_rage','skill_family','skill_source',
            'pet_skill_fire_condition','pet_skill_fire_value','fire_condition_scope')})


def pre_problem(record,capability,rows,config,*,run_id,combat_sha256):
    """Reconstruct only uniquely agreeing pre-policy rows and pre-click card."""
    by_line=dict(rows)
    start=by_line[record['controller_start_line']]
    identity=start.get('identity') or {};source=identity.get('source') or {}
    require(record['logged_click_card_cost_join'] and record['controller_join_verified'], 'EXACT_LOGGED_CLICK_REQUIRED')
    require(capability.get('status')=='CURRENT' and capability.get('ownership_current') is True
        and capability.get('skill_family')=='MEGA_TREX_CLICK_ONLY'
        and capability.get('element_type')=='MEGA_TREX'
        and capability.get('session_key')==source.get('session')
        and capability.get('skill_card_id')==record['skill_card_id'], 'CURRENT_TREX_CARD_REQUIRED')
    require(capability.get('effective_mana_cost_source')=='CONDITION_USE'
        and capability.get('effective_power_cost_source')=='POWER', 'KNOWN_COST_SOURCES_REQUIRED')
    costs=[capability.get('effective_mana_cost'),capability.get('effective_power_cost')]
    require(all(type(n) is int and n>=0 for n in costs) and costs==record['effective_cost'], 'COST_CONFLICT')
    require(config.get('play_style')=='mega_icarus_spam_skill' and config.get('main_pet')=='normal'
        and config.get('evolution_target')=='mega' and config.get('damage_card')=='pet_skill', 'LEGACY_ROUTE_NOT_VERIFIED')
    decisions=[(line,row) for line,row in rows if line<record['controller_start_line']
        and row.get('event')=='policy_decision' and row.get('session')==source.get('session')
        and row.get('turn')==source.get('turn') and row.get('srvSeq')==source.get('srv_seq')
        and row.get('boardHash')==source.get('board_hash')]
    require(bool(decisions), 'PRE_POLICY_BOARD_MISSING')
    require(len({digest(pre_view(row)) for _,row in decisions})==1, 'CONFLICTING_PRE_POLICY_STATE')
    line,decision=decisions[-1]
    view=pre_view(decision);trace=decision['trace'];board=view['board'];own=view['player'];boss=view['boss']
    require(valid_screen_board(board) and decision.get('boardSnapshotOrder')=='screen_rows_top_to_bottom_columns_left_to_right',
        'PRE_BOARD_DOMAIN_OR_ORDER')
    require(view['selected']=='pet_skill' and trace.get('skill_ready') is True
        and trace.get('skill_actionable') is True and trace.get('skill_capability_status')=='CURRENT'
        and trace.get('skill_family')=='MEGA_TREX_CLICK_ONLY'
        and trace.get('fire_condition_scope')=='MEGA_TREX_SEAL_30', 'POLICY_SKILL_SCOPE_CONFLICT')
    require(own.get('is_local') is True and own.get('is_boss') is False
        and boss.get('is_boss') is True and boss.get('is_local') is False, 'PRE_ACTOR_OWNERSHIP')
    require([own.get('mana'),own.get('power')]==record['resources_before']
        and [start.get('currentMana'),start.get('currentRage')]==record['resources_before']
        and [trace.get('current_mana'),trace.get('current_rage')]==record['resources_before']
        and costs==[trace.get('required_mana'),trace.get('required_rage')]
        and own['mana']>=costs[0] and own['power']>=costs[1], 'PRE_RESOURCES_OR_COST_CONFLICT')
    for d in (own,boss):
        require(all(type(d.get(k)) is int and d[k]>=0 for k in ('hp','max_hp','mana','max_mana','power','max_power','attack','shield')),
            'PRE_STATS_INCOMPLETE')
    require(trace.get('skill_source')=='EVOLUTION_TARGET', 'PRE_EVOLUTION_SOURCE_UNVERIFIED')
    require(config.get('pet_skill_fire_condition')==trace.get('pet_skill_fire_condition')
        and config.get('pet_skill_fire_value')==trace.get('pet_skill_fire_value'), 'CONFIG_AND_TRACE_CONFLICT')
    settings={k:config.get(k) for k in ('play_style','main_pet','damage_card','game_mode','pet_skill_fire_condition','pet_skill_fire_value')}
    settings.update(evolution=config['evolution_target'],intelligence='basic',
        mega_self_protection=config.get('mega_self_protection'))
    action=Action('pet_skill',card_source=canonical_json(dict(session=source['session'],card_id=record['skill_card_id'])))
    seal=mega_seal_for_type('MEGA_TREX')
    effect=EffectChoice(action,True,'LEGACY_PRE_CLICK_OWNED_TREX_CARD_REPLAY_ONLY',seal.cells,
        'B15_CONDITIONAL_MEGA_SEAL_FIRST_WAVE','CONDITIONAL_MODEL',costs[0],costs[1],FrozenJSON.of(dict(
            source_binding='CURRENT_OWNED_MEGA_SEAL_CARD',skill_card_id=record['skill_card_id'],seal_element_type='MEGA_TREX',
            actual_costs=dict(mana=costs[0],rage=costs[1]),
            self_heal_present=False,self_heal_provenance=None,self_heal_knowledge='UNKNOWN_NOT_CREDITED',
            fusion_lifesteal_knowledge='UNKNOWN_NO_ORDERED_EFFECTS',post_cost_gain_order='UNKNOWN',
            QTE_executor='UNCHANGED_EXISTING_OWNER')))
    facts=dict(root_allowed=True,pending=False,self=stats(own),opponent=stats(boss),
        conversion=dict(mana=30,rage=20),resource_declaration=RESOURCE_DECLARATION.plain(),
        resource_requirements=dict(mana=costs[0],rage=costs[1]),
        evolution=dict(pending=False,mana_cost=None,source='CURRENT_EVOLUTION_TARGET_CARD_NOT_EVOLVE_ACTION_PROOF'),
        mega_seal_type='MEGA_TREX',boss_policy='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD',
        account_sha256=None,controller_source_hash=source['critical_state_hash'],
        raw_remaining_seconds=trace.get('turn_time_remaining_seconds'),timer_source=trace.get('turn_timer_source'),
        healing_knowledge=dict(intrinsic_skill='UNKNOWN',fusion_lifesteal='UNKNOWN',credited=False),
        skill_damage_model=None,provenance='LEGACY_POLICY_ROW_NOT_FRESH_SKILL_ACTION_CONTEXT',
        raw_tag_board_hash_recomputed=False,historical_game_build_sha256=None,historical_source_sha256=None,
        reconstructed_actions=['swap','pet_skill'],omitted_actions=['evolve','cast','pass'])
    sid=SourceIdentity(run_id,canonical_json(source['session']),source['session']['match_id'],source['turn'],source['srv_seq'],
        source['board_hash'],own['actor_number'],None)
    path='external_logs/sha256/'+combat_sha256+'/combat.jsonl'
    problem=CommonProblem(sid,SourceRecord(path,line,combat_sha256,digest(decision)),
        CommonIntent('mega_icarus_spam_skill',FrozenJSON.of(settings),FrozenJSON.of(dict(engine=VERSION)),
            FrozenJSON.of(dict(kind='LEGACY_PRE_ACTION_RECONSTRUCTION_NOT_CURRENT_BUILD_ACCEPTANCE',input_authority=False))),
        tuple(tuple(tuple(c) for c in row) for row in board),action,trace.get('why_selected') or 'LOGGED_TREX_BASIC_SKILL',
        FrozenJSON.of(facts),(effect,))
    counts={}
    for g in GemType:
        if g is GemType.UNKNOWN:continue
        t=count_seal_gems(problem.board_state(),g,cells=seal.cells)
        counts[g.value]=dict(physical=t.physical,effective=t.effective)
    return problem,dict(policy_line=line,agreeing_pre_rows=[n for n,_ in decisions],
        board_semantic_sha256=semantic_board_hash(board),seal_type='MEGA_TREX',seal_cells=len(seal.cells),
        conditional_seal_counts=counts,final_pre_click_card_line=record['capability_line'],
        baseline_scope='LOGGED_CONTROLLER_BASIC_ONLY_NO_FRESH_STATE_EXPORT',
        healing_amount=None,damage=None)


def prepare(inventory_path,*,replay=True):
    inventory_path=Path(inventory_path).resolve()
    inventory=json.loads(inventory_path.read_text(encoding='utf-8'))
    records=[r for r in inventory['records'] if r['family']=='MEGA_TREX_CLICK_ONLY']
    cache={};cases=[];excluded=[];input_manifest={};checkpoints={}
    def pinned(path,expected):
        path=Path(path).resolve()
        require(path.is_file() and sha_file(path)==expected,'PINNED_HISTORICAL_LOG_CHANGED')
        input_manifest[path.as_posix()]=expected
        return path
    for old in records:
        primitive=pinned(old['skill_file'],old['skill_file_sha256'])
        old_combat=Path(old['combat_file']).resolve()
        matching=[sha for sha,v in inventory['input_manifest'].items() if old['combat_file'] in v['paths']]
        require(len(matching)==1,'COMBAT_HASH_NOT_PINNED')
        combat=pinned(old_combat,matching[0])
        if combat not in cache:
            rows,errors=read_rows(combat);require(not errors,'MALFORMED_PINNED_COMBAT')
            idx=combat_index(combat)
            configs=idx['configs'];require(len(configs)==1,'ONE_CONTROLLER_START_REQUIRED')
            checkpoint_path=combat.parents[2]/'checkpoint.json'
            cp=json.loads(checkpoint_path.read_text(encoding='utf-8'))
            input_manifest[checkpoint_path.as_posix()]=sha_file(checkpoint_path)
            checkpoints[cp['farm_run_id']]=dict(target_boss_id=cp.get('target_boss_id'),target_boss_name=cp.get('target_boss_name'),
                completed_matches=cp.get('completed_matches'),stop_reason=cp.get('stop_reason'),
                configuration_scope='RUN_METADATA_NOT_GAMEPLAY_INPUT')
            cache[combat]=(rows,idx,configs[0],cp)
        rows,idx,config,checkpoint=cache[combat]
        parsed,errors=read_rows(primitive);require(not errors,'MALFORMED_PINNED_PRIMITIVE')
        found=[r for r in analyze_rows(parsed) if r['action_key']==old['action_key']]
        require(len(found)==1,'UNIQUE_PRIMITIVE_RESULT_REQUIRED')
        record=found[0];record.update(controller_join(record,idx))
        cap=dict(parsed)[record['capability_line']]['capability']
        try:
            prob,features=pre_problem(record,cap,rows,config,run_id=checkpoint['farm_run_id'],combat_sha256=matching[0])
        except ValueError as exc:
            excluded.append(dict(action_key=record['action_key'],match_id=record['match_id'],turn=record['source_turn'],
                                 reason=str(exc),training_eligible=False))
            continue
        case=dict(case_id=prob.snapshot_id,common_problem=prob.to_dict(),pre_action_features=features,
            observation=dict(logged_card_click=True,controller_identity_join=True,
                resource_endpoint_consistent=record['resource_endpoint_consistent'],
                resources_before=record['resources_before'],resources_after=record['resources_after'],
                net_delta=record['resource_net_delta'],ordered_server_effects=None,
                damage_or_heal_attribution=None,fusion_lifesteal_attribution=None),
            provenance=dict(combat_sha256=matching[0],primitive_sha256=old['skill_file_sha256'],
                action_key=record['action_key'],historical_source_sha256=None,historical_game_build_sha256=None),
            quality_label=None,independent_holdout=False,training_eligible=False,input_authority=False)
        if replay:
            case['same_state_common_replay']=compare(prob)
            chosen=plan_common(prob,clock=lambda:0)
            swaps=sorted((s for s in chosen.scores if s.action.family=='swap'),key=lambda s:order_key(s,prob.intent.profile))
            case['skill_vs_ranked_swap']=dict(skill=project_action(prob,prob.baseline),
                ranked_swap=None if not swaps else project_action(prob,swaps[0].action),
                alternative_observed_outcome=None,damage_or_win_comparison=None,input_authority=False)
        cases.append(case)
    zero_inputs=[r for r in inventory['records'] if r['family']=='UNKNOWN'
                 and 'MEGA_TREX_CLICK_ONLY' in r['attempted_families']]
    return dict(schema=SCHEMA,inventory_sha256=sha_file(inventory_path),cases=cases,excluded=excluded,
        zero_input_negative_references=[{k:r[k] for k in ('match_id','source_turn','action_key','card_clicks','result_kind')} for r in zero_inputs],
        input_manifest=input_manifest,run_metadata=checkpoints,
        summary=dict(logged_successful_casts=len(records),matches=len({r['match_id'] for r in records}),
            reconstructed_cases=len(cases),excluded_cases=len(excluded),zero_input_negative_cases=len(zero_inputs),
            endpoint_observations=sum(c['observation']['resource_endpoint_consistent'] for c in cases),
            native_skill_effect_targets=0,healing_formulas_fitted=0,damage_models_fitted=0,
            replay_actions=dict(Counter(c['same_state_common_replay']['reasoning']['action']['family'] for c in cases if replay)),
            missing_protection_settings=sum(c['common_problem']['intent']['settings']['mega_self_protection'] is None for c in cases),
            minimum_pre_hp_ratio=min((c['common_problem']['facts']['self']['hp']/c['common_problem']['facts']['self']['max_hp'] for c in cases),default=None),
            same_state_replay_count=sum('same_state_common_replay' in c for c in cases),
            icarus_heal_credit=False),
        limitations=['NO_ORDERED_SKILL_EFFECTS','NO_HISTORICAL_BUILD_OR_SOURCE_HASH','NO_FRESH_CONTEXT_EXPORT',
            'NULL_PROTECTION_SETTING_IS_UNKNOWN_NOT_NONE_OR_30_PERCENT','SOURCE_LABEL_IS_EVOLUTION_TARGET_NOT_ALL_EVOLUTION_ROUTES',
            'CONDITIONAL_MASK_NOT_NATIVE_EFFECT_WITNESS','NO_FUTURE_OUTCOME_FEATURES','NOT_CURRENT_NATIVE_ACCEPTANCE'],
        core_modified=False,new_live_attempts=0,models_fitted=0)


def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--inventory',type=Path,required=True)
    p.add_argument('--out',type=Path,required=True);p.add_argument('--no-replay',action='store_true')
    args=p.parse_args();out=args.out.resolve();require(out.is_relative_to(ROOT),'OUTPUT_INSIDE_V2_REQUIRED')
    data=prepare(args.inventory,replay=not args.no_replay)
    out.parent.mkdir(parents=True,exist_ok=True)
    with out.open('x',encoding='utf-8') as stream:json.dump(data,stream,ensure_ascii=False,indent=2)
    print(json.dumps(data['summary']))


if __name__=='__main__':main()
