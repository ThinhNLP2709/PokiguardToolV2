# Phase 4A.0 — Background Input Transport Audit

Ngày audit: **2026-09-23**

Phạm vi: **audit/read-only, không gửi input, không nối production**

Kết quả: **PASS STRONG**

## 1. Kết luận

V2 hiện là một hệ thống **foreground-only có nhiều lớp khóa**. Mouse dùng tọa
độ màn hình và input toàn cục; keyboard QTE dùng `keybd_event`; `FarmRun`,
`FarmCycle`, actionability, Pet Skill và recovery đều chặn khi HWND game không
foreground. Phase 4A.0 không tháo hoặc nới bất kỳ gate nào.

V1 Beta chứng minh được một candidate tối thiểu cho mouse nền:
`WM_MOUSEMOVE -> WM_LBUTTONDOWN -> WM_LBUTTONUP` gửi tới đúng HWND bằng tọa độ
client. V1 không kiểm tra kết quả từng `PostMessageW`, luôn trả `True`, không có
delivery ACK riêng, và vẫn chụp pixel desktop. Vì vậy V1 chỉ là reference cho
message sequence, không phải bằng chứng rằng Unity b4 nhận input nền.

V2 đã có ACK authoritative đủ để live-probe không phải đoán:

- Start/retry: session mới và opening `MATCH_START` 8x8 ổn định;
- lobby card: `ManagerRoom.selectedCards` chứa đúng card;
- SWAP: exact MatchService move sequence, last-move coordinates và opponent
  turn; bare `_ackedSeqs` advance không đủ;
- EVOLVE: `MATCH_FUSION_RES` và/hoặc durable Fusion terminal state;
- CAST: current-session response/card transition và consuming turn; direct
  owner path còn đòi exact Mana-cost delta cùng opponent turn;
- Pet Skill card: QTE generation mới gắn đúng session/CardUI;
- từng hướng: `currentIndex`, `correctCount` và `presses` tăng đúng một;
- Space: cùng QTE generation hoàn tất và runtime result `PERFECT`;
- postmatch/navigation/recovery: lifecycle/room/target/session transition tương
  ứng.

Vì ACK đã xác định, 4A.1 có thể kiểm tra riêng single click, two-click và drag.
Trạng thái hỗ trợ nền vẫn là `UNKNOWN` cho tới live evidence. Cửa sổ minimized
hiện là `UNSUPPORTED`. Route dùng ảnh screen-DC không an toàn khi cửa sổ bị che.

Ma trận đầy đủ ở
[artifacts/phase4a0_capability_matrix.json](artifacts/phase4a0_capability_matrix.json).

## 2. Snapshot và nhãn bằng chứng

```text
Source version: v1.1.0
Source commit: d48e3ecc2c0574758de480e6a2266d48d070ad6d
Upstream:      d48e3ecc2c0574758de480e6a2266d48d070ad6d
Branch:        codex/phase3a2-board-repair
Game build:    Pokiguard 1.7.4-b4
GameAssembly:  D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6
```

Nhãn dùng trong audit:

| Nhãn | Nghĩa |
|---|---|
| `CONFIRMED_FROM_CODE` | Hành vi đọc trực tiếp từ source hiện tại hoặc V1 reference. |
| `CONFIRMED_FROM_REVERSE` | Luồng Unity/native hoặc payload được xác minh từ reverse b4. |
| `CONFIRMED_FROM_PRIOR_LIVE` | Hành vi foreground đã được log/report live trước Phase 4. |
| `INFERRED` | Giả thuyết kỹ thuật có cơ sở nhưng chưa live-prove. |
| `UNKNOWN` | Chưa có đủ bằng chứng; không được xem là supported. |

## 3. Đối chiếu V1 Beta

Nguồn reference-only:
`D:/PokiguardAuto/pokiguard_auto/win32.py:20-23,134-178`,
`D:/PokiguardAuto/pokiguard_auto/engine.py:548,4046,4076`,
`D:/PokiguardAuto/README.md:15`.

### 3.1 Message sequence và tọa độ

V1 đổi normalized point thành client pixel trong `[0,width-1] x
[0,height-1]`, rồi pack:

```text
lParam = (clientY << 16) | (clientX & 0xFFFF)
PostMessageW(hwnd, WM_MOUSEMOVE,   0,          lParam)
PostMessageW(hwnd, WM_LBUTTONDOWN, MK_LBUTTON, lParam)
sleep(0.025)
PostMessageW(hwnd, WM_LBUTTONUP,   0,          lParam)
```

Đây là tọa độ **client**, khác đường foreground dùng screen coordinates.

### 3.2 Return value và ACK

- V1 bỏ qua return của cả ba `PostMessageW`.
- `click(..., mode="background")` trả `True` vô điều kiện sau ba lời gọi.
- Không có ACK giao hàng tại primitive.
- Engine/vision có logic quan sát board về sau, nhưng primitive không gắn queue
  result với một exact action identity như V2.
- `PostMessageW != 0` chỉ có nghĩa message được queue; không chứng minh Unity
  đã sample, gameplay handler đã chạy hoặc server đã chấp nhận.

### 3.3 Capture và covered/minimized

`WindowCapture.grab` dùng MSS trên rectangle màn hình. README V1 ghi rõ Click
nền chỉ thay cách gửi click, game vẫn phải nhìn thấy và Unity có thể không nhận
trên mọi máy. V1 vì vậy không chứng minh covered-window hay minimized.

### 3.4 Test coverage thực tế

`D:/PokiguardAuto/tests/test_win32.py` chỉ kiểm tra foreground click/focus.
`test_ui.py` chỉ kiểm tra giá trị option. Không có test cho message order,
`lParam`, failure return, partial sequence, ACK hoặc no-retry của background.

## 4. V2 transport hiện tại

### 4.1 Mouse foreground

`ForegroundClickExecutor` ở
`src/pokiguard_v2/win32_input.py:423-784`:

- single click: `_send_one` kiểm tra PID, geometry, foreground, gọi
  `SetCursorPos(screenX, screenY)`, kiểm tra foreground lần nữa rồi
  `mouse_event(LEFTDOWN/LEFTUP)`;
- two-click: gọi `_send_one` hai lần với delay bounded/adaptive;
- drag: đưa cursor tới ô đầu, `LEFTDOWN`, di chuyển theo thứ tự tới điểm
  overshoot và luôn `LEFTUP` trong `finally`;
- mỗi bước drag kiểm tra lại PID/HWND, geometry và foreground;
- normalized UI point được đổi sang cả client và screen point, nhưng đường gửi
  hiện tại dùng screen point.

Native primitives nằm tại `win32_input.py:886-1044`. `client_geometry` từ chối
window invisible hoặc `IsIconic`; mouse dùng `SetCursorPos` và `mouse_event`.

### 4.2 Keyboard foreground

- direction executor: `qte_direction_assist.py:83-118`;
- Space executor: `pet_skill_action.py:119-143`;
- native key primitive: `win32_input.py:1013-1044`.

Cả hai executor kiểm tra exact PID/HWND/geometry/foreground. Backend dùng
`keybd_event` với hold 40 ms. Prior live cho thấy foreground `SendInput` báo đã
gửi nhưng không tăng QTE index; legacy `keybd_event` tăng đúng state. Acceptance
vẫn đến từ RAM QTE, không từ return của API Windows.

### 4.3 Screenshot hiện tại

`capture_client_rgb` tại `win32_screenshot.py:263-359` gọi `GetDC(0)` và
`BitBlt` rectangle ở tọa độ desktop. Đây là **visible screen capture**, không
phải offscreen window capture. Nếu game bị che, pixel là nội dung đang che; nếu
minimized, window discovery/geometry hiện tại cũng không hợp lệ.

## 5. Inventory permit và foreground gate

Production enum đầy đủ nằm tại `farm_run.py:135-152`. Tất cả physical domains
đều đi qua một capability/permit; `GAMEPLAY_PASS` là zero-input.

| Domain | Permit/gate chính | Foreground gate hiện tại |
|---|---|---|
| `BOSS_ROOM_SHELL_EXIT` | `FarmRun.reserve_room_shell_exit` | `farm_run.py:1731-1772` |
| `BOSS_ROOM_SHELL_CONFIRM` | `reserve_room_shell_confirm` | `farm_run.py:1793-1841` |
| `BOSS_HUB_CHINH_PHUC_OPEN` | `reserve_hub_chinh_phuc_open` | `farm_run.py:1660-1710` |
| `BOSS_TARGET_SELECT` | `reserve_target_select` | `farm_run.py:1574-1639` |
| `BOSS_CARD_SELECT` | `reserve_lobby_card_select` | `farm_run.py:872-929` |
| `BOSS_ENTRY` | `reserve_entry` | `farm_run.py:834-870` |
| `BOSS_ENTRY_RETRY` | `reserve_entry_retry` | `farm_run.py:964-1035` |
| `GAMEPLAY_SWAP` | `reserve_gameplay` | `farm_run.py:1166-1209` |
| `GAMEPLAY_CAST` | `reserve_gameplay` | cùng gate gameplay |
| `GAMEPLAY_PET_SKILL` | `reserve_gameplay` + Pet Skill executor | gate gameplay và `pet_skill_action.py:1101-1128,1161-1184` |
| `GAMEPLAY_EVOLVE` | `reserve_gameplay` | cùng gate gameplay |
| `GAMEPLAY_PASS` | `reserve_gameplay` | foreground vẫn là precondition hiện tại; `complete_gameplay` cấm Windows input tại `1211-1228` |
| `POSTMATCH_CONFIRM` | `reserve_postmatch` | `farm_run.py:1538-1559` |
| `RECOVERY_EXIT` | recovery coordinator | `technical_recovery.py:549-564` |
| `RECOVERY_CONFIRM` | recovery coordinator | `technical_recovery.py:566-584` |
| `RECOVERY_TARGET_SELECT` | recovery coordinator | `technical_recovery.py:586-596` |
| `RECOVERY_REENTRY` | recovery coordinator | `technical_recovery.py:598-624` |

`FarmCycle` có ledger song song/legacy cho entry, gameplay và postmatch tại
`farm_cycle.py:239-275,336-374,436-471`; các reserve này cũng đòi foreground.
`ActionabilityGate.evaluate` chặn `GAME_NOT_FOREGROUND` tại
`actionability.py:281-288`. Phase production về sau phải thay foreground bool
bằng delivery authority theo từng domain; không được bỏ đồng loạt các gate.

## 6. Inventory action, ACK và visual dependency

| Action/gesture | Pre-state bắt buộc | ACK authoritative | Visual dependency hiện tại | Background state |
|---|---|---|---|---|
| Board two-click | exact session/turn/board/proposal, actionable, timer, geometry | exact move sequence + last-move cells + opponent turn; reject response là reject | modal sanity capture trước SWAP (`basic_auto_bot.py:8738-8754`) | `UNKNOWN` |
| Board drag | như two-click; endpoint/Board bounds | cùng ACK SWAP, độc lập gesture | cùng modal sanity capture | `UNKNOWN` |
| Generic single UI click | exact HWND/PID/geometry và typed target | domain-specific transition | thường có locator | `UNKNOWN` |
| Start | exact target room/pet, owner-free, stable Start | fresh distinct combat session + valid stable 64-cell opening | two-frame Start proof (`boss_entry.py:_capture_proof`) | `UNKNOWN` |
| Start retry | first Start sent exactly once, no session, same target/button | cùng session/opening ACK; chỉ một retry | stable same-button proof | `UNKNOWN` |
| Lobby Attack-card selection | unique current room card, selected missing | exact card xuất hiện trong `ManagerRoom.selectedCards` | two-frame toggle proof | `UNKNOWN` |
| EVOLVE | current Fusion authority/slot/resources | `MATCH_FUSION_RES` hoặc durable `used/locked/lastAttemptTurn` terminal state | gameplay-control locator | `UNKNOWN` |
| Default CAST | exact current card/slot/resources | response/card-used state + consuming turn; direct path requires exact Mana delta + opponent turn | gameplay-control locator | `UNKNOWN` |
| Pet Skill card | exact session/CardUI/Button/card/resources + inactive-QTE baseline | fresh bound QTE generation for same CardUI | runtime slot geometry; click uses normalized point | `UNKNOWN` |
| Result confirm | authoritative POSTMATCH + stable result identity | exact boss-lobby/return lifecycle | 3 stable visible frames (`farm_run.py:787-938`) | `UNKNOWN` |
| Room exit/confirm | detached shell/leave modal identity | modal transition, then owner-free map/hub state | screen-DC locators | `UNKNOWN` |
| Hub/map/island/boss re-entry | immutable pet ID -> group/pet, exact runtime branch | exact target room/pet/lobby, then fresh session/opening after Start | hub button, hunt badge, room control captures | `UNKNOWN` |
| QTE direction | exact session/generation/sequence/index/correct/presses | index +1, correct +1, one exact appended press (`qte_direction_assist.py:563-687`) | no screenshot in critical control poll | `UNKNOWN` |
| QTE Space | all directions ACKed; same generation inside Perfect window | same generation completed + runtime `PERFECT` (`pet_skill_action.py:780-904`) | no screenshot in critical poll | `UNKNOWN` |
| Technical recovery | exact failed session, locked gameplay, locator proof | exit modal, clean lobby/ACK epoch, exact target, distinct session/opening | Exit/Confirm/target visual locators | `UNKNOWN` |
| PASS | authoritative game-owned idle state and policy budget | AFK/pass payload and later turn/reset semantics | none for Windows input; sends zero input | không phải transport nền |

### 6.1 SWAP ACK chi tiết

`basic_auto_bot.py:3896-3959` chỉ nhận SWAP khi direct runtime khớp exact
session/sequence/last-move coordinates và chuyển sang opponent turn. Tại
`6500-6530`, ACK sequence tăng nhưng không quy được về nước hiện tại được ghi
`SEQUENCE_ADVANCED_UNATTRIBUTED`, vẫn `accepted=False`. Đây là ACK đúng cho cả
two-click và drag trong 4A.1.

### 6.2 Card và evolution ACK chi tiết

`basic_auto_bot.py:1396-1436` phân loại EVOLVE từ response/durable state.
`6403-6414` đọc `MATCH_FUSION_RES`, `MATCH_CARD_USE_RES` và
`MATCH_SKILL_USE_RES`. CAST chỉ hoàn tất khi có post-state tương ứng tại
`6568-6633`; queue/click success không đủ.

### 6.3 QTE ACK chi tiết

Direction send tại `qte_direction_assist.py:489-561`; controller không gửi
hướng kế tiếp cho tới khi exact progress tại `563-633`. Unchanged tới timeout
trở thành `INPUT_SENT_UNCONFIRMED` và không retry (`635-659`).

Space chỉ gửi một lần tại `pet_skill_action.py:794-826`; current generation
runtime `PERFECT` hoàn tất action tại `828-898`. Timeout trở thành
`SPACE_SENT_RUNTIME_COMPLETION_UNCONFIRMED_NO_RETRY`.

## 7. Reverse b4 liên quan transport

### 7.1 Board

Reverse hiện hành xác nhận `Dot.OnMouseDown/OnMouseUp`,
`firstTouchPosition/finalTouchPosition`, `IsValidSwipe`, `CalculateAngle` và
`MovePieces`. Drag hợp lệ phụ thuộc displacement qua `swipeResit`; elapsed drag
không nằm trong điều kiện native đã đọc. Prior live chỉ xác nhận quick foreground
flick hiện tại, chưa xác nhận posted mouse messages.

### 7.2 Card

[card_click_b4_transport.md](../card_click_b4_transport.md) xác nhận
`CardUI.Start` đăng ký UnityEvent callback không nhận `PointerEventData` hay
tọa độ. Request gửi `cardId/cardTarget/matchId`, không gửi pixel click. Điều này
giúp chọn ACK/state, nhưng không chứng minh callback nhận `PostMessage` khi nền.

### 7.3 QTE

[audition_qte_b4_input_transport.md](../audition_qte_b4_input_transport.md) và
[pokiguard_pet_skill_qte_reverse_report.md](../pokiguard_pet_skill_qte_reverse_report.md)
xác nhận direction được đọc bằng legacy `UnityEngine.Input.GetKeyDown`; chuỗi
hướng được giữ ở client rồi gửi trong skill-use. Audition V3 còn gửi timing TAP
khi confirm. Đây là lý do background keyboard phải live-test riêng; posted
`WM_KEYDOWN` có thể không làm Unity keyboard state thay đổi.

## 8. Background transport candidates

Các candidate dưới đây chỉ dành cho harness 4A.1/4A.2. Chúng chưa được phép ở
production.

### 8.1 Single click

```text
validate exact HWND/PID + visible/non-iconic + unchanged client geometry
client (x,y) -> lParam = LOWORD(x) | HIWORD(y)
PostMessageW(hwnd, WM_MOUSEMOVE,   0,          lParam)
PostMessageW(hwnd, WM_LBUTTONDOWN, MK_LBUTTON, lParam)
bounded hold
PostMessageW(hwnd, WM_LBUTTONUP,   0,          lParam)
wait only for domain ACK; never retry unconfirmed
```

Hypothesis `H-MOUSE-SINGLE`: Unity b4 dispatches the target UI Button while the
game is nonforeground but not minimized. Acceptance requires target post-state,
not API return. Stop on any false PostMessage, changed HWND/PID/geometry,
unexpected focus, timeout or ambiguous state.

### 8.2 Two-click board swap

Hai bounded single-click sequence, mỗi sequence có Move/Down/Up. Revalidate
HWND/PID/geometry/session/turn trước click thứ nhất và thứ hai. Không có ACK sau
click thứ nhất; nếu dừng hoặc click thứ hai fail, classify `PARTIAL_INPUT`, khóa
action identity và không retry.

Hypothesis `H-MOUSE-TWO-CLICK`: two tap-selection callbacks tạo đúng một SWAP
khi game background. Acceptance chỉ bằng exact SWAP ACK ở mục 6.1.

### 8.3 Drag

```text
MOVE(start, wParam=0)
DOWN(start, wParam=MK_LBUTTON)
MOVE(p1..pn, wParam=MK_LBUTTON, ordered)
MOVE(overshootEnd, wParam=MK_LBUTTON)
UP(lastKnownPoint, wParam=0)  # unconditional once DOWN was attempted
```

Mỗi message dùng client coordinates. Nếu stop/failure xảy ra sau DOWN, gửi đúng
một cleanup UP rồi classify partial/unconfirmed; không gửi proposal khác.

Hypothesis `H-MOUSE-DRAG`: posted ordered held-button moves làm
`Dot.OnMouseDown/OnMouseUp` thấy displacement qua threshold. Acceptance dùng
cùng exact SWAP ACK, nhưng kết quả được ghi riêng với two-click.

### 8.4 Direction và Space

Candidate duy nhất đáng kiểm tra đầu tiên là targeted
`WM_KEYDOWN/WM_KEYUP` với VK/scan bits đúng, exact HWND và một typed vocabulary
(`Left/Right/Up/Down`, `Space`). Không gửi `WM_CHAR`, không expose arbitrary key,
không dùng return queue làm ACK.

Hypothesis `H-QTE-DIRECTION`: posted key pair làm exact RAM index/correct/presses
tăng một. Stop ngay nếu unchanged timeout, jump, mismatch hoặc focus đổi; không
gửi hướng kế tiếp.

Hypothesis `H-QTE-SPACE`: posted Space làm same generation hoàn tất và runtime
`PERFECT`. Stop/no-retry nếu result không xác nhận. Do Unity dùng
`Input.GetKeyDown`, cả hai hypothesis hiện vẫn `UNKNOWN`; nếu bị reject, branch
hợp lệ là foreground QTE handoff.

## 9. Covered và minimized

| Trường hợp | Kết luận 4A.0 | Lý do |
|---|---|---|
| Game nonforeground, vẫn nhìn thấy | mouse/QTE `UNKNOWN` | chưa live-probe delivery nền |
| Game bị cửa sổ khác che | production route `UNSUPPORTED/UNKNOWN` theo domain | screen-DC captures nhìn thấy occluder; board memory tự thân không sửa được UI/modal proof |
| Active combat chỉ dùng memory | nền tảng đọc phù hợp, nhưng production chưa supported | actionability + permit + executor vẫn chặn foreground; SWAP còn có modal capture |
| Minimized | `UNSUPPORTED` | `NativeWin32Backend.client_geometry` trả `None` khi `IsIconic` |

Không được quảng bá `covered-window combat` chỉ vì board đọc từ memory. Cần đóng
visual/modal dependency hoặc một foreground navigation contract ở phase sau.

## 10. Fail-closed và logging contract cho live probe

Mỗi command 4A.1 phải ghi:

```text
probe/action id; game build hash; PID/HWND/title;
initial/current client geometry; IsIconic/visible; foreground HWND before/during/after;
typed domain + gesture; exact client coordinates; every message/wParam/lParam;
monotonic send timestamp + Win32 queue result;
pre-state session/turn/owner/sequence/board hash/target identity;
expected ACK kind and deadline;
post-state samples; ACK latency; accepted/rejected/unconfirmed/partial;
cursor before/after; cleanup UP; stop state; retryCount=0.
```

Stop rules chung:

1. zero input khi chưa arm;
2. reject wrong PID/HWND, resize, invisible, minimized, stale session/turn/target;
3. Emergency Stop/shutdown chặn message mới;
4. sau DOWN chỉ cho phép cleanup UP;
5. queue false hoặc partial sequence không được retry;
6. queue true nhưng không có ACK là `UNCONFIRMED`, không phải accepted;
7. unexpected foreground takeover hoặc system cursor movement là failure của
   background claim;
8. mỗi live action dùng một fresh identity và tối đa một attempt.

## 11. UNKNOWN giữ nguyên

- Unity b4 có dispatch posted mouse message khi background hay không;
- two-click và drag có thể khác kết quả nhau;
- posted arrow/Space có làm `Input.GetKeyDown` thay đổi hay không;
- offscreen/covered screenshot replacement nào đủ tin cậy cho navigation;
- minimized Unity có render/tick/input hay không; chưa được phép test trong A.1;
- `PostMessageW` timing/hold tối ưu; harness phải bounded, không tuning bằng
  retry mù.

## 12. PASS STRONG checklist

- [x] Inventory đủ mọi `FarmInputDomain`, recovery domain, two-click/drag và
  direction/Space.
- [x] Permit, foreground gate, primitive và coordinate space được ghi rõ.
- [x] ACK authoritative cho mọi action dự định live-test đã xác định.
- [x] Two-click và drag có hypothesis/stop rule riêng.
- [x] QTE direction và Space tách riêng.
- [x] Visual screen-DC, covered và minimized được chốt rõ.
- [x] V1 return handling, ACK, capture và test gap được đối chiếu.
- [x] Không gửi input, không sửa production, không dùng direct game/network
  method.
- [x] Runbook bounded đã tạo.
- [x] Machine-readable matrix có evidence source cho từng capability.

Router result: **Phase 4A.0 PASS STRONG → Phase 4A.1**.
