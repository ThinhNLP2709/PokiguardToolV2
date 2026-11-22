# Độ phủ bằng chứng Demon và kế hoạch thu phần còn thiếu — 20/11/2026

Đã rà offline cặp BASIC/Suy luận mới nhất và các log B17 cũ cùng nhóm danh
nghĩa. Có **67 nước của ta nối được nguồn nước đi, phản hồi và hai trạng
thái tài nguyên**, thuộc14 trận;29 nước kích hoạt quét Demon theo geometry
đang dùng. Log cũ đã có ví dụ2/3/4 Kiếm hiệu dụng ở cả hai nhóm nộ trước
nước đi. **Không cần mở thêm trận chỉ để lấy ví dụ đầu tiên cho các ô này.**

Đây là kiểm độ phủ, chưa phải mô hình damage hoặc chứng nhận Suy luận tốt
hơn. Không thay gameplay, train, build, attach hoặc gửi input. Source476
file Python trong `src/tools/tests` giữ nguyên `f595bdb51359394b31a812699b6dc7864893780cc501dfa78373b9dfc7e969ac`.
Tổng lượt thử trước vẫn21, mọi cap đã đóng, còn0; không mở cap mới.

## Phạm vi và cách nối dữ liệu

- Cặp mới nhất: source native `7a6503d4…`, B17, Solo Priest cấp131 (1845),
  Demon Aegis thường (560), ăn Khiên, không tiến hóa. Giữ raw log và closure
  gốc; source hiện tại chỉ được dùng để phân tích offline.
- Log cũ: lọc cùng game build, account alias, pet/boss, cấu hình và thông số
  danh nghĩa max HP/Mana/Nộ/Attack của hai bên; chỉ nhận phase đã đóng, có
  SHA raw log, SWAP ACK, typed effect và trạng thái nguồn khớp chính xác.
  Có13 phase đáp ứng bộ lọc,12 trận có nước LOCAL dùng được. Khớp thông số
  không chứng minh toàn bộ trang bị/buff/crit tương đương; giữ cột lịch sử
  riêng, không gộp thành một tập fit damage đồng nhất.
- Geometry chỉ dùng bàn trước nước đi và solver hiện tại; phân biệt số viên
  vật lý và hiệu dụng có x2. Không đưa refill thực tế vào dự đoán. Geometry
  đợt quét đầu không tự giải thích toàn bộ DAMAGE của cả hành động.
- Chỉ ghép bằng nguồn/action/sequence/result/session đã xác minh. Không ghép
  theo thời gian gần nhất, không điền ba effect thiếu của cặp mới.

## Số liệu thực có

| Nhóm | LOCAL có nguồn và hai endpoint | Quét Demon | Trận có LOCAL |
|---|---:|---:|---:|
| Cặp mới nhất | 7 | 6 | 2 |
| Lịch sử cùng nhóm danh nghĩa | 60 | 23 | 12 |
| Tổng kiểm kê, chưa gộp fit | 67 | 29 | 14 |

**18 khoảng tài nguyên của cặp mới =7 LOCAL +11 BOSS**, không phải18 mẫu
đòn đánh Demon. Trong7 LOCAL có6 quét và1 nước tài nguyên. Trong29 quét
toàn bộ có1 nước0 Kiếm hiệu dụng không ghi được DAMAGE; không gọi đó là
chứng minh cả hành động gây0 damage. Có thêm5 nước ăn Kiếm thường không
kích hoạt quét, cần giữ thành cơ chế riêng.

Bảng dưới đếm quét theo **Kiếm hiệu dụng trên geometry đợt đầu** và nộ trước
nước đi. Ngưỡng100 chỉ là nhóm để kiểm kê, không xác nhận ngưỡng damage.

| Kiếm hiệu dụng | Nộ trước | Cặp mới: mẫu / trận | Lịch sử: mẫu / trận |
|---|---|---:|---:|
| 2 | <100 | 1 / 1 | 2 / 2 |
| 2 | ≥100 | 0 / 0 | 1 / 1 |
| 3 | <100 | 0 / 0 | 3 / 2 |
| 3 | ≥100 | 0 / 0 | 1 / 1 |
| 4 | <100 | 2 / 2 | 4 / 4 |
| 4 | ≥100 | 1 / 1 | 6 / 4 |
| ≥5 | <100 | 1 / 1 | 1 / 1 |
| ≥5 | ≥100 | 1 / 1 | 4 / 3 |

Không cộng cột số trận giữa các ô: một trận có thể xuất hiện ở nhiều ô.
Ba viên vật lý có x2 có thể là4 hiệu dụng; không dùng nó làm mẫu3 hiệu dụng.

## Phần còn thiếu và giới hạn suy diễn

1. **Ý nghĩa/presence của `fullPower` và thứ tự thay đổi nộ.** Trong các
   DAMAGE component được giữ của67 nước:36 cờ `true`,3 giá trị `None`, chưa
   có `false` tường minh. Riêng quét là27 `true`,1 `None`. `None` không phải
   `false`; projector cũ dùng `.get()` còn gộp thiếu field với null. Cần kiểm
   raw/reverse/đường projection trước khi yêu cầu người dùng cố thu mẫu
   `false`. Chưa biết server có bỏ field khi false hay không.
2. **Ngữ cảnh damage.** Cùng4 Kiếm hiệu dụng ở cặp mới ghi152796 hoặc229194
   tổng DAMAGE; nộ, số viên vật lý/x2 và thứ tự effect khác nhau. Chưa đủ để
   suy ra công thức, quy lỗi hay nhận định chỉ nộ tạo chênh lệch. `destroyedByTag`
   chưa được xác minh là số vật lý hay hiệu dụng. Toàn bộ gear/buff/crit/
   khắc hệ và mức đầy đủ effect cả hành động còn UNKNOWN.
3. **Trạng thái đặc biệt.** Trên67 LOCAL chưa có mẫu bắt đầu đầy HP, đầy Mana
   hoặc boss nộ0. Riêng29 quét chỉ1 mẫu HP ta<30%,1 mẫu boss HP≤25%,5 mẫu
   boss có Khiên. Đây là độ phủ mô tả, không thêm ngưỡng bảo vệ hoặc rule
   kết liễu. Các mốc cap/floor cần giữ raw delta, thứ tự operation và endpoint.
4. **Biên đầu/cuối trận.** Cặp mới có1 ACK typed ở nước mở đầu chưa có cặp
   published-resource endpoint, và2 nước cuối không có ordinary ACK. Có thể
   rà nguồn adviser/action/checkpoint chính xác thành một tầng bằng chứng
   riêng; chưa mở rộng hợp đồng endpoint trong kiểm kê này. HP boss về0 là
   quan sát bị chặn ở0, không phải damage tiềm năng chính xác.
5. **Khả năng dự đoán ngoài dữ liệu đã xem.** Cả14 trận đã được kiểm, không
   phải holdout độc lập. Source `f595…` có thêm metadata response identity
   nhưng chưa có native proof mới; proof/profile `7a…` giữ nguyên, không
   rebind. Không lấy số lượt, WIN, override hoặc điểm utility nội bộ làm nhãn
   chất lượng. So BASIC/Suy luận phải cùng trạng thái trước nước đi; nhánh
   chưa được chơi vẫn thiếu outcome thực.

## Làm tiếp theo thứ tự nào

**Trước mắt làm offline:** kiểm presence/order `fullPower` trên raw và reverse;
sau đó rà nguồn biên mở đầu bằng exact binding. Chốt điều đã xác minh hoặc
UNKNOWN, cùng field cụ thể cần bổ sung; không thay rule để cố lấp bảng.

**Khi mở một mốc live riêng sau này:** giữ rõ game/source/account/pet/boss/
loadout, kiểm logger source mới bằng tối đa1 BASIC rồi1 Suy luận nếu mốc đó
được yêu cầu. Không bảo đảm sẽ xuất hiện UNAVAILABLE và không tự chạy bù.
Sau kiểm offline mới chọn các tình huống tự nhiên còn thiếu: cap tài nguyên,
HP thấp, nguồn nộ boss cạn, boss có Khiên/gần chết. Không ép nước nguy hiểm,
không sửa PASS, không kéo dài trận chỉ để lấy số liệu. Chưa cần thu mọi tổ
hợp hoặc chuyển Mega/Galaxy để hoàn thành nghiên cứu Khiên này.

**Trước khi fit thử:** công bố phạm vi context hỗ trợ và tiêu chí sai số,
giữ trận độc lập chưa xem để kiểm. Với context thiếu hoặc ngoài phạm vi phải
trả UNKNOWN. Mẫu lịch sử dùng kiểm giả thuyết/độ phủ; không mặc định coi là
cùng loadout hiện tại. Hiện chưa train hoặc nạp model nào vào adviser.

## Bằng chứng tái hiện

- [Cặp mới và các nguồn từng nước](artifacts/demon_coverage_20261120/coverage.json)
- [Độ phủ lịch sử và điều kiện lọc](artifacts/demon_coverage_20261120/historical_coverage.json)
- [Bảng độ phủ và ưu tiên thu tiếp](artifacts/demon_coverage_20261120/collection_plan.json)
- Script tái hiện: `audit.py`, `audit_history.py`, `plan.py` cùng thư mục.
- [Kiểm SHA, source và trạng thái cuối](artifacts/demon_coverage_20261120/final_verification.json)

Các assertion của audit kiểm endpoint/source/ACK/pins và chống đếm trùng;
không chạy lại bộ unit test runtime vì không đổi file source hoặc test.
UI/game không được kiểm lại trong mốc chỉ đọc file này.
