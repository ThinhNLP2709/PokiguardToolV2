# Phase 3D.2 Report — 25-Match Pet-Skill Reliability Soak

## Result

**PASS STRONG**

One immutable FarmRun completed exactly 25 matches in 25 attempts. All 25
results were authoritative WINs, every Pet Skill completed with runtime
`PERFECT`, and the first skill killed Starburst in every match. No attempt 26
was created.

## Source and scope

- Expected accepted base: `7130649144d4ffe375f080e26ed0a8c77bd11b94`.
- Actual frozen source: `5b620987320b4132c33ab7d1acc269901e7431b3`.
- Application version: `v1.0.49`.
- The actual source includes the separately committed lobby re-entry hardening
  completed before this soak. No production source or gameplay configuration
  changed after the FarmRun started.
- Phase 3D.2 made no gameplay-policy, QTE, input-timing or production behavior
  change.

The user operated the normal Desktop UI and supplied no manual combat input.
The project retained the external read-only state provider and normal
foreground Windows input architecture.

## Frozen profile

| Setting | Value |
|---|---|
| Boss | Starburst `1289` |
| PlayStyle | `skill_rush` / Chịu đấm ăn xôi |
| Intelligence | `BASIC` |
| Main Pet | `LEGENDARY` |
| Evolution | `NONE` |
| Damage Card | `PET_SKILL` |
| Fire condition | `sword_count` / Kiếm đủ |
| Fire value | `10` |
| Semantics | known effective Sword value `>= 10` |
| Audition | `audition_v3` |
| Board input | `two_click` |
| Target | 25 completed matches |
| Max attempts | 35 |

Preferences validation, Desktop Start and the checkpoint independently
recorded the same profile. Start locked the run limits and config.

## Canonical FarmRun

- FarmRun ID: `cdc37e234ec54b8f9c54bc718b92c636`
- Completed/attempts: `25/25`
- W/L/U: `25/0/0`
- Technical abort/recovery/exit: `0/0/0`
- Stop reason: `FARM_TARGET_COMPLETED`
- Finalized status: `COMPLETED`
- Extra attempt after target: `0`
- Final lifecycle: `BOSS_LOBBY`
- Final controller/FarmRunner: `STOPPED / STOPPED`
- Total measured local-turn energy units: `206`; mean `8.24`, range `5..12`.

All 25 terminal results had strong memory evidence, all 25 postmatch UI audits
were consistent WINs, and all 25 returns resolved the exact Starburst room.
Result accounting satisfies `wins + losses + unknown == completed == 25`.

## Pet Skill, QTE and freshness

- Accepted Pet Skills: `25`
- Immediate first-skill kills: `25`
- Second Pet Skills: `0`
- Runtime PERFECT/GOOD/BAD: `25/0/0`
- Directions sent/authoritatively confirmed: `175/175`
- Space confirms: `25`
- Wrong/duplicate/stale/old-session directions: `0/0/0/0`
- Duplicate/stale/old-session confirms: `0/0/0`
- Stale QTE across MatchIds: `0`
- Stale skill-card use: `0`

Every executable action ID, QTE generation, direction record and skill-card ID
belonged to its current MatchId/session. Server timing echo was
`NOT_OBSERVED`; the accepted authoritative runtime result was PERFECT in every
match and no server reject was observed.

Attempt 16 had one `FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING` preflight
rejection. It sent zero card clicks and zero Space, released the permit,
reacquired current state, and then completed one PERFECT action on the same
source turn. This is the intended fail-closed fresh-state rearm, not a
technical recovery or stale retry. A few transient torn QTE reads and
non-current Audition V3 candidates were also rejected before input.

## Gameplay and input safety

- SWAP sent/ACK/rejected/uncertain: `180/180/0/0`
- PASS: `0`
- EVOLVE: `0`
- Ordinary Attack before first skill: `0`
- Forced/intentional pre-first-skill Sword consumption: `0/0`
- Premature `SETUP_BLOCKED` skill: `0`
- Post-skill finisher: `0`
- Wrong-turn/boss-turn input: `0/0`
- Misclick/partial/duplicate/stale input: `0/0/0/0`
- Postmatch/lobby/after-combat gameplay input: `0/0/0`
- Sequence desync: `0`
- Duplicate controller/orphan controller/orphan poller: `0/0/0`

The run observed no natural technical recovery and no empty-room/general-hub
re-entry. Both are recorded as `NOT_OBSERVED`; deterministic recovery tests
remain green. The separately committed re-entry repair is therefore not
claimed as live-exercised by this soak.

## Verification

Pre-live and final verification both passed:

- Focused Pet Skill/QTE/FarmRunner suite: `694/694 PASS`
- Randomized input: `18/18 PASS` in `5/5` consecutive runs
- Full regression: `1366/1366 PASS`
- `compileall`: PASS
- `git diff --check`: PASS

## Evidence

- [Structured analysis](artifacts/phase3d2_soak_analysis.json)
- [Readable analysis](artifacts/phase3d2_soak_analysis.md)
- [Executed runbook](phase3d2_runbook.md)
- Raw immutable logs:
  `logs/farm_runs/cdc37e234ec54b8f9c54bc718b92c636/`

Phase 3D.2 is complete. Packaging, tagging and Phase 3E.1 remain outside this
phase.
