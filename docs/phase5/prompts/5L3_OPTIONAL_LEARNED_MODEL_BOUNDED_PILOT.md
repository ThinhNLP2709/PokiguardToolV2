# 5L.3 — Learned model bounded pilot, tùy chọn

Chỉ sau L2 PASS STRONG và yêu cầu người dùng kích hoạt bounded pilot này.
Đọc [contract](../EXECUTION_CONTRACT.md), [status](../STATUS.md),
[router](../ROUTER.md), AGENTS, L1/L2 reports, A3 protocol và E1 comparison.

## Phạm vi một bước

1. Freeze model hash/source/features/config và một profile/cohort đã technical
   accepted. Existing final preflight/controller giữ authority; model chỉ đề xuất
   qua utility/evidence boundary, không bypass hard legality.
2. Default utility-without-model3 + with-model3 attempts, tổng cap6 cả invalid/
   abort; policy fixed per match, objective/settings/loadout/mode comparable.
   Không tự mở nhiều cohort hoặc update model giữa run.
3. Chạy focused offline malformed/late/OOD/absent-model fallback regression
   trước pilot; không tạo wrong-input faults trong game.
4. Khi live activated và game sẵn, người dùng vận hành game qua flow accepted.
   Không computer-use, extra memory/capture/poll hoặc thay executor/QTE/ACK.
   Stop/user abort/safety/flow violation dừng ngay.
5. Observe model overrides so utility, support/confidence type, deadlines,
   fallbacks, action/ACK outcome thật và all-attempt energy/time/W-L-UNKNOWN.
   Model score không thành xác suất thắng, small pilot không proof efficacy.
6. Nếu lỗi: disable model, retain utility/BASIC scoped baseline và remediation
   parent. Không retrain/retry vô hạn hoặc sửa BASIC để model pass.
7. Đủ technical gate: quay [5E.1](5E1_BOUNDED_GAMEPLAY_COMPARISON.md), freeze lại
   comparison manifest để đánh giá hiệu quả model trước E2/package. Không dùng
   utility-only evidence cũ để promote model mới.

## Đầu ra và STOP

Report `docs/phase5/reports/5l3_report.md` theo [handoff](../HANDOFF_TEMPLATE.md),
model/source/hash/config, bounded results, scoped technical status và router.
Chưa activated hoặc thiếu required evidence → PARTIAL, giữ model gated.
Đủ gate → chọn E1 rồi **STOP**. Không commit/push/tag/build/version/release.
