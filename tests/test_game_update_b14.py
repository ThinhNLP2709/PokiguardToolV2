"""Independent B14 export/binary checks and bounded migration scope."""
import ast
import hashlib
import importlib
import json
from pathlib import Path
import tempfile
import unittest

from tools.reverse_exports import parse_fields, dumper_types, unique
from tools.audit_dumper_semantics import flat_cpp_layout, scoped_type

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'docs/artifacts/game_1_7_4_b14_20261101'
NEW = ROOT / 'reverse/reverse_1.7.4-b14'


class DumperEvidenceParserTests(unittest.TestCase):
    def test_backing_fields_stop_before_nested_and_duplicate_rejected(self):
        text = 'private int <Turn>k__BackingField; // 0x28\n// Nested types\nprivate int wrong; // 0x80'
        self.assertEqual(parse_fields(text), {'_Turn_k__BackingField': {'type': 'int', 'offset': 40}})
        with self.assertRaises(ValueError):
            parse_fields('private int null; // 0x10\nprivate int null; // 0x14')

    def test_same_short_name_in_other_namespace_or_image_not_merged(self):
        text = ('// Image 0: Assembly-CSharp.dll - 0\n// Image 1: Other.dll - 3\n'
                '// Namespace: One\npublic class Thing // TypeDefIndex: 0\n{\npublic int x; // 0x10\n}\n'
                '// Namespace: Two\npublic class Thing // TypeDefIndex: 1\n{\npublic int x; // 0x18\n}\n'
                '// Namespace: One\npublic class Thing // TypeDefIndex: 3\n{\npublic int x; // 0x20\n}\n')
        with tempfile.TemporaryDirectory() as directory:
            Path(directory, 'dump.cs').write_text(text, encoding='utf-8')
            rows = dumper_types(directory)
            self.assertEqual(len(rows), 3)
            self.assertEqual(rows['Assembly-CSharp', 'Two.Thing']['fields']['x']['offset'], 24)
            self.assertEqual(rows['Other', 'One.Thing']['fields']['x']['offset'], 32)

    def test_ambiguous_symbols_and_unknown_abi_fail(self):
        with self.assertRaises(ValueError):
            unique([{'Name': 'X'}, {'Name': 'X'}], 'X')
        with self.assertRaises(KeyError):
            flat_cpp_layout('struct Bad {\nUnknown x;\n};', 'Bad')
        self.assertNotEqual(scoped_type('Active', 'Active.PlayerStats'),
                            scoped_type('Active', 'ActivePVP.PlayerStats'))
        self.assertEqual(scoped_type('MatchHost', 'static MatchKind?'),
                         scoped_type('MatchHost', 'static Nullable<MatchKind>'))


from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256


@unittest.skipUnless(
    "33df13da565808a41d8268dafdf5702d736fc8fcb889515e57bda475528d2152"
    in SUPPORTED_GAME_ASSEMBLY_SHA256,
    "Historical B14 profile; current profile verified by B15 tests",
)
@unittest.skipUnless((OUT / 'native_evidence_v2.json').is_file() and (NEW / 'script.json').is_file(),
                     'Local B14 reverse/evidence required')
class B14CompatibilityTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit = json.loads((OUT / 'static_audit.json').read_text('utf-8'))
        cls.native = json.loads((OUT / 'native_evidence_v2.json').read_text('utf-8'))
        cls.semantic = json.loads((OUT / 'semantic_evidence_v3.json').read_text('utf-8'))
        cls.migration = json.loads((OUT / 'constant_migration.json').read_text('utf-8'))

    def test_exact_hash_gate_and_metadata_not_interchangeable(self):
        from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
        from tools.metadata_probe import SUPPORTED_VERSIONS
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256,
            {'33df13da565808a41d8268dafdf5702d736fc8fcb889515e57bda475528d2152'})
        self.assertNotIn('51eaeff77252e7119647a590c534196093b36e752115b500672f24da758f1064', SUPPORTED_GAME_ASSEMBLY_SHA256)
        self.assertEqual(self.audit['metadata_header'], [0xFAB11BAF, 111])
        self.assertIn(111, SUPPORTED_VERSIONS)
        self.assertNotIn(112, SUPPORTED_VERSIONS)

    def test_all_39_named_roots_match_dumper_not_a_global_delta(self):
        from tools.reverse_exports import dumper_script
        script = dumper_script(str(NEW))
        self.assertEqual(len(self.audit['typeinfo']), 39)
        deltas = set()
        for row in self.audit['typeinfo']:
            current = unique(script['ScriptMetadata'], row['export']['Name'])
            self.assertEqual(current, row['export'])
            module = importlib.import_module('pokiguard_v2.' + Path(row['module']).stem)
            self.assertEqual(getattr(module, row['constant']), current['Address'], row['constant'])
            deltas.add(current['Address'] - row['old'])
        self.assertGreater(len(deltas), 1)
        self.assertNotEqual(unique(script['ScriptMetadata'], 'Active.PlayerStats_TypeInfo')['Address'],
                            unique(script['ScriptMetadata'], 'ActivePVP.PlayerStats_TypeInfo')['Address'])

    def test_257_owned_fields_and_51_moves_match_independent_export(self):
        types = dumper_types(str(NEW))
        rows = self.audit['offset_candidates']
        self.assertEqual(len(rows), 257)
        self.assertEqual(sum(r['old']['offset'] != r['new']['offset'] for r in rows), 51)
        for row in rows:
            current = types['Assembly-CSharp', row['klass']]['fields'][row['field']]
            self.assertEqual(current, row['new'])
            self.assertEqual(scoped_type(row['klass'], row['old']['type']), scoped_type(row['klass'], current['type']))
            module = importlib.import_module('pokiguard_v2.' + Path(row['module']).stem)
            self.assertEqual(getattr(module, row['constant']), current['offset'], row['constant'])
        self.assertTrue(all(r['equal'] for r in self.audit['nested']))

    def test_extended_read_spans_cover_shifted_last_fields(self):
        from pokiguard_v2 import combat_cards as c, pet_qte_observer as q
        self.assertEqual(c.CARD_UI_READ_SIZE, 0x89)
        self.assertGreater(c.CARD_UI_READ_SIZE, c.CARD_UI_IS_PLACEHOLDER_OFFSET)
        self.assertEqual(q.MATCH_SERVICE_SERVER_QTE_READ_SIZE, 0x2E8)
        self.assertEqual(q.CARD_UI_READ_SIZE, 0x4AA)

    def test_native_signatures_are_exact_current_binary_bytes(self):
        import pefile
        from pokiguard_v2.native_card_ui import (_NATIVE_SIGNATURES, _UNMARSHAL_SIGNATURE,
            _COMPONENT_GO_ICALL, _COMPONENT_GO_RVA, _TRANSFORM_DATA_LOCAL_TRS_OFFSET)
        identities = {Path(r['path']).name: r for r in self.audit['identities']}
        for name in ('GameAssembly.dll', 'UnityPlayer.dll'):
            self.assertEqual(hashlib.sha256(Path(identities[name]['path']).read_bytes()).hexdigest(), identities[name]['sha256'])
        game, unity = (pefile.PE(identities[name]['path'], fast_load=True) for name in ('GameAssembly.dll', 'UnityPlayer.dll'))
        self.assertEqual(_NATIVE_SIGNATURES, tuple((r['rva'], r['signature']) for r in self.native['native_signatures']))
        self.assertEqual(len(_NATIVE_SIGNATURES), 16)
        for rva, code in _NATIVE_SIGNATURES:
            self.assertEqual(unity.get_data(rva, len(bytes.fromhex(code))), bytes.fromhex(code))
        self.assertEqual(_UNMARSHAL_SIGNATURE, tuple(self.native['unmarshal_signature']))
        rva, code = _UNMARSHAL_SIGNATURE
        self.assertEqual(game.get_data(rva, len(bytes.fromhex(code))), bytes.fromhex(code))
        self.assertEqual(_COMPONENT_GO_ICALL, self.native['component_cache_rva'])
        self.assertEqual(_COMPONENT_GO_RVA, self.native['component_unity_rva'])
        self.assertEqual(_TRANSFORM_DATA_LOCAL_TRS_OFFSET, 24)
        self.assertEqual(self.native['class_static_fields_offset'], 0x98)

    def test_canvas_enabled_uses_observed_virtual_getter_and_icall(self):
        import pefile
        from pokiguard_v2 import play_reminder as r
        proof = json.loads((OUT / 'canvas_enabled_readonly.json').read_text('utf-8'))
        probe = json.loads((OUT / 'candidate_readonly_probe_behaviour.json').read_text('utf-8'))
        self.assertTrue(proof['canvases'])
        self.assertTrue(any(x['method'] == 'UnityEngine.Behaviour$$get_enabled' and x['unity_rva'] == r._BEHAVIOUR_ENABLED_THUNK_RVA for x in probe['icalls']))
        identity = next(x for x in self.audit['identities'] if Path(x['path']).name == 'UnityPlayer.dll')
        binary = pefile.PE(identity['path'], fast_load=True)
        self.assertEqual(binary.get_data(r._BEHAVIOUR_ENABLED_THUNK_RVA, 10).hex(), proof['thunk_bytes'])
        for canvas in proof['canvases']:
            self.assertEqual(canvas['getter_unity_rva'], r._CANVAS_ENABLED_GETTER_RVA)
            self.assertEqual(canvas['class_identity'], ['Canvas', 'UnityEngine'])
            self.assertEqual(binary.get_data(r._CANVAS_ENABLED_GETTER_RVA, 8), r._CANVAS_ENABLED_GETTER_CODE)

    def test_closed_generic_abi_not_open_generic_zero_offsets(self):
        abi = self.semantic['closed_abi']
        self.assertEqual(abi['System_Collections_Generic_Dictionary_Entry_TKey__TValue__Fields']['size'], 24)
        self.assertEqual(abi['System_Collections_Generic_HashSet_Slot_long__Fields']['size'], 16)
        self.assertEqual(abi['System_Collections_Generic_Queue_UnityMainThreadDispatcher_PendingAction__Fields']['fields']['_size']['offset'], 32)
        self.assertEqual(abi['System_String_Fields']['fields']['_firstChar']['offset'], 20)
        self.assertEqual(self.semantic['array_abi']['data'], 32)

    def test_enum_existing_values_and_board_geometry_preserved(self):
        enums = self.semantic['enums']
        self.assertEqual(len(enums), 104)
        self.assertEqual({r['identity'] for r in enums if not r['equal']},
                         {'LibFilter.PetTier', 'PokyHome.Avatar.BackdropAnimTable.Kind'})
        for row in enums:
            self.assertTrue(row['new'])
            self.assertEqual(row['new'][:len(row['old'])], row['old'])
        self.assertTrue(all(row['normalized_equal'] for row in self.semantic['geometry']))
        self.assertFalse(self.semantic['board_pixel_mapping_live_verified'])

    def test_runtime_mutation_scope_is_limited_to_profile_and_two_indirections(self):
        for name, row in self.migration.items():
            def normalized(path):
                tree = ast.parse(path.read_bytes())
                for parent in ast.walk(tree):
                    if isinstance(parent, (ast.Module, ast.FunctionDef, ast.AsyncFunctionDef, ast.ClassDef)) and parent.body:
                        if isinstance(parent.body[0], ast.Expr) and isinstance(parent.body[0].value, ast.Constant) and isinstance(parent.body[0].value.value, str):
                            parent.body = parent.body[1:]
                tree.body = [n for n in tree.body if not (isinstance(n, ast.Assign) and any(isinstance(t, ast.Name) and t.id in row.get('added_constants', {}) for t in n.targets))]
                for node in ast.walk(tree):
                    if isinstance(node, ast.Assign) and any(isinstance(t, ast.Name) and t.id in row['constants'] for t in node.targets):
                        node.value = ast.Constant(None)
                    if isinstance(node, ast.BinOp) and isinstance(node.op, ast.Add) and isinstance(node.right, ast.Name):
                        if node.right.id == '_TRANSFORM_DATA_LOCAL_TRS_OFFSET':
                            node.right = ast.Constant(32)
                        elif node.right.id == '_BEHAVIOUR_ENABLED_THUNK_RVA':
                            node.right = ast.Constant(0x114430)
                return ast.dump(tree, include_attributes=False)
            self.assertEqual(normalized(OUT / 'before' / name), normalized(ROOT / name), name)

    def test_every_other_pre_task_runtime_file_matches_profile_or_reviewed_result_fix(self):
        before = json.loads((OUT / 'before_source.json').read_text('utf-8'))['files']
        self.assertEqual(len(before), 388)
        # Subsequent native B1 exposed a new result layout. Its separate
        # before/after proof is not folded into the constant-only migration.
        result_proof = json.loads((ROOT / 'tests/fixtures/petpuzzle_b14_result_20261101/provenance.json').read_text('utf-8'))
        result_fix = result_proof['source_change']
        current_result_fix = result_proof.get('followup_source_change', result_fix)
        if current_result_fix is not result_fix:
            self.assertEqual(current_result_fix['before_sha256'], result_fix['after_sha256'])
        transparency = json.loads((ROOT / 'tests/fixtures/petpuzzle_b14_result_20261102_transparency/provenance.json').read_text('utf-8'))['source_change']
        self.assertEqual(current_result_fix['after_sha256'], transparency['before_sha256'])
        current_result_fix = transparency
        # The later common-AI task is independent of B14 constant migration.
        # Only its explicitly reviewed runtime files may use the pinned closure;
        # reader/input/QTE and every other pre-task byte stay under this audit.
        common_names = frozenset('src/pokiguard_v2/'+n+'.py' for n in (
            'desktop_farm_controller','desktop_ui','reasoning_common_evidence','reasoning_common_models',
            'reasoning_common_planner','reasoning_common_selection','reasoning_ui_profile',
            'reasoning_ui_scope','reasoning_ui_session')) | {'tools/qualify_common_reasoning.py'}
        common_dir = ROOT / 'docs/phase5/artifacts/common_ai_assistant_20261101'
        common_before = json.loads((common_dir/'before_source.json').read_text('utf-8'))['files']
        common_final = json.loads((common_dir/'final_source.json').read_text('utf-8'))
        from pokiguard_v2.reasoning_snapshot import digest as source_digest
        self.assertEqual(source_digest(common_final['files']), common_final['fingerprint'])
        self.assertEqual(common_final['fingerprint'],'f669b126fbce1bd2410620f4ead003c2076c6e426c2250000ed13a0a13d48024')
        alignment_dir=ROOT/'docs/phase5/artifacts/strategy_alignment_20261103'
        alignment=json.loads((alignment_dir/'reviewed_runtime.json').read_text('utf-8'))
        alignment_before=json.loads((alignment_dir/'before_source.json').read_text('utf-8'))['files']
        self.assertEqual(source_digest(alignment['files']),alignment['fingerprint'])
        self.assertEqual(alignment['fingerprint'],'ef12b14c2c52351c6522087ae200b92cbbef52c6146422a14f7c22ba31e05355')
        direct=json.loads((ROOT/'docs/phase5/artifacts/adviser_direct_sword_20261104/reviewed_runtime.json').read_text('utf-8'))
        self.assertEqual(source_digest(direct['files']),direct['fingerprint'])
        self.assertEqual(direct['fingerprint'],'d0c010a7d6f77ad4ac801d99b5e87b594a671e30a389038b073b8c8bdd3dd776')
        self.assertEqual(set(alignment['files']),set(direct['files']))
        timing=json.loads((ROOT/'docs/phase5/artifacts/adviser_timing_reuse_20261104/reviewed_runtime.json').read_text('utf-8'))
        self.assertEqual(source_digest(timing['files']),timing['fingerprint'])
        self.assertEqual(timing['fingerprint'],'f44dd6c26133fa74e5bb793170c00fa437f7670923fc242ea71dd59a2a509c08')
        checkpoint_fix=json.loads((ROOT/'docs/artifacts/checkpoint_replace_20261105/reviewed_runtime.json').read_text('utf-8'))
        self.assertEqual(source_digest(checkpoint_fix['files']),checkpoint_fix['fingerprint'])
        self.assertEqual(checkpoint_fix['fingerprint'],'93b174da3bd3ec8f74239fde2da7455f94711d29966a99ac2d73e976ffe85d70')
        label131=json.loads((ROOT/'docs/artifacts/rebuild_v1_3_1_20261105/reviewed_runtime.json').read_text('utf-8'))
        self.assertEqual(source_digest(label131['files']),label131['fingerprint'])
        self.assertEqual(label131['fingerprint'],'b0655fefa4fee9c1dc320bfb7ea4380435c5a1bf5647fb8d03c550a4686fef97')
        for name,expected in label131['files'].items():
            self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),expected)
        for name,expected in checkpoint_fix['files'].items():
            if name in label131['files']:
                self.assertEqual(expected,label131['before_files'][name])
            else:
                self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),expected)
        for name,expected in timing['files'].items():
            if name in checkpoint_fix['files']:
                self.assertEqual(expected,checkpoint_fix['before_files'][name])
            else:
                self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),expected)
        for name,expected in alignment['files'].items():
            if name!='src/pokiguard_v2/reasoning_common_planner.py':self.assertEqual(expected,direct['files'][name])
            if name in timing['files']:
                self.assertEqual(direct['files'][name],timing['before_files'][name])
            else:
                self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),direct['files'][name])
        room_fix=json.loads((ROOT/'docs/artifacts/room_return_20261104/reviewed_runtime.json').read_text('utf-8'))
        self.assertEqual(source_digest(room_fix['files']),room_fix['fingerprint'])
        self.assertEqual(room_fix['fingerprint'],'ff957395e54d62640656de423b1fa24279cf58b422fe7f2ca369a4481d8c46f8')
        self.assertEqual(set(room_fix['files']),{'tools/farm_run.py','src/pokiguard_v2/farm_run.py','src/pokiguard_v2/room_invite.py'})
        for name,expected in room_fix['files'].items():self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),expected)
        for name, digest in before.items():
            if name.startswith(('src/', 'tools/')) and name not in self.migration:
                if name=='src/pokiguard_v2/reasoning_runner.py':
                    self.assertEqual(digest,alignment_before[name])
                    continue
                if name in common_names:
                    self.assertEqual(digest,common_before[name])
                    self.assertEqual(alignment_before[name],common_final['files'][name])
                    continue
                if name in room_fix['before_files']:
                    self.assertEqual(digest,room_fix['before_files'][name])
                    self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),room_fix['files'][name])
                    continue
                if name=='src/pokiguard_v2/version.py':
                    self.assertEqual(digest,label131['before_files'][name])
                    self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),label131['files'][name])
                    continue
                if name=='src/pokiguard_v2/farm_checkpoint.py':
                    self.assertEqual(digest,checkpoint_fix['before_files'][name])
                    self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),checkpoint_fix['files'][name])
                    continue
                if name == result_fix['path']:
                    self.assertEqual(digest, result_fix['before_sha256'])
                    self.assertEqual(hashlib.sha256((ROOT / name).read_bytes()).hexdigest(), current_result_fix['after_sha256'])
                    continue
                self.assertEqual(hashlib.sha256((ROOT / name).read_bytes()).hexdigest(), digest, name)


if __name__ == '__main__':
    unittest.main()
