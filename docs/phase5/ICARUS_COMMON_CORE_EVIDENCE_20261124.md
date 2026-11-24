# Icarus — dữ liệu và regression cho lõi suy luận chung

24/11/2026, Asia/Saigon. Đã xử lý offline dữ liệu ba trận BASIC và chuẩn bị
đầu vào dùng ngay với lõi chung hiện tại. Không mở trận, đọc game, đổi
policy/weights, fit model, cập nhật profile, build hoặc commit/push. Plan và
tài liệu của agent phụ trách lõi không bị sửa.

## Phần đã hoàn thành

| Hạng mục | Kết quả |
|---|---|
| Đầu vào trước skill | 7 `CommonProblem` đúng schema hiện hành; gồm board/actor/stats/settings/cost và ấn Icarus |
| Biên nhận hiệu ứng riêng | 7 receipt giữ các bước theo thứ tự; 4 liên hệ client-card có điều kiện, 3 terminal UNBOUND |
| Đếm vùng phá | 7/7 vùng DESTROY đầu tiên khớp đúng 30 ô registry Icarus |
| Kiểm trừ chi phí | 14/14 phép trừ Mana/Nộ trước DESTROY khớp cost đã đọc |
| Ledger STAT_CHANGE | 63 phép tính khớp trực tiếp; 10 pattern chạm trần, không gọi gross gain là net |
| Endpoint local | 28/28 HP/Mana/Nộ/Khiên khớp snapshot trong cùng response |
| Replay cùng bàn | 7/7 lõi hiện tại giữ incumbent skill; không phải kết luận nước tối ưu |
| Sensitivity giả lập | 28 ca cùng bàn: HP 25%, HP đầy, thiếu Mana, thiếu Nộ; nhãn SYNTHETIC riêng |
| Kiểm thử | 20 kiểm chuyên biệt; tổng focused CI 500 PASS |

Nguồn native vẫn là `fbf861fd…`, pet thường → Icarus trên No.11 lv185.
Nội dung raw phải khớp manifest closure trước khi exporter chạy. Không trộn
run F9 trước đó, dữ liệu Demon, G4 hoặc T-Rex vào cohort này.

## Kiến thức rút ra để lõi chung dùng đúng

**Chi phí và số dư ròng là hai khái niệm khác nhau.** Phản hồi giữ khoản
trừ 200 Mana/150 Nộ trước DESTROY, rồi các thay đổi do thu tài nguyên, Hút,
chạm trần và `FULL_POWER`. Cả 7 packet có operation ghi FULL_POWER -100;
đây là quan sát của cohort, chưa là luật được áp cho mọi pet, boss hoặc
mọi lần đánh. Ví dụ một operation báo +260 Nộ nhưng số dư chỉ tăng +150
vì chạm trần; giữ cả hai số thay vì fit một hệ số từ net delta.

**HEAL và LIFESTEAL phải tách theo nguồn.** Trong 7/7 packet, operation
đối chiếu với LIFESTEAL ghi `FUSION_LIFESTEAL`. Không chuyển nhãn đó thành
khả năng hồi của mọi Mega hoặc skill Icarus thuần. HEAL riêng, LIFESTEAL
riêng, và không có công thức dự báo lượng hồi được nạp. Số HP hiện tại so
với max HP vẫn là đầu vào trước skill; lượng hồi quan sát nằm ở receipt sau.

**Vùng ấn đã có bằng chứng thực nhưng tổng hậu quả chưa hoàn tất mô hình.**
DESTROY đầu khớp registry cả 7 packet. Có packet có thêm DESTROY tiếp theo;
multiplier/tag trong operation vẫn UNKNOWN. Số viên trước nước, số viên
hiệu dụng trong ấn và tổng tài nguyên/kiếm sau cả skill không được coi là
cùng một đại lượng. Không đưa refill quan sát vào nhánh swap giả định.

**Thiếu card ID server vẫn giữ thiếu.** Bốn case client-window dùng được
để nghiên cứu và regression liên kết yếu có điều kiện; cả bảy packet vẫn
không có strict wire-card proof. Ba terminal giữ UNBOUND, kể cả khi phép
tính cost/endpoints tình cờ khớp. Receipt UNBOUND ghi rõ arithmetic là giả
thuyết candidate; không nâng thành mẫu hiệu chuẩn hoặc nhãn huấn luyện.

## Cấu trúc bàn giao

`evidence_pack.json` tách rõ:

- `common_problem`: **chỉ thông tin trước dispatch**, đúng `CommonProblem`
  hiện hành. `EffectChoice` dùng hình ấn/cost đã biết, lượng damage và hồi
  chưa biết. Đây là reconstruction offline, không là packet authority của
  runtime; không tự tạo quyền PASS/CAST/EVOLVE còn thiếu.
- `pre_action_features`: số ô thật và hiệu dụng của từng loại viên trong
  ấn, cùng dòng/hashes của board và policy nguồn.
- `observed_receipt`: typed steps, STAT_CHANGE ledger, cost debit, nguồn
  HEAL/LIFESTEAL, net endpoints và scope association; không vào planner.
- `same_state_common_replay`: quyết định hiện tại trên chính snapshot đó.
- `skill_vs_ranked_swap`: skill so với swap được xếp đầu theo thứ tự của
  core hiện hành. Chỉ so hậu quả cơ học đã mô hình hóa; không có outcome
  thật của swap chưa đi, không gán nhãn “R tốt hơn”.
- `synthetic_sensitivity`: đổi riêng HP hoặc một số dư trên cùng board,
  ghi rõ SYNTHETIC. Đây không phải 28 trận/mẫu native mới.

Module [reasoning_skill_receipts.py](../../src/pokiguard_v2/reasoning_skill_receipts.py)
trả `FrozenJSON` bất biến và không được planner/runtime import. Công cụ
[prepare_icarus_core_evidence.py](../../tools/prepare_icarus_core_evidence.py)
đọc log có SHA pin, tái dùng normalizer và solver/common planner hiện có.
Không có thuật toán đánh song song mới.

Fixture [7 case native đã rút gọn](../../tests/fixtures/icarus_core_20261124/cases.json)
giữ hash nguồn, không có tên tài khoản rõ. Agent core có thể dùng ngay trong
U1/U2/U5/U6, rồi mở rộng model/adapter theo plan chung. Schema này không tự
giải quyết arbitration tiến hóa hoặc cho phép giữ skill trong host.

## Chất lượng và giới hạn

Poison lượng damage, heal, HP sau response, refill và nhãn thắng/thua của
cả 7 case không đổi input ID hoặc quyết định replay. Input trước nước có
checksum/owner/board/cost mâu thuẫn bị loại, không dùng state sau để sửa.
Source model/planner/selection/runner/BASIC hiện tại byte-exact so với
baseline; chỉ thêm module offline, fixture, tool và đăng ký bài CI mới.

Các sensitivity cho thấy proxy cơ hội hồi tăng khi HP 25% và về 0 khi HP
đầy; thiếu **một trong hai** Mana/Nộ thì không mô hình hóa skill là dùng
được. Không ghi lượng HP cứu được hoặc xác suất thắng. Bảy tình huống thật
đều trên 30% HP; chưa có witness native dùng skill để cứu nguy dưới ngưỡng.

7/7 giữ skill có thể là lựa chọn hợp lý hoặc do giới hạn mô hình hiện tại;
nhánh tương lai của replay còn chưa đầy đủ. Vì vậy đây là bộ regression và
đầu vào nghiên cứu, **chưa phải nâng cấp chất lượng gameplay đã nghiệm thu**.
Dữ liệu đã dùng phát triển parser, không gọi là holdout độc lập.

## Điểm chốt

Phần offline Icarus ở mốc này đã xong và đủ bàn giao cho lõi chung. Không
cần lặp BASIC cùng boss chỉ để tăng mẫu. Việc tiếp theo thuộc agent core:
đọc các đầu vào này cho effect model/fire-vs-hold và đo trên cùng bàn;
không triển khai predictor damage/heal từ 7 packet hoặc mở lại cap cũ.

### Bằng chứng và tái hiện

- [Evidence pack](artifacts/icarus_core_evidence_20261124/evidence_pack.json).
- [Verification, hashes và source isolation](artifacts/icarus_core_evidence_20261124/verification.json).
- [Script tái hiện](artifacts/icarus_core_evidence_20261124/verify.py).
- [CI 500 tests](artifacts/icarus_core_evidence_20261124/ci_final.log).
- [Native closure gốc](ACTIVE_SKILL_NATIVE_BASIC3_20261124.md).

```powershell
$env:PYTHONPATH = 'src'
python -B -m unittest tests.test_icarus_core_evidence -q
python -B docs/phase5/artifacts/icarus_core_evidence_20261124/verify.py
```
