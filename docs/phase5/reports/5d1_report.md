# 5D.1 — SIMPLE/CAREFUL pilot

Ngày **2026-10-16 (Asia/Saigon)**. RESULT **PASS STRONG — SCOPED TECHNICAL R1/RETENTION SIMPLE–CAREFUL**.
Parent5C.4/5C.3;BOUNDED_LIVE. Exactly one next prompt:
[5D.2](../prompts/5D2_SKILL_RUSH_ACCEPTANCE.md), chưa thực thi. Original12 và
targeted SIMPLE3 riêng đã hoàn tất;không build/version/commit/push/release.

## Per-profile verdict

| Profile/source | BASIC | REASONING | Verdict |
|---|---|---|---|
| SIMPLE/c707 |3/3WIN|3/3WIN;1job completed,then timing breaker atturn3|Rollback/flow observed;exposurePARTIAL;post-fix liveNOT_OBSERVED|
| SIMPLE post-fix/ba4856 |Original BASIC c707 exact-boundary-reviewed|3/3WIN;33jobs,allretain BASIC|PASS technical R1/retention;0worker/timing faults|
| CAREFUL/ba4856 |3/3WIN|3/3WIN;13completed jobs,allretain BASIC|PASS technical R1/retention integration;0worker/timing faults|

Original cap12 đã dùng hết12;targeted SIMPLE3 user cho phép riêng cũng hoàn tất.
15normal boss-lobby returns tổng cộng,0technical abort,
0observed critical safety counters. Không gọi12WIN là12trận do AI xử lý.
Không pool c707/ba4856 hoặc suy efficacy từ pilot tuần tự; BASIC vẫn default.
Full source/host/build/config hashes pin trong closures/requests dưới đây.
Current308source ba4856e56d34…, HEAD c646acfa5e895732bbdade553f9d7bd61171cd29;
original SIMPLE305/c707 giữ lịch sử. Package1.2.5/V1/game files không sửa.

## Cohort và flow

Starburst1289/lv73, Solo, Phoenix theo user; same structural witness account,
boss[99,84180,445,250,325],fusion[254767,2102],Attack64647/4,
normal→normal/default_attack. Foreground/two_click,AuditionV3,original1280x640.
ManualStart/private session preferences. Không thêm reader/capture hoặc đổi
executor/ACK/QTE/room/Stop để nghiên cứu. Shared guard chỉ monitor post-return;
không replacement BASIC sau input. Code không đổi trong lượt live CAREFUL.

## CAREFUL evidence

| Arm | FarmRunId | Turns proxy | Active elapsed | SWAP/ACK/terminal proof |
|---|---|---:|---:|---|
| BASIC |`2b64518433b4469abf2b45101ca8d2e1`|24|403.131s|24/21/3|
| REASONING |`886c96f171be495684dc50792aa5d328`|16|296.163s|16/13/3|

Different boards/time/turns không chứng minh suy luận tốt hơn. Account energy
debit UNKNOWN; turns chỉ là proxy. BASIC29timing events,24returns,18full ACK
anchors,Hmax329.2004ms/Imax2899.0576ms;5superseded decision events giữ nguyên.

REASONING67events=34selection+16swap_timing+13decision+1decision_timing+
3run_summary,allwritten/flushed/closed,0dropped.3workers/reaped3,
13submitted/completed/published,0fault/late/reject;3combats enabled,
first_faultnull.16sent swaps join independently với timing/action records:
13ACK+3strong terminal noACK proofs;16RETURNED,preflight/operational/component
fault đều null. Hmax241.784ms,Imax2811.6865ms. Sharedguard maxdebit0ms:
policy mới đã chạy nhưng positive debit/exhaustion chưa thấy live;
original2.722ms excess replay và pool exhaustion là offline proof.

Worker compute nearest-rank descriptive:N13,p50=42.7484ms,
p95/p99/max=63.232ms;không phải end-to-end/first-click latency. Selections:
NO_COMPLETED_PROPOSAL6,RETAIN_BASELINE26,SOURCE_CHANGED2. ROOT/final có thể ghi
hai lần/job;26selection không phải26jobs. Sourcechanged proposal không dùng
lại;opening/unavailable giữ BASIC. CAREFUL fault/breaker fallback0.

BASIC evolve4attempts/2success/2failed;REASONING1attempt/0success/1failed.
Không gọi zero mọi lỗi: nguyên nhân evolve_failed chưa phân tích/chưa quyAI;
không technical abort/critical counter. Evolve/QTE ngoài R1 swap scope này.
EmergencyStop live NOT_OBSERVED; không inject fault live.

## Rationale và limitations

13jobs RETAIN_BASELINE,reasonNEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE.
Ví dụM_39eee640/turn3,swap(2,5)↔(2,6),19candidates evaluated;baseline utility
[-1.375,5.765860592595376]. Resource-conversion/cap và execution-cost features
cònUNSUPPORTED;UNKNOWN exposure có risk penalty. Không đủ bằng chứng để
thay incumbent. [Rationale raw](../artifacts/5d1_main_pilot_20261016_v1/careful_reasoning/retention_rationale_case.json).
Completed retention hợp lệ theo user; không ép quota đổi nước.
Accepted override/native override latency NOT_OBSERVED. R1 one-step proxy,
không actual damage/win probability/fullrefill/R2/multi-turn model;
không suy Demon/Mega/Coop từ pilot này.

## Gates

| Gate | Verdict |
|---|---|
| CAREFUL enabled planner/preflight/ACK/terminal |PASS R1 retention scope;16raw joins|
| Critical flow/safety/return |PASS observed;allcounters0/12returns|
| Fault rollback beforedispatch |SIMPLE breaker dùng BASIC;offline real-controller tests;CAREFUL natural faultNOT_OBSERVED|
| Diagnostics/worker cleanup |CAREFUL PASS67/67records,3/3workers reaped|
| Offline implementation/cost |32/32eachprofile;fullruntime2368PASS/1outdated fixture expectation;fixture-only fix+51affectedPASS;not full2369PASS|
| SIMPLE current-source live afterfix |PASS targeted3/3WIN;33jobs;36raw joins;153/153records;0fault|
| Override/nativeU/transportalignment/efficacy |NOT_OBSERVED/UNKNOWN/notclaimed;no forced quota|

[Shared guard remediation](5d1_shared_guard_remediation_report.md) giữ exact
failure/fix/source compatibility. Original2.722ms excess physical cause
OS/GC/allocator vẫnUNKNOWN, không gán nguyên nhân khi chưa có trace.

Offline missing-evidence preparation xong: c707 BASIC exactboundary review
verified on currentba4856,40anchors/46returns (origin vẫnc707, không relabel
current observation);fresh SIMPLE sharedguard32/32raw costs recomputePASS.
[Targeted plan](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_plan.json):
một case SIMPLE post-fix,cap3REASONING attempts,cùngboss/pet/Attack/config,
không thêm BASIC controls. Plan file là snapshot ban đầu PREPARED_NOT_ACTIVATED. User sau đó đã yêu cầu
riêng và activated targeted3;batch này đã hoàn tất3attempts,không reset old
claim/breaker,không bonus attempts/P. Missing cases vẫn NOT_OBSERVED.

## Evidence / STOP

[Original ledger12](../artifacts/5d1_main_pilot_20261016_v1/attempt_ledger.json),
[BASIC closure](../artifacts/5d1_main_pilot_20261016_v1/careful_basic/closure.json),
[REASONING closure+pins](../artifacts/5d1_main_pilot_20261016_v1/careful_reasoning/closure.json),
[current request](../artifacts/5d1_main_pilot_20261016_v1/careful_reasoning/package/request_20261016_205352.json),
[watermarks](../artifacts/5d1_main_pilot_20261016_v1/careful_reasoning/relaunch_20261016_205352/ui_session/operational_pilot/watermarks.json).

STOP tại5D.1 đã đóng technical R1/retention scope. Next5D.2;5D.2 chưa chạy.
Búwin nhánh phụ khiuserbáo. Không build/release hoặc đổi defaultBASIC.


## Targeted activation snapshot trước Start

User đã xác nhận “Oke vậy tiếp tục đi”: activated riêng SIMPLE REASONING3,
original12 giữ nguyên. New UI PID33632 PREPARED, đúng Starburst73,0Start/claim.
[Manifest](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_20261016_v1/batch_manifest.json). ManualStart;cap3 gồm cảinvalid/abort;
không thêm BASIC controls,không automaticretry/build/sourcechange.
Đây là snapshot trướcStart;final closure/verdict ở mục dưới.


## Final SIMPLE post-fix closure — 2026-10-16

Farm `455c0d5856cf4c6493484a023704598d`,pilot
`fbb8a4ec480244469a5433d797c5db20`:3attempts/3completed/3WIN,0abort,
3normal return BOSS_LOBBY,FARM_TARGET_COMPLETED. Match IDs:
M_5641dfa3 (8localturns),M_f4163ba0 (16),M_021b6b15 (13).
37turns là toolproxy;account energy debitUNKNOWN. Active elapsed529.334s;
không so sánh throughput/efficacy với các boards/trận khác.

33submitted/completed/published jobs,allRETAIN_BASELINE;3workers/reaped3,
0fault/late/reject. Session không fault/disable;3COMBAT_OPTIONS_READY.
153records=78selection+36swap_timing+33decision+3decision_timing+3summary,
allwritten/flushed/closed,0loss. SelectionsNO_COMPLETED_PROPOSAL6,
RETAIN_BASELINE66,SOURCE_CHANGED6;không nhân checkpoint thànhjobs.

36sent swaps join independently với36timing returns:33ACK+3strong terminal
proofs. Every sentinput completed2clicks,current preflight;0component/
operational fault. Hmax232.4808ms,Imax3037.2101ms;sharedguard maxdebit0ms.
Workercompute:N33,p50=30.0033ms,p95=47.1742ms,p99/max=65.8292ms,
nearest-rank descriptive;không phảifirst-click/end-to-end bound.
2evolve attempts/success2,0failed. Allcritical safety counters0 observed.

Retention có rationaleNEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE,
[rationale raw](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_20261016_v1/retention_rationale_case.json).
Không có acceptedoverride live;điều này hợp lệ theo user,không ép đổiBASIC.
CurrentR1 không chứng minh damage/fullrefill/R2/actual best-move efficacy.
Positiveguard debit/exhaustion và emergency fault vẫnNOT_OBSERVED live;
scoped offline native replay/real-controller tests giữ nguyên evidence.

[Targeted closure+raw pins](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_20261016_v1/closure.json),
[targeted ledger3](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_20261016_v1/attempt_ledger.json),
[technical acceptance](../artifacts/5d1_main_pilot_20261016_v1/technical_acceptance.json).
Original ledger12/raw/failedsource exposure giữ nguyên,không pool.
SIMPLE control originc707 exact-boundary-reviewed trênba4856 là compatibility
proof,không current-source native observation;request/activation pin điều đó.

**5D.1 technical R1/retention gates đủ cho SIMPLE và CAREFUL.**
Next duy nhất[5D.2](../prompts/5D2_SKILL_RUSH_ACCEPTANCE.md),chưa triển khai;
SkillRush phải qua owncapability/offline/live gates,không promote theoD1.
BASIC vẫndefault;không source/build/version/release/commit trong lượt này.
