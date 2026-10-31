# 5D.1 — SIMPLE live và shared guard remediation

Ngày **2026-10-16**. Main **5D.1 PARTIAL / SHARED GUARD OFFLINE COMPLETE**.
Original cap12 đã dùng6: SIMPLE BASIC3/3WIN và SIMPLE REASONING3/3WIN.
Reasoning exposure chỉ1completed retention rồi timing guard tắt AI; không gọi
3WIN là3trận đã được planner xử lý đầy đủ. Zero observed safety counters,6returns
về boss lobby. [Live/repair report](5d1_shared_guard_remediation_report.md).

Đã sửa explicit opt-in shared250ms guard, không thay BASIC/read/input/ACK/room/
Stop hoặc tăng aggregate reserve. Source308 `ba4856e56d34…`; SIMPLE/CAREFUL
mỗi profile32/32 fresh cost gates PASS. Full runtime regression2,368PASS/1test
legacy expectation lỗi; fixture-only correction +51affected testsPASS, runtime
exact sau full run. Không relabel full failed log thành PASS.

Next trong cùng [5D.1](../prompts/5D1_SIMPLE_CAREFUL_PILOT.md): CAREFUL BASIC3 rồi
REASONING3,6attempts còn lại của cap12. SIMPLE post-fix live NOT_OBSERVED;
không tự thêm Simple trận bù hoặc sinh P. D1 chưa chốt/chưa sangD2.

## Kết quả SIMPLE đã chạy

| Arm | Attempts/WIN | Selection exposure | Timing/flow |
|---|---|---|---|
| BASIC |3/3|BASIC dispatch|46SWAP=43ACK+3strong terminal;40native anchors;53timing events/zero loss|
| REASONING |3/3|1job completed,1retention,0override; sau đó AI disabled|2timing returns trước breaker;23AI records durable/zero loss;3normal lobby returns|

Tất cả6attempts thuộc sourcec707, tính đủ vào cap. Cả hai FarmRuns final
FARM_TARGET_COMPLETED/BOSS_LOBBY, zero safety counters, worker1/1reaped.
[Basic closure](../artifacts/5d1_main_pilot_20261016_v1/simple_basic/closure.json),
[reasoning closure](../artifacts/5d1_main_pilot_20261016_v1/simple_reasoning/closure.json).
WIN không là efficacy/AI benefit claim; local turns chỉ tool proxy.

## Nguyên nhân cụ thể và cách sửa

Lượt3 trận đầu: H306.0019ms >303.2799ms khoảng2.722ms; I1438.1892ms;
aggregate1744.1911ms <reserve6753.3322ms. Guard cũ tắt AI khi vượt từng envelope,
chưa cho dùng250ms host slack đã nằm trong reserve. Planner đã completed
NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE →RETAIN_BASELINE, worker không fault.
DIAGNOSTIC_DISABLED do timing breaker; không writer mất log. OS/GC cause của
2.722ms tăng thêm vẫn UNKNOWN. First fault được giữ, không thay bằng secondary
FINALIZER_UNCONFIRMED phát sinh sau collector disabled.

Opt-in `SHARED_HOST_GUARD_V1`: ghi base H/I overrun như cũ; debit chung
max(0,H−Hbudget)+max(0,I−Ibudget). Chỉ fault nếu debit>250ms, aggregate>R hoặc
invalid timestamps. Không mỗi component250ms; không bù bằng unused envelope
của component khác. Legacy policyNone giữ behavior/hash lịch sử. Root250/final100,
max10ms,4s compute budget, reserve formula/margin/input/ACK/Stop không đổi.
[Policy review](../research/5d1_shared_guard_review.md).

## Offline verification

14new testsPASS, gồm raw native failure replay và real controller+real session
callback Simple/Careful:1input/1ACK, không replay khi guard exhausted.
Full suite2369:2368PASS,1outdated test-only legacy hash expectation. Đã sửa
fixture và chạy51affected testsPASS. Runtime/tools byte-exact sau full run;
không chạy lại toàn suite cho một test-only delta, không claim initial fullPASS.

| Profile | Gates | Pipeline p50/p95/p99/max ms |
|---|---|---|
| SIMPLE |32/32 PASS|0.2438/0.4129/0.6026/4.6704|
| CAREFUL |32/32 PASS|0.2438/0.4225/0.6119/5.8884|

Mỗi profile một invocation,61,000raw/51,000measured,60s stress, max10ms giữ.
Actual shared policy tagged in all6,000pipeline rows; independent recomputePASS.
[Verification](../artifacts/5d1_main_pilot_20261016_v1/shared_guard_remediation/verification.json).

Source308 `ba4856e56d3445ba217f09c71febfb7d5e16748b85ca9dcedd8880c4f05aaf87`.6existing files changed (3runtime,1qualifier,2tests),3new
(2helpers,1test);299existing exact. Controller/provider/input/pacing/ACK/room/Stop
full bytes giữ.8,969parent artifacts exact,oldclaims/game/preferences/HEAD
exact. Không build/version/Git write hoặc game write/network.

## Native source facts và bước tiếp

SIMPLE BASIC raw sourcec707 giữ nguyên. Exact AST/full-file boundary review chỉ
cho source delta ngoài BASIC H/I path; current source/host +fresh costs vẫn bắt
buộc. Không rewrite raw nguồn thành source mới, không lấy failed reasoningH
để tăng basis. Reviewed basis vẫn40anchors/46returns,H285.126/I3080.0523ms.
[Reviewed basis](../artifacts/5d1_main_pilot_20261016_v1/shared_guard_remediation/reviewed_simple_basis/native_review.json).
Các maxima là mô tả, U/transport/alignment vẫn UNKNOWN.

CAREFUL phải có controls của đúng profile trên source mới rồi mới reasoning.
Original remaining allocation3+3,không chạy bù Simple; source cohorts tách trong
ledger, không pool old/new outcomes thành efficacy. SIMPLE post-fix live vẫn
NOT_OBSERVED, báo rõ khi xét final D1 acceptance. Không advanceD2 ở lúc này.
