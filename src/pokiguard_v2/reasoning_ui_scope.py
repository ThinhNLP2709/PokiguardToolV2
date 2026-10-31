"""Cheap UI-intent scope checks. No worker, filesystem, game read or input."""


def ui_reasoning_scope_reason(config, *, require_target=False):
    """Unsupported AI intent never makes an otherwise valid BASIC farm invalid."""
    required = dict(play_style='demon_aegis_farm', game_mode='solo', main_pet='normal',
        evolution='none', damage_card='pet_passive', demon_target_gem='shield',
        pet_skill_fire_condition='sword_count', input_delivery_mode='foreground',
        board_input_mode='two_click', game_window_size_profile='original_1280x640')
    for name, value in required.items():
        if getattr(getattr(config, name, None), 'value', None) != value:
            return 'UI_REASONING_CONFIG_UNSUPPORTED'
    if config.pet_skill_fire_value != 4:
        return 'UI_REASONING_CALIBRATED_THRESHOLD_REQUIRED'
    if config.ai.shadow_enabled:
        return 'UI_REASONING_SHADOW_CONFLICT'
    random = config.input_randomization
    if (random.reaction_max_seconds > 1 or random.inter_click_max_seconds > 1.5
            or random.coordinate_max_percent > 10):
        return 'UI_REASONING_TIMING_CONFIG_UNSUPPORTED'
    if require_target and config.normalized_boss_id != '1436':
        return 'UI_REASONING_TARGET_UNSUPPORTED'
    return None
