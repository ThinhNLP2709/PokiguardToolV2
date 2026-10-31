# Guard hộp thoại thoát và ảnh chẩn đoán — 2026-10-24

Đã hoàn tất sửa và kiểm thử offline. **Live BASIC3 đã PASS ngày2026-10-24:**
3/3WIN,7SWAP/4ACK/3terminal exclusions,0PASS/đọc lỗi/safety fault/recovery,
3confirm/về phòng rồi dừng đúng mục tiêu. Chưa gặp popup sức khỏe hoặc guard
thoát positive; hai nhánh đó vẫn NOT_OBSERVED live, không claim soak dài.
[Live review](artifacts/leave_modal_guard_fix_20261024/live3_20261024_132727/live_review.json).
Đây là nhánh bảo trì, không chạy5E.2, không bump version hoặc build lại ZIP.
Nhãn source vẫn1.2.8; ZIP1.2.8 đã phát hành trước đó chưa chứa bản sửa này.

## Nguyên nhân đã biết và giới hạn điều tra

[Điều tra95/500](health_reminder_incident_20261023.md) xác định tool dừng giữa
trận96 vì `LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK`, rồi game kickAFK.
Guard cũ chỉ cần hai vùng màu cam đối xứng; confidence0.96 là hằng số, không
phải xác suất đúng. Hai vùng cam thuần hoặc hai hình cam rỗng cũng làm guard
cũ trả `found=True`, dù không phải nút/hộp thoại.

Không có frame đúng lần chặn02:44:34.396. Dựng lại riêng board turn3 từ log,
dùng sprite trong fixture game mới, **không tái hiện được** báo modal cũ.
Không được gọi ảnh dựng là screenshot thật, hoặc khẳng định chắc lần96 bị
nhầm chính các viên trên board tĩnh. FX và modal thật lúc đó vẫn chưa phân biệt.
Sửa lần này loại lỗ hổng nhận diện đã tái hiện và bổ sung bằng chứng cho lần tới.

## Thay đổi

- `recovery_ui.locate_confirm_leave` giữ điều kiện vị trí/đối xứng hiện có,
  thêm thân nút đặc (fill>=0.60, aspect2.0..5.5) và nhiều nét chữ sáng bên
  trong **cả hai nút**. Không tính viền sáng là chữ, không chỉ dựa vào màu cam.
  Không OCR, không native input, không thêm capture/read/provider poll.
- Ảnh hộp thoại thật đã lưu từ recovery trước vẫn được nhận. Orange fill đo
  trên hai nút thật0.740/0.719; nhiều component chữ bên trong. Các ngưỡng này
  là kiểm chứng hình ảnh scoped, không chứng minh mọi UI tương lai đều đúng.
- Nếu guard chặn SWAP hoặc CAST, proposal chưa gửi vẫn bị hủy và guard pause
  như trước; ghi thêm `diagnosticImage` vào event hiện có. Lưu chính capture
  đã dùng để kiểm tra: `leave_modal_swap.png`, `leave_modal_cast.png`.
- Chặn ở final card preflight giữ hành vi không gửi, thêm event
  `leave_modal_final_preflight_blocked` và `leave_modal_card_final.png`.
- Tối đa3 tên file cố định mỗi combat, ghi đè cùng tên nếu lặp; không tạo PNG
  thường mỗi lượt. Failure PNG được giữ dù tắt ảnh thường. Lỗi ghi/path không
  bỏ qua guard, không tạo input và ghi `saved=false` cùng lỗi vào diagnostics.
- Không tự resume một SAFE_STOP hoặc phát input sau khi người dùng dừng.

## Popup sức khỏe theo yêu cầu người dùng

Quy tắc là đúng PlayReminder + Button Đã hiểu, không phụ thuộc số phút.
Không thêm kiểm timer180/193/370. Reader/handler hiện có không đọc số phút
để quyết định dismiss nên không cần sửa runtime của PlayReminder.

Đã thêm fixture ảnh370 phút người dùng cung cấp: bộ sức khỏe chấp nhận đúng
button; bộ nhận diện thoát không nhầm ảnh này.32 test handler/native/routing
sẵn có giữ kiểm boss room/map/hub, target/accounting/Stop/one-shot và lỗi lưu ảnh.
Ảnh screenshot chỉ kiểm visual sanity với annotation của fixture; production
vẫn lấy rectangle từ native Button ownership. Chưa phát input live đóng modal.

## Kiểm thử và ranh giới

- **598/598 PASS**,41.278s: các module guard/locator/health, farm/cycle, combat
  lifecycle, Stop/recovery, Bú win, foreground/pinned input, pet skill, BASIC,
  Demon và shared-guard controller flow. Đây là hồi quy liên quan, không full suite.
- Sau đó đưa việc tạo path vào nhánh bắt lỗi của helper; **9/9 PASS**,8.125s
  trên source cuối: actual controller không gửi SWAP khi modal thật, ảnh đúng
  capture, hết đĩa không làm lọt input, board thường vẫn dispatch và không ghi
  failure PNG, giới hạn file, rejected invalid stage, ảnh370 và modal thật.
 598 thuộc source trước chỉnh path nhỏ này; không đổi nhãn raw test log.
- AST354 Python files parse được.103 định nghĩa controller trước sửa khớp
  nguyên AST sau khi chỉ bỏ field/event ảnh chẩn đoán mới; helper ảnh là định
  nghĩa mới. Toàn bộ BASIC/planner/provider/pacing/QTE/ACK/farm/entry bytes
  ngoài hai file runtime được khai báo vẫn giữ đúng source trước sửa.
- Không sửa calibration/pin/authority của Phase5 để chấp nhận source mới.
  Kết quả bảo trì này không thay cho E2/F1 hoặc phép đo timing live.

Source trước **353 file**, SHA256
`58e9db264a73c4a7dd35aef2c846182fdac3d85e41eeac5c175956bd10478526`.
Source cuối **354 file**, SHA256
`72bdbc51917c5ca0561007986b413ae46906a138282331b9ae8d59eab3085589`.
Chỉ sửa runtime `recovery_ui.py`, `tools/basic_auto_bot.py`;3 test files gồm
test mới `test_leave_modal_guard.py`. Fixture/provenance nằm riêng trong tests.

## Runbook live đã dùng

Chuẩn bị phiên source mới tối đa3 BASIC, Solo Lieyun77, Demon Aegis thường,
Khiên/4 Kiếm hiệu dụng và đồ cũ; giữ AI/shadowOFF. Người dùng bấm Start TOOL.
Kiểm entry/swap/ACK/result/confirm/về phòng đủ mục tiêu. Popup sức khỏe nếu
đang có hoặc xuất hiện thì phải đóng và đi tiếp đúng target; không xuất hiện
ghi NOT_OBSERVED, không đợi đủ3h hoặc gọi game ShowForPreview. Nếu guard thoát
còn chặn, dừng và đọc frame mới, không tự retry/skip safety để chạy đủ mục tiêu.

## Bằng chứng

- [Before/after của locator](artifacts/leave_modal_guard_fix_20261024/before_after_locator.json).
- [Hồi quy598](artifacts/leave_modal_guard_fix_20261024/regression_tests.log).
- [Kiểm9 ca sau chỉnh path cuối](artifacts/leave_modal_guard_fix_20261024/final_failure_path_tests.log).
- [Boundary review](artifacts/leave_modal_guard_fix_20261024/boundary_review.json),
  [source manifest](artifacts/leave_modal_guard_fix_20261024/source_manifest.json).
- [Provenance ảnh](../tests/fixtures/recovery_ui/provenance.json).
- Reverse `MatchExitWarning.FindText` RVA0xF6E630 tìm Transform tên PanelExit,
  con text trong root trận; [disassembly](artifacts/leave_modal_guard_fix_20261024/native_PanelExit_FindText.txt).
  Chưa có native observation PanelExit của frame sự cố; bản sửa không thêm
  pointer chain/offset hoặc native lookup suy đoán vào hot path.
