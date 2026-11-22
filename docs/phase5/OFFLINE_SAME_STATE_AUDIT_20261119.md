# Rà soát chất lượng Suy luận trên cùng bàn — 19/11/2026

Đã sửa lỗi loại dữ liệu quá rộng và hoàn thành đối chiếu **643 snapshot/cấu
hình trên 619 bàn khác nhau**. Chưa tìm được lỗi định giá adviser đủ bằng
chứng để sửa gameplay. Đợt này thay đổi chẩn đoán và công cụ nghiên cứu;
adviser, BASIC, input, eligibility và luật bỏ lượt giữ nguyên byte so với
source đầu đợt `17c35c7e…`.

Source chốt: `6a5f2c6bf73ca208c38af39ba61c2afed2707644f7466a5719811c7495c6381b`.
**125 kiểm tra liên quan PASS**, replay không mở game, không chạy thêm trận,
không train, chỉnh prefs, build hoặc rebind profile. Native trước đó thuộc
source `17c35c7e…`; không chuyển nhãn nghiệm thu đó sang source mới.

## Sửa khoảng trống log

Trong trận BASIC `M_c2050523`, dòng 285/sequence 36 có optional outcome
`INVALID/OPERATION_SHAPE_OR_LIMIT`. Exporter cũ dùng bất kỳ outcome lỗi nào
trong file để loại mọi khoảng lượt boss, kể cả tám khoảng đã kết thúc trước
sequence 36. Đây là lỗi phân tích dữ liệu, không phải nguyên nhân tool bỏ
lượt hoặc dừng trong trận đó.

Exporter mới chỉ bỏ qua lỗi đối với một khoảng khi có bằng chứng vị trí
độc lập: accepted board đủ 64 ô, hash hợp lệ, match/epoch/sequence khớp và
hash đính kèm outcome khớp board. Lỗi nằm trong dòng hoặc sequence của
khoảng vẫn loại khoảng, kể cả ghi log trễ. Lỗi không rõ phạm vi, JSON hỏng
hoặc identity xung đột vẫn chặn. Consumer resource audit giữ lại capture
gap thay vì gọi phần đã khôi phục là dữ liệu đầy đủ.

Kết quả: **0 → 8 khoảng boss hợp lệ được giữ lại**; bản ghi cuối trận vẫn
INVALID, không tái tạo operations đã mất, không sửa log gốc/export cũ. Cả
hai phía Mana khớp flow đã ghi trong 8 khoảng; Nộ còn phần chênh chưa giải
thích. Không dùng phần chênh đó làm công thức Nộ mới.

Collector tương lai tách `OPERATION_SHAPE` và `OPERATION_LIMIT`, chỉ ghi
container/count/limit có kích thước nhỏ. Giới hạn 128 operations/128 steps/
32.768 byte không tăng. Lỗi optional không loại board hợp lệ, thêm quyền
input hoặc tạo lượt đọc process. Nguyên nhân chính xác của batch cũ vẫn
**UNKNOWN** vì lúc đó chưa lưu thông tin phân biệt shape với limit.

[Bằng chứng và script tái hiện](artifacts/outcome_scope_fix_20261119/review.json).

## Đối chiếu BASIC với Suy luận

Mỗi cặp dùng nguyên board, multiplier, HP/Mana/Nộ hai phía, pet, lối chơi và
settings trước hành động. BASIC là đề xuất owner đã ghi tại snapshot đó;
Suy luận là replay adviser hiện tại trên cùng snapshot, không tái dựng
owner/UI lịch sử để gọi đó là phiên BASIC mới. Đã giữ cả số ô vật lý và
viên hiệu dụng, chi phí skill, phạm vi mô phỏng, cascade chưa giải quyết,
ô refill chưa biết và hazard một ô của solver hiện có.

So sánh cơ hội của boss bao gồm cả Kiếm/Mana/Nộ/Máu/Khiên/Hút. Các cực đại
là của **những nước phản công riêng**, không cộng chúng thành một nước mà
boss có thể ăn tất cả. Chúng chỉ áp dụng trên phần bàn đã biết; không dự
đoán refill, passive/skill boss hoặc lựa chọn thật của boss.

| Nhóm đối chiếu | Số cặp | Ý nghĩa |
|---|---:|---|
| Cùng hành động | 181 | Không có lựa chọn thay thế để xếp hơn/kém |
| Có đánh đổi | 402 | Có phần được và mất trong các đại lượng đã xét |
| Chưa đủ mô hình so sánh | 56 | Khác horizon, hiệu ứng chưa biết hoặc cascade chưa giải quyết |
| Lợi thế cơ học có điều kiện | 4 | Không mất các đại lượng đã xét và giảm ít nhất một cơ hội tài nguyên đã biết của boss |

Đây không phải tỷ lệ quyết định tốt/xấu hoặc tỷ lệ thắng. Cả 643 cặp đều
không có optimal-action/training label. Bộ 584 snapshot lưu trữ và 59
snapshot native B16/B17 đã từng được nghiên cứu, **không phải holdout độc
lập**. 24 cấu hình dùng lại bàn, nên không gọi là 643 bàn hoặc 643 ván mới.

Ví dụ cụ thể trong trận Mega T-Rex `M_896e1cb4`, lượt 113: cả hai lựa chọn
đều lấy 6 Nộ hiệu dụng, cùng 3 ô refill chưa biết. Phần bàn đã biết sau BASIC
còn nước boss lấy 8 Hút hiệu dụng; sau Suy luận không còn nước Hút đã biết.
Đây là lợi thế bảo vệ tài nguyên có điều kiện, chưa cho biết boss thực tế
hút bao nhiêu hoặc nước nào thắng. Việc Mana đã đầy và Nộ 110/250 cũng được
giữ trong facts; số viên không được tự đổi thành lợi ích ròng.

## Ba trường hợp nhiều lượt đã xem kỹ

Bảng sơ bộ chỉ so kiếm phản công đánh dấu ba cặp lấy ít viên hơn. Khi xét
đầy đủ tài nguyên boss và thế ấn, cả ba là đánh đổi, chưa chứng minh bug:

| Trận/lượt | BASIC → Suy luận | Điều cần xét ngoài số viên lấy ngay |
|---|---|---|
| `M_cc9899da` / 139 | 6 → 4 Máu; bản thân đang đầy HP | Cơ hội Hút boss 10 → 0, Nộ 5 → 0; đổi lại cơ hội Khiên boss 0 → 11 |
| `M_cc9899da` / 141 | 4 → 3 Máu; bản thân đang đầy HP | Cơ hội hồi Máu boss 5 → 4, nhưng Mana boss 3 → 4 |
| `M_896e1cb4` / 37 | 5 → 4 Hút | Cơ hội Mana boss 4 → 3; với 18 phản công đã biết, số Kiếm hiệu dụng nhỏ nhất còn trong ấn T-Rex tăng 0 → 1, ngưỡng cài là 2 |

Thế ấn cuối vẫn chưa đạt ngưỡng trong kịch bản xấu nhất và không chứng minh
skill được phép bấm lượt sau. Lợi thế cấu trúc có thể giải thích lựa chọn,
không thay thế mô hình sát thương/sống sót hoặc luật server. Không tăng
trọng số chỉ để ép các cặp này thành nhãn “Suy luận thắng”.

[Corpus và số liệu](artifacts/same_state_corpus_20261119/summary.json),
[kiểm chứng và ba ca review](artifacts/same_state_corpus_20261119/verification.json).
Tool dùng lại cho một CommonProblem: `tools/compare_same_state_decisions.py`.

## Việc còn mở

Ưu tiên tiếp theo là đối chiếu **tác động tài nguyên ròng và điều kiện dùng
skill** từ ordered trace đã có: Hút/tiêu Nộ/chạm trần có thể làm gross gain
khác số dư thật. Chỉ nâng thành mô hình có phạm vi khi đủ identity, thứ tự,
nguồn và kiểm định riêng. Những cặp thiếu hiệu ứng/damage/refill tiếp tục
giữ UNKNOWN; không cần mở thêm trận cho milestone offline vừa hoàn tất.
