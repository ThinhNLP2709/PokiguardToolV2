# Adviser — giữ phần nhìn trước đã xác minh

**18/11/2026: hoàn tất offline; chưa kiểm native source mới.**
User yêu cầu tiếp tục sau phiên 3 BASIC + 3 REASONING. Đợt này chỉ phân tích
file và sửa adviser; không đọc/điều khiển game hoặc chạy thêm trận.

## Điều rút ra từ 18 thế bàn mới

11 nước đổi so với BASIC đều có ACK trong phiên source trước. Đối chiếu
đầu vào và score đã dùng cho thấy các nhóm có chồng nhau:

| Đặc điểm của nước được chọn so với BASIC | Số nước |
|---|---:|
| Nhiều Kiếm hơn trong phần phá đã biết | 7 |
| Cận trên proxy rủi ro của phản hồi đã biết thấp hơn | 9 |
| Tiến triển tài nguyên tốt hơn theo proxy hiện tại | 6 |
| Proxy tự bảo vệ cao hơn | 4 |
| Tránh ăn Hút khi boss có 0 Mana | 3 |

Đây là giải thích lựa chọn, không phải nhãn damage hoặc chứng minh nguyên
nhân thắng. Log không tự huấn luyện mô hình, và không có trọng số nào được fit.

Hai ca dùng một bước (`M_3759edec`, lượt server 3 và 9) không bị hết thời gian
hay quá nhiều nominal ties. Mỗi ca có một nhánh còn hiệu ứng/viên rơi chưa
xác định, không có phản hồi boss đã biết để tính phần chuẩn bị. Policy cũ
bỏ toàn bộ shortlist đã nhìn trước nếu chỉ một nhánh chưa hoàn tất. Hai ca
này vẫn gửi nước hợp lệ và được game xác nhận trong phiên đã đóng.

## Thay đổi

Chỉ sửa `plan_common` trong planner:

- Điểm chuẩn bị `_setup` được chuẩn hóa trong [0,1]; sau discount 0,5, nhánh
  chưa mô hình hóa nhận khoảng **[0;0,5]**, trạng thái UNSUPPORTED. Cận dưới
  bằng 0, không cộng cơ hội viên rơi thành điểm chắc chắn.
- Giữ cả cận trên của BASIC khi tương lai của nó chưa biết. Nước khác vẫn
  phải có utility thấp nhất vượt utility cao nhất của BASIC ít nhất 0,05.
- Giữ các nhánh đã hoàn tất khi một số nhánh còn thiếu dữ liệu. Diagnostics
  ghi `lookahead_unknown_roots`; trạng thái từng nhánh vẫn giữ UNKNOWN hoặc
  PARTIAL. `LOOKAHEAD_COMPLETE` nghĩa là hoàn tất so sánh các khoảng, không
  có nghĩa mọi diễn biến đều đã biết.
- Nếu toàn bộ tương lai đều không mô hình hóa được, giữ kết quả một bước.
  Nếu chạm node cap, deadline hoặc bị cancel, bỏ refinements chưa hoàn tất
  và dùng kết quả một bước như trước.

Không đổi weights, shortlist, budget, luật BASIC/PASS, geometry/solver,
read/input/ACK/QTE, FarmRunner, admission, profile hoặc version.
AST ngoài `plan_common` khớp bản trước; audit toàn bộ Python source chỉ thấy
planner thay đổi và một module test mới.

## Đối chiếu 584 tình huống

566 tình huống cũ + 18 snapshot nguyên vẹn của B16. Input pin SHA, paired
replay dùng cùng dữ liệu, không dùng kết quả thắng/thua sau đó làm feature.
205 ca cũ được dựng lại từ export đã pin; raw log lịch sử không được tái
xác minh trong đợt này. Các case đã dùng để nghiên cứu là regression, không
phải holdout độc lập.

| Đo offline | Trước | Sau |
|---|---:|---:|
| Lựa chọn hợp lệ | 584 | 584 |
| Hoàn tất so sánh nhìn trước | 559 | 571 |
| Dùng một bước | 25 | 13 |
| Tổng node | 2.144.969 | 2.144.969 |
| Node tối đa mỗi ca | 18.000 | 18.000 |

583 ca giữ nguyên nước; **1 ca Mega đổi nước**. Trong 18 ca B16 vừa thu,
không đổi lựa chọn, coverage nhìn trước tăng 16 → 18. 13 ca một bước còn lại:
9 ca tương lai chưa mô hình hóa được toàn bộ, 4 ca chạm node cap. Không biến
chúng thành kết quả nhìn trước hoàn chỉnh bằng cách tăng giới hạn.

Ca Mega đổi: `archived_mega_galaxy_swaps`, index 62. Một bước chọn
`(6,3)↔(7,3)`, lấy 7 Kiếm nhưng còn hiệu ứng chưa xác định. Bản mới chọn
`(0,6)↔(1,6)`, lấy 6 Kiếm và giữ đủ mục tiêu trong ấn qua cả 9 phản hồi
đã mô phỏng (1 Sword-first + 8 phương án khác), H=[0,5;0,5]. Nước mới vượt
cận trên BASIC theo margin hiện có. Đây là cơ sở cấu trúc của lựa chọn;
không bảo đảm thắng, sống sót hoặc biết trước damage/viên rơi.

Latency chỉ đo trong replay với clock quyết định cố định; p50 khoảng
124,6 → 123,3ms, p95 khoảng 348,3 → 352,6ms. Không xem đây là native reserve
hoặc bằng chứng chạy nhanh hơn. Số node không tăng.

## Kiểm tra và giới hạn còn lại

- Bộ kiểm rộng: **140 test, 137 PASS, 3 FAIL**. Cả 7 test mới đều PASS, gồm
  ca native đã lưu, ca Mega đổi nước, BASIC có tương lai chưa biết, toàn bộ
  tương lai thiếu model, node cap/deadline/cancel và worker thật qua host,
  fresh/final. Host từ chối diagnostics bị sửa để giấu nhánh chưa biết.
- 3 lỗi nằm trong `test_reasoning_config_projection`: ancestry hash của
  `reasoning_operational.py`, `reasoning_swap_timing.py`, và expectation
  118 case trong khi harness trả 120. Chạy lại đúng 3 test với planner đóng
  băng trước sửa vẫn lỗi y hệt; hai runtime file đó không đổi so với source
  đã kiểm live. Không sửa pin/expectation hay nới gate lịch sử để báo xanh.
- Replayer từ archive đã smoke 3/584 ca, có nhãn sample_limited; không cộng
  ba ca đó lần nữa vào số 584. Dataset và before/after source được giữ cùng
  manifest; output tạm luôn nằm dưới `temp/reasoning/`.

Source khi replay là `3a08bb19…`; sau khi thêm đúng module test mới, source
cuối là `9b4a21096f4efccc630039b790508f5f0a296bbd4cc0e4d9661b94fa7c36cb27`.
Planner runtime không đổi giữa hai mốc này. Cấu hình chính của user giữ
nguyên. Bằng chứng live source `836a5e09…` vẫn đóng với scope cũ; không tái
gán timing/authority của nó sang source mới. Chưa build, bump version hoặc
xác nhận bản ZIP.

- [Receipt kiểm tra và nguồn](artifacts/adviser_bounded_future_20261118/verification.json)
- [Paired summary](artifacts/adviser_bounded_future_20261118/paired_summary.json)
- [Giải thích 11 nước thực tế](artifacts/adviser_bounded_future_20261118/native18_explanations.json)
- [Patch](artifacts/adviser_bounded_future_20261118/change.patch)
- [Log 140 test](artifacts/adviser_bounded_future_20261118/final_tests.log)
- [Ba lỗi với planner trước sửa](artifacts/adviser_bounded_future_20261118/legacy_before_planner.log)

Reproduce bằng bộ dữ liệu đã đóng băng, không game IO:

```powershell
python -B docs/phase5/artifacts/adviser_bounded_future_20261118/replay.py --out temp/reasoning/bounded-future-replay
```

Điểm tiếp theo là kiểm native source mới bằng hiệu chuẩn/cap mới, rồi thu
thêm trận dài có skill/context đầy đủ. Bộ mẫu này chưa đủ fit damage hoặc
chứng minh tỷ lệ thắng tăng. Không tự mở lại cap 6 trận đã đóng.
