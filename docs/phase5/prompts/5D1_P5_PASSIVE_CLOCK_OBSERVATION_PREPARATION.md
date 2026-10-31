# 5D.1-P5 — Chuẩn bị passive clock observer riêng, offline

**OFFLINE ONLY / SELECTED ONLY / NOT EXECUTED.** Parent
[P4](../reports/5d1_p4_report.md), exact
[proposed observation contract](../research/5d1_p4_clock_evidence_and_observation.md).

Đọc AGENTS, EXECUTION_CONTRACT mục3, STATUS/ROUTER và clock ledger P4.
Không sửa accepted gameplay/provider/scan/capture/input/ACK/room flow hoặc
production timing authority. BASIC/shadowOFF giữ default; UI REASONING gated.
Không attach game, enumerate process, capture, phát input, gọi game function,
ping/request/network, build/version/Git hoặc mở native R calibration/D1/D2.

Triển khai đúng một standalone read-only observation utility trong V2, **chỉ
prepare/test offline, chưa chạy native**. Reuse verified root/runtime identity
primitives, không rewrite provider. Allowed extra reads chỉ hai48B blocks
MatchService `+0x1BC..+0x1EC`, decode năm verified fields; native Unity candidate
và SpeedGuard/RTT/payload reads không thuộc scope. Frozen manifest phải liệt kê
mọi base/root/identity RPM call/bytes ngoài incremental96B, source/build hashes,
host monotonic và output/cap. Nếu reuse helper có unbounded scans/retries hoặc
không inventory được, đóng hạn chế rõ, không auto-run native.

Offline meaningful cases: exact b6 offsets/valid types; A/B mismatch; missing
anchor/paused/FX reanchor ambiguity; nonfinite; source/process/match/turn drift;
cap60s/600samples/≤10Hz/no catch-up; Stop giữa reads; partial read/error; bounded
log loss/status; no write/function/input/network authority. A/B equal không là
atomic/freshness proof. Output pin source/clock/identity/full all-sample ledger;
verdict LOCAL_OBSERVATION_ONLY hoặc INCONCLUSIVE, luôn native_U_ms:null và input
authority false. Không tạo activation artifact bằng observations này.

Chuẩn bị command/runbook reviewable cho một future user-operated manual window,
không chạy command. Chưa có game cũng hoàn tất software/parser/cost tests.
Nếu muốn xin native activation, phải nêu mục đích phân biệt hypotheses cụ thể,
exact reads/cost/limits và chỉ hỏi sau khi artifact đã usable. Đây là diagnostic
contract ngoài production, không quyền thêm reader vào farm hoặc sửa mục3.

Không chạy lại2071full gameplay tests/30min soak cho utility độc lập nếu source
gameplay được hash-preserved; test utility và binding/fakes phù hợp. Bảo toàn
P3/P4 artifacts, ordinary preferences và game files. Giữ partial/failed output,
không repeat hoặc kéo dài live để tìm PASS.

Output report5d1_p5, exact source/review/tests/cost manifest + standalone runbook,
update router/capability. Review rõ transport_age vẫn UNKNOWN và local observation
không chữa mọi deadline gate. Chọn **một next concrete** rồi STOP. Chỉ yêu cầu
người dùng mở game khi phép quan sát riêng đã sẵn sàng và được kích hoạt; chưa
farm, R calibration hoặc reasoning pilot.
