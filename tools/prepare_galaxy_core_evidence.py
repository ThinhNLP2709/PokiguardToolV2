"""File-only Galaxy handoff: partial fixtures and joined G2 clicks stay separate.

No reader, executor, phase inference, fitting or rollout. An opaque Galaxy skill
must never be replaced by an empty Mega mask or scored as zero damage.
"""
from collections import Counter
import argparse
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
from pokiguard_v2.board_simulator import SwapMove
from pokiguard_v2.combat_board_evidence import valid_screen_board, semantic_board_hash
from pokiguard_v2.galaxy_glank import shield_count, shield_value
from pokiguard_v2.reasoning_common_models import RESOURCE_DECLARATION
from pokiguard_v2.reasoning_common_problem import CommonProblem, CommonIntent, EffectChoice, VERSION
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON, SourceIdentity, SourceRecord, canonical_json, digest, require
from tools.audit_active_skill_inventory import read_rows, sha_file, analyze_rows, combat_index, controller_join
from tools.compare_same_state_decisions import compare
from tools.prepare_icarus_core_evidence import stats
from tools.prepare_trex_core_evidence import pre_view

SCHEMA = 'pokiguard.galaxy_common_core_evidence.v1'
ELEMENTS = dict(g1='GALAXY_RICKY', g2='GALAXY_2', g3='GALAXY_DRAGON_KNIGHT')
FIXTURE = ROOT / 'tests/fixtures/galaxy_glank_20261115/replay.json'
DESCRIPTIONS = ROOT / 'tests/fixtures/galaxy_profiles_20261116/descriptions.json'


def actors(own, boss):
    require(isinstance(own, dict) and isinstance(boss, dict)
        and own.get('is_local') is True and own.get('is_boss') is False
        and boss.get('is_boss') is True and boss.get('is_local') is False
        and type(own.get('actor_number')) is int and type(boss.get('actor_number')) is int
        and own['actor_number'] != boss['actor_number'], 'PRE_ACTOR_OWNERSHIP')
    for actor in (own, boss):
        require(all(type(actor.get(k)) is int and actor[k] >= 0 for k in
            ('hp', 'max_hp', 'mana', 'max_mana', 'power', 'max_power', 'attack', 'shield')),
            'PRE_STATS_INCOMPLETE')
        require(actor['max_hp'] > 0 and actor['hp'] > 0, 'LIVE_PRE_ACTORS_REQUIRED')


def opaque_skill(action, *, costs=(None, None), element=None, binding=None):
    return EffectChoice(action, True, 'GALAXY_SKILL_EFFECT_UNMODELED', None,
        'UNKNOWN_GALAXY_DAMAGE_AND_RESOURCE_EFFECTS', 'UNKNOWN', *costs,
        FrozenJSON.of(dict(galaxy_element_type=element, source_binding=binding,
            self_heal_present=False, self_heal_knowledge='UNKNOWN_NOT_CREDITED',
            active_buff_remaining=None, stored_mark_damage=None, skill_phase_next=None,
            skill_phase_max=None, phase_support='UNKNOWN', guaranteed_refund_credit=0,
            guaranteed_random_outcome=None, seal_element_type=None)))


def facts(own, boss, *, origin, costs=None):
    return dict(root_allowed=True, pending=False, self=stats(own), opponent=stats(boss),
        conversion=dict(mana=30, rage=20), resource_declaration=RESOURCE_DECLARATION.plain(),
        resource_requirements={} if costs is None else dict(mana=costs[0], rage=costs[1]),
        evolution=dict(pending=None, mana_cost=None, source='UNKNOWN'),
        boss_policy='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD', account_sha256=None,
        skill_damage_model=None, provenance=origin, raw_tag_board_hash_recomputed=False,
        historical_game_build_sha256=None, historical_source_sha256=None,
        scenario_assumptions=['MODEL_ROOT_ACTION_WINDOW_ONLY_NOT_RUNTIME_PERMISSION'],
        phase_next=None, phase_max=None, phase_support='UNKNOWN',
        active_buff_remaining=None, stored_mark_damage=None, random_outcome=None,
        guaranteed_refund_credit=0, reconstructed_actions=['swap'], omitted_actions=['evolve', 'cast', 'pass'])


def features(problem):
    board = problem.board_state()
    return dict(board_semantic_sha256=semantic_board_hash(problem.board),
        shield_physical=shield_count(board.cells), shield_effective=shield_value(board.cells),
        role='PRE_ACTION_STRUCTURAL_FACTS_NOT_SKILL_DAMAGE', skill_effect_modeled=False,
        native_effect_witness=False, phase_observed=False, nominal_damage_is_not_prediction=True)


def fixture_problem(case, run, index, fixture_sha256):
    """Use only the fixture's recorded board/stats/action, never test mock cards."""
    require(case.get('pet') in ELEMENTS and valid_screen_board(case.get('board')), 'FIXTURE_PET_OR_BOARD')
    actors(case.get('player'), case.get('boss'))
    old_move = case.get('old_move')
    require(type(case.get('old_step')) is str, 'FIXTURE_BASELINE_REASON_REQUIRED')
    if old_move is None:
        require(case['old_step'] == 'GALAXY_FIRE', 'FIXTURE_ACTION_NOT_RECONSTRUCTABLE')
        action = Action('pet_skill', card_source='UNKNOWN_FIXTURE_CARD')
        effects = (opaque_skill(action, element=ELEMENTS[case['pet']], binding='FIXTURE_ALIAS_ONLY_NOT_OWNED_CARD'),)
    else:
        action = Action('swap', SwapMove(tuple(old_move['first']), tuple(old_move['second'])))
        effects = ()
    selected = {key: case[key] for key in ('pet', 'turn', 'srv_seq', 'board', 'player', 'boss', 'old_step', 'old_move')}
    settings = dict(play_style='galaxy', intelligence='basic', main_pet=None,
        evolution=None, damage_card=None, mega_self_protection=None,
        pet_skill_fire_condition=None, pet_skill_fire_value=None)
    f = facts(case['player'], case['boss'], origin='HISTORICAL_PARTIAL_FIXTURE_NOT_NATIVE_ACTION_CONTEXT')
    f.update(fixture_alias=case['pet'], raw_board_hash=None, baseline_execution_mode='UNKNOWN',
        missing_context=['OWNED_CARD', 'ACTUAL_COST', 'CONFIG', 'SESSION', 'MATCH', 'ACTION_GATE', 'PHASE', 'SKILL_RESPONSE'])
    if action.family == 'pet_skill': f['reconstructed_actions'].append('pet_skill')
    semantic = semantic_board_hash(case['board'])
    source = SourceIdentity(run['farm_run_id'], 'UNKNOWN_FIXTURE_SESSION:' + case['pet'],
        'UNKNOWN_FIXTURE_MATCH:' + case['pet'], case['turn'], case['srv_seq'],
        semantic, case['player']['actor_number'], None)
    return CommonProblem(source, SourceRecord(FIXTURE.relative_to(ROOT).as_posix(), 1,
        fixture_sha256, digest(selected)),
        CommonIntent('galaxy', FrozenJSON.of(settings), FrozenJSON.of(dict(engine=VERSION)),
            FrozenJSON.of(dict(kind='PARTIAL_FIXTURE_STRUCTURAL_REPLAY_ONLY', fixture_index=index,
                original_combat_sha256=run['combat_sha256'], original_combat_available=False,
                board_hash_kind='SEMANTIC_NOT_RAW_RUNTIME', input_authority=False))),
        tuple(tuple(tuple(c) for c in row) for row in case['board']), action,
        case['old_step'], FrozenJSON.of(f), effects)


def joined_g2_problem(record, capability, rows, config, *, run_id, combat_sha256, tactical_enabled):
    """Exact old click/card/cost join, with an opaque effect and unknown phase."""
    require(record.get('logged_click_card_cost_join') is True
        and record.get('controller_join_verified') is True, 'EXACT_LOGGED_CLICK_REQUIRED')
    start = dict(rows)[record['controller_start_line']]
    source = start['identity']['source']
    require(source.get('session', {}).get('match_id') == record.get('match_id')
        and start.get('skillCardId') == record.get('skill_card_id')
        and start['identity'].get('action') == 'pet_skill', 'CONTROLLER_ACTION_IDENTITY_CONFLICT')
    require(capability.get('status') == 'CURRENT' and capability.get('ownership_current') is True
        and capability.get('skill_family') == 'GALAXY_CLICK_ONLY'
        and capability.get('element_type') == 'GALAXY_2'
        and capability.get('source') == 'CARD_UI_BUTTON'
        and capability.get('live_card_present') is True and capability.get('live_card_actionable') is True
        and capability.get('session_key') == source.get('session')
        and capability.get('card_id') == capability.get('skill_card_id') == record['skill_card_id'],
        'CURRENT_G2_CARD_REQUIRED')
    require(capability.get('effective_mana_cost_source') == 'CONDITION_USE'
        and capability.get('effective_power_cost_source') == 'POWER', 'KNOWN_COST_SOURCES_REQUIRED')
    costs = [capability.get('effective_mana_cost'), capability.get('effective_power_cost')]
    require(all(type(n) is int and n >= 0 for n in costs) and costs == record['effective_cost'], 'COST_CONFLICT')
    require(costs == [start.get('requiredMana'), start.get('requiredRage')], 'DISPATCH_COST_CONFLICT')
    require(config.get('play_style') == 'galaxy' and config.get('main_pet') == 'galaxy'
        and config.get('evolution_target') == 'none' and config.get('damage_card') == 'pet_skill'
        and config.get('pet_skill_fire_condition') == 'skill_cost_ready', 'LEGACY_G2_ROUTE_NOT_VERIFIED')
    decisions = [(line, row) for line, row in rows if line < record['controller_start_line']
        and row.get('event') == 'policy_decision' and row.get('session') == source.get('session')
        and row.get('turn') == source.get('turn') and row.get('srvSeq') == source.get('srv_seq')
        and row.get('boardHash') == source.get('board_hash')]
    require(bool(decisions), 'PRE_POLICY_BOARD_MISSING')
    require(len({digest(pre_view(row)) for _, row in decisions}) == 1, 'CONFLICTING_PRE_POLICY_STATE')
    line, row = decisions[-1]
    own, boss, trace = row['player'], row['boss'], row['trace']
    actors(own, boss)
    require(valid_screen_board(row.get('boardSnapshot')) and row.get('boardSnapshotOrder') ==
        'screen_rows_top_to_bottom_columns_left_to_right', 'PRE_BOARD_DOMAIN_OR_ORDER')
    require(row.get('playStyle') == 'galaxy' and row.get('selectedAction') == 'pet_skill'
        and trace.get('skill_ready') is True and trace.get('skill_actionable') is True
        and trace.get('skill_capability_status') == 'CURRENT'
        and trace.get('skill_family') == 'GALAXY_CLICK_ONLY' and trace.get('skill_source') == 'MAIN_PET'
        and trace.get('fire_condition_scope') == 'RESOURCE_ONLY', 'POLICY_G2_SCOPE_CONFLICT')
    require([own['mana'], own['power']] == record['resources_before']
        == [start.get('currentMana'), start.get('currentRage')]
        == [trace.get('current_mana'), trace.get('current_rage')]
        and costs == [trace.get('required_mana'), trace.get('required_rage')]
        and own['mana'] >= costs[0] and own['power'] >= costs[1], 'PRE_RESOURCES_OR_COST_CONFLICT')
    settings = {key: config.get(key) for key in ('play_style', 'main_pet', 'damage_card',
        'game_mode', 'mega_self_protection', 'pet_skill_fire_condition', 'pet_skill_fire_value')}
    settings.update(evolution='none', intelligence='basic')  # Schema field, not execution-mode proof.
    action = Action('pet_skill', card_source=canonical_json(dict(session=source['session'], card_id=record['skill_card_id'])))
    f = facts(own, boss, origin='LEGACY_PRE_CLICK_G2_RECONSTRUCTION_NOT_CURRENT_BUILD_ACCEPTANCE', costs=costs)
    f.update(reconstructed_actions=['swap', 'pet_skill'], controller_source_hash=source['critical_state_hash'],
        raw_board_hash=source['board_hash'],
        evolution=dict(pending=False, mana_cost=None, source='RECORDED_NO_EVOLUTION_ROUTE'),
        baseline_execution_mode='GALAXY_PER_PET_TACTICS' if tactical_enabled is True else 'UNKNOWN',
        common_worker_execution=False, raw_remaining_seconds=row.get('timerRemaining'),
        timer_source=trace.get('turn_timer_source'))
    sid = SourceIdentity(run_id, canonical_json(source['session']), source['session']['match_id'],
        source['turn'], source['srv_seq'], source['board_hash'], own['actor_number'], None)
    problem = CommonProblem(sid, SourceRecord('logs/sha256/' + combat_sha256 + '/combat.jsonl',
        line, combat_sha256, digest(dict(pre_view(row), policyStep=row.get('policyStep')))),
        CommonIntent('galaxy', FrozenJSON.of(settings), FrozenJSON.of(dict(engine=VERSION)),
            FrozenJSON.of(dict(kind='LEGACY_G2_PRE_CLICK_OPAQUE_SKILL', input_authority=False))),
        tuple(tuple(tuple(c) for c in r) for r in row['boardSnapshot']), action,
        trace.get('why_selected') or 'LOGGED_G2_SKILL', FrozenJSON.of(f),
        (opaque_skill(action, costs=costs, element='GALAXY_2', binding='LEGACY_OWNED_CARD_UI'),))
    return problem, dict(policy_line=line, final_pre_click_card_line=record['capability_line'])


def replay_case(problem, *, replay):
    item = dict(case_id=problem.snapshot_id, common_problem=problem.to_dict(), pre_action_features=features(problem),
        quality_label=None, training_eligible=False, independent_holdout=False, input_authority=False,
        comparison_scope='LOGGED_BASELINE_VS_OFFLINE_COMMON_NOT_UI_BASIC_VS_REASONING',
        observation=dict(ordered_server_effects=None, damage_or_heal_attribution=None))
    if replay:
        comparison = compare(problem)
        item['same_state_common_replay'] = comparison
        is_g2 = problem.facts.plain().get('fixture_alias') == 'g2' or any(
            e.facts.plain().get('galaxy_element_type') == 'GALAXY_2' for e in problem.effects)
        if is_g2:
            def shield_review(projection):
                if projection['status'] != 'MODELED': return None
                consumed = projection['known_resources']['shield']['effective']
                return dict(known_shield_consumed=consumed,
                    known_shield_remaining_ignoring_refill=item['pre_action_features']['shield_effective']-consumed,
                    added_shield_from_refill=None, skill_damage_prediction=None)
            item['g2_strategy_review'] = dict(baseline=shield_review(comparison['basic']),
                common=shield_review(comparison['reasoning']),
                common_planner_has_pet_specific_shield_skill_utility=False,
                shield_collection_can_cost_skill_potential=True,
                mechanical_classifier_is_not_g2_strategy_quality=True,
                actual_buff_or_mitigation_credit=0)
    return item


def prepare(inventory_path, *, replay=True, fixture_path=FIXTURE, descriptions_path=DESCRIPTIONS):
    inventory_path, fixture_path, descriptions_path = map(Path, (inventory_path, fixture_path, descriptions_path))
    inventory = json.loads(inventory_path.read_text(encoding='utf-8'))
    fixture = json.loads(fixture_path.read_text(encoding='utf-8'))
    descriptions = json.loads(descriptions_path.read_text(encoding='utf-8'))
    manifest = {str(p.resolve()): sha_file(p) for p in (inventory_path, fixture_path, descriptions_path)}
    partial = [replay_case(fixture_problem(c, fixture['runs'][c['pet']], i, sha_file(fixture_path)), replay=replay)
        for i, c in enumerate(fixture['cases'])]
    joined, excluded, negatives, cache = [], [], [], {}
    for old in (r for r in inventory['records'] if r['family'] == 'GALAXY_CLICK_ONLY'):
        primitive, combat = Path(old['skill_file']).resolve(), Path(old['combat_file']).resolve()
        require(sha_file(primitive) == old['skill_file_sha256'], 'PINNED_PRIMITIVE_CHANGED')
        hashes = [sha for sha, v in inventory['input_manifest'].items() if old['combat_file'] in v['paths']]
        require(len(hashes) == 1 and sha_file(combat) == hashes[0], 'PINNED_COMBAT_CHANGED')
        manifest[str(primitive)] = old['skill_file_sha256']; manifest[str(combat)] = hashes[0]
        if combat not in cache:
            rows, errors = read_rows(combat); require(not errors, 'MALFORMED_PINNED_COMBAT')
            idx = combat_index(combat)
            starts = [r for _, r in rows if r.get('event') == 'auto_controller_started']
            require(len(starts) == 1, 'ONE_CONTROLLER_START_REQUIRED')
            cache[combat] = rows, idx, starts[0]
        rows, idx, started = cache[combat]
        parsed, errors = read_rows(primitive); require(not errors, 'MALFORMED_PINNED_PRIMITIVE')
        candidates = [r for r in analyze_rows(parsed) if r['action_key'] == old['action_key']]
        require(len(candidates) == 1, 'UNIQUE_PRIMITIVE_RESULT_REQUIRED')
        record = candidates[0]; record.update(controller_join(record, idx))
        if not record['logged_click_card_cost_join']:
            if record['card_clicks'] == 0 and record['result_kind'] == 'INVALIDATED':
                negatives.append({k: record[k] for k in ('match_id', 'source_turn', 'action_key', 'card_clicks', 'result_kind')})
            else:
                excluded.append(dict(action_key=record['action_key'], reason='LOGGED_CLICK_NOT_VERIFIED'))
            continue
        try:
            problem, context = joined_g2_problem(record, dict(parsed)[record['capability_line']]['capability'],
                rows, started['config'], run_id=combat.parents[2].name, combat_sha256=hashes[0],
                tactical_enabled=started.get('galaxyReasoningEnabled'))
        except ValueError as exc:
            excluded.append(dict(action_key=record['action_key'], reason=str(exc))); continue
        item = replay_case(problem, replay=replay)
        item['pre_action_features'].update(context)
        item['observation'].update(logged_card_click=True, controller_identity_join=True,
            resource_endpoint_consistent=record['resource_endpoint_consistent'],
            resources_before=record['resources_before'], resources_after=record['resources_after'],
            post_turn=record['post_turn'], net_delta=record['resource_net_delta'])
        joined.append(item)
    all_cases = partial + joined
    return dict(schema=SCHEMA, partial_fixture_cases=partial, joined_g2_cases=joined,
        excluded=excluded, zero_input_negative_references=negatives, input_manifest=manifest,
        description_references=[{k: d[k] for k in ('alias', 'element_type', 'source_log_sha256')} for d in descriptions],
        summary=dict(partial_fixture_cases=len(partial),
            partial_by_pet=dict(Counter(c['common_problem']['facts']['fixture_alias'] for c in partial)),
            joined_g2_clicks=len(joined), excluded=len(excluded), zero_input_negatives=len(negatives),
            resource_endpoints=sum(c['observation']['resource_endpoint_consistent'] for c in joined),
            native_effect_targets=0, native_phase_witnesses=0,
            same_state_replays=sum('same_state_common_replay' in c for c in all_cases),
            replay_actions=dict(Counter(c['same_state_common_replay']['reasoning']['action']['family'] for c in all_cases if replay)),
            joined_tactical_execution=sum(c['common_problem']['facts']['baseline_execution_mode'] == 'GALAXY_PER_PET_TACTICS' for c in joined)),
        limitations=['PARTIAL_FIXTURE_MISSING_SOURCE_CONFIG_CARD_PHASE', 'FIVE_G2_CLICKS_NOT_FIVE_ATTRIBUTED_EFFECTS',
            'UNKNOWN_SKILL_EFFECT_IS_OPAQUE_NOT_EMPTY_MASK', 'NO_G1_OR_G3_PHASE_RECONSTRUCTION_FROM_SPARSE_CASES',
            'NO_GUARANTEED_RNG_REFUND_OR_BUFF', 'NOT_UI_COMMON_WORKER_ROLLOUT', 'NOT_CURRENT_BUILD_ACCEPTANCE',
            'NO_QUALITY_LABEL_FROM_WIN_OR_INTERNAL_UTILITY'], core_modified=False, new_live_attempts=0, models_fitted=0)


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--inventory', type=Path, required=True); p.add_argument('--out', type=Path, required=True)
    p.add_argument('--no-replay', action='store_true')
    args = p.parse_args(); out = args.out.resolve()
    require(out.is_relative_to(ROOT), 'OUTPUT_INSIDE_V2_REQUIRED')
    result = prepare(args.inventory, replay=not args.no_replay)
    out.parent.mkdir(parents=True, exist_ok=True)
    with out.open('x', encoding='utf-8') as stream: json.dump(result, stream, ensure_ascii=False, indent=2)
    print(json.dumps(result['summary']))


if __name__ == '__main__': main()
