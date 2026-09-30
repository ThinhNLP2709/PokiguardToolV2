# Phase 4E.1 — B6 packaged shutdown/write audit

Ngày audit: 2026-09-30 (Asia/Saigon).

- Packaged UI đóng theo đường bình thường; startup log ghi
  `packaged_app_finished`, `exitCode=0` tại `2026-09-30T16:19:30.437Z`.
- Desktop poller ghi `poller_stopped`; không còn process
  `PokiguardToolV2`. Controller đã dừng và run-scope pin/input guard đã đóng.
- Game process PID 28056 vẫn chạy, responsive và giữ nguyên cửa sổ
  `PokiguardOnlines`.
- ZIP giữ nguyên SHA-256
  `ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`.
- So sánh byte-for-byte ZIP với extracted bundle: đúng 994/994 file,
  30,420,169 byte; 0 missing, 0 extra, 0 changed.
- Production source fingerprint vẫn là
  `23b7fcc5411fb3645527357de68ad5fd15ea20c483e346b8d40853398782d815`
  trên đúng 126 file nguồn đã khóa.
- Bốn hash game vẫn khớp manifest: executable `ebf152bd...`, GameAssembly
  `e2a24571...`, UnityPlayer `bb93aa06...`, metadata `b9e06bed...`.
- Không có file trong game install hoặc extracted bundle được ghi sau khi
  packaged app khởi động. Không có runtime write trong repository ngoài các
  data root acceptance; thay đổi dưới `docs/phase4` là báo cáo do agent ghi sau
  live test.

Một run 100 trận do operator bắt đầu sau B5 không thuộc B1–B6. Run đó hoàn
thành 17/100 rồi fail-closed tại boss lobby với `FARM_RUN_INTERNAL_INVARIANT`
(`native_card_ui: transform job pending`). Sự kiện này không làm thay đổi kết
quả shutdown/write audit, nhưng được giữ làm observation cho remediation riêng
nếu người dùng muốn xử lý long-run tiếp theo.

**B6 PASS STRONG.**
