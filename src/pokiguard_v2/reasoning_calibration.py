"""Explicit source-only BASIC timing request. File IO at setup/Start only.

This never supplies reasoning authority or game observations. One durable claim
prevents reopening the same request from resetting its all-attempt cap.
"""
from dataclasses import fields
from enum import Enum
import hashlib, json, math
from pathlib import Path
import time, uuid

from .board_diagnostics import jsonable
from .desktop_control_plane import DesktopConfig
from .basic_policy import Intelligence, PlayStyle
from .gameplay_profile import GameMode
from .game_location import resolve_game_executable, validate_supported_game_assembly, game_assembly_sha256
from .reasoning_settings import AISettings
from .reasoning_snapshot import canonical_json, strict_json_loads
from .reasoning_swap_timing import SwapTimingRequest, SwapTimingSession

SCHEMA='pokiguard.basic_calibration_request.v1'
D2_CONTROL_PROTOCOL='D2_SKILL_RUSH_BASIC_CONTROL_V1'
D2_TIMING_PROTOCOL='D2_SKILL_RUSH_SKILL_TIMING_PROBE_V1'
D3_CONTROL_PROTOCOL='D3_DEMON_AEGIS_BASIC_CONTROL_V1'
D4_CONTROL_PROTOCOL='D4_MEGA_ICARUS_BASIC_CONTROL_V1'
D4_INPUT_TIMING_PROTOCOL='D4_MEGA_CLICK_ONLY_INPUT_PROBE_V1'
D4_INPUT_RETRY_PROTOCOL='D4_MEGA_CLICK_ONLY_INPUT_REMEDIATION_V2'
from .reasoning_operational import host_fingerprint


def source_files(root):
    return {p.relative_to(root).as_posix():game_assembly_sha256(p)
      for base in ('src','tools','tests') for p in sorted((root/base).rglob('*.py'))}


def source_fingerprint(root):
    return hashlib.sha256(canonical_json(source_files(root)).encode()).hexdigest()


def d4_probe_run_id(parent_sha256):
    if (type(parent_sha256) is not str or len(parent_sha256)!=64
        or any(c not in '0123456789abcdef' for c in parent_sha256)):
        raise ValueError('exact D4 BASIC3 closure SHA required')
    return hashlib.sha256(('D4_INPUT_PROBE_ONCE:'+parent_sha256).encode()).hexdigest()[:32]


def verify_d4_probe_parent(data,root):
    parent=data.get('native_parent',{})
    expected='docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121/closure.json'
    if (parent.get('path')!=expected or
        tuple(data.get(k) for k in ('previous_attempts_consumed','probe_attempt_cap','remaining_after_probe','total_case_cap'))!=(3,1,2,6)
        or data.get('run_id')!=d4_probe_run_id(parent.get('sha256'))):
        raise ValueError('one D4 probe against exact BASIC3 parent and total cap6 required')
    path=Path(root)/expected
    if path.stat().st_size>128*1024:raise ValueError('bounded D4 closure required')
    raw=path.read_bytes()
    if hashlib.sha256(raw).hexdigest()!=parent['sha256']:raise ValueError('D4 BASIC3 closure changed')
    native=strict_json_loads(raw.decode('utf-8'))
    if (native.get('farm_run_id')!='941c8bc77a2c4713b6584480bcfa8722'
        or native.get('source_sha256')!='218d0e6c39a532d9da0c197ccbccceab459289282d087db1545699019f99f1df'
        or tuple(native.get(k) for k in ('attempts','completed','wins','remaining_total_attempts','total_case_cap'))!=(3,3,3,3,6)
        or native.get('reasoning_activation') is not False):
        raise ValueError('completed native BASIC3 is not the D4 probe parent')


def d4_retry_run_id(failed_sha256):
    d4_probe_run_id(failed_sha256)  # Same strict SHA shape; separate one-shot identity.
    return hashlib.sha256(('D4_INPUT_REMEDIATION_ONCE:'+failed_sha256).encode()).hexdigest()[:32]


def verify_d4_retry_parent(data,root):
    parent=data.get('retry_parent',{})
    repeat='docs/phase5/artifacts/5d4_input_retry1_live_20261018_140315/closure.json'
    if parent.get('path')==repeat:
        if (parent.get('sha256')!='99f9421e19b82e87df34f70753ba8b9f4f5c1a07a7683e82c660f5d60c38aaa6'
            or tuple(data.get(k) for k in ('previous_attempts_consumed','probe_attempt_cap',
                'remaining_after_probe','total_case_cap','planned_basic_attempts','planned_reasoning_attempts'))!=(5,1,2,8,6,2)
            or data.get('run_id')!=d4_retry_run_id(parent.get('sha256'))):
            raise ValueError('explicit one-BASIC repeat after foreground stop requires totalcap8 and two reserved REASONING')
        path=Path(root)/repeat
        if path.stat().st_size>128*1024:raise ValueError('bounded foreground-stop closure required')
        raw=path.read_bytes()
        if hashlib.sha256(raw).hexdigest()!=parent['sha256']:raise ValueError('foreground-stop closure changed')
        previous=strict_json_loads(raw.decode('utf-8'))
        if (previous.get('farm_run_id')!='f861e43bc41249e4bd53da9d6fa5416b'
            or previous.get('status')!='MEASUREMENT_SAMPLE_VALID_FARM_INCOMPLETE_FOREGROUND_SAFE_STOP'
            or previous.get('source_sha256')!='3e9d085a067f4167288fcb310a78e9d61a83f8ee664ab739d6d5359a712dde7e'
            or tuple(previous.get(k) for k in ('attempts','completed','cumulative_attempts',
                'remaining_total_attempts','total_case_cap'))!=(1,0,5,2,7)
            or previous.get('reasoning_activation') is not False):
            raise ValueError('the consumed foreground-stop attempt must remain in the repeat ledger')
        prior=data.get('prior_retry_parent',{})
        return verify_d4_retry_parent(dict(data,retry_parent=prior,
            run_id=d4_retry_run_id(prior.get('sha256')),previous_attempts_consumed=4,
            remaining_after_probe=2,total_case_cap=7),root)
    expected='docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'
    if (parent.get('path')!=expected or
        tuple(data.get(k) for k in ('previous_attempts_consumed','probe_attempt_cap','remaining_after_probe','total_case_cap')) not in ((4,1,1,6),(4,1,2,7))
        or data.get('run_id')!=d4_retry_run_id(parent.get('sha256'))):
        raise ValueError('D4 remediation requires failed probe plus exact5BASIC and1or2REASONING totalcap6or7')
    path=Path(root)/expected
    if path.stat().st_size>128*1024:raise ValueError('bounded failed probe closure required')
    raw=path.read_bytes()
    if hashlib.sha256(raw).hexdigest()!=parent['sha256']:raise ValueError('failed D4 probe closure changed')
    failed=strict_json_loads(raw.decode('utf-8'))
    if (failed.get('status')!='GAMEPLAY_WIN_MEASUREMENT_FAILED_ZERO_RECORDS'
        or failed.get('farm_run_id')!='09f41b6b9e3742efb4eabf9975dcb8fd'
        or failed.get('request_run_id')!='fd3337acef7a871ffad363b1f20ddd52'
        or failed.get('source_sha256')!='97d97cdb8215b7716fbb3586a64e4b0fe4126170896a599730fa822c900a61ad'
        or tuple(failed.get(k) for k in ('attempts','completed','wins','timing_records','collector_sequence',
            'cumulative_attempts_consumed','remaining_total_attempts','total_case_cap'))!=(1,1,1,0,0,4,2,6)
        or failed.get('reasoning_activation') is not False):
        raise ValueError('D4 remediation cannot erase or reset the failed measurement attempt')
    original=dict(data,run_id=d4_probe_run_id(data['native_parent']['sha256']),
        previous_attempts_consumed=3,remaining_after_probe=2,total_case_cap=6)
    verify_d4_probe_parent(original,root)


def decode_config(raw):
    default=DesktopConfig();values={}
    if type(raw) is not dict or set(raw)!={f.name for f in fields(default)}:
        raise ValueError('complete canonical DesktopConfig required')
    for f in fields(default):
        value=raw[f.name];example=getattr(default,f.name)
        if isinstance(example,Enum):value=type(example)(value)
        elif f.name=='ai':value=AISettings(**value)
        elif f.name=='input_randomization':
            from .input_randomization import InputRandomization
            value=InputRandomization.from_dict(value)
        values[f.name]=value
    config=DesktopConfig(**values)
    encoded=jsonable(config)
    # Retained native evidence predates the UI opt-in. Only an absent, false
    # intent may use the exact old AI shape; all other canonical checks remain.
    if 'reasoning_enabled' not in raw['ai'] and config.ai.reasoning_enabled is False:
        encoded['ai'].pop('reasoning_enabled',None)
    if canonical_json(encoded)!=canonical_json(raw):raise ValueError('noncanonical config')
    return config


def check_config(config,cap,*,profile_protocol=None):
    if profile_protocol == D4_INPUT_RETRY_PROTOCOL:
        return check_config(config,cap,profile_protocol=D4_INPUT_TIMING_PROTOCOL)
    if profile_protocol == D4_INPUT_TIMING_PROTOCOL:
        from dataclasses import replace
        if type(cap) is not int or cap != 1 or config.max_match_attempts != 1 or config.target_completed_matches != 1:
            raise ValueError('D4 click-only input probe requires exactly one BASIC attempt')
        return check_config(replace(config,max_match_attempts=3,target_completed_matches=3),3,
            profile_protocol=D4_CONTROL_PROTOCOL)
    if profile_protocol == D3_CONTROL_PROTOCOL:
        from .gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode, PetSkillFireCondition
        if (config.intelligence is not Intelligence.BASIC or config.ai.shadow_enabled
            or config.play_style is not PlayStyle.DEMON_AEGIS_FARM
            or config.game_mode is not GameMode.SOLO
            or config.main_pet is not MainPetType.NORMAL
            or config.evolution is not EvolutionTarget.NONE
            or config.damage_card is not DamageCardMode.PET_PASSIVE
            or config.demon_target_gem.value != 'shield'
            or config.pet_skill_fire_condition is not PetSkillFireCondition.SWORD_COUNT
            or type(config.pet_skill_fire_value) is not int or config.pet_skill_fire_value != 4
            or config.input_delivery_mode.value != 'foreground'
            or config.board_input_mode.value != 'two_click'
            or type(cap) is not int or cap != 3
            or config.max_match_attempts != 3 or config.target_completed_matches != 3
            or not config.normalized_boss_id):
            raise ValueError('D3 BASIC control requires SOLO Demon Aegis / normal pet / no evolution / passive / 4 physical Sword / foreground two_click / 3 attempts')
        return
    if profile_protocol == D4_CONTROL_PROTOCOL:
        from .gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode, PetSkillFireCondition, AuditionMode
        if (config.intelligence is not Intelligence.BASIC or config.ai.shadow_enabled
            or config.play_style is not PlayStyle.MEGA_ICARUS_SPAM_SKILL
            or config.game_mode is not GameMode.SOLO
            or config.main_pet is not MainPetType.NORMAL
            or config.evolution is not EvolutionTarget.MEGA
            or config.damage_card is not DamageCardMode.PET_SKILL
            or config.audition_mode is not AuditionMode.NO_ACTION
            or config.pet_skill_fire_condition is not PetSkillFireCondition.SWORD_COUNT
            or type(config.pet_skill_fire_value) is not int or config.pet_skill_fire_value != 6
            or config.normalized_boss_id != '2346'
            or config.input_delivery_mode.value != 'foreground'
            or config.board_input_mode.value != 'two_click'
            or type(cap) is not int or cap != 3
            or config.max_match_attempts != 3 or config.target_completed_matches != 3):
            raise ValueError('D4 BASIC control requires SOLO SmallBlue2346 / normal to Mega / Pet Skill / no QTE / 6 effective seal Sword / foreground two_click / 3 attempts')
        return
    if profile_protocol is not None:
        if profile_protocol not in (D2_CONTROL_PROTOCOL,D2_TIMING_PROTOCOL):
            raise ValueError('unknown BASIC observation profile protocol')
        expected_cap=1 if profile_protocol==D2_TIMING_PROTOCOL else 3
        from .gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode
        if (config.intelligence is not Intelligence.BASIC or config.ai.shadow_enabled
            or config.play_style is not PlayStyle.SKILL_RUSH
            or config.game_mode is not GameMode.SOLO
            or config.main_pet is not MainPetType.LEGENDARY
            or config.evolution is not EvolutionTarget.NONE
            or config.damage_card is not DamageCardMode.PET_SKILL
            or config.input_delivery_mode.value!='foreground'
            or config.board_input_mode.value!='two_click'
            or type(cap) is not int or cap!=expected_cap
            or config.max_match_attempts!=expected_cap or config.target_completed_matches!=expected_cap
            or not config.normalized_boss_id):
            raise ValueError('D2 BASIC control requires SOLO Skill Rush / Legendary / no evolution / Pet Skill / foreground two_click / 3 attempts')
        return
    if (config.intelligence is not Intelligence.BASIC or config.ai.shadow_enabled
        or config.play_style not in (PlayStyle.SIMPLE,PlayStyle.CAREFUL)
        or config.game_mode is not GameMode.SOLO
        or [config.main_pet.value,config.evolution.value,config.damage_card.value]
            != ['normal','normal','default_attack']
        or config.input_delivery_mode.value!='foreground' or config.board_input_mode.value!='two_click'
        or type(cap) is not int or not 1<=cap<=5 or config.max_match_attempts!=cap
        or not 1<=config.target_completed_matches<=cap or not config.normalized_boss_id):
        raise ValueError('frozen SOLO BASIC Simple/Careful foreground two_click / boss / total cap 1..5 required')


def build_request(root,config,game_location,*,cohort,seconds=7200,now=None,profile_protocol=None):
    check_config(config,config.max_match_attempts,profile_protocol=profile_protocol)
    if not cohort or len(cohort)>512 or not 60<=seconds<=7200:raise ValueError('cohort/window required')
    selection=resolve_game_executable(game_location)
    assembly=selection.executable.parent/'GameAssembly.dll'
    build=validate_supported_game_assembly(assembly)
    now=time.time() if now is None else now
    result=dict(schema=SCHEMA,run_id=uuid.uuid4().hex,created_at=now,expires_at=now+seconds,
      source_sha256=source_fingerprint(root),host_sha256=host_fingerprint(),
      timing_coverage='DECISION_EXIT_TO_EXECUTOR_RETURN_V1',game_executable=str(selection.executable),
      game_executable_sha256=game_assembly_sha256(selection.executable),game_build_sha256=build,
      config=jsonable(config),total_attempt_cap=config.max_match_attempts,cohort=cohort,
      cohort_authority='OPERATOR_LABEL_ONLY_RUNTIME_WITNESS_MUST_BE_CHECKED',reasoning_enabled=False)
    if profile_protocol is not None:result['profile_protocol']=profile_protocol
    return result


class BasicCalibrationActivation:
    def __init__(self,path,sha256,*,root,directory,game_executable,now=None):
        self.root=Path(root).resolve();self.path=Path(path).resolve();self.directory=Path(directory)
        if not self.path.is_relative_to(self.root) or self.path.stat().st_size>128*1024:
            raise ValueError('bounded request inside V2 workspace required')
        raw=self.path.read_bytes()
        if hashlib.sha256(raw).hexdigest()!=sha256:raise ValueError('request SHA changed')
        self.data=strict_json_loads(raw.decode('utf-8'));self.config=decode_config(self.data['config'])
        d=self.data
        if (d['schema']!=SCHEMA or d['reasoning_enabled'] is not False
            or type(d['run_id']) is not str or len(d['run_id'])!=32
            or any(c not in '0123456789abcdef' for c in d['run_id'])):raise ValueError('invalid calibration request')
        self.config_json=canonical_json(jsonable(self.config))
        claims=self.root/'logs/basic_calibration_claims'
        if not claims.resolve().is_relative_to(self.root):raise ValueError('claims must remain inside V2')
        self.claim_path=claims/(d['run_id']+'.json');self.claimed=False;self.session=None
        self.game_executable=game_executable  # Existing selected path; no process lookup.
        self.verify(now=now)
        if self.claim_path.exists():raise ValueError('request already consumed; no restart/resume')

    def verify(self,now=None):
        d=self.data;now=time.time() if now is None else now
        if not (all(type(d[k]) in (int,float) and math.isfinite(d[k]) for k in ('created_at','expires_at'))
          and d['created_at']<=now<d['expires_at'] and 60<=d['expires_at']-d['created_at']<=7200):
            raise ValueError('expired calibration request')
        check_config(self.config,d['total_attempt_cap'],profile_protocol=d.get('profile_protocol'))
        if d.get('profile_protocol') == D4_INPUT_TIMING_PROTOCOL:
            verify_d4_probe_parent(d,self.root)
        if d.get('profile_protocol') == D4_INPUT_RETRY_PROTOCOL:
            verify_d4_retry_parent(d,self.root)
        if d.get('host_sha256') is not None and d['host_sha256'] != host_fingerprint():
            raise ValueError('calibration host changed')
        selected=self.game_executable()
        if selected is None or Path(selected).resolve()!=Path(d['game_executable']).resolve():
            raise ValueError('selected executable changed')
        executable=Path(selected)
        if (source_fingerprint(self.root)!=d['source_sha256']
          or validate_supported_game_assembly(executable.parent/'GameAssembly.dll')!=d['game_build_sha256']
          or game_assembly_sha256(executable)!=d['game_executable_sha256']):
            raise ValueError('current source/build differs from request')

    def validate_launch(self,config,checkpoint):
        # Cheap preview only, no source hashing on UI polling thread.
        if (self.claimed or self.claim_path.exists() or checkpoint is not None
          or time.time()>=self.data['expires_at']
          or canonical_json(jsonable(config))!=self.config_json):
            raise ValueError('calibration closed, expired, resumed or config changed')

    def claim(self,config,checkpoint):
        self.validate_launch(config,checkpoint);self.verify()
        self.claim_path.parent.mkdir(parents=True,exist_ok=True)
        with self.claim_path.open('x',encoding='utf-8') as output:
            json.dump(dict(run_id=self.data['run_id'],claimed_at=time.time(),request=str(self.path)),output)
        self.claimed=True

    def __call__(self,config):
        if not self.claimed or self.session is not None:raise ValueError('one Start required')
        if canonical_json(jsonable(config))!=self.config_json:raise ValueError('config drift')
        self.verify()
        options=({'measure_skills':True} if self.data.get('profile_protocol') in
            (D2_CONTROL_PROTOCOL,D2_TIMING_PROTOCOL,D4_CONTROL_PROTOCOL) else {})
        factory=SwapTimingSession
        if self.data.get('profile_protocol') == D4_INPUT_TIMING_PROTOCOL:
            from .reasoning_mega_timing import MegaClickTimingSession
            factory=MegaClickTimingSession
        if self.data.get('profile_protocol') == D4_INPUT_RETRY_PROTOCOL:
            from .reasoning_mega_timing import MegaClickTimingSession
            factory=MegaClickTimingSession
        self.session=factory(SwapTimingRequest(self.data['run_id'],self.config_json,
          self.data['total_attempt_cap']),config=config,directory=self.directory,**options)
        return self.session
