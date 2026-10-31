# 5D.1-P4 — Clock-age evidence trên đúng build b6

Ngày 2026-10-12. **OFFLINE RESEARCH COMPLETE / NATIVE U UNKNOWN; PARTIAL D1.**
Parent [P3](5d1_p3_report.md). Không sửa runtime, không attach game, không input,
không build/version/Git mutation. **Chưa cần mở game.**

## Kết luận

Không thể chứng minh tuổi raw timer bằng read contract hiện tại. Tool đọc đúng
field b6 `TurnTimeRemainingSec +0x190`; field này không chứa thời điểm nhận tick.
Ngay cả đọc lại cùng giá trị cũng không phân biệt được tick mới và message cũ.
Vì thế chưa có U hữu hạn để kích hoạt bounded decision wait native theo contract
đang có. Không dùng proposed150ms, integer1s, RTT hoặc thêm trận farm để điền U.

P4 có phát hiện cần sửa trong nghiên cứu P3: các dẫn chứng Cpp2IL ở
`reverse/cpp2il_*` là layout cũ (`+0x118/+0x138/+0x13C`), không phải layout b6.
Hash GameAssembly hiện tại trong report không tự bind body reverse cũ với b6.
P4 đã disassemble trực tiếp file b6, đối chiếu declared symbols b6 và lưu raw
bytes/RVA/calls/literals. **Đây là sửa bằng chứng nghiên cứu; provider không bị
đọc nhầm offset.** Historical artifacts/report P3 được giữ nguyên.

## Những gì đã xác minh

| Hạng mục | Bằng chứng hiện tại / giới hạn |
|---|---|
| Build | GameAssembly `72d10a43…ec063`, UnityPlayer `bb93aa06…0b6d2`, launcher `32ef7bda…5929`, metadata `ac32633a…17c47`; exact full SHA/bytes trong `before.json` |
| Raw timer | b6 getter RVA `0x416CE0` đọc Int32 `+0x190`; provider và final reader dùng constant `0x190`; duration `+0x44` |
| Timing ingress | `HandleMatchTimerTick` RVA `0x423A70`: matchId, payload, turn/duration/raw integer với fallback giá trị cũ; sau đó `ApplyTimingFields` |
| Anchor | `ApplyTimingFields` RVA `0x417A50`: `turnRemainingMs >=0` mới cập nhật HasServerClock `+0x1BC`, pause `+0x1BD`, remain float `+0x1C8`, unscaled anchor `+0x1CC`, integer `+0x190` |
| b6 thêm `srvNow` | Cùng method đọc literal `srvNow`, positive value cung cấp cho SpeedGuard cùng realtimeSinceStartupAsDouble; đây là anchor/rate monitor, không phải bound tuổi message |
| Pause/FX | Getter RVA `0x4177D0` giữ remain khi paused hoặc local FX hold, ngược lại trừ elapsed Unity; clamp. `BeginLocalFxHold` có thể tự sửa remain/anchor; anchor đổi không đồng nghĩa nhận server tick |
| Dispatch | WebSocket callback decode/preparse rồi enqueue closure; closure route `MATCH_TIMER_TICK` tới event; main-thread dispatcher có budget4ms/min4actions/heavy cap. Budget xử lý mỗi frame không bound queue residence hoặc độ dài frame |
| RTT | Heartbeat đo Stopwatch quanh `WebSocket.ping`, ghi `ChatService +0x2F0`; failure ghi−1. Không có timestamp/identity của timer tick trong phép đo này; không lấy LastRttMs làm upper bound cho message khác |
| ServerClock khác | `ServerClock.Observe` dùng HTTP Date/Unix seconds, best historical RTT và midpoint. Không cung cấp per-turn transport/offset interval được pin để chứng minh U |
| Unity wrapper | b6 `Time.unscaledTime` RVA `0x2739270` resolve icall, cache function pointer RVA `0x38D8230`, tail-jump. Cache vẫn là hàm, không là time value |
| UnityPlayer native follow-up | Tìm đúng icall string và array4109 tên; parallel function-table hypothesis cho candidate `0x1077F30`. Chưa prove registration association/runtime target. Code shape không đủ quyền nhận singleton/clock chain; candidate giữ UNVERIFIED |

Đã đọc trực tiếp GameAssembly/UnityPlayer/metadata/launcher; không gọi hàm game.
Mọi address ở đây là module-relative RVA, không runtime absolute pointer.
Sources/line ranges/hash và hypotheses được pin trong
[clock ledger](../artifacts/5d1_clock_evidence_v1/clock_evidence_final.json).
[Nghiên cứu/đề xuất cụ thể](../research/5d1_p4_clock_evidence_and_observation.md).
Verified findings đã bổ sung symbol/board docs, đánh dấu bảng countdown cũ là
historical để không sử dụng nhầm cho b6.

## Năm thành phần U

| Thành phần | Trạng thái |
|---|---|
| anchor_age | UNKNOWN: accepted observation không có anchor/current Unity time; FX cũng reanchor |
| transport_age | UNKNOWN: chưa có cùng-message causal timestamp và interval đồng bộ server/client; queue/network có thể trễ |
| host_unity_alignment | UNKNOWN: clock origin/rate/frame caching/suspend chưa được bind; startup tool không là Unity epoch |
| read_span | Có thể đo host bracket; P4 không có native sample, chưa có upper bound được review |
| quantization | Với payload `turnRemainingMs >=0`, phép chia integer cho1000 gây phần lẻ <1000ms. Conditional arithmetic fact, không bound tuổi raw fallback hoặc toàn bộ U |

Một trường hợp không phân biệt được: hai lần đọc trả cùng match/turn/remaining,
nhưng một client vừa nhận tick, client kia đang giữ tick cũ. Các giá trị hiện có
không chứa tuổi tick. Getter smooth/RTT hoặc một max quan sát hữu hạn cũng không
tự loại trường hợp message bị giữ lâu hơn. Ledger verdict
`UNKNOWN_NO_FINITE_NATIVE_TIMER_AGE_BOUND`, `native_U_ms:null`, input authority false.

## Một remediation tối thiểu đã chuẩn bị

**Standalone passive anchor observation**, tách khỏi farm runtime, không thêm
read/capture vào BASIC. Bước đầu chuẩn bị offline: fake memory/parser, binding,
cost/limits và export; chưa attach/chạy native. Đề xuất scope cụ thể trong research:
hai reads48B quanh existing read-only identity/runtime sample, chỉ decode năm
field verified HasServerClock/ClockPaused/remain/anchor/FX. Thêm96B/hai RPM mỗi
sample so với baseline sample, chưa gồm root/identity reads phải inventory riêng.
Không đọc candidate Unity singleton chưa prove, không gửi ping/request.

Future observation nếu được kích hoạt riêng: tối đa60s/600samples, một cửa sổ,
người dùng chơi tay tối đa1trận;0tool input/0farm attempts. Mục đích phân biệt
raw-stale, anchor updates, pause/FX và host bracket; **không tự nhận là proof
server deadline**. Không thu token/tài khoản hoặc toàn bộ payload/chat.
Transport vẫn thiếu thì kết luận INCONCLUSIVE, dừng; không tự thêm trận hay
giảm tiêu chuẩn U. Đây là proposed diagnostic read contract, chưa thay accepted
production read contract và chưa có native authorization.

## P3 SLO và bảo toàn

P3 2071tests, prepared checkpoints, warm soak30min, paired sink CPU và fault/Stop
giữ đúng scope offline/source275. Không chạy lại tests/historical qualification
trong bước docs/evidence này. Không nâng thành whole-app native latency,
deadline correctness, live efficacy, mọi action family hoặc packaged acceptance.
Native R/cohort, actual timer proof và D1 activation vẫn thiếu; BASIC calibration
3/max5TOTAL prepared/not activated, C3cap6/D1draft12 không được mở lại.

275 Python sources,428P3 artifact files và4game files inspected byte-preserved.
Preferences config giữ nguyên; saved_at được lưu lại trong lúc rà soát,
writer identity không được quan sát và P4 không ghi file này. Exact hash
reconstruction xác nhận chỉ saved_at đổi: entry94e26fd… → observedf7fd55e….
First verification12/13 (whole-file preference equality false) giữ nguyên;
`preferences_observation.json` và `verification_final.json` ghi đúng scope. **Đính chính SHA preferences trong
văn bản P3:** artifact `before_preferences_sha256.txt` và P4 entry file đều là
`94e26fd36c1032f66e8125362ba223e9f4bb08e7af7ebe67b99706cab9ae9f55`;
`a8ce6394…` được copy từ mốc cũ trong report. Đó là lỗi SHA trong văn bản P3, tách biệt với saved_at thay đổi
trong cửa sổ P4; P4 không sửa preferences. Verification/file manifests nằm trong artifact P4.

Exactly one next: **[5D.1-P5 — offline observation preparation](../prompts/5D1_P5_PASSIVE_CLOCK_OBSERVATION_PREPARATION.md)**,
SELECTED ONLY / NOT EXECUTED. Không D1/D2, không native R calibration.
**STOP P4.**
