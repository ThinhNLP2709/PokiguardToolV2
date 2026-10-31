# 5B.3 report — Bounded boss reply và uncertainty refinement

Ngày: **2026-10-09 (Asia/Saigon)**.

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5B.3 / 5B.2 / OFFLINE ONLY
RESULT: PASS STRONG — BOUNDED STRUCTURAL COMPONENT GATES ONLY
R2 GAME/RUNTIME PROMOTION: DISABLED / NOT_VALIDATED
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
BASELINE: v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
HEAD TREE: b74139ea0f22ca4d6e08b06bbeb977bba68a1971
BRANCH: codex/phase3a2-board-repair
EXISTING RUNTIME/BASIC/SOLVER/PROVIDER/EXECUTOR CHANGES: NONE
GAME ATTACH / INPUT / PRODUCTION WIRING / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION / RELEASE: NONE
NEXT: 5B.4 OFFLINE — NOT_EXECUTED
STOP: 5B.3
```

## 1. Entry và kết quả

User yêu cầu “tiếp tục” sau [5B.2 PASS STRONG](5b2_report.md), đúng
[prompt5B.3](../prompts/5B3_BOUNDED_REPLY_AND_UNCERTAINTY_REFINEMENT.md).
Đã đọc AGENTS/status/router/execution contract, A0 research/completion, A2
feature/scenario, A3 deadline, B2 implementation/report và Demon incident review.

Thêm component ta→boss→ta bằng existing ordinary solver primitives, bounded
root/node/scenario/time, all nominal ties, conditional retained Shield geometry,
threat và adverse policy/UNKNOWN sensitivity. Không giả định có full boss,
refill, damage hoặc passive residual model. [Capability manifest](../capability_manifest.md)
phân biệt SUPPORTED/CONDITIONAL/UNKNOWN theo scope/game build.

**Đầu ra thực thi vẫn là completed bound R1.** Research ranking chỉ diagnostics;
R2 runtime promotion false. Đây là lựa chọn có chủ đích vì actual boss action,
refill/effect/survival scope chưa được narrow-validate; không biến synthetic
tests thành permission đổi nước đi trong game. Không block roadmap R1/B4.

## 2. Files, Git và fingerprints

New3 code/tool/test:

- [reasoning_refinement.py](../../../src/pokiguard_v2/reasoning_refinement.py).
- [evaluate_reasoning_refinement.py](../../../tools/evaluate_reasoning_refinement.py).
- [test_reasoning_refinement.py](../../../tests/test_reasoning_refinement.py).

New data/docs/artifacts:

- [Synthetic boards](../datasets/5b3_synthetic_boards_v1.json), seed5032026;
  search capped150 boards/30s, found both mechanical controls in4 boards/47 roots.
- [Capability manifest](../capability_manifest.md), report này.
- [Inputs](../artifacts/5b3_bounded_refinement_v1/inputs.jsonl),
  [R1/refinement ablations](../artifacts/5b3_bounded_refinement_v1/ablations.jsonl),
  [historical geometry/control chains](../artifacts/5b3_bounded_refinement_v1/historical_geometry.json),
  [verification/latency](../artifacts/5b3_bounded_refinement_v1/verification.json),
  [artifact hashes](../artifacts/5b3_bounded_refinement_v1/manifest.json).

Updated7 pointers: STATUS, ROUTER, README, ROADMAP, PROMPT_INDEX,
reasoning_gameplay_policy, CURRENT_STATE. Tổng18 paths:11 new +7 updated.
Không sửa B1/B2 code/tests/tools/data/specs/reports hoặc existing runtime.

Fingerprint4 code/tool/test/fixture paths (canonical sorted path→SHA256 map):
`3922c8ca32fa46e5ce3ffd89fd89963b8b07e84911d5060d7aa816d2e5b2e406`.
Individual hashes trong verification;9/9 B2 dependency files preserved.
Original solver/Demon hashes vẫn
`a26fe7213d30a8b61440f91a286b2469f63bb2a56008dfeb891b025193324fbd` /
`46e4468ff0e860dbcfde9667028fd0bcd49f4da85c3a4cf8fab411d5eadae301`.

Prior/user-owned work giữ nguyên: tracked CURRENT_STATE/DECISIONS/BASIC/Demon/
gameplay docs modified từ trước, untracked Phase3/, baseline combined/handoff
pack/phase5/canonical reasoning và8 B1/B2 source/tool/test files. Không reset,
checkout/xóa hoặc ghi đè accepted v1.2.4 artifact. HEAD/tree/branch không đổi;
HEAD đơn lẻ không fingerprint code mới chưa commit.

## 3. Model và bounded search

Refinement `5b3.structural.v1`, reply scope `5b3.reply_scope.v1`. Caller phải có
immutable snapshot và completed R1. Validate snapshot/config/canonical action
identity, baseline membership, unique/max128 candidates; invalid/stale incumbent
trả DISCARD_UNBOUND_INCUMBENT, không expose proposal cũ như executable fallback.

Root cap8, scenarios/root32, global node cap12000, default4000ms/max6000ms là
starting limits PROPOSED. Baseline luôn vào set trước, gồm cả baseline ngoài
top score; thêm incumbent/progress/resource/protection/damage/bait và goal-material
preservation diversity proxies. Không biến proxy selection thành setup credit.

Node đếm mỗi known transition attempt gồm illegal pairs, plus abstract knockout.
Deadline dùng caller monotonic absolute ceiling, không reset theo root/reply;
checks trước/sau primitive và trước atomic root commit. Cancel/node/deadline
discard root đang dở, giữ completed bound R1; partial diagnostic không là action.
Tail cooperative là một finite64-cell existing primitive và bounded result
packing. Hard crash/hang/process isolation/host return/preflight thuộc B4/C.

Known transitions tái dùng `_resolve_known_reply`, match/tally/collapse helpers
và Demon geometry hiện có; không viết solver mới, không thay UNKNOWN thành gem
thuận lợi. Private helper dependency được fingerprint; nếu core đổi cần revalidate.

Policy có scoped evidence: known Sword-producing replies → max **effective**
Sword, giữ mọi tie. Không có Sword/thiếu policy binding → all known alternatives;
secondary priority UNKNOWN. Boss skill/card/PASS/passive outside coverage.
Không có known reply không tự invent PASS hoặc guarantee ta có lượt.

Sau từng reply: enumerate known legal own followups, fixed A2 targets, Q bounds,
discount0.5 một lần vào H. Root balance cập nhật capped own gain; chỉ deficit mới
ở followup được credit. Post-boss HP MISSING vì damage/effect chưa có; không lấy
HP cũ lại thưởng future heal. Turn access positive lower credit chỉ dùng trong
SYNTHETIC fixture assumption; game access/survival UNKNOWN. No full second utility,
L0 vì contest đã nằm trong H; Bú win H0/no duplicate future B. Nominal terminal
certificate branch không nhận future H, certificate vẫn không observed WIN.

Known policy alternatives và2 abstract dependency knockouts đánh giá fragility.
Knockout không instantiate refill, không chứng minh reachable world hoặc probabilities.
U_nominal là minimum của các nominal ties đã cover; U_stress_min chỉ trong
scenarios đã xét; A2 lambda/pressure penalty có interval. Ties chưa đủ→không commit
aggregate. Root ngoài cap giữ future upper bound; research candidate cần baseline
complete, margin và vượt unseen upper bound. Returned R1 không bị ranking thay thế.

## 4. Scenario evidence và ablation

8 cases gồm2 generated S boards,3 synthetic contexts trên archived geometry
(bait healthy/lowHP, secondary-priority control), SIMPLE/CAREFUL/Mega reference.
Archived geometry dùng để dựng counterfactual có nhãn S; không transplant recorded
refill hoặc coi nguồn log đã quan sát outcome của alternative.

- **Positive Sword tie:**3 replies cùng4 effective Sword, retained passive physical
  Sword lần lượt0/0/5. Model giữ cả3 và minimum0, không chọn favorable5.
- **Secondary priority UNKNOWN:**5 replies đều0 Sword, gồm reply lấy Shield và
  làm opportunity0. Không giả boss tránh Khiên hoặc copy BASIC priority.
- **Effective vs physical:**3 max-effective ties7, nhưng có alternative lấy nhiều
  physical Sword hơn; physical-first chỉ sensitivity, không actual boss fact.
- **Bait:**pre-boss geometry6, nominal boss lấy6 effective Sword và còn4 physical
  Sword cho own Shield followup. HP10 tăng T/pressure penalty và lambda so HP100;
  không thưởng bait miễn phí hoặc nói boss6 Kiếm chắc gây chết.

Utility-only vs refinement: **8/8 returned proposals giữ đúng R1**. Có1 research
candidate vượt baseline reference, nhưng **trùng proposal R1**; không có action
change để suy counterfactual superiority. Lợi ích đo được ở đây là coverage/
explanation: nhận diện mất setup/tie fragility/threat/UNKNOWN, thay pre-boss forecast
bằng conditional post-reply opportunities. Không tuyên bố planner farm hiệu quả hơn.

Default work replay:2 generated cases chạm12000 nodes,5 complete roots/case;
root còn dở discard. Bait7637 nodes/7 complete roots; secondary3487/5; SIMPLE10440/8,
CAREFUL9768/8, Mega9880/8. Root passive residual unsupported giữ rõ status.
Không “hoàn tất search” chỉ vì hết cap hoặc đoán unseen ties.

## 5. Historical narrow validation / DSI01–DSI07

27 geometry-only traces:22 completed conditional ordinary graphs,
2 no-known-reply unsupported và3 passive-root-residual unsupported.
**23/23 applicable pre-boss forecast references khớp**, wrapper ordinary totals/
public resolver trên27 snapshots khớp tests; không validate actual full effect.

Giữ23 chosen-root→later-local-state chains,4 indicator losses:
M_7d274339 turns3→5,13→15; M_bdaf6d3b13→15; M_632f0563 1→3, actual next burst0.
Controls M_7d27433917→19 còn4 và M_632f0563 5→7 còn3. Không ban mọi setup hoặc
gọi mọi geometry change là failure. History không thêm hard rule “N lần thì phá”.

Legacy last_move owner23 LOCAL_ROOT, observed boss action **0**. Cause của4 losses
vẫn UNKNOWN_BOSS_REFILL_EFFECT. Geometry-only traces không có utility/alternate
outcome/R2 promotion. Pre-boss board/refill và actual boss swap còn missing;
không gán reply model nào là boss đã đi. Positive actual control có thể cùng
tồn tại với model adverse alternative; không ép model phải khẳng định control an toàn.

Narrow validation chỉ cho wrapper/mechanics/forecasts/owner/bounds. Actual boss
Sword policy, resource20/30/multiplier/gross-net, joint3+5/effect order/account,
damage/survival/passive residual chưa đủ evidence. R1 scoped calibration vẫn giữ
B2 contract; R2 promotion disable. Questions/return gates trong capability manifest
giao D3/D2/D4 bounded protocols khi user kích hoạt, không tự live/add reader.

## 6. Focused tests

```powershell
$env:PYTHONPATH='D:\PokiguardToolV2\src'
python -m unittest tests.test_reasoning_refinement tests.test_reasoning_planner tests.test_reasoning_offline tests.test_board_simulator tests.test_demon_aegis_farm
```

**114/114 PASS**,33.949s:33 B3 +32 B2 +22 B1 +19 simulator +8 Demon.
Có interrupted search/late primitive/deadline/cancel/node/scenario caps,
baseline outside top set, all ties/secondary/effective-vs-physical, multiple UNKNOWN
knockouts, unsupported reply/card/passive residual, scope/identity/membership/
invalid-state rejection, fixed future targets/discount/no repeat root resource,
actual incident losses/controls và deterministic serialized snapshot/work replay.
No IO/provider/capture/executor import/call trong component, clock only.

Direct CLI được chạy sau sửa standalone import path ROOT, không thay algorithm.
Không full-suite/build/game/live. New code scope có meaningful decision/budget
tests; existing B1/B2 tests/data và production source giữ nguyên.

## 7. Offline latency

```powershell
python tools/evaluate_reasoning_refinement.py --output-dir docs/phase5/artifacts/5b3_bounded_refinement_v1 --samples 10
```

80 paired timings,10/case,1 excluded refinement warmup/case. Python3.11.9,
platform/individual measurements trong verification. Deterministic graph replay
dùng fixed synthetic clock, **tách** real monotonic benchmark. Small-n descriptive
linear-interpolation quantiles, không p99 SLO acceptance.

| Case | R1 p50 ms | Refine p50 ms | p95 ms | p99 ms | max ms |
|---|---:|---:|---:|---:|---:|
| Effective/physical |71.881|958.617|974.600|980.226|981.633|
| Positive Sword ties |87.555|987.533|998.686|998.904|998.958|
| Bait healthy |36.891|473.041|481.489|484.828|485.662|
| Bait lowHP |37.760|472.484|514.574|517.076|517.701|
| Unknown secondary |14.254|186.955|196.381|198.488|199.015|
| SIMPLE reference |31.999|715.181|778.679|800.365|805.787|
| CAREFUL reference |31.260|623.619|646.563|651.107|652.242|
| Mega reference |32.352|628.165|653.305|657.826|658.956|

20/80 calls dừng NODE_CAP ở2 generated cases;60 còn lại complete-or-unsupported.
Refine timing gồm identity checks/clock/graph/result packing, loại R1/file IO/
provider/capture/IPC/log sink/host preflight/input. R1 timing đo riêng cùng sample.
Maximum refine998.958ms không chứng minh full4–6s job deadline, throughput,
energy/WIN, real farm improvement hoặc overhead logging. Node cap có tác dụng;
không tăng caps để che incomplete coverage.

Largest ablation JSONL line240091 bytes (R1+refinement+focused graph); đây là
offline artifact, không event16KiB. B4 cần bounded summaries/sampling/retention,
separate-vs-shared sink và overhead measurement; chưa logger/worker implementation.

## 8. Baseline/flow và gates

Tracked src/tools/tests diff vẫn rỗng; chỉ new3 offline source/tool/test files.
B1/B2 dependency hashes preserve, runtime không import component mới. Không
provider/process reads/capture/input handles, không sửa memory order/count,
executor/pacing/lease/QTE/click-only/ACK/pending/retry, Evolution/continuation,
navigation/Start/Stop/FarmRunner/recovery. No dispatch, không input thứ hai sau ACK.
Source non-wiring evidence không thay live BASIC/flow parity acceptance C3/E2.

| B3 required gate | Result / scope |
|---|---|
| Bounded diverse roots/incumbent/node/scenario/time | PASS offline component + interruption tests; caps PROPOSED |
| Known reply vs full boss actions, manifest | PASS scoped enumeration; unknown effects/policy stay disabled |
| Root→boss→own/ties/retained setup/bait | PASS structural synthetic/archived-geometry controls; no real survival guarantee |
| No invented favorable refill/damage/policy certainty | PASS no gem instantiation, all secondary alternatives, no full world claim |
| Complete incumbent/cancel/late/stale/invalid handling | PASS; partial root discarded, unbound incumbent not usable |
| Narrow evidence / R2 promotion only validated scope | PASS limited geometry/mechanics validation; game R2 promotion DISABLED |
| Focused tests/ablation/latency/limits documented | PASS114 tests/8 cases/80 paired timings/27 traces |
| Existing flow/no live/no release/STOP | PASS source scope; runtime parity NOT_MEASURED |

PASS STRONG thuộc technical component gates. Không claim mọi O case/live effect
complete hoặc R2 tốt hơn R1/BASIC. Worker/log sink/actual deadline/reserve/flow
integration/profile acceptance/efficacy còn B4/C/D/E/F.

Final QA:4 artifact hashes/4 source hashes khớp;9 B1 hashed files và4 B2 artifact
hashes preserved.8/8 serialized ablations replay khớp R1/refinement/focused graph,
caps8/32/12000 giữ đúng;27 traces/23 forecast matches/80 samples/20 node-cap stops
confirmed. `git diff --check` pass (LF/CRLF notices only), new files/docs whitespace0
issues, local links tồn tại; tracked source/tools/tests diff rỗng.

## 9. Router và STOP

STATUS/router chọn đúng [5B.4 — isolated runner/failure logging](../prompts/5B4_ISOLATED_RUNNER_AND_FAILURE_LOGGING.md).
Runner nhận completed R1 và refinement diagnostics theo manifest; không tự
promote unknown R2 capability, không input/provider ownership. B4 chốt isolation,
crash/hang/backpressure/late results và log cost trước integration.

**STOP ở5B.3. 5B.4 chưa thực hiện.**
