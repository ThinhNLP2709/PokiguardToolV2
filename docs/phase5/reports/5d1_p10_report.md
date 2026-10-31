# 5D.1-P10 — Operational timing implementation, offline

2026-10-14 (Asia/Saigon). **PASS STRONG SCOPED OFFLINE / NATIVE RESERVE PENDING / PARTIAL D1.**
Parent [P9](5d1_p9_report.md), [prompt](../prompts/5D1_P10_OPERATIONAL_TIMING_IMPLEMENTATION_OFFLINE.md).
User đã chốt “cứ triển khai tôi sẽ nghe theo ý bạn”; [acceptance record](../artifacts/5d1_operational_timing_v1/accepted_decision.json)
pin exact P9 proposal bytes. Scope chỉ offline implementation/readiness,
không activation calibration hoặc AI input. Native U/transport/alignment UNKNOWN.

## Kết quả triển khai

Nhánh `OperationalPilotAuthority`/schema/context/loader riêng đã được nối vào
bridge và selector. Strict `PilotAuthority`, finite-U loader và meaning của
`uncertainty_ms` giữ nguyên. Operational model chỉ version, không synthetic
effects; native R/E UNSUPPORTED và full P intervals vẫn được kiểm chứng.

Một deadline lấy từ observation-start; read/BASIC/queue/IPC/worker/validation/
wait đều tiêu cùng budget. BASIC trước, cùng immutable data/incumbent cho
worker, trả sớm, kiểm Stop. No budget/late/error/unsupported giữ BASIC còn
hợp lệ; final rejection đi đường cancel-unsent hiện có, không read/input lại.

Reserve có H controller-tail + I final-input + measured selector allowance +
full commanded wait ceiling BASIC + guard250ms; return margin≥100ms. Native
H/I/read-span threshold chưa thu, không tạo actual authority từ số pending.
Reasoned SWAP bỏ optional random như P2; mandatory pacing/settle/hold và BASIC
random không đổi. Phép chiếu raw timer không biến thành finite server bound.

Chỉ opt-in timing collector có thêm host timestamps trước/sau existing poll,
decision-exit, fresh/final và executor-return. Không thêm/move game reads,
screenshots hoặc normal input. Telemetry/parameter lỗi tắt AI, không veto một
BASIC fallback còn hợp lệ. Chỉ reasoned receipt mới chịu operational final
read-span/input-parameter veto. Reserve overrun/late-final tắt operational pilot.

Disk sink vẫn có một producer. Controller timing buffer riêng được bridge
owner drain; writer flush/close ở session finalizer ngoài action/Stop thread.
Mỗi combat có sink riêng và successor bị chặn tới khi sink trước reaped; cap,
claim và request vẫn thuộc một run, không reset. Stop tức thì vẫn giữ pending
timing event; flush lỗi vẫn close owned writer và ghi unconfirmed receipt.

Optional session kiểm source/build/host/full config/policy/cohort/cap/expiry ở
Start, durable claim chặn restart/copy reset cap, một binding FarmRun. Acceptance
offline không là activation: loader còn đòi pinned independent bounded pilot
review, finalized native FarmRun/export/all-attempt ledger, zero-loss writer
watermarks, raw timing/ACK joins và offline selector allowance. Không có package
native hợp lệ nào được tạo trong P10. UI REASONING vẫn gated, BASIC/shadowOFF.

## Kiểm chứng

23new tests đạt trên source frozen: deadline t0/invalid/expired, missing native
provenance/forged U/effects/ledger, H/I/overrun/parameter/preflight guard, Stop/
superseded/log errors, native-fake actual controller/worker/ACK, BASIC fallback
parity, one-shot session, real offline writer durability và flush-fault cleanup.
Toàn bộ process/input của controller tests là fakes; writer/worker là child
process của tool trên data synthetic, không game process.

[Qualification](../artifacts/5d1_operational_timing_v1/qualification_final.json): **17/17gates PASS**
trên source frozen,5paired controller traces exact + optional AST exact. Mỗi
path có5,000measured samples sau1,000warmup. Completed root+fresh+final tổng
p50 **0.6822ms**,p99 **1.4705ms**,max9.9283ms; full host timing pipeline p50
0.2327ms,p99 0.6112ms,max3.8707ms. CPU trung bình ba checkpoint completed
0.7375ms.1,000Stop signal calls max0.023ms, worker reaped.60s stress với156,452
probe cycles, max1queued record, traced peak9429B. Đây là method/fake-data
software SLO, không whole-app/VM/native performance, không population bound.

**Full suite cuối:2,179/2,179 PASS trong260.301s**. Source283 giữ nguyên
suốt final run; [test log](../artifacts/5d1_operational_timing_v1/tests_full_final.log).
Không lấy initial run làm acceptance; final run không còn source-binding failure.

Một lỗi trong auditor lần đầu do `ast.unparse` thêm parentheses vào BoolOp;
đã đổi sang structural AST comparison. Source guard tiếp tục exact SHA, không
generic allowlist cho future edits. Các lần lỗi giữ trong artifacts, không xóa.
Lần full suite đầu chạy trong lúc hoàn thiện setup/binding nên không là frozen
acceptance; full suite cuối sẽ chạy trên final freeze, không sửa source giữa run.

## Bảo toàn

Current source283:273/280existing files giữ byte;7existing changes (4reasoning
modules,2tools,1fixture);3new files (operational module,test,qualification tool).
Solver/PlayStyle, reader, screenshot, executor, ACK/room/entry/recovery code giữ
bytes; controller AST sau khi bỏ6 host-only optional blocks giống before P10.
Strict authority/loader files cũng byte-preserved.

Historical C3/P2/P3/side fixes giữ original manifests. P10 successor manifest
pin actual source và before bytes riêng; các audit rewind qua exact P10 before,
không gọi old live/soak evidence acceptance cho source mới.

[Preservation](../artifacts/5d1_operational_timing_v1/preservation.json):1,994parent
artifact files/game4files/HEAD giữ byte. Source fingerprint
`3bf1e69fad10d21a59fa49b6da9980fda8a48c773962a5ef75fa9690621a804e`;
[runtime successor manifest](../artifacts/5d1_operational_timing_v1/after_runtime_manifest.json)
SHA `06355bc3b31a2a76d97c5a938b5217a2c1e0bc5d8c5acdbcd9b0683696b15750`.

Preferences thật có drift trong lúc làm: Mega7→Demon120 và related pet/card/
audition fields/saved_at; before và observed/latest bytes đều lưu. Actor UNKNOWN,
không có thao tác ghi file đó của agent; UI tests dùng temporary store hoặc
store=None. Không restore về file cũ và không thay đổi setting hiện tại.
Current preferences vẫn BASIC/shadowOFF; drift không cấp activation và future
request phải pin config riêng. Before SHA f7d04…; observed SHA3e264e… ghi đầy đủ
trong preservation.json. Đây là exception cho byte preservation, không che
thành exact preservation PASS.

0game process query/attach/native read/capture/input/network; không build,
version, Git mutation hoặc ghi preferences thật. Game files chỉ đọc để hash.

## Next duy nhất

[P11 — bounded BASIC reserve calibration](../prompts/5D1_P11_BOUNDED_BASIC_RESERVE_CALIBRATION.md)
chỉ được selected sau final offline gates đạt: chuẩn bị một cohort/request
SIMPLE/SOLO/normal/normal/default_attack/foreground two_click, default3 TOTAL
attempts, trình setting trước khi user mở đúng phòng boss. Chưa chuẩn bị request,
chưa activate/live. Không native clock observer mới, không AI input/D1draft12/D2.
Native measurements pending nên D1 vẫn PARTIAL. **STOP P10.**

[Final verification](../artifacts/5d1_operational_timing_v1/verification_final.json),
[artifact manifest](../artifacts/5d1_operational_timing_v1/artifact_manifest.json).
