# 5B.1 — Snapshot/replay/telemetry offline

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.
- [Demon Shield incident review](../research/demon_shield_setup_incident_review.md)
  và [10 archived source snapshots](../research/artifacts/demon_shield_incident_evidence_20261009.json).
  Map incident schema sang DTO thật; giữ source line/hash và cùng-match split,
  không coi missing boss swap là observed hoặc summary145+77 là222 distinct matches.

## Entry và mục tiêu

Mode: **OFFLINE**. 5A.1–5A.3 PASS STRONG; người dùng đã yêu cầu bước offline này.

Triển khai immutable snapshot, replay dataset và telemetry serialization offline; chưa nối runtime.

## Thực hiện trong phạm vi

1. Inspect chỉ source/solver/schema cần thiết để tái sử dụng. Lập implementation map nhỏ theo repo hiện tại, không tạo các file giả định chỉ vì nghiên cứu từng nêu tên.

2. Implement pure DTO/schema/serialization và replay runner từ fixture/log hiện có. Missing source/feature giữ UNKNOWN, không dùng default0 thay dữ liệu thiếu.

3. Nối state→candidate→chosen action→outcome bằng identity rõ, tách observation/model prediction/reviewer label. Outcome không đủ attribution ghi UNKNOWN; không tạo nhãn cho candidate chưa đi.

4. Manifest dataset ghi game/source/schema/profile/version, provenance, distinct turn/match counts, thiếu coverage; synthetic không được gọi là live.

5. Tái sử dụng solver simulation primitive và legality contract; chưa import/wire production FarmRunner/provider/executor. Offline tooling không attach process/capture/input.

6. Focused verification cho roundtrip, identity rejection, missingness, split không leak cùng trận, corrupted replay và immutable config. Không dựng test mirror implementation.

## Gate bắt buộc

- Replay chạy từ dataset khai báo, deterministic theo fixed input/work budget; attribution không bị trộn.
- Không production wiring/UI/worker/live/extra reads; BASIC runtime untouched.
- Coverage matrix phân biệt fixture/incident/live và còn thiếu.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Pure snapshot/replay/serialization components + focused tests theo cấu trúc repo.
- docs/phase5/datasets/README.md và manifest references; không copy raw ảnh/game files.
- Report `docs/phase5/reports/5b1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5B.2](5B2_OFFLINE_ADAPTIVE_UTILITY_PLANNER.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
