from __future__ import annotations

from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.farm_run_storage import (
    FarmRunStorageUsage,
    clear_farm_runs,
    format_byte_size,
    scan_farm_runs,
)


class FarmRunStorageTests(unittest.TestCase):
    def test_scan_counts_nested_files_and_formats_total_size(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            root = Path(directory) / "farm_runs"
            nested = root / "run-1" / "evidence"
            nested.mkdir(parents=True)
            (root / "index.json").write_bytes(b"1234")
            (nested / "events.jsonl").write_bytes(b"x" * 2048)

            usage = scan_farm_runs(root)

            self.assertEqual(FarmRunStorageUsage(2052, 2, 2), usage)
            self.assertEqual("2 KB", format_byte_size(usage.total_bytes))

    def test_missing_farm_runs_directory_has_zero_usage(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            usage = scan_farm_runs(Path(directory) / "farm_runs")
            self.assertEqual(FarmRunStorageUsage(), usage)

    def test_clear_removes_all_children_but_preserves_farm_runs_root(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            root = Path(directory) / "farm_runs"
            nested = root / "run-2" / "nested"
            nested.mkdir(parents=True)
            (nested / "summary.json").write_bytes(b"summary")
            (root / "latest.json").write_bytes(b"latest")

            deleted = clear_farm_runs(root)

            self.assertEqual(2, deleted.file_count)
            self.assertTrue(root.is_dir())
            self.assertEqual([], list(root.iterdir()))
            self.assertEqual(FarmRunStorageUsage(), scan_farm_runs(root))

    def test_rejects_any_directory_not_named_farm_runs(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            unsafe = Path(directory) / "logs"
            unsafe.mkdir()
            (unsafe / "keep.txt").write_text("keep", encoding="utf-8")

            with self.assertRaisesRegex(ValueError, "farm_runs"):
                clear_farm_runs(unsafe)

            self.assertTrue((unsafe / "keep.txt").is_file())

    def test_format_byte_size_uses_compact_binary_units(self) -> None:
        self.assertEqual("0 B", format_byte_size(0))
        self.assertEqual("1023 B", format_byte_size(1023))
        self.assertEqual("1 KB", format_byte_size(1024))
        self.assertEqual("1.5 MB", format_byte_size(1572864))


if __name__ == "__main__":
    unittest.main()
