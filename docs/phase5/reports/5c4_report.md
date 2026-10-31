# Phase 5C.4 — Guarded completed proposal → existing preflight

Date: 2026-10-11 (Asia/Saigon). Parent: [C3](5c3_report.md),
PASS_OFFLINE_LIVE_PENDING. Mode: **OFFLINE_INTEGRATION**.
Result: **PASS STRONG — scoped offline integration**. Efficacy: NOT_APPLICABLE.

User activated the next main-flow step; Bú win live retest is deferred. No
game attach/read/input, live batch, network/API, build/package, version change,
commit/push/tag or edits to PokiguardAuto/pc occurred.

Source: v1.2.5, HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, branch
`codex/phase3a2-board-repair`. Historical accepted baseline remains v1.2.4.
Current worktree includes the separately documented Bú win correction; it was
preserved byte-for-byte. Historical C3 acceptance was not re-labeled.

## Implementation and supported scope

- [reasoning_selection.py](../../../src/pokiguard_v2/reasoning_selection.py):
  immutable completed proposal, scoped capability, bounded host selector and
  safe exception/disposition wrappers. No provider/executor/worker ownership.
- [basic_auto_bot.py](../../../tools/basic_auto_bot.py): default-None optional
  selector, root/fresh/final checkpoints. No production factory, CLI switch or
  UI activation. Both injected shared runtime and PID0 native fakes are
  required for C4 selection; real process selection remains gated.
- [controller fixture](../../../tests/reasoning_controller_fixture.py): optional
  offline scenario injection and exact C4 source binding, keeping C3/side-fix
  historical bindings intact.
- [27 focused tests](../../../tests/test_reasoning_selection.py),
  [qualification tool](../../../tools/qualify_reasoning_selection.py) and
  [frozen protocol](../research/5c4_offline_selection_protocol.md).

Supported **offline only**: Simple/Careful ordinary SWAP→SWAP,
Normal/Normal/default Attack, completed R1 one-step proxy with explicit bound
model/legality/timing. Other loadouts, profiles, non-SWAP action families,
Coop/Bú win, R2 promotion and uncalibrated live reserves remain gated. Existing
shadow snapshots carry missing model/reserve/generation and cannot be promoted.

## Binding, fallback and unchanged owners

The off-path preparation reuses the existing runner's strict wire validation:
job/generation/source/snapshot/config/clock, action coordinates, candidate
attribution, input authority false and R2 false. It additionally pins the full
controller critical-state hash, all64 observed cells, self HP/resources,
profile/loadout, model/utility versions and explicit account/boss/loadout model
scope. The immutable BASIC action and full PolicyConfig are frozen into the job.

Only a completed scored R1 SWAP with robust lower-vs-baseline-upper gap≥0.05
and existing simulator legality proof may propose an override. Settings are
unchanged and advisory. Actual actionability, turn ownership, source freshness,
timer floor, coordinates and all existing reservations/preflight remain hard.
Preparation/simulation occurs off the action path; checkpoints do not run the
planner, wait, poll, capture, spawn or join.

Root invalid/unsupported/missing/late/fault → existing BASIC. Fresh state change
→ existing discard path; stale BASIC is not executed. On still-valid fresh
source, late/invalid/log failure rebinds the existing **unsent** reservation to
the already computed fresh BASIC decision. No extra policy/provider read occurs.
For valid proposals the existing fresh BASIC call is retained, while heuristic
move equality is replaced by the bound proposal check.

Final direct-runtime check keeps ownership/turn/sequence/timer requirements and
also rejects at/after the original absolute job deadline or candidate reserve.
This deadline is never extended. Invalidation after mapping/reservation cancels
through the existing preflight path; a subsequent existing iteration may use
BASIC. No alternate input is sent inside that final reservation. After any
sent/uncertain input, existing pending/ACK/recovery owns continuation; no AI
retry or replacement BASIC. QTE/PASS/Evolution/skill/lease semantics unchanged.

## Offline evidence

**41/41 qualification gates PASS**:
[qualification](../artifacts/5c4_guarded_selection_v1/qualification.json),
[raw controller traces](../artifacts/5c4_guarded_selection_v1/controller_traces.jsonl).

[Final verification](../artifacts/5c4_guarded_selection_v1/verification.json):
44/44 gates including full regression, all27 C4 tests on final source and no
source drift after qualification. [Patch](../artifacts/5c4_guarded_selection_v1/changes.patch)
and [artifact hashes](../artifacts/5c4_guarded_selection_v1/artifact_manifest.json).

The real archived pre-C4 controller and current controller execute the same
five normal/stale/final-wrong-owner/pending/Stop cases. Result, full call order
and gameplay JSON rows match exactly; only log pathname is normalized.
Controller AST reconstructs identically after removing exactly four optional
C4 blocks, two local assignments and the new keyword. Default import has zero
reasoning modules/resources.

Positive fixture: generated seed2 board, local HP40/100. BASIC selects Sword
`(6,1)↔(6,2)`; real R1 selects `(1,2)↔(2,2)`, collecting Health under an
explicit **SYNTHETIC_SPEC** healing proxy. Simple's configured30% threshold
is unchanged. Robust gaps: Simple0.915, Careful4.08 (proxy utility, not HP or
win probability). Both proposals pass the actual controller, mapping and
normal executor fake, then receive exact durable fake ACK. Native call/read/
capture order equals archived BASIC. This proves software selection freedom;
it does not validate healing20, damage, survival or superiority in the game.

Controls include real planner retention, near-tie/nonfinite/malformed worker
reply, stale job/config/source, exact deadline boundary, missing model/reserve,
unsupported profile/family, changed participant state, insufficient fresh/final
reserve, diagnostics full/disabled/exception, Stop at root/fresh/before input,
final expiry and pending ownership. No double input, stale/wrong-owner input,
input after Stop or replacement while pending in these fixtures.

Full regression: **2006/2006 PASS in218.574s**, including all27 C4 tests:
[full log](../artifacts/5c4_guarded_selection_v1/full_regression.txt).
Initial22 and expanded27 focused tests also passed; final source is verified by
the full suite rather than treating earlier focused logs as acceptance of later
source changes. The printed controller-lock error inside an expected-failure
test is not a suite failure; final unittest result/exit code are OK/0.

## Host timing and diagnostics

[Raw samples](../artifacts/5c4_guarded_selection_v1/checkpoint_timings.json):
native perf_counter timing with a completed fixture already prepared,3×1000
root/fresh/final triples. Construction/worker/planner/IPC/input are outside this
measurement. All raw tails retained; each block also passes the frozen A3 SLO.

| Checkpoint | N | p50 ms | p95 ms | p99 ms | max ms |
|---|---:|---:|---:|---:|---:|
| Root selection |3000|0.1297|0.2229|0.3275|1.6167|
| Fresh validation |3000|0.1004|0.1725|0.2802|0.5910|
| Final validation |3000|0.0992|0.1638|0.2613|2.6947|
| All three |3000|0.3344|0.5588|0.8205|3.5731|

270 fault-known→BASIC trials,30 per9 variants: all retained without waiting;
largest observed disposition0.8839ms.100 signal-only Stop trials: p95
0.0006ms,p99 0.0008ms,max0.0013ms. These are scoped host/software measurements,
not an OS hard bound or calibrated game input reserve.500/2000ms reserves are
explicitly synthetic; live reserve remains UNKNOWN.

C4 diagnostics use an externally owned bounded try-lock buffer,≤432 records/
6MiB and≤8 small events/second; no disk callback/new writer on this path.
Job/generation/snapshot/config and checkpoint/reason are logged. Selected is
not labeled dispatched; actual dispatch/ACK stays in the existing controller
log. Queue/enqueue failure disables/retains safely. Overload has counters;
100 same-second selections admit8 records (<8KiB),92 rate-limited. No full
graph/prompt/image is enqueued. C1/C3 separate capped sink remains the production
shadow policy. C4 writer/whole-app CPU/RAM/soak/UI/live overhead NOT_MEASURED;
no broader backend/resource acceptance is inferred from these timings.

## Source freeze and remaining gates

[Before manifest](../artifacts/5c4_guarded_selection_v1/before_source_manifest.json):257
Python sources.255 retained byte-identically; only controller seam and offline
fixture/audit helper changed. Three new Python files →260 total.
[Current manifest](../artifacts/5c4_guarded_selection_v1/source_manifest.json), fingerprint
`81a71fed954e1d95829c13f760cd9d31cb3f844b174eee27cf135e27ab28b92a`.
Exact runtime binding:
[after_runtime_manifest](../artifacts/5c4_guarded_selection_v1/after_runtime_manifest.json).
All six Bú win runtime fixes and BASIC/provider/capture/input/UI/version sources
are retained. Before-images, patch and final artifact manifest provide provenance.

| Required C4 gate | Result |
|---|---|
| Completed proposal/job/config/source/capability/timing binding |PASS offline|
| Tactical override without mutating settings; hard legality retained |PASS scoped synthetic fixture|
| Existing executor/preflight/read/capture/ACK ownership |PASS exact offline traces/AST|
| Fault/late/reserve/Stop/pending fallback, no double input |PASS offline|
| Disabled exact BASIC parity and no AI import/resource |PASS offline|
| Full regression on frozen current source |PASS2006/2006|
| Production gated; no live/build/version/Git mutation |PASS|

Live attempts0; game build/effects/account/actual resource formulas/efficacy and
packaged acceptance NOT_MEASURED. C3 live closure is still pending and must bind
the current frozen source/config; historical142 gates cannot silently certify
new source. Bú win remains a separate deferred retest.

Router: C4 offline PASS STRONG → exactly one next:
**[C3 live closure](../prompts/5C3_BASELINE_SHADOW_AND_FAULT_ACCEPTANCE.md)** using
[bounded runbook](../research/5c3_measurement_return_plan.md). No D1 advancement
before closure; live is not activated by this offline step. STOP at C4.
