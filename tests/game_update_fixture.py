"""Exact historical file view for tests, never runtime/calibration authority.

Both current successor and saved predecessor must match the pinned side audit.
Unreviewed edits fail. The production build/source admission is untouched.
"""
from __future__ import annotations

import hashlib
import json
from pathlib import Path
from contextlib import contextmanager
from contextvars import ContextVar


MANIFEST_SHA256 = '5d6f0ba7367ade01edcf3188ff54cdb14b24a2cb7a7f90d73d813e249324efae'
MAPPING_MANIFEST_SHA256 = 'caf7670f28cecac6b4479a63734b209374ef4e019e98ce6d331500601a056d35'
RELEASE_MANIFEST_SHA256 = '67f15f62d2b06c4dc4f500116b9a03f6d44cd6e3604aafbbdf99e0a4a9ff83dc'
E1_CURRENT_MANIFEST_SHA256 = '74d8ef55832e9dba6a580063842093e9d2db25556d6e31588a343e25e95f958b'
B10_MANIFEST_SHA256 = '7108268edc136638c23641f74989bccf73179bd48a7ac2d30933fca84eb8362b'
DEMON_TARGET_MANIFEST_SHA256 = '1852b61bb993db8a955c0b32d2ed44f39ab9c370856ef814bc90fec41d2d975e'
DEMON_EFFECTIVE_MANIFEST_SHA256 = 'b2dab468c5b3ef8ad115fa698d1c1a82252a5316000fce25f67ee41f3cbd6a34'
RELEASE_127_MANIFEST_SHA256 = '5b1fe3f5051688122d36be0898e6d08dcab36b34431193e544a7bb0b53addea7'
_HISTORICAL_TEST_VIEW = ContextVar('1749_historical_test_view', default=False)
E1_B10_MANIFEST_SHA256 = 'de5bea3bf7d93bc90dfb174b8bb87d4904f04218040767e872d8cd0a88ef883e'


@contextmanager
def historical_test_view():
    """Explicit unit-test opt-in; ordinary qualification stays on real files."""
    token=_HISTORICAL_TEST_VIEW.set(True)
    try:
        yield
    finally:
        _HISTORICAL_TEST_VIEW.reset(token)


@contextmanager
def historical_config_shape():
    """Test-only decoder for archived requests that predate the target field.

    The real decoder continues to require a complete current configuration.
    This seam audits old raw telemetry; it never authorizes the current source.
    """
    from unittest.mock import patch
    from pokiguard_v2 import reasoning_calibration
    decode=reasoning_calibration.decode_config
    def archived(raw):
        if type(raw) is dict and 'demon_target_gem' not in raw:
            raw=dict(raw,demon_target_gem='shield')
        return decode(raw)
    with patch.object(reasoning_calibration,'decode_config',side_effect=archived):
        yield


def before_e1_b10_path(root: Path, name: str) -> Path:
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/phase5/artifacts/5e1_b10_requalification_20261022/completion'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==E1_B10_MANIFEST_SHA256, 'E1 b10 fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    row=manifest['changed_existing'].get(name)
    if row is None:
        return root/name
    assert hashlib.sha256((root/name).read_bytes()).hexdigest()==row['after'],name+' E1 b10 successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' E1 b10 predecessor changed'
    return saved


def before_release_127_path(root: Path, name: str) -> Path:
    """Rewind only the audited release label inside historical test context."""
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/artifacts/release_v1_2_7_20261022'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==RELEASE_127_MANIFEST_SHA256, 'v1.2.7 fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    current=before_e1_b10_path(root,name)
    row=manifest['changed_existing'].get(name)
    if row is None:
        return current
    assert hashlib.sha256(current.read_bytes()).hexdigest()==row['after'],name+' v1.2.7 successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' v1.2.7 predecessor changed'
    return saved


def before_demon_effective_path(root: Path, name: str) -> Path:
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/artifacts/demon_effective_sword_20261022'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==DEMON_EFFECTIVE_MANIFEST_SHA256, 'effective Sword fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    current=before_release_127_path(root,name)
    row=manifest['changed_existing'].get(name)
    if row is None:
        return current
    assert hashlib.sha256(current.read_bytes()).hexdigest()==row['after'],name+' effective successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' effective predecessor changed'
    return saved


def archived_demon_engine(root: Path, directory_name: str, config):
    """Frozen legacy policy for historical counterfactual tests, never runtime."""
    import importlib.util
    import inspect
    import sys
    from pokiguard_v2 import basic_policy as current
    directory=root/'docs/artifacts'/directory_name
    manifest=json.loads((directory/'before_source.json').read_text('utf-8'))
    assert manifest['fingerprint'] in {
        'b338383abe567d474c849ec157e0ad12338ccf07f2cb21d638b175004958fc77',
        '9fa67d8d3bca0cf9527104f0f7bedea0ec3b2183270e615eabaa7f5570ef8d80'}
    def module(stem):
        path=directory/'before/src/pokiguard_v2'/(stem+'.py')
        assert hashlib.sha256(path.read_bytes()).hexdigest()==manifest['files']['src/pokiguard_v2/'+stem+'.py']
        name='pokiguard_v2._archived_'+directory_name+'_'+stem
        spec=importlib.util.spec_from_file_location(name,path)
        value=importlib.util.module_from_spec(spec);sys.modules[name]=value;spec.loader.exec_module(value)
        return value
    geometry=module('demon_aegis');policy=module('basic_policy')
    # Keep public decision/enum identities shared; execute only archived rules.
    for name,value in tuple(vars(policy).items()):
        if inspect.isclass(value) and value.__module__==policy.__name__ and name!='BasicPolicyEngine':
            setattr(policy,name,getattr(current,name))
    policy.evaluate_demon_aegis_move=geometry.evaluate_demon_aegis_move
    return policy.BasicPolicyEngine(config)


def before_demon_target_path(root: Path, name: str) -> Path:
    """Historical b10 compatibility evidence predates configurable targets."""
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/artifacts/demon_target_gem_20261022'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==DEMON_TARGET_MANIFEST_SHA256, 'Demon target fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    current=before_demon_effective_path(root,name)
    row=manifest['changed_existing'].get(name)
    if row is None:
        return current
    assert hashlib.sha256(current.read_bytes()).hexdigest()==row['after'],name+' target successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' target predecessor changed'
    return saved


def before_b10_path(root: Path, name: str) -> Path:
    """Explicit historical test bytes; never a runtime build/source rebind."""
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/artifacts/game_1_7_4_b10_audit_20261022'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==B10_MANIFEST_SHA256, 'b10 fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    current=before_demon_target_path(root,name)
    row=manifest['changed_existing'].get(name)
    if row is None:
        return current
    assert hashlib.sha256(current.read_bytes()).hexdigest()==row['after'],name+' b10 successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' b10 predecessor changed'
    return saved


def before_game_update_path(root: Path, name: str) -> Path:
    if not _HISTORICAL_TEST_VIEW.get():
        return root/name
    directory=root/'docs/artifacts/game_1_7_4_9_20261020'
    # Rewind E1-only setup and the exact CLI argument repair for historical
    # tests. Ordinary current-source qualification never enters this context.
    e1=root/'docs/phase5/artifacts/5e1_requalification_1749_20261021/completion'
    e1_raw=(e1/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(e1_raw).hexdigest()==E1_CURRENT_MANIFEST_SHA256, 'E1 fixture manifest changed'
    e1_manifest=json.loads(e1_raw)
    assert e1_manifest['historical_acceptance_rebound'] is False
    current=before_b10_path(root,name)
    e1_row=e1_manifest['changed_existing'].get(name)
    if e1_row is not None:
        assert hashlib.sha256(current.read_bytes()).hexdigest()==e1_row['after'],name+' E1 successor changed'
        current=e1/'before'/name
        assert hashlib.sha256(current.read_bytes()).hexdigest()==e1_row['before'],name+' E1 predecessor changed'
    # The requested release changes only the version label and matching tests.
    # Preserve the byte-exact pre-release view for historical audits, without
    # granting the new source any historical native calibration authority.
    release=root/'docs/artifacts/release_v1_2_6_20261021'
    release_raw=(release/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(release_raw).hexdigest()==RELEASE_MANIFEST_SHA256, 'release fixture manifest changed'
    release_manifest=json.loads(release_raw)
    assert release_manifest['historical_acceptance_rebound'] is False
    release_row=release_manifest['changed_existing'].get(name)
    if release_row is not None:
        assert hashlib.sha256(current.read_bytes()).hexdigest()==release_row['after'],name+' release successor changed'
        current=release/'before'/name
        assert hashlib.sha256(current.read_bytes()).hexdigest()==release_row['before'],name+' release predecessor changed'
    # Preserve the original migration manifest. Rewind the separately audited
    # coordinate fix first, only within this explicit offline test context.
    mapping=directory/'board_mapping_fix_20261021'
    mapping_raw=(mapping/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(mapping_raw).hexdigest()==MAPPING_MANIFEST_SHA256, 'board mapping fixture manifest changed'
    mapping_manifest=json.loads(mapping_raw)
    assert mapping_manifest['historical_acceptance_rebound'] is False
    mapping_row=mapping_manifest['changed_existing'].get(name)
    if mapping_row is not None:
        assert hashlib.sha256(current.read_bytes()).hexdigest()==mapping_row['after'],name+' mapping successor changed'
        current=mapping/'before'/name
        assert hashlib.sha256(current.read_bytes()).hexdigest()==mapping_row['before'],name+' mapping predecessor changed'
    raw=(directory/'historical_fixture_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==MANIFEST_SHA256, 'game update fixture manifest changed'
    manifest=json.loads(raw)
    assert manifest['historical_acceptance_rebound'] is False
    assert manifest['base_fingerprint']=='7235ddc725d6777908cef04c5e557b14e8e12e28880ed6316453eb1cf0de4d28'
    row=manifest['changed_existing'].get(name)
    if row is None:
        return current
    assert hashlib.sha256(current.read_bytes()).hexdigest()==row['after'],name+' update successor changed'
    saved=directory/'before'/name
    assert hashlib.sha256(saved.read_bytes()).hexdigest()==row['before'],name+' update predecessor changed'
    return saved
