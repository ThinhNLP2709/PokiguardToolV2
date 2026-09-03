from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.combat_cards import CardDataState  # noqa: E402
from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    BoundQteObservation,
    CardUiQteSnapshot,
    PetSkillSnapshot,
    QteBindingStatus,
    QteGenerationIdentity,
    QteResponseCorrelation,
    QteWindowSnapshot,
    ServerQteChallengeSnapshot,
)
from pokiguard_v2.pet_skill_shadow import (  # noqa: E402
    DeltaVerification,
    LivePetSkillCard,
    PetSkillCapabilityProvider,
    PetSkillCapabilityStatus,
    PetSkillCostSource,
    PetSkillFamily,
    PetSkillTargetMode,
    QteDirection,
    QteEvidenceStatus,
    QteObserver,
    QteTimingRegion,
    QteTimingResult,
    direction_from_runtime,
    pet_skill_family,
    resolve_pet_skill_cost,
)
from pokiguard_v2.state import CombatSessionKey  # noqa: E402


SESSION_A = CombatSessionKey(1, 0x100000, "M_A")
SESSION_B = CombatSessionKey(2, 0x200000, "M_B")


def card(**changes: object) -> CardDataState:
    values: dict[str, object] = {
        "address": 0x300000,
        "data_id": 0,
        "card_id": 7,
        "name": "Huyền Thoại 7",
        "description": None,
        "element_type": "ATTACK_LEGEND_",
        "skill_type": None,
        "value": 0,
        "max_level": 0,
        "count": 0,
        "level": 14,
        "condition_use": 200,
        "power": 200,
        "green": 1,
        "blue": 0,
        "red": 1,
        "yellow": 1,
        "white": 0,
        "purple": 0,
        "damage_multiplier": 1.8,
        "mana_cost": 0,
        "power_cost": 0,
        "cooldown_turns": 0,
        "need_perfection": False,
        "eat_perfect": 0,
        "eat_good": 20,
        "eat_bad": 12,
    }
    values.update(changes)
    return CardDataState(**values)  # type: ignore[arg-type]


def source_pet(*, with_card: bool = False, skill_card_id: int | None = None) -> PetSkillSnapshot:
    owned = card() if with_card else None
    resolved_id = 7 if with_card and skill_card_id is None else skill_card_id
    return PetSkillSnapshot(
        address=0x400000,
        data_id=0,
        user_id=None,
        pet_id=2306,
        skill_card_id=resolved_id,
        name="Silas",
        skill_card_name="Huyền Thoại 7" if with_card else None,
        element_type="EARTH",
        level=14,
        max_level=12,
        mana_skill_card=0,
        evo_stage=0,
        card_data_address=owned.address if owned else None,
        card_data=owned,
        card_identity_matches=True if owned else None,
    )


def candidate(
    *,
    session: CombatSessionKey = SESSION_A,
    value: CardDataState | None = None,
    card_ui_address: int | None = 0x500000,
    button_validated: bool = True,
    interactable: bool | None = True,
) -> LivePetSkillCard:
    return LivePetSkillCard(
        session_key=session,
        card_data=value or card(),
        card_ui_address=card_ui_address,
        board_instance=session.board_instance,
        active_instance=0x600000,
        button_address=0x700000 if button_validated else None,
        button_interactable=interactable if button_validated else None,
        button_validated=button_validated,
        source="ACTIVE_DOT_SKILL_CARD",
    )


def capability(
    *,
    session: CombatSessionKey = SESSION_A,
    value: CardDataState | None = None,
) -> object:
    return PetSkillCapabilityProvider().observe(
        observed_at=100.0,
        current_session=session,
        source_pet=source_pet(),
        candidates=(candidate(session=session, value=value),),
    )


def qte(
    *,
    index: int = 0,
    correct: int = 0,
    active: bool = True,
    finished: bool = False,
    elapsed: float = 1.0,
    perfect_start: float = 3.0,
    perfect_end: float = 3.3,
    displayed: str | None = None,
    presses: tuple[str, ...] = (),
) -> CardUiQteSnapshot:
    duration = 6.0
    return CardUiQteSnapshot(
        address=0x500000,
        card_data_address=0x300000,
        button_address=0x700000,
        button_interactable=True,
        button_validated=True,
        board_instance=SESSION_A.board_instance,
        active_instance=0x600000,
        actor_number=1,
        duration_seconds=duration,
        current_index=index,
        correct_count=correct,
        active=active,
        current_time_value=1.0 - elapsed / duration,
        damage_multiplier=1.8,
        finished=finished,
        displayed_timing_text=displayed,
        displayed_timing_result=displayed,
        current_arrows_list_address=0x810000,
        current_arrow_count=4,
        perfect_start_seconds=perfect_start,
        perfect_end_seconds=perfect_end,
        good_start_1_seconds=2.0,
        good_end_1_seconds=3.0,
        good_start_2_seconds=3.3,
        good_end_2_seconds=5.0,
        timing_bonus=0,
        current_arrow_seed=55,
        qte_presses_list_address=0x820000,
        qte_presses=presses,
    )


SEQUENCE = ("nutUp", "nutDown", "nutLeft", "nutRight")


def challenge(*, session: CombatSessionKey = SESSION_A) -> ServerQteChallengeSnapshot:
    return ServerQteChallengeSnapshot(
        match_id=session.match_id,
        sequence_list_address=0x800000,
        raw_sequence=("Up", "Down", "Left", "Right"),
        normalized_sequence=SEQUENCE,
        window=QteWindowSnapshot(6000, 3000, 3300, 2000, 3000, 3300, 5000),
    )


def bound(
    *,
    generation: int = 1,
    status: QteBindingStatus = QteBindingStatus.BOUND_CURRENT,
    value: CardUiQteSnapshot | None = None,
    session: CombatSessionKey = SESSION_A,
    actor: int = 1,
    skill_card_id: int = 7,
    turn: int = 33,
    reason: str = "current",
) -> BoundQteObservation:
    qte_value = value or qte()
    identity = None
    if status in {QteBindingStatus.BOUND_CURRENT, QteBindingStatus.COMPLETED_CURRENT}:
        identity = QteGenerationIdentity(
            session_key=session,
            local_actor_number=actor,
            skill_card_id=skill_card_id,
            turn_number=turn,
            card_ui_address=qte_value.address,
            server_sequence_list_address=0x800000,
            current_arrows_list_address=0x810000,
            current_arrow_seed=55,
            observer_generation=generation,
        )
    return BoundQteObservation(
        status=status,
        reason=reason,
        identity=identity,
        qte=qte_value,
        challenge=challenge(session=session),
        normalized_sequence=SEQUENCE if identity else (),
        predicted_timing_result=(
            "PERFECT!"
            if identity and qte_value.correct_count >= 7
            and qte_value.perfect_start_seconds
            <= qte_value.elapsed_seconds
            <= qte_value.perfect_end_seconds
            else "GOOD!"
            if identity and qte_value.correct_count >= 7
            else "BAD"
            if identity
            else None
        ),
    )


def observe(
    observer: QteObserver,
    observation: BoundQteObservation,
    *,
    cap: object | None = None,
    session: CombatSessionKey = SESSION_A,
    mana: int | None = 274,
    power: int | None = 215,
):
    return observer.observe(
        observed_at=100.0,
        session_key=session,
        observation=observation,
        capability=cap or capability(session=session),  # type: ignore[arg-type]
        player_mana=mana,
        player_power=power,
    )


class PetSkillCapabilityTests(unittest.TestCase):
    def test_no_pet_skill(self) -> None:
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(),
            candidates=(),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.NO_CAPABILITY)

    def test_valid_current_pet_skill(self) -> None:
        value = capability()
        self.assertEqual(value.status, PetSkillCapabilityStatus.CURRENT)
        self.assertTrue(value.live_card_present)
        self.assertTrue(value.ownership_current)

    def test_huyen_thoai_7_effective_costs(self) -> None:
        value = capability()
        self.assertEqual(value.effective_mana_cost, 200)
        self.assertEqual(value.effective_power_cost, 200)
        self.assertEqual(value.effective_mana_cost_source, PetSkillCostSource.CONDITION_USE)
        self.assertEqual(value.effective_power_cost_source, PetSkillCostSource.POWER)

    def test_huyen_thoai_2_effective_costs_from_second_live_shape(self) -> None:
        value = capability(
            value=card(
                card_id=2,
                name="Huyền Thoại 2",
                element_type="ATTACK_LEGEND",
                condition_use=200,
                power=150,
                value=5000,
                damage_multiplier=1.4,
            )
        )
        self.assertEqual(value.skill_family, PetSkillFamily.DOT_QTE_OTHER)
        self.assertEqual((value.effective_mana_cost, value.effective_power_cost), (200, 150))

    def test_raw_zero_costs_are_preserved(self) -> None:
        value = capability()
        self.assertEqual((value.raw_mana_cost, value.raw_power_cost), (0, 0))

    def test_cost_is_not_hardcoded_to_200(self) -> None:
        value = capability(value=card(condition_use=175, power=125, name="synthetic"))
        self.assertEqual((value.effective_mana_cost, value.effective_power_cost), (175, 125))

    def test_unknown_cost_source_for_unproven_family_shape(self) -> None:
        value = resolve_pet_skill_cost(card(element_type="OTHER"))
        self.assertEqual(value.effective_mana_cost_source, PetSkillCostSource.UNKNOWN)
        self.assertEqual(value.effective_power_cost_source, PetSkillCostSource.UNKNOWN)

    def test_metadata_without_live_card_ui(self) -> None:
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(with_card=True),
            candidates=(),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.METADATA_ONLY)
        self.assertFalse(value.live_card_present)

    def test_stale_card_ui_from_prior_match(self) -> None:
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_B,
            source_pet=source_pet(),
            candidates=(candidate(session=SESSION_A),),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.STALE)

    def test_multiple_live_cards_are_ambiguous(self) -> None:
        second = candidate(value=card(address=0x300100, card_id=8), card_ui_address=0x500100)
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(),
            candidates=(candidate(), second),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.AMBIGUOUS)

    def test_source_pet_card_mismatch_is_invalid(self) -> None:
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(skill_card_id=9),
            candidates=(candidate(),),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.INVALID)

    def test_unvalidated_button_is_metadata_only(self) -> None:
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(),
            candidates=(candidate(button_validated=False),),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.METADATA_ONLY)

    def test_same_card_metadata_and_live_wrapper_merge_to_live_capability(self) -> None:
        metadata = candidate(card_ui_address=None, button_validated=False)
        live = candidate()
        value = PetSkillCapabilityProvider().observe(
            observed_at=1.0,
            current_session=SESSION_A,
            source_pet=source_pet(),
            candidates=(metadata, live),
        )
        self.assertEqual(value.status, PetSkillCapabilityStatus.CURRENT)
        self.assertEqual(value.live_card_address, live.card_ui_address)

    def test_exact_family_and_target_mode(self) -> None:
        family, target = pet_skill_family("ATTACK_LEGEND_")
        self.assertEqual(family, PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION)
        self.assertEqual(target, PetSkillTargetMode.AUTOMATIC)


class QteShadowTests(unittest.TestCase):
    def test_no_qte_active(self) -> None:
        snap = observe(
            QteObserver(),
            bound(status=QteBindingStatus.INACTIVE, value=qte(active=False)),
        )
        self.assertEqual(snap.evidence_status, QteEvidenceStatus.INACTIVE)
        self.assertEqual(snap.sequence, ())

    def test_valid_current_qte(self) -> None:
        snap = observe(QteObserver(), bound())
        self.assertTrue(snap.observationally_current)

    def test_exact_sequence_extraction(self) -> None:
        snap = observe(QteObserver(), bound())
        self.assertEqual(snap.raw_sequence, ("Up", "Down", "Left", "Right"))

    def test_normalized_directions(self) -> None:
        snap = observe(QteObserver(), bound())
        self.assertEqual(
            snap.sequence,
            (QteDirection.UP, QteDirection.DOWN, QteDirection.LEFT, QteDirection.RIGHT),
        )

    def test_unknown_direction_is_not_silently_mapped(self) -> None:
        self.assertEqual(direction_from_runtime("diagonal"), QteDirection.UNKNOWN)

    def test_current_index_progression(self) -> None:
        observer = QteObserver()
        first = observe(observer, bound(value=qte(index=0)))
        second = observe(observer, bound(value=qte(index=2, correct=2)))
        self.assertEqual(first.expected_direction, QteDirection.UP)
        self.assertEqual(second.expected_direction, QteDirection.LEFT)

    def test_current_index_out_of_range_is_noncurrent(self) -> None:
        snap = observe(
            QteObserver(),
            bound(status=QteBindingStatus.INVALID_PROGRESS, value=qte(index=5)),
        )
        self.assertFalse(snap.observationally_current)
        self.assertEqual(snap.sequence, ())

    def test_new_generation_invalidates_previous_sequence_and_result(self) -> None:
        observer = QteObserver()
        old = observe(
            observer,
            bound(
                generation=1,
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1, displayed="PERFECT!"),
            ),
        )
        observer.note_inactive(SESSION_A)
        new = observe(observer, bound(generation=2, value=qte(index=0)))
        self.assertEqual(old.qte_generation, 1)
        self.assertEqual(new.qte_generation, 2)
        self.assertIsNone(new.runtime_display_result)
        self.assertIsNone(observer.pending_completed)

    def test_match_change_invalidates_qte(self) -> None:
        observer = QteObserver()
        observe(observer, bound())
        observer.invalidate("match_changed")
        self.assertIsNone(observer.current)
        self.assertIsNone(observer.pending_completed)

    def test_skill_card_id_mismatch(self) -> None:
        snap = observe(QteObserver(), bound(skill_card_id=8))
        self.assertEqual(snap.ownership_status, QteBindingStatus.WRONG_CARD)

    def test_local_actor_mismatch_is_stale(self) -> None:
        snap = observe(
            QteObserver(),
            bound(status=QteBindingStatus.WRONG_OWNER, actor=99),
        )
        self.assertEqual(snap.evidence_status, QteEvidenceStatus.STALE)

    def test_stale_object_rejected(self) -> None:
        snap = observe(
            QteObserver(),
            bound(status=QteBindingStatus.STALE_OR_CHANGED_QTE),
        )
        self.assertFalse(snap.observationally_current)

    def test_duplicate_old_result_rejected(self) -> None:
        observer = QteObserver()
        snap = observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1),
            ),
        )
        correlation = QteResponseCorrelation(True, "EXACT", "current")
        first = observer.correlate_server_response(
            generation=1,
            response_key="0x1",
            match_id="M_A",
            skill_card_id=7,
            correlation=correlation,
            server_timing_result="PERFECT!",
        )
        duplicate = observer.correlate_server_response(
            generation=1,
            response_key="0x1",
            match_id="M_A",
            skill_card_id=7,
            correlation=correlation,
            server_timing_result="PERFECT!",
        )
        self.assertIsNotNone(first)
        self.assertIsNone(duplicate)
        self.assertEqual(snap.qte_generation, 1)

    def test_current_server_result_correlated(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1),
            ),
        )
        updated = observer.correlate_server_response(
            generation=1,
            response_key="current",
            match_id="M_A",
            skill_card_id=7,
            correlation=QteResponseCorrelation(True, "EXACT", "current"),
            server_timing_result="PERFECT!",
        )
        self.assertEqual(updated.server_resolved_result, QteTimingResult.PERFECT)
        self.assertTrue(updated.server_response_correlated)

    def test_valid_perfect_interval(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(elapsed=3.1, correct=7)))
        self.assertEqual((snap.perfect_start, snap.perfect_end), (3.0, 3.3))
        self.assertAlmostEqual(snap.recommended_confirm_elapsed, 3.15)

    def test_invalid_inverted_interval(self) -> None:
        snap = observe(
            QteObserver(),
            bound(
                status=QteBindingStatus.INVALID_TIMING,
                value=qte(perfect_start=3.3, perfect_end=3.0),
            ),
        )
        self.assertEqual(snap.timing_region, QteTimingRegion.UNKNOWN)

    def test_inside_perfect_prediction(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(elapsed=3.1, correct=7)))
        self.assertEqual(snap.timing_region, QteTimingRegion.INSIDE_PERFECT)
        self.assertEqual(snap.predicted_timing_result, QteTimingResult.PERFECT)

    def test_before_perfect(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(elapsed=2.5, correct=7)))
        self.assertEqual(snap.timing_region, QteTimingRegion.BEFORE_PERFECT)

    def test_after_perfect(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(elapsed=4.0, correct=7)))
        self.assertEqual(snap.timing_region, QteTimingRegion.AFTER_PERFECT)

    def test_phase3a1_exact_fixture_predicts_perfect(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(elapsed=3.151977, correct=7)))
        self.assertEqual(snap.predicted_timing_result, QteTimingResult.PERFECT)
        self.assertEqual(snap.qte_elapsed_ms, 3152)

    def test_runtime_result_agreement(self) -> None:
        snap = observe(
            QteObserver(),
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(
                    index=4,
                    elapsed=3.1,
                    correct=7,
                    finished=True,
                    displayed="PERFECT!",
                ),
            ),
        )
        self.assertTrue(snap.prediction_runtime_consistent)

    def test_runtime_result_disagreement_remains_visible(self) -> None:
        snap = observe(
            QteObserver(),
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(
                    index=4,
                    elapsed=3.1,
                    correct=7,
                    finished=True,
                    displayed="BAD",
                ),
            ),
        )
        self.assertFalse(snap.prediction_runtime_consistent)
        self.assertEqual(snap.predicted_timing_result, QteTimingResult.PERFECT)
        self.assertEqual(snap.runtime_display_result, QteTimingResult.BAD)

    def test_active_generation_ignores_retained_prior_result_text(self) -> None:
        snap = observe(
            QteObserver(),
            bound(value=qte(elapsed=0.2, displayed="PERFECT!")),
        )
        self.assertIsNone(snap.runtime_result_text)
        self.assertIsNone(snap.runtime_display_result)
        self.assertIsNone(snap.prediction_runtime_consistent)

    def test_expected_direction_is_sequence_at_index(self) -> None:
        snap = observe(QteObserver(), bound(value=qte(index=3, correct=3)))
        self.assertEqual(snap.expected_direction, QteDirection.RIGHT)

    def test_completed_sequence_has_no_next_direction(self) -> None:
        snap = observe(
            QteObserver(),
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1),
            ),
        )
        self.assertIsNone(snap.expected_direction)

    def test_generic_server_envelope_does_not_fabricate_timing_result(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1),
            ),
        )
        updated = observer.correlate_server_response(
            generation=1,
            response_key="generic",
            match_id="M_A",
            skill_card_id=None,
            correlation=QteResponseCorrelation(True, "GENERIC", "current"),
            server_timing_result=None,
        )
        self.assertTrue(updated.server_response_correlated)
        self.assertIsNone(updated.server_resolved_result)

    def test_resource_delta_agrees_with_resolved_cost(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.1),
            ),
        )
        resource, _ = observer.observe_resolution(
            generation=1,
            mana_after=74,
            power_after=15,
            post_resolution_turn=33,
            post_resolution_local_actor=1,
        )
        self.assertEqual(resource.verification, DeltaVerification.AGREES)
        self.assertEqual((resource.observed_mana_delta, resource.observed_power_delta), (-200, -200))

    def test_phase3b1_late_automatic_effect_delta_is_ambiguous(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                turn=41,
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.008),
            ),
            mana=262,
            power=250,
        )
        resource, turn = observer.observe_resolution(
            generation=1,
            mana_after=62,
            power_after=250,
            post_resolution_turn=42,
            post_resolution_local_actor=99,
            concurrent_resource_change=True,
        )
        self.assertEqual(resource.verification, DeltaVerification.AMBIGUOUS)
        self.assertEqual(resource.observed_mana_delta, -200)
        self.assertEqual(resource.observed_power_delta, 0)
        self.assertTrue(turn.turn_consumed_observed)

    def test_huyen_thoai_2_live_cost_delta_agrees(self) -> None:
        observer = QteObserver()
        huyen_thoai_2 = card(
            card_id=2,
            name="Huyền Thoại 2",
            element_type="ATTACK_LEGEND",
            condition_use=200,
            power=150,
        )
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, elapsed=3.091),
                skill_card_id=2,
            ),
            cap=capability(value=huyen_thoai_2),
            mana=387,
            power=246,
        )
        resource, _ = observer.observe_resolution(
            generation=1,
            mana_after=187,
            power_after=96,
            post_resolution_turn=25,
            post_resolution_local_actor=1,
        )
        self.assertEqual(resource.verification, DeltaVerification.AGREES)
        self.assertEqual((resource.observed_mana_delta, resource.observed_power_delta), (-200, -150))

    def test_concurrent_resource_change_is_ambiguous(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True),
            ),
        )
        resource, turn = observer.observe_resolution(
            generation=1,
            mana_after=50,
            power_after=10,
            post_resolution_turn=34,
            post_resolution_local_actor=99,
            concurrent_resource_change=True,
        )
        self.assertEqual(resource.verification, DeltaVerification.AMBIGUOUS)
        self.assertTrue(turn.turn_consumed_observed)
        self.assertEqual(turn.evidence_status, QteEvidenceStatus.CURRENT)

    def test_non_turn_consuming_observation(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True),
            ),
        )
        _, turn = observer.observe_resolution(
            generation=1,
            mana_after=74,
            power_after=15,
            post_resolution_turn=33,
            post_resolution_local_actor=1,
        )
        self.assertFalse(turn.turn_consumed_observed)

    def test_turn_consuming_observation_is_not_globalized(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True),
            ),
        )
        _, turn = observer.observe_resolution(
            generation=1,
            mana_after=74,
            power_after=15,
            post_resolution_turn=34,
            post_resolution_local_actor=99,
        )
        self.assertTrue(turn.turn_consumed_observed)

    def test_observer_source_has_no_input_dependency(self) -> None:
        source = (SRC_ROOT / "pokiguard_v2" / "pet_skill_shadow.py").read_text("utf-8")
        self.assertNotIn("win32_input", source)
        self.assertNotIn("SendInput", source)

    def test_observer_source_has_no_process_write(self) -> None:
        source = (SRC_ROOT / "pokiguard_v2" / "pet_skill_shadow.py").read_text("utf-8")
        self.assertNotIn("WriteProcessMemory", source)


class QteSessionIsolationTests(unittest.TestCase):
    def test_match_b_cannot_inherit_match_a_fields(self) -> None:
        observer = QteObserver()
        a = observe(
            observer,
            bound(
                generation=1,
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True, displayed="PERFECT!"),
            ),
        )
        observer.invalidate("terminal")
        qte_b = replace(qte(), board_instance=SESSION_B.board_instance)
        b = observe(
            observer,
            bound(generation=2, session=SESSION_B, value=qte_b),
            session=SESSION_B,
        )
        self.assertEqual(a.match_id, "M_A")
        self.assertEqual(b.match_id, "M_B")
        self.assertIsNone(b.runtime_display_result)
        self.assertIsNone(b.resource_delta)
        self.assertIsNone(b.server_resolved_result)

    def test_same_match_generation_n_plus_one_has_independent_window(self) -> None:
        observer = QteObserver()
        first = observe(observer, bound(generation=1, value=qte(perfect_start=3.0, perfect_end=3.3)))
        observer.note_inactive(SESSION_A)
        second = observe(observer, bound(generation=2, value=qte(perfect_start=2.2, perfect_end=2.6)))
        self.assertEqual((first.perfect_start, first.perfect_end), (3.0, 3.3))
        self.assertEqual((second.perfect_start, second.perfect_end), (2.2, 2.6))

    def test_old_generation_result_cannot_finalize_new_generation(self) -> None:
        observer = QteObserver()
        observe(
            observer,
            bound(
                generation=1,
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True),
            ),
        )
        observer.note_inactive(SESSION_A)
        observe(
            observer,
            bound(
                generation=2,
                status=QteBindingStatus.COMPLETED_CURRENT,
                value=qte(index=4, correct=7, finished=True),
            ),
        )
        stale = observer.correlate_server_response(
            generation=1,
            response_key="old",
            match_id="M_A",
            skill_card_id=7,
            correlation=QteResponseCorrelation(True, "EXACT", "old"),
            server_timing_result="PERFECT!",
        )
        self.assertIsNone(stale)


if __name__ == "__main__":
    unittest.main()
