# PetPuzzle 1.7.4-b6 compatibility audit

Date: 2026-10-01 (Asia/Saigon)

Status: **LIVE B2 PASS STRONG — base b6 entry, board, acknowledged action,
result and multi-match continuity are closed.**

## Scope and build identity

This audit migrates the V2 read-only runtime from Pokiguard 1.7.4-b5 to the
user-supplied reverse output in `reverse/reverse_1.7.4-b6`. No game file or
target memory was modified.

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `PetPuzzle-1.7.4.exe` | 575,488 | `32EF7BDAC0FFECD45D8F50DC4A715CF9585FEFA5299FFC9207CD92A84A005929` |
| `GameAssembly.dll` | 62,532,608 | `72D10A43FBFDAB705E2DB7CACA1CC2B998B0B8581D56946DC545D87C720EC063` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,824,020 | `AC32633A4856D4BEF5EFB63028F2A354C63BCC327A8D275013728C5E25C17C47` |

`GameAssembly.dll` is x64, PE timestamp `0x6ABDA889`, preferred image base
`0x180000000`, and `SizeOfImage 0x03E5E000`. Metadata magic/version is
`0xFAB11BAF` / `110`. The allowlist accepts only this b6 GameAssembly hash.

## Product rename migration

The launcher/process is now `PetPuzzle-1.7.4.exe`; the live window title is
`Pet Puzzle`. The selector accepts current PetPuzzle and retired Pokiguard
names. A missing saved path such as `D:\pc\Pokiguard-1.7.4.exe` migrates only
to a supported launcher in the same existing directory. The hash gate remains
the final authority.

The installed b6 client still owns Unity PlayerPrefs under
`HKCU\Software\Pokiguard\PokiguardOnlines`, so that registry path is retained.

## TypeInfo migration

All values are module-relative b6 RVAs. Exact `(name, type, .NET type)` matching
was used to avoid class/array and co-op/PVP collisions.

| Type/root | b6 RVA | Type/root | b6 RVA |
|---|---:|---|---:|
| `Board` | `0x036C9F88` | `Active` | `0x036C9E70` |
| `ManagerMatch` | `0x036C6148` | `MatchService` | `0x036C4020` |
| `ChatService` | `0x036C3C38` | `ChatMessageDTO` | `0x036CDBB8` |
| `HubSuspendManager` | `0x036C3C50` | `MatchHost` | `0x036C4370` |
| `MatchSceneLoader` | `0x036C4278` | `TurnAnnouncer` | `0x036C3E90` |
| `Dot` | `0x036CBD30` | `WsCombatBatch` | `0x036CFC28` |
| `BoardWsApplier` | `0x036C3DE8` | `CardUI` | `0x036C3FD0` |
| `FusionCardUI` | `0x036EC2B0` | co-op `Active.PlayerStats` | `0x0367C930` |
| `PetUserDTO` | `0x0369EB60` | `CardData` | `0x036EC2C0` |
| `AuditionStage` | `0x03682B68` | `AuditionChallenge` | `0x03682828` |
| Chat message closure | `0x036D0348` | dispatcher | `0x036CDE18` |
| pending list | `0x036D8100` | pending queue | `0x036D8150` |
| `ManagerQuangTruong` | `0x036C4718` | `ManagerRoom` | `0x036C3FC0` |
| `WsRoomService` | `0x036D7B08` | `RoomCoopV2View` | `0x036A0A30` |
| `UIPanelManager` | `0x036C47E0` | `ChinhPhucDataService` | `0x0369B7E8` |
| `JArray` | `0x036C49D0` | `JObject` | `0x036C49C8` |
| `JProperty` | `0x036B66D8` | `JValue` | `0x036D7EA0` |

Important disambiguations: co-op `Active.PlayerStats` is `0x0367C930`, while
`ActivePVP.PlayerStats` is `0x0369EB68`; `PetUserDTO` is `0x0369EB60`, while
`PetUserDTO[]` is `0x036C6A88`.

## Managed and native comparison

The complete b5/b6 field scan found nine new DinoIsle files and twenty changed
classes. Of the production reader classes, only `ChatService` changed, adding
static flags and late world-replay fields. Every `ChatService` offset V2 reads
remains unchanged. All other managed fields consumed by board, transport,
cards, QTE, lobby, map and opening-snapshot readers match b5.

`UnityPlayer.dll` is byte-identical to b5, so its bounded signatures and
`Component.get_gameObject` RVA `0x01067390` remain valid. GameAssembly-side
anchors moved:

| Anchor | b6 RVA |
|---|---:|
| cached `Component.get_gameObject` target | `0x038D7AE8` |
| managed/native unmarshal code | `0x0138561F` |

The b6 unmarshal bytes are
`4885db7433f6c301740d488bcbe87f6ee8fe488bd8eb03488b1b`. Both anchors were
verified against the installed b6 process.

## Why an update is not only a signature/hash change

The b4-to-b5 migration also required every TypeInfo RVA, several managed
offsets, participant-class disambiguation, `RoomStartState` button semantics,
runtime Start geometry, GameAssembly native anchors, nested WorldSpace Canvas
handling, and the x1..x7 multiplier domain. The reusable runbook now treats
all of these as mandatory checks for every release.

## Verification

- focused compatibility tests: **101/101 PASS**;
- complete regression: **1625/1625 PASS**;
- exact b6 executable selection and hash gate: PASS;
- read-only live attach to PID `3744`: PASS;
- native Unity ownership bridge: PASS;
- lifecycle: `LOBBY`, no read errors;
- surface: `LOBBY_OTHER / GAME_LOBBY`, matching the current client;
- 21 initialized TypeInfo slots resolved; scene-owned null slots on the game
  lobby were not treated as evidence of failure;
- no input was sent and the desktop tool was not opened automatically.

## Bounded live acceptance plan

1. B1: from the correct boss lobby, run one target match and prove room-button
   state/geometry, authoritative 8x8 opening board and one acknowledged swap.
2. Complete it and prove result confirmation and return to the same room.
3. B2: run three consecutive matches to cover fresh MatchIds, participant and
   card/QTE ownership, result and re-entry continuity.

Any mismatch must fail closed and be recorded here before expanding the run.

## B1 live acceptance — PASS STRONG

Farm run `b3dcf0149dcd4b0495cc44e1606c6a19` completed exactly 1/1 against
Starburst with fresh match `M_f2dea564` and a strong memory-backed WIN. It
proved:

- exact b6 `CHINH_PHUC_ROOM`, `RoomStartState=Idle`, one runtime-owned Start
  click and no duplicate lobby input;
- authoritative 64-cell opening from
  `ChatMessageDTO.MATCH_START.matchPayload.board`, 64 unique coordinates,
  valid gem/multiplier domains and two stable confirmations;
- one foreground-leased two-click swap on the first local turn;
- Demon Aegis passive immediately reduced boss HP to zero before the normal
  ACK observer could publish a post-move board;
- the pending action ended as `ACTION_ABORTED_STATE_CHANGED /
  COMBAT_LIFECYCLE_ENDED`, while the same-session terminal snapshot proved
  local HP `78462`, boss HP `0`, `WIN / STRONG` and UI text `Thắng`;
- normal postmatch confirmation, return to `BOSS_LOBBY`, zero Pass, zero
  provider read/DTO/opening error, zero safety-counter violation, and final
  reason `FARM_TARGET_COMPLETED`.

The missing ordinary swap-ACK count is expected for this one-turn passive
kill: combat reached POSTMATCH before an acknowledged next board could be
sampled. The terminal HP transition and consistent memory/UI WIN provide
stronger causal acceptance that the sent move was processed; it is not counted
as an unacknowledged retry or gameplay failure.

B2 remains three consecutive matches to prove fresh-session continuity.

## B2 multi-match continuity — PASS STRONG

Farm run `5f42dd884e8d4936b4980547ff2a4be0` completed exactly 3/3 with three
fresh MatchIds (`M_a7f1e84e`, `M_74620083`, `M_ab1c1979`) and three strong,
memory/UI-consistent WINs. Across the run:

- each attempt used exactly one runtime-owned room-entry click and accepted an
  authoritative 64-cell opening with 64 unique coordinates;
- 10/10 swaps were sent, 7 received ordinary ACK evidence, zero were rejected,
  and the final swap of each match transitioned directly to POSTMATCH after
  the Demon Aegis passive reduced boss HP to zero;
- all three matches produced strong terminal HP evidence, UI `Thắng`, one
  normal result confirmation and a clean return to the boss room;
- zero Pass, loss, unknown result, technical abort/recovery, safe stop,
  provider read error, DTO rejection, stale publication, opening rejection,
  duplicate input, wrong-turn input, target error or result conflict;
- final lifecycle was `BOSS_LOBBY` and stop reason was
  `FARM_TARGET_COMPLETED`.

The second match ran eight local turns and supplied seven ordinary post-move
ACKs, directly covering the ACK path that the one-turn B1 and the other two
one-turn kills could not expose. This closes the base b6 compatibility path.
The Demon Aegis profile has no pet-skill QTE, so QTE execution was not part of
these live runs; its b6 TypeInfo/layout migration is reverse- and
regression-verified but not newly live-exercised here.

## Entry handoff regression after five matches — fixed offline

Farm run `05f7f29fed684adebcf7bad79f6433e1` completed five strong WINs, then
stopped while entering attempt 6. This was not a policy PASS failure:

- all five completed attempts recorded `pass_count=0`;
- attempt 6 sent one accepted Start click and created fresh match
  `M_80eb5daa`;
- entry missed the short-lived `MATCH_START` opening DTO and never handed the
  active session to the gameplay controller;
- at turn 3 the provider published the exact current 64-Dot board with stable
  `MatchService._ackedSeqs`, but the entry recovery gate only recognized a
  retained `MATCH_MOVE_RES` DTO source;
- the run therefore reached `ENTRY_TIMEOUT_OPENING_BOARD` with zero gameplay
  input. The later game-lobby ejection was the consequence of untouched turns,
  not the original stop cause.

The recovery gate now also accepts the provider's exact b6 live identity
`Board.allDots->GameObject.components->Dot.PoolTag+MatchService._ackedSeqs`.
It still requires the same current session, turn greater than one, no local
move, one entry click, zero gameplay input, positive sequence and a board hash.
A bare Board source or arbitrary ACK-like suffix remains rejected. The same
predicate is used by entry detection and the technical-recovery dispatcher so
the evidence cannot pass one boundary and fail at the next.

Offline verification after the fix:

- boss-entry, technical-recovery and FarmRunner tests: **160/160 PASS**;
- complete regression: **1.653/1.653 PASS**;
- compile and `git diff --check`: PASS.

A short live retry that naturally reaches the sixth entry is still required
to prove the recovered b6 source in the real timing path.

## Long-run retry — source gate proven; low-timer handoff fixed offline

Farm run `0cfc8d878cae4182b040cf58b4798926` targeted the 28 remaining
matches and completed 21 strong WINs before stopping on attempt 23. It recorded
zero loss and zero policy Pass; the final game-lobby ejection was again a
downstream consequence of an unattended combat after the controller had
already stopped.

This run proves the preceding b6 source-gate fix live. Attempt 18 missed the
short-lived opening DTO, recognized the exact ACK-attested current-board
source, dispatched recovery, left the failed combat, re-entered fresh match
`M_787b8497`, accepted its authoritative 64-cell opening and completed that
match as a WIN.

Attempt 23 reached the same recovery path and also exited/re-entered correctly,
but the replacement match `M_40ab66f1` was accepted with only five seconds
remaining on its first local turn. The required 2.5-second ACK handoff guard
remained clean for 17 samples, yet the timer had fallen to two seconds at its
end. The guard incorrectly treated that expected timer decay as
`RECOVERY_HANDOFF_NOT_STABLY_ACTIONABLE`, even though entry had already proved
the opening timer safe and no session, board-action or ACK invariant failed.

The handoff guard now preserves the entry-time timer proof while continuing to
run its complete bounded ACK/session/pristine-state check. If the timer crosses
the normal action floor during that guard, recovery hands control back with a
`waitForNextLocalTurn` diagnostic; FarmRunner performs its required full live
state reread and can wait for the next local turn instead of abandoning the
match. A low timer without the accepted entry-time proof remains rejected.

Offline verification after this correction:

- boss-entry, technical-recovery and FarmRunner tests: **162/162 PASS**;
- complete regression: **1,655/1,655 PASS**;
- compile and `git diff --check`: PASS.

The remaining seven matches may be used as the bounded live confirmation for
this handoff correction; they are not a replacement for the 21 already
completed matches.
