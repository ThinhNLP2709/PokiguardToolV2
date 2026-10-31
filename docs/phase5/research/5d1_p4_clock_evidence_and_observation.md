# P4 — Clock evidence và passive observation contract đề xuất

2026-10-12. FILE-ONLY EXECUTED; **native observation NOT ACTIVATED**.
[Report](../reports/5d1_p4_report.md), [ledger](../artifacts/5d1_clock_evidence_v1/clock_evidence_final.json).

## Current-build evidence

`artifacts/5d1_clock_evidence_v1/inspect_files.py` chỉ mở local files, pefile và
Capstone. Không process enumeration/attach/function call/injection/network.
Artifacts output bằng exclusive-create; không ghi đè output cũ. Source275 và
parent P3 files được hash trước khi sửa docs. Game hashes đầy đủ trong `before.json`.

`current_b6_disassembly.txt` là bytes từ current GameAssembly, range xác định
bằng declared b6 method boundaries; padding `int3` được giữ. Annotation method
addresses có shared implementation nên một tên annotate không tự chứng minh
ownership. `current_b6_detail.txt` resolve thêm string/type metadata của đúng
b6. Ví dụ key `srvNow` trước `turnRemainingMs` là literal verified, không đoán
từ DTO field tên `serverNow`. Hai tên này không tự đồng nhất.

`current_b6_network_time.txt` xác minh heartbeat RTT độc lập: stopwatch quanh
WebSocket ping, success milliseconds/failure−1. Không gọi ping trong P4.
`ServerClock.Observe` dùng HTTP Date với midpoint/best RTT; không pin per-turn
network age. `ClockDriftMonitor` so UTC với local mono; rate/drift monitor không
là đồng bộ epoch tới host Python hoặc proof delivery latency.

UnityPlayer string `UnityEngine.Time::get_unscaledTime` tại RVA `0x2005B28`,
pointer trong name array tại `0x201A358`. Array contiguous4109entries bắt đầu
`0x2012CE0`; index3791. Giả thuyết parallel function array tạo candidate
`0x1077F30` có code đọc một global và time-shaped fields. **Association chưa
verify:** các scoped RIP/data xref searches không xác minh được registration
loop/base. Không suy từ hai array liền nhau thành pointer chain được dùng.
`unity_parallel_table_hypothesis.json` luôn UNVERIFIED; không đưa global/field
của candidate vào provider/probe. `unity_registration*.txt/json` là exploratory
scope, không tuyên bố đã audit toàn engine hoặc không tồn tại clock source.

Read contract hiện có chỉ lấy duration/raw timer. Không có age/reset witness.
Pause, FX reanchor, frame freeze và queue residence làm việc đọc thêm anchor
đơn lẻ chưa đủ. Reconstruct client getter, nếu sau này prove được, cũng chỉ
cho client countdown trước khi có transport/server-clock uncertainty proof.

## Đúng một phương án: passive anchor observer riêng

Đây là proposal có thể review, **không sửa contract production mục3**.
Chưa triển khai hoặc attach trong P4. P5 được chuẩn bị offline riêng; native
collection chỉ sau explicit activation, source/build pinned và operator mở game.

| Field b6 | Type/offset | Mục đích |
|---|---|---|
| HasServerClock | bool `+0x1BC` | Phân biệt thiếu anchor |
| ClockPaused | bool `+0x1BD` | Tách paused samples; không suy pause reason |
| _clockRemainAtAnchorSec | float `+0x1C8` | Giá trị remain được anchor |
| _clockAnchorUnscaled | float `+0x1CC` | Nhận thấy anchor đổi, không mặc định server tick |
| _localFxHoldUntilUnscaled | float `+0x1E8` | Phân biệt FX reanchor candidate; chưa có current Unity clock thì hold-active vẫn UNKNOWN |

Mỗi sample bracket bằng host monotonic start/end, dùng existing read-only
root/runtime identity primitives trong **standalone utility**, không chạy farm
controller/provider poll đồng thời. Hai raw blocks A/B `[MatchService+0x1BC,
+0x1EC)` dài48B; chỉ decode năm field trên. Padding/pointer/event bytes bỏ,
không dereference/serialize reason string/event pointer. Incremental cost96B,
2RPM/sample; tối đa57.600B/1200extraRPM ở600samples. Root/identity/current timer
reads ngoài phần incremental này phải có full inventory/counters trong P5;
không quảng cáo96B là toàn chi phí observer.

A/B khác, nonfinite/out-of-range float, invalid bool/pointer, build/session
drift, quá read span/cap hoặc Stop → invalid/abort, không retry sample để che lỗi.
A/B bằng không là atomic snapshot proof hoặc tick receipt. Unity float ULP,
ABA/reanchor, unknown hold-active và missing turn causality luôn có status rõ.
Existing identity ít nhất gồm current build/process lifetime/MatchService pointer,
matchId/turn/player/raw timer theo primitive đã xác minh. Không map theo turn
number một mình; không reuse host anchor qua reconnect/process/match reset.

Chỉ quan sát changes + khoảng first-seen host, không quy host tool startup sang
Unity epoch. Field timestamp không đổi không là freshness proof; updated anchor
có thể do FX. P5 parser không được xuất finite U hoặc activation artifact từ
những observations này. Current Unity native/global candidate bị loại khỏi
read allowlist. Thêm clock root/SpeedGuard/payload/RTT reads là scope mới, cần
file evidence và review lại; không tự thêm dưới tên diagnostic.

Future live window đề xuất60s,≤600samples, rate≤10Hz (không catch-up), một cửa
sổ/không resume. Người dùng chơi tay tối đa1trận; observer không mở/trở lại room,
không click/capture/farm/consume energy tự động. Chưa kích hoạt cửa sổ này.
Đủ samples để kiểm tra anchor/raw/paused hypotheses thì dừng sớm; lỗi/Stop,
process exit, build drift hoặc cap kết thúc ngay. Nếu không có turn usable,
INCONCLUSIVE; không tự repeat. Log bounded, không tokens/chat/payload dumps.

## Return gate và giới hạn không được bỏ qua

P5 phải chứng minh offline parser/cost/caps/Stop/output binding và bảo toàn
source gameplay trước khi đề xuất người dùng mở game. Native sample có ích để
phân biệt local-anchor behavior, **không tự bound transport_age**. Sample max,
RTT max hoặc small-N p99 không là hard upper bound cho future ticks.

Sau observation, muốn nhận finite native U phải có causal source + defensible
server/client alignment interval và invalidation gates, ngoài các local fields.
Thiếu thì giữ UNKNOWN, không thêm các batch để tìm PASS. Nếu yêu cầu safety phải
đổi thành một operational/risk contract, đó là quyết định thiết kế riêng cần
user chốt với concrete before/after; P4/P5 không tự hạ gate hoặc enable UI.
Native R calibration3/max5 và D1pilot chưa được kích hoạt bởi tài liệu này.
