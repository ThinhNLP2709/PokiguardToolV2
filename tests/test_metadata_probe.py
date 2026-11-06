from __future__ import annotations

from pathlib import Path
import struct
import tempfile
import unittest

from tools.metadata_probe import (
    EXPECTED_MAGIC,
    EXPECTED_VERSION,
    SUPPORTED_VERSIONS,
    MetadataProbeError,
    parse_metadata,
    resolve_metadata_path,
)


class MetadataProbeTests(unittest.TestCase):
    def test_metadata_111_header_supported_but_future_or_bad_magic_invalid(self):
        with tempfile.TemporaryDirectory() as temp_dir:
            path = Path(temp_dir) / "global-metadata.dat"
            for magic, version, valid in ((EXPECTED_MAGIC, 111, True),
                                           (EXPECTED_MAGIC, 112, False), (0, 111, False)):
                with self.subTest(magic=magic, version=version):
                    path.write_bytes(struct.pack("<II", magic, version))
                    self.assertEqual(parse_metadata(path).valid, valid)

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

    def test_resolves_versioned_game_folder_and_accepts_metadata_110(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            root = Path(temp_dir)
            path = (
                root
                / "Pokiguard-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat"
            )
            path.parent.mkdir(parents=True)
            path.write_bytes(struct.pack("<II", EXPECTED_MAGIC, 110))
            result = parse_metadata(resolve_metadata_path(root))
        self.assertIn(110, SUPPORTED_VERSIONS)
        self.assertEqual(result.version, 110)
        self.assertTrue(result.valid)

    def test_resolves_petpuzzle_versioned_game_folder(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            root = Path(temp_dir)
            path = (
                root
                / "PetPuzzle-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat"
            )
            path.parent.mkdir(parents=True)
            path.write_bytes(struct.pack("<II", EXPECTED_MAGIC, 110))
            self.assertEqual(resolve_metadata_path(root), path.resolve())

    def test_rejects_short_file(self) -> None:
        with tempfile.TemporaryDirectory() as temp_dir:
            path = Path(temp_dir) / "global-metadata.dat"
            path.write_bytes(b"short")
            with self.assertRaises(MetadataProbeError):
                parse_metadata(path)


if __name__ == "__main__":
    unittest.main()
