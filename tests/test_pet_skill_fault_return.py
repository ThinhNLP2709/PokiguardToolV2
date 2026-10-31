from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import tempfile
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import FarmRunLimits, FarmRunState, FarmRunStopReason
from pokiguard_v2.pet_skill_shadow import PetSkillCapabilityProvider
from pokiguard_v2.technical_recovery import (
    RecoveryInputDomain, TechnicalFailureReason, TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher, TechnicalRecoveryState,
)
from tests.test_farm_checkpoint import start_run, enter, session
from tests.test_technical_recovery import active_state
from tools import farm_run
from tools import basic_auto_bot as bot
from tests.reasoning_controller_fixture import controller_trace
from tools.basic_auto_bot import (
    SharedCombatRuntime, _dispatch_technical_recovery, _pet_skill_failure_diagnostics,
)


class PetSkillFaultReturnTests(unittest.TestCase):
    def state(self):
        state = active_state()
        return replace(state, battle=replace(state.battle, local_username="happi"))

    def evidence(self, **changes):
        return dict(blocker="PET_SKILL_CAPABILITY_UNAVAILABLE", warmup_seconds=2.1,
                    pending_action=False, evidence_source="native hand diagnosis", **changes)

    def dispatch(self, state=None, evidence=None):
        coordinator = TechnicalRecoveryCoordinator()
        result = TechnicalRecoveryDispatcher(coordinator).dispatch_pet_skill_control_unavailable(
            state or self.state(), **(evidence or self.evidence()))
        return result, coordinator

    def test_exact_profile_failure_locks_gameplay_for_return_only(self):
        accepted, coordinator = self.dispatch()
        self.assertTrue(accepted)
        self.assertTrue(coordinator.gameplay_locked)
        self.assertEqual(coordinator.trigger.reason,
                         TechnicalFailureReason.PET_SKILL_CONTROL_UNAVAILABLE)
        self.assertEqual(coordinator.trigger.failed_session.match_id,
                         self.state().battle.match_id)

    def test_transient_pending_and_unrelated_blockers_do_not_authorize_exit(self):
        for changes in ({"warmup_seconds": 1.999}, {"warmup_seconds": float('nan')},
                        {"warmup_seconds": float('inf')}, {"pending_action": True},
                        {"blocker": "TURN_TIMER_SAFETY_MARGIN"}, {"evidence_source": ""}):
            with self.subTest(changes=changes):
                values=self.evidence(); values.update(changes)
                accepted, coordinator = self.dispatch(evidence=values)
                self.assertFalse(accepted)
                self.assertIsNone(coordinator.trigger)

    def test_stale_boss_terminal_or_unowned_state_does_not_authorize_exit(self):
        for changes in ({"session_key": None}, {"is_local_turn": False},
                        {"current_turn_player": "boss"}, {"local_username": None},
                        {"local_has_left_match": True}, {"match_over": True},
                        {"deferred_game_over": True},
                        {"combat_lifecycle": CombatLifecycleState.LOBBY}):
            with self.subTest(changes=changes):
                state=self.state(); state=replace(state,battle=replace(state.battle,**changes))
                accepted,_=self.dispatch(state=state)
                self.assertFalse(accepted)

    def records(self, reentry=False):
        kinds=[RecoveryInputDomain.RECOVERY_EXIT,RecoveryInputDomain.RECOVERY_CONFIRM]
        if reentry: kinds.append(RecoveryInputDomain.RECOVERY_REENTRY)
        return tuple(SimpleNamespace(domain=k,sent=True,detail="test") for k in kinds)

    def fault_run(self):
        run=start_run(FarmRunLimits(3,1,5),control=True)
        enter(run,session(1))
        self.assertTrue(run.technical_failure("PET_SKILL_CONTROL_UNAVAILABLE"))
        self.assertTrue(run.begin_recovery())
        return run

    def test_fault_exit_is_not_win_loss_graceful_stop_or_new_match(self):
        run=self.fault_run()
        self.assertTrue(run.record_technical_exit(
            self.records(),failure_reason="PET_SKILL_CONTROL_UNAVAILABLE"))
        snapshot=run.snapshot()
        self.assertEqual(snapshot.state,FarmRunState.SAFE_STOP)
        self.assertEqual(snapshot.stop_reason,FarmRunStopReason.COMBAT_SAFE_STOP)
        self.assertEqual(snapshot.technical_exits,1)
        self.assertEqual(snapshot.technical_aborts,1)
        self.assertEqual(snapshot.completed_matches,0)
        self.assertEqual(snapshot.match_attempts,1)
        self.assertIsNone(snapshot.graceful_stop_requested_at)
        self.assertIsNone(run.reserve_entry(foreground=True))

    def test_fault_exit_reentry_or_incomplete_records_are_rejected(self):
        for records in (self.records(True),self.records()[:1]):
            with self.subTest(records=records):
                run=self.fault_run()
                self.assertFalse(run.record_technical_exit(
                    records,failure_reason="PET_SKILL_CONTROL_UNAVAILABLE"))
                self.assertEqual(run.snapshot().technical_exits,0)

    def test_fault_exit_is_not_accepted_outside_recovery(self):
        run=start_run(FarmRunLimits(3,1,5),control=True)
        self.assertFalse(run.record_technical_exit(
            self.records(),failure_reason="PET_SKILL_CONTROL_UNAVAILABLE"))
        self.assertEqual(run.snapshot().total_recovery_inputs,0)

    def test_diagnosis_uses_cached_provider_values_without_poll_or_memory(self):
        provider=SimpleNamespace(
            scan_diagnostics={"nativeCardDiscoveryReason":"pet_skill_control_read_error:exact reason"},
            observed_pet_skill_cards=(),poll=Mock(side_effect=AssertionError("extra poll")))
        capability=SimpleNamespace(status=SimpleNamespace(value="NO_CAPABILITY"),
                                   source="current_runtime_pet_skill_discovery",stale_reason=None)
        d=_pet_skill_failure_diagnostics(provider,capability)
        self.assertEqual(d['capabilityStatus'],'NO_CAPABILITY')
        self.assertIn('exact reason',d['nativeDiscoveryReason'])
        self.assertEqual(d['currentSkillCards'],[])
        provider.poll.assert_not_called()

    def test_existing_dispatcher_handoff_receives_exact_evidence(self):
        dispatcher=Mock(); dispatcher.dispatch_pet_skill_control_unavailable.return_value=True
        runtime=SimpleNamespace(technical_recovery_dispatcher=dispatcher)
        state=self.state(); evidence=self.evidence()
        self.assertTrue(_dispatch_technical_recovery(
            runtime,reason="PET_SKILL_CONTROL_UNAVAILABLE",state=state,
            pet_skill_failure_evidence=evidence))
        dispatcher.dispatch_pet_skill_control_unavailable.assert_called_once_with(state,**evidence)

    def test_outer_runner_accepts_only_clean_return_and_never_resumes(self):
        run=self.fault_run()
        coordinator=Mock()
        coordinator.trigger=SimpleNamespace(
            reason=TechnicalFailureReason.PET_SKILL_CONTROL_UNAVAILABLE,failed_session=None)
        coordinator.snapshot.return_value=SimpleNamespace(
            old_session_invalidated=True,state=TechnicalRecoveryState.RESOLVE_REENTRY_TARGET,
            gameplay_locked=True,new_session=None,new_opening=None,
            trigger=coordinator.trigger,input_records=self.records())
        # _run_recovery begins the RECOVERY_PENDING state itself.
        run.state=FarmRunState.RECOVERY_PENDING
        with patch.object(farm_run.technical_recovery,'run_armed_live_recovery',return_value=4), \
             patch.object(farm_run,'_recovery_args',return_value=SimpleNamespace()):
            result=farm_run._run_recovery(
                run=run,args=SimpleNamespace(),runtime=Mock(),coordinator=coordinator,
                failure_state=None,writer=Mock(directory=Path('unused')),test_only=False)
        self.assertTrue(result)
        self.assertEqual(run.state,FarmRunState.SAFE_STOP)
        self.assertEqual(run.snapshot().match_attempts,1)

    def test_real_combat_loop_hands_fault_to_room_recovery_without_gameplay(self):
        coordinator=TechnicalRecoveryCoordinator()
        dispatcher=TechnicalRecoveryDispatcher(coordinator)
        construct=bot.SharedCombatRuntime
        capability=PetSkillCapabilityProvider().observe(
            observed_at=0.0,current_session=self.state().battle.session_key,
            source_pet=None,candidates=())
        refreshes=0

        def skill(provider,state,resolver):
            nonlocal refreshes
            refreshes+=1
            provider.observed_pet_skill_cards=()
            provider.scan_diagnostics['nativeCardDiscoveryReason']='pet_skill_control_card_missing_or_ambiguous'
            if refreshes==2:bot.time.sleep(2.1)  # synthetic discovery interval
            return capability

        def runtime(*args,**kwargs):
            value=construct(*args,**kwargs)
            return replace(value,gameplay_capability=SimpleNamespace(),
                           technical_recovery_dispatcher=dispatcher)

        with tempfile.TemporaryDirectory() as tmp, \
             patch.object(bot,'SharedCombatRuntime',side_effect=runtime), \
             patch.object(bot,'_current_pet_skill_capability',side_effect=skill):
            state=self.state()
            result,calls,rows=controller_trace(
                Path(tmp)/'combat.jsonl',case='pet_skill_missing',
                profile='mega_icarus_spam_skill',initial_combat=state)
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)
        self.assertIsNotNone(coordinator.trigger,[(r['event'],r.get('reason'),r.get('stopReason')) for r in rows])
        self.assertTrue(any(r['event']=='pet_skill_control_return_to_room' for r in rows))
        self.assertTrue(any(r['event']=='technical_recovery_handoff' for r in rows))
        self.assertFalse(any(r['event']=='auto_pause' for r in rows))


if __name__ == '__main__':
    unittest.main()
