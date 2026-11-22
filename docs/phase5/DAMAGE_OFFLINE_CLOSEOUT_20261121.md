# Demon — rà hết dữ liệu damage hiện có và chốt phần cần chơi mới

Ngày 21/11/2026. Đã hoàn tất phần offline có thể kiểm chứng từ corpus hiện
có. Source mới `d699a5acabb36fe4892fb6766caae3789801a39133116abe839f129549e72f30`
có492 file Python:488 file cũ nguyên byte,1 file capture thay đổi,3 file thêm.
Planner, reader, executor và rule PASS giữ nguyên. Chỉ bổ sung metadata vào
JSON tool đã đọc; predictor thử nghiệm chưa tham gia chọn nước.

**Điểm cần dữ liệu mới:** log cũ không giữ `crit` trong `BOSS_HP`/`STAT_CHANGE`;
không thể khôi phục việc có/không chí mạng, hoặc nguyên nhân từng component,
bằng cách xem lại bàn trước nước. Logger mới cũng chưa được kiểm native.
Đã chuẩn bị [bài kiểm kế tiếp](artifacts/damage_offline_closeout_20261121/next_collection_plan.json),
chưa mở cap, tool hoặc trận mới. Tổng dữ liệu live đã đóng vẫn30 lượt thử,
còn0; đợt này0 trận/input/attach/build mới.

## Corpus mở rộng và kết quả không thuận lợi

Rà28 bản `prepared.json`, chọn26 file combat chính từ26 trận đã đóng, cùng
B17 và Demon560. Mỗi file phải khớp SHA trong closure, source đã đóng,
account ownership và run/attempt. Hai bản setup không tạo trận bị loại;
không lấy bản sao archive làm mẫu mới, không lọc theo damage hoặc thắng/thua.
Đây là dữ liệu lịch sử đã xem, không phải26 trận vừa chơi hay holdout độc lập.

| Loại | Số lượng |
|---|---:|
| Cohort khai báo, còn giữ ranh giới source/account/chữ ký stats |13|
| SWAP có pre-input đủ trường |223|
| Có ACK / chưa ACK |197 /26|
| ACK có recorded DAMAGE component / không ghi DAMAGE |93 /64|
| ACK thiếu typed response |40|
| PASS giữ riêng khỏi damage |3|
| Trùng hoặc xung đột action trong bộ mẫu |0|

64 response không ghi DAMAGE không được điền thành0 sát thương;40 thiếu
typed và26 chưa ACK không thành nhãn dự đoán. Các khai báo pet/đồ hiện có
không chứng nhận đầy đủ loadout tại từng effect.
[Manifest](artifacts/damage_offline_closeout_20261121/historical_manifest.json),
[nguồn gốc](artifacts/damage_offline_closeout_20261121/historical_provenance.json),
[bộ mẫu](artifacts/damage_offline_closeout_20261121/historical_dataset.json).

Giữ nguyên policy của [baseline trước](DAMAGE_BASELINE_20261121.md): không
tuning, không hạ tối thiểu3 mẫu, không trộn trực tiếp với quét Demon hay
trộn source khác để tăng độ phủ. Đóng tất cả plan trước fit. Chạy25 fold
theo trận trong từng cohort; cohort chỉ1 trận không có validation. Có87
recorded targets trong25 trận được kiểm, reference chấm34 và guarded13.
Đây là25 artifact thử, không phải25 lần nghiệm thu mô hình độc lập. Không
gộp MAE của các cohort khác nhau thành một chất lượng chung.

Kết quả quan trọng: cohort `demon_reader_trace_native_20261119` có2 dự đoán
guarded nằm trong miền min/max của ba feature cũ nhưng MAE181.771, sai số
lớn nhất248.619,5. Do đó miền support hiện tại không đủ bảo đảm dự đoán tốt,
không dùng baseline để quyết định kết liễu hoặc chọn nước. Hai trận c509
mới nhất vẫn tái hiện reference6/8, MAE127,67; guarded1/8, không xóa kết quả
xấu ở cohort cũ vì kết quả mới đẹp hơn.
[Từng cohort và metric](artifacts/damage_offline_closeout_20261121/historical_baseline_summary.json).

## Đã kiểm Khiên, thứ tự effect và nhiều đợt phá

Audit ghép đúng sample, action line, response sequence và raw SHA. Trong223
action có180 sequence typed để xem sau response, gồm cả action chưa ACK;
chỉ93 target ACK ở trên được dùng làm recorded DAMAGE label. Có128 sequence
tag khớp effective first-wave,52 khác;43 sequence có nhiều DESTROY. Có26
sequence BLOCK,22 có toàn bộ chữ ký STAT_CHANGE Khiên khớp duy nhất và giữ
thứ tự.13 cặp BLOCK–DAMAGE liền kề chỉ là liên tiếp trong danh sách, không
chứng minh cùng một đòn hoặc nguồn damage.

Hai lỗi383 ở c509 đều bằng BLOCK383 ngay trước DAMAGE. Điều đó chưa chứng
minh phải cộng383 vào target hoặc trừ tổng Khiên trước nước: sequence còn
BLOCK khác. Giữ nguyên ledger, label, weights và forecast đã đóng.
[Audit sequence](artifacts/damage_offline_closeout_20261121/damage_sequences.json).

Hai sai số lớn ở `M_763be023`,turn1/7: first-wave dự kiến4 Kiếm nhưng tag
response ghi7 Kiếm, cả hai có DESTROY24+3+3. DAMAGE lần lượt267.393 và
401.090 trong khi baseline152.470,5. Response/action binding và native SWAP
không cho thấy lấy nhầm action; phép lật hàng quan sát khớp ở hai mẫu này
chỉ là chẩn đoán, không cấp thêm quyền input hoặc thay transform runtime.
Vì thiếu crit/subtype, nguyên nhân chênh lệch401.090 vẫn UNKNOWN.

Kiểm lại solver trước nước trên223 action:42 có match tồn dư đã biết,32 có
rủi ro auto-Sword qua một ô refill. Riêng turn1 lệch lớn có0 match tồn dư,
0 rủi ro một ô nhưng24 ô refill chưa biết. Không thấy hazard một ô không
loại trừ ghép do nhiều viên mới. Không đưa actual refill/tag/DAMAGE sau
response vào feature trước nước hoặc gọi nó là dự báo.
[Rà support trước nước](artifacts/damage_offline_closeout_20261121/pre_input_support_review.json).

## Reverse mới xác minh được và thay đổi capture

Pinned B17 GameAssembly SHA
`bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`,
script SHA `0eee9df46fa34079c356e7f558586b57e4b4c4638d7bf5d86207745f024505bc`.
`ApplyOp.MoveNext` gọi `ApplyBossHp` cho BOSS_HP. `ApplyBossHp` đọc
`newHP`,`delta`,`crit`; `ApplyStatChange` đọc `crit` ở nhánh HP âm. Đây là
client đọc dữ liệu effect, không phải công thức damage của server. DTO
vẫn khai báo `dmgSrc +0x38`, `fullPower +0x40`; projector cũ đọc đúng khóa
`dmgSrc`, không có bằng chứng server đổi tên trường đó.
[Địa chỉ/call đã kiểm](../il2cpp_symbols.md),
[bytes và string refs](artifacts/damage_offline_closeout_20261121/damage_operation_static.json),
[ApplyBossHp](artifacts/damage_offline_closeout_20261121/ApplyBossHp.asm),
[ApplyStatChange](artifacts/damage_offline_closeout_20261121/ApplyStatChange.asm).

`damage_operation_context.py` chiếu tùy chọn từ `matchPayload.ops` đã có:

- BOSS_HP: `delta`,`newHP`; STAT_CHANGE: `delta`,`newValue`,`statType`,
  `source`,`reason`,target đã hash. Chỉ giữ key hiện diện; không lưu tên thật.
- `crit_presence` phân biệt ABSENT/NULL/BOOL/UNVERIFIED_TYPE. `crit_value`
  chỉ có bool nguyên gốc. Không biến missing hoặc client ReadBool default
  thành false, không lưu giá trị tùy ý khi sai type.
- Match/sequence/type/raw SHA cùng response; giữ operation index, actor
  identity nếu hợp lệ. Không ghép crit vào combat step theo suy đoán.
- Tối đa32 record/4KB, giữ tổng effect+player context+metadata trong32KiB.
  Metadata lỗi/quá giới hạn được INVALID/OMITTED hoặc bỏ riêng; effect và
  player context cũ có ưu tiên. Không phát sinh memory query, offset,
  pointer chain, thay đổi cadence, action hoặc PASS.
- Chỉ là quan sát sau response, `calibration_eligible=false`,
  `input_authority=false`, `step_attribution=UNKNOWN`. Normalizer/model cũ
  chưa dùng trường mới. Logger chưa kiểm native, không tuyên bố đã thu crit.

210 kiểm tra tập trung PASS, gồm12 kiểm tra mới. Bản source trước được
phục hồi và xác minh SHA; toàn bộ function cũ trong module capture giữ AST
(public projector chuyển thành helper giữ nguyên body).31 fixture đối
chiếu với module cũ giữ nguyên mọi trường ngoài `damage_operations`, kể cả
UNAVAILABLE/rejection và lỗi optional.28 observation native c509 normalize
giữ nguyên. Hash raw/provenance, profile, preferences và artifact trước còn
nguyên.488 file cũ khác nguyên byte; không rebind profile hoặc mở lại cap.
[Kiểm tra](artifacts/damage_offline_closeout_20261121/tests.txt),
[audit](artifacts/damage_offline_closeout_20261121/audit.json).

## Chỗ dừng và bước kế tiếp

Đã khai thác dữ liệu cũ đủ để bác bỏ việc dùng baseline hiện tại. Chưa thể
chứng minh công thức Khiên/crit/fullPower hay định lượng đường refill bằng
dữ liệu đang thiếu. Thêm fitting trên các mẫu đã xem không lấp được chỗ
trống đó. Mega/Galaxy vẫn để sau Demon theo thứ tự đã chọn.

Bài kiểm đề xuất: **tối đa1 BASIC rồi1 Suy luận**, cùng Solo Priest131,
Demon Aegis thường ăn Khiên, ngưỡng4 Kiếm hiệu dụng và đồ giữ nguyên. Đây
là kiểm logger/response mới; không nhằm chứng nhận mô hình qua hai trận.
Phải đọc lại build/source/room/pet, tạo case/cap mới và làm control/qualification
đúng source; không sửa profile cũ để bỏ gate. Plan chỉ là đề xuất, chưa có
claim hoặc lượt thử mới được mở.

Nếu crit không hiện hoặc không có nhiều đợt phá, giữ UNKNOWN và đóng đúng
giới hạn, không chạy thêm để săn một sự kiện hiếm. Sau đó audit response
thực tế trước khi thiết kế mô hình mới. Độ tốt của adviser tiếp tục dựa vào
BASIC và Suy luận trên cùng bàn trước nước, không lấy số lượt/thắng làm
counterfactual. Còn cần bộ kiểm độc lập được pin trước khi fit/đổi mô hình.

Artifact nghiên cứu được giữ nguyên byte với
[bản đồ archive](artifacts/damage_offline_closeout_20261121/artifact_map.json).
Đường dẫn scratch bên trong plan/forecast cũ là provenance của lần chạy;
dùng bản đồ này để tìm bản lưu, không viết lại hoặc coi bản sao là mẫu mới.
