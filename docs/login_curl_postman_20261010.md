# cURL đăng nhập b6 để import Postman — 2026-10-10

Mẫu đầy đủ tại [login_b6.curl.txt](examples/login_b6.curl.txt). Chỉ dựng request,
chưa gửi thử đăng nhập và không sửa gameplay/runtime của tool.

## Cách dùng

1. Trong Postman chọn Import, dán nội dung file cURL và import thành request.
2. Mở Body / raw / JSON. Điền `user`, `password`, `deviceId`; chỉnh `deviceName`
   thành nhãn thiết bị mong muốn. `Postman (Windows)` trong mẫu là nhãn ví dụ.
3. Gửi request. Khi thành công, đọc `token` ở cấp ngoài cùng của JSON response.
   `rememberToken` là token ghi nhớ riêng, không dùng thay `token` cho bearer.

Mẫu nhắm client b6 có version nội bộ `1.7.4.7`. Không tự đoán version mới nếu
server báo cần cập nhật; cần kiểm tra lại client/reverse tương ứng.

## Lấy deviceId đang dùng của game

Reverse xác nhận `LoginDevice.Id` ưu tiên PlayerPrefs key `DeviceId`, sau đó
mới lấy deviceUniqueIdentifier hoặc tạo GUID dạng N rồi lưu lại. Để gửi cùng
ID thiết bị với game trên máy này, có thể đọc đúng key đó bằng PowerShell:

```powershell
$prefsKey = [Microsoft.Win32.Registry]::CurrentUser.OpenSubKey(
    'Software\Pokiguard\PokiguardOnlines', $false
)
if ($null -eq $prefsKey) { throw 'Không tìm thấy PlayerPrefs của game' }
try {
    foreach ($name in $prefsKey.GetValueNames()) {
        if ($name -notmatch '^DeviceId(?:_h\d+)?$') { continue }
        $value = $prefsKey.GetValue($name)
        if ($value -is [byte[]]) {
            [Text.Encoding]::UTF8.GetString($value).TrimEnd([char]0)
        } elseif ($value -is [string]) {
            $value
        }
    }
} finally {
    $prefsKey.Dispose()
}
```

Lệnh chỉ đọc key DeviceId, không ghi registry và không in password/token.
Sử dụng Registry API trực tiếp để tránh lỗi `Specified cast is not valid`
của Get-ItemProperty khi một giá trị khác trong cùng khóa có kiểu dữ liệu lỗi.
Nếu không có kết quả, chưa xác minh được deviceId của phiên cài đó; không coi
chuỗi placeholder trong mẫu cURL là ID thật. Vị trí PlayerPrefs trên Windows
đã được xác minh cho client b6 trong báo cáo compatibility hiện có.

## Tự lưu token vào Environment của Postman

Tạo/chọn một Environment, rồi thêm đoạn sau vào Scripts / Post-response:

```javascript
for (const key of ["authToken", "sessionKey", "rememberToken"]) {
    pm.environment.unset(key);
}
const result = pm.response.json();
if (pm.response.code >= 200 && pm.response.code < 300 &&
    result.success === true &&
    typeof result.token === "string" && result.token.length > 0) {
    pm.environment.set("authToken", result.token);
    for (const key of ["sessionKey", "rememberToken"]) {
        if (typeof result[key] === "string" && result[key].length > 0) {
            pm.environment.set(key, result[key]);
        } else {
            pm.environment.unset(key);
        }
    }
} else {
    throw new Error(result.message || "Login failed or token is missing");
}
```

Script không in token ra console. Biến `authToken` sau đó có thể tham chiếu
bằng `{{authToken}}` trong Bearer Token của request được người dùng chọn.

## Bằng chứng reverse/native

Hash GameAssembly đối chiếu lại:
`72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063`.

- `APIConfig.cs`: DOMAIN `pokiguard.online`, VERSION `1.7.4.7`. Native cctor
  RVA `0x009B6080` đặt SECURE=true; nhánh `0x009B619F`..`0x009B61CC` chọn
  `https://` và ghép domain, không thêm tiền tố `/api`.
- `APIConfig.POST_USER_LOGIN` getter RVA `0x009A8AE0`: ghép BASE_URL và
  `/users/login`.
- `LoginRequest.cs`: các field đúng tên `user`, `password`, `version`,
  `deviceId`, `deviceName`, `platform`, `rememberMe`.
- `LoginAuthService._Login_d__2.MoveNext` RVA `0x006A6A20`: version `1.7.4.7`,
  platform `PC`, lấy LoginDevice.Id/Name, serialize bằng JsonUtility.ToJson.
- `LoginAuthService._Send_d__5.MoveNext` RVA `0x006A7A00`: POST, UTF-8 JSON,
  header Content-Type application/json, Lang.ApplyHeader, timeout 15 giây.
  Trong đường này không thấy thêm Authorization hoặc chữ ký HMAC.
- `Lang.ApplyHeader` RVA `0x006892C0`: header `X-Lang`; giá trị vi/en được
  xác minh ở Normalize RVA `0x006878D0`.
- `LoginDevice.Id` RVA `0x006BC1E0`: key DeviceId, fallback SystemInfo hoặc
  Guid.ToString("N"); Name RVA `0x006BC670` ghép model và OS.
- Response parser call site `0x006A8179`, MethodInfo ở `0x006A816F` xác nhận
  `JsonUtility.FromJson<LoginResponse>(String)`, đọc JSON response trực tiếp.

`deviceName` trong mẫu chỉ là nhãn ví dụ; reverse không xác minh quy tắc
server dành cho thiết bị khác. Chưa kiểm tra credential, response thực tế
hoặc chính sách phiên đồng thời của tài khoản trong lượt dựng mẫu này.

Nguồn Postman:
[import cURL](https://learning.postman.com/docs/getting-started/importing-and-exporting/importing-data/#import-and-convert-curl-commands),
[environment variables](https://learning.postman.com/docs/use/send-requests/variables/environment-variables).
