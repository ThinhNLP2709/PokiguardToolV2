# Chuẩn bị thu bằng chứng callback Demon — 19/11/2026

Đã bổ sung lịch sử đọc root có giới hạn, kiểm offline và mở UI BASIC cách
ly ở trạng thái READY. **Chưa bấm Bắt đầu, chưa chạy trận mới.** Phòng được
kiểm bằng UI và read-only provider: Priest lv131/ID1845, Demon Aegis thường
ID560, room `Coop_300394`, ăn Khiên/ngưỡng4 Kiếm hiệu dụng, không tiến hóa.
Không đổi ordinary preferences hoặc file game.

Source mới:
`1909d77a6a66964d1e9867c5f26be81a30852f48c3aa4e4880db4cd222740303`.
Baseline trước setup là `d88e909f…`; native proof/profile trước vẫn pin
`b3ab48ce…`. Không rebind dữ liệu cũ, không build/train hoặc tuyên bố bản
mới đã được kiểm trực tiếp trong trận.

## Log thêm để phân biệt các tình huống

`dispatcher_reads` trong controller summary ghi:

- Mốc UTC cùng mốc monotonic của phiên, ID từng lần đọc, thời điểm bắt đầu/
  kết thúc, lỗi có nhãn cố định, số lần empty/nonempty/fail và khoảng ngắt.
- Callback/DTO/JSON bằng token theo phiên, queue/drain và logical index;
  không xuất raw address, payload, username hoặc exception text tùy ý.
- Các lần nhiều callback cùng DTO address trong **cùng một completed read**.
  Chúng là bằng chứng equality của address đã lấy mẫu, không tự chứng minh
  object lifetime, DTO pool hoặc nguyên nhân của response cũ bị thiếu.

Mỗi typed-capture observation có `reader_binding` để nối exact tuple/root
instance đã trả về với raw SHA, match/event/sequence đã giải mã. Binding
không tìm được hoặc đã bị đẩy khỏi cache giữ null; không tự gán read ID.
Các tầng board/ACK/typed-effect và quyền input vẫn độc lập.

Giữ tối đa128 event,8 root/event,16 alias event và4 read receipt gần nhất.
Empty/repeated membership được nén; lần ngắt hoặc đọc chậm từ20ms vẫn có
event đo thời gian. Ngưỡng này chỉ chọn log, không đổi chờ/input hoặc luật
game. Event lỗi có root count null, không được coi là đã thấy empty queue.
Có counter dropped/omitted/obsolete để nhận biết lịch sử chưa đầy đủ.
Reset token/generation theo phiên, không trộn ticket đang đọc của phiên cũ.

Không ghi đĩa trong reader/polling, không tăng số lệnh RPM, thay offset,
scan, fence, parser, nhịp sampler hoặc giới hạn capture. Có chi phí CPU cho
metadata: benchmark fake-memory p50 khoảng33,5→42,3µs, p95 55,6→67,5µs;
đây không là timing native. Event tuple được cache cho health polling.
Lỗi observer chỉ làm tăng diagnostic-fault counter, không che lỗi đọc gốc
hoặc làm hỏng board/message hợp lệ.

## Kiểm offline

**86 test PASS**, gồm shared-DTo trong cùng read/khác read, timestamp lỗi,
long-gap, bounded/redacted metadata, ticket cũ, exact-instance binding,
observer-fault isolation và tích hợp hai response đi hết tap/capture.
AST của protocol đọc gốc và tap sau khi bỏ hook metadata khớp baseline;
BASIC/adviser/PASS/input giữ nguyên byte. Fixture log lớn nhất203097 B.
Qualification mới đúng source/host: đủ14 gate PASS. Qualification và CPU
benchmark vẫn là synthetic, không cấp native acceptance cho source mới.

## Phiên đã chuẩn bị

Artifact: `artifacts/demon_reader_trace_native_20261119/`.

1. `live/` đã có request/preferences riêng: tối đa1 trận BASIC, AI tắt.
   Đã mở UI và thấy READY/target1/attempt1; không tự start.
2. Sau BASIC: `review_basic.py` xác minh kết thúc/ACK/timing và PASS theo
   payload authoritative của game; `review_reader_trace.py live` nối log.
3. Chỉ khi control hợp lệ mới tạo profile bằng `tools/prepare_common_runtime.py`
   từ export mới + qualification mới, `--max-attempts 1`; sau đó
   `prepare_reasoning.py`/`launch_phase.py reasoning` mở tối đa1 trận R.

Cap mới dự kiến2, đã dùng0;17 lượt cũ đều đóng. R chưa chuẩn bị profile hoặc
được chạy bằng timing cũ. Không tạo authority trước khi có BASIC mới.

Log trận nằm tại `live/data/logs/farm_runs/<run>/matches/attempt_001/combat.jsonl`
(R tương ứng dưới `reasoning/`). Trong `auto_controller_summary`:

- `dispatcherTransport.dispatcher_reads`: lịch sử root/timing/lỗi/alias.
- `dispatcherTransport.outcome_capture.observations[].reader_binding`:
  callback token/read ID nối đến typed response đã được quan sát.
- Các `action_sent`, `action_result`, `stateEvidence` giữ căn cứ độc lập
  cho nước gửi/ACK/state sau; không dùng root log thay thế chúng.

Mục tiêu là thu evidence cho đường reader hiện tại. Một trận đủ log không
chứng minh nguyên nhân của gap cũ; response không quan sát được vẫn UNKNOWN.
So chất lượng BASIC/R tại cùng pre-action snapshot, không xếp tốt hơn chỉ
bằng WIN/số lượt. Mega/Galaxy tiếp tục hoãn.

[Kiểm chứng source/test](artifacts/reader_trace_setup_20261119/verification.json) ·
[Qualification mới](artifacts/demon_reader_trace_native_20261119/qualification/qualification.json) ·
[BASIC prepared](artifacts/demon_reader_trace_native_20261119/live/prepared.json).
