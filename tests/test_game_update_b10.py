"""b10 independent reverse/byte evidence, exact scope, and fail-closed gates."""
import ast
import hashlib
import importlib
import json
from pathlib import Path
import re
import unittest
from unittest.mock import patch

from tests.game_update_fixture import before_b10_path, before_demon_target_path, historical_test_view

ROOT = Path(__file__).resolve().parents[1]
EVIDENCE = ROOT/'docs/artifacts/game_1_7_4_b10_audit_20261022'
NEW = ROOT/'reverse/reverse_1.7.4-b10'
OLD = ROOT/'reverse/reverse_1.7.4.9'
RUNTIME = {'boss_lobby_runtime.py','chinh_phuc_map.py','il2cpp_external.py',
           'opening_snapshot.py','native_card_ui.py','game_location.py'}


class B10CompatibilityTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.audit = json.loads((EVIDENCE/'static_audit.json').read_text('utf-8'))

    def test_exact_hash_gate_admits_only_b10_and_refuses_b9_and_b6(self):
        from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
        self.assertEqual(SUPPORTED_GAME_ASSEMBLY_SHA256,
            {'9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777'})

    def test_all_38_roots_match_b10_export_by_symbol_not_delta(self):
        from tools.audit_game_update import address_map
        pointers=address_map(NEW)['typeInfoPointers']
        symbols={tuple(v[k] for k in ('name','type','dotNetType')):v for v in pointers}
        self.assertEqual(len(self.audit['typeinfo']),38)
        deltas=set()
        for row in self.audit['typeinfo']:
            key=tuple(row['symbol'][k] for k in ('name','type','dotNetType'))
            rva=int(symbols[key]['virtualAddress'],16)-0x180000000
            module=importlib.import_module('pokiguard_v2.'+Path(row['module']).stem)
            self.assertEqual(getattr(module,row['constant']),rva,row['constant'])
            self.assertEqual(rva,row['new'])
            deltas.add(rva-row['old'])
        self.assertGreater(len(deltas),1)

    def test_all_256_observed_field_candidates_match_new_named_fields(self):
        from tools.audit_game_update import fields
        self.assertEqual(len(self.audit['offset_candidates']),256)
        for row in self.audit['offset_candidates']:
            f=fields(NEW/'cs/Assembly-CSharp'/(row['class']+'.cs'))[row['field']]
            module=importlib.import_module('pokiguard_v2.'+Path(row['module']).stem)
            self.assertEqual(getattr(module,row['constant']),f['offset'])
            self.assertEqual(f['type'],row['old_type'])

    def test_library_layouts_and_nested_stats_dispatcher_remain_equal(self):
        from tools.audit_game_update import fields, FIELD
        rows=json.loads((EVIDENCE/'library_layouts.json').read_text('utf-8'))
        self.assertEqual(len(rows),28)
        for row in rows:
            self.assertEqual(fields(OLD/'cs'/row['file']),fields(NEW/'cs'/row['file']),row['file'])
        def nested(root,rel,name):
            s=(root/'cs/Assembly-CSharp'/rel).read_text('utf-8')
            start=re.search(r'\bclass '+re.escape(name)+r'\b',s).end()
            body=s[start:].split('// Fields',1)[1].split('// Constructors',1)[0]
            return [m.groups() for line in body.splitlines() if (m:=FIELD.fullmatch(line))]
        for rel,name in [('Active.cs','PlayerStats'),('ChatService.cs','__c__DisplayClass321_0')]:
            self.assertEqual(nested(OLD,rel,name),nested(NEW,rel,name))

    def test_icall_cache_read_and_write_agree_with_runtime_constant(self):
        from pokiguard_v2.native_card_ui import _COMPONENT_GO_ICALL
        rows=json.loads((EVIDENCE/'native_check.json').read_text('utf-8'))['native']['Component.gameObject.get']
        load=next(r for r in rows if r['rva']=='0x30d3c6f')
        store=next(r for r in rows if r['rva']=='0x30d3c8c')
        self.assertEqual(load['rip_targets_rva'],store['rip_targets_rva'])
        self.assertEqual(int(load['rip_targets_rva'][0],16),_COMPONENT_GO_ICALL)

    def test_unmarshal_signature_keeps_length_and_follows_exported_tail_call(self):
        from pokiguard_v2.native_card_ui import _UNMARSHAL_SIGNATURE
        r=json.loads((EVIDENCE/'unmarshal_evidence.json').read_text('utf-8'))
        self.assertEqual(r['prefix_hits'],['0x191413f'])
        self.assertEqual(_UNMARSHAL_SIGNATURE[0],0x191413F)
        raw=b''.join(bytes.fromhex(x['bytes']) for x in r['instructions'] if 0x191413F<=int(x['rva'],16)<0x1914159)
        self.assertEqual(raw,bytes.fromhex(_UNMARSHAL_SIGNATURE[1]))
        self.assertEqual(len(raw),26)
        exported=(NEW/'cpp/appdata/il2cpp-functions.h').read_text('utf-8')
        self.assertIn('DO_APP_FUNC(0x01914120, _Canon *, Object_MarshalledUnityObject_Unmarshal',exported)
        check=json.loads((EVIDENCE/'native_check.json').read_text('utf-8'))
        self.assertTrue(all(v['matches'] for v in check['unity_signatures']))
        self.assertFalse(check['old_unmarshal_signature']['matches'])

    def test_production_functions_are_exact_only_reviewed_constant_values_change(self):
        by={}
        for row in self.audit['typeinfo']:by.setdefault(row['module'],set()).add(row['constant'])
        by['native_card_ui.py']={'_COMPONENT_GO_ICALL','_UNMARSHAL_SIGNATURE'}
        by['game_location.py']={'SUPPORTED_GAME_ASSEMBLY_SHA256'}
        self.assertEqual(set(by),RUNTIME)
        for name,allowed in by.items():
            trees=[ast.parse(p.read_text('utf-8')) for p in
                (EVIDENCE/'before/src/pokiguard_v2'/name,ROOT/'src/pokiguard_v2'/name)]
            for tree in trees:
                if isinstance(tree.body[0],ast.Expr) and isinstance(tree.body[0].value,ast.Constant):
                    tree.body=tree.body[1:]
                for n in tree.body:
                    if isinstance(n,ast.Assign) and any(isinstance(t,ast.Name) and t.id in allowed for t in n.targets):
                        n.value=ast.Constant(value=None)
            self.assertEqual(ast.dump(trees[0],include_attributes=False),ast.dump(trees[1],include_attributes=False),name)

    @historical_test_view()
    def test_all_other_runtime_sources_input_jitter_and_gameplay_are_byte_exact(self):
        old=json.loads((EVIDENCE/'before_source.json').read_text('utf-8'))['files']
        for name,expected in old.items():
            if name.startswith(('src/','tools/')) and Path(name).name not in RUNTIME:
                self.assertEqual(hashlib.sha256(before_demon_target_path(ROOT,name).read_bytes()).hexdigest(),expected,name)

    @historical_test_view()
    def test_saved_b9_view_is_exact_and_rejects_unreviewed_current_edits(self):
        name='src/pokiguard_v2/il2cpp_external.py'
        self.assertEqual(before_b10_path(ROOT,name),EVIDENCE/'before'/name)
        read=Path.read_bytes
        for target in (ROOT/name,EVIDENCE/'before'/name,EVIDENCE/'historical_fixture_manifest.json'):
            def altered(p):
                raw=read(p)
                return raw+b'\n# unreviewed\n' if p==target else raw
            with patch.object(Path,'read_bytes',altered),self.assertRaises(AssertionError):
                before_b10_path(ROOT,name)

    def test_default_path_is_current_and_old_E1_cannot_authorize_b10(self):
        from pokiguard_v2.reasoning_e1_native import verify_boundary
        from pokiguard_v2.reasoning_calibration import source_fingerprint
        self.assertEqual(before_b10_path(ROOT,'src/pokiguard_v2/il2cpp_external.py'),ROOT/'src/pokiguard_v2/il2cpp_external.py')
        old=ROOT/'docs/phase5/artifacts/5e1_requalification_1749_20261021/completion/pilot'
        cal=json.loads((old/'calibration.json').read_text('utf-8'))
        with self.assertRaises(ValueError):verify_boundary(old,cal,source_fingerprint(ROOT))


if __name__=='__main__':unittest.main()
