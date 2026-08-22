# Phase 2E.1 Report — Desktop Control UI MVP

Date: 2026-08-22 (Asia/Saigon)

## Outcome

**PASS STRONG.** PokiguardToolV2 now has a Windows desktop UI shell, a
UI-facing read-only control plane, canonical BASIC configuration validation,
live runtime/checkpoint status, and a single bounded polling worker. The UI
has no FarmRunner, boss-entry, gameplay, postmatch, stop, or resume command
path.

The accepted base was commit
`0282f83d0638c49b9da2ee123ecd8c5795205914`. The dedicated Phase 2E.1 commit
and push result are recorded in the final operator handoff after validation;
embedding a commit's own hash in its tracked report is self-referential.

## UI technology

The UI uses Python's standard-library **Tkinter/ttk** with Tk 8.6. The project
had no existing desktop framework dependency, and this choice provides a
native Windows window, a conventional event loop, straightforward later
packaging compatibility, and no new third-party runtime dependency. Phase
2E.1 intentionally does not include packaging or visual theming work.

## Architecture and authority boundary

```text
Tkinter DesktopApplication
  -> DesktopViewModel (presentation + session-local draft)
  -> DesktopControlPlane (immutable, lock-protected snapshots)
  -> ReadOnlyGameStatusProvider / LatestCheckpointSummaryProvider
  -> MemoryBoardStateProvider + canonical boss-lobby/lifecycle readers
  -> PROCESS_QUERY_INFORMATION | PROCESS_VM_READ
```

`DesktopControlPlane` exposes copied frozen dataclasses rather than mutable
FarmRunner/runtime ownership objects. `ReadOnlyGameStatusProvider` receives
the accepted `attach_target` factory and constructs only the read-only memory
provider. It imports no Windows input, FarmRunner, boss-entry executor,
postmatch executor, or controller lease.

There are no mutating farm command methods in the control plane and no active
or hidden command buttons. Launching the UI never starts automation.

## Configuration surface

The session-local draft exposes only existing canonical values:

- `PlayStyle`: SIMPLE or CAREFUL;
- `ManaPriority`: EVOLUTION or ATTACK;
- `Intelligence`: BASIC only; REASONING is visibly unavailable and rejected;
- target boss ID/name, with current default evidence Starburst / `1289`;
- finite `target_completed_matches`, `max_technical_recoveries`, and
  `max_match_attempts`.

Validation delegates to the existing `PolicyConfig`, `FarmTarget`, and
`FarmRunLimits` models. Draft changes are memory-only and produce no backend
command or persistent preference. Runtime-observed target and configured
target are displayed separately.

## Status surface

The window presents:

- game detected/unavailable and attach state;
- PID and architecture when attached;
- canonical local lifecycle, MatchId, and diagnostic CombatSessionKey when
  available;
- runtime-observed target ID/name;
- current session draft;
- the newest valid checkpoint's finalized status and aggregate results;
- snapshot version/time, backend health, provider reason, and latest error.

Unknown or failed observations display `UNKNOWN`, `UNAVAILABLE`, detached, or
`STALE / NON-ACTIONABLE`; they never become actionable truth.

## Polling, responsiveness, and fail-closed behavior

One reusable `SnapshotPoller` worker performs process-memory/checkpoint reads.
Tk's UI thread only renders the last immutable snapshot every 200 ms. A slow
read therefore leaves the prior snapshot visible without blocking normal
rendering. The worker uses a bounded interval and is never recreated for each
refresh.

Runtime/provider exceptions are caught at the control-plane boundary. The
last diagnostic data may remain visible, but attachment is invalidated and the
snapshot is marked stale/error. A stopped game detaches cleanly. Normal window
close cancels Tk callbacks, stops and joins the worker, closes the read-only
attachment, and destroys the root window.

During the first live diagnostic, normal active-session DTO wait branches
were incorrectly shown as backend errors because `ProviderPoll` retained its
authoritative `CombatSessionKey` but omitted the larger lifecycle observation.
The UI adapter now preserves `ACTIVE_COMBAT` only when that provider-issued
session key is present. The accepted retry recorded zero such false errors.

## Automated validation

Focused coverage includes canonical configuration mapping and REASONING
rejection, connected/detached/lifecycle snapshot mapping, valid and malformed
checkpoint handling, read failures, slow reads, exactly one polling worker,
clean worker stop, session draft isolation, lack of gameplay command methods,
and lack of input/farm imports or CLI command flags.

Final validation results:

```text
focused desktop tests: 23 PASS
full suite:             548 PASS
python compileall:      PASS
git diff --check:       PASS
```

## Offline Stage A

Accepted artifact:
`logs/desktop_ui/phase2e1_stage_a_20260822_181535/`.

The real Tk window launched with an explicit offline provider and auto-closed
normally. Evidence:

| Field | Value |
|---|---:|
| Refreshes | 12 |
| Render ticks | 15 |
| Poller starts | 1 |
| Poller alive after close | false |
| Handled/unhandled UI errors | 0 / 0 |
| FarmRunner starts | 0 |
| Autonomous gameplay inputs | 0 |

The unavailable game state, full configuration surface, checkpoint summary,
and backend health surface rendered without dispatching any command.

## Live Stage B1 — 10-minute read-only smoke

Accepted artifact:
`logs/desktop_ui/phase2e1_b1_retry1_20260822_1825/`.

The UI was configured for 600 seconds. The first-to-last refresh observation
span was 598.935 seconds; shutdown/finalization completed the bounded window.

| Field | Evidence |
|---|---|
| Game process | PID `18356`, x64, detected throughout |
| Process access | `PROCESS_QUERY_INFORMATION`, `PROCESS_VM_READ` |
| Refreshes | 287/287 attached; 0 detached; 0 errors |
| UI responsiveness | 2,945 render ticks; 0 handled/unhandled UI errors |
| Lifecycle refresh | repeated, ending at exact `BOSS_LOBBY` |
| Final target | runtime `Kassadin` / ID `1` (kept separate from draft) |
| Poller starts/leaks | 1 / 0 |
| FarmRunner starts | 0 |
| Automated gameplay inputs | 0 |
| Boss-entry/stop/resume commands | all 0 |

The final canonical boss-lobby reason was `WorldBoss discovery proven; visual
entry control still required`. The UI did not use that discovery to click the
entry control.

## Live Stage B2 — read-only transitions

**OBSERVED.** During the same accepted smoke, externally driven game state
produced the following observer-only transition sequence:

```text
ACTIVE_COMBAT -> POSTMATCH -> BOSS_LOBBY -> LOBBY_OTHER
-> BOSS_LOBBY -> ACTIVE_COMBAT -> LOBBY_OTHER -> BOSS_LOBBY
```

The UI followed canonical backend state without blocking or generating the
transitions. FarmRunner starts, autonomous gameplay input, automated
postmatch confirmation, and automated boss entry were all zero.

## Safety evidence

The accepted summary records all of these as zero:

- `farm_runner_starts`;
- `gameplay_windows_inputs`;
- `boss_entry_commands`;
- `graceful_stop_commands`;
- `emergency_stop_commands`;
- `checkpoint_resume_commands`;
- unhandled UI-thread exceptions;
- orphan polling workers after normal close;
- stale/actionable-state violations and unexpected farm dispatches.

Phase 2D.6 runtime/gameplay semantics were not changed.

## Files added or changed

- `src/pokiguard_v2/desktop_control_plane.py`;
- `src/pokiguard_v2/desktop_runtime.py`;
- `src/pokiguard_v2/desktop_ui.py`;
- `tools/desktop_ui.py`;
- `tests/test_desktop_control_plane.py`;
- `tests/test_desktop_runtime.py`;
- `docs/phase2e1_report.md`;
- `docs/phase2e1_runbook.md`;
- `docs/CURRENT_STATE.md`.

`docs/DECISIONS.md` is unchanged because this phase required no new gameplay
or product decision.

## Known limitations and stop boundary

- UI Start, boss entry, graceful stop, emergency stop, checkpoint resume, and
  UI-driven bounded farm are **NOT IMPLEMENTED**; they are reserved for Phase
  2E.2.
- Draft preferences are session-local; persistent preferences remain later
  work.
- The UI reads the latest valid checkpoint summary only; it does not mutate or
  resume it.
- No game launch, standalone packaging, installer, sophisticated operator log
  UX, pet-specific skill-card work, or REASONING was added.
- Missing historical Phase 2D.6 B3 RAM telemetry remains unavailable and was
  not reconstructed.

The controller is stopped. Phase 2E.2 was not started.
