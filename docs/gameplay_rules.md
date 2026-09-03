# Gameplay Rules — nguồn tham chiếu chuẩn (BASIC)

File này là **nguồn sự thật** cho logic chơi game do người dùng đặc tả.
Mọi thay đổi hành vi trong `src/pokiguard_v2/basic_policy.py` phải khớp với
file này. Bản triển khai kỹ thuật (simulator, trace, fail-closed gates) nằm ở
`docs/basic_gameplay_policy.md`.

## 1. Cấu hình lối chơi

Ta có 2 lựa chọn lối chơi: **Đơn giản**, **Cẩn thận**.

Ta có 2 lựa chọn ưu tiên mana: **Tiến hóa**, **Chưởng và không tiến hóa**.

Ta có 2 lựa chọn độ thông minh: **cơ bản**, **suy luận**.

## 2. Hai thẻ chức năng

1. **Thẻ tiến hóa** — dùng để tiến hóa pet giúp tăng máu, tăng dame (có thể),
   tăng giới hạn mana, nói chung là để mạnh hơn. Tiêu hao 160 mana. Khi dùng
   thẻ tiến hóa thì được tính là **chức năng**, nên sau khi dùng vẫn có thể đi
   tiếp được nước trên bàn cờ.
2. **Thẻ chưởng** — tiêu tốn 160 mana để ra chưởng gây sát thương cho boss.
   Khi dùng thẻ chưởng thì **tính là 1 lượt**, nên không thể ra nước đi trên
   bàn cờ.

## 3. Rule trong game

- Không được bỏ 3 lượt liên tiếp. Nếu bỏ 2 lượt và đi nước trên bàn hoặc là
  chưởng thì sẽ được reset và tính lại.
- Khi vào game lượt đầu tiên là lượt của chúng ta.
- Hầu hết các ván khi mới vào đều có kiếm.
- Max nộ được set cố định là **250**; cứ 100 nộ thì khi ăn kiếm dame sẽ nhiều
  hơn.

## 4. Các định nghĩa

- **Match-3 tiềm năng**: không phải là 3 viên cùng 1 hàng mà là 1 tổ hợp các
  viên có thể xếp ngang/dọc tạo thành match-3, match-4, …
- **Vùng kiếm nguy hiểm**: những vùng có kiếm đang liên kết với nhau nhưng vẫn
  còn cách nhau vài đơn vị nên chưa thể tạo được match-3 tiềm năng; hoặc là
  kiếm ở cùng 1 hàng nhưng cách nhau 1 cột (hàng 2 cột 1, hàng 2 cột 3) — nếu
  chúng ta ăn dọc match-3 ở cột 2 thì khả năng rơi kiếm cho boss là 2/3.
- **Nước đi an toàn**: các nước có thể tính toán được trên 64 viên trên bàn cờ
  mà sau khi ăn không chừa lại match-3 kiếm tiềm năng cho boss. Thường là
  những nước ngang tính toán được, hoặc những nước dọc cách các vùng kiếm nguy
  hiểm 2 đơn vị.
- **Nước đi nguy hiểm**: thường là các nước đi dọc với những phần chưa biết mà
  khi ăn có thể tạo thành match-3 kiếm tiềm năng. Nước ngang dễ tính toán hơn;
  nước dọc sập 1 lần 3 viên nên độ khó cao hơn, và cũng không biết được phía
  trên bàn cờ là những viên gì sẽ rơi xuống.
- **Ăn combo / ăn chuyền**: đi những nước tối ưu đạt được combo *và* đạt được
  viên mục tiêu, không đơn thuần chỉ ăn viên mục tiêu.
- **Nước đi tính toán được**: các nước đi nằm từ hàng 3 trở xuống — lúc này khi
  ăn ở khu vực dưới thì chúng ta có thể tính toán được một phần bàn cờ sau khi
  ăn xong.

## 5. Logic cơ bản (độ thông minh = cơ bản)

Quyết định đi nước được đưa ra bằng cách xét **lần lượt** theo các bước sau.

### Bước 1 — Thẻ tiến hóa

Sử dụng thẻ tiến hóa nếu đủ 3 yếu tố: **chưa tiến hóa** + **160 mana** + **cài
đặt ưu tiên mana là tiến hóa**. Thì cứ thử tiến hóa cho tới khi nào thành công.

Lượt đầu tiên vẫn phải đi một nước trên bàn. **Từ lượt của chúng ta lần thứ 2
trở đi**, nếu thẻ/pet tiến hóa hiện tại được game xác nhận, chưa tiến hóa thành
công và mana đủ chi phí runtime, thì Bước 1 phải được xét trước mọi nước trên
bàn. Production dùng cùng ngưỡng hành động inclusive 1 giây; không tự trì hoãn
tiến hóa chỉ vì còn dưới 10 giây.

Nếu cài đặt ưu tiên là chưởng thì bỏ qua — toàn trận không tiến hóa.

Ngoại lệ kết liễu: khi máu hiện tại của boss nhỏ hơn hoặc bằng ngưỡng cấu hình
`cast_when_boss_hp_below` (mặc định 30000, `0` là tắt), **không tiến hóa**, kể
cả khi đang chọn ưu tiên tiến hóa và đã đủ mana. Lúc này giữ tài nguyên để kết
liễu bằng kiếm hoặc chưởng.

Xét thẻ tiến hóa đầu vì đây là lá chức năng: sau tiến hóa vẫn có thể đi tiếp
được; nếu có tiến hóa nhưng không đi nước vẫn không tính là bỏ lượt.

Ngoại lệ an toàn 2/3: EVOLVE không được xem là hành động reset lượt bỏ. Khi
server đã báo 2/3, phải ưu tiên một SWAP hoặc CAST có tiêu thụ lượt để tránh bị
đá; nếu không còn đủ thời gian thì chuyển sang recovery.

> Xác định bỏ lượt **theo data game**, không tự count bằng code.

### Bước 2 — Ăn kiếm

Ưu tiên hàng đầu trên bàn cờ là ăn kiếm. Nếu trên bàn cờ có các nước ăn được
kiếm thì phải ăn.

Lúc ăn kiếm chúng ta không chỉ ăn kiếm mà phải **suy luận các nước đi khác liên
quan để có cùng kết quả ăn kiếm**, chứ không ăn kiếm đơn thuần.

> Ví dụ: có kiếm x3 tại (hàng 2, cột 2), kiếm x1 tại (2,3), kiếm x3 tại (3,3),
> kiếm x1 tại (1,4) và kiếm x1 tại (1,5). Nhưng tại cột 4 khi xét xuống hàng 7
> có tổ hợp match-3 tiềm năng nộ ngang gồm: nộ x1 (7,4), nộ x1 (7,5), khiên x1
> (7,6), nộ x1 (7,7). Khi ăn khiên (7,6) ⇄ nộ (7,7) thì cũng kéo theo ăn kiếm
> (mục tiêu), đạt được combo nhiều và tối ưu nhất.

Nếu trên bàn có 2 hoặc nhiều nước kiếm liên kết với nhau và có thể tính toán
được, hãy chọn nước đi mà khi ăn có thể **phá thế trận mà không chừa lại kiếm
nào cho boss**. Nếu không có nước nào phá được — ăn nước nào cũng chừa — thì
hãy ăn nhiều nhất có thể.

Chúng ta có data 64 viên: khi ra nước phải suy diễn xem sau khi ăn với data đã
biết thì có chừa lại kiếm hay không để mà né. Trừ trường hợp bất khả kháng (ăn
đường nào cũng chừa kiếm) thì bắt buộc chừa; còn không, phải cố gắng dựa trên
thông tin trên bàn mà không chừa lại match-3 tiềm năng cho boss.

Khái niệm "chừa kiếm" bao gồm cả hai đường đã tính được:

- trực tiếp: boss đổi một nước và match đó ăn kiếm ngay;
- gián tiếp: boss đổi một match tài nguyên khác, phần sập/combo deterministic
  từ 64 ô đã biết tiếp tục ăn kiếm.

Một nước chỉ được gọi là an toàn khi không để lại cả hai loại Sword reply trên.
Không suy đoán gem mới từ ngoài 64 ô; phần refill UNKNOWN vẫn theo nguyên tắc
fail-closed/risk hiện có. Kiểm tra UNKNOWN phải bao gồm cả chiều ngược lại:
nếu sau khi sập có một ô refill chưa biết nằm cạnh kiếm đã biết, phải thử đưa
kiếm đã biết đó vào ô refill. Nếu cách đổi ấy hoàn tất match-3 kiếm từ các viên
đã biết còn lại thì nước hiện tại là nguy hiểm, kể cả khi giả sử chính viên
refill là kiếm sẽ khiến nó tự ăn ngay trong cascade.

Ngoại lệ cho **duy nhất một nước kiếm**: nếu ăn nước đó chỉ lấy được lượng kiếm
hiệu dụng nhỏ hơn lượng kiếm mà một Sword reply deterministic sau đó trao cho
boss, không bắt buộc ăn ngay. Policy trước hết tiếp tục các nhánh tài nguyên với
một nước an toàn thật sự, hoặc PASS khi game-owned idle state xác nhận còn quyền
bỏ lượt. Nếu PASS không dùng được, policy chỉ được cố ý giữ thế kiếm bằng một
**Sword-hold** ở khu vực khác khi mô phỏng chứng minh rằng mọi Sword reply đã
biết của boss đều để lại cho lượt kế tiếp của ta lượng kiếm hiệu dụng lớn hơn
lượng boss vừa lấy. Sword-hold là ngoại lệ chiến thuật có kiểm chứng, **không**
được gắn nhãn nước an toàn; UNKNOWN không được dùng làm bằng chứng có lợi.

Nếu đang ở lượt bắt buộc, ưu tiên Sword-hold đã chứng minh; nếu không có thì
chọn nước có rủi ro kiếm thấp nhất theo Bước 7.

### Bước 3 — Chưởng kết liễu, rồi tài nguyên

Có 1 cài đặt là **"Chưởng khi boss còn dưới hoặc bằng: 30000 máu"** (30k là con số có thể
cài đặt được trên UI; hiện chưa có UI nên để ở config, tạm 30k). Lúc này chỉ
cần **còn đủ 160 mana và không có kiếm thì chưởng**. Còn không đủ mana thì tiếp
tục xét ăn tài nguyên, nhưng **ưu tiên mana an toàn trước nộ** để sớm đủ chi phí
chưởng. Nếu không có mana an toàn thì các nhánh an toàn còn lại tiếp tục được
xét; không ép một nước nguy hiểm.

Nếu trên bàn không có kiếm **và** boss cũng còn hơn 30k máu, thì lúc này chúng
ta bắt đầu xem xét tình hình trận đấu — nhưng thường 2 bước trên tôi sẽ chọn
tài nguyên (mana hoặc nộ). 2 viên này có độ ưu tiên theo tình hình bàn cờ và
tài nguyên mà chúng ta đang có, theo tiêu chí **thiếu gì ăn đó, đầy rồi thì
thôi**.

Nếu trên bàn cờ có nhiều vùng kiếm nguy hiểm và có nước ăn nộ an toàn thì ăn nộ
(nếu nộ của bản thân dưới 100) — mục đích là tích đủ 100 để khi có kiếm thì ăn
kiếm sẽ được tăng dame. Nếu nộ đã full hoặc trên bàn không có nước đi nộ an
toàn thì chúng ta xét sang mana an toàn.

### Bước 4 — Ăn máu khi nguy

Nếu qua các bước trên vẫn chưa có nước đi, chúng ta tiếp tục xét theo tình
hình. Nếu **máu chúng ta thấp** (lối chơi *đơn giản*: dưới 30% tổng; lối chơi
*cẩn thận*: dưới 50% tổng) mà **máu boss còn nhiều (> 50%)**, thì tìm các nước
đi ăn máu an toàn để kéo dài cơ hội thắng.

### Bước 5 — Chưởng tích trữ, hút, khiên

Nếu không có nước ăn máu hoặc không cần thiết ăn máu, mà mana của chúng ta quá
nhiều **> 480 mana (3 lượt chưởng)**, thì dùng thẻ chưởng để tấn công nhằm mục
đích skip lượt và gây sát thương, và **chừa lại 2 lượt chưởng backup**.

Nếu mana ít hơn 480 thì check qua mana và nộ của boss:

- Boss có **mana > 160 và nộ > 100** → chọn viên **hút** để có xác suất hút
  được tài nguyên của boss.
- Tài nguyên boss quá ít (**mana và nộ dưới 50**) hoặc boss không có tài nguyên
  → chọn nước đi **khiên** an toàn để bảo vệ bản thân.

Trừ khi tới bước xét này **hút là nước đi an toàn duy nhất** trên bàn cờ thì mới
chọn hút. Lưu ý phải là nước đi an toàn, không có cơ hội tạo ra match-3 kiếm
tiềm năng.

### Bước 6 — Bỏ lượt chủ động

Nếu qua các bước vẫn chưa có nước đi an toàn thì chúng ta có thể bỏ lượt chủ
động. Rule của game là không được bỏ 3 lượt liên tiếp nhau nên chúng ta có
quyền bỏ **2 lượt chủ động liên tiếp**, reset lại trạng thái bỏ lượt bằng cách
ăn nước hoặc chưởng.

Đó là lý do tại sao chừa lại 320 mana (2 lượt chưởng) — thì chúng ta sẽ có thể
skip lượt chờ boss làm mới bàn cờ.

> Về việc nhận biết bỏ lượt thì phải tin game, **không tự count**.

### Bước 7 — Nước đi bắt buộc

Nước đi bắt buộc là **nước đi đầu tiên**, vì ưu thế là của chúng ta.

Còn 1 nước đi bắt buộc nữa là **sau khi bỏ chủ động 2 lượt** — chúng ta phải đi
nước để không bị đá khỏi ván (khi bị đá là văng ra boss map). Nếu trên bàn vẫn
ở thế khó, cho dù đi đâu cũng chừa kiếm, thì hãy đi nước làm sao chừa ra **ít
kiếm nhất có thể**, hoặc chọn **khiên** để bảo vệ.

## 6. Bug bàn cờ chết

Còn 1 bug hiện tại của game là tất cả 64 viên trên bàn cờ không tạo ra được
match-3 nào. Đây là bug của game chưa fix. Trước đây khi bí thì bàn cờ có
refresh mới từ đầu, nhưng ở version hiện tại thì không.

Vì vậy khi gặp trường hợp *"bí do bàn cờ không chứa nước đi, game không
refresh"* thì chúng ta **out game chủ động** để ra boss lobby và bắt đầu lại.

## 7. Tham số cấu hình được

Mọi con số trong rule đều nằm ở `PolicyConfig`
(`src/pokiguard_v2/basic_policy.py`). Các tham số đã được duyệt cho operator
có cờ CLI tương ứng trên `tools/basic_auto_bot.py` và `tools/farm_run.py`; các
tham số còn ghi `—` mới chỉ cấu hình được qua code, chưa có UI/CLI công khai.

| Rule | Trường `PolicyConfig` | Cờ CLI | Mặc định |
|------|----------------------|--------|----------|
| Bước 3 — chưởng khi boss còn dưới X máu | `cast_when_boss_hp_below` | `--cast-when-boss-hp-below` | `30000` (0 = tắt) |
| Bước 5 — chưởng khi mana > X | `cast_mana_stockpile_threshold` | `--cast-mana-stockpile` | `480` |
| Bước 3 — mốc nộ cần đạt | `rage_target` | `--rage-target` | `100` |
| Bước 4 — máu thấp, lối chơi đơn giản | `low_hp_ratio_simple` | — | `0.30` |
| Bước 4 — máu thấp, lối chơi cẩn thận | `low_hp_ratio_careful` | — | `0.50` |
| Bước 5 — boss mana cao (hút) | `boss_high_mana` | — | `160` |
| Bước 5 — boss nộ cao (hút) | `boss_high_rage` | — | `100` |
| Bước 5 — boss tài nguyên thấp (khiên) | `boss_low_resource` | — | `50` |
| Lối chơi | `play_style` | `--play-style` | `simple` |
| Ưu tiên mana | `mana_priority` | `--mana-priority` | `evolution` |
| Độ thông minh | `intelligence` | `--intelligence` | `basic` |
| Biên đồng hồ lượt tối thiểu, inclusive (giây) | `minimum_turn_time_seconds` | `--minimum-action-time` | `1` |

Chi phí 160 mana của tiến hóa và của chưởng **không bao giờ được hard-code**:
policy đọc chi phí thật từ runtime (`FusionState.mana_cost`,
`CardData.manaCost` / `conditionUse`) và fail-closed nếu chưa chứng minh được.

## 8. Lịch sử thay đổi

- **2026-08-17** — Bổ sung chưởng kết liễu ở Bước 3
  (`cast_when_boss_hp_below`, mặc định 30000). Lý do: khi test thấy bot liên
  tục tích mana mà không dùng thẻ chưởng, vì Bước 5 chỉ chưởng khi mana > 480.
  Đồng thời tham số hóa toàn bộ các hằng số trong rule.
- **2026-08-18** — Hoàn thiện chế độ boss máu thấp: tại `HP <=` ngưỡng cấu
  hình, Bước 1 không tiến hóa; sau ưu tiên kiếm, bot chưởng ngay khi thẻ/cost
  runtime hợp lệ và đủ mana, nếu chưa đủ thì ưu tiên mana an toàn trước nộ.
- **2026-08-29** — Mở rộng Sword-safe sang reply gián tiếp: mô phỏng mọi nước
  hợp lệ của boss trên board đã settle, tính cả non-Sword direct match dẫn tới
  Sword cascade. Bổ sung ngoại lệ defer nước kiếm duy nhất khi nó mở cho boss
  lượng kiếm deterministic lớn hơn; Sword-hold chỉ hợp lệ khi mọi reply đã biết
  đều chứng minh lượt kế tiếp của ta lấy được nhiều kiếm hiệu dụng hơn.
- **2026-09-02** — Bịt lỗ hổng sập một hàng qua ô refill: ngoài việc thử gem
  mới là kiếm, simulator còn thử đưa kiếm đã biết cạnh ô UNKNOWN vào ô đó.
  Fixture hồi quy tái hiện hai kiếm hàng 1, hai kiếm hàng 3 và nước nộ hàng 2;
  nước nộ phải bị loại khỏi tập an toàn vì tạo match-3 kiếm tiềm năng cho boss.
