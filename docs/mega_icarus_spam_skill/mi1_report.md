# MI.1 — Config + Kết Ấn report

Ngày kiểm tra: 2026-10-01
Kết quả: **PASS STRONG**

## Kết quả triển khai

- Thêm lối chơi ổn định `mega_icarus_spam_skill`, hiển thị
  `Mega Icarus (Spam Skill)`.
- Thêm Hành động skill `none`, hiển thị `Không có`, trong field persistence
  `audition_mode` hiện tại. Giá trị V2/V3 cũ giữ nguyên identity và round-trip.
- Khóa đúng ba loadout Mega Icarus hợp lệ:
  - `Mega / Không tiến hóa`;
  - `Mega / Tiến hóa pet thường`;
  - `Pet thường / Tiến hóa pet Mega`.
- Mỗi loadout hợp lệ có đúng một nguồn Mega skill. Thẻ được cố định là
  `Thẻ skill của pet`; Hành động skill được cố định là `Không có`.
- UI đặt mặc định `Mega / Không tiến hóa / Thẻ skill của pet / Không có /
  Kiếm đủ / 10`, cho đổi đúng ma trận Mega/Normal và không mở Mega hoặc
  `Không có` ở các lối chơi cũ.
- Persistence, CLI, preference và checkpoint giữ đủ profile mới. Profile cũ
  V2/V3 vẫn đọc lại đúng như trước.
- Tạo mô hình dữ liệu Kết Ấn gồm đúng 30 tọa độ zero-based đã duyệt. Theo điều
  chỉnh từ live B2 ngày 2026-10-02, readiness dùng effective count trong mask
  với phép so sánh bao hàm `>=`; x2/x3 được cộng đầy đủ và `UNKNOWN` không có
  credit.
- `Đủ mana skill` nhận readiness từ capability và không phụ thuộc board/mask.

## Fail-closed ở ranh giới MI.1

MI.1 chưa nối policy và chưa gửi input. Profile hợp lệ trả blocker
`MEGA_ICARUS_POLICY_NOT_IMPLEMENTED`, vì vậy Desktop chưa cho Start profile
này. MI.2 sẽ thay blocker bằng policy tái sử dụng Skill Rush và action click
thẻ một lần, không gửi hướng/Space.

## Bằng chứng test

- `tests.test_mega_icarus_config`: **9/9 PASS**.
- `tests.test_pet_configuration`: **40/40 PASS**.
- `tests.test_pet_configuration_ui`: **22/22 PASS**.
- `tests.test_desktop_preferences` + `tests.test_farm_checkpoint`:
  **51/51 PASS**.
- Full unittest discovery: **1.635/1.635 PASS**.
- `python -m compileall -q src tests tools`: **PASS**.
- `git diff --check`: **PASS**.

Không chạy live test, build, package, commit hoặc push trong MI.1 theo phạm vi
đã khóa của mini-plan.
