# Định danh response thiếu hiệu ứng và xuất lại dữ liệu offline

Đã sửa việc mất định danh khi projection trả UNAVAILABLE và kiểm lại dữ
liệu đã thu, không mở game/tool, attach process hoặc chạy thêm trận.

Native source trước vẫn pin:
`7a6503d4c93cc7f0e5d552cd03604d445253ea06e58636d056b0df9dcb6bb13a`.
Source mới sau sửa:
`f595bdb51359394b31a812699b6dc7864893780cc501dfa78373b9dfc7e969ac`.
Metadata mới chưa có native-log proof; integration và replay offline đã qua.

## Lỗi và bản sửa

`project_combat_outcome` trước đây trả UNAVAILABLE ngay khi không có
`combatSteps`, bỏ match/type/sequence/hash khỏi capture. Khi drain qua
`dispatcher_combat_outcome`, event chỉ còn match/lifecycle; normalizer
không đủ căn cứ để biết exclusion thuộc khoảng nào và loại mọi interval.
Đây là lỗi làm mất phạm vi ở khâu thu/xuất dữ liệu chẩn đoán, không phải
nguyên nhân bỏ lượt hoặc safe stop trong trận vừa test.

Sau khi envelope qua match/sequence fence và có raw SHA hợp lệ, capture
không thành công giữ thêm `response_identity`: match ID, event type,
server sequence, raw SHA và provenance cố định. Nó có `effect_evidence=false`,
`input_authority=false`; không có steps, damage, actor name hoặc địa chỉ.
CAPTURED payload giữ nguyên byte. Sai fence/hash không được cấp identity.
Queue dùng identity này để đánh dấu delivery của metadata UNAVAILABLE.

Normalizer nhận identity ở event drain cùng match/lifecycle hợp lệ. Nếu
có field ngoài hoặc board scope, chúng phải đồng ý; dữ liệu mâu thuẫn
vẫn không được cấp phạm vi. Event nằm giữa hai boundary vẫn chặn interval,
kể cả khi sequence tự nhận ở ngoài. Identity chỉ định vị phần bị thiếu,
không nâng UNAVAILABLE/INVALID thành CAPTURED.

## Log cũ được đối chiếu bằng điều kiện nào

Log BASIC đã đóng không có field mới. Normalizer chỉ đối chiếu trường
hợp cũ khi toàn bộ phiên có accounting đủ và khớp duy nhất:

- Một summary đã dừng, đã clear session, không pending; published states
  thuộc một match/lifecycle/board session hợp lệ.
- Capture index bounded, không drop/fault/conflict hoặc lỗi JSON không
  xác định phạm vi. Mỗi observation có immutable raw hash và exact reader
  binding cùng trace; không có duplicate key hoặc ticket phiên cũ.
- Số emission khớp số observation. Mọi CAPTURED emission phải qua validator
  và khớp identity/hash/status/reason của một observation riêng, có delivery.
- Phần còn lại chỉ gồm UNAVAILABLE vì absent/empty combatSteps. Mỗi nhóm
  status/reason có đúng một emission và một observation chưa dùng; tất
  cả key của index đều phải được đối chiếu. Duplicate, thiếu hay nhiều
  candidate làm đối chiếu thất bại. Identity mới sai không được fallback.

Không dùng timestamp gần nhất, thứ tự dòng đơn thuần, HP hoặc mô phỏng
để suy sequence hay tạo effect. Log thiếu các điều kiện trên tiếp tục
fail-closed. Giới hạn đối chiếu này được ghi bằng
`UNIQUE_COMPLETE_CAPTURE_METADATA_ACCOUNTING`, khác căn cứ accepted board
và explicit response identity.

## Kết quả trên dữ liệu đã có

Ở `M_d9edcf8b`, accounting13 emission/13 observation đầy đủ:12 CAPTURED
khớp hash và1 UNAVAILABLE duy nhất COMBAT_STEPS_ABSENT. Phần còn lại nối
được response4/lifecycle1, nằm ngoài cả7 boss interval bắt đầu từ seq4
trở đi. Exclusion gốc ở dòng23 vẫn còn nguyên NOT_CAPTURED_OBSERVATION.

| Dữ liệu trong phiên BASIC + R mới nhất | Trước sửa | Sau sửa |
|---|---:|---:|
| Boss interval BASIC hợp lệ | 0 | 7 |
| Boss interval R hợp lệ | 4 | 4 |
| Resource interval BASIC hợp lệ | 0 | 11 |
| Resource interval R hợp lệ | 7 | 7 |
| Typed response | 21 | 21 |
| Capture exclusion | 1 | 1 |

Resource audit mới có18 khoảng:78 reported delta khớp,2 mẫu cap/floor,
51 lastStat khớp endpoint. Ba khoảng thiếu published boundary vẫn bị loại.
Đây là chứng cứ quan sát, không phải mô hình hoặc nhãn nước tối ưu.

Replay **123 archived combat file**: chỉ1 file có thêm7 boss interval;
không mất interval cũ, raw SHA, published state, retained board và capture
exclusions giữ nguyên. Raw log, closure và profile native cũ không đổi.
Response4 vẫn thiếu effect; hai response BASIC8/24 vẫn không có scoped
observation. Không khôi phục ba effect thiếu hoặc điền dữ liệu giả.

## Kiểm và giới hạn

**154 test PASS**, gồm fence/hash, absent/empty/rejected/invalid,
boardless queue delivery, identity mâu thuẫn, in-range emission, ambiguous
residual, thiếu/trùng index hoặc output, sai session/ticket, unclosed
summary, malformed JSON và resource consumer giữ gap.

72 projection fixture giữ nguyên status/reason/effects khi bỏ riêng field
identity mới. AST projector và tap khớp baseline sau khi loại hook metadata;
các hàm normalize chính và luật chặn interval không đổi. Chỉ sửa3 file
source có trước và thêm1 test;472 file source khác giữ nguyên byte, gồm
reader/RPM/cadence, BASIC, adviser, PASS và input.

Cap cũ vẫn đóng2/2, tổng21; đợt này0 trận/attach/input/train/build. Không
rebind profile7a sang sourcef595. Tool/UI cũ nếu còn mở vẫn thuộc source7a,
không là native acceptance của metadata mới trên đĩa.

Phần offline mất phạm vi đã đóng. Bước nghiên cứu sau có thể dùng18
resource interval và mẫu quét Demon đã bind để xét số dư/chi phí, giữ
damage/order chưa chứng minh là UNKNOWN. Mega/Galaxy tiếp tục hoãn.

[Kiểm source, AST và replay](artifacts/unavailable_identity_20261120/verification.json) ·
[123 file đã kiểm](artifacts/unavailable_identity_20261120/corpus_replay.json) ·
[Boss interval xuất lại](artifacts/unavailable_identity_20261120/latest_after_boss.json) ·
[Resource audit trước/sau](artifacts/unavailable_identity_20261120/resource_replay.json).
