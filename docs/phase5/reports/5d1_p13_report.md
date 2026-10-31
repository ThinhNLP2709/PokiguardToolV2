# 5D.1-P13 — Calibration review implementation và qualification offline

2026-10-15 (Asia/Saigon). **PASS SCOPED OFFLINE / LAUNCH READINESS PENDING /
PARTIAL D1.** Parent [P12](5d1_p12_report.md), [prompt P13](../prompts/5D1_P13_CALIBRATION_REVIEW_IMPLEMENTATION_OFFLINE.md).
User yêu cầu tiếp tục; chỉ triển khai scope offline, không kích hoạt game/pilot.
Source version **1.2.5**, HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`;
không build/version/Git mutation. Efficacy **NOT_APPLICABLE**.

## Đã hoàn thành

Một schema `pokiguard.reasoning.operational_calibration_review.v2`, verifier
setup/file-only và [utility export/verify](../../../tools/review_reasoning_calibration.py).
Review chuyên biệt cho cohort P11, không generic ignore mixed-witness errors.
Original v1 export/error/raw records và claims giữ nguyên. Old operational v1
và strict finite-U loader tiếp tục reject thiếu proof; runtime witness/equality
không đổi. Explicit v2 branch trong setup loader chỉ đi qua sau các gate request,
contract và independent activation vốn có; P13 không tạo activation thật.

[Package review](../artifacts/5d1_calibration_review_p13_v1/review_final/calibration_review.json)
copy byte-exact các input và cả22archive files/3consumed claims. Absolute paths
cũ chỉ là identity; mọi file mở bằng bounded package-relative ref + SHA, kiểm
traversal/alias/size/hash. Verifier dựng lại sequence, nguồn input/result, opening
diagnostics, strong terminal, all-attempt ledger/watermarks và maxima từ bytes.
Declared totals/classification phải bằng kết quả dựng lại.

| Evidence được giữ | N | Meaning |
|---|---:|---|
| Raw timing ledger | 30 | Toàn bộ26SWAP +4superseded decisions |
| Native match attempts | 3 | Giữ mọi kết quả, không reset consumed cap |
| Full observed Attack + ordinary ACK | 20 | Anchors đúng witness tương lai |
| Opening cards[], ACK | 3 | Host interval, ngoài scope suy luận |
| Terminal sent + complete host return, ACK0 | 3 | Matched lifecycle-ended +strong WIN; không biến thành ACK |
| Complete host intervals | 26 | N dùng tính reserve, gồm mọi SWAP return |
| Superseded EVOLVE decisions | 4 | Có3success/1failed; không duration0/input SWAP |

Full observed witness là scope duy nhất: SIMPLE/SOLO/normal→normal/default_attack,
P11 account/boss/fusion/card identity, foreground/two_click. Snapshot cards[]
hoặc mismatch giữ BASIC; không lấp missing cards bằng lobby, không read/chờ thêm.
Structural witness không là independent proof tên pet hoặc damage/effect model.

Đã reproduce old-active +cohort mismatch bằng actual owner loop trên exact
predecessor. `_prepare` trước đây giữ `active`, làm skipped result không signal
fallback; sửa duy nhất thành `self.completed = self.active = None` rồi invalidate.
[Red evidence](../artifacts/5d1_calibration_review_p13_v1/owner_loop_before.txt)
và current tests giữ. Không gọi đây là lỗi live đã quan sát.

## Source binding và bảo toàn flow

Native source284 vẫn `bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f`.
Final source287:
`3fb6430aff31ceac4224b0bdbcb012352b84b6fcbcae68a0d1fb1b6384591fe3`.
[Freeze/changed-file manifest](../artifacts/5d1_calibration_review_p13_v1/final_test_source_manifest.json)
và [source compatibility](../artifacts/5d1_calibration_review_p13_v1/review_final/source_compatibility.json)
giữ hai fingerprint riêng; native H/I/read/input dependencies không đổi. AST
comparison chỉ cho setup loader và exact owner invalidation exception đã reproduce;
mọi native file khác phải cùng SHA. Không relabel old native/P10 allowance.

280/284existing sources giữ byte.4existing changes: operational setup loader,
pilot owner correction, source-audit fixture và qualification tool.3new files:
review module, CLI utility và26tests. [Exact diffs](../artifacts/5d1_calibration_review_p13_v1/source_diffs/)
được lưu. Exact audit layers rewind side selected-Attack/UI fix, rồi P13 successor
về P10; historical C3/P10 manifests vẫn nguyên, không generic allowlist.

Reader, BASIC/solver, combat controller, selected-Attack entry correction,
desktop UI/controller, screenshot policy, executor/random/pacing/ACK và strict
finite-U modules giữ byte. Disabled controller AST và5paired traces
normal/pending/stale/wrong-turn/Stop exact: read/capture/input order giữ.
Stop vẫn signal; cleanup thuộc owner. Timing hoặc planner lỗi không đổi input
của BASIC còn hợp lệ, không second-input fallback.

## Kiểm chứng trên final source

**26new tests PASS; full regression 2,211/2,211 PASS trong289.372s**,
[raw full log](../artifacts/5d1_calibration_review_p13_v1/tests_full_final.log).
20[isolated mutations](../artifacts/5d1_calibration_review_p13_v1/independent_mutation_checks.json)
dùng fresh package riêng từng fault bổ sung kiểm card cost/cooldown/fusion/account/
boss/config, timestamp/source/partial, coverage/attempt và watermarks; đều reject.
Đủ26planned scenarios bằng unit/controller/source tests và qualification below.
Temporary packages/fake input/runtime; không native game capability.

[Final qualification](../artifacts/5d1_calibration_review_p13_v1/qualification_final/qualification.json):
**23/23gates PASS**. Mỗi path1,000warmup +5,000measured; không nới thresholds,
không sửa source giữa full run/qualification, không lặp phép đo để tìm PASS.

| Three checkpoints, ms | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| disabled | 0.0002 | 0.0002 | 0.0004 | 0.0117 |
| completed | 0.6741 | 1.0456 | 1.4232 | 6.1970 |
| timeout | 0.6683 | 0.9539 | 1.4160 | 2.3228 |
| error | 0.0430 | 0.0598 | 0.1004 | 0.3749 |
| fallback | 0.2830 | 0.4028 | 0.6908 | 1.4903 |

Thresholds giữ1.5/3/9/30ms. Added mean CPU ba checkpoints0.7125ms so disabled,
dưới1.5ms. Full host collector pipeline p50/p95/p99/max:
0.2323/0.3533/0.5693/9.1598ms, dưới0.5/1/3/10ms.1,000Stop signals max0.084ms,
worker reaped.60.0001s stress/149,851cycles, max1record, traced peak9,429B.
Raw checkpoint/pipeline/Stop records và source/host pins lưu trong qualification.
Không whole-app/native/VM soak hoặc future latency bound.

**Giới hạn quan trọng:** completed worker trả `BASELINE_TOP_IN_TOTAL_ORDER`, cả
ba checkpoint `RETAIN_BASELINE`. Đã đo completed-result validation/retention;
chưa đo nhánh accepted override có receipt. Error path là disabled/error-fallback;
actual worker exceptions/corrupt replies/hang/Stop có full regression riêng.
Không suy efficacy hoặc latency của accepted override từ completed benchmark này.
P14 phải xử lý limitation nếu muốn claim readiness cho đường đó.

Initial development failures giữ nguyên: missing qualifier rewind trong audit,
test dùng stale source hash và initial owner regression. Không lấy các lượt đó
làm acceptance; final run trên freeze đã PASS.

## Operational reserve và readiness

Hmax164.429ms/Imax2972.325ms/full-tailmax3132.4282ms lấy từ **cả26** returns,
root readmax49.7245ms/final readmax4.9305ms. First exact click NOT_MEASURED;
executor return là upper bound trên host, không proof server nhận input.

[Fresh selector allowance](../artifacts/5d1_calibration_review_p13_v1/review_final/selector_allowance.json)
pin current final source/host/raw qualification, max4paths **6.197ms**.
Không copy/relabel P10 9.9283ms. Công thức hiện tại:

```text
R_op = max(3000,1000,164.429 +2972.325 +6.197 +3060 +250)
     = 6452.951 ms
return_margin = 100 ms
max_read_span = 100 ms (operational veto policy)
```

100ms dùng qua existing root/final consumers, không thêm read hoặc đổi BASIC.
Native U/transport/alignment vẫn null. Sample maxima/allowance chỉ descriptive,
không population/server/OS guarantee; reserve chưa accepted cho live.
[Readiness draft](../artifacts/5d1_calibration_review_p13_v1/review_final/readiness.json)
ghi `accepted=false`, no run/expiry/claim/authority/activation.26host samples
và20anchors công bố riêng. Native old SHA và target final SHA vẫn riêng.

## Preservation và next

[Final verification](../artifacts/5d1_calibration_review_p13_v1/verification_final.json):
2,541parent artifact files,59native pins,4game files, HEAD/preferences giữ byte;
final287sources frozen. Existing P11 UI log prefix giữ,605snapshot_refreshed rows
append được theo dõi riêng. P13 không query/attach/read/capture/input/network game,
không khởi chạy observer/trận/UI hoặc ghi preferences thật; existing UI polling
không được dùng làm native evidence mới. BASIC/shadowOFF giữ mặc định.

Next duy nhất **[P14 — operational pilot launch readiness offline](../prompts/5D1_P14_OPERATIONAL_PILOT_LAUNCH_READINESS_OFFLINE.md)**,
SELECTED ONLY/NOT EXECUTED. Desktop hiện chỉ expose BASIC calibration request;
cần request/launcher setup độc lập và giải thích accepted-override benchmark gap
trước future pilot. Chưa cần mở game/live test, chưa AI input/D1draft12/D2.
**STOP P13.**
