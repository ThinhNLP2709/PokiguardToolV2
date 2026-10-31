# 5A.2 — Feature, utility và profile REASONING

Ngày: **2026-10-09 (Asia/Saigon)**.
Trạng thái: **SPEC_DEFINED — DOCS ONLY; chưa implementation/test/live**.
Entry: [5A.1 PASS STRONG](../reports/5a1_report.md).
Đọc chung [contract 5A.1](5a1_baseline_reasoning_contract.md),
[execution contract](../EXECUTION_CONTRACT.md) và [scenario matrix](5a2_scenario_matrix.md).

## 1. Yêu cầu mới và phạm vi

Người dùng giải thích cơ chế bằng Demon Farm, không giới hạn suy luận vào Demon:

- một viên Nộ thường x1 tương ứng **20 điểm Nộ**, Mana x1 tương ứng **30 điểm Mana**;
- ở tài khoản/ngữ cảnh boss người dùng đang nói tới, 4 Kiếm đủ kết liễu theo
  kinh nghiệm của người dùng; khi đủ Nộ, 3 Kiếm có thể đủ;
- ví dụ vùng nội tại có 3 Kiếm + 5 viên Nộ: phải được cân nhắc dù setting là4;
- không chỉ tạo match Khiên rồi cho rằng ta sẽ ăn ở lượt sau: boss cũng được đi;
- mô hình boss tham chiếu: ưu tiên nước ăn Kiếm, lấy nhiều Kiếm nhất, rồi gem khác;
- phải so cách giữ/tạo Khiên bằng board sau phản hồi boss, gồm chừa Kiếm có chủ
  đích để boss có động cơ ăn Kiếm và để lại Khiên.

“5 Nộ” trong ví dụ được hiểu là **5 viên Nộ x1 =100 điểm**, không phải5 điểm.
Đây là cách diễn giải dùng trong spec, có provenance rõ, không thêm cấu hình UI
hoặc thay defaults ở bước này. Không viết một rule mới “luôn3 Kiếm+5 Nộ”.

[Policy Demon BASIC](../../demon_aegis_farm_policy.md) ghi default3 ô Kiếm vật
lý; ví dụ cá nhân dùng setting4. Giữ defaults/preferences/BASIC nguyên trạng.
Demon quét **cột khi match Khiên ngang, hàng khi match Khiên dọc**, lấy hợp vùng
khi giao nhau; không giả định vùng3x3. Physical count khác effective count.

## 2. Evidence và đơn vị

Mọi value có metadata, không dùng null/0 thay cho bằng chứng:

| Trường semantic | Nội dung |
|---|---|
| value / unit | Giá trị + đơn vị, ví dụ physical_cells, effective_gem_units, mana_points, rage_points, hp_points, ratio, seconds |
| availability | PRESENT / MISSING / UNSUPPORTED / STALE / CONFLICT |
| origin | OBSERVED_SNAPSHOT / DERIVED_SOLVER / USER_PROVIDED / MODEL_PREDICTION / SYNTHETIC_SPEC |
| support | VERIFIED_FOR_SCOPE / USER_CALIBRATED / CONDITIONAL_MODEL / EMPIRICAL_VALIDATED / UNKNOWN |
| source_ref | Snapshot/model/calibration/research record, không game pointer mới |
| scope | Game build, actor/effect/profile/loadout/boss/account binding có sẵn hoặc khai báo operator |
| assumptions / dependencies | Refill, effect order, caps, boss-policy/tie assumptions; dependency identity |
| bounds | Khi có interval phải kèm nghĩa: exact conditional range, empirical interval hoặc scenario range |

Origin là nguồn; support là quyền sử dụng. USER_CALIBRATED không tự thành
reverse/live-verified và không là probability. Một số đếm có thể exact trên
simulated board nhưng forecast board đó vẫn CONDITIONAL_MODEL.

R1 được dùng calibration người dùng trong đúng scope để so sánh, không phải
đợi full damage model. Live promotion cần kiểm chứng hẹp ở B3/D3. Scope không
khớp/essential assumption mâu thuẫn thì bỏ certificate, dùng proxy/baseline;
không gắn calibration một account cho mọi account/boss.

## 3. Resource conversion và Demon sufficiency

### 3.1. Count, effective unit và điểm tài nguyên

```text
physical_count(g) = số ô known g bị consume (deduplicate)
effective_units(g) = tổng multiplier known của các ô đó
predicted_mana_gain = 30 * effective_units(MANA)
predicted_rage_gain = 20 * effective_units(RAGE)
```

20/30 có origin USER_PROVIDED trong bước này, là tham số conversion có version
và scope. Nhân multiplier chỉ khi cùng effect path được model hỗ trợ; multiplier
UNKNOWN không được tự gán1. Nếu actual snapshot/effect khác conversion thì giữ
observation, đánh dấu conflict/model unsupported; không sửa state thật.

Ví dụ x1: 3 Mana→90 điểm; 5 Nộ→100 điểm. Nếu path multiplier đã supported,
2 viên Nộ x1+x2→3 effective units→60 điểm; vẫn chỉ là2 physical cells.
Thiếu Mana60 thì 2 viên x1 có thể đóng deficit; không cần chờ3 viên theo một
minimum match assumption để tính readiness, nhưng **action vẫn phải là swap
tạo match hợp lệ**. Không sinh nước ăn2 ô trái luật từ phép tính đó.

Resource hiện có + gain khác resource tại thời điểm damage. Khi có cap đọc sẵn,
clamp theo cap; phần overflow không nhận readiness credit. Cap thiếu thì không
claim net gain/readiness vượt cap. Chi phí lấy từ capability runtime, không từ
20/30 hoặc net delta.

Không cộng direct/cascade/passive aggregate hai lần. Mỗi root-known cell chỉ
được credit một lần theo removal event; swept region dùng union. Refill mới,
spawn UNKNOWN và effects chưa modeled nhận zero favorable credit.

### 3.2. Calibration manifest khởi đầu, chưa là formula damage

| ID | Khai báo người dùng | Quyền sử dụng trong R1 |
|---|---|---|
| C-R20-M30 | Plain gem Nộ20, Mana30 | Resource-unit conversion có scope; không suy damage |
| C-D4 | 4 Kiếm đủ kết liễu trong account/ngữ cảnh boss đã nêu | Sufficiency predicate có provenance, không universal HP formula |
| C-D3-R100 | Khi đủ Nộ, 3 Kiếm có thể đủ; ví dụ3 Kiếm+5 viên Nộ x1 trong vùng phá | Joint-burst sufficiency candidate được cân nhắc ở setting4 |
| C-BOSS-SWORD | Boss ưu tiên Sword rồi nhiều Sword nhất, sau đó gem khác | Nominal opponent model, chưa là policy reverse-verified |

Đối với C-D4/C-D3-R100, giữ physical Sword count và effective Sword count riêng.
Ví dụ3+5 hiện dùng plain x1. Không tự tuyên bố một ô Sword x3 tương đương ba ô
cho mọi certificate. Các tổ hợp/multiplier khác cần scope/evidence riêng.

Hai đường đủ Nộ:
- Nộ đã đủ **trước damage**:3 Kiếm có thể đạt certificate trong scope.
- Nộ tới từ **cùng burst**: dùng khai báo joint3+5 của người dùng như calibration,
  ghi dependency về thứ tự/cơ chế áp Nộ; không lấy resource cuối action để chứng
  minh Nộ đã tăng trước Sword damage.

Không mặc định đủ Nộ nghĩa100 cho mọi account/mechanism;100 là mốc diễn giải của
ví dụ5 viên x1. Các trường hợp Nộ hiện có60 +2 viên x1 có tổng100 chỉ được xem
tương đương nếu thứ tự/applicability cùng path được hỗ trợ; nếu chưa thì conditional.
Không suy ra formula như damage=attack*sword*(1+rage/100) hoặc HP threshold mới.

Certificate tạo `nominal_objective_sufficient`, không `observed_WIN`.
Nếu không đủ scope/effect order,3 Kiếm vẫn không bị cấm chỉ vì setting4; có thể
được rank bằng tactical proxy, nhưng không claim kill. Khi outcome comparison
phụ thuộc essential evidence thiếu thì retain BASIC.

### 3.3. Làm rõ trực tiếp tại5D.3 — 2026-10-18

Người dùng chọn **boss Lieyun lv77**. Tài khoản hiện tại thiếu ATK nên BASIC
đặt4ôKiếm; theo calibration người dùng,3ôKiếm+100Nộ có thể đủ kết liễu. Năm
viên Nộ x1 phải khả dụng trong vùng thực sự bị tiêu thụ bởi nước kích hoạt
nội tại,không phải5viên bất kỳ trên bàn. Đã đủ Nộ trước burst và Nộ thu từ
cùng burst vẫn là hai đường applicability/order riêng.

Với tài khoản khác vốn đủ sát thương ở setting3,người dùng nêu variant2Kiếm+
đủNộ. Đây là template có scope account/loadout riêng,không áp certificate2Kiếm
cho tài khoản hiện đang cần4. Không nội suy mọi setting thành`setting-1`.

**Sàn2ôKiếm vật lý** là yêu cầu của người dùng cho certificate đủ sát thương:
không chấm0/1ôKiếm là đủ kết liễu dù có multiplier/Nộ. Đây không là bằng chứng
reverse/live về damage toàn tài khoản,không biến mọi nước bảo vệ/tài nguyên
thành trái luật. Variants2Kiếm và sàn này cần test trước D3reasoning admission;
chưa được thực thi bằng lần bổ sung tài liệu này.

Mục tiêu chính là **setup thông minh sau phản hồi boss**:giữ cơ hội Khiên ta
còn tiếp cận được,dụ boss ăn Kiếm khi trade-off phù hợp,tính ties và alternative
boss lấy Khiên,HP/tài nguyên/refillUNKNOWN,fire/setup/protect/PASS hợp lệ và
progress của những lượt setup liên tiếp. Combo giảm Kiếm là một nhánh hỗ trợ;
chỉ chứng minh combo hoặc thắng1lượt không hoàn tất phần contested-setup.
Không thêm rule cứng“sauNsetup luôn đổi”,không ép phải khác BASIC.

Nguồn trực tiếp/scope/giới hạn nằm trong
[operator clarification](../artifacts/5d3_demon_acceptance_20261018/operator_clarification_v2.json).

## 4. Logical schema v1

Đây là schema semantic cho B1 mapping sang DTO thực; không tuyên bố tất cả field
đã tồn tại với đúng attribute name. Chỉ source có sẵn hoặc derive từ immutable
state/solver/config; thiếu thì availability rõ, không thêm memory read/capture.

### 4.1. Snapshot — pokiguard.reasoning.snapshot.v1

| Nhóm | Nội dung / nguồn được phép |
|---|---|
| Identity | Existing CombatSessionKey/MatchId, actor/local owner, turn/local sequence, board hash/ACK identity, controller generation |
| Time | Existing observation timestamp/monotonic age, remaining timer/source, policy deadline; reserve từ A3 |
| Board |64 cells, canonical zero-based solver coordinates, gem/multiplier/knownness; input mapping authority vẫn ở executor |
| Actor state | Self/boss HP/maxHP, Mana/Nộ/caps/shield/buffs **chỉ nếu đã published**; missing từng field |
| Action capability | Existing card/skill/source/cost/cooldown/actionability, Evolution/turn-consuming semantics và supported family |
| Transition | Existing pending/Stop/terminal/pass legality/source-turn fences; không worker sở hữu các gate |
| Run intent | PlayStyle/loadout/input mode/settings immutable; profile/ruleset/schema/model/calibration versions |
| History | Existing same-session skill/continuation history; không dùng lịch sử trận trước như source authorization |
| Baseline | Existing BASIC decision/trace + exact source, kể cả NONE/technical disposition |
| Model references | Immutable conversion/calibration/boss-policy scope; không raw process handles/pointers/images |

Runtime board invalid/incomplete vẫn fail closed như A1; UNKNOWN trong simulated
refill board là khái niệm khác. Không invent tên pet/account nếu boundary hiện
chưa published; calibration dùng operator scope label + pinned run intent, ghi
mức binding thực tế. Không pretend đã tự xác minh tài khoản.

### 4.2. Candidate — pokiguard.reasoning.candidate.v1

| Nhóm | Nội dung |
|---|---|
| Identity | Stable action family + source identity + canonical swap endpoints/card source; BASIC membership |
| Validity | Hard legality/cost/source/capability disposition và reason; không threshold advisory trong hard filter |
| Root transition | Existing simulator result, known removal ledger/union, direct/cascade/passive triggers, next board/UNKNOWN |
| Features | Feature vector + evidence metadata, profile context, normalized values/scales |
| Opponent | Nominal max-Sword tie set, examined/stress/unexamined replies, policy assumptions, coverage |
| Continuation | Residual board và own followup reachable sau boss; destroyed/contested setup và effect boundaries |
| Evaluation | Immediate/continuation contributions, score range/nominal/stress/fragility, exclusions, completed work |
| Explanation | Baseline comparison, settings overridden, why-now/why-not-wait, downside/UNKNOWN |

Removal ledger có root-cell identity hoặc equivalent dedup proof từ primitive.
Không có ledger đủ thì không tự sum aggregate chồng nhau; feature unsupported/
conditional đúng phần bị ảnh hưởng. B1 map source catalog, B2/B3 implement derive.

### 4.3. Proposal — pokiguard.reasoning.proposal.v1

`USE_CANDIDATE` hoặc `RETAIN_BASELINE` là semantic dispositions, chưa thêm enum
runtime. Có source/job/config/calibration/model versions, completed candidate,
scores/contributions/evidence, reason/fallback, examined work, created/deadline.
Không chứa permission/coordinate-click script hoặc ACK giả.

Caller existing preflight có quyền reject. Worker không mutate snapshot/config,
chọn turn mới hoặc rerun read khi proposal stale. Proposal sai schema/identity,
NaN/Inf score, thiếu required metadata hoặc late → baseline còn hợp lệ.
Pending input → giữ ACK/recovery owner, không replacement action.

### 4.4. Source catalog

| Input | Sẵn từ docs / derive được | Nếu thiếu |
|---|---|---|
| Board/legal swaps/root resource/Sword replies/UNKNOWN | GameState + existing simulator/BASIC trace | Invalid observed state→existing fail closed; model field thiếu→unsupported |
| Self/boss resources, HP, skill cost/source, PASS | Existing state/capability/authority evidence | Optional feature missing; essential gate không override |
| Demon sweep region/physical/effective counts | [Demon policy](../../demon_aegis_farm_policy.md) + known board geometry | Không dựng geometry khác hoặc credit unknown gems |
|20/30, account3+Nộ/4Sword, nominal boss rule | User declaration + immutable calibration manifest | Có nguồn user rõ; không claim runtime field/reverse proof |
| Post-boss setup/reply tie effects | Pure derive từ candidates + bounded simulator | Coverage/unknown flags; không extra observation |
| Full damage/refill distribution/boss skill policy | Chưa có model đủ | Scoped proxy/certificate hoặc UNKNOWN, không tự bịa |

## 5. Features và normalization

Các dimensionless feature dưới đây có version, range[0,1] trừ score/contribution.
Dùng fixed scales/profile references, không normalize theo candidate min/max.

| ID | Ý nghĩa | Chuẩn hóa / evidence |
|---|---|---|
| F | Mục tiêu trận/đội đủ ngay trong scope model/certificate |0/1 sufficiency predicate + support; UNKNOWN không thành1 |
| R | Đóng actual Mana/Nộ deficit | Trung bình min(known point gain,deficit)/requirement của requirements đang thiếu; đủ rồi credit0 |
| D | Offensive/effect value còn tính được | Sword effective/8 clipped hoặc effect-quality/reference có scope, không gọi là HP damage |
| P | Health/Drain/Shield/heal protection hữu ích hiện tại | Benefit vào phần thiếu/đối thủ có tài nguyên có thể drain, effect model/proxy có nhãn; không universal20/30 cho gem khác |
| H | Setup **còn tiếp cận được sau boss** | Profile target progress/followup quality trên residual board; không cộng pre-boss geometry lần nữa |
| B | Cơ hội board phục vụ mục tiêu team của Bú win | Feed-boss/keep-Sword/turnover có giải thích; không probability team win |
| T | Known boss threat | Max known Sword effective/8 clipped trong tập reply; boss effect khác chỉ khi model supported |
| X | Uncertainty exposure/assumption dependence | Known refill UNKNOWN fraction + interacting target/Sword region flags, capped1; không probability |
| L | Loss của setup/resource option bị contest | Known goal cells/opportunity mất vào boss so reference, clipped1; chỉ phần chưa phản ánh trong H |
| E | Chi phí execution/compute ảnh hưởng deadline | Time/reserve fraction theo family/A3; chưa đo không suy chỉ bằng click count |

Scale8 là starting fixed normalization constant **PROPOSED**, không damage constant.
Physical/effective count vẫn lưu nguyên để review; không mất distinction do normalize.
X initial: `min(1, unknown_cells/64 +0.25*target_interaction +0.25*sword_interaction)`;
coefficients proposed, scenario sensitivity phải thử. UNKNOWN multiplier có flag riêng.

R không cộng điểm mọi tài nguyên ở max. Khi một actor/card resource consumption
khác cap hoặc requirement còn thiếu UNKNOWN, R có missingness/interval; không
gán denominator0. P thiếu HP không tự coi khỏe/đang chết.

H đo outcome của cả opportunity: boss lấy match Khiên hoặc phá Sword sweep target
thì giảm/zero H. Boss chỉ còn match khác nhưng không thể chứng minh own followup
tồn tại thì H là conditional/UNKNOWN, không full credit. Pre-boss setup score
chỉ diagnostics và candidate diversity, không cộng thẳng vào utility cuối.

Starting continuation rule **PROPOSED**: `H = 0.5 * Q_profile(best supported
legal own followup)` trên từng residual board. Q nằm[0,1]; dùng
`max(F_followup, mean(targets))` với target set cố định theo bảng dưới.

| Profile/stage | Targets trong Q, tính trên followup/residual state |
|---|---|
| SIMPLE / CAREFUL | D, R, P |
| Chịu đấm ăn xôi resource/setup | R, S |
| Chịu đấm ăn xôi post-skill | D, P |
| Demon | S, R, P |
| Mega Icarus | R, S, P |
| Bú win | H=0; board continuation chỉ vào B để không credit hai lần |

S là normalized known setup/effect progress: Demon physical Sword trong valid
sweep/reference Sword; Mega effective seal trong đúng30-cell scope/reference
seal; Skill Rush known selected-condition value/reference của condition. Clip
[0,1]. Actual-resource condition dùng deficit R thay S. Reference lấy immutable
setting có unit đúng và dương; invalid/không applicable thì S unsupported,
không tự đặt denominator1. Settings ở đây là normalization reference, không là
eligibility gate. Scoped sufficiency cho F=1 nên3 Kiếm không bị reference4 khóa.
Thiếu target/F thì giữ interval/missingness trên fixed target set, không bỏ
component rồi renormalize để tạo lợi thế; essential comparison nhạy thì baseline.
B2 hiện thực mapping theo source catalog, freeze version trước tuning; không
dùng một số Q opaque không giải thích hoặc credit future chưa supported.

Score một branch là utility của root ở mục7, với H/B tiếp cận được sau reply và
T/L/X phản ánh reply đó. Không cộng full utility của followup lần nữa: future
value đã discount trong H; B chỉ credit phần team opportunity chưa nằm trong H.
Followup resource chỉ chấm phần deficit mới trên residual state, không root
balance đã credit. Không recursion dài/discount hai lần hoặc giả ta chắc còn lượt.

F là objective bonus, D là effect proxy; ledger không đếm lại resource giữa hai
feature. Nếu model nói trận đã terminal sau root, không credit H/B/future gems;
vẫn lưu stress continuation nếu certificate conditional. R đã credit root gain
thì continuation chỉ credit phần mới, không chấm cả total state balance lần nữa.

## 6. Boss reply, tranh chấp setup và bounded lookahead

### 6.1. Nominal model, không fake boss certainty

Sau root, enumerate replies còn tính được bằng solver hiện có.
Nominal policy C-BOSS-SWORD:
1. Có known legal Sword-producing reply thì ưu tiên nhóm này.
2. Chọn lượng **effective Sword** lớn nhất từ direct + known cascade trong model.
   Đây là định nghĩa working của “nhiều Kiếm”; physical count vẫn log riêng,
   hiệu ứng khác hoặc ranking actual boss khác là model mismatch.
3. Giữ **mọi tie** đạt max; không lấy tie có lợi nhất cho ta.
4. Không có Sword: secondary gem priority chưa được user xác định đầy đủ;
   coi các non-Sword reply tính được là alternatives, không giả boss sẽ tránh Khiên.

Refill có thể tạo Sword option mới/cascade hoặc thay geometry: nominal result là
conditional. Boss skill/card/PASS/actor-specific passive ngoài coverage giữ flag
UNMODELED, không tuyên bố đã enumerate mọi action. Không dùng policy BASIC của
ta như proof boss dùng đúng code đó.

### 6.2. Đánh giá setup theo ta → boss → ta

Với mỗi root:
- root immediate effects/resource/trigger;
- từng nominal reply và residual board;
- own followup **hợp lệ/đủ nguồn và chi phí** trên residual board;
- mất Khiên/Sword/setup, survival/turn access, threat và UNKNOWN;
- adverse alternatives: boss chọn reply khác/tie khác, refill tương tác, model
  Sword-first không đúng. Không gán xác suất tùy ý cho alternatives.

Có thể giữ Sword làm mồi để boss chọn nó và để lại Khiên. Chỉ credit H khi
geometry và reply set còn hỗ trợ own shield action sau đó. Nếu một max-Sword tie
cũng ăn Khiên/phá vùng setup thì phải hiện contest/fragility; không bảo đảm dụ thành công.
Boss Sword damage là chi phí thật của bait: penalty T tăng theo pressure,
không thưởng mồi vô điều kiện ở HP thấp. Outcome sufficient ngay có thể tốt
hơn setup dài, nhưng certificate không là input authority.

Không cộng favorable refill để “dụ boss chừa Khiên”; không lập chuỗi swap cố
định nhiều lượt. Chỉ thực thi root; fresh turn lập kế hoạch lại theo flow cũ.

### 6.3. Coverage, aggregate và budget

All legal root swaps xét lớp đầu, baseline luôn có; không prune do count<setting.
Refine starting cap8 diverse roots: incumbent, immediate sufficiency, resource,
protection, retained setup và bait variants nếu có. Node/scenario/time caps giao
A3/B3;32 stress scenarios/candidate chỉ là starting research cap.

Within nominal reply ties, dùng conservative score của các tie đã cover, không
optimistic best-tie. Ties chưa xét→unexamined count; H/future value không được
claim guaranteed trừ khi có bound/invariant bao phủ phần chưa xét.

```text
U_nominal = min(score(root -> nominal reply -> supported own followup))
U_stress_min = min(score của adverse scenarios đã xét)
U_final = U_nominal - lambda * max(0, U_nominal - U_stress_min)
```

Không đủ probability thì không gọi U_nominal là expected return hoặc U_stress_min
là worst game bound/CVaR. Chưa refinement có thể dùng one-step utility, đánh dấu
coverage và không credit unexamined followup. Thêm lớp chỉ nếu không vượt budget;
completed result trước deadline mới có thể dùng, còn lại baseline theo A1.

## 7. Utility v1 và context adaptation

Hard gates/transition và objective tier của A1 đứng trước score. Nếu một scoped
supported model thực sự chứng minh root hoàn thành mục tiêu ngay, không có
conflicting outcome trong scope, terminal outcome đó trội hơn trì hoãn vô ích.
User-calibrated nominal sufficiency chỉ nhận F bonus, không tự là proof cho
dominance tier hoặc observed WIN; Bú win local death không phải terminal team WIN.

```text
U = 12*F + wR*R + wD*D + wP*P + wH*H + wB*B
    - wT*T - wX*X - wL*L - wE*E
```

Đây là starting rule/weights **PROPOSED_FOR_OFFLINE**, chưa tối ưu/accepted live.

| Profile/context | wR | wD | wP | wH | wB | wT | wX | wL | wE |
|---|---:|---:|---:|---:|---:|---:|---:|---:|---:|
| SIMPLE |3|5|2|2|0|4|2|2|1|
| CAREFUL |3|4|4|2|0|6|4|3|1|
| Skill Rush resource/setup |5|2|3|6|0|4|3|3|1|
| Skill Rush post-skill finisher |2|6|3|2|0|4|3|2|1|
| Demon Aegis |3|5|3|6|0|4|3|4|1|
| Mega Icarus |5|5|4|6|0|5|3|4|1|
| Bú win |0|0|0|1|6|0|3|3|1|

Context tags không hard authorize action. Skill Rush history phải exact session;
Bú win B/L là team-opportunity semantics riêng, không chỉ đảo dấu solo survival.

Adaptation trên profile solo, dùng continuous context:
- `pressure = max(1 - hp_ratio, known_boss_threat)`, clipped[0,1].
- `cost_gap = mean(current_actual_deficit / actual_requirement)`.
- wR nhân(1+cost_gap); wP nhân(1+2*pressure); wT nhân(1+2*pressure).
- wH nhân(1-0.5*pressure); wX nhân(1+pressure).
- lambda khởi đầu0.25*(1+pressure), CAREFUL0.35*(1+pressure), clipped[0,0.75].

Bú win giữ profile weights và lambda0.25 khởi đầu, không dùng self-HP pressure
để áp solo survival. Team-board risk/uncertainty vẫn vào B/L/X theo intent;
context team chưa supported giữ missingness, không giả team đang an toàn.

Context thiếu→interval/dependency, không dùng hp=100% hoặc pressure=0 ngầm.
Phần không thiết yếu có thể bỏ có nhãn; nếu override thay đổi khi vary essential
missing/context/order/policy assumption thì không claim strong benefit, retain
baseline hoặc chọn phương án có evidence đủ. Sensitivity không có nghĩa cấm
tất cả risky/UNKNOWN actions; risk trade-off vẫn mềm và theo mục tiêu profile.

Weights/config freeze theo run/evaluation version. Adaptation là hàm định nghĩa
từ snapshot, không online training hoặc tự rewrite weights/preferences.
F/certificate đủ không tự bypass hard gates hoặc buộc fire nếu supported downside
khác làm action kém hơn. Không điểm “save energy” giả cho một SWAP cũng tốn1 turn;
energy/WIN và throughput đo ở E1.

## 8. Mục tiêu/stage từng profile

| Profile | Context/stage và quyết định cần so sánh | Identity/boundary giữ |
|---|---|---|
| SIMPLE | Damage, actual resource deficit, protection, PASS/mandatory; Sword-first là reference | Không đổi loadout/ordinary card source hoặc legality |
| CAREFUL | Cùng candidates, pressure/uncertainty penalty lớn hơn; healthy có thể aggressive | Không generic ban UNKNOWN hoặc HP hard switch |
| Chịu đấm ăn xôi | Resource→setup→fire opportunity→post-skill continuation; compare earlier fire/protect vs wait | Actual cost/source/turn closure/history/QTE giữ; settings/gem preservation advisory |
| Demon Aegis | Immediate passive burst, Rage-supported sufficiency, contested setup, bait and retained Shield | Sweep geometry/passive family đúng; action vẫn ordinary SWAP, không thêm click thẻ/QTE |
| Mega Icarus | Resource/seal/effect quality, health pressure, repeated skill; early protection/fire vs healthy setup |30-cell seal scope, actual cost/source, Evolution/continuation và click-only/QTE family theo capability giữ |
| Bú win | Board feed-boss/team intent, resource turnover, local-death team-wait | No auto-solo survival; current Coop/NORMAL/NONE/no damage-card and action family gates; live baseline pending |

Demon ordinary Sword consumption là tactical cost cho setup, không universal
hard ban mới trong REASONING; có thể được xét vì consuming obligation/survival
và evidence. BASIC order không đổi; [late b6 addendum](../../board_resolution.md)
đã mô tả mandatory least-consuming Sword fallback, nên không dùng câu “never”
của policy report cũ để xóa accepted fallback.

Skill/CAST effects thiếu support thì không tự đặt D/P=0 để buộc SWAP thắng:
giữ opaque baseline action hoặc fallback cả comparison cần effect đó.
No-safe != no-legal. Mandatory turn không cho PASS; no legal roots tiếp tục
technical path existing. Shared Evolution branch/reads và state transition giữ A1.

## 9. Comparator, decision gate và explanation

Fixed `score_bucket = floor(U_final/0.01)`, bucket width0.01 **PROPOSED**.
Sắp xếp total order: bucket giảm → essential evidence/support tốt hơn → risk phù
hợp profile (solo threat thấp, Bú win theo team intent) → X thấp → objective
progress tốt → execution cost thấp → fixed action family/id/canonical coordinates.
Không pairwise epsilon comparator hoặc random tie.

Evidence key là weakest essential dependency rank trong scope: VERIFIED_FOR_SCOPE4,
EMPIRICAL_VALIDATED3, USER_CALIBRATED2, CONDITIONAL_MODEL1, UNKNOWN0; availability/
scope conflict xử lý trước rank. Origin không tự là support rank. Canonical
fallback order dùng ordinal family/source ID rồi numeric coordinates với swap
endpoints đã sort; không phụ thuộc enum numeric value hoặc input enumeration order.

Baseline retention gate tách khỏi comparator: khác baseline cần complete/valid/
supported proposal, explicit reason và score gap >=0.05 **PROPOSED** trên cùng
scale/evaluation coverage. Baseline thiếu score do effect unsupported thì không
bịa score0; retain opaque baseline trừ khi có scope chứng minh comparison.
Near-tie/essential assumption-sensitive/unexamined critical region → retain
baseline, vẫn log vì sao. Same input/work budget/version determinism; wall-time
truncation khác không hứa same refinement tree.

Explanation tối thiểu:
- baseline action/why; selected action và objective;
- setting/reference nào được cân nhắc khác;
- physical/effective/point quantities và support/calibration scope;
- nominal boss reply/ties, lost/retained setup và admissible followup;
- score components, gap/bucket, adverse scenario/downside/UNKNOWN;
- work/deadline/fallback; không score gap→probability thắng;
- “3+5 đủ theo calibration account” khác “WIN đã observed”.

## 10. Completion và handoff

Deliverables: doc này + [scenario matrix](5a2_scenario_matrix.md), canonical
clarification/user calibration/boss-contested planning, [report](../reports/5a2_report.md).
A3 nhận schema/evidence/assumptions để thiết kế telemetry/deadline/evaluation.
B1 map actual DTO inputs không thêm reads; B2 utility/scenarios; B3 reply/cert scope;
D3 kiểm Demon narrow calibration/bait, D4 Mega anti-rigidity, E1 hiệu quả thật.

Không code/test/live, build/commit/push/tag/version. Product spec defined không
đồng nghĩa runtime available. Đủ gate → next [5A.3](../prompts/5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md)
rồi **STOP**, không tự thực hiện bước đó.
