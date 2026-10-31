# 5D.1-P2 — Kết quả kịp lượt, activation và chuẩn bị calibration SWAP

**TARGETED OFFLINE_INTEGRATION. Đã thực thi offline; closure tại P2 report.**
Parent: [D1-P1 report](../reports/5d1_p1_report.md).
Return: [D1 pilot](5D1_SIMPLE_CAREFUL_PILOT.md), chỉ sau readiness đủ.
Đọc AGENTS, [contract](../EXECUTION_CONTRACT.md), STATUS/ROUTER, P1 report,
[calibration draft](../research/5d1_swap_calibration_preparation.md), A3 timing/SLO.

## Lỗi/thiếu sót cụ thể và cách tái hiện

P1 đã nối immutable state → isolated runner → completed selector.31/31 offline
gates và2039 tests PASS. Nhưng positive controller fixture cần pre-admit và chờ
worker **trước controller.run**. First observation tại root giữ BASIC ngay;
disposable spawn + duplicate BASIC preparation mất khoảng0.7s trên fixture.
Đây chưa phải giải pháp timely selection cho lượt mới trong game.

Reproduce bằng `tests.test_reasoning_pilot.PilotControllerTests` và
`tools/qualify_reasoning_pilot.py` với output directory mới. Source/evidence:
`docs/phase5/artifacts/5d1_production_bridge_v1/qualification_v3/`.
Minimal model vẫn giữ R/E unknown; fixture ấy không có override. UI/launch chưa
nối factory; calibration/build attestation hiện do caller cung cấp, chưa có
loader kiểm artifact thật. Những giới hạn này không phải BASIC regression.

## Việc cần làm trong bước này

1. Giải quyết timely admission trong reasoning boundary: có thể warm/reuse
   isolated worker hoặc precompute từ **state do flow hiện có cung cấp**, bỏ
   duplicate preparation nếu có cách bound incumbent chính xác. Không giữ
   result từ board/turn trước cho board mới; no deadline reset. Không thêm
   provider/capture/memory poll mới, không cố trì hoãn BASIC để đạt PASS.
   Nếu bất khả thi trong contract, ghi conflict và proposal scope cụ thể,
   giữ production gate đóng; không âm thầm đổi flow.

   Amendment theo người dùng2026-10-12: cho phép bounded interruptible decision
   wait sau khi đã có BASIC; cùng state/thẻ, trả sớm khi worker xong, timeout/
   lỗi giữ BASIC. Bỏ duplicate BASIC preparation trong nhánh này. Riêng nước
   suy luận valid được bỏ optional random reaction/inter-click jitter, giữ
   mandatory input pacing/gates. Xem contract mục3; không tự giảm R/U.
2. Prove actual producer→worker→root/fresh/final→input/ACK với native fakes và
   timeline tạo từ chính controller; **không pre-admit/chờ fixture trước run**
   làm positive acceptance. Log ready/missed root, admission/preparation/IPC/
   completion/checkpoint timestamps. Zero overrides phải ghi đúng, không PASS
   efficacy/all-fallback. Có thể dùng synthetic effects cho software positive
   nhưng không promote sang model thật. Minimal model/effects unknown giữ bounds.
3. Nối explicit per-run pilot opt-in đến factory và frozen authority ở desktop/
   session boundary tối thiểu. Ordinary preferences BASIC/shadowOFF giữ nguyên;
   production choice chỉ selectable sau required gates. Loader kiểm SHA/source/
   build/input mode/timer/calibration/cohort, expiry/change/absence → gated/BASIC.
   Không coi chuỗi `NATIVE_INPUT_CALIBRATED` tự nhập là chứng cứ đo.
4. Chuẩn bị optional timing observation trong accepted SWAP path để ghi
   preflight-start→required-second-click-end, monotonic clock, accepted timer
   read interval và kết quả final preflight/input/ACK vào buffered telemetry.
   Không extra read/capture/input; không disk/flush trên action/Stop. Disabled
   instrumentation phải giữ trace và latency accepted. Verify đúng clock/
   quantization bằng reverse hiện có; U chưa bound được vẫn đóng gate.
5. Qualify affected software/diagnostics scheduling, resource lifecycle và
   Stop/fault/pending path theo A3/C3. Tái dùng backend đã accepted nhưng không
   lấy old C3 soak/CPU làm proof của producer mới. Kiểm worst-case ready/miss,
   worker/sink faults, per-run cleanup/restart không overlap owner/process.
6. Hoàn thiện runbook + draft BASIC calibration **default3/max5 TOTAL attempts**
   cho một SWAP/input/cohort. Trong P2 không chạy live. Không đếm draft là
   calibrated, không mở D1 reasoning bằng fake reserve; N nhỏ chỉ descriptive.

Allowed: reasoning boundary/runner scheduling + minimal immutable opt-in/
telemetry hooks trong desktop/farm/basic_auto_bot, tests/tools/docs cần thiết.
Không sửa BASIC ranking, provider/capture order, executor/pacing/QTE/ACK/room/
result/lifecycle, game/V1 files hoặc network/memory writes. Reuse solver.

## Đầu ra và exit

- Report `docs/phase5/reports/5d1_p2_report.md`, immutable before/after/source/
  config/model manifests, timings/raw traces, actual override count và rõ scope
  native fakes. Full regression khi thay integration/desktop boundary.
- Return D1 chỉ khi software activation/timeliness và required native timing
  evidence đều đủ. Nếu native calibration còn thiếu nhưng software đã ready,
  chọn **một targeted BASIC calibration preparation/activation prerequisite**,
  chưa chạy nó. Nếu software chưa đủ, targeted remediation đúng nguyên nhân.
- Update capability/STATUS/router. **STOP tại P2.** Không live/game attach/input,
  build/version/commit/push/tag/release hoặc chạy D1/D2 tự động.
