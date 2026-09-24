# Phase 4D.1 — Foreground vs Pinned Foreground Beta A/B

Implement and validate **Phase 4D.1 ONLY**.

Entry gate: 4C.2 `PASS STRONG`.

So sánh cùng game build/config: A = foreground default; B = pinned foreground
lease Beta. Đề xuất 5 completed matches mỗi nhánh. Record exact manifest,
completed/attempt/W/L/U, input/ACK theo domain, stale/duplicate/partial, focus
takeover count/duration, cleanup, recovery và final controller state.

PASS STRONG yêu cầu cả hai đạt target, zero critical violation/no extra attempt,
mode B chỉ takeover trong lease đã công bố và artifacts reproducible. Next
`4D2_PINNED_FOREGROUND_RELIABILITY_SOAK.md`; STOP.

