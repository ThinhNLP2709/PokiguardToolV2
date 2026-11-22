# Kiến thức skill boss dùng chung và kiểm G4 không tiến hóa

Ngày23/11/2026. Yêu cầu: bổ sung đánh giá nguy cơ skill boss, dùng chung toàn
bộ Suy luận, kiểm xem G4 không tiến hóa còn cơ hội cải thiện trên dữ liệu đã có.

## Đã làm

- Thêm `boss_threat.py`: cùng một context cho8 profile common và các nhánh
  G1/G2/G3/G4. Ghi rõ boss có thể tự bơm tài nguyên/cast, tài nguyên hiện tại
  không chứng minh khả năng cast, không có Kiếm không chứng minh an toàn.
- Common tăng giá trị dự trữ Khiên khi boss giữ nhiều tài nguyên. Hút vẫn là
  cơ hội giảm một tài nguyên, không là bảo đảm chặn skill/tự bơm lại.
- G2 tránh trì hoãn thẻ bảo vệ đã đủ điều kiện khi áp lực tài nguyên boss cao.
  G1/G3 nhận cùng knowledge context, giữ cơ chế cast/route hiện có.
- G4 xét bảo vệ qua Máu/Khiên/Hút, giữ combo nội tại kèm bảo vệ thay vì đổi
  thành nước Máu nhỏ chỉ vì proxy cao hơn. Từ mốc11 vẫn ưu tiên cơ hội hồi
  theo mô tả; lượng hồi/damage thực tế không được suy thành chứng nhận sống.
- Không thêm gate dừng vì thiếu mô hình skill, không sửa rule bỏ lượt, không
  đổi lộ trình tiến hóa, không thêm reader/offset/input hoặc truy cập server.

Chi tiết nguồn kiến thức và heuristic: [tài liệu chung](../boss_skill_knowledge.md).
Những ngưỡng so sánh không phải điều kiện skill game; chi phí/cooldown/đảo hiện
tại chưa đọc được vẫn UNKNOWN. Không lấy lần hồi18,4M của Raijin thành luật
hồi chung cho mọi boss.

## Kiểm chứng offline

- 429 focused CI tests PASS, gồm44 G4/UI và10 kiểm shared boss threat.
- 88 targeted tests PASS cho shared/G4/G2/G1/G3 (có phần trùng với focused CI).
- 216 ca BASIC lịch sử exact parity;27 ca Galaxy R chỉ khác
  `why_selected` do thêm `boss_skill_threat`, hành động và phần trace cũ giữ
  nguyên. Không tuyên bố các profile Suy luận khác không đổi quyết định.
- Replay9 bàn trước nước đi từ trận G4 R không tiến hóa `M_1332665a`:9/9 vẫn
  cùng nước,9/9 phản hồi Kiếm đã biết0. Lượt9 giữ combo9+khiên4; lượt11 nhận
  ra bảo vệ bằng Máu5+Hút3; lượt17 nhận ra combo12 có cơ hội hồi. Đây là đổi
  cách giải thích/đánh giá, chưa là lợi thế thực chiến mới trong trận này.
- Tại lượt19, nhóm chừa0 Kiếm vẫn chỉ có combo10 hoặc8 và không có Máu/Khiên/
  Hút. Bản sửa tiếp tục combo10, không tự dừng và không nhận là sống được.

Không dùng response tương lai làm đầu vào chọn nước. Không mang kết quả
server của nhánh cũ sang nhánh giả định; không có replay win/loss giả.

## Kết luận về G4 không tiến hóa

Chưa chứng minh không thể thắng, cũng chưa có bằng chứng đủ để nói thắng
Raijin518 với cấu hình này. Trận đã thu cho thấy boss hồi18.414.835HP, đòn
cuối202.356 vượt180.029HP còn lại. Bổ sung kiến thức chung không tự tạo ra
nước phòng thủ trên bàn vốn không có nó.

Không tự mở thêm live cùng boss/cấu hình chỉ để tìm kết quả khác. Bài tiếp
theo cần mục tiêu mới: xác minh skill/cooldown boss từ bằng chứng đủ rõ, hoặc
đổi boss/route với giả thuyết cụ thể. Hai route tiến hóa vẫn chưa nghiệm thu
native. Các cap cũ giữ đóng: G4 đã2 trận, Demon42; không có run đang hoạt động.

Source mới chỉ kiểm offline, không kế thừa nghiệm thu native của source
3a7bb861… ở trận cũ. Chưa build/version/commit/push trong đợt này.

[Kết quả, hash và replay](artifacts/boss_skill_threat_20261123/verification.json).
