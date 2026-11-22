# Demon — đóng phiên BASIC và Suy luận có reader trace

Đã đóng cap **2/2: 1 BASIC + 1 Suy luận**, tổng ledger19; không còn lượt
trong phiên này. Hai trận đều WIN, nhận thưởng và về phòng. Không safe stop,
technical recovery, PASS hoặc lỗi input. Giữ source
`1909d77a6a66964d1e9867c5f26be81a30852f48c3aa4e4880db4cd222740303`
suốt hai pha; không sửa gameplay, train, build hoặc rebind profile.

Native log ngày19/11 UTC, báo cáo được chốt ngày20/11 giờ Việt Nam.

## Vận hành và quyết định

Solo Priest lv131/ID1845, Demon Aegis thường ID560, Khiên/ngưỡng4,
không tiến hóa. Pha R chạy ở phòng được vào lại, không phải phòng BASIC.
Các thông số quan sát ở nước đầu khớp: ta HP tối đa109491/Mana2771/Nộ250/
Attack1819; boss581505/540/250/766. Full gear UNKNOWN, không tuyên bố đã
đối chiếu toàn bộ trang bị hoặc tính năng account.

| Pha | Match / run | Kết quả vận hành |
|---|---|---|
| BASIC | `M_9f8b3109` / `a2514b451dcf465196aad82464f68163` | 13 lượt ta, 12 SWAP ACK và1 nước terminal; 12 mẫu timing mới hợp lệ |
| Suy luận | `M_763be023` / `789120f8c9d548878db0f21a83b70d26` | 5 lượt ta, 4 SWAP ACK và1 nước terminal; đủ5 decision/15 checkpoint |

R replay khớp cả5 hành động tại đúng snapshot gốc;4 nước cùng BASIC và1
nước khác. Worker1/1 reaped,31 diagnostic record được ghi đủ; không drop,
fault hoặc accounting mismatch. Summary lớn nhất11798/12000 byte.
Nước cuối có `ACTION_ABORTED_STATE_CHANGED` sau gửi input và boss HP0,
terminal/result UI WIN nhất quán; không phải safe stop hoặc bỏ lượt vì
không chọn được nước. Không tính nó thành ACK thông thường. Combat cũng
có event `postmatch_observation_timeout`; farm owner sau đó nhận thưởng,
xác minh postmatch bình thường và hoàn tất1/1, không dừng lỗi tại kết quả.

Số lượt13 và5 thuộc hai bàn ngẫu nhiên khác nhau. WIN, số lượt, override
count và điểm utility nội bộ không chứng minh Suy luận chơi tốt hơn.

## Đối chiếu nước khác BASIC tại cùng trạng thái

Lượt3, ta HP79265/109491, Mana150, Nộ25; boss HP469110/581505,
Mana90, Nộ5, Khiên2604. Cả hai lựa chọn dùng đúng bàn/facts/cài đặt trước
hành động, không đưa refill hoặc outcome thực vào nhánh giả định.

| Yếu tố tính được từ phần bàn đã biết | BASIC | Suy luận |
|---|---:|---:|
| Viên thu ngay | 3 Hút | 3 Nộ |
| Kiếm thu đã biết | 0 | 0 |
| Kiếm boss có thể ăn tối đa đã biết | 0 | 0 |
| Khiên boss có thể ăn tối đa đã biết | 3 | 0 |
| Hút boss có thể ăn tối đa đã biết | 3 | 4 |

Suy luận tiến triển Nộ và bỏ khả năng phản công bằng3 Khiên trên phần bàn
đã biết, đổi lại không lấy3 Hút ngay và tăng khả năng boss ăn Hút lên4.
Các cực đại tài nguyên boss là những nước riêng, không được cộng thành
một nước boss ăn tất cả. Đây là **TRADEOFF**, không có nhãn tốt hơn.

Nước Suy luận đã ACK, nhưng typed effect của chính nước này thiếu; outcome
của nước BASIC thay thế chưa bao giờ được quan sát. Refill, số dư tài
nguyên ròng, damage và kill của nhánh giả định vẫn UNKNOWN. Cả hai để0
Kiếm đã biết không chứng nhận an toàn sau refill.

## Độ phủ hiệu ứng và reader

| Dữ liệu | BASIC | Suy luận |
|---|---:|---:|
| Typed response giữ lại / chuẩn hóa | 22/22 | 7/7 |
| ACK có typed effect tương ứng | 10/12 | 2/4 |
| Observation có exact reader binding | 22 | 7 |
| Root reads / read failures | 90143 / 10 | 31854 / 11 |
| Root event còn giữ / bị đẩy khỏi ring | 128 / 491 | 128 / 90 |

Không trace/capture fault, projection exclusion hoặc normalization loss;
không thấy shared-DTO case native. Tổng29 typed response và16 local ACK,
trong đó4 ACK thiếu typed effect. Chưa xác định nguyên nhân thiếu, chưa
khôi phục hiệu ứng cũ, chưa chứng nhận thu đủ toàn bộ response server.

Cả hai khoảng thiếu BASIC và khoảng R lượt3 nằm trước lịch sử root còn
giữ. R lượt5 (gửi17:15:46.959, ACK17:15:47.730 UTC) nằm trong đoạn còn
giữ, có1 `ROOT_SET` và1 `EMPTY` chồng cửa sổ gửi–ACK. Những event này không
có nội dung response để gắn với sequence12, không chứng minh callback
vắng mặt hoặc read error là nguyên nhân. Mốc UTC của trace là xấp xỉ từ
một UTC/monotonic anchor.

Audit tài nguyên giữ25 khoảng có published boundary,73 delta khớp số
báo cáo,9 mẫu cap/floor và52 lastStat khớp endpoint. Đây là chứng cứ số dư
đã quan sát, chưa phải mô hình dự đoán hoặc tập training đã được duyệt.

## Điểm dừng và việc kế tiếp

ToolPID18516 đã STOPPED/FARM_RUN_COMPLETE, đủ1/1; UI log cuối đọc đúng
Priest1845 ở boss lobby. Cap này đóng hoàn toàn; không tự chạy thêm để bù
coverage hoặc tái dùng timing sau khi đổi source.

Việc offline kế tiếp là giữ riêng lịch sử reader quan trọng quanh action/
failure để tránh event ít liên quan đẩy mất đầu trận, với bộ nhớ có giới
hạn và không đổi protocol đọc, nhịp poll, BASIC, adviser, PASS hay input.
Thiếu log không được biến thành effect giả hoặc nhãn thắng cho thuật toán.
Mega/Galaxy tiếp tục hoãn theo ưu tiên Demon trước.

[Đóng phiên](artifacts/demon_reader_trace_native_20261119/closure.json) ·
[5 cặp cùng snapshot](artifacts/demon_reader_trace_native_20261119/feature_review.json) ·
[Reader và cửa sổ thiếu](artifacts/demon_reader_trace_native_20261119/diagnostics_review.json) ·
[Độ phủ capture](artifacts/demon_reader_trace_native_20261119/capture_coverage.json).
