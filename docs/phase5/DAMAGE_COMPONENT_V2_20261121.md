# Mô hình component V2 offline — 21/11/2026

Đã triển khai và chấm V2 học trực tiếp DAMAGE component ở cùng vector số
Kiếm biết trước. Không còn chia toàn bộ response cho prefix rồi nhân tỷ lệ
sang số Kiếm khác. Mô hình giữ biến thiên crit/refill trong dữ liệu,nhưng
**chưa chứng minh tốt hơn baseline** và chưa dùng để chọn nước live.

Source `f1d59907ef948df778b443df2408c8167dac933025551b73a0c5c4ee43023b88`,
503 Python:500 file có sẵn giữ nguyên byte,3 file thêm(module/runner/test).
Không thay planner,logger đã sửa event dài,input,PASS hoặc hai mô hình cũ.
Không attach game/chạy thêm trận/build. Tổng lượt nghiên cứu vẫn38,còn0.

## Chính sách chốt trước fit

[Policy](artifacts/damage_component_v2_20261121/policy_frozen.json),SHA
`ef697088…`,được pin trước khi chấm. Group bằng đúng build/account/source/
cohort/cài đặt/chữ ký stats,và **số lượng** Kiếm quét/trực tiếp/cascade đã
biết. Không chỉ cùng dấu có/không và không nội suy sang số Kiếm khác.

Dùng13 chiều pre-input cũ,3 láng giềng với toàn bộ tie,mỗi bàn TRAIN chỉ
đóng góp1 láng giềng gần nhất;ít nhất3 bàn khác nhau. Point là weighted
median của component amount;range là min/max amount của láng giềng,không
phải khoảng dự báo đã hiệu chuẩn. Reference chỉ nghiên cứu;guarded kiểm
miền từng chiều và khoảng cách joint. Thiếu hỗ trợ trả abstention,không có
đường từ đây tới SAFE_STOP.

Crit,refill,thứ tự tài nguyên và buff chưa quan sát là biến ẩn. Không lấy
post tags/crit làm feature,không loại TRAIN chỉ vì thấy crit/mismatch sau
nước,không sửa target hoặc cài hằng số nộ/damage. Toàn bộ target vẫn là
recorded component,không thành sát thương toàn hành động hoặc xác suất kill.

## Bài so sánh đã làm

[Plan](artifacts/damage_component_v2_20261121/experiment_plan_frozen.json),
SHA `7fee7f4e…`,pin trước fit;không chọn lại tham số theo metric. Có13 cohort
lịch sử/27 match và cohort native mới6 match:289 action/119 recorded target,
33 match riêng biệt. Chạy34 fold:33 fold bỏ riêng từng trận và1 split4/2 cũ
đã xem,dùng riêng để chẩn đoán,không cộng lại vào tổng33/119.

Mỗi fold fit baseline,V1,V2 cùng split:102 artifact(34 mỗi loại). Các
forecast được seal trước scoring. 1.024 forecast control ở các bài có bản
đối chiếu frozen tái hiện nguyên. Toàn bộ dữ liệu đã xem nên đây là
DEVELOPMENT hồi cứu,không phải TEST độc lập hoặc dự báo trước click.

| Mô hình | Reference có target chấm được | Guarded có target chấm được |
|---|---:|---:|
| Baseline | 63/119 | 30/119 |
| V1 tỷ lệ | 61/119 | 13/119 |
| V2 amount cùng số Kiếm | 14/119 | 2/119 |

Các số trên chỉ cộng **count**,không gộp MAE khác cohort/source thành một
metric. Trên14 reference target chung,V2 so V1:3 tốt hơn,1 xấu hơn,10 hòa;
so baseline:3 tốt hơn,2 xấu hơn,9 hòa. Nhưng V2 mất47 target V1 từng dự báo
được,gồm30 target V1 sai0;so baseline mất49,gồm32 sai0. Guarded chỉ có2
target chung,hòa cả hai,mất11 target V1/gồm6 sai0. Không thể gọi việc từ
chối nhiều là chất lượng tốt hơn.
[Lost coverage](artifacts/damage_component_v2_20261121/lost_coverage.json).

## So riêng6 trận native mới nhất

V2 reference chấm12/24 target,MAE22.776,25. Trên đúng12 target đó,V1
MAE24.559,39(3 tốt/1 xấu/8 hòa),baseline MAE18.097,08(2 tốt/1 xấu/9 hòa).
V2 interval phủ9/12,không tốt hơn baseline10/12. Guarded chỉ chấm2/24,
MAE9.549,bằng hai control trên cùng2 mẫu. Vì vậy chưa có gain toàn diện.

Split4 TRAIN/2 TEST cũ nay là DEVELOPMENT:V2 reference chỉ chấm2/9,target
chung có1 hòa/1 xấu hơn cả hai control;guarded1/9 hòa. Hai lỗi extrapolate
cũ bị từ chối do thiếu bàn cùng số Kiếm,không được tính thành dự báo đúng.
[Kết quả từng cohort](artifacts/damage_component_v2_20261121/experiment/summary.json).

## Dữ liệu hỗ trợ đang thiếu

Đối chiếu riêng với TRAIN4 cũ:

| Kiếm quét biết trước | Số bàn TRAIN có component | Thiếu để đạt tối thiểu3 bàn |
|---|---:|---:|
| 2 Kiếm | 0 | 3 |
| 4 Kiếm | 2 | 1 |
| 5 Kiếm | 0 | 3 |
| 6 Kiếm | 1 | 2 |

Nhóm3 Kiếm còn thiếu miền Nộ/Mana/Hút trong một số tình huống. Đây là
số bàn có ACK/component và context phù hợp,**không phải số trận đảm bảo**.
Số liệu thuộc cohort/source25a của bài cũ;không tự trộn source mới hoặc
cohort khác để đạt số3. Không nên săn đúng board hoặc gán thêm label giả.
[Yêu cầu theo từng mẫu](artifacts/damage_component_v2_20261121/support_requirements.json).

Trước một bài live mới cần pin đúng source và cohort,kiểm chứng đường thu
mới,và định rõ TRAIN/TEST mới sau freeze. Không rebound profile/cap cũ.
Thay đổi fingerprint do thêm module offline cũng không tự cho phép bỏ qua
provenance dữ liệu;khả năng chuyển dữ liệu giữa source phải được chứng minh
riêng trước khi đổi grouping. Chưa mở một bài live mới trong mốc này.

## Kiểm chứng và điểm chốt

314 test PASS,12 test mới. Có test3→6 Kiếm không rescale,tránh lặp bàn làm
tăng trọng số/đủ support,giữ range có crit outlier,5 target Demon dùng cùng
thuật toán,gates input/scope/validation/tamper và runner seal trước chấm.

Audit refit34 model V2 sau khi poison mọi post field và nhãn VALIDATION:
parameters/training payload giữ nguyên,610 forecast giữ nguyên. 500 Python
cũ nguyên byte,model cũ/control/raw/profile/cap trước giữ nguyên;module mới
chỉ được import bởi runner offline và test.
[Audit](artifacts/damage_component_v2_20261121/audit.json).

Mốc V2 này đóng với kết quả chưa đạt để deploy;không tuning tiếp trên những
target đã xem. V2 giải quyết cách diễn giải hệ số và ngoại suy số Kiếm,
chưa giải quyết đầy đủ dự báo crit/refill hoặc độ phủ. Hướng kế tiếp là
kiểm tương thích pipeline/provenance để dùng dữ liệu hiệu quả,định rõ phần
latent cần thêm bằng chứng,rồi mới chốt bài thu/TEST mới. Value/ranker và
Mega/Galaxy vẫn theo thứ tự cũ,Demon trước. Source503 chưa native,logger
event dài vẫn mới chỉ được kiểm offline;GUI cũ không xác nhận source này.
