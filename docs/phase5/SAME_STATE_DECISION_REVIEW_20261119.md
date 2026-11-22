# So sánh BASIC và Suy luận trên cùng trạng thái — 19/11/2026

Tiêu chí chất lượng do người dùng chốt: **tại đúng bàn đó, BASIC mang lại gì
và Suy luận mang lại gì**. Số lượt của hai ván khác nhau, số override, WIN,
số test hoặc số receipt không thay thế cho đối chiếu này.

Đã kiểm lại toàn bộ 10 snapshot của trận Suy luận mới `M_d1b1a9b4`, source
`17c35c7ee9dd96cfc596f851daeec950b481d2a6202e22bf92ff48c9253ea89d`.
Replay khớp cả 10 action thực gửi; 5 cặp dưới đây là các nước khác BASIC.
Mỗi cặp dùng cùng board/session/turn/seq, HP/Mana/Nộ, pet và settings trước
hành động. Baseline là quyết định BASIC được owner ghi tại chính thời điểm
đó, không lấy từ một ván khác hoặc chạy BASIC trên bàn sau nước Suy luận.

## Năm cặp đã đối chiếu

Số viên trong bảng là **hiệu dụng**, đã tính multiplier; không phải số ô vật
lý hoặc số Mana/Nộ/HP/damage cuối cùng. Dữ liệu JSON giữ cả physical/effective.

| Lượt | Nếu chọn BASIC: thu được phần đã biết | Nếu chọn Suy luận: thu được phần đã biết | Phản công kiếm đã biết của boss, BASIC → Suy luận | Lợi thế và đánh đổi |
|---|---|---|---|---|
| 3 | 6 Máu | 2 Kiếm + 4 Máu + 6 Khiên + 2 Mana + 8 Nộ + 2 Hút | 0 → 0 | Thêm tấn công, Khiên và tài nguyên, đổi mất 2 Máu; ô refill chưa biết tăng 6 → 24 |
| 5 | 3 Máu + 3 Nộ | 3 Kiếm + 3 Nộ | 3 → 0 | Đổi 3 Máu lấy 3 Kiếm và bỏ cơ hội kiếm trực tiếp đã biết cho boss; cả hai có 6 ô refill chưa biết |
| 7 | 3 Máu | 3 Hút | 0 → 0 | Đổi hồi máu lấy cơ hội tác động tài nguyên boss. Lượng/loại Hút và phản ứng sau refill chưa được dự đoán, chưa đủ gọi là tốt hơn tuyệt đối |
| 11 | 4 Nộ | 3 Máu | 0 → 0 | Chọn hồi máu khi đã có 100 Nộ; đây là mốc tham chiếu, **chưa phải trần 250**. Nộ dự trữ vẫn có thể hữu ích, phải ghi là đánh đổi |
| 17 | 7 Nộ | 3 Kiếm + 3 Máu + 5 Khiên + 4 Mana + 8 Nộ + 7 Hút | 0 → 0 | Thu được nhiều viên đã biết hơn ở mọi loại, nhưng ô refill chưa biết tăng 3 → 24; không chứng minh toàn bộ tương lai trội hơn |

Lượt 5 là ví dụ rõ về cả tiến công và không chừa kiếm đã biết. Trước nước,
HP ta 78.307/109.491, Nộ 155/250; lựa chọn không được đánh giá chỉ bằng số
kiếm. Ta từ bỏ cơ hội lấy Máu để lấy Kiếm và đổi cấu trúc phản công của bàn.
**0 Kiếm đã biết không đồng nghĩa boss chắc chắn không có Kiếm sau refill.**

Lượt 17 trội về vector viên thu được trong phần mô phỏng, nhưng điều đó không
xóa rủi ro phát sinh ở 24 ô chưa biết. Không dùng một điểm utility cao hơn
để biến một đánh đổi như vậy thành bằng chứng thắng hoặc sát thương tốt hơn.

## Mức độ kết luận

Có thể đối chiếu trực tiếp: viên/ô đã biết được ăn hoặc quét, cơ hội swap
Kiếm trên phần bàn đã biết, lượng ô chưa biết và các kịch bản hazard có
nguồn. Đó là bằng chứng cơ học có điều kiện, không phải xác suất thắng.

Cần nguồn riêng để so sánh: sát thương ròng, lượng hồi máu/Khiên thực, số dư
Mana/Nộ sau Hút/tiêu/chạm trần, skill sẵn sàng ở lượt sau, khả năng sống qua
đòn boss, refill/cascade và hành động boss chưa quan sát. Không cho nhánh
BASIC dùng refill thật của nhánh Suy luận hoặc dùng số liệu sau nước làm
đầu vào trước nước. Kết quả thực chỉ có cho nước đã chơi; kết quả của phương
án không chơi vẫn UNOBSERVED.

Do đó 5/5 override được gửi hợp lệ chứng minh kỹ thuật; bảng này mới trả lời
chúng khác nhau ở ích lợi/chi phí nào. Trong mẫu này có lợi thế cơ học rõ và
có các đánh đổi chưa thể chốt; **không kết luận cả năm nước Suy luận đều tốt
hơn**, hoặc toàn bộ chế độ hiệu quả hơn chỉ vì thắng.

## Chuẩn báo cáo tiếp theo

Mỗi nước thay BASIC phải giữ cùng snapshot và trình bày: mục tiêu theo lối
chơi/cài đặt, hai action, lợi ích đã biết, tài nguyên đánh đổi, cơ hội cho
boss, rủi ro chưa biết và mức độ kết luận. Tách riêng kiểm chức năng, thay
đổi thuật toán và chất lượng quyết định. Không dùng nhiều override hoặc
utility của chính adviser làm nhãn huấn luyện “nước tốt”. Những trường hợp
chưa phân định phải được giữ như vậy, thay vì chỉnh trọng số để ép kết luận.

Không đổi gameplay, mở thêm trận, train hoặc build trong lần đối chiếu này.
Source giữ nguyên nên nghiệm thu native trước vẫn thuộc đúng source đó.

[5 cặp có đầy đủ đầu vào và delta](artifacts/same_state_comparison_20261119/comparison.json)
· [Script đối chiếu](artifacts/same_state_comparison_20261119/compare.py)
· [Nguồn native và các giới hạn](REFILL_RISK_NATIVE_20261119.md).
