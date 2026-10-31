"""E1 Demon comparison admission and per-combat assignment, no game IO.

The existing FarmRunner owns entry, attempts, Stop, input and results. BASIC
combats receive no optional adapters. The existing operational session owns
workers only for REASONING combats. No policy switches occur within a combat.
"""
import hashlib
import json
from pathlib import Path
import threading
import time

from .reasoning_calibration_review import document, PARAMETERS
from .reasoning_demon import MODEL, VERSION
from .reasoning_snapshot import FrozenJSON, digest, require

PROTOCOL = 'E1_DEMON_LIEYUN20_BLOCKED_V1'
PREDECESSOR = 'aeab13c20e003ada3d24a0afbc8c32cbc2f28661f45b1a7a80b34814699efe57'
CHANGED = {'src/pokiguard_v2/reasoning_operational.py',
           'src/pokiguard_v2/reasoning_operational_launch.py',
           'tests/test_reasoning_mega_native.py', 'tests/reasoning_controller_fixture.py',
           'tests/test_reasoning_root_policy.py', 'tests/test_reasoning_mega_timing.py',
           'tests/test_reasoning_readiness.py'}
ADDED = {'src/pokiguard_v2/reasoning_comparison.py', 'tools/prepare_e1_comparison.py',
         'tests/test_reasoning_comparison.py'}


def check_config(config):
    require(config.play_style.value == 'demon_aegis_farm' and config.game_mode.value == 'solo'
        and config.intelligence.value == 'basic' and not config.ai.shadow_enabled
        and [getattr(config, k).value for k in ('main_pet', 'evolution', 'damage_card')]
            == ['normal', 'none', 'pet_passive']
        and config.pet_skill_fire_condition.value == 'sword_count' and config.pet_skill_fire_value == 4
        and config.demon_target_gem.value == 'shield'
        and config.normalized_boss_id == '1436'
        and config.target_completed_matches == config.max_match_attempts == 20
        and config.max_technical_recoveries == 0
        and config.input_delivery_mode.value == 'foreground' and config.board_input_mode.value == 'two_click'
        and config.ai.budget_ms == 4000, 'E1 frozen Demon/Lieyun77/setting4/20TOTAL/no recovery required')


def assignment(manifest):
    require(manifest['schema'] == 'pokiguard.e1.comparison_manifest.v1'
        and manifest['protocol'] == PROTOCOL and manifest['total_attempt_cap'] == 20
        and manifest['attempts_per_arm'] == 10 and manifest['no_automatic_extension'] is True
        and manifest['failed_entry_abort_included'] is True, 'bounded E1 manifest required')
    rows = manifest['assignment']
    require(type(rows) is list and len(rows) == 20, 'twenty frozen assignment slots required')
    arms = []
    for n, row in enumerate(rows):
        require(set(row) == {'slot', 'block', 'arm'} and row['slot'] == n + 1
            and row['block'] == n // 2 + 1 and row['arm'] in ('BASIC', 'REASONING'), 'invalid E1 slot')
        arms.append(row['arm'])
    require(all(set(arms[i:i+2]) == {'BASIC', 'REASONING'} for i in range(0, 20, 2))
        and sum(arms[i] == 'BASIC' for i in range(0, 20, 2)) == 5, 'balanced AB/BA blocks required')
    return tuple(arms)


def verify_boundary(directory, cal, runtime_sha256):
    from .reasoning_calibration import source_files
    root = Path(__file__).resolve().parents[2]
    before = document(directory, cal['e1_predecessor'])
    current = document(directory, cal['source_manifest'])
    require(before['fingerprint'] == digest(before['files']) == PREDECESSOR
        and current['fingerprint'] == digest(current['files']) == runtime_sha256
        and current['files'] == source_files(root), 'E1 source manifests unbound')
    old, new = before['files'], current['files']
    require(set(old) <= set(new)
        and {p for p, h in old.items() if new[p] != h} == CHANGED
        and set(new) - set(old) == ADDED, 'unreviewed E1 source boundary')
    # New admission is separate from old D3/D4 activations. The actual Demon
    # planner, controller, solver, reader, input, ACK, QTE and farm stay exact.
    return dict(changed=sorted(CHANGED), added=sorted(ADDED),
                unchanged=len(old)-len(CHANGED), predecessor_not_relabelled=True)


def load_reviewed_authority(directory, data, cal, request, *, policy_json, now):
    from .reasoning_demon_native import verify_native
    from .reasoning_operational import OperationalPilotAuthority, command_wait_ms
    from .reasoning_calibration import decode_config
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    check_config(decode_config(data['full_config']))
    require(data['pilot_protocol'] == PROTOCOL and data['total_attempt_cap'] == 20
        and data['root_read_policy'] == POLICY and data['component_guard_policy'] == GUARD
        and data['component_monitor'] == 'POST_RETURN_COMPONENTS_V1', 'E1 protocol mismatch')
    manifest = document(directory, data['comparison_manifest'])
    assignment(manifest)
    require(data['run_id'] == manifest['run_id']
        and manifest['source_sha256'] == request.runtime_sha256
        and manifest['full_config_sha256'] == request.full_config_sha256
        and manifest['game_build_sha256'] == request.verified_build_sha256
        and manifest['policy_json'] == policy_json, 'E1 frozen comparison drift')
    if cal.get('schema') == 'pokiguard.reasoning.e1_native_b10.v1':
        from .reasoning_e1_b10_native import verify_native as verify_current, verify_boundary as verify_current_boundary, RECOVERY_POLICY
        require(manifest.get('recovery_policy') == RECOVERY_POLICY,
                'E1 observed-recovery/slot exclusion and existing operator Stop required')
        native = verify_current(directory, cal)
        verify_current_boundary(directory, cal, request.runtime_sha256)
    elif cal.get('schema') == 'pokiguard.reasoning.e1_native_1749.v1':
        from .reasoning_e1_native import verify_native as verify_current, verify_boundary as verify_current_boundary, RECOVERY_POLICY
        require(manifest.get('recovery_policy') == RECOVERY_POLICY,
                'E1 observed-recovery/slot exclusion and existing operator Stop required')
        native = verify_current(directory, cal)
        verify_current_boundary(directory, cal, request.runtime_sha256)
    else:
        native = verify_native(directory, cal)
        verify_boundary(directory, cal, request.runtime_sha256)
    require(native['host_sha256'] == request.host_sha256
        and native['game_build_sha256'] == request.verified_build_sha256
        and data['witness'] == native['witness']
        and data['scope'] == dict(account_binding=native['witness']['account_username_sha256'],
                                 boss='1436', loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'),
        'E1 native cohort mismatch')
    profile = dict(MODEL, account_sha256=native['witness']['account_username_sha256'],
                   player_stats=native['player_stats'])
    require(data['demon_profile'] == profile, 'E1 Demon certificate drift')
    q = document(directory, data['selector_allowance'])
    costs = document(directory, q['raw_costs'])
    require(q['status'] == 'PASS' and q['source_sha256'] == request.runtime_sha256
        and q['host_sha256'] == request.host_sha256 and q['profile_version'] == VERSION
        and q['cycles'] >= 100 and q['loss'] == 0 and q['worker_roundtrip_pass']
        and q['controller_byte_exact'] and len(costs) == q['cycles']
        and all(type(v) in (int, float) and 0 <= v <= 30 for v in costs)
        and max(costs) == q['selector_extra_ms'], 'E1 own selector qualification required')
    a = document(directory, data['activation_review'])
    require(a['pilot_protocol'] == PROTOCOL and a['manual_start_only'] is True
        and a['comparison_sha256'] == data['comparison_manifest']['sha256']
        and a['calibration_sha256'] == data['calibration']['sha256']
        and a['selector_allowance_sha256'] == data['selector_allowance']['sha256']
        and a['component_guard_policy'] == GUARD
        and type(a['operator_authorization']) is str and bool(a['operator_authorization'].strip()),
        'E1 separate bounded activation required')
    components = dict(controller_tail_ms=native['H_ms'], final_input_ms=native['I_ms'],
        selector_extra_ms=max(costs), command_wait_ms=command_wait_ms(**PARAMETERS), host_guard_ms=250)
    return OperationalPilotAuthority('demon_aegis_farm', policy_json, FrozenJSON.of(data['scope']),
        FrozenJSON.of(data['witness']), FrozenJSON.of(data['model']), request.verified_build_sha256,
        request.runtime_sha256, request.host_sha256, request.contract_sha256, request.decision_sha256,
        data['calibration']['sha256'], FrozenJSON.of(components), FrozenJSON.of(PARAMETERS), 100, native['ack_samples'],
        time.perf_counter_ns()+int((data['expires_at']-now)*1e9), return_margin_ms=100,
        budget_ms=4000, root_read_policy=FrozenJSON.of(POLICY), component_guard_policy=GUARD,
        demon_profile=FrozenJSON.of(profile))


class ComparisonSession:
    """Use the existing once-per-combat seam, with no recovered handoff/resume.

    A technical failure must end the evaluation through the existing Stop
    owner. The legacy recovery field does not disable normal farm recovery;
    any observed recovery/slot mismatch invalidates this comparison. Keep
    failed attempts even when prepare was never called; never reassign them.
    Missing R adapters remain assigned R in the analysis, never become controls.
    """
    def __init__(self, core, arms):
        self.core, self.arms = core, tuple(arms)
        self.bound = self.stopped = self.core_bound = False
        self.prepares = []
        self.finalizer = None

    def bind_run(self, farm_run_id, directory):
        require(not self.bound and not self.stopped, 'E1 run already bound/stopped')
        self.bound = True
        self.farm_run_id, self.farm_directory = farm_run_id, str(Path(directory).resolve())
        # No core bind/worker for BASIC. Existing finalizer starts only at first R.

    def prepare_options(self):
        if self.stopped or not self.bound:
            return {}
        n = len(self.prepares)
        require(n < len(self.arms) == 20, 'E1 assignment cap exhausted')
        row = dict(slot=n+1, arm=self.arms[n], adapter_available=False)
        self.prepares.append(row)
        if row['arm'] == 'BASIC':
            return {}
        try:
            if not self.core_bound:
                self.core.bind_run(self.farm_run_id, self.farm_directory)
                self.core_bound = True
            if self.stopped:
                self.core.stop()
                return {}
            options = self.core.prepare_options()
            row['adapter_available'] = options.get('selection_adapter') is not None
            return options
        except Exception as exc:
            row['setup_fault'] = type(exc).__name__
            return {}  # Existing BASIC fallback; no pause/recovery/input here.

    def stop(self):
        if self.stopped:
            return
        self.stopped = True
        self.core.stop()  # Existing signal-only cleanup, even after setup fault.
        if self.bound:
            def finish():
                self.core.directory.mkdir(parents=True, exist_ok=True)
                receipt = dict(schema='pokiguard.e1.assignment_receipt.v1',
                    farm_run_id=self.farm_run_id, farm_directory=self.farm_directory,
                    prepares=list(self.prepares), assignment=list(self.arms),
                    core_bound=self.core_bound, core_faulted=self.core.faulted,
                    source='EXISTING_ONCE_PER_COMBAT_PREPARE_SEAM',
                    note='Terminal/entry failures and actual attempt accounting come from original farm logs.')
                try:
                    with (self.core.directory/'comparison_receipt.json').open('x', encoding='utf-8') as f:
                        json.dump(receipt, f, indent=2)
                except OSError:
                    pass  # Missing receipt is an evidence failure, never a live PASS.
            self.finalizer = threading.Thread(target=finish, name='e1-receipt-writer', daemon=True)
            self.finalizer.start()
