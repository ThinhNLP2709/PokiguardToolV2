# Kiểm trực tiếp bản sửa rủi ro lấp bàn — 19/11/2026

Đã hoàn thành đúng hai trận mới: một BASIC và một Suy luận. Cả hai WIN,
nhận thưởng và về phòng. Tool PID 27924 dừng đủ 1/1. Đây là kiểm chức năng
có giới hạn trên source mới; hai bàn khác nhau nên không so hiệu quả bằng
số lượt hoặc suy ra win rate.

## Phạm vi và chuẩn bị

Source giữ nguyên cả hai trận:
`17c35c7ee9dd96cfc596f851daeec950b481d2a6202e22bf92ff48c9253ea89d`.
Game B17 SHA `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.
Solo/Priest ID 1845/cấp 131/Demon Aegis ID 560, ăn Khiên, mốc 4 Kiếm hiệu
dụng, pet thường/không tiến hóa/nội tại; foreground, hai lần nhấp, 1280×640.
Random thời gian và 10% tọa độ giữ nguyên. Full gear vẫn UNKNOWN.

Lúc kiểm đầu phiên, game đã ra bản đồ Bóng đêm và có nhắc sức khỏe. Đã đóng
popup qua UI, đối chiếu đúng callback/Button Priest bằng reader chỉ đọc rồi
click bình thường để vào lại phòng mới `Coop_300394`. Không dựa vào số thứ
tự badge hoặc tọa độ cũ. Đây không phải re-entry trong trận hoặc hồi phục
kỹ thuật do phiên kiểm mới gây ra. Tool cũ đã dừng được đóng trước khi mở
phiên riêng.

Qualification hiện tại qua đủ 14 gate, worker/writer đóng và không mất log.
Profile riêng dùng **tám mẫu SWAP sent/ACK BASIC mới cùng source/build/host**;
không sửa pin hoặc tái gắn hồ sơ cũ. Giao diện Suy luận được đối chiếu trước
khi nhấn Bắt đầu. Cài đặt thường của người dùng giữ nguyên.

## Kết quả

| Mục | BASIC | Suy luận |
|---|---:|---:|
| Match | M_c2050523 | M_d1b1a9b4 |
| Nước ta / lượt boss | 9 / 8 | 10 / 9 |
| SWAP ACK | 8 | 9 |
| Nước cuối chuyển terminal | 1 | 1 |
| Kết quả | WIN STRONG, nhận thưởng/về phòng | WIN STRONG, nhận thưởng/về phòng |
| Safe stop / recovery / PASS | 0 / 0 / 0 | 0 / 0 / 0 |

Suy luận có **10 snapshot/decision và 30 ROOT/FRESH/FINAL hợp lệ**. Cả 10
nước thực gửi khớp decision theo session/turn/seq/board/critical-state hash.
Có năm nước khác BASIC, cả năm được SWAP ACK. Nước cuối chuyển terminal
được kiểm bằng HP boss 0 và kết quả STRONG, không tính làm mẫu ACK.

Log AI có 61 record, ghi/flushed đủ, 0 dropped/fault. Một worker được tạo và
reap. Summary lớn nhất **11.793/12.000 byte**; giữ đủ attribution của
baseline/proposal. Không chỉ căn cứ trạng thái tab AI để kết luận có suy luận.
Nhãn UI_REASONING_COHORT_CHANGED tạm lúc lượt boss vẫn là giới hạn UI đã ghi
trước đó; các receipt ở lượt ta đều hợp lệ, không phát sinh safe stop.

## Nhánh rủi ro mới đã thực thi

Trong 20 bản ghi candidate được giữ, có một candidate ở lượt 13 mang hazard
một ô chưa biết, mức 3 Kiếm hiệu dụng. T của nó mở từ 0,225 lên khoảng
0,71181 với reason `KNOWN_REPLY_AND_REFILL_SWORD_SENSITIVITY`. Candidate này
không được chọn. Đây là bằng chứng nhánh mới chạy trên dữ liệu native và
qua đường summary/worker/selector; chưa chứng minh nhánh mới là nguyên nhân
đổi lựa chọn ở lượt đó hoặc kết quả nước thay thế sẽ tốt hơn.

Không có xác suất refill, công thức sát thương, lợi ích refill giả định,
training hoặc nhãn tối ưu được tạo. Mẫu này chỉ thuộc swap family và cấu
hình nêu trên, chưa nghiệm thu toàn bộ các pet/style/skill hoặc gói ZIP.

## Khoảng trống dữ liệu còn giữ nguyên

BASIC có 15 batch outcome CAPTURED và một INVALID với reason
`OPERATION_SHAPE_OR_LIMIT`. Không có raw proof đủ để phân biệt chính xác
lỗi shape với quá giới hạn ops; không tự gán nguyên nhân là quá nhiều item
hoặc tăng giới hạn để cho qua. Batch bị từ chối là chẩn đoán optional, không
ảnh hưởng bàn đã chấp nhận, gameplay hoặc tám mẫu timing hợp lệ.

Exporter boss-interval hiện từ chối cả tám khoảng BASIC vì có outcome bị loại
trong file; không gọi đó là tám khoảng đã thu đủ. Đây là mục cần kiểm offline
về capture và phạm vi loại interval, không phải lỗi safe stop trong trận này.

Suy luận có 19 batch CAPTURED/0 INVALID, 91 STAT_CHANGE và 31 DESTROY. Nối
được tám khoảng boss với before/after, một batch không có đúng một SWAP;
boss có chín lượt nên vẫn không coi là complete effect coverage.

## Đóng cap và bằng chứng

Cap mới 2/2 đã dùng hết, tổng ledger lịch sử 13 trận được giữ riêng theo
source/cohort. Không tự chạy thêm trận, build, thay source hoặc preferences,
rebind profile, commit/push. Game ở đúng room Coop_300394, tool đang dừng.

- [Closure tổng và giới hạn](artifacts/refill_risk_native_20261119/closure.json)
- [BASIC và timing gốc](artifacts/refill_risk_native_20261119/live/closure.json)
- [Nối decision với nước thực gửi](artifacts/refill_risk_native_20261119/reasoning/closure.json)
- [Nhánh refill và ngân sách summary](artifacts/refill_risk_native_20261119/feature_review.json)
- [Qualification cùng source](artifacts/refill_risk_native_20261119/qualification/qualification.json)
