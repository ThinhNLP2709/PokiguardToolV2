# Phase 3B.2 — Automated QTE Direction Sequence

**Ngày triển khai/acceptance:** 2026-09-04

**Base commit:** `36fa85259147f622890bcb784075e2b2a7b24ce6`
**Trạng thái:** **PASS STRONG**

Phase này cấp đúng một authority mới: normal Windows input cho bốn hướng QTE
`UP/DOWN/LEFT/RIGHT`. Click Pet Skill và Space/Enter vẫn hoàn toàn do operator
thực hiện. Không có thay đổi BASIC policy, FarmRunner, ManaPriority, resource
strategy, card click hay Perfect confirm.

## Implementation

- `src/pokiguard_v2/qte_direction_assist.py`
  - public input vocabulary là enum chỉ có bốn hướng;
  - state ban đầu `DISARMED`;
  - một explicit arm chỉ bind tối đa một fresh inactive→active generation;
  - mỗi poll gửi tối đa một phím;
  - poll kế tiếp phải chứng minh đồng thời `currentIndex + 1`,
    `correctCount + 1`, thêm đúng một `qtePresses` và direction vừa ghi đúng;
  - timeout tạo `INPUT_SENT_UNCONFIRMED`, không resend và disarm;
  - session/MatchId/generation/card/actor/turn/sequence/window/foreground đổi
    đều thu hồi authority;
  - completion ở `currentIndex == sequence_length` tự disarm trước Space.
- `src/pokiguard_v2/win32_input.py`
  - thêm internal legacy `keybd_event` key-down/key-up primitive, giữ mỗi logical
    press 40 ms qua nhiều rendered frame;
  - lựa chọn primitive dựa trên native body `CardUI.GetDirectionFromInput()` của
    1.7.4: method gọi legacy `UnityEngine.Input.GetKeyDown` cho Arrow/WASD;
  - QTE public executor không nhận arbitrary virtual-key code.
- `tools/qte_direction_assist.py`
  - `--arm-next` là explicit one-generation authority;
  - giữ shared `AutomationControllerLease`, nên FarmRunner/BASIC không thể đồng
    thời sở hữu normal input;
  - gắn vào production read-only QTE observer qua hook; observer mặc định
    Phase 3B.1 vẫn không import input và vẫn read-only;
  - Ctrl+C disarm trước khi thoát; không có worker riêng/orphan worker.

## Direction mapping

Mapping dùng đúng physical arrow-key family đã được native/live Phase 3A.1 xác
nhận:

| Logical | Windows key |
|---|---|
| `UP` | `VK_UP (0x26)` |
| `DOWN` | `VK_DOWN (0x28)` |
| `LEFT` | `VK_LEFT (0x25)` |
| `RIGHT` | `VK_RIGHT (0x27)` |

Space, Enter, Escape, mouse và card action không tồn tại trong public QTE
direction API.

## Closed-loop acknowledgement

Một Windows input call thành công chỉ ghi `SENT_AWAITING_PROGRESS`; nó không
phải ACK.
Direction chỉ được xác nhận khi exact current generation đọc lại cho thấy:

```text
currentIndex == sourceIndex + 1
correctCount == sourceCorrect + 1
qtePresses == sourcePresses + exactly the expected direction
```

Default response window là 1.25 giây. Accepted live transitions thường được RAM
xác nhận trong khoảng 72--78 ms; 1.25 giây chỉ là bounded fail-closed window,
không phải pacing sleep.
Controller gửi ngay khi fresh preflight hợp lệ và không thêm human-like delay.
Nếu transition không được capture trước deadline, nó không gửi lại phím có thể
đã được game nhận.

## Telemetry

Mỗi logical direction ghi MatchId, generation, skillCardId, source index,
direction, physical mapping, send/post-read timestamps, post index/correct count,
status và failure reason. Generation summary ghi sent/confirmed/wrong/skipped/
duplicate/stale/unconfirmed, blind retry, completion elapsed, runtime Perfect
window và:

```text
headroom_to_perfect_start = perfect_start - completion_elapsed
```

Historical `3.000` không được hard-code; mỗi generation dùng runtime window.

## Resource/cost regression

Resolver Phase 3B.1 không đổi:

```text
HT7 = runtime conditionUse/power = 200 Mana / 200 Rage
HT2 = runtime conditionUse/power = 200 Mana / 150 Rage
```

Không có global Legendary cost constant. Gross resolved cost vẫn tách khỏi
observed net delta; post-effect HT7 có board absorption/cascade vẫn có thể là
`AMBIGUOUS` và không ghi đè gross cost.

## Offline verification

```text
Phase 3B.2 focused: 39/39 PASS
QTE/capability/input/stats combined focused: 141/141 PASS
full regression: 912/912 PASS
deterministic fake-backend key call: ~0.002 ms
deterministic bind + fresh preflight + key state processing: ~0.026 ms
deterministic bind + send + ACK state processing: ~0.044 ms
deterministic four-direction closed-loop state processing: ~0.142 ms
compileall: PASS
```

Các số trên là trung bình 5.000 fixture trên cùng lần chạy. Chúng chỉ đo
state-machine/fake backend, không giả làm live ReadProcessMemory/Unity input
latency. Live B4 sẽ đo confirmation-read latency, tổng sequence elapsed và dùng
chính runtime QTE elapsed để kết luận headroom.

Offline safety assertions:

```text
automated Pet Skill card clicks = 0
automated Space/Enter = 0
non-direction public keys = impossible
blind retries = 0
WriteProcessMemory = 0
direct gameplay calls = 0
network manipulation = 0
```

## Live remediation evidence

Hai prototype `SendInput` (virtual-key rồi extended physical scan-code) đều trả
về thành công ở Win32 nhưng RAM giữ `currentIndex=0/correctCount=0`; chúng không
được coi là input accepted. Native disassembly của
`CardUI.GetDirectionFromInput @ RVA 0x5B59A0` sau đó chứng minh game gọi legacy
`UnityEngine.Input.GetKeyDown` với `DownArrow/S`, `LeftArrow/A`, `RightArrow/D`,
`UpArrow/W`. Chuyển sang matching legacy `keybd_event` tạo ACK live đầu tiên:
`currentIndex 0→1`, `correctCount 0→1` trong 73 ms.

Lần đó cũng phát hiện full-object double-read quá nghiêm: `currentTimeValue`
thay đổi mỗi frame nên một snapshot coherent bị loại sau phím đầu. Reader hiện
chỉ double-check các byte ownership/identity/progress/timing; clock được phép
trôi, còn thay đổi index/correct/press-list giữa read vẫn fail closed. Hai test
khóa cả clock-drift accepted và progress-drift rejected.

## Live B1--B4 acceptance

| # | MatchId | Sequence | Sent/ACK | Complete | Perfect start | Headroom | Manual Space result |
|---|---|---|---:|---:|---:|---:|---|
| 1 | `M_fdc90d46` | D,R,U,D,U,U,U | 7/7 | 1.407 s | 3.000 s | 1.593 s | PERFECT |
| 2 | `M_fe86507a` | U,D,R,L,R,L,U | 7/7 | 1.330 s | 3.000 s | 1.670 s | GOOD |
| 3 | `M_fe86507a` | L,D,L,U,D,R,R | 7/7 | 1.378 s | 3.000 s | 1.622 s | GOOD |

Aggregate accepted live evidence:

```text
successful automated QTE generations = 3
automated directions sent/confirmed = 21/21
wrong/skipped/duplicate/stale/unconfirmed = 0/0/0/0/0
blind retries = 0
automated Pet Skill card clicks = 0
automated Space/Enter = 0
distinct MatchIds = 2
```

B3 isolation is directly observed: every sequence required a new explicit
process/arm, and after the second accepted assist auto-disarmed, the same
observer saw a later manual generation without any new
`qte_direction_input_sent` event. Old sequence/pending state therefore did not
leak into it. B4 is strong: all three closed-loop sequences completed at least
1.59 seconds before the runtime Perfect start.

Optional HT2 direction automation remains `NOT_OBSERVED`; it is not a PASS
requirement. The accepted HT2 runtime cost fixture remains 200 Mana / 150 Rage.

Phase 3B.2 has no remaining direction-primitive blocker for Phase 3B.3. It does
not itself automate Pet Skill click, Space, BASIC policy, or repeated future
generations without explicit re-arm.
