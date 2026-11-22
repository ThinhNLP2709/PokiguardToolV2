# Kiểm native source 505 và TEST model đã khóa — 22/11/2026

**Đã đóng đúng 2/2 lượt: 1 BASIC + 1 Suy luận, cả hai WIN/nhận thưởng/về phòng.**
0 safe stop, 0 technical recovery/abort. Source
`f7ba1ec6ea6205d48747be220dd1442b585b83aecf912f3eb5ea827b013c91e0`, toàn bộ
505 Python giữ nguyên so với freeze/qualification. 38 lượt cũ vẫn đóng;
tổng dữ liệu live hiện **40 lượt, không còn lượt mở**.

Game B17, phòng `Coop_353375`, pet 560 Demon Aegis thường ăn Khiên, ngưỡng
4 Kiếm hiệu dụng, boss 1845 Priest. UI đọc Priest lv131; trường level raw
của room vẫn 0, không nâng 0 thành bằng chứng level native. User xác nhận
giữ cấu hình. Full loadout tại thời điểm hiệu ứng vẫn chưa có chứng nhận.
User bấm Start hai lần trong tool vì computer-use có lỗi kernel OS error3;
FarmRunner gửi input thông thường, không có input trực tiếp bằng helper.

## Luồng chạy và bằng chứng suy luận

| Phiên | Match | Kết quả | Swap gửi | Timing/decision |
|---|---|---|---:|---|
| BASIC | `M_2073626b` | WIN, về phòng | 12 | 11 timing hợp lệ |
| Suy luận | `M_3dd29044` | WIN, về phòng | 10 | 11 decision, gồm 1 PASS |

11 timing BASIC tạo profile R mới max1, đúng source 505, không dùng lại
profile cũ. Reasoning worker 1/1 được reap; log đóng/flushed, 66 event đủ,
0 dropped/failed write. 11/11 decision khớp action thực thi và replay;
32/32 receipt ROOT/FRESH/FINAL hợp lệ (PASS dùng ROOT/FINAL).
PASS được game xác nhận qua MATCH_AFK_WARN; không input trong lúc chờ,
third pass 0. Rule bỏ lượt vẫn do game quyết định.

7 action khác BASIC **trên cùng trạng thái trước nước**: 1 lợi thế cơ học
có điều kiện, 3 TRADEOFF, 3 INSUFFICIENT_DATA. Không coi 10 so 12 swap hoặc
hai lần thắng là bằng chứng suy luận tốt hơn; những lớp so sánh này cũng
không xác nhận counterfactual outcome sau refill.

[Đóng bài và input accounting](artifacts/damage_reuse_native_20261121/closure.json),
[decision/replay](artifacts/damage_reuse_native_20261121/reasoning/same_state_comparisons.json).

## Logger và các giới hạn còn thấy

39 typed response normalize đủ 39, 0 mất tại normalization. 20 swap ACK,
17 có typed response liên kết; 3 gap không được lấp bằng suy đoán:

- BASIC turn1/sequence4: immutable JSON đã đọc, projection UNAVAILABLE với
  `COMBAT_STEPS_ABSENT`, không lỗi đọc JSON. Không còn raw JSON để dựng lại
  một typed combatSteps không tồn tại trong projection.
- R turn5/sequence12 và turn11/sequence25: không scoped observation; chưa
  đủ bằng chứng để kết luận callback không đến hay reader bỏ lỡ.

190 operation: 177 STAT_CHANGE/13 BOSS_HP. 189 crit ABSENT và 1 BOOL true
(R sequence4), giữ nguyên wire flag, không coi ABSENT=false hoặc suy crit
cho từng bước. Payload kết hợp tối đa 9.904/32.768 byte. Không gặp event
>128 ops: sửa long-event đã qua synthetic và source mới qua native luồng
chung, nhưng **nhánh omission chưa có positive witness native**.

UI đã phát `UI_REASONING_COHORT_CHANGED` ở 51 snapshot của R. Chưa chứng
minh tài khoản/đồ thay đổi. Hàm matches còn kiểm timer source nên nhãn UI
không đủ xác định nguyên nhân; ghi nhận riêng để rà lý do hiển thị. Đây
không phải combat safe stop: mọi 11 decision/32 receipt thực thi đều qua
kiểm nguồn. Không sửa runtime giữa bài hoặc nới gate theo thông báo này.

[Coverage và caveat](artifacts/damage_reuse_native_20261121/capture_coverage.json),
[target/crit wire](artifacts/damage_reuse_native_20261121/new_target_review.json).

## Kết quả model khóa trước TEST

Cả baseline/V1/V2 được freeze từ 33 trận/289 action cũ trước hai trận mới.
Giữ nguyên model, policy và namespace offline riêng; không import vào
gameplay. 22 swap mới: 20 ACK/2 terminal unACK, 7 recorded component target.
Train/Test match và pre-input board không trùng. Forecast tạo sau trận từ
pre-input request, seal trước scorer; 132 forecast giữ nguyên khi poison
post labels/flags. Không refit, tuning hoặc claim forecast prospective.

| Model | Reference: target /7 | MAE trên tập riêng | Guarded: target /7 |
|---|---:|---:|---:|
| Baseline | 7 | 2.383,10 | 6 |
| V1 | 7 | 2.383,21 | 5 |
| V2 | 6 | 127,67 | 3 |

**So cùng target:** V2/baseline hòa cả 6 reference, cùng MAE127,67; V2 bỏ
thêm 1 target có observed47.749 mà baseline dự báo31.833,33. Không được
lấy MAE riêng127,67 so2.383,10 để claim V2 tốt hơn. Guarded V2/baseline
hòa cả 3 chung (MAE0), V2 bỏ thêm 3 target. V1 reference: 6 hòa/1 kém hơn
baseline một lượng nhỏ; guarded 5 chung hòa. Model mới chưa chứng minh
gain, tiếp tục chỉ dùng đối chiếu offline, không điều khiển gameplay.

[Evaluation và các cặp cùng mẫu](artifacts/damage_reuse_native_20261121/test_evaluation/summary.json),
[seal trước scorer](artifacts/damage_reuse_native_20261121/test_evaluation/before_scoring.json).

## Bàn giao

Mốc kiểm source 505 và TEST2 đã hoàn tất; không cần thêm trận để đóng mốc.
1.624 pin lịch sử được kiểm nguyên, ordinary preferences không đổi, cap và
profile cũ không mở lại. GUI R PID27604 còn mở nhưng đã STOPPED 1/1 đúng
phòng. Không build/version/commit hoặc sửa game.

Việc offline kế tiếp: phân biệt lý do cảnh báo UI; dùng coverage/target mới
để thiết kế mô hình uncertainty tiếp theo trước khi thử thêm, không tuning
trên 7 target TEST này. Heal/skill và Mega/Galaxy chưa được nghiệm thu bởi
bài Demon này. Giữ thứ tự Demon trước, Mega/Galaxy sau như yêu cầu.
