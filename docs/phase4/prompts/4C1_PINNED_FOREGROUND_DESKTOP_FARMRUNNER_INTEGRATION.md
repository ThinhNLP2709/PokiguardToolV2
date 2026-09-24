# Phase 4C.1 — Desktop UI ↔ FarmRunner Pinned Foreground Integration

Implement and validate **Phase 4C.1 ONLY**.

Entry gate: 4B.2, 4B.3 và 4B.4P `PASS STRONG`.

Expose hai mode: `Tiền cảnh (mặc định)` và `Ghim game để tự chơi khi dùng máy —
Beta`. UI phải nói rõ game luôn visible/topmost, không minimized; tool có thể
tạm lấy chuột quanh click/swap và keyboard trong QTE; focus return là best
effort. Không dùng chữ full/background cho mode Beta.

Mode immutable trong run/checkpoint; config cũ về foreground; invalid combination
reject rõ. FarmRunner dùng delivery authority theo domain và giữ nguyên permits,
ACK, stop, counters, target/attempt/no-extra-entry.

Run tests UI/config/checkpoint/resume/import và full regression. Live source qua
`run_tool`: 1 foreground match, 1 Beta match, rồi 3–5 Beta matches nếu sạch,
kèm graceful stop. Navigation/re-entry hiếm chưa được mở rộng ở phase này.

PASS STRONG -> `4C2_PINNED_FOREGROUND_NAVIGATION_REENTRY.md`; STOP.

