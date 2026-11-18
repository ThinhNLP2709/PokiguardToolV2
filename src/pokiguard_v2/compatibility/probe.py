"""Read-only live verification; this module never imports an input backend."""
from __future__ import annotations
from pathlib import Path
import struct

from .profile import RuntimeProfile, require, CompatibilityError


def verify_loaded_image(memory, base: int, path: Path) -> None:
    """Reject a still-running old executable after its files were updated.

    Compare executable sections with disk, accounting only for PE DIR64 ASLR
    relocations. All reads are bounded module reads, never a heap scan.
    """
    import pefile
    pe = pefile.PE(str(path), fast_load=True)
    try:
        pe.parse_data_directories(directories=[pefile.DIRECTORY_ENTRY["IMAGE_DIRECTORY_ENTRY_BASERELOC"]])
        delta = base - pe.OPTIONAL_HEADER.ImageBase
        for section in pe.sections:
            if not section.Characteristics & 0x20000000:
                continue
            raw = bytearray(section.get_data())
            start = section.VirtualAddress
            for block in getattr(pe, "DIRECTORY_ENTRY_BASERELOC", ()):
                for entry in block.entries:
                    offset = entry.rva - start
                    if 0 <= offset < len(raw):
                        require(entry.type in (0, 10), "PE_RELOCATION_UNSUPPORTED")
                        if entry.type == 10:
                            require(offset + 8 <= len(raw), "PE_RELOCATION_INVALID")
                            value = struct.unpack_from("<Q", raw, offset)[0]
                            struct.pack_into("<Q", raw, offset, (value + delta) % 2**64)
            for offset in range(0, len(raw), 256 * 1024):
                expected = bytes(raw[offset:offset + 256 * 1024])
                require(memory.read(base + start + offset, len(expected)) == expected,
                        "RUNNING_GAME_DIFFERS_FROM_DISK", "Hãy thoát và mở lại game đã cập nhật.")
    finally:
        pe.close()


def live_probe(executable: Path, profile: RuntimeProfile) -> dict:
    from tools.runtime_common import configure_game_location, attach_target
    from ..boss_lobby_runtime import read_chinh_phuc_room
    from ..native_card_ui import NativeCardUiReader
    from ..il2cpp_external import is_canonical_user_pointer

    configure_game_location(executable)
    with attach_target(candidate_profile=profile) as target:
        resolver = target.resolver
        roots = []
        required = {"Board_TypeInfo", "Active_TypeInfo", "ManagerMatch_TypeInfo",
                    "ManagerRoom_TypeInfo", "WsRoomService_TypeInfo"}
        from .profile import load_contract
        for row in load_contract()["roots"]:
            if row["name"] not in required:
                continue
            klass = resolver.resolve_type_info_class(row["rva"])
            require(klass is not None, "SCENE_NOT_READY", "Vào phòng boss và để yên ở nút Bắt đầu.")
            name_ptr = resolver.read_pointer(klass + 0x10)
            namespace_ptr = resolver.read_pointer(klass + 0x18)
            def cstring(address):
                require(is_canonical_user_pointer(address), "CLASS_NAME_POINTER_INVALID")
                raw = bytearray()
                for index in range(96):
                    byte = target.memory.read(address + index, 1)
                    if byte == b"\0":
                        return raw.decode("ascii")
                    raw.extend(byte)
                raise CompatibilityError("CLASS_NAME_INVALID")
            require((cstring(name_ptr), cstring(namespace_ptr)) ==
                    (row["name"].removesuffix("_TypeInfo"), ""), "ROOT_CLASS_MISMATCH", row["name"])
            roots.append(row["name"])
        room = read_chinh_phuc_room(resolver)
        require(room.clean and room.button_start is not None and room.button_interactable is True
                and room.button_groups_allow is True, "SCENE_NOT_READY",
                "Vào phòng boss do bạn làm chủ, để hiện nút Bắt đầu rồi thử lại.")
        rects = []
        for _ in range(2):
            native = NativeCardUiReader(target.memory, target.game_assembly.base)
            geometry = native.read_button_geometry(room.button_start, max_translation_jitter=1.0,
                                                   allow_nested_fullscreen_canvas=True)
            require(geometry.active and geometry.viewport_rect is not None, "START_GEOMETRY_INVALID")
            rects.append(geometry.viewport_rect)
        require(all(abs(a - b) < 0.002 for a, b in zip(*rects)), "START_GEOMETRY_UNSTABLE")
        require(target.is_running(), "PROCESS_EXITED")
        return {"status": "verified", "pid": target.pid, "roots": roots,
                "start_rect": list(rects[-1]), "profile_id": profile.profile_id,
                "process_access": "QUERY_INFORMATION|VM_READ", "game_inputs": 0,
                "gameplay_qualification": "not_granted"}
