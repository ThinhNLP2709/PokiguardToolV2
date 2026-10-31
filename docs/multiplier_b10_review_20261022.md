# b10 multiplier review — 2026-10-22

Đối chiếu reverse1.7.4.9 với b10 và GameAssembly đang cài SHA `9bedce81…`:
`Dot.multiplier` vẫn là int tại+0x88, `BoardCellDTO.multiplier` vẫn tại+0x20.
Mã máy Board.GetDotMultiplier RVA0x1339360 đọc+0x88 tạiRVA0x13394DB rồi trả về.
Reader hiện tại dùng đúng hai offset đó, không có bằng chứng trường x2 đổi.

Phiên người dùng tự chạy sau live2 là farm `7b45d25366b545228846e8e3ca35d294`,
target **Máu**, ngưỡng4. Trận2 `M_86c91873`, turn7 lúc01:34:14+07:
log đã ghi Kiếm x2 tại hàng4/cột1 (tọa độ màn hình bắt đầu1), cùng7 viên x2 khác.
Replay board chính xác tại thời điểm policy cho hai swap Máu không ăn Kiếm
thông thường, mỗi vùng phá chứa3ôKiếm nhưng tổng hiệu dụng4: x2+x1+x1.

BASIC source `9fa67d8…` loại cả hai vì điều kiện `sword_cells >= threshold`.
Giá trị `sword_effective=4` đã được tính đúng, nhưng chỉ xét sau bước lọc và
xếp sau số ô trong tie-break. Tool chọn SETUP ở turn7; turn9 mới chọn một nước
có4ôKiếm, hiệu dụng5. Đây là điều kiện/xếp hạng BASIC, không phải offset mới.
Điều kiện vật lý đã tồn tại trước lần thêm dropdown Viên mục tiêu.

Không có ảnh đúng turn7 để so từng pixel; evidence là board JSON đã dùng để
quyết định. Không kết luận chắc chắn nước thay thế sẽ giết boss, vì đây không
phải mô phỏng damage đầy đủ hoặc kết quả đã quan sát của nước chưa đánh.

[Evidence, disassembly và replay](artifacts/multiplier_b10_review_20261022/evidence.json).
Audit không phát input, không sửa runtime; người dùng sau đó yêu cầu đổi BASIC
sang ngưỡng Kiếm hiệu dụng. Bản sửa được ghi riêng để không đổi nhãn source audit.
[Bản sửa đã hoàn tất offline](demon_effective_sword_fix_20261022.md):159 tests
PASS; chưa live trên source mới.
