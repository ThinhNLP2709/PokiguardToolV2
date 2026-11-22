# Log gọn cho nhánh thu Máu của Demon — 20/11/2026

Đã bổ sung log chẩn đoán để giữ một candidate thu Máu đã được scorer đánh
giá, kể cả khi candidate đó không nằm trong danh sách tóm tắt đầy đủ.
Thay đổi chỉ ở bước tạo summary; không thêm tính điểm, đổi nước chọn hoặc
gửi thao tác. Không chạy thêm trận trong mốc này.

## Trường mới và giới hạn

`summary.demon_health_prefix` chỉ xuất hiện khi có swap của Demon với P
`PRESENT`, reason `DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY`, khoảng hữu hạn
`0 < low <= high <= 1` và candidate ID khớp snapshot. Dữ liệu lấy từ kết quả
scorer sẵn có, không đọc lại game hoặc chạy lại planner trong logger.

- `scored`: số candidate khớp nhánh; `omitted`: số mẫu nhánh không được giữ
  trong trường gọn này, khác với `omitted_candidate_summaries` của toàn summary.
- `sample`: tối đa một mẫu gồm ID, action, khoảng P, số Máu hiệu dụng, phần
  HP hiện tại và vai trò `BASELINE`/`PROPOSAL`/`ALTERNATIVE`. Ưu tiên mẫu chưa
  có trong danh sách đầy đủ. Vai trò không chứng nhận đã gửi hay thực hiện.
- `kind=COLLECTION_PROXY`: cơ hội thu Máu, không phải lượng hồi thực tế,
  xác suất sống sót hoặc mô hình sát thương.

Trường gọn tối đa512 byte; summary giữ ngân sách12000 byte. Có thể lược
thêm alternative đầy đủ để giữ mẫu gọn, nhưng giữ nguyên toàn bộ thông tin
BASIC và proposal. Nếu chỉ đủ chỗ cho bộ đếm thì `sample=null`, `omitted`
bằng `scored`; nếu vẫn không đủ thì giữ nguyên summary cũ. Thiếu trường là
UNKNOWN, không đồng nghĩa nhánh không được chấm. Trường hợp mandatory đã
vượt ngân sách từ trước giữ nguyên hành vi cũ, không hy sinh attribution.
Lỗi riêng của logger không làm hỏng kết quả: ghi `demon_health_prefix_error`
bằng tên loại exception tối đa64 ký tự nếu còn chỗ; không ghi thông báo lỗi
tùy ý hoặc tạo failure mới cho worker/input.

## Kiểm chứng

Source trước: `61bead5bf7a1fd8651e4d8b2b129e2b2c9c5d0db71559b25b6a27b1c129c596b` (477 Python).
Source sau: `b0b524b17f774914c526624864a511390823790d56af06db556e5ea952e8c83c` (478 Python).
Chỉ đổi file Python hiện có `reasoning_runner.py`, thêm8 test trong
`test_reasoning_health_branch_log.py` và fixture JSON trước thao tác.
476 file Python cũ còn lại giữ nguyên byte. AST xác nhận chỉ thêm helper
và đổi `_decision_summary`; wire/validation/owner/BASIC/PASS/input nguyên.

41 test tập trung PASS, bao gồm ngân sách, count-only, lỗi logger và vòng
serialize/validate reply. Đợt kiểm rộng74 test có6 báo lỗi ở2 method cũ:
pin source `reasoning_operational.py` và5 subcase đối chiếu trace Galaxy
với bản archive. Cùng6 lỗi được tái hiện với runner trước thay đổi; không
bỏ hoặc nới test. Đợt74 chạy trước bản sửa nhỏ ghi loại lỗi;41 test đã chạy
lại trên source cuối. Không tuyên bố toàn bộ suite xanh.

Replay672 trạng thái trên kết quả planner cố định: giữ nguyên672/672
decision/score và bản ghi đầy đủ BASIC/proposal;456 trạng thái lối khác
giữ toàn bộ summary.656 trạng thái không có nhánh giữ nguyên summary.
16 trạng thái có log mới,16 mẫu đầy đủ,0 count-only trong corpus thực.
Summary lớn nhất11990/12000 byte. Benchmark chỉ đo
serialize summary từ kết quả tính sẵn, không đại diện thời gian native;
số đo chi tiết nằm trong `audit.json`.

Mẫu đã lưu r1 lượt3 nay giữ swap(1,6)→(1,7),4 Máu,HP79265/109491,
P=[0.18403947965281775,1], vai trò ALTERNATIVE. Đây là replay bằng logger
mới trên snapshot native cũ; không sửa hoặc gắn trường mới vào log native
lịch sử. Candidate này không phải nước đã được chơi ở trận cũ.

## Trạng thái bàn giao

Mốc offline hoàn tất:0 attach,0 input,0 trận mới,không train/build.
Tổng26 lượt thử đã đóng, còn0; không mở cap hoặc rebind hồ sơ cũ.
Proof/profile native vẫn thuộc source61bead5b. Source logger mới chưa được
kiểm live và chưa có witness nhánh này do worker native ghi trực tiếp.
UI source61 trước đó được ghi nhận đã dừng; không kiểm lại cửa sổ trong mốc
offline này. Chưa có cơ sở nâng chứng nhận chất lượng hay fit damage model.
Khi có mốc live riêng tiếp theo, cần kiểm log được ghi thực tế; không cần
chạy thêm ngẫu nhiên chỉ để tìm lại bàn đã lưu. Mega/Galaxy tiếp tục hoãn.

[Audit replay](artifacts/demon_health_branch_log_20261120/audit.json),
[mẫu cụ thể](artifacts/demon_health_branch_log_20261120/saved_frame_witness.json),
[test và giới hạn](artifacts/demon_health_branch_log_20261120/tests.json),
[xác minh cuối](artifacts/demon_health_branch_log_20261120/final_verification.json).
