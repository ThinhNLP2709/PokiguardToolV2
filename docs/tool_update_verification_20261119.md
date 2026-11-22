# Biên bản updater và pipeline — 2026-11-19

Ghi chú22/11: đây là biên bản lịch sử của nhánh updater. Tính năng hiện đã có
trên `main` cùng Demon; các số đo/ZIP bên dưới vẫn thuộc commit19/11, không
nghiệm thu lại source mới. [Biên bản tích hợp mới](main_integration_20261122.md).

Triển khai trên `codex/self-service-compatibility`, code kiểm tra tại
`b7f197d1`. Không merge vào main. Nhánh gốc local
`codex/phase3a2-board-repair` vẫn ở checkpoint `7abb167c`.

## Kết quả

- 294 focused regression tests PASS trên máy phát triển; 23 test updater PASS
  sau khi khóa contract artifact ZIP phẳng. Không tuyên bố full historical
  suite đã xanh.
- UI offline ở 460x680: nhận phiên bản mới, nút cài được mở, Start/Resume bị
  chặn khi cập nhật, đóng giữa tải hủy sạch; 0 lỗi render, 0 Start/Resume,
  poller dừng. Cài đặt có scrollbar để các tùy chọn cũ vẫn truy cập được.
- ZIP local qua 5 EXE checks: updater, compatibility, packaging, packaged
  reasoning và health-check, CWD/data root riêng, không PYTHONPATH.
- Helper EXE thật nâng từ build1 lên build2, thay cả bundle, loại marker cũ,
  giữ nguyên backup và dữ liệu preferences/profile.
- Helper EXE thật với build3 thiếu reset resource: health-check thất bại,
  khôi phục byte-for-byte bộ build1, preferences/profile còn nguyên.
- Không attach game hoặc gửi input game trong những kiểm tra updater trên.
  Helper chỉ query/wait đúng process tool cũ và chạy child health-check của nó.
- 240 module ngoài lớp tích hợp vẫn khớp checkpoint qua fixture bảo vệ
  gameplay. Không đổi solver, policy, pacing, jitter hoặc input executor.

## CI/CD đã chạy thực tế

- [Branch CI PASS](https://github.com/ThinhNLP2709/PokiguardToolV2/actions/runs/44388251327).
- [Preview CI/CD PASS](https://github.com/ThinhNLP2709/PokiguardToolV2/actions/runs/44388251703):
  verify job và draft-release job đều thành công.
- Secret `UPDATE_SIGNING_KEY_B64` đã cấu hình qua sealed-box encryption;
  private key ở AppData publisher, không ở Git/client/ZIP. Public key ID
  `56d3d4e75cee7c53`.
- Replay JSONL giữ nguyên byte qua checkout Windows; không sửa manifest hash
  hay nới validator. Các Actions pin commit Node24.
- ZIP đã kiểm và biên bản là hai artifact riêng. Job ký lấy đúng ZIP đã qua
  verify, không rebuild hoặc thay assets đã phát hành.

## Draft Release và gói đã tải kiểm lại

[Draft preview.2](https://github.com/ThinhNLP2709/PokiguardToolV2/releases/tag/untagged-bb857b478ac308468c9e)
đã tạo: **draft=true, prerelease=true, chưa Publish**, tag
`v1.3.6-updater-preview.2`, release ID `450503994`.

- App `v1.3.6`, build `5` (Actions run number).
- ZIP `PokiguardToolV2-v1.3.6-win-x64.zip`, 20,186,414 bytes, 1,012 files.
- SHA256 `aefdb199bce959b827fcd13066f2051f269083dbddc96e458676f17f4dc4b2c4`.
- Source fingerprint
  `666d13bc00c5fbfdf4140ccd5ff9722b1680bcd8e569eddd8f825219674cef3f`.
- ZIP và update.json tải từ chính Draft đã kiểm lại chữ ký, SHA/size, source
  fingerprint khớp source hiện tại; giải nén và cả 5 EXE checks lại PASS trên
  máy phát triển. Không có reverse, docs, tests, log, preferences hoặc PEM trong ZIP.
- Bản tải local: `build/github-updater-preview-20261119/`.

ZIP production B17 cũ vẫn giữ SHA256
`320ddc714a85ad20af06daf6a624311775f81144e5c34e7d7d72d4842d854983`.

Evidence local: `docs/artifacts/tool_updater_20261119/`. Không live trận đánh
và không tự chuyển qualification cũ sang source/build mới.

## Phát hành khi sẵn sàng

Owner review Draft và artifact trước. Khi muốn phát hành stable, bỏ prerelease
và chọn Set as latest release rồi Publish; hiện updater không đưa preview vào
kênh stable. Người dùng cần cài thủ công một lần bản có updater, từ các lần sau
mới bấm cập nhật trong app. Chi tiết ở [hướng dẫn](tool_update_release.md).
