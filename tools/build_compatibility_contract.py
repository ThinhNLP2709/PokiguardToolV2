"""Maintainer-only compiler for the reviewed B17 contract shipped in the app."""
from __future__ import annotations
import argparse
import json
from pathlib import Path

from pokiguard_v2.compatibility.audit import NativeAudit, enum_contract, header_layouts, type_contract
from pokiguard_v2.compatibility.exports import dumper_script, dumper_types
from pokiguard_v2.compatibility.profile import atomic_json, contract_path, install_identity


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--reverse", type=Path, required=True)
    parser.add_argument("--audit", type=Path, required=True)
    parser.add_argument("--exe", type=Path, required=True)
    parser.add_argument("--output", type=Path, default=contract_path())
    args = parser.parse_args()
    proof = json.loads(args.audit.read_text("utf-8"))
    types, script = dumper_types(str(args.reverse)), dumper_script(str(args.reverse))
    keys = {("Assembly-CSharp", name) for name in proof["selected_layouts"]}
    keys.update(("Newtonsoft.Json", "Newtonsoft.Json.Linq." + name) for name in
                ("JArray", "JObject", "JProperty", "JValue", "JPropertyKeyedCollection"))
    keys.add(("Newtonsoft.Json", "JProperty.JPropertyList"))
    keys.add(("Assembly-CSharp", "Poki.MatchHud.MatchHudV2"))
    for key in types:
        if key[0] == "Assembly-CSharp" and key[1] in {
                "BoardCellDTO", "BoardController", "RoomCoopV2Refs", "RoomStartState",
                "ManagerChinhPhuc", "ChinhPhucDataService", "Dot", "CardUI", "FusionCardUI"}:
            keys.add(key)
        if key[1] in {"UnityEngine.UI.Button", "UnityEngine.UI.Selectable", "UnityEngine.UI.CanvasScaler"}:
            keys.add(key)
    roots = [{"rva": r["new"], "name": r["export"]["Name"],
              "signature": r["export"]["Signature"]} for r in proof["typeinfo"]]
    names = {name for name, row in proof["anchors"].items() if row.get("instructions")}
    names.add("Poki.Health.PlayReminder$$get_IsOpen")
    # Protect the HUD setup as well as the two reviewed coordinate routines.
    names.update(r["Name"] for r in script["ScriptMethod"] if r["Name"].startswith("Poki.MatchHud.MatchHudV2$$"))
    native = NativeAudit(args.exe.parent / "GameAssembly.dll", script)
    try:
        methods = {name: native.fingerprint(name) for name in sorted(names)}
        cache, unmarshal, signature = native.bridge()
    finally:
        native.close()
    contract = {"schema": 1, "baseline": "PetPuzzle 1.7.4-b17", "identity": install_identity(args.exe),
                "roots": roots, "type_keys": sorted(keys), "types": type_contract(types, sorted(keys)),
                "header": header_layouts(args.reverse), "enums": enum_contract(types),
                "native_methods": methods, "native_bridge": [cache, unmarshal, signature],
                "native_signatures": proof["native_signatures"]}
    atomic_json(args.output, contract)
    print(f"Wrote {args.output}: {len(roots)} roots, {len(keys)} types, {len(methods)} native routines")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
