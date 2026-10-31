# 5D.1-P15 — Bounded SIMPLE operational pilot

2026-10-15 (Asia/Saigon). **CLOSED / PARTIAL — REASONING REMEDIATION REQUIRED.**
Observed baseline farm flow **PASS SCOPED**; chưa đủ để đóng SIMPLE reasoning.
[Prompt](../prompts/5D1_P15_BOUNDED_SIMPLE_OPERATIONAL_PILOT.md),
[parent P14](5d1_p14_report.md),
[machine-readable audit](../artifacts/5d1_operational_p15_20261015_v1/closure/audit.json).
Không ép đổi nước, không quota override. Efficacy **NOT_APPLICABLE**.

## Kết quả và phạm vi

User đã vào phòng, kích hoạt cohort đã trình và manual **Bắt đầu trong TOOL**.
Một source UI, một Start, một FarmRun, tối đa **3 TOTAL attempts**; không resume,
reset claim hoặc chạy thêm. Game/Start do user điều khiển; agent dùng command/file
tools để mở source UI và theo dõi log hiện có, không computer-use hoặc observer riêng.

Frozen config: SIMPLE/SOLO, Starburst **1289/lv73**, Phoenix do user khai báo,
normal→normal/default_attack, foreground/two_click, BASIC incumbent/shadowOFF,
budget4000ms, target3/max3, max technical recoveries1, original1280×640/soundOFF.
Witness native ở trận đầu khớp P11: account hash, boss stats, fusion[254767,2102],
Attack[64647,4,ATTACK,0,0,0]. Opening cards[] giữ BASIC như contract. Đây là
structural witness; không chứng minh tên/effect pet hoặc damage model hoàn chỉnh.

| Attempt / match | Result | Local / boss turns | SWAP / ACK | EVOLVE | Combat time |
|---|---|---:|---:|---|---:|
| 1 / M_f976e803 | WIN | 7 / 6 | 7 / 6 | 1 failed | 103.763s |
| 2 / M_667315ef | WIN | 5 / 4 | 5 / 4 | 1 success | 79.087s |
| 3 / M_a8e80c2b | WIN | 11 / 10 | 11 / 10 | 1 success | 157.585s |

**3WIN / 0LOSS / 0UNKNOWN; 23local turns**, tổng combat340.435s. Toàn run
10:55:28.338–11:02:10.731+07, **402.393s**. UI `total_energy_used=23` là counter
của tool; không coi đây là đo độc lập lượng năng lượng game đã trừ.

23SWAP +3EVOLVE =26gameplay action commands;3entry/3result-confirm/3normal
boss-lobby returns,0recovery.20SWAP ACK có sequence evidence;3last SWAP có
`ACTION_ABORTED_STATE_CHANGED/COMBAT_LIFECYCLE_ENDED` rồi terminal bossHP0/localHP>0
và UI WIN nhất quán. Giữ cả3terminal-no-ACK, không chuyển thành ACK hoặc replay.
EVOLVE_FAILED ở trận1 được giữ nguyên, sau đó controller tiếp tục SWAP cùng turn.

Final `FARM_TARGET_COMPLETED`, controller inactive/exit0, **BOSS_LOBBY**. Farm
safety và cả3combat safety telemetry đều0 về duplicate/wrong-turn/stale/partial/
postmatch input/input-after-stop. Provider read errors/DTO rejections0;
unstable skips258/203/445 được giữ, không gọi đó là read error. Đây là kết quả
quan sát của batch nhỏ, không chứng minh mọi future run không lỗi.

## Suy luận: normal retention và coverage thiếu

Chỉ có **combat_0**:26durable events gồm16selection checkpoints,7SWAP timings,
1completed worker decision,1decision timing trước EVOLVE và1worker summary.
Không có combat_1/2; **16SWAP ở hai trận sau không có per-turn reasoning timing**.
Không gán lý do fallback riêng cho16SWAP này khi log không có.

Worker đã submit1/complete1/reap1; faults/late/rejected/log_dropped0. Ở turn7,
worker đánh giá10candidates trong **33.4749ms**, trả `RETAIN_BASELINE` vì
`NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE`; decision wait **56.5876ms**.
Nước BASIC [[2,4],[3,4]] được giữ, input/ACK đúng source. Đây là kết quả suy luận
hợp lệ, không timeout/error và không phải failure vì không override. Nó cũng
không chứng minh BASIC là global optimum. Lý do thực tế này khác benchmark P14
`BASELINE_TOP_IN_TOTAL_ORDER`; hai evidence không được trộn.

7SWAP timing budget reasons: **1COMPLETED / 1FALLBACK / 5SOURCE_CHANGED**.
Opening FALLBACK tương ứng cards[] ngoài witness. Năm SOURCE_CHANGED có root
read spans218.2233–233.3348ms, vượt policy100ms. Source
`PilotSelectionBridge.observe` (reasoning_pilot.py:149–153) từ chối admission
những spans này; observation cũ còn lại nên `await_decision` trả SOURCE_CHANGED.
Hai root spans nhỏ là49.6429ms/opening và41.7281ms/completed turn7.
Không có bằng chứng nguyên nhân sâu hơn khiến provider poll dài hơn P11;
không suy thành lỗi memory reader hoặc tự nới100ms để tăng coverage.

16selection checkpoint events không phải16lượt/16worker jobs: cùng lượt có
hai ROOT-labelled checks (root và existing fresh opportunistic check).
`SUPERSEDED_BEFORE_PREFLIGHT` là timing trước EVOLVE turn7, không SWAP input
mất log; source hash đối chiếu đúng EVOLVE đã gửi. Accepted overrides **0**.
Worker vẫn dùng runner-event schema/producer cũ và `mode=OFFLINE_ONLY` trong
payload nội bộ vì worker không có input authority; đó không phải bằng chứng
batch chỉ offline. Session OPERATIONAL_PILOT, job/source/timestamps và normal
controller actions đã được đối chiếu riêng. Selection không tự dispatch.

## Lỗi vòng đời xác định ở source, tái hiện offline

Sau combat1, controller ExitStack signal Stop cho adapter/timing. Owner đóng
worker, session finalizer flush/close writer. Receipt xác nhận bridge_closed/
flushed/closed=True,26eligible/enqueued/written,0drop/fail/queue, accounting_valid.
Old sink có `disabled=True, failure=CLOSED` sau cleanup bình thường.

`OperationalPilotSession.prepare_options` kiểm tra old `sink.buffer.disabled`
ở [reasoning_operational.py:454](../../../src/pokiguard_v2/reasoning_operational.py#L454)
**trước** nhánh thay adapter đã stopped ở457. Vì vậy sink đóng bình thường bị
coi là `REQUEST_OR_DIAGNOSTICS_UNAVAILABLE`, session faulted và không tạo bridge
trận kế. `_finalize` đóng sink ở477–480; writer `_serve` đặt CLOSED ở
reasoning_diagnostics.py:295. Đây là lỗi phân biệt healthy retirement với lỗi
diagnostics, không phải thiếu quota đổi nước hoặc BASIC ngừng chạy.

[Tái hiện](../artifacts/5d1_operational_p15_20261015_v1/closure/closed_sink_branch_reproduction.json)
gọi đúng current method với inert stopped adapter/closed sink, expiry còn hạn:
options{}, faulted=True, fault counter1, **new_bridge_calls0**. Không construct
live session, tạo worker, đọc game hoặc phát input. Raw run chỉ có combat_0 và
receipt CLOSED khớp cơ chế này. **Live session fault reason/counter chưa được
persist**, nên không giả nhận reproduction là counter bắt được trong live hoặc
khẳng định timestamp chính xác của lần gate đó. Thiếu diagnostics này cũng cần
sửa; UI `ai_status=SHADOW_DISABLED` mô tả shadow, không phản ánh session riêng.

## Timing và giới hạn

[7timing→action/terminal joins](../artifacts/5d1_operational_p15_20261015_v1/closure/timing_action_join.json)
khớp exact AutonomousSource, không dùng board hash đơn lẻ. Required second input
hoàn tất qua executor return upper bound; first exact click **NOT_MEASURED**.

| Quan sát, chỉ trận1 | Max ms | So với calibration / reserve |
|---|---:|---|
| Root read span | 233.3348 | 5/7SWAP vượt admission100ms |
| Controller tail H | 405.3797 | 6/7vượt P11 samplemax164.429ms |
| Executor upper bound I | 2653.0962 | Dưới P11 samplemax2972.325ms |
| Full decision-exit→executor-return tail | 3001.1040 | Dưới R_op6455.8326ms |

0observed full-tail reserve overruns/operational_fault trong7SWAP records;
không có timing để kết luận điều này cho16SWAP còn lại. H component đã vượt
sample calibration nên cần review; không coi tổng reserve còn dư là proof từng
component đủ, không cập nhật allowance/calibration hậu nghiệm để làm P15 PASS.
Native U/transport/alignment vẫn **null UNKNOWN**; reserve descriptive, không
hard deadline guarantee. Accepted-override branch latency chưa có native sample.
3WIN không là efficacy, reasoning win-rate hay toàn scope SIMPLE acceptance.

## Provenance và preservation

- Version **1.2.5**, HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`.
- Frozen290sources `10cc39c2e323cb697c0dea4c04b5c541ce4eee0b22342283996c54700126c62a`;
  host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
- Request run `5da54123e7cd4faaaf32df5442b36fb5`; FarmRun
  `8ecbe119161845338a9338cf1a3462a4`.
- Request SHA `9b31e446fc209e237eef25466f6186fe68af0c3b325b904769967fe83475b7d5`;
  independent activation SHA `be136bbac3a04d9f35f8f96f0f4000655583bb707f81208f6b27613b92672157`.
  Fresh1h expiry, exclusive consumed claim giữ nguyên; original P14 draft còn
  accepted=false/run+expiry null. Không tái sử dụng request.
- [Raw archive manifest](../artifacts/5d1_operational_p15_20261015_v1/closure/raw_archive_manifest.json)
  pin93byte-exact files: full FarmRun/entries/combat/errors, request package,
  session/reasoning/watermarks/claim và UI closure prefix. UI còn mở ở trạng thái
  idle, original UI log có thể append; archived prefix không đổi.
- [Verification](../artifacts/5d1_operational_p15_20261015_v1/closure/verification.json):
  290sources,3,497parent artifact files,4game files,host,HEAD và ordinary preferences
  đều giữ. P15 before preferences SHA e1fd28a0… là baseline đúng, không restore
  P14 preferences cũ. Private preferences riêng, không ghi prefs thường.

Không sửa src/tools/tests/runtime, build/version/Git, game files hoặc policy.
Không regression rerun cho docs/file-only audit; giữ P14 frozen2,226tests/
23qualification gates. Các kiểm tra P15 là log joins/hash preservation và một
inert reproduction của code hiện tại; không gọi đó là full regression mới.

Next duy nhất **[P16 targeted offline remediation](../prompts/5D1_P16_OPERATIONAL_LIFECYCLE_ADMISSION_REMEDIATION_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**: sửa healthy retirement/successor và durable
reasoning status, kiểm chứng read-span rejection và timing H. Chưa cần game
hoặc batch mới; chưa mở D1cap12/CAREFUL/Demon/Mega/D2. **STOP P15.**
