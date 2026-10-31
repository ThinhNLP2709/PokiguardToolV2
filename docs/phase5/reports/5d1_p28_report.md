# 5D.1-P28 — Qualification failure disposition, file-only

2026-10-16 (Asia/Saigon). **REVIEW COMPLETE / KEEP FAILURES AND MAX10MS /
PARTIAL D1.** Không sửa code hoặc đo mới.
[Prompt](../prompts/5D1_P28_QUALIFICATION_FAILURE_DISPOSITION_OFFLINE.md),
[decision](../artifacts/5d1_qualification_disposition_p28_v1/decision.json),
[parent P27](5d1_p27_report.md).

## Kết luận

P27 vẫn **31/32FAIL**, nguyên index2612=10.4014ms>max10ms.
P21 vẫn **31/32FAIL**, nguyên index2789=11.8417ms. Không có bằng chứng đủ
để xác định cause của hai mẫu, chọn optimization tiếp hoặc đổi ngưỡng.
Không bỏ outlier/đổi warmup/percentile substitute/unchanged qualification rerun.

Chọn đúng một bước tiếp: **P29 current-source context attribution diagnostic**,
chỉ được chuẩn bị prompt/protocol ở P28, chưa tạo harness hoặc thực thi.
Nó thêm observation từng stage/gap/GC trên source301 sau đúng call/phase
prefix của qualifier; không là phép đo lại để lấy PASS. Nếu không tái hiện
long sample thì kết luận INCONCLUSIVE và dừng, không tự lặp.

Accepted S/R null, native H binding PENDING, không draft/activation/request/
claim/live. Chưa cần mở game. BASIC/PlayStyle, read/input/ACK/room/Stop và
preferences giữ. Không thêm quota đổi nước; giữ BASIC là kết quả bình thường.

## Raw/gate review và giới hạn chứng cứ

[Recomputation](../artifacts/5d1_qualification_disposition_p28_v1/qualification_raw_review.json)
đọc lại **61,000raw/51,000measured mỗi run**, không pool hai populations;
giữ toàn warmup/outlier/index/CPU/raw pins/root250/final100/source/host.
Mỗi run có đúng1/5000measured pipeline sample>10ms, không warmup nào>10ms.

| Dataset | Source | Pipeline p50 | p95 | p99 | Max | Gate |
| --- | --- | ---: | ---: | ---: | ---: | --- |
| P21 | 297/bab0145d… | 0.2725ms | 0.4227ms | 0.6878ms | **11.8417ms** | 31/32FAIL |
| P27 | 301/48eaf48d… | 0.2407ms | 0.5295ms | 0.7430ms | **10.4014ms** | 31/32FAIL |

Đây là hai runs/source khác nhau, không là paired causal experiment hoặc
whole-pipeline speedup proof. Median thấp hơn nhưng p95/p99 cao hơn cũng
không đủ quy thành improvement/regression của một component.

25gate booleans được tái tính từ raw + persisted outcomes/stress summaries/
source/AST;7booleans trace/worker/historical-source assertions giữ nhãn riêng.
Latency/CPU/Stop quantiles và means được tính lại từ samples. Outcome summaries
là representative branch values; source của qualifier assert outcome mỗi
iteration, raw timing rows không lưu từng full outcome. Stress là aggregate
receipt, không per-cycle evidence. Không gọi toàn bộ25 là independently observed
native outcomes. [Controller AST](../artifacts/5d1_qualification_disposition_p28_v1/controller_AST_review.json)
được parse/compare lại mà không thực thi controller. Full2,343tests PASS chỉ
kiểm existing footer/result/source pins; P28 không chạy test lại.

Pipeline max10ms và checkpoint/admission max30ms là hai gate riêng.
P25 đã xác nhận max10ms là policy intentional, không bị budget4–6s hoặc shadow
SLO thay thế. Không numerical rounding10.4014→10 để làm PASS.

## Thiếu gì và vì sao P24 chưa trả lời được

[Evidence gaps](../artifacts/5d1_qualification_disposition_p28_v1/evidence_gap_review.json)
và [source/accounting map](../artifacts/5d1_qualification_disposition_p28_v1/source_accounting_review.json)
pin15AST/line references. P21/P27 pipeline raw chỉ có index/warmup/ms,
P27 thêm projection policy; không absolute/stage/GC/CPU endpoints hoặc event
bytes cho chính failed sample. Không thể suy chúng hồi tố từ mean/profile khác.

P24 có19,000raw/102,000spans nhưng chạy source297, A/B6000+6000 rồi mới profile
6000. Nó không chạy real offline worker +30,000checkpoint +24,000admission
+1,000Stop/reap trước pipeline như qualifier. Hai bên có **prefix khác nhau**;
chưa biết allocation/GC/retained objects khác ra sao hoặc khác biệt đó có làm
chậm không. Không gọi prefix/GC là cause đã được prove.

P24 profile không có sample>10ms và0GC callbacks chỉ trong profile window.
CPU durations nhảy0 hoặc15.625ms dù declared resolution100ns: không đủ để
lấy wall−CPU suy descheduling. `start`59.35% ordinary instrumented cost là
concentration, không tail attribution. P26 prove projection benefit riêng
0.0533–0.0535ms/pair; P27 đã tích hợp đúng hàm nhưng vẫn có một tail sample.
Không có căn cứ tiếp tục giảm một component khác chỉ vì đứng đầu profile.

## Bước kế được giới hạn cụ thể

[Proposal](../artifacts/5d1_qualification_disposition_p28_v1/next_step_proposal.json)
và [options](../artifacts/5d1_qualification_disposition_p28_v1/disposition_options.json)
đã chuẩn bị, accepted=false/implemented=false. P29 thêm các observables:

- Source301 actual successor projection/authority/monitor; giữ phase/call
  prefix55000iterations trước6000instrumented pipeline samples. Một existing
  CPU worker được bounded/guarded/reaped, không game/native input.
- Absolute stage/gap endpoints, callback GC spans xuyên prefix/pipeline,
  exact phase/outcome/retained-state counters; riêng projection subspan mới.
  Giữ prior17spans và thêm projection thành18, không cộng inclusive hai lần.
- Empty1000reference có toàn18-span nesting, thay vì một wrapper. Nó không
  là correction để trừ chi phí hoặc tạo SLO PASS.

Fixed62000raw=55000prefix+6000profile+1000empty;1000warmup/5000measured
pipeline,108000raw spans. Một invocation/cap180s/GCcap20000/raw≤128MiB,
no retry/GCforce/disable/affinity/priority/threshold change. Validate guards/
fake-clock correctness/source/host/AST/cleanup trước rồi mới freeze harness
và thực thi một lần ở P29. P28 chưa tạo harness hoặc đo các số này.

Same call schedule **không** chứng minh identical allocator/GC/scheduler
history; instrumentation/preallocation/IO làm thay context. Diagnostic chỉ
thêm thông tin vị trí/correlation ở **sample mới**, không biết hồi tố cause
của sample2789/2612. Nếu không thấy≥10ms thì NOT_REPRODUCED, không tự đo tiếp.
Nếu thấy thì vẫn không thành qualification hoặc cho phép bỏ safety checks.

## Native H và accounting là blocker độc lập

[Native review](../artifacts/5d1_qualification_disposition_p28_v1/native_binding_review.json)
giữ P11 source28426returns/20anchors, P15 source2907returns/16missing,
P19 source29430returns/3attempts/108durable events riêng. Historical maxima
từ pinned reviewed interval rows/P19copied raw vẫn H405.3797/I2972.325ms;
không rewrite timestamp hoặc coi là source301 native calibration.

Projection ở trước preflight marker thuộcH; direct-runtime read/executor
thuộcI; monitor/encode/enqueue sau return marker vẫn trong full pipeline S.
Qualifier giữ3hashes, production caller dùng identity hash đã có; không bỏ
hash thứ3 để tìm PASS. Setup ngoài interval, raw.write ngoài marker; later
stress xảy ra sau pipeline nên không là prefix cần replay.

Giữ deliberate conservative overlaps:

```text
S = max(non-disabled checkpoint/admission maxima) + full pipeline max
R = max(action floor,1000,H + I + S + W3120 + G250)
D = min(t0+B,t0+raw_remaining−R−M), M100, B4000/cap6000/floor50
```

P21S24.4372/R6772.1419 và P27S24.2636/R6771.9683 chỉ descriptive.
Current accepted S/R/native basis null. Source change tự nó không chứng minh
cần live mới: conservative reuse chỉ có thể được review sau exact path/scope/
host/build/cohort/input/cost coverage và valid successor schema/loader. Khi
không map hoặc cover được H/I changes mới cần separately authorized native
calibration. P28 không approve reuse, không yêu cầu mở game để vượt cost FAIL.
U/transport/alignment vẫnnull/UNKNOWN, strict finite-U consumer giữ nguyên.

## Preservation và STOP

P271190artifact+7document pins, frozen/review/raw, P212344/P2438/P2517/
P2636artifact pins được verify. Source301/actual host/HEAD, toàn8,948parent
artifacts,6claims/current prefs/4static game hashes và idle UI prefix giữ.
Không code/tests/harness/measurement/game/UI/input/network/build/version/
Git/preference/claim changes. [Final verification](../artifacts/5d1_qualification_disposition_p28_v1/verification_final.json)
và [manifest](../artifacts/5d1_qualification_disposition_p28_v1/final_artifact_manifest.json).

Next duy nhất **[P29 context attribution diagnostic OFFLINE](../prompts/5D1_P29_CONTEXT_ATTRIBUTION_DIAGNOSTIC_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần game; không resume P19/general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc đóng Phase5. **STOP P28.**
