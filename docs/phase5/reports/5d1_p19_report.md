# 5D.1-P19 — Bounded SIMPLE successor pilot

2026-10-15 (Asia/Saigon). **CLOSED / PARTIAL — ADMISSION COVERAGE REVIEW REQUIRED.**
Luồng farm, successor lifecycle và diagnostics **PASS SCOPED** trên batch này.
Chưa đóng SIMPLE general acceptance hoặc toàn bộ D1.
[Prompt](../prompts/5D1_P19_BOUNDED_SIMPLE_SUCCESSOR_PILOT.md),
[parent P18](5d1_p18_report.md),
[audit](../artifacts/5d1_successor_p19_20261015_v1/closure/audit.json),
[preservation](../artifacts/5d1_successor_p19_20261015_v1/closure/preservation.json).

## Kết quả và giới hạn phiên

Phiên thực hiện đủ **3 TOTAL game attempts / 3 WIN**, 0 LOSS/UNKNOWN, không
technical recovery. Run 19:54:57.420–20:02:19.523+07, **442.103 giây**.
Tool xác nhận kết quả 3 lần, trở lại phòng boss 3 lần và dừng với
`FARM_TARGET_COMPLETED`, inactive, exit0, `BOSS_LOBBY`.

| Attempt / match | Result | Local / boss turns | SWAP / ACK | EVOLVE | Combat time |
|---|---|---:|---:|---|---:|
| 1 / M_6425991a | WIN | 9 / 8 | 9 / 8 | 0 | 123.339s |
| 2 / M_367cbe72 | WIN | 11 / 10 | 11 / 10 | 1 success | 150.331s |
| 3 / M_99c09bf2 | WIN | 10 / 9 | 10 / 9 | 0 | 129.495s |

Tổng **30 local turns**, 30 SWAP + 1 EVOLVE = 31 gameplay commands;
3 entry, 3 result confirms, 0 recovery inputs. 27 SWAP có ACK sequence evidence;
3 SWAP cuối trận chuyển sang `COMBAT_LIFECYCLE_ENDED` cùng terminal HP/UI WIN.
Không biến 3 terminal-no-ACK thành ACK hoặc replay input.

Trận 2 có thêm 2 proposal bị existing preflight hủy trước input ở turn9/15;
`expired_actions=2`, `user_state_changes=2` được giữ trong raw counters. Tên
counter không chứng minh người dùng thao tác. Sau đó controller chọn lại và
tiếp tục bình thường. Ba `SUPERSEDED_BEFORE_PREFLIGHT` timing records được giữ
riêng với 30 SWAP returns; không phải ba input mất log. Mỗi combat controller
ghi postmatch handoff timeout1s, rồi FarmRunner vẫn xác nhận kết quả và về room;
đây không phải stop reason cuối của batch.

## Phiên bị mất focus trước đó và retry được yêu cầu

Request đầu `1f4f9d6c01db4524b524ee02440479c0`, FarmRun
`70cde3b0df4c498a8b4850a08e6a97c4` dừng vì
`FOREGROUND_LOST / ATTACK_CARD_FOREGROUND_LOST` ở kiểm tra thẻ trước entry:
**0 game attempts, 0 gameplay/lobby inputs**. Claim đã consumed và giữ nguyên.
User xác nhận lỗi focus của mình và yêu cầu mở phiên mới. Tool cũ đã đóng.

Retry tạo request độc lập `11dfa9092c9d44a58f833e930826f688`, pin hash claim cũ,
giữ nguyên cấu hình và **3 TOTAL game attempts còn lại**. User bấm Start một lần
trong mỗi phiên; không reset/resume claim cũ, không thêm attempt sau khi đạt3.
Retry FarmRun `454ffc5e816d4c23937fc0c6fec5fe87`. Cả phiên pre-entry và retry,
hai request/activation/claims cùng logs được giữ trong archive.

## Cấu hình và cohort

SIMPLE/SOLO, Starburst1289/lv73, Phoenix do user khai báo,
normal→normal/default_attack, foreground/two_click, original1280×640,
BASIC incumbent/shadowOFF, budget4000ms, target3/max3, max technical recoveries1.
Request SHA `16132f99e4bb581587fc1f9d95e2bc5dd3c79d807b024545ac4c94956e32c49c`.

Account, boss stats `[99,84180,445,250,325]`, structural fusion `[254767,2102]`
và selected Attack `[64647,4,ATTACK,0,0,0]` khớp runtime witness khi đủ cards.
Opening của cả3 trận có cards[] nên giữ BASIC theo contract. RoomDTO pet ID2524
khác parent560 vẫn được giữ rõ trong preflight comparison; nguyên nhân UNKNOWN,
field đó không thuộc accepted structural witness. Không dùng nó để chứng minh
tên/effect pet hoặc relabel calibration. Không có full damage/survival model.

## Suy luận và admission coverage

| Combat | SWAP timing / sent | Worker submit / complete | Opening fallback | Read-span veto | Completed retention |
|---|---:|---:|---:|---:|---:|
| 0 | 9 / 9 | 7 / 7 | 1 | 1 | 7 |
| 1 | 11 / 11 | 1 / 1 | 1 | 9 | 1 |
| 2 | 10 / 10 | 0 / 0 | 1 | 9 | 0 |

**30/30 SWAP timing records** đối chiếu đúng full action source của input đã gửi.
Collector sequence1–33 đầy đủ:30 SWAP +3 superseded decision timings. Có64
selection checkpoints,8 decisions,3 worker summaries; tổng108 durable events.
Checkpoint/poll counters không phải số lượt hoặc số worker jobs.

8 worker decisions đều **RETAIN_BASELINE** hợp lệ:5
`NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE`,3 `BASELINE_TOP_IN_TOTAL_ORDER`.
Baseline move của cả8 decisions khớp SWAP thực tế. Compute22.2207–43.6303ms;
decision wait48.3091–84.3394ms. Không timeout/fault/late/rejected/stale-discarded.
Accepted overrides0 là bình thường; không quota đổi nước, không chứng minh nước
BASIC là global optimum hoặc suy luận làm tăng win rate. Worker payload có
label lịch sử `OFFLINE_ONLY` vì không có input authority; session/request và
normal controller action lineage xác nhận đây là operational pilot.

**19/30 SWAP** bị veto bởi `OBSERVATION_READ_SPAN_EXCEEDED`: root admission spans
120.2439–157.6481ms vượt policy100ms. Cả9 lượt sau opening của combat2 đều thuộc
nhóm này, nên trận3 không submit worker job. Opening cards[] giải thích fallback
còn lại. Đây là admission veto có log đầy đủ, không phải worker chết hoặc mất
log như P15. BASIC vẫn được phát qua existing preflight.

Chưa xác định nguyên nhân sâu khiến root poll vượt100ms từ những timestamps
tổng hiện có. Native board sub-read metric không bao phủ toàn root poll;
không lấy nó làm thời gian đọc toàn snapshot. Không kết luận là reader hỏng,
không tự nới100ms, không chạy thêm để tìm một lượt override. Zero jobs ở combat2
là lý do giữ **PARTIAL admission coverage** và chọn review offline tiếp theo.

## Timing, cleanup và an toàn

Monitor `POST_RETURN_COMPONENTS_V1` hoạt động đủ3 combats;
`H_max=253.036ms < H_budget425.1279ms`,
`I_max=2845.9532ms < I_budget6092.325ms`,
`full_tail_max=3054.4469ms < R6767.4529ms` trên30 SWAP returns.
0 component/aggregate/invalid-interval faults; session `first_fault=null`,
`faulted=false`, `COMBAT_OPTIONS_READY=3`. Các sample maxima này không bảo đảm
deadline phía server. Native U/transport/alignment vẫn null;
first exact click và accepted-override native latency **NOT_MEASURED**.
Retention dùng pacing BASIC hiện có; không coi đó là đo latency của override.

Cả3 successor bridges đều healthy retired, workers process/reap1/1 mỗi combat,
writer flush/close đầy đủ. Watermarks35/42/31 events, tổng108 eligible=enqueued=
written;0 drop/fail/queued/in-writer. `CLOSED` sau cleanup bình thường không còn
bị coi là diagnostics fault. Phiên pre-entry cũng cleanup sạch với1 event.

Farm safety và mỗi combat safety telemetry đều0 về duplicate, wrong-turn,
stale, partial input, postmatch gameplay input và input-after-stop. Provider
read errors/DTO rejections0. Provider metrics có bộ đếm tích lũy qua các combat;
giữ raw counters, không cộng nhầm chúng thành số đo độc lập từng trận.
Không inject fault live, memory write, direct game calls hoặc network changes.

## Bảo toàn và bước tiếp theo

[Raw archive manifest](../artifacts/5d1_successor_p19_20261015_v1/closure/raw_archive_manifest.json)
đóng băng458 files,48,205,399 bytes, gồm tất cả attempts, request/claims, timings,
worker/source/config/admission evidence và final watermarks. UI idle event log
là byte-exact prefix đã archive; phần append sau đó được ghi riêng, không dùng
làm combat evidence mới. Không tự đóng UI hoặc thao tác game sau batch.

Preservation kiểm **294 Python source files**,4,342 parent artifact files,
4 static game files, ordinary preferences,4 parent claims,2 P19 claims,
host và HEAD. Source giữ
`b673eab28dfcb1c5d32116d264789b7e5d8b2d9bdc7a2df7dfc469012e2740a9`,
host giữ `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Không source/tests/build/version/Git hoặc ordinary preference changes;
version1.2.5/package giữ nguyên. Không chạy thêm tests/benchmark ở bước live này.

Next duy nhất **[P20 admission coverage review OFFLINE](../prompts/5D1_P20_ADMISSION_COVERAGE_REVIEW_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Rà19 root-span vetoes và combat2 zero jobs
từ raw/native evidence cùng frozen source, trước khi quyết định scope tiếp.
Chưa cần mở game hoặc live test thêm. Chưa SIMPLE general acceptance,
CAREFUL/Demon/Mega/D1cap12/D2 hoặc Phase5 completion. **STOP P19.**
