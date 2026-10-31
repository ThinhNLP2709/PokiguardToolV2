# 5E.2 — Đã hoàn tất nghiệm thu độ ổn định trong scope Demon/Khiên

Ngày chốt **31/10/2026 (Asia/Saigon)**. **RESULT: PASS STRONG — SCOPED TECHNICAL RELIABILITY.**
Parent5E.1 CLOSED / efficacy INCONCLUSIVE. Source REASONING7421293d…,
BASIC native782aba…, gameb12. Không thay default BASIC hoặc claim hiệu quả vượt BASIC.

User đã cấp tối đa25lượt, gồm5BASIC+20REASONING. Đã dùng đúng25, WIN25/25;
nhận thưởng/về phòng25lần,0read error/input safety/timeout/PASS/abort/recovery.
Phiên REASONING có47SWAP/27ACK/20terminal exclusions được chứng minh;
47completed jobs gồm46retention+1override thực sự gửi và WIN cùng turn.
Nước đổi ở M_12845693/turn7:175nộ trước nước, vùng Khiên3Kiếm thay nước Nộ BASIC.
Không suy kết quả phản thực của BASIC hoặc công thức damage từ một trường hợp.

20/20compute workers reaped,20bridges closed/healthy;255/255AIrecords written,
0loss. Job/ROOT/FRESH/FINAL đúng source/deadline, không accepted late result.
14component tail excess được shared guard250ms hấp thụ đúng contract, maxdebit51.3822ms;
0guard exhaustion/breaker/aggregate overrun. Compute p50/p95/max42.1425/82.1705/88.1213ms;
observation→executor return1004.3535/1202.3400/1227.7082ms, N47 descriptive.

Resource live: family sampledpeak114.238MiB, mainprivate81.578MiB, retained
median growth6.256MiB trong khoảng12phút; toànmain activeCPU5.860hostpp.
Các số live là absolute/descriptive, **paired added AI CPU/memory NOT_MEASURED**,
không dùng mean có idle để che tải hoặc gọi đó là AI overhead. Fixed30min/
900jobs,490fault trials,disabled/component/logSLO dùng evidence offline có scope;
R1/worker/logger giữ bytes, không đổi nhãn source offline thành runtime mới.
Live fault/Stop/emergency/re-entry chưa gặp giữ NOT_OBSERVED theo bounded protocol,
không thêm trận ngoài25 để tìm mẫu. U/actualenergyUNKNOWN, efficacyINCONCLUSIVE.

[Closeout đầy đủ](../artifacts/5e2_live_20261029/closure_20261031/REPORT.md),
[machine-readable closure](../artifacts/5e2_live_20261029/closure_20261031/closure.json),
[hash manifest](../artifacts/5e2_live_20261029/closure_20261031/evidence_manifest.json),
[scope đóng băng](../artifacts/5e2_live_20261029/closure_20261031/PACKAGING_SCOPE.md).

**Exactly one next: [5F.1 — Packaged acceptance](../prompts/5F1_PACKAGED_ACCEPTANCE.md),
SELECTED ONLY / NOT EXECUTED. STOP E2.** Không build/version/Git/release hay liveF1 trong lượt chốt.
Chỉ experimental opt-in Solo Demon/Shield4/cohort trên có currentb12 reliability;
không mở Coop/Búwin/Dinosaur/R2/model hoặc quảng bá các pilots lịch sử là current acceptance.

---

## Báo cáo và trạng thái lịch sử trước khi đóng live

Các dòng PARTIAL/live-pending phía dưới mô tả thời điểm cũ; trạng thái hiện tại ở trên.

# 5E.2 — Offline hoàn tất, live còn pending

**Cập nhật30/10/2026:** user đã kích hoạt live25=5BASIC+20REASONING.
5BASIC đã WIN5/5,9SWAP/4ACK/5proved terminal exclusions,5confirm/return,
0read/input-safety/timeout/PASS/abort/recovery. Đã mở20REASONING slots6–25,
manual Start, source7421293d… với admission E2 setup riêng; gameplay/flow/
worker/logger byte-exact so với native source782aba…. Chưa tiêu slot reasoning
khi chuẩn bị, chưa E2PASS/F1/build. [Handoff/evidence hiện tại](../artifacts/5e2_live_20261029/REASONING20_HANDOFF.md).
Phần dưới giữ nguyên báo cáo offline lịch sử; “live0/chỉoffline” chỉ đúng tại mốc đó.

Ngày hoàn tất **2026-10-29, Asia/Saigon**; bắt đầu offline ngày28/10.
Parent5E.1 đã CLOSED: TECHNICAL PASS / EFFICACY INCONCLUSIVE.
**RESULT: PARTIAL — OFFLINE PASS / LIVE PENDING.** Chưa đủ full5E.2,
chưa chọn5F.1. Người dùng chỉ yêu cầu offline; live0attempts.

## Phạm vi và nguồn

Sourcev1.2.10, fingerprint `dbbe59fbdf79236fe3dc11256ce7931a4b99fe53b4542aedc630de7ae1e35ebd`. HEAD/branch giữ nguyên
theo [git identity](../artifacts/5e2_offline_20261028/git_identity.json).
GameAssembly đọc file readonly vẫn b12/51eaeff7…; không attach process, mở UI,
đọc state game, capture, input, tạo request/claim, sửa prefs thường hoặc checkpoint.
Không build/version/commit/push/tag/release. ZIP1.2.10 cũ giữ nguyên.

E2 chuẩn bị riêng Solo Lieyun77/Demon Aegis thường/nội tại Khiên/4Kiếm hiệu dụng,
sàn2ôKiếm, không tiến hóa, R1 experimental opt-in. BASIC giữ default; không claim
AI tốt hơn. Simple/Careful/HT7/Mega giữ technical pilot lịch sử theo đúng scope;
Coop/Bú win reasoning và shadow unsupported; Khủng long reasoning ngoài scope;
R2/model không được bật. Không mượn authority/timing b10 hoặc mở lại E1.

## Sửa offline và bảo toàn flow

Tái hiện TypeError trước sửa: hai caller `_passive_geometry` thiếu `target_gem`
làm setup evaluator B3 không chạy. Truyền Viên mục tiêu từ immutable settings,
legacy default Khiên; guard cascade passive cũng dùng đúng target. Không dùng
ordinary residual cho passive/cascade chưa mô hình hóa, không mở R2 promotion.
33test refinement cũ PASS;4test bổ sung kiểm5target, geometry qua public evaluator,
legacy Khiên và chặn residual cascade khác Khiên.

Chỉ `reasoning_refinement.py` đổi và thêm `test_reasoning_reliability.py`.
362Python files cũ byte-exact, gồm BASIC/solver/controller/
provider/read/capture/executor/QTE/ACK/lifecycle/room/re-entry/Stop/input random.
364AST/compile PASS. Sửa dừng nhầm Mega trước E2 được giữ nguyên,
không gộp thành thay đổi suy luận. Diff và manifests nằm trong evidence.

## Fault, deadline và diagnostics

490trials dùng current warm worker:270compute/control,100Stop,120writer faults.
Mỗi variant lỗi compute/log30trials; gồm crash/hang/corrupt/oversize/nonfinite/
binding mismatch/exception, queue đầy, denied/diskfull/hang/crash writer.
Tất cả child reaped; before-input giữ BASIC valid, after-input/invalid source
trả NONE. Không input game hoặc thay pending/ACK owner.

| Boundary | p50 / p95 / p99 / max, ms |
|---|---|
| Known fault → BASIC, N270 | 0.023 / 0.0361 / 0.0504 / 0.0559 |
| Stop signal, N220 | 0.0122 / 0.0275 / 0.0348 / 0.0576 |
| Cleanup ngoài action/Stop, N390 | 4.3422 / 14.9861 / 16.6081 / 29.1378 |

Micro3×10000mẫu/mode, warmup1000riêng: disabled/submit/enqueue shared/full/
lockbusy, prepared wire validation, ready completed R1, known fault và idempotent
Stop đạt A3 component SLO. Giữ raw tails, không gọi samplemax là future bound.
Không promote separate sink; shared namespace/filter policy giữ nguyên.

Ready Demon fixture hoàn tất có thể RETAIN_BASELINE; đây không phải timeout/error.
Harness B4 cũ giả định ready luôn override đã fail và được giữ trong artifacts;
harness E2 kiểm đúng completed reply/target, không ép đổi nước để làm test PASS.
Không sửa production runner hoặc nới SLO.

Qualification selector100cycles×6paths và real warm worker/writer PASS;
final-source max cả ROOT/FRESH/FINAL là2.1127ms,loss0.
Qualification trước bổ sung test có max12.607ms, cũng được giữ; không cherry-pick
để giảm reserve. Snapshot/cohort/timer ở đây là SYNTHETIC; không cấp live authority.

## Resource soak đủ30phút

Current R1 WarmIsolatedRunner, Demon/Shield synthetic, interval2s, budget4s;
không chạy refinement. Elapsed1800.015s,
900jobs; compute processes/reaped
1/1.

| Chỉ số | Đo được |
|---|---:|
| Peak added private main | 3.430MiB |
| Peak sampled added private total | 40.895MiB |
| Median retained growth, last5min vs first5min sau warmup | 0.000MiB |
| Main CPU, total-host normalization | 0.0787pp |
| Log eligible/enqueued/written | 901/901/901 |
| Dropped/failed/discarded | 0/0/0 |
| Queue high records/bytes | 1/8982 |

Worker/logger cleanup và finalflush PASS. Observer chỉ query own/known child PIDs,
sample20ms có blindspot peak ngắn hơn. CPU là absolute harness-main upper bound,
không paired game delta. Raw streaming, windows bounded; growth không do observer
giữ toàn history. R1 modules đo giữ nguyên bytes; refinement/test thay sau lúc
resource bắt đầu không thuộc path refinement=False và được phân biệt trong audit.

Fresh BASIC disabled probe60s/600trials:0AI module/thread/job/file/extra read/
capture; added private1.203MiB,mainCPU0.7834pp,đạt bound. Đây là offline fake IO,
không là actual game overhead hoặc latency guarantee.

## Regression và giới hạn

Chạy46modules/980cases, gồm3test target ở thời điểm broad run; supplement cuối
4test target đã PASS.30modules/737cases PASS hoàn toàn.16modules còn
26failure events và24error events; mọi event đó tái hiện đúng trên runtime
trước E2, không có event mới chưa giải thích. Không gọi toàn suite PASS.
Nhóm tồn tại trước gồm historical source/hash ancestry, config schema/metadata
và calibration artifacts của source cũ; không đổi assertion hoặc production
gate để ép green. Các checks này không cấp compatibility cho current native.

Functional coverage có current controller/fake input/ACK, fallback/Stop/stale/
after-input, actual worker/writer successors, no overlap/claim reset, breaker,
rotation/retention/counters, source/cost/session gates. Native fault/PASS/QTE/
re-entry/resource/latency trong E2 hiện NOT_OBSERVED; không suy từ offline.

## Gate live tiếp theo — cùng5E.2

Đã freeze inert draft25attempts: **BASIC5 + REASONING20**. Slots1–3 đo native
BASIC trong5control, không thêm3ngoài25. H/I/U đều null; chưa tạo request/claim,
không tái dùng E1. Nếu3đầu thiếu ACK, chỉ dùng slots4–5 BASIC còn lại; sau5vẫn
thiếu thì PARTIAL và dừng. Chỉ sau current b12 timing/account/loadout/source/
config/host review mới lập E2-specific admission cho20REASONING.

Runtime activation/admission còn phụ thuộc native evidence; draft không giả
request sẵn dùng. Native gate hoặc scope thiếu không được bypass bằng fixtures.
Caps tính cả failed entry/abort/Stop; không auto retry/bù/resetcap. No superiority
claim; E1 efficacy INCONCLUSIVE và BASIC default giữ nguyên.

**Exactly one next: cùng5E.2, user kích hoạt bounded live và chuẩn bị phòng
Lieyun77/Demon Aegis ăn Khiên; bắt đầu bằng BASIC control trong cap25. STOP ở
offline milestone.** Không mở5F.1 hoặc sinh chuỗiP.

[Runbook](../artifacts/5e2_offline_20261028/RUNBOOK.md),
[frozen draft](../artifacts/5e2_offline_20261028/live_draft/manifest.json),
[verification/SLO/raw references](../artifacts/5e2_offline_20261028/verification.json),
[regression](../artifacts/5e2_offline_20261028/regression/results.json),
[before/after failures](../artifacts/5e2_offline_20261028/baseline_failures/comparison.json).
