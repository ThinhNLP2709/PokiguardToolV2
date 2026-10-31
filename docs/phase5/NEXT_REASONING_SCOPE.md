# Hướng tiếp theo sau checkpoint1.3.0

Yêu cầu user ngày01/11/2026: “suy luận như1AI chung có thể dùng được ở tất cả
các lối chơi”; Demon Farm phải hỗ trợ các cài đặt viên mục tiêu khác, không
chỉ Khiên. User yêu cầu tạm chốt, push code và build1.3.0 trước khi làm tiếp.

## Ranh giới checkpoint

1.3.0 giữ phạm vi suy luận đã nghiệm thu: Demon Farm ăn Khiên/Lieyun77 và
cohort/build/host đã pin. Không gọi bản này là AI chung hoặc bật các lối chơi/
viên mục tiêu chưa kiểm. BASIC/fallback và toàn bộ flow farm/action cũ giữ nguyên.
Roadmap Phase5 và task UI cũ vẫn CLOSED; bước tiếp theo là yêu cầu mới này.

## Đích cần đạt ở phần tiếp theo

- Một cơ chế quyết định dùng chung, nhận data đã scan cùng nước mặc định từ
  lối chơi, so sánh SWAP/dùng skill/chờ hoặc bỏ lượt khi hợp lệ. Lối chơi định
  hướng mục tiêu; cài đặt chiến thuật là tham khảo có thể điều chỉnh theo state.
  Năng lực pet/action, ownership và an toàn input vẫn là điều kiện bắt buộc.
- Demon Farm hiểu trường Viên mục tiêu: Khiên/Máu/Mana/Hút/Nộ. Phải xét hiệu
  ứng thực tế của pet/cấu hình được chọn và Kiếm hiệu dụng x2/x3; không thay
  tên gem trong công thức Khiên rồi coi là đã hỗ trợ. Thiếu chứng cứ thì ghi
  UNKNOWN/fallback, không giả quy tắc damage/resource hoặc model cho account khác.
- Xem phản hồi boss và setup sau lượt boss trong phần có thể mô phỏng; tránh
  lặp để dành viên mục tiêu rồi boss lấy mãi. Không bắt buộc đổi nước BASIC.
- Cùng snapshot/những lần đọc có sẵn; không đổi thứ tự memory/screenshot,
  action/QTE/ACK/re-entry. Dùng budget trong bước quyết định; lỗi/quá hạn dùng
  BASIC hợp lệ, không cộng thêm random reaction vào nước R đã tính xong.
- Lỗi suy luận có log riêng có giới hạn và nối được về farm run/match/turn;
  không được làm dừng luồng farm chỉ vì worker/model/log suy giảm.

## Cách làm có điểm chốt

1. Rà lại model/capabilities hiện có và reverse cho từng nhóm lối chơi/viên
   mục tiêu; chốt phần dùng chung, phần hiệu ứng đã biết và phần còn UNKNOWN.
2. Hoàn tất offline trong một đợt: candidate/action schema, utility/advisory
   settings, phản hồi boss và bảng replay cho mọi lối chơi hiện có +5targetDemon,
   deadline/fallback/parity/fault/cleanup. Không sinh tiếp chuỗi P vụn vô hạn.
3. Chỉ dừng cần user khi tới live: chốt trước matrix đại diện và cap tổng,
   kiểm đúng bản binary rồi kết luận PASS/hạn chế/không hỗ trợ cho từng ô.
   Không tự train model, thêm trận hoặc mở scope chỉ để tìm được override.

Chưa triển khai phần mở rộng trong checkpoint1.3.0. Đây là yêu cầu và đích
cho lần tiếp tục sau khi checkpoint được bàn giao, không phải kết quả đã đạt.
