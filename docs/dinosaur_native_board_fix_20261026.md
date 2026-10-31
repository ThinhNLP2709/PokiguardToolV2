# Khủng long: mất bằng chứng native giữa hai poll — 26/10/2026

Đã sửa một lỗi trong provider khi bắt đầu giữa trận. Lỗi đã tái hiện offline
bằng `MemoryBoardStateProvider.poll()` thật: native board đủ64ô qua mẫu đầu,
nhưng mẫu thứ hai bị loại vì mất current-session witness. Không sửa policy,
random, deadline, ACK hay flow boss farm. Chưa live lại Khủng long và chưa
build ZIP mới.

## Log và nguyên nhân

Nguồn người dùng khác:
`C:\Users\Admin\Downloads\log\e11a3a9e50834eb3b1dff212ee6e3564`.
Match `M_638e3f14`, từ11:15:06 đến11:18:29 ngày25/10/2026, giờ Việt Nam.
Giữ nguyên folder gốc; đã chụp bản sao3file log vào artifact của tác vụ.

- Tool quan sát17lượt local, gửi9SWAP và nhận đủ9ACK; không có read error.
  Các lượt có input:1,3,5,9,11,15,21,27,29. Các lượt không có input:
  7,13,17,19,23,25,31,33. Đây không phải9click thất bại hay random kéo lệch.
- Native reader đã nhận36board hợp lệ. Một số ACK không có DTO8x8 được
  transport giữ lại; log cũng ghi10response không decode được board8x8.
  Chưa đủ dữ liệu để khẳng định vì sao server/transport không có đủ DTO.
- 11:18:15.216 ởturn33/move9/ACK67: provider báo
  `awaiting_stability_confirmation`, confirmations=1 và native reason
  `current_settled_board_owned_and_ack_stable`.
- 11:18:15.329: cùng generation `[33,9]`, chuyển sang
  `latest_acked_batch_not_resolved`, confirmations=0.
- 11:18:29.839: vẫn ACK67 nhưng lastAccepted65; countdown0 và đã nhận
  `MATCH_AFK_WARN idleCount=2`. Controller dừng
  `LOCAL_TURN_ACTION_DEADLINE`. Đây là chốt an toàn sau khi provider bị kẹt,
  không phải nguyên nhân bắt đầu mất nước đi.

`current_session_strong` được tạo lại ở mỗi poll từ owner/transport. Poll có
native fallback đã thêm native identity vào set này; poll kế tiếp chỉ giữ
owner/transport nên quên native identity. Trong chế độ `active_combat_start`,
eligibility bắt buộc giao ACK với set này, khiến native board mới đọc bị loại.
Trong khi đó `have_highest`/generation cache đã biết có native board nên không
đọc lại nó. Nếu có đủ DTO transport thì không gặp nhánh lỗi, giải thích vì sao
cùng trận vẫn có9nước thành công.

[Số liệu/timeline trích từ log](artifacts/dinosaur_native_board_fix_20261026/diagnosis.json),
[bản sao nguồn log](artifacts/dinosaur_native_board_fix_20261026/external_log/).

## Bản sửa

Chỉ thêm một block vào `MemoryBoardStateProvider.poll()`, sau khi phân loại
recovery ACK epoch và xác định generation hiện tại. Với
`active_combat_start=True` và không ở isolated recovery ACK epoch, khôi phục
current-session witness từ native identity đã được xác minh, khi:

- identity vẫn có trong tracked data;
- sequence vẫn nằm trong ACK set hiện tại;
- generation turn/localMoveSequence bằng generation đã lấy mẫu native.

Giữ nguyên kiểm tra ownership/native64ô, rig/session, ACK trước/sau, pending,
render/queue, array/flags và hai mẫu ổn định. Khi đổi phiên, cache vẫn bị xóa;
khi đổi generation phải lấy native sample mới. Transport DTO đúng ACK vẫn
được ưu tiên. Raw heap batch không được nâng thành witness. Không thêm scan,
poll, sleep, input hoặc fallback bỏ qua deadline; các mode khác không chạy
block mới.

## Kiểm chứng

- Trước sửa, test real provider tái hiện đúng: mẫu1 confirmations1, mẫu2
  `latest_acked_batch_not_resolved`; cùng fixture ở provider thường PASS.
  [Log trước sửa](artifacts/dinosaur_native_board_fix_20261026/before_regression.log).
- Sau sửa12test mới PASS: hai poll xuất board một lần, poll3 dedup; normal
  provider giữ hành vi; đổi turn/move/session, ACK race/mất ACK, render bận,
  untracked cache, unbound heap và isolated recovery epoch đều không được
  dùng witness sai. Full transport DTO vẫn giữ ưu tiên và cần hai mẫu riêng.
  Fixture dùng fake read-only memory/native boundaries, không tuyên bố đã
  replay pixel/board thật ởturn33.
-397test liên quan PASS: Dinosaur, memory/native provider, ACK, lifecycle,
  actionability/controller, idle/pass/recovery, BASIC policy, opening, desktop,
  game location và random. [Kết quả](artifacts/dinosaur_native_board_fix_20261026/regression.json),
  [log](artifacts/dinosaur_native_board_fix_20261026/regression.log).
-362file Python compile/AST PASS. Chỉ1runtime file cũ đổi;360file Python cũ
  còn lại giữ nguyên bytes; thêm1test file. Bỏ đúng block mới khỏi AST thì AST
  module bằng trước tác vụ. Không thay version/build, không nới source/timing
  authority; kết quả397test là suite liên quan, không phải full repository PASS.
  Các pin source lịch sử vẫn mang hash ở thời điểm lập báo cáo của chúng.

Source trước:
`447d3cf526e748c0451e52c53b892ac8eddfc9bbad4fb6705aa114b5e0f3803f`.
Source sau:
`7f7820695c6c3af74ce046687d83b9068a0792615d43d34ac49cb5c6c4bd3fa6`.
[Scope và verification](artifacts/dinosaur_native_board_fix_20261026/verification.json).

Khi live lại cần phiên source mới: người dùng tự vào trận Khủng long, chọn
Khủng long và Start trong tool; đánh một trận hiện tại rồi dừng như yêu cầu.
Cần quan sát ít nhất một lượt native fallback sau lượt mở đầu, hai xác nhận,
SWAP/ACK và kết trận. Bản ZIP1.2.9 cũ chưa chứa sửa đổi này.

## Đối chiếu trận BASIC b12 vừa chạy

Run `179f7070543c4ab9b04c63abada72634` ghi1/1WIN,2SWAP; nước đầu có ACK,
nước cuối được xác nhận bởi terminal WIN. Memory result và hộp thoại `Thắng`
nhất quán, có bước nhấn xác nhận thưởng. Sau đó không còn đúng phòng boss,
tool đi vào nhánh re-entry nhưng dừng `FOREGROUND_LOST` khi chứng minh room
shell. Log không chứng minh ai/cơ chế nào làm mất focus. Vì vậy chỉ chốt
combat/result; chưa chốt toàn bộ return/re-entry và chưa tính B1 PASS STRONG.
Không đổi guard focus trong tác vụ sửa Khủng long.
[BASIC1 observation](artifacts/dinosaur_native_board_fix_20261026/b12_basic1_observation.json).
