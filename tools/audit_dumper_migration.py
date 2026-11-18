"""Audit Dumper -> Dumper builds against a preserved production-source snapshot.

File reads only. The output supplies evidence, never runtime/input authority.
TypeInfo symbols and managed fields retain exact ownership and static qualifiers.
"""
from __future__ import annotations

import argparse
import ast
import bisect
import json
from pathlib import Path
import re
import struct

from tools.audit_game_update import sha
from tools.audit_dumper_update import compare_fields
from tools.audit_dumper_semantics import flat_cpp_layout, normalized_instructions
from tools.reverse_exports import dumper_types, dumper_script, unique


# Explicit field identities added since the B15 inventory, including statics.
EXTRA_FIELDS = {
    "galaxy_skill_phase.py": ("MatchPlayerSnapshotDTO", {
        "SKILL_PHASE_NEXT_OFFSET": "skillPhaseNext",
        "SKILL_PHASE_MAX_OFFSET": "skillPhaseMax",
        "SKILL_PHASE_CARD_ID_OFFSET": "skillPhaseCardId"}),
    "player_stats.py": ("Active.PlayerStats", {
        "PLAYER_STATS_ACTOR_OFFSET": "actorNumber", "PLAYER_STATS_CURRENT_HP_OFFSET": "currentHP",
        "PLAYER_STATS_MAX_HP_OFFSET": "maxHP", "PLAYER_STATS_CURRENT_MANA_OFFSET": "currentMana",
        "PLAYER_STATS_MAX_MANA_OFFSET": "maxMana", "PLAYER_STATS_CURRENT_POWER_OFFSET": "currentPower",
        "PLAYER_STATS_MAX_POWER_OFFSET": "maxPower", "PLAYER_STATS_ATTACK_OFFSET": "attack",
        "PLAYER_STATS_SHIELD_OFFSET": "shield"}),
    "dispatcher_chat_roots.py": ("UnityMainThreadDispatcher", {
        "DISPATCHER_STATIC_INSTANCE_OFFSET": "_instance",
        "DISPATCHER_STATIC_QUEUE_OFFSET": "_executionQueue",
        "DISPATCHER_DRAIN_BUFFER_OFFSET": "_drainBuffer"}),
}
STATIC_FIELDS = {
    "MATCH_HOST_STATE_STATIC_OFFSET": ("MatchHost", "_State_k__BackingField"),
    "MATCH_HOST_CURRENT_RIG_STATIC_OFFSET": ("MatchHost", "_CurrentRig_k__BackingField"),
    "MATCH_SCENE_LOADER_IS_LOADING_STATIC_OFFSET": ("MatchSceneLoader", "_isLoading"),
    "MATCH_SCENE_LOADER_IS_UNLOADING_STATIC_OFFSET": ("MatchSceneLoader", "_isUnloading"),
    "HUB_SUSPEND_MANAGER_IS_SUSPENDED_STATIC_OFFSET": ("HubSuspendManager", "_IsSuspended_k__BackingField"),
    "TURN_ANNOUNCER_BLOCKING_STATIC_OFFSET": ("TurnAnnouncer", "_blocking"),
    "TURN_ANNOUNCER_BLOCK_DEADLINE_STATIC_OFFSET": ("TurnAnnouncer", "_blockDeadline"),
}


def constants(source):
    result = {}
    for path in sorted(Path(source).glob("*.py")):
        tree = ast.parse(path.read_bytes())
        # Module-level constants only: no guessed binding from function locals.
        for node in tree.body:
            if isinstance(node, ast.Assign):
                for target in node.targets:
                    if isinstance(target, ast.Name):
                        try:
                            result[path.name, target.id] = ast.literal_eval(node.value)
                        except (ValueError, TypeError):
                            pass
    return result


def audit(old, new, prior_path, source, install):
    import pefile
    from capstone import Cs, CS_ARCH_X86, CS_MODE_64
    from capstone.x86 import X86_OP_MEM, X86_REG_RIP

    old, new, install = map(Path, (old, new, install))
    prior = json.loads(Path(prior_path).read_text("utf-8"))
    a, b = [dumper_types(str(p)) for p in (old, new)]
    oscript, nscript = [dumper_script(str(p)) for p in (old, new)]
    values = constants(source)
    callbacks = [r for r in nscript["ScriptMethod"] if re.fullmatch(
        r"ChatService\.<>c__DisplayClass\d+_0\$\$<OnWebSocketMessage>b__0", r["Name"])]
    if len(callbacks) != 1:
        raise ValueError("WebSocket closure identity ambiguous")
    closure = callbacks[0]["Name"].split("$$")[0]
    roots = []
    for (module, name), value in values.items():
        if not name.endswith("TYPE_INFO_RVA") or type(value) is not int:
            continue
        matches = [r for r in oscript["ScriptMetadata"]
                   if r["Address"] == value and r["Name"].endswith("_TypeInfo")]
        if len(matches) != 1:
            raise ValueError("Baseline TypeInfo identity ambiguous: " + module + ":" + name)
        prev = matches[0]
        newname = closure + "_TypeInfo" if name == "CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA" else prev["Name"]
        curr = unique(nscript["ScriptMetadata"], newname)
        if curr["Signature"] != prev["Signature"] and name != "CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA":
            raise ValueError("TypeInfo signature changed: " + name)
        roots.append(dict(module=module, constant=name, old=value, new=curr["Address"],
                          old_export=prev, export=curr))
    oldclosure = next(r["old_export"]["Name"].removesuffix("_TypeInfo") for r in roots
                      if r["constant"] == "CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA")

    bindings = {(r["module"], r["constant"]): (r["klass"], r["field"]) for r in prior["fields"]}
    for module, (owner, members) in EXTRA_FIELDS.items():
        for name, member in members.items():
            bindings[module, name] = owner, member
    for name, binding in STATIC_FIELDS.items():
        bindings["il2cpp_external.py", name] = binding
    for module, name, owner, member in [
        ("player_stats.py", "MATCH_PLAYER_SNAPSHOT_ACTOR_OFFSET", "MatchPlayerSnapshotDTO", "actorNumber"),
        ("boss_lobby_runtime.py", "MANAGER_QUANG_TRUONG_INSTANCE_STATIC_OFFSET", "ManagerQuangTruong", "Instance"),
        ("boss_lobby_runtime.py", "UI_PANEL_MANAGER_OPEN_ORDER_OFFSET", "UIPanelManager", "_openOrder"),
        ("play_reminder.py", "CANVAS_OFFSET", "Poki.Health.PlayReminder", "_canvas"),
        ("play_reminder.py", "REMINDER_COUNT_OFFSET", "Poki.Health.PlayReminder", "_remindedCount"),
        ("dispatcher_chat_roots.py", "CLOSURE_MESSAGE_OFFSET", oldclosure, "message"),
        ("dispatcher_chat_roots.py", "CLOSURE_JSON_OFFSET", oldclosure, "json"),
        ("il2cpp_layout.py", "BOARD_CELL_COL_OFFSET", "BoardCellDTO", "col"),
        ("il2cpp_layout.py", "BOARD_CELL_ROW_OFFSET", "BoardCellDTO", "row"),
        ("il2cpp_layout.py", "BOARD_CELL_TAG_OFFSET", "BoardCellDTO", "tag"),
    ]:
        bindings[module, name] = owner, member
    fields, missing_source = [], []
    for (module, name), (owner, member) in sorted(bindings.items()):
        if (module, name) not in values:
            missing_source.append(dict(module=module, constant=name))
            continue
        prev = a["Assembly-CSharp", owner]["fields"][member]
        newowner = closure if owner.startswith("ChatService.<>c__DisplayClass") else owner
        curr = b["Assembly-CSharp", newowner]["fields"].get(member)
        if values[module, name] != prev["offset"]:
            raise ValueError("Source is not the old build: " + module + ":" + name)
        if curr is None or curr["type"] != prev["type"]:
            raise ValueError("Managed field identity/type changed: " + owner + "." + member)
        fields.append(dict(module=module, constant=name, klass=newowner, field=member,
                           old=prev, new=curr, equal=prev == curr))
    layouts = []
    opaque = []
    for key in sorted(a.keys() & b.keys()):
        if a[key]["fields"] is None or b[key]["fields"] is None:
            opaque.append(key)
            continue
        diff = compare_fields(a[key]["fields"], b[key]["fields"])
        if not diff["equal"]:
            layouts.append(dict(identity=key, **diff))
    selected = sorted({r["klass"] for r in fields} | {
        "MatchHost", "MatchSceneLoader", "HubSuspendManager", "TurnAnnouncer",
        "ActivePVP.PlayerStats", "UnityMainThreadDispatcher.PendingAction",
        "ManagerChinhPhuc.<>c__DisplayClass41_0", "RoomStartState.Phase"})
    selected_layouts = {n: compare_fields(a["Assembly-CSharp", oldclosure if n == closure else n]["fields"],
                                        b["Assembly-CSharp", n]["fields"]) for n in selected}
    enums = []
    for key in sorted(a.keys() & b.keys()):
        if a[key]["kind"] == "enum":
            vals = lambda row: re.findall(r"public const \S+ (\w+) = ([^;]+);", row["text"])
            av, bv = vals(a[key]), vals(b[key])
            enums.append(dict(identity=key, old=av, new=bv, equal=av == bv))
    headers = [(p / "il2cpp.h").read_text("utf-8-sig") for p in (old, new)]
    abi = {}
    for name in prior["abi"]:
        # Prior artifacts retain the exact header-relative base used there.
        offset = 16 if name == "System_String_Fields" else 0
        av, bv = [flat_cpp_layout(h, name, offset) for h in headers]
        abi[name] = dict(equal=av["fields"] == bv["fields"] and av["size"] == bv["size"], old=av, new=bv)
    cpp_fields = [dict(re.findall(r"\b(\w+_Fields)\s*(?::[^\{]*)?\s*\{([^}]+)\};", h)) for h in headers]
    closed_contracts = {}
    for name in sorted(cpp_fields[0].keys() & cpp_fields[1].keys()):
        if name.startswith(("System_Collections_Generic_", "System_Nullable_", "System_ValueTuple_")):
            av, bv = [re.sub(r"\s+", " ", c[name]).strip() for c in cpp_fields]
            closed_contracts[name] = dict(equal=av == bv, old=av, new=bv)
    json_contracts = {name: compare_fields(a["Newtonsoft.Json", "Newtonsoft.Json.Linq." + name]["fields"],
        b["Newtonsoft.Json", "Newtonsoft.Json.Linq." + name]["fields"]) for name in
        ("JArray", "JObject", "JProperty", "JValue", "JPropertyKeyedCollection")}
    for t in (a, b):
        parent = t["Newtonsoft.Json", "Newtonsoft.Json.Linq.JProperty"]
        nested = t["Newtonsoft.Json", "JProperty.JPropertyList"]
        if nested["index"] != parent["index"] + 1 or nested["namespace"]:
            raise ValueError("JPropertyList nested ownership not proven")
    json_contracts["JProperty.JPropertyList"] = compare_fields(
        a["Newtonsoft.Json", "JProperty.JPropertyList"]["fields"], b["Newtonsoft.Json", "JProperty.JPropertyList"]["fields"])
    hud_constants = [re.findall(r"public const (\w+) (\w+) = ([^;]+);", t["Assembly-CSharp", "Poki.MatchHud.MatchHudV2"]["text"]) for t in (a, b)]

    paths = [install / "GameAssembly.dll", install / "UnityPlayer.dll", install / "PetPuzzle-1.7.4.exe",
             install / "PetPuzzle-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat",
             new / "dump.cs", new / "script.json", new / "il2cpp.h"]
    identities = [dict(path=str(p.resolve()), bytes=p.stat().st_size, sha256=sha(p)) for p in paths]
    game, unity, launcher = [pefile.PE(str(paths[i]), fast_load=True) for i in (0, 1, 2)]
    pe_identity = lambda pe: dict(machine=pe.FILE_HEADER.Machine, timestamp=pe.FILE_HEADER.TimeDateStamp,
        image_base=pe.OPTIONAL_HEADER.ImageBase, size_of_image=pe.OPTIONAL_HEADER.SizeOfImage)
    addresses = sorted(set(nscript["Addresses"]))
    md = Cs(CS_ARCH_X86, CS_MODE_64); md.detail = True
    anchors = {}
    for name in dict.fromkeys([*prior["anchors"], callbacks[0]["Name"]]):
        if name in prior["anchors"] and "instructions" not in prior["anchors"][name]:
            anchors[name] = dict(status="UNKNOWN_NO_PRIOR_NATIVE_BODY", prior=prior["anchors"][name])
            continue
        if name.startswith("ChatService.<>c__DisplayClass"):
            name = callbacks[0]["Name"]
        row = unique(nscript["ScriptMethod"], name)
        start = row["Address"]; stop = addresses[bisect.bisect_right(addresses, start)]
        instructions = []
        for ins in md.disasm(game.get_data(start, stop - start), start):
            rip = [ins.address + ins.size + op.mem.disp for op in ins.operands
                   if op.type == X86_OP_MEM and op.mem.base == X86_REG_RIP]
            item = dict(rva=ins.address, bytes=ins.bytes.hex(), mnemonic=ins.mnemonic,
                        op=ins.op_str, rip_targets=rip)
            if rip and ins.mnemonic in {"movss", "mulss", "divss", "comiss", "ucomiss", "addss", "subss", "maxss", "minss"}:
                item["float"] = format(struct.unpack("<f", game.get_data(rip[0], 4))[0], ".6g")
            instructions.append(item)
        previous = prior["anchors"].get(name.replace(closure, oldclosure))
        anchors[name] = dict(export=row, instructions=instructions,
            normalized_equal=bool(previous and "instructions" in previous and
                normalized_instructions(previous["instructions"]) == normalized_instructions(instructions)))
    bridge = anchors["UnityEngine.Component$$get_gameObject"]["instructions"]
    load = next(r for r in bridge if r["op"].startswith("rax, qword ptr [rip"))
    store = next(r for r in bridge if r["op"].startswith("qword ptr [rip") and r["op"].endswith(", rax"))
    if load["rip_targets"] != store["rip_targets"] or len(load["rip_targets"]) != 1:
        raise ValueError("Component cache load/store mismatch")
    literal = next(r for r in bridge if r["op"].startswith("rcx, [rip") and
        game.get_data(r["rip_targets"][0], 96).startswith(b"UnityEngine.Component::get_gameObject_Injected"))
    rows = anchors["UnityEngine.Object.MarshalledUnityObject$$Unmarshal<__Canon>"]["instructions"]
    tag = next(r for r in rows if r["mnemonic"] == "test" and r["op"] == "bl, 1")
    signature = game.get_data(tag["rva"], 24)
    if paths[0].read_bytes().count(signature) != 1:
        raise ValueError("Unmarshal signature is not unique")
    if not any(r["mnemonic"] == "jmp" and r["op"] == hex(anchors[
        "UnityEngine.Object.MarshalledUnityObject$$Unmarshal<__Canon>"]["export"]["Address"]) for r in bridge):
        raise ValueError("Component wrapper does not reach named unmarshal")
    for name in ("Active$$get_Instance", "Board$$get_Instance"):
        if not any(r["op"] == "rax, qword ptr [rax + 0x98]" for r in anchors[name]["instructions"]):
            raise ValueError("Il2CppClass.static_fields ABI changed")
    native_signatures = []
    for rva, code in values["native_card_ui.py", "_NATIVE_SIGNATURES"]:
        equal = unity.get_data(rva, len(bytes.fromhex(code))).hex() == code
        if not equal:
            raise ValueError("Unity native signature changed: " + hex(rva))
        native_signatures.append(dict(rva=rva, signature=code, equal=True))
    return dict(mode="FILES_ONLY_NO_INPUT_NO_GAME_WRITES", identities=identities,
        pe=pe_identity(game), pe_files={"GameAssembly.dll": pe_identity(game),
            "UnityPlayer.dll": pe_identity(unity), "PetPuzzle-1.7.4.exe": pe_identity(launcher)},
        metadata_header=struct.unpack("<II", paths[3].read_bytes()[:8]),
        app_info=(install / "PetPuzzle-1.7.4_Data/app.info").read_text("utf-8-sig"),
        typeinfo=roots, fields=fields, missing_source_bindings=missing_source, layout_changes=layouts,
        selected_layouts=selected_layouts, abi=abi, closed_contracts=closed_contracts,
        json_contracts=json_contracts, hud_constants=dict(equal=hud_constants[0] == hud_constants[1], old=hud_constants[0], new=hud_constants[1]),
        enums=enums, anchors=anchors,
        added_types=sorted(b.keys() - a.keys()), removed_types=sorted(a.keys() - b.keys()),
        opaque_types=opaque, compared_types=len(a.keys() & b.keys()),
        geometry=[dict(method=n, equal=anchors[n]["normalized_equal"]) for n in
            ("Poki.MatchHud.MatchHudV2$$SolveBoard", "Board$$GetCellBaseWorldPosition")],
        native_signatures=native_signatures, component_cache_rva=load["rip_targets"][0],
        component_literal_rva=literal["rip_targets"][0], unmarshal_signature=[tag["rva"], signature.hex()],
        limitations=["Instruction normalization ignores external call destinations; not whole-method equivalence.",
                     "Export equality is not proof of live screen geometry, ACK, QTE or result acceptance."])


def main():
    p = argparse.ArgumentParser(description=__doc__)
    for name in ("old", "new", "prior-audit", "source", "install", "output"):
        p.add_argument("--" + name, type=Path, required=True)
    args = p.parse_args()
    result = audit(args.old, args.new, args.prior_audit, args.source, args.install)
    with args.output.open("x", encoding="utf-8") as stream:
        json.dump(result, stream, ensure_ascii=False, indent=2)
    print(json.dumps(dict(typeinfo=len(result["typeinfo"]), fields=len(result["fields"]),
        moved_fields=[r["constant"] for r in result["fields"] if not r["equal"]],
        changed_types=len(result["layout_changes"]), changed_enums=[r["identity"] for r in result["enums"] if not r["equal"]],
        geometry=result["geometry"], component_cache=hex(result["component_cache_rva"]),
        unmarshal=hex(result["unmarshal_signature"][0]))))


if __name__ == "__main__":
    main()
