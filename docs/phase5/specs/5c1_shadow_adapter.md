# 5C.1 — Publication observer và shadow admission

Ngày 2026-10-10. Source v1.2.5 hiện có, baseline lịch sử v1.2.4.
Verdict/evidence cuối nằm trong [report](../reports/5c1_report.md).

## Seam và quyền sở hữu

`tools/basic_auto_bot.py:run(..., shadow_adapter=None)` có một hook setup opt-in.
Khi không truyền adapter, không import module reasoning và không đổi log handle.
Không có setting/CLI/UI mặc định bật shadow; 5C.2 mới expose immutable config.

Khi opt-in, `attach_shadow_log` freeze PolicyConfig và bọc handle log combat.
`_ObservedLog.write` chuyển **nguyên chuỗi và đúng một write** tới handle cũ,
sau đó try-admit chuỗi JSON bất biến đã được `_write` encode. `flush` vẫn chuyển
đúng một call tới handle cũ. Không sửa payload/retention/error semantics của
gameplay log và không thêm AI bytes vào file đó.

Observer chỉ nhận `policy_decision`, `action_sent`, `action_result` và
`pet_skill_dispatch_result` đã có. Pause/emergency/summary chỉ signal Stop AI;
ExitStack hiện có cũng signal qua wrapper chống exception. Không chèn callback
vào provider/capture/policy/preflight/executor/pending/ACK hoặc FarmRunner.

Host chỉ kiểm prefix tối đa160 ký tự, giữ immutable string, try-lock enqueue,
ghi counters và signal. Parse/copy/hash/schema validation/make_job/IPC/encoding
diagnostics đều ở thread/process nền. Queue full/busy/oversize bỏ observation;
không retry, sleep hoặc chờ để BASIC dispatch.

## Snapshot, deadline và attribution

Snapshot lấy board screen-order, session epoch/board instance/match, turn,
srvSeq, board hash, local actor, stats và incumbent SWAP từ publication hiện có.
Profile phải khớp config đã freeze. Generation của controller, observation age,
runtime model, legality certificate, account calibration và input reserve thiếu
thì để MISSING/UNKNOWN. Không lấy policy selection làm final-preflight proof.

SourceRecord là **virtual single-record publication**: digest của nguyên UTF-8
record, đường `published/<sha>.jsonl`, line1. Không giả đây là checksum của file
combat đang tăng. File nguồn này chưa được tự export; có thể materialize offline
từ record gốc đã log. Không thêm capture/export trên action path.

Hiện chỉ SWAP có đủ source trong legacy publication. Non-SWAP, owner/source/
coordinate/profile thiếu hoặc sai bị unsupported; BASIC vẫn xử lý family đó.
R1 vẫn kiểm112 swaps nhưng retain khi model/legality chưa bound. R2/model learned
không promote. Đây không phải acceptance hiệu quả của sáu PlayStyle.

Job có processing cap default4s, hard6s tính từ host nhận publication; đây là
**shadow analysis cap**, không phải deadline/reserve đã hiệu chuẩn để phát input.
Không lấy nó cấp quyền C4. New source có thể invalidate worker cũ; tối đa một
job được chuẩn bị mỗi1s. Job bị rate limit không khiến BASIC chờ hoặc đổi nước.

`action_sent` phải khớp session/turn/srvSeq/boardHash/board contents, SWAP target
và actual AutonomousActionIdentity. Khi khớp mới ghi dispatched BASIC candidate.
`action_result` chỉ link theo **nguyên identity** của dispatch đã quan sát. Root/
identity bị evict hoặc khác → UNKNOWN. ACK không là terminal win; boss action,
counterfactual outcome và terminal attribution không có thì luôn UNKNOWN.

Roots/dispatch identity maps tối đa64 entries mỗi map. Event stream có run/job/
snapshot/config/source/candidate correlation. Worker summary giữ provenance của
kernel offline; controller dispatch/outcome là event riêng, không sửa summary
thành một phản thực đã quan sát.

## Logging và các giới hạn

B4 stress cũ **vẫn không qualify separate sink ở tải khoảng500pairs/s**. C1 thêm
giới hạn thật trong source: **1job/s**, tối đa8 diagnostic events và128KiB trong
mỗi window1s. Overflow ghi counters, invalidate/stop AI; không synchronous rescue
write. Đây là phạm vi qualification mới, không repeat stress cũ để tìm PASS.

`create_shadow(enabled=True, directory=...)` tạo B4 bounded separate writer được
sở hữu bởi adapter. Disabled/thiếu directory+sink trả None; không tạo AI resource.
Common synchronous gameplay writer không được gọi từ AI thread và không bị sửa.
Default thiết kế B4 là shared; lựa chọn C1 chỉ đổi sang separate nếu measured
qualification của phạm vi rate-capped đạt cả CPU và action-seam SLO.

Combined buffers: input16records/1MiB, relay64/1MiB, sink432/6MiB =512/8MiB;
in-flight được charge. Host chỉ là input producer, runner chỉ relay producer,
adapter thread là sole sink producer. B4 retention10MiB×10files/7days, record
caps16/32KiB, error signatures64, first stack/repeat aggregation tiếp tục áp dụng.
Disk failure/known degraded queue chỉ disable AI; gameplay writer không chung
file/handle/process với AI. Lost/failed/discarded không được gọi written.

Stop chỉ signal adapter/runner. Owned worker/logger cleanup và best-effort
100ms flush nằm ở thread nền; controller không join/drain. `close` chỉ dùng
ngoài action/Stop path và báo false nếu cleanup chưa được xác nhận. Tail logs
khi Stop có thể mất và phải đếm; không hứa durable fsync.

## Phạm vi bằng chứng

Focused tests dùng actual BASIC policy và logging seam, frozen publication,
fault processes, bounded native disk writer và fakes cho input/read boundaries.
Không chạy toàn bộ controller với game thật. Source reconstruction kiểm hook
setup là thay đổi duy nhất so source trước C1; các owner/branches cũ giữ nguyên.

Perf đo toàn bộ **phần mới trên main thread**: observed-log write/admission và
forward flush, với BASIC direct-write control, 3×10k/mode +1k warmup/run. Enabled
dùng owned disk sink thật; backlog/busy/full/stopped dùng declared pressure fakes.
Không tính hashing như một prepared-submit đã có sẵn; hashing thực sự ở nền.
Full controller wall latency, live read/capture/input parity, reserve calibration
và package overhead thuộc C3/C4/F1, chưa được suy ra từ micro/seam benchmark.

CPU qualification3×30s/mode, shared writer emulation so common+separate writer,
8events/s với payload14,000bytes, zero-loss normal workload; chỉ sample own helper
PIDs, không quan sát process game. Shared emulation không là accepted common
backend. B4 CPU stress cũ và mọi prototype tails được giữ, không pool/loại outlier.
