"""Offline full controller fixture: native surfaces are explicit fakes.

The policy, mapping, actionability, pending/ACK and final preflight are real.
There is no game handle, memory reader, native backend or input capability.
"""
from contextlib import ExitStack, redirect_stdout
from dataclasses import dataclass, replace
import io
import json
import random
from types import SimpleNamespace
from unittest.mock import Mock, patch

from pokiguard_v2.memory_board_provider import ProviderMetrics, ProviderPoll
from pokiguard_v2.sequence_desync import SequenceDesyncTracker, SequenceEventRing
from pokiguard_v2.win32_input import (ClientGeometry, WindowBinding, WindowStatus,
                                    ClickPairResult, ClickStatus, AdaptiveSwapPacer)
from tests.test_actionability import actionable_state
from tests.test_basic_policy import combat_state
from tools import basic_auto_bot as bot
from tools.idle_state_watch import MatchRuntime
from tools.sequence_desync_runtime import RuntimeSequenceObservation
from tests.game_update_fixture import before_game_update_path


def before_shared_guard_path(root,name):
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_main_pilot_20261016_v1/shared_guard_remediation'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='e1aaa32d167827729082c38894da6232c86495b3357689bad8259d42cd34a4b8'
    manifest=json.loads(raw);assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
        'src/pokiguard_v2/reasoning_swap_timing.py','tools/qualify_reasoning_operational.py'}
    d2=root/'docs/phase5/artifacts/5d2_skill_rush_v1/offline_completion_v1'
    current_path=before_game_update_path(root,name)
    # E1 extends only admission. Verify its exact successor, then rewind to
    # the byte-exact Mega predecessor before the existing historical chain.
    e1_pins={'src/pokiguard_v2/reasoning_operational.py':
        'f9c668cb4a2a6b663ec75af364dd90514b693c9e09dbb18b2e343675884ed257',
        'src/pokiguard_v2/reasoning_operational_launch.py':
        '1ea8592ca4ab0915c9de0fb5ec81a974fd1df127e08cf3d95dd5e756ba74f438',
        'tests/test_reasoning_readiness.py':
        '700adc0b54c52258226db8f297c9caba945bc699af7d5a527d97edb3ca331953'}
    if name in e1_pins:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==e1_pins[name],name
        frozen=root/'docs/phase5/artifacts/5e1_comparison_20261019'
        previous=json.loads((frozen/'before_source.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='aeab13c20e003ada3d24a0afbc8c32cbc2f28661f45b1a7a80b34814699efe57'
        current_path=frozen/'before_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # Current Mega successor is pinned before auditing any historical source.
    mega_pins={'src/pokiguard_v2/reasoning_full_action_planner.py': '3054f7d3433de869a09914e8c035d52bb36cebad0b84032cc62555b72ddeed3d', 'src/pokiguard_v2/reasoning_full_actions.py': '40b0bfefb219a279344da7d8963ee8dcc48a3d3b3bd61f5677885e4ff7b360ef', 'src/pokiguard_v2/reasoning_operational.py': '0a46dbf96810d8197de420b8c78224aeb0fd8bc87841ceb4152311809ab5b2f0', 'src/pokiguard_v2/reasoning_operational_launch.py': '1a0f86f4b6eacab1e6b07634bb3a1e1e2e9611facdfe22bbd1f8f7465c14410f', 'src/pokiguard_v2/reasoning_runner.py': 'cd21768d91e5512f4ce2f1147d0c6150198c007be8dfd2b5e672cd4202fdc86a', 'src/pokiguard_v2/reasoning_selection.py': 'f58bdb31fa60e72565b7a11312ce48e98ca5a5b8a1fc0ca40ffb9ecb1074cb7e', 'src/pokiguard_v2/reasoning_mega_timing.py': 'c8406450e32fffbecd0a8d7cc43ef0f94d020f48633d42f8fb4e6079042a25fc', 'src/pokiguard_v2/reasoning_swap_timing.py': '00172cfad0334323ce5ffa4fe2e5079580b9755e6aa370a6afc4a33c4c0b334c'}
    mega_pins.update({'tests/test_reasoning_shared_guard.py': '776713735e2b9ed879c24ba352afe7111b4b644f56a0f294f56ca6b94256827c', 'tests/test_reasoning_planner.py': '54881827785bfac280507e7e8145af4a6b60271d1a9bfc3c5e49432573ebe152'})
    if name in mega_pins:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==mega_pins[name],name
        frozen=root/'docs/phase5/artifacts/5d4_input_repeat1_live_20261018_143456'
        previous=json.loads((frozen/'native_source_manifest.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='efc3887a67ad352fcd6d5e654f1afb07937b0119fc1279030d789a8159077e6a'
        current_path=frozen/'native_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # Pin the failed D4 probe separately. Its dispatch-only remediation never
    # rebinds historical native timing or gameplay acceptance.
    remediation_pins={'src/pokiguard_v2/reasoning_calibration.py':'f808a0715c16d4c8f6560cf302964f98a183921971a9e4a02aef656fa46a36f5',
        'src/pokiguard_v2/reasoning_swap_timing.py':'01ea9e226af17d4718701a0cd822fd09c6c0172aef62bb7a28ca8845bb06127d'}
    if name in remediation_pins:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==remediation_pins[name],name
        frozen=root/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726'
        previous=json.loads((frozen/'native_source_manifest.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='97d97cdb8215b7716fbb3586a64e4b0fe4126170896a599730fa822c900a61ad'
        current_path=frozen/'native_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # D4's input-only probe adds setup admission; historical control remains330.
    if name=='src/pokiguard_v2/reasoning_calibration.py':
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='ca806c1d3157918a34a93e73a0cd80612c9bdee350e22931d51dbd794003dfe1',name
        frozen=root/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121'
        previous=json.loads((frozen/'native_source_manifest.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='218d0e6c39a532d9da0c197ccbccceab459289282d087db1545699019f99f1df'
        current_path=frozen/'native_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # D4's observation-only successor keeps historical D3/D2/D1 source exact.
    if name=='src/pokiguard_v2/reasoning_calibration.py':
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='3e8769e6c3ca7289f987b55d74acc40525f572dd9c5573d4e7e679b19fd8b6a3',name
        frozen=root/'docs/phase5/artifacts/5d4_mega_acceptance_20261018'
        previous=json.loads((frozen/'before_source.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='00b19780f78fae906b84df47d4d67af6f085abc0df834822f4c9c6ce15a09702'
        current_path=frozen/'before_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # The twenty-match extension changes setup admission only. Historical
    # acceptance still runs on its exact predecessor, never on relabelled bytes.
    multiplier20_pins={'src/pokiguard_v2/reasoning_operational.py': '3082a784059d0ec45ed37ca4df48e293be0b194581f286307774ef23760a5ef3', 'src/pokiguard_v2/reasoning_operational_launch.py': '7b3a28e5f5071c1e0bd37c2c2f46a46bbeb2b3577304a9137656b3847c1a49b2'}
    if name in multiplier20_pins:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==multiplier20_pins[name],name
        frozen=root/'docs/phase5/artifacts/5d3_multiplier20_20261018'
        previous=json.loads((frozen/'before_source.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='b83cf22772db04df8cf6b5c466e313aab506180eb684c60244a1b27f320badf5'
        current_path=frozen/'before_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # D3 minimum successor is pinned before historical D2/D1 audits.
    demon_pins={'src/pokiguard_v2/reasoning_operational.py': '74bd663a9af88d8b12e5f9172ed33a47179bdd4222ff680f1d48a71b685d2050', 'src/pokiguard_v2/reasoning_operational_launch.py': '2eb79bb9df7b64f559ee03e9df83ef46f73e308e9450dfe790c26319fa57f234', 'src/pokiguard_v2/reasoning_planner.py': '78cbbd00772ac55e46aa1ffa6f775c2a1cf3251e879ddb482076e65d0e78a532', 'src/pokiguard_v2/reasoning_pilot.py': 'ef97703a2f4ef539aab59585f183725516e467975790c244ba0b80d922b09eeb', 'src/pokiguard_v2/reasoning_selection.py': '9ce66a1741163cf4688fd767598bf98a5c88f84c6c7c3ad2a51d1a236d909672'}
    if name=='tests/test_reasoning_planner.py':
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='ba5bf9476cf82974d2d0a557daf49dc00977022732da3c103a7fef4776a7a706',name
        current_path=root/'docs/phase5/artifacts/5d3_demon_reasoning_20261018/before_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='ac4b53467a2c493aeb3bc06ee95cc18eacda376ad08ff4e01b0fb0bc30447567',name
    if name in demon_pins:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==demon_pins[name],name
        frozen=root/'docs/phase5/artifacts/5d3_demon_reasoning_20261018'
        previous=json.loads((frozen/'before_source.json').read_text(encoding='utf-8'))
        assert previous['fingerprint']=='f397a136d1eafb8f4b2f6159716469d1378c1a4977ba36f254282c6fcecc09ba'
        current_path=frozen/'before_source'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==previous['files'][name],name
    # D3 adds one setup-only BASIC control branch. Pin that successor exactly,
    # then audit the byte-exact predecessor through the existing D2/D1 chain.
    if name=='src/pokiguard_v2/reasoning_calibration.py':
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='7b293ffbf422ed42a35d54b7e815a5ff4ca30e4ab0036d9c0ca4cfd7189c2bfc',name
        current_path=root/'docs/phase5/artifacts/5d3_demon_acceptance_20261018/before_source/reasoning_calibration.py'
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='f3a6abecec04364d94fbcd63a9eaae0f57c7fd511d5e56e95d4a3b7f23540911',name
    # D2 PASS proof binding is a reviewed successor. Verify the exact new
    # selector, then feed its saved predecessor into the historical audit.
    # No historical acceptance is rebound and no hash assertion is waived.
    if name=='src/pokiguard_v2/reasoning_selection.py':
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='5375cad8c08d79f21ffea12907ddbc2b1bbb2a3e4b4cd3a3e2bb0d94c98243ce',name
        current_path=root/'docs/phase5/artifacts/5d2_pass_authority_closeout_20261017/before'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()=='6301d58b80c371a9a97842a9780cb01de42fb081d72dd37a86c25d253a895f0c',name
    d2_manifest=d2/'runtime_boundary.json'
    if d2_manifest.exists():
        current=json.loads(d2_manifest.read_text(encoding='utf-8'))
        if name in current['changed_files']:
            assert hashlib.sha256(current_path.read_bytes()).hexdigest()==current['changed_files'][name],name
            current_path=d2/'before'/name
            assert hashlib.sha256(current_path.read_bytes()).hexdigest()==current['before_files'][name],name
    # D2's earlier BASIC skill instrumentation is also a historical successor,
    # not a re-certification of the D1 shared-guard source bytes.
    timing=root/'docs/phase5/artifacts/5d2_skill_rush_v1/pre_skill_timing'/name
    if timing.exists():
        phase=d2.parent
        after=json.loads((phase/'action_source_freeze.json').read_text(encoding='utf-8'))['files']
        before=json.loads((phase/'source_freeze.json').read_text(encoding='utf-8'))['files']
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==after[name],name
        assert hashlib.sha256(timing.read_bytes()).hexdigest()==before[name],name
        current_path=timing
    if name=='src/pokiguard_v2/reasoning_calibration.py':
        phase=d2.parent
        control=json.loads((phase/'source_freeze.json').read_text(encoding='utf-8'))['files']
        original=json.loads((phase/'before_source.json').read_text(encoding='utf-8'))['files']
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==control[name],name
        current_path=phase/'before'/name
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==original[name],name
    if name in manifest['files']:
        assert hashlib.sha256(current_path.read_bytes()).hexdigest()==manifest['files'][name],name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory/'before'/name if name in manifest['files'] else current_path


def before_d1_closeout_path(root,name):
    """Exact consolidated D1 pairs; historical reviews keep their own bytes."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_offline_closeout_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='ff360eef28ec12776fdc759ef53f462540173e7c2c24f63d09c0f9f96a26e297'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
        'src/pokiguard_v2/reasoning_operational_launch.py','src/pokiguard_v2/reasoning_swap_timing.py',
        'tools/qualify_reasoning_operational.py'}
    if name in manifest['files']:
        assert hashlib.sha256(before_shared_guard_path(root,name).read_bytes()).hexdigest()==manifest['files'][name],name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory/'before'/name if name in manifest['files'] else before_shared_guard_path(root,name)


def before_p27_path(root, name):
    """Exact P27 runtime pair; no waiver of any historical source check."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_config_projection_integration_p27_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='ab6f996d9074f51feecf4889808a08e63e72f06c70a0529a5f61ed5db7f9ee91'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
                                   'src/pokiguard_v2/reasoning_swap_timing.py',
                                   'tools/qualify_reasoning_operational.py'}
    if name in manifest['files']:
        assert hashlib.sha256(before_d1_closeout_path(root,name).read_bytes()).hexdigest()==manifest['files'][name],name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory/'before'/name if name in manifest['files'] else before_d1_closeout_path(root,name)


def before_p21_path(root, name):
    """Exact P21 pairs for historical fixture views, never native recertification."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_root_policy_p21_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='894cef103df662913574ac98f1b6653562ce73de185164068dd69d34d7a28247'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
        'src/pokiguard_v2/reasoning_pilot.py','src/pokiguard_v2/reasoning_swap_timing.py',
        'tools/qualify_reasoning_operational.py'}
    if name in manifest['files']:
        assert hashlib.sha256(before_p27_path(root,name).read_bytes()).hexdigest()==manifest['files'][name],name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory/'before'/name if name in manifest['files'] else before_p27_path(root,name)


def before_p18_path(root, name):
    """Exact P18 successor; earlier acceptances remain on their own bytes."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_source_timing_rebind_p18_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='77f7dbc33aa9156c9f9b57fedf35edba78e0c551a628a8e93906dbb28215b68e'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    for n,expected in manifest['files'].items():
        assert hashlib.sha256(before_p21_path(root,n).read_bytes()).hexdigest()==expected,n
    for n,expected in manifest['before_files'].items():
        assert hashlib.sha256((directory/'before'/n).read_bytes()).hexdigest()==expected,n
    return directory/'before'/name if name in manifest['before_files'] else before_p21_path(root,name)


def before_p16_path(root, name):
    """Exact remediation bytes, not a generic exemption or native acceptance."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_operational_remediation_p16_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='19f2dc504345bd594a01108c6398f9b6bc75a13c4a82b06415bb87bf2736acb5'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
        'src/pokiguard_v2/reasoning_pilot.py','tools/qualify_reasoning_operational.py'}
    for n,expected in manifest['files'].items():
        assert hashlib.sha256(before_p18_path(root,n).read_bytes()).hexdigest()==expected,n
        assert hashlib.sha256((directory/'before'/n).read_bytes()).hexdigest()==manifest['before_files'][n],n
    return directory/'before'/name if name in manifest['files'] else before_p18_path(root,name)


def before_p14_path(root, name):
    """Exact setup-only launch successor; preserve P13 historical bytes."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_operational_launch_p14_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='1c645e9fa94de2c285921ab9f002c3bbd5d9aac96da28632be0b99f89b132ebd'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py','tools/desktop_ui.py'}
    for n,expected in manifest['files'].items():
        assert hashlib.sha256(before_p16_path(root,n).read_bytes()).hexdigest()==expected,n
        assert hashlib.sha256((directory/'before'/n).read_bytes()).hexdigest()==manifest['before_files'][n],n
    return directory/'before'/name if name in manifest['files'] else before_p16_path(root,name)


def before_p13_path(root, name):
    """Exact scoped successor; keeps all historical acceptance on old bytes."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_calibration_review_p13_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='486c93c536c1940d4cfff3a68909a104f000c151bcacd6e1c4cc7c311ad1070b'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    assert set(manifest['files'])=={'src/pokiguard_v2/reasoning_operational.py',
        'src/pokiguard_v2/reasoning_pilot.py','tools/qualify_reasoning_operational.py'}
    for n,expected in manifest['files'].items():
        assert hashlib.sha256(before_p14_path(root,n).read_bytes()).hexdigest()==expected,n
        assert hashlib.sha256((directory/'before'/n).read_bytes()).hexdigest()==manifest['before_files'][n],n
    return directory/'before'/name if name in manifest['files'] else before_p14_path(root,name)


def before_entry_fix_path(root, name):
    import hashlib
    directory=root/'docs/artifacts/attack_selected_entry_fix_20261015'
    raw=(directory/'successor_source_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='b15779e73d6e5a5c02107cbc6d32242bdb5a950a7373aaea7a98ac7480ba33cc'
    manifest=json.loads(raw)
    assert set(manifest['changed'])=={'src/pokiguard_v2/desktop_farm_controller.py',
        'src/pokiguard_v2/desktop_ui.py','tools/boss_entry.py'}
    parent=json.loads((directory/'before_snapshot.json').read_text(encoding='utf-8'))['source_files']
    for n in manifest['changed']:
        assert hashlib.sha256(before_p13_path(root,n).read_bytes()).hexdigest()==manifest['source_files'][n],n
        assert hashlib.sha256((directory/'before'/n).read_bytes()).hexdigest()==parent[n],n
    return directory/'before'/name if name in manifest['changed'] else before_p13_path(root,name)


def operational_baseline(root):
    """Exact P10 successor binding; never re-certifies historical acceptance."""
    import hashlib
    directory=root/'docs/phase5/artifacts/5d1_operational_timing_v1'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()=='06355bc3b31a2a76d97c5a938b5217a2c1e0bc5d8c5acdbcd9b0683696b15750'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    for name,expected in manifest['files'].items():
        assert hashlib.sha256(before_p13_path(root,name).read_bytes()).hexdigest()==expected,name
    for name,expected in manifest['before_files'].items():
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==expected,name
    return directory,manifest['before_files']


def before_operational_path(root,name):
    directory,files=operational_baseline(root)
    return directory/'before'/name if name in files else before_entry_fix_path(root,name)


def pet_skill_fault_baseline(root):
    """Bind the side fix separately; historical Phase 5 files stay immutable."""
    import hashlib
    directory=root/'docs/artifacts/mega_icarus_skill_stop_20261014'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==        '1eafd08f3c4a5db620f0754fe08dcc48baac2785bacee476e16228bf8273e9e2'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    for name,digest in manifest['files'].items():
        assert hashlib.sha256(before_operational_path(root,name).read_bytes()).hexdigest()==digest,name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory,manifest['files']


def style_switch_baseline(root):
    """Pin the UI-only Demon transition repair without rebinding C3."""
    import hashlib
    directory=root/'docs/artifacts/demon_style_switch_20261014'
    raw=(directory/'after_runtime_manifest.json').read_bytes()
    assert hashlib.sha256(raw).hexdigest()==\
        '204a197062f59fdf2d32dd554f19e8e7838f81b17640bf219b1ed47857e3fb28'
    manifest=json.loads(raw)
    assert manifest['historicalPhase5AcceptanceRebound'] is False
    files={**manifest['files'],**manifest['test_files']}
    assert set(files)=={'src/pokiguard_v2/desktop_ui.py','tests/test_pet_configuration_ui.py'}
    for name,digest in files.items():
        assert hashlib.sha256(before_operational_path(root,name).read_bytes()).hexdigest()==digest,name
        assert hashlib.sha256((directory/'before'/name).read_bytes()).hexdigest()==manifest['before_files'][name],name
    return directory,files


def assert_c3_source_compatibility(test):
    """One invocation's immutable fixture view; never persist verification cache.

    All original SHA assertions still run. Memoizing path resolution only
    within this invocation avoids exponential ancestry traversal. The next
    call, including a tamper test, verifies fresh bytes again.
    """
    from functools import lru_cache
    with ExitStack() as stack:
        for name in ('before_shared_guard_path','before_d1_closeout_path','before_p27_path','before_p21_path','before_p18_path','before_p16_path','before_p14_path',
                     'before_p13_path','before_entry_fix_path','operational_baseline',
                     'before_operational_path','pet_skill_fault_baseline','style_switch_baseline'):
            stack.enter_context(patch(__name__+'.'+name,lru_cache(maxsize=1024)(globals()[name])))
        return _assert_c3_source_compatibility(test)


def _assert_c3_source_compatibility(test):
    """Pin C3 sources plus the separately recorded Bú win runtime correction.

    Historical C3 acceptance remains bound to its original source manifest.
    The side correction has exact before/after hashes, not a generic allowlist
    for future edits to entry, gameplay or screenshots.
    """
    import ast
    import hashlib
    from pathlib import Path
    root=Path(__file__).resolve().parents[1]
    fault_dir,fault_files=pet_skill_fault_baseline(root)
    style_dir,style_files=style_switch_baseline(root)
    def bound_path(name):
        if name in style_files:return style_dir/'before'/name
        return fault_dir/'before'/name if name in fault_files else before_operational_path(root,name)
    artifacts=root/'docs/phase5/artifacts'
    before=json.loads((artifacts/'5c3_integration_v1/source_manifest.json').read_text(encoding='utf-8'))['files']
    allowed={'src/pokiguard_v2/reasoning_diagnostics.py','tests/test_reasoning_integration.py'}
    side_names={
        'src/pokiguard_v2/farm_cycle.py','src/pokiguard_v2/farm_run.py',
        'src/pokiguard_v2/postmatch_ui.py','src/pokiguard_v2/win32_screenshot.py',
        'tools/boss_entry.py','tools/farm_run.py',
    }
    # C4 changes only the optional controller seam. Pin both its C3 original
    # and reviewed C4 bytes; never re-label historical C3 live acceptance.
    c4_dir=artifacts/'5c4_guarded_selection_v1'
    c4=json.loads((c4_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))['files']
    pilot_dir=artifacts/'5d1_production_bridge_v1'
    pilot=json.loads((pilot_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))['files']
    p2_dir=artifacts/'5d1_timely_activation_v1'
    p2=json.loads((p2_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))['files']
    p3_dir=artifacts/'5d1_activation_readiness_v1'
    p3=json.loads((p3_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))['files']
    test.assertEqual(set(p3),{'src/pokiguard_v2/desktop_farm_controller.py','tools/farm_run.py',
        'tools/desktop_ui.py','src/pokiguard_v2/reasoning_swap_timing.py',
        'src/pokiguard_v2/reasoning_pilot_activation.py','src/pokiguard_v2/reasoning_calibration.py'})
    # Separate post-P3 Bú win presentation correction. Historical manifests
    # remain immutable; bind its original P3 bytes and the reviewed successor
    # exactly, rather than exempting FarmRun from future source checks.
    presentation_dir=root/'docs/artifacts/bu_win_postmatch_animation_20261012'
    presentation=json.loads((presentation_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))
    test.assertEqual(presentation['schema'],'bu_win_postmatch_presentation_20261012.v1')
    test.assertFalse(presentation['historicalPhase5AcceptanceRebound'])
    test.assertEqual(presentation['baseRuntimeManifest']['path'],
        'docs/phase5/artifacts/5d1_activation_readiness_v1/after_runtime_manifest.json')
    test.assertEqual(presentation['baseRuntimeManifest']['sha256'],
        hashlib.sha256((p3_dir/'after_runtime_manifest.json').read_bytes()).hexdigest())
    test.assertEqual(presentation['files'],{'tools/farm_run.py':
        '1637b356adf8b60165d7b0c3471a512ec75e0161d6e8f8a991d18190cab72e37'})
    for name,expected in presentation['files'].items():
        test.assertEqual(expected,hashlib.sha256((bound_path(name)).read_bytes()).hexdigest(),name+' Bú win presentation binding')
    for name,expected in p3.items():
        current=(presentation_dir/'before'/name) if name in presentation['files'] else bound_path(name)
        test.assertEqual(expected,hashlib.sha256(current.read_bytes()).hexdigest(),name+' original D1-P3 binding')
    test.assertEqual(set(p2),{'tools/basic_auto_bot.py','tools/farm_run.py',
        'src/pokiguard_v2/reasoning_pilot.py','src/pokiguard_v2/desktop_farm_controller.py',
        'src/pokiguard_v2/win32_input.py'})
    # The Bú win Sword-risk pause correction changes only its exact guard
    # branch. Preserve the original P2 binding and pin the successor bytes.
    bu_win_dir=root/'docs/artifacts/bu_win_no_safe_move_20261013'
    bu_win=json.loads((bu_win_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))
    test.assertEqual(bu_win['schema'],'bu_win_no_safe_move_20261013.v1')
    test.assertFalse(bu_win['historicalPhase5AcceptanceRebound'])
    test.assertEqual(bu_win['baseRuntimeManifest']['path'],
        'docs/phase5/artifacts/5d1_timely_activation_v1/after_runtime_manifest.json')
    test.assertEqual(bu_win['baseRuntimeManifest']['sha256'],
        hashlib.sha256((p2_dir/'after_runtime_manifest.json').read_bytes()).hexdigest())
    test.assertEqual(bu_win['files'],{'tools/basic_auto_bot.py':
        '1413fc2f8dfc07a1bba76acc5aaefa3b627d94c0a146447d36939e8392d2bc6a'})
    for name,expected in bu_win['files'].items():
        test.assertEqual(expected,hashlib.sha256((bound_path(name)).read_bytes()).hexdigest(),name+' Bú win Sword-risk guard binding')
    for name,expected in p2.items():
        current=(bu_win_dir/'before'/name) if name in bu_win['files'] else ((p3_dir/'before'/name) if name in p3 else bound_path(name))
        test.assertEqual(expected,hashlib.sha256(current.read_bytes()).hexdigest(),name+' D1-P2 binding')
    test.assertEqual(set(pilot),{'tools/basic_auto_bot.py','src/pokiguard_v2/reasoning_selection.py'})
    for name,expected in pilot.items():
        current=(p2_dir/'before'/name) if name in p2 else bound_path(name)
        test.assertEqual(expected,hashlib.sha256(current.read_bytes()).hexdigest(),name+' D1-P1 binding')
    test.assertEqual(set(c4),{'tools/basic_auto_bot.py'})
    for name,expected in c4.items():
        test.assertEqual(before[name],hashlib.sha256((c4_dir/'before'/name).read_bytes()).hexdigest())
        test.assertEqual(expected,hashlib.sha256((pilot_dir/'before'/name).read_bytes()).hexdigest(),name+' original C4 seam')
    side_dir=root/'docs/artifacts/bu_win_runtime_fix_20261011'
    side=json.loads((side_dir/'after_source_manifest.json').read_text(encoding='utf-8'))
    original=json.loads((side_dir/'before_manifest.json').read_text(encoding='utf-8'))['files']
    test.assertEqual(set(side['files']),side_names)
    for name in side_names:
        test.assertEqual(before[name],original[name],name+' original C3 binding')
        test.assertEqual(before[name],hashlib.sha256((side_dir/'before'/name).read_bytes()).hexdigest())
        current=(p2_dir/'before'/name) if name in p2 else bound_path(name)
        test.assertEqual(side['files'][name],hashlib.sha256(current.read_bytes()).hexdigest(),name+' side correction changed')
    for name,digest in before.items():
        if name not in allowed|side_names|set(c4):
            current=(p2_dir/'before'/name) if name in p2 else ((p3_dir/'before'/name) if name in p3 else bound_path(name))
            test.assertEqual(digest,hashlib.sha256(current.read_bytes()).hexdigest(),name)
    def tree(text):return ast.parse(text)
    def dump(node):return ast.dump(node,include_attributes=False)
    def normalize(node):
        if isinstance(node,list):
            return [normalize(n) for n in node if not (isinstance(n,ast.Assign) and
                any(isinstance(t,ast.Name) and t.id=='file_stamp' for t in n.targets))]
        if isinstance(node,ast.Name) and node.id=='file_stamp':
            return ast.Call(func=ast.Attribute(value=ast.Name(id='time',ctx=ast.Load()),attr='time_ns',ctx=ast.Load()),args=[],keywords=[])
        if isinstance(node,ast.AST):
            for field,value in ast.iter_fields(node):setattr(node,field,normalize(value))
        return node
    directory=artifacts/'5c3_rotation_remediation_v1'
    for name in allowed:
        old=(directory/name.replace('/','__')).read_bytes()
        test.assertEqual(before[name],hashlib.sha256(old).hexdigest())
        original=tree(old.decode('utf-8'));current=tree((bound_path(name)).read_text(encoding='utf-8'))
        if name.startswith('src/'):
            writer=next(n for n in current.body if isinstance(n,ast.FunctionDef) and n.name=='_disk_writer')
            assignments=[n for n in ast.walk(writer) if isinstance(n,ast.Assign) and
                any(isinstance(t,ast.Name) and t.id=='file_stamp' for t in n.targets)]
            test.assertEqual(len(assignments),2)
            expected=['file_stamp = 0','file_stamp = _next_log_stamp(paths, previous=file_stamp, now=time.time_ns(), stem=stem)']
            test.assertEqual([dump(n) for n in assignments],[dump(ast.parse(s).body[0]) for s in expected])
            helper=next(n for n in current.body if isinstance(n,ast.FunctionDef) and n.name=='_next_log_stamp')
            for call in (n for n in ast.walk(helper) if isinstance(n,ast.Call)):
                if isinstance(call.func,ast.Name):test.assertIn(call.func.id,('max','int','len'))
                else:test.assertIsInstance(call.func,ast.Attribute);test.assertIn(call.func.attr,('isascii','isdigit'))
            current.body=[n for n in current.body if not (isinstance(n,ast.FunctionDef) and n.name=='_next_log_stamp')]
            for n in current.body:
                if isinstance(n,ast.FunctionDef) and n.name=='_disk_writer':normalize(n)
        else:
            for module in (original,current):
                for n in module.body:
                    if isinstance(n,ast.ClassDef) and n.name=='ReasoningIntegrationTests':
                        n.body=[m for m in n.body if not (isinstance(m,ast.FunctionDef) and m.name in
                            ('test_all_c2_sources_are_byte_preserved','test_c2_sources_preserved_except_documented_AI_rotation_fix'))]
        test.assertEqual(dump(original),dump(current),name+' changes exceeded documented rotation/audit scope')


def frozen_rotation_writer(*args):
    from pokiguard_v2.reasoning_diagnostics import _disk_writer
    with patch('pokiguard_v2.reasoning_diagnostics.time.time_ns',return_value=1_791_650_000_000_000_000):
        _disk_writer(*args)


@dataclass(frozen=True)
class OfflineTapDiagnostics:
    armed_match_id: str | None = None
    healthy: bool = False


def controller_trace(path, adapter=None, case='normal', *, controller_module=None,
                     initial_combat=None, selection_factory=None, profile='simple',
                     checkpoint_hook=None, target_pid=0, real_processing_clock=False,
                     timing_factory=None, timer_source="OFFLINE_VALID", gameplay_config=None):
    bot = controller_module or globals()['bot']
    calls=[]; loop=0; polls=0; sent=None; now=100.0
    combat=initial_combat or combat_state()
    state=replace(combat,battle=replace(actionable_state().battle,
        turn_number=14,srv_seq=14,current_turn_player='happi',
        turn_time_remaining_seconds=12,turn_duration_seconds=14,turn_timer_source=timer_source,
        local_move_sequence=0,last_move_sequence=0))
    if case in ('dinosaur_opening_missed', 'dinosaur_opening_ready'):
        state=replace(state,battle=replace(state.battle,turn_number=1,
            turn_time_remaining_seconds=0 if case == 'dinosaur_opening_missed' else 12))
    def running():
        nonlocal loop
        loop+=1;calls.append('process.is_running')
        if loop>(7 if case=='dinosaur_repeat_missed' else 5):raise AssertionError('offline controller did not stop')
        return True
    def sleep(seconds):
        nonlocal now
        now+=seconds;calls.append('clock.sleep')
    def current_runtime(final=False):
        turn=14;owner='happi';seq=0;coords=(None,)*4;ack=14
        if case == 'dinosaur_repeat_missed':
            count=calls.count('FAKE_NORMAL_INPUT')
            turn=(1 if count==0 else 2) if loop<=1 else 2 if loop==2 else 3 if loop==3 else 5 if count<2 else 6
            owner='boss' if turn in (2,6) else 'happi'
            seq=count;ack=13+turn
            if sent is not None:
                coords=(sent.first[1],7-sent.first[0],sent.second[1],7-sent.second[0])
            return MatchRuntime(state.battle.match_id,turn,owner,'happi',0 if loop==3 else 12,seq,seq,*coords,ack)
        if case == 'dinosaur_opening_missed':
            turn=1 if loop <= 1 else 3
        if case == 'dinosaur_opening_ready':turn=1
        if sent is not None and case not in ('pending','dinosaur_win_after_action'):
            turn=4 if case == 'dinosaur_opening_missed' else 2 if case == 'dinosaur_opening_ready' else 15
            owner='boss';seq=1;ack=15
            coords=(sent.first[1],7-sent.first[0],sent.second[1],7-sent.second[0])
        if final and case=='wrong_turn':owner='boss'
        remaining=2 if final and case=='reserve_final' else 12
        if case == 'dinosaur_opening_missed' and loop <= 1:
            remaining=0
        return MatchRuntime(state.battle.match_id,turn,owner,'happi',remaining,seq,seq,*coords,ack)
    def read_runtime(_):
        nonlocal now
        calls.append('runtime.read')
        # The startup read has no active combat; actual provider owns activation.
        if polls==0:return None,replace(current_runtime(),match_id=None)
        if case=='final_late':now=112.0
        if checkpoint_hook is not None:checkpoint_hook('final',polls)
        return None,current_runtime(final=True)
    def poll(*args,**kwargs):
        nonlocal polls,now
        polls+=1;calls.append('provider.poll')
        if case=='late_fresh' and polls>1:now=105.0
        if checkpoint_hook is not None:checkpoint_hook('poll',polls)
        fresh=state
        if case == 'dinosaur_repeat_missed':
            current=current_runtime()
            fresh=replace(state,battle=replace(state.battle,turn_number=current.turn,
                current_turn_player=current.current_player,srv_seq=current.highest_acked_sequence,
                turn_time_remaining_seconds=current.remaining,local_move_sequence=current.local_move_sequence,
                last_move_sequence=current.last_move_sequence,last_move_from_col=current.last_move_from_col,
                last_move_from_row=current.last_move_from_row,last_move_to_col=current.last_move_to_col,
                last_move_to_row=current.last_move_to_row))
        if case == 'dinosaur_opening_missed' and loop > 1:
            fresh=replace(state,battle=replace(state.battle,turn_number=3,
                                             turn_time_remaining_seconds=12))
        if case=='stale' and polls>1:
            fresh=replace(state,battle=replace(state.battle,turn_number=16,srv_seq=16))
        if case=='reserve_fresh' and polls>1:
            fresh=replace(state,battle=replace(state.battle,turn_time_remaining_seconds=2))
        if case=='stats_changed' and polls>1:
            fresh=replace(state,player=replace(state.player,mana=0))
        provider.last_published_state=fresh
        return ProviderPoll(fresh,True,'OFFLINE_VALID',
            lifecycle_event='board_found' if polls==1 else None,
            confirmations=2,session_key=state.battle.session_key)
    provider=SimpleNamespace(poll=poll,current_session_key=state.battle.session_key,
        current_board_instance=state.battle.board_instance,last_published_state=None,
        scan_diagnostics={'lobbyBaselineReady':True},metrics=ProviderMetrics(),
        observed_fusion=state.fusion,board_ws_owner_addresses=(),
        transport_region_hints=(),chat_message_region_hints=(),
        capture_transient_batches=lambda **_:(),refresh_pet_skill_cards=lambda *_,**__:None,
        read_current_combat_evidence=lambda:(state.participants,state.cards))
    if case in ('dinosaur_opening_missed','dinosaur_repeat_missed'):
        provider.scan_diagnostics.update(lastAcceptedSeq=14, lastAcceptedHash=state.battle.board_hash,
                                          highestAckedSequence=14)
    tracker=SequenceDesyncTracker()
    def transport_poll(**kwargs):
        calls.append('transport.poll')
        messages=()
        if case == 'dinosaur_win_event_active' or (case == 'dinosaur_win_after_action' and loop>=2):
            from tools.idle_state_watch import ServerMessage
            from dataclasses import fields, MISSING
            values={f.name:None for f in fields(ServerMessage)
                    if f.default is MISSING and f.default_factory is MISSING}
            values.update(address=123,event_type='MATCH_GAME_OVER',match_id=state.battle.match_id,
                timestamp='OFFLINE',username=None,payload_strings=(('winner','happi'),))
            messages=(ServerMessage(**values),)
        return RuntimeSequenceObservation(current_runtime(),messages,False)
    monitor=SimpleNamespace(tracker=tracker,events=SequenceEventRing(),has_scanned=True,
        begin_session=tracker.begin_session,end_session=tracker.end_session,poll=transport_poll,
        absorb_region_hints=lambda *_:None,absorb_chat_message_region_hints=lambda *_:None,
        needs_transport_gap_recovery=False)
    def window(_):
        calls.append('window.status')
        return WindowStatus(True,True,ClientGeometry(0,0,1280,640),'OFFLINE')
    def send_swap(binding,plan,**kwargs):
        nonlocal sent
        calls.append('FAKE_NORMAL_INPUT')
        # The durable fake ACK reports the exact ordered cells sent to this
        # executor, after the real controller mapping/preflight approved them.
        sent=SimpleNamespace(first=plan.first_cell,second=plan.second_cell)
        return ClickPairResult(ClickStatus.SENT,2,.35,'NORMAL','OFFLINE',0,0,0)
    executor=SimpleNamespace(window_status=window,send_swap=send_swap,
        cursor_settle_seconds=.06,backend=SimpleNamespace(mouse_button_hold_seconds=.075),
        swap_pacer=AdaptiveSwapPacer(),reset_swap_pacing_after_combat=lambda:None,
        note_swap_acknowledged=lambda seconds:calls.append('executor.ack'),
        note_swap_unconfirmed=lambda reason:calls.append('executor.unconfirmed'))
    target=SimpleNamespace(pid=target_pid,game_assembly=SimpleNamespace(base=1),is_running=running)
    binding=WindowBinding(0,0,'OFFLINE',1280,640)
    runtime=bot.SharedCombatRuntime(target,provider,monitor,binding,executor,
        SimpleNamespace(virtual_screen=lambda:(0,0,1280,640)))
    stop_iteration=2 if case in ('stale','wrong_turn','final_late','stats_changed','reserve_final') else 3
    if case == 'dinosaur_opening_missed':stop_iteration=4
    if case == 'dinosaur_repeat_missed':stop_iteration=6
    if case=='pet_skill_missing':stop_iteration=5
    hotkeys=SimpleNamespace(poll=lambda:(False,False,case=='stop' or loop>=stop_iteration),
        emergency_stop_requested=lambda:(case=='stop_after_fresh' and polls>1
            or case=='stop_before_input' and 'capture.modal' in calls
            or case=='stop_in_reasoning' and selection is not None
                and selection.bridge_counts.get('decision_wait_started',0)>0),pause_toggle_requested=lambda:False)
    tap=SimpleNamespace(diagnostics=OfflineTapDiagnostics(),
        arm=lambda *_:None,disarm=lambda:None,configure_runtime_owners=lambda **_:None,
        messages=lambda *_:(),runtime_batches=lambda *_:(),transport_board_snapshots=lambda *_:())
    tap_context=Mock();tap_context.__enter__=Mock(return_value=tap)
    tap_context.__exit__=Mock(return_value=False)
    args=bot.build_parser().parse_args(['--watch','--no-beep','--pass-acceptance-stage',
        'DISABLED','--play-style',profile,'--log',str(path)])
    if case=='pet_skill_missing':
        args.main_pet='mega';args.evolution_target='none'
        args.damage_card='pet_skill';args.audition_mode='none'
    if gameplay_config is not None:
        args.main_pet=gameplay_config.main_pet.value
        args.evolution_target=gameplay_config.evolution.value
        args.damage_card=gameplay_config.damage_card.value
        args.audition_mode=gameplay_config.audition_mode.value
        args.pet_skill_fire_condition=gameplay_config.pet_skill_fire_condition.value
        args.pet_skill_fire_value=gameplay_config.pet_skill_fire_value
    selection = None
    timing = None
    if selection_factory is not None or timing_factory is not None:
        config = bot.PolicyConfig(play_style=bot.PlayStyle(profile),
            mana_priority=bot.ManaPriority(args.mana_priority),
            minimum_turn_time_seconds=args.minimum_action_time,
            minimum_evolve_time_seconds=args.minimum_action_time)
        if gameplay_config is not None:
            config=replace(bot.basic_policy_config(gameplay_config),
                minimum_turn_time_seconds=args.minimum_action_time,minimum_evolve_time_seconds=args.minimum_action_time)
        if selection_factory is not None:
            selection = selection_factory(state, config)
        if timing_factory is not None:
            timing = timing_factory(state, config)
    def capture(_):
        calls.append('capture.modal')
        return SimpleNamespace(rgb=b'',width=1280,height=640)
    with ExitStack() as stack:
        import time as processing_clock
        from pokiguard_v2 import win32_input
        stack.enter_context(patch.object(win32_input,'random',random.Random(503)))
        for name,value in dict(AutoHotkeyEdges=lambda:hotkeys,
            DispatcherTransportTap=lambda _:tap_context,
            _prime_transport_for_runtime=lambda *_,**__:{},read_match_runtime=read_runtime,
            capture_client_rgb=capture,locate_confirm_leave=lambda *_:SimpleNamespace(found=False),
            utc_timestamp=lambda:'OFFLINE',time=SimpleNamespace(monotonic=lambda:now,sleep=sleep,
                perf_counter=processing_clock.perf_counter if real_processing_clock else lambda:now,
                perf_counter_ns=processing_clock.perf_counter_ns if real_processing_clock else lambda:int(now*1e9))).items():
            stack.enter_context(patch.object(bot,name,value))
        for name in ('attach_target','NativeWin32Backend','_create_shared_combat_runtime'):
            stack.enter_context(patch.object(bot,name,side_effect=AssertionError('native forbidden: '+name)))
        stack.enter_context(redirect_stdout(io.StringIO()))
        extra={} if selection_factory is None else {'selection_adapter':selection}
        if timing_factory is not None:
            extra['swap_timing_adapter']=timing
        result=bot.run(args,shared_runtime=runtime,shadow_adapter=adapter,**extra)
    rows=[json.loads(line) for line in path.read_text(encoding='utf-8').splitlines()]
    for row in rows:
        if row['event']=='auto_controller_started':row['config']['log']='OFFLINE_NORMALIZED_PATH'
    return result,calls,rows
