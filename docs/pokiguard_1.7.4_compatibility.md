# Pokiguard 1.7.4 IL2CPP compatibility

## Phase 2 b2 gameplay repair — 2026-09-11

Phase 2 default gameplay is reopened after two user live tests; the repair is
waiting for a new live retest and is not committed, pushed or phase-closed.
The exact installed GameAssembly and metadata hashes still match the b2 reverse
profile below, so no offset was changed speculatively.

Evidence and resulting fixes:

- `logs/farm_runs/e354ad0b878f4959838b3e07c4fbdcf0` proves the provider
  exposed `manaCost=120`, BASIC proposed Evolution with player Mana 154, input
  charged 120, and the exact `MATCH_FUSION_RES` returned `success=false`.
  Therefore b2 Evolution cost is already runtime-driven at 120; the failed
  evolution was an authoritative game outcome, not a retained 160 threshold.
- `logs/farm_runs/2b7ce245380c45848285ad087ef86ea7` records five acknowledged
  swaps, two formal PASS decisions, then `LOCAL_TURN_ACTION_DEADLINE`. At the
  final local turn the ACK advanced to 50 while the last published board was
  sequence 47. No third policy PASS was emitted; the missing input nevertheless
  became the server's third idle and caused removal from the room.
- The same run's sequence-40/45 board has 12 legal moves. The Mana move
  `(5,0)<->(5,1)` has zero direct, indirect and UNKNOWN Sword reply, but the old
  broad support heuristic reported `collapse_support_hazard=2` and vetoed it.
  Support overlap now ranks danger only; the exact board is a regression
  fixture and BASIC selects that Mana SWAP instead of PASS.
- A dispatcher callback can retain valid `ChatMessageDTO.matchPayload.board`
  even when the raw JSON shape is rejected. The tap now decodes that exact DTO
  fallback. A healthy dispatcher no longer suppresses recovery when the exact
  current `(match, turn, ACK)` board is absent; each gap is attempted once.
- Follow-up run `bef23282eac3461bb6ca629e36f63537` emitted zero formal PASS
  actions but missed input on several local turns. It performed eleven
  `LOCAL_TURN_ACK_GAP_FULL_ESCALATION` scans of 1.28--1.31 GiB, each taking
  7.02--7.18 seconds. This proves the apparent PASS loop was a self-amplifying
  capture stall: the broad recovery starved the callback tap and then missed
  the next board. Active combat now disallows full-heap scans and caps the one
  rotating learned-region fallback at 64 MiB per new ACK; the dispatcher tap
  target interval is 1 ms.
- Latest run `ab7e9331f5774a48b2da8549e2f7e77a` made 44,956 dispatcher
  direct-root polls, of which 44,951 were stable, but retained only four move
  boards. It observed six local turns and emitted only two policy decisions;
  therefore the reported idle/Sword skip occurred before the solver. The same
  log repeated 1,247 failed legacy payload decodes against a small set of old
  `ChatMessageDTO` allocations.
- The b2 mechanism behind the miss is now proven. Before enqueue,
  `ChatService.OnWebSocketMessage` calls `MatchPayloadPreparser.Prepare`, whose
  `PrepareBoard` stores a typed board at `ChatMessageDTO.preBoard +0x3C8` and
  marks `preBoardReady +0x3D0`. Production now reads that exact class-checked
  owner, samples its identity and owner fields before/after all 64 cells, and
  binds the board to immutable raw `matchPayload.srvSeq`. Normal exact ACK and
  stability gates remain mandatory. Legacy DTO failures are capped at two
  attempts per allocation.
- New run `c756bbc90fc64366802c7df3ade5f4ba` shows the remaining boundary:
  29,179 tap polls retained sequence-6 and sequence-10 boss boards but missed
  the sequence-14 callback completely. ACK advanced to 14 while the published
  board stayed at 10; the visible Sword turn therefore reached neither the
  decoder nor the policy. Successful captured DTOs had `preBoardReady=1`, so
  this is callback lifetime loss rather than a `preBoard` layout failure.
- The tap now samples the b2 typed current-owner roots at the same 1 ms cadence:
  `MatchService.PendingCombat +0x1A8` and the provider-validated
  `BoardWsApplier._pendingBatches +0x60`. MatchId/pointer and queue
  owner/version/content are sampled before and after each strict 64-cell read.
  Captured batches remain unusable until the exact ACK and all existing
  stability/actionability checks pass.
- That run also recorded 51 opening Rage proposals canceled before input even
  though session, `srvSeq` and board hash were unchanged. The fast opening
  preflight was replacing one valid pristine LastMove sentinel with another
  (`None`/`-1`) and then treating the representation change as gameplay. It now
  preserves the proven cached sentinel while separately validating that both
  reads remain pristine.
- The same run proves card scanning was not responsible:
  `extended_card_ui_scans=0`, `card_owner_anchor_scans=0` and
  `fusion_owner_anchor_scans=0`. Board transport and optional card discovery
  remain separate, with card discovery deferred past the opening action and
  cached owner/loadout evidence reused.
- The user's 15:02:48 screenshot is now a replay fixture. At 135 Mana with the
  runtime Fusion cost set to 120, BASIC chooses Evolution. If Fusion is already
  complete, it swaps screen `(0,1)<->(1,1)` and collects Sword-3 at Step 2.
  Thus the captured visible board is not a PASS board; end-to-end live capture
  after the `preBoard` repair still awaits retest.
- The user's 15:56:30 screenshot is a second replay fixture. With Fusion
  already used, BASIC chooses Step 2 Sword and screen swap
  `(0,4)<->(0,5)`, producing Sword-3. No formal PASS was logged for that live
  turn because its board was never published.
- Reverse b2 proves `Board.IsPlayerAllowedToMove` calls
  `TurnAnnouncer.IsBlockingInput`. `TurnAnnouncer` TypeInfo RVA is `0x2DDAE68`,
  `_blocking` is static-fields `+0x80`, `_blockDeadline` is `+0x84`, and the
  hard block constant is 3 seconds. The provider reads `_blocking` through the
  verified static-field chain and fails closed while it is true; it does not
  invent a sleep or call Unity time.

The first four findings come from immutable run logs and deterministic replay;
the turn-delay finding comes from `TurnAnnouncer.cs`, `Board.cs`, exact TypeInfo
mapping in `cpp/appdata/il2cpp-types-ptr.h`, and read-only disassembly of the
hash-gated installed DLL. Production behavior still requires the user's live
retest before Phase 2 can be accepted again. Final offline verification is
**1160/1160 tests PASS**; `compileall` and `git diff --check` pass.

## Current b2 build — supersedes the historical profile below

As of 2026-09-07 the active supported build is the exact 53,603,328-byte
`GameAssembly.dll` with SHA-256
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`.
Its metadata is 15,394,348 bytes, SHA-256
`F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`,
magic `0xFAB11BAF`, header version 110. The exact reverse source is
`reverse/reverse_1.7.4-b2`.

Current TypeInfo RVAs and shifted Board/MatchService/CardUI/QTE/boss-room
layouts are summarized in [il2cpp_symbols.md](il2cpp_symbols.md). A live
read-only smoke attached to PID 26452/x64 and proved `LOBBY -> BOSS_LOBBY /
CHINH_PHUC_ROOM`, clean room ownership, three selected cards and one Attack
card, with zero input. Full source validation is **1028/1028 PASS**. The C67
profile and the detailed history below are retained only as historical evidence
and are not allowlisted by the current single-profile runtime.

Current status (2026-09-11): the prior source integration and read-only runtime
evidence remain valid, but Phase 2 default gameplay has a newly repaired live
regression and is awaiting user retest. Phase 3 reports below remain historical
technical evidence; they do not close this current Phase 2 repair.

## Exact input build

| File | Size | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 51,685,888 | `C67FF9CC3BB280CC63B3B9BE24D45ED038937F70A95E13075D361C8DDDE95A78` |
| `global-metadata.dat` | 14,955,968 | `F96A095E22A1348B3AC3B850F236ECD836D3302E4EC12DD15DE8E8372228E598` |

The metadata header is `0xFAB11BAF`, version `110`. The data path is
`Pokiguard-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat`.

## Reverse evidence

Cpp2IL `2022.1.0-pre-release.21` was rejected because it only supports
metadata versions through 106. No output from that failed attempt was used.

Il2CppInspectorRedux `2026.2+335c379` parsed metadata 110 and the x64 PE, found
`CodeRegistration` at preferred VA `0x1826FE0E0` and
`MetadataRegistration` at preferred VA `0x182727FF0`, and generated:

- `reverse/pokiguard_1.7.4/il2cppinspector/types.cs`
- `reverse/pokiguard_1.7.4/il2cppinspector/metadata.json`

Both generated files are local evidence. The JSON is over 100 MiB and must not
be pushed to GitHub without an appropriate large-file storage policy.

## Verified type-info RVAs

All addresses below are module-relative RVAs. Runtime resolution remains
`GameAssembly.base + RVA`; no ASLR-dependent absolute address is stored.

| Type | RVA |
|---|---:|
| `Board` | `0x2BF22A0` |
| `Active` | `0x2BE5468` |
| `ManagerMatch` | `0x2C53818` |
| `MatchService` | `0x2C54F68` |
| `ChatService` | `0x2BF8980` |
| `ChatMessageDTO` | `0x2BF88D8` |
| `HubSuspendManager` | `0x2C2A828` |
| `MatchHost` | `0x2C54C30` |
| `MatchSceneLoader` | `0x2C54EC0` |
| `Dot` | `0x2C15858` |
| `WsCombatBatch` | `0x2C2FD80` |
| `BoardWsApplier` | `0x2BF2540` |
| `CardUI` | `0x2BF7480` |
| `FusionCardUI` | `0x2C21E08` |
| `Active.PlayerStats` | `0x2C40E28` |
| `ManagerQuangTruong` | `0x2C53AC8` |
| `ManagerRoom` | `0x2C53C20` |
| `WsRoomService` | `0x2C300F0` |

Newtonsoft anchors are `JArray=0x2C47B68`, `JObject=0x2C47D68`,
`JProperty=0x2C47EC0`, and `JValue=0x2C48578`.

## Important layout changes

- `Board.allDots=0x150`, `active=0x168`, `isCascadeRunning=0x180`,
  `isBoardReady=0x368`, `selectedCards=0x318`, `cardsInHand=0x320`.
- `MatchService._TurnTimeRemainingSec=0x120`, `_PendingCombat=0x188`,
  `_ackedSeqs=0x198`, `_matchOver=0x1CA`, and last-move fields begin at
  `0x1D8`.
- `ManagerRoom._IsOpeningRoomFlow=0x130`; `RoomDTO.cards=0x58`.
- `ManagerQuangTruong.panelBoss=0x108`, `panelChinhPhuc=0x2B0`, and
  `_managerBoss=0x3A0`.

The full declarations and exact field types remain in `types.cs`. Generic
collection/object headers that did not change retain their previous validated
layout.

## Runtime validation

A read-only live probe resolved the configured executable exactly, attached to
the x64 process, resolved the new type-info slots, and constructed the memory
provider successfully. The observed state outside a proven boss room was:

- `game_detected=True`
- `attached=True`
- `lifecycle=UNKNOWN`
- `provider_reason=lifecycle_signals_missing_or_disagree`

This proves process attachment and compatibility initialization only. Board,
card, boss-lobby and autonomous gameplay behavior on 1.7.4 remain pending live
validation. Start must remain disabled until the runtime proves exact
`BOSS_LOBBY`.

The complete source regression suite is **759/759 PASS**. The desktop UI was
then restarted with the persisted exact executable path and reported
`gameDetected=true`, `attached=true`, `health=OK` without dispatching Start or
Resume.

## Redux compatibility cross-check

The later split dump under `reverse/redux_compat` was compared directly with
the original generated `types.cs`. The exact EXE, GameAssembly and metadata
hashes remain unchanged. The boss-room layouts also agree, including:

- `ManagerQuangTruong._managerBoss=0x3A0`;
- `ManagerRoom.roomData=0x100`, `selectedCards=0x108`, and
  `_IsOpeningRoomFlow=0x130`;
- `WsRoomService.CurrentRoomId=0x10`, `CurrentRoomType=0x18`,
  `OwnerUsername=0x20`, and `Properties=0x38`;
- `RoomDTO.cards=0x58`.

Therefore no RVA or field offset was changed speculatively. The observed room
failure came from lifecycle gating: uninitialized static combat classes can
leave their static-field pointers absent, producing `UNKNOWN` before the room
reader ran. Version `v1.0.5` checks the exact room graph in that state and
promotes only a fully clean ChinhPhuc room with no contradictory combat signal
or read error. Stale `Active`/`ManagerMatch` singleton references alone do not
count as live combat after scene teardown; a Board, rig, transition or suspended
hub still blocks promotion.

## Unity class-header correction

A live bounded inspection of the exact class headers subsequently proved that
Unity 6000.7.0a4 stores `Il2CppClass.static_fields` at `+0x98`, not the older
runtime's `+0xB8`. For `ManagerQuangTruong`, `ManagerRoom`, and
`WsRoomService`, `+0x98` pointed to readable static-field blocks whose first
singleton object pointed back to the expected class; `+0xB8` was null in all
three cases. Version `v1.0.6` uses the verified `+0x98` layout globally.

After correction, a read-only live probe reported:

- `game_detected=True`, `attached=True`, PID `22608`, x64;
- `lifecycle=BOSS_LOBBY`;
- target `1289 / Starburst`;
- branch `CHINH_PHUC_ROOM`, room `Coop_788342`.

## Unity 1.7.4 viewport compatibility

The first live Start attempt on the updated client stopped before any entry or
gameplay click with `ATTACK_CARD_TOGGLE_UNPROVEN`. Runtime memory had already
proved one selected Attack card. The saved 1280x720 client capture proved that
the game presents a centered 1280x640 (2:1) viewport with 40-pixel black bars.
The old locator searched x=602..678; the live Attack card occupied x=538..596.
The initial correction correctly established a height-scaled, left-anchored
card/UI canvas, but then incorrectly reused that transform for Board cells. The
later combat evidence below proves that `DotsArea` has a separate horizontal
layout.

Version `v1.0.7` prepares the game at its native 1280x640 client size, removing
the bars. A shared fail-closed transform handles the lobby Attack card, combat
Evolution/Attack cards, board cells, leave recovery and postmatch confirmation.
The current Start button remains pixel-located rather than hard-coded. The
pre-fix artifact now proves the Attack card at confidence 0.970 and the Start
control at confidence 0.907; no game input was used for this validation.

## Live combat lifecycle polarity

The first successful 1.7.4 entry created match `M_b727b2f1`, produced a live
MatchHost rig in `RUNNING`, a ready 64-cell Board, matching
Board/Active/ManagerMatch ownership and complete server snapshots. Nevertheless
`HubSuspendManager.IsSuspended` and `ManagerMatch.isBossBattle` both remained
false. The former was still an old positive-polarity lifecycle gate, so the
provider stayed `UNKNOWN`, never issued a session key, and sent zero gameplay
inputs until `ENTRY_TIMEOUT_NEW_SESSION`.

Both fields and offsets match the Redux declarations (`HubSuspendManager` static
`+0x08`, `ManagerMatch` instance `+0x138`), making this a changed runtime
semantic rather than an offset guess. Version `v1.0.8` keeps Hub suspension as
required readable telemetry but accepts either boolean polarity. ACTIVE still
requires RUNNING MatchHost, live native rig, stable scene flags, readable Hub
state, exact Board/Active/ManagerMatch ownership, current match ID, ready Board,
and no terminal flag. `ManagerMatch.isBossBattle` remains telemetry; boss
identity continues to come from the authoritative participant/room evidence.

## Native 2:1 horizontal-layout correction

The first 1.7.4 gameplay attempt, FarmRun
`d103ea509fb740b188df524283e61224`, provides exact paired evidence:

- the authoritative 64-cell `MATCH_START` board made solver move
  `(screen row 0, col 7) <-> (row 1, col 7)` a legal three-Shield match;
- `action_sent` logged client `x=732` for both endpoints;
- the saved 1280x640 opening frame places the rightmost board column near
  client `x=815`, while `x=732` is around column 5;
- the server did not acknowledge the intended swap and the user observed a
  non-match click.

Therefore board recognition and solver legality were correct; sharing the
card/UI horizontal transform with the combat Board was wrong. Version `v1.0.9`
keeps the evidenced height-scaled, left-anchored transform for card, lobby,
recovery and postmatch controls, while `DotsArea` input preserves full-client
normalized x coordinates. The same move now maps to client `x=823`, within the
observed column-7 tile. Offline replay of the saved lobby frame still proves
the Attack card and Start control after this separation. A dedicated regression
test and the full **767/767** source suite pass. Live retry is still pending.

## Full DotsArea calibration correction

FarmRun `2c55da2623874fda9f95b3eea0e6b742` was started from the Python UI process
that was already running before `v1.0.9`, so its loaded modules still used the
old transform and V1-era vertical calibration. It selected the authoritative
legal move `(screen row 6,col 5)<->(row 7,col 5)` but logged client points
`(638,371)<->(638,417)`. The saved 1280x640 opening frame proves the relevant
tile centres near `(714,406)<->(714,456)` and the complete DotsArea boundaries
at approximately `x=438..840`, `y=79..481`.

Version `v1.0.10` therefore uses the live-derived Board-only calibration
`first=(.3620,.1625)`, `step=(.0393,.0787)`. It maps that same move to
`(714,405)<->(714,455)` and the earlier column-7 move to `x=814`. The log proves
that the failed input used wrong cells, not that 0.25-second pacing was too
fast: there was no swap response/durable local move sequence, and turn 2 arrived
only later. Normal pacing remains unchanged until a correct-coordinate retry
provides evidence. Offline lobby replay still proves Attack/Start, and the full
source suite is **768/768 PASS**. Live retry requires a newly started UI process.

## Correct-coordinate input sampling correction

A genuinely restarted `v1.0.10` retry, FarmRun
`8a57d4f5b6ec4a37bd45504e841574a0`, removed the remaining coordinate
ambiguity. The authoritative board selected
`(screen row 2,col 0)<->(row 2,col 1)`; the saved frame shows Fire and Sword at
exact client centres `(462,204)` and `(513,204)`, and moving that Sword left
forms the visible three-Sword column. The executor sent both of those exact
points, but the server exposed no attributable response or durable local move
sequence. The later authoritative `MATCH_AFK_WARN idle_count=1` proves that
the first turn was skipped rather than swapped.

The remaining local boundary is therefore delivery sampling, not board
recognition, solver legality, row orientation, or DotsArea calibration. Reverse
output for 1.7.4 confirms that `Dot` still consumes legacy `OnMouseDown` /
`OnMouseUp`, tracks frame-held mouse state, and supports tap selection through
`AttemptTapSelectOrSwap`. Version `v1.0.11` preserves that supported two-tap
flow but makes it frame-robust: 60 ms cursor-settle before each tap, 75 ms
mouse-button hold, and 350 ms normal inter-tap separation. All timings are now
included in `action_sent` and the farm input ledger. Adaptive degraded-client
pacing remains layered above the 350 ms normal baseline. Live acceptance still
requires one newly started-process retry with a durable SWAP acknowledgement.

## Current postmatch overlay

The restarted `v1.0.11` run `4966336390a74090807f5d28c942a6b1` completed one
STRONG/CONSISTENT WIN. Its first SWAP and ten subsequent SWAPs were durably
acknowledged, proving that the corrected DotsArea calibration and frame-robust
two-tap input deliver successfully. The only terminal failure was
`POSTMATCH_UI_AMBIGUOUS`; no postmatch click was sent.

The saved 1280x640 terminal frame proves a new 1.7.4 layout: a full-width orange
result banner and a single blue `Dong y` button. The old locator required a
large blue panel and orange button, so rejecting this screen was expected and
fail-closed. Version `v1.0.12` recognizes the new layout through both anchors
together while retaining the legacy path. Exact replay finds the blue control
at normalized `(0.5, 0.90078125)` and the rolling three-frame proof reports zero
drift. Authoritative `POSTMATCH`, final provider revalidation and foreground
proof remain mandatory outside the visual locator. The complete source suite is
**770/770 PASS**; live confirmation requires a newly started `v1.0.12` process.

## Combat-card strip uses the complete viewport

Run `76fc70afe4fe42d4880d0421099942b6` completed five consistent WINs and thus
live-validates the current postmatch overlay. It also logged nine CAST inputs
with zero accepted CASTs. Card memory and policy were correct: Attack ID `4`,
cost `160`, slot `1/2`, interactable/affordable, including finisher decisions at
boss HP `14163` and `22350`. The emitted point `x=0.470222` was the Fusion card,
not the visible Attack card at `x=0.529`.

The error was a coordinate-space mismatch. The dynamic two-slot calculation
correctly produced reference `x=0.529`, then the left-anchored 16:9 lobby
transform remapped it onto Fusion. Corresponding 160-Mana deductions and the
eventual max-HP/max-Mana increase prove the wrong card was activated. Version
`v1.0.13` maps combat-card regions and click points through the complete active
viewport while preserving the separate lobby, recovery, modal and Board paths.
The native 1280x640 regression locks Fusion `x=0.471` and Attack `x=0.529`.
Offline verification is **770/770 PASS**. One live EVOLVE and one live accepted
CAST remain the bounded acceptance boundary.

## Split managed-allocation combat-card discovery

Run `30d14369ec9e4bd3aab1f6c7df9e685e` entered with one selected Attack card,
and the visible combat strip contained Fusion plus Attack, but all 18 published
local turns reported `cardCount=0`. The provider performed four extended
CardUI scans (50,004,122 bytes) and three direct `cardsInHand` owner scans
without resolving a current Attack CardUI. Consequently the low-boss rule
correctly disabled EVOLVE below 30,000 HP but could not propose CAST because no
live, interactable Attack CardUI had passed validation.

The Redux metadata remains unchanged and exact:

- `Board.selectedCards : List<CardData>` at `+0x318`;
- `Board.cardsInHand : List<GameObject>` at `+0x320`;
- `CardUI.cardData` at `+0x20`, `btn` at `+0x28`, `board` at `+0x30`, and
  `active` at `+0x38`.

A read-only post-run `VirtualQueryEx` audit found the two current
`cardsInHand` GameObjects in two committed regions totalling 0.273 MiB. Two
objects with the exact CardUI class pointer were outside those regions but
inside the same OS `AllocationBase`; the complete writable allocation group
was 6.117 MiB. Game teardown had already cleared their owner fields, so the
existing strict validator correctly rejected them rather than promoting stale
UI.

Source `v1.0.14` retains `MEMORY_BASIC_INFORMATION.AllocationBase` and expands
only a current `Board.cardsInHand` anchor to the other private writable regions
of that exact allocation. The expansion is capped at 16 MiB; larger or missing
allocation metadata falls back to the original direct regions. Every hit must
still match the exact CardUI class, current Board and Active owners, readable
Unity native object/Button, CardData layout, and `Button.interactable` before
it can produce input. This is neither an adjacent-address guess nor a whole-RAM
scan. Offline verification is **774/774 PASS**; one live EVOLVE and one live
accepted CAST remain required.

## v1.0.15 EVOLVE ownership and idle-2 correction

Live run `9230a17fad904c3a9b38bb69c6113d97` proved that policy reached Step 1
with Mana 224--364 but published no actionable Fusion UI. The two current
`Board.cardsInHand` GameObjects occupied separate OS allocations of about
12.5 MiB each; their combined allocation envelope exceeded the 16 MiB bound,
so the prior union scan fell back to direct GameObject regions. The Fusion
allocation itself contained exact `FusionCardUI` candidates, including a
wrapper whose `_boundPetId` matched current `MatchService.selectedPetId=1845`.

`v1.0.15` now selects the appended Fusion GameObject's exact AllocationBase,
filters live class/native/Button candidates by the current selected-pet ID,
and caches only a unique result. Ambiguous broad-scan candidates no longer
disable later owner-anchor retries. Production Step 1 also follows the user
rule from the second local turn: when Evolution priority is selected and the
runtime cost is affordable, the inclusive action floor is one displayed
second rather than the former ten-second policy delay. Low-boss-HP mode and
authoritative idle 2/3 remain explicit exceptions.

The same run exposed a separate ejection path. A final SWAP preflight at one
second cancelled an unsent farm permit as a permanent capability failure; the
next turn was denied while the server had already emitted 2/3. The direct
preflight is now inclusive at one second, unsent changed-state permits can be
released and recomputed without stopping the farm, and every exact 2/3 server
payload latches mandatory SWAP/CAST even outside an intentional PASS wait.
Offline verification is **778/778 PASS**, with compileall and diff checks
clean. Fresh live acceptance is still required.

## v1.0.16 selectable board gesture and dropped-click diagnosis

The Redux `Dot` declaration confirms that board input supports both tap and
swipe semantics. It contains `OnMouseDown`, `OnMouseUp`,
`firstTouchPosition`, `finalTouchPosition`, `IsValidSwipe`, `MovePieces`, and
`ExecuteSwapToNeighbor`; it also has explicit
`TryPauseTurnTimerForDrag`/`TryResumeTurnTimerAfterDrag` methods. This is direct
evidence that an adjacent press-drag-release gesture is a supported normal game
input path, not an invented direct method call.

FarmRun `9230a17fad904c3a9b38bb69c6113d97` rules out a systematic coordinate
offset: the same full-viewport tile-centre mapping produced multiple
server-acknowledged SWAPs with the normal 0.35-second pair, while one later
pair was unconfirmed and produced an authoritative AFK `1/3`. The cursor ending
on gem 2 while gem 1 remains selected is consistent with the first click being
sampled and the second 75-ms pulse being missed between Unity render frames.
The fact that later degraded 1.5-second pairs were accepted also points to
delivery/frame timing rather than a board-read or solver-coordinate fault.

Source `v1.0.16` adds an immutable per-run `board_input_mode` preference:
`two_click` retains the accepted path, while `drag` holds LEFTDOWN on gem 1,
crosses six interpolated points, and releases exactly at gem 2. Normal drag
duration is 0.35 seconds and uses the existing delivery-health signal to grow
up to 1.5 seconds after proven lag. HWND, PID, client geometry and foreground
are revalidated throughout; once LEFTDOWN is emitted, LEFTUP is unconditional
even on a partial failure. Cards, lobby controls, recovery controls and result
modals remain ordinary single clicks. Every SWAP logs `inputMode`, drag
duration/steps, and the existing pacing evidence. Offline verification is
**780/780 PASS**; a fresh live run is required to compare drag acceptance.

## v1.0.17 fast-flick drag correction

The first live drag trial, FarmRun
`1e9097b2276948a7bdf7c78cc77281fa`, emitted the intended legal move
`(4,0)<->(4,1)` at exact mapped centres `(462,304)<->(513,304)`. Telemetry
proved `inputMode=drag`, 0.35 seconds and six steps, but the action received no
server response and the local move sequence stayed at zero. The operator also
observed that gem 1 remained selected. This rules out a different solver move
or an unlogged coordinate substitution; the slow drag itself failed live.

The older Cpp2IL method body supplies supporting behavioral evidence for the
Redux declarations: `Dot.OnMouseDown` stores `firstTouchPosition`, while
`Dot.OnMouseUp` stores `finalTouchPosition` and compares the absolute X/Y
displacement to instance `swipeResit`. A displacement over that threshold
calls `CalculateAngle`/`MovePieces`; elapsed drag time is not part of
`IsValidSwipe`. This does not supply or justify a guessed runtime threshold.

Source `v1.0.17` therefore models the operator's accepted manual gesture: a
fixed 0.10-second three-move flick, releasing 0.35 cell beyond the target
centre in the same direction. The release remains within the target cell and
validated Board rectangle for every edge direction. Adaptive two-click pacing
cannot stretch this drag after lag evidence. Telemetry adds
`dragOvershootPixels`; foreground, HWND/PID, geometry revalidation and
unconditional LEFTUP remain unchanged. Offline verification is **782/782
PASS**; fresh live acceptance is required.

## v1.0.18 calculable-resource safety correction

FarmRun `67bb91cf613345a6ba1b806cd834bb57` separates input delivery from
policy behavior. Five `two_click` SWAPs were server-acknowledged without a
partial input or rejection. At turn 11, however, policy selected Rage
`(1,2)<->(1,3)` and logged it as `safe=true` even though the same candidate
reported `calculable=false` and three UNKNOWN refill cells. The operator then
observed the collapse leave a Sword match-3 opportunity for the boss.

The defect was in the safety predicate: zero replies in the partially known
post-collapse board, plus zero single-UNKNOWN Sword completions, could promote
a top-area clear to safe. That absence is not positive safety evidence. Source
`v1.0.18` requires a normal safe resource move's direct clear to begin at
screen row 3 or lower. Step 2 deterministic Sword collection remains separate,
and a mandatory turn with no safe choice retains the minimum-risk fallback.

The operator then reconstructed the relevant topology: known Swords at
one-based `(row 1,col 1)`, `(row 1,col 2)`, `(row 3,col 2)` and
`(row 3,col 3)` surrounded a row-2 Rage clear. Clearing row 2 dropped the
known Sword in column 2, leaving a refill slot beside the other top-row Sword;
that known Sword could be swapped into the slot to complete the vertical
Sword-3. The old UNKNOWN audit tested only whether the refill itself was a
Sword. It now also moves each adjacent known Sword into a hypothetical
non-Sword refill slot and checks the resulting known Sword line. A dedicated
regression reproduces this collapse and rejects the Rage move as unsafe.

Policy telemetry now persists the complete screen-oriented 8x8 gem/multiplier
snapshot and compact evaluation for every legal move. Managed DTO addresses
can be reclaimed after a run; this evidence makes later collapse disputes
replayable instead of relying only on a board hash. Offline verification is
**785/785 PASS**; fresh live policy acceptance is required.

## v1.0.19 PASS handoff full-scan deduplication

FarmRun `67bb91cf613345a6ba1b806cd834bb57` also exposed an independent
latency defect. The first PASS discovery scan took 6.35 seconds and, while it
crossed the opponent/local boundary, decoded and offered the validated
current-match board for `srvSeq=19`. At the start of local turn 9,
`MatchService` reported 13 seconds remaining and ACK 19. The monitor considered
only already-`ackAttested` provider batches resolved, so the offered-but-not-yet
ACK-attested board did not suppress ACK-gap escalation. It scanned the broad
heap again for the same sequence, consuming 7.56 seconds. Provider stability
then completed at one second and the otherwise-correct Sword action expired.

The provider diagnostics now distinguish transport-attested and shared-runtime
heap-attested snapshots. The monitor treats their exact sequences as already
available for scan-deduplication, while the provider still independently
requires the matching `MatchService._ackedSeqs` value and every existing
stability/actionability gate before publishing the board to policy. An
unattested heap candidate cannot suppress discovery. PASS scan telemetry now
includes reason, regions and bytes so a future broad scan is attributable.
Offline verification is **786/786 PASS**; a fresh live PASS-to-local-turn
handoff is required to measure the bounded path.

## v1.0.20 redux owner-first scan and combat card cache

The latest `reverse/redux_compat/cs/Assembly-CSharp` evidence used here is:

- `Board.cs`: `selectedCards : List<CardData>` at `+0x318` and
  `cardsInHand : List<GameObject>` at `+0x320`;
- `CardUI.cs`: `cardData`, `board`, `active`, used/turn/pending fields at their
  declared `+0x20..+0x48` offsets;
- `CardData.cs`: complete ID/type/condition/power/cost/cooldown payload through
  `needPerfection` and quality fields at `+0x10..+0x98`;
- `FusionCardUI.cs`: `_btn +0x58`, `_nextRefreshAt +0x60`, `_boundPetId +0x68`;
- `MatchService.cs`: `PendingCombat +0x188`, current turn/timer, ACK and Fusion
  state roots already consumed by the read-only provider;
- `BoardWsApplier.cs`: current Board owner `+0x20`, pending batch queue `+0x50`
  and render-running flag `+0x58`;
- `WsCombatBatch.cs`: `srvSeq +0x10` and `board : BoardCellDTO[][] +0x38`.

This supports a narrower acquisition order, not a direct game-method call.
Opening local turn is board-only. First boss turn reads the current Board lists
and scans separately bounded owner allocations for ordinary and Fusion cards.
Resolved CardUI addresses persist for the combat and are revalidated directly;
immutable CardData is decoded once. Mana/power and current UI gating are still
read live before input. Heap discovery resumes only after ownership/readability
loss or a Fusion-success strip change, and every input remains ordinary
foreground Windows input.

For board transport, `PendingCombat` and `_pendingBatches` remain the strongest
direct transient roots. The monitor's periodic maintenance is now an
allocator-neighbour refresh rather than a timer-triggered process-wide scan.
The sole broad local fallback remains evidence-driven by an exact unresolved
ACK gap, and it cannot relax the provider publication gates. Offline source
verification is **788/788 PASS**; live timing/card-cache acceptance is pending.

## v1.0.21 direct standard-card path

Live run `3b5672d3e1be4a7193c15c6d84ad3710` proved that decoding the direct
Board lists was already quick and exact, while locating managed UI wrappers
could remain unresolved for many turns. The provider now treats an agreeing
standard layout (`Fusion` first, then `selectedCards` in list order) as a
bounded action authority. MatchService still supplies current Fusion
enabled/used/locked/cost/pet fields; PlayerStats supplies current resources;
the controller still requires a fresh visual proof at the resolved tile before
clicking. No address, slot count, cost, or selected card is guessed.

This direct path suppresses the ordinary/Fusion heap-wrapper scans when the
two Board lists already resolve the strip. Exact live UI state remains
preferred if already available. Ordinary cards with non-zero cooldown do not
use the direct fallback because their current cooldown state would be unknown.
The standard Attack card observed in the run has `cooldownTurns=0` and actual
cost `conditionUse=160`. Offline verification is **793/793 PASS**.

## v1.0.22 live turn projection and direct CAST confirmation

Live FarmRun `2f363b504c6742acacc882e3707e2acf` completed 5/5 STRONG,
CONSISTENT wins with zero technical abort, recovery, safe-stop, provider read
error, DTO rejection, stale publication, or result conflict. Its distinct
local-turn energy counts were 19, 14, 9, 11 and 22 (total 75). The controller
now projects the already-read, deduplicated current local-turn count to the UI;
no extra memory scan or capture is performed, and completed counts plus total
remain authoritative at the combat summary boundary.

The run also exposed a telemetry-only gap on the new standard direct-card
path: seven CAST inputs were sent, but `castAccepted` remained zero because no
managed CardUI wrapper existed. Five nonterminal CAST observations prove the
exact 160-mana decrease and immediate opponent-turn transition. That dual
proof now accepts only `BOARD_SELECTED_CARDDATA_CARD_STRIP` CASTs; either signal
alone and every other authority still fail closed. Offline verification is
**796/796 PASS**.

## v1.0.23 fast-turn observer hotfix

FarmRun `1e5ec6948f734889b29654122f0ecb17` entered combat with a proven
64/64 opening and sent its first SWAP, but the following direct MatchService
sample raised a local `TypeError`: the new UI `progress_observer` keyword had
been passed to `TurnTransitionTracker.observe_runtime`, whose API intentionally
owns only turn-transition proof. No runtime layout changed and this is not a
Redux 1.7.4 compatibility failure.

The observer is now routed to the deduplicated counter after the transition
tracker call. This preserves the tracker API, adds no process read, and keeps
projection errors isolated from gameplay. A regression test exercises the
exact fast path. Source verification is **797/797 PASS**; live retry remains
pending.

## Unversioned Phase 2 repair — b2 ops-only ACK board fallback

Run `4ea0b9f50cd54dc08d3bfdb984fd1f95` timed out three local turns
without entering policy. The durable ACK watermark advanced beyond the most
recent full-board DTO, so the provider waited for a same-sequence object that
b2 was not required to create. Native `HandleResEnvelope` proves that combat
responses can apply incremental `ops` and be acknowledged without carrying a
replacement board.

The provider now uses the current rendered 8x8 Dot grid only for this exact gap.
It follows Board-owned GameObjects into signature-gated native component lists,
requires one exact managed Dot per cell, reads b2 `PoolTag`/coordinate/
multiplier fields, rejects every motion/render flag, and repeats all ownership
plus ACK checks before publication. This is bounded to 64 current objects and
removes the multi-second heap recovery from the normal path. Same-sequence DTO
capture remains preferred.

This repair has no version bump, commit or push because the default Phase 2
live behavior is still under test. Offline checks pass. First live run
`2f9116700bac4331b5830ab438983229` completed one STRONG/CONSISTENT win,
accepted 5/5 native current-board reads with zero rejection, and executed a
consuming action on all eight local turns with zero PASS. It also made three
valid 120-mana Fusion requests; the server returned `success=false` and charged
120 each time, so evolution did not complete in this sample. Phase closure
remains pending user review.

## b2 multi-match opening pause handoff

Run `a588b67a29834419a9e8b351cfbed926` proved a tool-side cache defect exposed
by b2's delayed opening clock. Attempt 1 won and evolved successfully. Attempt
2 had an exact new MatchId, Board and 64-cell opening, and policy selected a
safe Sword move at 13 seconds. No input was sent because opening preflight
reused the first published MATCH_START battle envelope, which still contained
the earlier `ClockPaused=true / FX` signal. It aborted the same valid decision
41 times until the turn expired. The run contains zero formal PASS decisions.

`MatchService.cs` in `reverse_1.7.4-b2` declares `ClockPaused +0x165`,
`ClockPauseReason +0x168` and `_startGateSeen +0x178`; native
`ApplyTimingFields` updates this state. The compatibility layer therefore keeps
the pause gate. The correction is at the preflight cache boundary: it retains
the current duplicate state's dynamic actionability fields instead of restoring
the frozen first publication, then revalidates exact MatchService
identity/turn/timer and the pristine opening sequence. No heap scan or input is
added. Offline verification is **1165/1165 PASS**; multi-match live soak is
pending. See
[Phase 2 b2 multi-match incident](phase2_b2_multi_match_opening_incident.md).
