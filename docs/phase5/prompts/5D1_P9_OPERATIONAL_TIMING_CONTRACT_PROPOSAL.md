# 5D.1-P9 — Chốt đề xuất timing khả thi, offline

**EXECUTED OFFLINE 2026-10-14 / PROPOSAL COMPLETE / USER DECISION PENDING.**
[Report](../reports/5d1_p9_report.md), [proposal](../research/5d1_p9_operational_timing_contract.md).
Không code/native/input activation; STOP P9. Scope dưới đây giữ làm lịch sử
của milestone đã thực hiện. Parent
[P8](../reports/5d1_p8_report.md). Đọc AGENTS, STATUS/ROUTER/capability, contract
mục3–6, P3 clock feasibility/P4 evidence và P8 all-attempt analysis. Bảo toàn
source/worktree/parent artifacts; không reset accepted work.

P8 có551valid local samples, không prove finite native U. Không yêu cầu thêm
trận để tìm một max/p99 rồi gọi đó là hard bound. Mục tiêu P9 là một đề xuất
thiết kế cụ thể giúp user quyết định về timing trong flow đã có.

## Scope

Docs/file-only research và review relevant code. Không sửa Python/runtime,
provider/input/UI/preferences, không prepare/activate native, enumerate/attach/
RPM/capture/input/network/game call, không chạy tests/soak/build/version/Git
mutation. Không tiếp tục Unity candidate chưa verify hoặc thêm clock reader.

## Đầu ra bắt buộc

1. Trace các gate đang thực sự dùng trong source hiện hành: snapshot observation
   time/raw integer, budget/reserve/return margin, finite-U loader, bounded wait,
   existing freshness/preflight/ACK, activation/circuit breaker. Dẫn file/line/
   hash, phân biệt proven software behavior với physical assumptions. Kiểm cả
   proposal timeout, BASIC fallback và phần random theo quyết định user P2.
2. Hoàn thiện đúng một recommended operational timing contract cho opt-in pilot,
   kèm bảng before/after so với strict proof contract hiện tại. Vẫn ghi U và
   transport UNKNOWN; không tạo một U giả từ1s quantization, P8 max read span,
   anchor changes, RTT hoặc timer update cadence. Có phương án giữ BASIC nếu
   user không chấp nhận residual risk; không yêu cầu thêm room/live lúc này.
3. Chốt tên/units/provenance cho mọi clock/age/reserve/budget. Nếu dùng raw
   remaining trừ host elapsed, ghi rõ đó là operational projection có stale-
   message/pause/FX uncertainty, không bảo đảm server deadline. Không cần đọc
   thêm field hoặc tính current Unity time để gọi phép tính này là proof.
   Budget phải bắt đầu từ original observation, tính BASIC trước, cùng data cho
   worker, trả sớm/Stop; không reset deadline tại submit/wait/fallback. Reserve
   phải tính đường final gate/input hợp lệ của đúng transport/cohort, phân biệt
   optional random với mandatory pacing. Chưa đủ dữ liệu số thì ghi pending,
   không tự chọn1–2s và không chuyển pending thành input permission.
4. Nêu guard/invalidation/circuit breaker/fallback, zero-extra-read contract,
   all-attempt telemetry, giới hạn residual late-action risk và measurable
   acceptance/failure/stop criteria. Không hứa “BASIC luôn an toàn” hoặc cho
   fallback bypass existing state/preflight. Không sinh input thứ hai sau ACK
   uncertain; điều đó vẫn thuộc existing owner/recovery.
5. Tách các câu hỏi có thể đo bằng future BASIC-only reserve calibration khỏi
   điều không thể prove bằng vài trận. Nếu đề xuất protocol sau user decision,
   dùng lại3/max5TOTAL đã review hoặc giải thích khác biệt; chưa kích hoạt,
   không thu native R trong P9, không soạn vô hạn các research/live batches.
6. Tạo một decision package gọn, concrete/reviewable: chính xác doc/code gates
   sẽ cần đổi ở milestone sau, những gate/flow giữ nguyên, điều kiện áp dụng,
   rollback và điều user cần chấp nhận. Không tự áp dụng thay đổi hoặc gọi
   authorization P2 về decision budget là chấp thuận mọi timing assumption mới.

Report5d1_p9, before/after proposal, source/artifact preservation, update status/
router/capability. Chọn đúng một next theo bằng chứng hoặc đưa concrete user
decision nếu cần; không triển khai tiếp. **STOP P9.**
