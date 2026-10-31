# 5D.1-P23 — Harness diagnostic, offline

2026-10-15 (Asia/Saigon). **PARTIAL — HARNESS HOST-BINDING FAILURE BEFORE
MEASUREMENT.** Chưa có dữ liệu latency mới. Đây là lỗi harness mới của bước
này, không phải lỗi game hoặc source runtime của tool.
[Prompt](../prompts/5D1_P23_PIPELINE_DIAGNOSTIC_OFFLINE.md),
[parent P22](5d1_p22_report.md),
[summary](../artifacts/5d1_pipeline_diagnostic_p23_v1/diagnostic_summary.json).

## Kết quả và nguyên nhân

Đã dựng [harness riêng](../artifacts/5d1_pipeline_diagnostic_p23_v1/harness/pipeline_diagnostic.py),
fake validation PASS8cases, freeze harness/protocol rồi gọi `--measure` đúng
một lần. Process exit1 tại preflight host equality, **trước run claim và
trước mọi pipeline sample**. Có **0/19,000 planned records**, không raw
dataset hoặc completed measurement receipt. Không gọi lại phép đo.

Nguyên nhân đã xác định: audit guard chặn toàn bộ `socket.*`, bao gồm
`socket.gethostname` mà `platform.node()` dùng để đọc tên máy cục bộ.
`NativeForbidden` kế thừa `OSError`; stdlib `platform._node()` bắt exception
này và trả chuỗi rỗng. Host fingerprint của harness vì thế không thể khớp
host đã pin có tên máy khác rỗng. Actual source và actual host kiểm riêng
vẫn khớp trước/sau; không có bằng chứng máy hoặc source đã đổi.

[Entry failure review](../artifacts/5d1_pipeline_diagnostic_p23_v1/entry_failure_review.json)
giữ log/exit/guard receipts, source stdlib và một fake-only reproduction:
real `platform._node()` trả `''` khi fake `socket.gethostname` ném đúng
exception của harness. Không gọi socket/network thật trong phép kiểm này.
Guarded host record lúc lỗi chưa được persist; các field còn lại không
được giả là đã quan sát. Ba outside-write attempts bị chặn khi lấy host
metadata không lưu paths, nên exact paths vẫn UNKNOWN.

Tôi đã thiếu case kiểm host binding dưới guard trong fake validation trước
lần chạy. Đã giữ nguyên lỗi và không nới host check để cho qua.

## Phần đã chuẩn bị và kiểm

Source vẫn297 files,
`bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`;
host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Không thay src/tools/tests. Harness nằm dưới artifact directory, pin SHA
riêng; runtime fingerprint không được dùng thay harness provenance.

Control sequence AST khớp toàn bộ calls trong P21 interval sau bốn fixture
alias normalizations. Setup/sink allocation/authority identity ngoài timer;
custom validation/raw IO ngoài timer. Profile có17inclusive spans, ba
critical hashes, parent IDs; không cộng trùng nested times. A/B metadata
counterfactual giữ nguyên kế hoạch, chỉ được dùng với state giả.
[Frozen protocol](../artifacts/5d1_pipeline_diagnostic_p23_v1/protocol.json),
[pre-measurement manifest](../artifacts/5d1_pipeline_diagnostic_p23_v1/frozen_manifest.json).

[Fake-clock validation](../artifacts/5d1_pipeline_diagnostic_p23_v1/fake_validation.json)
kiểm8case: A/B metadata;17spans/parent order/restore; dropped sink fault;
fake GC events; native/audit guards; exception restoration; exact120s
deadline; fixed schedule/indices/19,000 planned records. Đây là validation
của harness với clocks giả, không phải latency measurements hoặc full tests
của tool. P21 full2316PASS chỉ được đọc lại từ footer/exit, không rerun.

Initial validation bị guard chặn ở `SetProcessDPIAware()` lúc import.
Native call đã bị stub chặn trước khi thực hiện. Đổi riêng exception type
của guard sang `OSError` để source module xử lý bằng catch hiện có; không
cho API thật chạy. Initial harness/cleanup/failure giữ ở
[attempt01](../artifacts/5d1_pipeline_diagnostic_p23_v1/validation_attempt_01/failure.json).
Final fake validation PASS, nhưng chưa bao phủ host acquisition nên
`--measure` mới dừng tại lỗi đã mô tả. Hai lỗi này không phải failed
performance datasets.

## Phần chưa đạt và bước kế

Chưa đo được wall/CPU/stage/GC/payload increment/overhead. Không có quantiles
mới, không thể kết luận nguồn gây mẫu11.8417ms của P21. P21 vẫn31/32
qualification FAIL; trần max10ms, raw/warmups/outlier giữ nguyên. S24.4372/
R6772.1419 vẫn chỉ descriptive; current accepted allowance/reserve null.
Native U/transport/alignment vẫn null. Không live authority hoặc pilot mới.

Chọn đúng một [repair proposal](../artifacts/5d1_pipeline_diagnostic_p23_v1/repair_proposal.json),
accepted=false/implemented=false: lấy actual host metadata bằng đúng hàm
cũ **trước khi cài guard và trước project imports**, đóng băng detached
canonical record cho guarded preflight. Final preservation ở process riêng
phải kiểm actual host lại; cached record không phải second observation.
Không hardcode tên máy, bỏ host check hoặc mở socket/network guard.

P24 cần thêm fake cases cho host binding/tamper và durable attempt receipt
ngay trước preflight. Sau khi harness mới được freeze mới cho đúng một
attempt riêng theo nguyên kế hoạch19,000records/cap120s. P23 đã đóng, không
resume hoặc ghi đè harness/log/frozen manifest cũ. Không chọn tối ưu runtime,
sửa SLO hoặc chạy qualification/live từ failure này.

## Preservation và STOP

P22 manifest19artifacts/7docs, P21 artifacts2,344 và7original/archived docs,
failed raw qualification và full regression footer đều được kiểm tại entry.
Source297/host/HEAD,6claims và4static game files được bảo toàn. Trong7,629
parent artifacts,7,628 giữ byte; prior P19 UI đóng độc lập lúc14:56:01Z,
append267bytes vào stdout và tạo thêm `ui_session/summary.json`. Prior stdout
prefix5,075bytes được tìm lại bằng exact SHA và archive riêng. Ordinary
preferences đổi saved_at và6config fields, từ Demon sang Mega Icarus;
không phải chỉ timestamp. Agent không gọi UI hoặc ghi preferences; writer/
thao tác cụ thể ngoài phiên chưa được xác định. Giữ nguyên current settings,
không hoàn nguyên thay đổi bên ngoài. Vì vậy byte-preservation tổng thể là
**PARTIAL_EXTERNAL_CHANGES**, không báo tất cả parent/preferences unchanged.
[External closure review](../artifacts/5d1_pipeline_diagnostic_p23_v1/external_UI_closure_review.json).
Năm current docs được archive trước update; idle UI stream chỉ frozen
prefix/append riêng, không native evidence.
[Final preservation](../artifacts/5d1_pipeline_diagnostic_p23_v1/verification_final.json).

Guard cleanup đã restore. Không game attach/read/capture/input, UI/observer/
worker launch, gameplay/source/default BASIC/read order/executor/ACK/Stop
change, network traffic, preferences/claims write hoặc build/version/Git.
Root250/final100 vẫn opt-in chưa live; normal BASIC retention hợp lệ,
không override quota. P23 chỉ thêm artifact harness/docs và fake validation;
measurement invocation lỗi trước khi đo, không rerun qualification/tests/soak.

Next duy nhất **[P24 host-binding repair OFFLINE](../prompts/5D1_P24_DIAGNOSTIC_HOST_BINDING_REPAIR_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game, không resume P19/general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc đóng Phase5. **STOP P23.**
