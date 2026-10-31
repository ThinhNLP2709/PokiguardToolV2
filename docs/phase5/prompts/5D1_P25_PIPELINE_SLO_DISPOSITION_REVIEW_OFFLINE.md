# 5D.1-P25 — Review contract của pipeline gate và qualification disposition

**SELECTED ONLY / NOT EXECUTED. FILE-ONLY.** Chưa cần mở game.
Đọc AGENTS, STATUS/ROUTER/capability, EXECUTION_CONTRACT,
[P24 report](../reports/5d1_p24_report.md),
[decision](../artifacts/5d1_diagnostic_host_binding_p24_v1/decision.json),
[raw recomputation](../artifacts/5d1_diagnostic_host_binding_p24_v1/raw_recomputation.json),
[P22 boundary map](../artifacts/5d1_pipeline_tail_review_p22_v1/pipeline_boundary_map.json),
spec5A.3, P9 accepted operational decision, P10/P12 timing contracts và
P18/P21 raw qualifications. Không chỉ đọc summary rồi nới gate.

## Entry và câu hỏi

P24 repair/fake12cases/one diagnostic invocation đạt integrity scoped:
19,000records/10.9656352s; currentA max1.1448ms, B1.4526ms, profile1.4458ms.
Không tái hiện historical11.8417ms; nguyên nhân vẫn UNKNOWN. CPU quantized
15.625ms, profile0GC events, A/B medians đổi dấu. Không đủ căn cứ sửa runtime
hoặc gọi historical spike là noise. Source297 bab0145d…/host giữ.

P21 **31/32FAIL**, current absolute pipeline max10ms còn nguyên. P24 diagnostic
khác harness/protocol không thay qualification hoặc accepted S/R/live.

Câu hỏi cụ thể: **absolute full collector max10ms đang enforce contract nào,
có đúng boundary/category của operational opt-in không, và disposition nào
có căn cứ để xử lý failure mà vẫn giữ BASIC/flow/deadline safety?**
5A.3 shadow SLO nói paired added action critical path; P10/P12 có absolute
collector gate. Khác scope là câu hỏi review, chưa chứng minh gate sai.

## Phạm vi

Chỉ đọc file/recompute dữ liệu đã có và ghi docs/review artifacts. Không
src/tools/tests/harness edits, tests/benchmark/qualification/diagnostic/soak
rerun, game attach/read/capture/input, UI/observer/worker/network, preferences/
claims/game files writes, build/version/Git. Stop đúng P25.
Không replay P24, dùng diagnostic dưới10ms làm PASS, pool populations, bỏ
warmups/outliers hoặc nói source/host same đồng nghĩa evidence interchangeable.

## Công việc

1. Verify P24 final/frozen manifests, raw/receipts/coverage19,000, P23 faults
   và original P21 failure. Snapshot current source297/host/parents/6claims/
   prefs/game4files/HEAD; preserve external P23 UI closure/current settings.
   Old full2316PASS chỉ kiểm file/footer, không chạy tests.

2. Truy exact origin max10ms từ spec5A.3, P9 accepted contract, P10 implementation,
   P12 addendum và P13/P18/P21 qualifier/validator. Lập boundary/category ledger:
   disabled/shadow added cost, compact enqueue, ready validation, active bounded
   compute, full collector telemetry, Stop và native H/I/S/R. Phân biệt proposed,
   accepted implementation, local sample max gate và future hard bound.
   Không áp shadow budget4–6s exemption lên toàn diagnostics hoặc bỏ timing
   guard bằng cách đổi tên category.

3. Map actual collector stages và production call placement: setup ngoài
   microbench, decision/start/preflight/finish/encode/enqueue, internal
   executor-return marker vs outer end, same state vs fresh state, command
   waits/guard/margin/reserve accounting và component monitor. Chỉ dùng source/
   evidence, không đổi runtime. Chỉ ra double-count/omission nếu chứng minh,
   không tự trừ guard/reserve hoặc lấy profile59.35% làm proof optimization.

4. Chọn đúng một disposition có căn cứ:

   - Nếu max10ms là applicable intentional gate và chưa có independent
     correction rationale: giữ failed qualification và nêu remediation cụ thể
     với phạm vi/evidence cần thiết; không measurement loop mơ hồ.
   - Nếu boundary/contract mismatch được chứng minh: soạn **successor scoped
     contract proposal accepted=false**, rationale từ original requirements,
     decision/input safety envelope và ownership của chi phí. Không chọn
     threshold chỉ để bao11.8417ms, bỏ max, đổi percentile hoặc coi outlier
     OS noise. Phải chỉ rõ strict/legacy gates giữ, intended opt-in scope,
     data/units/source pins, original failure giữ và fresh source/qualification/
     review riêng sau này. Nếu approval cần thiết theo scope thì chỉ hỏi khi
     đã có proposal cụ thể reviewable; không tự grant activation.

   Không implement SLO/validator/optimization hoặc chạy fresh qualification
   trong P25. Không derive accepted S/R từ diagnostic/current failed data;
   native U/transport/alignment null. Giữ no-second-input/Stop/ACK/source/
   ownership, strict finite-U/root250/final100/one-t0/deadline/budget/guard/
   margin. Suy luận có thể chọn BASIC, không quota override.

## Output và STOP

Viết `reports/5d1_p25_report.md`, contract provenance/boundary/accounting ledger,
UNKNOWN và đúng một decision/proposal accepted=false nếu có; final preservation.
Report nguyên P21 failure/P24 scope, không relabel qualification.
Update STATUS/README/ROUTER/capability/index. Chọn **exactly one next prompt**,
không tự thực thi hoặc mở live. Chưa cần game; không resume P19/general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2/Phase5 completion. **STOP P25.**
