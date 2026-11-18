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
)
if __name__ == '__main__':
    result = unittest.TextTestRunner(verbosity=2).run(unittest.defaultTestLoader.loadTestsFromNames(
        ['tests.' + name for name in MODULES]))
    raise SystemExit(not result.wasSuccessful())
