# 5A.3 — Bounded pilots, efficacy và soak

Ngày: **2026-10-09 (Asia/Saigon)**. Mode: **DOCS ONLY**.

Đây là protocol cho bước sau, **không kích hoạt live ở5A.3**. Numerical sample
targets/margins là **PROPOSED**. Chỉ chạy một batch khi người dùng yêu cầu bước
live tương ứng và chuẩn bị game; không dùng đọc prompt hoặc next pointer làm
quyền chạy. Người dùng vận hành game, agent không computer-use tự chơi.

Đọc [A1](5a1_baseline_reasoning_contract.md), [A2](5a2_features_utility_and_profiles.md),
[telemetry/deadline/SLO](5a3_telemetry_deadline_acceptance.md),
[execution contract](../EXECUTION_CONTRACT.md) và đúng prompt milestone.
BASIC giữ default kể cả scoped PROMOTE; unsupported profile giữ baseline.

**D1 execution update 2026-10-16, theo yêu cầu gom luồng của người dùng:**
pilot kỹ thuật hiện tại chạy BASIC3 trước REASONING3 cho từng SIMPLE/CAREFUL,
tổng cap12 giữ nguyên. Control vừa là baseline cùng source vừa đo native H/I;
không thêm trận calibration. Freeze source/cohort/config/formula/read policy/
cost protocol trước control; chỉ điền native maxima theo công thức đã khóa
trước reasoning arm. Không tune theo W/L, không chọn lại mẫu sau outcome, không
AB/BA hoặc efficacy claim. [Runbook D1](../research/5d1_pilot_runbook.md) thay draft
order D1 cũ; quy định E1/soak và các safety/Stop/cap gates vẫn giữ.

## 1. Batch manifest freeze trước outcomes

Một batch có batch_id/hash và:
- parent/return gate, purpose (technical/model/efficacy/soak/package), activated
  scope, profile/boss/mode/loadout/operator label/account binding và game-build evidence;
- source HEAD + worktree fingerprint + artifact hash, config/weights/schema/
  model/calibration versions, sink/runner/reserve/SLO manifests;
- entry gates, supported action families/effects và essential UNKNOWN;
- planned attempts mỗi arm, hard cap mọi attempts, assignment seed/order,
  session/block boundaries, stopping rules; allowed time window;
- primary metric, margins, CI method/unit, exclusions/invalid handling,
  baseline source and exact definitions; evidence paths và stop owner.

Freeze manifest trước first attempt. Đổi nguồn/config/calibration/boss/loadout
giữa batch → dừng, giữ old observations và đánh dấu drift; không pool cho PASS.
Batch mới/version cần kích hoạt riêng. Source HEAD không thay đổi vẫn có thể
có worktree khác; không map evidence bằng HEAD đơn lẻ.

Một attempt bắt đầu khi existing FarmRunner/entry path bắt đầu thử vào trận
cho assigned arm; failed entry/invalid/abort cũng tiêu cap. Một MatchId resume/
continuation không phải trận mới để nhân N; nếu phải relaunch entry sau abort,
đó là attempt mới và vẫn tiêu cap. Ghi attempt→MatchId mapping nhiều record.
Attempt không được chọn lại arm sau khi nhìn board hoặc kết quả.

Target3 valid/arm là mục tiêu coverage, **cap3 attempts/arm mặc định**. Nếu có
invalid thì valid ít hơn3, ghi thiếu. Có thể freeze cap5/arm trước batch được
kích hoạt; không được bổ sung “cho đủ valid” sau cap hoặc tự test tới khi gặp.

## 2. Caps theo milestone

| Batch | Default activated cap | Hard limit của protocol / mục đích |
|---|---|---|
| C3 BASIC disabled vs shadow | 3 + 3 = 6 total | 6 total; cả hai dispatch BASIC; parity technical |
| D1 SIMPLE và CAREFUL | 3/arm/profile = 12 total | Chỉ khi activation ghi cap khác:5/arm/profile =20 total; verdict từng profile |
| D2 Skill Rush / D3 Demon / D4 Mega | Mỗi bước3 BASIC +3 REASONING =6 total | Tối đa5/arm =10 total ở manifest activated; không gộp ba bước thành một run |
| D5 conditional Coop | Tối đa3 baseline, sau gate mới tối đa3 reasoning | Tổng6; reasoning cần nằm trong activation và Coop gate đủ; không mở thêm room/tìm teammate |
| Targeted live missing evidence | Không tự kích hoạt | Một case family, default3/max5 total attempts nếu được yêu cầu; không thay D/E gate |
| E1 efficacy | Một cohort,10/arm =20 total | Tối đa50/arm/cohort khi sample plan đó được kích hoạt trước; không tự mở nhiều cohort |
| E2 reliability soak | Tổng25: BASIC5 + accepted REASONING20 | Tổng hard cap30 nếu freeze riêng trước; allocation30 đề xuất BASIC6 + REASONING24 |
| F1 packaged smoke | BASIC2 + accepted REASONING2 =4 total | 4 total; coverage thiếu → NOT_OBSERVED/targeted protocol, không bonus retry |

Caps không cộng dồn quyền thực thi. Phase5 không có activation hàng loạt.
C3/E2/F1 caps giữ đúng prompt hiện tại; D optional5/arm và E1≤50 là bounded
options cần ghi rõ, không permission ngầm. D5 thiếu capability có thể đóng
CLOSED_BASELINE_ONLY theo router; không suy Coop từ solo.

E2 nếu dùng shadow thay selection vì E1 không promote, phải freeze allocation/
mode và giới hạn kết luận: **shadow soak không chứng minh selection reliability**.
Không dùng profile unsupported để đủ quota. 25/30 attempts không bảo đảm có đủ
từng fault/QTE/emergency; chưa thấy ghi NOT_OBSERVED, dùng offline evidence có nhãn.

## 3. Start, stop và cap accounting

Trước live: offline mandatory gates của đúng bước đủ; C3 live parity closure
bắt buộc trước D selection. Reservation/timer-family mapping và log backend
đã calibrate, artifact/config đúng. Chưa có game/activation thì chuẩn bị runbook
và ghi LIVE_PENDING; không tự điều khiển hoặc attach để điền report.

Dừng batch ngay khi:
- user Stop/emergency/abort, wrong-turn/stale/duplicate input, input after Stop,
  ownership/lease/ACK conflict, orphan, extra read/capture/reorder hoặc flow regression;
- configuration/source/cohort drift, action family ngoài capability;
- essential diagnostics mất khiến không kiểm được safety/outcomes/costs;
- cap đủ, time window kết thúc, hoặc mandatory gate fail.

User abort không tự là technical FAIL; giữ reason, energy/time và UNKNOWN nếu
chưa observed terminal. Critical fault là FAIL/remediation, không “thử tiếp xem”.
BASIC có thể tiếp tục vận hành bình thường ngoài evaluation theo người dùng;
không tự kéo dài batch nghiên cứu.

Reasoning faults tự nhiên trước dispatch có thể fallback hợp lệ và ghi count.
Nếu breaker mở thì còn attempts không được báo “reasoning selection tested”:
dừng evaluation tại safe existing boundary, ghi reduced exposure/coverage.
Không tự toggle breaker/restart run để làm đẹp fallback rate. Fault nguy hiểm
(crash/hang/corrupt action/wrong input/diskfull) chỉ inject **offline**; live
chỉ quan sát lỗi tự nhiên hoặc safe cancellation đã được prove.

Mọi exclusions vẫn có ledger, vẫn tính cap/energy/time. Không bỏ trận thua,
entry lỗi, timeout, thiếu log hoặc bị Stop khỏi mẫu bằng cách gọi “invalid”.
Report planned/started/completed/valid terminal/abort/invalid/not-started riêng.

## 4. Assignment, independence và confounders

C3/D/E1 BASIC control là cùng accepted source/flow với reasoning disabled.
Không sửa BASIC settings/logic để control yếu hơn. Config advisory setting dùng
cùng giá trị giữa arms; overrides chỉ trong reasoning, có log/provenance.

E1: default10 matched assignment blocks, mỗi block2 attempts (1 BASIC,
1 REASONING), thứ tự AB/BA bằng seeded permutation freeze trước chạy.
Nếu cap50/arm thì50 blocks; không tự tăng từ10 lên50 sau xem kết quả.
Block nằm trong cùng session/cohort khi có thể; session boundary chỉ giữa block
trừ Stop/incident. Trận riêng không cùng board/refill/seed và **không phải
paired counterfactual**; matched block chỉ giảm confounding theo thời gian.

Ghi boss/version/loadout/level, operator binding strength, mode, input transport,
QTE mode, session/time/order, foreground/network/machine-load evidence đã có,
drift và carryover của resources nếu có. Không thêm reader để lấp covariate.
Carryover không reset theo cách sửa game; nếu khác làm arms không comparable
thì limit/inconclusive. Không lựa boss khác sau nhìn thua.

Nếu nhiều attempts trong cùng session có dependence, không coi mọi turn/job
hay match là independent statistic. Dùng session clusters cho inference;
matched block bootstrap chỉ khi independence giữa blocks được giải thích bằng
evidence. Một session/ít cluster không được “tạo độc lập” bằng chia file log.

D pilots mặc định3 blocks/arm, mục đích technical/coverage; không suy win-rate.
Coop allocation baseline-first do entry gate; không báo randomized comparison.
E2 5 blocks default, mỗi block1 BASIC +4 accepted reasoning, order freeze trước;
đây là soak có control, không thay E1 efficacy trial.

## 5. Metric ledger và attribution

| Metric | Definition / missingness |
|---|---|
| Attempts N | Tất cả attempts đã start của arm, gồm abort/invalid/no terminal |
| W / L / U | Terminal WIN/LOSS authoritative theo flow accepted; U mọi attempt chưa biết terminal; N=W+L+U |
| Abort / invalid | Tags song song W/L/U với reason và count; không cộng thành outcome thứ tư hoặc đếm đôi N |
| WIN accounting rate | W/N, unknown tính chưa win cho accounting; thêm W/(W+L) terminal-only và unknown fraction; không gọi terminal-only là all-attempt win-rate |
| Energy spent | Tổng debit attributable của mọi attempt trong batch; không trừ regeneration/refund từ net balance rồi gọi consumption |
| Energy/WIN | Total energy mọi attempts / W; W=0 → UNDEFINED, energy missing → UNKNOWN/bounds, không dùng0 |
| Active elapsed | Assigned batch execution wall time gồm entry/combat/result/re-entry/recovery/fallback; outer operator pause ngoài batch ghi riêng |
| Time/WIN / throughput | Total active elapsed / W, và W / active hours; W=0 time/WIN UNDEFINED; không dùng combat-only time làm full throughput |
| Decision exposure | Eligible local decisions, jobs, valid proposals, overrides, baseline retained; reasons timeout/coverage/worker/log/breaker tách riêng |
| Fallback | Fault fallback/eligible enabled decisions; coverage retain/eligible, budget-skip/eligible và after-breaker disabled counts riêng |
| Action quality | Valid swaps/card/PASS, skill/Perfect/ACK result theo existing evidence, turns/match, turns-to-first-passive/cycle, setup retained/lost |
| Safety / flow | Wrong-turn, stale, duplicate, input after Stop, orphan, ownership/ACK conflict, extra read/capture/order violation; zero observed cần đủ trace, thiếu → UNKNOWN |
| Cost/tails | p50/p95/p99/max/N theo A3, CPU/private memory/queue/drop/writer/breaker; small live N descriptive |

Energy debit đã có trong accepted telemetry mới được dùng. Chỉ có trước/sau
balance mà regeneration/reward không tách được → consumption UNKNOWN, không thêm
memory reads. Freeze source/units/attribution rules. Energy cần vì mục tiêu
farm; primary metric thiếu không được efficacy PROMOTE chỉ bằng score/nhanh hơn.

Join chosen root/action_id/source to fresh turn/result trong cùng match/session.
Forecast setup và boss-reply model không phải observation. Observed Shield delta
boss + forecast loss chỉ indicator, không exact consumed cells/action. Boss
action absent ghi attribution UNKNOWN. Alternative có simulated features nhưng
không reward/label WIN/LOSS thật; replay không tạo comparison outcome.

## 6. Narrow validation: Demon adaptive count, setup và bait

D3 pilot không bắt buộc gặp mọi case tự nhiên; chuẩn bị offline scoped evidence
ở B1/B3 trước. Không force account/HP/resource/game state.

| Case | Evidence cần / expected scope |
|---|---|
| C-R20-M30 | Tách physical/effective units/points và caps; observed net resource delta không tự là gross gain hoặc multiplier formula |
| C-D4 vs C-D3-R100 | Operator/account/loadout/boss/build/calibration binding, Rage before, same-burst removals/cap/effect order/dependencies; setting4 là advisory, BASIC default3 không đổi |
| 3 Sword +5 Rage x1 | Nominal100 Rage theo user calibration; chỉ joint-burst claim trong scope conditional A2, không universal lethal |
| Same-burst order missing | Giữ conditional, không promote dependency thành verified; nếu essential để override thì retain BASIC |
| Retained Shield | Forecast pre-boss vs predicted post-boss vs actual next local turn; usable legal Shield match/sweep progress, không chỉ board Shield count |
| Repeated lost setup | Local-turn chain, turns-to-first-passive, resource/HP progress, intervening roots/return source; không rule “setup N lần thì ép fire” |
| Sword bait | Max-Sword ties/coverage, threat/HP/downside, uncertainty/refill stress; positive scope và adverse counterexample, không claim boss chắc ăn mồi |
| Controls | Available immediate fire và retained setup sau boss không được phạt như lost forecast; fallback khi essential model unknown |

[Incident review](../research/demon_shield_setup_incident_review.md) có445
combat files/unique MatchIds,26 indicator pairs/25 matches,10 selected snapshots.
Đã inspected nên là historical development set. Replay26 roots khớp known
resources;23 setup forecasts khớp,3 fire forecasts N/A. Đây là evidence cũ,
không kết quả chạy5A.3, B1 implementation hoặc REASONING superiority.

Case M_7d274339 turn3→5 và13→15 mất forecast, còn17→19 giữ setup là paired
negative/positive **within-match mechanism controls**, không independent win
samples. LOCAL_TURN_RETURNED.last_move match local root thì không relabel thành
boss swap. Không lấy observed next board làm post-boss board cho alternative.

Offline materialize DSI01–DSI07 với provenance. Nếu sau D3 vẫn thiếu actual
boss action/same-burst order, ghi NOT_OBSERVED/UNKNOWN và giới hạn calibration/
override. Không sửa reader/capture/action flow để “nghiên cứu đủ”.
Targeted live nếu được yêu cầu chỉ một case family, default3/max5 total;
cap hết vẫn chưa gặp thì giữ missingness, không chạy tới khi gặp.

## 7. CI95%, margins và verdict E1

### 7.1 Frozen analysis plan (PROPOSED)

Default primary: **energy/WIN ratio q = REASONING / BASIC**, smaller better.
Đồng thời gate all-attempt win rate difference d = W_R/N_R - W_B/N_B và
throughput ratio h = throughput_R / throughput_B.
Proposed scoped margins:
- win noninferiority: lower CI95%(d) >= -0,05 absolute (5 percentage points);
- energy benefit: upper CI95%(q) <=0,95 (ít nhất5% lower energy/WIN);
- throughput noninferiority: lower CI95%(h) >=0,95;
- critical technical/flow violations:0, reliable evidence required.

Margins là product hypotheses, chưa proven meaningful cho mọi account/cohort;
freeze trong E1 manifest trước outcomes. Không đổi primary sang speed hoặc nới
win margin sau khi energy không tốt. Với BASIC gần100%WIN,10/50 attempts có thể
không đủ narrow CI; đúng kết quả là INCONCLUSIVE, không tự mở mẫu.

Per-arm W/N: report descriptive two-sided Wilson95%, không normal CI suy
certainty khi toàn WIN. Wilson không giải quyết session dependence.
[statsmodels official method reference](https://www.statsmodels.org/stable/generated/statsmodels.stats.proportion.proportion_confint.html).

Between-arm d/q/h: proposed10.000 cluster bootstrap resamples, fixed seed;
resample whole independent sessions giữ paired blocks/arms trong session.
Nếu giữa-block independence có evidence và preregistered, resample whole matched
blocks. Mỗi resample tính lại aggregate numerator/denominator của statistic,
không bootstrap turns hoặc trung bình per-match energy/WIN. Dùng percentile
two-sided95% (2,5/97,5%); lưu method/unit/seed/degenerate replicates.
[Scientific API reference for bootstrap, pairing and degenerate distributions](https://docs.scipy.org/doc/scipy/reference/generated/scipy.stats.bootstrap.html).
Cluster design là lựa chọn protocol ở đây; API thường không tự biết session
groups, implementation phải resample đúng group. Không cần thêm library ở A3.

Minimum inference guard PROPOSED: >=10 defensible independent clusters
và >=10 observed wins/arm; ít hơn → descriptive/INCONCLUSIVE. Đây là guard,
không theorem/power guarantee. Tất cả outcomes giống nhau gây degenerate binary
bootstrap (ví dụ d=0 mọi resample) không được coi CI[0,0] chứng minh ngang nhau.
Giữ Wilson uncertainty, đánh dấu degenerate inference/INCONCLUSIVE; không đổi
method sau kết quả để lấy PASS. Resamples0 wins → ratio undefined/unbounded;
không drop chúng rồi chỉ lấy favorable finite quantiles. Unknown consumption/
terminal hoặc CI unreliable → chưa PROMOTE.

Unknown terminals: report sensitivity d_min = W_R/N_R - (W_B+U_B)/N_B,
d_max = (W_R+U_R)/N_R - W_B/N_B, cùng primary accounting d. Không bỏ U khỏi
denominator. Efficacy promotion yêu cầu terminal/cost completeness; nếu thiếu
thì INCONCLUSIVE kể cả terminal-only rate đẹp.

Một primary efficacy claim/profile/cohort mặc định. Multiple planned cohorts/
claims cần freeze family-wise analysis (ví dụ Holm) hoặc gọi các cohort phụ
exploratory, không cherry-pick cohort thắng. Pilot/tuning/soak không pool vào
fresh E1 holdout. Alternative roots và shadow proposals không thêm sample N.

### 7.2 Verdict matrix

| Technical result / efficacy | Quyết định |
|---|---|
| Critical safety/flow failure | FAIL → remediation, không PROMOTE hoặc đi soak để bỏ qua |
| Technical gates sạch, primary/guardrail đủ CI/margins và scope | PROMOTE scoped opt-in; BASIC vẫn default |
| Technical sạch, observed deterioration/no worthwhile benefit với uncertainty đủ rõ | NO_PROMOTION; ví dụ CI energy wholly above0,95 target, win wholly dưới -0,05, hoặc throughput wholly dưới0,95 |
| Insufficient clusters/power/coverage, CI straddles threshold, missing/degenerate data | INCONCLUSIVE; giữ experimental/disabled scope và BASIC default |
| Small D pilot thắng vài trận | Technical scope evidence thôi, không E1 PROMOTE |
| E2 soak sạch / packaged smoke sạch | Reliability/package evidence, không thay efficacy verdict |

Không gọi “không khác biệt có ý nghĩa” là chứng minh tương đương. Technical PASS
không yêu cầu thắng mọi trận; losses/outcomes ghi trung thực, no superiority beyond
scope. NO_PROMOTION/INCONCLUSIVE kỹ thuật sạch vẫn có thể sang E2 với experimental
scope đã gate, theo router; không tự mở model hoặc retune/test loop.

## 8. Report và return gates

Report theo [HANDOFF_TEMPLATE](../HANDOFF_TEMPLATE.md), kèm frozen manifest,
planned/actual cap, arm/order/session/cluster counts, all-attempt ledger,
energy/time denominators, outcomes/missingness, fallback/exposure, technical
critical counters, tails/sample sizes, source/log paths, CI/margins/limitations.

Tách **technical acceptance**, **model/calibration validation**, **efficacy** và
**reliability**. NOT_OBSERVED không thành live PASS; offline controls vẫn hữu ích
nhưng có nhãn. Mọi live batch hết cap/Stop phải kết thúc report và chọn đúng một
next/return prompt rồi STOP; không kéo dài để tìm PASS hoặc tự chạy phase sau.

