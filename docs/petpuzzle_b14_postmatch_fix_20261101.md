# B14: dừng ở màn thắng — 01/11/2026

## Nguyên nhân đã chứng minh

Phiên `406907d5e0854925a7411f74101220d6`, attempt1, match`M_2ad798d0`,
Lieyun77 / Demon Aegis. Tool không dừng giữa trận vì lỗi pointer/build:

- Entry1click, opening64cells hợp lệ; swap đầu có exact MatchService
  local-sequence/last-move/opponent-turn ACK, không duplicate entry.
-21:47:21.884: terminal snapshot trước cleanup ghi WIN/STRONG, bossHP0,
  localHP79372; UI title đọc được `Thắng`.
-21:47:23.003–21:47:53.487: chờ xác nhận30.484giây,30 mẫu. Cả ba mẫu cuối
  `arenaPanelCandidates=0`, fallback `expected_exactly_one_orange_result_button`.
  `firstConfirmVisibleSeconds=null`, không có exception và không có click
  Đồng ý. Tool kết thúc `POSTMATCH_UI_AMBIGUOUS`.
- Ảnh đầu lưu đúng animation hộp quà chưa có nút; ảnh cuối đã có nút Đồng ý
  xanh. Vì vậy đây là **nhận diện hụt giao diện B14**, không phải thiếu thời
  gian chờ hoặc trận chưa hoàn thành.

Ảnh native mới có khung thưởng hẹp hơn/nền trong suốt, bốn góc vàng chuyển
vào trong. Trong ảnh cuối, component xanh lớn nhất rộng760/1280=0.59375,
lọt dưới min0.60 của layout cũ; các box góc vàng cũ cũng không khớp. Detector
cũ từ chối ngay khung trước khi kiểm nút xanh, rồi rơi xuống fallback cam.

## Bản sửa

Chỉ sửa `src/pokiguard_v2/postmatch_ui.py`: thêm variant màn thắng B14, giữ
nguyên điều kiện hình học của layout cũ. Variant mới bắt buộc cùng lúc:

1. Component khung xanh đúng phạm vi của ảnh B14 và bốn góc vàng riêng biệt.
2. Cả hai cánh băng của header thắng.
3. Duy nhất một nút xanh đúng hình/kích thước/vị trí giữa khung.
4. Nhãn chữ trắng đã hiện trên nút.

Điểm click lấy từ component nút quan sát được, không click tọa độ cố định.
`POSTMATCH` authority, ba frame ổn định, fresh preflight, foreground check,
one-shot input, timeout30s và luồng return/re-entry đều giữ nguyên. Không sửa
solver, random, memory offsets hoặc QTE. Nhánh thua cũ giữ nguyên; màn thua
B14 mới chưa có mẫu, không tuyên bố nghiệm thu thêm.

Ảnh native và hashes/provenance được giữ ở
`tests/fixtures/petpuzzle_b14_result_20261101/`.
`provenance.json.source_change` pin riêng before/after của file UI; không nhập
thay đổi này vào constant-only migration B14 hoặc rebind live acceptance cũ.

## Kiểm chứng và giới hạn

-25 test visual PASS: native victory/presentation, bốn profile2:1 được resample,
  mất từng góc/wing/panel/label, hai nút, stable-frame proof, old layouts/thua
  và real `_confirm_postmatch` với fake executor chờ animation rồi click1lần.
-56 test integration/regression PASS: dialog sức khỏe/thoát/phòng boss thật
  không bị coi là kết quả; exact B14 profile/source proof, legacy victory,
  terminal result và bootstrap/re-entry owner.
- Resample là offline regression từ một quan sát, không phải bốn live tests.
- Chưa gửi input trong lượt sửa này, chưa mở phiên mới, chưa build. B1 đã
  dùng1attempt và chưa PASS toàn vòng vì return chưa thực hiện. Cần user về
  phòng boss, sau đó mở phiên1BASIC kiểm lại confirm/return; không tự cộng
  thêm trận vào cap E1/Sagui hoặc tiếp tục checkpoint1/1 đã đóng.

Evidence local: `docs/artifacts/game_1_7_4_b14_result_20261101/` với source
before, `visual_tests.log`, `integration_tests.log`, `verification.json`.
Log gốc vẫn ở `logs/farm_runs/406907d5e0854925a7411f74101220d6/`.
