# Adviser: độ vững của nước chuẩn bị — 17/11/2026

Đã hoàn tất phần nâng adviser offline từ các trận nhiều lượt đã lưu. Thay đổi
chỉ ở `reasoning_common_planner.py`: điểm chuẩn bị lượt sau xét độ nhạy với
các phản hồi hợp lệ khác của boss. Không sửa BASIC, input, skill/QTE, quyền
PASS, bộ đọc, FarmRunner, hồ sơ hiệu chuẩn hoặc version. Chưa build/live mới.

## Bằng chứng và phạm vi

- 100 snapshot Demon từ nghiên cứu [nhiều lượt ngày 10/11](DEMON_MULTITURN_REPLAY_20261110.md):
  52 phát triển và 48 đối chiếu riêng theo phiên. Snapshot được giữ nguyên SHA-256.
- 105 snapshot hồi quy từ [đợt nâng adviser trước](OFFLINE_ADVISER_UPGRADE_20261107.md),
  gồm Đơn giản, Cẩn trọng, Khủng long, Chịu đấm ăn xôi, Demon, Mega và Bú win.
  24 ca Khủng long dùng lại bàn Đơn giản, không phải log Khủng long thực.
- 87 file combat gốc được sample tham chiếu hiện không còn tại đường dẫn cũ.
  Vì vậy đợt này chạy trên snapshot đã lưu, không tái xác minh ACK/raw log và
  không cấp bằng chứng native mới. [Danh tính dữ liệu](artifacts/adviser_multiturn_20261117/sample_identity.json)
  ghi rõ giới hạn đó. Không tái trích corpus hoặc dùng lượt boss tương lai để
  chọn nước tại snapshot hiện tại.
- Lưu [source trước thay đổi](artifacts/adviser_multiturn_20261117/before/reasoning_common_planner.py)
  và [manifest](artifacts/adviser_multiturn_20261117/before_manifest.json) để so sánh.

## Cách chấm đã đổi

Trước đây, khi cấu hình tham chiếu giả định boss ưu tiên nhiều Kiếm, adviser
lấy mức chuẩn bị thấp nhất qua các phản hồi đồng hạng nhiều Kiếm nhất. Điểm
này là một số cố định. Một nước ít Kiếm hơn có thể phá setup nhưng chưa được
phản ánh vào điểm chuẩn bị.

Hiện tại:

1. Giữ phép xét toàn bộ các phản hồi đồng hạng nhiều Kiếm làm tham chiếu.
2. Kiểm thêm các phản hồi hợp lệ khác từ chính phần bàn đã biết.
3. Điểm chuẩn bị `H` là một khoảng: cận dưới bảo thủ sau phép kiểm bổ sung,
   cận trên theo tham chiếu ban đầu. Một phản hồi có thể phá setup làm giảm
   độ chắc chắn, không có nghĩa boss được dự đoán chắc chắn sẽ chọn nó.
4. Nếu hết giới hạn khảo sát phản hồi, cận dưới là 0 thay vì bịa một mức đảm
   bảo. Thiếu kết quả tham chiếu hoặc hết budget tổng vẫn dùng kết quả một
   bước đã hoàn tất như trước. Không thêm một lý do dừng farm.
5. Giữ nguyên hệ số chiết khấu tương lai 0,5 và trọng số hiện hành. Bộ so sánh
   vẫn yêu cầu cận dưới của đề xuất vượt cận trên BASIC đủ margin hiện có.
   Lợi ích Kiếm/tài nguyên/bảo vệ hiện tại tiếp tục dùng scorer cũ.

Kết quả của cùng một bàn sau phản hồi được cache trong một lần quyết định;
cache vẫn kiểm hủy/deadline và không dùng xuyên trận/lượt. Giới hạn 32 phản
hồi mỗi root, 8 root và budget/node tổng hiện có được giữ. Không dự đoán refill,
không học trọng số, không thêm xác suất boss hoặc công thức sát thương.

## Ca hồi quy cụ thể

Ở snapshot phát triển số 39 (tọa độ dưới đây bắt đầu từ 0):

- Bản trước chọn `(0,7) ↔ (1,7)`, ăn 5 Nộ và cho điểm chuẩn bị `H = 0,5`.
- Cả 3 phản hồi nhiều Kiếm giữ được mục tiêu danh nghĩa. Tuy nhiên, một phản
  hồi hợp lệ ít Kiếm hơn `(5,5) ↔ (5,6)` phá mất cơ hội đó trên phần bàn đã biết.
- Bản mới ghi `H = [0; 0,5]` và chọn `(3,2) ↔ (3,3)`, ăn ngay 3 Kiếm.
  Điểm đe dọa Kiếm boss của hai nước bằng nhau; bản mới không tuyên bố đủ damage
  hoặc chắc thắng. Đây là phản ví dụ theo mô phỏng, không phải kết quả trận nếu
  người chơi đã đi nước khác.

## Đối chiếu trước/sau

| Tập snapshot | Số ca | Đổi lựa chọn | Hoàn tất nhìn trước: trước → sau |
|---|---:|---:|---:|
| Demon phát triển | 52 | 1 | 50 → 50 |
| Demon đối chiếu riêng | 48 | 0 | 45 → 45 |
| Hồi quy nhiều lối chơi | 105 | 0 | 92 → 92 |
| Tổng | 205 | 1 | 187 → 187 |

205 lựa chọn đều hợp lệ theo solver. 18 ca còn lại dùng kết quả một bước như
bản trước; trong đó 8 ca Mega của corpus cũ thiếu thông tin hình ấn hiện hành.
Không bổ sung thông tin giả để biến chúng thành ca nhìn trước hoàn tất. Galaxy
không có corpus trận thật trong đợt này; chỉ có kiểm thử liên quan bằng dữ liệu giả.

Một lượt đo offline trước/sau xen kẽ trên máy này: p50 136,82 → 133,44 ms,
p95 594,93 → 495,12 ms, max 906,43 → 937,33 ms. Đây là thời gian planner cục bộ,
chưa gồm worker, kiểm host hoặc input; không dùng nó để cấp hiệu chuẩn timing.
Không kết luận tăng tỷ lệ thắng hoặc giảm số lượt từ những nước chưa từng gửi.

[Kết quả tổng](artifacts/adviser_multiturn_20261117/paired_replay/summary.json) ·
[205 cặp kết quả](artifacts/adviser_multiturn_20261117/paired_replay/paired_results.json).

## Kiểm thử và ranh giới

8 test mới kiểm bàn ghi lại, 5 viên mục tiêu, bàn chuyển vị có gravity giữ
nguyên, phản hồi ít Kiếm, giới hạn khảo sát, không có chính sách boss, bảo toàn
setup vững, cache/hủy và worker thật có parse/validation/dọn tiến trình.

Bộ kiểm tập trung có 102 test: 101 PASS, còn 1 assertion lịch sử tại
`test_reasoning_common_control` so AST calibration với checkpoint cũ.
`calibration_projection()` chỉ đọc `reasoning_calibration.py`; các thay đổi có
sẵn ở `decode_config` ngoài projection lịch sử khiến assertion này không khớp.
Task này không sửa file đó hoặc nới gate. [Phân tích assertion](artifacts/adviser_multiturn_20261117/historical_projection_failure.json)
và [kết quả test từ runner file](artifacts/adviser_multiturn_20261117/focused_file_tests.json).

BASIC/input/reader/skill/QTE/PASS/FarmRunner và version được đối chiếu SHA với
manifest trước thay đổi. Luật bỏ lượt vẫn do dữ liệu game và owner hiện có
quyết định. Source mới không tự kế thừa profile live cũ; không sửa hash hoặc
rebind bằng chứng để ép bật. Công thức damage, phản hồi skill boss, refill và
chất lượng thắng/thua thực tế tiếp tục nằm ngoài kết luận offline này.

Tái chạy so sánh bằng output mới dưới thư mục tạm:

```powershell
python -B docs/phase5/artifacts/adviser_multiturn_20261117/replay_compare.py --out temp/reasoning/adviser-replay-new
```
