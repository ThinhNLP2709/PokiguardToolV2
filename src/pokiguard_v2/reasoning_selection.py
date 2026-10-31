"""Guarded, completed R1 SWAP selection; default offline, explicit scoped pilot.

Preparation runs outside the action checkpoint. The checkpoint never runs a
planner, waits, reads the game, captures a screen, or owns an input/ACK. There
Pilot authority additionally pins cohort/config/model and calibrated timing.
"""
from __future__ import annotations

from collections import Counter
from dataclasses import dataclass, replace
import json
import math

from .autonomous_control import AutonomousSource
from .basic_policy import CandidateTrace, PolicyAction, PolicyDecision, _candidate_trace
from .board_diagnostics import jsonable
from .board_simulator import simulate_move
from .reasoning_diagnostics import DiagnosticBuffer, encode_event
from .reasoning_runner import RunnerJob, Reply, _validate_reply, deadline_ns
from .reasoning_snapshot import Action, canonical_json, digest
from .reasoning_operational import (is_pilot_authority, native_model_required,
    authority_deadline, authority_margin, OperationalPilotAuthority)
from .reasoning_planner import MODEL_VERSION, UTILITY_VERSION, FEATURES


VERSION = "5c4.completed_r1_swap.v1"
OFFLINE_CONTEXT = "OFFLINE_NATIVE_FAKES"
PROFILES = frozenset({"simple", "careful"})


def _action(decision):
    return Action("swap", decision.move) if decision.action is PolicyAction.SWAP else None


def _bounded_pilot_comparison(candidate):
    """Rank0 can describe a FULL normalized interval, not missing comparison.

    Only a typed pilot may use it. Essential model/legality/source/timing still
    require their independent checks. Unknown R/P keep [0,1]; known D/T/X
    remain structural proxies. Robust lower-v-upper must win over all of these
    intervals. This does not validate actual damage or survival.
    """
    features, contributions = candidate.get("features"), candidate.get("contributions")
    if (candidate.get("evidence_rank") != 0 or type(features) is not dict
            or type(contributions) is not dict or set(features) != set(FEATURES)
            or set(contributions) != set(FEATURES)):
        return False
    for name in FEATURES:
        bound, interval = features[name], contributions[name]
        if (type(bound) is not dict or bound.get("status") not in ("PRESENT", "BOUNDED", "UNSUPPORTED")
                or any(type(bound.get(k)) not in (int, float) or not math.isfinite(bound[k])
                       for k in ("low", "high")) or not 0 <= bound["low"] <= bound["high"] <= 1
                or type(interval) is not list or len(interval) != 2
                or any(type(x) not in (int, float) or not math.isfinite(x) for x in interval)
                or not -128 <= interval[0] <= interval[1] <= 128):
            return False
        if bound["status"] == "UNSUPPORTED" and (name not in ("R", "P", "E")
                or (bound["low"], bound["high"]) != (0, 1)):
            return False
        if name in ("F", "H", "B", "L") and (bound["low"], bound["high"]) != (0, 0):
            return False  # No unexamined future, certificate, team or effect credit.
        if bound["high"] == 0 and interval != [0, 0]:
            return False
        if name in ("T", "X", "L", "E"):
            if interval[1] > 0:
                return False
        elif interval[0] < 0:
            return False
    utility = candidate["utility"]
    return all(abs(sum(contributions[k][i] for k in FEATURES) - utility[field]) < 1e-8
               for i, field in enumerate(("low", "high")))


@dataclass(frozen=True)
class Capability:
    """Offline synthetic scope, or an explicit frozen pilot authority."""
    profile: str
    model_hash: str
    scope_json: str
    reserve_ms: float
    observed_ns: int
    remaining_ms: float
    context: str = OFFLINE_CONTEXT
    version: str = VERSION
    pilot_authority: object | None = None
    action_context: tuple | None = None

    def __post_init__(self):
        from .reasoning_full_actions import is_full_action
        d2 = is_full_action(self.pilot_authority)
        from .reasoning_demon import is_demon
        d3 = is_demon(self.pilot_authority)
        if ((self.profile not in PROFILES and not (d2 and self.profile in ('skill_rush','mega_icarus_spam_skill'))
                and not (d3 and self.profile == 'demon_aegis_farm'))
                or self.version != VERSION or type(self.observed_ns) is not int
                or self.observed_ns < 0 or any(type(v) not in (int, float)
                    or not math.isfinite(v) or v <= 0 for v in (self.reserve_ms, self.remaining_ms))):
            raise ValueError("unsupported capability/timing")
        if self.context == OFFLINE_CONTEXT:
            if self.pilot_authority is not None:
                raise ValueError("offline capability cannot carry pilot authority")
        else:
            from .reasoning_pilot_contract import PilotAuthority
            a = self.pilot_authority
            if (not is_pilot_authority(a) or self.context != a.context
                    or self.profile != a.profile or self.scope_json != a.scope.text
                    or self.model_hash != digest(a.model.plain()) or self.reserve_ms != a.reserve_ms):
                raise ValueError("unbound pilot capability")
        scope = json.loads(self.scope_json)
        if set(scope) != {"account_binding", "boss", "loadout"} or any(
                type(v) is not str or v in ("", "UNKNOWN", "NOT_PUBLISHED") for v in scope.values()):
            raise ValueError("explicit scoped model required")


@dataclass(frozen=True)
class CompletedProposal:
    job: RunnerJob
    reply: Reply
    source: AutonomousSource
    policy_json: str
    capability: Capability
    completed_ns: int
    dispatch_deadline_ns: int
    candidate_trace: CandidateTrace | None

    @classmethod
    def prepare(cls, *, job, raw_reply, state, config, capability, completed_ns):
        """Validate/pack one finished worker result OFF the dispatch path.

        The existing runner wire validator pins job, generation, immutable
        source/config, coordinates, attribution and no R2/input authority.
        Legality uses the existing simulator on the identical bound board.
        """
        from .reasoning_full_actions import is_full_action, prepare_completed
        from .reasoning_demon import is_demon, prepare_completed as prepare_demon_completed
        if is_demon(capability.pilot_authority):
            return prepare_demon_completed(cls,job=job,raw_reply=raw_reply,state=state,
                config=config,capability=capability,completed_ns=completed_ns)
        if is_full_action(capability.pilot_authority):
            return prepare_completed(cls, job=job, raw_reply=raw_reply, state=state,
                config=config, capability=capability, completed_ns=completed_ns)
        reply = _validate_reply(raw_reply, job)
        policy_json = canonical_json(jsonable(config))
        snapshot = job.snapshot
        source = AutonomousSource.from_state(state)
        if (type(capability) is not Capability or capability.profile != snapshot.intent.profile
                or config.play_style.value != capability.profile
                or (config.main_pet.value, config.evolution.value, config.damage_card.value)
                    != ("normal", "normal", "default_attack")
                or policy_json != snapshot.intent.settings.text
                or snapshot.board_state() != state.board
                or snapshot.source.session_id != canonical_json(jsonable(state.battle.session_key))
                or snapshot.source.match_id != state.battle.match_id
                or snapshot.source.turn != state.battle.turn_number
                or snapshot.source.srv_seq != state.battle.srv_seq
                or snapshot.source.board_hash != state.battle.board_hash
                or state.player is None or snapshot.source.actor_id != state.player.actor_number
                or snapshot.source.controller_generation != job.generation
                or snapshot.recorded.plain().get("controller_source_hash") != source.critical_state_hash
                or snapshot.baseline.family != "swap"
                or snapshot.intent.scope.plain().get("mode") != (
                    "OFFLINE_INTEGRATION" if capability.context == OFFLINE_CONTEXT else capability.context)
                or snapshot.intent.scope.plain().get("input_authority") is not False):
            raise ValueError("unbound source/config/capability")
        authority = capability.pilot_authority
        if authority is not None and (not authority.matches(state, config)
                or snapshot.intent.scope.plain().get("pilot_authority") != authority.identity):
            raise ValueError("pilot authority/cohort changed")
        model = snapshot.evidence("planner.model")
        legal = snapshot.evidence("planner.legality")
        if (snapshot.intent.versions.plain().get("utility") != UTILITY_VERSION
                or model.value.plain().get("version") != MODEL_VERSION):
            raise ValueError("unsupported model/utility version")
        for name, field in (("hp", "hp"), ("max_hp", "max_hp"), ("mana", "mana"),
                            ("max_mana", "max_mana"), ("rage", "power"), ("max_rage", "max_power")):
            observation = snapshot.evidence("self." + name)
            if observation.availability != "PRESENT" or observation.value.plain() != getattr(state.player, field):
                raise ValueError("resource/HP observation not bound to controller state")
        scope = json.loads(capability.scope_json)
        for evidence in (model, legal):
            binding = evidence.scope.plain()
            if (evidence.availability != "PRESENT" or any(binding.get(k) != v for k, v in scope.items())
                    or binding.get("profile") != capability.profile
                    or binding.get("session_id") != snapshot.source.session_id
                    or binding.get("match_id") != snapshot.source.match_id):
                raise ValueError("model/legality scope mismatch")
        if (digest(model.value.plain()) != capability.model_hash
                or legal.scope.plain().get("turn") != snapshot.source.turn
                or legal.value.plain() != dict(owner="ROOT_TURN", swap_allowed=True,
                    pass_allowed=False, mandatory=True, blocked=False)
                or type(completed_ns) is not int
                or not capability.observed_ns <= job.created_ns <= completed_ns < job.deadline_ns):
            raise ValueError("invalid completed result/timing/owner")
        limit = (deadline_ns(observed_ns=capability.observed_ns, remaining_ms=capability.remaining_ms,
            slice_started_ns=job.created_ns, now_ns=job.created_ns, reserve_ms=capability.reserve_ms)
            if authority is None else authority_deadline(authority,
                observed_ns=capability.observed_ns, remaining_ms=capability.remaining_ms,
                slice_started_ns=job.created_ns, now_ns=job.created_ns))
        if limit is None or job.deadline_ns > limit:
            raise ValueError("job exceeds source/action reserve")
        candidate_trace = None
        if reply.proposal is not None:
            if reply.proposal.family != "swap" or reply.reason != "ROBUST_ONE_STEP_PROXY_IMPROVEMENT":
                raise ValueError("unsupported proposal")
            summary = json.loads(reply.summary_json)
            by_id = {c["candidate_id"]: c for c in summary["candidates"]}
            pair = [by_id[job.candidate_id(a)] for a in (snapshot.baseline, reply.proposal)]
            for candidate in pair:
                utility = candidate.get("utility") or {}
                if (authority is not None and native_model_required(authority)
                        and candidate.get("evidence_rank") != 0):
                    raise ValueError("minimal production model must retain unsupported intervals")
                if (candidate.get("status") != "R1_PROXY_ONLY"
                        or type(candidate.get("evidence_rank")) is not int
                        or not 0 <= candidate["evidence_rank"] <= 4
                        or (candidate.get("evidence_rank", 0) < 1 and not (
                            authority is not None and _bounded_pilot_comparison(candidate)))
                        or utility.get("status") not in ("PRESENT", "BOUNDED")
                        or any(type(utility.get(k)) not in (int, float)
                            or not math.isfinite(utility[k]) for k in ("low", "high"))
                        or utility["low"] > utility["high"]):
                    raise ValueError("unscored/unsupported utility")
                if authority is not None and candidate["evidence_rank"] == 0:
                    evaluation = simulate_move(state.board, Action.from_dict(candidate["action"]).move)
                    if evaluation is None:
                        raise ValueError("invalid interval root")
                    trace = _candidate_trace(evaluation, board=state.board)
                    expected = dict(D=min(1, trace.sword_effective / 8),
                        T=min(1, trace.opponent_sword_reply_effective_max / 8),
                        X=min(1, trace.unknown_cells / 64 + .25 * bool(trace.unknown_sword_completions)))
                    for name, value in expected.items():
                        feature = candidate["features"][name]
                        if feature["low"] != value or feature["high"] != value:
                            raise ValueError("structural proxy differs from existing solver")
                    if native_model_required(authority):
                        for name in ("R", "E"):
                            f = candidate["features"][name]
                            if (f["low"], f["high"], f["status"]) != (0, 1, "UNSUPPORTED"):
                                raise ValueError("unmodeled production input was filled")
                        totals = {name: effective for name, physical, effective in trace.total_resources}
                        p = candidate["features"]["P"]
                        interval = (0, 1) if any(totals.get(g, 0) for g in ("health", "shield", "drain")) else (0, 0)
                        if (p["low"], p["high"]) != interval:
                            raise ValueError("unmodeled protection was filled")
            if pair[1]["utility"]["low"] - pair[0]["utility"]["high"] < .05:
                raise ValueError("near tie retains BASIC")
            evaluation = simulate_move(state.board, reply.proposal.move)
            if evaluation is None:
                raise ValueError("nonmatching swap")
            candidate_trace = _candidate_trace(evaluation, board=state.board)
        margin = 250 if authority is None else authority_margin(authority)
        dispatch_limit = capability.observed_ns + int(
            (capability.remaining_ms - capability.reserve_ms - margin) * 1e6)
        return cls(job, reply, source, policy_json, capability, completed_ns, dispatch_limit,
                   candidate_trace)


@dataclass(frozen=True)
class Selection:
    decision: PolicyDecision
    receipt: CompletedProposal | None = None
    reason: str = "BASIC"


class GuardedSelectionAdapter:
    """Single finished offer; no worker/queue creation or blocking callback.

    Diagnostics use an existing bounded, try-lock buffer, never disk on this
    path. At most 8 small records/second; a fault disables selection, while
    BASIC stays under the existing controller. The buffer's writer is external.
    """
    def __init__(self, completed=None, *, diagnostics, enabled=False, pilot_authority=None):
        if (type(diagnostics) is not DiagnosticBuffer or diagnostics.limits.records > 432
                or diagnostics.limits.bytes > 6 * 1024 * 1024):
            raise ValueError("qualified bounded diagnostic buffer required")
        if completed is not None and type(completed) is not CompletedProposal:
            raise ValueError("immutable completed proposal required")
        self.completed, self.diagnostics, self.enabled = completed, diagnostics, enabled is True
        if pilot_authority is not None:
            from .reasoning_pilot_contract import PilotAuthority
            if not is_pilot_authority(pilot_authority):
                raise ValueError("typed pilot authority required")
        self.pilot_authority = pilot_authority
        self.stopped = self.disabled = False
        self.counts = Counter()
        self.last_reason = None
        self._window = None
        self._emitted = self._sequence = 0

    def stop(self):
        self.stopped = True  # Signal only; no join, flush or child cleanup here.

    def _record(self, reason, checkpoint, now_ns):
        self.counts[reason] += 1
        self.last_reason = reason
        window = now_ns // 1_000_000_000
        if self._window != window:
            self._window, self._emitted = window, 0
        if self._emitted >= 8:
            self.counts["diagnostic_rate_limited"] += 1
            return False
        self._emitted += 1
        self._sequence += 1
        offer = self.completed
        correlation = {} if offer is None else dict(job_id=offer.job.job_id,
            generation=offer.job.generation, snapshot_id=offer.job.binding.snapshot_id,
            config_hash=offer.job.binding.config_hash)
        try:
            raw = encode_event("reasoning.selection", self._sequence, correlation,
                dict(reason=reason, checkpoint=checkpoint, scope=(OFFLINE_CONTEXT if
                     self.pilot_authority is None else self.pilot_authority.context),
                     comparison="STRICT_EVIDENCE_RANK" if self.pilot_authority is None
                         else "NORMALIZED_R1_FULL_INTERVALS_NO_DAMAGE_GUARANTEE",
                     selected_is_dispatch=False, existing_preflight_required=True,
                      timing_mode=("OPERATIONAL_PROJECTION" if type(self.pilot_authority) is OperationalPilotAuthority else "STRICT"),
                      native_U_ms=None if type(self.pilot_authority) is OperationalPilotAuthority else "NOT_PUBLISHED"))
            if self.diagnostics.enqueue(raw):
                return True
        except Exception:
            self.counts["diagnostic_exception"] += 1
        self.disabled = True
        self.counts["diagnostic_failure"] += 1
        return False

    def _reason(self, offer, state, baseline, config, now_ns, input_allowed, context, final=False,
                final_remaining_seconds=None):
        if not input_allowed: return "EXISTING_OWNER_OR_STOP"
        if self.stopped: return "STOPPED"
        if not self.enabled: return "OPT_IN_OFF"
        if self.disabled or self.diagnostics.disabled: return "DIAGNOSTIC_DISABLED"
        expected_context = OFFLINE_CONTEXT if self.pilot_authority is None else self.pilot_authority.context
        if context != expected_context: return "PRODUCTION_GATED"
        if offer is None: return "NO_COMPLETED_PROPOSAL"
        if (offer.capability.context != expected_context
                or offer.capability.pilot_authority != self.pilot_authority): return "CAPABILITY_CHANGED"
        if self.pilot_authority is not None and not self.pilot_authority.matches(state, config):
            return "PILOT_COHORT_CHANGED"
        if offer is not self.completed: return "SUPERSEDED_JOB"
        if not offer.source.matches(state): return "SOURCE_CHANGED"
        if canonical_json(jsonable(config)) != offer.policy_json: return "CONFIG_CHANGED"
        from .reasoning_full_actions import (is_full_action, incumbent_action, context_hash,
            current_action_allowed, pass_authority_view)
        d2 = is_full_action(self.pilot_authority)
        from .reasoning_demon import is_demon
        d3 = is_demon(self.pilot_authority)
        if config.play_style.value not in PROFILES and not (d2 and config.play_style.value in ('skill_rush','mega_icarus_spam_skill')) and not (d3 and config.play_style.value == 'demon_aegis_farm'): return "UNSUPPORTED_PROFILE"
        if (incumbent_action(baseline) if d2 else _action(baseline)) != offer.job.snapshot.baseline: return "BASIC_INCUMBENT_CHANGED"
        if d2:
            packet = getattr(self,'action_context',None)
            if (packet is None
                    or pass_authority_view(packet[0]) != pass_authority_view(state)
                    or context_hash(packet) != offer.job.snapshot.recorded.plain()['d2_actions']['context_hash']):
                return 'D2_CAPABILITY_OR_HISTORY_CHANGED'
            if not current_action_allowed(offer.reply.proposal or offer.job.snapshot.baseline,packet):
                return 'D2_FAMILY_NOT_CURRENTLY_ALLOWED'
        if now_ns < offer.completed_ns: return "RESULT_NOT_COMPLETED"
        limit = min(offer.dispatch_deadline_ns, offer.job.deadline_ns) if final else offer.job.deadline_ns
        if now_ns >= limit: return "LATE_PROPOSAL"
        remaining = final_remaining_seconds if final else state.battle.turn_time_remaining_seconds
        margin = 250 if self.pilot_authority is None else (
            authority_margin(self.pilot_authority))
        if (type(remaining) not in (int, float) or not math.isfinite(remaining)
                or remaining * 1000 <= offer.capability.reserve_ms + margin): return "INSUFFICIENT_RESERVE"
        if offer.reply.proposal is None:
            if d3 and offer.reply.reason in ('D3_BASELINE_ALREADY_BEST','D3_NO_CERTIFIED_IMPROVEMENT_RETAIN_BASIC',
                    'D3_UNCERTAINTY_OR_PRESSURE_RETAINS_BASIC'):
                return 'VALID_COMPLETED_R1_RETENTION'
            if d2 and offer.reply.reason in ('BASELINE_TOP_IN_TOTAL_ORDER','NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE'):
                return 'VALID_COMPLETED_R1_RETENTION'
            return "RETAIN_BASELINE"
        return "VALID_COMPLETED_R1"

    def select(self, state, baseline, config, *, now_ns, input_allowed, context):
        offer = self.completed
        reason = self._reason(offer, state, baseline, config, now_ns, input_allowed, context)
        logged = self._record(reason, "ROOT", now_ns)
        if reason not in ("VALID_COMPLETED_R1",'VALID_COMPLETED_R1_RETENTION') or not logged:
            return Selection(baseline, reason=reason if logged else "DIAGNOSTIC_FAILURE")
        proposal = offer.reply.proposal
        candidate = offer.candidate_trace
        if proposal is None:
            return Selection(baseline,offer,reason)
        from .reasoning_full_actions import is_full_action, apply_action
        if is_full_action(self.pilot_authority):
            if proposal is None:
                # Native policy branches carry execution permissions, including
                # the explicit Skill Rush fallback when every swap has risk.
                # Successful agreement must preserve that complete contract.
                return Selection(baseline,offer,reason)
            decision = apply_action(baseline, proposal, state, self.action_context, candidate)
            native_guard = getattr(self, 'native_policy_guard', None)
            if native_guard is not None and native_guard(decision) is not False:
                # The controller supplies its existing pure guard and already
                # computed counts. Never relax it or invent an allowed branch.
                # A rejected proposal has no receipt; ordinary BASIC pacing
                # and preflight remain responsible for the incumbent action.
                from .reasoning_mega import is_mega
                fallback = 'D4_NATIVE_POLICY_GUARD_RETAIN_BASIC' if is_mega(self.pilot_authority) else 'D2_NATIVE_POLICY_GUARD_RETAIN_BASIC'
                logged = self._record(fallback, 'ROOT', now_ns)
                return Selection(baseline,reason=fallback if logged else 'DIAGNOSTIC_FAILURE')
            return Selection(decision,offer,reason)
        trace = replace(baseline.trace, policy_step="REASONING_R1_SWAP", selected_candidate=candidate,
            why_selected="Bound completed R1 proxy improvement; BASIC settings remain advisory",
            skipped_current_sword_for_resource=False,
            selected_move_left_direct_boss_sword=bool(candidate and candidate.opponent_sword_replies),
            selected_move_left_indirect_boss_sword=bool(candidate and candidate.indirect_sword_replies))
        decision = replace(baseline, move=proposal.move, trace=trace)
        from .reasoning_demon import is_demon
        if is_demon(self.pilot_authority):
            native_guard = getattr(self, 'native_policy_guard', None)
            if native_guard is not None and native_guard(decision) is not False:
                fallback = 'D3_NATIVE_POLICY_GUARD_RETAIN_BASIC'
                logged = self._record(fallback, 'ROOT', now_ns)
                return Selection(baseline,reason=fallback if logged else 'DIAGNOSTIC_FAILURE')
        return Selection(decision, offer, reason)

    def revalidate(self, receipt, state, baseline, config, *, now_ns, input_allowed, context,
                   final=False, final_remaining_seconds=None):
        reason = self._reason(receipt, state, baseline, config, now_ns, input_allowed, context,
                              final, final_remaining_seconds)
        logged = self._record(reason, "FINAL" if final else "FRESH", now_ns)
        if (final and type(self.pilot_authority) is OperationalPilotAuthority
                and reason in ("LATE_PROPOSAL", "INSUFFICIENT_RESERVE")):
            self.disabled = True
        return None if reason in ("VALID_COMPLETED_R1",'VALID_COMPLETED_R1_RETENTION') and logged else (
            reason if logged else "DIAGNOSTIC_FAILURE")


def select_safely(adapter, *args, **kwargs):
    try:
        result = adapter.select(*args, **kwargs)
        if type(result) is not Selection:
            raise ValueError("invalid selector result")
        return result
    except Exception:
        adapter.disabled = True
        _fault_safely(adapter, "ROOT", kwargs["now_ns"])
        return Selection(args[1], reason="SELECTOR_EXCEPTION")


def revalidate_safely(adapter, *args, **kwargs):
    try:
        failure = adapter.revalidate(*args, **kwargs)
        if failure is not None and type(failure) is not str:
            raise ValueError("invalid preflight result")
        return failure
    except Exception:
        adapter.disabled = True
        _fault_safely(adapter, "PREFLIGHT", kwargs["now_ns"])
        return "SELECTOR_EXCEPTION"


def _fault_safely(adapter, checkpoint, now_ns):
    try:
        adapter._record("SELECTOR_EXCEPTION", checkpoint, now_ns)
    except Exception:
        pass  # A diagnostic failure cannot escape into the BASIC controller.


def stop_safely(adapter):
    try:
        adapter.stop()
    except Exception:
        pass
