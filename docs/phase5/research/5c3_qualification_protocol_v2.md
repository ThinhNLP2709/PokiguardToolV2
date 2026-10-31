# 5C.3 — Qualification bổ sung, offline

Ngày 2026-10-11. Parent: [C3 report](../reports/5c3_report.md),
[return plan](5c3_measurement_return_plan.md), [A3 SLO](../specs/5a3_telemetry_deadline_acceptance.md).
V2 chưa sửa runtime/BASIC hoặc sử dụng game/input. V3 chỉ sửa filename uniqueness
của AI logger sau khi regression tìm được lỗi; BASIC/flow/input giữ nguyên.
Không thay numeric targets.

## Vì sao cần phép đo bổ sung

V1 là stress probe dùng digest common sink và một SIMPLE config cho sáu
profiles. Giữ nguyên [raw/protocol/result V1](../artifacts/5c3_integration_v1/performance/benchmark.json)
và kết luận 4/12 nhóm không đạt. Nó không qualify healthy integration.

Calibration native đầu tiên cũng giữ riêng tại
[native_timing](../artifacts/5c3_integration_v2/native_timing/calibration_result.json).
AI tắt ở cả hai path mà chênh lệch một lần ghi lên tới 254,3307 ms. Sau đó
fixture Mega bị từ chối do cấu hình loadout không hợp lệ. Đây là lỗi setup
của harness, chưa có evidence về lỗi gameplay. Calibration NOT_QUALIFIED;
không bỏ spike, không dùng phần chạy dở làm acceptance. Metadata có source
hash trước chạy; không có archive đầy đủ bản entry point cũ của calibration.

Hai lần ghi file khác nhau, dù dùng cùng payload, không chia sẻ cùng thời
điểm disk flush/cache/scheduler. Chênh lệch max giữa chúng không xác định
được riêng chi phí AI. Vì vậy V2 freeze phương pháp dưới đây **trước** lượt
đo mới; không thử lại cùng protocol đến khi đạt.

## Latency: cùng lần ghi native và đầy đủ wall time

Entry point: [qualifier](../../../tools/qualify_reasoning_integration.py).
[Frozen protocol](../artifacts/5c3_integration_v2/causal_native_timing/protocol.json).

- Ba runs, mỗi mode 10.000 measured pairs + 1.000 warmup. Mode:
  disabled/shadow/degraded/stopped. Xoay thứ tự mode/profile, đảo thứ tự mỗi cặp.
- Mỗi combat giữ đúng immutable profile/config và một factory-owned adapter.
  Mega/Demon dùng loadout hợp lệ; Bú win trả UNSUPPORTED theo contract.
- Common writer là UTF-8 append, buffering=1; `_decision_fields`, serializer,
  write/flush là code đang accepted. Native AI writer/status manager thật.
- Ghi cả control/mode wall time, paired wall difference, quantile differences,
  exclusive added duration và paired exclusive difference. Giữ mọi mẫu và
  lossless gzip của common rows; chỉ bỏ timestamp khi so logical parity.
- Đo outer write/flush và native write/flush lồng bên trong **cùng invocation**.
  Outer trừ inner cho thời gian wrapper/admission cùng overhead clock/probe.
  Dùng chính tổng thời gian này làm gate, không trừ overhead probe control:
  bảo thủ hơn paired exclusive difference.
- Đồng thời gate `Q_mode-Q_control` của **toàn native path** ở p50/p95/p99.
  Max native wall và max paired wall difference vẫn công bố, không gán nhãn
  causal added max. Không che outlier hoặc gọi native I/O là hard realtime.
- Tất cả code runtime cũ giữ nguyên byte. Phần mới trên đường publish nằm
  trong `_ObservedLog.write/flush`; Stop signal được đo riêng tại actual
  controller callback. Không tuyên bố đo wall time game/provider/input.
- Chỉ measurement main thread được pin CPU và ABOVE_NORMAL; restore trong
  finally. Không đổi priority/process affinity của game hoặc ứng dụng khác.

| Mode | Exclusive added p50/p95/p99/max | Full native quantile difference p50/p95/p99 |
|---|---|---|
| Disabled | 0,10 / 0,50 / 1 / 5 ms | 0,10 / 0,50 / 1 ms |
| Shadow/degraded/stopped | 0,50 / 1 / 3 / 10 ms | 0,50 / 1 / 3 ms |

Các ngưỡng lấy từ A3. Đây là hiệu chỉnh cách đo **added software work**, không
phải tăng ngưỡng hoặc bằng chứng bounded disk/scheduler latency. Tên trường
`paired_delta_ms` trong summary V2 lưu exclusive mode duration (có probe);
paired difference thật nằm ở `paired_causal_difference_ms`.

Sáu fixtures có SIMPLE/CAREFUL SWAP, bốn profile còn lại NONE. Non-SWAP không
đủ exact source được từ chối ở observer; không tạo card/skill identity giả.
Gate này áp dụng seam hiện có, không chấp nhận selection/card/QTE mới. Các
profile/family chỉ mở ở C4/D khi đủ capability. Burst drops có counters và
chỉ là overload; healthy zero-loss được đo riêng dưới đây.

## Resources và sink CPU

Resource stream: 30 phút sau warmup 30 giây; source turn/sequence đổi mỗi
2 giây. Real BASIC policy/analysis → native common publication → actual
adapter/R1 process/native AI writer/status. Đây là published-event simulation,
không giả nó là toàn trận game hoặc actual controller ACK; full-controller
positive SWAP/ACK có fixture riêng.

Sample private bytes và CPU ở own PID/known logger/compute PIDs mỗi 20 ms;
retained query handles cho final lifetime CPU sau khi child đã reap. Không
quét process khác/game. Raw streamed, bounded first/last 5-minute windows.
Private bytes là proxy đã dùng ở B4, không gọi là exact private working set.
Gate main CPU ≤5 host pp, main/total private added ≤32/256 MiB, queue ≤8 MiB,
growth median ≤8 MiB. Healthy eligible logs/jobs không mất/discard/fail.

Disabled probe chạy fresh BASIC controller với adapter default None: không
import reasoning, không thread/job/queue/AI file hoặc extra read/capture.
Absolute own CPU là upper bound bảo thủ cho added CPU; ≤1 host pp, private
added ≤8 MiB. Probe này kiểm Stop/controller setup; không thay live profiling.

Sink CPU bổ sung so ba cặp 30 giây, xoay order, source đổi mỗi 2 giây và có
real R1. Tính **toàn** main/known children CPU, kể cả compute/startup. Common
writer accepted giữ native và giống nhau ở cả hai arm. Comparator shared dùng
B4 common writer emulation như C1: một producer observer route common records
và AI vào một writer, hoặc thêm separate AI writer. Đây là comparator offline;
không triển khai shared writer thay runtime. Gate separate−shared ≤1 host pp
ở từng run. Resource stream có thêm direct main+writer CPU bound, không dùng
việc trừ compute như một phép đo paired total CPU.

Metadata `writer_pid` trong V2 soak bị cache trước khi native writer lazy-launch,
nên là None. Đây là thiếu sót metadata của harness; tổng child CPU vẫn đủ
915 compute +1 writer qua retained handles. Verifier lấy logger PID từ final
raw sample sau compute kết thúc (chỉ còn main +logger), đối chiếu CPU handle,
và tính lại direct main+writer bound. Không sửa frozen raw hoặc dùng giá trị
bound thiếu writer ban đầu để PASS; paired CPU comparison lấy mọi writer PID
sau lazy-launch và tính toàn children CPU.
V3 chạy mới corrected-source soak, cập nhật PID sau lazy-launch ngay trong
sampling loop đã có; verifier bắt buộc metadata PID khớp final raw sample.

## Parity, faults và kiểm chứng

[Full controller fixture](../../../tests/reasoning_controller_fixture.py)
chạy actual `basic_auto_bot.run`: provider/window/native/capture boundaries giả,
real policy/actionability/calibration/map/final preflight/pending/direct ACK.
Freeze clock và RNG jitter cho cặp OFF/SHADOW; không xóa field gameplay để ép
parity. Kiểm normal SWAP→ACK→Stop, stale fresh source, wrong final turn,
pending→Stop; zero actual input/game handle.

Thêm 100 actual-controller Stop signal samples và 30 mỗi loại exception ở
admission/Stop. V1 100 paired Stop +180 worker trials giữ nguyên. B4 native
writer faults, cooperative cancel/hung reap chỉ được reuse nếu exact source
hash còn khớp, ghi rõ component scope. Full regression chạy sau measurement,
không đồng thời performance/resource probes.

[Verifier](../../../tools/verify_reasoning_acceptance.py) tính lại gates từ raw,
kiểm 248/250 existing sources byte-preserved, exact logger/audit AST exceptions,
frozen executed sources và new offline allowlist.
Historical V1 manifest giữ nguyên: document hashes của nó thuộc lần PARTIAL
trước, không phải hash của report cập nhật. Final V3 manifest ghi source,
artifact và document hashes mới. Không advance nếu còn required gate fail.

Live 0 attempts; runbook trong return plan vẫn PENDING. Chỉ khi offline đủ
mới ghi PASS_OFFLINE_LIVE_PENDING và chọn C4 offline, rồi STOP. C3 live closure
vẫn bắt buộc trước D; không suy technical acceptance thành efficacy.

## V3 rotation remediation — discovered by final regression

V2 full suite:1963/1964 PASS,1native rotation failure. Declared30-trial diagnosis
reproduced2 failures with `FileExistsError`, written2/failed1/discard7; writer
correctly degraded AI. [Raw diagnosis](../artifacts/5c3_integration_v2/rotation_diagnosis.json).
Không bỏ failure hoặc chạy lại cùng suite để tìm một lần xanh.

Fix giới hạn `_disk_writer` filename: local previous stamp và numeric names đã
có, chọn stamp lớn hơn dù wall clock cố định/lùi. Dùng danh sách paths đã scan;
không thêm IO scan, thread/process, queue hoặc work trên action path. Actual
write/ACK/error/retention/cancel code giữ AST. [Pre-fix archive](../artifacts/5c3_rotation_remediation_v1/before.json).

Source audit test thay đúng assertion cũ thành exact exception validation;
mọi controller/Stop/fault test method khác giữ AST,248existing sources giữ byte.
New tests: backward/existing stamps và30native fixed-clock
trials,300/300written, retention2files. Không giả source vẫn250/250 byte-identical.

V3 [artifacts](../artifacts/5c3_integration_v3/source_manifest.json): chạy mới
30min integrated resource soak, paired CPU/disabled probe/full regression trên
corrected source. Native publication benchmark **reuse** V2 raw: codec/admission/
Stop byte-preserved, benchmark AST giữ, chỉ naming ở off-path AI writer đổi.
Verifier gate compatibility riêng; không gọi copied raw là một timing run mới.
Full native IO max vẫn unbounded/descriptive. V2 failed suite và chẩn đoán
giữ nguyên; V3 chỉ đóng sau post-fix gates. Không build/version/Git/live.

V3 first post-fix suite:1964/1966 PASS,2source-audit failures vì new helper
allowlist bỏ sót builtin `len` trong phép cắt tên file. Đây là audit harness
error, không runtime failure. Chỉ thêm `len` vào pure-call allowlist; actual
logger/controller/rotation assertions giữ. Hai targeted audit checks PASS,
disabled probe và full regression chạy mới. [Archived failed suite](../artifacts/5c3_integration_v3/audit_remediation_v1/full_regression.log),
[original helper/hash](../artifacts/5c3_integration_v3/audit_remediation_v1/before.json).
Resource/sink measurements không import helper audit nên được giữ; final source
binding kiểm riêng các executed imports, không tuyên bố toàn harness byte-identical.
