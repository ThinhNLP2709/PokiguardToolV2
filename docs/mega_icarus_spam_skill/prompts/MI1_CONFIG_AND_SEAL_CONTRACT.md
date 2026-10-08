# MI.1 — Mega Icarus Config + Kết Ấn Contract

Implement and validate **MI.1 ONLY**.

## Entry gate

- Đọc `AGENTS.md`.
- Đọc `docs/mega_icarus_spam_skill/README.md`, `STATUS.md`, `ROUTER.md`.
- Kiểm tra HEAD/upstream/status/diff và giữ nguyên file riêng được liệt kê trong
  `STATUS.md`.
- Baseline implementation đã có `MainPetType.MEGA` và
  `EvolutionTarget.MEGA` nhưng chưa hỗ trợ; `AuditionMode` chỉ có V2/V3.

## Goal

Tạo contract cấu hình và mô hình Kết Ấn thuần túy, chưa nối policy thực chiến và
chưa gửi input.

## Required implementation

1. Thêm play style machine identity `mega_icarus_spam_skill`, label
   `Mega Icarus (Spam Skill)`.
2. Thêm Hành động skill machine identity `none`/`no_action`, label `Không có`,
   theo cách giữ tương thích field/checkpoint `audition_mode` hiện tại.
3. Validation riêng cho play style:
   - `Mega + None` hợp lệ;
   - `Mega + Normal evolution` hợp lệ;
   - `Normal + Mega evolution` hợp lệ;
   - mọi tổ hợp khác bị từ chối với blocker cụ thể;
   - damage luôn `PET_SKILL`;
   - action luôn `Không có`;
   - đúng một Mega skill source: main pet hoặc evolution target.
4. UI khi chọn style tự đặt mặc định:
   `Mega / None / Pet Skill / No Action / Sword Count / 10`;
   khóa/mở đúng radio/dropdown theo ma trận trên. Không mở Mega cho style khác.
5. Persistence/CLI/checkpoint round-trip đầy đủ; checkpoint cũ V2/V3 vẫn đọc
   như trước.
6. Tạo module pure-data cho Kết Ấn:
   - constant đúng 30 tọa độ zero-based trong README;
   - import-time/test validation: unique, trong 8x8, đúng 30;
   - API đếm physical/effective count của một `GemType` trong mask;
   - `UNKNOWN` không có credit;
   - readiness board-count dùng effective count bao hàm `>=`;
   - multiplier x2/x3 được cộng đầy đủ trong vùng Kết Ấn.

## Tests

Thêm test tập trung, tối thiểu:

- exact one-based -> zero-based mask và đủ 30 ô;
- gem ngoài mask không làm condition ready;
- 9 trong mask + nhiều gem ngoài mask vẫn false;
- effective count trong mask đạt 10 thì true, kể cả nhờ x2/x3;
- mọi loại count condition hiện có dùng đúng mask;
- `SKILL_COST_READY` không phụ thuộc mask;
- toàn bộ loadout matrix accepted/rejected;
- UI default, lock, đổi Mega/Normal, save/reopen;
- lối chơi cũ không thấy `No Action` như lựa chọn hợp lệ và không tự mở Mega;
- serialization/CLI/checkpoint round-trip.

Chạy targeted tests, full unittest suite, compileall và `git diff --check`.

## Out of scope

- không thay đổi nhánh quyết định Skill Rush;
- không click thẻ;
- không QTE/action executor;
- không live test;
- không FarmRunner navigation/re-entry/stop/window work;
- không build/package/commit/push.

## PASS STRONG

- contract cấu hình và mask đúng, không leakage;
- targeted + full suite pass;
- tạo `docs/mega_icarus_spam_skill/mi1_report.md`;
- cập nhật `STATUS.md` và trỏ current prompt sang MI.2;
- STOP, không tự bắt đầu MI.2.
