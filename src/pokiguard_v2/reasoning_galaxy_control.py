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


def galaxy_swap_witness_key(witness, config):
    """Like the Mega swap witness, but a Galaxy pet without fusion reports fusion as [0, 0]."""
    from .reasoning_snapshot import canonical_json
    require(type(witness) is dict and set(witness) == {'account_username_sha256', 'boss', 'loadout'},
        'Galaxy swap witness missing')
    account, boss, loadout = witness['account_username_sha256'], witness['boss'], witness['loadout']
    fusion = loadout.get('fusion') if type(loadout) is dict else None
    require(type(account) is str and len(account) == 64 and all(c in '0123456789abcdef' for c in account)
        and type(boss) is list and len(boss) == 5 and all(type(n) is int and n >= 0 for n in boss)
        and type(loadout) is dict and set(loadout) == {'config', 'cards', 'fusion'}
        and loadout['config'] == [config.main_pet.value, config.evolution.value, config.damage_card.value]
        and type(loadout['cards']) is list and all(type(c) is list and len(c) == 6 for c in loadout['cards'])
        and (fusion is None or type(fusion) is list and len(fusion) == 2
             and all(n is None or type(n) is int and n >= 0 for n in fusion)), 'Galaxy swap witness identity invalid')
    return canonical_json(dict(account_username_sha256=account, boss=boss, loadout=dict(config=loadout['config'])))
