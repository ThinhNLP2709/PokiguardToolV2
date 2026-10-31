# 5D.1-P1 — Production selection bridge, offline closure

Ngày **2026-10-12 (Asia/Saigon)**. Result **PARTIAL**.
Phần software bridge đã implement/kiểm offline; **chưa đủ timely first-root,
native calibration và operator activation để return D1 live**.
Parent: [D1 readiness](5d1_report.md), [P1 prompt](../prompts/5D1_P1_PRODUCTION_SELECTION_BRIDGE.md),
[contract](../EXECUTION_CONTRACT.md). Không chạy game/live/build/version/Git mutation.

## Kết quả chính

Đã có đường optional immutable state/config → background producer → isolated
R1 worker → completed selector → root/fresh/final preflight → existing SWAP/ACK.
SIMPLE/CAREFUL, Normal/Normal/default Attack, ordinary SWAP→SWAP là scope duy nhất.
Default `selection_adapter=None` giữ BASIC, không import reasoning modules khi
import controller, không tạo owner/worker/sink. UI và launch REASONING vẫn gated;
ordinary preferences BASIC/shadowOFF giữ nguyên.

**Không gọi đây là pilot ready.** Hai positive controller fixtures thực sự chạy
producer/child worker, nhưng pre-admit immutable fixture và đợi hoàn thành
**trước `controller.run`**. First fresh-root fixture không pre-admit vẫn dispatch
BASIC ngay. Không chèn wait/sleep/reread vào controller để đợi planner. Hiện
disposable spawn và background duplicate BASIC preparation mất khoảng0.7s trên
fixture; chưa chứng minh proposal có thể đến trước root thật của lượt mới.

## Đã thay đổi gì

- `reasoning_pilot_contract.py`: frozen explicit authority pin full policy,
  profile/loadout, operator cohort + structural runtime witness, build SHA,
  model, timer/input mode, absolute budget/U/R/M và calibration provenance.
- `reasoning_pilot.py`: typed opt-in factory, single-owner ledger, latest-one
  nonblocking admission, immutable snapshot/provenance, source/generation/job
  binding, actual runner completion packing ngoài action thread, capped relay
  và asynchronous Stop/cleanup. Tái dùng solver, isolated runner và capped sink.
- `reasoning_selection.py`: C4 mặc định vẫn offline-only; thêm typed authority
  context và scoped bounded R1 interval comparison, validation ở3 checkpoints.
- `basic_auto_bot.py`: chỉ optional setup/context và2 hooks trước/sau **poll
  sẵn có** để ghi monotonic span/retain frozen refs. Không thêm poll hoặc capture.
- Fixture/source audit pin before/after cụ thể;33 new tests và file-only
  qualification tool. Không sửa BASIC ranking, reader, executor/pacing/QTE,
  ACK/pending, room/result/farm lifecycle, desktop UI/preferences/launch.

Không có input authority trong worker/snapshot. Invalid source/config/model/
generation/actor/resources/coordinates/timer/reserve hoặc reply late/malformed
thì giữ BASIC còn hợp lệ; stale source vẫn theo existing flow/fail closed.
Đã gửi input thì không thay thế bằng BASIC, pending/ACK vẫn owner cũ.

Producer giữ nguyên deadline cho cùng source, không resubmit/reset để kéo dài
budget. Preparation/serialization/hash/solver/IPC relay/packing trên owner
background; host admission chỉ checks nhẹ + try-lock + frozen refs. Checkpoints
không plan/simulate/read/capture/flush/join. Stop chỉ signal; owner reaps process.

## Scope model và interval

Native authority hiện chỉ chấp nhận model `{version:5b2.scoped_inputs.v1}`:
không có numerical effect/cost/conversion calibration mới. D/T/X là proxies
Sword units / existing ordinary boss Sword reply / UNKNOWN exposure từ simulator.
Damage/boss skill threat để MISSING; R/E giữ full unknown[0,1], P full unknown
nếu ăn Health/Shield/Drain chưa biết effect. Không gán boss threat0 hoặc lấy
Health20 synthetic làm game data, không R2/survival/lethal promotion.

Planner gán evidence_rank0 khi weighted unknown còn tồn tại. P1 cho **typed
pilot** so full normalized intervals nếu mọi feature/contribution hữu hạn,
đúng signs, zero/future fields hợp lệ, utility sum nhất quán và structural
D/T/X khớp solver. Gap vẫn `proposal.low - BASIC.high >=0.05`. Unknown không
được zero-fill; rank0 không được dùng để bypass essential source/model/legality/
timing gates. Legacy C4 strict rank gate giữ nguyên. Đây là robust proxy
comparison trong declared intervals, không confidence probability/actual safety.

Native minimal-model fixture đã chạy worker và **giữ BASIC,0 override**. Positive
SIMPLE/CAREFUL dùng effect model synthetic có nhãn trong OFFLINE_NATIVE_FAKES;
fake authority không được dùng trên PID thật. Native-context test dùng attestation
**synthetic** với toàn bộ native IO forbidden/faked; chỉ prove validation branch,
không là calibration hoặc production input proof.

## Evidence và verification

Artifact root: [5d1_production_bridge_v1](../artifacts/5d1_production_bridge_v1/).

| Kiểm chứng | Kết quả và giới hạn |
|---|---|
| Full regression | **2039/2039 PASS**,237.014s; [console](../artifacts/5d1_production_bridge_v1/full_tests.txt) |
| Focused P1 + C4 | **60/60 PASS**,33 P1 +27 C4; [console](../artifacts/5d1_production_bridge_v1/focused_tests.txt); full regression gồm toàn bộ trên current runtime |
| File-only qualification final | **31/31 gates PASS**; [qualification_v3](../artifacts/5d1_production_bridge_v1/qualification_v3/qualification.json); overall milestone vẫn PARTIAL |
| Disabled parity |5 full trace pairs: normal/stale/wrong-turn/pending/Stop; return/calls/rows exact archived controller |
| Optional source isolation | AST sau bỏ đúng optional hooks khớp pre-C4 controller; chỉ2 new admission hooks, no extra read/capture/input |
| Positive actual pipeline |2 pre-admitted synthetic roots SIMPLE/CAREFUL, mỗi root3 valid checkpoints/1 fake normal input/1 ACK; exact old read/capture/input order |
| Fresh first-root readiness | Không pre-admit:1 BASIC input, NO_COMPLETED_PROPOSAL; **0 timely override proved** |
| Safety/faults | late/reserve/source/config mismatch, malformed bounds/reply, actual worker exception/hang, sink exception, wrong PID, Stop, stale/pending/unsupported family giữ owner/fallback đúng |
| Cleanup |7 controller fake trials,7 workers/7 reaped; hung-worker cleanup off controller; no replacement input khi pending |
| Actual bounded disk sink |2 events decision/selection written với write ACK, zero queued/in-writer tại watermark; [watermarks](../artifacts/5d1_production_bridge_v1/qualification_v3/disk_watermarks.json) |
| Native live |0attempts,0observed overrides; native tails/efficacy NOT_MEASURED |

Raw [traces](../artifacts/5d1_production_bridge_v1/qualification_v3/controller_traces.json),
[pipeline receipts](../artifacts/5d1_production_bridge_v1/qualification_v3/pipeline_receipts.json)
và exported virtual source/offer trong từng trial. Source SHA tái tạo được từ
frozen source/board/config/baseline/recorded body; runtime không thêm snapshot
game-read/file-write trên action path.

Method-only timing1000 samples mỗi lane:

| Lane (ms) | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| immutable admission |0.0050|0.0079|0.0229|0.4631|
| completed minimal-model validation → RETAIN_BASELINE |0.1960|0.2449|0.5941|1.0335|

[Raw timing](../artifacts/5d1_production_bridge_v1/qualification_v3/software_timings.json).
Đây không gồm native input, full controller dispatch/logging tails hoặc whole-app
CPU/RAM. Synthetic positive completion727.15/727.38ms là2 samples pre-admitted,
không population p99/timely game proof. Không relabel old C3 soak/CPU/live smoke
thành acceptance của producer mới.

Diagnostics dùng selector buffer64records/128KiB, runner relay1MiB và sink
432records/6MiB, rate8records/128KiB mỗi giây. Transfer/relay chỉ là queued,
không written; MemorySink trials written0. Actual sink write ACK chỉ confirm
record write, không fsync/power-loss guarantee. Overflow/log fault disables AI,
không chặn action/Stop. Backend reused, nhưng scheduling/CPU/tail/soak của bridge
mới **chưa requalified**; production gate vẫn đóng.

Qualification iteration giữ lịch sử: V1 đạt29/30 vì collector đòi3 events trong
trial chỉ phát decision+selection2 events, không phải mất log. V2 sửa kiểm
actual event types/accounting đạt30/30; V3 sửa method-timing timestamp từ trước
completion sang sau completion, thêm asserted RETAIN_BASELINE gate,31/31.
Không thay runtime để làm qualification pass; các artifact cũ giữ nguyên.

## Timer/reserve và opt-in còn thiếu

Accepted final SWAP preflight reject bằng `< minimum_action_time`; equality
được chấp nhận. Native timer `MatchService.server_tick` integer seconds.
P1 pin before/after accepted poll monotonic span và source, không giả biết
independent Unity clock. U/reserve native chưa có bound/measurement.

C3 chỉ có inter-click duration, thiếu full preflight-start→required-input-end.
Không lấy2s fake reserve hoặc150ms proposed U làm calibrated authority. Authority
cấu trúc yêu cầu explicit N>=1/provenance SHA; N nhỏ không chứng minh population
tail. Caller hiện cung cấp build/calibration attestation; **chưa có artifact
loader kiểm measured evidence thật**. Operator + structural witness chưa là
independent combat-pet/effect identity proof. Full canonical config/witness drift
thì reject, nhưng không vì pin string mà claim model/cohort đã observed/bound.

Đã chuẩn bị [targeted BASIC calibration draft](../research/5d1_swap_calibration_preparation.md),
default3/max5 TOTAL attempts,0started; chưa instrument/chạy/activate. D1 draft12
và C3 closed6 không mở lại. UI REASONING vẫn disabled, factory chỉ injectable
cho qualified caller; người dùng chưa có selectable production reasoning mode.

## Source/Git truth và return

HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, branch
`codex/phase3a2-board-repair`, source version1.2.5, package unchanged.
[Before manifest](../artifacts/5d1_production_bridge_v1/before_source_manifest.json)
có260Python files;256byte-preserved,4 changed existing files kể trên +4new files.
[Current264 manifest](../artifacts/5d1_production_bridge_v1/qualification_v3/source_manifest.json)
fingerprint `5ab14a8a42b5e1944425cb54bddd61036080e761a370c872bd1ef009a27e477c`.
Historical source260/C3/C4 acceptance giữ fingerprint cũ; exact predecessor bytes
được archive, audit không mở generic allowlist cho tương lai.

Ordinary `logs/desktop_ui/phase2e3_operator_preferences.json` giữ SHA256
`a8ce6394a258792f866a3357de2043ab6ecfc6d829e9af4e66848cfd2794bc46`.
Unrelated worktree/side Bú win fixes giữ nguyên; không reset/commit/push/tag,
không build/launch/attach/live hoặc sửa V1/game.

Exactly one next:
**[5D.1-P2 timely selection/activation/calibration preparation](../prompts/5D1_P2_TIMELY_SELECTION_AND_CALIBRATION_PREPARATION.md)**,
targeted OFFLINE_INTEGRATION selected only, NOT_EXECUTED. Sau required gates
mới quay D1; chưa D2. **STOP P1.** Chưa cần người dùng mở phòng hoặc tốn năng lượng.
