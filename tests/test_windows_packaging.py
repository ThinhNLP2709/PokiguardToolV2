from __future__ import annotations

import json
from pathlib import Path
import sys
import tempfile
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[1]
SRC = ROOT / "src"
for import_path in (str(ROOT), str(SRC)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import resolve_app_paths  # noqa: E402
from pokiguard_v2.controller_lease import (  # noqa: E402
    AutomationControllerLease,
    ControllerLeaseError,
)
from pokiguard_v2.runtime_calibration import production_input_calibration  # noqa: E402
from pokiguard_v2.version import APP_BUILD, APP_TITLE, APP_VERSION  # noqa: E402
from pokiguard_v2.windows_entry import (  # noqa: E402
    PACKAGING_SELF_CHECK_ARG,
    run_packaged,
)


class WindowsPackagingTests(unittest.TestCase):
    def _paths(self, root: Path):
        module = root / "bundle" / "pokiguard_v2" / "app_paths.py"
        module.parent.mkdir(parents=True)
        module.touch()
        return resolve_app_paths(
            frozen=True,
            module_file=module,
            executable=root / "portable" / "PokiguardToolV2.exe",
            environ={"POKIGUARD_V2_DATA_ROOT": str(root / "app-data")},
        )

    def test_packaged_entry_does_not_auto_start_or_resume(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            paths = self._paths(Path(temporary).resolve())
            with patch("tools.desktop_ui.main", return_value=0) as desktop_main:
                self.assertEqual(run_packaged([], paths=paths), 0)
            desktop_main.assert_called_once_with([])
            events = [
                json.loads(line)
                for line in paths.startup_log.read_text(encoding="utf-8").splitlines()
            ]
            started = next(value for value in events if value["event"] == "packaged_app_started")
            self.assertFalse(started["automaticStart"])
            self.assertFalse(started["automaticResume"])
            self.assertEqual(Path(started["dataRoot"]), paths.data_root)

    def test_packaged_entry_rejects_a_second_ui_owner(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            paths = self._paths(Path(temporary).resolve())
            paths.ensure_writable_directories()
            with AutomationControllerLease(paths.desktop_lock):
                with self.assertRaises(ControllerLeaseError):
                    run_packaged([], paths=paths)

    def test_self_check_imports_production_graph_without_process_or_input(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            paths = self._paths(root)
            source_resources = ROOT / "src" / "pokiguard_v2" / "resources"
            paths.reset_evidence.parent.mkdir(parents=True, exist_ok=True)
            paths.reset_evidence.write_bytes(
                (source_resources / "reset_capabilities.json").read_bytes()
            )
            paths.reference_root.mkdir(parents=True, exist_ok=True)
            for name in (
                "exit_ui_live_calibration.json",
                "exit_ui_live_calibration_1280x710.json",
            ):
                (paths.reference_root / name).write_bytes(
                    (ROOT / "reference" / name).read_bytes()
                )
            self.assertEqual(run_packaged([PACKAGING_SELF_CHECK_ARG], paths=paths), 0)
            records = [
                json.loads(line)
                for line in paths.startup_log.read_text(encoding="utf-8").splitlines()
            ]
            evidence = next(
                value for value in records if value["event"] == "packaged_self_check_passed"
            )
            self.assertFalse(evidence["processAttachment"])
            self.assertFalse(evidence["windowsInput"])
            self.assertEqual(evidence["productionResetCapabilities"], 1)

    def test_production_calibration_is_internal_and_matches_accepted_values(self) -> None:
        values = production_input_calibration()
        self.assertEqual(values["click_delay_seconds"], 0.25)
        self.assertEqual(values["board_first_center_x"], 0.357)
        self.assertEqual(values["board_first_center_y"], 0.146)
        self.assertEqual(values["board_step_x"], 0.0410)
        self.assertEqual(values["board_step_y"], 0.0725)
        source = (ROOT / "tools" / "basic_auto_bot.py").read_text(encoding="utf-8")
        self.assertNotIn("V1SolverAdapter(args.v1_root)", source)

    def test_spec_bundles_only_required_runtime_evidence(self) -> None:
        spec = (ROOT / "packaging" / "PokiguardToolV2.spec").read_text(
            encoding="utf-8"
        )
        self.assertIn("reset_capabilities.json", spec)
        self.assertIn("exit_ui_live_calibration.json", spec)
        self.assertIn("console=False", spec)
        for forbidden in ("reverse", "cpp2il", "Pokiguard.exe", "GameAssembly.dll"):
            self.assertNotIn(forbidden, spec)

    def test_build_script_reads_canonical_version(self) -> None:
        script = (ROOT / "scripts" / "build_windows.ps1").read_text(encoding="utf-8")
        self.assertIn("from pokiguard_v2.version import APP_VERSION", script)
        self.assertNotIn(f"APP_BUILD = {APP_BUILD}", script)
        self.assertEqual(APP_VERSION, "v1.0.0+15")
        self.assertEqual(APP_TITLE, "Pokiguard Tool V2 - v1.0.0+15")


if __name__ == "__main__":
    unittest.main()
