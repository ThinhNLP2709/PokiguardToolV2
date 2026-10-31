"""Immutable Skill Rush action evidence from already supplied state.

Pure component only. No reader, worker, input, QTE or runtime activation.
Eligibility here describes evidence; existing action owners must independently
revalidate before dispatch. An available but unmodeled skill/PASS is never
assigned zero utility to make another family win.
"""
from dataclasses import dataclass
import hashlib

from .basic_policy import (
    PlayStyle, PolicyAction, SkillRushMatchContext, _FIRE_CONDITION_GEM_TYPE,
    _known_gem_effective_count,
)
from .board_diagnostics import jsonable
from .board_simulator import evaluate_all_moves
from .gameplay_profile import PetSkillFireCondition
from .pet_skill_shadow import (
    PetSkillCapability, PetSkillFamily, PetSkillTargetMode, PetSkillCostSource,
)
from .reasoning_snapshot import Action, FrozenJSON, canonical_json, digest
from .state import GameOwnedIdleStatus, GamePhase, GemType
from .game_owned_idle import ResetConfidence

VERSION = 'D2_ALL_ACTION_EVIDENCE_V2'


def current_ht7_source_binding(capability):
    """Bind the already owned card; absent PetUserDTO is explicitly UNKNOWN.

    The existing decision path deliberately resolves with source_pet=None.
    CardData/CardUI/Button and exact session ownership are still mandatory.
    Present conflicting pet metadata is never discarded to use this path.
    """
    if (type(capability) is not PetSkillCapability or not capability.current
            or capability.skill_card_id != 7 or capability.card_id != 7
            or capability.skill_family is not PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION
            or capability.target_mode is not PetSkillTargetMode.AUTOMATIC
            or not capability.live_card_present or capability.source != 'CARD_UI_BUTTON'
            or any(type(v) is not int or v <= 0 for v in
                (capability.card_data_address, capability.live_card_address, capability.live_button_address))):
        return None
    identity = (capability.pet_id, capability.source_pet_skill_card_id)
    if identity == (2035, 7):
        return 'CURRENT_OWNED_CARD_AND_VERIFIED_PET'
    if identity == (None, None):
        return 'CURRENT_OWNED_CARD_PET_ID_UNKNOWN'
    return None


@dataclass(frozen=True)
class ActionEvidence:
    action: Action
    eligible: bool
    reason: str
    baseline_member: bool
    facts: FrozenJSON
    comparison: str = 'EFFECT_MODEL_REQUIRED'


def incumbent_action(decision):
    if decision.action is PolicyAction.SWAP:
        return Action('swap', decision.move)
    if decision.action is PolicyAction.PET_SKILL:
        return Action('pet_skill', card_source=canonical_json(dict(
            session=jsonable(decision.skill_session_key), card_id=decision.skill_card_id)))
    if decision.action is PolicyAction.PASS:
        return Action('pass')
    return None  # EVOLVE/CAST/other owners have not been promoted by D2.


def action_candidates(state, config, baseline, *, capability=None, history=None,
                      owner_allowed=False, pending=False, enumerate_swaps=True, pass_owner_allowed=True,
                      allow_current_ht7_card_source=False):
    """Publish data, including excluded actions and their exact missingness.

    Callers supply the current owner result; this function cannot query it or
    grant authority. No setting threshold is used as an eligibility gate.
    """
    incumbent = incumbent_action(baseline)
    if config.play_style is not PlayStyle.SKILL_RUSH:
        raise ValueError('Skill Rush evidence only')
    closed = (type(history) is SkillRushMatchContext
        and history.session_key == state.battle.session_key
        and history.successful_pet_skills > 0
        and history.latest_success_source_turn is not None
        and state.battle.turn_number is not None
        and state.battle.turn_number <= history.latest_success_source_turn)
    root = (owner_allowed is True and pending is False and not closed
        and state.phase is GamePhase.COMBAT and state.battle.is_local_turn is True
        and state.battle.session_key is not None and state.player is not None
        and state.player.is_local is True and type(state.player.hp) is int
        and state.player.hp > 0 and state.board.production_ready)
    choices = []
    for value in (evaluate_all_moves(state.board) if enumerate_swaps else ()):
        action = Action('swap', value.move)
        choices.append(ActionEvidence(action, bool(root),
            'KNOWN_LEGAL_SWAP' if root else 'EXISTING_OWNER_OR_STATE_BLOCKED',
            action == incumbent, FrozenJSON.of(dict(
                resources=jsonable(value.total),
                boss_sword_reply_count=len(value.sword_replies),
                boss_sword_effective_max=value.sword_risk.opponent_sword_reply_effective_max,
                unknown_exposure=jsonable(value.unknown_exposure))),
            'ORDINARY_R1_PROXY_ONLY'))

    facts = dict(session=jsonable(state.battle.session_key),
        actual_costs=None, current_mana=None if state.player is None else state.player.mana,
        current_rage=None if state.player is None else state.player.power,
        advisory_fire_condition=config.pet_skill_fire_condition.value,
        advisory_fire_value=config.pet_skill_fire_value,
        advisory_condition_ready=None, current_skill_effect='UNKNOWN',
        successful_skills_current_match=(history.successful_pet_skills
            if type(history) is SkillRushMatchContext
            and history.session_key == state.battle.session_key else 0))
    condition = config.pet_skill_fire_condition
    if condition is not PetSkillFireCondition.SKILL_COST_READY:
        gem = _FIRE_CONDITION_GEM_TYPE.get(condition)
        count = _known_gem_effective_count(state.board, gem) if gem is not None else None
        facts['known_condition_effective_count'] = count
        facts['advisory_condition_ready'] = (count >= config.pet_skill_fire_value
            if count is not None and type(config.pet_skill_fire_value) is int else None)
    card_id = None
    skill_reason = 'SKILL_CAPABILITY_MISSING'
    if type(capability) is PetSkillCapability:
        card_id = capability.skill_card_id
        binding = (current_ht7_source_binding(capability) if allow_current_ht7_card_source
            else ('PET_SOURCE_CARD_MATCH' if capability.source_pet_skill_card_id == card_id else None))
        mana, rage = capability.effective_mana_cost, capability.effective_power_cost
        facts.update(actual_costs=dict(mana=mana, rage=rage),
            skill_card_id=card_id, pet_id=capability.pet_id,
            source_binding=binding,
            skill_family=capability.skill_family.value,
            cooldown_turns=capability.cooldown_turns,
            need_perfection=capability.need_perfection,
            timing_metadata=dict(eat_perfect=capability.eat_perfect,
                eat_good=capability.eat_good, eat_bad=capability.eat_bad))
        if not root:
            skill_reason = 'EXISTING_OWNER_OR_STATE_BLOCKED'
        elif not capability.current or capability.session_key != state.battle.session_key:
            skill_reason = 'SKILL_SOURCE_NOT_CURRENT'
        elif (type(card_id) is not int or card_id < 0
                or binding is None
                or capability.skill_family is not PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION
                or capability.target_mode is not PetSkillTargetMode.AUTOMATIC):
            skill_reason = 'SKILL_SOURCE_OR_FAMILY_UNSUPPORTED'
        elif not (capability.live_card_present and capability.live_card_actionable is True):
            skill_reason = 'SKILL_CARD_NOT_ACTIONABLE'
        elif (capability.card_id != card_id
                or capability.effective_mana_cost_source is not PetSkillCostSource.CONDITION_USE
                or capability.effective_power_cost_source is not PetSkillCostSource.POWER):
            skill_reason = 'SKILL_CARD_OR_COST_SOURCE_UNKNOWN'
        elif (type(mana) is not int or type(rage) is not int or min(mana, rage) < 0
                or type(capability.cooldown_turns) is not int):
            skill_reason = 'SKILL_COST_OR_COOLDOWN_UNKNOWN'
        elif capability.cooldown_turns != 0:
            skill_reason = 'SKILL_ON_COOLDOWN'
        elif (type(state.player.mana) is not int or type(state.player.power) is not int
                or state.player.mana < mana or state.player.power < rage):
            skill_reason = 'SKILL_RESOURCES_INSUFFICIENT'
        else:
            skill_reason = 'CURRENT_SKILL_AVAILABLE_EFFECT_UNMODELED'
    action = Action('pet_skill', card_source=canonical_json(dict(
        session=jsonable(state.battle.session_key), card_id=card_id)))
    choices.append(ActionEvidence(action,
        skill_reason == 'CURRENT_SKILL_AVAILABLE_EFFECT_UNMODELED', skill_reason,
        action == incumbent, FrozenJSON.of(facts)))

    battle = state.battle
    # The native cache owns reset certification and current-session readiness.
    # Its confirmed reset view deliberately has no numeric idle counter.
    # Consume that published proof; never synthesize idleCount=0 or certify it
    # from the mere occurrence of a swap/skill. Native PASS still revalidates.
    reset_allowed = (
        battle.consecutive_pass_status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED
        and battle.consecutive_passes is None
        and battle.consecutive_pass_threshold is None
        and battle.consecutive_pass_source == 'accepted_consuming_reset_baseline'
        and bool(battle.consecutive_pass_reset_evidence)
        and battle.consecutive_pass_confidence in (
            ResetConfidence.RESET_CONFIRMED_EXPLICIT.value,
            ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE.value))
    counter_allowed = (battle.consecutive_pass_status is GameOwnedIdleStatus.PASS_ALLOWED
        and type(battle.consecutive_passes) is int
        and type(battle.consecutive_pass_threshold) is int
        and bool(battle.consecutive_pass_source)
        and battle.consecutive_pass_threshold > 0
        and 0 <= battle.consecutive_passes < battle.consecutive_pass_threshold - 1)
    explicit = (reset_allowed or counter_allowed) and battle.is_first_local_turn is False
    legal_pass = root and explicit and pass_owner_allowed is True
    action = Action('pass')
    choices.append(ActionEvidence(action, bool(legal_pass),
        'AUTHORITATIVE_PASS_AVAILABLE_EFFECT_UNMODELED' if legal_pass else (
            'EXISTING_PASS_OWNER_UNAVAILABLE' if pass_owner_allowed is not True else 'PASS_NOT_AUTHORITATIVELY_ALLOWED'),
        action == incumbent, FrozenJSON.of(dict(
            count=battle.consecutive_passes, threshold=battle.consecutive_pass_threshold,
            status=battle.consecutive_pass_status.value, source=battle.consecutive_pass_source,
            reset_evidence=battle.consecutive_pass_reset_evidence,
            confidence=battle.consecutive_pass_confidence,
            authority_kind=('CONFIRMED_CONSUMING_RESET' if reset_allowed else
                'EXACT_SERVER_IDLE_COUNTER' if counter_allowed else 'UNKNOWN'),
            first_local_turn=battle.is_first_local_turn, automatic_wait_owner=True))))
    return tuple(choices)


def evidence_digest(choices):
    return digest([jsonable(choice) for choice in choices])


def ht7_perfect_first_wave(state, capability, *, account_sha256, allow_current_ht7_card_source=False):
    """User-calibrated conditional geometry, not a damage or refill model.

    Human clarification 2026-10-16: Perfect eats all Sword/Rage/Health, and the
    configured seven Sword counts effective units including multipliers.
    Current native control bound Alacclipse2035 to skill card7. Other accounts,
    pets/cards, non-Perfect results and downstream effects are not covered.
    """
    account = state.battle.local_username
    binding = current_ht7_source_binding(capability) if allow_current_ht7_card_source else None
    pet_source_valid = (binding is not None if allow_current_ht7_card_source else
        type(capability) is PetSkillCapability and capability.pet_id == 2035
        and capability.source_pet_skill_card_id == 7)
    if (not isinstance(account, str)
            or hashlib.sha256(account.casefold().encode()).hexdigest() != account_sha256
            or type(capability) is not PetSkillCapability or not capability.current
            or capability.session_key != state.battle.session_key
            or not pet_source_valid or capability.skill_card_id != 7
            or capability.skill_family is not PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION
            or not state.board.production_ready):
        raise ValueError('HT7 current account/pet/card/session geometry binding required')
    selected = (GemType.SWORD, GemType.RAGE, GemType.HEALTH)
    cells = []; counts = {g.value: dict(physical=0, effective=0) for g in selected}
    for row in state.board.cells:
        for cell in row:
            if cell.gem in selected:
                cells.append((cell.row, cell.col))
                counts[cell.gem.value]['physical'] += 1
                counts[cell.gem.value]['effective'] += cell.multiplier
    return FrozenJSON.of(dict(version='HT7_USER_PERFECT_FIRST_WAVE_V1',
        origin='USER_CALIBRATED', reference='HUMAN_CLARIFICATION_2026_10_16',
        condition='PERFECT_ONLY', scope=dict(account_sha256=account_sha256,
            pet_id=capability.pet_id, skill_card_id=7, session=jsonable(state.battle.session_key),
            calibration_pet_id=2035, source_binding=binding or 'VERIFIED_PET_AND_CARD',
            runtime_pet_identity=('UNKNOWN_NOT_PUBLISHED_BY_DECISION_PATH'
                if capability.pet_id is None else 'OBSERVED_PET_METADATA')),
        original_cells=cells, quantities=counts, threshold_unit='EFFECTIVE_SWORD_UNITS',
        coverage='CONDITIONAL_FIRST_WAVE_ONLY',
        excluded=['GOOD_BAD_EFFECT', 'DAMAGE_HP', 'HEAL_POINTS', 'REFILL',
            'POST_SKILL_CASCADES', 'COST_GAIN_ORDER', 'NEXT_TURN_RESOURCE_BALANCE'],
        observed_result=False, input_authority=False))
