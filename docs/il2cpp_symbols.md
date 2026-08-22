# IL2CPP symbols — Phase 1

### Actual-action / idle audit addendum (Phase 2C.2A.1)

| Assembly | Namespace | Type | Member | Kind | Static | Declared type | Offset | RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `MatchService` | `_localSeqNum` | field | no | `System.Int64` | `+0xB0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `<LastMoveFromCol>k__BackingField` | field | no | `System.Int32` | `+0x1C0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `<LastMoveFromRow>k__BackingField` | field | no | `System.Int32` | `+0x1C4` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `<LastMoveToCol>k__BackingField` | field | no | `System.Int32` | `+0x1C8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `<LastMoveToRow>k__BackingField` | field | no | `System.Int32` | `+0x1CC` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `<LastMoveSeqNum>k__BackingField` | field | no | `System.Int64` | `+0x1D0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatMessageDTO` | TypeInfo global slot | metadata anchor | yes | `Il2CppClass*` after initialization | N/A | `0x350F660` | HIGH; repeated native metadata init immediately before `typeof(ChatMessageDTO)` |

`MatchService.SendMove(fromCol,fromRow,toCol,toRow)` increments `_localSeqNum`,
copies it to `LastMoveSeqNum`, writes the four coordinates, then calls
`WsMatchClient.SendMove`. Evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt:10437-10555`.
These are durable evidence of the last **client SendMove request**, not by
themselves proof that the server accepted the swap or the turn on which an old
value occurred. The constructor initializes FromCol, ToCol and LastMoveSeqNum
to the `-1` sentinel (`MatchService.txt:19056-19066`); readers treat coordinates
as absent until the sequence is positive.

Field declarations are in
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:265,332-340`;
trivial getter/setter native bodies are in
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt:10337-10435`.

The `ChatMessageDTO` anchor evidence is repeated in
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService.txt`, for example
`:18197-18217`, `:18592-18612`, and `:19578-19593`. It is used only for bounded
read-only evidence collection; transient DTO heap residue is not accepted as
durable current state.

> **Phase 2A addendum (2026-08-11):** Cpp2IL ISIL now confirms the complete
> `Dot` instance layout, `allDots` native indexing, DTO snapshot flow, and the
> additional type-info anchors documented in the final sections below. Earlier
> `UNKNOWN` entries are retained as milestone history and are superseded where
> an addendum row provides direct native evidence.

> **Phase 1.5 update (2026-08-11):** The original Diffable C#/plain dummy-DLL
> limitation below was overcome by generating Cpp2IL ISIL and an
> `attributeinjector` output from the same read-only game files. The following
> native values are now verified for the current SHA-256-bound build:
>
> | Type/member | Original token | Native/global RVA | Verified access |
> |---|---:|---:|---|
> | `Board.get_Instance` | `0x06001BE3` | method `0x5B25C0`; type-info slot `0x3508B28` | `[slot] -> class + 0xB8 -> static_fields + 0x10` |
> | `Active.get_Instance` | `0x06001B08` | method `0x56B350`; type-info slot `0x34FADB0` | `[slot] -> class + 0xB8 -> static_fields + 0x00` |
> | `ManagerMatch.Awake` / `Instance` | `0x060022B3` / field `0x0400210D` | method `0x624DD0`; type-info slot `0x3560A90` | `[slot] -> class + 0xB8 -> static_fields + 0x00` |
>
> Full disassembly evidence, TypeDef tokens, runtime pointers, and live combat
> validation are recorded in
> [`static_singleton_resolution.md`](static_singleton_resolution.md). Treat broad
> "all native RVAs UNKNOWN" statements in the historical Phase 1 text below as
> applying only to the earlier outputs available at that milestone.

## Quy ước evidence

- Assembly của các type dưới đây: `Assembly-CSharp`.
- Namespace: global namespace, đúng theo comment `//Type is in global namespace` của
  Diffable C#.
- Offset field instance là offset trong managed IL2CPP object được Cpp2IL reconstruct.
- Offset field static là offset trong static-fields storage của chính `Il2CppClass`, **không
  phải RVA và không được cộng trực tiếp vào GameAssembly base**.
- `N/A` nghĩa là loại member đó không có field offset. `UNKNOWN` nghĩa là output hiện có
  không xác minh được.
- Diffable C# không chứa annotation native RVA. Dummy DLL đã được inspect: method bodies là
  stub (ví dụ `Board.Awake` chỉ có 1 byte IL) và không có address attribute, nên PE RVA của
  dummy DLL không phải native RVA trong `GameAssembly.dll`. Vì vậy toàn bộ method RVA dưới
  đây được ghi `UNKNOWN`, không đoán.

Confidence `CONFIRMED` nghĩa là exact declaration/offset có trực tiếp trong Cpp2IL output;
`HIGH` là kết luận cấu trúc từ nhiều declaration phù hợp; `MEDIUM` là semantics hợp lý nhưng
method body không được reconstruct.

## Board

Evidence chính: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:919-1111`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | Board | `<Instance>k__BackingField` | field | yes | `Board` | `0x10` (Board static-fields) | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `Instance` | property | yes | `Board` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | Board | `dots` | field | no | `UnityEngine.GameObject[]` | `0x70` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `currentState` | field | no | `GameState` | `0x78` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `width` | field | no | `System.Int32` | `0x88` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `height` | field | no | `System.Int32` | `0x8C` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `allDots` | field | no | `UnityEngine.GameObject[,]` | `0x140` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `active` | field | no | `Active` | `0x158` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `isCascadeRunning` | field | no | `System.Boolean` | `0x170` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `selectedCards` | field | no | `System.Collections.Generic.List<CardData>` | `0x2F8` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `cardsInHand` | field | no | `System.Collections.Generic.List<UnityEngine.GameObject>` | `0x300` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `isBoardReady` | field | no | `System.Boolean` | `0x348` | N/A | CONFIRMED |
| Assembly-CSharp | global | Board | `Awake()` | method | no | `System.Void ()` | N/A | UNKNOWN | CONFIRMED signature |

`GameState` là enum global ở
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/GameState.cs`: `wait = 0`, `move = 1`.

Cpp2IL ISIL tại
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt` còn xác minh thứ tự tạo
UI: `DisplayCardsOnBoard` duyệt `selectedCards`, `EnsureFusionCards` thêm Fusion,
và `AddFusionSkillCard` thêm skill riêng của pet sau cùng. Đây là evidence dùng
để xác minh thành phần/thứ tự tạo, không tự nó chứng minh thứ tự hiển thị.
Quan sát live riêng cho loadout pet chuẩn xác minh Fusion nằm ngoài cùng bên
trái và các thẻ thường giữ nguyên thứ tự `selectedCards` ở phía sau. Layout có
skill riêng của pet hiện được đánh dấu DEFERRED và fail-closed, không suy đoán.

### `allDots` so với `dots`

- `allDots` là managed rectangular two-dimensional array `GameObject[,]`, instance offset
  `0x140`. Đây là candidate grid runtime.
- `dots` là one-dimensional `GameObject[]`, instance offset `0x70`. Declaration và các
  helper tên `FindDotPrefabByTag`/`SpawnDotByTag` cho thấy nó là collection object/prefab,
  không phải chính 8x8 grid; semantics prefab được đánh confidence MEDIUM vì method bodies
  trống.
- Exact array index order (`[col,row]` hay `[row,col]`) chưa được method body xác minh:
  **UNKNOWN**. Các API liên quan ưu tiên tham số `(col,row)`, nhưng Phase 1 không dùng điều
  đó để đoán layout. Khi có runtime reader phải đối chiếu với `Dot.column`/`Dot.row`.
- Layout native chính xác của IL2CPP rectangular array trên Unity 6000.0.26f1 chưa được
  output hiện tại cung cấp: **UNKNOWN**.

## Dot

Evidence: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Dot.cs:1-204`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | Dot | `column` | field | no | `System.Int32` | `0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | Dot | `row` | field | no | `System.Int32` | `0x24` | N/A | CONFIRMED |
| Assembly-CSharp | global | Dot | `_board` | field | no | `Board` | `0x48` | N/A | CONFIRMED |
| Assembly-CSharp | global | Dot | `multiplier` | field | no | `System.Int32` | `0x88` | N/A | CONFIRMED |
| Assembly-CSharp | global | Dot | `RequestSwap(int,int,int,int)` | method | no | `System.Void (System.Int32 fromCol, System.Int32 fromRow, System.Int32 toCol, System.Int32 toRow)` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | Dot | `BoardWidth` | property | no | `System.Int32` (private getter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | Dot | `BoardHeight` | property | no | `System.Int32` (private getter) | N/A | UNKNOWN | CONFIRMED |

Không có field `tag` trên `Dot`. Gem tag nằm ở layer `GameObject`/snapshot:
`BoardCellDTO.tag` là string; `BoardWsApplier` có `FindDotPrefabByTag`, `SpawnDotByTag`, và
nhận `tag` làm tham số. Việc đọc `GameObject.tag` cụ thể cần Unity object/component access
và chưa được implement. Kết luận “Dot chứa field tag” là sai.

## BoardCellDTO

Evidence: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs:1-13`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | BoardCellDTO | `col` | field | no | `System.Int32` | `0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardCellDTO | `row` | field | no | `System.Int32` | `0x14` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardCellDTO | `tag` | field | no | `System.String` | `0x18` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardCellDTO | `multiplier` | field | no | `System.Int32` | `0x20` | N/A | CONFIRMED |

Không tìm thấy top-level type `BoardCell`; type xác minh được là `BoardCellDTO`.

## BoardWsApplier

Evidence fields/methods:
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs:754-958`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | BoardWsApplier | `board` | field | no | `Board` | `0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardWsApplier | `_bootstrappedMatchId` | field | no | `System.String` | `0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardWsApplier | `_cachedDotsParentOwner` | field | no | `Board` | `0x48` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardWsApplier | `_pendingBatches` | field | no | `Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>>` | `0x50` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardWsApplier | `_renderRunning` | field | no | `System.Boolean` | `0x58` | N/A | CONFIRMED |
| Assembly-CSharp | global | BoardWsApplier | `LoadBoardFromSnapshot(Dictionary<String,Object>)` | method | no | `System.Collections.IEnumerator` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `LoadBoardFromSnapshotCore(Dictionary<String,Object>)` | method | no | `System.Collections.IEnumerator` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `ApplySwap(MatchOpDTO)` | method | no | `System.Void` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `ApplyFall(MatchOpDTO)` | method | no | `System.Void` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `ApplySpawn(MatchOpDTO)` | method | no | `System.Void` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `VerifyBoardAgainstServer(BoardCellDTO[][])` | method | no | `System.Int32` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | BoardWsApplier | `EnsureBoardRef()` | method | no | `System.Void` | N/A | UNKNOWN | CONFIRMED signature |

`BoardWsApplier` không có singleton/static instance field trong output. Nó giữ direct
reference tới `Board`, nhưng source object của component này chưa resolve được externally.

Phase 2A.5 xác minh type-info global slot của `BoardWsApplier` ở preferred VA
`0x183508D40`, build RVA `0x3508D40`, từ native metadata initialization trong
các method của chính type. External watcher chỉ chấp nhận object có exact
runtime `Il2CppClass*`, inherited `m_CachedPtr` canonical, và `board +0x20`
trỏ đúng current `Board.Instance`.

## MatchService / match state

Evidence:
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:180-355`, property declarations
ở lines 506-959, method declarations ở lines 1022-1552.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | MatchService | `<Instance>k__BackingField` | field | yes | `MatchService` | `0x0` (MatchService static-fields) | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `Instance` | property | yes | `MatchService` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `<CurrentMatchId>k__BackingField` | field | no | `System.String` | `0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `CurrentMatchId` | property | no | `System.String` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `<BoardWidth>k__BackingField` | field | no | `System.Int32` | `0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `BoardWidth` | property | no | `System.Int32` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `<BoardHeight>k__BackingField` | field | no | `System.Int32` | `0x34` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `BoardHeight` | property | no | `System.Int32` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `<CurrentTurnPlayer>k__BackingField` | field | no | `System.String` | `0x38` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `CurrentTurnPlayer` | property | no | `System.String` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `<TurnNumber>k__BackingField` | field | no | `System.Int32` | `0x40` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchService | `TurnNumber` | property | no | `System.Int32` (public getter, private setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | MatchService | `SendMove(int,int,int,int)` | method | no | `System.Void (System.Int32 fromCol, System.Int32 fromRow, System.Int32 toCol, System.Int32 toRow)` | N/A | UNKNOWN | CONFIRMED signature |
| Assembly-CSharp | global | MatchService | `<ServerStats>k__BackingField` | field | no | `Dictionary<System.String, MatchService.ServerPlayerStats>` | `0x1A0` | N/A | CONFIRMED |

Không có `RequestSwap` trên `MatchService`; member đó được xác minh là private instance
method của `Dot`. Không có direct `Board` field trên `MatchService` trong declaration hiện
có. Phase 1 không gọi bất kỳ method move nào.

## Active và PlayerStats

Không có top-level `PlayerStats.cs`. Type cần chú ý là nested
`Active.PlayerStats` trong `Active.cs`; ngoài ra còn một type khác
`ActivePVP.PlayerStats`, không dùng cho bảng boss/co-op này.

Evidence: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Active.cs:482-516` và
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ObfuscatedInt.cs:1-45`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | Active | `<Instance>k__BackingField` | field | yes | `Active` | `0x0` (Active static-fields) | N/A | CONFIRMED |
| Assembly-CSharp | global | Active | `Instance` | property | yes | `Active` (public getter, internal setter) | N/A | UNKNOWN | CONFIRMED |
| Assembly-CSharp | global | Active | `playerStatsMap` | field | no | `Dictionary<System.Int32, Active.PlayerStats>` | `0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active | `playerStatsList` | field | no | `List<Active.PlayerStats>` | `0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active | `board` | field | no | `Board` | `0x38` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `actorNumber` | field | no | `System.Int32` | `0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `currentHP` | field | no | `ObfuscatedInt` | `0x14` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `maxHP` | field | no | `ObfuscatedInt` | `0x24` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `currentMana` | field | no | `ObfuscatedInt` | `0x34` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `maxMana` | field | no | `ObfuscatedInt` | `0x44` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `currentPower` | field | no | `ObfuscatedInt` | `0x54` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `maxPower` | field | no | `ObfuscatedInt` | `0x64` | N/A | CONFIRMED |
| Assembly-CSharp | global | Active.PlayerStats | `shield` | field | no | `ObfuscatedInt` | `0x84` | N/A | CONFIRMED |

`ObfuscatedInt` là value type 16 byte gồm `_stored`, `_keyA`, `_keyB`, `_noise` ở offsets
`0x0/0x4/0x8/0xC`. Cpp2IL output hiện không có method body đủ để reconstruct chắc chắn
`Value`; Phase 1 không giải mã hay đọc stats runtime bằng cách đoán.

`MatchService.ServerPlayerStats` là nested class khác với plain `Int32` fields:
`HP 0x10`, `MaxHP 0x14`, `Mana 0x18`, `MaxMana 0x1C`, `Power 0x20`,
`MaxPower 0x24`, `Shield 0x28`. Nó được giữ trong `MatchService.ServerStats`.

## ManagerMatch

Evidence: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerMatch.cs:261-339`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | ManagerMatch | `Instance` | field | yes | `ManagerMatch` | `0x0` (ManagerMatch static-fields) | N/A | CONFIRMED |
| Assembly-CSharp | global | ManagerMatch | `active` | field | no | `Active` | `0x130` | N/A | CONFIRMED |
| Assembly-CSharp | global | ManagerMatch | `isBossBattle` | field | no | `System.Boolean` | `0x138` | N/A | CONFIRMED |

`ManagerMatch` không có direct `Board` field; chain xác minh theo declarations là
`ManagerMatch.Instance -> active -> Active.board`.

## UNKNOWN/blocker tại cuối Phase 1

1. Native method RVA cho toàn bộ target methods: UNKNOWN.
2. RVA/global pointer từ `GameAssembly.dll` tới `Il2CppClass` của `Board`, `Active`,
   `MatchService`, `ManagerMatch`: UNKNOWN.
3. Native layout/static_fields pointer chain cho Unity 6000 / metadata 31.1: chưa được
   output hiện có xác minh.
4. Exact runtime index order và native layout của `GameObject[,] allDots`: UNKNOWN.
5. Cách external reader lấy `Dot` component và `GameObject.tag` chỉ bằng
   `ReadProcessMemory`: UNKNOWN.
6. Decode `ObfuscatedInt.Value`: UNKNOWN từ output diffable hiện tại.

## Phase 2A — complete `Dot` instance layout

Assembly `Assembly-CSharp`, global namespace, original TypeDef token
`0x020003E5`. Every field below is an instance field reconstructed by Cpp2IL;
tokens and offsets are from the attributed output and Diffable C#.

| Member | Original field token | Exact declared type | Offset | Relevance |
|---|---:|---|---:|---|
| `column` | `0x04001CF9` | `System.Int32` | `+0x20` | Board coordinate |
| `row` | `0x04001CFA` | `System.Int32` | `+0x24` | Board coordinate |
| `previousColumn` | `0x04001CFB` | `System.Int32` | `+0x28` | Animation/move state |
| `previousRow` | `0x04001CFC` | `System.Int32` | `+0x2C` | Animation/move state |
| `targetX` | `0x04001CFD` | `System.Single` | `+0x30` | Animation target |
| `targetY` | `0x04001CFE` | `System.Single` | `+0x34` | Animation target |
| `isMathched` | `0x04001CFF` | `System.Boolean` | `+0x38` | Match animation flag (spelling is exact) |
| `swipeResit` | `0x04001D00` | `System.Single` | `+0x3C` | Input threshold |
| `swipeAngle` | `0x04001D01` | `System.Single` | `+0x40` | Input state |
| `_board` | `0x04001D02` | `Board` | `+0x48` | Strong heap fingerprint |
| `_boardPVP` | `0x04001D03` | `BoardPVP` | `+0x50` | PVP route, out of scope |
| `_active` | `0x04001D04` | `Active` | `+0x58` | Combat owner reference |
| `_activePVP` | `0x04001D05` | `ActivePVP` | `+0x60` | PVP route, out of scope |
| `otherDot` | `0x04001D06` | `UnityEngine.GameObject` | `+0x68` | Temporary swap peer |
| `firstTouchPosition` | `0x04001D07` | `UnityEngine.Vector2` | `+0x70` | Input state |
| `finalTouchPosition` | `0x04001D08` | `UnityEngine.Vector2` | `+0x78` | Input state |
| `tempPosition` | `0x04001D09` | `UnityEngine.Vector2` | `+0x80` | Animation state |
| `multiplier` | `0x04001D0A` | `System.Int32` | `+0x88` | Cell multiplier |
| `multiplierTextMesh` | `0x04001D0B` | `TMPro.TextMeshPro` | `+0x90` | UI reference only |
| `velocityX` | `0x04001D0C` | `System.Single` | `+0x98` | Motion state |
| `velocityY` | `0x04001D0D` | `System.Single` | `+0xA0` | Motion state |
| `positionSmoothVelocity` | `0x04001D0E` | `UnityEngine.Vector2` | `+0xA8` | Motion state |
| `_isFalling` | `0x04001D14` | `System.Boolean` | `+0xB0` | Cascade state |
| `_fallDelay` | `0x04001D15` | `System.Single` | `+0xB4` | Fall animation |
| `_fallDur` | `0x04001D16` | `System.Single` | `+0xB8` | Fall animation |
| `_fallElapsed` | `0x04001D17` | `System.Single` | `+0xBC` | Fall animation |
| `_fallStartPos` | `0x04001D18` | `UnityEngine.Vector2` | `+0xC0` | Fall animation |
| `_baseScale` | `0x04001D19` | `UnityEngine.Vector3` | `+0xC8` | Visual state |
| `_baseScaleCaptured` | `0x04001D1A` | `System.Boolean` | `+0xD4` | Visual state |
| `originalPrefab` | `0x04001D1B` | `UnityEngine.GameObject` | `+0xD8` | Best persistent gem identity clue; not a tag |
| `isPredictionSwap` | `0x04001D1C` | `System.Boolean` | `+0xE0` | Prediction visual state |
| `predictedTargetX` | `0x04001D1D` | `System.Single` | `+0xE4` | Prediction visual state |
| `predictedTargetY` | `0x04001D1E` | `System.Single` | `+0xE8` | Prediction visual state |
| `predictionStartTime` | `0x04001D1F` | `System.Single` | `+0xEC` | Prediction visual state |

Inherited evidence: `UnityEngine.Object.m_CachedPtr : System.IntPtr` is at
`+0x10` in `UnityEngine.CoreModule/UnityEngine/Object.cs`. Phase 2A uses only a
non-zero canonical value as an active-object validation signal; it does not
traverse undocumented native Unity object layout.

No field above is a tag, color, sprite, element enum, or gem-type string.
`originalPrefab` is the only direct structural identity field likely to remain
stable by gem type.

Relevant native methods for this build:

| Member | Original method token | RVA | Verified finding |
|---|---:|---:|---|
| `Dot.GetAllDots(int col,int row)` | `0x06001E4B` | `0x5DBB40` | Reads `Board+0x140`; index is `col * second_dimension_length + row`; data begins `array+0x20` |
| `Dot.Start()` | `0x06001E52` | `0x5DCBC0` | Initializes live component references/state |
| `Dot.UpdateBoardReference()` | `0x06001E5B` | `0x5DD1F0` | Refreshes Board ownership reference |

`Dot` type-info global slot is preferred VA `0x183526020`, build RVA
`0x3526020`. `Dot.cctor` reads that slot; Phase 2A resolves it read-only and
requires each candidate object's first qword to equal the exact runtime
`Dot Il2CppClass*`.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Dot.cs:1-204`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Dot.txt`
- `reverse/cpp2il_attributed/Assembly-CSharp.dll`
- `reverse/cpp2il_cs/DiffableCs/UnityEngine.CoreModule/UnityEngine/Object.cs`

## Phase 2A — DTO and service native additions

| Type/member | Kind | Static | Exact declared type | Offset | Original token | RVA / global RVA | Confidence |
|---|---|---:|---|---:|---:|---:|---|
| `WsCombatBatch.srvSeq` | field | no | `System.Int64` | `+0x10` | `0x04000BFD` | N/A | CONFIRMED |
| `WsCombatBatch.board` | field | no | `BoardCellDTO[][]` | `+0x38` | `0x04000C02` | N/A | CONFIRMED |
| `WsCombatBatch` type info | global slot | yes | `Il2CppClass*` | N/A | TypeDef `0x0200018C` | `0x35354A0` | HIGH, native allocation path |
| `MatchService.<PendingCombat>k__BackingField` | field | no | `WsCombatBatch` | `+0x170` | — | N/A | CONFIRMED |
| `MatchService.<CurrentMatchId>k__BackingField` | field | no | `System.String` | `+0x20` | N/A | N/A | CONFIRMED |
| `BoardWsApplier._bootstrappedMatchId` | field | no | `System.String` | `+0x30` | N/A | N/A | CONFIRMED; current renderer/match correlation |
| `MatchService` type info | global slot | yes | `Il2CppClass*` | N/A | TypeDef `0x02000182` | `0x3562340` | HIGH |
| `MatchService.get_Instance()` | method | yes | `MatchService ()` | N/A | `0x06000E33` | `0x4A7540` | HIGH |
| `MatchService.get_PendingCombat()` | method | no | `WsCombatBatch ()` | N/A | `0x06000EB0` | `0x4A77A0` | HIGH |
| `MatchService.set_PendingCombat(WsCombatBatch)` | method | no | `System.Void` | N/A | `0x06000EB1` | `0x4A8A50` | HIGH |
| `MatchService.ConsumePendingCombat()` | method | no | `WsCombatBatch ()` | N/A | `0x06000EB2` | `0x4A0EC0` | HIGH; reads then clears `+0x170` |
| `MatchService.ParseCombatBatch(...)` | method | no | `WsCombatBatch` | N/A | `0x06000EB3` | `0x4A3070` | HIGH; materializes `BoardCellDTO[][]` at batch `+0x38` |

## Phase 2A — `allDots` object relationship

Native `BoardWsApplier.SpawnDotByTag` proves the relationship without assuming
`GameObject* == Dot*`:

1. instantiate selected prefab as a `GameObject`;
2. get its `Dot` component;
3. write `Dot.originalPrefab`, `Dot.column`, `Dot.row`, and optional multiplier;
4. store the instantiated owner GameObject into `Board.allDots` using the same
   `col * second_dimension_length + row` index.

Thus Phase 2A can correlate the two independently found sets by the proven
coordinate/index relation. It cannot derive the `Dot*` by dereferencing an
undocumented `GameObject` native layout, and does not attempt to do so.

## Phase 2A.5 additional combat-card symbols

Evidence is recorded in detail in `docs/card_state_detection.md`.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method/global RVA | Confidence |
|---|---|---|---|---:|---:|---|---:|---:|---|
| Assembly-CSharp | global | `MatchService` | `FusionEnabled` backing field | field | no | `System.Boolean` | `+0x54` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `FusionManaCost` backing field | field | no | `System.Int32` | `+0x58` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `FusionStatPercent` backing field | field | no | `System.Int32` | `+0x5C` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionUsed` backing field | field | no | `System.Boolean` | `+0x60` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionLastAttemptTurn` backing field | field | no | `System.Int32` | `+0x64` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionSelectedUserPetId` backing field | field | no | `System.Int64` | `+0x68` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionSelectedPetId` backing field | field | no | `System.Int64` | `+0x70` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionSkillCard` backing field | field | no | `CardData` | `+0x78` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `LocalFusionDropReason` backing field | field | no | `System.String` | `+0x80` | N/A | CONFIRMED |
| Assembly-CSharp | global | `FusionCardUI` | type-info global slot used by its own metadata initializer | global | yes | `Il2CppClass*` | N/A | `0x35332A0` | HIGH; native `RefreshState` metadata init |
| Assembly-CSharp | global | `FusionCardUI` | `_btn` | field | no | `UnityEngine.UI.Button` | `+0x58` | N/A | CONFIRMED |
| Assembly-CSharp | global | `FusionCardUI` | `_nextRefreshAt` | field | no | `System.Single` | `+0x60` | N/A | CONFIRMED |
| Assembly-CSharp | global | `FusionCardUI` | `_boundPetId` | field | no | `System.Int64` | `+0x68` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | type-info global slot | global | yes | `Il2CppClass*` | N/A | `0x350E0D0` | HIGH; native static accessor |
| Assembly-CSharp | global | `CardUI` | `cardData` | field | no | `CardData` | `+0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `btn` | field | no | `UnityEngine.UI.Button` | `+0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `board` | field | no | `Board` | `+0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `active` | field | no | `Active` | `+0x38` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `hasUsedThisMatch` | field | no | `System.Boolean` | `+0x40` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `hasUsedThisTurn` | field | no | `System.Boolean` | `+0x41` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `lastTurnUsed` | field | no | `System.Int32` | `+0x44` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `isActionPending` | field | no | `System.Boolean` | `+0x48` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardUI` | `isPlaceholder` | field | no | `System.Boolean` | `+0x78` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerRoom` | `selectedCards` | field | no | `System.Collections.Generic.List<CardData>` | `+0x108` | N/A | CONFIRMED; pre-entry lobby loadout |
| Assembly-CSharp | global | `RoomDTO` | `cards` | field | no | `System.Collections.Generic.List<CardData>` | `+0x50` | N/A | CONFIRMED; room-synchronised pre-entry loadout |
| Assembly-CSharp | global | `CardData` | `cardId` | field | no | `System.Int64` | `+0x18` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `description` | field | no | `System.String` | `+0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `elementTypeCard` | field | no | `System.String` | `+0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `value` / `maxLevel` / `count` / `level` | fields | no | `System.Int32` | `+0x38/+0x3C/+0x40/+0x44` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `conditionUse` / `power` | fields | no | `System.Int64` | `+0x48/+0x50` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `green` / `blue` / `red` / `yellow` / `white` / `purple` | fields | no | `System.Int32` | `+0x58..+0x6C` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `damageMultiplier` | field | no | `System.Single` | `+0x70` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `skillType` | field | no | `System.String` | `+0x78` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `manaCost` | field | no | `System.Int32` | `+0x80` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `powerCost` / `cooldownTurns` | fields | no | `System.Int32` | `+0x84/+0x88` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `needPerfection` | field | no | `System.Boolean` | `+0x8C` | N/A | CONFIRMED |
| Assembly-CSharp | global | `CardData` | `eatPerfect` / `eatGood` / `eatBad` | fields | no | `System.Int32` | `+0x90/+0x94/+0x98` | N/A | CONFIRMED |
| UnityEngine.UI | UnityEngine.UI | `Selectable` | `m_Interactable` | field | no | `System.Boolean` | `+0xD8` | N/A | CONFIRMED |

Pre-entry loadout evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerRoom.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/RoomDTO.cs`

These two fields contain persistent `CardData` selections and are deliberately
not treated as proof of a live combat `CardUI`. The latter still requires the
current `Board@+0x30`, `Active@+0x38`, Unity object and Button validation.

## Phase 2B — `ObfuscatedInt` native decode addendum

Direct Cpp2IL native/ISIL evidence supersedes the earlier Phase 1 UNKNOWN for
`ObfuscatedInt.Value`:

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `ObfuscatedInt` | `_stored` | field | no | `System.Int32` | `+0x0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ObfuscatedInt` | `_keyA` | field | no | `System.Int32` | `+0x4` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ObfuscatedInt` | `_keyB` | field | no | `System.Int32` | `+0x8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ObfuscatedInt` | `_noise` | field | no | `System.Int32` | `+0xC` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ObfuscatedInt` | `get_Value()` | method | no | `System.Int32 ()` | N/A | `0x52FC80` | HIGH, complete native getter |

Getter formula: `int32((RotateRight32(_stored, _keyA & 31) XOR _keyB) -
_keyA)`. Constructor and setter prove the inverse encoding. `_noise` is not
read by the getter. Evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ObfuscatedInt.txt`. Full analysis
and external-reader validation rules are in `docs/player_stats_resolution.md`.

Additional exact runtime anchor: `Active.PlayerStats` type-info preferred VA
`0x18354A9B0`, build RVA `0x354A9B0`, used by the native allocation in
`Active.InitializeStatsFromWsSnapshot`. `Active.SyncStatsListForInspector`
proves the concrete `List<PlayerStats>` layout read by Phase 2B: list items
`+0x10`, size `+0x18`, version `+0x1C`, backing-array length `+0x18`, and data
`+0x20`. Confidence: HIGH, direct native method bodies in
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt`.

## Phase 2B.5 — ACK sequence currentness witness

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `MatchService` | `_ackedSeqs` | field | no | `System.Collections.Generic.HashSet<System.Int64>` | `+0x180` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `SendAnimAck` | method | no | `System.Void (System.Int64 srvSeq)` | N/A | UNKNOWN | HIGH behavior; RVA not recorded |
| Assembly-CSharp | global | `MatchService` | `ApplyMatchInitFromMessage` | method | no | `System.Void (ChatMessageDTO m)` | N/A | UNKNOWN | HIGH behavior; RVA not recorded |

`SendAnimAck` reads `_ackedSeqs` at `this+0x180`, calls
`HashSet<Int64>.Contains(srvSeq)`, inserts a positive unseen sequence, clears
the set when its count exceeds 64, re-adds the current sequence, and passes the
same `srvSeq` to `WsMatchClient.SendAnimDone`. `ApplyMatchInitFromMessage` reads
the same field and clears it during every new match initialization. This makes
membership match-scoped evidence that the client completed rendering that
server sequence; it is not treated as a pointer to the batch.

The runtime-instantiated `HashSet<Int64>` layout used by the read-only decoder
was validated as: buckets `+0x10`, slots `+0x18`, count `+0x20`, lastIndex
`+0x24`, freeList `+0x28`, version `+0x38`; an `Int64` slot is 16 bytes
`(Int32 hashCode, Int32 next, Int64 value)`. The generic Diffable C# does not
carry useful concrete offsets, so these values come from the System.Core native
HashSet bodies and were runtime cross-checked by decoding 49 unique sequences
after a completed match. The external reader validates counters, capacity,
slot occupancy, uniqueness, and a stable header before returning values.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:317,1022,1385`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `SendAnimAck` and `ApplyMatchInitFromMessage`
- ``reverse/cpp2il_cs/DiffableCs/System.Core/System/Collections/Generic/HashSet`1.cs``
- ``reverse/cpp2il_isil/IsilDump/System.Core/System/Collections/Generic/HashSet`1.txt``

## Phase 2C.1 actionability additions

These fields are read only to reproduce the client's own permission, ownership,
connection and end-state checks. Method RVAs below remain `UNKNOWN` where this
Phase did not independently recover a build RVA; no RVA is inferred from method
order.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method/global RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `Board` | `currentState` | field | no | `GameState` | `+0x78` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `hasDestroyedThisTurn` | field | no | `System.Boolean` | `+0x125` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isMega2PanelOpen` | field | no | `System.Boolean` | `+0x129` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isProcessingUI` | field | no | `System.Boolean` | `+0x1D0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isGameOver` | field | no | `System.Boolean` | `+0x2A8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isUsingLegendCard` | field | no | `System.Boolean` | `+0x349` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isUsingMega` | field | no | `System.Boolean` | `+0x350` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isResuming` | field | no | `System.Boolean` | `+0x368` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `isMega1PanelOpen` | field | no | `System.Boolean` | `+0x408` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `txtResultTitle` | field | no | `UnityEngine.UI.Text` | `+0x270` | N/A | CONFIRMED |
| Assembly-CSharp | global | `Board` | `IsPlayerAllowedToMove()` | method | no | `System.Boolean ()` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `MatchService` | `HasServerClock` backing field | field | no | `System.Boolean` | `+0x128` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `ClockPaused` backing field | field | no | `System.Boolean` | `+0x129` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `ClockPauseReason` backing field | field | no | `System.String` | `+0x130` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_inFlightBatches` | field | no | `System.Int32` | `+0x178` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_matchOver` | field | no | `System.Boolean` | `+0x1B2` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_resyncCoroutine` | field | no | `UnityEngine.Coroutine` | `+0x1B8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_deferredWinner` | field | no | `System.String` | `+0x220` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_hasDeferredGameOver` | field | no | `System.Boolean` | `+0x228` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `get_IsStartGatePaused()` | method | no | `System.Boolean ()` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `MatchService` | `IsLocalTurn()` | method | no | `System.Boolean ()` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `MatchService` | `HandleMatchGameOver(ChatMessageDTO)` | method | no | `System.Void (ChatMessageDTO)` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `BoardWsApplier` | `HandleGameOver(String)` | method | no | `System.Void (System.String)` | N/A | UNKNOWN | HIGH; complete native body |
| UnityEngine.UI | `UnityEngine.UI` | `Text` | `m_Text` | field | no | `System.String` | `+0xE8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | type-info global slot | global | yes | `Il2CppClass*` | N/A | `0x350F718` | HIGH |
| Assembly-CSharp | global | `ChatService` | `_instance` | field | yes | `ChatService` | static `+0x0` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `isConnected` | field | no | `System.Boolean` | `+0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `username` | field | no | `System.String` | `+0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `_explicitDisconnect` | field | no | `System.Boolean` | `+0x286` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `_reconnectCoroutine` | field | no | `UnityEngine.Coroutine` | `+0x288` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `_connecting` | field | no | `System.Boolean` | `+0x294` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `get_Instance()` | method | yes | `ChatService ()` | N/A | UNKNOWN | HIGH; complete native body |

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:945-1141,1441`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`,
  `IsPlayerAllowedToMove`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:285-354,1135,1250,1280`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `get_IsStartGatePaused`, `HandleMatchGameOver`, and `IsLocalTurn`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs:860`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt:16799`,
  `HandleGameOver`
- `reverse/cpp2il_cs/DiffableCs/UnityEngine.UI/UnityEngine/UI/Text.cs:12`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatService.cs:143-151,297-300,1131`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService.txt`, `get_Instance`

Terminal-result semantics are also native-proven. `HandleMatchGameOver` first
requires the message MatchId to equal `CurrentMatchId`, reads the exact
`matchPayload["winner"]` value, sets `_matchOver`, and either raises game-over
immediately or freezes that string in `_deferredWinner` until presentation is
idle. `BoardWsApplier.HandleGameOver` treats an exact local
`ChatService.username` winner as local WIN, and exact `"__BOSS__"` or
`"BOSS"` as local LOSS. Other strings remain UNKNOWN in the external reader.
The result-title field is retained only as secondary UI audit evidence.

### Turn countdown addendum

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `MatchService` | `TurnDurationSec` backing field | field | no | `System.Int32` | `+0x44` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `TurnTimeRemainingSec` backing field | field | no | `System.Int32` | `+0x118` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_clockRemainAtAnchorSec` | field | no | `System.Single` | `+0x138` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_clockAnchorUnscaled` | field | no | `System.Single` | `+0x13C` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `_localFxHoldUntilUnscaled` | field | no | `System.Single` | `+0x158` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `get_ServerTurnRemainingSec()` | method | no | `System.Single ()` | N/A | UNKNOWN | HIGH; complete native getter |
| Assembly-CSharp | global | `MatchService` | `HandleMatchTimerTick(ChatMessageDTO)` | method | no | `System.Void (ChatMessageDTO)` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `MatchService` | `ApplyTimingFields(Dictionary<String,Object>)` | method | no | `System.Void (System.Collections.Generic.Dictionary<System.String,System.Object>)` | N/A | UNKNOWN | HIGH; complete native body |

`HandleMatchTimerTick` updates current turn player `+0x38`, turn number `+0x40`,
duration `+0x44` and remaining seconds `+0x118`, then calls
`ApplyTimingFields`. That method reads server `turnRemainingMs`, pause state and
pause reason, stores the floating-point remaining anchor at `+0x138` and Unity
`Time.unscaledTime` at `+0x13C`. `get_ServerTurnRemainingSec` reproduces the
smooth client countdown and clamps to the configured duration.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:213-220,285-303,920-941,1038,1223,1268`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `ApplyTimingFields`, `get_ServerTurnRemainingSec`, and
  `HandleMatchTimerTick`

### Consecutive-pass / AFK addendum (Phase 2C.2A)

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `MatchService` | `OnAfkWarn` | event backing field | no | `System.Action<System.String,System.Int32,System.Int32>` | `+0xF8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `HandleMatchAfkWarn(ChatMessageDTO)` | method | no | `System.Void (ChatMessageDTO)` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `ChatMessageDTO` | `matchPayload` | field | no | `System.Collections.Generic.Dictionary<System.String,System.Object>` | `+0xC8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ChatService` | `messageHistory` | field | no | `System.Collections.Generic.List<ChatMessageDTO>` | `+0x38` | N/A | CONFIRMED |
| Assembly-CSharp | global | `WsPlayerStateDTO` | `passed` | field | no | `System.Int32` | `+0x40` | N/A | CONFIRMED field; combat skip semantics UNKNOWN |
| Assembly-CSharp | global | `Board` | `requestPass` | field | no | `System.Int32` | `+0x2C8` | N/A | CONFIRMED field; rejected as combat skip counter |

`HandleMatchAfkWarn` verifies `matchId`, ignores the event after match-over,
reads `idleCount` with default 0 and `threshold` with default 3 from
`ChatMessageDTO.matchPayload`, then invokes `OnAfkWarn(username, idleCount,
threshold)` only when `idleCount > 0`. The complete native body does **not**
store either integer in `MatchService`.

The websocket dispatch closure routes `MATCH_AFK_WARN` directly to its event
delegate. Its only `messageHistory` append/trim path is in the world/team chat
branches, not `MATCH_AFK_WARN`. `BoardWsApplier.HandleAfkWarn` consumes the
three event arguments to display the local warning and also stores no counter.
Therefore the current read-only provider has no durable game-owned
consecutive-pass value and publishes it as `UNKNOWN`.

Rejected lookalikes:

- `WsPlayerStateDTO.passed +0x40` is owned through
  `WsRoomService.PlayerStates`; no Cpp2IL/native evidence ties it to
  `MATCH_AFK_WARN.idleCount` or the combat reset rule.
- `Board.requestPass +0x2C8` is initialized from `PlayerPrefs.GetInt(
  "requestPass", 5)` in `Board.Start`; it is a configuration/request value,
  not the consecutive AFK count.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:283,1246`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `HandleMatchAfkWarn`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs:23`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatService.cs:152`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService_NestedType___c__DisplayClass240_0.txt`,
  `MATCH_AFK_WARN` dispatch and history branches
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt`,
  `HandleAfkWarn`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/WsPlayerStateDTO.cs:14`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/WsRoomService.cs:19,220`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`, `Start`

### Chinh Phuc map target addendum (Phase 2D.6)

These members support read-only association of a configured Chinh Phuc pet
with its ordinary map `Button`. They do not authorize direct method calls or
memory writes.

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `ManagerChinhPhuc` | `panels` | field | no | `UnityEngine.GameObject[]` | `+0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc` | `buttons` | field | no | `UnityEngine.UI.Button[]` | `+0x30` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc` | `cachedPetData` | field | no | `System.Collections.Generic.List<GroupDTO>` | `+0x98` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `lockedForClick` | field | no | `System.Boolean` | `+0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `lockedOrderForClick` | field | no | `System.Int32` | `+0x14` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `requiredAttack` | field | no | `System.Int32` | `+0x18` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `petId` | field | no | `System.Int32` | `+0x1C` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `reA` | field | no | `System.String` | `+0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc.<>c__DisplayClass38_0` | `<>4__this` | field | no | `ManagerChinhPhuc` | `+0x28` | N/A | CONFIRMED |
| Assembly-CSharp | global | `GroupDTO` | `id` | field | no | `System.Int32` | `+0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | `GroupDTO` | `name` | field | no | `System.String` | `+0x18` | N/A | CONFIRMED |
| Assembly-CSharp | global | `GroupDTO` | `listPetEnemy` | field | no | `PetEnemyDTO[]` | `+0x20` | N/A | CONFIRMED |
| Assembly-CSharp | global | `PetEnemyDTO` | `id` | field | no | `System.Int32` | `+0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | `PetEnemyDTO` | `name` | field | no | `System.String` | `+0x18` | N/A | CONFIRMED |
| Assembly-CSharp | global | `PetEnemyDTO` | `locked` | field | no | `System.Boolean` | `+0x35` | N/A | CONFIRMED |
| Assembly-CSharp | global | `ManagerChinhPhuc` | `OnReceived(List<GroupDTO>)` | method | no | `System.Void (System.Collections.Generic.List<GroupDTO>)` | N/A | UNKNOWN | HIGH; complete native body |
| Assembly-CSharp | global | `ManagerChinhPhuc` | `EnsureHuntOrderBadge(Transform,Int32,Boolean,Boolean)` | method | no | `System.Void (UnityEngine.Transform,System.Int32,System.Boolean,System.Boolean)` | N/A | UNKNOWN | HIGH; complete native body |

`OnReceived` stores its input at `cachedPetData +0x98`, gets each panel's
Button components, pairs each button index with the same `PetEnemyDTO[]` index,
creates one `<>c__DisplayClass38_0`, copies the exact pet ID/lock/requirement
values into it, and adds its `<OnReceived>b__0` delegate to the Button click
event. It also calls `EnsureHuntOrderBadge` with `pet index + 1`.
`EnsureHuntOrderBadge` loads the displayed digit sprites from
`Image/petK/number/number_A_*`. Thus the button closure is identity evidence;
the visible digit is only a separately checked hunt-order locator.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerChinhPhuc.cs:69-80,332-356,401,428`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/GroupDTO.cs:3-7`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/PetEnemyDTO.cs:3-15`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ManagerChinhPhuc.txt`,
  `OnReceived` and `EnsureHuntOrderBadge`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ManagerChinhPhuc_NestedType___c__DisplayClass38_0.txt`,
  `<OnReceived>b__0`

Current live validation for the configured Phase 2D.6 target resolved exactly
one unlocked/interactable closure with `petId=1289`, cached group index 5 and
pet index 7 (hunt order 8), matching the three read-only PlayerPrefs keys.
Runtime addresses are deliberately not documented as stable symbols because
they are process/session allocations and subject to ASLR and Unity lifetime.
