# Phase 3C.3 — Chịu đấm ăn xôi

## Status

- Revision: **Final HT7 One-Hit Setup + Post-Skill Finisher**
- Result: **PASS STRONG**
- Base commit: `88a50a0d7be499c95f52c881f0d5e17f96bdad68`
- Phase commit: this final Phase 3C.3 commit (see Git history)
- Source version: `v1.0.48`
- Pushed: yes

The earlier Phase 3C.3 B1/B2 runs remain historical evidence because they used
the superseded immediate-skill policy. The accepted historical default B3 is
retained unchanged. No benchmark, soak, package or tag belongs to this revision.

## Supported profile

- PlayStyle identity: `skill_rush`
- Desktop label: `Chịu đấm ăn xôi`
- Exact scope: `LEGENDARY / NONE / PET_SKILL / BASIC`
- Skill family: current proven HT7 automatic board-effect family
- Default PlayStyle: unchanged (`simple`)
- Other profiles: blocked by `SKILL_RUSH_PROFILE_NOT_IMPLEMENTED`

## Final pre-skill policy

The policy derives four stages from each authoritative state:

1. `EARLY_BOSS_PREP`
2. `RESOURCE_AND_BOARD_SETUP`
3. `PET_SKILL`
4. `POST_SKILL_FINISHER`

One ordinary early 3-Sword clear may prepare the boss while boss HP is at least
50%. Fresh boss ratio `< 0.50` completes HP preparation. Approximately 35% is a
lower preparation margin rather than the target. The approximately 30% boss
evolution region is user-provided gameplay knowledge, not an exact reverse-
proven trigger.

Mana/Rage requirements come only from current `PetSkillCapability`. While a
requirement is missing, deterministic current-deficit progress ranks first.
Full resources and UNKNOWN refill receive zero readiness credit. Equivalent
moves consume fewer existing Sword, preserve more known result-board Sword,
then prefer known non-Sword turnover in zero/low-Sword rows or columns.

Only known `GemType.SWORD` cells on the authoritative 64-cell board count.
`known_sword_count >= 8` is the revised practical high-density setup condition. A ready and
actionable skill fires when:

```text
boss_hp_ratio < 0.50 OR known_sword_count >= 8
```

Boss ratio at or below approximately 30% records `VERY_LOW_HP` and fires when
resources are ready. If resources are ready but boss ratio is at least 50% and
known Sword is below 8, setup continues. Once resources are ready, the policy
first restricts setup to direct non-Sword clears at Manhattan distance at least
2 from every known Sword. If none exists and the skill is actionable, it fires
with `SETUP_BLOCKED`; it does not clear beside the prepared Sword region. Only
a temporarily non-actionable CardUI permits the least-adjacent fallback.
UNKNOWN refill never receives predicted Sword-spawn credit.

Direct/indirect boss Sword replies remain strategic-risk telemetry only in
this PlayStyle. Existing hard actionability/input safety and proven survival
branches stay intact. SIMPLE/CAREFUL keep their prior Sword-first behavior.

## Post-skill finisher

Runtime records accepted `SUCCESS_PERFECT` turns only under the exact
`CombatSessionKey`. The record is memory-only, is cleared at session end and is
not serialized into checkpoints. A previous match can never unlock the next.

The successful skill closes its source turn. No Attack, SWAP, PASS or second
skill may occur there. On a later authoritative local turn, fresh current boss
stats enable `POST_SKILL_FINISHER` only when:

```text
current_boss_hp < 30,000 OR current_boss_hp / max_boss_hp < 0.20
```

Both comparisons are strict. Affordable actionable ordinary Attack is first;
otherwise a deterministic Sword move may finish. EVOLVE stays disabled. Above
both thresholds ordinary Attack remains blocked, normal setup resumes, and a
second Pet Skill remains possible when its runtime resources/fire condition
become ready.

Structured telemetry now includes skill-fire boss HP/ratio, known Sword,
current/required resources, `HP_PREP`/`SWORD_DENSITY`/`BOTH`/`VERY_LOW_HP`,
current-match success count, post-skill HP/ratio,
`ABSOLUTE_HP`/`RELATIVE_HP`/`BOTH`/`NONE`, `SETUP_BLOCKED`, finisher action, early prep Sword,
second-skill counts and immediate skill kills.

## Offline evidence

The final-policy focused tests cover:

- 45% HP + 5 Sword, 75% + 12 Sword, and 75% + 5 Sword fire behavior;
- resource-missing dominance and runtime effective costs;
- 50% HP-prep completion, very-low-HP fire and ordinary 3-Sword prep;
- revised strict 7/8 known-Sword boundary and UNKNOWN zero contribution;
- exact failed-B1 turn-13 fire plus derived 7-Sword distance-two setup behavior;
- Sword preservation and sparse-axis deterministic turnover;
- post-skill 25k absolute/both and 16% relative finishers;
- strict 30,000/20% boundaries and 60k/200k non-finisher behavior;
- no-first-skill and stale-previous-match Attack blocking;
- same-source-turn closure and later-turn Attack/Sword finishers;
- second Pet Skill availability above finisher range;
- no policy/history leakage into default PlayStyles.

Final-policy tests are **31/31 PASS**; combined autonomous/final-policy focused
tests are **143/143 PASS**; full regression is **1,281/1,281 PASS**.
Compileall and global `git diff --check` pass. The randomized-input module is
**18/18 PASS** on each of five consecutive repeats. User-owned runtime
randomization in `win32_input.py` remains preserved.

## Fresh final-policy B1 — PASS

FarmRun `b0506f59f05b456abeb50413c7ea2810`, MatchId `M_a6efe54f`, completed
exactly 1/1 match as a STRONG WIN and returned to `BOSS_LOBBY` without another
entry. The controller ended `STOPPED` with `COMBAT_LIFECYCLE_ENDED` and cleared
the combat session.

The opening observed boss HP was `58,926 / 84,180`. No ordinary early Sword
preparation action was selected; all five pre-skill moves were resource
progress. On local turn 11, runtime resources were `218 Mana / 250 Rage`
against authoritative requirements `200 / 200`, boss HP was
`59,902 / 84,180` (`71.1594%`), and the authoritative board contained nine
known Sword. The policy fired HT7 immediately with `SWORD_DENSITY` under the
revised eight-Sword floor.

The skill completed `SUCCESS_PERFECT`: seven of seven directions were
authoritatively confirmed, one Space was sent inside the Perfect window, and
the skill killed the boss immediately. The run recorded one Pet Skill attempt,
one Perfect, one immediate kill, zero same-source-turn follow-up, zero EVOLVE,
zero ordinary Attack/CAST, zero PASS, 5/5 acknowledged SWAPs, and zero QTE or
technical safety violation. A post-skill finisher was therefore unnecessary.

## Fresh final-policy B2 — PASS

FarmRun `6c3be41f56b9450ebd4f8d69b5e3f9a8` completed exactly five attempts and
five accounted STRONG wins with five unique MatchIds: `M_c91e3aca`,
`M_a7b32037`, `M_4ba99db3`, `M_8337796d`, and `M_60571d6d`. There was no sixth
entry, loss, UNKNOWN result, technical abort/recovery/exit, safe stop, result
conflict, or accounting mismatch. Final lifecycle was `BOSS_LOBBY` with
`FARM_TARGET_COMPLETED`; every combat controller ended `STOPPED` and cleared
its session.

Each match used HT7 once. The five fire records were:

| Match | Turn | Boss HP | Mana/Rage | Required | Known Sword | Trigger |
|---|---:|---:|---:|---:|---:|---|
| `M_c91e3aca` | 11 | 60,389 / 84,180 | 237 / 225 | 200 / 200 | 11 | `SWORD_DENSITY` |
| `M_a7b32037` | 11 | 60,390 / 84,180 | 300 / 200 | 200 / 200 | 12 | `SWORD_DENSITY` |
| `M_4ba99db3` | 13 | 59,902 / 84,180 | 313 / 250 | 200 / 200 | 8 | `SWORD_DENSITY` |
| `M_8337796d` | 15 | 60,715 / 84,180 | 270 / 250 | 200 / 200 | 11 | `SWORD_DENSITY` |
| `M_60571d6d` | 11 | 46,763 / 84,180 | 275 / 250 | 200 / 200 | 8 | `SWORD_DENSITY` |

All five skills completed `SUCCESS_PERFECT`, with 35/35 authoritatively
confirmed directions, five card clicks and five Space presses. Wrong, skipped,
duplicate, stale, unconfirmed and blind-retry direction counts were zero. All
five skills killed immediately, so one-hit rate was 5/5 and no post-skill
finisher or second skill was needed.

The run recorded no early HP-prep Sword action, no additional HP-prep Sword
after the threshold, zero EVOLVE, zero ordinary Attack/CAST, zero PASS, zero
same-source-turn follow-up, and 28/28 acknowledged SWAPs. FarmRunner and
controller safety telemetry were entirely zero; provider read/DTO/stale errors
were also zero.

## Fresh default B3 — PASS

FarmRun `b48e5b5a729b43b7b2d18547a643dd94`, MatchId `M_9e2fca01`, used the exact
default profile `SIMPLE / BASIC / NORMAL / NORMAL / DEFAULT_ATTACK` and
completed exactly 1/1 as a STRONG WIN. It returned to `BOSS_LOBBY`, stopped the
combat controller, cleared the session and did not enter another match.

Live branch coverage was ordinary default policy only: `SWORD=5`, `RAGE=3`,
`MANA=1`, and `SAFE_RESOURCE_FALLBACK=2`. Pet Skill proposals/attempts were
zero, all `SKILL_RUSH_*` counters were zero, and no post-skill finisher state
appeared. The run also recorded zero PASS, CAST, EVOLVE, wrong-turn, stale,
duplicate, postmatch, lobby or after-combat input. Ten of eleven SWAPs received
ordinary ACK; the final SWAP killed the boss and was closed by the authoritative
combat lifecycle, with no reject or lost action. Offline default regressions
retain coverage of EVOLVE and ordinary Attack branches that were not naturally
reached in this one live match.

## Fresh B1 attempt excluded — integration guard repaired

FarmRun `ba353e09c60c407abb485ae9086496ac` stopped during turn 7 before a
fourth input. The authoritative board was complete and current (`srvSeq=14`),
the turn had 13 seconds left, and analysis found eight legal moves. The final
policy selected `(2,2)->(2,3)` under `SKILL_RUSH_RESOURCE_PROGRESS` for known
Mana progress, with 10 known Sword. No provider/read, wrong-turn, stale,
duplicate or ACK failure occurred; all three earlier SWAPs were acknowledged.

The stop was an integration defect: the generic SIMPLE/CAREFUL
`safeMoveCount=0` guard overrode the final SKILL_RUSH rule that treats
direct/indirect Sword reply as allowed strategic risk. The guard now exempts
only explicit SKILL_RUSH SWAP branches with a concrete selected move. Other
PlayStyles and unrelated branches retain the original fail-closed behavior.
A dedicated regression covers all five authorized SKILL_RUSH SWAP branches
plus negative SIMPLE/unrelated cases. This run is not B1 acceptance; retry B1
from a newly started tool process.

## Fresh B1 retry excluded — setup policy repaired

FarmRun `c722ad0f4f5141839eb697d4f555d860` was stopped manually after 14/14
acknowledged SWAPs because setup had become excessively long. There were no
provider, ACK, wrong-turn, stale or duplicate-input failures. Runtime costs were
the expected 200 Mana / 200 Rage.

The trace proved two policy defects. At turn 13, resources were ready and the
board had eight known Sword. The old sparse-axis rank selected a direct clear
with one cell adjacent to Sword even though three legal direct clears were at
least two orthogonal cells away. The same class recurred at turn 23. At turn
27, resources were ready at 215/250 and the board had exactly ten known Sword,
but the old 11-Sword floor selected another setup SWAP. The next local board
was still waiting for stability when the operator pressed F9, so no unrecorded
policy decision is inferred.

The repaired policy uses the distance-two direct-clear pool during ready setup
below eight Sword and changes the practical fire floor to eight known Sword.
The exact turn-13 board now selects Pet Skill immediately with
`SWORD_DENSITY`; a derived seven-Sword form of that board chooses an isolated
clear with zero adjacent cells. Turn 27 also selects Pet Skill. This run is
diagnostic only and fresh B1 remains required.

## Historical live evidence retained

- superseded B1: FarmRun `efc0570ae51a47c0ad19cf17afd9fe0c`, 1/1 STRONG WIN,
  1/1 Pet Skill PERFECT, zero EVOLVE/CAST/PASS and zero technical violations;
- superseded B2: FarmRun `39b33a81f5bd46269afc2eec0aaa9126`, 5/5 STRONG WIN,
  7/7 Pet Skill PERFECT, zero EVOLVE/CAST/PASS and zero technical violations;
- retained default B3: FarmRun `fc0a4f27662c4772b021687d5bcbb49a`, 1/1 STRONG
  WIN, `SWORD=5`, `EVOLVE=1`, `RAGE=2`, `MANA=2`, no Pet Skill or
  `SKILL_RUSH_*`, final `BOSS_LOBBY`.

These runs are historical only; fresh final-policy B1/B2 are recorded above.
Follow
[phase3c3_runbook.md](phase3c3_runbook.md).

## Final verification

- focused autonomous/final-policy tests: **143/143 PASS**;
- final-policy tests within that group: **31/31 PASS**;
- complete regression: **1,281/1,281 PASS**;
- randomized input regression: **18/18 PASS**, five consecutive repeats;
- `compileall`: PASS;
- `git diff --check`: PASS before the final commit;
- live B1/B2/B3: PASS with zero technical safety violations.

Phase 3C.3 is complete. Phase 3D.1, benchmark, 25-match soak, packaging and
tagging were not started by this revision.

Stop after Phase 3C.3. Do not begin a new Phase 3D.1 comparison in this work.
