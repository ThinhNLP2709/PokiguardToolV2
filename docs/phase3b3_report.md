# Phase 3B.3 — Full Automated Pet Skill + PERFECT QTE

**Base commit:** `b9164c557cfc055aa13f9a5d5499b367b6e594ab`

**Trạng thái hiện tại:** **Phase 3B.3 — PASS STRONG, v1.0.43**, theo completion
contract đã được user sửa và ghi tại `DECISIONS.md`.

**Báo cáo chốt đầy đủ:** [phase3b3_closeout.md](phase3b3_closeout.md).
B1/B2/B3/B4 đã đủ; 282 focused tests và 1083 full tests PASS. Không còn test
live bắt buộc. Controller đã dừng; không mở phase tiếp theo hay đóng gói.

## Lịch sử triển khai và evidence

Các mục dưới đây giữ nguyên diễn biến qua nhiều bản sửa. Những trạng thái
PARTIAL/pending/retry cũ không phải trạng thái hiện tại; dùng báo cáo chốt ở
trên. Không xóa hoặc chuyển hàng loạt kết quả lỗi cũ thành PASS.

### B4 retry 1 — v1.0.43 PASS, two current PERFECTs in the same match

User reported pet lobby; fresh lobby baseline accepted on replacement game
PID 23784 at 2026-09-10 12:44 ICT. Log:
`logs/phase3b3_pet_skill_action_20260910_124435_b4_retry1_two_same_match_v1043.jsonl`.
Authority `--b4-two-same-match --timeout 1800`; execution session 70040.
User reported two Perfects; raw final summary independently confirms
`B4_SUCCESS_TWO_CURRENT_PERFECT`, `acceptedActions=2`, no stop reason. Both
use MatchId `M_60410580`, epoch 1, Board `0x0000021E58B7F540`, local actor 1,
skill card id 7. The retained observer progresses generation 1 -> 2 without
process restart or match change. Existing B3 streak remains unchanged.

| Action | Source turn | Mana / Rage before | 7/7 ACK completion | Space elapsed estimate | Current result |
|---|---:|---:|---:|---:|---|
| 5ae06813a7a3472185fd52530d4e7474 | 13 | 270 / 200 | 1.152945 s | 3.154792 s | PERFECT |
| 7ca4565446dd40f5b601e30bf2731cb1 | 21 | 240 / 225 | 1.150411 s | 3.167089 s | PERFECT |

Each action has exactly one card click, one Space, seven directions sent and
seven RAM-confirmed, zero wrong/skipped/duplicate/stale/unconfirmed/blind
retries. Both current windows are [3.0, 3.299999952]; Space margins from
start/end are 154.792/145.208 ms and 167.089/132.911 ms respectively.
Both succeed immediately at current runtime PERFECT without server response
correlation or post-effect state (`server_response_correlated=false`,
`post_state=null`). Observer `completedQtes=0` is the optional callback count,
not the accepted action count; do not regress to requiring that counter.

Generation 1 challenge **315118874137065403** has sequence
`DOWN UP LEFT LEFT DOWN RIGHT LEFT`. Generation 2 challenge
**3212872392316864696** has sequence `RIGHT UP RIGHT UP LEFT UP RIGHT`.
The same CardUI (2329902246528) and arrows-list (2330546606128) are reused by
the game; distinct current challenge/identity/sequence and the inactive edge
prove isolation rather than depending on a different object address.
First accepted at 13:13:40.883 ICT; inactive edge 13:13:42.110; second accepted
13:14:33.700; observer stopped 13:14:33.727 ICT (27 ms later), exit **0**.
Read-only process inventory shows game PID 23784 but no Python controller.
Total actual input is two card clicks, fourteen confirmed directions, two
Spaces; no third action. This validates second-card rediscovery after the
v1.0.43 fix in a retained match.

One zero-input preflight at 13:14:28.392 was rejected with
`FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING`; native detail is
`geometry changed during read`. Its ActionId
`33e6d904d9be4eaface542ab1ff46b38` has cardClicks=0, Space=0 and
`inputEmitted=false`. Existing fresh-read rearm then completed action 2;
this is not a third full action or a retry after sending input. Raw diagnostic
remains in the log. No code/timing changes were needed during this review.

**B4 same-match isolation milestone PASS.** B3 already supplies accepted
cross-match samples. No new live run was started, no BASIC/FarmRunner,
consumable or board-input authority added. Final phase scope/isolation audit
and handoff remain; this is not an overall phase release/commit/push claim.

### B4 attempt 1 — first PERFECT, second hidden by stale-lifetime flag

Log `logs/phase3b3_pet_skill_action_20260910_020559_b4_two_same_match_v1042.jsonl`.
MatchId `M_8718fdf8`, PID 11324, first action
`e0fc95bd6bb7419d86104df24d88f1e2`, turn 39. Accepted 02:12:00.666 ICT:
one card click, 7/7 RAM directions in 1.234789 s, one Space at 3.185688 s
inside [3.0, 3.299999952], current PERFECT, zero violations.
Current inactive edge observed at 02:12:01.807. At turn 43, resources 360/250
are current and sufficient, but the hand reader reports
`suspended_during_skill_execution`, deriving `NO_CAPABILITY`; turn 49 repeats
with 620/250. No second card input is present. The user correctly reported
the lit card and sufficient resources. The test is incomplete due to a tool
discovery bug, not a second failed QTE, resource shortage or proven game lag.

Root cause: fast hand discovery equated `Board.isUsingLegendCard` with an
active QTE. The reverse-proven setter and the observed post-QTE lifetime
contradict that interpretation; exact evidence is in the B4 addendum of
`phase3b3_native_card_evidence.md`. v1.0.43 removes only this fast-discovery
early return. Current identity/hand, inactive QTE, readiness, resource,
CardUI pending/used/button, foreground, geometry and all QTE input gates stay.
No reuse of old card data, altered offsets, response wait, broad scan or change
to the accepted directions/Space timing. General board-policy/modal behavior
is deliberately not changed as part of this bounded B4 fix.

Stopped the known harness during diagnosis; execution exit 1 and no final
observer footer. Read-only process inventory confirms PID 35544 is gone.
Raw log is preserved. Await boss-lobby retry; no mid-match/automatic relaunch.

Files changed for this fix: `src/pokiguard_v2/memory_board_provider.py`,
`src/pokiguard_v2/version.py`, `tests/test_memory_provider_baseline.py`,
`tests/test_pet_skill_b4.py`, the two UI/packaging version tests,
`docs/CURRENT_STATE.md`, this report, `docs/phase3b3_runbook.md`,
`docs/phase3b3_native_card_evidence.md`, and `docs/il2cpp_symbols.md`.
New regressions cover rediscovery with the legend flag still true, active-QTE
blocking despite available cards/resources, and pending/used/placeholder cards
still refusing the second click. Live v1.0.43 result is not yet observed.
Validation: targeted provider/B4/control **122 PASS**; full discovery
`python -m unittest discover -s tests -q` **1083 PASS** (13.822 s).

### B4 retained-session coordinator — implementation, not yet live PASS

User requested multiple QTEs in one combat. Added an explicitly authorized
`--b4-two-same-match` CLI mode. It retains the observer/tracker across two
fresh one-action executors, pins the first session, and stops after two current
Perfects. The original one-shot remains mutually exclusive and unchanged in
card/direction/Space execution. Its `completed_successfully` property now lets
the CLI distinguish one-shot success from full two-action B4 completion.

Action 2 requires a post-result proven inactive edge and fresh ready control
on a later local turn. It independently checks current native card/resources/
geometry, then rejects old/foreign generation or challenge before directions.
Success 1 is never held pending response/post-state; terminal exit after it
records an incomplete B4 sample with the first accepted result retained.
No automatic third action, retry of sent input, board play, consumable,
recovery/re-entry or BASIC/FarmRunner integration is introduced.

Changed for B4: `tools/pet_skill_b4.py` (new),
`tools/pet_skill_action.py`, `src/pokiguard_v2/memory_board_provider.py`
(expose already-read readiness flags, no added scan),
`src/pokiguard_v2/version.py` (1.0.42), `tests/test_pet_skill_b4.py` (new),
`tests/test_qte_control_poll.py`, `tests/test_desktop_ui_hardening.py`,
`tests/test_windows_packaging.py`, and the current-state/decisions/runbook/report
documents. No one-action algorithm or gameplay policy change.

Offline tests cover two actions, generation/challenge isolation, immediate
first success without callbacks, equal current sequence/window values, inactive
edge/later-turn/readiness/resource gates, session/terminal/abort handling,
unconfirmed second click without retry, and CLI authority/lobby restrictions.
Verification: `python -m unittest discover -s tests -q` — **1080 tests PASS**;
targeted B4/control rerun — **57 PASS**, including 15 new B4 tests. Compileall,
CLI help and `git diff --check` pass. An initial discovery with `-t .` hit an
existing bare test-module import; the project's normal `-s tests` invocation
passes without changing that unrelated test. Live B4 remains pending; tests
do not substitute for live evidence.

Live invocation armed from boss lobby at 2026-09-10 02:05:59 ICT:
`logs/phase3b3_pet_skill_action_20260910_020559_b4_two_same_match_v1042.jsonl`.
Authority `--b4-two-same-match --timeout 1800`; first PERFECT, second-card
discovery blocked; stopped for the v1.0.43 correction documented above.

### B3 closure — ten consecutive scored PERFECT actions (2026-09-10 ICT)

The preferred B3 live reliability milestone is **PASS STRONG** under the
explicit test protocol. This is a ten-action scored streak, not a claim that
all fifteen physical attempts succeeded. Attempt 11 is excluded by the user's
explicit manual-consumable-interference decision; its raw failure remains.
Attempt 4 remains a scored unconfirmed activation. Startup refusals and the
first attempt-13 process interruption sent no input and are not full actions.

Re-reading each selected log's final `observer_stopped.runtimeHookSummary`
verified: `SUCCESS_PERFECT`, one card click, one Space, 7/7 sent/confirmed,
zero wrong/skipped/duplicate/stale/unconfirmed/blind retries, runtime PERFECT,
and nonnegative start/end Perfect margins. All ten use unchanged v1.0.41.

| Attempt | MatchId | 7/7 completion (s) | Space elapsed estimate (s) | Result |
|---|---|---:|---:|---|
| 5 | M_ad73d344 | 1.234045 | 3.183263 | PERFECT |
| 6 | M_eef5529e | 1.201285 | 3.152418 | PERFECT |
| 7 | M_5e2aed5d | 1.084980 | 3.153923 | PERFECT |
| 8 | M_63347773 | 1.284190 | 3.151786 | PERFECT |
| 9 | M_7c1eba11 | 1.250835 | 3.152789 | PERFECT |
| 10 | M_47a26f41 | 1.135214 | 3.170393 | PERFECT |
| 12 | M_b7052e6c | 1.050251 | 3.168426 | PERFECT |
| 13 retry 1 | M_091afa9a | 1.167758 | 3.151877 | PERFECT |
| 14 | M_edd151b4 | 1.051448 | 3.153671 | PERFECT |
| 15 | M_316ad722 | 1.068051 | 3.153467 | PERFECT |

Totals: **15 full attempts**, **14 scored (13 accepted / 1 unconfirmed)**,
**1 excluded**, current scored streak **10/10**; 70/70 directions in this streak,
91/91 across all thirteen accepted actions. Per-attempt evidence follows below.
No new B3 action is necessary. Final phase scope/isolation audit and handoff
remain; this result review does not claim overall phase closure or perform a
commit/push/package, BASIC integration or next-phase implementation.

### B3 full-action attempt 15 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_013402_b3_attempt15_v1041.jsonl`.
ActionId `4107bba60ea84692900e64d37d099998`; MatchId `M_316ad722`; source
turn 21; PID 11324; HT7/card id 7; pre-action resources 300 Mana / 250 Rage.

- One card click; fresh generation 1; detection latency **1.046 s**.
- Sequence `LEFT DOWN UP LEFT RIGHT RIGHT RIGHT`; **7/7** RAM ACKs in
  **1.068051 s**, headroom **1.931949 s**; all direction violations zero.
- One Space at estimated elapsed **3.153467 s**, current interval
  `[3.0, 3.299999952]`; midpoint error **+3.467 ms**, start/end margins
  **153.467 / 146.533 ms**. Logged QTE elapsed is 3153 ms.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; user reported done.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  result 01:36:59.573 ICT, stopped 01:36:59.601 ICT (28 ms later).
- No callback/post-state wait, extra input, surviving controller or code change.

### B3 full-action attempt 14 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_011910_b3_attempt14_v1041.jsonl`.
ActionId `217917dac8434242a28b16eb7f7ca352`; MatchId `M_edd151b4`; epoch 2,
turn 31; PID 11324; HT7/card id 7; pre-action resources 385 Mana / 235 Rage.

- One card click, generation 1; detection latency **1.063 s**.
- Sequence `UP RIGHT LEFT RIGHT UP RIGHT UP`; **7/7** RAM ACKs in
  **1.051448 s**, headroom **1.948552 s**; all direction violations zero.
- One Space at estimated elapsed **3.153671 s**, current runtime interval
  `[3.0, 3.299999952]`; midpoint error **+3.671 ms**, start/end margins
  **153.671 / 146.329 ms**. Logged QTE sample elapsed is 3170 ms.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; user reported done.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  result 01:29:14.871 ICT, stopped 01:29:14.898 ICT (27 ms later).
- No callback/post-state wait, extra click, surviving controller or code change.

Before the action, at 01:29:09.958 ICT, preflight ActionId
`898775d9006c41248f4a9f4d6fe671e0` was rejected with
`FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING`. The emitted rearm evidence
names `native_card_ui: geometry changed during walk`, `inputEmitted=false`,
cardClicks=0, Space=0. The existing safe zero-input rearm then reacquired fresh
evidence and executed the single accepted action above. This is neither an
additional full action nor a blind retry after a click; preserve its raw log.

Accounting: **14 full attempts**, **13 scored (12 accepted / 1 unconfirmed)**,
**1 excluded operator-interference sample**, current scored streak **9/10**,
cumulative confirmed directions **84/84**. One more successive scored Perfect
action remains for the preferred B3 target. Next: **B3 attempt 15**.

### B3 attempt 13 retry 1 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_010424_b3_attempt13_retry1_v1041.jsonl`.
ActionId `fa558d3ad90b492db7fb9c756606fd5c`; MatchId `M_091afa9a`; source
turn 53; replacement PID 11324; HT7/card id 7; resources 570 Mana / 250 Rage.

- One card click; fresh generation 1; detection latency **1.047 s**.
- Sequence `DOWN RIGHT DOWN RIGHT LEFT LEFT RIGHT`; **7/7** RAM ACKs in
  **1.167758 s**, headroom **1.832242 s**; all direction violations zero.
- One Space at estimated elapsed **3.151877 s**, current interval
  `[3.0, 3.299999952]`; midpoint error **+1.877 ms**, start/end margins
  **151.877 / 148.123 ms**. Logged QTE sample elapsed is 3136 ms.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; user reported done.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  result at 01:12:07.165 ICT, stopped 01:12:07.191 ICT (26 ms later).
- No surviving controller, callback scan/post-state wait, extra invocation or
  source/timing change. Fresh process binding succeeded after the restart.

Accounting: **13 full attempts**, **12 scored (11 accepted / 1 unconfirmed)**,
**1 excluded operator-interference sample**. Current scored streak **8/10**;
cumulative confirmed directions **77/77**. The original attempt-13 launch
stopped before any input and does not add a full attempt. Two more successive
scored Perfect actions remain. Next: **B3 attempt 14**; phase stays PARTIAL.

### Attempt-13 startup interrupted before input (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_005144_b3_attempt13_v1041.jsonl`.
Attached PID 35016 at 00:51:46.576 ICT; stopped 00:52:30.011 ICT, exit 1.
Final summary: `IDLE`, `invocationConsumed=false`, card/Space timestamps null;
no QTE or action was started. User reported the game went out. Process check
finds replacement game PID 11324 and no Python controller. Cause of the old
game exit is not established by this log. A fresh boss-lobby attach is required;
do not reuse the old process/session. This is not another full action or scored
failure: totals remain 10 accepted / 11 scored + 1 excluded, streak **7/10**.
Next: retry attempt 13 on user authorization. No code change or auto-restart.

### B3 full-action attempt 12 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_004009_b3_attempt12_v1041.jsonl`.
ActionId `f8f75f111fb64b21b3348a1afe4a3b4a`; MatchId `M_b7052e6c`; source
turn 49; PID 35016; HT7/card id 7; pre-action resources 230 Mana / 204 Rage.

- One card click; fresh generation 1; detection latency **1.016 s**.
- Sequence `UP DOWN LEFT UP RIGHT RIGHT LEFT`; **7/7** RAM ACKs in
  **1.050251 s**, headroom **1.949749 s**; all direction violations zero.
- One Space at **3.168426 s**, current runtime interval `[3.0, 3.299999952]`;
  midpoint error **+18.426 ms**, start/end margins **168.426 / 131.574 ms**.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; user reported done.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  observer stopped at 00:47:06.362 ICT. No surviving input controller.
- No callback scan/post-state wait, source/timing change or extra invocation.

Accounting: **12 full attempts**, **11 scored (10 accepted / 1 unconfirmed)**,
**1 excluded operator-interference sample**. Streak **7/10** under the user's
explicit attempt-11 exclusion; cumulative confirmed directions **70/70**.
Three further consecutive scored Perfect actions remain for the preferred
B3 target. Next: **B3 attempt 13**. B1/B2 remain PASS; phase remains PARTIAL.

### B3 attempt 11 — mana-card overlap; unchanged-code retry requested

Log: `logs/phase3b3_pet_skill_action_20260910_003243_b3_attempt11_v1041.jsonl`.
Match `M_9c449306`, turn 15, ActionId `6fbba057810c4004a9f5d38827a043b3`.
At 00:35:24.848 ICT mana was 171; at 00:35:25.071 it was 271, Rage 230.
The skill button became interactable and the harness sent one click. No fresh
QTE was observed before its deadline: `CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`,
zero direction/Space input, exit 1, observer stopped 00:35:28.713 ICT.

User reported overlapping manual mana-card use/animation, then explicitly
withdrew the fix request and requested another test with unchanged code. The
log does not prove which animation/input blocker was active. No source/timing
changes were made; no causal claim about a code defect is accepted from this
sample. The user's subsequent explicit correction excludes this manual
consumable interference from scoring: `EXCLUDED_OPERATOR_INTERFERENCE`, neither
PASS nor FAIL, preserving streak **6/10**. Raw exit/result remain unchanged.
Accounting: 11 full attempts, 10 scored (9 accepted / 1 unconfirmed), 1 excluded.
The previous automatic streak-reset assessment is superseded by the user's
test-protocol decision; this does not erase attempt 4's scored failure. The
tool must not use Mana/Rage consumables. No automatic retry was added.
Attempt-12 startup was refused before input because Board.Instance still
existed. This is a pre-start refusal, not an additional full-action failure.
Next: user returns to exact boss lobby, then explicitly retries attempt 12.

### B3 full-action attempt 10 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_001348_b3_attempt10_v1041.jsonl`.
ActionId `597c6d3aadb24137af302c66d4b273ee`; MatchId `M_47a26f41`; source
turn 27; PID 35016; HT7/card id 7; pre-action resources 233 Mana / 248 Rage.

- One card click; fresh generation 1; detection latency **1.047 s**.
- Sequence `RIGHT RIGHT DOWN UP LEFT UP LEFT`; **7/7** RAM ACKs in
  **1.135214 s**, headroom **1.864786 s**; all direction violations zero.
- One Space at **3.170393 s**, current runtime interval `[3.0, 3.299999952]`;
  midpoint error **+20.393 ms**, start/end margins **170.393 / 129.607 ms**.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; runtime acceptance
  observed 62 ms after the Space timestamp. User asked whether it was Perfect;
  no separate user-visible timing claim is attributed to this action.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  observer stopped at 00:17:54.379 ICT, about 27 ms after runtime acceptance.
- No response scan, dispatcher tap, post-state wait, extra input or surviving
  input controller.

Accounting: **10 full attempts / 9 accepted / 1 unconfirmed**, current streak
**6/10** after attempt 4, cumulative confirmed directions **63/63**. This is
not 10/10 reliability: four more consecutive accepted actions are needed for
the preferred streak. Next: **B3 attempt 11**. B2 remains PASS; no code/timing
changes or automatic new invocation during this log review.

### B3 full-action attempt 9 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260910_000638_b3_attempt9_v1041.jsonl`.
ActionId `9565e7f238d2405eb314214c84dd1fd3`; MatchId `M_7c1eba11`; source
turn 19; PID 35016; HT7/card id 7; current resources 360 Mana / 250 Rage.

- One card click, fresh generation 1; detection latency **1.047 s**.
- Sequence `LEFT DOWN UP DOWN LEFT LEFT LEFT`; **7/7** RAM ACKs in
  **1.250835 s**, headroom **1.749165 s**; all direction violations zero.
- One Space at **3.152789 s**, current interval `[3.0, 3.299999952]`;
  midpoint error **+2.789 ms**, start/end margins **152.789 / 147.211 ms**.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`; user confirmed
  `đã xong 1 per`. Runtime acceptance observed 62 ms after the Space timestamp.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  observer stopped 00:09:29.762 ICT, about 29 ms after runtime acceptance.
- No response scan, dispatcher tap, post-state wait, extra input or surviving
  input controller.

Accounting: **9 full attempts / 8 accepted / 1 unconfirmed**, current streak
**5/10** after attempt 4, cumulative confirmed directions **56/56**. B2 remains
PASS. Next: **B3 attempt 10**, candidate sixth success of this streak.
No code/timing changes or new invocation during this review.

### B3 full-action attempt 8 — PASS PERFECT (2026-09-10 ICT)

Log: `logs/phase3b3_pet_skill_action_20260909_235156_b3_attempt8_v1041.jsonl`.
ActionId `e3014f3b8cb644c2bd622306692f4b3f`; MatchId `M_63347773`; source
turn 77; PID 35016; HT7/card id 7; pre-action resources 240 Mana / 250 Rage.

- One card click, fresh generation 1; detection latency **1.078 s**.
- Sequence `DOWN UP LEFT UP DOWN RIGHT RIGHT`; **7/7** RAM ACKs in
  **1.284190 s**, headroom **1.715810 s**; all direction violations zero.
- One Space at **3.151786 s** inside runtime interval `[3.0, 3.299999952]`;
  midpoint error **+1.786 ms**, start/end margins **151.786 / 148.214 ms**.
- Prediction/current runtime `PERFECT`, RAM text `PERFECT!`, user reported
  `đã per`. Runtime acceptance was observed 62 ms after the Space timestamp.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`, exit **0**;
  observer stopped 2026-09-10 00:02:17.487 ICT, about 28 ms after acceptance.
- No response scan, dispatcher tap, post-state wait, extra input or surviving
  input controller.

Accounting: **8 full attempts / 7 accepted / 1 unconfirmed**, current streak
**4/10** after attempt 4; cumulative confirmed directions **49/49**. B2 PASS
is preserved. Next is **B3 attempt 9**, candidate fifth success of the current
streak. No code/timing changes or new live action during this result review.

### B3 full-action attempt 7 — PASS PERFECT (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_233727_b3_attempt7_v1041.jsonl`.
ActionId `a2d79a409a80417ab2cefef42f4b6493`; MatchId `M_5e2aed5d`; source
turn 75; PID 35016; HT7/card id 7; pre-action resources 430 Mana / 250 Rage.

- One card click, fresh generation 1, detection latency **1.031 s**.
- Sequence `DOWN UP LEFT UP UP DOWN LEFT`; **7/7** RAM ACKs in **1.084980 s**;
  headroom to Perfect start **1.915020 s**; all direction violations zero.
- One Space at **3.153923 s**, runtime interval `[3.0, 3.299999952]`;
  midpoint error **+3.923 ms**, start/end margins **153.923 / 146.077 ms**.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`, user reported
  `có per 1 lần r`. Acceptance was observed 47 ms after the Space timestamp.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`; exit **0**;
  observer stopped 23:47:38.406 ICT, about 28 ms after runtime acceptance.
- No callback scan, dispatcher tap, post-state wait, extra input or surviving
  input controller.

Accounting: **7 full attempts / 6 accepted / 1 unconfirmed**, current streak
**3/10** after attempt 4, cumulative directions **42/42**. B2 remains PASS.
Next controlled action is **B3 attempt 8**, candidate fourth success of the
current streak. This review only updates acceptance documentation.

### B3 full-action attempt 6 — PASS PERFECT (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_232748_b3_attempt6_v1041.jsonl`.
ActionId `7129a97e00fc417baacce20063cbdbd4`; MatchId `M_eef5529e`; source
turn 43; PID 35016; HT7/card id 7; current pre-action Mana/Rage 390/250.

- One card click, fresh generation 1; detection latency **1.078 s**.
- Sequence `UP LEFT UP LEFT UP LEFT UP`; **7/7** RAM ACKs in **1.201285 s**;
  headroom to Perfect start **1.798715 s**; all direction violations zero.
- One Space at **3.152418 s** inside `[3.0, 3.299999952]`, midpoint error
  **+2.418 ms**, start/end margins **152.418 / 147.582 ms**.
- Predicted/current runtime `PERFECT`, RAM text `PERFECT!`, user reported
  `đã per`. Runtime acceptance observed 62 ms after the Space timestamp.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`; exit **0**;
  observer stopped 23:33:36.382 ICT, about 28 ms after runtime acceptance.
- No response scan, dispatcher tap or post-state wait; no extra input and no
  surviving input controller.

Accounting: **6 full attempts / 5 accepted / 1 unconfirmed**, current streak
**2/10** after attempt 4; cumulative confirmed directions **35/35**. B2 PASS
is retained. Next controlled action is **B3 attempt 7**, candidate third
success in the current streak. Only documentation changed during this review.

### B3 retry / full-action attempt 5 — PASS PERFECT (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_231903_b3_attempt5_v1041.jsonl`.
ActionId `ea4f713d62d74cb4b389cfd02d66bc9b`; MatchId `M_ad73d344`; PID 35016;
source turn 25; HT7/card id 7; current pre-action Mana/Rage 330/250.

- One card click; fresh QTE generation 1, detection latency **1.078 s**.
- Sequence `LEFT LEFT UP UP UP LEFT DOWN`; **7 sent / 7 RAM-confirmed**
  in **1.234045 s**; headroom to Perfect start **1.765955 s**.
- Wrong/skipped/duplicate/stale/unconfirmed/blind direction retries: all zero.
- Exactly one Space at **3.183263 s**, runtime interval `[3.0, 3.299999952]`;
  margins **183.263 / 116.737 ms**, midpoint error +33.263 ms.
- Predicted and current runtime `PERFECT`; RAM text `PERFECT!`; user confirmed
  `đã xong 1 per`. Runtime acceptance was observed 47 ms after Space.
- Final `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`; process exit
  **0**. Observer stopped at 23:22:45.611 ICT, 27 ms after runtime acceptance.
- Zero response-scan, dispatcher-tap or post-QTE provider events; no post-state
  wait. No extra input or surviving input controller.

This retry succeeded using unchanged v1.0.41 code and the existing three-second
challenge timeout. It demonstrates a successful activation after the earlier
unconfirmed click, but does not establish the cause of that earlier failure.
Historical attempt 4 remains counted. Aggregate: **5 full attempts / 4 accepted /
1 unconfirmed**, current consecutive streak **1/10**, cumulative confirmed
directions **28/28** across the four accepted actions. B2 remains PASS.
Next controlled invocation is **B3 attempt 6** (candidate second success of the
current streak). No new action was started by this result review.

### B3 action 4 — card click sent, no fresh QTE observed (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_230144_b3_action4_v1041.jsonl`.
PID 35016; ActionId `58a8a512b0e1422f9f9e3cd21658594e`; MatchId
`M_5a7fcc7d`; source turn 55. Exact native hand discovered HT7/card id 7
in zero-based slot 4 of 5, current Button usable, current resources 360/250
and capability-derived cost 200 Mana / 200 Rage. Geometry proof was current,
sample age 110 ms, normalized click point (0.614882, 0.829344), cursor settle
60 ms and mouse hold 75 ms.

One card click was sent at 23:13:38 ICT. No fresh QTE/challenge generation was
observed within the three-second generation timeout. Final result at
23:13:41 was `CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`; process exited 1.
Directions 0, Space 0, duplicate card click 0. There is no Perfect result to
accept for this attempt. This differs from the removed post-Perfect response
gate: the mandatory pre-input challenge itself was not observed.

User reported a game disconnect and being in combat after evolution. Direct
read-only diagnostics found the same MatchId and Board, turn 67/local with
10 seconds remaining and 510 Mana / 225 Rage; a later read found turn 72/boss
and HT7 still present in slot 4/5, Button usable, no pending action/used-this-turn.
The inactive CardUI QTE scalar read was rejected as implausible; it supplies no
valid current QTE evidence. The slot-0 non-skill card also rejected CardData
identifiers; this did not prevent reading all four other cards, including HT7.
No automated input or new invocation occurred during these diagnostics.

`C:/Users/Admin/AppData/LocalLow/Pokiguard/PokiguardOnlines/Player.log` records
DNS failures (`Could not resolve host 'pokiguard.online'`) and WebSocket close
code 1006, including 23:04:01, 23:04:17, 23:04:47, 23:05:17 and 23:05:59.
Combat was first observed at 23:07:23. These failures corroborate the reported
earlier disconnection but do not prove a network fault at the 23:13:38 click.
The log has no timed skill acknowledgement explaining this activation failure.
Lost mouse activation vs delayed/missing server challenge remains UNKNOWN;
do not change click timing or bypass challenge validation from this evidence.

Accounting: **4 full actions / 3 accepted / 1 unconfirmed**, consecutive
reliability streak **0/10** after this failed activation. B2's historical 3/3
PASS is retained. No direction or Space timing failure occurred in action 4.
The harness is stopped; the next controlled attempt starts from boss lobby.

### Live B2 action 3 — PASS; B2 closed at 3/3 (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_024319_b2_action3_v1041.jsonl`.
ActionId: `c6bc1d4de62040f991dd21351b1f48d9`; MatchId: `M_76c33a56`;
lifecycle epoch 2; source turn 57; HT7/card id 7; pre-action resources 355/250.

- Exactly one card click; fresh QTE generation 1 within this new session.
- Sequence `LEFT RIGHT RIGHT LEFT RIGHT RIGHT UP`; **7/7** runtime ACKs
  in **1.200452 s**. Wrong/skipped/duplicate/stale/unconfirmed/blind retries: zero.
- One Space at **3.201961 s**, current interval `[3.0, 3.299999952]`,
  start/end margins **201.961 / 98.039 ms**, midpoint error +51.961 ms.
- Current CardUI `PERFECT!`, prediction `PERFECT`; user reported completion.
- `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`; exit **0**.
  Runtime acceptance occurred 47 ms after the Space timestamp. The observer
  stopped at 03:00:09.740 ICT, about 27 ms after the acceptance event.
- No callback scan/post-state wait and no extra input after completion.

This invocation first observed `M_7287990c`, then a match-clear edge at turn 74,
then new match `M_76c33a56`. No card click was sent for the first match. The
accepted action is tied to the new lifecycle epoch 2 and its fresh preflight;
that is useful in-process evidence across a match boundary.

#### Accepted B2 sequence and reliability continuation

| Action | MatchId | Directions elapsed (s) | Space elapsed (s) | End margin (ms) | Final-contract result |
|---|---|---:|---:|---:|---|
| 1 | M_a04f76c1 | 1.234376 | 3.183324 | 116.676 | PERFECT; v1.0.40 post-state-only failure explicitly reclassified |
| 2 | M_bea34652 | 1.151995 | 3.168201 | 131.799 | SUCCESS_PERFECT on v1.0.41 |
| 3 | M_76c33a56 | 1.200452 | 3.201961 | 98.039 | SUCCESS_PERFECT on v1.0.41 |

**B2 PASS: 3 full-action attempts / 3 accepted**, 21/21 directions, three card
clicks and three Space confirms. PERFECT 3 / GOOD 0 / BAD 0. Wrong, missing,
duplicate, stale or blind input; double card click; duplicate/out-of-window
Space; wrong-generation result: all zero in this sequence. Historical retries
and the action-1 raw failure remain documented, not removed from their records.

Timing across the three accepted actions:

| Metric | Min | Max | Average |
|---|---:|---:|---:|
| QTE detection latency (s) | 1.062 | 1.094 | 1.078 |
| Direction completion elapsed (s) | 1.151995 | 1.234376 | 1.195608 |
| Direction headroom to Perfect start (s) | 1.765624 | 1.848005 | 1.804392 |
| Space elapsed (s) | 3.168201 | 3.201961 | 3.184495 |
| Start margin (ms) | 168.201 | 201.961 | 184.495 |
| End margin (ms) | 98.039 | 131.799 | 115.505 |

The three action/QTE identities belong to three distinct MatchIds. Observer
generation number 1 is scoped to its full session identity, not reused as global
authority. Action 3 additionally crossed an earlier match while the harness
waited. This evidence supports B4 session isolation; final phase audit remains.

B3 extends this same accepted streak from **3/10**; the next invocation is
**B3 action 4/10**, followed by six more if all succeed. Do not require ten
additional actions or silently omit a future input/timing failure. Each action
still requires explicit controlled invocation. No B3 action was auto-started by
this review. Phase 3B.3 remains PARTIAL; no code, packaging or Git publication
changed during this log review.

### Live B2 action 2 — PASS, immediate completion verified (2026-09-09)

Log: `logs/phase3b3_pet_skill_action_20260909_023218_b2_action2_v1041.jsonl`.
ActionId: `da95a2ef9a574277b30a29456ee6b2e4`; MatchId: `M_bea34652`;
source turn 49; HT7/card id 7; resources before 339 Mana / 250 Rage.

- One automatic card click and fresh generation 1.
- Sequence `DOWN RIGHT UP RIGHT UP LEFT DOWN`; **7/7 RAM-confirmed** in
  **1.151995 s**. Wrong/skipped/duplicate/stale/unconfirmed/blind retry: all zero.
- One Space at **3.168201 s**, inside `[3.0, 3.299999952]`; margins
  **168.201 ms / 131.799 ms**; target-midpoint error +18.201 ms.
- Predicted/runtime `PERFECT`; current CardUI text `PERFECT!`; user reported
  `per 1 cái r`. Runtime acceptance was observed 62 ms after the Space timestamp.
- Final result `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`,
  `card_clicks=1`, `space_presses=1`, `post_state=null`.
- `observer_stopped` at 02:39:26.064 ICT, about **29 ms** after the runtime
  acceptance event; process exited **0** and no input controller remained.
- Zero response scans, dispatcher-tap events and post-QTE provider polls.
  `server_response_correlated=false` is expected. `completedQtes=0` and the
  console's `QTE correlated: 0` are legacy callback counters; the authoritative
  harness result is one completed input action.

This live result confirms the v1.0.41 completion fix. Current B2 progress is
**2/3 consecutive accepted actions** under the final user contract: action 1
is the explicitly reclassified v1.0.40 evidence below; action 2 is this fresh
v1.0.41 run. No input/timing failures in this sequence. Next: **B2 action 3**
from boss lobby. Phase 3B.3 is still PARTIAL. Only acceptance documentation was
updated after this run; no code/input timing was changed.

### Final contract correction and B2 action 1 review (2026-09-09)

The accepted action ends at **current-generation CardUI runtime PERFECT** after
one card click, a fresh server-issued challenge, closed-loop directions and one
in-window Space. v1.0.41 immediately returns
`SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`. Post-Space response,
resource deltas, cascade/board effects and a later GameState are outside this
input primitive. A future gameplay controller must independently wait for the
normal actionable board before sending another action.

The B2 action-1 capture ran on v1.0.40:

- Log: `logs/phase3b3_pet_skill_action_20260909_b2_action1_v1040.jsonl`.
- ActionId: `530143a332e24f7fb584b7fee275ca11`; MatchId: `M_a04f76c1`;
  source turn 79; HT7/card id 7; resources before: 1010 Mana / 235 Rage.
- One card click; fresh generation 1; sequence
  `DOWN RIGHT LEFT LEFT DOWN LEFT RIGHT`.
- **7 sent / 7 confirmed** in **1.234376 s**; wrong, skipped, duplicate,
  stale, unconfirmed and blind retry all **0**.
- Exactly one Space at **3.183324 s**, interval `[3.0, 3.299999952]`;
  183.324 ms after start / 116.676 ms before end.
- Prediction `PERFECT`, current CardUI `PERFECT!`, user confirmation
  `per 1 lần`; no correlated response.
- The original terminal result was `POST_SKILL_REREAD_UNCONFIRMED`, reason
  `RUNTIME_PERFECT_BUT_FRESH_SETTLED_GAME_STATE_UNAVAILABLE`.
  The unnecessary 30-second post-state wait contained 107 unresolved-ACK polls
  and four direct-owner-capture waits. The dispatcher tap made 5054 polls,
  observed 42 candidate messages and decoded zero skill results.

The defect was the leftover post-state acceptance condition, not a failed
direction or Space input. The raw log remains unchanged. Under the final user
contract this evidence is accepted as **B2 action 1/3**. The current sequence
contains **one full action, one accepted, zero input/timing failures**. The
earlier turn-63 `FINAL_CARD_LOCAL_TURN_NOT_ACTIONABLE` had zero clicks/Space and
is recorded as a pre-input race, not omitted as a failed full action. This is
an explicit evidence reclassification; v1.0.41 still needs its next live run.

Implementation changes:

- finish the executor directly at the exact current runtime PERFECT;
- disable the one-shot's dispatcher response tap, response heap scan and
  post-Space transient board capture;
- completed actions ignore later callbacks, missing/unstable boards and later
  lifecycle changes, and cannot emit another card/direction/Space;
- reject inconsistent QTE ownership as well as wrong generation/session;
- keep independent diagnostic response parsers; deprecated post-state timeout
  arguments and legacy enum values remain for compatibility but the normal
  executor never enters that state;
- replace obsolete post-state test cases with active tests for this boundary;
  preserve independent diagnostic board-helper tests.

B1 remains PASS. B2 is **1/3**, and the next live command is **B2 action 2**
from the exact boss lobby. No new live input was sent during this correction.
Phase 3B.3 remains PARTIAL; BASIC/FarmRunner Pet Skill integration is later work.

Verification on v1.0.41: **137/137 focused** Pet Skill/QTE/control/dispatcher
tests and **1065/1065 full regression PASS**, with **zero skipped tests**;
compileall and diff checks PASS. The temporary skipped historical class was
removed: 24 obsolete post-state cases were replaced with 10 active
completion/ownership/input-isolation and diagnostic board-helper cases. New
coverage also checks the callback tap is never armed and an exactly correlated
reject can only affect an unfinished action. The test run's intentional parser
error, fatal-controller fixture and read-stall messages are expected test output;
the suite exits zero.

Files changed for this final v1.0.41 correction (all in PokiguardToolV2):

- `src/pokiguard_v2/pet_skill_action.py`
- `src/pokiguard_v2/version.py`
- `tools/pet_skill_action.py`
- `tools/pet_qte_observer.py`
- `tests/test_pet_skill_action.py`
- `tests/test_qte_control_poll.py`
- `tests/test_desktop_ui_hardening.py`
- `tests/test_windows_packaging.py`
- `docs/DECISIONS.md`
- `docs/CURRENT_STATE.md`
- `docs/phase3b3_report.md`
- `docs/phase3b3_runbook.md`
- `docs/pokiguard_pet_skill_qte_reverse_report.md`

Source/harness version is updated; no new packaged executable was built and no
commit/push was performed by this correction. Existing unrelated worktree
changes and raw live logs are preserved.

All entries below describe earlier versions and their then-current gates;
the final contract above and `DECISIONS.md` take precedence.

### Historical live B1 revalidation — PASS (2026-09-09, v1.0.40)

Log: `logs/phase3b3_pet_skill_action_20260909_012152.jsonl`

ActionId: `e7ea05db917a46d0aae9547cbb983d47`

MatchId: `M_702266cf`

Skill: HT7 / card id 7

Source turn: 49

- Automatic card click: **1**; fresh QTE generation: **1**.
- Sequence: `RIGHT LEFT DOWN RIGHT UP LEFT LEFT`.
- Directions sent/confirmed: **7/7** in 1.167871 s.
- Wrong, missing/unconfirmed, duplicate, stale and blind retry: **0**.
- Current Perfect interval: `[3.0, 3.299999952]`; target midpoint:
  3.149999976 s; one Space sent at 3.153660 s.
- Space margins: 153.660 ms after interval start and 146.340 ms before end;
  target error +3.660 ms.
- Native prediction: `PERFECT`; current-generation CardUI runtime result:
  `PERFECT!`; user-visible result: `Perfect`.
- Gross HT7 capability remains 200 Mana / 200 Rage. Observed resources
  238/250 -> 140/150 are the net post-effect values, not a replacement cost.
- Fresh post-skill GameState: active combat, turn 51, board ready, stable,
  non-cascading; it proves turn/resource progress from the action source state.
- Final result:
  `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT_AND_SETTLED_GAME_STATE`.
  The one-shot process exited cleanly after exactly one completed action.

The server callback was observed (`server_response_correlated=true`) but had no
semantic result (`server_result=null`). Under the corrected external boundary it
is optional telemetry, not the acceptance basis. B1 is therefore accepted from
the server-issued challenge, exact closed-loop inputs, current runtime Perfect,
and fresh settled authoritative GameState. Controlled B2 starts at **0/3**;
Pet Skill remains outside BASIC/FarmRunner policy.

### Contract correction — callback optional after runtime PERFECT (2026-09-09)

#### Why the old gate was wrong

The old executor required current `MATCH_SKILL_USE_RES` correlation before it
could read the post-skill state. That made externally ephemeral callback
ownership part of gameplay success. It produced false failures in two directly
observed cases:

- `phase3b3_pet_skill_action_20260908_224056.jsonl`: CardUI runtime PERFECT;
  response correlated after about 1.17 s but had no board; the old harness later
  failed only because it could not obtain the callback-shaped post-state path.
- `phase3b3_pet_skill_action_20260908_231448.jsonl`: 7/7, one in-window Space,
  CardUI runtime PERFECT and a user-confirmed lethal win; combat closed before
  the callback was externally captured, so the old harness rejected a skill
  that the game had already executed successfully.

The callback is still used by the game to apply authoritative resolution. The
bug was requiring the **external tool** to observe it. Reverse evidence is
recorded in `pokiguard_pet_skill_qte_reverse_report.md`.

#### v1.0.40 completion model

```text
current server challenge (mandatory)
-> exact ActionId / QTE generation
-> 7/7 directions, each RAM-ACKed
-> exactly one Space inside current runtime Perfect interval
-> same CardUI generation reports runtime PERFECT
-> no further QTE input
-> exact terminal OR later fresh stable/ready/non-cascading GameState
   with board/turn/resource progress
-> SUCCESS_PERFECT / release authority
```

`MATCH_SKILL_USE_RES` is retained only as:

- best-effort telemetry;
- a non-blocking strict-board fast path when present;
- an explicit rejection signal after full current-action correlation.

Missing response, missing timing echo and response-without-board do not block or
fail the action. A server timing word also does not override the direct current
CardUI runtime PERFECT result. The broad result heap scan is skipped for this
callback-optional harness, preventing it from delaying the full settled-state
poll. Stale/wrong skill, challenge, generation, session and MatchId evidence,
pre-Space lifecycle loss, Emergency Stop and failure to obtain a settled state
within the bounded deadline still fail closed. Card click and Space remain
strictly one-shot.

#### Offline validation

- focused Pet Skill/QTE/control/dispatcher tests: **149/149 PASS**;
- full regression: **1077/1077 PASS**;
- new coverage includes callback-free active and terminal completion, optional
  non-PERFECT timing echo as telemetry, exact explicit reject handling, stale
  reject isolation, no extra input during settle wait, and unchanged timeout.

This remediation does not integrate Pet Skill into BASIC/FarmRunner and each
harness invocation still authorizes only one action. The live B1 above closes
the revalidation requirement; controlled B2 is next.
All historical sections below remain evidence of the previous gate and must not
be read as the current acceptance rule.

### B2 retry — terminal win closed ACTIVE_COMBAT before callback capture

Log `logs/phase3b3_pet_skill_action_20260908_231448.jsonl`, ActionId
`ef0116e70f014ef3a21cfdd152b98c4f`, match `M_2ba7d737`, source turn 41.
One dynamic HT7 click produced `UP RIGHT RIGHT UP RIGHT DOWN UP`; 7/7 directions
were individually RAM-ACKed in 1.150914 s. One Space landed at 3.186133 s inside
the current `[3.0, 3.299999952]` Perfect interval. Runtime/RAM reported
`PERFECT!` and `qteElapsedMs=3186`; the user confirmed the skill won the match.

The server callback was not correlated before the skill's lethal effect closed
combat. Roughly 0.62 s after QTE closure, `poll_qte_control` reported the
lifecycle edge; the old harness invalidated the action, disarmed its tap and
stopped. Because current server correlation and a fresh post-skill GameState
remain mandatory, the visible win is not counted. B2 stays **0/3** and the
cumulative total becomes **12 full actions: 2 accepted, 10 failed**.

v1.0.39 preserves only read-only work across this exact post-Space boundary.
After one Space plus runtime completion, it retains the immutable ActionId,
original MatchId, completed QTE and pre-armed dispatcher tap until the existing
bounded deadlines. It can correlate only an exact callback for that MatchId and
then requires a later exact terminal GameState; it cannot click the card, send a
direction or resend Space. Pre-Space ownership loss and ambiguous/wrong-match
terminal evidence remain terminal failures. Offline verification is
**297/297 focused** and **1072/1072 full regression PASS**; compileall and diff
check are clean. Live retry is required.

### B2 retry — correlated response omitted board; later boards were not retained

Log `logs/phase3b3_pet_skill_action_20260908_224056.jsonl`, ActionId
`743ebfa7f9e84af5ae44d95b2830e15b`, match `M_bba167e4`, source turn 47.
The executor clicked once, confirmed 7/7 directions in 1.185870 s, and sent
one Space at 3.171934 s inside the current `[3.0, 3.299999952]` interval.
Runtime/RAM resolved `PERFECT!` (`qteElapsedMs=3156`) and the exact current
server response correlated.

The response contained neither board nor `srvSeq`. The match advanced through
turns 48--51 during the new 30-second post-state window, but five direct-owner
grace polls and 106 subsequent polls found no current ACK-attested full batch.
The direct dispatcher tap had been disarmed at correlation, so later ephemeral
move/card response boards were not retained. The provider correctly produced
no fabricated GameState. This action fails the final gate; B2 remains **0/3**
and cumulative full actions are **11: 2 accepted, 9 failed**.

v1.0.38 retains the already pre-armed read-only dispatcher tap until the action
fully completes/fails. During post-state wait it captures strict 64-cell boards
from later current-match `MATCH_MOVE_RES`, `MATCH_CARD_USE_RES` or
`MATCH_SKILL_USE_RES`, including reused DTO addresses distinguished by their
closure JSON identity, then offers each once to the normal provider. Publication
still requires exact `srvSeq`, latest ACK and all presentation/array/flag
stability gates. No extra gameplay input is possible. Live retry is required.
Offline verification is **293/293 focused** and **1068/1068 full regression
PASS**; compileall and diff check are clean.

### B2 retry — raw callback remained, mutable DTO result was missed

Log `logs/phase3b3_pet_skill_action_20260908_222828.jsonl`, ActionId
`5b98fadfab394d6b9bb75958fc1bc998`, match `M_3c2943da`, source turn 21.
The executor used one click, confirmed 7/7 directions in 1.101554 s and sent
one Space at 3.186741 s inside `[3.0, 3.299999952]`. Runtime/RAM resolved
`PERFECT!` with `qteElapsedMs=3172`; wrong, missing, duplicate, stale and blind
retry counts were all zero.

Server correlation failed despite 6,017 stable direct-dispatcher reads, zero
torn reads and 44 callback candidates. The defect was local: v1.0.35 read the
immutable `json +0x18` only after `message +0x20` decoded as the exact mutable
DTO. If Unity cleared/reused the DTO first, the retained raw envelope was never
examined. This action is not accepted, so B2 stays **0/3** and cumulative full
actions are **10: 2 accepted, 8 failed**.

v1.0.37 independently decodes an exact current-MatchId
`MATCH_SKILL_USE_RES` from the callback JSON and projects only already accepted
result-correlation fields. It does not relax current-generation timestamp
correlation. Raw response boards still require their own strict 8x8 and
`srvSeq` validation plus the existing ACK/latest/stability gate. Stale/other
events produce no result, and no gameplay input is retried. Live retry remains
required. Offline verification is **291/291 focused** and **1066/1066 full
regression PASS**; compileall and diff check are clean.

### B2 retry — raw response board passed; post-skill presentation exceeded 15 s

Log `logs/phase3b3_pet_skill_action_20260908_164100.jsonl`, ActionId
`545efe7efae74f129d3d68f83efed806`, match `M_52debf2f`, source turn 63.
The executor sent one card click, RAM-ACKed all 7/7 directions in 1.184840 s,
and sent exactly one Space at 3.202731 s inside the current
`[3.0, 3.299999952]` Perfect interval. Direction violations were zero;
runtime/RAM returned `PERFECT!`, `qteElapsedMs=3188`, and the exact current
server response correlated.

The v1.0.35 immutable callback-JSON path succeeded on its first live exercise:
it decoded the current `MATCH_SKILL_USE_RES` board at `srvSeq=146` as a strict
8x8/64-cell snapshot, recorded one decoded raw board and zero raw-board
rejections, and the normal provider accepted the transport witness. Publication
still correctly waited for latest ACK ownership and presentation stability.
Nineteen polls reported `latest_acked_batch_not_resolved`; after the long skill
effect the provider reached one `awaiting_stability_confirmation`, then the next
turn entered presentation and ten more polls remained busy until the 15-second
deadline. No stale state was substituted.

This full action therefore remains failed solely at the mandatory fresh
post-state gate and resets B2 to **0/3**. Cumulative full actions are
**9: 2 accepted, 7 failed**. v1.0.36 extends only the harness's bounded
read-only post-state wait to 30 seconds. It does not weaken exact session,
response, ACK/latest, presentation-idle, array/flag stability or semantic-board
validation and cannot emit any further Pet Skill input. Live retry is required.
Offline verification is **266/266 focused** and **1063/1063 full regression
PASS**; compileall and diff check are clean.

### B2 action 2 — Perfect/server pass; response DTO lost board before post-state

Log `logs/phase3b3_pet_skill_action_20260908_161553.jsonl`, ActionId
`904832e6d5aa4af58fd62ad37ec02e87`, match `M_8c1c22c3`, turn 27. The action
used one click, bound sequence `LEFT DOWN LEFT LEFT LEFT UP DOWN`, and
RAM-ACKed 7/7 directions in 1.233585 s. All direction violation counters were
zero. One Space landed at 3.153407 s inside `[3.0, 3.299999952]` with
0.153407/0.146593 s margins. Runtime/RAM reported `PERFECT!` and
`qteElapsedMs=3153`.

The pre-armed tap retained exact current `MATCH_SKILL_USE_RES`, MatchId and
`srvSeq=63` after about 1.2 seconds, with no broad fallback scan. The response
DTO's already pre-parsed `matchPayload` lacked `board`; owner capture retained
only a lower sequence, and 43 polls rejected it as
`latest_acked_batch_not_resolved`. No fresh post-state was fabricated. The
action failed only the mandatory final state gate, is not accepted, and resets
B2 to **0/3**. Cumulative attempts are **8: 2 accepted, 6 failed**.

v1.0.35 uses the second reverse-proven field in the same callback closure:
`ChatService.__c__DisplayClass275_0.json +0x18`. The immutable raw websocket
string is assigned before enqueue, while `message +0x20` is the deserialized
DTO that can be pre-parsed/mutated. After the DTO proves current event and
MatchId, the tap reads the raw string and independently requires exact event,
MatchId, bounded integer `srvSeq`, strict nested 8x8 board and all canonical
cell semantics. The resulting transport witness still needs the existing
exact `_ackedSeqs` and stability gates; bad/missing/stale JSON fails closed.
No target memory write, method call, hook, packet capture or network access was
added. Validation is **148/148 focused** and **1062/1062 full regression PASS**,
with compileall and diff check clean. Live retry remains required.

### LIVE B2 fresh sequence — action 1/3 accepted after v1.0.34

Log `logs/phase3b3_pet_skill_action_20260908_160105.jsonl`, ActionId
`9d7d75488ae04f21b58e670153bf614e`, match `M_aee2377f`, source turn 25.
Preflight proved 523 Mana/250 Rage and the exact current HT7 CardUI/Button.
The action clicked once, bound one fresh QTE with sequence
`LEFT RIGHT RIGHT DOWN UP LEFT LEFT`, and RAM-ACKed 7/7 directions in
1.234155 s. Wrong/missing/duplicate/stale/blind-retry counts were all zero.

One Space at 3.169678 s was inside `[3.0, 3.299999952]`, with
0.169678/0.130322 s start/end margins. Runtime/RAM reported `PERFECT!` and
`qteElapsedMs=3170`. The direct tap retained current
`MATCH_SKILL_USE_RES`, exact MatchId and `srvSeq=59`; correlation passed. Its
board entered the normal transport/ACK gate and a fresh post-skill GameState
was read at turn 26. Net resources were 623 Mana/150 Rage after automatic board
destruction/cascade; gross HT7 cost remains runtime-derived and unchanged.
Final result was `SUCCESS_PERFECT` with one click and one Space. B2 consecutive
progress is **1/3**; no controller remains.

### B2 retry — server correlation passed; blocking fallback lost owner batch

Log `logs/phase3b3_pet_skill_action_20260908_154136.jsonl`, match
`M_8938a3ae`, turn 29. v1.0.33 proved the pre-arm correction: the direct
dispatcher tap retained one exact current `MATCH_SKILL_USE_RES` with
`payload.srvSeq=69`, and correlation passed as
`CURRENT_ENVELOPE_TEMPORAL_SESSION`. The input side was also clean: one card
click, 7/7 RAM-ACKed directions, one Space inside the runtime interval, and
runtime/RAM `PERFECT!`.

This response variant lacked `matchPayload.board`. The observer began its
broad heap fallback after only 0.75 seconds; that scan occupied the main thread
for 1.5 seconds precisely while the response arrived. The separate dispatcher
tap captured the envelope, but the blocked main loop could not sample the
short-lived `MatchService.PendingCombat`/`BoardWsApplier._pendingBatches` root.
Consequently no ACK-attested fresh board was published during the 15-second
post-state window. The action correctly ended
`CORRELATED_PERFECT_BUT_FRESH_POST_STATE_UNAVAILABLE`; it is not accepted.
B2 remains **0/3** and cumulative attempts are **6: 1 accepted, 5 failed**.

v1.0.34 extends the dispatcher-only window from 0.75 to 3.0 seconds. This is
based on the observed approximately one-second response latency and remains
inside the existing 15-second result deadline. It avoids blocking owner-root
sampling during the normal response window; after three seconds the bounded
heap fallback is still available. Captures remain read-only and must satisfy
the exact response correlation, ACK, stability and fresh post-state gates.
Validation is **136/136 focused** and **1058/1058 full regression PASS**, with
compileall and diff check clean. A new live action remains required.

### B2 fresh-sequence retry — QTE Perfect; direct tap startup race proven and fixed

Log `logs/phase3b3_pet_skill_action_20260908_022704.jsonl`, ActionId
`35073db47b56444b8d31a4cbdb023b70`, match `M_2cf12832`, turn 57. The current
HT7 preflight proved 280 Mana/250 Rage. The one card click created a fresh QTE
with `LEFT RIGHT LEFT DOWN LEFT DOWN RIGHT`; 7/7 directions were individually
RAM-ACKed in 1.134015 s with zero wrong/skipped/duplicate/stale/unconfirmed or
blind-retry input. One Space at 3.184344 s was inside the current
`[3.0, 3.299999952]` Perfect interval and runtime/RAM reported
`PERFECT`/`PERFECT!`.

Strict acceptance still failed because no current `MATCH_SKILL_USE_RES` or
fresh post-state was captured. Direct-tap telemetry recorded 2,809 stable root
reads, one rejected/torn sample and 18 callback candidates, but zero skill
responses. This proves the reverse chain itself remained readable; review of
the control handoff found that the polling thread was first created by
`arm()` only after Space. Unity could enqueue and drain the short-lived
callback before its first scheduled sample. The result is not accepted and B2
remains **0/3**; cumulative full-action attempts are
**5: 1 accepted, 4 failed**.

v1.0.33 starts the same read-only direct tap at `PREFLIGHT`, once the exact
one-shot ActionId/MatchId exists and before any card input. It remains armed
through click, QTE directions, Perfect confirmation and result wait. This is
capture timing only: the observer still requires completed-current QTE,
current MatchId, bounded server timestamp, runtime Perfect and a fresh
post-state before success. It adds no target write, hook, method call, network
access or input retry. Focused dispatcher/QTE/action validation is
**135/135 PASS**; full regression is **1057/1057 PASS**, with compileall and
diff check clean. A new live action remains required.

### B2 fresh-sequence retry — runtime Perfect, response still escaped heap rediscovery

Log `logs/phase3b3_pet_skill_action_20260908_014748.jsonl`, ActionId
`c2e8607752ed481b9afbf25dd80c2c43`, match `M_9390287b`, turn 51. Preflight
proved current HT7 and 390 Mana/250 Rage. The single card click created a
fresh QTE with `DOWN RIGHT LEFT RIGHT LEFT RIGHT DOWN`; all 7/7 inputs were
RAM-ACKed in 1.150589 s, with no wrong/skipped/duplicate/stale/unconfirmed or
blind-retry input. Exactly one Space was sent at 3.151488 s, only 0.001488 s
from the current Perfect-window midpoint. Runtime result and displayed RAM
text were `PERFECT`/`PERFECT!`.

The stronger v1.0.31 fallback still missed the response: full scans 1/2/8/16
alternated ascending/descending and took 3.203–3.375 s; all returned zero,
while fast scans remained in 11 learned regions. Without a current server
envelope and fresh post-state, the harness ended
`SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY`. This is not accepted for B2. The
consecutive count remains **0/3** and cumulative B2 full-action attempts are
**4: 1 accepted, 3 failed**.

The b2 reverse closes a narrower ownership path. At OnWebSocketMessage RVA
`0x37C940`, native code writes the deserialized DTO to closure `+0x20`
(`0x37CA8C`) before calling `UnityMainThreadDispatcher.TryEnqueue(Action,bool)`
at `0x37CCEC`. Inspector declares dispatcher static `_executionQueue +0x08`,
instance `_drainBuffer +0x20`, `PendingAction.Action +0x00/Heavy +0x08`, and
closure `ChatService.__c__DisplayClass275_0.message +0x20`. v1.0.32 follows
only these exact owner roots at 2 ms cadence after Space; it checks verified
TypeInfo classes, queue/list size/version and stable before/after roots, then
requires the existing exact ChatMessageDTO class/current MatchId parser. No
target write, method invocation, hook, network access or extra input was added.
The heap scan remains a 0.75-second-delayed fallback.

Offline validation is **54/54 focused**, **1056/1056 full regression**, plus
compileall and diff check PASS. A new live action is required to validate the
dispatcher capture; Phase 3B.3 remains PARTIAL.

### B2 fresh-sequence action 1 — skill/Perfect succeeded, response capture raced

Log `logs/phase3b3_pet_skill_action_20260908_011400.jsonl`, ActionId
`7da3bdfc86b4488c9c8f42789fa6fa03`, match `M_18a6b73a`, turn 35. The
v1.0.30 settled click was accepted and created one fresh HT7 QTE. All 7/7
directions were individually RAM-ACKed in 1.185502 s with zero wrong, skipped,
duplicate, stale, unconfirmed or blind retry. Exactly one Space was sent at
3.154924 s inside the current `[3.0, 3.299999952]` Perfect interval; predicted
and runtime results were `PERFECT`, RAM displayed `PERFECT!`, and the operator
visually confirmed that the Pet Skill executed.

The strict harness did not promote this to a B2 success: its first full result
scan took 2.235 s and found no `MATCH_SKILL_USE_RES`; it then learned ten
ordinary ChatMessageDTO regions and confined all 77 later scans to those old
regions. No current server envelope or fresh post-state was correlated, so it
terminated `SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY` and sent no further input.
The two accepted earlier actions each found the response in their first full
scan, which took 2.579/2.688 s. This isolates a result-allocation scan race,
not a card/QTE/Perfect failure.

v1.0.31 begins direct transient batch capture immediately after the one Space,
always performs two bounded full response-discovery passes in opposite address
orders, and repeats bounded rediscovery every eighth scan while retaining fast
learned-region scans between them. Exact MatchId/QTE correlation, response
board validation, ACK/stability gates and the no-retry input contract are
unchanged. Offline validation: **133/133 focused**, **1047/1047 full regression
PASS**. Because server/post-state evidence is mandatory, B2 remains **0/3**;
cumulative B2 full-action attempts are **3: 1 accepted, 2 failed**.

### B2 action 2 — exact card click sent, game did not create QTE

Log `logs/phase3b3_pet_skill_action_20260908_004701.jsonl`, ActionId
`5a7058210c224218922e669e8aa4f9ab`, match `M_b940154b`, turn 73. The
preflight read a fresh local `590 Mana / 250 Rage`, current HT7 cardId 7,
current native CardUI/Button with `interactable=true`, and a visual point
inside that exact current Button rectangle. It then emitted exactly one normal
Windows click at `18:01:34.584Z`. No current QTE generation appeared in RAM
during the three-second bounded wait, so it correctly stopped without a
second click, direction or Space as
`CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`.

This proves the earlier resource-refresh remediation worked; the failure is
at the UI input acceptance boundary. Code audit found that board swaps already
settled the OS cursor for 60 ms before the button pulse because Unity 1.7.4 can
sample position on a later rendered frame, but single UI/card clicks called
the same primitive with `settle_cursor=false`. v1.0.30 changes only the Pet
Skill invocation to request the existing 60 ms settle, followed by the
existing 75 ms mouse-button hold. It still sends one click only and still
requires a new current QTE in RAM as the acknowledgement. New action telemetry
records the normalized point, settle and hold values. Offline validation:
**132/132 focused**, **1046/1046 full regression PASS**, compileall and diff
check PASS.

This is one failed full-action attempt, therefore the consecutive B2 sequence
resets to **0/3**. Cumulative B2 full-action attempts are **2: 1 success, 1
failure**. A new lobby-start action is required to begin the consecutive
sequence again.

### B2 action 2 diagnostic — resource sample stopped before card-lit frame

Log `logs/phase3b3_pet_skill_action_20260908_000716.jsonl` is not a completed
Pet Skill action and does not advance or reset the consecutive B2 count. The
harness correctly discovered current HT7 cardId 7 and its native
CardUI/Button. The last current samples before the observer stopped advancing
were turn 33 with 157 Mana/40 Rage and turn 34 with the same values. At
`2026-09-07T17:11:54.609Z`, `MatchService.Players` changed during the bounded
local-actor read. The old path invalidated the input-free watch session and
fell back to expensive full-board discovery, so no later resource sample was
recorded. Therefore those old values cannot be used to contradict the
operator's later visible high Mana/Rage/card-lit observation. Automatic input
for this diagnostic attempt was zero.

The exact b2 reverse still declares `Active.PlayerStats.currentMana` at
`+0x34`, `currentPower` at `+0x54`, and the same 16-byte `ObfuscatedInt`
layout/decoder. Native `CardUI.CheckConditionUse` reads these current fields
and compares them with HT7 `CardData.conditionUse=200` and `power=200`; the
200 Mana/200 Rage gross requirement remains evidence-backed and is not
lowered.

v1.0.29 keeps the exact fast-watch session across input-free transient
runtime-singleton and local-actor torn reads, then revalidates control ownership
on the next sample. Clean session/lifecycle loss and every failure after input
remain terminal. Card-click authorization now accepts only a fresh
`Active.playerStatsMap/ObfuscatedInt.Value` resource sample; a torn read never
falls back to an older board resource snapshot. Waiting telemetry records
resource freshness, source and exact read error. Offline validation is
**101/101 focused**, **1045/1045 full regression PASS**, plus compileall PASS.
At that diagnostic point B2 remained **1/3**; the later action-2 failure above
supersedes the consecutive count.

### LIVE B2 progress — action 1/3 accepted

Log `logs/phase3b3_pet_skill_action_20260907_234014.jsonl`, ActionId
`447375a608b642fbaa8fa6a2652ec62b`, match `M_3b575383`, turn 33. One card
click started one fresh seven-direction generation; all 7/7 directions were
RAM-ACKed with zero wrong/duplicate/stale/unconfirmed/blind retry. One Space at
3.170186 s was inside `[3.0, 3.299999952]`; runtime result was `PERFECT`, the
current response correlated, fresh post-state proved turn 34, and terminal was
`SUCCESS_PERFECT`. At that point B2 consecutive count was **1/3**; attempts
**1**, failures **0**. The later action-2 failure above supersedes the
consecutive count.

### LIVE B1 PASS — full automatic HT7 Perfect

Accepted log: `logs/phase3b3_pet_skill_action_20260907_232352.jsonl`.
Action `373ba344a9eb49c29b7a1a5ae561c118` owned match `M_951c8052`,
turn 61 and skillCardId 7. The harness dynamically resolved the current HT7
CardUI/Button and sent exactly one card click. It bound fresh server challenge
`5551834908367274682` with sequence `LEFT, DOWN, RIGHT, RIGHT, DOWN, DOWN, UP`.
All **7/7** directions were individually RAM-ACKed; wrong, missing, duplicate,
stale, unconfirmed and blind-retry counts are all zero.

Directions completed at **1.034103 s**. The current runtime Perfect interval
was `[3.0, 3.299999952]`; Space was sent exactly once at **3.151958 s**, giving
start/end margins **0.151958/0.148042 s** and target error **0.001958 s**.
Predicted and native/runtime results are both `PERFECT`; RAM text is
`PERFECT!`. A current `MATCH_SKILL_USE_RES` envelope was correlated by exact
MatchId plus bounded timestamp. This server envelope does not echo an explicit
quality value, so `server_result` remains null rather than being guessed.

The correlated response supplied a strict **64/64** board and was accepted by
the provider. A fresh post-skill GameState then proved turn **61 -> 62**, local
resources **221/250 -> 21/150**. The current capability's gross requirement/cost
model remains **200 Mana + 200 Rage**; the observed net delta was `-200/-100`
because HT7's board effect can restore Rage. Control then passed to the boss.
Terminal result is
`SUCCESS_PERFECT / CURRENT_GENERATION_PERFECT_AND_POST_STATE_REREAD` with
`cardClicks=1`, `Space=1`; the observer/controller stopped cleanly.

B1 is PASS. Phase 3B.3 remains PARTIAL until B2 demonstrates three consecutive
full automatic actions, followed by B3/B4 reliability/isolation evidence.

### B1 retry 23 — torn native hand đúng giữa hai preflight

Log `logs/phase3b3_pet_skill_action_20260907_223807.jsonl` chứng minh tool
đã thấy đúng HT7 tại turn 47 với `mana=311`, `power=219`, Button
`interactable=true` và geometry ban đầu hợp lệ. Ngay lần đọc độc lập bắt buộc
trước card click, native CardUI fence đổi trong lúc walk
(`pet_skill_control_read_error:native_card_ui: geometry changed during walk`).
Mẫu rách không có card đã được chiếu thành `NO_CAPABILITY`, làm executor cũ
trả `FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING`. Không có input nào được
gửi (`cardClicks=0`, `Space=0`).

v1.0.28 chỉ re-arm trường hợp này khi cả ba điều kiện đều đúng: rejection xảy
ra ở final card preflight, diagnostic hiện tại mang exact
`pet_skill_control_read_error:*`, và tổng input vẫn bằng 0. Capability thực sự
vắng mặt, session/ownership thay đổi, hoặc bất kỳ lỗi nào sau click vẫn
terminal/fail-closed. Event `pet_skill_action_preflight_rearmed` lưu lại exact
native reader reason. Offline validation: **73/73 focused** và **1042/1042 full
regression PASS**; live retry mới vẫn pending.

### B1 retry 22 — input-free control sample làm rơi fast watch

Log `logs/phase3b3_pet_skill_action_20260907_215135.jsonl`: harness bind đúng
combat `M_6ef76bce` và ban đầu refresh đều đặn với trạng thái chưa Fusion.
Sau 21:52:50, worker có khoảng trống gần ba phút trước một refresh kế tiếp,
rồi lại không tạo mẫu mới; operator thấy thẻ sáng nhưng controller vẫn giữ dữ
liệu `pet_skill_not_unlocked_by_fusion` cũ. Automatic card/direction/Space đều
0 và controller đã được Ctrl+C dừng trước khả năng click trễ.

Code audit xác định một đường gây rơi fast watch: `poll_qte_control` gọi
`CombatSessionTracker.observe()` trước khi loại mẫu lifecycle có `read_errors`.
Một mẫu RPM rách vì vậy xóa session đã biết; outer loop lập tức bỏ control-only
path và quay về full provider scan đắt, đúng với gap/CPU runtime. Build cũ không
log exact rejection operand nên loại read error cụ thể của retry 22 vẫn
UNKNOWN; không quy lỗi này cho game hay thẻ.

v1.0.27 kiểm tra lifecycle read errors trước khi mutate session. Input-free
IDLE/PREFLIGHT giữ exact watch session qua một rejected control read và retry
control-only; không fallback sang full provider. Clean non-ACTIVE lifecycle
hoặc `qte_control_session_not_owned` vẫn invalidates ngay, và mọi rejection sau
card click vẫn terminal. Event mới `pet_skill_pre_action_control_read_retry`
ghi exact reason. Live retry mới phải bắt đầu lại từ boss lobby.

### B1 retry 21 — lỗi đọc giữa chuỗi 5/7 và remediation v1.0.26

Log `logs/phase3b3_pet_skill_action_20260907_212858.jsonl`, action
`88dc6e1dbded47038dfd8a77427744e6`: tool click đúng HT7 một lần, bind đúng
server challenge `2407718613707047066` và chuỗi 7 hướng. Bốn hướng đầu được
RAM-ACK; hướng thứ năm `RIGHT` cũng đã được game ghi nhận vì mẫu kế tiếp có
`currentIndex=5`, `correctCount=5` và press-list kết thúc bằng `nutRight`.

Ngay mẫu đó, stable read của MatchService challenge bị exception nhưng code cũ
nuốt chi tiết và biến nó thành `challenge=null/WRONG_SESSION`. Direction
controller vì vậy invalidated ở 5/7; hai hướng cuối do operator nhập và Space
không kịp. Đây không phải bằng chứng challenge ID thực sự bị game clear.

v1.0.26 giữ đúng một mẫu lỗi đọc chỉ khi một generation đã bind và CardUI vẫn
chứng minh cùng session/owner/CardData/object/arrow-list/seed/window, đồng thời
press-list là exact all-correct prefix (`correctCount == currentIndex`) của
chuỗi server đã bind. Nó không tạo generation và không đoán phím; lỗi đọc thứ
hai liên tiếp, prefix sai hoặc identity đổi vẫn fail closed. Exception thật nay
được log bằng `server_qte_challenge_read_rejected`.

Một race độc lập ở final card preflight cũng được sửa: nếu turn/Button đổi sau
initial proof nhưng trước click và tổng input vẫn bằng 0, one-shot quay về chờ
lượt current kế tiếp thay vì tự kết thúc. Mọi lỗi sau bất kỳ input nào vẫn là
terminal. Offline verification tại thời điểm đó: **71/71 focused**, **1040/1040 full regression
PASS**, compileall và diff check PASS. B1 live retry sau remediation vẫn cần;
Phase 3B.3 chưa được nâng thành PASS.

### QTE UI/mechanics addendum — v1.0.25

Native audit of the fresh b2 binary confirms the visible QTE was redesigned
(timeline/needle, Good/Perfect zones, D-pad/modal and arrow feedback), while
arrow/WASD input, Space/Enter confirmation and the Perfect scoring predicate
remain unchanged. The protocol now carries a per-QTE `qteChallengeId` through
MatchService, CardUI and `MATCH_SKILL_USE_RES`. The observer/controller now
requires a current server-provided arrow flag plus nonzero challenge ID before
binding, preserves the already-bound ID across native post-Space clear, and
uses an echoed response ID when available. This is read-only state validation;
no game method or network path is called. See
[QTE timing evidence](phase3b3_qte_timing_evidence.md). Full offline regression
is **1033/1033 PASS**; live B1 is still pending.

## 1.7.4-b2 compatibility closure — 2026-09-07

Fresh evidence under `reverse/reverse_1.7.4-b2` matches the installed
53,603,328-byte `GameAssembly.dll` with SHA-256
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`
and the installed metadata SHA-256
`F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`.
The metadata header is version 110.

The exact new type-info RVAs and changed managed offsets used by Phase 3B.3
have been integrated. The largest relevant movement is the `CardUI` QTE block:
server challenge moves to MatchService `+0x220/+0x228/+0x22C`, while current
directions/index/correct/active move to CardUI `+0x148/+0x150/+0x154/+0x158`,
timing windows to `+0x310..+0x328`, seed to `+0x488`, and QTE presses to
`+0x490`. Board card ownership is now `cardContainer=+0x328`,
`selectedCards=+0x340`, `cardsInHand=+0x348`.

Native live-byte verification found the new Unity component icall slot at RVA
`0x302CEE8` and exact unmarshal gate at RVA `0xBB7CF4`; all 15 existing Unity
native signatures still match. A zero-input read-only lobby smoke attached to
PID 26452/x64 and proved a clean exact `CHINH_PHUC_ROOM` with three selected
cards and one Attack card. **1028/1028 full regression PASS**, compileall and
diff check PASS. No B1 action was launched, so live Phase 3B.3 acceptance is
still pending.

## Superseded runtime blocker 2026-09-07 — game update chưa reverse-verified

Precheck cho B1 retry tiếp theo nhận PID 26452 và đúng executable
`D:\pc\Pokiguard-1.7.4.exe`, nhưng không launch harness. `GameAssembly.dll`
đã đổi sang 53,603,328 bytes / SHA-256
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`;
metadata hiện tại là 15,394,348 bytes / SHA-256
`F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`.
`reverse/redux_compat` hiện có cũ hơn update này và allowlist chỉ xác minh
GameAssembly hash `C67FF9...95A78`.

Giữ fail-closed: không thêm hash mới, không dùng offset/RVA/native signature
cũ và không chạy B1 cho tới khi có reverse dump của exact binary/metadata mới
và revalidate các symbol cần cho Phase 3B.3. Tên EXE vẫn là 1.7.4 không chứng
minh layout không đổi. Blocker lịch sử này nay đã đóng bằng evidence b2 ở trên.

## Latest: B1 retry 19 — controller stall trước resource refresh

Log `logs/phase3b3_pet_skill_action_20260906_213144.jsonl`, MatchId
`M_2a1f03d9`, controller PID 3424. Native control path đã tìm đúng
HT7 slot 4 sau Fusion. Mẫu current cuối được ghi nhận ở turn 7 là Button
`interactable=false`, 260 Mana / 0 Rage, nên gate `INSUFFICIENT_RAGE` lúc đó là
đúng.

Operator sau đó tích đủ resource và tự dùng skill, nhưng log đã ngừng hoàn toàn
từ 21:33:41 trong khi Python/controller còn sống tới lúc kiểm tra khoảng
21:36:30. Vì worker không quay lại vòng mới, mẫu 260/0 chỉ là dữ liệu cũ và
không được dùng để kết luận trạng thái lúc thao tác tay. Controller được Ctrl+C
dừng sạch; automatic card/direction/Space đều **0**. Lần manual này không tính
B1 PASS.

Build cũ chưa có stage marker nên exact synchronous call bị kẹt vẫn UNKNOWN.
Remediation thêm watchdog riêng cho các phase còn có thể phát input. Mỗi
native-card refresh, QTE control poll, provider/runtime/participant/source-pet/
challenge/QTE read và geometry proof có begin/end stage. Nếu một stage vượt
2 giây, input authority bị thu hồi trước mọi delayed click; IDLE one-shot kết
thúc zero input, còn active action abort fail-closed. Result/post-state
read-only sau Space không bị áp ngưỡng này. Không thêm retry click/key/Space.

Validation **145/145 focused**, **1028/1028 full regression**, compileall và
diff check PASS. Cần live retry để vừa xác định stage nếu stall tái diễn, vừa
kiểm chứng full action nếu không tái diễn.

## Latest: B1 retry 18 — thẻ đọc đúng, zero click do preflight scheduling

Log `logs/phase3b3_pet_skill_action_20260906_212126.jsonl`, MatchId
`M_8c2f4e06`, source turn 21. Bounded telemetry đã phân biệt được chính xác
case “thẻ sáng nhưng chưa nhấn”:

- direct native refresh đọc đúng HT7 cardId 7 ở slot 4, đúng current
  CardUI/Button, `interactable=true`, resources 855 Mana / 250 Rage và cost
  200/200;
- geometry proof current hoàn tất trong 156 ms, action đi vào `PREFLIGHT`;
- trước khi gửi input, vòng kế tiếp rơi khỏi control path về full provider
  poll và action fail aggregate guard `ACTIVE_COMBAT_OWNERSHIP_INVALID` sau
  khoảng 0,46 giây;
- card click, direction và Space đều bằng **0**. Không có evidence game từ
  chối click và không có sai card/slot/resource.

Retry 18 chưa log các operand của aggregate guard vì vòng cũ không được đánh
dấu owned; do đó không được khẳng định operand cụ thể là Board publication hay
singleton nào. Điều xác minh được từ code là `PREFLIGHT` đã bị loại khỏi cả
watch/critical route và bắt buộc dùng full provider không cần thiết.

Fix hẹp: trạng thái `PREFLIGHT` vẫn chưa phát input, nên mandatory second
sample nay tiếp tục dùng exact native-hand refresh + `poll_qte_control` của
chính action session. Geometry vẫn được đọc lại trực tiếp và mọi identity,
foreground, turn, lifecycle, resource, Button và inactive-QTE guard vẫn fail
closed. Sau card click, fast QTE/ACK path giữ nguyên; không thêm retry input.
Validation **142/142 focused**, **1025/1025 full regression**, compileall và
diff check PASS. Cần một B1 live retry mới; Phase 3B.3 chưa PASS.

## Latest: B1 retry 17 — zero input, cần telemetry đúng thời điểm thẻ sáng

Log `logs/phase3b3_pet_skill_action_20260906_204900.jsonl`, match
`M_0bd305f9`: capability turn 1 là absent đúng kỳ vọng, nhưng không có
transition mới trước khi match kết thúc ở turn 33. Operator đã thấy thẻ Pet
Skill sáng và một lượt bị miss. Harness gửi zero card/direction/Space và đã
được terminate trước match sau.

Sau trận, MatchService còn giữ evidence read-only: Fusion success tại turn 25;
`LocalFusionSkillCard` đọc được HT7 cardId 7, `ATTACK_LEGEND_`, cost 200/200.
Board/native hand cũ đã bị destroy nên không thể hồi tố xác định refresh không
được gọi hay native validation trả empty trong đúng frame đó. Không đoán.

Build kế tiếp log `pet_skill_control_refresh` khi reason/card state thay đổi và
tối đa mỗi 5 giây: duration, native reason, exact CardState/Button. Telemetry
không thêm scan/input. Validation **142/142 focused**, **1025/1025 full**.

## Latest: B1 retry 16 — thẻ sáng nhưng action không nhận capability

Log `logs/phase3b3_pet_skill_action_20260906_203812.jsonl`, match
`M_3f10490b`. Harness chỉ ghi capability `NO_CAPABILITY` từ turn 1 rồi không
cập nhật kịp khi operator thấy HT7 sáng. Harness được dừng chủ động; card click,
direction và Space đều bằng 0.

Read-only diagnostic trực tiếp trong cùng trận chứng minh:

- Fusion đã success ở turn 13;
- native hand có 5 visible slots;
- HT7 là slot 4, `cardId=7`, `ATTACK_LEGEND_`, đúng Fusion skill CardData;
- CardUI/Button current và interactable;
- native chain đọc trong 166–209 ms.

Lỗi là coupling sai: native card đã được tìm ở đầu provider poll nhưng
`observed_pet_skill_cards` chỉ được gán sau board/ACK batch path. Khi ACK board
chưa resolve, heap scan nặng hoặc early return xảy ra trước bước gán, nên
action gate tiếp tục thấy capability cũ.

Fix mới refresh Pet Skill qua control plane riêng sau khi exact combat session
đã được dựng: Board/Match ownership + Fusion success + native cardsInHand +
CardUI/CardData/Button/live flags. Nó không quét batch, không publish board và
không cấp quyền solver. Live read-only smoke trên turn 54 tìm đúng HT7 trong
208.806 ms. B1 vẫn cần retry sạch từ boss lobby.

## Latest: B1 retry 15 — PERFECT đạt, audit bị foreground guard sai phạm vi

Log `logs/phase3b3_pet_skill_action_20260905_160701.jsonl`, MatchId
`M_e053e2fd`, source turn 23, ActionId
`8f2e5d29a25142949728a0bcbce76f55`.

- Tool tự click đúng một current HT7 card khi resource là 570 Mana / 250 Rage.
- Sequence DOWN LEFT UP RIGHT UP UP LEFT đạt 7/7 RAM ACK trong 1.117173 s;
  không wrong/skipped/duplicate/stale/unconfirmed/blind retry.
- Tool gửi đúng một Space tại 3.168743 s trong current Perfect window; RAM báo
  `PERFECT!`, `qteElapsedMs=3169`; operator xác nhận action đã hoàn tất.
- Sau mọi input, operator chuyển focus để báo kết quả. Harness cũ vẫn áp
  `GAME_NOT_FOREGROUND` cho read-only `WAIT_RESULT`, nên tự invalidated.
- Trước đó scanner không giữ được response: learned scans đang trộn 76 vùng
  ChatMessageDTO/WsCombatBatch, tốn 703–797 ms/vòng; first learned+full scan
  tốn 2.563 s. Không có correlation/post-state nên retry này chưa phải full B1.

Sửa hẹp sau retry 15:

- foreground vẫn bắt buộc tuyệt đối trước card, directions và Space; sau Space
  không còn input nên focus loss chỉ cho phép tiếp tục bounded read-only wait;
- không resend card/key/Space trong mọi trường hợp;
- result scanner chỉ dùng allocation regions đã thực sự chứa ChatMessageDTO;
  batch-only regions không còn làm giảm cadence bắt response;
- khi đã có current message hints, không chạy broad fallback ngay ở scan đầu;
- correlation authority, strict 64-cell response board decoder, exact ACK và
  post-state stability không đổi.

Validation offline: **139/139 focused**, **1022/1022 full regression**,
compileall và diff check PASS. Cần một live retry mới để có đủ
`qte_result_message` -> board offered -> current fresh GameState ->
`SUCCESS_PERFECT`.

## Latest: B1 retry 14 — action/game effect đạt, response DTO bị lỡ

Log `logs/phase3b3_pet_skill_action_20260905_152539.jsonl`, MatchId
`M_53b8ad51`, source turn 23, ActionId
`ac2184fbaff74668bc8863937f37978c`.

- Current HT7 card/Button/geometry hợp lệ, resources 400 Mana / 250 Rage;
  automatic card click **1**.
- Sequence UP DOWN LEFT RIGHT UP DOWN RIGHT: **7/7 sent + RAM-ACK**,
  zero wrong/skipped/duplicate/stale/unconfirmed/blind retry; hoàn tất trong
  **1.185443 s**, headroom 1.814557 s.
- Space **1** tại projected **3.166887 s**, trong current Perfect window;
  runtime `qteElapsedMs=3167`, `PERFECT!`.
- User trực tiếp thấy pet ăn các viên, board cascade/refill và lượt tiếp theo
  hoạt động bình thường. Điều này khớp reverse server-response/render flow và
  chứng minh action/game effect thành công.
- Không `qte_result_message` nào được scanner giữ trong 15 s; harness dừng
  `SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY`, không phát input lần hai. Vì không
  bắt được response DTO nên nhánh strict skill-board mới chưa được live chạy.

Log định vị race trước scanner: sau runtime completion, result wait chuyển sang
full provider trước; 23 provider polls tốn 31–703 ms, median 359 ms, tổng
8.326 s. `MATCH_SKILL_USE_RES` là managed transport object ngắn hạn và có thể
bị reclaim trước khi scanner đọc. Đây là lỗi lịch đọc của observer, không phải
bằng chứng game từ chối skill.

Sửa hẹp sau retry 14:

- giữ control-only owner/session/actor/connection poll trong toàn bộ
  `WAIT_RESULT`, kể cả sau khi RAM đã báo completion;
- trong completed-result wait, gọi `capture_transient_batches()` để giữ
  `MatchService.PendingCombat` và current owner queue trực tiếp; không heap
  scan, không tự ACK/publish;
- result scan đầu tiên ưu tiên learned regions rồi có bounded full fallback;
  tiếp tục learned scan nhanh và ghi `qte_result_scan` timing/count;
- chỉ sau exact response correlation mới trở về full provider cho post-state;
- strict skill response board + exact `_ackedSeqs` + render/stability gates từ
  retry 13 giữ nguyên. Không dùng visible effect thay server correlation, không
  resend card/key/Space.

Validation: **109/109 focused**, **1020/1020 full regression**, compileall và
diff check PASS. Cần một B1 live mới để xác nhận response capture + board offer
+ fresh GameState + `SUCCESS_PERFECT`.

## Latest: B1 retry 13 — QTE/correlation đạt, response board bị decoder bỏ qua

Log `logs/phase3b3_pet_skill_action_20260905_144943.jsonl`, MatchId
`M_d3106c16`, source turn 19, ActionId
`ceb63ff8b7534390a70fed3a4e7e60f5`.

- Exact HT7 current CardUI/Button/geometry hợp lệ; resource 275 Mana / 200 Rage.
  Automatic card click **1**.
- Sequence 7/7 được gửi và RAM-ACK, zero wrong/skipped/duplicate/stale/
  unconfirmed/blind retry. Directions hoàn tất trong **1.159891 s**.
- Space **1** tại projected **3.163413 s**, đúng current runtime Perfect window
  `[3.000000,3.299999952]`; runtime `qteElapsedMs=3163`, `PERFECT!`.
- `pet_skill_qte_cleanup_wait` giữ nguyên ownership và không resend. Current
  `MATCH_SKILL_USE_RES` được correlate bằng exact MatchId + unique completed
  QTE + bounded server timestamp.
- Sau correlation, 37 full-provider polls trong 15 giây không xuất bản state:
  2 lần `awaiting_direct_owner_batch_capture`, 35 lần
  `latest_acked_batch_not_resolved`. Cùng Board/Match session vẫn active và
  turn tiến 19 -> 20 -> 21 -> 22; đây không còn là animation đơn thuần.

Root cause đã xác minh từ native 1.7.4: `HandleMatchSkillUseRes` RVA
`0x337B50` chuyển đúng DTO vào `HandleResEnvelope` RVA `0x338540`;
`HandleResEnvelope` đọc `matchPayload +0xC8`, chạy `ParseOps`,
`ApplyStateDelta`, rồi gọi `ParseCombatBatch` RVA `0x338AE0`. Batch có
`srvSeq +0x10` và `BoardCellDTO[][] board +0x38`. Tuy nhiên decoder transport
của tool chỉ whitelist `MATCH_START/MATCH_MOVE_RES`, còn provider chỉ nhận
`MATCH_MOVE_RES`. Vì vậy response skill đã correlate nhưng board snapshot cùng
response chưa từng được đưa vào exact ACK gate.

Remediation hẹp:

- strict transport decoder nhận thêm response đi qua cùng verified envelope:
  `MATCH_CARD_USE_RES` và `MATCH_SKILL_USE_RES`;
- observer chỉ decode/offer skill board **sau exact current correlation**;
- payload bắt buộc có bounded `srvSeq`, đúng 8x8/64 unique coordinates, known
  tags và multiplier hợp lệ;
- provider vẫn bắt buộc exact MatchId/session, cùng sequence trong
  `MatchService._ackedSeqs`, Dot multiplier/render convergence, presentation
  idle và stability confirmations;
- payload thiếu/sai, type-info thiếu hoặc ACK không khớp đều fail closed. Không
  tái dùng board cũ, không coi bare ACK là board, không thêm input/retry.

Log live kế tiếp phải có `qte_result_board_snapshot_offered` với
`completeCells=64`, `accepted=true`, rồi một fresh post-state và
`SUCCESS_PERFECT`. Validation offline: **109/109 focused**, **1020/1020 full
regression**, compileall và diff check PASS. Retry 13 vẫn không tính full B1.

## Latest: B1 retry 12 — PERFECT đạt, server response chậm hơn 5 giây

Log `logs/phase3b3_pet_skill_action_20260905_144152.jsonl`, MatchId
`M_e40051dc`, source local turn 15, ActionId
`9679da7994714a67a0f46c1316d9de09`.

- Current HT7 capability/card/Button/geometry hợp lệ; resources trước action
  260 Mana / 225 Rage, effective cost 200/200. Automatic card click **1**.
- Sequence DOWN DOWN DOWN DOWN UP RIGHT RIGHT: **7/7 sent và RAM-ACK**;
  wrong/skipped/duplicate/stale/unconfirmed/blind retry đều **0**. Directions
  hoàn tất elapsed **1.204005 s**, còn **1.795995 s** tới Perfect start.
- Space **1** tại projected elapsed **3.157258 s**, trong current runtime
  window `[3.000000, 3.299999952]`; margins 157.258/142.742 ms. Runtime actual
  `qteElapsedMs=3174`, RAM result `PERFECT!`. User báo QTE đã hoàn tất.
- Sau Space, full-provider giữ đúng current combat ownership nhưng chưa tìm
  thấy current server response/batch trong default 5 s. Harness dừng
  `SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY`: không server correlation, không
  post-state, không thêm Space/card/direction. Retry 11 đã cho thấy cùng loại
  response có thể tới sau khoảng **6.025 s**, nên 5 s là giới hạn ngắn hơn
  latency đã quan sát, không phải bằng chứng input bị game bỏ.

Remediation tối thiểu: result wait sau Space tăng bounded **5 -> 15 s**, cùng
hard upper bound đã có; post-state wait vẫn 15 s. Cả hai chỉ đọc RAM, không
retry Space/card, không reset action/QTE và không giả kết quả. Focused
**102/102**, full regression **1018/1018**, compileall và diff check PASS.
Retry 12 không được tính full B1; cần một live retry mới để có cả correlation
và fresh post-skill GameState.

## Latest: B1 retry 11 — PERFECT/correlation đạt, 4 giây chưa đủ cho post-state

Log `logs/phase3b3_pet_skill_action_20260905_005856.jsonl`, MatchId
`M_1bc9ed56`, source local turn 23, ActionId
`596321bcb0454a5ab2bf03ff1fcd77ac`.

- HT7 current capability/card/Button/geometry đều được chứng minh; effective
  cost 200 Mana / 200 Rage; resources trước action 625/250.
- Automatic card click **1**. Sequence UP LEFT DOWN RIGHT LEFT LEFT RIGHT:
  **7/7 sent và RAM-ACK**, wrong/skipped/duplicate/stale/unconfirmed/blind
  retry đều **0**.
- Directions hoàn tất tại elapsed **1.148706 s**, còn **1.851294 s** tới đầu
  current Perfect window. Space **1** tại projected elapsed **3.181947 s**
  trong runtime-derived `[3.000000, 3.299999952]`; runtime QTE elapsed
  **3166 ms**, RAM result `PERFECT!`; user cũng xác nhận `perfect`.
- Cleanup path mới đã chạy đúng: `pet_skill_qte_cleanup_wait`, không phát sinh
  card/key/Space lần hai. Server response sau đó được correlate CURRENT qua
  `CURRENT_ENVELOPE_TEMPORAL_SESSION`: exact MatchId + unique completed QTE +
  bounded response timestamp. Build này không echo timing enum trong envelope
  (`serverResult=null`), nên không được ghi giả một server enum.
- Correlated resource observation 625/250 -> 425/250: Mana delta -200 khớp
  gross cost; Rage net 0 do skill board effect có thể hoàn tài nguyên, vì vậy
  attribution giữ `AMBIGUOUS`. Turn được quan sát 23/local -> 24/boss trong
  khoảng response/effect; không đủ để quy kết riêng rằng skill tiêu thụ turn.
- Sau correlation, 23 lần full-provider poll trong **4.157 s** đều còn
  `presentation_busy_or_batch_pending`; chưa có fresh board/GameState. Harness
  fail `CORRELATED_PERFECT_BUT_FRESH_POST_STATE_UNAVAILABLE`. Đây không phải
  QTE/gameplay failure, nhưng vẫn **chưa đủ** tiêu chuẩn full B1 vì prompt bắt
  buộc fresh post-skill GameState.

Remediation tối thiểu: default post-state reread wait tăng từ 4 lên **15 s**,
đúng hard upper bound đã có. Đây chỉ là bounded read-only wait sau correlated
result: không click, không Arrow, không Space, không reset deadline và không
chấp nhận stale board. Test mới khóa CLI default; timeout path vẫn fail closed
và giữ đúng một Space. Validation sau sửa: **102/102 focused**, **1018/1018
full regression**, compileall và diff check PASS. Cần một live B1 mới để chứng
minh board xuất bản trong cửa sổ này; chưa tự chạy B2.

## Latest: B1 retry 10 — thẻ đọc đúng, final geometry preflight bị loại

Log `logs/phase3b3_pet_skill_action_20260905_003531.jsonl`.

- M_d126ec41: user báo thua, log không thấy skill capability, chưa invoke action;
  harness còn chờ nên user được tiếp tục trận mới cùng invocation chưa dùng.
- M_854938f2 / epoch 2: đã phát hiện HT7, exact current CardUI/CardData/Button,
  effective cost 200/200, Mana/Rage 760/250. Native hand có 5 thẻ.
- Các lượt chờ có cả LOCAL_TURN_NOT_ACTIONABLE, PET_SKILL_BUTTON_NOT_ACTIONABLE,
  CARD_CHANGED_BEFORE_GEOMETRY_PROOF, geometry changed during read/walk. Không
  được quy toàn bộ khoảng chờ cho thiếu thẻ/Mana hoặc cho game lag.
- Local turn 29, ActionId `bf8e410b76bf4b4f97347584bd2355c3`: initial preflight
  125 ms hợp lệ, final proof absent sau 16 ms. Reason cuối
  `FINAL_CARD_PET_SKILL_BUTTON_GEOMETRY_UNKNOWN`; **card/direction/Space = 0**.
  Log action cũ thiếu underlying geometry reason, nên exact branch của final
  rejection là UNKNOWN; không khẳng định ngược rằng nó chắc chắn là job fence.
- Observer dừng 17:45:33.714 UTC, PID 2852 / terminal 92604 exit 1. Không có
  QTE nên terminal-cleanup fix của retry 9 chưa được live kiểm chứng ở đây.

### Trace read-only và fix sau retry 10

Khi combat còn tồn tại, native probe cùng game PID 26436 đọc 12/12 hand ổn định
(95.57–143.68 ms). Batch tiếp 48 lần: 42 thành công, 2 pending transform job,
1 geometry changed during read, 3 geometry changed during walk. Các mutation
ghi được là shared Transform data+0 job field đổi giữa zero/nonzero trong lúc
đọc; không phải chứng cứ sai CardUI hay tọa độ lệch. Native getter đã reverse
kiểm tra job field trước khi đọc TRS; không được bỏ fence.

- Tách `NativeGeometryBusyError` (dirty/job-in-flight/read-change) khỏi invalid
  index/layout/owner/signature. Job field chỉ so sánh zero như native, không
  dereference opaque job value như pointer.
- Geometry proof trước click được **tối đa 2 whole-hand reads** khi gặp typed
  busy error. Mỗi lần xóa per-read caches/fences; không tái dùng phần đọc dang
  dở. Unsupported/invalid evidence không retry; persistent busy vẫn no click.
- CardData/Button/usability được kiểm tra lại sau read; final frozen geometry
  và cửa sổ vẫn phải khớp. Không restamp sample; thời gian cả hai read nằm trong
  age limit 350 ms cũ. Retry quá chậm vẫn bị loại, không cố click.
- `_geometry_proof` không yêu cầu slot từ lần provider đọc trước: current
  native hand tự chứng minh slot/rect. Chỉ cập nhật slot diagnostics của local
  observation từ proof cùng exact identity; không sửa cached CardState, không
  thay đổi resource/owner authority. Không đoán slot hoặc click theo slot index.
- Waiting/action/result events thêm `geometryReason`, `geometryReadAttempts`,
  `geometryRetryReason`; sửa reason khi early identity/capture-size reject.

Validation: **1017/1017 regression PASS**, **101/101 native/action/control PASS**,
9 test mới: opaque pending job, invalid index không transient, whole reread
bỏ partial cache, busy->fresh proof, max 2 reads, invalid không retry, CardData
đổi vẫn reject, missing provider slot được chứng minh mới, total retry age
không reset + zero click + final reason telemetry. Compileall/diff check PASS.
Probe sau sửa không còn current Board nên **chưa đo/live-accept** activation
retry path; zero input. Tool đã dừng; không tự restart, commit/push/package.

## B1 retry 9 — PERFECT thật, cleanup bị hiểu nhầm thành stale QTE

Log `logs/phase3b3_pet_skill_action_20260905_001953.jsonl`, MatchId `M_2bee7569`,
source local turn 49, ActionId `ffe5caed04c44db19cb6489868409bb2`.
User xác nhận `perfect`. Harness PID 18952 / terminal 5239 đã kết thúc exit 1.

- Automatic card click **1**; HT7 effective cost 200/200, trước action 280 Mana,
  230 Rage. QTE generation 1, bind latency 1.297 s từ click.
- Sequence DOWN DOWN RIGHT UP RIGHT RIGHT UP: **7/7 sent/ACK**, wrong/skipped/
  duplicate/stale/unconfirmed/blind retry **0**.
- Directions done elapsed **1.244157 s**, headroom trước Perfect **1.755843 s**.
- Automatic Space **1**, projected send elapsed **3.163942 s**, midpoint error
  +13.942 ms. Projected start/end margins 163.942/136.058 ms.
- Runtime actual elapsed **3181 ms** (rounded), `PERFECT!`, predicted PERFECT;
  runtime margins khoảng 181/119 ms trong current [3000,3300] ms window.
  Không đồng nhất runtime elapsed với projected send timestamp.
- 54 critical samples: provider median **15.5 ms**, cycle median **31 ms**,
  max cycle **78 ms**. Không có initialization-wait event; nhánh sequence rỗng
  của retry 8 chưa có live coverage trong lần này.
- Line 318 lúc 17:26:23.724 UTC: `COMPLETED_CURRENT`, CardUI active=true,
  finished=true, 7/7, PERFECT. Line 319 full provider không publish board
  (`latest_acked_batch_not_resolved`) nhưng current control ACTIVE/session/actor/
  turn/connection hợp lệ. Fix fresh-control handoff đã vượt qua đoạn trước.
- Line 324 lúc 17:26:24.196 UTC: cùng raw CardUI/CardData/Button/Board, 7/7,
  finished=true, elapsed/text giữ nguyên, chỉ active=false. Tracker đúng khi
  trả INACTIVE/identity=None; action sai khi coi cleanup này là đổi generation.
  `_step_result` abort `QTE_GENERATION_CHANGED_OR_STALE` ~0.52 s sau Space.
- `server_response_correlated=false`, post_state=null, completedQtes=0.
  Không gọi full B1 PASS dù cả user và RAM xác nhận Perfect; không loại mẫu
  này khỏi lịch sử thất bại ở result finalization.

### Remediation sau retry 9

Đã dựng regression qua chính `QteObserver` để tạo INACTIVE snapshot như
production, không giữ giả identity/completed/result trong fixture. Test tái
hiện đúng `QTE_GENERATION_CHANGED_OR_STALE` trước khi sửa.

- Executor lưu fact **đã quan sát completion đúng bound generation** sau
  Space. Fact này chỉ phục vụ result wait/routing, không phải current QTE
  hay authority phát input.
- Chỉ trong WAIT_RESULT, sau Space một lần + completion đã xác minh, nếu
  snapshot đúng INACTIVE, cùng session và current clicked CardUI/CardData/
  Button/skill/actor thì chờ read-only đến deadline gốc. Không reset 5 s result
  timeout, không tạo result giả, không click/phím/Space mới. Một log
  `pet_skill_qte_cleanup_wait` ghi rõ đang chờ correlated response.
- Mất completion flag do cleanup không làm routing quay về fast control-only;
  tiếp tục full provider + fresh control để thu result và board.
- Chưa quan sát completion, stale/unknown/đổi QTE, sai owner/session/card,
  Emergency Stop/foreground/lifecycle vẫn fail closed. Correlated result phải
  qua checks cũ và cần full board đọc sau correlation trước SUCCESS_PERFECT.

**1008/1008 full regression PASS; 68/68 focused PASS**, 6 test mới: production
inactive projection, delayed correlation + later board, original timeout,
missing bound completion, new/stale generation, current identity/stop gates.
Compileall và diff check PASS. Không sửa direction/Space timing, BASIC hay
game files; không tự restart, chưa commit/push/package. Cần một B1 mới để xác
nhận đoạn cuối; server response và post-skill state của retry 9 vẫn UNKNOWN.

## B1 retry 8 — thiếu server sequence lúc khởi tạo, không gửi hướng

Log `logs/phase3b3_pet_skill_action_20260904_231540.jsonl`, match `M_04c99254`,
local turn 41, ActionId `b2639ee4ace941c898ec97f32d8e7564`.

- Line 190–191: card click **1**, rồi WAIT_QTE_GENERATION lúc 16:27:50.334 UTC.
  HT7 effective cost 200/200, trước action Mana/Rage 265/240.
- Line 196/198: lúc 16:27:51.875 UTC, CardUI active/unfinished, index 0,
  correctCount 0, presses rỗng, timeLeft normalized 1.0. Current server
  challenge đúng MatchId nhưng `sequence_list_address=null`, sequence rỗng.
  Tracker trả `SEQUENCE_UNAVAILABLE`; executor lập tức FAILED với
  `QTE_NOT_CURRENT_OR_AMBIGUOUS` thay vì chờ hết generation deadline hiện có.
- **Directions 0, Space 0**, generation chưa bind, không server correlation,
  không post-state. Không có bằng chứng phím tự động gửi sớm rồi game mất input.
- Một critical poll: provider 16 ms, cycle 31 ms, sample age 15 ms. Không đủ
  dữ liệu để kết luận FPS/ping là nguyên nhân server sequence thiếu; thời điểm
  sequence xuất hiện sau đó là UNKNOWN vì observer đã dừng.
- User thấy BAD; đây là **user-reported BAD**, chưa có runtime/server result
  correlated trong log này. Không bỏ lần thất bại khỏi lịch sử acceptance.
- Line 200: observer dừng 16:27:51.901 UTC; harness PID 6848 đã kết thúc.
  Startup riêng `231435` trước đó dừng ở lobby với zero input, không tính là
  một skill action khác. Không tự restart sau lượt fix này.

### Sửa hẹp sau retry 8

`PetSkillActionExecutor.WAIT_QTE_GENERATION` nay chờ read-only khi tracker xác
nhận `SEQUENCE_UNAVAILABLE` trước bind, đúng current session/actor/source turn
và exact clicked CardUI/CardData/Button. Giữ nguyên deadline gốc (default 3 s),
không reset deadline mỗi poll. Log một lần
`pet_skill_qte_initialization_wait / CURRENT_CARD_WAITING_FOR_SERVER_SEQUENCE`.

Khi có sequence, vẫn phải vượt toàn bộ fresh-generation checks rồi mới gửi
từng hướng với RAM ACK. Không dùng local/fallback arrows; không đoán FPS ổn
định, không fixed sleep, không click thẻ hoặc resend hướng để thử vận may.
Sequence mất sau bind, sai owner/card/session, sample cũ, midstream/ambiguous
vẫn fail closed. Deadline hết vẫn `CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`.
Nhịp fast-control và Perfect scheduler đã đạt Perfect ở retry 7 không đổi.

**1002/1002 full regression PASS; focused action/control 62/62 PASS**.
5 test mới: sequence đến trễ rồi mới bind/send; deadline không bị kéo dài;
invalid evidence khác không được đổi thành wait; exact clicked identity/turn/
actor bắt buộc; mất sequence sau bind vẫn stop. Compileall và diff check PASS.
Đây là fix offline, không bảo đảm game lag nặng vẫn đạt Perfect. Cần B1 mới
kiểm chứng cả delayed initialization và result/post-state handoff; chưa B2/B3.

Native initialization-wait evidence được bổ sung trong
[QTE timing evidence](phase3b3_qte_timing_evidence.md), không thay đổi game.

## Post-QTE handoff remediation sau retry 7

Đã sửa contract trong `tools/pet_qte_observer.py` và
`tools/pet_skill_action.py`, không thay đổi hướng/Space đã đạt Perfect:

- Sau runtime completion, vẫn chạy full provider để lấy board, nhưng đọc thêm
  current control-only evidence để chứng minh lifecycle/session/actor/turn/
  connection. Provider không publish board trong cascade không còn tự đồng
  nghĩa mất ownership. Không dùng last_state cũ làm authority.
- Nếu control read thất bại hoặc full GameState thuộc session/lifecycle khác,
  fail closed. GameState và cờ publish nguyên bản không bị relabel/ép publish.
- Correlated server response chỉ chuyển sang POST_SKILL_REREAD; không đánh dấu
  board đã đọc trước scan response là một lần reread mới. Có timestamp barrier
  để cả callback tiếp theo trong cùng vòng observer cũng không thể đóng nhầm.
  Phải có full GameState của lượt poll sau; thiếu thì chờ bounded timeout.
- Sau Space không có thêm card click/phím/Space. Result và reread timeout giữ
  nguyên, không mở farm/BASIC. Log `post_qte_provider_poll` và
  `qte_ownership_rejected` giữ reason/session/control/root diagnostics.
- Reproduction test dựng đúng contract thiếu combat_lifecycle/no board sau
  clear last_state. Đây là lỗi code tái hiện được; exact branch của retry 7
  vẫn không thể bổ sung ngược vào log cũ.

**997/997 full regression PASS**, 7 test mới (post-QTE routing, zero resend,
real owner loss, wrong-session/lobby snapshot, original publication, delayed
fresh reread, timeout). Live B1 mới vẫn cần chứng minh server correlation và
fresh post-state; không retroactively đổi retry 7 thành full PASS.

## B1 retry 7 — automatic PERFECT, chưa full-action PASS

Log `logs/phase3b3_pet_skill_action_20260904_223027.jsonl`, match `M_448d6389`,
local turn 79. User trực tiếp xác nhận `perfect`.

- Automatic card click: **1**; directions sent/confirmed: **7/7**.
- Wrong/skipped/duplicate/stale/unconfirmed/blind retry: **0**.
- Directions complete elapsed **1.378084 s**; headroom đến Perfect start
  **1.621916 s**. Sequence: DOWN UP RIGHT UP RIGHT LEFT LEFT.
- Automatic Space: **1**; projected send elapsed **3.171087 s**, cách midpoint
  +21.087 ms. Runtime actual final elapsed **3156 ms**, predicted/runtime
  `PERFECT`, user thấy Perfect. Không đồng nhất projected và actual elapsed.
- 51 critical samples: provider median **15 ms**, cycle median **31 ms**,
  maximum cycle **79 ms**. Lỗi nhịp input chậm retry 6 không tái diễn.
- Harness vẫn **INVALIDATED / ACTIVE_COMBAT_OWNERSHIP_INVALID** ở
  15:40:10.110 UTC, sau runtime completion 15:40:09.596 UTC.
  `server_response_correlated=false`, `post_state=null`, completedQtes=0.
- PID 27228 đã dừng, terminal 65291 exit 1; không có Python/controller còn chạy.

Chưa nâng B1/B2 hay cả phase thành PASS STRONG. Điểm cần kiểm tra là handoff
từ control-only sang full provider sau QTE: last_state đã clear, trong khi
các normal ProviderPoll không publish board có thể thiếu combat_lifecycle;
observer không có direct_session và hủy trước scan result. Đây là điểm thiếu
trong contract thấy trực tiếp từ code. Log không ghi poll reason/root diagnostics
tại invalidation nên chưa xác định exact failing branch của live sample.
Phải phân biệt thiếu board publication với mất ownership thật bằng fresh
control evidence, không bỏ guard hay dùng stale GameState. Lượt review này
chỉ đọc log/code và ghi evidence; chưa sửa code hay restart.

## History: retry 6 và QTE timing remediation

Retry 6 (`phase3b3_pet_skill_action_20260904_220109.jsonl`) đã click thẻ đúng,
nhưng chỉ đạt 5/7 trước hết thời gian, game hiện BAD, zero automated Space.
Nhịp full provider poll chèn giữa mỗi direction/ACK gây regression so với 3B.2.
Đã tách control-only polling, giữ closed-loop key/ACK, xác nhận theo runtime
Perfect window, thêm per-key và per-poll timing, giữ summary cả khi fail.
Reverse/deadline, thay đổi và giới hạn xác minh được ghi đầy đủ ở
[QTE timing evidence](phase3b3_qte_timing_evidence.md). Harness đã dừng;
không tự restart trong lượt fix này. B1 không được tính PASS.

Validation mới nhất: **990/990 regression PASS**, focused action/control
**50/50 PASS**, read-only observer smoke sạch ở lobby. Chưa đo được nhịp
control-only trong active live QTE tại thời điểm đó. Retry 7 phía trên đã bổ
sung runtime Perfect/timing; full-action acceptance vẫn thiếu finalization.

Không được phân loại Phase 3B.3 là PASS/PASS STRONG trước live acceptance.

## Implementation hiện có (chưa live-accept)

- `PetSkillActionExecutor` là state machine one-shot, có immutable ActionId và
  hai preflight tách biệt trước card click.
- Pet Skill CardUI/Button được tìm từ CURRENT Board.cardsInHand qua native
  components và scripting handle đã reverse; vị trí lấy từ current RectTransform.
  Không dùng baseline trước tiến hóa, card ID/type, count hay vị trí trái/phải
  để suy ra skill slot. Chi tiết: [native evidence](phase3b3_native_card_evidence.md).
- Gross cost lấy từ current `PetSkillCapability`; HT7/HT2 fixture vẫn lần lượt
  là `200/200` và `200/150`, không có global Legendary constant.
- Card click tối đa một lần, không retry mù khi QTE chưa xuất hiện.
- Fresh QTE bắt buộc bind cùng MatchId/session/actor/turn/skillCardId rồi tái sử
  dụng closed-loop direction executor Phase 3B.2.
- Space chỉ có authority sau khi RAM chứng minh toàn bộ direction hoàn tất; thời
  điểm là midpoint của `perfect_start/perfect_end` hiện tại, dựa trên elapsed
  runtime cộng monotonic sample age, không fixed sleep.
- Final Space preflight kiểm tra lại process/HWND, foreground, session,
  generation, skill, actor/lượt, completion, runtime window và stop gates.
- Result phải là predicted PERFECT + direct RAM PERFECT + current-generation
  server correlation; response có timing echo thì echo cũng phải PERFECT.
- Sau correlation cần một fresh GameState trước khi COMPLETE; executor không
  phát SWAP/CAST/EVOLVE/Pet Skill tiếp theo.
- Controlled harness giữ shared `AutomationControllerLease` và chỉ chạy khi có
  `--execute-once`.

## Offline evidence

```text
focused native + action + screenshot + autonomous + provider: 221/221 PASS
native ownership/geometry: 24/24 PASS
full regression: 976/976 PASS
compileall: PASS
git diff --check: PASS
```

Các fixture bao phủ valid full path, two-stage card preflight, resource/card
change, missing/ambiguous capability, dynamic card slot, stale/midstream QTE,
direction ACK failure, generation/session change, runtime timing windows khác
nhau, delayed read, exactly-one Space, delayed/missing/stale/GOOD/BAD result,
post-state reread và Emergency Stop tại các input boundary. Native fixtures thêm
new wrapper, shuffled order, five visible objects vs explicitly inactive Fusion,
foreign Button/container, signature mismatch, stale handle, unknown active,
dirty/overlapping/job-pending/changing geometry và Canvas mode. Thêm fixture
combat root Canvas có scene Transform cha, nested Canvas khác raw mode và
toàn bộ hierarchy/scale/rect được đọc trong retry 4.

## Live B1 attempt 1 — rejected, zero automated input

Log: `logs/phase3b3_pet_skill_action_20260904_173754.jsonl`

- Harness observed the combat and the user successfully evolved to HT7.
- Before the user's manual skill click, capability remained
  `CURRENT_PET_SKILL_CAPABILITY_MISSING`; automated card click/Arrow/Space were
  all zero.
- Only after the manual click created `CardUI.ActiveDotSkillCard` did the
  observer see HT7 with current runtime cost `200 Mana / 200 Rage`. At that
  point the Button was correctly non-actionable because QTE was already active.
- The manual QTE was observed as 7/7 correct and runtime `PERFECT`, but it is
  not Phase 3B.3 acceptance evidence because the user supplied the input.

**Correction:** kết luận cũ “LocalFusionSkillCard luôn null trước activation”
không đủ bằng chứng và đã được rút lại. Retry 3 đọc được pointer khác null
TRƯỚC manual activation. Điều đã chứng minh là reader bỏ sót CardUI mới.
Remediation dùng owner-anchor/ba lượt scan trước đây KHÔNG đủ coverage; nay
đã thay bằng đường native trực tiếp sau tiến hóa. Không đoán skill slot.

## Live B1 retry 1 — rejected, zero automated input

Log: `logs/phase3b3_pet_skill_action_20260904_180105.jsonl`

The durable Fusion-success gate worked, but the pre-click skill wrapper still
did not enter the validated candidate set. A concurrent read-only probe while
the visible HT7 card was lit proved:

```text
Board                  = 0x0000023B7F915540
HT7 CardUI             = 0x0000023B7F915A80
CardUI.cardId/type     = 7 / ATTACK_LEGEND_
Button                 = current + interactable
Board/Active ownership = current + validated
```

The wrapper is adjacent to the current Board in the Board allocation, while
the prior owner scan was anchored only to `Board.cardsInHand` GameObjects in
other allocations. A bounded scan with the exact current Board added as an
anchor found the sole HT7 CardUI after reading 671,744 bytes; it did not need a
process-wide scan. The provider now includes the current Board allocation only
for `CardUI.board` discovery and still applies exact class/Board/Active/native
object/CardData/Button validation. Retry 1 produced zero automated card click,
Arrow and Space. Đây chỉ là một allocation arrangement, không phải guarantee
qua các trận; đường native mới không phụ thuộc wrapper ở gần Board.

## Live B1 retry 2 và 3 — không được tính PASS

Logs `183955` (`M_da79f665`) và `185520` (`M_83acee9f`) ngày 2026-09-04 đều
không gửi automatic skill click/Arrow/Space. User dùng skill bằng tay. Retry 3
hết timeout lúc 19:25:22, không tiêu thụ one-shot invocation.

Probe read-only trong retry 3 chứng minh CardUI HT7 ở committed region 69,632
bytes, allocation khác các owner-anchor đang quét. Năm GameObject/RectTransform
tách biệt cũng bác bỏ giả định “5 object nhưng giữ nguyên 4 ô”. Đã gỡ mapping
skill vào ô Fusion cũ và các test synthetic từng khẳng định mapping đó đúng.

## Live B1 retry 4 — lỗi root Canvas đã xác định và sửa

Log: `logs/phase3b3_pet_skill_action_20260904_210747.jsonl`, PID 26456,
MatchId `M_bfb931a0`. Đây là harness thứ năm không có auto activation;
card click / Arrow / Space tự động đều **0**.

- Trước thao tác tay, `CURRENT_PET_SKILL_CAPABILITY_MISSING` đi kèm
  `native_card_ui: non-RectTransform geometry`. Reader đã đi qua root Canvas
  của trận và cố đọc object cha `UnityEngine.Transform` như RectTransform.
  Exception làm mất native hand/candidates, không phải chứng cứ thiếu thẻ.
- Manual activation ở lượt 59: HT7 id 7 / `ATTACK_LEGEND_`, Mana/Rage
  `422/250`, cost `200/200`; QTE 7/7 đúng, runtime PERFECT, có current-envelope
  correlation. Sau đó `222/50`. Các kết quả này là MANUAL, không tính B1 PASS.
- Đã dừng harness PID 22832 bằng Ctrl+C trước khi kiểm tra/sửa, không tự restart.
- Sửa điểm dừng theo root Canvas (`parentCanvas == NULL`) chứ không phải
  `Transform.parent == NULL`. Nested Canvas dùng renderMode của root; không
  áp dụng camera/world TRS của root khi quy đổi tọa độ trong Canvas.
- Direct read-only probe sau sửa đọc được cả 5 thẻ/rect, HT7 CardUI và Button
  đúng owner; cold sample **177.02 ms**. Tại sample này Button HT7 không
  interactable sau lần dùng tay, nên đây không phải click authorization.
- Observer read-only tiếp theo:
  `logs/phase3b3_b1_retry4_shadow_after_canvas_fix_20260904.jsonl`.
  Không thấy capability mới trong 5 giây. Kiểm tra provider ngay sau đó:
  `Board.is_game_over=True`, `poll.reason=local_match_end_flag`, native discovery
  `not_requested`. Không tắt terminal gate để ép thử trên trận đã kết thúc.
- Bản sửa có direct-native live evidence và offline regression; production
  discovery trước activation + full auto action trong trận mới còn PENDING.

## Live B1 retry 5 — đọc được thẻ trước activation, preflight quá chậm

Log: `logs/phase3b3_pet_skill_action_20260904_213919.jsonl`, game PID 26436,
harness PID 26944, MatchId `M_cf7e3c5a`. Attach từ lobby sau restart process;
native code signatures PASS. Đây là lần thứ sáu chưa có full-auto success.

- Turn 57, `Mana=255`, `Rage=250`: current HT7 id 7, effective cost `200/200`,
  exact Board/Active/CardData/CardUI/Button; `interactable=true` được đọc TRƯỚC
  activation. Layout 5 ô, skill slot diagnostic=4; native actual rectangle và
  visual proof đều thành công. Lỗi mất CardUI/đi vượt root Canvas đã được đóng
  bằng production live evidence này.
- Lý do chặn khi foreground hợp lệ: `PREFLIGHT_SAMPLE_STALE`. Có đoạn
  `GAME_NOT_FOREGROUND` khi đổi cửa sổ, và Button chưa interactable trong
  transition; không quy tất cả lỗi cho foreground hoặc Mana/Nộ.
- Observer log tới lúc dừng có 64 waiting events, trong đó 3 stale-sample
  events; không có card click, Arrow, Space hay QTE activation. Harness đã
  Ctrl+C và không restart tự động. Không gọi retry này là PASS.
- Read-only profiling trên cùng process, cùng 5-card hand/1280×640:
  native read 278.04–333.09 ms, capture 396.03–410.46 ms, visual 1.40–2.14 ms.
  Tổng 675–742 ms vượt giới hạn sample 350 ms. Capture có Python loop theo
  từng pixel; Canvas ancestor/component walk bị lặp cho từng thẻ.
- Sửa nhỏ: đổi BGRA→RGB sang bulk slices, giữ nguyên bytes/thứ tự/alpha;
  cache Canvas ancestor path chỉ trong MỘT `read_hand`, xóa ở đầu lần đọc sau.
  Fences cuối lần đọc vẫn kiểm tra parent/TRS/rect/Canvas; changed/dirty/job
  pending vẫn fail closed. Không cache tọa độ qua lượt/session.
- Sau sửa, 5 read-only samples: tổng native+capture+visual
  `249.60, 197.25, 199.51, 201.83, 199.39 ms`; capture còn 19.49–26.71 ms.
  Đây không phải end-to-end latency của full action. Probe gọi riêng hook
  geometry sau đó bị `GAME_NOT_FOREGROUND`, đúng fail closed, không click.
- Giữ nguyên age guard **0.35 s**, không restamp sample cũ. Thêm log
  `preflightTiming.geometryMs/sampleAgeMs` và `lastCardPreflightTiming` ở action
  events. Test hook chứng minh 2 preflight 200 ms cho đúng 1 fake click;
  preflight 700 ms ban đầu hoặc cuối đều không click.
- Tests mới kiểm tra bulk RGB byte-equivalence, Canvas path không tồn tại
  qua lần đọc sau, parent đổi giữa lần đọc vẫn bị loại và shared ancestor chỉ
  walk một lần. Full 976/976 PASS. Full automatic B1 sau sửa vẫn PENDING.

## Remediation hiện tại

- Native code của AddFusionSkillCard chứng minh Instantiate -> CardUI ->
  AdoptSharedSkillRefs -> SetCardData -> cardsInHand.Add. Không thay FusionCardUI.
- Discovery: current owned GO -> native components -> even scripting handle ->
  managed CardUI, rồi full validator. Không dùng heap scan cho post-Fusion skill.
- Geometry: current active GO + exact Button owner + RectTransform/local TRS
  + root Canvas/current viewport; final preflight đọc lại. Không đoán slot.
- Tất cả native layout có byte-signature guard. Unknown/dirty/changing state
  không cho click. Reason chi tiết được log để không còn chỉ thấy “không bấm”.
- Native signature, handle roundtrip và combat hand đã được probe read-only
  trên PID 26456; root Canvas aspect 2.0. Chưa có full-action live acceptance
  sau sửa; KHÔNG dùng direct hand probe để suy ra B1 thành công.
- Observer smoke `logs/phase3b3_native_card_smoke_20260904_readonly.jsonl`:
  attach READ-ONLY, chạy 3 giây và dừng sạch; `noInput=true`, `runtimeHook=null`,
  không có QTE/action. Tại kiểm tra cuối chỉ game PID 26456 còn chạy, không có
  Python observer/controller.
- Không tự start harness/live game trong lượt remediation này. Game files không
  sửa; code chưa commit/push; Phase 3B.3 vẫn PARTIAL, B1/B2/B3/B4 pending.

## Live acceptance

B1 attempt 1 cùng năm retry chưa thành công, không được đưa vào mẫu thành công. Làm theo
[phase3b3_runbook.md](phase3b3_runbook.md) để chạy B1 retry sau remediation.

## Scope giữ nguyên

- Pet Skill BasicPolicy integration: **NOT IMPLEMENTED**
- Pet Skill resource planner: **NOT IMPLEMENTED**
- autonomous Pet Skill farming: **NOT IMPLEMENTED**
- Pet/Evolution/Damage-card config: **NOT IMPLEMENTED**
- ManaPriority removal: **NOT IMPLEMENTED**
- memory write/direct gameplay call/network manipulation: **0**
