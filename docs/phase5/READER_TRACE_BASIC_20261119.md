# Root trace Demon — BASIC đã đóng, Suy luận sẵn sàng

**BASIC hoàn tất1/1, WIN sau13 lượt ta/12 lượt boss**, nhận thưởng và về
đúng phòng. Không safe stop, technical recovery, lỗi input hoặc PASS.
Match `M_9f8b3109`, run `a2514b451dcf465196aad82464f68163`.
Source giữ nguyên:
`1909d77a6a66964d1e9867c5f26be81a30852f48c3aa4e4880db4cd222740303`.

Solo Priest lv131/ID1845, Demon Aegis thường ID560, Khiên/ngưỡng4, không
tiến hóa; room `Coop_300394`. Ordinary preferences giữ nguyên. Đã dùng
computer use kiểm tool dừng1/1, đóng BASIC và mở UI R mới; chưa start R.

## Dữ liệu dùng được và phần chưa đủ

13 SWAP gửi:12 ACK và1 nước terminal boss HP0, kết quả WIN nhất quán.
**12 mẫu timing native hợp lệ** tạo profile R riêng đúng source/build/host,
không rebind timing cũ. Hiệu ứng optional thiếu không làm giả ACK/timing.

Giữ22 typed response, tất cả CAPTURED, chuẩn hóa22/22, có22 reader binding
đúng trace ID. Không diagnostic fault, không lỗi projection. Nối đủ11 boss
board interval hợp lệ. Đây là operational proof có phạm vi, không phải
chứng nhận toàn bộ response hoặc mọi mode/input family.

Hai nước ACK thiếu typed response:

| Lượt | Sequence trước → sau | Gửi / ACK (UTC) |
|---|---|---|
| 3 | 6 → 8 | 13:53:31.240 / 13:53:32.267 |
| 11 | 22 → 24 | 13:54:35.972 / 13:54:36.362 |

Reader đã có90143 completed read, gồm89224 empty,909 nonempty và10 lỗi.
Không thấy shared-DTO case trong các mẫu thành công; không có alias event
bị drop. Tuy nhiên **128 event lịch sử giữ lại,491 event cũ bị đẩy khỏi
ring**. Phần lịch sử còn khoảng13:55:40–13:56:24 UTC, muộn hơn cả hai ACK
thiếu effect. Mốc UTC ở đây là xấp xỉ từ một UTC/monotonic anchor.

Do đó chưa xác định được lỗi root/timing tại hai khoảng này; không lấy10
root failures làm nguyên nhân khi chưa đối chiếu được thời điểm. Gap lớn
nhất156ms và lần đọc lâu nhất47ms đều khoảng13:53:28.488 UTC, trước cửa
sổ gửi/ACK đầu tiên nêu trên; không tự quy chúng cho hai response thiếu.

Giới hạn ring đã được ghi rõ qua dropped counter, không phải log bị mất
âm thầm hoặc tool bỏ lượt. Toàn bộ capture binding giữ được vẫn hợp lệ,
nhưng không tuyên bố lịch sử reader đầy đủ. Không sửa source hoặc tăng
buffer giữa hai pha để giữ nguyên timing/profile của phiên đã chuẩn bị.

## Pha R còn lại

Đã chuẩn bị và mở **tối đa1 trận Suy luận**. Sau thời gian chờ, game đã về
sảnh ngoài phòng. Dùng computer use qua Chinh Phục chọn lại Priest lv131;
read-only xác minh đúng boss ID1845, Demon Aegis ID560 và account alias.
Phòng859489 mất boss properties trong khi UI vẫn hiển thị phòng; nguyên nhân
UNKNOWN. Đã vào lại lần nữa, phòng hiện tại `Coop_652784`, khác phòng BASIC
`Coop_300394`; không thay hồ sơ
gốc hoặc reset cap. Full gear vẫn UNKNOWN, không tuyên bố tương đương toàn
bộ đồ. [Lần kiểm lại phòng](artifacts/demon_reader_trace_native_20261119/reasoning/room_recheck_final.json).

UI PID18516 đã thấy READY, target1/attempt1; chưa bấm Bắt đầu.
Profile riêng dùng12 timing mới, authority SWAP; luật PASS hiện có tiếp
tục do game quyết định. Dữ liệu/ordinary prefs được cách ly như pha BASIC.

Case mới đã dùng1/2, tổng ledger18; chỉ còn1 lượt R trong cap này. Không
reset BASIC, không tự chạy thêm để bù coverage. Sau R sẽ chốt cả phiên và
rà cách lưu lịch sử quan trọng mà không bị event khác đẩy mất, dựa trên
dữ liệu thực. Giữ nguyên source cho đến khi pha R đóng; không train/build.

[BASIC closure](artifacts/demon_reader_trace_native_20261119/live/closure.json) ·
[Coverage và giới hạn reader](artifacts/demon_reader_trace_native_20261119/basic_diagnostics_review.json) ·
[Pha R đã chuẩn bị](artifacts/demon_reader_trace_native_20261119/reasoning/prepared.json).
