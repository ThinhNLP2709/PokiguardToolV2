# Phase 2 b2 — hụt phản hồi EVOLVE làm mất nước kiếm cùng lượt

Ngày điều tra và sửa offline: 2026-09-12. Phase 2 vẫn chưa chốt. Không commit,
push hay tăng version trong lần sửa này.

## Phạm vi run

FarmRun `71526bd08c114d02b42a90129d60c2b1` dùng cấu hình mặc định, target 5 và
tối đa 8 attempt. Hai attempt đầu đều WIN. Attempt 1 có 9 local turn, 9 SWAP đã
gửi, 8 ACK và một EVOLVE thất bại. Attempt 2 có 8 local turn, 8 SWAP đã gửi và
7 ACK. Attempt 3 được người dùng F9 sau khi quan sát tool bỏ kiếm.

Toàn run không có formal PASS. Provider có 0 read error, 0 DTO rejection, 0
stale publication và 0 ambiguous-latest rejection. Vì vậy lượt mất input không
phải do policy chọn PASS, thiếu board hay solver không thấy nước.

## Bằng chứng lượt lỗi

Lượt người dùng gọi là turn 6 của trận 2 trên màn hình là local turn thứ 6 của
attempt 3, tương ứng game `TurnNumber=11`, MatchId `M_0242dfaa`. Năm local turn
trước đều gửi SWAP; nước mana tại turn 9 được ACK trước khi vào turn 11.

Ở `18:56:15.740Z`, policy chọn `STEP_1_EVOLVE` khi còn 13 giây và mana 210,
đủ runtime Fusion cost 120. Input EVOLVE được gửi ở `18:56:15.927Z`. Từ
`18:56:16.901Z`, exact MatchService state ổn định là:

- `LocalFusionLastAttemptTurn=11`;
- `LocalFusionLockedThisTurn=true`;
- `LocalFusionUsed=false`;
- Fusion cost 120;
- highest ACK 25 so với source sequence 23;
- current turn vẫn là 11 và local move sequence chưa đổi.

Trạng thái này lặp đến `18:56:31.620Z` khi đồng hồ giảm từ 13 xuống 1. Không có
`MATCH_FUSION_RES` được dispatcher/scan giữ lại. Controller cũ chỉ coi durable
Fusion state là terminal khi `used` đổi thành true; trường hợp thất bại vẫn chờ
DTO phản hồi, gia hạn observation một lần rồi khóa mọi input còn lại của turn.
Do đó policy không được chạy lại để chọn Sword.

Reverse và tài liệu `card_state_detection.md` xác nhận `HandleFusionRes` luôn
ghi current turn vào `LocalFusionLastAttemptTurn` cho local actor, còn
`LocalFusionUsed=true` chỉ được ghi khi thành công. Kết hợp last-attempt mới,
current-turn lock và `used=false` vì vậy là bằng chứng bền vững cho một response
thất bại đã được game xử lý, không phải suy đoán từ việc thiếu callback.

## Sửa chữa

`_fusion_terminal_result` nay nhận hai terminal equivalent đọc-only:

- thành công: `used` đổi `false -> true` và last-attempt đúng source turn;
- thất bại: last-attempt mới đúng source turn, current-turn lock true và
  `used=false`.

Cả hai đường đều hoàn tất pending EVOLVE ngay ở sample bền vững đầu tiên, cập
nhật đúng bộ đếm success/failure và dùng khoảng settle trình bày 3.5 giây đã có.
Nếu vẫn còn cùng local turn, controller đọc fresh board/actionability rồi chạy
policy tiếp để gửi SWAP/CAST. Nó không click EVOLVE lần hai trong cùng turn,
không gửi input lúc presentation còn bận và không tự sửa idle counter.

Với timeline run lỗi, terminal failure đã có sau click khoảng một giây. Sau
settle sẽ còn khoảng 8–9 giây cho nước Sword thay vì chờ đến khi đồng hồ còn một
giây.

## Xác minh offline

- `tests.test_autonomous_control`: **108/108 PASS**.
- Toàn bộ `python -m unittest discover -s tests -p 'test_*.py' -q`:
  **1168/1168 PASS**.
- Test mới xác nhận durable failure được phân loại khi không có response, đồng
  thời từ chối state không có attempt mới hoặc không có current-turn lock.
- `py_compile`, `compileall` và `git diff --check`: chạy lại ở bước nạp UI.

Cần live soak tiếp. Tiêu chí trực tiếp: nếu callback EVOLVE lại bị hụt nhưng
durable state trên xuất hiện, log phải ghi `EVOLVE_FAILED` với
`terminalEquivalent=MATCH_SERVICE_DURABLE_FUSION_TRANSITION`, kết thúc settle
và gửi nước Sword/SWAP an toàn trong cùng turn nếu thời gian và actionability
còn hợp lệ.
