# 5D.1-P3 — Activation và calibration readiness

Ngày 2026-10-12. **PARTIAL / OFFLINE SOFTWARE VERIFIED / NATIVE CLOCK PENDING.**
Đã hoàn tất scope triển khai/qualification offline P3. Chưa đủ gate để chạy
calibration/pilot native. **0 live attempts; không cần mở game ở bước này.**
Parent [P2](5d1_p2_report.md). Current source v1.2.5; package không thay đổi.

## Kết quả thực hiện

Explicit source-only BASIC calibration đi qua UI Start/FarmRunner hiện có.
Creator tự hash current source, supported GameAssembly và launcher; loader
kiểm lại selected executable/build/source/config. Request freeze cohort label,
foreground/two_click/SOLO, Simple/Careful, ID, expiry tối đa2giờ và cap mặc định3/
max5 TOTAL. Global exclusive claim theo run ID chặn restart/resume, cả khi copy
file request. Không persist opt-in hoặc sửa ordinary preferences. Thiếu/sai
request vẫn BASIC; setup drift của phiên đã xác thực bị chặn trước launch.

Optional timing dùng các final reads/actions đã có, giữ raw preflight/read-end/
validation-end/executor-return upper bound, full AutonomousSource và incomplete/
Stop/error. Một finalizer có giới hạn flush/close writer và ghi watermarks ngoài
caller Stop; không chờ disk trong action. Export pin session/FarmRun ID/path/
config/cap, join action_sent/ACK theo full source; ambiguous/missing/mất record
đều không được xem là evidence đủ. Giữ mọi attempts và local-turn cost, kể cả
LOSS/UNKNOWN/abort. Không thay pacing/ACK/room/recovery hoặc ranking BASIC.

Expiry kiểm setup/Start; không thêm timer interrupt cho trận đang chạy. Runbook
yêu cầu operator Stop nếu quá cửa sổ. Cohort label không là combat-pet/effect
authority; actual witness vẫn phải đối chiếu. Chưa có native setup observation.

Clock loader yêu cầu báo cáo được pin riêng sau review, phép cộng năm bounds
hữu hạn và file/line/hash evidence. Đây là kiểm schema/binding, không tự chứng
minh vật lý. Synthetic fixture chỉ exercise schema; không promote thành game data.

## Bằng chứng software và performance

| Gate | Kết quả / phạm vi |
|---|---|
| Full regression cuối | 2071/2071 PASS, 248.426s, `full_tests_v4.txt` |
| New setup/export/clock cases | 13 ca trong full; source/build drift, expired/copy/restart/resume/cap, Stop log fault, real writer receipt, missing/ambiguous ACK/timing |
| Source/AST/default trace | 16/16, `qualification_v2/qualification.json`; 5 complete disabled native-fake trace pairs khớp; UI/manager/FarmRunner/executor optional AST reconstruction khớp |
| Prepared selector | 3x10.000 +1.000 warmup/run/mode; 6strata PASS; ready triple worst p99 1.1201ms, max 12.1192ms |
| Timing hook full start/preflight/finish | 3x10.000 +1.000 warmup/run; worst p99 0.5015ms, max 8.4208ms; full encoding/enqueue, fresh bounded sinks outside clock |
| Warm faults / Stop | 30actual trials mỗi hung-deadline/corrupt/raises =90; all BASIC/reaped;100Stop across5strata, p99 0.0525ms/max 0.0725ms; cleanup off caller |
| Affected warm soak | 30min +30s warmup, 915jobs; all 13gates PASS, one warm worker reused, writer/worker cleanup confirmed |
| Resources | Main CPU 0.4053host pp; whole main+children 0.6142pp; main added peak 4.7031MiB; total added peak 65.875MiB; queue peak 10008B |
| Growth | Last5min−first5min median 1.2695MiB; N 2804/2805; raw streamed, not old C3 soak |
| Healthy logs | Eligible/written 1830/1830; dropped/failed/discarded0; accounted before close |
| Paired log CPU | 3interleaved30s shared/separate pairs, whole warm pipeline, all children counted; deltas [0.2427, 0.1478, 0.2028]host pp, mean 0.1978pp <=1 |
| Fresh disabled BASIC | 300fake Stop runs/30.00s, CPU upper bound 0.6814pp, added private 2.2148MiB;0AI modules/threads/jobs/files/extra reads/captures |

Intentional decision wait tách riêng: soak N915, p50
78.138ms/p99 96.210ms/max
818.449ms, bao gồm cold/warm. Không lấy nó làm overhead
shadow. Prepared selector dùng actual warm offer nhưng shallow adapter copy /
bounded buffer mới ngoài clock và immutable timestamp; không là live latency.
CPU shared comparator là asynchronous writer emulation với cùng gameplay rows;
accepted synchronous gameplay writer không đổi. Cùng một owned2s warm soak ở
background cả hai arms; không có regression workload trong CPUv2. Không claim
whole-app/native perf/efficacy, counterfactual WIN hoặc mọi family đều accepted.
Calibration finalizer có real-writer/Stop test, chưa có native/long-run session.

## Source binding và phạm vi thay đổi

Before269: `ba0adf97d87b7efa93f2fa044bef2962814d1a4d375f2ba1bbc6600995c5c817`.
Final275: `c912711bcdd0d1607ecf9bd8915a7c2a943767402aabd6c718261fd505b5a415`.
261/269parent Python files byte-preserved;8existing changes và6new.
`before/`, `after_final/`, `before_source_manifest.json`,
`after_source_manifest_final.json`, `after_runtime_manifest.json` và
`review_final.diff` nằm trong [artifact](../artifacts/5d1_activation_readiness_v1/).
6 runtime/entry files pin riêng; những thay đổi còn lại là tests/qualification helpers.
Policy, provider, screenshot, ordinary input executor và combat controller byte-
preserved so với P2; new FarmRunner/desktop seams chỉ optional setup/metadata.
Ordinary preferences giữ SHA
`a8ce6394a258792f866a3357de2043ab6ecfc6d829e9af4e66848cfd2794bc46`.
Historical P2 artifacts được kiểm checksum, không overwrite/relabel acceptance.
No build/version/commit/push/tag/release; pc và V1 chỉ đọc.

## Những output lỗi được giữ nguyên

Collector soak_v2 đã thu1830s nhưng crash khi tổng hợp vì dùng tên counter
`dropped` thay cho schema `dropped_before_enqueue`; không có final qualification.
Raw/collector source giữ nguyên, không lấy làm resource acceptance. Collector_v3
persist baseline/jobs/final counters trước tổng hợp; chạy lại đúng30min vì lỗi
thu số, không chọn mẫu đẹp hoặc repeat để che regression. Early `soak/` cũng là
failed collector smoke, không accepted. Syntax/probe setup errors ở console.

CPUv1 bị invalidate vì last12s overlap full_v4; corrected CPUv2 là acceptance.
Readiness_v1 enum typo và final_v4 fixture đánh dấu discard thay vì written đã
sửa trong fixture; cả lỗi và kết quả trước giữ lại. Full_v1/v2/v3 là parent
candidates; full_v4 là current. `after/`/manifest không hậu tố là candidate cũ,
final dùng `after_final/` và manifest `_final`, không overwrite snapshot cũ.

## Native gate và đúng một next

GameAssembly hiện tại read-only SHA
`72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063`.
Reverse xác minh raw integer countdown cập nhật từ messages; smooth countdown
trừ elapsed Unity từ anchor. Tool hiện đọc raw field; cached Unity icall pointer
là hàm, không phải current-time value. Tick age/transport/host alignment chưa
có finite bound. **U UNKNOWN; native R/cohort NOT_MEASURED**. Không suy U<=1s từ
integer hoặc dùng proposed150ms làm evidence. Nguồn/derivation/giới hạn nằm ở
[clock research](../research/5d1_p3_clock_feasibility.md), hashes ở
`clock_sources_final.json`. Verified findings ghi trong symbol/board docs.

[BASIC runbook](../research/5d1_basic_calibration_runbook.md) default3/max5TOTAL
prepared/not activated. SmallN chỉ descriptive; export luôn reasoning_authority
false. Không yêu cầu người dùng chơi thêm để điền U; C3cap6/D1draft12 không cấp
quyền batch mới. UI REASONING vẫn gated; BASIC/shadowOFF default.

Exactly one next **[5D.1-P4 clock-age evidence](../prompts/5D1_P4_CLOCK_AGE_EVIDENCE.md)**,
targeted OFFLINE / SELECTED ONLY / NOT EXECUTED. Chưa D1/D2/native calibration.
**STOP P3.**
