# 5C.3 — Offline parity/fault acceptance, chưa đủ performance gate

Ngày báo cáo: 2026-10-11 (Asia/Saigon); tiếp tục yêu cầu từ2026-10-10.

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5C.3 / 5C.2 / BASELINE_LIVE_OPTIONAL — OFFLINE ONLY
RESULT: PARTIAL — LATENCY NOT_QUALIFIED; RESOURCE/LIVE PENDING
EFFICACY: NOT_APPLICABLE / NOT_MEASURED
SOURCE VERSION: v1.2.5 existing worktree; historical baseline v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
RUNTIME CHANGES IN C3: NONE
LIVE / BUILD / VERSION / COMMIT / PUSH / TAG: NONE
NEXT: same 5C.3, targeted integration measurement; C4 NOT_ALLOWED_YET
```

Người dùng yêu cầu tiếp tục sau [C2](5c2_report.md). Entry C2 PASS STRONG đủ.
Lần này thêm hai file **offline**: verifier benchmark và integration tests;
không sửa gameplay, runtime, UI, provider, solver, executor hoặc version.
Tất cả248 Python sources trong C2 manifest giữ nguyên byte. Không đụng
PokiguardAuto/pc; không attach game, network/API hoặc phát native input.

## Parity và fault evidence

- Full regression: **PASS — 1,960/1,960tests;171.389s;6 new C3 cases**, xem
  [full log](../artifacts/5c3_integration_v1/full_regression.log).
- 100 paired Stop trials chạy **actual `basic_auto_bot.run`**, với game/window/
  capture/input surfaces bị chặn.50 pending,50 không pending; sink-raise, sink
  degraded, already-stopped và running observer. Gameplay logs/order giống
  disabled; initial transport prime→runtime read→is_running→hotkey Stop,
  zero provider poll/capture/native input sau Stop.
- Thêm actual controller Stop khi native compute process đang treo, dùng
  RunShadowSession/native separate logger. Cleanup assert mọi compute child
  reaped. Đây là offline synthetic process fixture, không phải game hang.
- 180 isolated worker trials: crash, corrupt reply, config binding mismatch,
  planner exception, hang/deadline, cooperative/deadline;30 mỗi variant.
  BASIC publication/dispatch data giữ nguyên, AI authorityfalse; assert cleanup
  sau mỗi trial. Counters trong raw là **trước cleanup**, không phải orphan.
- Component compositions kiểm normal/stale/wrong-turn/pending/duplicate/Stop
  qua actual AutonomousGuard/direct runtime preflight. Chỉ fake normal input
  ở normal case. Đây không phải full-controller SWAP/ACK run.
- Sáu PlayStyle giữ BASIC publication bytes; non-SWAP không được đoán thành
  supported action. C1/C2/B4 tests trong full suite giữ coverage native log
  faults, source invalid, late result, callback faults, active config/Stop/QTE.

[Raw integration trials](../artifacts/5c3_integration_v1/integration_raw.jsonl),
[test source](../../../tests/test_reasoning_integration.py).
Full controller Stop =101 shadow invocations,100 disabled controls. Không
nâng coverage Stop thành live hoặc positive SWAP/ACK/controller whole-flow PASS.
Memory/capture/QTE/ACK/navigation/recovery source byte-preservation và existing
regression là evidence hiện tại; live sequence vẫn NOT_OBSERVED.

## Latency: giữ thất bại, không advance

Đo **`_decision_fields` + existing JSON serializer + gameplay write/flush +
optional admission**, native AI logger và actual manager status callback.
3runs×10,000pairs/mode,1,000warmup/run/mode;120,000 measured pairs +12,000warmup.
Sáu profile/family strata, nearest-rank từng run/family, giữ mọi raw spike,
quantile differences và source/protocol trước đo. Không concurrent regression.
12/12 groups giữ gameplay digest/write/flush parity;264,000 publications gồm
controls vàwarmup. Đây là added publication-path probe; không gọi là toàn game
wall time hoặc đo provider/solver/input duration.

| Group không đạt | Số đo | Gate |
|---|---:|---:|
| disabled run0 / CAREFUL | paired max9.819ms | ≤5ms |
| shadow run1 / CAREFUL | family p95=1.0211ms | ≤1ms |
| sink_fault run2 / Skill Rush NONE | paired max10.1486ms | ≤10ms |
| shadow run2 / Demon NONE | paired max10.2197ms | ≤10ms |

**8/12 group PASS;4/12 NOT_QUALIFIED.** Không pool hoặc làm tròn để tạo PASS.
Shadow aggregate p95 runs0/1/2=.4877/.5476/.4976ms; p99=1.0617/1.1466/.9809ms.
Disabled spike xảy ra giữa hai path có cùng logic; chưa thể quy nguyên nhân cho
AI. Chưa xác định một runtime flow regression hoặc sửa code theo suy đoán.

Giới hạn quan trọng: burst corpus dùng một SIMPLE-bound adapter cho sáu
profiles; conflict/unsupported handling và overload được exercised. Native AI
writer thật, gameplay writer là deterministic digest sink. Chưa qualify healthy
per-profile/native-common-writer workload; adapter drops≈5.7–5.9k/run trong
overload không được gọi là healthy zero-loss. C1 rate-cap qualification còn
nguyên scope, B4 saturated failure vẫn giữ.

[Protocol](../artifacts/5c3_integration_v1/performance/protocol.json),
[summary](../artifacts/5c3_integration_v1/performance/benchmark.json),
[raw](../artifacts/5c3_integration_v1/performance/raw.jsonl).
Một setup error tuple-unpack xảy ra trước sample đầu đã giữ tại
`invalid_setup_tuple_unpack/`, không dùng làm acceptance. Executed tool source
được archive/hash; final tool bỏ resource prototype chưa chạy, benchmark/codec/
session/digest AST giữ nguyên. Không rerun để thay failed samples.

## Resource và diagnostics decision

C3 integrated CPU/private-memory/30min growth/healthy critical zero-loss:
**NOT_MEASURED**. Chưa chạy resource qualification tiếp theo sau latency
nonqualification. B4 30min component soak và C1 separate CPU proof không được
đổi tên thành C3 whole-integration acceptance.

Không đổi sink runtime khi chưa có nguyên nhân/evidence so sánh. C1 capped
separate vẫn là implementation hiện có cho opt-in shadow, defaultOFF;
**C3 whole-integration sink NOT_QUALIFIED**, chưa promotion/live. Common
namespace/filter là phương án phải so sánh nếu native separate không đạt;
không sửa accepted gameplay writer chỉ để vượt test. Queue bounds, logging
fault isolation và selectionfalse giữ nguyên source C2.

## Gates và handoff

| Gate | Result |
|---|---|
|248 existing C2 sources / version / unrelated work preserved | PASS |
|Composed parity + actual full-controller Stop / pending / hung child | PASS offline scope |
|Regression / worker fault matrix | PASS — 1,960/1,960tests;171.389s;6 new C3 cases |
|Healthy full integration latency / null-control qualification | NOT_QUALIFIED / PENDING |
|Integrated CPU/RAM/growth and sink choice | PENDING |
|Full controller positive action/ACK and native writer timing | PENDING |
|Live parity, actual QTE/lease/re-entry | PENDING / NOT_OBSERVED |
|REASONING selection, R2 game model, efficacy | NOT_ENABLED / NOT_MEASURED |

Final source fingerprint (250Python files):
`168c81eb29fd929b0dc4b0a0d83c6fd14a09790aefa8c8f22067bd5b541e07fe`.
Parent C2 fingerprint:
`404a12828c2abdcedb7a5f8ddbcdaa08a48aa81934f6e1a96fd826621e2bfd3e`.
New files: [offline verifier](../../../tools/verify_reasoning_integration.py) và
[integration tests](../../../tests/test_reasoning_integration.py).
Stop semantic/cleanup assertions PASS; C3 added Stop latency/cooperative cancel/
reap timing chưa qualify. Source audit/final fingerprints và artifact hashes:
[verification](../artifacts/5c3_integration_v1/verification.json),
[manifest](../artifacts/5c3_integration_v1/manifest.json).
Unrelated preexisting dirty work giữ nguyên; HEAD chỉ là reference, không
giả worktree clean hoặc rollback sourcev1.2.5.

Exactly one next: **same [5C.3](../prompts/5C3_BASELINE_SHADOW_AND_FAULT_ACCEPTANCE.md)**,
với [measurement return plan + bounded live runbook](../research/5c3_measurement_return_plan.md).
**STOP5C.3 PARTIAL**; chưa PASS_OFFLINE_LIVE_PENDING và chưa cho C4/D.
Bú win giữ nhánh phụ khi người dùng báo test. Không build/version/Git mutation.
