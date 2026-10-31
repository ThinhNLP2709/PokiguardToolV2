# 5B.2 — Phạm vi R1 offline và evidence đầu vào

Ngày: 2026-10-09. Implementation: [planner](../../../src/pokiguard_v2/reasoning_planner.py),
[scenario/benchmark CLI](../../../tools/evaluate_reasoning_planner.py),
[focused tests](../../../tests/test_reasoning_planner.py).
Contract A1/A2/A3 giữ nguyên. Đây là input contract **nghiên cứu offline**, chưa
là adapter cho provider hoặc một capability manifest được live-accept.

## 1. Entry và kết quả

`plan(ReasoningSnapshot)` trả `PlannerDecision`: `PROPOSE_OFFLINE` hoặc
`RETAIN_BASELINE`, lý do, baseline, optional proposal, all scored candidates,
feature/contribution bounds, scope/provenance/missingness và versions.
Proposal không có input authority. Không tự ghi log, gọi clock, poll, capture,
read process, executor hoặc callback. Typed snapshot/JSON validation thuộc B1;
malformed evidence/state trong planner trả retention kèm error. Unexpected
programmer exceptions dành cho isolated runner B4, không giả đã fault-isolate.
Invalid state vẫn phải fail closed ở boundary/preflight hiện có.

Utility/config `5b2.one_step.v1`, feature `5b2.features.v1`, model
`5b2.scoped_inputs.v1` đóng băng bằng canonical config hash. A2 starting weights,
normalization8 Sword, bonus12, bucket0.01, margin0.05 đều **PROPOSED_FOR_OFFLINE**.
Context weights thay đổi liên tục theo HP/threat/actual resource gap. Bú win
giữ team objective, không dùng solo HP pressure. Không training hoặc tự sửa config.

## 2. Evidence bổ sung — không tạo thêm reader

Planner chỉ dùng `snapshot.observations` có sẵn. B1 historical records không có
những capability/model dưới đây, nên giữ baseline, không tự bổ sung từ suy đoán.
Evidence phải PRESENT, support khác UNKNOWN, đúng unit và scope; origin không
tự tăng support rank. Model/legality scope phải có profile/session_id/match_id;
legality thêm turn. Card model cần account_binding/boss/loadout cụ thể, khớp
run intent. Không diễn giải operator binding thành xác minh tài khoản runtime.

| Key | Unit | Nội dung / giới hạn |
|---|---|---|
| `planner.model` | `scoped_model` | Version, optional conversion/requirements/protection/certificates/action_models/team_intent/execution_costs |
| `planner.legality` | `action_capability` | owner, swap_allowed, pass_allowed, mandatory, blocked; flags bool, scope đúng turn |
| `planner.known_boss_threat` | `normalized` | Proxy0..1 có evidence; thiếu thì pressure interval, không ngầm threat0 |
| `self.hp`, `self.max_hp` | `hp_points` | Thiếu HP không được hiểu là khỏe hoặc chết |
| `self.mana`, `self.max_mana` | `mana_points` | Actual balance/cap; không lấy30 làm cost |
| `self.rage`, `self.max_rage` | `rage_points` | Actual balance/cap; không lấy20 làm damage |

`conversion={rage:20,mana:30}` là C-R20-M30 USER_CALIBRATED; multiplier path
phải được khai báo supported khi effective khác physical. Record giữ physical,
effective, gross points, actual balance/cap/requirement/deficit và capped gain.
R chỉ thưởng phần deficit được đóng, resource đã ready không nhận thêm R.
Thiếu cap/conversion giữ missingness; không nội suy readiness từ final delta.

Protection cần scoped points/effective và kind heal/barrier; thiếu effect giữ
P interval. Health/Drain chia sẻ HP deficit, không cộng heal vượt phần thiếu.
Không dùng20/30 cho Health/Shield/Drain. Tất cả protection effects/costs/identity
trong B2 fixtures là **SYNTHETIC_SPEC**, không phải công thức game mới được tìm thấy.

`demon_certificates` có id, scope account_binding/boss/loadout, integer
physical_swords, rage_points và rage_mode. Các mode:

- preexisting: chỉ xét Nộ đã có trước root;
- joint_calibrated: scoped nominal joint-burst calibration, không chứng minh effect order;
- after_gain: chỉ nhận bonus nếu model scope hỗ trợ GAIN_BEFORE_BURST.

Certificate chỉ cộng F theo nominal scope, không là observed WIN/damage formula,
dominance tier hoặc input authority. Sai account/boss/loadout bỏ certificate;
các nước khác có căn cứ độc lập vẫn có thể được đề xuất. Setting4 không lọc3
Kiếm; một Kiếm x3 không đạt certificate3 physical Kiếm.

`action_models` cần canonical action, legal/source_valid/consumes_turn bool,
explicit Mana/Rage costs cho card, effect reference và đầy đủ F/R/D/P/B/T/X/E
normalized proxies. Card chỉ xét CAST/PET_SKILL, source không rỗng; PASS chỉ khi
allowed và không mandatory. EVOLVE/nonconsuming/continuation/pending owner
không được planner nhận quyền. Bú win không nhận solo damage skill/card override.
Legal/source_valid là evidence tổng hợp do caller cung cấp, **chưa có production
caller**, chưa chứng minh cooldown/QTE/turn-closure từ những synthetic flags này.
Opaque baseline/card effect không bị gán utility0 để ép SWAP thắng.

## 3. Ledger, coverage và retention

All legal swaps từ existing `evaluate_all_moves` được xét; không top-K/setting
filter. Original cell IDs theo swap và simulator clear rounds/collapse, kiểm
tổng ordinary ledger khớp simulator. Không viết lại logic tìm match.

Demon dùng scope chung **FIRST_WAVE_UNION** cho mọi root: first ordinary clear
union passive sweep. Giao ngang/dọc chỉ tính một lần; Sword certificate chỉ
đếm passive Sword physical. Passive làm thay đổi collapse, nên không cộng
ordinary hypothetical cascades vào sweep. Chưa có passive residual simulator:
T và target/Sword refill interactions giữ interval, không dùng reply geometry
ordinary như proof cho residual passive. Các profile khác dùng known ordinary
cascades, không credit refill mới.

H/L bằng0 với nhãn chưa xét future setup/contest; fixed continuation targets
và discount0.5 được version hóa, chưa có followup nào được cộng điểm. Không
credit pre-boss Shield geometry, không giải quyết bait ở bước này. B3 phải
thêm residual/reply/ties/stress/followup coverage; chưa claim full boss policy.

Total order dùng bucket của lower utility bound → weakest essential support →
profile risk → X → progress → execution cost → family/source/numeric canonical
coordinates. No pairwise epsilon. Override chỉ khi candidate lower bound trừ
baseline upper bound >=0.05 trên cùng one-step coverage. Missing HP/cost/order/
effect có thể làm comparison retain; không blanket ban mọi risk/UNKNOWN.
E thiếu giữ interval, không suy execution cost từ số click. Fixture E0 là input
tổng hợp, không phải latency đã đo ở game. Opaque incumbent luôn retain.

## 4. Coverage so với50 design cases

Đây là mapping scope, **không** tuyên bố50 cases đã pass. 32 focused B2 tests,
24 CLI scenario records và1 targeted healthy-setup fallback kiểm những phần
sau; B1/core regression thêm49 tests.
Machine results: [verification](../artifacts/5b2_adaptive_utility_v1/verification.json),
[inputs](../artifacts/5b2_adaptive_utility_v1/scenario_inputs.jsonl),
[scores](../artifacts/5b2_adaptive_utility_v1/scenario_scores.jsonl).

| A2 IDs | Evidence B2 | Phần còn lại |
|---|---|---|
| U01/U04/U05/U07 | Synthetic units/path missing, ordinary/cross union ledger, scoped certificate negative controls | Actual calibration D3 |
| U02/U03 | Gross Mana90/capped gain10, Rage100/capped gain5; physical/effective và unsupported multiplier test | Exact3 Mana/deficit60 và2 Rage x1+x2 design variants chưa dựng nguyên case; không gọi cả U02/U03 complete |
| U06 | Legal Shield sweep thu2 Mana đóng60 actual requirement; không tạo match2 trái luật | Validate actual conversion/order D3 |
| U08 | Conflicting conversion/unit/binding bị reject; không sửa observed state | Actual observed gain-vs-model conflict/invalidation B3/D3 |
| D01–D06 | Setting4,3 Sword+5 Rage joint scope; existing100 Rage +0 new Rage; insufficient;60+2 order missing/resolved;4 Sword;1 Sword x3 | Actual scoped effect validation D3 |
| D07 | Central cross39-cell union, no overlap/double credit; horizontal primitive regression | Vertical primitive đã thuộc existing8 Demon tests |
| D08 | No-safe synthetic risk injection vẫn giữ legal roots; mandatory/PASS/source filter | Exact Demon least-consuming historical fallback and live parity D3/C3 |
| D09 | Source/config/snapshot IDs có trong decision, bound model/legality turn | Stale proposal rejection/dispatch B4/C4 |
| O01–O09 | H0, no favorable refill/future credit, residual missingness | Reply/ties/bait/retained Shield/stress/refinement toàn bộ B3, chưa claim fix incident |
| P01/P02/P03/P04 | Four profile paired healthy/pressure same settings; SIMPLE/CAREFUL đổi choice, interval risk/missing HP | Exact risky setup/boss interaction B3/D1 |
| P05/P06 | Actual costs/resource readiness + Skill Rush early protection synthetic pair | Actual stage/setup/fire effect/history D2; no full post-skill simulation |
| P07 | EVOLVE/continuation/pending ownership giữ existing boundary; nonconsuming rejected | Real source/history/turn closure integration C/D2 |
| P08/P09 | Mega HP40% vẫn cân nhắc supported protective skill dưới setting, không30% hard cutoff; missing cost/effect controls | Historical MI3 HP9.46/seal5 fixture chưa replay như test mới; actual30-cell/QTE/skill effect D4 |
| P10 | Healthy giữ offensive incumbent; future H0; targeted healthy setup thiếu effect/reply model giữ baseline ([record](../artifacts/5b2_adaptive_utility_v1/healthy_setup_unsupported.json)) | Healthy **post-boss setup** còn unmodeled B3/D4, chưa validate setup choice |
| P11/P12 | Bú win HP1/HP100 cùng team intent chọn cùng board feed proxy; thiếu team model retain; no solo card | Authoritative team wait/live Coop baseline D5 chưa accepted |
| C01/C02/C03/C05/C06/C07/C11 | Determinism/shuffled enumeration/total order/margin, missing context, opaque baseline, nominal F, legal PASS, no future double count | Actual effect sensitivity/calibration B3/D |
| C04 | X risk flag và passive interaction interval, no generic UNKNOWN ban | Target-vs-nontarget residual sensitivity B3 |
| C08/C09 | Strict B1 codec + B2 invalid evidence/state retention; no action authority | Worker timeout/NaN/log-full/stale/preflight behavior B4/C3/C4 |
| C10/C12 | No production imports/calls; pending owner returns baseline | After-dispatch, BASIC/off/shadow/Stop parity C3/E2; chưa test live |

26 H historical roots +1 S B1 mechanics record đều retain vì thiếu model/legal
capability. Không gán boss action hoặc alternative outcome, không dùng chúng để
tune weights hay claim hiệu quả. Không validation/holdout nào bị dùng để tuning.

## 5. Reproduce

```powershell
$env:PYTHONPATH='D:\PokiguardToolV2\src'
python -m unittest tests.test_reasoning_planner tests.test_reasoning_offline tests.test_board_simulator tests.test_demon_aegis_farm
python tools/evaluate_reasoning_planner.py --output-dir docs/phase5/artifacts/5b2_recheck_new_directory --samples 30
```

CLI yêu cầu output directory mới dưới phase5/artifacts, không ghi đè evidence
cũ; chỉ đọc file dataset. Benchmark timing bắt đầu sau fixture construction,
bao gồm pure plan/simulator/immutable explanation, loại IO/decision serialization/
provider/capture/input/preflight/worker/log sink. Quantiles descriptive với30
samples/stratum, không end-to-end deadline proof hoặc bằng chứng tốt hơn BASIC.

Next:5B.3 khi được yêu cầu. STOP ở5B.2.
