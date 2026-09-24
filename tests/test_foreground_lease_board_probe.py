from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from tools.foreground_lease_board_probe import (  # noqa: E402
    _validate_args,
    build_parser,
)


class ForegroundLeaseBoardProbeArgumentTests(unittest.TestCase):
    def test_explicit_prearm_is_required(self) -> None:
        args = build_parser().parse_args([])

        with self.assertRaises(ValueError):
            _validate_args(args)

    def test_documented_b3_defaults_are_valid(self) -> None:
        args = build_parser().parse_args(["--prearmed"])

        _validate_args(args)

        self.assertEqual(args.minimum_action_time, 7)
        self.assertEqual(args.focus_settle, 0.40)
        self.assertEqual(args.post_action_settle, 0.20)
        self.assertEqual(args.required_idle, 0.25)
        self.assertEqual(args.idle_timeout, 0.75)


if __name__ == "__main__":
    unittest.main()
