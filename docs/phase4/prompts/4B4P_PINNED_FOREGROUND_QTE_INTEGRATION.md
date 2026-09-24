# Phase 4B.4P — Pinned Foreground Pet-Skill/QTE Integration

Implement and validate **Phase 4B.4P ONLY**.

Entry gate: 4B.3 `PASS STRONG`; 4A.2-R1 B2/B3 live evidence accepted.

## Goal

Nối production Pet Skill action cũ vào pinned foreground QTE lease đã proven.
Không tạo QTE/executor/input route mới và không đổi policy/timing/random.

## Contract

- exact actionable current card mới được acquire;
- mouse guard chỉ giữ qua đúng một card click;
- fresh current QTE bind là ACK để chuyển sang keyboard-only guard;
- trả cursor trước direction đầu tiên;
- giữ nguyên per-direction RAM ACK, no retry và one-shot Space/Perfect logic;
- release keyboard/cursor/topmost sạch ở success/failure/stop;
- focus restore best effort và không gửi input vào prior app;
- foreground default giữ nguyên.

Tests cover early non-interactable card, generation ownership, guard transition,
direction/Space ACK, stop/focus loss và cleanup. Live do user điều khiển: tối
thiểu 3/3 full Pet Skill actions từ app khác đang foreground, runtime PERFECT,
zero wrong/skip/duplicate/stale/unconfirmed/blind retry.

PASS STRONG -> `4C1_PINNED_FOREGROUND_DESKTOP_FARMRUNNER_INTEGRATION.md`; STOP.

