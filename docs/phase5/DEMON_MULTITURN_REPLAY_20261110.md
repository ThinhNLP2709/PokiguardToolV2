# Replay Demon Farm nhiều lượt — 10/11/2026

Rà log Cơ bản của 850 trận Lieyun và ba trận Highsion, Argilpus, Erdegon. Các phiên đều ăn Khiên, dùng ngưỡng 3 hoặc 4 Kiếm hiệu dụng theo cấu hình đã ghi. Giữ nguyên toàn bộ phiên Lieyun 500 trận làm tập đối chiếu riêng. Có 501 trận ghi từ hai lượt ta và ít nhất một lượt boss.

## Kết quả từ log thật

- 1.221 nước đổi ô ghép được quyết định, input và `SWAP_ACKNOWLEDGED` theo trận, phiên, lượt, `srvSeq`, hash bàn cờ và tọa độ. Trong đó 1.214 nước ghép được lượt boss và bàn thật tiếp theo của ta. Có thể dùng bàn cuối trận làm bàn quan sát dù nước trên bàn đó kết thúc combat trước ACK thông thường. Các nước thiếu ACK vẫn nằm ngoài tập nước gốc dùng để đánh giá planner.
- Trong 394 ca BASIC dự báo setup đủ ngưỡng Kiếm sau nước của ta, **145 ca xuống dưới ngưỡng ở lượt ta tiếp theo** và **249 ca còn đạt ngưỡng**. Có 16 trận bị mất cơ hội ít nhất hai lần. Trong 50 ca mất cơ hội, chỉ số Khiên của boss tăng và ledger đã biết của nước ta không ghi ăn Khiên.
- `last_move` tại `LOCAL_TURN_RETURNED` vẫn trùng nước của ta ở cả 1.214 cặp. Dữ liệu xác nhận cơ hội biến mất và thay đổi tài nguyên, nhưng tọa độ chính xác của nước boss và phần refill/cascade gây thay đổi vẫn chưa xác định.
- Lieyun, attempt 206 là một ca lặp rõ. Lượt 1 và 7 đều dự báo 4 Kiếm hiệu dụng. Bàn thật lượt 3 và 9 lần lượt đều không có nước quét đạt sàn hai ô Kiếm thật. Chỉ số Khiên boss tăng từ 0 lên 569 trong cả hai cặp. Trận này có 10 lượt của ta. [Log](../../logs/farm_runs/bb036c7905fd48c590fb76d28dac2d22/matches/attempt_206/combat.jsonl:20)

Các số liệu trên đo ngưỡng cấu hình trên bàn thật sau lượt boss. Chúng không dùng thắng/thua để gán nhãn nước đi, và một cơ hội xuống dưới ngưỡng vẫn có thể đáng đánh khi xét Nộ hoặc sát thương thực.

## Đối chiếu hai cách xét phản hồi

Trên cùng 394 nước đã gửi, tính lại cơ hội từ phần bàn còn biết được sau nước của ta. So sánh tập phản hồi có nhiều Kiếm nhất với phép thử thêm các phản hồi ít Kiếm hơn có thể lấy Khiên. Cả hai giữ refill ở `UNKNOWN`.

| Tập trận | Thực tế mất setup, phát hiện thêm phản hồi lấy Khiên có thể phá setup | Thực tế giữ setup, nhưng cũng phát hiện phản hồi như vậy |
|---|---:|---:|
| Phát triển | 5 | 9 |
| Đối chiếu riêng | 2 | 9 |
| Tổng | 7 | 18 |

Cách xét rộng hơn tìm được tình huống dễ mất setup nhưng sẽ hạ điểm cả 18 ca thực tế vẫn giữ được setup. Vì vậy chưa đổi trọng số hoặc chuyển sang giả định boss luôn chọn nước phá Khiên. Thông tin này phù hợp để đo mức độ dễ bị phá của từng nước, và cần ghép nước boss có nguồn xác nhận trước khi dùng như dự báo hành vi.

## Baseline của adviser hiện tại

Chạy trên 100 bàn được lấy mẫu theo nhóm, thuộc 87 trận. 48 bàn thuộc phiên đối chiếu riêng. 100 lựa chọn hợp lệ theo solver. Adviser đề xuất khác BASIC ở 94 bàn và hoàn thành nhìn trước ở 95 bàn. Thời gian một lượt chạy offline trên máy này khoảng **112 ms p50, 183 ms p95, 265 ms max**, chưa gồm worker, bước kiểm host và input. Những lựa chọn khác BASIC chỉ được so sánh bằng mô hình trên cùng bàn. Log không có kết quả của những nước chưa đi.

Tập này có bốn lượt boss còn dưới 35% Máu, đều từ một trận Argilpus. Duyệt cả 112 cặp trên bốn bàn đó không tìm được nước Kiếm thường xác định được, không cần kích nội tại. Vì vậy đợt này chưa đủ dữ liệu kiểm đúng tình huống boss thấp máu, Nộ cao và có nước Kiếm trực tiếp mạnh. Cũng chưa có dữ liệu damage theo từng nguồn để hiệu chuẩn một khoảng sát thương đáng tin.

## Tái chạy

```powershell
$env:PYTHONPATH = 'src'
python docs/phase5/artifacts/demon_multiturn_20261110/replay.py --extract --label baseline
```

[Thống kê theo phiên](artifacts/demon_multiturn_20261110/audit.json), [đối chiếu phản hồi](artifacts/demon_multiturn_20261110/reply_sensitivity.json), [100 bàn có nguồn và SHA‑256](artifacts/demon_multiturn_20261110/sample.json), [kết quả adviser](artifacts/demon_multiturn_20261110/baseline.json). Phần phân tích chỉ đọc log đã lưu và chạy planner offline. Giữ nguyên thuật toán runtime, cấu hình và bản đóng gói.
