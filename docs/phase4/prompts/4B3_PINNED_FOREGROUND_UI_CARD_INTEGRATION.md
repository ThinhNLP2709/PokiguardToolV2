# Phase 4B.3 — Pinned Foreground UI/Card Integration

Implement and validate **Phase 4B.3 ONLY**.

Entry gate: 4B.2 `PASS STRONG`.

## Goal

Bọc các single-click production domain bằng mouse lease đã accepted, theo từng
domain riêng: Boss Start/retry, lobby selection nếu có, EVOLVE, default CAST,
postmatch confirm và các recovery click đã có proof. Pet Skill QTE để 4B.4P.

## Safety

- exact lifecycle/session/card/button/slot/actionability và fresh visual/native
  proof như production hiện tại;
- acquire không được xảy ra trước khi exact control actionable;
- reread sau foreground acquire và trước click;
- one click per permit; queued/sent không đồng nghĩa ACK;
- outcome uncertain không reclick;
- attempt/target/no-extra-entry invariants giữ nguyên;
- release mouse/cursor ngay sau click; focus return best effort;
- foreground default không đổi.

Tests/replay cover từng domain, stale/placeholder/non-interactable control,
delayed/no ACK, stop, accounting và cleanup. Live bounded prove Start, ít nhất
một card/control phù hợp cấu hình, postmatch return và zero wrong click.

PASS STRONG -> `4B4P_PINNED_FOREGROUND_QTE_INTEGRATION.md`; STOP.

