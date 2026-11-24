"""Diagnostic-only skill context/export and strict offline response binding."""
from copy import deepcopy
from dataclasses import asdict, replace
from enum import Enum
import hashlib
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock

from pokiguard_v2.autonomous_control import AutonomousActionIdentity, AutonomousSource
from pokiguard_v2.basic_policy import PolicyAction, PolicyConfig
from pokiguard_v2.combat_outcome_evidence import project_combat_outcome
from pokiguard_v2.skill_action_evidence import context_fields_safely, emit_retained_skill_outcomes_safely
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_active_skill_inventory import fixture
from tests.test_combat_outcome_evidence import envelope
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tools.bind_active_skill_outcomes import bind_file, check_context
from pokiguard_v2.skill_action_evidence import SCHEMA as CONTEXT_SCHEMA
from pokiguard_v2.combat_outcome_evidence import actor_identity
from tools.dispatcher_qte_result_tap import DispatcherTransportTap
from tools.normalize_action_outcomes import extract


def capture(sequence=11, card=99, actor='synthetic-player', *, board=False):
    raw = envelope('MATCH_SKILL_USE_RES', sequence)
    raw.update(matchId='M_test', skillCardId=card)
    raw['matchPayload']['actorUsername'] = actor
    if not board:
        raw['matchPayload'].pop('board')
    return project_combat_outcome(raw, expected_match_id='M_test', expected_sequence=sequence,
        raw_sha256=hashlib.sha256(json.dumps(raw).encode()).hexdigest(), board_attested=board)


def files_fixture():
    primitive, index = fixture()
    start = deepcopy(index['sends'][0][1])
    source = start['identity']['source']
    source.update(board_hash='a'*64, critical_state_hash='b'*64, current_turn_player='synthetic-player')
    end = deepcopy(index['results'][0][1])
    end['identity'] = deepcopy(start['identity'])
    end.update(event='pet_skill_dispatch_result', inputSent=True)
    start['event'] = 'pet_skill_dispatch_started'
    rows = [start, end, dict(event='pet_skill_retained_outcome', combatOutcome=capture().to_dict())]
    return [d for _, d in primitive], rows


def client_window_fixture():
    primitive, rows = files_fixture()
    primitive.insert(2, deepcopy(primitive[0]))
    primitive[-1]['result']['post_state']['battle']['is_local_turn'] = False
    rows[1]['result'] = deepcopy(primitive[-1]['result'])
    source = deepcopy(rows[0]['identity']['source'])
    source['actor_identity'] = actor_identity(source.pop('current_turn_player'))
    ctx = dict(schema=CONTEXT_SCHEMA, status='RECORDED', source=source, skill_card_id=99,
               costs=dict(mana=200, rage=200), input_authority=False, calibration_eligible=False)
    ctx['context_sha256'] = hashlib.sha256(json.dumps(ctx, sort_keys=True, separators=(',', ':'), ensure_ascii=True).encode()).hexdigest()
    rows[0]['skillActionContext'] = ctx
    rows[-1].update(sourceSession=deepcopy(source['session']), sourceTurn=3, sourceSrvSeq=10)
    rows[-1]['combatOutcome']['evidence']['card_ids'] = dict(cardId=None, skillCardId=None)
    return primitive, rows


class SkillContextTests(unittest.TestCase):
    def sample(self):
        state = session_state(mana=500, rage=250)
        cap = capability(element='MEGA_TREX', card_id=99)
        identity = AutonomousActionIdentity(AutonomousSource.from_state(state), PolicyAction.PET_SKILL,
                                           (cap.session_key, cap.skill_card_id))
        return state, cap, identity

    def test_existing_fresh_state_only_and_no_plain_username(self):
        state, cap, identity = self.sample()
        record = context_fields_safely(identity, state, cap, PolicyConfig())['skillActionContext']
        self.assertEqual('RECORDED', record['status'])
        self.assertEqual(500, record['player']['mana'])
        self.assertNotIn(identity.source.current_turn_player, json.dumps(record))
        self.assertFalse(record['input_authority'])
        self.assertIsNone(record['prediction'])
        source = dict(record['source'])
        source.pop('actor_identity')
        source['current_turn_player'] = identity.source.current_turn_player
        expected = dict(skill_card_id=99, effective_cost=[200, 200])
        self.assertEqual(record, check_context(record, source, expected))

    def test_changed_owner_or_card_gives_diagnostic_loss_only(self):
        state, cap, identity = self.sample()
        bad = replace(cap, ownership_current=False)
        result = context_fields_safely(identity, state, bad, PolicyConfig())
        self.assertEqual('UNAVAILABLE', result['skillActionContext']['status'])
        self.assertFalse(result['skillActionContext']['input_authority'])

    def test_context_failure_and_export_failure_never_escape(self):
        self.assertEqual('UNAVAILABLE', context_fields_safely(None, None, None, None)['skillActionContext']['status'])
        _, _, identity = self.sample()
        tap = Mock()
        tap.skill_outcome_snapshot.side_effect = RuntimeError('diagnostic only')
        emit = Mock()
        self.assertFalse(emit_retained_skill_outcomes_safely(tap, identity, emit))
        self.assertEqual('UNAVAILABLE', emit.call_args.kwargs['status'])
        tap.skill_outcome_snapshot.side_effect = None
        tap.skill_outcome_snapshot.return_value = (capture().to_dict(),)
        emit.side_effect = OSError('disk unavailable')
        self.assertFalse(emit_retained_skill_outcomes_safely(tap, identity, emit))

    def test_empty_export_records_checkpoint_without_claiming_zero_effect(self):
        _, _, identity = self.sample()
        tap = Mock()
        tap.skill_outcome_snapshot.return_value = ()
        emit = Mock()
        self.assertTrue(emit_retained_skill_outcomes_safely(tap, identity, emit))
        self.assertEqual(1, emit.call_count)
        self.assertEqual('pet_skill_capture_checkpoint', emit.call_args.args[0])
        self.assertEqual(0, emit.call_args.kwargs['retainedRecords'])
        self.assertIn('NOT_COMPLETE_EFFECT_COVERAGE', emit.call_args.kwargs['reason'])

    def test_context_hash_mismatch_is_not_silently_used(self):
        state, cap, identity = self.sample()
        ctx = context_fields_safely(identity, state, cap, PolicyConfig())['skillActionContext']
        ctx['player']['mana'] += 1
        with self.assertRaisesRegex(ValueError, 'HASH'):
            check_context(ctx, {}, {})

    def test_oversized_diagnostic_is_omitted_without_touching_gameplay(self):
        state, cap, identity = self.sample()
        cap = replace(cap, element_type='X'*5000)
        self.assertEqual('UNAVAILABLE', context_fields_safely(identity, state, cap, PolicyConfig())['skillActionContext']['status'])


class RetainedSkillSnapshotTests(unittest.TestCase):
    def setUp(self):
        self.target = SimpleNamespace(memory=Mock(), resolver=Mock())
        self.target.resolver.resolve_type_info_class.return_value = 0x123000
        self.tap = DispatcherTransportTap(self.target)

    def test_snapshot_preserves_queue_messages_and_board_attestation(self):
        cap = capture(board=True)
        self.tap._combat_outcomes['M_test', 1, 1] = (None, cap)
        self.tap._pending_combat_outcomes.append(('M_test', cap))
        original = deepcopy(cap.to_dict())
        records = self.tap.skill_outcome_snapshot('M_test', 10)
        self.assertEqual(1, len(records))
        self.assertFalse(records[0]['evidence']['accepted_board_attached'])
        self.assertEqual(original, cap.to_dict())
        self.assertEqual(1, len(self.tap._pending_combat_outcomes))
        self.assertEqual([], self.target.memory.mock_calls)
        self.assertEqual((), self.tap.skill_outcome_snapshot('OTHER', 10))
        self.assertEqual((), self.tap.skill_outcome_snapshot('M_test', 11))

    def test_snapshot_is_bounded_and_records_omission(self):
        for seq in range(11, 15):
            self.tap._combat_outcomes['M_test', seq, 1] = (None, capture(seq))
        records = self.tap.skill_outcome_snapshot('M_test', 10)
        self.assertEqual(2, len(records))
        self.assertEqual('SKILL_SNAPSHOT_EXPORT_LIMIT', records[1]['reason'])
        self.assertEqual(4, len(self.tap._combat_outcomes))
        self.assertEqual([], self.target.memory.mock_calls)

    def test_boardless_and_unavailable_steps_remain_unattested(self):
        cap = capture()
        self.tap._combat_outcomes['M_test', 1, 1] = (None, cap)
        self.assertFalse(self.tap.skill_outcome_snapshot('M_test', 10)[0]['evidence']['accepted_board_attached'])
        raw = envelope('MATCH_SKILL_USE_RES', 12)
        raw['matchPayload'].pop('combatSteps')
        missing = project_combat_outcome(raw, expected_match_id='M_SYNTHETIC', expected_sequence=12,
                                        raw_sha256='a'*64, board_attested=False)
        self.tap._combat_outcomes['M_SYNTHETIC', 2, 2] = (None, missing)
        record = self.tap.skill_outcome_snapshot('M_SYNTHETIC', 10)[0]
        self.assertEqual('UNAVAILABLE', record['status'])
        self.assertEqual('COMBAT_STEPS_ABSENT', record['reason'])
        self.assertIsNone(record['evidence'])


class SkillOutcomeBindingTests(unittest.TestCase):
    def run_case(self, primitive=None, rows=None, *, extra_primitive=None, review_client_windows=False):
        p, r = files_fixture()
        primitive = p if primitive is None else primitive
        rows = r if rows is None else rows
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            path = Path(folder) / 'combat.jsonl'
            original = ''.join(json.dumps(x)+'\n' for x in rows).encode()
            path.write_bytes(original)
            (path.parent/'pet_skill_M_test_turn3.jsonl').write_text(
                ''.join(json.dumps(x)+'\n' for x in primitive), encoding='utf-8')
            if extra_primitive is not None:
                (path.parent/'pet_skill_other.jsonl').write_text(
                    ''.join(json.dumps(x)+'\n' for x in extra_primitive), encoding='utf-8')
            base = extract(path)
            result = bind_file(path, review_client_windows=review_client_windows)
            self.assertEqual(base, result['legacy'])
            self.assertEqual(original, path.read_bytes())
        return result

    def test_boardless_skill_joins_actual_click_and_ordered_effects_without_model_authority(self):
        result = self.run_case()
        self.assertEqual(1, result['summary']['matched'])
        obs = result['skill_observations'][0]
        self.assertEqual(3, len(obs['ordered_steps']))
        self.assertEqual([200, 200], obs['final_card_before_click']['effective_cost'])
        self.assertFalse(obs['training_eligible'])
        self.assertFalse(obs['calibration_eligible'])
        self.assertFalse(obs['skill_action_binding']['acknowledged'])
        self.assertIsNone(obs['prediction'])
        self.assertNotIn('synthetic-player', json.dumps(obs))

    def test_skill_response_cannot_borrow_a_swap_or_proposal(self):
        primitive, rows = files_fixture()
        rows.pop(1)
        self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_success_zero_input_is_not_bound(self):
        primitive, rows = files_fixture()
        primitive.pop(1)
        primitive[-1]['result']['card_clicks'] = 0
        rows[1]['result']['card_clicks'] = 0
        rows[1]['inputSent'] = False
        self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_wrong_actor_card_match_and_stale_sequence_do_not_bind(self):
        for mutate in (
            lambda e: e.update(actor_identity='BOSS'),
            lambda e: e.update(match_id='OTHER'),
            lambda e: e.update(server_sequence=10),
            lambda e: e['card_ids'].update(skillCardId=100),
            lambda e: e['card_ids'].update(skillCardId=None),
            lambda e: e['card_ids'].update(skillCardId=True),
            lambda e: e['card_ids'].update(cardId=100),
        ):
            primitive, rows = files_fixture()
            mutate(rows[-1]['combatOutcome']['evidence'])
            self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_wrong_result_action_id_and_cost_are_not_repaired_by_time(self):
        for change in ('action', 'cost'):
            primitive, rows = files_fixture()
            if change == 'action':
                rows[1]['result']['action_id']['value'] = 'different'
            else:
                rows[0]['requiredMana'] += 1
            self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_multiple_response_batches_keep_binding_unknown(self):
        primitive, rows = files_fixture()
        rows.append(dict(event='dispatcher_combat_outcome', combatOutcome=capture(12).to_dict()))
        result = self.run_case(primitive, rows)
        self.assertEqual(2, result['summary']['responses'])
        self.assertEqual(0, result['summary']['matched'])

    def test_duplicate_export_is_one_observation_not_two_skills(self):
        primitive, rows = files_fixture()
        rows.append(deepcopy(rows[-1]))
        result = self.run_case(primitive, rows)
        self.assertEqual(1, result['summary']['matched'])
        self.assertEqual(1, result['legacy']['duplicate_outcomes'])

    def test_conflicting_primitive_and_changed_session_fail_closed_only_for_data(self):
        primitive, rows = files_fixture()
        other = deepcopy(primitive)
        other[-1]['timestamp'] = 'different retained copy'
        self.assertEqual(0, self.run_case(primitive, rows, extra_primitive=other)['summary']['matched'])
        rows[-1]['sourceSession'] = dict(lifecycle_epoch=2, board_instance=123, match_id='M_test')
        self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_next_action_bounds_late_callback(self):
        primitive, rows = files_fixture()
        other = deepcopy(rows[0])
        other['identity']['source']['srv_seq'] = 11
        rows.insert(2, other)
        self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])

    def test_missing_steps_is_not_zero_damage_or_a_bound_effect(self):
        primitive, rows = files_fixture()
        rows[-1]['combatOutcome'].update(status='UNAVAILABLE', evidence=None)
        result = self.run_case(primitive, rows)
        self.assertEqual([], result['skill_observations'])
        self.assertTrue(result['legacy']['excluded'])

    def test_terminal_primitive_without_post_state_can_retain_explicit_server_effects(self):
        primitive, rows = files_fixture()
        primitive[-1]['result']['post_state'] = None
        rows[1]['result']['post_state'] = None
        result = self.run_case(primitive, rows)
        self.assertEqual(1, result['summary']['matched'])
        self.assertIsNone(result['skill_observations'][0]['resource_endpoint'])
        self.assertFalse(result['skill_observations'][0]['calibration_eligible'])

    def test_current_context_retained_tap_and_binder_work_together(self):
        state = session_state(mana=500, rage=250)
        state = replace(state, battle=replace(state.battle, board_hash='a'*64))
        cap = capability(element='MEGA_TREX', card_id=99)
        identity = AutonomousActionIdentity(AutonomousSource.from_state(state), PolicyAction.PET_SKILL,
                                           (cap.session_key, cap.skill_card_id))
        plain = lambda v: json.loads(json.dumps(v, default=lambda x: x.value if isinstance(x, Enum) else asdict(x)))
        primitive, rows = files_fixture()
        action = primitive[-1]['result']['action_id']
        action.update(match_id=identity.source.session.match_id, session_key=asdict(identity.source.session),
                      source_turn=identity.source.turn)
        primitive[0]['capability'] = plain(asdict(cap))
        primitive[1]['actionId'] = deepcopy(action)
        res = primitive[-1]['result']
        res['telemetry'].update(turn_before=identity.source.turn, turn_after=identity.source.turn+1)
        res['post_state']['battle'].update(session_key=asdict(identity.source.session),
            match_id=identity.source.session.match_id, turn_number=identity.source.turn+1,
            srv_seq=identity.source.srv_seq+1)
        rows[0].update(identity=plain(asdict(identity)),
                       **context_fields_safely(identity, state, cap, PolicyConfig()))
        rows[1].update(identity=plain(asdict(identity)), result=deepcopy(res))
        rows.pop()
        raw = envelope('MATCH_SKILL_USE_RES', identity.source.srv_seq+1)
        raw.update(matchId=identity.source.session.match_id, skillCardId=99)
        raw['matchPayload']['actorUsername'] = identity.source.current_turn_player
        for s in raw['matchPayload']['combatSteps']:
            if s['source'] == 'synthetic-player': s['source'] = identity.source.current_turn_player
            if s['target'] == 'synthetic-player': s['target'] = identity.source.current_turn_player
        captured = project_combat_outcome(raw, expected_match_id=identity.source.session.match_id,
            expected_sequence=identity.source.srv_seq+1,
            raw_sha256=hashlib.sha256(json.dumps(raw).encode()).hexdigest())
        target = SimpleNamespace(memory=Mock(), resolver=Mock())
        target.resolver.resolve_type_info_class.return_value = 0x123000
        tap = DispatcherTransportTap(target)
        tap._combat_outcomes[identity.source.session.match_id, 1, 1] = (None, captured)
        self.assertTrue(emit_retained_skill_outcomes_safely(tap, identity,
            lambda event, **fields: rows.append(dict(event=event, **fields))))
        result = self.run_case(primitive, rows)
        self.assertEqual(1, result['summary']['matched'], result['excluded_skill_inputs'])
        self.assertEqual('RECORDED', result['skill_observations'][0]['pre_skill_context']['status'])
        self.assertEqual([], target.memory.mock_calls)

    def test_missing_wire_card_keeps_strict_unbound_and_separate_opt_in_window(self):
        primitive, rows = client_window_fixture()
        default = self.run_case(primitive, rows)
        self.assertEqual(0, default['summary']['matched'])
        self.assertNotIn('client_card_window_observations', default)
        result = self.run_case(primitive, rows, review_client_windows=True)
        self.assertEqual(0, result['summary']['matched'])
        self.assertEqual(1, result['summary']['client_window_matched'])
        obs = result['client_card_window_observations'][0]
        self.assertEqual('UNKNOWN', obs['skill_action_binding']['wire_card_identity'])
        self.assertFalse(obs['skill_action_binding']['acknowledged'])
        self.assertFalse(obs['training_eligible'])
        self.assertIsNone(obs['prediction'])

    def test_client_window_requires_exact_post_sequence_stable_card_and_export_source(self):
        for field in ('post_seq', 'post_card', 'post_session', 'export_seq', 'context'):
            primitive, rows = client_window_fixture()
            if field == 'post_seq':
                primitive[-1]['result']['post_state']['battle']['srv_seq'] += 1
                rows[1]['result'] = deepcopy(primitive[-1]['result'])
            elif field == 'post_card':
                primitive[2]['capability']['skill_card_id'] = 100
            elif field == 'post_session':
                primitive[2]['capability']['session_key'] = dict(match_id='OTHER')
            elif field == 'export_seq':
                rows[-1]['sourceSrvSeq'] = 9
            else:
                rows[0].pop('skillActionContext')
            result = self.run_case(primitive, rows, review_client_windows=True)
            self.assertEqual(0, result['summary']['client_window_matched'], field)

    def test_partial_terminal_snapshot_cannot_anchor_client_card_window(self):
        primitive, rows = client_window_fixture()
        primitive[-1]['result']['post_state'] = None
        rows[1]['result'] = deepcopy(primitive[-1]['result'])
        result = self.run_case(primitive, rows, review_client_windows=True)
        self.assertEqual(0, result['summary']['client_window_matched'])

    def test_explicit_conflicting_wire_card_is_never_replaced_with_client_card(self):
        primitive, rows = client_window_fixture()
        rows[-1]['combatOutcome']['evidence']['card_ids']['skillCardId'] = 100
        result = self.run_case(primitive, rows, review_client_windows=True)
        self.assertEqual(0, result['summary']['matched'])
        self.assertEqual(0, result['summary']['client_window_matched'])

    def test_known_unavailable_move_outside_window_does_not_poison_valid_skill(self):
        primitive, rows = files_fixture()
        raw = envelope('MATCH_MOVE_RES', 5)
        raw['matchId'] = 'M_test'
        raw['matchPayload'].pop('combatSteps')
        missing = project_combat_outcome(raw, expected_match_id='M_test', expected_sequence=5,
                                        raw_sha256='a'*64).to_dict()
        rows.insert(0, dict(event='dispatcher_combat_outcome', combatOutcome=missing))
        result = self.run_case(primitive, rows)
        self.assertTrue(result['legacy']['excluded'])
        self.assertEqual(1, result['summary']['matched'])

    def test_unknown_move_inside_window_still_blocks_attribution(self):
        primitive, rows = files_fixture()
        raw = envelope('MATCH_MOVE_RES', 11)
        raw['matchId'] = 'M_test'
        raw['matchPayload'].pop('combatSteps')
        missing = project_combat_outcome(raw, expected_match_id='M_test', expected_sequence=11,
                                        raw_sha256='a'*64).to_dict()
        rows.insert(2, dict(event='dispatcher_combat_outcome', combatOutcome=missing))
        self.assertEqual(0, self.run_case(primitive, rows)['summary']['matched'])


if __name__ == '__main__':
    unittest.main()
