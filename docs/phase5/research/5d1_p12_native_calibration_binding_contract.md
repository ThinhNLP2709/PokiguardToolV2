# P12 — Đề xuất binding cho calibration đã thu

2026-10-15 (Asia/Saigon). **REVIEW COMPLETE / PROPOSED FOR OFFLINE IMPLEMENTATION.**
Đọc cùng [P11](../reports/5d1_p11_report.md), [P9 accepted contract](5d1_p9_operational_timing_contract.md)
và [inventory đã đối chiếu](../artifacts/5d1_native_binding_p12_v1/accepted_data_inventory.json).
Tài liệu này chưa sửa schema, loader, witness hoặc bật suy luận.

## 1. Kết luận từ dữ liệu gốc

Reader chủ động ưu tiên bàn cờ mở đầu. [Predicate](</D:/PokiguardToolV2/src/pokiguard_v2/memory_board_provider.py:605>)
xét local turn, turn0/1, local move sequence0 và last sequence chưa có.
Session reset xóa card cache; khi predicate đúng, reader bỏ optional selected-card
reads, không khám phá CardUI và đánh dấu layout `opening_board_action_priority`.
State vẫn có bàn cờ hợp lệ để BASIC đi SWAP. [Witness hiện tại](</D:/PokiguardToolV2/src/pokiguard_v2/reasoning_pilot_contract.py:15>)
chép `state.cards` vào trường mang tên loadout, nên danh sách quan sát chưa đủ
bị so sánh như thể đó là toàn bộ bộ thẻ đã trang bị.

Cả ba log combat có diagnostics tại line5: card cache0, selected count null,
preentry Attack64647/card4, live cards[], layout `opening_board_action_priority`.
Tại line20, reader đã validate current-hand card/fusion và live Attack xuất hiện.
Ba mẫu witness rỗng đều ở turn1; account/boss/fusion/config bằng các mẫu sau.
Đây là bằng chứng của đường hoãn discovery trong source và log hiện tại;
không phải bằng chứng người chơi gỡ thẻ. Không kết luận nguyên nhân hình thẻ
không nhận diện được, actual pet effects hoặc lỗi EVOLVE từ dữ liệu này.

| Phân loại raw | Số mẫu | ACK | Dùng làm gì trong đề xuất |
|---|---:|---:|---|
| Opening discovery deferred, cards[] | 3 | 3 | Giữ timing; ngoài phạm vi witness cho suy luận |
| Observed Attack witness, ordinary ACK | 20 | 20 | Anchor calibration cho đúng witness đã quan sát |
| Observed Attack witness, trận kết thúc | 3 | 0 | Giữ host interval và terminal evidence; không tạo ACK |
| Decision superseded trước preflight | 4 | Không áp dụng | Giữ ledger; join với4EVOLVE attempts, không gán input duration0 |

Tổng30records,26SWAP intervals,3attempts, watermark30/30 written và zero loss.
3terminal samples có một sent, một `COMBAT_LIFECYCLE_ENDED` và terminal WIN
nhất quán trong đúng attempt. Original export v1 vẫn giữ lỗi mixed witness.

## 2. Một phương án: phạm vi witness đầy đủ, ledger giữ nguyên

Đề xuất một **review sidecar phiên bản2 cho operational calibration**, tên schema
`pokiguard.reasoning.operational_calibration_review.v2`. Đây là schema đề xuất,
chưa tồn tại trong runtime. Không thay nghĩa `state.cards` hoặc điền card từ lobby
vào snapshot planner. Không sửa `runtime_witness`, strict finite-U authority,
hoặc equality của `OperationalPilotAuthority.matches`.

Chọn đúng một full observed witness từ P11: account hash/boss stats/fusion IDs/
normal-normal-default_attack và Attack64647/card4 với các cost fields đã quan sát.
20ACK-joined samples cùng witness là anchors; không gọi chúng là damage/skill
cost validation. Future ordinary SWAP chỉ được xét suy luận khi **state hiện tại**
khớp witness này và qua các owner/source/legality/deadline gates hiện có.
Cards[] hoặc witness khác giữ BASIC; không thêm read, chờ CardUI hoặc gắn một
rule chiến thuật mới vào PlayStyle. Không cấm suy luận ở turn1 nếu tương lai
state thực sự đã khớp đầy đủ; phạm vi dựa trên dữ liệu, không số turn cố định.

Sidecar giữ ba khái niệm riêng:

| Trường đề xuất | Nội dung bắt buộc |
|---|---|
| `raw_export` / `raw_records` | Ref path+SHA cho nguyên export v1 và toàn bộ30records; không sửa bytes/errors |
| `all_attempts` / `watermarks` | Cả3attempts và toàn bộ writer accounting, source/config/build/host/claim gốc |
| `row_classification` | Mỗi event_seq đúng một phân loại raw có ref/line/source; tổng phải phủ30/30 |
| `anchor_rows` | Chính xác20rows đầy đủ witness+sent+ACK; không là quyền input |
| `host_interval_rows` | Cả26completed physical-return intervals, gồm3opening và3terminal |
| `retained_non_anchor_rows` | 3opening,3terminal và4superseded, kèm lý do và bằng chứng; không bị xóa |
| `proposed_scope_witness` | Full witness đã quan sát, không wildcard/union/normalization |
| `native_runtime_sha256` | Fingerprint284 của P11, giữ nguyên |
| `target_runtime_sha256` / `compatibility_review` | Source tương lai + review dependency chính xác; không đổi nhãn native SHA |
| `activation` | False/không cấp quyền; future live cần request/review/claim độc lập |

Verifier mới phải dựng lại joins và classification từ raw source, không tin
những totals/indices do sidecar tự khai. Khi đọc nguyên v1 export, chỉ mixed
witness có giải thích đầy đủ theo hai nhóm trên mới được review theo nhánh v2;
bất kỳ lỗi khác, nhóm thứ ba, thẻ/cost/account/boss/fusion thay đổi, thiếu raw
hoặc không chứng minh được deferred opening đều reject. V1 loader vẫn reject
export lỗi như hiện tại; strict finite-U loader giữ nguyên bytes/semantics.

V1 còn đòi ordinary ACK cho mọi completed-input row. Vì vậy chỉ sửa mixed-witness
và source SHA cũng chưa làm P11 hợp lệ: ba terminal rows cần classification
riêng có chứng cứ trong nhánh v2, không được bỏ khỏi records hoặc biến thành ACK.

Future package chứa byte-exact copies của evidence cùng một mapping đã pin từ
original file identity sang archive-relative path+SHA. Không sửa absolute-path
strings trong export cũ và không blindly mở các path do export khai. Verifier
chỉ đọc bounded refs nằm trong package như `_document` hiện có, kiểm cả mapping
và original expected SHA. P11 native archive đã giữ đủ raw FarmRun, gồm2failed
openings trước; copy package sau này không biến thành một native run mới.

Đây là thu hẹp scope cho authority tương lai và bổ sung review dữ liệu; không
biến opening chưa đủ thẻ thành state được phép override. Phạm vi này chỉ cho
Simple/Solo/foreground/two_click với exact policy và cohort P11, không tự mở
Careful, Demon, Mega, Coop hoặc hiệu ứng model chưa có bằng chứng.

## 3. Reserve dùng tất cả host intervals

Anchors và envelope có mục đích khác nhau. Tính H/I/full-tail maxima trên **cả26**
valid completed host intervals; không giảm envelope bằng cách bỏ opening hoặc
terminal không có ordinary ACK. Vẫn công bố N20 anchors/N23ACK/N26host/N30records
và mọi excluded reason. Unknown/partial interval phải giữ trong ledger; thiếu
thời điểm cần thiết thì không tự điền0 hoặc claim bound cho input chưa hoàn tất.
V2 ghi riêng `native_host_interval_N=26` và `calibration_anchor_N=20`;
nếu dùng field authority hiện có `calibration_samples` thì nó là26host intervals
đã dùng tính reserve, không mô tả26ACK. Diagnostic/readiness phải công bố cả hai N.

P11 cho Hmax164.429ms, Imax2972.325ms, full-tailmax3132.4282ms. Các maxima cũng
nằm trong nhóm full-witness, nhưng công thức vẫn phải dùng cả26. Command ceiling
3060ms từ pinned settle0.06s/hold0.075s, host guard≥250ms, return margin≥100ms.
Minimum action floor3000ms giữ. Đợi fresh selector allowance, rồi áp dụng:

```text
R_op = max(3000, 1000, 164.429 + 2972.325 + H_extra_current + 3060 + 250)
```

6456.6823ms với H_extra cũ9.9283ms chỉ là số học tham khảo, không reserve accepted.
Mọi maximum là descriptive small-N; native U/transport/alignment tiếp tục null.
Không dùng RTT, raw timer hoặc executor-return để tạo proof server-clock.

Đề xuất **max_read_span_ms=100.0**, chỉ là policy veto trên host cho cùng scope:
P11 root spanmax49.7245ms/finalmax4.9305ms nằm dưới ngưỡng này.100ms không được
suy ra như một future bound hoặc clock uncertainty. Root/final vượt ngưỡng thì
loại reasoned proposal theo gate hiện có, giữ BASIC nếu còn hợp lệ; không thêm
read/sleep và không phát fallback lần2 sau bất kỳ input. Giá trị100ms chưa áp dụng
trong P12; implementation/readiness phải kiểm đúng consumer và boundary cases.

## 4. Source và benchmark

[Compatibility ledger](../artifacts/5d1_native_binding_p12_v1/source_compatibility_ledger.json)
đối chiếu toàn bộ284files với P10:280existing files giữ byte,3files đổi do entry/
UI stop correction,1new test.8files trong P10 runtime qualification manifest còn
exact byte; selector/pilot/operational/timing/provider/executor/controller combat
và qualification fixture chưa đổi. Changed function AST và exact diff được lưu.

Điều đó chứng minh code các method đo cũ chưa đổi; không cấp chứng nhận timing
cho source284 hoặc source tương lai. Source toàn cục đã khác và historical audit
fixture chưa rewind entry/UI correction mới. P13 cần exact before/after layer cho
side fix, rồi layer riêng cho thay đổi P13, không generic allowlist hoặc sửa P10
manifests. P10 full2179 và entry102 tests giữ đúng source/scope lịch sử.

Sau implementation offline, freeze source rồi đo lại completed/timeout/error/
fallback và disabled trên cùng host. Mỗi path1000warmup+5000measured, giữ raw
samples. Giữ thresholds P10: p50≤1.5ms,p95≤3ms,p99≤9ms,max≤30ms; added mean CPU
so disabled≤1.5ms/three checkpoints. Full timing pipeline: p50≤0.5ms,p95≤1ms,
p99≤3ms,max≤10ms.1000Stop signals max<25ms và worker reaped;60s bounded stress,
max1record/history và peak<16MiB. Đây là scoped method/fake-data qualification,
không whole-app/VM/native soak. Nếu không đạt thì giữ failure, không đổi thresholds
hoặc lặp đến PASS mà không có correction có căn cứ.

P11 native data chỉ tái sử dụng nếu final source compatibility chứng minh native
H/I/read/input measurement path không đổi. Loader/exporter/setup-only changes
có thể được review; bất kỳ runtime dependency thay đổi ảnh hưởng native interval
thì ghi INCONCLUSIVE, không tự chuyển SHA hoặc tự chạy thêm game. Benchmark mới
phải pin final current source/host/raw output, không copy numbers hoặc sửa nhãn P10.

## 5. Return gate cho bước implementation

Một milestone **P13 offline**, file scope: grouped review/export path,
operational setup loader/schema branch, exact source-audit fixture và qualification
tool/tests. Giữ reader, solver/PlayStyle, combat controller, executor, ACK,
entry correction, screenshot/PNG policy và strict finite-U loader nguyên byte.
Không đổi deadline hoặc runtime exact witness match để qua gate.

Static review còn thấy `_prepare` khi mismatch xóa completed/invalidate runner
nhưng chưa xóa active; `_serve` chỉ signal skipped result nếu active=None hoặc
completed khácNone. P13 phải có negative case khi đã có old active job, chứng
minh unsupported witness không đợi cả budget. Chỉ sửa owner-side invalidation nếu
test tái hiện được; không thêm wait/read/capture và không đổi BASIC. Đây là static
risk, chưa là lỗi live đã quan sát. Requalification phải bao changed path nếu sửa.

Meaningful cases nằm trong [test plan](../artifacts/5d1_native_binding_p12_v1/implementation_case_plan.json):
raw integrity/classification/unknown/terminal/partial/authority/source/cap/expiry/
deadline/Stop/mismatch với active job. Disabled traces/read/capture/input sequences
phải giữ; current source binding và full regression cuối milestone integration,
scoped qualification trên freeze; không chạy native test để lấp review thiếu.

Exit P13: reviewed-data verifier đúng, old exports/errors giữ byte, source/host/
dependency compatibility đầy đủ, fresh allowance và return gates đạt. Có thể soạn
readiness package, nhưng vẫn không tạo accepted live activation hoặc bật UI
REASONING. Nếu thiếu data thì ghi rõ đúng thiếu sót trước khi đề nghị live mới.
Không cần thêm trận để giải quyết hai vấn đề đã xác định trong P12.

**P12 STOP tại proposal này. P13 chưa thực thi; chưa D1draft12/D2.**
