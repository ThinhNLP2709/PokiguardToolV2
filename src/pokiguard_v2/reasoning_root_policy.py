"""File-only v4 root-policy review. No game IO, implicit activation or clock proof."""
import ast
from collections import Counter
from dataclasses import replace
import hashlib
from pathlib import Path
import time

from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require, strict_json_loads
from .reasoning_calibration_review import document, read_ref, WITNESS, PARAMETERS
from . import reasoning_timing_review as v3

SCHEMA = "pokiguard.reasoning.operational_calibration_review.v4"
POLICY = dict(version="OPERATIONAL_ROOT250_FINAL100_V1", max_root_poll_span_ms=250,
              max_final_read_span_ms=100)
P18_SOURCE = "b673eab28dfcb1c5d32116d264789b7e5d8b2d9bdc7a2df7dfc469012e2740a9"
P18_REVIEW = "482a1c125d3bb3639476a5bc41a6cc054cf0d68578e671c3a1f2264ee3c385d0"
P20_CONTRACT = "22d5330a70b47d1a7b145a3713dcfdda820af7415f82c9716f3df323f7114bce"
P19_MANIFEST = "123040d8ddc3a95711faba646005728365d9096cfef79b9b4506b4580350fd45"
ROOT = Path(__file__).resolve().parents[2]
CHANGED = {"src/pokiguard_v2/reasoning_operational.py", "src/pokiguard_v2/reasoning_pilot.py",
           "src/pokiguard_v2/reasoning_swap_timing.py", "tools/qualify_reasoning_operational.py",
           "tests/test_reasoning_timing_review.py", "tests/reasoning_controller_fixture.py"}
ADDED = {"src/pokiguard_v2/reasoning_root_policy.py", "tools/review_reasoning_timing_v4.py",
         "tests/test_reasoning_root_policy.py"}
EDITED = {"src/pokiguard_v2/reasoning_operational.py": {
    "OperationalPilotAuthority.__post_init__", "OperationalPilotAuthority.identity",
    "OperationalPilotAuthority.max_root_poll_span_ms", "load_operational_authority"},
    "src/pokiguard_v2/reasoning_pilot.py": {"PilotSelectionBridge.observe"},
    "src/pokiguard_v2/reasoning_swap_timing.py": {"SwapTimingCollector.__init__"}}
# Filled from the final reviewed source, never from a request's declarations.
APPROVED_METHODS = {'src/pokiguard_v2/reasoning_operational.py': {'OperationalPilotAuthority.__post_init__': '7b96cf7c49d7880341a816f52179e9c3f65d4a9cf15661224a624762171ea00c', 'OperationalPilotAuthority.identity': '0eaec1953f78e0e2a9b7e12c7f9128f4f1194aa5524fbbb410a5393380f627ba', 'OperationalPilotAuthority.max_root_poll_span_ms': 'c61e2feee54e570e8574d6a4b0b488d4410b542f33535fab60134d8ebaf8977d', 'load_operational_authority': '7c4efc89e249ef62d23bdd166a33f4214ff9d71abd1c7f776337968e48a8727d'}, 'src/pokiguard_v2/reasoning_pilot.py': {'PilotSelectionBridge.observe': 'cff4d2ff29457b027b4442a8dc61f352445e1ebb195be8a785af975e0e72a5f2'}, 'src/pokiguard_v2/reasoning_root_policy.py': {'load_reviewed_authority': '1d73de9c6fb8f20bae82721a150724f0a561d52b00043676ee1df7300194660d', 'protected': 'dee35a5d4d3a7a5028ba809db6f6a366a6a21731ecccc593036a2fb90ce33448', 'recompute_p19': '3bdaa888f3a3f48282a0f722de43761472cd33163c960c9b327908bf55630317', 'validate_costs': '5697a023451a136842ffc6687fdbf80f0724525570fc4dd6cfdd21c0a3dadb48', 'validate_policy': 'd044cb819a5033f7eaa5372db558e3497705d5ba6e0c12e51b0ca3e50dced4a9', 'verify_review': '7964a9f5e07acce8b2e5e0364e769397d8aecbbd5f2ef7d5f82d2877081bd7ae', 'verify_sources': '7d24c279e7088d3e3d77cd4df8122ae22213ca0bbc48da53b879539919bfdec3'}, 'src/pokiguard_v2/reasoning_swap_timing.py': {'SwapTimingCollector.__init__': '6ff07fc1f58c2d15e4740ea73531aa0093d948a2b40b9a5b9bddcd0bea6366e7'}}
APPROVED_OFFLINE_FILES = {'tests/test_reasoning_root_policy.py': '4884e20e3e948cb8b83f302ca293605f6e0bf84a14257e69258a303a5455e404', 'tests/test_reasoning_timing_review.py': 'ac1a87daf35e3d6189f1e180fcbe538366dd5b47b14d0df4d17ff567b0e9dc85', 'tools/qualify_reasoning_operational.py': '03a36ff34c93e96950b1d46d793e43df8d4ca978d597e96a00490f244c90a736', 'tools/review_reasoning_timing_v4.py': '27f30ca4ac4546828c71769dfddc366348e771dbbc04f1f5ab1069da64bdd739', 'tests/reasoning_controller_fixture.py': '3444dd0dddefd2195b33f4040912d1eaa1655f9b3b0099adc77210992688bf61'}


def validate_policy(value):
    require(type(value) is dict and set(value) == set(POLICY)
            and type(value["version"]) is str
            and type(value["max_root_poll_span_ms"]) is int
            and type(value["max_final_read_span_ms"]) is int and value == POLICY,
            "reviewed root250/final100 policy required")
    return value


def protected(raw, *, new=False, excluded=()):
    tree = ast.parse(raw.decode("utf-8"))
    if new:
        for node in tree.body:
            if isinstance(node, ast.ClassDef) and node.name == "OperationalPilotAuthority":
                fields = [n for n in node.body if isinstance(n, ast.AnnAssign)
                          and isinstance(n.target, ast.Name) and n.target.id == "root_read_policy"]
                require(len(fields) == 1 and ast.unparse(fields[0]) ==
                        "root_read_policy: FrozenJSON | None = None", "unreviewed authority field")
                node.body.remove(fields[0])
    return v3.protected_ast(ast.unparse(tree).encode(), excluded)


def verify_sources(directory, data, *, runtime_sha256, current_root=ROOT):
    from .reasoning_calibration import source_files
    before = document(directory, data["parent_manifest"])
    after = document(directory, data["target_manifest"])
    actual = source_files(Path(current_root))
    require(digest(before["files"]) == before["fingerprint"] == P18_SOURCE
            and after["files"] == actual and digest(actual) == after["fingerprint"]
            == runtime_sha256 == data["target_runtime_sha256"], "complete exact source pair required")
    old = before["files"]
    require(set(old) <= set(actual) and set(actual)-set(old) == ADDED
            and {n for n in old if old[n] != actual[n]} == CHANGED
            and set(data["changes"]) == CHANGED | ADDED, "unreviewed successor file change")
    parent_root = Path(directory)/"parent_source"
    require(source_files(parent_root) == old, "complete frozen P18 source required")
    for name, pair in data["changes"].items():
        require(set(pair) == ({"before", "after"} if name in CHANGED else {"after"}), "missing source pair")
        new = read_ref(directory, pair["after"])
        require(hashlib.sha256(new).hexdigest() == actual[name], "successor source bytes changed")
        if name in CHANGED:
            prior = read_ref(directory, pair["before"])
            require(hashlib.sha256(prior).hexdigest() == old[name], "parent bytes changed")
            if name in EDITED:
                require(protected(prior, excluded=EDITED[name]) ==
                        protected(new, new=True, excluded=EDITED[name]), "protected path changed: " + name)
        if name in EDITED or name == "src/pokiguard_v2/reasoning_root_policy.py":
            names = EDITED.get(name, set(v3.methods(new)))
            require({k:v3.methods(new)[k] for k in names} == APPROVED_METHODS[name],
                    "unreviewed method body: " + name)
        else:
            require(hashlib.sha256(new).hexdigest() == APPROVED_OFFLINE_FILES[name],
                    "unreviewed offline file: " + name)
    return dict(parent_source=P18_SOURCE, target_source=runtime_sha256,
                changed=len(CHANGED), added=len(ADDED), protected_methods_exact=True)


def recompute_p19(directory, data):
    manifest = strict_json_loads(v3.pinned(directory, data["p19_manifest"], P19_MANIFEST).decode())
    refs = data["p19_files"]
    require(set(refs) == {"run", "watermarks"} | {f"reasoning{i}" for i in range(3)}
            | {f"combat{i}" for i in range(3)}, "complete P19 evidence required")
    def raw(role):
        item = refs[role]
        require(manifest["artifact_files"][item["original"]] == item["sha256"], "P19 lineage changed")
        return read_ref(directory, item)
    run = strict_json_loads(raw("run").decode())["snapshot"]
    water = strict_json_loads(raw("watermarks").decode())
    require(run["match_attempts"] == run["completed_matches"] == len(run["attempts"]) == 3
            and run["wins"] == 3 and run["total_swap_sent"] == 30
            and run["stop_reason"] == "FARM_TARGET_COMPLETED"
            and water["session"]["first_fault"] is None and water["session"]["faulted"] is False
            and water["sequence"] == 33 and len(water["combats"]) == 3,
            "P19 ledger/cleanup changed")
    samples=[]; sequence=[]; jobs=[]
    for i in range(3):
        rows=[strict_json_loads(l) for l in raw(f"reasoning{i}").decode().splitlines()]
        combat=[strict_json_loads(l) for l in raw(f"combat{i}").decode().splitlines()]
        sent={canonical_json(x["identity"]["source"]):x for x in combat
              if x.get("event")=="action_sent" and x.get("action")=="SWAP"}
        ts=[x for x in rows if x["event_type"]=="reasoning.swap_timing"]
        require(len(ts)==len(sent)==run["attempts"][i]["swap_sent"], "P19 SWAP omitted")
        receipt=water["combats"][i]; stats=receipt["after_close"]
        require(receipt["healthy"] and all(receipt[k] for k in ("bridge_closed","flushed","closed"))
                and stats["eligible"]==stats["enqueued"]==stats["written"]==len(rows)
                and all(stats[k]==0 for k in ("dropped_before_enqueue","failed_write","discarded_after_enqueue","queued","in_writer"))
                and stats["accounting_valid"] is True, "P19 durable events changed")
        sequence.extend(x["event_seq"] for x in rows if x["event_type"] in
                        ("reasoning.swap_timing","reasoning.decision_timing"))
        jobs.append(sum(x["event_type"]=="reasoning.decision" for x in rows))
        for event in ts:
            t=event["payload"]; source=canonical_json(t["autonomous_source"])
            require(source in sent and t["status"]=="RETURNED" and t["sent_clicks"]==2
                    and t["required_input_completed"] and t["component_fault"] is None
                    and t["operational_fault"] is None and t["native_U_ms"] is None,
                    "P19 source/input/fault changed")
            results=[x for x in combat if x.get("event")=="action_result"
                     and canonical_json((x.get("action") or {}).get("identity",{}).get("source"))==source]
            require(len(results)==1 and (results[0]["result"]=="SWAP_ACKNOWLEDGED" or
                    (results[0].get("reason")=="COMBAT_LIFECYCLE_ENDED"
                     and run["attempts"][i]["terminal_boss_hp"]==0
                     and run["attempts"][i]["terminal_local_hp"]>0)), "P19 ACK/terminal changed")
            samples.append(dict(H_ms=(t["preflight_start_ns"]-t["decision_exit_ns"])/1e6,
                I_ms=(t["executor_return_ns"]-t["preflight_start_ns"])/1e6,
                reason=t["budget"]["reason"]))
    require(sorted(sequence)==list(range(1,34)) and jobs==[7,1,0] and len(samples)==30
            and Counter(x["reason"] for x in samples)==dict(COMPLETED=8,FALLBACK=3,OBSERVATION_READ_SPAN_EXCEEDED=19),
            "P19 coverage/retentions changed")
    return dict(scope="P19_SOURCE294_OPERATIONAL_SUPPLEMENT", returns=30, attempts=3,
                jobs=jobs, root_vetoes=19, unknown_U=None,
                maxima_ms={k:max(x[k] for x in samples) for k in ("H_ms","I_ms")})


def verify_review(directory, data, *, runtime_sha256, host_sha256, game_build_sha256,
                  policy_json, witness, current_root=ROOT):
    require(data["schema"]==SCHEMA and data["reasoning_authority"] is False
            and data["live_acceptance"] is False, "v4 review is not activation")
    validate_policy(data["root_read_policy"])
    require(data["host_sha256"]==host_sha256 and data["game_build_sha256"]==game_build_sha256
            and data["policy_json"]==policy_json and data["proposed_scope_witness"]==witness==WITNESS
            and data["input_parameters"]==PARAMETERS and data["component_monitor"]==v3.MONITOR
            and data["command_ceiling_version"]==v3.COMMAND
            and all(data[k] is None for k in ("native_U_ms","transport_age_ms","host_unity_alignment_ms")),
            "v4 frozen binding changed")
    v3.pinned(directory,data["root_policy_contract"],P20_CONTRACT)
    parent=strict_json_loads(v3.pinned(directory,data["parent_review"],P18_REVIEW).decode())
    prior=v3.verify_timing_review(Path(directory)/Path(data["parent_review"]["path"]).parent,
        parent,runtime_sha256=P18_SOURCE,host_sha256=host_sha256,game_build_sha256=game_build_sha256,
        policy_json=policy_json,witness=witness,current_root=Path(directory)/"parent_source")
    sources=verify_sources(directory,data,runtime_sha256=runtime_sha256,current_root=current_root)
    p19=recompute_p19(directory,data)
    basis={k:max(prior["cost_basis_ms"][k],p19["maxima_ms"][k]) for k in ("H_ms","I_ms")}
    result=dict(parent=prior,source_review=sources,p19=p19,cost_basis_ms=basis,
                calibration_samples=26,anchor_samples=20,supplement_samples=7,p19_samples=30,native_U_ms=None)
    if "review" in data: require(data["review"]==result, "v4 declared review differs from raw")
    return result


def validate_costs(directory,q):
    require(q.get("root_read_policy")==POLICY, "fresh v4 policy costs required")
    result=v3.validate_costs(directory,q)
    rows=[strict_json_loads(l) for l in read_ref(directory,
        dict(path="admission_raw.jsonl",sha256=q["raw_sha256"]["admission_raw.jsonl"])).decode().splitlines()]
    expected=dict(admitted=250_000_000,span_rejected=250_000_001,clock_rejected=-1,busy=250_000_000)
    require(all(r["root_read_policy"]==POLICY and r["read_span_ns"]==expected[r["path"]] for r in rows),
            "successor admission path not measured")
    return result


def load_reviewed_authority(directory,data,calibration,request,*,policy_json,now):
    from .reasoning_operational import OperationalPilotAuthority, command_wait_ms
    validate_policy(data["root_read_policy"])
    require("review" in calibration, "declared v4 review required")
    v3.pinned(directory,data["root_policy_contract"],P20_CONTRACT)
    activation=document(directory,data["activation_review"])
    require(activation["root_read_policy"]==data["root_read_policy"]==calibration["root_read_policy"]
            and activation["calibration_sha256"]==data["calibration"]["sha256"]
            and activation["root_policy_contract_sha256"]==P20_CONTRACT
            and activation["selector_allowance_sha256"]==data["selector_allowance"]["sha256"],
            "independent root policy activation required")
    require(data["max_read_span_ms"]==100 and data["host_guard_ms"]==250
            and data["return_margin_ms"]==100 and data["total_attempt_cap"]==3
            and data["component_monitor"]==v3.MONITOR and data["command_ceiling_version"]==v3.COMMAND
            and data["input_parameters"]==PARAMETERS, "final/monitor/reserve policy changed")
    v3.pinned(directory,data["timing_addendum"],v3.ADDENDUM_SHA)
    result=verify_review(directory,calibration,runtime_sha256=request.runtime_sha256,
        host_sha256=request.host_sha256,game_build_sha256=request.verified_build_sha256,
        policy_json=policy_json,witness=data["witness"])
    allowance=document(directory,data["selector_allowance"]);qr=allowance["qualification"]
    q=document(directory,qr);costs=validate_costs(Path(directory)/Path(qr["path"]).parent,q)
    require(allowance["scope"]=="OFFLINE_REVIEWED_V4_SELECTOR"
            and allowance["root_read_policy"]==POLICY and allowance["costs"]==costs
            and allowance["runtime_sha256"]==request.runtime_sha256
            and allowance["host_sha256"]==request.host_sha256, "v4 allowance changed")
    components=dict(controller_tail_ms=result["cost_basis_ms"]["H_ms"],final_input_ms=result["cost_basis_ms"]["I_ms"],
        selector_extra_ms=costs["selector_extra_ms"],command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority("simple",policy_json,FrozenJSON.of(data["scope"]),FrozenJSON.of(data["witness"]),
        FrozenJSON.of(data["model"]),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data["calibration"]["sha256"],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,26,time.perf_counter_ns()+int((data["expires_at"]-now)*1e9),
        return_margin_ms=100,budget_ms=data["budget_ms"],root_read_policy=FrozenJSON.of(POLICY))
