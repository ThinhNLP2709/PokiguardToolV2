# Phase 2F.2 Release Candidate Runbook

This runbook reproduces the finite BASIC Release Candidate validation. It does
not authorize REASONING, infinite farming, automatic game launch/restart,
login automation, target rotation, memory writes or network manipulation.

## Prerequisites

- Windows x64.
- CPython 3.11 x64 and PyInstaller 6.22.0 for building only.
- Accepted source commit
  `1dd53340e20ca405c0bf446682b3fcbf823afe62`.
- The user manually launches Pokiguard and enters an exact boss room for live
  stages. The package never launches or logs into the game.
- Preserve unrelated untracked files exactly. Stop before release tagging
  until the user explicitly decides their disposition; never silently delete,
  ignore or mix them into the release artifact.

## Build and clean staging

```powershell
python -c "import struct; assert struct.calcsize('P') == 8"
python -c "import PyInstaller; print(PyInstaller.__version__)"
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

Canonical RC:

```text
PokiguardToolV2-v1.0.0+15-win-x64.zip
13,609,921 bytes
SHA-256 e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69
```

Extract the ZIP to a new directory outside the source repository and game
installation. Launch from a different working directory with `PYTHONPATH`
removed. Use a new absolute `POKIGUARD_V2_DATA_ROOT` under LocalAppData for
each stage.

When the packaged process is launched through an AppContainer host, keep the
explicit test root short. The host can prepend a long virtualization path; an
overly deep test root may exceed legacy Windows path length even though a
normal `%LOCALAPPDATA%\PokiguardToolV2` launch does not.

Run the no-input production graph check:

```powershell
& .\PokiguardToolV2.exe --packaging-self-check
```

Run a bounded offline UI smoke:

```powershell
& .\PokiguardToolV2.exe --offline --smoke-seconds 1
```

## B1 — game absent and read-only attach

With Pokiguard absent, run:

```powershell
& .\PokiguardToolV2.exe --smoke-seconds 2
```

Require unavailable/detached state, responsive UI, zero Start/Resume/input and
a stopped poller after close. The package must not launch the game.

Then have the user manually launch the game and enter the exact boss room. Run
another short packaged smoke. Require x64 attach, `BOSS_LOBBY`, exact target,
zero Start/Resume/input and the game still running after tool close.

## B2 — final 10-match bounded farm

1. Start from exact boss lobby with a fresh data root.
2. Set Target matches to 10 and Max attempts to a finite value with margin
   (the accepted value was 16).
3. Click Start once and do not manipulate the game/tool while active.
4. On stop, inspect `run.json`, `checkpoint.json` and `events.jsonl`.

Require exactly 10 completed results, exact W/L/U accounting, no unexplained
UNKNOWN, no extra attempt after target, `FARM_TARGET_COMPLETED`, final
`BOSS_LOBBY`, one maximum controller and every critical safety counter zero.
Technical aborts must not count as completion.

## B3 — Graceful Stop

1. Use a new data root and a target large enough to remain active.
2. Start from exact boss lobby.
3. During early `ACTIVE_COMBAT`, click Stop After Current Match once.
4. Require UI ACK `GRACEFUL_STOP_ACCEPTED`.
5. Let the current match complete normally.

Require the current result to be counted once, no next attempt/entry,
`STOPPED_GRACEFULLY`, final `BOSS_LOBBY` and controller STOPPED.

## B4 — checkpoint Resume

1. Use a new data root, Target matches 5 and Max attempts 8.
2. Start and request Graceful Stop during the first combat.
3. Require a valid `STOPPED_GRACEFULLY` checkpoint at `BOSS_LOBBY` with one
   historical completion.
4. Close the packaged UI normally.
5. Restart the same EXE with the same data root.
6. Do not edit the checkpoint. Keep the exact same target/attempt limits and
   click Resume Checkpoint, not Start.
7. Let the continuation reach the historical target of 5.

Require `continuation_of` to name the source FarmRun, five unique historical
MatchIds, exact W/L/U accounting, no double count, no extra attempt and final
`FARM_TARGET_COMPLETED/BOSS_LOBBY`.

## B5 — Emergency Stop

1. Use a new data root and a target large enough to remain active.
2. Start from exact boss lobby.
3. During active automation, click Emergency Stop — Immediate once.
4. Record the UI ACK timestamp.

After ACK require zero authorized input operation, gameplay input, boss entry,
postmatch input, recovery input and new match. Controller must stop and UI must
remain responsive. The game may remain in combat; do not fabricate or count an
unfinished result and do not expect Emergency Stop to recover the game.

## B6 — final shutdown and write audit

Close the stopped packaged UI normally. Require:

```text
controller alive = 0
poller alive = 0
PokiguardToolV2 process = 0
Pokiguard process = still running
handled/unhandled UI errors = 0
```

Compare pre/post hashes for:

```powershell
Get-FileHash D:\pc\Pokiguard.exe -Algorithm SHA256
Get-FileHash D:\pc\GameAssembly.dll -Algorithm SHA256
Get-FileHash D:\pc\UnityPlayer.dll -Algorithm SHA256
Get-FileHash D:\pc\Pokiguard_Data\il2cpp_data\Metadata\global-metadata.dat -Algorithm SHA256
Get-FileHash .\PokiguardToolV2-v1.0.0+15-win-x64.zip -Algorithm SHA256
git status --short
```

Require no runtime writes to the game installation, source repository or
beside the packaged EXE. Expected mutable state belongs only under the selected
application-data root.

## Final offline validation

```powershell
$env:PYTHONPATH = 'src;.'
python -m unittest tests.test_app_paths tests.test_windows_packaging -v
python -m unittest discover -s tests -p 'test_*.py' -v
python -m compileall -q src tools tests
git diff --check
```

Accepted counts:

```text
focused release tests: 14/14 PASS
full regression:       740/740 PASS
compileall:            PASS
git diff --check:      PASS
```

## Git release boundary

Review and stage only deliberate Phase 2F.2 files. Before any release commit:

```powershell
git status --short
git diff
git diff --check
git diff --cached --name-only
git tag --list
```

If an unrelated file remains in status, report `BLOCKED_GIT_HYGIENE` and do
not create the release commit/tag. For this release, the user explicitly
authorized finalization after the QTE report was verified as valid project
documentation. Its exact bytes were preserved in separate commit `c2f4242e`
before the Phase 2F.2 release commit. The annotated release tag is
`v1.0.0+15`.
