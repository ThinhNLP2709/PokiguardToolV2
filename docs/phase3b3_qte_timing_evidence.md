# Phase 3B.3 — QTE deadline và sửa nhịp đọc (2026-09-04)

## Final timing acceptance — 2026-09-10

Phase 3B.3 is closed PASS STRONG on v1.0.43 under the final user completion
contract. See [phase3b3_closeout.md](phase3b3_closeout.md) for the accepted
17-action sample and the distinct B3 ten-scored-action streak. The sample has
119/119 ACKs; direction completion 1.050251..1.284190 s; Space estimates
3.151786..3.201961 s in current [3.0, 3.299999952] windows; minimum start/end
margins 151.786/98.039 ms. No out-of-window or duplicate Space is present.
These observed values are not constants in the scheduler. Runtime PERFECT,
not mandatory external callback capture/post-state, completes the action.
The implementation/retry entries below are historical evidence.

## Accepted B1 timing — 2026-09-07

`phase3b3_pet_skill_action_20260907_232352.jsonl` bound a fresh seven-key
generation and authoritatively confirmed 7/7 directions in 1.034103 s. The
runtime Perfect interval was `[3.0, 3.299999952]`; the one Space was sent at
3.151958 s, 0.151958 s after its start and 0.148042 s before its end. Target
error was 0.001958 s. Runtime/RAM resolved `PERFECT!`; the current server
response correlated, its 64-cell board was accepted, and fresh post-state was
published. This is the accepted Phase 3B.3 B1 timing fixture.

## B1 retry 21 — torn challenge read tại progress 5/7 (2026-09-07)

`logs/phase3b3_pet_skill_action_20260907_212858.jsonl` chứng minh card click
đúng một lần và server generation hiện hành có sequence
`UP DOWN DOWN UP RIGHT LEFT LEFT`. Game/RAM xác nhận bốn hướng đầu. Sau lần gửi
`RIGHT`, mẫu CardUI kế tiếp là index/correct `5/5` với exact năm presses, nên
hướng thứ năm cũng đã được game nhận.

Stable read của MatchService challenge ở chính cycle đó bị exception. Bản cũ
nuốt exception thành `None`, tracker phát `WRONG_SESSION` và action dừng ở 5/7.
Log không chứng minh challenge ID trong game đã bị clear; kết luận duy nhất là
server-challenge snapshot không đọc ổn định được trong một cycle.

v1.0.26 cho phép bridge đúng **một** failed read từ server generation đã bind.
CardUI vẫn phải khớp toàn bộ identity hiện hành, timing window và exact
all-correct press prefix; không dữ liệu nào được suy đoán và mỗi phím tiếp tục
cần RAM-ACK. Hai lỗi liên tiếp hoặc bất kỳ mismatch nào vẫn revoke input.
Exception được giữ lại trong telemetry thay vì biến thành một server absence
giả. Final card preflight race zero-input cũng được re-arm để chờ lượt mới.
Validation: 73 focused và 1042 full tests PASS; the later live B1 is accepted.

## Current 1.7.4-b2 layout addendum — 2026-09-07

The fresh exact dump under `reverse/reverse_1.7.4-b2` shifts the fields used by
the QTE controller. Current values are:

- MatchService server arrows/duration/window/challenge ID: `+0x220`, `+0x228`,
  `+0x22C`, `+0x250`;
- CardUI actor/duration/timing text: `+0x58`, `+0xC0`, `+0xF8`;
- CardUI directions/index/correct/active/current time/multiplier:
  `+0x148`, `+0x150`, `+0x154`, `+0x158`, `+0x15C`, `+0x160`;
- CardUI finished: `+0x178`;
- Perfect/Good windows and timing bonus: `+0x310..+0x328`;
- current arrow seed / QTE presses / server-arrow flag: `+0x488` / `+0x490` /
  `+0x498`.

The reader's timing policy is unchanged: every value comes from the current
runtime challenge and each direction still requires RAM acknowledgement before
the next key. Declarations are CONFIRMED; a corrected live B1 on b2 remains
pending.

## QTE UI V2 và challenge identity — 2026-09-07

Đối chiếu `reverse/reverse_1.7.4-b2` với `reverse/redux_compat` xác nhận UI QTE
đã thay đổi đáng kể nhưng input và luật chấm điểm cốt lõi không đổi:

- `CardUI` mới có timeline/needle, vùng Good/Perfect, D-pad layout, modal/scrim,
  arrow cue và hiệu ứng đúng/sai. Coroutine mới thêm `_wasInPerfectZone` và
  `_wasInGoodZone`; đây là state hiển thị, không thay predicate kết quả.
- Native `CardUI.Update` RVA `0x6D3760` vẫn nhận `Up/Down/Left/Right`
  (`273..276`) hoặc `W/S/A/D` (`119/115/97/100`), và vẫn xác nhận bằng
  `Return` (`13`) hoặc `Space` (`32`). Tool tiếp tục dùng arrow keys + Space.
- `ApplyServerQteWindow` RVA `0x6BDEE0` vẫn copy bảy số nguyên từ
  `MatchService.ServerQteWindow +0x22C`, đổi ms sang giây và ghi vào các field
  runtime. Default declaration vẫn là Perfect `3.0–3.3 s`, Good
  `2.5–3.0 s` và `3.3–4.2 s`; tool không hard-code các default này mà đọc
  current server window.
- `GetLastTimingResult` RVA `0x6C86F0` vẫn tính
  `elapsed = duration - duration * currentTimeValue`. Với
  `ATTACK_LEGEND_`, dưới 7 nút đúng là `BAD`; đủ 7 thì trong inclusive Perfect
  interval là `PERFECT!`, ngoài interval là `GOOD!`.

Thay đổi cơ chế thật sự là identity của challenge:

- `MatchService._ServerQteChallengeId_k__BackingField` là `long` tại `+0x250`;
  `_qteRequestedCardId +0x258`, `_qteRequestedAt +0x25C`, stale timeout 6 s.
- `RequestQteChallenge` RVA `0x398F20` clear ID rồi ghi card/time;
  `HandleQteChallenge` RVA `0x3966E0` nhận và ghi ID; `EnsureQteChallenge`
  RVA `0x394BB0` xử lý request stale.
- `CardUI._qteArrowsFromServer +0x498` chỉ được bật khi
  `GenerateDotArrows` RVA `0x6C7660` lấy chuỗi server. Method
  `CurrentQteChallengeId` RVA `0x6C5950` chỉ trả ID khi cờ này bật và ID khác
  zero.
- `SendSkillUse` RVA `0x399810` nay nhận `long? qteChallengeId`; `CardUI`
  truyền ID hiện tại cùng presses/elapsed/result rồi MatchService clear ID.
  `ChatMessageDTO.qteChallengeId` là `long?` tại `+0x148`.

Tool v1.0.25 đọc cả server-arrow flag và challenge ID. Một QTE mới chỉ được
bind khi hai bằng chứng này hiện hành; đổi ID giữa chừng bị fail closed. Sau
Space, native game có thể clear ID trước lần đọc kế tiếp, nên completion chỉ
được giữ nếu tracker đã bind chính ID trước đó. Response có ID được correlate
trực tiếp bằng ID; không gửi network hay gọi method game. Validation offline:
**1033/1033 full regression PASS**, compileall và `git diff --check` PASS.

## Live bổ sung — B1 retry 19

`phase3b3_pet_skill_action_20260906_213144.jsonl`: HT7 được discover sau
Fusion, nhưng log dừng ở mẫu 260 Mana/0 Rage lúc 21:33:41 và controller còn
sống gần ba phút. Operator đủ resource và dùng skill sau đó bằng tay; worker
không hề lấy mẫu mới, automatic input bằng 0. Exact blocking call của build cũ
UNKNOWN vì chưa có stage marker.

Build mới đặt begin/end quanh từng read/capture và watchdog 2 giây chỉ trong
input-capable phase. Stall thu hồi authority trước delayed input và ghi exact
stage; không thay QTE deadlines, per-key RAM ACK hay Perfect scheduler.

## Live bổ sung — B1 retry 18

`phase3b3_pet_skill_action_20260906_212126.jsonl`, match `M_8c2f4e06`,
turn 21: HT7 slot 4/Button/actionability/resources và geometry 156 ms đều được
chứng minh current. Action vào `PREFLIGHT`, nhưng vòng thứ hai dùng full board
provider và bị aggregate ownership guard loại sau khoảng 0,46 s. Nhánh cũ
không log operand cụ thể nên nó vẫn UNKNOWN. Không có card click, hướng hay
Space.

Sửa scheduling giữ input-free `PREFLIGHT` trên native-hand refresh + exact
control-only ownership, đồng thời vẫn đọc lại geometry/identity trước click.
Fast per-key RAM ACK và Perfect scheduler sau click không thay đổi.

## Live bổ sung — B1 retry 15

`phase3b3_pet_skill_action_20260905_160701.jsonl`, action
`8f2e5d29a25142949728a0bcbce76f55`: 7/7 directions RAM-ACK trong
1.117173 s; Space một lần tại 3.168743 s; runtime 3169 ms / `PERFECT!`.
Không có input vi phạm hay retry.

Audit bị dừng `GAME_NOT_FOREGROUND` khoảng 7.8 s sau Space, dù lúc đó chỉ còn
bounded read-only response wait. Trước khi dừng, seven result scans cho thấy
vùng scan bị pha lẫn batch-only allocations: 76 learned regions, 703–797 ms
mỗi learned pass và 2.563 s cho first learned+full pass. Sửa mới bỏ foreground
requirement chỉ sau khi Space đã gửi, đồng thời tách ChatMessageDTO regions khỏi
WsCombatBatch-only regions. Perfect timing path không đổi.

## Kết luận từ retry 6

`logs/phase3b3_pet_skill_action_20260904_220109.jsonl`, match `M_de6ac78f`,
turn 17: thẻ HT7 được bấm tự động đúng một lần. QTE có sequence
LEFT, RIGHT, UP, RIGHT, RIGHT, UP, LEFT. First-observation latency sau click
1.421 s; số này gồm cả thời gian game phản hồi và observer, không đủ evidence
để quy toàn bộ cho network hoặc Python.

RAM xác nhận index 1/2/3/4 tại 15:04:12.853 / 13.916 / 15.053 / 15.989 UTC.
Ở elapsed 3.6365 s chỉ có 3/7; elapsed 4.5378 s có 4/7. Cuối cùng game tự hết
thời gian, index/correctCount 5/5 và timing text BAD. Action dừng
`QTE_GENERATION_CHANGED_OR_STALE`, một card click, zero Space. Đây là B1 FAIL,
không phải server-correlated full-action success. Log cũ làm mất direction
summary khi invalidate; không suy ra các phím còn lại đã được xác nhận.

Regression scheduling: harness gọi toàn bộ `MemoryBoardStateProvider.poll()`
trước MỖI lần đọc QTE. Chu kỳ quan sát khoảng nửa giây; primitive 3B.2 cần
một snapshot để gửi, snapshot sau để ACK, rồi snapshot tiếp để gửi hướng mới.
Các ACK cách nhau khoảng một giây, thay vì 72–78 ms trong live 3B.2 đã PASS.
Full provider gồm DTO/card/native geometry work không cần cho direction ACK.
Log cũ không có profiler từng nhánh nên phần đóng góp chính xác của mỗi reader
là UNKNOWN. Không sửa primitive thành gửi cả chuỗi hoặc giảm key hold để che
độ trễ của vòng quan sát.

## Reverse đối chiếu đúng build 1.7.4

GameAssembly SHA256 (đọc lại file, không sửa):
`c67ff9cc3bb280cc63b3b9be24d45ed038937f70a95e13075d361c8ddde95a78`.
Các địa chỉ dưới đây là RVA, KHÔNG phải địa chỉ runtime cố định.

| Assembly / namespace / type | Member | Kind / scope | Declared type | Offset / RVA | Evidence |
|---|---|---|---|---|---|
| Assembly-CSharp / global / CardUI | dotSkillDuration | instance field | float | +0xB8 | redux CardUI.cs:54 |
| Assembly-CSharp / global / CardUI | correctDotCount | instance field | int | +0x14C | CardUI.cs:89 |
| Assembly-CSharp / global / CardUI | currentTimeValue | instance field | float | +0x154 | CardUI.cs:91 |
| Assembly-CSharp / global / CardUI | perfectStartTime / perfectEndTime | instance fields | float / float | +0x1A0 / +0x1A4 | CardUI.cs:109,111 |
| Assembly-CSharp / global / MatchService | _ServerQteWindow_k__BackingField | instance field | QteWindow | +0x20C | MatchService.cs:178; struct :362 |
| Assembly-CSharp / global / MatchService | _ServerQteArrows_k__BackingField | instance field | List<string> | +0x200 | MatchService.cs:174; getter :256 + native |
| Assembly-CSharp / global / CardUI._HandleDotSkillSequence_d__159 | _qteWait_5__6 | instance field | float | +0x44 | CardUI.cs:449 + native |
| Assembly-CSharp / global / CardUI | ApplyServerQteWindow() | instance method | void | 0x5B0100 | CardUI.cs:883 + native |
| Assembly-CSharp / global / CardUI | GetLastTimingResult() | instance method | string | 0x5B5FF0 | CardUI.cs:887 + native |
| Assembly-CSharp / global / CardUI._HandleDotSkillSequence_d__159 | MoveNext() | instance method | bool | 0x5CF430 | CardUI.cs:438–463 + native |
| UnityEngine.CoreModule / UnityEngine / Time | deltaTime getter | static property getter | float | 0x221E640 | UnityEngine/Time.cs:28 |

Sources above are under `reverse/redux_compat/cs/Assembly-CSharp/` and
`reverse/redux_compat/cs/UnityEngine.CoreModule/`. Confidence: HIGH for the
listed declarations and native control flow; not claims about unknown builds.

Native disassembly was inspected read-only with pefile/capstone:

- `ApplyServerQteWindow` at 0x5B0223 reads MatchService +0x20C. The valid struct
  supplies durationMs/perfectStartMs/perfectEndMs; 0x5B028F / 0x5B02B1 /
  0x5B02A5 store converted seconds to CardUI +B8/+1A0/+1A4. Therefore windows
  must be read from the current challenge, not global constants.
- `MoveNext` 0x5CF991–0x5CF9A0 initializes timeLeft/totalTime from duration.
  0x5CF9AC–0x5CF9CD exits when timeLeft <= 0 or hasFinishedDotSkill != 0.
  0x5CF9D8 calls `Time.deltaTime`; 0x5CF9DD subtracts it and 0x5CF9ED–0x5CF9F2
  writes remaining/total into currentTimeValue. This is Unity elapsed time,
  not the match's 14-second turn timer and not necessarily wall time when frozen.
- 0x5CFC07–0x5CFC15 invokes the normal finish handler internally when the
  coroutine ends without a prior confirmation. The external tool never calls
  this handler. It explains the observed BAD without an automated Space.
- `GetLastTimingResult` 0x5B6047–0x5B6060 computes
  `elapsed = duration - duration * currentTimeValue`. The special-family
  branch at 0x5B6094–0x5B6097 rejects correctDotCount < 7; 0x5B609D–0x5B60AD
  checks the inclusive Perfect bounds. The other timing branch also checks
  the runtime bounds.

Retry 6 runtime: duration 5.0 s; Perfect [3.0, 3.299999952] s; target midpoint
3.149999976 s. These are fixture values only. Finishing 7 directions at 4 s
is already too late for Perfect even though the total timer has not expired.

## Remediation

- After the one owned card click, `poll_qte_control(expected_session)` reads
  only fresh lifecycle/ownership/actor/connection/turn/membership. It fences
  owner and turn before/after, never scans DTOs/cards/geometry, never publishes
  a fake board or a combat GameState without a board. Failure cannot reuse an
  older playable state to authorize a key.
- Current ActiveDotSkillCard, challenge identity, sequence, progress, timing
  and resources are still read from RAM. Before click, ordinary discovery and
  final native geometry remain mandatory. The fast path remains until the
  runtime completion is captured; normal full polling then resumes for the
  correlated result and post-skill GameState.
- Accepted 3B.2 direction/key backend is unchanged: 40 ms hold, one expected
  key, fresh authoritative ACK, next key. No blind retry/open-loop sequence.
- Adaptive short poll delay near CURRENT Perfect midpoint is now wired into
  the harness. QTE and control samples keep their original separate timestamps;
  the 0.35 s freshness limit is not relaxed. RAM elapsed itself must enter
  Perfect before Space, even if wall-time projection would enter earlier.
- If directions are still incomplete after the current Perfect end, stop
  further keys with `PERFECT_WINDOW_MISSED_DURING_DIRECTIONS`; never send a
  desperate Space. One Space maximum and server/runtime verification remain.
- Log `pet_skill_direction_event` preserves sent/ACK records and the summary
  on invalidation. `qte_critical_poll` records provider/cycle/sample-age ms.

## Verification / remaining acceptance

Full regression after remediation: **990/990 PASS**. Focused action/control
tests: **50/50 PASS**, including 14 new control/timing tests. `git diff --check`
is clean. Existing working-tree changes from earlier Phase 3B.3 are preserved.

Offline regression covers seven directions with 40 ms simulated physical holds,
individual fresh ACKs, no full scan during the QTE, two different runtime
Perfect windows and exactly one Space. It also covers stale control samples,
frozen Unity clock, late incomplete directions, wrong session, changed owner/
turn, unreadable lifecycle/actor/membership, disconnect and recovery. Offline
timing is NOT a live latency guarantee.

Read-only check of PID 26436 found LOBBY, so live active-control timing could
not be measured. Smoke log `logs/phase3b3_qte_fast_poll_readonly_20260904.jsonl`
ran 3 seconds with no runtime hook/input and stopped normally. Full-action B1
retry is still required. No harness was auto-started after this fix; BASIC,
gameplay policy, packaging and accepted 3B.2 directional primitive are unchanged.

## Live bổ sung — B1 retry 12

`logs/phase3b3_pet_skill_action_20260905_144152.jsonl`, action
`9679da7994714a67a0f46c1316d9de09`: one card click; sequence DOWN DOWN DOWN
DOWN UP RIGHT RIGHT đạt 7/7 ACK trong 1.204005 s; Space một lần tại projected
3.157258 s trong current `[3.000000,3.299999952]`; runtime 3174 ms và RAM
`PERFECT!`. Không có critical input violation.

Current response không được tìm thấy trước old result deadline 5 s, nên action
dừng unconfirmed mà không retry. Retry 11 đã quan sát response tương đương tới
sau khoảng 6.025 s. Result deadline nay tăng bounded 15 s; đây là read-only
latency tolerance, không thay đổi hướng/Space timing hay tiêu chuẩn correlation.

## Live bổ sung — B1 retry 13

`phase3b3_pet_skill_action_20260905_144943.jsonl`, action
`ceb63ff8b7534390a70fed3a4e7e60f5`: 7/7 RAM-ACK trong 1.159891 s, one Space
tại projected 3.163413 s trong `[3.000000,3.299999952]`, runtime 3163 ms và
`PERFECT!`. Exact current server response đã correlate; không có duplicate/
retry input.

Post-state timeout 15 giây vẫn hết với 37 poll ở ACK gap dù session còn current
và turn tiến tới 22. Native `HandleMatchSkillUseRes -> HandleResEnvelope ->
ParseCombatBatch` chứng minh response skill dùng cùng board-bearing combat
envelope, nhưng transport decoder cũ không nhận event này. Fix mới offer strict
64-cell `MATCH_SKILL_USE_RES.matchPayload.board` vào exact ACK gate sau
correlation. Timing/direction/Space path không đổi; live retry còn cần để xác
nhận board payload thực tế và hoàn tất full action.

## Live bổ sung — B1 retry 14

`phase3b3_pet_skill_action_20260905_152539.jsonl`, action
`ac2184fbaff74668bc8863937f37978c`: 7/7 RAM-ACK trong 1.185443 s, one Space
tại 3.166887 s, runtime 3167 ms/PERFECT. User thấy automatic board destruction,
cascade và next turn bình thường.

Response scanner không giữ được DTO trong 15 s. Trước mỗi lần tìm response,
observer cũ chạy một full provider poll; 23 lần tốn tổng 8.326 s, median
359 ms, max 703 ms. Sửa mới giữ fast control-only polling đến correlation,
chụp direct transient owner batch và chạy first result scan với bounded full
fallback. Sau correlation mới chạy full post-state poll. QTE direction/Space
timing không đổi; response và fresh state vẫn bắt buộc để full B1 PASS.

## Live bổ sung — B1 retry 11

`logs/phase3b3_pet_skill_action_20260905_005856.jsonl`, action
`596321bcb0454a5ab2bf03ff1fcd77ac`: 7/7 directions được xác nhận trong
1.148706 s, còn 1.851294 s tới Perfect start. Current window là
`[3.000000, 3.299999952]`; projected Space elapsed 3.181947 s, runtime
`qteElapsedMs=3166`, result RAM `PERFECT!`, user-visible Perfect. Một card click,
một Space, không wrong/missing/duplicate/stale/blind retry. 55 critical polls:
provider min/median/max 0/15/16 ms, cycle 15/31/79 ms.

Kết quả server được correlate đúng current Match/QTE nhưng full board còn bị
`presentation_busy_or_batch_pending` suốt 4.157 s sau correlation. Việc fail
lần này là timeout post-state, không phải QTE timing. Default post-state wait
được tăng bounded 4 -> 15 s; QTE poll/key/Space timing không đổi.

## Live bổ sung — B1 retry 7

`phase3b3_pet_skill_action_20260904_223027.jsonl`: one card click, 7/7 ACK,
zero direction errors/retries, completion elapsed 1.378084 s, headroom 1.621916 s.
One automatic Space (projected elapsed 3.171087 s); game recorded 3156 ms and
PERFECT. User confirmed Perfect. 51 critical samples: provider median 15 ms,
cycle median 31 ms, maximum cycle 79 ms. Direction/timing remediation is now
live-confirmed for this invocation, not a universal performance guarantee.

Full action still failed after runtime Perfect with
`ACTIVE_COMBAT_OWNERSHIP_INVALID`, before server correlation/post-state.
No further input/controller remains. See latest `phase3b3_report.md`; do not
count this as full B1 PASS or silently promote it to B2.

## Retry 8 — active CardUI chưa đủ để gửi hướng (2026-09-04)

Log `phase3b3_pet_skill_action_20260904_231540.jsonl`, lines 190–200:
card click 1, direction/Space 0; `M_04c99254`, local turn 41. At first active
read (about 1.54 s after click), current challenge MatchId was correct but
ServerQteArrows was null. CardUI was active/unfinished, index/correctCount 0/0,
presses empty, currentTimeValue 1.0, currentArrowCount 7, local seed -959.
Tracker correctly withheld generation authority (`SEQUENCE_UNAVAILABLE`),
but action incorrectly ended its wait immediately. No lost automated key is
evidenced. User-reported BAD occurred after observer stopped; runtime result,
later server sequence, FPS/ping cause and exact initialization delay are UNKNOWN.

Additional native inspection of the same hashed 1.7.4 GameAssembly, read-only:

- `MoveNext` RVA 0x5CF7F6 checks MatchService +0x200 against zero. At
  0x5CF7FF–0x5CF80B it compares coroutine qteWait +0x44 with the float at
  RVA 0x266C030 (`0.6000000238418579`). If the sequence is absent and the
  wait is below that bound, 0x5CF814 calls Time.deltaTime, adds it at
  0x5CF819, stores qteWait at 0x5CF827 and yields the coroutine at
  0x5CF831–0x5CF83A.
- This proves the game itself has an asynchronous server-sequence wait before
  proceeding. It does NOT prove when retry 8's server sequence later arrived,
  or that 0.6 Unity seconds equals a wall-time/FPS readiness guarantee.
  The external tool does not read/write coroutine internals or copy this
  constant into a sleep/timeout; local arrows alone never authorize input.
- Confidence HIGH for declared fields/native wait control flow; later runtime
  behavior of retry 8 remains UNKNOWN. Addresses are RVAs, not ASLR pointers.

Fix: preserve the existing default 3 s generation deadline, but poll read-only
through pre-bind SEQUENCE_UNAVAILABLE only with the exact clicked current
capability and same session/actor/turn. Wrong/stale/ambiguous evidence remains
rejected, as does any sequence loss after binding. No early directions, extra
click or Space, no reset of the deadline, no weakening of 0.35 s sample age.
Fast 3B.2 direction ACK and runtime Perfect scheduling are unchanged.

Offline: **1002/1002 regression, 62/62 focused action/control PASS**, including
5 new delayed-initialization/identity/timeout tests. Live B1 still pending;
this retry did not reach the post-QTE handoff remediation.

## Retry 9 — xác nhận nhanh + PERFECT, lỗi ở terminal cleanup (2026-09-05)

`phase3b3_pet_skill_action_20260905_001953.jsonl`, M_2bee7569 / local turn 49:
one card, 7/7 sent/ACK, zero direction error/retry, one Space. Sequence
DOWN DOWN RIGHT UP RIGHT RIGHT UP. Directions finished at elapsed 1.244157 s,
headroom 1.755843 s. Projected Space 3.163942 s vs midpoint 3.15 s; actual RAM
rounded elapsed 3181 ms, PERFECT. User confirmed Perfect. 54 critical polls:
provider median 15.5 ms, cycle median 31 ms, max cycle 78 ms. No startup
SEQUENCE_UNAVAILABLE was observed in this sample.

Completion was first read with active=true/finished=true; the next raw read
had active=false but the same CardUI/owner/sequence/progress/time/result.
Projection deliberately dropped its current-generation authority (INACTIVE),
which was incorrectly treated as a changed QTE by result waiting. No further
input occurred, but server correlation/post-state never completed. This is not
a failed Space or evidence of lost arrow input; full B1 remains incomplete.

Offline terminal-cleanup remediation retains only a bound-completion fact for
the existing result deadline and full+control polling. It cannot authorize any
new input or replace server correlation. **1008/1008 tests PASS, 68/68 focused**;
direction/Perfect scheduling is unchanged. Details in `phase3b3_report.md`.
