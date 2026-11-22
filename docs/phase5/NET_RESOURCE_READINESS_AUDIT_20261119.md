# Kiểm số dư Mana/Nộ và điều kiện skill — 19/11/2026

**Đã xác minh phần số dư thực của nhóm trận đã có; chưa đủ dữ liệu native
để nghiệm thu dự báo mở skill Mega.** Không phát hiện mâu thuẫn trong logic
đủ tài nguyên đang kiểm. Giữ cách tính lợi ích có điều kiện của adviser;
không thêm công thức trừ Nộ hoặc thay đổi điều kiện dùng skill.

Source trước `6a5f2c6b…`, source sau
`cbccf8c41940e58193b960555e69082e47c6521e3f48025e14e54e68b7dde09d`.
Chỉ thêm công cụ audit và test; mọi file mã nguồn đã có trong manifest, gồm adviser, BASIC,
collector, input và luật PASS, giữ nguyên từng byte. Đợt này offline,
không mở tool/game, chạy thêm trận, train, build hoặc rebind profile.

## Số dư quan sát được

Nguồn là bốn trận B17 Priest131/Demon Aegis ăn Khiên, giữ match/source gốc
riêng biệt. Có 72 response hợp lệ; bảy response thiếu cặp published state
trước–sau duy nhất bị loại khỏi phần đối chiếu số dư. Một optional capture
lỗi cuối trận BASIC vẫn bị giữ là thiếu, không sửa lại log.

**65 khoảng có đủ identity và published endpoint**, gồm 31 hành động ta và
34 hành động boss. LOCAL còn phải khớp SWAP sent/ACK, nguồn board/turn/
sequence/session; BOSS không bị trộn với input của ta. Đổi role, capacity,
epoch, thứ tự sai hoặc thiếu endpoint không được điền số đoán.

| Kiểm chứng | Kết quả |
|---|---:|
| Cập nhật STAT_CHANGE Mana/Nộ được xét trong 65 khoảng | 197 |
| `newValue` khớp giá trị trước + delta | 179 |
| Khớp mẫu chạm trần/sàn | 18 |
| Cập nhật cuối của một tài nguyên khớp published endpoint | 140/140 |
| Tài nguyên không có update được capture | 120; số dư trước/sau đều không đổi |
| Update có nhãn FULL_POWER trong các khoảng đủ endpoint | 16 |

Toàn bộ 72 response có 20 update nhãn FULL_POWER và không có card ID cụ
thể. Không dùng bốn update ngoài khoảng đủ endpoint để chứng nhận số dư
cuối. Delta có thể là lượng trước khi chạm trần, nên tổng delta không luôn
bằng thay đổi số dư. Combat steps và STAT_CHANGE là hai góc ghi nhận hiệu
ứng: **không cộng chúng hai lần**, không trộn idx combatSteps với index ops.

Ví dụ Nộ phía ta:

| Trận/lượt | Chuỗi client nhận được | Số dư cuối |
|---|---|---:|
| `M_fcd2b84e` / 9 | 175 → nhận +120, newValue 250 → nhận +5, vẫn 250 → FULL_POWER −100 | 150 |
| `M_acace752` / 3 | 60 → nhận +100, lên 160 → FULL_POWER −100 | 60 |
| `M_d1b1a9b4` / 3 | 100 → nhận +160, newValue 250 → FULL_POWER −100 | 150 |

Ở ca đầu, tổng delta báo là +25 nhưng số dư thật giảm 25 vì chạm trần
trước khi tiêu. Các chuỗi này chứng minh dữ liệu số dư đã ghi và giải thích
một số chênh lệch cũ. Chúng **chưa chứng minh điều kiện kích hoạt FULL_POWER,
thứ tự tính bên trong server hoặc mức tiêu Nộ chung cho mọi pet/đòn**.

## Viên ăn được khác tài nguyên để dành

Nối thêm 22 SWAP với exact CommonProblem trước nước, action thực gửi, ACK
và published state đầu lượt boss; hai nước cuối thiếu endpoint bị loại.
Phép cộng gross từ phần viên đã biết khớp số dư thật ở **16/22 Mana và
9/22 Nộ**. Không coi mọi chênh lệch là bị tiêu: refill/cascade và Hút cũng
có thể làm số thực nhận khác mô hình phần bàn đã biết.

Đây là đối chiếu hồi cứu, không gán phần thiếu cho server theo một hằng số.
Giá trị sau nước không được đưa ngược vào adviser để chọn nước trước đó.
Kết quả củng cố việc không cộng chắc bonus “đã đủ Nộ để skill lượt sau”
trong nước có kiếm. Runtime hiện đã giữ khoảng này theo báo cáo
[resource balance trước](B17_RESOURCE_BALANCE_REVIEW_20261119.md).

## Điều kiện skill: phần đã kiểm và phần chưa có

Đã kiểm lại 643 CommonProblem của corpus đối chiếu:

- 24 mẫu có đủ cả chi phí Mana/Nộ; cả 24 có provenance `synthetic/common.json`.
  Logic kiểm số dư hiện tại khớp phép kiểm đủ **cả hai tài nguyên**: 23 mẫu
  chưa đủ, một mẫu đủ. Không có mâu thuẫn.
- 619 mẫu còn lại không có đủ thông tin chi phí để kết luận. Trong đó có
  các mẫu Demon passive vốn không dùng thẻ tấn công chủ động; không coi
  thiếu chi phí là chi phí bằng 0 hoặc là bug của lối chơi đó.
- Các snapshot Mega lịch sử trong corpus này không giữ EffectChoice skill
  đầy đủ. Bộ corpus không có pet_skill eligible được ghi; điều đó không nói
  tool chưa từng dùng skill trong các trận gốc.
- Bốn trận có ordered trace đều Demon passive, không có card ID của một
  lần skill thực. Vì vậy có **0 mẫu native đủ liên kết chi phí của thẻ hiện
  tại với hành động skill và số dư sau skill** trong phạm vi audit này.

Đủ Mana nhưng thiếu Nộ vẫn không đủ tài nguyên. Đủ cả hai chỉ chứng minh
khả năng trả chi phí đó; actionability/cooldown/card ownership/evolution
vẫn do state và owner hiện tại quyết định. Không dùng chi phí ở snapshot
trước để chứng nhận một thẻ sau tiến hóa hoặc sau đổi trận.

**55 test PASS** kiểm hai tài nguyên, ngưỡng đúng bằng, cost 0, missing/
boolean/âm, owner chưa cho phép dù đủ tiền, cost không khớp, cap/spend,
thiếu endpoint, identity/order/role sai, không đếm hiệu ứng hai lần và
không phát sinh quyền input. Đây là kiểm logic, chưa thay thế native skill.

## Điểm chốt

Chưa có bằng chứng cần sửa gameplay thêm ở mốc này. Công cụ mới
`tools/audit_ordered_resource_readiness.py` giúp các lần sau kiểm trực tiếp
số dư, trace và thiếu hụt của dữ liệu mà không dựa vào tổng số viên.

Phần còn thiếu để kiểm tiếp **skill Mega** là một trace mới có card ID/
cost Mana và Nộ đang có nguồn hợp lệ, state trước khi bấm, hành động/
kết quả skill và state sau khi giải quyết; nên có cả khoảng đủ và thiếu
Nộ. Đây là yêu cầu dữ liệu cho mốc sau, không mở thêm cap live trong đợt
offline này. Trước lần thu Mega mới cần chuẩn bị đường nối action skill,
card/cost hiện tại và outcome; normalizer hiện chỉ chứng nhận sent/ACK cho
SWAP. Không hứa rằng chỉ chạy thêm một trận là tự có đầy đủ liên kết đó.
Hút/damage/refill và các nhóm pet/boss khác vẫn cần kiểm phạm
vi riêng, không gộp số liệu để fit một công thức chung.

[Audit, input SHA và ví dụ](artifacts/net_resource_readiness_20261119/audit.json) ·
[Script tái kiểm](artifacts/net_resource_readiness_20261119/audit.py) ·
[Verification](artifacts/net_resource_readiness_20261119/verification.json).
