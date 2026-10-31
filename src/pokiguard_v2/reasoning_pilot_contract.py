"""Frozen, explicit pilot authority. No process, game reader, input or file IO."""
from __future__ import annotations

from dataclasses import dataclass
import hashlib
import math

from .board_diagnostics import jsonable
from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require

PILOT_CONTEXT = "BOUNDED_R1_SWAP_PILOT"
FAKE_PILOT_CONTEXT = "OFFLINE_PILOT_NATIVE_FAKES"


def runtime_witness(state, config):
    """Structural/operator binding, NOT independent pet/effect identity proof."""
    require(state.player is not None and state.player.is_local is True
            and bool(state.battle.local_username), "local ownership missing")
    bosses = [p for p in state.opponents if p.is_boss is True]
    require(len(bosses) == 1, "solo boss witness missing")
    boss = bosses[0]
    require(all(getattr(boss, k) is not None for k in
                ("max_hp", "max_mana", "max_power", "attack")), "boss scope incomplete")
    return FrozenJSON.of(dict(
        account_username_sha256=hashlib.sha256(state.battle.local_username.casefold().encode()).hexdigest(),
        boss=[boss.actor_number, boss.max_hp, boss.max_mana, boss.max_power, boss.attack],
        loadout=dict(config=[config.main_pet.value, config.evolution.value, config.damage_card.value],
            cards=[[c.data_id, c.card_id, c.element_type, c.mana_cost, c.power_cost,
                    c.cooldown_turns] for c in state.cards],
            fusion=None if state.fusion is None else
                [state.fusion.selected_user_pet_id, state.fusion.selected_pet_id])))


@dataclass(frozen=True)
class PilotAuthority:
    """External calibration provenance is required; fake evidence stays fake.

    Source/build/model/config/cohort are frozen before a run. Constructing this
    record alone never enables UI or input. Real creation also needs a matching
    independently supplied build hash, and native-fake records require PID0.
    """
    profile: str
    policy_json: str
    scope: FrozenJSON
    witness: FrozenJSON
    model: FrozenJSON
    game_build_sha256: str
    timer_source: str
    reserve_ms: float
    uncertainty_ms: float
    return_margin_ms: float
    max_read_span_ms: float
    calibration_origin: str
    calibration_sha256: str
    calibration_samples: int
    input_p99_ms: float
    input_mode: str = "foreground"
    board_mode: str = "two_click"
    budget_ms: int = 4000

    def __post_init__(self):
        config = FrozenJSON(self.policy_json).plain()
        require(self.profile in ("simple", "careful") and config["play_style"] == self.profile
                and config["intelligence"] == "basic", "scoped BASIC incumbent required")
        require([config[k] for k in ("main_pet", "evolution", "damage_card")]
                == ["normal", "normal", "default_attack"], "unsupported pilot loadout")
        require(type(self.scope) is FrozenJSON and set(self.scope.plain()) ==
                {"account_binding", "boss", "loadout"} and all(type(v) is str and
                v.strip().upper() not in ("", "UNKNOWN", "NOT_PUBLISHED")
                for v in self.scope.plain().values()), "explicit operator cohort required")
        require(type(self.witness) is FrozenJSON and set(self.witness.plain()) ==
                {"account_username_sha256", "boss", "loadout"}, "runtime witness required")
        for value in (self.game_build_sha256, self.calibration_sha256):
            require(type(value) is str and len(value) == 64 and
                    all(c in "0123456789abcdef" for c in value), "evidence SHA256 required")
        require(self.calibration_origin in ("OFFLINE_NATIVE_FAKES", "NATIVE_INPUT_CALIBRATED")
                and type(self.calibration_samples) is int and self.calibration_samples >= 1,
                "explicit calibration origin/sample count required")
        require((self.input_mode, self.board_mode) == ("foreground", "two_click"),
                "uncalibrated transport")
        require(type(self.budget_ms) is int and 50 <= self.budget_ms <= 6000,
                "bounded immutable processing budget required")
        for value in (self.reserve_ms, self.uncertainty_ms, self.return_margin_ms,
                      self.max_read_span_ms, self.input_p99_ms):
            require(type(value) in (int, float) and math.isfinite(value) and value > 0,
                    "finite positive timing evidence required")
        require(self.reserve_ms >= max(1000, config["minimum_turn_time_seconds"] * 1000,
                                      self.input_p99_ms + 250)
                and self.uncertainty_ms >= 150 and self.return_margin_ms >= 100,
                "reserve cannot weaken accepted floor or measured tail")
        require(self.timer_source == ("OFFLINE_VALID" if self.calibration_origin ==
                "OFFLINE_NATIVE_FAKES" else "MatchService.server_tick"), "unmapped timer source")
        require(type(self.model) is FrozenJSON, "immutable model required")
        require(self.model.plain().get("version") == "5b2.scoped_inputs.v1", "model version mismatch")
        if self.calibration_origin == "NATIVE_INPUT_CALIBRATED":
            # No numerical effects/costs/conversions are validated by this step.
            require(set(self.model.plain()) == {"version"}, "unsupported production effect model")

    @property
    def context(self):
        return FAKE_PILOT_CONTEXT if self.calibration_origin == "OFFLINE_NATIVE_FAKES" else PILOT_CONTEXT

    @property
    def identity(self):
        return digest(jsonable(self))

    def matches(self, state, config):
        return (canonical_json(jsonable(config)) == self.policy_json
                and runtime_witness(state, config) == self.witness
                and state.battle.turn_timer_source == self.timer_source)
