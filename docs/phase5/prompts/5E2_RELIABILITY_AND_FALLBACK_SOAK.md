# 5E.2 — Soak độ ổn định và fallback

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. 5E.1 technical gate sạch; efficacy verdict ghi rõ; chỉ soak capability thực sự accepted.

Soak reliability, fallback và Stop trong phạm vi được công bố; không mở rộng gameplay/model scope.

## Thực hiện trong phạm vi

1. Freeze source/config/capabilities; BASIC giữ mặc định, E1 PROMOTE chỉ cho scoped opt-in. Không bật profile đã unsupported chỉ để đủ soak matrix.

2. Live activated default tổng25 attempts, hard cap30 theo A3; có BASIC control block và REASONING/shadow block accepted, counts đóng băng trước chạy. Invalid/abort tính vào cap; không bonus retry.

3. Quan sát startup→match→result→re-entry→bounded Stop/resume theo path accepted; không đổi lifecycle/navigation/read/capture/executor để chữa lỗi planner.

4. Fault matrix crash/hang/stale/queue/log sink/Stop tiếp tục offline tại boundary; live chỉ lỗi tự nhiên hoặc safe cancellation đã prove, không cố inject input sai.

5. Đo fallback frequency/reasons, circuit breaker, p50/p95/p99/max deadlines, action latency, CPU/memory growth, queue/retention/dropped diagnostics và worker cleanup.

6. Verify planner lỗi không tạo technical recovery/PASS giả/idle reset/double input; baseline valid tại preflight. Disabled BASIC không có worker hoặc overhead nặng.

7. Dừng batch khi safety/flow regression, write incident/remediation; không cố hoàn tất target. Cases chưa xảy ra ghi NOT_OBSERVED, không claim live fault coverage từ offline.

8. Chỉ chốt package gate khi declared scope đủ reliability; unexplained resource/log growth hoặc unbounded shutdown phải sửa.

## Live gate chung

Chỉ chạy live khi người dùng kích hoạt batch bước này và chuẩn bị game.
Chưa kích hoạt: làm runbook/offline thuộc scope, ghi live PENDING và STOP.
Người dùng vận hành game; không computer-use tự chơi. Không extra reads/captures
và không inject fault gây input sai. Stop/user abort hoặc wrong-turn/stale/
duplicate/ownership/ACK conflict/flow regression phải dừng batch ngay.
Mọi invalid/abort đều tính vào cap; tăng cap cần yêu cầu mới.

## Gate bắt buộc

- Zero new critical violation; stop/cancel bounded, no orphan controller/worker.
- Logging overhead/retention và fallback SLO đạt; evidence source/scope rõ.
- Soak không là win-rate proof; no default/promotion change ngoài E1 recommendation.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Bounded soak report, resource/latency/fault/Stop evidence.
- Frozen packaging scope, supported/experimental/disabled profile matrix.
- Report `docs/phase5/reports/5e2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5F.1](5F1_PACKAGED_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
