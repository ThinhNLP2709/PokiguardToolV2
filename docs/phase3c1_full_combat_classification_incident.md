# Phase 3C.1 — FULL_COMBAT_COMPLETED FarmRunner adapter incident

Date: 2026-09-14 (Asia/Saigon)

## Live evidence

FarmRun `b77eb786333345418e379777bf78cddd`, match `M_79773863`, completed the
Audition V3 Pet Skill successfully:

- one card click;
- expected sequence `LEFT, RIGHT, LEFT, LEFT, LEFT, LEFT, LEFT`;
- seven directions sent and seven authoritatively confirmed;
- zero wrong, skipped, duplicate, stale or unconfirmed directions;
- one Space at QTE elapsed `3.185 s`, within the `3.000..3.300 s` Perfect
  window and `0.035 s` from the selected `3.150 s` target;
- authoritative runtime result `PERFECT`;
- zero gameplay safety violations.

The skill killed Starburst in one use. Before controller cleanup, the read-only
terminal snapshot recorded boss HP `0/84180`, local HP `38134/49157`, UI text
`Thắng`, result `WIN`, confidence `STRONG`, and evidence from both PlayerStats,
the active-to-postmatch transition, and the terminal HP pair.

## Cause

The embedded controller ended normally with:

```text
stopReason=COMBAT_LIFECYCLE_ENDED
attemptClassification=FULL_COMBAT_COMPLETED
fullCombatResult=WIN
sessionCleared=true
pending=null
```

`tools/farm_cycle.py::_validate_combat_summary` allowed only
`FULL_MATCH_PASS` and `B5_PASS_STRONG`. Those are Phase 2/B5 classifications.
Phase 3C.1 deliberately runs with B3 pass acceptance and therefore uses the
general successful-combat classification `FULL_COMBAT_COMPLETED`. The adapter
returned `COMBAT_CLASSIFICATION_FULL_COMBAT_COMPLETED`, causing FarmRunner to
safe-stop before it could confirm the result UI or count the match.

The QTE, policy, input and terminal readers did not fail.

## Correction

The validator now also accepts exact `FULL_COMBAT_COMPLETED`. Acceptance still
requires all existing conditions:

- `COMBAT_LIFECYCLE_ENDED`;
- a completed terminal result with required evidence when the result is
  unknown;
- cleared session and no active or pending action;
- every safety counter equal to zero;
- authoritative postmatch observation or a proven postmatch timeout routed to
  the result UI handler.

`FULL_COMBAT_COMPLETED_WITH_SAFETY_FINDING` remains rejected.

The original combat log now validates as
`(True, POSTMATCH_RESULT_UI_REQUIRED)`, which routes FarmRunner to its bounded
result-confirm handler. Regression coverage includes both the accepted safe
classification and rejection of its safety-finding variant.

## Verification and remaining live gate

- combat-summary focused tests: **8/8 PASS**;
- Phase 3C.1 focused tests: **27/27 PASS**;
- complete regression: **1222/1222 PASS**;
- `python -m compileall -q src tools tests`: PASS;
- `git diff --check`: PASS.

Corrected FarmRun `6bcf4d8efa9a4e129cc32aa492a17b6a`, MatchId `M_8ba50c47`,
proved the remaining path: the validator routed to the result handler, one
result confirmation was sent, memory/UI both reported WIN, the match was
counted exactly once, and the run returned to the exact `BOSS_LOBBY`. Live B1
is PASS. One fresh completed B2 remains for cross-match generation isolation.
