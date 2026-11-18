"""Common saved outcomes: typed effects are observations, never model authority."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.combat_outcome_evidence import actor_identity
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_observation_normalization import cases
from tools.normalize_action_outcomes import checked,extract,raw_ledger,summarize


def fixture():
    case=cases()[0]
    return case['sent'],case['capture']


def step(kind,amount,*,idx=0,target=None,after=None,**extra):
    who=actor_identity('SYNTHETIC_NATIVE_ACTOR')
    return dict(kind=kind,amount=amount,idx=idx,source=who,target=target or who,
        after=after,damage_source=None,full_power=None,**extra)


class ActionOutcomeNormalizationTests(unittest.TestCase):
    def test_native_operations_remain_raw_and_do_not_create_a_boss_decision_label(self):
        sent,capture=fixture();e=capture['evidence']
        e.update(actor_identity='BOSS',wire_swap=None,
            swap_operations=[dict(operation_index=2,type='SWAP',native_swap=[1,2,1,3])],
            swap_operation_source='matchPayload.ops[].data',swap_operation_decision_binding='UNKNOWN')
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual(e['swap_operations'],obs['swap_operations'])
        self.assertEqual('UNBOUND',obs['action_binding']['status'])
        self.assertIn('SWAP_OPERATION_DECISION_BINDING_UNKNOWN',obs['observation_limits'])
        for bad in (dict(native_swap=[1,2,1,6]),dict(operation_index=True),dict(type='SOMETHING')):
            other=deepcopy(capture);other['evidence']['swap_operations'][0].update(bad)
            self.assertTrue(self.run_case(sent,other)['excluded'])

    def extract_rows(self,rows):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            path=Path(d)/'combat.jsonl';path.write_text(''.join(json.dumps(r)+'\n' for r in rows),encoding='utf-8')
            return extract(path)

    def run_case(self,sent=None,capture=None,*,ack=True,extra=()):
        default_sent,default_capture=fixture()
        sent=default_sent if sent is None else sent;capture=default_capture if capture is None else capture
        rows=[dict(event='auto_controller_started',config=dict(play_style='simple')),sent]
        rows.extend(extra)
        rows.append(dict(event='dispatcher_combat_outcome',combatOutcome=capture))
        if ack:rows.append(dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=sent['identity'])))
        return self.extract_rows(rows)

    def test_style_and_activation_are_not_prerequisites_for_typed_effect_observation(self):
        result=self.run_case()
        self.assertFalse(result['excluded']);self.assertEqual(1,len(result['observations']))
        obs=result['observations'][0]
        self.assertEqual('EXACT_SWAP_SENT_ACK',obs['action_binding']['status'])
        kinds={s['kind'] for s in obs['effect_totals']}
        self.assertIn('DAMAGE',kinds);self.assertIn('POWER',kinds)
        self.assertFalse(obs['calibration_eligible']);self.assertFalse(obs['training_eligible'])
        self.assertIsNone(obs['prediction']);self.assertFalse(obs['input_authority'])

    def test_block_heal_and_hp_damage_stay_separate(self):
        sent,capture=fixture();who=actor_identity(sent['identity']['source']['current_turn_player'])
        sent['boss'].update(hp=500,shield=50)
        capture['evidence']['steps']=[step('BLOCK',50,target='BOSS',after={'SHIELD':0}),
            step('DAMAGE',100,idx=1,target='BOSS',after={'HP':400}),
            step('HEAL',25,idx=2,target='BOSS',after={'HP':425})]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual([('BLOCK',50),('DAMAGE',100),('HEAL',25)],
            [(r['kind'],r['observed_amount']) for r in obs['effect_totals']])
        self.assertEqual([-50,-100,25],[r['observed_delta'] for r in obs['raw_ledger']])
        self.assertNotIn('estimated_damage',obs)

    def test_cap_pattern_does_not_promote_requested_gain_to_actual_gain_or_training(self):
        sent,capture=fixture();sent['player'].update(power=220,max_power=250)
        capture['evidence']['steps']=[step('POWER',140,after={'POWER':250})]
        obs=self.run_case(sent,capture)['observations'][0];ledger=obs['raw_ledger'][0]
        self.assertEqual('CAP_PATTERN_OBSERVED',ledger['status'])
        self.assertEqual((140,30),(ledger['reported_amount'],ledger['observed_delta']))
        self.assertEqual('CLAMP_SEMANTICS_NOT_VERIFIED',ledger['reason'])
        self.assertFalse(obs['calibration_eligible']);self.assertFalse(obs['training_eligible'])

    def test_overkill_and_zero_hp_are_censored_without_rewriting_reported_damage(self):
        sent,capture=fixture();sent['boss']['hp']=100
        capture['evidence']['steps']=[step('DAMAGE',300,target='BOSS',after={'HP':0})]
        obs=self.run_case(sent,capture,ack=False)['observations'][0]
        self.assertEqual('ZERO_FLOOR_PATTERN_OBSERVED',obs['raw_ledger'][0]['status'])
        self.assertEqual(300,obs['effect_totals'][0]['observed_amount'])
        self.assertEqual(['BOSS'],obs['zero_hp_targets']);self.assertIn('ZERO_HP_CENSORED',obs['observation_limits'])

    def test_unknown_steal_after_is_not_assigned_to_sender_or_receiver(self):
        sent,capture=fixture();who=actor_identity(sent['identity']['source']['current_turn_player'])
        capture['evidence']['steps']=[step('STEAL',90,target='BOSS',after={'POWER':175}),
            step('POWER',20,idx=1,after={'POWER':195})]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertIn('STEAL_TYPE_MISSING',obs['observation_limits'])
        self.assertEqual('UNINTERPRETED',obs['raw_ledger'][0]['status'])
        self.assertEqual('BASELINE_UNKNOWN',obs['raw_ledger'][1]['reason'])
        self.assertIsNone(obs['raw_ledger'][1]['observed_delta'])

    def test_lowercase_or_unknown_after_keys_are_preserved_without_alias_guessing(self):
        sent,capture=fixture();capture['evidence']['steps']=[step('HEAL',100,after={'hp':1234})]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual({'hp':1234},obs['steps'][0]['after'])
        self.assertEqual('RAW_AFTER_KEY_MISSING',obs['raw_ledger'][0]['reason'])

    def test_boardless_skill_is_typed_but_not_bound_to_a_swap_or_given_zero_board_effect(self):
        sent,capture=fixture();capture['evidence'].update(event_type='MATCH_SKILL_USE_RES',wire_swap=None)
        capture['evidence']['steps']=[step('DAMAGE',200,target='BOSS',after={'HP':100})]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual('UNBOUND',obs['action_binding']['status'])
        self.assertEqual('CARD_SKILL_SENT_ACK_BINDING_NOT_VERIFIED',obs['action_binding']['reason'])
        self.assertNotIn('board_after',obs);self.assertFalse(obs['training_eligible'])

    def test_boss_effect_is_not_labeled_with_our_previous_last_move(self):
        sent,capture=fixture();capture['evidence'].update(actor_identity='BOSS',wire_swap=None)
        capture['evidence']['steps']=[dict(step('DAMAGE',200,after={'HP':400}),source='BOSS')]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual('BOSS_MOVE_NOT_IDENTIFIED',obs['action_binding']['reason'])
        self.assertIsNone(obs['action_binding']['source']);self.assertIsNone(obs['wire_swap'])
        self.assertEqual('BASELINE_UNKNOWN',obs['raw_ledger'][0]['reason'])

    def test_optional_full_power_and_steal_type_remain_unknown_for_old_records(self):
        sent,capture=fixture();s=step('STEAL',10,after={'MANA':1});s.pop('full_power')
        capture['evidence']['steps']=[s]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertIsNone(obs['steps'][0]['full_power']);self.assertIsNone(obs['steps'][0]['steal_type'])

    def test_duplicate_capture_paths_dedupe_but_conflicting_identity_is_excluded(self):
        sent,capture=fixture();duplicate=deepcopy(capture)
        duplicate['evidence']['accepted_board_attached']=not capture['evidence'].get('accepted_board_attached',False)
        duplicate['evidence']['provenance']='ANOTHER_DIAGNOSTIC_PATH'
        result=self.run_case(sent,capture,extra=[dict(combatOutcome=duplicate)])
        self.assertEqual(1,result['duplicate_outcomes']);self.assertEqual(1,len(result['observations']))
        for key,value in [('amount',999),('full_power',False)]:
            other=deepcopy(capture);other['evidence']['steps'][0][key]=value
            result=self.run_case(sent,capture,extra=[dict(combatOutcome=other)])
            self.assertFalse(result['observations']);self.assertEqual('CONFLICTING_OUTCOME_IDENTITY',result['excluded'][0]['reason'])

    def test_wrong_match_actor_sequence_or_duplicate_input_does_not_bind(self):
        for mutate in (lambda e:e.update(match_id='OTHER'),
                lambda e:e.update(actor_identity='BOSS'),lambda e:e.update(server_sequence=18)):
            sent,capture=fixture();mutate(capture['evidence'])
            result=self.run_case(sent,capture)
            self.assertEqual('UNBOUND',result['observations'][0]['action_binding']['status'])
        sent,capture=fixture();duplicate=deepcopy(sent)
        result=self.run_case(sent,capture,extra=[duplicate])
        self.assertEqual('AMBIGUOUS_SOURCE_ACTION',result['observations'][0]['action_binding']['reason'])

    def test_next_action_of_another_family_bounds_the_response_window(self):
        sent,capture=fixture();other=deepcopy(sent)
        other['identity']['source']['srv_seq']=19;other['identity']['action']='pet_skill';other['selectedAction']='pet_skill'
        result=self.run_case(sent,capture,extra=[other])
        self.assertEqual('UNBOUND',result['observations'][0]['action_binding']['status'])

    def test_wrong_ack_target_or_no_ack_is_not_confirmed(self):
        sent,capture=fixture();other=deepcopy(sent['identity']);other['target']=[[0,0],[0,1]]
        result=self.run_case(sent,capture,ack=False,extra=[dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=other))])
        self.assertEqual('SENT_WITHOUT_EXACT_ACK',result['observations'][0]['action_binding']['status'])

    def test_two_distinct_responses_in_one_action_window_remain_unbound(self):
        sent,capture=fixture();second=deepcopy(capture)
        second['evidence']['server_sequence']+=2
        result=self.run_case(sent,capture,extra=[dict(combatOutcome=second)])
        self.assertEqual(2,len(result['observations']))
        self.assertTrue(all(o['action_binding']['reason']=='AMBIGUOUS_RESPONSE_WINDOW' for o in result['observations']))

    def test_unproven_stat_ownership_does_not_supply_a_numeric_baseline(self):
        sent,capture=fixture();sent['player']['is_local']=None
        capture['evidence']['steps']=[step('POWER',20,after={'POWER':95})]
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertEqual('BASELINE_UNKNOWN',obs['raw_ledger'][0]['reason'])

    def test_malformed_older_action_does_not_crash_a_later_valid_observation(self):
        sent,capture=fixture()
        rows=[dict(event='action_sent',identity=None),sent,dict(combatOutcome=capture),
            dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=sent['identity']))]
        self.assertEqual('EXACT_SWAP_SENT_ACK',self.extract_rows(rows)['observations'][0]['action_binding']['status'])

    def test_malformed_types_and_oversized_steps_are_evidence_errors_only(self):
        for change in (lambda e:e.update(server_sequence=True),lambda e:e.update(actor_identity='raw-name'),
                lambda e:e['steps'][0].update(amount=True),lambda e:e['steps'][0].update(full_power=1),
                lambda e:e['steps'][0].update(after=[]),lambda e:e['steps'][0].update(steal_type=1),
                lambda e:e.update(steps=e['steps']*129)):
            sent,capture=fixture();change(capture['evidence'])
            result=self.run_case(sent,capture)
            self.assertFalse(result['observations']);self.assertTrue(result['excluded'])

    def test_incomplete_steps_unknown_kinds_and_missing_baselines_do_not_become_zero(self):
        sent,capture=fixture();capture['evidence']['steps']=[step('FUTURE_KIND',5,idx=1,after={'HP':3})]
        result=self.run_case(sent,capture);obs=result['observations'][0]
        self.assertEqual('FUTURE_KIND',obs['effect_totals'][0]['kind'])
        self.assertIn('INCOMPLETE_STEP_INDEX',obs['observation_limits'])
        self.assertEqual('UNINTERPRETED',obs['raw_ledger'][0]['status'])
        summary=summarize([result]);self.assertEqual(0,summary['models_fitted']);self.assertEqual(0,summary['training_eligible'])

    def test_input_records_are_not_mutated_and_output_removes_plain_username(self):
        sent,capture=fixture();original=deepcopy((sent,capture))
        checked(capture);self.assertEqual(original,(sent,capture))
        obs=self.run_case(sent,capture)['observations'][0]
        self.assertNotIn(sent['identity']['source']['current_turn_player'],json.dumps(obs))


if __name__=='__main__':unittest.main()
