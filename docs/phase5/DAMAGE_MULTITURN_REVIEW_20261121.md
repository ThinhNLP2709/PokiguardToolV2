# Demon — phân tích8 mẫu damage và4 chuỗi phá mới

Đã hoàn thành rà offline hai trận vừa thu và bổ sung bộ mô tả cơ chế trước
nước cho nghiên cứu damage. Bộ mô tả tách Kiếm ăn trực tiếp, Kiếm trong vùng
quét Demon và Kiếm từ chuỗi ordinary đã biết. Giữ Nộ trước nước, viên Nộ/Hút
đã biết và phần tiếp diễn chưa biết riêng biệt, không biến chúng thành dự
báo chắc chắn FULL_POWER hoặc số dư cuối.

Source mới `33997e9cb5f215e77f4152012c7912a8c052630ca6678d210518249fb067a578`,
495 Python: **492 file cũ nguyên byte,3 file thêm**, cùng1 fixture JSON
chỉ chứa dữ liệu trước nước. Đây là nâng công cụ phân tích/đầu vào mô hình
offline, chưa thay nước đi hoặc mô hình runtime. BASIC/adviser/reader/input/
PASS giữ nguyên. Không mở tool, attach process, chơi thêm hoặc build.
Case native d699 vẫn đóng2/2, tổng32, còn0; profile/prefs/cap cũ không đổi.

## Tám quan sát nói được gì

Chỉ dùng8 target recorded DAMAGE có ACK.17 response không ghi DAMAGE không
thành nhãn0;4 ACK thiếu typed và2 action chưa ACK giữ riêng. DAMAGE ở đây
là component ta→boss được lưu, không cam kết damage toàn nước hoặc kill.

| Trận/lượt | Kiếm quét / Kiếm chuỗi đã biết | Nộ trước nước | Nộ hiệu dụng trong phần bàn đã biết | DAMAGE được ghi | fullPower wire |
|---|---:|---:|---:|---:|---|
| BASIC3 |4 /0|20|6|152.030|true|
| BASIC17 |6 /0|215|5|229.194|true|
| BASIC27 |3 /0|245|10|113.295|true|
| R1 |3 /0|0|5|114.597|true|
| R3 |4 /0|5|1|101.864|ABSENT|
| R5 |3 /0|45|6|114.597|true|
| R11 |4 /0|245|5|152.796|true|
| R13 |0 /3|170|3|28.649|true|

Đây là các bàn khác nhau, không phải thí nghiệm đổi một biến có kiểm soát.
Không lấy chênh lệch damage làm bằng chứng nhân quả của riêng Nộ hay nội tại.

**Không thể chỉ nhân số Kiếm với một tỷ lệ chung.** R3 và R11 cùng4 Kiếm
quét nhưng component101.864 và152.796. R3 ghi Nộ5→25 và không có operation
FULL_POWER trong response đã giữ; fullPower key ABSENT không được đổi thành
false. R1 bắt đầu Nộ0, response ghi +100→100 rồi FULL_POWER−100→0. R5 ghi
+120→165, Hút+70→235 rồi FULL_POWER−100→135. Các chuỗi này giải thích vì
sao phải xét Nộ có thể thu trong nước và giữ riêng tiêu Nộ/Hút/chạm trần.
Không lấy hằng số100/20 từ vài quan sát để cài một công thức server chung.

Trong4 mẫu quét có wiretrue và boss không Khiên, tỷ lệ component/known Sword
đều38.199; một mẫu quét wireabsent là25.466; mẫu ordinary cascade R13 là
28.649/3. Đây chỉ là mô tả sau response, không là hệ số được nghiệm thu cho
mọi pet, target, khắc hệ hoặc tình trạng crit. Cả230 operation ở phiên này
vẫn thiếu crit, không chứng minh damage không chí mạng.

BASIC3 có Khiên boss1.149, BLOCK383 rồi BLOCK766 rồi DAMAGE152.030.
BASIC27 có Khiên4.557, BLOCK3.255 rồi BLOCK1.302 rồi DAMAGE113.295. Cộng
BLOCK liền trước vào DAMAGE cho152.796 và114.597 chỉ là phép tính sau
response; không chứng minh từng BLOCK thuộc cùng một đòn. Không sửa target
thành DAMAGE+toàn bộ Khiên hoặc đưa BLOCK sau nước vào feature.
[Từng target và operation](artifacts/damage_multiturn_review_20261121/eight_target_review.json).

## Bốn chuỗi phá: phân biệt phần biết trước và phần chưa biết

| Trận/lượt | Từ bàn trước nước, solver cũ tính được | Phản hồi đã ghi thêm | Phạm vi giữ lại |
|---|---|---|---|
| BASIC1 |3 Hút rồi3 Mana|tag khớp6 viên đã biết|ordinary cascade có điều kiện|
| R3 |quét đầu có4 Kiếm và5 Máu|thêm3 Máu ở đợt sau|chỉ ghi quét đầu; chưa biết tiếp diễn|
| R13 |3 Nộ rồi3 Kiếm|còn7 Máu trong tag tổng|ghi3 Kiếm đã biết, không cộng7 Máu chưa chứng minh|
| R15 |3 Máu rồi3 Hút|tag khớp6 viên đã biết|ordinary cascade có điều kiện|

Ở R13, bộ mẫu damage cũ chỉ chứa first-wave nên có0 Kiếm và baseline từ
chối. Solver ordinary hiện có đã thấy3 Kiếm ở chuỗi tiếp theo ngay từ bàn
trước nước. Adviser vốn dùng solver này; thay đổi mới giúp **đầu vào nghiên
cứu damage bắt kịp khả năng đó**, không phải sửa một lỗi bỏ Kiếm của runtime.
Vẫn có ô refill chưa biết; đường đã biết không chứng nhận toàn bộ diễn biến
server, toàn bộ tag hoặc damage của nước thay thế.

Rà thêm26 log chính cũ tìm3 action tương tự có0 Kiếm first-wave nhưng
3/4 Kiếm trong known cascade; cả3 có ACK và tag Sword khớp phần đã biết.
Giữ chúng theo source/cohort gốc, không gộp để chứng nhận một hệ số damage
chung hoặc biến bản sao log thành mẫu độc lập mới.

## Phần triển khai

- `damage_action_context.describe_action` chỉ nhận prediction request trước
  nước có schema/hash/geometry hợp lệ. Không nhận nhãn hoặc context sau
  response. Đối chiếu lại cache first-wave với chính board/move/target.
- Dùng `_passive_geometry` và solver/collapse cũ. Chia vùng quét với direct
  ngoài vùng quét thành hai phần không giao nhau; giữ x1–x7 theo effective
  units. Cùng geometry khai báo hoạt động với cả5 target Demon.
- Ordinary cascade được giữ nếu không có target kích hoạt ở chuỗi sau.
  Nếu target có thể kích hoạt ở chuỗi sau, dừng mô tả tại first-wave và đánh
  dấu `LATER_PASSIVE_UNMODELED`; không bịa một quét tiếp theo.
- Quét Demon giữ first-wave và phần refill/residual chưa biết; không chạy
  solver ordinary giả định bỏ qua nội tại để cộng thêm lợi ích sau quét.
- Nộ/Mana/Hút vẫn là gross counts và context trước nước, không là số dư
  ròng. Damage/fullPower/crit forecast đều null, input authority=false.
- `review_damage_mechanisms.py` ghép exact response/action/raw SHA và giữ
  chẩn đoán sau response trong nhánh riêng. Không sửa nhãn, fit hoặc đổi
  cách chọn nước. Không có import module mới vào luồng gameplay.

Đã rà254 action:31 mới+223 lịch sử,28 file chính khác nhau. Tất cả cache
first-wave khớp board/move;4 action có Kiếm chuỗi dù first-wave0. Một action
lịch sử có thể kích hoạt target ở chuỗi sau được giữ là chưa mô hình hóa.
Đây là số action, không là254 mẫu độc lập hoặc254 trận mới.
[Mẫu mới](artifacts/damage_multiturn_review_20261121/native_mechanisms.json),
[lịch sử](artifacts/damage_multiturn_review_20261121/historical_mechanisms.json).

## Giữ phép đo baseline cũ để so sánh

Đã đóng plan trước lần fit/chấm này và chạy lại đúng policy cũ trên hai trận
mới:2 fold theo trận, source/account/cấu hình/chữ ký stats và direct/quét
tách riêng, tối thiểu3 mẫu, không tuning hoặc nới gate.

| Mode cũ | Target chấm được | MAE | Sai số lớn nhất |
|---|---:|---:|---:|
| Reference |7/8|7.735,57|50.166|
| Guarded |2/8|670,25|766|

Sai số50.166 nằm ở R3, nơi cùng4 Kiếm nhưng chuỗi Nộ/fullPower khác. Guarded
giữ2 mẫu, không gọi độ phủ25% là đã dự đoán tốt. R13 vẫn bị baseline cũ từ
chối do first-wave0; chưa đổi denominator, weights hoặc forecast của nó theo
descriptor mới. Mô tả cơ chế mới **chưa được đưa vào một predictor mới**, nên
không tuyên bố nó đã giảm MAE. Hai trận đã xem trước là dữ liệu khám phá,
không phải holdout độc lập cho thuật toán được thiết kế sau khi xem.
[Plan đóng băng](artifacts/damage_multiturn_review_20261121/baseline_plan.json),
[metric và từng fold](artifacts/damage_multiturn_review_20261121/frozen_baseline/summary.json).

## Kiểm chứng và điểm chốt

222 test tập trung PASS, gồm12 test mới về known cascade,5 target,x1–x7,
phân vùng không đếm đôi,later passive/missingness,hash/cache và rò dữ liệu
tương lai. Thử đổi DAMAGE/fullPower/response context/crit trên254 mẫu giữ
nguyên request và descriptor254/254. Fixture4 bàn trước nước đối chiếu đúng
request trong dataset native, không chứa response làm đầu vào.

492 Python cũ và raw/native/profile/prefs/cap đã đóng nguyên hash. Source
495 hiện tại chỉ được kiểm offline; proof native d699 vẫn giữ phạm vi cũ.
UI17788 dừng1/1 là quan sát cuối của phiên trước, không kiểm lại offline.
Không mở cap/claim mới, không build; chỉ lưu2 artifact baseline nghiên cứu cũ,
không train value/ranker hoặc deploy mô hình vào adviser.
[Audit](artifacts/damage_multiturn_review_20261121/audit.json),
[kiểm tra](artifacts/damage_multiturn_review_20261121/tests.txt).

Mốc phân tích8 target/4 chuỗi và bổ sung đầu vào cơ chế đã hoàn thành.
Hướng kế tiếp là predictor có điều kiện theo các kênh Kiếm và ngữ cảnh Nộ,
giữ bất định Khiên/Hút/refill/crit; chưa lấy thiếu crit làm lý do săn thêm
trận ngẫu nhiên. Trước lần kiểm chất lượng mới phải đóng thiết kế và split,
không tự chứng nhận bằng cách fit rồi chấm lại8 mẫu đã xem.
[Yêu cầu model kế tiếp, chưa phải model hoặc quyền live](artifacts/damage_multiturn_review_20261121/next_model_requirements.json),
[bản đồ artifact](artifacts/damage_multiturn_review_20261121/artifact_map.json),
[kiểm tra cuối](artifacts/damage_multiturn_review_20261121/final_verification.json).
