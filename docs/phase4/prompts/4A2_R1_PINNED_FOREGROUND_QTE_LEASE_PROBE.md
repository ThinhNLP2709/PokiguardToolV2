# Phase 4A.2-R1 — Pinned Foreground Existing-Input Lease Probe

Implement and validate **Phase 4A.2-R1 ONLY**.

## Entry gate

- Phase 4A.1-R2 `PASS STRONG`.
- `PINNED_FOREGROUND_LEASE` đã prove Start và exact first-turn board swap.
- Foreground production, solver, policy, Pet Skill executor và toàn bộ QTE input
  hiện tại là baseline accepted.
- Production/FarmRunner/Desktop UI chưa tích hợp Phase 4.

## Goal

Không tạo QTE hoặc tuyến input mới. Pin cửa sổ game, rồi bọc nguyên hành động
Pet Skill hiện có bằng một bounded foreground/input lease:

1. executor hiện tại click đúng thẻ;
2. executor hiện tại nhấn từng hướng với timing/delay hiện có và chờ ACK;
3. executor hiện tại nhấn đúng một Space trong Perfect interval;
4. xác nhận current-instance CardUI runtime `PERFECT`;
5. trả focus, mouse/keyboard authority và topmost sạch.

Khái niệm generation/current-instance chỉ dùng để chống đọc hoặc gửi input vào
dữ liệu cũ. Nó không có nghĩa là một cơ chế QTE mới.

## Constraints

- User tự chuẩn bị trận và tài nguyên; agent chỉ chạy script/log.
- Bind exact PID/HWND/geometry/match/card/current QTE generation.
- Game luôn visible/topmost, không minimized hoặc resize.
- Khi action bắt đầu, lease được phép tạm chiếm foreground, mouse và keyboard.
- Guard phải bounded, release trong `finally` và không chặn Emergency Stop.
- Nếu `BlockInput` bị Windows từ chối, fallback ghép cursor confinement với
  low-level keyboard guard; injected input của executor và physical `F9` được
  đi qua.
- Lease bao trọn phiên từ card click đến runtime result, không acquire/release
  riêng cho từng hướng.
- Không sửa gameplay policy, timing/scoring QTE, random delay hoặc executor cũ.
- Không có directions-only route, Space thủ công hoặc input retry mù.
- Không nối FarmRunner trong phase này.

## Offline stages

- Tạo typed keyboard lease wrapper dùng executor cũ.
- Prove wrong/stale generation, wrong direction, focus denied, guard denied,
  stop và exception đều fail closed.
- Prove per-direction ACK, một Space tối đa và release luôn chạy.
- Chạy focused/full/compileall/diff-check.

## Live stages

### B1 — zero-input observation

User tự nhấn thẻ và tự hoàn tất QTE. Probe chỉ bind QTE hiện tại, đọc
generation/sequence/Perfect interval rồi dừng với zero input.

### B2 — full existing action while pinned

User tự đi bàn để tích tài nguyên nhưng không nhấn thẻ. Khi policy cũ cho phép,
probe acquire một lease và để nguyên full executor cũ chạy từ click thẻ qua
directions đến Space/Perfect. Không yêu cầu focus ban đầu thuộc ứng dụng khác.

### B3 — same full action with focus takeover/restore

Lặp lại B2 nhưng user chuyển focus sang ứng dụng khác trước khi action sẵn sàng.
Chỉ accept khi lease lấy foreground, full action cũ thành công và focus được trả
đúng ứng dụng trước đó.

## Acceptance

`PASS STRONG` yêu cầu B1/B2/B3 accepted, zero duplicate/stale input,
focus/keyboard/cursor/topmost release sạch và toàn bộ test pass. Khi đó router
mới cho phép tạo mode/backend production cho `PINNED_FOREGROUND_LEASE`.

## Explicit stop

STOP sau report/checkpoint. Không tích hợp FarmRunner, UI hoặc package trong
cùng phase.
