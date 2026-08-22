# Phase 2E.2 — UI ↔ FarmRunner Live Integration

## Result

**PASS STRONG** on 2026-08-22.

Base commit: `a45b89fe35dc923ce53c4195c6ca7b1a2c1fba4c` (accepted
Phase 2E.1). The Phase 2E.2 commit is the focused commit containing this
report; its exact hash is reported in the final handoff after Git creates it.

Phase 2E.2 connects the Tkinter/ttk UI to the accepted bounded FarmRunner. It
does not implement Phase 2E.3, infinite farming, REASONING, game launch/login,
or a second automation engine.

## Control plane and ownership

The command path is:

```text
Tkinter widget
-> DesktopViewModel short submission
-> DesktopControlPlane validated command
-> DesktopFarmControllerManager single controller lease
-> accepted FarmRunner/actionability/input layers
```

The control plane exposes Start, graceful stop, emergency stop, and durable
checkpoint resume. Widgets never click the game, enter a boss, edit checkpoint
history, or mutate FarmRunner internals. FarmRunner remains on its own worker;
the Tk event loop only submits short commands and renders immutable snapshots.

`DesktopFarmControllerManager` owns exactly one generation-bound controller.
Double Start is rejected while active. Graceful/emergency commands carry the
current generation, so a delayed command for an older controller cannot affect
a newer run. The shared `FarmControlAuthority` is checked at every accepted
normal foreground input boundary.

Start requires a fresh healthy attached `BOSS_LOBBY` snapshot, canonical BASIC
finite configuration, exact target, and no active controller. Before starting,
the controller restores and foregrounds the verified game PID; failure to do
so rejects Start with zero farm input. Graceful Stop latches the current
FarmRun's accepted stop request and returns game focus so the current match can
finish normally. Emergency Stop revokes future automation authority and does
not exit the game, recover it, or fabricate a combat result.

Resume uses the existing checkpoint parser and canonical FarmRunner validator.
The UI hint is enabled only for the same durable lobby boundaries accepted by
the validator: graceful lobby stop, or an unfinalized checkpoint written at a
durable lobby boundary. `COMPLETED` and `EMERGENCY_STOPPED` checkpoints do not
enable Resume. Backend validation remains authoritative.

The UI was narrowed to 520 px wide (minimum 460 px) and uses a two-row control
button layout. This reduces game occlusion without changing backend behavior.

## Offline verification

```text
focused desktop/control/input tests: 46/46 PASS
full suite:                         564/564 PASS
python -m compileall -q src tools: PASS
git diff --check:                  PASS
```

Focused coverage includes single ownership, double Start, invalid lifecycle,
foreground handoff/failure, graceful focus return, generation staleness,
graceful/emergency races, zero post-ack input, resume validation/accounting,
UI close guard, and truthful Resume availability for completed, emergency, and
graceful checkpoints.

## Live B1 — UI Start

```text
FarmRunId:             b4f61920272645d6b93949a67d848606
configured target:     1 completed match
completed / attempts:  1 / 1
result:                1 WIN, 0 LOSS, 0 UNKNOWN
gameplay inputs:       16
postmatch inputs:      1
attempt 2:             not created
final lifecycle:       BOSS_LOBBY
controller:            STOPPED
safety counters:       all zero
```

The UI stayed responsive and Start foregrounded `PokiguardOnlines` before the
first boss-entry input.

## Live B2 — UI Graceful Stop

An initial diagnostic run `256b6c0a2f434b81a618f1d2f089828b` safe-stopped
because opening the UI consumed foreground close to the four-second local
action floor. No late input was sent. The controller was then hardened so the
graceful command synchronously returns the verified game window to foreground.

Accepted retry:

```text
FarmRunId:                    a8169e2b3e804734933370dc4548ba62
configured target:            3
stop requested during:        attempt 1 ACTIVE_COMBAT
completed / attempts:         1 / 1
result:                       1 WIN
gameplay / postmatch inputs:  19 / 1
next entry / attempt 2:       zero / not created
final lifecycle:              BOSS_LOBBY
checkpoint/controller:        STOPPED_GRACEFULLY / STOPPED
safety counters:              all zero
```

## Live B3 — UI Checkpoint Resume

The first UI run stopped gracefully after one completed match:

```text
historical FarmRunId:  e1723a3298384a809eb41148a23060d9
checkpoint:            1/5, 1 WIN
final boundary:        BOSS_LOBBY / STOPPED_GRACEFULLY
```

UI Resume created a distinct controller/run:

```text
resumed FarmRunId:     0de27ce9fa444f48ae260cb73ff9a7c4
continuation_of:       e1723a3298384a809eb41148a23060d9
historical start:      1/5
remaining work:        4 completed matches
final total:           exactly 5/5
results:               5 WIN, 0 LOSS, 0 UNKNOWN
attempts:              exactly 5
attempt 6:             not created
double count/replay:   zero
final lifecycle:       BOSS_LOBBY
controller:            STOPPED
safety counters:       all zero
```

## Live B4 — UI Emergency Stop

```text
FarmRunId:                          2fb98472d17d4634b5a4cc32fc9f5830
lifecycle at request:               ACTIVE_COMBAT, attempt 1
acknowledgement:                    EMERGENCY_STOP_ACKNOWLEDGED
gameplay actions before request:    3 SWAP
actions after acknowledgement:      0
boss entries after acknowledgement: 0
new matches after acknowledgement:  0
unfinished result counted:          no
checkpoint:                         EMERGENCY_STOPPED, 0/3
controller:                         STOPPED
```

The game was intentionally not exited or recovered by Emergency Stop. With
automation authority revoked, the game later applied its normal three-idle
rule and returned to the boss map. A normal manual UI path was used to re-enter
the Starburst lobby before B5. This is the intended Phase 2E.2 emergency
boundary, not a technical-recovery action.

## Live B5 — bounded UI farm

```text
FarmRunId:                 9ba4a5efd1074a26847603711c8ca75d
target / completed:        5 / 5
results:                   4 WIN, 1 LOSS, 0 UNKNOWN
attempts / unique MatchId: 5 / 5
attempt 6:                 not created
technical abort/recovery:  0 / 0
safe stops:                0
gameplay inputs:           98
lobby / postmatch inputs:  5 / 5
terminal confidence:       5 STRONG
memory/UI consistency:     5 CONSISTENT, 0 conflict/incomplete
final lifecycle:           BOSS_LOBBY
final state:               FARM_RUN_COMPLETE / controller STOPPED
stage result:              PASS
final invariant:           PHASE2E2_UI_BOUNDED_COMPLETED
```

Across all five attempts, these critical counters were zero:

```text
duplicate_inputs, misclicks, partial_inputs, wrong_turn_inputs,
stale_actions, boss_turn_inputs, postmatch_inputs, lobby_inputs,
input_after_combat, wrong_third_pass, local_turn_deadline_safe_stops,
safety_limit_reached, dead_board, sequence_desync
```

The run also naturally exercised card behavior: 11 evolution attempts with 4
successes, and 6 Attack casts with 5 accepted. In attempt 1 the low-HP finisher
branch selected Attack at boss HP 17,220 with player mana 1,132. No gameplay
policy was changed in this phase.

## UI/process health

- UI remained responsive during B1–B5; no unhandled UI-thread exception.
- Maximum simultaneous FarmRunner controllers: 1.
- Duplicate starts, stale command applications, wrong-run commands, and
  checkpoint double counts: 0.
- No orphan controller or polling worker was observed.
- Memory remained read-only. No direct game calls or network manipulation.

The final UI artifact is
`logs/desktop_ui/phase2e2_live_acceptance_v6/summary.json`. Clean close recorded
1,819/1,819 attached refreshes, 9,056 render ticks, zero refresh/UI errors,
one poller start, `pollerAliveAfterClose=false`, `controllerStopped=true`, and
`unexpectedError=null`. The UI process exited; the game process remained alive
at the exact `BOSS_LOBBY` boundary.

## Known NOT OBSERVED / deferred

- No natural technical recovery occurred in the accepted B5 soak.
- Phase 2E.3 lifecycle-aware operator polish and final close/shutdown UX are
  not implemented.
- REASONING and infinite farming remain unsupported.
- Pet-specific skill-card behavior remains deferred.

The intended next phase is **Phase 2E.3 — UI Hardening + Operator UX**, not
implemented here.
