# 5A.2 — Đặc tả suy luận thích ứng theo PlayStyle

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a1_baseline_reasoning_contract.md](../specs/5a1_baseline_reasoning_contract.md).
- [basic_gameplay_policy.md](../../basic_gameplay_policy.md).
- [demon_aegis_farm_policy.md](../../demon_aegis_farm_policy.md).
- [mi3_survival_hotfix_report.md](../../mega_icarus_spam_skill/mi3_survival_hotfix_report.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **DOCS**. 5A.1 PASS STRONG; contract đã phân biệt hard/objective/soft.

Đặc tả planner biết so sánh phương án theo tình thế và mục tiêu của cả sáu PlayStyle, đủ rõ để triển khai offline.

## Thực hiện trong phạm vi

1. Chốt schema immutable snapshot/candidate/proposal: source/session/turn identity, action family, config/version, feature missingness, units, normalization và evidence scope. Chỉ dùng trường từ state/solver đã có.

2. Viết objective và context/stage utility cho SIMPLE, CAREFUL, Chịu đấm ăn xôi, Demon Aegis, Mega Icarus, Bú win. Settings là reference; chọn khác gợi ý phải có evidence/reason và không mutate preferences.

3. Định nghĩa context adaptation có version: HP/resource/setup/boss threat/uncertainty làm đổi trade-off thế nào; tránh chỉ chuyển if/elif cứng thành một bảng trọng số cứng khác. Weight và score margin là PROPOSED cho offline tuning.

4. Định nghĩa candidate generation dùng existing solver, BASIC incumbent, action validity, PASS/card capability, scope seal, continuation và effect UNKNOWN. Không tạo lợi ích từ refill giả; tally không đồng nghĩa HP/damage.

5. Đặc tả bounded reply/lookahead, sensitivity, stop boundaries, R1 proxies và R2 capability manifest. Card/effect chưa đủ model đi theo baseline contract.

6. Viết scenario matrix có expected reasoning/explanation: cùng settings nhưng HP/boss/resource khác → cân nhắc khác; Mega chưa đạt seal target nhưng cần bảo vệ/fire sớm khi hợp lệ; healthy setup; no-safe-move; PASS; missing HP; high UNKNOWN; Bú win team objective.

7. Định nghĩa comparator ổn định/score bucket, baseline retention khi near-tie, why-better-than-baseline và assumptions. Score gap không phải xác suất.

## Gate bắt buộc

- Đủ sáu profile, có positive/negative anti-rigidity cases, không áp survival cá nhân chung lên Bú win.
- Hard validity tách khỏi advisory thresholds; action/executor sequence không đổi.
- Feature/prediction có evidence/missingness, không ngầm dùng full damage/refill model.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- docs/phase5/specs/5a2_features_utility_and_profiles.md
- docs/phase5/specs/5a2_scenario_matrix.md
- Report `docs/phase5/reports/5a2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5A.3](5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
