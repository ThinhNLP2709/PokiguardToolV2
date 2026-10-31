from tests.game_update_fixture import historical_test_view
"""C4 integration: real planner/policy/controller, explicitly fake native IO."""
from dataclasses import FrozenInstanceError, replace
from functools import lru_cache
import hashlib
import importlib.util
import io
import json
from pathlib import Path
import random
import subprocess
import sys
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction, PolicyConfig
from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.board_diagnostics import analyze_game_state, jsonable
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer, LogLimits
from pokiguard_v2.reasoning_planner import plan
from pokiguard_v2.reasoning_runner import Binding, REPLY_SCHEMA, RunnerJob, _decision_summary
from pokiguard_v2.reasoning_selection import (Capability, CompletedProposal, GuardedSelectionAdapter,
    OFFLINE_CONTEXT, Selection, revalidate_safely, select_safely, stop_safely)
from pokiguard_v2.reasoning_shadow import snapshot_from_publication
from pokiguard_v2.reasoning_snapshot import FrozenJSON, canonical_json, digest
from pokiguard_v2.state import BoardState, CellState, GemType
from tests.reasoning_controller_fixture import controller_trace
from tests.test_basic_policy import combat_state
from tools import basic_auto_bot as bot
from tools.evaluate_reasoning_planner import evidence, snapshot

ROOT = Path(__file__).resolve().parents[1]
ARTIFACTS = ROOT / 'docs/phase5/artifacts/5c4_guarded_selection_v1'
NOW = 100_000_000_000


def tactical_combat():
    """Seed 2 generated board; healing model is SYNTHETIC, not observed damage.

    HP40% is above Simple's configured30% branch. R1 may collect Health under
    its explicit proxy instead of BASIC's Sword. This is a selection proof,
    never evidence that an account survives or that healing is20 in the game.
    """
    rng = random.Random(2)
    rows = []
    for y in range(8):
        row = []
        for x in range(8):
            options = [g for g in GemType if g is not GemType.UNKNOWN
                and not (x > 1 and row[x-1] == row[x-2] == g)
                and not (y > 1 and rows[y-1][x] == rows[y-2][x] == g)]
            row.append(rng.choice(options))
        rows.append(row)
    board = BoardState(tuple(tuple(CellState(y, x, g, 1) for x, g in enumerate(row))
                             for y, row in enumerate(rows)))
    state = combat_state(board=board, rage=100)
    return replace(state, player=replace(state.player, hp=40, max_hp=100))


def completed_fixture(state, config, *, reserve_ms=500):
    policy = BasicPolicyEngine(config)
    baseline = policy.decide(state)
    analysis = analyze_game_state(state, policy_engine=policy)
    stream = io.StringIO()
    bot._write(stream, 'policy_decision', **bot._decision_fields(state, baseline, analysis),
               trace=baseline.trace)
    base = snapshot_from_publication(stream.getvalue(), canonical_json(jsonable(config)), 'C4_OFFLINE_RUN')
    source = replace(base.source, controller_generation=7)
    scope = dict(account_binding='SYNTHETIC_ACCOUNT', boss='SYNTHETIC_BOSS',
                 loadout='SYNTHETIC_NORMAL', mode='OFFLINE_INTEGRATION', input_authority=False)
    template = snapshot(board=base.board, baseline=base.baseline, hp=40, rage=100,
        profile=config.play_style.value, model_updates=dict(protection={g:dict(
            points_per_effective=20 if g == 'health' else 0, kind='heal')
            for g in ('health', 'shield', 'drain')}))
    binding = dict(profile=config.play_style.value, session_id=source.session_id,
        match_id=source.match_id, **{k:scope[k] for k in ('account_binding', 'boss', 'loadout')})
    observations = dict(base.observations)
    for name in ('planner.model', 'planner.legality', 'planner.known_boss_threat'):
        old = template.evidence(name)
        observations[name] = evidence(old.value.plain(), old.unit,
            dict(binding, turn=source.turn) if name == 'planner.legality' else binding)
    snap = replace(base, source=source, observations=tuple(sorted(observations.items())),
        intent=replace(base.intent, versions=template.intent.versions, scope=FrozenJSON.of(scope)),
        recorded=FrozenJSON.of(dict(controller_source_hash=AutonomousSource.from_state(state).critical_state_hash)))
    result = plan(snap)  # Completed outside controller.run and its checkpoints.
    job_binding = Binding(snap.snapshot_id, snap.intent.config_hash,
                          canonical_json(source.to_dict()), config.play_style.value)
    job = RunnerJob('C4_OFFLINE_JOB', 7, job_binding, snap, NOW-100_000_000, NOW+3_900_000_000)
    raw = dict(schema=REPLY_SCHEMA, job_id=job.job_id, generation=job.generation,
        binding=vars(job.binding), disposition='USE_CANDIDATE' if result.proposal else 'RETAIN_BASELINE',
        reason=result.reason, proposal=None if result.proposal is None else result.proposal.to_dict(),
        compute_ns=25_000_000, input_authority=False, r2_promotion=False,
        summary=_decision_summary(snap, result, None))
    capability = Capability(config.play_style.value, digest(snap.evidence('planner.model').value.plain()),
        canonical_json({k:scope[k] for k in ('account_binding', 'boss', 'loadout')}),
        reserve_ms, NOW-100_000_000, 12000)
    arguments = dict(job=job, state=state, config=config, capability=capability,
                     completed_ns=NOW-10_000_000)
    return baseline, result, raw, arguments


def prepare(raw, arguments):
    return CompletedProposal.prepare(raw_reply=canonical_json(raw).encode(), **arguments)


def adapter_fixture(state, config, *, reserve_ms=500):
    baseline, result, raw, arguments = completed_fixture(state, config, reserve_ms=reserve_ms)
    completed = prepare(raw, arguments)
    adapter = GuardedSelectionAdapter(completed, enabled=True, diagnostics=DiagnosticBuffer(
        LogLimits(records=432, bytes=6*1024*1024)))
    return adapter, baseline, result, raw, arguments


@lru_cache(maxsize=1)
def original_controller():
    name = 'tools._c4_original_controller'
    spec = importlib.util.spec_from_file_location(name, ARTIFACTS/'before/tools/basic_auto_bot.py')
    module = importlib.util.module_from_spec(spec)
    sys.modules[name] = module
    spec.loader.exec_module(module)
    return module


class SelectionTests(unittest.TestCase):
    def setUp(self):
        from tests.test_reasoning_shadow import publication
        _, base, _, _, _ = publication()
        combat = tactical_combat()
        self.state = replace(combat, battle=base.battle)
        self.config = replace(PolicyConfig(), minimum_turn_time_seconds=1, minimum_evolve_time_seconds=1)
        self.adapter, self.baseline, self.result, self.raw, self.arguments = adapter_fixture(self.state, self.config)
        self.kw = dict(now_ns=NOW, input_allowed=True, context=OFFLINE_CONTEXT)

    def test_real_r1_tactical_override_above_basic_hp_threshold(self):
        self.assertIsNotNone(self.result.proposal)
        self.assertNotEqual(self.result.proposal.move, self.baseline.move)
        selected = self.adapter.select(self.state, self.baseline, self.config, **self.kw)
        self.assertEqual(selected.decision.move, self.result.proposal.move)
        self.assertEqual(selected.decision.trace.selected_candidate.move, self.result.proposal.move)
        self.assertGreater(selected.decision.trace.selected_candidate.total_resources.__len__(), 0)
        self.assertEqual(self.config.low_hp_ratio, .3)
        self.assertEqual(self.state.player.hp/self.state.player.max_hp, .4)
        self.assertEqual(selected.receipt.source, self.adapter.completed.source)

    def test_immutable_completed_config_and_action(self):
        with self.assertRaises(FrozenInstanceError):self.adapter.completed.completed_ns = 0
        with self.assertRaises(FrozenInstanceError):self.config.rage_target = 0
        self.assertEqual(self.arguments['job'].snapshot.intent.settings.text, canonical_json(jsonable(self.config)))

    def test_wire_faults_are_rejected_before_checkpoint(self):
        mutations = [lambda r:r.update(job_id='OLD'), lambda r:r.update(generation=6),
            lambda r:r['binding'].update(config_hash='0'*64), lambda r:r.update(r2_promotion=True),
            lambda r:r.update(input_authority=True), lambda r:r.update(compute_ns=-1),
            lambda r:r['proposal'].update(move=[[0,0],[7,7]]),
            lambda r:r['summary'].update(dispatched_candidate_id='invented')]
        for mutate in mutations:
            with self.subTest(mutate=mutate):
                raw=json.loads(json.dumps(self.raw));mutate(raw)
                with self.assertRaises(ValueError):prepare(raw,self.arguments)

    def test_near_tie_and_nonfinite_summary_cannot_override(self):
        for delta in (.049, float('inf')):
            raw=json.loads(json.dumps(self.raw))
            pair={c['candidate_id']:c for c in raw['summary']['candidates']}
            base=pair[raw['summary']['baseline_candidate_id']]['utility']['high']
            pair[raw['summary']['proposed_candidate_id']]['utility']['low']=base+delta
            pair[raw['summary']['proposed_candidate_id']]['utility']['high']=base+delta
            with self.assertRaises(ValueError):prepare(raw,self.arguments)

    def test_preparation_rejects_missing_reserve_model_and_source(self):
        for change in (dict(completed_ns=NOW+4_000_000_000),
                       dict(config=replace(self.config,rage_target=0)),
                       dict(state=replace(self.state,player=replace(self.state.player,mana=0))),
                       dict(capability=replace(self.arguments['capability'],model_hash='0'*64)),
                       dict(capability=replace(self.arguments['capability'],reserve_ms=12000))):
            with self.subTest(change=change):
                with self.assertRaises(ValueError):prepare(self.raw,dict(self.arguments,**change))

    def test_selection_retains_for_stale_config_late_reserve_owner_and_production(self):
        cases=[('SOURCE_CHANGED',replace(self.state,player=replace(self.state.player,mana=0)),self.config,self.kw),
            ('CONFIG_CHANGED',self.state,replace(self.config,rage_target=0),self.kw),
            ('LATE_PROPOSAL',self.state,self.config,dict(self.kw,now_ns=NOW+4_000_000_000)),
            ('INSUFFICIENT_RESERVE',replace(self.state,battle=replace(self.state.battle,
                turn_time_remaining_seconds=.5)),self.config,self.kw),
            ('EXISTING_OWNER_OR_STOP',self.state,self.config,dict(self.kw,input_allowed=False)),
            ('PRODUCTION_GATED',self.state,self.config,dict(self.kw,context='LIVE'))]
        for reason,state,config,kw in cases:
            with self.subTest(reason=reason):
                answer=self.adapter.select(state,self.baseline,config,**kw)
                self.assertIs(answer.decision,self.baseline)
                self.assertIsNone(answer.receipt);self.assertEqual(answer.reason,reason)

    def test_no_completed_worker_fault_and_opt_in_off_retain(self):
        self.adapter.completed=None
        self.assertEqual(self.adapter.select(self.state,self.baseline,self.config,**self.kw).reason,'NO_COMPLETED_PROPOSAL')
        self.adapter.enabled=False
        self.assertEqual(self.adapter.select(self.state,self.baseline,self.config,**self.kw).reason,'OPT_IN_OFF')

    def test_diagnostic_full_and_exception_fall_back_without_wait(self):
        for kind in ('full','exception','disabled'):
            adapter,baseline,*_=adapter_fixture(self.state,self.config)
            with self.subTest(kind=kind):
                if kind=='disabled':adapter.diagnostics.disable('OFFLINE_DISK_FAULT')
                elif kind=='full':adapter.diagnostics.queued_bytes=adapter.diagnostics.limits.bytes
                with patch.object(adapter.diagnostics,'enqueue',side_effect=OSError('offline')) if kind=='exception' else patch.object(adapter,'enabled',True):
                    selected=select_safely(adapter,self.state,baseline,self.config,**self.kw)
                self.assertIs(selected.decision,baseline);self.assertIsNone(selected.receipt)

    def test_selector_exception_and_malformed_result_do_not_escape(self):
        for effect in ('raise','malformed'):
            with patch.object(self.adapter,'select',side_effect=RuntimeError('offline') if effect=='raise' else None,
                              return_value=object()):
                selected=select_safely(self.adapter,self.state,self.baseline,self.config,**self.kw)
                self.assertIs(selected.decision,self.baseline)
        with patch.object(self.adapter,'revalidate',side_effect=RuntimeError('offline')):
            self.assertEqual(revalidate_safely(self.adapter,self.adapter.completed,self.state,
                self.baseline,self.config,**self.kw),'SELECTOR_EXCEPTION')

    def test_hot_checkpoints_never_run_planner_simulation_or_wait(self):
        with (patch('pokiguard_v2.reasoning_planner.plan',side_effect=AssertionError('planner on checkpoint')),
              patch('pokiguard_v2.reasoning_selection.simulate_move',side_effect=AssertionError('simulation on checkpoint'))):
            selected=self.adapter.select(self.state,self.baseline,self.config,**self.kw)
            self.assertIsNone(self.adapter.revalidate(selected.receipt,self.state,self.baseline,self.config,**self.kw))
            self.assertIsNone(self.adapter.revalidate(selected.receipt,self.state,self.baseline,self.config,
                **self.kw,final=True,final_remaining_seconds=12))

    def test_stop_supersession_and_final_reserve(self):
        receipt=self.adapter.completed
        self.assertEqual(self.adapter.revalidate(receipt,self.state,self.baseline,self.config,
            **self.kw,final=True,final_remaining_seconds=.5),'INSUFFICIENT_RESERVE')
        self.adapter.completed=replace(receipt,completed_ns=receipt.completed_ns+1)
        self.assertEqual(self.adapter.revalidate(receipt,self.state,self.baseline,self.config,**self.kw),'SUPERSEDED_JOB')
        stop_safely(self.adapter)
        self.assertEqual(self.adapter.select(self.state,self.baseline,self.config,**self.kw).reason,'STOPPED')

    def test_other_action_families_and_profiles_remain_with_existing_owner(self):
        for action in (PolicyAction.EVOLVE,PolicyAction.CAST,PolicyAction.PET_SKILL,PolicyAction.PASS):
            baseline=replace(self.baseline,action=action)
            selected=self.adapter.select(self.state,baseline,self.config,**self.kw)
            self.assertIs(selected.decision,baseline);self.assertIsNone(selected.receipt)
        with self.assertRaises(ValueError):replace(self.arguments['capability'],profile='demon_aegis_farm')

    def test_job_deadline_exact_boundary_rejected_without_reset(self):
        deadline=self.adapter.completed.job.deadline_ns
        self.assertIsNotNone(self.adapter.select(self.state,self.baseline,self.config,
            **dict(self.kw,now_ns=deadline-1)).receipt)
        self.assertIsNone(self.adapter.select(self.state,self.baseline,self.config,
            **dict(self.kw,now_ns=deadline)).receipt)
        self.assertEqual(self.adapter.revalidate(self.adapter.completed,self.state,self.baseline,self.config,
            **dict(self.kw,now_ns=deadline),final=True,final_remaining_seconds=12),'LATE_PROPOSAL')

    def test_bounded_separate_diagnostics_have_job_config_and_no_dispatch_claim(self):
        for _ in range(100):self.adapter.select(self.state,self.baseline,self.config,**self.kw)
        rows=[json.loads(raw) for raw in self.adapter.diagnostics.items]
        self.assertEqual(len(rows),8)
        self.assertLess(sum(len(raw) for raw in self.adapter.diagnostics.items),8192)
        self.assertEqual(rows[0]['correlation']['job_id'],'C4_OFFLINE_JOB')
        self.assertFalse(rows[0]['payload']['selected_is_dispatch'])
        self.assertEqual(self.adapter.counts['diagnostic_rate_limited'],92)

    def test_disabled_import_has_no_reasoning_modules(self):
        code="import tools.basic_auto_bot,sys; assert not any(k.startswith('pokiguard_v2.reasoning_') for k in sys.modules)"
        result=subprocess.run([sys.executable,'-c',code],capture_output=True,text=True)
        self.assertEqual(result.returncode,0,result.stderr)


class ControllerSelectionTests(unittest.TestCase):
    def run_case(self, *, case='normal', mutate=None, profile='simple', enabled=True,
                 target_pid=0, initial_combat=None, checkpoint_hook=None):
        box={}
        def factory(state,config):
            adapter,baseline,result,*_=adapter_fixture(state,config,
                reserve_ms=2000 if case in ('reserve_fresh','reserve_final') else 500)
            box.update(adapter=adapter,baseline=baseline,result=result,state=state,config=config)
            adapter.enabled=enabled
            if mutate is not None:mutate(adapter)
            return adapter
        with tempfile.TemporaryDirectory() as folder:
            trace=controller_trace(Path(folder)/'run.jsonl',case=case,initial_combat=initial_combat or tactical_combat(),
                selection_factory=factory,profile=profile,target_pid=target_pid,
                checkpoint_hook=checkpoint_hook)
        return trace,box

    def test_real_completed_override_runs_existing_executor_and_ack(self):
        (result,calls,rows),box=self.run_case()
        self.assertEqual(result,0)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(calls.count('executor.ack'),1)
        sent=next(row for row in rows if row['event']=='action_sent')
        self.assertEqual(sent['identity']['target'],jsonable((box['result'].proposal.move.first,box['result'].proposal.move.second)))
        self.assertNotEqual(box['baseline'].move,box['result'].proposal.move)
        self.assertTrue(box['adapter'].stopped)
        self.assertEqual(box['adapter'].counts['VALID_COMPLETED_R1'],3)

    def test_careful_real_r1_override_is_acknowledged(self):
        (_,calls,rows),box=self.run_case(profile='careful')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertIsNotNone(box['result'].proposal)
        self.assertNotEqual(box['baseline'].move,box['result'].proposal.move)
        self.assertEqual(calls.count('executor.ack'),1)
        self.assertEqual(box['config'].play_style,PlayStyle.CAREFUL)

    def test_existing_read_capture_order_same_with_selected_override(self):
        (selected,calls,_),_=self.run_case()
        with tempfile.TemporaryDirectory() as folder:
            baseline=controller_trace(Path(folder)/'old.jsonl',initial_combat=tactical_combat(),
                                      controller_module=original_controller())
        self.assertEqual(selected,baseline[0]);self.assertEqual(calls,baseline[1])

    def test_disabled_exact_full_controller_parity_with_archived_source(self):
        with tempfile.TemporaryDirectory() as folder:
            for case in ('normal','stale','wrong_turn','pending','stop'):
                with self.subTest(case=case):
                    old=controller_trace(Path(folder)/(case+'_old.jsonl'),case=case,controller_module=original_controller())
                    current=controller_trace(Path(folder)/(case+'_new.jsonl'),case=case)
                    # New default setting is diagnostic metadata, not an input
                    # or a read-order change. Keep every other byte comparable.
                    started=next(r for r in current[2] if r['event']=='auto_controller_started')
                    self.assertEqual(started['config'].pop('demon_target_gem'),'shield')
                    self.assertEqual(current,old)

    def test_late_at_fresh_rebinds_basic_and_sends_once(self):
        (_,calls,rows),box=self.run_case(case='late_fresh')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        fallback=next(row for row in rows if row.get('selectionFallback'))
        self.assertEqual(fallback['selectionFallback'],'LATE_PROPOSAL')
        sent=next(row for row in rows if row['event']=='action_sent')
        self.assertEqual(sent['identity']['target'],jsonable((box['baseline'].move.first,box['baseline'].move.second)))

    def test_insufficient_reserve_at_fresh_uses_basic_with_accepted_floor(self):
        (_,calls,rows),box=self.run_case(case='reserve_fresh')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(next(row for row in rows if row.get('selectionFallback'))['selectionFallback'],
                         'INSUFFICIENT_RESERVE')

    def test_real_planner_retention_keeps_baseline(self):
        (_,calls,rows),box=self.run_case(initial_combat=combat_state())
        self.assertIsNone(box['result'].proposal)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertGreater(box['adapter'].counts['RETAIN_BASELINE'],0)

    def test_fresh_diagnostic_failure_uses_baseline_once(self):
        box={}
        def mutate(adapter):box['adapter']=adapter
        def hook(checkpoint,polls):
            if checkpoint=='poll' and polls==2:box['adapter'].diagnostics.disable('OFFLINE_DISK_FAULT')
        (_,calls,rows),_=self.run_case(mutate=mutate,checkpoint_hook=hook)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(next(row for row in rows if row.get('selectionFallback'))['selectionFallback'],
                         'DIAGNOSTIC_FAILURE')

    def test_invalid_root_logging_failure_production_and_disabled_keep_basic(self):
        mutations=[lambda a:setattr(a,'completed',None),lambda a:a.diagnostics.disable('OFFLINE_DISK_FAILURE')]
        for mutate in mutations:
            (_,calls,rows),box=self.run_case(mutate=mutate)
            self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
            sent=next(row for row in rows if row['event']=='action_sent')
            self.assertEqual(sent['identity']['target'],jsonable((box['baseline'].move.first,box['baseline'].move.second)))
        (_,calls,rows),box=self.run_case(target_pid=123)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertGreater(box['adapter'].counts['PRODUCTION_GATED'],0)
        (_,calls,rows),box=self.run_case(enabled=False)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertGreater(box['adapter'].counts['OPT_IN_OFF'],0)

    def test_stale_wrong_turn_stop_and_expired_final_never_send(self):
        for case in ('stale','wrong_turn','stop','final_late','stats_changed','reserve_final',
                     'stop_after_fresh','stop_before_input'):
            with self.subTest(case=case):
                (_,calls,_),box=self.run_case(case=case)
                self.assertNotIn('FAKE_NORMAL_INPUT',calls)
                self.assertTrue(box['adapter'].stopped)

    def test_pending_keeps_existing_owner_without_baseline_replacement(self):
        (_,calls,rows),box=self.run_case(case='pending')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(box['adapter'].counts['VALID_COMPLETED_R1'],3)
        self.assertNotIn('executor.ack',calls)
        self.assertFalse(any(row.get('selectionFallback') for row in rows))

    @historical_test_view()
    def test_c3_audit_pins_only_documented_c4_controller_change(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        assert_c3_source_compatibility(self)


if __name__ == '__main__':unittest.main()
