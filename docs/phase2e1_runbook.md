# Phase 2E.1 Runbook — Read-Only Desktop UI

This runbook reproduces the Phase 2E.1 UI shell and its read-only acceptance.
It contains no UI-driven farming instructions because FarmRunner control is
reserved for Phase 2E.2.

## 1. Prerequisites and safety

- Windows x64 and 64-bit Python 3.11 or compatible Python 3.
- Tkinter/Tk available (`python -m tkinter` may be used for a local check).
- Repository at `D:\PokiguardToolV2`.
- No FarmRunner/controller/other Pokiguard automation process running.
- The UI attaches with only `PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`.
- The UI must produce zero mouse/keyboard gameplay input.

PowerShell setup:

```powershell
cd D:\PokiguardToolV2
$env:PYTHONPATH = 'src'
```

## 2. Offline UI

The offline flag uses an explicit unavailable fake and does not attach to the
game:

```powershell
python tools\desktop_ui.py --offline
```

Verify that the window opens, stays responsive, shows the unavailable/detached
state, renders BASIC configuration and checkpoint status, and closes normally.
The only button validates a session-local configuration draft; it cannot start
or control gameplay.

For a bounded auto-closing smoke with artifacts:

```powershell
python tools\desktop_ui.py `
  --offline `
  --poll-interval 0.25 `
  --smoke-seconds 3 `
  --artifacts logs\desktop_ui\phase2e1_offline_repro
```

Use a new artifact directory on every run; the CLI refuses to overwrite an
existing directory.

## 3. Focused tests

```powershell
python -m unittest `
  tests.test_desktop_control_plane `
  tests.test_desktop_runtime `
  -v
```

Expected current count: 23 tests, all PASS.

## 4. Full validation

```powershell
python -m unittest discover -s tests
python -m compileall -q src tools tests
git diff --check
git status --short
```

Expected Phase 2E.1 suite count: 548 tests, all PASS. `compileall` and
`git diff --check` must produce no failure.

## 5. Live read-only smoke

1. Confirm no FarmRunner/controller process is running.
2. Launch Pokiguard normally.
3. Reach a safe state, preferably the boss lobby.
4. Do not start `tools\farm_run.py`, `tools\basic_auto_bot.py`, or another
   automation controller.
5. Launch the desktop observer:

```powershell
python tools\desktop_ui.py `
  --poll-interval 2 `
  --smoke-seconds 600 `
  --artifacts logs\desktop_ui\phase2e1_live_repro
```

During the 10-minute window, verify:

- game PID/x64 attachment and lifecycle refresh visibly;
- the UI continues repainting while memory polling occurs;
- unknown/stale errors are visibly non-actionable;
- there is no automatic boss entry, board move, card use, result confirmation,
  lobby action, keypress, or modal interaction;
- no FarmRunner process starts.

The operator may manually move between lobby/combat states to observe a
transition, but the desktop UI must remain an observer. Do not perform a
transition solely to manufacture evidence.

After auto-close, inspect:

```powershell
Get-Content logs\desktop_ui\phase2e1_live_repro\summary.json
Get-Content logs\desktop_ui\phase2e1_live_repro\events.jsonl | Select-Object -Last 10
```

Required safety values in `summary.json`:

```text
readOnly = true
farmRunnerStarted = false
phase2e2CommandsAvailable = false
pollerStarts = 1
pollerAliveAfterClose = false
unhandledUiThreadExceptions = 0
safety.* = 0
controllerStopped = true
```

If the game detaches or a read fails, the UI must show detached/stale/error and
must still send zero input.

## 6. Normal close and artifacts

Close with the normal window close control or let `--smoke-seconds` expire.
Normal close cancels Tk callbacks, joins the one polling worker, closes the
read-only process handle, and writes:

```text
logs/desktop_ui/<run>/events.jsonl
logs/desktop_ui/<run>/summary.json
```

The Phase 2E.1 UI has no F6/F9 behavior and no Start, Stop, Resume, or boss
entry control. Do not expect it to farm; those commands do not exist yet.
