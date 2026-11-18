# Biên bản kiểm tra nhánh migration tự phục vụ — 2026-11-18

- Checkpoint trước triển khai: `7abb167c0a97f1787d99cb2d415b6df71feea09d`.
- Nhánh gốc `codex/phase3a2-board-repair` vẫn ở checkpoint; chưa merge.
- Code của gói thử nghiệm: `8c2ec432`, nhánh `codex/self-service-compatibility`.
- 240 module ngoài lớp tích hợp khớp checkpoint (chuẩn hóa newline).
- 271 test liên quan PASS; đây là focused regression, không tuyên bố full
  historical suite đã xanh. Test UI cũ kỳ vọng v1.3.4 trong khi baseline là
  v1.3.6 vẫn là lỗi có sẵn; không sửa assertion đó trong feature này.

## Kiểm tra thực tế không input

Pinned Dumper3.2.1 và .NET10.0.15 portable được tải mới, kiểm hash rồi chạy
CLI trên file B17 thật. Dumper hoàn tất trong khoảng7,5 giây, tạo đủ 3 export.
Audit 39 root/55 type/69 routine và ABI/UI assets PASS; prepare giữ candidate
pending, không kích hoạt. Danh tính game sau kiểm tra vẫn khớp baseline.

UI offline đã chạy nút trong tab Cài đặt: B17 được nhận hỗ trợ sẵn, 10 render
ticks, 0 lỗi UI, 0 Start, 0 Resume, poller đóng sạch. Không có game chạy lúc
kiểm tra, không thực hiện trận đánh hay xác nhận move/ACK trên build kế tiếp.

## ZIP thử nghiệm riêng

`build/compatibility-preview-final-20261118/PokiguardToolV2-v1.3.6-win-x64.zip`

- App version giữ `v1.3.6`; đây là gói thử nhánh riêng, chưa thay gói production.
- Kích thước: `20,194,336` bytes; `1,010` file trong ZIP.
- SHA256: `f1707e1b87d58832f3111d887d286b8f06366fe534e8e5aa67279e3c78c730b1`.
- Source fingerprint: `282a9c5e8ad68a76e7545e5eadf5f76c12b4593ea62fd6882b4c8777c456faea`.
- ZIP CRC và bytes giải nén khớp; không đóng gói reverse, docs, tests, log hoặc
  preferences người dùng.
- Từ chính ZIP đã giải nén, CWD/data root riêng và xóa PYTHONPATH: cả
  `--compatibility-self-check`, `--packaging-self-check`,
  `--packaged-reasoning-self-check` đều exit0. Compatibility self-check thực
  sự nạp Capstone native library, pefile, Ed25519 backend và contract resource.
- Các self-check không attach game, gửi input hoặc cấp qualification live.

ZIP production B17 trước đó không đổi:
`build/v1.3.6-b17/PokiguardToolV2-v1.3.6-b17-win-x64.zip`, SHA256
`320ddc714a85ad20af06daf6a624311775f81144e5c34e7d7d72d4842d854983`.

Evidence local: `docs/artifacts/self_service_compatibility_20261118/`.
Catalog verifier/signing utility đã có; endpoint/public key chưa cấu hình.
Với build tiếp theo, mọi gate còn phải được chạy trên chính build đó; không
chuyển chứng nhận B17 sang build mới.
