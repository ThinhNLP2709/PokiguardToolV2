from __future__ import annotations

import json
import os
from pathlib import Path
import sys
import tempfile
import time
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[1]
SRC = ROOT / "src"
for import_path in (str(ROOT), str(SRC)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import (  # noqa: E402
    AppPathError,
    create_unique_directory,
    resolve_app_paths,
)
from pokiguard_v2.desktop_control_plane import DesktopConfig  # noqa: E402
from pokiguard_v2.desktop_control_plane import (  # noqa: E402
    LatestCheckpointSummaryProvider,
)
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore  # noqa: E402
from pokiguard_v2.farm_checkpoint import (  # noqa: E402
    CHECKPOINT_SCHEMA,
    CheckpointPayload,
    validate_for_resume,
    write_checkpoint,
)
from pokiguard_v2.farm_run import FarmRunArtifactWriter  # noqa: E402
from pokiguard_v2.reset_evidence_store import load_reset_capabilities  # noqa: E402


class AppPathTests(unittest.TestCase):
    def _module_file(self, root: Path) -> Path:
        path = root / "src" / "pokiguard_v2" / "app_paths.py"
        path.parent.mkdir(parents=True)
        path.touch()
        return path

    def test_source_mode_preserves_checkout_data_root_without_cwd(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            module = self._module_file(root)
            unrelated = root / "unrelated"
            unrelated.mkdir()
            with patch.object(Path, "cwd", return_value=unrelated):
                paths = resolve_app_paths(
                    frozen=False,
                    module_file=module,
                    executable=root / "python.exe",
                    environ={},
                )
            self.assertEqual(paths.source_root, root)
            self.assertEqual(paths.data_root, root)
            self.assertEqual(
                paths.preferences_file,
                root / "logs" / "desktop_ui" / "operator_preferences.json",
            )

    def test_frozen_mode_uses_local_app_data_not_install_or_cwd(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            local = root / "local"
            install = root / "portable"
            bundle = install / "_internal"
            package = bundle / "pokiguard_v2"
            package.mkdir(parents=True)
            paths = resolve_app_paths(
                frozen=True,
                module_file=package / "app_paths.py",
                executable=install / "PokiguardToolV2.exe",
                bundle_root=bundle,
                environ={"LOCALAPPDATA": str(local)},
            )
            self.assertEqual(paths.install_root, install)
            self.assertEqual(paths.data_root, local / "PokiguardToolV2")
            self.assertEqual(
                paths.preferences_file,
                local
                / "PokiguardToolV2"
                / "preferences"
                / "operator_preferences.json",
            )
            self.assertTrue(paths.reset_evidence.is_relative_to(package))
            self.assertTrue(paths.reference_root.is_relative_to(package))
            self.assertFalse(paths.logs_root.is_relative_to(install))

    def test_frozen_mode_fails_closed_without_local_app_data(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            with self.assertRaises(AppPathError):
                resolve_app_paths(
                    frozen=True,
                    module_file=self._module_file(root),
                    executable=root / "app" / "PokiguardToolV2.exe",
                    environ={},
                )

    def test_explicit_data_root_must_be_absolute(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            with self.assertRaises(AppPathError):
                resolve_app_paths(
                    frozen=False,
                    module_file=self._module_file(root),
                    environ={"POKIGUARD_V2_DATA_ROOT": "relative-data"},
                )

    def test_packaged_writes_stay_under_fresh_data_root(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            data = root / "fresh-data"
            paths = resolve_app_paths(
                frozen=True,
                module_file=self._module_file(root),
                executable=root / "portable" / "PokiguardToolV2.exe",
                environ={
                    "LOCALAPPDATA": str(root / "ignored-local"),
                    "POKIGUARD_V2_DATA_ROOT": str(data),
                },
            )
            paths.ensure_writable_directories()
            store = DesktopPreferenceStore(paths.preferences_file)
            store.save(DesktopConfig())
            writer = FarmRunArtifactWriter.create(paths.farm_runs, "path-test-run")
            writer.event("path_test")
            for expected in (
                paths.preferences_file,
                paths.farm_runs / "path-test-run" / "events.jsonl",
            ):
                self.assertTrue(expected.is_file())
                self.assertTrue(expected.resolve().is_relative_to(data))
            self.assertFalse((root / "portable" / "logs").exists())

    def test_packaged_checkpoint_is_discovered_and_canonically_validated(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary).resolve()
            data = root / "fresh-data"
            paths = resolve_app_paths(
                frozen=True,
                module_file=self._module_file(root),
                executable=root / "portable" / "PokiguardToolV2.exe",
                environ={"POKIGUARD_V2_DATA_ROOT": str(data)},
            )
            now = time.time()
            checkpoint = paths.farm_runs / "packaged-resume" / "checkpoint.json"
            payload = CheckpointPayload(
                schema_version=CHECKPOINT_SCHEMA,
                farm_run_id="packaged-resume",
                continuation_of=None,
                checkpoint_seq=1,
                created_at=now,
                updated_at=now,
                target_boss_id="boss-73",
                target_boss_name="Starburst",
                configured_limits={
                    "target_completed_matches": 3,
                    "max_technical_recoveries": 1,
                    "max_match_attempts": 5,
                },
                run_started_at=now,
                match_attempts=1,
                completed_matches=1,
                wins=1,
                losses=0,
                unknown_results=0,
                technical_aborts=0,
                technical_recoveries=0,
                technical_exits=0,
                last_completed_match_id="match-1",
                seen_match_ids=("match-1",),
                action_aggregates={
                    "swap_sent": 1,
                    "swap_acknowledged": 1,
                    "swap_rejected": 0,
                    "swap_aborted_state_changed": 0,
                    "cast_sent": 0,
                    "cast_accepted": 0,
                    "cast_rejected": 0,
                    "evolve_attempts": 0,
                    "evolve_success": 0,
                    "evolve_failed": 0,
                },
                pass_totals=0,
                consistency_aggregates={
                    "consistent": 1,
                    "memory_incomplete": 0,
                    "conflicts": 0,
                    "strong_terminal_results": 1,
                },
                last_safe_lifecycle="BOSS_LOBBY",
                stop_request_state="STOPPED_AT_LOBBY",
                stop_reason="STOPPED_GRACEFULLY",
                finalized_status="STOPPED_GRACEFULLY",
            )
            write_checkpoint(checkpoint, payload)

            summary = LatestCheckpointSummaryProvider(paths.farm_runs).read_latest()
            decision = validate_for_resume(
                payload,
                target_boss_id="boss-73",
                target_boss_name="Starburst",
                target_completed_matches=3,
                max_technical_recoveries=1,
                max_match_attempts=5,
            )

            self.assertTrue(summary.available)
            self.assertEqual(Path(summary.path or ""), checkpoint.resolve())
            self.assertTrue(checkpoint.resolve().is_relative_to(data))
            self.assertTrue(decision.allowed)
            self.assertEqual(decision.remaining_completed, 2)

    def test_unique_artifact_directory_handles_same_second(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            parent = Path(temporary).resolve()
            first = create_unique_directory(parent, "20260829_010203")
            second = create_unique_directory(parent, "20260829_010203")
            self.assertEqual(first.name, "20260829_010203")
            self.assertEqual(second.name, "20260829_010203_001")

    def test_bundled_reset_capability_is_production_ready(self) -> None:
        resource = (
            Path(__file__).resolve().parents[1]
            / "src"
            / "pokiguard_v2"
            / "resources"
            / "reset_capabilities.json"
        )
        values = load_reset_capabilities(resource)
        self.assertEqual(len(values), 1)
        self.assertTrue(values[0].production_ready)
        payload = json.loads(resource.read_text(encoding="utf-8"))
        self.assertNotIn("D:\\PokiguardToolV2", payload["sourceLog"])


if __name__ == "__main__":
    unittest.main()
