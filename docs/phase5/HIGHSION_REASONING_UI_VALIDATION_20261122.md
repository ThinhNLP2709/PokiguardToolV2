# Highsion165: kiểm Suy luận và sửa trạng thái chờ UI — 22/11/2026

Phiên Suy luận mới **WIN 1/1**, nhận thưởng và về đúng phòng, không safe stop,
recovery hoặc technical abort. Đã đóng phiên và tool. Sau đó sửa riêng nhãn UI
khi game tạm chưa có bàn ổn định; 48 kiểm tra liên quan và 14 gate offline đạt.
Không mở thêm trận, thay scorer, triển khai damage model hoặc build.

## Phạm vi và nguồn kiểm chứng

User đã yêu cầu tiếp tục sau khi đóng tool. Đây là bài kiểm chức năng Suy luận/UI
mới tối đa1 lượt, tách khỏi scout áp lực đã đóng tại BASIC1. Đọc lại 11 mẫu timing
BASIC cùng source/build/host/settings để tạo profile max1 mới; không gia hạn cap
scout hoặc đổi profile cũ. Sky tự bấm Start tool đúng1 lần; toàn bộ gameplay vẫn
qua FarmRunner và input thường. Không nhập chuột trực tiếp vào bàn game.

- B17, Highsion ID1651, cấp165 quan sát UI; RoomDTO level0 giữ riêng.
- `Coop_389316`, Demon Aegis560 thường, Khiên, ngưỡng4 Kiếm hiệu dụng, không
  tiến hóa; giữ đồ user đã chọn.
- Source native `1d8349dc…`/508 Python, farm `08743e7167664746b73f1c5308710924`,
  match `M_7a3a6509`, 04:09:35–04:12:05 UTC.
- BASIC scout vẫn đóng1/2 với1 lượt dự phòng hết hiệu lực. Phiên R mới1/1 đóng;
  cộng dồn42 lượt dữ liệu đã đóng, còn0. Đây là số kế toán các case, không phải
  42 trận đồng nhất hoặc thước đo chất lượng AI.

[Intent](artifacts/highsion_reasoning_validation_20261122/intent.json),
[native closure](artifacts/highsion_reasoning_validation_20261122/reasoning/closure.json),
[case closure](artifacts/highsion_reasoning_validation_20261122/closure.json).

## Những gì đã xác minh trong trận

9 quyết định đều khớp snapshot trước hành động, lựa chọn thực thi và replay9/9.
26 receipt hợp lệ: SWAP có ROOT/FRESH/FINAL, PASS có ROOT/FINAL. 54 sự kiện
diagnostic ghi đủ, không drop/fault, worker1/1 được thu hồi, writer đóng sạch.

8 SWAP gửi,7 ACK; SWAP cuối kết thúc bằng `ACTION_ABORTED_STATE_CHANGED` khi
game chuyển sang thắng, không suy thành ACK, không phải một safe stop.
1 PASS ở turn11 được game xác nhận qua `MATCH_AFK_WARN`: idle1/ngưỡng3,
không input trong thời gian chờ, thirdPass0. Không thêm giới hạn bỏ lượt cứng.

HP thấp nhất trong9 snapshot trước quyết định là45.357/109.491≈41,42%; terminal
55.362. Trận này cũng chưa có tình huống sinh tồn dưới30%. Không dùng nó để
đổi kết luận của scout hoặc tiếp tục săn áp lực trên cùng boss.

## So BASIC và Suy luận trên đúng cùng bàn

5/9 quyết định khác BASIC. Phân loại thận trọng:4 thiếu dữ liệu để so toàn cục,
1 tradeoff; không gán nhãn thắng chỉ vì ăn nhiều viên hoặc kết trận sớm.

| Turn game | BASIC dự kiến | Suy luận dự kiến trên cùng trạng thái | Giới hạn |
|---|---|---|---|
| 3 | 3 Hút | Quét có2 Kiếm,2 Mana,1 Nộ,8 Khiên,3 Máu,8 Hút | Mới so first-wave của nội tại với cascade BASIC; refill3→24 ô chưa biết |
| 5 | 4 Máu | Quét có2 Kiếm,1 Mana,5 Nộ,5 Khiên,8 Máu,3 Hút | Cùng giới hạn khác horizon; không đổi số viên thành net gain/sát thương |
| 11 | 3 Hút | PASS, giữ bàn | Đổi tài nguyên lấy giữ cấu trúc bàn; không biết phản hồi/refill thực tế của phương án BASIC |
| 13 | 3 Hút | 3 Máu +3 Nộ | Mất Hút, mở thêm khả năng boss ăn Mana/Hút, giảm Nộ/Máu boss có thể ăn; là tradeoff |
| 15 | 3 Nộ, chừa tối đa4 Kiếm hiệu dụng trên phần bàn đã biết | Quét có6 Kiếm hiệu dụng và tài nguyên; phần bàn đã biết còn0 Kiếm cho boss | 25 ô refill chưa biết; vẫn có hazard một ô có thể tạo Kiếm, không chứng nhận an toàn/kết liễu |

Các số trên là cơ học mô phỏng từ pre-input, không phải kết quả thực tế của
nhánh chưa chơi. Maxima từng tài nguyên phản hồi boss là các nước riêng, không
cộng chúng thành một nước. Ví dụ turn15 chứng minh adviser có cân nhắc Kiếm
cho boss trong lựa chọn hiện tại; chưa chứng minh một nâng cấp chiến thuật mới.

[So cùng bàn](artifacts/highsion_reasoning_validation_20261122/reasoning/same_state_comparisons.json).

## Lỗi UI tìm được và sửa sau khi đóng native

UI có53 snapshot `UI_REASONING_CONTEXT_UNAVAILABLE` xen với20 `COMPLETED`.
Không có lỗi controller hoặc bridge trong trận. Code producer xác minh được:
provider trả `ProviderPoll(None,False,…)` khi presentation busy/batch pending;
controller vẫn gọi observer; bridge lưu tuple có `state=None`. Helper UI truy cập
`state.battle` rồi rơi vào nhánh DEGRADED. Đây là trạng thái thiếu dữ liệu tạm,
không chứng minh thay tài khoản/đồ. Không có packet trực tiếp nối mỗi snapshot UI
với một provider poll, nên không khẳng định toàn bộ53 snapshot cùng nguyên nhân.

Sửa tối thiểu sau khi đóng toàn bộ bằng chứng source1d83:

- `state=None` → WAITING/`UI_REASONING_WAITING_STATE`, hiển thị
  **“Chờ game cập nhật bàn ổn định”**; có state hợp lệ thì phục hồi.
- Profile hết hạn và config đổi vẫn ưu tiên trước nhánh chờ. Object hỏng nhưng
  khác None vẫn DEGRADED. Không đổi validator, bridge admission hoặc rule PASS.
- Cờ display selection không bật khi chờ. Display không gọi disable/fault/stop.
- Regression đi qua observer thật với None rồi state hợp lệ, kiểm bridge không
  fault/stop, không tạo worker chỉ vì cập nhật nhãn.

Source sau sửa `0a86db74…`/508: chỉ2 file UI +1 test thay đổi,505 Python còn lại
nguyên. Source mới có48 test liên quan PASS;14/14 gate synthetic PASS,300 receipt
không mất, worker/writer thu hồi, triple p50=0,6793ms/p95=1,4498ms/max=1,823ms.
Đây không phải native acceptance của source0a86; không rebind timing/profile1d83
sang source mới hoặc chạy thêm trận chỉ để đuổi fingerprint.

Lượt chạy test harness đầu thiếu main guard cho multiprocessing Windows nên4
test worker thất bại; giữ log thất bại, sửa harness rồi48/48 đạt. Lệnh unittest
thử đầu cũng chưa đặt PYTHONPATH/tên module đúng; không dùng để kết luận lỗi
runtime. Các lỗi fixture AST/F1 cũ đã ghi ở báo cáo offline trước không được sửa
hay gọi là đã pass; đây là nhóm kiểm liên quan, không tuyên bố full suite sạch.

[UI review](artifacts/highsion_reasoning_validation_20261122/ui_review.json),
[test retry](artifacts/highsion_reasoning_validation_20261122/ui_followup_checks_retry.json),
[qualification](artifacts/highsion_reasoning_validation_20261122/ui_followup_qualification/qualification.json).

## Dữ liệu và việc còn thiếu

14 typed response normalize đủ14,101 operations (84 STAT_CHANGE/17 BOSS_HP).
2 crit=true có witness,99 ABSENT giữ nguyên; không suy ABSENT thành false.
Payload max9.049/32.768 byte. 5/7 ACK có typed response;2 khoảng turn7/13 không
scoped observation, không chứng minh callback absent và không lấp effect giả.
7 boss interval có đủ biên được giữ riêng. Không fit/pool hệ số Highsion với Priest,
không gọi DAMAGE component là toàn bộ sát thương hành động.

Ba việc offline user yêu cầu đã có: phân biệt lý do UI, API đánh giá bất định
damage giữ unknown, replay so cùng bàn. Predictor vẫn chưa đủ bằng chứng để đưa
vào gameplay; một kết quả thắng không thay điều đó. Không cần thêm Highsion để
chốt bài này. Khi kiểm sinh tồn tiếp, cần tình huống áp lực thật và tiêu chí thu
trước trận; Mega/Galaxy vẫn là các cohort riêng theo thứ tự user đã chốt.

[Capture coverage](artifacts/highsion_reasoning_validation_20261122/capture_coverage.json),
[ba bước offline](ADVISER_UNCERTAINTY_OFFLINE_20261122.md).
