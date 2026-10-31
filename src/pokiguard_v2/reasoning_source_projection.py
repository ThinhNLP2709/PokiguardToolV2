"""Opt-in current-value telemetry projection; no source hashes reused or cached."""
from dataclasses import fields
from .autonomous_control import AutonomousSource
from .state import CombatSessionKey
from .board_diagnostics import jsonable

SOURCE_FIELDS=('session','srv_seq','board_hash','turn','current_turn_player','critical_state_hash')
SESSION_FIELDS=('lifecycle_epoch','board_instance','match_id')
SCALARS=(str,int,bool,float,type(None))


def project_source(value):
    if type(value) is not AutonomousSource or tuple(f.name for f in fields(value))!=SOURCE_FIELDS:
        return jsonable(value)
    session=value.session
    if type(session) is not CombatSessionKey or tuple(f.name for f in fields(session))!=SESSION_FIELDS:
        return jsonable(value)
    result={};nested={}
    for name in SESSION_FIELDS:
        child=getattr(session,name)
        if type(child) not in SCALARS:return jsonable(value)
        nested[name]=child
    result['session']=nested
    for name in SOURCE_FIELDS[1:]:
        child=getattr(value,name)
        if type(child) not in SCALARS:return jsonable(value)
        result[name]=child
    return result
