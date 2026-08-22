# PokiguardToolV2 Current State

Canonical technical handoff as of **2026-08-22 (Asia/Saigon)**.

Read [AGENTS.md](../AGENTS.md) first. User-defined gameplay/product rules are
canonical in [DECISIONS.md](DECISIONS.md). This file contains current accepted
technical state; use linked phase reports for detailed evidence.

## Source-of-Truth Hierarchy

1. [AGENTS.md](../AGENTS.md) — agent, workspace, and safety rules.
2. [DECISIONS.md](DECISIONS.md) — gameplay/product decisions defined or
   approved by the user.
3. This file — latest accepted technical state.
4. Latest phase-specific reports — detailed acceptance evidence.
5. Logs, reference artifacts, and tests — raw/runtime evidence.
6. Old/superseded reports — historical evidence only.

When sources conflict, identify which is newer; do not silently merge them or
rewrite history. Technical implementation does not silently override a user
decision in `DECISIONS.md`.

## Project Status

| Item | Current state |
|---|---|
| Current completed phase | **Phase 2E.2 — PASS STRONG** |
| Next approved/planned phase | **Phase 2E.3 NOT IMPLEMENTED — await explicit approval** |
| Current controller status | **STOPPED** |
| Current live automation | **NONE** |

Phase 2E.2 connects the Phase 2E.1 desktop UI to the accepted Phase 2D.6
FarmRunner through one asynchronous controller and one authoritative command
owner. Start, Stop After Current Match, Emergency Stop, and durable checkpoint
Resume are live, bounded, and fail closed. Start foregrounds the verified game
PID before normal input; graceful stop drains the current match and returns
focus to the game, while emergency stop invalidates future actions immediately
and never synthesizes an unfinished result.

Live UI acceptance passed every required stage. B1 completed exactly 1/1 WIN.
B2 stopped gracefully after the current WIN at exact `BOSS_LOBBY`, with no
second entry. B3 resumed a durable 1/5 lobby checkpoint and reached exactly
5/5 WINs without attempt 6. B4 acknowledged an emergency stop during active
combat and sent zero actions or entries after the ACK. B5 completed exactly
5/5 matches (4 WIN, 1 LOSS, 0 UNKNOWN), returned to exact `BOSS_LOBBY`, created
no attempt 6, and kept every safety aggregate at zero. Evidence:
[Phase 2E.2 report](phase2e2_report.md) and
[runbook](phase2e2_runbook.md).

Phase 2E.1 remains the accepted read-only UI/control-plane foundation. Its
offline and live observer evidence is retained in the
[Phase 2E.1 report](phase2e1_report.md) and
[runbook](phase2e1_runbook.md). There is still no hidden start-on-launch
behavior. Phase 2E.3 has not been implemented.

Phase 2D.6 accepted graceful stop, durable checkpoint/resume, and a 25-match
bounded soak. B1 artifact
`logs/farm_runs/dded65a91c9d4955b9614a1b61f40904/` proves F6 during
`ACTIVE_COMBAT` drained one STRONG/consistent WIN through postmatch to exact
`BOSS_LOBBY`, with zero entry after the request. Final invariant
`PHASE2D6_GRACEFUL_STOP_PROVEN`.

B2 Run A `dc1d191f369449deb422f1b3c7cc209b` stopped gracefully after two
completed WINs. Explicit resume `7afb954b302a4bdab59ff488bb56317f`
continued the historical accounting to 5/5 WINs, including one natural
dead-board technical abort/recovery that was not counted as completion. There
were no duplicate MatchIds or result counts. Final invariant
`PHASE2D6_CHECKPOINT_RESUME_PROVEN`.

B3 artifact `logs/farm_runs/6f8d890137604098b6ff4a066a20d4ec/`
completed exactly 25/25 unique matches in 25 attempts: 24 WIN, 1 LOSS, 0
UNKNOWN, 25/25 consistent memory/UI results, 0 technical aborts/recoveries,
and every safety counter zero. It returned to exact `BOSS_LOBBY`, stopped with
`FARM_TARGET_COMPLETED`, and created no attempt 26. Final invariant
`PHASE2D6_LONG_SOAK_PROVEN`. Evidence: [Phase 2D.6 report](phase2d6_report.md)
and [runbook](phase2d6_runbook.md).

Phase 2D.5 accepted both required live boundaries. Stage B1 artifact
`logs/farm_runs/4f1608ed395e44e8886244587a5bb9b0/` proves a frozen,
memory/lifecycle-backed terminal WIN before Board/Active ownership cleanup:
MatchId `M_d8d290a1`, local HP `64900/105228`, boss HP `0/84180`, confidence
STRONG, and a consistent `Thắng -> WIN` UI audit. It completed exactly one
match and stopped at the exact boss lobby before entry #2. Final invariant
`PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN`.

Stage B2 artifact
`logs/farm_runs/b63cd48b836c4aa6bb8f7092c06776aa/` proves the extended
bounded configuration `target_completed_matches=10`,
`max_technical_recoveries=2`, `max_match_attempts=14`. It used 10 attempts to
complete 10 unique matches: 10 STRONG memory WINs, 0 losses, 0 unknowns, and
10 consistent WIN UI audits. It returned to the exact boss lobby, stopped with
`FARM_TARGET_COMPLETED`, and reserved no entry #11. Technical aborts,
recoveries, result conflicts, input-after-stop, and every farm safety counter
were zero. Final invariant `PHASE2D5_EXTENDED_SOAK_PROVEN`. Natural technical
failure was `NOT_OBSERVED`; Phase 2D.4 remains the live recovery-resume proof.
Evidence: [Phase 2D.5 report](phase2d5_report.md).

Phase 2D.4 accepted both required live boundaries. Stage B1 artifact
`logs/farm_runs/fc396e1d55dc455390e752e57eb927b2/` proves one TEST_ONLY
technical recovery followed by a distinct current session, hardened fresh
opening, full-state/policy recomputation, one safe SWAP, exact ACK, and stop.
Final invariant `PHASE2D4_RECOVERY_RESUME_PROVEN`; failed MatchId
`M_a62e5f2f`, recovered MatchId `M_c52277e6`.

Stage B2 artifact
`logs/farm_runs/8a5ad3f5d02b4871b0baf1a22935a422/` proves bounded continuous farming with
limits `target_completed_matches=3`, `max_technical_recoveries=1`, and
`max_match_attempts=5`. It completed three unique matches, performed three
normal postmatch confirmations, returned to exact BOSS_LOBBY, and stopped with
`FARM_TARGET_COMPLETED` before entry #4. All farm safety counters are zero;
final invariant `PHASE2D4_BOUNDED_FARM_PROVEN`. Natural technical failure was
`NOT_OBSERVED`. Evidence: [Phase 2D.4 report](phase2d4_report.md).

The immutable B2 artifact's raw outcome subtype is `UNKNOWN/0 wins/0 losses`
because the provider cleared Board/Active ownership before publishing terminal
PlayerStats. All three stable result frames show `THẮNG` and boss HP 0, so the
audited result is 3 wins/0 losses alongside authoritative normal POSTMATCH
completion. Terminal PlayerStats are now captured before lifecycle cleanup;
missing evidence still fails closed to UNKNOWN. Phase 2D.5 subsequently
live-proved the correction in B1 and all ten B2 matches; this paragraph remains
the historical explanation for the immutable Phase 2D.4 artifact.

Phase 2D.3 accepted artifact `logs/technical_recovery/20260815_232743_777/`
proves one bounded automatic technical-recovery boundary: explicit TEST_ONLY
ACTIVE trigger, immediate gameplay lock, exactly one `<<`, exactly one stable
leave-modal `Đồng ý`, exact BOSS_LOBBY, old-session invalidation, exact
Starburst 1289, exactly one re-entry, a different MatchId/session/Board/epoch,
fresh MATCH_START opening 64/64, then hard stop before gameplay. Final invariant
`PHASE2D3_RECOVERY_BOUNDARY_PROVEN`; all gameplay, duplicate, wrong-target,
wrong-UI, and stale-session safety counters are zero. Production
`SEQUENCE_DESYNC` and exact zero-legal dead-board signals dispatch through the
same coordinator in captured replay/offline integration. Naturally occurring
live technical failure remains `NOT_OBSERVED`. Evidence:
[Phase 2D.3 report](phase2d3_report.md).

Phase 2D.2 attempt 3 (`20260815_203412`) structurally completed two entries and
one autonomous combat, but is **not live-accepted**. The user disclosed after
the run that they manually clicked `Đồng ý` on the result modal. Thus the logged
three-second `POSTMATCH -> LOBBY` transition is not an automatic-return proof.
The combat/session/input boundaries remain valid—entry inputs 2, sessions seen
2, sessions played 1, combat-2 inputs 0, and all recorded safety counters 0—but
postmatch ownership still needs a no-user-input retry. Evidence:
[Phase 2D.2 report](phase2d2_report.md).

Attempt 4 (`20260815_204412`) supplied that missing observation: with no user
input, authoritative POSTMATCH and the result modal persisted for 60 seconds.
Two captures prove the same WIN panel and sole `Đồng ý` control. A fail-closed,
resolution-independent locator and single-use `POSTMATCH_UI` capability are now
implemented offline; both real frames resolve the same normalized point with
confidence 0.98 and zero drift. This one-click path was subsequently
live-accepted by attempt 5.

Attempt 5 (`20260815_205707`) is the accepted Phase 2D.2 run. With no user
interaction, it completed combat #1, proved authoritative POSTMATCH across
three stable result frames, sent exactly one capability-owned `Đồng ý` click,
reacquired exact stable BOSS_LOBBY, entered a distinct session #2, and
hard-stopped at opening #2. Final invariant:
`accepted=true / PHASE2D2_BOUNDARY_PROVEN`; all safety counters and combat-2
inputs were zero. Evidence: [Phase 2D.2 report](phase2d2_report.md).

Post-acceptance, `--run-single-cycle` was added for the user's requested visible
demonstration: entry #1 -> one B5 combat -> exact returned BOSS_LOBBY -> hard
stop, with no entry #2 capability. First live attempt `20260815_213316`
safe-stopped after three acknowledged SWAPs because a pre-PASS SWAP reset proof
was incorrectly reused after PASS #1; the server correctly reported 2/3 while
the controller expected 1/3. No wrong-turn, duplicate, stale, foreground, or
post-combat input occurred. The reset correlation now requires the consuming
action's source turn to be strictly after the last confirmed PASS.

The user then explicitly approved reducing the local-turn deadline warning from
the prior six-second margin to the exact four-second actionability floor. The
controller may continue evaluation at 5+ seconds but still fail-closes at 4
seconds before sending an unacceptably late action.

The requested visible demonstration then passed on artifact
`logs/boss_farm_cycle/20260815_214234/`. The controller entered Starburst 1289,
completed one full B5 match, captured a visible `THẮNG` result with boss HP
`0/84180`, sent exactly one proven `Đồng ý` click, reacquired exact stable
BOSS_LOBBY, and hard-stopped without entry #2. Final invariant:
`accepted=true / SINGLE_CYCLE_RETURNED_LOBBY_PROVEN`; every farm safety counter
was zero.

## Current Architecture

```text
Pokiguard.exe
  -> ReadProcessMemory (external/read only)
  -> MemoryBoardStateProvider
  -> GameState
  -> deterministic board simulator / BASIC PolicyEngine
  -> ActionabilityGate + session/sequence/input guards
  -> normal foreground Windows UI/input
```

Farm-side accepted entry:

```text
Boss lobby
  -> exact target resolution
  -> one normal foreground Windows UI entry click
  -> new MatchId / CombatSessionKey
  -> accepted opening board + first local turn
  -> STOP
```

CV remains audit/reference/fallback, not the production board source. No
production path writes game memory, calls gameplay IL2CPP methods, or
manipulates network traffic.

## Production Board Source

Production source:

```text
WsCombatBatch.board / BoardCellDTO
```

Post-opening publication is current-session and highest-valid-ACK attested.
The opening-only bootstrap may use exact current-match
`ChatMessageDTO.MATCH_START.matchPayload.board`; it must still be 64/64,
stable twice, session-bound, first-local-turn state with local move sequence
zero. Normal post-opening ACK rules remain unchanged.

Accepted contract:

- exact 8x8, 64/64 cells, and 64 unique coordinates in `0..7 x 0..7`;
- exact known `GemType`; multiplier x1, x2, x3, or x4;
- valid `srvSeq` and SHA-256 `boardHash`;
- current session, latest state, lifecycle, render/stability, and ACK/opening
  validation;
- invalid/ambiguous/stale/incomplete/unknown state fails closed.

`Dot` is optional validation/telemetry, not a production requirement. CV is
audit/reference, not production. See [Phase 2B.5](phase2b5_report.md).

## Coordinate Model

All cells use zero-based `(row, col)`:

| Space | Meaning |
|---|---|
| Runtime/DTO | Bottom-origin row; column unchanged. |
| Provider `BoardState` | Top-origin visible-board row. |
| Solver | Same top-origin coordinates as provider. |
| Screen/click | Same cell coordinates as solver, then current client geometry. |

```text
providerRow = solverRow = screenRow = 7 - runtimeRow
providerCol = solverCol = screenCol = runtimeCol
```

`live_state.to_board_state()` flips the row once before solver publication.
Provider-to-solver and solver-to-screen are identity mappings. Never flip again
at the input boundary; tests cover this no-double-flip contract.

## Current GameState

Production state currently resolves/carries:

- **Board:** `GemType`, multiplier, `srvSeq`, `boardHash`, production/stable/
  latest/ACK flags, readiness, cascade/presentation/current state, modal/end
  flags, `Board.Instance`, and session key.
- **Battle:** `MatchId`, `CombatSessionKey`, turn/current player, local username,
  first local turn, server-tick timer/duration, lifecycle, connection/reconnect/
  resync, and local/last move sequence telemetry.
- **Player/boss:** ownership, HP/maxHP, Mana/maxMana, Rage/Power/max, Shield.
- **Cards:** dynamic object/data/card identity, type, current cost from
  `manaCost` or positive `conditionUse`, interactable, pending/use/cooldown/
  last-turn state. Observed ATTACK ID `4` is not hard-coded.
- **Fusion:** enabled/available/used/locked, current runtime cost/UI, last
  attempt, correlated response success/failure, and durable success state.
- **Idle/PASS:** exact authoritative payload values, freshness/correlation, and
  accepted reset-baseline provenance; never a local gameplay counter.
- **Sequence desync:** a sticky, session-scoped `SequenceDesyncState` guard
  accompanies `GameState`; it is not inferred from board motion or repaired.

See [state.py](../src/pokiguard_v2/state.py),
[Phase 2C.2C](phase2c2c_report.md), and
[sequence-desync resolution](sequence_desync_resolution.md).

## Combat Lifecycle

Exact `CombatLifecycleState` members:

```text
LOBBY | ENTERING | ACTIVE | LEAVING | POSTMATCH | STALE_SERVER_MATCH | UNKNOWN
```

Boss-entry external classifications are `BOSS_LOBBY`, `LOBBY_OTHER`,
`ENTERING_COMBAT`, `ACTIVE_COMBAT`, `POSTMATCH`, and `UNKNOWN`.

A server match ID alone does not prove local/actionable combat. `ACTIVE`
requires local rig, loader/Hub, Board/Active/ManagerMatch ownership, match ID,
board readiness, and non-terminal flags to agree. Stale/hidden server state is
`STALE_SERVER_MATCH` and fails closed; local lifecycle wins for UI safety.
Leaving `ACTIVE` invalidates session-scoped board/action/idle/desync/card/Fusion
caches. See [combat lifecycle resolution](combat_lifecycle_resolution.md).

## Actionability

Every gameplay input requires:

- exact `ACTIVE` lifecycle and current matching session;
- production board current/stable/ready and ACK/opening-authoritative;
- no cascade, presentation, turn-resolution, or known modal state;
- exact local turn, player/boss known and alive, no end state;
- ready connection, no reconnect/resync, and no terminal sequence desync;
- known timer above configured safety margin;
- bound Pokiguard window valid, unchanged, and foreground;
- no pending input/action lock or controller pause;
- fresh proposal still matching session, turn, `srvSeq`, hash, critical state,
  and recomputed policy immediately before input.

Unknown required state fails closed. Generic unrelated Unity modal traversal is
still UNKNOWN; known Board modal/action/end flags are the accepted gate. See
[actionability signals](actionability_signals.md).

## Autonomous Gameplay Currently Proven

### SWAP — PRODUCTION ACCEPTED

- Normal Windows two-click input on validated adjacent screen cells.
- Full foreground/state revalidation, single-use identity, and ACK/current-state
  synchronization.
- Bounded, multi-turn, and full-match acceptance; accepted runs have no known
  duplicate, stale, wrong-turn, boss-turn, lobby, or post-combat input issue.

### EVOLVE — PRODUCTION ACCEPTED within BASIC combat

- Dynamic live Fusion control and actual positive runtime cost.
- Functional and non-turn-consuming.
- `success=false` may retry only under fresh-state/lock/response safety.
- `success=true` requires durable `fusion.used=true`, then full reread; a
  consuming action may still occur on the same turn.
- Terminal success/failure may lead to an `EVOLVE-only turn` with zero further
  input when policy would otherwise PASS.

EVOLVE idle-reset semantics: **UNKNOWN**.

### CAST — PRODUCTION ACCEPTED

- Dynamic current ATTACK card; no hard-coded card ID.
- Actual cost comes from runtime data; accepted runs observed 160.
- Consumes the turn and locks out same-turn SWAP after acceptance.
- Card/mana/turn transition can prove acceptance if transient DTO is missed.

CAST idle-reset semantics for production PASS: **UNKNOWN**.

### PASS — PRODUCTION ACCEPTED, authoritative and bounded

- PASS sends **zero gameplay input**.
- Numeric state comes only from exact local-user server payloads.
- Live acceptance observed `1/3` and `2/3`; first local turn cannot PASS.
- At `2/3`, third PASS is prohibited and the next successful action must
  consume the turn; EVOLVE alone is insufficient.
- Accepted controlled cycle: `1/3 -> 2/3 -> mandatory SWAP -> 1/3`.
- No local `idle_count += 1`, decrement, or synthetic zero.
- UNKNOWN/stale/missing/rejected/uncorrelated evidence fails closed.

SWAP reset is production-proven. CAST and EVOLVE resets remain UNKNOWN. B5's
accepted natural full match contained no PASS (`NOT_OBSERVED` cycle coverage);
B3 and Phase 2C.2C supply accepted autonomous PASS evidence.

## BASIC Policy

```text
PlayStyle:    SIMPLE | CAREFUL
ManaPriority: EVOLUTION | ATTACK
Intelligence: BASIC | REASONING
```

`BASIC` is implemented/accepted. `REASONING` is represented but intentionally
undefined/not implemented; it returns `NONE / REASONING_NOT_IMPLEMENTED`.
Never invent REASONING behavior. See [BASIC policy](basic_gameplay_policy.md).
Its old PASS-disabled/undefined-fallback notes are superseded by
[Phase 2C.2C](phase2c2c_report.md) and the latest
[Phase 2C.2B/B5 report](phase2c2b_report.md).

## BASIC Resource Rules Currently Accepted

1. EVOLVE first only for `ManaPriority=EVOLUTION` when an evolution pet and
   current live Fusion slot are proven, the action is eligible/affordable, the
   inclusive EVOLVE time floor is met, and low-boss-HP mode is inactive.
   `ATTACK` priority, no selected evolution pet, or boss HP at/below the
   enabled low-HP threshold disables EVOLVE without stopping board play.
2. Sword is highest. A non-Sword direct match may win when its deterministic
   cascade collects the better Sword result.
3. At/below the configurable boss-HP threshold (default 30,000), after Sword:
   use an affordable proven Attack card, otherwise prefer safe Mana. Outside
   that mode, safe Rage has tactical priority below 100; otherwise safe Mana.
4. Safe Health: boss HP >50%, own HP <30% (`SIMPLE`) or <50% (`CAREFUL`).
5. Normal CAST requires player Mana strictly >480 and a usable dynamic ATTACK
   card, preserving 320 after observed cost 160. Low-boss-HP mode explicitly
   allows an affordable CAST without that stockpile threshold. No equipped or
   proven live Attack card disables CAST only; board policy continues.
6. Safe Drain: boss Mana >160 and Rage >100. Safe Shield: both <50.
   Intermediate handling prefers safe Shield. Only-safe Drain and Health-only
   safe fallback are accepted special cases.
7. After explicit branches, use deterministic minimum-risk safe-resource
   fallback. Safe Rage remains useful while below max 250 even when >=100.
8. A full resource has no value solely for filling itself; Sword/cascade/combo,
   another resource, safety, or mandatory action may still justify the move.
9. PASS only when no Sword-safe move remains and authoritative state permits.
   Mandatory state uses a normal safe consuming action or deterministic
   least-dangerous legal action.

Canonical intent: [DECISIONS.md](DECISIONS.md). Exact ranking/trace:
[basic_policy.py](../src/pokiguard_v2/basic_policy.py).

## Board Simulator

- Exhaustive 112 adjacent pairs: 56 horizontal + 56 vertical.
- Separates legal, safe, and dangerous moves.
- Resolves direct matches, known gravity, and deterministic known cascades from
  the current 64 cells; preserves x1-x4 multiplier with each gem.
- Off-board refill is `UNKNOWN` and earns no deterministic cascade credit.
- Records resources, Sword potential/risk, collapse/support hazard, UNKNOWN
  exposure, and deterministic tie-breaks.

## Dead Board

Not `policy returned NONE`; not `safeMoveCount=0`. Definition:

```text
ACTIVE/current/stable local-turn 64-cell board
AND board ready / no cascade
AND exhaustive legalMatchProducingMoves == 0
```

Missing gates yield UNKNOWN. `legal>0, safe=0` is live but dangerous. Exact dead
board now dispatches the bounded Phase 2D.3 technical-recovery coordinator;
`POLICY_NO_SAFE_MOVE` explicitly does not. The deterministic zero-legal path is
offline-accepted, while natural zero-legal runtime evidence remains
`NOT_OBSERVED`. See [dead-board resolution](dead_board_resolution.md) and the
[Phase 2D.3 report](phase2d3_report.md).

## Sequence Desync

Accepted sources: `FORCE_RESYNC`, structured sequence-gap/duplicate reject, and
`ChatMessageDTO.rejectReason` where applicable (structured payload code wins).

```text
SEQUENCE_DESYNC
-> terminal for current session
-> all gameplay actions blocked
-> pending identity consumed; no retry
-> no idle-state mutation
```

Only proven old-session end plus a different clean session clears it. Never
repair sequence via memory/network/direct call/forged ACK/local counter. See
[sequence-desync resolution](sequence_desync_resolution.md).

## Safe UI Recovery

Accepted normal Windows UI flow:

```text
ACTIVE combat -> << -> confirmation modal -> Đồng ý -> POSTMATCH -> LOBBY
```

Locator and single-step clicks are implemented. Manual F10-confirmed recovery
remains **PASS**. Phase 2D.3 additionally live-accepts one coordinator-owned
automatic recovery for exact technical triggers, with foreground revalidation,
single-use input permits, exact lobby/target re-entry, fresh opening proof, and
a hard stop before recovered-combat gameplay. See
[safe UI recovery](safe_ui_recovery.md) and the
[Phase 2D.3 report](phase2d3_report.md).

## Boss Entry

Phase 2D.1: **PASS STRONG**. Current accepted target:

```text
Starburst
ID = 1289
```

Architecture remains target-configurable; source does not hard-code this
target, and CLI must receive exact ID/name.

```text
BOSS_LOBBY -> exact target -> one normal UI entry
-> new MatchId/session -> opening 64/64 -> first local turn -> STOP
```

Accepted evidence: wrong clicks 0, duplicate clicks 0, stale-session confusion
0, gameplay inputs after entry 0; foreground loss failed closed with zero input.
Stop was `NEW_COMBAT_OPENING_READY`. See [Phase 2D.1](phase2d1_report.md).
The separate WorldBoss-card path remains enumeration/read-only; live rect/
selection calibration is not accepted.

## Bounded Farm Runner

Phase 2D.6: **PASS STRONG**. The production runner owns the complete bounded
state machine, explicit operator-control axis, durable historical checkpoint,
and the single automation-controller lease:

```text
BOSS_LOBBY -> exact Starburst 1289 entry -> fresh opening -> full BASIC
-> normal POSTMATCH confirmation -> exact BOSS_LOBBY -> bounded next entry
```

Accepted Phase 2D.6 B3 bounds are exactly 25 completed matches, at most 3
technical recoveries, and at most 32 fresh match attempts. Progress is explicit
`FarmRun` state; it is not inferred from MatchId count. Each entry re-resolves
the target and requires a unique session plus hardened current 64/64 opening.
Target completion is checked after exact lobby reacquisition, before another
entry capability can be issued. The accepted run used exactly 25 attempts and
did not create entry/attempt 26.

Terminal classification is frozen before ownership cleanup in a session-bound
`TerminalCombatSnapshot`. Exact terminal winner/HP evidence is primary;
postmatch `Thắng`/`Thua` is a secondary consistency audit. Results are
WIN/LOSS/UNKNOWN with STRONG/PARTIAL/UNKNOWN provenance. Strong results cannot
be downgraded by later cleanup. Normal completion is counted exactly once;
technical aborts do not increment completion; UI/memory conflict safe-stops at
the lobby. Accepted B3 accounting is 24 wins, 1 loss, 0 unknowns, 25 unique
MatchIds, and 25/25 memory/UI consistency.

Production `SEQUENCE_DESYNC` and exact `DEAD_BOARD_NO_REFRESH` dispatch into
the same accepted recovery coordinator. Recovery immediately locks gameplay,
uses normal foreground exit/confirm/re-entry inputs, rejects failed-session
state, accepts only a distinct current session/opening, then rereads and
recomputes BASIC. Phase 2D.4 Stage B1 live-proves one accepted consuming action
after this handoff. Phase 2D.6 B2 naturally observed and recovered one dead
board; B3 had no natural technical failure.

F6 is the accepted edge-triggered graceful stop: it drains an active/in-flight
match and postmatch to exact boss lobby, then stops with a hard no-new-entry
gate. F9 terminally prevents future input and produces a non-resumable
emergency checkpoint. F7 is deliberately disabled; stale-safe farm-level
pause/resume has not been accepted.

Checkpoint schema `pokiguard.farm_checkpoint.v1` persists only durable history
with atomic temp/flush/fsync/replace writes. Explicit resume is accepted only
at freshly confirmed exact `BOSS_LOBBY` with identical target/limits. It never
restores Board/action/sequence/idle/UI runtime state or resumes an old combat.
Infinite farming, game launch/process restart, and automatic login are not
implemented. See [Phase 2D.6](phase2d6_report.md) and its
[runbook](phase2d6_runbook.md).

## Latest Accepted Milestones

- [Phase 2B.5](phase2b5_report.md) — memory board hardening: **PASS STRONG**.
- [Phase 2C.1](phase2c1_report.md) — single-step input: **PASS STRONG**.
- [Phase 2C.2C](phase2c2c_report.md) — authoritative PASS/reset cycle: **PASS**.
- [Phase 2C.2B B3/B5](phase2c2b_report.md) — full BASIC combat:
  **FULL_MATCH_PASS** (user-confirmed WIN).
- [Phase 2D.1](phase2d1_report.md) — one-shot boss entry: **PASS STRONG**.
- [Phase 2D.2](phase2d2_report.md) — **PASS STRONG**; accepted attempt 5
  autonomously completed one combat, confirmed the result, entered session #2,
  and hard-stopped before any combat-2 input.
- [Phase 2D.3](phase2d3_report.md) — **PASS STRONG**; one automatic technical
  recovery exits, reacquires the exact lobby/target, enters a fresh session,
  validates opening 64/64, and hard-stops with all safety counters zero.
- [Phase 2D.4](phase2d4_report.md) — **PASS STRONG**; live recovery resumes
  fresh BASIC gameplay, and a separate bounded run completes exactly three
  matches then stops at boss lobby before entry #4 with every safety counter
  zero.
- [Phase 2D.5](phase2d5_report.md) — **PASS STRONG**; B1 freezes a STRONG
  memory-backed WIN before ownership cleanup, and B2 completes exactly 10
  STRONG/consistent wins then stops at boss lobby before entry #11 with exact
  accounting and every safety counter zero.
- [Phase 2D.6](phase2d6_report.md) — **PASS STRONG**; F6 drains safely to
  lobby, explicit checkpoint resume preserves exact accounting, and B3
  completes 25/25 unique matches (24 WIN, 1 LOSS, 0 UNKNOWN) before entry #26
  with every safety counter zero.
- [Phase 2E.1](phase2e1_report.md) — **PASS STRONG**; read-only desktop UI and
  control-plane observer, with one poller, immutable snapshots, and clean close.
- [Phase 2E.2](phase2e2_report.md) — **PASS STRONG**; UI Start, graceful stop,
  emergency stop, durable resume, foreground handoff, and an exact 5-match
  bounded run passed live with no post-boundary input or extra entry.

Intermediate retries are historical evidence, not current phase status.

## Current Test Baseline

Verified on **2026-08-22**:

```text
python -m unittest discover -s tests
Ran 564 tests
OK
```

Current baseline: **564/564 PASS**. Phase 2E desktop/controller focus suites:
**46/46 PASS**. `python -m compileall -q src tools tests`:
**PASS**. `git diff --check`: **PASS**. The suite additionally covers terminal
WIN/LOSS/UNKNOWN classification, frozen result survival after ownership
cleanup, UI/memory consistency and conflict, idempotent accounting, two
independent bounded recovery invocations, recovery-resume for captured sequence
desync and deterministic dead board, target/recovery/attempt hard boundaries,
session uniqueness, no entry after the configured target, input after stop,
single-use farm capabilities, exact hardened openings, graceful-stop lifecycle
races, F9 invalidation, checkpoint validation/atomicity/resume accounting,
optional/dynamic card layout, recovery ACK-epoch contamination, and the x64
working-set sampler ABI. Phase 2E.2 adds controller ownership/generation,
command gating, verified-PID foreground transfer, graceful and emergency stop
handoffs, exact resumable-checkpoint boundaries, and clean worker shutdown.

## Current Known Limitations

- The Phase 2E.2 UI intentionally exposes only finite target/attempt/recovery
  limits. Infinite/daemon operation, automatic game launch/login/process
  restart, target rotation, scheduling, and remote control are not implemented.
- Emergency Stop is terminal for the current UI controller generation. It can
  leave the game combat itself running; the user may finish/exit normally, but
  the stopped controller sends no further input and its checkpoint is not
  resumable.
- UI Resume accepts only a durable checkpoint at an exact boss-lobby boundary.
  Completed, emergency, malformed, stale, or mid-combat checkpoints remain
  disabled in the UI and are rejected again by the backend authority.
- Bounded continuous farming is accepted for the Phase 2D.6 B3 limits: 25
  completed matches, at most 3 technical recoveries, and at most 32 match
  attempts. Infinite/daemon farming, game launch/login, automatic process
  restart, and unbounded retries are not accepted.
- Checkpoint resume is history/accounting continuation only and requires a
  freshly confirmed exact boss lobby. Mid-combat controller restart/resume and
  restoration of executable runtime state are not accepted.
- The result-modal `Đồng ý` requirement, exact locator, one-click normal-UI
  path, and resulting lobby transition are live-accepted for the proven modal.
- Phase 2D.6 B2 naturally recovered one exact dead board. B3 required zero
  recoveries. If old MatchService ACK state persists at the lobby, technical
  recovery now refuses re-entry; only a user-run game process restart clears
  the observed contamination, because automatic restart is out of scope.
- Terminal PlayerStats capture before cleanup is live accepted for all 25 B3
  matches: 24 STRONG WINs and one STRONG LOSS, all UI-consistent. UNKNOWN
  remains the fail-closed outcome when evidence disappears too early.
- Accepted B3 working-set start/peak/end values are unavailable because the
  original ctypes sampler truncated the x64 pseudo handle. The ABI is fixed and
  regression-tested for future runs, but no retroactive RAM series is claimed.
- Ordinary Attack/Fusion card layout is dynamic and accepted. A missing Attack
  card or evolution pet disables that card action only. Pet-specific skill-card
  click layout/use remains intentionally deferred.
- `REASONING` is undefined/not implemented.
- CAST reset **UNKNOWN**; EVOLVE reset **UNKNOWN**.
- B5 natural full-cycle PASS coverage `NOT_OBSERVED`; controlled 2C.2C proves
  the complete SWAP reset cycle, while B5 retry 2 proves its dangerous half.
- Natural live sequence desync remains `NOT_OBSERVED`; exact zero-legal dead
  board recovery is naturally observed in Phase 2D.6 B2. Generic unrelated
  modal traversal is **UNKNOWN**.
- Direct WorldBoss-card entry is not live-calibrated/accepted.

## Superseded Historical Assumptions

- Dot 64/64 is not a production requirement; CV is not production board source.
- Older PASS-disabled text is historical; bounded authoritative PASS is accepted.
- Early 3/10-action caps are milestones, not current B5 gameplay caps.
- Manual opening move is superseded by exact `MATCH_START` bootstrap.
- Old `BASIC_INTERMEDIATE_FALLBACK_UNDEFINED` behavior is superseded by accepted
  Shield/Health/general safe-resource fallback.

## Next Phase

**Phase 2E.3 is not implemented. Await explicit user review and approval.**

```text
accepted Phase 2E.2 live UI/FarmRunner control integration
-> review evidence
-> explicitly define/approve Phase 2E.3 before implementation
```

No Phase 2E.3 or other future scope is inferred. Infinite farming, process
relaunch/login, internet recovery, target rotation, pet-specific skill-card
use, mid-combat checkpoint resume, and expanded recovery authority remain
outside current scope unless explicitly approved.

## Update Policy for Future Phases

After each accepted phase: update completed/next phase, capabilities, unresolved
blockers, test baseline, evidence links, and superseded assumptions. Update
[DECISIONS.md](DECISIONS.md) only when the user changes a gameplay/product rule
or explicitly approves policy; technical discoveries normally belong here or
in phase reports.

## New Agent / New Conversation Bootstrap

```text
Read AGENTS.md first.
Then read docs/CURRENT_STATE.md and docs/DECISIONS.md.

Treat those files as the canonical current handoff.
Use phase-specific reports and logs only for deeper evidence.
Do not rely on previous chat history.
Do not change gameplay rules recorded in DECISIONS.md.
Continue only the phase explicitly requested by the user.
```

Canonical references: [AGENTS.md](../AGENTS.md) and
[DECISIONS.md](DECISIONS.md).
