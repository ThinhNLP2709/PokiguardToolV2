# Phase 4A.1-R1 — Nghiên cứu hướng khác sau PostMessageW

## Kết luận

Không còn candidate Win32 public API nào có bằng chứng đủ mạnh để gửi mouse
input vào **Unity window đang không foreground trên cùng interactive desktop**.
Thử `PostMessageW` thêm biến thể chỉ thay đổi cách message tới WindowProc, trong
khi live evidence cho thấy Unity `EventSystem` không tạo pointer action từ các
message đó.

Hướng phù hợp nhất với mục tiêu thực tế “tool farm trong khi người dùng vẫn dùng
máy” là chạy game + V2 foreground trong **một môi trường tách biệt**: máy ảo hoặc
máy thứ hai. Với cách này, game vẫn foreground trong guest/remote machine, còn
desktop host của người dùng không bị tool chiếm chuột/focus.

Một bounded foreground handoff trên cùng desktop cũng khả thi về kỹ thuật vì V2
đã có đường foreground accepted, nhưng nó sẽ giành focus ở mỗi lượt nên không
đạt ý nghĩa background mà người dùng đang cần.

## Bằng chứng gốc

- B2 chính thức và một lần lặp do người dùng yêu cầu đều queue đủ
  `MOVE/DOWN/UP`, giữ DOWN 31 ms, nhưng không vào trận và không có opening ACK.
- B3 two-click queue đủ sáu message nhưng turn/local sequence/last-move không
  đổi.
- B4 held drag queue đủ bảy message gồm unconditional UP cleanup nhưng
  turn/local sequence/last-move không đổi.
- Cửa sổ game là `UnityWndClass`. Read-only UI Automation inspection tại live
  HWND `1840700` chỉ thấy root `ControlType.Window` và **0 descendants**.
- Reverse b4 xác nhận `ManagerRoom.ButtonStart` là `UnityEngine.UI.Button`,
  không phải Win32 child button.
- Unity mô tả `StandaloneInputModule` là module lấy trạng thái mouse/input rồi
  tạo pointer press/drag/click qua `EventSystem` và raycaster.

Nguồn chính thức:

- [Microsoft PostMessageW](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagew)
- [Microsoft SendMessageTimeoutW](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagetimeoutw)
- [Microsoft SendInput](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput)
- [Microsoft SetForegroundWindow](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setforegroundwindow)
- [Microsoft Desktops](https://learn.microsoft.com/en-us/windows/win32/winstation/desktops)
- [Unity Standalone Input Module](https://docs.unity3d.com/2018.3/Documentation/Manual/script-StandaloneInputModule.html)

## Đánh giá candidate

| Candidate | Kết luận | Lý do |
|---|---|---|
| `PostMessageW` thêm timing/message | Loại | hai B2 + B3 + B4 không ACK; queue success không tạo Unity input state |
| `SendMessage`/`SendMessageTimeout` | Không đáng live probe | đồng bộ WindowProc nhưng vẫn là cùng message path; không chèn mouse event vào system input stream |
| `PostThreadMessage` | Loại | còn yếu hơn vì không target một HWND/UI control cụ thể |
| `WM_COMMAND`/`BM_CLICK` | Loại | Start là Unity `Button`, không có native child HWND |
| UI Automation Invoke | Loại trên build/máy hiện tại | live UIA tree có 0 descendants dưới Unity root |
| `SetActiveWindow` không foreground | Loại | API không biến background application thành active foreground target |
| `SendInput`/`mouse_event` khi game background | Không phải targeted background | chèn vào global input stream; cửa sổ foreground nhận input |
| `AttachThreadInput` + activate/focus | Foreground handoff trá hình | vẫn đổi active/foreground ownership và có thể làm gián đoạn người dùng |
| hidden alternate Windows desktop | Không đáp ứng mục tiêu | chỉ active input desktop nhận user input; switch desktop thay desktop người dùng |
| multi-monitor | Không giải quyết | foreground window là trạng thái toàn desktop, không tách theo monitor |
| virtual HID/gamepad | Chưa có evidence và không phù hợp board | không có verified controller path cho board/UI; input vẫn thuộc system/foreground route |
| direct Unity callback/method | Ngoài biên dự án | cần injection/hook/direct game method |
| direct match/network request | Ngoài biên dự án | vi phạm read-only/normal-input boundary |

`SendMessageTimeout` chỉ chờ WindowProc xử lý message; nó không biến message
thành hardware/system input. Đây là suy luận từ contract Win32, Unity input flow
và live evidence, không phải một live rejection riêng.

## Hai hướng còn khả thi

### 1. Isolated foreground runtime — khuyến nghị

Chạy game và bản V2 foreground hiện tại trong VM hoặc máy thứ hai:

- guest có desktop/input stream riêng;
- game vẫn là foreground window bên trong guest;
- memory reader, screenshot và normal input giữ đúng kiến trúc đã accepted;
- người dùng tiếp tục dùng host mà không bị đổi focus/cursor.

Đây là environment isolation, không được đặt tên là background input transport.
UI/config bên trong guest vẫn dùng `FOREGROUND`.

Probe nhỏ nhất nếu chọn hướng này:

1. cài/copy package và game vào guest hoặc máy thứ hai;
2. xác minh process read-only attach và canonical geometry;
3. chạy một trận foreground trong guest trong lúc người dùng thao tác host;
4. nếu đạt, chạy 5 trận gồm board, card, QTE và postmatch/re-entry;
5. PASS khi guest đạt đúng ACK/result và host không bị focus/cursor takeover.

Host hiện báo `HypervisorPresent=True`, nhưng không tìm thấy `VBoxManage`,
`vmrun` hoặc `vmconnect`; trạng thái feature Windows cần quyền cao hơn để đọc.
Vì vậy môi trường VM chưa được coi là sẵn sàng.

### 2. Bounded foreground lease — phương án phụ

Nếu người dùng chấp nhận game bật lên rất ngắn ở mỗi action:

- lưu exact foreground HWND và cursor của người dùng;
- lấy foreground cho exact game HWND;
- gửi đúng một existing foreground action;
- chờ authoritative ACK;
- phục hồi cursor và foreground HWND cũ;
- dừng nếu user input/focus thay đổi trong lease.

V2 đã có `restore_and_foreground`, foreground executors và ACK nên hướng này ít
rủi ro triển khai hơn. Tuy nhiên board cần action thường xuyên; việc đổi focus có
thể cắt ngang gõ phím/click của người dùng. Nó không nên được quảng bá là
background và không phải lựa chọn khuyến nghị cho farm dài.

## Router đề xuất

- true same-desktop background: giữ `BLOCKED`;
- không chạy 4A.2 và không thử thêm posted mouse message;
- nếu mục tiêu ưu tiên là không ảnh hưởng desktop host: tạo phase riêng để
  validate `ISOLATED_FOREGROUND_RUNTIME` sau khi có VM/máy thứ hai;
- nếu người dùng chấp nhận focus interruption: tạo remediation riêng cho
  `BOUNDED_FOREGROUND_LEASE`, không đổi tên thành background.
