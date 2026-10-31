# 5A.2 report — Adaptive features, utility và profile

Ngày: **2026-10-09 (Asia/Saigon)**.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP: 5A.2
PARENT: 5A.1
MODE: DOCS ONLY
RESULT: PASS STRONG — SPEC/DOCUMENTATION ONLY
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
SOURCE VERSION: v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
HEAD TREE: b74139ea0f22ca4d6e08b06bbeb977bba68a1971
RUNTIME/GAMEPLAY/TEST CODE CHANGES: NONE
GAME ATTACH / LIVE INPUT / TEST / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION BUMP: NONE
NEXT: 5A.3 DOCS — NOT_EXECUTED
STOP: 5A.2
```

## 1. Entry, scope và Git truth

Người dùng yêu cầu tiếp tục5A.2 và làm rõ suy luận qua Demon Farm: Nộ20/Mana30,
setting4 vẫn có thể chọn3 Kiếm khi đủ Nộ, setup Khiên phải còn sau boss, có thể
chừa Sword làm mồi theo nominal Sword-first. Đây là nguyên tắc tổng quát,
không yêu cầu code hoặc chỉ thêm một rule riêng cho Demon.

Entry [5A.1](5a1_report.md) PASS STRONG DOCS. Đã dùng prompt5A.2,
[contract](../EXECUTION_CONTRACT.md), canonical BASIC/Demon,
[MI3 historical hotfix](../../mega_icarus_spam_skill/mi3_survival_hotfix_report.md)
và nghiên cứu5A.0 làm nền; chỉ đọc tài liệu và Git metadata, không audit code.

Entry worktree có4 tracked docs modified: CURRENT_STATE, DECISIONS,
basic_gameplay_policy, gameplay_rules. Untracked docs có Phase3/, baseline
combined/handoff pack, phase5/ và reasoning_gameplay_policy. Bảo toàn toàn bộ
prior/user-owned work; chỉ bổ sung các section/link/pointer liên quan, không
reset/checkout/xóa artifact cũ, không sửa5A.1 spec/report lịch sử.

Source fingerprint là HEAD + tree ở trên và Git changed-path manifest:
tracked changes/untracked nonignored chỉ thuộc docs/, không có source/runtime/
test path thay đổi so HEAD. Không dùng HEAD đơn lẻ để claim source unchanged.
Không mới đo runtime/flow parity từ fingerprint này.

## 2. Hoàn tất

- [Feature/utility/schema/profile spec](../specs/5a2_features_utility_and_profiles.md):
  snapshot/candidate/proposal semantic v1; units, availability, origin/support,
  scope/assumptions; source catalog chỉ existing state/solver.
- Count vật lý, effective units và Mana/Nộ points tách riêng; caps/deficit/cost,
  multiplier applicability, removal-event/sweep union dedup, same-burst order.
- Scoped user calibration cho3 Kiếm+Nộ so setting4, không damage formula toàn
  cục; R1 được dùng calibration đúng scope, không cần full world model.
- Root→boss→own legal followup; nominal max-Sword ties, secondary priorities
  UNKNOWN, post-boss setup/contested loss, intentional Sword bait và threat.
- Utility initial weights, continuous HP/resource/threat/uncertainty adaptation,
  continuation discount/target sets, nominal/stress fragility, total comparator
  và baseline margin. Numerical constants **PROPOSED**, cần offline validation.
- [50 scenario designs](../specs/5a2_scenario_matrix.md): 8 U +9 D +9 O +12 P +12 C,
  gồm positive/negative và paired anti-rigidity, cả sáu PlayStyles.
- Canonical product clarification, future A3/B2/B3/D3 prompt handoff và current
  STATUS/router. Không thực thi prompt kế tiếp.

Ví dụ positive: setting4, đúng scope joint-burst3 Kiếm+5 Nộ x1 thì root có
nominal sufficiency và eligible; không ép fire nếu threat/evidence/gap khác.
Counterexample: thiếu Nộ, scope khác hoặc future resource chưa chứng minh áp
trước damage thì không claim kill. Bait giữ Khiên có thể tốt khi khỏe; tie ăn
Khiên hoặc HP thấp phải giảm giá trị/hiện downside.

## 3. Baseline, flow và capability

BASIC v1.2.4/default3 Sword Demon và hotfix Mega giữ nguyên. Setting4 là ví dụ
cá nhân. Historical Demon “never Sword” không xóa mandatory least-consuming
Sword fallback ở accepted b6 [addendum](../../board_resolution.md).

Memory/provider/read order, capture order, action/input/QTE/click-only/ACK/
pending/lease, lifecycle/navigation/recovery/Stop không có implementation
change. Parity dưới code REASONING tương lai vẫn NOT_IMPLEMENTED/NOT_MEASURED;
không lấy docs PASS làm runtime acceptance.

Proposal không có input authority. Baseline phải sẵn có; error/late/unsupported
trước dispatch dùng incumbent còn valid qua preflight cũ. Invalid state fail
closed. Sau dispatch giữ pending/ACK owner, không gửi replacement input.
Hard costs/source/legality/continuation vẫn tách khỏi tactical thresholds.

R1 model/proxy và USER_CALIBRATED khác reverse/runtime verified hoặc observed
WIN. Full damage/refill/boss special action policy còn UNKNOWN. Account identity
chưa có boundary ổn định thì operator label+pinned run intent, ghi binding strength.
Bú win không tự áp solo survival, baseline live vẫn pending. Không profile nào
được claim REASONING live accepted trong bước này.

## 4. Diagnostics và evidence còn thiếu

A2 chốt cần log units/counts, calibration version/scope/dependencies, baseline
comparison, boss tie/coverage, retained/lost setup, bait threat, contributions/
fragility và fallback. Không log raw ảnh/process pointer hoặc search tree nặng.

Separate sink/shared namespace, bounded queue/retention, SLO/deadline/cancel/
Stop reserve và overhead giao A3/B4/C3/E2/F1; không giả đã chọn/prove sink.
Log failure không block action. Event counts/p50/p95/p99/max/CPU/memory:
**NOT_MEASURED**. Chưa có fixture execution/fault injection/live batch/package
trong5A.2. 50 design cases không phải50 tests pass, không dataset/holdout proof.

Narrow questions đã có owner: B1 DTO/provenance; B2 utility/normalization;
B3 effect-order/scope/reply/ties/refinement; D3 conversion/joint-burst/retained
Shield/bait observed theo protocol bounded; D4 anti-rigidity; E1 efficacy.
Thiếu case live ghi NOT_OBSERVED, không unlimited retries.

## 5. Changed-file manifest của bước này

3 output mới:
- specs/5a2_features_utility_and_profiles.md
- specs/5a2_scenario_matrix.md
- reports/5a2_report.md

6 canonical docs bổ sung/cập nhật:
- docs/CURRENT_STATE.md
- docs/DECISIONS.md
- docs/basic_gameplay_policy.md
- docs/gameplay_rules.md
- docs/demon_aegis_farm_policy.md
- docs/reasoning_gameplay_policy.md

6 coordination docs:
- docs/phase5/STATUS.md
- docs/phase5/ROUTER.md
- docs/phase5/README.md
- docs/phase5/PROMPT_INDEX.md
- docs/phase5/ROADMAP.md
- docs/phase5/EXECUTION_CONTRACT.md

4 future prompt handoffs, chưa thực thi:
- prompts/5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md
- prompts/5B2_OFFLINE_ADAPTIVE_UTILITY_PLANNER.md
- prompts/5B3_BOUNDED_REPLY_AND_UNCERTAINTY_REFINEMENT.md
- prompts/5D3_DEMON_AEGIS_ACCEPTANCE.md

Các path specs/reports/prompts ở danh sách trên nằm dưới docs/phase5/.
Tổng19 file tài liệu; không commit source/doc snapshot.

## 6. Gate tài liệu và verification

| Gate5A.2 | Result / evidence |
|---|---|
| Sáu profiles, mục tiêu vs advisory vs hard validity | PASS DOCS — spec8 + matrixD/O/P |
| Positive/negative anti-rigidity, không solo-survival cho Bú win | PASS DOCS — D01–D05, O02–O04, P01–P12 |
| Units/evidence/scope, không fake full damage/refill model | PASS DOCS — spec2–5 + U/D/C |
| Boss-contested setup/ties/bait và bounded future value | PASS DOCS — spec5–7 + O01–O09/C11 |
| Stable comparison/baseline/UNKNOWN/fallback ownership | PASS DOCS — spec9 + C01–C12 |
| Giữ BASIC/flow, không action/code/runtime modification | PASS SCOPE — docs-only manifest/Git metadata; runtime parity chưa đo |
| Documentation links/IDs/pointers/whitespace | PASS DOCS — 50 unique IDs đúng nhóm; 65 existing links +1 expected future A3 output; 19 files không trailing whitespace; pointers A3 |
| Không commit/push/tag/version/build/test/live, STOP | PASS SCOPE — chỉ docs; next5A.3 chưa chạy |

Doc QA kiểm toàn bộ local links trong3 output mới và A2/A3 references ở16 file
còn lại:66 refs,65 file tồn tại;1 link B3→5a3_telemetry_deadline_acceptance.md
là output tương lai của A3, được giữ pending, không tạo file giả. Git diff
--check -- docs exit0; LF→CRLF warnings chỉ là line-ending notice. Git metadata
xác nhận HEAD/tree/branch như entry,5 tracked modified paths và54 untracked
files đều thuộc docs/, non-doc paths0. Đây là kiểm tra tài liệu/phạm vi, không
phải runtime/code test hoặc chứng minh gameplay parity.

PASS STRONG chỉ thuộc completeness/consistency của specification. Không claim
planner working, calibrated lethal proof, optimal move, win-rate improvement,
runtime safety acceptance hoặc log/deadline performance.

## 7. Router / STOP

Current5A.2: **PASS STRONG DOCS ONLY**.
[STATUS](../STATUS.md) và [ROUTER](../ROUTER.md) trỏ duy nhất tới
[5A.3](../prompts/5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md).
5A.3 tiếp tục đặc tả log/deadline/protocol; chưa thực hiện. **STOP tại5A.2**.
