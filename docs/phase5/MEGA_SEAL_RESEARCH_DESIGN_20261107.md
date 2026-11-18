# Mega Kết Ấn — nghiên cứu và thiết kế B15

Ngày 07/11/2026. Người dùng chọn **chốt nghiên cứu và thiết kế trước**.
Bước này không triển khai gameplay, không mở tool, không đọc tiến trình đang
chạy và không phát input. Những thay đổi adviser offline có trước yêu cầu này
vẫn là công việc riêng, chưa được nghiệm thu thêm bởi báo cáo này.

## 1. Kết luận và điểm chốt

**Có thể phát triển Mega Icarus thành lối chơi Mega Kết Ấn dùng chung.** B15
có bộ phân loại và bộ điều phối Kết Ấn riêng, hiện nhận đúng hai loại
`MEGA_ICARUS` và `MEGA_TREX`. Tool nên đọc thẻ đang có trong trận để tự chọn
đúng hình ấn, chi phí và khả năng của skill. Người dùng chọn lối chơi, viên
điều kiện và ngưỡng tại Tùy chọn; AI tiếp tục là adviser chung.

Đã đủ bằng chứng tĩnh để thiết kế và bắt đầu phần offline cho hai loại này.
Chưa đủ để công bố T-Rex chạy live, mặc định T-Rex hồi máu hoặc tính damage
chính xác. Các Mega chọn hàng/chọn điểm/chuyển viên cần cơ chế riêng tương
ứng, dù về sau có thể dùng chung mô tả skill và bộ adviser.

Phần mở rộng Kết Ấn không phụ thuộc việc giải được công thức damage. Có thể
hoàn thành đếm ấn, xét chi phí và chọn thời điểm bằng dữ liệu hiện biết, rồi
bổ sung bộ ước lượng sát thương khi có đủ bằng chứng.

## 2. Nguồn và kết quả kiểm chứng

Nguồn chính là `reverse/reverse_1.7.4-b15/dump.cs`, `script.json` và native
code của `D:\pc\GameAssembly.dll`, chỉ đọc từ file. SHA-256 của binary là
`18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea`.
Mọi RVA bên dưới gắn với hash này, không phải địa chỉ runtime tuyệt đối.

| Phát hiện | Bằng chứng B15 | Ý nghĩa với tool |
|---|---|---|
| Game phân loại theo `CardData.elementTypeCard` | `CardUI.ElementTypeUpper`, RVA `0x1569D20`; `IsSkillCard`, `0x1554A40` | Dùng loại thẻ hiện tại, kèm identity/session; không suy từ tên pet hoặc chuỗi mô tả |
| Kết Ấn hiện chỉ Icarus/T-Rex | `IsSealSkillType`, `0x1554500`, so sánh hai chuỗi chính xác | Registry có phạm vi xác định, không dùng điều kiện tên bắt đầu bằng `MEGA` |
| Hai skill đi qua cùng bộ cast | `StartMegaIcarusPanel` `0x157E9C0` truyền kind 0; `StartMegaTrexPanel` `0x157E9D0` truyền kind 1 tới `StartMegaSealCast` `0x157E9E0` | Có cơ sở dùng chung loại executor kích hoạt bằng click, vẫn cần kiểm tích hợp T-Rex |
| Mỗi hình ấn có 30 ô | `.cctor` Icarus `0x169F910`, T-Rex `0x16A0280` | Có thể trích bảng tọa độ đúng từ native initializer |
| Hai ấn có 19 ô chung và 22 ô khác khi lấy hiệu đối xứng | So sánh hai initializer đã giải mã | Áp hình Icarus cho T-Rex sẽ vừa đếm thiếu vừa đếm thừa |
| T-Rex có kiểm dấu ấn nhận về | `ApplyMegaTrexMark.MoveNext`, `0xA68D60`, đọc `data["cells"]`, gọi `MegaTrexPattern.BoardCells` và `HashSet.SetEquals` | Có đường đối chiếu kết quả thực; chưa phải bằng chứng đã quan sát live |
| Điều kiện tài nguyên của hai skill đi cùng nhánh | `CardUI.CheckConditionUse`, `0x1571AB0`; nhánh sau `IsSealSkillType` tới `0x157262A` | Đọc giá từng thẻ, không cố định chi phí Icarus cho T-Rex |
| `MEGA1`/`MEGA3` thuộc nhóm chọn hàng B15 | `IsRowSkillType`, `0x1553B40` | Alias lịch sử `MEGA1 = Icarus` trong tool cần xử lý theo build khi triển khai |

[Danh mục native và bộ phân loại](../artifacts/b15_mega_seal_expansion_20261107/native_index.json),
[bảng tọa độ và địa chỉ từng lệnh ghi](../artifacts/b15_mega_seal_expansion_20261107/seal_masks.json),
[kết quả kiểm tĩnh](../artifacts/b15_mega_seal_expansion_20261107/static_checks.json).
Script nghiên cứu trong cùng thư mục tái giải mã hai initializer, kiểm 30 ô
duy nhất/nằm trong bàn, so với bảng đã lưu và hằng Icarus của source hiện có.
Các kiểm tra đó đã qua. Không chạy test gameplay vì chưa đổi gameplay.

## 3. Hình ấn và cách đếm

Trên bàn 8×8, mỗi hàng dưới đây là một hàng màn hình từ trên xuống;
`#` là ô thuộc ấn. Tọa độ trong artifact dùng chỉ số bắt đầu từ 0.

Icarus

```text
....#...
..##.#..
#.#.###.
.#######
..#####.
.#####..
.###.#..
........
```

T-Rex

```text
..####..
.######.
##.##.##
.######.
.#.##.#.
..#..#..
...##...
........
```

`ToBoardCell` của cả hai dùng `col = x + trunc((width - 8) / 2)` và
`game_row = height - 1 - y`. Provider 8×8 dùng `screen_row = 7 - game_row`.
Không lấy vị trí sprite/khung hiệu ứng trên ảnh để suy ra ô thuộc ấn.

Cách đếm đề xuất là tổng multiplier hợp lệ của viên điều kiện nằm **trong
đúng ấn của thẻ hiện tại**. Ví dụ một Kiếm x2 và bốn Kiếm thường trong ấn
cho 6 Kiếm hiệu dụng. Ngoài ấn không được cộng; UNKNOWN không được cộng.
Giữ cả số ô thật và số hiệu dụng trong log. Multiplier lấy từ ledger đã
kiểm của provider, không tự giới hạn chỉ x2/x3.

Một phản ví dụ cho việc dùng nhầm hình là ba Kiếm x2 tại `(row,col)`
`(0,2), (0,3), (0,5)`. T-Rex đếm được 6 nhưng Icarus đếm 0. Ngược lại,
ba Kiếm x2 tại `(2,2), (2,5), (3,7)` làm Icarus đếm 6 và T-Rex đếm 0.
Đây là ca tổng hợp chứng minh lỗi ánh xạ, không phải bàn đã gặp live.

Ấn này là vùng ban đầu được client định nghĩa. Các ô phá thêm, cascade,
refill, multiplier do server roll và damage cuối cùng cần bằng chứng riêng.
Không coi 30 ô ban đầu là toàn bộ hậu quả của skill.

## 4. Thiết kế lối chơi và adviser

### Thẻ skill là nguồn xác định cơ chế

Tạo mô tả skill dùng chung từ dữ liệu đang được đọc ở lượt hiện tại. Mô tả
gồm build, session, identity/generation của thẻ và pet sở hữu, loại thẻ,
kiểu chọn mục tiêu, hình ấn, chi phí Mana/Nộ, cooldown, trạng thái nút và
những hiệu ứng đã xác minh. `skillType`, tên và description được giữ để
chẩn đoán; không dùng description tiếng Việt làm bộ luật thực thi.

Registry ban đầu ánh xạ `MEGA_ICARUS -> Icarus` và `MEGA_TREX -> Trex`.
Các bảng hình ấn lấy từ reverse đã kiểm cho build. Không cần buộc mỗi turn
đọc thêm static array trong game, vì class có thể chưa khởi tạo trước lần
cast đầu. Việc có sẵn mảng runtime tại thời điểm đó vẫn UNKNOWN.

Khi tiến hóa, đọc lại identity của thẻ theo đường hiện có rồi chọn mô tả
tương ứng. Không giữ hình ấn của thẻ trước tiến hóa. Không gắn registry chung
với ID pet Javan IV hoặc thẻ 22 của phép thử Icarus lịch sử.

### Tách điều kiện của game và điều kiện người dùng

**Điều kiện game** gồm đúng lượt, thẻ hiện tại, đủ tài nguyên, cooldown,
silence/trạng thái cấm và các guard input hiện có. Nhánh B15 dành cho seal
so `currentPower` với `CardData.power`, `currentMana` với
`CardData.conditionUse`; giá không dương không tạo yêu cầu dương trong
nhánh đó. Cần kiểm giá live và cách dữ liệu đã phản ánh discount; không tự
trừ discount lần nữa hoặc tự coi mọi trường chi phí bằng 0 là thẻ miễn phí.
Các trường `manaCost`/`powerCost` tồn tại không có nghĩa được chọn thay cho
nhánh native vừa xác minh.

**Điều kiện người dùng** là chủ trương khi nào đáng ra skill. Giữ các tùy
chọn đang có, như đủ giá skill hoặc đủ X Kiếm/Mana/Nộ/Hút/Khiên hiệu dụng
trong vùng ấn. Bộ đếm thiết kế theo GemType để có thể bổ sung Máu mà không
viết policy theo từng pet; việc thêm lựa chọn Máu cần migration riêng nếu
triển khai, vì enum hiện tại chưa có lựa chọn này.

BASIC dùng ngưỡng đã cài và cơ chế bảo vệ đã kiểm theo từng skill. Suy luận
coi ngưỡng là mục tiêu tham khảo, có thể chọn skill sớm hơn khi có lợi hoặc
chờ nếu nước khác tốt hơn. Cả hai luôn phải qua điều kiện game. Không dùng
override của adviser để vượt chi phí, cooldown hoặc quyền PASS của game.

### Những nước adviser phải so sánh

- Ra skill ngay với đúng vùng ấn, tài nguyên tiêu hao và hiệu ứng đã biết.
- Swap chuẩn bị vùng ấn, tích Mana/Nộ cho chu kỳ kế và giữ HP/tài nguyên.
- Swap tấn công trực tiếp nếu hợp tình huống, kể cả khi chưa đạt ngưỡng skill.
- Chờ/bỏ lượt chỉ khi game và owner hiện tại cho phép; giữ nguyên cách đọc
  PASS và xử lý chuỗi bỏ lượt đang hoạt động.

Mỗi lựa chọn xét trạng thái hai bên, hiệu dụng x2/x3, cơ hội thắng sớm,
phản hồi boss đang tính được, tài nguyên còn lại trong ấn sau phản hồi và
rủi ro ô chưa biết. Không ghép số Kiếm của một phản hồi boss với Mana/Nộ
của phản hồi khác. Boss ưu tiên Kiếm là mô hình hiện dùng theo quan sát,
không phải chứng minh mọi boss luôn tuân thủ ở mọi trạng thái.

Lợi ích hồi máu phải thuộc đúng skill. Icarus có khai báo người dùng về hồi
máu, lượng hồi chưa xác minh; T-Rex hiện UNKNOWN. T-Rex vẫn có thể tạo lợi
ích phòng thủ qua việc lấy tài nguyên/ngăn boss ăn, nếu có bằng chứng của
bàn và hiệu ứng tương ứng. Không tự gắn khả năng hồi máu Icarus cho T-Rex.

Adviser được giữ nguyên nước BASIC nếu đó là lựa chọn tốt nhất. Lỗi hoặc
hết deadline quay về nước BASIC hợp lệ đã tính trên cùng snapshot. Nếu
chưa xác định được hình ấn thì không tự cast skill đó hoặc áp ấn Icarus;
dùng nhánh đi viên hợp lệ hiện có khi đủ bằng chứng. Những lỗi đọc state
hay guard an toàn của tool vẫn giữ cách xử lý hiện hành.

### UI và tương thích

Đổi tên hiển thị thành **Mega Kết Ấn** ở tab Tùy chọn. Lối chơi và độ thông
minh vẫn chọn ở đây; tab AI chỉ giữ các thiết lập suy luận. Có thể hiển thị
thông tin chỉ đọc “đang nhận diện Icarus/T-Rex”, không thêm bộ chọn AI A/B/C.

Giữ khả năng nạp setting/checkpoint Icarus cũ. Cách ít rủi ro là giữ giá trị
lưu `mega_icarus_spam_skill` làm alias tương thích cho lối chung, đổi label
và resolve qua thẻ đang có; nếu đổi machine value thì cần migration tường
minh. `MEGA1` cần lookup theo build, B15 không được hiểu là fixed seal.

Giữ trình tự đọc memory, capture, executor, QTE, re-entry và nhận thưởng.
Mở rộng ở mô tả skill và bước quyết định. Dữ liệu bổ sung chưa có trong
snapshot không được biến thành vòng quét/chờ mới trong gameplay.

## 5. Sát thương và phần server quyết định

Có bằng chứng rõ rằng kết quả damage của đường chiến đấu đang xét do
server quyết định. `ApiEndpoints.SUBMIT_BOSS_DAMAGE` mang attribute
`Obsolete` ghi endpoint bị xóa và damage do server engine tính. Đây là
khai báo trong client, không phải phép thử trạng thái endpoint hiện tại.
Native `MatchService.ParseCombatBatch` tại `0xAD2F80` còn đọc `srvSeq`,
`totalDamageDisplay`, `combatSteps` và `destroyedByTag` vào `WsCombatBatch`.
Không gọi hoặc thử bất kỳ endpoint nào trong nghiên cứu này.

Client có những dữ liệu hữu ích sau.

| Dữ liệu | Đã xác minh | Giới hạn |
|---|---|---|
| Attack, HP/Mana/Nộ, shield, weakness | `Active.PlayerStats`; `GetWeaknessVsBoss` `0x14B86C0` đọc weakness | Chưa xác định trọn công thức damage từ các trường này |
| Hệ số tương khắc dùng ở client | `GetDamageMultiplier` `0x14BC600` lấy weakness hoặc nghịch đảo tùy phía | Không phải hàm tính damage hoàn chỉnh |
| Hệ số và bổ trợ thẻ | `CardData.damageMultiplier`, star/breakthrough damage, crit/seal và discounts | Có field không chứng minh thứ tự áp dụng hoặc semantics server |
| Ngưỡng/cost full Nộ | `MatchPrepDataDTO.fullPowerThreshold`/`fullPowerCost`, nullable | Cần xác minh snapshot/đường đọc; chưa thể mặc định mọi trận đều ngưỡng 100 |
| Kết quả theo bước | `WsCombatStepDTO.kind/source/target/amount/dmgSrc/fullPower/after/idx` | Là dữ liệu sau hành động; không biết kết quả nước chưa chọn |
| Tổng damage từ viên | `SumBoardDotDamage` `0x14BBE30` cộng amount dương khi kind `DAMAGE`, dmgSrc `BOARD_DOT` | Hàm cộng kết quả nhận về, không dự đoán damage của bàn chưa đi |

Trong các nhánh đã kiểm chưa tìm được công thức đầy đủ, được xác minh cho
damage kiếm và hai skill trước khi cast. Thứ tự tiêu Nộ/nhận Nộ, defense,
buff/debuff, crit, shield, overkill, multiplier roll và cascade vẫn có thể
ảnh hưởng kết quả. Không suy ra công thức “mỗi Kiếm cố định X damage” từ
một trận hoặc từ `damageMultiplier`.

Hướng phù hợp cho adviser là một bộ ước lượng có phạm vi và độ tin cậy.
Trước mắt số chưa đủ bằng chứng giữ UNKNOWN và dùng xếp hạng cơ học/nominal
hiện có. Khi có log phù hợp, dự báo khoảng damage và lượng hồi, tách damage
kiếm thường với damage skill và các wave; không biến điểm proxy thành xác
suất thắng hoặc chứng nhận chắc chắn giết boss.

Mẫu thực phải gắn build, account/loadout/stats, boss/element/status,
session/turn/srvSeq, thẻ/giá, số viên hiệu dụng, tài nguyên trước/sau và
từng bước server cho đúng source/target. So HP delta một mình có thể trộn
damage với hồi máu, shield hoặc hiệu ứng khác. Không dùng WIN cuối trận
để gán damage cho một nước.

`PendingCombat` và các queue render của client có dữ liệu ngắn hạn. Chỉ
thấy declaration chưa chứng minh có thể thu đầy đủ bằng đường đọc hiện
tại. Cần audit vị trí giữ/lifetime/dedupe trước một collector chỉ đọc;
không gọi `ConsumePendingCombat` và không thêm poll gây trễ quyết định.
Nếu bỏ lỡ event hoặc không tách được wave, loại mẫu khỏi fit damage.

## 6. Chỗ code hiện tại cần thay khi được triển khai

| Vùng | Việc cần làm |
|---|---|
| `mega_icarus.py` | Tách bảng hình ấn và bộ đếm thành API nhận descriptor; giữ wrapper Icarus tương thích |
| `pet_skill_shadow.py`, `pet_qte_observer.py` và công cụ observer | Nhận diện `MEGA_TREX`, xử lý alias theo build, resolve giá/owner đúng thẻ |
| `basic_policy.py` | Truyền đúng mask vào fire condition, setup, turnover, giữ viên sau phản hồi boss và bảo vệ; không chỉ sửa điểm đếm lúc cast |
| `reasoning_common_evidence.py`, `reasoning_common_planner.py` | Dùng geometry và effect của skill hiện tại; tách bằng chứng hồi máu theo skill |
| `reasoning_mega.py` và profile/calibration D4 cũ | Giữ proof lịch sử Icarus/card22 đúng phạm vi; tạo contract chung mới thay vì relabel proof sang T-Rex |
| `pet_configuration.py`, `desktop_ui.py`, adapter executor | Đổi label, giữ setting cũ, nhận capability chung; xác minh T-Rex đi cùng executor mà không thay flow |

## 7. Kế hoạch có giới hạn

**Bước 1 — triển khai và kiểm offline trong một đợt.** Registry hai hình ấn,
nhận thẻ/giá, BASIC/adviser, UI và migration được làm cùng một phạm vi.
Kiểm replay Icarus giữ tương thích; dùng fixture T-Rex cho hình khác,
x2/x3, ngoài ấn, UNKNOWN, cost/cooldown, tiến hóa/thay thẻ và lỗi adviser.
Kiểm một tập đầy đủ các điều kiện viên ở offline, không yêu cầu mỗi viên
một campaign live. Hoàn tất khi các ca hình khác phát hiện được áp nhầm
ấn và không thay các luồng input/read/PASS/QTE đã có.

**Bước 2 — kiểm live có giới hạn sau khi offline xong và người dùng chuẩn
bị.** Đề xuất tối đa 3 trận Icarus + 3 trận T-Rex, dừng sớm khi đã quan sát
đủ thẻ đúng/giá đúng/đếm đúng/skill được chấp nhận và một lượt sau skill
nếu boss còn sống. Không tự mở thêm batch nếu chưa gặp điều kiện; ghi rõ
ca thiếu và chỉnh phép thử có lý do. Các điều kiện đếm viên dùng cùng API
không cần lặp live riêng từng lựa chọn. Hồi máu/damage chưa quan sát giữ
UNKNOWN; không công bố T-Rex có hiệu ứng đó.

**Bước 3 — chốt phạm vi và bàn giao.** Ghi hỗ trợ Icarus/T-Rex, fallback,
giới hạn, kết quả test. Chỉ build/phát hành khi có yêu cầu tương ứng.
Các Mega khác dùng cơ chế khác được để ngoài milestone này.

Nhánh damage có điểm chốt riêng sau này: audit dữ liệu hiện có, thu mẫu có
thể tách tác nhân, dựng estimate offline rồi đo sai số trên dữ liệu giữ
lại. Nếu không thu được dữ liệu đầy đủ, giữ UNKNOWN; không kéo dài phần
Kết Ấn để theo đuổi công thức chưa chứng minh được.

## 8. Triển khai offline sau mốc so sánh

Commit `4a681359` lưu phiên bản trước khi sửa gameplay. Bước 1 đã nối cả
hai hình ấn vào nhận diện thẻ B15, BASIC, adviser và executor. Tùy chọn
hiển thị Mega Kết Ấn với mã cấu hình `mega_icarus_spam_skill` để đọc được
cấu hình cũ. Bộ suy luận dùng số viên hiệu dụng trong ấn làm một phần của
điểm chọn skill. T-Rex dùng dữ liệu tác động lên bàn và lợi ích tài nguyên
đã biết. Phần hồi máu hiện có của Icarus vẫn gắn riêng với Icarus.

Các bài kiểm thử mô phỏng thẻ đổi sau tiến hóa, hai nước chuẩn bị có lợi
cho hai hình ấn khác nhau, giá Mana/Nộ theo thẻ và việc hủy click nếu loại
thẻ đổi trong lần kiểm cuối. Đối chiếu dữ liệu B15 khớp đủ 30 ô cho mỗi ấn.
448/450 kiểm thử offline đạt. Hai ca đọc cấu hình D4 lịch sử báo
`complete canonical DesktopConfig required` khi chạy cả bản sửa và commit
mốc. Bước 2 cần quan sát hành vi thật của T-Rex trên B15. Phép ước lượng
sát thương vẫn là nhánh riêng.
