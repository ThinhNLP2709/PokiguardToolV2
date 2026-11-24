"""Pinned Icarus logs -> pre-action CommonProblems + separate skill receipts.

No fitting, game I/O, online memory, model promotion or alternate refill labels.
The current common core can replay the inputs; observed outcomes never enter it.
"""
from collections import Counter
from copy import deepcopy
from dataclasses import replace
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.combat_board_evidence import semantic_board_hash
from pokiguard_v2.combat_player_context import validate_player_context
from pokiguard_v2.mega_icarus import mega_seal_for_type, count_seal_gems
from pokiguard_v2.reasoning_common_models import RESOURCE_DECLARATION
from pokiguard_v2.reasoning_common_problem import CommonProblem, CommonIntent, EffectChoice, VERSION
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_planner import order_key
from pokiguard_v2.reasoning_skill_receipts import skill_receipt, validate_pre_context
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON, SourceIdentity, SourceRecord, canonical_json, digest, require
from pokiguard_v2.state import GemType
from tools.audit_active_skill_inventory import read_rows, sha_file, combat_index
from tools.bind_active_skill_outcomes import bind_file, prepare_candidates
from tools.compare_same_state_decisions import compare, project_action
from tools.normalize_action_outcomes import checked
from tools.normalize_boss_transitions import checked_state

SCHEMA = 'pokiguard.icarus_common_core_evidence.v1'


def stats(actor):
    return {key: actor.get(field) for key, field in (
        ('hp','hp'), ('max_hp','max_hp'), ('mana','mana'), ('max_mana','max_mana'),
        ('rage','power'), ('max_rage','max_power'), ('attack','attack'), ('shield','shield'))}


def pre_problem(candidate, rows, *, run_id, relative_path, file_sha256):
    """All dependencies are pre-dispatch; changing later outcomes is irrelevant."""
    context = validate_pre_context(candidate['context'])
    source, record = context['source'], candidate['record']
    require(context['family'] == 'MEGA_ICARUS_CLICK_ONLY' and context['element_type'] == 'MEGA_ICARUS',
            'ICARUS_PRE_ACTION_CARD_REQUIRED')
    require(context['skill_card_id'] == record['skill_card_id'], 'CARD_ID_CONFLICT')
    found = []
    for line, row in rows:
        if line >= candidate['start_line'] or row.get('event') != 'combat_state_evidence':
            continue
        value = row.get('stateEvidence')
        if type(value) is dict and (value.get('match_id'), value.get('server_sequence'), value.get('turn')) == (
                source['session']['match_id'], source['srv_seq'], source['turn']):
            value = checked_state(value)
            require(value['board_hash'] == source['board_hash']
                    and value['actor_identity'] == source['actor_identity'] == value['local_identity']
                    and value['board_instance'] == source['session']['board_instance']
                    and value['lifecycle_epoch'] == source['session']['lifecycle_epoch'], 'PRE_BOARD_IDENTITY')
            found.append((line, value))
    require(bool(found) and len({digest(v) for _, v in found}) == 1, 'UNIQUE_PUBLISHED_PRE_BOARD_REQUIRED')
    line, state = found[-1]
    for key in context['player']:
        require(state['player'].get(key) == context['player'][key], 'PLAYER_PRE_CONTEXT_CONFLICT')
    require(len(state['bosses']) == 1, 'ONE_OBSERVED_BOSS_REQUIRED')
    for key in context['boss']:
        require(state['bosses'][0].get(key) == context['boss'][key], 'BOSS_PRE_CONTEXT_CONFLICT')
    decisions = [(n, r) for n, r in rows if n < candidate['start_line'] and r.get('event') == 'policy_decision'
                 and r.get('session') == source['session'] and r.get('srvSeq') == source['srv_seq']
                 and r.get('turn') == source['turn'] and r.get('boardHash') == source['board_hash']]
    require(bool(decisions), 'PRE_POLICY_DECISION_REQUIRED')
    decision_line, decision = decisions[-1]
    trace = decision.get('trace') or {}
    require(decision.get('selectedAction') == 'pet_skill' and decision['boardSnapshot'] == state['board']
            and trace.get('skill_ready') is True and trace.get('skill_actionable') is True, 'PRE_SKILL_OWNER_PROOF')
    costs = context['costs']
    require(costs['mana_source'] == 'CONDITION_USE' and costs['rage_source'] == 'POWER'
            and record['effective_cost'] == [costs['mana'], costs['rage']]
            and context['player']['mana'] >= costs['mana'] and context['player']['power'] >= costs['rage'],
            'PRE_COSTS_AND_BALANCES')
    settings = deepcopy(context['settings'])
    settings.update(intelligence='basic', damage_card='pet_skill', game_mode='solo')
    skill = Action('pet_skill', card_source=canonical_json(dict(session=source['session'], card_id=context['skill_card_id'])))
    seal = mega_seal_for_type(context['element_type'])
    require(seal is not None and seal.heals_self, 'VERIFIED_ICARUS_SEAL_REQUIRED')
    effect = EffectChoice(skill, True, 'HISTORICAL_CURRENT_OWNED_CARD_REPLAY_ONLY', seal.cells,
        'B15_CONDITIONAL_MEGA_SEAL_FIRST_WAVE', 'CONDITIONAL_MODEL', costs['mana'], costs['rage'],
        FrozenJSON.of(dict(source_binding='CURRENT_OWNED_MEGA_SEAL_CARD', skill_card_id=context['skill_card_id'],
            seal_element_type='MEGA_ICARUS', actual_costs=dict(mana=costs['mana'],rage=costs['rage']),
            self_heal_present=True, self_heal_provenance='USER_DECLARATION_MEGA_ICARUS_HEALS_AMOUNT_UNKNOWN',
            post_cost_gain_order='UNKNOWN', QTE_executor='UNCHANGED_EXISTING_OWNER')))
    facts = dict(root_allowed=True, pending=False, self=stats(context['player']), opponent=stats(context['boss']),
        resource_requirements=dict(mana=costs['mana'],rage=costs['rage']),
        conversion=dict(mana=30,rage=20), resource_declaration=RESOURCE_DECLARATION.plain(),
        evolution=dict(pending=False,mana_cost=None,source='SKILL_OWNER_ALREADY_OBSERVED_NO_EVOLVE_ALTERNATIVE_RECONSTRUCTED'),
        mega_seal_type='MEGA_ICARUS', boss_policy='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD',
        account_sha256=None, controller_source_hash=source['critical_state_hash'],
        raw_remaining_seconds=trace.get('turn_time_remaining_seconds'), timer_source=trace.get('turn_timer_source'),
        provenance='FILE_RECONSTRUCTED_PRE_INPUT_ONLY_NO_RUNTIME_AUTHORITY',
        reconstructed_actions=['swap','pet_skill'], omitted_actions=['evolve','cast','pass'],
        self_heal_amount='UNKNOWN', skill_damage_model=None)
    identity = SourceIdentity(run_id,canonical_json(source['session']),source['session']['match_id'],
        source['turn'],source['srv_seq'],source['board_hash'],context['player']['actor_number'],None)
    problem = CommonProblem(identity,SourceRecord(relative_path,line,file_sha256,digest(dict(rows)[line])),
        CommonIntent('mega_icarus_spam_skill',FrozenJSON.of(settings),FrozenJSON.of(dict(engine=VERSION)),
            FrozenJSON.of(dict(kind='OFFLINE_NATIVE_PRE_STATE_RECONSTRUCTION_NOT_CALIBRATION',input_authority=False))),
        tuple(tuple(tuple(cell) for cell in row) for row in state['board']),skill,
        trace.get('why_selected') or 'RECORDED_BASIC_SKILL',FrozenJSON.of(facts),(effect,))
    tallies = {g.value:dict(physical=count_seal_gems(problem.board_state(),g,cells=seal.cells).physical,
                           effective=count_seal_gems(problem.board_state(),g,cells=seal.cells).effective)
               for g in GemType if g is not GemType.UNKNOWN}
    return problem, dict(published_board_line=line,policy_decision_line=decision_line,
                         source_board_semantic_sha256=semantic_board_hash(state['board']),
                         seal_type=seal.element_type,seal_cells=len(seal.cells),known_seal_counts=tallies,
                         role='PRE_INPUT_CONDITIONAL_GEOMETRY_NOT_TOTAL_SKILL_OUTCOME')


def sensitivity(problem):
    """Labelled synthetic feature checks, not new native or optimal actions."""
    result=[]
    original=problem.facts.plain()
    costs=original['resource_requirements']
    changes=(('self_hp_25_percent','hp',original['self']['max_hp']//4),
             ('self_hp_full','hp',original['self']['max_hp']),
             ('mana_below_cost','mana',max(0,costs['mana']-1)),
             ('rage_below_cost','rage',max(0,costs['rage']-1)))
    for label,key,value in changes:
        facts=deepcopy(original);facts['self'][key]=value
        altered=replace(problem,facts=FrozenJSON.of(facts))
        chosen=plan_common(altered,clock=lambda:0)
        score=next((s for s in chosen.scores if s.action==altered.baseline),None)
        projection=project_action(altered,altered.baseline)
        result.append(dict(label=label,origin='SYNTHETIC_SAME_BOARD_SENSITIVITY',changed_stat=key,value=value,
            board_unchanged=altered.board==problem.board,actual_game_outcome=None,quality_label=None,
            effect_projection_status=projection['status'],effect_projection_reason=projection.get('reason'),
            protection_proxy=None if score is None else score.details.plain().get('tactical_context',{}).get('protection_proxy'),
            action_authority=False,damage_prediction=None))
    return result


def prepare(closure_path, *, replay=True):
    closure_path = Path(closure_path).resolve()
    closure = json.loads(closure_path.read_text(encoding='utf-8'))
    folder = closure_path.parents[1]
    manifest = closure['raw_manifest']
    for name, expected in manifest.items():
        path = (folder/name).resolve()
        require(path.is_relative_to(folder) and path.is_file() and sha_file(path) == expected, 'PINNED_NATIVE_LOG_CHANGED')
    selected_runs = [r for r in closure['run_ledger'] if r['completed_matches'] == 3 and r['wins'] == 3
                     and r['gameplay_config']['play_style'] == 'mega_icarus_spam_skill']
    require(len(selected_runs) == 1, 'ONE_COMPLETED_ICARUS_COHORT_REQUIRED')
    run = selected_runs[0]
    cases, ledger_counts, heal_sources = [], Counter(), Counter()
    for name in sorted(manifest):
        if not name.endswith('/combat.jsonl') or run['farm_run_id'] not in name:
            continue
        path = folder/name
        rows, errors = read_rows(path)
        require(not errors, 'MALFORMED_PINNED_LOG')
        candidates, excluded, primitives = prepare_candidates(path,rows,combat_index(path))
        require(not excluded, 'PRIMITIVE_SOURCE_CONFLICT')
        bindings = bind_file(path,review_client_windows=True)
        assoc = {o['skill_action_binding'].get('action_key'):o for o in bindings.get('client_card_window_observations',[])
                 if o['skill_action_binding']['status'] == 'OBSERVED_CLIENT_CARD_WINDOW'}
        for candidate in candidates:
            key = candidate['record']['action_key']
            problem, features = pre_problem(candidate,rows,run_id=run['farm_run_id'],
                relative_path=path.resolve().relative_to(ROOT).as_posix(),file_sha256=sha_file(path))
            start = candidate['source']
            captures = [(line,row['combatOutcome']) for line,row in rows
                if row.get('event') == 'pet_skill_retained_outcome'
                and row.get('sourceSession') == start['session'] and row.get('sourceTurn') == start['turn']
                and row.get('sourceSrvSeq') == start['srv_seq']]
            require(len(captures)==1, 'ONE_RETAINED_SKILL_RESPONSE_REQUIRED')
            response_line, capture = captures[0]
            evidence = checked(capture)
            context = capture.get('player_context')
            if context is not None:
                validate_player_context(context,**{k:evidence[k] for k in ('match_id','server_sequence','event_type','raw_sha256')})
            association = 'CLIENT_CARD_WINDOW' if key in assoc else 'UNBOUND'
            receipt = skill_receipt(candidate['context'],evidence,association=association,response_players=context)
            plain = receipt.plain()
            destroys = [op for op in evidence.get('resource_operations') or [] if op['type']=='DESTROY']
            first = destroys[0] if destroys else {}
            native = first.get('native_positions')
            observed_cells = None if native is None else {(7-y,x) for x,y in native}
            geometry_review = dict(status='UNKNOWN' if observed_cells is None else
                'OBSERVED_FIRST_DESTROY_MATCHES_REGISTRY' if observed_cells == set(mega_seal_for_type('MEGA_ICARUS').cells)
                else 'OBSERVED_FIRST_DESTROY_DIFFERS',
                observed_first_cells=None if observed_cells is None else len(observed_cells),
                destroy_operation_count=len(destroys),resource_multiplier_attribution=first.get('tag_multiplier_binding','UNKNOWN'),
                counted_geometry_not_total_damage=True)
            ledger_counts.update(op['status'] for op in plain['resource_ledger']['entries'])
            heal_sources.update(label for component in plain['healing_components'] for label in component['operation_source_labels'])
            case = dict(case_id=problem.snapshot_id,common_problem=problem.to_dict(),
                pre_action_features=features,observed_receipt=plain,
                observed_geometry_review=geometry_review,
                observation_link=association,source_turn=start['turn'],match_id=problem.source.match_id,
                provenance=dict(combat_path=problem.provenance.path,combat_sha256=sha_file(path),
                    primitive_sha256=candidate['primitive_sha256'],response_line=response_line,
                    native_source_sha256=closure['native_source_sha256'],boss=closure['known_boss']),
                counterfactual_outcome=None,quality_label=None,independent_holdout=False,training_eligible=False)
            if replay:
                case['same_state_common_replay'] = compare(problem)
                result = plan_common(problem,clock=lambda:0)
                swaps = sorted((s for s in result.scores if s.action.family=='swap'),
                               key=lambda s:order_key(s,problem.intent.profile))
                case['skill_vs_ranked_swap'] = dict(
                    skill=project_action(problem,problem.baseline),
                    ranked_swap=None if not swaps else project_action(problem,swaps[0].action),
                    same_snapshot_id=problem.snapshot_id, selection_rule='EXISTING_CORE_ORDER_NOT_OPTIMAL_ACTION',
                    alternative_observed_outcome=None, damage_or_win_comparison=None,
                    observation_injected=False, quality_label=None, input_authority=False)
                case['synthetic_sensitivity'] = sensitivity(problem)
            cases.append(case)
    return dict(schema=SCHEMA,source_closure_sha256=sha_file(closure_path),cases=cases,
        summary=dict(cases=len(cases),conditional_client_windows=sum(c['observation_link']=='CLIENT_CARD_WINDOW' for c in cases),
            unbound=sum(c['observation_link']=='UNBOUND' for c in cases),
            raw_ledger_status_counts=dict(ledger_counts),healing_operation_source_labels=dict(heal_sources),
            first_destroy_geometry_matches=sum(c['observed_geometry_review']['status']=='OBSERVED_FIRST_DESTROY_MATCHES_REGISTRY' for c in cases),
            same_state_replay_count=sum('same_state_common_replay' in c for c in cases),
            synthetic_sensitivity_cases=sum(len(c.get('synthetic_sensitivity',[])) for c in cases),
            replay_proposals=dict(Counter(c['same_state_common_replay']['reasoning']['action']['family']
                for c in cases if 'same_state_common_replay' in c)),
            model_fitted=False,runtime_changed=False,game_input=0,new_live_attempts=0,training_eligible=0),
        use='OFFLINE_REPLAY_AND_EFFECT_CONTRACT_REGRESSION_FOR_COMMON_CORE',
        limitations=['OBSERVED_TARGETS_NEVER_INPUT_FEATURES','GEOMETRY_COUNTS_NOT_SERVER_TOTALS',
                     'UNBOUND_TERMINAL_RECEIPTS_NOT_CALIBRATION','NO_NEW_INPUT_AUTHORITY',
                     'NOT_NATIVE_REASONING_ACCEPTANCE','NO_UNIVERSAL_DAMAGE_HEAL_OR_FULL_POWER_RULE'])


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--closure',type=Path,required=True)
    p.add_argument('--out',type=Path,required=True)
    p.add_argument('--no-replay',action='store_true')
    args=p.parse_args()
    out=args.out.resolve()
    require(out.is_relative_to(ROOT),'OUTPUT_INSIDE_V2_REQUIRED')
    data=prepare(args.closure,replay=not args.no_replay)
    out.parent.mkdir(parents=True,exist_ok=True)
    with out.open('x',encoding='utf-8') as stream:
        json.dump(data,stream,ensure_ascii=False,indent=2)
    print(json.dumps(data['summary']))


if __name__=='__main__':main()
