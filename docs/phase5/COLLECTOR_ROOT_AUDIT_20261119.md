# Demon — rà callback đến capture log, 19/11/2026

Đã rà offline bằng reverse/native B17 và log của phiên đã đóng. Tái hiện
và sửa được **một lỗi có điều kiện trong bước gộp callback**. Chưa chứng minh
lỗi này gây ra response BASIC12 bị thiếu; không khôi phục effect cũ hoặc
tuyên bố capture đã đầy đủ. Không chạy thêm trận.

## Ownership và vòng đời đã kiểm

Binary `D:/pc/GameAssembly.dll` chỉ được đọc từ file, SHA
`bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.
Các lệnh native được giải mã lại từ đúng file và so byte với listing;
`dump.cs`, `script.json`, `il2cpp.h` đều có SHA trong artifact.

| Đường đã xác minh B17 | Bằng chứng |
|---|---|
| `ChatService.OnWebSocketMessage` | RVA `0xB6D940`; tạo closure328_0, giữ JSON tại+0x18 và DTO tại+0x20, preparse rồi tạo Action/enqueue |
| Callback328_0 | RVA `0xB7E130`; đọc chính JSON/DTO của closure, tail-call `DispatchIncoming` tại `0xB6DF50` |
| `TryEnqueue(Action,bool)` | RVA `0xC20980`; đường thành công gọi instance Enqueue tại `0xC219B0` |
| `UnityMainThreadDispatcher.Update` | RVA `0xC20CF0`; dequeue vào drain list, gọi delegate, có nhánh đưa phần chưa xử lý về queue |
| Dọn drain | `0xC21754` đặt size0; `0xC21769` gọi `System.Array.Clear` |

Các field/static owner và stride khớp exporter: static queue+0x08, instance
drain+0x20, PendingAction stride0x10, delegate target+0x20, closure
JSON/DTO+0x18/+0x20. Không thêm offset/RVA vào runtime hoặc dùng địa chỉ
ASLR tuyệt đối. Tên closure trong docstring đã sửa từ tên build cũ275 sang328.

Đây là nguồn ngắn hạn, không phải lịch sử tất cả response. Một callback
đến và bị xử lý/dọn giữa hai lần đọc có thể không được thấy. Chưa đo được
thời lượng tồn tại thực tế của callback thiếu; không suy số millisecond từ
cadence, FPS hoặc tổng poll. Board/ACK sau đó không chứa JSON đã bỏ lỡ.
Chưa xác minh một owner lâu dài khác giữ nguyên JSON cho response đó.

## Lỗi gộp có thể tái hiện và bản sửa

Reader trước duyệt đúng queue/drain và kiểm closure, nhưng kết quả dùng
`roots.setdefault(message_address, root)`. Hai callback hợp lệ có cùng DTO
address sẽ bị gộp dù closure/JSON khác nhau. Điều này không phải kiểm chứng
hai response giống nhau và có thể giấu JSON trước khi đến parser/index.

Đã đổi khóa thành **(closure address, DTO address, JSON address)**. Không
bỏ kiểm class/pointer, không đọc lại memory đã bị dọn hoặc tự đoán seq.
Một callback xuất hiện ở cả queue và drain tiếp tục chỉ trả về một root.

Hai ca synthetic thất bại ở reader cũ và qua ở reader mới:

- Hai closure cùng DTO nhưng JSON khác: trước1 root, sau2 root.
- Callback đầu DTO-only che callback sau có JSON riêng: trước1, sau2.

Integration dùng reader thật với fake memory và tap thật: cả hai JSON có
sequence9/11 đến được typed capture, raw SHA riêng biệt; đọc lặp không tạo
capture trùng. Đây là **bằng chứng lỗi có điều kiện**, không là bằng chứng
game đã chia sẻ DTO theo cách đó trong trận vừa rồi. Không giả định DTO
luôn riêng biệt hoặc khẳng định game có pool DTO.

## Kiểm lại log BASIC12

Match `M_29c474a7`, lượt5, source10 → published12: nước được ACK và có
published state; không có scoped observation/capture cho response12.
12 typed record thu được đều đã xuất và chuẩn hóa, không index fault/drop.
Summary có5 lần root torn/unavailable nhưng không giữ timestamp của từng
lần, nên chưa gắn được một lỗi root với đúng khoảng response12.

Log có message/JSON address cho các board offer đã thấy: BASIC9 offer/9
DTO address khác nhau; R13/13. Không thấy alias trong nhóm offer này.
Log không giữ closure address và thành viên từng lần reader.read, cũng
không có root của callback đã bị bỏ. Vì vậy không thể chứng minh hoặc bác
bỏ lỗi gộp ở đúng response12. Ba gap của match cũ cũng không được quy sang
nguyên nhân này. Tổng effect lịch sử khôi phục được:0.

## Kiểm chứng và phạm vi thay đổi

Source trước:
`86c22524a56d04e2fe4cea2f28d49ddc395d0bd85ba13b2f63c2218a339c4e1c`.
Source sau:
`d88e909faec74515b86ecaeaeb4e864ab0fafd4fbe5b0200b97dbc930ded1cc2`.
Chỉ đổi reader trên và test của nó. Tap, parser, exporter, BASIC, adviser,
PASS, input, nhịp sampler và các giới hạn giữ nguyên byte/giá trị.

**65 test PASS**. Differential replay9 ca giữ nguyên toàn bộ thứ tự/địa chỉ/
kích thước đọc root; ví dụ normal/alias đều19 lượt đọc trước và sau. Chỉ
hai ca gộp sai tăng số root trả về; normal, callback trùng, non-chat,
invalid-message, empty và torn queue/closure giữ hành vi cũ. Các fence
và phần control flow khác được kiểm AST bằng bản reader trước sửa.

Không thêm scan hoặc nguồn memory mới. Khi giữ được callback trước kia
bị gộp, tap có thể đọc thêm JSON/DTO đó qua đường đang có; **không khẳng
định tổng số process read không đổi** hoặc đã kiểm timing native mới.

Đợt này0 process attach/game input/live, không train/build hoặc rebind
profile. Các cap trước vẫn đóng, tổng lượt17. Native proof/profile gần
nhất vẫn thuộc source `b3ab48ce…`, không được đổi sang source mới. UI/game
không được thao tác hoặc xác nhận lại trong đợt offline này.

**Mốc tiếp theo:** kiểm trực tiếp reader mới trên Demon với cap mới riêng
và timing phù hợp source; nghiệm thu board/ACK/log/capture, không dùng một
ván đủ log để chứng nhận nguyên nhân của gap cũ. Chưa tự cấp thêm lượt ở
đợt rà này. Mega/Galaxy tiếp tục hoãn.

[Kiểm chứng và SHA](artifacts/collector_root_audit_20261119/verification.json) ·
[Replay trước/sau và giới hạn native](artifacts/collector_root_audit_20261119/replay.json) ·
[Native listing](artifacts/collector_root_audit_20261119/static.json) ·
[Script tái hiện](artifacts/collector_root_audit_20261119/verify.py).
