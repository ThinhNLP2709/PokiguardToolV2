# Dữ liệu phục vụ ước lượng damage/skill — 17/11/2026

## Bổ sung kiểm thực tế — 18/11/2026

Đường thu đã được kiểm bằng source ở hai trận BASIC, mỗi trận có cap1 riêng.
Lieyun77 thắng1/1 sau1 nước, có1 batch/5 bước, gồm DAMAGE127330 nhưng là đòn
kết trận. Lion Star105 thắng1/1 sau8 nước, nhận thưởng/về phòng và dừng đúng
target, không technical abort/recovery. Có14 batch/37 bước, ghép duy nhất được
phản hồi với7/8 nước của ta theo actor, match và khoảng srvSeq; nước kết trận
không thu được callback outcome. Không có echo tọa độ wire trong các record.

Hai mẫu damage chưa kết trận của Lion Star có SWAP ACK và khớp phép trừ HP:

| Lượt nguồn | HP boss trước → sau trong batch | DAMAGE | BLOCK riêng | fullPower |
|---|---|---:|---:|---|
| 9 | 252795 → 88539 |164256|870|true|
|11 | 288908 → 61415 |227493|3451|true|

Đây là số server đã báo của các nước đã đi, không phải dự đoán cho nước chưa
đi. `damage_source` còn null; fullPower thiếu ở record khác không được đổi
thành false. Bổ sung chuẩn hóa18/11: cả6 loại viên của hai vùng quét khớp
ledger hiệu dụng, gồm5/7 Kiếm từ4/6 viên thật; phạm vi chỉ hai nước đã kiểm.
[Đối chiếu chi tiết](COMBAT_NORMALIZATION_20261118.md).
Hai điểm trên đủ làm quan sát offline, chưa đủ fit hoặc cấp model cho
pet/boss/loadout khác. Không suy damage từ HP ở lượt ta kế tiếp, vì trạng thái
boss có thể đổi trong khoảng lượt boss. Scorer chưa dùng một công thức mới.

[Đối chiếu Lion Star](artifacts/combat_outcome_live1_20261118_002040/review_lionstar_43150383/review.json).
Các mục dưới là báo cáo offline trước hai trận kiểm này, giữ nguyên phạm vi
theo thời điểm ghi nhận.

Đã hoàn tất audit dữ liệu hiện có và bổ sung đường ghi bằng chứng chỉ đọc từ
JSON phản hồi tool đã lấy sẵn. **Chưa fit hoặc bật bộ ước lượng damage trong
adviser.** Không lấy chênh lệch HP hay WIN để tự gán sát thương cho một nước.
Scorer và bộ chọn nước của bản 1.3.6 giữ nguyên trong đợt này.

## Dữ liệu thật hiện có

[Audit 401 combat log](artifacts/combat_outcomes_20261117/current_logs_audit.json)
gồm 400 trận Demon ăn Khiên và 1 trận Galaxy. Có 1.034 quyết định kèm chỉ số
hai bên, 626 SWAP ACK, 6 đề xuất/dispatch skill và 401 terminal snapshot.
Không có record từng bước `combatSteps` đủ nguồn trong các file này.

HP tại quyết định kế tiếp có thể đã đi qua lượt boss; HP terminal có thể bị
cắt ở 0 hoặc phản ánh lý do kết trận khác. Các giá trị đó không tách được damage,
heal, shield, phản đòn hoặc các wave. Vì vậy số model fit hiện tại là **0**,
lý do `NO_ATTRIBUTED_SERVER_STEPS`. Không đưa mốc damage của một pet/account
thành hằng số dùng chung.

## Chỗ thu dữ liệu đã bổ sung

`DispatcherTransportTap` vốn đã đọc JSON bất biến từ callback và parse
`matchPayload`. Đường mới chỉ chiếu các trường từ object Python đó; không
thêm RPM, không đọc thêm stats, không scan, không gọi game method hay network.
Decoder bàn cờ và quyền chấp nhận action không phụ thuộc phần chiếu này.

- MOVE/CARD/SKILL có board: `combatOutcome` được gắn vào event
  `dispatcher_board_snapshot_offered` khi board được provider chấp nhận.
  Bằng chứng phải gắn đúng instance snapshot đang được offer, MatchId và srvSeq.
- Skill không có board, gồm trường hợp Galaxy: ghi event
  `dispatcher_combat_outcome` từ đúng JSON response đã decode cho match hiện tại.
  Record đánh dấu `accepted_board_attached = false`; nó không phải ACK, không
  cấp quyền action và không được coi là đã chứng minh một board sau skill.
- Giữ `kind`, `source`, `target`, `amount`, `dmgSrc`, `fullPower`, `idx`,
  `after`, destroyed tags, display total, ID thẻ nếu có và tọa độ wire nếu hợp lệ.
  Tên người chơi trong actor/source/target được hash, giữ được phép so sánh
  identity mà không ghi thêm tên vào record này.
- Không gộp DAMAGE từ BOARD_DOT với nguồn khác, HEAL, chi phí hoặc transfer.
  `fullPower` thiếu vẫn là null; tổng display thiếu không bị đổi thành 0.
  Khóa `after` được giữ nguyên, chưa diễn giải thành HP/Mana/shield cụ thể.
- `wire_turn` không được gán thành lượt nguồn của ta: payload có thể mô tả
  người chơi kế tiếp. Audit loại duplicate outcome theo match/seq/event/actor,
  báo conflict khi payload hash khác, không nhân số mẫu bởi callback trùng.

Các record đều có `calibration_eligible = false`, coverage hiệu ứng toàn action
`UNKNOWN` và `input_authority = false`. Trước khi fit phải ghép đúng action,
ACK, source/target, wave, game build, pet/thẻ, loadout và trạng thái hai bên;
đồng thời kiểm số bước bị mất/trùng. Đợt này không mở đường dùng model chưa
hiệu chuẩn trong adviser hoặc sửa profile cũ để vượt gate.

## Giới hạn và cách lỗi

- Tối đa 128 bước/batch; mỗi record tối đa 32 KiB.
- Map giữ tối đa 128 record và queue boardless tối đa 128 record; có thể giữ
  khoảng 8 MiB payload trong trường hợp xấu nhất, cộng overhead Python.
- Mỗi checkpoint hiện có lấy tối đa 2 record boardless. Chạm giới hạn có record
  `UNAVAILABLE`; không xóa bộ đếm guard của game hoặc chờ để thu đủ dữ liệu.
- Sai type, bool giả int, stale match/seq, idx trùng/đảo thứ tự hoặc payload
  quá lớn: bằng chứng là `INVALID`, không phải board/action thất bại.
- Fault khi projection/export/drain chỉ làm mất bằng chứng, không ném lỗi lên
  controller. Không thêm retry click, native input, sleep hoặc polling.

## Bằng chứng reverse và kiểm chứng

B15 và B16 có cùng 9 field managed của `WsCombatStepDTO` và 8 field managed
của `WsCombatBatch`. [Đối chiếu có SHA-256](artifacts/combat_outcomes_20261117/static_field_evidence.json).
Tên field không chứng minh công thức server, tính đầy đủ của wave hoặc wire
schema live. B16 raw steps và lượng hiệu ứng thực còn **chưa kiểm live**.
Runtime mới không thêm offset/RVA để đọc các DTO này.

226 kiểm tra liên quan PASS, gồm parser/correlation, card/skill không board,
queue/record cap, callback reuse, thiếu dữ liệu, fault injection, reset session,
typed actor/amount, controller/ACK, input lease, Galaxy và setup adviser.
[Log test](artifacts/combat_outcomes_20261117/focused_tests.log).

AST của `basic_auto_bot.py` giữ nguyên ngoài checkpoint offer/log diagnostics.
SHA của planner, tactics, BASIC policy, bộ đọc, input, pet skill executor,
FarmRunner và version khớp baseline trước thay đổi.
[Receipt](artifacts/combat_outcomes_20261117/verification.json).
1000 phép chiếu JSON giả lập 3 bước: p50 0,066 ms, p95 0,089 ms, max 0,410 ms;
đây không phải latency toàn farm hoặc hiệu chuẩn timing native.

## Điểm chốt

Source đã sẵn sàng ghi dữ liệu mới ở lần test tiếp theo. ZIP 1.3.6 đã bàn giao
trước đợt này không có phần ghi mới; chưa build, mở tool hoặc chạy trận mới.
Sau khi có record thật, chạy audit và kiểm attribution trước khi xây khoảng
ước lượng damage/heal. Không tuyên bố AI đã biết trước damage hoặc tự học từ
log hiện tại.

```powershell
python -B tools/audit_combat_outcomes.py --logs logs/farm_runs --out temp/reasoning/combat-outcome-audit-new.json
```
