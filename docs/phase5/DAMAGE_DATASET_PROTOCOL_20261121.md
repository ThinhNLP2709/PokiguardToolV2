# Bộ mẫu trước nước và chuẩn kiểm sai số damage

Đã hoàn thành mốc offline: xuất mẫu trước nước từ hai log native gần nhất,
tách nhãn hiệu ứng đã quan sát và có công cụ chấm sai số dự đoán. Không fit
mô hình,không thay adviser hoặc chạy thêm trận.

## Dữ liệu đã xuất

Chỉ dùng hai file đã pin SHA của BASIC `M_74d53f68` và Suy luận
`M_f0474047`,source c50977f8/game B17/cùng account và cấu hình Demon Khiên.
Không pool các log cũ khác build/account hoặc xem lời khai giữ đồ là chứng
nhận đủ loadout. Manifest chứa nguồn/hash/phạm vi của từng file.

| Nhóm mẫu | Số lượng | Cách giữ |
|---|---:|---|
| Lần gửi SWAP | 18 | Một sample theo identity của action,không theo số bản sao log |
| Được game ACK | 16 | Giữ cả các nước không có typed effect |
| Hủy do state đổi,chưa ACK | 2 | Nhãn không xác định,không tính sai số damage |
| ACK có ghi component DAMAGE ta→boss | 8 | Sum amount của đúng component được giữ,không gọi là damage toàn nước |
| ACK có effect nhưng không ghi DAMAGE | 5 | `NO_RECORDED_COMPONENT`,amount=null |
| ACK thiếu typed response | 3 | `MISSING_TYPED_RESPONSE`,amount=null |

PASS được game xác nhận ở trận R có1 record đợi,được đếm riêng; không biến
thành mẫu SWAP hoặc gán damage0. Không bỏ các nước thiếu kết quả khỏi mẫu
để làm sai độ phủ. Cả18 mẫu có đủ bộ input đã định nghĩa; điều đó không có
nghĩa đã đủ thông tin để hiệu chuẩn damage server.

## Hợp đồng trước nước

`prediction_request(sample)` là toàn bộ dữ liệu mà predictor tương lai được
nhận: sample ID,feature SHA,board/move,chỉ số trước input của ta và boss,
cài đặt lối chơi đã khai báo và kết quả quét đầu từ solver hiện có.

- Chỉ lấy từ `action_sent` có identity/turn/board/source hợp lệ. Stats phải
  có ownership và nguồn Active rõ ràng; thiếu giữ null,không điền0.
- Hình học dùng lại `_match_through`, `_passive_geometry`, `_tallies` đang
  có. Hỗ trợ cả nước thường và nội tại Demon,đủ5 viên mục tiêu. Đếm riêng
  số viên vật lý/hiệu dụng theo multiplier1–7 của dự án. Không cho refill/
  cascade chưa biết tài nguyên hoặc damage giả định.
- Nhãn DAMAGE,fullPower sau phản hồi,context/weakness/equip sau phản hồi,
  raw response SHA và kết quả trận không nằm trong feature. Không lấy
  context mới khớp post-state rồi dùng cho pre-state của cùng nước.
- Feature có whitelist và SHA riêng; nhãn hoặc dữ liệu tương lai thay đổi
  không được làm thay đổi request predictor. Board không hợp lệ giữ UNKNOWN,
  không sửa bàn. Tên actor được hash; không xuất username làm feature.

Mẫu vừa xuất chỉ là nguồn cho nghiên cứu. `training_eligible`,
`calibration_eligible`, `input_authority` tiếp tục false. Không nhập module
mới vào đường đánh đang chạy.

## Nhãn và thước đo

Target duy nhất hiện tại là
`RECORDED_LOCAL_TO_BOSS_DAMAGE_COMPONENT_SUM`. BLOCK/SHIELD/HEAL không được
cộng thành HP damage; không dùng chênh lệch HP thay component bị thiếu.
Whole-action coverage vẫn UNKNOWN. Component âm bị loại; HP boss chạm0
giữ censor và không tính như nhãn damage chính xác. Cả hai tình huống này
được kiểm bằng fixture,không tuyên bố đều xuất hiện trong18 mẫu thật.

Dự đoán phải nêu sample ID,feature SHA,point/lower/upper và khớp đúng SHA
dataset/loại target. Có thể từ chối dự đoán với reason và ba giá trị null.
Không cho NaN,bool,số âm,khoảng đảo chiều,dự đoán trùng hoặc nhầm mẫu.

Công cụ chấm:

- MAE,RMSE,sai số có dấu và p95 sai số tuyệt đối;
- tỷ lệ dự đoán lớn hơn amount quan sát,độ phủ và độ rộng khoảng;
- MAE trung bình theo từng trận,để trận nhiều nước không tự chiếm toàn bộ
  trọng số đánh giá;
- số action/ACK/mẫu có nhãn/số dự đoán/từ chối/lý do không tính,để thấy rõ
  độ phủ. Không dùng MAPE gây vấn đề với amount0 được ghi rõ.

Các số trên chỉ đo recorded component,không nghiệm thu kết liễu,sống sót,
damage toàn nước hoặc chất lượng chọn nước. Cần dữ liệu và chuẩn riêng cho
các mục tiêu đó. Hàm không tạo forecast,không tự fit hoặc cấp quyền live.

## Tách tập và chống dùng lại dữ liệu

Mỗi trận nằm trọn một partition. Cùng bàn trước nước không được đi qua hai
partition,kể cả move khác nhau. Bản sao action gộp lại; hai bản cùng identity
nhưng feature/nhãn/execution khác nhau bị cách ly,không chọn bản thuận lợi.

Kết quả chia theo build,source/account,cấu hình,cohort khai báo và chữ ký
stats tối đa/attack của ta/boss; tách nước quét nội tại với nước trực tiếp.
Đây là nhóm số học/manifest,không chứng nhận mọi trang bị/buff giống nhau.
Tổng MAE được giữ để mô tả,các nhóm không tự trở thành một model dùng chung.

Hai trận này đã được xem khi nghiên cứu,nên đều là DEVELOPMENT. Công cụ
từ chối gọi chúng là TEST độc lập. Ngay cả manifest khai chưa xem và plan
yêu cầu holdout,report vẫn không tự chứng nhận tính độc lập/nguồn forecast
trước kết quả; các bằng chứng đó cần được pin riêng ở bước thử model.

## Đã kiểm được gì

- 184 test tập trung PASS,gồm15 test mới: target thiếu/0/censor,ownership,
  x7/5 target,geometry cũ,duplicate/conflict,leakage,split và toán metric.
- Trên18 sample thật,khi replay bỏ hết response/published-state tương lai,
  predictor request vẫn khớp18/18. Đổi nhãn/fullPower tương lai trong bộ
  nhớ cũng giữ request18/18. Đây là kiểm offline trên log native,không phải
 18 phiên live mới.
- Replay thêm bản sao BASIC vẫn18 action duy nhất,gộp đúng7 bản sao.28 typed
  outcome của hai file giữ normalization như trước; file thô giữ nguyên.
- Hai CLI build/evaluate chạy được. Vì chưa có model/forecast,artifact
  đánh giá thật có0 prediction/0 scored,MAE/RMSE/độ phủ khoảng đều null.
  Không điền dự đoán giả để tạo kết quả đẹp. Kiểm toán metric bằng forecast
  tổng hợp chỉ nằm trong test và không được gọi là độ chính xác native.

Source trước c50977f8,sau
`07cceab0e3ed02c233f859defb274adbed02c508b5a462d482fc0b0c94b08bfc`
(486 Python). Chỉ thêm3 file;483 file cũ nguyên byte,bao gồm reader,
collector,BASIC/adviser/PASS/input. Whole-source fingerprint mới chưa có
native acceptance; bằng chứng live c509 vẫn ở phạm vi gốc. Không cần chạy
thêm game chỉ để kiểm các helper offline này.

## Dùng lại và điểm chốt

Chạy từ gốc V2,output phải là đường dẫn mới trong V2:

```powershell
python tools/prepare_demon_damage_dataset.py build --manifest docs/phase5/artifacts/damage_dataset_20261121/manifest.json --out temp/reasoning/damage_check/dataset.json
python tools/prepare_demon_damage_dataset.py evaluate --dataset temp/reasoning/damage_check/dataset.json --predictions docs/phase5/artifacts/damage_dataset_20261121/empty_predictions.json --partition-plan docs/phase5/artifacts/damage_dataset_20261121/partition_plan.json --out temp/reasoning/damage_check/evaluation.json
```

Artifact dự đoán rỗng chỉ kiểm đường chạy CLI,không là model. Mốc này đóng:
0 trận/input/attach/train/build mới,tổng30 lượt đã đóng,còn0. Profile,
preferences và cap cũ giữ nguyên. Tool23260 dừng ở mốc trước; đợt offline
không kiểm lại hoặc thao tác UI/game.

Việc tiếp theo đã rõ: thử baseline/predictor offline có quyền từ chối khi
không đủ nguồn,và chốt nguồn dự đoán/split trước khi xem kết quả mới.8 mẫu
component chưa giải quyết boss metadata/crit/buff/whole-action coverage hoặc
holdout độc lập. Không nạp hệ số vào adviser từ một tỷ lệ damage/kiếm,
không dùng WIN hoặc điểm utility làm nhãn tối ưu. Nhánh học value/ranker
vẫn xếp sau phần dữ liệu/ước lượng còn mở.

[Dataset đã pin](artifacts/damage_dataset_20261121/dataset.json),
[plan DEVELOPMENT](artifacts/damage_dataset_20261121/partition_plan.json),
[kết quả chạy không có forecast](artifacts/damage_dataset_20261121/evaluation.json),
[audit chống leakage](artifacts/damage_dataset_20261121/audit.json),
[kiểm tra cuối](artifacts/damage_dataset_20261121/final_verification.json).
