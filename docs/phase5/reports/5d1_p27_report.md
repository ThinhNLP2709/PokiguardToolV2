# 5D.1-P27 — Collector config projection integration, offline

2026-10-16 (Asia/Saigon). **INTEGRATED SCOPED / 2,343 TESTS PASS /
PARTIAL — QUALIFICATION 31/32 FAIL.** No live authority.
[Prompt](../prompts/5D1_P27_COLLECTOR_CONFIG_PROJECTION_INTEGRATION_OFFLINE.md),
[artifacts](../artifacts/5d1_config_projection_integration_p27_v1/decision.json),
[parent P26](5d1_p26_report.md).

## Kết quả

Đã tích hợp nguyên hàm uncached projection đã prove ở P26 vào riêng collector
có immutable successor binding và component monitor. BASIC, legacy/v2/v3/v4
không opt-in vẫn dùng generic conversion. Không thay quyết định PlayStyle,
memory/provider/controller, screenshot, executor/pacing, ACK/pending, lifecycle,
room/recovery hoặc Stop. Không mở game/UI, attach process, phát input, sửa
preferences/claims, build/version hoặc Git state.

Full regression **2,343 tests PASS / 495.471s**, command wall497.0622s, exit0,
trên final frozen source301. Qualification **một invocation89.9154s**, đủ
61,000raw/51,000measured và nguyên32gates: **31PASS/1FAIL**.
`full_timing_pipeline_latency` FAIL vì measured index2612=
**10.4014ms > max10ms**. Giữ mọi warmup/outlier; không sửa source hoặc đo lại
sau khi thấy FAIL. Historical P21 index2789=11.8417ms giữ nguyên.

Cost validator và draft exporter đều reject; không tạo draft/output, activation,
request/run/expiry hoặc claim mới. **Accepted S/R null.** Native H source
binding cũng còn PENDING riêng; functional parity không tự thay native timing.

## Implementation và exact source review

`reasoning_config_projection.py` giữ nguyên AST hàm P26, đủ18field/type guard,
unknown shape/type fallback và current-value reads mỗi call. Không cache config,
JSON/digest hoặc bỏ validation. `reasoning_swap_timing.py` chỉ đổi `start`:
conversion nằm inline tại digest cũ, sau fresh witness/AutonomousSource và trước
`preflight_start_ns`. Legacy branch không import helper vào hot path.
Root metadata/limits, hash/witness calls, markers, monitor, encode/enqueue,
fault/Stop và preflight methods khác giữ nguyên AST.

`OperationalPilotAuthority` có optional immutable `config_projection_policy`:
exact version và root250/final100 bắt buộc. Identity bỏ field khiNone để giữ
legacy digest. Existing exact-type guards, deadline/matching/reserve/session
methods giữ nguyên. Common loader reject projection field trong mọi legacy/
v2/v3/v4 request/calibration; source-only review mới chưa có activation loader.

New `reasoning_projection_review.py` và file-only exporter verify exact
P21→P27 source pairs, approved `start`/authority bodies, protected AST,
candidate/proof/cost pins và complete source manifests. Old v4 verifier/exporter
không sửa hash hoặc nới rule; actual source301 bị v4 reject. Historical v4
tests dùng frozen source297 riêng. Fixture thêm exact before/after SHA layer,
cache chỉ trong một invocation; next invocation vẫn phát hiện changed bytes.

Source301:
`48eaf48d7b5bff826bfdd8a53b4d81f0574eb1509c1e2db760fc9bf93297cc33`.
**5 existing changes / 4 new files / 292 existing byte-exact**.
[Freeze](../artifacts/5d1_config_projection_integration_p27_v1/source_freeze.json),
[source pairs](../artifacts/5d1_config_projection_integration_p27_v1/after_runtime_manifest.json),
[flow proof](../artifacts/5d1_config_projection_integration_p27_v1/flow_preservation.json).
Version1.2.5/HEAD giữ; đây chưa là build hoặc release.

## Functional proof và các lần sửa trước freeze

Inherited118cases/67valid configs và18field replacements PASS. Real collector
được đối chiếu old implementation bằng deterministic monotonic/UTC clocks:
exact log bytes, digest/fields, source mismatch, input-parameter fault,
post-return overrun và no-authority/legacy/monitor branches. Có config
replacement, same-object fake mutation, unknown schema/type, nonfinite/copy
exceptions, fresh witness/hash ordering và independent output dictionaries.

Real fake-controller kiểm read/input/ACK parity với normal, conversion exception
và post-return fault: một input, một ACK, không second-input fallback. Inherited
session worker/writer lifecycle, Stop/factory races, cleanup và durable failures
được chạy dưới successor binding. Có source/proof/host repin tamper, old-v4
rejection và8 request/calibration smuggling combinations.

Initial focused50tests có29errors: proposed subclass bị existing type guards
reject và oracle gọi collector.close không tồn tại. Sửa bằng optional field
trên class cũ, giữ guards; cleanup thuộc session. Focused lần2 có13failures:
test fixture thay nhầm policy config và byte oracle chưa freeze UTC. Đã sửa
fixture, không nới runtime guard hoặc bỏ log field. Affected/new12tests PASS
trong6.065s; toàn bộ2,343tests sau đó PASS trên final freeze.
[All failures/repairs](../artifacts/5d1_config_projection_integration_p27_v1/functional_repair_history.json)
giữ nguyên logs. Không gọi failed attempts là PASS.

Source/fixture/AST/parent review preflight hoàn tất trước freeze và trước
qualification; không có pre-measurement retry hoặc P26 component rerun.

## Fresh qualification và accounting

[Raw qualification](../artifacts/5d1_config_projection_integration_p27_v1/qualification/qualification.json)
và [independent recomputation](../artifacts/5d1_config_projection_integration_p27_v1/qualification_recomputation.json)
pin current source/host, root250/final100, actual successor authority/helper/
component monitor. Fixed6000/path, warmup1000/path; Stop1000. Nearest-rank
quantiles và tất cả existing gate meanings/thresholds giữ nguyên.

| Phép đo | p50 | p95 | p99 | Max |
| --- | ---: | ---: | ---: | ---: |
| Full collector pipeline | 0.2407ms | 0.5295ms | 0.7430ms | **10.4014ms** |
| Completed three checkpoints | 0.6828ms | 1.1164ms | 1.5648ms | 10.6663ms |
| Admitted root + checkpoints | 0.7001ms | 1.3536ms | 1.8268ms | 13.8622ms |
| Signal-only Stop | 0.0064ms | 0.0074ms | 0.0107ms | 0.0859ms |

Exactly1/5000 measured pipeline samples vượt10ms; next-largest3.6323ms.
Pipeline p50/p95/p99 đạt, absolute max không đạt. Checkpoint/admission max gate
là30ms, giữ khác pipeline max10ms. Added mean checkpoint CPU0.734375ms và
admitted mean CPU0.73125ms dưới1.5ms. Stress60.0001407s/50,473cycles,
max1record, peak24,137B; worker cleanup/reap PASS. Stress receipt không là
native/whole-app soak, không có per-cycle traces.

Conservative descriptive S=13.8622+10.4014=**24.2636ms**;
R=H405.3797+I2972.325+S+W3120+G250=**6771.9683ms**.
Không trừ overlap hoặc giảm historical H/I. Accepted S/R vẫnnull; margin100,
one original t0, default budget4000/cap6000/floor50ms giữ.
Validator message `v3 pipeline threshold changed` là shared rejection message
cho violation này; threshold thực tế không bị thay.

P21/P27 là hai runs/source khác nhau, không là paired experiment để kết luận
whole-pipeline improvement hoặc tail đã fix. Raw wall time không có per-stage
CPU/GC/scheduling attribution cho mẫu2612; cause **UNKNOWN**. Không gọi OS
noise, GC, serialization hoặc user activity là nguyên nhân đã được chứng minh.

## Native lineage, preservation và bước kế

[Native compatibility review](../artifacts/5d1_config_projection_integration_p27_v1/native_compatibility_review.md):
conversion nằm trong H, trước preflight marker. P11 native26returns/20anchors,
P15 supplement7returns/16missing, P19 source29430returns/3attempts/108durable
events được recompute riêng; không sửa timestamps hoặc re-label thành new-source
calibration. Current native H/I basis **PENDING_H_CONVERSION_BOUNDARY**;
native U/transport/alignment null, root250/final100 chưa live.

Final preservation kiểm frozen301source/actual host, toàn bộ7,757parent
artifacts,6claims/current preferences,4static game hashes/HEAD và idle UI
prefix; before docs giữ exact P26 pins. Xem
[final verification](../artifacts/5d1_config_projection_integration_p27_v1/verification_final.json)
và [final manifest](../artifacts/5d1_config_projection_integration_p27_v1/final_artifact_manifest.json).
BASIC/default/shadowOFF và normal retention giữ; không quota đổi nước hoặc
suy win-rate/global optimum từ các tests này.

Next duy nhất **[P28 qualification failure disposition OFFLINE](../prompts/5D1_P28_QUALIFICATION_FAILURE_DISPOSITION_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Review current blocker và kế hoạch có giới
hạn từ existing evidence; không blind optimization, unchanged rerun hoặc nới
max10ms. Chưa cần game; không resume P19/general SIMPLE/CAREFUL/Demon/Mega/
D1cap12/D2 hoặc đóng Phase5. **STOP P27.**
