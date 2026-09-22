"""Read-only native evidence export for the b4 QTE input-flow audit."""
import hashlib
import json
import re
from collections import defaultdict
from pathlib import Path

import capstone
import pefile
from capstone.x86 import X86_OP_IMM, X86_OP_MEM, X86_REG_RIP


ROOT = Path(__file__).resolve().parents[1]
REVERSE = ROOT / "reverse/reverse_1.7.4-b4"
BINARY = Path("D:/pc/GameAssembly.dll")
EXPECTED = "d55bde20918f65e84700736e0ede33aa8ee50a10956590d28fb8e53d185b28d6"

SELECT = {
    "CardUI": {"OnAuditionPress", "OnAuditionTap", "OnDirectionButtonPress",
               "CheckDotArrow", "OnEnterButtonPress", "Update", "ShowTimingResult",
               "CurrentQteElapsedMs", "SendQteEventSafe", "ResetDotCombo"},
    "CardUIPVP": {"OnAuditionPress", "OnAuditionTap", "OnDirectionButtonPress",
                  "CheckDotArrow", "OnEnterButtonPress", "Update", "ShowTimingResult"},
    "MatchService": {"SendSkillUse", "SendQteTap", "RequestQteChallenge",
                     "HandleQteChallenge"},
    "WsMatchClient": {"SendSkillUse", "SendQteTap", "RequestQteChallenge"},
    "ChatService": {"SendMatchSkillUse", "SendMatchQteStart", "SendMatchQteTap",
                    "SendMatchQteEvent", "SendWebSocketMessage"},
    "AuditionInput": {"Poll"},
    "AuditionStage": {"PressDir", "TapBar", "Build", "_BuildOneButton_b__0"},
    "AuditionRunner": {"_Run_b__0", "RelayQte", "Grade"},
}


def main(prefix="audition_qte_b4", title="QTE / Audition V3, 1.7.4-b4 static native evidence", include_qte_coroutines=True):
    digest = hashlib.sha256(BINARY.read_bytes()).hexdigest()
    if digest != EXPECTED:
        raise SystemExit(f"BUILD_MISMATCH: {digest}")
    pe = pefile.PE(str(BINARY), fast_load=True)
    base = pe.OPTIONAL_HEADER.ImageBase
    amap = json.loads((REVERSE / "il2cpp.json").read_text(encoding="utf-8-sig"))["addressMap"]
    labels = defaultdict(list)
    for kind, entries in amap.items():
        for item in entries:
            if not isinstance(item, dict) or "virtualAddress" not in item:
                continue
            rva = int(item["virtualAddress"], 16) - base
            if kind == "stringLiterals":
                label = "STRING " + repr(item["string"])
            elif kind in ("methodDefinitions", "constructedGenericMethods"):
                label = item.get("group", "") + " :: " + item.get("dotNetSignature", "")
            elif kind == "methodInfoPointers":
                label = "METHODINFO " + item.get("dotNetSignature", "")
            elif kind == "typeInfoPointers":
                label = "TYPEINFO " + item.get("dotNetType", "")
            else:
                continue
            if label not in labels[rva]:
                labels[rva].append(label)

    ranges = {}
    selected = {}
    csroot = REVERSE / "cs/Assembly-CSharp"
    for typename, names in SELECT.items():
        paths = list(csroot.rglob(typename + ".cs"))
        if len(paths) != 1:
            raise SystemExit(f"DECLARATION_AMBIGUOUS: {typename}")
        for line in paths[0].read_text(encoding="utf-8-sig").splitlines():
            match = re.search(r"\b(\w+)\([^;]*\); // (0x[\dA-Fa-f]+)-(0x[\dA-Fa-f]+)", line)
            if not match:
                continue
            name, va, end = match.groups()
            start, stop = int(va, 16) - base, int(end, 16) - base
            ranges[start] = stop
            if name in names:
                selected[start] = (stop, f"{typename}.{name}")
    for item in amap["methodDefinitions"]:
        group = item.get("group", "")
        if item.get("dotNetSignature") != "Boolean MoveNext()":
            continue
        if include_qte_coroutines and (("CardUI" in group and "<HandleDotSkillSequence>" in group) or "AuditionRunner+<Run>" in group):
            start = int(item["virtualAddress"], 16) - base
            selected[start] = (ranges[start], group + " :: MoveNext")

    decoder = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
    decoder.detail = True
    out = [title,
           "GameAssembly.dll SHA256: " + digest,
           "All instruction addresses and direct branch operands are module-relative RVAs.",
           "No runtime execution, network requests, or game writes."]
    summary = []
    for start, (stop, name) in sorted(selected.items()):
        heading = f"{name} RVA 0x{start:X}..0x{stop:X}"
        out.extend(["", heading])
        summary.extend(["", heading])
        for ins in decoder.disasm(pe.get_data(start, stop - start), start):
            annotations = []
            for op in ins.operands:
                target = None
                if op.type == X86_OP_IMM:
                    target = op.imm
                elif op.type == X86_OP_MEM and op.mem.base == X86_REG_RIP:
                    target = ins.address + ins.size + op.mem.disp
                if target in labels:
                    annotations.extend(labels[target][:4])
            note = " | ".join(annotations)
            line = f"{ins.address:08X} {ins.mnemonic:8s} {ins.op_str}" + (" ; " + note if note else "")
            out.append(line)
            if (ins.mnemonic in ("call", "jmp") and note) or "STRING " in note or "METHODINFO " in note:
                summary.append(line)
    for filename, lines in [(prefix + "_native.txt", out), (prefix + "_calls.txt", summary)]:
        target = ROOT / "reference" / filename
        target.write_text("\n".join(lines) + "\n", encoding="utf-8")
        print(f"{filename}: {len(lines)} lines; {len(selected)} method bodies")


if __name__ == "__main__":
    main()
