"""Pin the reviewed logging delta without reusing historical native authority."""
import ast
import copy
import hashlib
import json
from pathlib import Path
import unittest

ROOT = Path(__file__).resolve().parents[1]
FIXTURE = ROOT / 'tests/fixtures/compatibility/active_skill_evidence_20261123.json'


class RemoveSkillDiagnostics(ast.NodeTransformer):
    def __init__(self):
        self.counts = dict(imports=0, context_fields=0, snapshots=0, tap_method=0)

    def visit_ImportFrom(self, node):
        if node.module == 'pokiguard_v2.skill_action_evidence':
            self.counts['imports'] += 1
            return None
        return node

    def visit_Expr(self, node):
        call = node.value
        if isinstance(call, ast.Call) and isinstance(call.func, ast.Name):
            if call.func.id == 'emit_retained_skill_outcomes_safely':
                self.counts['snapshots'] += 1
                return None
            if (call.func.id == '_write' and len(call.args) > 1
                    and isinstance(call.args[1], ast.Constant)
                    and call.args[1].value == 'pet_skill_dispatch_started'):
                keep = []
                for kw in call.keywords:
                    if (kw.arg is None and isinstance(kw.value, ast.Call)
                            and isinstance(kw.value.func, ast.Name)
                            and kw.value.func.id == 'context_fields_safely'):
                        self.counts['context_fields'] += 1
                    else:
                        keep.append(kw)
                call.keywords = keep
        return self.generic_visit(node)

    def visit_ClassDef(self, node):
        if node.name == 'DispatcherTransportTap':
            keep = []
            for item in node.body:
                if isinstance(item, ast.FunctionDef) and item.name == 'skill_outcome_snapshot':
                    self.counts['tap_method'] += 1
                else:
                    keep.append(item)
            node.body = keep
        return self.generic_visit(node)


def ast_hash(tree):
    return hashlib.sha256(ast.dump(tree, include_attributes=False).encode()).hexdigest()


class SkillDiagnosticIsolationTests(unittest.TestCase):
    def test_erasing_only_reviewed_diagnostics_restores_exact_controller_and_tap_ast(self):
        data = json.loads(FIXTURE.read_text(encoding='utf-8'))
        u4 = json.loads((ROOT / 'tests/fixtures/compatibility/u4_core_20261125.json').read_text(encoding='utf-8'))
        self.assertFalse(data['runtime_profile_authority'])
        self.assertFalse(data['native_acceptance'])
        for name, record in data['reviewed_files'].items():
            tree = ast.parse((ROOT/name).read_text(encoding='utf-8-sig'))
            strip = RemoveSkillDiagnostics()
            restored = strip.visit(copy.deepcopy(tree))
            self.assertEqual(record['erased_node_counts'], strip.counts, name)
            expected = record['baseline_ast_sha256']
            later = u4['reviewed_files'].get(name, {})
            if 'skill_isolation_baseline_ast_sha256' in later:
                # A later reviewed change starts from this pinned baseline and records the next one.
                self.assertEqual(expected, later['skill_isolation_previous_ast_sha256'], name)
                expected = later['skill_isolation_baseline_ast_sha256']
            self.assertEqual(expected, ast_hash(restored), name)

    def test_helpers_are_in_pet_skill_branch_and_export_follows_result(self):
        tree = ast.parse((ROOT/'tools/basic_auto_bot.py').read_text(encoding='utf-8-sig'))
        branches = [n for n in ast.walk(tree) if isinstance(n, ast.If)
                    and ast.unparse(n.test) == 'decision.action is PolicyAction.PET_SKILL'
                    and any(isinstance(x, ast.ImportFrom) and x.module == 'pokiguard_v2.skill_action_evidence'
                            for x in n.body)]
        self.assertEqual(1, len(branches))
        body = branches[0].body
        helpers = [i for i, n in enumerate(body) if isinstance(n, ast.Expr)
                   and isinstance(n.value, ast.Call) and isinstance(n.value.func, ast.Name)
                   and n.value.func.id == 'emit_retained_skill_outcomes_safely']
        self.assertEqual(1, len(helpers))
        previous = body[helpers[0]-1].value
        self.assertEqual('_write', previous.func.id)
        self.assertEqual('pet_skill_dispatch_result', previous.args[1].value)


if __name__ == '__main__':
    unittest.main()
