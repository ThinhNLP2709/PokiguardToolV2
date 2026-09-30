# Phase 4B.2 — Pinned Foreground Board Integration

Implement and validate **Phase 4B.2 ONLY**.

Entry gate: 4B.1 `PASS STRONG`.

## Goal

Bọc nguyên board SWAP executor production hiện tại bằng pinned foreground mouse
lease. Không đổi solver/policy/scoring/PASS/card/QTE.

## Requirements

- foreground mode giữ nguyên tuyệt đối;
- Beta mode pin game khi run active, nhưng chỉ takeover/guard quanh đúng swap;
- Beta phải cho phép bước đọc/chọn nước SWAP không phát input chạy khi app khác
  đang foreground; không được để legacy `GAME_NOT_FOREGROUND` chặn trước lease;
- ngoại lệ trên chỉ phục vụ board preparation và fresh SWAP gate. Foreground
  mode cùng các action chưa tích hợp lease vẫn giữ điều kiện foreground cũ;
- reread exact session/local turn/actionability sau acquire;
- dùng proposal, coordinate mapping, two-click/drag và board ACK cũ;
- release mouse/cursor ngay sau bounded input; focus return best effort;
- uncertain/partial/no ACK fail closed, không blind retry hoặc đổi proposal;
- stop giữa endpoints phải cleanup an toàn; zero input sau stop ACK.
- cổng emergency authority phải cho phép executor đang được cấp quyền tự poll
  stop ở từng input boundary mà không deadlock; nút Emergency Stop của Desktop
  UI không được kẹt vô hạn vì cùng khóa với worker.

## Validation

Tests cover mode/domain permit, first-turn/current-turn gate, stale session,
wrong HWND/geometry, delayed/no ACK, partial input, stop, cleanup và identical
solver output. Có regression tái hiện nested emergency poll bên trong atomic
input và fail nếu worker không kết thúc trong thời gian bounded. Live do user
điều khiển: foreground regression và 1–3 pinned
lease swaps có exact sequence/coordinate/turn ACK khi app khác đang foreground.

PASS STRONG yêu cầu zero wrong/stale/duplicate/unconfirmed retry, cleanup sạch và
STATUS/router sang `4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md`. STOP.
