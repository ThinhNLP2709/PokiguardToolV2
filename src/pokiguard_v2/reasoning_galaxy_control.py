"""U4c: one frozen BASIC Galaxy/G4 swap-timing control, like the Mega control. No input or decisions."""
from .basic_policy import Intelligence, PlayStyle
from .gameplay_profile import G4_PET_ROUTES, AuditionMode, GameMode
from .reasoning_snapshot import require

GALAXY_CONTROL_STYLES = (PlayStyle.GALAXY, PlayStyle.GALAXY_SHADOW_SWORD)


def check_galaxy_control(config, cap):
    require(config.intelligence is Intelligence.BASIC
        and not config.ai.reasoning_enabled and not config.ai.shadow_enabled
        and config.play_style in GALAXY_CONTROL_STYLES
        and (config.play_style is not PlayStyle.GALAXY_SHADOW_SWORD or (config.main_pet, config.evolution) in G4_PET_ROUTES)
        and config.game_mode is GameMode.SOLO and config.audition_mode is AuditionMode.NO_ACTION
        and config.input_delivery_mode.value == 'foreground'
        and config.board_input_mode.value == 'two_click'
        and config.game_window_size_profile.value == 'original_1280x640'
        and type(cap) is int and cap == config.max_match_attempts == config.target_completed_matches == 1
        and bool(config.normalized_boss_id), 'Galaxy swap control requires one frozen SOLO BASIC Galaxy/G4 attempt')
    random = config.input_randomization
    require(random.reaction_max_seconds <= 1 and random.inter_click_max_seconds <= 1.5
        and random.coordinate_max_percent <= 10, 'Galaxy swap control input randomization exceeds measured envelope')
