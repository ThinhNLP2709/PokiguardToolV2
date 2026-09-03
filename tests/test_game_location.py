from __future__ import annotations

from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.game_location import (
    GameLocationError,
    game_assembly_sha256,
    is_supported_game_executable_name,
    resolve_game_executable,
    validate_supported_game_assembly,
)
from tools.process_probe import ModuleInfo
import tools.runtime_common as runtime_common


class GameLocationTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temporary = tempfile.TemporaryDirectory()
        self.root = Path(self.temporary.name)
        (self.root / "GameAssembly.dll").write_bytes(b"MZ")

    def tearDown(self) -> None:
        self.temporary.cleanup()

    def test_current_versioned_name_is_supported(self) -> None:
        self.assertTrue(is_supported_game_executable_name("Pokiguard-1.7.4.exe"))
        self.assertTrue(is_supported_game_executable_name("POKIGUARD-2.0.EXE"))
        self.assertFalse(is_supported_game_executable_name("PokiguardToolV2.exe"))

    def test_folder_selects_highest_numeric_version(self) -> None:
        (self.root / "Pokiguard-1.7.4.exe").write_bytes(b"MZ")
        (self.root / "Pokiguard-1.10.0.exe").write_bytes(b"MZ")
        (self.root / "Pokiguard.exe").write_bytes(b"MZ")
        selected = resolve_game_executable(self.root)
        self.assertEqual(self.root.resolve(), selected.location)
        self.assertEqual("Pokiguard-1.10.0.exe", selected.executable.name)
        self.assertEqual((1, 10, 0), selected.version)

    def test_direct_executable_path_is_accepted(self) -> None:
        executable = self.root / "Pokiguard-1.7.4.exe"
        executable.write_bytes(b"MZ")
        selected = resolve_game_executable(executable)
        self.assertEqual(executable.resolve(), selected.executable)

    def test_folder_without_game_executable_fails_closed(self) -> None:
        with self.assertRaises(GameLocationError) as context:
            resolve_game_executable(self.root)
        self.assertEqual("GAME_EXECUTABLE_NOT_FOUND", context.exception.reason)

    def test_executable_without_game_assembly_fails_closed(self) -> None:
        other = self.root / "other"
        other.mkdir()
        executable = other / "Pokiguard-1.7.4.exe"
        executable.write_bytes(b"MZ")
        with self.assertRaises(GameLocationError) as context:
            resolve_game_executable(executable)
        self.assertEqual("GAME_ASSEMBLY_NOT_FOUND", context.exception.reason)

    def test_runtime_pid_selection_requires_the_configured_full_path(self) -> None:
        executable = self.root / "Pokiguard-1.7.4.exe"
        executable.write_bytes(b"MZ")
        selected = resolve_game_executable(self.root)
        wrong = ModuleInfo(
            executable.name,
            str(self.root / "other" / executable.name),
            0x1000,
            0x1000,
        )
        exact = ModuleInfo(
            executable.name,
            str(executable),
            0x2000,
            0x1000,
        )
        with (
            patch.object(runtime_common, "find_process_ids", return_value=(11, 12)),
            patch.object(
                runtime_common,
                "enumerate_modules",
                side_effect=([wrong], [exact]),
            ),
        ):
            self.assertEqual(12, runtime_common._find_configured_process(selected))

    def test_game_assembly_hash_is_read_only_and_unknown_build_fails_closed(self) -> None:
        game_assembly = self.root / "GameAssembly.dll"
        before = game_assembly.read_bytes()
        digest = game_assembly_sha256(game_assembly)
        self.assertEqual(64, len(digest))
        self.assertEqual(before, game_assembly.read_bytes())
        with self.assertRaises(GameLocationError) as context:
            validate_supported_game_assembly(game_assembly)
        self.assertEqual("GAME_BUILD_INCOMPATIBLE", context.exception.reason)


if __name__ == "__main__":
    unittest.main()
