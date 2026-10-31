# 5A.3 — Chốt log, deadline và protocol đánh giá

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a1_baseline_reasoning_contract.md](../specs/5a1_baseline_reasoning_contract.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.
- [Demon Shield incident review](../research/demon_shield_setup_incident_review.md):
  repeated forecast loss, retained setup/progress và actual boss-action missingness.

## Entry và mục tiêu

Mode: **DOCS**. 5A.1 và 5A.2 PASS STRONG.

Chốt protocol telemetry, latency, fallback và đánh giá trước code; các số chưa đo được ghi mục tiêu, không claim PASS.

## Thực hiện trong phạm vi

1. Chốt event schema + source/job/action/run correlation: baseline/proposal/chosen action, override, evidence, work completed, deadline/fallback, exception đầu tiên và aggregated repeats, written/dropped counters. Bao gồm physical/effective/point units, calibration scope/version/binding/effect-order dependencies, nominal boss ties/coverage, lost/retained setup và bait downside theo5A.2; không serialize toàn bộ search tree vào hot path.

2. Thiết kế bounded queue/retention/sampling; state đã có mới được serialize, không thêm capture/read. So separate sink với shared namespace/filter; chọn theo overhead đo ở B4/C3, không bắt buộc tạo hai file trace.

3. Chốt budget absolute từ remaining time/observation age/action reserve, default proposed 4s cap6s; không thêm delay hoặc wait loop. Tách compute/IPC/preflight/dispatch/ACK, shadow không chờ. Reserve SWAP/card/QTE theo evidence hiện có.

4. Đặt SLO đo được cho BASIC disabled/shadow overhead, p50/p95/p99/max, cancellation/Stop và diagnostics. Không dùng benchmark 22.901ms một fixture làm end-to-end proof. Giá trị chưa có baseline ghi PROPOSED và chỉ cho phép calibrate trước pilot.

5. Chốt dataset tiers: synthetic regression, existing incident replay, shadow coverage và live holdout; chia theo match/session/time. Không bắt buộc thu hàng trăm trận trước pilot kỹ thuật; coverage thiếu phải khai báo.

6. Chốt pilot nhỏ từng profile (đề xuất 3–5 valid attempts/arm), E1 cohort cap/stop/metrics và E2 soak mặc định25 max30. Mỗi live batch được kích hoạt riêng; không tự mở rộng mẫu để tìm PASS.

7. Định nghĩa energy tổng mọi attempt/WIN, throughput, W/L/UNKNOWN/abort/fallback; block assignment/confounders, CI95%, margin/no-promotion. Mốc50/arm chỉ là đề xuất cap kỹ thuật, không đủ mặc nhiên chứng minh win-rate.

8. Chốt failure matrix: malformed/late/unsupported/hang/crash/queue/disk/Stop/config mismatch; expected baseline hoặc fail-closed theo existing gates. Thêm calibration mismatch/conflict, same-burst order UNKNOWN, unexamined boss ties và opaque baseline effect; chốt narrow validation cho Demon3+5/retained Shield/bait với NOT_OBSERVED thay unlimited retries.

## Gate bắt buộc

- Có acceptance rubric số đo/tolerance/sample count cụ thể hoặc trạng thái PROPOSED cần calibrate; chưa có kết quả giả.
- Tách technical acceptance, model validation, efficacy live; INCONCLUSIVE giữ BASIC default.
- Protocol không tự cấp unlimited live, không thêm flow/read/capture hoặc blocking logging.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- docs/phase5/specs/5a3_telemetry_deadline_acceptance.md
- docs/phase5/specs/5a3_bounded_live_protocols.md
- Report `docs/phase5/reports/5a3_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5B.1](5B1_OFFLINE_SNAPSHOT_REPLAY_AND_TELEMETRY.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
