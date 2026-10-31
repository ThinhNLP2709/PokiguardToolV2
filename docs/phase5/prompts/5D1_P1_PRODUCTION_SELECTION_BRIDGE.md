# 5D.1-P1 — Bổ sung production bridge trước pilot

**Targeted prerequisite, OFFLINE_INTEGRATION. Đã thực thi2026-10-12; PARTIAL.**
Closure: [P1 report](../reports/5d1_p1_report.md). Software bridge offline đã có,
timely first-root/native calibration/operator activation còn thiếu; current
next là P2 theo STATUS/ROUTER. Nội dung yêu cầu gốc bên dưới giữ nguyên.
Parent: [D1 readiness report](../reports/5d1_report.md).
Return: [D1 pilot](5D1_SIMPLE_CAREFUL_PILOT.md).
Đây là một bước lấp capability thiếu, không chạy lại toàn bộ C4/C3 và không
thay kết luận của các report lịch sử.

## Đọc trước và bằng chứng tái hiện

Đọc AGENTS, [contract](../EXECUTION_CONTRACT.md), [STATUS](../STATUS.md),
[ROUTER](../ROUTER.md), D1 report/runbook, C4 report và A3 deadline/reserve spec.
[Readiness landmarks](../artifacts/5d1_preparation_v1/readiness_review.json)
gắn source260 fingerprint; inspect đúng các boundary ấy, bảo toàn worktree cũ.

Hiện tại UI/launch chặn REASONING, host chỉ nhận native fake PID0 và capability
OFFLINE_CONTEXT. Shadow thiếu essential binding/timing/model; publication
policy_decision đến sau root selector. Không có producer completed proposal
cho selection thật. C4 chỉ prove synthetic model/reserve và injected proposal.

## Phạm vi thực thi

1. Thiết kế và nối producer immutable snapshot/job từ state/config/BASIC đã có
   trong decision slice accepted. Ghi admission/completion timing để chứng minh
   proposal có thể sẵn trước checkpoint, không chỉ đến sau dispatch. Không
   thêm game reader/capture/poll/sleep hoặc vòng chờ planner. Nếu không thể nối
   trong contract thì nêu conflict cụ thể; không lách bằng delayed BASIC.
2. Tái dùng isolated runner, bounded sink và selector C4. Tạo production/pilot
   capability riêng có evidence, không chỉ xóa PID0/OFFLINE guards hoặc đổi
   context string. Scope chỉ SIMPLE/CAREFUL ordinary SWAP→SWAP + loadout đã
   prove. Immutable source/job/generation/controller hash/all cells/actor/
   resource/config/model/version/timer/reserve phải bound; invalid → BASIC.
3. R1 dùng proxies có nhãn; không yêu cầu full damage simulator. Effect thiếu
   giữ bounds/missingness, không copy SYNTHETIC Health20 hoặc gán unknown0.
   Không promote R2 hoặc user Demon certificate sang account/boss chưa bound.
   Chỉ completed robust comparison mới eligible, no partial/late result.
4. Opt-in phải explicit, scoped và locked per run. Giữ default BASIC và
   shadowOFF/preferences cũ; unsupported profiles/loadouts/families vẫn BASIC.
   Baseline EVOLVE/CAST/QTE/PASS/continuation giữ nguyên, không ép SWAP.
5. Map exact timer source/monotonic observation age và accepted inequality,
   preflight-to-required-input boundary, family/input mode, U/R/M. Đo software
   overhead offline và tận dụng evidence accepted sẵn có, không gọi native
   fakes là real-input tail. Nếu chưa calibrate thật thì giữ live gate đóng,
   chuẩn bị riêng targeted BASIC calibration default3/max5 total attempts
   theo A3, **chưa kích hoạt/chạy**, không ngầm tăng cap D1.
6. Runtime bridge và diagnostics đều lỗi-cô-lập: no provider/input trong
   worker, no blocking disk/flush/join trong action/Stop; faults disable AI,
   BASIC fresh-valid tiếp tục; after-send giữ pending/ACK owner cũ.

Allowed minimal files: reasoning boundary modules/new bridge, optional hooks
trong basic_auto_bot/farm_run/desktop controller/settings/UI/preferences nếu
cần để truyền opt-in immutable; tests/tools và docs tương ứng. Không sửa BASIC
ranking/gameplay, provider/read/capture order, executor/QTE/ACK/lifecycle.
Không broad refactor, offset guessing, game/V1 changes hoặc network gameplay.

## Verification và return gate

- Meaningful integrated tests: real context/native boundary fakes được gắn
  scope rõ; completed override đi qua root/fresh/final và đúng input/ACK;
  unsupported/malformed/missing/stale/late/source/config/generation/reserve
  mismatch, worker/log fault, Stop và pending không duplicate/replacement.
- Actual producer → runner → selector chain, không chỉ inject completed offer.
  Số0 observed override phải được ghi đúng, không acceptance bằng all fallback.
- Disabled full trace/read/capture/action parity với accepted source; no heavy
  imports/resources/worker when disabled. Immutable settings giữ nguyên;
  account/loadout missingness không tự biến thành observed model binding.
- Full regression khi thay integration/desktop boundary; source manifest và
  affected-scope qualification. Không relabel C3 historical soak/live smoke
  thành proof của source đã đổi; chỉ revalidate affected gates có lý do.
- Report `docs/phase5/reports/5d1_p1_report.md`, update capability/STATUS/router.
  Return D1 chỉ khi production path + required offline gates đủ; reserve/live
  readiness thiếu thì PARTIAL và next targeted prerequisite cụ thể. Không
  tuyên bố pilot ready hoặc chạy12 trận với synthetic reserve.

Không live, game attach/read/input, build/version/commit/push/tag/release trong
P1. Chỉ chọn một return/next và **STOP**, không tự thực thi D1/D2.
