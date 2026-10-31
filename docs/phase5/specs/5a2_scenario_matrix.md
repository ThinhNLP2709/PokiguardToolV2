# 5A.2 — Scenario matrix cho REASONING

Ngày: **2026-10-09 (Asia/Saigon)**.
Trạng thái: **DESIGN_CASES — chưa có fixture thực thi/test/live**.
Đọc [feature/utility spec](5a2_features_utility_and_profiles.md) và
[contract 5A.1](5a1_baseline_reasoning_contract.md).

## 1. Cách dùng

50 case dưới đây là yêu cầu hành vi/negative controls, không phải 50 test đã
pass. B1/B2 phải tạo board hợp lệ từ snapshot có provenance hoặc synthetic
fixture có nhãn; ghi board, root/reply/followup, ledger, scope và expected
contributions. Không bịa tọa độ/board rồi gọi đó là tình huống đã observed.

Expected “cân nhắc/eligible” không ép action phải thắng mọi candidate. Expected
“chọn” chỉ áp dụng khi fixture chứng minh đủ preconditions, comparison coverage
tương đương và gap qua baseline gate. Khi thiếu điều kiện thiết yếu, expected
là explanation/conditional/baseline, không đổi nhãn thành test pass cho chọn sai.

Mỗi fixture ghi: ID, profile/stage, settings, baseline action, immutable source/
config/calibration versions, legal roots, conversions/units, known/UNKNOWN,
nominal replies/ties/coverage, own accessible followup, score breakdown, reason,
expected forbidden inference. Kết quả simulator/scenario khác observed outcome.

## 2. Resource, count và provenance — U01–U08

| ID | Điều kiện thiết kế | Expected / inference phải tránh |
|---|---|---|
| U01 | 5 Nộ x1 known, cùng supported effect path | Gain100 rage_points, physical5; không hiểu thành5 điểm hoặc5 effective Sword |
| U02 | 3 Mana x1 known, deficit60, cap/cost đủ nguồn | Gross90; readiness chỉ credit60 còn thiếu, overflow không credit; không lấy30 làm card cost |
| U03 | 2 Nộ x1+x2, multiplier path supported | Physical2/effective3/gain60; không đồng nhất physical với effective |
| U04 | Như U03 nhưng một multiplier UNKNOWN/path chưa supported | Flag unsupported đúng phần gain; không tự gán x1/x2 hoặc claim đủ Nộ |
| U05 | Cùng root cell xuất hiện trong direct/cascade/passive hoặc vùng sweep giao nhau | Removal ledger dedup; một event không được cộng hai lần; refill khác event/UNKNOWN không được credit thuận lợi |
| U06 | Deficit Mana60, candidate hợp lệ consume2 Mana qua cascade/passive | Có thể đủ requirement; không cần cứng nhắc chờ match3 Mana; không sinh swap match2 trái luật |
| U07 | User calibration account A; run intent/account binding khác hoặc chưa xác định | Scope mismatch bỏ sufficiency certificate; binding yếu phải hiện rõ, không tự nhận đã xác minh account |
| U08 | Predicted20/30 mâu thuẫn observed state/cap/effect path | Giữ observation và model-conflict evidence; không sửa state, không suy gross gain/cost từ net delta lẫn effects khác |

## 3. Demon thích ứng theo hiệu quả — D01–D09

| ID | Điều kiện thiết kế | Expected / inference phải tránh |
|---|---|---|
| D01 | Setting cá nhân4; root Khiên quét3 Kiếm x1 +5 Nộ x1; calibration joint-burst đúng scope; action legal | Root eligible và có USER_CALIBRATED nominal sufficiency dù physical Sword3<4; có thể chọn nếu tốt hơn incumbent đủ gap; không đổi setting/default |
| D02 | Setting4; Nộ đã đủ trước damage trong scope; sweep3 Kiếm, không cần ăn thêm5 Nộ | Cân nhắc3 Kiếm theo existing-rage certificate; không biến “3+5” thành combo bắt buộc |
| D03 | Như D01 nhưng không có Nộ đủ/gain đủ hoặc certificate không áp dụng | Không claim kill vì chỉ thấy3 Kiếm; có thể setup/protect/giữ BASIC tùy utility, không luôn fire3 |
| D04 | Đã60 Nộ, sweep3 Kiếm+2 Nộ x1; effect order/applicability chưa supported | Tổng cuối có thể100 không chứng minh damage dùng100; conditional, sensitivity/retain baseline nếu essential; không nội suy formula damage |
| D05 |4 Kiếm x1 trong scope C-D4 và root hợp lệ; alternative3 Kiếm chưa đủ support | Giữ khả năng chọn4 theo calibration/baseline; adaptive không có nghĩa luôn hạ Sword count |
| D06 | Một Sword x3 trong sweep, còn0/1 Sword physical khác | Offensive proxy dùng effective; không tự đạt physical3/4 certificate từ multiplier |
| D07 | Match Khiên ngang/dọc/cross có overlap | Sweep lần lượt cột/hàng/union đúng policy; không vùng3x3, không double count Sword/Nộ |
| D08 | Không có board-safe candidate, mandatory turn, least-consuming Sword root theo accepted b6 fallback | Không cấm mọi Sword/PASS giả; giữ legal consuming obligation và baseline path; ordinary Sword tactical cost khác hard gate |
| D09 | Passive burst candidate có score tốt nhưng proposal stale hoặc source thay | Reject tại preflight hiện có, không thêm card/QTE/input; score/certificate không có authority |

Làm rõ ngày2026-10-18 cho variants củaD01/D02/D03/D06:bossLieyun77;
current account setting4→candidate3physicalSword+100Rage từ5known consumable
Ragex1,hoặc đủNộ có sẵn theo đúng applicability. Other-account setting3→
candidate2Sword+đủNộ cần own scope;không transplant vào current account.
0/1physicalSword không có offensive sufficiency certificate theo sàn2do user
yêu cầu. Các variants mới này là **design/pending**,không cộng vào8cases đã
chạy hoặc gọi đã verified universal damage. O01–O09 vẫn là phần trọng tâm;
combo đủ sát thương không thay acceptance setup/retained Shield/bait.

## 4. Boss tranh chấp setup, bait và coverage — O01–O09

| ID | Điều kiện thiết kế | Expected / inference phải tránh |
|---|---|---|
| O01 | Root tạo match Khiên đẹp; boss reply nominal lấy Khiên/phá sweep target | Pre-boss setup chỉ diagnostics; H giảm/zero theo opportunity sau boss, không tự giữ full setup credit |
| O02 | Root A tạo Khiên nhưng boss ăn; root B chừa Sword để boss nominal ăn Sword, sau đó ta có legal Shield followup; HP đủ theo evidence | Bait B eligible, so threat/fragility vs A và baseline; có thể chọn B, không luôn cấm để lại Sword |
| O03 | Hai max-Sword replies bằng effective count: một giữ Khiên, một ăn Khiên/phá target | Giữ cả tie, không chọn favorable tie; H không được guaranteed từ tie tốt; explanation phải có contest |
| O04 | Như O02 nhưng HP thấp/boss threat lớn, alternative protect/fire có supported value cao hơn | T/pressure làm giảm sức hấp dẫn bait; chọn alternative nếu fixture đủ gap, không “Sword bait luôn tốt” |
| O05 | Boss không có Sword-producing reply; có Shield và resource replies | Secondary priority UNKNOWN; xem alternatives, không giả boss sẽ chừa Khiên hoặc tự dùng priority của ta làm proof |
| O06 | Refill UNKNOWN có thể tạo Sword reply mới/auto-match làm mất setup | Known model conditional; flag interaction/downside; không tự fill gem thuận lợi hoặc gọi H guaranteed |
| O07 | Một reply ăn nhiều physical Sword hơn nhưng effective ít hơn reply khác | Log cả hai; nominal working model max effective, physical-first là sensitivity/model mismatch; không tuyên bố boss thực dùng effective đã verified |
| O08 | Hết node/time cap khi còn nominal ties hoặc critical target region chưa xét | Coverage/unexamined rõ; không full future credit/guarantee, nếu comparison nhạy thì baseline; không chờ thêm/reread |
| O09 | Nominal Sword-first giữ Khiên, adverse non-Sword ăn Khiên; boss card/effect ngoài coverage | Nominal + fragility penalty và model flags; không gán probability, không dùng mọi adverse branch làm hard veto, không claim enumerate toàn bộ boss policy |

## 5. Cùng settings, tình thế khác — P01–P12

| ID | Profile / điều kiện thiết kế | Expected / inference phải tránh |
|---|---|---|
| P01 | SIMPLE: HP khỏe, known offensive root tốt, setup/resource không cấp thiết | Có thể tiếp tục Sword-first; reasoning không phải ép chọn khác BASIC |
| P02 | SIMPLE: giữ settings/board phần liên quan, đổi HP/threat; có protect root đủ supported value | Trade-off được đổi bằng context, cân nhắc protection thay damage; không dùng một HP threshold chung khóa mọi profile |
| P03 | CAREFUL: healthy, offensive root ít uncertainty và tốt hơn giữ setup | Có thể aggressive; CAREFUL không phải ban Sword/UNKNOWN tuyệt đối |
| P04 | CAREFUL: risky setup nhiều UNKNOWN so protect/resource root | T/X/pressure/sensitivity hiện trong comparison; no-safe không được biến thành no-legal |
| P05 | Chịu đấm ăn xôi: thiếu actual resource, setup setting chưa đạt | Compare close deficit vs giữ gem/setup; actual cost/source giữ hard, setting advisory; không credit resource đã max |
| P06 | Chịu đấm ăn xôi: skill hợp lệ, threshold chưa đạt, wait cho boss reply nguy hiểm hơn supported early fire | Early fire/protect được cân nhắc có evidence; unsupported skill effect không tự score0 để force SWAP |
| P07 | Chịu đấm ăn xôi: post-skill/EVOLVE continuation | Đúng current skill source/history và turn-consuming semantics; không repeat skill/swap sau closed turn; shared Evolution branch giữ nguyên |
| P08 | Mega Icarus: seal5<setting6, HP9.46%, actual skill actionable; historical MI3 làm nguồn scenario | Có thể fire/protect thay setup; current BASIC hotfix là incumbent, không gọi historical case là test mới hoặc “lỗi còn tồn tại” |
| P09 | Mega Icarus: HP/threat pressure cần protection trước mốc30%, same seal setting, candidate supported | Continuous trade-off có thể chọn sớm; không chuyển hotfix30% thành hard REASONING cutoff |
| P10 | Mega Icarus: HP khỏe, seal chưa đủ, setup sau boss tốt và nguồn skill hợp lệ | Có thể tiếp tục setup, không luôn early fire; 30-cell scope và click-only/QTE capability giữ |
| P11 | Bú win: local death là một phần team intent, board feed-boss phù hợp, authoritative team wait | Không áp solo survival/Sword-avoidance để phá profile; no-skill/card gates và team wait giữ; không chứng minh team WIN từ local death |
| P12 | Bú win chưa có baseline live closure, hoặc stale Coop/player ownership | REASONING live unsupported/pending, giữ capability gate; không suy acceptance từ solo hoặc offline fixtures |

Demon là profile thứ sáu được kiểm ở D01–D09/O01–O09. P01/P02,
P03/P04, P05/P06 và P09/P10 là các cặp chống cứng nhắc; thêm paired variants
chỉ đổi HP, actual resource, boss reply hoặc calibration scope, giữ settings.

## 6. Comparison, UNKNOWN, deadline và invariant — C01–C12

| ID | Điều kiện thiết kế | Expected / inference phải tránh |
|---|---|---|
| C01 | Candidate set/root ordering đổi nhưng snapshot/config/work budget y hệt; near tie | Fixed bucket/total order + baseline margin giữ determinism; không pairwise epsilon/random tie |
| C02 | Score gap nhỏ hơn margin, hoặc calibration/effect assumption có thể đảo winner | Retain valid baseline; explanation không gọi score gap là xác suất thắng |
| C03 | Thiếu HP, boss HP, caps hoặc resource/cost essential | Missingness riêng; thử supported proxy/interval đúng scope, essential unresolved thì baseline; không null→0/healthy/guaranteed kill |
| C04 | UNKNOWN chỉ ở vùng không tương tác outcome so critical UNKNOWN ở target/reply | Có thể phân biệt risk; không generic UNKNOWN hard ban, không favorable refill credit |
| C05 | Opaque baseline CAST/skill effect, SWAP effect có model | Không mặc định baseline utility0; retain baseline/giới hạn comparison tới scope supported |
| C06 | F certificate dự đoán terminal, nhưng chỉ là conditional calibration | Root terminal scenario không future credit; vẫn giữ adverse continuation/claim nominal, không ghi observed WIN |
| C07 | PASS được authoritative cho phép so PASS prohibited/mandatory consuming turn | Legal PASS chỉ ở case được phép; reasoning không né deadline bằng PASS giả/reset idle |
| C08 | Worker timeout/error/malformed/NaN/log sink đầy trước dispatch | Return baseline còn valid qua preflight; không block action/Stop, không claim actual logging/fault test ở 5A.2 |
| C09 | Proposal đến muộn/sai session/config/turn hoặc state invalid | Reject proposal; invalid state existing fail closed, không bypass bằng fallback |
| C10 | Input đã gửi, ACK uncertain, worker trả action khác | Không replacement BASIC/REASONING input; pending/ACK/recovery ownership cũ |
| C11 | Root resource/gems rồi followup score; same future opportunity đã ghi H | Discount future một lần và chỉ incremental/new event; không cộng H rồi full future utility hoặc chấm lại root balance |
| C12 | BASIC/off/shadow, logging lỗi hoặc worker active khi Stop | Thiết kế giữ flow read/capture/input/ACK và BASIC incumbent; shadow không chờ; Stop không chờ worker/drain vô hạn; đo ở C3/E2 sau |

## 7. Gate và handoff

- B1: provenance + legal replay board/ledger + missingness, không thêm reads.
- B2: U/D/P/C comparison cases, anti-rigidity paired fixtures, deterministic
  score/contribution checks. Chưa có refinement thì future coverage unsupported.
- B3: O/D same-burst/certificate scope, tie coverage, retained Shield, bait
  downside, adverse scenarios và effect-order sensitivity. Không chỉ tối đa
  immediate Sword rồi gọi là planning.
- A3: đưa conversion/calibration/reply/followup/coverage/override reasons vào
  diagnostics và protocol. Chốt numeric latency/evidence gates riêng.
- D3: narrow validation conversion/joint-burst và contested Shield/bait theo
  scope thực tế; nếu case chưa xuất hiện ghi NOT_OBSERVED, không chạy thêm vô hạn.
- D1/D2/D4/D5: profile gates riêng; D5 còn baseline live condition.
- E1: measured efficacy theo frozen cohort; design matrix không chứng minh
  optimality, win-rate, energy/WIN hoặc latency.

Case không thể dựng từ existing published state/solver phải ghi limitation/
capability unsupported, không đổi reader/executor để ép case pass trong Phase5.
Một calibration chứng minh sai cần invalidate version/scope và giữ baseline,
không tự sửa preferences hoặc online training.

**STOP ở 5A.2.** Matrix này chưa được thực thi và không kích hoạt bước sau.

## 8. Targeted incident evidence sau closure

[Demon Shield review](../research/demon_shield_setup_incident_review.md) đã rà
log cũ và replay primitive hiện có, lưu10 actual snapshots. DSI01–DSI07 bổ sung
multi-turn chain/control/missing boss-action requirements cho B1/B2/B3; không
đổi50 design cases thành tests passed và không advance roadmap.
