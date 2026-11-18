# Dữ liệu outcome chung — 18/11/2026

Theo yêu cầu xử lý việc cũ trước, đã hoàn thành một mốc offline của nhánh
dữ liệu effect/damage. Đề xuất learned outcome/value/ranker được ghi vào
[backlog](RESEARCH_BACKLOG_20261118.md) với trạng thái
`QUEUED_AFTER_OLD_WORK`; chưa training hoặc đổi lựa chọn nước đi.

## Đã làm

`tools/normalize_action_outcomes.py` đọc log đã lưu, không yêu cầu style
Demon hoặc kích hoạt nội tại. Nó giữ batch/actor/sequence, từng effect theo
thứ tự, nguồn/đích, damage source, fullPower, lượng báo và raw after.
DAMAGE, BLOCK, HEAL, SHIELD, MANA, POWER và STEAL được tách riêng. Không
dùng chênh HP đơn thuần để gán sát thương, không cộng block vào HP damage.

Chỉ giao thức SWAP sent/ACK hiện có được nối thành nguồn hành động đã xác
nhận: đúng match/actor/source sequence, khoảng dòng và lần gửi duy nhất,
không có response cạnh tranh, ACK khớp toàn bộ identity. Action thuộc loại
khác vẫn chặn cửa sổ nối. Skill/card chỉ là typed observation chưa có
binding đã kiểm; boss không được gán `LastMove` của ta. Duplicate callback
được gộp; identity xung đột bị loại. Thiếu dữ liệu giữ UNKNOWN.

So sánh arithmetic raw after là giả thuyết kiểm sổ, không phải công thức
server. Gain được báo và gain thực tế khác nhau khi chạm trần; overkill/HP=0
bị censor. STEAL chưa rõ after thuộc bên nhận hay bên mất nên không tự
chuyển số đó sang baseline của bất kỳ bên nào. Mọi observation vẫn
`calibration_eligible=false`, `training_eligible=false`, `prediction=null`.

Runtime chỉ đổi module ghi bằng chứng `combat_outcome_evidence.py`:

- Giữ trường `stealType` đã có trong DTO B16; trước đây trường này bị bỏ.
  Thiếu trường trong log cũ không được suy diễn lại thành Mana/Nộ.
- Giữ mọi op `SWAP` trong `matchPayload.ops[].data`, kèm index và tọa độ
  native. Chưa chọn một op làm quyết định boss, chưa đổi `wire_swap` cũ,
  chưa tự ánh xạ sang nhãn hành động hoặc tạo board trước nước boss.
- Projection bounded tối đa128 ops, vẫn chịu giới hạn capture32KiB và
  retention hiện có. Malformed optional evidence chỉ làm mất evidence;
  test xác nhận board hợp lệ vẫn được đưa tới controller, không thêm RPM.

Không đổi solver, BASIC, adviser, reader, input, QTE, PASS, farm hay version.
Không đọc/ghi tiến trình hoặc phát input trong mốc này.

## Kết quả trên dữ liệu có sẵn

Đầu vào là đúng12 `combat.jsonl` của hai cohort B16 đã đóng, chọn theo
manifest SHA, không quét lẫn bản sao log trong timing profile.

| Kết quả | Số lượng |
|---|---:|
| Batch outcome duy nhất |137|
| Có nguồn SWAP sent + ACK khớp |62|
| Có nguồn sent nhưng thiếu ACK khớp |12|
| Batch boss chưa nối nguồn hành động |63|
| Exclusion / duplicate |0 /0|
| Skill dispatch trong các cohort này |0|

Có397 effect: POWER69, DAMAGE72, STEAL51, MANA64, HEAL62, SHIELD48,
BLOCK31.193 arithmetic checks khớp raw delta,12 có dạng chạm trần,5 có
dạng chạm0;136 UNKNOWN và51 transfer chưa diễn giải. Đây không phải397
mẫu độc lập hoặc193 mẫu đã đủ để fit damage.

Đối chiếu35 observation Demon cũ cho kết quả giống hệt, gồm eligibility và
exclusion. Không sửa byte nào của normalizer Demon cũ. Toàn bộ11 observation
có `POWER_LEDGER_MISMATCH` chứa pattern chạm trần trong phân tích mới.
Ví dụ `M_13d40762`, seq24: trước220, báo cộng140, after250, delta30.
Pattern này giải thích thiếu sót của phép cộng thẳng ở mức quan sát; chưa
chứng minh đầy đủ công thức, chi phí fullPower hay thứ tự mọi hiệu ứng.
Không nới điều kiện hiệu chuẩn chỉ để tăng số mẫu.

Tất cả137 batch cũ thiếu projection ops mới;51 STEAL thiếu `stealType`.
Không thể khôi phục các trường đó từ file đã mất dữ liệu gốc. Không thấy
tọa độ boss trong log này không có nghĩa client không nhận tọa độ boss.

## Reverse B16 và giới hạn nguồn boss

Kiểm binary chỉ đọc, pin SHA của `GameAssembly.dll`, `script.json`, `dump.cs`:

1. `MatchService.ParseOps(ChatMessageDTO)`, RVA `0xBA7220`, dùng preOps
   khi có, nếu không đọc `matchPayload +0x128`.
2. Overload dictionary RVA `0xBA72E0` đọc key `ops`, chuyển sang danh sách
   `MatchOpDTO`. DTO có type `+0x10`, data `+0x18`.
3. `ApplyOp.MoveNext`, RVA `0xB2E640`, nhánh literal `SWAP` gọi
   `BoardWsApplier.ApplySwap` tại RVA `0xB2EAF1`.
4. `ApplySwap`, RVA `0xB154F0`, đọc fromCol/fromRow/toCol/toRow từ
   `op.data +0x18` qua `ReadInt`. Projection không dùng fallback0 của client
   cho key thiếu và không coerce string/bool thành tọa độ.

Đây là bằng chứng đường client, chưa là một nước boss quan sát được. Nguồn
board trước nước boss, ánh xạ coordinate, actor binding, các op phụ/cascade
và complete refill vẫn cần kiểm với capture thực tế. Không thêm pointer
chain hoặc gán LastMove đang thuộc nước ta thành nước boss.

## Kiểm chứng và danh tính

186 test PASS: typed normalization, normalizer Demon, optional evidence,
dispatcher/tap/chat roots, common snapshot/selection, provider baseline và
bounded-future. Bao gồm malformed/bounded data, duplicate/conflict, sai
ACK/actor/session/sequence, terminal/cap, unknown transfer và optional
projection hỏng vẫn trả board mà không thêm memory read.

Đây là suite liên quan tới thay đổi, không là tuyên bố toàn bộ test repo
đã sạch.3 lỗi projection/ancestry lịch sử đã ghi ở backlog vẫn chưa sửa.

- Trước: `9b4a21096f4efccc630039b790508f5f0a296bbd4cc0e4d9661b94fa7c36cb27`.
- Hiện tại: `923813c6c7d95863e2973f50d4a632eb084425c1d673f5a491d034e71f7554fb`.
- Thay đổi source chỉ4 file: optional evidence, tool offline mới và2 test.
  Frozen source manifest chứng minh các module gameplay/input khác giữ nguyên.
- Live proof9b4 vẫn thuộc đúng source/cohort cũ, không rebind profile hay
  gọi đó là live cho projection mới.0 native attempt,0 build ở mốc này.

Tái hiện: chạy `python -B docs/phase5/artifacts/common_outcomes_20261118/audit.py`.
Audit kiểm SHA đầu vào và parity35 observation cũ trước khi tạo lại corpus.
Static audit: `audit_b16_ops.py`, dùng pefile/capstone sẵn dưới
`temp/b16_dependencies`; chỉ mở binary đọc. Tool dùng chung:
`python -B tools/normalize_action_outcomes.py --combat <file> --out <new-file-inside-V2>`.

[Audit và danh tính source/input](artifacts/common_outcomes_20261118/audit.json),
[summary](artifacts/common_outcomes_20261118/summary.json),
[corpus](artifacts/common_outcomes_20261118/observations.json.gz),
[static native evidence](artifacts/common_outcomes_20261118/boss_move_static.json),
[test log](artifacts/common_outcomes_20261118/focused_tests.log).

## Những việc cũ còn mở

Đường chuẩn hóa chung đã dùng được ở mức quan sát. Skill sent/ACK binding,
damage/heal định lượng theo pet/loadout/build và nguồn quyết định boss/refill
chưa hoàn thành chỉ bằng việc có exporter. Dữ liệu đang audit có0 skill và0
mẫu calibration-eligible; thiếu context/buff/khắc hệ, không có outcome của
những nước không chọn. Không fit predictor hoặc value/ranker bằng nhãn WIN
gán cho mọi nước trong trận. Nhánh learned model tiếp tục ở sau các thiếu
hụt cũ này; capture các trường đã xác minh giúp lần thu log sau không lặp
lại việc mất `stealType`/ops. Chưa mở một phiên live mới.
