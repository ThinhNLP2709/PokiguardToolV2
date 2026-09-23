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
CURRENT PHASE: Phase 4A.1
CURRENT RESULT: Phase 4A.0 PASS STRONG
CURRENT NEXT PROMPT: prompts/4A1_BACKGROUND_MOUSE_LIVE_PROBE.md
LATEST REPORT: phase4a0_report.md
LATEST REMEDIATION: NONE
```

## Accepted capability matrix

`UNKNOWN` không được coi là hỗ trợ.

| Capability | Status | Evidence/report |
|---|---|---|
| Foreground input hiện tại | PASS STRONG | v1.1.0 accepted source/live history |
| Background single mouse click | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); chờ 4A.1 live ACK |
| Background two-click swap | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); exact SWAP ACK đã map, transport chưa live-prove |
| Background drag swap | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); hypothesis tách riêng two-click |
| Background card click | UNKNOWN | [4A.0 audit](phase4a0_transport_audit.md); callback/payload đã reverse, delivery chưa prove |
| Background QTE directions | UNKNOWN | `Input.GetKeyDown`; per-direction RAM ACK đã map, chờ 4A.2 |
| Background Space confirm | UNKNOWN | same-generation runtime PERFECT ACK đã map, chờ 4A.2 |
| Covered-window combat | UNKNOWN | memory state thuận lợi nhưng SWAP production còn modal screen-DC proof |
| Covered-window navigation/re-entry | UNKNOWN | screen-DC visual dependency đã xác nhận tại 4A.0 |
| Minimized operation | UNSUPPORTED | `NativeWin32Backend.client_geometry` rejects `IsIconic` |

## Roadmap progress

| Phase | Result | Report | Next decision |
|---|---|---|---|
| 4A.0 Transport audit | PASS STRONG | [report](phase4a0_report.md) | inventory/ACK/candidate/runbook hoàn chỉnh |
| 4A.1 Mouse live proof | NEXT | — | tạo isolated bounded harness; user điều khiển live |
| 4A.2 QTE keyboard live proof | PENDING | — | phụ thuộc mouse/card trigger evidence |
| 4B.1 Mode contract/backend | PENDING | — | phụ thuộc capability matrix A-series |
| 4B.2 Board integration | PENDING | — | chỉ mode swap đã proven |
| 4B.3 UI/card integration | PENDING | — | chỉ click domain đã proven |
| 4B.4F Full background QTE | CONDITIONAL | — | chỉ khi 4A.2 full PASS STRONG |
| 4B.4H Hybrid QTE handoff | CONDITIONAL | — | khi keyboard nền không được proven |
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
