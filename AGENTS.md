# PokiguardToolV2 Agent Instructions

## Workspace

### PokiguardToolV2
Primary writable project.

All new V2 code, docs, tools and tests belong here.

This project already contains:
- docs/
- reverse/
- reference/

The Cpp2IL reverse output is already inside `reverse/`.
Do not look for or require a separate `poki_reverse` workspace.

### PokiguardAuto
Reference only.

This is the working Python V1 bot containing:
- OpenCV/template matching
- board recognition
- solver
- scoring
- automation loop
- input executor
- game screenshots/state references

Never modify this folder.

Reuse or adapt the existing solver rather than rewriting working gameplay logic.

### pc
Strictly read only.

This is the real game installation.

Never:
- modify
- patch
- replace
- rename
- delete
- write to game files

Reading and inspection are allowed.

## Target architecture

V1:

screen -> CV -> board -> existing solver -> normal input

V2 target:

game state -> read-only state provider -> existing solver -> normal input

Keep CV available as fallback.

## Current scope

Until explicitly approved:

- no WriteProcessMemory
- no DLL injection
- no remote thread
- no game binary patching
- no direct MatchService.SendMove
- no direct RequestSwap
- no network/packet manipulation
- no HP/damage/reward modification
- no use of game enableAutoMove logic

External memory work begins read-only.

## Reverse engineering

Cpp2IL output is stored under:

`PokiguardToolV2/reverse/`

Use it as evidence.

Do not guess:
- field offsets
- RVAs
- ownership
- pointer chains

Record verified findings in:
- docs/il2cpp_symbols.md
- docs/board_resolution.md

If something cannot be verified, mark it UNKNOWN.

Never hard-code ASLR-dependent absolute runtime addresses.

## Development

- New code only in PokiguardToolV2.
- PokiguardAuto is read-only reference.
- pc is strictly read-only.
- Prefer small testable milestones.
- Log errors clearly.
- Invalid pointers/state must stop or fail closed.
- Keep disposable reasoning scratch files, temporary datasets and source-review
  copies under `temp/reasoning/`, never in `tmp*` folders at the project root.
  Tests should use `tests.reasoning_test_paths.reasoning_temp_root()` as the
  parent of `tempfile.TemporaryDirectory`; keep permanent evidence in docs.
- Stop at the milestone requested by the user.

## Verification

- Offline gate: `python scripts/ci_offline.py` (624 tests after U1, about 100 s).
- One test module needs `PYTHONPATH=<repo>;<repo>\src`, e.g.
  `python -m unittest tests.test_reasoning_u1_bench`.
- Same-board bench/timing: `python tools/reasoning_u1_bench.py corpus|run|compare|timing|freeze`
  (see `docs/opus/reports/U1_report.md`).
- Any added or changed `.py` under `src/`, `tools/` or `tests/` changes the source fingerprint that
  pins source-mode reasoning profiles; report the new fingerprint.
