# Phase 4E.1 — B4 packaged graceful checkpoint/resume report

Ngày live: 2026-09-30 (Asia/Saigon).

- Artifact SHA-256:
  `ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`.
- Data root dùng chung:
  `D:\PokiguardToolV2\build\v1.1.0\acceptance-phase4e1-b4-r1`.
- FarmRun gốc: `a76c6bac72a44b88a87cc47e0cd05b38`.
- FarmRun tiếp tục: `e51cf245fba2454a97ec60c4823bd45c`.
- Run gốc nhận graceful stop trong trận đầu, hoàn thành đúng 1/3 WIN rồi dừng
  tại `BOSS_LOBBY` với `STOPPED_GRACEFULLY`.
- Sau yêu cầu dừng không phát thêm boss-entry input. Checkpoint gốc canonical
  ở sequence 4 và giữ nguyên SHA-256
  `9851e6f94cc950b21fcd166d5c04cab9b79c380404ecac0758258c6806db9fa2`
  qua lần đóng/mở packaged UI.
- Resume nhận đúng `continuationOf` của run gốc, nạp `historicalCompleted=1`
  và chỉ chạy `remainingCompleted=2`.
- Lịch sử cuối: 3/3 WIN trong 3 attempts, đúng ba MatchId duy nhất:
  `M_49c620f4`, `M_42f44295`, `M_8e008eb6`; không double-count.
- Tổng board swap của cặp run: 20/20 ACK, 0 reject. Mỗi trận có một Pet Skill
  PERFECT và kết quả memory/UI `CONSISTENT`.
- Checkpoint continuation kết thúc `COMPLETED`, `FARM_TARGET_COMPLETED`,
  `last_safe_lifecycle=BOSS_LOBBY`; 0 technical abort/recovery và mọi safety
  counter bằng 0.
- Mỗi process có đúng một pin/unpin run-scope; guard/focus/cursor cleanup sạch.

**B4 PASS STRONG.**
