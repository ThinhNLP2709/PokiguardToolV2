# 5B.2 report — Adaptive utility planner offline

Ngày: **2026-10-09 (Asia/Saigon)**.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP / PARENT / MODE: 5B.2 / 5B.1 / OFFLINE ONLY
RESULT: PASS STRONG — ONE-STEP OFFLINE COMPONENT GATES ONLY
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
SOURCE VERSION: v1.2.4 baseline + new offline-only components
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
HEAD TREE: b74139ea0f22ca4d6e08b06bbeb977bba68a1971
BRANCH: codex/phase3a2-board-repair
RUNTIME / BASIC / SOLVER / PROVIDER / EXECUTOR CHANGES: NONE
NEW CODE: 1 pure module +1 offline scenario/benchmark CLI +1 focused test file
GAME ATTACH / LIVE INPUT / PRODUCTION WIRING / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION BUMP / RELEASE: NONE
NEXT: 5B.3 OFFLINE — NOT_EXECUTED
STOP: 5B.2
```

## 1. Entry và phạm vi

Người dùng yêu cầu “tiếp tục đi” sau B1 closure. Entry:
[5B.1 PASS STRONG](5b1_report.md), A1/A2/A3 specs chốt ở docs, đúng
[prompt5B.2](../prompts/5B2_OFFLINE_ADAPTIVE_UTILITY_PLANNER.md).
Đã đọc AGENTS/status/router/execution contract, research/spec/scenario/dataset
và B1 implementation liên quan. Không triển khai B3 hoặc production adapter.

Pure planner nhận immutable snapshot và incumbent; all legal swaps từ existing
simulator, không solver mới/top-K/setting filter. Evidence-aware quantities,
context weights, utility bounds, total order, robust margin và retention có
explanation/version. No read/capture/input authority hoặc IO trong planner.

Unrelated/prior work giữ nguyên: tracked docs CURRENT_STATE, DECISIONS,
BASIC/Demon/gameplay policy đã modified trước entry; untracked Phase3/,
combined baseline/handoff pack, phase5/, canonical reasoning policy và5 B1
code/tool/test files. Không reset/checkout hoặc ghi đè binary/package v1.2.4.

## 2. Files và fingerprint

New code/tool/test:

- [reasoning_planner.py](../../../src/pokiguard_v2/reasoning_planner.py).
- [evaluate_reasoning_planner.py](../../../tools/evaluate_reasoning_planner.py).
- [test_reasoning_planner.py](../../../tests/test_reasoning_planner.py).

New evidence/docs:

- [Coverage/input contract](../research/5b2_coverage_and_inputs.md).
- [Scenario inputs](../artifacts/5b2_adaptive_utility_v1/scenario_inputs.jsonl),
  [scores/explanations](../artifacts/5b2_adaptive_utility_v1/scenario_scores.jsonl).
- [Verification/benchmark](../artifacts/5b2_adaptive_utility_v1/verification.json).
- [Targeted healthy setup unsupported record](../artifacts/5b2_adaptive_utility_v1/healthy_setup_unsupported.json).
- [Artifact SHA-256 manifest](../artifacts/5b2_adaptive_utility_v1/manifest.json).
- Report này.

Updated7 coordination/canonical pointers: STATUS, ROUTER, README, ROADMAP,
PROMPT_INDEX, reasoning_gameplay_policy, CURRENT_STATE. Tổng17 paths của B2:
**10 new paths**
(3 code/tool/test +2 docs +5 artifacts) và **7 updated coordination docs**.
Không sửa historical A/B1 reports/specs/datasets hoặc existing runtime files.

SHA-256 canonical sorted path→hash map của3 B2 code/tool/test files:
`fc4fb33ba5f544a08b847ea4971c671d36b605a3f1dff7be6cca3f1ef104498e`.
Individual hashes/dependency hashes trong verification. **9/9** B1 hashed
code/dataset/event files giữ nguyên. Core simulator/Demon hashes vẫn:

- simulator: `a26fe7213d30a8b61440f91a286b2469f63bb2a56008dfeb891b025193324fbd`;
- Demon geometry: `46e4468ff0e860dbcfde9667028fd0bcd49f4da85c3a4cf8fab411d5eadae301`.

HEAD không đổi; phải đi cùng worktree fingerprint, không suy new code đã commit.

## 3. Cơ chế R1 và ví dụ chống cứng nhắc

Utility `5b2.one_step.v1`, feature `5b2.features.v1`, scoped input model
`5b2.scoped_inputs.v1`; full config/version hash có trong từng decision.
Starting A2 weights/bonus12/normalization8/bucket0.01/margin0.05 là PROPOSED.
HP/threat/cost-gap thay đổi weights liên tục; Bú win theo team intent.

Concrete offline evidence:

- D01: setting4, passive3 physical Kiếm +5 Nộ x1→100 points, đúng joint-burst
  account/boss/loadout calibration: propose swap `(5,3)↔(6,3)`. F là nominal
  USER_CALIBRATED, không observed WIN hoặc proof effect order.
- D02: cùng setting4, đã100 Nộ và sweep **0 viên Nộ mới**, vẫn propose3 Kiếm.
  Không tạo hard combo3+5. D03 thiếu Nộ giữ baseline; D04 đã60 +2 viên Nộ,
  thiếu effect order không fire theo giả định tổng cuối100; scoped order evidence
  mới làm đủ certificate. Một Kiếm x3 không là3 physical Kiếm.
- SIMPLE/CAREFUL/Skill Rush/Mega: mỗi cặp cùng board/settings/model/baseline,
  chỉ HP100→40. Healthy giữ offensive incumbent; HP40 chọn supported protective
  skill. Không có rule HP30 mới. Actual cost thiếu→skill bị loại; opaque effect
  baseline→retain, không chấm skill0 để ép SWAP thắng.
- Healthy setup thiếu effect/reply evidence: targeted record giữ baseline;
  không claim đã đánh giá tốt setup sau boss. B3/D4 còn phải kiểm case đó.
- Bú win HP1 vàHP100 với cùng team intent chọn cùng feed-boss board proxy;
  không áp solo survival hoặc cho damage skill override. Team model thiếu→retain.

Scope mismatch chỉ bỏ sufficiency credit; ordinary action có căn cứ độc lập
vẫn có thể được đề xuất. Thiếu cap cũng không tự cấm mọi action: dependent
certificate giữ interval, root khác có evidence đủ vẫn được so. Không biến
“fallback” thành blanket ban mọi risk/UNKNOWN.

## 4. Mechanics/evidence và giới hạn chưa hỗ trợ

Original-cell removal ledger theo simulator clear rounds/collapse, khớp ordinary
resource totals; physical/effective/point quantities tách riêng. Actual cap và
cost kiểm readiness/progress; overflow hoặc resource đã ready không nhận thêm R.
Protection phải có scoped effect; không dùng20/30 cho gem khác. Health/Drain
không heal-credit hai lần cùng HP deficit.

Demon dùng common FIRST_WAVE_UNION coverage: ordinary first clear union passive
blast, cross39 cells dedup. Không cộng ordinary cascade sau sweep vì residual
geometry đã đổi. Passive residual Sword reply và target/refill interaction giữ
interval. H/L bằng0, fixed followup target sets/discount0.5 version hóa nhưng
chưa cộng future value. Pre-boss Shield setup chưa được thưởng như own followup.

Comparator total order bằng fixed bucket/lower bound, weakest essential evidence,
profile risk/X/progress/E/canonical family/source/numeric coordinates. Override
chỉ khi candidate lower bound > incumbent upper bound ít nhất0.05. Unresolved
essential context có thể retain; opaque baseline không được gán score0.

**Chưa sửa vấn đề boss ăn Khiên bằng R1.** O01–O09: boss reply ties/secondary
priority/bait/threat/retained Shield/stress/refill/effect-order validation thuộc
B3/D3. Không full world/damage/boss/card policy model. Effects/identity/costs
thêm trong fixtures đều SYNTHETIC_SPEC, không calibration game mới được verify.
Detailed mapping50 design cases ghi partial/deferred đúng phạm vi tại coverage
doc; không báo50/50 đã pass.

## 5. Kiểm thử và replay

Command đã chạy:

```powershell
$env:PYTHONPATH='D:\PokiguardToolV2\src'
python -m unittest tests.test_reasoning_planner tests.test_reasoning_offline tests.test_board_simulator tests.test_demon_aegis_farm
```

**81/81 PASS** trong12.896s:32 B2 +22 B1 +19 simulator +8 Demon.
Tests có meaningful context choice, all-root/baseline inclusion, invalid
cost/source/PASS/continuation filtering, scoped certificate/order controls,
original-ID cascade/cross dedup, legal Shield sweep thu2 Mana đóng60-point
requirement, cap/multiplier/missingness, no-safe/lowHP không hard ban,
near-tie retention, canonical transitive order, shuffled enumeration và strict
JSON replay determinism. No pure module IO/provider/executor import.

24 CLI synthetic scenarios: **11 PROPOSE_OFFLINE /13 RETAIN_BASELINE**, mọi
declared expectation pass. Thêm1 targeted healthy setup unsupported record
retains; tổng25 scoped scenario records.32 tests không đồng nghĩa32 independent
game observations hoặc50 design cases complete.

27 B1 records (26 historical H/3 matches +1 S mechanics): **27 RETAIN_BASELINE**,
reason UNSUPPORTED_MODEL_OR_LEGALITY_CONTEXT. Missing model/legal evidence không
tự fill bằng giả định. Chosen action attribution giữ B1, không gán alternative
outcome/boss move/refill. Dataset development đã xem trước, không tune weights
theo outcome hoặc dùng validation/holdout. Không win-rate/optimality claim.

Trong kiểm thử, fixture cross ban đầu vô tình có4 Shield dọc nên vùng44 thay
vì39; đã sửa fixture tạo đúng3×3 cross. Khi bỏ Nộ mới ở D02, fixture ban đầu
chỉ có một legal root trùng incumbent; đã thêm independent legal health root
để thật sự kiểm3 Kiếm override. Scope/cap negative controls cũng được kiểm
theo dependent credit: không bắt cả planner retain nếu root khác đủ evidence.
Không sửa solver để khớp fixture.

## 6. Benchmark offline

Command:

```powershell
python tools/evaluate_reasoning_planner.py --output-dir docs/phase5/artifacts/5b2_adaptive_utility_v1 --samples 30
```

**540 samples**,30/stratum,6 profiles ×3 boards, mỗi stratum có1 excluded warmup.
Python3.11.9, platform/individual samples lưu verification. Sparse/reference/
dense-three-gems có lần lượt0/11/43 legal swaps. Dense fixture được tạo stable
với3 gem types, là stress workload tổng hợp, không representative game cohort.
Quantiles dùng linear interpolation, tail descriptive/small-n.

| Profile | Legal roots | n | p50 ms | p95 ms | p99 ms | max ms |
|---|---:|---:|---:|---:|---:|---:|
| SIMPLE sparse |0|30|4.967|5.725|5.894|5.962|
| SIMPLE reference |11|30|32.031|34.698|34.850|34.911|
| SIMPLE dense |43|30|281.866|305.887|326.552|330.163|
| CAREFUL sparse |0|30|4.864|5.956|6.123|6.163|
| CAREFUL reference |11|30|32.639|35.484|36.097|36.174|
| CAREFUL dense |43|30|281.197|311.943|324.865|329.966|
| Skill Rush sparse |0|30|5.232|5.958|6.312|6.411|
| Skill Rush reference |11|30|34.055|37.678|39.005|39.355|
| Skill Rush dense |43|30|280.929|314.886|326.142|329.251|
| Demon sparse |0|30|5.052|6.083|7.230|7.618|
| Demon reference |11|30|32.992|35.169|36.588|36.922|
| Demon dense |43|30|280.539|296.335|304.639|305.708|
| Mega sparse |0|30|4.780|5.420|5.561|5.614|
| Mega reference |11|30|31.672|33.864|34.561|34.798|
| Mega dense |43|30|280.944|307.315|315.807|317.528|
| Bú win sparse |0|30|4.756|6.060|6.467|6.561|
| Bú win reference |11|30|31.217|35.626|39.141|40.462|
| Bú win dense |43|30|278.869|329.432|346.239|346.685|

Includes pure plan/simulator/immutable explanation, excludes fixture construction,
decision serialization/file IO/provider/capture/worker/preflight/input/log sink.
Không end-to-end deadline proof; không suy4–6s đủ cho B3 hoặc runtime từ kết
quả này. Không full-suite/build/live; focused regression đúng changed scope.

## 7. BASIC/flow, diagnostics và gates

Tracked `src/tools/tests` diff vẫn rỗng; chỉ thêm3 new offline files. B1/code/data
hashes preserved, simulator/Demon không đổi. Không import/wire module mới vào
package init/BASIC/UI/controller. Provider/read count/order, screenshot flow,
executor/pacing/lease/QTE/click-only/ACK/pending/retry/Evolution/continuation,
navigation/Start/Stop/FarmRunner/recovery không được sửa hoặc gọi.
Đây là source non-wiring evidence, **không** live flow/action parity acceptance.

Diagnostics là deterministic offline result/JSONL, namespace riêng không phải
runtime sink. Logging queue/rotation/breaker/error isolation/overhead chưa đo,
chọn B4/C3. No shadow wait, real deadline/preflight/stale-result/after-dispatch
test hoặc fallback runtime mới. Những gate đó còn B4/C/D/E.

| Required B2 gate | Result / evidence |
|---|---|
| Existing mechanics/all-root/baseline | PASS, focused tests + source dependency preservation |
| Evidence-aware adaptive objective, advisory settings | PASS within synthetic one-step scope, paired choice + D01/D02 controls |
| Unit/cap/dedup/no unsupported future credit | PASS scoped tests; full passive residual/effect validation deferred B3/D3 |
| Legal/card/PASS/opaque baseline/ownership disposition | PASS offline capability fixtures; no production authority |
| Determinism/comparator/margin/unsupported input | PASS, replay/shuffle/near-tie/missing evidence tests |
| Versioned score/explanation/coverage/benchmark | PASS, linked artifacts + coverage limitations |
| Preserve baseline/flow/no live/no release/STOP | PASS scope; runtime parity NOT_MEASURED |

`git diff --check -- docs src tools tests` pass (existing LF/CRLF notices only);
new source/tool/test/docs whitespace check0 issues. Final QA:4 artifact hashes,
3 source +6 dependency hashes,9 B1 hashes khớp;25/25 serialized scenario decisions
replay khớp chính xác, contribution sums khớp utility bounds,540 samples confirmed.
No superiority/production readiness claim.

## 8. Router và STOP

Result **PASS STRONG** chỉ cho B2 one-step offline component gates. STATUS/router
chọn đúng [5B.3 — bounded reply/uncertainty refinement](../prompts/5B3_BOUNDED_REPLY_AND_UNCERTAINTY_REFINEMENT.md).
Next cần giữ all-root incumbent, scoped certificates và no-credit-before-coverage;
đánh giá root→boss→ta, nominal ties, residual passive limitations, refill stress,
retained Shield/bait downside và incident controls. Không tự mở production/live.

**STOP ở5B.2. 5B.3 chưa thực hiện.**
