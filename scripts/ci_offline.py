"""Portable focused gates; historical/live acceptance is deliberately separate."""
from pathlib import Path
import sys
import unittest
ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
MODULES = (
    'test_tool_updater', 'test_compatibility_migration', 'test_il2cpp_external',
    'test_native_card_ui', 'test_game_location', 'test_desktop_runtime', 'test_farm_checkpoint',
    'test_app_paths', 'test_windows_packaging', 'test_pinned_board_input', 'test_basic_policy',
    'test_reasoning_drain_resources', 'test_reasoning_post_action_resources',
    'test_reasoning_ui_status', 'test_reasoning_common_native',
    'test_reasoning_common_selection', 'test_reasoning_strategy_intent',
    'test_reasoning_health_branch_log', 'test_damage_uncertainty',
    'test_reasoning_demon_health_prefix', 'test_reasoning_refill_sword',
    'test_galaxy_shadow_sword', 'test_galaxy_shadow_sword_ui',
    'test_boss_threat',
    'test_active_skill_inventory', 'test_active_skill_evidence', 'test_skill_evidence_isolation',
    'test_icarus_core_evidence',
    'test_trex_core_evidence',
    'test_galaxy_core_evidence', 'test_reasoning_u1_bench',
    'test_galaxy', 'test_galaxy_glank', 'test_galaxy_pet_reasoning', 'test_galaxy_skill_phase',
    'test_mega_swap_control', 'test_reasoning_calibration_compat_projection',
)
if __name__ == '__main__':
    result = unittest.TextTestRunner(verbosity=2).run(unittest.defaultTestLoader.loadTestsFromNames(
        ['tests.' + name for name in MODULES]))
    raise SystemExit(not result.wasSuccessful())
