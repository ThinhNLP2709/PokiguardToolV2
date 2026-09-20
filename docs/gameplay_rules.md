# Gameplay Rules — nguồn tham chiếu chuẩn (BASIC)

File này là **nguồn sự thật** cho logic chơi game do người dùng đặc tả.
Mọi thay đổi hành vi trong `src/pokiguard_v2/basic_policy.py` phải khớp với
file này. Bản triển khai kỹ thuật (simulator, trace, fail-closed gates) nằm ở
`docs/basic_gameplay_policy.md`.

## 1. Cấu hình lối chơi

Ta có 3 lựa chọn lối chơi: **Đơn giản**, **Cẩn thận**, và tùy chọn
**Chịu đấm ăn xôi**. Mặc định vẫn là **Đơn giản**.

Ba trường cấu hình pet hiện hành là:

- **Pet của tôi**: Pet thường, Huyền thoại; Pet tiến hóa và Mega được hiển thị
  nhưng chưa cho chọn.
- **Tiến hóa**: Không tiến hóa, Tiến hóa pet thường, Tiến hóa pet huyền thoại;
  mục tiêu Pet tiến hóa và Mega được hiển thị nhưng chưa cho chọn.
- **Thẻ sát thương**: Thẻ chưởng mặc định hoặc Thẻ skill của pet. Thẻ skill chỉ
  cho chọn khi cấu hình có ít nhất một nguồn skill về mặt khái niệm.
- **Điều kiện ra skill**: chỉ hiện cùng Audition khi dùng **Thẻ skill của pet**.
  Sáu lựa chọn là Đủ mana skill, Kiếm đủ, Mana Đủ, Nộ đủ, Hút đủ, Khiên đủ.
  Đủ mana skill dùng chi phí runtime hiện tại và không có số; năm lựa chọn gem
  dùng tổng giá trị hiệu dụng đã biết `>= value`, trong đó `x1/x2/x3/x4` đóng
  góp `1/2/3/4`; ASCII `0..256`. Mặc định là Kiếm đủ / 10.
  Preferences/checkpoint lưu cấu hình, còn Start/Resume khóa nó cho FarmRun.

Ba profile backend đang chạy được với BASIC:

- `NORMAL / NORMAL / DEFAULT_ATTACK`: có Bước 1 Tiến hóa;
- `NORMAL / NONE / DEFAULT_ATTACK`: bỏ Bước 1 và dùng thẻ chưởng thường;
- `LEGENDARY / NONE / PET_SKILL`: không tiến hóa, không dùng thẻ chưởng
  thường, dùng skill pet khi capability runtime hiện tại đủ điều kiện.

Profile Pet Skill trên chạy qua Desktop/FarmRunner đã được chấp nhận ở Phase
3C.2. `Chịu đấm ăn xôi` chỉ được Start với đúng profile này. Các profile khác
có thể hợp lệ và lưu được nhưng không có FarmRunner policy cho lối chơi mới.
Nhiều nguồn skill hoặc capability không rõ ràng phải fail-closed, không tự chọn
một nguồn.

Ta có 2 lựa chọn độ thông minh: **cơ bản**, **suy luận**.

## 2. Hai thẻ chức năng

1. **Thẻ tiến hóa** — dùng để tiến hóa pet giúp tăng máu, tăng dame (có thể),
   tăng giới hạn mana, nói chung là để mạnh hơn. Chi phí phải đọc từ runtime;
   bản 1.7.4-b2 hiện quan sát là **120 mana**. Khi dùng thẻ tiến hóa thì được
   tính là **chức năng**, nên sau khi dùng vẫn có thể đi tiếp được nước trên
   bàn cờ.
2. **Thẻ chưởng** — tiêu tốn 160 mana để ra chưởng gây sát thương cho boss.
   Khi dùng thẻ chưởng thì **tính là 1 lượt**, nên không thể ra nước đi trên
   bàn cờ.
3. **Thẻ skill pet (profile 3C.1)** — chi phí lấy từ
   `PetSkillCapability` hiện tại, không suy từ rarity. Fixture HT7 là 200
   mana/200 nộ; HT2 là 200 mana/150 nộ. Skill HT7 đã chứng minh kết thúc lượt:
   sau khi gửi input không được SWAP/CAST/PASS/dùng skill lần nữa trong cùng
   source turn. Số tài nguyên sau skill có thể được refill bởi hiệu ứng nên
   không được dùng net delta để suy ngược gross cost.

### 1.1. Nhánh riêng cho `LEGENDARY / NONE / PET_SKILL`

1. Capability skill của đúng session phải duy nhất, current, thuộc family được
   hỗ trợ, có cost dương đã biết và CardUI hiện tại phải actionable. UNKNOWN,
   stale, ambiguous hoặc family chưa hỗ trợ thì dừng input fail-closed.
2. Khi đủ Mana/nộ, chọn `PET_SKILL` ngay tại nhánh damage Bước 1. Không tích
   thêm tài nguyên, không EVOLVE và không dùng thẻ chưởng thường.
3. Khi chưa đủ, kiếm vẫn là mục tiêu bàn cờ cao nhất. Nếu không có nước kiếm,
   chỉ xét nước an toàn có known gain cho phần Mana/nộ đang thiếu. Ưu tiên nước
   hoàn tất một yêu cầu, rồi tổng phần thiếu được đóng theo công thức
   `min(known_gain, missing) / required`. Tài nguyên đã đủ và UNKNOWN refill
   không được cộng điểm readiness.
4. Sau đó giữ nguyên thứ tự Health, Drain, Shield, PASS và nước bắt buộc của
   BASIC. PASS đầu trận và PASS thứ ba liên tiếp vẫn bị cấm theo bằng chứng
   server hiện hành.

### 1.2. PlayStyle `Chịu đấm ăn xôi`

Nhánh này chỉ áp dụng cho `LEGENDARY / NONE / PET_SKILL / BASIC` và family HT7
đã chứng minh. Đây là chiến thuật farm ba giai đoạn. Mục tiêu là tích đủ tài
nguyên, chuẩn bị đủ số gem đã cấu hình rồi dùng một Pet Skill Perfect để kết
thúc trận trước khi boss tiến hóa. Mega là mục tiêu tương lai; chưa được mở khi
chưa có capability runtime đã xác minh.

#### Giai đoạn 1 — tích và bảo toàn tài nguyên

1. Khi thiếu Mana hoặc Nộ, chọn nước an toàn giúp đóng phần thiếu; ưu tiên
   combo có tổng tiến độ tốt nhất theo `min(known_gain, missing) / required`.
   Requirement đã đủ và refill UNKNOWN nhận 0 điểm.
2. Nếu không có Mana/Nộ an toàn, chọn Hút an toàn rồi Khiên an toàn. Hút vừa
   không để boss lấy vừa có thể hút tài nguyên; Khiên bảo toàn tài nguyên.
3. Trong toàn bộ thời gian trước skill đầu tiên, **cấm tuyệt đối tự ăn Kiếm**,
   không phụ thuộc Nộ hiện tại. Mọi SWAP được chọn phải có
   `knownSwordConsumed = 0`.
4. Quy tắc SIMPLE “không chừa Kiếm cho boss” vẫn là ranh giới an toàn chính:
   loại nước có direct/indirect/UNKNOWN Sword reply khi còn một nước non-Sword
   an toàn khác.
5. Khi không còn nước an toàn, nếu HP người chơi `> 30%`, được “chịu đấm” bằng
   nước non-Sword rủi ro thấp nhất theo thứ tự Mana/Nộ còn thiếu → Hút → Khiên
   → turnover khác. Nếu HP `<= 30%` hoặc chưa đọc được, ưu tiên Khiên rồi Máu;
   sau đó PASS mới là lựa chọn cuối cùng.
6. PASS chỉ hợp lệ từ trạng thái idle authoritative của game, không dùng ở lượt
   đầu và không được bỏ quá hai lượt liên tiếp. Khi PASS tiếp theo bị cấm, phải
   đi nước non-Sword rủi ro thấp nhất để reset chuỗi bỏ lượt. Nếu mọi nước hợp
   lệ đều tự ăn Kiếm, fail-closed với `SKILL_RUSH_ONLY_SWORD_MOVES`.

#### Giai đoạn 2 — setup theo điều kiện ra skill

1. `skill_cost_ready` không cần setup board: khi tài nguyên runtime và mọi cổng
   actionability đạt thì chuyển thẳng sang Giai đoạn 3.
2. Năm điều kiện count cộng tổng multiplier đã biết của
   `GemType.SWORD/MANA/RAGE/DRAIN/SHIELD` trên board hiện tại với inclusive
   `known_effective_count >= value`; một viên `x3` được tính là 3. UNKNOWN đóng
   góp 0. `Mana Đủ` là giá trị gem Mana trên board, không phải thanh Mana. Mặc
   định `sword_count / 10`, nên 9 ô Kiếm gồm một `x3` và một `x2` có tổng 12 đã
   đạt điều kiện 10.
3. Khi chưa đủ count, không tự ăn Kiếm và cũng không ăn loại gem đang được dùng
   làm điều kiện setup. Ưu tiên nước vừa phá thế Kiếm của boss vừa bảo toàn các
   gem mục tiêu; sau đó chọn nước an toàn có direct clear cách mọi Kiếm đã biết
   ít nhất 2 ô theo Manhattan. Khoảng cách là tiêu chí xếp hạng sau kiểm tra
   direct/indirect/UNKNOWN Sword reply, không tự chứng minh một nước là an toàn.
4. Nếu không có nước setup an toàn mà game còn cho PASS, dùng
   `SKILL_RUSH_SETUP_PASS`. Khi PASS bị cấm, chọn nước non-Sword bảo toàn gem
   điều kiện và có rủi ro thấp nhất. Nếu mọi nước đều ăn Kiếm hoặc gem điều
   kiện, fail-closed với `SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES`.

#### Giai đoạn 3 — ra skill và kết thúc

1. Chỉ đề xuất `PET_SKILL` khi tài nguyên thật đạt chi phí runtime, điều kiện đã
   chọn đạt và toàn bộ cổng kỹ thuật/actionability đạt. HP boss không phải đường
   tắt cho skill đầu tiên. Profile hiện hành dùng Audition V3 trái/phải và phải
   đạt Perfect.
2. Sau `SUCCESS_PERFECT`, đóng source turn và đọc lại HP boss ở lượt local sau.
   Nếu boss còn `> 30%`, quay lại Giai đoạn 1 và phải đạt lại cùng điều kiện để
   dùng skill lần hai.
3. Nếu boss còn `<= 30%`, ưu tiên thẻ chưởng thường khi thẻ hợp lệ và đủ Mana;
   nếu không thì được phép ăn Kiếm để kết thúc sớm. EVOLVE luôn bị cấm.
4. Lịch sử skill chỉ thuộc đúng `CombatSessionKey`, không lưu executable state
   qua checkpoint và không được rò sang trận kế.

Các cổng lifecycle/timer, chống stale/duplicate input, source-turn closure và
QTE giữ nguyên. Hai PlayStyle cũ vẫn dùng policy riêng như trước.

Simulator hiện chưa có mô hình damage-to-HP để chứng minh một reply sẽ gây chết
ngay; hard-survival trong trace vì thế là `UNKNOWN_NO_LETHALITY_MODEL`, không
được tự gắn nhãn an toàn.

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
- **Nước đi an toàn**: nước mà mô phỏng từ 64 viên đã biết không chừa lại
  match-3 kiếm trực tiếp/gián tiếp cho boss và không có nhánh refill UNKNOWN
  hoàn tất kiếm. Nước ngang ở vùng trên vẫn có thể chứng minh là an toàn nếu
  phần sập/refill liên quan không tạo nguy cơ kiếm; vị trí hàng 3 trở xuống và
  khoảng cách với vùng kiếm dùng để xếp hạng độ nguy hiểm, không tự động phủ
  quyết một nước đã qua các kiểm tra kiếm chính xác.
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

Với profile chạy được `NORMAL / NORMAL / DEFAULT_ATTACK`, sử dụng thẻ tiến hóa
nếu đủ 3 yếu tố: **chưa tiến hóa** + **đủ chi phí runtime** + **đã yêu cầu
tiến hóa pet thường**. Bản 1.7.4-b2 hiện trả chi phí **120 mana**. Thì cứ thử
tiến hóa cho tới khi nào thành công.

Lượt đầu tiên vẫn phải đi một nước trên bàn. **Từ lượt của chúng ta lần thứ 2
trở đi**, nếu thẻ/pet tiến hóa hiện tại được game xác nhận, chưa tiến hóa thành
công và mana đủ chi phí runtime, thì Bước 1 phải được xét trước mọi nước trên
bàn. Production dùng cùng ngưỡng hành động inclusive 1 giây; không tự trì hoãn
tiến hóa chỉ vì còn dưới 10 giây.

Với profile chạy được `NORMAL / NONE / DEFAULT_ATTACK`, bỏ qua Bước 1 — toàn
trận không tiến hóa.

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

### Bước 2 — Ăn kiếm (Đơn giản/Cẩn thận và Pet Skill chuẩn)

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

Không nhận được board đúng sequence hoặc hết deadline kỹ thuật **không phải**
là quyết định PASS. Khi đã có ACK mới mà thiếu snapshot tương ứng, runtime phải
thử đường phục hồi capture có giới hạn ngay trong lượt; trạng thái kỹ thuật
không được giả thành bằng chứng rằng bàn không còn nước an toàn.

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

Các ngưỡng BASIC nằm ở `PolicyConfig`. Ngưỡng kiếm `SKILL_RUSH` là Preferences
của operator, nhưng được đóng băng vào cấu hình FarmRun khi Start/Resume và
không đổi giữa run. Các tham số được duyệt cho operator có cờ CLI tương ứng
trên `tools/basic_auto_bot.py` và `tools/farm_run.py`; các tham số ghi `—` không
có UI/CLI công khai.

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
| Pet của tôi | `main_pet` | `--main-pet` | `normal` |
| Tiến hóa | `evolution` | `--evolution-target` | `normal` |
| Thẻ sát thương | `damage_card` | `--damage-card` | `default_attack` |
| Độ thông minh | `intelligence` | `--intelligence` | `basic` |
| Biên đồng hồ lượt tối thiểu, inclusive (giây) | `minimum_turn_time_seconds` | `--minimum-action-time` | `1` |
| Pet Skill — điều kiện ra skill | `pet_skill_fire_condition` | `--pet-skill-fire-condition` | `sword_count` / Kiếm đủ |
| Pet Skill — giá trị hiệu dụng | `pet_skill_fire_value` | `--pet-skill-fire-value` | `10`, inclusive `known effective count >= value`, range `0..256`; null cho `skill_cost_ready` |
| SKILL_RUSH ngưỡng HP người chơi để nhận rủi ro | `SKILL_RUSH_SURVIVAL_HP_RATIO` | — | `0.30`; chỉ nhận nước rủi ro khi `> 0.30` |
| SKILL_RUSH finisher HP boss tương đối | `SKILL_RUSH_FINISHER_RATIO` | — | `<= 0.30` |

Chi phí tiến hóa (1.7.4-b2 hiện quan sát **120**) và chi phí chưởng (hiện quan
sát **160**) **không bao giờ được hard-code**: policy đọc chi phí thật từ
runtime (`FusionState.mana_cost`, `CardData.manaCost` / `conditionUse`) và
fail-closed nếu chưa chứng minh được.

## 8. Lịch sử thay đổi

- **2026-09-21** — Sửa điều kiện count dùng tổng multiplier x1–x4. FarmRun
  `03ceea93d6254ed1a4f4dac54562e85a` có turn 15 đủ tài nguyên và thẻ actionable,
  9 ô Kiếm nhưng 12 Kiếm hiệu dụng; cách đếm ô cũ ăn thêm Khiên rồi mới bắn ở
  turn 17. Policy mới phải bắn ngay tại turn 15. Telemetry lưu riêng số ô và
  tổng hiệu dụng; range cấu hình mở thành `0..256`.
- **2026-09-21** — Sửa thứ tự tích tài nguyên từ FarmRun
  `420227ce72734e28a0fa4a89e0827f7f`: khi Mana/Nộ còn thiếu và HP trên 30%,
  nước bổ sung tài nguyên được chọn trước Hút/Khiên/turnover dù có thể chừa
  Kiếm cho boss, miễn là không tự ăn Kiếm đang giữ. Safe Mana/Nộ vẫn đứng đầu;
  HP thấp hoặc UNKNOWN vẫn được ưu tiên bảo toàn/sống sót trước nước tài nguyên
  nguy hiểm. Ranh giới Sword-safe cứng vẫn áp dụng ở giai đoạn setup.
- **2026-09-21** — Chốt chiến thuật ba giai đoạn: cấm tự ăn Kiếm ở mọi mức Nộ;
  khi hết nước an toàn, HP người chơi trên 30% chọn nước non-Sword ít rủi ro
  trước PASS, còn HP thấp ưu tiên Khiên/Máu. Setup bảo toàn cả Kiếm lẫn GemType
  của điều kiện. `skill_cost_ready` bỏ qua setup. Sau Perfect, boss trên 30%
  quay lại chu kỳ cho skill hai; boss còn tối đa 30% cho phép chưởng/ăn Kiếm
  kết thúc. Quy tắc này thay thế khóa Kiếm chỉ khi Nộ `>=100` bên dưới.
- **2026-09-21** — Khóa setup trước skill theo phản hồi live FarmRun
  `e4dbca0f44ea46cca5afac3984766dda`: khi nộ `>=100`, không nước nào được tự
  ăn kiếm. Nếu không có nước non-Sword an toàn thì dùng tối đa ngân sách PASS
  authoritative; khi PASS bị cấm, đi nước non-Sword ít rủi ro nhất theo
  Mana/Nộ → Hút → Khiên → turnover. Điều kiện fire vẫn inclusive và chỉ bắn
  khi vừa đủ tài nguyên runtime vừa đạt count cấu hình.
- **2026-09-19** — Sửa regression live Mode B
  `26fbc39c62ca469e89c779ee5d2e7f2b`: khoảng cách 2 ô không còn được phép
  vượt qua `SwordRisk.safe`. Cả resource-progress và setup dùng Sword-safe làm
  ranh giới cứng; trong pool an toàn ưu tiên Mana/Nộ còn thiếu, sau đó Hút rồi
  Khiên. Nếu chỉ nước tự ăn kiếm mới an toàn thì dùng fallback có lý do riêng,
  không giao deterministic Sword reply cho boss.
- **2026-09-19** — `Kiếm đủ` và bốn điều kiện GemType còn lại dùng ngưỡng
  inclusive `known_count >= value`; cài đặt 10 kích hoạt tại đúng 10 gem.
  Fallback không-có-nước-an-toàn so toàn bộ nước hợp lệ, kể cả nước tự ăn/phá
  kiếm, trước khi chọn phương án để boss có ít cơ hội kiếm nhất.
- **2026-09-19** — Phase 3D.1-R1 Generic Pet-Skill Fire Condition thay trường
  Sword-only bằng `Điều kiện ra skill` với sáu lựa chọn và machine enum ổn định.
  Năm GemType dùng current known board count inclusive `>=`; `Đủ mana skill` dùng
  resource cost runtime và không có số. Default/migration vẫn Kiếm đủ / 10 nên
  bằng đúng accepted R1 live 5. DEFAULT_ATTACK ẩn condition/Audition; config,
  checkpoint, active-run immutability, telemetry và analyzer dùng generic key.
- **2026-09-17** — Phase 3D.1-R1 Final Revision thêm Preferences
  `skill_rush_sword_threshold` (mặc định 10, range 0..63, strict `>`), bỏ toàn
  bộ HP-prep/very-low-HP shortcut và route kiếm gây damage trước skill. Skill
  đầu/lần hai đều cần tài nguyên runtime và Sword vượt ngưỡng. `SETUP_BLOCKED`
  chỉ nới setup; ăn kiếm trước skill chỉ còn fallback bắt buộc có reason riêng.
  Finisher sau skill, QTE và các cổng cứng giữ nguyên.
- **2026-09-17** — Phase 3C.3 Final Revision đổi từ bắn skill ngay khi đủ tài
  nguyên sang setup HT7. Mô tả này là lịch sử trước R1; R1 ở trên là policy
  hiện hành. Bản lịch sử giữ kiếm và thay ô cách vùng kiếm ít nhất 2 ô khi có
  nước hợp lệ. Sau Perfect đầu tiên của đúng trận, boss
  dưới 30.000 HP hoặc dưới 20% cho phép chưởng thường/kiếm ở lượt local sau;
  source turn, MatchId và default PlayStyle vẫn được khóa riêng.
- **2026-09-16** — Phase 3C.3 thêm PlayStyle tùy chọn `skill_rush` với nhãn
  `Chịu đấm ăn xôi` cho đúng profile `LEGENDARY/NONE/PET_SKILL/BASIC`. Missing
  Mana/nộ đứng trước Sword; direct/indirect boss Sword reply là rủi ro chiến
  lược được phép và vẫn được ghi telemetry. SIMPLE/CAREFUL không đổi.

- **2026-09-12** — Phase 3C.1 thêm profile backend
  `LEGENDARY/NONE/PET_SKILL`: Pet Skill là action riêng tiêu thụ lượt, không
  EVOLVE/ordinary CAST, dùng cost/actionability runtime và planner chỉ nhắm
  current deficits dưới Sword safety. Desktop Start vẫn chờ Phase 3C.2; live
  B1/B2 chưa hoàn thành.

- **2026-09-11** — Mở lại Phase 2 để tương thích bản 1.7.4-b2: xác nhận chi
  phí tiến hóa runtime 120; không dùng collapse/support heuristic làm veto nếu
  kiểm tra Sword/UNKNOWN chính xác đã chứng minh nước an toàn; phân biệt PASS
  policy với việc thiếu board đúng ACK; thêm game-owned `TurnAnnouncer` vào
  cổng thao tác. Chờ người dùng test live, chưa chốt phase và chưa commit/push.
- **2026-09-11** — Log chẩn đoán tiếp theo chứng minh các lượt đứng im không
  phải policy PASS (`pass_totals=0`) mà do recovery quét 1.28--1.31 GiB trong
  7.02--7.18 giây. Trong combat cấm full-heap scan; mỗi ACK mới chỉ được một
  cửa sổ xoay tối đa 64 MiB từ vùng đã học ở lobby. Đọc board và khám phá thẻ
  tách riêng; thẻ dùng cache đầu trận và chỉ khám phá tùy chọn sau lượt mở màn.
- **2026-09-10** — Phase 3A.2 thay setting sản phẩm `ManaPriority` bằng ba
  trường typed Pet/Tiến hóa/Thẻ sát thương. Adapter nội bộ tạm thời ánh xạ đúng
  hai profile BASIC cũ; không thay đổi thứ tự hay quyết định trong
  `BasicPolicyEngine`. Profile Pet Skill được lưu nhưng chưa được chạy.
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
