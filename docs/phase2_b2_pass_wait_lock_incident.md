# Phase 2 b2 — PASS_WAIT giữ khóa qua nhiều lượt local

Ngày điều tra và sửa offline: 2026-09-12. Phase 2 vẫn chưa chốt. Không commit,
push hay tăng version trong lần sửa này.

## Phạm vi run

FarmRun `dcd4bc3c6d55430abee17139c4257e67` dùng cấu hình mặc định, target 5 và
tối đa 8 attempt. Run hoàn thành bốn trận đầu với kết quả WIN / STRONG /
CONSISTENT. Attempt 5, MatchId `M_f832ad3c`, bị game đưa về lobby sau ba lượt
local liên tiếp không có input và FarmRunner kết thúc `SAFE_STOP /
PASS_ABORTED_COMBAT_END`.

Vì vậy trạng thái UI `Completed 4/5` có nghĩa attempt 4 đã thắng; lỗi xảy ra ở
attempt 5. Toàn run có 59 SWAP sent, 56 ACK, 3 CAST sent, 2 accepted, 3 EVOLVE
attempt, 1 success và đúng 1 formal PASS. Provider có 0 read error, 0 DTO
rejection, 0 stale publication và 0 ambiguous-latest rejection.

## Bằng chứng lượt lỗi

Trong attempt 5, sáu lượt local đầu đều gửi SWAP và nhận ACK. Ở turn 13 policy
chọn `STEP_6_PASS` khi còn 13 giây: board có 6 legal move nhưng 0 safe move,
không có safe Sword/Rage/Mana/Health/Shield/Drain, mana 90 thấp hơn Fusion cost
120, và reset baseline từ SWAP turn 11 đã được xác nhận. Đây là một PASS chủ
động hợp lệ theo policy hiện tại.

Sau PASS turn 13, MatchService lần lượt báo turn 14 BOSS, turn 15 LOCAL, turn
16 BOSS và turn 17 LOCAL. Turn 15 và 17 không có `policy_decision`,
`action_sent` hay formal PASS mới. `PASS_WAIT` chỉ kết thúc tại combat end với
`PASS_ABORTED_COMBAT_END`. Do đó ba lượt game tính là bỏ gồm một PASS có chủ
đích ở turn 13 và hai lượt zero-input ngoài ý muốn ở turn 15/17.

## Nguyên nhân

Controller đã chuyển sang `DispatcherTransportTap` làm nguồn transport chính.
Nguồn này lấy callback/message đã giữ lại và trả
`RuntimeSequenceObservation.scan_performed=false` vì không quét managed heap.
Trong khi đó `AuthoritativePassCoordinator` chỉ đếm một vòng quan sát AFK đã
hoàn tất khi `scan_performed=true`. Nếu callback AFK ngắn bị lỡ, coordinator
nhìn thấy game đã quay lại lượt local nhưng không bao giờ đủ điều kiện thoát
`PASS_WAIT`; vòng chính tiếp tục khóa toàn bộ gameplay input.

Đây là lỗi nối hai cơ chế đọc, không phải solver không tìm được nước, provider
không đọc được bàn hay game không ACK các SWAP trước đó.

## Sửa chữa

Vòng chính nay mang provenance của observation. Một mẫu từ dispatcher callback
đang hoạt động hoặc một bounded heap response scan đều được tính là một lần
quan sát phản hồi hoàn chỉnh. Sau hai mẫu hoàn chỉnh trên cùng lượt local kế
tiếp mà vẫn không có AFK tương quan, coordinator kết thúc
`PASS_STATE_UNCONFIRMED` thay vì giữ khóa đến hết trận.

Trong production B5, kết quả này không tạo hay đoán `idleCount`. Bot giữ trạng
thái số học là UNKNOWN, cấm PASS/EVOLVE cho lượt cứu, đọc lại current board và
bắt buộc một SWAP hoặc CAST tiêu thụ lượt. Hành động tiêu thụ an toàn với mọi
giá trị idle có thể có và cắt chuỗi zero-input. Khi không có safe move, BASIC
dùng nhánh minimum-risk bắt buộc đã có sẵn. Các stage nghiệm thu P1/P2/P3 và
B3/B4 vẫn dừng an toàn khi PASS không xác nhận; thay đổi tiếp tục trận chỉ áp
dụng cho production B5.

Việc không thấy AFK qua dispatcher vẫn không được hiểu là server không tính
PASS. Nó chỉ kích hoạt hành vi bảo thủ là phải hành động ở lượt kế tiếp.

## Xác minh offline

- `tests.test_authoritative_pass` và `tests.test_autonomous_control`: 122/122
  PASS.
- Toàn bộ `python -m unittest discover -s tests -p 'test_*.py' -q`:
  **1167/1167 PASS**.
- `py_compile` cho coordinator và production bot: PASS.

Cần live soak lại target 5 / attempts 8. Tiêu chí trực tiếp cho lỗi này: nếu
formal PASS không bắt được AFK nhưng MatchService quay lại lượt local, log phải
có `PASS_STATE_UNCONFIRMED`, `mandatory_action_state_entered` với source
`PASS_STATE_UNCONFIRMED_NEXT_LOCAL`, rồi một SWAP/CAST được gửi và ACK ngay
trong lượt đó. Không được có hai lượt local kế tiếp thiếu policy/action như
turn 15/17 của run lỗi.
