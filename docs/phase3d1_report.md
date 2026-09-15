# Phase 3D.1 — Controlled Performance / Efficiency A-B Comparison

## Status

**READY FOR LIVE B1/B2**

- Base commit: `345cf9b026ab3c6435db511016c1ee25cad05f47`
- Source version: `v1.0.47`
- Benchmark source commit: to be pinned after the pre-benchmark analyzer commit
- Runtime instrumentation: none
- Live B0: skipped because existing accepted telemetry supplies exact boundaries
- Historical parser smoke: passed on one prior Default run and one prior
  five-match Pet Skill run; these runs are not benchmark samples

This report remains open until both controlled blocks, offline analysis, final
regression, documentation, commit, push, and clean-worktree verification finish.

## Fixed comparison method

| Field | Value |
|---|---|
| Mode A | Normal / Normal / Default Attack / BASIC |
| Mode B | Legendary / None / Pet Skill / BASIC |
| Path | Normal Desktop UI and bounded FarmRunner |
| Boss | Starburst `1289`, identical for A and B |
| Order | A block, then B block |
| Target | 10 completed matches each |
| Max Attempts | 15 each |
| Manual combat assistance | None |
| Combat boundary | accepted opening → FarmRunner terminal accounting |
| Cycle boundary | safe boss lobby before entry → safe boss lobby after result |
| Energy | `NOT_MEASURED`; `local_turns` is not authoritative game energy |

The comparison covers the complete profiles; pet/loadout differences are
intentional. Board RNG remains natural. All valid completed matches remain in
the primary dataset, and natural technical abort/recovery remains in operational
attempt accounting.

## Analyzer

`src/pokiguard_v2/phase3d1_benchmark.py` is an offline-only parser and statistics
module. It has no gameplay-controller imports and no authority over policy,
input, timing, FarmRunner, or QTE. It computes mean, median, min, max, population
standard deviation, totals, attempts/completion, completion rate, QTE metrics,
and A-minus-B reductions. Division by zero produces `null`, not a fabricated
percentage.

The compact final dataset will be written to
`docs/artifacts/phase3d1_matches.json`. Raw runtime logs remain ignored.

## Results

Pending Live B1 and B2. The final report will include the analyzer-generated
comparison table and explicit conclusions for combat speed, full-cycle speed,
SWAP/action efficiency, reliability, energy, safety, exclusions, and scope.
