# Mega — chuẩn bị lại hiệu chuẩn trước phiên Suy luận

24/11/2026. User yêu cầu chuẩn bị lại sau khi phiên đã chọn Suy luận trên
UI thực tế chạy BASIC vì `UI_REASONING_COMMON_CALIBRATION_REQUIRED`.

## Giữ nguyên lịch sử, không gọi nhầm là Suy luận

Run `824d3bd0f0524f779e53216093f65ef8` đã dừng sau trận theo yêu cầu:
4/5 WIN, 74 SWAP/74 ACK, 9 skill Icarus, 0 technical abort/recovery.
AI selection authority false trong cả phiên. Bốn trận được giữ là BASIC;
không sửa nhãn, không làm lại checkpoint hoặc dùng WIN làm proof của R.

Phiên riêng chưa có `common.json`. Profile timing gần nhất cũng thuộc
source cũ `1d8349dc…`; không copy sang source mới rồi đổi hash. Source/game/
host và các khoảng thời gian thật phải có nguồn kiểm được.

## Đường đo mới

Thêm protocol setup `COMMON_MEGA_BASIC_SWAP_CONTROL_V1`:

- Đúng một trận BASIC, Solo, pet thường → Mega, thẻ skill, không QTE,
  foreground/two-click, cửa sổ 1280×640 và đúng transport envelope hiện có.
- Giữ lựa chọn điều kiện skill/Tự bảo vệ của user. Không đổi solver,
  policy đánh, reader, input, luật PASS hoặc reserve floor.
- Dùng BasicCalibrationActivation/SwapTimingSession, one-Start claim,
  source/build/host/config/boss và all-attempt ledger hiện có. Request mới
  chưa được claim khi chỉ mở UI; không tự bắt đầu trận.
- Đo SWAP bằng QPC, ghi decision-exit/preflight/read/validation/return,
  số click thật và join sent/ACK. Không cấp timing authority cho skill.
- Ghi full runtime witness trong mỗi sample. Thẻ và dữ liệu fusion có thể
  thay đổi khi tiến hóa; kiểm cohort SWAP theo cùng account, boss, route
  cấu hình. Không bỏ full witness, không suy resource/damage từ phép chiếu.
  Protocol cũ tiếp tục kiểm witness nguyên vẹn theo luật cũ.

Exporter và loader cùng kiểm phép chiếu Mega. Thiếu hoặc sai witness,
sent/ACK mơ hồ, mất log, incomplete run, source đổi hoặc read span sai
thì không sinh profile dùng được. Các protocol D2/D3/D4 và nghiệm thu cũ
không được nới điều kiện hoặc mở lại cap.

Qualification có lựa chọn `--same-source`: baseline phải chính xác toàn
bộ source hiện tại, không cho sửa/thêm Python giữa baseline và phép đo.
Vẫn chạy disabled parity, input order/boundary, worker/writer, 100 bộ
ROOT/FRESH/FINAL, legacy calibration AST và kiểm mất log. Ba thay đổi
harness lịch sử được đối chiếu AST/hash riêng, không bỏ qua runtime.

## Trình tự tiếp theo

1. Hoàn tất regression và qualification, tạo request BASIC1 đúng phòng
   No.11 lv185, giữ route/settings hiện hành. Mở tool chờ operator Start.
2. User đồng ý bài đo bằng cách Start đúng cửa sổ BASIC1 đã được giải thích.
   Mọi entry failure/abort cũng tính trong cap1; không tự mở lại request.
3. Export run đã kết thúc cùng watermark, kiểm nguồn từng sample và ACK.
   Không dùng 4 trận không có collector để điền các mốc QPC chưa ghi.
4. Chỉ sau khi export đủ và source vẫn nguyên vẹn mới tạo profile runtime.
   Hàm `prepare_reasoning_run` giữ cap BASIC1 trong archive; giới hạn tối đa
   5 lượt Suy luận là một yêu cầu user riêng, không đổi ledger control.
5. Gọi loader thật và kiểm UIReasoningSession/authority trên config thực
   trước khi mở tool Suy luận. Có profile/authority mới báo sẵn sàng R;
   kiểm log sau Start để tránh chỉ dựa vào dropdown.

Đầu mối phiên hiện hành: `logs/latest_mega_restart.json`. Gói cũ có CI
chưa đạt được giữ riêng, abandoned trước Start, 0 attempt/0 claim. Không
install profile rỗng, không chuyển profile source cũ thành nghiệm thu mới.

Các file thay đổi của mốc này chỉ là setup/qualification/export và test;
overlay compatibility mới không cấp native hoặc runtime-profile authority.
Không build/version/commit/push trong bước chuẩn bị.

Đã xác minh trước khi mở: 617 test PASS, 14/14 qualification gate PASS,
100 bộ ROOT/FRESH/FINAL với triple max 1,9191 ms (đo offline, không phải
native input bound), worker/writer reaped, mất log 0. BasicCalibrationActivation
kiểm đúng request/source/build/host và chưa tạo claim. UI PID6028 đã đọc
đúng boss lobby No.11 lv185, IDLE, target1/max1 và Cơ bản; chưa bấm Start.
Profile Suy luận vẫn chờ kết quả native của bài đo này, không báo sẵn sàng R.
