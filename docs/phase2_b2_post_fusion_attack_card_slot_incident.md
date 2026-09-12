# Phase 2 b2 — mất slot thẻ Chưởng sau khi tiến hóa

Ngày điều tra và sửa offline: 2026-09-12. Phase 2 vẫn chưa chốt. Không commit,
push hay tăng version trong lần sửa này.

## Phạm vi run

FarmRun `f6af5b106e2949b7990ec52c2648dc7a` hoàn thành ba trận đầu với kết quả
WIN. Màn hình ghi `Completed 3/5 — Attempts 4`, nên trận người dùng gọi là
“trận số 3” trong phản hồi là attempt đang chạy thứ tư, MatchId `M_721352fb`.
Người dùng F9 ở game turn 42 sau 21 local turn.

Attempt 4 có 20 SWAP đã gửi trước F9, 19 SWAP được ACK, hai formal PASS và
không có CAST. EVOLVE ở turn 13 thành công với runtime cost 120.

## Bằng chứng lỗi

Trước EVOLVE, provider đọc ba thẻ thường từ exact current
`Board.selectedCards/cardsInHand`. Thẻ Chưởng có cost 160, `uiSlot=1/4`,
`interactionAuthority=BOARD_SELECTED_CARDDATA_CARD_STRIP` và được policy coi
là usable khi đủ mana.

Sau EVOLVE, game thay các wrapper CardUI. Từ turn 15 trở đi provider vẫn chứng
minh được:

- `selectedCardCount=3`, `cardsInHandCount=4`;
- đúng ba danh tính MANA / POWER / ATTACK;
- exact current native hand, CardUI và Button ownership;
- thẻ ATTACK cost 160, cooldown 0, không pending, chưa dùng trong turn;
- `memoryFusionRuntime.usedSuccessfully=true`;
- `memoryFusionRuntime.skillCardPresent=false`.

Provider cũ buộc toàn bộ native card layout phải tìm được pet-skill data và
slot. Vì pet hiện tại không xuất bản pointer đó, layout mang reason
`native_hand_pet_skill_missing_or_ambiguous`; cả ba thẻ thường bị mất
`uiSlot/uiSlotCount` dù CardUI native của chúng đã được định vị riêng. Policy
vì vậy chặn Chưởng chỉ bởi `uiLocated=false`.

Boss xuống 23.124 HP ở turn 25 trong khi mana người chơi là 560. Các turn 25,
27, 29, 31 và 33 tiếp tục SWAP thay vì `STEP_3_FINISH_CAST`. Ở turn 35 và 37,
solver tìm thấy ba legal move nhưng không có safe move nên đi vào formal PASS;
lúc này mana là 860 và Chưởng vẫn bị chặn chỉ bởi slot bị mất. Đây là nguyên
nhân khiến hai Pass xuất hiện dù thực tế còn hành động Chưởng hợp lệ.

## Đối chiếu ảnh cuối

Ảnh `Screenshot 2026-09-12 024505.png` khớp turn 41: boss 26.988 HP, mana
980, timer 13 và có Sword trên bàn. Log cho thấy cửa sổ game từng mất foreground
ngắn lúc người dùng chụp/đổi cửa sổ. Khi foreground hợp lệ trở lại, policy chọn
`STEP_2_SWORD` lúc `19:45:05.951Z` và gửi SWAP `(3,5)<->(3,6)` lúc
`19:45:07.493Z`. F9 đến lúc `19:45:12.312Z`, sau khi game đã sang turn 42,
nên action cuối bị ghi `ACTION_ABORTED_STATE_CHANGED` thay vì chờ terminal ACK.
Lượt Sword trong ảnh không bị policy bỏ; lỗi thật đã xảy ra ở những lượt trước,
khi Chưởng bị khóa sai.

## Sửa chữa

Layout thẻ thường sau tiến hóa nay được giải quyết độc lập bằng chuỗi hiện có:

`Board.cardsInHand -> current GameObject -> CardUI/Button -> RectTransform slot`

Chỉ khi toàn bộ `selectedCards` khớp các CardUI hiện tại, mỗi thẻ có slot hợp lệ
và các slot không trùng nhau thì các thẻ thường mới được cấp vị trí. Các cờ
động từ live CardUI như `interactable`, pending, used-turn và cooldown vẫn được
giữ nguyên. Pet skill tiếp tục bị khóa nếu identity/slot của riêng nó chưa được
chứng minh; việc thiếu pet skill không còn xóa bằng chứng độc lập của Chưởng.

Ngay trước CAST, controller vẫn chụp cửa sổ hiện tại, kiểm tra tile Chưởng tại
đúng slot, kiểm tra foreground, session/turn, mana và capability rồi mới gửi
normal foreground click. Không có write memory, injection hay gọi API game.

Với timeline đã ghi, từ turn 25 thẻ Chưởng sẽ có slot native hợp lệ và policy
phải chọn `STEP_3_FINISH_CAST` trước các nhánh tài nguyên/Pass vì boss đã dưới
30.000 HP và mana vượt cost 160. Sword vẫn giữ đúng ưu tiên cao hơn CAST.

## Xác minh offline

- `tests.test_autonomous_control`: **111/111 PASS**.
- Các suite provider/native-card/policy/pet-skill: **206/206 PASS**.
- Full regression: **1172/1172 PASS**.
- Test mới xác nhận ba thẻ thường ở native slot 1/2/3 của strip bốn ô vẫn được
  resolve khi pet-skill pointer thiếu.
- Test mới cũng xác nhận thiếu một selected CardUI hoặc trùng slot đều fail
  closed.
- `py_compile`, `compileall` và `git diff --check`: PASS.

Cần live soak lại để xác nhận Chưởng thực sự được gửi và nhận ở trạng thái sau
EVOLVE của build b2. Tiêu chí trực tiếp là layout reason
`current_native_selected_cardui_rectangles_pet_skill_unresolved`, ATTACK có
`uiSlot`, và boss <=30.000 với đủ mana tạo `STEP_3_FINISH_CAST`/`CAST` thay vì
SWAP hoặc PASS khi trên bàn không có Sword.
