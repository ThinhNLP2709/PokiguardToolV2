# 5D.1-P29 — Current-source context attribution, offline

**SELECTED ONLY / NOT EXECUTED. Chưa cần mở game.**
Đọc AGENTS, EXECUTION_CONTRACT, STATUS/ROUTER/capability,
[P28 report](../reports/5d1_p28_report.md),
[frozen proposal](../artifacts/5d1_qualification_disposition_p28_v1/next_step_proposal.json),
P28 source/accounting/evidence-gap/native ledgers, P27 source freeze/raw/31of32
failure và P24 harness/protocol/clock limits. STOP đúng P29.

## Mục tiêu và giới hạn

P27 source30148eaf48d… vẫn FAIL ở10.4014ms; P21 source29711.8417ms giữ.
P24 source297 profile sau12000collector controls, không có qualification
prefix55000checkpoint/admission/Stop calls. Cần thêm **same-sample stage/gap/
GC observations trên source301 trong đúng call/phase prefix**, gồm riêng
config projection span mới. Chưa có bằng chứng prefix gây historical tail.

Đây là một diagnostic có instrumentation, **không phải qualification rerun**.
Không gọi qualifier `qualify()`/CLI, tạo32gate acceptance result hoặc dùng
diagnostic dưới10ms để thay P21/P27. Same call schedule không là identical
allocator/GC/scheduler history; mọi observer/preallocation/raw persistence
đều có thể làm khác context. Không hứa tái hiện hoặc biết cause của mẫu cũ.

Chỉ thêm artifact-local harness/validation/docs trong V2. Không sửa
src/tools/tests, qualifier/verifiers, BASIC/solver/profile/model/weights,
provider/controller/read/screenshot/input/pacing/ACK/result/room/recovery/
Stop. Không game attach/read/capture/input, game files writes, UI/live/
observer, network/preferences/claims/build/version/Git writes.

## 1. Entry và proof trước measurement

- Verify P28/P27 final/frozen/protocol/raw/source manifests, actual host,
  parents/6claims/current prefs/4static game hashes/HEAD; archive before docs.
  Source301 và all parent failures giữ nguyên. Không reset settings.
- Harness mới trong artifact directory riêng. Pin exact source/harness/
  protocol/guard/validation bytes. Review AST cho **phase/call/argument order**
  so với frozen current qualifier; chỉ observer/diagnostic output/control
  code được thêm, không bỏ witness/hash/root metadata/monitor/validation.
- Host canonical record lấy thực tế **trước project imports/guards**, validate
  immutable text/hash dưới guard; independent actual check sau run ở process
  riêng. Không mở socket/hostname guard hoặc dùng hostname rỗng.
- Native/game/provider/capture/input/network và writes ngoài artifact bị chặn.
  Explicit native fakes cho controller; import DPI phải bị stub chặn như P24.
  Chỉ cho phép tối đa **một existing CPU-only reasoning worker** và existing
  owner/supervisor threads của nó để lấy completed offer cho prefix. Không
  thêm process target/writer/plugin/API/native capability. Worker target/
  ownership/serialization phải được source-pin và validation trước execution.
  Nếu không enforce được boundary này thì ghi NOT_READY, chưa measurement;
  không mở rộng guard cho mọi subprocess/thread.
- Fake validation dùng clocks/states/native/executor/process fakes: exact
  prefix modes/counts/order, actual collector old-oracle payload/digest/error
  parity,18spans/nesting/gaps, GC overlap/missing/overflow, coarse CPU và
  clock reversal; source/host/freeze tamper, cap/partial/Stop/worker failure/
  cleanup/attempt consumption/retry rejection. Không lấy validation timing
  làm performance data; không chạy full production tests lại.

## 2. Protocol cố định trước data

Chỉ sau validation/source proof PASS mới freeze complete harness/protocol.
Durable exclusive attempt ghi **trước host capture/preflight** của measurement
invocation. Failed preflight/partial cũng tiêu attempt. **Một invocation,
zero automatic retries**, wall cap180s; giữ all partial raw/errors/receipts.

Giữ current synthetic `native_state`/PolicyConfig/parameters, actual successor
immutable config projection policy + root250/final100 + component monitor.
Setup metadata/sink allocation ngoài pipeline timer như original qualifier.

1. Source/ancestry/AST audit và five disabled fake-controller before/after
   trace pairs; không true controller input.
2. Một existing real offline CPU worker completion; cùng completed offer/
   ownership semantics cho inert adapters. Không spawn worker mỗi sample.
3. Prefix fixed order: checkpoint modes disabled/completed/timeout/error/
   fallback, mỗi6000; admission admitted/span_rejected/clock_rejected/busy,
   mỗi6000; Stop1000; reap/close worker **trước pipeline**. Tổng55000prefix
   records, giữ1000warmup/mode như current code; không adaptive shortening.
4. **6000 instrumented pipeline samples**,1000warmup +5000measured; actual
   collector/helper/authority/monitor, nguyên argument evaluation/markers và
   **3critical hashes** của qualifier. Không đổi sang production caller2hashes
   để giảm số đo. Giữ full root metadata và synthetic no-input result.
5. **1000 empty-reference samples** với toàn18-span nesting/enclosures, sau
   pipeline; không chỉ một wrapper như P24. Đây chỉ observer reference,
   không subtraction/correction để tạo SLO PASS.

Tổng **62000raw records**:55000prefix/6000profile/1000empty; không pool groups.
Profile18spans/sample=108000raw/90000measured spans: prior17 gồm9top-level
và nested3critical_hash/monitor/encode/enqueue/witness/config_digest, thêm
**config_projection** bên trong start. Verify exact parent/call counts.
Các span inclusive; không cộng nested vào parent lần nữa.

Không replay later60s stress: nó xảy ra sau pipeline gốc và không giải thích
context trước pipeline. Không metadata-omitted control, GC force/disable,
priority/affinity tweak, altered warmup/corpus/random policy hoặc source fix.

## 3. Observables và integrity

- Prefix phase/sample IDs, exact outcomes, actual offer/owner/reap counters,
  source/host/policy pins và retained-state summaries ở phase boundaries.
  Existing CPU/wall fields được giữ nhưng không gọi chúng qualification.
- Pipeline absolute outer and18stage begin/end timestamps, stage nesting,
  clock arithmetic, non-overlap top-level coverage/residual gaps; event bytes,
  payload/digest/monitor/outcome/error và cleared pending/decision interval.
- Bounded GC start/stop callback spans **cả prefix và pipeline**, index/phase
  association + absolute overlap; retain open/unmatched intervals as UNKNOWN.
  Record current GC config/counters ở phase boundaries, không force cycle.
  Callback overlap là correlation, không tự chứng minh cause.
- Thread/process CPU endpoints và actual clock info; quantum0/15.625ms
  phải giữ, không dùng zero hoặc wall−CPU để chứng minh descheduling.
- Observer fields/preallocation/callback overhead ghi rõ. Raw storage≤128MiB,
  GC events≤20000, profile spans≤108000; overflow/cap là PARTIAL, không drop
  rồi gọi COMPLETE. IO/validation/custom JSON ngoài từng timed interval.
- Restore every wrapper/callback/GC settings và bounded worker cleanup;
  Stop/cap chỉ kết thúc diagnostic owner, không tương tác game/tool của user.

## 4. Quy tắc kết luận và STOP

Diagnostic integrity PASS chỉ nghĩa source/host/AST/coverage/raw/guard/cleanup
đúng. Không accepted S/R/native binding/draft/activation/claim/live mới.
Trần qualification10ms và mọi original failures giữ nguyên.

- Có outer≥10ms: giữ toàn raw và neighborhoods, map longest inclusive stages/
  residual gaps/GC overlaps trên **cùng sample**. Chỉ kết luận vị trí hoặc
  correlation có bằng chứng; không gọi CPU/OS/GC là cause khi chưa chứng minh.
- Không có outer≥10ms: đóng **NOT_REPRODUCED / INCONCLUSIVE**, không tự chạy
  lại cùng diagnostic để tìm spike. Không chọn optimization vì stage đứng đầu.
- Runtime remediation sau này chỉ được plan khi có independent correctness/
  cost rationale cụ thể, exact parity boundary và predeclared benefit criterion;
  future source change cần exact successor review/freeze/fresh qualification.
  Không dùng kết quả lần này làm excuse cho unchanged qualification rerun.

Viết `reports/5d1_p29_report.md`, validation/freeze/protocol/attempt/raw/
stage-gap-GC/CPU/recompute/cleanup/preservation/UNKNOWN ledgers. Giữ errors
và partials. Update STATUS/README/ROUTER/capability/index, chọn exactly one
next prompt nhưng **không thực hiện**. Native H binding vẫnPENDING độc lập,
U/transport/alignment null; BASIC/normal retention/no quota giữ. Chưa mở
general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc đóng Phase5. **STOP P29.**
