# Phase 2C.2B report

Status: Stage A, Stage B1, bounded Stage B2, Stage B3 and Stage B4 live
acceptance PASS STRONG. Stage B5 is now **FULL_MATCH_PASS** with a
user-confirmed WIN in match `M_217798cd`. Optional B5 full-cycle coverage is
`NOT_OBSERVED`, not failed, because no natural PASS occurred in the accepted
match.
One complete autonomous BASIC combat with production authoritative PASS ended
in a user-confirmed WIN and a clean controller stop. Automatic
exit/recovery/re-entry and multi-match farming remain disabled.

## Stage B5 full BASIC combat + authoritative PASS cycle — FULL_MATCH_PASS

B5 extends the accepted B3 full-combat controller without the B4 stop-after-
CAST condition. Its fixed live profile is `simple / evolution / basic`, with
EVOLVE, SWAP, CAST and zero-input authoritative PASS allowed for exactly one
combat. The only action bound is the existing high emergency total-input
ceiling; there is no 10-action or CAST terminal cap.

The PASS coordinator still accepts numeric idle state only from
`MATCH_AFK_WARN` or `MATCH_TURN_END.matchPayload.afkWarn`. Exact 2/3 enters a
mandatory consuming-action state, blocks a third PASS, and records all legal
candidate Sword-risk/Shield/unknown-exposure evidence. EVOLVE may run first
but does not satisfy the lock. The accepted mandatory SWAP/CAST result and its
reset provenance are recorded separately.

B5 now retains strong direct CAST acceptance as the distinct provenance
`DIRECT_CAST_STATE_TRANSITION` instead of fabricating a card-response DTO. A
later compatible exact server idle payload can classify that reset only as
`RESET_STRONGLY_INFERRED`; explicit or response/sequence-confirmed evidence
remains separate. Unknown CAST reset allows ordinary safe play to continue,
but any later need for PASS fails closed.

Full-cycle classification is evidence-bounded. `B5_PASS_STRONG` requires
server 1/3, server 2/3, an accepted mandatory consuming action, and a later
intentional PASS returning server 1/3 without an intervening consuming action.
A clean completed combat without that natural board sequence is
`FULL_MATCH_PASS` with PARTIAL/NOT_OBSERVED cycle coverage. No bad board is
manufactured.

Offline verification: Python compile PASS and `300/300` full regression PASS.
Runbook: `docs/phase2c2b_stage_b5_runbook.md`. Lobby smoke and one live combat
remain pending.

The first B5 preflight attached read-only to PID 14912 and classified the game
as LOBBY, but an independent singleton read found a stale ready 8x8
`Board.Instance` left by the previous combat. The controller correctly failed
before its input executor became active with `ProviderSetupError: start
MemoryBoardStateProvider in the lobby before Board.Instance exists`. No input
was sent. Evidence:
`logs/phase2c2b_stage_b5_preflight_20260814.jsonl`,
`logs/phase2c2b_stage_b5_stale_board_preflight_20260814.jsonl`, and
`logs/phase2c2b_stage_b5_lobby_smoke_20260814.jsonl`. The clean-lobby gate is
retained; a full game-process restart is required before retrying smoke/live
acceptance.

### Stage B5 live attempt 1 — safe stop after EVOLVE

Evidence: `logs/phase2c2b_stage_b5_acceptance1_20260814.jsonl`, match
`M_1628e4db`. The controller sent seven SWAPs and two EVOLVE inputs. Six SWAPs
were acknowledged. EVOLVE first failed, then later succeeded on local turn 13
with exact durable `fusion.used=true` evidence. It correctly reread a stable
same-turn board and selected a safe fallback SWAP, but sent that follow-up only
1.47 seconds after the EVOLVE terminal. The game ignored the two-click swap
during the remaining animation/presentation window; no ACK arrived within nine
seconds, so the controller emitted the three-tone alarm and locked input as
`ACTION_RESPONSE_TIMEOUT`. Duplicate, misclick, partial, wrong-turn, stale,
boss-turn, postmatch and lobby inputs were all zero. PASS/CAST, DEAD_BOARD and
SEQUENCE_DESYNC were zero. The later combat end did not overwrite the earlier
safe-stop reason.

Eight prior successful EVOLVE-follow-up samples used 3.80–5.20 seconds between
EVOLVE terminal and next SWAP. B5 now holds all follow-up input for 3.5 seconds
after either EVOLVE success or failure, then performs the full fresh
actionability/timer/state/policy reread. A source/turn change cancels the
same-turn wait. Regression after the fix was `298/298 PASS`; lobby smoke retry
2 sent zero input and passed.

### Stage B5 live retry 2 — bounded cycle partial, EVOLVE-only AFK discovery

Evidence: `logs/phase2c2b_stage_b5_acceptance_retry2_20260814.jsonl`, match
`M_35b2ee04`. The controller completed 10/10 acknowledged SWAPs and one
successful EVOLVE, with all duplicate/misclick/partial/wrong-turn/stale/
opponent/postmatch/lobby counters at zero. It observed an exact first PASS at
1/3, a second PASS at 2/3, then sent an acknowledged mandatory SWAP; no third
PASS occurred. This proves the dangerous half of the bounded cycle and its
mandatory-action gate worked in live B5.

After the successful EVOLVE on local turn 25, the 3.5-second input settlement
completed correctly. BASIC then selected PASS from the prior acknowledged
SWAP reset baseline. The controller sent zero input, boss turn 26 occurred,
and local turn 27 returned, but the game emitted no correlated AFK payload.
The old coordinator therefore stopped safely as `PASS_STATE_UNCONFIRMED`.
Together with the historical accepted-EVOLVE capture `M_1aaa7be0`, this is
direct evidence that an EVOLVE-touched turn may end without being reported as
an AFK/PASS turn.

B5 now uses a distinct `EVOLVE-only turn` zero-input state when the same-turn
post-EVOLVE policy would otherwise PASS. It does not start `PASS_WAIT`, does
not increment PASS execution/proposal counts, preserves only actual server
idle evidence, observes the opponent transition, and forces a complete fresh
reread before the next local action.

### Stage B5 live retry 3 — failed EVOLVE is activity too

Evidence: `logs/phase2c2b_stage_b5_acceptance_retry3_20260814.jsonl`, match
`M_f8cd2d73`. All 6/6 SWAPs were acknowledged. The autonomous EVOLVE on local
turn 13 received exact `MATCH_FUSION_RES success=false`; the controller then
settled for 3.5 seconds and BASIC legitimately found 11 legal but zero safe
moves. Because the first activity marker covered success only, the old path
entered `PASS_WAIT`. Boss activity and local turn 15 followed with no AFK
payload, so it emitted the three-tone `PASS_STATE_UNCONFIRMED` safe stop.

This independently proves that a rejected terminal Fusion attempt can also
make the turn non-AFK. The activity marker now covers both `EVOLVE_SUCCESS`
and `EVOLVE_FAILED`. Full regression is `300/300 PASS`; all live retry-3
duplicate/misclick/partial/wrong-turn/stale/opponent/postmatch/lobby and third-
PASS counters were zero.

### Stage B5 live retry 4 — excluded user foreground interruption

Match `M_97015e9e` is not an acceptance failure. The user tabbed away on local
turn 19. The controller logged `GAME_NOT_FOREGROUND`, sent no click, and then
safe-stopped at six seconds as `LOCAL_TURN_ACTION_DEADLINE`. It had already
completed 7/7 acknowledged SWAPs and two independently server-confirmed 1/3
PASS waits; all safety counters were zero. The lifecycle later ended and
returned to lobby while autonomous input stayed disabled.

### Stage B5 live retry 5 — FULL_MATCH_PASS, user-confirmed WIN

Evidence: `logs/phase2c2b_stage_b5_acceptance_retry5_20260814.jsonl`, match
`M_217798cd`. The user visually confirmed WIN. Runtime recorded 26 local and
25 boss turns, 27 total inputs and 26 turn-consuming inputs. The exact action
totals were:

- SWAP: 21 sent, 20 acknowledged, zero rejected. The final SWAP was already
  sent on turn 51 when the game entered postmatch, so it was correctly closed
  as `ACTION_ABORTED_STATE_CHANGED / COMBAT_LIFECYCLE_ENDED` rather than
  retried or falsely acknowledged;
- EVOLVE: one proposal/input and one success on turn 9. The settlement gate
  delayed the follow-up until 4.77 seconds after the terminal Fusion result;
  the same-turn SWAP was then acknowledged;
- CAST: five proposals/inputs and five accepted state transitions. Each used
  the dynamically resolved Attack card (`ID 4`, `Tấn công`, cost 160 from
  `CardData.conditionUse`) and showed the exact mana deduction. No same-turn
  SWAP followed a CAST;
- PASS: zero proposals/executions in this natural match. Therefore cycle
  coverage is `NOT_OBSERVED`, while earlier retry 2 retains partial evidence
  for 1/3 -> 2/3 -> acknowledged mandatory SWAP.

Policy coverage was Sword 4, Rage 3, Mana 8, Shield 2, Drain 1, CAST 5,
EVOLVE 1 and general safe-resource fallback 3. DEAD_BOARD, SEQUENCE_DESYNC,
illegal third PASS and all duplicate/misclick/partial/wrong-turn/stale/
opponent/postmatch/lobby/after-combat input counters were zero. Lifecycle was
lobby -> active combat -> postmatch -> lobby, the session cache was cleared,
and the controller stopped with `COMBAT_LIFECYCLE_ENDED`. Classification is
`FULL_MATCH_PASS`; regression is `300/300 PASS`.

## Stage B4 attack-priority CAST acceptance — PASS STRONG

B4 is an explicit production-PASS mode using `simple / attack / basic`. The
existing BASIC order and strict `playerMana > 480` CAST threshold are
unchanged. Attack CardUI resolution remains dynamic: no card ID is hard-coded,
and the actual positive cost comes from `CardData.manaCost`, otherwise
`CardData.conditionUse`.

ATTACK priority now has a controller-level hard assertion in addition to the
policy rule. B4 advertises EVOLVE as disabled, logs the first
`EVOLVE_SKIPPED_MANA_PRIORITY_ATTACK` observation, and stops before input as
`B4_EVOLVE_FORBIDDEN` if an EVOLVE proposal ever escapes policy. The summary
records EVOLVE proposals, inputs and violations separately; all must remain
zero in live acceptance.

CAST revalidation already covered session, match, turn, `srvSeq`, board hash,
critical stats/cards, full actionability, timer, modal, foreground, dynamic
card ownership/state and affordability. B4 additionally records the exact
cost source and before-idle/reset evidence, then holds the consuming-turn lock
in `WAIT_CARD_RESPONSE`.

The prior B3 fallback could accept a missed response from an exact boss-turn
transition alone. B4 is intentionally stronger: it retains that exact
same-session source-turn-plus-one boss transition with unchanged local/last
board-move sequences, but also re-reads current Board/Active-owned player stats
and CardUI state without a heap scan. Acceptance requires exact
`manaAfter = manaBefore - actualCost` plus either an accepted current-match
card response or a durable `lastTurnUsed/hasUsedThisTurn` transition. Missing
or conflicting evidence remains pending and times out closed.

After strong acceptance the controller immediately stops all input and emits
two high tones. The accepted CAST source turn is registered and a same-turn
SWAP proposal is an emergency hard failure. CAST idle/reset capability remains
reported exactly; UNKNOWN never becomes a local idle zero. No automatic exit,
re-entry or farming was added.

Offline regression after B4 integration: `74/74` focused and `290/290` full
PASS; Python compile PASS. The lobby smoke attached read-only to PID 26248,
proved `LOBBY`, advertised only `SWAP/CAST/PASS`, disabled EVOLVE, and stopped
after three seconds with zero gameplay input and every safety counter zero.
Evidence: `logs/phase2c2b_stage_b4_lobby_smoke_20260814.jsonl`. Runbook:
`docs/phase2c2b_stage_b4_runbook.md`. Live CAST acceptance is now complete in
retry 2 below.

### Live retry 2 — B4 PASS STRONG

Evidence:
`logs/phase2c2b_stage_b4_acceptance_retry2_20260814.jsonl`, match
`M_4ce90616`. The controller started from the verified boss lobby, observed 17
local and 16 boss turns, and stopped intentionally after the accepted CAST;
full combat completion was optional and therefore remains `NOT_COMPLETED` in
the controller summary. The user heard the intended two high tones and later
reported returning to lobby.

The accepted retry sent 16 gameplay inputs, all turn-consuming: 15 SWAPs and
one CAST. All 15 SWAPs were acknowledged with zero rejection. BasicPolicy
produced one CAST proposal at `STEP_5_CAST`; full pre-click revalidation passed
and the current owned/equipped Attack CardUI was clicked by normal Windows UI.
The observed card was ID 4, `Tấn công`, type ATTACK, but selection remained
dynamic and did not hard-code that ID. Actual cost came from
`CardData.conditionUse = 160`.

CAST evidence is exact: before, local turn 33 had mana 603 and the card was
interactable, unused this turn, with `lastTurnUsed = -1`; after, mana was 443,
the card was non-interactable, used this turn, with `lastTurnUsed = 33`, and
MatchService was on boss turn 34. Both local board-move sequence fields stayed
at 15, proving no SWAP was sent as part of the consuming transition. Thus
`603 - 160 = 443`, same-turn SWAP was zero, and the action was terminalized as
`CAST_ACCEPTED`.

The response DTO was not retained, so `responseAccepted` is false while the
independent CardState/mana/turn proof is true. In accordance with the fixed
authoritative model, CAST reset activity, idle state and reset baseline after
CAST remain UNKNOWN/null; no local idle zero was synthesized. The controller
stopped as `B4_CAST_ACCEPTED_RESET_UNKNOWN`, disabled input, emitted the
two-tone success signal, and classified the attempt `B4_PASS_STRONG`.

Authoritative PASS remained active: one BASIC-selected PASS sent zero gameplay
input and received exact `PASS_CONFIRMED_IDLE_1`; there was no idle 2/3, third
PASS or mandatory reset action. EVOLVE proposals, EVOLVE inputs and ATTACK
priority violations were all zero. DEAD_BOARD and SEQUENCE_DESYNC were zero.
Duplicate, misclick, partial, wrong-turn, stale, boss-turn, postmatch, lobby
and after-combat inputs were all zero. Pending action was null and controller
status was `STOPPED`.

Across B4 there were two manually entered sessions: attempt 1
`M_b7235e32`, rejected as a clean run because of the now-fixed post-acceptance
bookkeeping crash, and accepted retry 2 `M_4ce90616`. No third session was
started. Final Python compile passed; focused regression is `77/77` and full
regression is `293/293`. Stage B4 stops here: no farm loop, auto-exit,
auto-reentry or REASONING implementation was added.

### Live attempt 1 — CAST strongly observed; clean run rejected after terminalization crash

Evidence: `logs/phase2c2b_stage_b4_acceptance1_20260814.jsonl`, match
`M_b7235e32`. The controller observed 16 local and 16 boss turns and sent 16
inputs: 15 SWAPs, all acknowledged, followed by one dynamically resolved
Attack CAST. There were no policy PASS or EVOLVE proposals/inputs.

BasicPolicy selected `STEP_5_CAST` on local turn 31 with mana 882. The owned
CardUI was card ID 4, name `Tấn công`, type ATTACK; ID 4 was observed data, not
hard-coded selection. Its actual cost came from `CardData.conditionUse = 160`.
After normal UI input, the card changed from interactable/unused/last turn -1
to non-interactable/used/last turn 31, mana changed exactly `882 -> 722`, and
MatchService changed to boss turn 32 with unchanged local board-move sequences.
This is strong CAST acceptance evidence. Same-turn SWAP count was zero.

The retained `MATCH_CARD_USE_RES` was absent. After logging the accepted proof,
the first B4 implementation incorrectly passed the synthetic label
`MATCHSERVICE_TURN_TRANSITION` into the game-owned idle model, whose invariant
correctly permits only `MATCH_CARD_USE_RES` or `MATCH_SKILL_USE_RES` for CAST.
The resulting `accepted activity/source message mismatch` exception terminated
the hidden controller before its normal result/summary and two-tone success
signal. The user then observed three inactive local turns and was removed from
the match. The log contains zero PASS decisions: those skipped turns occurred
after the controller had crashed. This attempt is therefore not a clean B4
PASS despite the valid CAST evidence.

The fix no longer fabricates a response source. A direct state/turn CAST proof
is retained, CAST reset remains exactly UNKNOWN when no accepted response DTO
is available, input stops normally, and the two-tone success path can finish.
Unhandled controller exceptions now emit the three-tone pause alarm as an
additional fail-closed notification. New tests cover both the response-missing
and attributed-response paths plus fatal alarm behavior. Python compile,
focused regression `77/77`, and full regression `293/293` PASS. The subsequent
clean retry 2 fulfilled B4; no automatic re-entry was added.

## Stage B3 PASS STRONG — one complete autonomous combat

Evidence:
`logs/phase2c2b_stage_b3_authoritative_pass_retry6_20260814_192336.jsonl`.
The live match was `M_4e7b051a`, lifecycle epoch 1, Board instance
`0x00000258EAAA8540`, on the freshly restarted game PID 26248. The user made no
gameplay input and directly confirmed the result as WIN. The memory-only end
classifier did not capture a zero-HP snapshot before teardown and therefore
conservatively logged `ENDED_RESULT_UNKNOWN`; this does not contradict the
observed WIN.

The controller observed 17 local and 15 boss turns. It sent 15 total gameplay
inputs: one non-consuming EVOLVE and 14 turn-consuming SWAP inputs. Thirteen
SWAPs received terminal ACKs. The fourteenth was the final turn-33 SWAP; combat
ended before its ACK could be retained, so it was correctly terminalized as
`ACTION_ABORTED_STATE_CHANGED / COMBAT_LIFECYCLE_ENDED`, not rejected or
retried. No pending action survived session cleanup.

EVOLVE was attempted once on turn 19 and returned `EVOLVE_FAILED`. The
controller reread the full state and sent an ACKed SWAP later on the same turn,
proving the failed-Fusion continuation path without a tight loop. CAST was not
selected because its real policy conditions did not occur in this match and is
reported `NOT_OBSERVED`, not synthesized.

Three BASIC-selected PASS actions sent zero gameplay input and each received
exact `PASS_CONFIRMED_IDLE_1`. Each was later separated by an accepted
consuming action, so authoritative idle 2/3 and its mandatory-reset branch were
not triggered in this particular combat. There was no third consecutive PASS.
The integrated 2/3 prohibition and mandatory reset remain backed by the
already accepted Phase 2C.2C P0-P3 evidence; B3 did not force a dangerous or
artificial PASS merely to repeat that coverage.

Run totals:

- result/classification: user-confirmed `WIN` / `FULL_COMBAT_COMPLETED`;
- stop reason: `COMBAT_LIFECYCLE_ENDED`, controller `STOPPED`;
- local/boss turns: 17/15;
- total input/turn-consuming input: 15/14;
- SWAP sent/ACK/rejected: 14/13/0, plus one valid lifecycle abort at combat end;
- EVOLVE attempts/fail/success: 1/1/0;
- CAST attempts/accepted: 0/0 (`NOT_OBSERVED`);
- PASS started/idle-1/idle-2: 3/3/0;
- mandatory actions after 2/3: 0 (`NOT_TRIGGERED`);
- wrong third PASS/PASS gameplay input: 0/0;
- reset baselines confirmed: 13; loaded SWAP reset capability remained 2/2
  `reset_confirmed_by_server_sequence`;
- policy coverage: SWORD 4, RAGE 2, SHIELD 2, SAFE_RESOURCE_FALLBACK 5,
  DRAIN 1, PASS_REQUIRED 3, EVOLVE 1;
- DEAD_BOARD/SEQUENCE_DESYNC/safety-limit/deadline stops: 0/0/0/0;
- duplicate/misclick/partial/wrong-turn/stale/expired input: all zero;
- boss-turn/postmatch/lobby/after-combat inputs: all zero;
- lifecycle: LOBBY -> board/session found -> ACTIVE_COMBAT -> POSTMATCH ->
  LOBBY; session, idle/reset, pending, Fusion/Card and board-scoped state were
  cleared.

Final offline regression is `41/41` focused and `283/283` full PASS. Stage B3
stops here for review. It does not authorize automatic exit, re-entry, farming,
REASONING policy, memory writes, direct game calls or network manipulation.

## Stage B3 authoritative PASS production integration — offline PASS

Phase 2C.2C P0-P3 established production-ready SWAP reset evidence and the
server-authoritative `1/3 -> 2/3 -> mandatory SWAP -> 1/3` cycle. Stage B3 now
has an explicit `B3` authoritative-PASS mode. It loads that audited reset
capability, permits only BASIC-selected zero-input PASS, and rejects the
acceptance-only forced-PASS trigger. Confirmed idle 1 and idle 2 continue the
combat instead of using the P1/P2/P3 acceptance stop conditions.

After exact idle 2 the controller retains a mandatory-reset lock. PASS is no
longer a candidate, and the normal strategic/safe consuming choice or existing
deterministic least-dangerous fallback must produce an acknowledged SWAP/CAST.
Only a capability-backed reset baseline reopens a new two-PASS cycle; a missing
reset stops as `PASS_STATE_UNKNOWN`. First-turn, lifecycle, foreground,
actionability, dead-board and sequence-desync guards are unchanged.

The former `legal > 0`, `safe == 0`, idle-UNKNOWN path is no longer mislabeled
`POLICY_NO_SAFE_MOVE`; it is the distinct safe terminal
`PASS_STATE_UNKNOWN`. The summary now exposes production/acceptance PASS mode,
whether forced acceptance was enabled, and the confirmed reset-baseline count.
Focused regression is `41/41 PASS`; full offline regression is `283/283 PASS`.
The fresh lobby smoke attached read-only to PID 7232, proved `LOBBY`, logged
`STAGE_B3_ONE_COMPLETE_COMBAT_AUTHORITATIVE_PASS`, allowed
`EVOLVE/SWAP/CAST/PASS`, confirmed the forced acceptance trigger was false,
and stopped after three seconds with zero gameplay input and every safety
counter zero. Evidence:
`logs/phase2c2b_stage_b3_authoritative_pass_lobby_smoke_20260814.jsonl`.

### Authoritative-PASS live attempt 1 — stale response DTO rejected

Evidence: `logs/phase2c2b_stage_b3_authoritative_pass_live_20260814_183531.jsonl`,
match `M_a4caf16a`. The controller acknowledged three SWAPs, then completed a
zero-input `PASS_CONFIRMED_IDLE_1` from exact `MATCH_AFK_WARN 1/3`. During the
second PASS, a heap-scanned `MATCH_MOVE_RES` combined a current-looking
timestamp with `actorUsername=happi` but carried `serverSequence=3`, older than
the PASS source `srvSeq=19`. The user confirmed no gameplay action. The
timestamp-only activity freshness check therefore produced a false
`PASS_ABORTED_USER_ACTION`; this run is rejected.

A new activity response must now have both a server timestamp not older than
PASS_WAIT and a server sequence strictly newer than the PASS source. A missing
or non-increasing response sequence cannot claim user input. The independent
direct `localMoveSequence` increase detector remains active for a real manual
SWAP, while absent PASS evidence still fails closed on the next-local scan.
Focused and full regressions were `51/51` and `281/281 PASS` at this point.

### Authoritative-PASS live retry 1 — safe stop; CAST transition isolated

Evidence:
`logs/phase2c2b_stage_b3_authoritative_pass_retry1_20260814_184035.jsonl`,
match `M_33d64441`. Before stopping, the controller completed 19/19 SWAPs,
one successful EVOLVE, four authoritative zero-input PASS actions
(`idle-1=3`, `idle-2=1`) and one mandatory reset. PASS sent zero gameplay
input, no third PASS occurred, and all input-safety counters remained zero.

The controller then clicked the server-provided attack card on local turn 47
with 11 seconds remaining. At 1.25 seconds after the click, exact
`MatchService` state changed to turn 48 owned by the boss while both local
board-move sequence fields remained 19. This is the consuming transition for
an accepted CAST; a rejected CAST does not consume the turn. The retained
`MATCH_CARD_USE_RES` DTO was not captured, so the previous implementation
waited for its action timeout, beeped and auto-paused as
`ACTION_RESPONSE_TIMEOUT`. Combat later ended while paused, and the old
lifecycle path incorrectly overwrote that earlier terminal reason with
`COMBAT_LIFECYCLE_ENDED`. This retry is therefore a safe stop, not the B3 live
PASS.

The controller now accepts CAST only from that exact same-session,
source-turn-plus-one opponent transition with unchanged, known local/last
board-move sequences when the DTO is missed. Conflicting turn, player or
sequence evidence is rejected. Combat teardown also preserves an earlier
`AUTO_PAUSED`/`RECOVERY_REQUIRED` terminal reason so a later match end cannot
turn a safe stop into a false full-combat acceptance. Current regression after
these fixes is `41/41` focused and `283/283` full PASS.

## Stage B3 live attempt 1 — invalidated by manual input, blocker isolated

Evidence: `logs/phase2c2b_stage_b3_acceptance_20260814_102006.jsonl`, match
`M_bce1f7ea`. The controller autonomously completed multiple ACKed SWAPs and
later proved both `EVOLVE_FAILED` and `EVOLVE_SUCCESS`; the successful attempt
was followed by a same-turn ACKed SWAP. After the failed attempt on turn 15,
however, no new Board DTO was published. The provider waited for a board
capture through local turns 17 and 19 even though failure changed only Fusion
attempt state. It produced no policy decision and no beep. The user made a
manual move before the third consecutive skip, so this attempt cannot satisfy
B3 acceptance. A later `GAME_NOT_FOREGROUND` interval is separately visible
and was not the initial cause.

The controller was stopped externally only after the log proved equal sent and
terminal action counts (`12/12`), so no input was pending. The provider now
recognizes a failed Fusion ACK as a durable non-board transition only when the
ACK advances, `LocalFusionLastAttemptTurn` advances on the same local turn,
local move sequence is unchanged, pending/in-flight batches are absent and two
validated `Board.allDots` samples are identical. It can then republish the
retained authoritative board for the same-turn follow-up policy.

A separate direct-root deadline guard now safe-stops and beeps at six seconds
when an authoritative local turn has no consuming action. It uses server turn,
current-player and timer state rather than a local pass counter. This prevents
a future state-provider delay from silently spending two turns. Full offline
regression after both corrections: `246/246 PASS`. A clean lobby retry remains
pending.

## Stage B3 retry 4 — safe-stop detected, ordering and alert corrected

Evidence: `logs/phase2c2b_stage_b3_retry4_20260814_110702.jsonl`, pause
artifact
`logs/policy_pause/20260814_112404_139_POLICY_NO_SAFE_MOVE_seq23_795bf7f6b6db`.
The controller completed five SWAPs with five terminal ACKs. On local turn 11
the authoritative board contained exactly one legal swap: a vertical Shield
clear with three unknown refill cells, `collapseSupportHazard=1` and a remaining
sword-danger region. Classifying that swap unsafe is consistent with the BASIC
policy and has not been relaxed.

Fusion was actionable and the policy correctly selected Step 1 EVOLVE, but the
generic zero-safe-swap gate ran before dispatch and paused the controller before
EVOLVE. This was an ordering defect: EVOLVE is a non-board function and must be
attempted before judging whether a board move is required; CAST is likewise a
separate consuming action. The later manual rescue invalidates this run as B3
acceptance.

The no-safe-move guard now exempts EVOLVE and CAST while retaining fail-closed
behavior for unsafe SWAP/PASS proposals. The former 120 ms pause chirp was easy
to miss and is now a distinctive three-tone 760 ms alarm. The controller was
stopped only after all five sent actions had terminal results, with no pending
input. Full offline regression after these corrections: `247/247 PASS`.

## Stage B3 retry 7 — direct-owner grace exhausted the local turn

Evidence: `logs/phase2c2b_stage_b3_retry7_20260814_123153.jsonl`, match
`M_b94d57a6`. The controller completed seven SWAPs with seven exact terminal
ACKs and zero pending input. At local turn 15, MatchService proved the turn at
14 seconds and highest ACK advanced to sequence 32, but the provider still had
sequence 28 as its last published board. Sequence 30 was transport/ACK-attested;
using it would have been stale after the boss action, so the provider correctly
refused it.

The missing sequence-32 DTO triggered the direct-owner capture grace. Its old
limit was eight complete provider polls; live polls were roughly 0.9 seconds in
this interval, so the wait consumed the actionable window and the watchdog
paused at five seconds with `LOCAL_TURN_ACTION_DEADLINE`. The new three-tone
alarm was heard, F9 was applied, and the controller ended with `7/7` terminal
actions and no pending input.

The direct-owner grace was reduced to two polls. At this revision autonomous
mode still intentionally disabled ACK heap scanning and continued with its
transport-only wait; retry 8 was required to test whether grace alone was
sufficient. No currentness or board validation rule was relaxed. Diagnostics
now expose the grace sequence, poll count and limit. Focused regression
`57/57 PASS`; full offline regression was `247/247 PASS`.

## Stage B3 retry 8 — transport DTO lost; bounded ACK fallback enabled

Evidence: `logs/phase2c2b_stage_b3_retry8_20260814_123653.jsonl`, match
`M_ab29a1e2`. The controller completed six SWAPs plus one failed EVOLVE; all
seven inputs reached exact terminal results and no input was pending. The
failed EVOLVE was correctly republished as a stable non-board transition and
the same-turn follow-up SWAP was ACKed. On local turn 13, highest ACK advanced
to 29 while the last published sequence was 26. A transport board at sequence
27 existed, but sequence 29's short-lived Newtonsoft payload repeatedly failed
strict decoding with `JProperty runtime class mismatch`; using 27 would have
been stale. After two direct-owner grace polls the controller reached
`awaiting_transport_board_capture` and the deadline alarm fired at five
seconds. The controller was externally stopped at `7/7` terminal actions and
zero pending input.

Read-only post-stop measurement confirmed why the old alternatives were
insufficient. An unrestricted scan read 3.36 GiB in 14.5 seconds. The provider's
old bounded 8 MiB envelope read 237 MB in 1.06 seconds but missed the newest
live batch; a dedicated 16 MiB envelope read 435 MB in 1.94 seconds and found
both live batches. Autonomous mode now enables only this dedicated bounded
16 MiB exact-ACK fallback. Normal provider scans remain at 8 MiB and the
unrestricted scan remains disabled. Class hits still require exact current ACK,
complete 64-cell validation, current-session filtering and stable publication.
Focused regression `59/59 PASS`; full offline regression `249/249 PASS`. A
clean retry is pending.

## Stage B3 retry 9 — valid no-safe-move stop

Evidence: `logs/phase2c2b_stage_b3_retry9_20260814_131150.jsonl`, match
`M_57b38333`, artifact
`logs/policy_pause/20260814_131409_434_POLICY_NO_SAFE_MOVE_seq23_5bd6ec5b088a`.
The controller completed five SWAPs with five terminal ACKs and zero pending
input. Sequence 23 was a stable current ACK-attested 64-cell board, so this was
not a transport/provider stall and the new ACK heap fallback was not required
before the stop.

At local turn 11 the solver found six legal swaps and classified all six
unsafe. Every candidate exposed at least one unknown sword completion; danger
scores were 100--220, with up to four collapse-support hazards and up to five
remaining sword-danger regions. The player had 140 mana, below the proven
160 Fusion cost; Fusion UI interactability was not proven, no attack card was
available, and the game-owned consecutive-idle count remained UNKNOWN. BASIC
therefore reached Step 6, but automatic PASS is disabled in Stage B3 and an
unknown idle count cannot authorize it. `POLICY_NO_SAFE_MOVE` and the three-tone
alarm were the required fail-closed result. The exact controller PID was
stopped at `5/5` terminal actions; game PID 8052 was untouched. No safety rule
was relaxed and this run is not a full-combat acceptance.

## Stage B3 retry 10 — second valid Step-6 boundary

Evidence: `logs/phase2c2b_stage_b3_retry10_20260814_132005.jsonl`, match
`M_eb8737a5`, artifact
`logs/policy_pause/20260814_132305_549_POLICY_NO_SAFE_MOVE_seq41_03154ee8793c`.
The controller completed nine SWAPs with nine terminal ACKs and zero pending
input. All nine published boards were normal stable ACK-attested DTOs; there
was no `LOCAL_TURN_ACTION_DEADLINE`, no transport-only wait and no need to use
the bounded ACK heap fallback before the policy stop.

At local turn 19, sequence 41 contained six legal moves and zero safe moves.
Five candidates left a known sword potential; the remaining candidate exposed
an unknown sword completion. Danger scores ranged from 200 to 630, with up to
four sword-danger regions and three collapse-support hazards. Player mana was
105, below the proven 160 Fusion cost; no CAST was available. The policy
correctly reached Step 6, but game-owned idle state was UNKNOWN and automatic
PASS remains outside Stage B3. `POLICY_NO_SAFE_MOVE` was therefore a valid
safe-stop. F9 was received and the controller exited at `9/9` terminal actions.

Retries 9 and 10 demonstrate a scope boundary rather than a provider or solver
defect: a complete autonomous combat cannot be guaranteed with PASS disabled
when the requested BASIC policy legitimately reaches Step 6. The solver safety
thresholds remain unchanged; no dangerous move is forced merely to satisfy the
acceptance run.

## Stage B3 retry 11 — opening duplicate-scan deadline

Evidence: `logs/phase2c2b_stage_b3_retry11_20260814_132704.jsonl`, match
`M_a9483d51`. MatchService first proved local turn 1 at 14 seconds and the
current MATCH_START payload was decoded completely at sequence 1. The provider
retained the required two stable opening samples, but the board reached
`stable_match_start_opening_dto` only just before the watchdog observed five
seconds remaining. It paused as `LOCAL_TURN_ACTION_DEADLINE`; no policy or input
was issued. F9 ended the controller at `0/0` actions and zero pending input.

The timing trace isolated duplicate transport work rather than an invalid
opening: each controller iteration sampled learned ChatMessageDTO regions
before the provider to preserve short-lived boards, then sampled the same
regions again after the provider for sequence monitoring. The post-provider
stage now reuses the already-current early observation from that iteration. If
the provider creates the combat session during the poll, no early observation
exists and the normal post-provider sample remains mandatory. Two-sample board
stability, exact DTO validation, the six-second deadline and minimum input time
are unchanged. Focused controller/sequence regression `46/46 PASS`; full
offline regression remains `249/249 PASS`. A clean retry is pending.

## Stage B3 retry 12 — opening fixed; late learned-region fallback isolated

Evidence: `logs/phase2c2b_stage_b3_retry12_20260814_133234.jsonl`, match
`M_3e73ba7c`. Reusing the early transport observation removed the retry-11
opening failure: the controller autonomously sent fourteen SWAPs and one
EVOLVE, the Fusion succeeded, and all `15/15` inputs reached terminal results.
The bounded ACK heap path was exercised repeatedly and produced exact
`MatchService._ackedSeqs+postLobbyHeap` witnesses while preserving stable DTO
publication.

At local turn 29, highest ACK advanced to sequence 62. One direct-owner grace
poll ran, then the learned batch-region scan did not resolve sequence 62. The
old implementation recorded that miss and deferred the bounded full scan until
the next controller iteration. The next full scan found exact sequence 62 and
the board reached two-sample stability, but only at five seconds remaining, so
`LOCAL_TURN_ACTION_DEADLINE` correctly paused input. Sequence 62 was never
replaced by stale sequence 60. After the pause the user manually made a Sword
move and won the combat; F9 arrived after lifecycle end with `15/15` controller
actions terminal and zero pending. The manual rescue means this run cannot be
counted as the one-complete-combat autonomous acceptance.

Direct-owner grace is now one complete provider poll. A learned-region miss
immediately escalates to the bounded full 16 MiB scan in that same poll instead
of spending another transport/controller cycle. Exact highest ACK, session
baseline exclusion, complete 64-cell DTO validation, render convergence and
two-sample stability are unchanged. Diagnostics now report ACK heap scan count.
Focused regression `60/60 PASS`; full offline regression `250/250 PASS`. A
clean acceptance retry remains pending.

## Stage B3 retry 13 — timing fixes PASS; valid Step-6 stop remains

Evidence: `logs/phase2c2b_stage_b3_retry13_20260814_135230.jsonl`, match
`M_80c655a5`, artifact
`logs/policy_pause/20260814_135552_683_POLICY_NO_SAFE_MOVE_seq40_59343c8aed21`.
The controller completed nine SWAPs and one successful EVOLVE. All `10/10`
inputs reached terminal results with zero pending input. The player evolved to
105228 maximum HP. Exact ACK heap witnesses were used during the run without a
local-turn deadline, confirming that one-poll direct-owner grace plus same-poll
bounded full fallback removed retry 12's timing failure.

At local turn 19, sequence 40 had only two legal moves and zero safe moves.
Both were vertical, non-calculable candidates that left a known sword potential;
one also exposed an unknown sword completion. Their danger scores were 620 and
520. Fusion was already used, player mana was 442 (below the BASIC policy's
greater-than-480 CAST branch), and game-owned consecutive idle remained
UNKNOWN. Step 6 therefore safe-stopped as `POLICY_NO_SAFE_MOVE`. F9 ended the
controller at `10/10` terminal actions. This is not a provider defect and no
safety threshold was relaxed.

Retries 9, 10 and 13 independently reach the same legitimate Stage-B3 scope
boundary: with automatic PASS disabled, a full combat depends on never
encountering a board where BASIC requires Step 6. The current timing/provider
corrections are validated; one autonomous full-combat acceptance remains
pending.

## Stage B1 implementation

The controller now separates `input_actions_total`,
`turn_consuming_actions_total`, `evolve_attempts`, `swap_actions` and
`cast_actions`. Stage B1 stops after the terminal result of the third
SWAP/CAST (`AUTO_STOP_AFTER_ACK`) and has a separate ten-input ceiling.
EVOLVE does not consume the three-action budget and is limited to two attempts
per concrete session/turn by default.

Every proposal logs `action_identity_created`; every sent input logs
`action_sent`; every terminal sent action logs `action_terminal` while the
existing `action_result` vocabulary remains available for Stage A tooling.
Identity includes session, match, turn, server sequence, board hash, action and
target plus a hash of critical gameplay state. Timer ticks are excluded from
that critical hash, but player/boss resources, cards, Fusion and actionability
signals invalidate a stale proposal.

After an accepted SWAP/CAST the controller blocks policy evaluation until it
has observed and logged `OPPONENT_TURN`, followed by a distinct
`LOCAL_TURN_RETURNED`. A local turn that advances without an observed opponent
turn pauses fail-closed. The accepted current-match 64-cell opening DTO emits
`OPENING_BOARD_READY` before its first decision.

Unsent reservations can now be cancelled independently of the permanent
executed registry. F7 is rechecked immediately before all gameplay input;
pause discards an unsent proposal and resume recomputes from fresh GameState.
F9 remains rechecked after slow reads and immediately before input.

PASS and generic dangerous fallback remain disabled. Ordinary non-opening
states with legal moves but zero safe moves pause as `POLICY_NO_SAFE_MOVE`.
Undefined BASIC resource states log boss mana/rage and safe Drain/Shield/
Mana/Rage availability. The dead-board proof now correctly accepts the exact
authoritative opening DTO as well as normal ACK-attested boards; no automatic
exit is performed. CAST no longer has a guessed 160-mana fallback: a positive
runtime card cost must be known.

Offline regression after Stage B1 implementation: `183/183 PASS`; Python
compile and actual CLI parsing also PASS.

## Stage B1 live attempt 1

Evidence: `logs/phase2c2b_stage_b1_live_20260813_191228.jsonl`, match
`M_eaae0779`. The accepted opening board was complete/stable and emitted
`OPENING_BOARD_READY`. The controller selected a safe Rage SWAP `(6,6) ->
(6,7)`, sent exactly one two-click input and received
`SWAP_ACKNOWLEDGED` at sequence 5. Duplicate, misclick, partial, wrong-turn,
stale and desync counters were all zero.

The next local board was eventually published at turn 3, sequence 7, but the
controller paused `TURN_TRANSITION_NOT_PROVEN`. This was a conservative false
negative: transition tracking began only when the delayed SWAP ACK was
observed, after the short boss turn had already happened. The user then used
F9 and the controller stopped cleanly with no pending action. This attempt is
a valid safe pause, not a strong Stage B1 PASS.

The tracker now begins when a consuming input is actually sent and observes
the direct read-only `MatchService.CurrentTurnPlayer/TurnNumber` roots during
ACK/DTO delay. Full current 64-cell Board publication is still required before
the next policy decision/input. A bounded fast direct-root sampling window
prevents the stricter heap/DTO scan from hiding the short boss turn. A
transition pause also clears its witness after one warning, preventing repeated
beeps. Regression after this correction: `184/184 PASS`.

## Stage B1 live retry 1

Evidence: `logs/phase2c2b_stage_b1_retry_20260813_192153.jsonl`, match
`M_9a933b08`. The combat session started cleanly, but the retained
current-match MATCH_START DTO disappeared before the controller's first
post-Board runtime scan. No opening board was accepted; at the four-second
timer margin the controller paused `OPENING_STATE_UNAVAILABLE_BEFORE_TIMER_MARGIN`.
The user returned to lobby. The summary proved zero input and a clean
`COMBAT_LIFECYCLE_ENDED` stop.

Opening capture now starts as soon as the direct MatchService CurrentMatchId
changes from its lobby value, before the heavier Board/provider lifecycle
poll. The exact current-match MATCH_START payload is fully decoded to a local
64-cell immutable snapshot, then offered only after the real Board-derived
CombatSessionKey exists and its match ID agrees. Cross-match or invalid data
still fails closed. Regression remains `184/184 PASS`.

## Stage B1 live retry 2 — PASS

Evidence: `logs/phase2c2b_stage_b1_retry2_20260813_192736.jsonl`, match
`M_164ad55f`. The early current-match preload retained and decoded the exact
64-cell MATCH_START board, then the real combat provider published it after
two stability confirmations and emitted `OPENING_BOARD_READY` at turn 1,
server sequence 3.

The controller sent exactly three bounded, safe SWAP actions:

- turn 1, sequence 3: Sword `(6,3) -> (6,4)`, acknowledged at sequence 5;
- turn 3, sequence 7: Rage `(0,4) -> (1,4)`, acknowledged at sequence 9;
- turn 5, sequence 11: Rage `(4,6) -> (4,7)`, acknowledged at sequence 13.

For every consuming action the read-only turn tracker observed an explicit
boss turn followed by a distinct return to the local player: turns 2/3, 4/5
and 6/7. After the third terminal `SWAP_ACKNOWLEDGED`, the controller emitted
`AUTO_STOP_AFTER_ACK` before another policy decision and stopped with no
pending action. The summary records three inputs, three consuming actions,
three unique executed identities and zero duplicate, misclick, partial,
wrong-turn, stale, expired or sequence-desync events. PASS, automatic exit,
automatic re-entry, memory writes, direct game calls and network manipulation
all remained disabled.

The user's observation that the boss acted three times and then automation no
longer acted is consistent with this deliberate Stage B1 bound. Stage B1 is
complete; stop here for review before any Stage B2/B3 or full-match expansion.

## Stage B2 implementation

Stage B2 raises only the bounded acceptance envelope: ten terminal consuming
SWAP/CAST actions in one combat, with a separate twenty-input ceiling including
EVOLVE attempts. The defaults and CLI validation reject more than 10/20 and
the tenth action still stops only after its terminal result with
`AUTO_STOP_AFTER_ACK`; action 11 is never prepared.

All Stage B1 lifecycle, source-identity, fresh reread, turn-transition,
foreground, timer, sequence and pending-action guards remain unchanged. EVOLVE
now requires a positive actual `LocalFusionManaCost`; the previous inferred
160 fallback is removed from both policy and executor. CAST rejection is
terminal and auto-pauses. A response timeout clears the consuming transition
lock and auto-pauses. A partial one-click SWAP permanently consumes its action
identity and total-input budget, emits `SWAP_REJECTED`, and cannot be retried.
CAST is never classified accepted from a response alone at combat teardown;
the durable used/turn transition remains mandatory.

Offline regression after Stage B2 implementation: `188/188 PASS`. Python
compile, actual CLI parsing, bounded default validation and rejection of caps
above 10/20 also PASS. Live evidence remains pending.

## Stage B2 live attempt 1 — PARTIAL/SAFE-STOP

Evidence: `logs/phase2c2b_stage_b2_acceptance_20260813_194803.jsonl`, match
`M_bdd0ed14`. The controller published the exact 64-cell opening and sent two
consuming SWAP actions from distinct current sources:

- turn 1, sequence 1, hash `68681a689978182720c2da53692fe464445d581fc3c98aaec7a596863859a555`:
  mandatory opening SWAP `(3,2) -> (3,3)`, acknowledged;
- turn 3, sequence 7, hash `8c8bd6efb4b27b8223621642d0319fe32f6d6a87eaf25d8d64d9f813d7c9ba02`:
  Mana SWAP `(3,1) -> (4,1)`, acknowledged.

Both actions had explicit `OPPONENT_TURN -> LOCAL_TURN_RETURNED` evidence. On
turn 5, sequence 11, the fresh board hash was
`d22ac31d931322b33e6506ffc8d66d343ec0164962b2f5a5203fcb5971ca3e9d`.
There were 14 legal moves and one safe move, but no safe Sword, Mana, Rage,
Shield or Drain resource candidate; only one safe Health candidate existed
while the BASIC higher-priority health condition was not active. Boss mana was
0 and boss rage 10. This is exactly the user-undefined intermediate resource
state, so policy returned `UNDEFINED_BASIC_FALLBACK` and the controller
auto-paused `BASIC_INTERMEDIATE_FALLBACK_UNDEFINED` with one beep. It did not
force the sole safe move or invent a generic fallback.

The user then pressed F9, producing the final process stop reason
`EMERGENCY_STOP` with no pending action. Counters: 2 total inputs, 2 consuming
actions, 2/2 SWAP ACK, 0 EVOLVE, 0 CAST, 4 turn-transition events, 3 distinct
decision source hashes, 0 duplicate, misclick, partial, wrong-turn, stale,
expired, timer skip, PASS_REQUIRED, POLICY_NO_SAFE_MOVE, DEAD_BOARD or
SEQUENCE_DESYNC, and 1 undefined-policy safe pause. EVOLVE failure/success and
CAST coverage are `NOT_OBSERVED` because their real conditions did not occur.

Classification: `PARTIAL/SAFE-STOP`, not controller failure and not a strong
ten-action PASS. No policy change is made to force progress. A retry must begin
from a clean lobby and a new combat session.

## Stage B2 live retry 2 — PARTIAL/SAFE-STOP, EVOLVE_FAILED observed

Evidence: `logs/phase2c2b_stage_b2_retry2_20260813_195237.jsonl`, match
`M_f404c10e`. Four distinct consuming SWAP actions on turns 1, 3, 5 and 7 were
all acknowledged and each had an explicit boss/local transition pair. On turn
9, sequence 19, the policy selected EVOLVE from a fresh current board with
player mana 385, actual Fusion cost 160, a current interactable Fusion UI and
12 seconds remaining. Exactly one EVOLVE click was sent.

The monitor captured the authoritative local `MATCH_FUSION_RES` with
`success=false` immediately after the click. This is genuine live
`EVOLVE_FAILED` coverage. The then-current controller incorrectly waited for
optional `LocalFusionLastAttemptTurn`/turn-lock telemetry as an additional
failure witness and timed out after nine seconds, producing one pause beep and
`ACTION_EXPIRED`. No later automatic input was sent. The combat later ended in
lobby and the controller stopped with no pending action.

The classifier now treats a current-match local `MATCH_FUSION_RES
success=false` as terminal `EVOLVE_FAILED` immediately, then requires a fresh
complete GameState before policy can retry or continue. EVOLVE success remains
strict: `success=true` alone is insufficient and must still be accompanied by
the durable MatchService-owned `fusion.used=true` transition. Regression tests
cover both asymmetric rules.

Attempt counters: 5 total inputs, 4 consuming actions, 4/4 SWAP ACK, one EVOLVE
attempt with one authoritative failure response, 0 CAST, 8 transition events,
0 duplicate, misclick, partial, wrong-turn, stale, PASS_REQUIRED,
POLICY_NO_SAFE_MOVE, DEAD_BOARD or SEQUENCE_DESYNC. Classification remains
`PARTIAL/SAFE-STOP`; the failure-result handling bug is corrected. Regression
after correction: `190/190 PASS`; Python compile PASS.

## Stage B2 live retry 3 — PARTIAL/SAFE-STOP

Evidence: `logs/phase2c2b_stage_b2_retry3_20260813_195842.jsonl`, match
`M_7ae9cf62`. Three SWAP actions on turns 1, 3 and 5 were acknowledged from
distinct source boards, with three explicit boss/local transition pairs. On
turn 7, sequence 15, hash
`a85b5446406da4b6d7597bb1bd1f390128d2585fa1ba6865a21552b0ea55161b`,
the controller observed seven legal moves and five safe moves. The player had
84/1563 mana and 140/250 rage; the boss had 0/445 mana and 15/250 rage. The
only safe resource branch was Rage (five candidates), but the user's BASIC
rule selects safe Rage in this part of Step 3 only when local rage is below
100. No Sword, Mana, Shield, Health or Drain safe candidate was available.

Policy therefore returned `UNDEFINED_BASIC_FALLBACK`; the controller emitted
one pause beep and sent no further input. This is the explicitly required
fail-closed behavior: it did not broaden the policy, choose an arbitrary safe
Rage move, or force progress toward ten actions. Classification is
`PARTIAL/SAFE-STOP`. The user pressed F9 and returned to lobby; the final
summary recorded `EMERGENCY_STOP`, no pending action, 3/3 SWAP ACK, zero input
errors and one undefined-policy pause.

## Controller architecture

```text
MemoryBoardStateProvider (read only)
  -> lifecycle / sequence guard / ActionabilityGate
  -> existing BasicPolicyEngine
  -> fresh-state policy revalidation
  -> autonomous action identity + one pending lock
  -> normal foreground input: EVOLVE | SWAP | CAST
  -> server response / ACK / durable-state correlation
```

The identity includes session, match, source `srvSeq`, board hash, turn,
current player, action and target. A state change or different fresh decision
invalidates the action before input. Only one consuming action is allowed per
session/turn.

## EVOLVE

EVOLVE requires BASIC Step 1, enough real mana, unused/unlocked Fusion state,
exactly one current live `FusionCardUI`, `Button.interactable=true`, fresh
visual tile sanity and full actionability. After one click the controller
waits for local `MATCH_FUSION_RES` plus the corresponding durable
`LocalFusionUsed` or last-attempt/turn-lock transition. Failure may be retried
only after the lock clears and a fresh actionable state is republished. Success
forces a complete reread before any SWAP.

## CAST

CAST is selected only by the existing BASIC Step 5. The runtime-selected card
must be Attack type, current Board/Active-owned, interactable, unused,
non-pending and affordable by its actual positive `mana_cost`, otherwise
`condition_use`. No card ID is hard-coded. Acceptance requires a local
`MATCH_CARD_USE_RES`/`MATCH_SKILL_USE_RES` plus durable used/turn transition.
The source turn is locked against a later SWAP.

## SWAP

SWAP reuses the Phase 2C.1 foreground two-click executor and coordinate
pipeline. State, policy, session, turn, sequence, hash, board stability,
lifecycle, modal, timer, foreground window and adjacency are revalidated just
before input. It waits for a strictly newer validated `_ackedSeqs` witness.
The identity is never retried.

## Pause, timer and recovery

- Minimum fresh-action time defaults to four seconds; low time never chooses a
  dangerous fallback.
- F7 pause/resume; F9 stops and prevents future input immediately.
- Manual user state changes invalidate stale source/decision data.
- PASS remains disabled and produces `PASS_REQUIRED_BUT_DISABLED` + pause.
- `POLICY_NO_SAFE_MOVE` pauses and saves a board artifact.
- DEAD_BOARD and SEQUENCE_DESYNC lock gameplay, save evidence and require the
  already accepted user-confirmed F10 recovery flow.
- Automatic exit and automatic re-entry remain disabled.

## Stage A results

The first two live-entry attempts sent zero input. The controller never emitted
`combat_session_started` or `policy_decision`. Evidence from
`logs/phase2c2b_stage_a_20260813_170055.jsonl` plus a read-only in-combat probe
isolated `lobby_batch_baseline_unavailable`: `WsCombatBatch` was initialized in
the boss lobby while the optional `BoardWsApplier` type-info was not, so the
lobby fingerprint was never marked ready. The fingerprint now requires only
the batch class; `BoardWsApplier` remains an optional region-learning needle.

The same trial exposed an F9 exception: `stop()` had been indented into
`ConsumingTurnRegistry` instead of `AutonomousGuard`. The method and a
regression test are now on the correct class. F9 is also rechecked after slow
provider/fresh-state reads and immediately before each gameplay input.

The next clean lobby-entry trial proved the baseline fix, then exposed a
second opening-only transition. `CurrentMatchId` and turn became current while
`LocalSeqNum` had reset to zero but `LastMoveSeqNum` still held the previous
match's value. This exact game ordering was already documented and handled by
`idle_state_watch.read_match_runtime`: the optional `LastMove*` telemetry is
UNKNOWN until internally consistent. `MemoryBoardStateProvider` now reuses
that semantics. It does not reinterpret the stale value, relax ACK validation,
or synthesize coordinates. The second trial again sent zero input, and the
corrected F9 path stopped cleanly with status `STOPPED` and no exception.

These earlier attempts left Stage A runtime-pending until the authoritative
MATCH_START opening path below was implemented and validated.

The following read-only opening probe then captured the missing authoritative
source in `logs/opening_snapshot_live_20260813_174320.jsonl`:

- current match `M_a7be4775` published `MATCH_START` with a 33-key
  `matchPayload` containing `board`, `srvSeq`, `turnNumber=1` and the local
  current player;
- `_ackedSeqs` was empty before the first move. Native `SendAnimAck` proves
  only that values `<= 0` are ignored; the later positive opening value proves
  that rule alone does not explain why this specific MATCH_START is unacked;
- after the user's manual first move, a complete 64-cell `WsCombatBatch`
  appeared at `srvSeq=5` and `LastMoveSeqNum/LocalSeqNum` became 1.

The next live decode attempt (`M_3521bb40`) retained the boxed `srvSeq` object
from that payload and proved its value is **3**, while `LocalSeqNum` was zero
and the first post-move batch was sequence 5. The earlier assumption that
opening `srvSeq` itself was zero was therefore false: the zero belongs to the
local move sequence, not the server transport sequence.

The opening board is therefore decoded only from the exact current-match
`ChatMessageDTO.MATCH_START.matchPayload["board"]` Newtonsoft `JArray`. It must
have a nonnegative boxed `srvSeq`, exact 8x8 shape, exact
`row/col/tag/multiplier` properties and
all canonical DTO semantics. It is session-bound and accepted only while the
game still reports opening local sequence zero and no positive last move. The
normal ACK-attested path remains unchanged for every post-opening board.

Offline regression with this opening path: `177/177 PASS`.

The next retry (`logs/opening_snapshot_verify_retry_20260813_181931.jsonl`)
decoded two retained current-match MATCH_START DTOs at server sequences 1 and
3. Both contained the same complete 64-cell board and the same canonical hash;
the provider accepted them without any input. The user's manual move occurred
before two provider stability polls completed, so this run correctly reported
`stable_published=0`. The probe now prioritizes those two polls ahead of its
slower diagnostic batch scan and can emit two tones only after a stable opening
GameState is actually published.

The final read-only validation
(`logs/opening_snapshot_publish_beep_20260813_182817.jsonl`) completed the
opening milestone for match `M_05bd0654`:

- the exact current-match MATCH_START board decoded as 64/64 canonical cells
  at `srvSeq=3`, hash
  `b7c0aa7759469eb3395273b09cb3382f327545158ef50dbb70e81edc6edfc1e6`;
- provider state advanced through `awaiting_stability_confirmation` and then
  `stable_match_start_opening_dto` with two confirmations;
- the published state still had local move sequence zero, no previous move,
  turn 1, and the local player as current player;
- only after publication did the probe emit its two diagnostic tones; it sent
  no game input;
- the user's subsequent manual move changed local sequence 0 -> 1 and current
  player to the boss, while the probe observed the first post-opening batch.

The missing-first-board blocker is therefore resolved for the read-only state
pipeline. The separate live input acceptance is recorded below.

The first live input acceptance on match `M_beab3205` proved that the opening
state can drive normal game input: a two-click SWAP from `(6,7)` to `(7,7)`
was sent from the stable opening hash and later received
`SWAP_ACKNOWLEDGED`. The then-current controller was scoped to one combat and
therefore also sent an ACKed SWAP on turn 3 before it was externally stopped.
That second action was valid gameplay but exceeded the intended one-action
acceptance scope. Stage A now has an explicit `--max-actions` hard cap; it
waits for the capped action's terminal result, logs `action_budget_reached`,
and stops before another policy decision can produce input.

The bounded acceptance retry
(`logs/phase2c2b_stage_a_one_action_20260813_184313.jsonl`) passed all Stage A
invariants on match `M_31ed930d`:

- exact current-match 64-cell opening state reached two stability
  confirmations;
- exactly one policy decision selected SWAP `(3,3) -> (3,4)` from turn 1,
  `srvSeq=1`, hash
  `4649cd41ef4ad0d0220acb54c193d4378d76b9313db3f6c6c5257101f269acbf`;
- exactly one `action_sent` was emitted, followed by exactly one terminal
  `SWAP_ACKNOWLEDGED` at new sequence 5;
- `action_budget_reached` recorded `maxActions=1`, `sentActions=1`, then the
  summary recorded `STOPPED`, no pending action and one executed identity;
- duplicate/misclick/partial/wrong-turn/stale/expired/desync counters were all
  zero; PASS, automatic exit/re-entry, memory writes, direct game calls and
  network manipulation were all false;
- the three later decode rejections came from one transient/invalid retained
  MATCH_START object and failed closed; they did not replace the already
  accepted opening snapshot or cause input.

Stage A is complete. This result does not authorize full-auto, PASS, automatic
recovery/re-entry, or any Phase 2D/other expansion.

## Files

Created:

- `src/pokiguard_v2/autonomous_control.py`
- `src/pokiguard_v2/gameplay_ui.py`
- `tools/basic_auto_bot.py`
- `tests/test_autonomous_control.py`
- `tests/test_memory_provider_baseline.py`
- `docs/phase2c2b_runbook.md`
- `docs/phase2c2b_report.md`
- `src/pokiguard_v2/opening_snapshot.py`
- `tools/opening_snapshot_probe.py`
- `tests/test_opening_snapshot.py`

Modified:

- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/basic_policy.py`
- `src/pokiguard_v2/win32_input.py`
- `tools/sequence_desync_runtime.py`
- `tests/test_basic_policy.py`
- `src/pokiguard_v2/actionability.py`

## Tests

Offline regression after the live-entry fixes: `177/177 PASS`. Lobby smoke attached to PID 2184, remained
in `WAITING_FOR_COMBAT`, sent zero input, and exited on its three-second
diagnostic timeout (`logs/phase2c2b_lobby_smoke_final.jsonl`). The bounded live
Stage A milestone is complete; stop here for user review before any broader
runtime milestone.
