# B4: tọa độ click thẻ và dữ liệu dùng thẻ gửi lên server

Ngày kiểm tra: 2026-09-22. Phân tích tĩnh, chỉ đọc, build **1.7.4-b4**.

## Kết luận

**Không thấy ghi/gửi tọa độ pixel của điểm bấm lên thẻ trong các handler và
đường transport đã kiểm tra.** Luồng dùng thẻ gửi danh tính thẻ và mục tiêu:
`cardId`, `cardTarget`, `matchId`, cùng thông tin định danh người gửi.

Cần phân biệt với kim cương: `MATCH_MOVE_REQ` gửi tọa độ **ô bàn chơi**
`fromCol/fromRow/toCol/toRow`, sequence và `clientMonoMs`. Đây không phải
bằng chứng server nhận `(mouseX, mouseY)` hoặc mọi lần click vào viên kim cương.

Với thẻ skill chọn hàng/ô, server có thể nhận hàng/ô đã chọn, kể cả qua
`MATCH_SKILL_HINT` trước khi thi triển. Đó là tọa độ mục tiêu gameplay,
không phải tọa độ click trên ảnh thẻ.

Mức tin cậy **HIGH** cho payload/handler được kiểm tra. Việc server có lưu
request thành lịch sử, thời gian lưu, hay có một đường thu thập dữ liệu khác
ngoài các đường này là **UNKNOWN**. Không coi sự kiện pointer tạm thời phục vụ
UI là bằng chứng client lưu một nhật ký tọa độ click.

## Bằng chứng native

Đọc `D:\pc\GameAssembly.dll`, SHA-256 khớp reverse b4:
`D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`.
Biên hàm, field và symbol từ `reverse/reverse_1.7.4-b4`. Các địa chỉ sau là RVA.

### 1. Bấm nút thẻ truyền đối tượng thẻ

- `CardUI.Start`, RVA `0xA93A00`, đăng ký `<Start>b__207_0()` vào UnityEvent
  ở `0xA940BE`. Callback không nhận `PointerEventData` hoặc tham số x/y.
- Callback RVA `0xABCD40` kiểm tra điều kiện sử dụng và chuyển `CardUI` tới
  `CardPhotonSync.RequestUseCard(CardUI)` tại `0xABD0CD`.
- `RequestUseCard`, RVA `0x28F4D0`, chọn nhánh theo loại thẻ. Nhánh dùng thẻ
  thường gọi `MatchService.SendCardUse` tại `0x28FA3C` với ID lấy từ dữ liệu
  thẻ; nhánh skill đi tới UI/coroutine riêng.
- PVP tương tự: callback RVA `0x97C9F0` tới
  `CardPhotonSyncPVP.RequestUseCard` RVA `0xB01DF0`; lời gọi gửi thẻ ở
  `0xB023C0`. PVP có nhánh xác định actor đối thủ làm mục tiêu.

### 2. Payload dùng thẻ không mang điểm click màn hình

`MatchService.SendCardUse(int cardId, int? cardTarget)`, RVA `0x3D1300`,
chuyển tới `WsMatchClient.SendCardUse(matchId, cardId, cardTarget)`.

Trong b4, thân `WsMatchClient.SendCardUse` RVA `0x423E20` chứa phần dựng
message được inline, tương ứng với `ChatService.SendMatchCardUse` RVA
`0x3B30A0`:

| Dữ liệu | Field DTO | Bằng chứng ghi trong ChatService |
|---|---|---|
| Người gửi | `userId +0x10`, `username +0x18` | Lấy từ ChatService |
| Loại yêu cầu | `type +0x38` | `MATCH_CARD_USE_REQ` |
| Trận | `matchId +0xB8` | Tham số match ID |
| Thẻ | `cardId +0x108` | Lệnh `0x3B3267` |
| Mục tiêu tùy chọn | `cardTarget +0x110` | Lệnh `0x3B326E` |

Gửi qua `SendWebSocketMessage` tại `0x3B3275`; bản inline gửi tại
`0x424035`. Các builder này không điền tọa độ chuột/pixel và không gắn
`clientMonoMs`. Điều đó không loại trừ việc server biết thời điểm nhận request.

`CardDisabledClickHint.OnPointerDown/OnPointerClick` cũng đã được đọc:
kiểm tra trạng thái khóa, lấy lý do không dùng được thẻ, giới hạn nhịp hiện
thông báo, rung UI. Không thấy lưu điểm click hoặc gọi transport trong hai hàm.
Các field `_baseLocalX`/`x` của hiệu ứng là vị trí UI để rung và khôi phục,
không phải payload tọa độ click.

### 3. Skill có dữ liệu mục tiêu riêng

- `CardUI.OnMega1ToggleChanged`, RVA `0xAB3970`, dựng payload có
  `kind`, `row`, `isOn`, gọi `SendSkillHintSafe` tại `0xAB3FC6`.
- `CardUI.OnMega2ToggleChanged`, RVA `0xAB6EC0`, có nhánh dựng payload
  `kind`, `col`, `row`, `isOn`, gọi `SendSkillHintSafe` tại `0xAB7466`
  hoặc `0xAB7918` tùy loại skill.
- `SendSkillHintSafe` có nhánh gửi ngay hoặc giữ hint chờ. `SendSkillHintNow`
  gọi `ChatService.SendMatchSkillHint` tại `0xAB45BD`.
- `SendMatchSkillHint`, RVA `0x3B29E0`, dùng `MATCH_SKILL_HINT` và
  `matchPayload`. Đây là dữ liệu ô/hàng gameplay và trạng thái chọn.
- Payload dùng skill cuối cùng còn có `selectedRows`/`selectedDots` khi loại
  skill cần chúng. Với QTE/Audition, chuỗi hướng được gửi chung khi ra skill,
  không gửi một gói cho từng hướng; V3 có thêm gói timing TAP riêng.

Xem [phân tích QTE/Audition V3](audition_qte_b4_input_transport.md).

### 4. Đối chiếu luồng kim cương

`ChatService.SendMatchMove`, RVA `0x3B2E20`, ghi bốn field `int?`:

- `fromCol +0xE8` ở `0x3B2FFB`;
- `fromRow +0xF0` ở `0x3B3015`;
- `toCol +0xF8` ở `0x3B3038`;
- `toRow +0x100` ở `0x3B305B`.

Sau đó ghi sequence và timestamp đơn điệu, gửi tại `0x3B3081`. Những field
này mô tả nước đổi ô. Không được diễn giải thành log mọi click hoặc vị trí
pixel chính xác trong từng viên kim cương.

## Artifact kiểm chứng

- [17 thân hàm native](../reference/card_click_b4_native.txt).
- [Call/string liên quan](../reference/card_click_b4_calls.txt).
- [Script xuất lại](../reference/card_click_b4_static_audit.py), dùng chung
  exporter b4 có kiểm tra hash với audit QTE.

Không thực thi hàm game, không bắt/gửi/sửa packet, không sửa file hoặc bộ nhớ game.
