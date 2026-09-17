# Phase 3D.1 Runbook — Controlled Performance / Efficiency A-B Comparison

## Completion record

Phase 3D.1 completed **PASS STRONG** on frozen source commit
`44fea0cc3e89d670dc273a5fae7c5cf94e8809b0`, version `v1.0.48`.

Included blocks:

- Mode A FarmRun `2876f169879548f790b3920e6894e491`
- Mode B FarmRun `e8a38744abbb4120b190118063c9a4dd`

Each block completed 10/10 wins in ten attempts on Starburst `1289`, returned
to a proven boss lobby and recorded zero critical technical/QTE safety
violations. See `docs/phase3d1_report.md` for results and `docs/artifacts/` for
the manifest and compact dataset.

## Frozen comparison

| Mode | PlayStyle | Main Pet | Evolution | Damage card | Intelligence |
|---|---|---|---|---|---|
| A Default | Simple | Normal | Normal | Default Attack | BASIC |
| B Pet Skill | Chịu đấm ăn xôi | Legendary | None | Pet Skill | BASIC |

Both blocks use the normal `run_tool.bat` → Desktop UI → bounded FarmRunner
path, Two Click board input, Audition V3 and the same accepted common settings.
The complete profiles differ by pet/loadout by design.

The authoritative Mode B policy is the accepted repository state at v1.0.48:

- HP preparation: boss ratio strictly below 50%;
- Sword density: at least eight authoritative known Sword;
- resources: current runtime Mana and Rage must satisfy current capability;
- very-low boss region: at or below approximately 30%;
- with resources ready below both normal fire conditions, setup uses direct
  non-Sword clears at Manhattan distance at least two from every known Sword;
- if no such clear exists and CardUI is actionable, fire as `SETUP_BLOCKED`;
- after a successful current-match skill, a later-turn ordinary finisher is
  allowed only when boss HP is below 30,000 or ratio is below 20%.

Do not substitute the superseded `>10` Sword text from the original planning
prompt for the accepted eight-Sword repository rule.

## Measurement definitions

`combat_duration_s` runs from the accepted match-opening timestamp to the
FarmRunner terminal-accounting timestamp.

`farm_cycle_duration_s` runs from the latest structured, ready boss-lobby
observation before entry to that attempt's structured, ready
`normal_return_boss_lobby`. Missing boundaries remain `NOT_MEASURED`.

Major gameplay actions are:

```text
SWAP_sent + EVOLVE_attempts + ordinary_CAST_sent + PET_SKILL_attempts + PASS
```

QTE directions and Space are audited separately. Energy is
`NOT_MEASURED`; local turns do not prove a game-owned energy delta.

## Reproduction procedure

Before a future rerun, verify the intended source revision and run:

```powershell
$env:PYTHONPATH = "src"
python -m unittest tests.test_phase3d1_benchmark tests.test_basic_policy tests.test_phase3c1_pet_skill_policy tests.test_phase3c3_skill_rush_policy tests.test_desktop_farm_controller tests.test_pet_skill_action tests.test_qte_direction_assist tests.test_terminal_result -v
python -m unittest discover -s tests
python -m compileall -q src tools tests
git diff --check
git rev-parse HEAD
git rev-parse origin/main
```

Run Mode A first with Target `10`, Max attempts `15`, then fully stop at the
exact Starburst `1289` boss lobby. Switch only the profile fields listed above
and run Mode B with the same limits. Do not provide manual combat input and do
not discard slow matches, poor boards or natural recovery.

Stop and preserve evidence for wrong/stale/duplicate QTE or gameplay input,
Mode B EVOLVE, invalid Mode B Attack, non-PERFECT accepted Pet Skill, result
conflict, wrong target/profile or a source change between blocks.

## Offline analysis

The checked-in manifest records the actual order and run IDs. Rebuild the
dataset with:

```powershell
$env:PYTHONPATH = "src"
python tools/phase3d1_benchmark.py `
  --manifest docs/artifacts/phase3d1_manifest.json `
  --logs-root logs/farm_runs `
  --output docs/artifacts/phase3d1_matches.json `
  --markdown-output temp/phase3d1_comparison.md
```

The analyzer is read-only with respect to runtime logs. It fails closed on
wrong profiles/boss, incomplete or inconsistent accounting, invalid skill-fire
reasons, unproven `SETUP_BLOCKED`, invalid Mode B Attack, QTE violations or
ambiguous timing.

Phase 3D.1 ends after report, regression, one focused commit and push. It does
not include the Phase 3D.2 25-match soak, packaging, tagging or release work.
