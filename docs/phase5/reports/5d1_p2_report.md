# 5D.1-P2 — Decision budget, warm worker và chuẩn bị calibration

Ngày2026-10-12. **PARTIAL / OFFLINE SOFTWARE VERIFIED / LIVE_PENDING.**
Parent: [P1](5d1_p1_report.md). Không attach game, đọc memory thật, capture thật
hoặc phát input thật. Source vẫnv1.2.5; không build/version/commit/push/tag.

## Kết quả và quyết định của người dùng

P2 đã khắc phục giới hạn first-root của P1 trong scope software native fakes.
Controller lấy BASIC từ policy hiện có, rồi cung cấp **cùng immutable state và
incumbent đó** cho worker. Không tính lại BASIC trong producer ở chế độ budget.
Worker warm/reuse chạy process riêng. Bước quyết định trả sớm khi kết quả hoàn
tất, chờ tối đa deadline đã trừ R/U/M; timeout/fault/unknown giữ BASIC.
Fresh/final preflight, mapping, input ownership, pending và ACK vẫn dùng đường cũ.

Ban đầu P2 tuân thủ no-wait và đo được0 timely overrides kể cả warm worker/late
checkpoint. Hai exploratory probes được giữ tại artifact root; không gọi chúng
là acceptance. Người dùng đã quyết định trực tiếp trong chat ngày2026-10-12:
dùng budget sau khi có BASIC, ưu tiên bỏ duplicate BASIC; không cộng random delay
cho nước suy luận. [Contract mục3](../EXECUTION_CONTRACT.md) được cập nhật rõ
ngoại lệ này. Không cố trì hoãn BASIC để làm positive fixture.

Riêng foreground ordinary SWAP có receipt valid: bỏ random reaction0–1s và
random inter-click jitter0–1.5s. Giữ adaptive base pacing, cursor settle/mouse
hold, hai click và foreground/Stop gates. BASIC/fallback giữ random cũ.
Không đổi thứ tự provider/read/capture, skill/card/QTE/PASS, recovery hoặc room.

## Bằng chứng offline

Current: [qualification V3](../artifacts/5d1_timely_activation_v1/qualification_v3/qualification.json),
**56/56 gates PASS**. Source269 Python files;7existing changes +5new,
257/264predecessor files byte-preserved. Exact manifests, five disabled complete
trace pairs và reconstructed controller/executor/farm/desktop AST đều đạt.
Historical C3/C4/P1 sources vẫn bound archive; không relabel acceptance cũ.

-6cold actual-controller positives:3Simple +3Careful. Không pre-admit job,
  không chờ runner trước `controller.run`. Cả6 đề xuất qua ROOT/FRESH/FINAL,
  normal input và ACK; read/capture/input/ACK order khớp predecessor.
-Decision slice N6: p50=694.4777ms; empirical p95/p99/max=716.5141ms.
  Tất cả trả trước deadline. Đây là sample software nhỏ trên native fakes,
  không là native timing bound hoặc toàn bộ app latency.
-7actual overrides trong15trial block:6đã ACK +1pending case. Pending chỉ phát
  một input và không gửi BASIC thay thế. Pending case không tính là WIN/ACK.
-Budget50ms không đủ để admit, worker exception/corrupt reply và minimal unknown model giữ
  BASIC; stale/wrong-turn/reserve-final/Stop trong decision không phát input.
-Actual disk writer:5eligible/enqueued/written,0drop/failed/discard, accounting
  valid; bridge/worker/writer được cleanup. Component tests kiểm reuse2jobs/
  1child, hung worker Stop signal, startup Stop, deadline không reset và lỗi IPC.
  Disk-writer controller run là một diagnostic proof riêng, không cộng vào
  thống kê15trials/7overrides phía trên.
-[Targeted deadline probe](../artifacts/5d1_timely_activation_v1/deadline_probe.json):
  actual controller submit job với worker hang/budget1500ms, hết deadline giữ
  BASIC và ACK đúng đường cũ;5/5checks PASS, child được reap. Đây là actual
  timeout proof riêng, khác với50ms admission skip; không native IO/efficacy claim.

[Focused](../artifacts/5d1_timely_activation_v1/focused_tests_v2.txt):104tests PASS,
44.999s. [Full regression cuối](../artifacts/5d1_timely_activation_v1/full_tests_v2.txt):
**2058/2058tests PASS**,237.132s. Prior full block237.544s giữ tại artifact root.
V1 qualification dừng vì collector script dùng sai tên accounting key; V2 sửa
tool đo, không sửa gameplay. V3 rebind sau làm rõ module docstring/comment về
bounded decision budget; runtime behavior giữ nguyên. Failed component assertion trước đó dùng nhầm
tên reason counter; current assertion kiểm `VALID_COMPLETED_R1` và actual trace.
Các raw kết quả trước sửa được giữ, không ghi đè.

## Activation và telemetry đã chuẩn bị

Explicit per-run session factory đã nối desktop→farm→combat ở cả hai combat
branches; defaultNone giữ đường cũ. File-only loader kiểm artifact/sample/clock
report SHA, source/build/config/cohort, expiry≤7ngày, input/timer mode, completed
2clicks và read interval. Provenance thiếu/đổi/expired bị gate; native model chỉ
có version, không điền UNKNOWN bằng0 hoặc synthetic Health20.

Đây là **API injection seam**, chưa là nút/CLI activation usable cho operator.
UI REASONING vẫn gated, ordinary preferences BASIC/shadowOFF giữ byte/SHA cũ.
Synthetic loader tests chỉ exercise schema, không chứng minh native calibration.
Một pinned local clock report vẫn cần được review độc lập; loader không tự chứng
minh physical U chỉ từ verdict string hay các hash do người tạo fixture cấp.

Optional BASIC timing collector ghi host monotonic trước final runtime read,
read-end/validation-end, remaining/failure, input result/mode và executor-return.
Return là **upper bound sau required second click**, không phải exact click2
timestamp; không đổi executor để đo. ACK nằm trong existing combat log/trace,
chưa có standalone native join/all-attempt calibration export. Writer chỉ dừng
ở run boundary; collector được tạo lại giữa matches, sequence giữ liên tục.
Không flush/join disk hoặc worker trong action/Stop.

## Giới hạn bắt buộc; vì sao chưa mở game

1. **U/native R/cohort chưa calibrated.** Existing `MatchService.server_tick`
   đọc integer field, không gọi smooth `get_ServerTurnRemainingSec`. Reverse
   getter còn trừ Unity unscaled elapsed, pause và localFX hold. Không suy ra
   U≤1s chỉ từ kiểu Int32, không gán U150/R2000 từ synthetic authority.
   [Timer symbols](../../il2cpp_symbols.md:863),
   `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt` getter4940.
2. **Affected long-soak/paired CPU/SLO chưa requalified** cho producer/runner mới.
   Component/fault/Stop/current disk proofs ở trên không thay C3's30min evidence.
3. Cần source-bound operator activation, ACK/all-attempt export và workflow
   review timer bound trước BASIC calibration. Chưa có accepted native artifact.
4. Efficacy/actual damage/survival/boss policy chưa đo. Positive fixtures có
   numerical effects synthetic; minimal production model vẫn giữ unknown.
   Demon/Mega/skill/QTE/Coop reasoning không được promote từ Simple/Careful.

Calibration draft **BASIC/shadowOFF/reasoningOFF default3/max5 TOTAL attempts**
vẫn prepared/not activated;0attempts. Không tăng cap để bù invalid. D1 draft12
chưa chạy; C3 batch6 đã đóng. Chưa cần người dùng mở phòng trong P2.

## Source và bàn giao

Runtime changed: `reasoning_pilot.py`, `desktop_farm_controller.py`,
`win32_input.py`, `tools/basic_auto_bot.py`, `tools/farm_run.py`.
New: warm runner, file artifact loader/session, swap timing collector/session.
Tests/qualification fixture và AST source audit được cập nhật có explicit pins.
Không sửa BASIC policy/ranking hoặc provider; không chạm game/V1 files.

Archive: [P2 artifacts](../artifacts/5d1_timely_activation_v1/), including exact
before264sources, runtime/source manifests, raw controller traces, worker/
preparation/checkpoint timelines và review diff. Current qualification source
fingerprint nằm trong source manifest; verification/artifact manifest xác nhận
bindings và unchanged preferences/version.

Current269-file fingerprint:
`ba0adf97d87b7efa93f2fa044bef2962814d1a4d375f2ba1bbc6600995c5c817`.
HEAD vẫn `c646acfa5e895732bbdade553f9d7bd61171cd29`, branch
`codex/phase3a2-board-repair`; worktree có changes từ các phase/nhánh trước,
không reset chúng. Ordinary preferences SHA256 giữ
`a8ce6394a258792f866a3357de2043ab6ecfc6d829e9af4e66848cfd2794bc46`.

Exactly one next:
**[5D.1-P3 activation/affected qualification/calibration readiness](../prompts/5D1_P3_ACTIVATION_AND_CALIBRATION_READINESS.md)**,
selected only, **chưa thực thi/chưa live**. Return D1 khi required gates/native
evidence đủ. Không D2, không tự build. **STOP P2.**
