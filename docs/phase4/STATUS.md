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
CURRENT PHASE: Phase 4B.1
CURRENT REMEDIATION: Phase 4A.1-R2 CLOSED — PINNED_FOREGROUND_LEASE
CURRENT RESULT: 4A.2-R1 PASS STRONG — pinned foreground existing-input QTE lease accepted
CURRENT NEXT PROMPT: prompts/4B1_PINNED_FOREGROUND_LEASE_CONTRACT_BACKEND.md
LATEST REPORT: phase4a2_r1_report.md
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
| Pinned foreground full Pet Skill/QTE lease | PASS STRONG | [4A.2-R1 report](phase4a2_r1_report.md); external foreground takeover, 1 card, 7/7 direction ACK, 1 Space, runtime PERFECT, clean release |
| Background single mouse click | UNCONFIRMED | [4A.1 report](phase4a1_report.md); Start click queued nhưng không có fresh session/opening ACK |
| Background two-click swap | UNCONFIRMED | [4A.1 report](phase4a1_report.md); messages queued nhưng turn/sequence/last-move không đổi |
| Background drag swap | UNCONFIRMED | [4A.1 report](phase4a1_report.md); held drag + UP queued nhưng turn/sequence/last-move không đổi |
| Background card click | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); callback/payload đã reverse, delivery chưa prove |
| Background QTE directions | UNKNOWN | `Input.GetKeyDown`; per-direction RAM ACK đã map, chờ 4A.2 |
| Background Space confirm | UNKNOWN | same-generation runtime PERFECT ACK đã map, chờ 4A.2 |
| Covered-window combat | UNSUPPORTED_CURRENT_POSTMESSAGE_ROUTE | B3/B4 không có board ACK; production không được nối |
| Covered-window navigation/re-entry | UNKNOWN | screen-DC visual dependency đã xác nhận tại 4A.0 |
| Minimized operation | UNSUPPORTED | `NativeWin32Backend.client_geometry` rejects `IsIconic` |

## Roadmap progress

| Phase | Result | Report | Next decision |
|---|---|---|---|
| 4A.0 Transport audit | PASS STRONG | [report](phase4a0_report.md) | inventory/ACK/candidate/runbook hoàn chỉnh |
| 4A.1 Mouse live proof | BLOCKED | [report](phase4a1_report.md) | STOP; chỉ remediation nếu có hypothesis mới có bằng chứng |
| 4A.1-R1 Alternative research | TRUE_BACKGROUND_BLOCKED | [research](phase4a1_r1_alternative_transport_research.md) | VM/máy thứ hai được khuyến nghị; foreground lease là phương án phụ |
| 4A.1-R2 Pinned foreground lease | PASS STRONG | [report](phase4a1_r2_report.md) | B1/B2/B3 pass; capability là pinned foreground lease, production chưa tích hợp |
| 4A.2 Existing QTE/input lease proof | PASS STRONG | [report](phase4a2_r1_report.md) | B1/B2/B3 accepted; exact-card gate fixed; 1470 tests pass; selected capability is pinned foreground lease |
| 4B.1 Pinned lease contract/backend | ACTIVE | — | typed production contract/backend only; no call-site integration |
| 4B.2 Board integration | PENDING | — | after 4B.1 PASS STRONG |
| 4B.3 UI/card integration | PENDING | — | after 4B.2 PASS STRONG |
| 4B.4P Pet Skill/QTE integration | PENDING | — | after 4B.3 PASS STRONG |
| 4B.4F Full background QTE | NOT_SELECTED | — | PostMessage true-background route không được accepted |
| 4B.4H Hybrid QTE handoff | NOT_SELECTED | — | nhánh hiện tại là full existing action trong pinned foreground lease |
| 4C.1 Desktop/FarmRunner integration | PENDING | — | sau B-series accepted |
| 4C.2 Navigation/re-entry closure | PENDING | — | route theo visual/native evidence |
| 4D.1 Bounded A/B acceptance | PENDING | — | sau UI/Farm integration |
| 4D.2 Reliability soak | PENDING | — | sau 4D.1 PASS STRONG |
| 4E.1 Packaged acceptance | PENDING | — | sau soak PASS STRONG |

## Cách cập nhật file này

Sau mỗi phase:

1. ghi result và link report vào bảng;
2. cập nhật capability matrix chỉ bằng bằng chứng accepted;
3. chạy decision table trong `ROUTER.md`;
4. đổi `CURRENT NEXT PROMPT` sang đúng file;
5. nếu chưa `PASS STRONG`, không đánh dấu phase kế tiếp là active;
6. giữ nguyên `UNKNOWN`, `NOT_OBSERVED`, `NOT_MEASURED` khi đúng sự thật.
