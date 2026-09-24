# Phase 4B.2 — Pinned Foreground Board Integration

Implement and validate **Phase 4B.2 ONLY**.

Entry gate: 4B.1 `PASS STRONG`.

## Goal

Bọc nguyên board SWAP executor production hiện tại bằng pinned foreground mouse
lease. Không đổi solver/policy/scoring/PASS/card/QTE.

## Requirements

- foreground mode giữ nguyên tuyệt đối;
- Beta mode pin game khi run active, nhưng chỉ takeover/guard quanh đúng swap;
- reread exact session/local turn/actionability sau acquire;
- dùng proposal, coordinate mapping, two-click/drag và board ACK cũ;
- release mouse/cursor ngay sau bounded input; focus return best effort;
- uncertain/partial/no ACK fail closed, không blind retry hoặc đổi proposal;
- stop giữa endpoints phải cleanup an toàn; zero input sau stop ACK.

## Validation

Tests cover mode/domain permit, first-turn/current-turn gate, stale session,
wrong HWND/geometry, delayed/no ACK, partial input, stop, cleanup và identical
solver output. Live do user điều khiển: foreground regression và 1–3 pinned
lease swaps có exact sequence/coordinate/turn ACK khi app khác đang foreground.

PASS STRONG yêu cầu zero wrong/stale/duplicate/unconfirmed retry, cleanup sạch và
STATUS/router sang `4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md`. STOP.

