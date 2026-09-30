# Phase 4D.2 — Pinned Foreground Reliability Soak

Kết quả hiện tại: **PASS STRONG**

Entry gate Phase 4D.1: `PASS STRONG`.

## Live soak lần 1

- FarmRunId: `ae93a3c6e18942898af20790a12685db`;
- hoàn thành `25/25`, đúng `25` attempts, `25 WIN`, không có technical abort,
  recovery, safe stop hoặc lỗi kết thúc;
- `147/147` swap có ACK, `25/25` vào trận và `25/25` xác nhận kết quả;
- exact binding `HWND=4001306`, `PID=3980`, client `800x400`;
- `197` mouse lease, `26` QTE lease, toàn bộ guard/cursor/pin cleanup sạch;
- `222` focus takeovers, trong đó có `26` QTE takeovers;
- kết thúc đúng `FARM_TARGET_COMPLETED`, `BOSS_LOBBY`, checkpoint `COMPLETED`.

Run này **không đạt PASS STRONG**. Ở attempt 14, MatchId `M_b74482e7`, lần
Pet Skill đầu tiên đã click đúng thẻ và gửi đủ `7/7` hướng có authoritative
ACK, nhưng foreground chuyển sang cửa sổ người dùng sau khi tool trả chuột.
Lease QTE cũ coi mất foreground là invalid ngay lập tức nên không gửi Space:
`cardClicks=1`, `spacePresses=0`, `PINNED_QTE_LEASE_INVALIDATED`. Tool tiếp tục
an toàn và Pet Skill lần hai đạt PERFECT rồi thắng, nhưng tổng bằng chứng vẫn là
`26` skill input và chỉ `25` PERFECT, kèm
`pet_skill_after_input_failures=1`. Đây là lỗi input thật nên không được bỏ qua.

Manifest lần 1 yêu cầu tối đa `32` attempts trong khi UI live được đặt `30`.
Đây là mismatch cấu hình không gây input sai, nhưng cũng đủ làm run không đạt
acceptance. Evidence lần 1 được giữ tại:

- `artifacts/phase4d2_attempt1_manifest.json`;
- `artifacts/phase4d2_attempt1_analysis.json`;
- `artifacts/phase4d2_attempt1_analysis.md`.

Ba `expired_actions` còn lại đã được đối chiếu tận event: cả ba đều là
`ACTION_ABORTED_STATE_CHANGED / POLICY_CHANGED_ON_FRESH_REREAD` cho proposal
swap và chưa gửi input. Đây là cơ chế đọc mới để hủy proposal cũ an toàn, không
phải stale/partial input.

## Remediation

Production QTE lease giờ giữ full input guard từ lúc click thẻ đến terminal:

- không trả chuột khi executor chuyển sang chuỗi hướng;
- nếu Win32 `BlockInput` dùng được, guard đó giữ cả mouse/keyboard và vẫn cho
  injected direction/Space của executor đi qua;
- nếu phải fallback sang `CURSOR_CONFINE`, cursor vẫn bị giữ trong game và một
  low-level keyboard hook được bật song song;
- log `foreground_qte_full_guard_retained` ghi mode và identity của action;
- chỉ release mouse/keyboard/cursor/focus sau PERFECT/terminal, emergency stop
  hoặc nhánh lỗi fail closed;
- exact HWND/PID/title/geometry, thời hạn và stop gate vẫn được kiểm tra ở từng
  poll.

Analyzer v2 giữ raw `expired_actions` để audit, đồng thời chỉ trừ đúng các event
hủy proposal trước input nêu trên. Bất kỳ expiration không có evidence tương
ứng, đã gửi input, khác action/reason hoặc counter dư vẫn là critical failure.

## Offline validation

- QTE lease + pinned Pet Skill tập trung: `30/30 PASS`;
- full repository: `1610/1610 PASS`;
- `py_compile` các file sửa đổi: PASS;
- analyzer lần 1 xác nhận `3/3` expiration là safe pre-input replan; failure thật
  còn lại là `pet_skill_after_input_failures=1` và input thiếu ACK;
- không thay đổi gameplay policy, solver, board input hoặc QTE timing hiện có.

## B0 full-guard live smoke — PASS STRONG

- FarmRunId: `34b4905056234d5fb0be819190201869`;
- `1/1 WIN`, đúng một attempt, kết thúc `FARM_TARGET_COMPLETED` tại
  `BOSS_LOBBY`;
- QTE lease lấy đúng foreground từ cửa sổ ngoài sang game;
- `foreground_qte_full_guard_retained=COMPLETE` với
  `CURSOR_CONFINE+KEYBOARD_HOOK`, mouse guard và keyboard guard cùng active;
- không có `foreground_qte_mouse_released_for_keyboard`, focus reclaim hoặc
  reclaim failure;
- một card click, `7/7` hướng đều authoritative ACK, một Space, runtime
  `PERFECT`;
- không có zero/after-input failure, partial input, misclick, stale hoặc expired
  action;
- terminal release `COMPLETE`, guard/cursor/focus đều restored; pinned session
  unpin sạch.

B0 chứng minh full guard mới hoạt động live. Nó không thay thế soak 25 trận.

## Official 25-match retry — PASS STRONG

- FarmRunId: `018e125ba3e0442dba800f3bfd44d3af`;
- analyzer v2: `PASS_STRONG`, zero acceptance failure;
- hoàn thành `25/25`, đúng `25` attempts, `25 WIN`, `0 LOSS`, `0 UNKNOWN`;
- `0` technical abort/recovery/exit/safe-stop, zero input sau emergency ACK;
- `25/25` boss entry ACK, `153/153` swap ACK, `25/25` Pet Skill ACK và
  `25/25` postmatch confirm ACK;
- cả 25 Pet Skill đều có đúng một card click, `7/7` direction ACK, đúng một
  Space và runtime `PERFECT`;
- cả 25 QTE đều giữ full guard `CURSOR_CONFINE+KEYBOARD_HOOK`; không có event
  trả chuột giữa QTE, focus reclaim hoặc reclaim failure;
- cả 25 QTE terminal release đều `COMPLETE`, mouse/keyboard guard, cursor và
  focus được trả sạch;
- `203` mouse leases, `25` QTE leases, `227` focus takeovers; pinned session
  start/close và topmost pin/unpin đúng một lần;
- toàn bộ critical counter và snapshot safety counter hiệu lực bằng `0`;
- một raw `expired_actions` được đối chiếu đúng một safe pre-input policy reread,
  nên effective expiration bằng `0`;
- kết thúc đúng `FARM_TARGET_COMPLETED`, checkpoint `COMPLETED`, lifecycle
  `BOSS_LOBBY`, final invariant bounded completed;
- natural recovery `NOT_OBSERVED`; route re-entry vẫn dựa trên accepted replay
  2/2 của Phase 4C.2.

Machine-readable evidence:

- `artifacts/phase4d2_manifest.json`;
- `artifacts/phase4d2_analysis.json`;
- `artifacts/phase4d2_analysis.md`;
- `artifacts/phase4d2_full_guard_audit.json`.

## Manifest retry

Manifest chính đã được tạo lại cho source đã sửa:

- fingerprint:
  `2e9c94d5940ea803afcf769a9abc4c54ca406bd73330836002e6b6b610c7ec1c`;
- target: `25` completed matches;
- maximum: `30` attempts, khớp UI live;
- mode/config/game hash giữ nguyên;
- `farm_run_id: 018e125ba3e0442dba800f3bfd44d3af`.

Phase 4D.2 đã chốt `PASS STRONG`. Router chuyển sang
`prompts/4E1_PACKAGED_PINNED_FOREGROUND_BETA_ACCEPTANCE.md`. Không package trong
Phase 4D.2.
