# Cập nhật tool và pipeline phát hành

Đã tích hợp vào `main` cùng checkpoint Demon ngày22/11/2026. Nhánh triển khai
gốc là `codex/self-service-compatibility`; riêng updater không sửa solver,
policy, pacing hoặc input. Các release/ZIP cũ được giữ nguyên.
[Phạm vi và kiểm tra tích hợp](main_integration_20261122.md).

## Người dùng

**v1.3.7 là bản bàn giao đầu tiên có nút cập nhật trong app.** Khách đang dùng
ZIP1.3.6 cũ tải/giải nén1.3.7 thủ công một lần; ZIP1.3.6 đã gửi trước đây
không được sửa hoặc tự thêm nút từ xa. Các preview updater1.3.6 là bản thử
riêng, không phải ZIP production1.3.6 cũ.

Trong **Cài đặt → Cập nhật tool**, bấm **Kiểm tra cập nhật**, đọc phiên bản/nội
dung rồi bấm **Cập nhật và mở lại**. Không thao tác khi FarmRunner/migration
đang chạy. Chạy source chỉ kiểm tra; cài update qua bản EXE.

Bản portable đầu tiên có updater phải được tải và giải nén thủ công. Từ bản
đó mới cập nhật trong app. Giải nén app vào thư mục riêng có EXE và `_internal`,
không đặt chung với game, source hoặc dữ liệu khác. Mất mạng, chưa có manifest,
chữ ký sai hoặc tải hỏng không ảnh hưởng bản hiện tại.

Sau update, app mở lại ở trạng thái chưa Start/Resume. Preferences, log,
checkpoint và profile trong `%LOCALAPPDATA%\PokiguardToolV2` được giữ lại.
Profile/qualification cũ vẫn phải khớp contract/hash/source; cập nhật app không
tự rebind hoặc cấp quyền gameplay trên build mới.

## Cơ chế

- Nguồn: GitHub Releases của `ThinhNLP2709/PokiguardToolV2`, asset `update.json`
  ở `releases/latest/download/update.json`. Google Drive không nằm trong đường
  tải tự động.
- Manifest stable Windows x64 có version/build, URL asset cố định theo tag,
  kích thước, SHA256, source fingerprint và chữ ký Ed25519. Public key pin trong
  resource; private key không vào Git, ZIP hoặc client. Domain ký riêng với
  catalog compatibility.
- So sánh số SemVer rồi build; từ chối downgrade/cài lại. Build tăng độc lập
  nên các lần sửa cùng version vẫn được nhận diện.
- Tải/giải nén/copy helper trong AppData. Chỉ sau xác minh mới đóng UI. Helper
  ở ngoài thư mục cài đặt, đợi đúng process tool cũ thoát, giữ desktop/controller
  lease, rồi xác minh lại ZIP trước swap.
- Thay cả bộ app trên cùng volume bằng rename. Bản cũ giữ tại thư mục sibling
  `.Pokiguard-update-<job>/previous`. Không giữ DLL cũ lẫn vào bộ mới.
- New EXE chạy health-check không game/input trong data root riêng. Receipt có
  nonce, version/build và source hash. PASS mới commit; FAIL khôi phục đúng bộ
  cũ và mở lại. Chặn mọi đường dẫn nằm trong game và thư mục không phải bundle.
- Không xóa backup/job tự động. Khi mất điện/crash giữa swap, có journal và
  helper còn nguyên để chạy lại: `<job>\helper\PokiguardToolV2.exe
  --apply-tool-update <job>`. Nếu helper phục hồi trạng thái interrupted, mở
  EXE cũ thủ công sau khi nó hoàn tất. Không hứa rollback tự động khi OS dừng.

Nhật ký: `AppData\Local\PokiguardToolV2\updates\jobs\<id>\transaction.json`;
startup/packaged_console.log giữ lỗi helper. Nút update không sửa file game,
gọi API game hoặc gửi input.

## Thiết lập maintainer một lần

```powershell
python -m pip install -r requirements-build.txt
python -m pip install -r requirements-publisher.txt
python scripts/configure_tool_updates.py
python scripts/setup_github_release.py --configure-secret
```

Script key tạo/reuse PEM tại
`%LOCALAPPDATA%\PokiguardToolV2\publisher\update-signing.pem`. Cần sao lưu khóa
này để tiếp tục ký cho client đã phát hành. Không đưa PEM/base64 vào chat, Git,
release hoặc log. Public key ID hiện tại: `56d3d4e75cee7c53`.

Script setup dùng đăng nhập GitHub hiện có (GH_TOKEN/GITHUB_TOKEN hoặc Git
Credential Manager), kiểm key khớp pin rồi mã hóa libsodium sealed box trước
khi tạo repository secret **UPDATE_SIGNING_KEY_B64**. Client không có GitHub
token. Script không log credential hoặc plaintext signing key.

## Pipeline

`.github/workflows/windows-release.yml`:

1. Push `main`/`codex/**`, PR, tag `v*` hoặc manual dispatch → Windows2022,
   Python3.11 x64, pinned dependencies/actions, focused offline regression.
2. Build ZIP đầy đủ, giải nén và chạy các self-check EXE, health-check; không
   có game installation/reverse riêng hoặc live input trên runner.
3. Chỉ tag/manual dispatch mới tải lại **đúng artifact đã kiểm**, ký manifest,
   kiểm lại gói đã ký rồi tạo **Draft Release**. Tag preview/alpha/beta/rc còn
   được đánh dấu prerelease. Không tự Publish, thay assets hay merge code.
4. Maintainer kiểm artifact/live cần thiết, mở Draft và Publish; bản stable cần
   chọn **Set as latest release**. Client đọc stable latest; prerelease không
   được tự nhận thành production update.

Build mặc định bằng Actions run number; manual dispatch có thể nhập build
lớn hơn. Tag không tự đổi version trong code. Khi tăng SemVer, sửa version và
các assertion version liên quan trước; manifest và package phải đồng bộ.

Sau khi push `main`, workflow có trên default branch và có thể dùng
`workflow_dispatch`. Push nhánh chỉ chạy verify/build, không tự tạo Draft hoặc
Publish. Cũng có thể tạo tag mới trỏ đúng commit đã kiểm; không dùng lại tag cũ:

```powershell
git tag <tag-moi> <commit-da-kiem>
git push origin <tag-moi>
```

Không đẩy tag production vào commit chưa kiểm tra. Lỗi secret/sign/check dừng
trước Draft. PR job có quyền đọc và không được cấp signing secret; release job
mới có quyền ghi release. Không dùng `pull_request_target`.

## Build/ký trên máy khi cần

```powershell
./scripts/build_windows.ps1 -OutputRoot D:\PokiguardToolV2\build\my-release -ReleaseBuild 100
python scripts/create_update_manifest.py --archive <ZIP> --tag <tag> --key-file <PEM-private> --output <update.json>
python scripts/verify_windows_package.py --archive <ZIP> --manifest <update.json> --output <thu-muc-moi>
```

Upload ZIP + update.json vào cùng Draft Release/tag đã ký. Signing script lấy
version/build từ ZIP, không nhận số version riêng để tránh lệch metadata.
