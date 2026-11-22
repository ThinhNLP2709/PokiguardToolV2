# Conditional damage v1 — TRAIN4 rồi TEST2, 21/11/2026

Đã đóng đúng bài tối đa 6 lượt: 1 BASIC + 3 Suy luận TRAIN, đóng băng hai
mô hình, rồi mới thu 2 Suy luận TEST. Cả 6 trận WIN, nhận thưởng và về đúng
phòng; không safe stop, technical abort hoặc recovery. Mô hình conditional
mới **chưa tốt hơn baseline** trên dữ liệu TEST, tiếp tục giữ ngoài gameplay.

Source `25a991ea6aed7f18164f29882000156c4d69bf0a4930e608e300278c7185218d`,
498 Python giữ nguyên byte. Game B17, Priest do UI/operator xác nhận cấp131,
Demon Aegis560 thường ăn Khiên/4 Kiếm hiệu dụng, không tiến hóa. Room/property
level vẫn raw0, không đổi thành bằng chứng native131. Đồ do operator xác nhận
giữ nguyên; chữ ký stats không chứng nhận toàn bộ loadout/effect thời điểm đó.

## Trình tự và giới hạn

[Intent](artifacts/damage_conditional_native_20261121/intent.json) định sẵn
vai trò và thứ tự 1/3/2 trước trận đầu. TRAIN có 4 match khác nhau,33 SWAP,
29 ACK,15 recorded DAMAGE target. Hai target không có Kiếm trong prefix đã
biết nên không fit; mỗi model dùng13 component:5 trực tiếp và8 quét.

[Freeze](artifacts/damage_conditional_native_20261121/frozen_models/freeze_manifest.json)
lúc09:42:44 UTC, trước khi tạo profile TEST và trước trận TEST đầu09:46:30.
Giữ nguyên policy v1, không tìm tham số hoặc thêm dữ liệu cohort khác.
Conditional đủ5 bàn trực tiếp/8 bàn quét; không có nhóm cascade riêng đủ mẫu.

Fitter cũ yêu cầu có VALIDATION hồi cứu. Adapter chỉ chạy file offline đã
được khai báo trong intent: clone AST, bỏ duy nhất điều kiện phải có
VALIDATION hiện hữu, vẫn yêu cầu TRAIN không rỗng và kiểm exact dataset/split.
Toàn bộ thân fit khác giữ nguyên; khôi phục điều kiện cho AST trùng gốc.
Trên split hợp lệ cũ, clone và fitter gốc trả về artifact giống hệt.
[Bằng chứng adapter](artifacts/damage_conditional_native_20261121/frozen_models/adapter_review.json).
Không sửa module production, input, PASS hoặc pointer gate.

TEST có16 SWAP,14 ACK,9 recorded DAMAGE target,4 response không ghi DAMAGE,
1 thiếu typed response và2 chưa ACK. Không thay các loại thiếu bằng0.
Match và bàn TRAIN/TEST không giao nhau, cùng source/build/account/cohort.
Weights được khóa trước khi chơi TEST; forecast tạo offline sau trận từ
pre-input request, pin trước scoring. Vì vậy không gọi đây là chứng nhận dự
báo trực tiếp trước click, công thức server, whole-action damage hoặc kill.
Evaluator vẫn giữ `independent_holdout=false` và provenance prospective=false.

## Kết quả trên cùng 9 target TEST

| Mô hình | Mode | Số target chấm được | MAE component |
|---|---|---:|---:|
| Baseline tỷ lệ trung vị | reference | 9/9 | 12.596,22 |
| Conditional 3 láng giềng | reference | 9/9 | 33.818,07 |
| Baseline tỷ lệ trung vị | guarded | 3/9 | 3.183,00 |
| Conditional 3 láng giềng | guarded | 1/9 | 9.549,00 |

Reference so từng target:7 hòa,2 xấu hơn,0 tốt hơn. Guarded chỉ có1 target
chung,hai model đều sai9.549; baseline còn2 target riêng sai0. Không so MAE
khác coverage để tuyên bố mô hình tốt hơn. Khoảng min/max là empirical,
không phải khoảng dự báo đã hiệu chuẩn.
[Forecast, metric và paired](artifacts/damage_conditional_native_20261121/test_evaluation/summary.json).

Hai lỗi cùng match `M_3801761d`: turn1 ghi152.796,baseline dự229.194,
conditional343.792; turn3 ghi152.796,baseline152.796,conditional229.194,67.
Cả hai dùng ba hàng TRAIN tỷ lệ rất khác nhau:38.199;57.298,67;89.131 trên
mỗi Kiếm đã biết. Có chỉ số tài nguyên ngoài miền TRAIN; guarded đã từ chối
cả hai. Đây là bằng chứng ngoại suy tỷ lệ cao, chưa chứng minh crit hoặc
thứ tự nộ là nguyên nhân. Không sửa policy sau khi xem TEST.
[Rà lỗi cố định](artifacts/damage_conditional_native_20261121/error_review.json).

64 forecast giữ nguyên khi thay toàn bộ nhãn/post-action bằng poison.
Hai artifact model vẫn trùng SHA đã freeze. Không nạp model mới vào adviser;
hai mode reference/guarded trong bảng chỉ là mode dự báo offline.

## Gameplay và dữ liệu thu được

44 quyết định Suy luận khớp replay44/44 trên trạng thái trước nước,130
checkpoint hợp lệ,5 worker đều được thu hồi,diagnostic queue không mất event.
26 lần chọn khác BASIC:16 đánh đổi,10 thiếu dữ liệu để chấm ưu thế;không
gán nhãn tốt hơn chỉ vì thắng hoặc ít lượt. Ví dụ TRAIN `M_c2dac07a` turn3:
BASIC lấy4 Máu và để boss có nước3 Kiếm đã biết;Suy luận lấy3 Kiếm và phần
bàn biết trước không còn nước Kiếm trả lời,đổi lại mất4 Máu. Refill vẫn
UNKNOWN nên không coi là đảm bảo an toàn.

Hai PASS được game xác nhận qua MATCH_AFK_WARN,không gửi gameplay input khi
chờ;không có third pass. Quyết định bỏ lượt vẫn do trạng thái game.
[TRAIN](artifacts/damage_conditional_native_20261121/train_reasoning/closure.json),
[TEST](artifacts/damage_conditional_native_20261121/validation_reasoning/closure.json).

84 response typed xuất đủ84/84,43 ACK có41 typed. Một gap TRAIN không có
scoped observation,cause UNKNOWN. Một gap TEST có JSON nhưng bị parser từ
chối vì176 operation vượt limit128;đã giữ rejection diagnostics,không phải
lỗi gửi nước/safe stop,không hồi phục hiệu ứng thiếu.
[Chi tiết hai gap](artifacts/damage_conditional_native_20261121/capture_gap_details.json).

428 operation có423 `crit` ABSENT và5 BOOL true,không có BOOL false. Đây là
wire field trong cùng response sau hành động;không biến absent thànhfalse,
không tự gán crit cho từng DAMAGE hoặc lấy flag tương lai làm input.
[Witness crit](artifacts/damage_conditional_native_20261121/crit_presence_witnesses.json).
Payload tối đa9.589/32.768 byte. Log/profile/prefs/cap cũ giữ nguyên;1.173
pin đầu vào/evidence cũ được kiểm lại,ordinary preferences vẫn không có như
ở đầu case. Không build,đổi version hoặc tự mở thêm trận.

## Điểm chốt và việc kế tiếp

Cap mới6/6 đã đóng,cộng32 lịch sử thành38,còn0. Tool TEST ở trạng thái dừng
2/2 trong lobby sạch;GUI vẫn mở. [Closure](artifacts/damage_conditional_native_20261121/closure.json).

Bước offline tiếp theo là rà thứ tự Nộ/Hút/Khiên và phần damage có thể do
refill chưa biết trong các tỷ lệ TRAIN chênh lệch,giữ TEST này là bằng chứng
đã xem. Đồng thời thiết kế cách thu event dài176 operation trong ngân sách
cố định,không đơn thuần nới limit rồi gọi là đủ. Sau khi có thiết kế v2 mới
đăng ký policy và split trước một bài TEST mới. Chưa cần chơi thêm hoặc đổi
Mega/Galaxy ở mốc này;chưa có bằng chứng để dùng predictor này quyết định
đòn kết liễu hoặc xếp hạng nước live.
