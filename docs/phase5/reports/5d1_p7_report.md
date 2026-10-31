# 5D.1-P7 — FX sentinel và field diagnostics, offline

2026-10-14 (Asia/Saigon). **PASS STRONG OFFLINE CORRECTION / PARTIAL D1.**
Parent [P6](5d1_p6_report.md). Không chạy thêm native window hoặc đọc process.

## Đã sửa

Chỉ đổi hai Python files: standalone observer core và test của nó. CLI,
gameplay/provider/solver/input/ACK/room flow giữ nguyên byte.

`decode_clock` chấp nhận **đúng float32 FX bits0xBF800000 = -1.0**, căn cứ
ClearLocalFxHold/ApplyTimingFields của b6 trong evidence P6. Output ghi
`fx_hold_state=RESET_SENTINEL`; các giá trị FX không âm ghi
`VALUE_ONLY_ACTIVE_UNKNOWN`. `fx_hold_active` luôn UNKNOWN; reset sentinel
không cung cấp current Unity clock, server receipt hoặc bound timer age.

Negative FX khác, negative remain/anchor, nonfinite, invalid bool và operational
remain cap300 vẫn bị từ chối. Không nới mọi negative để làm observer PASS.

Khi decode lỗi, `ClockDecodeError` giữ diagnosis của đúng năm fields allowlisted:
field, offset, type, original bits, finite value, classification, valid/reason.
NaN/±Inf xuất value null + classification/bits, không serialize nonfinite JSON.
Các field hợp lệ còn lại cũng được giữ để phân biệt lỗi. Clock A/B có diagnostics
riêng và failure_phase rõ. Partial/Stop/read abort không decode prefix; chỉ giữ
phase, returned-byte count và status. Pair mismatch giữ decoded A/B, không dump
padding/full block hoặc thêm read để tìm khác biệt.

Observation schema mới `5d1.p7.passive_clock.v2`, diagnostics schema
`5d1.p7.clock_fields.v1`. Historical P5/P6 outputs vẫn v1 và không bị rewrite.

## Kiểm chứng

**54 focused tests PASS**, 0.726s; gồm39cases cũ và15regressions mới. Một test
cũ coi FX=-1 invalid được đổi sang FX=-2 theo evidence; cap/rate/Stop/native-fake/
source binding/export tests còn lại giữ và PASS. Coverage mới gồm exact sentinel,
float32 neighbors âm, negative remain/anchor, mọi field lỗi, original NaN bits,
±Inf JSON-safe, A/B partial/Stop/mismatch, no padding/account leak và export fidelity.
P5 review cũ bị source gate từ chối trước NativeSession; không auto-rebind.

Six paired old/new trials (healthy, bad A, bad B, partial B, mismatch, Stop)
giữ **exact RPM/query/binding/wait sequence**, verdict và stop reason tương ứng.
AST audit chứng minh root/identity, GuardedMemory, Limits/Binding, export và các
constants/read caps khác không đổi; CLI giữ nguyên byte. Changes chỉ decoder,
error/phase diagnostics và observation schema.

Counterexample synthetic P6 trước sửa bị INVALID_CLOCK_FLOAT; sau sửa ghi reset
sentinel hợp lệ. Đây **không replay mẫu native P6**: actual failing field/value
của lần đó vẫn UNKNOWN. Native P6 JSON4129B giữ nguyên hash.

600synthetic reset samples đầy đủ, max string128:18000RPM/801600B, output
3106909B <8MiB, no drops. Synthetic error output giữ đúng5fields, diagnosis
947B trong fixture, file4427B. FILE_WRITTEN/partial/exclusive/disk-loss semantics
giữ nguyên, không claim durable hoặc native CPU/latency bound.

## Contract và review mới

Không thêm RPM/byte/query, không đổi identity/root/string read allowlist hoặc
thứ tự A/B. Max30RPM/1336B +12VQ mỗi mẫu, clock incremental2RPM/96B; một window
60s admission/600samples/≤10Hz, no catch-up, read-span50ms, Stop waits≤20ms.
Output/buffering cap8MiB/600records vẫn giữ. Rich diagnosis chỉ khi lỗi, tối đa
5fields; lỗi đầu kết thúc window, không ghi thêm một error stream hoặc read retry.
Healthy output thêm FX state, nullable diagnostics và failure_phase.

Review mới tạo bằng `--prepare` file-only; CLI/schema review v1 tương thích,
source pin bind observer/output v2. Supplemental
`artifacts/5d1_observer_sentinel_diagnostics_v1/diagnostics_contract.json`
ghi chính xác payload/cost mới. Runbook mới riêng tại
[P7/P8 runbook](../research/5d1_p7_observer_runbook.md); P5 review/runbook còn nguyên.
Review này vẫn PREPARED_NOT_ACTIVATED, không là AI activation artifact.

Source279 fingerprint:
`b7fbeba620868937c309d0edf2097dbe75037423ccca78bd25ef927a6c42203a`.
Review SHA:
`29729cde74c90a260b379dc1fcdc45d2af8138282942b944f1b1c59a2c7da515`.
HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, appv1.2.5/package unchanged.

## Preservation và giới hạn

277/279entry Python files byte-preserved; chỉ core/test observer đổi.507parent
artifact files (P3/P4/P5/P6/preflight), bốn game files, preferences, AGENTS,
symbol/board docs giữ nguyên. Before/after/diffs/source review/qualification/
final verification ở `artifacts/5d1_observer_sentinel_diagnostics_v1/`.
Không chạy lại full gameplay suite hoặc soak vì accepted runtime không đổi.
0native windows/process enumerations/attach/RPM/input/capture/network;
no build/version/Git mutation trong P7. Native-looking calls của tests là fakes.

`native_U_ms:null`, transport age/alignment UNKNOWN, input authority false.
Offline correction không chữa mọi deadline gate, không chứng minh native clock
đã usable hoặc suy luận đã đủ điều kiện input. BASIC/shadowOFF/UI gate giữ nguyên.

Exactly one next:
**[5D.1-P8 — one corrected passive window](../prompts/5D1_P8_CORRECTED_PASSIVE_OBSERVATION.md)**,
SELECTED ONLY / NOT EXECUTED / NOT ACTIVATED. Chưa cần mở game trong P7;
window mới cần user preparation/activation riêng, không farm/native R/D1/D2.
**STOP P7.**
