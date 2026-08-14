from __future__ import annotations

from pathlib import Path
import struct
import tempfile
import unittest

from tools.metadata_probe import (
    EXPECTED_MAGIC,
    EXPECTED_VERSION,
    MetadataProbeError,
    parse_metadata,
    resolve_metadata_path,
)


class MetadataProbeTests(unittest.TestCase):
    def test_parses_little_endian_header_and_size(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            path = Path(temp_dir) / "global-metadata.dat"
            payload = struct.pack("<II", EXPECTED_MAGIC, EXPECTED_VERSION) + b"fixture"
            path.write_bytes(payload)
            result = parse_metadata(path)
        self.assertEqual(result.magic, EXPECTED_MAGIC)
        self.assertEqual(result.version, EXPECTED_VERSION)
        self.assertEqual(result.file_size, len(payload))
        self.assertTrue(result.valid)

    def test_resolves_game_folder_layout(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            root = Path(temp_dir)
            path = root / "Pokiguard_Data/il2cpp_data/Metadata/global-metadata.dat"
            path.parent.mkdir(parents=True)
            path.write_bytes(struct.pack("<II", EXPECTED_MAGIC, EXPECTED_VERSION))
            self.assertEqual(resolve_metadata_path(root), path.resolve())

    def test_rejects_short_file(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            path = Path(temp_dir) / "global-metadata.dat"
            path.write_bytes(b"short")
            with self.assertRaises(MetadataProbeError):
                parse_metadata(path)


if __name__ == "__main__":
    unittest.main()
