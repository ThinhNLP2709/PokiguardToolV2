# 5D.1-P6 — Một cửa sổ passive clock observation, chơi tay

**SELECTED ONLY / NOT EXECUTED / NOT ACTIVATED.** Đọc AGENTS, contract mục3,
STATUS/ROUTER, [report P5](../reports/5d1_p5_report.md),
[runbook đóng băng](../research/5d1_p5_passive_observer_runbook.md) và final review.

Chỉ thực hiện khi người dùng kích hoạt cửa sổ diagnostic này và chuẩn bị game/
explicit PID. User tiếp tục roadmap không tự cho phép tool farm hoặc REASONING
input. Nếu activation/PID/game chưa sẵn sàng, chỉ rà offline binding, rồi xin
đúng thông tin còn thiếu; giải thích mục đích và đọc/cost/caps theo runbook đã có.
Không tự enumerate/attach game trước activation. Không chạy native R calibration,
không mở lại C3cap6/D1draft12, không đổi production timer/flow/UI gate.

Kiểm source279/review SHA và exact b6 hashes. Source/build/clock đổi thì giữ
mismatch, quay về targeted review; không re-prepare ngầm để bỏ gate. Observer
standalone; auto/farm phải dừng, người dùng chơi tay tối đa1trận. Không input,
capture, gọi game function, network hoặc đọc field ngoài allowlist P5.

Đúng một window≤60s admission/600samples/≤10Hz, không catch-up hoặc resume.
Dùng đúng command/output độc nhất trong runbook; không thực thi lệnh trước
activation. Ctrl+C/lỗi/drift/cap chấm dứt; giữ cả partial/failed output. OS call
stall không preempt được, không khẳng định wall-clock/Stop native bound chưa đo.
Không repeat hoặc thêm trận để tìm case/đủ mẫu/PASS.

Phân tích tất cả attempts, ledger/counters/RPM/query/export/cleanup/source/final
binding. Phân biệt raw giữ nguyên/anchor đổi và paused/FX confounds, giữ không
có Unity-current clock. First-seen host là interval quan sát, không tick receipt.
Không lấy sample max, RTT hoặc integer remainder làm finite U. Kết quả chỉ
LOCAL_OBSERVATION_ONLY/INCONCLUSIVE; native_U_ms và input_authority giữ null/false.
Nếu transport/server alignment thiếu thì phải nói rõ quan sát chưa chữa được
deadline gate; không bật REASONING hoặc tự sửa safety contract.

Report5d1_p6 có exact binding, user-operated scope, useful/invalid/dropped counts,
cả failed/partial rows và limitations. Bảo toàn sources/game/preferences/parent
artifacts. Không chạy lại full gameplay suite hoặc soak vì bước chỉ quan sát.
Update STATUS/router/capability, chọn đúng **một next concrete** theo evidence,
chưa thực thi next. **STOP P6.**
