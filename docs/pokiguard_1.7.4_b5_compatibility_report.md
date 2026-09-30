# Pokiguard 1.7.4-b5 compatibility audit

Date: 2026-09-28 (Asia/Saigon)

Status: **LIVE B2 PASS STRONG — base b5 compatibility and multi-match
continuity are closed; Phase 4C.2 re-entry acceptance resumes next.**

## Build identity

The audit used the user-supplied reverse output in
`reverse/reverse_1.7.4-b5` and read the installed files under `D:\pc` without
modifying them.

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 62,338,560 | `E2A2457128B4F412EAE302AC5314350F0C18529C12716B4EBDB36281D923F9E9` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,794,684 | `B9E06BED5E0B1B090DC69160DC2A89CB1CBF9864DB34854D74473CAE638814A2` |

The allowlist now accepts only the b5 `GameAssembly.dll` hash. A b4 or unknown
binary fails closed before the read-only state provider attaches.

## Runtime migration

All build-specific TypeInfo RVAs moved. The production profile was migrated
as one unit, including Board/Active/MatchService, websocket DTO and dispatcher
roots, CardUI/Fusion/Pet/QTE roots, lobby/map singletons and Newtonsoft token
types. They remain module-relative RVAs; no ASLR-dependent absolute address is
stored.

The managed layouts also changed in several places:

- `Board` removed two fields before the late readiness flags. `isBoardReady`,
  Legend/Mega state, resume state and Mega1 panel state moved by eight bytes.
- `ChatService` gained room-start events. Its disconnect/reconnect guard fields
  moved from `+0x2D4..+0x2E4` to `+0x2FC..+0x30C`.
- `ChatMessageDTO` gained room-start data. Combat fields moved by `+0x40`, and
  pre-parsed board/combat fields moved by `+0x60`.
- `PetUserDTO.cardDTO` moved from `+0x98` to `+0xA8`.
- `AuditionStage` removed two UI references. Cursor, elapsed time, duration,
  perfect flag and grade moved by eight bytes; `AuditionChallenge`, CardUI and
  MatchService QTE layouts stayed unchanged.
- `ManagerQuangTruong.Instance` moved from static field `+0x00` to `+0x08`.
  All instance panel offsets used by the tool stayed unchanged.

## New boss-room Start behavior

B5 introduces `RoomCoopV2View` and `RoomStartState`. The single visible main
button can now mean `ReadyOn`, `ReadyOff`, `CancelCountdown`, or `OwnerStart`.
Native disassembly of `RoomStartState.Describe` confirms these phases:

| Value | Phase | Safe first automated click |
|---:|---|---|
| `0` | `Idle` | yes |
| `1` | `ReadyWait` | no; it can unready the player |
| `2` | `Counting` | no; it can cancel the countdown |
| `3` | `Locked` | no |

The lobby reader now requires the exact `RoomCoopV2View.Instance`, verifies
`RoomCoopV2Refs.ButtonStart` equals `ManagerRoom.ButtonStart`, and authorizes
entry only at `Idle` with `_myReady == false`. Later phases wait or fail closed
instead of clicking the same visual control again.

The entry locator no longer assumes the b4 button position. It resolves the
live `ManagerRoom.ButtonStart` RectTransform through the existing read-only
Unity ownership bridge, validates that exact rectangle against the captured
frame, and clicks its runtime center. This tolerates the b5 position and
palette change while retaining the exact managed/native owner, active,
interactable, CanvasGroup, foreground, modal and two-frame checks. The same
runtime rectangle is available to the detached-room recovery proof.

The b5 `GameAssembly.dll` also moved the two native-ownership bridge anchors
even though `UnityPlayer.dll` itself is unchanged:

| Bridge anchor | b5 RVA |
|---|---:|
| cached `Component.get_gameObject` target | `GameAssembly+0x38AA280` |
| managed/native unmarshal signature | `GameAssembly+0x136097F` |

Both anchors were verified against the installed b5 process. With them, the
live room control resolves as one `UnityEngine.UI.Button` with a valid
managed/native ownership roundtrip. The old b4 cache address fails closed and
must not be used on b5.

## Verification

- native ownership/geometry tests including the pinned b5 bridge anchors and
  nested room Canvas: **38/38 PASS**;
- complete regression after the participant mapping repair: **1570/1570 PASS**;
- `compileall`: PASS;
- no game file was written, patched or replaced;
- no process-memory write, injected method call or direct game/network action
  was added.

Live acceptance remains required. The first bounded run should verify one
entry from the b5 boss room, first-turn board publication, one acknowledged
normal action, and return to the same boss room. The tool was not opened
automatically after this offline update.

## First bounded live attempt and repair

Farm run `d94cc810353f47398fdd8664ec372b28` proved the exact Starburst room,
`RoomStartState=Idle`, `_myReady=false`, and a clean target association, but
sent zero entry clicks. It waited in `LOCATE_ENTER_BUTTON` with
`native_card_ui: unreadable range` until the operator used F9.

Read-only inspection of the installed process showed the b4
`Component.get_gameObject` cache was the failing precondition. After migrating
both bridge anchors, the same live `ManagerRoom.ButtonStart` resolved as
`UnityEngine.UI.Button` with a valid managed/native ownership roundtrip. A
bounded B1 retry is still required to accept the active rectangle, visual
proof, click and state transition.

The next bounded run `9f74507ed8744b06806752924edd0207` loaded the corrected
bridge and again proved the exact room and Idle state, but sent zero entry
clicks. Its live active hierarchy exposed a b5-specific nested WorldSpace
Canvas: the button and its `2160x1080` Canvas were valid, while two layout-only
RectTransforms above that Canvas intentionally had no native TransformAccess
handle. The reader previously tried to cross those null handles to reach the
screen-space parent Canvas and failed closed.

Room entry now has an explicit bounded opt-in that stops at this full-design
nested Canvas only after proving its exact native parent is one active
screen-space root Canvas and both centered rectangles have the same aspect.
Card, board and general hub geometry keep their prior strict path. The live
button rectangle was `(0.716204, 0.831481) - (0.910648, 0.920370)`; independent
visual proof on the operator screenshot accepted the red b5 Start control at
confidence `0.99` and center `(0.813426, 0.875926)`.

## First combat handoff and participant mapping repair

Farm run `58a631a4c5764200b76c85e68a5d086b` proved the repaired room path end to
end: it issued exactly one entry click, reached match `M_657d9d4e`, accepted
the authoritative 64-cell opening board and enumerated 16 legal moves. It sent
no board input because the policy correctly failed closed with
`PET_SKILL_RESOURCE_STATE_UNKNOWN`.

The board and live Pet Skill CardUI were current, but both local-player and
boss participant states were absent. Reverse evidence found that the b5
TypeInfo migration had confused two adjacent nested types:

```text
0x0364FB00 -> Active_PlayerStats
0x03672E38 -> ActivePVP_PlayerStats
```

The co-op provider reads `Active.playerStatsMap`, so it must validate entries
against `Active_PlayerStats`. The runtime constant and symbol table now use
`0x0364FB00`; a regression test explicitly rejects the PVP address. Managed
field offsets remain unchanged. The complete suite passes 1570/1570 after the
repair.

## B1 live acceptance — PASS STRONG

Farm run `16381e658aee4a949664fb2ee7ac5e2a` completed exactly 1/1 with one
unique match (`M_1ed99a37`) and a strong memory-backed WIN. It proved:

- one bounded b5 room entry and one authoritative 64-cell opening;
- current local/boss HP, Mana and Nộ from
  `Active.playerStatsMap/ObfuscatedInt.Value` throughout combat;
- five SWAP inputs, all five acknowledged and none rejected;
- one current-session Pet Skill with `SUCCESS_PERFECT`;
- zero Pass, safe-stop, provider read error, DTO rejection, wrong-turn input,
  duplicate input or result conflict;
- consistent memory/UI result (`WIN` / `Thắng`) and final lifecycle
  `BOSS_LOBBY`.

B2 will run three consecutive matches from the same room. It must prove three
fresh MatchIds, one bounded entry per match, fresh participant/card ownership,
acknowledged gameplay, normal postmatch confirmation and return to the same
boss room between matches without a ReadyOff/CancelCountdown duplicate click.

## B2 multi-match continuity — PASS STRONG

Farm run `e223cce0bf33488e8cbe5401433210d1` completed exactly 3/3 with three
unique matches (`M_fe7b0096`, `M_ebdaa7d3`, `M_2bd38568`) and three STRONG
memory-backed WINs. Across the run:

- each attempt issued exactly one boss-entry click and reached a fresh combat
  session;
- all policy samples had current local and boss participant state;
- 16/16 SWAP inputs were acknowledged, with zero rejection;
- all three Pet Skill actions completed with one card click, 7/7 confirmed
  directions, one Space and runtime `PERFECT`;
- there were zero Pass, safe-stop, technical abort/recovery, provider read
  error, DTO rejection, duplicate/wrong-turn/stale/postmatch input or result
  conflict;
- all three memory results agreed with the `Thắng` UI and the run finalized at
  `BOSS_LOBBY` with `FARM_TARGET_COMPLETED`.

This closes base b5 compatibility. It does not count toward Phase 4C.2's two
required navigation re-entry cycles because every match used the normal
postmatch return to the existing boss room.

## Conquest-island surface classification repair

A read-only probe on the visible Dragon Island found that every b5 ownership
field was valid: `panelChinhPhuc=true`, `panelMain=true`, exactly one active
island panel at index `5`, and one dynamic `UIPanelManager` entry. The desktop
status still reported `LOBBY_OTHER` without a branch because the shared hub
classifier required `dynamic_panel_count == 0` before it would accept any
Chinh Phuc surface. That condition describes the island map, but excludes the
island detail layer itself.

The classifier now accepts either the zero-dynamic-panel map or exactly one
dynamic panel backed by an active `ManagerChinhPhuc.panelMain` and one
unambiguous active island index. Missing panel ownership, no active index, or
more than one dynamic panel continues to fail closed. A post-fix live probe on
the same unchanged screen returned `CHINH_PHUC_ISLAND`, `Đảo rồng`, and
`visible Chinh Phuc island panel proven` with zero input. Full regression:
**1572/1572 PASS**.

## Late-turn multiplier correction — 2026-09-29

FarmRun `e746727a66bc4f7589e416b1abaacf8e`, attempt 3, reached turn 20 and
exposed x5, x6 and x7 multipliers in immutable server boards and the live Dot
graph. The previous x1..x4 validator rejected all later boards, causing local
turns 21, 23 and 25 to expire without a policy decision or input. Native b5
`DotMultiplierRoll.Roll` at RVA `0x00C6D960` and `PermilleAt` at RVA
`0x00C6DB40` prove the current domain is exactly x1..x7, with x5..x7 eligible
from turn 20.

The transport decoder, rendered-Dot fallback, state model and opening/recovery
evidence gates now share the x1..x7 domain. Values outside it remain rejected.
The multiplier-weighted configuration maximum is now 448. Full regression is
**1589/1589 PASS**; live retry is pending.
