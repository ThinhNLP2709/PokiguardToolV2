# Phase 2D.2 audit report — PASS STRONG

## Status

**PASS STRONG — LIVE ACCEPTED ON ATTEMPT 5 (`20260815_205707`).**

The accepted run completed one autonomous B5 combat, proved authoritative
POSTMATCH, located the stable result modal, sent exactly one farm-owned normal
Windows click to `Đồng ý`, reacquired exact stable BOSS_LOBBY, entered a second
distinct combat, and hard-stopped at its opening with zero combat-2 gameplay
input. The user sent no result-modal input. Attempts 1–4 remain historical
SAFE_STOP/evidence runs; attempt 3 is specifically invalidated by its disclosed
manual postmatch click.

## Audit of the initial implementation

Useful work retained:

- one shared process/provider/sequence-monitor/window/executor across entry and
  combat;
- explicit farm-cycle model and cycle identity;
- reuse of the accepted Phase 2D.1 entry pipeline and B5 BASIC controller;
- structural rule that B5 is invoked only for session #1;
- bounded two-entry flow and second-session identity check.

Acceptance-critical defects found:

1. Entry and gameplay counts were incremented when the outer runner claimed to
   authorize an action, not when the real input boundary sent it.
2. The farm ledger was not connected to B5's actual PASS, SWAP, EVOLVE, or CAST
   boundaries. A unit-test claim of a hard boundary therefore did not prove the
   live executor boundary.
3. Entry authorization used a caller-supplied constant `foreground=True`
   before the Phase 2D.1 atomic preflight.
4. The outer post-combat runner accepted only a `stopReason` string and did not
   require full-match classification, zero safety counters, cleared session,
   cleared pending action, and a postmatch observation event.
5. F9 was not polled during the outer return-to-lobby wait.
6. Combat timeout defaulted to unbounded (`0`).
7. The entry baseline omitted `oldBoardHash`.
8. The read-only smoke used one sample and had no cooperating-controller
   exclusion.
9. The report/runbook contradicted the code: they simultaneously said
   `--run-cycle` was refused and enabled, and claimed smoke evidence that was
   not established in the current workspace audit.

## Repaired architecture

### Farm-cycle state and identity

`src/pokiguard_v2/farm_cycle.py` owns:

- `FarmCycleId`;
- explicit entry #1, combat #1, postmatch, lobby return, entry #2, opening #2,
  complete, and safe-stop states;
- exact entry/session/play budgets;
- session #1 and session #2 identities;
- per-domain input records and state-transition events;
- validated opening evidence including 64 unique cells, SHA-256 board hash,
  known gem types, x1..x4 multipliers, fresh MATCH_START source, two stable
  confirmations, first local turn, local sequence zero, and timer margin.

### Two-phase capabilities

Entry and gameplay use `reserve -> executor/result -> complete`:

- a reservation is not counted as an input;
- an entry is counted only after the Phase 2D.1 executor reports one sent
  Windows click;
- a partial SWAP is counted as a real Windows input;
- a zero-click physical gameplay failure safe-stops the cycle;
- PASS is recorded as a gameplay action with exactly zero Windows input;
- no gameplay capability is created for combat #2.

The capability is called at the real production boundaries in:

- `tools/boss_entry.py` immediately before/after the entry click;
- `tools/basic_auto_bot.py` immediately before/after PASS start;
- `tools/basic_auto_bot.py` immediately before/after SWAP input;
- `tools/basic_auto_bot.py` immediately before/after EVOLVE/CAST input.

Every boundary uses a fresh foreground status. Capability denial stops before
the executor call.

### Shared runtime and cleanup

The accepted controllers keep their standalone CLI behavior and can receive a
farm-owned shared runtime. The B5 handoff requires the entry-proven session,
rereads provider state, and reuses its normal ActionabilityGate and policy
recomputation. The accepted B5 lifecycle path clears the active session,
monitor, idle/pass state, pending proposal/action identities, and transient
combat caches before the outer runner can accept a returned boss lobby.

### Combat and postmatch acceptance

Entry #2 is reachable only when B5 evidence contains all of:

- `stopReason = COMBAT_LIFECYCLE_ENDED`;
- classification `FULL_MATCH_PASS` or `B5_PASS_STRONG`;
- a completed combat result;
- `sessionCleared = true`;
- no active session and no pending action;
- every B5 safety telemetry counter equal to zero;
- `postmatch_observation_complete` with automatic input disabled;
- a later two-sample exact `BOSS_LOBBY` and exact target resolution;
- no current combat-session ownership.

No postmatch button, recovery button, third entry, or continuous loop was
implemented. An unresolved postmatch remains a safe stop.

### Single-controller ownership

`AutomationControllerLease` is now acquired by the farm, standalone boss-entry,
and standalone B5 CLIs. A second cooperating controller fails before attach or
input. Nested shared runners do not acquire a second lease.

## Offline evidence

Commands run on 2026-08-15:

```text
python -m unittest discover -s tests -v
Ran 335 tests
OK

python -m compileall -q src tools tests
PASS

git diff --check
PASS (only Git line-ending notices)

python tools/farm_cycle.py --help
PASS
```

The Phase 2D.2 tests cover the complete two-entry/one-combat path and failure
paths including invalid start, target missing/ambiguous mapping, foreground
loss, duplicate entry reservation, failed entry input, invalid opening fields,
old MatchId reuse, combat end with a pending capability, postmatch ambiguity,
desync/dead-board safe stop, physical input failure, combat #2 gameplay denial,
entry #3 denial, B5 production hook, and duplicate controller lease.

## Read-only smoke result

After the user entered the Starburst pet boss lobby, the audit ran:

```text
python tools/farm_cycle.py --read-only-smoke --boss-id 1289 --lobby-timeout 30
```

Observed:

```text
lobbyState=BOSS_LOBBY
targetResolution=TARGET_RESOLVED
reason=BOSS_LOBBY_READY
stableFrames=2
staleCombatOwnership=0
otherCooperatingController=0
inputs=0
```

The required smoke precondition passes. This was read-only and did not start a
live farm cycle.

## Live attempt 1 — SAFE_STOP

Artifact: `logs/boss_farm_cycle/20260815_181914/`

| Evidence | Result |
|---|---|
| Cycle ID | `3ef787b7b1154dc89884e65e508b1586` |
| Start state / target | `BOSS_LOBBY`; Starburst ID 1289 exact resolution |
| Entry #1 | PASS; one entry input; wrong/duplicate click 0 |
| Session #1 | epoch 1, Board `0x000001728CE45540`, MatchId `M_fbb17c3a` |
| Opening #1 | 64/64 unique, valid hash/types/multipliers, stable x3, first local turn |
| Combat #1 | Ended after authoritative idle reached removal threshold; result unknown |
| Turns observed | local 3, boss 2 |
| SWAP / EVOLVE / CAST / PASS | all 0; total gameplay Windows input 0 |
| Safety counters | duplicate/misclick/partial/wrong/stale/boss/lobby/postmatch input all 0 |
| DEAD_BOARD / SEQUENCE_DESYNC | 0 / 0 |
| Combat end / cleanup | POSTMATCH -> LOBBY observed; session and pending state cleared |
| Entry #2 / session #2 / opening #2 | not attempted |
| Combat #2 gameplay | 0 |
| Final stop | `COMBAT1_SAFE_STOP / LOCAL_TURN_ACTION_DEADLINE` |

### Root cause

Entry #1 accepted opening at `11:19:22.953Z`. The farm handoff then repeated
`RuntimeSequenceMonitor.prime_regions()`, scanning 403,211,185 bytes. B5 first
reached its action gate at `11:19:27.356Z` with six seconds remaining, exactly
the configured deadline warning. It correctly sent no stale/late input and
paused. Because the accepted standalone B5 pause contract expects possible user
takeover, it remained paused through later local turns; the server observed
idle 1 then idle 2 and ended the match at the threshold.

### Post-attempt fix

- Farm-owned B5 now reuses transport-region evidence learned during entry;
  additional handoff prime bytes are exactly zero.
- Standalone B5 keeps its accepted pause/resume behavior.
- Farm-owned B5 exits immediately on a local-turn deadline so ownership returns
  to the user instead of silently remaining paused.
- Added a regression proving farm handoff does not call `prime_regions()`.
- Full offline baseline after the fix: **336/336 PASS**; compileall PASS.

At that point the fix had not been live-retried; attempt 2 below records the
next result.

## Live attempt 2 — SAFE_STOP

Artifact: `logs/boss_farm_cycle/20260815_195803/`

| Evidence | Result |
|---|---|
| Cycle ID | `fe222d310b5246d0b2ba16b07e859a7e` |
| Start state / target | `BOSS_LOBBY`; Starburst ID 1289 exact resolution |
| Entry #1 | PASS; one entry input; wrong/duplicate click 0 |
| Session #1 | epoch 1, Board `0x000001CB8B080000`, MatchId `M_7e66a30d` |
| Opening #1 | 64/64 unique, valid hash/types/multipliers, stable x3, first local turn |
| Handoff | Entry transport regions reused; additional scan bytes exactly 0 |
| SWAP | 8 sent, 8 acknowledged, 0 rejected |
| EVOLVE | 1 sent; terminal `ACTION_EXPIRED / RESPONSE_OR_ACK_TIMEOUT` |
| CAST | 0 |
| PASS | 1 zero-input PASS; `PASS_CONFIRMED_IDLE_1` from `MATCH_AFK_WARN 1/3` |
| Safety counters | wrong/duplicate/stale/partial/foreground/combat-2 inputs all 0 |
| Entry #2 / session #2 / opening #2 | not attempted |
| Final artifact stop | `F9_EMERGENCY_STOP`, detail `KeyboardInterrupt` after Codex stopped the tool process to preserve evidence; the user did not press F9 |

Attempt 2 proves the attempt-1 handoff-latency fix: B5 reached the first action
without a repeated region prime, then completed eight server-acknowledged SWAPs
and one authoritative PASS. At turn 19 it sent EVOLVE with current mana 315 and
runtime cost 160. No `MATCH_FUSION_RES` or equivalent durable transition was
observed within the accepted action timeout, so the action terminal was
correctly classified `ACTION_EXPIRED` and input was disabled.

### Root cause and post-attempt fix

Standalone B5 intentionally stays alive after `AUTO_PAUSED` so a user can take
over or explicitly resume. The farm-owned B5 reused that interactive contract,
so after the EVOLVE timeout it stopped sending input but kept observing later
turns instead of returning a safe-stop result to `FarmCycle`.

Farm-owned B5 now treats `PAUSED_BY_USER`, `AUTO_PAUSED`, and
`RECOVERY_REQUIRED` as terminal handoff states. On the next controller boundary
it disables input, emits `farm_safe_stop_immediate`, returns to the farm state
machine, and prevents entry #2. Standalone B5 retains its existing interactive
pause/resume behavior. A regression covers both sides of this contract.

Offline baseline after the fix: **337/337 PASS**; compileall and diff check PASS.
The fix had not yet been live-retried at that point; attempt 3 below supplies
the accepted evidence.

## Live attempt 3 — STRUCTURAL PASS, LIVE ACCEPTANCE INVALIDATED

Artifact: `logs/boss_farm_cycle/20260815_203412/`

| Evidence | Result |
|---|---|
| Cycle ID | `69d04639a8a54f4db1f9fdb3b9ef66ac` |
| Start state / target | Exact `BOSS_LOBBY`; Starburst ID 1289 |
| Entry #1 | PASS; exactly 1 entry input; wrong/duplicate click 0 |
| Session #1 | epoch 1, Board `0x000001CCEB4EF540`, MatchId `M_2c1481f0` |
| Opening #1 | 64/64 unique; stable/current/fresh; first local turn; valid hash |
| Combat result | `FULL_MATCH_PASS`; lifecycle ended via `local_match_end_flag` |
| Local / boss turns | 22 / 21 |
| SWAP | 20 sent; 19 ACK; 0 rejected; final pending SWAP safely aborted by combat end |
| EVOLVE | 1 attempt; 1 success; 0 failure; same-turn reread and SWAP succeeded |
| CAST | 2 sent; 2 accepted; 0 rejected; runtime cost 160 |
| PASS | 0 in this match; no fabricated idle mutation |
| Policy coverage | Sword 5, Mana 6, Rage 4, Shield 4, Health 1, EVOLVE 1, CAST 2 |
| Safety telemetry | duplicate/misclick/partial/wrong-turn/stale/boss-turn/lobby/postmatch/post-end input all 0 |
| DEAD_BOARD / SEQUENCE_DESYNC / foreground failure | 0 / 0 / 0 |
| Postmatch | Controller sent 0 postmatch input, but user manually clicked `Đồng ý`; automatic return is not proven |
| Session cleanup | `sessionCleared=true`, `activeSession=null`, `pending=null` |
| Lobby reacquisition | Exact stable `BOSS_LOBBY`; old combat ownership absent |
| Entry #2 | PASS; exactly 1 entry input; wrong/duplicate click 0 |
| Session #2 | epoch 2, Board `0x000001CCEB777340`, MatchId `M_a387cdd3` |
| Session separation | MatchId, epoch, Board instance, and opening hash all differ |
| Opening #2 | 64/64 unique; stable/current/fresh; first local turn; valid hash |
| Combat #2 gameplay | 0 actions, 0 Windows inputs |
| Total entry inputs | exactly 2; target-select inputs 0; third-entry inputs 0 |
| Final state / stop | `FARM_CYCLE_COMPLETE / SECOND_COMBAT_OPENING_READY` |
| Machine invariant | `accepted=true / PHASE2D2_BOUNDARY_PROVEN`, superseded for live acceptance by the user's manual-input disclosure |

The runtime's outcome label is `ENDED_RESULT_UNKNOWN` because no authoritative
WIN/LOSS payload was retained. The last fresh policy state had local HP
`32209/105228` and boss HP `4400/84180`; the final SWAP overlapped the proven
combat-end transition. A win is therefore plausible but is only an inference.
Acceptance relies on the authoritative local lifecycle transition to POSTMATCH,
not on that inferred outcome.

Input-domain totals:

| Domain | Logical actions | Windows inputs |
|---|---:|---:|
| `BOSS_ENTRY` | 2 | 2 |
| `BOSS_TARGET_SELECT` | 0 | 0 |
| `GAMEPLAY_SWAP` | 20 | 20 |
| `GAMEPLAY_EVOLVE` | 1 | 1 |
| `GAMEPLAY_CAST` | 2 | 2 |
| `GAMEPLAY_PASS` | 0 | 0 |
| `POSTMATCH_UI` | 0 | 0 |
| `RECOVERY_UI` | 0 | 0 |

This attempt-3 conclusion is retained as historical context. It was superseded
by attempt 4's no-user-input modal evidence and attempt 5's accepted autonomous
postmatch action. Continuous farming, automatic technical recovery, combat #2
automation, and entry #3 remain outside this phase.

## Files created or modified by the repaired implementation

Created:

- `src/pokiguard_v2/controller_lease.py`
- `src/pokiguard_v2/farm_cycle.py`
- `src/pokiguard_v2/farm_cycle_runtime.py`
- `tools/farm_cycle.py`
- `tests/test_farm_cycle.py`
- `tests/test_farm_cycle_input_hooks.py`
- `docs/phase2d2_report.md`
- `docs/phase2d2_runbook.md`

Modified:

- `tools/boss_entry.py`
- `tools/basic_auto_bot.py`

Canonical status files:

- `docs/CURRENT_STATE.md`: updated through live attempt 2 SAFE_STOP, both root
  causes, offline fixes, 337-test baseline, and retry blocker.
- `docs/DECISIONS.md`: updated after the user clarified that Starburst 1289 is
  an acceptance fixture, while the product target is the pet selected/configured
  by the user and the eventual product goal is an explicitly controlled
  continuous farm loop.

## Resolved acceptance blocker

The result modal had to be observed and dismissed without manual interaction.
Attempt 4 proved that `Đồng ý` is mandatory and supplied stable visual evidence;
attempt 5 proved its exact one-click capability and the resulting lobby
transition. This blocker is closed.

## Live attempt 4 — POSTMATCH EVIDENCE PASS / CYCLE SAFE_STOP

Artifact: `logs/boss_farm_cycle/20260815_204412/`

- Cycle ID `6db8db7fa6ae41ccb956c17c8e392f99`.
- Entry #1 and opening #1 passed; MatchId `M_24d0eb40`.
- Combat #1 classified `FULL_MATCH_PASS`: 15 local turns, 13 boss turns, 12
  SWAP inputs (11 ACK plus final lifecycle overlap), EVOLVE 1/1 success, and
  authoritative PASS 1/3 -> 2/3 -> mandatory SWAP.
- At `13:47:21.368Z`, lifecycle became authoritative POSTMATCH and all gameplay
  input was disabled.
- The user sent no input. POSTMATCH persisted for the full 60-second observation
  and ended `postmatch_observation_timeout` with lifecycle still POSTMATCH.
- Entry #2 was not attempted; postmatch, combat #2, wrong-target, duplicate,
  stale, desync, and dead-board inputs/findings remained zero.
- Two visible-client captures prove the mandatory result UI:
  `postmatch_modal.png` and `postmatch_modal_2.png`. Both show the same WIN panel,
  boss HP `0/84180`, and the sole lower-center `Đồng ý` control.

### Postmatch implementation after attempt 4

- Added a resolution-independent result-modal locator. It requires exactly one
  large blue result panel and exactly one orange button in the normalized
  lower-center result anchor; the two-button leave modal is rejected.
- The two real frames both resolve to normalized point
  `(0.5000, 0.875352)`, confidence `0.98`, with drift `0`.
- Farm-owned handling requires authoritative POSTMATCH, three stable visual
  frames, unchanged lifecycle, a valid foreground window, and a single-use
  `POSTMATCH_UI` capability immediately before one normal Windows click.
- A sent click is not considered sufficient by itself: the existing exact,
  stable `BOSS_LOBBY` reacquisition remains the transition acknowledgement.
- Any ambiguity, focus loss, second click request, failed click, or missing
  lobby transition safe-stops before entry #2.
- Farm postmatch read-only wait is now bounded to five seconds before the proven
  modal path; standalone B5 behavior is unchanged.

Offline verification after this implementation: **343/343 PASS**; compileall
and diff check PASS. Attempt 5 below live-accepted the exact result click and
the full two-entry boundary without user interaction.

## Live attempt 5 — PASS STRONG

Artifact: `logs/boss_farm_cycle/20260815_205707/`

- Cycle ID `b1bc4bd7bed14220896653986ba8f2c8`.
- Entry #1 PASS; session epoch 1, Board `0x000001CCEB4EF540`, MatchId
  `M_7932ca46`; opening 64/64, fresh and stable, first local turn.
- Combat #1 `FULL_MATCH_PASS`: 40 local turns, 38 boss turns, 37 SWAP inputs,
  4 EVOLVE inputs (1 success), 2 authoritative PASS actions with zero Windows
  input, and no CAST input.
- The final SWAP overlapped authoritative combat end and was safely classified
  `action_aborted_due_lifecycle=1`; there was no post-combat gameplay input.
- Authoritative lifecycle changed to POSTMATCH via `local_match_end_flag`.
- Three result frames produced the same stable sole-button proof. The farm
  controller reserved its single-use `POSTMATCH_UI` capability and sent exactly
  one normal Windows click (`RESULT_CONFIRM:SENT`). The user did not click.
- Exact stable `BOSS_LOBBY` was reacquired after the click and served as its
  transition acknowledgement.
- Entry #2 PASS; session epoch 2, Board `0x000001CCEB4EF000`, MatchId
  `M_c19328e0`; opening 64/64, fresh and stable, first local turn.
- Session #2 differs from session #1 by epoch, Board address, MatchId, and board
  hash. Combat #2 received 0 gameplay actions and 0 Windows inputs.
- Domain totals: BOSS_ENTRY 2/2 actions/inputs, POSTMATCH_UI 1/1,
  GAMEPLAY_SWAP 37/37, GAMEPLAY_EVOLVE 4/4, GAMEPLAY_PASS 2/0; no target-select,
  cast, or recovery input.
- All final safety counters are zero: wrong/duplicate/third entry, stale-session,
  dead-board, sequence-desync, foreground, and combat-2 input failures.
- Final state `FARM_CYCLE_COMPLETE`; hard stop
  `SECOND_COMBAT_OPENING_READY`; invariant
  `accepted=true / PHASE2D2_BOUNDARY_PROVEN`.

Phase 2D.2 is therefore **PASS STRONG**. The accepted boundary is exactly one
complete autonomous combat plus automatic result confirmation and entry into a
second combat, followed by a hard stop. It does not enable continuous looping.

## Post-acceptance visible single-cycle demonstration — PASS

Artifact: `logs/boss_farm_cycle/20260815_214234/`

At the user's request, bounded mode `--run-single-cycle` reused the accepted
entry/B5/POSTMATCH pipeline but stopped after exact lobby return instead of
reserving entry #2. The run:

- entered exact target Starburst 1289 once; MatchId `M_55c4a9e5`;
- completed `FULL_MATCH_PASS` over 23 local and 19 boss turns;
- sent 19 SWAP and 6 EVOLVE inputs; one EVOLVE succeeded;
- proved PASS 1/3 and then a later 1/3 -> 2/3 sequence, followed by the required
  consuming SWAP; no third PASS occurred;
- visibly captured `THẮNG`, local HP `54630/105228`, boss HP `0/84180`;
- proved the result control across three stable frames and sent exactly one
  `POSTMATCH_UI` click;
- reacquired exact stable BOSS_LOBBY and stopped with one entry, one session,
  no entry #2, and all farm safety counters zero.

Final state `FARM_CYCLE_COMPLETE`, stop `RETURNED_BOSS_LOBBY_READY`, invariant
`accepted=true / SINGLE_CYCLE_RETURNED_LOBBY_PROVEN`. This demonstration does
not enable a retry loop or continuous farming.
