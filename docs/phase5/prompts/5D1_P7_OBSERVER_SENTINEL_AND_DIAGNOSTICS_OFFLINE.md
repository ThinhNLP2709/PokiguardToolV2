# 5D.1-P7 — Sửa sentinel/diagnostics observer, offline

**SELECTED ONLY / NOT EXECUTED / OFFLINE ONLY.** Đọc AGENTS, contract mục3,
STATUS/ROUTER, [P6 report](../reports/5d1_p6_report.md), P5 utility/source review
và P6 actual failed ledger/file evidence/counterexample. Không cần mở game.

P6 chỉ có một sample INVALID_CLOCK_FLOAT, không giữ exact field/value. Không
gán actual sample cho FX=-1 hoặc giả tạo native replay. Current-b6 file bytes
prove FX reset sentinel -1.0 tại +0x1E8; parser P5 loại sentinel này là defect
độc lập đã prove. Parent fixtures, failed window và mọi historical manifests
phải giữ nguyên.

Allowed changes chỉ standalone observer/parser/export diagnostics và tests
liên quan (`src/pokiguard_v2/passive_clock_observer.py`,
`tests/test_passive_clock_observer.py`; CLI chỉ nếu artifact/schema bắt buộc).
Không thay gameplay/provider/root/field read allowlist, call count/size, cap/
rate/Stop, timing authority, BASIC behavior, flow/capture/input/ACK/room/UI gate.
Không process enumeration/attach/RPM, input, capture, network, build/version/Git.

Chấp nhận **đúng sentinel float32 -1.0** của FX, có status reset-sentinel rõ;
không nới arbitrary negatives/nonfinite hoặc gọi nó proof current Unity clock/
server freshness. Giữ validation remain/anchor và các giá trị FX khác có căn cứ.

Khi decode lỗi, export diagnosis của đúng năm fields allowlisted: field/offset,
reason, value classification và float32 bits nếu cần; finite values được giữ,
NaN/Inf dùng representation JSON-safe. Không export full48B blocks/padding,
pointer/event/reason string hoặc account data. A/B mismatch/partial reads phải
giữ nguồn/phase rõ, không che record lỗi hoặc tự retry sample.

Meaningful tests: verified reset sentinel và nonnegative FX; các negative khác/
NaN/Inf/invalid bool; per-field failure rõ và JSON-safe; no pointer/padding
leak; partial/Stop/caps/read-cost/source binding giữ nguyên. Counterexample là
synthetic theo file evidence, không observed replay. Test utility/binding/fakes;
không full gameplay suite/30min soak khi accepted runtime hash-preserved.

Freeze before/after source/artifact hashes, inventory cho diagnostics mới, review
manifest/runbook mới riêng. Không overwrite P5 review hoặc rebind historical
PASS. Review mới vẫn diagnostic-only, native_U_ms:null/input_authority:false.
Không tự mở lại P6 native window để xem fix có PASS hay không.

Report5d1_p7 với exact changes, tests, error/loss/export fidelity, preservation
và native limitations. Update status/router/capability; chọn **một next concrete**
dựa trên evidence, không thực thi next hoặc xin game trong bước offline.
**STOP P7.**
