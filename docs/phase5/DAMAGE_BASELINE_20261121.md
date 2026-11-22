# Predictor thử nghiệm offline: đã có phép đo đầu tiên

Đã fit2 artifact thử nghiệm: học từ BASIC rồi dự đoán trận Suy luận,và học
từ Suy luận rồi dự đoán BASIC. Mỗi nước chỉ được chấm khi thuộc trận ngoài
tập học của model đó. Chưa đưa predictor vào adviser hoặc gameplay.

Đây là thử nghiệm khám phá trên hai trận đã được xem trước. Không phải
holdout độc lập hoặc dự đoán được ghi trước khi chơi. Target vẫn chỉ là sum
component DAMAGE ta→boss được lưu,không phải damage toàn nước/khả năng kill.

## Cấu hình đã đóng băng

Plan được ghi trước lần fit/chấm của thử nghiệm này,không phải trước mọi
lần nghiên cứu dữ liệu trước đây. Không tìm hyperparameter hoặc sửa quy
tắc sau khi thấy sai số:

- Chia theo trận,cả hai chiều BASIC↔Suy luận;giữ kiểm trùng bàn giữa split.
- Nhóm theo đúng build/account/source/cấu hình/chữ ký stats hiện có; nước
  ăn trực tiếp tách khỏi nước quét nội tại Demon. Không cố định viên Khiên.
- Học median của recorded component/effective Sword trong từng nhóm;
  ít nhất3 mẫu component mới xuất forecast. Giữ min/max tỷ lệ đã học để
  mô tả khoảng,không gọi đó là khoảng tin cậy hoặc bảo đảm độ phủ.
- Chế độ `reference` giữ các gate scope/regime/số mẫu nhưng cho phép
  ngoại suy để đối chiếu. `guarded` còn kiểm min/max từng chiều của số
  Kiếm hiệu dụng,Nộ trước nước và Khiên boss trước nước; ngoài miền thì
  không xuất ước lượng.

Các điều kiện trên thuộc nghiên cứu offline,không thêm giới hạn bỏ lượt,
SAFE_STOP hoặc nhánh input. Dataset vẫn calibration/training-eligible=false.
Việc fit yêu cầu cờ cho phép thí nghiệm component chưa hiệu chuẩn và mọi
artifact tiếp tục deployment_eligible=false. Không đổi cờ của dữ liệu để
biến mô hình thử thành mô hình được nghiệm thu.

## Kết quả ngoài trận học

18 action đều được đưa qua predictor của fold tương ứng. Có8 action đủ
nhãn recorded DAMAGE để chấm;5 không ghi DAMAGE,3 thiếu typed response và2
chưa ACK vẫn được giữ trong mẫu,không trở thành nhãn0.

| Mục | Reference | Guarded |
|---|---:|---:|
| Mẫu component được chấm | 6/8 | 1/8 |
| Độ phủ trên8 mẫu component | 75% | 12,5% |
| MAE | 127,67 | 0 |
| RMSE | 221,13 | 0 |
| Sai số lớn nhất trong tập này | 383 | 0 |
| Độ phủ khoảng min/max học được | 5/6 | 1/1 |
| Khoảng rộng trung bình | 328,29 | 383 |

MAE trung bình theo trận của reference cũng127,67; mỗi chiều chấm3 mẫu.
Guarded chỉ chấm BASIC turn11 từ model học ở trận R.0 sai số trên1 mẫu
không chứng minh chất lượng hoặc an toàn. Guard chỉ kiểm miền từng chiều;
một tổ hợp nằm trong hộp min/max chưa chắc đã từng xuất hiện trong tập học.

Reference xuất9 forecast số trên18 request:6 có nhãn chấm được,3 không
đủ nhãn;2 request thiếu nhóm trực tiếp đã học và7 không có Kiếm trong quét
đầu thì từ chối. Guarded xuất1 forecast; ngoài2+7 lý do trên,có8 request
bị từ chối vì ngoài miền. Các số request và component không cùng mẫu số.

Hai artifact có nhóm passive3 mẫu mỗi fold. Model học từ R còn thấy2
mẫu ăn Kiếm trực tiếp,nhưng chưa qua ngưỡng3 nên không dùng chúng để dự
đoán. Không pool damage trực tiếp với quét Demon để tăng độ phủ giả.
Không nạp tỷ lệ median đã học thành công thức damage của game.

## Điều học được từ sai số

Hai forecast reference bị dư383:

| Mẫu | Khiên boss trước nước | Reference | DAMAGE ghi được | BLOCK liền trước DAMAGE |
|---|---:|---:|---:|---:|
| BASIC turn3 | 1915 | 267393 | 267010 | 383 |
| Suy luận turn13 | 1532 | 152796 | 152413 | 383 |

Cả hai còn có một BLOCK sớm hơn,đưa Khiên xuống383. Sai số bằng BLOCK383
liền kề là quan hệ số học/thứ tự trong log,chưa xác minh quan hệ nhân quả
hoặc subtype damage. Trừ toàn bộ Khiên trước nước không khớp cả hai mẫu.
Không gán BLOCK trước đó cho Hút/nội tại khi thiếu bằng chứng,không lấy
BLOCK quan sát sau nước đưa vào predictor trước nước.

Kết quả này chỉ ra một hướng offline cụ thể: tách tương tác với Khiên và
thứ tự effect trước khi cố tăng độ phủ hoặc suy damage từ số Kiếm. Bản
thử nghiệm chính và forecast đã đóng băng không bị sửa theo nhận xét này.

## Kiểm chống rò rỉ và hồi quy

- 198 test tập trung PASS,gồm14 test baseline mới. Kiểm nộ/khiên/kiếm ngoài
  miền,scope/regime khác,5 viên mục tiêu,x7,thiếu/censor/không ACK,request
  trong tập học,hash/authority và toán học bằng dữ liệu tổng hợp.
- Hai fold tách match/board,model chỉ tính tham số từ TRAIN. Đổi mọi nhãn
  và fullPower ở VALIDATION vẫn giữ nguyên tham số,training digest và
  forecast của cả hai mode trên18 request thực. SHA dataset/model có thể
  đổi do metadata pin đã đổi;không gọi toàn bộ artifact là giống byte.
- Model/request/forecast được ghi và pin hash trước thao tác chấm metric.
  Điều đó chứng minh thứ tự xử lý offline,không chứng minh predictor chưa
  từng thấy kết quả game trong quá trình nghiên cứu trước đây.
- Hai model chính được tái hiện đúng.4 lần fit trong bộ nhớ phục vụ kiểm
  tái hiện/poisoning được ghi riêng,không cộng thành dữ liệu/trận/model mới.
- Source trước07cceab0,sau
  `df80f92606cd33e53a7420cb167b7fd37c8c31e8a033d9ffbb729dffb1381555`
  (489 Python). Chỉ thêm module/tool/test;486 file cũ nguyên byte. Mọi
  reader/collector/BASIC/adviser/PASS/input và dữ liệu/profile cũ giữ nguyên.

Mốc này có fit thử nghiệm cục bộ;chưa train value/ranker hoặc thay thuật
toán chọn nước.0 trận/input/attach mới,tổng30 lượt đã đóng,còn0. Không build.
UI23260 là trạng thái cuối ở mốc live trước,không kiểm lại trong đợt này.

## Dùng lại và bước tiếp

Chạy từ thư mục gốc V2,output mới trong V2:

```powershell
python tools/run_damage_baseline.py --plan docs/phase5/artifacts/damage_baseline_20261121/experiment_plan.json --out-dir temp/reasoning/damage_baseline_replay
```

Bước predictor nhỏ đã hoàn tất. Chưa đủ để đưa bộ ước lượng này vào tool.
Tiếp theo có thể kiểm riêng decomposition của BLOCK/DAMAGE và các trạng
thái bị từ chối từ chính log đã có. Không nới gate theo sai số của hai trận,
không cần mở trận mới để nghiệm thu helper offline. Holdout độc lập và
ngữ cảnh đầy đủ vẫn là phần riêng trước khi cân nhắc triển khai live.

[Plan đã chốt](artifacts/damage_baseline_20261121/experiment_plan.json),
[hai model và kết quả](artifacts/damage_baseline_20261121/experiment/summary.json),
[từng mẫu có nhãn](artifacts/damage_baseline_20261121/eligible_prediction_review.json),
[phân tích Khiên](artifacts/damage_baseline_20261121/shield_error_review.json),
[audit](artifacts/damage_baseline_20261121/audit.json),
[kiểm tra cuối](artifacts/damage_baseline_20261121/final_verification.json).
