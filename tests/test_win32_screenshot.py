from __future__ import annotations

from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.win32_screenshot import write_png_rgb


class Win32ScreenshotTests(unittest.TestCase):
    def test_dependency_free_png_encoder(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "test.png"
            write_png_rgb(path, 2, 1, bytes((255, 0, 0, 0, 255, 0)))
            raw = path.read_bytes()
            self.assertTrue(raw.startswith(b"\x89PNG\r\n\x1a\n"))
            self.assertIn(b"IHDR", raw)
            self.assertIn(b"IDAT", raw)


if __name__ == "__main__":
    unittest.main()
