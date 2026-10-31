# 5D.1-P21 — Root policy implementation, offline

2026-10-15 (Asia/Saigon). **IMPLEMENTED / FUNCTIONAL REGRESSION PASS /
PARTIAL — QUALIFICATION TAIL REVIEW REQUIRED.** Không có live authority.
[Prompt](../prompts/5D1_P21_ROOT_ADMISSION_POLICY_IMPLEMENTATION_OFFLINE.md),
[parent P20](5d1_p20_report.md),
[readiness](../artifacts/5d1_root_policy_p21_v1/readiness.json).

## Kết quả

Đã triển khai successor v4 **OPERATIONAL_ROOT250_FINAL100_V1**:
full root poll cap250ms, final direct-runtime read cap100ms. Legacy/v2/v3 giữ
ngưỡng cũ và strict finite-U giữ nguyên. Source/default BASIC không mở worker
hoặc input path mới. Không đổi provider, solver, BASIC, weights/model,
controller, executor/pacing, ACK/result/room/recovery/Stop.

**2,316 full tests PASS trong398.818s**, exit0. Đây là offline regression với
native surfaces được fake; không phải native acceptance của root250.
Qualification đạt **31/32 gates**. `full_timing_pipeline_latency` FAIL vì
measured sample index2789 có **11.8417ms > max10ms**. Sample được giữ nguyên;
không chạy lại để tìm PASS, không nới threshold hoặc bỏ outlier.

Verifier/exporter từ chối qualification này. **Không có pilot draft mới,
current allowance/reserve accepted, activation/request/claim hoặc live run.**
P21 đóng PARTIAL, chưa mở successor pilot.

## Implementation và binding

- `reasoning_operational.py`: optional immutable root policy, typed values và
  final100 bắt buộc. Legacy authority identity vẫn byte-equivalent về digest
  bằng cách bỏ field mới khiNone. Deadline/command ceiling/matches/Stop/session
  ownership methods giữ; new policy chỉ được load qua reviewed-v4.
- `reasoning_pilot.py`: root admission đọc cap đã verify. Rejected-root receipt
  ghi policy v4; prior completed offer vẫn bị veto kể cả cùng source.
- `reasoning_swap_timing.py`: chỉ thêm policy vào cached setup metadata của
  opt-in collector. Final preflight100 và post-return monitor giữ nguyên.
- New `reasoning_root_policy.py`: verify riêng v4, exact P18→P21 source pairs,
  protected methods/approved bodies, frozen parent review, P19 raw joins và
  fresh policy-qualified costs. Runtime load cần activation pin root policy,
  calibration/allowance/contract cùng source/host/build/config/cohort/cap.
- New `review_reasoning_timing_v4.py`: file-only export/verify/draft builder;
  draft path bị chặn trước khi tạo output nếu qualification fail.
- Qualification đo actual admitted root250ms, root250ms+1ns rejection,
  invalid clock và busy cùng existing checkpoint/collector/monitor paths.
  Không thêm game reads/captures/polls hoặc hot-path disk IO.

Current source297:
`bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`.
Parent source294 b673eab2…; **6 existing changes / 3 new files / 288 existing
files byte-exact**. [Exact source map](../artifacts/5d1_root_policy_p21_v1/final_test_source_manifest.json)
và source_diffs giữ toàn bộ thay đổi. New source không được grandfather dưới
P18/P19 request. Version1.2.5/package/HEAD giữ; không build hoặc release.

## Tests và lịch sử các lần chạy

25 tests thêm ở `test_reasoning_root_policy.py` gồm root/final exact boundary,
invalid clocks/policy types, immutable binding, original-t0/50ms floor,
cached-offer rejection, legacy policy smuggling, real fake-controller
read/input/ACK parity, v4 source/proof/activation tamper và inherited session
Stop/cleanup/fault races dưới authority mới. Shared source/config/legality/
monitor paths giữ byte và vẫn nằm trong full regression.

V3 file tests giờ kiểm frozen P18 view riêng, xác nhận real installed P21 bị
v3 reject và kiểm consumer cũ trên fake installed P18. Không nới v3 verifier.
Fixture thêm exact before/after layer để historical C3/P10/P13/P14/P16/P18
vẫn kiểm đúng source của mình. Cache chỉ sống trong một invocation của source
fixture; original SHA checks vẫn chạy. [Cache scope check](../artifacts/5d1_root_policy_p21_v1/fixture_cache_validation.json)
xác nhận invocation kế tiếp verify mới, không có persistent cache.

Initial focused run72 tests có4 lỗi harness mới:3 inert buffers dùng giới hạn
không phù hợp và1 duplicate keyword trong fake P18 source view. Đã sửa;10
affected checks PASS. Full2316 trên final source đã kiểm lại cả nhóm còn lại.
Các logs initial/repairs đều giữ, không gọi initial run là PASS.

Lần qualification đầu dừng ở fixture chưa biết source P21. Hai lần kế tiếp
được ngắt **trước microbench**, khi mới có source_manifest, để sửa traversal
ancestry lặp nhiều tầng. Chỉ dừng process qualification do agent tạo; không
đụng game/UI. Source fixes và artifacts từng lần được giữ. Final measured run
`qualification_verified` hoàn tất32 gates với31PASS/1FAIL; không rerun sau FAIL.

## Qualification raw và gate bị chặn

[Raw qualification](../artifacts/5d1_root_policy_p21_v1/qualification_verified/qualification.json)
pin61,000 values, gồm51,000 measured và toàn warmups/outliers. Đọc `pass_all=false`
và gate result; command exit0 không có nghĩa qualification PASS.

| Phép đo | p50 | p95 | p99 | Max |
|---|---:|---:|---:|---:|
| Full collector pipeline | 0.2725ms | 0.4227ms | 0.6878ms | **11.8417ms** |
| Completed three checkpoints | 0.6876ms | 1.1787ms | 1.7252ms | 12.5955ms |
| Admission + checkpoints, admitted | 0.6923ms | 1.1641ms | 1.6478ms | 8.8324ms |
| Signal-only Stop | 0.0039ms | 0.0040ms | 0.0047ms | 0.0264ms |

Completed added mean CPU0.75ms; admission mean CPU0.73125ms dưới1.5ms gates.
Stress receipt60.000659s/53,757cycles, max1 queued record, peak26,032B; không
có per-cycle trace, không native/whole-app soak claim. Worker reap/cleanup gates PASS.

Pipeline measured5000 samples có đúng1 mẫu vượt10ms, index2789. Next-largest
9.2042ms. Wall-time raw không có CPU/per-stage/GC/scheduling trace cho mẫu đó;
nguyên nhân **UNKNOWN**, không gọi nó là OS noise hoặc root-policy regression.

Descriptive arithmetic từ failed run: S24.4372ms, R6772.1419ms với native basis
H405.3797/I2972.325/W3120/G250. Đây **không phải accepted allowance/reserve**;
validator từ chối trước draft. Không dùng P18 S/R cũ thay current qualification,
không hạ reserve dựa trên P19 samples nhỏ hơn. Guard/margin/budget/deadline giữ.

## Native lineage và preservation

V4 recompute original P11 native26returns/20anchors/3attempts/4superseded,
P15 operational7returns/16missing/5root vetoes riêng, rồi P19 source29430returns,
3attempts/33collector intervals/108durable events/worker jobs7,1,0 riêng.
P19 H253.036/I2845.9532 không giảm combined basis cũ. Counterfactual27roots của
P20 không thành jobs/calibration/action/ACK giả. Native U/transport/alignment
null; first exact click/accepted-override native latency NOT_MEASURED.

Parent artifacts5,264,6claims, ordinary preferences,4static game files, host,
HEAD và toàn source pairs được kiểm bảo toàn. Existing idle UI log là frozen
prefix và append riêng; không dùng như native combat evidence mới.
Không game attach/read/capture/input, UI/observer launch, network/memory write,
ordinary preference change hoặc Git/version/build. Regression dùng fakes/temp
files; V1/game installation chỉ read-only khi hash các static files.
[Final verification](../artifacts/5d1_root_policy_p21_v1/verification_final.json).

Next duy nhất **[P22 pipeline tail review OFFLINE](../prompts/5D1_P22_PIPELINE_TAIL_REVIEW_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game hoặc live test, không resume
P19. Chưa general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc Phase5 completion.
**STOP P21.**
