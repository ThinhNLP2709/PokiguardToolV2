# Đã kiểm trực tiếp bộ thu ngữ cảnh: 1 BASIC + 1 Suy luận

Đã hoàn thành đúng2 trận được yêu cầu, cả hai WIN/nhận thưởng/về lại phòng
Priest. Không có safe stop, recovery hoặc lỗi input. Mốc này nghiệm thu
việc thu/ghép context và chạy Suy luận trên source hiện tại; chưa chứng nhận
mô hình damage hoặc kết luận Suy luận tốt hơn chỉ từ kết quả hai trận.

Source `c50977f870de8717cf57db2cc5639f7bf978f8f3fb4549b59c86064b210d0c7c`,
483 Python giữ nguyên byte từ trước đến sau. Game B17, room `Coop_517437`,
pet560 Demon Aegis thường ăn Khiên, boss1845 Priest. UI hiển thị131;
RoomDTO/properties level0 không được coi là level thực của boss. Đồ giữ
nguyên theo người dùng; không tuyên bố đã đọc đủ toàn bộ loadout runtime.

## Hai phiên thực tế

| Mục | BASIC | Suy luận |
|---|---:|---:|
| Match | M_74d53f68 | M_f0474047 |
| Run | dc3f9c659cfc4d7a8315a67e835915fd | 41a16d9916b444ff9c46599750ce704e |
| Kết quả | WIN, về phòng | WIN, về phòng |
| Lượt ta/boss | 7/6 | 12/11 |
| SWAP sent / ACK / hủy do state đổi | 7/6/1 | 11/10/1 |
| PASS được game xác nhận | 0 | 1 |
| Context phản hồi duy nhất | 12 | 18 |
| Context ghép exact SWAP sent/ACK | 5 | 8 |

Không dùng chênh lệch7 với12 lượt làm thước đo chất lượng vì hai bàn khác
nhau. Nước PASS ở turn17 được `MATCH_AFK_WARN` xác nhận idle_count1,
threshold3,0 gameplay input trong lúc đợi. Không có lượt bỏ thứ ba; không
thêm giới hạn bỏ lượt cứng hoặc thay rule đang hoạt động.

14 gate qualification giữ nguyên điều kiện và PASS với baseline đóng băng
của chính source này.6 mẫu thời gian BASIC mới tạo profile mới, tối đa1
trận Suy luận; không gắn lại profile cũ sang source mới. R ghi12 decision,
35 checkpoint (11 SWAP×3 +1 PASS×2),12/12 replay trùng nước và cấu trúc
search.72 event ghi đủ,0 drop/fault,worker1/1 đã reap,writer closed/flushed.
Summary lớn nhất11826/12000 byte. Cấu hình jitter0–1s/0–1,5s/±10% giữ nguyên.

Computer-use lỗi kernel assets OS error3 sau reset/retry. Hai cú Bắt đầu
do người dùng bấm trong UI tool; gameplay dùng đúng FarmRunner/input hiện
có. GUI BASIC7024 được đóng sau khi ledger/watermark hoàn tất; GUI R23260
đang dừng1/1,đúng lobby ở lần kiểm cuối. Không gọi API game để đi nước.

## Context mới đã thu được gì

30 response có context CAPTURED,không conflict;28 typed outcome. Tất cả
context lấy từ `playersStateDelta` và chỉ có actor của ta trong các phản hồi
đã giữ. Boss metadata chưa xuất hiện trong context này. Tên actor được hash
và khớp ownership từ phòng; actorNumber không tự tạo quyền sở hữu.

23/24 field whitelist xuất hiện. `weaponRarity` thiếu, không điền lại;
weaponImageId0 là giá trị raw thật, không đồng nghĩa không có trang bị.
Các giá trị ổn định trong30 mẫu: pet560,METAL,lv12,attack1819,avatarId1,
weaknessVsBoss1.75,equipCounterPct[25,25,25,25,25]. Thứ tự/ý nghĩa mảng
khắc hệ và công thức áp dụng chưa xác minh. Không cộng attack pet+avatar.
Payload effect + context lớn nhất6363/32768 byte.

**Đã kiểm được phase quan sát, không nâng thành feature trước nước:**

- 28 response có published state cùng match/sequence,acknowledged/stable:
  cả28 khớp8 chỉ số HP/Mana/Nộ/công/Khiên và các mức tối đa.
- 13 context ghép exact SWAP sent/ACK có đủ pre-input stats để so: cả13 có
  ít nhất một chỉ số khác trước nước. Vì thế không lấy context response làm
  snapshot trước nước, không dùng để dự đoán chính damage vừa quan sát.
- 14/28 phép đối chiếu field với raw target-after của bước cuối được giữ
  khớp nhau. Phần không khớp không bị ép sửa; context response không phải
  trạng thái tại từng effect. Không suy whole-action completeness/formula.

13 context ghép exact ACK,2 chỉ có sent chưa exact ACK,15 UNBOUND (gồm các
response boss hoặc không có typed effect đủ ghép). Giữ nguyên từng nhóm;
không ghép gần thời gian,carry-forward delta hoặc dùng probe mở đầu trận.
Mọi mẫu vẫn calibration_eligible=false; chưa train hoặc nạp predictor.

## Đọc Suy luận trên cùng bàn

7/12 quyết định khác BASIC:4 TRADEOFF,3 INSUFFICIENT_DATA. Ví dụ turn3,
BASIC lấy3 Mana +3 Nộ, Suy luận lấy3 Kiếm; đường bàn đã biết sau đó có
reply kiếm tối đa3 so với0. Đây là đánh đổi tài nguyên với áp lực kiếm;
refill chưa biết nên0 không phải cam kết boss không có kiếm.

Turn19,Suy luận lấy3 Kiếm vật lý/6 hiệu dụng thay nước BASIC không có kiếm,
đổi lại mở thêm refill. Turn17 chọn PASS thay nước3 Nộ vật lý/5 hiệu dụng;
không có kết quả phản thực để chứng nhận bỏ lượt tối ưu. Các ví dụ được giữ
để nghiên cứu,không lấy utility/WIN làm nhãn học.3 mẫu nhánh thu Máu trong
worker summary cũng khớp replay; không ép chúng thành lợi ích định lượng.

UI có59 snapshot tạm hiển thị `UI_REASONING_COHORT_CHANGED`,sau đó quay lại
REASONING. Guard dùng chung policy/timer-source/expiry,nhãn này tự nó không
chứng minh đổi pet/boss hoặc Suy luận bị tắt.12 quyết định thực có đầy đủ
receipt hợp lệ,0 fault/fallback do thay cohort trong audit. Chưa xác định
điều kiện con gây từng nhãn tạm; ghi việc rà thông báo UI,không sửa gameplay
hoặc tuyên bố nguyên nhân đã được chứng minh.

## Phần chưa đủ và điểm dừng

16 SWAP ACK có13 typed response ghép được. BASIC turn1/response4 đọc được
JSON nhưng `combatSteps` thiếu hoặc null. R turn5/response12 và
turn21/response45 không có scoped observation trong trace đã giữ; không
được kết luận callback chưa từng đến. Không mất bản ghi ở normalization,
không điền các effect thiếu thành0; capture đầy đủ vẫn UNKNOWN.

Cap mới2/2 đóng,tổng30 lượt đã theo dõi,còn0. Không mở thêm trận. Source,
preferences thường,profile/cap cũ giữ nguyên;0 train/build. Bộ thu ngữ cảnh
mới đã được kiểm native trong phạm vi hai trận này. Boss/crit/buff và
ngữ cảnh tại từng effect vẫn thiếu. Bước tiếp theo là thiết kế bộ mẫu dùng
chỉ dữ liệu trước nước và chuẩn kiểm sai số ước lượng,offline; không cần
chạy thêm ngẫu nhiên để tìm field hoặc gắn nhãn thắng cho các nước.

[Đóng phiên và giới hạn](artifacts/response_context_native_20261121/closure.json),
[context và các nước cùng bàn](artifacts/response_context_native_20261121/context_and_choices.json),
[đối chiếu đúng sequence](artifacts/response_context_native_20261121/same_sequence_context_review.json),
[độ phủ effect/ACK](artifacts/response_context_native_20261121/capture_coverage.json),
[kiểm tra cuối](artifacts/response_context_native_20261121/final_verification.json).
