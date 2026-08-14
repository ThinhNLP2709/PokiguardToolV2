# Combat card state detection (read-only)

Scope: additional Phase 2A.5 research requested after the 2026-08-11 live
match. This work detects state only. It does not call `SendCardUse`,
`SendFusionUse`, or any game method, and it does not perform input or solver
integration.

## Result

Both important cards are externally detectable, but their evidence has
different semantics:

- Evolution is named **Fusion** by the client. Successful use is a persistent,
  server-response-derived `MatchService.LocalFusionUsed` value.
- The attack card ("Chưởng") is an ordinary `CardUI`. Its current client
  usability is the `Button.interactable` value refreshed from
  `CardUI.CanUseCard`. Its used flags are optimistic client state and must not
  be called server-confirmed until reject/rollback has been excluded or the
  authoritative card-use operation is observed.

The first completed-match log predated this instrumentation and could not
prove the card uses retroactively. A second full live run on 2026-08-11 then
validated both paths; results are recorded below.

## Evolution / Fusion evidence

All fields are instance members of `Assembly-CSharp`, global namespace,
`MatchService`:

| Member | Exact type | Offset | Meaning |
|---|---|---:|---|
| `FusionEnabled` backing field | `System.Boolean` | `+0x54` | feature enabled |
| `FusionManaCost` backing field | `System.Int32` | `+0x58` | configured cost |
| `FusionStatPercent` backing field | `System.Int32` | `+0x5C` | configured stat percent |
| `LocalFusionUsed` backing field | `System.Boolean` | `+0x60` | local Fusion succeeded |
| `LocalFusionLastAttemptTurn` backing field | `System.Int32` | `+0x64` | attempt/turn lock |
| `LocalFusionSelectedUserPetId` backing field | `System.Int64` | `+0x68` | selected owned pet |
| `LocalFusionSelectedPetId` backing field | `System.Int64` | `+0x70` | selected resulting pet |
| `LocalFusionSkillCard` backing field | `CardData` | `+0x78` | resolved Fusion card |

`get_LocalFusionLockedThisTurn()` returns true exactly when the last attempt is
positive and equals `TurnNumber +0x40`. Native `HandleFusionRes` first checks
`rejected`; for the local actor it records the attempt turn, and only on
`success` writes `LocalFusionUsed = true` and parses `skillCard`. Therefore the
watcher's `fusion_success` event has strong success semantics.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:230-246`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `get_LocalFusionLockedThisTurn` and `HandleFusionRes`

`candidateAvailable = enabled && !usedSuccessfully && !lockedThisTurn` is
logged only as a conservative candidate. A future gameplay decision must also
validate current player/turn, local authoritative mana, and visible UI state.

## Attack-card identity and current usability

`CardUI` current ownership is validated by three independent conditions:

1. object class equals the exact runtime `CardUI Il2CppClass*`;
2. `CardUI.board +0x30 == Board.Instance`;
3. `CardUI.active +0x38 == Active.Instance`.

The `CardUI` type-info global slot is preferred VA `0x18350E0D0`, hence build
RVA `0x350E0D0`. The reader uses module base plus this RVA and never an ASLR
dependent absolute runtime address.

Relevant instance fields:

| Type/member | Exact type | Offset |
|---|---|---:|
| `CardUI.cardData` | `CardData` | `+0x20` |
| `CardUI.btn` | `UnityEngine.UI.Button` | `+0x28` |
| `CardUI.board` | `Board` | `+0x30` |
| `CardUI.active` | `Active` | `+0x38` |
| `CardUI.hasUsedThisMatch` | `System.Boolean` | `+0x40` |
| `CardUI.hasUsedThisTurn` | `System.Boolean` | `+0x41` |
| `CardUI.lastTurnUsed` | `System.Int32` | `+0x44` |
| `CardUI.isActionPending` | `System.Boolean` | `+0x48` |
| `CardUI.isPlaceholder` | `System.Boolean` | `+0x78` |
| `Selectable.m_Interactable` | `System.Boolean` | `+0xD8` |

`CardUI.UpdateCardVisual()` calls `CanUseCard()` and writes its result through
`Selectable.set_interactable`. Thus `btn +0xD8` is the game-computed client UI
signal for whether the ordinary card is currently clickable.

The attack-card identity is taken from `CardData.elementTypeCard +0x30` using
the exact strings tested by `CardUI.IsAttackCard`: `ATTACK`,
`ATTACK_LEGEND`, `ATTACK_LEGEND_`, or `MEGA1`. Other useful declared fields are
`cardId +0x18`, `name +0x20`, `skillType +0x78`, `manaCost +0x80`,
`powerCost +0x84`, and `cooldownTurns +0x88`.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/CardUI.cs:714-731`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/CardData.cs:6-27`
- `reverse/cpp2il_cs/DiffableCs/UnityEngine.UI/UnityEngine/UI/Selectable.cs:46`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/CardUI.txt`,
  `CanUseCard`, `IsAttackCard`, and `UpdateCardVisual`

## Why attack-card "used" is labeled carefully

`CardPhotonSync.RequestUseCard` performs this client sequence:

```text
BeginPendingAction
  -> MatchService.SendCardUse
  -> CardUI.MarkAsUsed
```

That means `hasUsedThisTurn`/`lastTurnUsed` can change optimistically before the
server response. `CardRejectUiHelper` calls `RevertOptimisticUse` when the
server rejects the card. The watcher therefore records
`combat_card_use_observed` with this limitation explicit; it does not label
that event server-confirmed. `BoardWsApplier.ApplyCardUse` can provide an exact
authoritative operation (`ownerUsername`, `cardId`, `isSkill`), but its queued
lifetime is very short and was not yet runtime-captured.

## Watcher output

`tools/live_cell_state_watch.py` now adds:

- `fusion_state`: direct MatchService Fusion fields when they change;
- `fusion_success`: transition of `LocalFusionUsed` from false to true;
- `combat_card_state`: current Board/Active-owned cards and UI usability;
- `combat_card_use_observed`: optimistic used-state transition, explicitly
  labeled with rollback semantics.

All card candidates fail closed on class, Board/Active ownership, pointer,
UTF-16 string, boolean, identifier, and resource-cost validation.

## Live acceptance result (2026-08-11, second run)

Source: `logs/live_cell_state_20260812_001627.jsonl`. The watcher started from
the lobby, attached read-only to PID `22260`, saw the live Board, and ended
cleanly with `board_lost` plus `watch_summary`.

### Fusion

At turn 21 the state changed atomically from:

```text
LocalFusionUsed=false, LocalFusionLastAttemptTurn=-1
```

to:

```text
LocalFusionUsed=true, LocalFusionLastAttemptTurn=21
```

The watcher emitted one `fusion_success` at `17:19:22.398Z`. The success flag
remained true through turn 49. Observed configuration was `FusionEnabled=true`,
`FusionManaCost=160`, `FusionStatPercent=70`, selected user pet `218166`, and
selected result pet `1845`. This is a **PASS** for direct successful Evolution
detection.

### Attack card

The exact current-Board `CardUI` inventory contained:

| cardId | Name | elementTypeCard | Classification |
|---:|---|---|---|
| 1 | Hoi mana | `MANA` | non-attack |
| 2 | Hoi no | `POWER` | non-attack |
| 4 | Tan cong | `ATTACK` | attack card |

Card ID 4 was observed with `uiInteractable=true` in 11 state samples. Four
use-state transitions were recorded at turns `37`, `39`, `45`, and `49`. Each
had `hasUsedThisTurn=true`, `lastTurnUsed=<same turn>`,
`isPlaceholder=true`, `actionPending=false`, and `uiInteractable=false`.

For turns 37, 39, and 45, `lastTurnUsed` remained at that accepted turn after
the game advanced to the next turn instead of being reset to `-1` by
`RevertOptimisticUse`. The turn-49 state remained used through `board_lost`.
No rollback was observed. This is a **PASS** for attack-card identity,
availability, and durable client accepted-state detection. It is strong
acceptance evidence, but still not the same as directly capturing the
short-lived authoritative `BoardWsApplier.ApplyCardUse` operation.

## Phase 2B production model addendum

`MemoryBoardStateProvider` enumerates every exact current-Board/current-Active
`CardUI` candidate. It does not filter or hard-code card ID 4. The canonical
`GameState.cards` records identity, name/description, `elementTypeCard`,
`skillType`, UI interactability, match/turn usage flags, costs/cooldown, and all
declared `CardData` metadata through `eatBad +0x98`.

The additional exact `CardData` fields are `description +0x28`, `value +0x38`,
`maxLevel +0x3C`, `count +0x40`, `level +0x44`, `conditionUse +0x48`, `power
+0x50`, color values `green..purple +0x58..+0x6C`, `damageMultiplier +0x70`,
and `eatPerfect/eatGood/eatBad +0x90/+0x94/+0x98`. These raw named fields are
logged without assigning undocumented gameplay meaning to them.

The card list is refreshed from runtime ownership on every provider scan and
cached only while each object continues to pass the exact class and Board/Active
checks. A loadout change therefore changes the enumerated card records without a
code change.
