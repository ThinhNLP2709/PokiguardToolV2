# IL2CPP symbols — Phase 1

## Pokiguard 1.7.4-b4 default-runtime symbols — 2026-09-14

Exact build gate: `GameAssembly.dll` SHA-256
`D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`.
Preferred image base is `0x180000000`; all values below are RVAs.

| Type | b4 TypeInfo RVA | Key current fields |
|---|---:|---|
| `Board` | `0x033558A0` | `allDots +0x150`; `active +0x168`; card container/selection/hand `+0x330/+0x348/+0x350`; ready/legend/mega/resume/Mega1 `+0x398/+0x399/+0x3A0/+0x3B8/+0x478` |
| `Dot` | `0x03359050` | column/row/Board/multiplier `+0x20/+0x24/+0x48/+0x88`; falling/prediction/squashing `+0xB0/+0xE0/+0xFC`; `PoolTag +0x100`; `RenderHidden +0x131` |
| `Active` | `0x03355698` | `board +0x38`; `playerPets +0x300` |
| `Active.PlayerStats` | `0x033415B0` | b3 offsets unchanged |
| `ManagerMatch` | `0x03350170` | `active +0x130`; `isBossBattle +0x138` |
| `MatchService` | `0x0334A100` | b3 turn/Fusion/ACK/desync/QTE/terminal offsets unchanged |
| `ChatService` | `0x03349A90` | fields consumed by V2 unchanged; new `_authProbeRunning +0x2EC` follows them |
| `ChatMessageDTO` | `0x0335B9A8` | b3 transport, move/card/skill/QTE and pre-board offsets unchanged |
| `BoardWsApplier` | `0x03349D48` | `board +0x20`; pending queue `+0x60`; render flag `+0x68` |
| `WsCombatBatch` | `0x0335F580` | sequence/board fields unchanged |
| `CardUI` | `0x0334A080` | ordinary/default-card fields unchanged |
| `FusionCardUI` | `0x03386C78` | button/refresh/pet ID `+0x60/+0x68/+0x70` |
| `CardData` | `0x03386C80` | identity/cost fields unchanged |
| `PetUserDTO` | `0x0336C5A8` | evolution stage `+0x78`; card data `+0x98` |
| `TurnAnnouncer` | `0x03349E00` | static blocking/deadline `+0x80/+0x84` |
| `UnityMainThreadDispatcher` | `0x0335BC08` | pending List/Queue TypeInfo `0x033665E0/0x03366628` |
| `ChatService.<>c__DisplayClass275_0` | `0x0335BAB8` | raw JSON/message ownership fields unchanged |

Lobby/lifecycle TypeInfo RVAs are `MatchSceneLoader=0x0334B8E8`,
`MatchHost=0x0334BB28`, `HubSuspendManager=0x03349AD8`,
`ManagerQuangTruong=0x0334C3A8`, `ManagerRoom=0x0334A068`, and
`WsRoomService=0x03366060`. Newtonsoft roots are
`JArray=0x033482F0`, `JObject=0x033482E8`, `JProperty=0x0337AD08`, and
`JValue=0x033663A0`.
The corresponding inherited instance fields are confirmed as
`JArray._values +0x50`, `JObject._properties +0x50`, and
`JProperty._content +0x50`; the earlier `+0x58` decoder values were invalid.

Native b4 evidence: `Component.get_gameObject` cache
`GameAssembly+0x355F678`, wrapper RVA `0x027E9DA0`, unchanged resolved
UnityPlayer function RVA `0x1067390`, and unmarshal branch signature at
`GameAssembly+0x10971EF`. Declarations and exact installed bytes are
**CONFIRMED**. A zero-input b4 lobby probe resolved every provider TypeInfo root
listed above plus lobby/lifecycle singletons without read errors; live Board
instance fields remain **PENDING** until combat. See the
[b4 compatibility report](pokiguard_1.7.4_b4_compatibility_report.md).

The exact b4 signature at `+0x10971EF` contains relative-call displacement
`BF E4 16 FF` (b3 used `0F C9 17 FF`). This was rechecked against both the
installed PE RVA mapping and read-only live process memory after the first
combat fail-closed on the stale displacement. A later live attempt accepted
three complete native 64-Dot boards with the b4 fields and zero rejection.

## Cân Đẩu Vân 1.7.4-b3 audit — 2026-09-13

Build-specific static evidence; this addendum concerns only the mini game.
The installed DLL hash was rechecked against the b3 reverse provenance.

| Type | Member | b3 field offset / method RVA | Evidence confidence |
|---|---|---|---|
| `CanDauVanApi.RollReq` | `rollSeq`, `t`, `s` | `+0x10`, `+0x18`, `+0x20` | CONFIRMED declarations and native request construction |
| `CanDauVanApi` | `Roll(int, Action<CanDauVanRollResult>, Action<string>)` | RVA `0x3214B0` | HIGH; native JSON POST with typed response |
| `APIConfig` | `CAN_DAU_VAN_ROLL(int)` | RVA `0x85EFE0` | CONFIRMED; URL format `{0}/api/can-dau-van/{1}/roll` |
| `CanDauVanPanel` | `OnRollTap`, `OnRollOk`, `TryPlay`, `PlayRoll` | RVAs `0x351740`, `0x351C90`, `0x351C00`, `0x352220` | HIGH; native request, response and rendering flow |
| `CanDauVanPanel` | `_state`, `_diceDone`, `_pendingRoll`, `_lastDice` | `+0x188`, `+0x1B1`, `+0x1B8`, `+0x1C0` | CONFIRMED declarations and native accesses |
| `CanDauVanRollResult` | `dice`, `toPos`, `path` | `+0x20`, `+0x30`, `+0x38` | CONFIRMED; native `PlayRoll` reads response fields |
| `CanDauVanState` | `player`, `ApplyRoll(CanDauVanRollResult)` | `+0x48`, RVA `0x3449E0` | CONFIRMED; native copies result into player state |
| `CanDauVanPlayer` | `pos`, `rollSeq` | `+0x28`, `+0x2C` | CONFIRMED declarations and native accesses |
| `CanDauVanFx` | `DiceRoll(...)` | RVA `0x32EDF0` | HIGH; visual effects and completion callback |

The server response supplies the effective dice and destination; the client
animates that result. Server RNG, seed, weighting and generation timing are
**UNKNOWN**. This audit does not establish a live memory root or runtime owner
lifetime for the mini game.

Evidence: [authority report](can_dau_van_roll_authority.md), b3
`cs/Assembly-CSharp/CanDauVan*.cs`, `APIConfig.cs`, `il2cpp.json`, and
[annotated native disassembly](../reference/can_dau_van_1.7.4_b3_native.txt).

## Current 1.7.4-b2 semantic correction — B4, 2026-09-10

`Board.isUsingLegendCard : System.Boolean`, instance +0x391, remains a verified
field, but **true does not imply current QTE execution**. Native
`CardUI.SetLegendMultiplier(float) : void` (instance, RVA 0x6D0370) writes it
true at RVA 0x6D03D8 through `CardUI.board +0x30`. B4 observed it still true
after the proven inactive QTE edge and multiple later local turns. The fast
Pet Skill hand reader must not hide the card on this flag alone. Offset/body
and runtime evidence are in `phase3b3_native_card_evidence.md`, B4 addendum;
global reset lifetime is UNKNOWN. Earlier modal interpretation below is
historical, not a confirmed current-skill actionability predicate.

## Current 1.7.4-b2 addendum — 2026-09-07

This addendum supersedes earlier 1.7.4 RVA/offset values for the currently
installed build. Exact evidence is in `reverse/reverse_1.7.4-b2/cs` and
`reverse/reverse_1.7.4-b2/il2cpp.json`; preferred image base is
`0x180000000`. Runtime addressing remains `GameAssembly.base + RVA`.

| Type | TypeInfo RVA | Key current fields |
|---|---:|---|
| `Board` | `0x2DA5890` | `allDots +0x150`; `isGameOver +0x2E0`; `cardContainer +0x328`; `selectedCards +0x340`; `cardsInHand +0x348`; `isBoardReady +0x390`; `isUsingLegendCard +0x391`; `isUsingMega +0x398`; `isResuming +0x3B0`; `isMega1PanelOpen +0x470` |
| `Active` | `0x2D96E60` | `board +0x38`; `playerPets +0x310` |
| `ManagerMatch` | `0x2D947D0` | `active +0x130`; `isBossBattle +0x138` |
| `MatchService` | `0x2D96548` | Fusion block `+0x60..+0x90`; `Players +0xB8`; `_localSeqNum +0xC0`; turn remaining `+0x138`; pending/acked `+0x1A8/+0x1B8`; QTE arrows/duration/window/challenge ID `+0x220/+0x228/+0x22C/+0x250` |
| `TurnAnnouncer` | `0x2DDAE68` | static `_blocking +0x80`; static `_blockDeadline +0x84`; `IsBlockingInput` RVA `0x3D3870`; `HARD_BLOCK_SEC=3` |
| `CardUI` | `0x2DAB7F0` | ordinary head `cardData/button/board/active = +0x20/+0x28/+0x30/+0x38`; `isPlaceholder +0x80`; QTE fields `+0x58..+0x498`, including `_qteArrowsFromServer +0x498`, as detailed in the current compatibility report |
| `BoardWsApplier` | `0x2DA5B70` | `board +0x20`; pending batches `+0x60`; render running `+0x68` |
| `Dot` | `0x2DCC268` | core fields used by the provider unchanged |
| `WsCombatBatch` | `0x2DEB350` | core sequence/board fields used by the provider unchanged |
| `FusionCardUI` | `0x2DD97E8` | fields used by the tool unchanged |
| `Active.PlayerStats` | `0x2DFD1A0` | player stat fields used by the tool unchanged |
| `PetUserDTO` | `0x2DA86D0` | fields used by the QTE identity reader unchanged |
| `CardData` | `0x2DAB070` | card identity/cost fields used by the tool unchanged |
| `UnityMainThreadDispatcher` | `0x2DE08F8` | static `_instance +0x00`; static `_executionQueue +0x08`; instance `_drainBuffer +0x20`; `Update` RVA `0x3D5730` |
| `Queue<UnityMainThreadDispatcher.PendingAction>` | `0x2DE5D48` | `_array +0x10`; `_head +0x18`; `_tail +0x1C`; `_size +0x20`; `_version +0x24` |
| `List<UnityMainThreadDispatcher.PendingAction>` | `0x2DDB970` | `_items +0x10`; `_size +0x18`; `_version +0x1C` |
| `ChatService.__c__DisplayClass275_0` | `0x2D97A60` | `__this +0x10`; `json +0x18`; `message +0x20`; callback RVA `0x38EBB0` |
| `ChatMessageDTO` | `0x2DAD0B0` | `type +0x30`; `matchId +0xB0`; `matchPayload +0xC8`; `preBoard +0x3C8`; `preBoardReady +0x3D0` |
| `MatchPayloadPreparser` | N/A | `PrepareBoard` RVA `0x3919D0`; `Prepare` RVA `0x392610`; `ShouldPrepare` RVA `0x3926C0` |

Additional current TypeInfo RVAs: `ChatService=0x2DAD230`,
`ChatMessageDTO=0x2DAD0B0`, `MatchHost=0x2D95F88`,
`MatchSceneLoader=0x2D96490`, `HubSuspendManager=0x2DE3C78`,
`ManagerQuangTruong=0x2D94AB0`, `ManagerRoom=0x2D94C20`, and
`WsRoomService=0x2DEB6E8`. The new dump also proves MatchHost static `State`
at `+0x04` (CurrentRig remains `+0x10`) and the current boss-room shifts
`panelChinhPhuc +0x2C0`, `_managerBoss +0x3E0`, and
`ManagerRoom._IsOpeningRoomFlow +0x148`.

Confidence: **CONFIRMED** for declarations/offsets and JSON TypeInfo mappings;
**HIGH** for the native TypeInfo use verified against current runtime method
bytes. Old values below remain milestone history only.

### Phase 2 b2 turn/transport evidence — 2026-09-11

The installed hash-gated `GameAssembly.dll` body for
`Board.IsPlayerAllowedToMove` (RVA `0x6AD340`) contains the exact call to
`TurnAnnouncer.get_IsBlockingInput` at RVA `0x3D3870`. The getter reads the
static `_blocking` flag and checks `_blockDeadline` against Unity unscaled time;
`TurnAnnouncer.Runner.Update` clears the flag after expiry. The external
provider therefore follows TypeInfo `0x2DDAE68 -> Il2CppClass.static_fields
+0x98 -> _blocking +0x80` and blocks conservatively while true. It does not
call the getter or read/invent an unproved Unity clock pointer.

The same b2 reverse set confirms the transport capture chain used by the Phase
2 repair: `ChatService.__c__DisplayClass275_0` keeps `json +0x18` and the exact
deserialized `ChatMessageDTO +0x20`. `ChatMessageDTO` adds typed
`preBoard +0x3C8` and `preBoardReady +0x3D0`. Read-only native disassembly of
`ChatService.OnWebSocketMessage` proves calls to
`MatchPayloadPreparser.ShouldPrepare` RVA `0x3926C0` and `Prepare` RVA
`0x392610` before `UnityMainThreadDispatcher.TryEnqueue`; `PrepareBoard` is RVA
`0x3919D0`. This is the primary b2 recovery when raw JSON is not the legacy 8x8
shape and `matchPayload` no longer exposes `board/srvSeq`. A missing callback
remains possible, so current-ACK heap recovery is bounded once per exact gap.

Run `c756bbc90fc64366802c7df3ade5f4ba` observed exactly such a missing callback:
ACK reached 14 while the tap retained only sequence 6 and 10 boards. The b2
declarations also prove `MatchService._PendingCombat_k__BackingField +0x1A8`
is `WsCombatBatch`, while `BoardWsApplier._pendingBatches +0x60` is
`Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>>`. The current
read-only tap samples both roots at 1 ms, double-checks current MatchId and/or
owner/queue identity around the strict batch read, and leaves exact ACK gating
to the provider. These are direct typed-root reads only; no target method is
called and no memory is written.

Evidence files: `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/TurnAnnouncer.cs`,
`Board.cs`, `ChatMessageDTO.cs`, `MatchPayloadPreparser.cs`, `WsCombatBatch.cs`,
`cpp/appdata/il2cpp-types-ptr.h`, plus read-only bytes from the exact installed
DLL. Confidence: **CONFIRMED** for fields/RVAs and **HIGH** for the native
control-flow interpretation.

Native `ChatService.OnWebSocketMessage` RVA `0x37C940` stores the deserialized
DTO at closure `+0x20` (`0x37CA8C`) before calling
`UnityMainThreadDispatcher.TryEnqueue(Action,bool)` (`0x37CCEC`, callee RVA
`0x3D5620`). `System.Delegate.m_target` is declared at delegate-field `+0x10`,
therefore object offset `+0x20`; `PendingAction` is a 16-byte value with Action
at `+0x00` and bool Heavy at `+0x08`. Evidence:
`reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/ChatService.cs`,
`UnityMainThreadDispatcher.cs`, `il2cpp.h`,
`cpp/appdata/il2cpp-types-ptr.h`, and read-only native disassembly of the
installed hash-gated `GameAssembly.dll`. Confidence: **CONFIRMED** for declared
types/offsets/RVAs, **HIGH** for the native ownership/control-flow reading.

## Current 1.7.4 addendum — Phase 3B.3 (2026-09-04)

New skill creation, native Unity component ownership, scripting-handle
conversion and current RectTransform evidence are recorded in
[phase3b3_native_card_evidence.md](phase3b3_native_card_evidence.md).
These native offsets are signature-gated and must not be confused with managed
Cpp2IL fields or reused for an unverified UnityPlayer build. Live automatic B1
for the corrected path remains pending.

QTE deadline fields, server-window application, coroutine timeout and timing
predicate were rechecked against 1.7.4 native code after B1 retry 6. Exact
assembly/type/member/offset/RVA/source/confidence and the build hash are in
[phase3b3_qte_timing_evidence.md](phase3b3_qte_timing_evidence.md). The external
reader uses those existing runtime fields; no game methods are invoked.

The fresh 1.7.4-b2 audit also confirms `MatchService.ServerQteChallengeId`
(`long`, instance, `+0x250`), `CardUI.CurrentQteChallengeId()` (instance method,
RVA `0x6C5950`), `CardUI._qteArrowsFromServer` (`bool`, instance, `+0x498`),
and `ChatMessageDTO.qteChallengeId` (`long?`, instance, `+0x148`). Exact native
flow and the unchanged key/timing rules are recorded in
[phase3b3_qte_timing_evidence.md](phase3b3_qte_timing_evidence.md).

Retry 8 addendum in the same evidence file records current
`MatchService._ServerQteArrows_k__BackingField` (+0x200, `List<string>`) and
`CardUI._HandleDotSkillSequence_d__159._qteWait_5__6` (+0x44, `float`), with
native coroutine wait RVAs and its verified float constant. The coroutine
constant is evidence only, not a new external sleep or guessed ready signal.

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
| Assembly-CSharp | global | Board | `_leftActorNumbers` | field | no | `System.Collections.Generic.HashSet<System.Int32>` | `0x2B0` | N/A | CONFIRMED; runtime actor `1` observed after client player-left state |
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

Đoạn kết luận cũ của Phase 1 rằng Dot không có tag chỉ đúng với reverse cũ. Bản
1.7.4-b2 thêm backing field `Dot._PoolTag_k__BackingField : string` tại `+0xF8`.
Native `BoardWsApplier.SpawnDotByTag` RVA `0x358A30` lấy đúng Dot component của
GameObject mới tạo, ghi tham số `tag` vào `Dot+0xF8`, rồi ghi `column +0x20`,
`row +0x24`, `originalPrefab +0xD8` và `multiplier +0x88`. Vì vậy b2 có một
Gem-tag source trực tiếp trên component render; nó không phải `GameObject.tag`.

Các field ổn định/chuyển động dùng cho production fallback b2:

| Type | Field | Offset | Confidence |
|---|---|---:|---|
| `Dot` | `column`, `row` | `+0x20`, `+0x24` | CONFIRMED declaration/native writes |
| `Dot` | `_board` | `+0x48` | CONFIRMED declaration |
| `Dot` | `multiplier` | `+0x88` | CONFIRMED declaration/native write |
| `Dot` | `_isFalling` | `+0xB0` | CONFIRMED declaration |
| `Dot` | `isPredictionSwap` | `+0xE0` | CONFIRMED declaration |
| `Dot` | `_squashing` | `+0xF4` | CONFIRMED declaration |
| `Dot` | `_PoolTag_k__BackingField` | `+0xF8` | CONFIRMED declaration/native write |
| `Dot` | `_RenderHidden_k__BackingField` | `+0x129` | CONFIRMED declaration |

External reader không ép `GameObject* == Dot*`. Nó đi theo
`Board.allDots -> managed GameObject +0x10 -> native GameObject component list ->
native scripting handle -> managed Dot`, kiểm tra exact class và roundtrip ở
mỗi bước. Unity native offsets chỉ được bật khi tất cả code signatures khớp
binary hiện hành.

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
| Assembly-CSharp | global | MatchService | `<Players>k__BackingField` | field | no | `Dictionary<System.String, MatchPlayerSnapshotDTO>` | `0xA8` | N/A | CONFIRMED |
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
| Assembly-CSharp | global | Active | `LocalActorNumberOrZero` | property | no | `System.Int32` (internal getter) | N/A | `0x56B3D0` getter | CONFIRMED |
| Assembly-CSharp | global | Active | `board` | field | no | `Board` | `0x38` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchPlayerSnapshotDTO | `username` | field | no | `System.String` | `0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | MatchPlayerSnapshotDTO | `actorNumber` | field | no | `System.Int32` | `0x18` | N/A | CONFIRMED |
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

`Active.get_LocalActorNumberOrZero` được xác minh thêm từ
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt`: nhánh ưu tiên đọc
`ChatService.Username`, lookup `MatchService.Players`, rồi trả về
`MatchPlayerSnapshotDTO.actorNumber +0x18`. Đây là ownership evidence dùng để
phân biệt người chơi với một PlayerStats không-boss bổ sung của pet tiến hóa;
không hard-code actor `1`.

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
| Assembly-CSharp | global | `MatchService` | `_ackedSeqs` | field | no | `System.Collections.Generic.HashSet<System.Int64>` | b2 `+0x1B8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `SendAnimAck` | method | no | `System.Void (System.Int64 srvSeq)` | N/A | b2 `0x399300` | CONFIRMED declaration; HIGH native behavior |
| Assembly-CSharp | global | `MatchService` | `HandleResEnvelope` | method | no | `System.Void (ChatMessageDTO m, System.String kind)` | N/A | b2 `0x396A70` | CONFIRMED declaration; HIGH native behavior |
| Assembly-CSharp | global | `MatchService` | `ApplyMatchInitFromMessage` | method | no | `System.Void (ChatMessageDTO m)` | N/A | b2 `0x392F50` | CONFIRMED declaration; HIGH native behavior |
| Assembly-CSharp | global | `MatchService._AckStuckGuard_d__287` | `MoveNext` | method | no | `System.Boolean ()` | N/A | b2 `0x3A2DF0` | CONFIRMED declaration; HIGH native behavior |

Current b2 `SendAnimAck` reads `_ackedSeqs` at `this+0x1B8`, calls
`HashSet<Int64>.Contains(srvSeq)`, inserts a positive unseen sequence, clears
the set when its count exceeds 64, re-adds the current sequence, and passes the
same `srvSeq` to `WsMatchClient.SendAnimDone`. `ApplyMatchInitFromMessage` reads
the same field and clears it during every new match initialization. This makes
membership match-scoped evidence that the client completed rendering that
server sequence; it is not treated as a pointer to the batch or proof that a
same-sequence full-board DTO exists. `HandleResEnvelope` applies incremental
`ops` and can reach `SendAnimAck` for a response without a replacement 8x8
board. The provider therefore uses ACK as a presentation watermark and, for
such a gap, double-samples the complete current Board-owned Dot grid.

For a work-bearing batch, `BeginAnimAck` starts `AckStuckGuard`. Its native
state machine waits `max(6, ServerAckDeadlineSec - 1.5)` seconds when the server
deadline is positive, otherwise 9 seconds. If the sequence is still absent, it
decrements the in-flight count and calls `SendAnimAck`. Thus an ACK may be
delayed while rendering, but once inserted it is retained until a new-match
clear or the greater-than-64 rollover; that rollover immediately retains the
newest sequence.

The runtime-instantiated `HashSet<Int64>` layout used by the read-only decoder
was validated as: buckets `+0x10`, slots `+0x18`, count `+0x20`, lastIndex
`+0x24`, freeList `+0x28`, version `+0x38`; an `Int64` slot is 16 bytes
`(Int32 hashCode, Int32 next, Int64 value)`. The generic Diffable C# does not
carry useful concrete offsets, so these values come from the System.Core native
HashSet bodies and were runtime cross-checked by decoding 49 unique sequences
after a completed match. The external reader validates counters, capacity,
slot occupancy, uniqueness, and a stable header before returning values.

Evidence:

- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/MatchService.cs`
- read-only disassembly of the installed b2 `GameAssembly.dll` at the RVAs in
  the table above
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

### 1.7.4-b4 general-hub Chinh Phuc return addendum

These b4 members identify the normal hub control used only after a proven
detached Chinh Phuc room shell has lost all server room ownership. The tool
reads their live Unity ownership and geometry; it does not call
`OpenChinhPhucPanel`.

| Assembly | Type | Member | Kind | Exact declared type | b4 field offset / RVA | Confidence |
|---|---|---|---|---|---:|---|
| Assembly-CSharp | `ManagerQuangTruong` | `Instance` | field | `ManagerQuangTruong` | static | CONFIRMED |
| Assembly-CSharp | `ManagerQuangTruong` | `panelChinhPhuc` | field | `UnityEngine.GameObject` | `+0x2C0` | CONFIRMED |
| Assembly-CSharp | `ManagerQuangTruong` | `btnChinhPhuc` | field | `UnityEngine.UI.Button` | `+0x2C8` | CONFIRMED |
| Assembly-CSharp | `ManagerQuangTruong` | `OpenChinhPhucPanel()` | method | `System.Void` | `0x9BE480` | CONFIRMED declaration/RVA; never invoked by the tool |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `lockedForClick` | field | `System.Boolean` | `+0x10` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `islandLockMsg` | field | `System.String` | `+0x18` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `lockedOrderForClick` | field | `System.Int32` | `+0x20` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `requiredAttack` | field | `System.Int32` | `+0x24` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `petId` | field | `System.Int32` | `+0x28` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `reA` | field | `System.String` | `+0x30` | CONFIRMED |
| Assembly-CSharp | `ManagerChinhPhuc.<>c__DisplayClass41_0` | `<>4__this` | field | `ManagerChinhPhuc` | `+0x38` | CONFIRMED |

Evidence:

- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ManagerQuangTruong.cs:123-131`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ManagerQuangTruong.cs:1463-1469`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ManagerChinhPhuc.cs:181-205`

The normal-input point is derived from the manager-owned Button's managed to
native roundtrip, owning GameObject, active cache, first RectTransform
component and stable root Canvas path. `panelChinhPhuc` must be inactive while
the Button is active, interactable and allowed by its CanvasGroup. Two stable
samples and a captured-region sanity check are required before the click.
The Chinh Phuc button's b4 idle animation changes only native TRS translation;
live run-48 evidence measured about 0.29 px during one ownership walk. The
reader therefore allows at most 1 px translation movement for this hub control
while rotation, scale, ownership and active state remain exact. The older
Phase 2D.6 `<>c__DisplayClass38_0` offsets above are historical pre-b4 evidence
and are not used for the verified b4 executable.

### 1.7.4-b4 Chinh Phuc target display metadata

The desktop UI reads target metadata from the persistent service below. This
path is read-only and does not perform the native `Button` scan used by the
re-entry executor.

| Assembly | Type | Member | Kind | Exact declared type | b4 field offset / RVA | Confidence |
|---|---|---|---|---|---:|---|
| Assembly-CSharp | `ChinhPhucDataService` | `Instance` | field | `ChinhPhucDataService` | TypeInfo RVA `0x333DF98`, static field `+0x00` | CONFIRMED reverse and live read |
| Assembly-CSharp | `ChinhPhucDataService` | `Data` | field | `List<GroupDTO>` | `+0x20` | CONFIRMED reverse and live read |
| Assembly-CSharp | `PetEnemyDTO` | `lever` | field | `System.Int32` | `+0x20` | CONFIRMED reverse and live read |
| Assembly-CSharp | `PetEnemyDTO` | `leverDisplay` | field | `System.Int32` | `+0x24` | CONFIRMED reverse and live read |

The live Starburst row resolved `petId=1289`, internal `lever=10`, displayed
`leverDisplay=73`, group ID 6 and group name `Tam giới Tinh`. The UI therefore
uses `leverDisplay`; it never exposes the pet ID in its target label.

The b4 `level2` scene serializes island controls as `btnIsland{id}`. Their child
Text labels establish the display-only group-ID mapping: 1 `Mộc tinh`, 2
`Hỏa tinh`, 3 `Thủy tinh`, 4 `Thổ tinh`, 5 `Kim tinh`, 6 `Đảo rồng`, 7
`Thập nhị tinh`, 8 `Hộ vệ`, 9 `Bóng đêm`, 10 `Thánh thú`, 11 `Titan`, 12
`12 con giáp`, 13 `Thần thoại`, 14 `Thời gian`, 15 `Băng giá`, 16 `Thần Giới`,
17 `Khế Ước`, and 18 `Đảo Liên Minh`. Unknown group IDs omit the island label.
This mapping is presentation data only; target selection and navigation remain
derived from the exact live `GroupDTO`/`PetEnemyDTO` association.

Evidence:

- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ChinhPhucDataService.cs:18-30`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/PetEnemyDTO.cs:16-20`
- read-only serialized scene inspection of
  `Pokiguard-1.7.4_Data/level2`, `btnIsland1` through `btnIsland18`
- read-only live probe of `ChinhPhucDataService.Data` for pet 1289

### 1.7.4-b2 Legend-card continuation audit addendum (Phase 3C.0)

| Assembly | Type | Member | Kind | Exact declared type | b2 field offset / RVA | Confidence |
|---|---|---|---|---|---:|---|
| Assembly-CSharp | `Board` | `isUsingLegendCard` | field | `System.Boolean` | `+0x391` | CONFIRMED declaration and live read layout |
| Assembly-CSharp | `Board` | `isUsingMega` | field | `System.Boolean` | `+0x398` | CONFIRMED declaration and live read layout |
| Assembly-CSharp | `Board` | `isMega2PanelOpen` | field | `System.Boolean` | `+0x129` | CONFIRMED declaration and live read layout |
| Assembly-CSharp | `Board` | `isMega1PanelOpen` | field | `System.Boolean` | `+0x470` | CONFIRMED declaration and live read layout |
| Assembly-CSharp | `CardUI` | `SetLegendMultiplier(float)` | method | `System.Void (System.Single)` | RVA `0x6D0370` | CONFIRMED declaration/RVA; reset semantics UNKNOWN |

The Cpp2IL b2 C# output declares the fields and method range but does not
contain a body that proves when the Legend flag returns to false. Phase 3C.0
therefore records its live value before deciding whether it is a current modal
signal or a durable match-level state. No reset rule is inferred from the name.

Evidence:

- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/Board.cs`
- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/CardUI.cs`

### Redux 1.7.4 skill-response combat envelope addendum (Phase 3B.3)

| Assembly | Namespace | Type | Member | Kind | Static | Exact declared type | Field offset | Method RVA | Confidence |
|---|---|---|---|---|---:|---|---:|---:|---|
| Assembly-CSharp | global | `ChatMessageDTO` | `matchPayload` | field | no | `Dictionary<string, object>` | `+0xC8` | N/A | CONFIRMED |
| Assembly-CSharp | global | `MatchService` | `HandleMatchSkillUseRes(ChatMessageDTO)` | method | no | `System.Void` | N/A | `0x337B50` | HIGH; complete native wrapper |
| Assembly-CSharp | global | `MatchService` | `HandleResEnvelope(ChatMessageDTO,string)` | method | no | `System.Void` | N/A | `0x338540` | HIGH; complete native body |
| Assembly-CSharp | global | `MatchService` | `ParseCombatBatch(ChatMessageDTO,string)` | method | no | `WsCombatBatch` | N/A | `0x338AE0` | HIGH; complete native body |
| Assembly-CSharp | global | `WsCombatBatch` | `srvSeq` | field | no | `System.Int64` | `+0x10` | N/A | CONFIRMED |
| Assembly-CSharp | global | `WsCombatBatch` | `board` | field | no | `BoardCellDTO[][]` | `+0x38` | N/A | CONFIRMED |

`HandleMatchSkillUseRes` routes the exact DTO through `HandleResEnvelope`;
the envelope reads `matchPayload`, applies state/ops and invokes
`ParseCombatBatch`. This proves the skill response is processed as a combat
batch envelope. It does not prove that every payload contains a board, so the
reader must still require concrete `board` + `srvSeq` and fail closed when
either is absent.

Evidence:

- `reverse/redux_compat/cs/Assembly-CSharp/ChatMessageDTO.cs`
- `reverse/redux_compat/cs/Assembly-CSharp/MatchService.cs`
- `reverse/redux_compat/cs/Assembly-CSharp/WsCombatBatch.cs`
- `D:\pc\GameAssembly.dll`, read-only disassembly at the RVAs above; absolute
  runtime addresses remain ASLR-dependent and are not hard-coded.

### Pokiguard 1.7.4-b4 Audition V3 addendum (Phase 3C.1)

These are b4 module-relative TypeInfo RVAs and declared managed offsets. They
are read-only ownership/state evidence; none authorizes a managed method call.

| Type/root | b4 TypeInfo RVA | Static field |
|---|---:|---:|
| `PokiGuard.Audition.AuditionStage` | `0x0332D328` | `Active +0x00` |
| `PokiGuard.Audition.AuditionChallenge` | `0x0332CFB8` | N/A |

| Type | Member | Offset |
|---|---|---:|
| `AuditionStage` | `Host` | `+0x10` |
| `AuditionStage` | `Disposed`, `Tapped`, `TapElapsedMs`, `CorrectCount` | `+0x18`, `+0x19`, `+0x1C`, `+0x20` |
| `AuditionStage` | `_ch` | `+0x40` |
| `AuditionStage` | `_cursor` | `+0x118` |
| `AuditionStage` | `_qteElapsed`, `_durSec`, `_durMs` | `+0x14C`, `+0x150`, `+0x154` |
| `AuditionStage` | `_wasPerfect`, `_grade` | `+0x158`, `+0x168` |
| `AuditionChallenge` | `Display`, `Expected` | `+0x10`, `+0x18` |
| `AuditionChallenge` | duration/window integers | `+0x20..+0x38` |
| `AuditionChallenge` | `ReverseFrom`, `GreatMs` | `+0x3C`, `+0x40` |
| `AuditionChallenge` | `MultPerfect`, `MultGood`, `MultBad` | `+0x44..+0x4C` |
| `AuditionChallenge` | `ChallengeId` | `+0x50` |
| `CardUI` | `_auditionV3`, `_auditionV3ElapsedMs` | `+0xE0`, `+0xE4` |
| `CardUI` | `qtePresses` | `+0x498` |
| `MatchService` | server arrows/duration/window | `+0x278`, `+0x280`, `+0x284` |
| `MatchService` | layout/reverse/Great | `+0x2A8`, `+0x2B0`, `+0x2B4` |
| `MatchService` | three multipliers/challenge ID | `+0x2B8..+0x2C0`, `+0x2C8` |
| `ChatMessageDTO` | skill/correct/timing/dots | `+0x120`, `+0x128`, `+0x130`, `+0x138` |
| `ChatMessageDTO` | QTE presses/elapsed/challenge ID | `+0x150`, `+0x158`, `+0x160` |

`MatchService` declares current `QteUiGeneration = 3` and legacy generation 2.
The V3 reader requires exact `ServerQteLayout == "LR"`, binds the active stage
to the current CardUI/Board/Active/session, and uses `AuditionChallenge.Expected`
as the input sequence. `Display` is retained as server equality evidence; the
tool does not infer the reversal rule. Any disagreement fails closed.

Live B1 run `f740e9c51fb845d7a9fe2c8ea1de5a6b` proved that
`MatchService.ServerQteReverseFrom +0x2B0` uses `-1` as the normal no-reverse
sentinel. Read-only native disassembly of `AuditionChallenge.FromService` at
RVA `0xBD7EF0` independently shows initialization of `ReverseFrom +0x3C` to
`0xFFFFFFFF`, copying the server field, clamping an index at or beyond the
display count back to `-1`, and skipping `Opposite` while the value is
negative. The production reader accepts exact `-1`; other negative values
remain invalid.

`CardUI._auditionV3ElapsedMs +0xE4` also has a distinct exact `-1` pre-tap
sentinel. Native b4 evidence: `CardUI..ctor` RVA `0xABBEC0` and
`HandleDotSkillSequence.MoveNext` RVA `0xADC090` write `0xFFFFFFFF`;
`CurrentQteElapsedMs` RVA `0xAA9AA0` derives elapsed time from the live clock
while the field is negative; `IAuditionHost.OnAuditionTap` RVA `0xA939A0`
replaces it with the actual tap milliseconds. The V3 reader therefore accepts
exact `-1` only for an untapped stage, using `AuditionStage._qteElapsed`, and
requires bounded equality with `AuditionStage.TapElapsedMs` after tap.

`AuditionStage._wasPerfect +0x158` is not a completed-result flag. Native
`TickBar` RVA `0xBD1E20` compares `_qteElapsed * 1000` with the challenge
Perfect window, requires the stage to remain untapped, and writes the resulting
live highlight boolean to `+0x158`. `TapBar` RVA `0xBD0580` separately writes
`Tapped +0x19` and `TapElapsedMs +0x1C`; `ShowResult` RVA `0xBD3170` writes the
later grade to `_grade +0x168`. An untapped stage may therefore coherently have
`_wasPerfect=true` and `_grade=null` while awaiting Space.

Evidence:

- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/PokiGuard/Audition/AuditionStage.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/PokiGuard/Audition/AuditionChallenge.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/CardUI.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/MatchService.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ChatMessageDTO.cs`
