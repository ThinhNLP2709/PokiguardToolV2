# Phase 4E.1 — B5 packaged emergency-stop report

Ngày live: 2026-09-30 (Asia/Saigon).

- Artifact SHA-256:
  `ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`.
- Data root:
  `D:\PokiguardToolV2\build\v1.1.0\acceptance-phase4e1-b5-r1`.
- FarmRun: `55fc1065438a4370ac847242d54c9a2f`.
- Match: `M_f8a9f898`; emergency stop được yêu cầu sau lượt tool đầu tiên.
- Lượt duy nhất là một swap hợp lệ và đã ACK: 1/1 sent/acknowledged.
- UI ghi ACK dừng khẩn cấp tại `2026-09-30T12:30:11.294Z`; controller trả
  `EMERGENCY_STOP`, chuyển `STOPPED`, `active=false`, checkpoint kết thúc
  `EMERGENCY_STOPPED` với lý do `F9_EMERGENCY_STOP`.
- Các snapshot sau ACK giữ nguyên `total_gameplay_inputs=1` và
  `autonomous_inputs_after_emergency_ack=0`; không có input, trận mới hoặc kết
  quả giả sau ACK.
- Run có đúng một pin/unpin. Lease của swap đã nhả cursor guard trước ACK;
  run-scope pin được nhả và session đóng ngay khi controller trả về.
- Tool UI tiếp tục responsive; mọi safety counter bằng 0.

**B5 PASS STRONG.**
