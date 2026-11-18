# B17 — Demon Aegis / Priest: thu dữ liệu native

18/11/2026. **CLOSED FUNCTIONAL PASS trong phạm vi đã chạy:** 1 trận BASIC
thăm dò rồi 3 trận BASIC tiếp theo, tổng 4/4 WIN STRONG, nhận thưởng và về
phòng Priest. Cap4 đã dùng hết; không tự mở lại request hoặc phiên cũ.

User giao tự thao tác sau khi thoát remote, chuẩn bị boss khoảng400k HP;
đồng thời xác nhận các nhóm Mega khác có thể dùng boss và acc khác. Đợt
này chỉ kiểm nhóm hiện tại, không đổi acc, pet, boss hoặc cấu hình giữa nhóm.

## Nhóm dữ liệu và danh tính

- Game B17, `GameAssembly.dll` SHA
  `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.
- Source giữ nguyên từ đầu tới cuối:
  `95288bffd3d2ba73477023bb4d06692a9030f6df33060f38a1bfe77786e4f400`.
- Solo, Demon Aegis thường ID560, ăn Khiên, ngưỡng4 Kiếm hiệu dụng,
  không tiến hóa, nội tại pet; BASIC, AI tắt. Input foreground two_click,
  profile1280x640, random thời gian và tọa độ giữ nguyên trong request riêng.
- Priest ID1845, display lv131, Bóng đêm, room `Coop_911927`.
  HP boss bắt đầu407.053/581.505; player76.643/109.491 ở action đầu.
- 28 action đều đọc cùng tuple local(maxHP109491, attack1819, maxMana2771,
  maxPower250); boss(maxHP581505, attack766, maxMana540, maxPower250).
- Nhóm có alias từ hash local username và pet/boss/session cụ thể. Đây không
  phải xác minh một account ID bất biến. Full avatar equipment, khắc hệ,
  buff/crit context còn UNKNOWN. Không trộn hệ số damage với nhóm acc/boss khác.

`ManagerRoom.selectedCards` rỗng còn `RoomDTO.cards` có4 card cơ bản; hai
nguồn không đồng ý. Đã lưu cả hai và giữ loadout authority UNKNOWN, không
lấy card list đó để cấp quyền click. Đợt này không gửi card, skill hay evolve.
Không nới production guard để vượt bất đồng này.

## Kết quả

| Giai đoạn / match | Lượt ta | SWAP ACK chưa kết trận | SWAP cuối / terminal exclusion | Kết quả |
|---|---:|---:|---:|---|
| B1 `M_68c6a737` |11|10|1|WIN STRONG|
| B2 `M_e5bc0de8` |6|5|1|WIN STRONG|
| B2 `M_1845a7ae` |5|4|1|WIN STRONG|
| B2 `M_39c13672` |6|5|1|WIN STRONG|
| Tổng |28|24|4|4/4|

0 safe stop, technical abort/recovery, PASS, duplicate, misclick, partial,
wrong-turn, stale hoặc input sau combat theo receipt/counter hiện có.
4 SWAP cuối có `ACTION_ABORTED_STATE_CHANGED` khi combat kết thúc; không
cộng thành ACK. Cả4 có terminal HP pair/UI result WIN STRONG và postmatch bình thường.

28 timing record,24 có sent/ACK đủ điều kiện mô tả; exporter kiểm request,
session, watermark closed/flushed,0 diagnostic loss và đúng cap1+3. Chưa
phát profile suy luận, chưa gán native timer U hoặc population bound.

Đã kiểm22 điểm click của B1: đúng ô, board rect client `[400,29,878,507]`,
jitter trong ngưỡng đã chọn với sai số làm tròn. Opening image có lưới8x8
và các tag nhìn thấy khớp snapshot; loading text che một số ô. Không coi đó
là attestation CV đầy đủ mọi ô/multiplier hoặc nghiệm thu card/QTE. Snapshot
native B1 có88 lượt xuất hiện ô multiplier>1, không phải88 ô độc lập hoặc
88 lần kiểm hình x2 riêng biệt.

Một số MOVE response không mang board8x8 bị transport board parser từ chối;
provider tiếp tục dùng board native đã validate. Cuối run tap đã disarm nên
`healthy=false` ở summary không tự chứng minh lỗi đang chơi. Không sửa
parser/admission hoặc dùng board không hợp lệ. Raw combat outcome là đường
bằng chứng riêng và vẫn được giữ. `postmatch_observation_timeout` thuộc
cửa sổ chỉ đọc sau combat; farm vẫn nhận thưởng/về đúng lobby.

## Dữ liệu mới đã thu được gì

51 batch outcome duy nhất,166 effect,0 exclusion/conflict/duplicate trong
exporter chung:24 gắn SWAP sent/ACK,4 có sent thiếu ACK terminal,23 batch boss
chưa gắn nguồn quyết định. Toàn bộ51 có dữ liệu ops được giữ, gồm28 SWAP
của ta,21 SWAP trong batch boss và2 batch boss không có SWAP. Số này không
chứng minh đủ mọi hành động/effect trong trận.

28/28 op SWAP của ta khớp đúng thứ tự nước đã gửi với ánh xạ
`screen_row = 7 - native_row`, cột giữ nguyên.24 có ACK riêng,4 là terminal.
Đây là kiểm đường tọa độ trên B17 trong scope này. Boss còn thiếu board
trước action có nguồn xác nhận; không gán LastMove của ta hoặc mô phỏng
refill thành board thật để tạo nhãn chính sách boss.

22 STEAL giữ được loại tài nguyên:14 POWER và8 MANA. Đây là cải thiện so
với51 STEAL B16 cũ thiếu `stealType`. Raw after của transfer vẫn chưa tự
gán là số dư của bên nhận/bên mất khi chưa kiểm semantics.

Normalizer Demon cũ tạo17 observation,10 usable ở mức quan sát. Blocker
có chồng nhau:2 first-wave/server-tags mismatch,4 power ledger mismatch,
4 thiếu ACK terminal,4 terminal/unknown HP,4 HP ledger mismatch. Không
loại sạch rồi gọi10 mẫu này là independent holdout hoặc hiệu chuẩn model.
Tất cả vẫn calibration-eligible=false; không sửa normalizer cũ hoặc fit model.

## Điểm dừng và việc tiếp theo

Tool source v1.3.6 vẫn mở ở trạng thái hoàn tất3/3 của B2, không active
controller. Game ở phòng Priest lv131, Demon Aegis giữ nguyên. Main
preferences giữ nguyên; source không đổi trong phiên.0 REASONING,0 skill,
0 training,0 build. Không gắn lại native proof/profile B16 cho B17.
Request đo đã tiêu dùng nên Start/resume bị khóa; dòng preview cấu hình
không hợp lệ sau khi hoàn tất không phải một safe stop giữa trận.

Boss này đủ dùng cho bước thu mẫu Demon ban đầu: các trận có5–11 lượt ta,
có nhiều activation và state Nộ/tài nguyên khác nhau. Chưa đủ để kết luận
chất lượng suy luận hoặc dự đoán damage trên mọi pet/boss/acc.

Việc cũ còn mở: nối board trước/sau response với đúng actor/seq để học nước
boss/refill; kiểm semantics transfer/cap và phần định lượng có thể dùng từ
state trước action. Skill sent/ACK, damage/heal Mega cần cohort riêng do
user chuẩn bị sau. Logic adviser có thể dùng chung; hệ số damage, đánh giá
win rate và sai số phải giữ điều kiện theo từng nhóm. Learned value/ranker
vẫn xếp sau các thiếu hụt dữ liệu này.

- [Closure và cap](artifacts/b17_priest_outcomes_20261118/closure.json)
- [Cohort và giới hạn nguồn](artifacts/b17_priest_outcomes_20261118/cohort_notes.json)
- [B1 review](artifacts/b17_priest_outcomes_20261118/b1/review.json)
- [B2 review](artifacts/b17_priest_outcomes_20261118/b2/review.json)
- [Tọa độ sent ↔ native op](artifacts/b17_priest_outcomes_20261118/operation_mapping.json)
- [Typed corpus](artifacts/b17_priest_outcomes_20261118/common_outcomes.json)
- [Native board review](artifacts/b17_priest_outcomes_20261118/b1/native_board_review.json)
