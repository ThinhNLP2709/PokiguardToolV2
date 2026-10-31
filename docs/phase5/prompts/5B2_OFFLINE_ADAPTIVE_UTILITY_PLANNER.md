# 5B.2 — Planner utility thích ứng offline

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md).
- [README.md](../datasets/README.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **OFFLINE**. 5B.1 PASS STRONG; specs5A đã chốt.

Implement pure R1 adaptive planner offline, có baseline incumbent và giải thích trade-off theo PlayStyle.

## Thực hiện trong phạm vi

1. Tái sử dụng toàn bộ legal root swap enumeration và simulator hiện có; không viết solver mới. Baseline choice được đưa vào candidate set, kể cả ngoài top heuristic.

2. Implement evidence-aware feature/normalization, context adaptation và utility theo version. Hard legality filter riêng; settings chiến thuật không được dùng như khóa cứng. Tách physical/effective/gain points, conversion Nộ20/Mana30 có provenance, scoped sufficiency và fixed continuation targets/discount, không double count ledger/H. Chưa refinement thì không credit unexamined future setup.

3. Chọn proposal hoặc retain BASIC với reason, contribution scores, risk/UNKNOWN và assumptions. Không coi lowHP là cấm mọi risky action; khi không phân biệt được thì baseline.

4. Chỉ so PASS/card khi legality/effect scope đủ; EVOLVE/continuation/executor semantics giữ contract. Không dùng fictitious damage/heal/refill để tạo action thắng.

5. Thực hiện paired scenario cases: same settings/different context, Mega early protection/skill when valid, healthy setup, Bú win team intent, missing effect và no-safe-move. Đặc biệt D01/D02/D03: setting4 vẫn xét3 Sword theo scoped Rage/joint-burst evidence, không sinh hard rule3+5; U cases kiểm units/caps/dedup. Expected case có thể là fallback nếu evidence thiếu; boss refinement cases giaoB3.

6. Focused tests cho invalid action exclusion, baseline retention, meaningful context adaptation, bucket total order và deterministic replay. Báo cả case planner vẫn cứng nhắc hoặc chưa hỗ trợ.

7. Benchmark offline theo profile/board density, sample counts và p50/p95/p99/max; đây không phải end-to-end deadline acceptance.

## Gate bắt buộc

- Planner thể hiện so sánh thích ứng có evidence, không chỉ bảng weights cố định; objective profile giữ đúng.
- Không runtime/provider/capture/input authority; malformed/unsupported input trả disposition rõ.
- Không claim tối ưu/win-rate từ replay; tuning không dùng holdout.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Pure R1 planner + focused scenario regression theo repo.
- Offline score/explanation và coverage/benchmark artifacts có version.
- Report `docs/phase5/reports/5b2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5B.3](5B3_BOUNDED_REPLY_AND_UNCERTAINTY_REFINEMENT.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
