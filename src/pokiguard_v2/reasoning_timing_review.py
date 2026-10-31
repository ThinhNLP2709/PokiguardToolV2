"""File-only P18 reviewed timing lineage. This never grants live activation.

V2 is verified against its original target. Operational observations stay a
separate cost supplement. Complete current source bytes, protected AST paths
and fresh raw costs are checked independently of the declared review result.
"""
import ast
from collections import Counter
import hashlib
import math
from pathlib import Path
import time

from .reasoning_calibration_review import document, read_ref, verify_review, PARAMETERS, WITNESS
from .reasoning_snapshot import canonical_json, digest, FrozenJSON, require, strict_json_loads

SCHEMA = "pokiguard.reasoning.operational_calibration_review.v3"
MONITOR = "POST_RETURN_COMPONENTS_V1"
COMMAND = "TWO_CLICKS_TWO_SETTLES_V1"
QUALIFICATION_GATES = ({"disabled_controller_ast_exact", "historical_sources_exactly_bound",
    "added_cpu_three_checkpoints_under_1_5ms", "admission_cpu_under_1_5ms", "signal_only_stop_under_25ms",
    "worker_reaped", "full_timing_pipeline_latency", "bounded_stress_no_retained_history",
    "final_source_still_frozen", "full_60_second_stress"}
    | {"disabled_trace:"+k for k in ("normal","pending","stale","wrong_turn","stop")}
    | {"checkpoint_latency:"+k for k in ("disabled","completed","timeout","error","fallback")}
    | {"measured_path:"+k for k in ("completed","timeout","error","fallback")}
    | {"admission_latency:"+k for k in ("admitted","span_rejected","clock_rejected","busy")}
    | {"admission_outcome:"+k for k in ("admitted","span_rejected","clock_rejected","busy")})
P15_SOURCE = "10cc39c2e323cb697c0dea4c04b5c541ce4eee0b22342283996c54700126c62a"
P16_SOURCE = "a8aba6c01a3a5fa9eda6d46c1c7f84b4c1e577d080c4d015b0d68c0ebdac1638"
BASE_SHA = "a02d18b71fd92481d409a4a0db3a2e0f9b6947c84db15cd537675342d533c00c"
PROPOSAL_SHA = "e0a120629fe316d0afcc744fede1baf4f1c721ba949869dfa7dbd76eb652bd9c"
ADDENDUM_SHA = "d933912b9cb058be30bc4b99570414d886caf16e5b9626a1a4fbc8d8891bff62"
P15_ARCHIVE_SHA = "f7cdca363aff00b24a52dd2334533727eeb90e9843d9094384871e0c4bad322e"
ROOT = Path(__file__).resolve().parents[2]

# These are exact reviewed changes, never exemptions for whole runtime files.
P18_CHANGED = {"src/pokiguard_v2/reasoning_operational.py",
               "src/pokiguard_v2/reasoning_swap_timing.py",
               "tools/prepare_operational_pilot.py", "tools/qualify_reasoning_operational.py",
               "tests/test_reasoning_operational.py", "tests/reasoning_controller_fixture.py"}
P18_ADDED = {"src/pokiguard_v2/reasoning_timing_review.py",
             "tools/review_reasoning_timing_v3.py", "tests/test_reasoning_timing_review.py"}
EDITED_METHODS = {
    "src/pokiguard_v2/reasoning_operational.py": {
        "command_wait_ms", "load_operational_authority", "OperationalPilotSession._new_bridge"},
    "src/pokiguard_v2/reasoning_swap_timing.py": {
        "SwapTimingCollector.__init__", "SwapTimingCollector._fault", "SwapTimingCollector.finish",
        "SwapTimingCollector._monitor_components"}}
APPROVED_RUNTIME_METHODS = {'src/pokiguard_v2/reasoning_operational.py': {'OperationalPilotSession._new_bridge': '1808498da68e7f2359d50288b1fea7205ed5c6a40460532cf270ab594d0331d6', 'command_wait_ms': '6aeb09c347428e818d18abbfb49f2832d75d9e2779d1087b33c8ff983feda483', 'load_operational_authority': 'fda6c753bddfe71482cd93582da2877c9866df03a31f5e51903a2fc2cd480e31'}, 'src/pokiguard_v2/reasoning_swap_timing.py': {'SwapTimingCollector.__init__': '68a63fefdf5dcdfabfcf416d77899b592f3a6a8ea101867076a70ece96ec3330', 'SwapTimingCollector._fault': 'f00468041ef21940b6e5cd455affdb5ed584c203bef3df7102f13c623d5f00d5', 'SwapTimingCollector._monitor_components': '47406fefe353d4dda08ec248b9667625e3bf38243eb2015082bbb1eb9b1a6e11', 'SwapTimingCollector.finish': '98e399ed4f2e00acf3c16d2208611e60aaaca2962b786329df9ac4574ae07f59'}}


def pinned(directory, ref, expected):
    require(ref["sha256"] == expected, "historical pin changed")
    return read_ref(directory, ref)


def methods(raw):
    tree = ast.parse(raw.decode("utf-8"))
    result = {}
    def visit(nodes, prefix=""):
        for node in nodes:
            if isinstance(node, (ast.FunctionDef, ast.AsyncFunctionDef)):
                result[prefix+node.name] = hashlib.sha256(ast.dump(node, include_attributes=False).encode()).hexdigest()
            elif isinstance(node, ast.ClassDef):
                visit(node.body, prefix+node.name+".")
    visit(tree.body)
    return result


def protected_ast(raw, excluded):
    tree = ast.parse(raw.decode("utf-8"))
    def clean(nodes, prefix=""):
        kept=[]
        for node in nodes:
            name = prefix+getattr(node, "name", "")
            if isinstance(node, (ast.FunctionDef, ast.AsyncFunctionDef)) and name in excluded:
                continue
            if isinstance(node, ast.ClassDef): node.body=clean(node.body, name+".")
            kept.append(node)
        return kept
    tree.body=clean(tree.body)
    return ast.dump(tree, include_attributes=False)


def verify_sources(directory, data, *, runtime_sha256, current_root=ROOT):
    """Exact P16 pairs plus a separately frozen installed P18 successor."""
    from .reasoning_calibration import source_files
    proposal = strict_json_loads(pinned(directory, data["proposal"], PROPOSAL_SHA).decode("utf-8"))
    pinned(directory, data["addendum"], ADDENDUM_SHA)
    p16 = document(directory, data["p16_manifest"])
    require(data["p16_manifest"]["sha256"] == proposal["P16_source_manifest"]["sha256"]
            and digest(p16["files"]) == P16_SOURCE, "P16 manifest changed")
    base = document(directory, data["base_review"])
    compat = document(Path(directory)/Path(data["base_review"]["path"]).parent, base["source_compatibility"])
    before, after = compat["target_files"], p16["files"]
    require(digest(before) == P15_SOURCE and set(before) <= set(after), "P16 source lineage changed")
    expected = proposal["P16_exact_changes"]
    changes = {n for n in before if before[n] != after[n]}
    added = set(after)-set(before)
    require(changes | added == set(expected) == set(data["p16_changes"]), "P16 changes omitted/extended")
    for name, pair in data["p16_changes"].items():
        for stage, ref in pair.items():
            raw = pinned(directory, ref, expected[name][stage]["sha256"])
            require(hashlib.sha256(raw).hexdigest() == (before if stage == "before" else after)[name],
                    "P16 source bytes changed")
        require(set(pair) == set(expected[name]), "P16 before/after omitted")
    target = document(directory, data["target_manifest"])
    actual = source_files(Path(current_root))
    require(target["files"] == actual and digest(actual) == target["fingerprint"] == runtime_sha256
            == data["target_runtime_sha256"], "exact installed target source required")
    require(set(after) <= set(actual) and set(actual)-set(after) == P18_ADDED, "P18 additions/removals changed")
    changed = {n for n in after if after[n] != actual[n]}
    require(changed == P18_CHANGED and set(data["target_changes"]) == changed | P18_ADDED,
            "unreviewed P18 file change")
    for name, pair in data["target_changes"].items():
        require(set(pair) == ({"before", "after"} if name in changed else {"after"}), "target pair omitted")
        new = read_ref(directory, pair["after"])
        require(hashlib.sha256(new).hexdigest() == actual[name], "target bytes changed")
        if name in changed:
            old = read_ref(directory, pair["before"])
            require(hashlib.sha256(old).hexdigest() == after[name], "P18 baseline bytes changed")
            if name in EDITED_METHODS:
                require(protected_ast(old, EDITED_METHODS[name]) == protected_ast(new, EDITED_METHODS[name]),
                        "protected runtime path changed: " + name)
                require({k:methods(new)[k] for k in EDITED_METHODS[name]} == APPROVED_RUNTIME_METHODS[name],
                        "unreviewed body inside runtime file: " + name)
        require(data["target_methods"][name] == methods(new), "exact reviewed method body changed")
    return dict(parent_source=P15_SOURCE, p16_source=P16_SOURCE, target_source=runtime_sha256,
                p16_changed=len(changes), p16_added=len(added), target_changed=len(changed),
                target_added=len(P18_ADDED), protected_methods_exact=True)


def recompute_supplement(directory, data):
    """Rejoin all seven P15 returns, retaining root vetoes and missing coverage."""
    archive = strict_json_loads(pinned(directory, data["p15_archive"], P15_ARCHIVE_SHA).decode("utf-8"))
    refs = data["p15_files"]
    require(len(archive["entries"]) == len(refs) == 93, "complete P15 archive required")
    for item in archive["entries"]:
        name=item["archived"]
        require(name in refs and refs[name]["sha256"] == item["sha256"], "P15 archive omitted/changed")
        require(len(read_ref(directory, refs[name])) == item["bytes"], "P15 raw byte count changed")
    def doc(name): return document(directory, refs["closure/"+name])
    def lines(name): return [strict_json_loads(line) for line in
                            read_ref(directory, refs["closure/"+name]).decode("utf-8").splitlines()]
    session, water = doc("operational_pilot/session.json"), doc("operational_pilot/watermarks.json")
    run=doc("farm_run/run.json")["snapshot"]; attempts=run["attempts"]
    require(run["farm_run_id"] == session["farm_run_id"] and run["match_attempts"] == len(attempts) == 3
            and [a["attempt_index"] for a in attempts] == [1,2,3]
            and session["total_attempt_cap"] == 3 and water["run_id"] == session["run_id"]
            and water["native_U_ms"] is None and water["collector_dropped"] == 0
            and water["collector_disabled"] is False and water["sequence"] == 8
            and len(water["combats"]) == 1, "P15 session/attempt/watermark changed")
    receipt=water["combats"][0]; stats=receipt["after_close"]
    require(all(receipt[k] is True for k in ("bridge_closed","flushed","closed"))
            and stats["accounting_valid"] is True and stats["eligible"] == stats["enqueued"] == stats["written"] == 26
            and all(stats[k] == 0 for k in ("dropped_before_enqueue","failed_write","discarded_after_enqueue","queued","in_writer")),
            "P15 durable raw missing")
    names=[n.removeprefix("closure/") for n in refs if n.startswith("closure/operational_pilot/combat_")
           and "/reasoning." in n and n.endswith(".jsonl")]
    require(len(names) == 1 and names[0].startswith("operational_pilot/combat_0/"), "P15 worker coverage relabeled")
    events=lines(names[0]); require(len(events)==26, "P15 event coverage changed")
    timings=[e for e in events if e["event_type"] in ("reasoning.swap_timing","reasoning.decision_timing")]
    require([e["event_seq"] for e in timings] == list(range(1,9)), "P15 timing sequence changed")
    combats=[lines(f"farm_run/matches/attempt_{j:03d}/combat.jsonl") for j in (1,2,3)]
    intervals=[]; seen=set(); budget=Counter(); selections=[]
    for event in timings:
        require(event["correlation"] == dict(run_id=session["run_id"],mode="OPERATIONAL_PILOT"), "P15 timing relabeled")
        p=event["payload"]
        require(p["native_U_ms"] is None and p["input_parameters"] == PARAMETERS, "P15 UNKNOWN/parameters changed")
        if event["event_type"] == "reasoning.decision_timing":
            require(p["status"] == "SUPERSEDED_BEFORE_PREFLIGHT", "P15 EVOLVE row missing")
            sent=[r for r in combats[0] if r.get("event")=="action_sent" and r.get("action")=="EVOLVE"
                  and r["identity"]["source"]["critical_state_hash"]==p["decision_source_hash"]]
            require(len(sent)==1, "P15 EVOLVE join changed")
            continue
        source=p["autonomous_source"]; key=canonical_json(source)
        require(key not in seen and source["session"]==attempts[0]["session_key"]
                and p["match_id"]==source["session"]["match_id"] and p["turn"]==source["turn"]
                and p["source_hash"]==p["decision_source_hash"]==source["critical_state_hash"], "P15 source identity changed")
        seen.add(key)
        sent=[r for r in combats[0] if r.get("event")=="action_sent" and r.get("action")=="SWAP" and r["identity"]["source"]==source]
        results=[r for r in combats[0] if r.get("event")=="action_result" and r.get("action",{}).get("identity",{}).get("source")==source]
        require(len(sent)==len(results)==1 and sent[0]["identity"]==results[0]["action"]["identity"], "P15 exact sent/result join required")
        require(p["required_input_completed"] is True and p["status"]=="RETURNED" and p["sent_clicks"]==sent[0]["sentClicks"]==2
                and p["click_status"]=="SENT" and p["board_input_mode"]=="two_click"
                and p["preflight_failure"] is None and p["operational_fault"] is None
                and p["clock"]=="host.perf_counter_ns" and p["input_mode"]=="foreground"
                and p["timer_source"]=="MatchService.server_tick", "P15 incomplete input")
        times=[p[k] for k in ("observed_ns","observation_read_end_ns","decision_exit_ns","fresh_checkpoint_ns",
                             "final_checkpoint_ns","preflight_start_ns","read_end_ns","validation_end_ns","executor_return_ns")]
        require(all(type(t) is int and t>=0 for t in times) and times==sorted(times), "P15 clock sequence changed")
        require(p["controller_tail_ns"]==times[5]-times[2] and p["elapsed_upper_bound_ns"]==times[8]-times[5]
                and p["full_tail_ns"]==times[8]-times[2] and p["first_input_ns"] is None
                and p["first_input_status"]=="NOT_MEASURED", "P15 derived intervals changed")
        outcome=results[0]["result"]
        if outcome != "SWAP_ACKNOWLEDGED":
            terminal=attempts[0]["terminal_snapshot"]
            require(outcome=="ACTION_ABORTED_STATE_CHANGED" and results[0]["reason"]=="COMBAT_LIFECYCLE_ENDED"
                    and terminal["session_key"]==source["session"] and terminal["turn_number"]==source["turn"]
                    and terminal["srv_seq"]==source["srv_seq"] and terminal["boss_hp"]==0
                    and terminal["result"]=="WIN" and terminal["confidence"]=="STRONG"
                    and terminal["captured_before_cleanup"] is True, "P15 terminal evidence changed")
        opening=not p["witness"]==WITNESS
        if opening:
            witness=strict_json_loads(canonical_json(WITNESS));witness["loadout"]["cards"]=[]
            require(p["turn"]==1 and p["witness"]==witness, "P15 witness changed")
        budget[p["budget"]["reason"]]+=1
        intervals.append(dict(seq=event["event_seq"],turn=p["turn"],source=source,result=outcome,
            H_ms=(times[5]-times[2])/1e6,I_ms=(times[8]-times[5])/1e6,full_tail_ms=(times[8]-times[2])/1e6,
            root_span_ms=(times[1]-times[0])/1e6,final_span_ms=(times[6]-times[5])/1e6))
    swaps=[sum(r.get("event")=="action_sent" and r.get("action")=="SWAP" for r in rows) for rows in combats]
    require(swaps==[a["swap_sent"] for a in attempts]==[7,5,11] and len(intervals)==7
            and sum(r["root_span_ms"]>100 for r in intervals)==5
            and budget==dict(FALLBACK=1,SOURCE_CHANGED=5,COMPLETED=1), "P15 cost/coverage changed")
    selections=[e["payload"] for e in events if e["event_type"]=="reasoning.decision"]
    require(len(selections)==1 and selections[0]["disposition"]=="RETAIN_BASELINE", "P15 worker outcome changed")
    return dict(scope="OPERATIONAL_SUPPLEMENT_NOT_BASIC_CALIBRATION",source=P15_SOURCE,intervals=intervals,
        maxima_ms={k:max(r[k] for r in intervals) for k in ("H_ms","I_ms","full_tail_ms","root_span_ms","final_span_ms")},
        raw_events=26,timing_rows=8,returns=7,covered_combats=1,attempts=3,missing_swap_timings=16,
        root_span_vetoes=5,budget_counts=dict(budget),completed_worker_jobs=1,
        completed_disposition="RETAIN_BASELINE",live_fault_reason="UNKNOWN_NOT_PERSISTED",native_U_ms=None)


def recompute_review(directory, data, *, runtime_sha256, host_sha256, game_build_sha256, policy_json, witness,
                     current_root=ROOT):
    require(data["schema"]==SCHEMA and data["reasoning_authority"] is False and data["live_acceptance"] is False,
            "v3 review is not activation")
    require(data["target_runtime_sha256"]==runtime_sha256 and data["host_sha256"]==host_sha256
            and data["game_build_sha256"]==game_build_sha256 and data["policy_json"]==policy_json
            and data["proposed_scope_witness"]==witness==WITNESS and data["input_parameters"]==PARAMETERS
            and data["component_monitor"]==MONITOR and data["command_ceiling_version"]==COMMAND,
            "v3 frozen scope/monitor changed")
    require(all(data[k] is None for k in ("native_U_ms","transport_age_ms","host_unity_alignment_ms")), "UNKNOWN must stay null")
    pinned(directory,data["base_review"],BASE_SHA)
    base=document(directory,data["base_review"])
    native=verify_review(Path(directory)/Path(data["base_review"]["path"]).parent,base,
        runtime_sha256=P15_SOURCE,host_sha256=host_sha256,game_build_sha256=game_build_sha256,
        policy_json=policy_json,witness=witness)
    sources=verify_sources(directory,data,runtime_sha256=runtime_sha256,current_root=current_root)
    supplement=recompute_supplement(directory,data)
    return dict(native=native,supplement=supplement,source_review=sources,
        cost_basis_ms={k:max(native["maxima_ms"][k],supplement["maxima_ms"][k]) for k in ("H_ms","I_ms")},
        calibration_samples=26,anchor_samples=20,supplement_samples=7,native_U_ms=None)


def verify_timing_review(directory, data, **bindings):
    result=recompute_review(directory,data,**bindings)
    require(data["review"]==result, "v3 declared review differs from raw evidence")
    return result


def validate_costs(directory, q):
    """Fresh raw cost proof; maxima never establish server/OS hard bounds."""
    from .reasoning_calibration import source_fingerprint
    from .reasoning_operational import host_fingerprint
    # Keep quantile definition identical to the published qualification tool.
    def quantiles(values):
        values=sorted(values); n=len(values)
        return dict(n=n,**{k:values[min(n-1,max(0,math.ceil(p*n)-1))] for k,p in
                           (("p50",.5),("p95",.95),("p99",.99),("max",1))})
    require(q["schema"]=="5d1.p18.qualification.v1" and q["component_monitor"]==MONITOR
            and q["runtime_sha256"]==source_fingerprint(ROOT) and q["host_sha256"]==host_fingerprint(),
            "fresh v3 qualification source/host required")
    require(set(q["raw_sha256"]) == {"checkpoint_raw.jsonl","admission_raw.jsonl","pipeline_raw.jsonl",
                                      "stop_raw.json","source_manifest.json"}, "complete raw qualification pins required")
    for name,sha in q["raw_sha256"].items():
        read_ref(directory,dict(path=name,sha256=sha))
    source=document(directory,dict(path="source_manifest.json",sha256=q["raw_sha256"]["source_manifest.json"]))
    require(digest(source["files"])==source["fingerprint"]==q["runtime_sha256"], "qualification manifest changed")
    cpu={}; maxima=[]
    for file,modes,stats_key,cpu_key in (
        ("checkpoint_raw.jsonl",("disabled","completed","timeout","error","fallback"),"selector_paths_ms","mean_cpu_ms_per_three_checkpoints"),
        ("admission_raw.jsonl",("admitted","span_rejected","clock_rejected","busy"),"admission_paths_ms","admission_mean_cpu_ms")):
        rows=[strict_json_loads(l) for l in read_ref(directory,dict(path=file,sha256=q["raw_sha256"][file])).decode("utf-8").splitlines()]
        require(len(rows)==len(modes)*6000 and {r["path"] for r in rows}==set(modes), "complete cost paths required")
        cpu[cpu_key]={}
        for mode in modes:
            items=[r for r in rows if r["path"]==mode]
            require(all(type(r["index"]) is int for r in items) and [r["index"] for r in items]==list(range(6000))
                    and all(type(r["warmup"]) is bool and r["warmup"]==(r["index"]<1000) for r in items), "warmup/index changed")
            require(all(type(r[k]) in (int,float) and math.isfinite(r[k]) and r[k]>=0 for r in items for k in ("ms","cpu_ms")), "invalid raw cost")
            values=items[1000:]; stats=quantiles([r["ms"] for r in values])
            require(stats==q[stats_key][mode] and all(stats[k]<=v for k,v in zip(("p50","p95","p99","max"),(1.5,3,9,30))), "latency threshold/summary changed")
            mean=sum(r["cpu_ms"] for r in values)/5000
            require(mean==q[cpu_key][mode], "CPU summary changed")
            cpu[cpu_key][mode]=mean
            if mode!="disabled":maxima.append(stats["max"])
    require(max(cpu["mean_cpu_ms_per_three_checkpoints"].values())-cpu["mean_cpu_ms_per_three_checkpoints"]["disabled"]<=1.5
            and max(cpu["admission_mean_cpu_ms"].values())<=1.5, "CPU allowance exceeded")
    rows=[strict_json_loads(l) for l in read_ref(directory,dict(path="pipeline_raw.jsonl",sha256=q["raw_sha256"]["pipeline_raw.jsonl"])).decode("utf-8").splitlines()]
    require(all(type(r["index"]) is int for r in rows) and [r["index"] for r in rows]==list(range(6000))
            and all(type(r["warmup"]) is bool and r["warmup"]==(r["index"]<1000) for r in rows), "collector coverage changed")
    require(all(type(r["ms"]) in (int,float) and math.isfinite(r["ms"]) and r["ms"]>=0 for r in rows), "invalid pipeline cost")
    stats=quantiles([r["ms"] for r in rows[1000:]])
    require(stats==q["full_timing_pipeline_ms"] and all(stats[k]<=v for k,v in zip(("p50","p95","p99","max"),(.5,1,3,10))), "v3 pipeline threshold changed")
    stop=document(directory,dict(path="stop_raw.json",sha256=q["raw_sha256"]["stop_raw.json"]))
    require(len(stop)==1000 and all(type(v) in (int,float) and math.isfinite(v) and v>=0 for v in stop)
            and quantiles(stop)==q["stop_ms"] and max(stop)<25, "Stop cost changed")
    require(q["stress"]["seconds"]>=60 and q["stress"]["max_queued_records"]<=1
            and q["stress"]["peak_traced_bytes"]<16*1024*1024 and q["pass_all"] is True
            and set(q["gates"])==QUALIFICATION_GATES and all(v is True for v in q["gates"].values()),
            "stress/cleanup/trace qualification incomplete")
    return dict(selector_extra_ms=max(maxima)+stats["max"],checkpoint_admission_max_ms=max(maxima),
                full_pipeline_max_ms=stats["max"],raw_values=61000,measured_values=51000,
                stress_evidence="RECEIPT_ONLY_NO_PER_CYCLE_TRACE",completed_branch="RETENTION_ONLY_NO_OVERRIDE_QUOTA")


def load_reviewed_authority(directory, data, calibration, request, *, policy_json, now):
    """Called only after the original loader verified contract/activation/expiry."""
    from .reasoning_operational import OperationalPilotAuthority, command_wait_ms
    require(data["component_monitor"]==MONITOR and data["command_ceiling_version"]==COMMAND
            and data["max_read_span_ms"]==100 and data["host_guard_ms"]==250
            and data["return_margin_ms"]==100 and data["total_attempt_cap"]==3
            and data["input_parameters"]==PARAMETERS,
            "v3 monitor/reserve/cap policy changed")
    pinned(directory,data["timing_addendum"],ADDENDUM_SHA)
    result=verify_timing_review(directory,calibration,runtime_sha256=request.runtime_sha256,
        host_sha256=request.host_sha256,game_build_sha256=request.verified_build_sha256,
        policy_json=policy_json,witness=data["witness"])
    allowance=document(directory,data["selector_allowance"])
    qref=allowance["qualification"]; q=document(directory,qref)
    costs=validate_costs(Path(directory)/Path(qref["path"]).parent,q)
    require(allowance["scope"]=="OFFLINE_REVIEWED_V3_SELECTOR" and allowance["runtime_sha256"]==request.runtime_sha256
            and allowance["host_sha256"]==request.host_sha256 and allowance["costs"]==costs, "v3 allowance changed")
    components=dict(controller_tail_ms=result["cost_basis_ms"]["H_ms"], final_input_ms=result["cost_basis_ms"]["I_ms"],
        selector_extra_ms=costs["selector_extra_ms"],command_wait_ms=command_wait_ms(**data["input_parameters"]),host_guard_ms=250)
    return OperationalPilotAuthority("simple",policy_json,FrozenJSON.of(data["scope"]),FrozenJSON.of(data["witness"]),
        FrozenJSON.of(data["model"]),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data["calibration"]["sha256"],FrozenJSON.of(components),
        FrozenJSON.of(data["input_parameters"]),100,26,time.perf_counter_ns()+int((data["expires_at"]-now)*1e9),
        return_margin_ms=100,budget_ms=data["budget_ms"])
