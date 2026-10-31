"""Exact P27 source review only. Native H rebinding and live activation pending."""
import ast
import hashlib
from pathlib import Path

from .reasoning_snapshot import digest, require, strict_json_loads
from .reasoning_calibration_review import document, read_ref
from .reasoning_calibration import source_files
from . import reasoning_root_policy as v4
from . import reasoning_timing_review as v3
from .reasoning_config_projection import VERSION

ROOT = Path(__file__).resolve().parents[2]
SCHEMA = "pokiguard.reasoning.config_projection_source_review.v1"
P21_SOURCE = "bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40"
P21_REVIEW = "b9321955dc24b6a0dce8f68c98c66e532884dd2cb2e899f3c5b0caf7fd4d80c7"
CANDIDATE = "b2d6986ec8bcaf6c8fabcd01967e80c6ba5521d87900677204bda67cf430e7ab"
PROOF = "d53329280ab12bbb089812bbe7425fd30e9f15343d73ead116481738878a7ac6"
COMPONENT_COST = "ac004696fc195fdf21fbb8f1c677be6dce01ec6df7a2bb1159278b0461b15e2c"
CHANGED = {"src/pokiguard_v2/reasoning_operational.py",
           "src/pokiguard_v2/reasoning_swap_timing.py", "tools/qualify_reasoning_operational.py",
           "tests/reasoning_controller_fixture.py", "tests/test_reasoning_root_policy.py"}
ADDED = {"src/pokiguard_v2/reasoning_config_projection.py",
         "src/pokiguard_v2/reasoning_projection_review.py",
         "tools/review_reasoning_projection.py", "tests/test_reasoning_config_projection.py"}
APPROVED_START = '82e4fe83348617465228e1727dbd2f59d83384a050f27b6f94f5f0ed3df187ff'
APPROVED_AUTHORITY_METHODS = {'OperationalPilotAuthority.__post_init__': '09853925c20701f88d64689578e64e05797dde859397c3f2097a2c3718f46b1e', 'OperationalPilotAuthority.identity': 'deb24616570a978843795d99396fcab1481b3b544e2ae55a68dd1816cfdb10df', 'load_operational_authority': 'de4eb2cbdeb876342a54ebb9524e4699344f3ea7da07461dcbe07c3a32790f09'}
APPROVED_FILES = {'src/pokiguard_v2/reasoning_config_projection.py': '6ebc6155ed00ab9768457f81d560f60c2a05982507f0ed07136ead6b07a05e24', 'tests/reasoning_controller_fixture.py': '1da5d2361d888aef69de8bc97d321dc7f88f949e50ae5bb7a327f429a6ee921b', 'tests/test_reasoning_config_projection.py': '9452eb0983162a5a735afb2bc0496c58a3fca739eea5975e6675157653b4bdf4', 'tests/test_reasoning_root_policy.py': '0f5b0fb0b99fff6d2ea986811ad64ff68041e8e5a7ee39ea929f975588d487be', 'tools/qualify_reasoning_operational.py': 'b3d0fbd67f94c9db335813fa695c585002d6512542c326ae41038289e7c41cd2', 'tools/review_reasoning_projection.py': 'f48dfafb5ea8f318abdbe6b39bb1acbff71727ba04933e0de9ca3dbd0bbe548e'}
APPROVED_REVIEW_METHODS = {'verify_sources': 'f483d1b5c53ca27c0531379286b8a3a3b72f9d810d1997e79096f18aec55749c', 'verify_review': '7274c43e0bd8e1f8cae941ddba4c9da3c2cbd42143710501f97b4844ed80b9a3', 'validate_costs': '4844562ea81057e3fa5e355aee5fc61f127d0407c6e9e2dc9110f97d8ac45fee'}


def verify_sources(directory, data, *, runtime_sha256, current_root=ROOT):
    before = document(directory, data["parent_manifest"])
    after = document(directory, data["target_manifest"])
    actual = source_files(Path(current_root)); old = before["files"]
    require(digest(old) == before["fingerprint"] == P21_SOURCE
            and after["files"] == actual and digest(actual) == after["fingerprint"]
            == runtime_sha256 == data["target_runtime_sha256"], "complete exact P21/successor source required")
    require(set(old) <= set(actual) and set(actual)-set(old) == ADDED
            and {n for n in old if old[n] != actual[n]} == CHANGED
            and set(data["changes"]) == CHANGED | ADDED, "unreviewed projection successor change")
    require(source_files(Path(directory)/"parent_source") == old, "exact complete frozen P21 source required")
    for name, pair in data["changes"].items():
        require(set(pair) == ({"before", "after"} if name in CHANGED else {"after"}), "missing projection source pair")
        new = read_ref(directory, pair["after"])
        require(hashlib.sha256(new).hexdigest() == actual[name], "projection source bytes changed")
        if name in CHANGED:
            prior = read_ref(directory, pair["before"])
            require(hashlib.sha256(prior).hexdigest() == old[name], "P21 source bytes changed")
        if name == "src/pokiguard_v2/reasoning_swap_timing.py":
            excluded = {"SwapTimingCollector.start"}
            require(v3.protected_ast(prior, excluded) == v3.protected_ast(new, excluded)
                    and v3.methods(new)["SwapTimingCollector.start"] == APPROVED_START,
                    "only reviewed inline config conversion may change")
        elif name == "src/pokiguard_v2/reasoning_operational.py":
            tree = ast.parse(new.decode())
            cls = next(n for n in tree.body if isinstance(n, ast.ClassDef) and n.name == "OperationalPilotAuthority")
            field = [n for n in cls.body if isinstance(n, ast.AnnAssign)
                     and isinstance(n.target, ast.Name) and n.target.id == "config_projection_policy"]
            require(len(field) == 1 and ast.unparse(field[0]) == "config_projection_policy: str | None = None",
                    "exact immutable opt-in field required")
            cls.body.remove(field[0])
            excluded = set(APPROVED_AUTHORITY_METHODS)
            require(v3.protected_ast(prior, excluded) == v3.protected_ast(ast.unparse(tree).encode(), excluded)
                    and {k:v3.methods(new)[k] for k in excluded} == APPROVED_AUTHORITY_METHODS,
                    "unreviewed authority method or protected path")
        elif name == "src/pokiguard_v2/reasoning_projection_review.py":
            require(v3.methods(new) == APPROVED_REVIEW_METHODS, "unreviewed projection verifier body")
        else:
            require(hashlib.sha256(new).hexdigest() == APPROVED_FILES[name], "unreviewed projection file: " + name)
    candidate = v3.pinned(directory, data["candidate"], CANDIDATE)
    helper = read_ref(directory, data["changes"]["src/pokiguard_v2/reasoning_config_projection.py"]["after"])
    require(v3.methods(candidate)["project_config"] == v3.methods(helper)["project_config"],
            "exact proven uncached candidate required")
    return dict(parent_source=P21_SOURCE, target_source=runtime_sha256,
                changed=len(CHANGED), added=len(ADDED), protected_collector_exact=True,
                candidate_function_exact=True, native_acceptance_rebound=False)


def verify_review(directory, data, *, runtime_sha256, host_sha256, current_root=ROOT):
    require(data["schema"] == SCHEMA and data["accepted"] is False
            and data["live_acceptance"] is False and data["input_authority"] is False
            and data["config_projection_policy"] == VERSION
            and data["host_sha256"] == host_sha256
            and data["native_binding"] == "PENDING_H_CONVERSION_BOUNDARY"
            and all(data[k] is None for k in ("native_U_ms", "transport_age_ms", "host_unity_alignment_ms")),
            "source-only successor review required")
    parent = strict_json_loads(v3.pinned(directory, data["parent_review"], P21_REVIEW).decode())
    prior = v4.verify_review(Path(directory)/Path(data["parent_review"]["path"]).parent, parent,
        runtime_sha256=P21_SOURCE, host_sha256=host_sha256,
        game_build_sha256=data["game_build_sha256"], policy_json=data["policy_json"],
        witness=data["proposed_scope_witness"], current_root=Path(directory)/"parent_source")
    sources = verify_sources(directory, data, runtime_sha256=runtime_sha256, current_root=current_root)
    v3.pinned(directory, data["parity_proof"], PROOF)
    v3.pinned(directory, data["component_cost_proof"], COMPONENT_COST)
    result = dict(source_review=sources, historical_native=prior,
        historical_cost_basis_ms=prior["cost_basis_ms"], current_native_cost_basis_ms=None,
        native_binding="PENDING_H_CONVERSION_BOUNDARY", activation_supported=False)
    if "review" in data: require(data["review"] == result, "projection declared review differs")
    return result


def validate_costs(directory, q):
    require(q.get("config_projection_policy") == VERSION, "fresh successor projection costs required")
    rows = [strict_json_loads(l) for l in read_ref(directory, dict(path="pipeline_raw.jsonl",
        sha256=q["raw_sha256"]["pipeline_raw.jsonl"])).decode().splitlines()]
    require(len(rows) == 6000 and all(r["config_projection_policy"] == VERSION for r in rows),
            "successor projection pipeline not measured")
    # Keep all existing32 gates, raw recomputation and root250/final100 checks.
    return v4.validate_costs(directory, q)
