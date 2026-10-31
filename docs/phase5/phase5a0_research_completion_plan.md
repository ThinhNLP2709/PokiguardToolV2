# Phase 5 — Nghiên cứu bổ sung và plan cơ chế REASONING

Ngày: **2026-10-09 — Asia/Saigon**.

Trạng thái: **RESEARCH / PROPOSED PLAN — KHÔNG TRIỂN KHAI CODE**.

Đây là snapshot nghiên cứu 5A.0 bổ sung. Các ghi chú “chưa thực thi” bên dưới
thuộc thời điểm nghiên cứu; tiến độ thực hiện từ 5A.1 theo [STATUS](STATUS.md).

Tài liệu này hoàn thiện [nghiên cứu 5A.0 ban đầu](phase5a0_reasoning_research.md).
Phạm vi là đánh giá mức đầy đủ của nghiên cứu, nghiên cứu thêm các điểm còn
thiếu và chốt một phương án triển khai theo milestone. Đây chưa phải thay đổi
quy tắc gameplay đã được chấp nhận trong tài liệu canonical.

**Làm rõ theo yêu cầu mới nhất:** settings chiến thuật là tham khảo; giữ mục tiêu
PlayStyle và BASIC accepted, không giữ mọi threshold/heuristic thành hard rule.
Flow read/capture/action/ACK v1.2.4 không đổi. [EXECUTION_CONTRACT](EXECUTION_CONTRACT.md)
và [ROADMAP](ROADMAP.md) chốt bộ20 bước/prompt thay roadmap rút gọn cũ. Hiện chỉ
chuẩn bị tài liệu; chưa triển khai bất kỳ bước nào.

## 1. Nghiên cứu ban đầu đã đủ chưa?

**Đủ để chọn hướng hybrid planner; chưa đủ để triển khai toàn bộ cơ chế suy
luận như mô tả.** Báo cáo ban đầu chọn đúng các thành phần, nhưng chưa giải
quyết cách chúng phối hợp khi mục tiêu, rủi ro, bằng chứng và deadline xung đột.

Các thiếu sót cần bổ sung là:

| Điểm còn thiếu | Vì sao ảnh hưởng cơ chế suy luận | Quyết định trong plan này |
|---|---|---|
| Định nghĩa REASONING hoạt động thế nào | Một tổng điểm có trọng số tự nó chưa tạo ra kế hoạch hay dự đoán | So sánh phương án, phân tích phản hồi, stress scenario, giải thích và lập kế hoạch lại |
| Ranh giới biết/chưa biết | Có thể biến kết quả trong simulator thành khẳng định về trận thật | Mỗi feature/prediction mang loại bằng chứng và phạm vi hiệu lực |
| Damage, survival, terminal value | Chưa có căn cứ tính xác suất thắng hoặc kết luận một reply gây chết | Bản đầu dùng proxy có nhãn; mở lethality gate chỉ trong phạm vi đã kiểm chứng |
| Boss policy và tập action của boss | Worst Sword reply chưa phải worst mọi hành động của boss | Tách Sword reply coverage khỏi boss-action coverage |
| UNKNOWN nhiều ô và chuỗi refill | Một số kịch bản đã xét không đại diện cho mọi refill | Stress scenario không được gọi là cận toàn cục hoặc xác suất |
| Thứ bậc mục tiêu | Risk đứng sau efficiency có thể cho phép đổi sinh tồn lấy vài tài nguyên | Tách điều kiện bắt buộc khỏi utility; risk và lợi ích mềm được xét cùng tầng |
| So sánh SWAP/PASS/card | Các action có thời gian, điều kiện và hiệu ứng khác nhau | Action contract riêng; action chưa có effect model giữ quyết định baseline |
| Dừng tính và fallback | Hết thời gian, state đổi và input đã gửi là ba tình huống khác nhau | Deadline tuyệt đối; fallback chỉ trước dispatch và trên state còn hợp lệ |
| Đánh giá hiệu quả | Replay/shadow không quan sát kết quả thật của nước chưa đi | Tách kiểm chứng logic, kiểm chứng model và so sánh kết quả live |
| Học từ log | Thắng/thua không cung cấp nhãn cho mọi candidate | Thu outcome có attribution, giữ giới hạn counterfactual, học offline có điều kiện |

Sau bổ sung này, **đã đủ cơ sở thiết kế phiên bản REASONING đầu tiên và plan
Phase 5**. Những phần còn UNKNOWN được chuyển thành mốc thu bằng chứng, không
được giải quyết bằng cách tự giả định công thức hoặc phân phối của game.

## 2. Nghiên cứu bổ sung và hệ quả thiết kế

### 2.1. Nhiều mục tiêu: constraint trước, utility sau

Các phương pháp đa mục tiêu phân biệt việc dùng trọng số với việc áp thứ bậc
hoặc ngưỡng cho từng mục tiêu. Vì vậy không nên dùng một tổng điểm duy nhất để
cho phép mọi đánh đổi. Phase5 dùng phân biệt này để giữ actual validity và mục
tiêu PlayStyle, đồng thời cân nhắc lại heuristic chiến thuật. [Roijers và cộng sự, multi-objective sequential decision-making](https://www.cs.ox.ac.uk/people/shimon.whiteson/pubs/roijersjair13.pdf).

**Áp dụng cho Phase 5:** identity, actual legality và transition obligations là
constraint; threshold/fire/setup/Sword lock là chiến thuật được cân nhắc lại.
Bảo vệ, rủi ro và lợi ích cùng xét theo mục tiêu profile. Không đặt một quy tắc
sinh tồn chung lên Bú win.

### 2.2. Chưa biết xác suất: ưu tiên phân tích độ nhạy và kịch bản

Robust MDP xử lý bất định thông qua một tập mô hình có định nghĩa. Bảo đảm của
phương pháp phụ thuộc vào tập bất định và các giả thiết của mô hình. Không thể
lấy vài refill tưởng tượng rồi gọi giá trị thấp nhất là worst case của game.
[Nilim & El Ghaoui, robust MDP](https://people.eecs.berkeley.edu/~elghaoui/Pubs/RobMDP_OR2005.pdf).

**Áp dụng cho Phase 5:** khi chưa có phân phối refill, không tính expected win
rate, expected damage hay CVaR từ các mẫu tùy ý. Dùng scenario để phát hiện
điểm yếu của một candidate và kiểm tra quyết định có phụ thuộc quá nhiều vào
giả định chưa biết hay không. Mỗi kết luận phải nói rõ đã xét những gì.

### 2.3. Lookahead có ích, nhưng không vượt qua khoảng trống mô hình

POMCP cần một generative simulator có thể sinh state kế tiếp, observation và
reward. Không bắt buộc viết công thức xác suất tường minh, nhưng vẫn cần cơ chế
sinh các transition đáng tin cậy. Đây là lý do chưa chọn POMCP/MCTS đầy đủ cho
bản đầu. [Silver & Veness, POMCP](https://papers.nips.cc/paper_files/paper/2010/file/edfbe1afcf9246bb0d40eb4d8027d90f-Paper.pdf).

**Áp dụng cho Phase 5:** cho phép nhìn trước hữu hạn trên phần transition đã
có bằng chứng. Dừng mở nhánh khi hiệu ứng cần thiết chưa được mô hình hóa. Một
chuỗi tính được trong mô hình bỏ qua refill vẫn là kết luận có điều kiện nếu
refill thật có thể làm đổi thứ tự cascade hoặc vị trí gem.

Lập kế hoạch lại từ fresh state do flow hiện có cung cấp phù hợp nguyên lý
receding horizon; không thêm vòng đọc riêng. Nó giúp sửa kế hoạch khi observation
thay đổi, nhưng không tự biến một model thiếu
thành model chính xác. [Rosolia, Zhang & Borrelli, predictive control](https://www.annualreviews.org/content/journals/10.1146/annurev-control-060117-105215).

### 2.4. Ngân sách 4–6 giây là trần, không phải thời gian phải sử dụng

Nghiên cứu về metareasoning xem việc tính thêm là một quyết định có chi phí:
chỉ đáng làm nếu có khả năng cải thiện lựa chọn cuối. Đây là nguyên tắc phù
hợp với một lượt có deadline. [Hay và cộng sự, selecting computations](https://aima.cs.berkeley.edu/~russell/papers/uai12-meta.pdf).

**Áp dụng cho Phase 5:** trả sớm khi kết luận đã rõ hoặc các bước tính còn lại
không bổ sung bằng chứng. Không chạy đủ bốn giây để tạo cảm giác “thông minh”.
Thời gian dư không bù được thiếu thông tin về refill hoặc boss.

### 2.5. Baseline là điểm tựa; fallback không phải chứng minh không thua kém

SPIBB nghiên cứu việc bám baseline tại vùng dữ liệu thiếu, với bảo đảm dưới
các giả thiết cụ thể của bài toán và dataset. Phase 5 có thể học nguyên tắc
giữ baseline khi thiếu bằng chứng, nhưng không được nhận luôn bảo đảm lý thuyết
của thuật toán đó cho planner heuristic. [Laroche và cộng sự, SPIBB](https://proceedings.mlr.press/v97/laroche19a.html).

**Áp dụng cho Phase 5:** BASIC luôn là phương án tham chiếu. Một nước REASONING
khác BASIC cần lý do có thể kiểm tra. Có fallback vẫn phải đo chất lượng thật.

### 2.6. Đánh giá offline và học: tách bài toán một bước khỏi cả trận

Replay bandit trong nghiên cứu LinUCB dựa trên điều kiện của logging policy và
dữ liệu; không thể áp thẳng lên log deterministic rồi suy ra kết quả của các
nước chưa được chọn. [Li và cộng sự, contextual bandit](https://www.schapire.net/papers/www10.pdf).

Các hành động trong game còn thay đổi state và cơ hội của những lượt sau, nên
đánh giá cả policy là bài toán tuần tự. Các phương pháp OPE cho RL có thể hữu
ích về sau, nhưng cần dữ liệu và giả thiết phù hợp. [Jiang & Li, sequential off-policy evaluation](https://proceedings.mlr.press/v48/jiang16.html).

**Áp dụng cho Phase 5:** shadow đo disagreement, logic và prediction error.
Nó không đo được win rate phản thực của REASONING. Logged outcome chỉ gán cho
action thực sự xảy ra và chỉ trong phạm vi attribution được chứng minh.

## 3. Cơ chế được chọn

Tên mô tả: **planner chiến thuật theo tình thế, có constraint, phân tích rủi
ro và lookahead giới hạn**.

```text
state mới + cấu hình PlayStyle bất biến
  -> tình thế hiện tại và loại bằng chứng
  -> action hợp lệ + phương án BASIC
  -> actual validity và mục tiêu PlayStyle
  -> settings chiến thuật tham khảo, cân nhắc lại theo tình thế
  -> feature / utility theo profile
  -> phân tích phản hồi boss còn mô hình hóa được
  -> stress scenario và độ nhạy
  -> chọn phương án hoặc giữ BASIC
  -> existing preflight trước dispatch, không thêm read/capture
  -> input bình thường
  -> quan sát kết quả để lập kế hoạch lại
```

Cơ chế này phải thực hiện được bốn việc rõ ràng:

1. **Nhận diện tình thế:** đang thiếu chi phí, đang setup, có thể fire, cần bảo
   vệ, phải có consuming action, hoặc đang chờ transition đã gửi.
2. **So sánh phương án:** không chỉ giải thích nước tốt nhất mà còn nêu vì sao
   nó hơn BASIC hoặc phương án đứng thứ hai.
3. **Dự đoán có giới hạn:** ghi phản hồi tính được, phần chưa biết và điều kiện
   làm kết luận mất hiệu lực.
4. **Tự giới hạn:** dừng tính, giữ baseline hoặc fail closed đúng nguyên nhân.

Đây là phần khác biệt giữa REASONING và chỉ đổi tuple ranking thành tổng điểm.

## 4. Hai mức năng lực, cùng một kiến trúc

| Mức | Làm được | Chưa được tuyên bố |
|---|---|---|
| R1 — Model-limited tactical planner | So sánh resource/setup, known Sword reply, PASS baseline, uncertainty và các nhánh có điều kiện | Xác suất thắng, damage chính xác, tránh chết chắc chắn, tối ưu cả trận |
| R2 — Evidence-supported short-horizon planner | Thêm damage/effect/boss model đã kiểm chứng cho từng phạm vi; đánh đổi risk có căn cứ hơn | Bảo đảm ngoài phạm vi model hoặc trên game version chưa kiểm chứng |

R1 là mục tiêu bắt buộc đầu tiên. R2 được mở từng capability, không chờ một
simulator hoàn hảo cho toàn game. Learned ranker là thành phần tùy chọn, không
phải điều kiện để gọi R1 là REASONING.

## 5. Thứ bậc quyết định

### Tầng 0 — Tính hợp lệ kỹ thuật

Đúng session, actor, turn, board, actionability, freshness, deadline và trạng
thái executor. Invalid/stale/ambiguous identity không đi vào utility.

### Tầng 1 — Nghĩa vụ gameplay và transition

Giữ actual cost/cooldown/source, Evolution, QTE, authoritative consuming-action/
PASS legality, continuation và terminal handling. Chỉ nghĩa vụ thực từ game và
accepted executor là hard; heuristic tên “mandatory fire” không tự thành hard
rule. EVOLVE không được chấm như SWAP kết thúc lượt; state tiếp theo do existing
transition/read flow cung cấp.

### Tầng 2 — Mục tiêu PlayStyle và settings tham khảo

Giữ identity/mục tiêu profile, không tự đổi lối chơi. Giữ Sword, tích chi phí,
bảo toàn seal, fire threshold và thứ tự emergency là gợi ý để so sánh theo HP/
resource/boss/uncertainty. Planner được chọn khác gợi ý với reason/evidence,
không ghi đè settings. “Strategy envelope” không khóa mọi heuristic.

### Tầng 3 — Utility mềm và rủi ro

Chấm tiến độ và rủi ro cùng tầng, sau constraint. Không để một tầng efficiency
cao hơn mọi penalty risk. “Lethal” chỉ là predicate bắt buộc khi model có đủ
bằng chứng; nếu chưa có, giữ nhãn UNKNOWN và dùng proxy có giải thích.

### Tầng 4 — Chọn ổn định

Khi utility gần nhau, ưu tiên bằng chứng mạnh hơn, risk thấp hơn, tiến độ đúng
mục tiêu, input cost thấp hơn và cuối cùng là thứ tự action/toạ độ cố định.
Giữ BASIC khi khác biệt chưa có ý nghĩa đủ rõ.

## 6. Mục tiêu theo PlayStyle

| PlayStyle | Mục tiêu | Phạm vi REASONING tối ưu | Ngoại lệ phải giữ |
|---|---|---|---|
| SIMPLE | Thắng, rồi giảm chi phí trận | Offensive gem, tài nguyên, protection, boss reply | Không biến mọi UNKNOWN thành cấm tuyệt đối |
| CAREFUL | Thắng với mức phạt rủi ro cao hơn | Như SIMPLE, nhưng nhạy hơn với HP và uncertainty | HP thấp chưa tự chứng minh next-hit lethal |
| Chịu đấm ăn xôi | Chu kỳ chi phí/setup/skill/continuation để thắng | Đóng thiếu hụt, độ bền setup, bảo vệ và fire theo tình thế | Actual cost/source/continuation hard; Sword lock/fire threshold advisory |
| Demon Aegis Farm | Trigger passive đúng mục tiêu, tiết kiệm năng lượng | Shield line, Sword bị passive tác động, residual board | Phải dùng effect model riêng của passive, không lấy resource tally thay damage |
| Mega Icarus | Duy trì chu kỳ chi phí/seal/skill, hồi máu và thắng | Seal progress, bảo toàn qua reply, turnover, emergency | Scope seal, skill source, click-only và Evolution contract |
| Bú win | Kết quả thắng của đội; local death là chiến thuật trung gian | Giữ/tạo cơ hội Sword cho boss và xử lý tài nguyên theo profile | Không áp survival cá nhân; chờ đồng đội đúng lifecycle |

BASIC giữ nguyên emergency/hotfix accepted. Nhánh REASONING được cân nhắc lại
setup/fire/emergency với evidence ngay trong contract5A.1/5A.2, không đòi scope
đổi gameplay riêng chỉ để override threshold. Mega Icarus không bị buộc tiếp
tục setup tới seal target khi phương án hợp lệ khác có căn cứ bảo vệ tốt hơn.
Không cần viết lại solver/PlayStyle hoặc đổi execution flow.

Bú win cần baseline acceptance riêng trước khi đánh giá REASONING live. Kết
quả của các profile solo không chứng minh hiệu quả trong Coop.

## 7. Feature và utility: chốt cách xây dựng

### 7.1. Feature phải kèm ý nghĩa và bằng chứng

| Nhóm | Nội dung chính | Lưu ý |
|---|---|---|
| Context | Profile, stage, HP ratio, resource deficit, skill readiness | Thiếu HP không được gán 0 hoặc 100% |
| Immediate board effect | Direct/cascade resource, multiplier, clear geometry | Resource tally không đồng nghĩa damage/HP delta |
| Setup | Known count, seal count, threshold progress, preserved gem | Phân biệt full board và seal |
| Boss reply | Direct/indirect Sword, max known take, resource opportunity | Ghi rõ coverage chỉ Sword hay rộng hơn |
| Uncertainty | UNKNOWN cells/depth, interacting regions, unexamined cases | Không dùng số scenario đã chạy như xác suất bao phủ |
| Continuation | Known/conditional followup, setup sau reply | Không credit gem refill chưa quan sát |
| Execution | Input family, preflight reserve, remaining deadline | Không suy ra action cost chỉ từ số click |
| Attribution | Source state/action/session và model/profile version | Outcome phải nối được về đúng action |

Mỗi prediction có một trong các loại:

- `VERIFIED_FOR_SCOPE`: được kiểm chứng trong phạm vi cơ chế/version cụ thể;
- `CONDITIONAL_MODEL`: đúng nếu các giả thiết đã ghi của model giữ được;
- `EMPIRICAL_VALIDATED`: dự đoán thực nghiệm đã qua kiểm định ngoài tập học;
- `UNKNOWN`: không có đủ bằng chứng.

Một số lượng gem biết chắc trong snapshot và một dự đoán HP đều không thể dùng
chung một cờ confidence chung chung.

### 7.2. Công thức utility bản đầu

Trong cùng mục tiêu PlayStyle, dùng các thành phần chuẩn hóa theo context:

```text
U = weighted(resource progress, setup progress, offense, protection)
    - weighted(known boss threat, uncertainty exposure)
```

- Resource progress đo tỷ lệ thiếu hụt được đóng; tài nguyên đã đủ không nhận
  thêm readiness credit.
- Setup progress đo tiến gần target tham khảo đúng scope, có penalty làm mất
  setup; target chưa đạt không cấm action hợp lệ khác.
- Offense R1 đo giá trị gem/effect proxy được hỗ trợ, chưa gọi là expected HP.
- Protection R1 là proxy theo tình thế; chỉ đổi sang predicted HP/shield gain
  khi effect model đã kiểm chứng.
- Known threat và uncertainty là hai thành phần riêng; không cộng chúng rồi
  đặt tên thành “xác suất chết”.
- Chuẩn hóa dùng thang cố định có version theo loại feature/profile. Không đổi
  thang theo min/max của tập candidate mỗi lượt, vì thêm một candidate không
  liên quan có thể làm đổi thứ hạng cũ.
- Missing feature có cờ riêng. Chỉ bỏ thành phần không thiết yếu; thiếu thành
  phần bắt buộc của quyết định thì giữ BASIC hoặc fail closed theo lớp lỗi.

**Trọng số khởi tạo đề xuất**, dùng để bắt đầu offline tuning, chưa phải các
trọng số đã chứng minh tối ưu:

| Profile/stage | Resource | Setup | Offense | Protection | Known threat penalty | Uncertainty penalty |
|---|---:|---:|---:|---:|---:|---:|
| SIMPLE | 3 | 1 | 5 | 2 | 4 | 2 |
| CAREFUL | 3 | 1 | 4 | 4 | 6 | 4 |
| Skill Rush trước skill | 5 | 5 | 0 | 2 | 4 | 3 |
| Demon Aegis | 1 | 4 | 5 | 2 | 4 | 3 |
| Mega Icarus chu kỳ thường | 5 | 5 | 0 | 3 | 5 | 3 |

Các con số là tỷ lệ tương đối sau chuẩn hóa, không dùng trực tiếp với raw Mana,
HP hoặc gem count. Skill Rush continuation có bảng stage riêng. Bú win có
utility riêng theo mục tiêu feed-boss; không chỉ đảo dấu survival penalty.

Actual legality/transition obligations xác định trước utility. Emergency/fire/
setup priorities là phần so sánh thích ứng, không chốt action rồi chấm điểm cho
có. Context adaptation có định nghĩa/version; không chỉ thay if/elif cứng bằng
weights cứng. Cùng settings có thể chọn khác khi tình thế khác. Tuning freeze
trước evaluation.

Mọi SWAP thường cùng tiêu thụ một local turn nên không tạo một “energy saving”
score tức thời giả. Hiệu quả năng lượng được đo ở cấp trận/run; tiến độ skill
chỉ là proxy để tìm cơ hội cải thiện nó.

## 8. Thuật toán online bản đầu

1. Nhận immutable snapshot từ existing flow; xác định context/actual obligations.
   Fast path chỉ cho nghĩa vụ thật, không khóa tactical threshold.
2. Lấy quyết định BASIC làm incumbent và lưu lý do baseline.
3. Sinh đầy đủ legal root swaps bằng solver hiện có; bổ sung PASS/card chỉ khi
   capability của action đó được chứng minh.
4. Áp hard validity và objective; settings là tactical reference. Không cắt root
   swap chỉ vì heuristic thấp hoặc khác gợi ý threshold.
5. Chấm toàn bộ root candidate bằng feature có version; giữ phương án tốt
   nhất về progress, protection và setup để tránh search chỉ nhìn một nhóm.
6. Refinement ưu tiên top 8 root candidate, luôn kèm BASIC nếu chưa nằm trong
   nhóm. Đây là giới hạn tính khởi tạo, không phải tuyên bố top 8 chứa optimum.
7. Phân tích các boss reply còn mô hình hóa được. Nếu xét followup của ta, giới
   hạn ở chuỗi `ta → boss → ta`, ghi điều kiện và dừng tại ranh giới model.
8. Chạy stress scenario có ngân sách, ưu tiên vùng UNKNOWN tương tác với Sword
   hoặc setup. Giới hạn khởi tạo 32 scenario/candidate; phần chưa xét vẫn UNKNOWN.
9. Kiểm tra độ nhạy: lựa chọn có phụ thuộc vào một giả thiết có lợi chưa chứng
   minh, một feature thiếu hay trọng số sát ngưỡng không?
10. Nếu quyết định có đủ bằng chứng và cải thiện có ý nghĩa cho mục tiêu profile,
    trả candidate; nếu chưa phân biệt được, giữ BASIC.
11. Caller dùng existing preflight, không thêm read/capture. Sau transition thật
    do existing flow cung cấp, bỏ nhánh dự báo cũ và lập kế hoạch lại.

Trong R1, favorable refill không được cấp điểm tài nguyên, skill readiness hay
fire threshold. Scenario bất lợi dùng để phát hiện fragility; score nhỏ nhất
trong scenario đã xét chỉ là **stress score trong tập đó**.

Near-tie được thực hiện bằng score bucket cố định có version thay vì comparator
“hai số cách nhau ít hơn epsilon” từng cặp. Điều này giữ thứ tự tổng nhất quán.
Đề xuất bucket ban đầu là 0,01 sau chuẩn hóa; phải kiểm tra độ nhạy khi chốt
5A.2. Replay ghi work budget/refinement đã hoàn tất: tie-break cố định không
tự bảo đảm search bị ngắt ở thời điểm khác nhau sẽ cho cùng kết quả.

## 9. Boss, refill và damage: nghiên cứu thực nghiệm có đầu ra rõ

### 9.1. Boss action coverage

Tách ba câu hỏi:

1. Boss **có thể** làm gì trên board/state này?
2. Mỗi action đó có hiệu ứng gì?
3. Boss **có xu hướng chọn** action nào?

Liệt kê Sword reply chỉ trả lời một phần câu1. Model xác suất lựa chọn không
được bypass validity hoặc gọi risk UNKNOWN là safe. Sword risk phục vụ trade-off
theo profile, không mặc nhiên cấm mọi exposure.
Boss Mana/Rage/skill/pass và action chưa quan sát mang status riêng.

Đầu ra nghiên cứu thực nghiệm là capability manifest theo boss/profile/version,
coverage, prediction error và giới hạn sử dụng. R1 không chờ manifest đầy đủ.

### 9.2. Refill

R1 dùng uncertainty features và adverse scenarios, gồm cả nhiều UNKNOWN tương
tác, automatic match, cascade đổi geometry và multiplier chưa biết. Không có
mẫu nào được đưa vào current board như observation thật.

Muốn mở stochastic lookahead, cần dataset refill có attribution theo vị trí,
turn, version và điều kiện có thể ảnh hưởng sinh gem. Phải kiểm tra correlation
và drift; tần suất biên của từng gem chưa chứng minh các ô độc lập. Refill
distribution là capability tùy chọn, không phải yêu cầu của R1.

### 9.3. Damage và effect model

Không suy công thức từ tên field, attack stat hoặc một HP delta. Cần tách actor,
gem/effect source, multiplier, Rage, shield, heal/drain, passive, skill và thứ
tự effect. Nếu observation không tách được action của ta khỏi boss/đồng đội thì
attribution là UNKNOWN.

Ưu tiên phạm vi hẹp: một loại effect, một profile/boss/version. Có thể xây
predictor thực nghiệm hoặc interval có đánh giá coverage trên dữ liệu giữ lại.
Interval thực nghiệm vẫn không phải bảo đảm vật lý tuyệt đối. Lethality gate
chỉ mở khi loại bằng chứng và sai số cho phép sử dụng nó ở quyết định đó.

Quan sát dùng snapshot/log sẵn trong existing read-only flow, không thêm read/
capture/poll để nuôi planner. Không packet manipulation, direct gameplay API
hoặc memory write. Thiếu dữ liệu giữ UNKNOWN hoặc đề xuất scope riêng.

## 10. PASS, card và fallback

PASS là zero-input action nhưng vẫn giao lượt và board cho phía tiếp theo.
Nó phải có baseline threat/setup như một phương án cạnh SWAP, đồng thời giữ
nguyên quyền PASS authoritative và actual consuming-action obligations.

Card chỉ được so utility với board action khi effect model của card đủ dùng.
Ở lần tích hợp đầu, card có actual transition obligation hoặc effect chưa biết đi qua
baseline contract. Không để giả định heal/damage của card lấn át điều kiện
chi phí, cooldown, source identity hay QTE.

| Tình huống | Hành vi |
|---|---|
| Thiếu thời gian tính, worker lỗi, evidence không đủ | BASIC trên fresh valid state nếu chưa dispatch và còn đủ thời gian input |
| State/source đổi trong khi tính | Hủy kết quả; theo existing controller/read/preflight flow, không thêm vòng reread/planner retry |
| Identity/actionability invalid hoặc không xác minh được | Fail closed theo controller contract |
| Đã gửi input, ACK chưa rõ | Giữ action ownership và recovery hiện có; không fallback bằng một input khác |
| Không có legal move | Đi qua dead-board/technical contract, không biến thành PASS heuristic |
| Local pet chết trong Bú win | Lifecycle/team-wait contract, không áp auto-survival hoặc recovery của solo |

“Fallback luôn bật” chỉ đúng trong lớp lỗi planner trước dispatch. Nó không
phải giấy phép vượt qua state validity hay gửi action thứ hai.

## 11. Deadline, worker và tab AI

Giữ configured budget mặc định 4 giây, hard cap 6 giây. Budget thực lấy từ
remaining time tại thời điểm observation, trừ tuổi observation, bất định timer,
chi phí còn phải làm và reserve theo action/input mode. Không trừ lại chi phí
đọc state đã được phản ánh trong timer mới.

Phải đo riêng snapshot/preprocessing, candidate/refinement, IPC, final
revalidation, dispatch và ACK/transition. SWAP, card, Evolution và QTE có timing
contract khác nhau; không dùng một số reserve duy nhất cho tất cả.

Planner trả sớm khi đã xong các bước hữu ích. Khi deadline đến, chỉ dùng
incumbent đã đánh giá đủ; không xuất candidate đang dở.

Kiến trúc chọn pure planner sau worker boundary: immutable snapshot, job identity,
bounded queue/cancel, không provider/capture/input authority hoặc foreground lease.
Process isolation ưu tiên khi compute/model có hang risk, phải prove overhead/
cleanup; không bắt process chỉ vì tên AI. Tắt REASONING không khởi worker/model
nặng; shadow không chờ baseline dispatch. Kết quả muộn/sai source bị bỏ; caller
giữ existing action path. Capability chưa có, cần prove B4/C3/F1.

Tab AI ban đầu có BASIC/REASONING, budget, diagnostics và shadow switch cho
development. Hiển thị lý do, threat/uncertainty, thời gian và fallback; không
hiển thị “xác suất thắng” từ score gap. Chưa có nút training sau mỗi trận.

## 12. Telemetry và dataset

Một record quyết định cần nối được (full candidate trace có sampling/bounded
queue, không bắt mỗi lượt đồng bộ ghi toàn bộ):

- Immutable profile, stage, source session/turn/board và feature/model version;
- state đủ để replay decision, capability và trạng thái transition liên quan;
- tất cả root candidates, exclusions, BASIC choice, REASONING choice và scores;
- reply/scenario coverage, assumptions, work đã hoàn tất, deadline/fallback;
- input thực sự được gửi, action identity, ACK/terminal disposition;
- observation trước/sau action, boss transition nếu tách được, resource/HP delta;
- outcome toàn trận, năng lượng/thời gian/attempts và lý do kết thúc.

Lưu ít nhất ba loại nhãn khác nhau: observation thật của chosen action;
prediction của model; annotation/preference của người review. Không trộn
prediction và observation thành một ground truth.

Dataset chia theo match/session và thời gian, có version và profile strata.
Các candidate cùng một turn không được tách qua train/test. Holdout không dùng
để chỉnh trọng số. Retention phải giữ được evidence cần review mà không lưu
ảnh hoặc raw trace không giới hạn.

Mốc coverage trưởng thành tham khảo:200 distinct states từ ít nhất20 trận/profile,
cộng HP thấp, actual obligation, no-safe-move, PASS, skill-ready/high uncertainty.
Đây không phải gate cứng trước pilot kỹ thuật hay quyền tự chạy20 trận/profile.
A3 tách fixture/incident/shadow/live tiers, chốt coverage theo scope; số state
không chứng minh win-rate.

## 13. Đánh giá: thế nào mới gọi là tốt hơn BASIC?

### Bốn loại bằng chứng

| Loại | Có thể kết luận | Không thể kết luận |
|---|---|---|
| Offline replay | Constraint, repeatability theo work budget, ranking/explanation, incident handling | Kết quả thật của action khác log |
| Shadow | Latency, coverage, disagreement, prediction error của action đã xảy ra | Win rate/energy counterfactual của REASONING |
| Model validation | Accuracy/calibration trong phạm vi holdout | Chính xác với mọi boss/version |
| Bounded live comparison | Kết quả thực của policy trong cohort đã chạy | Generalization ra tất cả PlayStyle |

### Metrics bắt buộc

1. Safety/reliability: wrong-session/turn, stale/duplicate input, deadline miss,
   third PASS, invalid action, unconfirmed dispatch và technical abort.
2. Gameplay: win rate, loss reason, tổng năng lượng của **mọi attempt / số WIN**,
   thời gian active / WIN và wins / giờ. Không bỏ chi phí trận thua khỏi mẫu số.
3. Theo profile: time-to-cost-ready, setup turns, skill cycles, seal preservation,
   passive trigger, known boss threat và emergency outcomes.
4. Planner: wall-clock tail latency, fallback reasons, uncertainty coverage và
   số lần thay BASIC có lợi/bất lợi còn xác định được.

### Thiết kế so sánh

Đóng băng profile, boss, game version, input mode và planner weights. So sánh
theo block các trận, không chuyển policy giữa một trận để gọi là A/B độc lập.
Refill thật không thể replay cùng seed nếu chưa có capability đó.

Chạy ablation: BASIC → utility → thêm reply/risk → thêm refinement → optional
ranker. Nếu một lớp không đem lợi ích thì bỏ lớp đó. Không mặc định search sâu
hơn hoặc model lớn hơn sẽ tốt hơn.

Đề xuất mục tiêu sản phẩm để chốt trong 5A.3: cải thiện ít nhất 5% năng lượng/WIN
hoặc throughput trong cohort phù hợp, giữ win rate theo non-inferiority margin
đóng băng trước thí nghiệm. Margin1 điểm phần trăm chỉ là đề xuất nghiên cứu,
chưa được người dùng chấp nhận, không phải quyền giảm tỷ lệ thắng. Chưa chốt
margin/baseline/power thì không kết luận non-inferiority/PROMOTE.

Smoke10/arm và cap50/arm là con số tham khảo; bounded protocol A3/E1 chốt batch
thực tế, không cấp quyền chạy tất cả profile. Không con số nào mặc nhiên đủ cho
kết luận thống kê. Sample size của gameplay gate
phải tính từ baseline, margin, độ biến thiên và khoảng tin cậy 95%. Nếu dữ liệu
chưa phân biệt được, kết quả là INCONCLUSIVE và BASIC vẫn là production default.

## 14. Lộ trình học và model local

R1 không cần model. Ưu tiên tune utility từ replay/incident và xác nhận bằng
shadow/live theo gate. Không update production sau từng trận.

Nếu cần model, ưu tiên predictor cho outcome gần hoặc residual value trên
feature candidate. Chosen-action data không tự tạo nhãn pairwise về kết quả của
mọi nước còn lại. Preference annotation cũng chỉ chứng minh preference trong
phạm vi review, không tự chứng minh khả năng thắng.

Offline RL có thể lỗi khi chọn action ngoài vùng dữ liệu; đó là lý do phải
kiểm tra support, drift và rollback trước khi học từ log. [Fujimoto và cộng sự, BCQ](https://proceedings.mlr.press/v97/fujimoto19a.html).

Linear/tree/ranker nhỏ được so với utility baseline trước. ONNX Runtime là
deployment option sau khi model chứng minh lợi ích; CPU/GPU inference support
không chứng minh accuracy hoặc deadline của ứng dụng. [ONNX Runtime documentation](https://onnxruntime.ai/docs/).

POMCP/MCTS đầy đủ và online exploration không phải deliverable bắt buộc của
Phase 5. Chỉ mở nghiên cứu đó khi generative model và dữ liệu hỗ trợ đã đủ.

## 15. Roadmap Phase 5 chi tiết thay sơ đồ cũ

[ROADMAP](ROADMAP.md) và [PROMPT_INDEX](PROMPT_INDEX.md) là lịch triển khai chính
thức của plan này:20 bước chính,3 learned-model tùy chọn và2 template.

| Chặng | Bước | Phạm vi |
|---|---|---|
| Contract/spec | 5A.1–5A.3 | Docs only; baseline boundary, adaptive features/utility, telemetry/deadline/evaluation |
| Offline core | 5B.1–5B.4 | Snapshot/replay → utility → bounded refinement → isolated runner/log |
| Integration | 5C.1–5C.4 | Shadow → AI config → parity/fault acceptance → existing preflight selector |
| Profile pilots | 5D.1–5D.5 | SIMPLE/CAREFUL → Skill Rush → Demon → Mega → conditional Coop |
| Evaluation | 5E.1–5E.2 | Bounded efficacy comparison → reliability/fallback soak |
| Closure | 5F.1–5F.2 | Exact packaged artifact acceptance → final docs/rollback, STOP |
| Optional model | 5L.1–5L.3 | Offline → shadow → pilot; explicit request only, quay E1 trước E2 |

Đây là plan chưa thực thi. D là profile acceptance bắt buộc theo declared scope,
**không còn dùng D làm nhánh model** như sơ đồ nghiên cứu cũ. Bú win có closure
BASELINE_ONLY minh bạch nếu Coop baseline/effect thiếu; R2 chỉ bật scope đã prove.
Không cần full world model để R1 tiếp tục, nhưng essential evidence thiếu thì
profile/action reasoning giữ baseline.

Đọc [EXECUTION_CONTRACT](EXECUTION_CONTRACT.md) và [ROUTER](ROUTER.md) cho gate/
exceptions/return path. Không tự triển khai khi tạo prompt, không auto chuyển
phase/live/commit/push/build. Learned model không tự mở vì utility không cải thiện.

## 16. Câu hỏi đã chốt và giới hạn còn lại

**Đã chốt trong plan:** hybrid planner; R1 trước R2; constraint trước utility;
utility theo profile/stage; scenario có nhãn; lookahead ngắn; BASIC incumbent;
deadline động và dừng sớm; telemetry trước học; đánh giá live riêng; model tùy
chọn; rollout theo capability.

**Chưa thể khẳng định bằng nghiên cứu tài liệu:** công thức damage thật, phân
phối refill thật, policy boss thật, latency toàn pipeline và mức cải thiện
gameplay. Plan đã chỉ định cách thu và đánh giá những bằng chứng đó. Không cần
chờ trả lời hết mới làm R1 shadow, nhưng không được dùng tên REASONING để bỏ
qua các giới hạn này.

Mốc tiếp theo của plan là 5A.1. Lượt hiện tại dừng ở nghiên cứu và hoàn thiện
plan; không viết planner, sửa runtime, gửi input, commit hay push.
