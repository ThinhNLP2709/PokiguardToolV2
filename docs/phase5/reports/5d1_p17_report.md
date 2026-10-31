# 5D.1-P17 — Source/timing review, offline

2026-10-15 (Asia/Saigon). **OFFLINE REVIEW COMPLETE / IMPLEMENTATION PENDING /
PARTIAL D1.** [Prompt](../prompts/5D1_P17_SOURCE_TIMING_REVIEW_OFFLINE.md),
[parent P16](5d1_p16_report.md),
[review/addendum proposal](../research/5d1_p17_source_timing_rebind_contract.md).
Chỉ file/data/source inspection; không code runtime, test/benchmark mới hoặc live.

## Kết luận

Đủ evidence hiện có để triển khai offline compatibility/timing v3, chưa cần
thêm trận. Chưa cấp current-source allowance hoặc activation. Hai việc cụ thể
cần sửa trước successor request:

1. Full commanded ceiling thiếu cursor settle của click thứ hai: **3120ms**
   mới đúng với params0.06/0.075s, thay vì current3060ms. Executor đã settle cả
   hai click; chỉ sửa accounting/setup, giữ cách action như cũ.
2. Current watchdog chỉ kiểm full-tail>R, chưa kiểm H/I budgets riêng. Đề xuất
   v3 monitor sau executor return, signal AI-only fault khi exceed, giữ BASIC/
   pending/ACK và không gửi input thứ hai. Đây là đề xuất, chưa implement.

Giữ normal completed retention là kết quả hợp lệ, không quota đổi nước. Không
gọi3WIN là efficacy/optimum hoặc sample maximum là future hard bound.

## Evidence đã tính lại

| Nguồn | Coverage / kết quả |
|---|---|
| P11 BASIC native284 | 30rows/3attempts;26returns/20full-witness ACK anchors,3opening-deferred ACK,3terminal-no-ACK,4EVOLVE gồm1failed |
| P15 operational290 | 7returns chỉ combat_0/6ACK+1matched terminal;1completed retention/1opening fallback/5SOURCE_CHANGED;16SWAP thiếu reasoning timing giữ UNKNOWN |
| P16 software291 | 61,000sealed raw cost values:30kstandard/24kadmission/6kpipeline/1kStop; recompute indices/warmup/quantiles/CPU, không rerun |

[P11 recomputation](../artifacts/5d1_source_timing_review_p17_v1/p11_raw_review.json):
exact AutonomousSource/action/result joins và watermarks30/30, all-attempt
ledger/original mixed-witness error giữ. Hmax164.429/Imax2972.325/full-tailmax
3132.4282ms; root49.7245/final4.9305ms. Không chỉ chọn20anchors để thu nhỏ cost.

[P15 supplement](../artifacts/5d1_source_timing_review_p17_v1/p15_operational_supplement_review.json):
Hmax405.3797/Imax2653.0962/full-tailmax3001.104ms; rootmax233.3348ms.
6/7H vượt old basis,5/7root spans vượt100ms. Không đổi nhãn thành BASIC calibration
hoặc giả dựng worker/timing cho hai trận sau. H tăng chủ yếu nằm trước existing
fresh marker trong các sample này; thiếu native substage durations để gán nguyên
nhân cho reader/selector/OS. Giữ read-span100ms.

[P16 cost recomputation](../artifacts/5d1_source_timing_review_p17_v1/p16_cost_recomputation.json):
published cost gates vẫn đạt khi dùng toàn bộ raw samples. Main completed
max8.9737ms, admission+3checks max8.9074ms, pipeline5.2365ms, Stop0.0207ms;
mean CPU0.6875/0.709375ms. Stress receipt/source đã kiểm, không có raw per-cycle
trace để độc lập remeasure. Main pipeline là BASIC collector, chưa đủ proof
future operational v3 monitor; P18 phải qualify actual affected final source.

Native U/transport/alignment null UNKNOWN, first exact click NOT_MEASURED.
Accepted-override native latency chưa có. Retention benchmark không là accepted
reasoned-input timing: current retained selection không có override receipt và
vẫn dùng incumbent pacing. Không tự thay behavior đó trong P17.

## Command ceiling, reserve và schema đề xuất

[Command source audit](../artifacts/5d1_source_timing_review_p17_v1/command_wait_review.json)
xác nhận send_swap gọi _send_one ở594/640 đều settle_cursor=True; sleeper ở547,
hold ở1089. `1000+1850+2*60+2*75=3120ms`. Current helper/draft builder/test
literals vẫn3060; không sửa hoặc rerun chúng trong P17. Guard250ms không thay
cho missing60ms; chưa có evidence lỗi này gây late input trong P11/P15.

[Latest reserve proposal v2](../artifacts/5d1_source_timing_review_p17_v1/reserve_proposal_v2.json):

```text
H_basis=405.3797 (max basic/operational, provenance tách riêng)
I_basis=2972.325
S=max(overlapping checkpoint/admission measurements)+full pipeline
 =8.9737+5.2365=14.2102
W_full=3120; guard=250; return margin=100
H_budget=419.5899; I_budget=6092.325
R_proposed=6761.9149ms
```

Đây là conservative proposal cho dữ liệu/source đã review, **accepted=false**.
Draft calculation v1 còn3060 được giữ và superseded rõ. Không update P11/P15
reserves hậu nghiệm, không cấp authority từ proposal, không reuse current numbers
cho final P18 source đã đổi. Native raw timing và command constants lịch sử giữ.

[Proposed v3 proof](../artifacts/5d1_source_timing_review_p17_v1/review_schema_proposal.json)
giữ base v2 source chain, exact P16 files/method hashes,7P15 supplemental costs,
correct command/addendum/mandatory monitor và fresh target qualification riêng.
Old raw rejection/finite-U semantics không nới; no generic exemption. Future
request phải có independent activation/source/host/build/cohort/cap/expiry/claim.
[34planned cases](../artifacts/5d1_source_timing_review_p17_v1/planned_cases.json)
đã chốt cho P18; đây không là34tests đã chạy.

## Preservation và next

Source **291 / a8aba6c01a3a5fa9eda6d46c1c7f84b4c1e577d080c4d015b0d68c0ebdac1638**,
version1.2.5/HEAD c646acfa… giữ. Native284 bb69e4c5…, P13 287 3fb6430a…,
P14/P15 290 10cc39c2… vẫn distinct. Host3a0ab45d… giữ.
Snapshot3,594immutable parent files +1existing P15 UI log prefix,4game files,
ordinary preferences/4claims/HEAD; [final verification](../artifacts/5d1_source_timing_review_p17_v1/verification_final.json) ghi separate append của
existing idle UI, không dùng làm native evidence mới.

151initial input pins và các source/command review refs đi kèm artifacts. Không
build/version/Git/preferences mutation, không game query/attach/read/capture/
input hoặc UI/observer launch. Không chạy test/benchmark cho docs-only review.

Next duy nhất **[P18 offline implementation/readiness](../prompts/5D1_P18_SOURCE_TIMING_REBIND_IMPLEMENTATION_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game/live test, chưa request/claim
mới, chưa D1cap12/CAREFUL/Demon/Mega/D2. **STOP P17.**
