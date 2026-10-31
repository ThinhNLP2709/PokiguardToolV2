# Nhắc nhở sức khoẻ — 2026-10-22

Người dùng chốt2026-10-23: thấy đúng popup thì đóng, bất kể180/193/370 hay
số phút khác. Handler không dùng số phút làm điều kiện. Bổ sung ảnh370 và
kiểm guard thoát tại [bản sửa2026-10-24](leave_modal_guard_fix_20261024.md).

Đã bổ sung xử lý cho Pet Puzzle 1.7.4-b10 và đóng gói trong
[v1.2.8 ngày 2026-10-23](v1.2.8_release_report.md). Phiên BASIC mới nhất đã WIN
3/3 với hai lần về lại target từ bản đồ; chưa phát input live để đóng modal
sức khoẻ thật do popup không xuất hiện. Đây là nhánh thích ứng UI,
không tiếp tục triển khai suy luận/Phase 5 trong thay đổi này.

## Hành vi

1. Trong phòng boss: phát hiện đúng `Poki.Health.PlayReminder`, chờ animation
   mở ổn định, click Button **Đã hiểu** đúng một lần, kiểm tra Canvas đã tắt,
   rồi đọc lại phòng và tiếp tục quy trình chuẩn bị/vào trận hiện có.
2. Sau trận, nếu đang ở bản đồ đảo, bản đồ boss hoặc sảnh game: đóng cùng modal,
   đọc lại trạng thái, rồi dùng router khôi phục hiện có về **FarmTarget đã lưu
   theo ID**. Không lấy boss nhìn thấy phía sau modal làm target mới.
3. Nếu client đã trả về LOBBY khi phần xác nhận kết quả còn chờ: chỉ nhận
   nhánh thông báo ngoài trận khi handler đã chứng minh/đóng được modal thật.
   Giữ kết quả terminal đã được caller ghi nhận; không ghi giả click nhận quà
   hay tự thêm một trận hoàn thành. Không thấy modal thì giữ kiểm tra cũ.
4. Modal được nhận diện bằng class/static instance → Canvas → `_board` →
   Button duy nhất thuộc cây đó. Màu xanh và chữ sáng chỉ kiểm chứng hình ảnh
   **trong RectTransform của Button đã xác định**, không tìm nút xanh bất kỳ.
5. Không có modal: đọc trạng thái, không chụp ảnh, không focus, không input.
   Có modal: cho native layout tối đa 2 giây ổn định, xử lý lỗi đọc/layout
   tạm thời có giới hạn; xác nhận đóng tối đa 3 giây sau click. Không click lặp
   khi không rõ kết quả. F9 vẫn hủy thao tác.
6. Năng lực input riêng `BOSS_HEALTH_REMINDER_DISMISS`; chỉ ở các trạng thái
   chờ/chuẩn bị ngoài trận, không có session hoặc permit khác. Một instance +
   `_remindedCount` chỉ được reserve một lần; lần nhắc sau có generation mới.
   Không tăng attempt/completed/recovery hoặc sửa quyết định gameplay.

Nhánh ngoài trận dùng chứng cứ LOBBY/stale-server đã có. Trường hợp combat
statics chưa khởi tạo chỉ dùng ngoại lệ **phòng Chinh Phục clean** và predicate
không có dấu hiệu combat vốn đã tồn tại. UNKNOWN chung, owner còn sống,
ENTERING/ACTIVE/LEAVING/POSTMATCH không cấp quyền click thông báo.

Coop giữ nguyên quy tắc hiện có: đóng thông báo nếu vẫn ở phòng; nếu bị đẩy
khỏi phòng của người khác thì không tự tạo một phòng Solo thay thế. Router tự
vào lại target trong báo cáo này là router Solo hiện có.

## Chứng cứ reverse và native

Nguồn: `reverse/reverse_1.7.4-b10/cs/Assembly-CSharp/Poki/Health/PlayReminder.cs`
và `reverse/reverse_1.7.4-b10/il2cpp.json`, đối chiếu disassembly GameAssembly.dll.

| Thành phần | Giá trị xác minh |
| --- | --- |
| TypeInfo `Poki.Health.PlayReminder` | RVA `0x3D686B0` |
| static `_instance` | static fields + `0x00` |
| `_remindedCount` | managed instance + `0x24` |
| `_canvas`, `_board` | managed + `0x30`, `0x48` |
| `IsOpen` | RVA `0x5DF220`, đọc Canvas.enabled |
| `Hide` | RVA `0x5E05C0`, chỉ Canvas.enabled = false |
| `Build` | RVA `0x5E0C60`; tạo `btnOk` dưới `_board`, delegate là `Hide` |
| `Show` | RVA `0x5E00C0`; có LeanTween.scale / setEaseOutBack |
| mặc định | 180 phút, settle ngoài trận 2 giây, sorting order 5200 |

`Update` hoãn thông báo khi `InMatchNow()` còn true. `InMatchNow` kiểm
MatchHost.IsInMatch/IsBusy, MatchContext, MatchSceneLoader.IsBusy. Không gọi
những hàm đó từ tool; chỉ dùng disassembly làm bằng chứng.

Canvas có thể vẫn có GameObject active sau khi đã đóng, nên không dùng
activeSelf để kết luận modal đang mở. Đối chiếu native:

- Icall Behaviour.get_enabled_Injected của UnityPlayer ở RVA `0x114430`:
  `48 8b 01 48 ff a0 c8 00 00 00`, lấy virtual slot `0xC8`.
- Canvas getter ở RVA `0xCD630`:
  `80 79 30 00 0f 95 c0 c3` = `cmp byte [rcx+0x30],0; setne al; ret`.
- Đã quan sát read-only qua `LoginScreen.Instance` TypeInfo `0x3D0FAF8`,
  static offset `0x10`, `_backCanvas +0x20`: managed type Canvas, virtual getter
  khớp file, reader mới đọc enabled=True. **Đây không phải live test modal.**
- Runtime kiểm class, ownership roundtrip, virtual target RVA và code bytes
  trước khi đọc byte enabled. Tất cả địa chỉ phụ thuộc module base hiện tại.
- Không ghi memory, không gọi Show/Hide/ShowForPreview hay hàm game nào.

Fingerprint file đang cài vẫn là b10 đã được chấp nhận:

- GameAssembly.dll: `9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777`.
- UnityPlayer.dll: `bb93aa060395c4ace3561b4ceafe06cfaebd5dfb883c451058b9ccb74b50b6d2`.

Không mở rộng fingerprint để chấp nhận build chưa xác minh.

## Boss/đảo/Chinh Phục đổi vị trí có ảnh hưởng không?

Nhánh điều hướng chính không giữ tọa độ boss/đảo/Chinh Phục cũ:

- `hub_navigation.read_hub_chinh_phuc_control`: lấy
  `ManagerQuangTruong.btnChinhPhuc +0x2C8`, rồi Button/RectTransform hiện tại.
- `chinh_phuc_map.discover_chinh_phuc_island_target`: gắn group chứa pet ID
  với Button đảo trong runtime graph.
- `discover_chinh_phuc_map_target`: gắn PetEnemyDTO/closure/panel Button với
  pet ID của FarmTarget; tọa độ lấy từ geometry sống của Button.

Do đó, **chỉ dời vị trí trên cùng cấu trúc UI không đòi sửa tọa độ cứng**.
Nếu game đổi ID, thứ tự liên kết dữ liệu/Button, hierarchy, Canvas hoặc artwork
ảnh hưởng kiểm chứng hình ảnh thì vẫn cần audit tương thích. Nhánh fallback
nhận dạng badge cũ cũng có giới hạn artwork riêng; không khẳng định mọi kiểu
đổi giao diện đều tự thích ứng. Trước click vẫn phải xác minh đúng target.

### Bổ sung sau bốn ảnh bản đồ cuộn dọc của người dùng

Ảnh Thập Nhị Tinh cho thấy boss được dời trong cùng màn; ba ảnh Chinh Phục
cho thấy **cùng danh sách đảo cuộn dọc**, không phải ba bản đồ độc lập.
Rà code xác nhận một thiếu sót chưa được sửa trong nhánh health reminder:

- `discover_chinh_phuc_island_target` chỉ trả Button có geometry hiện tại.
  NativeCardUiReader từ chối rectangle vượt root Canvas; caller nhận None.
- `_select_chinh_phuc_island_from_main_map` chỉ đọc lại target rồi click,
  chưa có input cuộn/kéo để đưa đảo vào vùng nhìn thấy. Vì vậy re-entry có
  thể hết deadline khi đảo nằm ngoài màn, kể cả đảo ở đầu danh sách nếu người
  dùng đang cuộn xuống dưới.
- Bounds root Canvas không thay cho bounds viewport/mask của danh sách cuộn.
  Chưa có chứng cứ đủ để khẳng định Button bị che/cắt bởi viewport vẫn an toàn
  để click; cần kiểm clipping trước khi cấp input.
- Reverse b10 khai báo `ChinhPhucIslandMap._content +0x28`,
  `SoftenViewport`, `FocusFrontier`, `Relayout`, `ApplyBob`. Đây là các khai báo
  được xác minh; ownership của ScrollRect/viewport và field cần đọc cho cơ chế
  cuộn của tool **UNKNOWN, chưa audit**, không suy ra offset từ ảnh.

Phần thích ứng tiếp theo cần đọc đúng content/viewport của bản đồ đang mở,
xác định đảo từ ID target, cuộn bằng input thông thường có giới hạn, đợi dừng,
rồi đọc lại ID/geometry và vùng click nhìn thấy trước khi chọn đảo/boss. Không
dùng số thứ tự huy hiệu hay tọa độ ảnh thay cho ID. **Chưa triển khai hoặc live
test phần cuộn trong lượt rà ảnh này**; 320 test phía dưới là phạm vi health
reminder và regression cũ, không chứng minh hỗ trợ cuộn dọc.

## Kiểm chứng

- Hai ảnh người dùng được lưu ở `docs/artifacts/play_reminder_20261022/`.
  Cả hai qua visual sanity với rectangle được đánh dấu từ ảnh; cả hai bị bộ
  nhận diện nút nhận thưởng từ chối. Rectangle ảnh là fixture offline, không
  được dùng làm tọa độ production và không thay thế bằng chứng native live.
- Tests bao gồm native class/owner/getter/signature, Canvas tắt nhưng GO vẫn
  active, Button mơ hồ, tương tác bị khóa, hình/nút sai, layout đang animation,
  deadline, F9, owner combat, exception, lease pin, một click duy nhất, không
  đổi accounting, và đóng modal → router cũ → chọn lại đúng target.
- Regression của entry, kết quả, bú win, room re-entry, native UI, bản đồ và
  ánh xạ UI được chạy cùng bộ mới: **320 test PASS trong 34.518 giây**.
  Kết quả cuối trong `regression_tests.txt` và `verification.json`.
- Đọc 100 probe khi PlayReminder chưa tạo Canvas: median ~0.998 ms, max ~2.005
  ms trên PID 22732, 0 ảnh/input. Đây chỉ là số đo nhánh absent lúc đọc, không
  phải benchmark click modal/farm tổng thể.
- Còn cần một lần quan sát popup thật: native ownership/geometry của **chính
  PlayReminder đang mở**, click, Canvas đóng, rồi farm tiếp/vào lại target.
  Đợt sửa offline ban đầu không điều khiển game. Phiên farm sau đó và phạm vi
  kiểm chứng live được ghi riêng trong báo cáo v1.2.8 ở trên.

Log dùng chung `events.jsonl` với tiền tố `health_reminder_*`; lỗi có
`HEALTH_REMINDER_BLOCKED`, thông tin proof/input/lease bị từ chối và ảnh lỗi
khi đã có frame. Không tạo thêm worker/sink chỉ để ghi log modal.

Source snapshot trước thay đổi, diff, hashes và disassembly nằm trong cùng
thư mục artifact. Planner, BASIC policy, đọc bàn cờ, QTE và executor đi nước
không đổi. Bản EXE/ZIP v1.2.7 đã phát hành được giữ nguyên; v1.2.8 có thư mục riêng.
