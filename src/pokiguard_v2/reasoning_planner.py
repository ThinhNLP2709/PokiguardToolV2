"""Phase 5B.2: pure, one-step utility research; never an input authority.

The only board mechanics are the existing simulator and Demon geometry. Extra
effect/cost/legality evidence must be explicitly supplied in an immutable
snapshot. Historical B1 snapshots do not supply it and remain baseline-only.
No boss refinement, worker, clock, IO, provider or runtime adapter belongs here.
"""
from __future__ import annotations

from dataclasses import dataclass
import math
from typing import Any

from .board_simulator import MoveEvaluation, evaluate_all_moves
from .demon_aegis import evaluate_demon_aegis_move
from .reasoning_snapshot import (
    Action, Evidence, FrozenJSON, ReasoningSnapshot, canonical_json, digest, require,
)
from .state import GemType

UTILITY_VERSION = "5b2.one_step.v1"
FEATURE_VERSION = "5b2.features.v1"
MODEL_VERSION = "5b2.scoped_inputs.v1"
FEATURES = ("F", "R", "D", "P", "H", "B", "T", "X", "L", "E")
SUPPORT_RANK = {"VERIFIED_FOR_SCOPE": 4, "EMPIRICAL_VALIDATED": 3,
                "USER_CALIBRATED": 2, "CONDITIONAL_MODEL": 1, "UNKNOWN": 0}
WEIGHTS = {
    "simple": (3, 5, 2, 2, 0, 4, 2, 2, 1),
    "careful": (3, 4, 4, 2, 0, 6, 4, 3, 1),
    "skill_rush": (5, 2, 3, 6, 0, 4, 3, 3, 1),
    "skill_rush_post": (2, 6, 3, 2, 0, 4, 3, 2, 1),
    "demon_aegis_farm": (3, 5, 3, 6, 0, 4, 3, 4, 1),
    "mega_icarus_spam_skill": (5, 5, 4, 6, 0, 5, 3, 4, 1),
    "bu_win": (0, 0, 0, 1, 6, 0, 3, 3, 1),
}
FOLLOWUP_TARGETS = {
    "simple": ("D", "R", "P"), "careful": ("D", "R", "P"),
    "skill_rush": ("R", "S"), "skill_rush_post": ("D", "P"),
    "demon_aegis_farm": ("S", "R", "P"),
    "mega_icarus_spam_skill": ("R", "S", "P"), "bu_win": (),
}
VERSION_CONFIG = FrozenJSON.of(dict(
    utility=UTILITY_VERSION, features=FEATURE_VERSION, model=MODEL_VERSION,
    weights=WEIGHTS, sufficiency_bonus=12, sword_reference=8,
    bucket_width=0.01, override_margin=0.05, future_discount=0.5,
    fixed_followup_targets=FOLLOWUP_TARGETS,
    resource_points={"rage": 20, "mana": 30}, status="PROPOSED_FOR_OFFLINE",
    coverage="ONE_STEP_NO_FUTURE_CREDIT",
))


def number(value: Any, name: str, low: float = 0, high: float = math.inf) -> float:
    require(type(value) in (int, float) and math.isfinite(value) and low <= value <= high,
            f"{name}: invalid finite number/range")
    return float(value)


def clip(value: float) -> float:
    return max(0.0, min(1.0, value))


@dataclass(frozen=True)
class Bound:
    low: float
    high: float
    status: str = "PRESENT"
    reason: str = "SUPPORTED_PROXY"

    def __post_init__(self) -> None:
        number(self.low, "lower bound", -1e6, 1e6)
        number(self.high, "upper bound", self.low, 1e6)

    @classmethod
    def fixed(cls, value: float, reason: str = "SUPPORTED_PROXY") -> Bound:
        return cls(value, value, "PRESENT", reason)

    @classmethod
    def missing(cls, reason: str) -> Bound:
        return cls(0, 1, "UNSUPPORTED", reason)

    def to_dict(self) -> dict:
        return dict(low=self.low, high=self.high, status=self.status, reason=self.reason)


@dataclass(frozen=True)
class CandidateScore:
    candidate_id: str
    action: Action
    baseline_member: bool
    features: tuple[tuple[str, Bound], ...]
    contributions: tuple[tuple[str, Bound], ...]
    utility: Bound
    evidence_rank: int
    details: FrozenJSON

    @property
    def bucket(self) -> int:
        return math.floor(self.utility.low / 0.01)

    def to_dict(self) -> dict:
        return dict(candidate_id=self.candidate_id, action=self.action.to_dict(),
                    baseline_member=self.baseline_member, bucket=self.bucket,
                    utility=self.utility.to_dict(), evidence_rank=self.evidence_rank,
                    features={k: v.to_dict() for k, v in self.features},
                    contributions={k: v.to_dict() for k, v in self.contributions},
                    details=self.details.plain())


def order_key(candidate: CandidateScore, profile: str) -> tuple:
    """Fixed buckets and canonical coordinates form a transitive total order."""
    f = dict(candidate.features)
    move = candidate.action.to_dict()["move"]
    coordinates = tuple(n for cell in (move or []) for n in cell)
    risk = -f["B"].low if profile == "bu_win" else f["T"].high
    progress = f["F"].low + f["R"].low + f["D"].low + f["B"].low
    return (-candidate.bucket, -candidate.evidence_rank, risk, f["X"].high,
            -progress, f["E"].high, candidate.action.family,
            candidate.action.card_source or "", coordinates, candidate.candidate_id)


@dataclass(frozen=True)
class PlannerDecision:
    snapshot_id: str
    config_hash: str
    baseline: Action
    disposition: str
    reason: str
    proposal: Action | None
    scores: tuple[CandidateScore, ...]
    diagnostics: FrozenJSON

    def to_dict(self) -> dict:
        return dict(schema="pokiguard.reasoning.offline_decision.v1",
                    utility_version=UTILITY_VERSION, feature_version=FEATURE_VERSION,
                    evaluation_config_hash=digest(VERSION_CONFIG.plain()),
                    snapshot_id=self.snapshot_id, config_hash=self.config_hash,
                    baseline=self.baseline.to_dict(), disposition=self.disposition,
                    reason=self.reason,
                    proposal=None if self.proposal is None else self.proposal.to_dict(),
                    scores=[score.to_dict() for score in self.scores],
                    diagnostics=self.diagnostics.plain(), input_authority=False)

    def dumps(self) -> str:
        return canonical_json(self.to_dict())


class Inputs:
    def __init__(self, snapshot: ReasoningSnapshot):
        self.snapshot = snapshot
        self.observations = dict(snapshot.observations)
        self.context = dict(snapshot.intent.scope.plain(), profile=snapshot.intent.profile,
                            session_id=snapshot.source.session_id, match_id=snapshot.source.match_id,
                            turn=snapshot.source.turn)
        self.missing: set[str] = set()
        self.used: dict[str, Evidence] = {}

    def value(self, name: str, unit: str | None = None) -> Any:
        ev = self.observations.get(name)
        if ev is None or ev.availability != "PRESENT" or ev.support == "UNKNOWN":
            self.missing.add(name)
            return None
        scope = ev.scope.plain()
        if scope is not None:
            require(isinstance(scope, dict), f"{name}: invalid scope")
            require(all(self.context.get(k) == v for k, v in scope.items()),
                    f"{name}: scope conflict")
        if unit is not None:
            require(ev.unit == unit, f"{name}: unit conflict")
        self.used[name] = ev
        return ev.value.plain()

    def stat(self, name: str, unit: str) -> float | None:
        value = self.value(name, unit)
        return None if value is None else number(value, name)


def removal_ledger(snapshot: ReasoningSnapshot, value: MoveEvaluation,
                   passive_cells: tuple[tuple[int, int], ...] | None = None) -> dict:
    """Map round-local coordinates to original IDs, without finding new matches.

    Demon comparisons use the common FIRST_WAVE_UNION scope. Its sweep changes
    collapse, so ordinary hypothetical cascades must not be added to that union.
    Other profiles can replay all existing ordinary clear rounds.
    """
    grid = [[(r, c) for c in range(8)] for r in range(8)]
    a, b = value.move.first, value.move.second
    grid[a[0]][a[1]], grid[b[0]][b[1]] = grid[b[0]][b[1]], grid[a[0]][a[1]]
    rounds = value.clear_rounds if passive_cells is None else (
        tuple(sorted(set(value.clear_rounds[0]) | set(passive_cells))),)
    removed: set[tuple[int, int]] = set()
    for cells in rounds:
        for r, c in cells:
            original = grid[r][c]
            if original is not None:
                require(original not in removed, "duplicate original removal")
                removed.add(original)
        cleared = set(cells)
        for c in range(8):
            survivors = [grid[r][c] for r in range(8) if (r, c) not in cleared]
            column = [None] * (8 - len(survivors)) + survivors
            for r in range(8):
                grid[r][c] = column[r]
    totals = {g.value: dict(physical=0, effective=0) for g in GemType if g != GemType.UNKNOWN}
    for r, c in removed:
        gem, multiplier = snapshot.board[r][c]
        totals[gem]["physical"] += 1
        totals[gem]["effective"] += multiplier
    if passive_cells is None:
        require(all(v["physical"] == value.total.cells(GemType(g)) and
                    v["effective"] == value.total.effective(GemType(g))
                    for g, v in totals.items()), "ledger/simulator mismatch")
    return dict(original_cells=[list(cell) for cell in sorted(removed)], totals=totals,
                coverage="ORDINARY_KNOWN_CASCADES" if passive_cells is None else "FIRST_WAVE_UNION",
                excluded="UNKNOWN_REFILL_AND_PASSIVE_CASCADES")


def resource_credit(inputs: Inputs, model: dict, totals: dict) -> tuple[Bound, dict, Bound]:
    conversion = model.get("conversion")
    if conversion is not None:
        require(conversion == {"rage": 20, "mana": 30}, "conversion conflict with C-R20-M30")
    requirements = model.get("requirements")
    require(requirements is None or isinstance(requirements, dict) and
            set(requirements) <= {"rage", "mana"}, "invalid actual requirements")
    records, progress, gaps = {}, [], []
    unavailable = False
    for gem, points in (("rage", 20), ("mana", 30)):
        raw = totals[gem]
        current = inputs.stat("self." + gem, gem + "_points")
        cap = inputs.stat("self.max_" + gem, gem + "_points")
        req = None if requirements is None else requirements.get(gem, 0)
        if req is not None:
            req = number(req, "actual " + gem + " requirement")
        require(current is None or cap is None or current <= cap, "resource exceeds cap")
        gain = raw["effective"] * points if conversion is not None and (
            model.get("multiplier_supported") is True or raw["physical"] == raw["effective"]) else None
        net = min(gain, max(0, cap - current)) if all(x is not None for x in (gain, cap, current)) else None
        deficit = max(0, req - current) if req is not None and current is not None else None
        records[gem] = dict(**raw, points_per_x1=points if conversion else None,
                            gross_points=gain, current_points=current, cap_points=cap,
                            capped_gain_points=net, actual_requirement=req,
                            deficit_points=deficit, conversion_support="USER_CALIBRATED" if conversion else "MISSING")
        if req == 0:
            continue
        if req is None or deficit is None or (net is None and raw["physical"]):
            unavailable = True
            continue
        if deficit > 0:
            progress.append(min(net or 0, deficit) / req)
        gaps.append(deficit / req)
    r = Bound.missing("ACTUAL_COST_CAP_OR_CONVERSION_MISSING") if unavailable else Bound.fixed(
        sum(progress) / len(progress) if progress else 0, "ACTUAL_DEFICIT_CLOSED_NO_OVERFLOW_CREDIT")
    gap = Bound.missing("ACTUAL_COST_CONTEXT_MISSING") if unavailable else Bound.fixed(
        clip(sum(gaps) / len(gaps)) if gaps else 0)
    return r, records, gap


def pressure_context(inputs: Inputs) -> Bound:
    hp = inputs.stat("self.hp", "hp_points")
    cap = inputs.stat("self.max_hp", "hp_points")
    threat = inputs.value("planner.known_boss_threat", "normalized")
    if threat is not None:
        threat = number(threat, "known boss threat", 0, 1)
    if hp is None or cap is None or cap <= 0:
        return Bound(threat or 0, 1, "UNSUPPORTED", "HP_CONTEXT_MISSING")
    require(hp <= cap, "HP exceeds max HP")
    hp_pressure = 1 - hp / cap
    return Bound.fixed(max(hp_pressure, threat)) if threat is not None else Bound(
        hp_pressure, 1, "UNSUPPORTED", "BOSS_THREAT_CONTEXT_MISSING")


def context_weights(profile: str, pressure: Bound, gap: Bound, post_skill: bool) -> dict[str, Bound]:
    base = WEIGHTS["skill_rush_post" if profile == "skill_rush" and post_skill else profile]
    result = {k: Bound.fixed(v) for k, v in zip(FEATURES[1:], base)}
    result["F"] = Bound.fixed(12)
    if profile == "bu_win":
        return result
    for key, scale, context in (("R", 1, gap), ("P", 2, pressure),
                                ("T", 2, pressure), ("X", 1, pressure)):
        v = result[key].low
        result[key] = Bound(v * (1 + scale * context.low), v * (1 + scale * context.high),
                            context.status, context.reason)
    v = result["H"].low
    result["H"] = Bound(v * (1 - .5 * pressure.high), v * (1 - .5 * pressure.low),
                        pressure.status, pressure.reason)
    return result


def protection_credit(inputs: Inputs, model: dict, totals: dict) -> Bound:
    hp, cap = inputs.stat("self.hp", "hp_points"), inputs.stat("self.max_hp", "hp_points")
    active = [g for g in ("health", "drain", "shield") if totals[g]["effective"]]
    if not active:
        return Bound.fixed(0, "NO_PROTECTION_RESOURCE_COLLECTED")
    rules = model.get("protection", {})
    require(isinstance(rules, dict) and set(rules) <= {"health", "drain", "shield"},
            "invalid protection model")
    if hp is None or cap is None or cap <= 0 or any(g not in rules for g in active):
        return Bound.missing("PROTECTION_EFFECT_OR_HP_MISSING")
    healing, barrier = 0.0, 0.0
    for gem in active:
        rule = rules[gem]
        require(isinstance(rule, dict) and set(rule) == {"points_per_effective", "kind"},
                "invalid protection conversion")
        require(rule["kind"] in ("heal", "barrier"), "unsupported protection kind")
        points = number(rule["points_per_effective"], "protection points") * totals[gem]["effective"]
        if rule["kind"] == "heal":
            healing += points
        else:
            barrier += points
    return Bound.fixed(clip((min(healing, cap - hp) + barrier) / cap),
                       "SCOPED_EFFECT_PROXY_NOT_INVENTED_HEAL")


def sufficiency(inputs: Inputs, model: dict, ledger: dict, passive: bool,
                resources: dict) -> tuple[Bound, dict]:
    if not passive:
        return Bound.fixed(0, "NO_SUPPORTED_SUFFICIENCY_CERTIFICATE"), {}
    certificates = model.get("demon_certificates", [])
    require(isinstance(certificates, list) and len(certificates) <= 16, "invalid certificates")
    unknown_order = False
    for cert in certificates:
        require(isinstance(cert, dict) and set(cert) == {
            "id", "scope", "physical_swords", "rage_points", "rage_mode"}, "invalid certificate")
        require(isinstance(cert["id"], str) and cert["id"], "certificate version required")
        scope = cert["scope"]
        require(isinstance(scope, dict) and all(k in scope for k in
                ("account_binding", "boss", "loadout")), "certificate binding incomplete")
        if any(v in (None, "UNKNOWN", "NOT_PUBLISHED") or inputs.context.get(k) != v
               for k, v in scope.items()):
            continue
        require(type(cert["physical_swords"]) is int, "physical Sword requirement must be integer")
        swords = number(cert["physical_swords"], "physical Sword requirement", 1, 64)
        rage = number(cert["rage_points"], "Rage requirement")
        require(cert["rage_mode"] in ("preexisting", "joint_calibrated", "after_gain"),
                "invalid Rage timing mode")
        if ledger["passive_swords"]["physical"] < swords:
            continue
        actual = resources["rage"]["current_points"]
        if actual is None:
            unknown_order = True
            continue
        if cert["rage_mode"] != "preexisting":
            net = resources["rage"]["capped_gain_points"]
            if net is None:
                unknown_order = True
                continue
            actual += net
        if actual < rage:
            continue
        if cert["rage_mode"] == "after_gain" and model.get("effect_order") != "GAIN_BEFORE_BURST":
            unknown_order = True
            continue
        return Bound.fixed(1, "USER_CALIBRATED_NOMINAL_SUFFICIENCY"), dict(
            certificate=cert, support="USER_CALIBRATED", observed_win=False,
            dominance_tier=False, effect_order_proven=cert["rage_mode"] == "preexisting" or
            model.get("effect_order") == "GAIN_BEFORE_BURST")
    return (Bound.missing("SUFFICIENCY_RESOURCE_OR_ORDER_UNRESOLVED") if unknown_order else
            Bound.fixed(0, "NO_APPLICABLE_SUFFICIENCY_CREDIT")), {}


def team_credit(model: dict, value: MoveEvaluation, totals: dict) -> Bound:
    # This proxy is explicitly supplied team intent, not a team-WIN predictor.
    intent = model.get("team_intent")
    if intent != "FEED_BOSS_SWORD_AND_TURNOVER":
        return Bound.missing("TEAM_INTENT_MISSING_OR_UNSUPPORTED")
    return Bound.fixed(clip(.75 * value.sword_risk.opponent_sword_reply_effective_max / 8 +
                            .25 * sum(t["physical"] for t in totals.values()) / 8),
                       "SCOPED_TEAM_OPPORTUNITY_PROXY_NO_WIN_CLAIM")


def score_candidate(snapshot: ReasoningSnapshot, sid: str, action: Action, features: dict[str, Bound],
                    weights: dict[str, Bound], details: dict, rank: int) -> CandidateScore:
    contributions = {}
    for key in FEATURES:
        f, w = features[key], weights[key]
        low, high = f.low * w.low, f.high * w.high
        if key in ("T", "X", "L", "E"):
            low, high = -high, -low
        contributions[key] = Bound(low, high, f.status, f.reason)
    lower = sum(c.low for c in contributions.values())
    upper = sum(c.high for c in contributions.values())
    if any(weights[k].high > 0 and (features[k].status == "UNSUPPORTED" or
                                   weights[k].status == "UNSUPPORTED") for k in FEATURES):
        rank = 0  # Weakest essential dependency, including unresolved intervals.
    return CandidateScore(digest(dict(snapshot_id=sid, action=action.to_dict())), action,
                          action.to_dict() == snapshot.baseline.to_dict(),
                          tuple((k, features[k]) for k in FEATURES), tuple(contributions.items()),
                          Bound(lower, upper, "PRESENT" if lower == upper else "BOUNDED",
                                "ONE_STEP_UTILITY_NOT_WIN_PROBABILITY"), rank, FrozenJSON.of(details))


def _plan(snapshot: ReasoningSnapshot) -> PlannerDecision:
    sid = snapshot.snapshot_id
    inputs = Inputs(snapshot)
    board = snapshot.board_state()  # Invalid observed state still fails closed.
    values = evaluate_all_moves(board)  # Every legal swap, never a setting/top-K filter.
    model = inputs.value("planner.model", "scoped_model")
    legal = inputs.value("planner.legality", "action_capability")
    base_diag = dict(source=snapshot.source.to_dict(), run_intent=snapshot.intent.to_dict(),
                     baseline_reason=snapshot.baseline_reason,
                     mode="OFFLINE_ONLY", coverage="ONE_STEP_NO_FUTURE_CREDIT",
                     adjacent_pairs=112, legal_root_swaps=len(values),
                     boss_refinement="NOT_IMPLEMENTED_5B3", future_discount=.5,
                     followup_targets=list(FOLLOWUP_TARGETS[snapshot.intent.profile]),
                     followup_status="NOT_EVALUATED_5B3", input_authority=False)

    def finish(reason: str, scores: tuple = (), proposal: Action | None = None,
               extra: dict | None = None) -> PlannerDecision:
        diag = dict(base_diag, missing_inputs=sorted(inputs.missing),
                    evidence_inputs={k: v.to_dict() for k, v in sorted(inputs.used.items())},
                    **(extra or {}))
        return PlannerDecision(sid, snapshot.intent.config_hash, snapshot.baseline,
                               "PROPOSE_OFFLINE" if proposal else "RETAIN_BASELINE",
                               reason, proposal, scores, FrozenJSON.of(diag))

    if model is None or legal is None:
        return finish("UNSUPPORTED_MODEL_OR_LEGALITY_CONTEXT")
    require(all(k in inputs.used["planner.model"].scope.plain()
                for k in ("profile", "session_id", "match_id")), "model scope binding incomplete")
    require(all(k in inputs.used["planner.legality"].scope.plain()
                for k in ("profile", "session_id", "match_id", "turn")), "legality scope binding incomplete")
    require(isinstance(model, dict) and model.get("version") == MODEL_VERSION,
            "unsupported model version")
    require(set(model) <= {"version", "conversion", "multiplier_supported", "requirements",
                          "protection", "demon_certificates", "effect_order", "action_models",
                          "team_intent", "post_skill_session", "execution_costs"}, "unknown model fields")
    require(isinstance(legal, dict) and set(legal) == {
        "owner", "swap_allowed", "pass_allowed", "mandatory", "blocked"}, "invalid legality context")
    require(all(type(legal[k]) is bool for k in ("swap_allowed", "pass_allowed", "mandatory", "blocked")),
            "invalid legality flag")
    # Nothing here can own Evolution/post-skill continuation or replace a sent input.
    if legal["owner"] != "ROOT_TURN" or legal["blocked"]:
        return finish("EXISTING_OWNER_OR_PENDING_BOUNDARY")
    pressure = Bound.fixed(0, "TEAM_INTENT_NO_SOLO_PRESSURE") if snapshot.intent.profile == "bu_win" else pressure_context(inputs)
    weights = None
    scores = []
    excluded = []
    for value in values if legal["swap_allowed"] else ():
        passive = evaluate_demon_aegis_move(board, value, include_next_turn=False,
            target_gem=GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield"))) if snapshot.intent.profile == "demon_aegis_farm" else None
        ledger = removal_ledger(snapshot, value, passive.blast_cells if passive is not None else None)
        if passive is not None:
            ledger["passive_swords"] = dict(physical=passive.sword_cells, effective=passive.sword_effective)
        totals = ledger["totals"]
        r, resources, gap = resource_credit(inputs, model, totals)
        weights = context_weights(snapshot.intent.profile, pressure, gap,
                                  model.get("post_skill_session") == snapshot.source.session_id)
        f, certificate = sufficiency(inputs, model, ledger, bool(passive and passive.activates_passive), resources)
        # Ordinary simulator's reply geometry is not valid after a Demon sweep.
        altered = bool(passive and passive.activates_passive)
        t = Bound.missing("PASSIVE_RESIDUAL_REPLY_NOT_MODELED") if altered else Bound.fixed(
            clip(value.sword_risk.opponent_sword_reply_effective_max / 8), "KNOWN_ORDINARY_SWORD_REPLY_PROXY")
        unknown_count = len(ledger["original_cells"]) if altered else value.unknown_exposure.cells
        sword_interaction = bool(value.unknown_exposure.hypothetical_sword_completions)
        x = (Bound(clip(unknown_count / 64), clip(unknown_count / 64 + .5),
                   "UNSUPPORTED", "PASSIVE_RESIDUAL_TARGET_SWORD_INTERACTIONS_UNMODELED") if altered else
             Bound.fixed(clip(unknown_count / 64 + .25 * sword_interaction),
                         "UNKNOWN_EXPOSURE_PROXY_NO_REFILL_CREDIT"))
        features = dict(F=f, R=r, D=Bound.fixed(clip(totals["sword"]["effective"] / 8), "SWORD_UNITS_PROXY_NOT_HP_DAMAGE"),
                        P=protection_credit(inputs, model, totals), H=Bound.fixed(0, "NO_UNEXAMINED_FUTURE_CREDIT"),
                        B=team_credit(model, value, totals) if snapshot.intent.profile == "bu_win" else Bound.fixed(0),
                        T=t, X=x,
                        L=Bound.fixed(0, "NO_FUTURE_CONTEST_CREDIT_OR_DOUBLE_PENALTY"),
                        E=Bound.missing("EXECUTION_COST_NOT_MEASURED"))
        action = Action("swap", value.move)
        costs = model.get("execution_costs", {})
        require(isinstance(costs, dict), "invalid execution costs")
        cost_key = canonical_json(action.to_dict())
        if cost_key in costs:
            features["E"] = Bound.fixed(number(costs[cost_key], "execution cost", 0, 1), "SUPPLIED_RESERVE_FRACTION_SCOPE_IN_EVIDENCE")
        details = dict(ledger=ledger, resources=resources, certificate=certificate,
                       settings_reference=snapshot.intent.settings.plain(), setting_is_eligibility_gate=False,
                       pressure=pressure.to_dict(), cost_gap=gap.to_dict(),
                       weights={k: v.to_dict() for k, v in weights.items()},
                       boss_reply_count=len(value.sword_replies), boss_reply_coverage="ORDINARY_PROXY_ONLY" if not altered else "UNSUPPORTED",
                       target_interaction="FUTURE_TARGET_NOT_EVALUATED_5B3",
                       multiplier_uncertainty=model.get("multiplier_supported") is not True,
                       assumptions=["NO_FAVORABLE_REFILL", "NO_FUTURE_SETUP_CREDIT",
                                    "USER_SUFFICIENCY_IS_NOMINAL_NOT_OBSERVED_WIN"])
        rank = min([1] + [SUPPORT_RANK[e.support] for e in inputs.used.values()])
        scores.append(score_candidate(snapshot, sid, action, features, weights, details, rank))
    # Typed effect evidence can compare a card/PASS only within its explicit scope.
    action_models = model.get("action_models", [])
    require(isinstance(action_models, list) and len(action_models) <= 16, "invalid action models")
    if action_models:
        require(all(k in inputs.used["planner.model"].scope.plain() and
                    inputs.context.get(k) not in (None, "UNKNOWN", "NOT_PUBLISHED")
                    for k in ("account_binding", "boss", "loadout")),
                "card effect model scope binding incomplete")
    for spec in action_models:
        require(isinstance(spec, dict) and set(spec) == {
            "action", "legal", "source_valid", "consumes_turn", "costs", "effects", "reference"},
            "invalid action model")
        action = Action.from_dict(spec["action"])
        require(type(spec["legal"]) is bool and type(spec["source_valid"]) is bool and
                type(spec["consumes_turn"]) is bool, "invalid action capability flags")
        valid = spec["legal"] and spec["source_valid"] and spec["consumes_turn"]
        valid &= action.family in ("cast", "pet_skill", "pass")
        valid &= action.family == "pass" or bool(action.card_source)
        valid &= snapshot.intent.profile != "bu_win" or action.family == "pass"
        if action.family == "pass":
            valid &= legal["pass_allowed"] and not legal["mandatory"]
        require(isinstance(spec["costs"], dict) and set(spec["costs"]) <= {"mana", "rage"}, "invalid action costs")
        require(action.family == "pass" or set(spec["costs"]) == {"mana", "rage"},
                "actual Mana/Rage costs must both be explicit")
        for resource, cost in spec["costs"].items():
            cost = number(cost, "action cost")
            actual = inputs.stat("self." + resource, resource + "_points")
            valid &= actual is not None and actual >= cost
        if not valid:
            excluded.append(dict(action=action.to_dict(), reason="UNSUPPORTED_OR_ILLEGAL_ACTION_CAPABILITY"))
            continue
        require(isinstance(spec["reference"], str) and spec["reference"], "effect reference required")
        effects = spec["effects"]
        require(isinstance(effects, dict) and set(effects) == set(FEATURES) - {"H", "L"},
                "opaque/incomplete card effect comparison")
        features = {k: Bound.fixed(number(v, "effect " + k, 0, 1), "SCOPED_SUPPLIED_EFFECT_PROXY") for k, v in effects.items()}
        features.update(H=Bound.fixed(0, "NO_FUTURE_CREDIT"), L=Bound.fixed(0, "NO_FUTURE_CONTEST"))
        _, _, gap = resource_credit(inputs, model, {g.value: dict(physical=0, effective=0) for g in GemType if g != GemType.UNKNOWN})
        weights = context_weights(snapshot.intent.profile, pressure, gap,
                                  model.get("post_skill_session") == snapshot.source.session_id)
        scores.append(score_candidate(snapshot, sid, action, features, weights,
                                      dict(effect_reference=spec["reference"], source_valid=True,
                                           costs=spec["costs"], pressure=pressure.to_dict(),
                                           settings_reference=snapshot.intent.settings.plain(),
                                           weights={k: v.to_dict() for k, v in weights.items()},
                                           observed_win=False, future_credit=0),
                                      min(SUPPORT_RANK[e.support] for e in inputs.used.values())))
    ids = [s.candidate_id for s in scores]
    require(len(ids) == len(set(ids)), "duplicate action model")
    ordered = tuple(sorted(scores, key=lambda c: order_key(c, snapshot.intent.profile)))
    extra = dict(excluded_actions=excluded, pressure=pressure.to_dict(),
                 baseline_scored=any(c.baseline_member for c in ordered),
                 resource_conversion_claim="USER_CALIBRATED_NOT_RUNTIME_VERIFIED",
                 settings_are_advisory=True)
    baseline = next((s for s in ordered if s.baseline_member), None)
    if baseline is None:
        return finish("OPAQUE_OR_UNSCORABLE_BASELINE", ordered, extra=extra)
    if not ordered or ordered[0].baseline_member:
        return finish("BASELINE_TOP_IN_TOTAL_ORDER", ordered, extra=extra)
    best = ordered[0]
    robust_gap = best.utility.low - baseline.utility.high
    nominal_gap = best.utility.low - baseline.utility.low
    extra.update(best_candidate_id=best.candidate_id, robust_gap=robust_gap,
                 lower_score_gap=nominal_gap, override_margin=.05)
    if robust_gap < .05:
        return finish("NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE", ordered, extra=extra)
    return finish("ROBUST_ONE_STEP_PROXY_IMPROVEMENT", ordered, best.action, extra)


def plan(snapshot: ReasoningSnapshot) -> PlannerDecision:
    """Return an offline proposal or explicit retention. Never dispatch anything.

    Invalid state has a dedicated disposition reason; retaining the incumbent
    here does not make an invalid state executable through existing preflight.
    Unexpected programmer errors remain visible to the future isolated runner.
    """
    require(isinstance(snapshot, ReasoningSnapshot), "immutable snapshot required")
    try:
        if snapshot.recorded.plain().get('d3_demon') is not None:
            from .reasoning_demon import plan_demon
            return plan_demon(snapshot)
        if snapshot.recorded.plain().get('d2_actions') is not None:
            from .reasoning_full_action_planner import plan_full_actions
            return plan_full_actions(snapshot)
        return _plan(snapshot)
    except (ValueError, TypeError, KeyError) as exc:
        return PlannerDecision(snapshot.snapshot_id, snapshot.intent.config_hash, snapshot.baseline,
                               "RETAIN_BASELINE", "INVALID_OR_UNSUPPORTED_INPUT", None, (),
                               FrozenJSON.of(dict(error_type=type(exc).__name__, error=str(exc),
                                                  input_authority=False, invalid_state_must_fail_closed=True,
                                                  source=snapshot.source.to_dict(), mode="OFFLINE_ONLY")))
