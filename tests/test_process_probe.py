from __future__ import annotations

import os
import unittest

from tools import process_probe
from tools.process_probe import (
    IMAGE_FILE_MACHINE_AMD64,
    IMAGE_FILE_MACHINE_I386,
    IMAGE_FILE_MACHINE_UNKNOWN,
    ModuleInfo,
    architecture_label,
    checked_module_end,
    find_named_module,
)


class ProcessProbeHelperTests(unittest.TestCase):
    def test_module_lookup_is_case_insensitive(self) -> None:
        modules = [ModuleInfo("GAMEASSEMBLY.DLL", "D:/pc/GameAssembly.dll", 0x1000, 0x2000)]
        found = find_named_module(modules, "GameAssembly.dll")
        self.assertIsNotNone(found)
        self.assertEqual(found.base, 0x1000)

    def test_checked_module_end(self) -> None:
        self.assertEqual(checked_module_end(0x100000, 0x2000), 0x102000)
        with self.assertRaises(ValueError):
            checked_module_end(0, 0x2000)
        with self.assertRaises(ValueError):
            checked_module_end(0x1000, 0)

    def test_architecture_labels(self) -> None:
        self.assertEqual(
            architecture_label(IMAGE_FILE_MACHINE_UNKNOWN, IMAGE_FILE_MACHINE_AMD64),
            "x64",
        )
        self.assertEqual(
            architecture_label(IMAGE_FILE_MACHINE_I386, IMAGE_FILE_MACHINE_AMD64),
            "x86 (WOW64)",
        )

    @unittest.skipUnless(os.name == "nt", "Win32 integration check")
    def test_minimal_rights_read_works_on_current_process(self) -> None:
        pid = os.getpid()
        access = process_probe.PROCESS_QUERY_INFORMATION | process_probe.PROCESS_VM_READ
        handle = process_probe.kernel32.OpenProcess(access, False, pid)
        self.assertTrue(handle)
        try:
            modules = process_probe.enumerate_modules(pid)
            self.assertGreater(len(modules), 0)
            sample = process_probe.read_bytes(handle, modules[0].base, 64)
            self.assertEqual(sample[:2], b"MZ")
        finally:
            process_probe._close_handle(handle)


if __name__ == "__main__":
    unittest.main()
