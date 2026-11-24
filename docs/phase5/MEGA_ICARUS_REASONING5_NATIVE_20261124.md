# Mega Icarus — chốt 5 trận Suy luận ngày 24/11/2026

## Kết quả và phạm vi

Phiên `d3f2130b1a6d4d86aabdfc42bb401948` đã kết thúc đúng cap 5/5,
`FARM_TARGET_COMPLETED`, về BOSS_LOBBY. Source giữ nguyên
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.
Phạm vi là Solo No.11 lv185, pet thường → Mega Icarus, đủ điều kiện skill,
Tự bảo vệ dưới 30%, foreground/two-click 1280×640.

| Chỉ số | Kết quả |
|---|---:|
| Lượt thử / hoàn thành / WIN | 5 / 5 / 5 |
| SWAP gửi / ACK | 115 / 115 |
| Skill Icarus | 14 |
| Tiến hóa thành công / thất bại | 5 / 25 |
| PASS / PASS thứ ba sai luật | 5 / 0 |
| Technical abort / recovery | 0 / 0 |
| Worker hoàn tất / thu hồi | 5 / 5 |
| Bản ghi writer / mất | 750 / 0 |

Đây là nghiệm thu kỹ thuật và bằng chứng quyết định có phạm vi. Không coi
5 WIN hoặc ít lượt hơn là chứng minh tối ưu chiến thuật. Không mở rộng
nghiệm thu sang T-Rex, Galaxy hoặc route Mega chính → pet thường.

Bốn trận BASIC fallback trước và một trận BASIC đo timing được giữ riêng,
không đổi nhãn thành Suy luận. Profile mới có 14 mẫu native; regression
617 kiểm tra và qualification 14 gate đã đạt trước khi mở phiên này.

## So BASIC với nước thực sự gửi trên cùng bàn

Ghép được **88 nước** từ snapshot và quyết định native, đủ ROOT/FRESH/FINAL,
action thực gửi và ACK: **60 nước đổi so với BASIC, 28 nước giữ nguyên**.
27 SWAP còn lại được tách thành BASIC fallback, không đưa vào bộ so R.
Không chạy lại planner rồi gán đề xuất mới thành quyết định đã live.

Cả 60 nước đổi đều được phân loại **TRADEOFF**: có lợi ích và chi phí,
không tự sinh nhãn nước tốt nhất hoặc nhãn huấn luyện. Trong số đó:

- 20 nước giảm lượng Kiếm hiệu dụng tối đa boss có thể ăn từ phần bàn đã
  biết; không nước nào tăng chỉ số này. Điều này chưa bảo đảm sau refill.
- 2 nước lấy thêm Mana, 11 nước lấy thêm Nộ; các nhóm có thể trùng nhau.
- Ví dụ `M_9c305403` lượt 37: BASIC ăn 3 Hút; R thực gửi ăn 9 Kiếm hiệu
  dụng + 3 Khiên, giảm cơ hội Kiếm đã biết của boss từ 9 xuống 0. Đánh đổi
  là mất phần Hút; chưa đủ chứng minh sát thương kết liễu hoặc sống sót.
- Cùng trận lượt 27: BASIC ăn 4 Mana hiệu dụng; R ăn 5 Kiếm, giảm cơ hội
  Kiếm đã biết từ 8 xuống 0 và đánh đổi Mana.

112 quyết định worker không đồng nghĩa 112 SWAP thực được dùng. Trong đó
91 ghi `COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1`: dùng đánh giá R1 đã
hoàn tất, không coi tương lai chưa hoàn tất là đã tính được. Quyền quyết
định skill, tiến hóa và PASS vẫn thuộc luồng hiện có; chưa nghiệm thu một
bộ tối ưu thời điểm dùng/giữ skill mới.

## 27 fallback do thời gian đọc

Cả 27 SWAP BASIC fallback có read span vượt gate 100 ms, trong khoảng
100.9658–172.4372 ms. Tất cả đều gửi và có ACK; không phải bỏ lượt hoặc
safe stop. Giữ gate hiện tại, không nới để làm đẹp tỷ lệ dùng Suy luận.
Khoảng đo này chưa đủ quy nguyên nhân gốc cho game, UI hay reader.

## Skill và giới hạn kết luận

Đã chuyển 14 context trước skill thành CommonProblem và 14 phản hồi thành
receipt hồi cứu. Có 9 liên hệ client-card có điều kiện và 5 terminal
UNBOUND; **0 liên kết card ID trực tiếp từ wire** vì phản hồi không chứa
card ID. 14 vùng DESTROY đầu khớp registry ấn Icarus 30 ô, nhưng không nâng
5 phản hồi UNBOUND thành liên kết thẻ chắc chắn chỉ nhờ geometry.

Ledger ghi 123 phép số học raw khớp và 21 mẫu cap quan sát được. Nhãn hồi
máu có nguồn `FUSION_LIFESTEAL` ở cả 14 phản hồi; không chuyển thành giả
định hồi máu nội tại của mọi Mega hoặc T-Rex. Không fit mô hình damage/heal.

## Bằng chứng đã lưu và kiểm

- [Closure](artifacts/mega_restart_timing_20261124_165628/reasoning/review/closure.json).
- [88 cặp cùng bàn và 27 fallback](artifacts/mega_restart_timing_20261124_165628/reasoning/review/same_board_native_cases.json).
- [14 skill receipts](artifacts/mega_restart_timing_20261124_165628/reasoning/review/native_skill_receipts.json).
- [Verification](artifacts/mega_restart_timing_20261124_165628/reasoning/review/verification.json): 24 file raw kiểm hash, source không đổi, 13 fixture chiếu lại khớp.
- [Fixture gọn](../../tests/fixtures/mega_native_reasoning5_20261124/cases.json): 13 case chọn có tiêu chí và hai ví dụ fallback; không phải holdout độc lập hoặc nhãn chất lượng.
- [Đường đo timing và các phiên BASIC riêng](MEGA_SWAP_TIMING_RESTART_20261124.md).

## Bước tiếp theo

Không cần lặp Icarus/No.11 chỉ để tăng số lượng. Ưu tiên **tối đa một trận
T-Rex Suy luận có mục tiêu**, giữ route pet thường → Mega nếu có thể để
giảm số biến thay đổi. Trước Start kiểm đúng thẻ, mask, chi phí, cấu hình,
profile và source/game/host/transport; chỉ tái dùng profile SWAP khi loader
xác minh còn hợp lệ, không cấp profile đó cho timing skill.

Mục tiêu là xác minh collector T-Rex hiện hành và ghép quyết định trước
skill, phản hồi, trạng thái sau skill; không áp heal Icarus cho T-Rex.
Nếu gate hoặc điều kiện thu thiếu, ghi đúng phần thiếu rồi chuẩn bị bài
hẹp tương ứng, không mặc định bắt chạy thêm BASIC hay tăng cap.

Sau T-Rex chuyển Galaxy G1/G2/G3 theo account user có; G2 thuận tiện kiểm
collector trước vì không có chuỗi pha. G4 đã chốt riêng. Đợt closeout này
không mở thêm live, sửa gameplay, commit, push hoặc build.
