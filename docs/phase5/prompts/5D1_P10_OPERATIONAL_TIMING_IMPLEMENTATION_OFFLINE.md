# 5D.1-P10 — Triển khai operational timing và readiness offline

2026-10-14. **EXECUTED / PASS STRONG SCOPED OFFLINE / NATIVE RESERVE PENDING.**
[Report](../reports/5d1_p10_report.md). STOP P10; scope dưới đây giữ làm lịch sử.
No native/input activation.
Người dùng đã chốt: “cứ triển khai tôi sẽ nghe theo ý bạn”.
Parent [P9](../reports/5d1_p9_report.md),
[exact accepted decision](../artifacts/5d1_operational_timing_v1/accepted_decision.json).
Proposal P9 giữ bytes/hash lịch sử, acceptance ghi riêng.

## Scope

Thực hiện mục9 của [P9 contract](../research/5d1_p9_operational_timing_contract.md).
Type/schema/context operational riêng; U/transport/alignment UNKNOWN; preserve
strict loader. BASIC-first, same state, một deadline từ observation, reserve
đủ controller/input/fallback; zero additional game reads/capture. Host-only
timing probes chỉ khi explicit opt-in; ghi all-attempt/fault/Stop evidence.
Source/build/host/config/cohort pin, cap/expiry/claim/rollback, UI gated.

Không game/native attach/query/input/network, không native R calibration/live
pilot, không game patch/write, không sửa solver/PlayStyle/input pacing hoặc
ACK/lifecycle/entry/recovery, không build/version/Git mutation/preferences thật.
Không spawn subagents. New runtime chỉ trong V2; preserve dirty accepted work.

## Required closure

1. Implement accepted contract với exact type separation và native-model
   UNKNOWN protections, fallback/error/late/Stop and one absolute deadline.
2. Host-only observation/decision/fresh/final/input return receipts: thêm H
   decision-exit→preflight vào I hiện có; giữ zero extra reads/disabled parity.
3. File-only loader/readiness và frozen explicit session cap/expiry/one-shot
   claim; implementation acceptance không là activation hoặc native reserve.
4. Meaningful unit/controller/native-fake tests, exact source/AST/read/input/ACK
   parity khi disabled, negative authority/timing/model/owner/Stop coverage;
   affected checkpoint/CPU/Stop/bounded memory stress trên current source.
5. Preserve source predecessors/parent artifacts/game/preferences/HEAD; reports,
   manifest/current bindings và canonical docs. Full suite phù hợp trước closure.
6. Chỉ chọn một next bounded BASIC calibration package nếu offline gates đạt;
   chưa chạy nó. Nếu thiếu native measurements, giữ rõ PENDING, không fabricate
   R/U hoặc gọi offline performance là native/whole-app acceptance. **STOP P10.**
