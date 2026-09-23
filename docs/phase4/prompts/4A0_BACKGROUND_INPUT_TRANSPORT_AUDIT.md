# Phase 4A.0 — Background Input Transport Audit

Implement **Phase 4A.0 ONLY** for `PokiguardToolV2`.

Đây là phase audit/read-only. Không gửi input vào game và không nối background
mode vào production.

## 0. Read first

Đọc:

1. `AGENTS.md`;
2. `docs/phase4/README.md`;
3. `docs/phase4/STATUS.md`;
4. `docs/phase4/ROADMAP.md`;
5. `docs/phase4/ROUTER.md`;
6. `docs/CURRENT_STATE.md` và `docs/DECISIONS.md`;
7. `src/pokiguard_v2/win32_input.py`;
8. `src/pokiguard_v2/win32_screenshot.py`;
9. foreground/actionability gates trong `farm_run`, `farm_cycle`, Pet Skill/QTE,
   entry và recovery;
10. V1 `PokiguardAuto/pokiguard_auto/win32.py`, engine/UI/README dưới dạng
    reference-only;
11. reverse/docs hiện hành về board drag, card click và QTE input transport.

Trước khi làm:

```text
git status --short
git rev-parse HEAD
git rev-parse @{u}
git diff --stat
```

Không stage/revert các file riêng được ghi trong `STATUS.md`.

## 1. Exact goal

Tạo một capability/transport audit đủ chính xác để phase live probe không cần
đoán:

- liệt kê mọi production input domain;
- nơi tạo input permit;
- nơi foreground được kiểm tra;
- Windows primitive hiện dùng;
- tọa độ client/screen;
- pre-state và authoritative ACK hiện có;
- visual/screenshot dependency;
- behavior khi game covered/minimized;
- transport candidate cho background;
- điều kiện fail closed và log cần có.

Input domains tối thiểu:

```text
board two-click
board drag
single UI click
Start / retry
card selection
EVOLVE / default CAST / Pet Skill card
result confirm
room exit/confirm
map/island/boss re-entry
QTE direction
QTE Space
technical recovery
```

## 2. Required evidence

Đối chiếu V1 Beta chính xác:

- message sequence;
- coordinate packing;
- return-value handling;
- lack/presence of ACK;
- capture visibility requirement;
- test coverage thực tế.

Đối chiếu V2:

- `ForegroundClickExecutor` two-click/drag/single point;
- `NativeWin32Backend` mouse/keyboard primitive;
- QTE direction/Space gate;
- FarmRun/FarmCycle permit gate;
- visual proof dùng screen DC;
- state ACK sau từng action.

Phân biệt:

```text
CONFIRMED_FROM_CODE
CONFIRMED_FROM_REVERSE
CONFIRMED_FROM_PRIOR_LIVE
INFERRED
UNKNOWN
```

Không dùng `PostMessageW` return value làm game acceptance.

## 3. Deliverables

Tạo:

- `docs/phase4/phase4a0_transport_audit.md`;
- `docs/phase4/phase4a0_live_probe_runbook.md`;
- machine-readable capability matrix nếu hữu ích, ví dụ
  `docs/phase4/artifacts/phase4a0_capability_matrix.json`.

Audit phải chỉ ra transport candidate tối thiểu cho:

```text
single click: client WM_MOUSEMOVE/DOWN/UP
two-click: two bounded single-click sequences
drag: DOWN + ordered MOVE(MK_LBUTTON) + unconditional UP
direction/Space: candidates only; no claim before live ACK
```

Mỗi candidate phải có testable hypothesis và stop rule.

## 4. Offline validation

Phase này không cần thêm production implementation. Chỉ thêm test nếu phát hiện
một helper/audit parser thực sự cần thiết; không viết test giả chỉ mirror docs.

Chạy:

- focused tests liên quan input/window/QTE/package nếu code bị chạm;
- full regression nếu production code bị chạm;
- `python -m compileall -q src tools tests` nếu Python bị chạm;
- `git diff --check` luôn bắt buộc.

Docs-only audit không cần full regression nếu không có code/config change; ghi
rõ lý do và kiểm tra mọi local link.

## 5. PASS

PASS khi:

- inventory đầy đủ;
- không còn foreground gate hoặc input domain quan trọng bị bỏ sót;
- candidate và ACK được ghi rõ;
- UNKNOWN được giữ đúng;
- runbook live probe bounded và không retry mù.

## 6. PASS STRONG

PASS STRONG = PASS cộng:

- capability matrix có evidence source cho từng ô;
- exact files/functions/line anchors được ghi;
- separate hypotheses cho two-click và drag;
- QTE directions và Space tách riêng;
- visual dependency/covered/minimized được chốt rõ;
- `STATUS.md` được cập nhật và router chọn chính xác 4A.1;
- focused audit commit/push theo workflow hiện tại nếu phase được chốt.

## 7. Blockers

Block nếu:

- không xác định được HWND/client-coordinate contract;
- không xác định được ACK cho một action định live-test;
- audit yêu cầu sửa V1 hoặc game;
- proposal dựa vào direct game/network method;
- production foreground gate bị gỡ trong phase này.

## 8. Final report and routing

Dùng `docs/phase4/HANDOFF_TEMPLATE.md` và tạo
`docs/phase4/phase4a0_report.md`.

Chỉ khi `PASS STRONG`:

```text
CURRENT NEXT PROMPT = prompts/4A1_BACKGROUND_MOUSE_LIVE_PROBE.md
```

Nếu chưa đủ, giữ phase 4A.0 hoặc tạo `4A.0-R1`.

## 9. Explicit stop

STOP sau audit/docs/validation/checkpoint. Không gửi background input, không tạo
production backend và không bắt đầu 4A.1 trong cùng phase.
