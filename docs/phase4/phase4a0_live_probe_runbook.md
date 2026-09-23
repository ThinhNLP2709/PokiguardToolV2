# Phase 4A.0 — Runbook cho Phase 4A.1 Mouse Live Probe

Tài liệu này định nghĩa live probe kế tiếp. **Phase 4A.0 không chạy các bước
này và không gửi input.** Harness được tạo ở 4A.1 phải tuân đúng contract dưới
đây; tên lệnh thực tế sẽ được report 4A.1 ghi lại sau khi implementation tồn
tại.

## 1. Mục tiêu và giới hạn

Kiểm tra tách biệt trên game **Pokiguard 1.7.4-b4**:

1. một background single click;
2. một background two-click SWAP;
3. một background drag SWAP;
4. exact ACK cho từng action;
5. game không foreground trong toàn bộ message sequence và system cursor không
   di chuyển.

Không nối Desktop UI, policy hoặc FarmRunner. Không test QTE, navigation,
covered-window hay minimized. Không auto-retry.

## 2. Điều kiện trước khi bắt đầu

- Phase 4A.0 report là `PASS STRONG` và `STATUS.md` trỏ 4A.1.
- Source/HEAD/upstream được rà lại.
- Game executable/hash khớp profile b4:
  `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`.
- Chỉ có một process/window game hợp lệ.
- Game không minimized, không resize trong probe.
- Client geometry được bind một lần và revalidate trước từng message.
- User điều khiển game/Windows; agent không dùng computer-use.
- Có sẵn phím Emergency Stop và console/harness thể hiện trạng thái `UNARMED`.

## 3. Contract bắt buộc của harness 4A.1

Harness dự kiến có typed commands tương đương:

```text
attach-zero-input
arm-start-single-click
arm-board-two-click
arm-board-drag
stop
```

Tên CLI có thể thay đổi, nhưng không được có arbitrary coordinate/message/key
public command. Mỗi lần chạy mặc định `UNARMED`, chỉ một typed command được arm,
và command tự disarm ngay khi message đầu tiên bắt đầu.

Mỗi action có `probeActionId`, exact pre-state, message ledger và ACK deadline.
`PostMessageW` return chỉ ghi `queued=true/false`; field `accepted` chỉ được set
từ ACK game.

## 4. Cách giữ game background đúng bài

1. Đặt game ở kích thước/position đã bind và để toàn bộ game nhìn thấy.
2. Đặt cửa sổ console/tool nhỏ ở ngoài vùng game hoặc chỉ che vùng không liên
   quan tới control đang probe.
3. Click/focus console/tool để `GetForegroundWindow() != gameHwnd`.
4. Không minimize game và không dùng cửa sổ full-screen che game.
5. Harness ghi foreground HWND trước, giữa mỗi message và sau action.

Nếu game tự lấy lại foreground ở bất cứ lúc nào, action có thể vẫn được ACK
nhưng **không được tính là background accepted**.

## 5. B1 — Zero-input attach

### User chuẩn bị

- Ở exact boss lobby đã chọn đúng pet/boss.
- Đưa console/tool lên foreground theo mục 4.

### Harness làm

- bind exact PID/HWND/title/geometry;
- xác nhận visible, non-iconic, nonforeground;
- đọc owner-free boss lobby và exact target;
- lấy hai stable Start-control proof khi control vẫn nhìn thấy;
- giữ `UNARMED` tối thiểu một bounded observation window;
- ghi cursor position đầu/cuối.

### PASS B1

- zero Windows input;
- zero state mutation do harness;
- exact binding/target/proof ổn định;
- game nonforeground, cursor không đổi.

### Stop

Sai PID/HWND, geometry đổi, minimized, target/room không exact, screenshot bị
che hoặc bất kỳ input nào khi unarmed.

## 6. B2 — Một single click vào Start

Start được chọn vì có native/runtime target identity, stable visual proof và
ACK mạnh là fresh session/opening. Không dùng một tọa độ hard-code.

### Pre-state

- B1 vừa đạt;
- exact same target/room;
- no combat owner;
- stable Start proof còn current;
- game nonforeground và không bị che ở Start control;
- cursor được ghi lại;
- chưa có input B2.

### Input tối đa

```text
WM_MOUSEMOVE(client Start)
WM_LBUTTONDOWN(client Start, MK_LBUTTON)
WM_LBUTTONUP(client Start)
```

Mỗi message ghi timestamp, `wParam`, packed `lParam` và queue result.

### ACK

`ACCEPTED` chỉ khi có distinct current-session combat owner và valid stable
64-cell `MATCH_START` opening cho cùng target. `REJECTED` khi game có explicit
state từ chối/không còn target. Hết deadline mà không có session/opening là
`UNCONFIRMED`.

### Stop

- queue false/partial;
- game foreground;
- cursor đổi;
- binding/target đổi;
- ACK timeout.

Không gửi Start retry trong B2. Retry là một domain riêng và nằm ngoài sample
tối thiểu của 4A.1.

## 7. B3 — Một two-click board SWAP

### User chuẩn bị

- B2 đã tạo fresh active match.
- Chờ harness báo một exact local turn/actionable board.
- Giữ console/tool foreground; game vẫn nhìn thấy và không minimized.

### Harness pre-state

- exact same session, turn, local owner, complete production board;
- timer trên action floor;
- solver proposal hợp lệ và adjacent;
- no modal/stop/recovery/pending action;
- exact client geometry;
- record source board hash, local/last sequence và from/to cells.

### Input tối đa

Hai sequence riêng, mỗi sequence `MOVE/DOWN/UP`. Trước click thứ hai revalidate
binding/session/turn/geometry. Nếu dừng sau click đầu, classify `PARTIAL_INPUT`,
khóa action identity và không retry.

### ACK

`ACCEPTED` chỉ khi exact runtime quy được move sequence + last-move coordinates
về proposal và opponent turn. Bare `_ackedSeqs` advance là
`UNCONFIRMED`, không phải accepted.

### Stop

Một trong hai message sequence fail/partial, state đổi giữa hai click, no exact
ACK, wrong move, focus takeover hoặc cursor movement.

## 8. B4 — Một drag board SWAP

B4 chạy trên **local turn mới**, không tái dùng proposal B3. Nếu B3 làm
lifecycle/session không còn phù hợp, ghi `NOT_RUN`.

### Pre-state

Giống B3 nhưng dùng fresh session-turn-action identity và fresh proposal.

### Input tối đa

```text
MOVE start
DOWN start
ordered MOVE steps with MK_LBUTTON
MOVE overshoot endpoint with MK_LBUTTON
UP last-known point
```

Sau khi DOWN bắt đầu, UP cleanup là bắt buộc kể cả stop/queue failure. Cleanup
không cấp quyền retry hoặc proposal mới.

### ACK

Cùng exact SWAP ACK của B3. Kết quả drag ghi riêng, không gộp với two-click.

### Stop

Sai thứ tự, thiếu held-button flag, queue false, partial sequence, geometry/
session/turn đổi, no exact ACK, unexpected foreground hoặc cursor movement.

## 9. Result classification

Mỗi primitive nhận đúng một trạng thái:

```text
ACCEPTED     authoritative ACK khớp exact action
REJECTED     explicit reject hoặc post-state chứng minh action không hợp lệ
UNCONFIRMED  messages đã queue nhưng không có ACK đủ mạnh
NOT_RUN      precondition không đạt nên zero input
```

`PARTIAL_INPUT` là safety outcome riêng và làm phase fail/remediate; không được
đổi thành `REJECTED` rồi retry.

## 10. Artifacts bắt buộc

```text
probe summary JSON
append-only JSONL message/state ledger
exact source commit + game hash
PID/HWND/title/client geometry
foreground HWND samples
cursor before/after
typed action/pre-state/proposal
per-message queue result
authoritative post-state/ACK + latency
cleanup/no-retry/stop evidence
```

Không cần screenshot khi control/action đã có native identity và visual proof
được lấy trong lúc game nhìn thấy; nếu có capture, ghi rõ game có bị che hay
không. Không dùng screenshot bị che làm proof.

## 11. Gate sau live

`PASS STRONG` của 4A.1 yêu cầu:

- single Start click `ACCEPTED`;
- ít nhất two-click hoặc drag `ACCEPTED`;
- game nonforeground xuyên suốt accepted action;
- system cursor không đổi;
- zero duplicate/wrong/stale/after-stop input;
- zero retry cho unconfirmed/partial;
- kết luận riêng cho two-click và drag.

Nếu two-click accepted nhưng drag không accepted, capability board được ghi
`TWO_CLICK_ONLY`. Nếu cả mouse primitives đều rejected/unconfirmed, route Phase
4 background bị `BLOCKED` trừ khi có hypothesis mới có bằng chứng.
