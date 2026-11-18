"""Address-only proof against a compact, shipped B17 contract.

No source rewriting, heap scans, native invocation or guessed offsets. A change
to a consumed layout or protected native routine requires a new tool release.
"""
from __future__ import annotations

import bisect
from pathlib import Path
import re
import struct

from .exports import dumper_script, dumper_types, unique
from .profile import RuntimeProfile, canonical, digest, require


def header_layouts(directory: Path) -> dict:
    header = (directory / "il2cpp.h").read_text("utf-8-sig")
    rows = re.findall(r"\b(\w+_Fields)\s*(?::([^\{]*))?\s*\{([^}]+)\};", header)
    selected = {}
    core = {"System_String_Fields", "System_Array_Fields",
            "UnityMainThreadDispatcher_PendingAction_Fields"}
    for name, parent, body in rows:
        if name in core or name.startswith(("System_Collections_Generic_", "System_Nullable_",
                                            "System_ValueTuple_")):
            require(name not in selected, "DUPLICATE_ABI_DECLARATION", name)
            selected[name] = re.sub(r"\s+", " ", parent + "{" + body).strip()
    require(len(selected) > 2000, "CLOSED_ABI_MISSING")
    return selected


def enum_contract(types: dict) -> dict:
    return {image + ":" + name: [list(v) for v in re.findall(r"public const \S+ (\w+) = ([^;]+);", row["text"])]
            for (image, name), row in types.items() if row["kind"] == "enum"}


def type_contract(types: dict, keys: list) -> dict:
    result = {}
    for image, name in keys:
        row = types.get((image, name))
        require(row is not None and row["fields"] is not None, "MANAGED_TYPE_UNKNOWN", name)
        result[image + ":" + name] = {"kind": row["kind"], "fields": row["fields"],
            "constants": [list(v) for v in re.findall(r"public const (\S+) (\w+) = ([^;]+);", row["text"])]}
    return result


class NativeAudit:
    def __init__(self, assembly: Path, script: dict):
        import pefile
        from capstone import Cs, CS_ARCH_X86, CS_MODE_64
        self.pe = pefile.PE(str(assembly), fast_load=True)
        require(self.pe.FILE_HEADER.Machine == 0x8664, "GAME_ARCH_UNSUPPORTED")
        self.script = script
        self.addresses = sorted(set(script["Addresses"]))
        self.methods = {}
        self.metadata = {}
        for row in script["ScriptMethod"]:
            self.methods.setdefault(row["Address"], []).append(row["Name"])
        for row in script["ScriptMetadata"]:
            self.metadata.setdefault(row["Address"], []).append([row["Name"], row["Signature"]])
        self.disassembler = Cs(CS_ARCH_X86, CS_MODE_64)
        self.disassembler.detail = True

    def close(self):
        self.pe.close()

    def rows(self, name: str):
        row = unique(self.script["ScriptMethod"], name)
        start = row["Address"]
        index = bisect.bisect_right(self.addresses, start)
        require(index < len(self.addresses), "METHOD_END_UNKNOWN", name)
        size = self.addresses[index] - start
        require(0 < size < 2**20, "METHOD_SIZE_INVALID", name)
        raw = self.pe.get_data(start, size)
        result = list(self.disassembler.disasm(raw, start))
        require(sum(i.size for i in result) == len(raw), "NATIVE_DECODE_INCOMPLETE", name)
        while result and result[-1].mnemonic == "int3":
            result.pop()
        return result

    def fingerprint(self, name: str) -> str:
        from capstone.x86 import X86_OP_MEM, X86_REG_RIP
        rows = self.rows(name)
        indices = {row.address: i for i, row in enumerate(rows)}
        result = []
        for ins in rows:
            op, mnemonic = ins.op_str, ins.mnemonic
            if "rip" in op:
                target = [ins.address + ins.size + o.mem.disp for o in ins.operands
                          if o.type == X86_OP_MEM and o.mem.base == X86_REG_RIP]
                require(len(target) == 1, "RIP_TARGET_AMBIGUOUS", name)
                address = target[0]
                symbol = self.metadata.get(address)
                if symbol:
                    replacement = "META:" + digest(sorted(symbol))
                elif mnemonic in {"movss", "mulss", "divss", "comiss", "ucomiss", "addss", "subss", "maxss", "minss"}:
                    replacement = "FLOAT:" + self.pe.get_data(address, 4).hex()
                else:
                    section = self.pe.get_section_by_rva(address)
                    require(section is not None, "RIP_OUTSIDE_IMAGE", name)
                    # Read-only constants/string bytes must stay identical. Writable
                    # cache/initialization slots are protected by the entire routine.
                    replacement = ("DATA:" + self.pe.get_data(address, 32).hex()
                                   if not section.Characteristics & 0x80000000 else "CACHE")
                op = re.sub(r"\[rip[^]]*\]", replacement, op)
            if (mnemonic == "call" or mnemonic.startswith("j")) and re.fullmatch(r"0x[0-9a-f]+", op):
                address = int(op, 16)
                if address in indices:
                    op = "INS:" + str(indices[address])
                elif address in self.methods:
                    op = "METHOD:" + digest(sorted(self.methods[address]))
                else:
                    # Unknown IL2CPP helpers have no symbol. Exact bytes are a
                    # deliberately conservative gate rather than a guessed role.
                    body = self.pe.get_data(address, 48)
                    require(len(body) == 48, "NATIVE_TARGET_UNKNOWN", name)
                    op = "HELPER:" + body.hex()
            result.append([mnemonic, re.sub(r"\s+", "", op)])
        return digest(result)

    def bridge(self) -> tuple[int, int, str]:
        from capstone.x86 import X86_OP_MEM, X86_REG_RIP
        rows = self.rows("UnityEngine.Component$$get_gameObject")
        def targets(ins):
            return [ins.address + ins.size + op.mem.disp for op in ins.operands
                    if op.type == X86_OP_MEM and op.mem.base == X86_REG_RIP]
        loads = [targets(r) for r in rows if r.op_str.startswith("rax, qword ptr [rip")]
        stores = [targets(r) for r in rows if r.op_str.startswith("qword ptr [rip") and r.op_str.endswith(", rax")]
        require(len(loads) == len(stores) == 1 and loads == stores and len(loads[0]) == 1,
                "COMPONENT_CACHE_UNKNOWN")
        literal = {targets(r)[0] for r in rows if r.op_str.startswith("rcx, [rip") and
                   self.pe.get_data(targets(r)[0], 96).startswith(
                       b"UnityEngine.Component::get_gameObject_Injected(System.IntPtr)\0")}
        require(len(literal) == 1, "COMPONENT_LITERAL_UNKNOWN")
        name = "UnityEngine.Object.MarshalledUnityObject$$Unmarshal<__Canon>"
        start = unique(self.script["ScriptMethod"], name)["Address"]
        require(any(r.mnemonic == "jmp" and r.op_str == hex(start) for r in rows), "COMPONENT_TAIL_UNKNOWN")
        tags = [r for r in self.rows(name) if r.mnemonic == "test" and r.op_str == "bl, 1"]
        require(len(tags) == 1, "UNMARSHAL_TAG_UNKNOWN")
        rva = tags[0].address
        signature = self.pe.get_data(rva, 24).hex()
        require(bytes(self.pe.__data__).count(bytes.fromhex(signature)) == 1, "UNMARSHAL_TAG_AMBIGUOUS")
        for name in ("Active$$get_Instance", "Board$$get_Instance"):
            require(any(r.op_str == "rax, qword ptr [rax + 0x98]" for r in self.rows(name)),
                    "STATIC_FIELDS_ABI_CHANGED")
        return loads[0][0], rva, signature


def audit_candidate(directory: Path, executable: Path, identity: dict, contract: dict) -> RuntimeProfile:
    require(identity["metadata_version"] == contract["identity"]["metadata_version"], "METADATA_ABI_CHANGED")
    require(identity["files"]["unity"] == contract["identity"]["files"]["unity"], "UNITY_ABI_CHANGED")
    require(identity["files"]["app_info"] == contract["identity"]["files"]["app_info"], "GAME_PRODUCT_CHANGED")
    require(identity["ui_assets"] == contract["identity"]["ui_assets"], "UI_ASSETS_CHANGED")
    types, script = dumper_types(str(directory)), dumper_script(str(directory))
    require(type_contract(types, contract["type_keys"]) == contract["types"], "MANAGED_CONTRACT_CHANGED")
    # New unrelated enums are acceptable; consumed values and all baseline enums
    # must retain their exact definitions. No fuzzy short-name matching.
    enums = enum_contract(types)
    require(all(enums.get(k) == v for k, v in contract["enums"].items()), "ENUM_CONTRACT_CHANGED")
    header = header_layouts(directory)
    require(all(header.get(k) == v for k, v in contract["header"].items()), "CLOSED_ABI_CHANGED")
    bindings = []
    for root in contract["roots"]:
        current = unique(script["ScriptMetadata"], root["name"])
        require(current["Signature"] == root["signature"], "TYPEINFO_SIGNATURE_CHANGED", root["name"])
        bindings.append([root["rva"], current["Address"]])
    native = NativeAudit(executable.parent / "GameAssembly.dll", script)
    try:
        for name, expected in contract["native_methods"].items():
            require(native.fingerprint(name) == expected, "NATIVE_CONTRACT_CHANGED", name)
        cache, unmarshal, signature = native.bridge()
        require(0 < cache < native.pe.OPTIONAL_HEADER.SizeOfImage - 8,
                "COMPONENT_CACHE_OUTSIDE_IMAGE")
        for _, rva in bindings:
            require(0 < rva < native.pe.OPTIONAL_HEADER.SizeOfImage - 8, "TYPEINFO_OUTSIDE_IMAGE")
    finally:
        native.close()
    data = {"schema": 1, "contract_sha256": digest(contract), "identity": identity,
            "bindings": bindings, "component_cache": cache, "unmarshal": [unmarshal, signature]}
    return RuntimeProfile.from_dict(data, contract)
