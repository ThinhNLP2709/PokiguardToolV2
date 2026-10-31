"""File-only evidence for a game update; never attaches or changes runtime code.

Compare Inspector exports by symbol/field identity, not by an address delta.
The report is an audit aid, not permission to enable an unverified build.
"""
from __future__ import annotations

import argparse
import ast
import hashlib
import json
from pathlib import Path
import re


FIELD = re.compile(r"\s*(?:public|private|internal|protected) (?!const )(.+?) (\w+); // (0x[0-9A-Fa-f]+)$")
PREFIXES = {
    "MATCH_SERVICE_": "MatchService", "CHAT_SERVICE_": "ChatService",
    "CHAT_MESSAGE_": "ChatMessageDTO", "BOARD_WS_APPLIER_": "BoardWsApplier",
    "MANAGER_MATCH_": "ManagerMatch", "BOARD_": "Board", "ACTIVE_": "Active",
    "MQT_": "ManagerQuangTruong", "MANAGER_ROOM_": "ManagerRoom",
    "MANAGER_BOSS_": "ManagerBoss", "MANAGER_CHINH_PHUC_": "ManagerChinhPhuc",
    "CHINH_PHUC_DATA_SERVICE_": "ChinhPhucDataService",
    "ROOM_COOP_V2_REFS_": "RoomCoopV2Refs", "ROOM_COOP_V2_": "RoomCoopV2View",
    "WS_": "WsRoomService", "ROOM_": "RoomDTO", "BOSS_ITEM_": "BossItem",
    "WORLD_BOSS_": "WorldBossDTO", "CARD_DATA_": "CardData", "CARD_UI_": "CardUI",
    "FUSION_CARD_UI_": "FusionCardUI", "PET_USER_": "PetUserDTO",
    "PET_": "PetEnemyDTO", "GROUP_": "GroupDTO", "DOT_": "Dot",
    "WS_COMBAT_BATCH_": "WsCombatBatch", "AUDITION_STAGE_": "PokiGuard/Audition/AuditionStage",
    "AUDITION_CHALLENGE_": "PokiGuard/Audition/AuditionChallenge",
}


def sha(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for data in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(data)
    return h.hexdigest()


def fields(path: Path) -> dict[str, dict]:
    """Top-level fields only; nested/compiler types need separate inspection."""
    result = {}
    for line in path.read_text(encoding="utf-8-sig").splitlines():
        if result and line.strip().startswith(("// Properties", "// Events", "// Nested", "// Constructors", "// Methods")):
            break
        m = FIELD.fullmatch(line)
        if m:
            result[m[2]] = {"type": m[1], "offset": int(m[3], 16)}
    return result


def address_map(path: Path) -> dict:
    return json.loads((path / "il2cpp.json").read_text(encoding="utf-8-sig"))["addressMap"]


def audit(old: Path, new: Path, source: Path, install: Path) -> dict:
    import pefile
    a, b = address_map(old), address_map(new)
    key = lambda x: tuple(x[n] for n in ("name", "type", "dotNetType"))
    lookup = {key(x): x for x in b["typeInfoPointers"]}
    prior = {int(x["virtualAddress"], 16) - 0x180000000: x for x in a["typeInfoPointers"]}
    roots, offsets = [], []
    for path in sorted(source.glob("*.py")):
        for node in ast.walk(ast.parse(path.read_text(encoding="utf-8-sig"))):
            if not isinstance(node, ast.Assign) or not isinstance(node.value, ast.Constant) or type(node.value.value) is not int:
                continue
            name, value = ast.unparse(node.targets[0]), node.value.value
            if value in prior:
                x = prior[value]; y = lookup.get(key(x))
                roots.append({"module": path.name, "constant": name, "old": value,
                              "new": int(y["virtualAddress"], 16)-0x180000000 if y else None, "symbol": x})
            if not name.endswith("_OFFSET"):
                continue
            prefix = next((p for p in sorted(PREFIXES, key=len, reverse=True) if name.startswith(p)), None)
            if not prefix:
                continue
            cls = PREFIXES[prefix]
            pa, pb = old/"cs/Assembly-CSharp"/(cls+".cs"), new/"cs/Assembly-CSharp"/(cls+".cs")
            if not pa.exists() or not pb.exists():
                continue
            fa, fb = fields(pa), fields(pb)
            candidates = [n for n, v in fa.items() if v["offset"] == value and "static " not in v["type"]]
            if len(candidates) == 1:
                member = candidates[0]; target = fb.get(member)
                offsets.append({"module": path.name, "constant": name, "class": cls, "field": member,
                                "old": value, "new": target["offset"] if target else None,
                                "old_type": fa[member]["type"], "new_type": target["type"] if target else None})
    diff = []
    for p in sorted((new/"cs/Assembly-CSharp").rglob("*.cs")):
        q = old/"cs/Assembly-CSharp"/p.relative_to(new/"cs/Assembly-CSharp")
        if q.exists():
            fa, fb = fields(q), fields(p)
            changes = {k: {"old": fa.get(k), "new": fb.get(k)} for k in sorted(fa.keys() | fb.keys()) if fa.get(k) != fb.get(k)}
            if changes:
                diff.append({"type": p.relative_to(new/"cs/Assembly-CSharp").as_posix(), "fields": changes})
    dll = install/"GameAssembly.dll"; pe = pefile.PE(str(dll), fast_load=False)
    imports = [{"dll": e.dll.decode(), "names": [x.name.decode() if x.name else f"ordinal:{x.ordinal}" for x in e.imports]}
               for e in getattr(pe, "DIRECTORY_ENTRY_IMPORT", [])]
    identities = []
    for p in (dll, install/"UnityPlayer.dll", install/"PetPuzzle-1.7.4.exe", install/"PetPuzzle-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat", new/"il2cpp.json", new/"il2cpp.h"):
        identities.append({"path": str(p.resolve()), "bytes": p.stat().st_size, "sha256": sha(p)})
    return {"mode": "FILES_ONLY_NO_PROCESS_OR_NETWORK", "identities": identities,
            "pe": {"machine": pe.FILE_HEADER.Machine, "timestamp": pe.FILE_HEADER.TimeDateStamp,
                   "image_base": pe.OPTIONAL_HEADER.ImageBase, "size_of_image": pe.OPTIONAL_HEADER.SizeOfImage},
            "typeinfo": roots, "offset_candidates": offsets, "top_level_layout_changes": diff,
            "imports": imports}


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--old", type=Path, required=True)
    parser.add_argument("--new", type=Path, required=True)
    parser.add_argument("--source", type=Path, default=Path("src/pokiguard_v2"))
    parser.add_argument("--install", type=Path, required=True)
    parser.add_argument("--output", type=Path, required=True)
    args = parser.parse_args()
    result = audit(args.old, args.new, args.source, args.install)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(result, indent=2, ensure_ascii=False), encoding="utf-8")
    print(json.dumps({"output": str(args.output), "typeinfo": len(result["typeinfo"]),
                      "unresolved_typeinfo": [x["constant"] for x in result["typeinfo"] if x["new"] is None],
                      "changed_offset_candidates": sum(x["old"] != x["new"] for x in result["offset_candidates"])}, indent=2))


if __name__ == "__main__":
    main()
