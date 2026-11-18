"""Audit the B15 compatibility delta against the local reverse and binary."""

import ast
import hashlib
import importlib
import json
from pathlib import Path
import unittest

from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
from tools.reverse_exports import dumper_script, dumper_types, unique


ROOT = Path(__file__).resolve().parents[1]
REVERSE = ROOT / "reverse/reverse_1.7.4-b15"
EVIDENCE = ROOT / "docs/artifacts/game_1_7_4_b15_20261105"
B15 = "18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea"
B14 = "33df13da565808a41d8268dafdf5702d736fc8fcb889515e57bda475528d2152"


@unittest.skipUnless(
    B15 in SUPPORTED_GAME_ASSEMBLY_SHA256 and (EVIDENCE / "static_audit.json").is_file(),
    "Local current B15 audit required",
)
class B15CompatibilityTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit = json.loads((EVIDENCE / "static_audit.json").read_text("utf-8"))

    def test_profile_binds_b15_and_rejects_b14(self):
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256, {B15})
        self.assertNotIn(B14, SUPPORTED_GAME_ASSEMBLY_SHA256)
        self.assertEqual(self.audit["metadata_header"], [0xFAB11BAF, 111])

    def test_all_named_roots_match_the_new_export(self):
        script = dumper_script(str(REVERSE))
        roots = self.audit["typeinfo"]
        self.assertEqual(len(roots), 39)
        for row in roots:
            export = unique(script["ScriptMetadata"], row["export"]["Name"])
            module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
            self.assertEqual(getattr(module, row["constant"]), export["Address"], row["constant"])
            self.assertNotEqual(row["old"], export["Address"], row["constant"])
        self.assertNotEqual(
            unique(script["ScriptMetadata"], "Active.PlayerStats_TypeInfo")["Address"],
            unique(script["ScriptMetadata"], "ActivePVP.PlayerStats_TypeInfo")["Address"],
        )

    def test_consumed_field_offsets_and_qte_read_span(self):
        from pokiguard_v2 import pet_qte_observer as qte

        types = dumper_types(str(REVERSE))
        fields = self.audit["fields"]
        self.assertEqual(len(fields), 257)
        self.assertEqual(sum(not row["equal"] for row in fields), 9)
        for row in fields:
            field = types["Assembly-CSharp", row["klass"]]["fields"][row["field"]]
            self.assertEqual(field["type"], row["old"]["type"])
            module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
            self.assertEqual(getattr(module, row["constant"]), field["offset"], row["constant"])
        self.assertEqual(qte.CHAT_MESSAGE_QTE_RESULT_READ_SIZE, 0x1D0)
        self.assertEqual(
            qte.CHAT_MESSAGE_QTE_RESULT_READ_SIZE, qte.CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET + 16
        )

    def test_same_unity_layout_and_relocated_native_bridge(self):
        import pefile
        from pokiguard_v2 import native_card_ui as native

        files = {Path(row["path"]).name: row for row in self.audit["identities"]}
        game = Path(files["GameAssembly.dll"]["path"])
        unity = Path(files["UnityPlayer.dll"]["path"])
        if not game.is_file() or not unity.is_file():
            self.skipTest("Local B15 installation required")
        self.assertEqual(hashlib.sha256(game.read_bytes()).hexdigest(), B15)
        self.assertEqual(hashlib.sha256(unity.read_bytes()).hexdigest(),
                         "2584be0698de516d555042c682d11a266fa3c143fa5e1194976e7608833eba90")
        self.assertEqual(native._COMPONENT_GO_ICALL, self.audit["component_cache_rva"])
        self.assertEqual(native._UNMARSHAL_SIGNATURE, tuple(self.audit["unmarshal_signature"]))
        rva, code = native._UNMARSHAL_SIGNATURE
        self.assertEqual(pefile.PE(str(game), fast_load=True).get_data(rva, len(bytes.fromhex(code))).hex(), code)

    def test_board_geometry_closed_abi_and_consumed_room_fields(self):
        self.assertTrue(all(row["equal"] for row in self.audit["geometry"]))
        self.assertTrue(all(row["equal"] for row in self.audit["abi"].values()))
        for owner in ("Board", "Dot", "BoardCellDTO", "RoomCoopV2Refs", "RoomCoopV2View",
                      "ManagerRoom", "ManagerChinhPhuc", "Poki.Health.PlayReminder", "MatchService", "CardUI"):
            self.assertTrue(self.audit["selected_layouts"][owner]["equal"], owner)

    def test_runtime_migration_only_changes_verified_constants(self):
        migration = json.loads((EVIDENCE / "constant_migration.json").read_text("utf-8"))
        before = json.loads((EVIDENCE / "before_source.json").read_text("utf-8"))["files"]
        # Compare the two manifests from the migration itself. The shape
        # check below still audits the current runtime layout modules.
        migrated = json.loads((EVIDENCE / "source_manifest.json").read_text("utf-8"))["files"]
        protected = {name for name in before if name.startswith(("src/", "tools/"))}
        expected = {"src/pokiguard_v2/" + name for name in migration}
        self.assertEqual({name for name in protected if before[name] != migrated.get(name)}, expected)

        def shape(path, constants):
            tree = ast.parse(path.read_bytes())
            for node in ast.walk(tree):
                if isinstance(node, (ast.Module, ast.ClassDef, ast.FunctionDef, ast.AsyncFunctionDef)):
                    if ast.get_docstring(node) is not None:
                        node.body = node.body[1:]
                if isinstance(node, ast.Assign) and any(
                    isinstance(target, ast.Name) and target.id in constants for target in node.targets
                ):
                    node.value = ast.Constant(None)
            return ast.dump(tree, include_attributes=False)

        for module, constants in migration.items():
            name = "src/pokiguard_v2/" + module
            previous = EVIDENCE / "before" / name
            self.assertEqual(hashlib.sha256(previous.read_bytes()).hexdigest(), before[name])
            self.assertEqual(shape(previous, constants), shape(ROOT / name, constants), name)


if __name__ == "__main__":
    unittest.main()
