# G4 — mục tiêu theo cấu hình tiến hóa, 23/11/2026

User làm rõ G4 không bắt buộc ăn Kiếm như BASIC: không tiến hóa thì tập trung
combo để kích hoạt nội tại; có route tiến hóa thì lấy lợi thế tiến hóa sớm,
sau đó mới tối ưu skill. Đợt này sửa offline, không mở game/tool hoặc thêm trận.

Đã thấy hai điểm chưa phù hợp trong source22/11: fallback vẫn đặt Kiếm trước
combo và chặn setup khi có nước Kiếm; route G4 chính →pet thường vẫn ưu tiên
combo skill trong lúc chưa tích đủ Mana tiến hóa. Route pet thường →G4 chỉ
ưu tiên Mana sau nhánh Kiếm, nên cũng chưa thực sự đặt tiến hóa làm mục tiêu.

## Hành vi hiện tại

| Cấu hình/trạng thái | Mục tiêu và hành động |
|---|---|
| Không tiến hóa | Combo nội tại9–13, cộng x1…x7 và cascade. Chưa đủ mốc thì chọn combo hiện tại hoặc setup phù hợp; Kiếm là một ứng viên, không là ưu tiên bắt buộc. |
| G4 chính →pet thường, chưa thành công | Ưu tiên Mana cho tiến hóa. Nội tại G4 vẫn có thật và có thể tự kích hoạt từ nước Mana; không ưu tiên một combo skill riêng để trì hoãn tiến hóa. |
| Pet thường →G4, chưa thành công | Ưu tiên Mana cho tiến hóa; không tính damage/hút máu/mốc kích hoạt của G4 trước khi game xác nhận thành công. |
| Route có tiến hóa, đã thành công | Đọc state mới và chuyển mục tiêu sang combo nội tại, kể cả khi vẫn trong cùng lượt. |

Mỗi nhánh đều lọc nhóm nước có phản hồi Kiếm hiệu dụng nhỏ nhất trên phần bàn
đã biết. Có nước chừa0 thì không lấy nước chừa nhiều hơn chỉ để có thêm Mana
hoặc combo. Nếu tất cả đều chừa Kiếm, vẫn chọn mức thấp nhất và tiếp tục đánh.
Đây không là cam kết về viên server refill hoặc boss dùng skill.

Khi đang tích Mana, xét hệ số Mana lấy được; cùng mức tiến triển ưu tiên lợi
ích Máu/Khiên và rủi ro còn lại. Không suy chính xác một viên cho bao nhiêu
Mana hoặc một nước sẽ đủ chi phí; không coi Hút là chắc chắn lấy được Mana,
vì resource được hút và lượng chuyển vẫn chưa có công thức được xác minh.
Không chạy setup combo skill trong giai đoạn đang chuẩn bị tiến hóa.

Step1 tiến hóa cũ vẫn kiểm pet đã chọn, chi phí thực đọc từ game, slot/UI,
Mana, khả năng tương tác và timer. Đủ điều kiện thì đề xuất EVOLVE trước mọi
combo. Thành công bắt buộc đọc lại state. Nếu Mana đã đủ nhưng card chưa dùng
được, tool vẫn đánh/bảo vệ và thử lại từ state mới; không tiếp tục đặt mục
tiêu tích thêm Mana. Nếu Mana đầy mà chi phí chưa rõ, không bịa trạng thái
“đủ tiến hóa” hoặc liên tục ưu tiên Mana. Cần chọn đúng pet tiến hóa trong game.

Suy luận giữ các lựa chọn hồi máu, cơ hội hút máu và setup có giới hạn khi mục
tiêu đã là combo. Setup được phép thay một nước Kiếm nhỏ nếu có cơ hội combo
tốt hơn mà không tăng phản hồi Kiếm đã biết; không đoán refill, kill hoặc sống
sót chắc chắn. Không đổi chốt lượt/timer, luật PASS, input, ACK hay memory reader.

Trace ghi `goal`, `phase`, `evolution_pending`, `evolution_missing_mana`, trạng
thái chi phí/capacity và Mana gem hiệu dụng của nước đi. Thiếu cost hoặc balance
giữ UNKNOWN, không có chi phí cố định mới trong runtime. Điều kiện nội tại
vẫn mặc định/ẩn; không thêm lựa chọn vào tab AI.

## Kiểm tra

- **39 test G4 PASS**, gồm8 test mục tiêu mới: combo5 thay Kiếm3 dưới mốc,
  Mana ưu tiên trước combo skill ở cả hai route/mode dù HP thấp, đủ Mana
  EVOLVE trước rồi đọc lại/chuyển mục tiêu, tôn trọng Không tiến hóa dù runtime
  có thẻ Fusion, card chưa dùng được, thiếu cost, đầy Mana và giữ guard Kiếm.
- Ví dụ bàn native cũ ở lượt17 với trạng thái kiểm soát thiếu Mana: có combo12
  lấy4 Mana nhưng route chờ tiến hóa chọn nước lấy5 Mana. Không tiến hóa hoặc
  sau thành công thì chọn combo nội tại. Đây là kiểm offline, không là dữ liệu
  tiến hóa thật của trận đã chơi.
- **414 test CI offline PASS**, 243 tình huống style cũ giữ nguyên decision/trace
  ngoài trường chẩn đoán mới `g4_combo=None` đã loại khi đối chiếu.
- 11 bàn trước nước đi ×3 trạng thái route ×2 mode =66 replay. Chi phí200
  trong replay là giá trị kiểm soát, không là cost lấy từ game hoặc cấu hình
  cố định của G4. Cả66 trường hợp giữ0 phản hồi Kiếm đã biết. Không suy14 lần
  đổi nước thành14 lần cải thiện hoặc kết quả thắng counterfactual.

Source mới chưa live; không build, tăng version, commit/push, rebind profile
hoặc mở lại cap đã đóng. Không áp dụng thay đổi này sang Mega/Galaxy chủ động.

[Replay theo route](artifacts/g4_route_goals_20261123/replay.json),
[source và kiểm chứng](artifacts/g4_route_goals_20261123/verification.json).
