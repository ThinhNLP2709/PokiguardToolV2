# Phase 3D.1-R1 — Generic Pet-Skill Fire Condition

## Status

**PASS STRONG — THREE-STAGE SKILL RUSH AND REFRESHED A/B COMPLETE**

- Base: `37c922ec2812d8082fa7748219ffffbe2326af06`
- Source version: `v1.0.49`
- Generic-condition revision and detailed three-stage farm strategy: offline
  PASS
- Accepted R1 live validation: PASS, 5/5 preserved (4 WIN + 1 explicit
  operator-accepted completed combat whose raw terminal result remains UNKNOWN)
- Refreshed Mode A: PASS, 10/10
- Refreshed Mode B: PASS, 10/10 WIN and 10/10 one-skill PERFECT kills
- Refreshed analyzer/artifacts: PASS, exact A10/B10 accounting
- Final verification: 94/94 focused, 1,354/1,354 full regression, randomized
  input 18/18 repeated five times
- Package/tag: outside this task

Historical Phase 3D.1 evidence remains immutable. The accepted R1 live block
still proves five completed Perfect skill runs, but its former strict boundary
does not validate firing at exactly ten under the current inclusive meaning of
`Kiếm đủ / 10`.

## Revision

The Sword-only preference was replaced by the generic `Điều kiện ra skill`
model.

## UI

The existing right-hand outer grid cell is unchanged; it contains one
child frame split into a readonly condition dropdown and a numeric Entry.

The dropdown order and labels are exactly:

1. `Đủ mana skill`
2. `Kiếm đủ`
3. `Mana Đủ`
4. `Nộ đủ`
5. `Hút đủ`
6. `Khiên đủ`

The whole condition row, Audition control and Audition help are visible only
for `PET_SKILL`. They are hidden for `DEFAULT_ATTACK`, and their persisted
values have no gameplay effect in that profile. Repeated hide/show preserves
the selected condition, last valid count and Audition mode.

`Đủ mana skill` empties and disables the numeric Entry. Every gem-count choice
enables it and restores the last valid count. Active count values accept ASCII
decimal digits in `0..256`; invalid or empty active values block Start/Resume.

## Config

| Contract | Value |
|---|---|
| Stable enum | `PetSkillFireCondition` |
| Condition key | `pet_skill_fire_condition` |
| Optional value key | `pet_skill_fire_value` |
| Default | `sword_count / 10` (`Kiếm đủ / 10`) |
| Count comparison | inclusive multiplier-weighted `known_effective_count >= configured_value` |
| Skill-cost value | `None`; stale numeric values are ignored |
| Persistence | Preferences and checkpoint |
| Active run | immutable accepted Start/Resume snapshot |

The enum values are `skill_cost_ready`, `sword_count`, `mana_gem_count`,
`rage_gem_count`, `drain_gem_count`, and `shield_gem_count`. Vietnamese strings
are display labels only.

An old `skill_rush_sword_threshold = N` with no generic fields migrates to
`sword_count / N`. A configuration older than that field migrates to
`sword_count / 10`. Invalid persisted enums or active count values fail through
the existing safe preference/checkpoint paths and never become active policy.

Preferences, immutable FarmRun configuration and checkpoint/resume preserve
the exact condition/value pair. `skill_cost_ready` persists and resumes with a
null value; executable QTE state is still excluded from checkpoints.

## Semantics

`skill_resources_ready` continues to come from the current authoritative Pet
Skill capability and its runtime resource costs. No generic condition hard
codes Legendary Mana/Rage costs.

| UI condition | Runtime condition |
|---|---|
| `Đủ mana skill` | authoritative current skill resources are sufficient; no numeric value |
| `Kiếm đủ` | current known `GemType.SWORD` count `>= value` |
| `Mana Đủ` | current known `GemType.MANA` board count `>= value` |
| `Nộ đủ` | current known `GemType.RAGE` board count `>= value` |
| `Hút đủ` | current known `GemType.DRAIN` board count `>= value` |
| `Khiên đủ` | current known `GemType.SHIELD` board count `>= value` |

All board values use only the accepted current 8x8 board. Known x1/x2/x3/x4
cells contribute 1/2/3/4; UNKNOWN adds zero. Screenshots, OCR, predicted refill,
stale boards and old MatchId state never prove readiness. `Mana Đủ` sums Mana
gem multipliers on the board; it does not inspect the player's Mana meter.

Normal Pet Skill authorization still requires both actual runtime resources
and the selected condition, followed by every existing session, lifecycle,
local-turn, capability, cooldown, foreground, actionability, QTE freshness,
technical and Emergency Stop gate. A board count can never bypass missing
resources.

## Regression

- Boss HP still cannot authorize a normal first skill.
- `HP_PREP_READY`, `HP_PREP_SWORD` and intentional pre-skill Sword damage are
  absent.
- `SETUP_BLOCKED` remains setup relaxation only and cannot authorize skill.
- Direct, indirect and UNKNOWN boss Sword replies prefer safe progress during
  resource collection and hard-filter count-based setup whenever a safe
  preserving action exists. Distance two is a setup preference inside the safe
  pool, not standalone safety proof.
- Missing Mana/Rage remains first. Without safe progress, a player above 30%
  HP takes the best Sword-preserving missing-resource move before Drain,
  Shield or turnover, even when the move leaves Sword risk for the boss. Every
  pre-first-skill action must preserve all known Sword, at every Rage value.
  At or below 30%, or when HP is unknown, safe protection/survival may precede
  unsafe resource progress. PASS is the last option; after
  its budget is exhausted, choose a mandatory non-Sword action. If every legal
  move consumes Sword, fail closed.
- `skill_cost_ready` skips board setup. A count-based setup preserves both
  Sword and the selected condition GemType. If no safe preserving setup exists,
  use an allowed PASS, then a mandatory lowest-risk preserving non-Sword action.
  If every legal action consumes Sword or the setup gem, fail closed.
- Generic fire conditions choose when to fire; they do not create six separate
  collection policies.
- The later-turn post-skill finisher uses fresh boss HP ratio `<=30%`.
- A later second Pet Skill uses the same selected normal fire condition.
- Source-turn closure, current MatchId ownership, QTE freshness and Emergency
  Stop behavior remain unchanged.

The canonical fire reason is `SKILL_RUSH_FIRE_CONDITION_READY`. Telemetry now
records condition, optional value, selected GemType/count, condition readiness,
runtime resource proof, action reason and current-match history. Historical R1
Sword telemetry remains readable as a narrow compatibility input; canonical
product configuration and new benchmark metadata use the generic fields.

## Tests

| Check | Result |
|---|---:|
| Skill Rush policy, including exact latest-live boards | 63/63 PASS |
| Preferences + Tk persistence/visibility | 29/29 PASS |
| Preference migration class | 6/6 PASS |
| Checkpoint/resume class | 11/11 PASS |
| Phase benchmark + Skill Rush focused suite | 94/94 PASS |
| Full regression | 1,354/1,354 PASS |
| User-owned randomized-input suite | 18/18 PASS, repeated 5/5 runs |
| `compileall` for `src`, `tools`, `tests` | PASS |
| `git diff --check` | PASS |

Coverage includes all six conditions, inclusive 9/10 boundaries for all five
GemTypes, runtime resource gating for every count condition, UNKNOWN exclusion,
numeric validation, hidden DEFAULT_ATTACK behavior, one-cell UI layout,
persistence, old-key migration, active-run immutability, checkpoint/resume,
the historical 82.3%/four-Sword fixture, SETUP_BLOCKED, post-skill finisher,
second skill, source-turn closure, PetSkillAction, Audition V3/V2, QTE freshness
and Emergency Stop. It also replays the stopped Mode-B turn-1/turn-13 boards
plus the latest diagnostic turn-13/turn-17 boards. Those fixtures verify safe
Mana/Rage priority over safe Drain/Shield while HP is above 30%,
healthy-player risk acceptance, low-HP Shield/Health priority,
authoritative PASS as the last option, mandatory non-Sword fallback, generic
setup-gem preservation and zero self-Sword consumption at every Rage value.

The user's randomized-input changes remain intact. Unrelated user-owned files
remain unstaged and untouched.

## R1 live 5 — preserved

- FarmRun: `401e5153c44b437f8abc3698b383c981`
- Profile: `skill_rush / BASIC / legendary / none / pet_skill`
- Boss: Starburst `1289`
- Historical run semantics: strict `known Sword > 10`
- Accepted matches: `5/5`
- First-skill known Sword counts: `11, 11, 11, 11, 11`
- Runtime resources complete at every proposal
- Pet Skill: `5/5 PERFECT`
- Evolve / ordinary Attack / Pass: `0 / 0 / 0`
- Forced / intentional pre-first-skill Sword consumption: `0 / 0`
- Wrong-turn input / misclick: `0 / 0`
- Authoritative FarmRunner results: four WIN; fifth terminal result UNKNOWN
  because the user exited immediately after completed combat

The user explicitly accepted the fifth combat as completed. Its log records
`FULL_COMBAT_COMPLETED`, one PERFECT Pet Skill and normal lifecycle end; the
report does not rewrite UNKNOWN into WIN. The earlier threshold-7 run
`19965d7daa384980b86eb0675a44d9d7` remains excluded.

The accepted live 5 remains valid as historical completed-match evidence. The
current revision keeps default `sword_count / 10` with inclusive `>=` semantics;
the refreshed Mode B block below validates that boundary and the final fallback
behavior independently.

## Inclusive-boundary smoke and no-safe fallback correction

FarmRun `b9a40538eda54da595b0d4b76fae1f41` completed 1/1 WIN, 17 local
turns, 16 acknowledged SWAPs, zero PASS and one `SUCCESS_PERFECT` Pet Skill
that killed the boss. The running pre-correction process observed exactly ten
known Sword with resources ready on local turn 13 but did not fire under the
former strict `> 10` comparison; it later fired at 11.

That turn also proved all six legal moves unsafe. The old fallback first
discarded Sword-consuming moves, then selected `(0,5)<->(0,6)`, which left two
UNKNOWN Sword completions; the boss consumed Sword before the next local turn.
The intermediate correction compared all legal moves and selected
`(2,5)<->(3,5)`, which consumed three Sword ourselves while reducing the boss
reply risk. The canonical three-stage strategy supersedes that behavior at
every Rage value: the exact board may choose a non-Sword risky resource move
when the player is healthy, but it can never self-consume Sword. Exact-board
regressions cover resource-incomplete and setup branches. This smoke is
diagnostic evidence only and does not count toward refreshed Mode B10.

## Refreshed Mode A — PASS

- FarmRun: `fb3fddffb1f14442b31f92c473edc56e`
- Profile: `simple / BASIC / normal / normal / default_attack / two_click`
- Limits: target 10, max attempts 15
- Result: 10/10 completed, 10 WIN, 0 LOSS, 0 UNKNOWN
- Attempts: 10; technical abort/recovery/exit: 0/0/0
- Result accounting: consistent 10/10; final lifecycle `BOSS_LOBBY`
- Controller: `STOPPED`, reason `FARM_TARGET_COMPLETED`, exit code 0
- Pet Skill proposals/attempts: 0/0
- Nonzero `SKILL_RUSH_*` policy steps: 0
- All Skill Rush fire/setup/finisher counters: 0
- Misclick, wrong-turn input, rejected SWAP: 0
- One transient provider read error was recovered inside normal polling; it
  caused no DTO rejection, technical abort, recovery or result ambiguity.

The hidden Pet Skill condition/Audition values had zero gameplay effect.

## Refreshed Mode B — stopped sample rejected

- FarmRun: `26fbc39c62ca469e89c779ee5d2e7f2b`
- Result: user Emergency Stopped during match 1; accepted benchmark count `0/10`
- No completed match is retained from this run.
- Root cause: resource/setup ranking treated Manhattan distance and known-Sword
  preservation as stronger than `SwordRisk.safe`. Turn 13 selected a
  distance-two Shield clear with three deterministic boss Sword replies; turn
  15 selected a distance-two Rage clear with two replies. Unsafe resource
  progress also occurred on turns 1, 3 and 11 while safe moves existed.
- Remediation: hard safe-pool boundary in both resource and setup branches;
  safe Mana/Rage, then Drain, then Shield; absolute pre-skill Sword
  preservation; HP-aware lowest-risk non-Sword fallback; PASS only as the last
  available option.
- Exact turn-1 and turn-13 board snapshots are regression fixtures.

## Latest live diagnostic — stopped accounting, policy finding retained

- FarmRun: `e4dbca0f44ea46cca5afac3984766dda`
- Visible result: WIN; controller result: `SAFE_STOP / COMBAT_TERMINAL_UNPROVEN`
- Accepted benchmark count: `0/10`
- Local/boss turns: 15/14
- Formal PASS proposals/executions: 0/0
- Pet Skill: proposed on local turn 29 at Mana/Rage `730/250` and exactly ten
  known Sword; QTE result PERFECT
- Inclusive threshold result: correct; the skill fired on the first state where
  both runtime resources and the configured board threshold were ready
- Policy defect: turn 13 consumed three known Sword and turn 17 consumed four.
  This delayed the qualifying board and contradicted the farm setup strategy.
- Correction: every pre-first-skill candidate requires
  `knownSwordConsumed=0`. Because the observed player HP was above 30%, the
  exact turn-13 and turn-17 boards now select the lowest-risk non-Sword
  Mana/Rage action before PASS. Separate fixtures cover low-HP survival, PASS
  as last resort and a mandatory non-Sword action after two PASS turns.
- Offline validation at that revision: Skill Rush 61/61; full repository
  1,349/1,349.

## Multiplier-weighted live regression — PASS

FarmRun `03ceea93d6254ed1a4f4dac54562e85a` completed 1/1 WIN with 9
energy. On turn 15 it had Mana/Rage `270/250`, cost `200/200`, actionable skill,
9 physical Sword cells and 12 effective Sword from x3/x2. The old physical-cell
comparison selected a safe Shield clear, then fired on turn 17 at 10 cells / 16
effective Sword. This is a policy definition defect rather than stale board or
CardUI delay. The exact board is now an offline regression: it must fire on
turn 15. Telemetry and the analyzer distinguish physical cells from effective
value, and the configured threshold uses effective value.

FarmRun `b55706d7afd54b48a2fc9ec3167b92e4` then validated the corrected source:

- Result: 1/1 WIN, 6 energy, 5 acknowledged SWAPs, zero PASS
- Fire turn: local turn 11 at Mana/Rage `270/210`, required `200/200`
- Board threshold: 9 physical Sword cells, 12 effective Sword, configured 10
- Decision: immediate `PET_SKILL`; no extra setup SWAP and no pre-skill Sword
  consumption
- QTE/result: `SUCCESS_PERFECT`, immediate skill kill from boss HP
  `59,414/84,180`
- Safety: one zero-input preflight requested fresh state; it sent no Windows
  input and retried successfully on the same source turn

This 1/1 run is the accepted live regression for multiplier counting. It is
kept separate from the continuous refreshed Mode B10 benchmark block.

## Refreshed Mode B — resource-priority stop rejected

- FarmRun: `420227ce72734e28a0fa4a89e0827f7f`
- Controller accounting: two completed WINs, then Emergency Stop during
  attempt 3; the run is rejected from the refreshed continuous B10 block
- Finding: at local turn 15 of attempt 3, player HP was 75.2% and Mana/Rage was
  `90/250`. A Sword-preserving Mana x3 move at `(0,4)<->(0,5)` existed with
  refill Sword risk, while a safe Shield move at `(6,3)<->(6,4)` existed. The
  old ordering selected Shield.
- Correction: while HP is above 30%, missing Mana/Rage progress precedes Drain,
  Shield and turnover even when the resource move is not Sword-safe. It still
  may not consume known Sword. Low/unknown HP keeps the survival preference.
- Exact-board regression: current policy selects the Mana move, records
  `SKILL_RUSH_RESOURCE_RISK_ACCEPTED`, `knownSwordConsumed=0`, and does not
  choose the safe Shield.
- Offline validation at that correction: Skill Rush 63/63; full repository
  1,351/1,351. Final phase validation later reached 1,354/1,354.

FarmRun `ae7bca6157f242689e4ad863c52416b5` is the accepted 1/1 live smoke for
that correction:

- Result: 1/1 WIN, 7 energy, zero PASS and zero pre-skill Sword consumption
- Live branch proof: local turn 7 had 61.1% HP and no safe Mana/Rage progress;
  the only missing-resource move was Rage x3 with three direct boss Sword
  replies
- Decision: `SKILL_RUSH_RESOURCE_RISK_ACCEPTED`, Rage selected before
  protection, `knownSwordConsumed=0`
- Completion: resources ready, Sword-safe setup, then `SUCCESS_PERFECT` on
  local turn 13 at 10 physical / 15 effective Sword; immediate skill kill

The smoke proves the corrected ordering once and remains separate from the
continuous refreshed Mode B10 benchmark block.

## Refreshed Mode B — PASS

- FarmRun: `ee83bac8f35241c7a08afdff048632e2`
- Profile: `skill_rush / BASIC / legendary / none / pet_skill`, V3, Two Click
- Boss: Starburst `1289`; limits target 10, max attempts 15
- Result: 10/10 completed, 10 WIN, 0 LOSS, 0 UNKNOWN in exactly 10 attempts
- Pet Skill: 10 proposals, 10 accepted, 10 `SUCCESS_PERFECT`, 10 immediate
  one-skill kills
- Board input: 69/69 acknowledged SWAPs, zero reject; PASS / EVOLVE / ordinary
  Attack before first skill: `0 / 0 / 0`
- Safety: zero misclick, partial input, wrong turn, stale action, third PASS,
  forced Sword consumption or intentional pre-skill Sword consumption
- Resource policy: 25 explicit `SKILL_RUSH_RESOURCE_RISK_ACCEPTED` decisions;
  every one preserved current known Sword
- Setup audit: two `RELAXED_DISTANCE` moves, zero premature skill and zero
  Sword-consuming fallback
- Final controller: `FARM_RUN_COMPLETE / FARM_TARGET_COMPLETED`, terminal
  memory evidence consistent, normal return to `BOSS_LOBBY`
- Two transient provider read errors recovered through ordinary polling with
  zero DTO rejection, recovery attempt, result ambiguity or extra input

The ten fire states used physical/effective Sword counts
`10/10, 10/10, 11/13, 8/10, 8/11, 9/12, 7/10, 10/14, 8/10, 14/16`.
Every effective value satisfies the inclusive configured threshold. This proves
that x2/x3 multipliers participate in readiness and that physical cell count no
longer delays the skill. Match-local turn counts were
`8, 6, 7, 8, 9, 10, 7, 8, 6, 10` (79 total). Formal external energy deltas were
not captured, so the benchmark reports energy as `NOT_MEASURED` rather than
converting those turn counts into a fabricated energy measurement.

## Refreshed A/B result

| Metric | Mode A default | Mode B Skill Rush | B reduction |
|---|---:|---:|---:|
| Mean combat duration | 174.954 s | 111.745 s | 36.129% |
| Median combat duration | 160.004 s | 106.802 s | 33.250% |
| Mean full farm cycle | 189.016 s | 121.187 s | 35.885% |
| Mean primary gameplay actions | 13.4 | 7.9 | 41.045% |
| Attempts per completion | 1.0 | 1.0 | 0% |

Mode A and Mode B both finished 10/10 with exact result accounting and zero
critical safety violation. Mode A had no Pet Skill or Skill Rush branch leakage.
Mode B achieved a 100% first-skill kill rate without EVOLVE or PASS.

Canonical reproducible evidence:

- `docs/artifacts/phase3d1_r1_manifest.json`
- `docs/artifacts/phase3d1_r1_analysis.json`
- `docs/artifacts/phase3d1_r1_analysis.md`

The analyzer preserves the historical R1 fifth result as UNKNOWN and records
the user's explicit completion acceptance separately; it never rewrites the raw
FarmRun. Phase 3D.1-R1 is complete at **PASS STRONG**. Phase 3D.2, packaging and
tagging remain outside this task.
