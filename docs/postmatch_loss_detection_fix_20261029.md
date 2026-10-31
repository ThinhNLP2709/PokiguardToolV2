# Không nhận nút Đồng ý trên màn Thua — 2026-10-29

Đã xác định và sửa lỗi của phiên `147ef987f988438c8ffb59878ecf6da2`.
Phiên chạy Mega Icarus BASIC, Solo, Lienor ID2217, target3trận; AI/shadow tắt.
Tool đã kết thúc cả3combat nhưng dừng lỗi ở bước xác nhận kết quả trận3.

## Trạng thái và nguyên nhân được chứng minh

| Trận | Match | Kết quả ghi nhận | Nhận thưởng/về phòng |
|---|---|---|---|
| 1 | M_61f5235e | WIN STRONG, UI Thắng | Bình thường |
| 2 | M_b7b09d8f | UNKNOWN/PARTIAL, UI Thắng | Bình thường |
| 3 | M_871d66c2 | LOSS STRONG, ảnh cuối HP0 và bảng Thua | Không nhận diện được Đồng ý |

Không sửa UNKNOWN thành WIN: ảnh/UI thắng không tự thay thế terminal memory
proof còn thiếu. Checkpoint gốc giữ1WIN/1UNKNOWN/1LOSS, completed3/target3.

Giờ Asia/Saigon ngày29/10/2026:

- 00:15:49.692: gửi SWAP turn121; ACK lúc00:15:50.347.
- 00:15:54.890: server `MATCH_GAME_OVER`, winner `__BOSS__`, chuyển POSTMATCH.
- Trong cửa sổ chờ, ảnh đầu còn animation; ảnh cuối đã có bảng **Thua**, HP0
  và nút **Đồng ý** xanh rõ ràng.
- 00:16:27.525: sau31samples/30.75s, tool SAFE_STOP
  `POSTMATCH_UI_AMBIGUOUS`; không có confirm input của trận3.
- Log UI ghi game process thoát nhiều giờ sau; không dùng việc đó giải thích
  nguyên nhân stop ban đầu.

Detector arena đã chứng minh được panel xanh, đủ4góc vàng, nhưng đòi **hai
cánh băng trắng của màn Thắng**. Màn Thua dùng sừng tím/phù hiệu kim loại khác.
Cánh trái chỉ1110pixel so với ngưỡng1474.56; bị loại trước khi xét nút xanh.
Fallback cũ tìm banner/nút màu cam nên cũng không nhận được màn Thua mới.
Replay đúng PNG native tái hiện FAIL trước sửa, không suy đoán từ stop code.

Các PASS quan sát trong trận3 ở turn25,27,79 nhận AFK1,2,1 theo các chu kỳ;
không có AFK3 được log. Trận3 có49SWAP/49ACK và terminalLOSS trước tool stop.
Không quy việc thua cho lỗi dừng lựa chọn nước trước đây, và không thay tactic
hoặc đoán công thức damage để sửa lỗi nhận thưởng này.

## Thay đổi

Chỉ sửa `src/pokiguard_v2/postmatch_ui.py`:

- Giữ nguyên proof màn Thắng bằng hai cánh băng.
- Thêm một header variant cho màn Thua: mỗi bên đúng1sừng tím,1phù hiệu kim
  loại ở giữa và chữ sáng trong banner; kiểm cả kích thước/vị trí theo viewport.
- Vẫn bắt buộc panel lớn,4góc vàng, đúng1nút xanh ở vùng hợp lệ và chữ trên nút.
  Thiếu bất kỳ proof bắt buộc nào vẫn không cấp tọa độ.
- Tọa độ click lấy từ component nút phát hiện được, không hard-code điểm bấm.
  Detector chỉ nhận control; không dùng màu/header để tự đổi kết quả trận.

Không đổi FarmRunner/controller/provider/BASIC/solver/QTE/executor/ACK/Stop,
timeout, frequency/order đọc memory hoặc capture. `_confirm_postmatch` vẫn
giữ proof3frames và fresh preflight hiện có. Không thêm retry/auto re-entry hay
phát input khi combat chưa kết thúc.

## Kiểm chứng

**168tests liên quan PASS**, gồm8regression mới:

- PNG Thua native;4profile kích thước là biến đổi cùng ảnh, không gọi là4live.
- Animation chưa có bảng: từ chối. Thiếu từng sừng, phù hiệu, chữ tiêu đề,
  panel/góc/nút/label: từ chối. Hai nút xanh: từ chối.
- Luồng `_confirm_postmatch` thật với capture/native/input giả: animation rồi
  3ảnh Thua ổn định và fresh check, đúng1confirm;3memory polls như owner cũ,
  giữ1LOSS và total_postmatch_inputs1. Không click game thật.
- Màn Thắng/legacy layouts, các màn khác, farm/result/return/re-entry/leave guards.

365AST/compile PASS,363Python files cũ byte-exact; thêm1test file và2PNG native
có provenance/SHA. Source
`782aba5054d9a7da84ca244750a7d3821318e633bacccf47fc2949b2ab306289`.

[Before regression](artifacts/postmatch_loss_fix_20261029/before_regression.log),
[after8cases](artifacts/postmatch_loss_fix_20261029/after_regression.log),
[168tests](artifacts/postmatch_loss_fix_20261029/focused_tests.log),
[verification](artifacts/postmatch_loss_fix_20261029/verification.json),
[diagnosis/raw hashes](artifacts/postmatch_loss_fix_20261029/diagnosis.json),
[diff](artifacts/postmatch_loss_fix_20261029/runtime_changes.diff).

## Bàn giao và Phase5

Đã sửa source; chưa live lại, chưa build/version/restart hoặc Start tool/game.
UI đang mở đã nạp code cũ, cần phiên mới khi test. ZIP1.2.10 chưa chứa sửa này.
Không thay checkpoint/accounting của phiên cũ.

Đây là maintenance trước khi quay lại suy luận. E2 offline evidence vẫn gắn
source dbbe59…; current source đã khác chỉ ở postmatch locator/test. AI R1,
runner/log/deadline/fallback/controller/read/input không đổi. Không tự rebind
timing/authority hay gọi đây là E2live; draft E2 cũ vẫn inert và sẽ cần refresh
source binding trước activation. Cap25(5B+20R) và next cùng5E.2 giữ nguyên.
