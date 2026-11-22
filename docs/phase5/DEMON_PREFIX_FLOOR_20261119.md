# Demon: giữ giá trị đợt quét đầu khi cascade còn chưa rõ — 19/11/2026

**Ưu tiên theo user: tiếp tục Demon trước; Mega và Galaxy để sau.** Việc
thiếu trace skill chủ động ở mốc trước không chặn nghiên cứu Demon passive.
Không tiếp tục nhánh skill/card/cost binding trong milestone này.

Đã sửa một điểm đánh giá quá thấp trong shared adviser: khi một nước Demon
còn cascade chưa giải quyết, code trước hạ toàn bộ F/D về khoảng 0–1 dù
mô hình hình học đã xác định đợt quét đầu ăn được kiếm và có thể đã đạt
mục tiêu quét danh nghĩa. Cái chưa biết ở phần tiếp diễn không làm phần
thu được đầu tiên biến thành 0.

Source trước `cbccf8c4…`; source sau
`1bd824c27677c7050112e049aa916d1b4858cb86d6b5904ced903d51fab16ee8`.
Chỉ đổi `_score` trong `reasoning_common_planner.py` và thêm test/fixture.
Tất cả hàm khác, weights, BASIC, owner/preflight/ACK, timing, input, PASS,
reader và runtime của Mega/Galaxy giữ nguyên. Không build hoặc mở trận mới.

## Giá trị giữ lại và phạm vi chưa biết

Chỉ áp dụng khi profile là Demon, coverage là
`CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY` và có residual chưa giải quyết:

- D giữ giá trị proxy đã tính từ kiếm đợt đầu, thường là
  `min(1, kiếm hiệu dụng đã biết / 8)`. Nếu model danh nghĩa hiện có đã giới
  hạn D theo mục tiêu thì giữ giới hạn đó, không thưởng kiếm thừa. Ví dụ đã ăn
  bốn kiếm thì D từ `[0,1]` thành `[0.5,1]`. Đây là proxy số kiếm, không
  phải phần trăm sát thương hoặc khả năng thắng.
- F chỉ giữ phần đã đạt mục tiêu danh nghĩa của đợt quét đầu. Đủ mục tiêu
  thì F `[1,1]`; chưa đủ vẫn `[0,1]`, không tự cộng kiếm từ refill.
- R/P/T/B vẫn UNKNOWN nếu phần tiếp diễn chưa đủ mô hình: không coi Nộ
  gross là Nộ để dành, không chứng nhận hồi máu/sống sót hoặc phản công.
- Không áp dụng cho Demon geometry chưa xác minh, ordinary cascade có thứ
  tự passive chưa rõ, hoặc các lối chơi khác. Không bỏ yêu cầu kiếm vật lý
  của mục tiêu Demon. Phần tính này không phụ thuộc tên viên kích hoạt;
  test gồm Khiên/Máu/Mana/Hút/Nộ.

Giới hạn trên F/D vẫn là 1; không thưởng thêm tương lai chưa quan sát.
F là mục tiêu theo setting/khai báo/model có phạm vi, **không là kill
certificate**. Mô hình quét đầu dựa vào khai báo geometry của user hiện có,
không nâng nó thành công thức server hoặc sát thương chắc chắn.

## Kiểm trên cùng trạng thái

Paired replay dùng 643 snapshot/cấu hình từ corpus đã đóng, gồm 187 Demon
và 456 của các lối chơi khác. Trước/sau dùng nguyên board, multiplier,
HP/Mana/Nộ hai phía, pet, settings và nguồn BASIC được ghi. Bản trước khớp
643 quyết định đã lưu. Các action mới đều hợp lệ theo owner/model hiện có.

| Kiểm chứng | Kết quả |
|---|---:|
| Test liên quan | 80 PASS, gồm 10 test mới |
| Trạng thái có candidate giữ được giá trị quét đầu | 14, trong đó 7 từ các cohort native B16/B17 |
| Lựa chọn đổi | 4 Demon: 2 archive, 1 snapshot B16, 1 snapshot B17 mới |
| Lối chơi khác | 456/456 decision, score, diagnostics giữ nguyên |
| Chạm node cap trước → sau | 2 → 2 |
| Root/scenario/node budget | 8 / 32 / 18.000, giữ nguyên |
| Worker summary lớn nhất | 11.990 / 12.000 byte |

Test kiểm lower bound qua các lượng kiếm bổ sung có thể xảy ra, goal chưa
đạt/đã đạt, physical floor, cả năm target, zero Sword, geometry không có
nguồn, giữ UNKNOWN cho tài nguyên/rủi ro và hai pre-action fixture native.
Không dùng kết quả sau nước trong fixture để chấm điểm trước nước.

Bộ dữ liệu đã từng được nghiên cứu, không phải holdout độc lập. Số mẫu,
override, utility và test xanh không là nhãn lựa chọn tốt hơn.

## Hai cặp native đổi lựa chọn

Số viên trong bảng là hiệu dụng, chỉ trong phần mô hình đã biết. Bản mới
đều có residual chưa giải quyết nên chưa có phản công settled đáng tin.

| Snapshot | Trước sửa | Sau sửa | Đánh đổi vẫn phải giữ |
|---|---|---|---|
| `M_4a7aa56b` / lượt 3, B16 | 1 Kiếm, 5 Mana, 5 Nộ, 5 Khiên, 4 Máu, 4 Hút | 3 Kiếm, 3 Mana, 5 Nộ, 6 Khiên, 6 Máu, 2 Hút | Mất 2 Mana/2 Hút; ô refill 24 → 25; cascade và phản công mới chưa biết |
| `M_d1b1a9b4` / lượt 1, B17 | 3 Mana, 4 Nộ, 3 Máu, không Kiếm | 3 Kiếm, 5 Mana, 6 Nộ, 8 Khiên, 2 Máu | Mất 1 Máu; ô refill 10 → 24; có cơ hội tiến công nhưng chưa chứng nhận damage/kill |

Ở cặp B17, trước nước ta có HP 76.643/109.491, Nộ 0; boss HP
407.053/581.505. Không dùng gross 6×20 Nộ để chứng nhận số dư sau nước;
việc nó góp vào burst danh nghĩa vẫn giữ khai báo user, không chốt thứ tự
server. Số dư ròng tiếp tục theo [audit Mana/Nộ](NET_RESOURCE_READINESS_AUDIT_20261119.md).

Cả bốn cặp đổi lựa chọn được giữ nhãn **INSUFFICIENT_DATA** cho so sánh
toàn bộ tương lai vì khác horizon hoặc chưa giải quyết residual. Có thể
giải thích phần kiếm/goal đã biết mà không tuyên bố nước mới tốt hơn toàn
cục. Không dùng WIN cũ của các trận này để nghiệm thu nước thay thế.

## Mốc tiếp theo

Tiếp tục **Demon**: kiểm source mới trực tiếp trong cùng nhóm pet/account/
boss, xem đợt quét, kết quả nước và timing; đối chiếu quyết định trên cùng
bàn. Hồ sơ native trước thuộc source cũ và cap đã đóng; không tự rebind
chúng sang bản chấm điểm mới. Mega/Galaxy và skill binding xếp sau.
Đợt này 0 live attempt, 0 game input, 0 train/build và 0 kill certificate.

[Paired summary](artifacts/demon_prefix_floor_20261119/summary.json) ·
[Các cặp đổi lựa chọn](artifacts/demon_prefix_floor_20261119/changed_cases.json) ·
[Verification](artifacts/demon_prefix_floor_20261119/verification.json) ·
[Script replay](artifacts/demon_prefix_floor_20261119/replay.py).
