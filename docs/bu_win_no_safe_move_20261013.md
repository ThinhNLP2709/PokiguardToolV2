# Bú win dừng 4/7: chốt tránh kiếm xung đột với mục tiêu chừa kiếm

## Nguyên nhân đã xác định

Run `abf8415a1b06405883bafb4368e6dce7` hoàn thành bốn trận, vào trận thứ
năm `M_5ee43f63`, rồi dừng lúc **00:06:26 ngày 13/10/2026** (giờ Việt Nam).
Lý do cuối là `COMBAT_SAFE_STOP / POLICY_NO_SAFE_MOVE`. Đây là dừng trong
bước chọn nước ở lượt 3, server sequence 8; trận thứ năm chưa có input.

Log `policy_branch_observed` đã chọn nhánh `BU_WIN_FEED_BOSS`, action SWAP.
Bàn cờ có **9 nước tạo match hợp lệ, 0 nước đạt tiêu chí tránh kiếm**.
Chốt chung `_must_pause_for_no_safe_move` thấy safeMoveCount=0 và dừng
trước bước phát input, dù policy Bú win đã chọn được nước đúng mục tiêu.

Trong simulator, `safe` đánh giá rủi ro kiếm còn lại/phát sinh, không phải
điều kiện swap hợp lệ. Bú win chủ động chừa kiếm để boss đánh chết pet
local; áp chốt tránh kiếm của lối chơi sinh tồn cho nhánh này là sai mục tiêu.
Tại thời điểm dừng HP local còn 4388/6269, timerRemaining=13; đây không phải
hết thời gian, không phải pet đã chết, cũng không phải chờ bảng thưởng.

Nước đã chọn theo tọa độ màn hình, đánh số từ 0: `(0,7) -> (1,7)`.
Nó ăn 3 Khiên, không ăn Kiếm đã biết, để lại phản hồi boss tối đa 4 Kiếm
hiệu dụng theo phần bàn còn tính được. Refill/damage thực tế vẫn UNKNOWN;
không khẳng định boss chắc chắn chọn nước này hay pet chết ngay.

Bằng chứng gốc trong
`logs/farm_runs/abf8415a1b06405883bafb4368e6dce7/`:

- `run.json`, `events.jsonl`: tiến độ 4/7, attempt 5, lý do dừng.
- `matches/attempt_005/combat.jsonl`: nhánh chọn nước rồi `auto_pause`.
- `matches/attempt_005/policy_pause/20261013_000626_166_POLICY_NO_SAFE_MOVE_seq8_0d398cdd5bfb/`:
  `board.json`, `analysis.json`, `board.txt` giữ state và mọi candidate.

## Sửa trong phạm vi yêu cầu

Chỉ đổi runtime tại `_must_pause_for_no_safe_move`, `tools/basic_auto_bot.py`:
nhánh `BU_WIN_FEED_BOSS` được miễn chốt tránh kiếm khi style là `bu_win`,
action đúng SWAP và có move. Những style khác hoặc nhánh sai vẫn chịu
điều kiện dừng cũ. Không đổi cách xếp hạng/chọn nước của Bú win.

Vẫn giữ nguyên kiểm tra dữ liệu mới, quyền lượt local, deadline, Stop,
mapping, normal input, pending/ACK, kết trận và nhận thưởng. Không thêm
đọc memory/chụp ảnh, delay hay vòng poll vào runtime. Không thay luật
fail closed cho pointer/state không hợp lệ.

Sửa chờ thưởng ngày 12/10 vẫn hoạt động trong run này: attempt 3 nhìn thấy
Đồng ý sau 31.969s, ổn định sau 32.609s; attempt 4 lần lượt 32.406s/33.062s.
Cả bốn attempt đã xác nhận thưởng và trở về lobby trước khi vào trận kế.
Đây là bằng chứng live cho nhánh chờ quá 30s đã sửa trước đó, không phải
bằng chứng live của bản sửa tránh kiếm ngày 13/10.

## Kiểm chứng

Fixture `tests/fixtures/bu_win_no_safe_move_20261013.json` sao chép nguyên
byte từ board.json gốc. Chỉ khôi phục kiểu enum GameOwnedIdleStatus từ
string JSON trong helper test; không sửa dữ liệu bàn, HP hoặc candidate.

Replay cùng state qua hàm chốt được trích nguyên AST từ source trước sửa
cho kết quả `oldGuardPaused=true`; source sau sửa cho
`newGuardPaused=false`. Policy vẫn chọn chính nước cũ.

Sáu test mới trong `tests/test_bu_win_no_safe_move.py` kiểm bàn lỗi thực tế,
phạm vi miễn trừ đúng nhánh, chạy
controller thật với native I/O giả qua normal input và ACK đúng một lần,
state/lượt/deadline/Stop từ chối input, pet chết không phát input và
source binding tiếp tục từ chối thay đổi controller chưa được kiểm chứng.
Test controller tái sử dụng battle/session/timer giả của harness, giữ
nguyên board và combat stats; không giả lập cả trận thứ năm hay kết quả 7/7.

157 test tập trung PASS, gồm các kiểm tra source/AST của Phase 5 có liên quan.
Lượt đầu có hai kỳ vọng sai của test mới: một
case chỉ đổi host clock dành cho adapter suy luận nhưng Bú win dùng BASIC;
pet chết được chặn sớm ở action gate trước log chờ đồng đội. Đã sửa test
để đo deadline authoritative và kiểm đúng `PLAYER_DEAD`; runtime không
được mở rộng để phục vụ hai kỳ vọng này. Giữ log lượt đầu trong artifact.

Full suite lượt đầu chạy 2088 test, bốn lỗi source/AST binding vì bản sửa
guard và việc thêm regression test vào file test đã pin từ C3. Đã chuyển
test mới sang module riêng, khôi phục nguyên byte file test cũ, và bổ sung
binding cho đúng bản sửa guard. Audit pin hash source trước/sau, chứng minh
chỉ một hàm runtime đổi, rồi mới khôi phục AST hàm cũ để so sánh riêng các
hook reasoning. Thay đổi controller trong tương lai, kể cả chỉ thêm comment,
vẫn bị từ chối ở cả source binding và AST audit. Không chỉnh manifest hoặc
kết quả acceptance lịch sử; không sửa thêm runtime khi xử lý các audit này.

Full suite lượt cuối **2088/2088 PASS** trong 251.566s. Kết quả và kiểm tra
phạm vi lưu cùng evidence tại
`docs/artifacts/bu_win_no_safe_move_20261013/`.

## Trạng thái giao bản

Source đã sửa; chưa live test bản sửa mới, chưa build EXE hoặc đổi version.
Đóng/mở lại tool chạy từ source để nhận thay đổi. Nếu chạy EXE đóng gói,
cần build lại trước khi test. Không tuyên bố đã hoàn thành 7/7.

Phase 5 giữ nguyên milestone hiện tại. Historical acceptance không được
gán lại cho source mới: manifest riêng pin đúng source trước/sau của sửa
Bú win này, đồng thời giữ hash P2 gốc trong chuỗi kiểm tra source.
