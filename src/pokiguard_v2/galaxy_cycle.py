"""G1/G3 resource-cycle tactics over the established board solver.

No random outcome, mark damage, stun, drain immunity or healing is invented.
Refund projections only break charging ties; they never make a cast eligible.
"""
from .galaxy_glank import GlankPlan
from .galaxy_profiles import G1_OPTIONS, G3_STAGES, current_profile
from .state import GemType


class GalaxyCyclePlanner:
    def __init__(self):
        self.session = None
        self.opening_seen = False
        self.source = None
        self.complete_tool_history = False
        self.last_count = 0

    def observe(self, state):
        if self.session != state.battle.session_key:
            self.session = state.battle.session_key
            self.opening_seen = False
            self.source = None
            self.complete_tool_history = False
            self.last_count = 0
        if state.battle.is_first_local_turn is True:
            self.opening_seen = True

    def context(self, state, capability, history):
        self.observe(state)
        profile = current_profile(capability, state.battle.session_key)
        if profile is None or profile.alias not in ("G1", "G3"):
            return None
        current_history = history is not None and history.session_key == state.battle.session_key
        count = history.successful_pet_skills if current_history else None
        latest = history.latest_success_source_turn if current_history else None
        source = (profile.element_type, capability.skill_card_id, capability.card_data_address)
        if self.source is None:
            self.complete_tool_history = self.opening_seen and count == 0
        elif self.source != source:
            # Seeing a different card mid-match does not prove its initial phase.
            self.complete_tool_history = False
        if count is not None and count < self.last_count:
            self.complete_tool_history = False
        self.source = source
        if count is not None:
            self.last_count = count
        phase, support = None, "UNKNOWN"
        if (type(capability.skill_phase_next) is int
                and capability.skill_phase_max == profile.cycle_length
                and 1 <= capability.skill_phase_next <= profile.cycle_length
                and capability.skill_phase_source == "MatchService.Players.local.skillPhaseNext/Max/CardId"):
            phase, support = capability.skill_phase_next, "CURRENT_RUNTIME_CARD_PHASE"
        elif capability.skill_phase_next is not None or capability.skill_phase_max is not None:
            support = "UNKNOWN_PHASE_CONFLICT"
        elif (capability.skill_phase_source or "").startswith("UNKNOWN:phase_read_unavailable"):
            support = "UNKNOWN_RUNTIME_PHASE_INVALID"
        elif (self.complete_tool_history and type(count) is int and count >= 0
                and (latest is None or (state.battle.turn_number is not None and latest < state.battle.turn_number))):
            phase, support = count % profile.cycle_length + 1, "TOOL_HISTORY_ESTIMATE_FROM_OBSERVED_OPENING"
        facts = dict(pet_alias=profile.alias, pet_name=profile.name, element_type=profile.element_type,
            identity_source="CURRENT_OWNED_CARD_UI", next_phase=phase, phase_support=support,
            phase_observation_source=capability.skill_phase_source or "UNKNOWN",
            observed_tool_successes=count, random_outcome="UNKNOWN", active_buff_remaining="UNKNOWN",
            stored_mark_damage="UNKNOWN", current_cost_credit_from_refund=0, refill_credit=0,
            model_support="USER_CARD_DESCRIPTION_AND_CAPTURED_B15_CARDDATA",
            next_cycle_projection="CONDITIONAL_AFTER_COST_NOT_CURRENT_RESOURCE_AUTHORITY")
        if profile.alias == "G1":
            facts.update(random_options=G1_OPTIONS, random_probabilities="UNKNOWN",
                doubled_fourth=(phase == 4 if phase is not None else None),
                guaranteed_heal=0, guaranteed_stun_turns=0,
                guaranteed_mana_refund=0, guaranteed_rage_refund=0)
        else:
            facts.update(declared_stage=G3_STAGES.get(phase),
                declared_stage_alternatives=tuple(G3_STAGES.values()) if phase is None else None)
        return facts

    def decide(self, state, evaluations, *, capability, history, can_cast,
               required_mana, required_rage, missing_mana, missing_rage,
               protection_ratio, pass_allowed):
        facts = self.context(state, capability, history)
        if facts is None:
            return None
        alias = facts["pet_alias"]
        own = state.player
        hp_ratio = own.hp / own.max_hp if own.hp is not None and own.max_hp and own.max_hp > 0 else None
        boss = next((actor for actor in state.opponents if actor.is_boss), None)
        facts.update(hp_ratio=hp_ratio, mana=own.mana, rage=own.power,
            required_mana=required_mana, required_rage=required_rage,
            missing_mana=missing_mana, missing_rage=missing_rage)

        def result(action, step, selected=None, **detail):
            return GlankPlan(action, "GALAXY_" + alias + "_" + step, selected, dict(facts, **detail))

        # Ready G1/G3 keep the successful immediate-cast behavior. No board
        # threshold or guessed future refund is required to authorize it.
        if can_cast:
            if alias == "G1":
                return result("pet_skill", "FIRE_FOURTH" if facts["doubled_fourth"] else "FIRE_RANDOM_CARD")
            return result("pet_skill", "FIRE_STAGE_" + str(facts["next_phase"] or "UNKNOWN"))

        sword_allowed = own.power == 0
        facts["sword_allowed"] = sword_allowed
        eligible = tuple(m for m in evaluations if sword_allowed or m.sword_effective == 0)
        safe = tuple(m for m in eligible if m.sword_risk.safe)
        if not eligible:
            return result("pass", "WAIT_RAGE_PRESERVE") if pass_allowed else result("none", "SWORD_BLOCKED_WITH_RAGE")

        def gain(move, gem, rate, current, maximum):
            value = move.total.effective(gem) * rate
            return min(value, max(0, maximum-current)) if maximum is not None else value

        def resource_values(move):
            mana = gain(move, GemType.MANA, 30, own.mana, own.max_mana)
            rage = gain(move, GemType.RAGE, 20, own.power, own.max_power)
            completed = int(bool(missing_mana) and mana >= missing_mana) + int(bool(missing_rage) and rage >= missing_rage)
            progress = (min(mana, missing_mana or 0)/required_mana if required_mana else 0)
            progress += min(rage, missing_rage or 0)/required_rage if required_rage else 0
            stage = facts.get("declared_stage") or {}
            # G1 RNG and unknown G3 phase receive no guaranteed refund credit.
            refund_mana, refund_rage = stage.get("mana_refund", 0), stage.get("rage_refund", 0)
            next_mana = max(0, own.mana + mana - required_mana) + refund_mana
            next_rage = max(0, own.power + rage - required_rage) + refund_rage
            if own.max_mana is not None:
                next_mana = min(next_mana, own.max_mana)
            if own.max_power is not None:
                next_rage = min(next_rage, own.max_power)
            next_deficit = max(
                max(0, required_mana-next_mana)/required_mana if required_mana else 0,
                max(0, required_rage-next_rage)/required_rage if required_rage else 0)
            return completed, progress, next_deficit

        def rank(move):
            completed, progress, next_deficit = resource_values(move)
            risk = move.sword_risk
            return (-completed, -round(progress, 9), round(next_deficit, 9),
                risk.opponent_sword_reply_effective_max, risk.opponent_sword_replies,
                move.unknown_exposure.cells, risk.danger_score, move.move)

        protecting = (protection_ratio is not None and hp_ratio is not None and hp_ratio <= protection_ratio)
        if protecting:
            for gem in (GemType.HEALTH, GemType.SHIELD, GemType.DRAIN):
                pool = tuple(m for m in safe if m.total.effective(gem) > 0)
                if pool:
                    chosen = min(pool, key=lambda m: (-m.total.effective(gem), rank(m)))
                    return result("swap", "PROTECT_" + gem.value.upper(), chosen)
        safe_progress = tuple(m for m in safe if resource_values(m)[1] > 0)
        if safe_progress:
            chosen = min(safe_progress, key=rank)
            return result("swap", "RESOURCE_CYCLE", chosen,
                          conditional_next_cycle_deficit=resource_values(chosen)[2])
        risk_floor = .4 if alias == "G1" and facts["doubled_fourth"] is True else .5
        risky_progress = tuple(m for m in eligible if resource_values(m)[1] > 0)
        if risky_progress and hp_ratio is not None and hp_ratio > risk_floor and not protecting:
            chosen = min(risky_progress, key=lambda m: (
                m.sword_risk.opponent_sword_reply_effective_max, rank(m)))
            nominal_reply = (chosen.sword_risk.opponent_sword_reply_effective_max * boss.attack
                             if boss is not None and boss.attack is not None else None)
            if nominal_reply is not None and own.hp is not None and nominal_reply < .15 * own.hp:
                return result("swap", "RESOURCE_RISK_ACCEPTED", chosen,
                    risk_hp_reference=risk_floor, nominal_reply_pressure=nominal_reply,
                    pressure_support="STRUCTURAL_PROXY_NOT_LETHALITY_PROOF")
        empty_swords = tuple(m for m in safe if sword_allowed and m.sword_effective > 0)
        if empty_swords:
            return result("swap", "SWORD_EMPTY_RAGE", min(empty_swords, key=lambda m: (-m.sword_effective, rank(m))))
        if safe:
            chosen = min(safe, key=lambda m: (
                -m.total.effective(GemType.HEALTH) * (1-hp_ratio if hp_ratio is not None else 1),
                -m.total.effective(GemType.SHIELD),
                -m.total.effective(GemType.DRAIN) if boss is not None and boss.mana else 0, rank(m)))
            return result("swap", "SUPPORT_CYCLE", chosen)
        chosen = min(eligible, key=lambda m: (m.sword_risk.opponent_sword_reply_effective_max,
                                             m.sword_risk.opponent_sword_replies, rank(m)))
        return result("swap", "LOWEST_KNOWN_RISK", chosen)
