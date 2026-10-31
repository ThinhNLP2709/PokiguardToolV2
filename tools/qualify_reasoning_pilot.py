"""D1-P1 file-only qualification; native surfaces are forbidden/faked.

Positive controller trials explicitly pre-admit a frozen fixture BEFORE run().
They prove the real worker/selector wiring, NOT timely first-root selection in
the game. This tool neither calibrates native input nor enables the desktop UI.
"""
from __future__ import annotations

import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import sys
import tempfile
import time
import unittest

ROOT = Path(__file__).resolve().parents[1]
for directory in (ROOT, ROOT / "src", ROOT / "tests"):
    sys.path.insert(0, str(directory))

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyConfig
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge, create_pilot_bridge
from pokiguard_v2.reasoning_selection import select_safely
from pokiguard_v2.reasoning_snapshot import canonical_json, digest
from tests.reasoning_controller_fixture import assert_c3_source_compatibility, controller_trace
from tests.test_reasoning_pilot import MemorySink, await_completed, pilot_authority, scoped_state
from tests.test_reasoning_selection import original_controller
from tools.qualify_reasoning_selection import controller_ast_audit, quantiles

ARTIFACTS = ROOT / "docs/phase5/artifacts/5d1_production_bridge_v1"


def write_json(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, indent=2, ensure_ascii=False) + "\n", encoding="utf-8")


def export_offer(out, bridge):
    offer = bridge.completed
    s = offer.job.snapshot
    body = dict(source=s.source.to_dict(), board=s.board, recorded=s.recorded.plain(),
        config=s.intent.settings.plain(), baseline=s.baseline.to_dict(), baseline_reason=s.baseline_reason)
    assert digest(body) == s.provenance.record_sha256
    path = out / s.provenance.path
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(canonical_json(body), encoding="utf-8")
    assert hashlib.sha256(path.read_bytes()).hexdigest() == s.provenance.file_sha256
    write_json(out / "offer.json", dict(snapshot=s.to_dict(), job_id=offer.job.job_id,
        generation=offer.job.generation, created_ns=offer.job.created_ns,
        deadline_ns=offer.job.deadline_ns, completed_ns=offer.completed_ns,
        disposition=offer.reply.disposition, reason=offer.reply.reason,
        proposal=None if offer.reply.proposal is None else offer.reply.proposal.to_dict(),
        summary=json.loads(offer.reply.summary_json), timing=bridge.completed_history))


def qualify(out):
    if (out / "qualification.json").exists():
        raise ValueError("retain recorded evidence; use a new output directory")
    out.mkdir(parents=True, exist_ok=True)
    gates, traces, receipts = {}, [], []
    audit = controller_ast_audit()
    gates["controller_ast_exact_without_optional_hooks"] = audit["pass_ast"] and audit["pass_counts"]
    assert_c3_source_compatibility(unittest.TestCase())
    gates["historical_c3_c4_and_side_fix_binding"] = True
    before = json.loads((ARTIFACTS / "before_source_manifest.json").read_text(encoding="utf-8"))["files"]
    current = {p.relative_to(ROOT).as_posix(): hashlib.sha256(p.read_bytes()).hexdigest()
        for folder in ("src", "tests", "tools") for p in (ROOT / folder).rglob("*.py")}
    changed = sorted(name for name, sha in before.items() if current.get(name) != sha)
    expected = sorted(("src/pokiguard_v2/reasoning_selection.py", "tools/basic_auto_bot.py",
        "tests/reasoning_controller_fixture.py", "tools/qualify_reasoning_selection.py"))
    gates["only_four_existing_python_files_changed"] = changed == expected
    added = sorted(set(current) - set(before))
    gates["only_four_declared_python_files_added"] = added == sorted((
        "src/pokiguard_v2/reasoning_pilot.py", "src/pokiguard_v2/reasoning_pilot_contract.py",
        "tests/test_reasoning_pilot.py", "tools/qualify_reasoning_pilot.py"))
    write_json(out / "source_manifest.json", dict(files=dict(sorted(current.items())),
        fingerprint=digest(current), changed_parent_files=changed, added=added,
        parent_file_count=len(before), preserved_parent_files=len(before) - len(changed)))

    with tempfile.TemporaryDirectory() as directory:
        temp = Path(directory)
        for case in ("normal", "stale", "wrong_turn", "pending", "stop"):
            old = controller_trace(temp / (case + "_old.jsonl"), case=case,
                                   controller_module=original_controller())
            new = controller_trace(temp / (case + "_new.jsonl"), case=case)
            gates["disabled_complete_trace_parity:" + case] = old == new
            traces.append(dict(mode="DISABLED_PAIR", case=case, old=old, current=new))

        for profile, case, ready, pid in (("simple", "normal", True, 0),
                ("careful", "normal", True, 0), ("simple", "normal", False, 0),
                ("simple", "stale", True, 0), ("simple", "pending", True, 0),
                ("simple", "stop_before_input", True, 0), ("simple", "normal", True, 123)):
            holder = {}
            def factory(state, config):
                a = pilot_authority(state, config)
                bridge = PilotSelectionBridge(authority=a, diagnostics=MemorySink(),
                    verified_build_sha256=a.game_build_sha256, enabled=True)
                holder["bridge"] = bridge
                if ready:
                    now = time.perf_counter_ns()
                    bridge.observe(state, config, observed_ns=now, read_end_ns=now, context=a.context)
                    await_completed(bridge)  # Fixture setup only, never controller.run.
                return bridge
            label = f"{profile}_{case}_ready{ready}_pid{pid}"
            try:
                result = controller_trace(temp / (label + ".jsonl"), initial_combat=scoped_state(),
                    profile=profile, case=case, selection_factory=factory, target_pid=pid,
                    real_processing_clock=True)
                bridge = holder["bridge"]
                calls, rows = result[1:]
                selected = any(r["event"] == "policy_decision" and
                    r.get("policyStep") == "REASONING_R1_SWAP" for r in rows)
                if case == "normal" and ready and pid == 0:
                    gates["producer_worker_root_fresh_final_ack:" + profile] = (
                        selected and bridge.counts["VALID_COMPLETED_R1"] == 3
                        and calls.count("FAKE_NORMAL_INPUT") == calls.count("executor.ack") == 1
                        and bridge.runner.counters["processes"] == 1)
                    old = controller_trace(temp / (label + "_old.jsonl"), initial_combat=scoped_state(),
                        profile=profile, controller_module=original_controller())
                    gates["selected_read_capture_input_order:" + profile] = calls == old[1]
                    export_offer(out / label, bridge)
                elif not ready:
                    gates["first_fresh_root_immediate_basic"] = (not selected and
                        calls.count("FAKE_NORMAL_INPUT") == 1 and bridge.counts["NO_COMPLETED_PROPOSAL"] == 1)
                elif pid != 0:
                    gates["fake_authority_real_pid_gated"] = not selected and bridge.counts["PRODUCTION_GATED"] == 1
                elif case == "pending":
                    gates["pending_no_replacement"] = calls.count("FAKE_NORMAL_INPUT") == 1 and "executor.ack" not in calls
                else:
                    gates[case + "_no_input"] = "FAKE_NORMAL_INPUT" not in calls
                traces.append(dict(mode="NATIVE_BOUNDARY_FAKES", label=label,
                    preadmitted_before_run=ready, actual_worker=True, observed_override=selected, trace=result))
            finally:
                bridge = holder.get("bridge")
                if bridge is not None:
                    gates["cleanup:" + label] = bridge.close()
                    receipts.append(dict(label=label, worker=dict(bridge.runner.counters),
                        selector=dict(bridge.counts), bridge=dict(bridge.bridge_counts),
                        timing=bridge.completed_history, memory_sink=bridge.sink.buffer.stats(),
                        memory_sink_is_durable=False))

    # Exercise native-context validation using an explicitly SYNTHETIC
    # attestation and NO native IO; this is not native calibration evidence.
    state = scoped_state()
    config = PolicyConfig(minimum_turn_time_seconds=1, minimum_evolve_time_seconds=1)
    state = replace(state, battle=replace(state.battle, turn_timer_source="MatchService.server_tick"))
    a = replace(pilot_authority(state, config, minimal_model=True),
        calibration_origin="NATIVE_INPUT_CALIBRATED", timer_source="MatchService.server_tick")
    bridge = PilotSelectionBridge(authority=a, diagnostics=MemorySink(),
        verified_build_sha256=a.game_build_sha256, enabled=True)
    try:
        context = bridge.controller_context(target_pid=123, shared_runtime=True)
        now = time.perf_counter_ns()
        bridge.observe(state, config, observed_ns=now, read_end_ns=now, context=context)
        offer = await_completed(bridge)
        baseline = BasicPolicyEngine(config).decide(state)
        selection = select_safely(bridge, state, baseline, config, now_ns=time.perf_counter_ns(),
                                 input_allowed=True, context=context)
        gates["native_context_faked_attestation_minimal_model_retains_unknown"] = (
            context == a.context and offer.reply.proposal is None and selection.receipt is None
            and bridge.last_snapshot.evidence("planner.known_boss_threat").availability == "MISSING")
        export_offer(out / "native_context_SYNTHETIC_ATTESTATION_ONLY", bridge)
        timings = {"admission_ns": [], "ready_validation_ns": []}
        validation_reasons = []
        for _ in range(1000):
            start = time.perf_counter_ns()
            bridge.observe(state, config, observed_ns=now, read_end_ns=now, context=context)
            timings["admission_ns"].append(time.perf_counter_ns() - start)
            start = time.perf_counter_ns()
            validation_reasons.append(bridge._reason(offer, state, baseline, config,
                                                     offer.completed_ns + 1, True, context))
            timings["ready_validation_ns"].append(time.perf_counter_ns() - start)
        gates["timed_ready_validation_reaches_retain_baseline"] = set(validation_reasons) == {"RETAIN_BASELINE"}
        write_json(out / "software_timings.json", dict(raw=timings, validation_reason="RETAIN_BASELINE",
            quantiles={k: quantiles(v) for k, v in timings.items()},
            scope="method-only repeated immutable fixture; NOT native execution/whole-app SLO"))
    finally:
        gates["native_context_fake_cleanup"] = bridge.close()

    # Actual capped disk sink; only this sink's write ACK is a durable receipt.
    state = scoped_state()
    a = pilot_authority(state, config)
    bridge = create_pilot_bridge(enabled=True, authority=a, verified_build_sha256=a.game_build_sha256,
                                 directory=out / "isolated_disk_sink")
    if bridge is None:
        gates["owned_disk_sink_created"] = False
    else:
        try:
            now = time.perf_counter_ns()
            bridge.observe(state, config, observed_ns=now, read_end_ns=now, context=a.context)
            await_completed(bridge)
            select_safely(bridge, state, BasicPolicyEngine(config).decide(state), config,
                          now_ns=time.perf_counter_ns(), input_allowed=True, context=a.context)
            deadline = time.perf_counter() + 3
            while time.perf_counter() < deadline and bridge.bridge_counts["relayed_not_durable"] < 2:
                time.sleep(.005)  # Offline evidence collector only.
            flushed = bridge.sink.flush()
            stats = bridge.sink.buffer.stats()
            disk_events = [json.loads(line)["event_type"]
                for path in (out / "isolated_disk_sink").glob("*.jsonl")
                for line in path.read_text(encoding="utf-8").splitlines()]
            gates["actual_disk_write_ack"] = (flushed and stats["written"] >= 2
                and stats["accounting_valid"] and stats["queued"] == stats["in_writer"] == 0
                and {"reasoning.decision", "reasoning.selection"}.issubset(disk_events))
            write_json(out / "disk_watermarks.json", dict(stats=stats, disk_events=disk_events,
                relayed_not_durable=bridge.bridge_counts["relayed_not_durable"],
                scope="one offline fixture; not CPU/RAM/tail/soak requalification"))
        finally:
            gates["owned_bridge_cleanup"] = bridge.close()
            gates["owned_disk_sink_cleanup"] = bridge.sink.close()

    write_json(out / "controller_traces.json", traces)
    write_json(out / "pipeline_receipts.json", receipts)
    result = dict(mode="OFFLINE_INTEGRATION_NATIVE_BOUNDARY_FAKES", gates=gates,
        passed=sum(bool(v) for v in gates.values()), total=len(gates),
        offline_gates_pass=all(gates.values()), controller_ast=audit,
        milestone_result="PARTIAL", live_attempts=0, native_input_calibrated=False,
        native_observed_overrides=0, desktop_activation_enabled=False,
        timely_first_root_override_proved=False,
        limitations=["positive controller fixtures need pre-admission before run",
            "native-context attestation is synthetic and only exercises validation",
            "minimal actual-effect model retained BASIC in this fixture",
            "native U/reserve/input tail and operator cohort still unmeasured/unbound",
            "new bridge scheduling/log overhead not whole-app/soak qualified"])
    write_json(out / "qualification.json", result)
    return result


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--out", type=Path, default=ARTIFACTS / "qualification_v1")
    args = parser.parse_args()
    result = qualify(args.out)
    print(json.dumps({k: result[k] for k in ("offline_gates_pass", "passed", "total", "milestone_result")}))
    raise SystemExit(0 if result["offline_gates_pass"] else 1)
