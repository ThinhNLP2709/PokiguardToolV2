"""Independent b12 file/reverse evidence and exact migration scope."""
import ast
import hashlib
import importlib
import json
from pathlib import Path
import re
import unittest
from unittest.mock import patch

ROOT=Path(__file__).resolve().parents[1]
OUT=ROOT/'docs/artifacts/game_1_7_4_b12_20261026'
OLD=ROOT/'reverse/reverse_1.7.4-b10'
NEW=ROOT/'reverse/reverse_1.7.4-b12'


class B12CompatibilityTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit=json.loads((OUT/'static_audit.json').read_text('utf-8'))
        cls.native=json.loads((OUT/'native_layout_evidence.json').read_text('utf-8'))
        cls.migration=json.loads((OUT/'constant_migration.json').read_text('utf-8'))

    def test_exact_supported_build_and_old_build_rejection(self):
        from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256,
            {'51eaeff77252e7119647a590c534196093b36e752115b500672f24da758f1064'})
        self.assertNotIn('9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777',
                         SUPPORTED_GAME_ASSEMBLY_SHA256)

    def test_all_39_typeinfo_slots_match_exact_new_symbol_identity(self):
        from tools.audit_game_update import address_map
        symbols={tuple(row[k] for k in ('name','type','dotNetType')):row
                 for row in address_map(NEW)['typeInfoPointers']}
        self.assertEqual(len(self.audit['typeinfo']),39)
        deltas=set()
        for row in self.audit['typeinfo']:
            key=tuple(row['symbol'][k] for k in ('name','type','dotNetType'))
            rva=int(symbols[key]['virtualAddress'],16)-0x180000000
            module=importlib.import_module('pokiguard_v2.'+Path(row['module']).stem)
            self.assertEqual(getattr(module,row['constant']),rva,row['constant'])
            self.assertEqual(row['new'],rva)
            deltas.add(rva-row['old'])
        self.assertGreater(len(deltas),1)

    def test_257_field_candidates_keep_exact_name_type_offset(self):
        from tools.audit_game_update import fields
        self.assertEqual(len(self.audit['offset_candidates']),257)
        for row in self.audit['offset_candidates']:
            a=fields(OLD/'cs/Assembly-CSharp'/(row['class']+'.cs'))[row['field']]
            b=fields(NEW/'cs/Assembly-CSharp'/(row['class']+'.cs'))[row['field']]
            self.assertEqual(a,b,(row['class'],row['field']))
            module=importlib.import_module('pokiguard_v2.'+Path(row['module']).stem)
            self.assertEqual(getattr(module,row['constant']),b['offset'])

    def test_library_nested_and_reminder_layouts(self):
        from tools.audit_game_update import fields
        self.assertEqual(len(self.native['library_layouts']),28)
        self.assertTrue(all(row['equal'] for row in self.native['library_layouts']+self.native['nested']))
        for row in self.native['library_layouts']:
            self.assertEqual(fields(OLD/'cs'/row['file']),fields(NEW/'cs'/row['file']))
        rel='cs/Assembly-CSharp/Poki/Health/PlayReminder.cs'
        self.assertEqual(fields(OLD/rel),fields(NEW/rel))
        from pokiguard_v2.play_reminder import PLAY_REMINDER_TYPE_INFO_RVA
        self.assertEqual(PLAY_REMINDER_TYPE_INFO_RVA,0x3DD5B50)

    def test_native_cache_load_store_and_exported_tail(self):
        from pokiguard_v2.native_card_ui import _COMPONENT_GO_ICALL,_UNMARSHAL_SIGNATURE
        rows=self.native['component']
        load=next(r for r in rows if r['rva']=='0x31361af')
        store=next(r for r in rows if r['rva']=='0x31361cc')
        self.assertEqual(load['rip_targets'],store['rip_targets'])
        self.assertEqual(int(load['rip_targets'][0],16),_COMPONENT_GO_ICALL)
        self.assertTrue(any(r['mnemonic']=='jmp' and r['operands']=='0x19740a0' for r in rows))
        self.assertEqual(_UNMARSHAL_SIGNATURE,(0x19740BF,
            '4885db7433f6c301740d488bcbe8df888afe488bd8eb03488b1b'))
        header=(NEW/'cpp/appdata/il2cpp-functions.h').read_text('utf-8')
        self.assertIn('DO_APP_FUNC(0x019740A0, _Canon *, Object_MarshalledUnityObject_Unmarshal',header)
        self.assertEqual(len(bytes.fromhex(_UNMARSHAL_SIGNATURE[1])),26)
        self.assertTrue(all(row['matches'] for row in self.native['unity_signatures']))

    def test_migration_changes_only_verified_constants_in_seven_runtime_files(self):
        self.assertEqual(len(self.migration),7)
        for name,row in self.migration.items():
            def normalized(path):
                tree=ast.parse(path.read_text('utf-8'))
                if isinstance(tree.body[0],ast.Expr) and isinstance(tree.body[0].value,ast.Constant):tree.body=tree.body[1:]
                for node in tree.body:
                    if isinstance(node,ast.Assign) and any(isinstance(t,ast.Name) and t.id in row['constants'] for t in node.targets):node.value=ast.Constant(None)
                return ast.dump(tree,include_attributes=False)
            self.assertEqual(normalized(OUT/'before'/name),normalized(ROOT/name),name)

    def test_all_other_runtime_sources_are_byte_exact(self):
        before=json.loads((OUT/'before_source.json').read_text('utf-8'))['files']
        for name,digest in before.items():
            if name.startswith(('src/','tools/')) and name not in self.migration:
                self.assertEqual(hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),digest,name)

    def test_metadata_runtime_names_and_machine(self):
        self.assertEqual(self.native['app_info'].splitlines(),['Pet Puzzle','Pet Puzzle'])
        self.assertEqual(self.native['metadata_header'],[0xFAB11BAF,110])
        self.assertEqual(self.audit['pe']['machine'],0x8664)
        from pokiguard_v2.game_location import is_supported_game_executable_name
        self.assertTrue(is_supported_game_executable_name('PetPuzzle-1.7.4.exe'))


if __name__=='__main__':unittest.main()
