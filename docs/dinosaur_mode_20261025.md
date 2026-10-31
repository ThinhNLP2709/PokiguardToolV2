# Lối chơi Khủng long — 25/10/2026

Rule hiện tại26/10: mọi lượt chưa gửi nước mà hết giờ đều chờ lượt mới; WIN
mạnh đúng phiên thì dừng ngay, không đợi kết trận/màn thưởng. Không còn giới
hạn chờ35giây hoặc200input riêng cho Dinosaur.
[Rule người dùng và529test liên quan](dinosaur_rule_20261026.md) thay các giới
hạn mở đầu trong mô tả triển khai cũ bên dưới.

Update26/10: đã nhận log live từ người dùng khác và sửa lỗi native board bị
quên giữa hai poll. [Nguyên nhân, sửa đổi và397test liên quan](dinosaur_native_board_fix_20261026.md).
Phần dưới ghi trạng thái tại lúc triển khai25/10, không thay thế bằng chứng
live mới hoặc tuyên bố đã retest sau sửa.

Đã thêm chế độ `dinosaur`, nhãn **Khủng long**. Dùng chung `BasicPolicyEngine`
với Đơn giản; không sao chép rồi duy trì một solver riêng. Khác biệt nằm ở
khởi động trong trận và cách xử lý lượt mở đầu bị lỡ. Chưa live test Khủng long,
đã được đưa vào bản1.2.9 theo yêu cầu gửi người dùng live test. Không đóng,
mở lại hoặc Start phiên soak200 đang chạy.

## Cách dùng và phạm vi

1. Sau khi phiên farm hiện tại kết thúc, mở phiên tool mới để nạp code mới.
2. Chọn **Khủng long**, cấu hình pet/thẻ như Đơn giản và lưu.
3. Người dùng tự vào trận. Khi tool nhận `ACTIVE_COMBAT`, bấm Bắt đầu trong tool.
4. Tool đọc bàn hiện tại, kiểm chứng và đánh ngay khi điều kiện input cho phép.
   Nếu chưa gửi nước ở lượt mở đầu và không còn thời gian, tiếp tục quan sát
   để đọc bàn mới và đánh lượt tiếp theo; không tự dừng chỉ vì lỡ lượt đầu.
5. Kết thúc trận hiện tại thì dừng. Không chờ boss lobby, tự đi bản đồ, vào
   trận mới hoặc tự xử lý bảng kết quả riêng của Dino.

Người dùng đã chốt **đánh xong trận hiện tại rồi dừng**. Giới hạn đúng
**một trận đang mở**, Start ghim
target/attempt là1; không dùng giá trị200/400 từ phiên farm trước. Không Resume
checkpoint boss. Chưa triển khai suy luận/shadow cho profile mới.

## Hành vi và an toàn

- Đơn giản và Khủng long chạy cùng luật Kiếm/Nộ/Mana/Máu/thẻ/tiến hóa, cùng
  simulator, input thường, ACK, QTE và random theo cấu hình. Ngưỡng Máu30%.
- Start Khủng long cần trạng thái còn mới, backend khỏe, process x64 đã gắn,
  `ACTIVE_COMBAT` và match ID. Bỏ target boss lưu từ trước. Runner kiểm lại PID
  và match ID, rồi ghim một `CombatSessionKey` thật; không dựng entry/opening giả.
- Provider chỉ cho attach trong trận khi có opt-in riêng. Không quét bàn hiện
  tại thành baseline sảnh giả; giữ64ô hợp lệ, hai mẫu ổn định, nguồn gắn với
  phiên/owner/transport/native hiện tại và ACK. Batch heap rời không đủ quyền.
  Các caller khác giữ nguyên cấu hình mặc định cần baseline.
- Lượt mở đầu0/1 có thể hết giờ nếu chưa có input tiêu lượt và không có action
  pending hoặc yêu cầu bắt buộc sau hai lần bỏ lượt. Tiến hóa đã xác nhận không
  tiêu lượt không cấm chờ lượt kế. Không tạo PASS/ACK giả, không dùng lại nước
  cũ. Lượt sau, input đã gửi/chưa rõ ACK, sai phiên, mất focus và lỗi an toàn
  tiếp tục dùng cơ chế cũ.
- Không prime một lượt quét heap toàn bộ/baseline sảnh trước nước đầu. Khởi
  động sử dụng provider/controller hiện có; thời gian thực tế chưa đo native.
- Dừng khẩn cấp còn hiệu lực trong lúc đọc bàn và tại ranh giới input. Dừng
  sau trận vẫn đánh nốt trận hiện tại. Lỗi được ghi `events.jsonl`, `run.json`,
  `matches/attempt_001/combat.jsonl` trong `logs/farm_runs/<run-id>/`.

## Reverse và giới hạn bằng chứng

Reverse b10 có `DinoIsle.DinoBattleBridge` (HuntId/EnemyPetId và đường tạo phòng
riêng), `DinoBattleReturn` và `DinoHuntResultPanel`. Điều này giải thích vì sao
không dùng vòng boss lobby/Chinh Phục cho chế độ này. Code mới **không gọi**
bất kỳ method game nào; không thêm offsets/RVA, sửa memory hoặc network.

Việc chọn Khủng long là ý định người dùng; Start kiểm chứng combat chung,
không tuyên bố đã tự nhận diện `HuntId` hoặc đã live xác minh toàn bộ giao thức
Dino. Cần một trận thật sau phiên soak để xác nhận dữ liệu bàn/thẻ, nước đầu
và kết trận trên chế độ game này. Không đem kết quả BASIC Demon Farm sang
chứng nhận Khủng long, không đổi source/calibration authority cũ.

## Kiểm chứng offline

- Test chọn nước đối chiếu toàn bộ decision/trace (trừ nhãn profile) trên16
  tổ hợp bàn, tài nguyên, boss HP và tiến hóa: bằng Đơn giản.
- Controller thật, native giả: đi ngay lượt1 khi đủ dữ liệu; hết giờ lượt1
  không input → giữ chạy → gửi đúng một SWAP ở lượt3 (lượt local thứ2), đọc
  lại/preflight; cùng trace Đơn giản vẫn xử lý deadline theo luật cũ.
- Test Start giữa trận không cần boss ID; loại target phòng cũ; từ chối sai
  match/trạng thái, ghim PID, board chưa đủ mẫu, pending và nguồn không rõ; F9/F6,
  persistence, routing production, artifact/counter/terminal và không checkpoint.
- Kết quả cuối và số lượng kiểm tra ở
  [verification.json](artifacts/dinosaur_mode_20261025/verification.json),
  [regression.log](artifacts/dinosaur_mode_20261025/regression.log).
- Ba kiểm tra lịch sử đã lỗi cả trên bytes nguồn trước task: archived config
  thiếu `input_randomization`, source pins trước các sửa maintenance. Giữ nguyên
  lỗi/trace tại [legacy_before_task.json](artifacts/dinosaur_mode_20261025/legacy_before_task.json).
  Không sửa decoder production, xóa assertion hoặc đổi hash cũ để làm xanh test.

Nguồn trước task lưu hash357file Python. Chỉ8file Python hiện có đổi, thêm
2module và1test; các file/game/phiên live ngoài phạm vi giữ nguyên. Xem manifest
trước/sau và diff riêng trong `docs/artifacts/dinosaur_mode_20261025/`.

Kết quả cuối: **22/22 test Khủng long PASS**. Bộ rộng1.054tests chạy64,151s:
**1.051PASS**,2FAIL/1ERROR là ba ca lịch sử đã tái hiện trước task; không có
failure mới ngoài nhóm đó. Không gọi đây là full-suite PASS.360file Python
parse AST thành công;349/357file Python cũ giữ nguyên. Source fingerprint:
`91bc63340f1b63cf995caa40d86f2c9da607020440b35e4205590ca10b31a3d1`.
