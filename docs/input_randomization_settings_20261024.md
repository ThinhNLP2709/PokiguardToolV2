# Tùy chỉnh random thao tác — 2026-10-24

Đã thêm **Cài đặt → Random đi bàn cờ** trong source. Cấu hình được lưu cùng
preferences, áp dụng cho phiên Bắt đầu/Tiếp tục kế tiếp và bị khóa khi farm chạy.
Không mở game, phát input thật, đổi version hoặc build ZIP trong thay đổi này.

## Cách dùng

| Mục | Mặc định | Giá trị cho phép |
| --- | --- | --- |
| Trước nước đi, Min/Max | 0–1 giây | 0–1 giây |
| Random thêm giữa hai click, Min/Max | 0–1,5 giây | 0–1,5 giây |
| Lệch tọa độ tối đa | 10% kích thước ô | 0–10% |

Nhập giá trị rồi bấm **Lưu random**. Dấu phẩy hoặc dấu chấm thập phân đều hợp lệ.
Với mỗi cặp thời gian, **Max = 0 tắt random của mục đó**, kể cả khi Min còn giá
trị cũ. Nếu Max khác 0 thì Min phải nhỏ hơn hoặc bằng Max. Min = Max cho thời
gian cố định. Số âm, NaN, vô cực và giá trị ngoài khoảng bị từ chối tại UI/CLI.

Tọa độ được lấy quanh tâm riêng của từng viên, lệch độc lập theo hai trục; phần
trăm tính theo kích thước ô đã ánh xạ, không tính theo cả cửa sổ. Đặt **0%** để
click tâm, hoặc **10%** để giữ đúng hành vi trước thay đổi.

Random giữa hai click là phần **cộng thêm** vào độ trễ cơ sở/adaptive pacing.
Max = 0 không bỏ thời gian cơ sở, cursor settle hay mouse hold. Với chế độ kéo,
không có hai click để cộng random; thời gian phản xạ và lệch tọa độ vẫn áp dụng.
Giới hạn chọn viên và dự phòng thời gian lượt vẫn có quyền rút ngắn thời gian
chờ, nên Min không ép tool chờ khi sắp hết lượt.

Giữ mức tối đa thời gian bằng khoảng cũ để không tăng thời gian input đã được
dự phòng trong Phase 5. Nước REASONING hợp lệ vẫn bỏ hai khoản random thời gian
như contract hiện tại; BASIC và fallback dùng cấu hình này. Tọa độ áp dụng cho
cả hai nhánh. Không thay đổi QTE, quyết định đi nước hay các thao tác thẻ/skill.

## Nối cấu hình và tương thích

- `InputRandomization` là cấu hình bất biến, nối từ DesktopConfig/preferences
  qua CLI FarmRunner đến executor. Cả executor thường và hai đường sao chép
  executor của chế độ ghim game đều giữ cùng cấu hình.
- Preferences cũ thiếu block `input_randomization` nhận đúng mặc định cũ. Nếu
  block này hỏng, chỉ random trở về mặc định và ghi cảnh báo
  `PREFERENCE_RANDOMIZATION_INVALID`; không bỏ các cài đặt gameplay hợp lệ.
- Log `input_randomization_saved`, `farm_run_started` và
  `auto_controller_started` ghi cấu hình sử dụng. Kết quả thao tác vẫn có log
  khoảng cách hai click thực tế và tọa độ theo cơ chế hiện có.
- Không thêm đọc memory/chụp ảnh/poll/input, không sửa policy, QTE, recovery,
  GameplayConfig hay checkpoint. Canonical decoder của request đo thời gian
  hiểu field mới, vẫn đòi đầy đủ cấu hình; request cũ thiếu field không tự được
  nâng cấp hoặc chứng nhận lại. Không đổi pin/source authority lịch sử.

## Kiểm chứng

Source cuối: **690/690 bài regression PASS** trong 38,034 giây, gồm 12 ca mới;
356 file Python parse AST thành công. So với source đầu, 344/354 file Python
cũ giữ nguyên, 10 file đổi và 2 file mới. Fingerprint:
`9dd81a8ec663eb7b6f58e0b6789c9d944fe7a7a8812f659bbbc89fa3151ec701`.

Xem [verification.json](artifacts/input_randomization_settings_20261024/verification.json)
và [source_manifest.json](artifacts/input_randomization_settings_20261024/source_manifest.json).
Các ca mới kiểm cấu hình, Max = 0, tọa độ theo kích thước ô, CLI, lưu/mở lại,
fallback preferences, canonical decoder, cả hai chế độ input và Tk ẩn. So sánh
seed cố định với executor/mapper trước sửa cho cùng tọa độ, wait, kết quả và
trạng thái RNG ở mặc định, kể cả khi có timer guard và khi reasoned.

Lần chạy regression đầu chọn nhầm module không tồn tại
`tests.test_game_window_size`: 689 ca thật qua, loader báo một lỗi. Log này được
giữ nguyên. Lần chạy lại đúng danh sách qua 689/689. Sau đó rà soát phát hiện
đường clone executor thuộc FarmRunner cần giữ cấu hình; đã sửa và thêm ca kiểm
riêng. Kết quả cuối được ghi trong verification, không dùng lần chạy trước để
chứng nhận source sau sửa.

Đây là kiểm chứng offline; chưa live test hoặc đóng gói bản có tính năng này.
ZIP v1.2.8 đã phát hành trước đó không tự có thay đổi source mới.
