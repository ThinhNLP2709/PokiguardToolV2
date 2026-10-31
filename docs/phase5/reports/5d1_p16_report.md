# 5D.1-P16 — Operational lifecycle/admission remediation, offline

2026-10-15 (Asia/Saigon). **PASS SCOPED OFFLINE REMEDIATION / NATIVE TIMING
REBINDING PENDING / PARTIAL D1.** [Prompt](../prompts/5D1_P16_OPERATIONAL_LIFECYCLE_ADMISSION_REMEDIATION_OFFLINE.md),
[parent P15](5d1_p15_report.md). Không game/live test, không build/version/Git.
Version1.2.5, HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29` giữ.

## Lỗi và sửa

P15 chỉ có combat_0 vì prepare_options thấy old writer CLOSED rồi fault trước
nhánh thay bridge đã stopped. [Before reproduction](../artifacts/5d1_operational_remediation_p16_v1/before_reproduction.json)
giữ source290: options{}, faulted=True, new_bridge_calls0.

Session nay đợi **bằng chứng retire đã hoàn tất** do finalizer publish, rồi mới
tạo successor qua global factory gate cũ. CLOSED đơn lẻ không đủ: phải bridge/
writer đóng và reap xác nhận, flush/accounting hợp lệ, không mất record hoặc
disabled collector/bridge. Chưa cleanup xong thì trả BASIC ngay với
SUCCESSOR_CLEANUP_PENDING; factory đang bận thì SUCCESSOR_FACTORY_UNAVAILABLE.
Expiry, active sink fault, unhealthy/unconfirmed cleanup và cap vẫn fail closed
cho reasoning; Farm/BASIC giữ quyền điều khiển hiện có.

prepare_options chỉ try-lock, không sleep/join/flush/IO. Stop method giữ AST;
Stop race trong lúc factory tạo bridge không giao options hoặc job mới cho
combat. Finalizer off-path chờ publication đang diễn ra rồi đóng mọi resource
đã sở hữu; không bỏ sót writer/worker được tạo trong race đó. Không đổi FarmRun
attempt charging, exclusive claim/no restart/resume hoặc global one-owner gate.

[After reproduction](../artifacts/5d1_operational_remediation_p16_v1/after_reproduction.json)
với inert healthy-retirement witness trả2options/new_bridge_calls1/faultedFalse.
Đây là fake rõ, không tự chứng minh real cleanup. Test riêng chạy **3generations
worker + writer thật offline**,3completed decisions/3timing sequences, closed/
flushed/reaped/accounting đủ cho mỗi generation. Không process game hoặc input.

## Diagnostics và admission

watermarks.session ghi fault đầu, stage, bridge combat_index, prepare_call,
bounded reason counters và tối đa32status transitions. Mỗi combat receipt ghi
bridge/selection/worker counters, last admission và collector counters. Ghi ở
background finalizer, dùng file receipt riêng hiện có, không ghi đôi trace hoặc
thêm polling vào UI. combat_index là thứ tự bridge của session, prepare_call là
thứ tự lần chuẩn bị; không giả nhận chúng là match ID. Raw timing vẫn có match/
turn/AutonomousSource. Shadow OFF không được dùng làm operational status.

Read span vẫn **100ms**. Admission phân biệt OBSERVATION_READ_SPAN_EXCEEDED,
OBSERVATION_CLOCK_INVALID, ADMISSION_BUSY và unsupported/unavailable. Rejected
current observation chặn offer cũ ở root/fresh/final, kể cả cùng board/source;
không dùng stale completed result khi try-lock không lấy được. Không thêm read,
hash hoặc solver ở admission. Một last-admission receipt nhỏ, counters/buffers
giữ bounded; timestamps từ observation có sẵn.

Budget log ghi preparation reason như COHORT_OR_CONFIG_CHANGED, NO_PROCESSING_BUDGET,
JOB_RATE_LIMITED hoặc worker fallback, cùng completed worker reason/disposition.
Completed RETAIN_BASELINE vẫn hợp lệ, khác unsupported/timeout/error. Same-source
job không resubmit/reset original deadline; config/source/timer changes vẫn veto.
Không đổi model/weights/BASIC để tạo override, không quota đổi nước.

## Source/provenance

Source290 P15 `10cc39c2e323cb697c0dea4c04b5c541ce4eee0b22342283996c54700126c62a`
→ current291 `a8aba6c01a3a5fa9eda6d46c1c7f84b4c1e577d080c4d015b0d68c0ebdac1638`.
[Frozen manifest/diffs](../artifacts/5d1_operational_remediation_p16_v1/final_test_source_manifest.json)
ghi **6existing changed +1new test**,284existing giữ byte:

- Production: reasoning_operational.py session lifecycle/receipt;
  reasoning_pilot.py admission veto/reasons.
- Offline qualifier dùng current PilotSelectionBridge checkpoint methods với
  inert owner + real finished worker reply; không bypass method mới bằng base
  adapter. Không tạo30,000worker chỉ để microbenchmark.
- Historical fixture thêm exact P16 before/after binding của3files, hard-pinned
  manifest và negative future-edit test. Hai historical package test suites
  dùng sealed P14 review trong temp root với source/native surfaces mock rõ.
- New test_reasoning_operational_lifecycle.py:18regressions cho lỗi thật.

[Boundary audit](../artifacts/5d1_operational_remediation_p16_v1/change_boundary.json)
prove reader/controller/BASIC/solver/entry/input/random/pacing/ACK/room/recovery,
base selector/timing collector và operational loader/deadline/authority AST giữ.
Strict finite-U loader và native calibration verifier **không nới**. Old P14
review bị reject cho current source; exporter không tự mint allowance từ source
chưa review. Exact source chain chỉ dùng offline test parity, không chuyển
historical native acceptance sang P16.

Development run đầu79tests có1failure/1error do các exact source gates cũ từ chối
source đã đổi; không runtime failure trong các new lifecycle/admission tests. Đã sửa test binding như
trên, giữ raw failure. [Focused115](../artifacts/5d1_operational_remediation_p16_v1/development_tests_02.log)
PASS trong94.576s. **Full regression2,244/2,244 PASS trong477.611s** trên cùng
source frozen; [raw](../artifacts/5d1_operational_remediation_p16_v1/tests_full_final.log).

## Fresh offline qualification

[Main qualification](../artifacts/5d1_operational_remediation_p16_v1/qualification_final/qualification.json):
**23/23gates PASS**,1,000warmup +5,000measured/path, frozen current source/host.

| Three current pilot checkpoints, ms | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| disabled | 0.0002 | 0.0002 | 0.0003 | 0.0134 |
| completed | 0.6789 | 0.9637 | 1.4103 | 8.9737 |
| timeout | 0.6736 | 0.9019 | 1.3529 | 2.1695 |
| error | 0.0471 | 0.0622 | 0.1060 | 0.3231 |
| fallback | 0.2860 | 0.3664 | 0.6880 | 1.1470 |

Thresholds p50≤1.5/p95≤3/p99≤9/max≤30ms giữ. Added mean CPU ba checkpoints
0.6875ms so disabled, dưới1.5ms. Host collector pipeline p50/p95/p99/max
0.2292/0.3063/0.5282/5.2365ms, dưới0.5/1/3/10ms.1,000Stop signals
max0.0207ms; worker reaped.60.00049s stress/154,399cycles/max1record/peak9,437B.
Five disabled controller traces và optional controller AST exact.

[Additional admission + checkpoints](../artifacts/5d1_operational_remediation_p16_v1/qualification_admission/qualification.json):
**7/7gates PASS**,1,000warmup +5,000measured/path; dùng actual current methods,
inert owner và real completed worker reply, không tạo thêm worker mỗi sample.

| Admission + three checkpoints, ms | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| admitted | 0.6856 | 0.8693 | 1.2088 | 8.9074 |
| span_rejected | 0.0530 | 0.0627 | 0.0882 | 0.4098 |
| clock_rejected | 0.0525 | 0.0634 | 0.0785 | 0.1262 |
| busy | 0.0530 | 0.0801 | 0.1200 | 0.4243 |

Mean CPU cao nhất0.709375ms, dưới1.5ms; rejected outcomes đúng ở cả3checks,
source giữ và worker reaped. Captured validation time chỉ isolate software cost,
không là deadline/live authority; raw24,000rows giữ. Hai phép đo completed đều
BASELINE_TOP_IN_TOTAL_ORDER/RETAIN_BASELINE, không gán lý do này cho P15 near tie.
Native R/U trong cả2qualification vẫn null; không mint selector/native allowance
hoặc activation mới từ các numbers này.


Qualification chỉ là software cost/cleanup với native fakes. Completed worker
RETAIN_BASELINE là outcome bình thường; không proof global optimum hoặc efficacy.
Không ép model/board thành override. Nhánh accepted override chưa có native
latency sample; không claim latency nhánh đó từ completed retention benchmark.

## Native timing còn thiếu và next

[Timing provenance review](../artifacts/5d1_operational_remediation_p16_v1/timing_provenance_review.json)
giữ7records P15:5root spans218.2233–233.3348ms vượt100ms;
Hmax405.3797ms/6of7vượt P11 descriptive164.429ms; full-tailmax3001.104ms dưới
R_op6455.8326ms. Observation bắt đầu trước existing provider poll, kết thúc
trước immutable admission; H từ decision exit tới final preflight. Không có
native substage timestamps để gán nguyên nhân cho reader/selector/OS cụ thể.
Không sửa reader hoặc nới100ms, không dùng phần reserve còn dư làm proof.

Không relabel P11/P15, không tự cập nhật native H/R hoặc reuse P14 allowance
cho source mới. Native U/transport/alignment **null UNKNOWN**, first exact input
NOT_MEASURED.16SWAP P15 không có reasoning timing vẫn UNKNOWN. Source changes
và sample H exceed cần review độc lập trước bounded successor activation.

[Final preservation](../artifacts/5d1_operational_remediation_p16_v1/verification_final.json):
3,528immutable parent artifacts,4game files,host,HEAD,ordinary preferences và
4existing real claims giữ byte. Một existing idle P15 UI log có append;
5,581,104byte prefix giữ đúng SHA8ea2a0fd… và được lưu riêng, không rewrite hoặc
coi append này là native evidence P16. Không mở UI/observer hoặc query game mới.
Không ghi game/V1/preferences thật, không build/version/Git, không live input/
request/claim/activation. Existing P15 consumed request không thể restart.


Next duy nhất **[P17 source/timing review OFFLINE](../prompts/5D1_P17_SOURCE_TIMING_REVIEW_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game hoặc live test; chưa tạo request/
claim/activation mới, chưa D1cap12/CAREFUL/Demon/Mega/D2. **STOP P16.**
