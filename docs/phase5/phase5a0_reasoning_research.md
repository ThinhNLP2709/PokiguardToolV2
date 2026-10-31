# Phase 5A.0 — Nghiên cứu kiến trúc REASONING

Ngày nghiên cứu: 2026-10-09 (Asia/Saigon)

Trạng thái: **RESEARCH COMPLETE — NO GAMEPLAY CODE CHANGE**

Đây là snapshot nghiên cứu 5A.0. Các ghi chú “chưa thực thi” bên dưới thuộc thời
điểm nghiên cứu; tiến độ thực hiện từ 5A.1 trở đi theo [STATUS](STATUS.md).

Ghi chú bổ sung 2026-10-09: trạng thái trên là hoàn tất nghiên cứu chọn hướng
ban đầu, chưa có nghĩa cơ chế triển khai đã được đặc tả đầy đủ. Xem
[nghiên cứu bổ sung và plan Phase 5](phase5a0_research_completion_plan.md) để có
ranh giới R1/R2, decision layers, uncertainty, bounded lookahead và acceptance
gates được hoàn thiện. Theo yêu cầu mới nhất, [EXECUTION_CONTRACT](EXECUTION_CONTRACT.md)
và [ROADMAP](ROADMAP.md) chốt flow v1.2.4 không đổi, settings chiến thuật advisory,
fallback/log isolation và bộ prompt chi tiết. Chúng thay các đề xuất cũ chưa phù
hợp; canonical hiện tại mô tả BASIC, không hạn chế ý định REASONING mới của người dùng.

## 1. Mục tiêu và tiền đề đã được người dùng xác nhận

`REASONING` là một bộ máy chung chạy trên lối chơi được chọn. Nó không thay thế
PlayStyle và không đổi tên các lối chơi BASIC hiện có.

Các tiền đề đầu vào của nghiên cứu:

1. Lối chơi hiện tại là mục tiêu/baseline. REASONING thêm đánh giá tình thế;
   threshold/priority chiến thuật là tham khảo, không khóa cứng quyết định.
2. Mỗi fresh turn dùng state mới do existing flow cung cấp rồi plan lại;
   không thêm reader/capture/poll và không giả định refill chưa xuất hiện.
3. Mục tiêu cấp cao nhất là thắng. Utility phụ thuộc mục đích của PlayStyle:
   farm ưu tiên năng lượng/thời gian sau khi giữ xác suất thắng; boss mạnh ưu
   tiên sống sót và thắng; Mega Icarus ưu tiên nhịp skill hồi máu và gây sát
   thương.
4. Một lượt có tổng cộng 14 giây. Ngân sách suy luận mong muốn là 4–6 giây sau
   khi trừ thời gian đọc state, kiểm tra fresh-state, delay/input và dự phòng an
   toàn. Lượt mở màn thiếu thời gian được phép dùng BASIC ngay.
5. Rủi ro/PASS phải phụ thuộc tình thế: HP, tài nguyên hai bên, khả năng boss ăn
   Kiếm trực tiếp/gián tiếp, vùng refill UNKNOWN, skill/cứu nguy và số lượt bỏ
   authoritative. Không biến một ví dụ rủi ro thành cấm tuyệt đối cho mọi trận.

## 2. REASONING hiện có gì trong V2

### 2.1 Nền tảng có thể tái sử dụng

V2 đã có phần lớn feature extractor và simulator cần cho planner:

- `board_simulator.evaluate_all_moves()` xét đủ 112 cặp kề và chỉ trả swap tạo
  match hợp lệ;
- mỗi `MoveEvaluation` có direct/cascade/total resource, multiplier hiệu dụng,
  số chain, bàn sau mô phỏng, exposure UNKNOWN, Sword potential và mọi boss
  Sword reply xác định được;
- policy trace đã lưu toàn bộ candidate, candidate được chọn, tài nguyên, risk,
  độ sẵn sàng skill và nguyên nhân chọn;
- simulator không bịa refill: ô ngoài 64 viên đã biết trở thành `UNKNOWN`;
- BASIC đã có nhiều hàm xếp hạng riêng theo PlayStyle. Đây là dữ liệu nền tốt,
  nhưng hiện chúng là các tuple ưu tiên cứng, chưa phải utility chung.

Tham chiếu code:

- `src/pokiguard_v2/board_simulator.py` — simulator và legal candidates;
- `src/pokiguard_v2/basic_policy.py` — CandidateTrace, rank và BASIC engine;
- `tools/basic_auto_bot.py` — `policy_decision` log toàn bộ candidate trace.

Microbenchmark cục bộ trên fixture chuẩn
`reference/phase2c2a_basic_policy_fixture.json`, Python 3.11.9, 300 lần:

```text
legal moves: 11
evaluate_all_moves median: 22.901 ms
p95: 25.443 ms
max: 31.861 ms
```

Kết luận: sinh và mô phỏng toàn bộ nước hợp lệ một lớp hiện rất nhỏ so với ngân
sách 4–6 giây. Nút thắt của Phase 5 không phải là tìm swap hợp lệ; đó là mô hình
giá trị dài hạn, uncertainty, dự đoán boss và kiểm soát deadline.

### 2.2 Khoảng trống bắt buộc phải giữ đúng tên

- Chưa có mô hình damage -> HP đáng tin cậy cho từng loại gem/skill. Trace hiện
  ghi `UNKNOWN_NO_LETHALITY_MODEL`.
- Chưa có xác suất refill chính thức. Simulator chỉ có risk bound/hypothetical
  completion, không có distribution được chứng minh.
- Chưa có model hành vi boss. Code hiện có thể enumerate reply hợp lệ, đặc biệt
  Sword reply, nhưng chưa ước lượng boss sẽ chọn reply nào.
- Log chỉ quan sát kết quả của hành động đã chọn. Nó không tự tạo nhãn cho kết
  quả dài hạn của mọi hành động không được chọn.
- Win/loss cuối trận là reward trễ và bị trộn bởi nhiều lượt, refill, boss và
  skill. Không thể kết luận một candidate riêng lẻ đúng/sai chỉ từ nhãn trận.

## 3. Nghiên cứu các hướng

### 3.1 AI local mini/LLM chọn nước trực tiếp

**Khả thi về kỹ thuật, không phù hợp làm controller đầu tiên.** Có thể chạy
model local bằng một worker process; ONNX Runtime hỗ trợ inference CPU/GPU và
`InferenceSession` cục bộ. Tuy nhiên một LLM/mini neural model nhận board thô sẽ
phải học lại legal move, cascade, multiplier và constraint mà code đã tính chính
xác. Nó cũng khó bảo đảm deadline, tính lặp lại và lý do chọn.

Nếu sau này dùng model local, đầu vào nên là feature vector của các candidate,
không phải ảnh hoặc prompt text. Model chỉ dự đoán value/rank; hard guard và
legal move vẫn thuộc code. Model nên chạy process riêng, có deadline và fallback
BASIC. ONNX chỉ là runtime triển khai; nó không làm model trở nên đúng và tài
liệu ONNX Runtime cũng yêu cầu ứng dụng tự kiểm chứng accuracy/performance.

Nguồn: [ONNX Runtime documentation](https://onnxruntime.ai/docs/),
[Python API](https://onnxruntime.ai/docs/api/python/api_summary.html).

### 3.2 Học online sau từng trận

**Không phù hợp ở giai đoạn đầu.** Agent chỉ thấy reward của hành động đã chọn,
không thấy counterfactual của các nước còn lại. Thắng/thua là reward rất trễ;
một trận thua không xác định được lượt gây lỗi. Cho model tự exploration trong
farm thật còn có thể giảm tỷ lệ thắng trong thời gian học.

Contextual bandit phù hợp hơn supervised learning thuần khi chỉ có feedback cho
action đã chọn, nhưng muốn đánh giá offline đáng tin cậy phải thu thập dữ liệu
theo logging policy và propensity phù hợp. Offline RL còn có lỗi extrapolation
khi policy mới chọn hành động ngoài phân phối log cũ.

Nguồn: [LinUCB/contextual bandit paper](https://www.schapire.net/papers/www10.pdf),
[BCQ/offline RL paper](https://proceedings.mlr.press/v97/fujimoto19a/fujimoto19a.pdf),
[Offline RL tutorial](https://arxiv.org/abs/2005.01643).

### 3.3 Search/MCTS/POMDP đầy đủ

Tree search có deadline là nền tảng hợp lý cho game có nhiều action. UCT là một
thuật toán anytime: càng còn thời gian càng mở rộng search. POMCP cho thấy online
planning có thể làm việc với partial observability bằng sampling và black-box
simulator.

Tuy nhiên V2 chưa có simulator đầy đủ cho refill, damage và boss policy. Dùng
MCTS/POMCP ngay sẽ buộc ta bịa distribution hoặc học một world model chưa có dữ
liệu. MuZero có thể học model dùng cho planning, nhưng quy mô huấn luyện và yêu
cầu dữ liệu của hướng đó vượt xa nhu cầu Phase 5 hiện tại.

Nguồn: [UCT paper](https://sites.ualberta.ca/~szepesva/papers/cg06-ext.pdf),
[POMCP paper](https://papers.nips.cc/paper_files/paper/2010/file/edfbe1afcf9246bb0d40eb4d8027d90f-Paper.pdf),
[MuZero paper](https://arxiv.org/abs/1911.08265).

### 3.4 Weighted reasoning + receding-horizon planning

**Đây là hướng phù hợp nhất cho Phase 5 đầu tiên.** Mỗi local turn dùng state
mới từ flow đã có, plan hữu hạn theo scope simulator/evidence, chọn action,
quan sát state thật ở lượt sau rồi tính lại. Đây cùng nguyên lý receding horizon:
không giữ một kế hoạch dài khi ngoại lực/refill đã thay đổi state.

Weighted reasoning không có nghĩa bỏ luật. Nó dùng ba tầng:

1. hard validity/safety constraints;
2. mục tiêu chiến thuật của PlayStyle;
3. utility mềm để so sánh candidate còn lại.

Nguồn tổng quan về replanning từ state mới và uncertainty:
[Data-Driven Predictive Control for Autonomous Systems](https://doi.org/10.1146/ANNUREV-CONTROL-060117-105215).

## 4. Kiến trúc được đề xuất

Tên làm việc:

```text
Constraint-Guided Anytime Receding-Horizon Planner
```

### 4.1 Pipeline một lượt

```text
fresh authoritative state
  -> PlayStyle objective + advisory settings
  -> legal actions + function/card actions
  -> hard constraints
  -> candidate feature extraction
  -> deterministic simulation
  -> boss-reply / UNKNOWN risk evaluation
  -> play-style utility
  -> bounded anytime refinement
  -> evidence/fallback gate
  -> existing fresh-state preflight (không thêm read/capture)
  -> normal input executor
```

`Strategy envelope` chỉ giữ mục tiêu/identity, không giữ mọi heuristic. Mega
Icarus vẫn hướng tới chu kỳ skill hiệu quả, nhưng seal/fire/Sword priorities là
tham khảo. REASONING được chọn phương án hợp lệ khác có căn cứ tốt hơn theo
HP/resource/boss/uncertainty; không phải đợi vượt một HP threshold mới được
ngừng setup. BASIC hotfix và execution flow giữ nguyên.

### 4.2 Hard constraints

Không cho model/utility vượt qua:

- swap phải legal trên đúng current board;
- state/session/turn/freshness/actionability hợp lệ;
- không PASS ở lượt đầu;
- không tạo lần PASS thứ ba;
- actual consuming-action obligation để tránh bị đá;
- actual cost/cooldown/source/card/evolution/QTE contract;
- deadline còn đủ cho input và ACK;
- fail-closed khi identity hoặc state không chắc chắn.

### 4.3 Utility có thứ bậc

Không nên gom mọi thứ vào một tổng điểm duy nhất ngay từ đầu. Dùng thứ bậc:

1. **Hard validity:** actual legality, actor/turn/source, PASS/transition/input.
2. **Objective:** mục tiêu PlayStyle, không tự đổi profile hoặc team intent.
3. **Adaptive utility:** progress/setup/offense/protection và risk cùng xét theo
   tình thế; settings là reference, không efficiency cao hơn mọi penalty risk.
4. **Stable selection:** evidence/support, risk theo objective, progress, input
   cost và fixed action order; near-tie có thể giữ baseline.

Terminal/lethality chỉ dùng như fact trong scope model đã prove; thiếu thì proxy/
UNKNOWN. Không dùng survival cá nhân chung cho Bú win. Xem bản bổ sung mục5–8
và spec5A.2 tương lai cho normalization, context adaptation và score bucket.

### 4.4 Profile mục tiêu ban đầu

| PlayStyle | Mục tiêu REASONING chính |
|---|---|
| SIMPLE/CAREFUL | tối đa hóa khả năng thắng; CAREFUL phạt risk/HP mạnh hơn |
| Chịu đấm ăn xôi | đạt tài nguyên + setup skill sớm, giảm năng lượng/lượt sau khi survival đạt |
| Demon Aegis Farm | tìm Shield line phá đủ Sword với ít năng lượng nhất |
| Mega Icarus | giữ nhịp skill, hồi máu, gây damage dần; survival cao hơn tiết kiệm lượt |
| Bú win | team win là terminal goal; chết có kiểm soát là strategy goal, không dùng survival của pet làm mục tiêu chung |

Không được áp một bộ trọng số farm cho mọi PlayStyle.

### 4.5 Boss prediction và refill UNKNOWN

Ba mức bằng chứng:

1. **Known/conditional transition:** enumerate reply tính được trên bàn mô phỏng;
   scope hiện mạnh ở Sword, không đồng nghĩa mọi boss action/refill đã biết.
2. **Empirical boss model:** sau khi log đủ actual boss transition, ước lượng
   boss ưu tiên action nào trong từng context. Model chỉ điều chỉnh expected
   value trong scope được validate; không bỏ validity hoặc gọi UNKNOWN là safe.
3. **UNKNOWN refill:** Phase 5 đầu tiên dùng interval/scenario risk, không gán
   một viên cụ thể. Sau khi có dataset refill đủ lớn mới cân nhắc distribution
   thực nghiệm và phải kiểm tra drift theo game version.

Mỗi lượt mới xóa cây/kế hoạch phụ thuộc state cũ và lập kế hoạch lại từ state
authoritative. Không dùng dự báo để thay thế current board.

### 4.6 PASS/risk là một action có giá trị

PASS phải được chấm như một action: bàn không đổi được giao cho boss. So sánh
PASS với candidate rủi ro bằng cùng feature set:

- HP hiện tại và damage budget;
- Shield/Health/Drain và skill cứu nguy;
- boss Mana/Rage;
- effective Sword mà boss có thể lấy;
- Sword/setup còn lại sau worst/expected reply;
- số PASS authoritative và mandatory action;
- utility mục tiêu của PlayStyle.

REASONING có thể chấp nhận Sword/UNKNOWN exposure khi trade-off có evidence phù
hợp profile; cũng có thể PASS nếu hợp lệ và tốt hơn. HP ratio không tự chứng
minh chịu được damage. Actual PASS legality vẫn hard, không bị utility override.

## 5. Deadline 14 giây

Planner dùng deadline tuyệt đối, không `sleep` để đủ 4–6 giây:

```text
available = remaining_at_observation
            - observation_age_and_timer_uncertainty
            - remaining_preflight_input_ack_budget
            - safety_reserve

reasoning_budget = clamp(configured_budget, 0, available)
```

Đề xuất mặc định ban đầu:

- configured reasoning budget: `4.0s`;
- hard maximum: `6.0s`;
- input/ACK safety reserve: không thấp hơn cổng hiện tại của production;
- nếu budget thực còn dưới ngưỡng tối thiểu: dùng BASIC trên cùng fresh state;
- lượt đầu local: BASIC fast path nếu opening/read state đã tiêu tốn budget;
- thuật toán phải giữ best-so-far candidate và trả được ngay khi deadline đến.

Tách measurement read/candidate/search/preflight/input và timer từ evidence sẵn
có, không thêm đọc state để đo. Không trừ hai lần read cost nếu remaining timer
đã phản ánh nó. 4–6s là compute cap trong decision slice hiện có, không delay cố
định; shadow không chờ planner. Log bounded/nonblocking, không thêm sync I/O.

## 6. Tie-break là gì

Tie-break là quy tắc chọn khi hai candidate có utility bằng nhau hoặc gần bằng
nhau. Nếu không có tie-break ổn định, cùng một state có thể chọn hai nước khác
nhau, làm replay/test rất khó.

Đề xuất thứ tự tie-break:

1. evidence/risk phù hợp mục tiêu profile hơn; lethality chỉ khi model đủ;
2. ít UNKNOWN exposure hơn;
3. tiến gần mục tiêu PlayStyle hơn;
4. thời gian/input cost thấp hơn;
5. tọa độ move theo thứ tự cố định.

Tie-break không phải chiến thuật chính và không cần random. Nó chỉ làm kết quả
tái lập theo cùng input/work budget khi utility không phân biệt hai nước;
search bị cắt ở thời điểm khác có thể khác phần refinement đã hoàn tất.

## 7. Tab AI và local worker

Thêm tab `AI` là khả thi, nhưng tab nên quản lý planner/worker chứ không chứa
logic gameplay trong UI thread.

Thiết kế hợp lý:

- `Độ thông minh`: Cơ bản / Suy luận;
- `Ngân sách suy luận`: mặc định 4 giây, tối đa 6 giây;
- `Chế độ`: Weighted Planner; Learned Ranker chỉ mở khi đã accepted;
- hiển thị PlayStyle objective được suy ra, không cho tạo profile mâu thuẫn;
- `Fallback về BASIC khi hết giờ/lỗi`: luôn bật ở giai đoạn đầu;
- diagnostics: số candidate, thời gian, best/second score, evidence/support, risk,
  lý do chọn và fallback reason;
- cờ dev `Ghi dữ liệu học`; không lưu ảnh mặc định;
- nút training nếu có phải chạy offline trên snapshot log, không cập nhật model
  production ngay sau từng trận.

Pure worker boundary phải cô lập lỗi, có immutable snapshot/jobs, bounded queue,
cancel và late-result rejection. Process là lựa chọn khi compute/model hang risk,
phải prove overhead/cleanup; không bắt process chỉ vì AI. Worker không provider/
capture/input authority. Tắt reasoning không load worker/model nặng; caller dùng
existing preflight/action path. Diagnostics riêng chỉ khi overhead đạt, nếu không
shared namespace/filter; log failure không block baseline.

## 8. Lộ trình học từ log

### Giai đoạn 1 — Không model

- weighted planner chạy shadow;
- BASIC vẫn phát input;
- lưu score của mọi candidate và lựa chọn giả định của REASONING;
- replay incidents để chỉnh utility; actual hard guards giữ contract.

### Giai đoạn 2 — Dataset có outcome gần

Mỗi action cần liên kết:

- before state và mọi candidate feature;
- chosen action, BASIC/REASONING score;
- ACK/terminal status;
- authoritative board tiếp theo;
- actual HP/Mana/Rage/Shield/damage/resource delta;
- boss transition quan sát được;
- skill/evolution/pass state;
- terminal win/loss, lượt và năng lượng toàn trận.

Ưu tiên nhãn gần: prediction error, boss Sword take, survival delta, resource và
setup progress. Nhãn thắng/thua toàn trận chỉ là một phần reward, không gán trực
tiếp cho từng move.

### Giai đoạn 3 — Learned ranker nhỏ

Huấn luyện offline model tuyến tính/tree/ranker trên candidate features. Model
đầu tiên chỉ dự đoán residual/value bổ sung cho utility; không tự sinh action.
Chạy replay và shadow A/B trước. Nếu đóng gói model, ONNX Runtime là một lựa chọn
triển khai, nhưng chỉ thêm dependency sau khi benchmark package/RAM/latency.

### Giai đoạn 4 — Online adaptation có kiểm soát

Chỉ cân nhắc contextual bandit hoặc model update theo batch sau khi có:

- logging propensity/exploration contract;
- đủ dữ liệu theo từng PlayStyle/boss/game version;
- offline evaluation;
- rollback/model versioning;
- giới hạn exploration không phá tỷ lệ thắng.

Không training trực tiếp sau từng trận ở production trong Phase 5 đầu tiên.

## 9. Kiến trúc file được đề xuất cho bước triển khai sau

```text
src/pokiguard_v2/intelligence.py
src/pokiguard_v2/reasoning_features.py
src/pokiguard_v2/reasoning_utility.py
src/pokiguard_v2/reasoning_planner.py
src/pokiguard_v2/reasoning_worker.py       # chỉ khi cần process/model
src/pokiguard_v2/reasoning_telemetry.py
tools/replay_reasoning.py
tests/test_reasoning_features.py
tests/test_reasoning_utility.py
tests/test_reasoning_planner.py
tests/test_replay_reasoning.py
```

Không nhồi REASONING vào `basic_policy.py`. BASIC nên được giữ làm baseline và
fallback đã chứng minh ổn định. Các primitive simulator/risk được tách/tái sử
dụng thay vì viết solver mới.

## 10. Roadmap Phase 5 chi tiết

Sơ đồ nghiên cứu rút gọn cũ đã được thay bằng [ROADMAP](ROADMAP.md) và
[PROMPT_INDEX](PROMPT_INDEX.md): 5A.1–A.3 đặc tả, 5B.1–B.4 offline core,
5C.1–C.4 shadow/config/parity/selector, 5D.1–D.5 profile pilots,
5E.1–E.2 efficacy/soak, 5F.1–F.2 package/closeout.

Nhánh learned model nay là **5L.1–L.3**, tùy chọn và chỉ mở khi người dùng yêu cầu;
5D là acceptance từng PlayStyle, không còn chỉ model. L3 quay E1 trước E2.
Mỗi bước một prompt/report/gate và STOP; hiện tất cả bước triển khai NOT_STARTED.

## 11. Kết luận

Giải pháp phù hợp nhất là **hybrid planner**, không phải LLM mini và chưa phải
online RL:

```text
existing PlayStyle objective + advisory tactical settings
+ hard production validity + unchanged operational flow
+ weighted multi-objective utility
+ bounded online lookahead
+ replanning mỗi fresh turn
+ BASIC deadline/error fallback
+ optional learned ranker sau khi log đủ tốt
```

Hướng này tận dụng simulator/trace đã có, giải thích được mỗi quyết định, đáp
ứng ngân sách lượt và cho phép học dần mà không đặt độ ổn định hiện tại vào một
model chưa được chứng minh.

## 12. File canonical cần cập nhật sau khi 5A.1 được duyệt

Chưa cập nhật trong 5A.0:

1. `docs/DECISIONS.md` — hợp đồng sản phẩm REASONING;
2. `docs/gameplay_rules.md` — mục `Logic suy luận`;
3. tạo `docs/reasoning_gameplay_policy.md` — contract kỹ thuật;
4. `docs/basic_gameplay_policy.md` — ranh giới BASIC/fallback;
5. `docs/CURRENT_STATE.md` — trạng thái và bằng chứng Phase 5.
