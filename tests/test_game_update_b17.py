"""Exact B17 profile and independent Dumper/native migration evidence."""
import ast
import hashlib
import importlib
import json
from pathlib import Path
import unittest

from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
from tools.reverse_exports import dumper_script, dumper_types, unique

ROOT = Path(__file__).resolve().parents[1]
REVERSE = ROOT / "reverse/reverse_1.7.4-b17"
EVIDENCE = ROOT / "docs/artifacts/game_1_7_4_b17_20261118"
B17 = "bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7"
B16 = "c69c95c4c6bd0cbc28181033ccd2a974e085f47055f123627e0b3a33e1595f3a"


@unittest.skipUnless(B17 in SUPPORTED_GAME_ASSEMBLY_SHA256, "B17 is not the active runtime profile")
class B17ProfileTests(unittest.TestCase):
    def test_only_the_exact_b17_build_is_enabled(self):
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256, frozenset({B17}))
        self.assertNotIn(B16, SUPPORTED_GAME_ASSEMBLY_SHA256)

    def test_native_anchors_are_pinned_individually(self):
        from pokiguard_v2 import native_card_ui as native
        self.assertEqual(native._COMPONENT_GO_ICALL, 0x4630EE0)
        self.assertEqual(native._UNMARSHAL_SIGNATURE,
            (0x1C7201C, "f6c301740d488bcbe8f7945dfe488bd8eb03488b1b4885db"))


@unittest.skipUnless(B17 in SUPPORTED_GAME_ASSEMBLY_SHA256 and (REVERSE / "script.json").is_file() and
    (EVIDENCE / "static_audit_verified.json").is_file(), "Local B17 reverse audit required")
class B17ContractTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit = json.loads((EVIDENCE / "static_audit_verified.json").read_text("utf-8"))
        cls.script = dumper_script(str(REVERSE))
        cls.types = dumper_types(str(REVERSE))

    def test_all_runtime_roots_match_exact_export_identity(self):
        self.assertEqual(len(self.audit["typeinfo"]), 39)
        self.assertTrue(all(r["old"] != r["new"] for r in self.audit["typeinfo"]))
        for row in self.audit["typeinfo"]:
            with self.subTest(constant=row["constant"]):
                export = unique(self.script["ScriptMetadata"], row["export"]["Name"])
                self.assertEqual(export, row["export"])
                self.assertEqual(export["Signature"], row["old_export"]["Signature"])
                module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
                self.assertEqual(getattr(module, row["constant"]), export["Address"])

    def test_coop_and_pvp_stats_are_different_classes(self):
        from pokiguard_v2.il2cpp_external import ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        coop = unique(self.script["ScriptMetadata"], "Active.PlayerStats_TypeInfo")
        pvp = unique(self.script["ScriptMetadata"], "ActivePVP.PlayerStats_TypeInfo")
        self.assertEqual(ACTIVE_PLAYER_STATS_TYPE_INFO_RVA, coop["Address"])
        self.assertNotEqual(coop["Address"], pvp["Address"])

    def test_all_consumed_fields_retain_exact_type_offset_and_static_owner(self):
        self.assertEqual(len(self.audit["fields"]), 289)
        self.assertEqual(self.audit["missing_source_bindings"], [])
        self.assertTrue(all(r["equal"] for r in self.audit["fields"]))
        for row in self.audit["fields"]:
            with self.subTest(constant=row["constant"]):
                field = self.types["Assembly-CSharp", row["klass"]]["fields"][row["field"]]
                self.assertEqual(field, row["new"])
                module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
                self.assertEqual(getattr(module, row["constant"]), field["offset"])
        self.assertTrue(all(r["equal"] for r in self.audit["selected_layouts"].values()))
        from pokiguard_v2 import pet_qte_observer as qte
        self.assertGreaterEqual(qte.CHAT_MESSAGE_QTE_RESULT_READ_SIZE,
                                qte.CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET + 16)

    def test_closed_container_json_and_domain_contracts(self):
        self.assertEqual(len(self.audit["closed_contracts"]), 2414)
        self.assertEqual(len(self.audit["enums"]), 1722)
        self.assertTrue(all(r["equal"] for r in self.audit["abi"].values()))
        self.assertTrue(all(r["equal"] for r in self.audit["closed_contracts"].values()))
        self.assertTrue(all(r["equal"] for r in self.audit["json_contracts"].values()))
        self.assertTrue(all(r["equal"] for r in self.audit["enums"]))
        self.assertTrue(self.audit["hud_constants"]["equal"])
        self.assertTrue(all(r["equal"] for r in self.audit["geometry"]))

    def test_named_websocket_closure_keeps_the_message_role(self):
        name = "ChatService.<>c__DisplayClass328_0$$<OnWebSocketMessage>b__0"
        self.assertEqual(unique(self.script["ScriptMethod"], name), self.audit["anchors"][name]["export"])
        self.assertTrue(self.audit["anchors"][name]["normalized_equal"])
        fields = self.types["Assembly-CSharp", "ChatService.<>c__DisplayClass328_0"]["fields"]
        self.assertEqual(fields["message"], dict(type="ChatMessageDTO", offset=0x20))
        self.assertEqual(fields["json"], dict(type="string", offset=0x18))

    def test_consumed_native_semantics_and_seals_match_b16(self):
        contracts = json.loads((EVIDENCE / "runtime_contracts.json").read_text("utf-8"))
        comparisons = [r for r in contracts["native_comparisons_to_b16"].values() if "normalized_equal" in r]
        self.assertEqual(len(comparisons), 26)
        self.assertTrue(all(r["normalized_equal"] and r["symbolic_references_equal"] for r in comparisons))
        self.assertEqual(contracts["missing_requested_symbols"], [])
        self.assertTrue(contracts["closure_slot_used_by_websocket_handler"])
        self.assertTrue(all(r["matches_production"] for r in contracts["mega_patterns"].values()))

    def test_native_signatures_match_exact_installed_build(self):
        import pefile
        from pokiguard_v2 import native_card_ui as native
        self.assertEqual(native._COMPONENT_GO_ICALL, self.audit["component_cache_rva"])
        self.assertEqual(native._UNMARSHAL_SIGNATURE, tuple(self.audit["unmarshal_signature"]))
        identities = {Path(r["path"]).name: r for r in self.audit["identities"]}
        game = Path(identities["GameAssembly.dll"]["path"])
        unity = Path(identities["UnityPlayer.dll"]["path"])
        if not game.is_file() or hashlib.sha256(game.read_bytes()).hexdigest() != B17:
            self.skipTest("Exact local B17 installation required")
        self.assertEqual(hashlib.sha256(unity.read_bytes()).hexdigest(), identities["UnityPlayer.dll"]["sha256"])
        ga, up = [pefile.PE(str(p), fast_load=True) for p in (game, unity)]
        rva, code = native._UNMARSHAL_SIGNATURE
        self.assertEqual(ga.get_data(rva, len(bytes.fromhex(code))).hex(), code)
        self.assertEqual(game.read_bytes().count(bytes.fromhex(code)), 1)
        for rva, code in native._NATIVE_SIGNATURES:
            self.assertEqual(up.get_data(rva, len(bytes.fromhex(code))).hex(), code)

    def test_runtime_logic_and_all_preexisting_source_are_preserved(self):
        manifest = json.loads((EVIDENCE / "constant_migration.json").read_text("utf-8"))
        before = json.loads((EVIDENCE / "before_source.json").read_text("utf-8"))["files"]

        def shape(path, names):
            tree = ast.parse(path.read_bytes())
            for node in ast.walk(tree):
                if isinstance(node, (ast.Module, ast.ClassDef, ast.FunctionDef, ast.AsyncFunctionDef)):
                    if ast.get_docstring(node) is not None:
                        node.body = node.body[1:]
                if isinstance(node, ast.Assign) and any(isinstance(t, ast.Name) and t.id in names for t in node.targets):
                    node.value = ast.Constant(None)
            return ast.dump(tree, include_attributes=False)

        changed = {n for n, h in before.items() if n.startswith("src/")
                   and hashlib.sha256((ROOT / n).read_bytes()).hexdigest() != h}
        self.assertEqual(changed, {"src/pokiguard_v2/" + n for n in manifest})
        self.assertEqual(sum(map(len, manifest.values())), 42)
        for name, values in manifest.items():
            rel = "src/pokiguard_v2/" + name
            previous = EVIDENCE / "before" / rel
            self.assertEqual(hashlib.sha256(previous.read_bytes()).hexdigest(), before[rel])
            self.assertEqual(shape(previous, values), shape(ROOT / rel, values), rel)


@unittest.skipUnless((ROOT / "tests/fixtures/petpuzzle_b17_20261118/provenance.json").is_file(),
                     "Captured B17 fixture required")
class B17CapturedFixtureTests(unittest.TestCase):
    def test_owned_start_rect_matches_the_real_b17_room_image(self):
        from pokiguard_v2.boss_entry_ui import locate_chinh_phuc_start
        from pokiguard_v2.win32_screenshot import read_png_rgb
        directory = ROOT / "tests/fixtures/petpuzzle_b17_20261118"
        provenance = json.loads((directory / "provenance.json").read_text("utf-8"))
        image = read_png_rgb(directory / "room_start.png")
        room = provenance["captures"]["room"]
        self.assertEqual(room["boss_id"], 1473)
        self.assertEqual(room["display_level"], 105)
        self.assertEqual(room["start_phase"], 0)
        self.assertFalse(room["occlusion"])
        location = locate_chinh_phuc_start(image.rgb, image.width, image.height,
            expected_rect=tuple(room["start_rect"]))
        self.assertTrue(location.found)
        self.assertGreaterEqual(location.confidence, .95)

    def test_real_capture_identity_and_hashes_are_preserved(self):
        directory = ROOT / "tests/fixtures/petpuzzle_b17_20261118"
        provenance = json.loads((directory / "provenance.json").read_text("utf-8"))
        self.assertEqual(provenance["game_build_sha256"], B17)
        self.assertEqual(provenance["live_profiles"], [[1280, 640]])
        self.assertFalse(provenance["scaled_profiles_are_live"])
        self.assertFalse(provenance["game_input_sent"])
        for name, digest in provenance["files"].items():
            self.assertEqual(hashlib.sha256((directory / name).read_bytes()).hexdigest(), digest)


if __name__ == "__main__":
    unittest.main()
