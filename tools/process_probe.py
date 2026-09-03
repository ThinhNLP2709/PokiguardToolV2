#!/usr/bin/env python3
"""Attach to Pokiguard.exe with read/query rights and probe GameAssembly.dll.

The probe never requests write access and never creates a remote thread.
"""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
import os
import struct
import sys
from typing import Iterable, Sequence


PROCESS_VM_READ = 0x0010
PROCESS_QUERY_INFORMATION = 0x0400
TH32CS_SNAPPROCESS = 0x00000002
TH32CS_SNAPMODULE = 0x00000008
TH32CS_SNAPMODULE32 = 0x00000010
MAX_PATH = 260
MAX_MODULE_NAME32 = 255
ERROR_NO_MORE_FILES = 18
ERROR_BAD_LENGTH = 24
IMAGE_FILE_MACHINE_UNKNOWN = 0x0000
IMAGE_FILE_MACHINE_I386 = 0x014C
IMAGE_FILE_MACHINE_AMD64 = 0x8664


class ProcessProbeError(RuntimeError):
    """Raised for a fail-closed Win32 probing error."""


@dataclass(frozen=True)
class ProcessInfo:
    pid: int
    executable_name: str


@dataclass(frozen=True)
class ModuleInfo:
    name: str
    path: str
    base: int
    size: int

    @property
    def end(self) -> int:
        return checked_module_end(self.base, self.size)


def assert_python_x64() -> None:
    bits = struct.calcsize("P") * 8
    if bits != 64:
        raise ProcessProbeError(f"Python must be x64; current interpreter is {bits}-bit")


def checked_module_end(base: int, size: int) -> int:
    if base <= 0:
        raise ValueError("module base must be positive")
    if size <= 0:
        raise ValueError("module size must be positive")
    end = base + size
    if end <= base or end > 0xFFFFFFFFFFFFFFFF:
        raise ValueError("module address range overflows x64")
    return end


def find_named_module(modules: Iterable[ModuleInfo], name: str) -> ModuleInfo | None:
    expected = name.casefold()
    return next((module for module in modules if module.name.casefold() == expected), None)


def architecture_label(process_machine: int, native_machine: int) -> str:
    if process_machine == IMAGE_FILE_MACHINE_I386:
        return "x86 (WOW64)"
    if process_machine == IMAGE_FILE_MACHINE_AMD64:
        return "x64"
    if process_machine == IMAGE_FILE_MACHINE_UNKNOWN and native_machine == IMAGE_FILE_MACHINE_AMD64:
        return "x64"
    return f"unknown (process=0x{process_machine:04X}, native=0x{native_machine:04X})"


if os.name == "nt":
    ULONG_PTR = ctypes.c_size_t
    BYTE = ctypes.c_ubyte

    class PROCESSENTRY32W(ctypes.Structure):
        _fields_ = [
            ("dwSize", wintypes.DWORD),
            ("cntUsage", wintypes.DWORD),
            ("th32ProcessID", wintypes.DWORD),
            ("th32DefaultHeapID", ULONG_PTR),
            ("th32ModuleID", wintypes.DWORD),
            ("cntThreads", wintypes.DWORD),
            ("th32ParentProcessID", wintypes.DWORD),
            ("pcPriClassBase", wintypes.LONG),
            ("dwFlags", wintypes.DWORD),
            ("szExeFile", wintypes.WCHAR * MAX_PATH),
        ]

    class MODULEENTRY32W(ctypes.Structure):
        _fields_ = [
            ("dwSize", wintypes.DWORD),
            ("th32ModuleID", wintypes.DWORD),
            ("th32ProcessID", wintypes.DWORD),
            ("GlblcntUsage", wintypes.DWORD),
            ("ProccntUsage", wintypes.DWORD),
            ("modBaseAddr", ctypes.POINTER(BYTE)),
            ("modBaseSize", wintypes.DWORD),
            ("hModule", wintypes.HMODULE),
            ("szModule", wintypes.WCHAR * (MAX_MODULE_NAME32 + 1)),
            ("szExePath", wintypes.WCHAR * MAX_PATH),
        ]

    kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)
    INVALID_HANDLE_VALUE = ctypes.c_void_p(-1).value

    kernel32.CreateToolhelp32Snapshot.argtypes = [wintypes.DWORD, wintypes.DWORD]
    kernel32.CreateToolhelp32Snapshot.restype = wintypes.HANDLE
    kernel32.Process32FirstW.argtypes = [wintypes.HANDLE, ctypes.POINTER(PROCESSENTRY32W)]
    kernel32.Process32FirstW.restype = wintypes.BOOL
    kernel32.Process32NextW.argtypes = [wintypes.HANDLE, ctypes.POINTER(PROCESSENTRY32W)]
    kernel32.Process32NextW.restype = wintypes.BOOL
    kernel32.Module32FirstW.argtypes = [wintypes.HANDLE, ctypes.POINTER(MODULEENTRY32W)]
    kernel32.Module32FirstW.restype = wintypes.BOOL
    kernel32.Module32NextW.argtypes = [wintypes.HANDLE, ctypes.POINTER(MODULEENTRY32W)]
    kernel32.Module32NextW.restype = wintypes.BOOL
    kernel32.OpenProcess.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.DWORD]
    kernel32.OpenProcess.restype = wintypes.HANDLE
    kernel32.ReadProcessMemory.argtypes = [
        wintypes.HANDLE,
        wintypes.LPCVOID,
        wintypes.LPVOID,
        ctypes.c_size_t,
        ctypes.POINTER(ctypes.c_size_t),
    ]
    kernel32.ReadProcessMemory.restype = wintypes.BOOL
    kernel32.CloseHandle.argtypes = [wintypes.HANDLE]
    kernel32.CloseHandle.restype = wintypes.BOOL


def _require_windows() -> None:
    if os.name != "nt":
        raise ProcessProbeError("process_probe.py is Windows-only")


def _close_handle(handle: int | None) -> None:
    if handle and handle != INVALID_HANDLE_VALUE:
        kernel32.CloseHandle(handle)


def _snapshot(flags: int, pid: int = 0) -> int:
    for _ in range(4):
        handle = kernel32.CreateToolhelp32Snapshot(flags, pid)
        if handle != INVALID_HANDLE_VALUE:
            return handle
        if ctypes.get_last_error() != ERROR_BAD_LENGTH:
            break
    raise ctypes.WinError(ctypes.get_last_error())


def enumerate_processes() -> tuple[ProcessInfo, ...]:
    """Return the current Toolhelp process list without opening any process."""

    _require_windows()
    snapshot = _snapshot(TH32CS_SNAPPROCESS)
    processes: list[ProcessInfo] = []
    try:
        entry = PROCESSENTRY32W()
        entry.dwSize = ctypes.sizeof(entry)
        if not kernel32.Process32FirstW(snapshot, ctypes.byref(entry)):
            error = ctypes.get_last_error()
            if error == ERROR_NO_MORE_FILES:
                return ()
            raise ctypes.WinError(error)
        while True:
            processes.append(
                ProcessInfo(int(entry.th32ProcessID), str(entry.szExeFile))
            )
            if not kernel32.Process32NextW(snapshot, ctypes.byref(entry)):
                error = ctypes.get_last_error()
                if error != ERROR_NO_MORE_FILES:
                    raise ctypes.WinError(error)
                break
    finally:
        _close_handle(snapshot)
    return tuple(sorted(processes, key=lambda value: value.pid))


def find_process_ids(executable_name: str) -> tuple[int, ...]:
    """Return every PID whose image name exactly matches, ordered by PID."""

    expected = executable_name.casefold()
    return tuple(
        process.pid
        for process in enumerate_processes()
        if process.executable_name.casefold() == expected
    )


def find_process_id(executable_name: str = "Pokiguard.exe") -> int | None:
    matches = find_process_ids(executable_name)
    return matches[0] if matches else None


def enumerate_modules(pid: int) -> list[ModuleInfo]:
    _require_windows()
    snapshot = _snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, pid)
    modules: list[ModuleInfo] = []
    try:
        entry = MODULEENTRY32W()
        entry.dwSize = ctypes.sizeof(entry)
        if not kernel32.Module32FirstW(snapshot, ctypes.byref(entry)):
            raise ctypes.WinError(ctypes.get_last_error())
        while True:
            base = ctypes.cast(entry.modBaseAddr, ctypes.c_void_p).value or 0
            modules.append(
                ModuleInfo(entry.szModule, entry.szExePath, base, int(entry.modBaseSize))
            )
            if not kernel32.Module32NextW(snapshot, ctypes.byref(entry)):
                error = ctypes.get_last_error()
                if error != ERROR_NO_MORE_FILES:
                    raise ctypes.WinError(error)
                break
    finally:
        _close_handle(snapshot)
    return modules


def target_architecture(handle: int) -> str:
    _require_windows()
    is_wow64_process2 = getattr(kernel32, "IsWow64Process2", None)
    if is_wow64_process2 is not None:
        is_wow64_process2.argtypes = [
            wintypes.HANDLE,
            ctypes.POINTER(wintypes.WORD),
            ctypes.POINTER(wintypes.WORD),
        ]
        is_wow64_process2.restype = wintypes.BOOL
        process_machine = wintypes.WORD()
        native_machine = wintypes.WORD()
        if not is_wow64_process2(
            handle, ctypes.byref(process_machine), ctypes.byref(native_machine)
        ):
            raise ctypes.WinError(ctypes.get_last_error())
        return architecture_label(process_machine.value, native_machine.value)

    is_wow64 = wintypes.BOOL()
    kernel32.IsWow64Process.argtypes = [wintypes.HANDLE, ctypes.POINTER(wintypes.BOOL)]
    kernel32.IsWow64Process.restype = wintypes.BOOL
    if not kernel32.IsWow64Process(handle, ctypes.byref(is_wow64)):
        raise ctypes.WinError(ctypes.get_last_error())
    return "x86 (WOW64)" if is_wow64.value else "x64"


def read_bytes(handle: int, address: int, size: int) -> bytes:
    if address <= 0 or size <= 0:
        raise ValueError("address and size must be positive")
    buffer = (ctypes.c_ubyte * size)()
    bytes_read = ctypes.c_size_t()
    if not kernel32.ReadProcessMemory(
        handle,
        ctypes.c_void_p(address),
        buffer,
        size,
        ctypes.byref(bytes_read),
    ):
        raise ctypes.WinError(ctypes.get_last_error())
    if bytes_read.value != size:
        raise ProcessProbeError(
            f"short ReadProcessMemory: requested={size}, read={bytes_read.value}"
        )
    return bytes(buffer)


def main(argv: Sequence[str] | None = None) -> int:
    del argv  # Reserved for future read-only filters.
    try:
        _require_windows()
        assert_python_x64()
        pid = find_process_id("Pokiguard.exe")
        if pid is None:
            raise ProcessProbeError("Pokiguard.exe is not running")

        access = PROCESS_QUERY_INFORMATION | PROCESS_VM_READ
        process = kernel32.OpenProcess(access, False, pid)
        if not process:
            raise ctypes.WinError(ctypes.get_last_error())
        try:
            architecture = target_architecture(process)
            modules = enumerate_modules(pid)
            game_assembly = find_named_module(modules, "GameAssembly.dll")
            if game_assembly is None:
                raise ProcessProbeError("GameAssembly.dll not found in target module list")
            checked_module_end(game_assembly.base, game_assembly.size)
            sample = read_bytes(process, game_assembly.base, 64)
            if sample[:2] != b"MZ":
                raise ProcessProbeError(
                    f"unexpected GameAssembly header: {sample[:2].hex(' ').upper()}"
                )
        finally:
            _close_handle(process)

        print(f"PID: {pid}")
        print(f"architecture: {architecture}")
        print(f"GameAssembly runtime base: 0x{game_assembly.base:016X}")
        print(f"module size: 0x{game_assembly.size:X} ({game_assembly.size} bytes)")
        print(f"ReadProcessMemory: OK ({len(sample)} bytes, MZ header verified)")
        print(f"sample[0:16]: {sample[:16].hex(' ').upper()}")
        return 0
    except (OSError, ProcessProbeError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
