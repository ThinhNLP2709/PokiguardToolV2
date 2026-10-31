"""Bounded, offline structural lookahead. No gameplay or input authority.

Existing solver primitives resolve every modeled ordinary transition. Boss
policy, refill, survival and passive residual coverage remain separate facts.
The completed R1 decision is retained; research rankings cannot promote R2.
"""
from __future__ import annotations

from dataclasses import dataclass, replace
import time
from typing import Callable

from .board_simulator import (
    ResourceResult, SimulatedBoard, SimulatedCell, SwapMove,
    _CellValue, _freeze, _match_through, _merge_results, _resolve_known_reply,
)
from .demon_aegis import _passive_geometry
from .reasoning_planner import (
    Bound, CandidateScore, FOLLOWUP_TARGETS, Inputs, PlannerDecision, clip,
    number, order_key, protection_credit, resource_credit, score_candidate, sufficiency,
)
from .reasoning_snapshot import Action, Evidence, FrozenJSON, ReasoningSnapshot, digest, require
from .state import GemType

REFINEMENT_VERSION = "5b3.structural.v1"
CAPABILITY_VERSION = "5b3.reply_scope.v1"
CONFIG = FrozenJSON.of(dict(version=REFINEMENT_VERSION, root_cap=8, scenarios_per_root=32,
                           node_cap=12000, duration_ms=4000, future_discount=.5,
                           policy="MAX_EFFECTIVE_SWORD_ALL_TIES",
                           secondary_priority="UNKNOWN", r2_promotion=False,
                           unknown_stress="DEPENDENCY_KNOCKOUT_NOT_REFILL_SAMPLE"))


@dataclass(frozen=True)
class Limits:
    roots: int = 8
    scenarios: int = 32
    nodes: int = 12000
    duration_ms: float = 4000
    deadline_ms: float | None = None

    def __post_init__(self):
        for name, maximum in (("roots", 8), ("scenarios", 32), ("nodes", 50000)):
            value = getattr(self, name)
            require(type(value) is int and 0 <= value <= maximum, "invalid " + name + " cap")
        number(self.duration_ms, "duration_ms", 0, 6000)
        if self.deadline_ms is not None:
            number(self.deadline_ms, "absolute deadline_ms")


class Exhausted(Exception):
    pass


class Work:
    def __init__(self, limits: Limits, clock: Callable[[], float], cancelled: Callable[[], bool]):
        self.limits, self.clock, self.cancelled = limits, clock, cancelled
        self.started = number(clock(), "clock_ms")
        self.deadline = min(self.started + limits.duration_ms,
                            limits.deadline_ms if limits.deadline_ms is not None else float("inf"))
        self.nodes = 0
        self.stop = None

    def check(self):
        if self.cancelled():
            self.stop = "CANCELLED"
        elif number(self.clock(), "clock_ms") >= self.deadline:
            self.stop = "DEADLINE"
        if self.stop:
            raise Exhausted(self.stop)

    def node(self):
        self.check()
        if self.nodes >= self.limits.nodes:
            self.stop = "NODE_CAP"
            raise Exhausted(self.stop)
        self.nodes += 1


def moves():
    # Coordinate enumeration only; all match/cascade logic stays in the solver.
    for r in range(8):
        for c in range(8):
            if c < 7:
                yield SwapMove((r, c), (r, c + 1))
            if r < 7:
                yield SwapMove((r, c), (r + 1, c))


@dataclass(frozen=True)
class Transition:
    move: SwapMove
    resources: ResourceResult
    after: SimulatedBoard
    cascade_rounds: int


def transition(board: SimulatedBoard, move: SwapMove, work: Work) -> Transition | None:
    work.node()
    grid = [[_CellValue(c.gem, c.multiplier) for c in row] for row in board]
    resolved = _resolve_known_reply(grid, move)
    work.check()  # A finished primitive received after deadline is not committed.
    if resolved is None:
        return None
    direct, cascade, rounds, after = resolved
    return Transition(move, _merge_results(direct, cascade), _freeze(after), rounds)


def enumerate_known(board: SimulatedBoard, work: Work) -> tuple[Transition, ...]:
    return tuple(t for move in moves() if (t := transition(board, move, work)) is not None)


def nominal_replies(replies: tuple[Transition, ...], sword_first: bool) -> tuple[Transition, ...]:
    swords = [t.resources.effective(GemType.SWORD) for t in replies]
    maximum = max(swords, default=0)
    if not sword_first or maximum == 0:
        return replies  # UNKNOWN secondary priority: no optimistic chosen reply.
    return tuple(t for t in replies if t.resources.effective(GemType.SWORD) == maximum)


def totals(resources: ResourceResult) -> dict:
    return {g.value: dict(physical=resources.cells(g), effective=resources.effective(g))
            for g in GemType if g != GemType.UNKNOWN}


def first_wave(board: SimulatedBoard, move: SwapMove, blast: tuple) -> dict:
    grid = [[_CellValue(c.gem, c.multiplier) for c in row] for row in board]
    a, b = move.first, move.second
    grid[a[0]][a[1]], grid[b[0]][b[1]] = grid[b[0]][b[1]], grid[a[0]][a[1]]
    union = set(blast) | _match_through(grid, a) | _match_through(grid, b)
    result = {g.value: dict(physical=0, effective=0) for g in GemType if g != GemType.UNKNOWN}
    for r, c in sorted(union):
        cell = grid[r][c]
        if cell.gem != GemType.UNKNOWN:
            require(cell.multiplier is not None, "known multiplier missing")
            result[cell.gem.value]["physical"] += 1
            result[cell.gem.value]["effective"] += cell.multiplier
    return result


def updated_balances(snapshot: ReasoningSnapshot, root: CandidateScore) -> ReasoningSnapshot:
    """Only new own-followup deficit gets credit; never root balance again."""
    observations = dict(snapshot.observations)
    resources = root.details.plain().get("resources", {})
    for gem in ("rage", "mana"):
        record = resources.get(gem, {})
        current, gain = record.get("current_points"), record.get("capped_gain_points")
        value = None if current is None or gain is None else current + gain
        observations["self." + gem] = Evidence.observed(
            value, gem + "_points", root.candidate_id + ":incremental_root_balance",
            origin="MODEL_PREDICTION", support="CONDITIONAL_MODEL",
            reason="ROOT_BALANCE_OR_CONVERSION_UNSUPPORTED")
    # Boss damage/heal/drain/effect formulas aren't known. P must not reuse old HP.
    observations["self.hp"] = Evidence.observed(None, "hp_points", "5B3_BOSS_EFFECT_UNKNOWN",
                                                 reason="POST_REPLY_HP_UNMODELED")
    return replace(snapshot, observations=tuple(sorted(observations.items())))


def best_followup(board: SimulatedBoard, snapshot: ReasoningSnapshot, model: dict,
                  work: Work, turn_access: bool) -> dict:
    best_low, best_high, best_move = 0.0, 0.0, None
    best_swords, count = 0, 0
    target_keys = FOLLOWUP_TARGETS[snapshot.intent.profile]
    targets_for_best = {}
    for move in moves():
        t = transition(board, move, work)
        if t is None:
            continue
        count += 1
        matched, blast, physical, effective = _passive_geometry(
            board, move, GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield"))
        ) if snapshot.intent.profile == "demon_aegis_farm" else ((), (), 0, 0)
        quantities = first_wave(board, move, blast) if matched else totals(t.resources)
        inputs = Inputs(snapshot)
        r, resources, _ = resource_credit(inputs, model, quantities)
        p = protection_credit(inputs, model, quantities)
        if snapshot.intent.profile == "demon_aegis_farm":
            reference = snapshot.intent.settings.plain().get("sword_setting",
                snapshot.intent.settings.plain().get("recorded_sword_setting"))
            s = Bound.fixed(clip(physical / reference), "KNOWN_PASSIVE_GEOMETRY_REFERENCE") if (
                type(reference) in (int, float) and reference > 0) else Bound.missing("SETUP_REFERENCE_MISSING")
            ledger = dict(totals=quantities, passive_swords=dict(physical=physical, effective=effective))
            f, _ = sufficiency(inputs, model, ledger, bool(matched), resources)
        else:
            s = Bound.missing("PROFILE_SETUP_EFFECT_SCOPE_UNSUPPORTED")
            f = Bound.fixed(0, "NO_SUPPORTED_FOLLOWUP_CERTIFICATE")
        d = Bound.fixed(clip(quantities["sword"]["effective"] / 8))
        target = dict(S=s, R=r, P=p, D=d)
        low = sum(target[k].low for k in target_keys) / len(target_keys) if target_keys else 0
        high = sum(target[k].high for k in target_keys) / len(target_keys) if target_keys else 0
        q_low, q_high = max(f.low, low), max(f.high, high)
        if q_low > best_low or best_move is None:
            best_low, best_move = q_low, move
            targets_for_best = {k: target[k].to_dict() for k in target_keys}
        best_high = max(best_high, q_high)
        best_swords = max(best_swords, physical)
    # No probability or guarantee that the player will survive/get that next turn.
    h = Bound(.5 * best_low if turn_access else 0, .5 * best_high,
              "CONDITIONAL", "FIXED_TARGETS_SINGLE_DISCOUNT_CONDITIONAL_TURN_ACCESS")
    return dict(h=h.to_dict(), best_move=None if best_move is None else Action("swap", best_move).to_dict(),
                legal_known_followups=count, passive_swords_max=best_swords,
                targets=targets_for_best, fixed_targets=list(target_keys),
                turn_access="SYNTHETIC_ASSUMPTION" if turn_access else "UNKNOWN",
                survival="UNMODELED", guarantee=False)


def choose_roots(snapshot: ReasoningSnapshot, incumbent: PlannerDecision, cap: int) -> tuple[CandidateScore, ...]:
    candidates = list(incumbent.scores)
    chosen = []
    def add(c):
        if c is not None and c not in chosen and len(chosen) < cap:
            chosen.append(c)
    add(next((c for c in candidates if c.baseline_member), None))
    add(next((c for c in candidates if c.action == incumbent.proposal), None))
    for feature in ("F", "R", "P", "D", "T"):
        if candidates:
            add(max(candidates, key=lambda c: (dict(c.features)[feature].low, c.bucket, c.candidate_id)))
    # Preserve known goal material as a diversity proxy, never setup utility.
    swaps = [c for c in candidates if c.action.family == "swap"]
    if swaps:
        add(min(swaps, key=lambda c: (c.details.plain().get("ledger", {}).get("totals", {}).get("shield", {}).get("physical", 64),
                                     dict(c.features)["X"].low, c.candidate_id)))
    for c in candidates:
        add(c)
    return tuple(chosen)


def _bound(value: dict) -> Bound:
    return Bound(**value)


def branch_score(snapshot: ReasoningSnapshot, root: CandidateScore, followup: dict,
                 threat: float, unknown_fraction: float) -> CandidateScore:
    features = dict(root.features)
    features["H"] = _bound(followup["h"]) if snapshot.intent.profile != "bu_win" else Bound.fixed(0, "TEAM_B_ONLY_NO_H_DOUBLE_CREDIT")
    if features["F"].low == 1:
        features["H"] = Bound.fixed(0, "NOMINAL_TERMINAL_BRANCH_NO_FUTURE_CREDIT")
    features["T"] = Bound.fixed(clip(threat), "KNOWN_REPLY_SWORD_PROXY_NOT_DAMAGE")
    features["X"] = Bound.fixed(max(features["X"].low, clip(unknown_fraction)), "KNOWN_UNKNOWN_EXPOSURE_NOT_PROBABILITY")
    features["L"] = Bound.fixed(0, "CONTEST_ALREADY_IN_H_NO_DOUBLE_PENALTY")
    weights = {k: _bound(v) for k, v in root.details.plain()["weights"].items()}
    return score_candidate(snapshot, snapshot.snapshot_id, root.action, features, weights,
                           dict(coverage="ROOT_BOSS_OWN_CONDITIONAL", future_discount=.5), root.evidence_rank)


def aggregate(nominal: list[Bound], stress: list[Bound], pressure: Bound, careful: bool) -> dict:
    require(bool(nominal), "no nominal branch")
    n = Bound(min(x.low for x in nominal), min(x.high for x in nominal))
    examined = nominal + stress
    s = Bound(min(x.low for x in examined), min(x.high for x in examined))
    base = .35 if careful else .25
    lam = Bound(min(.75, base * (1 + pressure.low)), min(.75, base * (1 + pressure.high)))
    final = Bound(n.low - lam.high * max(0, n.high - s.low),
                  n.high - lam.low * max(0, n.low - s.high), "CONDITIONAL", "EXAMINED_SCENARIOS_ONLY")
    return dict(nominal=n.to_dict(), stress_min=s.to_dict(), final=final.to_dict(),
                lambda_bounds=lam.to_dict(), probability=None, global_worst_case=False)


def analyze_root(snapshot: ReasoningSnapshot, root: CandidateScore, work: Work,
                 sword_first: bool, turn_access: bool, model: dict, geometry_only: bool = False) -> dict:
    start = work.nodes
    result = dict(candidate_id=root.candidate_id, action=root.action.to_dict(),
                  baseline_member=root.baseline_member, completed=False, scenarios=[],
                  nominal_replies_total=None, nominal_replies_examined=0, unexamined_nominal=None,
                  r2_guarantee=False, boss_action_coverage="KNOWN_ORDINARY_ONLY")
    if root.action.family != "swap":
        result.update(status="UNSUPPORTED_CARD_OR_PASS_RESIDUAL", nodes=0)
        return result
    board = tuple(tuple(SimulatedCell(GemType(g), m) for g, m in row) for row in snapshot.board)
    if snapshot.intent.profile == "demon_aegis_farm" and _passive_geometry(
        board, root.action.move, GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield"))
    )[0]:
        result.update(status="UNSUPPORTED_PASSIVE_ROOT_RESIDUAL", nodes=0)
        return result
    t = transition(board, root.action.move, work)
    require(t is not None, "incumbent candidate not legal")
    if snapshot.intent.profile == "demon_aegis_farm" and t.resources.cells(
        GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield"))
    ):
        result.update(status="UNSUPPORTED_POSSIBLE_CASCADE_PASSIVE", nodes=work.nodes-start)
        return result
    future_snapshot = updated_balances(snapshot, root)
    pre = best_followup(t.after, future_snapshot, model, work, turn_access)
    replies = enumerate_known(t.after, work)
    nominal = nominal_replies(replies, sword_first)
    result.update(pre_boss_setup_diagnostic=pre, known_replies_total=len(replies),
                  nominal_replies_total=len(nominal),
                  policy="USER_CONDITIONAL_MAX_EFFECTIVE_SWORD" if sword_first else "UNSUPPORTED_POLICY_ALL_KNOWN_ALTERNATIVES",
                  secondary_priority="UNKNOWN", root_unknown_cells=sum(c.gem == GemType.UNKNOWN for row in t.after for c in row))
    if not nominal:
        result.update(status="UNSUPPORTED_NO_KNOWN_REPLY_NO_INVENTED_PASS", nodes=work.nodes-start,
                      unexamined_nominal=0)
        return result
    nominal_scores, stress_scores = [], []
    nominal_ids = {r.move for r in nominal}
    # Every max-effective tie comes first. Stress cannot crowd a nominal tie out.
    adverse = sorted((r for r in replies if r.move not in nominal_ids), key=lambda r: (
        -r.resources.cells(GemType.SHIELD), -r.resources.cells(GemType.SWORD), r.move))
    schedule = [("NOMINAL", r) for r in nominal] + [("POLICY_ALTERNATIVE", r) for r in adverse]
    unknown_slots = min(2, max(0, work.limits.scenarios-len(nominal))) if result["root_unknown_cells"] else 0
    scheduled = schedule[:max(min(len(nominal), work.limits.scenarios), work.limits.scenarios-unknown_slots)]
    for kind, reply in scheduled:
        work.check()
        followup = best_followup(reply.after, future_snapshot, model, work, turn_access)
        unknown = sum(c.gem == GemType.UNKNOWN for row in reply.after for c in row) / 64
        scored = None if geometry_only else branch_score(snapshot, root, followup, reply.resources.effective(GemType.SWORD) / 8, unknown)
        result["scenarios"].append(dict(kind=kind, boss_move=Action("swap", reply.move).to_dict(),
            boss_sword_physical=reply.resources.cells(GemType.SWORD),
            boss_sword_effective=reply.resources.effective(GemType.SWORD),
            boss_shield_physical=reply.resources.cells(GemType.SHIELD), followup=followup,
            utility=None if scored is None else scored.utility.to_dict(), hypothetical=True, observed_boss_action=False))
        if scored is not None:
            (nominal_scores if kind == "NOMINAL" else stress_scores).append(scored.utility)
        if kind == "NOMINAL":
            result["nominal_replies_examined"] += 1
    result["unexamined_nominal"] = len(nominal) - result["nominal_replies_examined"]
    result["policy_alternatives_unexamined"] = max(0, len(schedule) - len(result["scenarios"]))
    # Dependency knockouts do NOT instantiate gems or claim reachable refill worlds.
    room = work.limits.scenarios - len(result["scenarios"])
    if room and result["root_unknown_cells"]:
        for threat, label in ((0, "FUTURE_TARGET_ACCESS_UNSUPPORTED"), (1, "MULTI_UNKNOWN_SWORD_THREAT_UNSUPPORTED")):
            if room <= 0:
                break
            work.node()
            zero = dict(h=Bound.fixed(0).to_dict())
            scored = None if geometry_only else branch_score(snapshot, root, zero, threat, 1)
            if scored is not None:
                stress_scores.append(scored.utility)
            result["scenarios"].append(dict(kind="DEPENDENCY_KNOCKOUT", assumption=label,
                utility=None if scored is None else scored.utility.to_dict(), favorable_refill_credit=0,
                refill_instantiated=False, reachable_world_proven=False))
            room -= 1
    result["scenario_cap_reached"] = len(result["scenarios"]) >= work.limits.scenarios
    result["nodes"] = work.nodes - start
    if result["unexamined_nominal"]:
        result.update(status="PARTIAL_NOMINAL_TIES_NO_FUTURE_COMMIT", aggregate=None)
        return result
    pressure = _bound(root.details.plain().get("pressure", Bound.missing("PRESSURE_MISSING").to_dict()))
    if snapshot.intent.profile == "bu_win":
        pressure = Bound.fixed(0, "TEAM_OBJECTIVE")
    result.update(status="COMPLETED_CONDITIONAL", completed=True,
                  aggregate=None if geometry_only else aggregate(nominal_scores, stress_scores, pressure, snapshot.intent.profile == "careful"),
                  utility_usable=not geometry_only,
                  known_retained_swords_min=min(s["followup"]["passive_swords_max"] for s in result["scenarios"] if s["kind"] == "NOMINAL"))
    return result


@dataclass(frozen=True)
class RefinementResult:
    incumbent: PlannerDecision
    research_candidate: Action | None
    diagnostics: FrozenJSON
    incumbent_usable: bool = True

    def to_dict(self):
        return dict(schema="pokiguard.reasoning.refinement.v1", version=REFINEMENT_VERSION,
                    config_hash=digest(CONFIG.plain()), snapshot_id=self.incumbent.snapshot_id,
                    disposition="RETAIN_COMPLETED_R1" if self.incumbent_usable else "DISCARD_UNBOUND_INCUMBENT",
                    incumbent_usable=self.incumbent_usable,
                    incumbent_proposal=None if not self.incumbent_usable or self.incumbent.proposal is None else self.incumbent.proposal.to_dict(),
                    research_candidate=None if self.research_candidate is None else self.research_candidate.to_dict(),
                    r2_promotion=False, input_authority=False, diagnostics=self.diagnostics.plain())


def refine(snapshot: ReasoningSnapshot, incumbent: PlannerDecision, limits: Limits = Limits(), *,
           clock: Callable[[], float] = lambda: time.monotonic_ns() / 1e6,
           cancelled: Callable[[], bool] = lambda: False) -> RefinementResult:
    """R1 must already be complete. Absolute deadline never resets per branch.

    Only complete, equally covered root analyses can produce a research ranking.
    Missing production capability still retains R1, independent of that ranking.
    """
    require(isinstance(snapshot, ReasoningSnapshot) and isinstance(incumbent, PlannerDecision), "typed immutable input required")
    work = Work(limits, clock, cancelled)
    analyses, chosen, candidate, failure = [], (), None, None
    incumbent_usable = False
    try:
        require(incumbent.snapshot_id == snapshot.snapshot_id and incumbent.config_hash == snapshot.intent.config_hash
                and incumbent.baseline.to_dict() == snapshot.baseline.to_dict(), "source/config/incumbent mismatch")
        snapshot.board_state()
        require(len(incumbent.scores) <= 128 and len({c.candidate_id for c in incumbent.scores}) == len(incumbent.scores),
                "oversize/duplicate incumbent candidates")
        for c in incumbent.scores:
            require(c.candidate_id == snapshot.candidate_id(c.action), "candidate identity mismatch")
            require(c.baseline_member == (c.action.to_dict() == snapshot.baseline.to_dict()), "baseline membership mismatch")
        require(incumbent.proposal is None or any(c.action.to_dict() == incumbent.proposal.to_dict()
                for c in incumbent.scores), "unbound incumbent proposal")
        incumbent_usable = True
        work.check()
        inputs = Inputs(snapshot)
        capability = inputs.value("planner.refinement", "reply_capability")
        sword_first, turn_access = False, False
        if capability is not None:
            require(isinstance(capability, dict) and set(capability) == {"version", "boss_policy", "own_turn_access"}, "invalid refinement capability")
            require(capability["version"] == CAPABILITY_VERSION and capability["boss_policy"] == "MAX_EFFECTIVE_SWORD_ALL_TIES", "unsupported reply capability")
            scope = inputs.used["planner.refinement"].scope.plain()
            require(isinstance(scope, dict) and all(k in scope for k in ("profile", "session_id", "match_id", "boss", "game_build")), "refinement binding incomplete")
            sword_first = True
            require(type(capability["own_turn_access"]) is bool, "invalid turn access")
            # Synthetic alternation can exercise algorithms; it is not game proof.
            turn_access = capability["own_turn_access"] and inputs.used["planner.refinement"].origin == "SYNTHETIC_SPEC" and scope["game_build"] == "SYNTHETIC"
        model = inputs.value("planner.model", "scoped_model") or {}
        chosen = choose_roots(snapshot, incumbent, limits.roots)
        for c in chosen:
            work.check()
            try:
                analysis = analyze_root(snapshot, c, work, sword_first, turn_access, model)
                work.check()
                analyses.append(analysis)  # Atomic root commit, never a half branch.
            except Exhausted:
                failure = dict(candidate_id=c.candidate_id, partial_root_discarded=True)
                raise
        comparable = [a for a in analyses if a["completed"]]
        baseline = next((a for a in comparable if a["baseline_member"]), None)
        # Opaque/non-refined roots retain unknown future bounds; never rank them 0.
        if baseline is not None and not work.stop:
            by_id = {c.candidate_id: c for c in incumbent.scores}
            best = min(comparable, key=lambda a: order_key(
                replace(by_id[a["candidate_id"]], utility=_bound(a["aggregate"]["final"])), snapshot.intent.profile))
            done_ids = {a["candidate_id"] for a in comparable}
            unseen_upper = max((c.utility.high + (0 if dict(c.features)["F"].low == 1 or snapshot.intent.profile == "bu_win" else
                .5 * c.details.plain()["weights"]["H"]["high"]) for c in incumbent.scores if c.candidate_id not in done_ids), default=-1e6)
            if best["aggregate"]["final"]["low"] - baseline["aggregate"]["final"]["high"] >= .05 and best["aggregate"]["final"]["low"] >= unseen_upper:
                candidate = Action.from_dict(best["action"])
        work.check()
    except Exhausted:
        candidate = None
    except (ValueError, TypeError, KeyError) as exc:
        failure = dict(error_type=type(exc).__name__, error=str(exc))
        candidate = None
    return RefinementResult(incumbent, candidate, FrozenJSON.of(dict(
        source=snapshot.source.to_dict(), current_snapshot_id=snapshot.snapshot_id,
        mode="OFFLINE_DIAGNOSTIC_ONLY",
        limits=dict(roots=limits.roots, scenarios=limits.scenarios, nodes=limits.nodes,
                    duration_ms=limits.duration_ms, absolute_deadline_ms=limits.deadline_ms),
        clock_domain="CALLER_MONOTONIC_MS", deadline_resets=0,
        nodes=work.nodes, stop_reason=work.stop, failure=failure,
        chosen_root_ids=[c.candidate_id for c in chosen], roots_completed=sum(a["completed"] for a in analyses),
        analyses=analyses, incomplete_root_results_exposed=False,
        unrefined_roots=max(0, len(incumbent.scores)-len(analyses)),
        runtime_r2_gate="NOT_VALIDATED_BOSS_REFILL_EFFECT_SURVIVAL_SCOPE",
        stress_min_is_global_bound=False, boss_skill_passive_pass_coverage="UNKNOWN",
        return_policy="COMPLETED_BOUND_R1_ONLY_INVALID_STATE_FAILS_CLOSED",
        tail_bound="ONE_EXISTING_64_CELL_PRIMITIVE_PLUS_BOUNDED_RESULT_PACKING")), incumbent_usable)


def trace_known_root(snapshot: ReasoningSnapshot, limits: Limits = Limits(roots=1)) -> FrozenJSON:
    """Historical geometry-only diagnostic; never manufactures model/legality.

    The scaffold is deliberately not an R1 decision. No utility score, boss
    attribution, future balance, promotion or counterfactual outcome is emitted.
    """
    require(isinstance(snapshot, ReasoningSnapshot), "immutable snapshot required")
    snapshot.board_state()
    stub = CandidateScore(snapshot.candidate_id(snapshot.baseline), snapshot.baseline, True,
                          (), (), Bound.fixed(0), 0, FrozenJSON.of({}))
    work = Work(limits, lambda: time.monotonic_ns() / 1e6, lambda: False)
    try:
        analysis = analyze_root(snapshot, stub, work, False, False, {}, geometry_only=True)
        return FrozenJSON.of(dict(snapshot_id=snapshot.snapshot_id, source=snapshot.source.to_dict(),
                                  status="GEOMETRY_ONLY", analysis=analysis, nodes=work.nodes,
                                  boss_action="MISSING", alternative_outcomes="NOT_OBSERVED",
                                  r2_promotion=False, utility_usable=False))
    except Exhausted:
        return FrozenJSON.of(dict(snapshot_id=snapshot.snapshot_id, source=snapshot.source.to_dict(),
                                  status=work.stop, nodes=work.nodes, partial_root_discarded=True,
                                  utility_usable=False, r2_promotion=False))
