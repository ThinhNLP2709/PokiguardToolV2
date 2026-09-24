# Phase 4D.2 — Pinned Foreground Beta Reliability Soak

Implement and validate **Phase 4D.2 ONLY**.

Entry gate: 4D.1 `PASS STRONG`.

Chạy bounded source soak mặc định 25 completed matches với attempt margin hữu
hạn, exact immutable mode/config/build. User start và điều khiển máy; agent đọc
log, không dùng computer-use.

Critical zero: wrong HWND/turn, stale/duplicate/partial input, unconfirmed retry,
input sau stop ACK, QTE ownership conflict, unexpected takeover ngoài lease,
cursor/guard/topmost leak, terminal conflict và extra attempt. Natural recovery
được ghi; nhánh không xảy ra là `NOT_OBSERVED` nếu replay accepted.

PASS STRONG -> `4E1_PACKAGED_PINNED_FOREGROUND_BETA_ACCEPTANCE.md`; STOP.

