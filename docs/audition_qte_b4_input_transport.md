# QTE và Audition V3 b4: phím hướng được gửi lên server lúc nào?

Ngày kiểm tra: 2026-09-22. Build: **1.7.4-b4**.

## Kết luận

**Không gửi một gói riêng cho mỗi lần bấm trái/phải trong hai luồng đã kiểm
tra. Client ghi các hướng vào `qtePresses`, xử lý phản hồi UI tại chỗ, rồi gửi
cả danh sách trong `MATCH_SKILL_USE_REQ` khi hoàn tất luồng QTE để dùng skill.**
Vì vậy thao tác hướng không chỉ là UI: server nhận được chuỗi hướng đã ghi.

**Audition V3 còn gửi `MATCH_QTE_TAP` tại lúc bấm Space/Enter/chạm thanh**,
với thời gian bấm và challenge ID, nếu có phiên/challenge và transport hợp lệ.
Gói này tách biệt với gói dùng skill chứa danh sách hướng.

| Thao tác | QTE legacy trong b4 | Audition V3 trong b4 |
|---|---|---|
| Bấm hướng | Ghi `qtePresses`, kiểm tra hướng và cập nhật UI tại client | `PressDir` gọi host để ghi `qtePresses`, so với `Expected`, cập nhật UI |
| Gửi riêng mỗi hướng | Không thấy trong luồng đã kiểm chứng | Không thấy trong luồng đã kiểm chứng |
| Space/Enter | Ghi nhận/chấm timing tại client; handler không gọi transport | Ghi nhận timing và gửi `MATCH_QTE_TAP` khi đủ điều kiện |
| Kết thúc QTE / dùng skill | Gửi bản sao `qtePresses` và dữ liệu timing/challenge trong `MATCH_SKILL_USE_REQ` | Tương tự, sau khi coroutine Audition trả quyền điều khiển cho coroutine skill |

Mức tin cậy **HIGH** cho luồng client. Đây là bằng chứng tĩnh từ native code,
không phải bản bắt gói live. Việc server xác thực/replay/chấm điểm cụ thể và
lưu dữ liệu bao lâu là **UNKNOWN**, vì chưa có mã backend.

## Nguồn và phạm vi

- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/`, `il2cpp.json` và `il2cpp.h`.
- Đọc `D:\pc\GameAssembly.dll`; SHA-256 tính lại:
  `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`,
  khớp `reverse/reverse_1.7.4-b4/README.md`.
- Giải mã 39 thân hàm bằng Capstone x64, lấy biên hàm từ reverse C# và đối
  chiếu symbol/string/MethodInfo từ JSON.
- [Native đầy đủ](../reference/audition_qte_b4_native.txt),
  [tóm tắt call/string](../reference/audition_qte_b4_calls.txt),
  [xref transport](../reference/audition_qte_b4_xrefs.txt),
  [script xuất lại native](../reference/audition_b4_static_audit.py).
- Phân tích cả `CardUI` và `CardUIPVP`. Không gửi request, không chạy hàm game,
  không điều khiển game, không sửa file hoặc bộ nhớ game.
- Các địa chỉ dưới đây là RVA của đúng b4, không phải địa chỉ runtime.

## 1. Nhấn trái/phải trong Audition V3

```text
AuditionInput.Poll / phần Poll được inline trong AuditionRunner.Run
  -> AuditionStage.PressDir("nutLeft" / "nutRight")
     -> PressCallback(dir)
        -> IAuditionHost.OnAuditionPress(dir)
           -> CardUI.qtePresses.Add(dir) hoặc CardUIPVP.qtePresses.Add(dir)
     -> so sánh với challenge.Expected[cursor]
     -> cập nhật cursor, CorrectCount và hình/âm thanh
```

- `AuditionInput.Poll`, RVA `0xBC6F10`, nhận Left/A và Right/D, chuyển thành
  `nutLeft`/`nutRight` rồi gọi `PressDir` (`0xBC6FB7`, `0xBC6FE9`).
- `AuditionRunner.<Run>.MoveNext` có phần Poll inline với cùng các lời gọi
  `PressDir` ở `0xBC88CE`, `0xBC8900`. Nút UI cũng gọi `PressDir` qua callback
  `_BuildOneButton_b__0`, RVA `0xBD5800`.
- `PressDir`, RVA `0xBD0080`, bỏ qua stage disposed/tapped hoặc thiếu arrows;
  gọi `PressCallback +0x28` ở `0xBD00EF`, **trước** khi so hướng đúng/sai.
- `Run.MoveNext` resolve interface slot **3** ở `0xBC8576..0xBC8585`, dựng
  `Action<string>` và gán vào `stage.PressCallback` ở `0xBC85BA`.
  `il2cpp.h:225138` xác nhận slot 3 là `IAuditionHost.OnAuditionPress`.
- `CardUI.OnAuditionPress`, RVA `0xA938F0`, đọc `qtePresses +0x498` và thêm
  string nếu số phần tử dưới **64** (`0xA9392F`). Không gọi transport.
- `CardUIPVP.OnAuditionPress`, RVA `0x958EF0`, tương tự với
  `qtePresses +0x158`, cũng giới hạn 64 phần tử.

Do lưu trước khi so đúng/sai, các lần bấm sai được handler tiếp nhận cũng có
thể nằm trong danh sách. Đây không phải log toàn bộ raw keyboard: phím ngoài
luồng, stage đã đóng/tapped, giới hạn 64 và các điều kiện nhận input vẫn áp dụng.

## 2. Nhấn trái/phải trong QTE legacy

`CardUI.Update` (RVA `0xAADFA0`) đọc hướng và gọi `CheckDotArrow` ở
`0xAAE168`; nút UI đi qua `OnDirectionButtonPress` (RVA `0xAADA10`) đến
cùng `CheckDotArrow`.

`CheckDotArrow`, RVA `0xAAE200`, đọc `qtePresses +0x498` ở `0xAAE2E2`,
kiểm tra giới hạn 64 ở `0xAAE2F2`, thêm hướng vào list rồi mới xử lý so khớp
mũi tên/hiệu ứng. Không có lệnh gửi transport trong handler này. Nhánh PVP
tương ứng là `CheckDotArrow` RVA `0x972A20`, dùng list tại `+0x158`.

`OnEnterButtonPress` và phần Space/Enter trong `Update` gọi
`ShowTimingResult`, đặt cờ nhấn và dừng hiệu ứng chờ. Các handler legacy này
không phát `MATCH_QTE_TAP`. Không áp dụng kết luận "Space luôn gửi TAP riêng"
của V3 cho legacy.

## 3. Space của Audition V3 gửi gì?

```text
Space / Enter / chạm thanh
  -> AuditionStage.TapBar()
     -> Tapped = true; TapElapsedMs = thời gian QTE đã trôi qua, giới hạn theo duration
     -> TapCallback(TapElapsedMs)
        -> host.OnAuditionTap(elapsedMs)         [lưu timing ở client]
        -> ChatService.SendMatchQteTap(...)     [gửi gói TAP]
```

- `TapBar`, RVA `0xBD0580`, kiểm tra chưa disposed/tapped; ghi `Tapped +0x19`
  và `TapElapsedMs +0x1C`, gọi callback tại `0xBD0801`.
- `Run.MoveNext` gán `TapCallback +0x30` ở `0xBC85FC` tới `_Run_b__0`.
- `_Run_b__0`, RVA `0xBC7D60`, gọi interface slot **4** (`OnAuditionTap`),
  kiểm tra `MatchService`, match ID, challenge ID khác 0 và transport instance,
  rồi gọi `ChatService.SendMatchQteTap` tại `0xBC7FB0`.
- `CardUI.OnAuditionTap` (RVA `0xA939A0`) bản thân chỉ lưu
  `_auditionV3ElapsedMs +0xE4` và timing local. Lệnh gửi nằm ở callback runner.
- `ChatService.SendMatchQteTap`, RVA `0x3B27C0`, đặt message type
  `MATCH_QTE_TAP`, `matchId`, `qteElapsedMs +0x158` và
  `qteChallengeId +0x160`, rồi gọi `SendWebSocketMessage` ở `0x3B29BD`.
  Tên tham số hàm là `elapsedMs`/`challengeId`; tên field DTO gửi đi có tiền tố
  `qte`. Gói này không mang danh sách phím hướng.

Nếu timeout mà không tap, runner có nhánh báo timing cho host bằng interface
slot 4 ở `0xBC89BD`; không được coi đó là một lần tap thật hoặc tự suy ra có
gói TAP. Dữ liệu dùng skill vẫn do coroutine bên ngoài xử lý theo nhánh của nó.

## 4. Cả chuỗi hướng được gửi khi dùng skill

Coroutine `CardUI.<HandleDotSkillSequence>d__292.MoveNext`, RVA `0xADC090`,
chờ `AuditionRunner.Run` ở `0xADC972`. Sau khi runner hoàn tất, nhánh V3:

1. Lấy list tại `CardUI +0x498` (`0xADCBB5`).
2. Tạo `new List<string>(qtePresses)` (`0xADCBD2`).
3. Lấy `CurrentQteElapsedMs()` và `CurrentQteChallengeId()`.
4. Truyền bản sao list, timing/challenge và các tham số skill vào
   `MatchService.SendSkillUse` tại `0xADCC48`.

Các nhánh legacy cũng tạo bản sao list và gọi cùng hàm ở `0xADD926` và
`0xADDD69`. Nhánh PVP có các lời gọi tương ứng tại `0xB084E6`, `0xB091A7`
và `0xB094A0`.

```text
MatchService.SendSkillUse                         RVA 0x3D1390
  -> ChatService.SendMatchSkillUse                RVA 0x3B21A0
     -> ChatMessageDTO.type = "MATCH_SKILL_USE_REQ"
     -> qtePresses, qteElapsedMs, qteChallengeId
     -> correctDotCount, timingResult, dotsToDestroy, ...
     -> SendWebSocketMessage                     RVA 0x3ABAB0
        -> JSON serialize -> EnqueueSend
```

Native `SendMatchSkillUse` ghi `qtePresses` vào DTO `+0x150` tại
`0x3B24D4`, timing vào `+0x158` tại `0x3B2531`, challenge vào `+0x160`
tại `0x3B2546`, rồi gửi tại `0x3B254D`. `SendWebSocketMessage` serialize
DTO bằng Newtonsoft ở `0x3ABC78`, chuyển vào hàng đợi gửi ở `0x3ABD06`.
Transport vẫn kiểm tra trạng thái kết nối; phân tích tĩnh chứng minh đường gửi,
không chứng minh một server live đã nhận bất kỳ gói cụ thể nào.

Trong payload đã kiểm tra, `qtePresses` là **List<string>**, giữ thứ tự hướng;
không có timestamp riêng cho từng phần tử. Ví dụ minh họa một danh sách là
`["nutLeft", "nutRight", "nutLeft"]`; đây không phải dữ liệu bắt từ một lượt live.

## 5. Các gói QTE khác không phải gửi từng hướng

- `RequestQteChallenge` / `SendMatchQteStart`: gửi `MATCH_QTE_START` để xin
  challenge trước khi giải QTE. `HandleQteChallenge` đọc response challenge.
- `AuditionRunner.RelayQte`: các caller đã xác minh dùng phase `START`
  (`0xBC8705`) hoặc `END` (`0xBC8AEF`, `0xBC8F15`).
- Legacy `CardUI.SendQteEventSafe` được coroutine gọi với `START`
  (`0xADC8B6`) và `END` (`0xADD640`).
- Các đường này đến `SendMatchQteEvent` / `MATCH_QTE_EVENT`; không có payload
  hướng trong những caller START/END đã kiểm tra.

Danh sách xref lưu riêng là kết quả quét ứng viên relative call/jump trong PE;
những site nêu trên được đối chiếu lại trong thân hàm. Không dùng riêng một
kết quả quét không có caller để khẳng định toàn bộ hành vi game.

## Giới hạn kết luận

Đã xác minh server được gửi chuỗi hướng, một giá trị thời gian QTE và mã
challenge. Client cũng tự chấm/hiển thị grade. Chưa xác minh backend có tin
grade client, tự tính lại từ chuỗi hướng, kiểm tra từng điều kiện hay áp dụng
luật nào khác. Không suy ra thuật toán server hoặc cơ chế giám sát ngoài luồng
QTE này từ các tên field.
