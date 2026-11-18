# Tự cập nhật tương thích khi game đổi build

Triển khai trên nhánh `codex/self-service-compatibility`, tách từ checkpoint
`7abb167c0a97f1787d99cb2d415b6df71feea09d`. Nhánh gốc
`codex/phase3a2-board-repair` và các ZIP v1.3.6 trước đó được giữ nguyên.

## Người dùng thao tác

1. Cập nhật game, thoát tiến trình game cũ rồi mở bản mới.
2. Dừng lượt chạy của tool. Trong **Cài đặt → Cài đặt trò chơi**, chọn đúng
   EXE rồi nhấn **Cập nhật tương thích**.
3. Nếu được yêu cầu, vào phòng boss do mình làm chủ, để hiện nút **Bắt đầu**
   và nhấn lại. Tool không tự vào phòng, bắt đầu trận hay chơi thử.
4. Khi báo thành công, bắt đầu lượt chạy mới. Không chuyển checkpoint hay
   chứng nhận gameplay của build cũ sang build mới.

Build B17 đã được hỗ trợ sẵn nên nút trả về ngay, không tải hoặc thay profile.
Với build mới, app tự tải Il2CppDumper 3.2.1 và .NET 10.0.15 portable đã khóa
checksum. Không cần Python, Git, bộ reverse riêng hoặc quyền administrator.
Lần đầu cần Internet; lần sau dùng cache đã kiểm lại từ archive gốc.

## Phạm vi tự động chấp nhận

Chỉ nhận profile **đổi địa chỉ** trong contract B17 đã chứng minh:

- Đúng hash/kích thước launcher, GameAssembly, UnityPlayer, metadata, app.info;
  metadata111, PE x64. UnityPlayer phải giữ nguyên.
- Các file serialized `.assets`, `levelN`, globalgamemanagers, boot.config và
  StreamingAssets/catalog phải giữ nguyên. Không suy "UI không đổi" từ số version.
- 39 TypeInfo match exact tên/signature; 55 kiểu tiêu thụ giữ nguyên field,
  kiểu, offset, static ownership và constants; enum/closed-container ABI giữ nguyên.
- 69 routine native, gồm các routine HUD/tâm ô, giữ nguyên fingerprint ngữ nghĩa
  bảo thủ. Các call có symbol giữ exact identity; helper chưa định danh dùng
  bytes chính xác, nên có thể từ chối cả một thay đổi vô hại.
- Component icall cache được decode load/store từ wrapper; unmarshal phải có
  unique signature; getter phải vẫn chứng minh static_fields+0x98.
- Probe tiến trình thật chỉ với QUERY_INFORMATION|VM_READ: executable section
  phải khớp file hiện tại sau chuẩn hóa relocation ASLR; root class đúng owner;
  phòng và Start Button có ownership/Canvas/geometry ổn định.

UI/layout/Unity/decoder đổi hoặc có UNKNOWN thì dừng. Không cộng delta chung,
đoán địa chỉ, sửa game, inject, gọi method hay gửi packet. Đây không phải bộ
migration tự động cho mọi phiên bản game.

## Cách tích hợp mà không đổi gameplay

Profile bất biến gắn với từng `Win32RemoteMemory`/attachment. Resolver dùng
RVA B17 như khóa binding và đọc RVA của profile tương ứng. Native reader dùng
cùng object profile. Không monkeypatch globals hoặc sửa code/EXE khi migration.

Không có external profile thì B17 đi đúng đường built-in cũ. Solver, scoring,
policy, drain-resource logic, input backend, pacing, jitter và calibration không
đổi. Fixture `tests/fixtures/compatibility/b17_gameplay_manifest.json` giữ dấu
vết 241 module ngoài lớp tích hợp so với checkpoint.

Migration giữ cùng OS controller lease với FarmRunner. GUI khóa Start/Resume
và sửa đường dẫn trong lúc chạy; đóng cửa sổ sẽ hủy worker và thu hồi child
process trước khi thoát. Sau apply, callback hiện hữu detach provider cũ và
xóa cache pointer/metadata trước lần attach tiếp theo. Checkpoint mới của build
đã migrate có sidecar profile ID/run ID/sequence; checkpoint lịch sử không được
gắn lại profile mới. Khi dùng CLI farm trên build migrate phải cấu hình đúng
game trước, nếu không resume bị từ chối do không xác định được build scope.

## Dữ liệu và transaction

Bản đóng gói dùng `%LOCALAPPDATA%\PokiguardToolV2\compatibility\`:

- `tools/`: archive và tool/runtime portable đã khóa checksum.
- `jobs/<job-id>/`: danh tính input, dump mới, log, probe và kết quả.
- `candidates/<assembly-sha256>.json`: đã audit tĩnh, chưa cấp quyền attach thường.
- `profiles/<assembly-sha256>.json`: chỉ được ghi atomically sau probe PASS.

Mỗi dump có thư mục mới; parser không cache output của job trước. Không ghi
vào thư mục game, không gộp dump cũ. Có kiểm tra lại input sau audit/probe và
chặn storage/junction thoát vùng lưu trữ. Lỗi trước activation giữ nguyên file
profile đang có. File profile là điểm commit cuối cùng; log của job dùng trạng
thái `verified_pending_activation` ngay trước điểm đó. Profile verified là
authority về trạng thái activation.

Không xóa preferences hoặc log lịch sử. Không tự Start/Resume sau apply.
Đọc đúng board hay kiểm Start không thay thế live acceptance move/ACK/result.
Migration không cấp chứng nhận reasoning/timing: các gate hash/source cũ vẫn
giữ nguyên và cần qualification mới khi build hoặc source scope thay đổi.

## CLI và catalog tùy chọn

Source developer:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src;D:\PokiguardToolV2"
python -m tools.migrate_compatibility --game "D:\pc\PetPuzzle-1.7.4.exe"
python -m tools.migrate_compatibility --game "D:\pc\PetPuzzle-1.7.4.exe" --prepare --reverse "D:\PokiguardToolV2\reverse\reverse_1.7.4-b17"
```

EXE dùng `--migrate-compatibility --game <EXE> [--prepare] [--reverse <folder>]`.
GUI và CLI gọi cùng engine. Exit0=builtin/verified, exit3=pending, exit2=lỗi;
EXE windowed ghi chi tiết vào startup/packaged_console.log.

Đã có verifier catalog Ed25519 và công cụ maintainer
`tools/sign_compatibility_catalog.py`. Public key được pin trong resource
`compatibility_catalog.json`; private key luôn ở ngoài bản phát hành. Payload
có thời hạn tối đa31 ngày, ký canonical JSON với domain separator riêng.
Profile tải về vẫn phải match contract/install và qua probe cục bộ.

**Chưa cấu hình endpoint hay public key**, vì dự án chưa có dịch vụ phát profile.
Do đó nút hoạt động đầy đủ bằng local migration; không giả lập catalog đã online.
Khi có HTTPS feed, maintainer điền URL/public key vào resource trước đóng gói
và xuất catalog từ các profile đã verified. Lỗi mạng/chữ ký/catalog hết hạn
chuyển sang audit cục bộ; không chấp nhận profile unsigned.

## Kiểm tra đã thực hiện

- Reverse B17 từ game thật bằng chính toolchain tải mới: CLI thành công, tạo
  đủ dump.cs/script.json/il2cpp.h; audit lại contract đạt; `--prepare` giữ pending.
- UI offline: nút phản hồi B17 đã hỗ trợ, 0 lỗi render, 0 Start/Resume, worker
  và poller đóng sạch. Không có tiến trình game chạy ở lần kiểm tra này.
- Regression cuối: 270 test PASS; gồm migration, provider/resolver/native UI,
  game location, checkpoint, packaging, policy, input và drain-resource logic.
- Không thực hiện live trận đánh/build kế tiếp. Chưa thể khẳng định một build
  chưa có sẽ được chấp nhận; các kiểm tra trên quyết định khi build đó xuất hiện.

Nguồn toolchain: [Dumper3.2.1](https://github.com/AndnixSH/Il2CppDumper/releases/tag/3.2.1),
[CLI/build instructions](https://github.com/AndnixSH/Il2CppDumper/tree/3.2.1),
[Microsoft .NET10 release metadata](https://builds.dotnet.microsoft.com/dotnet/release-metadata/10.0/releases.json).
