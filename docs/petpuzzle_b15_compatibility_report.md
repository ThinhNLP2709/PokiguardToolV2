# Pet Puzzle 1.7.4 B15

Profile B15 đã qua kiểm tra offline và đọc đúng phòng Lieyun lv77, đảo Thập nhị tinh. GameAssembly SHA-256 là `18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea`. Metadata vẫn là 111. Launcher và UnityPlayer 6000.7.0b7 có SHA-256 trùng B14.

Đối chiếu hai bản Il2CppDumper theo tên khai báo cho thấy cả 39 TypeInfo RVA đã đổi. Trong 257 field được reader dùng, chín offset dịch trong `ChatMessageDTO`. `preBoard` và `preBoardReady` chuyển đến `+0x4C0` và `+0x4C8`. Bảy trường kết quả QTE dịch `+0x18`. Vùng đọc QTE hiện kết thúc ở `0x1D0`, đủ cho `Nullable<long> qteChallengeId` tại `+0x1C0`.

Managed wrapper `Component.get_gameObject` ở RVA `0x353AB90` đọc và ghi cùng cache `0x456E020`. Tiến trình B15 xác nhận cache đó trỏ đến UnityPlayer RVA `0x1197500`. Signature Unmarshal mới ở `0x1BD423C`. Disassembly xác nhận cùng logic giải mã handle, `Il2CppClass.static_fields +0x98` và closure nhận WebSocket `324_0`.

Disassembly chuẩn hóa của `MatchHudV2.SolveBoard` và `Board.GetCellBaseWorldPosition` khớp B14. `Dot.multiplier +0x88`, `BoardCellDTO.multiplier +0x20`, cấu trúc MatchService, RoomCoopV2Refs và tám layout generic đã đối chiếu vẫn khớp. Các field Fantasy mới trong DTO và BoardWsApplier nằm ngoài phần reader sử dụng. Phân loại mới `PetTier.Fantasy=5` xuất hiện trong export. Hành vi riêng của pet Fantasy cần bằng chứng trong trận.

Kiểm tra tập trung qua **414 test**. Hồi quy rộng chạy 2.944 test, ghi nhận 251 failure và 25 error. Trong 276 bản ghi lỗi, 269 cũng có ở lần hồi quy B14, năm ghim offset QTE của 1.7.4.9, một fixture ghim TypeInfo B14 đã được cập nhật và kiểm lại thành công, một ca timing writer qua lần chạy riêng. Các log gốc và phân loại nằm trong [evidence](artifacts/game_1_7_4_b15_20261105/regression_classification.json).

Đọc trực tiếp xác nhận phòng và nút Bắt đầu thuộc Canvas đang hoạt động. Khi game ở phía trước, vị trí nút khớp với ảnh ở mức tin cậy 0,99. Kiểm tra trọn vòng trận, QTE thực tế và kết quả trên B15 vẫn cần một trận live. Hồ sơ timing B14 gắn với GameAssembly cũ nên không cấp quyền Suy luận cho B15.

## Bản đồ Thập nhị tinh mới

Ba lần đọc trên bản đồ B15 đều xác nhận đúng Lieyun lv77, ID 1436, ô số 5. `ManagerChinhPhuc.OnReceived` lấy danh sách Button của panel tại RVA `0x13BD30A` và gắn callback chọn boss tại `0x13BE6E5`. Nút được luồng re-entry chọn có callback giữ pet ID 1436 và trỏ về đúng manager đang hiển thị. Điểm đọc từ RectTransform là `(0.68395, 0.40561)`, tương ứng khoảng `(875, 260)` trong vùng game 1280×640. Điểm này nằm trên Lieyun theo ảnh bố cục mới.

50 test bản đồ, thoát phòng lỗi và re-entry qua. Trong phiên BASIC B15, sau trận 1 tool đã click Lieyun số 5, vào lại phòng và bắt đầu trận 2. [Bằng chứng đọc bản đồ](artifacts/b15_lieyun_reentry_20261106/readonly_map.json).

Sau trận 2, tool nhận thưởng và có hai mẫu nút Lieyun ổn định. Lần đọc kiểm lại ngay trước click trả về rỗng khi game vẫn ở đúng đảo. Code cũ dừng ở bước đó và báo `RETURN_LOBBY_TIMEOUT`. Log chưa xác định được nguyên nhân bên trong lần đọc rỗng. Source đã cho phép tối đa bốn lần đọc ở bước kiểm này khi vẫn khớp manager, đảo và boss đã xác nhận. Bản ghi nút thay đổi tiếp tục bị từ chối. Ca tái hiện và 248 test tập trung qua. Bản sửa này đang ở source và chờ đóng gói, kiểm live. [Kết quả điều tra](artifacts/b15_reentry_preflight_20261106/result.json).

ZIP 1.3.1 cho B15 đã qua kiểm tra checksum, nội dung và hai self-check của EXE giải nén. [ZIP Windows x64](../build/v1.3.1-b15/PokiguardToolV2-v1.3.1-win-x64.zip).

[Static audit](artifacts/game_1_7_4_b15_20261105/static_audit.json), [read-only native](artifacts/game_1_7_4_b15_20261105/readonly_native.json), [room probe](artifacts/game_1_7_4_b15_20261105/readonly_boss_room_verified.json).
