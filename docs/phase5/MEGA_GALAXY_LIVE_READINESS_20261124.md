# Mega/Galaxy — việc offline đã đóng và live còn cần

**Đã đủ bài bổ sung trước bàn giao:** [G4 ba trận](GALAXY_G4_NATIVE_REASONING3_20261124.md)
đã hoàn thành cùng G1/G3. Không còn trận được yêu cầu chưa chơi; không tự
mở thêm live. Ba terminal SWAP G4 giữ riêng với ACK thường. G4 common
schema chưa hỗ trợ, cần agent lõi bổ sung adapter; dữ liệu không bị alias.

**Cohort bổ sung G1/G3 đã chốt cuối 24/11:**
[G1 Genbu ba trận](GALAXY_G1_NATIVE_REASONING3_20261124.md) và
[G3 Argilpus ba trận](GALAXY_G3_NATIVE_REASONING3_20261124.md) đều 3/3 WIN.
G3 đọc được pha runtime 1/3, chưa thấy pha 2/3; G1 chưa có pha runtime/lần
thứ tư. Còn G4 ba trận theo yêu cầu mới trước khi bàn giao; user chọn pet/
boss và Start, không Computer Use. Các đề nghị G1/G3 chưa live phía dưới
là trạng thái lịch sử, không mở lại nhóm đã đủ cap.

**G2 BASIC + Suy luận đã hoàn tất cuối 24/11:** [bài Suy luận hiện hành](GALAXY_G2_NATIVE_REASONING1_20261124.md)
1 WIN, 16 SWAP/ACK, ba skill response, 16 cặp so resource BASIC trên cùng
bàn. Không cần lặp Genbu để tăng số mẫu. Các đề nghị G2 "chưa khởi chạy"
bên dưới là lịch sử trước đợt này; chưa nghiệm thu common worker, G1/G3
hoặc route có tiến hóa. Không tự mở thêm live ở bước chốt dữ liệu.

**Cập nhật sau T-Rex 24/11:** [bài một trận Archon → T-Rex đã hoàn tất](MEGA_TREX_REASONING1_NATIVE_20261124.md).
23 SWAP/ACK, 10 cặp native cùng bàn, một skill terminal có ordered effects
và đúng mask riêng. Chưa chứng nhận client-card binding terminal hoặc
route Mega chính → pet thường. Mốc T-Rex đề nghị bên dưới là lịch sử trước
phiên này. Bước live tiếp theo là Galaxy G1/G2/G3 khi user có account;
không tự khởi chạy thêm T-Rex/Icarus.

**Cập nhật cuối ngày 24/11:** [Icarus Suy luận 5/5 đã hoàn tất](MEGA_ICARUS_REASONING5_NATIVE_20261124.md),
115 SWAP/ACK, 14 skill; 88 nước có so BASIC/R native trên cùng bàn.
Phạm vi thường → Icarus/No.11 lv185 đã chốt kỹ thuật. Các đề nghị Icarus
"chưa khởi chạy" bên dưới là lịch sử trước phiên này. Ưu tiên tiếp theo
là tối đa một bài T-Rex Suy luận kiểm collector và quyết định trên source
hiện hành khi gate hợp lệ, rồi Galaxy theo account có sẵn. Không cần thêm
Icarus hoặc mặc định đo lại BASIC nếu profile SWAP hiện tại vẫn hợp lệ.

24/11/2026. User yêu cầu xử lý hết offline rồi báo khi cần live, không mở
trận trong đợt này. Phần này bổ sung checkpoint, không sửa plan canonical
của agent lõi và không mở lại cap/claim lịch sử.

## Mega Suy luận đã live chưa?

**Đã có lịch sử Icarus Suy luận live, nhưng không phải bản hiện tại.**
[5D.4](reports/5d4_report.md), source `f04e452b…`, có 2 trận Icarus với
route pet thường → Mega, Small Blue lv220: 28 reasoned decisions, 42
SWAP/42 ACK, 4 click-only skills, 2/2 WIN. Có hai lỗi kiểm PASS và BASIC
fallback skill; narrow fix sau dừng chỉ được kiểm offline. Giữ lỗi và
ranh giới source trong closure, không coi 2 WIN là chứng minh đánh tối ưu.

Ba trận Icarus vừa thu ngày 23–24/11 là **BASIC**, mục đích kiểm collector:
7 skill, 4 liên hệ client-card có điều kiện và 3 terminal UNBOUND. Chưa phải
live Suy luận Mega hiện tại. Bộ T-Rex 112 cast lịch sử và replay 110 case
cũng không thay nghiệm thu đó. Không dùng field `intelligence=basic` đơn
lẻ để phân loại execution: đợt 5D.4 dùng worker/authority bên ngoài config.

T-Rex/Galaxy chưa có native effect acceptance của collector mới. Các route
Mega chính → pet thường chưa được nghiệm thu bởi cohort thường → Mega.

## Offline đã hoàn thành trong checkpoint này

| Nhóm | Đầu vào bàn giao | Phần vẫn UNKNOWN |
|---|---|---|
| Icarus mới | 7 CommonProblem, 7 receipts tách trước/sau, geometry và cost ledger; 28 sensitivity | Công thức damage/heal; 3 terminal binding; chất lượng R hiện tại |
| T-Rex cũ | 110 CommonProblem, 2 conflict loại, 4 zero-input negative; đúng mask riêng | Ordered effect, lượng heal/damage, protection setting cũ, native source hiện tại |
| Galaxy | 37 snapshot partial + 5 joined G2 click + 1 zero input; replay và đánh đổi Khiên | Effect G2, pha G1/G3, buff/RNG/refund, rollout common |

Không còn cách khôi phục các effect/phase chưa từng được lưu bằng cách
replay thêm các file này. Bộ dữ liệu đã đủ làm regression/bench trước
nâng lõi; không nên lặp hàng chục trận để tăng bộ đếm.

## Bài live tiếp theo đề nghị, chưa khởi chạy

**Ưu tiên đầu: tối đa 1 trận Mega Icarus Suy luận trên source hiện tại.**

- Giữ route và loadout tương đương ba trận BASIC mới nếu còn dùng được:
  pet thường → Icarus, điều kiện skill và Tự bảo vệ như đã thu. Chọn boss
  đủ sống sau một skill và để pet có thể tích đủ tài nguyên; không cần boss
  cực mạnh làm chết trước khi skill.
- Trước Start phải kiểm config, đúng pet/card, scope source/build và profile
  timing còn hợp lệ. Nếu thiếu gate thì báo đúng phần thiếu; không đổi nhãn
  BASIC thành R hoặc bỏ gate để chạy. Việc chuẩn bị profile/qualification
  thực hiện sau khi biết room/loadout, không rebind proof cũ.
- Tiêu chí: có quyết định R thực được ghi và ghép đến action; SWAP có ACK;
  nếu dùng skill thì có fresh context/cost/retained response, ưu tiên skill
  chưa kết trận và nước kế tiếp. So BASIC/common trên chính snapshot đó,
  ghi tài nguyên và cơ hội Kiếm của boss. Không ép R phải đổi nước, dùng
  skill, xuống thấp máu hoặc thắng để tính đạt.
- Nếu trận không chạm tình huống cần, đóng bài ghi coverage thiếu rồi mới
  quyết định thay boss/route. Không tự tăng cap; lỗi kỹ thuật/entry cũng tính
  là một lượt thử. Không thay luật PASS hoặc input để săn mẫu.

**Galaxy: G2 trước nếu user có account, một BASIC để kiểm capture trước.**

G2 không có chuỗi pha, phù hợp kiểm cost, board không bị phá, damage/refund/
buff có nguồn và nước sau skill. Khi đường thu được xác minh mới mở một R
riêng để kiểm nhánh đang thực chạy. Không gộp thành live common worker vì
UI hiện dùng nhánh per-pet. Nếu account chỉ có G1/G3, chuẩn bị bài riêng cho
pet đó, không gọi G4 thay thế G1/G2/G3 dùng thẻ.

G1 cần theo dõi đúng card/session từ đầu và đủ vòng 4 lần skill để kiểm
counter; G3 cần các phase 1→2→3 rồi quay lại 1. Một trận có thể đủ vòng,
nhưng chưa đặt cap hay yêu cầu chơi đủ bằng mọi giá. Bộ đọc/collector đã
có phase trong checkpoint và capability trước/sau; vẫn phải đối chiếu pha
thực khi đọc được. Missing field, wire card không công bố hoặc terminal
partial phải giữ UNKNOWN/UNBOUND. Không suy xác suất RNG hay damage formula
từ một vòng.

**T-Rex:** nếu mục tiêu tiếp theo là T-Rex thay Icarus, trước tiên cần một
bài collector mới đúng T-Rex để kiểm mask/cost/effect, sau đó kiểm R. Không
bắt user chạy lại Icarus chỉ để lấy số lượng và không áp heal Icarus cho
T-Rex. Có thể điều chỉnh thứ tự theo pet/account user có, mỗi bài giữ mục
tiêu và giới hạn riêng.

## Điểm dừng

Chưa có live mới, request, cap, profile activation hay game input trong
đợt offline này. Cần user chuẩn bị đúng account/pet/boss cho bài đã chọn;
chưa cần chơi cả Mega và Galaxy đồng thời. Phần chuẩn bị dữ liệu có thể
bàn giao cho agent lõi ngay, độc lập với việc user đổi account lúc nào.

Nguồn: [Icarus](ICARUS_COMMON_CORE_EVIDENCE_20261124.md),
[T-Rex](TREX_COMMON_CORE_EVIDENCE_20261124.md),
[Galaxy](GALAXY_COMMON_CORE_EVIDENCE_20261124.md),
[collector BASIC3](ACTIVE_SKILL_NATIVE_BASIC3_20261124.md),
[checkpoint](MEGA_GALAXY_CHECKPOINT_REVIEW_20261123.md).
