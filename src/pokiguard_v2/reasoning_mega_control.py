"""Setup-only Mega BASIC swap-timing cohort. No game read or input authority."""
from .basic_policy import Intelligence, PlayStyle
from .gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode, GameMode, AuditionMode
from .reasoning_snapshot import require
from .reasoning_snapshot import canonical_json


def check_mega_control(config, cap):
    require(config.intelligence is Intelligence.BASIC
        and not config.ai.reasoning_enabled and not config.ai.shadow_enabled
        and config.play_style is PlayStyle.MEGA_ICARUS_SPAM_SKILL
        and config.game_mode is GameMode.SOLO and config.main_pet is MainPetType.NORMAL
        and config.evolution is EvolutionTarget.MEGA and config.damage_card is DamageCardMode.PET_SKILL
        and config.audition_mode is AuditionMode.NO_ACTION
        and config.input_delivery_mode.value == 'foreground'
        and config.board_input_mode.value == 'two_click'
        and config.game_window_size_profile.value == 'original_1280x640'
        and type(cap) is int and cap == config.max_match_attempts == config.target_completed_matches == 1
        and bool(config.normalized_boss_id), 'Mega swap control requires one frozen SOLO BASIC normal-to-Mega attempt')
    random = config.input_randomization
    require(random.reaction_max_seconds <= 1 and random.inter_click_max_seconds <= 1.5
        and random.coordinate_max_percent <= 10, 'Mega swap control input randomization exceeds measured envelope')


def mega_swap_witness_key(witness, config):
    """Card/fusion presentation may change; keep account/boss/config identity.

    The full witness remains in every raw sample. This projection is solely for
    swap transport; it never makes a skill, evolution or resource model eligible.
    """
    require(type(witness) is dict and set(witness)=={'account_username_sha256','boss','loadout'},'Mega swap witness missing')
    account=witness['account_username_sha256'];boss=witness['boss'];loadout=witness['loadout']
    require(type(account) is str and len(account)==64 and all(c in '0123456789abcdef' for c in account)
        and type(boss) is list and len(boss)==5 and all(type(n) is int and n>=0 for n in boss)
        and type(loadout) is dict and set(loadout)=={'config','cards','fusion'}
        and loadout['config']==[config.main_pet.value,config.evolution.value,config.damage_card.value]
        and type(loadout['cards']) is list and all(type(c) is list and len(c)==6 for c in loadout['cards'])
        and (loadout['fusion'] is None or type(loadout['fusion']) is list and len(loadout['fusion'])==2
             and all(n is None or type(n) is int and n>0 for n in loadout['fusion'])), 'Mega swap witness identity invalid')
    return canonical_json(dict(account_username_sha256=account,boss=boss,
        loadout=dict(config=loadout['config'])))
