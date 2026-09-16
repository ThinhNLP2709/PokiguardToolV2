# Phase 3D.1 — Controlled Performance / Efficiency A-B Comparison

## Status

**PASS STRONG**

- Accepted Phase 3C.2 base: `345cf9b026ab3c6435db511016c1ee25cad05f47`
- Benchmark source commit: `292114f4e3adf5fbf8b6cdd0cc0e78816d5dc204`
- Source version: `v1.0.47`
- Runtime instrumentation added: none
- Live B0: skipped because accepted structured telemetry already supplied the required boundaries
- Valid sample: 10 Mode A matches and 10 Mode B matches
- Critical safety violations: 0
- Energy: `NOT_MEASURED`

Phase 3D.1 compared the two accepted complete profiles. It did not retune gameplay policy, input pacing, Pet Skill readiness, QTE timing, Evolution, Attack, PASS, recovery, or the boss target.

## Method

| Field | Value |
|---|---|
| Mode A | Normal / Normal / Default Attack / BASIC |
| Mode B | Legendary / None / Pet Skill / BASIC |
| Application path | `run_tool.bat` → Desktop UI → bounded FarmRunner |
| Source/build | Commit `292114f4`, version `v1.0.47` |
| Boss | Starburst `1289` for both blocks |
| Run order | A block, then B block |
| Board input | Two Click for both included blocks |
| Target / max attempts | 10 / 15 per mode |
| Manual combat assistance | None |
| Combat boundary | accepted opening timestamp → FarmRunner terminal accounting timestamp |
| Farm-cycle boundary | latest proven safe boss lobby before entry → proven safe boss lobby after result |
| Major-action formula | SWAP sent + EVOLVE attempts + ordinary CAST sent + Pet Skill attempts + PASS |
| Energy | `NOT_MEASURED`; local turns are not an authoritative game-energy balance |

The profiles intentionally use different pets and loadouts. The result therefore compares profile B with profile A; it does not isolate the Pet Skill card by itself. Natural board RNG was retained and every valid completed match remained in the primary dataset.

## Source runs

| Mode | FarmRunId | Attempts | Completed | W/L/U | Final state |
|---|---|---:|---:|---:|---|
| A Default | `f7bb98e3a52b47158b4c20822688d0aa` | 10 | 10 | 10/0/0 | `COMPLETED / FARM_TARGET_COMPLETED` |
| B Pet Skill | `51d49d61b4a946c4855872f8a605ab2f` | 10 | 10 | 10/0/0 | `COMPLETED / FARM_TARGET_COMPLETED` |

Both runs ended at a proven boss lobby. Neither used a technical recovery, produced an UNKNOWN result, or required more than one attempt per completion.

One preliminary A-profile run, `f31cebe0d6aa4afaab8d3261b268832b`, is explicitly excluded. The operator pressed emergency stop while diagnosing an apparent Start delay, and that setup run still used DRAG before Two Click was pinned as the common included setting. It completed no match and is retained in the dataset's `excluded_runs` section with the analyzer parse error caused by its missing terminal timestamp.

## Results

| Metric | A Default | B Pet Skill | Difference A−B | B reduction |
|---|---:|---:|---:|---:|
| Completed matches | 10 | 10 | 0 | — |
| Attempts | 10 | 10 | 0 | 0.000% |
| Wins | 10 | 10 | 0 | — |
| Mean combat duration | 144.383 s | 125.594 s | 18.789 s | 13.013% |
| Median combat duration | 134.690 s | 127.323 s | 7.367 s | 5.470% |
| Mean farm-cycle duration | 156.643 s | 134.495 s | 22.148 s | 14.139% |
| Median farm-cycle duration | 148.070 s | 138.183 s | 9.887 s | 6.677% |
| Mean SWAP sent | 10.200 | 9.000 | 1.200 | 11.765% |
| Median SWAP sent | 9.500 | 9.500 | 0.000 | 0.000% |
| Total SWAP sent | 102 | 90 | 12 | 11.765% |
| Mean major actions | 11.900 | 9.600 | 2.300 | 19.328% |
| Total major actions | 119 | 96 | 23 | 19.328% |
| Mean local turns | 10.500 | 9.600 | 0.900 | 8.571% |
| Attempts per completion | 1.000 | 1.000 | 0.000 | 0.000% |

Combat-duration distributions:

| Mode | Min | Max | Population stddev |
|---|---:|---:|---:|
| A Default | 95.264 s | 207.547 s | 32.590 s |
| B Pet Skill | 86.881 s | 165.562 s | 25.222 s |

Farm-cycle distributions:

| Mode | Min | Max | Population stddev |
|---|---:|---:|---:|
| A Default | 106.366 s | 219.163 s | 32.411 s |
| B Pet Skill | 94.608 s | 172.963 s | 24.918 s |

In this bounded benchmark, profile B was faster on both mean and median combat duration. It also reduced mean full-cycle time, mean SWAP count, mean local turns, and mean major gameplay actions. Median SWAP count was identical, so the action advantage was visible in the mean and totals rather than every match.

## Action and QTE audit

| Counter | A Default | B Pet Skill |
|---|---:|---:|
| EVOLVE attempts | 14 | 0 |
| Ordinary Attack CAST sent | 3 | 0 |
| Pet Skill attempts/accepted | 0 | 6 |
| Pet Skill PERFECT | 0 | 6 |
| Pet Skill GOOD/BAD | 0/0 | 0/0 |
| PASS | 0 | 0 |

Mode A never invoked PetSkillAction. Mode B preserved the no-EVOLVE/no-ordinary-Attack contract. Four Mode B matches killed the boss before Pet Skill became actionable; the remaining six each used one accepted Pet Skill and all six resolved PERFECT.

Mode B QTE evidence is 42/42 confirmed directions and six in-window Space presses. Wrong, skipped, duplicate, stale, unconfirmed, blind-retry directions, duplicate Space, and outside-window Space are all zero.

## Reliability and safety

Both modes achieved 100% completion and 100% win rate with 10 attempts for 10 completions. Technical aborts, technical recoveries, result conflicts, UNKNOWN results, PASS, wrong-third-PASS events, misclicks, partial inputs, wrong-turn inputs, stale actions, boss-turn inputs, postmatch inputs, lobby inputs, after-combat inputs, and duplicate inputs are all zero in the included samples.

Memory and result-UI classification agreed for all 20 completed matches. The analyzer reports `critical_safety_violations=0`, consistent result accounting, identical source/build declarations, the same verified boss, and a complete PASS STRONG sample.

## Energy conclusion

Authoritative game-energy consumption was not available per match. FarmRunner's historical “energy” display is a local-turn count and cannot prove account energy spent. Phase 3D.1 therefore reports energy saving as `NOT_MEASURED`.

Profile B used 0.9 fewer local turns per match on average and 23 fewer major gameplay actions across the sample. These are measured turn/action reductions, not proof of energy saving.

## Artifacts

- Manifest: `docs/artifacts/phase3d1_manifest.json`
- Compact dataset: `docs/artifacts/phase3d1_matches.json`
- Deterministic analyzer: `src/pokiguard_v2/phase3d1_benchmark.py`
- Analyzer CLI: `tools/phase3d1_benchmark.py`
- Runbook: `docs/phase3d1_runbook.md`

Raw runtime logs remain ignored and are not committed.

## Offline verification

- Focused Phase 3D.1/policy/controller/QTE/terminal suites: **209/209 PASS**
- Full regression: **1247/1247 PASS**
- `compileall`: PASS
- `git diff --check`: PASS
- Analyzer replay: PASS, A=10 and B=10
- Compact dataset SHA-256: `B38C50F689C25051624C768C7412C16595F18BEBBB3B11F47CDCEF9FF89F5717`

## Scope and limitations

This is a 10-versus-10 engineering benchmark on one boss, one application version, one execution order, and naturally different boards. It does not establish statistical significance or generalize to other bosses, Pet Skill families, evolved/Mega pets, or HT2. Pet and loadout differences are intentional, so the observed advantage belongs to the complete accepted B profile.

No natural technical recovery or detached-room re-entry occurred. Energy remains unmeasured. Phase 3D.2's 25-match soak was not started.

## Conclusion

Phase 3D.1 is **PASS STRONG**. The controlled measurement process is complete, both samples meet the preferred size, all safety and profile invariants hold, and the analyzer accepted the complete evidence. In this bounded Starburst benchmark, the accepted Legendary / No Evolution / Pet Skill profile was faster and required fewer mean actions than the accepted default profile, while both retained identical 10/10 completion reliability.
