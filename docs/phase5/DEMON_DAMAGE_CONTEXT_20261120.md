# Demon: dữ liệu sát thương và ngữ cảnh còn thiếu

Đã hoàn tất phần offline của việc rà ngữ cảnh damage/heal: bổ sung giữ
key-presence của `fullPower` và thêm công cụ kiểm độ sẵn sàng từ log. Chưa
fit hoặc nạp mô hình sát thương vào adviser. Cách chọn nước giữ nguyên.

## Thay đổi đã làm

Projection giữ thêm `steps[].full_power_presence` từ chính JSON bất biến mà
tap đã đọc, sau các kiểm tra match/sequence/type hiện có:

| Giá trị | Ý nghĩa |
|---|---|
| `ABSENT` | JSON không có khóa `fullPower` |
| `NULL` | Có khóa, giá trị `null` |
| `VALUE` | Có khóa, giá trị boolean; `full_power` giữ đúng `true` hoặc `false` |
| Không có metadata | UNKNOWN về key-presence; có thể là log cũ hoặc không đủ ngân sách |

Không biến thiếu/null thành false, không suy ngưỡng Nộ hoặc chi phí từ cờ.
Metadata chỉ được giữ nếu cả evidence vẫn vừa32768 byte. Nếu không vừa,
giữ nguyên toàn bộ evidence cũ; không biến một capture hợp lệ thành lỗi chỉ
vì metadata mới. Không tăng số bước, số operation hoặc hạn mức lưu.

Normalizer kiểm tính nhất quán của metadata. Hai bản sao cùng response có
effect giống nhau vẫn gộp được nếu một bản thiếu metadata do ngân sách;
metadata có nguồn được giữ lại. Hai bản khai presence trái nhau, hoặc
amount/identity khác nhau, tiếp tục bị loại như conflict. Log cũ không bị
điền lại presence. Không thay contract sent/ACK hoặc cơ chế bind nước.

`tools/audit_demon_damage_context.py` đọc log file, dùng exact SWAP binder
hiện tại và giữ chỉ số ta/boss, geometry quét đầu, DAMAGE/HEAL component,
trạng thái fullPower và các lý do chưa thể hiệu chuẩn. Nó kiểm ownership
stats, loại trùng response, giữ terminal/censor và không gọi component vắng
là0. Cấu hình pet thường/tiến hóa/viên mục tiêu chỉ là khai báo, không được
đánh tráo thành pet/loadout runtime đã chứng minh. Công cụ không đọc game,
gửi input, dự đoán hoặc train.

## Rà dữ liệu đã lưu

128 file combat có88 SHA file khác nhau, thuộc nhiều đợt lịch sử; không phải
128 trận mới. Chuẩn hóa510 observation tính cả các bản sao giữ nguyên đúng
kết quả trước thay đổi. Sau gộp theo identity, báo cáo Demon có:

| Mục | Số lượng |
|---|---:|
| Quan sát của ta duy nhất | 263 |
| Trận lịch sử có quan sát | 39 |
| Có exact SWAP sent/ACK | 227 |
| Xác định được quét đầu theo cơ chế Demon đã khai báo | 136 |
| Có đủ tám chỉ số số học ở cả ta và boss | 263 |
| DAMAGE component ta→boss được giữ | 158 |
| Trong đó full_power=true từ projection cũ | 136 |
| full_power=None cũ, không phân biệt thiếu/null | 22 |
| Quan sát có mục tiêu HP0, cần giữ censor | 36 |
| Mẫu được công nhận đủ để fit | 0 |

Các count có chồng nhau.39 trận thuộc kiểm kê lịch sử, không thay số26 lượt
thử của mốc đang theo dõi. Không có conflict identity trong tập này. Dữ liệu
đã được xem nên không phải holdout độc lập.

52 nhóm theo chỉ số số học/quét đầu được giữ để kiểm giả thuyết, không là
52 loadout đã xác minh. Ví dụ cùng4 Kiếm vật lý/hiệu dụng, công ta1819,
HP tối đa109491, công boss580,HP tối đa361136,Nộ đầu≥100 vẫn ghi DAMAGE
131405 hoặc164256. Điều này chưa chứng minh nguyên nhân là Nộ/crit/cascade;
chỉ cho thấy không được gán một hệ số damage cố định từ số Kiếm và stats đó.
Các HP0 trong nhóm vẫn có nhãn censor. Không đưa after-state vào feature
trước nước, không dùng WIN/số lượt/utility làm nhãn tối ưu.

## Reverse B17 cho biết gì

`dump.cs` xác nhận khai báo `WsCombatStepDTO.fullPower` là bool tại+0x40.
`Active.PlayerStats` có attack+0x74, weakness+0x98,equipCounter+0xA0 và
petData+0xA8. `PetUserDTO` có petId+0x1C,elementType+0x40,attack+0x5C và
weaknessValue+0x68. Đây là khai báo field, chưa xác minh ownership/lifetime,
giá trị runtime, ý nghĩa damage hoặc chuỗi pointer mới.

Reader hiện xuất HP/Mana/Nộ/công/Khiên và dừng vùng đọc ở0xA8; chưa theo
petData hoặc equipCounter, chưa xuất weakness. Không mở rộng reader trong
mốc này. Crit/buff/khắc hệ đầy đủ tại lúc gây damage và cách server áp dụng
chúng vẫn UNKNOWN. Không cộng attack avatar+pet lần nữa khi chưa biết
attack đang đọc đã tổng hợp những phần nào.

## Kiểm chứng và giới hạn

Source trước `b0b524b17f774914c526624864a511390823790d56af06db556e5ea952e8c83c`.
Source sau `28fa103c4eeac3662505da2b429e5224c2c73abfd6aad9c4e0f3ace01d752cc9`
(480 Python). Chỉ đổi projection trong `combat_outcome_evidence.py`, kiểm
metadata/gộp duplicate trong `normalize_action_outcomes.py`; thêm công cụ
audit và12 test.476 file Python cũ còn lại nguyên byte, bao gồm reader,
BASIC/adviser/planner,owner,PASS,executor và log nhánh Máu vừa chốt.

154 test liên quan PASS, có kiểm ngân sách, false/null/absence, duplicate,
exact board export không thêm truy vấn bộ nhớ, ownership, censor và
normalization.24 fixture projection giữ status/reason/identity/effect cũ
sau khi bỏ đúng metadata mới.128 file thực giữ normalization cũ. Đây là
kiểm tập trung, không tuyên bố cả suite dự án xanh.

Không attach,không input,không trận mới,không train/build.26 lượt thử cũ đã
đóng, còn0. Proof/profile native source61 giữ nguyên; source mới chưa được
kiểm trực tiếp. Không sửa log cũ hoặc gắn bằng chứng native của source cũ
cho source mới.

## Điểm dừng và phần thực sự còn thiếu

Phần offline này đã đóng. Chơi thêm nhiều trận trên logger cũ không phục
hồi được22 trường None và không tự bổ sung được context crit/buff/loadout.
Trước khi thử fit, cần:

1. Kiểm logger mới trên game ở một mốc live riêng, giữ build/source/account/
   pet/boss/đồ rõ ràng. Kiểm ghi presence và capture/nhận thưởng/về phòng;
   không chạy bù ngẫu nhiên nếu nhánh Máu hiếm chưa xuất hiện.
2. Xác minh nguồn và ownership cho pet/khắc hệ/buff/crit hoặc giới hạn bài
   đo vào context có thể xác nhận. Khai báo field trong dump không đủ để
   tự thêm reader hoặc coi dữ liệu thiếu là0. Hiện cần một lần đối chiếu
   runtime có kiểm soát, không cần người dùng farm hàng loạt ngay.
3. Chốt phạm vi mô hình, tiêu chí sai số và các trận mới dành riêng để kiểm
   trước khi xem kết quả. Mẫu thiếu context/censored nằm ngoài tập fit;
   nếu chưa đủ nguồn thì predictor phải trả UNKNOWN.

Chưa mở training, chưa chuyển sang Mega/Galaxy. Công việc tiếp theo cần
game/context runtime; không có thêm phép sửa offline nào có thể khôi phục
những field chưa từng được ghi trong log hiện có.

[Audit và SHA đầu vào](artifacts/demon_damage_context_20261120/audit.json) ·
[Kiểm kê ngữ cảnh](artifacts/demon_damage_context_20261120/context_cases.json.gz) ·
[Các nhóm mô tả](artifacts/demon_damage_context_20261120/descriptive_strata.json) ·
[Khai báo reverse](artifacts/demon_damage_context_20261120/static_context.json) ·
[Kiểm cuối](artifacts/demon_damage_context_20261120/final_verification.json).
