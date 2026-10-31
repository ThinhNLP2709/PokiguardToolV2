# 5C.2 — Tab AI và immutable run configuration

Ngày 2026-10-10, Asia/Saigon. **PASS STRONG — OFFLINE_UI ONLY**.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP / PARENT / MODE: 5C.2 / 5C.1 PASS STRONG / OFFLINE_UI
SOURCE VERSION: v1.2.5 existing worktree; historical baseline v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
SOURCE FINGERPRINT (248 Python files):
404a12828c2abdcedb7a5f8ddbcdaa08a48aa81934f6e1a96fd826621e2bfd3e
LIVE: NOT_RUN
REASONING SELECTION: DISABLED / NOT_IMPLEMENTED
WHOLE CONTROLLER LATENCY / EFFICACY: NOT_MEASURED
BUILD / VERSION BUMP / COMMIT / PUSH / TAG: NONE
NEXT: 5C.3 SELECTED / NOT_EXECUTED; STOP 5C.2
```

User yêu cầu “triển khai bước kế” sau handoff C1. Entry đã đủ theo
[C1 report](5c1_report.md), [prompt C2](../prompts/5C2_AI_SETTINGS_AND_IMMUTABLE_RUN_CONFIG.md),
[contract](../EXECUTION_CONTRACT.md). Không mở live batch hoặc nhánh phụ Bú win.

## Đã hoàn tất

- Tab **AI**: Cơ bản mặc định; REASONING selection bị khóa và có giải thích.
  Shadow explicit opt-in, mặc định tắt; budget integer 50–6000 ms, default 4000.
- Preference v3 đọc v1/v2/v3. Thiếu AI block chỉ thêm safe defaults; invalid AI
  block báo warning và giữ valid gameplay/preferences khác. Save AI riêng không
  thực hiện window operation hoặc áp các trường gameplay đang chỉnh dở.
- Frozen AISettings nằm trong DesktopConfig frozen hiện có. Start/Resume khóa
  intent tại boundary cũ; config hash bao gồm full accepted DesktopConfig.
  Không ghi đè tactical thresholds khi quan sát đề xuất.
- Optional RunShadowSession truyền adapter vào hai combat invocations sẵn có.
  Disabled gọi BASIC với arguments cũ, không import shadow/runner/diagnostics/
  planner, không tạo AI session/thread/queue/process.
- Status reason/suggestion/override-disabled/written/dropped/degraded cập nhật
  qua observer callback và cached Desktop snapshot hiện có. Listener fault/lock
  busy/stale generation/old combat/after Stop không can thiệp BASIC.
- Bú win/Coop shadow unsupported và không tạo worker; baseline Coop giữ nguyên.
  Các profile solo vẫn chỉ quan sát publication SWAP được C1 hỗ trợ.

Chi tiết thuật ngữ, config/version mapping, retention và giới hạn:
[spec C2](../specs/5c2_ai_settings_and_run_intent.md).

## Nguồn đã thay đổi và bảo toàn

[Source audit](../artifacts/5c2_ai_settings_v1/source_audit.json),
[manifest](../artifacts/5c2_ai_settings_v1/source_manifest.json),
[diff riêng C2](../artifacts/5c2_ai_settings_v1/step_diff.patch).

7 existing files thay đổi: desktop_control_plane, desktop_preferences,
desktop_farm_controller, desktop_ui, reasoning_shadow, tools/farm_run và test
tab-order hiện có. 2 files mới: reasoning_settings.py và test_reasoning_settings.py.
**239/246 existing Python sources byte-preserved**, không xóa source. Dirty
work đã có từ trước, version.py và release artifacts được giữ nguyên.

14/14 source audit gates PASS. `tools/basic_auto_bot.py` byte-preserved so C1;
solver/provider/capture/executor/ACK/QTE/pending/input lease/navigation/recovery
code không thay. **Toàn bộ AST module tools/farm_run.py khớp trước C2** sau khi
loại optional shadow parameter/forwarding branches. Hai BASIC calls trong
disabled branch giữ nội dung cũ. Shadow admission/log forwarding/Stop/close/
config binding/factory ownership implementation khớp AST trước C2; factory chỉ
đổi một docstring. Reproduce: `python docs/phase5/artifacts/5c2_ai_settings_v1/verify.py`.

Đây là source/seam evidence, chưa thay live read/capture/order/call-count proof
của C3. Desktop UI poll log có thêm ai_status trong controller snapshot, nhưng
không thêm timer/provider read/log sink. Combat gameplay writer không đổi.

## Immutable intent, capability và lỗi

Preferences `pokiguard.desktop_preferences.v3`; AI block
`pokiguard.ai_settings.v1`; frozen run copy `pokiguard.ai_run_intent.v1`.
Config SHA xuất hiện trong snapshot versions/decision diagnostics và AIStatus;
private run UUID + observation serial phân biệt combat. Session/match/board/
turn/action correlation C1 giữ nguyên. AI intent không thêm executable state vào
checkpoint và không thay canonical resume validation.

Status callback chạy ở background observer, tối đa 1 lần/giây + final, không
chạy trên BASIC admission hoặc Tk. Manager try-lock và copy frozen primitives;
chỉ nhận current active generation/observation, selection_authority luôn False.
Không có vòng game poll/capture mới. UI dùng timer/cached snapshot cũ.

Factory exception/unavailable hoặc cleanup trước chưa reaped: None/degraded và
BASIC tiếp tục, không chờ/thử lại ở action. Session Stop signal-only, C1 cleanup
chạy off controller thread. Sau controller Stop, UI giữ latest watermark và
đổi STOPPED; late status không thể bật lại trạng thái run.

Actual model/legality/input reserve/observation age và source skill/thẻ còn
UNKNOWN/unsupported; R2 promotion disabled. Budget là shadow processing cap,
không phải calibrated game input deadline. Không có tactical override thật,
lethal/safe guarantee hoặc fix boss ăn Khiên live ở bước này.

## Diagnostics và overhead

Giữ factory C1 **RATE_CAPPED_SEPARATE**: 1 job/s, 8 events/128 KiB/s, tổng queues
512 records/8 MiB, retention 10 MiB ×10 files/7 ngày. Sink directory dùng chung
`farm_runs/reasoning/` giữa các combat, không nhân allocation theo số trận.
Status callback không thêm AI log event. Counters là watermark theo observation;
written chỉ lấy writer ACK, không gọi enqueued là đã ghi; accounting_valid=False.
Sink enqueue rejection không bị cộng lại hai lần vào displayed dropped count.

C1 admission timing/CPU qualification chỉ là evidence của C1/capped workload.
C2 callback/config plumbing chưa có benchmark end-to-end hoặc CPU/RSS toàn app:
**NOT_MEASURED; giao C3**. B4 saturated separate stress vẫn NOT_QUALIFIED.
Không suy từ offline tests rằng máy ảo/live gameplay có overhead đã accepted.

## Kiểm chứng offline

- [Full regression](../artifacts/5c2_ai_settings_v1/full_regression.log):
  **1,954/1,954 PASS, 95.834 s**, exact source fingerprint phía trên.
- [29 C2 tests](../artifacts/5c2_ai_settings_v1/c2_final_from_full.log), gồm
  **6 actual Tk UI tests** với unavailable provider, không khởi động poller/game.
- [135 focused integration cases trong full run](../artifacts/5c2_ai_settings_v1/focused_final_from_full.log):
  C2, preferences, desktop controls/UI/manager và C1 shadow.
  Hai focused extracts không phải execution bổ sung.
- Native killable disk logger thật + synthetic BASIC publication: config hash,
  source correlation, written watermark và simulated sink disable được kiểm;
  common BASIC text giữ nguyên, mọi native reasoning record input_authority=False.
- Blocking/throwing listener, queue/disk faults C1, factory/setup/Stop exceptions,
  stale source/status, default no-worker, bounded budget và old prefs đều đạt.
- Start giữ accepted config khi active; Emergency Stop giữ semantics cũ và UI
  STOPPED sau worker return; Resume freeze AI budget mới mà checkpoint unchanged.
- Initial test harness thiếu PYTHONPATH/fixture runtime và pending Tk idle
  callbacks đã sửa; raw setup/intermediate logs giữ lại, không dùng acceptance.
  Final full run sạch và có footer OK; expected fatal-test output là fixture cũ.

Dataset ở bước này là synthetic/offline fixtures, không có observed gameplay
cohort, win-rate/counterfactual label, bounded live hoặc package test mới.

## Gates và handoff

[Verification](../artifacts/5c2_ai_settings_v1/verification.json): 15 required C2
gates PASS (task-scope prohibition gate ghi observed), 14 source audit gates PASS.
Old BASIC prefs/default, AI budget, immutable Start/Resume, no authority, disabled
no-worker, unsupported Coop, nonwaiting UI/status faults, native diagnostic
correlation, actual UI controls/layout, regression và source preservation đủ
để đóng **OFFLINE_UI**. Không claim live acceptance.

STATUS/ROUTER và các current pointers được cập nhật. Exactly one next:
[5C.3 — baseline/shadow/fault acceptance](../prompts/5C3_BASELINE_SHADOW_AND_FAULT_ACCEPTANCE.md).
Chưa thực hiện C3, chưa cần người dùng chuẩn bị game ở C2. C3 bắt đầu offline;
live chỉ khi người dùng kích hoạt bounded batch riêng. **STOP 5C.2.**
