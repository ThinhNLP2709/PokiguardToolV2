# Rà log skill Mega và nguồn Galaxy — 23/11/2026

Đã hoàn thành bước inventory/binding log offline theo
[checklist Mega/Galaxy](MEGA_GALAXY_CHECKPOINT_REVIEW_20261123.md).
Baseline khi bắt đầu: `5c887b77`. Chỉ thêm công cụ audit, kiểm thử và bằng
chứng; không sửa runtime, plan Opus, DECISIONS, mở game/tool, chơi thêm,
fit model, build hoặc commit. Các file đang được agent core sửa giữ riêng.

**Bước tiếp theo đã triển khai offline:**
[đường thu và binding skill](ACTIVE_SKILL_CAPTURE_BINDING_20261123.md),
474 CI PASS; source mới chưa native. Inventory lịch sử dưới đây giữ nguyên.

## Kết quả chính

| Nhóm | Kết quả primitive được giữ | Có đúng một click, đúng thẻ/chi phí và controller result | Số dư Mana/Nộ nhất quán ở lượt ngay sau |
|---|---:|---:|---:|
| Mega Icarus | 19 trong 8 trận | 19 | 12 |
| Mega T-Rex | 112 kết quả thành công trong 7 trận | 112 | 105 |
| Galaxy G2, trận `M_65f4e402` | 6: 5 SUCCESS_NO_ACTION và 1 INVALIDATED | 5 | 0 |
| Thẻ đã thành UNKNOWN trước input, có dấu vết thử T-Rex | 4 INVALIDATED | 0 | 0 |

**Mega có 131 log cast nối được click–thẻ–chi phí–kết quả primitive, với
117 endpoint tài nguyên đủ điều kiện kiểm nhất quán.** Đây là quan sát đã
được game/provider đọc lại, không phải 131 phản hồi server đã được quy hiệu
ứng, mẫu damage đủ hiệu chuẩn, hoặc nhãn nước tối ưu.

Tìm 159 file primitive trong `logs/`, `docs/` và Downloads/log; loại 18 bản
sao byte-identical. Trong 141 nội dung duy nhất có 3 file ngoài nhóm
Mega/Galaxy click-only. Còn 138 file phù hợp, chứa 141 kết quả do 3 file
ghi nối tiếp hai lần thử. Ghép với 16 combat log. Không có JSON lỗi hoặc
hai bản nội dung khác nhau tranh cùng action identity trong kết quả này.

Mọi mẫu cast Mega giữ được ở inventory này thuộc route **pet thường → Mega**.
Hai giá quan sát là Icarus 200 Mana/150 Nộ và T-Rex 200 Mana/200 Nộ;
không biến chúng thành giá cố định của pet/build khác. Không coi route
Mega chính → pet thường đã được đo chỉ từ các log này.

## Nối được những gì

Audit chỉ nhận bằng chứng khi:

1. Primitive result có action ID, match, session, lượt nguồn và card ID.
2. Capability mới nhất **trước click** cùng session/card, CURRENT, đúng
   owner, actionable, có nguồn chi phí. Một lần đọc UNKNOWN/đổi thẻ sau
   đó sẽ vô hiệu bằng chứng CURRENT cũ.
3. Có đúng một event click cùng toàn bộ action ID; result báo đúng một
   click, không Arrow/Space, hoàn tất click-only.
4. Controller result giữ chính action ID đó; dispatch start cùng source
   identity và đúng card/cost/resources trước click. Ghép bằng identity và
   thứ tự start/result, không chỉ timestamp hoặc tên file.
5. Endpoint tài nguyên chỉ nhận khi cùng session/match, turn = nguồn + 1,
   đúng local participant và telemetry khớp snapshot Mana/Nộ. Snapshot
   muộn qua lượt boss, thiếu turn hoặc chỉ còn state UNKNOWN không được bù.

Ba trường hợp T-Rex cùng source turn 129/157/141 có INVALIDATED, zero input
rồi lần thử sau thành công. Audit tách chúng theo action ID và ranh giới
result/start; không tính lần zero input thành cast hoặc coi hai start cùng
source là hai lần click trùng. Bốn result UNKNOWN/zero input và một G2
INVALIDATED vẫn được giữ để review, không trộn vào các mẫu thành công.

## Không khôi phục được damage/heal từ tập log này

- 154 hash đầu vào, 169 đường dẫn/bản sao đã được xác minh SHA; quét lại cho
  kết quả inventory byte-for-byte tương đương về dữ liệu.
- Có 36 event `dispatcher_board_snapshot_offered` loại MATCH_SKILL_USE_RES
  trong các combat log liên quan. Chúng chỉ giữ metadata như srvSeq và
  accepted; không có body `combatSteps`, actor/card/effect đầy đủ để quy
  damage/heal cho một hành động. Không gọi đây là “không có phản hồi skill”.
- Không file đầu vào nào trong manifest giữ `combatSteps` hoặc
  `combatOutcome`. Cờ `server_response_correlated` của các primitive không
  cung cấp xác nhận hiệu ứng riêng. Không nối metadata bằng độ gần thời gian.
- 13 cast Mega không có turn sau đầy đủ trong post-state, thêm 1 T-Rex có
  post-state vẫn cùng lượt; giữ ngoài nhóm 117 endpoint. Chúng không tự trở
  thành bug hoặc thất bại skill chỉ vì thiếu endpoint phù hợp.
- 5 click G2 có post-state vẫn cùng lượt, Mana/Nộ vẫn như trước click. Chưa
  có bằng chứng giải quyết chiêu trong chính các post-state đó; không suy
  thành 5 skill đã gây damage hay kết luận bug từ log cũ này.

Tài nguyên ròng không phải chi phí thẻ. Ví dụ T-Rex `M_91294d21`/155:
cost 200/200, trước 10.611 Mana/250 Nộ, sau 10.843/10, net +232/-240.
Nhiều cast khác tăng Mana hoặc chạm trần. Chưa có thứ tự effect để tách
cost, ăn viên, tiêu Nộ, hồi hoặc transfer; không gán cơ chế cho chênh lệch.

Vì vậy **0 mẫu mới được cấp quyền fit/predict damage trong gameplay**.
Không lấy HP ở lượt kế tiếp hoặc WIN để điền phần server chưa được giữ.

## Galaxy lịch sử còn dùng được đến đâu

Fixture `tests/fixtures/galaxy_glank_20261115/replay.json` vẫn giữ 37 state:
35 G2 và hai state skill G1/G3, có hash combat nguồn. Mô tả G1/G3 cũng
được giữ riêng trong fixture ngày 16/11. Các dữ liệu này còn dùng được
cho replay/cơ chế/nhận diện thẻ.

Đã tìm theo SHA trên 571 file `combat.jsonl` trong ba root nói trên;
không tìm được full combat trùng ba hash G1/G2/G3 của fixture. Đây là kết
luận trong phạm vi quét, không phải tuyên bố log đã bị xóa ở mọi nơi.
Trận G2 `M_65f4e402` còn nguyên primitive là một run khác; không gộp nó với
G2 `M_c543da74`. Fixture không thay full trace để chứng minh vòng thứ tư
G1, chuỗi ba pha G3 hay kết quả resource/damage của từng skill.

Checkpoint/config ghi intelligence=basic không tự chứng minh không có
worker R: các bài Icarus 5D.4 từng gắn authority ngoài field cấu hình này.
Audit chưa phân loại lại execution mode; nghiệm thu R lịch sử giữ theo
closure riêng, không dùng bộ đếm skill này làm bằng chứng nâng chất lượng.

## Đầu vào cho agent nâng lõi chung

Có thể dùng ngay offline:

- 131 join Mega và 117 endpoint làm regression cho cost/identity/resource
  accounting; giữ cả zero input, retry, thiếu turn và cùng turn làm negative.
- 37 state Galaxy cùng mô tả/nguồn thẻ làm regression chiến thuật; giữ nhãn
  fixture lịch sử, không gọi là holdout độc lập hoặc rollout live mới.
- Danh mục route/thẻ/source còn thiếu để lập bài live có mục tiêu sau này.

Đường thu/binding skill mới cần giữ: source action/session/actor/card,
effective costs và nguồn trước click; response event/match/actor/card/srvSeq;
ordered combatSteps/after/damage source và phần thiếu/trùng; phase/owner
trước skill, loadout/build/source cùng coverage/cap. Ưu tiên projection từ
callback/JSON đã đọc; không thêm RPM hoặc gọi game method để bù dữ liệu.
Metadata accepted hoặc log ghi SUCCESS không được thay chứng cứ effect.

Phần này là dữ liệu cho U2/U5/U6 và rollout U10/U11 của plan chung; không
đưa một planner, admission hoặc policy khác vào runtime song song.
**Chưa cần lặp thêm trận để tăng số lượng.** Bước thiếu đã rõ là capture và
binding effect skill; chỉ mở live riêng khi đường thu sẵn sàng và có câu
hỏi kiểm chứng rõ.

## Tái hiện và kiểm chứng

- [Công cụ audit](../../tools/audit_active_skill_inventory.py).
- [Inventory và manifest](artifacts/active_skill_inventory_20261123/inventory.json).
- [Verification/SHA và các hash Galaxy chưa tìm thấy](artifacts/active_skill_inventory_20261123/verification.json).
- [Script xác minh độc lập hash và chạy lại inventory](artifacts/active_skill_inventory_20261123/verify.py).
- 22 kiểm thử attribution/dedup/negative PASS, gồm stale/foreign card,
  zero input, duplicate click/result, cost UNKNOWN, changed resources,
  late turn, retry và bản sao cùng action.

```powershell
python -B -m unittest tests.test_active_skill_inventory -v
python -B docs/phase5/artifacts/active_skill_inventory_20261123/verify.py
```
