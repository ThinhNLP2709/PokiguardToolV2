# P17 — Source/timing rebinding proposal for the P16 successor

2026-10-15 (Asia/Saigon). **REVIEW COMPLETE / PROPOSAL ONLY.** Không runtime
change, test/benchmark mới, request/claim hoặc live authority. Parent accepted
[P9 contract](5d1_p9_operational_timing_contract.md) và decision SHA được giữ;
đây là addendum đề xuất, không sửa văn bản/raw/request lịch sử.

## 1. Bằng chứng và source lineage

| Nhóm | Source | Vai trò |
|---|---|---|
| P11 native284 | bb69e4c5… | BASIC-only calibration,30records/3attempts |
| P13 source287 | 3fb6430a… | V2 verification của original P11 |
| P14/P15 source290 | 10cc39c2… | Setup successor và bounded operational run |
| P16 current291 | a8aba6c0… | Lifecycle/admission remediation, fresh offline costs |
| Future P18 | Chưa có | Phải freeze/qualify/review source thực tế, không copy pin P16 |

[Exact lineage/files/method pairs](../artifacts/5d1_source_timing_review_p17_v1/review_schema_proposal.json)
pin full SHA và6existing changes/1new test. Native review P14 target290 không
được gọi là review current291.6files đổi gồm2production modules,1offline
qualifier và3test files; new file là test. Không generic exemption cho một file
hoặc method chỉ vì tên quen thuộc. Dù code mới chỉ thêm veto, hot path vẫn có
thay đổi và cần cost evidence của đúng source.

Session setup/retirement chủ yếu ở boundary/background. observe chạy trước BASIC,
_reason chạy ở các checkpoint, _prepare/_complete ở owner, await ghi budget
trước decision-exit. Reader/controller/executor/ACK/base selector/timing collector
giữ byte ở P16. Background scheduling/OS vẫn có thể ảnh hưởng native latency;
không suy exact native H từ một microbenchmark.

## 2. Recompute native rows, không thay nhãn

[P11 raw review](../artifacts/5d1_source_timing_review_p17_v1/p11_raw_review.json)
kiểm package SHAs,30ordered rows, exact AutonomousSource/action/result joins,
watermarks30/30 và all-attempt ledger:

- 26SWAP host intervals:20full-witness ACK anchors,3opening-deferred ACK,
  3terminal-no-ACK có matched terminal HP/result/session/sequence.
- 4superseded EVOLVE decisions:3success/1failed; không xoá failed action.
- Original `MISSING_OR_MIXED_RUNTIME_WITNESS` giữ nguyên, opening cards[] có
  deferred-discovery proof. Không sửa original v1 export thành sạch giả.
- Max H164.429ms/I2972.325ms/full-tail3132.4282ms;
  root49.7245ms/final4.9305ms.26returns đủ cost envelope,20anchors đủ full witness.

[P15 supplement](../artifacts/5d1_source_timing_review_p17_v1/p15_operational_supplement_review.json)
giữ scope operational source290:7returns chỉ combat_0,6ACK/1matched terminal,
3actual attempts và16SWAP không có reasoning timing. Budget1completed/1opening
fallback/5SOURCE_CHANGED;5root spans218.2233–233.3348ms bị policy100ms loại.
Không đổi raw lý do cũ thành lý do P16, không gọi7returns là7reasoning jobs hoặc
BASIC-only calibration. Chỉ dùng chúng bổ sung chi phí fallback/retention đã
quan sát; high root span không biến thành admission proof.

P15 Hmax405.3797ms, Imax2653.0962ms, full-tailmax3001.104ms.6/7H vượt cả P11
samplemax164.429 lẫn old H+selector173.5076ms, nhưng0full-tail vượt old R6455.8326ms.
Ở sample Hmax, decision-exit→fresh-marker326.988ms, fresh→final78.0553ms và
final-marker→preflight-start0.3364ms. Các marker khoanh vùng coarse controller
work, không đo riêng reader/solver/OS. Chưa xác định nguyên nhân sâu của root
spans hoặc H tăng; không thêm observer/read/capture để tìm trong bước này.

Native U/transport/alignment vẫn null UNKNOWN; first exact click NOT_MEASURED.
Executor return là upper bound trên host, ACK/terminal là evidence riêng.

## 3. Chi phí P16 đã kiểm lại từ raw

[Recomputation](../artifacts/5d1_source_timing_review_p17_v1/p16_cost_recomputation.json)
kiểm61,000raw cost values:30,000standard checkpoints,24,000admission+checkpoints,
6,000pipeline và1,000Stop. Giữ đúng index/warmup/path, không bỏ outlier.
Sau warmup có51,000measured values. Source291/host pin khớp.

Standard completed max8.9737ms; admission+3checks max8.9074ms. Không cộng đôi
hai measurements trùng chức năng: dùng max8.9737ms. Pipeline max5.2365ms được
cộng toàn bộ như allowance bảo thủ, dù instrumentation đã có trong native H/I.
S_proposal =8.9737+5.2365=**14.2102ms**.

Published latency/CPU/pipeline/Stop thresholds đều đạt khi recompute. Added mean
CPU standard0.6875ms, admission combined0.709375ms; Stop max0.0207ms. Stress
receipt60.00049s/154,399cycles/max1record/peak9,437B được source/receipt audit;
không có raw per-cycle memory/time trace để độc lập đo lại stress. Không rerun.

Completed benchmarks RETAIN_BASELINE/BASELINE_TOP_IN_TOTAL_ORDER, khác P15
near-tie reason. Current retained result không có override receipt và còn dùng
incumbent pacing; không gọi nó là accepted reasoned-input latency. Không quota
đổi nước, không fabricate board/model. Native accepted-override latency chưa có.

Main pipeline đo BASIC collector với authority=None. Nó chưa đo đầy đủ future
v3 operational collector/monitor. P18 phải qualify actual affected path cùng
fresh final source;14.2102ms ở đây chưa là allowance có quyền dùng cho P18.

## 4. Hai điểm phải xử lý trước successor request

### Full commanded ceiling thiếu một cursor settle

[Source audit](../artifacts/5d1_source_timing_review_p17_v1/command_wait_review.json):
send_swap gọi _send_one ở594 và640, **cả hai settle_cursor=True**. _send_one
sleep cursor_settle ở546–547; mỗi backend click hold một lần ở1084–1090.
Reaction≤1000ms, inter-click commanded cap1850ms. Do đó:

```text
W_full = 1000 +1850 +2*cursor_settle_ms +2*mouse_hold_ms
       = 1000 +1850 +2*60 +2*75 =3120ms
```

Current command_wait_ms chỉ cộng1settle nên trả3060ms; draft builder cũng
hard-code3060, tests dùng literal đó. Cần sửa phép tính/setup, **không sửa
executor hoặc giảm delays**. I samples đã chứa actual waits; cộng W_full lần
nữa vẫn là chủ đích bảo thủ của P9. Guard250ms không thay cho accounting thiếu
60ms. Không có bằng chứng missing60ms đã gây late input; không đổ lỗi cho flow
đang chạy. Historical3060/old reserve records giữ nguyên.

### Watchdog chỉ kiểm aggregate

[Source + raw audit](../artifacts/5d1_source_timing_review_p17_v1/component_watchdog_review.json):
SwapTimingCollector.finish hiện kiểm missing/nonmonotonic decision interval và
full-tail>R, chưa kiểm riêng H/I budgets. Vì thế old H drift không có component
fault. Không được quảng bá old per-component estimates như caps đã được enforce.

Đề xuất v3 opt-in monitor tại **finish sau executor return**, trên timestamps đã
có. Nếu H>H_budget, I>I_budget, tổng>R hoặc interval invalid: ghi component flag/
reason/limits và signal AI-only fault qua callback hiện có. Không send BASIC
thay thế sau input, không đổi pending/ACK, không pause/recover game chỉ vì AI.
Payload fault và final session receipt phải nhất quán; không ghi đôi trace.
Legacy/no-authority calibration giữ đường cũ. New reviewed-v3 request bắt buộc
monitor; thiếu/tắt/đổi mode bị từ chối ở setup.

## 5. Reserve đề xuất, chưa có authority

[Latest proposal v2](../artifacts/5d1_source_timing_review_p17_v1/reserve_proposal_v2.json)
supersede bản tính đầu còn3060. Cả hai accepted=false; giữ bản đầu để thấy lý do
sửa, không dùng nó trong future request.

```text
H_basis = max(P11 BASIC Hmax, P15 operational Hmax) =405.3797ms
I_basis = max(P11 BASIC Imax, P15 operational Imax) =2972.325ms
S       =14.2102ms (current offline checkpoint/pipeline proposal)
W_full  =3120ms; G_host=250ms; M_return=100ms
H_budget=H_basis+S =419.5899ms
I_budget=I_basis+W_full =6092.325ms
R_op    =max(3000,H_budget+I_budget+G_host) =6761.9149ms
```

H_basis là **combined scoped host cost basis**, không đổi P11 Hnative thành
405.3797ms. Counts26BASIC/20anchors/7supplement tách riêng. Không dùng33 làm số
full-witness anchors. G_host cộng đúng một lần vào aggregate, không chia đôi
rồi dùng lại cho từng component. Các component budgets là conservative policy
envelopes đề xuất, không population/server/OS guarantees.

Deadline giữ t0-based min(B,raw_remaining−R−M), Bdefault4000/cap6000ms;
remaining window tại now phải≥50ms. Với raw11s còn full4s từt0; raw7s chỉ còn
138.0851ms từt0 trước khi trừ elapsed, nên có thể fallback ngay. Không đợi tới
một mốc7s/5s, không thêm poll/read hoặc rút mandatory input để có thêm compute.

## 6. V3 proof và implementation boundary

[Proposed schema](../artifacts/5d1_source_timing_review_p17_v1/review_schema_proposal.json)
phải kiểm độc lập:

1. Original v2 native review với chính target290 và nguyên P13/P14 chain.
2. P16 full manifest/diffs/method hashes exact; không generic allowlist.
3. Supplemental P15 hashes/joins/coverage/errors/missing rows, chỉ cấp cost basis.
4. Correct command version, effective budgets, mandatory v3 monitor và addendum.
5. Fresh raw qualification cho final P18 source/host; không reuse P16 acceptance.

Old v1/v2 raw rejection semantics và strict finite-U loader không được nới.
Sửa command helper là conservative accounting correction cho current source;
không grandfather old source-bound requests. Parent P9 contract/accepted decision
giữ nguyên SHA. New draft/review phải pin addendum này cùng parent; new live
activation vẫn độc lập với exact config/run/cap/source/host/build/expiry/claim.

P18 scope hẹp: corrected command helper + separate v3 setup verifier/exporter,
session truyền validated monitor option, collector post-return component fault,
tests/qualification và false draft. Không sửa reader/controller/BASIC/solver/
planner/model/executor/ACK/FarmRun/room/recovery/ordinary preferences.

[34planned cases](../artifacts/5d1_source_timing_review_p17_v1/planned_cases.json)
gồm same-file protected edits, raw max/warmup tamper, incomplete lineage/joins,
wrong counts/labels, real fake-executor wait trace, H/I boundary+1ns/aggregate,
missing monitor, fault-after-input no replay, source/deadline/Stop/cap/cleanup,
legacy/default parity và UNKNOWN-U forgery. Đây là planned cases, không tests
đã chạy trong P17.

## 7. Route

Đủ dữ liệu để **triển khai/review offline** v3 với các giới hạn trên; chưa cần
calibration/trận mới để làm bước đó. Chưa đủ live acceptance hoặc general SIMPLE
coverage. Next duy nhất P18 offline implementation/readiness; nếu PASS mới chọn
bounded successor pilot riêng, user/manual Start, cap mới được kích hoạt độc lập.
Không mở CAREFUL/Demon/Mega/D1cap12/D2 hoặc học model từ3WIN.
