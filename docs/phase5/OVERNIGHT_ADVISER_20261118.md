# Mốc tiếp tục adviser — 18/11/2026

**Mốc live mới nhất:** đã tự mở tool kiểm source9b4a2109… bằng cap mới
3 BASIC +3 REASONING,6 WIN/confirm/return.21 quyết định R hợp lệ,15 override
gửi đúng (12ACK +3 terminal),2 ca bounded-unknown thực sự chạy. Cap6 đã đóng,
game ở lobby, tool hoàn tất; chưa build hoặc nghiệm thu ZIP/mọi lối chơi.
[Kết quả và giới hạn](BOUNDED_FUTURE_NATIVE_20261118.md).

**Mốc source mới nhất:** sau live đã tiếp tục offline, giữ so sánh nhìn trước
khi một số nhánh thiếu model bằng khoảng bảo thủ.584 ca hợp lệ,1 Mega đổi,
coverage559→571;137/140 test PASS,3 lỗi legacy được tái hiện với planner cũ.
Source9b4a2109… chưa có native/profile mới; cap live trước đã đóng.
[Báo cáo cập nhật](ADVISER_BOUNDED_FUTURE_20261118.md).

**Cập nhật sau khi user mở game và giao tự kiểm:** đã chạy đủ cap mới
3 BASIC + 3 REASONING,6 WIN/confirm/return,11 đề xuất đổi nước có ACK.
Không lỗi kỹ thuật hoặc mất log; game ở lobby, tool đã hoàn tất. Mốc cần
native phía cuối tài liệu là trạng thái lịch sử trước phiên mới này.
[Kết quả và phạm vi đã đóng](ADVISER_NATIVE_20261118.md).

User giao tiếp tục tự quyết định offline khi game tắt; dừng khi cần kiểm thật,
thông tin từ user hoặc hết khả năng kiểm chứng. Không có quyền đọc hạn mức
5 giờ của tài khoản qua tool hiện có. Không khởi động game/farm hoặc build.

## Đã hoàn tất

- Chuẩn hóa hai trận BASIC vừa thu, có2 quan sát không terminal và1 mẫu
  terminal bị censor.85 test PASS trước thay đổi adviser tiếp theo.
  [Kết quả](COMBAT_NORMALIZATION_20261118.md).
- Kiểm2.736 root từ205 snapshot đã lưu:10 root có một phản hồi ít Kiếm
  nhưng risk proxy lớn hơn do tài nguyên/HP. Thêm khoảng T từ tham chiếu
  Sword-first đến trường hợp xấu nhất của các phản hồi đã biết; không gộp
  hiệu ứng nhiều nước thành một nước boss giả.
- Replay trước/sau205 ca:0 đổi lựa chọn,205 lựa chọn hợp lệ;187 hoàn tất
  nhìn trước và18 dùng một bước ở cả hai phía. Đây là tăng coverage rủi ro,
  không phải bằng chứng thắng nhiều hơn. Không tune trọng số.
- Test bước đầu:27 test common/setup/assistant và32 test strategy/risk PASS.

## Đã chốt cuối phiên offline

- Bổ sung361 swap có ACK từ8 combat còn gốc:334 Mega sau tiến hóa có loại ấn
  hiện tại,27 Galaxy. Cộng với205 ca cũ:566 lựa chọn đều hợp lệ,0 đổi nước,
 543 hoàn tất nhìn trước/23 một bước trước và sau. Chưa chứng minh win tăng.
- Thêm ghi chính xác problem adviser ở owner nền qua buffer/writer đã có.
  Lỗi record riêng không disable AI; test worker/host thật hoàn tất và dọn
  được process khi sink snapshot ném lỗi. Không thêm reads hoặc input.
- 154/154 kiểm tra cuối PASS, gồm control lịch sử đã sửa phép projection.
  Chỉ nhận migration của đúng file SHA de85959… và default30% để giữ hành vi
  cũ; các sửa đổi khác vẫn reject. Runtime decoder/proof/cap không đổi.
- Lưu patch, baseline và SHA; nén dữ liệu lớn còn khoảng0,63MB cho ba file
  evidence chính thay vì28,5MB. Thử lại reader/replayer từ archive bằng
  smoke3 ca có nhãn sample_limited, không cộng vào số566.

[Báo cáo đầy đủ và receipt](ADVISER_REPLY_RISK_20261118.md).

Scratch tại `temp/reasoning/adviser_reply_risk_20261118/`, gồm baseline source,
manifest, probe2.736 root và paired replay. Bằng chứng cần giữ đã nằm tại
`docs/phase5/artifacts/adviser_reply_risk_20261118/`.

## Bước tiếp theo cần game/dữ liệu mới

Đã review tương thích legacy mega_self_protection, không cấp authority mới.
Tiếp theo kiểm native source mới bằng cap mới do user chuẩn bị; hai cap1 BASIC trước đã hết. Thu đòn chưa
kết trận và skill có ACK/context đầy đủ; không đặt hằng số damage từ2 điểm.
Game đang được user tắt nên phiên này dừng ở checkpoint offline, không giả
kết quả nghiệm thu native hoặc tự sửa trọng số chỉ để tạo nước khác.
