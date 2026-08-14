# Safe UI recovery and re-entry research

Status: locator/offline validation and live single-step exit acceptance PASS.
Automatic exit and re-entry remain disabled.

## Normal exit evidence

V1 reference screenshot `PokiguardAuto/GameScreenShoot/thoat_tran.png` shows the
normal flow:

1. combat-only white `<<` Back/Exit control at top left;
2. leave-warning modal: `Chạy sớm là chấp nhận thua đó !`;
3. left orange `Đồng ý` and right orange `Chơi tiếp` buttons.

V1 `engine.py` also used this two-click flow, but its confirm coordinate was
explicitly documented as an estimate. V2 does not reuse that estimated
coordinate. Reverse output contains generic `UI_ArrowButton.direction` and
`Press()`, but does not prove the instantiated combat Back object or provide a
safe ownership chain; V2 does not call `Press()`.

## V2 locator

The locator consumes a fresh client-area screenshot and the current client
rectangle; it never assumes one resolution.

- Exit/Back is accepted only while hardened lifecycle is `ACTIVE`, the window
  is unchanged/foreground, and multiple white chevron components occupy the
  small combat top-left anchor.
- Confirm is accepted only when exactly two large, similarly sized orange
  components form the expected central leave-modal layout. The left component
  is selected from the detected pair.
- The screenshot is captured again immediately before each click.
- A missing/ambiguous control, changed window, focus loss, or invalid point
  produces `RECOVERY_BLOCKED` and sends no click.
- The Exit sprite blinks. V2 samples multiple frames after a move-only hover
  probe. If every sample lands on an invisible phase, it may use the exact
  1294x696 live calibration only because an earlier confirmed run already
  clicked that hitbox and then proved the expected modal on 3/3 frames. The
  calibration is rejected for any other client dimensions.

Offline checks locate the Exit control on the 1294x696 client screenshot saved
by the low-board artifact and locate both modal buttons in `thoat_tran.png`.
Synthetic positive/negative tests cover ambiguity rejection.

## Confirmed state flow

```text
ACTIVE_COMBAT
  -> SEQUENCE_DESYNC (real mode only)
  -> RECOVERY_REQUIRED
  --F10 + proven Exit--> RECOVERY_REQUESTED -> EXIT_CONTROL_CLICKED
  -> CONFIRM_MODAL_VISIBLE
  --F10 + re-proven modal--> normal Đồng ý click
  -> LEAVING_COMBAT
  -> BOSS_MAP_OR_LOBBY
```

F10 advances at most one proven UI step. The modal confirmation requires a
second F10; this prevents one hotkey from producing two unreviewed clicks. F9
stops immediately. No board/card/Fusion click path exists in the recovery tool.

Completion does not use `Board.Instance == NULL` alone. It uses the hardened
local lifecycle: MatchHost/local rig, loading/unloading, Hub suspension and
Board/Active/ManagerMatch ownership. `STALE_SERVER_MATCH` is an acceptable
proof that the local combat UI/rig has exited, but remains non-actionable and
is logged as stale rather than clean server completion.

## Live acceptance runbook

Run from an ordinary combat that the user is willing to intentionally lose:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\sequence_recovery.py --manual-test --single-step
```

The banner explicitly says `MANUAL_UI_FLOW_TEST`; it is not a fake desync.

1. Keep Pokiguard foreground in active combat.
2. Wait for the low-low recovery beep and `UI exit locator armed`.
3. Press F10 once. Expected: only the normal `<<` control is clicked.
4. Wait for the second beep and `Leave modal proven`.
5. Visually confirm the modal, then press F10 once. Expected: only `Đồng ý` is
   clicked.
6. Do not click anything else. The tool must print `SINGLE-STEP EXIT PASS` only
   after local lifecycle proves boss map/lobby (or stale server match with no
   local combat rig).
7. F9 at any time aborts. `RECOVERY_BLOCKED` is a safe failure and must not be
   worked around with coordinates.

Real-desync arming exists as `--watch-desync --single-step`, but acceptance
does not require deliberately reproducing the bug.

## Live acceptance result

PASS on 2026-08-13, match `M_d7c6d1ce`, evidence
`logs/phase2c2a4_live_calibrated_20260813_114552.jsonl`:

- hardened lifecycle started at `ACTIVE_COMBAT` with Board
  `0x0000015EEEDB7000`;
- Exit locator got two consistent blinking-control hits and sent exactly one
  normal click;
- modal locator got 3/3 consistent frames and selected the left confirm button;
- the second F10 sent exactly one normal confirm click;
- lifecycle moved `ACTIVE_COMBAT -> POSTMATCH -> LOBBY`;
- final `single_step_exit_pass` records `staleServerMatch=false`,
  `localCombatUiExited=true`, and `noStrayGameplayClick=true`.

Two earlier attempts safely returned `RECOVERY_BLOCKED` when their temporal
samples landed only on the invisible blink phase; no click was sent in those
blocked attempts. This directly validates the fail-closed path.

## Re-entry research only

The earlier combined path below was a research hypothesis:

```text
main map (Lobby.png)
  -> boss UI
  -> target
  -> normal entry control
  -> entering combat -> active clean session
```

Cpp2IL evidence:

- `ManagerQuangTruong.ShowPanelBoss()` opens the boss area;
- `ManagerBoss` owns a `List<WorldBossDTO>`;
- `BossItem.btnFight` is `UnityEngine.UI.Button` at offset `0x48` and belongs
  to the same object as `BossItem.bossData`;
- the V1 `waiting_room.png` reference visibly contains `Bắt Đầu`.

Phase 2D.1 native-body analysis later proved these are two separate flows:
`BossItem.OnFightClicked` directly creates/starts a WorldBoss session and loads
`Match`, while `waiting_room.png` is the ChinhPhuc `ManagerRoom` flow whose
selected target is `RoomDTO.enemyPetId/nameEnemyPetId` and whose entry control
is `ManagerRoom.ButtonStart`. See `docs/boss_entry_resolution.md` for the exact
signals and current implementation status.
