"""Exact c707 BASIC H/I boundary review. Never relabel raw source lineage."""
import ast
from copy import deepcopy
from pathlib import Path
from .reasoning_snapshot import digest,require
from .reasoning_calibration_review import document,read_ref

ORIGIN='c707890f44be01215f93876987c11f66fe4b19ad7b4ddefc33aeeb7d4e6b723f'
SCHEMA='pokiguard.reasoning.basic_boundary_review.v1'
CHANGED={
 'src/pokiguard_v2/reasoning_operational.py':{'OperationalPilotAuthority.__post_init__','OperationalPilotAuthority.identity'},
 'src/pokiguard_v2/reasoning_swap_timing.py':{'SwapTimingCollector._monitor_components'},
 'src/pokiguard_v2/reasoning_d1_native.py':{'validate_costs','verify_native','load_reviewed_authority'},
}
ADDED={'src/pokiguard_v2/reasoning_component_guard.py','src/pokiguard_v2/reasoning_native_boundary_review.py'}


def normalized(code,name):
    tree=ast.parse(code)
    def walk(body,prefix=''):
        result=[]
        for node in body:
            if isinstance(node,ast.AnnAssign) and prefix=='OperationalPilotAuthority.' and isinstance(node.target,ast.Name) and node.target.id=='component_guard_policy':
                continue
            if isinstance(node,(ast.FunctionDef,ast.AsyncFunctionDef)) and prefix+node.name in CHANGED[name]:
                node.body=[ast.Pass()]
            elif isinstance(node,ast.ClassDef):node.body=walk(node.body,prefix+node.name+'.')
            result.append(node)
        return result
    tree.body=walk(tree.body)
    return ast.dump(tree,include_attributes=False)


def verified_origin(directory,reference,*,current_sha256):
    from .reasoning_calibration import source_files,source_fingerprint
    root=Path(__file__).resolve().parents[2];review=document(directory,reference)
    before=document(directory,review['before_manifest'])['files'];after=source_files(root)
    require(review['schema']==SCHEMA and review['origin_sha256']==digest(before)==ORIGIN
        and review['current_sha256']==source_fingerprint(root)==current_sha256
        and review['basic_boundary_execution_unchanged'] is True,
        'exact c707 BASIC boundary review required')
    require(set(before)<=set(after),'native origin files removed')
    changed={n for n in before if n.startswith('src/') and before[n]!=after[n]}
    added={n for n in after if n.startswith('src/') and n not in before}
    require(changed==set(CHANGED) and added==ADDED and set(review['before_files'])==set(CHANGED),
        'unexpected runtime delta in native boundary review')
    require(all(before[n]==after[n] for n in before if n.startswith('tools/') and n!='tools/qualify_reasoning_operational.py'),
        'BASIC controller or other execution tools changed')
    for name in CHANGED:
        reference=review['before_files'][name]
        require(reference['sha256']==before[name],'native before-source bytes unbound')
        original=read_ref(directory,reference).decode('utf-8');current=(root/name).read_text(encoding='utf-8')
        require(normalized(original,name)==normalized(current,name),'BASIC boundary or unreviewed method changed')
    return dict(files=before,source_sha256=ORIGIN,current_source_sha256=current_sha256,
        scope='EXACT_BASIC_BOUNDARY_COMPATIBILITY_NOT_CURRENT_SOURCE_OBSERVATION')
