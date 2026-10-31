# Log máy người dùng khác: bỏ lượt và dừng9/500 — 2026-10-24

Nguồn chỉ đọc: `C:/Users/Admin/Downloads/log/f8fb6238d864435aacf40bcfc590b905`.
Đã đọc cả9 combat logs, events, run và checkpoint. Không điều khiển Explorer,
game hoặc máy người dùng. Bộ gửi không có Player.log/desktop_ui/ảnh thời điểm lỗi.

## Kết luận

Có hai hiện tượng riêng. **Một lượt không đi trong trận9** trong lúc client
chặn trạng thái bàn cờ rồi reconnect; tool sau đó chơi tiếp và WIN. **Dừng hẳn
9/500** xảy ra sau click nhận thưởng vì phòng trả về thiếu RoomDTO/boss identity,
đúng shape của [bản sửa bootstrap re-entry vừa hoàn thành](postmatch_bootstrap_reentry_fix_20261024.md).

Thiết lập: BASIC, Demon Farm/Khiên/2 Kiếm, Solo, pet thường/không tiến hóa,
pet passive, two-click, `pinned_foreground_lease_beta`, target Lieyun1436,
500 trận/maxattempt505. Không phải phiên suy luận.

## Timeline trận9, giờ Việt Nam

| Giờ | Dữ liệu |
| --- | --- |
| 16:17:59.646 | Bắt đầu `M_88db3fbf` |
| 16:18:04.268 | Gửi SWAP lượt1; được xác nhận |
| 16:18:14.295 | Gửi SWAP lượt3; được xác nhận |
| 16:18:17.302 | Quan sát lượt5 của ta, remaining14 |
| 16:18:18.005 | Gate `BOARD_NOT_MOVE_STATE`, boardCurrentState0 |
| 16:18:35.866 | Gate `PRESENTATION_BUSY` |
| 16:18:37.025 | Gate `RECONNECTING`, reconnecting=true |
| 16:18:40.267 | Provider chưa có complete batch được ACK chứng thực hiện tại |
| 16:18:48.355 | Đã sang lượt6 boss; nhận `MATCH_AFK_WARN`, idleCount1/threshold3 |
| 16:18:50.273 | Quan sát lượt7 của ta |
| 16:18:56.156 | Gửi SWAP lượt7, được xác nhận |
| 16:19:03.744 | Hoàn tất delivery SWAP lượt9 |
| 16:19:13.843 | Trận9 WIN, terminal strong, UI nhất quán |
| 16:19:17.406 | Click xác nhận thưởng SENT |
| 16:20:47.884 | Hết90 giây đợi phòng, SAFE_STOP/RETURN_LOBBY_TIMEOUT |

Trận1–8 đi đủ mọi lượt local đã quan sát. Trận9 đi các lượt1/3/7/9, chỉ
lượt5 không có action. Không có intentional PASS, too_late, misclick, partial
input, action response timeout hoặc local-turn deadline stop trong summary.
Cả9 combat controllers kết thúc `COMBAT_LIFECYCLE_ENDED`, WIN, không auto-pause.
Tổng18 SWAP =9 ACK +9 terminal exclusions; không suy terminal exclusions là
9 input lỗi.

Reverse b10 `GameState.cs` vẫn có wait0/move1, `Board.currentState +0x78`.
Gate chặn0 là đúng semantics đã có; không có bằng chứng enum đổi khiến tool
đọc nhầm. `RECONNECTING` là trạng thái quan sát được, chưa chứng minh lỗi
đường truyền, server, client hay một nguyên nhân sâu hơn. Thiếu Player.log và
ảnh nên không quy lượt5 cho một thay đổi game cụ thể hoặc cho random click.
Không bỏ gate/chạy input trên state thiếu chứng cứ để che triệu chứng này.

## Fix đã áp dụng và kiểm lại

Snapshot cuối của máy này giữ WS room`Coop_252354`/type`ChinhPhuc`/local host,
nhưng RoomDTO/boss fields rỗng; reader báo properties thiếu boss identity.
Đây là cùng lỗi coverage của phiên87/120, không cần thêm một runtime exception
khác theo tên tài khoản, room ID hay địa chỉ máy này.

Đã thêm nguyên snapshot có provenance vào
`tests/fixtures/room_bootstrap_failure_external_user_20261024.json` và một ca
replay đường pinned thật của controller với native IO/input fakes. Bản sửa
hiện tại nhận timeout này → chứng minh/đóng shell → chỉ sau đó scan/chọn lại
đúng target1436 → trả phòng ready; giữ số trận/attempt/target. Thao tác đóng
shell vẫn đòi native Start geometry +hai frame +fresh room key. Target vẫn
đòi native Button/Pet association; không lấy boss mới từ phòng hỏng.

**133/133 test liên quan PASS**, gồm toàn bộ19 ca bootstrap re-entry, gate,
pinned, waiter, modal và VM room recovery. Runtime byte-preserved so với bản
bootstrap fix đã qua758 bài regression; lượt này chỉ thêm fixture/test và
báo cáo. Đây là kiểm chứng offline, không phải live PASS trên máy khách.

[Evidence/hash/timeline từng combat](artifacts/external_user_log_review_20261024/evidence.json).
[Verification](artifacts/external_user_log_review_20261024/verification.json).
Source357files:
`48b73af8b68204afe0d7a4f0ae4116c09d49b8108c361620067f0465f2fd2a37`.

Log không ghi version/build/source hash đủ để xác định chính xác binary khách.
Phiên đã dừng không có hành vi re-entry mới; ZIPv1.2.8 phát hành trước bản sửa
không chứa fix source này. Chưa rebuild/đổi version, không sửa old artifact hay
repin authority Phase5. Cần đóng gói bản source đã sửa trước khi gửi máy khách;
không kỳ vọng source trên máy này tự cập nhật binary ở máy người dùng khác.
