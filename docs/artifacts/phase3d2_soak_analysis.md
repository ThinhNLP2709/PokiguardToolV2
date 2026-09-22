# Phase 3D.2 soak analysis

- Result: **PASS STRONG**
- Source: `5b620987320b4132c33ab7d1acc269901e7431b3` / `v1.0.49`
- FarmRun: `cdc37e234ec54b8f9c54bc718b92c636`
- Profile: `skill_rush / BASIC / legendary / none / pet_skill / sword_count >= 10 / audition_v3 / two_click`
- Completed: **25/25** in **25 attempts**; W/L/U `25/0/0`
- Pet Skill: **25/25 PERFECT**, `25/25` immediate first-skill kills
- Directions: `175/175` confirmed; confirms `25`
- SWAP: `180/180` ACK; reject `0`
- PASS / EVOLVE / pre-skill Attack: `0 / 0 / 0`
- Technical abort / recovery / extra attempt: `0 / 0 / 0`

## Per-match audit

| # | MatchId | Result | SWAP ACK | Sword cell/effective | Mana/Rage | QTE | Directions | First-skill kill | Local turns |
|---:|---|---|---:|---:|---:|---|---:|---|---:|
| 1 | `M_7b9e58f3` | WIN | 10/10 | 8/11 | 491/250 | PERFECT | 7/7 | yes | 11 |
| 2 | `M_36e7b3ce` | WIN | 10/10 | 9/13 | 300/225 | PERFECT | 7/7 | yes | 12 |
| 3 | `M_b6e3812b` | WIN | 5/5 | 8/11 | 300/200 | PERFECT | 7/7 | yes | 6 |
| 4 | `M_b3370ae7` | WIN | 8/8 | 9/12 | 300/250 | PERFECT | 7/7 | yes | 9 |
| 5 | `M_3280d3c5` | WIN | 8/8 | 9/13 | 302/250 | PERFECT | 7/7 | yes | 9 |
| 6 | `M_d81cf076` | WIN | 7/7 | 9/11 | 483/230 | PERFECT | 7/7 | yes | 8 |
| 7 | `M_18cf3df6` | WIN | 8/8 | 11/16 | 280/250 | PERFECT | 7/7 | yes | 9 |
| 8 | `M_f96beb47` | WIN | 7/7 | 10/11 | 300/235 | PERFECT | 7/7 | yes | 8 |
| 9 | `M_07f6e556` | WIN | 6/6 | 9/12 | 240/250 | PERFECT | 7/7 | yes | 7 |
| 10 | `M_3c51d8a2` | WIN | 8/8 | 10/16 | 333/250 | PERFECT | 7/7 | yes | 9 |
| 11 | `M_e90bdea2` | WIN | 5/5 | 11/15 | 480/250 | PERFECT | 7/7 | yes | 6 |
| 12 | `M_aa913a3d` | WIN | 7/7 | 9/10 | 210/250 | PERFECT | 7/7 | yes | 8 |
| 13 | `M_c8101316` | WIN | 10/10 | 9/12 | 602/250 | PERFECT | 7/7 | yes | 11 |
| 14 | `M_3cfbb5ec` | WIN | 6/6 | 9/11 | 240/235 | PERFECT | 7/7 | yes | 7 |
| 15 | `M_b99f3c34` | WIN | 10/10 | 12/16 | 630/250 | PERFECT | 7/7 | yes | 11 |
| 16 | `M_461fda11` | WIN | 7/7 | 10/17 | 453/250 | PERFECT | 7/7 | yes | 8 |
| 17 | `M_b2351412` | WIN | 7/7 | 10/10 | 320/230 | PERFECT | 7/7 | yes | 8 |
| 18 | `M_958a7efa` | WIN | 7/7 | 11/18 | 300/230 | PERFECT | 7/7 | yes | 8 |
| 19 | `M_d4ba2616` | WIN | 6/6 | 10/11 | 336/225 | PERFECT | 7/7 | yes | 7 |
| 20 | `M_c23a55b4` | WIN | 8/8 | 11/18 | 360/250 | PERFECT | 7/7 | yes | 9 |
| 21 | `M_31a5b53a` | WIN | 4/4 | 10/10 | 210/210 | PERFECT | 7/7 | yes | 5 |
| 22 | `M_f115ffa1` | WIN | 5/5 | 10/10 | 420/210 | PERFECT | 7/7 | yes | 6 |
| 23 | `M_62034e1e` | WIN | 9/9 | 10/13 | 260/205 | PERFECT | 7/7 | yes | 10 |
| 24 | `M_420897a6` | WIN | 5/5 | 11/13 | 250/210 | PERFECT | 7/7 | yes | 6 |
| 25 | `M_e0ce541c` | WIN | 7/7 | 8/11 | 270/230 | PERFECT | 7/7 | yes | 8 |

## Safety and freshness

- All critical gameplay and QTE safety counters are zero.
- Every executable QTE and skill-card identity matched its current MatchId/session.
- One fail-closed preflight rejection occurred in match 16 with zero input; current card/QTE state was reacquired before the successful action.
- Runtime PERFECT: 25; GOOD: 0; BAD: 0. Server timing echo: `NOT_OBSERVED`; no server reject was observed.
- Natural technical recovery and the empty-room/general-hub re-entry route were `NOT_OBSERVED`.
- Final state: `BOSS_LOBBY`, controller/FarmRunner stopped, no attempt 26.

## Offline verification

- Focused: 694/694 PASS
- Random input: 18/18 PASS in 5/5 runs
- Full regression: 1366/1366 PASS
- Compileall: PASS
- `git diff --check`: PASS

Raw evidence: `D:\PokiguardToolV2\logs\farm_runs\cdc37e234ec54b8f9c54bc718b92c636`
