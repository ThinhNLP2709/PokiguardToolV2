# 5D.1-P4 — Evidence tối thiểu để giải quyết tuổi timer

**EXECUTED FILE-ONLY / RESEARCH COMPLETE / NATIVE U UNKNOWN / STOP P4.**
Closure: [P4 report](../reports/5d1_p4_report.md). Original procedure below retained.
Parent P3 report và `research/5d1_p3_clock_feasibility.md`. Chưa live/D1/D2.

Đọc AGENTS, contract mục3, STATUS, P3 exact source/tests/resource/SLO và remaining
gates. Không sửa gameplay, provider loop, pacing, worker policy hoặc mở UI
REASONING. Không build/version/Git; không attach/capture/input tự động.

Làm đúng một targeted evidence procedure: lần theo existing reverse của
MatchService timing ingress và Unity Time native icall **bằng file-only đọc**,
để trả lời liệu có thể bound tuổi raw integer timer trong read contract đã có.
Xác minh current build, nguồn anchor/current time, pause/FX/transport semantics,
và cách quy về host monotonic. Function pointer không là time value; không đoán
offset/RVA/Unity singleton, không gọi hàm hoặc inject vào game.

Nếu tìm được derivation finite và kiểm chứng được, ghi đúng nguồn/file/line/hash,
năm thành phần U, assumptions và validity/freshness gates; soạn phép quan sát
read-only có giới hạn nếu thật sự cần live để phân biệt giả thuyết. Chưa chạy
phép quan sát đó. Nếu cần mở rộng accepted read contract, nêu chính xác những
field/read mới, chi phí/binding và giới hạn, để chốt scope trước implementation.

Nếu không thể bound trong contract hiện có, ghi UNKNOWN với lý do cụ thể và
một lựa chọn remediation tối thiểu có thể review; không gán số từ quantization,
không chơi thêm trận chỉ để tự pass. Native R calibration 3/max5 TOTAL chỉ được
đề xuất khi clock measurement và remaining P3 software gates thực sự đủ dùng.
Không kế thừa cap6 C3/cap12 D1 draft làm live authorization.

Review remaining P3 SLO limitations đúng scope; không gọi whole-app accepted từ
prepared selector/worker-only CPU. Không tự rerun lịch sử hoặc overwrite artifact.

Output `reports/5d1_p4_report.md`, verified symbol/board docs nếu có findings,
machine-readable clock evidence hoặc UNKNOWN ledger, cập nhật router/capability,
chọn **một** next concrete rồi STOP. Báo user cần mở game chỉ khi có phép đo
cụ thể và hữu ích; no arbitrary farm-to-calibrate.
