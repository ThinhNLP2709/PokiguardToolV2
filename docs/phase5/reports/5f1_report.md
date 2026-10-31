# 5F.1 — Packaged acceptance: CLOSED

Ngày31/10/2026. **PASS STRONG — scoped technical packaged acceptance.**
Đủ cap4 =2BASIC+2REASONING,4/4WIN/nhận thưởng/về phòng. Không còn required gate
pending trong phạm vi công bố bên dưới. **Next duy nhất:5F.2, selected only;
chưa thực hiện**, Phase5 chưa đóng roadmap hoặc release.

Parent: [5E.2 scoped technical acceptance](5e2_report.md).
Prompt: [5F.1](../prompts/5F1_PACKAGED_ACCEPTANCE.md).
[Machine closure](../artifacts/5f1_packaged_20261031/closure_20261031/closure.json),
[native exposure](../artifacts/5f1_packaged_20261031/closure_20261031/reasoning_exposure.json),
[latency samples](../artifacts/5f1_packaged_20261031/closure_20261031/latency_samples.json).
Preparation reports/manifests là lịch sử; final evidence manifest là snapshot
đóng batch. Không mở lại E2 hoặc F1 để tìm thêm override.

## Exact artifact/source

| Trường | Giá trị |
|---|---|
| Version/HEAD/branch | v1.2.10 / `c646acfa5e895732bbdade553f9d7bd61171cd29` / `codex/phase3a2-board-repair`; dirty worktree khác được giữ |
| Source,370Pythonfiles | `f0aeab76e40ffc12fa11692702119d181bc8e869ae44033f7624ec80d1a8018b` |
| ZIP riêng | `D:/PokiguardToolV2/build/phase5-f1-20261031-acceptance/PokiguardToolV2-v1.2.10-win-x64.zip` |
| ZIP SHA256 | `2a7c74d4a8236a2a58404d8ef057be2c44d141fe0cf90d1d6d75533109fd6515` |
| ZIP size/entries | 14,842,150bytes/996, integrity PASS |
| EXE đã giải nén, kiểm offline và cả4live | `docs/phase5/artifacts/5f1_packaged_20261031/acceptance_extracted/PokiguardToolV2/PokiguardToolV2.exe` |
| EXE SHA256 | `a41cb23c55a27b7c45e21b3b92bc26261bd338b80b4125cfb485006fc4184efe` |
| Embedded build manifest SHA256 | `1ebdeec72244e2df2c0383213b379b97bf8887b3946c9ec657bea4e6b9f0bcaf` |
| Build | Python3.11.9, PyInstaller6.22.0, Windowsx64; [dependency versions](../artifacts/5f1_packaged_20261031/dependency_environment.json) |

[Artifact identity](../artifacts/5f1_packaged_20261031/acceptance_package_identity.json),
[source manifest](../artifacts/5f1_packaged_20261031/final_source.json),
[setup boundary](../artifacts/5f1_packaged_20261031/source_boundary.json).
133embedded runtime modules+entry code khớp source compile optimize1 bằng code
objects, không chỉ HEAD. Exact ZIP/EXE/source không thay giữa offline/BASIC/R.
Không bundle test/private request/claim/account calibration/game/reverse/model
tải ngoài; không download dependency trong lúc chơi.

## Package activation và flow

F1 thêm **lab opt-in riêng** cho exact frozen package. Source-only pilot gate
cũ vẫn từ chối frozen. Request pin EXE/source/build/host/config/cohort/expiry,
cap2 mỗi arm trong cap4, one-shot claim theo batch/arm, manual Start; không
resume/reset cap bằng nonce mới. Native BASIC2 review được xác thực lại từ
original run/claim/request/timing/combats trước khi tạo REASONING2 authority.
Private dataRoot/prefs/calibration nằm ngoài ZIP; ordinary prefs/UI vẫn BASIC.
Đây không là acceptance cho public UI REASONING tùy ý tài khoản/profile.

New package modules: `packaged_reasoning.py`, `packaged_verification.py`;
build recipe/manifest/synthetic probe và11package gate tests. Executable deltas
trong file cũ chỉ thuộc setup functions của reasoning_operational/windows_entry/
tools.desktop_ui. So trướcF1:363oldPythonfiles byteexact;
reasoning_warm_runner chỉ LF→CRLF, AST/code giữ nguyên. Solver/BASIC/planner/
reader/controller/action executor/QTE/ACK/pending/lease/recovery/navigation
không đổi. Không thêm memory read/capture để chờ planner.

Native package có ACK trên BASIC và terminal dispatch trên R, original strong
terminal/pending/accounting và existing preflight/flow đều đạt. Counts polling
BASIC và R khác do thời lượng/số lượt; không claim raw count bằng nhau. Exact
reader/capture/executor code/order parity dựa source và embedded code mapping,
không biến memory transient_capture_polls thành số screenshot. Paired screenshot
counts/CPU/memory overhead trong game **NOT_MEASURED**. Worker không gửi input.

## Live4 — nguyên batch đã đóng

Batch `F1_45604976ec3b4aa299144ee25928c9d7`, Solo Lieyun77/b12,
Demon Aegis normal/none/pet_passive, Khiên,4Kiếm hiệu dụng/floor2, giữ nguyên đồ.
Foreground/two_click/1280×640, BASIC incumbent/shadowOFF/budget4000ms.
Người dùng tự Start TOOL; không computer-use tự chơi hoặc live fault injection.

| Arm | Attempts/WIN | SWAP | ACK | Proved terminal exclusions | Local turns/match | Confirm/return |
|---|---:|---:|---:|---:|---|---:|
| BASIC slots1–2 | 2/2 | 4 | 2 | 2 | 3,1 | 2/2 |
| REASONING slots3–4 | 2/2 | 2 | 0 | 2 | 1,1 | 2/2 |
| Total | 4/4 | 6 | 2 | 4 | descriptive, unpaired boards | 4/4 |

BASIC farm `61120b0999cd4982ba97cad5bb98080b`;
R farm `6f242ad7f1e14b59b9f9f8827fa414a3`.
Không loại/bù matches; cap4 hết.0read/providerDTO/input-safety/timeout/PASS/
abort/recovery.0duplicate/wrong-turn/stale/input-after-stop/conflict. Native
pending sạch, STRONG WIN/bossHP0 trước cleanup, final BOSS_LOBBY. Both UI/poller
đóng sạch, startup exit0; game không bị đóng.

Hai unique jobs/decisions đều completed retention: `D3_BASELINE_ALREADY_BEST`
(17candidates) và `D3_UNCERTAINTY_OR_PRESSURE_RETAINS_BASIC` (20candidates).
Hai nước đã gửi trùng BASIC, qua ROOT/FRESH/FINAL;6selection records là
revalidation checkpoints, không phải6quyết định/nước.0failure fallback/override;
không bắt planner đổi nước. R1pure-worker payload ghi OFFLINE_ONLY vì không có
quyền input; native dispatch được chứng minh riêng bằng matched source/job/
board/turn/action/timing và terminal, không suy từ payload đó.

2workers/processes completed/reaped2,0workerfault/late/rejected/stalediscard/
orphan.12AIrecords eligible/enqueued/written,0loss,2writer receipts flushed/
closed.18aggregate admission skips `UNSUPPORTED_OR_UNAVAILABLE` là poll-level
refusals, không là18action fallback; raw reason không tách sâu hơn nên không
đoán nguyên nhân cụ thể.2completed actions đều có valid receipt,0breaker/
component overrun/sharedguard exhaustion.

UI `ai_status=OFF/SHADOW_DISABLED` vẫn mô tả ordinary shadow setting; lab
operational worker/status được theo dõi bằng separate receipts/logs. Không
advertise widget đó như monitor tổng quát của lab R. Raw worker/proposal/input
correlation và writer counters mới là evidence tại đây.

## Timing/uncertainty

BASIC package H126.2615ms/I2409.3919ms samplemax từ2ACK. R dùng max với E2 native
H/I đã pin: H127.3942ms/I2409.3919ms +selector2.6446ms +full commanded wait3120ms
+sharedguard250ms =reserve5909.4307ms, margin100ms, budget4000ms. Không đổi bound
hay coi samplemax là future bound. NativeU/transport/alignment **UNKNOWN**.

R samplesN2: compute66.3042–77.9866ms; decision wait158.0164–206.1872ms;
observation→decision exit323.7610–416.1129ms; controller tail119.6581–126.1408ms;
input upper bound655.5364–657.7899ms. Raw root read≤26.3845ms/final≤2.5040ms;
deadlines/intervals/component guards hợp lệ. File latency có p50/p95/p99/max/N,
chỉ mô tả N2. R cả2WINngay turn1 nên **reasoned nonterminal ACK NOT_OBSERVED**;
không tính terminal samples như ACK calibration. Actual account energyUNKNOWN,
throughput/localturn không là energy/win. Efficacy **INCONCLUSIVE**, BASICdefault.

## Offline và regression

Exact EXE: clean/oldv2prefs BASICdefault/shadowOFF/0autoStart; graph import/path
probe và worker2healthyjobs/1child reaped PASS. Crash/corrupt/hang cancellation/
fallback/Stop-signal, writablepath, rotation20records/2files, boundedqueue và
actual writer path failure PASS. Stop .0097–.0126ms là runner signal nhỏN,
không end-to-end emergency UI live. Invalid request bị reject trước provider;
startup error MessageBox hiện có đợi đóng, own negative-test process được kết
thúc riêng sau15s; không claim clean process exit cho ca đó.

108focused testsPASS;15packaging/app-path+11new gates có overlap, không cộng
thành sample độc lập.370files compile optimize1PASS;100qualification cycles×6
lanes PASS max2.6446ms, real sourceworker/log cleanup;13native-control parser
fixtures PASS, fixture tổng hợp không được dùng làm live authority.

Final-source full regression153modules/2779cases:130modules green,
199failure+26error events/213unique IDs.211IDs tái hiện preF1 overlay;1cold-close
timing case tái hiện trong byteexact old writer component (1/30, queued1 khi
hết flush0.5s, discard1 khi close). Test preflush khi queue rỗng không prove
READY; unchanged behavior giữ nhãn, live receipts bắt buộc0loss.1expected E2
source-boundary rejection giữ nguyên vì F1 có delta riêng. Không có unexplained
new failure; không gọi toàn suite green. [Regression audit](../artifacts/5f1_packaged_20261031/regression_audit.json).
Candidate harness assert-side-effect/optimize1 và stdin multiprocessing lỗi đã
sửa/rerun; chỉ final exact ZIP nhận acceptance. Không đổi runtime sau live.

## Final declared matrix / rollback / STOP

| Capability | Kết quả được công bố |
|---|---|
| BASIC/default/fallback/log isolation | Package offline và current BASIC2 native PASS; giữ behavior trướcF1 |
| DemonShield R1SWAP | **Experimental lab opt-in**, exact package/current b12/Solo/Lieyun77/account/loadout/4effective/floor2; packaged2completed retention/terminalWIN PASS |
| Native current package override / reasoned nonterminalACK | NOT_OBSERVED; historical sourceE2 override/ACK vẫn riêng, không đổi nhãn thành F1 live |
| Simple/Careful/HT7/Mega reasoning | Historical scoped source pilots; current package acceptance UNSUPPORTED/NOT_OBSERVED |
| Skill/QTE/PASS | NOT_APPLICABLE to declared passive DemonSWAP profile; no package acceptance for other profile domains |
| Other Demon targets, Coop/Búwin/Dinosaur reasoning/shadow | UNSUPPORTED; BASIC branches giữ scope riêng |
| R2/learned model/general boss/refill/damage/survival model | DISABLED/UNSUPPORTED |
| Live emergency/resume/re-entry/fault injection | NOT_OBSERVED; offline evidence không bị đổi nhãn thành live |
| General public UI opt-in / arbitrary account/loadout | Not accepted by lab F1; no automatic promotion |
| Hiệu quả vượt BASIC | INCONCLUSIVE;0override không là lỗi, không tự PROMOTE |

9rollbackZIPs giữ nguyên, gồm acceptedv1.2.4 và releasedv1.2.10 SHA
`7249a3e5711ba319f733f43c8b23c9a5f59857889f01dcb4e3da314261e065c5`.
Stop hiện có→đợi cleanup→mở thường không lab args để BASIC; prefs thường giữ
nguyên. Binary rollback dùng ZIP riêng, không chuyển claims/authority/checkpoint;
không hứa v1.2.4 cũ tương thích b12. [Runbook](../artifacts/5f1_packaged_20261031/RUNBOOK.md).

Native logs tại `docs/phase5/artifacts/5f1_packaged_20261031/live_data/logs/`:
`farm_runs` giữ trận/input/terminal, `desktop_ui/*/packaged_acceptance` giữ AI/
timing/worker/watermarks. Normal packaged log root vẫn LOCALAPPDATA, không trộn
private F1 evidence. Diagnostics không block input; fallback chỉ trước dispatch,
sau đó existing executor/ACK giữ ownership, không input thứ hai.

**Next:[5F.2](../prompts/5F2_CLOSEOUT_AND_ROLLBACK_HANDOFF.md), SELECTED ONLY.**
F1 CLOSED/cap4exhausted. Không thêm trận, commit/push/tag/version/release/F2 ở
lượt này; không ghi game `D:/pc` hoặc referenceV1. Roadmap chưa complete.
