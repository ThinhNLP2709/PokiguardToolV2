# Phase 4E.1 — Pre-B1 packaged stdout incident

Ngày phân tích và remediation: 2026-09-30 (Asia/Saigon).

## Hiện tượng

Data root `acceptance-phase4e1-b1-r2` ghi nhận ba lần Start, cả ba dừng ở
`ENTRY_READY` trước input đầu tiên:

- `accbeb27831f4e0fa340f1d36acff59c`;
- `4e274bc76bd84df18846e9a99c4a7b12`;
- `4345740dac844f57bd4d4347ac79b801`.

Cả ba có `completed_matches=0`, `total_gameplay_inputs=0`,
`total_lobby_inputs=0` và dừng bằng `FARM_RUN_INTERNAL_INVARIANT` với
`OSError: [Errno 22] Invalid argument`.

## Nguyên nhân đã chứng minh

EXE dùng PyInstaller `console=False`, trong khi FarmRunner và boss-entry vẫn
chạy in-process và có console diagnostics bằng `print`. Khi EXE được mở từ một
launcher có console handle tạm thời, handle kế thừa có thể hết hiệu lực sau khi
launcher kết thúc. Lệnh `print` tiếp theo trong boss-entry ném `OSError(22)` và
làm runner fail-closed trước khi phát input.

Traceback của ba run đặt lỗi tại các lệnh `print` trong `tools/boss_entry.py`,
gồm transition `ENTRY_READY -> RESOLVE_TARGET` và banner đầu entry. Đây không
phải lỗi board, policy, QTE hay thao tác Alt-Tab của người dùng.

## Sửa đổi

`src/pokiguard_v2/windows_entry.py` hiện chuyển `sys.stdout` và `sys.stderr`
của bản frozen sang file append-only
`logs/startup/packaged_console.log` ngay sau khi tạo data root. Stream được giữ
suốt vòng đời tiến trình. Source launcher tiếp tục dùng terminal bình thường.

## Xác minh offline

- packaging test chuyên biệt mô phỏng controller `print`: PASS;
- focused packaging/app-path: 15/15 PASS;
- full regression: 1612/1612 PASS;
- compileall: PASS;
- packaged self-check: exit 0, có `consoleLog` hợp lệ và
  `packaged_self_check_passed`;
- artifact mới:
  `ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`.

B1 phải chạy lại bằng data root sạch và artifact hash mới; ba run lỗi không
được dùng làm acceptance evidence.
