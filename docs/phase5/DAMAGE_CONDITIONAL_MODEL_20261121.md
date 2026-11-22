# Mô hình damage có điều kiện: đã triển khai offline, chưa chứng minh tốt hơn

Đã xây predictor thử nghiệm học từ cơ chế Kiếm và ngữ cảnh trước nước, giữ
baseline cũ để so trên đúng cùng target. **Kết quả log thật chưa chứng minh
chất lượng dự đoán tốt hơn. Không đưa mô hình vào gameplay.**

Source `25a991ea6aed7f18164f29882000156c4d69bf0a4930e608e300278c7185218d`,
498 Python:495 file cũ nguyên byte,3 file thêm. Không đổi BASIC/adviser,
reader, controller, input hoặc PASS; không có tùy chọn/lối chơi UI mới.
Đợt này0 trận,0 input,0 attach,0 build; tổng32 lượt kiểm đã đóng,còn0.
Native proof d699,profile,prefs và cap cũ giữ nguyên. Source mới chỉ được
kiểm offline; UI17788 dừng1/1 là lần quan sát trước,không kiểm lại.

## Model học gì và giới hạn ở đâu

`damage_conditional.py` nhận đúng prediction request trước nước. Cơ chế
quét/direct/known cascade lấy từ descriptor đã kiểm; tách nhóm theo việc
có mỗi kênh Kiếm,giữ nguyên build/account/source/cohort/cấu hình/chữ ký
stats. Không trộn pet hoặc viên kích hoạt khác nhau để tăng số mẫu.

Trong từng nhóm,học các cặp context và tỷ lệ recorded DAMAGE/known-prefix
Sword từ TRAIN. Context gồm13 chiều:3 kênh Kiếm,Nộ ta,viên Nộ đầu/sau,
Hút,Nộ/Mana boss,Mana ta,Khiên boss,ô refill chưa biết và residual đã biết.
Không dùng fullPower/crit sau response,không cài ngưỡng Nộ100,gain20 hoặc
hệ số damage của server.

Chọn3 hàng context gần nhất,giữ tất cả tie tại khoảng cách thứ3. Khoảng
cách RMS được chia theo range của TRAIN;weight=`1/(1+distance²)`. Point là
weighted median tỷ lệ địa phương nhân số Kiếm trong prefix. Lower/upper
là min/max tỷ lệ của các hàng đó,chỉ là khoảng kinh nghiệm,không phải
prediction interval đã hiệu chuẩn hoặc bảo đảm damage toàn nước/kill.

Cần ít nhất3 bàn TRAIN khác nhau,không lấy bản sao của1 bàn để đủ hỗ trợ.
Không dự đoán lại action/bàn đã học. Later passive chưa mô hình hóa,thiếu
stats hoặc không có Kiếm trong phần đã biết trả abstention,không trả0 damage.

Hai mode chỉ phục vụ kiểm nội bộ:

- `reference` cho phép ngoại suy và ghi rõ trường nào ngoài miền.
- `guarded` còn yêu cầu mọi chiều nằm trong range TRAIN và context gần
  không vượt bán kính nearest-neighbor leave-one-out của TRAIN.

Abstention là kết quả của predictor offline,**không phải SAFE_STOP hoặc lệnh
bỏ lượt**. Module không được import vào luồng chơi,không có input authority.
Không tuyên bố đã học xác suất thắng,chí mạng hoặc quy tắc FULL_POWER.

## Đã đóng phép thử trước khi fit

[Policy](artifacts/damage_conditional_20261121/policy_frozen.json) và
[plan](artifacts/damage_conditional_20261121/experiment_plan_frozen.json) được
pin trước lần fit nghiên cứu. Không tuning K,feature,guard hoặc split sau
khi xem kết quả.13 cohort dùng đúng các fold theo trận của baseline cũ;
không chia lại theo damage hoặc thắng/thua.1 cohort chỉ có1 trận vẫn bị
loại khỏi validation,không ép ghép với source khác.

Có27 artifact model/27 trận trong validation,240 action và95 recorded target.
Đây là dữ liệu lịch sử đã xem,không phải27 trận mới hoặc holdout độc lập.
Weights,pre-input requests và forecast được lưu/hash trước scoring;baseline
đã lưu được tái hiện nguyên metric từ raw predictions. Không thay target
thành DAMAGE+BLOCK hoặc điền effect thiếu thành0.

## Kết quả phải đọc cùng độ phủ

| Mode nội bộ | Baseline chấm được | Conditional chấm được | Trên target cả hai cùng chấm |
|---|---:|---:|---|
| Reference |41/95|39/95|37 bằng,1 tốt hơn,1 xấu hơn|
| Guarded |15/95|4/95|cả4 bằng baseline|

Không có target mới mà conditional chấm được còn baseline không chấm được.
Reference mất2 target;guarded mất11. Không gộp MAE của các cohort khác nhau
thành một số chất lượng chung.

Trong11 target guarded bị rút,2 ở reader_trace từng có sai số lớn,nhưng9
target còn lại từng có sai số0 trong tập đã xem cũng bị rút. Vì thế không
gọi việc rút2 sai số lớn là một nâng cấp chất lượng đã chứng minh.
[Các target mất độ phủ](artifacts/damage_conditional_20261121/coverage_loss_review.json).

Ở hai trận mới nhất,tập so giống nhau hoàn toàn:reference7/8 MAE7735,57,
guarded2/8 MAE670,25;mọi point bằng baseline. Ví dụ R3:TRAIN bên BASIC có
3 mẫu quét chủ yếu cùng mức damage cao. Query R3 có Nộ,viên Nộ,Hút/residual
ngoài miền đó. Reference vẫn dự đoán152.030 so với101.864 thực được ghi;
guarded từ chối. Nó không thể học mức damage chưa có trong TRAIN bằng
cách đổi tên thuật toán.

[Metric từng cohort và paired target](artifacts/damage_conditional_20261121/experiment/summary.json),
[support và trường ngoài miền](artifacts/damage_conditional_20261121/support_review.json).

## Dữ liệu đang thiếu có thể chỉ ra cụ thể

Trong95 target:

| Lý do chưa xuất point ở reference | Số target |
|---|---:|
| Chưa đủ3 bàn TRAIN trong cùng nhóm |32|
| Scope/cơ chế chưa xuất hiện trong TRAIN |16|
| Later passive chưa mô hình hóa |1|
| Không có Kiếm ở prefix đã biết |7|

Guarded từ chối thêm35 target vì context ngoài range TRAIN;không có target
thật mới bị loại chỉ bởi joint radius sau khi đã qua range ở lần thử này.
Các kiểm synthetic đã xác minh joint guard hoạt động,không lấy synthetic
làm bằng chứng native đã tránh một lỗi cụ thể.

Model có40 group entry qua các fold,24 entry chỉ có1–2 bàn,không phải40
nhóm độc lập. Chỉ thêm số trận ở nguồn/cấu hình khác sẽ không tự lấp các
nhóm này. Thiếu đáng chú ý là các context Nộ thấp/ít viên Nộ nhưng có Kiếm,
và ordinary cascade có Kiếm trong cùng một nguồn/cấu hình ổn định. Bốn
action cascade đã tìm được nằm ở các scope/fold khác nhau;không ép gộp.
Không cần săn cờ crit vốn có thể tiếp tục vắng mặt.

## Kiểm chứng

239 test tập trung PASS,gồm17 test mới. Synthetic có kiểm soát cho thấy
cùng3 Kiếm nhưng TRAIN với context Nộ khác nhau có hai mức300/600 thì
predictor học được300/600 cho bàn validation khác;baseline trả450 cho cả
hai. Đây là kiểm khả năng học và code,không phải kết quả trên game.

Test kiểm hash/board leakage,bản sao không đủ hỗ trợ,5 target,known cascade,
thiếu/censored/no-ACK,joint gap,tie và paired coverage. Đổi flags sau
response trong TRAIN và đổi toàn bộ amount VALIDATION ở27 fold giữ nguyên
parameters và480 forecast của hai mode.27 refit đó chỉ là audit trong RAM,
tách khỏi27 artifact fit nghiên cứu. Không train value/ranker.

495 Python cũ và các raw/profile/prefs/cap/weights/forecasts baseline nguyên
hash. Các khoảng kinh nghiệm chưa được hiệu chuẩn;chưa có native timing
hoặc native acceptance của predictor này. Bản thử chưa đủ để quyết định
kết liễu,bảo đảm sống hoặc chấm tối ưu nước thay thế.
[Audit](artifacts/damage_conditional_20261121/audit.json),
[tests](artifacts/damage_conditional_20261121/tests.txt),
[bản đồ artifact](artifacts/damage_conditional_20261121/artifact_map.json).

## Điểm chốt và bài thu kế tiếp đã chuẩn bị

Mô hình có điều kiện v1 và phép so đã hoàn tất. Giữ kết quả không thuận lợi;
không tìm thêm biến thể trên chính95 target để làm đẹp phép đo. Điều cần
kế tiếp là các bàn mới trong cùng một source/cấu hình và validation mới
được giữ sau khi đóng weights,không phải mở lại cap cũ.

Đã chuẩn bị **đề xuất tối đa6 lượt thử mới**,chưa được mở/ủy quyền:

1. TRAIN:1 BASIC đo thời gian mới +tối đa3 Suy luận,cùng Priest131/Demon
   Aegis thường ăn Khiên/4 Kiếm hiệu dụng/đồ giữ nguyên. Chơi bình thường,
   không ép nước để săn nhãn,không thay boss/pet/đồ giữa chừng.
2. Đóng TRAIN và kiểm support;đóng băng cả baseline lẫn conditional trước
   validation. Nếu chưa có support phù hợp thì giữ UNKNOWN,không tự tiêu
   thêm lượt để đủ mẫu.
3. TEST:tối đa2 Suy luận tiếp theo,giữ source/cohort,có request/cap riêng
   và ledger cha đã đóng. Không rebind/reset profile cũ hoặc vượt initial
   profile max3. Lưu forecast trước scoring và báo cả sai số lẫn độ phủ.

Vai trò các slot phải pin trước trận đầu;không chọn holdout bằng kết quả.
Sáu lượt không bảo đảm gặp đủ context hiếm hoặc đủ nghiệm thu triển khai.
Đề xuất chưa tạo request,profile,claim hoặc game input;cap thực vẫn32 đóng,
còn0. [Bài thu cụ thể](artifacts/damage_conditional_20261121/next_collection_proposal.json),
[kiểm tra cuối](artifacts/damage_conditional_20261121/final_verification.json).
