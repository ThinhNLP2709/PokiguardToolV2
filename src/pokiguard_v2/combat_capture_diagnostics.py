"""Bounded metadata about the existing sampler, never reconstructed effects.

No process reads, raw JSON bodies, actor names, pointer addresses, input
authority or cadence changes. Immutable cached snapshots keep health polling
constant time; only new response metadata or delivery changes copy the index.
"""
from dataclasses import dataclass,replace
from .combat_outcome_evidence import RESPONSE_TYPES,MAX_RETAINED_CAPTURES
from .dispatcher_read_trace import RootReadBinding

SCHEMA='pokiguard.combat_capture_diagnostics.v1'
_ERRORS=frozenset(('ExternalReadError','OSError','LayoutValidationError','ValueError'))


@dataclass(frozen=True)
class CaptureObservation:
    match_id:str
    event_type:str
    server_sequence:int
    metadata_source:str
    raw_sha256:str|None
    json_chars:int|None
    json_read_state:str
    json_read_error:str|None
    board_parsed:bool
    projection_status:str
    projection_reason:str|None
    conflicting_raw_identity:bool=False
    board_fields_offered:bool=False
    queue_drained:bool=False
    reader_binding:RootReadBinding|None=None


@dataclass(frozen=True)
class CaptureDiagnostics:
    schema:str=SCHEMA
    observations:tuple[CaptureObservation,...]=()
    record_limit:int=MAX_RETAINED_CAPTURES
    dropped_observations:int=0
    unscoped_json_read_errors:tuple[tuple[str,int],...]=()
    input_authority:bool=False
    effect_completeness:str='UNKNOWN'


def _sequence(value):return type(value) is int and 0<=value<=10000000
def _hash(value):return type(value) is str and len(value)==64 and all(c in '0123456789abcdef' for c in value)
def _reason(value):
    return value if (type(value) is str and 0<len(value)<=96
        and all(c in 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_' for c in value)) else None


class CaptureTrace:
    """Caller supplies its existing lock. Metadata is not an evidence provider."""
    def __init__(self):
        self._records={};self._errors={};self._dropped=0
        self.snapshot=CaptureDiagnostics()

    def clear(self):
        self._records.clear();self._errors.clear();self._dropped=0
        self.snapshot=CaptureDiagnostics()

    def _publish(self,changed=False):
        observations=tuple(self._records.values()) if changed else self.snapshot.observations
        self.snapshot=CaptureDiagnostics(observations=observations,dropped_observations=self._dropped,
            unscoped_json_read_errors=tuple(sorted(self._errors.items())))

    def observe(self,*,match_id,raw_envelope,dto_message,raw_sha256,json_chars,
                json_read_state,json_read_error,board_parsed,projection_status,projection_reason,reader_binding=None):
        if type(json_read_error) is str and json_read_error in _ERRORS:
            self._errors[json_read_error]=self._errors.get(json_read_error,0)+1
            self._publish()
        if not (type(match_id) is str and 0<len(match_id)<=256 and all(ord(c)>=32 for c in match_id)):
            return
        payload=raw_envelope.get('matchPayload') if type(raw_envelope) is dict else None
        raw_ok=(type(payload) is dict and raw_envelope.get('matchId')==match_id
            and type(raw_envelope.get('type')) is str and raw_envelope['type'] in RESPONSE_TYPES
            and _sequence(payload.get('srvSeq')))
        if raw_ok:
            event=raw_envelope['type'];sequence=payload['srvSeq'];digest=raw_sha256 if _hash(raw_sha256) else None
            source='IMMUTABLE_JSON' if digest is not None else 'JSON_METADATA_UNPINNED'
        elif (getattr(dto_message,'match_id',None)==match_id
                and type(getattr(dto_message,'event_type',None)) is str and dto_message.event_type in RESPONSE_TYPES
                and _sequence(getattr(dto_message,'server_sequence',None))):
            event=dto_message.event_type;sequence=dto_message.server_sequence
            digest=None;source='DTO_METADATA_ONLY_NOT_TYPED_EFFECTS'
        else:return
        key=(match_id,event,sequence);previous=self._records.get(key)
        if previous is None and len(self._records)>=MAX_RETAINED_CAPTURES:
            self._dropped+=1;self._publish();return
        status=projection_status if projection_status in ('CAPTURED','INVALID','UNAVAILABLE','REJECTED','NOT_APPLICABLE') else 'NOT_PROJECTED'
        entry=CaptureObservation(match_id,event,sequence,source,digest,
            json_chars if raw_ok and type(json_chars) is int and 0<=json_chars<=262144 else None,
            json_read_state if json_read_state in ('READ','READ_ERROR','NO_JSON_ROOT') else 'UNKNOWN',
            json_read_error if type(json_read_error) is str and json_read_error in _ERRORS else None,
            board_parsed is True,status,_reason(projection_reason))
        if type(reader_binding) is RootReadBinding:
            entry=replace(entry,reader_binding=reader_binding)
        if previous is not None:
            conflict=previous.conflicting_raw_identity or (previous.raw_sha256 is not None
                and digest is not None and previous.raw_sha256!=digest)
            # A later DTO-only view must not overwrite the retained JSON view.
            if previous.raw_sha256 is not None and digest is None:entry=previous
            entry=replace(entry,conflicting_raw_identity=conflict,board_fields_offered=previous.board_fields_offered,
                queue_drained=previous.queue_drained)
        if entry!=previous:self._records[key]=entry;self._publish(True)

    def delivered(self,match_id,event_type,sequence,route):
        if (route not in ('BOARD','QUEUE') or type(match_id) is not str
                or type(event_type) is not str or not _sequence(sequence)):return
        old=self._records.get((match_id,event_type,sequence))
        if old is None:return
        field='board_fields_offered' if route=='BOARD' else 'queue_drained'
        if not getattr(old,field):
            self._records[match_id,event_type,sequence]=replace(old,**{field:True});self._publish(True)
