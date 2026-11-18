"""Optional exact adviser inputs on the existing background diagnostic writer.

No process reads, files, input, new queue, retries or live action authority.
Failure loses an offline observation only. Oversized events use the existing
explicit truncation record and cannot be decoded as complete snapshots.
"""
from .reasoning_common_problem import CommonProblem
from .reasoning_diagnostics import EVENT_SCHEMA, encode_event
from .reasoning_snapshot import canonical_json, require


SCHEMA = 'pokiguard.reasoning.common_capture.v1'
EVENT = 'reasoning.common_snapshot'


def snapshot_event(job):
    problem = job.snapshot
    require(type(problem) is CommonProblem, 'common immutable snapshot required')
    require(job.binding.snapshot_id == problem.snapshot_id
        and job.binding.config_hash == problem.intent.config_hash
        and job.binding.source_json == canonical_json(problem.source.to_dict()), 'snapshot job binding mismatch')
    return encode_event(EVENT, job.generation, job.correlation(), dict(
        schema=SCHEMA, snapshot_id=problem.snapshot_id, config_hash=problem.intent.config_hash,
        snapshot=problem.to_dict(),
        scope='EXACT_ADVISER_INPUT_NOT_PROOF_OF_INPUT_DELIVERY_OR_NATIVE_ACCEPTANCE'))


def record_snapshot_safely(sink, job):
    """Called by the existing owner thread, never the controller checkpoint."""
    try:
        return 'queued' if sink.enqueue(snapshot_event(job), critical=False) else 'dropped'
    except Exception:
        return 'error'


def decode_snapshot_event(record):
    """Return replay input only; this cannot install a native admission/profile."""
    require(type(record) is dict and record.get('schema') == EVENT_SCHEMA
        and record.get('event_type') == EVENT and record.get('input_authority') is False,
        'not an observation-only common snapshot event')
    payload = record.get('payload'); correlation = record.get('correlation')
    require(type(payload) is dict and payload.get('truncated') is not True
        and payload.get('schema') == SCHEMA and type(correlation) is dict,
        'snapshot missing, truncated or unsupported')
    require(payload.get('scope') == 'EXACT_ADVISER_INPUT_NOT_PROOF_OF_INPUT_DELIVERY_OR_NATIVE_ACCEPTANCE',
        'snapshot observation scope changed')
    value = CommonProblem.from_dict(payload.get('snapshot'))
    require(payload.get('snapshot_id') == correlation.get('snapshot_id') == value.snapshot_id
        and payload.get('config_hash') == correlation.get('config_hash') == value.intent.config_hash
        and correlation.get('source') == value.source.to_dict()
        and correlation.get('profile') == value.intent.profile
        and correlation.get('provenance') == value.provenance.to_dict()
        and correlation.get('versions') == value.intent.versions.plain()
        and correlation.get('clock_domain') == 'host.perf_counter_ns', 'snapshot source/config/hash mismatch')
    require(type(correlation.get('job_id')) is str and 0 < len(correlation['job_id']) <= 128
        and type(record.get('event_seq')) is int and record['event_seq'] >= 0
        and type(correlation.get('job_generation')) is int
        and record['event_seq'] == correlation['job_generation'], 'snapshot job identity mismatch')
    return value
