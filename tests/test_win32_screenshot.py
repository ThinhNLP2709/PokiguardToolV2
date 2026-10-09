from __future__ import annotations

from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.win32_screenshot import (
    _bgra_to_rgb,
    configure_diagnostic_image_writes,
    diagnostic_image_writes_enabled,
    write_png_rgb,
    write_recovery_png_rgb,
)


class Win32ScreenshotTests(unittest.TestCase):
    def tearDown(self) -> None:
        configure_diagnostic_image_writes(enabled=True)

    def test_fast_bgra_matches_original_pixel_order_and_ignores_alpha(self) -> None:
        bgra = bytes(range(256)) * 97
        expected = bytes(channel for offset in range(0, len(bgra), 4)
                         for channel in (bgra[offset + 2], bgra[offset + 1], bgra[offset]))
        self.assertEqual(_bgra_to_rgb(bgra), expected)
        self.assertEqual(_bgra_to_rgb(b""), b"")

    def test_fast_bgra_rejects_partial_pixel(self) -> None:
        with self.assertRaises(ValueError):
            _bgra_to_rgb(b"\x00\x01\x02")

    def test_dependency_free_png_encoder(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "test.png"
            write_png_rgb(path, 2, 1, bytes((255, 0, 0, 0, 255, 0)))
            raw = path.read_bytes()
            self.assertTrue(raw.startswith(b"\x89PNG\r\n\x1a\n"))
            self.assertIn(b"IHDR", raw)
            self.assertIn(b"IDAT", raw)

    def test_disabled_diagnostic_writes_keep_pixels_in_memory_only(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "disabled.png"
            configure_diagnostic_image_writes(enabled=False)

            write_png_rgb(path, 1, 1, bytes((12, 34, 56)))

            self.assertFalse(path.exists())
            self.assertFalse(diagnostic_image_writes_enabled())

    def test_disabled_diagnostic_writes_still_validate_rgb_buffer(self) -> None:
        configure_diagnostic_image_writes(enabled=False)

        with self.assertRaises(ValueError):
            write_png_rgb(Path("ignored.png"), 1, 1, b"no")

    def test_recovery_evidence_png_is_written_when_routine_images_are_disabled(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "recovery.png"
            configure_diagnostic_image_writes(enabled=False)

            write_recovery_png_rgb(path, 1, 1, bytes((12, 34, 56)))

            self.assertTrue(path.is_file())
            self.assertTrue(path.read_bytes().startswith(b"\x89PNG\r\n\x1a\n"))


if __name__ == "__main__":
    unittest.main()
