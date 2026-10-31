# Re-entry khi mất dữ liệu phòng sau nhận thưởng — 2026-10-24

Đã sửa trong source, kiểm chứng offline **758/758 bài PASS**, gồm18 ca mới.
Chưa live test, đổi version hoặc build ZIP. Tool đang mở phải được đóng/mở lại
để nạp source mới; ZIP v1.2.8 đã phát hành không tự nhận thay đổi này.

## Nguyên nhân đã xác minh

[Điều tra trận87/120](health_reminder_incident_20261024.md) ghi game mất WS,
bootstrap phòng thất bại sau khi đã click nhận thưởng. Room ID/type/owner vẫn
còn nhưng RoomDTO và boss identity mất. Nhánh map đòi WS room đã rỗng; nhánh
detached shell đòi pet ID còn trong RoomDTO. Shape thực tế không khớp cả hai
nên waiter hết90 giây và dừng `RETURN_LOBBY_TIMEOUT`.

## Hành vi sau sửa

1. Vẫn dùng khoảng chờ rehydration đang có: trong lượt farm điều khiển thông
   thường là45 giây với return timeout90 giây. Nếu dữ liệu phòng phục hồi,
   waiter trả phòng hợp lệ như trước. Không thêm chờ trong gameplay.
2. Nếu cùng phòng lỗi ổn định qua khoảng đó, trả
   `ROOM_BOOTSTRAP_FAILED_CANDIDATE`, thay vì chờ tới timeout chung. Fallback
   classifier cũng nhận snapshot timeout cũ có đúng shape này.
3. Nhánh đóng shell chỉ được kích hoạt sau một trận Solo đã kết thúc, đã gửi
   xác nhận thưởng, không còn combat session và target trùng FarmTarget bất
   biến. Không dùng dữ liệu phòng thiếu để suy ra boss mới.
4. Kiểm chứng native Start geometry và hai frame của lớp phòng Start/Ready +
   nút X hiện có; reread room key và geometry trước click. Chỉ thoát đúng
   shell đã chứng minh, kể cả trong chế độ ghim. Nếu có hộp thoại xác nhận
   thoát, dùng nhánh xác nhận có giới hạn hiện tại với cùng room key.
5. Sau khi thoát thật, dùng router bản đồ/sảnh hiện có, tìm đúng pet ID và
   native Button geometry của target trước khi click vào lại phòng. Không
   click map xuyên qua lớp phòng lỗi. Không tăng lại completed/attempt/recovery.
6. Kết nối có thể hồi giữa lúc chuẩn bị thoát: kiểm lại phòng tối đa2 giây;
   nếu phòng đã hợp lệ thì tiếp tục, không đóng phòng. Nếu đã ra map/sảnh thì
   dùng lượt route thứ hai trong giới hạn2 lượt đang có.

Candidate đòi lifecycle LOBBY sạch, không có owner combat; RoomDTO/boss fields
đều rỗng; WS vẫn giữ chính phòng ChinhPhuc của local host; Start/native control
sống, interactable, không opening flow. Lý do reader phải đúng trường hợp
properties đã đọc nhưng thiếu boss identity. Pointer/read error, UNKNOWN,
combat, phòng người khác hoặc room key thay đổi không cấp quyền thoát.

Popup sức khỏe tiếp tục được handler hiện có xử lý trước waiter/router. Nếu
handler đóng popup làm thay đổi surface, nhánh kiểm lại sẽ route theo surface
mới. Không click xuyên popup bị BLOCKED. Coop/current-room-only giữ các giới
hạn cũ, không tự tạo phòng Solo thay phòng của người khác.

## Kiểm chứng và giới hạn

Fixture lấy nguyên snapshot `normal_return_boss_lobby` attempt87 của run
`3157d2739f604f3cb517ed65ca627d4a`, có provenance trong JSON. Tests kiểm candidate,
grace, hồi phòng, F9, read error, thay room key, thiếu native/visual proof, chưa
click thưởng, target sai, đóng shell trước khi scan map, confirmation/target
capability, ghim và popup đổi surface. Luồng route/settle/capability là code
thật; native IO/ảnh/input được thay bằng fixtures/fakes, không phát input live.

[Verification](artifacts/postmatch_bootstrap_reentry_fix_20261024/verification.json),
[diff riêng lần sửa](artifacts/postmatch_bootstrap_reentry_fix_20261024/owned_source.diff),
[source manifest](artifacts/postmatch_bootstrap_reentry_fix_20261024/source_manifest.json).
Lần regression đầu có779 ca thật PASS và một loader lỗi do tên module không
tồn tại; log được giữ nguyên. Thêm hai ca modal, bỏ việc import lặp TestCase
của fixture; lần kiểm cuối758/758 PASS trong40,771s trên source cuối.

Chỉ2 file runtime `tools/farm_cycle.py`, `tools/farm_run.py` thay đổi;
354/356 Python file cũ byte-preserved, thêm1 test file và1 JSON fixture.
357 Python file parse AST thành công. Gameplay solver/provider/QTE/input
executor/random config/version không đổi trong lần sửa này. Không sửa game,
gọi API game, ghi memory hoặc đổi pin timing/source authority lịch sử.

Fingerprint:
`5fbfcd84753c9c9d06de0e3b779be21a08b438e3156a2e80659e596452a23def`.
Game đã đóng lúc thử quan sát read-only geometry nên việc thoát shell lỗi
thật và vào lại boss vẫn cần live xác nhận; không ghi nhận live PASS từ tests.
