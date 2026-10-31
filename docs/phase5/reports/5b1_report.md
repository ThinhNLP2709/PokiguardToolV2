# 5B.1 report — Immutable snapshot, replay và event codec offline

Ngày: **2026-10-09 (Asia/Saigon)**.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP / PARENT / MODE: 5B.1 / 5A.3 / OFFLINE ONLY
RESULT: PASS STRONG — OFFLINE COMPONENT/DATA GATES ONLY
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
SOURCE VERSION: v1.2.4 baseline + new offline-only components
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
HEAD TREE: b74139ea0f22ca4d6e08b06bbeb977bba68a1971
BRANCH: codex/phase3a2-board-repair
EXISTING RUNTIME / BASIC / SOLVER / PROVIDER / EXECUTOR CHANGES: NONE
NEW CODE: 3 pure modules +1 offline CLI +1 focused test file
GAME ATTACH / LIVE INPUT / PRODUCTION WIRING / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION BUMP / RELEASE: NONE
NEXT: 5B.2 OFFLINE — NOT_EXECUTED
STOP: 5B.1
```

## 1. Entry, scope và Git truth

Người dùng yêu cầu “bước tiếp theo” sau [5A.3](5a3_report.md) DOCS PASS STRONG.
Đã đọc AGENTS/STATUS/router/execution contract,
[prompt5B.1](../prompts/5B1_OFFLINE_SNAPSHOT_REPLAY_AND_TELEMETRY.md),
A2/A3 specs, scenario matrix, research và incident evidence liên quan.

Implementation map lấy từ source thực: immutable state/GemType/SwapMove,
evaluate_all_moves và evaluate_demon_aegis_move, existing replay/test conventions.
Không viết solver mới hoặc audit/rewrite controller/provider/executor.
Map chi tiết tại [dataset README](../datasets/README.md).

Entry tracked docs đã modified CURRENT_STATE, DECISIONS, basic_gameplay_policy,
demon_aegis_farm_policy, gameplay_rules. Untracked docs có Phase3/, baseline
combined/handoff pack, phase5/, reasoning_gameplay_policy. Giữ toàn bộ prior/
user-owned work, historical reports/specs/artifact; không reset/checkout/xóa
hoặc ghi đè accepted v1.2.4 binary/package.

Git tracked source/runtime/tools/tests không đổi;5 code/tool/test files đều mới.
New modules không được import/wire vào package init/UI/BASIC/controller.
HEAD/tree giữ nguyên, không dùng HEAD đơn lẻ làm fingerprint cho code mới.

## 2. Hoàn tất và manifest19 paths

New code/tool/test:
- [reasoning_snapshot.py](../../../src/pokiguard_v2/reasoning_snapshot.py).
- [reasoning_replay.py](../../../src/pokiguard_v2/reasoning_replay.py).
- [reasoning_telemetry.py](../../../src/pokiguard_v2/reasoning_telemetry.py).
- [replay_reasoning.py](../../../tools/replay_reasoning.py).
- [test_reasoning_offline.py](../../../tests/test_reasoning_offline.py).

New dataset/docs:
- [datasets/README](../datasets/README.md), [manifest](../datasets/manifest.json).
- [26 historical roots](../datasets/demon_historical_v1.jsonl),
  [1 synthetic mechanics fixture](../datasets/synthetic_mechanics_v1.jsonl).
- [27 offline event records](../datasets/replay_events_v1.jsonl),
  [verification/fingerprints](../datasets/5b1_verification.json).
- Report này.

Updated7 coordination/canonical pointers:
[STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [README](../README.md),
[ROADMAP](../ROADMAP.md), [PROMPT_INDEX](../PROMPT_INDEX.md),
[REASONING policy](../../reasoning_gameplay_policy.md), [CURRENT_STATE](../../CURRENT_STATE.md).
Không sửa DECISIONS/BASIC/Demon/gameplay rules hoặc runtime defaults ở bước này.

Fingerprint5 code/tool/test files, SHA-256 của canonical sorted path→hash map:
`7e600255192041e8b9f49582b26a791bc2b3366157f0646232ba6add6a4899fa`.
Individual code/data hashes nằm trong verification artifact.
Existing simulator/Demon SHA-256 vẫn khớp incident review:
`a26fe7213d30a8b61440f91a286b2469f63bb2a56008dfeb891b025193324fbd`,
`46e4468ff0e860dbcfde9667028fd0bcd49f4da85c3a4cf8fab411d5eadae301`.

## 3. Baseline, flow và quyền action

Không production wiring hoặc live. BASIC policy/defaults/heuristics và existing
solver giữ nguyên; no changes memory read order/count/provider ownership,
capture count/order, input transport/lease/action pacing, QTE/card/click-only,
ACK/pending/retry/EVOLVE continuation, navigation/lifecycle/recovery/Start/Stop.

New APIs chỉ nhận immutable records/file data; không game/provider/capture/input
handle, không gọi runtime API. Existing package initialization giữ nguyên;
explicit offline imports không tạo controller/worker. Static boundary test cấm
new modules import production IO authority.

Root mechanical legality khác action preflight/runtime authorization.
Offline errors reject rõ bằng exception/CLI exit1; chưa là runtime fallback.
Deadline/fallback/after-input ownership/Stop contract A1/A3 vẫn phải implement/
prove ở B4/C3/C4. Không claim flow parity từ49 unit tests.

## 4. Schema, provenance và attribution

Snapshot/candidate semantic v1 map sang frozen DTO; nested config/evidence JSON
copy vào canonical immutable text. Return plain dict là detached copy.
Strict decoding reject duplicate JSON keys/nonfinite/deep/oversize/unknown
schema/invalid shape/multiplier/types. Observed gem/multiplier thiếu được lưu,
nhưng mechanical replay UNSUPPORTED và0 pairs, không fill refill giả.

Source identity gồm run/session/match/turn/seq/hash/actor/controller generation.
Session label derive từ published epoch/run/MatchId, không lưu raw board pointer;
controller generation/account/clock thiếu giữ MISSING. board_hash nguồn và
snapshot content hash riêng. Config hash/version/scope immutable, không pretend
full legacy settings hoặc binary fingerprint đã bind.

Source file/dòng/hash cho policy và action_sent; canonical action endpoints
không là executor script. Chosen action phải cùng source/snapshot/baseline,
action_sent file/hash/line hợp lệ. Native executor ActionId thiếu giữ MISSING,
không đổi derive candidate ID thành observed ActionId.

Physical/effective ordinary tallies, UNKNOWN exposure, round-local clears và
Demon Shield sweep union/Sword counts là mechanical features. Point conversion,
joint ordinary/passive ledger, utility, opponent policy/post-boss setup giữ
unavailable/deferred; không cộng aggregate chồng nhau hoặc giả numeric damage.

Outcome API chỉ trả observed terminal cho đúng chosen candidate; alternative
không nhãn thắng/thua. Dataset này không parse/prove final-match terminal:
27 terminal records MISSING có reason. Observation links cùng session/match/
actor, fresh later turn; không suy causal boss/damage từ next board.

## 5. Dataset, chain controls và kết quả replay

[Manifest](../datasets/manifest.json):27 records tổng,26 historical roots trong3
matches +1 synthetic regression context trên existing screenshot fixture.
Historical logs3 file hashes verified; importer map10/10 archived snapshots và
nguyên chuỗi10/12/4 quyết định. Không nhân continuation/summary thành trận mới.

Historical là inspected development data, không independent holdout. Loader
reject duplicate snapshot/ambiguous turn, same-match/session split leakage,
inspected holdout/validation và tier/provenance mismatch. Synthetic không được
đổi nhãn live; source screenshot thật nhưng context/action synthetic mechanics,
không BASIC engine decision.

Execution:
```powershell
python tools/replay_reasoning.py replay docs/phase5/datasets/manifest.json --output-events docs/phase5/datasets/replay_events_v1.jsonl
```

| Check | Kết quả thực tế |
|---|---:|
| Mechanical root replay MATCH |27/27 (26 historical +1 synthetic) |
| Historical ordinary resources matched |26/26 |
| Applicable pre-boss setup forecasts matched |23/23 |
| Historical fire forecast N/A |3 (không tính PASS forecast) |
| Synthetic forecast N/A |1 |
| Same-session next-observation links |23 |
| Archived boards/identity/source hashes matched |10/10 |
| Local-root legacy last_move owner checks |23/23 bound return records |
| Exact observed boss actions |0; evidence MISSING, không negative boss claim |

DSI01–DSI03 losses giữ full chains, gồm M_7d274339 turns3→5 và13→15.
DSI04 retained positive control17→19 vẫn burst4 và M_632f0563 5→7 còn usable3.
DSI05 lưu HP/resource/shield/policy progress toàn chuỗi; không hard cutoff N
hoặc planner history policy. DSI06 last_move matching local root không relabel
boss swap. DSI07 all legal alternatives có model-only features và missing
outcomes/post-boss prediction; chưa bait ranking hoặc alternative superiority.

Không transplant observed refill sang alternative; chưa full BASIC engine
decision parity, effect order/damage/boss/refill validation hoặc50 utility
scenario tests. Source binary của historical logs vẫn UNKNOWN, không gán HEAD.

## 6. Focused verification

Command thực thi cuối:
```powershell
$env:PYTHONPATH = 'D:\PokiguardToolV2\src'
python -m unittest tests.test_reasoning_offline tests.test_board_simulator tests.test_demon_aegis_farm
```

**49/49 PASS**:22 tests B1 +19 existing simulator +8 existing Demon.
Coverage:
- immutable nested settings/copies, snapshot/candidate/record/event roundtrip,
  all proven multipliers1–7, missing khác observed0;
- deterministic replay, mechanical known roots và lost/retained controls;
- malformed/duplicate/nonfinite/deep/oversize JSON, invalid coordinates/
  units/count references/schema, incomplete observed board fail closed;
- source/run/session/match/turn/seq/hash/actor/generation mismatch,
  chosen-action binding, unchosen outcome unavailable;
- corrupt dataset hash/duplicate continuation/split leak/path escape/
  inspected holdout/tier mismatch;
- bounded event/candidate summaries, config/source/chosen/event ID/clock
  tampering, offline codec không publish production proposal;
- new modules không import IO authority.

No full regression/build/game attach/live. Full boundary/fault/SLO tests thuộc
B4/C3/C4/E/F; không gọi unit tests là proof production fallback/Stop.

## 7. Diagnostics và remaining capability

27/27 event codec roundtrips,27 unique deterministic event IDs.
Max decision event6237 UTF-8 bytes dưới cap16384. Candidate summaries chỉ
baseline, no full tree. run_intent/config/source/provenance/version/units và
chosen-binding được lưu; runtime UTC/monotonic clock explicit MISSING.
No job tạo thật, no proposal/selection mới, no guessed native ActionId.

Queue/writer/separate-vs-shared/rotation/retention/rate-limit/circuit breaker/
dropped-written-aggregated runtime counters: **NOT_IMPLEMENTED / NOT_MEASURED**.
CPU/memory/latency p50/p95/p99/max/cancel/Stop: **NOT_MEASURED**.
Offline command/test elapsed không thay SLO calibration A3.

All6 profile schema names được nhận; historical model coverage chỉ Demon,
SIMPLE chỉ synthetic mechanics. Skill Rush/Mega/Bú win/core efficacy chưa
accepted. Model/weights/resource conversion/certificates scope giao B2/B3,
technical/runtime/pilot/efficacy/package gates giữ nguyên.

## 8. Gates, QA và STOP

| B1 gate | Result |
|---|---|
| Pure immutable snapshot/config/schema + serialization |PASS — tests/codec |
| Deterministic legal replay từ declared manifest |PASS —27 roots, source/data hashes |
| Source→candidate→chosen→outcome attribution / missingness |PASS — identity guards, unknown terminal/boss, negative tests |
| Independent split / corruption / provenance coverage |PASS — development grouping, holdout0 explicit |
| Reuse existing primitives, no production wiring/authority |PASS scope — unchanged existing files + boundary test |
| Full utility/refinement/model/runtime/efficacy acceptance |PENDING — ngoài5B.1 |

Doc link/fence/whitespace QA và Git configured diff --check PASS.
Existing tracked source/tools/tests unchanged; new files đúng19-path manifest.
No commit/push/tag/version/release/build/live; prior work preserved.

STATUS/router cập nhật **5B.1 CLOSED — PASS STRONG OFFLINE**.
Exactly one next:
[5B.2 — Adaptive utility planner offline](../prompts/5B2_OFFLINE_ADAPTIVE_UTILITY_PLANNER.md).
Chỉ chọn prompt, chưa thực hiện nó. **STOP ở5B.1.**

