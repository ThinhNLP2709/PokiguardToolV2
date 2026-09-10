# Phase 3B.3 — Runbook full Pet Skill action + PERFECT QTE

**CLOSED — PASS STRONG, v1.0.43.** Xem
[báo cáo chốt](phase3b3_closeout.md). Không cần chạy thêm test live bắt buộc.
Các lệnh dưới đây chỉ để tái hiện khi được user yêu cầu; không tự khởi động.

## B4 v1.0.43 — two current PERFECT QTEs in one retained match

**B4 PASS; no further B4 live retry is required for this milestone.** Retry 1
log `logs/phase3b3_pet_skill_action_20260910_124435_b4_retry1_two_same_match_v1043.jsonl`
proves two current Perfects in MatchId `M_60410580`, turns 13/21, generations
1/2 with distinct challenges, 14/14 RAM ACKs, exactly two card clicks/two
Spaces and exit 0. User confirmed both. Stopped 2026-09-10 13:14:33.727 ICT.
B3 10/10 remains PASS STRONG. Final phase audit/handoff is complete; do not
launch another harness automatically. The protocol below is for reproduction.

The first v1.0.42 B4 run hid the second card because the legend flag stayed
true after QTE cleanup. v1.0.43's discovery fix is now live validated.
This is bounded acceptance, not general auto gameplay. The historical
one-action B3 procedure below remains available independently.

1. Close other input controllers; stand in the exact boss lobby, game foreground.
2. Start only this bounded harness (never combine the two authority flags):

```powershell
$env:PYTHONPATH = "src;."
python tools/pet_skill_action.py --b4-two-same-match --timeout 1800
```

3. Wait for the attached/started log, then enter ONE combat. Play board moves
   and evolve manually. Do not use Mana/Rage consumables or press the Pet Skill,
   QTE directions or Space yourself. The harness only handles the Pet Skill.
4. After `B4 PERFECT 1/2`, continue playing in the SAME match and accumulating
   resources. Do not wait for a chat reply or re-launch the harness. Once a later
   ready local turn and resources are current, it may perform action 2.
5. After `B4 PERFECT 2/2`, the harness stops. Continue/finish the match manually
   if it is still running. Report the visible results. If the match ends before
   action 2, report that instead: the completed first action remains valid but
   the two-action B4 sample is incomplete. Do not force recovery to manufacture it.

Acceptance: two different ActionIds, same process/epoch/Board/MatchId/local
actor, later source turn, increasing observer generation, distinct positive
server challenges, each 7/7 RAM ACKs + one current in-window Space + runtime
PERFECT. Exactly two card clicks/two Spaces, zero stale/wrong/duplicate inputs,
no third action. Equal sequence/timing values are not themselves stale evidence.
The first result is accepted immediately; only the next action waits for its
own readiness proof. F9 is not this CLI's stop control: use Ctrl+C in its
terminal or ask to stop; a game/session exit also revokes its input authority.

## Current v1.0.41 procedure (supersedes earlier post-state/callback gates)

**B1/B2 PASS; B3 PASS STRONG for the 10/10 scored Perfect streak.**
No further B3 live invocation is needed; final phase/isolation audit is complete.
B2 action 1 is accepted by evidence review under the final user
contract; actions 2 and 3 passed live on v1.0.41. B3 action 4 sent one card click
but no fresh QTE appeared before timeout. Attempts 5-10 and 12-15 passed with 7/7,
one in-window Space each, runtime PERFECT and exit zero. Current accounting:
**13 accepted / 14 scored attempts + 1 excluded**, current streak **10/10**.
Attempt 11 emitted one skill click but observed no QTE during user-reported
manual Mana-card animation overlap. Per explicit user correction, classify it
`EXCLUDED_OPERATOR_INTERFERENCE`: neither PASS nor FAIL; do not reset the streak.
Preserve the raw log. The user requested no code fix and unchanged v1.0.41.
Do not use Mana/Rage consumables during this test; the tool has no authority to
use them. All ten final log summaries were re-audited for current PERFECT,
7/7 directions, single click/Space and zero violations. Attempt 15 finished
at 01:36:59.601 ICT, exit zero. No input controller remains. Do not start
another test automatically or integrate into BASIC/FarmRunner in this phase.
Latest action log:
`logs/phase3b3_pet_skill_action_20260910_013402_b3_attempt15_v1041.jsonl`.
The earlier disconnect is verified but its causal relation to this click is
UNKNOWN. Keep the mandatory current challenge and single-click limit.
Success no longer waits for an externally captured `MATCH_SKILL_USE_RES`. The
current acceptance chain is:

```text
one dynamic Pet Skill click
-> fresh server challenge
-> 7/7 directions RAM-ACKed
-> one Space in the current runtime Perfect interval
-> CardUI runtime PERFECT
-> immediate SUCCESS_PERFECT and stop
```

The one-shot does not start a callback tap, scan for a response, capture
transport boards or wait for post-effect GameState. The exact current CardUI
runtime Perfect is still required; predicted timing or a sent Space alone is
insufficient. Subsequent gameplay waits for its independent normal actionability
gate. A completed QTE cannot be reopened by a late callback.

Test steps:

1. Close Desktop UI/FarmRunner and any other input sender.
2. Stand in the exact pet boss lobby, keep the game foreground, then run from
   `D:\PokiguardToolV2`:

```powershell
$env:PYTHONPATH = "src;."
python tools/pet_skill_action.py --execute-once --timeout 1800
```

3. Enter combat, play and evolve normally. When the Pet Skill is lit and has
   enough runtime Mana/Rage, do not press the skill, directions or Space.
4. The harness must produce one card click, all 7 directions and one Space. Do
   not wait for the assistant between QTE inputs.
5. Report the visible timing result and the final terminal line. A valid pass is
   `SUCCESS_PERFECT` with reason `CURRENT_GENERATION_RUNTIME_PERFECT`.
   The log must show `cardClicks=1`, `spacePresses=1`, 7/7
   confirmed and zero wrong/missing/duplicate/stale/blind retry.
6. Keep playing only after the one-shot harness has stopped. This phase still
   does not give BASIC/FarmRunner continuous Pet Skill authority.

Accepted B1 evidence is
`logs/phase3b3_pet_skill_action_20260909_012152.jsonl`: one HT7 click, fresh
generation, 7/7 RAM-ACKed directions, one Space inside the current interval,
CardUI runtime/user-visible Perfect, fresh settled GameState, and clean
`SUCCESS_PERFECT`. Callback correlation was present but carried no semantic
result and was not used as the gate. B2 action-1 evidence is
`logs/phase3b3_pet_skill_action_20260909_b2_action1_v1040.jsonl`: 7/7, one Space
at 3.183324 s and current/user-visible Perfect. Its old post-state-only failure
is preserved and explicitly reclassified in `phase3b3_report.md`. Action 2 log
`logs/phase3b3_pet_skill_action_20260909_023218_b2_action2_v1041.jsonl` proves
7/7, one Space at 3.168201 s, current/user-visible Perfect, immediate
`SUCCESS_PERFECT` and exit zero. Action 3 log
`logs/phase3b3_pet_skill_action_20260909_024319_b2_action3_v1041.jsonl` adds
7/7, one Space at 3.201961 s, current runtime Perfect, immediate success and
exit zero. **B2 is 3/3 PASS; B3 starts from this streak at 3/10**, with seven
more required for the preferred ten-action reliability target. Each invocation
remains one action. A card/direction/timing/current-QTE
failure resets the consecutive sequence; an unavailable callback/post-state
does not. The observer's `QTE correlated: 0` counts optional server callbacks;
use `PET SKILL ACTION SUCCESS_PERFECT` and `runtimeHookSummary` for acceptance.

The historical narrative below documents earlier callback-required retries and
is retained for audit only.

The most recent action reset B2 to **0/3**: card/QTE/Space reached runtime
`PERFECT!` and the skill won, but the lethal effect closed ACTIVE_COMBAT before
the queued result callback was sampled. v1.0.39 keeps the immutable ActionId,
original MatchId and pre-armed result tap through this post-Space terminal edge.
This is read-only: no card, direction or Space can be sent again. It still needs
an exact old-MatchId response and a later fresh terminal GameState before
success. Current cumulative full actions are 12 (2 accepted, 10 failed). Retry
action 1/3 from the exact boss lobby.

Historical v1.0.34 live action `9d7d75488ae04f21b58e670153bf614e` passed the entire
chain: one card click, 7/7 RAM-ACKed directions, one in-window Space, correlated
server `PERFECT`, and fresh ACK-attested post-state. At that point B2 reached
**1/3**; the later action-2 failure reset the consecutive count.

The preceding B2 retry proved v1.0.33 captures the exact current server envelope,
but its broad heap fallback began after 0.75 seconds and blocked the main loop
for 1.5 seconds while that response arrived. The response variant had no board,
so the blocked loop missed the short-lived owner batch and could not produce a
fresh ACK-attested post-state. v1.0.34 retains pre-arm and reserves the first
3.0 seconds after QTE completion for the 2 ms dispatcher tap plus continuous
25 ms `PendingCombat`/owner-queue capture; only then may the bounded heap
fallback block. The tap
follows only the reverse-proven
`_executionQueue/_drainBuffer -> PendingAction.Action -> Action.m_target ->
ChatService.__c__DisplayClass275_0.message` chain and retains an exact current
MatchId `MATCH_SKILL_USE_RES`; torn reads fail closed. The bounded heap scan
remains a delayed fallback. No card/key/Space is retried. The latest action is
not counted; cumulative B2 full actions are 6 (1 accepted, 5 failed), so
restart B2 from 0/3 after returning to the exact boss lobby.

B2 action 2 reached a fully current, actionable HT7 at 590 Mana/250 Rage and
sent one click, but the game did not publish a QTE. v1.0.30 fixes the concrete
input-path discrepancy: the Pet Skill click now waits the existing 60 ms
cursor-settle interval before the existing 75 ms button hold. It remains one
click/no retry and RAM QTE remains the only acceptance acknowledgement. The
failed action resets consecutive B2 progress to 0/3; start a new harness only
from boss lobby.

B2 action 2 diagnostic ended with zero input after a transient
`MatchService.Players changed during read`; its last resource values were stale
before the operator saw the card lit. v1.0.29 keeps the input-free exact
fast-watch across this runtime/actor torn-read class and retries the next fresh
sample. It also refuses to authorize a card click from board-fallback resources:
`resourceCurrent=true` and source
`Active.playerStatsMap/ObfuscatedInt.Value` are required. The gross HT7 gate
remains 200 Mana + 200 Rage as proven by b2 native code. Start the next B2
action from boss lobby; this zero-input diagnostic does not change accepted
B2 progress 1/3.

Retry 19 tìm đúng HT7 nhưng observer ngừng polling trước khi operator tích đủ
resource; mẫu 260 Mana/0 Rage cuối log đã stale và lần dùng skill sau đó là
manual. Current build có input-phase stage watchdog 2 giây. Nếu terminal báo
`PET SKILL ACTION READ STALL`, controller đã thu hồi quyền input và sẽ không
click muộn; tự tiếp tục giữ lượt, lưu log và quay về boss lobby trước retry.
Event `pet_skill_action_stage_stalled.stage` cho biết chính xác native refresh,
QTE control, runtime read hay geometry bị kẹt. Không tự coi stall là game từ
chối skill.

Retry 18 đã đọc đúng current HT7/Button/interactable/resource/geometry nhưng
zero-click vì second preflight dùng nhầm full-board poll và bị aggregate
ownership guard loại; operand cụ thể của guard cũ không được log nên vẫn
UNKNOWN. Current build giữ cả `IDLE` và input-free `PREFLIGHT` trên exact
native-card + control-only session path. Đây không phải retry click: mọi fresh
guard vẫn bắt buộc và action chỉ có thể phát đúng một card click.

Retry 17 chứng minh Fusion success nhưng log cũ không phân biệt được control
refresh không chạy hay native hand tạm trả empty ở lượt thẻ sáng. Current build
ghi bounded `pet_skill_control_refresh` mỗi state change/5 giây; khi thẻ sáng,
operator nên báo ngay để log đang chạy cho biết exact reason. Harness vẫn chỉ
có quyền một action và phải được dừng trước khi operator tự dùng thẻ.

Retry 16 phát hiện Pet Skill discovery bị chặn sau board/ACK heap path. Current
build đã tách native Pet Skill refresh thành control-only path khoảng 0.2 s sau
khi session được xác lập; board publication/solver gate không đổi. Retry 16 đã
dừng trước mọi input, vì vậy cần khởi chạy B1 mới từ boss lobby.

Retry 15 đạt automatic 7/7 + runtime PERFECT nhưng bị harness cũ invalidated
khi operator chuyển focus sau Space. Current build chỉ đòi foreground cho tới
khi input cuối cùng được gửi; bounded result/post-state wait sau đó là
read-only. Scanner response cũng chỉ quét ChatMessageDTO regions, không trộn
batch-only regions. Vì vậy vẫn cần một B1 live mới để xác nhận exact response,
response board và fresh post-state; visible Perfect một mình chưa đủ.

Harness này chỉ thực hiện **một** Pet Skill action đã được operator cho phép:

```text
Pet Skill card click một lần
→ fresh QTE
→ Arrow closed-loop
→ Space một lần tại midpoint của runtime Perfect window
→ correlated result
→ fresh GameState reread
→ dừng
```

Đây không phải BASIC/FarmRunner policy. Harness không tự tích tài nguyên, không
tự tiến hóa, không đi SWAP/CAST sau Pet Skill và không tự dùng Pet Skill lần
thứ hai.

## B1 — Một full action đầu tiên

1. Đóng Desktop UI/FarmRunner và mọi tool có thể gửi input.
2. Dùng pet thường tương thích với `Huyền Thoại 7`; đứng ở đúng boss lobby.
3. Giữ game ở foreground, mở PowerShell tại `D:\PokiguardToolV2`, chạy:

```powershell
python tools/pet_skill_action.py --execute-once --timeout 1800
```

4. Tự vào trận, chơi/tích tài nguyên và tiến hóa. Harness phải được chạy từ boss
   lobby để giữ đúng lifecycle/QTE inactive baseline của combat session.
   Không còn dùng layout trước tiến hóa để đoán ô skill; CardUI mới được tìm
   bằng native ownership và click trong current RectTransform của chính nó.
5. Khi thẻ Pet Skill sáng và runtime có đủ Mana/Rage, không click thẻ, không
   nhấn Arrow/WASD/Space/Enter. Harness sẽ tự làm toàn bộ đúng một action.
6. Chờ terminal in một trong hai dạng:

```text
PET SKILL ACTION SUCCESS_PERFECT: ...
PET SKILL ACTION <failure>: ...
```

Nếu Pet Skill hạ boss, giữ nguyên màn hình kết quả và không tự bấm `Đồng ý`
cho tới khi harness in terminal. v1.0.39 cần giữ cửa sổ terminal đó đủ lâu để
bắt callback đúng MatchId và đọc lại GameState hậu trận; đây hoàn toàn là bước
chỉ đọc, không có thêm input QTE.

7. Báo lại kết quả nhìn thấy trên game (`PERFECT/GOOD/BAD`), trạng thái hiện tại
   và có/không có thao tác ngoài dự kiến. Log nằm trong
   `logs/phase3b3_pet_skill_action_*.jsonl`.

Nếu thẻ sáng mà harness chưa bấm: không phải chờ assistant trả lời trong lượt.
Tiếp tục tự đi nước để tránh bị loại ba lượt; đừng giữ game chỉ để chờ thông báo.
Nếu muốn tự dùng skill thì hãy dừng harness trước. Giữ lại log; xem
`nativeCardDiscoveryReason`, `runtimeCardLayoutReason`, `geometryReason`.
Mỗi lần harness chỉ sở hữu một action; không tự retry card click.

Sau retry 10: geometry proof có thể đọc lại nguyên hand thêm một lần nếu bắt
gặp Unity đang cập nhật Transform. Đây là retry READ trước input, không phải
retry click. Cả hai read vẫn phải nằm trong freshness guard cũ. Nếu final
preflight reject, harness dừng với zero click; các field geometryReason /
geometryReadAttempts / geometryRetryReason ghi nguyên nhân. Khi harness đã
dừng, thẻ sáng ở lượt sau không tự khởi động lại invocation.

Sau retry 8: lúc game đang khởi tạo QTE, đúng current card nhưng server sequence
chưa tới sẽ hiện log `pet_skill_qte_initialization_wait`. Tool chỉ chờ/đọc RAM
trong generation deadline hiện có (default 3 s), chưa gửi hướng hay Space.
Đừng tự nhấn chen trong khoảng này. Nếu deadline hết, harness dừng, không click
lại; giữ log để phân biệt thiếu challenge với hướng đã gửi mà game chưa ACK.
Không kéo dài lượt đấu để chờ assistant; khi harness đã dừng, tự tiếp tục
chơi hoặc thoát trận như bình thường. Chỉ bắt đầu retry mới từ boss lobby.

## B2/B3

Accepted B1 log `phase3b3_pet_skill_action_20260907_232352.jsonl` now proves the
complete chain: one dynamic HT7 CardUI click, fresh seven-key challenge, 7/7
RAM-ACKed directions, one Space inside the current Perfect interval, runtime
`PERFECT!`, current response-envelope correlation, accepted 64-cell response
board, fresh post-state, and clean `SUCCESS_PERFECT` termination. B1 is PASS.
Proceed only with the controlled B2 sequence below; do not integrate BASIC.

Retry 7 đã chứng minh automatic 7/7 + runtime Perfect. Lần B1 kế tiếp kiểm
tra thêm sửa handoff sau QTE: `qte_server_result_correlated` -> lần đọc board
mới -> `SUCCESS_PERFECT` -> harness tự dừng. Không tính chỉ nhìn thấy Perfect
là full B1 PASS; không tự chuyển B2 khi thiếu server/post-state evidence.

Retry 9 tiếp tục đạt 7/7 + runtime Perfect, nhưng action dừng khi QTE đóng
trước response. Bản sửa mới phải chứng minh `pet_skill_qte_cleanup_wait`
(nếu cleanup đi trước response) -> đúng server correlation -> board reread ->
SUCCESS_PERFECT. Khi QTE vừa kết thúc, harness có thể còn chờ thu kết quả;
nó tuyệt đối không bấm lại skill/Space. Đừng restart invocation ngay chỉ vì
chữ Perfect đã hiện; chờ harness kết luận để không trộn hai action.

Retry 11 đã chứng minh cleanup handoff, 7/7, một Space, RAM `PERFECT!` và exact
server response correlation. Full board vẫn bị game giữ ở
`presentation_busy_or_batch_pending` lâu hơn default 4 giây nên chưa có fresh
post-skill GameState. Harness nay chờ bounded tối đa 15 giây sau correlation;
đây là read-only wait, không phát thêm input và không dùng stale board. Lần B1
kế tiếp phải kết thúc `SUCCESS_PERFECT` với `pet_skill_action_complete`; nếu
hết 15 giây vẫn không có current full state thì giữ fail-closed và giữ log.

Retry 12 tiếp tục đạt 7/7 + một Space + RAM `PERFECT!`, nhưng current server
response chưa xuất hiện trước result timeout 5 giây. Retry 11 đã đo response
tới sau khoảng 6.025 giây, nên harness nay dùng bounded result wait **15 giây**
rồi mới dùng bounded post-state wait **15 giây**. Hai khoảng này chỉ đọc RAM;
Space không bao giờ được retry. Không nhầm `SPACE_SENT_RESULT_UNCONFIRMED` với
QTE input failure và không tính B1 PASS khi chưa có response + full GameState.

Retry 13 đạt 7/7 + một Space + runtime Perfect + exact server correlation,
nhưng transport decoder cũ bỏ qua board nằm trong `MATCH_SKILL_USE_RES`, làm
provider chờ một batch cùng ACK đến hết 15 giây. Bản sửa hiện tại decode/offer
đúng current response board, vẫn bắt buộc strict 64 cells + bounded `srvSeq` +
exact `_ackedSeqs` và mọi stability gate. Khi live lại, giữ log event
`qte_result_board_snapshot_offered`; chỉ `completeCells=64`, `accepted=true`
và terminal `SUCCESS_PERFECT` mới hoàn tất B1. Event rejected/unavailable hoặc
timeout vẫn là fail-closed, không tự retry skill/Space.

Retry 14 đạt automatic Perfect và user thấy skill phá/cascade board rồi sang
lượt mới bình thường, nhưng observer không giữ kịp response DTO. Bản hiện tại
giữ fast control-only polling đến khi response correlate; full board scan chỉ
chạy sau đó. Log mới thêm `qte_result_scan` và direct transient batch capture
vẫn phải qua exact ACK. Live retry cần có `qte_result_message`,
`qte_result_board_snapshot_offered`, fresh post-state và `SUCCESS_PERFECT`.

Sau retry 6, phải test lại B1 với control-only QTE polling. Khi bot đã bấm
thẻ, để bot tự gửi đủ hướng và Space; không nhập chen để làm đẹp kết quả.
Log cần chứng minh 7/7 ACK, đủ headroom, Space trong runtime Perfect window,
runtime/server-correlated Perfect. `qte_critical_poll` và
`pet_skill_direction_event` dùng để phân biệt reader chậm với game không ACK.
Nếu game hết cửa sổ Perfect, harness fail closed; không tự retry skill.

Chỉ làm sau khi B1 sạch. Mỗi lần chạy lệnh là một authority mới và tối đa một
full action. Cách acceptance an toàn nhất là chạy lại từ boss lobby cho từng
action. Mục tiêu B2 là 3 action liên tiếp; B3 ưu tiên 10 action liên tiếp nếu
chi phí tài nguyên/thời gian hợp lý. Không bỏ action lỗi khỏi mẫu số.

## Fail-closed / dừng

- `Ctrl+C` hoặc terminate: thu hồi toàn bộ input còn lại và nhả controller
  lease.
- Mất foreground, đổi HWND/kích thước, MatchId/session/lượt/actor đổi trước
  confirm, recovery/postmatch hoặc QTE mơ hồ: không gửi input tiếp.
- Card click đã gửi nhưng QTE chưa được xác nhận: không click lại.
- Direction chưa được RAM ACK: không resend và không Space.
- Space đã gửi: tuyệt đối không Space lần hai, kể cả response chậm.
- Không chạy song song Desktop UI/FarmRunner; shared controller lease sẽ từ
  chối owner thứ hai.

Harness chỉ dùng read-only process memory và normal foreground mouse/keyboard.
Không có memory write, injection, direct game method hay network manipulation.
