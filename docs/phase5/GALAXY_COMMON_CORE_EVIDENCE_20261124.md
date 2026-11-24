# Galaxy — chốt dữ liệu offline và ranh giới live

**G4 mới cuối 24/11:** [ba trận đã chốt](GALAXY_G4_NATIVE_REASONING3_20261124.md),
9 pre-state và response local, 2 nước đổi/7 giữ BASIC branch replay. Giữ
6 ACK và 3 terminal không ACK; có mẫu 20 viên/21 đơn vị hiệu dụng.
G1/G3/G4 đã đủ mỗi nhóm ba trận. G4 chưa có CommonProblem profile; fixture
riêng được bàn giao để agent lõi thêm adapter, không ép alias sang Galaxy.

**Cohort G1/G3 mới cuối 24/11:**
[G1 ba trận Genbu](GALAXY_G1_NATIVE_REASONING3_20261124.md) và
[G3 ba trận Argilpus](GALAXY_G3_NATIVE_REASONING3_20261124.md) đã chốt.
G3 thêm ba context pha runtime 1/3, hai response cost/refund và 22 cặp
resource BASIC/R trên cùng bàn. Còn G4 ba trận trước bàn giao. Các số
inventory và trạng thái UNKNOWN của corpus cũ phía dưới giữ theo thời điểm;
không đổi thành nghiệm thu common worker hoặc phủ hết vòng pha Galaxy.

**G2 Suy luận mới đã chốt 24/11:** [native và so cùng bàn](GALAXY_G2_NATIVE_REASONING1_20261124.md),
1 WIN, 16 SWAP/ACK, ba response skill. Nhánh per-pet được xác minh thực
chạy; 7/16 SWAP đổi so với replay resource BASIC, 9 giữ, có một case giữ
thêm 4 Khiên hiệu dụng. Đây chưa phải rollout common worker hoặc nghiệm
thu G1/G3/route tiến hóa; không fit damage model từ các mẫu cùng boss.

**Cập nhật live cuối 24/11:** [G2 BASIC collector mới đã WIN 1/1](GALAXY_G2_NATIVE_BASIC1_20261124.md),
18 SWAP/ACK, ba fresh context và một ordered response có cost/refund/damage;
hai response còn thiếu, binding vẫn UNBOUND. Đã lưu thêm ba CommonProblem
native có nguồn riêng; không sửa cohort lịch sử dưới đây hoặc coi đó là
nghiệm thu common worker. Phiên một trận Suy luận G2 riêng đã chuẩn bị.

24/11/2026, Asia/Saigon. Đã xử lý phần Galaxy còn dùng được từ corpus cũ,
theo cùng schema CommonProblem với Icarus/T-Rex. Không sửa cách đánh,
solver, weights, reader, input, PASS, profile hoặc rollout. Không mở tool,
đọc game, đổi account, chơi thêm, fit model, build, commit/push. Plan và
các file của agent phụ trách lõi chung giữ nguyên.

## Kết quả

| Nhóm nguồn | Dùng được | Phạm vi |
|---|---:|---|
| Fixture Galaxy lịch sử | 37: G1 1, G2 35, G3 1 | Board, stats, nước đã ghi; thiếu full trace/card/config/session |
| G2 `M_65f4e402` | 5 trạng thái trước click skill | Ghép đúng primitive/controller, thẻ và chi phí thực 200 Mana/200 Nộ |
| G2 zero input | 1 INVALIDATED | Negative reference, không tính thành skill đã bấm |
| Replay common cùng bàn | 42 | 11 giữ skill opaque, 31 chọn SWAP |
| Skill effect/pha native đủ nguồn | 0 / 0 | Không có ordered combatSteps hoặc chuỗi pha đủ nguồn |
| Kiểm thử | 599/599 PASS | Gồm 22 kiểm mới và hồi quy Galaxy/G1/G2/G3/decoder pha |

Trong 31 baseline SWAP có 12 giữ nước, 19 đề xuất khác; classifier cơ học
ghi 17 TRADEOFF và 2 CONDITIONAL_MECHANICAL_ADVANTAGE. 11 incumbent skill
được giữ do hiệu ứng chưa được mô hình hóa. Không dùng các bộ đếm này làm
nhãn nước tối ưu, chất lượng Suy luận hoặc tỷ lệ thắng.

**Đây là baseline đã ghi so với common replay**, không tự đổi tên thành
UI BASIC so với UI Suy luận: fixture không giữ execution mode, còn full
trace G2 có `galaxyReasoningEnabled=true` dù config `intelligence=basic`.
Năm click này thuộc nhánh chiến thuật Galaxy riêng, không phải bằng chứng
UI đã chạy common worker. Các nhận định “chưa live” trong tài liệu 15–16/11
được giữ theo thời điểm; audit này chỉ bổ sung phạm vi trace thực tìm thấy.

## Không khôi phục điều chưa từng ghi

Full combat gốc của ba hash G1/G2/G3 trong fixture chưa tìm được trong
phạm vi inventory trước đó. Exporter giữ hash tham chiếu, dùng SourceRecord
trỏ fixture thực và đánh dấu session/match/config/card/cost UNKNOWN. Board
hash ở đây là semantic, không giả làm hash raw runtime. Không lấy mock
capability/cost 200/200 của test cũ điền vào snapshot lịch sử.

Riêng năm click G2 có card/cost/session thật trước click, route Galaxy
chính, không tiến hóa, Tự bảo vệ “Không”. Post-state primitive vẫn cùng
lượt và cùng Mana/Nộ; 0 endpoint đạt điều kiện inventory. Có các event
resolving/turn-resolved về sau nhưng không có combatSteps để tách trừ cost,
hồi Mana, damage, buff/giáp. Không kết luận skill đã gây damage, không
kết luận click là lỗi, không suy lượng damage từ HP boss ở lượt sau.

Pha G1/G3 giữ UNKNOWN. Một snapshot turn17/13 không chứng minh pha1,
lần thứ tư, vòng ba chiêu, buff còn hạn hoặc sát thương ấn tích lũy. Mô tả
thẻ vẫn là tri thức cơ chế, không phải một kết quả RNG hay phần hồi được
ứng trước. Không cộng hồi máu Icarus cho Galaxy.

## Điều cần bàn giao cho lõi chung

**Skill Galaxy opaque không được biến thành mask rỗng hoặc damage 0.**
EffectChoice giữ `cleared=null`, support UNKNOWN. Common planner giữ
incumbent chưa mô hình hóa; không thắng một phép so bằng cách bỏ hiệu ứng
skill khỏi phép tính. Đây cũng chưa phải quyết định “skill luôn tốt hơn”.

**Khiên G2 vừa có thể bảo vệ bản thân vừa có giá trị khi còn trên bàn.**
Exporter đếm physical/effective và ghi số Khiên đã biết còn lại sau mỗi
nước SWAP, chưa cộng refill. Ví dụ fixture G2 turn9: baseline giữ 17 Khiên
hiệu dụng, common đề xuất còn 10. Lợi ích thu thêm Health/Rage phải cân
với mất Khiên cho skill; không gọi thu nhiều Khiên là lợi ích thuần.

Turn39 có đánh đổi khác: known Sword reply 10 → 0 và Khiên giữ lại 8 → 14,
nhưng vẫn có chi phí tài nguyên khác, refill/damage/buff UNKNOWN. Turn15
giảm known Sword reply 5 → 0 nhưng tiêu Nộ qua ăn Kiếm có thể trái chủ trương
tích skill. Các case này là đầu vào để agent lõi kiểm U1/U5/U6, không phải
lý do sửa weights hoặc tự thay nhánh Galaxy đang hoạt động.

Lõi common hiện dùng objective Galaxy chung; chưa có utility riêng cho
Khiên G2 hay vòng G1/G3. UI vẫn dùng GalaxyReasoningSession riêng. Việc
hợp nhất, fire/hold và rollout thuộc plan canonical, không tạo lõi thứ hai
trong đợt chuẩn bị dữ liệu này.

## Bằng chứng và kiểm lại

- [Exporter](../../tools/prepare_galaxy_core_evidence.py).
- [22 kiểm thử mới](../../tests/test_galaxy_core_evidence.py): pre-state,
  card/cost/owner/session/route, conflict, opaque skill, không rò future,
  không đoán pha/refund và đánh đổi Khiên G2.
- [Fixture 5 G2 click rút gọn](../../tests/fixtures/galaxy_core_20261124/cases.json),
  đã bỏ plaintext username, không tái tạo authority từ fixture.
- [Evidence pack 42 case](artifacts/galaxy_core_evidence_20261124/evidence_pack.json),
  [verification](artifacts/galaxy_core_evidence_20261124/verification.json),
  [script tái hiện](artifacts/galaxy_core_evidence_20261124/verify.py),
  [CI transcript](artifacts/galaxy_core_evidence_20261124/ci_final.log).
- [Rà lịch sử và bài live kế tiếp](MEGA_GALAXY_LIVE_READINESS_20261124.md).

Các case không cấp training/input authority; chưa fit hoặc nạp công thức
damage/heal vào gameplay. Các nhóm Icarus, T-Rex và Galaxy giữ cohort riêng.

```powershell
$env:PYTHONPATH = 'src'
python -B -m unittest tests.test_galaxy_core_evidence -v
python -B docs/phase5/artifacts/galaxy_core_evidence_20261124/verify.py
```
