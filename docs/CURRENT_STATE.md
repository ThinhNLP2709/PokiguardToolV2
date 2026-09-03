# PokiguardToolV2 Current State

Canonical technical handoff as of **2026-09-03 (Asia/Saigon)**.

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
| Current completed phase | **Phase 3A.0 — PASS STRONG / SOURCE MAINTENANCE BASELINE** |
| Active phase | **NONE** |
| Current controller status | **STOPPED** |
| Current live automation | **NONE** |

Phase 2F.2 Release Candidate `v1.0.0+15` passed clean staging and packaged-live
acceptance B1-B6 against one unchanged binary. The accepted RC archive is
`PokiguardToolV2-v1.0.0+15-win-x64.zip`, size `13,609,921` bytes, SHA-256
`e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69`,
built from commit `1dd53340e20ca405c0bf446682b3fcbf823afe62` with PyInstaller
6.22.0 and CPython 3.11.9 x64.

B2 FarmRun `e113cf4a037949f68bcebc1d086a311d` completed exactly 10/10
STRONG/CONSISTENT WINs in 12 attempts; two technical aborts recovered and did
not count as combat results. B3 graceful-stop run
`f7936c6c94f24c30b693065062202cfb` completed the in-flight WIN and created no
next attempt. B4 resumed checkpoint `6f604d50505d4148abb32e3d457bf614`
through continuation `8876e53d4a6948388de421e5a9bd9382` to exactly 5/5 WINs
with five unique MatchIds. B5 emergency run
`e2c6919c29d4482a8d2f4cc3c9d37585` acknowledged the command during
`ACTIVE_COMBAT` and emitted zero gameplay, entry, recovery or postmatch input
after acknowledgement. B6 closed cleanly with one stopped controller/poller,
zero UI errors, and the game process still alive.

Focused release tests are **14/14 PASS** and full regression is **740/740
PASS**. Game-installation, source-runtime and packaged-directory write audits
are all zero; game binaries and the RC archive remained byte-identical.

The pre-existing untracked
`docs/pokiguard_pet_skill_qte_reverse_report.md` was verified as a valid
project reverse report and, after explicit user authorization to finalize, was
preserved byte-for-byte in the separate documentation commit `c2f4242e`. It
was not mixed into the RC artifact or production runtime graph. Git hygiene is
therefore resolved and the annotated release tag is `v1.0.0+15`. Canonical evidence:
[Phase 2F.2 report](phase2f2_report.md), [runbook](phase2f2_runbook.md), and
[release manifest](../release/phase2f2_manifest.json).

Phase 3A.0 freezes the newer repository-truth source baseline as `v1.0.23`.
The original `v1.0.1` maintenance boundary was carried forward through the
Pokiguard 1.7.4 compatibility repairs; the accepted packaged RC remains
`v1.0.0+15` and was not rebuilt or retagged. FarmRun
`8f7be1b715644b008431060baab72eef` completed exactly 5/5
STRONG/CONSISTENT WINs in five attempts and returned to `BOSS_LOBBY` with the
controller stopped. It observed five EVOLVE clicks (three success, two
failure) and eight CAST clicks on the shared normalized Y `0.824` boundary;
seven CASTs have direct mana-plus-turn acceptance proof and the final CAST
ended combat before a nonterminal acknowledgement could be recorded. All
card/input safety counters are zero.

Every one of the five result confirmations followed authoritative POSTMATCH,
stable modal evidence and final preflight, was clicked exactly once, and
returned to the exact boss lobby. Terminal-result-to-confirm latency was
2.384--2.456 seconds (average 2.403 seconds), demonstrating removal of the old
fixed five-second delay without weakening the modal boundary. Across 74 live
SWAP decisions there were zero ordinary safe labels with a known direct or
indirect opponent Sword reply and zero UNKNOWN-as-favorable decisions. The
rare unique-adverse-Sword and Sword-hold live branches were `NOT_OBSERVED` and
remain covered by deterministic tests. Per-match local turns/energy were
19, 23, 17, 17 and 23 (total 99, average 19.8). Canonical evidence is in the
[Phase 3A.0 report](phase3a0_report.md) and
[runbook](phase3a0_runbook.md).

Post-release source maintenance `v1.0.1` originally added three operator-requested
refinements. Combat card visual validation remains centred at normalized Y
`0.836`, but the actual EVOLVE/CAST click is raised to Y `0.824` (about 8.5
pixels at the canonical 710-pixel client height). The combat worker's redundant
postmatch lobby wait is reduced from 5 seconds to 1 second. Result confirmation
still requires authoritative POSTMATCH, three stable high-confidence modal
frames, and a fresh POSTMATCH/foreground preflight immediately before its
single click; the visual frames no longer repeat the heavy memory-provider
poll. Finally, BASIC Sword safety now audits every legal boss reply on the
settled known board, including a non-Sword direct match whose deterministic
cascade collects Sword. The unique-adverse-Sword exception can defer the only
Sword move and use authoritative PASS or a separately proven Sword-hold; the
hold is never labelled safe and UNKNOWN earns no favorable credit. Offline
verification at that historical checkpoint was **745/745 PASS**. Its live
validation boundary is superseded by the accepted Phase 3A.0 `v1.0.23` run
above.

Source compatibility update `v1.0.3` removes the runtime dependency on the
retired fixed launcher name `Pokiguard.exe`. The new **Settings** tab persists
the exact full path of one operator-selected `Pokiguard-<version>.exe` beside
`GameAssembly.dll`, and applies that path to both the read-only desktop observer
and FarmRunner attach path. When an update changes the launcher filename, the
operator selects the new EXE with **File...**. Process
matching requires both executable name and full module path, so another game
copy with the same filename is not accepted. The setting is locked while a
controller owns an active run and changing it drops only the cached read-only
handle; no game file is written or modified.
The full source regression suite is **759/759 PASS** and the source UI smoke
resolves `D:\pc\Pokiguard-1.7.4.exe` with zero render errors.

Source compatibility update `v1.0.4` adds verified metadata-110 symbols and
field layouts for the current Pokiguard 1.7.4 `GameAssembly.dll`. The desktop
observer distinguishes an exact detected process from an incompatible memory
layout instead of reporting both as a missing game. Unknown future binary
hashes fail closed before a memory provider is constructed. A read-only live
probe resolves the new type-info slots and constructs the provider; boss-room,
combat and autonomous behavior still require live validation on 1.7.4. See
[pokiguard_1.7.4_compatibility.md](pokiguard_1.7.4_compatibility.md).

Source compatibility update `v1.0.5` cross-checks the split
`reverse/redux_compat` output against the existing 1.7.4 layout. The executable,
GameAssembly and metadata hashes are unchanged, and the boss-room field offsets
match. The desktop observer now evaluates the exact ChinhPhuc room graph even
when uninitialized combat static classes leave the base lifecycle `UNKNOWN`.
Promotion to `BOSS_LOBBY` remains fail-closed: the room graph must be completely
clean and there must be no positive combat/transition signal or read error.

Source compatibility update `v1.0.6` corrects the Unity 6000.7.0a4
`Il2CppClass.static_fields` offset from the previous runtime's `+0xB8` to the
live-verified `+0x98`. A bounded read of the exact `ManagerQuangTruong`,
`ManagerRoom`, and `WsRoomService` class headers showed valid static blocks and
matching class-owned singleton instances at `+0x98`, while `+0xB8` was null for
all three. A live read-only probe then resolved `BOSS_LOBBY`, target `1289 /
Starburst`, and room `Coop_788342`. Full regression remains **759/759 PASS**.

Source compatibility update `v1.0.7` fixes the first 1.7.4 Start failure. Run
`3c530ea44f2a442888181f588b83af8a` stopped with
`ATTACK_CARD_TOGGLE_UNPROVEN` before sending any input: memory proved the
Attack card selected, but the 1280x720 artifact contained a centered
1280x640 game viewport and the old fixed ROI was 64 pixels to the right of the
live card. Desktop Start now prepares the native 1280x640 client. The first
compatibility implementation reused that height-scaled, left-anchored UI
canvas for every control; later combat evidence showed that Board `DotsArea`
uses a separate full-width layout (see `v1.0.9` below). The saved pre-fix frame proves Attack at 0.970
confidence and Start at 0.907 without input. Compileall and the full source
suite pass **765/765**.

Source compatibility update `v1.0.8` fixes the next live boundary. Entry run
`e1b6c5bd0ef04f3ca5e6cf23c397601e` successfully clicked Start and observed
match `M_b727b2f1`, MatchHost `RUNNING`, a live rig, complete 64-cell snapshots,
a ready Board and consistent Board/Active/ManagerMatch ownership. The updated
game nevertheless kept the verified `HubSuspendManager.IsSuspended@static+0x08`
and `ManagerMatch.isBossBattle@+0x138` fields false. The former old polarity
gate held lifecycle at UNKNOWN and caused `ENTRY_TIMEOUT_NEW_SESSION` with zero
gameplay inputs. Hub state is now required to be readable but either polarity
is valid; all stronger local-rig, scene, ownership, match, Board-ready and
non-terminal gates remain mandatory. Full regression passes **766/766**.

Source compatibility update `v1.0.9` fixes the first live combat-input failure
on 1.7.4. Run `d103ea509fb740b188df524283e61224` read a complete authoritative
opening board and correctly selected `(screen row 0, col 7) <-> (row 1, col 7)`,
which produces a three-Shield match across top-row columns 5..7. The emitted
plan nevertheless used client `x=732`; the saved 1280x640 opening frame places
column 7 near `x=815`, so the click landed around column 5 and appeared as a
non-match. This disproves applying the left-anchored card/UI canvas transform
to the Board: the combat `DotsArea` separately preserves the complete client
width. Board input now leaves normalized x coordinates unchanged and maps the
same move to client `x=823`; card, lobby, recovery and postmatch controls keep
their evidenced height-scaled, left-anchored UI transform.
Regression coverage locks this evidence and the full suite passes **767/767**.
One live retry remains required before declaring 1.7.4 gameplay accepted.

Source compatibility update `v1.0.10` completes the Board calibration after
FarmRun `2c55da2623874fda9f95b3eea0e6b742`. That retry was launched by the
already-running pre-fix Python process, so it still emitted selected move
`(row 6,col 5)<->(row 7,col 5)` at client `(638,371)<->(638,417)`. The saved
opening frame proves the actual centres near `(714,406)<->(714,456)` and exact
grid boundaries `x=438..840`, `y=79..481`. The input therefore missed both
intended cells; no server response or durable local move sequence followed,
and the eventual boss turn does not prove acceptance. There is no clean
evidence that the normal 0.25-second click gap was too short, so pacing is not
changed speculatively. Production Board calibration is now
`first=(.3620,.1625)`, `step=(.0393,.0787)`: the same lower-board move maps to
`(714,405)<->(714,455)`, and the earlier rightmost-column move maps to `x=814`.
Card/lobby/modal calibration remains unchanged. Full regression passes
**768/768**; a genuinely restarted `v1.0.10` live retry is pending.

Source compatibility update `v1.0.11` analyzes that clean retry, FarmRun
`8a57d4f5b6ec4a37bd45504e841574a0`. The opening memory board and saved frame
agree exactly: `(row 2,col 0)<->(row 2,col 1)` moves the visible Sword left to
make the three-Sword column, and emitted client points
`(462,204)<->(513,204)` are the centres of those two tiles. Nevertheless no
durable local move sequence or attributable server acknowledgement followed;
`MATCH_AFK_WARN idle_count=1` proves the game counted the turn as idle. This
rules out solver legality and board calibration for this failure. The normal
input path now lets Unity sample each cursor position for 60 ms, holds each
mouse-down for 75 ms, and separates the two taps by 350 ms. The complete pair
still finishes in well under one second, retains all foreground/window/PID
revalidation, and logs every timing used. A new-process live retry is required.

Source compatibility update `v1.0.12` analyzes the clean restarted retry,
FarmRun `4966336390a74090807f5d28c942a6b1`. The first move and ten further
SWAPs produced durable attributable acknowledgements; the match ended as a
STRONG/CONSISTENT WIN with boss HP zero. The controller then safe-stopped with
`POSTMATCH_UI_AMBIGUOUS` and sent no postmatch input. Its final frame proves
that current 1.7.4 uses a wide orange result banner and one centered blue
`Dong y` control rather than the legacy large-blue-panel/orange-button layout.

The new locator grants a point only when both current-layout anchors are unique
and present together; the legacy locator remains available. FarmRunner still
independently requires authoritative `POSTMATCH`, three stable samples, a final
provider poll, and foreground/focus proof before ordinary input. Exact replay
finds normalized point `(0.5, 0.90078125)` with zero three-frame drift. Offline
verification is **770/770 PASS** with compileall and diff checks clean. A newly
started `v1.0.12` process is required for live confirmation.

Source compatibility update `v1.0.13` analyzes the five-win completion run
`76fc70afe4fe42d4880d0421099942b6`. That run closes the current postmatch
boundary: all five result overlays were confirmed and the farm reached its
exact target. It also exposes one independent combat-card coordinate defect.
Memory correctly proved Attack card ID `4`, cost `160`, slot `1/2`, interactable
and affordable; policy emitted nine CAST actions, including low-boss-HP
`STEP_3_FINISH_CAST` at boss HP `14163` and `22350`. None was accepted.

The logged Attack point was normalized `x=0.470222`, which is the visible
Fusion card centre in the saved 1280x640 opening frame. The Attack card is at
the full-viewport slot-1 centre `x=0.529`. Mana repeatedly fell by exactly 160,
and the final wrong-card activation increased max HP `83371 -> 105214` and max
Mana `1579 -> 1757`, proving that CAST input had activated Fusion instead.
The slot calculation was correct; applying the separate left-anchored 16:9
lobby transform a second time moved slot 1 onto slot 0.

Combat-card visual validation and click points now use the complete active
viewport in both native and letterboxed 2:1 modes. Lobby, recovery and legacy
modal mappings are unchanged, as are Board coordinates. The native 1280x640
two-slot regression now locks Fusion at `x=0.471` and Attack at `x=0.529`.
Offline verification remains **770/770 PASS** with compileall and diff checks
clean. Live acceptance remains required for one attributable EVOLVE attempt
and one attributable CAST acceptance from a newly started `v1.0.13` process.

Source compatibility update `v1.0.14` analyzes run
`30d14369ec9e4bd3aab1f6c7df9e685e`. The selected Attack card was proven in
the exact boss lobby and visible in combat, but every local policy state had
`cardCount=0`; therefore the low-HP finisher correctly skipped EVOLVE yet could
not authorize CAST. The run's single PASS at turn 33 was unrelated: policy saw
one Sword-5 move that would leave a known Sword-6 reply for the boss, deferred
it under the accepted unique-adverse-Sword rule, then took Sword-6 after the
board changed on turn 35.

Redux metadata reconfirms `Board.cardsInHand +0x320` and the CardUI ownership
fields. A read-only post-run audit proved the discovery gap: the two anchored
GameObjects occupied 0.273 MiB of direct `VirtualQueryEx` regions, while two
exact-class CardUI objects were in other regions of the same 6.117 MiB
`AllocationBase`. The provider now retains AllocationBase and scans only the
complete current cards-in-hand allocation, capped at 16 MiB. Full CardUI class,
current Board/Active ownership, Unity native/Button, CardData and interactable
validation remain mandatory; stale postmatch objects still reject. Offline
verification is **774/774 PASS**. Live acceptance still requires one
attributable EVOLVE and one accepted CAST from a newly started `v1.0.14`
process.

Phase 2F.1 adds the canonical Windows x64 portable one-folder package. Final
build `v1.0.0+15` uses PyInstaller 6.22.0, starts through the windowed frozen
entry point, requires neither Python nor the source repository at runtime, and
writes preferences/logs/checkpoints/locks only below one local app-data root.
The deterministic ZIP SHA-256 is
`b8aed614f43d3550ef1d8dd6d88d3d3dbdb76547f63d5b9b4144bca89f5e1d05`.

Clean staging outside the repository, different CWD, missing `PYTHONPATH`,
fresh app data, production-graph self-check and actual game-absent startup all
pass. Packaged read-only attach sends zero input. B4 FarmRun
`add073d8cbdb4fcb9a660964fb35ec11` completed exactly one
STRONG/CONSISTENT WIN after one correctly excluded dead-board technical abort
and exact-pet recovery; it created no attempt after target. B5 FarmRun
`6b89455c91ef434594f42f1febdeb905` accepted the UI graceful-stop command
during `ACTIVE_COMBAT`, completed one STRONG/CONSISTENT WIN, created no next
attempt, and stopped at exact `BOSS_LOBBY`. Build `+15` fixes the presentation
label so durable graceful-stop history does not leave the inactive button
showing `Stopping...` after controller STOPPED.

Write audit proves zero writes to `D:\pc`, zero writes to the source repository
during packaged execution and zero writes beside the packaged EXE. Packaged
checkpoint discovery uses the unchanged canonical validator. Final offline
baseline is **740/740 PASS** with compileall and diff check clean. Evidence:
[Phase 2F.1 report](phase2f1_report.md) and
[runbook](phase2f1_runbook.md).

Phase 2E.3 completes the compact Desktop UI and its finite UI-controlled
FarmRunner. Start, Stop After Current Match, Emergency Stop and durable lobby
checkpoint Resume share one generation-bound controller owner. Preferences
never auto-start or auto-resume. Accepted configuration is immutable while a
run is active, the verified game PID is foregrounded and normalized before
input, operator logging is bounded, and UI shutdown drains its single poller.

Start/Resume still requires an exact `CHINH_PHUC_ROOM` and pins that room's
positive runtime `enemyPetId` only for the farm session. A proven ejection or
technical incident may re-enter only that exact pet. Each independently proven
incident receives a fresh one-shot recovery coordinator; there is no
farm-lifetime recovery ceiling. Ambiguous room/map ownership, stale state or a
failed recovery still stops fail-closed. The pin is cleared when the controller
ends, and the tool does not navigate from the general lobby through islands.

Final B6 FarmRun `3aa7b7e1279a4c91a03c2f72dd9d48c4` completed exactly
25 evidence-backed results in 27 attempts: 25 WIN, 0 LOSS, 0 UNKNOWN, 25
STRONG/CONSISTENT terminals, and two independent dead-board technical aborts
whose exact-Starburst `1289` recoveries succeeded. Attempt 27 produced the 25th
completion and no attempt 28 was created. The run ended
`FARM_TARGET_COMPLETED` at `BOSS_LOBBY`. After idle UI close, the summary proved
one poller, one maximum controller, 67/500 operator-log entries, zero UI/thread
errors, a stopped poller/process and the game process still alive. Evidence:
[Phase 2E.3 report](phase2e3_report.md) and
[runbook](phase2e3_runbook.md).

The accepted Phase 2E.2 and Phase 2E.1 foundations remain documented in their
respective reports. There is still no hidden start-on-launch behavior.

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

The user then explicitly approved reducing the local-turn deadline warning to
an inclusive one-second actionability floor. The controller may send at a
displayed `1` after its ordinary fresh preflight, and fail-closes at `0`.

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

Primary production source:

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

Phase 2E.3 B6 retries exposed a remaining post-opening gap when Unity reclaims
the current `WsCombatBatch`/transport DTO after its durable ACK becomes visible
but before the external poll captures it. `Board.allDots` cannot close this gap
directly: Cpp2IL proves that its elements are `GameObject` references, not
`Dot` component pointers, and the external `GameObject -> Dot` traversal is
still UNKNOWN. The rejected experimental `GameObject + 0x48` path was removed;
it never resolved a live Dot and had no valid layout evidence. DTO remains the
only production board source. CV remains audit/reference, not production. See
[Phase 2B.5](phase2b5_report.md) for the accepted DTO-only boundary.

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
- Live control discovery first scans only the allocation regions anchored by
  the current `Board.cardsInHand` GameObjects. Cpp2IL proves that
  `FusionCardUI.Spawn`'s returned GameObject is appended to this list. Region
  membership is discovery evidence only; the exact `FusionCardUI` class,
  native object and live Button must still validate before input.
- Functional and non-turn-consuming.
- `success=false` may retry only under fresh-state/lock/response safety.
- `success=true` requires durable `fusion.used=true`, then full reread; a
  consuming action may still occur on the same turn.
- Terminal success/failure may lead to an `EVOLVE-only turn` with zero further
  input when policy would otherwise PASS.

EVOLVE idle-reset semantics: **UNKNOWN**.

Phase 2E.3 B6 retry 31 exposed a discovery regression rather than an evolution
failure: Mana reached 175/280/385, but no EVOLVE input was sent. At turns with
six seconds left the inclusive ten-second EVOLVE response/follow-up floor
correctly deferred the action; at the ten-second opportunity the rotating
extended scan had not found a current `FusionCardUI`
(`cachedFusionUiAddresses=0`). The new cards-in-hand owner-anchor discovery is
offline-tested and still requires a fresh live EVOLVE observation before B6
can continue.

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
- [Phase 2E.3](phase2e3_report.md) — **PASS STRONG**; compact operator UX,
  session-pinned exact-pet recovery, card/Fusion and latency hardening, two
  naturally recovered dead boards, and an exact 25/25 STRONG/CONSISTENT WIN
  UI soak with clean UI/poller shutdown.

Intermediate retries are historical evidence, not current phase status.

## Current Test Baseline

Verified on **2026-09-03**:

```text
python -m unittest discover -s tests -p 'test_*.py'
Ran 797 tests
OK
```

Current source baseline: **797/797 PASS**. The accepted packaged Phase 2F.2 RC
remains at its original **740/740 PASS** baseline. Phase 2E desktop/controller and terminal
hardening focused suites: **PASS**. `python -m compileall -q src tools tests`:
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
Phase 2F.1 adds source/frozen path abstraction, packaged checkpoint discovery,
frozen startup/single-instance behavior and production bundle/resource checks.

## Current Known Limitations

- The Phase 2E.3 UI intentionally exposes only finite target and attempt
  limits. Infinite/daemon operation, automatic game launch/login/process
  restart, target rotation, scheduling, and remote control are not implemented.
- Emergency Stop is terminal for the current UI controller generation. It can
  leave the game combat itself running; the user may finish/exit normally, but
  the stopped controller sends no further input and its checkpoint is not
  resumable.
- UI Resume accepts only a durable checkpoint at an exact boss-lobby boundary.
  Completed, emergency, malformed, stale, or mid-combat checkpoints remain
  disabled in the UI and are rejected again by the backend authority.
- Bounded continuous farming is accepted for 25 completed matches with an
  explicit match-attempt ceiling. Successful technical recovery has no
  farm-lifetime cap, but every proven incident still receives only one bounded
  Exit/Confirm/Re-entry coordinator. Infinite/daemon farming, game launch/login,
  automatic process restart and ambiguous retries are not accepted.
- Checkpoint resume is history/accounting continuation only and requires a
  freshly confirmed exact boss lobby. Mid-combat controller restart/resume and
  restoration of executable runtime state are not accepted.
- The result-modal `Đồng ý` requirement, exact locator, one-click normal-UI
  path, and resulting lobby transition are live-accepted for the proven modal.
- Phase 2E.3 B6 naturally recovered two exact dead boards. Session-scoped ACK
  isolation accepted both fresh recovered openings; an unexplained current-
  session ACK conflict still stops fail-closed. Automatic process restart
  remains out of scope.
- Terminal PlayerStats capture before cleanup is live accepted for all 25 B6
  matches: 25 STRONG WINs, all UI-consistent. UNKNOWN remains the fail-closed
  outcome when evidence disappears too early.
- The accepted B6 working-set sampler observed start/peak/end values of roughly
  52/106/106 MiB across 27 attempts, with no observed unbounded growth.
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
- Desktop Start/Resume remains current-room-only, but an active farm session may
  re-enter its exact pinned positive numeric pet ID from a proven settled world
  boss map. Each incident uses a fresh one-shot recovery coordinator;
  ambiguous target evidence or an already-sent recovery re-entry fails closed.
  The pin is cleared when the
  controller ends, so a later Start again requires an exact current boss room.

### Superseded Phase 2E.3 live-retry evidence

The following entries explain the defects found on the route to acceptance.
Their statements that another exact-25 run was required are superseded by the
accepted FarmRun documented in [Phase 2E.3 report](phase2e3_report.md).

- Phase 2E.3 B6 attempt `phase2e3_b6_25_match_soak_01` stopped safely after
  seven STRONG/CONSISTENT wins when attempt 8 lost combat ownership at turn 5
  and returned directly to `WORLD_BOSS_LIST`. The attempt had three local
  SWAP inputs, no terminal participants/HP/event/UI evidence, and therefore
  cannot be called a completed match. The discovered accounting bug that had
  promoted this lifecycle loss to completed `UNKNOWN` is fixed: both the
  combat-summary validator and `FarmRun.normal_combat_ended` now reject an
  evidence-free UNKNOWN terminal. Evidence-backed UNKNOWN captured before
  cleanup remains supported. B6 retry
  `b049492a1bf94becb8d974c3321041fd` then proved the guard: its second attempt
  was not counted when a mandatory idle-2 turn arrived with six seconds, the
  selected SWAP was sent promptly but never ACKed, and the room was lost. The
  new late-mandatory recovery dispatch and exact-pet ejection fallback are now
  covered offline. B6 run `7509b0e5526c41eeab443a9332f6a457` then provided
  live exact-pet re-entry evidence: attempt 4 lost its terminal evidence,
  settled at `WORLD_BOSS_LIST`, selected only pinned pet `1289` (`Starburst`),
  restored exact room `Coop_581981`, and entered attempt 5 without counting a
  completed UNKNOWN. The same run later hit a genuine
  `DEAD_BOARD_NO_REFRESH` on attempt 8. Recovery sent one `Exit + Confirm` and
  returned to the exact pinned room, but its internal ACK-epoch guard blocked
  before re-entry; the outer runner previously stopped because it accepted only
  a world-map fallback. It now also accepts this independently proven exact-room
  boundary, audits that no recovery re-entry/target-selection input was sent,
  discards all old combat state, consumes one bounded recovery, and uses the
  normal fresh-entry flow. Fresh retry `23389f2475ed4b9db3dea884dd3ee4e6`
  live-proved another exact `1289` map re-entry and then exposed a separate
  PASS-correlation bug at attempt 10: the server reported authoritative idle
  `1/3` before PASS and `2/3` after PASS, but the coordinator compared `2/3`
  with its local first-pass index and stopped. PASS confirmation now derives
  the expected transition from the exact game-owned idle-before value
  (`1 -> 2` here), falling back to the local bounded index only for an accepted
  non-numeric reset baseline. It still rejects stale, mismatched, threshold-3,
  and otherwise unproven observations. The next live retry
  `92a1d2643da34079b35d0709a822073c` completed one STRONG/CONSISTENT WIN, then
  exposed two independent input-boundary regressions on attempt 2. First,
  ejection re-entry stopped at `WORLD_BOSS_LIST` because the desktop UI owned
  foreground; re-entry now restores only the already bound exact-PID HWND and
  then reacquires all runtime/two-frame target evidence before its maximum-one
  normal click. Second, the resized `1181x617` game client inherited V1's
  `board_first_center_y=.146` / `board_step_y=.0725` calibration. The planned
  bottom-row `(7,2)<->(7,3)` was a real match on the authoritative board, but
  its physical y=402 landed at the row-6/row-7 boundary rather than the tile
  centre near y=426. Exact evidence was board hash unchanged, LocalSeqNum still
  zero and authoritative AFK advancing to 1/3 then 2/3. Desktop Start now
  restores the verified HWND/PID and normalizes the client to canonical
  `1280x720` before FarmRunner binds it; a live zero-input preflight changed
  PID 3504 from `1181x617@(717,206)` to `1280x720@(632,206)` while retaining
  the exact HWND/PID and foreground. A bare MatchService `_ackedSeqs` advance
  is no longer SWAP acceptance or idle-reset evidence: only the exact durable
  local move-sequence plus matching from/to coordinates can acknowledge a
  SWAP. Later B6 retries `_28`, `_29`, and `_30` all stopped safely with zero
  invented completion when Unity's short-lived transport DTO and
  `WsCombatBatch` were reclaimed after the durable ACK became visible. That
  transport gap remains unresolved; `Board.allDots` must not be treated as a
  `Dot[,]` or promoted into a production board without a proven component
  traversal. A fresh exact-25 B6 run is still required after the provider
  timing/current-DTO path is corrected.
- The first live EVOLVE regression retry after the Fusion owner-anchor change
  proved a separate timing defect: current `FusionCardUI` discovery did not
  start until local Mana reached the runtime cost. By turn 13 it had spent two
  owner-anchor attempts plus two extended scans (33,554,530 bytes) and still
  had no cached Fusion wrapper; zero EVOLVE inputs were sent. Discovery is now
  explicitly independent from Mana. Turn 1 remains reserved for the opening
  board/SWAP, while the first observed boss turn performs one full normal-region
  current-session CardUI/FusionCardUI warm-up and caches only exact validators.
  The first live warm-up retry then proved its board/CardUI half: turn 1 SWAP
  was acknowledged, and turn 2 performed a full normal scan at zero Mana which
  resolved all three equipped CardUI wrappers. It also exposed that the
  game-owned `FusionEnabled` flag is false before affordability, so using that
  flag as a discovery prerequisite still skipped FusionUI. `FusionEnabled` is
  now removed from discovery while remaining an EVOLVE action gate. Later
  retries remain bounded. This final adjustment is offline-tested but still
  requires a fresh live EVOLVE acceptance run.
- Phase 2E.3 B6 exact-25 retry `65095df6d2c24cd49274def942f39d83`
  exercised the production one-second inclusive action floor and the post-IDLE-2
  cached-board fast path. It completed three STRONG WIN results with 80
  gameplay inputs, including confirmed SWAP, EVOLVE success and accepted CAST,
  before attempt 4 stopped at `PASS_STATE_UNKNOWN`. Exact evidence showed a
  policy-selected zero-input PASS while the authoritative board/local turn and
  live boss remained current but the transient board-only stats fallback had
  no local `Player` object. The PASS preflight was abandoned, the server later
  emitted exact `MATCH_AFK_WARN 1/3`, and the next local turn could not bind
  that numeric result to an active PASS coordinator. The controller stopped
  fail-closed; the user then manually returned to the boss lobby. This was not
  an automatic recovery or game ejection.
- Farm-owned zero-input PASS tracking now tolerates only that exact stats-only
  gap: local player absent, boss present with positive HP, same ACTIVE local
  session, production-ready stable/ACK/latest board. It still sends no Windows
  input and lets authoritative AFK/lifecycle evidence determine the terminal
  result. As defense in depth, a remaining farm-owned `PASS_STATE_UNKNOWN`
  with a live bounded recovery dispatcher no longer auto-pauses immediately;
  it sends no input and waits for either authoritative state change or the
  existing terminal active-turn recovery gate. Standalone/no-recovery behavior
  remains fail-closed.
- Phase 2E.3 B6 exact-25 retry
  `dea1b8b2eb8e42b98616018dcd4133c6` completed 13/13
  STRONG/CONSISTENT WINs with 258 gameplay inputs and zero technical
  recoveries. Entry 14 then created exact session `M_31f7fb40`, but its
  short-lived `MATCH_START` opening DTO was reclaimed before the provider could
  publish a stable immutable opening. A later exact current-session
  `MATCH_MOVE_RES` board proved that the untouched combat had already advanced
  beyond turn 1 (`turn=3`, `LocalMoveSequence=0`, one entry click, zero gameplay
  inputs). The old entry boundary correctly refused to treat that later board
  as an opening, but stopped the whole run with `ENTRY_TIMEOUT_OPENING_BOARD`.
  The controller stopped at `11:57:11Z` while the combat remained active. At
  `11:57:23Z` the observer saw `LOBBY_OTHER` with no combat/room owner: the
  untouched match was ejected to the boss map after the controller had stopped.
  The user did not manually return to the lobby and no automatic recovery ran.
- That exact missed-opening case now routes to bounded technical recovery only
  when session/match ownership, one entry click, zero gameplay input, turn > 1,
  `firstLocalTurn=false`, `LocalMoveSequence=0`, positive `srvSeq`, board hash,
  and exact `ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board` source all agree.
  The route is immediate on that first proven advanced current board; it does
  not wait out the remaining opening timeout and abandon the game near the idle
  ejection boundary. It remains a technical abort, never a completed match,
  and the recovery path still revalidates the failed live session immediately
  before normal Exit UI input. Any mismatch remains fail-closed. Offline
  verification after the PASS and missed-opening fixes was 650 tests PASS and
  compileall clean.
- Phase 2E.3 B6 exact-25 retry
  `56c884d710e94dbaad8c0c6a3379c639` completed 11/11
  STRONG/CONSISTENT WINs with 229 gameplay inputs and zero technical aborts or
  recoveries. Attempt 11 sent exactly one audited `POSTMATCH_CONFIRM` only
  after memory proved WIN and the UI proved `Thắng`. The server then removed
  `WsRoomService.CurrentRoomId` while Unity continued rendering the exact
  Starburst/Ready room shell. Read-only evidence was lifecycle `LOBBY`, no
  combat owner, stale `RoomDTO.enemyPetId=1289`, exact clean runtime pet-button
  closure/PlayerPrefs for 1289, but `ManagerBoss=null`; the old lobby waiter
  discarded this as generic `LOBBY_OTHER` until `RETURN_LOBBY_TIMEOUT`.
  The detached-shell locator already existed, but its atomic gate incorrectly
  required the mutually exclusive `WORLD_BOSS_LIST` branch. The waiter now
  surfaces only a stable exact-pet detached-shell candidate after the existing
  room-rehydration grace. Re-entry still requires the current pinned positive
  pet ID, no combat owner, exact read-only Button/cached-group/PlayerPrefs
  association, and two stable visual frames before one shell-exit click; it
  then requires the fully proven world-boss map before the existing maximum-one
  exact target selection. Wrong pet, live session, ambiguous runtime or
  unstable UI sends no click and fails closed. The captured live shell satisfies
  both the new read-only candidate and visual locator (`confidence=0.9698`).
  Offline verification is now **652/652 PASS**, compileall clean and
  `git diff --check` clean apart from existing CRLF conversion warnings. A
  fresh exact-25 B6 live run is still required; Phase 2E.3 remains NOT PASS.
- Run `0d465c3f5d4b40aa94abf62bb0b00b13` also exposed the gameplay-latency
  regression behind its late turns. At turn 27, the local turn was visible at
  about `17:10:17`, but policy did not receive a stable board until
  `17:10:25.684`. The blocking step was
  `LOCAL_TURN_ACK_GAP_FULL_ESCALATION`: 510 regions / 571,180,289 bytes / 3.50
  seconds, followed by board stabilization. `RuntimeSequenceMonitor` retained
  only ChatMessageDTO regions even when the same scan found WsCombatBatch in a
  batch-only 8-16 MiB region, so later ACK gaps repeatedly fell back to broad
  heap scans during the player's turn. The monitor now learns both DTO and
  batch regions during the safe pre-entry lobby prime, retains batch-only hits
  after every scan, and receives both hint types from the shared provider.
  Ordinary scans use exact learned regions; allocator neighbours are added only
  for a new ACK gap. A live lobby measurement on PID 5748 reduced the repeated
  scan set from 429.62 MiB to 39.04 MiB and measured the learned scan at 0.206
  seconds (the one-time 429.62 MiB prime remained in the lobby at 2.94 seconds).
  Fresh combat evidence is still required before declaring the latency fix
  live-accepted.
- A manual room re-entry after that stop proved another lifecycle boundary:
  `ManagerRoom.selectedCards` was empty while stale `RoomDTO.cards` still held
  Mana/Rage/Health/Attack, so the authoritative next-combat loadout contained
  zero cards. Cpp2IL/ISIL proves that `ManagerRoom.DisplayCardsForSelection`
  creates and registers room Toggles in exact `RoomDTO.cards` order. The live
  room had one owned Attack candidate at index 3 (`data_id=64647`, `card_id=4`).
  One diagnostic normal click changed the manager list from empty to exactly
  `((64647,4,ATTACK))`. The production path now plans only a unique owned
  Attack card, requires the exact room/pet and no combat owner, proves the
  runtime-indexed Toggle in two frames, records one `BOSS_CARD_SELECT`, and
  rereads `ManagerRoom.selectedCards` before permitting the independent Start
  capability. A live no-entry probe repeated the complete empty -> auto-select
  -> memory-confirm sequence successfully; locator confidence was `0.9690`.
  No function/support card is restored in this milestone, and a genuinely
  unavailable Attack card retains board-only fallback. Offline verification is
  now **658/658 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF conversion warnings. The UI must be reloaded before the fresh
  exact-25 run; Phase 2E.3 remains NOT PASS.
- Fresh exact-25 run `15cb5cf6be3648e19d4090a9b26c2956` proved the
  pre-entry Attack contract end to end for three completed STRONG/CONSISTENT
  WINs: every entry had `preentryCardCount=1`,
  `preentryAttackCardCount=1`, and the live combat used the card (attempt 3 had
  four accepted casts). Attempt 4 then exposed a separate dead-board routing
  defect. After two authoritative passes and one acknowledged mandatory reset,
  the exhaustive 112-pair scan again returned `NO_LEGAL_MOVE_BUG` at idle 2.
  The generic mandatory SWAP/CAST assertion ran before the existing
  `EXIT_MATCH`/dead-board recovery branch, producing
  `MANDATORY_CONSUMING_ACTION_NOT_SELECTED` and safely stopping the run at
  3/25. Verified dead-board evidence now preempts only that generic assertion
  and dispatches the existing bounded `DEAD_BOARD_NO_REFRESH` technical
  recovery to the outer farm coordinator. PASS, NONE and EVOLVE at idle 2
  remain fail-closed and cannot use this exception. Offline verification is
  now **660/660 PASS**, compileall clean and `git diff --check` clean apart
  from existing CRLF conversion warnings. Because the run ended before this
  fix was loaded, a new exact-25 run is still required; Phase 2E.3 remains NOT
  PASS.
- After a machine reset, fresh run `8116549228b4419bb518f95fb6fe1a18`
  completed one STRONG/CONSISTENT WIN, then reproduced the real postmatch card
  reset: `ManagerRoom.selectedCards=[]` while `RoomDTO.cards` still exposed one
  Attack at index 3. The selection path correctly planned that exact card, but
  Unity rendered the cyan cost header one frame before the card body. The first
  locator frame was incomplete; the very next frame proved the exact Attack
  Toggle with confidence `0.9815`. Requiring exactly the first two frames
  therefore produced the false stop `ATTACK_CARD_TOGGLE_UNPROVEN`. Selection
  now remains zero-input for a bounded three-second window and requires two
  consecutive complete proofs at the same runtime-derived point and unchanged
  foreground geometry. Thresholds are unchanged; an unstable, missing or
  changed Toggle still fails closed. Offline verification is now **662/662
  PASS**, compileall clean and `git diff --check` clean apart from existing
  CRLF conversion warnings. A reloaded UI and fresh live run must prove the
  empty-manager-list -> selected Attack -> Start sequence and continue the
  exact-25 soak; Phase 2E.3 remains NOT PASS.
- The first live retry with the bounded visual wait,
  `70e86e4434cd4859aa826cf4f9cce2e1`, completed another
  STRONG/CONSISTENT WIN. Its next entry reproduced the asynchronous state more
  precisely: the locator obtained two consecutive complete Attack frames after
  four captures (`confidence=0.9690`), while the atomic read-only preflight
  found that Unity/server had independently repopulated the same Attack into
  `ManagerRoom.selectedCards`. The old strict REQUIRED-only preflight rejected
  this desired `REQUIRED -> ALREADY_SELECTED` transition as
  `ATTACK_CARD_RUNTIME_CHANGED`. The preflight now accepts only that transition
  when the exact card identity, room, pet and no-combat-owner invariants still
  match, records `preentry_attack_selection_rehydrated`, and sends zero card
  clicks. Different card identity or any other runtime change still fails
  closed. Offline verification is now **664/664 PASS**, compileall clean and
  `git diff --check` clean apart from existing CRLF conversion warnings. The
  UI must be reloaded again and the next postmatch entry must prove this live;
  Phase 2E.3 remains NOT PASS.
- Post-reset exact-25 run `77e182eb460b43a1802daa8e6601aa46`
  completed 21 matches (19 WIN, 2 LOSS) with zero technical aborts/recoveries,
  including the previously problematic attempt 16 and a live
  `REQUIRED -> ALREADY_SELECTED` Attack-card rehydration. Attempt 22 then
  stopped making progress on boss turn 6: `MatchService` remained at timer 14
  and `ClockPauseReason=ACK_WAIT`, with no pending bot action, while the ACK set
  had already advanced from `srvSeq=11` to 13. Read-only runtime evidence found
  local actor 1 in `Board._leftActorNumbers`; the game UI independently showed
  the local player as left. `MatchService.Players["happi"]` remained stale at
  `inMatch=true`, proving it is not a safe membership source for this failure.
  The provider now validates the exact `HashSet<int>` layout at `Board+0x2B0`,
  publishes `local_has_left_match`, blocks all gameplay when true, and routes
  only an exact farm-owned ACTIVE session to bounded technical recovery. Boss
  turns without this durable signal remain zero-input waits; no generic boss
  timeout was added. Offline verification is now **671/671 PASS**, compileall
  clean. The running UI predates this fix and must be reloaded before live
  recovery/soak validation; Phase 2E.3 remains NOT PASS.
- Fresh exact-25 run `786ab019a93e4c8abb3d424c10b1c20a` completed
  7/7 STRONG/CONSISTENT WINs with zero technical aborts/recoveries, including
  Attack casts and successful EVOLVE-follow-up gameplay. After attempt 7 the
  server again removed room ownership while Unity rendered the exact Starburst
  shell. Production correctly surfaced `DETACHED_ROOM_SHELL_CANDIDATE` and
  sent one proven shell-exit click, but then timed out because the map badge
  locator's single historical `number_A_8` template did not match Unity's
  1280x720 rasterization. A direct live capture classified the displayed 8 as
  the old 6 template (`targetScore=7`); the measured 1280x720 variant now
  identifies only that badge with `digitScore=0`, `digitMargin=6`, and
  confidence `0.955`. The post-shell transition now accepts exactly two
  bounded paths: two stable runtime-derived target-badge frames for direct map
  navigation, or three stable leave-modal frames followed by one separately
  audited `BOSS_ROOM_SHELL_CONFIRM`, unchanged exact-pet/no-owner runtime
  proof, then stable map proof. Neither path may click on ambiguity. Live
  read-only verification on the resulting map resolved Starburst/1289,
  `huntOrder=8`, the unique badge, and one exact normal click returned to a
  true inspect-ready boss room. Offline verification is now **674/674 PASS**,
  compileall and `git diff --check` clean apart from existing CRLF warnings. A
  new exact-25 run is required; Phase 2E.3 remains NOT PASS.
- Exact-25 retry `653bac40fc0c443ea465d9c4294b31bb` completed attempt 1 as
  a STRONG/CONSISTENT WIN with successful Attack cast and EVOLVE, then the
  first Start input for attempt 2 received no game response. The exact target,
  Attack loadout, two-frame Start locator, foreground geometry and normal
  input dispatch were all valid, but 45 seconds later there was still no
  session/loading owner and the same Start control remained visible. The old
  one-click entry contract therefore stopped at `ENTRY_TIMEOUT_NEW_SESSION`.
  Farm-owned entry now has one separately audited `BOSS_ENTRY_RETRY` permit:
  it is available only in the still-pending same attempt after exactly one
  sent Start, with no combat owner, unchanged clean room ID/pet/Button address,
  and two stable frames of the same Start signature. It cannot create a new
  match attempt, cannot be repeated, and a changed/ambiguous proof sends zero
  retry input and fails closed. Standalone BossEntry remains one-shot because
  it has no farm retry capability. Offline verification is now **677/677
  PASS** and compileall clean. A fresh exact-25 run is still required; Phase
  2E.3 remains NOT PASS.
- Exact-25 run `33f02803c0b2464cb3a0da22b05eff09` completed six consecutive
  STRONG/CONSISTENT WINs. Attempt 7 naturally hit an exact dead board and the
  bounded technical recovery correctly sent one Exit plus one Confirm, cleared
  the old provider session and returned to the true exact Starburst boss
  lobby. It then stopped before re-entry because the original lobby ACK guard
  required `MatchService._ackedSeqs` to be empty. Live read-only evidence over
  120 samples/15 seconds proved `CurrentMatchId=null`, no provider session and
  an unchanged stale pair `highestAckedSequence=29/localMoveSequence=6`.
  Successful ordinary entries in the same process prove that Unity clears
  this residue while binding the next MATCH_START, not necessarily while idle
  in the lobby. Recovery now accepts only a frozen owner-free residue after at
  least eight identical samples spanning two seconds; advancing, unreadable or
  owned epochs still block. It then re-proves the exact lobby and keeps
  gameplay locked until a distinct pristine MATCH_START shows a null ACK epoch
  throughout the existing 2.5-second handoff guard. Focused offline recovery
  tests are PASS; full-suite and new exact-25 live evidence are pending, so
  Phase 2E.3 remains NOT PASS.
- Exact-25 run `f4ea08261b1e4b41a9c997c46e7f5a25` completed 16/16
  normal results before an operator-requested graceful stop at the exact boss
  lobby: 13 WIN, 1 LOSS and 2 evidence-backed UNKNOWN, with zero technical
  aborts/recoveries. Attempts 1-13 had complete local PlayerStats. On attempts
  14-16 every policy sample retained boss stats but lost the local participant;
  Attack remained discoverable, yet affordability was UNKNOWN and no
  EVOLVE/CAST was permitted. This was not merely terminal cleanup: it affected
  every active-turn policy decision in those three matches. Reverse evidence
  confirms `Active.playerStatsList +0x28` is the serialized inspector view,
  while `Active.playerStatsMap +0x20` is the game-owned
  `Dictionary<int, Active.PlayerStats>` used by combat actor lookup. Participant
  decoding now structurally validates both sources and uses the current map as
  primary, with the list only as an overlapping pointer-consistency check and
  fallback when no map object is published. A declared malformed/changing map,
  key/actor mismatch or map/list pointer conflict fails closed; no prior-call
  participant is cached or reused. The exact list-only-boss/map-player+boss
  regression and conflict cases are covered offline. Full verification is now
  **685/685 PASS**, compileall clean. A fresh live run must prove map-backed
  local HP/mana and card use beyond the old long-session boundary before B6
  can be accepted; Phase 2E.3 remains NOT PASS.
- Exact-25 retry `bbb76d27b1ef403fb4530d3a57937c5c` proved the new
  `playerStatsMap` path in three consecutive STRONG/CONSISTENT WINs. Every
  local/boss sample was map-backed; EVOLVE succeeded and was followed by a
  fresh-state same-turn SWAP, while three ATTACK casts were accepted. Attempt
  4 naturally hit a proven `DEAD_BOARD_NO_REFRESH`. Bounded recovery sent one
  Exit and one Confirm, returned to the exact Starburst room, sent one re-entry
  click and obtained a distinct pristine 64/64 MATCH_START. The handoff then
  falsely stopped because the provider instance reused by recovery retained
  `metrics.highest_acked_sequence=43` from the failed session even though the
  new runtime ACK epoch was empty. This field is a current-session gauge, not
  a cumulative metric: both lifecycle reset and lifecycle clear now set it to
  `None`. The handoff guard also keeps gameplay locked for its complete bounded
  window when it initially sees a dirty gauge, accepting only after the gauge
  clears and at least two clean pristine states remain with more than four
  seconds; a persistent/delayed ACK still fails closed as
  `RECOVERY_ACK_EPOCH_NOT_RESET`, and session/action mismatches still reject
  immediately. Regression coverage includes both provider lifecycle paths,
  stale-gauge settlement, persistent contamination and session change. Full
  verification is **690/690 PASS**, compileall clean and `git diff --check`
  clean apart from existing CRLF warnings. The run stopped at the guard and
  therefore a fresh exact-25 B6 run is still required; Phase 2E.3 remains NOT
  PASS.
- Exact-25 retry `1f605aeb308e4b09a95878fcb37ec398` completed 19
  STRONG/CONSISTENT results (18 WIN, 1 LOSS) with zero technical aborts or
  recoveries. It passed the old attempt-14--16 failure boundary with every
  local/boss policy sample sourced from
  `Active.playerStatsMap/ObfuscatedInt.Value`; Attack affordability, fourteen
  successful EVOLVEs and thirty accepted CASTs remained available in the long
  process. After result 19, Unity produced a detached room shell. The runner
  proved and clicked exactly one shell exit, then proved the exact Starburst
  hunt-order-8 badge in two frames. The final atomic preflight rejected only
  because the generic lobby classifier reported the expected owner-free
  post-shell transition as `LOBBY_OTHER/branch=None`, rather than the normal
  `BOSS_LOBBY/WORLD_BOSS_LIST`; exact Button/Pet/PlayerPrefs identity and all
  no-owner evidence were unchanged. Map preflight now accepts exactly those
  two owner-free shapes. It still requires lobby lifecycle, null room ID/type,
  null owner, `is_host=false`, no provider session, the exact runtime target
  association and stable badge proof. Any owned room, ACTIVE lifecycle or
  different state/branch remains fail-closed. Full verification is now
  **693/693 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF warnings. The safety stop means this run is not B6 acceptance;
  a fresh exact-25 run is still required. Phase 2E.3 remains NOT PASS.
- Exact-25 retry `5fb7ac622bd1476babe099e0dab0bfb3` completed three
  STRONG/CONSISTENT WINs with zero aborts/recoveries, then stopped before
  attempt 4 with zero new input. `ManagerRoom.selectedCards` had correctly
  reset while `RoomDTO.cards` still proved the unique Attack at index 3, but
  Unity rendered only the cyan strip/header throughout the former three-second
  visual window; both Attack body metrics remained exactly zero. The saved
  frames prove this was an incomplete strip rather than a wrong card. The live
  room later rendered all four bodies normally. Required-Attack discovery now
  remains zero-input for a bounded 15 seconds and still requires two complete
  consecutive frames with the original thresholds, exact foreground geometry
  and unchanged room/runtime identity. The post-click read-only verification
  window is separately bounded at ten seconds. These waits are lobby-only and
  do not affect first-turn or combat action latency. Full verification is now
  **694/694 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF warnings. The safety stop invalidates B6 acceptance; a fresh
  exact-25 run remains required. Phase 2E.3 remains NOT PASS.
- Exact-25 retry `0d465c3f5d4b40aa94abf62bb0b00b13` completed 14
  evidence-backed matches in 16 attempts (8 WIN, 1 LOSS, 5 UI-audited
  MEMORY_INCOMPLETE UNKNOWN), with one dead-board technical recovery. Attempt
  10 itself ended with stable `Thắng/WIN`; it was not the ejection. Attempt 16
  reproduced the actual failure: after authoritative PASS at turn 25 produced
  idle `1/3`, a Sword SWAP was selected/sent at one remaining server tick and
  expired with `RESPONSE_OR_ACK_TIMEOUT`. The next local turn was first usable
  at two ticks; another SWAP was sent without ACK, after which combat ownership
  disappeared with no terminal HP/event/UI evidence. This is consistent with
  the server counting the missed inputs as idle 2/3 and 3/3. The user separately
  confirmed that moves sent at displayed `1` are accepted and animate normally,
  so this is classified as lag/unconfirmed-action evidence rather than a reason
  to raise the timer floor. Production keeps the inclusive one-second floor;
  only `0` blocks new input. A fresh exact-25 run is required;
  Phase 2E.3 remains NOT PASS.
- First-turn retry `6f865ca238134733b1d252f6a876e885` proved that the
  remaining opening failure was latency, not a wrong swap coordinate. Entry
  had already accepted a pristine 64/64 opening at timer 10, but the combat
  controller repeated provider stabilization. An equivalent later
  `MATCH_START` publication changed the sequence identity, so the policy
  proposal at timer 6 was rejected; the replacement proposal reached the
  input executor only after a timer-3 preflight and received no ACK before the
  user stopped. Production handoff now reuses the entry-proven immutable board
  for only the pristine first local action. A cheap direct MatchService read
  must still prove the exact session/match, local owner, turn 0/1, local move
  sequence 0, no prior move and timer >= 1 both at controller publication and
  immediately before input. Any mismatch falls back to the normal provider;
  any successful SWAP, EVOLVE or CAST permanently invalidates this fast path.
  Transport scans also retain both ChatMessageDTO and WsCombatBatch regions;
  a live read-only benchmark reduced the ordinary learned scan from about
  429.62 MiB to 39.04 MiB (0.206 s on that sample). Offline verification is
  **696/696 PASS**, compileall and `git diff --check` are clean. A fresh live
  manual-Start retry is still required; Phase 2E.3 remains NOT PASS.
- Live run `5048e07b690d456ca0783ff6b949dc4e` proved the opening
  fast path in repeated real combats. Attempts 1, 3, 4 and 5 were accounted as
  STRONG/CONSISTENT WINs; attempt 2 was a true dead-board technical abort whose
  bounded Exit/Confirm/exact-Starburst re-entry completed successfully. The
  first SWAP in attempts 5 and 6 was decided immediately from the pristine
  handoff and acknowledged by the server. Attempt 6 additionally proved three
  failed EVOLVE responses each fell through to a same-turn acknowledged SWAP,
  a later EVOLVE succeeded, two ATTACK cards were accepted with exact 160-Mana
  deltas, and authoritative idle 1/3 then 2/3 forced an acknowledged mandatory
  SWAP instead of a third pass. It reached a STRONG WIN with zero duplicate,
  stale, wrong-turn, postmatch or lobby input and zero response timeouts. An F9
  edge arrived about two seconds after the terminal WIN and finalized the run
  as `EMERGENCY_STOPPED`, so attempt 6 was deliberately not counted in the
  checkpoint; this is operator/control evidence, not a combat failure.
  Optional-card publication was intermittent after rapid ordinary postmatch
  returns: attempts 2 and 4 had no live CardUI/FusionCardUI, whereas attempts
  1, 3, 5 and 6 resolved both. Pre-entry now maps an already-selected unique
  RoomDTO Attack back to its exact visual slot and requires the selected body
  proof to remain stable for three seconds before Start. It sends no extra card
  click; ambiguous/no-slot telemetry keeps the Manager selection authoritative
  and records that the settle proof was unavailable. This lobby-settle patch
  is offline verified but was not loaded by the UI process used for the run.
  Full verification remains **696/696 PASS**, compileall and
  `git diff --check` clean. Restart the Desktop UI and run a fresh bounded soak
  to validate the settle patch; Phase 2E.3 remains NOT PASS.
- Exact-25 run `0345ab13927c4607bf9d381c97085725` loaded the lobby
  settle patch and reached 19/25 completed matches: 19 STRONG/CONSISTENT WIN,
  0 LOSS, 0 UNKNOWN, 3 earlier successful technical recoveries. Attempt 23
  accepted a pristine 64/64 opening at timer 13 but then published the local
  actor inside validated `Board._leftActorNumbers`; the game UI showed timer 0
  and `[đã thoát]` while lifecycle remained `ACTIVE_COMBAT`. The detector
  produced `LOCAL_PLAYER_LEFT_ACTIVE_COMBAT`, but the old run-level recovery
  cap had withheld the per-combat dispatcher, so `recoveryTrigger` remained
  null and the run finalized `COMBAT_SAFE_STOP`. Recovery is now farm-lifetime
  unbounded: each proven incident always receives a fresh one-shot coordinator,
  while ambiguous/failed recovery remains fail-closed. `Max recoveries` was
  removed from the UI and CLI help; old persisted/checkpoint values are ignored
  for enforcement and resume compatibility. A narrow history-only migration
  can resume this exact legacy cap-stop shape from an independently proven
  exact boss lobby, accounting its single orphan attempt as technical abort and
  restoring no executable state. Offline verification is **701/701 PASS**.
  The patch requires a Desktop UI restart and live resume/continuation; Phase
  2E.3 remains NOT PASS until the exact-25 target completes.
- Exact-25 retry `40e07464eebd4509a91439877d63c6f2` reached 21/25
  completed matches in 23 attempts: 17 WIN, 0 LOSS, 4 UI-audited
  MEMORY_INCOMPLETE UNKNOWN, one dead-board abort and one successful recovery.
  Attempt 23 then proved a different game/server freeze. After three accepted
  SWAPs, direct MatchService state became permanently fixed at match
  `M_ef4e8a78`, turn 10, owner `__BOSS__`, timer 14, local/last move sequence
  3 and highest ACK 24. Across 187 full scans there were no new messages,
  batches, timer ticks, turn transitions or sequence progress; the controller
  waited until its 1800-second timeout. The screenshot also displayed
  `happi [đã thoát]`, but `Board._leftActorNumbers` did not publish a fresh
  `GameState`, so the existing player-left detector could not arm recovery.
  Build `v1.0.0+10` adds an exact-session active-combat progress watchdog for
  either turn owner. Any change to session, turn, owner, timer, local/last move
  sequence or highest ACK resets the proof; missing evidence, foreground loss,
  a pristine opening, pending action, PASS/Fusion wait or sequence desync also
  resets it. Only a production-ready ACTIVE board with prior accepted gameplay
  and at least four unchanged samples over 45 seconds dispatches
  `ACTIVE_COMBAT_PROGRESS_STALLED` into the existing farm-lifetime-unbounded
  recovery path. Replaying the real attempt-23 log would trigger at
  `2026-08-27T13:31:43.748Z` after 50.343 seconds, rather than at the 30-minute
  controller timeout. Offline verification is **713/713 PASS**; a restarted UI
  and fresh bounded continuation are still required before Phase 2E.3 PASS.

## Superseded Historical Assumptions

- Dot 64/64 is not a production requirement; CV is not production board source.
- Older PASS-disabled text is historical; bounded authoritative PASS is accepted.
- Early 3/10-action caps are milestones, not current B5 gameplay caps.
- Manual opening move is superseded by exact `MATCH_START` bootstrap.
- Old `BASIC_INTERMEDIATE_FALLBACK_UNDEFINED` behavior is superseded by accepted
  Shield/Health/general safe-resource fallback.

## Next Phase

**Phase 2F.2 is PASS STRONG. Finite BASIC scope is COMPLETE.**

```text
accepted Phase 2E.2 live UI/FarmRunner integration
-> accepted Phase 2E.3 operator UX + exact-pet recovery + 25-match UI soak
-> accepted Phase 2F.1 portable Windows packaging + packaged live validation
-> accepted Phase 2F.2 Release Candidate + Final Acceptance
```

There is no next phase in the current roadmap. Infinite farming, process
relaunch/login, internet recovery, target
rotation, pet-specific skill-card use, mid-combat checkpoint resume, and
navigation from the general game lobby through Chinh Phuc islands remain
outside current scope unless explicitly approved. REASONING remains undefined
and unsupported.

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

## Desktop Compact Layout / Build Label

The Control tab now hides Attachment, Process, Session, pinned pet ID and
pinned pet name. These values remain internal read-only controller/recovery
state and diagnostics evidence; only their redundant widgets were removed.
PlayStyle/Intelligence share one equal-width row, Target matches/Max attempts
share another, and the explanatory pet/preferences subtitles were removed.
The accepted Phase 2F.1 title is `Pokiguard Tool V2 - v1.0.0+15`. PlayStyle and
Intelligence are two equal-width **clusters** on the first row. Target matches
and Max attempts use the same two-cluster 50/50 outer layout. Inside every
cluster, the label keeps its natural width immediately beside the control; the
label and control are never forced to 50/50. ManaPriority is the only cluster on
its following row, so that cluster spans the full row with no empty sibling.
Subsequent pre-MVP tool-code revisions increment only
the `+N` build suffix.

Build `+5` fixes the compact-panel render contract: removing Attachment,
Process and Session widgets must also remove those keys from the Tk update loop.
The runtime poller was still healthy in the incident evidence, but the stale
hidden-key lookup raised `KeyError: 'attachment'` before lifecycle values and
controller button state could render. A regression test now covers this exact
hidden-widget failure mode. Timed UI smoke runs now also fail closed unless they
complete at least one render with zero handled UI errors and stop their poller.

Build `+6` also removes MatchId from both the compact runtime panel and its Tk
update set. Match identity remains internal controller/gameplay evidence only;
the operator UI no longer creates or updates a MatchId widget.

Build `+7` separates gameplay preferences into the second `Preferences` tab.
PlayStyle, Intelligence and ManaPriority use a two-column 30/70 table so all
controls share one left edge. The Control tab keeps only Target matches and Max
attempts from the editable settings, places them inside the FarmRunner control
area, and renders the completed/attempt/W-L-U run report below the buttons.

Build `+8` gives initial keyboard focus to the notebook/tab surface instead of
the first Target matches entry. The limits remain normally mouse-editable, but
opening or initially activating the tool no longer selects that field.

Build `+9` adds background-click defocus without intercepting clicks on Entry,
Combobox, Button, Text or Notebook controls. Start/Resume parses the two limit
StringVars through canonical `DesktopConfig`, hands that immutable config to the
controller, immediately disables the editable settings on acceptance, and
reasserts the accepted Target matches / Max attempts values until the controller
stops. The fields become editable again only after backend controller truth is
inactive.

Build `+10` adds the read-only active-combat progress watchdog described above.
It closes the boss-turn/timer-14 freeze gap without using screenshots or
relaxing any gameplay-input gate.

Build `+11` fixes exact-25 run `4ab9bda9429144f991dd8bdcd6e83956`.
The run completed 11 STRONG WINs, then attempt 12 correctly detected
`DEAD_BOARD_NO_REFRESH`, exited and re-entered exact Starburst `1289` as new
match `M_d624138a`. The recovered MATCH_START was complete (64/64), but the
failed match's frozen raw ACK maximum `53` persisted while current-session
batches were only `3..7`; treating the process-wide maximum as current caused
`ENTRY_TIMEOUT_OPENING_BOARD`. Recovery ACK isolation is now armed only after
the exact owner-free room proves a frozen lobby ACK/local-sequence pair. The
raw value remains visible for audit, while publication may use only the exact
new MATCH_START or batches independently tied to the current BoardWs owner or
current-match ChatMessageDTO. An unexplained ACK advance still fails closed.
The same incident ended in a proven `DETACHED_ROOM_SHELL_CANDIDATE`; failed
recovery fallback now audits one prior re-entry and continues through that
exact-pet/no-owner shell into the existing map-target recovery path instead of
immediately finalizing `RECOVERY_FAILED`. Offline verification is **719/719
PASS** with compileall and diff checks clean.

Build `+12` addresses live run `73b33c680535474fba7031732bd6347f`,
which completed 24/25 STRONG/CONSISTENT WINs. Attempt 25 hit a technical
failure; recovery could not complete in-room after the game reported a lost
room connection, but the existing exact-pet fallback restored Starburst
`1289` and attempt 26 entered combat successfully. That recovered combat then
sent 11 SWAPs but confirmed only 8. Two SWAPs timed out, and the mandatory
SWAP after authoritative idle `2/3` received no response before the game
ejected the player. Every physical SWAP still used the fixed 0.25-second
two-click gap, even while the observed client was running at roughly 3-4 FPS.

There is no verified read-only game field for overlay Ping/FPS and no OCR
dependency is added. The ordinary-input executor now uses auditable adaptive
pacing instead: 0.25 seconds normally, 1.0 second after a proven recovery or
exact room re-entry, and at most 1.5 seconds after an unconfirmed SWAP. Slow
accepted transitions retain degraded pacing; only eight consecutive accepted
SWAPs within the fast threshold decay one level. A late integer server timer
may clamp the delay so the second click retains a 1.25-second delivery margin.
Each `action_sent` records the selected delay, mode, reason and lag score.

The same run also proved that ordinary `COMBAT_TERMINAL_UNPROVEN` ejection can
settle at the exact-pet/no-owner `DETACHED_ROOM_SHELL_CANDIDATE`, not only the
fully loaded `WORLD_BOSS_LIST`. That branch now uses the same centralized
owner-free ejection proof and exact pinned-pet restoration path instead of
finalizing `COMBAT_SAFE_STOP`. Match completion is still not counted, old
combat state is never reused, and ambiguous ownership/target evidence remains
fail-closed. Offline verification is **722/722 PASS** with compileall and diff
checks clean.

Build `+13` diagnoses the two starts in runs
`06b9fa00bcbe43caa37266cd06367bf2` and
`77de198ab03e413694182a11c5099a03`. The first run's dead-board artifact proved
three valid stats actors: local user `1` at `716/1563` Mana, Fusion pet `2`,
and boss `99`; Fusion UI was live and interactable. The old "one non-boss"
heuristic therefore made player/Mana UNKNOWN and suppressed EVOLVE for the
wrong ownership reason. The provider now mirrors the read-only
`Active.LocalActorNumberOrZero` primary chain through
`MatchService.Players[ChatService.Username].actorNumber`, without hard-coding
an actor number.

The second run selected a SWAP at timer 2, spent about 1.46 seconds between the
policy record and completed click pair, then received the exact server reject
`Không phải lượt bạn`. Its logged adaptive delay was the normal 0.25 seconds,
so build `+12` did not cause that rejection. Build `+13` adds a cheap direct
MatchService preflight immediately before SWAP input and cancels the unsent
action if match, turn, owner, timer or local move sequence changed. Response
deadlines now start at the actual input boundary rather than before modal and
coordinate preparation. Offline verification is **725/725 PASS** with
compileall and diff checks clean.

Build `+14` introduces the Phase 2F.1 frozen Windows entry point, local
app-data path boundary, internal production calibration, bundled recovery
resources, one-folder PyInstaller spec and deterministic ZIP build. Packaged
B4/B5 live validation proves bounded completion and UI graceful stop.

Build `+15` fixes the post-graceful-stop button label: the terminal controller
snapshot intentionally retains `graceful_stop_requested=true` as evidence, but
pending text is now rendered only while that controller is active. Final
Phase 2F.1 verification is **740/740 PASS**.

## Source compatibility v1.0.15 — EVOLVE priority and third-idle prevention

Run `9230a17fad904c3a9b38bb69c6113d97` stopped after zero EVOLVE/CAST inputs
and was later ejected. This was not caused by solver choice. Fusion discovery
cached 42 ambiguous heap candidates while the exact Fusion owner allocation
was omitted by a combined two-allocation 16 MiB cap. The provider now scans
the appended Fusion GameObject's exact allocation, validates `_boundPetId`
against current `selectedPetId` (with the documented fallback), and caches
only one uniquely owned live wrapper.

Production Evolution priority now starts after the mandatory opening board
turn and uses the same inclusive one-second action floor. Low-boss-HP finisher
mode and authoritative idle 2/3 still suppress EVOLVE. A SWAP reservation
aborted before any Windows input is now released for fresh recomputation
instead of permanently stopping FarmRun; one displayed second is accepted by
the final direct preflight. Any exact server 2/3 payload independently latches
mandatory SWAP/CAST so a missed/unconfirmed earlier action cannot lead to a
third zero-input turn. Source verification: **778/778 PASS**, compileall PASS,
`git diff --check` clean. Live EVOLVE plus continued combat/recovery remains
the acceptance boundary.

## Source compatibility v1.0.16 — selectable two-click/drag SWAP input

Redux 1.7.4 directly declares `Dot.OnMouseDown`, `Dot.OnMouseUp`,
`firstTouchPosition`, `finalTouchPosition`, `IsValidSwipe`, `MovePieces`, and
the drag-specific turn-timer pause/resume path. The product now exposes
`Board input` in the Preferences tab with `two_click` and `drag`. Existing
preference files without the field migrate to the requested `drag` experiment;
the selected value is validated, persisted, snapshotted at Start/Resume and
forwarded through Desktop controller -> FarmRun -> combat executor.

Drag uses only foreground normal Windows mouse input. It presses at the exact
first tile centre, traverses six bounded points for 0.35 seconds normally
(adaptive up to 1.5 seconds after lag evidence), and releases at the exact
second centre. Window/PID/geometry/focus changes fail closed and LEFTUP is
guaranteed after any emitted LEFTDOWN. Card and UI actions are unchanged.
Action telemetry distinguishes `inputMode`, `dragDurationSeconds` and
`dragSteps`. Source verification: **780/780 PASS**; live drag acceptance is
pending.

## Source compatibility v1.0.17 — quick-flick drag correction

FarmRun `1e9097b2276948a7bdf7c78cc77281fa` live-rejected the initial drag:
the exact legal adjacent centres were emitted over 0.35 seconds/six steps, but
there was no server response, local move sequence stayed zero, and the first
gem remained selected. The Cpp2IL `Dot.OnMouseDown`/`OnMouseUp` body confirms
that swipe validity is based on press/release displacement against
`swipeResit`, not elapsed drag time.

Drag now performs the operator-confirmed gesture shape: a fixed 0.10-second
three-move flick ending 0.35 cell beyond the second centre, still inside the
target cell and Board rectangle. Adaptive lag evidence continues to pace
`two_click`, but never stretches a drag. `dragOvershootPixels` is included in
SWAP telemetry; all foreground/window/geometry guards and unconditional
LEFTUP cleanup remain active. Offline verification is **782/782 PASS**;
fresh live drag acceptance remains required.

## Source compatibility v1.0.18 — calculable safe-resource boundary

Run `67bb91cf613345a6ba1b806cd834bb57` proved the `two_click` path itself was
healthy (five acknowledged SWAPs), but exposed a policy defect. Turn 11's Rage
candidate was `calculable=false`, introduced three UNKNOWN refill cells, and
still carried `safe=true`; live play showed its collapse forming a Sword
opportunity for the boss. A top-board outcome with unknown refill cannot be
made safe by the absence of a Sword in one bounded hypothetical check.

Normal safe-resource candidates now require a calculable direct clear at
screen row 3 or lower in addition to the existing direct/indirect Sword reply,
UNKNOWN and collapse-support gates. Sword priority and mandatory minimum-risk
fallback behavior are unchanged. Every policy event now stores the exact 8x8
screen-oriented board plus all compact legal-candidate evaluations, preventing
managed-object reclamation from erasing the evidence needed for replay.
The UNKNOWN gate now also covers the operator-reconstructed one-row collapse:
when a refill slot appears beside a known Sword, the simulator tests moving
that existing Sword into the slot, because a non-Sword refill can expose a
match-3 even when treating the refill itself as Sword would auto-clear. The
exact topology is locked by regression coverage. Offline verification is
**785/785 PASS**; fresh live acceptance remains required.

## Source compatibility v1.0.19 — duplicate local-turn full scan removed

The same run's PASS handoff explains why a nominal 14-second turn reached
policy with one second left. A 6.35-second PASS scan had already decoded and
offered the exact current-match board for `srvSeq=19`. When direct runtime
subsequently sampled local turn 9 at 13 seconds with ACK 19, the monitor failed
to recognize that prevalidated but not-yet-ACK-attested provider snapshot and
performed a redundant 7.56-second broad heap scan. Provider stability work
then consumed the remaining margin.

Provider diagnostics now expose per-batch transport/runtime-heap attestation.
Those exact sequences suppress only duplicate heap discovery; they do not
bypass the provider's independent exact-ACK, latest-board, stability,
actionability or lifecycle gates. Unattested candidates remain excluded.
Future `pass_message_scan` events include scan reason, region count and bytes.
Offline verification is **786/786 PASS**; fresh live timing acceptance remains
required.

## Source compatibility v1.0.20 — owner-first card cache and bounded transport refresh

The current `reverse/redux_compat` declarations confirm the direct read-only
ownership roots used by the provider: `Board.selectedCards +0x318`,
`Board.cardsInHand +0x320`, `CardUI.cardData/board/active` at
`+0x20/+0x30/+0x38`, `MatchService.PendingCombat +0x188`, and
`BoardWsApplier._pendingBatches +0x50`. They do not provide a direct singleton
for CardUI or BoardWsApplier, so no pointer or owner was guessed.

The mandatory opening local turn now performs no optional card-list or card-UI
discovery. It remains reserved for the authoritative opening board and SWAP.
On the immediately following boss turn, the provider first reads the two
current Board-owned lists, decodes each immutable `CardData` once per combat,
and scans the exact ordinary-card and Fusion GameObject allocation envelopes
separately. Only a failed owner lookup can enter the rotating <=8 MiB and then
8--16 MiB compatibility fallbacks. The former first-boss-turn process-wide
CardUI/FusionUI scan has been removed.

Once a CardUI is resolved, each poll revalidates only its current Board/Active
ownership, Unity native/Button pointers, interactable bit, used/pending fields
and current participant resources. Card strings, costs and conditions come
from the per-combat immutable CardData cache. A proven current selected-card
list with no Attack card suppresses pointless Attack UI retries; unknown or
conflicting lobby evidence keeps discovery enabled. Fusion success clears the
obsolete Fusion wrapper, re-reads exact strip cardinality/order and reopens
bounded ordinary-card discovery only if the cached wrapper no longer validates.

Periodic transport maintenance no longer performs a broad heap traversal based
only on a timer. It scans learned allocator neighbours on an opponent turn;
full scans remain limited to explicit force, loss of every live learned region,
or one exact unresolved ACK-gap escalation. Board publication still requires
the existing exact ACK, latest-board, ownership, stability, lifecycle and
actionability gates. Offline verification is **788/788 PASS**; a fresh live run
must confirm the expected boss-turn cache discovery and local-turn latency.

## Source compatibility v1.0.21 — direct card authority and match energy accounting

The five-match live run
`logs/farm_runs/3b5672d3e1be4a7193c15c6d84ad3710` confirmed that board acquisition
and SWAP timing are now fast and stable. It also isolated the remaining card
delay: turns with 210--371 mana repeatedly logged
`STEP_1_EVOLVE: live FusionCardUI is not proven interactable`, even though the
same snapshots already proved one selected Attack `CardData`, two
`cardsInHand` entries, Fusion slot 0, Attack slot 1, `FusionEnabled=true`, an
unused selected pet, and the exact 160 Fusion cost. One match did not resolve
an Attack `CardUI` wrapper at all. This was a wrapper-discovery bottleneck, not
a policy-order defect.

After the opening board-only local turn, the common standard-pet path now uses
the current Board-owned `selectedCards +0x318` and `cardsInHand +0x320` lists,
immutable `CardData`, and direct MatchService Fusion fields as the action
authority. If a live CardUI/FusionCardUI exists it remains preferred and its
dynamic Button state wins. If it is absent, exact list order/cardinality and a
standard strip without a pet-specific skill can authorize the known slot; the
foreground controller must still capture the client and prove the current
card tile immediately before a normal click. Direct ordinary-card fallback is
limited to `cooldownTurns == 0`; other cooldowns remain fail-closed. The former
owner/bounded/extended wrapper scans are skipped when this direct strip is
already exact, while opening-turn board priority is unchanged.

Farm telemetry already deduplicated observations by exact
`(session, TurnNumber, LOCAL/BOSS)`. That local count is now explicitly stored
as `energyUsed` for every attempt, emitted as `match_turn_energy_counted`, and
shown in the Control tab per completed match (latest eight) with the run total.
EVOLVE plus SWAP in one local turn counts once. Offline verification is
**793/793 PASS**; live acceptance should confirm that turn 2+ evolves before
Sword/SWAP whenever mana and Fusion conditions allow, and that the displayed
per-match energy matches the game flow.

## Source compatibility v1.0.22 — live current turn and CAST telemetry repair

FarmRun `logs/farm_runs/2f363b504c6742acacc882e3707e2acf`
completed 5/5 STRONG, CONSISTENT wins in five attempts. It had zero technical
abort, recovery, safe-stop, provider read error, DTO rejection, stale/latest
ambiguity, opening rejection, or terminal-result conflict. Local turn/energy
counts were 19, 14, 9, 11 and 22, total 75 (average 15). EVOLVE ran nine times:
four successes and five server-confirmed/timeout failures. All extended card,
Fusion and owner wrapper scans remained zero on the direct standard strip.

Seven CAST inputs were sent. The prior summary recorded zero accepted because
the direct CardData authority intentionally has no dynamic CardUI wrapper.
Five nonterminal CASTs nevertheless have exact evidence in the log: player
mana fell by the runtime 160 cost and the next authoritative turn belonged to
the boss. Acceptance now recognizes this dual proof only for
`BOARD_SELECTED_CARDDATA_CARD_STRIP`; mana or turn alone, an unexpected cost,
or a different authority still remains unconfirmed. This changes telemetry and
idle-reset correlation, not the physical click or policy order.

The Control tab now separates completed-match energy, current-match local
turn/energy, and total energy onto three lines. Current progress is projected
once per already-deduplicated game-owned TurnNumber and performs no additional
RAM scan, capture, solver evaluation or input. Full offline verification is
**796/796 PASS**. A subsequent live run is needed only to confirm the new UI
projection and repaired `castAccepted` counter; the underlying five-match farm
run itself already completed cleanly.

## Source compatibility v1.0.23 — fast-turn observer hotfix

The first live start on v1.0.22, FarmRun
`logs/farm_runs/1e5ec6948f734889b29654122f0ecb17`, proved the opening
64/64 board and sent one opening SWAP, then stopped with
`FARM_RUN_INTERNAL_INVARIANT`. The exact exception was
`TurnTransitionTracker.observe_runtime() got an unexpected keyword argument
'progress_observer'`. This was a local callback-routing regression introduced
by live turn projection, not a game, board, solver, lifecycle, or input-layout
failure.

The fast MatchService path now routes status projection through the same
deduplicated turn-counter helper as normal polling and leaves
`TurnTransitionTracker.observe_runtime` unchanged. A dedicated regression test
executes this exact helper boundary. Source version is `v1.0.23`; full offline
verification is **797/797 PASS**. A fresh live start is required to confirm the
hotfix past the opening action.
