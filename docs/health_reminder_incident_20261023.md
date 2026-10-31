# Dừng farm 95/500, bị đá AFK và thông báo sức khỏe

**Cập nhật2026-10-24:** [đã sửa guard và lưu failure frame](leave_modal_guard_fix_20261024.md),
hồi quy offline598 ca PASS,9 ca helper/controller cuối PASS; live pending.
Phần bên dưới giữ nguyên kết luận điều tra ngày23/10, không phải claim chưa có
bản sửa hiện tại. Frame gốc vẫn thiếu, không tự đổi UNKNOWN thành false positive đã chứng minh.

Ngày rà: 2026-10-23, Asia/Saigon. Đây là điều tra nhánh phụ, không triển khai
5E.2 hoặc sửa runtime. Source hiện mang nhãn v1.2.8; phiên UI được ghi là
source mode (`frozen=false`), không suy ra chính xác hash runtime lúc khởi chạy
chỉ từ nhãn hiện tại.

## Kết luận có bằng chứng

Farm `6b1a3c585e584f6dbb2007fff8207fcf` dừng sau 95 WIN, khi đang chơi trận96
`M_ef0c85dd`. Nguyên nhân trực tiếp là guard ảnh báo có hộp thoại xác nhận thoát
trước một SWAP. Tool hủy proposal chưa gửi, AUTO_PAUSED rồi SAFE_STOP. Sau đó
game ghi `KICKED room=Coop_635716 reason=AFK` và UI chuyển về sảnh chính.
Đây không phải một lần kết trận/nhận thưởng bình thường.

Thông báo sức khỏe không có event phát hiện/click trong farm này. Không có
chứng cứ nó gây lần dừng 02:44. Sau SAFE_STOP, vòng FarmRunner đã kết thúc;
poller giao diện còn đọc trạng thái nhưng không có quyền tự đóng modal hoặc
tự khởi động lại farm. Do đó thông báo xuất hiện sau đó sẽ còn trên màn hình.

## Timeline, giờ Việt Nam ngày23/10

| Giờ | Bằng chứng |
| --- | --- |
| 01:37:15.590 | Bắt đầu farm, target500/maxattempt600, Demon Farm/Khiên/4, BASIC |
| 02:44:09.241 | Trận95 WIN, strong terminal, bossHP0; kết quả nhất quán UI |
| 02:44:15.070 | Xác nhận về đúng phòng boss Lieyun |
| 02:44:19.899 | Trận96 mở thành công, đủ64 ô |
| 02:44:22.807 | Gửi SWAP đầu trận96 |
| 02:44:23.198 | SWAP đã được ACK |
| 02:44:27.200 | Lượt ta tiếp theo, turn3; runtime còn ACTIVE |
| 02:44:34.396 | `LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK`, hủy SWAP thứ hai trước dispatch |
| 02:44:34.397 | `FARM_GAMEPLAY_AUTO_PAUSED`; sau đó `COMBAT_SAFE_STOP`, 95/500 |
| 02:45:25.326 | Poller UI ghi LEAVING_COMBAT; controller đã STOPPED |
| 02:45:30.151 | Poller UI ghi sảnh chính, `general game lobby proven` |
| 07:41:08.814 | UI đóng sạch; trạng thái cuối vẫn sảnh chính, controller STOPPED |
| 07:41:33.743 | Thời gian ghi file ảnh người dùng cung cấp, đang hiện370 phút; không phải timestamp popup bắt đầu mở |

Player.log xác nhận AFK trong cùng room, sau đoạn khởi tạo đúng MatchId96;
log game không có timestamp từng dòng nên giờ chuyển cảnh lấy từ poller UI.
Trận96 chỉ có1 SWAP/1 ACK, không CAST/EVOLVE/PASS, không terminal snapshot,
không kết quả WIN/LOSS, không click xác nhận thưởng và không automatic exit/re-entry.

## Bộ nhận diện nào làm tool dừng?

`recovery_ui.locate_confirm_leave` tìm đúng hai vùng màu cam có kích thước/
đối xứng phù hợp trong vùng ảnh, rồi trả `found=True`, confidence0.96 cố định.
Đây là heuristic ảnh, không phải xác suất đúng hoặc native proof của modal.
Lần này ghi leftPixels1701/rightPixels1697, điểm chuẩn hóa(0.40546875,0.56015625).

Nhánh SWAP trong `tools/basic_auto_bot.py` dùng kết quả đó để tự pause. Không
lưu frame kiểm tra tại nhánh này; attempt96 chỉ còn combat/entry JSON. Vì vậy
**chưa thể chốt modal thoát thật hay nhận diện nhầm các vùng màu trên bàn cờ**.
Đã xác định chính xác điều kiện làm dừng, nhưng nguyên nhân sâu hơn của kết quả
nhận diện vẫn cần bằng chứng ảnh/native phù hợp. Không quy lỗi cho người dùng,
không gọi nhận diện nhầm là đã được chứng minh và không bỏ guard để tiếp tục.

## Chu kỳ thông báo theo reverse b10

Disassembly mới của `PlayReminder.IntervalMinutes` RVA0x5DF450 và `Update`
RVA0x5DFEE0, đối chiếu binary b10 SHA2569bedce81…:

- Mặc định interval180 phút. Đọc override `RemoteUiConfig.TryGet("health",
  "reminderMin", out value)`; parse số nguyên thành công thì dùng giá trị đó.
  Giá trị<=0 tắt nhắc; giá trị dương nhỏ hơn30 được nâng lên30.
- Cộng `min(unscaledDeltaTime,1.0)` vào `_onlineSec` khi session hợp lệ.
  Tính `floor(_onlineSec / (interval*60))`; khi vượt `_remindedCount` thì cập
  nhật generation và đặt `_pending=true`. Vì vậy có nhiều lần nhắc theo chu kỳ.
- Nếu `IsOpen` hoặc `InMatchNow` còn true thì chưa Show mới. Khi hết combat/
  busy, đợi ngoài trận ổn định2 giây rồi Show.
- Tham số Show là `floor(_onlineSec/60)`, tức tổng phút online tại lúc mở,
  không phải luôn là180 hay bội chính xác của interval. Thông báo có thể trễ
  vì còn trong trận/busy hoặc đang có modal mở. Chu kỳ có thể bị server đổi.
- Helper số học RVA0x2EE4D0 gọi CRT `floor` qua thunk0x29C62E rồi đổi về int;
  hằng số60.0 và2.0 được đọc trực tiếp từ binary, không suy từ ảnh.

Với default180, các ngưỡng là180/360/540… nhưng ảnh370 **không chứng minh**
interval đang là370/185 hay một giá trị cụ thể khác. Giá trị remote trong
session này và thời điểm popup đầu tiên mở đều NOT_OBSERVED. Log hiện không
ghi event Show/text của PlayReminder nên không thể dựng lại giờ mở chính xác.

Tool nhận diện PlayReminder bằng class/ownership/Canvas, không so chữ180 hoặc
so phút. Do đó số370 không tự làm bộ xử lý modal từ chối.

## Phạm vi điều tra và bằng chứng

- [Trích log, timeline và raw hashes](artifacts/health_reminder_incident_20261023/log_evidence.json).
- [Disassembly interval/Update](artifacts/health_reminder_incident_20261023/native_reminder_interval.txt).
- [Symbols, binary hash và hằng số](artifacts/health_reminder_incident_20261023/native_symbols.json).
- Log gốc: `logs/farm_runs/6b1a3c585e584f6dbb2007fff8207fcf`,
  `logs/desktop_ui/20261023_013406`, Player.log trong LocalLow/Pet Puzzle/Pet Puzzle.

Không sửa runtime, không phát input, không đọc/ghi memory hay gọi game methods,
không mở game/tool, không build hoặc chạy thêm trận. Bước sửa phù hợp tiếp theo
là củng cố bằng chứng modal xác nhận thoát và giữ frame chẩn đoán khi guard đó
báo có modal; kiểm riêng việc đóng PlayReminder trong một farm còn hoạt động.
Không cần đợi đủ3 giờ hoặc tự gọi ShowForPreview để điều tra nhánh dừng đã rõ.
