# 5L.1 — Learned model offline, tùy chọn

**Chỉ mở khi người dùng yêu cầu model/học riêng.** Weighted planner không thắng
BASIC không tự cấp quyền training. Prompt này chưa được thực thi.

## Entry và đọc trước

Đọc AGENTS, [contract](../EXECUTION_CONTRACT.md), [status](../STATUS.md),
[router](../ROUTER.md), [nghiên cứu bổ sung](../phase5a0_research_completion_plan.md),
report E1 và dataset/capability manifests. E1 kỹ thuật sạch, telemetry có
provenance; thiếu evidence thì targeted evidence hoặc STOP. Mode: OFFLINE.

## Mục tiêu và phạm vi

1. Chọn bài toán hẹp: predictor outcome gần hoặc residual candidate value.
   So model nhỏ/linear/tree/ranker với utility baseline; không dựng LLM click
   trực tiếp hoặc online RL exploration.
2. Dataset tách observed chosen-action outcomes, model prediction và reviewer
   preferences; không dùng WIN của trận làm nhãn cho mọi candidate.
3. Split theo match/session/time/version; candidates cùng turn ở cùng split.
   Holdout không dùng tune; logging policy/support/drift/missingness phải ghi.
4. Chốt objective/loss/metrics/coverage trước train; ranking preference không
   tự chứng minh win-rate. Không áp bandit replay/OPE nếu assumptions không đủ.
5. Model chỉ bổ sung giá trị trong scope; legality/objective/settings advisory/
   preflight/fallback vẫn do planner/controller. Unsupported/OOD → utility/BASIC.
6. Training/tooling offline, không production wiring/game/input/capture/read.
   Không auto-train sau mỗi trận hoặc ghi đè active model/config.
7. Đo quality/calibration/error/tails trên holdout và inference CPU/memory.
   Export chỉ nếu format/runtime phù hợp, pin hashes/dependencies; ONNX là option,
   không bắt buộc dependency mới để gọi là AI.
8. Focused verification malformed features, NaN/shape/schema/version mismatch,
   absent model, OOD và deadline failure. Không claim efficacy từ train score.

## Gate và đầu ra

- Có improvement metric scoped so utility, leakage/support audit và model hash.
- Nếu model không thêm giá trị: NO_MODEL_PROMOTION, giữ planner không model và STOP.
- Pure feature inference, không input authority và không ảnh hưởng disabled BASIC.
- Report `docs/phase5/reports/5l1_report.md` theo [handoff](../HANDOFF_TEMPLATE.md),
  model card/manifest và reproducible dataset split references.
- Đủ gate: next [5L.2](5L2_OPTIONAL_LEARNED_MODEL_SHADOW.md); chỉ chọn rồi STOP.
  Không commit/push/tag/build/release hoặc tự chạy shadow/live.
