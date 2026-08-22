# Phase 2E.2 Runbook

Run from `D:\PokiguardToolV2` in 64-bit PowerShell/Python. The game must already
be running and the selected exact pet must be visible in `BOSS_LOBBY`. Keep the
game foreground for gameplay; Start and graceful stop restore the verified
game window automatically.

## Offline checks

```powershell
$env:PYTHONPATH = 'src;.'
python -m unittest discover -s tests -p 'test_desktop*.py' -q
python -m unittest discover -s tests -p 'test_win32_input.py' -q
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
```

Expected accepted baseline: focused 46/46, full 564/564, compileall PASS,
diff-check PASS.

## Launch the live UI

Use a new artifact path for each UI process:

```powershell
pythonw tools\desktop_ui.py `
  --poll-interval 1 `
  --artifacts logs\desktop_ui\phase2e2_manual_001
```

The UI is 520 px wide. `REASONING` is disabled. Configure an exact target,
finite completed-match target, recovery limit, and attempt limit, then press
`Validate Draft`.

Start is available only with a healthy attached `BOSS_LOBBY` and no active
controller. Resume additionally requires a canonical durable resumable
checkpoint. `COMPLETED` and `EMERGENCY_STOPPED` checkpoints must leave Resume
disabled. Backend validation remains final authority.

## Live B1 — Start

1. Set target matches to 1 and max attempts to at least 1.
2. In `BOSS_LOBBY`, click `Start` once.
3. Verify the game comes to foreground and exactly one FarmRunId appears.
4. Let the normal entry, BASIC combat, result confirmation, and lobby return
   complete.
5. Verify 1/1, attempts=1, controller STOPPED, `BOSS_LOBBY`, and no attempt 2.

## Live B2 — graceful stop

1. Set target matches greater than one (3 is sufficient).
2. Click Start and wait for `ACTIVE_COMBAT`.
3. Click `Stop After Current Match` once.
4. Do not steal foreground while the current match finishes.
5. Verify normal result accounting/postmatch, return to `BOSS_LOBBY`,
   `STOPPED_GRACEFULLY`, and no next entry/attempt.

Repeated graceful requests must be harmless. If foreground is lost near the
four-second action floor, the gameplay controller must fail closed; it must
never send a late action.

## Live B3 — checkpoint resume

1. Set target=5 and begin a UI run.
2. After at least one completed match, request graceful stop during the next
   active match or at the accepted boundary.
3. Wait for `BOSS_LOBBY` and controller STOPPED.
4. Confirm the checkpoint shows fewer than 5 completed and Resume is enabled.
5. Click `Resume Checkpoint` once.
6. Verify a new FarmRunId with `continuation_of` the historical run.
7. Let remaining work finish; verify exact historical total 5/5, no replay or
   double count, exactly five attempts total, no attempt 6, and final lobby.

Never edit checkpoint JSON manually.

## Live B4 — emergency stop

1. Start a small finite run and wait for active combat plus at least one
   recorded gameplay action.
2. Click `Emergency Stop` once.
3. Record the acknowledgement timestamp.
4. Verify controller STOPPED and checkpoint `EMERGENCY_STOPPED`.
5. Verify zero `action_sent`, boss-entry, or fresh-match events after the
   acknowledgement.
6. Verify the unfinished match was not fabricated as WIN/LOSS.

Emergency Stop only revokes automation. It does not exit/recover the game. The
game may later enforce its normal three-idle rule. Use normal manual game UI to
return to the boss lobby before another test.

## Live B5 — five-match bounded farm

1. Return to exact `BOSS_LOBBY`.
2. Set target=5 and max attempts=5; validate the draft.
3. Click Start once and leave the game foreground.
4. Wait for final `COMPLETED` rather than stopping at the first visible 5/5.
5. Verify:

```text
completed=5
attempts=5
attempt_006 absent
wins + losses + unknown = 5
all five terminal results memory/UI consistent
technical recovery/abort=0 unless naturally and validly observed
final lifecycle=BOSS_LOBBY
controller=STOPPED
final invariant=PHASE2E2_UI_BOUNDED_COMPLETED
critical safety counters=0
```

Accepted reference run: `9ba4a5efd1074a26847603711c8ca75d`.

## Safe close

For Phase 2E.2, close the desktop UI only after controller state is STOPPED.
The interim close guard rejects normal close while a controller is active.
Final close/shutdown UX belongs to Phase 2E.3.

## Boundaries

Do not enable infinite farming or REASONING. Do not add memory writes,
injection, direct game calls, packet manipulation, automatic process launch,
login, or target rotation. Stop after Phase 2E.2 acceptance.
