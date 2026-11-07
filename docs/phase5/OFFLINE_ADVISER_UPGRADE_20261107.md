# Nâng cấp adviser từ replay đã lưu

Checkpoint `37a6718a` lưu source v1.3.2, tương thích B15 và kết quả live trước đợt nâng cấp. Replay đối chiếu cùng một bàn, trạng thái và nước gốc giữa planner của checkpoint và planner mới. Dữ liệu gồm 81 lượt swap trích từ log và 24 lượt dùng lại bàn Đơn giản để kiểm mục tiêu Khủng long. Log Khủng long thực chưa có trong corpus này. Replay dùng các hiệu ứng và điều kiện đã biết, giữ skill/PASS ngoài phép so sánh swap khi log thiếu đủ bằng chứng về quyền hoặc hiệu ứng.

## Những quyết định đã sửa

- **Đơn giản, Cẩn trọng và Khủng long.** Khi có nhiều phản hồi boss ngang số Kiếm, planner cũ có thể lấy Kiếm/Hút từ một nước rồi cộng Mana/Nộ và hồi máu tối đa từ các nước khác. Planner mới tính rủi ro cho từng nước và lấy trường hợp xấu nhất trong tập phản hồi đang xét. Nếu chưa thấy nước phản hồi trên bàn có ô refill chưa biết, điểm rủi ro mang trạng thái thiếu bằng chứng.
- **Chịu đấm ăn xôi và Mega Icarus.** Điểm sẵn sàng dùng skill xét chung Mana và Nộ theo giá đã xác nhận của thẻ thuộc trận hiện tại. Khi một tài nguyên còn thiếu, phần tích thêm cho chu kỳ kế tiếp nhận trọng số thấp hơn. Chịu đấm ăn xôi giữ ưu tiên nạp lại nếu skill kế tiếp chưa đủ tài nguyên. Planner lấy lại số dư thực ở lượt sau để đánh giá kết quả skill, vì thứ tự trừ và nhận tài nguyên trong cùng hiệu ứng còn thiếu bằng chứng. Mega vẫn ưu tiên Mana theo chi phí tiến hóa khi đang ở giai đoạn này.
- **Demon Farm.** Nước chuẩn bị sau phản hồi boss được chấm theo cùng quy tắc Nộ danh nghĩa như nước đánh ngay, với sàn hai ô Kiếm thật. Ở bước nhìn trước, chỉ tính Nộ đã biết trong vùng quét của chính nước kế tiếp, vì chưa biết số dư Nộ khi đến lượt đó. Áp dụng chung cho năm viên mục tiêu và tính x2/x3 theo ledger hiện có.
- **Bú win.** Mục tiêu để Kiếm cho boss được giữ. Mẫu hiện có chưa đủ để dự đoán đồng đội hoặc đổi quyền chơi Coop.

## Kết quả offline

| Lối chơi | Ca replay | Đổi lựa chọn so với planner trước |
|---|---:|---:|
| Đơn giản | 24 | 1 |
| Cẩn trọng | 16 | 1 |
| Khủng long, dùng bàn Đơn giản | 24 | 1 |
| Chịu đấm ăn xôi | 16 | 5 |
| Demon Farm | 10 | 1 |
| Mega Icarus | 8 | 1 |
| Bú win | 7 | 0 |

Cả 105 nước chọn lại đều hợp lệ. Cả hai phiên bản hoàn tất nhìn trước ở 100 ca và dùng kết quả một bước ở 5 ca còn lại. Bốn ca chạm giới hạn 18.000 node và một ca thiếu mô hình để so sánh phản hồi. Một lượt Chịu đấm ăn xôi trong log có 178 Mana và 55 Nộ, với chi phí 200/200. Nước planner mới chọn nâng tỷ lệ của tài nguyên còn thiếu nhất từ 27,5% lên 57,5% theo ledger đã biết. Đây là đánh giá cơ học trên cùng bàn cờ. Kết quả trận nếu đi nước khác không có trong log.

Các phép đo planner mới ở 105 ca có median khoảng 176 ms, max khoảng 813 ms trên máy này. Chúng đo một lần chạy planner offline. Độ trễ live gồm thêm worker, bước kiểm host và input. Chi tiết nằm trong [đối chiếu](artifacts/offline_adviser_upgrade_20261107/comparison_final.json), [bản ghi trước](artifacts/offline_adviser_upgrade_20261107/before.json) và [bản ghi sau](artifacts/offline_adviser_upgrade_20261107/final.json).

208 test liên quan đã qua khi dùng thư mục tạm trong workspace. Cả năm ca hồi quy mới đều tái hiện trên checkpoint. [Log kiểm thử](artifacts/offline_adviser_upgrade_20261107/tests_workspace_temp.log).

Chỉ ba module của adviser thay đổi. BASIC, quyền PASS do game cung cấp, QTE, trình tự đọc, capture, input và farm vẫn dùng đường cũ. Công thức sát thương, refill, skill boss, hành vi đồng đội và hiệu quả thắng/tiết kiệm năng lượng còn cần bằng chứng khác. Hồ sơ live B15 trước đó gắn với source của checkpoint. Source mới đang ở bước offline.
