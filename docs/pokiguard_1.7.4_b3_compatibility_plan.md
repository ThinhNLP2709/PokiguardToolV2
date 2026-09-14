# Pokiguard 1.7.4-b3: compatibility audit and implementation plan

Date: 2026-09-12

Historical note: **superseded by the b4 compatibility report and the current
Phase 3C.1 report.** Statements below describe the b3 checkpoint at the time
and are not current runtime gates.

Status: **default-mode implementation and read-only lobby validation complete;
one live default combat remains. Audition V3 is intentionally paused**.

This document began as the static handoff and now also records the bounded b3
default-mode implementation. Game files were read only and were not modified.

## Implementation update — 2026-09-13

The current runtime remains a single-profile implementation. It now maps the
exact b3 hash to the b3 layout and no longer accepts the b2 hash; accepting both
with one global constant set would let one build run against the other build's
offsets. The following default-mode paths are updated together:

- Board/Active TypeInfo roots and shifted late Board fields;
- MatchService turn, server-clock, Fusion, pending-combat, ACK, last-move,
  desync, and terminal fields;
- ChatMessageDTO transport/typed pre-board fields and Newtonsoft TypeInfo roots;
- player actor/stats ownership, ordinary cards, Fusion UI, PetUserDTO, lobby,
  room entry, and lifecycle roots;
- idle diagnostics that decode current ChatMessageDTO responses.

The new UI does not invalidate the native geometry walk. Exact static and live
checks prove:

```text
Component.get_gameObject icall cache  GameAssembly + 0x354C060
resolved UnityPlayer function          UnityPlayer  + 0x1067390
managed/native unmarshal signature     GameAssembly + 0x108881F
```

All 15 existing UnityPlayer ownership, component-list, active-state,
RectTransform, Transform, and Canvas signatures match the installed b3 DLL
byte for byte. The cache RVA and unmarshal routine changed and are updated.

Audition V3 has not been mechanically routed through the legacy CardUI QTE
reader. Pet Skill execution now fails closed before FarmRunner starts with
`PET_SKILL_AUDITION_V3_NOT_IMPLEMENTED`. Phase 3C.1 policy/backend source is
preserved for the later V3 adapter. Default Attack and normal evolution remain
the only authorized live gameplay scope.

Verification completed so far:

- focused layout/default/Pet-configuration tests: PASS;
- complete unit regression: **1211/1211 PASS**;
- compileall and `git diff --check`: PASS;
- exact installed b3 hash accepted; unknown hashes remain rejected;
- read-only live attach: x64, MatchService/ChatService resolved, native
  geometry initialized, lifecycle classified LOBBY, no read errors;
- read-only boss-lobby inspection exercised the shifted ManagerRoom and
  WsRoomService fields with zero input. Artifact:
  `logs/boss_entry/20260913_011233/entry.jsonl`.

The live process was outside a Chinh Phuc room during inspection. The remaining
default-mode acceptance is a fresh 8x8 board observation followed by one
bounded normal-pet/default-Attack match. Until that finishes, b3 combat status
is implemented but not yet declared live-stable.

## Conclusions

1. The primary build fingerprint required by the current runtime is the
   SHA-256 of `GameAssembly.dll`. For the installed b3 build it is:

   ```text
   BD504AF095F825864C963B10C9F62ADA1B8BD7B18E13FF1F0C87B04CD4B5B02D
   ```

2. The current tool must remain blocked on b3. Its allowlist contains only the
   b2 hash, and every relevant `TypeInfo` RVA moved. Adding the b3 hash alone
   would allow b2 offsets to run against b3 memory and would be unsafe.

3. The board data contract is partly stable. The server board DTO, `Dot`, the
   first part of `Board`, `Active.board`, and the core `BoardWsApplier` fields
   retain their offsets. However, the `TypeInfo` RVAs changed, fields in the
   latter half of `Board` shifted, most of `MatchService` shifted, and
   `ChatMessageDTO.preBoard` moved. Therefore current board capture,
   actionability, card discovery, ACK/desync, and result observation are not
   b3-compatible.

4. Settings can calculate and persist a fingerprint without reverse tooling.
   Python's standard `hashlib` is already used by the project. Exact semantic
   offsets and `TypeInfo` RVAs cannot be safely inferred from a filename or
   hashes; robust automatic derivation would amount to maintaining a
   version-aware IL2CPP reverse pipeline. That should not run when Settings is
   saved.

5. The legendary skill is a new conditional QTE implementation named
   `PokiGuard.Audition`, with layout `LR`. The existing input backend already
   knows Left, Right, and Space, but its observer binds progress and timing to
   legacy `CardUI` fields. Under b3 Audition V3, progress and timing live in
   `AuditionStage`. The current legendary-skill automation is therefore
   incompatible even after a mechanical offset update.

6. The screenshot supplied with this task agrees with the reverse evidence:
   the QTE exposes only left/right buttons plus a timing bar. It does not show
   the normal board grid, so it cannot prove new board click coordinates.

## Evidence boundary

The audit used only read-only sources:

- user-supplied reverse output at `reverse/reverse_1.7.4-b3`;
- the accepted b2 baseline at `reverse/reverse_1.7.4-b2`;
- the installed files under `D:\pc`, read only;
- current V2 source and documentation;
- read-only x64 disassembly of the exact installed b3 `GameAssembly.dll` at
  RVAs declared by the b3 reverse output;
- the screenshot supplied with the task.

Generated C# declarations prove type names, field layouts, and method address
ranges. Native behavior below is called **CONFIRMED** only where the exact b3
DLL body was inspected. No runtime pointer chain has been live-validated yet.

The b3 reverse directory does not contain a provenance README or embedded hash
of its input files. The association between that directory and the installed
binary is based on the user's supplied provenance and the matching b3 type and
method layout. The next implementation task should add a small provenance file
beside the reverse output after the hashes are accepted.

The installed Unity files report product version `6000.7.0a4
(7305b6f6fd4f)`, while Il2CppInspector's generated
`il2cpp-metadata-version.h` says target Unity `6000.7.0a3`. Both b2 and b3
generated headers make that same a3 selection. Compatibility must therefore be
keyed by exact hashes and validated layouts, not by that Unity label.

## Task 1: exact b3 fingerprint

### Installed b3 artifacts

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 58,686,976 | `BD504AF095F825864C963B10C9F62ADA1B8BD7B18E13FF1F0C87B04CD4B5B02D` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,303,076 | `6A6FC8D0E761D33C2EC882A3E01C3516CDFCBB9F5885477E3FE35819A861F751` |

Metadata header:

```text
magic          = 0xFAB11BAF
header version = 110
```

Additional PE identity for `GameAssembly.dll`:

```text
machine       = 0x8664 (x64)
PE timestamp  = 0x6AA53310
SizeOfImage   = 0x03AB3000
```

For comparison, the accepted b2 profile uses a 53,603,328-byte
`GameAssembly.dll` with SHA-256
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`
and 15,394,348-byte metadata with SHA-256
`F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`.
The executable name remains `Pokiguard-1.7.4.exe`, so its name/version cannot
distinguish b2 from b3.

### Current gate

`src/pokiguard_v2/game_location.py` currently contains only the b2
`GameAssembly.dll` SHA-256 in `SUPPORTED_GAME_ASSEMBLY_SHA256`.
`tools/runtime_common.py::attach_target` hashes the loaded module path and
fails closed with `IncompatibleGameBuildError` before constructing the memory
resolver. This is the correct current behavior for b3.

Implementation rule for the next task:

- do not append the b3 hash first;
- implement and verify the b3 layout profile;
- run offline structural tests;
- perform read-only live validation;
- only then enable the b3 fingerprint.

## Task 2: board, cards, lifecycle, and memory-layout impact

### All relevant TypeInfo RVAs moved

These are RVAs relative to the loaded `GameAssembly.dll` base, never absolute
runtime addresses.

| Type | b2 RVA | b3 RVA |
|---|---:|---:|
| `Board` | `0x02DA5890` | `0x03343B68` |
| `Dot` | `0x02DCC268` | `0x03347260` |
| `Active` | `0x02D96E60` | `0x03343968` |
| `Active.PlayerStats` | `0x02DFD1A0` | `0x0332F598` |
| `ManagerMatch` | `0x02D947D0` | `0x0333DAF0` |
| `MatchService` | `0x02D96548` | `0x03337DE0` |
| `ChatService` | `0x02DAD230` | `0x033377B8` |
| `ChatMessageDTO` | `0x02DAD0B0` | `0x03349C28` |
| `WsCombatBatch` | `0x02DEB350` | `0x0334D930` |
| `BoardWsApplier` | `0x02DA5B70` | `0x03337A50` |
| `CardUI` | `0x02DAB7F0` | `0x03337D48` |
| `FusionCardUI` | `0x02DD97E8` | `0x03373998` |
| `CardData` | `0x02DAB070` | `0x033739A0` |
| `PetUserDTO` | `0x02DA86D0` | `0x0335A470` |
| `TurnAnnouncer` | `0x02DDAE68` | `0x03337B18` |
| `MatchSceneLoader` | `0x02D96490` | `0x033397A0` |
| `MatchHost` | `0x02D95F88` | `0x03339948` |
| `HubSuspendManager` | `0x02DE3C78` | `0x033377D8` |
| `ManagerQuangTruong` | `0x02D94AB0` | `0x03339F30` |
| `ManagerRoom` | `0x02D94C20` | `0x03337D30` |
| `WsRoomService` | `0x02DEB6E8` | `0x033544E8` |
| `UnityMainThreadDispatcher` | `0x02DE08F8` | `0x03349EB8` |
| dispatcher pending-action `List` | `0x02DDB970` | `0x033549F8` |
| dispatcher pending-action `Queue` | `0x02DE5D48` | `0x03354A48` |
| `ChatService.<>c__DisplayClass275_0` | `0x02D97A60` | `0x03349D50` |
| Newtonsoft `JArray` | `0x02E02ED0` | `0x033363F0` |
| Newtonsoft `JObject` | `0x02E030F8` | `0x033363E8` |
| Newtonsoft `JProperty` | `0x02E03268` | `0x03367910` |
| Newtonsoft `JValue` | `0x02E03990` | `0x033547D0` |

Consequences:

- no existing class pointer lookup is valid on b3;
- heap/class scans cannot be reused until their expected class pointers come
  from the b3 profile;
- singleton/static-field layouts that are otherwise unchanged still require
  the new TypeInfo RVA.

### Board and server-board transport

The primary grid and early actionability offsets are unchanged:

| Field | b2 | b3 | Verdict |
|---|---:|---:|---|
| `Board.currentState` | `0x78` | `0x78` | stable |
| `Board.width` | `0x88` | `0x88` | stable |
| `Board.height` | `0x8C` | `0x8C` | stable |
| `Board.hasDestroyedThisTurn` | `0x125` | `0x125` | stable |
| `Board.isMega2PanelOpen` | `0x129` | `0x129` | stable |
| `Board.allDots` | `0x150` | `0x150` | stable, still `GameObject[,]` |
| `Board.active` | `0x168` | `0x168` | stable |
| `Board.isCascadeRunning` | `0x180` | `0x180` | stable |
| `Board.isProcessingUI` | `0x1E0` | `0x1E0` | stable |
| `Board.isGameOver` | `0x2E0` | `0x2E0` | stable |
| `Board._leftActorNumbers` | `0x2E8` | `0x2E8` | stable |

b3 adds `Board.isGuildBossBattle` at `0x30A` and
`Board._raidFightAgainBtn` at `0x310`. The new pointer shifts the later Board
layout by eight bytes:

| Field used by V2 | b2 | b3 | Required action |
|---|---:|---:|---|
| `cardContainer` | `0x328` | `0x330` | update b3 card owner path |
| `selectedCards` | `0x340` | `0x348` | update b3 card state |
| `cardsInHand` | `0x348` | `0x350` | update b3 card state |
| `isBoardReady` | `0x390` | `0x398` | update b3 actionability |
| `isUsingLegendCard` | `0x391` | `0x399` | update b3 actionability/QTE |
| `isUsingMega` | `0x398` | `0x3A0` | update b3 actionability |
| `isResuming` | `0x3B0` | `0x3B8` | update b3 actionability |
| `isMega1PanelOpen` | `0x470` | `0x478` | update b3 actionability |

`Dot.column +0x20`, `Dot.row +0x24`, `Dot._board +0x48`,
`Dot.multiplier +0x88`, and `Dot.originalPrefab +0xD8` are unchanged.
`WsCombatBatch.srvSeq +0x10` and `board +0x38` are unchanged.
`BoardWsApplier.board +0x20`, `_bootstrappedMatchId +0x30`,
`_pendingBatches +0x60`, and `_renderRunning +0x68` are unchanged. The b3
applier adds later guild-raid/render-recovery state, which does not move those
four fields.

The production rule that `Board.allDots` is not a typed `Dot[,]` remains in
force. The strong source is the class-checked server DTO board carried by the
current transport/message owner. The solver and board legality logic do not
need to be rewritten merely because the build changed.

### MatchService

The identity and basic turn fields remain stable:

```text
CurrentMatchId       +0x20
CurrentTurnPlayer    +0x38
TurnNumber           +0x40
TurnDurationSec      +0x44
```

Most fields after that moved because b3 inserted guild-raid, Fusion, and QTE
state. Every following value used by V2 needs a b3 profile:

| Field | b2 | b3 |
|---|---:|---:|
| `FusionEnabled` | `0x60` | `0x98` |
| `FusionManaCost` | `0x64` | `0x9C` |
| `FusionStatPercent` | `0x68` | `0xA0` |
| `LocalFusionUsed` | `0x6C` | `0xA4` |
| `LocalFusionLastAttemptTurn` | `0x70` | `0xA8` |
| `LocalFusionSelectedUserPetId` | `0x78` | `0xB0` |
| `LocalFusionSelectedPetId` | `0x80` | `0xB8` |
| `LocalFusionSkillCard` | `0x88` | `0xC0` |
| `LocalFusionDropReason` | `0x90` | `0xC8` |
| `Players` | `0xB8` | `0x108` |
| `LocalSeqNum` | `0xC0` | `0x110` |
| `TurnTimeRemainingSec` | `0x138` | `0x190` |
| `HasServerClock` | `0x164` | `0x1BC` |
| `ClockPaused` | `0x165` | `0x1BD` |
| `ClockPauseReason` | `0x168` | `0x1C0` |
| `PendingCombat` | `0x1A8` | `0x200` |
| `_inFlightBatches` | `0x1B0` | `0x208` |
| `_ackedSeqs` | `0x1B8` | `0x210` |
| `_matchOver` | `0x1EB` | `0x243` |
| `_resyncCoroutine` | `0x1F0` | `0x248` |
| last move from col/row | `0x1F8/0x1FC` | `0x250/0x254` |
| last move to col/row | `0x200/0x204` | `0x258/0x25C` |
| last move sequence | `0x208` | `0x260` |
| `ServerQteArrows` | `0x220` | `0x278` |
| `ServerQteDurationMs` | `0x228` | `0x280` |
| `ServerQteWindow` | `0x22C` | `0x284` |
| `ServerQteChallengeId` | `0x250` | `0x2C8` |
| `LastRejectCardId` | `0x270` | `0x2E8` |
| `_deferredWinner` | `0x280` | `0x2F8` |
| `_hasDeferredGameOver` | `0x288` | `0x300` |

b3 also adds these QTE fields:

```text
ServerQteLayout       +0x2A8
ServerQteReverseFrom  +0x2B0
ServerQteGreatMs      +0x2B4
ServerQteMultPerfect  +0x2B8
ServerQteMultGood     +0x2BC
ServerQteMultBad      +0x2C0
QteUiGeneration       3
QteUiGenerationLegacy 2
```

This affects turn deadlines, ACK correlation, pending combat capture, desync
recovery, Fusion/evolution, player identity, terminal detection, and both QTE
generations.

### ChatMessageDTO and opening-board capture

b3 inserts `vipLevel +0x20`, `clientMonoMs +0xD0`, and new raid data. Critical
fields used by V2 move as follows:

| Field | b2 | b3 |
|---|---:|---:|
| `timestamp` | `0x28` | `0x30` |
| `type` | `0x30` | `0x38` |
| `matchId` | `0xB0` | `0xB8` |
| `seqNum` | `0xB8` | `0xC0` |
| `matchPayload` | `0xC8` | `0xE0` |
| `fromCol/fromRow` | `0xD0/0xD8` | `0xE8/0xF0` |
| `toCol/toRow` | `0xE0/0xE8` | `0xF8/0x100` |
| `cardId` | `0xF0` | `0x108` |
| `rejectReason` | `0x100` | `0x118` |
| `skillCardId` | `0x108` | `0x120` |
| `correctDotCount` | `0x110` | `0x128` |
| `timingResult` | `0x118` | `0x130` |
| `dotsToDestroy` | `0x120` | `0x138` |
| `selectedRows` | `0x128` | `0x140` |
| `selectedDots` | `0x130` | `0x148` |
| `qtePresses` | `0x138` | `0x150` |
| `qteElapsedMs` | `0x140` | `0x158` |
| `qteChallengeId` | `0x148` | `0x160` |
| `preOps` | `0x3B8` | `0x410` |
| `preBoard` | `0x3C8` | `0x420` |
| `preBoardReady` | `0x3D0` | `0x428` |
| `preCombatSteps` | `0x3D8` | `0x430` |
| `preDestroyedByTag` | `0x3E8` | `0x440` |
| `prePlayers` | `0x3F8` | `0x450` |

The b2 fast typed `preBoard` path would therefore read unrelated b3 fields.
The idle-state DTO reader and QTE result correlation would also decode wrong
members. This is a direct blocker for Phase 2 reliability and for Phase 3C.1.

### Pet, cards, and Fusion

`CardData` preserves every old field through `eatBad +0x98`. It appends:

```text
petStar                    +0x9C
starSkillDamagePct         +0xA0
starSkillManaDiscountPct   +0xA4
starSkillPowerDiscountPct  +0xA8
```

The old `CardData` read size `0x9C` is still structurally safe for the old
fields, but it ignores star-based skill modifiers. The next implementation
must determine whether effective pet-skill costs/damage already arrive in the
old fields or must apply these modifiers. That requires a read-only runtime
comparison before policy uses them.

`PetUserDTO` keeps identity, name, skill-card ID, and `manaSkillCard +0x70`.
It adds `powerSkillCard +0x74`, causing:

| Field | b2 | b3 |
|---|---:|---:|
| `evoStage` | `0x74` | `0x78` |
| `evoChainLen` | `0x78` | `0x7C` |
| `cardDTO` | `0x90` | `0x98` |

It also adds star fields at `0x90/0x94`. The current pet reader's b2 read size
ends before the b3 `cardDTO`; it must be updated through a b3 profile.

`Active.playerStatsMap +0x20`, `playerStatsList +0x28`, and `board +0x38` stay
fixed. `Active.playerPets` moves from `0x310` to `0x300`; `enemyPets` from
`0x318` to `0x308`; and `activePlayers` from `0x330` to `0x320`.
`Active.PlayerStats` keeps the actor, HP, Mana, Power, Attack, and Shield
offsets used by V2 through `0x84`; `petData` moves from `0xA0` to `0xA8` after
the new `equipCounter +0xA0`. The current numeric stats read remains valid once
its b3 class pointer is supplied, but it must not infer the pet pointer at the
old location.

`FusionCardUI` adds `txtPity +0x50`, shifting:

| Field | b2 | b3 |
|---|---:|---:|
| used overlay | `0x50` | `0x58` |
| button | `0x58` | `0x60` |
| next refresh | `0x60` | `0x68` |
| bound pet ID | `0x68` | `0x70` |

The early ordinary `CardUI` identity/action fields remain stable:
`cardData +0x20`, button `+0x28`, board `+0x30`, active `+0x38`, used flags
`+0x40/+0x41`, last turn `+0x44`, action pending `+0x48`, and placeholder
`+0x80`. Thus the small ordinary-card instance read remains structurally
compatible after class discovery and the Board card-container offsets are
updated.

### Lobby and lifecycle

The three lobby TypeInfo RVAs moved as listed above. The fields used from
`ManagerQuangTruong`, `ManagerBoss`, `WorldBossDTO`, `RoomDTO`, and
`WsRoomService` remain at their b2 offsets. In particular, boss panels remain
at `+0x108/+0x2C0`, `_managerBoss +0x3E0`, boss list `+0x70`, room data
`+0x100`, selected cards `+0x108`, and room identity/properties fields remain
stable.

One used `ManagerRoom` field changed: `IsOpeningRoomFlow` moves from `+0x148`
to `+0x130`, because b3 removed the guild-room skin fields before it. Leaving
the old offset would make the entry guard read unrelated state.

`ManagerMatch.active +0x130` and `isBossBattle +0x138` are unchanged.
`MatchHost` state/current-rig statics, `MatchSceneLoader` loading statics,
`TurnAnnouncer` blocking/deadline statics, and the critical `ChatService`
connection fields retain their offsets; only their TypeInfo roots moved.

### Visible board geometry

Static reverse proves new guild-raid result/UI code, including
`EnsureRaidFightAgainButton`, but it does not encode the final serialized
prefab positions of the normal 8x8 grid. V2 sends physical swaps using
normalized calibration and a canonical game window. A visual grid move can
therefore break input even when the memory board and solver remain correct.

Current verdict: **UNKNOWN, live calibration required**.

Before any gameplay input on b3, run a zero-input memory-board overlay at the
canonical client size and confirm all 64 centers against a normal board
screenshot. Check at least the four corners and both bottom-row endpoints. Do
not infer coordinates from the supplied QTE screenshot because the grid is
covered.

## Task 3: automatic fingerprinting without reverse output

### What can be automatic and dependency-free

When the operator saves the game location, V2 can derive these paths from the
selected executable and read them without starting or attaching to the game:

```text
<game directory>\GameAssembly.dll
<game directory>\UnityPlayer.dll
<game directory>\<exe stem>_Data\il2cpp_data\Metadata\global-metadata.dat
```

Using the standard library, Settings can calculate:

- SHA-256 and file size for the executable, `GameAssembly.dll`,
  `UnityPlayer.dll`, and metadata;
- metadata magic and header version;
- basic PE machine, timestamp, and `SizeOfImage`.

No Cpp2IL, Il2CppInspector, network call, or process attachment is needed for
this fingerprint. Current code already hashes `GameAssembly.dll` at attach,
but `configure_game_location` and `_apply_game_location` only resolve and
persist the selected path. They do not calculate, display, or save a complete
build fingerprint at Settings-save time.

Recommended future Settings behavior:

1. resolve the exact executable and sibling files;
2. calculate a `BuildFingerprint` record read only;
3. compare it with a reviewed compatibility manifest;
4. display `SUPPORTED`, `UNKNOWN BUILD`, or `INCOMPLETE INSTALL` plus the exact
   `GameAssembly.dll` hash;
5. persist the selected path and last observed fingerprint for diagnostics;
6. keep runtime attachment blocked unless the exact fingerprint maps to a
   fully validated layout profile.

Saving an unknown path must never silently add its hash to the allowlist.
A hash identifies bytes; it does not prove that the hard-coded offsets are
correct.

### What should not be automatic in Settings

Exact field offsets and TypeInfo pointer RVAs require correlating IL2CPP
metadata with native registration/code in `GameAssembly.dll`, then validating
the result. Supporting that generally requires a version-aware reverse engine
such as Il2CppInspector or Cpp2IL, or an equivalent substantial parser owned by
this project. A simple metadata-header reader cannot recover the complete
runtime profile safely.

Therefore the next task should use this model:

```text
automatic fingerprint -> select reviewed per-build manifest -> validate live
```

It should not use this model:

```text
automatic fingerprint -> guess offsets -> auto-allowlist
```

The practical maintenance unit is a small, reviewed `BuildProfile` containing
the hashes, TypeInfo RVAs, field offsets, read sizes, and feature flags for one
exact build. The large generated reverse directory remains development
evidence and is not required on an end-user machine.

## Task 4: legendary skill changed from four directions to two

### Confirmed b3 mechanism

b3 adds the namespace `PokiGuard.Audition` with:

- `AuditionInput`;
- `AuditionRunner`;
- `AuditionStage`;
- `AuditionChallenge`;
- `AuditionStyle`;
- `AuditionArt`;
- `IAuditionHost`.

`CardUI` now implements `IAuditionHost` and adds `_auditionV3 +0xE0` and
`_auditionV3ElapsedMs +0xE4`. `MatchService` declares generation 3 and legacy
generation 2.

New TypeInfo RVAs:

| Type | b3 RVA |
|---|---:|
| `IAuditionHost` | `0x0331B190` |
| `AuditionStyle` | `0x0331AFE8` |
| `AuditionChallenge` | `0x0331BA78` |
| `AuditionStage` | `0x0331B1A8` |
| `AuditionRunner` | `0x033464A0` |

`AuditionRunner.ServerSupportsV3` is **CONFIRMED** from the exact b3 native
body. It requires a live `MatchService`, a non-empty match ID, a non-empty
server arrow list, and a non-empty layout equal to `LR` case-insensitively.
The body reads the new `MatchService` offsets `+0x278` and `+0x2A8`.

`AuditionInput.Poll` is **CONFIRMED** from native code:

| Logical input | Accepted keys |
|---|---|
| left | Left Arrow (`0x114`) or A (`0x61`) |
| right | Right Arrow (`0x113`) or D (`0x64`) |
| timing tap | Space (`0x20`), Return (`0x0D`), or keypad Enter (`0x10F`) |

Thus V2's physical Left/Right/Space capability is usable. The problem is its
state observer, not the key sender.

`AuditionChallenge` owns two lists:

```text
Display       +0x10
Expected      +0x18
DurationMs    +0x20
PerfectStart  +0x24
PerfectEnd    +0x28
Good windows +0x2C..+0x38
ReverseFrom   +0x3C
GreatMs       +0x40
multipliers   +0x44..+0x4C
ChallengeId   +0x50
```

The separate Display and Expected lists, plus `ReverseFrom` and
`AuditionChallenge.Opposite`, prove that the visible direction is not always
the direction that should be sent. A b3 adapter must consume the game's
already-built `Expected` list; it must not guess or recompute reversal from the
screenshot.

`AuditionStage.Active` is a static field at `+0x00`. Its critical instance
state is:

```text
Host           +0x10
Disposed       +0x18
Tapped         +0x19
TapElapsedMs   +0x1C
CorrectCount   +0x20
Challenge      +0x40
arrow nodes    +0x110
cursor         +0x118
qteElapsed     +0x14C
duration ms    +0x154
grade          +0x168
```

`AuditionStage.PressDir` is **CONFIRMED** to compare the submitted direction
with `Challenge.Expected[cursor]`; a correct input increments both cursor
`+0x118` and correct count `+0x20`. `TapBar` is **CONFIRMED** to mark Tapped,
clamp/store elapsed milliseconds, and invoke the host/tap callback.

`CardUI.IAuditionHost.OnAuditionPress` is **CONFIRMED** to append the received
direction to `CardUI.qtePresses +0x498` up to 64 items. It does not increment
the legacy `CardUI.currentDotIndex` or `correctDotCount`. Those legacy fields
moved to `+0x158/+0x15C`, but merely updating their offsets would still observe
the wrong progress owner for V3.

`CardUI.IAuditionHost.OnAuditionTap` stores elapsed milliseconds at `+0xE4`
and derives `currentTimeValue +0x164` after the tap. It does not supply the live
pre-tap timing cursor expected by the current V2 action loop.

`MatchService.SendQteTap(int elapsedMs)` is **CONFIRMED** to use current match
ID and challenge ID and call the new `ChatService.SendMatchQteTap` path.
Protocol strings in b3 include `MATCH_QTE_START`, `MATCH_QTE_EVENT`, and
`MATCH_QTE_TAP`. V2 must continue using normal foreground keyboard input; it
must not call these game methods directly.

### Compatibility verdict

| Area | Current V2 vs b3 |
|---|---|
| Left/Right/Space key emission | compatible as a physical input subset |
| challenge address/fields | incompatible; MatchService offsets moved and new layout fields exist |
| active QTE owner | incompatible; V3 uses `AuditionStage.Active` |
| per-direction progress | incompatible; current V2 watches legacy CardUI counters |
| live timing | incompatible; V3 owns elapsed time in AuditionStage |
| result/DTO correlation | incompatible; ChatMessageDTO fields moved and V3 adds a tap path |
| fixed seven-correct Perfect rule | incompatible; use `AuditionChallenge.Count` |
| legacy fallback | must remain; b3 explicitly retains generation 2 |

Current result: **the tool cannot safely automate a b3 legendary QTE yet**.
It may send the correct key names, but the existing closed-loop verifier will
not see authoritative progress and may stall or fail closed.

### Required dual-generation adapter

The next implementation should preserve the existing legacy observer and add
a separate Audition V3 observer selected by game-owned evidence:

1. Read `MatchService.ServerQteLayout` and require exact normalized `LR` for
   the V3 branch.
2. Resolve `AuditionStage.Active`; require a live, non-disposed stage.
3. Bind stage Host to the current CardUI and bind the stage Challenge ID to the
   current MatchService challenge and current combat session.
4. Read a stable copy of `Challenge.Expected`, `Challenge.Display`, Count,
   timing windows, `ReverseFrom`, and ChallengeId before any input.
5. Accept only `nutLeft` and `nutRight` in V3. Any other expected token fails
   closed.
6. Send one direction at a time through the existing foreground key backend.
   After each key, require cursor and CorrectCount to advance exactly once and
   require the CardUI press list to agree. Never blind-retry a direction.
7. Use `AuditionStage.qteElapsed` and the Challenge timing window to schedule
   exactly one Space. Revalidate HWND/PID/foreground/session/stage/challenge
   immediately before sending it.
8. After Space, require `Tapped=true`, a stable `TapElapsedMs`, a grade tied to
   this same stage/generation, and then a correctly offset current-session
   response or settled game state. Never send a second Space.
9. Use dynamic `Challenge.Count`; do not retain the current hard-coded
   `correct >= 7` classification rule.
10. If `LR`/active-stage evidence is absent, use the legacy generation-2 path
    only when all legacy binding invariants pass. Do not mix fields from both
    generations in one attempt.

## Implementation sequence for the next task

### P0: preserve the current checkpoint

- Keep the existing Phase 3C.1 worktree changes separate from the b3
  compatibility work.
- Record the current HEAD and dirty-file inventory before editing.
- Do not run live FarmRunner on b3 while only the b2 hash/profile is accepted.

### P1: introduce exact build profiles

- Replace scattered single-build constants with an immutable `BuildProfile`
  selected by the exact `GameAssembly.dll` fingerprint.
- Put TypeInfo RVAs, field offsets, read sizes, and feature flags in the
  profile. Keep b2 intact as a regression profile.
- Add a b3 profile from the tables in this document.
- Make every reader receive the selected profile; no module should silently
  fall back to b2 constants.

Recommended b3 feature flags:

```text
qte_generation_legacy = true
qte_generation_audition_v3 = true
qte_layout_lr = true
card_star_modifiers_present = true
guild_raid_board_fields_present = true
```

### P2: update non-QTE memory readers

- Update TypeInfo roots first.
- Update Board later fields and ordinary/Fusion card anchors.
- Update every moved MatchService field, including `_ackedSeqs` in
  `acked_sequences.py` and `Players` in `player_stats.py`.
- Update all `ChatMessageDTO` consumers together: idle state, opening snapshot,
  typed pre-board, sequence recovery, and QTE result DTO.
- Update PetUserDTO/Active pet ownership and ManagerRoom opening-flow state.
- Retain all current class checks, stable-before/after reads, exact match/turn/
  sequence binding, and fail-closed behavior.

### P3: add Settings-time fingerprint diagnostics

- Compute the fingerprint from files only.
- Show and log the exact observed hash and matched profile name.
- Persist diagnostic fingerprint data but keep compatibility acceptance in the
  reviewed manifest.
- Treat missing/changed files between Save and attach as a hard mismatch.

### P4: implement the Audition V3 observer/adapter

- Add new read-only structures for `AuditionChallenge` and `AuditionStage`.
- Keep V3 and legacy ownership/progress/timing code separate.
- Reuse the current foreground key executor and one-shot guarantees.
- Extend result vocabulary only from proven b3 grade/runtime response data.
- Add replay/unit fixtures for LR, reversed Expected input, variable Count,
  stale ChallengeId, stage replacement, wrong Host, missed timing window,
  duplicate direction, and duplicate Space.

### P5: read-only live validation

Before enabling input:

1. Confirm the calculated fingerprints against this report.
2. Resolve every critical TypeInfo and require the expected class name/shape.
3. Prove lifecycle and exact room identity from b3.
4. Capture several stable 8x8 server boards and compare them with the visible
   board without scanning the full heap during a turn.
5. Validate MatchService turn/clock/ACK fields over multiple transitions.
6. Validate normal cards, Fusion state/cost, pet identity/evolution stage, and
   star modifier fields.
7. Open one legendary QTE manually and record, without input from V2, the
   MatchService challenge, `AuditionStage.Active`, Host, Expected/Display,
   cursor, elapsed, and grade lifecycle.

### P6: input calibration and bounded live tests

1. Validate all board click centers with a zero-input overlay at canonical
   window size. Update calibration only from exact live evidence.
2. Run one controlled single-swap test and require exact server ACK plus
   matching from/to coordinates.
3. Run one default Phase 2 match and audit every local turn for a published
   board and accepted action.
4. Run one manual-assisted Audition V3 trace to confirm Expected/reversal and
   timing semantics.
5. Run one autonomous legendary-skill match with exactly one bound QTE at a
   time.
6. Only after those gates pass, run the Phase 3C.1 B1/B2 sequence and then a
   bounded multi-match regression.

### Final acceptance gates

- exact b3 fingerprint maps to exactly one profile;
- unknown hash remains blocked;
- all critical read-only singletons/classes and offsets validate live;
- visible and memory board agree for all 64 cells;
- one swap produces an exact durable ACK and coordinate match;
- no missing-board local turn and no unintended PASS;
- Fusion cost/state and pet/card capability match the UI;
- V3 uses only Left/Right and exactly one timing tap;
- cursor/CorrectCount advance once per accepted direction;
- reversed challenges follow `Expected`, not `Display`;
- no stale QTE, duplicate key, duplicate Space, or mixed-generation binding;
- terminal result and room return are classified correctly;
- the b2 hash remains rejected because the single active layout profile has
  now been intentionally moved to b3.

## Source map for future work

Current V2 locations most directly affected:

- `src/pokiguard_v2/game_location.py`
- `tools/runtime_common.py`
- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/opening_snapshot.py`
- `src/pokiguard_v2/player_stats.py`
- `src/pokiguard_v2/acked_sequences.py`
- `src/pokiguard_v2/combat_cards.py`
- `src/pokiguard_v2/native_card_ui.py`
- `src/pokiguard_v2/pet_qte_observer.py`
- `src/pokiguard_v2/pet_skill_action.py`
- `src/pokiguard_v2/boss_lobby_runtime.py`
- `tools/idle_state_watch.py`
- `tools/dispatcher_qte_result_tap.py`

Primary b3 evidence:

- `reverse/reverse_1.7.4-b3/cpp/appdata/il2cpp-types-ptr.h`
- `reverse/reverse_1.7.4-b3/cpp/appdata/il2cpp-functions.h`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/Board.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/Dot.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/Active.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/MatchService.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/ChatMessageDTO.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/BoardWsApplier.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/WsCombatBatch.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/CardUI.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/FusionCardUI.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/PetUserDTO.cs`
- `reverse/reverse_1.7.4-b3/cs/Assembly-CSharp/PokiGuard/Audition/`

The next task should treat this report as the static b3 map, then add runtime
evidence rather than repeating the initial b2-versus-b3 diff.
