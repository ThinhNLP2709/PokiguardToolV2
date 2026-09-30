# Phase 4E.1 — B1 packaged foreground report

Ngày live: 2026-09-30 (Asia/Saigon).

## Artifact

- Version: `v1.1.0`.
- SHA-256:
  `ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`.
- Input delivery: `foreground`.
- Data root:
  `D:\PokiguardToolV2\build\v1.1.0\acceptance-phase4e1-b1-r3`.

## Accepted run

- FarmRun: `16892a67a0b34eeba13172578eb05086`.
- Match: `M_2ec4f567`.
- Kết quả: 1/1 completed, 1 WIN, 0 technical abort/recovery.
- Board: 9 swap sent, 9 ACK, 0 reject, 0 pass.
- Pet Skill: một click thẻ, chuỗi 7 nút, 7/7 direction ACK, một Space,
  runtime `PERFECT`, immediate kill.
- Result: memory WIN mạnh, UI `Thắng`, `CONSISTENT`; đúng một
  `RESULT_CONFIRM`.
- Final lifecycle: `BOSS_LOBBY`, đúng Starburst LV73 tại Đảo rồng.
- Safety: mọi counter duplicate, misclick, partial, wrong-turn, stale,
  postmatch/lobby gameplay input và input-after-stop đều bằng 0.
- `packaged_console.log` hoạt động xuyên suốt; không còn `OSError(22)`.

## Kết luận

**B1 PASS STRONG.** Run setup trước đó trong cùng data root dừng fail-closed do
Pet Skill capability chưa sẵn sàng và không phát gameplay input; không được dùng
làm evidence. Acceptance chỉ định danh đúng FarmRun phía trên.
