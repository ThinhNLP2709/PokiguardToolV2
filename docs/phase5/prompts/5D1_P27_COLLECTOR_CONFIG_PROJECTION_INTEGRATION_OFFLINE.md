# 5D.1-P27 — Tích hợp config projection vào collector, offline

**SELECTED ONLY / NOT EXECUTED.** Chưa cần mở game.
Đọc AGENTS, STATUS/ROUTER/capability, EXECUTION_CONTRACT,
[P26 report](../reports/5d1_p26_report.md),
[integration proposal](../artifacts/5d1_config_serialization_proof_p26_v1/integration_proposal.json),
[candidate proof/cost](../artifacts/5d1_config_serialization_proof_p26_v1/component_recomputation.json),
P25 gate/accounting ledgers và P21 source/root-policy qualification history.

## Entry và mục tiêu

P26 exact uncached PolicyConfig projection đạt118parity/7guard cases và
one12,000raw component run. Four paired median savings≥0.0533ms so với
target0.010ms; candidate p95=0.0394ms≤legacy0.1157ms. Chưa runtime integration.
Không suy whole-pipeline benefit hoặc historical tail fix. P21 vẫn31/32FAIL
ở11.8417ms>max10ms; original raw giữ nguyên.

Tích hợp đúng conversion đã prove vào **opt-in successor operational
collector** và verify source/costs mới, bảo toàn BASIC và toàn flow hiện có.
Không dùng cải thiện component để skip qualification hoặc hạ reserve.

## Scope và invariants

New V2 source/tests/tools/docs chỉ theo các mục dưới đây. Không đổi global
jsonable/BASIC/solver/PlayStyle/model/weights, provider/memory/screenshot/
controller read order, input/executor/pacing/ACK/result/room/recovery/Stop.
Không game attach/read/capture/input, UI/observer/live launch, network/game
files/preferences/claims writes, build/version/Git. Tests dùng native fakes.
Không auto-activate pilot hoặc resume P19. Stop đúng P27.

## Công việc

1. Verify P26 final/frozen/candidate/proof/raw manifests, source297 bab0145d…/
   host/parents/6claims/current prefs/game4static hashes/HEAD. Archive exact
   before source/docs. P21 failure và P23/P24 history giữ. Không dùng HEAD
   đơn lẻ hoặc generic allowlist để map evidence cho source mới.

2. Tái dùng candidate projection của P26, cùng18-field/type guard/fallback;
   không tạo serializer khác hoặc cache config/digest. Chỉ successor reviewed
   operational authority với component_monitor dùng projection mới. Legacy/
   no-authority/v2/v3 giữ generic branch/output/exception semantics.

   Thay config projection **inline tại `policy_sha256=digest(...)` trong
   collector.start**, đúng evaluation order cũ sau witness/source snapshot và
   trước preflight_start timestamp. Không precompute trên state cũ, move marker,
   bỏ state hash hoặc reuse witness. Giữ full current config mỗi call.
   Không đổi canonical_json/digest, root metadata/limits, monitor/encode/
   enqueue/breaker/on_fault/Stop/fallback hoặc sinh input thứ hai.

3. Source binding successor riêng phải verify exact P21→new source pairs,
   candidate/helper và allowed `start` expression. V4 source297 review giữ
   nguyên, deliberate reject actual new source; không sửa approved old hashes
   để làm new source pass hoặc weaken strict/legacy consumer. Nếu cần schema/
   exporter mới thì chỉ cho exact reviewed successor, không generic exemptions.
   Fixture ancestry thêm exact before/after layer có SHA; invocation cache chỉ
   trong fake historical fixture, không persistent verify cache.

   Native P11/P15/P19 cohorts/timestamps/provenance giữ riêng. Review rõ tác
   động vào measured H vì config conversion nằm trước preflight_start; output
   parity/component speedup không tự chứng minh native timing source binding.
   Reuse native cost basis chỉ khi exact scope/source proof đủ; thiếu thì
   native binding PENDING và không draft/live, không tự chạy game để bù.

4. Meaningful checks: inherited P26 full parity corpus; real collector với
   fake clocks trước/sau có exact payload/digest/field presence/fault behavior;
   legacy branch; config replacement/same-object fake mutation/unknown shape/
   nonfinite errors; source/witness/input parameter changes; fake-controller
   read/input/ACK parity, AI-only faults và no-second-input; existing session
   lifecycle/Stop/cleanup paths. Test source-review tamper và original-v4 reject.
   Không dùng test mirror implementation thay cho independent legacy oracle.

   Hoàn tất focused tests/fixes rồi **freeze final complete source** trước
   full regression và performance. Full suite phù hợp integration boundary.
   Source fixture/ancestry preflight phải kiểm sẵn để không lặp lại P21
   traversal/pre-measurement failures. Giữ all failed/repair logs.

5. Sau functional/source proof đạt, đúng **một fresh qualification** trên
   final source/host: actual successor admission+3checkpoints/root250/final100,
   current collector/helper+authority+monitor, all existing32gate meanings và
   latency/CPU/pipeline/Stop/stress thresholds giữ nguyên. Pipeline max≤10ms;
   không nới threshold, đổi mode, bỏ warmup/outlier hoặc lặp để tìm PASS.
   Giữ đủ61,000raw/51,000measured, source manifest, CPU/outcomes/Stop/cleanup/
   stress receipt và all failure evidence. Không rerun P26 microbenchmark.

   Recompute actual new S/R theo nguyên envelope H/I+C+pipeline+W3120+G250,
   margin100/one-t0/default4000/cap6000/minimum-window50ms. Candidate benefit
   không cho giảm native basis/guard hoặc miễn gate. Nếu bất kỳ gate fail,
   accepted S/R null, draft/exporter phải reject; report PARTIAL, không sửa
   tiếp source hoặc đo lại sau khi thấy performance FAIL trong P27.

6. Nếu và chỉ nếu all cost/source/native-binding requirements đủ, có thể tạo
   source-only successor draft **accepted=false/live=false**, request/run/
   expiry/claim null hoặc false. Không activation/manual Start/game prep trong
   P27. Nếu thiếu chỉ ghi readiness/UNKNOWN, không fabricate approval.

## Output và STOP

Viết `reports/5d1_p27_report.md`, exact source/diffs/native compatibility,
tests/freeze/raw/recomputation/readiness, original failures và final preservation.
Không gọi component PASS hoặc tests PASS là qualification/native/live PASS.
Strict finite-U/native U/transport/alignment null semantics giữ; root250/
final100/one-t0/deadline/source/ownership/Stop/ACK/no-second-input giữ.
Reasoning có thể giữ BASIC; không quota override hoặc hiệu quả thắng giả.

Update STATUS/README/ROUTER/capability/index; chọn **exactly one next prompt**,
không tự thực thi, mở live, general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc
đóng Phase5. **STOP P27.**
