# Phase 4E.1 — Packaged Pinned Foreground Beta Acceptance

Ngày chốt acceptance: 2026-09-30 (Asia/Saigon).

Artifact duy nhất được kiểm tra:

```text
Version: v1.1.0
ZIP: D:\PokiguardToolV2\build\v1.1.0\PokiguardToolV2-v1.1.0-win-x64.zip
SHA-256: ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5
```

Kết quả acceptance:

| Bài | Kết quả | Evidence chính |
|---|---|---|
| B1 foreground | PASS STRONG | 1/1 WIN, 9/9 swap ACK, Pet Skill PERFECT |
| B2 Beta/QTE | PASS STRONG | 1/1 WIN, 4/4 swap ACK, 7/7 direction + Space |
| B3 multi/re-entry | PASS STRONG | 3/3 WIN, native Starburst re-entry sạch |
| B4 checkpoint/resume | PASS STRONG | graceful 1/3, đóng/mở, resume đúng lên 3/3 |
| B5 emergency stop | PASS STRONG | dừng sau 1 swap ACK, zero input sau ACK |
| B6 shutdown/write audit | PASS STRONG | exit 0, process sạch, artifact/source/game bất biến |

Offline gate: 1612/1612 full regression, 15/15 packaging-focused,
`compileall`, diff-check, self-check và offline UI đều PASS. Package dùng data
root tách biệt, không tự Start/Resume và không ghi cạnh EXE.

Capability được phát hành đúng tên: game visible/topmost với bounded foreground
takeover. Minimized và true-background `PostMessage` không được quảng bá.

Acceptance commit `5f135696` đã được tạo và branch
`codex/phase3a2-board-repair` được push theo yêu cầu chốt. Tag/release publish
chưa thực hiện.

**Phase 4E.1 PASS STRONG. Phase 4 acceptance roadmap hoàn tất.**
