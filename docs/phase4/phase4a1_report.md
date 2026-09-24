# Phase 4A.1 — Isolated Background Mouse Live Probe

## Kết quả

**BLOCKED.** Harness an toàn và bounded, nhưng không primitive chuột nền nào
nhận được authoritative ACK trên Pokiguard 1.7.4-b4:

| Stage | Primitive | Kết quả | Bằng chứng acceptance |
|---|---|---|---|
| B1 | zero-input attach | ACCEPTED | exact PID/HWND/title/geometry/target; zero input |
| B2 | single click Start | UNCONFIRMED | `PostMessageW=true`, nhưng không có fresh combat session/opening |
| B3 | two-click swap | UNCONFIRMED | turn/sequence/last-move không đổi |
| B4 | held drag swap | UNCONFIRMED | turn/sequence/last-move không đổi |

Theo gate của 4A.1, tập kết quả này dừng roadmap background. Không bắt đầu
4A.2 và không nối transport vào Desktop UI, policy hoặc FarmRunner.

## Source

- app/source version: v1.1.0
- base commit: `4c2777d415a8f77037820babc7a67ad72186441c`
- phase commit: NOT_CREATED
- branch: `codex/phase3a2-board-repair`
- pushed: no
- game build: Pokiguard 1.7.4-b4
- `GameAssembly.dll` SHA-256:
  `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`
- worktree: giữ nguyên mọi file riêng đã liệt kê trong `STATUS.md`; production
  source không bị sửa

## Scope đã hoàn thành

- Tạo isolated typed transport cho `START_SINGLE_CLICK`, `BOARD_TWO_CLICK` và
  `BOARD_DRAG` trong `tools/background_mouse_transport.py`.
- Tạo user-operated harness trong `tools/background_mouse_probe.py`.
- Bind và revalidate exact PID/HWND/title/client geometry trước từng message.
- Reject minimized, geometry/PID/HWND stale, queue failure và input khi chưa arm.
- Log từng message, client coordinate, packed `lParam`, monotonic timestamp,
  foreground HWND, queue result và authoritative pre/post-state.
- Giữ system cursor nguyên vị trí; không dùng global cursor.
- Không retry partial/unconfirmed input; drag luôn có `UP` cleanup sau `DOWN`.
- Production input backend, FarmRunner, Desktop UI và policy không bị nối/chạm.

## Transport evidence

Tất cả run hợp lệ dùng PID `6412`, HWND `1840700`, title
`PokiguardOnlines`, client geometry `(664,146,1280,640)`. Foreground HWND khi
gửi input là `329892`, khác HWND game.

### B1 — zero-input attach

- exact Starburst ID `1289` và Start proof ổn định;
- cursor `(644,1003)` trước/sau;
- input counts đều bằng 0;
- result `ACCEPTED` chỉ có nghĩa attach/target/zero-input contract đạt.

### B2 — Start single click

- client point `(779,519)`;
- `WM_MOUSEMOVE`, `WM_LBUTTONDOWN`, giữ 31 ms, `WM_LBUTTONUP`;
- cả ba message queue thành công;
- cursor `(564,482)` trước/sau;
- 45 giây sau input, lifecycle vẫn ở lobby với
  `local_match_rig_and_combat_objects_absent`;
- không fresh session/MATCH_START opening; result `UNCONFIRMED`; zero retry.

Sau khi report ban đầu được lập, người dùng yêu cầu một lần lặp riêng để tự
quan sát màn hình. Run `b2_user_observed_retry_20260923` queue cùng sequence,
giữ DOWN 31 ms, cursor vẫn không đổi và không có opening ACK; người dùng xác
nhận game không vào trận. Đây là repeat được user cấp quyền rõ ràng, không phải
auto/blind retry, và củng cố cùng kết luận `UNCONFIRMED`.

Run B2 pulse tức thời trước đó bị loại khỏi kết luận vì harness lúc đó thiếu
bounded 25 ms hold đã được xác nhận trong V1 Beta. B2 ở trên là remediation có
hold và là evidence chính thức.

### B3 — two-click board swap

- fresh manual-entry combat session `M_b3b30976`, proposal
  `(3,0) -> (4,0)`, turn 3;
- hai client points `(454,258)` và `(460,304)`;
- sáu message queue thành công, mỗi click giữ khoảng 31 ms;
- cursor `(567,565)` trước/sau;
- trong cửa sổ ACK: turn `3 -> 3`, local move sequence `0 -> 0`, last move
  sequence vẫn `-1`, không exact from/to ACK;
- result `UNCONFIRMED`; zero retry.

Attempt board đầu tiên bị loại khỏi kết luận vì manual-entry ACK lúc đó yêu cầu
sai opening-only state; harness không gửi input trong attempt đó. Điều kiện đã
được sửa và B3 chính thức ở trên chấp nhận stable production combat state.

### B4 — held drag board swap

- fresh manual-entry combat session `M_1914bcda`, proposal
  `(2,4) -> (3,4)`, turn 3;
- start `(658,212)`, ba held moves, held overshoot tới `(658,263)`, sau đó
  unconditional `WM_LBUTTONUP` cleanup;
- cả bảy message queue thành công;
- cursor `(518,824)` trước/sau;
- trong cửa sổ ACK: turn `3 -> 3`, local move sequence `0 -> 0`, không last
  move coordinates;
- result `UNCONFIRMED`; zero retry.

Attempt B4 trước đó hết manual-entry timeout trước khi user vào trận và có zero
input, nên không tham gia kết luận. CLI guard sau đó được mở tới 300 giây và có
unit test để tránh lặp lại lỗi vận hành này.

## Capability

- foreground baseline: PASS STRONG, giữ nguyên v1.1.0
- background single click: UNCONFIRMED
- background two-click swap: UNCONFIRMED
- background drag swap: UNCONFIRMED
- background card click: UNKNOWN, không chạy vì primitive nền cơ sở không ACK
- background arrows/Space: NOT_RUN; 4A.2 không có entry gate
- covered-window combat: UNSUPPORTED theo evidence hiện tại
- navigation/re-entry: UNKNOWN
- minimized: UNSUPPORTED
- selected branch: BLOCKED

`PostMessageW=true` chỉ chứng minh message được xếp vào queue. Nó không chứng
minh Unity/game xử lý input. Không có transport nào đủ điều kiện để đi vào
production.

## Critical safety

- wrong HWND/PID: 0
- wrong-turn input: 0
- partial input: 0
- duplicate input: 0
- stale input: 0
- input after stop ACK: 0
- unconfirmed input retried: 0
- user-authorized observable repeat: 1
- board ACK conflict: 0
- orphan controller/poller: 0
- cursor movement caused by harness: 0

Người dùng đã tự thoát các trận probe và xác nhận quay về boss lobby.

## Tests

- focused: 20 tests pass
- full regression: 1,407 tests pass
- compileall: pass
- `git diff --check`: pass
- fake backend covers packing/order/separation/drag cleanup/stale binding/stop/
  queue failure/no ACK/no retry/unarmed zero-input

## Docs và artifacts

- runbook: `docs/phase4/phase4a1_live_probe_runbook.md`
- live evidence summary:
  `docs/phase4/artifacts/phase4a1_live_evidence.json`
- capability matrix:
  `docs/phase4/artifacts/phase4a1_capability_matrix.json`
- raw local logs: `logs/phase4a1/`
- raw summary/events SHA-256 được neo trong live evidence summary
- `STATUS.md`: updated
- production integration: none

## Known unknown

- Chưa có bằng chứng rằng một transport khác ngoài posted window messages sẽ
  được game nhận khi covered/nonforeground.
- Không thử background keyboard/QTE vì 4A.1 không đạt entry gate cho 4A.2.
- Không suy rộng kết quả sang minimized; minimized vẫn unsupported.

## Router decision

- current phase result: `BLOCKED`
- next prompt: `STOP`
- reason: B2/B3/B4 đều `UNCONFIRMED` dù message queue thành công, game
  nonforeground và system cursor không đổi
- remediation return gate: chỉ tạo `4A.1-Rn` khi có một transport hypothesis
  mới kèm bằng chứng; không lặp lại PostMessageW cùng sequence

Quy trình live sau này dùng nhịp bất đồng bộ: agent start/arm script một lần,
người dùng tự vào trận và quan sát; agent không poll terminal trong trận. Người
dùng tự thoát sau số lượt đã định hoặc sau 1–2 action, rồi agent mới đọc log.
