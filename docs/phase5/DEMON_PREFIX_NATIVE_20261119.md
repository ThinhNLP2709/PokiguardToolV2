# Kiểm trực tiếp Demon sau sửa chấm đợt quét đầu — 19/11/2026

**Đã hoàn tất đúng 1 BASIC + 1 Suy luận**, cả hai WIN, nhận thưởng và về
đúng phòng. Nhánh giữ giá trị kiếm/goal của đợt đầu đã xuất hiện trong một
nước thực được chọn và ACK. Đây là nghiệm thu chức năng có phạm vi, chưa
chứng minh hiệu quả tổng thể hoặc sát thương tốt hơn.

Source giữ nguyên trong suốt hai trận:
`1bd824c27677c7050112e049aa916d1b4858cb86d6b5904ced903d51fab16ee8`.
Game B17 SHA `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.

## Phòng và phiên đo

Solo Priest cấp 131, ID 1845, room `Coop_300394`; Demon Aegis thường ID560,
ăn Khiên, ngưỡng danh nghĩa 4 Kiếm hiệu dụng, không tiến hóa, pet passive.
Random tọa độ tối đa 10% và các khoảng random thời gian giữ nguyên. Chữ ký
stat đầu trận hai phiên khớp: ta maxHP109.491/Mana2771/Nộ250/ATK1819;
boss maxHP581.505/Mana540/Nộ250/ATK766. Full gear vẫn UNKNOWN, không dùng
chữ ký stat thay bằng chứng toàn bộ đồ. Alias account và loadout được pin
riêng trong prepared/request, không trộn acc/pet/boss khác.

Đã dùng computer use để đóng popup sức khỏe trong lobby, đóng phiên tool
cũ đã hoàn tất, mở/chạy hai UI cách ly, kiểm tool dừng và game về phòng.
Không sửa preferences thông thường. UI cuối vẫn mở ở trạng thái đã dừng
1/1, PID28296; game ở lobby đúng boss, không có modal chặn lúc kiểm cuối.

Qualification offline mới chạy trên đúng source/host, đủ 14 gate PASS.
BASIC mới ghi 7 timing record: **6 mẫu đủ sent/ACK** dùng tạo profile riêng,
một nước terminal không được tính timing hợp lệ. Không rebind profile cũ.
Profile chỉ nghiệm thu họ input SWAP; phiên R giới hạn một trận và đã dùng.

## Kết quả vận hành

| Mục | BASIC | Suy luận |
|---|---:|---:|
| Match | `M_3176ba19` | `M_78f6ef49` |
| Lượt ta / boss | 7 / 6 | 9 / 8 |
| SWAP sent / ACK | 7 / 6 | 9 / 8 |
| Nước cuối chuyển terminal trước ACK | 1 | 1 |
| WIN, nhận thưởng và về phòng đúng | Có | Có |
| Safe stop / recovery / PASS | 0 / 0 / 0 | 0 / 0 / 0 |

Nước terminal có snapshot HP boss0 và UI WIN khớp; không coi bộ đếm
`swap_aborted_state_changed=1` ở đây là bỏ lượt hoặc lỗi dừng trước khi đánh.
Không lấy 7 và 9 lượt của hai bàn khác nhau để xếp BASIC/Suy luận hơn kém.

Suy luận có 9 decision, đủ **27 ROOT/FRESH/FINAL hợp lệ**, cả 9 nước gửi
khớp quyết định. Sáu nước khác BASIC đều ACK. Log55 record đủ, không mất/
fault, worker1/1 reaped; summary lớn nhất11.752/12.000 byte. Replay hiện tại
trên 9 snapshot khớp9/9 action thật.

## Nhánh mới đã tác động tại đúng một bàn

Lượt9, snapshot `8c9656dec70719e43846e31366dfc4412b6a46d9e226772146febf79cd4f70ef`:
ta HP78.517/109.491, Mana300, Nộ45; boss HP312.408/581.505, Mana90, Nộ105.

| Cùng snapshot trước nước | Phần viên hiệu dụng theo mô hình đã biết |
|---|---|
| BASIC và bộ chấm trước sửa | 4 Máu, không Kiếm |
| Suy luận mới, thực gửi và ACK | 3 Kiếm + 7 Mana + 7 Nộ + 5 Khiên + 3 Máu + 3 Hút |

Bản mới giữ F `[1,1]` cho goal danh nghĩa của đợt đầu và D `[0.375,1]`
cho ba Kiếm đã biết. Native summary có marker `DEMON_FIRST_WAVE_FLOOR`
trên đúng candidate được chọn; paired replay trước/sau cùng snapshot đổi
nước này, không đổi tám nước còn lại. Không dùng utility làm nhãn chất lượng.

**Đánh đổi:** mất một Máu hiệu dụng, ô refill chưa biết tăng3→24, residual
chưa giải quyết. Phản công settled, Nộ ròng, damage và kill tiếp tục chưa
biết. Hút3 không được tự đổi thành một lượng Mana/Nộ chắc chắn. Cặp này
giữ `INSUFFICIENT_DATA` cho so sánh toàn bộ tương lai, không gán “tốt hơn
tuyệt đối”. Năm cặp override còn lại cũng giữ dữ liệu lợi ích/cost và
UNKNOWN trong feature review.

## Khoảng thiếu dữ liệu cần làm tiếp trên Demon

BASIC giữ13 và Suy luận giữ14 typed outcome, đều CAPTURED, không có
rejection. **Điều này không chứng minh capture đầy đủ.**

Tám nước ACK của R đều có published state sau nước, nhưng ba nước ở lượt
5/9/15, post sequence12/20/32 chưa có typed combat-effect response tương ứng
được giữ. Trong đó có nước prefix ở lượt9. Vì vậy chỉ xác nhận nước đã gửi,
ACK và state sau; không gán damage/effect chi tiết hoặc số dư ròng cho phần
không giữ được. Chưa chứng minh nguyên nhân là operation limit/shape.

Đã audit riêng23 khoảng có cặp published trước/sau từ27 response giữ được:
81 update Mana/Nộ khớp delta, ba mẫu cap/floor; 55 lastStat khớp endpoint.
Không dùng chúng làm công thức server hoặc nhãn optimal-action.

**Tiếp theo vẫn là Demon:** nghiên cứu offline nguyên nhân thiếu typed
effect của ba nước ACK, ưu tiên các đợt quét. Mega/Galaxy tiếp tục để sau.
Không chạy thêm trận để lấp chỗ thiếu trước khi xem đường thu hiện có.

Cap mới2/2 đã đóng, tổng ledger nhóm15 trận; không reset case cũ. Không đổi
source/prefs, train hoặc build trong hai trận. Phạm vi native chỉ là Solo
Priest131/Demon Aegis ăn Khiên/SWAP; không mở rộng thành nghiệm thu mọi pet,
target, boss hoặc active skill.

[Closure và input SHA](artifacts/demon_prefix_native_20261119/closure.json) ·
[Các cặp cùng bàn và feature marker](artifacts/demon_prefix_native_20261119/feature_review.json) ·
[Coverage thiếu ba response](artifacts/demon_prefix_native_20261119/capture_coverage.json) ·
[Timing BASIC](artifacts/demon_prefix_native_20261119/live/basic_export.json).
