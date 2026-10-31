"""Explicit setup gate for a source-only operational pilot, dormant until Start.

Only existing read-only file validation occurs here. No process discovery,
reader, capture, input, worker or preference writes. An offline draft is never
an accepted activation. Keeping BASIC is a normal reasoning outcome.
"""
from dataclasses import replace
import hashlib
from pathlib import Path
import time

from .board_diagnostics import jsonable
from .pet_configuration import basic_policy_config
from .reasoning_calibration import decode_config, source_fingerprint
from .reasoning_calibration_review import document, read_ref, WITNESS
from .reasoning_operational import (OperationalArtifactRequest, OperationalPilotSession,
    SCHEMA, load_operational_authority, host_fingerprint)
from .reasoning_snapshot import canonical_json, digest, require, strict_json_loads

DRAFT_SCHEMA = 'pokiguard.reasoning.operational_pilot_draft.v1'


def operational_policy_json(config):
    """Match the existing production controller's minimum-action-time default1.

This validates setup; it does not change the controller or BASIC policy.
"""
    return canonical_json(jsonable(replace(basic_policy_config(config),
        minimum_turn_time_seconds=1, minimum_evolve_time_seconds=1)))


def check_launch_config(config):
    require(config.play_style.value == 'simple' and config.game_mode.value == 'solo'
            and config.intelligence.value == 'basic' and config.ai.shadow_enabled is False
            and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]
                == ['normal','normal','default_attack']
            and config.input_delivery_mode.value == 'foreground'
            and config.board_input_mode.value == 'two_click'
            and config.normalized_boss_id == '1289'
            and config.target_completed_matches == config.max_match_attempts == 3,
            'P14 requires frozen SIMPLE/SOLO/Starburst1289/normal/Attack/foreground/two_click/3TOTAL')


class OperationalPilotLaunch:
    """Preview verifies files; the existing Start gate claims exactly once."""
    def __init__(self, path, sha256, *, root, directory, game_executable, now=None):
        self.root=Path(root).resolve();self.path=Path(path).resolve()
        require(self.path.is_relative_to(self.root), 'pilot request must stay inside V2')
        # The SHA is external to the request; the original filename is not trusted.
        raw=read_ref(self.root,dict(path=self.path.relative_to(self.root).as_posix(),sha256=sha256),cap=512*1024)
        self.data=strict_json_loads(raw.decode('utf-8'))
        d=self.data
        current=d.get('pilot_protocol')=='D1_SIMPLE_CAREFUL_CURRENT_NATIVE_V1'
        d2=d.get('pilot_protocol')=='D2_HT7_FULL_ACTION_CURRENT_NATIVE_V1'
        d3=d.get('pilot_protocol') in ('D3_DEMON_MINIMUM_CURRENT_NATIVE_V1',
                                    'D3_DEMON_MULTIPLIER20_CURRENT_NATIVE_V1')
        d4=d.get('pilot_protocol')=='D4_MEGA_FULL_ACTION_CURRENT_NATIVE_V1'
        e1=d.get('pilot_protocol')=='E1_DEMON_LIEYUN20_BLOCKED_V1'
        e2=d.get('pilot_protocol')=='E2_B12_DEMON_SHIELD_RELIABILITY20_V1'
        require(d['schema']==SCHEMA and (current or d2 or d3 or d4 or e1 or e2 or d['witness']==WITNESS), 'scoped operational request required')
        self.config=decode_config(d['full_config'])
        if e2:
            from .reasoning_e2_native import check_config
            check_config(self.config)
        elif e1:
            from .reasoning_comparison import check_config
            check_config(self.config)
        elif d4:
            from .reasoning_mega_native import check_config
            check_config(self.config)
        elif d3:
            from .reasoning_demon_native import check_config
            check_config(self.config, protocol=d['pilot_protocol'])
        elif d2:
            from .reasoning_d2_native import check_config
            check_config(self.config)
        elif current:
            from .reasoning_d1_native import check_config
            check_config(self.config)
        else:check_launch_config(self.config)
        self.config_json=canonical_json(jsonable(self.config))
        require(d['full_config_sha256']==digest(jsonable(self.config))
                and d['total_attempt_cap']==(self.config.max_match_attempts if d2 or d3 or d4 or e1 or e2 else 3)
                and d['budget_ms']==self.config.ai.budget_ms
                and d['policy_json']==operational_policy_json(self.config)
                and d['max_read_span_ms']==100, 'launch config/policy/cap differs from review')
        self.request=OperationalArtifactRequest(str(self.path),sha256,d['game_build_sha256'],
            d['runtime_sha256'],d['host_sha256'],d['contract_sha256'],d['decision_sha256'],
            d['full_config_sha256'],d['activation_sha256'])
        self.game_executable=game_executable;self.directory=Path(directory)
        self.claimed=False;self.session=None;self.delivered=False
        self.claim_path=self.root/'logs/operational_pilot_claims'/(d['run_id']+'.json')
        require(self.claim_path.resolve().is_relative_to(self.root), 'claim outside V2')
        self.verify(now=now)
        require(not self.claim_path.exists(), 'request consumed; no restart/resume')

    def verify(self, *, now=None):
        from .game_location import validate_supported_game_assembly, game_assembly_sha256
        require(self.path.stat().st_size<=512*1024 and
                hashlib.sha256(self.path.read_bytes()).hexdigest()==self.request.sha256,
                'pilot request changed')
        require(source_fingerprint(self.root)==self.request.runtime_sha256
                and host_fingerprint()==self.request.host_sha256, 'current source/host changed')
        selected=self.game_executable()  # Selected file path only, no game lookup.
        require(selected is not None and Path(selected).resolve()==Path(self.data['game_executable']).resolve(),
                'selected executable changed')
        exe=Path(selected)
        require(validate_supported_game_assembly(exe.parent/'GameAssembly.dll')==self.request.verified_build_sha256
                and game_assembly_sha256(exe)==self.data['game_executable_sha256'], 'game files changed')
        # Includes independent accepted bounded review, expiry, every native row,
        # compatibility chain and a fresh selector allowance. Allocates no worker.
        load_operational_authority(self.request,policy_json=self.data['policy_json'],now=now)

    def validate_launch(self, config, checkpoint):
        require(not self.claimed and not self.claim_path.exists() and checkpoint is None
                and time.time()<self.data['expires_at']
                and canonical_json(jsonable(config))==self.config_json,
                'operational pilot consumed/expired/resumed/config changed')

    def claim(self, config, checkpoint):
        self.validate_launch(config,checkpoint);self.verify()
        # Existing session owns the durable exclusive claim. Never reset it.
        self.session=OperationalPilotSession(self.request,root=self.root,config=config,
            policy_json=self.data['policy_json'],directory=self.directory,
            game_executable=self.game_executable())
        if self.data.get('pilot_protocol')=='E1_DEMON_LIEYUN20_BLOCKED_V1':
            from .reasoning_comparison import ComparisonSession, assignment
            self.session=ComparisonSession(self.session, assignment(document(self.path.parent,
                self.data['comparison_manifest'])))
        self.claimed=True

    def __call__(self, config):
        require(self.claimed and self.session is not None and not self.delivered
                and canonical_json(jsonable(config))==self.config_json,
                'one matching Start required')
        self.delivered=True
        return self.session
