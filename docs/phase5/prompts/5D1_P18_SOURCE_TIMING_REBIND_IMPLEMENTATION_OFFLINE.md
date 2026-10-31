# 5D.1-P18 — Reviewed source/timing rebinding implementation, offline

**CLOSED / PASS SCOPED OFFLINE / LIVE NOT ACTIVATED.** [Báo cáo P18](../reports/5d1_p18_report.md). Parent [P17](../reports/5d1_p17_report.md),
[review/addendum proposal](../research/5d1_p17_source_timing_rebind_contract.md).
Chỉ thực hiện khi user yêu cầu tiếp tục. Đọc AGENTS/STATUS/router/contract/
capability, P9/P11–P17 và P17 raw recomputations/source ledger/34planned cases.

## Entry và scope

Pin actual source291 a8aba6c0…, host/build/HEAD/preferences/claims/parent artifacts.
Nếu drift thì giải thích compatibility trước sửa, không reset unrelated work.
Đây là offline implementation/readiness **một milestone**, không thêm research
clock loop hoặc tự chạy calibration. Không game/UI/observer/process lookup/
memory read/capture/input/network, build/version/Git hoặc real preferences.
Không đổi reader/controller/BASIC/solver/planner/model/executor/random/pacing/
hold/ACK/FarmRun/room/recovery. Không reuse/reset consumed request.

## 1. Correct command accounting

command_wait_ms phải count **hai cursor settles, hai holds** theo actual two-click
executor: default3120ms, không3060. Sửa setup builder hard-code và dependent
fixtures đúng nghĩa, không sửa executor. Test bằng actual fake-executor maximum
trace/counts và nonzero/zero settle variants, không chỉ mirror helper formula.
Finite/bounds/unsupported transport checks giữ. Historical3060records/old
contracts/raw requests không được overwrite hoặc tự relabel.

## 2. Separate reviewed-v3 source/timing verification

Implement proposal P17 bằng separate schema/verifier/setup export. Giữ old v1/v2
raw reject semantics và strict finite-U; không catch failure rồi accept. Kiểm
parent v2 trên original target290, exact P16 transition và exact P18 frozen
successor riêng. Pin complete manifests/bytes/methods; same-file protected
deadline/Stop/factory edit vẫn bị reject, không generic method/file exemption.

Giữ26P11 BASIC intervals/20anchors/3attempts/30rows/4EVOLVE/original errors;
7P15 returns là operational supplement, không BASIC calibration hoặc7AI jobs.
Giữ5root-span vetoes và16missing timings. Raw SHA/identity/result/terminal/
watermark/cap semantics phải được recompute, không tin PASS/totals tự khai.

New draft/review pin parent P9 contract/accepted decision và P17 addendum.
Current-source command correction không cấp compatibility cho old requests.
Setup loader chỉ map validated data sang typed operational authority; giữ U/
transport/alignment null, no numerical model effects và BASIC default.

## 3. Component monitor tại callback hiện có

Reviewed v3 request bắt buộc opt-in monitor; session truyền mode đã validate
cho collector. Default/no-authority/legacy flow giữ. Tại finish **sau executor
return**, dùng existing timestamps và frozen components:

```text
H_budget=controller_tail_ms+selector_extra_ms
I_budget=final_input_ms+command_wait_ms
aggregate R giữ formula hiện có, shared guard cộng đúng một lần
```

H/I budget exceed, aggregate exceed hoặc invalid interval phải ghi flag/reason/
limits rồi signal AI-only fault qua callback hiện có. Payload và session receipt
khớp first fault. Không thêm input/read/capture, không gửi BASIC thứ hai sau
input, không đổi pending/ACK hoặc làm FarmRunner stop/recover chỉ do AI lỗi.
Boundary equality/1ns over, after-input fault, healthy retirements/failure/Stop
race/cap/default parity phải có meaningful tests. Không thử fault trong game.

## 4. Freeze, validation và allowance

Thực hiện34planned cases và focused/full regression phù hợp boundary. Capture
exact diffs/AST protected paths, native/parent/claim/game/preferences preservation.
Freeze final source trước full regression/qualification; giữ raw failures, không
nới published thresholds hoặc repeat chỉ để tìm PASS.

Fresh qualification dùng actual current pilot methods, admission+3checkpoints,
v3 operational collector với authority+monitor (P16 main pipeline chỉ BASIC
collector), error/timeout/fallback/Stop/cleanup/bounded writer/stress. Không claim
accepted-override/native latency từ retention benchmark; giữ limitation rõ.
Nếu cần tối ưu metadata để đạt SLO thì giữ bytes/meaning của telemetry và flow,
ghi before/after evidence, không nới gate.

Recompute S/R trên **actual final P18 source/host**, không dùng14.2102/6761.9149
như current authority có sẵn. Native H/I provenance giữ riêng26+7; corrected
command3120, guard≥250/margin≥100/read-span100/defaultbudget4000/cap6000 và
one-t0/no-reset giữ. Sample maxima descriptive; first exact click NOT_MEASURED.

## 5. Draft và closure

Nếu đủ gate, dựng successor draft source-only, accepted=false/live=false,
run/expiry/claim null; same P11 account/Starburst1289lv73/Phoenix-user-declared/
normal→normal/default_attack/SIMPLE/SOLO/foreground/two_click, target3/max3TOTAL.
Không UI REASONING đại trà, không cấp real accepted activation/request/claim,
không chạy live hoặc reset P15. Cohort/setup cần user chuẩn bị ở bước sau.

Report `reports/5d1_p18_report.md`, source/host/config/qualification pins, exact
changes/checks/remaining UNKNOWN; update STATUS/README/router/capability. Chọn
**một** next theo evidence: targeted remediation nếu thiếu, hoặc bounded
successor pilot riêng nếu readiness đủ. Chưa D1cap12/CAREFUL/Demon/Mega/D2.
**STOP P18.**
