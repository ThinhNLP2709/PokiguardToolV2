# Phase 4B.1 — Input Mode Contract + Backend

Implement **Phase 4B.1 ONLY**.

Entry gate:

- 4A.1 `PASS STRONG`;
- 4A.2 có kết luận accepted là `FULL_BACKGROUND_CAPABLE` hoặc
  `HYBRID_REQUIRED`;
- `STATUS.md` capability matrix đã được cập nhật.

Nếu không, không triển khai production backend.

## 1. Exact goal

Tạo model/config/backend nền typed và testable, nhưng chưa nối autonomous board,
card, QTE, FarmRunner hay Desktop UI.

Contract tối thiểu:

```text
InputDeliveryMode
- FOREGROUND (default)
- BACKGROUND_MOUSE_BETA
- BACKGROUND_FULL_BETA       [chỉ khi capability Full]
- HYBRID_QTE_FOREGROUND      [chỉ khi branch Hybrid]
```

Tên cuối cùng có thể theo convention repository, nhưng semantics phải rõ và
serialize ổn định.

## 2. Requirements

- default/migration của config cũ luôn là foreground;
- unsupported mode không được load thành một mode khác âm thầm;
- config immutable trong một FarmRun;
- backend bind exact HWND/PID/client geometry;
- background mouse dùng client coordinates, không `SetCursorPos`/global mouse;
- typed methods cho single click, two-click, drag nếu proven;
- typed keyboard methods chỉ tồn tại nếu 4A.2 Full;
- queue result và authoritative acceptance là hai trạng thái riêng;
- partial drag luôn cleanup UP;
- minimized/resized/wrong PID/stale binding fail closed;
- Emergency Stop/shutdown chặn message mới;
- foreground executor hiện tại giữ nguyên behavior/default.

Không bỏ toàn bộ foreground checks bằng một boolean chung. Tạo một delivery
authority/capability contract để caller hỏi đúng mode/domain.

## 3. Telemetry

Mỗi attempted transport ghi:

- run/session/domain/action identity;
- mode/branch;
- HWND/PID/geometry;
- client point(s);
- message sequence và timestamps;
- queued/partial/rejected;
- expected ACK kind;
- focus state trước/sau;
- cleanup result.

Không log secret hoặc full raw memory.

## 4. Tests

Cover:

- config migration/default;
- branch capability validation;
- exact message ordering/coordinates;
- unsupported drag/keyboard;
- foreground backend unchanged;
- wrong PID/window/geometry/minimized;
- stop/exception cleanup;
- serialized round-trip;
- package import graph nếu module mới được bundle.

Run focused, full regression, compileall và diff-check.

## 5. Acceptance

PASS STRONG yêu cầu:

- all tests green;
- foreground regression unchanged;
- impossible combinations rejected explicitly;
- zero production call site chuyển sang background trong phase này;
- docs/decisions ghi contract, không claim capability ngoài live evidence;
- STATUS/router chọn 4B.2;
- focused commit/push khi phase được chốt.

## 6. Do not implement

- board/card/QTE production wiring;
- Desktop UI option;
- FarmRunner permit relaxation;
- re-entry/navigation;
- live farm;
- package build.

## 7. Explicit stop

STOP sau backend/model/tests/docs/checkpoint.
