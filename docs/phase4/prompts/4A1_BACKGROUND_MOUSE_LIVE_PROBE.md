# Phase 4A.1 — Isolated Background Mouse Live Probe

Implement and validate **Phase 4A.1 ONLY**.

Entry gate: Phase 4A.0 phải `PASS STRONG`; đọc report/runbook/matrix mà
`STATUS.md` trỏ tới. Nếu entry gate không đạt, không viết harness live.

## 0. Read first

Đọc toàn bộ Phase 4 core docs, 4A.0 artifacts, canonical state/decisions,
`win32_input.py`, actionability/session code và các test input hiện có.

Rà Git trước khi sửa. Giữ V1/game read-only và giữ nguyên file riêng của user.

## 1. Exact goal

Tạo một harness tách biệt, opt-in, bounded để trả lời bằng live evidence:

1. game b4 có nhận background single click không;
2. game b4 có nhận background two-click swap không;
3. game b4 có nhận background drag swap không;
4. behavior khi HWND hợp lệ nhưng không foreground;
5. ACK nào chứng minh từng action accepted.

Không nối harness vào Desktop UI, policy hay FarmRunner production.

## 2. Harness contract

Harness phải:

- bind exact PID/HWND/title/client geometry;
- reject minimized, resized, wrong PID hoặc stale session;
- dùng client coordinates và target HWND;
- có typed command riêng cho single-click, two-click, drag;
- arm từng command rõ ràng; mặc định zero input;
- log từng message, coordinate, monotonic timestamp và Win32 return;
- log authoritative pre/post state và ACK;
- không coi queue success là acceptance;
- không tự retry unconfirmed hoặc partial input;
- luôn gửi UP cleanup sau DOWN nếu drag đã bắt đầu;
- Emergency Stop/shutdown chặn input mới ngay lập tức.

Không thêm arbitrary-coordinate/arbitrary-message public API vào production.

## 3. Offline tests

Dùng fake Win32 backend để cover:

- lParam client-coordinate packing;
- exact message order;
- two-click separation;
- drag `MK_LBUTTON` moves và unconditional UP;
- wrong HWND/PID/geometry/minimized;
- stop between messages;
- PostMessage false;
- PostMessage true nhưng no ACK;
- no blind retry;
- zero input when unarmed.

Chạy focused, full regression, compileall và diff-check nếu code production/shared
bị chạm. Harness-only vẫn phải chạy focused relevant và compileall.

## 4. Live stages — user controls the game

Agent không điều khiển Windows/game. Hướng dẫn người dùng chuẩn bị từng stage,
sau đó chạy harness và đọc log.

Game phải mở, không minimized. Người dùng đưa một cửa sổ khác lên foreground để
chứng minh game thật sự background.

### B1 — zero-input attach

- attach/read state;
- game background;
- zero input;
- prove exact HWND/PID/geometry/session.

### B2 — one single click

Chọn một UI action bounded có exact native/visual identity và authoritative
state transition. Gửi đúng một click. Không dùng tọa độ đoán.

### B3 — one two-click board swap

Chỉ ở local turn/actionable board. Gửi đúng một adjacent proposal và chờ board/
sequence ACK hiện có. Không retry nếu unconfirmed.

### B4 — one drag board swap

Chạy ở một local turn mới. Gửi đúng một flick sequence và chờ ACK. Không chạy B4
nếu B3 làm lifecycle/session không còn phù hợp.

Mỗi transport phải được đánh giá riêng:

```text
ACCEPTED
REJECTED
UNCONFIRMED
NOT_RUN
```

## 5. PASS / PASS STRONG

PASS yêu cầu:

- harness an toàn và bounded;
- ít nhất single click hoặc một board transport có authoritative ACK;
- zero wrong/duplicate/stale/stop-after-ACK input;
- kết luận riêng cho each primitive.

PASS STRONG yêu cầu thêm:

- background single click = ACCEPTED;
- ít nhất two-click hoặc drag = ACCEPTED;
- exact non-foreground evidence xuyên suốt action;
- cursor hệ thống không bị di chuyển bởi harness;
- no partial/unconfirmed retry;
- artifacts/replay/tests đủ tái hiện;
- capability matrix/STATUS/router cập nhật.

Nếu two-click accepted nhưng drag không accepted, vẫn có thể PASS STRONG với
background board capability = `TWO_CLICK_ONLY`.

## 6. Blockers and routing

- Mọi mouse primitive REJECTED/UNCONFIRMED: `BLOCKED`, dừng roadmap background.
- Single click + board transport accepted: next 4A.2.
- Safety/duplicate/wrong input: `FAIL`, tạo 4A.1-Rn.

Tạo report/runbook dưới `docs/phase4/` và dùng handoff template.

## 7. Do not implement

- production input mode/config;
- FarmRunner/Desktop UI wiring;
- background keyboard/QTE;
- navigation/re-entry;
- package build.

## 8. Explicit stop

STOP sau live evidence/report/checkpoint. Không bắt đầu 4A.2 trong cùng phase.
