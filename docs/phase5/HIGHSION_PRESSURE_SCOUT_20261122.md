# Highsion165: computer-use khôi phục, đóng pilot tại BASIC1 — 22/11/2026

**Đã tự mở tool và bấm Start bằng computer-use. BASIC WIN1/1, nhận thưởng
về đúng phòng; 0 safe stop/recovery/abort. Không chạy thêm R chỉ để đủ số.**

Sau khi user mở lại ChatGPT Desktop, `@oai/sky` khởi tạo và truy cập cửa sổ
Pet Puzzle thành công. User đã chọn boss mới và cho phép dùng. Đã đối chiếu
ảnh phòng Highsion level165, tool/provider cũng đọc đúng ID1651/level165.
Phòng `Coop_389316`, Demon Aegis thường560 ăn Khiên, tham chiếu4 Kiếm hiệu
dụng, không tiến hóa. Room raw level0 giữ riêng; không đổi thành level165.
Các cài đặt và pet hiện tại được giữ nguyên, không đổi đồ/acc.

Source `1d8349dcb4c6d405b9d56ca8dcf87066cdbf2cfde5af79cd454a481ff23514cb`,
508 Python nguyên byte từ qualification trước tới lúc đóng scout. Đây là
native BASIC có phạm vi trên source508, chưa là native Suy luận/UI-status
acceptance vì phiên này AI tắt. Không nạp predictor damage hoặc build.

## Bài chạy và kết quả

Intent mới tối đa2 lượt: BASIC1 thăm dò, R1 chỉ mở nếu có pressure witness
đã định và timing hợp lệ. 40 lượt cũ vẫn đóng. CLI chỉ mở GUI, không auto
Start; agent quan sát đúng nút và gửi một click Start qua sky. FarmRunner
gửi input game thông thường. Không có click gameplay trực tiếp bằng sky.

| Mục | Quan sát |
|---|---:|
| Match | `M_acf5df66` |
| Thời gian trận | 187,183 giây |
| Lượt ta / boss | 12 /12 |
| SWAP gửi / ACK | 12 /11 |
| SWAP cuối loại do kết trận | 1 |
| Timing BASIC hợp lệ | 11 |
| HP tối đa boss | 1.067.059 |
| HP ta thấp nhất trước nước | 42.946 /109.491 = **39,22%** |
| HP ta ở terminal | 53.860 /109.491 |
| PASS / safe stop / recovery | 0 /0 /0 |

Trận mới có boss HP cao hơn Priest, nhưng không có frame ta dưới30% HP
kèm các nước có tradeoff khác nhau. Không có candidate thiếu Nộ kèm áp
lực HP đủ rõ. Không dùng thiếu Mana/Nộ ở opening hoặc sự kiện Hút mơ hồ
để mở rộng điều kiện thăm dò sau khi thấy kết quả.

**Quyết định: đóng pilot tại1.** R1 chưa được mở, không tạo profile R,
không đổi boss khác hoặc dùng lượt dự phòng để chơi tiếp. Cap tối đa2,
đã dùng1, đóng1 lượt có điều kiện chưa dùng; còn0 lượt đang mở. Tổng ledger
**41 lượt đã đóng**. Đây là quyết định dừng thu dữ liệu, không phải tool
tự dừng giữa trận hoặc lỗi gameplay.

## Dữ liệu mới có ích

- 12 pre-input sample mới, 11 ACK/1 terminal unACK;6 recorded DAMAGE
  component,5 không ghi DAMAGE,0 thiếu typed cho ACK. Giữ scope Highsion
  riêng, không pool hệ số từ Priest hoặc gọi component là toàn damage.
- 24 typed response normalize đủ24;24 response context,11/11 ACK có typed.
  127 operation (105 STAT_CHANGE/22 BOSS_HP),crit đều ABSENT,không suy false.
- Payload kết hợp max8.928/32.768 byte. Boss interval:10 có published
  before/after đủ điều kiện;2 khoảng còn thiếu biên hoặc không đúng một
  boss SWAP được giữ riêng,không giả dữ liệu.
- Source508 đã chạy BASIC đúng input/timing/capture và về phòng. Điều này
  không chứng minh Suy luận thắng hơn,không nghiệm thu mô hình damage hoặc
  nhánh UI chờ timer trong R. Không train/refit hoặc đổi scorer theo kết quả.

[Intent](artifacts/highsion_pressure_native_20261122/intent.json),
[closure](artifacts/highsion_pressure_native_20261122/closure.json),
[pressure review](artifacts/highsion_pressure_native_20261122/pressure_review.json),
[capture coverage](artifacts/highsion_pressure_native_20261122/capture_coverage.json),
[CU đã hoạt động](artifacts/highsion_pressure_native_20261122/computer_use_restored.json).

Tool đã được quan sát STOPPED1/1 ở đúng lobby. Nút Start bị khóa sau khi
request thăm dò một lượt đã dùng xong; dòng cấu hình/checkpoint không hợp
lệ sau completion không phải stop reason của trận (run là
FARM_TARGET_COMPLETED). Không tiếp tục bằng cách reset request/cap cũ.

Mốc này hoàn tất. Nếu thu tiếp về sinh tồn cần boss tạo áp lực thực tế cao
hơn,thay vì chỉ nhiều HP hơn hoặc cấp cao hơn. Không tự thêm phiên trên
Highsion sau scout này; giữ bài đánh giá cùng bàn và điều kiện thu rõ ràng.
