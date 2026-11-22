# Mana/Nộ sau nước đi: đối chiếu log và sửa độ chắc chắn của điểm tích Nộ

19/11/2026. Đợt này làm offline trên `main`, không mở tool hoặc chạy thêm trận.
Nguồn là4 trận B17 Priest131/Demon Aegis đã đóng, tách theo match/source;
không gộp với pet/acc/boss khác để fit công thức. Cap live trước đó giữ đóng.

## Log cho biết gì

Auditor mới nối25 khoảng boss BOSS→LOCAL có bàn/trạng thái trước/sau,
cùng match/epoch/Board, turn liền kề và sequence tăng. Có100 phép kiểm
Mana/Nộ của hai bên:

- 50 kiểm Mana khớp phép đối chiếu lượng cộng trực tiếp và lượng STEAL đã
  được báo cho bên cho/nhận. Đây là số lượng **đã xảy ra**, không suy ra
  trước được lượng sẽ hút, công thức theo viên hoặc ownership của raw `after`.
- 50 kiểm Nộ còn phần chưa giải thích: boss22 lần+5,2 lần−95,1 lần−70;
  phía ta17 lần+5,6 lần+20,2 lần+35. Không biến các mẫu đó thành quy tắc
  cộng5 mỗi lượt hoặc tiêu100 Nộ cố định. Các hiệu ứng/regen/thứ tự/cap chưa
  được capture đầy đủ vẫn UNKNOWN.

Ngoài ra nối được12 SWAP ACK của2 trận Suy luận với exact before snapshot,
nước thực gửi và published state đầu lượt boss.2 nước cuối trận thiếu
published endpoint phù hợp được loại. Trong9 nước có kiếm kèm gain Nộ
biết trước,8 lần số dư Nộ quan sát khác phép cộng gross. Chỉ7/12 số dư
Mana và4/12 số dư Nộ khớp gross known gains; không coi gross là net.

Ví dụ `M_72a5be29`, lượt3: Nộ80+60 gross nhưng quan sát sau là40;
Mana105+150 gross nhưng quan sát sau là435. Lượt9 cùng trận có2 kiếm,
Nộ25+120 lại khớp145. Vì vậy không sửa bằng một mức trừ Nộ cứng hoặc
ngưỡng số kiếm đoán từ vài trường hợp.

`tools/audit_resource_balances.py` chỉ đọc file, kiểm identity/order/capacity,
tách reported flow và phần chưa giải thích. Sai session/role/capacity/order
bị từ chối; signed amount/loại Hút thiếu giữ UNKNOWN. Raw `after` không được
dùng để gán chắc cho bên nào.0 mẫu được nâng thành calibration/training label.

## Sửa adviser

Trước sửa, điểm R và bonus mở skill có thể coi toàn bộ Nộ ăn trong nước kiếm
là tài nguyên để dành. Dù phần đánh giá nguy cơ bị Hút đã giữ thứ tự tiêu
Nộ UNKNOWN, phần tích tài nguyên này vẫn cho điểm chắc theo gross gain.

Giờ điểm R có khoảng **lợi ích tích tài nguyên có điều kiện**:

- Phần dưới không cộng chắc lợi ích để dành từ Nộ trong nước có kiếm.
  Nếu skill cần Nộ, không cộng chắc bonus “đã mở skill sau nước này”; ưu tiên
  tích phần Mana còn thiếu vẫn được giữ. `after` readiness là UNKNOWN ở đây.
- Phần trên giữ upside gross trước đó, không xóa khả năng nước ấy giữ được
  Nộ. Đây không là khoảng số dư server, damage hoặc xác suất thắng.
- Nước không kiếm giữ cách tính cũ. Skill chỉ cần Mana không bị ép có thêm
  Nộ. Readiness **trước** nước vẫn dùng số dư thực; quyền dùng skill/input
  không đến từ dự đoán readiness sau nước.
- Điểm kiếm/tấn công, Demon cùng nước ăn Nộ tăng burst theo khai báo user,
  threshold/cài đặt, BASIC, PASS, owner/guard và giới hạn tìm kiếm giữ nguyên.
  Khoảng R không phát sinh safe-stop mới. Thiếu input/residual cũ vẫn đi theo
  missingness hiện có, không được coi là0 đã biết.

Worker summary giữ range và readiness hai kịch bản trong budget12KB. Chỉ
3 file runtime đổi: tactics, ghép Bound R trong scorer và2 trường summary.
Galaxy trong common corpus không chứng minh UI Galaxy đã đổi nhánh runtime.

## Kiểm chứng

Source trước `666d13bc00c5fbfdf4140ccd5ff9722b1680bcd8e569eddd8f825219674cef3f`.
Source sau `de63bc05a1bc6d6bbfe4ef381e0ae2295a0e8e9da9c82264b1c97671f3a0ecfa` và manifest
được giữ trong verification dưới đây; source mới
chưa live hoặc build, hồ sơ native666 vẫn thuộc source trước.

61 test tập trung PASS; hồi quy219 test PASS trong77,344s, gồm14 test mới.
Kiểm gain/skill cost hai tài nguyên, trường hợp có kiếm nhưng không có viên
Nộ, Mana-only, evolution, Demon burst, missing/residual, PASS/skill và giới hạn
summary. Fixture4 native case tách before `problem` khỏi `retrospective`;
đổi số dư tương lai trong fixture không làm đổi score. Đây không là full
suite xanh;5 lỗi thiếu fixture lịch sử đã ghi ở đợt trước không được chạy lại.

Kiểm thêm summary thực của53 case (toàn bộ20 case đổi và35 snapshot native,
loại trùng), tất cả nằm trong12.000 byte; lớn nhất11.963 byte. Đây là kích
thước của tập đã kiểm, không là đo latency native hoặc quyền gửi input.

Paired replay619 trạng thái duy nhất =584 archive+21 B16+8 B17 cũ+6 B17
main mới. Chỉ restore đúng tactics/scorer trước sửa để so sánh cùng planner,
8 root/32 scenario/18000 node,clock deterministic.613 kết quả trước sửa khớp
hoàn toàn kết quả sau của replay mốc trước, kiểm soát đúng lineage.

20 lựa chọn đổi, tất cả SWAP→SWAP hợp lệ:17 Demon và3 Mega.17 ca đổi giữa
hai đề xuất;3 ca giữ BASIC thay vì override, không dừng đánh.74 lựa chọn sau
có khoảng R rộng;6 snapshot native mới nhất giữ nguyên nước,5 có khoảng R
rộng.2 ca node cap cũ giữ nguyên,0 ca cap mới hoặc tăng budget. Không dùng
20 thay đổi làm nhãn tốt hơn,619 trạng thái không là619 trận hoặc holdout
độc lập. Không có nước mới nào của source này đã gửi trong game.

## Điểm chốt và việc còn mở

Đã có công cụ kiểm số dư và sửa một chỗ adviser chắc quá mức về tích Nộ.
Chưa có công thức dự đoán net Mana/Nộ sau attack/transfer/refill đủ bằng chứng.
Không fit mức tiêu Nộ/transfer từ các residual này, không dùng WIN làm nhãn
tối ưu. Damage/heal skill và refill coverage tiếp tục cần dữ liệu có nguồn;
learned outcome/value/ranker vẫn xếp sau các việc dữ liệu cũ.0 game input,
0 live attempt,0 train/build; không rebind hồ sơ native cũ.

[Audit25+12 khoảng](artifacts/b17_resource_ledger_20261119/resource_audit.json),
[script tái kiểm và input SHA](artifacts/b17_resource_ledger_20261119/run_audit.py),
[verification](artifacts/b17_resource_ledger_20261119/verification.json),
[test log](artifacts/b17_resource_ledger_20261119/final_tests.log),
[paired replay](artifacts/b17_resource_ledger_20261119/paired_summary.json).

## Bổ sung sau quan sát của user: Nộ khi đổi lượt và nhận đòn

User nhắc Nộ có thể bị Hút, tăng khi bị đánh, và có thể tăng5 qua lượt.
Đã đối chiếu lại đúng25 khoảng BOSS→LOCAL phía trên, chỉ xét Nộ người
chơi phòng thủ, sau khi tách lượng POWER/STEAL được báo:

| Hiệu ứng quan sát trong lượt boss | Số khoảng | Phần Nộ tăng ngoài flow đã báo |
|---|---:|---:|
| Không có DAMAGE HP dương | 17 | +5 ở cả17 |
| 1 DAMAGE HP dương, `full_power` null | 6 | +20 ở cả6 |
| 1 DAMAGE HP dương, `full_power=true` | 2 | +35 ở cả2 |

Trong17 khoảng đầu có2 khoảng BLOCK dương nhưng không mất HP; vẫn chỉ+5.
Có3 khoảng bị Hút Nộ, đã tách lượng mất trước khi tính các phần tăng trên.
Ví dụ Nộ90, bị Hút45, published sau50 phù hợp với90−45+5.

Mẫu này ủng hộ giả thuyết cơ sở+5 và nhận đòn thêm15 hoặc30 theo loại đòn;
không đủ chốt số đó cho mọi turn/pet/boss. `full_power=null` không là false.
Chưa xác minh mốc tick/thứ tự spend/steal, multiple hit/skill, khi chạm trần
hoặc áp dụng đối xứng khi boss là bên nhận đòn. Đây là phát hiện post-hoc
trên cùng nhóm, không là holdout hoặc công thức dự đoán được nghiệm thu.

Chỉ bổ sung bằng chứng và ưu tiên nghiên cứu, không đổi runtime source
`de63bc05…`, hằng số gameplay, quyền skill/PASS hoặc mở trận mới. Nộ đọc
thực từ game vẫn là căn cứ đủ điều kiện ra skill.
[Script đối chiếu và25 record có nguồn](artifacts/b17_rage_hit_followup_20261119/review.json).
