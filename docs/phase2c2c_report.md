# Phase 2C.2C report

Status: implementation/offline regression PASS. Live acceptance P0, P1, P2
and P3 PASS. Phase 2C.2C acceptance is complete. Stage B3 has not been
restarted.

## 1. Authoritative PASS state model

The model exposes `UNKNOWN`, `RESET_BASELINE_CONFIRMED`, `PASS_ALLOWED` and
`PASS_FORBIDDEN_MANDATORY_ACTION`. Numeric `idle_count/threshold` enter only
through an exact server payload. A certified accepted consuming action creates
a non-numeric reset baseline; it never writes a synthetic zero.

## 2. Exact server sources

- direct `MATCH_AFK_WARN`
- nested `MATCH_TURN_END.matchPayload.afkWarn`

Both require the local username and valid numeric pair. Nested events must
match the current runtime turn. A direct event can finish PASS_WAIT only when
newly observed after PASS start, after the local turn ended, and its server
timestamp is not older than the PASS start. The next local turn receives an
explicit PASS_WAIT correlation without changing the numeric value.

## 3. SWAP reset confidence/result

Runtime result: PASS on retry4, match `M_37fbec89`, process 8980. Two distinct
ordered cycles reached `RESET_CONFIRMED_BY_SERVER_SEQUENCE`: accepted SWAP at
local turn 5 -> authoritative `1/3` at turn 9, then accepted SWAP at turn 9 ->
authoritative `1/3` at turn 13. The capability artifact records `swap` at 2/2
confirmations with `productionReady=true`. Source log:
`logs/phase2c2c_p0_reset_retry4_20260814_153442.jsonl`; capability:
`logs/phase2c2c_reset_capabilities.json`.

## 4. CAST reset confidence/result

Current classification: `RESET_UNKNOWN` for production. The existing earlier
single controlled observation remains insufficient. CAST may still be used as
normal consuming gameplay, but PASS fails closed afterward unless a separately
audited CAST capability exists.

## 5. EVOLVE idle semantics

EVOLVE is non-consuming. Success/failure preserves a still-fresh exact idle
observation, never becomes a reset candidate, and still requires a same-turn
SWAP/CAST/PASS decision. Lifecycle/sequence invalidation still clears it.

Stage B5 runtime addendum: when a terminal EVOLVE attempt (success or failure)
is followed by a same-turn PASS decision, the server may advance without any
AFK payload. That remainder is now an `EVOLVE-only turn`, not an intentional
PASS: zero additional input, no PASS accounting/coordinator, and a fresh reread
on the next local turn. EVOLVE reset remains UNKNOWN and no numeric idle state
is synthesized.

## 6. P1 result

PASS on retry1. The controller entered `PASS_WAIT`, sent zero gameplay input,
and accepted the exact nested `MATCH_TURN_END.matchPayload.afkWarn` value `1/3`
at turn 5. Terminal result was `PASS_CONFIRMED_IDLE_1`; the summary recorded
exactly one confirmed autonomous PASS, zero unconfirmed/aborted PASSes and
`P1_ONE_AUTONOMOUS_PASS_CONFIRMED`. Safety telemetry was zero for duplicate,
misclick, partial, wrong-turn, stale, boss-turn, postmatch, lobby and
after-combat input. Source log:
`logs/phase2c2c_p1_retry1_20260814_164402.jsonl`.

The earlier rejected P1 attempt entered `PASS_WAIT` at turn 13 and sent zero
gameplay input, but a transient provider result
(`presentation_busy_or_batch_pending`, no lifecycle observation) was
incorrectly mapped to `PASS_ABORTED_COMBAT_END`. MatchService still held the
same match and subsequent runtime turns proved combat remained active. The
controller now represents a missing lifecycle classification as UNKNOWN; only
explicit non-ACTIVE evidence or loss of `CurrentMatchId` can classify combat
end. Regression coverage was added before the successful retry.

## 7. P2 result

PASS on retry9. Earlier rejected attempts are retained below as diagnostic
evidence. The first P2 attempt was rejected before any PASS: at
local turn 7 the provider reported `ambiguous_latest_sequence` and could not
publish a stable current board before the fail-closed four-second action
deadline. The controller emitted `LOCAL_TURN_ACTION_DEADLINE`; autonomous PASS
count remained zero. Source log:
`logs/phase2c2c_p2_20260814_165002.jsonl`.

P2 retry1 was also rejected before any PASS. At local turn 17 the direct-owner
capture/ACK fallback raised cumulative ACK heap scans from 1 to 3; the exact
board became stable only when the game timer had reached 5 seconds, so the
six-second warning gate emitted `LOCAL_TURN_ACTION_DEADLINE`. No PASS was
started and this run is not counted. Source log:
`logs/phase2c2c_p2_retry1_20260814_165453.jsonl`.

P2 retry2 sent zero input for its first PASS and observed the exact direct
`MATCH_AFK_WARN 1/3`, but the DTO arrived at the final timer tick while
MatchService still exposed source turn 11. The coordinator correctly waited
for durable turn ordering, but then failed to retain/re-correlate that exact
direct DTO when turn 13 appeared and stopped `PASS_STATE_UNCONFIRMED`. The run
is rejected despite the retrospective server evidence. The coordinator now
retains a validated direct warning only within the active PASS attempt and
finishes it after the subsequent runtime turn proves ordering; session/input/
desync checks still run first. Regression suite after the fix: `272/272 PASS`.
Source log: `logs/phase2c2c_p2_retry2_20260814_170311.jsonl`.

P2 retry3 confirmed the first zero-input PASS from the exact direct
`MATCH_AFK_WARN 1/3` and durable turn ordering. The coordinator result was
`PASS_CONFIRMED_IDLE_1`, but the controller's runtime-observation terminal
branch incorrectly classified every terminal as a stop condition, emitted the
three-tone alert and stopped before the required second PASS. This run is
rejected as P2 acceptance even though its first PASS evidence is valid. The
runtime and message terminal paths now share one disposition function: P2
continues silently after confirmed idle 1 and stops only after confirmed idle
2; failures still stop closed. Source log:
`logs/phase2c2c_p2_retry3_20260814_171930.jsonl`.

P2 retry4 entered its first zero-input PASS at local turn 7, but a provider
board/ACK fallback poll then occupied approximately 12 seconds
(`10:26:22.991Z` -> `10:26:35.016Z`). That interval covered the transient AFK
warning window, so no exact `MATCH_AFK_WARN` or nested `afkWarn` was captured.
The coordinator correctly failed closed as `PASS_STATE_UNCONFIRMED` on the
next local turn; this was the user's reported three-tone alert and is not a
confirmed idle 1. During PASS_WAIT the controller now defers every heavy
provider/ACK scan and runs only the already-separate direct MatchService and
ChatMessageDTO observation path. No board is needed and no policy/input can be
evaluated while PASS_WAIT is locked. Source log:
`logs/phase2c2c_p2_retry4_20260814_172517.jsonl`.

P2 retry5 proved the runtime-only observation fix: the first PASS at turn 17
captured direct `MATCH_AFK_WARN 1/3`, used zero input and completed
`PASS_CONFIRMED_IDLE_1`. The policy then selected an accepted SWAP at turn 19,
which authoritatively began a new reset cycle. A later PASS at turn 21 correctly
produced server `1/3`, but the coordinator incorrectly retained its prior
session-wide PASS index and expected `2/3`, so it failed closed. The user's
observation that the two skips were separated was exact. The coordinator's
bounded index is now reset after every certified consuming SWAP/CAST; only an
uninterrupted `1/3 -> 2/3` sequence can complete P2. Source log:
`logs/phase2c2c_p2_retry5_20260814_173046.jsonl`.

P2 retry6 completed the combat (user-reported win) without a safety alert. It
captured two valid zero-input `PASS_CONFIRMED_IDLE_1` results at turns 37 and
47, but accepted consuming actions reset the server sequence after each, so no
`2/3` occurred. This validates the corrected per-reset-cycle accounting but
does not satisfy P2. Because natural BASIC play has a low probability of
choosing two PASSes consecutively before a win, an explicit test-only CLI
trigger can now force consecutive PASS decisions after five server-accepted
consuming actions. It remains gated by the authoritative readiness and all
existing safety checks, is disabled by default, and is unavailable outside
P2/P3. Source log: `logs/phase2c2c_p2_retry6_20260814_173633.jsonl`.

P2 retry7 deterministically sent zero input on two consecutive local turns
after five accepted SWAPs. The first direct warning was captured and confirmed
as `1/3`. The second PASS occurred, but its transient direct `2/3` DTO was not
captured; only the earlier first-PASS nested `MATCH_TURN_END 1/3` remained, so
the coordinator failed closed on the next local turn. This run is not P2 PASS.
The message monitor previously scanned only learned allocation regions between
periodic full scans; a new warning DTO can land in another bounded candidate
region at the final tick. PASS_WAIT now forces every ChatMessageDTO scan across
all bounded candidate regions, while the unrelated board/ACK provider remains
deferred. Two full next-local scans are still required before missing evidence
can fail closed. Source log:
`logs/phase2c2c_p2_retry7_20260814_175531.jsonl`.

The original P2 retry8 ended on a user-reported server disconnect after five
accepted actions and before any PASS began, so it is excluded. Source log:
`logs/phase2c2c_p2_retry8_20260814_180202.jsonl`.

P2 retry8 reconnect1 reached the forced first PASS, but the new full scan
surfaced a stale/reused `MATCH_MOVE_RES` object whose decoded sequence was 4
and whose timestamp field contained unrelated UI text (`Ping/FPS`). It was
incorrectly treated as a new manual local action and aborted PASS_WAIT, even
though the user sent no action. A server activity DTO can now abort PASS_WAIT
only when its parseable server timestamp is not older than the attempt start;
the direct MatchService local-move-sequence check remains the independent
manual-SWAP detector. Malformed/stale activity is logged and ignored. Source
log: `logs/phase2c2c_p2_retry8_reconnect1_20260814_180435.jsonl`.

P2 retry9 is the accepted live result. After five server-accepted consuming
SWAPs, the acceptance-only trigger selected two consecutive zero-input PASSes.
The server reported direct `MATCH_AFK_WARN 1/3` for pass index 1 at source turn
11, followed by direct `MATCH_AFK_WARN 2/3` for pass index 2 at source turn 13.
Both `pass_result` records contain `gameplayInputsDuringWait: 0`. The controller
then stopped before a third PASS with
`P2_TWO_AUTONOMOUS_PASSES_CONFIRMED`. Final counters were
`auto_pass_started=2`, `pass_confirmed_idle_1=1`,
`pass_confirmed_idle_2=1`, `pass_state_unconfirmed=0`, `pass_aborted=0`,
`pass_gameplay_inputs=0`, and `wrong_third_pass=0`; all input safety telemetry
counters were zero. Source log:
`logs/phase2c2c_p2_retry9_20260814_180909.jsonl`.

## 8. P3 mandatory reset result

P3 attempt 1 was rejected. The controller sent and acknowledged two
SWAPs, then BASIC selected a zero-input PASS at turn 5 because the board had
eight legal moves but no move classified safe. PASS_WAIT began with
`localMoveSequence=2`, but a later direct runtime sample exposed a lower value
and the previous inequality check misclassified that non-monotonic read as a
manual action. The user confirmed no action was sent. A read immediately after
the stop exposed `localMoveSequence=0`, proving the observed direction was a
decrease rather than the increment produced by a local SWAP. This run is
rejected with `PASS_ABORTED_USER_ACTION`; no PASS was counted and no P3 reset
was attempted. The guard now treats only a strictly increased local move
sequence as independent manual-action evidence. A decreased value remains
fail-closed for state publication but cannot by itself claim user input.
Regression coverage includes the exact `2 -> 0` case. Source log:
`logs/phase2c2c_p3_20260814_181348.jsonl`.

P3 retry1 is excluded because the user moved the game out of the foreground.
The actionability gate correctly blocked input with `GAME_NOT_FOREGROUND` and
then paused at `LOCAL_TURN_ACTION_DEADLINE`. No autonomous PASS began. The
combat later ended with five acknowledged SWAPs and zero safety telemetry.
Source log: `logs/phase2c2c_p3_retry1_20260814_182015.jsonl`.

P3 retry2 is the accepted live result. After five certified consuming actions,
the acceptance trigger produced two consecutive zero-input PASSes. Direct
`MATCH_AFK_WARN` reported `1/3` at source turn 11 and `2/3` at source turn 13.
At turn 15 the mandatory action was an acknowledged SWAP (`srvSeq=33`), whose
reset baseline retained the prior authoritative `2/3`. A later zero-input PASS
was then correlated with nested `MATCH_TURN_END.matchPayload.afkWarn 1/3` at
source turn 19, proving the reset. The controller stopped with
`P3_MANDATORY_RESET_CYCLE_CONFIRMED`. Final counters were
`auto_pass_started=3`, `pass_confirmed_idle_1=2`,
`pass_confirmed_idle_2=1`, `mandatory_reset_actions=1`,
`pass_state_unconfirmed=0`, `pass_aborted=0`, `pass_gameplay_inputs=0`, and
`wrong_third_pass=0`; all input safety telemetry counters were zero. Source
log: `logs/phase2c2c_p3_retry2_20260814_182141.jsonl`.

## 9. PASS input count

Offline result: zero. The rejected first P1 runtime attempt also recorded zero
gameplay inputs during `PASS_WAIT`. `AuthoritativePassCoordinator` has no input dependency;
the controller PASS branch starts PASS_WAIT and immediately continues without
calling either foreground executor method.

## 10. Idle warning values observed

Historical runtime evidence contains `1/3` and `2/3`. P0 retry4 observed exact
server-owned `1/3` payloads and did not synthesize zero. Threshold is always
taken from the payload, never hard-coded by the memory provider.

## 11. Kick/out count

P0 acceptance window: zero kicks/outs before the 2/2 capability was committed.
The earlier retry3 was explicitly rejected as a clean acceptance run after the
user reported a mistaken sequence and the server later reported `2/3`.

## 12. Wrong third-PASS count

Offline deterministic result: zero. Both server readiness and the bounded
coordinator reject a third PASS; the controller records
`WRONG_THIRD_PASS_BLOCKED` if policy ever contradicts that invariant.

## 13. Session freshness behavior

Match/session changes, lifecycle exit, lobby/postmatch and sequence-desync
clear current idle/baseline state. Stale nested event turns are rejected.
Reset capability proofs are process-level audited evidence, not match idle
state, and are loaded only from a validated P0 artifact.

## 14. Sequence-desync interaction

Terminal desync during PASS_WAIT produces `SEQUENCE_DESYNC`, clears idle state,
locks gameplay and enters the existing manual-confirmed recovery path. No
consuming rescue input is sent.

## 15. Phase boundary

There are no remaining Phase 2C.2C acceptance blockers. P0, P1, P2 and P3 are
all complete. Stage B3 remains stopped at this phase boundary and must be
started only by an explicit next-phase instruction.

## 16. Tests

Offline suite after hardening non-monotonic PASS_WAIT runtime sequence reads:
`279/279 PASS`. Coverage
includes reset proof/capability,
rejected action, EVOLVE preservation, stale/session handling, first turn,
zero-input PASS, manual abort, desync abort, missing-warning failure, bounded
one/two PASS and mandatory policy behavior. A dedicated regression proves that
P2 confirmed idle 1 continues while confirmed idle 2 stops.
An additional regression proves that PASS_WAIT cannot invoke the heavy
provider poll, and another proves that a consuming reset restarts the expected
idle sequence at 1. The acceptance-only forced-PASS trigger has deterministic
enable/disable and authoritative-gate coverage. A monitor regression proves
forced PASS_WAIT scans include newly allocated candidate regions outside the
previously learned region set. Stale/malformed activity timestamps surfaced by
a full scan cannot abort PASS_WAIT.

## 17. Files changed

Created:

- `src/pokiguard_v2/authoritative_pass.py`
- `src/pokiguard_v2/reset_evidence_store.py`
- `tools/authoritative_pass_probe.py`
- `tests/test_authoritative_pass.py`
- `tests/test_reset_evidence_store.py`
- `docs/phase2c2c_runbook.md`
- `docs/phase2c2c_report.md`

Modified:

- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/game_owned_idle.py`
- `src/pokiguard_v2/basic_policy.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/__init__.py`
- `tools/basic_auto_bot.py`
- `tools/sequence_desync_runtime.py`
- `tests/test_game_owned_idle.py`
- `tests/test_basic_policy.py`
- `tests/test_autonomous_control.py`
