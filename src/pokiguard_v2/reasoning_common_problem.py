"""Immutable common reasoning data. No game reader, input or runtime authority."""
from dataclasses import dataclass,field
from .reasoning_snapshot import (Action,FrozenJSON,SourceIdentity,SourceRecord,digest,keys,require)
from .state import BoardState,CellState,GemType

SCHEMA='pokiguard.reasoning.common_problem.v1'
VERSION='common_reasoning.v1'
PROFILES=frozenset(('simple','careful','skill_rush','demon_aegis_farm',
    'mega_icarus_spam_skill','bu_win','dinosaur'))


@dataclass(frozen=True)
class CommonIntent:
    profile:str
    settings:FrozenJSON
    versions:FrozenJSON
    scope:FrozenJSON
    _config_hash:str=field(init=False,repr=False,compare=False)

    def __post_init__(self):
        require(self.profile in PROFILES,'unsupported common objective')
        require(all(type(v) is FrozenJSON and type(v.plain()) is dict
            for v in (self.settings,self.versions,self.scope)),'immutable common intent required')
        require(self.settings.plain().get('play_style',self.profile)==self.profile
            and self.settings.plain().get('intelligence','basic')=='basic','common objective cannot alias current policy')
        require(self.versions.plain().get('engine')==VERSION,'unsupported common engine version')
        object.__setattr__(self,'_config_hash',digest(self.to_dict()))

    @property
    def config_hash(self):return self._config_hash

    def to_dict(self):
        return dict(profile=self.profile,settings=self.settings.plain(),versions=self.versions.plain(),scope=self.scope.plain())

    @classmethod
    def from_dict(cls,value):
        keys(value,{'profile','settings','versions','scope'})
        return cls(value['profile'],*(FrozenJSON.of(value[k]) for k in ('settings','versions','scope')))


@dataclass(frozen=True)
class EffectChoice:
    """Owner-published action and conditional effect. This grants no permission.

    cleared=None means opaque. A legal but opaque incumbent must be retained;
    an opaque alternative is excluded explicitly, never scored as utility zero.
    """
    action:Action
    eligible:bool
    reason:str
    cleared:tuple|None
    model:str
    support:str
    mana_cost:int|None=0
    rage_cost:int|None=0
    facts:FrozenJSON=FrozenJSON.of({})

    def __post_init__(self):
        require(type(self.action) is Action and self.action.family in ('pet_skill','cast','pass'),
            'common effect must be an existing active action')
        require(type(self.eligible) is bool and type(self.reason) is str and bool(self.reason),'eligibility reason required')
        require(self.support in ('UNKNOWN','USER_CALIBRATED','CONDITIONAL_MODEL','VERIFIED_FOR_SCOPE'),
            'effect provenance required')
        require(type(self.model) is str and bool(self.model) and type(self.facts) is FrozenJSON,'immutable effect facts required')
        for value in (self.mana_cost,self.rage_cost):
            require(value is None or type(value) is int and value>=0,'actual nonnegative cost or UNKNOWN required')
        if self.cleared is not None:
            require(type(self.cleared) is tuple and len(set(self.cleared))==len(self.cleared)
                and all(type(p) is tuple and len(p)==2 and all(type(n) is int and 0<=n<8 for n in p)
                    for p in self.cleared),'unique known effect cells required')

    def to_dict(self):
        return dict(action=self.action.to_dict(),eligible=self.eligible,reason=self.reason,
            cleared=None if self.cleared is None else [list(p) for p in self.cleared],model=self.model,
            support=self.support,mana_cost=self.mana_cost,rage_cost=self.rage_cost,facts=self.facts.plain())

    @classmethod
    def from_dict(cls,value):
        keys(value,{'action','eligible','reason','cleared','model','support','mana_cost','rage_cost','facts'})
        return cls(Action.from_dict(value['action']),value['eligible'],value['reason'],
            None if value['cleared'] is None else tuple(tuple(p) for p in value['cleared']),
            value['model'],value['support'],value['mana_cost'],value['rage_cost'],FrozenJSON.of(value['facts']))


@dataclass(frozen=True)
class CommonProblem:
    source:SourceIdentity
    provenance:SourceRecord
    intent:CommonIntent
    board:tuple
    baseline:Action
    baseline_reason:str
    facts:FrozenJSON
    effects:tuple=()
    _snapshot_id:str=field(init=False,repr=False,compare=False)

    def __post_init__(self):
        require(type(self.source) is SourceIdentity and type(self.provenance) is SourceRecord
            and type(self.intent) is CommonIntent and type(self.baseline) is Action,'typed common problem required')
        require(type(self.facts) is FrozenJSON and type(self.facts.plain()) is dict,'immutable common facts required')
        require(type(self.baseline_reason) is str and 0<len(self.baseline_reason)<=4096,'bounded incumbent reason required')
        require(type(self.effects) is tuple and len(self.effects)<=16 and all(type(c) is EffectChoice for c in self.effects),
            'bounded immutable action choices required')
        require(len({digest(c.action.to_dict()) for c in self.effects})==len(self.effects),'duplicate action choice')
        self.board_state()
        object.__setattr__(self,'_snapshot_id',digest(self.to_dict()))

    def board_state(self):
        require(type(self.board) is tuple and len(self.board)==8 and
            all(type(row) is tuple and len(row)==8 for row in self.board),'8x8 board required')
        board=BoardState(tuple(tuple(CellState(r,c,GemType(g),m) for c,(g,m) in enumerate(row))
            for r,row in enumerate(self.board)))
        require(board.production_ready,'observed common board is not production ready')
        return board

    @property
    def snapshot_id(self):return self._snapshot_id

    def candidate_id(self,action):return digest(dict(snapshot_id=self.snapshot_id,action=action.to_dict()))

    def to_dict(self):
        return dict(schema=SCHEMA,source=self.source.to_dict(),provenance=self.provenance.to_dict(),
            intent=self.intent.to_dict(),board=[[list(c) for c in row] for row in self.board],
            baseline=self.baseline.to_dict(),baseline_reason=self.baseline_reason,
            facts=self.facts.plain(),effects=[c.to_dict() for c in self.effects])

    @classmethod
    def from_dict(cls,value):
        keys(value,{'schema','source','provenance','intent','board','baseline','baseline_reason','facts','effects'})
        require(value['schema']==SCHEMA,'common problem schema mismatch')
        return cls(SourceIdentity.from_dict(value['source']),SourceRecord.from_dict(value['provenance']),
            CommonIntent.from_dict(value['intent']),tuple(tuple(tuple(c) for c in row) for row in value['board']),
            Action.from_dict(value['baseline']),value['baseline_reason'],FrozenJSON.of(value['facts']),
            tuple(EffectChoice.from_dict(c) for c in value['effects']))
