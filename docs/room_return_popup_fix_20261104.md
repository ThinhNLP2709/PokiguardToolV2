# Sửa dừng sau trận khi phòng lỗi và popup che UI — 04/11/2026

Đã đối chiếu hai run `8c37be…` (390 trận) và `bc9657…` (96 trận).
Cả hai kết thúc trận bình thường, xác nhận thưởng, rơi ra bản đồ Thập nhị
tinh, chọn lại đúng target rồi hết thời gian chờ phòng: `RETURN_LOBBY_TIMEOUT`.
Đây là lỗi nhánh về phòng/re-entry, không phải dừng controller giữa lượt.

## Chứng cứ và giới hạn kết luận

- Run390 dừng khoảng **04:42 ngày03/11**; run96 dừng **02:32 ngày04/11**, giờ
  Việt Nam. Snapshot cuối của cả hai có `roomData=null`, `enemy_pet_id=null`,
  không còn ownership của room, nhưng graph bản đồ và Button target vẫn đọc được.
- Ảnh người dùng chụp07:35 ngày03/11 có popup sức khỏe540 phút trên hộp Mời
  đồng đội và một phòng thiếu thông tin. Không có ảnh ở thời điểm timeout,
  nên **không xác định được popup540 xuất hiện trước hay sau lúc tool dừng**.
  Không khẳng định chính popup gây ra lần dừng ban đầu hoặc tool đã bấm Mời bạn.
- Log run390 có hai lần đóng nhắc sức khỏe thành công trước đó, tại attempt112
  và364. Các event trạng thái farm được ghi dồn ở cuối; không lấy timestamp
  flush đó làm giờ popup thực sự xuất hiện.
- Nút Đã hiểu trên ảnh540 vẫn qua kiểm tra ảnh/native rectangle hiện có.
  Logic không đọc số phút để quyết định có đóng hay không.

## Thiếu sót trong code đã sửa

1. Probe phòng rỗng che bản đồ trước đây đòi DTO/ID boss cũ còn tồn tại. Vì
   cả hai đã mất trong ca này, nó có thể bỏ qua kiểm tra lớp phòng trước khi
   dùng tọa độ Button của bản đồ cache. Nay chấp nhận thêm đúng shape NULL
   có nguồn từ log, chỉ để mở probe ảnh có giới hạn. Click thoát vẫn phải có
   hai frame Start/Ready + X phù hợp, lifecycle owner-free và target proof.
2. Nếu lần chọn target kết thúc bằng timeout nhưng vẫn chứng minh được bản
   đồ owner-free, router nay có thể sử dụng lượt phục hồi còn lại. Giữ tối đa
   hai pass và luật target click lần hai cần shell exit được xác nhận.
3. Foreground nay chạy cùng kiểm tra target ngay trước click như pinned.
   Popup trong lúc probe cũng được xử lý trước khi dùng lại trạng thái.
   Reconnect hoàn tất trong lúc kiểm tra sẽ được đọc lại, tránh dừng dù room
   đã sẵn sàng.
4. Ngoài nhắc sức khỏe, xử lý hộp **Mời đồng đội** qua đúng serialized
   `RoomCoopV2Refs.btnInviteClose`. Đóng sức khỏe trước, rồi đóng Mời đồng đội,
   kiểm tra đã đóng và đọc lại lớp UI bên dưới. Không chọn player hoặc nút gửi
   lời mời. Có navigation permit riêng; không dùng permit gameplay/Start.
5. Một lần về phòng thất bại sẽ lưu `return_lobby_failure.png` và event
   `postmatch_return_failure_evidence` gồm lobby mới đọc và trạng thái nhắc sức
   khỏe, kể cả khi ảnh thường đã tắt. Lỗi lưu chẩn đoán không đổi kết quả router.

## Native evidence của hộp Mời đồng đội

B14/metadata111 khai báo `RoomCoopV2Refs.designRoot +0x30`, `ButtonStart +0x38`,
`invitePanel +0x258`, `btnInviteClose +0x260`; dùng static/view refs đang có.
Reader kiểm class, active panel, Button khác Start, interaction flags, ancestry
trong designRoot, managed/native roundtrip và geometry ổn định. Kiểm ảnh chỉ
trong đúng rectangle của Close, sau đó fresh preflight và xác nhận panel ẩn.

Đã đọc PE tĩnh: `RoomCoopV2Host.CloseInvite` RVA `0xF09340` chuyển panel vào
`UIAnim.Close`; callback RVA `0x12AF6C0` gọi
`UnityEngine.GameObject::SetActive_Injected(System.IntPtr,System.Boolean)` với
false sau animation. Đây là chứng cứ byte tĩnh; không gọi hàm game.
[Disassembly](artifacts/room_return_20261104/invite_native_static.json).

## Kiểm chứng

**404 test/12 module PASS**: recorded NULL DTO, map thật không bị thoát nhầm,
foreground/pinned, popup540, Invite Close đúng ownership/không alias Start,
ảnh không có dấu X bị từ chối, combat/unknown/Stop, re-entry hữu hạn,
checkpoint/storage, failure capture và B14 source guard.

AST audit xác nhận main runner chỉ đổi callback xử lý modal; FarmRun core
chỉ thêm permit overlay và thống kê lobby input. Reasoning/scorer, BASIC,
board provider, input primitive, QTE và luật PASS giữ nguyên byte.

[Test log](artifacts/room_return_20261104/verified_tests.log),
[receipt/source](artifacts/room_return_20261104/closure.json).

Chưa có live click popup sau sửa: lần probe chỉ đọc không attach được game.
Source404 file SHA `4da18e87…`; chưa build lại ZIP1.3.0, ZIP cũ giữ SHA
`a9a190ba…`. Các proof timing/adviser trước sửa giữ nguyên nguồn và phạm vi.
