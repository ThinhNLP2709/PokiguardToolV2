# G4 Suy luận không tiến hóa — vì sao thua Raijin518

Trận `M_1332665a`, run `3c7f113254d34f63b3905a6c55312f07`, khoảng00:28–00:30
ngày23/11/2026 (GMT+7). User chọn **không tiến hóa** và tự bấm Start. Source
`3a7bb861b607ab97fd47c8e17edc01e8ec72f11d2ffed535fc6a00f2cceeaa07` giữ nguyên.

Log xác nhận9 SWAP/9 ACK,0 PASS,0 safe stop/recovery, không lỗi đọc hoặc timeout
ACK. Game báo LOSS; farm xử lý kết quả và về lobby, dừng khi đủ1/1. Đây không
là lần tool ngừng đánh giữa trận. Cấu hình checkpoint ghi intelligence BASIC
là trường lịch sử; cả9 decision có `g4_combo.mode=REASONING`, goal=PASSIVE_COMBO.

## Hai diễn biến quyết định

| Bằng chứng | Giá trị |
|---|---|
| HP tối đa của mình | 242.692 |
| HP tối đa boss | 40.655.221 |
| Sau nước mình, response36 | Boss còn14.109.341 HP |
| Response38 của boss | `BOSS_HP delta=+18.414.835`, lên32.524.176 HP, gần80% tối đa |
| Trước đòn cuối, published response40 | Mình còn180.029 HP, không có Khiên |
| Response45 của boss | `DAMAGE amount=202.356, full_power=true, after.HP=0` |
| Kết quả game/UI | LOSS, winner=`__BOSS__` |

Boss hồi nhiều hơn lượng HP ròng ta vừa kéo xuống từ28.458.654 lúc bắt đầu
đến14.109.341. Sau đó chuỗi cuối có số Kiếm ghi trong `destroyed_by_tag` là12,
kèm Nộ/Mana và các tài nguyên khác, gây đòn kết liễu vượt HP còn lại22.327.
Đây là bằng chứng boss áp đảo cấu hình không tiến hóa trong trận này; không
là chứng minh không thể thắng bằng mọi cách chơi.

Không gọi riêng đợt hồi18,4M là công thức skill đã biết: log chỉ xác nhận thay
đổi HP. Ngưỡng kích hoạt, cooldown, tính lặp lại và tên kỹ năng vẫn UNKNOWN.

## Có phải chừa Kiếm hoặc bỏ lượt?

Replay9 bàn trước nước đi khớp9/9 lựa chọn, cả9 đều có phản hồi Kiếm đã biết=0
và đó cũng là mức nhỏ nhất trên bàn. Lỗi6/11 nước có thể tránh Kiếm ở bản cũ
không lặp lại ở mẫu này.

Quan sát thêm bàn thực tế sau xử lý server, không dùng nó làm đầu vào chọn
nước: response12/21 tạo cơ hội Kiếm4/5 sau khi state cập nhật. Riêng trước
đòn cuối, bàn published response40 đã có đầy đủ viên nhưng solver vẫn không
có nước Kiếm; chuỗi12 Kiếm xuất hiện trong phần xử lý tiếp theo của boss.
Không quy nó thành một nước Kiếm đã sẵn trên bàn mà tool cố tình nhường.
Gói cuối không có đủ operation để chứng minh chính xác skill, refill hay
thay đổi bàn nào tạo ra toàn bộ chuỗi đó.

Log ghi boss ở lượt12 rồi14, không ghi LOCAL ở13. Không có bằng chứng PASS/
idle của tool trong khoảng đó; nguyên nhân trạng thái khiến lượt13 không
được xuất bản cho LOCAL chưa đủ dữ liệu để gọi là Choáng/Đóng Băng cụ thể.

## Giới hạn chiến thuật và bước tiếp

Nội tại/hiệu ứng hồi HP đã giúp kéo dài trận: trước lượt17 có111.454 HP, sau
đợt xử lý tiếp theo hồi lên180.029. Tuy vậy G4 hiện xét combo/HP/Nộ và phản
hồi Kiếm, chưa có mô hình cho lần boss hồi lên80% hoặc thay đổi bàn bằng skill.
Tại lượt cuối, nhóm nước chừa0 Kiếm chỉ có combo10 và combo8, không có nước
Máu/Khiên/Hút trong nhóm đó; tool đã chọn combo10. Chưa có counterfactual đủ
chứng minh một nước khác sẽ sống hoặc thắng.

Cần đánh giá cơ chế boss và khả năng chịu đòn của route có tiến hóa, thay vì
coi né Kiếm là đủ bảo vệ. Nếu kiểm tiếp, nên kiểm riêng route G4→pet thường
hoặc dùng boss ít áp lực hơn. Chưa tự mở thêm trận, chưa sửa gameplay hoặc build.

Phạm vi nghiệm thu native hiện tại chỉ là **G4 Suy luận/không tiến hóa,1 trận**;
chưa nghiệm thu hai route tiến hóa hoặc chất lượng tối ưu toàn cục. Cap này
đã dùng1/còn0; tổng G4 đã hoàn thành2 trận (1 BASIC trước đây+1 R),42 Demon
đã đóng giữ nguyên.

[Dữ liệu phân tích](artifacts/g4_reasoning_no_evolution_20261123/loss_analysis.json),
[biên bản và hash log](artifacts/g4_reasoning_no_evolution_20261123/closure.json).
