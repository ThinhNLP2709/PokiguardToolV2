# G4 Combo — Galaxy Shadow Sword, 22/11/2026

Đã triển khai lối chơi riêng **G4 Combo (Shadow Sword)** cho Solo, Nội tại pet.
Hỗ trợ G4 chính không tiến hóa, G4 chính tiến hóa pet thường, hoặc pet thường
tiến hóa Galaxy G4. Không dùng thẻ skill, ấn, QTE hoặc chi phí
Mana/Nộ của lối Galaxy chủ động. Chọn Cơ bản/Suy luận tại tab Tùy chọn như các
lối chơi khác; tab AI vẫn chỉ là cài đặt liên quan.

Source đã kiểm offline và sau đó kiểm trực tiếp **1 trận BASIC G4**:11 SWAP/11
ACK, không safe stop, xử lý LOSS/về đúng lobby. Có witness3 ô thành12 hiệu dụng.
Suy luận mới replay cùng11 bàn, chưa live; chưa build, tăng version hoặc
commit/push. [Kết quả live và giới hạn](phase5/G4_BASIC_NATIVE_20261122.md).

Sau phản hồi trận thua, đã sửa thứ tự ưu tiên Kiếm của cả BASIC/R, thêm hai
route tiến hóa và bỏ dòng cài đặt nội tại khỏi UI. Bản sửa này đã kiểm offline,
chưa live lại. [Cách chơi hiện tại và bằng chứng](phase5/G4_DENIAL_AND_EVOLUTION_20261122.md).

**23/11 — mục tiêu theo route đã được chỉnh lại:** không tiến hóa thì combo
nội tại, không bắt buộc Kiếm; có tiến hóa thì ưu tiên Mana/tiến hóa thành công
trước rồi mới tối ưu skill. [Hành vi hiện tại và kiểm tra](phase5/G4_ROUTE_GOALS_20261123.md)
thay phần ưu tiên Kiếm ở bản22/11; vẫn giữ guard phản hồi Kiếm.

## Skill và bằng chứng

Hai ảnh user cung cấp là mô tả Shadow Sword cấp14. Nội tại Tự Lực tính tổng
viên phá trong **một lượt kéo**, mọi loại, gồm cả viên rơi xuống rồi khớp tiếp:

**User xác nhận bổ sung ngày22/11: mốc tính cả hệ số x2…x7.** Vì vậy dùng
tổng viên hiệu dụng (cộng hệ số của mỗi viên ăn được), không dùng số ô vật lý.
Ví dụ x7 + x1 + x1 là3 ô nhưng tính9, đạt mốc9. Xác nhận này là bằng chứng từ
user; chưa được đo lại trên tài khoản G4. Nó thay thế giả định đếm ô thật của
bản nghiên cứu offline đầu tiên cùng ngày.

| Mốc viên theo mô tả | Sát thương ghi trong mô tả | Hút máu |
|---|---|---|
| 9 | 500.000 | Không ghi |
| 10 | 700.000 | Không ghi |
| 11 | 1.000.000 | 2% sát thương gây ra trong PvE |
| 12 | 1.500.000 | 2% trong PvE |
| 13 | 2.000.000 | 2% trong PvE |

Mô tả còn ghi: không cần bấm thẻ, không tốn Mana/Nộ; sát thương cộng thêm phụ
thuộc tấn công nhân vật/pet và tăng khi đối thủ ít máu. Kiên Định sau skill có
50% không bị Đóng Băng/Choáng trong4 lượt. Phần Đấu Trường ghi hút100% và2 lượt
Kiên Định; tool chưa triển khai PvP từ những số đó.

Reverse B17 có:

- Literal `galaxy_shadow_sword`, `SHADOW_SWORD_STRIKE`,
  `shadow_sword.lib_accumulate`, `.lib_steadfast`, `.status_accumulate`,
  `.status_steadfast`, `.strike_popup`.
- `PokiGuard.StatusFx.StatusFxController.PlayAccumulateStrike(bool targetIsSelf,
  int damage, int healed, bool steadfast)`, RVA **0x18D3C80**. Native bytes trong
  đúng GameAssembly B17 có hai RIP reference tại0x18D3D33/0x18D3F38 tới literal
  `shadow_sword.strike_popup` ở0x4394948. Đây là bằng chứng nhánh trình bày
  effect, không là công thức damage hoặc quyền gọi method game.
- `WsCombatStepDTO` có kind/source/target/amount/dmgSrc và `WsCombatBatch` có
  steps/destroyedByTag/board. Sự hiện diện các trường không chứng minh cách G4
  tính mốc hoặc quy thuộc toàn bộ sát thương cho nội tại.

Không tìm được công thức server đã được kiểm chứng để suy kill/heal từ các số
trên. Active buff thật, nhiều lần kích hoạt trong cùng nước, cách server tính
damage và phần refill chưa thấy đều giữ UNKNOWN. Pet ID2859 đã quan sát trong
phiên account G4, chưa đăng ký tự nhận pet. Cách đếm hệ số
đã được user xác nhận; reverse nhánh effect không tự chứng minh luật đếm đó.

[Audit file/native và hash ảnh](phase5/artifacts/g4_combo_20261122/research.json).

## Vì sao tách khỏi các lối chơi đã có

| Lối cũ | Cơ chế hữu ích để tái sử dụng | Phần không phù hợp với G4 |
|---|---|---|
| Đơn giản/Cẩn trọng | Solver hợp lệ, cascade, kiếm cho boss, fresh input/ACK | Chọn Kiếm trước có thể bỏ mất combo nhiều loại |
| Demon Farm | Tư duy ưu tiên nội tại, không bấm thẻ | G4 không có viên kích hoạt hoặc quét hàng/cột theo Demon |
| Mega Kết Ấn | Xét bảo vệ và setup theo trạng thái | G4 không có ấn hoặc thao tác skill |
| Galaxy chủ động G1/G2/G3 | Chia sẻ owner Suy luận UI và lifecycle | G4 không đợi đủ chi phí hoặc nhận thẻ để cast |

Do đó dùng solver match/collapse V1 đã chuyển sang V2, cộng một bộ xếp hạng
combo riêng; không viết lại solver hoặc giả G4 là một CardUI chủ động.

## Cơ bản

1. Duyệt112 cặp đổi kề bằng solver hiện có, lấy các nước hợp lệ.
2. Giữ nhóm nước chừa ít Kiếm hiệu dụng nhất cho boss trên phần bàn đã biết.
   Nếu có nước chừa0, mọi lựa chọn combo/tài nguyên/setup phải ở trong nhóm0.
   Có route tiến hóa chưa thành công thì ưu tiên Mana tiến hóa trong nhóm này,
   dùng Step1 cũ để tiến hóa ngay khi game cho phép; chưa ưu tiên combo skill.
   Mana đủ/đầy nhưng card chưa dùng được thì tiếp tục đánh/bảo vệ và đọc lại.
3. Cộng **hệ số x1…x7** của tất cả viên từ direct và các cascade xác định
   được. Giao chữ T/L không đếm lặp trong cùng đợt; cùng tọa độ ở đợt sau có
   thể là viên khác. Không cộng dồn giữa các lượt. Số ô thật ghi riêng để
   chẩn đoán, không dùng làm ngưỡng kích hoạt.
4. Trong nhóm đã lọc, ưu tiên mốc cao nhất có thể đạt, tối đa mốc13. Cùng mốc
   xét Kiếm của ta, máu cần ăn và rủi ro còn lại.
5. Khi mục tiêu đã là nội tại, chưa có mốc9 thì chọn combo phù hợp để đổi bàn;
   không bắt buộc ăn Kiếm. Trước khi pet thường tiến hóa G4 thành công,
   không tính điểm nội tại. G4 chính vẫn có thể kích hoạt nội tại tình cờ khi
   ăn Mana cho tiến hóa; đó không là mục tiêu skill ưu tiên trong giai đoạn này.
6. Mọi nước đều có phản hồi Kiếm thì chọn mức thấp nhất và tiếp tục chơi;
   không dừng tool vì rủi ro hoặc chưa đạt mốc.

Mô hình coi mốc là ngưỡng tối thiểu và bão hòa tham chiếu ở13, không cộng
500k+700k+… thành một lần đánh. 8 ô x7 cho56 viên hiệu dụng, thuộc mốc13 của
mô hình. Đây không là chứng nhận damage hoặc số lần kích hoạt thực tế. Cần
kiểm live phần effect, đặc biệt khi tổng vượt13. Unknown refill không được
lấy mẫu hoặc điền viên thuận lợi để nâng số combo.

## Suy luận

Giữ mục tiêu kích hoạt nội tại, xét thêm tình hình:

- Ưu tiên combo không để lại phản hồi Kiếm trên phần bàn đã biết. Zero ở đây
  không chứng minh an toàn sau refill.
- Khi máu dưới30%, hoặc máu không quá60% và boss có ít nhất80% Nộ, tăng ưu
  tiên hồi máu và giảm Kiếm chừa lại. Đây là heuristic áp lực, không là luật
  game, công thức sát thương hoặc chứng nhận sống sót. Combo từ11 có cơ hội
  hút máu; không cộng một lượng hồi giả vào HP hiện hành.
- Khi chưa có mốc và mục tiêu đã là nội tại, tìm setup trên tối đa6 nước ứng
  viên, được phép thay nước Kiếm nhỏ nhưng không chừa thêm Kiếm cho boss. Mô phỏng phản hồi Kiếm
  nhiều nhất của boss **có điều kiện**, giữ mọi nước đồng hạng, rồi xem
  combo của lượt sau. Không cộng các phản hồi khác nhau hoặc giả boss đứng yên
  khi phần bàn đã biết không có nước phản hồi.
- Chỉ nhận điểm setup nếu đã tính đủ các tie được xét và mọi tie đều còn cơ
  hội combo từ9 viên hiệu dụng; phép tính lượt sau cũng cộng hệ số. Quá4 tie
  hoặc tính dở thì không nhận floor setup. Đây vẫn là giả thuyết boss chọn
  Kiếm, không dự đoán chắc boss không dùng skill.
- Setup giới hạn1.800 node và tối đa min(ngân sách AI,250ms). Hết ngân sách
  quay về nước hiện tại đã có; không fault/stop. Toàn bộ fresh read, lượt,
  timer, input lease, chuột và ACK cũ vẫn kiểm lại trước khi gửi nước.

Không thêm bộ đếm bỏ lượt cứng. G4 luôn chọn SWAP khi còn nước hợp lệ; bàn
thật sự không có nước và dữ liệu không hợp lệ vẫn theo chốt hiện hữu.
Không suy Kiên Định còn hiệu lực hoặc chắc miễn khống chế chỉ vì trước đó đã
chọn một combo. Sát thương thực tế, hồi máu và kill luôn chưa chứng nhận.

## Cấu hình và chẩn đoán

Chọn **Tùy chọn → Lối chơi → G4 Combo (Shadow Sword)**. UI mặc định Galaxy chính,
không tiến hóa, Nội tại pet. Có thể chọn Galaxy chính + tiến hóa pet thường,
hoặc pet thường + tiến hóa Galaxy G4. Ẩn cả dòng “Kích hoạt nội tại”, Viên mục
tiêu và thao tác skill; không có ngưỡng/cài đặt tích chi phí skill cho G4. Chọn Suy luận
tại cùng tab; AI budget là trần tính toán, không là thời gian chờ thêm.

CLI dùng profile canonical:

```powershell
python -m tools.farm_run --stage-b2-farm --play-style galaxy_shadow_sword --main-pet galaxy --evolution-target none --damage-card pet_passive
```

Lệnh trên chỉ minh họa cấu hình, chưa được chạy live. Chọn Suy luận trong UI
không thay trường intelligence lịch sử của BASIC/checkpoint; owner truyền
flag chiến thuật và budget vào policy như Galaxy hiện tại. Không giả profile
common worker hoặc nới qualification cho style mới.

Trace `g4_combo` ghi số ô thật `known_destroyed_cells`, tổng hiệu dụng
`known_combo_units` và các phần `direct_combo_units`/`cascade_combo_units`
riêng; `trigger_counting=MULTIPLIER_WEIGHTED_ALL_GEMS_PER_SWAP`. Ghi mốc tham chiếu,
HP/Nộ, phản hồi Kiếm, setup/budget và các UNKNOWN. Identity là **operator chọn
G4**, chưa phải tự nhận đúng pet từ runtime. Pet ID2859 chỉ ghi trong hồ sơ
phiên đã đối chiếu màn hình; chưa đăng ký Shadow Sword vào active-card list.
`resource_cost=0` chỉ nói chi phí kích hoạt nội tại; không chứng nhận lượng Nộ
còn lại sau nước có ăn Kiếm thông thường. Balance thực tế vẫn do game quyết định.

## Kiểm tra và phần cần live

- 39 test G4: các biên8–14 và tổng448, cascade thật với x1…x7; ví dụ hỗn hợp
  x7+x1+x1 đạt9 từ3 ô; chọn combo hiệu dụng thay vì nhiều ô hơn; lookahead
  đếm hệ số; log tách ô/hiệu dụng; không tích giữa lượt; bảo vệ thay vì combo
  rủi ro; setup thật trên bàn tổng hợp; timeout;
  tất cả nước nguy hiểm vẫn SWAP; không cast/evolve; lượt/timer; controller
  bình thường có SWAP/ACK và final turn đổi thì không gửi; UI/CLI/prefs/budget.
- **414 test CI offline PASS** sau chỉnh mục tiêu theo route, gồm39 test G4.
  Bản22/11 có406 CI và142 test liên quan PASS; sau sửa hệ số trước đó có398 test. Bản đầu trước
  xác nhận hệ số có394 test. Nhóm UI/config/Galaxy liên quan kiểm
  riêng; hai assumption enum/UI cũ đã cập nhật cho điều kiện auto-combo mới.
- Bản đầu có27 trạng thái tổng hợp ×2 mode =54 replay, không có kết quả trận hoặc nhãn
  “tối ưu toàn cục”. Không sử dụng kết quả refill thực tế làm input.
- 243 tình huống của8 style cũ (và nhánh Suy luận Galaxy) so với main04d9680a
  cho decision/trace giống nhau sau khi chỉ loại trường `g4_combo=None` mới.
  Không tuyên bố đây là live game hoặc full historical suite sạch.
- Không sửa game/V1, input backend, solver core, PASS hoặc native address;
  manifest migration cũ/Demon giữ nguyên, thêm overlay kiểm hash cho phạm vi G4.

Bài live BASIC1 đã đóng, không còn lượt dự phòng. Đã xác nhận luồng SWAP/ACK,
kết quả/lobby và cách tính hệ số trong runtime. Actual activation qua các mốc,
trên13, cascade/refill và heal vẫn cần quy thuộc hiệu ứng; Suy luận cần bài
live riêng nếu kiểm tiếp. Cần chốt giả thuyết và giới hạn trước khi mở.

[Bản đầu trước xác nhận hệ số](phase5/artifacts/g4_combo_20261122/verification.json),
[replay](phase5/artifacts/g4_combo_20261122/replay.json),
[parity các lối cũ](phase5/artifacts/g4_combo_20261122/existing_parity.json).

Bản sau xác nhận hệ số giữ hồ sơ riêng, không đổi nhãn bằng chứng đếm ô cũ:
[kiểm tra và source](phase5/artifacts/g4_weighted_20261122/verification.json),
[replay có hệ số](phase5/artifacts/g4_weighted_20261122/replay.json).
