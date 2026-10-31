# Runbook: cập nhật tương thích khi PetPuzzle/Pokiguard đổi bản

Quy trình này tạo một runtime profile đã được chứng minh cho đúng binary mới.
Không được bật bản mới bằng cách chỉ thay hash hoặc cộng một delta chung vào
các địa chỉ cũ.

## Nguyên tắc

- Chỉ đọc game/reverse; không sửa file game, ghi memory, inject DLL hoặc gọi
  trực tiếp method/network của game.
- Giữ nguyên mọi thay đổi chưa commit trong repo.
- Chỉ lưu RVA tương đối với module; không hard-code địa chỉ runtime chịu ASLR.
- Giá trị chưa chứng minh phải ghi `UNKNOWN` và fail closed.
- Hash, TypeInfo, managed layout và native anchors là một profile nguyên tử.
- Hoàn tất test offline và probe chỉ đọc trước khi xin người dùng live test.

## 1. Khóa danh tính build

1. Xác định reverse mới và reverse/report gần nhất đã pass.
2. Đọc launcher, `GameAssembly.dll`, `UnityPlayer.dll` và
   `global-metadata.dat` trong thư mục game thực.
3. Ghi tên/kích thước/SHA-256; PE architecture, timestamp, preferred base,
   `SizeOfImage`; metadata magic/version.
4. Kiểm tra launcher name, process name, window title, Unity data-directory và
   PlayerPrefs registry owner. Lấy company/product từ `app.info`; không suy
   registry owner từ tên EXE hoặc sự tồn tại của một khóa cũ.
5. Tạo compatibility report và `reverse/<build>/README.md` ghi provenance.

## 2. So sánh toàn bộ contract managed

Phải so tất cả root mà production reader dùng:

- board/lifecycle: `Board`, `Active`, `ManagerMatch`, `MatchService`,
  `MatchHost`, `MatchSceneLoader`, `HubSuspendManager`, `TurnAnnouncer`;
- transport/ACK: `ChatService`, `ChatMessageDTO`, `WsCombatBatch`,
  `BoardWsApplier`, dispatcher closure/list/queue;
- cell/card/pet/QTE: `Dot`, `CardUI`, `FusionCardUI`, co-op
  `Active.PlayerStats`, `PetUserDTO`, `CardData`, `AuditionStage`,
  `AuditionChallenge`;
- lobby/map: `ManagerQuangTruong`, `ManagerRoom`, `WsRoomService`,
  `RoomCoopV2View`, `UIPanelManager`, `ChinhPhucDataService`;
- opening JSON: `JArray`, `JObject`, `JProperty`, `JValue`.

Với mỗi type: match exact namespace/name/.NET type; ghi TypeInfo RVA; diff field
order/offset và static owner; phân biệt class/array/nested type/co-op/PVP; kiểm
tra enum, sentinel và domain như lifecycle, RoomStartState, QTE, multiplier.
Ghi thêm class mới/xóa/thay đổi có thể ảnh hưởng UI hoặc flow.

Trước khi sửa source, có thể tạo candidate audit bằng
`tools/audit_game_update.py --old <reverse-cũ> --new <reverse-mới>
--install <thư-mục-game> --output <artifact>/static_audit.json`.
Source hiện tại phải còn ứng với `--old`; dùng `--source` trỏ baseline nếu
đang kiểm lại migration đã làm. Script chỉ đọc file, không tự patch source
hoặc cho phép build. Field tìm theo offset chỉ là candidate, phải kiểm lại
tên/kiểu/ownership trước khi áp dụng; nested/compiler closures phải lần riêng.

## 3. Kiểm tra native bridge và UI

1. So hash `UnityPlayer.dll`; dù không đổi vẫn kiểm lại byte signatures.
2. Từ wrapper `Component_get_gameObject`, decode RIP-relative load/store để
   tìm cache global mới; cả hai instruction phải cùng trỏ một RVA.
3. Tìm managed/native unmarshal bằng prefix có ý nghĩa, yêu cầu unique match và
   lưu đủ byte signature để fail closed.
4. Kiểm tra managed/native roundtrip và UnityPlayer MZ/base.
5. Đọc lại RectTransform runtime của Start/result/close/boss-cell Button. Không
   lấy tọa độ ảnh hoặc badge/order number làm authority.
6. Kiểm tra Canvas mới/nested WorldSpace Canvas, active/interactable,
   CanvasGroup, modal, foreground và geometry stability.
7. Diff semantics của nút/state; cùng một button có thể là Start, ReadyOff hoặc
   CancelCountdown ở các phase khác nhau.
8. Lưu ảnh fixture có provenance của Start/room, main hub, island/boss map,
   WIN và LOSS/aborted nếu có. Chứng minh đúng nút, label đã hiện, không
   nhập nhằng và không click trong reward animation. Scale fixture chỉ là
   test biến đổi, không tính thành live trên nhiều profile.
9. Kiểm riêng ánh xạ **board cell -> input pixel**: provider đọc đúng 64 ô
   không chứng minh tọa độ click đúng. Diff HUD layout, DotsArea/content rect,
   padding/frame gap và công thức tâm ô trong reverse. Đối chiếu ảnh client-only
   thật, ghi rõ pitch theo pixel khác kích thước local/world và sprite art.
   Đồng bộ production calibration/default/fallback; kiểm 64 tâm ô, 112 cặp
   swap, mép bàn và 4 profile 2:1 với jitter người dùng yêu cầu. Không đổi jitter
   hoặc input pacing để bù một calibration sai. Live phải xác nhận move/ACK.

## 4. Cập nhật một profile đồng bộ

1. Cập nhật launcher-family resolver và migration đường dẫn cũ.
2. Allowlist đúng một GameAssembly hash đã chứng minh.
3. Cập nhật toàn bộ TypeInfo RVA và managed offset thực sự thay đổi.
4. Cập nhật native anchors/signature cùng regression test pin exact value.
5. Cập nhật metadata discovery, file picker, process/window discovery và
   utility path đang dùng trong production.
6. Không sửa solver/policy gameplay nếu evidence không cho thấy contract đó
   đổi.
7. Cập nhật `docs/il2cpp_symbols.md`, `docs/board_resolution.md`, compatibility
   report; mọi điểm chưa xác minh ghi `UNKNOWN`.

## 5. Verification không input

1. Chạy test game location/hash, TypeInfo constants, layouts, native bridge.
2. Chạy compile/import checks.
3. Attach tiến trình bằng quyền query/read-only.
4. Xác minh exact executable path, hash, module size và native bridge.
5. Đọc lifecycle/surface; kết quả phải khớp màn hình hiện tại.
6. Resolve TypeInfo đã initialize; null ngoài scene có thể hợp lệ, sai class
   hoặc pointer không hợp lệ là lỗi.
7. Chạy full regression. Không tự mở tool sau khi fix nếu user chưa yêu cầu.
8. Khi test lỗi, phân biệt fixture còn layout cũ, bug runtime và rejection
   đúng của calibration/source gate cũ. Không nới gate hoặc rebind bằng chứng
   live cũ để làm test xanh. Ghi rõ calibration cần requalify sau migration.

## 5a. Khi được yêu cầu kiểm tra cơ chế phát hiện auto

- So với bản trước, phân biệt tên field/metadata, native path có caller và
  remote/backend policy thực tế. Ghi UNKNOWN nếu chưa có bằng chứng.
- Rà API process/window/hook/debug, clock, combat report và QTE/input paths;
  keyword không có hit không chứng minh không có cơ chế phát hiện.
- Import native đơn lẻ không chứng minh application đang dùng nó để quét.
- Đánh giá ảnh hưởng đối với read-only memory + normal input hiện tại.
  Không đổi pacing để né phát hiện, không che process, spoof hoặc bypass.

## 6. Live acceptance giới hạn

- B1 một trận: room identity, đúng button/state, một entry click, opening 8x8,
  participant, một swap có ACK, card/QTE nếu phát sinh, result và return room.
- B2 ba trận: fresh MatchId, không duplicate input, không vi phạm Pass policy,
  fresh ownership, postmatch và re-entry.
- Chỉ sau PASS STRONG mới tăng soak. Mismatch phải quay lại bước evidence tương
  ứng; không nới validator chỉ để ép chạy.

## Prompt dùng lại cho chat sau

```text
Game vừa update. Reverse mới ở <REVERSE_PATH>. Reverse và compatibility report
gần nhất đã pass là <PREVIOUS_REVERSE_PATH> và <PREVIOUS_REPORT_PATH>.

Hãy làm compatibility migration đầy đủ theo
docs/game_update_compatibility_runbook.md. Không đoán và không chỉ thay hash.
Phải:
1. giữ nguyên mọi thay đổi chưa commit trong D:\PokiguardToolV2;
2. chỉ đọc thư mục game thật, không sửa/patch/rename/delete file game;
3. ghi build identity gồm launcher/process/window/data-directory, SHA-256,
   PE và metadata;
4. diff toàn bộ TypeInfo + managed field/static offsets production đang dùng,
   phân biệt exact namespace/type/class/array và co-op/PVP;
5. kiểm tra GameAssembly native anchors, UnityPlayer signatures,
   managed/native roundtrip, UI ownership/geometry, Canvas và button semantics;
6. kiểm tra board, lifecycle, ACK/transport, card, pet/QTE, boss lobby, map,
   result/re-entry và multiplier/domain;
7. cập nhật atomically code + tests + docs/il2cpp_symbols.md +
   docs/board_resolution.md + compatibility report mới; UNKNOWN phải ghi rõ và
   fail closed;
8. chạy focused tests, read-only live attach/probe và full regression;
9. không gửi input, không tự mở tool và không build release trước khi báo kết
   quả offline. Sau đó đưa kịch bản B1/B2 giới hạn để tôi tự live test.

Cuối cùng báo rõ thứ gì đổi, thứ gì giữ nguyên do đã so sánh, bằng chứng trực
tiếp, test đã pass và phần còn cần live acceptance.
```
