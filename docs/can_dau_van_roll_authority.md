# Cân Đẩu Vân 1.7.4-b3: bên quyết định kết quả gieo xúc xắc

Ngày kiểm tra: 2026-09-13. Phạm vi: phân tích tĩnh, chỉ đọc.

## Kết luận

**Kết quả có hiệu lực do server trả về. Client gửi yêu cầu gieo rồi hiển thị
xúc xắc, di chuyển và cập nhật trạng thái theo phản hồi đó.** Mức tin cậy:
**HIGH**, có đối chiếu thân hàm native của đúng build, không chỉ suy luận từ
tên hàm hoặc khai báo C#.

Chưa có mã backend nên thuật toán RNG, seed, xác suất từng mặt, khả năng dùng
trọng số, thời điểm sinh kết quả và ảnh hưởng của thời gian bấm là **UNKNOWN**.
Không thể kết luận xúc xắc công bằng chỉ từ reverse client.

## Nguồn và cách kiểm chứng

- Khai báo và địa chỉ: `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/` và
  `reverse/reverse_1.7.4-b3/il2cpp.json`.
- Đọc tĩnh `D:\pc\GameAssembly.dll`; SHA-256 tính lại khớp README provenance:
  `BD504AF095F825864C963B10C9F62ADA1B8BD7B18E13FF1F0C87B04CD4B5B02D`.
- Dùng pefile đọc PE và Capstone giải mã x64. Với các hàm CanDauVan, lấy khoảng
  hàm từ khai báo reverse; với shared generic HTTP, lấy điểm đầu từ JSON và
  điểm cuối từ PE runtime-function table.
- Bản giải mã có chú thích symbol/string:
  [can_dau_van_1.7.4_b3_native.txt](../reference/can_dau_van_1.7.4_b3_native.txt).
  Cột địa chỉ lệnh là RVA. Địa chỉ trong toán hạng là địa chỉ ảo theo preferred
  image base của file PE, không phải địa chỉ runtime đã resolve.
- Không thực thi hàm game, không gửi request, không gieo thử, không sửa file
  hoặc bộ nhớ game. Không đọc mã server hoặc ghi nhận response live.

## Chuỗi bằng chứng

### 1. Khi bấm gieo, client gửi số thứ tự lượt

`CanDauVanPanel.OnRollTap`, RVA `0x351740`:

- Khởi động `CanDauVanFx.DiceRoll` tại `0x351A85`.
- Đọc `CanDauVanPlayer.rollSeq` tại `+0x2C` ở lệnh `0x351A8A`.
- Gọi `CanDauVanApi.Roll(rollSeq, OnRollOk, OnRollErr)` tại `0x351AE2`.

`CanDauVanApi.Roll`, RVA `0x3214B0`, tạo `RollReq` gồm đúng ba field:

| Field request | Kiểu / offset b3 | Giá trị xác minh trong native |
|---|---|---|
| `rollSeq` | `int`, `+0x10` | Tham số số thứ tự lượt, ghi ở `0x3217DC` |
| `t` | `long`, `+0x18` | Kết quả `HMACHelper.GetTimestamp()`, ghi ở `0x3217DF` |
| `s` | `string`, `+0x20` | Kết quả `HMACHelper.GenerateWheelSignature(...)`, gọi ở `0x321870` |

Request không có field mặt xúc xắc, vị trí đích hoặc phần thưởng do client chọn.
Không phân tích nội bộ chữ ký; không suy ra cách server xác thực từ tên helper.

### 2. Đây là HTTP POST thật trong luồng thực thi

Native dựng URL theo literal `{0}/api/can-dau-van/{1}/roll`, trong đó tham số
thứ hai lấy từ `CanDauVanState.SelfUserId`. Sau đó gọi
`APIManager.PostRequest<CanDauVanRollResult>` tại `0x3219D6` rồi
`StartCoroutine` tại `0x3219E9`. Generic type được xác minh bằng MethodInfo
được nạp tại `0x3219B9`; shared native code có tên `PostRequest<__Canon>`.

Shared coroutine `APIManager.<PostRequest>d__11<__Canon>.MoveNext`, điểm đầu
`0x10BA200`, thực hiện `JsonUtility.ToJson` (`0x10BA4DE`), tạo
`UnityWebRequest` với method `POST`, gắn JSON upload, gọi `SendWebRequest`
(`0x10BA744`), rồi parse JSON response và chuyển dữ liệu tới callback thành
công. `_Roll_b__0` kiểm tra envelope qua `Accept` trước khi gọi callback `ok`.

### 3. Phản hồi chứa kết quả đã được quyết định

`CanDauVanRollResult.cs` khai báo:

| Field response | Kiểu / offset b3 | Ý nghĩa |
|---|---|---|
| `dice` | `int[]`, `+0x20` | Các mặt xúc xắc để hiển thị |
| `steps` | `int`, `+0x28` | Số bước trong response |
| `fromPos`, `toPos` | `int`, `+0x2C`, `+0x30` | Vị trí xuất phát và đích |
| `path` | `int[]`, `+0x38` | Đường di chuyển |
| `landed` | `CanDauVanTile`, `+0x40` | Ô đáp xuống |
| `granted` | `RechargeEventReward`, `+0x48` | Phần thưởng trong response |
| `rollsLeft`, `roundNo`, `roundEnded` | `int`, `int`, `bool`; `+0x50`, `+0x54`, `+0x58` | Trạng thái vòng |
| `tickets`, `rollSeq` | `int`, `+0x5C`, `+0x60` | Vé và số thứ tự lượt mới |
| `tray`, `wallet` | Reference, `+0x68`, `+0x70` | Khay thưởng và ví |

`OnRollOk` (RVA `0x351C90`) cập nhật state bằng các field response, lưu chính
result vào `_pendingRoll +0x1B8` tại `0x351E58`, rồi gọi `TryPlay`.

### 4. Hiệu ứng phải chờ cả response và animation

`TryPlay` (RVA `0x351C00`) kiểm tra `_diceDone +0x1B1` và
`_pendingRoll +0x1B8`. Chỉ khi animation xong, có result và UI còn hợp lệ mới
chuyển result sang `PlayRoll`.

Callback animation `_OnRollTap_b__213_0` (RVA `0x355980`) đặt `_diceDone=true`;
nếu response đã tới thì dùng `_pendingRoll` để gọi `PlayRoll`. Vì vậy thứ tự
response/animation hoàn thành có thể đảo nhau mà vẫn dùng cùng kết quả server.

`CanDauVanFx.DiceRoll` (RVA `0x32EDF0`) gọi `Tumble`, `Ripple` và callback hẹn
giờ của `LeanTween`. Chữ ký hàm chỉ nhận ảnh, sprite, transform và `Action`
không tham số; callback không trả về số mặt xúc xắc.

### 5. Client hiển thị và áp dụng các field response

`PlayRoll` (RVA `0x352220`):

- `0x352460` đọc `r.dice +0x20`; `0x35246A` gọi `ShowDice(r.dice)`.
- `0x35248B` đọc `r.toPos +0x30` và chuẩn hóa theo chiều dài đường đi.
- `0x3524A7` đọc `r.path +0x38`; nếu thiếu/rỗng thì gọi
  `PathBetween(r.fromPos, normalizedToPos, trackLen, loop)` tại `0x3524C9`.
  Đây là dựng đường animation từ hai đầu mút response, không gieo lại kết quả.
- `ShowDice` lưu mảng ở `_lastDice +0x1C0`, lấy từng giá trị và chuyển tới
  `ShowFace`. Có fallback hiển thị `DEFAULT_DICE` nếu mảng null/rỗng; fallback
  này không tự quyết định vị trí hoặc phần thưởng.
- `ApplyRollLocal` và `CanDauVanState.ApplyRoll` sao chép trạng thái result;
  ví dụ `0x344AC0..0x344AC3` sao chép `r.toPos` vào `player.pos +0x28`.

Không có bước client chọn mặt xúc xắc có hiệu lực trong luồng gieo đã kiểm tra.
Backend có thể sinh kết quả khi nhận request hoặc lấy từ trạng thái đã chuẩn bị;
reverse client không phân biệt được hai trường hợp này.
