# Adviser: UI đúng lý do, bất định damage và replay cùng bàn — 22/11/2026

**Ba phần offline đã hoàn tất. Không thêm trận Priest131 hoặc mở cap live mới.**
Source `1d8349dcb4c6d405b9d56ca8dcf87066cdbf2cfde5af79cd454a481ff23514cb`,
508 Python: 503 file cũ nguyên byte; sửa 2 file UI, thêm module uncertainty
offline và 2 file test. Gameplay solver/chooser, normal input, native
admission và rule PASS giữ nguyên so với source505 vừa được kiểm live.
Mốc gameplay Demon đã chốt; nghiên cứu damage tiếp tục là nhánh adviser
chung và không được kéo dài điều kiện hoàn thành cơ chế Demon.

## 1. Cảnh báo UI đã tách lý do

Trước đây `_supervise` dùng `not authority.matches(...)` cho một nhãn
COHORT_CHANGED. Nhưng matches còn kiểm expiry, config và timer; nhãn đó
không đủ kết luận đổi tài khoản/đồ. Log cũ không giữ mọi packet mà thread
hiển thị đã đọc, nên chưa quy chính xác 51 snapshot cũ cho một nguyên nhân.

UI mới phân biệt:

| Trường hợp | Hiển thị |
|---|---|
| Chưa có timer game được xác minh | Chờ timer từ game |
| Profile hết hạn | Hồ sơ suy luận hết hạn; dùng Cơ bản |
| Policy/config thay đổi | Cài đặt lối chơi thay đổi; dùng Cơ bản |
| Context khác còn lại | Dữ liệu trận chưa khớp hồ sơ |
| Không đọc/kiểm được context | Chưa kiểm tra được ngữ cảnh |

Chờ timer không bị ghi là đổi đồ, không gắn cờ selection authority và
không disable bridge/stop farm. Khi timer hợp lệ trở lại, lý do được cập
nhật theo observation mới. Hàm `CommonNativeAuthority.matches` và các gate
ROOT/FRESH/FINAL giữ nguyên, không nới kiểm để loại bỏ cảnh báo.

## 2. Đã thêm cách diễn giải bất định, chưa đưa predictor vào gameplay

`damage_uncertainty.assess` nhận đúng request trước nước và một forecast
được pin riêng. Nó giữ khoảng thực nghiệm cùng các rủi ro rõ ràng:
crit chưa quan sát trước nước, Khiên và thứ tự hiệu ứng, tiêu/nhận Nộ,
Hút, refill/cascade và độ phủ component chưa hoàn chỉnh.

- Không trừ toàn bộ Khiên trước nước khỏi forecast như một công thức server.
- Khoảng từng quan sát vượt HP boss vẫn không trở thành chứng nhận kill.
- Khoảng thấp hơn HP không chứng minh refill/phần hiệu ứng còn thiếu không
  thể kết liễu. Không gán xác suất crit hoặc biên damage chắc chắn tự tạo.
- Model từ chối dự đoán vẫn trả quyền cho adviser hiện có; không phát
  SAFE_STOP, yêu cầu bỏ lượt hoặc input mới.
- `compare_references` chỉ so hai nước cùng bàn/stats/settings; point hoặc
  khoảng tách nhau không thành nhãn nước tối ưu.

Module này phục vụ audit/replay offline. Không fit model mới, đổi target,
đổi weights hoặc nhập module vào planner để đổi nước đánh. Đây là cải tiến
đánh giá bằng chứng, chưa phải chứng minh tăng khả năng thắng của AI.

## 3. Replay cùng bàn và độ đa dạng dữ liệu

Đọc đúng 35 combat/311 swap đã pin, lấy 169 CommonProblem từ 17 diagnostic
file. Giữ bàn và facts trước nước; không chèn refill/outcome thực vào nước
thay thế. Chạy chooser hiện tại và chiếu riêng BASIC/selected trên cùng bàn:

| Kết quả cơ học | Số trạng thái |
|---|---:|
| Cùng action BASIC | 78 |
| Có lợi thế cơ học có điều kiện | 2 |
| Có lợi ích và chi phí đánh đổi | 49 |
| Chưa đủ để so cùng phạm vi | 40 |
| **Tổng** | **169** |

91 action khác BASIC không đồng nghĩa 91 action tốt hơn. Ví dụ ở
`M_3dd29044`, một nước giữ cùng phần thu đã biết nhưng giảm cơ hội trả lời
Mana/Hút của boss từ3 xuống0; đó là lợi thế trên phần bàn đã biết. Ở
`M_0b5c5e04`, BASIC lấy3 Máu, adviser lấy4 Kiếm hiệu dụng, nhưng để lại
cơ hội Mana/Nộ khác cho boss: vẫn là tradeoff, chưa có counterfactual win.

4 lựa chọn khác native lịch sử thuộc các source adviser cũ hơn. Chooser
hiện tại nguyên byte so với source505; thay đổi UI/uncertainty của mốc này
không đổi lựa chọn gameplay. Không gọi bốn ca đó là gain mới từ mốc này.

163 cặp SWAP được đánh giá bằng baseline/V2 đã khóa, mỗi model có cả
reference/guarded. Dữ liệu cũ dùng fold bỏ toàn source khỏi TRAIN; hai trận
mới nhất dùng model khóa trước thu. Không refit. 652 kiểm poison giữ nguyên
assessment khi thay post labels/crit. Tất cả vẫn là development đã xem.

| Có dự báo ở cả hai nước | Cặp | Khoảng tách được |
|---|---:|---:|
| Baseline reference | 59 | 0 |
| Baseline guarded | 51 | 0 |
| V2 reference | 50 | 0 |
| V2 guarded | 29 | 0 |

Mọi khoảng còn chồng nhau; các cặp khác thiếu forecast ở ít nhất một nước.
Do đó chưa có bằng chứng dùng damage model để phân xử các lựa chọn này.
6 cặp có PASS giữ riêng, không gán PASS thành damage0.

## Quyết định về live: đổi điều kiện thu, không lặp boss cũ

35 trận có cùng một chữ ký thông số setup và một bộ stats khởi đầu.
277/311 nước lúc HP ta trên50%; chỉ9 nước ở10–30%, không có nước ở≤10%.
Hai trận mới có9 bucket tình huống chưa thấy trong TRAIN và13/22 action
thuộc bucket đã có. Bucket là công cụ đo độ phủ, không phải luật game hoặc
thước đo chất lượng. Bàn random mới không tự là bằng chứng hữu ích mới.

Chốt: không tiếp tục Priest131 để lấy thêm cùng kiểu dữ liệu. Nếu kiểm live
tiếp, pilot mới tối đa2 lượt trên boss **cao hơn131 và tạo áp lực thực tế**,
giữ Demon Aegis ăn Khiên và đồ hiện tại. Giả thuyết cần kiểm là lựa chọn
giữa sinh tồn, tài nguyên và tấn công khi bị đe dọa, không lấy số WIN làm
tiêu chí. Boss cần đủ trụ nhiều lượt, đồng thời không giết ta ngay.

Trước khi mở pilot phải chọn được target Solo mở khóa và đọc đúng phòng.
BASIC1 thăm dò trước: chỉ mở R1 nếu có timing hợp lệ và tình huống định trước
(HP ta dưới30% kèm lựa chọn tài nguyên/tấn công có hệ quả khác nhau; hoặc
thiếu tài nguyên rõ rệt dưới áp lực boss). Nếu BASIC vẫn cùng kiểu dữ liệu,
đóng pilot tại1, không tiêu nốt lượt chỉ để đủ2. Không săn thêm crit hoặc
>128ops ở Priest, không mở lại 40 lượt cũ.

Computer-use được thử khởi tạo một lần ở mốc này, vẫn lỗi:
`failed to write kernel assets ... (os error 3)`. Không input nào được gửi,
không dùng helper UI thay thế. Read-only check thấy game vẫn mở đúng
`Coop_353375`, Demon560/Priest1845; chưa đổi boss. Vì không thể tự thao tác
đổi phòng/Start nên pilot chưa có request/profile/cap và chưa bắt đầu.
Không cần user thao tác lúc ngủ; khi tiếp tục sẽ cần boss mới và CU hoạt
động hoặc cú bấm trực tiếp. User đã cấp quyền thực hiện, không thiếu approval.

## Kiểm tra và giới hạn

13 test mới PASS; batch liên quan thực thi288 test,287 PASS. Một assertion
AST cũ `test_worker_change_only_adds_common_summary_attribution` vẫn dùng
fixture03/11, chưa tính helper chẩn đoán Máu20/11. Cả file test và runner
nguyên byte từ source505; không phải regression của thay đổi này. Giữ log
FAILED gốc và ghi rõ ngoại lệ, không tuyên bố full suite sạch.

Nhóm5 test legacy ProfileReview cũng gặp lỗi proof F1 đã cũ; lỗi tái hiện
giống nhau khi khôi phục hai module UI cũ trong bộ nhớ. Đây không phải
checkout toàn bộ source lịch sử, không phải lý do nới validator production.
Các log trước/sau giữ riêng. Common runtime mới dùng gate/bundle riêng.

Qualification mới trên đúng source508:14/14 gate PASS,300 checkpoint không
mất,worker/writer thu hồi. Triple p50=0,7276ms,p95=1,2178ms,max=1,5213ms.
Đây là kiểm synthetic, không tạo quyền native/timing hoặc nâng profile cũ.
Source508 chưa được kiểm live. Không build/version/commit hoặc sửa game.

[Checks và ngoại lệ](artifacts/adviser_uncertainty_20261122/checks.json),
[qualification](artifacts/adviser_uncertainty_20261122/qualification/qualification.json),
[replay](artifacts/adviser_uncertainty_20261122/replay/summary.json),
[độ đa dạng](artifacts/adviser_uncertainty_20261122/scenario_novelty.json),
[trạng thái môi trường](artifacts/adviser_uncertainty_20261122/environment_check.json).
