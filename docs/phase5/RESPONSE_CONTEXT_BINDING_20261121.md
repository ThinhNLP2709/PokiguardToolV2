# Ngữ cảnh pet gắn với đúng phản hồi của game

Đã bổ sung thu ngữ cảnh từ JSON tool đang đọc và công cụ ghép offline với
đúng response/nước đã gửi. Đây là bước chuẩn bị dữ liệu cho ước lượng damage;
chưa thay đổi cách chấm hay chọn nước, chưa fit mô hình.

## Cách thu và giới hạn

`combat_outcome_evidence.project_combat_outcome` giữ thêm `player_context`
tùy chọn, lấy từ chính envelope đã qua kiểm match/sequence/type/hash.
Không thêm lần đọc process, theo pointer hoặc thay collector/reader. Projection
effect cũ giữ nguyên thân hàm trong `_project_combat_effects`.

Reverse B17 xác minh nhánh JSON thô của `ParsePlayersSnapshot` ưu tiên
`players` khác null; chỉ khi thiếu/null mới dùng `playersStateDelta`. Logger
giữ tên khóa nguồn và phân biệt `REPLACE_DICTIONARY` với `MERGE_PLAYER_DELTA`.
Đây là nhãn nhánh nguồn, không phải bằng chứng client đã merge xong hoặc mọi
field của profile đều đầy đủ. Không replay quy tắc default/merge của client.

Các field được giữ nếu thật sự có trong JSON:

| Nhóm | Field raw |
|---|---|
| Chỉ số | actorNumber, hp/hpMax, mana/manaMax, power/powerMax, attack, shield |
| Pet | petId, petElementType, petLevel, petStar, petBtLevel, petBtMax |
| Avatar/trang bị | avatarId, weaponImageId, weaponRarity, weaknessVsBoss, equipCounterPct |
| Tiến hóa | fusionUsedSuccess, fusionBonusHp, fusionBonusAttack, fusionBonusMana |

Không cộng thêm attack pet/avatar, giải thích thứ tự mảng khắc hệ, suy crit,
buff hoặc điền field vắng. Thiếu khóa, null, 0, false và chuỗi rỗng là các
trạng thái riêng. Tên actor được hash theo phép ánh xạ hiện có; không ghi tên,
user ID, display name hoặc avatar layers. Dictionary key/username trái nhau
làm context INVALID, không làm mất effect đã hợp lệ.

Giới hạn16 actor,4096 byte context; payload effect + context vẫn không quá
32768 byte. Khi quá ngân sách, lược context trước và giữ nguyên effect/
fullPower-presence. Lỗi context chỉ tạo diagnostic giới hạn kiểu lỗi; không
đổi kết quả xác thực effect/board, quyền input hoặc gây dừng gameplay vì
context không có. Mọi trường hợp thiếu context vẫn là UNKNOWN.

## Ghép dữ liệu offline

`tools/bind_response_player_context.py` dùng normalizer sent/ACK hiện có,
không sửa normalizer. Khóa là match + sequence + event + SHA JSON thô.
Context actor/mục tiêu chỉ lấy theo đúng identity trong chính response đó.
Response UNAVAILABLE có thể giữ context nhưng không được biến thành
CAPTURED effect hoặc nước đã ACK khi thiếu bằng chứng typed effect.

Hai bản sao thiếu/omitted context không làm mất bản CAPTURED của cùng
response trong file. Hai bản CAPTURED khai khác nhau bị cách ly context;
effect vẫn do normalizer cũ kiểm riêng. Tổng hợp nhiều file loại trùng và
cách ly identity có semantic conflict, bỏ qua khác biệt số dòng vật lý.

**Ngữ cảnh của response không được gọi là ngữ cảnh trước nước hoặc tại lúc
gây damage.** Cả `pre_action_context` và `effect_time_context` luôn null;
`calibration_eligible`, `training_eligible`, `input_authority` luôn false.
Không ghép theo thời gian gần nhất, carry-forward delta hoặc lấy probe mở
đầu trận áp dụng cho các lượt sau. Client còn có nhánh dữ liệu pre-parsed;
việc thấy khóa JSON không xác nhận nhánh runtime nào đã chạy.

Ví dụ chạy từ thư mục gốc V2, đọc file đã lưu và ghi một output mới:

```powershell
python tools/bind_response_player_context.py --combat "duong-dan-combat.jsonl" --out "temp/reasoning/context_check/output.json"
```

## Kiểm chứng

Source trước `28fa103c4eeac3662505da2b429e5224c2c73abfd6aad9c4e0f3ace01d752cc9`,
source sau `c50977f870de8717cf57db2cc5639f7bf978f8f3fb4549b59c86064b210d0c7c`
(483 Python). So với mốc bắt đầu: đổi1 file cũ, thêm module/công cụ/test;
479 file cũ giữ nguyên byte, gồm BASIC/adviser/planner/PASS/input/reader/tap.

- 169 test tập trung PASS, gồm15 test context mới: exact binding, thiếu/null,
  budget, context lỗi, UNAVAILABLE, duplicate conflict, không carry-forward,
  không thêm memory query và không đổi board disposition.
- AST thân projector effect cũ và các helper giữ nguyên;27 fixture đối chiếu
  cả3 response type giữ đúng status/reason/identity/effect sau khi bỏ riêng
  field context mới. Fixture là tổng hợp, không phải bằng chứng native.
- 130 file combat lịch sử,90 SHA file khác nhau:533 observation tính cả bản
  sao giữ normalization cũ chính xác. File thô giữ nguyên. Không có context
  mới trong các log này; số context ghép được là0, không điền lại từ probe.
- Benchmark riêng projection trên JSON tổng hợp đã parse,2 actor/1000 mẫu:
  median41,8µs, p9547,6µs. Đây không phải latency reader/input hoặc số đo native.

[Audit và hash dữ liệu](artifacts/context_snapshot_binding_20261121/audit.json),
[khai báo field đã đối chiếu](artifacts/context_snapshot_binding_20261121/static_dto.json),
[nhánh native đã disassemble](artifacts/context_snapshot_binding_20261121/static_labels.json),
[đối chiếu fixture](artifacts/context_snapshot_binding_20261121/projection_differential.json),
[kiểm tra cuối](artifacts/context_snapshot_binding_20261121/final_verification.json).

## Điểm chốt

Mốc offline này hoàn tất;0 trận/input/attach mới, tổng28 lượt đã đóng, còn0.
Không train/build hoặc đổi preferences/profile/cap cũ. Proof native gần nhất
vẫn thuộc source28; source mới chưa được nghiệm thu native. UI14420 dừng1/1
là trạng thái quan sát ở mốc trước, không được kiểm lại trong đợt offline này.

Khi có log mới, cần kiểm field nào thực sự xuất hiện trong response và giữ
đúng phase/ownership của nó trước khi xét hiệu chuẩn. Nếu JSON không chứa
đủ dữ liệu thì ghi UNKNOWN; không dùng after-state làm feature trước nước.
Damage/crit/buff/formula và holdout vẫn chưa đủ để nạp predictor vào adviser.
Không cần mở trận ngẫu nhiên chỉ để điền các field còn thiếu.
