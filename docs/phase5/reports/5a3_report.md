# 5A.3 report — Telemetry, deadline và bounded acceptance

Ngày: **2026-10-09 (Asia/Saigon)**.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP / PARENT / MODE: 5A.3 / 5A.2 / DOCS ONLY
RESULT: PASS STRONG — SPEC/DOCUMENTATION GATES ONLY
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
SOURCE VERSION: v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
HEAD TREE: b74139ea0f22ca4d6e08b06bbeb977bba68a1971
RUNTIME/GAMEPLAY/TEST CODE CHANGES: NONE
RUNTIME INSPECTION / GAME ATTACH / LIVE INPUT / TEST / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION / RELEASE: NONE
LIVE BATCH ACTIVATED: NONE
NEXT: 5B.1 OFFLINE — NOT_EXECUTED
STOP: 5A.3
```

## 1. Entry, authorization và source truth

Người dùng yêu cầu “chạy bước tiếp theo đi” sau5A.2 và targeted Shield log review.
Entry [5A.1](5a1_report.md), [5A.2](5a2_report.md) PASS STRONG DOCS;
[prompt5A.3](../prompts/5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md) chọn đúng
scope docs. Đọc AGENTS/STATUS/ROUTER/EXECUTION_CONTRACT/HANDOFF, A1/A2 specs,
research/incident evidence liên quan và future prompts để giữ protocol nhất quán.
Chỉ đọc tài liệu/Git và nguồn thống kê official, không code audit.

Entry worktree: tracked modified docs CURRENT_STATE, DECISIONS,
basic_gameplay_policy, demon_aegis_farm_policy, gameplay_rules; untracked docs
Phase3/, baseline combined/handoff pack, phase5/, reasoning_gameplay_policy.
Giữ toàn bộ prior/user-owned work, historical A1/A2 reports/spec và incident
artifact. Không reset/checkout/delete/rewrite history hoặc accepted binary.

Source fingerprint: HEAD + tree + changed-path evidence. Tracked/nonignored
untracked paths trong Git chỉ thuộc docs/, không source/runtime/test path đổi.
Đây không phải observation live parity hoặc proof running process/binary giống
HEAD; game/current process không được inspect. Historical incident binary hash
vẫn UNKNOWN, không lấy current source hash gán ngược.

## 2. Deliverables và changed-file manifest

Tạo3 files:
- [Telemetry/deadline/technical acceptance](../specs/5a3_telemetry_deadline_acceptance.md).
- [Bounded live protocols](../specs/5a3_bounded_live_protocols.md).
- Report này.

Cập nhật8 files, chỉ pointer/link/protocol summary:
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [README](../README.md).
- [ROADMAP](../ROADMAP.md), [PROMPT_INDEX](../PROMPT_INDEX.md),
  [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Canonical REASONING policy](../../reasoning_gameplay_policy.md),
  [CURRENT_STATE](../../CURRENT_STATE.md).

Tổng11 docs chạm ở bước này. Không sửa BASIC/Demon gameplay policy,
DECISIONS, gameplay_rules hoặc prompt thực thi khác trong5A.3; những path đã
modified từ trước được bảo toàn. Bộ20 main +3 optional +2 template giữ nguyên.

SHA-256 của2 normative specs tại closure:
- telemetry/deadline: `A465EC86E6DD5BD0DB53C9D784C60CA061FF52BB543A2E6596DF72BB6F7A4071`.
- bounded live: `4849C10582EDEEEDA4A45846C75E87AC41FC33599A003F80A42ABCCE25A0ECA9`.

## 3. Baseline, flow và reasoning capability

**Runtime unchanged; no live/test execution.** Không sửa thứ tự/count memory,
provider ownership/capture, executor/input mode/lease, card/QTE/pending/ACK,
Evolution/continuation, navigation/FarmRunner/recovery/Start/Stop/resume.
New-code parity và runtime safety counters: NOT_OBSERVED/NOT_MEASURED,
không claim PASS bằng docs.

Contract giữ selected PlayStyle objective, settings advisory; hard legality/
actual source/cost/ownership/timer không override. Incumbent BASIC trước job,
existing preflight thắng. Lỗi trước input retain BASIC còn hợp lệ; invalid state
giữ fail closed. Đã input thì không replacement; ACK/QTE/recovery owner cũ thắng.

Schema semantic event.v1 nối run/session/match/source/job/config/candidate/
dispatched action, provenance/units/version/calibration scope/binding.
Baseline/proposal/selected, completed work/coverage/gap, overrides/fallback và
observed chosen-root outcome tách riêng. Physical/effective/points, same-burst
order, boss max-Sword ties, retained/lost setup/bait downside theo A2;
không dump full tree hoặc label outcome cho alternative.

R1/R2/model/profiles chưa implemented/validated. Conditional Demon3+5,
nominal Sword-first và resource conversion giữ đúng support/scope A2.
Tất cả6 profile giữ capability pending; Coop baseline live gap không suy từ solo.

## 4. Diagnostics, deadline và proposed SLO

- Bounded queue512 /8MiB, event caps,100% compact eligible summary attempts,
  first exception + bounded signatures/repeat aggregation, counters và quota/
  rotation/retention. Written không giả là eligible/enqueued/aggregated.
- Default thiết kế shared namespace/filter nếu backend accepted đáp ứng;
  separate chỉ sau measured total/delta SLO đạt. Backend thực tế UNSELECTED;
  overhead NOT_MEASURED. Không synchronous disk/lock wait hoặc log drain Stop.
- Absolute budget default4000ms/cap6000ms từ t0, source observation age,
  uncertainty, family reserve và validation margin. Thiếu budget/source timing
  evidence thì BASIC ngay; không thêm wait loop/read/capture/delay cố định.
- Family floor proposals SWAP1000ms, click-only1250ms, QTE initiation1500ms;
  accepted gate/reserve chặt hơn luôn thắng. Inclusive/strict wording conflict
  docs cũ được giữ UNKNOWN mapping giao B4/C3, không sửa runtime predicate.
- Single active + latest pending job, stale/late discard, no retry trong decision,
  proposed breaker3 consecutive /5 trong20 fault jobs, persistent fault disable.
  Stop/input authority không chờ cleanup.
- SLO p50/p95/p99/max, disabled/shadow/separate delta/validation/fault/Stop,
  CPU/memory/log loss, sample counts và calibration procedure đều có số
  **PROPOSED**, chưa kết quả. Offline timing3×10.000/mode, fault30/variant,
  Stop100 trials; live N theo cap thực tế, không hàng chục nghìn trận.

Dropped/written/aggregated runtime counters: NOT_MEASURED.
CPU/private memory/tails/reserve calibration/cleanup: NOT_MEASURED.
Benchmark22.901ms cũ không là new end-to-end evidence.

## 5. Offline evidence và Shield incident limitations

Không chạy replay/simulator/test harness mới ở5A.3. Dùng
[incident review có sẵn](../research/demon_shield_setup_incident_review.md):
445 unique combat logs/MatchIds,26 indicator pairs/25 matches; archived10
snapshots, known-root replay26/26 resources và23/23 setup forecasts,3 fire N/A.
Đây là targeted work trước A3, không B1/B3 implementation hoặc planner acceptance.

Protocol yêu cầu pre-boss forecast/predicted post-boss/actual fresh-next-turn
setup tách riêng, repeated loss/progress/turns-to-first-passive và retained
positive controls. Actual boss swap/consumed cells missing; last_move đã
owner-match local root không được đổi nhãn boss. Không claim cause chính xác
hoặc simulated alternatives thắng tốt hơn.

Dataset tiers S/H/O/L; group split match/session/time, dedup continuation,
historical inspected corpus là development evidence. Minimum offline coverage
A2 designs + failure matrix + DSI01–DSI07 materialize ở B steps; không gọi
design rows là test PASS. No production snapshot export/read loop added.

## 6. Live protocols và efficacy separation

Không live batch nào được kích hoạt/chạy ở5A.3.
Chốt cap mỗi bước, all-attempt ledger, predeclared stop/assignment/scope:
C3 tổng6; D default3/arm/profile, explicit option≤5; D5 conditional tổng6;
E1 default10/arm, activated max50/arm/cohort; E2 default25/max30 total;
F1 tổng4. Invalid/abort tiêu cap, không refill tới khi đủ valid/gặp case.

N=W+L+UNKNOWN; abort/invalid là tags. Energy tổng debit mọi attempts/WIN,
throughput/full active time, fallback vs coverage/budget skip/breaker exposure
và technical counters. Missing consumption/terminal không dùng0 hoặc drop.
Chosen root mới có observed outcome; alternative/shadow không win label.

CI95% primary-source references, session/block dependence, bootstrap ratios/
degeneracy/zero-win và Wilson descriptive uncertainty được ghi rõ.
Proposed win margin -5pp, energy benefit5%, throughput margin -5%, minimum
independence guard; **không tuyên bố cap10/50 đủ statistical power**.
PROMOTE/INCONCLUSIVE/NO_PROMOTION tách technical PASS; BASIC vẫn default.
Missing actual boss action/order/case → NOT_OBSERVED/UNKNOWN, không unlimited test.

## 7. Gates và QA

| Gate ở5A.3 | Result / evidence |
|---|---|
| Event correlation/evidence/units/coverage và bounded counters | PASS — telemetry spec2–4 |
| Absolute deadline/reserve ownership/Stop/breaker | PASS SPEC — mục5; calibration implementation pending |
| Numerical SLO/tolerance/sample plan, proposed vs measured | PASS SPEC — mục6, zero measured claims |
| Failure matrix / baseline vs fail-closed / after-input | PASS SPEC — mục7, no fault execution |
| Dataset provenance/independent split/attribution | PASS SPEC — mục8 + incident limitations |
| Bounded pilots/E1/E2, all-attempt metrics/CI/margins/stop | PASS SPEC — bounded protocol1–8 |
| No flow/code/live changes, no unrequested Git/release action | PASS scope — docs-only manifest/Git metadata |
| Runtime/model/technical live/efficacy/package acceptance | PENDING / NOT_IMPLEMENTED / NOT_MEASURED |

Doc QA: local Markdown links ở11 changed docs resolve; balanced fences,
no replacement characters/trailing whitespace; next pointers agree5A.3 CLOSED
→5B.1 NOT_STARTED. Numeric cap/default correspondence với future prompts,
formula examples và source/support wording reviewed. Git configured
`diff --check -- docs` PASS; HEAD/tree unchanged, tracked/nonignored untracked
changed paths docs-only. Đây là doc QA, không gameplay/test suite execution.

## 8. Router và STOP

Current result **PASS STRONG — DOCS ONLY**. STATUS/router cập nhật.
Exactly one next prompt:
[5B.1 — Offline snapshot/replay/telemetry](../prompts/5B1_OFFLINE_SNAPSHOT_REPLAY_AND_TELEMETRY.md).

5B.1 là bước code offline đầu tiên khi người dùng yêu cầu; chưa chạy, chưa
production wiring/worker/UI/input. **STOP ở5A.3.**

