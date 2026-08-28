# Phase 2E.3 — UI Hardening + Operator UX + Long UI-Driven Soak

## Result

**PASS STRONG** on 2026-08-29 (Asia/Saigon).

Base commit: `b3db75af` (accepted Phase 2E.2). This Phase 2E.3 commit contains
the implementation, tests, runbook and report described here; its exact hash
is reported in the final handoff after Git creates it.

Phase 2E.3 hardens the Desktop UI and the accepted UI-controlled FarmRunner.
It retains the read-only-memory and normal-foreground-input architecture. It
does not add infinite farming, automatic game launch/login, multi-target
rotation, memory writes, direct gameplay calls or network manipulation.

## Original Phase 2E.3 scope

The original phase required:

- lifecycle-aware Start/Resume/Stop command gates and one controller owner;
- persistent BASIC operator preferences with no automatic Start/Resume;
- graceful and emergency close behavior;
- a bounded operator log, one poller and no worker-thread Tk writes;
- a responsive compact UI throughout a long UI-driven run;
- an exact 25-completed-match soak ending at a safe boss-lobby boundary.

Live B1-B5 had already accepted lifecycle/error UX, preference persistence,
graceful close, emergency close, bounded logging and responsiveness. The final
B6 run below closes the remaining exact-25 requirement.

## Live B6 — exact 25 completed matches

Accepted FarmRun:

```text
FarmRunId:                     3aa7b7e1279a4c91a03c2f72dd9d48c4
target boss:                   Starburst / 1289
configured completed target:  25
configured maximum attempts:  32
completed / attempts:         25 / 27
results:                      25 WIN, 0 LOSS, 0 UNKNOWN
technical aborts/recoveries:  2 / 2
terminal confidence:          25 STRONG
memory/UI consistency:        25 CONSISTENT, 0 conflict/incomplete
final run state:              FARM_RUN_COMPLETE
stop reason:                  FARM_TARGET_COMPLETED
final lifecycle:              BOSS_LOBBY
next attempt after target:    absent
duration:                     8,670.47 seconds
```

Attempts 3 and 23 independently proved `DEAD_BOARD_NO_REFRESH`. Each incident
locked gameplay, sent one proven Exit and Confirm, invalidated the old session,
re-resolved exact Starburst `1289`, sent one recovery re-entry, accepted a
distinct pristine MATCH_START and handed a full reread to gameplay. Both
recoveries recorded zero duplicate exit/confirm/re-entry, wrong target, stale
session confusion or gameplay input during recovery.

Technical aborts do not count as completed matches. Attempt 27 produced the
25th completed result and the controller created no attempt 28. This is the
correct target boundary when recovery attempts exist; an absolute requirement
that `attempt_026` never exist would contradict the accepted accounting rule.

## Gameplay and state evidence

```text
SWAP sent / acknowledged / rejected: 447 / 429 / 0
SWAP aborted after state change:      15
CAST sent / accepted / rejected:      64 / 54 / 0
EVOLVE attempts / success / failed:   29 / 13 / 16
authoritative PASS actions:           52
provider read/DTO/stale errors:       0 / 0 / 0
```

The 18 SWAPs without normal acknowledgement are fully accounted for by 15
state/lifecycle aborts and three bounded response timeouts. Four action records
expired without a blind retry. The run still completed normally with zero
server rejection, wrong-turn input, duplicate input, stale input, misclick,
partial input, sequence desync, input after combat or safety-limit stop.

EVOLVE success/failure came from game-owned Fusion response/state and Mana
transitions. Attack-card acceptance came from the accepted card response/Mana
path. Terminal results came from current participant state before cleanup and
were cross-checked against the postmatch result UI.

## Additions driven by live evidence

The following production hardening was not part of the initial UI-only prompt,
but became necessary to complete the accepted long run safely.

### Session-pinned exact-pet recovery

- Start reads and pins the exact current room's positive enemy pet ID/name.
- Recovery may re-enter only that pet for the lifetime of the farm session.
- The pin is cleared when the FarmRun ends; a later Start again requires an
  exact boss room.
- No navigation from the general lobby through Chinh Phuc/island selection is
  attempted.

### Per-incident recovery without a farm-lifetime cap

- Every independently proven technical incident receives a new one-shot
  recovery coordinator.
- A coordinator still permits only its bounded Exit/Confirm/Re-entry sequence.
- Ambiguous or failed recovery remains a fail-closed stop.
- Legacy `max_technical_recoveries` remains serialized only for checkpoint/CLI
  compatibility and is not enforced as a farm-lifetime ceiling.

### Freeze, ejection and detached-shell handling

- A read-only active-combat progress watchdog detects an exact session whose
  turn/owner/timer/move/ACK state is unchanged for at least 45 seconds.
- Local-player-left, timer-zero, dead-board and proven active-combat stall paths
  route to the same bounded recovery authority.
- Lost-room and owner-free detached-room-shell states may recover through the
  exact runtime-derived island badge and pinned target.
- Owned, active or ambiguous map/room state still sends zero target input.

### Session-scoped ACK and recovered-opening isolation

- A previous match's frozen raw ACK maximum cannot suppress a new MATCH_START.
- Only transport evidence independently tied to the current BoardWs owner or
  MatchId may advance the effective current-session watermark.
- Recovery handoff requires pristine current-session state, a clean ACK epoch
  and a full provider reread before gameplay resumes.

### Card and Fusion preparation

- Lobby entry verifies the unique selected Attack card before Start.
- An already-selected Attack is never clicked again and accidentally removed.
- An absent required Attack may be selected through a bounded runtime/visual
  identity gate; incomplete card rendering waits without blind input.
- Missing/ambiguous cards fall back to board-only gameplay.
- Fusion/Card UI warmup starts on the first observed boss turn rather than
  waiting until Mana reaches the action cost.
- Local participant ownership now follows
  `ChatService.Username -> MatchService.Players[username].actorNumber`, so a
  separate Fusion-pet actor cannot make local HP/Mana ownership ambiguous.

### Gameplay policy hardening

- Below the configurable low-boss-HP threshold (default 30,000), EVOLVE is
  suppressed and the BASIC policy prioritizes a Sword finish, Mana and Attack.
- Authoritative idle/pass state still comes from game data. A proven idle 2/3
  requires a consuming reset instead of a third pass.

### First-turn latency and adaptive SWAP input

- The exact immutable 64-cell opening proven by entry may feed only the first
  pristine local action after a cheap direct runtime proof.
- Ordinary transport scanning uses learned current allocation regions rather
  than repeatedly scanning the broad managed-heap envelope.
- SWAP click pacing is executor-owned: 0.25 seconds normally, 1.0 second after
  recovery/re-entry, and at most 1.5 seconds after an unconfirmed SWAP; stable
  fast acknowledgements decay the delay.
- The production action floor remains inclusive at one displayed second.
- A final direct MatchService preflight immediately before SWAP cancels an
  unsent proposal if match, owner, turn, timer or local move sequence changed.
- Response deadlines begin at the actual input boundary.

### Entry and postmatch resilience

- A proven Start click with no response may be retried exactly once after a
  fresh atomic room/target/button/geometry preflight.
- Postmatch and recovery flows support the proven detached-room shell without
  inventing an UNKNOWN result or reusing executable combat state.

### Operator UI changes

- The compact Control tab hides internal attachment/process/session/MatchId and
  pinned-pet fields while retaining them as backend diagnostics.
- Preferences live in a separate table-aligned tab.
- Target matches and Max attempts are locked to the accepted immutable config
  for the active run.
- Background clicks can release entry focus; launch no longer focuses Target
  matches.
- Start foregrounds the verified game PID and normalizes its client area to
  `1280x720` before input is authorized.
- `run_tool.bat` provides a single-instance, non-autostart launcher.
- The pre-MVP build label is `Pokiguard Tool V2 - v1.0.0+13`.

## UI/process close evidence

The user closed the idle UI after bounded completion. The final UI summary
records:

```text
attached refreshes / errors:          5,639 / 0
render ticks:                         54,610
operator log max / configured bound:  67 / 500
poller starts:                        1
poller alive after close:             false
max simultaneous controllers:         1
handled/unhandled UI errors:          0 / 0
worker-thread Tk writes:              0
controller exit code:                 0
controller state:                     STOPPED
game process after UI close:          still running (PID 2836)
```

The UI's final generic world-boss-list candidate was Kassadin after the user
left the completed Starburst room. This does not alter the completed
checkpoint: its pinned target remains Starburst `1289`, and the session pin was
correctly cleared when the FarmRun ended.

## Offline verification

Build `v1.0.0+13` was verified before the accepted soak:

```text
focused UI/controller: 70/70 PASS
full regression:       725/725 PASS
python compileall:     PASS
git diff --check:      PASS
```

The same full verification is rerun during phase finalization and its final
result is reported in the commit handoff.

## Safety boundary

- process access remains `PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`;
- no `WriteProcessMemory`, injection, remote thread, hook or game-file change;
- no direct `RequestSwap`, `SendMove` or Unity gameplay invocation;
- no packet/WebSocket manipulation;
- all actions use normal foreground Windows input;
- invalid, stale, incomplete or ambiguous state fails closed.

## Evidence

- FarmRun: `logs/farm_runs/3aa7b7e1279a4c91a03c2f72dd9d48c4/`
- FarmRun summary: `run.json`
- Durable final ledger: `checkpoint.json`
- Farm/recovery timeline: `events.jsonl`
- UI summary: `logs/desktop_ui/20260828_231815/summary.json`
- UI timeline: `logs/desktop_ui/20260828_231815/events.jsonl`

Runtime artifacts remain intentionally excluded from Git because they contain
large process/session-specific diagnostics. This report and the runbook retain
their stable evidence IDs and acceptance totals.

## Final conclusion

**Phase 2E.3 is PASS STRONG.**

The accepted product boundary is a compact UI-controlled, finite, exact-current
boss-room farm with session-pinned recovery, read-only game-state input, the
existing solver as gameplay source of truth and normal Windows input. Future
scope requires a new explicit phase request.
