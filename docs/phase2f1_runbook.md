# Phase 2F.1 Runbook

This runbook builds and validates the Phase 2F.1 portable Windows package. It
does not require or authorize a 25-match soak and does not create a release
tag.

## Build prerequisites

- Windows x64.
- CPython 3.11 x64 for building only.
- PyInstaller 6.22.0.
- Project checkout at any absolute path.

Verify:

```powershell
python -c "import struct; assert struct.calcsize('P') == 8"
python -c "import PyInstaller; print(PyInstaller.__version__)"
```

End users do not need Python, PyInstaller, `PYTHONPATH`, the repository or
`PokiguardAuto` to run the packaged application.

## Clean build

From the project root:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

The script safely clears only its versioned `work` and `dist` children. The
default output is:

```text
%LOCALAPPDATA%\PokiguardToolV2\package-builds\v1.0.0+15\
```

Expected distributable:

```text
PokiguardToolV2-v1.0.0+15-win-x64.zip
SHA-256 b8aed614f43d3550ef1d8dd6d88d3d3dbdb76547f63d5b9b4144bca89f5e1d05
```

An alternate build output may be supplied only as an explicit absolute path:

```powershell
.\scripts\build_windows.ps1 -OutputRoot 'C:\safe\package-output\v1.0.0+15'
```

## Clean staging

Create an empty directory outside the repository and extract the ZIP there.
Use a different working directory and remove any explicit source `PYTHONPATH`:

```powershell
$stage = Join-Path $env:LOCALAPPDATA 'PokiguardToolV2\manual-stage\v1.0.0+15'
$cwd = Join-Path $env:LOCALAPPDATA 'PokiguardToolV2\manual-stage\cwd'
New-Item -ItemType Directory -Path $stage,$cwd -Force | Out-Null
Expand-Archive -LiteralPath `
  "$env:LOCALAPPDATA\PokiguardToolV2\package-builds\v1.0.0+15\PokiguardToolV2-v1.0.0+15-win-x64.zip" `
  -DestinationPath $stage
Remove-Item Env:PYTHONPATH -ErrorAction SilentlyContinue
Start-Process -FilePath "$stage\PokiguardToolV2\PokiguardToolV2.exe" `
  -WorkingDirectory $cwd
```

Do not copy runtime resources beside the EXE manually. They are already in the
one-folder bundle.

## First run / fresh app data

For an isolated acceptance run, set a fresh absolute root before launching:

```powershell
$env:POKIGUARD_V2_DATA_ROOT = `
  "$env:LOCALAPPDATA\PokiguardToolV2\manual-validation\fresh-data"
& "$stage\PokiguardToolV2\PokiguardToolV2.exe"
```

Verify:

- title contains `v1.0.0+15`;
- no console window;
- missing preferences use safe defaults;
- no Start or Resume occurs automatically;
- closing idle UI stops its poller and leaves the game untouched.

Remove the override in the shell after the isolated run:

```powershell
Remove-Item Env:POKIGUARD_V2_DATA_ROOT -ErrorAction SilentlyContinue
```

Normal packaged launches use `%LOCALAPPDATA%\PokiguardToolV2`.

## Game-absent smoke

1. Ensure no FarmRunner is active.
2. Close Pokiguard manually; do not have the tool launch it.
3. Launch the packaged EXE normally.
4. Verify game unavailable/detached, UI responsive, zero Start/Resume/input.
5. Close the UI and verify its process/poller stop.

## Read-only attach

1. Launch the game manually.
2. Enter a safe exact boss lobby.
3. Launch packaged `PokiguardToolV2.exe`.
4. Verify Game detected, lifecycle `BOSS_LOBBY` and runtime target populated.
5. Do not press Start for the attach-only check.
6. Verify no unexpected game input and that closing the idle tool leaves the
   game running.

## One-match packaged farm

1. Be in the exact pet boss lobby.
2. Set `Target matches = 1` and a valid finite Max attempts.
3. Click Start exactly once.
4. Let the tool enter, play and complete normally. Technical aborts/recoveries
   do not count as completed matches.
5. Verify exactly one completed WIN/LOSS/strongly evidenced result, no attempt
   after the attempt reaching target, final `BOSS_LOBBY` and controller
   `STOPPED`.
6. Inspect `<app-data>\logs\farm_runs\<FarmRunId>\run.json` and
   `checkpoint.json`; do not infer acceptance from the visible game alone.

## Graceful-stop packaged smoke

1. From exact boss lobby, set `Target matches > 1` and click Start.
2. Wait until lifecycle is `ACTIVE_COMBAT`.
3. Click the packaged UI button **Stop After Current Match** exactly once.
4. Do not use F6/F9 for this UI-command acceptance.
5. Verify the current match completes and is accounted normally.
6. Verify no next entry/attempt, final lifecycle `BOSS_LOBBY`, stop reason
   `STOPPED_GRACEFULLY`, controller `STOPPED` and the button label has returned
   to `Stop After Current Match`.

An additional live Emergency Stop is not required for Phase 2F.1 because the
package retains the accepted in-process controller owner and offline tests
cover the unchanged command boundary.

## Checkpoint/path validation

Packaged artifacts must remain under one data root:

```powershell
$root = Join-Path $env:LOCALAPPDATA 'PokiguardToolV2'
Get-ChildItem -LiteralPath $root -Recurse -File |
  Select-Object FullName,Length,LastWriteTime
```

Expected categories are preferences, startup/desktop/FarmRun logs, per-run
`events.jsonl`, `run.json`, `checkpoint.json`, diagnostics and controller
locks. A completed checkpoint remains non-resumable. Only a checkpoint accepted
by the canonical validator may enable Resume.

## Data-path/write audit

Before and after packaged validation, compare hashes or Git status for:

```powershell
Get-FileHash D:\pc\Pokiguard.exe -Algorithm SHA256
Get-FileHash D:\pc\GameAssembly.dll -Algorithm SHA256
Get-FileHash D:\pc\UnityPlayer.dll -Algorithm SHA256
Get-FileHash D:\pc\Pokiguard_Data\il2cpp_data\Metadata\global-metadata.dat `
  -Algorithm SHA256
git status --short
```

Required:

```text
game-install writes = 0
source-repository writes during packaged execution = 0
unexpected writes beside EXE = 0
runtime state only under the selected app-data root
```

## Offline regression

From the project root:

```powershell
$env:PYTHONPATH = 'src;.'
python -m unittest tests.test_app_paths tests.test_windows_packaging -v
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
```

Accepted Phase 2F.1 baseline:

```text
focused packaging: 14/14 PASS
full regression:   740/740 PASS
compileall:        PASS
git diff --check:  PASS
```
