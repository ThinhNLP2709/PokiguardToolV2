# Bú win + Coop trong phòng người khác — 2026-10-10

Đã bổ sung vào source. Phase 5B.3 vẫn tạm dừng; thay đổi này phục vụ yêu cầu
chơi Bú win trong phòng do người khác làm chủ.

## Hành vi

1. Người dùng tự tham gia phòng boss, chọn Bú win + Coop rồi bấm Start trên tool.
2. Tool xác nhận boss, Room ID, chủ phòng và trạng thái nút chính từ memory.
   Phòng khách được chấp nhận cho cấu hình này; các lối chơi solo vẫn cần chủ phòng.
3. Tool dùng đúng nút `ManagerRoom.ButtonStart`, hình học runtime và kiểm chứng
   ảnh hiện có để bấm Sẵn sàng một lần. Không dựa vào chữ trên nút để chọn vị trí.
4. Tool chờ chủ phòng bắt đầu. Ready không được tính là một trận đã vào;
   cần Match ID mới, session và bằng chứng board theo luồng entry hiện có.
5. Khi vào trận, dùng chiến thuật Bú win hiện có: chọn nước hợp lệ để chừa kiếm
   cho boss, không sử dụng card hay tiến hóa.
6. Khi pet local chết, ngừng phát nước đi và chờ kết quả của đội. HP local bằng
   0 không tự chứng minh thua trong Coop. Khi có bằng chứng kết thúc và boss HP
   bằng 0, có thể ghi nhận thắng dù pet local đã chết. Winner string chưa được
   kiểm chứng vẫn UNKNOWN; tín hiệu mâu thuẫn giữ cơ chế kiểm tra hiện có.
7. Tool xử lý màn hình kết quả/nhận quà và quay về lobby bằng luồng sẵn có,
   xác nhận lại đúng Room ID và chủ phòng rồi Ready lượt tiếp theo đến giới hạn
   số trận đã cài.

Không thêm thao tác tìm phòng hoặc tự join phòng. Không thay solver Bú win,
thứ tự đọc state/capture trong combat, executor, QTE hay quy trình nhận quà.
Các lần đọc bổ sung chỉ kiểm tra phòng trong lúc chờ chủ phòng bắt đầu.

## Dừng và log

- Không click Ready lần hai để retry: cùng nút có thể chuyển thành ReadyOff.
- Idle + `_myReady=false` vẫn là điều kiện trước click. Nếu người dùng đã
  Ready từ trước khi Start, tool chưa tự tiếp quản trạng thái đó; không toggle Off.
- Thời hạn chờ chủ phòng dùng `max(entry_timeout, lobby_timeout)`, mặc định
  180 giây ở FarmRun. Hết hạn dừng với `COOP_READY_WAIT_TIMEOUT_NEW_SESSION`.
- Đổi phòng/chủ phòng dừng với `COOP_ROOM_CHANGED`; bị đá ra thì dừng, không
  tạo lại phòng của người khác. Lỗi kỹ thuật trong Coop dừng và ghi log, không
  tự thoát/re-entry qua nhánh recovery của solo.
- Dùng log JSONL hiện có: `coop_room_bound`, `coop_ready_acknowledged`,
  `bu_win_wait_teammates`, `coop_room_ejected`, `coop_technical_stop`, cùng log
  terminal/postmatch. Sự kiện chờ đồng đội chỉ ghi một lần mỗi session.

## Kiểm chứng

- 275 kiểm thử tập trung: PASS.
- Toàn bộ regression: **1.853 tests PASS**, 66.409 giây. Log tại
  `temp/bu_win_guest_regression_20261010.log` (artifact cục bộ, không commit).
- Bổ sung kiểm thử guest room, quyền solo/Coop, đổi chủ phòng trước Ready,
  ghim Room ID/chủ phòng khi quay về, pet chết không phát action, thắng đội
  khi pet đã chết, tiếp tục lượt sau và không tự recovery khỏi phòng Coop.
- Kiểm tra thêm ReadyWait/Idle khi `_myReady=true` đều chặn click lại;
  winner không biết và tín hiệu kết quả mâu thuẫn không tự suy thành thắng.
- Chưa chạy farm thật hoặc phát input thật trong phiên làm việc này.
- Chưa build/ghi đè EXE v1.2.4. Thay đổi có hiệu lực khi chạy source mới hoặc
  build bản mới; EXE cũ không tự nhận cập nhật source.

## Kiểm chứng trực tiếp còn lại

1. Dùng bản chạy từ source mới hoặc bản build từ source này, tự vào phòng
   người khác, để nút game ở Sẵn sàng và chọn Bú win + Coop.
2. Bấm Start tool; kiểm tra tool chỉ click một lần, game chuyển sang đã Ready,
   không có click lặp trong khi chủ phòng chưa bắt đầu.
3. Chủ phòng bắt đầu trong thời hạn chờ; kiểm tra Match ID mới, nước đi Bú win
   và việc ngừng thao tác khi pet chết.
4. Chờ đội thắng: kiểm tra nhận quà, quay về đúng phòng, Ready cho trận kế;
   đối chiếu kết quả và các sự kiện log nêu trên.

Nếu không có bằng chứng terminal đủ rõ, xem log trước khi kết luận thắng/thua;
không dùng thời điểm pet local chết làm nhãn kết quả cả trận.
