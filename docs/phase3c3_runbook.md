# Phase 3C.3 Final Revision — Live Acceptance Runbook

Status: **COMPLETE / PASS STRONG**. Offline verification and fresh operator-run
B1/B2/B3 are accepted on source `v1.0.48`.

The operator controls the Desktop UI and game. Do not assist combat manually.
Freeze these values for B1 and B2:

- HP preparation: boss ratio `< 50%`;
- lower preparation margin: approximately 35%, not a target;
- approximate evolution-risk region: approximately 30%;
- Sword-density condition: at least 8 known Sword;
- post-skill absolute finisher: boss HP `< 30,000`;
- post-skill relative finisher: boss ratio `< 20%`.

## A — UI/config preflight

Open `run_tool.bat` and select:

- PlayStyle: `Chịu đấm ăn xôi`
- Intelligence: `basic`
- Pet của tôi: `Huyền thoại`
- Tiến hóa: `Không tiến hóa`
- Thẻ sát thương: `Thẻ skill của pet`
- Audition: `Audition V3 (2 hướng — mặc định)`
- Board input: `Two Click`

Save, close, reopen and verify the values persist without starting a run. Enter
the exact supported boss room. Do not start from the world-boss map.

## B1 — one final-policy match

**PASS (2026-09-17 ICT).** FarmRun
`b0506f59f05b456abeb50413c7ea2810`, MatchId `M_a6efe54f`, completed 1/1 as a
STRONG WIN. At skill fire the boss was `59,902 / 84,180`, resources were
`218 / 250` against `200 / 200`, and the board had nine known Sword. Fire
reason was `SWORD_DENSITY`; HT7 completed PERFECT and killed immediately.
EVOLVE/Attack/PASS, same-turn follow-up, QTE violations and technical safety
violations were all zero. Final lifecycle was `BOSS_LOBBY` and the combat
controller was `STOPPED`.

Close and reopen the tool before the retry so the process loads the repaired
SKILL_RUSH no-safe-move integration guard. The interrupted FarmRun
`ba353e09c60c407abb485ae9086496ac` is diagnostic evidence only.
The later setup-policy diagnostic run
`c722ad0f4f5141839eb697d4f555d860` is also excluded. Restart again so the
process loads the distance-two setup rule and revised 8-Sword fire floor.

Set Target matches to `1` and Max attempts high enough for one bounded result,
then press Start once.

Capture from the final log:

- starting boss HP;
- first ordinary 3-Sword preparation move, if any, and boss HP afterward;
- Mana/Rage and runtime requirements at skill fire;
- known Sword count and fire reason: `HP_PREP`, `SWORD_DENSITY`, `BOTH`, or
  `VERY_LOW_HP`; `SETUP_BLOCKED` is valid only when no legal distance-two setup
  clear exists;
- Pet Skill result and whether it killed immediately;
- for a survivor: fresh residual HP/ratio, finisher trigger
  `ABSOLUTE_HP`/`RELATIVE_HP`/`BOTH`/`NONE`, and the next local-turn action.

Acceptance:

- exactly 1 completed/accounted match and no extra entry;
- every accepted Pet Skill is `SUCCESS_PERFECT`;
- EVOLVE is 0;
- ordinary Attack before the first successful Pet Skill is 0;
- no additional intentional HP-prep Sword action after boss HP is below 50%,
  unless another recorded policy reason independently selected it;
- no stale, wrong-turn, duplicate, post-stop or same-source-turn follow-up;
- final `BOSS_LOBBY`, controller `STOPPED`.

If the first skill leaves the boss alive below either strict finisher threshold,
ordinary Attack or Sword is valid only on a later local turn. A survivor above
both thresholds must return to normal setup; a second Pet Skill remains valid.

## B2 — five final-policy matches

**PASS (2026-09-17 ICT).** FarmRun
`6c3be41f56b9450ebd4f8d69b5e3f9a8` completed exactly 5/5 as STRONG wins with
no extra entry. HT7 was PERFECT 5/5 (35/35 confirmed directions) and killed
immediately 5/5. Fire counts were `SWORD_DENSITY=5`, with 8–12 known Sword;
all runtime resources met the authoritative `200 / 200` costs. The run had
28/28 acknowledged SWAPs and zero EVOLVE, Attack/CAST, PASS, same-turn
follow-up, QTE violation, technical failure, or safety violation. Final
lifecycle was `BOSS_LOBBY`; all combat controllers were `STOPPED`.

B1 is clean. Set Target matches to `5`, keep the same frozen
profile/thresholds, set Max attempts to `8`, and provide no manual combat input.

Acceptance:

- exactly 5 completed/accounted matches with no sixth entry;
- every accepted Pet Skill is PERFECT;
- EVOLVE is 0;
- illegal ordinary Attack before first skill is 0;
- ordinary Attack outside a proven post-skill low-HP finisher is 0;
- QTE critical and technical gameplay violations are 0;
- no action follows Pet Skill success in the same source turn;
- final `BOSS_LOBBY`, controller `STOPPED`.

Record per skill: boss ratio, known Sword, current/required Mana/Rage, fire
reason and immediate kill. Also record early 3-Sword prep, boss crossing below
50%, unnecessary later HP-prep Sword actions, post-skill survivors, finisher
Attack/Sword, and second Pet Skill uses. One-hit rate is diagnostic rather than
a pass requirement. Do not tune thresholds during B2.

## B3 — fresh default regression if shared dispatch changed

**PASS (2026-09-17 ICT).** FarmRun
`b48e5b5a729b43b7b2d18547a643dd94`, MatchId `M_9e2fca01`, completed exactly
1/1 as a STRONG WIN on `SIMPLE / BASIC / NORMAL / NORMAL / DEFAULT_ATTACK`.
It used only default branches (`SWORD=5`, `RAGE=3`, `MANA=1`, safe fallback=2),
with zero Pet Skill, `SKILL_RUSH_*`, PASS, CAST or technical safety violation.
The final SWAP ended combat authoritatively; final lifecycle was `BOSS_LOBBY`
and controller status was `STOPPED`.

The retained historical default run is FarmRun
`fc0a4f27662c4772b021687d5bcbb49a`. Because the final revision adds
match-scoped skill history and an ordinary-Attack exception in shared dispatch,
run one fresh match with:

- PlayStyle `Đơn giản`
- `NORMAL / NORMAL / DEFAULT_ATTACK / BASIC`

Verify one accounted result, normal Sword-first/Evolution/Attack behavior, no
Pet Skill, no `SKILL_RUSH_*` branch, no finisher-rule leakage, final
`BOSS_LOBBY`, and controller `STOPPED`.

Stop after B3. Do not benchmark, run the 25-match soak, package, or tag.
