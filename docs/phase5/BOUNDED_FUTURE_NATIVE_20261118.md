# Adviser giữ phần nhìn trước — live B16

**18/11/2026: CLOSED PASS — kiểm kỹ thuật source trong cohort này.** User
yêu cầu tự mở tool và tự live test khi đi làm. Phiên giới hạn 3 BASIC +
3 REASONING, tối đa 6 lượt thử, đã hoàn tất đúng giới hạn.

Solo Lion Star lv105, Demon Aegis thường ăn Khiên, không tiến hóa, ngưỡng
4 Kiếm hiệu dụng. Đồ và cấu hình chơi giữ nguyên giữa hai nhánh. Source
đóng băng từ đầu đến cuối:
`9b4a21096f4efccc630039b790508f5f0a296bbd4cc0e4d9661b94fa7c36cb27`.

## Kết quả thực tế

| Đo | BASIC | REASONING |
|---|---:|---:|
| Lượt thử / hoàn tất / thắng | 3 / 3 / 3 | 3 / 3 / 3 |
| Lượt của mình mỗi trận | 8, 8, 3 | 1, 13, 7 |
| Tổng lượt của mình | 19 | 21 |
| SWAP gửi / ACK khi chưa kết trận | 19 / 16 | 21 / 18 |
| SWAP cuối chuyển trạng thái kết trận | 3 | 3 |
| Technical abort / recovery / safe stop | 0 / 0 / 0 | 0 / 0 / 0 |
| Bỏ lượt | 0 | 0 |
| Nhận thưởng / về đúng phòng | 3 / 3 | 3 / 3 |

Các trận có bàn random khác nhau. 3 trận mỗi nhóm chưa đủ đánh giá tăng tỷ
lệ thắng hoặc hiệu quả farm; 19 so với 21 lượt không chứng minh tốt/xấu hơn.
Chỉ số lượt của UI là proxy, không đồng nhất với năng lượng tài khoản.
Không fit damage hoặc sửa weights theo kết quả những trận này.

## Suy luận và nhánh vừa sửa đã thực sự chạy

- 21 snapshot nguyên vẹn, 21 quyết định; 21 ROOT + 21 FRESH + 21 FINAL
  đều `VALID_COMPLETED_COMMON`. Không có source join lỗi. Input thực tế
  khớp đề xuất hoặc quyết định giữ BASIC ở cả 21 lượt.
- 15 đề xuất đổi nước được gửi; 12 có ACK game. Ba đề xuất còn lại là nước
  cuối trận, có `ACTION_ABORTED_STATE_CHANGED`, terminal HP boss=0, kết quả
  WIN STRONG và nhận thưởng bình thường. Chúng là terminal exclusions,
  không được cộng thành 3 ACK hoặc khẳng định riêng từng nước gây kill.
- 6 quyết định giữ BASIC. Cả 21 so sánh hoàn tất nhìn trước.
- Nhánh bounded-unknown xuất hiện thật ở `M_de13d38e` lượt server 19 và
  `M_4a7aa56b` lượt server 1: mỗi ca có một root thiếu model, giữ H=[0;0,5]
  UNSUPPORTED cùng các nhánh đã hoàn tất. Không cấp điểm chắc chắn cho refill.
- Replay đúng 21 đầu vào native với planner trước sửa: 19 lookahead +
  2 one-step; planner mới 21 lookahead. Lựa chọn không đổi ở cả 21 ca và
  tái hiện đúng toàn bộ input đã gửi. Đây là chứng cứ coverage/transport,
  chưa phải bằng chứng chất lượng nước đi hoặc win tăng.

129/129 record đã ghi, flush và đóng; không dropped/failed/discarded. 21 job
hoàn tất, không fault/late/stale, 3 worker đều reap; cả 3 bridge healthy.

## Hiệu chuẩn, lỗi đọc và trạng thái UI

16 SWAP BASIC có ACK được đo mới trên đúng source, game và máy này.
Profile dùng controller tail max180,6802ms, final input max2773,6704ms và
selector extra max1,5653ms. Đây là các cực đại mẫu, không phải population
bound hoặc native_U. Fresh-current-source qualifier đã tính và qua14/14
gate; runner/fixture review giữ trong artifact. Không gán lại timing cũ.

Trong BASIC trận `M_13d40762` có **1 provider read error** lúc
04:24:53.605 UTC: `acked sequence HashSet changed during read`. Mẫu bị loại
vì collection thay đổi khi đọc; nước kế tiếp được gửi lúc04:24:57.501 UTC.
Trận thắng với0 PASS/0 technical abort/0 recovery. Không nới kiểm pointer,
sequence hoặc dùng dữ liệu đọc không nhất quán. REASONING có0 read error.

UI observer có lúc phát `UI_REASONING_COHORT_CHANGED` giữa các snapshot.
Đây là thông báo từ bộ xuất trạng thái, không phải bằng chứng đổi pet/đồ
hoặc farm đã dừng. Trong phiên này, cả21 hành động đều có3 receipt hợp lệ
và không thiếu quyết định adviser. `authority.matches` còn kiểm timer source;
chưa quy nhãn UI này thành lỗi gameplay hoặc tự bỏ kiểm admission. Đã giữ
counter và mẫu UI trong receipt để tránh đánh đồng trạng thái hiển thị với
quyền input thực tế.

14 gate fresh-current-source khác với bộ test lịch sử:3 lỗi projection
đã ghi trong [báo cáo offline](ADVISER_BOUNDED_FUTURE_20261118.md) vẫn là
giới hạn của ancestry cũ. Không thay pin/expectation hoặc báo toàn bộ CI xanh.

## Điểm dừng và phạm vi

Game được kiểm bằng read-only provider và computer use: ở lobby Lion Star
lv105, room `Coop_601898`. Tool vẫn mở ở trạng thái hoàn tất3/3, không active
controller/worker. Cấu hình chính của user và source hash giữ nguyên.

Profile chỉ ở data root riêng của phiên, không cài vào dữ liệu mặc định.
Receipt chuẩn bị vẫn giữ `installed:false` / `live_acceptance:false`; receipt
live riêng ở dưới ghi technical smoke đã qua cho source/cohort này. Không
đổi metadata gốc để biến thành nghiệm thu mọi pet/style/máy/ZIP.
Chưa build, bump version hoặc chạy thêm trận sau cap6.

- [Closure và manifest](artifacts/b16_bounded_future_live_20261118_112329/live_closure.json)
- [BASIC export](artifacts/b16_bounded_future_live_20261118_112329/basic_export.json)
- [Join đề xuất → input → ACK/terminal](artifacts/b16_bounded_future_live_20261118_112329/reasoning3/native_join_review.json)
- [Đối chiếu trước/sau trên21 đầu vào native](artifacts/b16_bounded_future_live_20261118_112329/reasoning3/paired_native21.json)
- [Qualifier review](artifacts/b16_bounded_future_live_20261118_112329/qualification_review.json)

Đã thu thêm21 snapshot và17 quan sát damage từ hai nhánh; normalizer hiện
nhận2 BASIC +6 REASONING là usable theo các điều kiện quan sát. Chưa coi8
mẫu đó là đủ hoặc độc lập để dựng công thức damage/skill. Có thể tiếp tục
phân tích offline, không tự mở lại6 lượt thử đã đóng.
