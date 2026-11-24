# Bàn giao dữ liệu Mega/Galaxy ngày 24/11/2026

Đã hoàn tất phần thu bổ sung theo yêu cầu: **G1/G3/G4 mỗi nhóm ba trận
Suy luận**; G2 giữ một trận R đã chốt. Không cần mở thêm live để tăng số
mẫu. Source toàn bộ cohort hiện hành:
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.

Gói này là dữ liệu và bằng chứng cho agent phụ trách plan canonical
Opus; không triển khai U1, đổi weights, rollout common worker, nghiệm thu
mọi route/pet, build hoặc commit/push. Demon đã chốt giữ nguyên.

## Đọc theo thứ tự

1. [Manifest](manifest.json) ghim hash fixture/report, nguồn raw local và
   giới hạn mỗi cohort. Đường dẫn trong manifest tính từ gốc repository.
2. Các báo cáo native dưới đây để phân biệt source, route, ACK, binding
   và phần thiếu; không chỉ đọc số WIN.
3. Bộ cặp cùng bàn để kiểm quyết định; receipts chỉ dùng hồi cứu effect,
   không ghép outcome/refill tương lai vào input của planner.

| Cohort | Bài đã hoàn thành | Cặp SWAP cùng bàn | Giới hạn chính |
|---|---|---:|---|
| [Icarus](../MEGA_ICARUS_REASONING5_NATIVE_20261124.md) | 5 R, thường → Icarus | 88 native BASIC/R | 27 fallback read span có ACK; 9 conditional client-card và 5 terminal UNBOUND |
| [T-Rex](../MEGA_TREX_REASONING1_NATIVE_20261124.md) | 1 R, Archon → T-Rex | 10 native BASIC/R | 13 fallback có ACK; một skill terminal UNBOUND, chưa kiểm hành động sau skill |
| [G2](../GALAXY_G2_NATIVE_REASONING1_20261124.md) | 1 R và [1 BASIC riêng](../GALAXY_G2_NATIVE_BASIC1_20261124.md) | 16 resource BASIC branch replay/R | Giữ Khiên cho skill; response không có wire-card ID |
| [G1](../GALAXY_G1_NATIVE_REASONING3_20261124.md) | 3 R, Genbu lv161 | 21 resource BASIC branch replay/R | Chưa có cast thứ tư; pha runtime chưa công bố, chỉ opening/history estimate |
| [G3](../GALAXY_G3_NATIVE_REASONING3_20261124.md) | 3 R, Argilpus lv170 | 22 resource BASIC branch replay/R | Runtime pha 1/3; pha 2/3 chưa quan sát, một response skill thiếu |
| [G4](../GALAXY_G4_NATIVE_REASONING3_20261124.md) | 3 R, Argilpus lv170 | 9 G4 BASIC branch replay/R | 6 ACK + 3 terminal không ACK; schema riêng, không giả thành Galaxy active skill |

Tất cả Galaxy mới là Galaxy chính, không tiến hóa. Các route tiến hóa,
cứu nguy, pha sau và boss khác chưa được cấp nghiệm thu từ bảng này.

## Dữ liệu portable và raw

Fixture ở `tests/fixtures/*_native_*_20261124/` chứa đầy đủ G1/G2/G3/G4
và T-Rex cho cohort tương ứng. Fixture Icarus là 13 case chọn có chủ ý;
[88 cặp đầy đủ](datasets/icarus_native_swaps.json) và
[14 skill receipts](datasets/icarus_skill_receipts.json) được giữ thêm
ở đây, byte-for-byte từ closure local để agent có thể rà ngoài checkout
chứa logs. Không xem 13 case chọn là tập kiểm độc lập.

Raw logs/primitive và manifest gốc nằm dưới `docs/phase5/artifacts/`, bị
ignore theo quy ước repository. Manifest bàn giao lưu hash và đường dẫn
raw; không biến thiếu raw ở checkout khác thành một kiểm đã pass. Không
khôi phục context/card/phase chưa từng được ghi.

Trận G1 Nightsilver lv316 LOSS/F9 trước ba Genbu giữ riêng trong kế hoạch
thu; đã kiểm ledger/controller nhưng full skill/phase audit còn thiếu.
Không xóa hoặc gán lại nhãn, không trộn vào ba Genbu. Cohort này không
được dùng làm training/acceptance trước khi hoàn tất audit còn thiếu.

## Các ranh giới agent lõi cần giữ

- So BASIC và R trên **cùng pre-state**; Icarus/T-Rex có native proposal,
  Galaxy hiện là replay nhánh production. Không trộn hai loại bằng chứng.
- Không coi WIN, số lượt ít, utility nội bộ hoặc nhãn TRADEOFF là nhãn
  nước tối ưu. G1 có một case cần rà với chi phí trước mắt chưa đo lợi ích.
- CommonProblem hiện không hỗ trợ `galaxy_shadow_sword`. Dùng schema G4
  riêng, bổ sung adapter trong plan chung khi đến phạm vi đó; không alias
  G4 thành `galaxy`/`simple` hoặc làm mất nội tại khỏi phép so.
- Skill Galaxy active opaque không phải mask rỗng/damage 0. G4 là nội tại
  gắn với SWAP, không dựng một action bấm thẻ/cost Mana/Nộ cho nó.
- Cost hiện tại không được ứng trước refund/RNG. Tách effect server báo,
  phép số học raw, endpoint, cap/floor và nguồn skill còn UNKNOWN.
- HEAL hoặc FUSION_LIFESTEAL quan sát trong một route không chứng minh
  Icarus/T-Rex/Galaxy đều có cùng nội tại hồi máu.
- Known Sword reply bằng 0 không chứng nhận an toàn sau refill, không
  loại trừ boss tự bơm tài nguyên/ra skill. Không dùng thiếu mô hình để
  tạo safe stop chiến thuật hoặc thay rule PASS đang hoạt động.

Không có training/holdout độc lập hoặc damage predictor đạt nghiệm thu
được tạo trong gói này. Mọi fixture giữ `training_eligible=false` và các
outcome phản thực tế UNKNOWN. Chỉ mở live mới khi có câu hỏi và tiêu chí
kiểm rõ ràng mà corpus này không trả lời được.
