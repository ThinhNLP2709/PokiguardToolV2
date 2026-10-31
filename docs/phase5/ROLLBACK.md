# Tắt AI và rollback

Chốt31/10/2026. BASIC là mặc định; hướng dẫn này không phát hành binary mới,
không mở lại batch test đã dùng hết cap. [Phạm vi hiện tại](FINAL_REPORT.md).

**Bổ sung01/11/2026:** [bản UI đã nghiệm thu](CURRENT_HANDOFF.md) dùng profile
riêng ngoài ZIP, không cần cờ lab. Khi controller đã dừng, chọn **Cơ bản** trong
AI, tắt shadow nếu không cần và **Lưu cấu hình AI**; lần Start/Tiếp tục tiếp theo
không tạo workerR. Không cần restart tool để đổi lựa chọn. Phần “đóng phiên
lab” bên dưới chỉ áp dụng các phiên lab lịch sử.

## Trở lại BASIC

1. Dùng Dừng sau trận hiện tại hoặc Dừng khẩn cấp theo nhu cầu. Đợi controller
   ngừng, worker/poller đóng sạch; giữ log của phiên để phân tích.
2. Đóng phiên lab. Mở tool thông thường không kèm operational/package acceptance
   request, chọn Cơ bản, tắt shadow và lưu cấu hình AI.
3. Kiểm lại pet/loadout/lối chơi/mục tiêu trước khi tự Start. Preferences thường
   không bị hồ sơ lab ghi đè; không chép session_preferences của lab sang prefs
   thường chỉ để bật suy luận.

Không xóa request/claim hoặc reset checkpoint để tắt AI. Sau dispatch, không
phát nước BASIC thứ hai; ACK/pending owner vẫn phải kết thúc action hiện có.

## Binary giữ riêng

| Artifact | Đường dẫn | SHA256 |
|---|---|---|
| UI opt-in đã kiểm, chưa phát hành | `D:/PokiguardToolV2/build/ui-reasoning-20261031-final/PokiguardToolV2-v1.2.10-win-x64.zip` | `fcf29a1ab2c0b32e4398307e92e12879d5ac559325125ede4fbfef006a9d3c26` |
| F1 test package đã nghiệm thu | `D:/PokiguardToolV2/build/phase5-f1-20261031-acceptance/PokiguardToolV2-v1.2.10-win-x64.zip` | `2a7c74d4a8236a2a58404d8ef057be2c44d141fe0cf90d1d6d75533109fd6515` |
| Release v1.2.10 cũ được giữ | `D:/PokiguardToolV2/build/v1.2.10/PokiguardToolV2-v1.2.10-win-x64.zip` | `7249a3e5711ba319f733f43c8b23c9a5f59857889f01dcb4e3da314261e065c5` |
| Accepted v1.2.4 baseline | `D:/PokiguardToolV2/build/v1.2.4/PokiguardToolV2-v1.2.4-win-x64.zip` | `a71f75a808111e903bae39b115b6c446632511a9ef7d1fa06434aecc326fbdd9` |

Cùng tên version1.2.10 không có nghĩa cùng binary. Dùng đúng đường dẫn/hash;
không overwrite release cũ bằng test package. Danh sách9ZIP được giữ có trong
[rollback hashes](artifacts/5f1_packaged_20261031/rollback_hashes.json).

## Nếu cần đổi về binary cũ

- Giữ nguyên ZIP, log và preferences hiện tại; sao lưu preferences trước khi
  dùng binary khác. Normal package prefs thường ở
  `%LOCALAPPDATA%/PokiguardToolV2/preferences/operator_preferences.json`.
  Private F1 dataRoot được lưu riêng trong artifact F1, không trộn hai nơi.
- Đóng tool hiện tại sạch rồi giải nén ZIP được chọn vào một thư mục riêng.
  Không thay game files, không reset/checkout source project hoặc sửa V1.
- So SHA256 với bảng; mở ở BASIC/shadowOFF. Không mang authority/request/claim,
  hồ sơ timing hoặc active checkpoint từ binary mới sang binary cũ để tiếp tục
  lab run. Batches E1/E2/F1 đã đóng không được resume/reset cap.
- Binary phải nhận đúng game/build/state và cho phép thao tác theo gate hiện
  có trước khi người dùng Start. v1.2.4 được giữ làm baseline lịch sử, **không
  được coi là tương thích tự động với game b12**. Nếu báo INCOMPATIBLE_BUILD,
  không bỏ qua kiểm fingerprint hoặc ép offset cũ; cần thích ứng game riêng.

Để kiểm ZIP bằng PowerShell, chỉ đọc file:

```powershell
Get-FileHash -Algorithm SHA256 -LiteralPath 'D:\PokiguardToolV2\build\v1.2.10\PokiguardToolV2-v1.2.10-win-x64.zip'
```

F2 không thực thi các bước rollback/build/live. Tắt AI cũng không sửa nguyên
nhân mất focus, ACK chưa rõ hoặc game update; giữ đúng evidence để chẩn đoán.
