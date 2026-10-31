# 5C.3 — AI log rotation collision remediation

Ngày 2026-10-11. Parent: [C3](5c3_report.md). Scope: dedicated AI logger only;
không phải lỗi room/re-entry hoặc chẩn đoán một live farm incident.

## Exact cause

V2 full regression:1963/1964 PASS, failure ở
`DiagnosticsTests.test_real_writer_rotation_retention_and_ack_accounting`.
[Failed suite](../artifacts/5c3_integration_v2/full_regression.log).
Declared30-trial diagnosis tái hiện2 failures:
[raw](../artifacts/5c3_integration_v2/rotation_diagnosis.json),
[batch script](../artifacts/5c3_integration_v2/diagnose_rotation.py).

Writer dùng `time.time_ns()` làm tên và exclusive `open('xb')`. Hai rotations
trong cùng wall-clock tick nhận cùng tên, gây `FileExistsError`. Failure xảy ra
sau khoảng398–419ms, không phải flush timeout5s. Mỗi lần viết2, failed1,
discard7/10; accounting vẫn đúng, AI sink degraded. Đây là lỗi đã tái hiện,
không suy đoán từ scheduling spike. Không có evidence BASIC phát input sai
hoặc dừng game do lỗi này; asynchronous logger có failure isolation.

## Narrow fix

[reasoning_diagnostics.py](../../../src/pokiguard_v2/reasoning_diagnostics.py):
stamp mới lớn hơn previous stamp và numeric filenames đang có, cùng giá trị
`now` làm lower bound. Dùng lại list paths đã enumerate; không thêm filesystem
scan, observer/poll/thread/process hoặc work trên action path. Giữ filename
20-digit numeric format, oldest-first ordering, retention count/age, JSON,
write/ACK/error handling và cleanup/cancel.

Thêm đúng một retained integer trong logger child, không queue/history tăng
theo thời gian. Không sửa BASIC, planner scoring, provider/memory/capture,
executor, preflight/action/ACK/QTE/Stop, navigation/recovery, settings/version.
Trên nguồn C3 V1:248/250 files byte-preserved; hai khác biệt là AI logger
filename code và đúng source-audit test method. Sáu new offline tool/test files
của C3 tiếp tục riêng; không giả250/250 vẫn byte-identical.

[Pre-fix source archive/hash](../artifacts/5c3_rotation_remediation_v1/before.json).
Source compatibility helper xác nhận exact two new assignments/path expression,
pure filename helper và AST mọi phần còn lại của logger; AST mọi integration
Stop/fault/controller test method khác giữ. Không đổi assertions gameplay để
ép parity hoặc nới limits.

## Verification and return gate

- Pure frozen/backward clock +preexisting-name controls.
- 30 native trials với frozen clock và preexisting filename:300/300written,
  bounded2files; source/retention/accounting checks. Final raw nằm trong
  [V3 integration trials](../artifacts/5c3_integration_v3/integration_raw.jsonl).
- Chạy mới post-fix30min resource soak, three paired sink CPU comparisons,
  disabled probe và full regression. Result chỉ theo
  [C3 final verification](../artifacts/5c3_integration_v3/verification.json).
- V2 publication latency reuse có compatibility gate: codec/admission/Stop
  byte-preserved, benchmark AST unchanged; chỉ off-path filename code thay.
  Không gọi copied raw là run mới. B4 cancellation/native injected fault code
  giữ AST; filename correction kiểm riêng và corrected-source healthy soak.
- Failed V2 suite/diagnosis và original pre-fix measurements giữ nguyên;
  không retry đến xanh, không sửa numeric SLO. Native disk/scheduler max vẫn
  unbounded/descriptive, không gán IO stall thành causal AI overhead.

Return gate: post-fix gates đủ → C3 PASS_OFFLINE_LIVE_PENDING, C4 offline only;
không build/version/Git/live hoặc tự thực hiện C4. Live C3 closure vẫn bắt buộc
trước D1. Báo cáo này không tự cấp acceptance độc lập với C3 verification.

V3 first full regression còn2source-audit failures (1964/1966 PASS) vì audit
allowlist thiếu builtin `len`, dù native frozen-clock rotation đã PASS. Đã
sửa riêng offline audit, chạy2targeted checks PASS rồi fresh disabled/full
regression. [Failed audit run](../artifacts/5c3_integration_v3/audit_remediation_v1/full_regression.log)
và [pre-fix helper/hash](../artifacts/5c3_integration_v3/audit_remediation_v1/before.json)
giữ nguyên. Runtime fix không đổi thêm; không lấy failed suite làm final PASS.
