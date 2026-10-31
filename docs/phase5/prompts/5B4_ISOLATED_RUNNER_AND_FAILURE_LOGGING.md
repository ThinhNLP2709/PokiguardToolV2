# 5B.4 — Runner cô lập lỗi và logging có giới hạn

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **OFFLINE**. 5B.3 PASS STRONG; pure planner không có authority.

Cô lập planner failures và diagnostics, prove fallback/cancellation offline trước integration.

## Thực hiện trong phạm vi

1. Implement bounded runner boundary với immutable jobs, source/config identity, cancellation, latest-job/backpressure, late result discard và circuit breaker. Chọn process/thread phù hợp bằng evidence; pure Python compute có hang phải có cách không giữ controller.

2. Worker chỉ nhận snapshot/features, không provider/process memory/capture/executor/foreground/input handle. Tắt BASIC không spin up worker hoặc import model nặng.

3. Baseline incumbent phải sẵn cho caller; crash/hang/malformed/source mismatch không bắt caller chờ hết timeout nếu đã biết lỗi. Không auto-retry vô hạn.

4. Implement diagnostics bounded enqueue/writer/retention; compare separate reasoning sink với common namespace/filter. Không double full traces; queue/disk failure vẫn trả fallback và tăng dropped/degraded counters.

5. Record error đầu tiên đủ stack/job/source correlation, repeats rate-limit/count; không log storm. Stop/cancel/shutdown bounded, không drain vô hạn hoặc orphan worker.

6. Fault injection offline cho crash/hang/IPC corruption/queue full/permission or disk write failure/cancel/late completion; đo compute+serialization+IPC+logging tails và memory.

7. Chốt lại các SLO PROPOSED còn thiếu từ A3 bằng số đo và giải thích trước khi integration; không nới gate chỉ để che lỗi.

## Gate bắt buộc

- Fault runner/logging không chặn baseline hay Stop; jobs không có input authority.
- Có evidence lựa chọn log sink/runner và overhead; log failure được quan sát, không claim logged giả.
- Offline tests đủ boundary faults; chưa production wiring hoặc live input.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Isolated runner + diagnostics implementation và focused fault tests.
- Measured runner/log sink decision, updated budget/SLO and capability limitations.
- Report `docs/phase5/reports/5b4_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5C.1](5C1_SHADOW_DECISION_SEAM_ADAPTER.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
