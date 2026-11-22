# Kiến thức chung: boss có skill và có thể tự tăng tài nguyên

Xác nhận của người dùng ngày23/11/2026: boss ở các đảo sau Đảo Liên Minh II,
từ Đảo Cổ Đại trở đi, có thể tự bơm Mana/Nộ và dùng skill. Đây là kiến thức
chung của bộ Suy luận, áp dụng qua `boss_threat.py`, không là đặc tính riêng G4.

## Bằng chứng và điều chưa biết

- Mana/Nộ hiện tại chỉ là số dư tại snapshot. Số dư thấp không loại trừ chuỗi
  tự tăng tài nguyên rồi ra skill; số dư cao cũng không chứng minh đủ điều kiện
  cho một thẻ cụ thể.
- Không chừa Kiếm đã biết vẫn hữu ích, nhưng không chứng minh sống qua lượt
  boss. Skill hoặc phần xử lý tiếp theo có thể tạo thêm nguy cơ ngoài nhánh
  swap/collapse đang mô phỏng. Nguồn chuỗi Kiếm cuối trận Raijin vẫn UNKNOWN.
- Log Raijin `M_1332665a` xác nhận boss tăng18.414.835HP và đòn cuối202.356
  damage. Không dùng một quan sát này để gán ngưỡng hồi, cooldown hay công thức
  skill cho mọi boss. Xem [kiểm tra trận thua](phase5/G4_RAIJIN_LOSS_REVIEW_20261123.md).
- Hút có thể làm giảm Mana hoặc Nộ; lựa chọn tài nguyên và lượng hút chưa đủ
  chứng minh. Không cộng hai chuyển tài nguyên đồng thời, không coi Hút là bảo
  đảm khóa skill, nhất là khi boss có thể tự bơm lại.
- Snapshot hiện tại chưa có định danh đảo/kỹ năng/cooldown của boss. Không
  đoán boss đang ở đảo nào từ HP, cấp hoặc tên. `current_boss_scope=UNKNOWN`.

## Cách dùng trong code

`assess_boss_threat()` nhận các field đã được provider công bố, không đọc thêm
địa chỉ hoặc cấp quyền input. Dictionary và adapter cho GameState dùng chung
một mô hình, phân biệt số dư quan sát được với phần UNKNOWN của skill.

Các profile common (Đơn giản, Cẩn trọng, Khủng long, Chịu đấm ăn xôi, Demon,
Mega Kết Ấn, Galaxy và Bù win) đều lưu `boss_skill_threat` trong tactical context.
Giá trị Khiên tăng khi boss giữ nhiều tài nguyên, ngay cả khi không có phản hồi
Kiếm đã biết. G1/G2/G3 và G4 cũng nhận cùng context; G2 dùng nó để tránh trì
hoãn thẻ bảo vệ đang thực sự đủ điều kiện. Không đổi gate cast hoặc quyền input.

G4 Suy luận dùng tín hiệu tài nguyên để xem xét bảo vệ sớm hơn, đánh giá cả
Máu/Khiên/Hút. Combo nội tại kèm tài nguyên bảo vệ được giữ, tránh đánh đổi một
combo kích hoạt tốt lấy chút Máu chỉ vì điểm proxy nhỉnh hơn. Combo từ11 có cơ
hội hút máu theo mô tả, nhưng lượng hồi thực tế vẫn UNKNOWN. Route tiến hóa
đang chờ vẫn ưu tiên Mana/tiến hóa theo cấu hình.

Các số0,30/0,80 và hệ số0,5/6 trong lựa chọn là ngưỡng/đơn vị so sánh heuristic,
không phải luật skill server. Nộ dùng mốc tham chiếu100 đã có trong adviser
common; lưu riêng tỷ lệ Nộ theo sức chứa. Không suy chi phí skill từ mốc100.
Không gắn xác suất thắng hoặc khoảng sát thương chưa đo vào những proxy này.

Thiếu kiến thức skill không tạo lý do dừng combat mới. Có nước hợp lệ thì G4
tiếp tục chọn nước, kể cả mọi nước rủi ro; các gate dữ liệu/input cũ giữ nguyên.

## Kiểm chứng

Unit tests kiểm cả8 profile common, G1/G2/G3 và9 bàn native của G4 không tiến
hóa. Replay chỉ so quyết định trên cùng snapshot; không đưa bàn tương lai vào
đầu vào và không coi kết quả của nhánh cũ là kết quả nhánh mới. Đánh giá sống/
thắng trước skill cần dữ liệu theo boss hoặc bằng chứng thực tế bổ sung.
