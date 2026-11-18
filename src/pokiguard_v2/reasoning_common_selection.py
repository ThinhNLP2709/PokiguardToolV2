"""Host verification and existing-checkpoint selection for the common chooser.

Synthetic admission cannot reach a real PID. Shared native admission requires
its own current input-family timing proof; the released Shield certificate does
not grant it. No reader, capture, executor or QTE lives here.
"""
from collections import Counter,deque
from dataclasses import dataclass,replace,field
import json,math,threading,time,uuid
from .autonomous_control import AutonomousSource
from .basic_policy import PlayStyle,PolicyAction,PolicyDecision,_candidate_trace
from .board_simulator import simulate_move
from .reasoning_common_evidence import build_problem,incumbent_action,packet_hash,_packet_hash,policy_json
from .reasoning_common_planner import CommonLimits,plan_common
from .reasoning_common_problem import CommonProblem,VERSION
from .reasoning_common_capture import record_snapshot_safely
from .reasoning_diagnostics import DiagnosticBuffer,encode_event
from .reasoning_full_actions import pass_authority_view
from .reasoning_runner import make_job,deadline_ns,_validate_reply,_decision_summary,REPLY_SCHEMA
from .reasoning_selection import Selection
from .reasoning_shadow import _Relay
from .reasoning_snapshot import FrozenJSON,canonical_json,digest,require
from .reasoning_warm_runner import WarmIsolatedRunner
from .pet_skill_shadow import PetSkillCapability
from .state import GamePhase

CONTEXT='COMMON_OFFLINE_NATIVE_FAKES'


class _CheckpointLog:
    """CPython single controller producer / single owner consumer, 128KiB cap.

    deque append/popleft are atomic. There is no shared counter update, wait,
    overwrite-on-full or concurrent disk call on a controller checkpoint.
    """
    def __init__(self):self.items=deque();self.disabled=False
    def enqueue(self,raw):
        if self.disabled or type(raw) is not bytes or len(raw)>2048 or len(self.items)>=64:return False
        self.items.append(raw);return True
    def take(self):
        try:return self.items.popleft()
        except IndexError:return None
    def finish(self,raw):pass # Durable accounting belongs to the shared sink.


@dataclass(frozen=True)
class CommonAdmission:
    policy_json:str
    reserves:FrozenJSON
    models:FrozenJSON
    max_read_span_ms:float=100
    budget_ms:float=4000
    context:str=CONTEXT
    native_authority:object=None
    _identity:str=field(init=False,repr=False,compare=False)

    def __post_init__(self):
        from .reasoning_common_native import CommonNativeAuthority,CONTEXT as NATIVE_CONTEXT
        require(type(self.reserves) is FrozenJSON and type(self.models) is FrozenJSON,'immutable admission required')
        if self.native_authority is None:
            require(self.context==CONTEXT,'native common requires verified timing authority')
        else:
            a=self.native_authority
            require(type(a) is CommonNativeAuthority and self.context==NATIVE_CONTEXT
                and self.policy_json==a.policy_json and self.reserves.plain()=={'swap':a.reserve_ms,'pass':a.reserve_ms}
                and self.max_read_span_ms==a.max_read_span_ms and self.budget_ms==a.budget_ms,
                'common native admission differs from verified authority')
        require(type(self.policy_json) is str and canonical_json(json.loads(self.policy_json))==self.policy_json,
            'canonical current policy required')
        values=self.reserves.plain()
        require(type(values) is dict and 'swap' in values and set(values)<=set(('swap','pet_skill','pass')),
            'explicit action-family timing required')
        require(all(type(v) in (int,float) and math.isfinite(v) and v>0 for v in values.values()),
            'positive action reserves required')
        require(type(self.max_read_span_ms) in (int,float) and math.isfinite(self.max_read_span_ms)
            and 0<self.max_read_span_ms<=1000 and type(self.budget_ms) in (int,float)
            and math.isfinite(self.budget_ms) and 0<self.budget_ms<=6000,'bounded observation/budget required')
        model=self.models.plain()
        require(type(model) is dict and set(model)<=set(('demon_geometry','conversion','operator_demon_rage_discount','demon_damage_model')),
            'unknown model setting')
        require(model.get('demon_geometry') in (None,'USER_DECLARED_PERPENDICULAR'),'unknown Demon effect')
        conversion=model.get('conversion',{})
        require(type(conversion) is dict and set(conversion)<=set(('mana','rage')) and all(
            type(v) in (int,float) and math.isfinite(v) and v>=0 for v in conversion.values()),'invalid conversion')
        require(model.get('demon_damage_model') is None or type(model['demon_damage_model']) is dict,'invalid scoped damage model')
        discount=model.get('operator_demon_rage_discount')
        require(discount is None or type(discount) is int and 0<=discount<=1,'unsupported nominal discount')
        object.__setattr__(self,'_identity',digest(dict(policy=self.policy_json,reserves=self.reserves.plain(),
            models=self.models.plain(),read_cap=self.max_read_span_ms,budget=self.budget_ms,context=self.context,
            native=None if self.native_authority is None else self.native_authority.identity)))

    @property
    def identity(self):return self._identity

    def problem(self,value,*,run_id,generation,observed_ns,read_end_ns):
        require(policy_json(value[1])==self.policy_json,'common config changed')
        require(self.native_authority is None or self.native_authority.matches(value[0],value[1]),
            'common native observation/context changed')
        result=build_problem(value,run_id=run_id,generation=generation,observed_ns=observed_ns,
            read_end_ns=read_end_ns,**self.models.plain())
        # Missing timing never turns a legal action into a numerical zero.
        # An unrepresented BASIC effect keeps the entire comparison on BASIC.
        effects=tuple(replace(c,eligible=False,reason='ACTION_FAMILY_TIMING_UNAVAILABLE')
            if c.action.family not in self.reserves.plain() else c for c in result.effects)
        return replace(result,effects=effects)

    def limit(self,value,observed_ns,read_end_ns,now_ns):
        if self.native_authority is not None and not self.native_authority.matches(value[0],value[1]):return None
        remaining=value[0].battle.turn_time_remaining_seconds
        if (type(remaining) not in (int,float) or not math.isfinite(remaining)
                or policy_json(value[1])!=self.policy_json
                or read_end_ns-observed_ns>self.max_read_span_ms*1e6):return None
        # Largest declared family reserve; never an invented per-action latency.
        return deadline_ns(observed_ns=observed_ns,remaining_ms=remaining*1000,
            slice_started_ns=read_end_ns,now_ns=now_ns,reserve_ms=max(self.reserves.plain().values()),
            configured_ms=self.budget_ms)


@dataclass(frozen=True)
class CommonCompleted:
    job:object
    reply:object
    source:AutonomousSource
    policy_json:str
    context_hash:str
    admission_hash:str
    completed_ns:int
    dispatch_deadline_ns:int
    candidate_trace:object|None

    @classmethod
    def prepare(cls,job,raw_reply,value,admission,*,clock=time.perf_counter_ns,cancelled=lambda:False):
        require(type(admission) is CommonAdmission and type(job.snapshot) is CommonProblem,'common job/admission required')
        problem=job.snapshot;facts=problem.facts.plain()
        observed,ended=facts['observed_ns'],facts['read_end_ns']
        expected=admission.problem(value,run_id=problem.source.run_id,generation=job.generation,
            observed_ns=observed,read_end_ns=ended)
        require(expected==problem and observed<=job.created_ns<=clock()<job.deadline_ns,
            'common job source/context/time mismatch')
        limit=admission.limit(value,observed,ended,job.created_ns)
        require(limit is not None and job.deadline_ns<=limit,'common deadline exceeds source reserve')
        reply=_validate_reply(raw_reply,job);summary=json.loads(reply.summary_json)
        diag=summary.get('common_diagnostics',{})
        stage=diag.get('stage')
        require(summary.get('common_engine')==VERSION and stage in ('ONE_STEP_COMPLETE','LOOKAHEAD_COMPLETE'),
            'incomplete common comparison')
        complete_future=stage=='LOOKAHEAD_COMPLETE'
        reference=plan_common(problem,CommonLimits(duration_ms=6000,lookahead=complete_future),
            deadline_ns=job.deadline_ns,clock=clock,cancelled=cancelled)
        require(reference.diagnostics.plain()['stage']==stage and reference.proposal==reply.proposal,
            'worker comparison not reproducible')
        allowed=(('COMMON_BOUNDED_IMPROVEMENT','COMMON_COMPLETED_RETENTION') if complete_future else (
            'COMMON_ONE_STEP_IMPROVEMENT','COMMON_COMPLETED_RETENTION','COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1',
            'COMMON_LOOKAHEAD_DEADLINE_USE_COMPLETED_R1','COMMON_LOOKAHEAD_NODE_CAP_USE_COMPLETED_R1'))
        require(reply.reason in allowed,'unsupported completed common reason')
        checked=_decision_summary(problem,reference,None)
        supplied=dict(summary);supplied.pop('common_diagnostics',None)
        checked.pop('common_diagnostics',None)
        require(supplied==checked,'worker utility/attribution not reproducible')
        refdiag=reference.diagnostics.plain()
        require(all(diag.get(k)==refdiag[k] for k in ('version','stage','adjacent_pairs','legal_swaps',
            'excluded_actions','input_authority','global_optimum_claim')),'worker coverage not reproducible')
        require(set(diag)==set(refdiag),'unexpected common coverage fields')
        if complete_future:require(diag==refdiag,'worker future coverage not reproducible')
        require(type(diag.get('nodes')) is int and refdiag['nodes']<=diag['nodes']<=18000,'invalid work receipt')
        trace=None
        if reply.proposal is not None and reply.proposal.family=='swap':
            evaluation=simulate_move(value[0].board,reply.proposal.move)
            require(evaluation is not None,'invalid current swap')
            trace=_candidate_trace(evaluation,board=value[0].board)
        completed=clock()
        require(not cancelled() and completed<job.deadline_ns,'common verification late or cancelled')
        return cls(job,reply,AutonomousSource.from_state(value[0]),admission.policy_json,packet_hash(value),
            admission.identity,completed,job.deadline_ns,trace)


def apply_common_action(baseline,action,state,value,candidate):
    if action==incumbent_action(baseline):return baseline
    family={'swap':PolicyAction.SWAP,'pet_skill':PolicyAction.PET_SKILL,'pass':PolicyAction.PASS}[action.family]
    cap=value[3] if type(value[3]) is PetSkillCapability else None
    trace=replace(baseline.trace,selected_action=family,policy_step='REASONING_COMMON_'+action.family.upper(),
        selected_candidate=candidate,why_selected='Completed common structural comparison; settings advisory',
        blocker=None,skill_fire_trigger='REASONING_COMMON_MODELED_SKILL' if family is PolicyAction.PET_SKILL else None,
        required_mana=None if cap is None else cap.effective_mana_cost,
        required_rage=None if cap is None else cap.effective_power_cost,
        current_mana=state.player.mana,current_rage=state.player.power,pet_skill_candidate=family is PolicyAction.PET_SKILL,
        skipped_current_sword_for_resource=False,
        selected_move_left_direct_boss_sword=bool(candidate and candidate.opponent_sword_replies),
        selected_move_left_indirect_boss_sword=bool(candidate and candidate.indirect_sword_replies))
    return PolicyDecision(family,trace,move=action.move,
        skill_card_id=cap.skill_card_id if family is PolicyAction.PET_SKILL else None,
        skill_session_key=state.battle.session_key if family is PolicyAction.PET_SKILL else None,
        consumes_turn=family is not PolicyAction.PASS,requires_state_reread=True)


def galaxy_strategy_allows(config,baseline,proposed):
    """Keep shared skill/resource/protection priorities at the input boundary."""
    if config.play_style is not PlayStyle.GALAXY or proposed == baseline:return True
    if (baseline.action is not PolicyAction.SWAP or proposed.action is not PolicyAction.SWAP
            or baseline.trace.policy_step.startswith('GALAXY_SURVIVAL')):return False
    before=baseline.trace.selected_candidate;after=proposed.trace.selected_candidate
    if before is None or after is None:return False
    if after.sword_effective>0 or after.known_sword_consumed>0:return False
    if before.safe and not after.safe:return False
    def progresses(candidate):
        return ((baseline.trace.missing_mana != 0 and candidate.known_mana_gain>0)
            or (baseline.trace.missing_rage != 0 and candidate.known_rage_gain>0))
    if progresses(before):return progresses(after)
    # Preserve the shared Drain > Shield > turnover fallback order as well.
    for gem in ('drain','shield'):
        if any(name==gem and effective>0 for name,physical,effective in before.total_resources):
            return any(name==gem and effective>0 for name,physical,effective in after.total_resources)
    return True


class CommonSelectionBridge:
    """One pending packet, one worker, bounded logs; admission owns the context."""
    def __init__(self,*,admission,diagnostics,enabled=False,run_id=None):
        require(type(admission) is CommonAdmission,'typed common admission required')
        require(enabled is True,'common bridge requires explicit opt-in')
        require(type(diagnostics.buffer) is DiagnosticBuffer and diagnostics.buffer.limits.records<=432
            and diagnostics.buffer.limits.bytes<=6*1024*1024,'bounded existing diagnostic sink required')
        self.admission=admission;self.sink=diagnostics;self.enabled=enabled is True
        self.pilot_authority=None # Legacy certificates are never widened.
        self.stopped=self.disabled=False;self.decision_budget=self.warm_worker=True
        self.diagnostics=_CheckpointLog()
        self.relay=_Relay(diagnostics);self.runner=WarmIsolatedRunner(diagnostics=self.relay)
        self.timing_diagnostics=self.relay
        self.run_id=run_id or uuid.uuid4().hex;self.generation=0
        self.observation=self.action_context=self.completed=self.request=None
        self.last_admission=None;self.preparation_reason=None;self.cleanup_ok=None;self.log_pending=None
        self.lock=threading.Lock();self.wake=threading.Event();self.shutdown=threading.Event();self.result_ready=threading.Event()
        self.budget_receipts=deque(maxlen=64);self.counts=Counter();self.bridge_counts=self.counts;self.sequence=0
        self.thread=threading.Thread(target=self._serve,name='reasoning-common-owner',daemon=True);self.thread.start()

    def controller_context(self,*,target_pid,shared_runtime):
        if self.admission.native_authority is not None:
            return self.admission.context if type(target_pid) is int and target_pid>0 and shared_runtime is True else 'PRODUCTION_GATED'
        return CONTEXT if target_pid==0 and shared_runtime is True else 'PRODUCTION_GATED'

    def _record(self,reason,checkpoint,now_ns):
        self.counts[reason]+=1;self.sequence+=1
        ok=self.diagnostics.enqueue(encode_event('reasoning.common_selection',self.sequence,dict(run_id=self.run_id),
            dict(reason=reason,checkpoint=checkpoint,existing_preflight_required=True,dispatch=False)))
        if not ok:self.disabled=True
        return ok

    def observe(self,state,config,*,observed_ns,read_end_ns,context):
        self.generation+=1 # Even identical-source re-observation supersedes an old offer.
        self.completed=None;self.observation=None
        reason='ADMISSION_UNAVAILABLE'
        if (self.enabled and not self.stopped and not self.disabled and context==self.admission.context
                and type(observed_ns) is int and type(read_end_ns) is int
                and 0<=observed_ns<=read_end_ns
                and read_end_ns-observed_ns<=self.admission.max_read_span_ms*1e6):
            self.observation=(state,config,observed_ns,read_end_ns);reason='ADMITTED'
        self.last_admission=reason
        return reason=='ADMITTED'

    def await_decision(self,state,baseline,config,*,context,stop_requested):
        if not self.enabled or self.stopped or self.disabled or context!=self.admission.context:return 'SKIPPED'
        if self.last_admission!='ADMITTED' or self.observation is None:return 'NO_OBSERVATION'
        observed_state,observed_config,observed,ended=self.observation
        value=self.action_context
        if (value is None or not AutonomousSource.from_state(value[0]).matches(state)
                or value[1]!=config or value[2]!=baseline
                or not AutonomousSource.from_state(observed_state).matches(state) or observed_config!=config):return 'SOURCE_CHANGED'
        start=time.perf_counter_ns();limit=self.admission.limit(value,observed,ended,start)
        if limit is None:return 'NO_BUDGET'
        if not self.lock.acquire(False):return 'BUSY'
        try:
            self.generation+=1;generation=self.generation
            self.completed=None;self.result_ready.clear();self.preparation_reason=None
            self.request=(value,observed,ended,limit,generation);self.wake.set()
        finally:self.lock.release()
        reason='DEADLINE'
        self.counts['decision_wait_started']+=1
        while time.perf_counter_ns()<limit:
            if stop_requested():self.stop();reason='STOPPED';break
            if self.stopped or self.disabled or self.runner.breaker.disabled or self.sink.buffer.disabled:
                reason='UNAVAILABLE';break
            if self.result_ready.is_set():reason='COMPLETED' if self.completed is not None else 'FALLBACK';break
            self.result_ready.wait(min(.005,max(0,(limit-time.perf_counter_ns())/1e9)))
        if reason=='DEADLINE':self.runner.invalidate()
        self.budget_receipts.append(dict(started_ns=start,ended_ns=time.perf_counter_ns(),deadline_ns=limit,
            reason=reason,observed_ns=observed,read_end_ns=ended,preparation_reason=self.preparation_reason))
        return reason

    def _reason(self,offer,state,baseline,config,now_ns,input_allowed,context,final=False,final_remaining_seconds=None):
        if not input_allowed:return 'EXISTING_OWNER_OR_STOP'
        if self.stopped:return 'STOPPED'
        if not self.enabled:return 'OPT_IN_OFF'
        if self.disabled or self.sink.buffer.disabled or self.diagnostics.disabled:return 'DIAGNOSTIC_DISABLED'
        if context!=self.admission.context:return 'PRODUCTION_GATED'
        if self.admission.native_authority is not None and not self.admission.native_authority.matches(state,config):return 'NATIVE_CONTEXT_EXPIRED_OR_CHANGED'
        if state.phase is not GamePhase.COMBAT or state.battle.is_local_turn is not True:return 'EXISTING_PHASE_OR_TURN_BLOCKED'
        if self.last_admission!='ADMITTED':return 'OBSERVATION_REJECTED'
        if offer is None or offer is not self.completed:return 'NO_CURRENT_COMPLETED_PROPOSAL'
        if not offer.completed_ns<=now_ns<offer.dispatch_deadline_ns:return 'LATE_OR_INVALID_CLOCK'
        current_source=AutonomousSource.from_state(state)
        if offer.source!=current_source:return 'SOURCE_CHANGED'
        if offer.admission_hash!=self.admission.identity or policy_json(config)!=offer.policy_json:return 'CONFIG_OR_ADMISSION_CHANGED'
        if incumbent_action(baseline)!=offer.job.snapshot.baseline:return 'BASIC_INCUMBENT_CHANGED'
        value=self.action_context
        packet_source=(None if value is None else current_source if value[0] is state else AutonomousSource.from_state(value[0]))
        if (value is None or value[5] is not True or packet_source!=current_source
                or _packet_hash(value,packet_source.critical_state_hash)!=offer.context_hash
                or pass_authority_view(value[0])!=pass_authority_view(state)):
            return 'CURRENT_CAPABILITY_HISTORY_OR_OWNER_CHANGED'
        remaining=final_remaining_seconds if final else state.battle.turn_time_remaining_seconds
        reserve=max(self.admission.reserves.plain().values())+250
        if type(remaining) not in (int,float) or not math.isfinite(remaining) or remaining*1000<=reserve:return 'INSUFFICIENT_RESERVE'
        return 'VALID_COMPLETED_COMMON'

    def select(self,state,baseline,config,*,now_ns,input_allowed,context):
        offer=self.completed;reason=self._reason(offer,state,baseline,config,now_ns,input_allowed,context)
        if not self._record(reason,'ROOT',now_ns):return Selection(baseline,reason='DIAGNOSTIC_FAILURE')
        if reason!='VALID_COMPLETED_COMMON':return Selection(baseline,reason=reason)
        action=offer.reply.proposal
        decision=baseline if action is None else apply_common_action(baseline,action,state,self.action_context,offer.candidate_trace)
        if not galaxy_strategy_allows(config,baseline,decision):
            self._record('GALAXY_STRATEGY_RETAIN_BASIC','ROOT',now_ns)
            return Selection(baseline,reason='GALAXY_STRATEGY_RETAIN_BASIC')
        guard=getattr(self,'native_policy_guard',None)
        if action is not None and guard is not None and guard(decision) is not False:
            self._record('EXISTING_POLICY_GUARD_RETAIN_BASIC','ROOT',now_ns)
            return Selection(baseline,reason='EXISTING_POLICY_GUARD_RETAIN_BASIC')
        return Selection(decision,offer,reason)

    def revalidate(self,receipt,state,baseline,config,*,now_ns,input_allowed,context,final=False,final_remaining_seconds=None):
        reason=self._reason(receipt,state,baseline,config,now_ns,input_allowed,context,final,final_remaining_seconds)
        logged=self._record(reason,'FINAL' if final else 'FRESH',now_ns)
        return None if reason=='VALID_COMPLETED_COMMON' and logged else reason if logged else 'DIAGNOSTIC_FAILURE'

    def stop(self):
        self.stopped=True;self.shutdown.set();self.runner.stop();self.wake.set();self.result_ready.set()

    def close(self,timeout=3):
        self.stop();self.thread.join(timeout)
        return not self.thread.is_alive() and self.cleanup_ok is True

    def _drain(self):
        # Windows scheduling may wake the owner less frequently than requested.
        # A bounded batch drains all three checkpoints per turn without growing
        # the controller queue or adding any work to its producer.
        for _ in range(8):
            if not self._transfer_one():break

    def _transfer_one(self):
        if self.log_pending is None:
            item=self.relay.take()
            if item is not None:self.log_pending=(item[0],item[1],self.relay,time.perf_counter_ns())
            else:
                raw=self.diagnostics.take()
                if raw is not None:self.log_pending=(raw,True,self.diagnostics,time.perf_counter_ns())
        if self.log_pending is None:return False
        raw,critical,owner,started=self.log_pending
        try:ok=self.sink.enqueue(raw,critical=critical)
        except Exception:
            ok=False;self.disabled=True
        if ok:
            owner.finish(raw);self.log_pending=None
            return True
        elif self.disabled or self.sink.buffer.disabled or time.perf_counter_ns()-started>=100_000_000:
            owner.finish(raw);self.log_pending=None;self.disabled=True
            self.counts['diagnostic_transfer_failed']+=1
            return True
        # A transient try-lock/full response is retried only by the background
        # owner, with one bounded pending record. The controller never waits.
        return False

    def _execute(self,request):
        value,observed,ended,limit,generation=request
        problem=self.admission.problem(value,run_id=self.run_id,generation=generation,
            observed_ns=observed,read_end_ns=ended)
        job=make_job(problem,deadline=limit,generation=generation)
        self.counts['snapshot_'+record_snapshot_safely(self.sink,job)]+=1
        if not self.runner.submit(job):raise ValueError('worker submit rejected')
        while not self.shutdown.is_set() and time.perf_counter_ns()<limit:
            self._drain()
            if self.disabled:break
            if self.runner.lock.acquire(False):
                try:outcome=self.runner.outcome if self.runner.current is job else None
                finally:self.runner.lock.release()
                if outcome is not None:
                    reply,reason=outcome
                    if reply is None:
                        self.preparation_reason='COMMON_WORKER_'+reason
                        return
                    stage=json.loads(reply.summary_json).get('common_diagnostics',{}).get('stage')
                    if reply.proposal is None and stage not in ('ONE_STEP_COMPLETE','LOOKAHEAD_COMPLETE'):
                        self.preparation_reason=reply.reason
                        return # Expected missing model/partial work: ordinary BASIC, no receipt.
                    raw=canonical_json(dict(schema=REPLY_SCHEMA,job_id=job.job_id,generation=job.generation,
                        binding=vars(job.binding),disposition=reply.disposition,reason=reply.reason,
                        proposal=None if reply.proposal is None else reply.proposal.to_dict(),compute_ns=reply.compute_ns,
                        input_authority=False,r2_promotion=False,summary=json.loads(reply.summary_json))).encode()
                    completed=CommonCompleted.prepare(job,raw,value,self.admission,cancelled=self.shutdown.is_set)
                    if not self.stopped and generation==self.generation and time.perf_counter_ns()<limit:
                        self.completed=completed
                    return
            self.shutdown.wait(.002)
        self.runner.invalidate()

    def _serve(self):
        try:
            while not self.shutdown.is_set():
                self.wake.wait(.002);self.wake.clear();self._drain()
                with self.lock:request,self.request=self.request,None
                if request is None:continue
                try:self._execute(request)
                except Exception as exc:
                    self.preparation_reason='COMMON_'+type(exc).__name__+': '+str(exc)[:160]
                    # Fault disables AI only; the accepted BASIC loop continues.
                    if not self.stopped and time.perf_counter_ns()<request[3]:self.disabled=True
                    raw=encode_event('reasoning.common_error',0,dict(run_id=self.run_id),dict(reason=self.preparation_reason))
                    try:self.sink.enqueue(raw,critical=True)
                    except Exception:pass
                finally:self.result_ready.set()
        finally:
            self.runner.stop();self.cleanup_ok=self.runner.close(1.3)
            for _ in range(128):
                self._drain()
                if self.log_pending is None and not self.relay.items and not self.diagnostics.items:break
                time.sleep(.002)


def create_common_bridge(*,enabled=False,admission=None,diagnostics=None,**kwargs):
    """Off means no worker, owner thread, diagnostic queue or extra imports."""
    if enabled is not True:return None
    return CommonSelectionBridge(enabled=True,admission=admission,diagnostics=diagnostics,**kwargs)


def observe_common_safely(adapter,*args,**kwargs):
    if type(adapter) is not CommonSelectionBridge:return False
    try:return adapter.observe(*args,**kwargs)
    except Exception:
        adapter.disabled=True
        try:adapter._record('COMMON_OBSERVATION_EXCEPTION','OBSERVE',time.perf_counter_ns())
        except Exception:pass
        return False


def await_common_safely(adapter,*args,**kwargs):
    if type(adapter) is not CommonSelectionBridge:return 'SKIPPED'
    try:return adapter.await_decision(*args,**kwargs)
    except Exception:
        adapter.disabled=True
        try:adapter._record('COMMON_DECISION_EXCEPTION','DECISION',time.perf_counter_ns())
        except Exception:pass
        return 'FALLBACK'


def create_common_native_bridge(*,enabled=False,authority=None,verified_build_sha256=None,
        diagnostics=None,run_id=None,warm_worker=True,decision_budget=True):
    if enabled is not True:return None
    from .reasoning_common_native import CommonNativeAuthority,CONTEXT as NATIVE_CONTEXT
    require(type(authority) is CommonNativeAuthority and verified_build_sha256==authority.game_build_sha256
        and warm_worker is True and decision_budget is True,'verified shared native context required')
    # PASS sends no input. Keep the full measured BASIC fallback reserve; its
    # existing server proof/first-turn/third-pass guards still own eligibility.
    admission=CommonAdmission(authority.policy_json,FrozenJSON.of({'swap':authority.reserve_ms,'pass':authority.reserve_ms}),FrozenJSON.of({}),
        max_read_span_ms=authority.max_read_span_ms,budget_ms=authority.budget_ms,
        context=NATIVE_CONTEXT,native_authority=authority)
    return create_common_bridge(enabled=True,admission=admission,diagnostics=diagnostics,run_id=run_id)
