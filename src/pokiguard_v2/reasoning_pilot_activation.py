"""File-only measured-artifact loader. No native/game reads or input.

The caller pins both artifact SHA and independently verified build/runtime SHA.
Self-declared origin strings without native sample provenance never suffice.
"""
from __future__ import annotations

from dataclasses import dataclass
import hashlib
import json
import math
from pathlib import Path
import time

from .reasoning_pilot_contract import PilotAuthority
from .reasoning_snapshot import FrozenJSON, require, strict_json_loads

SCHEMA = "pokiguard.reasoning.pilot_calibration.v1"


@dataclass(frozen=True)
class PilotArtifactRequest:
    path: str
    sha256: str
    verified_build_sha256: str
    runtime_sha256: str
    verified_clock_report_sha256: str | None = None

    def __post_init__(self):
        require(Path(self.path).is_absolute(), "absolute pilot artifact required")
        for value in (self.sha256, self.verified_build_sha256, self.runtime_sha256):
            require(type(value) is str and len(value) == 64 and
                    all(c in '0123456789abcdef' for c in value), "pinned SHA256 required")


def load_pilot_authority(request, *, policy_json, now=None):
    """Setup only. Missing/stale/mismatched evidence raises; caller retains BASIC.

    Native uncertainty requires a separately pinned bound report; raw integer
    tick samples alone cannot prove Unity/server clock uncertainty. This step
    does not manufacture that report or claim any current artifact is accepted.
    """
    require(type(request) is PilotArtifactRequest, "explicit opt-in request required")
    path = Path(request.path)
    require(path.stat().st_size <= 512*1024, "oversize calibration artifact")
    raw = path.read_bytes()
    require(hashlib.sha256(raw).hexdigest() == request.sha256, "calibration SHA mismatch")
    data = strict_json_loads(raw.decode('utf-8'))
    require(data['schema'] == SCHEMA and data['origin'] == 'NATIVE_OBSERVATION', "native provenance required")
    now = time.time() if now is None else now
    require(all(type(data[k]) in (int,float) and math.isfinite(data[k]) for k in ('created_at','expires_at'))
            and data['created_at'] <= now < data['expires_at']
            and data['expires_at'] - data['created_at'] <= 7*24*3600, "expired calibration")
    require(data['runtime_sha256'] == request.runtime_sha256
            and data['game_build_sha256'] == request.verified_build_sha256
            and data['policy_json'] == policy_json, "source/build/config changed")
    samples = data['samples']
    require(type(samples) is list and 1 <= len(samples) <= 512, "bounded native sample ledger required")
    durations = []
    for sample in samples:
        require(sample['origin'] == 'NATIVE_OBSERVATION'
                and sample['timer_source'] == 'MatchService.server_tick'
                and sample['input_mode'] == 'foreground'
                and sample['board_mode'] == 'two_click', "mixed or fake input cohort")
        p = (path.parent / sample['record_path']).resolve()
        require(p.is_relative_to(path.parent.resolve()) and p.is_file()
                and p.stat().st_size <= 32*1024*1024, "bounded local sample provenance required")
        content = p.read_bytes()
        require(hashlib.sha256(content).hexdigest() == sample['record_sha256'], "sample provenance changed")
        lines = content.decode('utf-8').splitlines()
        require(type(sample['line']) is int and 1 <= sample['line'] <= len(lines), "native record line missing")
        event = strict_json_loads(lines[sample['line']-1])
        require(event['event_type'] == 'reasoning.swap_timing', "wrong native timing event")
        body = event['payload']
        require(event['correlation']['mode'] == 'BASIC_CALIBRATION_ONLY'
                and body['input_mode'] == 'foreground' and body['witness'] == data['witness']
                and body['board_input_mode'] == 'two_click'
                and body['policy_sha256'] == hashlib.sha256(policy_json.encode()).hexdigest()
                and body['clock'] == 'host.perf_counter_ns'
                and body['timer_source'] == 'MatchService.server_tick', "timing record cohort/config changed")
        require(body['required_input_completed'] is True and body['sent_clicks'] == 2
                and body['click_status'] == 'SENT'
                and body['preflight_failure'] is None and body['status'] == 'RETURNED', "incomplete native input")
        start,end = body['preflight_start_ns'],body['executor_return_ns']
        require(type(start) is int and type(end) is int and 0 <= start < end
                and body['elapsed_upper_bound_ns'] == end-start, "unbound input interval")
        read_end, validated = body['read_end_ns'], body['validation_end_ns']
        require(type(read_end) is int and type(validated) is int
                and start <= read_end <= validated <= end
                and read_end-start <= data['max_read_span_ms']*1e6,
                "invalid or excessive native read interval")
        durations.append((end-start)/1e6)
    bound = data['timer_bound']
    p = (path.parent / bound['report_path']).resolve()
    require(p.is_relative_to(path.parent.resolve()) and p.is_file() and p.stat().st_size <= 512*1024,
            "separate clock bound provenance required")
    raw = p.read_bytes()
    require(hashlib.sha256(raw).hexdigest() == bound['report_sha256'], "clock proof SHA changed")
    require(request.verified_clock_report_sha256 == bound['report_sha256'],
            "independently reviewed clock derivation must be pinned")
    proof = strict_json_loads(raw.decode('utf-8'))
    require(proof['verdict'] == 'ACCEPTED_BOUNDED_NATIVE_TIMER'
            and proof['game_build_sha256'] == request.verified_build_sha256
            and proof['timer_source'] == 'MatchService.server_tick'
            and proof['clock_domain'] == 'host.perf_counter_ns'
            and proof['runtime_sha256'] == request.runtime_sha256, "unproved timer uncertainty")
    u = proof['uncertainty_ms']
    require(type(u) in (int,float) and math.isfinite(u) and u >= 150, "bounded U required")
    derivation = proof.get('derivation', {})
    require(derivation.get('method') == 'BOUNDED_COMPONENT_SUM_V1', 'clock derivation missing')
    components = derivation.get('components', [])
    require(type(components) is list and len(components) == 5
            and {c.get('name') for c in components} == {
                'anchor_age','transport_age','host_unity_alignment','read_span','quantization'},
            'all timer uncertainty components required')
    total = 0
    for component in components:
        upper = component.get('upper_ms')
        require(type(upper) in (int,float) and math.isfinite(upper) and upper >= 0,
                'finite conservative clock component required')
        total += upper
        references = component.get('evidence')
        require(type(references) is list and 1 <= len(references) <= 8, 'clock evidence references required')
        for ref in references:
            evidence = (path.parent / ref['path']).resolve()
            require(evidence.is_relative_to(path.parent.resolve()) and evidence.is_file()
                    and evidence.stat().st_size <= 32*1024*1024, 'bounded local clock evidence required')
            content = evidence.read_bytes()
            require(hashlib.sha256(content).hexdigest() == ref['sha256'], 'clock evidence changed')
            lines = content.decode('utf-8').splitlines()
            require(type(ref['first_line']) is int and type(ref['last_line']) is int
                    and 1 <= ref['first_line'] <= ref['last_line'] <= len(lines), 'clock source lines missing')
    require(total <= u, 'U does not cover declared uncertainty components')
    p99 = sorted(durations)[math.ceil(.99*len(durations))-1]
    config = json.loads(policy_json)
    reserve = max(1000, config['minimum_turn_time_seconds']*1000, p99+250)
    return PilotAuthority(config['play_style'], policy_json, FrozenJSON.of(data['scope']),
        FrozenJSON.of(data['witness']), FrozenJSON.of(data['model']), request.verified_build_sha256,
        'MatchService.server_tick',reserve,u, data['return_margin_ms'],data['max_read_span_ms'],
        'NATIVE_INPUT_CALIBRATED',request.sha256,len(durations),p99,
        budget_ms=data['budget_ms'])


class PilotRunSession:
    """Verified request is locked per run; unavailable factory keeps BASIC."""
    def __init__(self, request, *, policy_json, directory, factory=None):
        from .reasoning_pilot import create_pilot_bridge
        self.authority = load_pilot_authority(request, policy_json=policy_json)
        self.request, self.directory = request, directory
        self.factory = factory or create_pilot_bridge
        self.adapter = None
        self.stopped = False
        self.prepare_options()  # Warm resource at setup, without any game snapshot/job.

    def prepare_options(self):
        if self.stopped: return {}
        if self.adapter is None or self.adapter.stopped:
            self.adapter = self.factory(enabled=True, authority=self.authority,
                verified_build_sha256=self.request.verified_build_sha256,directory=self.directory)
        return {} if self.adapter is None else dict(selection_adapter=self.adapter)

    def stop(self):
        self.stopped = True
        if self.adapter is not None: self.adapter.stop()
