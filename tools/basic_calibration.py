"""File-only BASIC calibration request/export. Never opens/attaches/runs a game."""
import argparse, hashlib, json, math
from dataclasses import replace
from pathlib import Path
import sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import build_request, SCHEMA
from pokiguard_v2.reasoning_snapshot import canonical_json
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.basic_policy import Intelligence, PlayStyle
from pokiguard_v2.reasoning_settings import AISettings


def read_json(path):return json.loads(path.read_text(encoding='utf-8'))
def sha(path):return hashlib.sha256(path.read_bytes()).hexdigest()
def write_new(path,data):
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as output:json.dump(data,output,ensure_ascii=False,indent=2)


def export(request_path,request_sha,timing_directory,farm_directory):
    if sha(request_path)!=request_sha:raise ValueError('request SHA mismatch')
    request=read_json(request_path);binding=read_json(timing_directory/'session.json')
    if request['schema']!=SCHEMA or binding['run_id']!=request['run_id']:
        raise ValueError('request/session mismatch')
    if (Path(binding['farm_directory']).resolve()!=farm_directory.resolve()
      or binding['config_json']!=canonical_json(request['config'])
      or binding['total_attempt_cap']!=request['total_attempt_cap']):raise ValueError('wrong FarmRun/config/cap')
    inputs={};errors=[]
    def pin(p):inputs[str(p.resolve())]=sha(p)
    for p in (request_path,timing_directory/'session.json'):pin(p)
    watermark_path=timing_directory/'watermarks.json'
    if watermark_path.is_file():
        pin(watermark_path);watermark=read_json(watermark_path);stats=watermark.get('before_close',{})
        if not (watermark.get('run_id')==request['run_id'] and watermark.get('flushed') is True
          and watermark.get('closed') is True and watermark.get('collector_dropped')==0
          and watermark.get('collector_disabled') is False and stats.get('accounting_valid') is True
          and stats.get('eligible')==stats.get('written')
          and all(stats.get(k)==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer'))):
            errors.append('UNCONFIRMED_OR_LOST_DIAGNOSTIC_RECORDS')
    else:errors.append('MISSING_FINAL_DIAGNOSTIC_WATERMARK')
    run_path=farm_directory/'run.json';checkpoint=farm_directory/'checkpoint.json'
    snapshot=None;finalized=False
    if run_path.is_file():pin(run_path);snapshot=read_json(run_path)['snapshot'];finalized=True
    elif checkpoint.is_file():
        pin(checkpoint);data=read_json(checkpoint);snapshot=data.get('snapshot')
    if snapshot is None:
        errors.append('MISSING_FINAL_LEDGER_NO_COST_OR_ACCEPTANCE_CLAIM');snapshot={}
    if snapshot.get('farm_run_id')!=binding['farm_run_id']:errors.append('FARM_RUN_ID_UNBOUND')
    attempts=snapshot.get('attempts',[]);count=snapshot.get('match_attempts')
    if count!=len(attempts) or count is None or count>request['total_attempt_cap']:
        errors.append('ATTEMPT_ACCOUNTING_INVALID')
    if finalized and snapshot.get('limits',{}).get('max_match_attempts')!=request['total_attempt_cap']:
        errors.append('FARM_CAP_CHANGED')
    combats=[]
    for path in sorted((farm_directory/'matches').glob('*/combat.jsonl')):
        pin(path)
        for line,raw in enumerate(path.read_text(encoding='utf-8').splitlines(),1):
            try:combats.append((json.loads(raw),dict(path=str(path.resolve()),sha256=inputs[str(path.resolve())],line=line)))
            except ValueError:errors.append('MALFORMED_COMBAT_RECORD')
    samples=[];witnesses=set()
    for path in sorted(timing_directory.glob('*.jsonl')):
        pin(path)
        for line,raw in enumerate(path.read_text(encoding='utf-8').splitlines(),1):
            try:event=json.loads(raw)
            except ValueError:errors.append('MALFORMED_TIMING_RECORD');continue
            if event.get('event_type')!='reasoning.swap_timing':continue
            p=event['payload'];correlation=event.get('correlation',{})
            reasons=[];source=p.get('autonomous_source')
            if p.get('witness') is None:reasons.append('MISSING_RUNTIME_WITNESS')
            if correlation.get('run_id')!=request['run_id']:reasons.append('WRONG_RUN')
            sent=[ref for row,ref in combats if row.get('event')=='action_sent' and row.get('action')=='SWAP'
              and row.get('identity',{}).get('source')==source and source is not None]
            ack=[ref for row,ref in combats if row.get('event')=='action_result'
              and row.get('result')=='SWAP_ACKNOWLEDGED'
              and row.get('action',{}).get('identity',{}).get('source')==source and source is not None]
            if len(sent)!=1 or len(ack)!=1:reasons.append('MISSING_OR_AMBIGUOUS_SENT_ACK_JOIN')
            if not (p.get('status')=='RETURNED' and p.get('required_input_completed') is True
              and p.get('sent_clicks')==2 and p.get('click_status')=='SENT'
              and p.get('preflight_failure') is None):reasons.append('INCOMPLETE_OR_REJECTED')
            times=[p.get(k) for k in ('preflight_start_ns','read_end_ns','validation_end_ns','executor_return_ns')]
            if (not all(type(t) is int and t>=0 for t in times) or times!=sorted(times)
              or times[-1]<=times[0] or p.get('elapsed_upper_bound_ns')!=times[-1]-times[0]):
                reasons.append('INVALID_INTERVAL')
            if (p.get('input_mode')!='foreground' or p.get('board_input_mode')!='two_click'
              or p.get('timer_source')!='MatchService.server_tick'):reasons.append('WRONG_INPUT_TIMER_COHORT')
            witnesses.add(canonical_json(p.get('witness')))
            samples.append(dict(path=str(path.resolve()),sha256=inputs[str(path.resolve())],line=line,payload=p,
              sent=sent,ack=ack,eligible_for_descriptive_R=not reasons,rejections=reasons))
    if len(witnesses)!=1 or 'null' in witnesses:errors.append('MISSING_OR_MIXED_RUNTIME_WITNESS')
    observed_sources={canonical_json(s['payload'].get('autonomous_source')) for s in samples}
    for row,ref in combats:
        if row.get('event')=='action_sent' and row.get('action')=='SWAP':
            source=row.get('identity',{}).get('source')
            if source is None or canonical_json(source) not in observed_sources:
                errors.append('MISSING_TIMING_FOR_SENT_SWAP')
    if not finalized:errors.append('INCOMPLETE_RUN')
    eligible=[s['payload']['elapsed_upper_bound_ns']/1e6 for s in samples if s['eligible_for_descriptive_R']]
    empirical=None
    if eligible:
        values=sorted(eligible)
        empirical=dict(N=len(values),p50=values[math.ceil(.5*len(values))-1],
          p95=values[math.ceil(.95*len(values))-1],p99=values[math.ceil(.99*len(values))-1],max=max(values),
          tail_claim='DESCRIPTIVE_ONLY_SMALL_N_NO_POPULATION_BOUND')
    full_tail=[];controller_tail=[]
    for sample in samples:
        p=sample['payload'];start=p.get('decision_exit_ns');end=p.get('executor_return_ns')
        preflight=p.get('preflight_start_ns')
        if (sample['eligible_for_descriptive_R'] and all(type(v) is int for v in (start,preflight,end))
                and 0<=start<=preflight<=end):
            full_tail.append((end-start)/1e6);controller_tail.append((preflight-start)/1e6)
    return dict(schema='pokiguard.basic_calibration_export.v1',request_sha256=request_sha,
      source_sha256=request['source_sha256'],game_build_sha256=request['game_build_sha256'],
      host_sha256=request.get('host_sha256'),timing_coverage=request.get('timing_coverage'),
      controller_tail_descriptive_ms=None if not controller_tail else dict(N=len(controller_tail),max=max(controller_tail)),
      full_tail_descriptive_ms=None if not full_tail else dict(N=len(full_tail),max=max(full_tail)),
      operational_reserve_ready=False,
      run_id=request['run_id'],inputs=inputs,finalized=finalized,all_attempts=attempts,
      all_attempt_count=count,total_attempt_cap=request['total_attempt_cap'],
      local_turn_cost=sum(a.get('local_turns',0) for a in attempts),
      cost_scope='ALL_ATTEMPTS_LOCAL_TURNS_TOOL_PROXY_NOT_ACCOUNT_ENERGY_DELTA',
      samples=samples,raw_timing_N=len(samples),R_descriptive_ms=empirical,errors=errors,
      diagnostic_accounting='PINNED_FINAL_WRITER_WATERMARK_AND_SOURCE_SENT_COMPLETENESS',
      U_ms=None,native_timer_bound='UNKNOWN',reasoning_authority=False,live_acceptance=False)


def main():
    parser=argparse.ArgumentParser(description=__doc__);sub=parser.add_subparsers(dest='mode',required=True)
    p=sub.add_parser('create');p.add_argument('--preferences',type=Path,required=True)
    p.add_argument('--game',required=True);p.add_argument('--boss-id',required=True);p.add_argument('--boss-name',required=True)
    p.add_argument('--cohort',required=True);p.add_argument('--profile',choices=['simple','careful'],default='simple')
    p.add_argument('--cap',type=int,default=3);p.add_argument('--seconds',type=int,default=7200);p.add_argument('--out',type=Path,required=True)
    p=sub.add_parser('export');p.add_argument('--request',type=Path,required=True);p.add_argument('--request-sha256',required=True)
    p.add_argument('--timing-directory',type=Path,required=True);p.add_argument('--farm-directory',type=Path,required=True)
    p.add_argument('--out',type=Path,required=True);args=parser.parse_args()
    if args.mode=='create':
        loaded=DesktopPreferenceStore(args.preferences).load()
        if not loaded.loaded or loaded.warnings:raise ValueError('valid explicit preferences required')
        config=replace(loaded.config,play_style=PlayStyle(args.profile),intelligence=Intelligence.BASIC,
          ai=AISettings(False),boss_id=args.boss_id,boss_name=args.boss_name,
          target_completed_matches=args.cap,max_match_attempts=args.cap)
        data=build_request(ROOT,config,args.game,cohort=args.cohort,seconds=args.seconds)
    else:data=export(args.request,args.request_sha256,args.timing_directory,args.farm_directory)
    write_new(args.out,data);print(str(args.out.resolve()));print('SHA256='+sha(args.out))


if __name__=='__main__':main()
