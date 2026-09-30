# Phase 4 Status

File này là con trỏ cục bộ để chat/agent sau tiếp tục mà không cần lịch sử chat.
Chỉ cập nhật `CURRENT NEXT PROMPT` sau khi phase trước đạt `PASS STRONG` hoặc
router chọn một nhánh/remediation khác từ bằng chứng thực tế.

## Snapshot lúc tạo roadmap

```text
Ngày: 2026-09-23
Source version: v1.1.0
Source commit: d48e3ecc2c0574758de480e6a2266d48d070ad6d
Branch: codex/phase3a2-board-repair
Remote branch: origin/codex/phase3a2-board-repair
Package: build/v1.1.0/PokiguardToolV2-v1.1.0-win-x64.zip
Package SHA-256: 07893149757fe4b89b2f9d2de909965531cc9ce5d9d12a3add2967ba6f5a3f3a
Package self-check: PASS
Package offline smoke: PASS
```

Snapshot này không thay thế repository truth. Agent luôn phải đọc lại Git,
version và tài liệu canonical trước khi bắt đầu.

Các file riêng tồn tại lúc tạo roadmap và không thuộc Phase 4:

```text
AGENTS.md (user-modified)
code_src.txt
code_tests.txt
code_tools.txt
docs/reverse_1.7.4_b4_player_monitoring_report.md
gop_code.py
reference/Po1m/
```

Không stage, sửa hoặc xóa chúng chỉ vì Phase 4.

## Current next prompt

```text
CURRENT PHASE: Phase 4E.1
CURRENT REMEDIATION: Phase 4A.1-R2 CLOSED — PINNED_FOREGROUND_LEASE
CURRENT RESULT: 4E.1 PASS STRONG — B1–B6 complete on one packaged artifact
CURRENT NEXT PROMPT: ROADMAP COMPLETE — STOP
LATEST REPORT: phase4e1_report.md
LATEST REMEDIATION RESEARCH: phase4a1_r1_alternative_transport_research.md
```

## Accepted capability matrix

Nguồn machine-readable hiện tại là
`artifacts/phase4a1_capability_matrix.json`. `UNKNOWN` và `UNCONFIRMED` không
được coi là hỗ trợ.

| Capability | Status | Evidence/report |
|---|---|---|
| Foreground input hiện tại | PASS STRONG | v1.1.0 accepted source/live history |
| Pinned foreground Start lease | PASS LIVE | [4A.1-R2 report](phase4a1_r2_report.md); fresh ACTIVE session ACK, focus/cursor restored |
| Pinned foreground board swap lease | PASS STRONG | [4A.1-R2 report](phase4a1_r2_report.md); first-turn exact sequence/coordinate/turn ACK, guard/focus/cursor restored |
| Pinned foreground full Pet Skill/QTE lease | PASS STRONG | [4D.2 report](phase4d2_report.md); full guard live 25/25, mỗi action 1 card, 7/7 direction ACK, 1 Space, runtime PERFECT, clean release |
| Background single mouse click | UNCONFIRMED | [4A.1 report](phase4a1_report.md); Start click queued nhưng không có fresh session/opening ACK |
| Background two-click swap | UNCONFIRMED | [4A.1 report](phase4a1_report.md); messages queued nhưng turn/sequence/last-move không đổi |
| Background drag swap | UNCONFIRMED | [4A.1 report](phase4a1_report.md); held drag + UP queued nhưng turn/sequence/last-move không đổi |
| Background card click | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); callback/payload đã reverse, delivery chưa prove |
| Background QTE directions | UNKNOWN | `Input.GetKeyDown`; per-direction RAM ACK đã map, chờ 4A.2 |
| Background Space confirm | UNKNOWN | same-generation runtime PERFECT ACK đã map, chờ 4A.2 |
| Covered-window combat | UNSUPPORTED_CURRENT_POSTMESSAGE_ROUTE | B3/B4 không có board ACK; production không được nối |
| Pinned navigation/re-entry | PASS STRONG | [4C.2 report](phase4c2_report.md); 2/2 production re-entry, native cell Button target, fresh post-focus proof và room/opening ACK sạch |
| Minimized operation | UNSUPPORTED | `NativeWin32Backend.client_geometry` rejects `IsIconic` |

## Roadmap progress

| Phase | Result | Report | Next decision |
|---|---|---|---|
| 4A.0 Transport audit | PASS STRONG | [report](phase4a0_report.md) | inventory/ACK/candidate/runbook hoàn chỉnh |
| 4A.1 Mouse live proof | BLOCKED | [report](phase4a1_report.md) | STOP; chỉ remediation nếu có hypothesis mới có bằng chứng |
| 4A.1-R1 Alternative research | TRUE_BACKGROUND_BLOCKED | [research](phase4a1_r1_alternative_transport_research.md) | VM/máy thứ hai được khuyến nghị; foreground lease là phương án phụ |
| 4A.1-R2 Pinned foreground lease | PASS STRONG | [report](phase4a1_r2_report.md) | B1/B2/B3 pass; capability là pinned foreground lease, production chưa tích hợp |
| 4A.2 Existing QTE/input lease proof | PASS STRONG | [report](phase4a2_r1_report.md) | B1/B2/B3 accepted; exact-card gate fixed; 1470 tests pass; selected capability is pinned foreground lease |
| 4B.1 Pinned lease contract/backend | PASS STRONG | [report](phase4b1_report.md) | production types/backends promoted; 151 focused and 1481 full tests pass; zero call-site integration |
| 4B.2 Board integration | PASS STRONG | [report](phase4b2_report.md) | B1 foreground 5/5 ACK; B2 Beta 3/3 ACK, including 2 external-focus takeovers; all guard/focus/cursor cleanup clean; 1498 tests pass |
| 4B.3 UI/card integration | PASS STRONG | [report](phase4b3_report.md) | 1514/1514 tests; Start + exact lobby Attack-card + board + result confirm + return lobby + unpin PASS |
| 4B.4P Pet Skill/QTE integration | PASS STRONG | [report](phase4b4p_report.md) | 1526 tests; production live 3/3 sạch: mỗi action 1 card, 7/7 ACK, 1 Space, PERFECT, cleanup complete |
| 4B.4F Full background QTE | NOT_SELECTED | — | PostMessage true-background route không được accepted |
| 4B.4H Hybrid QTE handoff | NOT_SELECTED | — | nhánh hiện tại là full existing action trong pinned foreground lease |
| 4C.1 Desktop/FarmRunner integration | PASS STRONG | [report](phase4c1_report.md) | 1537/1537 PASS; B1 foreground, B2 Beta/reposition, B3 3-match soak và B4 graceful-stop đều sạch; zero extra entry |
| 4C.2 Navigation/re-entry closure | PASS STRONG | [report](phase4c2_report.md) | 1575/1575 pass; run f591... 3/3 WIN, hai native Button re-entry cycle sạch, zero critical event |
| 4D.1 Bounded A/B acceptance | PASS STRONG | [report](phase4d1_report.md) | A/B 10/10 clean; zero critical counter |
| 4D.2 Reliability soak | PASS STRONG | [report](phase4d2_report.md) | run `018e125...`: 25/25 WIN, 25 PERFECT, full guard/ACK/cleanup sạch, zero acceptance failure |
| 4E.1 Packaged acceptance | PASS STRONG | [final report](phase4e1_report.md) | B1–B6 sạch trên một artifact; shutdown exit 0 và write audit bất biến; Phase 4 roadmap complete |

## Cách cập nhật file này

Sau mỗi phase:

1. ghi result và link report vào bảng;
2. cập nhật capability matrix chỉ bằng bằng chứng accepted;
3. chạy decision table trong `ROUTER.md`;
4. đổi `CURRENT NEXT PROMPT` sang đúng file;
5. nếu chưa `PASS STRONG`, không đánh dấu phase kế tiếp là active;
6. giữ nguyên `UNKNOWN`, `NOT_OBSERVED`, `NOT_MEASURED` khi đúng sự thật.
