# Phase 3D.1 Runbook — Controlled Performance / Efficiency A-B Comparison

## Scope

This runbook compares two already accepted BASIC strategies through the normal
Desktop UI and FarmRunner path. It does not tune policy, controller timing,
thresholds, retry behavior, Pet Skill cost, or QTE behavior.

| Mode | Main Pet | Evolution | Damage card | Intelligence |
|---|---|---|---|---|
| A Default | Normal | Normal | Default Attack | BASIC |
| B Pet Skill | Legendary | None | Pet Skill | BASIC |

The complete strategies differ by pet/loadout by design. Results therefore
compare profile B with profile A; they do not isolate the Pet Skill card alone.

## Pinned method

- Application path: `run_tool.bat` → normal Desktop UI → bounded FarmRunner.
- Source version: `v1.0.47`.
- Source commit: capture the clean pre-benchmark commit immediately before B1;
  both B1 and B2 must use that exact commit.
- Boss: Starburst, ID `1289`, for both blocks. If it is unavailable or changes,
  stop and restart the affected comparison under one equivalent target.
- Order: A block, then B block.
- Target: 10 completed matches per mode (PASS STRONG target).
- Max Attempts: 15 per mode.
- No manual combat input or assistance.
- Do not count time spent changing the profile between blocks.
- Do not discard ordinary slow/fast matches, poor boards, or natural recovery.
- Stop immediately on a critical gameplay/QTE safety violation.

No runtime instrumentation is added in Phase 3D.1. Existing structured events
already contain all authoritative timing boundaries, so live stage B0 is
skipped. The historical parser smoke is validation only and is not part of the
benchmark sample.

## Measurement definitions

`combat_duration_s` starts at the accepted `match_entry_result` opening, which
is identical to `MatchTelemetry.start_timestamp`, and ends at the FarmRunner
terminal-accounting timestamp `MatchTelemetry.end_timestamp`. The analyzer
recomputes the duration and rejects a disagreement with the stored duration.

`farm_cycle_duration_s` starts at the latest structured, ready, safe boss-lobby
observation before that match and ends at that attempt's structured, ready
`normal_return_boss_lobby`. A missing exact boundary produces `null` /
`NOT_MEASURED`; it is never estimated from a screenshot or stopwatch.

The major-action formula is:

```text
SWAP_sent + EVOLVE_attempts + ordinary_CAST_sent + PET_SKILL_attempts + PASS
```

QTE arrows and Space are reported separately and are not counted as gameplay
turns or major actions. `local_turns` is reported as a turn metric. The Desktop
UI label historically called this “turns / energy”, but it is not an
authoritative game-energy balance. Phase 3D.1 therefore records energy as
`NOT_MEASURED` unless direct before/after game-energy evidence is supplied for
every completed match.

## Pre-benchmark gate

From the repository root:

```powershell
$env:PYTHONPATH = "src"
python -m unittest tests.test_phase3d1_benchmark tests.test_basic_policy tests.test_phase3c1_pet_skill_policy tests.test_desktop_farm_controller tests.test_pet_skill_action tests.test_qte_direction_assist tests.test_terminal_result -v
python -m unittest discover -s tests
python -m compileall -q src tools tests
git diff --check
git status --short
git rev-parse HEAD
git rev-parse origin/main
```

Do not start B1 if any gate fails or the worktree is dirty. Record both revision
values; the tested benchmark commit may remain local until final Phase 3D.1
closeout, when `HEAD == origin/main` becomes mandatory.

## Live B1 — Mode A Default

1. Start the game and enter the exact Starburst `1289` boss lobby.
2. Start `run_tool.bat` yourself. Do not use external Windows automation for
   this benchmark.
3. In the tool's Preferences/Settings select:
   - Main Pet: `Normal`
   - Evolution: `Normal`
   - Damage card: `Default Attack`
   - Intelligence: `BASIC`
4. Keep all accepted common settings unchanged, including SIMPLE play style,
   Audition V3, board input mode, thresholds, and timing.
5. On Control set Target matches `10` and Max attempts `15`.
6. Start once. Do not make any manual gameplay input.
7. If a safety violation occurs, use the accepted stop control and preserve the
   run. Otherwise wait until 10 completions.
8. Before changing profile, verify the game is back at the exact boss lobby and
   the controller is `STOPPED`.
9. Record the FarmRunId shown by the UI/log.

## Live B2 — Mode B Pet Skill

1. Stay on Starburst `1289` and the same pinned source/build.
2. In the tool select:
   - Main Pet: `Legendary`
   - Evolution: `None`
   - Damage card: `Pet Skill`
   - Intelligence: `BASIC`
3. Keep every common setting identical to B1.
4. Set Target matches `10` and Max attempts `15`.
5. Start once and provide no manual gameplay input.
6. Stop immediately if EVOLVE or ordinary Attack CAST occurs, a Pet Skill is
   accepted below PERFECT, QTE direction/Space safety is violated, or any other
   critical input-safety violation appears.
7. Otherwise wait for 10 completions and verify exact boss lobby plus controller
   `STOPPED`.
8. Record the FarmRunId.

## Offline analysis

After both blocks are stopped, create
`docs/artifacts/phase3d1_manifest.json` with the actual order, pinned source,
boss and run IDs, then run:

```powershell
python tools/phase3d1_benchmark.py `
  --manifest docs/artifacts/phase3d1_manifest.json `
  --logs-root logs/farm_runs `
  --output docs/artifacts/phase3d1_matches.json `
  --markdown-output temp/phase3d1_comparison.md
```

The analyzer only reads source artifacts. It fails closed on wrong profiles,
wrong boss, corrupt/incomplete rows, counter disagreement, hidden attempt/result
accounting, incomplete declared energy measurement, or ambiguous timestamps.
Exclusions require an explicit reason and remain visible. Zero-attempt launches
remain separate pre-entry failures.

Review the compact dataset, generate the final human report, update
`docs/CURRENT_STATE.md`, rerun the full gate, commit, push, and verify
`HEAD == origin/main` with a clean worktree. Stop after Phase 3D.1; do not start
the 25-match Phase 3D.2 soak.
