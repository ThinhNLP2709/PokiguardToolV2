# Phase 2F.1 — Standalone Windows Packaging

## Result

**PASS STRONG** on 2026-08-29 (Asia/Saigon).

Base commit: `3b0bbd74d1fe88fbd0823e6d1825e4434a69254a` (accepted
Phase 2E.3). The exact commit containing this report is recorded in the final
handoff after Git creates it.

This is a packaging and small packaged-live-validation milestone. It is not a
Release Candidate, does not create a release tag and does not implement Phase
2F.2.

## Canonical package

```text
packaging tool:       PyInstaller 6.22.0
Python build runtime: CPython 3.11.9 x64
format:               portable one-folder, windowed/no console
application version:  v1.0.0+15
entry point:          pokiguard_v2.windows_entry
executable:           PokiguardToolV2.exe
executable size:      3,651,784 bytes
bundle files:         994
bundle size:          29,894,977 bytes
archive:              PokiguardToolV2-v1.0.0+15-win-x64.zip
archive size:         13,610,131 bytes
SHA-256:              b8aed614f43d3550ef1d8dd6d88d3d3dbdb76547f63d5b9b4144bca89f5e1d05
bundle fingerprint:   b75b0582c58cfe970d6b93d6ecc0a9a8ed4485836d65eacfdc62cd64ef0c1b31
```

Canonical build command:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

The script asserts a 64-bit Python runtime, reads the canonical app version,
runs focused tests, safely recreates only its versioned `work`/`dist`
children, builds from `packaging/PokiguardToolV2.spec`, creates a sorted
fixed-timestamp ZIP and prints its SHA-256. Generated artifacts stay outside
Git under `%LOCALAPPDATA%\PokiguardToolV2\package-builds\<version>` by default.

PyInstaller warnings were limited to ordinary optional cross-platform modules
such as `pwd`, `grp` and `fcntl`. The packaged production graph imported
successfully. Recursive archive inspection found the production
`tools.basic_auto_bot` and `tools.desktop_ui` modules and did not find the
diagnostic V1 adapter, OpenCV, NumPy, MSS, pytest or legacy overlay bots.

## Runtime path architecture

`pokiguard_v2.app_paths` is the single environment/path boundary.

Packaged mode:

```text
bundled resources:  PyInstaller _MEIPASS/pokiguard_v2/resources
writable root:      %LOCALAPPDATA%\PokiguardToolV2
preferences:        <root>\preferences\operator_preferences.json
Desktop UI logs:    <root>\logs\desktop_ui\<unique run>\
FarmRun logs:       <root>\logs\farm_runs\<FarmRunId>\
checkpoint:         <FarmRun directory>\checkpoint.json
startup log:        <root>\logs\startup\startup.jsonl
controller locks:   <root>\locks\
```

The explicit `POKIGUARD_V2_DATA_ROOT` override exists for isolated acceptance
and tests and must be absolute. Packaged mode fails closed if neither an
explicit root nor `LOCALAPPDATA` is available. Current working directory is
never used to resolve production code, resources or writable state.

Source/developer mode preserves historical repository-local logs and CLI
compatibility. No old source checkpoint is automatically migrated. Preferences
remain separate from checkpoints and never auto-start or auto-resume.

Production input calibration is internal to V2. The packaged runtime no longer
imports or reads `D:\PokiguardAuto`. Only the accepted reset capability and two
exact exit-UI calibration JSON files are bundled; source docs, tests, reverse
output, game files and historical logs are excluded.

`multiprocessing.freeze_support()` is called at the frozen entry boundary. The
FarmRunner continues to run as one in-process owned thread; packaging adds no
worker process or subprocess recursion. A data-root lease rejects a second
Desktop UI owner.

## Offline and build validation

```text
focused packaging tests:  14/14 PASS
focused UI/path/package:  29/29 PASS
full regression:          740/740 PASS
compileall:               PASS
git diff --check:         PASS
standalone build:         SUCCESS
packaged self-check:      exit 0
```

Focused coverage includes source/frozen path resolution, different CWD,
missing app-data failure, fresh directory creation, safe preference/FarmRun
writes, packaged checkpoint discovery plus canonical resume validation, no
automatic Start/Resume, duplicate UI ownership, complete production import
graph, internal calibration and exact bundled resources.

## Packaged B1 — clean staging

Final `+15` archive was extracted to:

```text
C:\Users\Admin\AppData\Local\PokiguardToolV2\package-validation\
fresh15_20260829_042201\archive\PokiguardToolV2
```

It launched from sibling `arbitrary-cwd` with `PYTHONPATH` absent and a fresh
explicit data root. Both the no-input production-graph self-check and offline
UI smoke exited 0. The UI recorded ten render ticks, zero handled/unhandled UI
errors, zero Start, zero Resume, zero gameplay input and a stopped poller.
Python or the source repository was not used at runtime.

## Packaged B2 — game absent

After a machine restart proved both Pokiguard and the tool absent, final `+15`
was launched normally, not with the offline provider.

```text
mode:                 LIVE_CONTROLLED
game detected:        false
attached:             false
lifecycle:            UNAVAILABLE
provider reason:      attach_failed
render ticks:         15
Start / Resume:       0 / 0
gameplay/lobby input: 0 / 0
UI errors:            0
controller stopped:   true
poller alive:         false
exit code:            0
```

The package did not launch the game and failed closed as an unavailable
read-only runtime.

## Packaged B3 — read-only attach

The clean-staged `+14` package attached read-only to the running game in exact
`BOSS_LOBBY`. Packaging PID telemetry recorded game PID 2836, a responsive UI,
zero automatic Start and zero Windows input. A second three-second attach audit
also observed the running game and left the game files, ZIP, distribution and
repository state byte-identical.

The final `+15` delta after live B5 changes only the graceful-button render
text and version label. Its frozen production graph, fresh extraction,
game-absent process discovery and write boundaries were rebuilt and rechecked.

## Packaged B4 — bounded farm

```text
FarmRunId:             add073d8cbdb4fcb9a660964fb35ec11
configured target:    1 completed match
completed / attempts: 1 / 2
result:                1 WIN, 0 LOSS, 0 UNKNOWN
terminal:              STRONG / CONSISTENT
technical abort:      1 DEAD_BOARD_NO_REFRESH
technical recovery:   1 successful exact-pet recovery
final lifecycle:      BOSS_LOBBY
final state:          FARM_RUN_COMPLETE
stop reason:          FARM_TARGET_COMPLETED
attempt after target: none
```

Attempt 1 encountered an exact dead board and was correctly excluded from
completed results. Recovery re-entered exact Starburst `1289`; attempt 2 won.
No attempt 3 was created. There were zero SWAP/CAST rejections, provider read
errors, result conflicts or non-zero FarmRun safety counters. The terminal boss
HP was 0 and the result modal was `Thắng`.

## Packaged B5 — graceful control

Accepted UI-command run:

```text
FarmRunId:             6b89455c91ef434594f42f1febdeb905
configured target:    2 completed matches
stop request:         request_graceful_stop accepted in ACTIVE_COMBAT
completed / attempts: 1 / 1
result:                1 WIN, STRONG / CONSISTENT
attempt 2:             absent
entry after request:  0
final lifecycle:      BOSS_LOBBY
final stop:           STOPPED_GRACEFULLY
controller:            STOPPED, exit 0
```

The UI command counter was one; duplicate, stale and wrong-run commands were
zero; maximum simultaneous controllers was one. Emergency Stop was not repeated
live because packaging retained the accepted in-process owner and focused
offline tests cover its command boundary.

This run exposed one presentation-only defect: the durable terminal snapshot
correctly retained `graceful_stop_requested=true`, so the disabled button kept
showing `Stopping after current match...` after STOPPED. Build `+15` now shows
pending text only while the controller is active. A regression test proves both
active and terminal labels. No FarmRunner, process ownership, path, input or
checkpoint logic changed.

## Checkpoint and persistence

The packaged B4 completed checkpoint is correctly non-resumable. The packaged
B5 checkpoint is `STOPPED_GRACEFULLY` at `BOSS_LOBBY` and retains its canonical
resume semantics. Focused integration writes a valid resumable checkpoint
under a fresh packaged app-data root, discovers it through
`LatestCheckpointSummaryProvider` and validates it through the unchanged
canonical backend. Filename or root changes do not bypass validation.

Preferences reload from packaged app data but never trigger Start or Resume.
Missing preferences use safe defaults; corrupt preference handling remains
covered by the accepted Desktop UI suite.

## Write-location audit

The final `+15` artifact was executed from clean staging with a dedicated data
root. SHA-256/mtime/length snapshots and post-run manifests proved:

```text
writes to D:\pc:                    0
writes to source repository:        0
writes beside packaged executable:  0
ZIP changes:                        0
staged bundle changes:              0
expected app-data files:            4
```

Critical game hashes remained:

```text
Pokiguard.exe        8a157ed48add3ac19e41ab1796338f85badfac3f1d44a9b64b04a7a88d4bf875
GameAssembly.dll     5a993b8aef2371f6053aa46c692592ce32ff8418071e85357541f7fb504d58b3
UnityPlayer.dll      34b546a31b94758666aa814b37c9f0aaabe25909a9c6d23e53ab8ed1d18090a7
global-metadata.dat  c9ec5627aa074066190bcf1e6f1f592a9c7dfd0adcdd2a5b1f4b4b7df5216085
```

## Resource observation

Read-only B3 sampling of the packaged process:

```text
samples:                 27
start working set:       13,385,728 bytes
peak working set:        47,656,960 bytes
end working set:         44,519,424 bytes
```

B4 FarmRunner telemetry recorded three controller samples from 51,109,888 to
88,035,328 bytes and interpreted no observed unbounded growth during the short
bounded run. These observations are diagnostic, not a new RAM limit.

## Known limitations / stop boundary

- `BASIC` remains the only supported intelligence mode.
- `REASONING` remains undefined/unsupported.
- Infinite farming remains unsupported; targets and attempts are finite.
- The package does not launch/login to the game or navigate from the general
  lobby through islands.
- Runtime target pin/re-entry still requires an initial exact boss room.
- App-data virtualization observed when a child EXE is launched from the Codex
  packaged host is host-specific; an explicit absolute data root was used for
  clean isolation. A normal user launch resolves ordinary `%LOCALAPPDATA%`.
- Phase 2F.2 Release Candidate/final distribution acceptance is not
  implemented.

Next roadmap phase: **Phase 2F.2 — Release Candidate + Final Acceptance**.
