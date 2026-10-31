"""Explicit operational pilot, separate from finite-U proof authority.

Local timing projections do not bound server age, pause/FX or OS scheduling.
No game reader, native input or implicit activation lives in this module.
"""
from __future__ import annotations

from dataclasses import dataclass, field
import hashlib
import json
import math
from pathlib import Path
import time

from .board_diagnostics import jsonable
from .reasoning_pilot_contract import PilotAuthority, runtime_witness
from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require, strict_json_loads

CONTEXT = "BOUNDED_R1_OPERATIONAL_SWAP_PILOT"
SCHEMA = "pokiguard.reasoning.operational_pilot.v1"
ORIGIN = "NATIVE_OPERATIONAL_CALIBRATED"
COMPONENTS = {"controller_tail_ms", "final_input_ms", "selector_extra_ms",
              "command_wait_ms", "host_guard_ms"}


def _sha(value):
    require(type(value) is str and len(value) == 64 and
            all(c in "0123456789abcdef" for c in value), "pinned SHA256 required")


def _finite(value, *, minimum=0):
    require(type(value) in (int, float) and math.isfinite(value) and value >= minimum,
            "finite operational timing required")


def command_wait_ms(*, cursor_settle_seconds, mouse_button_hold_seconds):
    from .win32_input import MAX_TAP_SELECTION_INTER_CLICK_DELAY_SECONDS
    _finite(cursor_settle_seconds); _finite(mouse_button_hold_seconds)
    require(cursor_settle_seconds <= .25 and mouse_button_hold_seconds <= 1,
            "unsupported input parameters")
    # Deliberately added even though calibration already contains actual waits.
    return 1000 + MAX_TAP_SELECTION_INTER_CLICK_DELAY_SECONDS * 1000 + (
        2 * cursor_settle_seconds + 2 * mouse_button_hold_seconds) * 1000


def operational_deadline_ns(*, observed_ns, remaining_ms, now_ns, reserve_ms,
                            return_margin_ms=100, configured_ms=4000):
    """One t0-based deadline; UNKNOWN U is not represented by a fake zero."""
    values = (remaining_ms, reserve_ms, return_margin_ms, configured_ms)
    if (any(type(v) not in (int, float) or not math.isfinite(v) or v <= 0 for v in values)
            or type(observed_ns) is not int or type(now_ns) is not int
            or not 0 <= observed_ns <= now_ns or not 50 <= configured_ms <= 6000
            or return_margin_ms < 100):
        return None
    limit = min(observed_ns + int(configured_ms * 1e6),
                observed_ns + int((remaining_ms - reserve_ms - return_margin_ms) * 1e6))
    return limit if limit - now_ns >= 50_000_000 else None


@dataclass(frozen=True)
class OperationalPilotAuthority:
    profile: str
    policy_json: str
    scope: FrozenJSON
    witness: FrozenJSON
    model: FrozenJSON
    game_build_sha256: str
    runtime_sha256: str
    host_sha256: str
    contract_sha256: str
    decision_sha256: str
    calibration_sha256: str
    reserve_components: FrozenJSON
    input_parameters: FrozenJSON
    max_read_span_ms: float
    calibration_samples: int
    valid_until_ns: int
    return_margin_ms: float = 100
    budget_ms: int = 4000
    timer_source: str = "MatchService.server_tick"
    input_mode: str = "foreground"
    board_mode: str = "two_click"
    calibration_origin: str = ORIGIN
    root_read_policy: FrozenJSON | None = None
    config_projection_policy: str | None = None
    component_guard_policy: str | None = None
    action_profile: FrozenJSON | None = None
    demon_profile: FrozenJSON | None = None
    _reserve_ms: float = field(init=False, repr=False, compare=False)

    def __post_init__(self):
        config = FrozenJSON(self.policy_json).plain()
        d2 = self.action_profile is not None
        d3 = self.demon_profile is not None
        from .reasoning_mega import is_mega
        mega=is_mega(self)
        require(not (d2 and d3), 'one reasoning profile owner required')
        if d3:
            from .reasoning_demon import validate_profile
            validate_profile(self.demon_profile, self.witness)
        if d2:
            from .reasoning_full_actions import validate_profile
            validate_profile(self.action_profile, self.witness)
        require(self.profile in (("demon_aegis_farm",) if d3 else ("mega_icarus_spam_skill",) if mega else ("skill_rush",) if d2 else ("simple", "careful")) and config["play_style"] == self.profile
                and config["intelligence"] == "basic", "scoped BASIC incumbent required")
        require([config[k] for k in ("main_pet", "evolution", "damage_card")]
                == (["normal", "none", "pet_passive"] if d3 else ["normal", "mega", "pet_skill"] if mega else ["legendary", "none", "pet_skill"] if d2 else ["normal", "normal", "default_attack"]), "unsupported pilot loadout")
        require(type(self.scope) is FrozenJSON and set(self.scope.plain()) ==
                {"account_binding", "boss", "loadout"} and all(type(v) is str and
                v.strip().upper() not in ("", "UNKNOWN", "NOT_PUBLISHED")
                for v in self.scope.plain().values()), "explicit cohort required")
        require(type(self.witness) is FrozenJSON and set(self.witness.plain()) ==
                {"account_username_sha256", "boss", "loadout"}, "runtime witness required")
        require(type(self.model) is FrozenJSON and self.model.plain() ==
                {"version": "5b2.scoped_inputs.v1"}, "no operational numerical effects")
        for value in (self.game_build_sha256, self.runtime_sha256, self.host_sha256,
                      self.contract_sha256, self.decision_sha256, self.calibration_sha256):
            _sha(value)
        require(self.calibration_origin == ORIGIN and self.timer_source == "MatchService.server_tick"
                and (self.input_mode, self.board_mode) == ("foreground", "two_click"),
                "operational native context required")
        require(type(self.calibration_samples) is int and 1 <= self.calibration_samples <= 512,
                "native reserve samples required")
        require(type(self.valid_until_ns) is int and self.valid_until_ns > 0, "frozen host expiry required")
        require(type(self.budget_ms) is int and 50 <= self.budget_ms <= 6000, "bounded budget required")
        _finite(self.return_margin_ms, minimum=100); _finite(self.max_read_span_ms, minimum=.001)
        if self.root_read_policy is not None:
            from .reasoning_root_policy import validate_policy
            require(type(self.root_read_policy) is FrozenJSON, "immutable root policy required")
            validate_policy(self.root_read_policy.plain())
            require(self.max_read_span_ms == 100, "final read policy must remain100ms")
        if self.config_projection_policy is not None:
            from .reasoning_config_projection import VERSION
            require(type(self.config_projection_policy) is str and self.config_projection_policy == VERSION
                    and self.root_read_policy is not None, "exact successor config projection/root policy required")
        if self.component_guard_policy is not None:
            from .reasoning_component_guard import VERSION
            require(type(self.component_guard_policy) is str and self.component_guard_policy==VERSION
                    and (self.config_projection_policy is not None or ((d2 or d3) and self.root_read_policy is not None)),
                    "explicit current shared guard policy required")
        components = self.reserve_components.plain()
        require(set(components) == COMPONENTS, "complete operational reserve required")
        for value in components.values(): _finite(value)
        _finite(components["host_guard_ms"], minimum=250)
        require(components["final_input_ms"] > 0, "native final input measurement required")
        parameters = self.input_parameters.plain()
        require(set(parameters) == {"cursor_settle_seconds", "mouse_button_hold_seconds"},
                "exact input parameter witness required")
        require(components["command_wait_ms"] == command_wait_ms(**parameters),
                "BASIC fallback commanded waits must be covered")
        object.__setattr__(self, "_reserve_ms", max(1000, config["minimum_turn_time_seconds"]*1000,
                                                   sum(components.values())))

    @property
    def reserve_ms(self):
        return self._reserve_ms

    @property
    def native_U_ms(self): return None

    @property
    def context(self):
        from .reasoning_mega import is_mega,CONTEXT as MEGA_CONTEXT
        if is_mega(self):return MEGA_CONTEXT
        if self.demon_profile is not None:
            from .reasoning_demon import CONTEXT as D3_CONTEXT
            return D3_CONTEXT
        if self.action_profile is not None:
            from .reasoning_full_actions import CONTEXT as D2_CONTEXT
            return D2_CONTEXT
        return CONTEXT

    @property
    def identity(self):
        data = jsonable(self)
        if self.root_read_policy is None:
            data.pop("root_read_policy")  # Historical identities stay exact.
        if self.config_projection_policy is None:
            data.pop("config_projection_policy")  # Legacy identities stay exact.
        if self.component_guard_policy is None:
            data.pop("component_guard_policy")  # Historical identities stay exact.
        if self.action_profile is None:
            data.pop("action_profile")
        if self.demon_profile is None:
            data.pop("demon_profile")
        return digest(data)

    @property
    def max_root_poll_span_ms(self):
        return self.max_read_span_ms if self.root_read_policy is None else 250

    def matches(self, state, config):
        if self.demon_profile is not None:
            from .reasoning_demon import structural_witness
            return (time.perf_counter_ns() < self.valid_until_ns
                and canonical_json(jsonable(config)) == self.policy_json
                and structural_witness(runtime_witness(state,config).plain()) == structural_witness(self.witness.plain())
                and [getattr(state.player,k) for k in ('max_hp','max_mana','max_power','attack')]
                    == self.demon_profile.plain()['player_stats']
                and state.battle.turn_timer_source == self.timer_source)
        if self.action_profile is not None:
            from .reasoning_full_actions import structural_witness
            return (time.perf_counter_ns() < self.valid_until_ns
                and canonical_json(jsonable(config)) == self.policy_json
                and structural_witness(runtime_witness(state,config).plain()) == structural_witness(self.witness.plain())
                and state.battle.turn_timer_source == self.timer_source)
        return (time.perf_counter_ns() < self.valid_until_ns
                and canonical_json(jsonable(config)) == self.policy_json
                and runtime_witness(state, config) == self.witness
                and state.battle.turn_timer_source == self.timer_source)


def is_pilot_authority(value):
    return type(value) in (PilotAuthority, OperationalPilotAuthority)


def native_model_required(authority):
    return (type(authority) is OperationalPilotAuthority or
            authority.calibration_origin == "NATIVE_INPUT_CALIBRATED")


def authority_margin(authority):
    return (authority.return_margin_ms if type(authority) is OperationalPilotAuthority
            else authority.uncertainty_ms + authority.return_margin_ms)


def authority_deadline(authority, *, observed_ns, remaining_ms, slice_started_ns, now_ns):
    if type(authority) is OperationalPilotAuthority:
        return operational_deadline_ns(observed_ns=observed_ns, remaining_ms=remaining_ms,
            now_ns=now_ns, reserve_ms=authority.reserve_ms,
            return_margin_ms=authority.return_margin_ms, configured_ms=authority.budget_ms)
    from .reasoning_runner import deadline_ns
    return deadline_ns(observed_ns=observed_ns, remaining_ms=remaining_ms,
        slice_started_ns=slice_started_ns, now_ns=now_ns, reserve_ms=authority.reserve_ms,
        uncertainty_ms=authority.uncertainty_ms, return_margin_ms=authority.return_margin_ms,
        configured_ms=authority.budget_ms)


@dataclass(frozen=True)
class OperationalArtifactRequest:
    path: str
    sha256: str
    verified_build_sha256: str
    runtime_sha256: str
    host_sha256: str
    contract_sha256: str
    decision_sha256: str
    full_config_sha256: str
    activation_sha256: str

    def __post_init__(self):
        require(Path(self.path).is_absolute(), "absolute operational request required")
        for key, value in vars(self).items():
            if key != "path": _sha(value)


def _document(directory, reference, *, cap=512*1024):
    p = (directory / reference["path"]).resolve()
    require(p.is_relative_to(directory.resolve()) and p.is_file() and p.stat().st_size <= cap,
            "bounded local provenance required")
    raw = p.read_bytes()
    require(hashlib.sha256(raw).hexdigest() == reference["sha256"], "provenance changed")
    return raw


def load_operational_authority(request, *, policy_json, now=None):
    """Setup-only, no finite-U report or promotion from old clock observations."""
    require(type(request) is OperationalArtifactRequest, "explicit operational request required")
    path = Path(request.path)
    require(path.is_file() and path.stat().st_size <= 512*1024, "bounded operational artifact required")
    raw = path.read_bytes(); require(hashlib.sha256(raw).hexdigest() == request.sha256, "artifact changed")
    data = strict_json_loads(raw.decode("utf-8")); now = time.time() if now is None else now
    require(data["schema"] == SCHEMA and data["origin"] == ORIGIN, "operational schema required")
    for k in ("created_at", "expires_at"): _finite(data[k])
    require(data["created_at"] <= now < data["expires_at"] and
            data["expires_at"] - data["created_at"] <= 7200, "expired operational request")
    for k in ("runtime_sha256", "host_sha256", "contract_sha256", "decision_sha256",
              "full_config_sha256", "activation_sha256"):
        require(data[k] == getattr(request, k), "request binding changed: " + k)
    require(data["game_build_sha256"] == request.verified_build_sha256
            and data["policy_json"] == policy_json, "build/policy changed")
    require(all(data.get(k, "MISSING") is None for k in
                ("native_U_ms", "transport_age_ms", "host_unity_alignment_ms")), "native U must remain UNKNOWN")
    contract = _document(path.parent, data["contract"])
    decision_raw = _document(path.parent, data["decision"])
    require(hashlib.sha256(contract).hexdigest() == request.contract_sha256 and
            hashlib.sha256(decision_raw).hexdigest() == request.decision_sha256, "unpinned acceptance")
    decision = strict_json_loads(decision_raw.decode("utf-8"))
    require(decision["accepted"] is True and decision["contract_sha256"] == request.contract_sha256
            and decision["scope"] == "OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY", "contract decision missing")
    # Acceptance of implementation is not activation: a separately reviewed,
    # expiring request pins its bounded run and full DesktopConfig.
    require(data["activation"] == "EXPLICIT_BOUNDED_PILOT_REQUEST" and
            type(data["total_attempt_cap"]) is int and (1 <= data["total_attempt_cap"] <= 12
                or (data.get('pilot_protocol') == 'D3_DEMON_MULTIPLIER20_CURRENT_NATIVE_V1'
                    and data['total_attempt_cap'] == 20)
                or (data.get('pilot_protocol') == 'E1_DEMON_LIEYUN20_BLOCKED_V1'
                    and data['total_attempt_cap'] == 20)
                or (data.get('pilot_protocol') == 'E2_B12_DEMON_SHIELD_RELIABILITY20_V1'
                    and data['total_attempt_cap'] == 20))
            and type(data["run_id"]) is str and len(data["run_id"]) == 32 and
            all(c in "0123456789abcdef" for c in data["run_id"]), "bounded run required")
    activation_raw = _document(path.parent, data["activation_review"])
    require(hashlib.sha256(activation_raw).hexdigest() == request.activation_sha256,
            "independent bounded activation review required")
    activation = strict_json_loads(activation_raw.decode("utf-8"))
    require(activation["accepted"] is True and activation["scope"] == "BOUNDED_OPERATIONAL_PILOT"
            and all(activation[k] == data[k] for k in ("run_id", "total_attempt_cap", "full_config_sha256",
                "runtime_sha256", "host_sha256", "contract_sha256", "decision_sha256")),
            "offline decision is not live activation")
    calibration = strict_json_loads(_document(path.parent, data["calibration"]).decode("utf-8"))
    if data.get('pilot_protocol') == 'F1_B12_DEMON_SHIELD_PACKAGE2_V1':
        from .packaged_reasoning import load_authority
        return load_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    if data.get('pilot_protocol') == 'E2_B12_DEMON_SHIELD_RELIABILITY20_V1':
        from .reasoning_e2_native import load_reviewed_authority
        return load_reviewed_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    if data.get('pilot_protocol') == 'E1_DEMON_LIEYUN20_BLOCKED_V1':
        from .reasoning_comparison import load_reviewed_authority
        return load_reviewed_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    if data.get('pilot_protocol') in ('D3_DEMON_MINIMUM_CURRENT_NATIVE_V1',
                                    'D3_DEMON_MULTIPLIER20_CURRENT_NATIVE_V1'):
        from .reasoning_demon_native import load_reviewed_authority
        return load_reviewed_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    if data.get('pilot_protocol') == 'D2_HT7_FULL_ACTION_CURRENT_NATIVE_V1':
        from .reasoning_d2_native import load_reviewed_authority
        return load_reviewed_authority(path.parent, data, calibration, request, policy_json=policy_json, now=now)
    if data.get('pilot_protocol') == 'D4_MEGA_FULL_ACTION_CURRENT_NATIVE_V1':
        from .reasoning_mega_native import load_reviewed_authority
        return load_reviewed_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    if calibration.get("schema") == "pokiguard.reasoning.current_native_d1.v1":
        from .reasoning_d1_native import load_reviewed_authority
        return load_reviewed_authority(path.parent,data,calibration,request,policy_json=policy_json,now=now)
    require("config_projection_policy" not in data and "config_projection_policy" not in calibration,
            "projection successor native binding pending; activation unsupported")
    if calibration.get("schema") == "pokiguard.reasoning.operational_calibration_review.v4":
        from .reasoning_root_policy import load_reviewed_authority
        return load_reviewed_authority(path.parent, data, calibration, request,
                                       policy_json=policy_json, now=now)
    require("root_read_policy" not in data and "root_read_policy" not in calibration,
            "successor root policy requires v4 review")
    if calibration.get("schema") == "pokiguard.reasoning.operational_calibration_review.v3":
        from .reasoning_timing_review import load_reviewed_authority
        return load_reviewed_authority(path.parent, data, calibration, request,
                                       policy_json=policy_json, now=now)
    reviewed = calibration.get("schema") == "pokiguard.reasoning.operational_calibration_review.v2"
    if reviewed:
        from .reasoning_calibration_review import verify_review
        result = verify_review(path.parent, calibration, runtime_sha256=request.runtime_sha256,
            host_sha256=request.host_sha256, game_build_sha256=request.verified_build_sha256,
            policy_json=policy_json, witness=data["witness"])
        require(data["max_read_span_ms"] == 100, "reviewed operational read policy required")
        h = [row["H_ms"] for row in result["host_interval_rows"]]
        i = [row["I_ms"] for row in result["host_interval_rows"]]
    else:
        require(calibration["mode"] == "BASIC_CALIBRATION_ONLY" and calibration["origin"] == "NATIVE_OBSERVATION"
                and calibration["runtime_sha256"] == request.runtime_sha256
                and calibration["host_sha256"] == request.host_sha256
                and calibration["policy_json"] == policy_json and calibration["witness"] == data["witness"]
                and type(calibration["total_attempt_cap"]) is int and 1 <= calibration["total_attempt_cap"] <= 5,
                "native calibration cohort changed")
        # Ledger and durable watermark cover invalid/aborted attempts too.
        ledger = strict_json_loads(_document(path.parent, calibration["attempt_ledger"]).decode("utf-8"))
        require(type(ledger) is list and 1 <= len(ledger) <= calibration["total_attempt_cap"]
                and [a["index"] for a in ledger] == list(range(len(ledger)))
                and all(a["status"] in ("COMPLETED", "ABORTED", "INVALID", "FAILED") for a in ledger),
                "complete all-attempt ledger required")
        farm_export = strict_json_loads(_document(path.parent, calibration["farm_export"], cap=32*1024*1024).decode("utf-8"))
        require(farm_export["schema"] == "pokiguard.basic_calibration_export.v1"
                and farm_export["finalized"] is True and farm_export["errors"] == []
                and farm_export["source_sha256"] == request.runtime_sha256
                and farm_export["game_build_sha256"] == request.verified_build_sha256
                and farm_export["host_sha256"] == request.host_sha256
                and farm_export["total_attempt_cap"] == calibration["total_attempt_cap"]
                and farm_export["all_attempt_count"] == len(ledger)
                and len(farm_export["all_attempts"]) == len(ledger)
                and [a["attempt_index"] for a in farm_export["all_attempts"]] == list(range(1,len(ledger)+1)),
                "finalized native FarmRun/export ledger required")
        watermarks = strict_json_loads(_document(path.parent, calibration["watermarks"]).decode("utf-8"))
        require(watermarks["flushed"] is True and watermarks["closed"] is True
                and watermarks["collector_dropped"] == 0 and watermarks["collector_disabled"] is False,
                "durable zero-loss calibration required")
        stats = watermarks["before_close"]
        require(stats["accounting_valid"] is True and stats["eligible"] == stats["written"]
                and all(stats[k] == 0 for k in ("dropped_before_enqueue", "failed_write",
                    "discarded_after_enqueue", "queued", "in_writer")), "writer watermark incomplete")
        records = _document(path.parent, calibration["records"], cap=32*1024*1024).decode("utf-8").splitlines()
        require(1 <= len(records) <= 1024, "bounded all-record ledger required")
        combat_refs = calibration["combat_records"]
        require(type(combat_refs) is list and 1 <= len(combat_refs) <= 5, "bounded combat provenance required")
        combats = []
        for ref in combat_refs:
            combats.extend(strict_json_loads(line) for line in
                _document(path.parent, ref, cap=32*1024*1024).decode("utf-8").splitlines())
        h, i = [], []
        sources = set()
        for index, line in enumerate(records):
            event = strict_json_loads(line)
            require(event["correlation"]["mode"] == "BASIC_CALIBRATION_ONLY"
                    and event["event_seq"] == index + 1
                    and event["event_type"] in ("reasoning.swap_timing", "reasoning.decision_timing"),
                    "mixed or incomplete timing sequence")
            p = event["payload"]
            if event["event_type"] != "reasoning.swap_timing": continue
            require(p["witness"] == data["witness"] and p["policy_sha256"] == digest(json.loads(policy_json))
                    and p["timer_source"] == "MatchService.server_tick" and p["input_mode"] == "foreground"
                    and p["clock"] == "host.perf_counter_ns" and p["input_parameters"] == data["input_parameters"],
                    "mixed timing cohort")
            if not p["required_input_completed"]:
                continue  # Retained failure row, never a native input duration.
            require(p["status"] == "RETURNED" and p["sent_clicks"] == 2 and p["click_status"] == "SENT"
                    and p["board_input_mode"] == "two_click" and p["preflight_failure"] is None,
                    "incomplete calibration input")
            ts = [p[k] for k in ("decision_exit_ns", "preflight_start_ns", "read_end_ns",
                                 "validation_end_ns", "executor_return_ns")]
            require(all(type(t) is int and t >= 0 for t in ts) and ts == sorted(ts) and ts[-1] > ts[1],
                    "complete controller/input timing required")
            require((ts[2] - ts[1]) / 1e6 <= data["max_read_span_ms"], "read span exceeded")
            observed, read_end = p["observed_ns"], p["observation_read_end_ns"]
            require(type(observed) is int and type(read_end) is int and 0 <= observed <= read_end <= ts[0]
                    and (read_end-observed)/1e6 <= data["max_read_span_ms"], "root read span unbound")
            source = p["autonomous_source"]; key = canonical_json(source)
            require(key not in sources and p["decision_source_hash"] == p["source_hash"], "duplicate/stale timing source")
            sources.add(key)
            sent = [r for r in combats if r.get("event") == "action_sent" and r.get("action") == "SWAP"
                    and r.get("identity", {}).get("source") == source]
            ack = [r for r in combats if r.get("event") == "action_result" and r.get("result") == "SWAP_ACKNOWLEDGED"
                   and r.get("action", {}).get("identity", {}).get("source") == source]
            require(len(sent) == len(ack) == 1, "native input/ACK provenance unbound")
            h.append((ts[1] - ts[0]) / 1e6); i.append((ts[-1] - ts[1]) / 1e6)
        require(1 <= len(h) <= 512 and watermarks["sequence"] == len(records), "complete bounded timing records required")
    extra = strict_json_loads(_document(path.parent, data["selector_allowance"]).decode("utf-8"))
    require(extra["scope"] == "OFFLINE_OPERATIONAL_SELECTOR" and
            extra["runtime_sha256"] == request.runtime_sha256 and extra["host_sha256"] == request.host_sha256
            and set(extra["paths"]) == {"completed", "timeout", "error", "fallback"}, "selector allowance provenance required")
    for value in extra["paths"].values(): _finite(value)
    if reviewed:
        qualification = strict_json_loads(_document(path.parent, extra["qualification"]).decode("utf-8"))
        require(qualification["pass_all"] is True and all(qualification["gates"].values())
                and qualification["runtime_sha256"] == request.runtime_sha256
                and qualification["host_sha256"] == request.host_sha256
                and extra["paths"] == {k: qualification["selector_paths_ms"][k]["max"]
                    for k in ("completed", "timeout", "error", "fallback")},
                "fresh final-source qualification required")
    components = dict(controller_tail_ms=max(h), final_input_ms=max(i),
        selector_extra_ms=max(extra["paths"].values()), command_wait_ms=command_wait_ms(**data["input_parameters"]),
        host_guard_ms=data["host_guard_ms"])
    return OperationalPilotAuthority(json.loads(policy_json)["play_style"], policy_json,
        FrozenJSON.of(data["scope"]), FrozenJSON.of(data["witness"]), FrozenJSON.of(data["model"]),
        request.verified_build_sha256, request.runtime_sha256, request.host_sha256, request.contract_sha256,
        request.decision_sha256, data["calibration"]["sha256"], FrozenJSON.of(components),
        FrozenJSON.of(data["input_parameters"]), data["max_read_span_ms"], len(h),
        time.perf_counter_ns() + int((data["expires_at"]-now)*1e9),
        return_margin_ms=data["return_margin_ms"], budget_ms=data["budget_ms"])


def host_fingerprint():
    """Setup-only host/runtime identity, not a latency or clock-age bound."""
    import platform
    import sys
    clock = time.get_clock_info("perf_counter")
    return digest(dict(machine=platform.node(), system=platform.system(),
        release=platform.release(), version=platform.version(), architecture=platform.machine(),
        python=sys.version, clock=[clock.implementation, clock.monotonic, clock.adjustable, clock.resolution]))


class OperationalPilotSession:
    """Optional factory product: verifies and claims once before any game data.

    Only a separately reviewed activation request can construct this. The UI
    still launches BASIC; its existing farm cap/owner governs all attempts.
    """
    def __init__(self, request, *, root, config, policy_json, directory, game_executable, package_binding=None):
        from .reasoning_calibration import source_fingerprint
        from .game_location import validate_supported_game_assembly
        from .basic_policy import Intelligence
        from .gameplay_profile import GameMode
        require(type(request) is OperationalArtifactRequest, "typed operational request required")
        root = Path(root).resolve(); path = Path(request.path).resolve()
        require(path.is_relative_to(root), "request must stay inside V2")
        require(config.intelligence is Intelligence.BASIC and not config.ai.shadow_enabled
                and config.game_mode is GameMode.SOLO and config.input_delivery_mode.value == "foreground"
                and config.board_input_mode.value == "two_click", "scoped SOLO BASIC launch required")
        require(digest(jsonable(config)) == request.full_config_sha256, "frozen launch changed")
        from .pet_configuration import basic_policy_config
        from .reasoning_operational_launch import operational_policy_json
        require(policy_json in (canonical_json(jsonable(basic_policy_config(config))),
                                operational_policy_json(config)),
                "launch/incumbent policy differs from calibration")
        if package_binding is None:
            require(source_fingerprint(root) == request.runtime_sha256 and host_fingerprint() == request.host_sha256,
                    "source/host changed at Start")
        else:
            from .packaged_reasoning import PackageBinding
            require(type(package_binding) is PackageBinding and host_fingerprint() == request.host_sha256,
                'typed package binding and same host required')
            package_binding.verify(request,root)
        exe = Path(game_executable).resolve()
        require(validate_supported_game_assembly(exe.parent / "GameAssembly.dll") == request.verified_build_sha256,
                "build changed at Start")
        self.authority = load_operational_authority(request, policy_json=policy_json)
        raw = path.read_bytes()
        require(hashlib.sha256(raw).hexdigest() == request.sha256, "request changed before claim")
        data = strict_json_loads(raw.decode("utf-8"))
        require(config.max_match_attempts == data["total_attempt_cap"] and
                1 <= config.target_completed_matches <= data["total_attempt_cap"]
                and bool(config.normalized_boss_id), "existing farm attempt cap must match")
        claim = root / "logs/operational_pilot_claims" / (data["run_id"] + ".json")
        require(claim.resolve().is_relative_to(root), "claim outside V2")
        claim.parent.mkdir(parents=True, exist_ok=True)
        with claim.open("x", encoding="utf-8") as stream:
            json.dump(dict(run_id=data["run_id"], request_sha256=request.sha256), stream)
        self.request, self.data = request, data
        self.directory = Path(directory)
        self.adapter = self.collector = self.sink = None
        self.bridges = []  # At most the independently frozen FarmRun attempt cap.
        self.prior_dropped = 0
        self.stopped = False
        self.faulted = False
        self.bound = False
        self.finalizer = None
        import threading
        self.finalize_requested = threading.Event()
        self.options_lock = threading.Lock()
        self.retirements = {}  # Published only after off-thread durable cleanup.
        self.collectors = []
        from collections import Counter, deque
        self.session_counts = Counter()
        self.status_history = deque(maxlen=32)
        self.prepare_calls = 0
        self.first_fault = None

    def bind_run(self, farm_run_id, directory):
        import threading
        require(not self.bound and not self.stopped and time.time() < self.data["expires_at"], "pilot closed")
        self.bound = True
        self.directory.mkdir(parents=True, exist_ok=True)
        try:
            with (self.directory / "session.json").open("x", encoding="utf-8") as stream:
                json.dump(dict(run_id=self.data["run_id"], farm_run_id=farm_run_id,
                    farm_directory=str(Path(directory).resolve()), request_sha256=self.request.sha256,
                    total_attempt_cap=self.data["total_attempt_cap"], native_U_ms=None), stream)
            require(self._new_bridge(), "pilot factory unavailable")
            self.finalizer = threading.Thread(target=self._finalize, name="operational-finalize", daemon=True)
            self.finalizer.start()
        except Exception:
            self.stop()
            if self.sink is not None: self.sink.stop()
            raise

    def _status(self, reason, stage):
        item = dict(reason=reason, stage=stage, combat_index=len(self.bridges)-1,
                    prepare_call=self.prepare_calls, host_monotonic_ns=time.perf_counter_ns())
        self.session_counts[reason] += 1
        self.status_history.append(item)
        return item

    def _fault(self, reason, stage="TIMING"):
        item = self._status(reason, stage)
        if self.first_fault is None: self.first_fault = item
        self.faulted = True
        if self.adapter is not None:
            self.adapter.disabled = True
            self.adapter.bridge_counts["operational_fault:" + reason] += 1
            self.adapter.result_ready.set()

    def _new_bridge(self):
        from .reasoning_pilot import create_pilot_bridge
        from .reasoning_swap_timing import SwapTimingCollector
        require(len(self.bridges) < self.data["total_attempt_cap"], "pilot resource cap exhausted")
        bridge = create_pilot_bridge(enabled=True, authority=self.authority,
            verified_build_sha256=self.request.verified_build_sha256,
            directory=self.directory / ("combat_" + str(len(self.bridges))), run_id=self.data["run_id"])
        if bridge is None: return False
        bridge.defer_sink_stop = True  # Flush/close off Stop, after bridge drains.
        sequence = 0 if self.collector is None else self.collector.sequence
        if self.collector is not None: self.prior_dropped += self.collector.dropped
        self.adapter, self.sink = bridge, bridge.sink
        self.bridges.append(bridge)
        collector_factory=SwapTimingCollector
        from .reasoning_mega import is_mega
        if is_mega(self.authority):
            from .reasoning_mega_timing import MegaClickTimingCollector
            collector_factory=MegaClickTimingCollector
        self.collector = collector_factory(sink=bridge.timing_diagnostics, run_id=self.data["run_id"],
            sequence=sequence, operational_authority=self.authority, on_fault=self._fault,
            measure_skills=self.authority.action_profile is not None,
            component_monitor=self.data.get("component_monitor") == "POST_RETURN_COMPONENTS_V1")
        self.collectors.append(self.collector)
        return True

    def prepare_options(self):
        # No waits/joins/IO here. Stop signals independently; the finalizer owns
        # cleanup and waits for any already-started factory publication off-path.
        if not self.options_lock.acquire(False):
            self._status("PREPARE_BUSY", "PREPARE")
            return {}
        try:
            self.prepare_calls += 1
            if self.stopped or self.faulted or not self.bound or self.adapter is None: return {}
            if time.time() >= self.data["expires_at"]:
                self._fault("REQUEST_EXPIRED", "PREPARE")
                return {}
            if self.adapter.stopped:
                retirement = self.retirements.get(len(self.bridges)-1)
                if retirement is None:
                    if self.adapter.cleanup_ok is False:
                        self._fault("WORKER_CLEANUP_UNCONFIRMED", "PREPARE")
                    else:
                        self._status("SUCCESSOR_CLEANUP_PENDING", "PREPARE")
                    return {}
                if not retirement["healthy"] or self.adapter.disabled:
                    self._fault("RETIRED_BRIDGE_UNHEALTHY", "PREPARE")
                    return {}
                if len(self.bridges) >= self.data["total_attempt_cap"]:
                    self._fault("RESOURCE_CAP_EXHAUSTED", "PREPARE")
                    return {}
                if not self._new_bridge():
                    self._status("SUCCESSOR_FACTORY_UNAVAILABLE", "PREPARE")
                    return {}
            if self.stopped or self.faulted:
                # Stop can arrive inside the existing factory. Own and retire
                # that bridge, but never hand it to a combat or submit a job.
                self.collector.stop()
                self.adapter.stop()
                return {}
            if self.adapter.disabled or self.sink.buffer.disabled:
                self._fault("ACTIVE_DIAGNOSTICS_UNAVAILABLE", "PREPARE")
                return {}
            self._status("COMBAT_OPTIONS_READY", "PREPARE")
            return dict(selection_adapter=self.adapter, swap_timing_adapter=self.collector)
        finally:
            self.options_lock.release()

    def stop(self):
        self.stopped = True
        if self.collector is not None: self.collector.stop()
        if self.adapter is not None: self.adapter.stop()
        self.finalize_requested.set()

    def _finalize(self):
        receipt = dict(run_id=self.data["run_id"], native_U_ms=None, combats=[])
        retired = set()
        def retire(index, bridge):
            item = dict(combat_index=index, bridge_closed=False, flushed=False, closed=False)
            try:
                item["bridge_closed"] = bridge.close(1.3)
                item["flushed"] = bridge.sink.flush(.5)
            except Exception as exc:
                item["error"] = type(exc).__name__
            finally:
                try:
                    bridge.sink.stop()
                    item["closed"] = bridge.sink.close(1.3)
                    item["after_close"] = bridge.sink.buffer.stats()
                except Exception as exc:
                    item["cleanup_error"] = type(exc).__name__
            stats = item.get("after_close", {})
            collector = self.collectors[index]
            item["healthy"] = (all(item[k] for k in ("bridge_closed", "flushed", "closed"))
                and not bridge.disabled and not collector.disabled and collector.dropped == 0
                and stats.get("accounting_valid") is True and stats.get("failure") == "CLOSED"
                and stats.get("eligible") == stats.get("written")
                and all(stats.get(k) == 0 for k in ("dropped_before_enqueue", "failed_write",
                    "discarded_after_enqueue", "queued", "in_writer")))
            if not item["healthy"]:
                self._fault("FINALIZER_UNCONFIRMED", "FINALIZER")
            receipt["combats"].append(item)
            retired.add(id(bridge))
            self.retirements[index] = item
        try:
            # Close each retired combat off the farm/action/Stop thread. The
            # factory refuses a successor until this sink has been reaped.
            while not self.finalize_requested.wait(.01):
                for index, bridge in enumerate(tuple(self.bridges)):
                    if id(bridge) not in retired and bridge.stopped and not bridge.thread.is_alive():
                        retire(index, bridge)
            # Only this background owner may wait for a factory already in
            # progress. Stop/prepare remain signal-only/try-lock respectively.
            with self.options_lock:
                for index, bridge in enumerate(self.bridges):
                    if id(bridge) not in retired: retire(index, bridge)
                for index, item in enumerate(receipt["combats"]):
                    bridge, collector = self.bridges[index], self.collectors[index]
                    item.update(bridge_counts=dict(bridge.bridge_counts), selection_counts=dict(bridge.counts),
                        last_admission=bridge.last_admission, worker_counts=dict(bridge.runner.counters),
                        collector_sequence=collector.sequence, collector_dropped=collector.dropped,
                        collector_disabled=collector.disabled)
            receipt.update(sequence=self.collector.sequence, collector_dropped=self.prior_dropped+self.collector.dropped,
                           collector_disabled=self.collector.disabled)
        except Exception as exc:
            receipt["error"] = type(exc).__name__
            self._fault("FINALIZER_EXCEPTION", "FINALIZER")
        receipt["session"] = dict(stopped=self.stopped, faulted=self.faulted,
            first_fault=self.first_fault, prepare_calls=self.prepare_calls,
            counts=dict(self.session_counts), status_history=list(self.status_history))
        try:
            with (self.directory / "watermarks.json").open("x", encoding="utf-8") as stream:
                json.dump(receipt, stream, indent=2)
        except Exception:
            pass  # Missing receipt is never accepted as durable.
