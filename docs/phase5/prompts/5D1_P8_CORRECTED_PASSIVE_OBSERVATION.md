# 5D.1-P8 — Một passive window với observer đã sửa

**EXECUTED 2026-10-14 / CLOSED — LOCAL_OBSERVATION_ONLY / PARTIAL D1.**
[Report P8](../reports/5d1_p8_report.md). Trước activation, prompt này là
SELECTED ONLY / NOT EXECUTED / NOT ACTIVATED; các yêu cầu dưới đây đã dùng cho
đúng một window. Không dùng prompt này để retry/resume. Đọc AGENTS/contract mục3,
STATUS/ROUTER, [P7 report](../reports/5d1_p7_report.md),
[P7 runbook](../research/5d1_p7_observer_runbook.md), final review và supplemental
diagnostics contract. P6 failed output vẫn nguyên; P8 không resume/reinterpret P6.

Chỉ native sau user activation và chuẩn bị auto-stopped/game/bàn cờ. Có thể lấy
PID hiện hành giúp người dùng bằng đúng một query tên/path đã được nhờ trong
session; không dùng PID cũ, không enumerate/attach trước khi chuẩn bị. Không
tool input/capture/farm, network, game call, native R calibration/D1/D2.

Review/source279/b6/host clock phải khớp; không re-prepare tự động khi mismatch.
Dùng đúng command/output mới độc nhất trong runbook, explicit PID, read-only
rights, không thêm field/read/cost. Đúng1window60s admission/≤600samples/≤10Hz,
no catch-up/retry/resume. User chơi tay tối đa1trận, không cố tạo case hoặc thêm
trận. OS call stall không preempt được, không claim hard wall-clock bound.

Giữ full all-attempt ledger và failure diagnosis. FX=-1 RESET_SENTINEL hợp lệ;
không suy thành current Unity clock hoặc freshness. Nếu float khác lỗi, đọc
field/offset/classification/bits mới, không tự nới gate. Partial/A/B mismatch/
Stop/source drift/cap phải kết thúc, không repeat để tìm PASS. Preserve failed
output/receipt, no dropped-record claims khi chưa kiểm actual file.

Phân tích raw/anchor/paused/FX changes theo source và host bracket; thiếu paired
valid samples thì INCONCLUSIVE. Dù valid vẫn LOCAL_OBSERVATION_ONLY, không
finite timer-age U hoặc transport proof từ sample max/RTT. native_U_ms:null,
input_authority:false và UI/BASIC/shadowOFF giữ nguyên. Không auto-activate AI.

Report5d1_p8 gồm mọi attempts/status/cost/cleanup/final binding, exact hashes,
useful/invalid/dropped, limitations và preservation. Không đổi source hoặc
rerun full gameplay suite/soak ở bước observation. Update status/router/capability,
chọn đúng **một next concrete** theo evidence rồi STOP. Nếu vẫn cần operational
timing contract thay cho hard proof, chỉ chuẩn bị before/after cho user chốt,
không tự thay production safety gate. **STOP P8.**
