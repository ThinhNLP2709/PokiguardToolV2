# Pokiguard 1.7.4-b4 compatibility audit

Date: 2026-09-14 (Asia/Saigon)

Status: **PASS — b4 default BASIC compatibility is accepted by a complete
bounded live win after the MATCH_START repair. Audition V3/Pet Skill is now
integrated offline under Phase 3C.1; its live B1 remains pending.**

## Evidence and build identity

The folder linked as `reverse/pokiguard_1.7.4` contains only an older
Il2CppInspector `types.cs` dated 2026-09-01. The b4 evidence used here is the
full user-supplied output at `reverse/reverse_1.7.4-b4`.

All installed game files under `D:\pc` were read only:

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 58,770,944 | `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,312,528 | `C90F02A5AD34726CD2B89951A21C82F19BECF88EC7D7697605D70BD2AF1BE575` |

`GameAssembly.dll` is x64 with timestamp `0x6AA6926D`, image base
`0x180000000`, and `SizeOfImage 0x03AC8000`. Metadata has magic
`0xFAB11BAF`, header version `110`; the generated header selects Unity
`6000.7.0a3`, while installed `UnityPlayer.dll` reports
`6000.7.0a4 (7305b6f6fd4f)`. Exact hashes and byte signatures remain the
compatibility authority.

The runtime allowlist now contains only the b4 `GameAssembly.dll` hash. b3 and
unknown builds fail closed before the memory provider is constructed.

## TypeInfo migration

Every root used by the default runtime moved. These are module-relative RVAs,
never absolute process addresses.

| Type/root | b3 | b4 |
|---|---:|---:|
| `Board` | `0x03343B68` | `0x033558A0` |
| `Dot` | `0x03347260` | `0x03359050` |
| `Active` | `0x03343968` | `0x03355698` |
| `Active.PlayerStats` | `0x0332F598` | `0x033415B0` |
| `ManagerMatch` | `0x0333DAF0` | `0x03350170` |
| `MatchService` | `0x03337DE0` | `0x0334A100` |
| `ChatService` | `0x033377B8` | `0x03349A90` |
| `ChatMessageDTO` | `0x03349C28` | `0x0335B9A8` |
| `WsCombatBatch` | `0x0334D930` | `0x0335F580` |
| `BoardWsApplier` | `0x03337A50` | `0x03349D48` |
| `CardUI` | `0x03337D48` | `0x0334A080` |
| `FusionCardUI` | `0x03373998` | `0x03386C78` |
| `CardData` | `0x033739A0` | `0x03386C80` |
| `PetUserDTO` | `0x0335A470` | `0x0336C5A8` |
| `TurnAnnouncer` | `0x03337B18` | `0x03349E00` |
| `MatchSceneLoader` | `0x033397A0` | `0x0334B8E8` |
| `MatchHost` | `0x03339948` | `0x0334BB28` |
| `HubSuspendManager` | `0x033377D8` | `0x03349AD8` |
| `ManagerQuangTruong` | `0x03339F30` | `0x0334C3A8` |
| `ManagerRoom` | `0x03337D30` | `0x0334A068` |
| `WsRoomService` | `0x033544E8` | `0x03366060` |
| dispatcher message closure | `0x03349D50` | `0x0335BAB8` |
| `UnityMainThreadDispatcher` | `0x03349EB8` | `0x0335BC08` |
| dispatcher pending `List` | `0x033549F8` | `0x033665E0` |
| dispatcher pending `Queue` | `0x03354A48` | `0x03366628` |
| Newtonsoft `JArray` | `0x033363F0` | `0x033482F0` |
| Newtonsoft `JObject` | `0x033363E8` | `0x033482E8` |
| Newtonsoft `JProperty` | `0x03367910` | `0x0337AD08` |
| Newtonsoft `JValue` | `0x033547D0` | `0x033663A0` |

The b4 profile updates every root above together. Enabling only the b4 hash
without these migrations would be unsafe.

## Managed layout comparison

Declarations for `Board`, `Active`, `ManagerMatch`, `MatchService`,
`ChatMessageDTO`, `WsCombatBatch`, `BoardWsApplier`, `CardUI`, `FusionCardUI`,
`CardData`, `PetUserDTO`, `TurnAnnouncer`, lifecycle classes and all default
combat fields are unchanged from b3. Therefore the b3 offsets already adopted
for board, turns, ACK/desync, typed transport board, normal card, evolution,
stats and terminal detection remain valid on b4.

Two additions were found:

1. `Dot` adds `_pressAccepted +0xF0` and `_pressFingerId +0xF4`. This moves
   `_squashing 0xF4 -> 0xFC`, `PoolTag 0xF8 -> 0x100`, and `RenderHidden
   0x129 -> 0x131`. The Board-owned 64-Dot reader and its test fixture are
   updated to the b4 offsets and larger `0x132` bounded sample. Native
   `BoardWsApplier.SpawnDotByTag` at RVA `0x00360350` calls the `PoolTag`
   setter at `0x002B4AF0`; that setter writes `[Dot+0x100]`. It then writes
   row `+0x24`, column `+0x20`, and multiplier `+0x88`.
2. `ChatService` adds an authentication probe at `+0x2EC`, after the fields
   read by the tool. `WsRoomService` adds `_pendingLeaveRoomId +0xD8`, also
   after all fields read by the tool. These changes do not shift any current
   default-runtime offset.

Newtonsoft's inherited LINQ-token layouts were also rechecked rather than
carried forward from the old test fixture. In both b3 and b4 declarations,
`JArray._values`, `JObject._properties`, and `JProperty._content` are all at
`+0x50`. The opening decoder and its synthetic snapshot builder had incorrectly
used `+0x58`; both now use the declared `+0x50` offsets.

The new Dot release-coordinate methods change game input handling internally,
but normal external foreground mouse input still enters the same public
OnMouseDown/OnMouseUp path. Live acceptance remains necessary to prove the
complete input behavior.

## Native Unity ownership bridge

`UnityPlayer.dll` is byte-identical to b3. All 15 signature checks used for
GameObject ownership, components, active state, RectTransform, Transform and
Canvas match the installed b4 file exactly. The GameAssembly-side bindings
moved and are updated:

```text
Component.get_gameObject cache       GameAssembly + 0x355F678
resolved Unity function              UnityPlayer  + 0x1067390
managed/native unmarshal signature   GameAssembly + 0x10971EF
```

The wrapper at `GameAssembly+0x027E9DA0` loads the cache at `+0x355F678`, calls
the resolved Unity function, and tail-jumps into the unmarshal routine at
`+0x10971D0`. The fail-closed signature is taken at the branch that distinguishes
even pointer handles from tagged engine handles (`+0x10971EF`). No engine
method is invoked by the tool.

The first live combat exposed one correction to the original offline profile:
the b4 relative `call` displacement inside that branch is `BF E4 16 FF`, while
the b3 displacement was `0F C9 17 FF`. The installed b4 PE mapping and the live
read-only bytes both produce
`48 85 DB 74 33 F6 C3 01 74 0D 48 8B CB E8 BF E4 16 FF 48 8B D8 EB 03 48 8B 1B`.
The exact b4 bytes are now used by the fail-closed guard.

## Live findings and MATCH_START repair

The third bounded b4 attempt entered match `M_91a4747a` and sent no gameplay
input. The first provider publication arrived only after the opening turn had
advanced, so entry stopped with `ENTRY_TIMEOUT_OPENING_BOARD`. This was the
user-visible skipped turn. It was not a mistaken gem map: the provider later
performed three direct `Board.allDots` reads, accepted all three, retained 64
cached Dot objects and reported zero native-board rejection. It also read the
live normal evolution cost as 120.

The exact timing isolated the fault. The new Board was ready at
`17:47:24.719Z`, but entry returned `awaiting_match_start_opening_dto` because
its transport scan did not retain the short-lived MATCH_START callback. A
later board at ACK sequence 4 was valid but deliberately could not be relabeled
as the opening. Artifact:
`logs/b4_compatibility/20260914_basic_live_3/32c1d9b304b1405a935ed7e593bf8654/`.

The repair keeps the existing strict opening contract. Immediately before the
single Start click, boss entry now starts the existing read-only 1 ms dispatcher
sampler in new-match discovery mode. It accepts only a nonempty MatchId that
differs from the lobby baseline and an exact schema-valid 64-cell raw
`MATCH_START`; if the raw board was compacted, the same callback may supply the
class-checked b4 `ChatMessageDTO.preBoard` with the raw `srvSeq`. The retained
snapshot is offered only after the actual Board session binds to that same
MatchId. No fallback board is described as MATCH_START, and no acceptance,
actionability or input invariant was relaxed.

## Implemented scope and live acceptance

The b4 code profile covers the complete default path: boss-room discovery,
combat lifecycle, Board/Active ownership, server and rendered board capture,
turn/actionability state, ACK/desync evidence, player stats, normal Attack
card, normal evolution, input geometry and terminal observation.

The default-mode compatibility result above is unchanged. Subsequent Phase
3C.1 work added b4 Audition V3/Pet Skill support behind the exact
`LEGENDARY/NONE/PET_SKILL` profile. V3 `LR` is the default; legacy V2
four-direction handling remains an explicit option. That later integration has
offline coverage but still needs its own bounded live acceptance.

Offline verification is complete:

- focused b4 layout/default tests: PASS;
- complete regression: **1212/1212 PASS**;
- `compileall` and `git diff --check`: PASS;
- the exact installed b4 hash is accepted; b3 and arbitrary hashes are rejected;
- all 15 native UnityPlayer signatures match the installed DLL byte for byte.

A zero-input live lobby probe then attached to PID `20116`, x64, at
`GameAssembly base 0x00007FFA2CC30000`. `MemoryBoardStateProvider` resolved the
b4 `WsCombatBatch`, `Dot`, `BoardWsApplier`, `CardUI`, `FusionCardUI`,
`ChatMessageDTO`, and `Active.PlayerStats` roots without error. Lifecycle and
lobby singletons resolved as `LOBBY_OTHER`; `Board`, `Active`, and current rig
were correctly null outside combat. The run stopped with
`ENTRY_TIMEOUT_BOSS_LOBBY` because no Chinh Phuc room was open, with
`entryClicks=0` and `gameplayInputs=0`. Evidence:
`logs/b4_compatibility/20260914_lobby_inspect/entry.jsonl`.

The installed game then ran as PID `154496`. A post-repair bounded run used
`NORMAL / NORMAL / DEFAULT_ATTACK` against Fraxure 1307. The dispatcher sampler
was armed before Start at `18:11:40.394Z`; it retained the first complete
64-cell MATCH_START at `18:11:41.248Z`. Entry accepted the opening with two
stable confirmations, `firstLocalTurn=true`, `localMoveSequence=0`, and 14
seconds remaining. Policy selected a safe Rage-producing SWAP on turn 1 and
the server acknowledged it. The previous skipped-opening behavior did not
recur.

Match `M_64611df6` completed as a strong WIN with boss HP `0/96298` and returned
to `BOSS_LOBBY`. It observed 15 local turns and 14 boss turns, sent 15 SWAPs,
received 14 normal SWAP acknowledgements, and recorded zero rejection. The
last SWAP coincided with combat terminal; it was correctly closed as
`ACTION_ABORTED_STATE_CHANGED/COMBAT_LIFECYCLE_ENDED` instead of fabricating an
ACK. Normal evolution used the live 120-mana cost: the server explicitly
rejected the first attempt, accepted the second, and the runtime confirmed
`EVOLVE_SUCCESS`. There were zero PASS proposals/executions, zero read/DTO/
stale/ambiguous/sequence-desync errors, zero technical abort/recovery, and zero
safety violation. Native board fallback accepted 18/18 reads with zero
rejection.

The ordinary Attack card was also mapped through the current four-slot strip
with `conditionUse=160`, but this match created no CAST proposal: boss HP never
met the 30,000 finisher threshold before the killing Sword move and player mana
never reached the configured 480 stockpile. Its input/ACK path was therefore
not re-exercised in this single sample; its b4 managed layout, CardUI ownership
and interaction geometry were live-resolved and are unchanged from the prior
accepted default runtime.

Final artifact:
`logs/b4_compatibility/20260914_011130_basic_live_retest/a6d3f398cd0b4cb4bb009ead46d83601/`.
The run reports `FARM_RUN_COMPLETE`, `FULL_MATCH_PASS`, 1/1 WIN and final
lifecycle `BOSS_LOBBY`. This closes the b4 default compatibility gate.
