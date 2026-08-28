# Phase 2E.3 Runbook

Run from `D:\PokiguardToolV2` with 64-bit Python. The game must already be
running. Live Start/Resume requires the user to be inside an exact
`CHINH_PHUC_ROOM`; the Desktop UI reads and pins that room's positive runtime
`enemyPetId`. It does not navigate from the general game lobby through the
Chinh Phuc islands.

## Offline validation

```powershell
$env:PYTHONPATH = 'src;.'
python -m unittest tests.test_desktop_control_plane `
  tests.test_desktop_farm_controller `
  tests.test_desktop_runtime `
  tests.test_desktop_preferences `
  tests.test_desktop_ui_hardening -v
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
```

Final Phase 2E.3 implementation baseline:

```text
focused UI hardening: 70/70 PASS
full regression:      725/725 PASS
compileall:           PASS
git diff --check:     PASS
```

## Launch the live UI

Use a new artifact directory for every UI process. Preferences are separate
from FarmRunner checkpoints and must never cause automatic Start/Resume.

```powershell
pythonw tools\desktop_ui.py `
  --artifacts logs\desktop_ui\phase2e3_manual_001 `
  --preferences logs\desktop_ui\phase2e3_operator_preferences.json
```

The UI displays at most 500 operator-log entries. `REASONING` and infinite
farming remain unsupported. Start restores only the verified Pokiguard PID's
window, normalizes its client area to `1280x720`, returns it to foreground, and
revalidates the exact PID/HWND/client size before FarmRunner may send input.

## Live B1 — lifecycle and error UX

1. Launch with no active FarmRunner.
2. Verify game detection, attachment, lifecycle and exact current-room target.
3. In a valid exact boss room, Start is available; outside it, the UI explains
   the unavailable state and Start stays disabled.
4. Verify Stop After Current Match is available only for a live owned run and
   Emergency Stop remains available while automation authority is active.
5. If testing the game-absent state, do so only while no run is active. The UI
   must stay alive, show process unavailable, send zero input and never launch
   the game automatically.

## Live B2 — preference persistence and corruption

1. With no controller active, set a supported BASIC configuration and save it.
2. Close normally and relaunch with the same preference path.
3. Verify play style, mana priority and finite limits are restored, while no
   FarmRunner starts or resumes.
4. Use a separate tool-owned preference file containing invalid JSON.
5. Relaunch and verify safe defaults plus a bounded warning, zero Start/Resume,
   and no checkpoint mutation.

Never place a pet ID, active match/session, controller ownership, result
counters or checkpoint data in preferences.

## Live B3 — active close with graceful stop

1. Start a finite run with target greater than one.
2. During `ACTIVE_COMBAT`, request window close.
3. Select `Stop After Current Match & Close`.
4. Verify the UI stays alive and responsive while exactly one graceful-stop
   edge is latched.
5. Verify the current match completes and is accounted normally, postmatch is
   confirmed, final lifecycle is exact `BOSS_LOBBY`, no next entry occurs, the
   controller reaches `STOPPED`, then the poller/UI exit.
6. Confirm the game process remains running.

The Cancel path must send no stop command and preserve the current controller.

## Live B4 — active close with emergency stop

1. Start another finite run and wait for active automation.
2. Request window close and select `Emergency Stop & Close`.
3. Record the Emergency Stop ACK timestamp.
4. Verify zero gameplay input, boss entry and new match after ACK.
5. Verify the controller reaches `STOPPED`, then the poller/UI exit. The game
   remains running and may remain in combat; no unfinished result is invented.

## Live B5 — bounded log and responsiveness

Exercise normal Start, lifecycle changes, match completion, control-state
updates and shutdown. Verify:

```text
operator log entries <= 500
poller starts = 1
max simultaneous controllers <= 1
worker-thread Tk writes = 0
unhandled UI-thread exceptions = 0
UI remains responsive
```

The exact log cap is additionally proven deterministically by
`tests.test_desktop_ui_hardening` without spamming game input.

## Live B6 — exact 25-match UI soak

1. Return to the exact selected pet room and keep Pokiguard available for
   normal foreground input.
2. Configure BASIC, finite target `25`, and `max_match_attempts >= 25` with
   enough operational margin. Technical recovery itself has no farm-lifetime
   cap.
3. Click Start once in the Desktop UI. Do not launch FarmRunner from CLI.
4. Leave the UI open throughout the run. Do not resize the game mid-run.
5. Wait for the controller to stop at normal bounded completion.
6. Verify:

```text
completed_matches = 25
wins + losses + unknown_results = 25
no attempt after the attempt that reaches completed_matches = 25
max simultaneous controllers = 1
duplicate/stale/wrong-run command violations = 0
checkpoint double counts = 0
critical gameplay/input violations = 0
final controller = STOPPED
final lifecycle = BOSS_LOBBY
```

Technical aborts are not completed matches. Any exact-pet map re-entry must
select only the current farm session's pinned runtime ID. Successful recovery
has no farm-lifetime budget: every independently proven technical incident is
offered a new one-shot recovery coordinator. A failed/ambiguous recovery still
stops fail-closed; do not relabel it as a completed UNKNOWN.

During the soak, inspect participant source telemetry as well as board/input
counts. `Active.playerStatsMap/ObfuscatedInt.Value` is the primary current
participant source. The serialized `playerStatsList` is fallback/consistency
evidence only because a long live run proved it can retain only the boss. A
declared but malformed/changing map, actor-key mismatch, overlapping pointer
conflict, or ambiguous local ownership must send no card/input that depends on
HP/mana/nộ. No participant snapshot may be reused across polls or matches.

Production uses an inclusive one-second action floor. A current local-turn
sample at `1` may still send SWAP/CAST after the normal fresh preflight; `0`
must send no new input and may hand off to bounded technical recovery when its
exact session/actionability proof is available. This includes the turn after
an unconfirmed action and an authoritative idle `2/3` mandatory reset. Run
`0d465c3f5d4b40aa94abf62bb0b00b13`, where one- and two-second SWAP attempts
both lacked ACK before ownership was removed, is classified as lag/unconfirmed
action evidence rather than proof that the displayed `1` cannot accept input.

The pre-entry transport prime must learn both `ChatMessageDTO` and
`WsCombatBatch` allocation regions. Normal combat polls scan exact learned
regions only. A new ACK gap may add the immediate allocator neighbours once;
it must not repeatedly broad-scan the complete 8-16 MiB managed heap envelope
inside ordinary player-turn evaluation.

The first combat action may reuse the immutable 64-cell opening already proven
by the entry gate instead of performing a second heap stabilization cycle.
This fast path is valid only for the exact expected session while direct
MatchService roots still prove local ownership, turn 0/1, local move sequence
0, no prior move and at least one remaining second. Repeat that cheap direct
proof immediately before input. Any mismatch uses the normal provider, and any
sent SWAP, EVOLVE or CAST permanently disables opening reuse for that combat.

Technical recovery deliberately reuses one provider instance. Its
`highestAckedSequence` telemetry is a current-session gauge and must be reset
on both lifecycle clear and new-session bind. During recovered-opening handoff,
an initially stale non-null gauge keeps gameplay locked for the full bounded
guard. Continue only after it becomes null, two pristine current-session states
are observed and the timer remains above four seconds. A persistent non-null
ACK, changed session or non-pristine local action state is a fail-closed stop.

When a normal postmatch leaves a detached exact-pet room shell, the controller
may send at most one proven shell-exit click. It must then prove either the
runtime-derived hunt-order badge in two stable map frames, or the standard
leave modal in three stable frames before one `BOSS_ROOM_SHELL_CONFIRM` click.
After an optional confirm it must again prove the exact map badge before the
single target selection. Missing/ambiguous modal and badge evidence sends no
additional click and fails closed.

The final map preflight accepts two exact owner-free runtime shapes: the normal
`BOSS_LOBBY/WORLD_BOSS_LIST`, or the post-detached-shell transitional
`LOBBY_OTHER/branch=None`. The transitional shape is valid only with lobby
lifecycle, null room ID/type, null owner, `is_host=false`, no provider session,
unchanged exact Button/Pet/PlayerPrefs association and the already stable
runtime-derived badge. An owned room, ACTIVE lifecycle or any other state/
branch remains a zero-input rejection.

If one proven Start click receives no response for the complete entry timeout,
the UI-controlled FarmRunner may retry Start exactly once within the same
pending attempt. Immediately before that retry it must re-prove no combat
owner, the same clean room ID/pet/Button address, unchanged foreground client
geometry, and the same Start signature in two stable frames. Record the input
as `BOSS_ENTRY_RETRY`, not as a duplicate entry or a new match attempt. A
second timeout is terminal and must stop fail-closed.

When `ManagerRoom.selectedCards` is empty but `RoomDTO.cards` proves one unique
Attack, Unity may temporarily render only the cyan strip header. Card selection
waits at most 15 seconds with zero input and requires two complete consecutive
frames at the runtime-derived slot; locator thresholds and foreground geometry
remain unchanged. After one proven click, runtime selection verification waits
at most ten seconds. These lobby-only waits never extend a combat turn.

When `ManagerRoom.selectedCards` already proves the unique Attack, do not click
the selected toggle again because that could deselect it. Resolve the matching
RoomDTO index when it is unique, prove that exact selected card body using the
same visual/runtime identity gate, and require it to remain stable for three
seconds before Start. Re-read the same room, boss, Manager selection and visual
slot atomically at the end of the settle window. If RoomDTO cannot provide one
unique matching index, retain the Manager selection as authoritative, record
`preentry_attack_selection_settle_unavailable`, send zero card input and use the
ordinary fail-closed combat card discovery path.

Live reference run `5048e07b690d456ca0783ff6b949dc4e` used the old UI
process and therefore does not validate this new lobby settle. It does validate
the pristine first-turn handoff, EVOLVE failure fallback, EVOLVE success,
accepted ATTACK casts and the authoritative 2/3 mandatory reset. Its final
attempt reached a STRONG WIN before an explicit F9 edge finalized the farm run;
do not count that emergency-stopped attempt as a completed checkpoint result.

Live exact-25 run `0345ab13927c4607bf9d381c97085725` reached 19/25
STRONG/CONSISTENT WINs in 23 attempts with zero LOSS/UNKNOWN. Attempt 23
accepted a pristine 64/64 local opening at timer 13, then the game added the
local actor to validated `Board._leftActorNumbers` while lifecycle remained
`ACTIVE_COMBAT`; the UI simultaneously showed timer 0 and `[đã thoát]`. The
controller correctly classified `LOCAL_PLAYER_LEFT_ACTIVE_COMBAT`, but the old
lifetime cap withheld its dispatcher after three prior recoveries, leaving
`recoveryTrigger=null` and finalizing `COMBAT_SAFE_STOP`. Production now always
provides the per-combat one-shot dispatcher and the FarmRun ledger no longer
enforces the compatibility-only recovery limit. The UI no longer presents
`Max recoveries`. A legacy cap-stop checkpoint with exactly one orphaned
attempt may resume history only after desktop preflight independently proves
the exact pinned boss lobby; that orphan is converted to a technical abort,
and no executable combat state is restored. The implementation is offline
verified at **701/701 PASS** with compileall and diff checks clean.

Live exact-25 retry `40e07464eebd4509a91439877d63c6f2` reached 21/25.
Attempt 23 froze with direct MatchService fixed at turn 10, boss owner, timer
14 and highest ACK 24 for the rest of the 1800-second controller budget. This
was not covered by the local-turn deadline detector, and the visual
`[đã thoát]` state did not arrive through a newly published
`Board._leftActorNumbers` GameState. Build `v1.0.0+10` therefore adds a
read-only whole-combat progress watchdog: four or more identical exact-session
samples spanning at least 45 seconds dispatch
`ACTIVE_COMBAT_PROGRESS_STALLED` into the existing unbounded per-incident
recovery path. Any timer/turn/owner/move/ACK progress or ambiguous/pending state
resets the proof. The captured attempt-23 log replays to a trigger after 50.343
seconds. Offline verification is **713/713 PASS**; restart the UI before the
next live continuation.

Live retry `4ab9bda9429144f991dd8bdcd6e83956` completed 11/25 STRONG
WINs before attempt 12 hit an exact `DEAD_BOARD_NO_REFRESH`. Recovery exited,
confirmed the exact Starburst `1289` room and sent one re-entry. The game
created distinct match `M_d624138a` and exposed a complete 64-cell MATCH_START,
but the prior raw `highestAckedSequence=53` remained while current-session
batches were sequence 3 through 7. The old maximum blocked provider
publication until `ENTRY_TIMEOUT_OPENING_BOARD`; after the game ejected that
unplayed recovered match, the one-shot fallback observed an exact-pet,
owner-free `DETACHED_ROOM_SHELL_CANDIDATE` and then stopped.

Build `v1.0.0+11` scopes that proven frozen residue to the next distinct
session. The raw value remains unchanged and logged; only the new MATCH_START
or batches independently attested by the exact current BoardWs owner/current
MatchId transport can become the effective watermark. Any unexplained raw ACK
advance remains a zero-input rejection. Failed recovery may also audit one
already-sent re-entry after combat ownership is gone and continue through the
existing exact detached-shell -> island-map -> pinned-pet-room path. Duplicate
re-entry, ambiguous target, active combat ownership or missing visual/runtime
proof still fails closed. Offline verification is **719/719 PASS**.

Live run `73b33c680535474fba7031732bd6347f` then reached 24/25
STRONG/CONSISTENT WINs. Attempt 25 recovered through the exact Starburst
`1289` fallback after the client displayed a lost-room connection. Attempt 26
entered and sent its opening action, but only 8 of 11 SWAPs were confirmed;
two timed out and the mandatory post-idle-2 SWAP remained unconfirmed until
the game ejected the player. Log timestamps show the fixed 0.25-second click
gap was still used for every SWAP despite the operator-observed 2-second ping
and intermittent 3-4 FPS.

Build `v1.0.0+12` adds executor-owned adaptive SWAP pacing that persists
across matches in the same FarmRunner process. Recovery/re-entry arms a
1.0-second gap; an unconfirmed SWAP raises it to the 1.5-second maximum; slow
accepted transitions retain degraded mode; eight consecutive fast accepted
SWAPs decay one level. Timer-aware clamping preserves 1.25 seconds for click
two. `action_sent`, timeout and final summary evidence include pacing mode,
reason, lag score and actual delay. The overlay Ping/FPS text is not treated as
authoritative because no verified memory field or dependency-free parser is
available.

Attempt 26 finally settled as `DETACHED_ROOM_SHELL_CANDIDATE`, with null room
ID/type and owner, exact enemy pet `1289`, and no combat session. The normal
unproven-terminal branch previously accepted only `WORLD_BOSS_LIST`, causing
the observed stop. It now shares the exact same centralized ejection-source
proof used by failed recovery and may restore the pinned room from either
owner-free origin. Ambiguous state still sends no target input.
Offline verification is **722/722 PASS** with compileall and diff checks clean.

After normal completion, close the idle UI and verify controller, poller and UI
process are all gone while Pokiguard remains running.

## Accepted final evidence

FarmRun `3aa7b7e1279a4c91a03c2f72dd9d48c4` completed the B6 target:

```text
completed / attempts:        25 / 27
results:                     25 WIN, 0 LOSS, 0 UNKNOWN
strong/consistent terminals: 25 / 25
technical abort/recovery:    2 / 2
target:                      Starburst / 1289
stop reason:                 FARM_TARGET_COMPLETED
final lifecycle/controller:  BOSS_LOBBY / STOPPED
attempt after target:        absent
```

Attempts 3 and 23 were independent `DEAD_BOARD_NO_REFRESH` incidents. Both
one-shot coordinators exited, confirmed, invalidated the old session,
re-resolved exact Starburst `1289`, accepted a distinct pristine opening and
returned control with no wrong-target, duplicate or stale-session input.
Attempt 27 produced completion 25 and no attempt 28 was created.

Idle UI close then wrote
`logs/desktop_ui/20260828_231815/summary.json`: 5,639 attached refreshes,
54,610 render ticks, 67/500 maximum operator-log entries, one poller start, one
maximum concurrent controller, zero UI/thread errors,
`pollerAliveAfterClose=false`, controller exit code zero, and the game process
still alive. The stable acceptance report is
[phase2e3_report.md](phase2e3_report.md).

## Evidence locations

- Desktop UI process evidence: `logs\desktop_ui\<stage>\events.jsonl` and
  `summary.json` after clean close.
- FarmRun evidence: `logs\farm_runs\<FarmRunId>\events.jsonl`,
  `checkpoint.json`, `summary.json`, and per-attempt artifacts.
- Working-set telemetry: FarmRunner summary `resourceTelemetry` generated by
  the accepted x64 `K32GetProcessMemoryInfo` sampler.

## Boundaries

Do not add packaging, an installer, automatic game launch/login, infinite
farming, multi-target rotation, REASONING, memory writes, injection, direct
game method calls, or packet/network manipulation. Stop after Phase 2E.3 is
accepted, documented, committed and pushed.
## Live EVOLVE regression check

After changing Fusion UI discovery, restart the Desktop tool so the process
loads the new provider code. In one fresh combat with `ManaPriority=EVOLUTION`:

1. verify the mandatory first local turn publishes/scans the board and sends
   its opening SWAP without optional-UI delay;
2. on the first observed boss turn (`turn >= 2`), verify
   `sessionUiWarmupCompleted == true` and that CardUI/FusionCardUI discovery
   runs even while local Mana is below the runtime Fusion cost;
3. require `cachedFusionUiAddresses == 1` and either
   `fusionOwnerAnchorReason == current_fusion_ui_resolved` or
   `current_fusion_ui_resolved_by_session_warmup` before EVOLVE;
4. require an `action_sent` with `action=EVOLVE` only while the current
   `FusionCardUI` is interactable and the inclusive ten-second same-turn floor
   is met;
5. prove the terminal attempt from game-owned Fusion state and Mana transition;
6. verify that a successful functional EVOLVE is followed by a fresh full
   state read and, when policy selects one, a same-turn consuming action.

Zero/ambiguous UI candidates, a short timer, low-boss-HP mode, insufficient
Mana, no selected evolution pet, or a non-interactable Button must continue to
fail closed without a blind click.

Build `v1.0.0+13` adds two regression checks before resuming the long soak:

1. A combat containing local actor, Fusion pet actor and boss must log a
   non-null `player`, the exact local Mana, and `provider.localActorNumber`
   resolved from `MatchService.Players`; it must never rely on actor `1` as a
   constant.
2. A late SWAP must record
   `FINAL_SWAP_DIRECT_RUNTIME_PREFLIGHT_REJECTED` with `inputSent=false` when
   the direct turn owner/timer changes during preparation. No `MATCH_REJECT:
   Không phải lượt bạn` should be produced by that unsent proposal.
