"""Static research only. Read the B15 PE and Dumper index; never attach/call game."""
from pathlib import Path
import bisect
import hashlib
import json
import struct

import capstone
import pefile

ROOT = Path(__file__).resolve().parents[3]
OUT = Path(__file__).resolve().parent
EXPECTED = "18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea"
BINARY = Path(r"D:\pc\GameAssembly.dll")
raw = BINARY.read_bytes()
assert hashlib.sha256(raw).hexdigest() == EXPECTED, "Different game binary"
pe = pefile.PE(data=raw, fast_load=True)
script = json.loads((ROOT / "reverse/reverse_1.7.4-b15/script.json").read_text(encoding="utf-8"))
methods = {m["Name"]: m for m in script["ScriptMethod"]}
names = {}
for m in script["ScriptMethod"]:
    names.setdefault(m["Address"], []).append(m["Name"])
symbols = {m["Address"]: m["Name"] for m in script["ScriptMetadata"]}
symbols.update({m["Address"]: repr(m["Value"]) for m in script["ScriptString"]})
boundaries = sorted(set(script["Addresses"]) | set(names))
md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
md.detail = True

def instructions(name):
    start = methods[name]["Address"]
    end = boundaries[bisect.bisect_right(boundaries, start)]
    return list(md.disasm(pe.get_data(start, end - start), start))

def annotated(ins):
    refs = []
    for op in ins.operands:
        if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
            ref = ins.address + ins.size + op.mem.disp
            if ref in symbols:
                refs.append(symbols[ref])
        elif op.type == capstone.x86.X86_OP_IMM and ins.mnemonic in {"call", "jmp"}:
            refs.extend(names.get(op.imm, ()))
    return f"{ins.address:08X} {ins.mnemonic:<10} {ins.op_str:<50} {' | '.join(refs)}".rstrip()

selected = [
    "CardUI$$IsRowSkillType", "CardUI$$IsSealSkillType", "CardUI$$IsMegaTrexType",
    "CardUI$$IsMegaIcarusType", "CardUI$$IsSkillCard", "CardUI$$CanUseCard",
    "CardUI$$ElementTypeUpper", "CardUI$$CheckConditionUse",
    "CardUI$$StartMegaIcarusPanel", "CardUI$$StartMegaTrexPanel",
    "CardUI$$StartMegaSealCast", "CardUI.<RunMegaSealAutoCast>d__425$$MoveNext",
    "MegaSeal$$SkillType", "MegaSeal$$Contains", "MegaTrexPattern$$ToBoardCell",
    "MegaIcarusPattern$$.cctor",
    "MegaTrexPattern$$.cctor", "BoardWsApplier.<ApplyMegaTrexMark>d__182$$MoveNext",
    "Active$$GetWeaknessVsBoss", "Active$$GetDamageMultiplier", "Active$$SumBoardDotDamage",
    "MatchService$$ParseCombatBatch", "Active$$RenderWsCombat",
]
index = {"game_assembly_sha256": EXPECTED, "methods": {}, "classifiers": {}}
for name in selected:
    code = instructions(name)
    stem = name.replace("$$", "_").replace(".", "_").replace("<", "_").replace(">", "_")
    file = stem + ".txt"
    (OUT / file).write_text("\n".join(annotated(i) for i in code) + "\n", encoding="utf-8")
    index["methods"][name] = {"rva": hex(methods[name]["Address"]), "file": file}
for name, method in methods.items():
    if name.startswith("CardUI$$Is") and ("Type" in name or "SkillCard" in name):
        refs = []
        for ins in instructions(name):
            for op in ins.operands:
                if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                    ref = ins.address + ins.size + op.mem.disp
                    if ref in symbols and symbols[ref].startswith("'"):
                        refs.append(symbols[ref])
        index["classifiers"][name] = {"rva": hex(method["Address"]), "string_refs": sorted(set(refs))}
(OUT / "native_index.json").write_text(json.dumps(index, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

# Both audited initializers build each Vector2Int in the same 8-byte stack slot.
# Decode that slot at each sequential array store, rejecting other code shapes.
def initializer_cells(name):
    slot = bytearray(8)
    known = [False] * 8
    zero_regs = set()
    result = []
    code = instructions(name)
    for ins in code:
        ops = ins.operands
        if ins.mnemonic == "xor" and len(ops) == 2 and ops[0].type == ops[1].type == capstone.x86.X86_OP_REG and ops[0].reg == ops[1].reg:
            zero_regs.add(ops[0].reg)
        if ins.mnemonic != "mov" or len(ops) != 2 or ops[0].type != capstone.x86.X86_OP_MEM:
            continue
        dst, src = ops
        if dst.mem.base == capstone.x86.X86_REG_RSP and dst.mem.disp in {0x38, 0x3c}:
            assert dst.size in {4, 8}
            value = src.imm if src.type == capstone.x86.X86_OP_IMM else 0 if src.type == capstone.x86.X86_OP_REG and src.reg in zero_regs else None
            assert value is not None, hex(ins.address)
            offset = dst.mem.disp - 0x38
            slot[offset:offset + dst.size] = int(value).to_bytes(dst.size, "little", signed=True)
            known[offset:offset + dst.size] = [True] * dst.size
        elif dst.mem.base in {capstone.x86.X86_REG_RAX, capstone.x86.X86_REG_RDX} and dst.size == 8 and dst.mem.disp >= 0x20:
            assert dst.mem.disp == 0x20 + len(result) * 8 and all(known), hex(ins.address)
            x, y = struct.unpack("<ii", slot)
            result.append(dict(col=x, screen_row=y, store_rva=hex(ins.address)))
    assert len(result) == 30
    assert len({(c["col"], c["screen_row"]) for c in result}) == 30
    assert all(0 <= c["col"] < 8 and 0 <= c["screen_row"] < 8 for c in result)
    return result

masks = json.loads((OUT / "seal_masks.json").read_text(encoding="utf-8"))
for kind in ("Icarus", "Trex"):
    decoded = initializer_cells(f"Mega{kind}Pattern$$.cctor")
    assert decoded == masks["patterns"][kind]["cells"]
    mask = ["".join("#" if any(c["col"] == col and c["screen_row"] == row for c in decoded) else "." for col in range(8)) for row in range(8)]
    assert mask == masks["patterns"][kind]["mask"]
icarus = {(c["screen_row"], c["col"]) for c in masks["patterns"]["Icarus"]["cells"]}
trex = {(c["screen_row"], c["col"]) for c in masks["patterns"]["Trex"]["cells"]}
from pokiguard_v2.mega_icarus import MEGA_ICARUS_SEAL_CELLS
assert icarus == set(MEGA_ICARUS_SEAL_CELLS)
assert len(icarus ^ trex) == 22
checks = dict(game_assembly_sha256=EXPECTED, initializer_decode_matches=True,
              icarus_matches_existing_source=True, count_icarus=len(icarus), count_trex=len(trex),
              common_cells=len(icarus & trex), symmetric_difference=len(icarus ^ trex),
              only_icarus=sorted(icarus - trex), only_trex=sorted(trex - icarus),
              new_gameplay_code=False, live_reads=0, game_input=0)
(OUT / "static_checks.json").write_text(json.dumps(checks, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
print(json.dumps({"methods": len(index["methods"]), "checks": checks}, ensure_ascii=False, indent=2))
