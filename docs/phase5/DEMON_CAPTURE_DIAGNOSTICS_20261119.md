# Demon — kiểm khoảng trống dữ liệu hiệu ứng, 19/11/2026

Đã xác nhận khoảng trống nằm **trước bước chuẩn hóa log**. Chưa xác định
được nguyên nhân cụ thể của ba response cũ; không khôi phục hoặc tự suy ra
hiệu ứng còn thiếu. Thay đổi lần này bổ sung dấu vết chẩn đoán cho đường thu
hiện có, không thay đổi quyết định chơi.

## Bằng chứng từ phiên đã đóng

Đối chiếu match `M_78f6ef49`, source
`1bd824c27677c7050112e049aa916d1b4858cb86d6b5904ced903d51fab16ee8`:

| Nước ta gửi | Sequence trước → published sau | Kết quả được giữ | Hiệu ứng typed |
|---|---|---|---|
| Lượt 5 | 10 → 12 | SWAP ACK và published state | Thiếu |
| Lượt 9 | 18 → 20 | SWAP ACK và published state | Thiếu |
| Lượt 15 | 30 → 32 | SWAP ACK và published state | Thiếu |

Cả 14 capture typed có trong combat log đều được chuẩn hóa, cùng đúng
identity; không có bản ghi bị mất hoặc bị loại ở normalizer. Không có
dispatcher board offer, typed projection rejection hay board parser
rejection tương ứng seq12/20/32. Seq20 có thêm runtime heap board fallback;
bàn 64 ô không thay thế được chuỗi hiệu ứng server.

Tám board-shape rejection ở seq8/14/16/18/24/28/34/36 đều **đã giữ được
typed effects** qua đường JSON không kèm bàn. Vì vậy các lỗi shape này
không giải thích ba khoảng trống. Không có bằng chứng quy nguyên nhân cho
operation limit, gameplay failure hoặc nước không được gửi.

Log cũ không giữ chỉ mục đọc JSON/projection/delivery cho từng response.
Không phân biệt chắc được callback chưa quan sát, JSON không đọc được khi
DTO còn sống, hay một khoảng trống projection/export. Nguyên nhân cụ thể
vẫn `UNKNOWN`; ba hiệu ứng lịch sử không thể dựng lại từ dữ liệu hiện có.

[Forensic và SHA đầu vào](artifacts/demon_capture_diagnostics_20261119/forensic.json),
[script tái hiện](artifacts/demon_capture_diagnostics_20261119/forensic.py).
Log nguồn và profile cũ giữ nguyên.

## Thay đổi đã làm

`CaptureTrace` chỉ dùng JSON/DTO và kết quả projection **đã đọc sẵn**.
Mỗi match giữ tối đa 128 mục theo match/event/server sequence:

- Nguồn metadata: immutable JSON có SHA, JSON chưa pin được SHA, hoặc
  DTO-only; DTO không được biến thành typed effects.
- Trạng thái đọc JSON, loại lỗi đã giới hạn, kích thước, board-parsed và
  trạng thái/lý do projection.
- Dấu đã offer cùng board hoặc drain qua queue; conflicting raw identity
  được ghi rõ, DTO về sau không ghi đè immutable identity.

Không giữ raw body, tên actor, địa chỉ pointer hay nội dung exception tùy ý.
Read error không bind được identity chỉ có counter tổng hợp, không gán
sequence đoán. Metadata không chứng nhận effect completeness hoặc quyền input.
Chỉ mục reset theo match, có counter khi đầy và immutable snapshot được
cache; health polling không dựng lại chỉ mục mỗi lần đọc.

Metadata được lập trước khi publish outcome để consumer drain đồng thời
không mất dấu delivery. Lỗi của observer/delivery chỉ tăng counter riêng,
không làm thất bại board/message hợp lệ. Không đổi số lần đọc game, nhịp
sampler, giới hạn capture/queue, parser, ACK, BASIC, adviser, PASS hoặc input.

## Kiểm chứng và phạm vi

Source mới:
`b3ab48cea3da7ae0751912004650608eebabb10e75e292902ba4ed5e2042a546`.
So với source `1bd824c2…`, chỉ tap cũ được thêm hooks metadata; thêm module
metadata và test. AST của mọi method tap cũ bằng bản trước sau khi bỏ hooks;
tuple outcome được drain giữ nguyên. Manifest pin toàn bộ file mã nguồn.

**89 test PASS**: bounded/redacted metadata, identity/reset, DTO-only,
đồng thời publish/drain, lỗi observer, đường boardless, board instance chính
xác, tap/outcome/normalizer/board evidence. Các integration fixture không
phát sinh process read mới. [Kiểm chứng](artifacts/demon_capture_diagnostics_20261119/verification.json),
[test output](artifacts/demon_capture_diagnostics_20261119/tests.txt),
[script kiểm](artifacts/demon_capture_diagnostics_20261119/verify.py).

Đợt này 0 trận mới, không mở tool, không train/build hoặc rebind profile.
Native proof trước vẫn thuộc source `1bd824c2…`; source mới chưa được
kiểm native. Không tuyên bố đã sửa nguyên nhân mất effect lịch sử hoặc
tăng độ thông minh nhờ chỉ mục chẩn đoán.

**Bước kế tiếp trên Demon:** thu một phiên mới có chỉ mục này, đối chiếu
ACK/published sequence với observation, projection và delivery. Nếu response
vẫn không có identity thì chỉ mục/counter giúp thu hẹp nhưng chưa tự chứng
minh nguyên nhân. Chỉ sửa đường thu khi có bằng chứng; không nới giới hạn
hay thêm reads theo suy đoán. Mega/Galaxy tiếp tục hoãn theo ưu tiên user.
