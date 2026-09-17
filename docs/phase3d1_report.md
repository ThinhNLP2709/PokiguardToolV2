# Phase 3D.1 — Controlled A/B Performance Comparison

## Status

**PASS STRONG**

- Accepted Phase 3C.3 base and frozen benchmark source:
  `44fea0cc3e89d670dc273a5fae7c5cf94e8809b0`
- Source version: `v1.0.48`
- Runtime instrumentation added: none
- Valid sample: 10 Mode A matches and 10 Mode B matches
- Critical technical or QTE safety violations: 0
- Energy saving: `NOT_MEASURED`

Phase 3D.1 measured the accepted strategies without changing gameplay policy,
input timing, QTE behavior, recovery behavior or the target boss between the
two blocks. The repository's accepted Phase 3C.3 policy is authoritative: its
Sword-density floor is eight known Sword and it includes the documented
`SETUP_BLOCKED` fire path.

## Method

| Field | Value |
|---|---|
| Mode A | `simple / BASIC / NORMAL / NORMAL / DEFAULT_ATTACK` |
| Mode B | `skill_rush / BASIC / LEGENDARY / NONE / PET_SKILL` |
| Application path | `run_tool.bat` → Desktop UI → bounded FarmRunner |
| Source/build | Commit `44fea0cc`, version `v1.0.48` |
| Boss | Starburst `1289` for both blocks |
| Run order | Mode A, full stop at boss lobby, then Mode B |
| Board input | Two Click for both blocks |
| Target / max attempts | 10 / 15 per mode |
| Manual combat assistance | None |
| Combat boundary | accepted match opening → FarmRunner terminal accounting |
| Farm-cycle boundary | latest proven safe boss lobby before entry → proven safe boss lobby after result |
| Major-action formula | SWAP sent + EVOLVE attempts + ordinary CAST sent + Pet Skill attempts + PASS |
| Energy | `NOT_MEASURED`; local turns do not prove account-energy consumption |

The profiles intentionally use different pets and loadouts. Results compare the
complete accepted profiles and do not isolate the Pet Skill card. Natural board
variation was retained and all 20 valid matches remain in the primary sample.

## Source runs

| Mode | FarmRunId | Attempts | Completed | W/L/U | Final state |
|---|---|---:|---:|---:|---|
| A Default | `2876f169879548f790b3920e6894e491` | 10 | 10 | 10/0/0 | `FARM_RUN_COMPLETE / FARM_TARGET_COMPLETED / BOSS_LOBBY` |
| B Pet Skill | `e8a38744abbb4120b190118063c9a4dd` | 10 | 10 | 10/0/0 | `FARM_RUN_COMPLETE / FARM_TARGET_COMPLETED / BOSS_LOBBY` |

Neither run used a technical recovery, produced an UNKNOWN result or required
more than one attempt per completion. There are no exclusions.

## Comparison

Positive reductions mean Mode B used less or was faster.

| Metric | A Default | B Pet Skill | Difference A−B | B reduction |
|---|---:|---:|---:|---:|
| Completed matches | 10 | 10 | 0 | — |
| Attempts | 10 | 10 | 0 | 0.000% |
| Wins | 10 | 10 | 0 | — |
| Mean combat duration | 223.822 s | 127.056 s | 96.766 s | 43.233% |
| Median combat duration | 217.256 s | 125.677 s | 91.579 s | 42.153% |
| Mean farm-cycle duration | 235.905 s | 136.189 s | 99.716 s | 42.270% |
| Median farm-cycle duration | 228.820 s | 134.346 s | 94.474 s | 41.287% |
| Mean SWAP sent | 13.300 | 7.900 | 5.400 | 40.602% |
| Median SWAP sent | 13.500 | 8.000 | 5.500 | 40.741% |
| Total SWAP sent | 133 | 79 | 54 | 40.602% |
| Mean major actions | 16.600 | 8.900 | 7.700 | 46.386% |
| Median major actions | 16.000 | 9.000 | 7.000 | 43.750% |
| Total major actions | 166 | 89 | 77 | 46.386% |
| Mean local turns | 15.100 | 8.900 | 6.200 | 41.060% |
| Attempts per completion | 1.000 | 1.000 | 0.000 | 0.000% |

Duration distributions:

| Metric | A min / max / stddev | B min / max / stddev |
|---|---:|---:|
| Combat | 172.185 / 298.766 / 35.460 s | 87.780 / 174.825 / 29.530 s |
| Farm cycle | 184.336 / 310.277 / 35.096 s | 97.053 / 188.420 / 30.313 s |

Both mean and median favor Mode B for combat and full-cycle duration. Mode B
also used fewer SWAPs and fewer major actions in this bounded benchmark.

## Action and policy audit

| Counter | A Default | B Pet Skill |
|---|---:|---:|
| EVOLVE attempts | 16 | 0 |
| Ordinary Attack CAST sent | 7 | 0 |
| Pet Skill attempts / accepted | 0 / 0 | 10 / 10 |
| Pet Skill PERFECT | 0 | 10 |
| Pet Skill GOOD / BAD | 0 / 0 | 0 / 0 |
| PASS | 10 | 0 |
| Skill-rush branch leakage in Mode A | 0 | n/a |

Mode B used one accepted Pet Skill in every match. All ten were PERFECT and all
ten were immediate first-skill kills, giving a measured first-skill kill rate
of 100%. No boss survived the first skill, so no post-skill finisher or second
Pet Skill was needed.

Mode B fire reasons:

| Reason | Count |
|---|---:|
| `HP_PREP` | 1 |
| `SWORD_DENSITY` | 7 |
| `BOTH` | 1 |
| `VERY_LOW_HP` | 0 |
| `SETUP_BLOCKED` | 1 |

At first skill, mean boss HP ratio was 70.8%, median 72.5%, range 40.3–84.6%.
Mean known Sword count was 8.4, median 8, range 4–13. The setup recorded one
early boss-preparation Sword action, 18 resource choices that skipped a current
Sword opportunity, 25 choices leaving a direct boss Sword reply and nine
choices leaving an indirect reply. Those reply counters are strategic-risk
telemetry for this aggressive PlayStyle, not technical safety failures.

## Four-Sword final match

Mode B match `M_bcf5a8ff`, attempt 10, fired at turn 15 with:

- boss HP `69,276 / 84,180` (`82.295%`);
- four authoritative known Sword;
- `270 / 250` current Mana/Rage against `200 / 200` requirements;
- one legal direct clear, but no direct setup clear at Manhattan distance at
  least two from every known Sword.

The recorded reason is `SETUP_BLOCKED`, not HP preparation or Sword density.
The policy trace proves the distance-two setup branch was exhausted and states
that firing avoids disturbing the prepared Sword region. The analyzer now
requires that evidence and rejects a bare `SETUP_BLOCKED` label without it.
The skill resolved PERFECT and killed immediately. The operator visually
observed a critical hit; structured telemetry proves the immediate kill but
does not expose a separate critical-hit field.

This action matches the accepted Phase 3C.3 policy and is not a technical or
policy-contract violation. It does expose a strategic limitation: when isolated
setup is blocked, the current policy may fire with high boss HP and a low Sword
count, so one-hit success can depend on damage variance. Phase 3D.1 preserves
that result and does not retune the strategy mid-benchmark.

## QTE, reliability and safety

Mode B recorded 70/70 confirmed directions and ten in-window Space presses.
Wrong, skipped, duplicate, stale, unconfirmed and blind-retry directions were
all zero. Duplicate or outside-window Space was zero.

Both modes achieved 10 wins in 10 attempts. Technical aborts, recoveries,
result conflicts, UNKNOWN results, misclicks, partial inputs, wrong-turn
inputs, stale actions, boss-turn inputs, postmatch inputs, lobby gameplay
inputs, after-combat inputs and duplicate gameplay inputs were all zero.
Memory and result UI agreed on all 20 matches.

## Energy conclusion

`ENERGY_SAVING = NOT_MEASURED`.

Mode B used fewer local turns and major actions, but FarmRunner's local-turn
counter is not an authoritative game-owned energy balance. No energy saving is
inferred from speed or action reduction.

## Artifacts and verification

- Manifest: `docs/artifacts/phase3d1_manifest.json`
- Compact 20-match dataset: `docs/artifacts/phase3d1_matches.json`
- Deterministic analyzer: `src/pokiguard_v2/phase3d1_benchmark.py`
- Analyzer CLI: `tools/phase3d1_benchmark.py`
- Runbook: `docs/phase3d1_runbook.md`

Raw runtime logs remain ignored and are not committed. Final test counts and
the dataset digest are:

- focused policy/controller/QTE/analyzer suites: **245/245 PASS**;
- full regression: **1,286/1,286 PASS**;
- analyzer unit suite: **16/16 PASS**;
- analyzer replay: PASS, A=10 and B=10;
- `compileall`: PASS;
- `git diff --check`: PASS;
- compact dataset SHA-256:
  `F6E089ED28F63AB43116E2AE0ECD943DA71418AC13AAECD9CBB477BF93B47C3D`.

## Scope and conclusion

This is a 10-versus-10 engineering benchmark on one boss, one version and one
execution order. It does not establish statistical significance or generalize
to other bosses, Pet Skill families, evolved/Mega pets or HT2.

Phase 3D.1 is **PASS STRONG**. The experiment used the same frozen source,
boss and measurement definitions, achieved complete 10+10 samples with zero
critical safety violations, and retained every valid result. In this bounded
benchmark, Mode B was materially faster and used fewer board and major actions
than Mode A. Phase 3D.2's 25-match soak was not started.
