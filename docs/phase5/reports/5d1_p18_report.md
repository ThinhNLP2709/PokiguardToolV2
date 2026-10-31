# 5D.1-P18 — Reviewed source/timing implementation, offline

2026-10-15 (Asia/Saigon). **PASS SCOPED OFFLINE / LIVE NOT ACTIVATED / PARTIAL D1.**
Parent [P17](5d1_p17_report.md), [prompt P18](../prompts/5D1_P18_SOURCE_TIMING_REBIND_IMPLEMENTATION_OFFLINE.md),
[P17 addendum](../research/5d1_p17_source_timing_rebind_contract.md).

## Result and scope

Final regression2291tests and32fresh qualification gates passed. No live activation,
request, claim, game runtime query/attach/read/capture/input, UI/observer launch, network,
build/version/Git or ordinary preference changes. Package remains1.2.5.
No agent delegation. All controller/game/input surfaces in tests are fakes;
existing native evidence is opened as sealed bounded files only.

Frozen source294: `b673eab28dfcb1c5d32116d264789b7e5d8b2d9bdc7a2df7dfc469012e2740a9`.
Parent source291: `a8aba6c01a3a5fa9eda6d46c1c7f84b4c1e577d080c4d015b0d68c0ebdac1638`.
Host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`;
HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`.
[Final source manifest](../artifacts/5d1_source_timing_rebind_p18_v1/final_test_source_manifest.json)
pins all294Python files;6existing files changed,3added,285existing unchanged.

## Implemented changes

- Correct `command_wait_ms` to count both cursor settles and both holds.
  Default `1000+1850+2*60+2*75=3120ms`. Existing executor/delays are byte exact.
  The old setup builder now computes the ceiling rather than hard-coding3060.
  Historical records/contracts/requests containing3060stay untouched.
- Add separate reviewed-v3 file-only verifier/exporter. Original P11 v2 review
  is still verified on its own target290. Exact P16 transition and complete
  frozen P18 source/method bytes are checked separately. No generic runtime
  file/method exemption; protected deadline/Stop/factory edits are rejected.
- Recompute all native/raw identity, terminal, attempt, sequence and watermark
  evidence. Keep26BASIC returns/20anchors/30rows/4EVOLVE/3attempts and the original
  mixed-witness error.7P15 operational returns stay a separate cost supplement;
  their5root-span vetoes and16missing timings are never promoted to admissions.
- Reviewed-v3 setup requires `POST_RETURN_COMPONENTS_V1`, corrected command
  version, span100ms/guard250ms/margin100ms and cap3. Existing setup verifies
  contract, independent activation, expiry and request bindings before v3.
  Native U/transport/alignment stay null; numerical model effects stay absent.
- Collector checks H, I, aggregate and interval validity at existing finish
  after executor return. It records flags/limits/first reason once and signals
  the existing AI-only fault callback. It never sends replacement input or
  changes reader/preflight/pending/ACK/FarmRun/result/room/recovery/Stop flow.
  Default/legacy collectors retain their old behavior and acquire no monitor.

Frozen authority metadata is cached only at v3 collector construction rather
than rehashed on every action. A software test compares all common payload
fields with the uncached path; bytes/meaning stay equal. New component fields
are added once to the same bounded timing event, without duplicating traces.
No SLO threshold was relaxed.

[Source dependency audit](../artifacts/5d1_source_timing_rebind_p18_v1/source_dependency_audit.json)
passes36checks. The legacy loader body is AST exact after removing the one new
v3 setup branch; bridge factory is exact except the validated monitor keyword.
Observation/checkpoint/start/preflight/Stop callbacks remain exact. BASIC,
provider, input executor, screenshot code, planner bridge, strict finite-U
contract/activation, original v2 verifier, controller and FarmRun bytes remain.
Exact before/after copies and diffs are retained with the source manifest.

## Validation

[Planned case coverage](../artifacts/5d1_source_timing_rebind_p18_v1/planned_case_coverage.json)
maps all34P17 cases.36direct tests plus11existing lifecycle/race tests repeated
with v3 mode cover actual fake-executor waits,0/nonzero settles,1ns component
boundaries, invalid intervals, aggregate fault, post-click ACK/no replay,
durable first fault, closed sinks/successors/caps/Stop races, source/raw tamper,
complete artificial cost rows/index/warmup/outlier/summary and null UNKNOWNs.
Synthetic accepted activation/cost fixtures exist only in disposable tests;
no real session/request/claim is activated.

Development run01:35tests,1fixture error (selected a non-timing event); raw
failure is retained. Fixed the fixture and added invalid timestamp/lifecycle
coverage. Focused run:128tests PASS in241.106s, before the final qualifier-only
path checks and common-payload test were added. Final frozen full regression
covers those additions; do not label the earlier focused run as final-source
qualification.

[Full frozen-source regression](../artifacts/5d1_source_timing_rebind_p18_v1/full_final.log):
**2,291/2,291 PASS**,1114.907s; no skips/failures. Source was frozen before this
run and remained identical for qualification. No repeat to find a PASS.

[Fresh qualification](../artifacts/5d1_source_timing_rebind_p18_v1/qualification_final/qualification.json):
**32/32 gates PASS**. Actual current pilot admission/three checkpoints and v3
operational collector/monitor were measured. Five standard paths plus four
admission paths have6,000raw rows each, first1,000warmup retained; collector has
6,000rows and Stop1,000. [Independent raw recomputation](../artifacts/5d1_source_timing_rebind_p18_v1/qualification_raw_recomputation.json)
verifies all61,000values/51,000measured after warmup, complete indices, paths,
quantiles, CPU, source and host. No maximum/outlier was removed.

| Measurement | p50 | p95 | p99 | max (ms) |
|---|---:|---:|---:|---:|
| Completed checkpoints |0.6728|0.9005|1.4497|2.0370|
| Admitted plus3checks |0.6850|0.9857|1.4753|10.2792|
| Full v3 collector pipeline |0.2644|0.3339|0.5884|9.4690|
| Signal-only Stop |0.0039|0.0041|0.0047|0.0337|

Published gates remain checkpoint1.5/3/9/30ms, pipeline0.5/1/3/10ms, mean added
CPU≤1.5ms and Stop<25ms. Max added checkpoint CPU0.696875ms; combined admission
CPU0.728125ms. Stress60.000679s/61,377cycles/max1queued/peak22,462bytes, with
bounded-memory receipt only; no invented per-cycle trace or native soak claim.
Worker cleanup and normal completed retention paths were confirmed.

## Reserve and draft

Native basis remains scoped/descriptive:
`H_basis=max(P11_BASIC164.429,P15_OPERATIONAL405.3797)=405.3797ms`;
`I_basis=max(P11_BASIC2972.325,P15_OPERATIONAL2653.0962)=2972.325ms`.
No change to historical native measurements, read policy, authority or reserves.
Fresh current-source checkpoint/admission overlap is counted with max, then
full operational collector pipeline is added conservatively. Shared guard250ms
is added once; margin100ms is subtracted once in the unchanged one-t0 deadline.
P17's S14.2102/R6761.9149proposal is not reused as current authority.

```text
S_current=max(overlapping checkpoint/admission maxima)+full v3 pipeline
         =10.2792+9.4690=19.7482ms
H_budget =405.3797+19.7482=425.1279ms
I_budget =2972.325+3120=6092.325ms
R_current=425.1279+6092.325+250=6767.4529ms
```

[False successor draft](../artifacts/5d1_source_timing_rebind_p18_v1/pilot_draft/pilot_draft.json)
is independently verified against the raw review/costs and final source294.
`accepted=false`, `live_acceptance=false`, no reasoning authority, run/expiry/
activation/claim null or false. Same P11 account/Starburst1289lv73/Phoenix user
declared/normal→normal/default_attack/SIMPLE/SOLO/foreground/two_click,
target3/max3TOTAL. Native26/anchors20/supplement7remain separate. It cannot
start or claim a batch. Current source is not grandfathered under old requests.

Maxima describe observed samples; they do not bound future OS/server behavior.
First exact click and native accepted-override latency remain NOT_MEASURED.
Completed retention retains incumbent BASIC pacing; its benchmark is not
native accepted-override input latency. Retention is normal, separate from
timeout/error/fallback; no forced
override or efficacy claim. Stress receipt has no per-cycle raw memory trace.

## Preservation and next

[Final preservation verification](../artifacts/5d1_source_timing_rebind_p18_v1/verification_final.json)
checks3,614immutable parent files, the byte-exact saved prefix of the existing
P15 idle UI event log (append reported separately, unused as native evidence),
4static game-file hashes, ordinary preferences, all4claims, host, HEAD and the
frozen294source map. Game files were hashed read-only; no runtime game read.
Historical native284/P13287/P14–P15290/P16291lineages remain distinct.

Exactly one next: **[P19 bounded SIMPLE successor pilot](../prompts/5D1_P19_BOUNDED_SIMPLE_SUCCESSOR_PILOT.md)**,
SELECTED ONLY / NOT EXECUTED. P19 needs user-prepared game/cohort and separate
bounded activation; no tool/game launch in P18. No general SIMPLE acceptance,
CAREFUL/Demon/Mega/D1cap12/D2. **STOP P18.**
