# Rà trận 14 nước và bổ sung rủi ro kiếm sau lấp bàn — 19/11/2026

Đã bổ sung vào common adviser phần rủi ro kiếm phát sinh quanh ô chưa biết
sau khi ăn viên. Tái sử dụng đánh giá đã có trong solver; không viết lại
solver hoặc gán xác suất rơi viên. Bản sửa đạt 112 kiểm tra và replay offline
633 trạng thái, nhưng chưa kiểm trực tiếp source mới.

## Đối chiếu 11 nước khác BASIC

Dữ liệu là trận `M_acace752`, source trước sửa `e48e94d3…`. Đã nối đủ source,
session, turn, seq, board và critical state hash. Replay tái hiện đúng cả
14 quyết định/điểm số đã ghi. Cả 11 override vượt upper utility của baseline
ít nhất 0,05 trong mô hình lúc đó. Đây không phải chứng minh nước tối ưu:
kết quả thực của phương án BASIC không được quan sát.

| Lượt game | Nước Suy luận đã chọn và lý do định giá | Quan sát sau nước đã gửi |
|---|---|---|
| 3 | Quét Khiên lấy 3 Kiếm cùng Nộ/Máu/Khiên, thay 3 Hút | DAMAGE boss 114.597, hồi 3.638 HP, Hút Mana 90 |
| 7 | Lấy Nộ + Máu + Hút, thay Hút + Mana; Nộ trước nước là 40 | +60 Nộ và Hút thêm 5 Nộ, hồi 2.729 HP |
| 9 | Hồi Máu, cùng mức phản công đã biết với phương án Hút | Hồi 2.729 HP |
| 11 | Hút + Nộ, giảm tài nguyên boss có thể thu so với Mana + Nộ | Hút 50 Mana; boss vẫn có nước 6 Kiếm trên bàn đã lấp |
| 13 | Hút, thay Mana + Nộ khi Nộ đã vượt mốc tham chiếu | Hút 15 Nộ |
| 15 | Hồi Máu + Hút, giá trị bảo vệ cao hơn ở mô hình cũ | Hồi 3.638 HP, Hút 90 Nộ nhưng chỉ giữ thêm 5 do trần; có rủi ro một ô lấp tạo 6 Kiếm |
| 17 | Hồi Máu, thay Hút + Mana khi HP còn khoảng 47% | Hồi 2.729 HP; có rủi ro một ô lấp tạo 6 Kiếm |
| 19 | Quét Khiên lấy 2 Kiếm, Nộ và phòng thủ; không đợi đủ 4 Kiếm | DAMAGE boss 76.398, cộng Khiên và Máu; vẫn có phản công sau lấp bàn |
| 21 | Lấy Mana + Nộ và giảm giá trị phản hồi tài nguyên của boss | +150 Mana, +80 Nộ |
| 23 | Lấy 4 Kiếm thay 7 Máu, bỏ cơ hội 4 Kiếm đã biết cho boss | DAMAGE boss 38.199; phản hồi boss quan sát được không lấy Kiếm |
| 27 | Quét Khiên lấy 3 Kiếm cùng tài nguyên khi boss còn khoảng 45.015 HP | Chuyển terminal WIN; không gán damage riêng khi thiếu response nối ACK |

Các số DAMAGE/HEAL/STEAL là hiệu ứng được log, không phải công thức suy ra.
Những phản hồi không có đủ nguồn vẫn để UNKNOWN. Không dùng WIN gán nhãn
đúng cho toàn bộ 11 nước hoặc dùng after-state để chạy lại adviser.

## Mana/Nộ: điều đã kiểm được

Có 13 nước với published endpoint sau SWAP ACK. Gross known gain trùng số dư
cuối ở 9/13 ca Mana và 5/13 ca Nộ. Đọc STAT_CHANGE đúng thứ tự, gồm Hút,
FULL_POWER và chạm trần, khớp đủ **26/26 endpoint**. Có bốn update bị chặn ở
trần trong ba khoảng; cộng raw delta một lần không tái hiện được chúng.

Ví dụ lượt 3: Nộ 60, nhận 100 rồi FULL_POWER −100, kết thúc vẫn 60. Lượt 19:
Nộ 250, nhận 120 rồi Hút thêm 25 nhưng vẫn 250, sau đó FULL_POWER −100 còn
150. Vì vậy cách giữ khoảng giá trị tài nguyên đã làm trước đó là cần thiết.
Đợt này không thêm công thức Nộ/kiếm, công thức damage hoặc net resource mới.

## Khoảng trống đã sửa

Trong 10 khoảng boss nối được, có năm khoảng mà bàn trước nước ta chỉ cho
thấy 0 Kiếm phản công đã biết, nhưng bàn thực sau khi lấp cho phép boss lấy
Kiếm. Một ca còn có survivor thay đổi do cascade ngoài mô hình; không quy
mọi sai khác thành cùng một nguyên nhân.

Hai ca cụ thể ở lượt 15/17 có cấu trúc một ô chưa biết đủ làm lộ nước
6 Kiếm hiệu dụng. Solver đã có `_hypothetical_unknown_hazard` để phân biệt
match tự động với cơ hội swap trên bàn ổn định; common adviser chưa dùng nó.
Đã nối khả năng này vào đánh giá T:

- Giữ endpoint rủi ro của bàn đã biết; chỉ mở rộng phía rủi ro có điều kiện.
- Dùng mức lớn nhất của từng kịch bản, không cộng hiệu ứng từ các nước khác nhau.
- Không cộng F/R/D/P/H hoặc lợi ích từ refill giả định, không dự đoán damage.
- Không dùng auto-match làm bằng chứng boss sẽ được swap đó.
- Giữ giới hạn thời gian/node/cancellation, fallback BASIC và toàn bộ quyền
  input, PASS, skill eligibility, reader. Solver và BASIC giữ nguyên byte.

Đây vẫn là proxy cho một ô chưa biết. Nhiều ô lấp, cascade tiếp theo, skill
boss và phân phối refill chưa được mô hình hóa đầy đủ. Không gán xác suất
hoặc coi việc không tìm thấy hazard là chứng nhận an toàn.

## Kiểm trước/sau và bản chốt

Paired replay gồm 584 corpus cũ + 21 B16 + 8 B17 + 6 B17 main + 14 trạng thái
mới, tổng 633 snapshot riêng. Before của 619 snapshot cũ khớp chính xác after
đã lưu ở mốc trước. Có **95 đổi lựa chọn, tất cả SWAP → SWAP hợp lệ**:
Demon 25, Mega 53, Cẩn trọng 3, Cơ bản 4, Khủng long 4, tích tài nguyên 1,
Galaxy common 5, Bù win 0. Node cap vẫn 2 → 2; không tăng giới hạn tìm kiếm.

Trên 14 trạng thái của trận vừa rồi, bản sửa chỉ đổi lượt **15 và 17**, tránh
hai cấu trúc hazard trên. Nước lấy 2 Kiếm ở lượt 19 và ăn 4 Kiếm bảo vệ ở
lượt 23 được giữ. Chưa có kết quả game của hai nước thay thế; không kết luận
thắng nhanh hơn, tăng win rate hoặc tối ưu toàn cục. Corpus đã được nghiên
cứu, không phải holdout độc lập. Galaxy common trong replay không chứng minh
UI Galaxy G1/G2/G3 đã dùng cùng worker.

Paired đầy đủ đầu tiên dùng source `31fb5082…`. Kiểm ngân sách log sau đó
phát hiện case cần 12.270 byte. Bản chốt sửa projection metadata và bỏ ứng
viên phụ khi không còn chỗ, luôn giữ baseline/proposal bắt buộc. Kiểm lại
**toàn bộ 633 trạng thái trên source chốt**: quyết định/điểm số giữ nguyên,
0 lỗi attribution hoặc budget; summary lớn nhất **11.990/12.000 byte**.

**112 test PASS trên source chốt**, gồm 11 test mới. Kiểm witness, auto-match,
positive credit, immutable input, deadline/cancel, các lối chơi, summary lớn
có/không có proposal và AST bảo vệ worker/admission. Log lỗi phát hiện trong
đợt kiểm được giữ riêng; không nới giới hạn để cho qua.

## Danh tính và trạng thái

- Trước sửa: `e48e94d3302b95fd2b9d0c37ed7815bc50d23f0ffc9439bec1dbb4defffb5561`.
- Bản chốt: `17c35c7ee9dd96cfc596f851daeec950b481d2a6202e22bf92ff48c9253ea89d`.
- Production đổi `reasoning_common_planner.py` và phần summary trong
  `reasoning_runner.py`. Các đường worker/admission ngoài projection summary
  được kiểm AST, không đổi. Có một test guard được cập nhật đúng delta và
  một file test mới; fixture chỉ chứa đầu vào trước hành động.
- Không mở thêm trận, attach game, thay preferences, rebind profile, train,
  build, commit hoặc push trong đợt này. Native 14 nước thắng thuộc source
  trước sửa, không được gắn lại cho bản chốt.

[Kiểm nguồn và phạm vi](artifacts/adviser_refill_risk_20261119/verification.json)
· [Rà đủ 14 quyết định và resource](artifacts/adviser_refill_risk_20261119/decision_review.json)
· [Paired trước/sau](artifacts/adviser_refill_risk_20261119/paired_summary.json)
· [633 replay bản chốt và budget](artifacts/adviser_refill_risk_20261119/final_replay.json)
· [14 trạng thái trước/sau](artifacts/adviser_refill_risk_20261119/native_after_review.json).

Scratch/prototype để trong `temp/reasoning/adviser_native_review_20261119/`.
Bản source trước sửa, script, SHA và bằng chứng cần giữ đã archive cùng báo
cáo; muốn tái chạy nên sao chép artifact sang một thư mục mới dưới temp.
