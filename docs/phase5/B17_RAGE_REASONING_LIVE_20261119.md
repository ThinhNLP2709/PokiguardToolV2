# Kiểm Suy luận B17 trên source hiện tại — 19/11/2026

Đã hoàn thành một trận Suy luận có giới hạn mới, theo yêu cầu người dùng
“Vậy kiểm suy luận đi”. Tool dừng đủ 1/1 ở lobby Priest cấp 131. Kiểm chức
năng đạt; không suy ra tỷ lệ thắng hay hiệu quả từ một trận.

## Phạm vi và chuẩn bị

Source giữ nguyên trước/sau:
`e48e94d3302b95fd2b9d0c37ed7815bc50d23f0ffc9439bec1dbb4defffb5561`.
Game B17 SHA `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.
Solo, Priest ID 1845/cấp 131/room Coop_310394; Demon Aegis ID 560, ăn Khiên,
4 Kiếm hiệu dụng, pet thường/không tiến hóa/nội tại. Full gear UNKNOWN.
Account alias và lobby được kiểm lại trước chạy, không gộp các account/boss
khác thành một cohort. Main preferences không đổi.

Qualification cùng source đạt toàn bộ 14 gate: transport, boundary, worker,
writer và log accounting. Đo 100 bộ ROOT/FRESH/FINAL giả lập, max tổng
1,5485 ms; đây không phải 100 mẫu native. Runner chỉ đổi pin source so với
runner trước, giữ kiểm frozen source và fixture đã review. Baseline controller
cùng byte với lần qualification main trước.

Profile riêng được tạo từ **bảy mẫu sent/ACK BASIC mới cùng source/B17/host**
của phiên sửa collector, không rebind profile cũ. Authority load hợp lệ,
chỉ swap family; budget 4000 ms, foreground/two_click, random thời gian và
10% tọa độ giữ nguyên. Tool cũ được đóng sau khi xác nhận đã hoàn thành.
Phiên mới PID 19252, không auto-start; bắt đầu bằng computer-use trên UI.

## Kết quả native

Match `M_acace752`, farm `d477a9ad26af465d8710e98757cde4ad`:

| Mục | Kết quả |
|---|---|
| Kết quả | WIN STRONG, nhận thưởng và trở về đúng lobby |
| Nước ta / lượt boss | 14 / 13 |
| SWAP ACK / nước cuối chuyển terminal | 13 / 1 |
| Safe stop / recovery / PASS | 0 / 0 / 0 |
| Quyết định AI / xác nhận ROOT-FRESH-FINAL | 14 / 42 hợp lệ |
| Nước thực gửi khác BASIC | 11 |
| Log AI | 85 record, ghi đủ, 0 loss/fault |
| Worker | 1 tạo, 1 reap |
| Compute AI lớn nhất | 209,5739 ms |

Cả 14 nước thực gửi khớp decision đã nối theo source/session/turn/seq/board/
critical state hash. Không chỉ căn cứ nhãn UI để kết luận Suy luận hoạt động.
Nước cuối có ACTION_ABORTED_STATE_CHANGED khi chuyển terminal; xác nhận bằng
HP boss 0, result STRONG và nhận thưởng, không dùng làm mẫu ACK.

Nhãn UI_REASONING_COHORT_CHANGED có thể xuất hiện khi lượt boss như mốc trước;
trong trận này 42 receipt ở lượt ta vẫn VALID_COMPLETED_COMMON. Đây không là
safe stop. Các lần provider bỏ snapshot chưa ổn định không phải bỏ lượt:
14 lượt ta đều có action, không có PASS.

## Nhánh tài nguyên và collector đã chạy thật

Trong 28 bản ghi candidate được giữ trong decision summary (không phải toàn
bộ không gian tìm kiếm), 10 bản ghi đánh dấu thứ tự tiêu Nộ khi tấn công chưa
biết; năm bản ghi có khoảng stockpile khác 0. Cả 10 không cộng chắc bonus mở
skill sau tấn công. Có một candidate thay đổi reply risk khi xét known gain.
Đó là bằng chứng nhánh mới được thực thi, không phải nhãn nước đi tối ưu.

Collector giữ 25 batch CAPTURED, 0 invalid; 111 STAT_CHANGE và 32 DESTROY.
Có 54 POWER update, gồm 21 bước +5 và sáu bước FULL_POWER −100. Đây vẫn là
quan sát, chưa chốt công thức Nộ/kiếm. Exporter nối được 10 khoảng boss với
before/after; boss có 13 lượt nên không gọi là coverage đầy đủ.

## Đóng phiên

Cap mới 1/1 đã dùng hết, tổng nhóm lịch sử 11 trận, không reset cap cũ.
Tool đang dừng; không tự mở thêm trận, build, push hoặc train. Source và
cài đặt người dùng giữ nguyên. Kết quả chỉ xác minh một trận Solo/Priest131/
DemonShield với swap family; chưa là nghiệm thu mọi lối chơi, skill hoặc ZIP.
Hai bàn BASIC trước và bàn Suy luận khác nhau: số nước 8 và 14 không đủ
kết luận chế độ nào nhanh hơn.

- [Closure và nối từng nước thực gửi](artifacts/b17_rage_reasoning_20261119/reasoning/closure.json)
- [Kiểm nguồn, log và nhánh tài nguyên](artifacts/b17_rage_reasoning_20261119/verification.json)
- [Qualification cùng source](artifacts/b17_rage_reasoning_20261119/qualification/qualification.json)
- [Profile và số đo BASIC gốc](artifacts/b17_rage_reasoning_20261119/reasoning/data/preferences/reasoning_acceptance/common.json)
