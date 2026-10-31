# 5D.1-P16 — Operational lifecycle/admission remediation, offline

**CLOSED 2026-10-15 / PASS SCOPED OFFLINE REMEDIATION / PARTIAL D1.**
[Actual report](../reports/5d1_p16_report.md). Native timing/source rebinding còn
pending; các bước dưới là scope đã thực hiện, không cấp live activation. Parent
[P15](../reports/5d1_p15_report.md). Chỉ thực hiện khi user yêu cầu tiếp tục.
Đọc AGENTS, STATUS/router/contract/capability, P13/P14/P15, request/source pins,
P15 full raw archive/audit/join/watermarks và inert reproduction.

## Mục tiêu và scope

P15 baseline flow3WIN/3returns/target Stop, nhưng chỉ combat_0 có worker/timing.
Closed old sink bị prepare_options coi là diagnostics fault trước nhánh tạo
successor. Read-span policy100ms loại5/7SWAP; log ghi SOURCE_CHANGED không chỉ
ra admission reason. Hmax405.3797ms vượt P11 descriptive164.429ms. Không sửa
BASIC/planner để ép đổi nước hoặc gọi3WIN là reasoning acceptance.

Thực hiện **offline**: sửa hẹp vòng đời/diagnostics của operational session,
verify admission provenance và timing qualification. Không mở tool/game/observer,
lookup/attach/read memory/capture/input/network, live batch hoặc real claim mới.
Không đổi reader/controller/entry/action/random/pacing/ACK/recovery, strict
finite-U loader, weights/model/solver và ordinary preferences. Không build,
version/Git mutation hoặc chạm game/V1. Giữ mọi raw failures/consumed claims.

## 1. Snapshot và tái hiện trước sửa

Pin source290/host/game/HEAD/preferences/parent artifacts, so đúng P15. Tái
hiện lỗi bằng real method + inert/fake-native objects, rõ synthetic provenance.
Không giả định có live fault counter chưa được export. Trace healthy combat
Stop→worker close→writer flush/close→prepare successor và nhánh cleanup chưa
xác nhận; chứng minh thứ tự check hiện tại gây lỗi.

## 2. Sửa healthy retirement/successor

Phân biệt normal CLOSED của bridge đã retire với diagnostics failure/expiry/
fault đang hoạt động. Chỉ tạo successor khi previous worker/owner/writer cleanup
đã xác nhận và cap cho phép; không bypass global owner gate. Mỗi attempt vẫn
thuộc cap hiện có, không reset/resume/reuse claim. Không join/flush/sleep/wait
trong Farm/action/Stop/prepare_options để ép successor sẵn sàng. Nếu cleanup
chưa xong hoặc failure thật, BASIC tiếp tục, trạng thái lý do rõ và bounded.

Không làm lỏng lỗi active sink, writer fail/accounting invalid/queue overflow,
worker fail/expiry/mismatch. Terminal Stop vẫn ngăn resource/job mới. Test tối
thiểu sequence3combats, retired healthy, delayed/unconfirmed cleanup, true sink
fault, fault/expiry before next, cap exhausted, Stop race và no duplicate owner.

## 3. Diagnostics đủ phân biệt, không thêm game read

Persist session-level outcome/fault stage/attempt-or-combat identity và bounded
bridge/admission counters trong receipt off action thread. Closed old sink
không được nuốt lý do session lỗi. Phân biệt:

- completed retention (hợp lệ) và accepted override nếu thật sự đủ bằng chứng;
- opening/witness unsupported, read-span rejection, source/config change;
- deadline/worker/logging fault, healthy retirement và successor unavailable.

Không dùng shadow OFF làm operational status. Nếu expose status, dùng existing
file/controller boundary, không polling/read/capture mới và không chặn BASIC.
Không log lặp vô hạn; verify watermark accounting/lost-record counters, Stop
không chờ diagnostics drain. Giữ absence là UNKNOWN thay vì fabricate per-turn
evidence cho16SWAP P15 không instrumented.

## 4. Admission và timing evidence

Đối chiếu root provider-poll interval với immutable snapshot/state source. Xác
định phần nào đã prove từ raw P15/source, phần nào UNKNOWN về218–233ms. Verify
reject span không reuse completed source cũ, không reset deadline hoặc chờ thêm.
Test same-source/timer/config/lock-busy/stale-result cases bằng synthetic
snapshots có nhãn. Giữ100ms; **không tự nới threshold để tăng coverage**. Nếu
cần thay meaning/threshold/calibration, ghi proposal/evidence riêng và chọn
review tiếp theo, không áp dụng ngầm trong bản sửa này.

Review Hmax405.3797ms/6of7component sample exceed, không relabel P11 hoặc thay
allowance dựa trên P15 hindsight. R_op/native U vẫn descriptive/UNKNOWN. Nếu
source đổi, lập exact compatibility chain và fresh current-source allowance
bằng qualification thích hợp; không reuse P14 acceptance cho source mới.
Giữ thresholds công bố trước, không repeat để tìm PASS. Normal retention là
kết quả hợp lệ; không quota hoặc fabricate board/model để tạo override.

## 5. Validation và closure

Focused tests cho lỗi thật và full regression theo change; qualified overhead,
Stop/worker/writer/owner cleanup, all three checkpoints/pipeline/stress/accounting
trên source frozen nếu affected. Kiểm existing no-session/default BASIC byte/
AST parity, source/parent/native/raw/claim/game/preferences/HEAD preservation.
Không thử fault trong game. Không tự cấp live activation khi offline PASS.

Report `reports/5d1_p16_report.md`: before/after cause, exact changed scope,
fresh pins/checks, supported vs UNKNOWN, timing/read-span coverage limitations,
normal retention semantics và trạng thái claim cũ. Update STATUS/README/router/
capability; chọn **một** next theo evidence: review còn thiếu hoặc chuẩn bị
bounded successor pilot riêng. Chưa tự chạy live, chưa D1cap12/CAREFUL/Demon/
Mega/D2. **STOP P16.**
