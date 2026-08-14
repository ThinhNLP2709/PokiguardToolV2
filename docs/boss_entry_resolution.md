# Phase 2D.1 boss-lobby and one-shot entry resolution

Status: **PASS STRONG**. Implementation, offline validation, confirmed Stage A,
and automatic one-shot Stage B acceptance are complete. Phase 2D.1 is stopped
before gameplay as required.

## Two different boss UI flows

The previous recovery note combined two independent flows. Cpp2IL native bodies
now prove they must not be treated as one chain.

### ChinhPhuc pet-boss room (the current farm flow)

```text
ManagerChinhPhuc target selection
  -> Coop room with CurrentRoomType == "ChinhPhuc"
  -> ManagerRoom.roomData identifies the enemy pet/boss
  -> ManagerRoom.ButtonStart (visible text: Bắt Đầu)
  -> WsRoomService.StartMatch
  -> Match scene
```

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerRoom.cs`
  - static `ManagerRoom.Instance`;
  - `ButtonStart : UnityEngine.UI.Button` at instance offset `+0x28`;
  - `roomData : RoomDTO` at `+0x100`;
  - `IsOpeningRoomFlow` backing bool at `+0x125`.
- `RoomDTO.cs`
  - `enemyPetId : int` at `+0x38`;
  - `nameEnemyPetId : string` at `+0x40`;
  - `enemyPetLevel : int` at `+0x3C`.
- `ManagerRoom.txt`, native `BuildInitialBossProps()` reads
  `MatchPetIds.EPetId()` and creates `enemyPetId` room properties.
- `ManagerRoom.txt`, native `StartBattleSequence()` requires
  `Room_Handler.IsRoomOwner()`, an in-room `WsRoomService`, then calls
  `WsRoomService.StartMatch()`.
- `WsRoomService.cs`
  - `CurrentRoomId` at `+0x10`;
  - `CurrentRoomType` at `+0x18`;
  - `OwnerUsername` at `+0x20`;
  - `Properties` at `+0x38`.
- `ManagerRoom+<EnsureWsThenOpenRoom>d__54.txt` creates the room with exact
  room type `ChinhPhuc` and the `BuildInitialBossProps()` result.

This gives a strong association: the same `ManagerRoom` owns both the selected
`RoomDTO` and `ButtonStart`, while that room is bound to the current WS room.
No separate target-card click is needed after the correct room is open.

### WorldBoss list (different direct-entry flow)

```text
ManagerQuangTruong.ShowPanelBoss
  -> ManagerBoss.bossItems
  -> one BossItem owns bossData + btnFight
  -> BossItem.OnFightClicked
  -> create/join boss room + server StartMatch
  -> Match scene
```

Evidence:

- `ManagerQuangTruong.Instance` type-info RVA `0x3560D90`, with
  `_managerBoss : ManagerBoss` at `+0x350`.
- `ManagerBoss.bossItems : List<BossItem>` at `+0x70`.
- `BossItem.bossData : WorldBossDTO` at `+0x78` and `btnFight : Button` at
  `+0x48`; therefore identity and Fight ownership are on the same object.
- `WorldBossDTO` provides `id`, `petId`, `bossName`, `status` and
  `remainingAttempts` at `+0x10`, `+0x14`, `+0x18`, `+0x60`, `+0x68`.
- Native `BossItem.OnFightClicked()` accepts only `status == "ACTIVE"` and
  `remainingAttempts > 0`, persists `CurrentBossId`, `petId` and element, then
  starts `CreateBossRoomThenLoadScene()`.
- The coroutine passes exact `bossId`, `petId`, and `elementType` properties to
  `BossRoomBridge.CreateAndJoinPhoton`, waits for the server start response,
  then calls `MatchSceneLoader.StartLoad("Match")`.

There is no proven intermediate `ManagerRoom/Bắt Đầu` screen in this native
WorldBoss path. The current tool enumerates these items but refuses a WorldBoss
click because no matching live screenshot/rect calibration exists yet.

## Exact boss-lobby signals

`BOSS_LOBBY` for the accepted ChinhPhuc branch requires all of:

1. hardened base lifecycle is `LOBBY` or `STALE_SERVER_MATCH` with no local
   combat rig;
2. `ManagerRoom.Instance` class and native object are alive;
3. `roomData` is readable and has positive `enemyPetId` plus non-empty exact
   `nameEnemyPetId`;
4. `WsRoomService.CurrentRoomId` is non-empty;
5. `CurrentRoomType == "ChinhPhuc"`;
6. current room owner equals `ChatService.username` with ordinal/case-insensitive
   semantics, matching native `WsRoomService.IsHost`;
7. WS room `Properties` is non-null;
8. `ButtonStart` native object is alive, `m_Interactable == true`, and
   `m_GroupsAllowInteraction == true`;
9. `ManagerRoom.IsOpeningRoomFlow == false`;
10. two consecutive runtime samples have the same branch and target identity.

`Board.Instance == NULL` is never sufficient. A stale server match ID remains
non-actionable but does not block discovery when all clean local-room signals
above agree.

Required external classification is:

```text
BOSS_LOBBY
LOBBY_OTHER
ENTERING_COMBAT
ACTIVE_COMBAT
POSTMATCH
UNKNOWN
```

The existing hardened lifecycle remains the source for entering/active/end
states. `LOBBY_OTHER` includes a stale `ManagerRoom.roomData` without a current
WS room.

## Enumeration and identity

ChinhPhuc emits exactly one selected-room candidate:

```text
boss_id   = str(RoomDTO.enemyPetId)
boss_name = RoomDTO.nameEnemyPetId
room_id   = WsRoomService.CurrentRoomId
pet_id    = RoomDTO.enemyPetId
selected  = SELECTED
```

WorldBoss enumeration reads every entry in `ManagerBoss.bossItems`, bounded to
64 and protected by before/after list version checks. Each record logs index,
WorldBoss ID/name/pet ID, status/availability, button address and screen rect
(currently `UNKNOWN`).

Target resolution is exact only:

- configured ID: trimmed ordinal equality; ID takes priority;
- configured name: trim + Unicode NFC + `casefold`, then equality;
- no fuzzy matching, accent removal or near-name mapping;
- zero matches: `TARGET_MISSING`;
- more than one match: `TARGET_AMBIGUOUS` and no click.

The source has no hard-coded farm target. Live inspection on 2026-08-14 proved
the user's current room model contains `enemyPetId=1289`, name `Starburst`; the
CLI must still receive `--boss-id 1289` or `--boss-name Starburst` explicitly.

## Start-button proof

Identity is runtime-owned. Pixels are used only for the normal UI click point.
The dependency-free locator:

- scans the lower-center client ROI in normalized coordinates;
- groups the observed bright-cyan ornamental border on a resolution-scaled
  grid;
- requires the candidate's observed dimensions/anchor plus warm/white text;
- requires exactly one candidate and confidence at least `0.90`;
- rejects missing or multiple candidates;
- requires two frames with the same quantized structural signature;
- rejects the known symmetric two-button modal pattern;
- captures only while the game is foreground and geometry is unchanged.

It passes both read-only V1 references:

- `waiting_room.png`: point approximately `(0.6421, 0.8036)`, confidence
  `0.9623`;
- `waiting_room_with_selected_support_card.png`: point approximately
  `(0.6437, 0.8064)`, confidence `0.9640`.

These are observations, not fixed click coordinates. Live pixel coordinates are
derived from the current client dimensions immediately before input.

## One-shot identity and session acceptance

Each attempt binds:

```text
lobby epoch
exact target stable key
selection state
button detection timestamp
button structural signature
```

Immediately before input, the tool rereads lifecycle, room, target, selection,
entry component address, foreground, geometry, modal absence and visual
signature. It calls the existing foreground-only normal Windows input executor
once. There is no retry after an uncertain result.

Baseline records old match ID, session key, Board instance, srvSeq, local move
sequence and lobby epoch. A new session must have a different match ID and, if
an old local Board existed, a different Board object. MATCH_START is preloaded
during the entering window and then bound to the new provider session.

Acceptance reuses the Phase 2C opening pipeline and requires:

- current new session/match;
- source `ChatMessageDTO.MATCH_START.matchPayload.board`;
- exactly 64 production-ready cells;
- valid stable board hash and two confirmations;
- first local turn;
- `localMoveSequence == 0`;
- zero gameplay input.

The tool then emits `NEW_COMBAT_OPENING_READY` and stops. It does not import or
run BasicPolicy, card, Fusion, PASS or swap executors.

## Stale-state inspection result

Read-only inspect attempt `logs/boss_entry/20260814_233851` observed:

- hardened combat lifecycle `LOBBY`;
- old `ManagerRoom.roomData` still contained Starburst/1289;
- `WsRoomService.CurrentRoomId` and `CurrentRoomType` were null;
- classification `LOBBY_OTHER`;
- stop `ENTRY_TIMEOUT_BOSS_LOBBY`;
- entry clicks `0`, gameplay inputs `0`.

This is the expected negative proof that cached room identity alone cannot arm
an entry click.

## Live acceptance result

Stage A artifact: `logs/boss_entry/20260814_235937`.

- exact target: `enemyPetId=1289`, `Starburst`, room `Coop_772438`;
- one F8-confirmed normal UI click;
- new match `M_bdce2972`;
- opening source `ChatMessageDTO.MATCH_START.matchPayload.board`;
- `srvSeq=1`, 64 cells, two stability confirmations, first local turn and
  `localMoveSequence=0`;
- stop `NEW_COMBAT_OPENING_READY`;
- entry clicks 1; gameplay inputs, wrong-target clicks, duplicate entry clicks
  and stale-session confusions all 0.

Automatic Stage B PASS STRONG artifact: `logs/boss_entry/20260815_000202`.

- exact target and room were revalidated before input;
- locator confidence `0.954507`, normalized point approximately
  `(0.6750, 0.8113)` in the current 1280x710 client—not a fixed screen point;
- exactly one normal UI click;
- new match `M_bd9f0142`, new Board instance, accepted MATCH_START opening;
- `srvSeq=1`, 64 cells, two stability confirmations, first local turn and
  `localMoveSequence=0`;
- stop `NEW_COMBAT_OPENING_READY`;
- entry clicks 1; gameplay inputs, wrong-target clicks, duplicate entry clicks
  and stale-session confusions all 0.

The preceding Stage B attempt `logs/boss_entry/20260815_000032` intentionally
failed closed because the game was not foreground: stop
`ENTRY_TIMEOUT_BOSS_LOBBY`, entry clicks 0 and gameplay inputs 0. This is a
positive safety result, not an entry acceptance run.
