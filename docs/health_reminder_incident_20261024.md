# Farm 87/120 dừng, popup sức khỏe còn mở — 2026-10-24

**Cập nhật:** [đã bổ sung nhánh re-entry cho bootstrap phòng thất bại](postmatch_bootstrap_reentry_fix_20261024.md),
758/758 regression offline PASS; live pending. Nội dung bên dưới giữ nguyên
kết luận của lượt điều tra trước sửa.

## Kết luận

Phiên `3157d2739f604f3cb517ed65ca627d4a` thắng 87 trận và dừng vì
`RETURN_LOBBY_TIMEOUT / BOSS_LOBBY_TIMEOUT` khi chờ về phòng sau trận 87.
Game mất WebSocket trong trận cuối; khi trở về, bootstrap phòng không tải
được user/RoomDTO. Không có bằng chứng popup sức khỏe làm dừng phiên này.

Popup trong ảnh hiện được bộ đọc native nhận đúng `open=true, clean=true`,
generation 1, Button có geometry hợp lệ. FarmRunner đã STOPPED nên không còn
handler input chạy; poller Desktop chỉ đọc trạng thái, không tự đóng popup
hoặc tự tiếp tục farm sau SAFE_STOP.

## Timeline

Giờ Việt Nam ngày 24/10/2026; giờ có độ chính xác mili giây lấy từ log tool.

| Giờ | Chứng cứ |
| --- | --- |
| 14:53:26 | Bắt đầu phiên target120/maxattempt600, Demon Farm/Khiên/4, BASIC |
| 16:02:17.210 | Trận87 `M_eb659fa5` mở thành công |
| 16:02:26 | Player.log ghi WebSocketException đọc frame; ChatService đóng code1006, không clean |
| 16:02:51.677 | Trận87 WIN; strong terminal/bossHP0, kế toán87/120 |
| 16:02:53.893 | Đã gửi click xác nhận thưởng, không phải bỏ quên nút Đồng ý |
| 16:03:01.162 | Poller nhận LOBBY_OTHER/CHINH_PHUC_ISLAND, không có target hợp lệ |
| 16:04:24.267 | Hết90 giây chờ phòng, SAFE_STOP/RETURN_LOBBY_TIMEOUT |
| khoảng16:22 | Ước tính mốc180 phút từ counter online quan sát read-only sau đó; không phải event Show có timestamp |
| 16:45:32 | Một lần WS lỗi khác sau khi tool đã dừng; sau đó game thử rejoin Coop_181235 và báo phòng không tồn tại/đã đóng |

Trong đoạn game trở về sau trận87, Player.log ghi:

```text
[ManagerQuangTruong] Fast return nhưng mất WS room → fallback normal path
[ManagerRoom] LoadRoomDataWithoutLoading: WS bootstrap fail → user/room không load.
[Room_Handler] Timeout chờ currentUser sau 50s! (ROOM_BOOTSTRAP_RES không về — kiểm tra độ trễ backend)
```

Các dòng này không có timestamp riêng; đối chiếu thứ tự sau init MatchId87
và trước lần WS lỗi16:45:32. Không gán cho lỗi rejoin lúc16:45 là nguyên nhân
đầu tiên của lần tool dừng16:04.

## Vì sao nhánh phục hồi chưa chạy?

Snapshot cuối lúc timeout có lifecycle `LOBBY`, không có rig/Board/Active,
nhưng WsRoomService vẫn giữ `Coop_181235`, type`ChinhPhuc`, owner là user hiện
tại. Đồng thời `ManagerRoom.roomData=null`, không có enemyPetId/name/level và
properties không chứa boss identity hợp lệ. Nút Start vẫn allocated/interactable.
Classifier trả `LOBBY_OTHER/CHINH_PHUC_ISLAND` theo panel nền còn active; đây
không chứng minh lớp phòng nhìn thấy trên ảnh đã đóng.

Các predicate hiện có bảo vệ re-entry:

- Map candidate đòi WSroomid/type đã rỗng để tránh thao tác khi còn ở phòng.
- Detached shell candidate đòi pet ID target còn được chứng minh trong RoomDTO.

Shape thực tế vừa giữ WS room cũ vừa mất RoomDTO/boss identity nên không vào
nhánh nào; waiter hết90 giây và router không nhận timeout chung làm nguồn
re-entry. Đây là thiếu coverage phục hồi cho phòng bootstrap thất bại, không
phải lỗi random hay lỗi quyết định đi nước. Không được chỉ bỏ điều kiện rồi
click boss/đóng phòng khi chưa có proof UI tương ứng.

## Popup có xuất hiện trước khi dừng không?

Farm không có event health-reminder, không có input domain đóng thông báo,
không có ảnh popup tại thời điểm dừng. Handler đang có trong waiter nhưng
trả ABSENT thì không ghi event. Vì vậy chỉ log này chưa cho timestamp mở.

Probe read-only cùng game PID4728 lúc09:49:40.166 UTC đọc `_onlineSec`12434.5322;
một giây sau12435.5283, generation1/pendingfalse/Canvasopen. Theo reverse b10,
Show dùng floor(_onlineSec/60); ảnh ghi180 phút. Ngoại suy tốc độ counter hiện
tại cho mốc180 khoảng16:22:25, hơn18 phút sau SAFE_STOP. Các mẫu mới lưu trong
evidence cũng cho mốc này gần tương tự. Đây là ước tính với giả định clock/session
không bị reset hoặc tăng tốc giữa các thời điểm, không đổi thành timestamp Show
đã log. Dữ liệu hiện có ủng hộ popup xuất hiện sau khi tool dừng.

Không có lọc số180/193/370 trong handler. Probe hiện nhận được cùng popup thật;
không cần sửa dấu vân tay hoặc số phút để nhận nó.

## Phạm vi và bằng chứng

[Evidence gồm raw hashes, timeline, terminal, snapshot và native samples](artifacts/health_reminder_incident_20261024/evidence.json).
[Trích log game có số dòng](artifacts/health_reminder_incident_20261024/player_excerpt.txt).
Source fingerprint giữ nguyên
`9dd81a8ec663eb7b6f58e0b6789c9d944fe7a7a8812f659bbbc89fa3151ec701`.

Lượt này điều tra theo yêu cầu check: không sửa runtime, không phát input,
không đóng popup, không Start/Resume hoặc build. Đọc process chỉ dùng
PROCESS_QUERY_INFORMATION/PROCESS_VM_READ; không gọi hàm game.
