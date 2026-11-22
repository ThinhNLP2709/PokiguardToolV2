# Kiểm tương thích dữ liệu và thử tái sử dụng cho predictor — 21/11/2026

**Cập nhật 22/11:** bài native2 sau đây đã hoàn tất trên source505,2 WIN,
không safe stop;model V2 vẫn chưa thắng baseline trên cùng target. Tổng40
lượt đóng,còn0. [Kết quả mới](DAMAGE_REUSE_NATIVE_20261122.md). Phần chờ
phòng ở cuối báo cáo này là trạng thái lịch sử trước bài mới.

**Offline hoàn tất. Chưa chứng minh predictor tốt hơn baseline; chưa đưa vào gameplay.**
Source `f7ba1ec6ea6205d48747be220dd1442b585b83aecf912f3eb5ea827b013c91e0`,
505 Python. Toàn bộ 503 file của mốc V2 giữ nguyên byte; chỉ thêm
`tools/audit_damage_data_reuse.py` và `tests/test_damage_data_reuse.py`.
Không thay planner, input, rule PASS hoặc cơ chế dừng của tool.

## Những phần đã làm nốt

1. Tách danh tính pipeline trích xuất khỏi danh tính toàn source. Cache kiểm
   raw không cấp quyền dùng timing/profile cũ cho source mới.
2. Re-extract 14 dataset, 33 match, 289 action, 119 recorded component target.
   Cả 289 sample khớp toàn bộ features, target/execution, source/cohort,
   seen flags và provenance. Kiểm 58 source snapshot (25 danh tính khác nhau).
   Hash raw được kiểm trước/sau; không viết lại source/cohort để giả cùng nguồn.
3. Thêm 11 kiểm tra cho raw thay đổi, feature/label sai, source giả, action
   trùng và ranh giới quyền. Tổng 325 kiểm tra tập trung PASS.
4. Chạy qualification mới cho đúng source 505: 14/14 gate PASS.
   Đây là kiểm synthetic, chưa thay thế native. BASIC entrypoint tham chiếu
   lấy từ qualification 25a đã lưu, byte-equal hiện tại; tên lịch sử
   `v1_3_0_basic_auto_bot.py` không có nghĩa là file raw release 1.3.0.

[Audit](artifacts/damage_reuse_closeout_20261121/reuse_audit.json),
[kiểm lại](artifacts/damage_reuse_closeout_20261121/reuse_reverification.json),
[test](artifacts/damage_reuse_closeout_20261121/tests.txt),
[qualification](artifacts/damage_reuse_closeout_20261121/qualification/qualification.json).

## Kết quả nghiên cứu gộp theo context quan sát

Tất cả mẫu thuộc cùng game B17/account và cùng thông số số học đã ghi nhận.
Điều này **chưa chứng minh** loadout, buff, crit hoặc phân phối hiệu ứng tương
đương. Vì vậy gộp chỉ là giả thuyết trong namespace offline riêng. Giữ nguyên
metadata source/cohort của từng mẫu, không tạo whitelist runtime.

Đóng băng plan trước fit, giữ nguyên estimator baseline/V1/V2. Chỉ thay key
nhóm trong namespace riêng: build/account/settings/max HP/mana/nộ/attack.
Bài chính bỏ toàn bộ một source khỏi TRAIN (14 fold); bài phụ bỏ một match
(33 fold). 141 model đều bị validator production từ chối. 47 refit chỉ để
kiểm rò rỉ: poison label VALIDATION và post-response fields không đổi 1.156
forecast V2. Đây vẫn là dữ liệu đã xem, không phải independent holdout.

| Bài chính: bỏ một source | Reference: target /119 | MAE trên mẫu của riêng model | Guarded: target /119 |
|---|---:|---:|---:|
| Baseline | 105 | 13.758,24 | 99 |
| Conditional V1 | 108 | 16.460,63 | 90 |
| Raw component V2 | 93 | 18.317,65 | 54 |

MAE riêng từng model có tập mẫu khác nhau. So đúng **93 target chung** của
V2/baseline: baseline MAE **14.953,73**, V2 **18.317,65**; V2 tốt hơn 5,
kém hơn 9, hòa 79, mất 12 target baseline chấm được. Với V1 trên 93 chung:
V1 18.519,32 so V2 18.317,65; tốt 10/kém 10/hòa 73, mất 15 target. Bài bỏ
match cũng chưa thắng baseline: trên 94 chung, 14.930,10 so 18.380,19.

Độ phủ V2 tăng từ 14 lên 93 target nhờ giả thuyết transfer. Kết quả chưa
ủng hộ đưa V2 vào quyết định nước đi, và không dùng mức tăng coverage để
claim suy luận thông minh hơn. Giữ mọi model ở mức đối chiếu offline;
abstention của predictor không được trở thành SAFE_STOP của gameplay.

[Plan đã đóng](artifacts/damage_reuse_closeout_20261121/transfer/plan_frozen.json),
[kết quả hai bài](artifacts/damage_reuse_closeout_20261121/transfer/summary.json),
[audit chốt](artifacts/damage_reuse_closeout_20261121/audit.json).

## Phần còn lại cần game

Đã khóa cả ba model trên 289 action/33 trận cũ **trước** bất kỳ TEST mới nào.
Adapter file-only chỉ bỏ điều kiện bắt buộc phải có VALIDATION hồi cứu khi
fit toàn bộ TRAIN; mọi phép fit và guard TRAIN rỗng giữ nguyên. Khôi phục
biểu thức cho AST gốc khớp hoàn toàn; regression trên split cũ giống hệt.
Ba artifact riêng tiếp tục bị validator production từ chối, không import
vào gameplay, không chọn model sau khi nhìn TEST.

[Freeze mới](artifacts/damage_reuse_native_20261121/frozen_models/freeze_manifest.json),
[adapter review](artifacts/damage_reuse_native_20261121/frozen_models/adapter_review.json),
[intent](artifacts/damage_reuse_native_20261121/intent.json).

Bài tiếp theo giới hạn **2 lượt thử mới: 1 BASIC + 1 REASONING** trên cùng
cấu hình Priest/Demon Aegis thường ăn Khiên, ngưỡng 4 Kiếm hiệu dụng.
Chỉ existing gameplay điều khiển trận; predictor khóa trước thu chỉ được
chấm offline từ pre-input request. Sau BASIC mới tạo timing/profile R cho
đúng source. Không mở lại 38 lượt cũ, không rebind profile/timing cũ, không
chơi thêm để săn crit hoặc event dài. Nếu không gặp >128 ops thì native
nhánh omission vẫn chưa có positive witness dù kiểm synthetic đã đạt.

Quan sát gần nhất: game B17 PID32112 còn mở nhưng phòng không clean/không
host, room ID null; chưa chuẩn bị request/profile/GUI mới hoặc gửi input.
Đã yêu cầu user vào lại phòng. Computer-use trước đó lỗi khởi tạo kernel
assets `OS error 3` sau retry; cần user bấm Start tool nếu lỗi còn tồn tại.
Hiện mới đóng offline: **0 trận mới, 0 input mới, tổng 38 lượt cũ đã đóng**.

Các review script, baseline, test và qualification được archive cùng
artifact. Không build, bump version, commit hoặc sửa game.
