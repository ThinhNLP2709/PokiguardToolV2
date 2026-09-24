# Phase 4A.1-R2 — Pinned Foreground Lease Report

## Kết quả hiện tại

```text
RESULT: PASS STRONG — LIVE B1/B2/B3 ACCEPTED
PRODUCTION INTEGRATION: NO
```

## Thiết kế đã triển khai

`tools/foreground_lease_transport.py` cung cấp:

- `PinnedWindowSession`: ghim/gỡ đúng HWND bằng topmost không kích hoạt;
- `BoundedForegroundLease`: một arm, một foreground takeover, một typed action;
- kiểm tra exact PID/title/client geometry trước arm, sau idle và sau focus;
- user-idle guard bằng `GetLastInputInfo` và trạng thái phím/nút chuột;
- trả focus/cursor có điều kiện;
- tôn trọng focus/cursor mới nếu user take over;
- event telemetry cho pin, arm, action và release.

`tools/foreground_lease_probe.py` triển khai B1 zero-input và B2 single Start
click, dùng `ForegroundClickExecutor` hiện có và read-only opening ACK. Probe
không được nối vào FarmRunner.

## Safety đã prove offline

- Unarmed/consumed/stale/busy/focus-denied/window-changed đều không gọi action.
- Action exception vẫn chạy release.
- Focus user chọn trong lúc lease không bị ghi đè.
- Cursor user di chuyển trong lúc lease không bị snap về.
- Pin lifecycle không làm đổi foreground trong fake backend.
- Một lease thành công gọi action đúng một lần.

## Verification

```text
python -m unittest tests.test_foreground_lease_transport \
  tests.test_foreground_lease_board_probe \
  tests.test_foreground_lease_probe -q
42 tests PASS

python -m compileall -q tools/foreground_lease_transport.py \
  tools/foreground_lease_probe.py tools/foreground_lease_board_probe.py \
  tests/test_foreground_lease_transport.py
PASS

python -m unittest discover -s tests -p "test_*.py" -q
1445 tests PASS
```

## Giới hạn đã biết

- Topmost chỉ giữ game nhìn thấy; action vẫn chiếm foreground/chuột thật.
- Windows có thể từ chối `SetForegroundWindow`; trường hợp đó zero action.
- Không thể loại bỏ hoàn toàn va chạm nếu user bắt đầu input đúng lúc action đã
  chạy; lease phát hiện sau action và không cưỡng ép restore.
- Bản đầu giữ nguyên kích thước game để bảo toàn calibration.

## Gate tiếp theo

Chạy B1 rồi B2 theo runbook. Chỉ sau authoritative B2 ACK mới tạo B3 để prove
một board swap trong lease. Chưa thay đổi capability matrix production.

## Live B1 attempt 1

Artifact: `logs/phase4a1_r2/b1_live_20260924`.

- Exact PID `6412`, HWND `1840700`, client `1280x640`.
- `TOPMOST` được đặt và gỡ thành công; game luôn nonforeground.
- Boss `1289`/Starburst và nút Bắt đầu được prove ở confidence `0.95078125`.
- Zero click/keyboard; B1 bị harness đánh fail vì cursor do user di chuyển.

Điều kiện cursor bất biến thuộc probe background cũ và mâu thuẫn với mục tiêu
cho phép user dùng chuột khi game được ghim. Harness đã sửa để xác nhận trực
tiếp số lời gọi foreground/cursor API bằng 0 trong B1; cursor do user thay đổi
chỉ được ghi telemetry, không còn làm fail.

## Live B1 retry

Artifact: `logs/phase4a1_r2/b1_retry_20260924`.

```text
RESULT: ACCEPTED
PID/HWND: 6412 / 1840700
Client: left=602, top=157, 1280x640
Boss: 1289 / Starburst
Start confidence: 0.95078125
Game foreground during proof: false
Topmost during proof: true
Foreground requests from probe: 0
Cursor-set requests from probe: 0
Start clicks: 0
Unpin: UNPINNED
```

B1 đã đóng. B2 single Start-click vẫn `PENDING` và cần operator arm riêng.

## Live B2 attempt 1

Artifact: `logs/phase4a1_r2/b2_live_20260924`.

```text
RESULT: UNCONFIRMED
Typed click result: SENT
Authoritative opening ACK: false
Lease duration: 0.407 s
Cursor restore: true
Focus restore: false (foreground became transient NULL)
Automatic retry: false
```

User quan sát đúng cửa sổ được ghim nhưng game không vào trận và đánh giá click
quá nhanh. Tọa độ `(1381,676)` khớp Start point đã prove; không có bằng chứng
click nhầm. Remediation cho retry tăng focus settle từ `0,08 s` lên `0,40 s`,
tăng cursor hover settle từ `0,06 s` lên `0,25 s`, thêm timestamp cho acquire /
action begin / action end, và chờ bounded focus-release ACK thay vì kiểm tra tức
thời. B2 vẫn pending; không tự retry.

## Live B2 retry 1

Artifact: `logs/phase4a1_r2/b2_retry_20260924`.

```text
RESULT: NOT_RUN
B1: ACCEPTED
Focus acquisition: FAILED
Typed action attempted: false
Start clicks: 0
Automatic retry: false
```

Windows giữ foreground ở HWND `590324` và từ chối direct
`SetForegroundWindow`; vì vậy nhịp click chậm chưa được thực thi hoặc đánh giá.
Harness đã thêm bounded fallback `AttachThreadInput`: chỉ khi direct request
fail, probe tạm nối input queue của thread hiện tại với foreground/target
thread, foreground đúng HWND rồi detach trong `finally`. Telemetry ghi riêng số
attempt/success của fallback. Không có game injection hoặc memory write.

## Live B2 retry 2 — accepted sau evidence review

Artifact: `logs/phase4a1_r2/b2_retry2_20260924`.
Machine-readable review: `post_review.json` trong cùng thư mục.

```text
RESULT: ACCEPTED
Lease: COMPLETE
Focus acquire: direct; bridge attempts 0
Foreground settle: 0.40 s
Cursor hover settle: 0.25 s
Lease duration: 0.984 s
Typed click: SENT exactly once
Focus restore: true
Cursor restore: true
Fresh match: M_1cad5711
Board instance: 1817336670848
Fresh ACTIVE lifecycle confirmations: 71
Operator observed game entry: true
Automatic retry: false
```

Summary ban đầu ghi `UNCONFIRMED` vì gate cũ chỉ chấp nhận full
`MATCH_START` DTO. Log lại chứng minh chuỗi nhân quả sau click: lobby không có
session → server match ID mới → scene loading → local rig/board ownership khớp,
`board_ready=true`, session key mới. `CombatLifecycleState.ACTIVE` vốn là
classifier fail-closed và đòi toàn bộ bằng chứng local ownership; hai mẫu liên
tiếp đủ làm ACK cho thao tác vào trận. Probe đã cập nhật để chấp nhận exact DTO
hoặc hai fresh ACTIVE lifecycle samples.

B1 và B2 đã pass. Production vẫn chưa thay đổi; return gate tiếp theo là B3
exact one-swap lease với turn/sequence/last-move ACK.

## Live B3 attempt 1 — zero input, stale proposal

Artifact: `logs/phase4a1_r2/b3_live_20260924`.

```text
RESULT: NOT_RUN
Foreground-lease swaps: 0
First actionable proposal: turn 3, 13 s remaining
Proposed swap: (1,1) -> (2,1), safe rage match
Idle wait: 6.219 s
Lease: STALE_ACTION
Topmost release: UNPINNED
Automatic retry: false
```

Đây không phải quyết định bỏ lượt của solver và probe không phát input. Trước
proposal, turn 2 còn `BOARD_NOT_MOVE_STATE`; sang turn 3 game còn presentation
busy/FX pause. Khi state lần đầu actionable, lease đã có nước hợp lệ nhưng
user-idle guard liên tục bị reset trong lúc user sử dụng chuột. Sau 6,219 giây,
preflight phát hiện proposal đã cũ và hủy đúng fail-closed.

Guard cũ không phù hợp mục tiêu đã thống nhất là tool được tạm chiếm chuột lúc
cần đi. B3 retry dùng courtesy window mới: nhường input tối đa 0,75 giây; sau
đó được lấy foreground nếu không có phím hoặc nút chuột nào đang được giữ.
Trạng thái cửa sổ, turn và proposal vẫn được kiểm tra lại trước và sau khi lấy
focus. Nếu user đang giữ input thì tuyệt đối không gửi swap. Hai nhánh này đã
được kiểm thử riêng.

Sau attempt, `finally` đã ghi `UNPINNED`. Kiểm tra Win32 trực tiếp sau phản hồi
của operator cũng xác nhận exact HWND có `TOPMOST=false`; lệnh gỡ ghim cưỡng
bức giữ kết quả `false` và không gửi input.

B3 retry vẫn pending. Production chưa thay đổi.

## Live B3 retry 2 — held-input guard quá rộng

Artifact: `logs/phase4a1_r2/b3_retry2_20260924`.

```text
RESULT: NOT_RUN
Foreground-lease swaps: 0
Proposal: turn 3, 13 s remaining, (3,5) -> (3,6)
Courtesy wait: 0.75 s
Focus acquire/restore: true / true
Lease: USER_TAKEOVER_DURING_ACTION
Topmost release: UNPINNED
```

Courtesy timeout hoạt động đúng và lấy focus sau 0,75 giây, nhưng guard cũ dò
toàn bộ virtual-key range nên một phím hoặc nút đang giữ làm hủy trước swap.
Điều này vẫn chưa đúng UX đã chốt: game phải luôn được ghim nhìn thấy, còn tool
chỉ tạm chiếm focus/chuột khi cần đi.

Remediation tiếp theo cho mouse lease:

- không yêu cầu operator tự đưa game xuống nền;
- chấp nhận cả game đang active lẫn focus đang ở ứng dụng khác;
- bàn phím đang được dùng không làm hủy mouse action;
- chỉ chặn khi một nút chuột vật lý đang được giữ, tránh biến two-click thành
  drag hoặc mixed-button gesture;
- khi focus vốn ở ứng dụng khác, vẫn trả lại sau action;
- không tự retry và giữ exact preflight trước input.

Hai attempt B3 đến đây đều phát zero swap. B3 retry mới vẫn pending.

## Live B3 retry 4 — transport nhận, policy lượt đầu fail

Artifact: `logs/phase4a1_r2/b3_retry4_20260924`.

```text
RESULT: POLICY FAIL / TRANSPORT ACCEPTED
Foreground-lease swaps: 1
Proposal: screen (6,4) -> (6,5), turn 3
Typed clicks: 2
Inter-click delay: 0.573 s
Local move sequence: 0 -> 1
Runtime last move: (row 1,col 4) -> (row 1,col 5)
Focus restore: true
Cursor restore: true
Topmost release: UNPINNED
```

Runtime row dùng trục ngược với screen row, nên `screen row 6 == runtime row 1`.
Hai cột và sequence đều khớp; game đã nhận nước. Gate cũ đánh
`UNCONFIRMED` vì kiểm tra ngay sau sequence tăng, trước khi turn đổi sang boss,
rồi coi sequence tăng là reject thay vì pending transition.

Kết quả vẫn không đạt B3 vì tool bỏ lượt local đầu và chỉ đi lượt local thứ hai.
Nguyên nhân chính xác nằm trong `_wait_board_proposal`: nhánh dùng lại từ
PostMessage probe bỏ qua toàn bộ polling khi game đang foreground. Điều kiện đó
mâu thuẫn với pinned foreground lease.

Remediation:

- foreground lease poll board cả khi game đang active;
- ACK giữ exact inverted-row coordinate check nhưng chờ transition hoàn tất;
- focus acquire retry tối đa ba lần trong cùng bounded lease;
- action gọi nguyên executor/solver cũ, không tạo route chơi mới;
- ngay trước action, dùng bounded physical-input lock; không lấy được lock thì
  zero action; luôn release trong `finally` kể cả executor ném exception.

B3 cần live retry để prove hành động ngay lượt local đầu. Production chưa nối.

## Live B3 retry 5 — exclusive lock đặt quá muộn

Artifact: `logs/phase4a1_r2/b3_retry5_20260924`.

```text
RESULT: NOT_RUN
Foreground-lease swaps: 0
Focus acquire/restore: true / true
Proposal: turn 3, 13 s remaining
Lease: USER_TAKEOVER_DURING_ACTION
Exclusive-input acquire event: absent
Topmost release: UNPINNED
```

Lease lấy focus thành công nhưng đợi settle 0,4 giây rồi chạy held-pointer guard
trước `BlockInput`. Vì vậy input mới trong khoảng settle làm action bị hủy trước
khi cơ chế exclusive control được gọi.

Remediation chuyển exclusive-input acquire lên ngay sau focus acquisition, trước
focus settle và final preflight. Khi lock đã được lấy, post-focus user-takeover
guard không còn quyền hủy action. Mọi nhánh stop, stale, executor failure hoặc
exception đều chạy bounded unlock trước khi restore focus.

Probe cũng chuyển về lifecycle giống FarmRunner cũ: provider phải được tạo từ
boss lobby (`require_lobby_start=True`) và bỏ Dot audit khỏi deadline mở màn.
Điều này giữ first-turn capture thuộc luồng cũ thay vì tạo route board mới.

## Live B3 retry 6 — Windows từ chối `BlockInput`, zero action

Artifact: `logs/phase4a1_r2/b3_retry6_20260924`.

```text
RESULT: NOT_RUN
Foreground-lease swaps: 0
Proposal: turn 3, 13 s remaining, (2,0) -> (3,0)
Focus acquire/restore: true / true
BlockInput attempts: 3, acquired: false
Lease: EXCLUSIVE_INPUT_FAILED
Topmost release: UNPINNED
```

Focus, exact HWND và proposal đều hợp lệ. Lỗi xảy ra trước executor vì Windows
không cấp global `BlockInput` cho tiến trình tool hiện tại. Probe fail-closed:
không click, trả focus rồi gỡ topmost.

Remediation giữ `BlockInput` làm lựa chọn đầu. Khi API này bị từ chối, mouse
lease dùng `ClipCursor` giới hạn con trỏ tại điểm executor đang sở hữu; trước
mỗi cursor move, giới hạn một pixel được chuyển sang đúng click point. Vùng
clip cũ được lưu và khôi phục trước khi trả focus. Nếu không đọc/đặt/khôi phục
được clip, action vẫn fail-closed. `ForegroundClickExecutor` không đổi logic;
B3 chỉ bọc backend con trỏ của executor bằng lease này.

Hai test native mới prove chuỗi acquire → chuyển click point → restore và nhánh
không lưu được clip thì zero action. Full suite tại remediation đó đạt
**1442/1442 PASS**. Cần một live retry riêng; không tự retry.

## Live B3 retry 7 — transport PASS, opening policy FAIL

Artifact: `logs/phase4a1_r2/b3_retry7_20260924`.

```text
HARNESS RESULT: ACCEPTED
PHASE REVIEW: POLICY FAIL — FIRST LOCAL TURN MISSED
Foreground-lease swaps: 1
Proposal: turn 3, sequence 0, screen (4,2) -> (5,2)
Cursor guard: CURSOR_CONFINE acquire/release true
Typed clicks: 2
Local move sequence: 0 -> 1
Runtime last move: (row 3,col 2) -> (row 2,col 2)
Turn: local 3 -> boss 4
Focus/cursor restore: true / true
Topmost release: UNPINNED
```

Screen/runtime row đảo chiều nên tọa độ ACK khớp chính xác. Cursor confinement
đã giữ action, chuyển qua hai click point và trả vùng chuột thành công. Transport
đã được prove hoàn chỉnh.

Tuy nhiên provider chỉ publish ở turn local 3; turn local đầu đã trôi qua mà
`local_move_sequence` vẫn bằng 0. Nhãn `ACCEPTED` trong summary chỉ phản ánh
exact transport ACK, không đủ để pass gate B3 đã thống nhất.

Remediation dùng đúng opening transport của FarmRunner:

- arm `DispatcherTransportTap.arm_for_new_match` ngay từ boss lobby;
- giữ immutable `MATCH_START` ở cadence 1 ms trong lúc user vào trận;
- khi provider bind Board session, offer snapshot rồi repoll ngay;
- B3 chỉ cho proposal có `is_first_local_turn == true`;
- nếu chỉ thấy local turn sau opening, dừng zero-input và ghi
  `board_probe_first_local_turn_missed`.

Hai regression test mới prove cả fast opening offer/repoll lẫn late-turn
fail-closed. Full suite hiện **1444/1444 PASS**. Cần retry riêng để prove turn 1.

## Live B3 retry 8 — opening PASS, Phase-4 delivery UNCONFIRMED

Artifact startup fail (zero input):
`logs/phase4a1_r2/b3_retry8_20260924`.

Artifact live attempt:
`logs/phase4a1_r2/b3_retry8_window_rebind_20260924`.

Lần khởi động đầu gặp exact game HWND tạm thời không khả dụng. Tiến trình và
HWND sau đó vẫn đúng, visible, không minimized; attempt này chưa arm và gửi zero
input. Cùng authorization được chạy lại trong artifact riêng.

```text
RESULT: UNCONFIRMED
MATCH_START retained/offered: true / true
Opening source: ChatMessageDTO.MATCH_START.matchPayload.board
Proposal: turn 1, local sequence 0, 13 s remaining
Proposed swap: (3,5) -> (4,5), valid Rage match
Cursor guard: CURSOR_CONFINE acquire/release true
Typed clicks: 2
Post runtime: boss turn 2, local sequence still 0
Exact swap ACK: false
Focus/cursor restore: true / true
Topmost release: UNPINNED
```

Dispatcher remediation đã đóng lỗi đọc chậm: provider publish authoritative
opening ở turn 1 và proposal có `is_first_local_turn == true`. Board replay xác
nhận tuple `(row, col)` cùng nước Rage hợp lệ; không có lỗi đảo tọa độ.

Game không ghi nhận swap: local move sequence giữ 0 cho đến khi lượt chuyển cho
boss. Vì foreground production hiện tại, solver, policy và executor cũ đã được
live prove ổn định, đây được phân loại là lỗi delivery của wrapper Phase 4,
không mở lại hoặc sửa gameplay cũ.

Telemetry cho thấy action end, cursor-guard release và cursor restore xảy ra
cùng timestamp. Remediation thêm `post_action_settle_seconds=0.20` chỉ trong
foreground lease B3: giữ focus, endpoint thứ hai và cursor guard qua thêm nhiều
render frame sau mouse-up rồi mới nhả. Solver và `ForegroundClickExecutor`
production không đổi. Test mới bắt buộc settle xảy ra trước release; full suite
hiện **1445/1445 PASS**. Cần một live retry riêng, không tự retry.

## Live B3 retry 9 — PASS STRONG

Artifact: `logs/phase4a1_r2/b3_retry9_20260924`.
Machine-readable review: `post_review.json` trong cùng thư mục.

```text
RESULT: ACCEPTED
Opening source: ChatMessageDTO.MATCH_START.matchPayload.board
Proposal: first local turn 1, sequence 0, 13 s remaining
Proposed swap: screen (3,5) -> (3,6)
Cursor guard: CURSOR_CONFINE acquire/release true
Post-action settle: 0.20 s before guard release
Typed clicks: 2
Local move sequence: 0 -> 1
Runtime last move: (row 4,col 5) -> (row 4,col 6)
Turn: local 1 -> boss 2
Focus/cursor restore: true / true
Topmost release: UNPINNED
Automatic retry: false
```

Runtime row đảo chiều với screen row, nên `screen row 3 == runtime row 4`;
sequence, cột, hàng và turn transition đều khớp exact proposal. ACK xuất hiện
sau khi wrapper giữ endpoint/focus/cursor guard thêm 0,20 giây. Đây là live
proof cho transport `PINNED_FOREGROUND_LEASE`, không phải true background.

B3 return gate đã đạt. Foreground production, solver, policy và executor cũ
vẫn là baseline accepted và chưa bị sửa hoặc nối vào probe. Bước kế tiếp phải
prove QTE directions + Space dưới bounded pinned foreground lease trước khi
tạo mode/backend production.
