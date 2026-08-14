# Phase 2D.1 final report — boss lobby identification and one-shot entry

Status: **PASS STRONG** on 2026-08-15 (Asia/Saigon). Phase 2D.1 is complete
and stopped. No combat controller or automatic second re-entry was started.

## 1. Boss-lobby exact runtime signals

The accepted `CHINH_PHUC_ROOM` branch requires a non-combat local lifecycle,
live `ManagerRoom` and native object, valid `RoomDTO` enemy identity, an active
WS room whose `CurrentRoomType` is exactly `ChinhPhuc`, matching local owner,
non-null room properties, an alive/interactable `ButtonStart`,
`IsOpeningRoomFlow == false`, and two stable runtime samples. A null Board alone
is never treated as a boss lobby. A stale server match remains non-actionable.

The externally exposed classifications are `BOSS_LOBBY`, `LOBBY_OTHER`,
`ENTERING_COMBAT`, `ACTIVE_COMBAT`, `POSTMATCH`, and `UNKNOWN`.

## 2. Boss enumeration mechanism

For the active pet-boss room, `ManagerRoom.roomData` produces the one currently
selected ChinhPhuc candidate. For the separate WorldBoss flow,
`ManagerQuangTruong._managerBoss -> ManagerBoss.bossItems` is enumerated with a
64-item bound and before/after list-version validation; every item reads its own
`BossItem.bossData` and `btnFight`. The tool does not silently choose the first
item.

## 3. Target identity fields

The production identity is limited to reverse/runtime-proven data:

```text
boss_id   = str(RoomDTO.enemyPetId)
boss_name = RoomDTO.nameEnemyPetId
room_id   = WsRoomService.CurrentRoomId
pet_id    = RoomDTO.enemyPetId
source    = ManagerRoom.roomData
```

The accepted live target was `1289 / Starburst / Coop_772438`.

## 4. Target matching rules

`--boss-id` uses exact trimmed ordinal equality and takes priority.
`--boss-name` uses trim, Unicode NFC and `casefold`, then exact equality. There
is no fuzzy or accent-stripping fallback. Zero candidates yields
`TARGET_MISSING`; multiple exact candidates yield `TARGET_AMBIGUOUS`; both send
zero input. No target is hard-coded in source.

## 5. Selection detection

In the accepted ChinhPhuc flow, the exact WS room and `ManagerRoom.roomData`
prove the target is already selected. The same `ManagerRoom` owns `roomData` and
`ButtonStart`; therefore no boss-card selection input was required. The target
identity, selected state and entry-control address are reread immediately
before input.

## 6. Fight button detection

Runtime proves `ManagerRoom.ButtonStart` is alive and interactable. A calibrated
visual locator supplies the normal UI click point only after exactly one
lower-center cyan Start control is detected in two stable frames with confidence
at least 0.90. Missing, ambiguous, modal, foreground-loss and geometry-change
states fail closed.

## 7. UI coordinate and locator behavior

Coordinates are normalized to the current client rectangle and converted at
the final input boundary; no absolute boss/Fight coordinate is stored. In the
Stage B PASS, the client was 1280x710 at screen origin `(617,265)`, the detected
normalized point was approximately `(0.6750,0.8113)`, confidence `0.954507`,
and the derived client/screen points were `(863,575)` / `(1480,840)`.

## 8. One-shot input sequence

The attempt identity binds lobby epoch, exact target key, selected state,
button timestamp and structural signature. After final revalidation the
foreground-only Windows executor sends exactly one normal click. The attempt is
then pending and cannot click again. No Unity call, network call, memory write,
injection, double-click or blind retry exists in this path.

## 9. Old-session baseline

Before entry the controller records old match ID, session key, Board instance,
server sequence, local move sequence and lifecycle epoch, then invalidates the
session-scoped board/action/idle/desync/card/fusion caches. Stage B recorded no
old local match/session/Board and a prior local sequence value of 1. The earlier
negative artifact `20260814_233851` proved stale `roomData` without a current WS
room is `LOBBY_OTHER` and cannot arm a click.

## 10. New match/session proof

Stage B observed new match ID `M_bd9f0142`, local move sequence 0, and new Board
instance `2538281925248`. MATCH_START was captured during entry and rebound only
after the new provider session matched the new match ID and Board identity. It
was not confused with a previous server match.

## 11. Opening-board acceptance

The accepted source was
`ChatMessageDTO.MATCH_START.matchPayload.board`. It contained exactly 64 valid
cells, `srvSeq=1`, board hash
`556d45204580eb1f87b72b8b2502132ab2c333b780e15049129e5af6f8b27ba3`, two
stability confirmations, first local turn, and `localMoveSequence=0`.

## 12. Stage A result

Artifact: `logs/boss_entry/20260814_235937`.

Confirmed F8 mode entered the exact target with one click, created match
`M_bdce2972`, accepted a stable 64/64 first-turn opening, and stopped with
`NEW_COMBAT_OPENING_READY`. Entry clicks: 1. Gameplay inputs: 0.

## 13. Stage B result

Artifact: `logs/boss_entry/20260815_000202`.

Automatic one-shot mode completed:

```text
BOSS_LOBBY -> exact Starburst target -> Bắt Đầu
-> new match/session -> stable opening 64/64 -> STOP
```

No user confirmation was used and no gameplay action followed entry. This is
the required PASS STRONG result.

The prior artifact `logs/boss_entry/20260815_000032` stopped with
`ENTRY_TIMEOUT_BOSS_LOBBY` because the game was not foreground. It sent zero
input, as designed.

## 14. Wrong and duplicate click counts

For both accepted runs:

- wrong boss clicks: 0;
- duplicate entry clicks: 0;
- post-entry extra clicks: 0.

## 15. Stale-session confusion count

Stage A: 0. Stage B: 0.

## 16. Gameplay input count after entry

Stage A: 0. Stage B: 0. BasicPolicy, SWAP, EVOLVE, CAST and PASS were not loaded
or executed by the entry tool.

## 17. Exact stop reason

Both accepted runs stopped at `NEW_COMBAT_OPENING_READY` with final state
`STOP`.

## 18. Tests

`python -m unittest discover -s tests -v` passed **310/310**. Coverage includes
single/missing/ambiguous target resolution, exact normalized names,
single/missing/ambiguous button detection, both read-only V1 lobby screenshots,
dependency-free PNG decoding, and binary-log summarization. Live foreground
loss also produced a zero-input fail-closed artifact.

## 19. Files created or changed

- `src/pokiguard_v2/boss_entry.py`
- `src/pokiguard_v2/boss_entry_ui.py`
- `src/pokiguard_v2/boss_lobby_runtime.py`
- `src/pokiguard_v2/win32_screenshot.py`
- `tools/boss_entry.py`
- `tests/test_boss_entry.py`
- `docs/boss_entry_resolution.md`
- `docs/phase2d1_runbook.md`
- `docs/phase2d1_report.md`
- `docs/safe_ui_recovery.md`

No file in `PokiguardAuto` or `pc` was modified.

## 20. Blockers before Phase 2D.2

There is no blocker for one-shot entry into the currently accepted ChinhPhuc
Starburst room. Phase 2D.2 still needs an explicitly scoped integration that
chains the already accepted B5 controller, postmatch/lobby proof, mandatory
session reset and exactly one further entry; none of that is implemented here.

The separate direct WorldBoss-card path remains read-only/enumeration-only
because a live rect/selection calibration has not been accepted. It is a blocker
only if a future phase is expected to farm that different UI flow. Automatic
infinite retry, auto-exit and full farm loops remain intentionally out of scope.
