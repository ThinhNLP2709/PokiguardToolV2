# Demon: thu Máu trong đợt quét đầu và giới hạn bằng chứng Nộ — 20/11/2026

Đã hoàn tất hai việc offline kế tiếp của [kiểm độ phủ](DEMON_EVIDENCE_COVERAGE_20261120.md):
rà ý nghĩa/presence/order của `fullPower`, và kiểm nguồn nước mở đầu. Đồng
thời sửa một điểm adviser bỏ mất lợi ích đã biết khi phần tiếp diễn chưa rõ.
Không fit công thức damage khi ngữ cảnh còn thiếu.

## Sửa đánh giá nước quét Demon

Trước sửa, khi quét đầu còn cascade chưa mô hình được, adviser đã giữ giá
trị Kiếm của đợt đầu nhưng đặt toàn bộ điểm bảo vệ P về UNKNOWN `[0,1]`.
Điều này bỏ luôn cơ hội thu Máu đã có trên geometry đầu, kể cả lúc ta yếu máu.

Giờ, riêng SWAP Demon có geometry quét đã khai báo và HP trước nước đã biết:

- Giữ phần dưới của P bằng proxy thu Máu đang dùng:
  `min(1, số Máu hiệu dụng / 6) × tỷ lệ HP đang thiếu`. Đây là giá trị cơ hội
  thu viên trong đợt đầu, không phải lượng HP hồi hoặc sàn HP sau hành động.
  Ví dụ ta còn30% HP, quét3 Máu: P từ `[0,1]` thành `[0.35,1]`.
- Không thêm sàn cho Khiên/Hút hoặc skill hồi máu. HP đầy, HP chưa biết,
  không thu Máu, geometry không xác minh hoặc lối chơi khác giữ cách cũ.
- R/T/B vẫn UNKNOWN khi continuation chưa mô hình được; không chứng nhận
  sống sót, kết liễu, tài nguyên ròng hoặc phản công. Không lấy refill thực
  tế hoặc outcome tương lai làm input cho điểm trước nước.
- Cùng logic cho5 viên mục tiêu Demon; không thêm cài đặt hoặc ngưỡng bảo vệ.
  Việc kiểm native các pet/target khác vẫn giữ trạng thái cũ.

Chỉ đổi `_score` trong `reasoning_common_planner.py`, thêm8 test hồi quy.
475 file Python cũ còn lại nguyên byte. BASIC, quyền PASS từ game, preflight/
ACK, timing, input, reader, collector, các lối chơi khác giữ nguyên.

Source trước: `f595bdb51359394b31a812699b6dc7864893780cc501dfa78373b9dfc7e969ac`.
Source sau: `61bead5bf7a1fd8651e4d8b2b129e2b2c9c5d0db71559b25b6a27b1c129c596b`.

## Đã kiểm gì

| Kiểm chứng | Kết quả |
|---|---:|
| Test tập trung và hồi quy liên quan | 121 PASS, gồm8 test mới |
| Replay cùng trạng thái trước nước | 648:192 Demon +456 lối khác |
| Trạng thái có candidate giữ thêm giá trị thu Máu | 16, trong đó9 từ nhóm native B16/B17 |
| Lựa chọn trước/sau thay đổi | 0 /648 |
| Lối chơi khác giữ toàn bộ decision/score/diagnostics | 456 /456 |
| Số node từng trạng thái giữ nguyên | 648 /648 |
| Chạm node cap trước/sau | 2 /2 |
| Worker summary lớn nhất | 11990 /12000 byte |

Replay thêm5 snapshot từ cặp retention mới vào corpus643 cũ. Giữ nguyên
budget8 root/32 scenario/18000 node/4000ms. Dữ liệu đã được nghiên cứu,
không là holdout độc lập. Đây là sửa độ đầy đủ của đánh giá; **chưa có bằng
chứng thay đổi lựa chọn hoặc tăng tỷ lệ thắng**. Không ép tăng override.

## Nộ: điều đã xác minh và điều chưa thể suy ra

Trên67 LOCAL đã bind, giữ39 DAMAGE component:36 `full_power=true`,3 `None`.
Có27 update của ta có reason `FULL_POWER`, tất cả delta−100 trong tập này.
16 hành động có cờ true dù nộ trước nước<100;9 hành động có true nhưng
không giữ được update tiêu nộ có nhãn tương ứng. Không gọi9 trường hợp đó
là server không tiêu nộ: capture cả hành động vẫn chưa chứng minh đầy đủ.

Do đó chưa được dùng cờ true để mặc định trừ100, hoặc suy công thức damage
từ nộ đầu lượt. `None` không là false. Raw key-presence của `fullPower`
không được giữ trong log cũ, nên không khôi phục được thiếu field so với
null; bổ sung thu mới cần giữ đúng metadata này, không thêm đọc bộ nhớ.

Native B17 cùng SHA game đã pin xác minh:

- `WsCombatStepDTO.fullPower` là bool không nullable, offset `+0x40`.
- `MatchService.ParseCombatBatch` RVA `0xB98E10` lấy literal `combatSteps`,
  gọi `JToken.ToObject<List<WsCombatStepDTO>>()` tại `0xB99210`, gán list
  batch tại `0xB99215`. Đây là đọc kết quả nhận về, không là công thức damage.
- Chính sách server bỏ field, ngưỡng/cost hiện hành của trận và ý nghĩa
  đầy đủ của cờ còn UNKNOWN. Chỉ số trong `ops` và `combatSteps` thuộc hai
  list riêng; không tự nối thành một thứ tự effect chung.

## Nước mở đầu: thêm một tầng bằng chứng riêng

Nước1 của `M_1d67187c` có đủ snapshot adviser trước nước, sent action, ACK,
typed response và trạng thái published sau nước. Đã khớp chính xác session/
match/sequence/turn/board, bảng viên và stats hai bên; không dùng timestamp
gần nhất. Ta và boss đều bắt đầu nộ0; nộ ta sau là80, HP ta76643→81993;
boss407053→216058. DAMAGE ghi190995 và true; ops của ta chỉ giữ POWER+80.
Đây là ví dụ cụ thể cho lý do chưa được suy ra chi phí/nộ từ cờ true.

Giữ mẫu này thành tầng `ADVISER_SOURCE_SENT_ACK_PUBLISHED_AFTER`, **không**
đổi hợp đồng published-before/published-after hoặc chèn vào67 mẫu cũ.
Hai nước terminal tiếp tục bị loại khỏi ordinary ACK; HP0 không trở thành
nhãn damage tiềm năng. Ba effect thiếu không được khôi phục hoặc tự điền.

## Điểm chốt và bước còn lại

Phần offline này đã đóng. Source mới chưa kiểm trực tiếp; native proof và
profile source `7a6503d4…` giữ nguyên, không rebind. Tổng21 lượt thử cũ đều
đóng, còn0. Đợt này0 attach/input/trận mới/train/build; game/UI chưa kiểm lại.

Mốc live tiếp theo cần mở riêng trên source mới: BASIC control mới trước,
rồi Suy luận, giới hạn cụ thể trước khi mở. Kiểm hành vi/thu log và so hai
lựa chọn trên cùng pre-action state. Không chạy thêm chỉ để lấp ô số Kiếm,
không lấy WIN/số lượt làm nhãn. Các mẫu damage định lượng tiếp tục cần
key-presence, gear/buff/crit/khắc hệ, effect completeness và trận độc lập;
không biến lịch sử đã xem thành model đã hiệu chuẩn. Mega/Galaxy còn hoãn.

[Replay và giới hạn](artifacts/demon_health_prefix_20261120/replay_summary.json) ·
[Các candidate thu Máu](artifacts/demon_health_prefix_20261120/health_floors.json) ·
[Rà Nộ](artifacts/demon_health_prefix_20261120/power_order_review.json) ·
[Nguồn nước mở đầu](artifacts/demon_health_prefix_20261120/opening_review.json) ·
[Native B17](artifacts/demon_health_prefix_20261120/static_semantics.json) ·
[Scope và tests](artifacts/demon_health_prefix_20261120/scope_review.json) ·
[Kiểm cuối](artifacts/demon_health_prefix_20261120/final_verification.json).
