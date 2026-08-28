# Phase 2D.6 Runbook — Long-Running Farm Operations + Graceful Control

Operator guide for the Phase 2D.6 live stages.  Read this fully before
starting B1.

## 0. Safety model (unchanged from earlier phases)

- Game memory is **read-only** (`PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`).
  No writes, no injection, no packet manipulation, no direct game calls.
- All gameplay, lobby, postmatch and recovery actions are **normal foreground
  Windows input** (real clicks in a focused window).
- Every run is **finite**.  There is no infinite farming mode and no flag that
  can request one.

## 1. Hotkeys

| Key | Meaning | Notes |
|-----|---------|-------|
| **F6** | **Graceful stop** (new in 2D.6) | Finish the current match, return to boss lobby, then stop.  Never enters a new match. |
| F7 | Pause | Disabled at farm level |
| F8 | Boss entry confirmation | Already in use — this is why graceful stop is F6 |
| F9 | **Emergency stop** | Unchanged.  Stops as fast as safely possible.  A run stopped by F9 **cannot be resumed**. |
| F10 | Manual recovery step | Unchanged |

### F6 vs F9 — pick the right one

- **F6** = "I want to stop soon, cleanly."  The current match is played to its
  natural end, the postmatch dialog is confirmed, the game returns to the boss
  lobby, and only then does the tool stop.  The run is **resumable**.
- **F9** = "Stop now."  Emergency only.  The run is finalized as
  `EMERGENCY_STOPPED` and is **deliberately not resumable** — an emergency stop
  means the world state is not trusted.

One physical F6 press produces exactly one logical stop request.  Pressing F6
repeatedly is harmless; extra presses are counted and ignored.

## 2. Preconditions for every live stage

1. Pokiguard is running and **at the boss lobby**.
2. The target boss is **Starburst (`--boss-id 1289`)** and is available.
3. No other automation tool is running (the controller lease will otherwise
   refuse to start with `CONTROLLER_CONFLICT`).
4. The game window can be brought to the foreground and left there.
5. Reset-evidence file exists at `logs\phase2c2c_reset_capabilities.json`.

PowerShell setup:

```powershell
cd D:\PokiguardToolV2
$env:PYTHONPATH = 'src'
```

## 3. Return codes

| Code | Meaning |
|------|---------|
| 0 | Stage accepted (PASS) |
| 2 | Stopped without meeting the acceptance predicate |
| 1 | Configuration / checkpoint error — **zero Windows input was sent** |
| 130 | Ctrl+C |

## 4. Stage A — offline, no game needed

Run this first.  It sends **zero** Windows input.

```powershell
python tools\farm_run.py --stage-d6-a-control
```

Expect `"accepted": true` and `"actualWindowsInputs": 0`.

## 5. Stage B1 — prove the graceful stop

**Goal:** prove that F6 finishes the current match and then stops at the boss
lobby without ever entering a new match.

> **Do not press F9 during this stage.**  Using F9 makes the stage fail by
> definition — B1 exists to prove the *new* control works on its own.

```powershell
python tools\farm_run.py `
  --stage-d6-b1-graceful `
  --new-run `
  --boss-id 1289 `
  --target-matches 3 `
  --max-technical-recoveries 1 `
  --max-match-attempts 5 `
  --reset-evidence logs\phase2c2c_reset_capabilities.json
```

**What you do:** once the **first match is underway** (you can see the board and
the bot is making moves), press **F6 once**.

**What you should see:**

```
F6 graceful stop accepted: finishing the current match, then stopping at the
boss lobby.  No new match will be entered.
```

Then the bot plays that match to the end, confirms the postmatch dialog,
returns to the boss lobby, and stops.

**PASS looks like:**

```
Phase 2D.6 B1 PASS (PHASE2D6_GRACEFUL_STOP_PROVEN); reason=STOPPED_GRACEFULLY; completed=1/3
```

Note `completed=1/3` — stopping *short of the target* is the whole point.  If it
reached 3/3 the stop proved nothing.

## 6. Stage B2 — prove checkpoint and resume

**Goal:** a run split across two separate invocations reaches the target
cumulatively, with correct accounting and no stale gameplay state carried over.

### Run A — complete exactly 2 matches, then stop

```powershell
python tools\farm_run.py `
  --stage-d6-b2-resume `
  --new-run `
  --boss-id 1289 `
  --target-matches 5 `
  --max-technical-recoveries 1 `
  --max-match-attempts 8 `
  --reset-evidence logs\phase2c2c_reset_capabilities.json
```

**What you do:** let the first match finish.  During the **second match**, press
**F6 once**.  The run drains that match and stops with 2 completed.

Expect:

```
Phase 2D.6 B2 PASS (PHASE2D6_CHECKPOINT_RUN_A_STOPPED); reason=STOPPED_GRACEFULLY; completed=2/5
To continue this run later:
  --resume D:\PokiguardToolV2\logs\farm_runs\<run-id>\checkpoint.json
```

**Copy that checkpoint path.**

### Run B — resume and finish the remaining 3

Return the game to the boss lobby first.  Then, with **identical** target and
limits (a mismatch is rejected on purpose):

```powershell
python tools\farm_run.py `
  --stage-d6-b2-resume `
  --resume D:\PokiguardToolV2\logs\farm_runs\<run-id>\checkpoint.json `
  --boss-id 1289 `
  --target-matches 5 `
  --max-technical-recoveries 1 `
  --max-match-attempts 8 `
  --reset-evidence logs\phase2c2c_reset_capabilities.json
```

Let it run to completion untouched.  It needs only **3 more** matches, because
the 2 from Run A are carried forward as history.

**PASS looks like:**

```
Phase 2D.6 B2 PASS (PHASE2D6_CHECKPOINT_RESUME_PROVEN); reason=FARM_TARGET_COMPLETED; completed=5/5
```

### What resume deliberately does NOT restore

The checkpoint stores **history only** — counters, match IDs, aggregates.  It
never stores or restores board instance, pending action, server sequence, board
hash, idle state, desync stickiness, or any UI pointer.  Resume attaches fresh,
re-reads the world, and refuses to start unless the game is at a clean boss
lobby.

### Resume refusals (all fail closed, zero input)

| Situation | Reason |
|-----------|--------|
| Target/limits differ from the checkpoint | `CHECKPOINT_CONFIG_MISMATCH` |
| Run already hit its target | `CHECKPOINT_ALREADY_COMPLETED` |
| Run was stopped with F9 | `CHECKPOINT_NOT_RESUMABLE` |
| Checkpoint was not finalized by a clean F6 stop at boss lobby | `CHECKPOINT_NOT_RESUMABLE` |
| File corrupt or truncated | `CHECKPOINT_INVALID` |
| Written by a newer tool version | `CHECKPOINT_SCHEMA_UNSUPPORTED` |
| Game is not at a clean boss lobby | `RESUME_START_STATE_UNSAFE` |

A corrupt checkpoint is **never** auto-discarded — the tool stops and tells you.

## 7. Stage B3 — long bounded soak

**Goal:** 25 matches back to back, proving no session/input/state leakage over
time.  This takes a while; plan for it.

```powershell
python tools\farm_run.py `
  --stage-d6-b3-soak `
  --new-run `
  --boss-id 1289 `
  --target-matches 25 `
  --max-technical-recoveries 3 `
  --max-match-attempts 32 `
  --reset-evidence logs\phase2c2c_reset_capabilities.json
```

Leave it alone.  If you must stop early, press **F6** — it stops cleanly at the
next lobby and the run stays resumable.

**PASS looks like:**

```
Phase 2D.6 B3 PASS (PHASE2D6_LONG_SOAK_PROVEN); reason=FARM_TARGET_COMPLETED; completed=25/25
Controller working set: start=… KiB, peak=… KiB, end=… KiB (no observed
unbounded growth during this bounded soak).
```

That memory wording is deliberately modest.  A 25-match run cannot prove the
absence of a leak; it can only show none was observed within these bounds.

Accepted B3 run `6f8d890137604098b6ff4a066a20d4ec` completed on
2026-08-22 with `25/25` normally completed matches and final invariant
`PHASE2D6_LONG_SOAK_PROVEN`. Its working-set sampler reported
`{"available": false}` because the original ctypes call did not declare the
x64 `HANDLE` return type of `GetCurrentProcess`; that truncated the pseudo
handle before `GetProcessMemoryInfo`. The sampler now declares the complete
x64 ABI and uses `kernel32.K32GetProcessMemoryInfo`, with a Windows regression
test and a successful live one-shot sample. The completed run cannot be
retroactively assigned start/peak/end values, so the accepted report records
those three measurements as unavailable rather than inventing them. Future
soaks will emit the intended fields.

## 8. Artifacts

Each run writes to `logs/farm_runs/<farm_run_id>/`:

| File | Contents |
|------|----------|
| `run.json` | Final snapshot, acceptance verdict, invariant, memory report |
| `events.jsonl` | Append-only event stream |
| `checkpoint.json` | Durable history for resume (2D.6 stages only) |
| `matches/attempt_NNN/` | Per-match logs |
| `recoveries/` | Recovery transcripts |

Useful `run.json` fields for verifying a graceful stop:

- `gracefulStop.observed` — was F6 actually pressed
- `gracefulStop.bossEntryInputsAfterRequest` — **must be 0**; this is the
  `GRACEFUL_STOP_NO_NEW_ENTRY_PROVEN` evidence
- `gracefulStop.emergencyStopUsed` — must be `false` in B1
- `checkpoint.continuationOf` — the prior run ID when resuming
- `controllerMemory` — start/peak/end working set

## 9. Troubleshooting

**"CONTROLLER_CONFLICT"** — another automation process holds the lease.  Close
it, or delete `logs/.automation_controller.lock` if nothing is actually running.

**Run stops immediately with `FARM_START_STATE_INVALID`** — the game was not at
a clean boss lobby.  Return to the lobby and restart.

**F6 seems to do nothing** — the press is latched and handled at the next farm
boundary, which can be a few seconds into a long combat turn.  Wait for the
confirmation line rather than pressing repeatedly.  Extra presses are ignored,
not queued.

**Resume refuses with `CHECKPOINT_CONFIG_MISMATCH`** — the target boss or the
three limit values differ from Run A.  They must match exactly.

**An action response is late** — the bot may retry *observation* once if the
same local turn still has safe time. It never repeats the uncertain click. If
the response remains unavailable, the log records
`ACTION_OUTCOME_UNCONFIRMED`; the rest of that source turn has zero further
input and only game/server-owned AFK evidence may classify the skipped turn.
This is not counted as a reject and does not stop the whole farm by itself.
For an unconfirmed non-consuming EVOLVE that reaches the action floor, B5 may
enter `unconfirmed_evolve_zero_input_wait_started` only when the same current
combat board is still proven and authoritative idle readiness says one AFK
outcome is safe (for example, after a confirmed consuming reset). It never
clicks EVOLVE again. If the game received EVOLVE, the turn may finish without
an AFK payload; if it did not, the exact server AFK payload updates the idle
cache. No local counter guesses which case occurred. First turn, idle-2
mandatory action, stale board/session, desync and ambiguous lifecycle remain
fail-closed.

**The server timer reaches exactly 4 seconds during the fresh reread** — the
configured 4-second action floor is inclusive. The game exposes an integer
timer and a memory reread can legitimately move it from 6 to 4; treating 4 as
expired silently changed the requested floor into an effective 5-second
guard. Policy selection, the fresh pre-input check, and the missing-action
deadline now all allow exactly 4 seconds and fail closed only below 4. The
uncertain-action rule is unchanged: clicks are never repeated merely because
the response is slow.

**EVOLVE is proposed after a laggy board publication** — EVOLVE is
non-consuming, but its response/animation and a fresh-state reread must still
leave time for the same-turn SWAP. Live B3 run
`22d5790afc294a029cb9884074902752` published local turn 17 only at 8 seconds;
the failed Fusion response was not resolved until 4 seconds and the next board
poll reached 1 second. The policy now uses a separate inclusive 10-second
EVOLVE floor. At 10--14 seconds it keeps normal Step 1 priority; below 10 it
records an explicit defer reason and continues through Sword/resource policy
so the turn can still consume a board action. The general action floor remains
4 seconds.

**Low-boss-HP policy** — default threshold is 30000 current HP and can be set
with `--cast-when-boss-hp-below`. At or below it, the bot skips EVOLVE; after
Sword it uses an affordable proven Attack card, otherwise it prioritizes safe
Mana. Use `0` only when deliberately disabling this mode.

**`cardCount=0` even though a card is equipped** — each entry now records a
`preentry_card_loadout` event before clicking `Bắt đầu`. Compare
`preentryCardCount/preentryAttackCardCount` with the later live CardUI count.
The former comes only from live `ManagerRoom.selectedCards`; stale
`RoomDTO.cards` is retained as separate diagnostic evidence and is never
promoted into the executable loadout. The later CardUI count is intentionally
stricter because every object must belong to the new combat's current `Board`
and `Active`. A nonzero pre-entry Attack count followed by zero live Attack
cards is a CardUI-discovery gap, not an empty loadout.
`preentry_card_loadout_refreshed` is informational: lobby sync changed the
expected list between READY and preflight, so the latest value was recorded;
it does not weaken or veto the independent target/Button entry gate.
If pre-entry Attack is nonzero but live CardUI remains zero, check whether the
first session scan was full. Current code resets this cadence at every new
combat because Unity may allocate live CardUI into a new small region even when
old learned regions remain readable.

**`ENTRY_TIMEOUT_OPENING_BOARD` after many completed matches** — this is a
fail-closed entry stop, not permission to attach to a later turn. In B3 run
`154854d4f41548409b6212f6e7dd15e9`, attempt 16 clicked `Bắt đầu` exactly once
and created session `M_6ef683f5`, but the usable `MATCH_START` object was missed.
By the time a stable board was published, the server had advanced to local
turns 3 and 5 with `localMoveSequence=0`; the strict first-turn entry gate
correctly refused both.

The diagnosed long-run cause was cross-session accumulation of raw learned
batch/CardUI/FusionUI regions (202 batch regions by attempt 16), combined with
an unnecessary extended CardUI scan before the short-lived opening transport
object was captured. The provider now:

1. yields the pristine first-turn window to the external `MATCH_START` scanner
   before broad UI/ACK scans;
2. drops session-owned batch/CardUI/FusionUI region hints at every lifecycle
   boundary and retains only regions containing current ownership-validated
   objects; and
3. skips the 8--16 MiB CardUI fallback when the normal scan already found a
current, validated Attack card.

**EVOLVE/CAST is logged as sent but mana does not decrease** — a valid Fusion
attempt, whether it succeeds or fails, consumes the configured 160 mana and
produces `MATCH_FUSION_RES`; a later durable Fusion transition distinguishes
success. Run `0af0065ec1e148eb8f7c43abf6e03d2f` exposed a UI-layout bug: the
V1 anchor `(0.417, 0.836)` was calibrated for Fusion plus three selected cards,
but the Phase 2D.6 loadout had only one selected Attack card. Unity centred the
two-tile strip, moving Fusion to approximately `(0.471, 0.836)`, so all ten
Windows clicks landed left of the card and mana stayed unchanged. Gameplay UI
location no longer assumes a fixed loadout or fixed card-type slot. Cpp2IL
proves that `Board.DisplayCardsOnBoard` creates `Board.selectedCards` in list
order, then appends Fusion, then the optional pet-specific skill card. The
standard-pet UI was then verified live: Fusion is the leftmost slot and each
ordinary card retains its `selectedCards` index after Fusion. The provider
checks that ordered list against the actual `Board.cardsInHand` count and maps
each live `CardUI.cardData` pointer to its own visual slot. Pet-specific skill
layout support is deferred; its presence, ambiguous pointers, duplicate
entries, or count disagreement leave all card slots unresolved and disable
card input only. Board solving remains active. A visual proof failure for an
optional EVOLVE/CAST is scoped to that source turn and the unchanged policy is
immediately re-evaluated in board-only mode instead of pausing the combat.
`action_sent.locator.metrics.slotIndex/slotCount` and provider
`runtimeCardLayout*` diagnostics make the chosen layout auditable.
A future timeout with zero mana delta and no Fusion response remains
unconfirmed; it must never be counted as a random Fusion failure or retried
blindly in the same source turn.

Ordinary Attack cards and the evolution pet are optional. Pre-entry reads
`ManagerRoom.selectedCards`; zero selected Attack cards is logged as
`BOARD_ONLY_NO_ATTACK_CARD` and no longer blocks entry. In combat, at least one
Fusion selected-pet ID must be positive to authorize EVOLVE; when both are
absent/zero the loadout has no evolution pet. If the operator did not equip
Attack, did not select
an evolution pet, or the runtime slot cannot be proven, policy skips that card
action and continues normal Sword/resource/board play. A pet-specific skill
card is still detected from live state, but its click layout and use are
deferred to a later phase as agreed with the operator.

Do not resume a stopped B3 checkpoint after this condition. Start the next B3
acceptance run only from a confirmed boss lobby so the fixed provider begins
with a fresh process attachment and a clean session boundary.

**Opening turn reaches the policy with only 3--5 seconds left** — optional
CardUI/FusionUI discovery must not consume the mandatory first-turn window.
Live B3 run `ca9e8b0092504a9ba4b70ba7e906e4ed`, attempt 2, captured the opening
board with 5 seconds remaining after two extended FusionUI scans had read
504,276,470 bytes and the card-owner anchor path had read another 31,232,000
bytes. Policy selected a valid Sword swap, but the fresh reread reached 3
seconds and correctly rejected input at the 4-second safety floor.

On an authoritative local turn 0/1 with `localMoveSequence=0` and no prior
move, the provider now suppresses all uncached optional UI discovery: the
session-first full CardUI/FusionUI scan, the extended region fallbacks and the
card-owner anchor scan. Cached validated candidates may still be used. The
authoritative board is published first so the mandatory normal swap can be
sent; uncached card discovery resumes on the existing later-poll cadence after
the opening action. This changes scan scheduling only, not policy priority,
card validation or the 4-second action guard.

The first live verification after this change was B3 run
`59913cccaa5341d89374c15efe6439b9`, attempt 1. Opening board publication
reached policy with 8 seconds remaining, the Sword SWAP was sent about 0.9
seconds later, and all opening extended/anchor scan counters were zero. Live
card discovery resumed on turn 3. The same combat also proved both a failed
EVOLVE and a successful EVOLVE were followed by a same-turn SWAP. Two laggy
SWAP outcomes remained unconfirmed and the terminal result was retained as
UNKNOWN; that run is therefore evidence for action-flow behavior, not a B3
strong PASS.

That UNKNOWN combat returned to the Chinh Phuc map and exposed a separate
orchestration defect before target selection: `_return_from_chinh_phuc_map`
referenced `ClickStatus.SENT` without importing `ClickStatus`. The resulting
`NameError` is fixed by importing the existing enum from `win32_input`; no
input had been sent by the failing map-return path. Do not reinterpret this
deterministic code exception as server lag, and do not reinterpret the
terminal UNKNOWN as WIN/LOSS without authoritative evidence.

**`LOCAL_TURN_ACTION_DEADLINE` after a reconnect/runtime reset** — a normal
deadline remains a fail-closed stop. A narrowly evidenced reconnect signature
is now recoverable: this exact combat must already have server-ACKed a
consuming action, the late local-turn `MatchService` action sequence must have
regressed to `localMoveSequence=0` and `lastMoveSequence=null`, the provider
must simultaneously report `no_current_ack_attested_complete_batch` or
`stale_sequence`. It may instead be on the immediately following
`awaiting_stability_confirmation` poll only when the last actionability gate
from that same unresolved interval explicitly reported `DISCONNECTED` or
`RECONNECTING`. A prior accepted sequence/hash must still exist. In that case
the run records `ACTIONABILITY_STATE_LOST` as a technical abort and uses one
bounded recovery slot to exit, re-enter, and require a new first-turn opening.
It never retries the uncertain gameplay click and never treats a normal
first-turn `0/null` sequence as failure. If any evidence is missing, the
original `LOCAL_TURN_ACTION_DEADLINE` safe-stop is preserved.

Live B3 run `4834183a698742ce8bf754ba3a1c0dae`, attempt 4, exposed the one-poll
race this qualification addresses. The controller first observed explicit
`DISCONNECTED`, then `RECONNECTING`, then
`no_current_ack_attested_complete_batch`; at the 2-second deadline the current
provider poll had advanced to `awaiting_stability_confirmation`. Runtime had
regressed to `localMoveSequence=0/lastMoveSequence=null` after 17 acknowledged
SWAPs, while durable DTO evidence still held `srvSeq=74`. This is a technical
reconnect/reset signature, not a slow BASIC policy decision and not permission
to guess or resend a gameplay action.

**A recovered MATCH_START is initially clean, then the prior ACK watermark
reappears before the first gameplay input** — live B3 continuation
`6a2bf612e0fe41678c884e55cb4e638e` completed six strong WINs, then naturally
hit `DEAD_BOARD_NO_REFRESH`. Recovery exited and re-entered a fresh MatchId,
Board and lifecycle epoch. Entry accepted a complete first-turn MATCH_START at
`srvSeq=3` while `MatchService._ackedSeqs` was empty. About 2.4 seconds after
handoff, however, the old match's `highestAckedSequence=27` reappeared. The
fresh pre-input reread correctly returned no executable state; zero Windows
gameplay inputs were sent and the controller stopped at the deadline. This is
an ACK-epoch leak inside the live client/recovery transition, not game lag and
not permission to treat sequence 27 as belonging to the new MatchId.

The first mitigation kept gameplay locked for a 2.5-second quarantine after
the accepted opening. It required at least two pristine first-turn state
samples, the exact new session, `localMoveSequence=0`, no last move, an empty
ACK set throughout the guard, and more than the normal four-second action
floor remaining. Live B3 run `63041dc113084d1fbf66f5219497bc70`
proved that this post-entry time window alone is insufficient. After two
strong WINs, attempt 3 naturally hit `DEAD_BOARD_NO_REFRESH`; recovery entered
attempt 4 with a complete new opening and 17 clean guard samples, but the old
watermark appeared later as `highestAckedSequence=19`. The first proposed
Rage SWAP failed its mandatory fresh reread, zero gameplay inputs were sent in
the recovered combat, and the controller stopped at
`LOCAL_TURN_ACTION_DEADLINE`.

Read-only inspection after that stop showed the decisive earlier boundary:
while `CurrentMatchId=null` at the boss lobby, the same MatchService still held
`highestAckedSequence=19`. The value also survived normal foreground
navigation from the boss room to the Chinh Phuc pet map, the region map and
the game home screen. This is persistent client state, not scan latency.
Technical recovery therefore reads MatchService at the exact boss-lobby
boundary *before* reserving RECOVERY_REENTRY. A non-null MatchId records
`RECOVERY_LOBBY_MATCH_NOT_CLEARED`; an unreadable epoch records
`RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE`; an advancing ACK/local-move watermark
records `RECOVERY_ACK_EPOCH_NOT_RESET`. Those cases fail closed with zero
re-entry inputs.

Exact-25 Phase 2E.3 run `33f02803c0b2464cb3a0da22b05eff09`
provided the missing distinction. After six strong WINs, attempt 7 hit an
exact `DEAD_BOARD_NO_REFRESH`; recovery exited normally and proved the exact
owner-free Starburst boss lobby for 120 samples over 15 seconds. Throughout
that interval `CurrentMatchId=null`, the provider session was null and the
same MatchService retained the *unchanged* pair
`highestAckedSequence=29/localMoveSequence=6`. Ordinary successful entries in
the same run also began from stale lobby ACK telemetry and obtained a clean
epoch only while the new MATCH_START session was bound. The pre-entry guard
now permits this one deferred-reset case after at least eight identical
samples spanning two seconds, including an unchanged MatchService address,
ACK and local sequence. The exact lobby is re-proved before the click. The
2.5-second post-opening guard remains mandatory. Build `v1.0.0+11`
supersedes the earlier assumption that every non-null raw ACK must block: run
`4ab9bda9429144f991dd8bdcd6e83956` proved that the frozen value can survive
the distinct pristine MATCH_START itself. Only an explicitly armed frozen
lobby residue may be isolated, and then only exact current-session
ChatMessageDTO/BoardWs evidence is eligible; the raw ACK remains audit
telemetry. A reused/changed session, non-pristine action state, unsafe timer or
unexplained ACK advance still fails closed. The tool never clears, repairs or
writes the game's ACK set.

**`PASS_STATE_UNCONFIRMED` during reconnect** — PASS_WAIT still requires the
game-owned AFK payload and never increments idle locally. The transport monitor
now performs one full ChatMessageDTO discovery scan at the start of a PASS,
then uses fast learned-region scans with its existing periodic full rescan;
forcing every poll to traverse the full heap previously consumed about 1.9 s
per sample and could miss the short-lived AFK DTO. If the payload is still
missing, recovery is allowed only when the next local turn is observed with
zero gameplay inputs during PASS_WAIT and previously nonzero MatchService
action telemetry has regressed to `localMoveSequence=0`,
`lastMoveSequence=null`, `highestAckedSequence=null`. That exact reconnect
signature records `ACTIONABILITY_STATE_LOST` and consumes one bounded recovery
slot. Without all of those fields, `PASS_STATE_UNCONFIRMED` remains a safe-stop.

**`RETURN_LOBBY_TIMEOUT` with `WORLD_BOSS_LIST` after a normal WIN** — a
Chinh Phuc result can return to the island map instead of reopening the
selected `ManagerRoom`. Stale `ManagerBoss` data makes that map look like the
unrelated world-boss list to the original lobby classifier, so target 1289 is
correctly absent and the old run stopped. Phase 2D.6 now has one narrow return
path: it read-only resolves the configured pet ID through the map Button's
UnityEvent closure, checks the same pet exactly once in
`ManagerChinhPhuc.cachedPetData`, verifies `SelectedPetId`,
`SelectedGroupIndex` and `ActivePanelIndex` from read-only PlayerPrefs, then
requires two stable frames containing exactly one badge for the runtime-derived
hunt order. Only then may it send one normal foreground target-selection click
and wait for the exact room again. The pixels identify the displayed order,
never the pet. Missing, duplicate, locked, non-interactable, unstable or
unsupported evidence fails closed. The attempt artifact includes
`chinh_phuc_map_before.png` plus `chinh_phuc_map_return*` events.

A LOSS can expose a different transient with the same initial classifier:
`WsRoomService.CurrentRoomId/CurrentRoomType` still names the Chinh Phuc room,
but `ManagerRoom.roomData` is temporarily null while Unity rebuilds the room.
Live run `e37f0b3191a147c4843796946aca7b0c`, attempt 2, returned exactly this
shape (`Coop_578601`, `ChinhPhuc`, null `roomData`) and then hydrated into the
correct Starburst lobby without a target-selection action. Phase 2D.6 now
waits up to 45 seconds inside the existing 90-second return budget for this
exact rehydration signature. It does not run the island-map click path while a
room ID is still owned, and all other target-missing shapes keep their existing
fail-closed behavior.

**`TURN_TRANSITION_NOT_PROVEN` during severe client lag** — a one-step local
turn advance with the local actor is still treated as the known non-atomic
`TurnNumber`/`CurrentTurnPlayer` race and fails closed on expiry. A same-session
authoritative advance from local turn N directly to local turn N+2 is now
accepted as a missed *observation* of the intervening boss turn in this
two-participant boss match. It is logged as
`LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE`. This never retries an input:
the original SWAP/CAST must still receive its normal terminal result, and a
complete fresh Board publication is still mandatory before the next policy
decision. Odd jumps, unchanged turns, actor ambiguity, session changes and
missing fields remain unproven and stop safely.

## 10. Accepted Phase 2D.6 evidence

The canonical accepted live artifacts are:

| Stage | Run | Result |
|---|---|---|
| B1 | `dded65a91c9d4955b9614a1b61f40904` | One STRONG/consistent WIN, F6 during `ACTIVE_COMBAT`, exact lobby stop, zero entry after request; `PHASE2D6_GRACEFUL_STOP_PROVEN`. |
| B2 Run A | `dc1d191f369449deb422f1b3c7cc209b` | Two STRONG/consistent WINs, then clean F6 stop at lobby with resumable checkpoint. |
| B2 resume | `7afb954b302a4bdab59ff488bb56317f` | Explicit continuation of Run A, cumulative 5/5 STRONG results, one natural dead-board recovery, no duplicate accounting; `PHASE2D6_CHECKPOINT_RESUME_PROVEN`. |
| B3 | `6f8d890137604098b6ff4a066a20d4ec` | Exactly 25 attempts/completions: 24 WIN, 1 LOSS, 0 UNKNOWN, 0 recoveries, no attempt 26, exact boss lobby; `PHASE2D6_LONG_SOAK_PROVEN`. |

B3 ran for 7,058.980 seconds. It recorded 410 SWAP sends (397 ACK, 12
state-changed aborts, 0 rejects), 53 CAST sends (41 accepted, 0 rejected), 42
EVOLVE attempts (20 successes, 22 failures), and 53 PASS decisions with zero
Windows input. All duplicate, wrong-target, wrong-turn, opponent-turn, stale,
lobby/postmatch gameplay, result-conflict and input-after-stop counters were
zero. The artifact measured 258,551,940 bytes before final `run.json`
serialization (approximately 246.57 MiB); the current directory size including
final output is 259,137,424 bytes.

Automation is stopped after acceptance. Do not start another stage or a future
phase without explicit operator approval.
