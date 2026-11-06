"""Explicit user-declared effects, separate from native timing/input authority."""
from .gameplay_profile import DamageCardMode
from .reasoning_snapshot import FrozenJSON,require

DEMON_GEOMETRY='USER_DECLARED_PERPENDICULAR'
DEMON_TARGETS=('shield','health','mana','drain','rage')
DEMON_DECLARATION=FrozenJSON.of(dict(
    id='user.demon_all_targets_perpendicular.20261101.v1',
    origin='USER_DECLARATION',support='USER_CALIBRATED',
    answer='Cùng cơ chế quét, chỉ đổi viên kích hoạt',
    scope='DEMON_FARM_CONFIGURED_PASSIVE_TARGET',targets=list(DEMON_TARGETS),
    horizontal_match='CLEAR_MATCHED_COLUMNS',vertical_match='CLEAR_MATCHED_ROWS',
    confirms=['ACTIVATION_GEM','FIRST_WAVE_GEOMETRY'],
    does_not_confirm=['SERVER_DAMAGE','SAME_BURST_RESOURCE_DAMAGE_ORDER',
        'REFILL','PASSIVE_CASCADE_ORDER','LIVE_INPUT_TIMING']))
AUTO_GEOMETRY=object()
AUTO_DISCOUNT=object()
RESOURCE_DECLARATION=FrozenJSON.of(dict(
    id='user.resources.20rage_30mana.v1',origin='USER_DECLARATION',
    mana_per_effective_gem=30,rage_per_effective_gem=20,
    scope='ALL_STYLES_STRUCTURAL_RESOURCE_PROGRESS_NOT_DAMAGE'))
DEMON_RAGE_REFERENCE=FrozenJSON.of(dict(
    id='user.demon_rage_reference.v1',origin='USER_DECLARATION',
    rage_threshold=100,maximum_sword_discount=1,minimum_physical_swords=2,
    same_burst='KNOWN_RAGE_IN_PASSIVE_SWEEP',
    scope='NOMINAL_SETTING_REFERENCE_NOT_KILL_CERTIFICATE',
    server_damage_order_verified=False))


def demon_strategy(config,geometry,conversion,discount=AUTO_DISCOUNT):
    """Declared advisory goals; never infer equipped pet or grant an action."""
    enabled=(geometry==DEMON_GEOMETRY and config.main_pet.value=='normal'
        and config.evolution.value=='none')
    rates=dict(mana=30,rage=20) if conversion is None else conversion
    require(type(rates) is dict and set(rates)<=set(('mana','rage')),'resource rates required')
    import math
    require(all(type(v) in (int,float) and math.isfinite(v) and v>=0 for v in rates.values()),
        'finite nonnegative resource rates required')
    nominal=(1 if enabled else None) if discount is AUTO_DISCOUNT else discount
    require(nominal is None or type(nominal) is int and 0<=nominal<=1,'bounded nominal discount required')
    return dict(rates),nominal,dict(
        resources=RESOURCE_DECLARATION.plain() if conversion is None else None,
        rage_reference=DEMON_RAGE_REFERENCE.plain() if enabled and nominal==1 else None,
        automatic_kill_claim=False)


def demon_effect(config,requested=AUTO_GEOMETRY):
    """Resolve the declared effect for the actual configuration, not a pet guess.

    A caller can explicitly disable the model after a build/observation mismatch.
    Choosing a target does not certify that the in-game pet matches that target.
    """
    active=(config.play_style.value=='demon_aegis_farm'
        and config.damage_card is DamageCardMode.PET_PASSIVE)
    target=config.demon_target_gem.value
    require(requested is AUTO_GEOMETRY or requested in (None,DEMON_GEOMETRY),'unsupported Demon geometry')
    enabled=active and target in DEMON_TARGETS and requested is not None
    evidence=dict(status='USER_DECLARED_EFFECT' if enabled else 'NOT_APPLIED',
        configured_target=target,configuration_is_capability_declaration=True,
        actual_pet_target_verification='NOT_DERIVED_FROM_SETTING',
        declaration=DEMON_DECLARATION.plain() if enabled else None,
        reason=('MATCHED_DEMON_PASSIVE_CONFIGURATION' if enabled else
            'EXPLICIT_MODEL_DISABLED' if requested is None else 'CONFIGURATION_NOT_DEMON_PASSIVE'))
    return (DEMON_GEOMETRY if enabled else None),evidence
