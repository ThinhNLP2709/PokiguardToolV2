# 5L.2 — Learned model shadow, tùy chọn

Chỉ thực hiện bước này khi được yêu cầu và L1 PASS STRONG; không tự mở nhánh model.

## Đọc trước

AGENTS, [contract](../EXECUTION_CONTRACT.md), [status](../STATUS.md),
[router](../ROUTER.md), L1 model card/hash/report, A3 latency/log protocol,
B4 runner và C3 parity reports. Mode: SHADOW_MODEL.

## Mục tiêu và phạm vi

1. Load model trong runner boundary đã accepted, immutable feature/model/config
   version và bounded inference budget. Không load vào BASIC disabled hot path.
2. Tái sử dụng shadow seam C1; model không đổi action hoặc làm baseline chờ.
   Không thêm reader/capture/IPC roundtrip trong dispatch critical path.
3. Compare model + utility vs utility + baseline với evidence/UNKNOWN/support.
   Shadow outcome chỉ thuộc action thực sự đã đi, không counterfactual win-rate.
4. Error/missing model/OOD/NaN/timeout/crash phải degrade về planner không model
   hoặc BASIC theo existing contract; bounded circuit breaker/logging.
5. Focused offline integration/fault validation, measure serialization/inference/
   log overhead tails và cleanup. Source/capability changes khai báo revalidation.
6. Nếu shadow live được kích hoạt: tối đa5 attempts tổng, BASIC hoặc planner
   không model vẫn chọn action theo control đã freeze; model chỉ observe.
   Chưa live thì report PARTIAL_LIVE_PENDING, không mở L3.
7. Người dùng chuẩn bị/vận hành game; không computer-use, extra read/capture,
   fault injection có input sai hoặc unlimited retry. Stop/regression dừng ngay.
8. Không tune model trên shadow holdout để claim đã validate cùng sample; thay
   model phải quay gate L1 và version/hash mới.

## Gate và đầu ra

- Model shadow không đổi flow/action/read/capture/ACK/pacing và đạt overhead SLO.
- Fault model/log isolation đủ, no orphan worker và BASIC fallback giữ.
- Report `docs/phase5/reports/5l2_report.md`, model/hash/source/config manifest,
  measured tails/drift/support, updated capability/status/router.
- Đủ required evidence → next [5L.3](5L3_OPTIONAL_LEARNED_MODEL_BOUNDED_PILOT.md),
  chọn rồi STOP. Thiếu live/quality → pending hoặc NO_MODEL_PROMOTION; không auto live.
- Không tự build/commit/push/tag/version/release.
