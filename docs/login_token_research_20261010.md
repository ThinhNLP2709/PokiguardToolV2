# Kiểm tra token sau đăng nhập — 2026-10-10

## Kết luận

**Có.** Reverse mới nhất dùng cho client hiện tại là
`reverse/reverse_1.7.4-b6`. `LoginResponse` chứa `token`, `sessionKey` và
`rememberToken`. Đã đối chiếu khai báo reverse với mã native của GameAssembly
đang cài, không chỉ suy ra từ tên field.

GameAssembly SHA-256 kiểm tra lại trong phiên này:
`72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063`,
trùng provenance của reverse b6.

| Trường trong LoginResponse | Offset instance | Vai trò/đường lưu đã xác minh |
|---|---:|---|
| `token` | `+0x20` | Pipeline đăng nhập lưu vào PlayerPrefs key `AuthToken`; APIManager đọc key này và dùng header `Authorization: Bearer …` |
| `sessionKey` | `+0x28` | Pipeline xử lý riêng và lưu PlayerPrefs key `SessionKey` nếu có giá trị |
| `rememberToken` | `+0x58` | OnLoginOk đọc trường này; khi ghi nhớ hoặc đăng nhập bằng token, token mới không rỗng được đưa qua LoginCredentialStore.SaveToken |

`rememberToken` có đường lưu riêng: `SaveToken` gọi `Protect`, sau đó lưu
blob vào PlayerPrefs `RememberToken` và đặt `RememberMe`. `LoadToken` đọc
`RememberToken` rồi gọi `Unprotect`. `LoginAuthService.LoginWithToken` và
`TokenLoginRequest.rememberToken +0x10` xác nhận luồng đăng nhập ghi nhớ.
Đây không phải cùng một field với access token dùng cho API.

## Bằng chứng native

Tất cả địa chỉ dưới đây là RVA theo module, không phải địa chỉ runtime tuyệt đối.

| Hàm/vị trí | RVA | Bằng chứng |
|---|---:|---|
| `LoginSuccessPipeline._Run_d__0.MoveNext` | `0x006A1BA0` | Đọc response `token +0x20`, gọi PlayerPrefs.SetString với key `AuthToken` tại call site `0x006A1E23` |
| Cùng pipeline, sessionKey | `0x006A1E36` | Đọc `sessionKey +0x28`; nhánh giá trị không rỗng lưu `SessionKey` tại call site `0x006A1F38` |
| `LoginScreen.OnLoginOk` | `0x0069B210` | Đọc `AuthResult.login +0x30`, rồi `LoginResponse.rememberToken +0x58` tại `0x0069B4F3`; gọi SaveToken tại `0x0069B53F` khi điều kiện ghi nhớ/đăng nhập token và token không rỗng thỏa mãn |
| `LoginCredentialStore.SaveToken` | `0x006BA770` | Gọi Protect, lưu `RememberToken` bằng PlayerPrefs.SetString tại `0x006BA82E`; đặt RememberMe |
| `LoginCredentialStore.LoadToken` | `0x006BA620` | Đọc RememberToken, gọi Unprotect; có nhánh xóa token ghi nhớ khi không giải mã được |
| `APIManager.GetAuthToken` | `0x00A1B260` | Đọc PlayerPrefs `AuthToken` |
| `APIManager._PostBytes_d__16.MoveNext` | `0x00A1C450` | Gọi GetAuthToken, nối chuỗi `Bearer `, đặt header `Authorization` tại `0x00A1C7B7` |

Nguồn khai báo:

- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/LoginResponse.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/LoginSuccessPipeline.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/LoginScreen.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/LoginCredentialStore.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/LoginAuthService.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/TokenLoginRequest.cs`
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/APIManager.cs`
- `reverse/reverse_1.7.4-b6/il2cpp.json`: symbol/RVA và string literal map.

## Giới hạn kết luận

- Đã chứng minh client nhận và sử dụng các trường token trong luồng đăng nhập.
  Chưa kiểm tra một phản hồi đăng nhập mới của tài khoản cụ thể trong phiên này.
- Giá trị token hiện tại, thời hạn, định dạng JWT và cơ chế refresh: **UNKNOWN**.
- Chỉ đọc reverse và file game để đối chiếu. Không lấy giá trị credential từ
  memory/registry, không gửi request và không sửa code runtime trong lượt này.

## Rà yêu cầu Bú win trước đó

Source đã có guest room cho Bú win + Coop, Ready một lần, chờ chủ phòng,
ngừng action khi pet chết, phân loại kết quả Coop, sử dụng postmatch hiện có
và ghim lại Room ID/chủ phòng khi tiếp tục. Đối chiếu log regression trước đó:
1.853 tests PASS. Chạy lại 48 kiểm thử liên quan trong lượt này: PASS.

Chưa build EXE mới và chưa kiểm chứng farm thật từ Ready đến nhận quà qua nhiều
trận. Vì vậy phần triển khai source/offline đã hoàn tất; chưa thể đánh dấu
nghiệm thu live hoặc cập nhật bản EXE đang dùng là hoàn tất.
