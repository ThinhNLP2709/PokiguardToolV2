# Giữ riêng lịch sử root và lỗi đọc — 20/11/2026

Đã sửa phần metadata của reader và kiểm offline. Thay đổi nằm ở
`dispatcher_read_trace.py` cùng test;473 file source khác giữ nguyên byte,
gồm reader protocol, tap, BASIC, adviser, PASS và input. Không thêm RPM,
scan, offsets, thay nhịp polling hoặc ghi đĩa trong reader.

Source trước có native proof:
`1909d77a6a66964d1e9867c5f26be81a30852f48c3aa4e4880db4cd222740303`.
Source mới, **chưa kiểm native**:
`7a6503d4c93cc7f0e5d552cd03604d445253ea06e58636d056b0df9dcb6bb13a`.

## Cách giữ bằng chứng

Native BASIC/R vừa đóng đã đẩy491/90 event khỏi ring128. Các mốc empty,
timing và membership cùng dùng ring này. Ba trong bốn khoảng ACK thiếu
typed effect đã nằm ngoài phần lịch sử còn giữ; khoảng còn lại chưa đủ
identity response để xác định nguyên nhân. Đây là giới hạn log đã quan
sát, không chứng minh callback thiếu do lỗi reader nào cụ thể.

Giữ nguyên ring128, cách nén và các field cũ. Bổ sung hai nhóm độc lập:

| Nhóm metadata | Giới hạn | Khi vượt giới hạn |
|---|---:|---|
| `protected_root_events` | 256 | Giữ128 root membership đầu +128 gần nhất |
| `protected_error_events` | 32 | Giữ16 lỗi đầu +16 gần nhất |

EMPTY và timing event vẫn nằm trong ring cũ, không dùng chỗ của hai nhóm
mới. Mỗi lỗi đọc được giữ mốc thời gian riêng trong nhóm lỗi, kể cả khi
ring cũ nén nhiều lỗi cùng nhãn thành một event. Bộ đếm `observed` và
`omitted` báo rõ số event đủ điều kiện và số bị bỏ ở mỗi nhóm.

Root event là một completed-read witness khi membership thay đổi, không
phải mọi lần đọc nonempty hoặc lịch sử liên tục của game. Phần giữa vẫn
có thể bị bỏ sau256 root event; các khoảng empty/timing cũ vẫn có thể mất
khỏi ring128. Không dùng việc không tìm thấy event để kết luận response
server vắng mặt. Chính sách không khôi phục response hay event cũ.

Các event giữ token callback/DTO/JSON theo phiên, không thêm raw address,
payload hoặc exception text. Reset theo phiên xóa cả hai nhóm; ticket từ
phiên cũ không được đưa event trở lại. Tuple snapshot được cache, không
dựng lại danh sách trong health polling. Memory/file I/O và quyền input
không được cấp qua metadata này.

## Kiểm offline

**94 test PASS**, gồm8 test mới về flood timing/empty, prefix/suffix không
trùng, đếm phần giữa bị bỏ, lỗi lặp có timestamp riêng, độc lập dung lượng,
snapshot cached/frozen, reset/ticket cũ, giới hạn kích thước và redaction.
Các test reader/tap/capture hiện có vẫn qua, gồm observer-fault isolation.

Đối chiếu9 trace synthetic với module trước sửa: mọi field metadata cũ
khớp, gồm counters, ring/alias events, timestamps và tokens. Fixture reader
trả cùng root và cùng19 RPM query. Không đổi473 file source còn lại.

Replay chính sách trên hai native tail còn giữ: giữ46/45 root witness và
1/3 error witness, không bỏ record nào trong tập tail đó. Đây chỉ là
replay phần đã được ghi;491/90 event trước đó và4 typed effect thiếu
không được khôi phục. Không tuyên bố đã tái hiện full native sampling.

Fixture giới hạn chứa8 root/event, overflow root và error cùng lúc:
serialized JSON compact618453 byte, dưới1MiB. Benchmark fake-memory,
6000 mẫu mỗi bên, thứ tự trước/sau được luân phiên:

| CPU một lần đọc, fake memory | Trước | Sau |
|---|---:|---:|
| p50 | 41,4µs | 41,5µs |
| p95 | 56,8µs | 56,1µs |

Đây là số đo mô tả trên fixture stable root, chưa chứng nhận timing
native, chi phí mọi pattern, hoặc thời gian gửi input trong game.

## Trạng thái và điểm dừng

Cap native trước vẫn đóng2/2, tổng19; đợt này0 attach/input/trận mới,
không train hoặc build. Ordinary preferences không đổi. Native proof và
profile cũ tiếp tục pin source1909; không rebind sang source7a6503.

Mốc tiếp theo là kiểm trực tiếp metadata mới trên Demon bằng control và
timing mới đúng source. Chưa chuẩn bị hoặc mở cap khác. Tool của phiên
trước vẫn được xem là UI lịch sử source1909, không là bản kiểm native của
source trên đĩa hiện tại. Mega/Galaxy tiếp tục hoãn.

[Bản kiểm source, replay và CPU](artifacts/reader_trace_retention_20261120/verification.json) ·
[Native trước sửa và các gap còn UNKNOWN](DEMON_READER_TRACE_NATIVE_20261120.md).
