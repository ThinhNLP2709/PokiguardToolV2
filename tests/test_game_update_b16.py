"""B16 profile is one exact build, with independently exported reader contracts."""
import ast
import hashlib
import importlib
import json
from pathlib import Path
import unittest

from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
from tools.reverse_exports import dumper_script, dumper_types, unique

ROOT = Path(__file__).resolve().parents[1]
REVERSE = ROOT / "reverse/reverse_1.7.4-b16"
EVIDENCE = ROOT / "docs/artifacts/game_1_7_4_b16_20261117"
B16 = "c69c95c4c6bd0cbc28181033ccd2a974e085f47055f123627e0b3a33e1595f3a"
B15 = "18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea"


@unittest.skipUnless(B16 in SUPPORTED_GAME_ASSEMBLY_SHA256, "B16 is not the active runtime profile")
class B16ProfileTests(unittest.TestCase):
    def test_exact_build_is_required(self):
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256, frozenset({B16}))
        self.assertNotIn(B15, SUPPORTED_GAME_ASSEMBLY_SHA256)

    def test_relocated_connection_flags_are_pinned(self):
        from pokiguard_v2 import il2cpp_external as runtime
        self.assertEqual(runtime.CHAT_SERVICE_EXPLICIT_DISCONNECT_OFFSET, 0x34D)
        self.assertEqual(runtime.CHAT_SERVICE_RECONNECT_COROUTINE_OFFSET, 0x350)
        self.assertEqual(runtime.CHAT_SERVICE_CONNECTING_OFFSET, 0x35C)


@unittest.skipUnless(B16 in SUPPORTED_GAME_ASSEMBLY_SHA256 and (REVERSE / "script.json").is_file() and
                     (EVIDENCE / "static_audit_verified.json").is_file(), "Local B16 reverse audit required")
class B16ExportTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit = json.loads((EVIDENCE / "static_audit_verified.json").read_text("utf-8"))
        cls.script = dumper_script(str(REVERSE))
        cls.types = dumper_types(str(REVERSE))

    def test_every_production_typeinfo_matches_exact_symbol(self):
        self.assertEqual(len(self.audit["typeinfo"]), 39)
        for row in self.audit["typeinfo"]:
            with self.subTest(constant=row["constant"]):
                export = unique(self.script["ScriptMetadata"], row["export"]["Name"])
                self.assertEqual(export, row["export"])
                module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
                self.assertEqual(getattr(module, row["constant"]), export["Address"])
        coop = unique(self.script["ScriptMetadata"], "Active.PlayerStats_TypeInfo")
        pvp = unique(self.script["ScriptMetadata"], "ActivePVP.PlayerStats_TypeInfo")
        self.assertNotEqual(coop["Address"], pvp["Address"])

    def test_all_consumed_managed_fields_match_name_type_and_owner(self):
        self.assertEqual(len(self.audit["fields"]), 289)
        self.assertEqual(sum(not r["equal"] for r in self.audit["fields"]), 3)
        self.assertEqual(self.audit["missing_source_bindings"], [])
        for row in self.audit["fields"]:
            with self.subTest(module=row["module"], constant=row["constant"]):
                field = self.types["Assembly-CSharp", row["klass"]]["fields"][row["field"]]
                self.assertEqual(field, row["new"])
                self.assertEqual(field["type"], row["old"]["type"])
                module = importlib.import_module("pokiguard_v2." + Path(row["module"]).stem)
                self.assertEqual(getattr(module, row["constant"]), field["offset"])
        from pokiguard_v2 import pet_qte_observer as qte
        self.assertGreaterEqual(qte.CHAT_MESSAGE_QTE_RESULT_READ_SIZE,
                                qte.CHAT_MESSAGE_QTE_CHALLENGE_ID_OFFSET + 16)

    def test_opening_json_closed_containers_domains_and_board_formula(self):
        self.assertTrue(all(r["equal"] for r in self.audit["json_contracts"].values()))
        self.assertEqual(len(self.audit["closed_contracts"]), 2384)
        self.assertTrue(all(r["equal"] for r in self.audit["closed_contracts"].values()))
        self.assertTrue(all(r["equal"] for r in self.audit["abi"].values()))
        self.assertTrue(all(r["equal"] for r in self.audit["enums"]))
        self.assertTrue(all(r["equal"] for r in self.audit["geometry"]))
        self.assertTrue(self.audit["hud_constants"]["equal"])
        for owner in ("Dot", "BoardCellDTO", "ChatMessageDTO", "MatchService", "ManagerMatch",
                      "RoomCoopV2Refs", "RoomCoopV2View", "ManagerRoom", "ManagerChinhPhuc",
                      "CardUI", "FusionCardUI", "CardData", "Active.PlayerStats", "WsCombatBatch"):
            self.assertTrue(self.audit["selected_layouts"][owner]["equal"], owner)

    def test_closure_role_follows_message_not_compiler_number(self):
        name = "ChatService.<>c__DisplayClass328_0$$<OnWebSocketMessage>b__0"
        callback = unique(self.script["ScriptMethod"], name)
        self.assertEqual(callback, self.audit["anchors"][name]["export"])
        self.assertTrue(self.audit["anchors"][name]["normalized_equal"])
        fields = self.types["Assembly-CSharp", "ChatService.<>c__DisplayClass328_0"]["fields"]
        self.assertEqual(fields["message"], {"type": "ChatMessageDTO", "offset": 0x20})
        self.assertEqual(fields["json"], {"type": "string", "offset": 0x18})

    def test_native_cache_and_unique_unmarshal_signature_match_installed_build(self):
        import pefile
        from pokiguard_v2 import native_card_ui as native
        self.assertEqual(native._COMPONENT_GO_ICALL, self.audit["component_cache_rva"])
        self.assertEqual(native._UNMARSHAL_SIGNATURE, tuple(self.audit["unmarshal_signature"]))
        files = {Path(r["path"]).name: r for r in self.audit["identities"]}
        game, unity = [Path(files[n]["path"]) for n in ("GameAssembly.dll", "UnityPlayer.dll")]
        if not game.is_file() or hashlib.sha256(game.read_bytes()).hexdigest() != B16:
            self.skipTest("Exact local B16 installation required")
        self.assertEqual(hashlib.sha256(unity.read_bytes()).hexdigest(), files["UnityPlayer.dll"]["sha256"])
        ga, up = [pefile.PE(str(p), fast_load=True) for p in (game, unity)]
        rva, code = native._UNMARSHAL_SIGNATURE
        self.assertEqual(ga.get_data(rva, len(bytes.fromhex(code))).hex(), code)
        self.assertEqual(game.read_bytes().count(bytes.fromhex(code)), 1)
        for rva, code in native._NATIVE_SIGNATURES:
            self.assertEqual(up.get_data(rva, len(bytes.fromhex(code))).hex(), code)

    def test_migration_preserves_existing_runtime_logic(self):
        migration = json.loads((EVIDENCE / "constant_migration.json").read_text("utf-8"))

        def shape(path, names):
            tree = ast.parse(path.read_bytes())
            for node in ast.walk(tree):
                if isinstance(node, (ast.Module, ast.ClassDef, ast.FunctionDef, ast.AsyncFunctionDef)):
                    if ast.get_docstring(node) is not None:
                        node.body = node.body[1:]
                if isinstance(node, ast.Assign) and any(isinstance(t, ast.Name) and t.id in names for t in node.targets):
                    node.value = ast.Constant(None)
            return ast.dump(tree, include_attributes=False)

        before = json.loads((EVIDENCE / "before_source.json").read_text("utf-8"))["files"]
        changed = {name for name, digest in before.items() if name.startswith("src/")
                   and hashlib.sha256((ROOT / name).read_bytes()).hexdigest() != digest}
        self.assertEqual(changed, {"src/pokiguard_v2/" + name for name in migration})
        for name, changes in migration.items():
            rel = "src/pokiguard_v2/" + name
            previous = EVIDENCE / "before" / rel
            self.assertEqual(hashlib.sha256(previous.read_bytes()).hexdigest(), before[rel])
            self.assertEqual(shape(previous, changes), shape(ROOT / rel, changes), rel)

    def test_verified_seal_data_and_skill_phase_are_preserved(self):
        contracts = json.loads((EVIDENCE / "runtime_contracts.json").read_text("utf-8"))
        self.assertTrue(contracts["closure_slot_used_by_websocket_handler"])
        self.assertTrue(all(r["matches_b15"] and r["matches_production"] for r in contracts["mega_patterns"].values()))
        from pokiguard_v2.galaxy_skill_phase import (SKILL_PHASE_NEXT_OFFSET, SKILL_PHASE_MAX_OFFSET,
                                                    SKILL_PHASE_CARD_ID_OFFSET, SNAPSHOT_READ_SIZE)
        self.assertEqual((SKILL_PHASE_NEXT_OFFSET, SKILL_PHASE_MAX_OFFSET, SKILL_PHASE_CARD_ID_OFFSET),
                         (0x15C, 0x17C, 0x180))
        self.assertGreaterEqual(SNAPSHOT_READ_SIZE, SKILL_PHASE_CARD_ID_OFFSET + 4)

class B16CapturedFixtureTests(unittest.TestCase):
    """Captured B16 evidence remains verifiable after the runtime profile moves."""

    def test_live_room_fixture_matches_owned_start_rectangle(self):
        from pokiguard_v2.win32_screenshot import read_png_rgb
        from pokiguard_v2.boss_entry_ui import locate_chinh_phuc_start
        directory = ROOT / "tests/fixtures/petpuzzle_b16_20261117"
        provenance = json.loads((directory / "provenance.json").read_text("utf-8"))
        self.assertEqual(provenance["game_build_sha256"], B16)
        self.assertEqual(provenance["live_profiles"], [[1280, 640]])
        self.assertFalse(provenance["game_input_sent"])
        image = read_png_rgb(directory / "room_start.png")
        location = locate_chinh_phuc_start(image.rgb, image.width, image.height,
            expected_rect=tuple(provenance["room"]["start_rect"]))
        self.assertTrue(location.found)
        self.assertGreaterEqual(location.confidence, 0.95)

    def test_live_fixtures_retain_identity_and_map_provenance(self):
        directory = ROOT / "tests/fixtures/petpuzzle_b16_20261117"
        provenance = json.loads((directory / "provenance.json").read_text("utf-8"))
        for name, digest in provenance["files"].items():
            self.assertEqual(hashlib.sha256((directory / name).read_bytes()).hexdigest(), digest)
        self.assertEqual(provenance["map"]["boss_id"], 1436)
        self.assertIn("panelButtons[pet_index]", provenance["map"]["proof"])
        self.assertFalse(provenance["map"]["occlusion"])
        self.assertFalse(provenance["scaled_profiles_are_live"])


if __name__ == "__main__":
    unittest.main()
