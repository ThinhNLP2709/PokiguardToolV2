# Phase 4B.1 — Pinned Foreground Lease Contract + Backend

Implement **Phase 4B.1 ONLY**.

Entry gate: 4A.1-R2 và 4A.2-R1 đều `PASS STRONG`; selected capability là
`PINNED_FOREGROUND_EXISTING_INPUT_LEASE`.

## Goal

Chuyển transport/lease đã live-prove thành contract/backend production typed và
testable. Chưa nối board, card, QTE, FarmRunner hoặc Desktop UI.

Mode tối thiểu:

```text
FOREGROUND                         (mặc định, giữ nguyên)
PINNED_FOREGROUND_LEASE_BETA       (game visible/topmost, bounded takeover)
```

Không đặt tên hoặc mô tả mode Beta là background/minimized.

## Contract bắt buộc

- exact PID/HWND/client geometry và game không minimized;
- pin/unpin có ownership rõ, cleanup idempotent;
- mouse lease cho click/swap: lấy foreground, giữ chuột chỉ quanh executor cũ,
  trả cursor và thử trả focus theo best effort;
- QTE lease chia hai stage: mouse cho card click, keyboard-only sau current QTE
  bind, rồi release sạch;
- `F9`/stop có thể đi qua guard và chặn input mới sau stop ACK;
- unsupported domain/mode fail closed, không silent fallback;
- focus restore là telemetry best effort; cursor/guard/topmost cleanup bắt buộc;
- config cũ migrate về `FOREGROUND`; mode immutable trong một run;
- không đổi solver, policy, executor, timing/random hay ACK hiện có.

## Tests

Cover mode migration/round-trip, exact binding, wrong PID/HWND/geometry,
minimized, pin ownership, mouse/keyboard stage transitions, stop/exception,
cursor restore, focus restore success/failure, idempotent cleanup và foreground
regression. Run focused, full regression, compileall, diff-check.

## Acceptance

All tests green, zero production call site chuyển mode trong phase này, docs và
telemetry dùng đúng tên pinned foreground lease. Update STATUS/router sang
`4B2_PINNED_FOREGROUND_BOARD_INTEGRATION.md` rồi STOP. Commit/push chỉ khi user
yêu cầu chốt.

