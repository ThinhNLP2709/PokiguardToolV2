# PokiguardToolV2 Current State

Canonical technical handoff as of **2026-09-22 (Asia/Saigon)**.

Read [AGENTS.md](../AGENTS.md) first. User-defined gameplay/product rules are
canonical in [DECISIONS.md](DECISIONS.md). This file contains current accepted
technical state; use linked phase reports for detailed evidence.

## Source-of-Truth Hierarchy

1. [AGENTS.md](../AGENTS.md) — agent, workspace, and safety rules.
2. [DECISIONS.md](DECISIONS.md) — gameplay/product decisions defined or
   approved by the user.
3. This file — latest accepted technical state.
4. Latest phase-specific reports — detailed acceptance evidence.
5. Logs, reference artifacts, and tests — raw/runtime evidence.
6. Old/superseded reports — historical evidence only.

When sources conflict, identify which is newer; do not silently merge them or
rewrite history. Technical implementation does not silently override a user
decision in `DECISIONS.md`.

## Project Status

| Item | Current state |
|---|---|
| Current accepted phase | **Phase 3D.2 25-match Pet-Skill reliability soak — PASS STRONG** |
| Active phase | **None; Phase 3D.2 is complete** |
| Phase 3 status | **The accepted v1.0.49 Skill Rush profile passed one continuous 25/25 soak; `Kiếm đủ / 10` remains multiplier-weighted known Sword value `>= 10`** |
| Current controller status | **No FarmRunner/PetSkill executor is running** |
| Current live automation | **FarmRun `cdc37e234ec54b8f9c54bc718b92c636` completed 25/25 WIN and stopped in Starburst 1289 BOSS_LOBBY** |

## Phase 3D.2 — PASS STRONG

The accepted Skill Rush profile completed one immutable 25-match reliability
soak on source `5b620987320b4132c33ab7d1acc269901e7431b3`, application
`v1.0.49`. FarmRun `cdc37e234ec54b8f9c54bc718b92c636` finished 25/25 WIN
in exactly 25 attempts, with zero UNKNOWN, technical abort, technical recovery
or extra attempt. Final stop reason was `FARM_TARGET_COMPLETED`; lifecycle was
`BOSS_LOBBY` and the controller/FarmRunner stopped.

The frozen profile was Starburst `1289`, `skill_rush / BASIC / LEGENDARY /
NONE / PET_SKILL`, `sword_count / 10` with inclusive multiplier-weighted
`>= 10`, Audition V3 and Two Click. It recorded 180/180 acknowledged SWAPs,
zero reject, PASS, EVOLVE, pre-skill Attack, forced/intentional pre-skill Sword
consumption or premature `SETUP_BLOCKED` fire.

All 25 accepted Pet Skills had current MatchId/session/card/QTE ownership,
runtime PERFECT, seven authoritatively confirmed directions and one Space.
The totals are 175/175 confirmed directions, 25 PERFECT, zero GOOD/BAD and
25 immediate first-skill kills. Every stale, duplicate, wrong-direction,
wrong-turn, boss-turn, misclick, partial-input and postmatch-input counter is
zero. Match 16 had one expected fail-closed card-capability preflight rejection
with zero input; it reread current state and then completed PERFECT.

Natural technical recovery and the new empty-room/general-hub re-entry path
were `NOT_OBSERVED`. Final verification is focused 694/694, randomized input
18/18 in five consecutive runs and full regression 1,366/1,366; compileall and
diff check pass. See [phase3d2_report.md](phase3d2_report.md),
[phase3d2_runbook.md](phase3d2_runbook.md),
[phase3d2_soak_analysis.json](artifacts/phase3d2_soak_analysis.json), and
[phase3d2_soak_analysis.md](artifacts/phase3d2_soak_analysis.md).

## Phase 3D.1-R1 — PASS STRONG

Source version `v1.0.49` exposes `Điều kiện ra skill` with stable generic keys
`pet_skill_fire_condition` and `pet_skill_fire_value`. Choices are `Đủ mana
skill`, `Kiếm đủ`, `Mana Đủ`, `Nộ đủ`, `Hút đủ`, and `Khiên đủ`. The first uses
authoritative current skill resources with no numeric value. The five board
conditions use inclusive multiplier-weighted known GemType value `>= value`,
where x1/x2/x3/x4 contribute 1/2/3/4; range `0..256`.
Actual runtime skill resources remain mandatory in every case. Default and old
Sword-only migration are `Kiếm đủ / 10`.

The condition row, Audition and its help are shown only for `PET_SKILL` and are
hidden with zero gameplay effect for `DEFAULT_ATTACK`. Preferences and
checkpoints preserve the exact condition/value; Start/Resume freezes it into
the active FarmRun. UNKNOWN cells contribute no favorable count.

Boss HP no longer authorizes a normal first skill at any HP value. There is no
active HP-preparation or early Sword-damage route. Before the first successful
skill, every selected SWAP must preserve all known Sword, regardless of current
Rage. Mana/Rage progress is first. Safe progress wins when available; if none
exists and player HP is above 30%, the policy still takes the best
Sword-preserving missing-resource move before Drain, Shield or turnover, even
when that move may leave Sword for the boss. At or below 30% HP, or when HP is
unknown, safe protection/survival may precede unsafe resource progress. PASS
remains the last option. A prohibited third PASS forces the
lowest-risk non-Sword action. If every move consumes Sword, the policy fails
closed with `SKILL_RUSH_ONLY_SWORD_MOVES`.

`skill_cost_ready` skips board setup. Every count-based setup preserves both
Sword and the selected condition GemType, favors Sword-safe direct clears at
Manhattan distance at least two, and may PASS only when no safe preserving move
exists. The accepted later-turn post-skill finisher now uses fresh boss HP
ratio `<=30%`; above 30% a second skill uses the same selected condition. Hard
actionability, lifecycle, timer, source-turn, QTE, dead-board and mandatory
gates are unchanged. SIMPLE/CAREFUL remain unchanged.

After the detailed three-stage correction, multiplier-weighted setup fix and
healthy-player resource-priority fix, the Skill Rush suite is **63/63 PASS**,
the phase-focused suite is **94/94 PASS**, and full regression is
**1,354/1,354 PASS**. The user-owned randomized-input suite remains
**18/18 PASS** in five consecutive runs. The historical R1 block remains
accepted as five completed combats while preserving its raw four WIN + one
UNKNOWN accounting and explicit operator acceptance.

Refreshed Mode A FarmRun `fb3fddffb1f14442b31f92c473edc56e` passed 10/10 WIN
in 10 attempts with zero Pet Skill and zero active `SKILL_RUSH_*` branch.
Refreshed Mode B FarmRun `ee83bac8f35241c7a08afdff048632e2` passed 10/10 WIN
in 10 attempts with 10/10 PERFECT Pet Skills and 10/10 immediate first-skill
kills. It recorded 69/69 acknowledged SWAPs, zero PASS/EVOLVE/pre-skill Attack,
zero forced or intentional Sword consumption and zero critical safety
violation. Its first-skill effective Sword values were
`10, 10, 13, 10, 11, 12, 10, 14, 10, 16`; physical counts fell as low as seven,
proving multiplier-weighted inclusive readiness. Compared with refreshed Mode
A, Mode B reduced mean combat duration by 36.129%, mean full-cycle duration by
35.885% and mean primary actions by 41.045%.

Canonical inputs and generated results are
[phase3d1_r1_manifest.json](artifacts/phase3d1_r1_manifest.json),
[phase3d1_r1_analysis.json](artifacts/phase3d1_r1_analysis.json), and
[phase3d1_r1_analysis.md](artifacts/phase3d1_r1_analysis.md). See
[phase3d1_r1_report.md](phase3d1_r1_report.md) and
[phase3d1_r1_runbook.md](phase3d1_r1_runbook.md).

The first refreshed Mode B attempt
`26fbc39c62ca469e89c779ee5d2e7f2b` is rejected: the user stopped it during its
first match, so it contributes `0/10`. Its trace contains the policy regression
used for remediation: setup turns 13/15 selected `safe=false` distance-two
moves with 3/2 deterministic boss Sword replies despite safe legal candidates.
The new exact-board regressions require safe selection in those states and also
  cover Mana/Rage > Drain > Shield ordering inside the safe pool. The accepted
  final Mode B block above supersedes this stopped sample for validation.

Smoke FarmRun `b9a40538eda54da595b0d4b76fae1f41` completed 1/1 WIN with
17 local turns, zero PASS and one `SUCCESS_PERFECT` Pet Skill. The old running
process saw exactly ten known Sword on local turn 13 and did not fire because
it still used `> 10`; it fired later at 11 and killed the boss. That same turn
had zero safe moves and exposed a separate pool bug. The current policy
supersedes every earlier forced-Sword fallback: exact-board tests now require
an immediate Pet Skill at ten when resources are ready and never permit a
pre-skill SWAP that consumes known Sword.

The latest diagnostic FarmRun `e4dbca0f44ea46cca5afac3984766dda` was visibly
won but the controller ended `SAFE_STOP / COMBAT_TERMINAL_UNPROVEN`, so it counts
as `0/10`. It logged zero formal PASS. The skill was proposed immediately on
local turn 29, the first state with both runtime resources and exactly ten known
Sword. Earlier turns 13 and 17 consumed respectively three and four known Sword,
delaying that fire state. With player HP above 30%, exact turn-13 and turn-17
regressions now prove a non-Sword Mana/Rage-priority move before PASS. Separate
fixtures prove low-HP Shield/Health priority, PASS as the last resort and the
mandatory non-Sword action when a third PASS is forbidden. The Desktop tool is
closed; the game process remains open for the next operator-run live test.

FarmRun `03ceea93d6254ed1a4f4dac54562e85a` completed 1/1 WIN but used 9
energy instead of the expected 8. At local turn 15, runtime resources were
`270/250` against cost `200/200`, the Pet Skill was actionable, and the board
had 9 physical Sword cells worth 12 effective Sword because of x3/x2. The old
cell-count comparison read 9 and selected Shield; it fired at turn 17 only
after reaching 10 cells worth 16 effective Sword. Current source compares the
effective value, records physical/effective counts separately, and contains the
exact turn-15 board as a regression requiring immediate `PET_SKILL`. A fresh
one-match smoke was required because the completed run used the old code.

That corrected smoke is now **PASS**. FarmRun
`b55706d7afd54b48a2fc9ec3167b92e4` completed 1/1 WIN using 6 energy, with
zero PASS and zero pre-skill Sword consumption. On local turn 11 the runtime
skill cost was ready at Mana/Rage `270/210` versus `200/200`; telemetry recorded
9 physical Sword cells and 12 effective Sword, so `Kiếm đủ / 10` selected
`PET_SKILL` immediately. Audition V3 returned `SUCCESS_PERFECT` and the skill
killed the boss at 59,414/84,180 HP. The one abandoned Pet Skill preflight sent
zero Windows input, requested fresh state and retried successfully on the same
  source turn. This smoke validates the multiplier correction and remains
  separate from the accepted continuous refreshed Mode B10 benchmark block.

The following Mode B10 attempt, FarmRun
`420227ce72734e28a0fa4a89e0827f7f`, was stopped after two completed wins; its
third attempt exposed a resource-order defect. At local turn 15 the player had
75.2% HP and Mana/Rage `90/250`. A Sword-preserving Mana x3 move existed but
carried refill Sword risk, while a safe Shield move also existed. The old
safe-pool ordering chose Shield. Current source now selects the Mana move first
while HP is above 30%, still requires `knownSwordConsumed=0`, and leaves the
safe Shield/survival preference intact for low or unknown HP. The exact turn-15
board is an offline regression. This stopped run is not part of the accepted
Mode B10 block.

The corrected resource-priority smoke is now **PASS**. FarmRun
`ae7bca6157f242689e4ad863c52416b5` completed 1/1 WIN using 7 energy, zero
PASS, zero pre-skill Sword consumption and one Perfect immediate skill kill.
It exercised the revised branch on local turn 7: HP was 61.1%, no safe
Mana/Rage progress existed, and the only missing-resource move was an unsafe
Rage x3 clear leaving three direct boss Sword replies. Policy selected that
Rage move before protection, recorded `SKILL_RUSH_RESOURCE_RISK_ACCEPTED`, and
kept `knownSwordConsumed=0`. Resources became ready, setup stayed Sword-safe,
  and the skill fired on turn 13 at 10 physical / 15 effective Sword. This
  one-match proof is supplemented by the accepted continuous Mode B10 block
  summarized above.

## Phase 3C.3 Final Revision — PASS STRONG (historical policy foundation)

The details in this section describe the accepted `v1.0.48` policy and its live
evidence. Phase 3D.1-R1 above supersedes its eight-Sword and `SETUP_BLOCKED`
fire rules for the current source; the historical records remain unchanged for
traceability.

Source candidate `v1.0.48` adds the optional `skill_rush` PlayStyle displayed as
`Chịu đấm ăn xôi`. It is not the default and FarmRunner gates it to exactly
`LEGENDARY / NONE / PET_SKILL / BASIC` with the supported HT7 automatic-board-
effect family.

The canonical final policy no longer fires merely because resources are ready.
One ordinary early 3-Sword clear may prepare boss HP; boss ratio below 50%
completes that preparation. A ready/actionable HT7 skill fires when boss ratio
is below 50% or the authoritative board contains at least 8 known Sword.
Approximately 35% remains a lower preparation margin rather than a target, and
the approximately 30% evolution danger is not claimed as an exact reverse-
proven trigger.

While resources are missing, current runtime Mana/Rage deficits stay primary.
Equivalent moves preserve known Sword. With resources ready but neither fire
condition met, deterministic setup first uses direct non-Sword clears at
Manhattan distance at least 2 from all known Sword, then ranks zero/low-Sword
axes. If no isolated legal clear exists and the skill CardUI is actionable, it
fires with `SETUP_BLOCKED`; the least-adjacent fallback is retained only for a
temporarily non-actionable CardUI. UNKNOWN refill receives no credit.
Direct/indirect boss Sword replies remain strategic risk only in this
PlayStyle. SIMPLE/CAREFUL behavior remains unchanged.

After a current-match `SUCCESS_PERFECT`, runtime closes that source turn and
stores success only under the exact `CombatSessionKey`. On a later local turn,
fresh boss HP `< 30,000` or ratio `< 20%` permits ordinary Attack/Sword as a
finisher. Above both strict thresholds ordinary Attack remains blocked and a
second skill may be prepared. The state is not checkpoint-serialized and
cannot leak to the next match.

The superseded immediate-skill B1/B2 runs
`efc0570ae51a47c0ad19cf17afd9fe0c` and
`39b33a81f5bd46269afc2eec0aaa9126` remain historical only. Historical default
B3 `fc0a4f27662c4772b021687d5bcbb49a` remains accepted evidence. A fresh
default B3 has now also passed. See
[phase3c3_report.md](phase3c3_report.md) and
[phase3c3_runbook.md](phase3c3_runbook.md).

Fresh B1 attempt `ba353e09c60c407abb485ae9086496ac` exposed one shared-guard
integration defect: turn 7 had a complete current board and eight legal moves,
but the generic `safeMoveCount=0` guard overrode an authorized
`SKILL_RUSH_RESOURCE_PROGRESS` Mana SWAP. The guard now exempts only the five
explicit SKILL_RUSH strategic SWAP branches; SIMPLE/CAREFUL and unrelated
branches retain the fail-closed rule. The interrupted run is excluded and a
new B1 is required from a restarted tool process.

The next B1 retry `c722ad0f4f5141839eb697d4f555d860` was manually stopped
after 14 acknowledged SWAPs. Exact live traces showed that the old setup rank
cleared next to Sword on turns 13 and 23 despite isolated alternatives, then
continued setup after resources were ready, including at eight Sword on turn
13 and ten Sword on turn 27. Distance-two setup filtering below the threshold
and the revised eight-Sword fire floor now repair both causes. The run remains
excluded and B1 must restart in a fresh process.

Fresh final-policy B1 FarmRun `b0506f59f05b456abeb50413c7ea2810`, MatchId
`M_a6efe54f`, is **PASS**: exactly 1/1 STRONG WIN, five acknowledged resource
SWAPs, then HT7 fired at `59,902 / 84,180` boss HP with `218 / 250` resources,
authoritative `200 / 200` requirements, and nine known Sword. Fire reason was
`SWORD_DENSITY`. The QTE was PERFECT with 7/7 confirmed directions and one
Space; the skill killed immediately. EVOLVE, ordinary Attack, PASS,
same-source-turn follow-up and all technical safety counters were zero. Final
lifecycle was `BOSS_LOBBY`; combat controller status was `STOPPED` and the
session was cleared.

Fresh final-policy B2 FarmRun `6c3be41f56b9450ebd4f8d69b5e3f9a8` is
**PASS**: exactly five attempts, five STRONG wins, five unique MatchIds and no
extra entry. HT7 fired five times under `SWORD_DENSITY` at 8–12 known Sword,
met current `200 / 200` resource requirements every time, completed PERFECT
5/5 with 35/35 confirmed directions, and killed immediately 5/5. The run had
28/28 acknowledged SWAPs and zero EVOLVE, ordinary Attack/CAST, PASS,
same-source-turn follow-up, QTE failure, technical failure or safety violation.
Final lifecycle was `BOSS_LOBBY`; every combat controller was `STOPPED` and
cleared its session.

Fresh default B3 FarmRun `b48e5b5a729b43b7b2d18547a643dd94`, MatchId
`M_9e2fca01`, is **PASS** on
`SIMPLE / BASIC / NORMAL / NORMAL / DEFAULT_ATTACK`: exactly 1/1 STRONG WIN,
default branches only (`SWORD=5`, `RAGE=3`, `MANA=1`, safe fallback=2), zero
Pet Skill, zero `SKILL_RUSH_*` leakage, zero PASS/CAST and zero technical safety
violation. The final SWAP killed the boss and combat closed authoritatively.
Final lifecycle was `BOSS_LOBBY`; controller status was `STOPPED`.

Final-policy verification is **31/31 PASS**, the combined autonomous/final-
policy group is **143/143 PASS**, and its acceptance discovery was
**1,281/1,281 PASS**. The user-owned input-randomization changes remain
present. Phase 3C.3 is complete and is the frozen gameplay foundation used by
Phase 3D.1.

## Phase 3D.1 — PASS STRONG

Phase 3D.1 compared the accepted default profile
`simple / BASIC / NORMAL / NORMAL / DEFAULT_ATTACK` with
`skill_rush / BASIC / LEGENDARY / NONE / PET_SKILL` on frozen source commit
`44fea0cc3e89d670dc273a5fae7c5cf94e8809b0`, Desktop UI/FarmRunner, Starburst
`1289`, Two Click input and finite 10-match targets. Mode A FarmRun
`2876f169879548f790b3920e6894e491` and Mode B FarmRun
`e8a38744abbb4120b190118063c9a4dd` each completed 10 wins in 10 attempts with
zero UNKNOWN, technical abort/recovery or critical safety violation.

Mode B reduced mean combat duration from 223.822 to 127.056 seconds (43.233%)
and median combat from 217.256 to 125.677 seconds (42.153%). Mean full-cycle
duration fell from 235.905 to 136.189 seconds (42.270%) and median cycle from
228.820 to 134.346 seconds (41.287%). Mean SWAP fell from 13.3 to 7.9
(40.602%); mean major gameplay actions fell from 16.6 to 8.9 (46.386%).

Mode A invoked no Pet Skill and leaked no `SKILL_RUSH_*` branch. Mode B invoked
no EVOLVE or ordinary Attack, used exactly one Pet Skill per match, and all ten
skills were PERFECT with 70/70 directions confirmed and ten valid Space
presses. Every first skill killed immediately; no finisher or second skill was
needed. Fire reasons were HP_PREP=1, SWORD_DENSITY=7, BOTH=1,
SETUP_BLOCKED=1 and VERY_LOW_HP=0.

The final match's `SETUP_BLOCKED` fire was valid under the accepted Phase 3C.3
policy: boss HP was 69,276/84,180, four known Sword and resources 270/250, but
there was no legal direct setup clear at distance at least two from every known
Sword. This is a measured strategic limitation because one-hit success at high
HP/low Sword can depend on damage variance; it is not a technical violation and
was not retuned during the benchmark.

Energy saving remains `NOT_MEASURED`; fewer turns/actions do not prove a
game-owned energy delta. The result compares complete profiles with different
pets/loadouts and natural board RNG on one boss, so it does not isolate the
skill card or establish statistical significance. There are no exclusions.
Focused verification is **245/245 PASS**, full discovery is **1,286/1,286
PASS**, analyzer replay is A=10/B=10, and compileall/diff checks pass.
See
[phase3d1_report.md](phase3d1_report.md),
[phase3d1_runbook.md](phase3d1_runbook.md), and the compact artifact
[`phase3d1_matches.json`](artifacts/phase3d1_matches.json). Phase 3D.2's
25-match soak has not started.

## Phase 3C.2 — PASS STRONG

The normal Desktop path now accepts the exact
`LEGENDARY / NONE / PET_SKILL / BASIC` profile and freezes it through one
controller and one FarmRunner into the Phase 3C.1 Pet Skill policy/action.
Audition V3 remains the default; V2 remains an optional four-direction mode.
Unsupported, evolved, Mega and ambiguous multi-source profiles stay blocked.
The default `NORMAL / NORMAL / DEFAULT_ATTACK / BASIC` profile also remains
fully runnable and does not dispatch PetSkillAction.

User-operated live acceptance passed all B1-B6 gates. The primary run
`feff9bffa0794632a655cc9dc6bc7b6b` completed exactly 5/5 wins with no sixth
attempt. Four naturally actionable Pet Skills were all runtime Perfect, using
28/28 confirmed directions and four in-window Space presses. EVOLVE, ordinary
Attack, PASS and all QTE/gameplay safety violations were zero. The fifth boss
died before the Pet Skill became actionable. Final state was proven
`BOSS_LOBBY / controller STOPPED`.

Graceful-stop run `8c0b3a53985a4e6db04254de6562624b`
accepted one stop request during match one, completed that win and returned to
the boss lobby without entering match two. Default regression run
`15a10dc9bbf34626958b0f4ccec41ebd` completed 1/1 win under the exact default
profile with PetSkillAction zero. The final Desktop artifact
`logs/desktop_ui/20260915_172841/summary.json` records zero UI errors, zero
worker Tk writes, a stopped poller and clean UI process exit while the game
remained running.

The accepted 5-match run did not exercise detached-room re-entry. Per the
user's scope decision, any future recurrence belongs to a separate follow-up
scope. HT2 full live, non-terminal next-local after Pet Skill, recovery during
Pet Skill farming, other skill families, performance advantage and energy
saving remain `NOT_OBSERVED`. Source version is `1.0.47`; final verification is
**1236/1236** plus compileall and diff checks. See
[phase3c2_report.md](phase3c2_report.md) and
[phase3c2_runbook.md](phase3c2_runbook.md).

## Pokiguard 1.7.4-b4 — default-mode repair

The current single runtime profile now targets only the exact b4
`GameAssembly.dll` SHA-256
`D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`.
The former b3 hash and unknown builds fail before the memory provider is
constructed because this source tree uses one layout profile at a time.

All b4 TypeInfo RVAs are implemented for Board/Active, MatchService
turn/clock/ACK/desync state, opening-board transport, ChatMessageDTO, player
stats, ordinary cards, Fusion/evolution, PetUserDTO capability, boss-room
discovery, and combat lifecycle. Default managed offsets remain stable from
b3 except the Dot tail: `_squashing +0xFC`, `PoolTag +0x100`, and
`RenderHidden +0x131`. The b4 `Component.get_gameObject` cache is
`GameAssembly+0x355F678`; its resolved UnityPlayer function remains
`UnityPlayer+0x1067390`. All 15 native ownership/geometry signatures match the
installed UnityPlayer exactly. The managed/native unmarshal signature is now
at `GameAssembly+0x10971EF`.
Its b4-unique relative-call bytes are `BF E4 16 FF`; live memory and the
installed PE agree. The earlier carried-forward b3 displacement caused the
first b4 combat to reject native board discovery before any gameplay input.

The b4 default repair was accepted before Pet Skill work resumed. Phase 3C.1
now adds a separate exact V3 `LR` reader and retains V2 four-direction mode as
an explicit compatibility option. The two default BASIC profiles remain
authorized and their complete regression stays green.

Live match `M_91a4747a` proved the b4 native mapping: three complete
`Board.allDots` reads were accepted, 64 Dot objects were cached, native-board
rejections stayed zero, and evolution mana cost was 120. Entry missed the
short-lived MATCH_START, so it intentionally sent zero gameplay input and
stopped after the opening turn advanced. The decoder had three inherited
Newtonsoft offsets at `+0x58`; b4 declarations put `JArray._values`,
`JObject._properties`, and `JProperty._content` at `+0x50`. Those offsets and
the synthetic test fixture are corrected. Boss entry now arms the existing
read-only 1 ms dispatcher sampler before Start and discovers only a strict
new-match MATCH_START, then binds it to the actual same-MatchId Board session.
No opening or gameplay acceptance invariant was relaxed.

Offline verification now passes **1212/1212** tests, `compileall`, and
`git diff --check`; the installed b4 hash is accepted by the exact gate. A
zero-input live attach resolved the b4 provider/lobby roots and
classified `LOBBY_OTHER` with no read errors. The inspector ended only because
the game was not in a Chinh Phuc room; counters are `entryClicks=0` and
`gameplayInputs=0`. Artifact:
`logs/b4_compatibility/20260914_lobby_inspect/entry.jsonl`.

The post-repair bounded run `a6d3f398cd0b4cb4bb009ead46d83601`
retained a complete 64-cell MATCH_START before Board construction, accepted it
on local turn 1 with sequence 0 and 14 seconds remaining, and immediately sent
a safe SWAP that the server acknowledged. It completed Fraxure match
`M_64611df6` as a strong 1/1 WIN and returned to `BOSS_LOBBY`: 15 SWAP sent,
14 normally acknowledged, final SWAP closed on terminal lifecycle, one failed
and one successful 120-mana evolution, 0 PASS, 0 technical abort/recovery, and
0 safety violation. Native mapping accepted 18/18 board reads with 0 rejection;
provider read, DTO, stale, ambiguous and sequence-desync errors were all zero.
Attack CardUI and its 160 cost resolved live, though this match did not meet the
configured CAST conditions before a Sword move killed the boss. b4 default
BASIC compatibility is accepted. See
[pokiguard_1.7.4_b4_compatibility_report.md](pokiguard_1.7.4_b4_compatibility_report.md).

## Phase 3C.1 — PASS STRONG

The first BASIC Pet Skill backend profile is narrowly
`LEGENDARY / NONE / PET_SKILL`. It uses a distinct turn-consuming
`PET_SKILL` policy action backed by the accepted Huyền Thoại 7 automatic-dot
QTE primitive. The policy never proposes EVOLVE or the ordinary Attack card
for this profile. A current-session capability, current runtime cost,
unambiguous supported family and live actionability are mandatory.

When the skill is not ready, Sword remains the highest board objective. The
next resource branch considers only Sword-safe deterministic Mana/Rage gains
toward the current deficits, ranks completed requirements before normalized
progress, and assigns no favorable credit to UNKNOWN refill. The established
Health, Drain, Shield, PASS and mandatory-action branches remain after this
resource branch.

FarmRunner now dispatches exactly one accepted Pet Skill primitive while
holding its existing gameplay capability. Physical card, direction and Space
inputs pass through that same authority. Zero-input rejection releases the
permit and requires a fresh state; any result after a card click closes the
source turn and prohibits fallback or blind retry. A successful runtime
Perfect waits for an authoritative boss turn, terminal state or later local
turn before gameplay can resume. No pending Pet Skill/QTE state is persisted
across matches or checkpoints.

Audition V3 now reads the separate b4 `AuditionStage` and
`AuditionChallenge`, requires exact server layout `LR`, and consumes the
game-built `Expected` list. Only Left/Right/Space are allowed. Audition V2 is
retained as the `audition_v2` four-direction option. The selected mode flows
through Preferences, Desktop Start/Resume, FarmRunner and the embedded action.

Source version is `1.0.46`. Full verification is **1222/1222**, the dedicated
V3 tests are **7/7**, and `compileall`/`git diff --check` pass. Live B1 reached
the Huyền Thoại 7 card in run `f740e9c51fb845d7a9fe2c8ea1de5a6b`; the card
was clicked once, but zero direction/Space inputs were emitted because the
reader incorrectly rejected the native `ServerQteReverseFrom = -1` no-reverse
sentinel. Native b4 disassembly and read-only runtime memory agree on `-1`; the
reader now accepts exactly that sentinel and retains fail-closed rejection for
other invalid negatives.

The next run `7f8cf5fc45484cb394017fa5900a49a1` proved that repair and exposed a
second distinct native sentinel: `CardUI._auditionV3ElapsedMs` is exactly `-1`
until Space is tapped. The former scalar gate rejected it before sending the
first direction. Native constructor, QTE-start, live-clock and tap callback
code all prove this lifecycle. The reader now accepts exact `-1` only before
tap and requires bounded host/stage equality after tap. A clean live retry
remains pending. See
[phase3c1_report.md](phase3c1_report.md) and
[phase3c1_runbook.md](phase3c1_runbook.md).

Run `17e9a8761c6e477ca8fee7436d4b2924` then confirmed the complete direction
path: seven of seven Left/Right inputs were authoritatively acknowledged with
zero wrong, skipped or duplicate directions. The action finished directions at
QTE elapsed `1.217 s` and waited for `3.150 s` inside the Perfect window. At
`3.054240 s`, the reader incorrectly rejected the coherent pre-tap tuple
`Tapped=false`, `_wasPerfect=true`, `_grade=null` and therefore sent no Space.
Native `TickBar` proves `_wasPerfect` is the current in-zone highlight, while
`ShowResult` writes `_grade` after grading. The false relationship is removed
and the next live retry proved it.

Run `b77eb786333345418e379777bf78cddd`, match `M_79773863`, clicked the skill
card once, confirmed the full seven-direction V3 sequence, pressed Space once
at `3.185 s` inside the Perfect window and received authoritative runtime
`PERFECT`. The skill killed Starburst immediately. The controller captured a
strong terminal WIN before cleanup: boss HP `0`, local HP `38134`, UI text
`Thắng`, and all safety counters zero. This accepts the V3 action itself.

The run stopped at the result screen because FarmRunner's combat-summary
adapter did not list the Phase 3C.1 success label `FULL_COMBAT_COMPLETED`.
It accepted only the historical `FULL_MATCH_PASS`/`B5_PASS_STRONG` labels and
therefore rejected a valid controller summary before result confirmation. The
adapter now accepts the exact safe classification while preserving terminal,
session, pending-action, postmatch and safety gates; the safety-finding variant
remains rejected. Replaying the captured log now routes to
`POSTMATCH_RESULT_UI_REQUIRED`. Corrected FarmRun
`6bcf4d8efa9a4e129cc32aa492a17b6a`, MatchId `M_8ba50c47`, then passed B1 end
to end: `1/1 WIN`, ten SWAPs all acknowledged, one Pet Skill runtime Perfect,
zero EVOLVE/ordinary CAST/PASS, one result confirmation, consistent memory/UI
WIN, final exact Starburst `BOSS_LOBBY`, and all safety counters zero. See
[phase3c1_full_combat_classification_incident.md](phase3c1_full_combat_classification_incident.md).

One direct B2 launch timed out before entry because the game window was never
foreground. It sent zero entry/gameplay inputs and produced no match attempt;
it is not B2 evidence.

Fresh B2 FarmRun `360e3ef223fc4f5eba5ca93d1cd2d490`, MatchId `M_031645fd`,
then completed `1/1 WIN`. It used a new Board/session and QTE generation,
performed six acknowledged SWAPs, logged three Sword-safe Rage-progress choices
against current deficits, and proposed HT7 at turn 13 with Mana/Rage `210/230`
against runtime cost `200/200`. Its fresh seven-direction sequence was fully
confirmed, Space was sent once at `3.168 s`, and runtime result was `PERFECT`.
The skill killed the boss; memory/UI WIN agreed, the result was confirmed once,
and FarmRunner returned to exact `BOSS_LOBBY` with all safety counters zero.

Accepted B1+B2 total two fresh completed MatchIds, two Pet Skill successes, two
Perfects, `16/16` acknowledged SWAPs, zero EVOLVE, zero ordinary CAST, zero
PASS, zero stale/duplicate/wrong QTE or gameplay input, zero same-source-turn
follow-up and consistent `2/2 WIN` accounting. Both skills killed the boss, so
next-local continuation is `NOT_OBSERVED`; Phase 3C.0 already proves the Legend
latch boundary. Phase 3C.1 is PASS STRONG. The next safe scope is Phase 3C.2;
no 3C.2 work has started.

## Phase 3C.0 — PASS STRONG

Read [phase3c0_report.md](phase3c0_report.md) and
[phase3c0_runbook.md](phase3c0_runbook.md). The audit executed exactly one
already-accepted Pet Skill and then performed read-only observation through the
next local turn. It separated `Board.isUsingLegendCard +0x391` from the three
other known modal flags. A current session, local actor, source turn,
inactive-QTE edge and fresh post-Perfect full board remained mandatory.

B1a and retry 1 each produced a valid Huyền Thoại 7 runtime Perfect with 7/7
confirmed directions and one Space. The skill killed Starburst from 49,620 HP
and then from 69,276 HP. Both sessions ended before a fresh same-turn board, so
those samples were inconclusive and sent zero post-Perfect input.
`isUsingLegendCard` was already false in both exact control samples at Perfect.
Retry 2 used the higher-HP boss and produced another valid Perfect: one click,
7/7 directions and one Space at 3.154079 s. The boss still had
248,555/509,272 HP at the last exact QTE sample, proving that the audit's
ownership failure 0.246 s later was not evidence of a kill. The audit had
called the full provider before retaining the exact post-Perfect control owner;
the animation's temporary `Board`/`Active` gap invalidated the lifecycle epoch.
Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry2_high_hp_boss.jsonl`.

The corrected route now checks the exact control owner first, retains temporary
post-Perfect gaps within the bounded wait without polling a full board, and
allows a full provider publication only after that owner returns. It emits no
post-Perfect input. Retry 3 timed out in the lobby after 30 minutes with no
match, action or input.

Retry 4 produced a valid Huyền Thoại 7 Perfect at source turn 23: one click,
7/7 confirmed directions and one Space at 3.152554 s. The corrected route kept
the same lifecycle and observed a proven-null QTE edge. Runtime advanced to
boss turn 24 only 1.216 s after Perfect; the first stable board still had
`isUsingLegendCard=true` while the three other known modal flags were false.
This proves the skill ends the source turn. The audit was extended through the
boss turn to classify the next fresh local turn, with a 60-second bound.
There is currently no harness running. Artifacts:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry3_transient_fix.jsonl`.
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry4_transient_fix.jsonl`.
Retry artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry1.jsonl`.

Retry 5 closed the audit in match `M_d5a467a1`. It produced a runtime Perfect
with one click, 7/7 confirmed directions and one Space at 3.152790 seconds.
The next settled local turn 19 still had `isUsingLegendCard=true`, while
`isUsingMega=false`, both Mega panels were closed and every other gate passed.
The former aggregate returned `MODAL_OPEN`; removing only the Legend contributor
returned `PASS`. No post-Perfect gameplay input was emitted.

Production `board_modal_open` now excludes this proven durable Legend latch and
continues to include Mega execution and both Mega panels. Exact Legend telemetry
and every presentation/cascade/clock/turn/lifecycle check remain intact.
Correction-focused tests are **103/103 PASS** and full regression is
**1189/1189 PASS**; compileall and diff check pass. No FarmRunner Pet Skill
integration, push, package or version bump was made. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry5_next_local_turn.jsonl`.

The user accepted this evidence and authorized the phase commit on 2026-09-12.
Phase 3C.0 is closed at **PASS STRONG**. Phase 3C.1 requires a new scope; it has
not been started automatically.

## Phase 2 b2 compatibility repair — live retest accepted

FarmRun `cddb3de3caef45dd8042d07cc28aab62` completed five attempts as five
strong, consistent wins and returned to `BOSS_LOBBY`. It recorded 50 SWAPs,
five CASTs, six evolution attempts, one policy PASS, no technical recovery,
no safe stop and consistent result/attempt accounting. The user accepted this
5/5 run as stable default behavior and authorized the next phase.

## Historical Phase 2 b2 compatibility repair investigation

The relevant immutable runs include
`logs/farm_runs/e354ad0b878f4959838b3e07c4fbdcf0`,
`logs/farm_runs/2b7ce245380c45848285ad087ef86ea7` and
`logs/farm_runs/bef23282eac3461bb6ca629e36f63537`. The latest diagnostic
runs are `logs/farm_runs/ab7e9331f5774a48b2da8549e2f7e77a` and
`logs/farm_runs/c756bbc90fc64366802c7df3ade5f4ba`.

Findings:

- Evolution is already runtime-driven at 120 Mana. The earlier run proposed it
  at player Mana 154, sent cost 120, and received exact
  `MATCH_FUSION_RES success=false`. The latest run had Mana 114 at the relevant
  turns, below 120, so not evolving there was correct.
- On the reported sequence-40/45 board, `(5,0)<->(5,1)` is a legal Mana x3
  move with zero direct, indirect and UNKNOWN Sword reply. The former support
  overlap veto (`collapse_support_hazard=2`) incorrectly removed it. Support
  overlap now contributes only to risk ranking, and an exact replay regression
  requires BASIC Step 3 Mana SWAP instead of PASS.
- The last run recorded only two formal PASS actions. On the next local turn,
  ACK advanced to 50 while the latest published board remained sequence 47;
  controller expiry sent no input and the server counted the effective third
  idle. The dispatcher now falls back from rejected raw JSON board shape to the
  same callback's DTO payload. The subsequent diagnostic run below proves that
  escalating this gap recovery to a full heap scan was itself unsafe.
- Run `bef23282eac3461bb6ca629e36f63537` recorded 11 local turns, six sent and
  acknowledged SWAPs, **zero policy PASS actions** and a user F9 stop. The
  visible idle turns were technical board-publication gaps, not solver PASS:
  every unresolved ACK launched a 1.28--1.31 GiB scan lasting 7.02--7.18
  seconds. Eleven such scans starved the high-cadence dispatcher and repeatedly
  missed the following board callback. The lobby baseline had retained 197
  candidate regions / 169.75 MiB, so even the first learned-neighbour pass was
  too broad before it escalated process-wide.
- Active combat now forbids every full-heap transport scan, including opening
  preload, post-entry fallback and PASS wait. The dispatcher tap samples at a
  1 ms target interval and remains the primary source. One exact missing ACK
  may scan only a rotating window of lobby-learned regions capped at 64 MiB;
  an unchanged `(match, turn, ACK)` cannot repeat that work. Broad discovery
  remains confined to the pre-entry lobby boundary.
- The latest run proves the remaining Sword/evolution failure was still not a
  policy PASS. It observed six local turns but emitted only two
  `policy_decision` records and two acknowledged Rage swaps; the other four
  local turns never received a publishable board. The dispatcher made 44,956
  bounded direct-root polls (44,951 stable, five torn), yet retained only four
  move boards. It also repeated 1,247 decodes of five/six old DTO allocations
  whose legacy payload no longer contained `board/srvSeq`.
- Reverse b2 explains that exact pattern. `ChatService.OnWebSocketMessage`
  calls `MatchPayloadPreparser.ShouldPrepare/Prepare` before dispatcher enqueue;
  `PrepareBoard` moves the typed `BoardCellDTO[8][8]` into
  `ChatMessageDTO.preBoard +0x3C8` and sets `preBoardReady +0x3D0`. The old
  raw/`matchPayload` readers ignored this b2 owner. The tap now combines the
  same callback's class-checked, stable `preBoard` with immutable raw
  `matchId/type/matchPayload.srvSeq`, then still requires the exact
  `MatchService._ackedSeqs` value before publication. Failed legacy DTO
  allocations are retired after one retry instead of being decoded throughout
  the match.
- Run `c756bbc90fc64366802c7df3ade5f4ba` disproves the assumption that the
  `preBoard` fallback alone closes every gap. The tap made 29,179 polls (29,099
  stable), decoded boards only for boss responses at sequences 6 and 10, and
  never observed the sequence-14 callback. ACK reached 14 while the published
  board remained at 10. The user's 15:56:30 screenshot is that missing local
  turn and visibly contains Sword; no policy decision or formal PASS exists for
  it. The successful sequence-6/10 DTOs had non-null `preBoardReady=1`; sampled
  local response DTOs normally had `preBoard=0/preBoardReady=0`. Therefore the
  decoder was valid, but the required callback itself was absent from the
  sampled dispatcher roots.
- The 1 ms tap now also samples the two typed owners already declared by the b2
  reverse output: `MatchService.PendingCombat +0x1A8` and
  `BoardWsApplier._pendingBatches +0x60`. PendingCombat is accepted only across
  stable current MatchId/pointer reads. A queued batch additionally requires a
  provider-validated BoardWsApplier address, exact class/Board/bootstrapped
  MatchId, and identical queue address/version/content before and after its
  64-cell read. Retention alone gives no action authority: provider publication
  still requires the exact sequence in `MatchService._ackedSeqs` plus normal
  stability and presentation gates.
- The same run found a separate opening defect. At turn 1, BASIC repeatedly
  chose a safe Rage swap, but the final preflight emitted 51
  `ACTION_ABORTED_STATE_CHANGED` results with the same session, sequence and
  board hash, then the turn expired. The opening handoff allowed both `None`
  and `-1` as equivalent pristine LastMove sentinels but copied the latest raw
  representation into the fresh state, invalidating the otherwise identical
  action identity. The preflight now preserves the already proven cached
  pristine representation; a regression proves `None` versus `-1` cannot
  cancel the same opening action.
- Card and board acquisition remain separate. In the diagnostic run,
  `extended_card_ui_scans`, `card_owner_anchor_scans` and
  `fusion_owner_anchor_scans` were all zero. The opening turn used the lobby
  card expectation/cache; optional current UI discovery remained deferred
  until after the opening action. Card discovery did not cause the 7-second
  stalls.
- At game turn 21 the player had 367 Mana, but authoritative idle was already
  2/3. Existing Phase 2 safety therefore correctly required a turn-consuming
  SWAP/CAST; Evolution does not consume the turn and could not satisfy that
  reset. The absence of earlier evolution proposals came from missing
  publishable boards or insufficient Mana, rather than a retained 160 cost.
- The 15:02:48 screenshot is transcribed as a deterministic regression board.
  With the shown 135 Mana and current 120 cost, default Phase 2 selects
  `EVOLVE`. With Fusion already used, the same board selects Step 2 Sword,
  swapping screen `(0,1)<->(1,1)` for Sword-3. This proves BASIC does not PASS
  that board when it receives it; the live log proves it did not receive that
  board in the affected local turn.
- The 15:56:30 screenshot is also a deterministic regression board. With
  Fusion already used, BASIC selects Step 2 Sword and swaps screen
  `(0,4)<->(0,5)` to collect Sword-3. This further localizes the incident to
  board capture rather than policy ranking.
- Reverse b2 proves the new turn announcement gate: `Board.IsPlayerAllowedToMove`
  calls `TurnAnnouncer.IsBlockingInput`; TypeInfo RVA is `0x2DDAE68`, static
  `_blocking +0x80`, deadline `+0x84`. The provider reads the game-owned bool
  and blocks input while true instead of guessing a delay.

Focused regression for the repaired policy, capture, actionability and provider
paths passed at that checkpoint. Offline verification was **1160/1160 tests
PASS** with compileall and diff check passing. This historical pre-live status
is superseded by the accepted 5/5 Phase 2 run and Phase 3C.0 closeout above.

## Historical Phase 3A.2 implementation record

Read [phase3a2_report.md](phase3a2_report.md) and
[phase3a2_runbook.md](phase3a2_runbook.md) as historical implementation
evidence only. At that checkpoint the phase had not yet been accepted. Source
`v1.0.44` replaces the
operator-facing `ManaPriority` with typed Main Pet, Evolution target/mode and
Damage-card fields. Preferences v2 and checkpoint v2 persist the immutable
profile. v1 migrations map old EVOLUTION and ATTACK to the two exact BASIC
profiles without creating Pet Skill intent.

The capability model keeps zero, one or multiple skill sources explicitly.
Future `LEGENDARY/NONE/PET_SKILL` is valid and persistable, but Start/Resume is
blocked before FarmRunner. `LEGENDARY/LEGENDARY` remains ambiguous; no source
is selected. EVOLVED/MEGA choices stay visible and disabled. The current
runtime `PetSkillCapability` and Phase 3B.3 executor remain unchanged.

Offline: **377 focused / 1121 full tests PASS**, compileall PASS, diff check
PASS. Live B1 UI/migration and B2 zero-input gate passed. B3 used exactly one
attempt and confirmed existing BASIC MANA/SWORD branches with two normal SWAPs,
zero PetSkillAction and no extra attempt. The game then moved directly to the
main lobby before memory/UI proved a terminal result; FarmRunner correctly
stopped `COMBAT_TERMINAL_UNPROVEN`. Completed count stayed zero and final
lifecycle was `LOBBY_OTHER`, so this phase is PASS but not PASS STRONG.

At that checkpoint, `Board.isUsingLegendCard` reset semantics were **UNKNOWN**.
Phase 3C.0 above has now resolved that uncertainty and closed the bounded audit.

## Phase 3B.3 final closeout — 2026-09-10

Read [phase3b3_closeout.md](phase3b3_closeout.md) for the final acceptance,
scope changes, timing statistics, safety audit and Git receipt procedure.
B1 PASS, B2 3/3, B3 ten consecutive **scored** Perfects, B4 two current
Perfects in one retained match: all mandatory live milestones are complete.
HT2 full-auto remains optional NOT_OBSERVED, not a required retry.
Final offline audit: **282 focused / 1083 full tests PASS**, compileall PASS.

The final user-approved action boundary ends immediately on current-generation
runtime PERFECT after 7/7 RAM ACKs and one in-window Space. No callback capture
or post-effect board wait is required to accept that action. This is not proof
of server damage/rewards, nor authority to play the next board without its
normal fresh-actionability gate. Historical failures/exclusions remain visible.

The next phase at this historical point was **3A.2 — Pet Configuration +
Capability Model**; it is now recorded above. The
general board-policy use of `isUsingLegendCard` requires a separate lifetime
audit before continuous skill integration; the accepted B4 fix only changes
fast card rediscovery. No packaging, release tag or automatic farming added.

## Historical implementation and live audit trail

The dated entries below preserve prior observations and pending states. The
final closeout above supersedes their old status/retry instructions.

### v1.0.43 — fix B4 second-card discovery blocked by latched flag

**B4 retry 1 PASS:** user reported two Perfects, independently verified in
`logs/phase3b3_pet_skill_action_20260910_124435_b4_retry1_two_same_match_v1043.jsonl`,
`--b4-two-same-match --timeout 1800`, execution session 70040, replacement game
PID 23784. Both actions share MatchId `M_60410580`, epoch 1, Board
`0x0000021E58B7F540`, local actor 1 and HT7 CardUI. Observer generations 1 -> 2
have distinct server challenges and source turns 13 -> 21. Each has 7/7 RAM
ACKs, one card click and one in-window Space, current runtime PERFECT and zero
direction violations. Directions take 1.152945 / 1.150411 s; Space estimates
3.154792 / 3.167089 s in current [3.0, 3.299999952] windows. The same CardUI
and arrows-list object are safely reused with a new identity/current sequence.

Inactive edge after action 1 is logged at 13:13:42.110 ICT. A geometry-change
preflight before action 2 rejected/rearmed with zero input; it is not a third
action or retry of sent input. Final `B4_SUCCESS_TWO_CURRENT_PERFECT`, accepted
2/2, exit 0; observer stopped 27 ms after result 2, no remaining Python input
controller. The latched-flag fix is live validated. No further B3/B4 retry is
needed for these milestones; final phase/isolation audit and handoff remain.
No new controller, code change, commit, push or phase expansion in this review.

B4 v1.0.42 log below has first current PERFECT in MatchId `M_8718fdf8`, turn
39; ActionId `e0fc95bd6bb7419d86104df24d88f1e2`, 7/7 RAM ACKs in 1.234789 s,
one Space at 3.185688 s within [3.0, 3.299999952], zero direction violations.
The inactive edge appears 1.141 s later. At turn 43 resources are 360/250,
but `refresh_pet_skill_cards` returns no cards on `isUsingLegendCard=true`.
This persists across later turns, so B4 is **INCOMPLETE / discovery bug**, not
two accepted actions or insufficient resources. First accepted action remains.

Read-only b2 disassembly confirms `CardUI.SetLegendMultiplier` sets Board's
+0x391 flag true; the observed lifetime is not the current QTE lifetime.
v1.0.43 removes that fast-hand-discovery suppression only; exact current card,
inactive QTE, resource/turn/readiness and input timing protections are unchanged.
See `phase3b3_native_card_evidence.md` and `phase3b3_report.md`.

Execution session 16429 was interrupted during diagnosis (exit 1; no final
`observer_stopped` footer). Process inspection confirms Python PID 35544 is
gone; no input controller remains. Raw log is preserved, not rewritten.
Do not hot-restart in the user's ongoing combat; retry from the exact boss
lobby when the user is ready. B3's prior scored streak is unchanged.
Offline verification for v1.0.43: targeted **122 PASS**, full suite **1083 PASS**.

### v1.0.42 — B4 retained-session two-action validation (2026-09-10)

The user authorized testing two QTEs in the SAME combat. The new optional
`--b4-two-same-match` coordinator retains the observer/generation tracker but
creates a fresh one-action executor after the first current runtime PERFECT.
The existing direction/Space primitive and immediate-success contract are
unchanged. No response scan or post-effect wait is reintroduced for success.

Only action 2 waits for a fresh proven inactive-QTE edge, a later local turn,
fresh ready control flags, resources and current native card/geometry proofs.
Its QTE must have a higher observer generation and a different positive server
challenge in the exact same session. Repeated sequence/window VALUES are legal;
their ownership must be current. The coordinator stops at two successes, any
post-input failure, session/actor change, terminal state, timeout or operator
abort. A match ending after one success is incomplete B4, not two successes.
No automatic third action, consumable, board move, recovery or re-entry.

Control readiness fields are projected from values already read by
`poll_qte_control`; no new offsets, board scan or additional RPM scan is added.
See `phase3b3_runbook.md` for the operator protocol and `phase3b3_report.md`
for verification. B3's scored 10/10 evidence below remains unchanged.

Offline regression: **1080 PASS**, targeted B4/control **57 PASS**. User-authorized
live invocation started successfully from the lobby:
`logs/phase3b3_pet_skill_action_20260910_020559_b4_two_same_match_v1042.jsonl`,
`--b4-two-same-match --timeout 1800`, execution session 16429. The started line
confirms the two-action protocol. This invocation subsequently stopped after
the first success and second-card discovery blocker; see v1.0.43 above.

### v1.0.41 — complete the action at runtime PERFECT (2026-09-09)

Live **B3 attempt 15 PASS PERFECT**, completed 2026-09-10 01:36:59 ICT. Log:
`logs/phase3b3_pet_skill_action_20260910_013402_b3_attempt15_v1041.jsonl`.
ActionId `4107bba60ea84692900e64d37d099998`, MatchId `M_316ad722`, turn 21,
PID 11324; HT7/card id 7, resources 300 Mana / 250 Rage. One click, 7/7 RAM ACKs
in 1.068051 s, zero direction violations; one Space at estimated elapsed
3.153467 s inside `[3.0, 3.299999952]`, current runtime `PERFECT!`.
`SUCCESS_PERFECT`, exit zero, observer stopped 28 ms after result; no surviving
input controller. User reported done. No code/timing change or further action.
Accounting: **15 full attempts = 13 accepted + 1 scored unconfirmed + 1 excluded**;
**14 scored**, scored streak **10/10**, cumulative confirmed directions **91/91**.
Direct final-summary audit of attempts **5-10 and 12-15** confirms 10 current
Perfect results, 70/70 directions, one card/Space each, zero direction violations
and all Space estimates within runtime windows. Attempt 11 remains excluded
by explicit user decision; pre-input startup refusals are not full actions.
**B3 reliability milestone PASS STRONG** under that declared protocol, not an
unqualified 15/15 success rate. No further B3 live invocation is needed.
Phase 3B.3 overall remains pending final scope/isolation audit and handoff;
no commit/push/package or next-phase integration performed in this log review.

Live **B3 attempt 14 PASS PERFECT**, completed 2026-09-10 01:29:14 ICT. Log:
`logs/phase3b3_pet_skill_action_20260910_011910_b3_attempt14_v1041.jsonl`.
ActionId `217917dac8434242a28b16eb7f7ca352`, MatchId `M_edd151b4`, epoch 2,
turn 31, PID 11324; resources 385 Mana / 235 Rage, HT7/card id 7. One click,
7/7 RAM ACKs in 1.051448 s, zero direction violations, one Space at estimated
elapsed 3.153671 s inside `[3.0, 3.299999952]`, current runtime `PERFECT!`.
`SUCCESS_PERFECT`, exit zero, observer stopped 27 ms after result; no surviving
input controller. User reported done. A preceding geometry-change preflight
was rejected/rearmed with zero input; it is not another full action or a retry
after sending a click. Raw diagnostic preserved. No code/timing changes.
Accounting: **14 full attempts = 12 accepted + 1 scored unconfirmed + 1 excluded**;
scored streak **9/10**, cumulative confirmed directions **84/84**.
Next: **B3 attempt 15**, candidate tenth success; no auto-start during review.

Live **B3 attempt 13 retry 1 PASS PERFECT**, completed 2026-09-10 01:12:07 ICT.
Log: `logs/phase3b3_pet_skill_action_20260910_010424_b3_attempt13_retry1_v1041.jsonl`.
ActionId `fa558d3ad90b492db7fb9c756606fd5c`, MatchId `M_091afa9a`, turn 53;
replacement PID 11324, HT7/card id 7, pre-action resources 570 Mana / 250 Rage.
One card click, 7/7 RAM ACKs in 1.167758 s, zero direction violations; one Space
at estimated elapsed 3.151877 s inside `[3.0, 3.299999952]`, runtime `PERFECT!`.
`SUCCESS_PERFECT`, exit zero, stopped 26 ms after result; no input controller
remains. User reported done. No source/timing changes or callback/post-state wait.
Accounting: **13 full attempts = 11 accepted + 1 scored unconfirmed + 1 excluded**,
current scored streak **8/10**, cumulative confirmed directions **77/77**.
The first attempt-13 launch ended before input and is not a full action.
Next: **B3 attempt 14**, candidate ninth success; no auto-start during review.

**B3 attempt-13 launch stopped before any action**, 2026-09-10 00:52:30 ICT. Log:
`logs/phase3b3_pet_skill_action_20260910_005144_b3_attempt13_v1041.jsonl`.
The observer had attached to PID 35016 at 00:51:46 ICT. Its final summary is
`IDLE`, `invocationConsumed=false`, all input timestamps null; exit 1.
User reported the game went out. Read-only process check now finds game PID
11324 and no Python harness: the old attachment is not alive or attached to
the replacement process. The log does not establish why the old game exited.
No action was attempted, so acceptance totals and streak **7/10** are unchanged.
Next: **retry B3 attempt 13** from the exact boss lobby, with explicit user
authorization and a fresh process/session binding. No automatic restart or
source/timing changes during this status review.

Live **B3 attempt 12 PASS PERFECT**, completed 2026-09-10 00:47:06 ICT.
Log: `logs/phase3b3_pet_skill_action_20260910_004009_b3_attempt12_v1041.jsonl`.
ActionId `f8f75f111fb64b21b3348a1afe4a3b4a`, MatchId `M_b7052e6c`, turn 49;
HT7/card id 7; pre-action resources 230 Mana / 204 Rage. One card click,
7/7 RAM ACKs in 1.050251 s, zero direction violations, one Space at 3.168426 s
inside current `[3.0, 3.299999952]`, runtime `PERFECT!`, `SUCCESS_PERFECT`.
Exit zero, observer stopped 00:47:06.362 ICT; no surviving input controller.
No code/timing change, callback scan or post-state wait. User reported done.
Accounting: 12 full attempts = **10 accepted / 11 scored attempts + 1 excluded**;
current streak **7/10** (attempt 11 excluded per explicit user decision),
cumulative confirmed directions **70/70**. Next: **B3 attempt 13**.

**B3 attempt 11 ended without a QTE** at 2026-09-10 00:35:28 ICT. Log:
`logs/phase3b3_pet_skill_action_20260910_003243_b3_attempt11_v1041.jsonl`.
Match `M_9c449306`, turn 15, ActionId `6fbba057810c4004a9f5d38827a043b3`.
Mana changed 171 -> 271 with Rage 230; one skill click, no fresh QTE, zero
direction/Space input, `CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`, exit 1.
User reported clicking a mana consumable whose animation was still running,
then explicitly requested an unchanged-code retry rather than a fix. Raw log
does not independently identify the animation/blocking flag at click time.
No code or timing changed. User explicitly corrected the acceptance accounting:
attempt 11 is `EXCLUDED_OPERATOR_INTERFERENCE`, neither PASS nor FAIL, because
manual Mana injection is outside the test protocol. Raw result is preserved.
Totals: 11 full attempts = 9 accepted + 1 scored unconfirmed + 1 excluded;
scored sample count remains 10 and the current success streak remains **6/10**.
The earlier streak-reset assessment is superseded by this user decision, not
by a reinterpretation of the raw action result. Tool consumable use remains
prohibited; next valid action is a candidate seventh successive Perfect.
The requested attempt-12 launch was rejected before attach/input:
`start MemoryBoardStateProvider in the lobby before Board.Instance exists`.
It is not a twelfth full action. Wait for the user's exact boss-lobby baseline;
do not bypass the lobby requirement or start another controller automatically.

Live **B3 attempt 10 PASS PERFECT** (2026-09-10 ICT). Log:
`logs/phase3b3_pet_skill_action_20260910_001348_b3_attempt10_v1041.jsonl`.
ActionId `597c6d3aadb24137af302c66d4b273ee`, MatchId `M_47a26f41`, turn 27;
HT7/card id 7; resources 233/248. One card click, 7/7 RAM ACKs in 1.135214 s,
zero direction violations, one Space at 3.170393 s inside current
`[3.0, 3.299999952]`, runtime `PERFECT!`. User requested log verification;
visible result was not separately reported for this action.
`SUCCESS_PERFECT`, exit zero; observer stopped about 27 ms after acceptance,
with no callback scan/post-state wait or surviving input controller.
Accounting: **10 attempts / 9 accepted / 1 unconfirmed**, current streak **6/10**,
cumulative confirmed directions **63/63**. Next: **B3 attempt 11**.

Live **B3 attempt 9 PASS PERFECT** (2026-09-10 ICT). Log:
`logs/phase3b3_pet_skill_action_20260910_000638_b3_attempt9_v1041.jsonl`.
ActionId `9565e7f238d2405eb314214c84dd1fd3`, MatchId `M_7c1eba11`, turn 19;
HT7/card id 7; resources 360/250. One click, 7/7 RAM-confirmed directions in
1.250835 s, zero direction violations, one Space at 3.152789 s within the
current `[3.0, 3.299999952]` interval; RAM and user confirmed Perfect.
`SUCCESS_PERFECT`, exit zero, observer stopped about 29 ms after acceptance;
no callback scan/post-state wait or surviving input controller.
Accounting: **9 attempts / 8 accepted / 1 unconfirmed**, current streak **5/10**,
cumulative confirmed directions **56/56**. Next: **B3 attempt 10**.

Live **B3 attempt 8 PASS PERFECT** (completed 2026-09-10 ICT). Log:
`logs/phase3b3_pet_skill_action_20260909_235156_b3_attempt8_v1041.jsonl`.
ActionId `e3014f3b8cb644c2bd622306692f4b3f`, MatchId `M_63347773`, source
turn 77; HT7/card id 7; resources 240/250. One card click, 7/7 directions
RAM-confirmed in 1.284190 s, zero direction violations, one Space at 3.151786 s
inside `[3.0, 3.299999952]`, current `PERFECT!`, user-confirmed Perfect.
`SUCCESS_PERFECT`, process exit zero; observer stopped about 28 ms after
acceptance. No callback scan/post-state wait or surviving input controller.
Accounting: **8 attempts / 7 accepted / 1 unconfirmed**, current streak **4/10**,
cumulative confirmed directions **49/49**. Next: **B3 attempt 9**.

Live **B3 attempt 7 PASS PERFECT**. Log:
`logs/phase3b3_pet_skill_action_20260909_233727_b3_attempt7_v1041.jsonl`.
ActionId `a2d79a409a80417ab2cefef42f4b6493`, MatchId `M_5e2aed5d`, turn 75;
HT7/card id 7; resources 430/250. One card click, 7/7 RAM-confirmed directions
in 1.084980 s, zero direction violations, one Space at 3.153923 s within
`[3.0, 3.299999952]`, runtime `PERFECT!`, user-confirmed Perfect. The harness
returned `SUCCESS_PERFECT` and exited zero, stopping about 28 ms after runtime
acceptance. No callback scan/post-state wait or surviving input controller.
Accounting: **7 attempts / 6 accepted / 1 unconfirmed**, current streak **3/10**,
cumulative confirmed directions **42/42**. Next: **B3 attempt 8**.

Live **B3 attempt 6 PASS PERFECT**. Log:
`logs/phase3b3_pet_skill_action_20260909_232748_b3_attempt6_v1041.jsonl`.
ActionId `7129a97e00fc417baacce20063cbdbd4`, MatchId `M_eef5529e`, source
turn 43; HT7/card id 7; pre-action resources 390/250. One card click, 7/7
directions RAM-confirmed in 1.201285 s, zero direction violations, one Space at
3.152418 s in `[3.0, 3.299999952]`, current runtime `PERFECT!`, user-confirmed
Perfect. The harness returned `SUCCESS_PERFECT` and exited zero, with the
observer stopped about 28 ms after acceptance. No response/post-state wait.
Accounting: **6 full attempts / 5 accepted / 1 unconfirmed**, current streak
**2/10**, cumulative confirmed directions **35/35**. Next: **B3 attempt 7**.
No input controller remains; code and timings are unchanged.

Live B3 retry / full-action attempt 5 **PASS**. Log:
`logs/phase3b3_pet_skill_action_20260909_231903_b3_attempt5_v1041.jsonl`.
ActionId `ea4f713d62d74cb4b389cfd02d66bc9b`, MatchId `M_ad73d344`, turn 25,
HT7/card id 7, current resources 330/250. One click, fresh generation 1,
7/7 RAM-confirmed directions in 1.234045 s, zero direction violations, and one
Space at 3.183263 s inside `[3.0, 3.299999952]` yielded current `PERFECT!`.
User confirmed one Perfect. The executor returned `SUCCESS_PERFECT`, process
exit zero, and the observer stopped about 27 ms after runtime acceptance.
There was no callback scan/post-state wait. No input controller remains.
Accounting: **5 full attempts / 4 accepted / 1 unconfirmed**, current streak
**1/10** following attempt 4. Next is controlled **B3 attempt 6** from boss lobby.
No code or timing changes were needed for this successful retry.

B3 action 4 ended **CARD_CLICK_SENT_QTE_UNCONFIRMED**, exit 1. Log:
`logs/phase3b3_pet_skill_action_20260909_230144_b3_action4_v1041.jsonl`.
At turn 55 of `M_5a7fcc7d`, ActionId `58a8a512b0e1422f9f9e3cd21658594e`,
the native hand proved current HT7 at slot 4/5, actionable, resources 360/250,
cost 200/200. One click was sent at 23:13:38; no fresh QTE appeared before the
3-second deadline. No directions or Space were sent; the harness stopped.
This full-action attempt is retained: final-contract aggregate **4 attempted /
3 accepted / 1 unconfirmed**, current consecutive reliability streak **0/10**.
Historical B2 PASS remains valid.

After the user's disconnect report, read-only checks on PID 35016 still found
the same MatchId/Board, turn 67 advancing to 72, exact HT7 slot 4/5 and current
resources 510 Mana / 225 Rage at turn 67. No input controller remained.
Player.log confirms DNS connection failures and WS close code 1006 ending at
23:05:59, before combat was first observed at 23:07:23. That supports the
reported earlier disconnect but does not establish why the 23:13:38 click had
no observed QTE. Lost click vs delayed/missing challenge remains UNKNOWN.
No code changes or automatic restart were made during the diagnostic review.
The historical successful sequence and timing evidence below remain preserved.

Live B2 action 3 **PASS**. Log:
`logs/phase3b3_pet_skill_action_20260909_024319_b2_action3_v1041.jsonl`.
ActionId `c6bc1d4de62040f991dd21351b1f48d9`, match `M_76c33a56`, lifecycle
epoch 2, source turn 57. One HT7 click, **7/7** ACKs in **1.200452 s**, zero
direction violations, one Space at **3.201961 s** in `[3.0, 3.299999952]`,
current runtime `PERFECT!`, and clean exit zero. Runtime acceptance was observed
47 ms after Space; observer stopped about 27 ms after the acceptance event.
No callback scan or post-state wait occurred. User reported completion.

**B2 PASS: 3 full actions / 3 accepted under the final contract**, 21/21
directions, three card clicks, three Space confirms, PERFECT 3 / GOOD 0 / BAD 0,
zero critical input violations. Action 1 is explicitly reclassified v1.0.40
evidence; actions 2 and 3 are clean v1.0.41 runs. The next reliability milestone
extends this same recorded streak toward 10: **B3 action 4/10**, not a reset.
Three distinct MatchIds and fresh action/QTE identities support session isolation.
Phase 3B.3 remains PARTIAL until remaining acceptance/finalization is complete.

The action-2/action-1 paragraphs below retain their chronological counts.

Live B2 action 2 **PASS** on v1.0.41. Log:
`logs/phase3b3_pet_skill_action_20260909_023218_b2_action2_v1041.jsonl`,
ActionId `da95a2ef9a574277b30a29456ee6b2e4`, match `M_bea34652`, turn 49.
One HT7 card click, 7/7 RAM-ACKed directions in 1.151995 s, zero direction
violations, and one Space at 3.168201 s inside `[3.0, 3.299999952]` produced
current CardUI `PERFECT!`; the user confirmed one Perfect. The executor returned
`SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT` and exited zero about
29 ms after logging runtime acceptance, with no response scan or post-state wait.
The legacy `completedQtes=0` counter counts correlated callbacks, not completed
input actions; `runtimeHookSummary` proves the one successful action.
B2 is now **2/3** (two full actions / two accepted under the final contract).
Next is **B2 action 3/3**. The action-1 reclassification below remains historical
context; action 2 is a fresh v1.0.41 live validation.

The final user contract in `DECISIONS.md` is now implemented: exact current
server challenge, all directions RAM-ACKed, one in-window Space, and the same
CardUI generation reporting runtime `PERFECT` immediately produce
`SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`.
No response tap, callback heap scan, transient transport capture, post-effect
board wait, or second input is part of this action. Subsequent gameplay must
still pass its independent normal GameState/actionability gate.

The B2 action-1 log is
`logs/phase3b3_pet_skill_action_20260909_b2_action1_v1040.jsonl`, ActionId
`530143a332e24f7fb584b7fee275ca11`, match `M_a04f76c1`, source turn 79.
It proves one card click, **7/7** ACKs in **1.234376 s**, zero direction
violations, and one Space at **3.183324 s** inside `[3.0, 3.299999952]`.
Both runtime RAM and the user reported Perfect. The original v1.0.40 harness
then failed solely on its leftover 30-second post-state gate: 107 polls reported
`latest_acked_batch_not_resolved`, four `awaiting_direct_owner_batch_capture`.

That original failure/log is preserved. Evidence review under the final user
contract accepts this completed QTE as **B2 1/3**, with **one full action / one
accepted / zero input or timing failures** in this new sequence. This is a
reclassification of a v1.0.40 live capture, not a claimed v1.0.41 live run. Its
earlier zero-click turn-boundary rejection is separately recorded and does not
consume an action. Next: controlled **B2 action 2/3** on v1.0.41.

The old post-state tests were replaced with active completion, no-extra-input,
ownership/generation rejection and no-response-capture tests. No obsolete test
class is skipped. Detailed validation and evidence are in `phase3b3_report.md`.
Verification: **137/137 focused** and **1065/1065 full regression PASS**, zero
skipped tests; compileall and diff checks PASS. The reduced total reflects
replacement of 24 obsolete post-state tests with 10 current boundary/helper
tests (plus the new ownership/reject/tap coverage), not hidden failures.
All versioned entries below retain the historical acceptance rule at that time;
they do not override this section or `DECISIONS.md`.

### Historical v1.0.40 — intermediate runtime PERFECT + settled-state gate

Live B1 revalidation is **PASS**. Log
`phase3b3_pet_skill_action_20260909_012152.jsonl`, ActionId
`e7ea05db917a46d0aae9547cbb983d47`, match `M_702266cf`, source turn 49:

- one dynamic HT7 card click and one fresh QTE generation;
- sequence `RIGHT LEFT DOWN RIGHT UP LEFT LEFT`, all **7/7** individually
  RAM-ACKed in 1.167871 s;
- wrong/missing/duplicate/stale/blind retry: **0/0/0/0/0**;
- exactly one Space at 3.153660 s inside the current runtime interval
  `[3.0, 3.299999952]`, 3.660 ms after its midpoint and with 153.660/146.340
  ms margins;
- predicted `PERFECT`, CardUI runtime `PERFECT!`, and user-visible `Perfect`;
- later full GameState was current, stable, board-ready and non-cascading, with
  authoritative turn progress 49 -> 51 and resources 238/250 -> 140/150;
- clean `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT_AND_SETTLED_GAME_STATE`
  termination; harness exited and sent no second action.

The callback happened to correlate in this sample but carried no semantic
server result (`server_result=null`). It is recorded only as telemetry and was
not the success gate. The settled GameState progress completed the action.
B1 is closed; the next milestone is controlled B2 at **0/3 consecutive**.

The user corrected the Phase 3B.3 acceptance boundary after repeated live
actions where the game accepted `7/7 + Space`, CardUI reported `PERFECT`, the
Pet Skill executed (including a lethal win), but the external observer did not
retain `MATCH_SKILL_USE_RES`. Native b2 inspection confirms two different
server interactions: the pre-input server challenge supplies the authoritative
direction sequence/timing and remains mandatory; the post-Space response is
handled internally by `CardUI.WaitForWsSkillResolution`/`MatchService` to apply
combat state, but need not remain externally observable.

v1.0.40 therefore completes QTE input on exact current-generation CardUI
runtime `PERFECT`, then waits for a later exact terminal state or fresh stable,
ready, non-cascading full GameState with progress in board identity, turn or
local resources. Only that settled-state gate completes the
one-shot. Missing callback, missing timing echo and callback-without-board are
telemetry conditions, not failures. The direct dispatcher tap remains armed as
a non-blocking telemetry/board fast path; broad heap result scans are disabled
for this callback-optional harness so they cannot delay the settled-state read.
An explicit reject is still fatal, but only after current MatchId, explicit
skill/challenge identity or bounded generic timestamp checks pass.

Offline verification: **149/149 focused** and **1077/1077 full regression
PASS**. Python compilation and diff checks remain required at final handoff.

### B2 retry: PERFECT skill won and closed combat before result correlation (2026-09-08, v1.0.39)

Log `phase3b3_pet_skill_action_20260908_231448.jsonl`, ActionId
`ef0116e70f014ef3a21cfdd152b98c4f`, match `M_2ba7d737`, source turn 41.
The one current HT7 click produced `UP RIGHT RIGHT UP RIGHT DOWN UP`; all 7/7
directions were RAM-ACKed in 1.150914 s. Exactly one Space at 3.186133 s was
inside `[3.0, 3.299999952]`. Runtime RAM reported `PERFECT!` with
`qteElapsedMs=3186`, and the user confirmed the skill won the match.

About 0.62 s after QTE closure, combat lifecycle ended before the queued server
callback was sampled. The old observer treated the failed ACTIVE control poll
as an action invalidation, immediately disarmed the response tap and stopped.
Visible win/PERFECT is not a substitute for the mandatory current server result
and fresh post-skill state, so this action is not accepted. B2 remains **0/3**;
cumulative full actions are **12: 2 accepted, 10 failed**.

v1.0.39 adds the missing terminal handoff. Only after one Space and a bound
runtime-completed QTE, loss of ACTIVE ownership enters a bounded read-only wait:
the immutable ActionId/MatchId and pre-armed dispatcher tap remain alive, no
additional input is possible, and only an exact old-MatchId callback may
correlate. Completion then requires a later, fresh terminal GameState tied to
the same match. Pre-Space lifecycle loss, stale QTEs, wrong-match terminal state,
Emergency Stop and timeout still fail closed. Offline verification is
**297/297 focused** and **1072/1072 full regression PASS**; compileall and diff
check are clean. A live retry is required.

### B2 retry: skill response had no board and later transport boards escaped (2026-09-08, v1.0.38)

Log `phase3b3_pet_skill_action_20260908_224056.jsonl`, ActionId
`743ebfa7f9e84af5ae44d95b2830e15b`, match `M_bba167e4`, turn 47. One click
created `RIGHT LEFT LEFT LEFT DOWN DOWN UP`; 7/7 directions were RAM-ACKed in
1.185870 s. One Space at 3.171934 s landed inside `[3.0, 3.299999952]`;
runtime/RAM reported `PERFECT!`, `qteElapsedMs=3156`, and exact current server
correlation passed.

This response variant genuinely lacked `board/srvSeq`. During the 30-second
post-state wait the match advanced through turns 48--51, but all 111 polls had
no current ACK-attested complete batch (5 direct-capture grace, then 106
`no_current_ack_attested_complete_batch`). The pre-armed dispatcher tap was
disarmed immediately after result correlation, so it could not retain a later
short-lived `MATCH_MOVE_RES`/`MATCH_CARD_USE_RES` board. No board was invented;
the action is not accepted. B2 stays **0/3** and cumulative full actions are
**11: 2 accepted, 9 failed**.

v1.0.38 keeps the same read-only tap armed through the bounded post-state wait.
It now retains strict current-MatchId boards from later supported response
events, distinguishes address reuse by closure JSON identity, and offers each
snapshot once to the unchanged provider. Exact `srvSeq`, 64-cell semantics,
latest `_ackedSeqs`, presentation idle and stability remain mandatory before a
fresh GameState can pass. This cannot emit card/direction/Space input. A new
live action is required. Offline verification is **293/293 focused** and
**1068/1068 full regression PASS**; compileall and diff check are clean.

### B2 retry: immutable JSON observed but result decode still depended on mutable DTO (2026-09-08, v1.0.37)

Log `phase3b3_pet_skill_action_20260908_222828.jsonl`, ActionId
`5b98fadfab394d6b9bb75958fc1bc998`, match `M_3c2943da`, turn 21. One click
created `RIGHT DOWN UP DOWN DOWN UP UP`; all 7/7 directions were RAM-ACKed in
1.101554 s with zero violations. One Space at 3.186741 s was inside
`[3.0, 3.299999952]`; runtime/RAM reported `PERFECT!` and
`qteElapsedMs=3172`.

The pre-armed dispatcher tap completed 6,017 stable root reads with zero torn
reads and observed 44 callback candidates, but decoded zero skill responses.
Code review found the remaining dependency: it read the immutable closure JSON
only *after* mutable `ChatMessageDTO` decoding succeeded. When Unity cleared or
reused that DTO before the 2 ms sample, the still-owned raw response was ignored.
The current action therefore has no server correlation and is not accepted;
B2 remains **0/3**, cumulative full actions **10: 2 accepted, 8 failed**.

v1.0.37 parses exact `MATCH_SKILL_USE_RES` and current MatchId directly from
the callback-owned raw JSON even when its DTO is unreadable. Only the bounded
correlation fields already consumed by the observer are projected; the raw
timestamp must still pass current-generation temporal correlation, while any
board independently retains strict 8x8/`srvSeq` validation and the unchanged
ACK/stability gate. Other callback events and stale MatchIds remain invisible.
No input retry, memory write, hook, game call or network access was added. A new
live action is required. Offline verification is **291/291 focused** and
**1066/1066 full regression PASS**; compileall and diff check are clean.

### B2 retry: raw response board proven; long presentation exceeded 15 s (2026-09-08, v1.0.36)

Log `phase3b3_pet_skill_action_20260908_164100.jsonl`, ActionId
`545efe7efae74f129d3d68f83efed806`, match `M_52debf2f`, turn 63. One current
HT7 click created `LEFT UP UP RIGHT DOWN LEFT DOWN`; all 7/7 directions were
RAM-ACKed in 1.184840 s with zero direction violations. Exactly one Space was
sent at 3.202731 s inside `[3.0, 3.299999952]`; runtime/RAM reported
`PERFECT!` and `qteElapsedMs=3188`. The current server response was correlated.

This live retry proves the v1.0.35 callback path: immutable closure JSON decoded
a strict 64-cell board for current `MATCH_SKILL_USE_RES`/`srvSeq=146`, with zero
raw-board rejection, and the unchanged transport gate accepted the offer. The
provider then spent 19 polls waiting for the latest ACK-attested batch, reached
one valid stability confirmation after the long skill cascade, and immediately
entered the next turn's presentation. The fixed 15-second post-state deadline
expired with 10 `presentation_busy_or_batch_pending` polls. No stale board was
published and the action is not accepted. B2 remains **0/3**; cumulative full
actions are **9: 2 accepted, 7 failed**.

v1.0.36 changes only the controlled harness's bounded read-only post-state wait
from 15 to 30 seconds. The exact MatchId/session, response-board semantics,
`_ackedSeqs`, latest-sequence, presentation-idle and stability gates are
unchanged. No card click, direction or Space can be retried during this wait.
A new live action is required. Offline verification is **266/266 focused** and
**1063/1063 full regression PASS**; compileall and diff check are clean.

### B2 action 2: mutable DTO board absent; callback raw-JSON path added (2026-09-08, v1.0.35)

Log `phase3b3_pet_skill_action_20260908_161553.jsonl`, ActionId
`904832e6d5aa4af58fd62ad37ec02e87`, match `M_8c1c22c3`, turn 27. One click
created a fresh QTE; 7/7 directions were RAM-ACKed in 1.233585 s with zero
direction violations. One Space at 3.153407 s was centered inside
`[3.0, 3.299999952]`; runtime/RAM reported `PERFECT!`, and the pre-armed tap
captured current `MATCH_SKILL_USE_RES`/`srvSeq=63` after about 1.2 seconds.
The three-second direct window worked and no blocking heap scan occurred.

The deserialized DTO's `matchPayload` no longer contained `board`, while the
owner capture retained only an older ACK-attested batch; 43 post-state polls
correctly rejected it as `latest_acked_batch_not_resolved`. This action is not
accepted and resets B2 consecutive progress to **0/3**. Cumulative full actions
are **8: 2 accepted, 6 failed**.

Reverse evidence already declares immutable closure field
`ChatService.__c__DisplayClass275_0.json +0x18`, assigned before the callback
is enqueued, alongside mutable/deserialized `message +0x20`. v1.0.35 now reads
that exact callback-owned IL2CPP string only for a decoded current
`MATCH_SKILL_USE_RES`, strictly parses exact type/MatchId, bounded `srvSeq`,
8x8 cell shape, coordinates, tags and multipliers, then offers the board to the
unchanged transport + `_ackedSeqs` + stability gates. Malformed/stale JSON
cannot authorize state. No target write, hook or network interception is used.
Validation is **148/148 focused** and **1062/1062 full regression PASS**, with
compileall and diff check clean.

### LIVE B2 fresh sequence — action 1/3 accepted (2026-09-08, v1.0.34)

Log `phase3b3_pet_skill_action_20260908_160105.jsonl`, ActionId
`9d7d75488ae04f21b58e670153bf614e`, match `M_aee2377f`, turn 25: one current
HT7 click created a fresh seven-direction QTE. All 7/7 directions were
individually RAM-ACKed in 1.234155 s with zero wrong, missing, duplicate, stale
or blind-retry inputs. Exactly one Space was sent at 3.169678 s in the current
`[3.0, 3.299999952]` interval; margins were 0.169678/0.130322 s and runtime
reported `qteElapsedMs=3170`, `PERFECT!`.

The pre-armed tap retained exact current `MATCH_SKILL_USE_RES`, MatchId
`M_aee2377f`, `srvSeq=59`; temporal-session correlation passed. The response
board was accepted and the normal ACK/stability gate produced a fresh
post-skill GameState at turn 26. Resources changed 523 Mana/250 Rage to
623/150 after the board effect, retained as a net delta rather than changing
the proven gross skill cost. Result: `SUCCESS_PERFECT`. B2 consecutive progress
is now **1/3**. The harness exited cleanly and no controller remains.

### Latest B2 retry: response captured; broad fallback blocked post-state owner capture (2026-09-08, v1.0.34)

Log `phase3b3_pet_skill_action_20260908_154136.jsonl`, ActionId
`41e5a99b88024ae4b7eeb42d8a5cb608`, match `M_8938a3ae`, turn 29: the v1.0.33
pre-armed tap worked. One HT7 click produced a fresh QTE, 7/7 directions were
RAM-ACKed, one Space landed inside the current Perfect window, runtime/RAM
reported `PERFECT!`, and the direct dispatcher root retained the exact current
`MATCH_SKILL_USE_RES` with `payload.srvSeq=69`. Correlation passed through
`CURRENT_ENVELOPE_TEMPORAL_SESSION`. The response variant did not contain a
board, and a 1.5-second broad heap fallback had blocked the main loop during
the response window, so no transient `PendingCombat`/owner-queue batch was
retained. The post-state gate correctly timed out. This action is not accepted:
B2 remains **0/3**; cumulative full actions are **6: 1 accepted, 5 failed**.

v1.0.34 gives the already pre-armed 2 ms dispatcher tap an exclusive
three-second result window before permitting the blocking broad heap fallback.
During that interval the normal 25 ms control loop continues read-only capture
of `MatchService.PendingCombat` and `BoardWsApplier._pendingBatches`; captured
batches still require their exact sequence in `_ackedSeqs` plus all normal
stability gates. The 15-second action deadline and fallback scan remain, while
all result/post-state authority requirements are unchanged. Validation is
**136/136 focused** and **1058/1058 full regression PASS**, with compileall and
diff check clean. A new live action is required.

### Latest B2 retry: QTE/Perfect passed, dispatcher tap armed too late (2026-09-08, v1.0.33)

Log `phase3b3_pet_skill_action_20260908_022704.jsonl`, ActionId
`35073db47b56444b8d31a4cbdb023b70`, match `M_2cf12832`, turn 57: current
HT7 preflight proved 280 Mana/250 Rage; the action RAM-ACKed 7/7 directions in
1.134015 s and sent one Space at 3.184344 s inside
`[3.0, 3.299999952]`. Runtime/RAM both reported `PERFECT!`, but neither the
dispatcher tap nor bounded heap fallback retained `MATCH_SKILL_USE_RES`, so
the strict action correctly failed without retry. This is not accepted for B2:
consecutive progress remains **0/3** and cumulative B2 full actions are
**5: 1 accepted, 4 failed**.

The new telemetry isolated the implementation race: the tap observed stable
dispatcher roots 2,809 times and other callback candidates 18 times, but it
was first armed only after Space had already been sent. The polling thread
could therefore start after Unity had enqueued and drained the short-lived
skill response. v1.0.33 pre-arms the same read-only ownership tap as soon as
the one-shot action identity exists, before the card click. Result acceptance
is unchanged: a response is not promoted until the current QTE is complete
and exact MatchId, bounded server timestamp, runtime Perfect and fresh
post-state gates all pass. Validation is **135/135 focused** and **1057/1057
full regression PASS**, with compileall and diff check clean. A new live action
is required; no controller is running.

### Latest B2 retry: second result-envelope miss; dispatcher tap added (2026-09-08, v1.0.32)

Log `phase3b3_pet_skill_action_20260908_014748.jsonl`, ActionId
`c2e8607752ed481b9afbf25dd80c2c43`, match `M_9390287b`, turn 51: one current
HT7 click produced a fresh QTE; all 7/7 directions were RAM-ACKed in
1.150589 s with zero direction violations. One Space at 3.151488 s was within
`[3.0, 3.299999952]`; runtime/RAM reported `PERFECT!`. Four alternating full
rediscovery passes (3.203–3.375 s each) plus learned scans still found no
short-lived `MATCH_SKILL_USE_RES`, so strict response/post-state acceptance
correctly failed with no input retry. B2 remains **0/3**; cumulative B2 full
actions are **4: 1 accepted, 3 failed**.

Fresh b2 native evidence proves `ChatService.OnWebSocketMessage` stores the
deserialized message in `__c__DisplayClass275_0.message +0x20`, then calls
`UnityMainThreadDispatcher.TryEnqueue(Action,bool)`. v1.0.32 now arms a
read-only 2 ms direct tap immediately after the one Space. It stable-reads the
exact `_executionQueue` and `_drainBuffer`, requires the verified queue/list/
closure classes, follows `Action.m_target +0x20`, and retains only a current
MatchId `MATCH_SKILL_USE_RES`. Mutable container shape/version and roots are
re-read; torn samples fail closed. The old bounded heap scan remains a delayed
fallback and every correlation/post-state gate remains unchanged. Validation:
**54/54 dispatcher/QTE focused**, **1056/1056 full regression**, compileall and
diff check PASS. Live validation of this new capture path is pending; no
controller is running.

### Latest B2 retry: action executed, result-envelope scan raced (2026-09-08, v1.0.31)

Log `phase3b3_pet_skill_action_20260908_011400.jsonl`, ActionId
`7da3bdfc86b4488c9c8f42789fa6fa03`: the current HT7 click was accepted,
7/7 directions were RAM-ACKed without violations, and one Space at 3.154924 s
produced runtime/RAM `PERFECT!`; the operator saw the skill execute. The first
full ChatMessageDTO scan missed the response, then 77 scans remained confined
to ten old learned regions. With no current response/post-state proof the
harness correctly stopped and did not retry input.

v1.0.31 starts direct transient-batch capture immediately after Space and adds
two opposite-direction bounded full discovery passes plus periodic bounded
rediscovery. Correlation and post-state acceptance remain strict. Validation:
**133/133 focused**, **1047/1047 full regression PASS**. B2 consecutive count
remains 0/3; cumulative full-action attempts are 3 (1 accepted, 2 failed).

### B2 action 2 failed at click acceptance (2026-09-08, v1.0.30)

Log `phase3b3_pet_skill_action_20260908_004701.jsonl`, ActionId
`5a7058210c224218922e669e8aa4f9ab`, proved fresh 590 Mana/250 Rage and current
HT7/CardUI/Button at turn 73. Exactly one Windows click was sent, but no fresh
QTE appeared in RAM within three seconds. The harness sent zero directions and
zero Space, did not retry the card, and terminated
`CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY`.

The single-point UI path moved the cursor and pulsed the button immediately,
although the reliable 1.7.4 board path already settles the cursor for 60 ms so
Unity can sample its new position. v1.0.30 requests that same existing settle
only for the Pet Skill click and retains the 75 ms mouse hold, one-click limit
and RAM QTE acknowledgement. Telemetry now records the point/settle/hold.
Validation is **132/132 focused**, **1046/1046 full regression**, compileall
and diff check PASS. Consecutive B2 progress is reset to **0/3**; cumulative
full-action attempts are 2 with 1 success and 1 failure. No controller runs.

### Historical LIVE B2 action 1 accepted (2026-09-07, v1.0.28)

Action `447375a608b642fbaa8fa6a2652ec62b` in match `M_3b575383` completed
`SUCCESS_PERFECT`: one card click, 7/7 RAM-ACKed directions, zero direction
violations, and one Space at 3.170186 s inside `[3.0, 3.299999952]`. The current
response correlated and a fresh turn-34 post-state was published. At that time
consecutive B2 progress was **1/3** from **1 attempt / 0 failures**. The later
action-2 click failure supersedes that consecutive count.

### B2 action 2 zero-input diagnostic (2026-09-08, v1.0.29)

Log `phase3b3_pet_skill_action_20260908_000716.jsonl` found the exact current
HT7 CardUI but stopped producing fresh samples after a transient
`MatchService.Players changed during read` at `17:11:54.609Z`. The last logged
157 Mana/40 Rage predates the operator's later high-resource/card-lit frame and
is not current evidence. This was no Pet Skill invocation: card click,
direction and Space counts are all zero, so accepted B2 progress remained
**1/3 at that diagnostic point**. The later action-2 failure above supersedes
the consecutive count.

v1.0.29 retains input-free fast-watch across transient runtime/actor torn
reads and retries fresh ownership/resource sampling. It does not retain clean
session loss and never retains after input. Resource authorization is now
fail-closed to fresh `Active.playerStatsMap` values; old board fallback values
cannot authorize a click. Telemetry exposes `resourceCurrent`,
`resourceSource`, `resourceReadError` and sample time. Reverse b2 confirms
currentMana `+0x34`, currentPower `+0x54`, unchanged ObfuscatedInt decoding and
HT7 gross requirement 200 Mana/200 Rage. Offline validation: **101/101
focused**, **1045/1045 full regression**, compileall PASS. No controller is
running; retry the next B2 action from boss lobby.

### LIVE B1 accepted (2026-09-07, v1.0.28)

Log `phase3b3_pet_skill_action_20260907_232352.jsonl` completed one full HT7
action in match `M_951c8052`, turn 61. It sent one current CardUI click, bound a
fresh seven-direction challenge, received authoritative progress for all 7/7
directions, and sent one Space at 3.151958 s inside the runtime Perfect window
`[3.0, 3.299999952]`. Predicted/runtime result was `PERFECT`; RAM displayed
`PERFECT!`. The current server response envelope correlated by exact MatchId
and bounded timestamp, supplied an accepted 64-cell board, and the provider
published fresh turn 62 post-state. Resources changed 221/250 to 21/150.

Terminal result was `SUCCESS_PERFECT` with zero wrong/missing/duplicate/stale/
unconfirmed/blind-retry directions, one card click and one Space. B1 is PASS;
B2 three-consecutive-action acceptance is next. No controller is running.

### Latest B1 retry 23 remediation (2026-09-07, v1.0.28)

Retry 23 log `phase3b3_pet_skill_action_20260907_223807.jsonl` reached an
actionable HT7 at turn 47 (`mana=311`, `power=219`, Button interactable). The
independent final native-hand read then returned the explicit transient error
`geometry changed during walk`; its empty candidate set became
`FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING`. No input was emitted.

v1.0.28 re-arms this zero-input final preflight only when its same sample also
contains exact `pet_skill_control_read_error:*` evidence. It does not make a
real missing capability retryable and does not re-arm after any click/key.
Offline validation is **73/73 focused** and **1042/1042 full regression PASS**.
A corrected lobby-start live retry remains pending; no controller is running.

### Latest B1 retry 22 remediation (2026-09-07, v1.0.27)

Retry 22 log `phase3b3_pet_skill_action_20260907_215135.jsonl` stopped producing
fresh state while the operator could see the Pet Skill card lit. Its last state
was still the old pre-Fusion `pet_skill_not_unlocked_by_fusion`; automatic input
was zero and the controller was explicitly stopped.

The control path previously mutated `CombatSessionTracker` with a lifecycle
sample before rejecting that sample's read errors. One torn sample could erase
the exact watch session and force the idle harness back into an expensive full
provider scan. v1.0.27 rejects lifecycle read errors before session mutation,
retains input-free IDLE/PREFLIGHT across transient control rejection, and retries
the same control-only path without stale authorization or full-scan fallback.
A clean lifecycle exit/session loss still invalidates immediately; after card
click no rejection is retained. Exact rejected operand was not logged by retry
22 and remains UNKNOWN. A fresh lobby-start live retry is pending; no controller
is running.

### Latest B1 retry 21 remediation (2026-09-07, v1.0.26)

The latest one-shot clicked the exact HT7 card and bound the current seven-key
server challenge. RAM acknowledged the first four keys; the next CardUI sample
proved the fifth key was also accepted (`currentIndex=5`, `correctCount=5`,
exact five-key press prefix). A stable MatchService challenge read then threw,
but the old loop discarded the exception and projected `challenge=null` as a
wrong session. The controller stopped at 5/7, so this run is not B1 PASS.

v1.0.26 may bridge one such failed read only from an already-bound generation
whose exact CardUI owner/object/arrow identity, timing and all-correct press
prefix remain current. It never creates a generation or guesses a key; a
second consecutive read failure or any mismatch remains fail-closed. The raw
exception is now logged. A separate zero-input final-preflight turn/Button race
returns the one-shot to waiting; nothing after an emitted click can re-arm.
Offline validation is **71/71 focused** and **1040/1040 full regression PASS**,
with compileall and diff check clean. Corrected live B1 remains pending; no
controller is currently running.

### 1.7.4-b2 compatibility closure (2026-09-07)

The fresh exact reverse dump is now available under
`reverse/reverse_1.7.4-b2`. It matches the installed binary pair and supersedes
the blocker recorded below:

- current `GameAssembly.dll`: 53,603,328 file bytes, SHA-256
  `7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`;
- current `global-metadata.dat`: 15,394,348 bytes, SHA-256
  `F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`;
- metadata magic `0xFAB11BAF`, header version `110`;
- reverse inventory: 103,967 method definitions, 12,401 type-info
  pointers and 456 described fields.

The build-specific type-info RVAs and shifted Board, MatchService,
BoardWsApplier, CardUI/QTE, combat-card, player-stat and boss-room layouts were
replaced only where the new dump provides an exact declaration. Current native
method bytes also revalidated the Unity component bridge: all 15 required
Unity signatures match, the component icall slot is now RVA `0x302CEE8`, and
the new unmarshal signature is gated at RVA `0xBB7CF4`.

A live read-only smoke attached to PID 26452/x64 in the exact pet boss room and
reported `lifecycle=LOBBY`, `lobbyState=BOSS_LOBBY`,
`branch=CHINH_PHUC_ROOM`, a clean room graph and three selected cards including
one Attack card. It sent zero input. Offline validation is **1028/1028 full
regression PASS**, compileall and diff check PASS. The old C67 layout is
intentionally no longer allowlisted because this source tree has one active
build profile. One corrected B1 live retry is still required; Phase 3B.3 is not
yet a live PASS.

The later QTE UI/mechanics audit found a new server challenge identity boundary:
`MatchService.ServerQteChallengeId +0x250`,
`CardUI._qteArrowsFromServer +0x498`, and
`ChatMessageDTO.qteChallengeId +0x148`. Version v1.0.25 binds input to that exact
ID and rejects local/stale arrow lists. The new timeline/D-pad presentation does
not change accepted arrow/WASD + Space/Enter input or the Perfect predicate.
Offline validation after this addendum is **1033/1033 full regression PASS**;
corrected live B1 remains pending.

### Superseded runtime blocker — unverified same-name update

B1 retry was requested from the pet lobby, but no harness was launched. The
read-only precheck found PID 26452 / `Pokiguard-1.7.4.exe`, then attachment
failed closed before any offset/RVA read because the installed binary changed:

- current `GameAssembly.dll`: 53,603,328 bytes, SHA-256
  `7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`;
- current `global-metadata.dat`: 15,394,348 bytes, SHA-256
  `F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`;
- currently reverse-verified 1.7.4 GameAssembly hash:
  `C67FF9CC3BB280CC63B3B9BE24D45ED038937F70A95E13075D361C8DDDE95A78`.

The installed GameAssembly/metadata timestamps are 2026-09-06, while the
available `reverse/redux_compat` output is from 2026-09-01. The unchanged EXE
name is not compatibility evidence. Do not add the new hash to the allowlist,
reuse old offsets/RVAs, or run B1 until a fresh reverse dump for this exact
pair is supplied and the required Phase 3B.3 symbols/native signatures are
revalidated. This blocker is now closed by the compatibility evidence above;
the paragraph is retained as historical fail-closed evidence.

Retry 19 log `logs/phase3b3_pet_skill_action_20260906_213144.jsonl`: after
Fusion the control refresh found the exact HT7 slot 4. Its last recorded sample
at turn 7 was Button non-interactable and 260 Mana / 0 Rage, so
`INSUFFICIENT_RAGE` was correct only for that sample. The operator later had
enough resources and manually used the card, but the log had stopped at
21:33:41 while controller PID 3424 remained alive until inspected around
21:36:30. The worker therefore never observed the later resource state.

The controller was stopped by Ctrl+C before further testing. Automatic card
click, directions and Space were all **zero**; the manual QTE is not acceptance
evidence. The old build had no per-call stage marker, so the exact blocking
synchronous call is UNKNOWN.

The current build traces nested native-card refresh, QTE control, observer
runtime reads and geometry proof. A daemon watchdog is active only while input
could still be emitted; any one stage exceeding 2 seconds revokes input
authority and records `pet_skill_action_stage_stalled` before a delayed click
can occur. Lobby scans and read-only result/post-state waits are excluded. No
input retry or relaxed authority gate was added. **145/145 focused and
1028/1028 full regression PASS**, compileall/diff check PASS.

Retry 18 log `logs/phase3b3_pet_skill_action_20260906_212126.jsonl`, MatchId
`M_8c2f4e06`, source turn 21: direct native refresh read the exact HT7 card at
slot 4, current CardUI/Button, `interactable=true`, 855 Mana / 250 Rage and
effective cost 200/200. Current geometry proof completed in 156 ms and the
one-shot entered `PREFLIGHT`.

No input had been emitted. The next mandatory preflight sample incorrectly
fell back to the full board provider instead of retaining the exact
native-hand/control-only route. It hit aggregate guard
`ACTIVE_COMBAT_OWNERSHIP_INVALID` about 0.46 seconds later and consumed the
attempt with **zero** card clicks, directions and Space. The old unowned branch
did not log the individual guard operands, so the precise transient operand is
UNKNOWN; this is scheduling evidence, not a failed game click.

The input-free `PREFLIGHT` state now remains bound to its action session through
`refresh_pet_skill_cards(session) + poll_qte_control(session)`. Fresh direct
geometry and all card/identity/turn/resource/foreground/QTE gates remain
mandatory; no click/key/Space retry was added. **142/142 focused and 1025/1025
full regression PASS**, compileall/diff check PASS. A new live B1 retry is still
required.

Retry 17 log `logs/phase3b3_pet_skill_action_20260906_204900.jsonl`, MatchId
`M_0bd305f9`: initial turn-1 capability was correctly absent, but no later
capability transition was logged before the match ended at turn 33. The
operator observed the Pet Skill card lit and one local turn was missed. The
harness sent **zero** card/direction/Space input and was explicitly terminated
before another match.

Read-only retained MatchService evidence after combat proves Fusion actually
succeeded (`usedSuccessfully=true`, `lastAttemptTurn=25`) and its
`LocalFusionSkillCard` remains a valid HT7 CardData (`cardId=7`,
`ATTACK_LEGEND_`, costs 200 Mana / 200 Rage). The old Board/native hand had
already been destroyed, so this completed log cannot prove whether the live
refresh was not entered or its native hand validation returned empty during
that exact turn. Do not infer either case.

The next build emits bounded `pet_skill_control_refresh` evidence on every
state change and at most once per five seconds otherwise: elapsed time, exact
reason and current card/Button state. This does not add scans or input and will
distinguish the remaining cases during the first lit-card turn. **142/142
focused and 1025/1025 full regression PASS**, compileall/diff check PASS.

Retry 16 log `logs/phase3b3_pet_skill_action_20260906_203812.jsonl`, MatchId
`M_3f10490b`: the harness established the session at turn 1, reported
`CURRENT_PET_SKILL_CAPABILITY_MISSING`, then never emitted another current
capability before the operator reported that the HT7 card was lit. No card,
direction or Space input was sent; the harness was manually disarmed to prevent
a delayed click.

An immediate read-only native diagnostic on the same live match proved Fusion
success (`lastAttemptTurn=13`), the exact five-slot native hand and current HT7
at slot 4. The direct owner/CardUI/CardData/Button read took 166–209 ms and
reported `cardId=7`, `ATTACK_LEGEND_`, correct Fusion skill CardData and a live
interactable Button. Root cause: the provider discovered the native hand early
but assigned `observed_pet_skill_cards` only after unrelated board/ACK batch
resolution. An unresolved ACK could run an expensive heap scan or return before
that assignment, so the one-shot action never saw a lit card.

Offline remediation adds a dedicated `refresh_pet_skill_cards(session)` path:
exact current Board/Match ownership, successful Fusion, native cardsInHand,
CardUI/CardData/Button and live flags are refreshed without board/batch scans
or GameState publication. After the first full poll establishes the session,
the idle B1 harness uses this control-plane refresh plus `poll_qte_control`.
Live read-only validation on turn 54 found the exact HT7 slot in **208.806 ms**.
Board/solver/ACK publication rules are unchanged. **93/93 focused and
1024/1024 full regression PASS**, compileall/diff check PASS. A clean B1 retry
from boss lobby remains required.

Retry 15 log `logs/phase3b3_pet_skill_action_20260905_160701.jsonl`, MatchId
`M_e053e2fd`, source turn 23, ActionId
`8f2e5d29a25142949728a0bcbce76f55`: one current HT7 card click; sequence
DOWN LEFT UP RIGHT UP UP LEFT reached **7/7 RAM ACK** in 1.117173 s with zero
wrong/skipped/duplicate/stale/unconfirmed/blind retry; one Space at 3.168743 s
inside `[3.000000,3.299999952]`; runtime `PERFECT!` / 3169 ms. The game effect
completed normally according to the operator.

The harness then incorrectly invalidated `GAME_NOT_FOREGROUND` after all input
had already ended, when the operator returned to Codex. Seven result scans
also mixed ChatMessageDTO and batch-only allocation regions: 76 regions,
703–797 ms per learned scan and 2.563 s for the first learned+full scan. No
response was retained before invalidation, so retry 15 is not full B1 PASS.

Offline remediation makes foreground mandatory only while an input can still
be emitted. `WAIT_RESULT` and post-state remain read-only and can continue
after focus changes, without retrying card/direction/Space. The response scan
now uses only regions that actually contained `ChatMessageDTO`; batch-only
regions remain on the separate direct-owner/post-state path. When current
message hints exist the critical result wait no longer immediately broad-scans
the process. Exact MatchId/generation/timestamp correlation, strict response
board decode and exact ACK/stability gates are unchanged. **139/139 focused
and 1022/1022 full regression PASS**, compileall/diff check PASS. One fresh B1
retry remains required for response + board offer + fresh post-state.

Retry 14 log `logs/phase3b3_pet_skill_action_20260905_152539.jsonl`, MatchId
`M_53b8ad51`, source turn 23, ActionId
`ac2184fbaff74668bc8863937f37978c`: one card click, 7/7 RAM-confirmed
directions in 1.185443 s, zero violations/retries, one Space at 3.166887 s in
the current `[3.000000,3.299999952]` window, runtime `PERFECT!` / 3167 ms.
User observed the skill consume the board, cascade/refill and the next turn
continue normally. Thus live action/game effect succeeded.

The audit still ended `SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY`: no response DTO
was found in 15 s, so the skill-response board decoder added after retry 13 was
not exercised. Log timing exposes a scheduling race: after runtime completion,
all 23 result-wait cycles ran the full provider before response discovery
(31–703 ms each, median 359 ms; 8.326 s total). A short-lived
`MATCH_SKILL_USE_RES` can be reclaimed while this unrelated full scan runs.

Offline remediation keeps the exact current QTE on fast control-only RPM until
server response correlation, starts the first result scan with learned regions
plus bounded full fallback, and captures direct `PendingCombat`/
`BoardWsApplier._pendingBatches` roots while waiting. These captures remain
unpublishable until exact ACK and normal stability checks. Only after response
correlation does full GameState polling resume. Result-scan timing/count is now
logged. No direction/Space/card timing, response authority or timeout is
relaxed. **109/109 focused and 1020/1020 full regression PASS**, compileall/
diff check PASS. Retry 14 is visible action PASS but not full audited B1 PASS;
one fresh live retry remains required before B2.

Retry 13 log `logs/phase3b3_pet_skill_action_20260905_144943.jsonl`, MatchId
`M_d3106c16`, source turn 19, ActionId
`ceb63ff8b7534390a70fed3a4e7e60f5`: one current HT7 card click, 7/7
RAM-confirmed directions in 1.159891 s, zero violations/retries, and one Space
at projected 3.163413 s in `[3.000000,3.299999952]`. Runtime result was
`PERFECT!` / 3163 ms. Exact current `MATCH_SKILL_USE_RES` correlated and the
cleanup wait sent no extra input.

The 15 s reread then failed `CORRELATED_PERFECT_BUT_FRESH_POST_STATE_UNAVAILABLE`:
37 polls stayed at `awaiting_direct_owner_batch_capture` then
`latest_acked_batch_not_resolved` even while the same session advanced through
turns 20–22. This disproves the earlier presentation-delay hypothesis for this
sample. Static 1.7.4 native evidence shows `HandleMatchSkillUseRes` delegates
to `HandleResEnvelope`, which calls `ParseCombatBatch` for that exact
`ChatMessageDTO`; the strict transport decoder/provider had nevertheless
allowed only `MATCH_MOVE_RES`. The current skill response's server board was
therefore never offered to the normal exact-ACK gate.

Offline remediation now decodes only a correlated current
`MATCH_SKILL_USE_RES.matchPayload` that contains bounded `srvSeq` and a strict
64-cell board, then offers it to the unchanged provider gate. Publication still
requires the same `MatchService._ackedSeqs`, current session and all Dot/render/
stability checks; absent/malformed payload remains fail-closed. No cache, old
batch or non-board ACK is promoted. **109/109 focused and 1020/1020 full
regression PASS**, compileall/diff check PASS. Retry 13 is not full B1 PASS;
one fresh live retry must demonstrate `qte_result_board_snapshot_offered` and
`SUCCESS_PERFECT` before B2.

User confirmed retry 12 visibly completed Perfect, the pet consumed the board,
and its animation finished, then returned to the exact boss lobby. That is
strong visible effect evidence but the stopped harness cannot retroactively
bind a response it did not capture.

Retry 12 log `logs/phase3b3_pet_skill_action_20260905_144152.jsonl`,
`M_e40051dc`, source turn 15, ActionId
`9679da7994714a67a0f46c1316d9de09`: one current HT7 card click, 7/7
RAM-confirmed directions, zero violations/retries, one Space in the current
Perfect window, qteElapsed 3174 ms and RAM `PERFECT!`. User reported the QTE
completed. Current server response did not arrive before the old 5 s result
deadline, so the harness exited `SPACE_SENT_RESULT_UNCONFIRMED_NO_RETRY` with
no extra input, no correlation and no post-state. Retry 11 had already observed
a comparable response after about 6.025 s, proving 5 s shorter than real
observed latency.

Result wait is now bounded at 15 s, matching the already corrected 15 s
post-state wait and the existing hard maximum. Waiting is read-only; exactly
one Space/card remains enforced and missing correlation still fails closed.
**102/102 focused and 1018/1018 full regression PASS**, compileall/diff check
PASS. Harness terminal 16967 exited code 1; superseded by retry 13 diagnostics.

Retry 11 log `logs/phase3b3_pet_skill_action_20260905_005856.jsonl`,
`M_1bc9ed56`, local source turn 23, ActionId
`596321bcb0454a5ab2bf03ff1fcd77ac`: one automatic current HT7 card click,
7/7 RAM-confirmed directions, zero direction violations/retries, one Space in
the runtime-derived Perfect window, qteElapsed 3166 ms, RAM `PERFECT!`; user
confirmed Perfect. The new cleanup path retained result ownership without any
extra input and the exact current server envelope correlated successfully.

Fresh full board remained unavailable as `presentation_busy_or_batch_pending`
for 4.157 s after correlation, exceeding the old 4 s post-state deadline.
Therefore retry 11 is NOT full B1 PASS: the required fresh post-skill GameState
is still absent. Default post-state wait is now bounded at 15 s (the existing
hard maximum), read-only, with no stale-board acceptance or input/deadline
retry. **102/102 focused and 1018/1018 full regression PASS**, compileall and
diff check PASS. Harness terminal 73692 exited code 1 and no controller remains.
Await user readiness for one corrected B1 retry; do not start B2 yet.

Retry 10 log `logs/phase3b3_pet_skill_action_20260905_003531.jsonl`:
first match M_d126ec41 ended without skill capability or any automated action;
user continued into M_854938f2 under the same still-unused invocation.
Second match had current HT7/200+200 cost, Mana/Rage 760/250. At local turn 29,
initial geometry preflight passed (125 ms), final geometry proof became absent
(16 ms); action `bf8e410b76bf4b4f97347584bd2355c3` failed
`FINAL_CARD_PET_SKILL_BUTTON_GEOMETRY_UNKNOWN`. Card/direction/Space counts 0.
The final underlying geometry reason was not logged, so its exact branch is
UNKNOWN. Earlier waiting rows contain busy geometry and Button state changes.

Read-only native tracing during the combat reproduced the busy geometry path:
42/48 whole-hand reads succeeded, 6 rejected (2 job pending, 1 changed during
read, 3 changed during walk). Changed bytes were the shared native Transform
job field, not evidence of wrong card identity. An earlier 12/12 sample batch
was stable, proving the rejection is intermittent; not a FPS/ping diagnosis.

Fix: typed busy-geometry errors permit ONE fresh whole-hand reread before any
click (max 2 attempts), no cached geometry or sleep/age extension. Invalid
layout/index/owner/signatures do not retry. Final card usability/identity and
350 ms total age remain mandatory. Prior provider slot is no longer needed to
read the actual native hand; layout diagnostics in the observation come from
that exact current proof, without changing the cached card or resources.
Final events now include geometryReason/readAttempts/retryReason. QTE input
timing is unchanged. **1017/1017 regression, 101/101 native/action/control PASS**,
9 new tests, compileall/diff check PASS. Post-fix read-only probe found no
current Board (zero input); live activation still pending. Await user readiness.

User explicitly requested `retry b1` after terminal-cleanup remediation.
Read-only precheck: game PID 26436 x64, LOBBY (combat objects absent),
HWND 4130696 / client 1280x640, native signatures PASS, no competing controller.
Foreground was false at precheck; operator must foreground game before playing.
Harness PID 2852 / terminal session 92604, timeout 1800 s, log
`logs/phase3b3_pet_skill_action_20260905_003531.jsonl`: now ended with the
zero-input rejection above. Do not assume PID 2852/session 92604 still waits.

Retry 9 log `logs/phase3b3_pet_skill_action_20260905_001953.jsonl`,
`M_2bee7569`, local turn 49, ActionId `ffe5caed04c44db19cb6489868409bb2`:
one card click, 7/7 directions confirmed, zero direction errors/retries, one
Space, runtime **PERFECT / 3181 ms**; user confirmed Perfect. Directions done
at elapsed 1.244 s (1.756 s headroom), control median 15.5 ms / cycle 31 ms.
No initialization-wait event occurred; retry 8's missing-sequence branch was
not exercised by this live sample.

The post-QTE full poll retained valid fresh control, but then normal CardUI
cleanup changed the projected QTE to INACTIVE with identity=None. Result wait
incorrectly rejected that as `QTE_GENERATION_CHANGED_OR_STALE` ~0.52 s after
Space, before server correlation/reread. Exact 7/7, finished=true, PERFECT text
remained in the same raw CardUI. Full B1 is NOT PASS.

Narrow fix: after one Space and a validated completion of the bound generation,
an exact-session INACTIVE snapshot with current clicked capability/actor can
wait read-only for the original result deadline. Historical completion does
not become current QTE/input authority or success. Wrong/stale/new generations,
owner/session changes and stop gates still reject. Full+control polling remains
selected after completion even when later snapshots lose their completion flag.
Server correlation and a later fresh full board remain mandatory. No input
timing change, additional click/Space, deadline extension, auto retry or BASIC.
**1008/1008 regression, 68/68 focused PASS**, 6 new terminal-cleanup tests;
reproduction failed before the fix. Compileall/diff check PASS. New live retry
requires user readiness; see `phase3b3_report.md`.

User explicitly requested `retry B1`. Read-only precheck: game PID 26436 x64,
LOBBY (combat objects absent), HWND 4130696, client 1280x640, foreground true,
native signatures PASS, no competing Python/controller. Launched the corrected
one-shot harness PID 18952 with timeout 1800 s, terminal session 5239, log
`logs/phase3b3_pet_skill_action_20260905_001953.jsonl`. This invocation has now
finished with the partial result above. Operator manually entered/evolved/
collected resources. Do not assume PID 18952 is still waiting.

Previous result log `logs/phase3b3_pet_skill_action_20260904_231540.jsonl`, match
`M_04c99254`, local turn 41: **one automatic card click, zero directions,
zero Space**. At the first active QTE read, CardUI had index/correctCount 0/0,
normalized timeLeft 1.0, but the current server challenge's sequence pointer
was null. Tracker returned `SEQUENCE_UNAVAILABLE`; the action failed at once
with `QTE_NOT_CURRENT_OR_AMBIGUOUS`, about 1.54 s after the card click, before
its existing generation deadline. User reported BAD after this; observer had
already stopped, so BAD is user-observed, not a correlated runtime result.
There is no evidence of an automated direction being sent too early/lost.

Remediation: exact current clicked CardUI/CardData/Button + unchanged current
session/actor/source turn may wait read-only for `SEQUENCE_UNAVAILABLE` ONLY
before generation binding, within the ORIGINAL 3 s default click deadline.
No card retry, guessed local arrows, early keys, FPS sleep or timeout reset.
Wrong ownership/stale evidence and sequence loss after binding still stop.
The fast per-key/ACK and runtime Perfect scheduling from retry 7 are unchanged.
New one-shot diagnostic: `pet_skill_qte_initialization_wait`.
Full regression **1002/1002 PASS**, focused **62/62 PASS**, including 5 new
initialization-wait tests. Compileall/diff check PASS. Neither this fix nor
the post-QTE handoff fix has full live B1 acceptance yet. Await user readiness
before a new retry; see `phase3b3_report.md` and timing evidence.

After user confirmed boss lobby and said continue, fresh precheck found PID
26436 x64 LOBBY, HWND 4130696 / 1280x640, no competing controller. Foreground
was false; operator must foreground the game. B1 retry 8 uses the post-QTE
handoff fix, terminal session 44668, timeout 1800 s, log
`logs/phase3b3_pet_skill_action_20260904_231540.jsonl`. This launch has now
finished with the failure above; do not assume session 44668 is still waiting.
User manually entered/evolved/collected resources. It is not B1 acceptance.

Initial startup log `phase3b3_pet_skill_action_20260904_231435.jsonl` was stopped
in lobby (PID 25044, zero action-state/input events) to suppress repeated
idle-only ownership diagnostics. Diagnostics now emit only while the harness
owns an action. Focused tests rerun 57/57 PASS before the corrected launch.

User explicitly requested `retry B1` after QTE control-only polling fix.
Fresh read-only precheck: PID 26436 x64, LOBBY (no active combat rig),
HWND 4130696, client 1280x640, no competing Python/controller. Foreground was
false during the check; operator must foreground game before playing.
Harness PID 27228 / terminal session 65291 has finished (exit 1); log
`logs/phase3b3_pet_skill_action_20260904_223027.jsonl`. User reported PERFECT.
In `M_448d6389`, turn 79: one automatic card click, 7/7 directions confirmed
at elapsed 1.378 s (1.622 s before Perfect start), one Space, runtime elapsed
3.156 s and `PERFECT!`. All direction error/retry counts zero. Control poll
median 15 ms; QTE cycle median 31 ms over 51 samples.

The next full-provider cycle invalidated with `ACTIVE_COMBAT_OWNERSHIP_INVALID`
before server correlation or fresh post-skill GameState. Full B1 is NOT PASS.
Inspect the fast-control -> normal full-provider handoff: last_state is clear,
while normal non-publishing ProviderPoll paths may omit combat_lifecycle, so
the observer cannot derive direct_session. The old event lacks detailed
poll/root diagnostics; exact failing live branch remains UNKNOWN. Do not
weaken ownership guards or restore stale board authority to force a PASS.
No code fix/restart was performed during that result review.

Subsequent user requested continuing from boss lobby. The post-QTE handoff is
now fixed offline: normal board poll plus fresh control evidence, no stale
last_state authority, detailed root/poll rejection diagnostics, and a strictly
later board read after server correlation (timestamp barrier). Direction/Space
timing code is unchanged. Regression **997/997 PASS** including 7 new post-QTE
tests. New full B1 acceptance remains pending; see `phase3b3_report.md`.

Retry 6 log `logs/phase3b3_pet_skill_action_20260904_220109.jsonl`:
one successful card click in `M_de6ac78f`, then QTE too slow (5/7 by timeout,
BAD, zero Space). PID 14264 / session 43998 finished. Read-only precheck now
finds game PID 26436 in LOBBY and no Python controller. Do not assume the old
invocation is waiting or silently restart it.

Latest remediation isolates fresh QTE control-plane polling from full board/
card/native geometry work; accepted 3B.2 key/ACK primitive remains unchanged.
Space requires all directions and actual RAM time inside current Perfect;
missed windows fail closed. Per-key/per-poll timing and failure summaries are
retained. Read-only smoke completed; live corrected B1 still pending. See
[QTE timing evidence](phase3b3_qte_timing_evidence.md).

Offline validation after QTE remediation: **990/990 tests PASS** (14 new
control/timing tests); read-only observer smoke: clean exit, zero QTE/input.
Retry 7 now establishes live direction/Perfect timing; full B1 correlation
and post-state acceptance remain incomplete.

User confirmed boss lobby and authorized B1 retry after the Canvas correction.
Read-only precheck: game PID 26436 x64, provider LOBBY baseline, native Unity
code signatures PASS; no competing Python/controller process was present.
Harness PID 26944 / terminal session 37504, timeout 1800 seconds, log
`logs/phase3b3_pet_skill_action_20260904_213919.jsonl`. Attach event confirms
HWND 4130696, one card click / one full action, no process writes or game-method
calls. In `M_cf7e3c5a` it resolved CURRENT HT7 CardUI/Button/geometry BEFORE
activation, with enough Mana/Rage and interactable=true, but preflight rejected
the sample as stale. Zero automated inputs/QTEs. User reported the lit card;
harness was stopped with Ctrl+C, not restarted. This is NOT a B1 PASS.

The FIRST six unsuccessful B1 harnesses sent zero automated inputs; retry 6
(the seventh harness) did click the card but did not finish the QTE. Earlier manual QTEs do
not count toward full-auto acceptance. The old fixed-count/previous-Fusion-slot
inference has been removed. Post-evolution skill discovery now uses verified
native component/handle ownership and current RectTransform geometry, with
signature guards. Evidence and remaining validation are in
[Phase 3B.3 report](phase3b3_report.md) and
[native card evidence](phase3b3_native_card_evidence.md). No BASIC skill policy,
packaging, commit or live PASS is claimed by this remediation.

Earlier B1 retry log `phase3b3_pet_skill_action_20260904_210747.jsonl`
exposed `native_card_ui: non-RectTransform geometry`: the reader walked past
the combat's root Canvas into a plain scene Transform. It now stops at the
verified root Canvas, including when nested Canvas raw mode differs. Read-only
inspection then resolved all five live card rectangles and the exact HT7
CardUI/Button. At that point regression was **968/968 PASS**. The match had ended before
the production observer recheck (`local_match_end_flag`); no post-fix automatic
click/full action has been live-accepted. Harness PID 22832 was stopped; do not
reuse this combat's pointers or silently restart automation.

Latest remediation: packed BGRA-to-RGB uses equivalent bulk channel slices;
the common Canvas ancestor path is reused only within a single hand read,
with existing end-of-read parent/TRS/rect/Canvas fences retained. Read-only
native+capture+visual samples improved from 675–742 ms to 197–250 ms; this is
NOT an automatic-click acceptance result. Original 0.35-second preflight age
guard and sample timestamp are unchanged. Logs now include geometry/sample
age timings. Full regression **976/976 PASS**, focused **221/221 PASS**. Full
post-fix B1 and later B2–B4 remain pending. Await user readiness before retry.

User clarified two skill-strip orders and required main/evolution pet choices
in future Preferences. Recorded in DECISIONS and section 22 of the Pet Skill
reverse report. Case 2 (skill appended after successful evolution) matches
current live evidence; case 1 (main-pet skill first) is user-confirmed but not
live-accepted here. No new Preferences or slot-only skill authority was added.

Phase 2F.2 Release Candidate `v1.0.0+15` passed clean staging and packaged-live
acceptance B1-B6 against one unchanged binary. The accepted RC archive is
`PokiguardToolV2-v1.0.0+15-win-x64.zip`, size `13,609,921` bytes, SHA-256
`e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69`,
built from commit `1dd53340e20ca405c0bf446682b3fcbf823afe62` with PyInstaller
6.22.0 and CPython 3.11.9 x64.

B2 FarmRun `e113cf4a037949f68bcebc1d086a311d` completed exactly 10/10
STRONG/CONSISTENT WINs in 12 attempts; two technical aborts recovered and did
not count as combat results. B3 graceful-stop run
`f7936c6c94f24c30b693065062202cfb` completed the in-flight WIN and created no
next attempt. B4 resumed checkpoint `6f604d50505d4148abb32e3d457bf614`
through continuation `8876e53d4a6948388de421e5a9bd9382` to exactly 5/5 WINs
with five unique MatchIds. B5 emergency run
`e2c6919c29d4482a8d2f4cc3c9d37585` acknowledged the command during
`ACTIVE_COMBAT` and emitted zero gameplay, entry, recovery or postmatch input
after acknowledgement. B6 closed cleanly with one stopped controller/poller,
zero UI errors, and the game process still alive.

Focused release tests are **14/14 PASS** and full regression is **740/740
PASS**. Game-installation, source-runtime and packaged-directory write audits
are all zero; game binaries and the RC archive remained byte-identical.

The pre-existing untracked
`docs/pokiguard_pet_skill_qte_reverse_report.md` was verified as a valid
project reverse report and, after explicit user authorization to finalize, was
preserved byte-for-byte in the separate documentation commit `c2f4242e`. It
was not mixed into the RC artifact or production runtime graph. Git hygiene is
therefore resolved and the annotated release tag is `v1.0.0+15`. Canonical evidence:
[Phase 2F.2 report](phase2f2_report.md), [runbook](phase2f2_runbook.md), and
[release manifest](../release/phase2f2_manifest.json).

Phase 3A.0 freezes the newer repository-truth source baseline as `v1.0.23`.
The original `v1.0.1` maintenance boundary was carried forward through the
Pokiguard 1.7.4 compatibility repairs; the accepted packaged RC remains
`v1.0.0+15` and was not rebuilt or retagged. FarmRun
`8f7be1b715644b008431060baab72eef` completed exactly 5/5
STRONG/CONSISTENT WINs in five attempts and returned to `BOSS_LOBBY` with the
controller stopped. It observed five EVOLVE clicks (three success, two
failure) and eight CAST clicks on the shared normalized Y `0.824` boundary;
seven CASTs have direct mana-plus-turn acceptance proof and the final CAST
ended combat before a nonterminal acknowledgement could be recorded. All
card/input safety counters are zero.

Every one of the five result confirmations followed authoritative POSTMATCH,
stable modal evidence and final preflight, was clicked exactly once, and
returned to the exact boss lobby. Terminal-result-to-confirm latency was
2.384--2.456 seconds (average 2.403 seconds), demonstrating removal of the old
fixed five-second delay without weakening the modal boundary. Across 74 live
SWAP decisions there were zero ordinary safe labels with a known direct or
indirect opponent Sword reply and zero UNKNOWN-as-favorable decisions. The
rare unique-adverse-Sword and Sword-hold live branches were `NOT_OBSERVED` and
remain covered by deterministic tests. Per-match local turns/energy were
19, 23, 17, 17 and 23 (total 99, average 19.8). Canonical evidence is in the
[Phase 3A.0 report](phase3a0_report.md) and
[runbook](phase3a0_runbook.md).

Post-release source maintenance `v1.0.1` originally added three operator-requested
refinements. Combat card visual validation remains centred at normalized Y
`0.836`, but the actual EVOLVE/CAST click is raised to Y `0.824` (about 8.5
pixels at the canonical 710-pixel client height). The combat worker's redundant
postmatch lobby wait is reduced from 5 seconds to 1 second. Result confirmation
still requires authoritative POSTMATCH, three stable high-confidence modal
frames, and a fresh POSTMATCH/foreground preflight immediately before its
single click; the visual frames no longer repeat the heavy memory-provider
poll. Finally, BASIC Sword safety now audits every legal boss reply on the
settled known board, including a non-Sword direct match whose deterministic
cascade collects Sword. The unique-adverse-Sword exception can defer the only
Sword move and use authoritative PASS or a separately proven Sword-hold; the
hold is never labelled safe and UNKNOWN earns no favorable credit. Offline
verification at that historical checkpoint was **745/745 PASS**. Its live
validation boundary is superseded by the accepted Phase 3A.0 `v1.0.23` run
above.

Source compatibility update `v1.0.3` removes the runtime dependency on the
retired fixed launcher name `Pokiguard.exe`. The new **Settings** tab persists
the exact full path of one operator-selected `Pokiguard-<version>.exe` beside
`GameAssembly.dll`, and applies that path to both the read-only desktop observer
and FarmRunner attach path. When an update changes the launcher filename, the
operator selects the new EXE with **File...**. Process
matching requires both executable name and full module path, so another game
copy with the same filename is not accepted. The setting is locked while a
controller owns an active run and changing it drops only the cached read-only
handle; no game file is written or modified.
The full source regression suite is **759/759 PASS** and the source UI smoke
resolves `D:\pc\Pokiguard-1.7.4.exe` with zero render errors.

Source compatibility update `v1.0.4` adds verified metadata-110 symbols and
field layouts for the current Pokiguard 1.7.4 `GameAssembly.dll`. The desktop
observer distinguishes an exact detected process from an incompatible memory
layout instead of reporting both as a missing game. Unknown future binary
hashes fail closed before a memory provider is constructed. A read-only live
probe resolves the new type-info slots and constructs the provider; boss-room,
combat and autonomous behavior still require live validation on 1.7.4. See
[pokiguard_1.7.4_compatibility.md](pokiguard_1.7.4_compatibility.md).

Source compatibility update `v1.0.5` cross-checks the split
`reverse/redux_compat` output against the existing 1.7.4 layout. The executable,
GameAssembly and metadata hashes are unchanged, and the boss-room field offsets
match. The desktop observer now evaluates the exact ChinhPhuc room graph even
when uninitialized combat static classes leave the base lifecycle `UNKNOWN`.
Promotion to `BOSS_LOBBY` remains fail-closed: the room graph must be completely
clean and there must be no positive combat/transition signal or read error.

Source compatibility update `v1.0.6` corrects the Unity 6000.7.0a4
`Il2CppClass.static_fields` offset from the previous runtime's `+0xB8` to the
live-verified `+0x98`. A bounded read of the exact `ManagerQuangTruong`,
`ManagerRoom`, and `WsRoomService` class headers showed valid static blocks and
matching class-owned singleton instances at `+0x98`, while `+0xB8` was null for
all three. A live read-only probe then resolved `BOSS_LOBBY`, target `1289 /
Starburst`, and room `Coop_788342`. Full regression remains **759/759 PASS**.

Source compatibility update `v1.0.7` fixes the first 1.7.4 Start failure. Run
`3c530ea44f2a442888181f588b83af8a` stopped with
`ATTACK_CARD_TOGGLE_UNPROVEN` before sending any input: memory proved the
Attack card selected, but the 1280x720 artifact contained a centered
1280x640 game viewport and the old fixed ROI was 64 pixels to the right of the
live card. Desktop Start now prepares the native 1280x640 client. The first
compatibility implementation reused that height-scaled, left-anchored UI
canvas for every control; later combat evidence showed that Board `DotsArea`
uses a separate full-width layout (see `v1.0.9` below). The saved pre-fix frame proves Attack at 0.970
confidence and Start at 0.907 without input. Compileall and the full source
suite pass **765/765**.

Source compatibility update `v1.0.8` fixes the next live boundary. Entry run
`e1b6c5bd0ef04f3ca5e6cf23c397601e` successfully clicked Start and observed
match `M_b727b2f1`, MatchHost `RUNNING`, a live rig, complete 64-cell snapshots,
a ready Board and consistent Board/Active/ManagerMatch ownership. The updated
game nevertheless kept the verified `HubSuspendManager.IsSuspended@static+0x08`
and `ManagerMatch.isBossBattle@+0x138` fields false. The former old polarity
gate held lifecycle at UNKNOWN and caused `ENTRY_TIMEOUT_NEW_SESSION` with zero
gameplay inputs. Hub state is now required to be readable but either polarity
is valid; all stronger local-rig, scene, ownership, match, Board-ready and
non-terminal gates remain mandatory. Full regression passes **766/766**.

Source compatibility update `v1.0.9` fixes the first live combat-input failure
on 1.7.4. Run `d103ea509fb740b188df524283e61224` read a complete authoritative
opening board and correctly selected `(screen row 0, col 7) <-> (row 1, col 7)`,
which produces a three-Shield match across top-row columns 5..7. The emitted
plan nevertheless used client `x=732`; the saved 1280x640 opening frame places
column 7 near `x=815`, so the click landed around column 5 and appeared as a
non-match. This disproves applying the left-anchored card/UI canvas transform
to the Board: the combat `DotsArea` separately preserves the complete client
width. Board input now leaves normalized x coordinates unchanged and maps the
same move to client `x=823`; card, lobby, recovery and postmatch controls keep
their evidenced height-scaled, left-anchored UI transform.
Regression coverage locks this evidence and the full suite passes **767/767**.
One live retry remains required before declaring 1.7.4 gameplay accepted.

Source compatibility update `v1.0.10` completes the Board calibration after
FarmRun `2c55da2623874fda9f95b3eea0e6b742`. That retry was launched by the
already-running pre-fix Python process, so it still emitted selected move
`(row 6,col 5)<->(row 7,col 5)` at client `(638,371)<->(638,417)`. The saved
opening frame proves the actual centres near `(714,406)<->(714,456)` and exact
grid boundaries `x=438..840`, `y=79..481`. The input therefore missed both
intended cells; no server response or durable local move sequence followed,
and the eventual boss turn does not prove acceptance. There is no clean
evidence that the normal 0.25-second click gap was too short, so pacing is not
changed speculatively. Production Board calibration is now
`first=(.3620,.1625)`, `step=(.0393,.0787)`: the same lower-board move maps to
`(714,405)<->(714,455)`, and the earlier rightmost-column move maps to `x=814`.
Card/lobby/modal calibration remains unchanged. Full regression passes
**768/768**; a genuinely restarted `v1.0.10` live retry is pending.

Source compatibility update `v1.0.11` analyzes that clean retry, FarmRun
`8a57d4f5b6ec4a37bd45504e841574a0`. The opening memory board and saved frame
agree exactly: `(row 2,col 0)<->(row 2,col 1)` moves the visible Sword left to
make the three-Sword column, and emitted client points
`(462,204)<->(513,204)` are the centres of those two tiles. Nevertheless no
durable local move sequence or attributable server acknowledgement followed;
`MATCH_AFK_WARN idle_count=1` proves the game counted the turn as idle. This
rules out solver legality and board calibration for this failure. The normal
input path now lets Unity sample each cursor position for 60 ms, holds each
mouse-down for 75 ms, and separates the two taps by 350 ms. The complete pair
still finishes in well under one second, retains all foreground/window/PID
revalidation, and logs every timing used. A new-process live retry is required.

Source compatibility update `v1.0.12` analyzes the clean restarted retry,
FarmRun `4966336390a74090807f5d28c942a6b1`. The first move and ten further
SWAPs produced durable attributable acknowledgements; the match ended as a
STRONG/CONSISTENT WIN with boss HP zero. The controller then safe-stopped with
`POSTMATCH_UI_AMBIGUOUS` and sent no postmatch input. Its final frame proves
that current 1.7.4 uses a wide orange result banner and one centered blue
`Dong y` control rather than the legacy large-blue-panel/orange-button layout.

The new locator grants a point only when both current-layout anchors are unique
and present together; the legacy locator remains available. FarmRunner still
independently requires authoritative `POSTMATCH`, three stable samples, a final
provider poll, and foreground/focus proof before ordinary input. Exact replay
finds normalized point `(0.5, 0.90078125)` with zero three-frame drift. Offline
verification is **770/770 PASS** with compileall and diff checks clean. A newly
started `v1.0.12` process is required for live confirmation.

Source compatibility update `v1.0.13` analyzes the five-win completion run
`76fc70afe4fe42d4880d0421099942b6`. That run closes the current postmatch
boundary: all five result overlays were confirmed and the farm reached its
exact target. It also exposes one independent combat-card coordinate defect.
Memory correctly proved Attack card ID `4`, cost `160`, slot `1/2`, interactable
and affordable; policy emitted nine CAST actions, including low-boss-HP
`STEP_3_FINISH_CAST` at boss HP `14163` and `22350`. None was accepted.

The logged Attack point was normalized `x=0.470222`, which is the visible
Fusion card centre in the saved 1280x640 opening frame. The Attack card is at
the full-viewport slot-1 centre `x=0.529`. Mana repeatedly fell by exactly 160,
and the final wrong-card activation increased max HP `83371 -> 105214` and max
Mana `1579 -> 1757`, proving that CAST input had activated Fusion instead.
The slot calculation was correct; applying the separate left-anchored 16:9
lobby transform a second time moved slot 1 onto slot 0.

Combat-card visual validation and click points now use the complete active
viewport in both native and letterboxed 2:1 modes. Lobby, recovery and legacy
modal mappings are unchanged, as are Board coordinates. The native 1280x640
two-slot regression now locks Fusion at `x=0.471` and Attack at `x=0.529`.
Offline verification remains **770/770 PASS** with compileall and diff checks
clean. Live acceptance remains required for one attributable EVOLVE attempt
and one attributable CAST acceptance from a newly started `v1.0.13` process.

Source compatibility update `v1.0.14` analyzes run
`30d14369ec9e4bd3aab1f6c7df9e685e`. The selected Attack card was proven in
the exact boss lobby and visible in combat, but every local policy state had
`cardCount=0`; therefore the low-HP finisher correctly skipped EVOLVE yet could
not authorize CAST. The run's single PASS at turn 33 was unrelated: policy saw
one Sword-5 move that would leave a known Sword-6 reply for the boss, deferred
it under the accepted unique-adverse-Sword rule, then took Sword-6 after the
board changed on turn 35.

Redux metadata reconfirms `Board.cardsInHand +0x320` and the CardUI ownership
fields. A read-only post-run audit proved the discovery gap: the two anchored
GameObjects occupied 0.273 MiB of direct `VirtualQueryEx` regions, while two
exact-class CardUI objects were in other regions of the same 6.117 MiB
`AllocationBase`. The provider now retains AllocationBase and scans only the
complete current cards-in-hand allocation, capped at 16 MiB. Full CardUI class,
current Board/Active ownership, Unity native/Button, CardData and interactable
validation remain mandatory; stale postmatch objects still reject. Offline
verification is **774/774 PASS**. Live acceptance still requires one
attributable EVOLVE and one accepted CAST from a newly started `v1.0.14`
process.

Phase 2F.1 adds the canonical Windows x64 portable one-folder package. Final
build `v1.0.0+15` uses PyInstaller 6.22.0, starts through the windowed frozen
entry point, requires neither Python nor the source repository at runtime, and
writes preferences/logs/checkpoints/locks only below one local app-data root.
The deterministic ZIP SHA-256 is
`b8aed614f43d3550ef1d8dd6d88d3d3dbdb76547f63d5b9b4144bca89f5e1d05`.

Clean staging outside the repository, different CWD, missing `PYTHONPATH`,
fresh app data, production-graph self-check and actual game-absent startup all
pass. Packaged read-only attach sends zero input. B4 FarmRun
`add073d8cbdb4fcb9a660964fb35ec11` completed exactly one
STRONG/CONSISTENT WIN after one correctly excluded dead-board technical abort
and exact-pet recovery; it created no attempt after target. B5 FarmRun
`6b89455c91ef434594f42f1febdeb905` accepted the UI graceful-stop command
during `ACTIVE_COMBAT`, completed one STRONG/CONSISTENT WIN, created no next
attempt, and stopped at exact `BOSS_LOBBY`. Build `+15` fixes the presentation
label so durable graceful-stop history does not leave the inactive button
showing `Stopping...` after controller STOPPED.

Write audit proves zero writes to `D:\pc`, zero writes to the source repository
during packaged execution and zero writes beside the packaged EXE. Packaged
checkpoint discovery uses the unchanged canonical validator. Final offline
baseline is **740/740 PASS** with compileall and diff check clean. Evidence:
[Phase 2F.1 report](phase2f1_report.md) and
[runbook](phase2f1_runbook.md).

Phase 2E.3 completes the compact Desktop UI and its finite UI-controlled
FarmRunner. Start, Stop After Current Match, Emergency Stop and durable lobby
checkpoint Resume share one generation-bound controller owner. Preferences
never auto-start or auto-resume. Accepted configuration is immutable while a
run is active, the verified game PID is foregrounded and normalized before
input, operator logging is bounded, and UI shutdown drains its single poller.

Start/Resume still requires an exact `CHINH_PHUC_ROOM` and pins that room's
positive runtime `enemyPetId` only for the farm session. A proven ejection or
technical incident may re-enter only that exact pet. Each independently proven
incident receives a fresh one-shot recovery coordinator; there is no
farm-lifetime recovery ceiling. Ambiguous room/map ownership, stale state or a
failed recovery still stops fail-closed. The pin is cleared when the controller
ends, and the tool does not navigate from the general lobby through islands.

Final B6 FarmRun `3aa7b7e1279a4c91a03c2f72dd9d48c4` completed exactly
25 evidence-backed results in 27 attempts: 25 WIN, 0 LOSS, 0 UNKNOWN, 25
STRONG/CONSISTENT terminals, and two independent dead-board technical aborts
whose exact-Starburst `1289` recoveries succeeded. Attempt 27 produced the 25th
completion and no attempt 28 was created. The run ended
`FARM_TARGET_COMPLETED` at `BOSS_LOBBY`. After idle UI close, the summary proved
one poller, one maximum controller, 67/500 operator-log entries, zero UI/thread
errors, a stopped poller/process and the game process still alive. Evidence:
[Phase 2E.3 report](phase2e3_report.md) and
[runbook](phase2e3_runbook.md).

The accepted Phase 2E.2 and Phase 2E.1 foundations remain documented in their
respective reports. There is still no hidden start-on-launch behavior.

Phase 2D.6 accepted graceful stop, durable checkpoint/resume, and a 25-match
bounded soak. B1 artifact
`logs/farm_runs/dded65a91c9d4955b9614a1b61f40904/` proves F6 during
`ACTIVE_COMBAT` drained one STRONG/consistent WIN through postmatch to exact
`BOSS_LOBBY`, with zero entry after the request. Final invariant
`PHASE2D6_GRACEFUL_STOP_PROVEN`.

B2 Run A `dc1d191f369449deb422f1b3c7cc209b` stopped gracefully after two
completed WINs. Explicit resume `7afb954b302a4bdab59ff488bb56317f`
continued the historical accounting to 5/5 WINs, including one natural
dead-board technical abort/recovery that was not counted as completion. There
were no duplicate MatchIds or result counts. Final invariant
`PHASE2D6_CHECKPOINT_RESUME_PROVEN`.

B3 artifact `logs/farm_runs/6f8d890137604098b6ff4a066a20d4ec/`
completed exactly 25/25 unique matches in 25 attempts: 24 WIN, 1 LOSS, 0
UNKNOWN, 25/25 consistent memory/UI results, 0 technical aborts/recoveries,
and every safety counter zero. It returned to exact `BOSS_LOBBY`, stopped with
`FARM_TARGET_COMPLETED`, and created no attempt 26. Final invariant
`PHASE2D6_LONG_SOAK_PROVEN`. Evidence: [Phase 2D.6 report](phase2d6_report.md)
and [runbook](phase2d6_runbook.md).

Phase 2D.5 accepted both required live boundaries. Stage B1 artifact
`logs/farm_runs/4f1608ed395e44e8886244587a5bb9b0/` proves a frozen,
memory/lifecycle-backed terminal WIN before Board/Active ownership cleanup:
MatchId `M_d8d290a1`, local HP `64900/105228`, boss HP `0/84180`, confidence
STRONG, and a consistent `Thắng -> WIN` UI audit. It completed exactly one
match and stopped at the exact boss lobby before entry #2. Final invariant
`PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN`.

Stage B2 artifact
`logs/farm_runs/b63cd48b836c4aa6bb8f7092c06776aa/` proves the extended
bounded configuration `target_completed_matches=10`,
`max_technical_recoveries=2`, `max_match_attempts=14`. It used 10 attempts to
complete 10 unique matches: 10 STRONG memory WINs, 0 losses, 0 unknowns, and
10 consistent WIN UI audits. It returned to the exact boss lobby, stopped with
`FARM_TARGET_COMPLETED`, and reserved no entry #11. Technical aborts,
recoveries, result conflicts, input-after-stop, and every farm safety counter
were zero. Final invariant `PHASE2D5_EXTENDED_SOAK_PROVEN`. Natural technical
failure was `NOT_OBSERVED`; Phase 2D.4 remains the live recovery-resume proof.
Evidence: [Phase 2D.5 report](phase2d5_report.md).

Phase 2D.4 accepted both required live boundaries. Stage B1 artifact
`logs/farm_runs/fc396e1d55dc455390e752e57eb927b2/` proves one TEST_ONLY
technical recovery followed by a distinct current session, hardened fresh
opening, full-state/policy recomputation, one safe SWAP, exact ACK, and stop.
Final invariant `PHASE2D4_RECOVERY_RESUME_PROVEN`; failed MatchId
`M_a62e5f2f`, recovered MatchId `M_c52277e6`.

Stage B2 artifact
`logs/farm_runs/8a5ad3f5d02b4871b0baf1a22935a422/` proves bounded continuous farming with
limits `target_completed_matches=3`, `max_technical_recoveries=1`, and
`max_match_attempts=5`. It completed three unique matches, performed three
normal postmatch confirmations, returned to exact BOSS_LOBBY, and stopped with
`FARM_TARGET_COMPLETED` before entry #4. All farm safety counters are zero;
final invariant `PHASE2D4_BOUNDED_FARM_PROVEN`. Natural technical failure was
`NOT_OBSERVED`. Evidence: [Phase 2D.4 report](phase2d4_report.md).

The immutable B2 artifact's raw outcome subtype is `UNKNOWN/0 wins/0 losses`
because the provider cleared Board/Active ownership before publishing terminal
PlayerStats. All three stable result frames show `THẮNG` and boss HP 0, so the
audited result is 3 wins/0 losses alongside authoritative normal POSTMATCH
completion. Terminal PlayerStats are now captured before lifecycle cleanup;
missing evidence still fails closed to UNKNOWN. Phase 2D.5 subsequently
live-proved the correction in B1 and all ten B2 matches; this paragraph remains
the historical explanation for the immutable Phase 2D.4 artifact.

Phase 2D.3 accepted artifact `logs/technical_recovery/20260815_232743_777/`
proves one bounded automatic technical-recovery boundary: explicit TEST_ONLY
ACTIVE trigger, immediate gameplay lock, exactly one `<<`, exactly one stable
leave-modal `Đồng ý`, exact BOSS_LOBBY, old-session invalidation, exact
Starburst 1289, exactly one re-entry, a different MatchId/session/Board/epoch,
fresh MATCH_START opening 64/64, then hard stop before gameplay. Final invariant
`PHASE2D3_RECOVERY_BOUNDARY_PROVEN`; all gameplay, duplicate, wrong-target,
wrong-UI, and stale-session safety counters are zero. Production
`SEQUENCE_DESYNC` and exact zero-legal dead-board signals dispatch through the
same coordinator in captured replay/offline integration. Naturally occurring
live technical failure remains `NOT_OBSERVED`. Evidence:
[Phase 2D.3 report](phase2d3_report.md).

Phase 2D.2 attempt 3 (`20260815_203412`) structurally completed two entries and
one autonomous combat, but is **not live-accepted**. The user disclosed after
the run that they manually clicked `Đồng ý` on the result modal. Thus the logged
three-second `POSTMATCH -> LOBBY` transition is not an automatic-return proof.
The combat/session/input boundaries remain valid—entry inputs 2, sessions seen
2, sessions played 1, combat-2 inputs 0, and all recorded safety counters 0—but
postmatch ownership still needs a no-user-input retry. Evidence:
[Phase 2D.2 report](phase2d2_report.md).

Attempt 4 (`20260815_204412`) supplied that missing observation: with no user
input, authoritative POSTMATCH and the result modal persisted for 60 seconds.
Two captures prove the same WIN panel and sole `Đồng ý` control. A fail-closed,
resolution-independent locator and single-use `POSTMATCH_UI` capability are now
implemented offline; both real frames resolve the same normalized point with
confidence 0.98 and zero drift. This one-click path was subsequently
live-accepted by attempt 5.

Attempt 5 (`20260815_205707`) is the accepted Phase 2D.2 run. With no user
interaction, it completed combat #1, proved authoritative POSTMATCH across
three stable result frames, sent exactly one capability-owned `Đồng ý` click,
reacquired exact stable BOSS_LOBBY, entered a distinct session #2, and
hard-stopped at opening #2. Final invariant:
`accepted=true / PHASE2D2_BOUNDARY_PROVEN`; all safety counters and combat-2
inputs were zero. Evidence: [Phase 2D.2 report](phase2d2_report.md).

Post-acceptance, `--run-single-cycle` was added for the user's requested visible
demonstration: entry #1 -> one B5 combat -> exact returned BOSS_LOBBY -> hard
stop, with no entry #2 capability. First live attempt `20260815_213316`
safe-stopped after three acknowledged SWAPs because a pre-PASS SWAP reset proof
was incorrectly reused after PASS #1; the server correctly reported 2/3 while
the controller expected 1/3. No wrong-turn, duplicate, stale, foreground, or
post-combat input occurred. The reset correlation now requires the consuming
action's source turn to be strictly after the last confirmed PASS.

The user then explicitly approved reducing the local-turn deadline warning to
an inclusive one-second actionability floor. The controller may send at a
displayed `1` after its ordinary fresh preflight, and fail-closes at `0`.

The requested visible demonstration then passed on artifact
`logs/boss_farm_cycle/20260815_214234/`. The controller entered Starburst 1289,
completed one full B5 match, captured a visible `THẮNG` result with boss HP
`0/84180`, sent exactly one proven `Đồng ý` click, reacquired exact stable
BOSS_LOBBY, and hard-stopped without entry #2. Final invariant:
`accepted=true / SINGLE_CYCLE_RETURNED_LOBBY_PROVEN`; every farm safety counter
was zero.

## Current Architecture

```text
Pokiguard.exe
  -> ReadProcessMemory (external/read only)
  -> MemoryBoardStateProvider
  -> GameState
  -> deterministic board simulator / BASIC PolicyEngine
  -> ActionabilityGate + session/sequence/input guards
  -> normal foreground Windows UI/input
```

Farm-side accepted entry:

```text
Boss lobby
  -> exact target resolution
  -> one normal foreground Windows UI entry click
  -> new MatchId / CombatSessionKey
  -> accepted opening board + first local turn
  -> STOP
```

CV remains audit/reference/fallback, not the production board source. No
production path writes game memory, calls gameplay IL2CPP methods, or
manipulates network traffic.

## Production Board Source

Primary production source:

```text
WsCombatBatch.board / BoardCellDTO
```

Post-opening publication is current-session and highest-valid-ACK attested.
The opening-only bootstrap may use exact current-match
`ChatMessageDTO.MATCH_START.matchPayload.board`; it must still be 64/64,
stable twice, session-bound, first-local-turn state with local move sequence
zero. Normal post-opening ACK rules remain unchanged.

Accepted contract:

- exact 8x8, 64/64 cells, and 64 unique coordinates in `0..7 x 0..7`;
- exact known `GemType`; multiplier x1, x2, x3, or x4;
- valid `srvSeq` and SHA-256 `boardHash`;
- current session, latest state, lifecycle, render/stability, and ACK/opening
  validation;
- invalid/ambiguous/stale/incomplete/unknown state fails closed.

Phase 2E.3 B6 retries exposed a remaining post-opening gap when Unity reclaims
the current `WsCombatBatch`/transport DTO after its durable ACK becomes visible
but before the external poll captures it. `Board.allDots` cannot close this gap
directly: Cpp2IL proves that its elements are `GameObject` references, not
`Dot` component pointers, and the external `GameObject -> Dot` traversal is
still UNKNOWN. The rejected experimental `GameObject + 0x48` path was removed;
it never resolved a live Dot and had no valid layout evidence. DTO remains the
only production board source. CV remains audit/reference, not production. See
[Phase 2B.5](phase2b5_report.md) for the accepted DTO-only boundary.

## Coordinate Model

All cells use zero-based `(row, col)`:

| Space | Meaning |
|---|---|
| Runtime/DTO | Bottom-origin row; column unchanged. |
| Provider `BoardState` | Top-origin visible-board row. |
| Solver | Same top-origin coordinates as provider. |
| Screen/click | Same cell coordinates as solver, then current client geometry. |

```text
providerRow = solverRow = screenRow = 7 - runtimeRow
providerCol = solverCol = screenCol = runtimeCol
```

`live_state.to_board_state()` flips the row once before solver publication.
Provider-to-solver and solver-to-screen are identity mappings. Never flip again
at the input boundary; tests cover this no-double-flip contract.

## Current GameState

Production state currently resolves/carries:

- **Board:** `GemType`, multiplier, `srvSeq`, `boardHash`, production/stable/
  latest/ACK flags, readiness, cascade/presentation/current state, modal/end
  flags, `Board.Instance`, and session key.
- **Battle:** `MatchId`, `CombatSessionKey`, turn/current player, local username,
  first local turn, server-tick timer/duration, lifecycle, connection/reconnect/
  resync, and local/last move sequence telemetry.
- **Player/boss:** ownership, HP/maxHP, Mana/maxMana, Rage/Power/max, Shield.
- **Cards:** dynamic object/data/card identity, type, current cost from
  `manaCost` or positive `conditionUse`, interactable, pending/use/cooldown/
  last-turn state. Observed ATTACK ID `4` is not hard-coded.
- **Fusion:** enabled/available/used/locked, current runtime cost/UI, last
  attempt, correlated response success/failure, and durable success state.
- **Idle/PASS:** exact authoritative payload values, freshness/correlation, and
  accepted reset-baseline provenance; never a local gameplay counter.
- **Sequence desync:** a sticky, session-scoped `SequenceDesyncState` guard
  accompanies `GameState`; it is not inferred from board motion or repaired.

See [state.py](../src/pokiguard_v2/state.py),
[Phase 2C.2C](phase2c2c_report.md), and
[sequence-desync resolution](sequence_desync_resolution.md).

## Combat Lifecycle

Exact `CombatLifecycleState` members:

```text
LOBBY | ENTERING | ACTIVE | LEAVING | POSTMATCH | STALE_SERVER_MATCH | UNKNOWN
```

Boss-entry external classifications are `BOSS_LOBBY`, `LOBBY_OTHER`,
`ENTERING_COMBAT`, `ACTIVE_COMBAT`, `POSTMATCH`, and `UNKNOWN`.

A server match ID alone does not prove local/actionable combat. `ACTIVE`
requires local rig, loader/Hub, Board/Active/ManagerMatch ownership, match ID,
board readiness, and non-terminal flags to agree. Stale/hidden server state is
`STALE_SERVER_MATCH` and fails closed; local lifecycle wins for UI safety.
Leaving `ACTIVE` invalidates session-scoped board/action/idle/desync/card/Fusion
caches. See [combat lifecycle resolution](combat_lifecycle_resolution.md).

## Actionability

Every gameplay input requires:

- exact `ACTIVE` lifecycle and current matching session;
- production board current/stable/ready and ACK/opening-authoritative;
- no cascade, presentation, turn-resolution, or known modal state;
- exact local turn, player/boss known and alive, no end state;
- ready connection, no reconnect/resync, and no terminal sequence desync;
- known timer above configured safety margin;
- bound Pokiguard window valid, unchanged, and foreground;
- no pending input/action lock or controller pause;
- fresh proposal still matching session, turn, `srvSeq`, hash, critical state,
  and recomputed policy immediately before input.

Unknown required state fails closed. Generic unrelated Unity modal traversal is
still UNKNOWN; known Board modal/action/end flags are the accepted gate. See
[actionability signals](actionability_signals.md).

## Autonomous Gameplay Currently Proven

### SWAP — PRODUCTION ACCEPTED

- Normal Windows two-click input on validated adjacent screen cells.
- Full foreground/state revalidation, single-use identity, and ACK/current-state
  synchronization.
- Bounded, multi-turn, and full-match acceptance; accepted runs have no known
  duplicate, stale, wrong-turn, boss-turn, lobby, or post-combat input issue.

### EVOLVE — PRODUCTION ACCEPTED within BASIC combat

- Dynamic live Fusion control and actual positive runtime cost.
- Live control discovery first scans only the allocation regions anchored by
  the current `Board.cardsInHand` GameObjects. Cpp2IL proves that
  `FusionCardUI.Spawn`'s returned GameObject is appended to this list. Region
  membership is discovery evidence only; the exact `FusionCardUI` class,
  native object and live Button must still validate before input.
- Functional and non-turn-consuming.
- `success=false` may retry only under fresh-state/lock/response safety.
- `success=true` requires durable `fusion.used=true`, then full reread; a
  consuming action may still occur on the same turn.
- Terminal success/failure may lead to an `EVOLVE-only turn` with zero further
  input when policy would otherwise PASS.

EVOLVE idle-reset semantics: **UNKNOWN**.

Phase 2E.3 B6 retry 31 exposed a discovery regression rather than an evolution
failure: Mana reached 175/280/385, but no EVOLVE input was sent. At turns with
six seconds left the inclusive ten-second EVOLVE response/follow-up floor
correctly deferred the action; at the ten-second opportunity the rotating
extended scan had not found a current `FusionCardUI`
(`cachedFusionUiAddresses=0`). The new cards-in-hand owner-anchor discovery is
offline-tested and still requires a fresh live EVOLVE observation before B6
can continue.

### CAST — PRODUCTION ACCEPTED

- Dynamic current ATTACK card; no hard-coded card ID.
- Actual cost comes from runtime data; accepted runs observed 160.
- Consumes the turn and locks out same-turn SWAP after acceptance.
- Card/mana/turn transition can prove acceptance if transient DTO is missed.

CAST idle-reset semantics for production PASS: **UNKNOWN**.

### PASS — PRODUCTION ACCEPTED, authoritative and bounded

- PASS sends **zero gameplay input**.
- Numeric state comes only from exact local-user server payloads.
- Live acceptance observed `1/3` and `2/3`; first local turn cannot PASS.
- At `2/3`, third PASS is prohibited and the next successful action must
  consume the turn; EVOLVE alone is insufficient.
- Accepted controlled cycle: `1/3 -> 2/3 -> mandatory SWAP -> 1/3`.
- No local `idle_count += 1`, decrement, or synthetic zero.
- UNKNOWN/stale/missing/rejected/uncorrelated evidence fails closed.

SWAP reset is production-proven. CAST and EVOLVE resets remain UNKNOWN. B5's
accepted natural full match contained no PASS (`NOT_OBSERVED` cycle coverage);
B3 and Phase 2C.2C supply accepted autonomous PASS evidence.

## BASIC Policy

```text
PlayStyle:    SIMPLE | CAREFUL
ManaPriority: EVOLUTION | ATTACK
Intelligence: BASIC | REASONING
```

`BASIC` is implemented/accepted. `REASONING` is represented but intentionally
undefined/not implemented; it returns `NONE / REASONING_NOT_IMPLEMENTED`.
Never invent REASONING behavior. See [BASIC policy](basic_gameplay_policy.md).
Its old PASS-disabled/undefined-fallback notes are superseded by
[Phase 2C.2C](phase2c2c_report.md) and the latest
[Phase 2C.2B/B5 report](phase2c2b_report.md).

## BASIC Resource Rules Currently Accepted

1. EVOLVE first only for `ManaPriority=EVOLUTION` when an evolution pet and
   current live Fusion slot are proven, the action is eligible/affordable, the
   inclusive EVOLVE time floor is met, and low-boss-HP mode is inactive.
   `ATTACK` priority, no selected evolution pet, or boss HP at/below the
   enabled low-HP threshold disables EVOLVE without stopping board play.
2. Sword is highest. A non-Sword direct match may win when its deterministic
   cascade collects the better Sword result.
3. At/below the configurable boss-HP threshold (default 30,000), after Sword:
   use an affordable proven Attack card, otherwise prefer safe Mana. Outside
   that mode, safe Rage has tactical priority below 100; otherwise safe Mana.
4. Safe Health: boss HP >50%, own HP <30% (`SIMPLE`) or <50% (`CAREFUL`).
5. Normal CAST requires player Mana strictly >480 and a usable dynamic ATTACK
   card, preserving 320 after observed cost 160. Low-boss-HP mode explicitly
   allows an affordable CAST without that stockpile threshold. No equipped or
   proven live Attack card disables CAST only; board policy continues.
6. Safe Drain: boss Mana >160 and Rage >100. Safe Shield: both <50.
   Intermediate handling prefers safe Shield. Only-safe Drain and Health-only
   safe fallback are accepted special cases.
7. After explicit branches, use deterministic minimum-risk safe-resource
   fallback. Safe Rage remains useful while below max 250 even when >=100.
8. A full resource has no value solely for filling itself; Sword/cascade/combo,
   another resource, safety, or mandatory action may still justify the move.
9. PASS only when no Sword-safe move remains and authoritative state permits.
   Mandatory state uses a normal safe consuming action or deterministic
   least-dangerous legal action.

Canonical intent: [DECISIONS.md](DECISIONS.md). Exact ranking/trace:
[basic_policy.py](../src/pokiguard_v2/basic_policy.py).

## Board Simulator

- Exhaustive 112 adjacent pairs: 56 horizontal + 56 vertical.
- Separates legal, safe, and dangerous moves.
- Resolves direct matches, known gravity, and deterministic known cascades from
  the current 64 cells; preserves x1-x4 multiplier with each gem.
- Off-board refill is `UNKNOWN` and earns no deterministic cascade credit.
- Records resources, Sword potential/risk, collapse/support hazard, UNKNOWN
  exposure, and deterministic tie-breaks.

## Dead Board

Not `policy returned NONE`; not `safeMoveCount=0`. Definition:

```text
ACTIVE/current/stable local-turn 64-cell board
AND board ready / no cascade
AND exhaustive legalMatchProducingMoves == 0
```

Missing gates yield UNKNOWN. `legal>0, safe=0` is live but dangerous. Exact dead
board now dispatches the bounded Phase 2D.3 technical-recovery coordinator;
`POLICY_NO_SAFE_MOVE` explicitly does not. The deterministic zero-legal path is
offline-accepted, while natural zero-legal runtime evidence remains
`NOT_OBSERVED`. See [dead-board resolution](dead_board_resolution.md) and the
[Phase 2D.3 report](phase2d3_report.md).

## Sequence Desync

Accepted sources: `FORCE_RESYNC`, structured sequence-gap/duplicate reject, and
`ChatMessageDTO.rejectReason` where applicable (structured payload code wins).

```text
SEQUENCE_DESYNC
-> terminal for current session
-> all gameplay actions blocked
-> pending identity consumed; no retry
-> no idle-state mutation
```

Only proven old-session end plus a different clean session clears it. Never
repair sequence via memory/network/direct call/forged ACK/local counter. See
[sequence-desync resolution](sequence_desync_resolution.md).

## Safe UI Recovery

Accepted normal Windows UI flow:

```text
ACTIVE combat -> << -> confirmation modal -> Đồng ý -> POSTMATCH -> LOBBY
```

Locator and single-step clicks are implemented. Manual F10-confirmed recovery
remains **PASS**. Phase 2D.3 additionally live-accepts one coordinator-owned
automatic recovery for exact technical triggers, with foreground revalidation,
single-use input permits, exact lobby/target re-entry, fresh opening proof, and
a hard stop before recovered-combat gameplay. See
[safe UI recovery](safe_ui_recovery.md) and the
[Phase 2D.3 report](phase2d3_report.md).

## Boss Entry

Phase 2D.1: **PASS STRONG**. Current accepted target:

```text
Starburst
ID = 1289
```

Architecture remains target-configurable; source does not hard-code this
target, and CLI must receive exact ID/name.

```text
BOSS_LOBBY -> exact target -> one normal UI entry
-> new MatchId/session -> opening 64/64 -> first local turn -> STOP
```

Accepted evidence: wrong clicks 0, duplicate clicks 0, stale-session confusion
0, gameplay inputs after entry 0; foreground loss failed closed with zero input.
Stop was `NEW_COMBAT_OPENING_READY`. See [Phase 2D.1](phase2d1_report.md).
The separate WorldBoss-card path remains enumeration/read-only; live rect/
selection calibration is not accepted.

## Bounded Farm Runner

Phase 2D.6: **PASS STRONG**. The production runner owns the complete bounded
state machine, explicit operator-control axis, durable historical checkpoint,
and the single automation-controller lease:

```text
BOSS_LOBBY -> exact Starburst 1289 entry -> fresh opening -> full BASIC
-> normal POSTMATCH confirmation -> exact BOSS_LOBBY -> bounded next entry
```

Accepted Phase 2D.6 B3 bounds are exactly 25 completed matches, at most 3
technical recoveries, and at most 32 fresh match attempts. Progress is explicit
`FarmRun` state; it is not inferred from MatchId count. Each entry re-resolves
the target and requires a unique session plus hardened current 64/64 opening.
Target completion is checked after exact lobby reacquisition, before another
entry capability can be issued. The accepted run used exactly 25 attempts and
did not create entry/attempt 26.

Terminal classification is frozen before ownership cleanup in a session-bound
`TerminalCombatSnapshot`. Exact terminal winner/HP evidence is primary;
postmatch `Thắng`/`Thua` is a secondary consistency audit. Results are
WIN/LOSS/UNKNOWN with STRONG/PARTIAL/UNKNOWN provenance. Strong results cannot
be downgraded by later cleanup. Normal completion is counted exactly once;
technical aborts do not increment completion; UI/memory conflict safe-stops at
the lobby. Accepted B3 accounting is 24 wins, 1 loss, 0 unknowns, 25 unique
MatchIds, and 25/25 memory/UI consistency.

Production `SEQUENCE_DESYNC` and exact `DEAD_BOARD_NO_REFRESH` dispatch into
the same accepted recovery coordinator. Recovery immediately locks gameplay,
uses normal foreground exit/confirm/re-entry inputs, rejects failed-session
state, accepts only a distinct current session/opening, then rereads and
recomputes BASIC. Phase 2D.4 Stage B1 live-proves one accepted consuming action
after this handoff. Phase 2D.6 B2 naturally observed and recovered one dead
board; B3 had no natural technical failure.

F6 is the accepted edge-triggered graceful stop: it drains an active/in-flight
match and postmatch to exact boss lobby, then stops with a hard no-new-entry
gate. F9 terminally prevents future input and produces a non-resumable
emergency checkpoint. F7 is deliberately disabled; stale-safe farm-level
pause/resume has not been accepted.

Checkpoint schema `pokiguard.farm_checkpoint.v1` persists only durable history
with atomic temp/flush/fsync/replace writes. Explicit resume is accepted only
at freshly confirmed exact `BOSS_LOBBY` with identical target/limits. It never
restores Board/action/sequence/idle/UI runtime state or resumes an old combat.
Infinite farming, game launch/process restart, and automatic login are not
implemented. See [Phase 2D.6](phase2d6_report.md) and its
[runbook](phase2d6_runbook.md).

## Latest Accepted Milestones

- [Phase 2B.5](phase2b5_report.md) — memory board hardening: **PASS STRONG**.
- [Phase 2C.1](phase2c1_report.md) — single-step input: **PASS STRONG**.
- [Phase 2C.2C](phase2c2c_report.md) — authoritative PASS/reset cycle: **PASS**.
- [Phase 2C.2B B3/B5](phase2c2b_report.md) — full BASIC combat:
  **FULL_MATCH_PASS** (user-confirmed WIN).
- [Phase 2D.1](phase2d1_report.md) — one-shot boss entry: **PASS STRONG**.
- [Phase 2D.2](phase2d2_report.md) — **PASS STRONG**; accepted attempt 5
  autonomously completed one combat, confirmed the result, entered session #2,
  and hard-stopped before any combat-2 input.
- [Phase 2D.3](phase2d3_report.md) — **PASS STRONG**; one automatic technical
  recovery exits, reacquires the exact lobby/target, enters a fresh session,
  validates opening 64/64, and hard-stops with all safety counters zero.
- [Phase 2D.4](phase2d4_report.md) — **PASS STRONG**; live recovery resumes
  fresh BASIC gameplay, and a separate bounded run completes exactly three
  matches then stops at boss lobby before entry #4 with every safety counter
  zero.
- [Phase 2D.5](phase2d5_report.md) — **PASS STRONG**; B1 freezes a STRONG
  memory-backed WIN before ownership cleanup, and B2 completes exactly 10
  STRONG/consistent wins then stops at boss lobby before entry #11 with exact
  accounting and every safety counter zero.
- [Phase 2D.6](phase2d6_report.md) — **PASS STRONG**; F6 drains safely to
  lobby, explicit checkpoint resume preserves exact accounting, and B3
  completes 25/25 unique matches (24 WIN, 1 LOSS, 0 UNKNOWN) before entry #26
  with every safety counter zero.
- [Phase 2E.1](phase2e1_report.md) — **PASS STRONG**; read-only desktop UI and
  control-plane observer, with one poller, immutable snapshots, and clean close.
- [Phase 2E.2](phase2e2_report.md) — **PASS STRONG**; UI Start, graceful stop,
  emergency stop, durable resume, foreground handoff, and an exact 5-match
  bounded run passed live with no post-boundary input or extra entry.
- [Phase 2E.3](phase2e3_report.md) — **PASS STRONG**; compact operator UX,
  session-pinned exact-pet recovery, card/Fusion and latency hardening, two
  naturally recovered dead boards, and an exact 25/25 STRONG/CONSISTENT WIN
  UI soak with clean UI/poller shutdown.

Intermediate retries are historical evidence, not current phase status.

## Current Test Baseline

Verified on **2026-09-04**:

```text
python -m unittest discover -s tests -p 'test_*.py'
Ran 908 tests
OK
```

Current source baseline: **908/908 PASS**. The accepted packaged Phase 2F.2 RC
remains at its original **740/740 PASS** baseline. Phase 2E desktop/controller and terminal
hardening focused suites: **PASS**. `python -m compileall -q src tools tests`:
**PASS**. `git diff --check`: **PASS**. The suite additionally covers terminal
WIN/LOSS/UNKNOWN classification, frozen result survival after ownership
cleanup, UI/memory consistency and conflict, idempotent accounting, two
independent bounded recovery invocations, recovery-resume for captured sequence
desync and deterministic dead board, target/recovery/attempt hard boundaries,
session uniqueness, no entry after the configured target, input after stop,
single-use farm capabilities, exact hardened openings, graceful-stop lifecycle
races, F9 invalidation, checkpoint validation/atomicity/resume accounting,
optional/dynamic card layout, recovery ACK-epoch contamination, and the x64
working-set sampler ABI. Phase 2E.2 adds controller ownership/generation,
command gating, verified-PID foreground transfer, graceful and emergency stop
handoffs, exact resumable-checkpoint boundaries, and clean worker shutdown.
Phase 2F.1 adds source/frozen path abstraction, packaged checkpoint discovery,
frozen startup/single-instance behavior and production bundle/resource checks.

## Current Known Limitations

- The Phase 2E.3 UI intentionally exposes only finite target and attempt
  limits. Infinite/daemon operation, automatic game launch/login/process
  restart, target rotation, scheduling, and remote control are not implemented.
- Emergency Stop is terminal for the current UI controller generation. It can
  leave the game combat itself running; the user may finish/exit normally, but
  the stopped controller sends no further input and its checkpoint is not
  resumable.
- UI Resume accepts only a durable checkpoint at an exact boss-lobby boundary.
  Completed, emergency, malformed, stale, or mid-combat checkpoints remain
  disabled in the UI and are rejected again by the backend authority.
- Bounded continuous farming is accepted for 25 completed matches with an
  explicit match-attempt ceiling. Successful technical recovery has no
  farm-lifetime cap, but every proven incident still receives only one bounded
  Exit/Confirm/Re-entry coordinator. Infinite/daemon farming, game launch/login,
  automatic process restart and ambiguous retries are not accepted.
- Checkpoint resume is history/accounting continuation only and requires a
  freshly confirmed exact boss lobby. Mid-combat controller restart/resume and
  restoration of executable runtime state are not accepted.
- The result-modal `Đồng ý` requirement, exact locator, one-click normal-UI
  path, and resulting lobby transition are live-accepted for the proven modal.
- Phase 2E.3 B6 naturally recovered two exact dead boards. Session-scoped ACK
  isolation accepted both fresh recovered openings; an unexplained current-
  session ACK conflict still stops fail-closed. Automatic process restart
  remains out of scope.
- Terminal PlayerStats capture before cleanup is live accepted for all 25 B6
  matches: 25 STRONG WINs, all UI-consistent. UNKNOWN remains the fail-closed
  outcome when evidence disappears too early.
- The accepted B6 working-set sampler observed start/peak/end values of roughly
  52/106/106 MiB across 27 attempts, with no observed unbounded growth.
- Ordinary Attack/Fusion card layout is dynamic and accepted. A missing Attack
  card or evolution pet disables that card action only. Pet-specific skill-card
  click layout/use remains intentionally deferred.
- `REASONING` is undefined/not implemented.
- CAST reset **UNKNOWN**; EVOLVE reset **UNKNOWN**.
- B5 natural full-cycle PASS coverage `NOT_OBSERVED`; controlled 2C.2C proves
  the complete SWAP reset cycle, while B5 retry 2 proves its dangerous half.
- Natural live sequence desync remains `NOT_OBSERVED`; exact zero-legal dead
  board recovery is naturally observed in Phase 2D.6 B2. Generic unrelated
  modal traversal is **UNKNOWN**.
- Direct WorldBoss-card entry is not live-calibrated/accepted.
- Desktop Start/Resume remains current-room-only, but an active farm session may
  re-enter its exact pinned positive numeric pet ID from a proven settled world
  boss map. Each incident uses a fresh one-shot recovery coordinator;
  ambiguous target evidence or an already-sent recovery re-entry fails closed.
  The pin is cleared when the
  controller ends, so a later Start again requires an exact current boss room.

### Superseded Phase 2E.3 live-retry evidence

The following entries explain the defects found on the route to acceptance.
Their statements that another exact-25 run was required are superseded by the
accepted FarmRun documented in [Phase 2E.3 report](phase2e3_report.md).

- Phase 2E.3 B6 attempt `phase2e3_b6_25_match_soak_01` stopped safely after
  seven STRONG/CONSISTENT wins when attempt 8 lost combat ownership at turn 5
  and returned directly to `WORLD_BOSS_LIST`. The attempt had three local
  SWAP inputs, no terminal participants/HP/event/UI evidence, and therefore
  cannot be called a completed match. The discovered accounting bug that had
  promoted this lifecycle loss to completed `UNKNOWN` is fixed: both the
  combat-summary validator and `FarmRun.normal_combat_ended` now reject an
  evidence-free UNKNOWN terminal. Evidence-backed UNKNOWN captured before
  cleanup remains supported. B6 retry
  `b049492a1bf94becb8d974c3321041fd` then proved the guard: its second attempt
  was not counted when a mandatory idle-2 turn arrived with six seconds, the
  selected SWAP was sent promptly but never ACKed, and the room was lost. The
  new late-mandatory recovery dispatch and exact-pet ejection fallback are now
  covered offline. B6 run `7509b0e5526c41eeab443a9332f6a457` then provided
  live exact-pet re-entry evidence: attempt 4 lost its terminal evidence,
  settled at `WORLD_BOSS_LIST`, selected only pinned pet `1289` (`Starburst`),
  restored exact room `Coop_581981`, and entered attempt 5 without counting a
  completed UNKNOWN. The same run later hit a genuine
  `DEAD_BOARD_NO_REFRESH` on attempt 8. Recovery sent one `Exit + Confirm` and
  returned to the exact pinned room, but its internal ACK-epoch guard blocked
  before re-entry; the outer runner previously stopped because it accepted only
  a world-map fallback. It now also accepts this independently proven exact-room
  boundary, audits that no recovery re-entry/target-selection input was sent,
  discards all old combat state, consumes one bounded recovery, and uses the
  normal fresh-entry flow. Fresh retry `23389f2475ed4b9db3dea884dd3ee4e6`
  live-proved another exact `1289` map re-entry and then exposed a separate
  PASS-correlation bug at attempt 10: the server reported authoritative idle
  `1/3` before PASS and `2/3` after PASS, but the coordinator compared `2/3`
  with its local first-pass index and stopped. PASS confirmation now derives
  the expected transition from the exact game-owned idle-before value
  (`1 -> 2` here), falling back to the local bounded index only for an accepted
  non-numeric reset baseline. It still rejects stale, mismatched, threshold-3,
  and otherwise unproven observations. The next live retry
  `92a1d2643da34079b35d0709a822073c` completed one STRONG/CONSISTENT WIN, then
  exposed two independent input-boundary regressions on attempt 2. First,
  ejection re-entry stopped at `WORLD_BOSS_LIST` because the desktop UI owned
  foreground; re-entry now restores only the already bound exact-PID HWND and
  then reacquires all runtime/two-frame target evidence before its maximum-one
  normal click. Second, the resized `1181x617` game client inherited V1's
  `board_first_center_y=.146` / `board_step_y=.0725` calibration. The planned
  bottom-row `(7,2)<->(7,3)` was a real match on the authoritative board, but
  its physical y=402 landed at the row-6/row-7 boundary rather than the tile
  centre near y=426. Exact evidence was board hash unchanged, LocalSeqNum still
  zero and authoritative AFK advancing to 1/3 then 2/3. Desktop Start now
  restores the verified HWND/PID and normalizes the client to canonical
  `1280x720` before FarmRunner binds it; a live zero-input preflight changed
  PID 3504 from `1181x617@(717,206)` to `1280x720@(632,206)` while retaining
  the exact HWND/PID and foreground. A bare MatchService `_ackedSeqs` advance
  is no longer SWAP acceptance or idle-reset evidence: only the exact durable
  local move-sequence plus matching from/to coordinates can acknowledge a
  SWAP. Later B6 retries `_28`, `_29`, and `_30` all stopped safely with zero
  invented completion when Unity's short-lived transport DTO and
  `WsCombatBatch` were reclaimed after the durable ACK became visible. That
  transport gap remains unresolved; `Board.allDots` must not be treated as a
  `Dot[,]` or promoted into a production board without a proven component
  traversal. A fresh exact-25 B6 run is still required after the provider
  timing/current-DTO path is corrected.
- The first live EVOLVE regression retry after the Fusion owner-anchor change
  proved a separate timing defect: current `FusionCardUI` discovery did not
  start until local Mana reached the runtime cost. By turn 13 it had spent two
  owner-anchor attempts plus two extended scans (33,554,530 bytes) and still
  had no cached Fusion wrapper; zero EVOLVE inputs were sent. Discovery is now
  explicitly independent from Mana. Turn 1 remains reserved for the opening
  board/SWAP, while the first observed boss turn performs one full normal-region
  current-session CardUI/FusionCardUI warm-up and caches only exact validators.
  The first live warm-up retry then proved its board/CardUI half: turn 1 SWAP
  was acknowledged, and turn 2 performed a full normal scan at zero Mana which
  resolved all three equipped CardUI wrappers. It also exposed that the
  game-owned `FusionEnabled` flag is false before affordability, so using that
  flag as a discovery prerequisite still skipped FusionUI. `FusionEnabled` is
  now removed from discovery while remaining an EVOLVE action gate. Later
  retries remain bounded. This final adjustment is offline-tested but still
  requires a fresh live EVOLVE acceptance run.
- Phase 2E.3 B6 exact-25 retry `65095df6d2c24cd49274def942f39d83`
  exercised the production one-second inclusive action floor and the post-IDLE-2
  cached-board fast path. It completed three STRONG WIN results with 80
  gameplay inputs, including confirmed SWAP, EVOLVE success and accepted CAST,
  before attempt 4 stopped at `PASS_STATE_UNKNOWN`. Exact evidence showed a
  policy-selected zero-input PASS while the authoritative board/local turn and
  live boss remained current but the transient board-only stats fallback had
  no local `Player` object. The PASS preflight was abandoned, the server later
  emitted exact `MATCH_AFK_WARN 1/3`, and the next local turn could not bind
  that numeric result to an active PASS coordinator. The controller stopped
  fail-closed; the user then manually returned to the boss lobby. This was not
  an automatic recovery or game ejection.
- Farm-owned zero-input PASS tracking now tolerates only that exact stats-only
  gap: local player absent, boss present with positive HP, same ACTIVE local
  session, production-ready stable/ACK/latest board. It still sends no Windows
  input and lets authoritative AFK/lifecycle evidence determine the terminal
  result. As defense in depth, a remaining farm-owned `PASS_STATE_UNKNOWN`
  with a live bounded recovery dispatcher no longer auto-pauses immediately;
  it sends no input and waits for either authoritative state change or the
  existing terminal active-turn recovery gate. Standalone/no-recovery behavior
  remains fail-closed.
- Phase 2E.3 B6 exact-25 retry
  `dea1b8b2eb8e42b98616018dcd4133c6` completed 13/13
  STRONG/CONSISTENT WINs with 258 gameplay inputs and zero technical
  recoveries. Entry 14 then created exact session `M_31f7fb40`, but its
  short-lived `MATCH_START` opening DTO was reclaimed before the provider could
  publish a stable immutable opening. A later exact current-session
  `MATCH_MOVE_RES` board proved that the untouched combat had already advanced
  beyond turn 1 (`turn=3`, `LocalMoveSequence=0`, one entry click, zero gameplay
  inputs). The old entry boundary correctly refused to treat that later board
  as an opening, but stopped the whole run with `ENTRY_TIMEOUT_OPENING_BOARD`.
  The controller stopped at `11:57:11Z` while the combat remained active. At
  `11:57:23Z` the observer saw `LOBBY_OTHER` with no combat/room owner: the
  untouched match was ejected to the boss map after the controller had stopped.
  The user did not manually return to the lobby and no automatic recovery ran.
- That exact missed-opening case now routes to bounded technical recovery only
  when session/match ownership, one entry click, zero gameplay input, turn > 1,
  `firstLocalTurn=false`, `LocalMoveSequence=0`, positive `srvSeq`, board hash,
  and exact `ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board` source all agree.
  The route is immediate on that first proven advanced current board; it does
  not wait out the remaining opening timeout and abandon the game near the idle
  ejection boundary. It remains a technical abort, never a completed match,
  and the recovery path still revalidates the failed live session immediately
  before normal Exit UI input. Any mismatch remains fail-closed. Offline
  verification after the PASS and missed-opening fixes was 650 tests PASS and
  compileall clean.
- Phase 2E.3 B6 exact-25 retry
  `56c884d710e94dbaad8c0c6a3379c639` completed 11/11
  STRONG/CONSISTENT WINs with 229 gameplay inputs and zero technical aborts or
  recoveries. Attempt 11 sent exactly one audited `POSTMATCH_CONFIRM` only
  after memory proved WIN and the UI proved `Thắng`. The server then removed
  `WsRoomService.CurrentRoomId` while Unity continued rendering the exact
  Starburst/Ready room shell. Read-only evidence was lifecycle `LOBBY`, no
  combat owner, stale `RoomDTO.enemyPetId=1289`, exact clean runtime pet-button
  closure/PlayerPrefs for 1289, but `ManagerBoss=null`; the old lobby waiter
  discarded this as generic `LOBBY_OTHER` until `RETURN_LOBBY_TIMEOUT`.
  The detached-shell locator already existed, but its atomic gate incorrectly
  required the mutually exclusive `WORLD_BOSS_LIST` branch. The waiter now
  surfaces only a stable exact-pet detached-shell candidate after the existing
  room-rehydration grace. Re-entry still requires the current pinned positive
  pet ID, no combat owner, exact read-only Button/cached-group/PlayerPrefs
  association, and two stable visual frames before one shell-exit click; it
  then requires the fully proven world-boss map before the existing maximum-one
  exact target selection. Wrong pet, live session, ambiguous runtime or
  unstable UI sends no click and fails closed. The captured live shell satisfies
  both the new read-only candidate and visual locator (`confidence=0.9698`).
  Offline verification is now **652/652 PASS**, compileall clean and
  `git diff --check` clean apart from existing CRLF conversion warnings. A
  fresh exact-25 B6 live run is still required; Phase 2E.3 remains NOT PASS.
- Run `0d465c3f5d4b40aa94abf62bb0b00b13` also exposed the gameplay-latency
  regression behind its late turns. At turn 27, the local turn was visible at
  about `17:10:17`, but policy did not receive a stable board until
  `17:10:25.684`. The blocking step was
  `LOCAL_TURN_ACK_GAP_FULL_ESCALATION`: 510 regions / 571,180,289 bytes / 3.50
  seconds, followed by board stabilization. `RuntimeSequenceMonitor` retained
  only ChatMessageDTO regions even when the same scan found WsCombatBatch in a
  batch-only 8-16 MiB region, so later ACK gaps repeatedly fell back to broad
  heap scans during the player's turn. The monitor now learns both DTO and
  batch regions during the safe pre-entry lobby prime, retains batch-only hits
  after every scan, and receives both hint types from the shared provider.
  Ordinary scans use exact learned regions; allocator neighbours are added only
  for a new ACK gap. A live lobby measurement on PID 5748 reduced the repeated
  scan set from 429.62 MiB to 39.04 MiB and measured the learned scan at 0.206
  seconds (the one-time 429.62 MiB prime remained in the lobby at 2.94 seconds).
  Fresh combat evidence is still required before declaring the latency fix
  live-accepted.
- A manual room re-entry after that stop proved another lifecycle boundary:
  `ManagerRoom.selectedCards` was empty while stale `RoomDTO.cards` still held
  Mana/Rage/Health/Attack, so the authoritative next-combat loadout contained
  zero cards. Cpp2IL/ISIL proves that `ManagerRoom.DisplayCardsForSelection`
  creates and registers room Toggles in exact `RoomDTO.cards` order. The live
  room had one owned Attack candidate at index 3 (`data_id=64647`, `card_id=4`).
  One diagnostic normal click changed the manager list from empty to exactly
  `((64647,4,ATTACK))`. The production path now plans only a unique owned
  Attack card, requires the exact room/pet and no combat owner, proves the
  runtime-indexed Toggle in two frames, records one `BOSS_CARD_SELECT`, and
  rereads `ManagerRoom.selectedCards` before permitting the independent Start
  capability. A live no-entry probe repeated the complete empty -> auto-select
  -> memory-confirm sequence successfully; locator confidence was `0.9690`.
  No function/support card is restored in this milestone, and a genuinely
  unavailable Attack card retains board-only fallback. Offline verification is
  now **658/658 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF conversion warnings. The UI must be reloaded before the fresh
  exact-25 run; Phase 2E.3 remains NOT PASS.
- Fresh exact-25 run `15cb5cf6be3648e19d4090a9b26c2956` proved the
  pre-entry Attack contract end to end for three completed STRONG/CONSISTENT
  WINs: every entry had `preentryCardCount=1`,
  `preentryAttackCardCount=1`, and the live combat used the card (attempt 3 had
  four accepted casts). Attempt 4 then exposed a separate dead-board routing
  defect. After two authoritative passes and one acknowledged mandatory reset,
  the exhaustive 112-pair scan again returned `NO_LEGAL_MOVE_BUG` at idle 2.
  The generic mandatory SWAP/CAST assertion ran before the existing
  `EXIT_MATCH`/dead-board recovery branch, producing
  `MANDATORY_CONSUMING_ACTION_NOT_SELECTED` and safely stopping the run at
  3/25. Verified dead-board evidence now preempts only that generic assertion
  and dispatches the existing bounded `DEAD_BOARD_NO_REFRESH` technical
  recovery to the outer farm coordinator. PASS, NONE and EVOLVE at idle 2
  remain fail-closed and cannot use this exception. Offline verification is
  now **660/660 PASS**, compileall clean and `git diff --check` clean apart
  from existing CRLF conversion warnings. Because the run ended before this
  fix was loaded, a new exact-25 run is still required; Phase 2E.3 remains NOT
  PASS.
- After a machine reset, fresh run `8116549228b4419bb518f95fb6fe1a18`
  completed one STRONG/CONSISTENT WIN, then reproduced the real postmatch card
  reset: `ManagerRoom.selectedCards=[]` while `RoomDTO.cards` still exposed one
  Attack at index 3. The selection path correctly planned that exact card, but
  Unity rendered the cyan cost header one frame before the card body. The first
  locator frame was incomplete; the very next frame proved the exact Attack
  Toggle with confidence `0.9815`. Requiring exactly the first two frames
  therefore produced the false stop `ATTACK_CARD_TOGGLE_UNPROVEN`. Selection
  now remains zero-input for a bounded three-second window and requires two
  consecutive complete proofs at the same runtime-derived point and unchanged
  foreground geometry. Thresholds are unchanged; an unstable, missing or
  changed Toggle still fails closed. Offline verification is now **662/662
  PASS**, compileall clean and `git diff --check` clean apart from existing
  CRLF conversion warnings. A reloaded UI and fresh live run must prove the
  empty-manager-list -> selected Attack -> Start sequence and continue the
  exact-25 soak; Phase 2E.3 remains NOT PASS.
- The first live retry with the bounded visual wait,
  `70e86e4434cd4859aa826cf4f9cce2e1`, completed another
  STRONG/CONSISTENT WIN. Its next entry reproduced the asynchronous state more
  precisely: the locator obtained two consecutive complete Attack frames after
  four captures (`confidence=0.9690`), while the atomic read-only preflight
  found that Unity/server had independently repopulated the same Attack into
  `ManagerRoom.selectedCards`. The old strict REQUIRED-only preflight rejected
  this desired `REQUIRED -> ALREADY_SELECTED` transition as
  `ATTACK_CARD_RUNTIME_CHANGED`. The preflight now accepts only that transition
  when the exact card identity, room, pet and no-combat-owner invariants still
  match, records `preentry_attack_selection_rehydrated`, and sends zero card
  clicks. Different card identity or any other runtime change still fails
  closed. Offline verification is now **664/664 PASS**, compileall clean and
  `git diff --check` clean apart from existing CRLF conversion warnings. The
  UI must be reloaded again and the next postmatch entry must prove this live;
  Phase 2E.3 remains NOT PASS.
- Post-reset exact-25 run `77e182eb460b43a1802daa8e6601aa46`
  completed 21 matches (19 WIN, 2 LOSS) with zero technical aborts/recoveries,
  including the previously problematic attempt 16 and a live
  `REQUIRED -> ALREADY_SELECTED` Attack-card rehydration. Attempt 22 then
  stopped making progress on boss turn 6: `MatchService` remained at timer 14
  and `ClockPauseReason=ACK_WAIT`, with no pending bot action, while the ACK set
  had already advanced from `srvSeq=11` to 13. Read-only runtime evidence found
  local actor 1 in `Board._leftActorNumbers`; the game UI independently showed
  the local player as left. `MatchService.Players["happi"]` remained stale at
  `inMatch=true`, proving it is not a safe membership source for this failure.
  The provider now validates the exact `HashSet<int>` layout at `Board+0x2B0`,
  publishes `local_has_left_match`, blocks all gameplay when true, and routes
  only an exact farm-owned ACTIVE session to bounded technical recovery. Boss
  turns without this durable signal remain zero-input waits; no generic boss
  timeout was added. Offline verification is now **671/671 PASS**, compileall
  clean. The running UI predates this fix and must be reloaded before live
  recovery/soak validation; Phase 2E.3 remains NOT PASS.
- Fresh exact-25 run `786ab019a93e4c8abb3d424c10b1c20a` completed
  7/7 STRONG/CONSISTENT WINs with zero technical aborts/recoveries, including
  Attack casts and successful EVOLVE-follow-up gameplay. After attempt 7 the
  server again removed room ownership while Unity rendered the exact Starburst
  shell. Production correctly surfaced `DETACHED_ROOM_SHELL_CANDIDATE` and
  sent one proven shell-exit click, but then timed out because the map badge
  locator's single historical `number_A_8` template did not match Unity's
  1280x720 rasterization. A direct live capture classified the displayed 8 as
  the old 6 template (`targetScore=7`); the measured 1280x720 variant now
  identifies only that badge with `digitScore=0`, `digitMargin=6`, and
  confidence `0.955`. The post-shell transition now accepts exactly two
  bounded paths: two stable runtime-derived target-badge frames for direct map
  navigation, or three stable leave-modal frames followed by one separately
  audited `BOSS_ROOM_SHELL_CONFIRM`, unchanged exact-pet/no-owner runtime
  proof, then stable map proof. Neither path may click on ambiguity. Live
  read-only verification on the resulting map resolved Starburst/1289,
  `huntOrder=8`, the unique badge, and one exact normal click returned to a
  true inspect-ready boss room. Offline verification is now **674/674 PASS**,
  compileall and `git diff --check` clean apart from existing CRLF warnings. A
  new exact-25 run is required; Phase 2E.3 remains NOT PASS.
- Exact-25 retry `653bac40fc0c443ea465d9c4294b31bb` completed attempt 1 as
  a STRONG/CONSISTENT WIN with successful Attack cast and EVOLVE, then the
  first Start input for attempt 2 received no game response. The exact target,
  Attack loadout, two-frame Start locator, foreground geometry and normal
  input dispatch were all valid, but 45 seconds later there was still no
  session/loading owner and the same Start control remained visible. The old
  one-click entry contract therefore stopped at `ENTRY_TIMEOUT_NEW_SESSION`.
  Farm-owned entry now has one separately audited `BOSS_ENTRY_RETRY` permit:
  it is available only in the still-pending same attempt after exactly one
  sent Start, with no combat owner, unchanged clean room ID/pet/Button address,
  and two stable frames of the same Start signature. It cannot create a new
  match attempt, cannot be repeated, and a changed/ambiguous proof sends zero
  retry input and fails closed. Standalone BossEntry remains one-shot because
  it has no farm retry capability. Offline verification is now **677/677
  PASS** and compileall clean. A fresh exact-25 run is still required; Phase
  2E.3 remains NOT PASS.
- Exact-25 run `33f02803c0b2464cb3a0da22b05eff09` completed six consecutive
  STRONG/CONSISTENT WINs. Attempt 7 naturally hit an exact dead board and the
  bounded technical recovery correctly sent one Exit plus one Confirm, cleared
  the old provider session and returned to the true exact Starburst boss
  lobby. It then stopped before re-entry because the original lobby ACK guard
  required `MatchService._ackedSeqs` to be empty. Live read-only evidence over
  120 samples/15 seconds proved `CurrentMatchId=null`, no provider session and
  an unchanged stale pair `highestAckedSequence=29/localMoveSequence=6`.
  Successful ordinary entries in the same process prove that Unity clears
  this residue while binding the next MATCH_START, not necessarily while idle
  in the lobby. Recovery now accepts only a frozen owner-free residue after at
  least eight identical samples spanning two seconds; advancing, unreadable or
  owned epochs still block. It then re-proves the exact lobby and keeps
  gameplay locked until a distinct pristine MATCH_START shows a null ACK epoch
  throughout the existing 2.5-second handoff guard. Focused offline recovery
  tests are PASS; full-suite and new exact-25 live evidence are pending, so
  Phase 2E.3 remains NOT PASS.
- Exact-25 run `f4ea08261b1e4b41a9c997c46e7f5a25` completed 16/16
  normal results before an operator-requested graceful stop at the exact boss
  lobby: 13 WIN, 1 LOSS and 2 evidence-backed UNKNOWN, with zero technical
  aborts/recoveries. Attempts 1-13 had complete local PlayerStats. On attempts
  14-16 every policy sample retained boss stats but lost the local participant;
  Attack remained discoverable, yet affordability was UNKNOWN and no
  EVOLVE/CAST was permitted. This was not merely terminal cleanup: it affected
  every active-turn policy decision in those three matches. Reverse evidence
  confirms `Active.playerStatsList +0x28` is the serialized inspector view,
  while `Active.playerStatsMap +0x20` is the game-owned
  `Dictionary<int, Active.PlayerStats>` used by combat actor lookup. Participant
  decoding now structurally validates both sources and uses the current map as
  primary, with the list only as an overlapping pointer-consistency check and
  fallback when no map object is published. A declared malformed/changing map,
  key/actor mismatch or map/list pointer conflict fails closed; no prior-call
  participant is cached or reused. The exact list-only-boss/map-player+boss
  regression and conflict cases are covered offline. Full verification is now
  **685/685 PASS**, compileall clean. A fresh live run must prove map-backed
  local HP/mana and card use beyond the old long-session boundary before B6
  can be accepted; Phase 2E.3 remains NOT PASS.
- Exact-25 retry `bbb76d27b1ef403fb4530d3a57937c5c` proved the new
  `playerStatsMap` path in three consecutive STRONG/CONSISTENT WINs. Every
  local/boss sample was map-backed; EVOLVE succeeded and was followed by a
  fresh-state same-turn SWAP, while three ATTACK casts were accepted. Attempt
  4 naturally hit a proven `DEAD_BOARD_NO_REFRESH`. Bounded recovery sent one
  Exit and one Confirm, returned to the exact Starburst room, sent one re-entry
  click and obtained a distinct pristine 64/64 MATCH_START. The handoff then
  falsely stopped because the provider instance reused by recovery retained
  `metrics.highest_acked_sequence=43` from the failed session even though the
  new runtime ACK epoch was empty. This field is a current-session gauge, not
  a cumulative metric: both lifecycle reset and lifecycle clear now set it to
  `None`. The handoff guard also keeps gameplay locked for its complete bounded
  window when it initially sees a dirty gauge, accepting only after the gauge
  clears and at least two clean pristine states remain with more than four
  seconds; a persistent/delayed ACK still fails closed as
  `RECOVERY_ACK_EPOCH_NOT_RESET`, and session/action mismatches still reject
  immediately. Regression coverage includes both provider lifecycle paths,
  stale-gauge settlement, persistent contamination and session change. Full
  verification is **690/690 PASS**, compileall clean and `git diff --check`
  clean apart from existing CRLF warnings. The run stopped at the guard and
  therefore a fresh exact-25 B6 run is still required; Phase 2E.3 remains NOT
  PASS.
- Exact-25 retry `1f605aeb308e4b09a95878fcb37ec398` completed 19
  STRONG/CONSISTENT results (18 WIN, 1 LOSS) with zero technical aborts or
  recoveries. It passed the old attempt-14--16 failure boundary with every
  local/boss policy sample sourced from
  `Active.playerStatsMap/ObfuscatedInt.Value`; Attack affordability, fourteen
  successful EVOLVEs and thirty accepted CASTs remained available in the long
  process. After result 19, Unity produced a detached room shell. The runner
  proved and clicked exactly one shell exit, then proved the exact Starburst
  hunt-order-8 badge in two frames. The final atomic preflight rejected only
  because the generic lobby classifier reported the expected owner-free
  post-shell transition as `LOBBY_OTHER/branch=None`, rather than the normal
  `BOSS_LOBBY/WORLD_BOSS_LIST`; exact Button/Pet/PlayerPrefs identity and all
  no-owner evidence were unchanged. Map preflight now accepts exactly those
  two owner-free shapes. It still requires lobby lifecycle, null room ID/type,
  null owner, `is_host=false`, no provider session, the exact runtime target
  association and stable badge proof. Any owned room, ACTIVE lifecycle or
  different state/branch remains fail-closed. Full verification is now
  **693/693 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF warnings. The safety stop means this run is not B6 acceptance;
  a fresh exact-25 run is still required. Phase 2E.3 remains NOT PASS.
- Exact-25 retry `5fb7ac622bd1476babe099e0dab0bfb3` completed three
  STRONG/CONSISTENT WINs with zero aborts/recoveries, then stopped before
  attempt 4 with zero new input. `ManagerRoom.selectedCards` had correctly
  reset while `RoomDTO.cards` still proved the unique Attack at index 3, but
  Unity rendered only the cyan strip/header throughout the former three-second
  visual window; both Attack body metrics remained exactly zero. The saved
  frames prove this was an incomplete strip rather than a wrong card. The live
  room later rendered all four bodies normally. Required-Attack discovery now
  remains zero-input for a bounded 15 seconds and still requires two complete
  consecutive frames with the original thresholds, exact foreground geometry
  and unchanged room/runtime identity. The post-click read-only verification
  window is separately bounded at ten seconds. These waits are lobby-only and
  do not affect first-turn or combat action latency. Full verification is now
  **694/694 PASS**, compileall clean and `git diff --check` clean apart from
  existing CRLF warnings. The safety stop invalidates B6 acceptance; a fresh
  exact-25 run remains required. Phase 2E.3 remains NOT PASS.
- Exact-25 retry `0d465c3f5d4b40aa94abf62bb0b00b13` completed 14
  evidence-backed matches in 16 attempts (8 WIN, 1 LOSS, 5 UI-audited
  MEMORY_INCOMPLETE UNKNOWN), with one dead-board technical recovery. Attempt
  10 itself ended with stable `Thắng/WIN`; it was not the ejection. Attempt 16
  reproduced the actual failure: after authoritative PASS at turn 25 produced
  idle `1/3`, a Sword SWAP was selected/sent at one remaining server tick and
  expired with `RESPONSE_OR_ACK_TIMEOUT`. The next local turn was first usable
  at two ticks; another SWAP was sent without ACK, after which combat ownership
  disappeared with no terminal HP/event/UI evidence. This is consistent with
  the server counting the missed inputs as idle 2/3 and 3/3. The user separately
  confirmed that moves sent at displayed `1` are accepted and animate normally,
  so this is classified as lag/unconfirmed-action evidence rather than a reason
  to raise the timer floor. Production keeps the inclusive one-second floor;
  only `0` blocks new input. A fresh exact-25 run is required;
  Phase 2E.3 remains NOT PASS.
- First-turn retry `6f865ca238134733b1d252f6a876e885` proved that the
  remaining opening failure was latency, not a wrong swap coordinate. Entry
  had already accepted a pristine 64/64 opening at timer 10, but the combat
  controller repeated provider stabilization. An equivalent later
  `MATCH_START` publication changed the sequence identity, so the policy
  proposal at timer 6 was rejected; the replacement proposal reached the
  input executor only after a timer-3 preflight and received no ACK before the
  user stopped. Production handoff now reuses the entry-proven immutable board
  for only the pristine first local action. A cheap direct MatchService read
  must still prove the exact session/match, local owner, turn 0/1, local move
  sequence 0, no prior move and timer >= 1 both at controller publication and
  immediately before input. Any mismatch falls back to the normal provider;
  any successful SWAP, EVOLVE or CAST permanently invalidates this fast path.
  Transport scans also retain both ChatMessageDTO and WsCombatBatch regions;
  a live read-only benchmark reduced the ordinary learned scan from about
  429.62 MiB to 39.04 MiB (0.206 s on that sample). Offline verification is
  **696/696 PASS**, compileall and `git diff --check` are clean. A fresh live
  manual-Start retry is still required; Phase 2E.3 remains NOT PASS.
- Live run `5048e07b690d456ca0783ff6b949dc4e` proved the opening
  fast path in repeated real combats. Attempts 1, 3, 4 and 5 were accounted as
  STRONG/CONSISTENT WINs; attempt 2 was a true dead-board technical abort whose
  bounded Exit/Confirm/exact-Starburst re-entry completed successfully. The
  first SWAP in attempts 5 and 6 was decided immediately from the pristine
  handoff and acknowledged by the server. Attempt 6 additionally proved three
  failed EVOLVE responses each fell through to a same-turn acknowledged SWAP,
  a later EVOLVE succeeded, two ATTACK cards were accepted with exact 160-Mana
  deltas, and authoritative idle 1/3 then 2/3 forced an acknowledged mandatory
  SWAP instead of a third pass. It reached a STRONG WIN with zero duplicate,
  stale, wrong-turn, postmatch or lobby input and zero response timeouts. An F9
  edge arrived about two seconds after the terminal WIN and finalized the run
  as `EMERGENCY_STOPPED`, so attempt 6 was deliberately not counted in the
  checkpoint; this is operator/control evidence, not a combat failure.
  Optional-card publication was intermittent after rapid ordinary postmatch
  returns: attempts 2 and 4 had no live CardUI/FusionCardUI, whereas attempts
  1, 3, 5 and 6 resolved both. Pre-entry now maps an already-selected unique
  RoomDTO Attack back to its exact visual slot and requires the selected body
  proof to remain stable for three seconds before Start. It sends no extra card
  click; ambiguous/no-slot telemetry keeps the Manager selection authoritative
  and records that the settle proof was unavailable. This lobby-settle patch
  is offline verified but was not loaded by the UI process used for the run.
  Full verification remains **696/696 PASS**, compileall and
  `git diff --check` clean. Restart the Desktop UI and run a fresh bounded soak
  to validate the settle patch; Phase 2E.3 remains NOT PASS.
- Exact-25 run `0345ab13927c4607bf9d381c97085725` loaded the lobby
  settle patch and reached 19/25 completed matches: 19 STRONG/CONSISTENT WIN,
  0 LOSS, 0 UNKNOWN, 3 earlier successful technical recoveries. Attempt 23
  accepted a pristine 64/64 opening at timer 13 but then published the local
  actor inside validated `Board._leftActorNumbers`; the game UI showed timer 0
  and `[đã thoát]` while lifecycle remained `ACTIVE_COMBAT`. The detector
  produced `LOCAL_PLAYER_LEFT_ACTIVE_COMBAT`, but the old run-level recovery
  cap had withheld the per-combat dispatcher, so `recoveryTrigger` remained
  null and the run finalized `COMBAT_SAFE_STOP`. Recovery is now farm-lifetime
  unbounded: each proven incident always receives a fresh one-shot coordinator,
  while ambiguous/failed recovery remains fail-closed. `Max recoveries` was
  removed from the UI and CLI help; old persisted/checkpoint values are ignored
  for enforcement and resume compatibility. A narrow history-only migration
  can resume this exact legacy cap-stop shape from an independently proven
  exact boss lobby, accounting its single orphan attempt as technical abort and
  restoring no executable state. Offline verification is **701/701 PASS**.
  The patch requires a Desktop UI restart and live resume/continuation; Phase
  2E.3 remains NOT PASS until the exact-25 target completes.
- Exact-25 retry `40e07464eebd4509a91439877d63c6f2` reached 21/25
  completed matches in 23 attempts: 17 WIN, 0 LOSS, 4 UI-audited
  MEMORY_INCOMPLETE UNKNOWN, one dead-board abort and one successful recovery.
  Attempt 23 then proved a different game/server freeze. After three accepted
  SWAPs, direct MatchService state became permanently fixed at match
  `M_ef4e8a78`, turn 10, owner `__BOSS__`, timer 14, local/last move sequence
  3 and highest ACK 24. Across 187 full scans there were no new messages,
  batches, timer ticks, turn transitions or sequence progress; the controller
  waited until its 1800-second timeout. The screenshot also displayed
  `happi [đã thoát]`, but `Board._leftActorNumbers` did not publish a fresh
  `GameState`, so the existing player-left detector could not arm recovery.
  Build `v1.0.0+10` adds an exact-session active-combat progress watchdog for
  either turn owner. Any change to session, turn, owner, timer, local/last move
  sequence or highest ACK resets the proof; missing evidence, foreground loss,
  a pristine opening, pending action, PASS/Fusion wait or sequence desync also
  resets it. Only a production-ready ACTIVE board with prior accepted gameplay
  and at least four unchanged samples over 45 seconds dispatches
  `ACTIVE_COMBAT_PROGRESS_STALLED` into the existing farm-lifetime-unbounded
  recovery path. Replaying the real attempt-23 log would trigger at
  `2026-08-27T13:31:43.748Z` after 50.343 seconds, rather than at the 30-minute
  controller timeout. Offline verification is **713/713 PASS**; a restarted UI
  and fresh bounded continuation are still required before Phase 2E.3 PASS.

## Superseded Historical Assumptions

- Dot 64/64 is not a production requirement; CV is not production board source.
- Older PASS-disabled text is historical; bounded authoritative PASS is accepted.
- Early 3/10-action caps are milestones, not current B5 gameplay caps.
- Manual opening move is superseded by exact `MATCH_START` bootstrap.
- Old `BASIC_INTERMEDIATE_FALLBACK_UNDEFINED` behavior is superseded by accepted
  Shield/Health/general safe-resource fallback.

## Next Phase

**Phase 2F.2 is PASS STRONG. Finite BASIC scope is COMPLETE.**

```text
accepted Phase 2E.2 live UI/FarmRunner integration
-> accepted Phase 2E.3 operator UX + exact-pet recovery + 25-match UI soak
-> accepted Phase 2F.1 portable Windows packaging + packaged live validation
-> accepted Phase 2F.2 Release Candidate + Final Acceptance
```

There is no next phase in the current roadmap. Infinite farming, process
relaunch/login, internet recovery, target
rotation, pet-specific skill-card use, mid-combat checkpoint resume, and
navigation from the general game lobby through Chinh Phuc islands remain
outside current scope unless explicitly approved. REASONING remains undefined
and unsupported.

## Update Policy for Future Phases

After each accepted phase: update completed/next phase, capabilities, unresolved
blockers, test baseline, evidence links, and superseded assumptions. Update
[DECISIONS.md](DECISIONS.md) only when the user changes a gameplay/product rule
or explicitly approves policy; technical discoveries normally belong here or
in phase reports.

## New Agent / New Conversation Bootstrap

```text
Read AGENTS.md first.
Then read docs/CURRENT_STATE.md and docs/DECISIONS.md.

Treat those files as the canonical current handoff.
Use phase-specific reports and logs only for deeper evidence.
Do not rely on previous chat history.
Do not change gameplay rules recorded in DECISIONS.md.
Continue only the phase explicitly requested by the user.
```

Canonical references: [AGENTS.md](../AGENTS.md) and
[DECISIONS.md](DECISIONS.md).

## Desktop Compact Layout / Build Label

The Control tab now hides Attachment, Process, Session, pinned pet ID and
pinned pet name. These values remain internal read-only controller/recovery
state and diagnostics evidence; only their redundant widgets were removed.
PlayStyle/Intelligence share one equal-width row, Target matches/Max attempts
share another, and the explanatory pet/preferences subtitles were removed.
The accepted Phase 2F.1 title is `Pokiguard Tool V2 - v1.0.0+15`. PlayStyle and
Intelligence are two equal-width **clusters** on the first row. Target matches
and Max attempts use the same two-cluster 50/50 outer layout. Inside every
cluster, the label keeps its natural width immediately beside the control; the
label and control are never forced to 50/50. ManaPriority is the only cluster on
its following row, so that cluster spans the full row with no empty sibling.
Subsequent pre-MVP tool-code revisions increment only
the `+N` build suffix.

Build `+5` fixes the compact-panel render contract: removing Attachment,
Process and Session widgets must also remove those keys from the Tk update loop.
The runtime poller was still healthy in the incident evidence, but the stale
hidden-key lookup raised `KeyError: 'attachment'` before lifecycle values and
controller button state could render. A regression test now covers this exact
hidden-widget failure mode. Timed UI smoke runs now also fail closed unless they
complete at least one render with zero handled UI errors and stop their poller.

Build `+6` also removes MatchId from both the compact runtime panel and its Tk
update set. Match identity remains internal controller/gameplay evidence only;
the operator UI no longer creates or updates a MatchId widget.

Build `+7` separates gameplay preferences into the second `Preferences` tab.
PlayStyle, Intelligence and ManaPriority use a two-column 30/70 table so all
controls share one left edge. The Control tab keeps only Target matches and Max
attempts from the editable settings, places them inside the FarmRunner control
area, and renders the completed/attempt/W-L-U run report below the buttons.

Build `+8` gives initial keyboard focus to the notebook/tab surface instead of
the first Target matches entry. The limits remain normally mouse-editable, but
opening or initially activating the tool no longer selects that field.

Build `+9` adds background-click defocus without intercepting clicks on Entry,
Combobox, Button, Text or Notebook controls. Start/Resume parses the two limit
StringVars through canonical `DesktopConfig`, hands that immutable config to the
controller, immediately disables the editable settings on acceptance, and
reasserts the accepted Target matches / Max attempts values until the controller
stops. The fields become editable again only after backend controller truth is
inactive.

Build `+10` adds the read-only active-combat progress watchdog described above.
It closes the boss-turn/timer-14 freeze gap without using screenshots or
relaxing any gameplay-input gate.

Build `+11` fixes exact-25 run `4ab9bda9429144f991dd8bdcd6e83956`.
The run completed 11 STRONG WINs, then attempt 12 correctly detected
`DEAD_BOARD_NO_REFRESH`, exited and re-entered exact Starburst `1289` as new
match `M_d624138a`. The recovered MATCH_START was complete (64/64), but the
failed match's frozen raw ACK maximum `53` persisted while current-session
batches were only `3..7`; treating the process-wide maximum as current caused
`ENTRY_TIMEOUT_OPENING_BOARD`. Recovery ACK isolation is now armed only after
the exact owner-free room proves a frozen lobby ACK/local-sequence pair. The
raw value remains visible for audit, while publication may use only the exact
new MATCH_START or batches independently tied to the current BoardWs owner or
current-match ChatMessageDTO. An unexplained ACK advance still fails closed.
The same incident ended in a proven `DETACHED_ROOM_SHELL_CANDIDATE`; failed
recovery fallback now audits one prior re-entry and continues through that
exact-pet/no-owner shell into the existing map-target recovery path instead of
immediately finalizing `RECOVERY_FAILED`. Offline verification is **719/719
PASS** with compileall and diff checks clean.

Build `+12` addresses live run `73b33c680535474fba7031732bd6347f`,
which completed 24/25 STRONG/CONSISTENT WINs. Attempt 25 hit a technical
failure; recovery could not complete in-room after the game reported a lost
room connection, but the existing exact-pet fallback restored Starburst
`1289` and attempt 26 entered combat successfully. That recovered combat then
sent 11 SWAPs but confirmed only 8. Two SWAPs timed out, and the mandatory
SWAP after authoritative idle `2/3` received no response before the game
ejected the player. Every physical SWAP still used the fixed 0.25-second
two-click gap, even while the observed client was running at roughly 3-4 FPS.

There is no verified read-only game field for overlay Ping/FPS and no OCR
dependency is added. The ordinary-input executor now uses auditable adaptive
pacing instead: 0.25 seconds normally, 1.0 second after a proven recovery or
exact room re-entry, and at most 1.5 seconds after an unconfirmed SWAP. Slow
accepted transitions retain degraded pacing; only eight consecutive accepted
SWAPs within the fast threshold decay one level. A late integer server timer
may clamp the delay so the second click retains a 1.25-second delivery margin.
Each `action_sent` records the selected delay, mode, reason and lag score.

The same run also proved that ordinary `COMBAT_TERMINAL_UNPROVEN` ejection can
settle at the exact-pet/no-owner `DETACHED_ROOM_SHELL_CANDIDATE`, not only the
fully loaded `WORLD_BOSS_LIST`. That branch now uses the same centralized
owner-free ejection proof and exact pinned-pet restoration path instead of
finalizing `COMBAT_SAFE_STOP`. Match completion is still not counted, old
combat state is never reused, and ambiguous ownership/target evidence remains
fail-closed. Offline verification is **722/722 PASS** with compileall and diff
checks clean.

Build `+13` diagnoses the two starts in runs
`06b9fa00bcbe43caa37266cd06367bf2` and
`77de198ab03e413694182a11c5099a03`. The first run's dead-board artifact proved
three valid stats actors: local user `1` at `716/1563` Mana, Fusion pet `2`,
and boss `99`; Fusion UI was live and interactable. The old "one non-boss"
heuristic therefore made player/Mana UNKNOWN and suppressed EVOLVE for the
wrong ownership reason. The provider now mirrors the read-only
`Active.LocalActorNumberOrZero` primary chain through
`MatchService.Players[ChatService.Username].actorNumber`, without hard-coding
an actor number.

The second run selected a SWAP at timer 2, spent about 1.46 seconds between the
policy record and completed click pair, then received the exact server reject
`Không phải lượt bạn`. Its logged adaptive delay was the normal 0.25 seconds,
so build `+12` did not cause that rejection. Build `+13` adds a cheap direct
MatchService preflight immediately before SWAP input and cancels the unsent
action if match, turn, owner, timer or local move sequence changed. Response
deadlines now start at the actual input boundary rather than before modal and
coordinate preparation. Offline verification is **725/725 PASS** with
compileall and diff checks clean.

Build `+14` introduces the Phase 2F.1 frozen Windows entry point, local
app-data path boundary, internal production calibration, bundled recovery
resources, one-folder PyInstaller spec and deterministic ZIP build. Packaged
B4/B5 live validation proves bounded completion and UI graceful stop.

Build `+15` fixes the post-graceful-stop button label: the terminal controller
snapshot intentionally retains `graceful_stop_requested=true` as evidence, but
pending text is now rendered only while that controller is active. Final
Phase 2F.1 verification is **740/740 PASS**.

## Source compatibility v1.0.15 — EVOLVE priority and third-idle prevention

Run `9230a17fad904c3a9b38bb69c6113d97` stopped after zero EVOLVE/CAST inputs
and was later ejected. This was not caused by solver choice. Fusion discovery
cached 42 ambiguous heap candidates while the exact Fusion owner allocation
was omitted by a combined two-allocation 16 MiB cap. The provider now scans
the appended Fusion GameObject's exact allocation, validates `_boundPetId`
against current `selectedPetId` (with the documented fallback), and caches
only one uniquely owned live wrapper.

Production Evolution priority now starts after the mandatory opening board
turn and uses the same inclusive one-second action floor. Low-boss-HP finisher
mode and authoritative idle 2/3 still suppress EVOLVE. A SWAP reservation
aborted before any Windows input is now released for fresh recomputation
instead of permanently stopping FarmRun; one displayed second is accepted by
the final direct preflight. Any exact server 2/3 payload independently latches
mandatory SWAP/CAST so a missed/unconfirmed earlier action cannot lead to a
third zero-input turn. Source verification: **778/778 PASS**, compileall PASS,
`git diff --check` clean. Live EVOLVE plus continued combat/recovery remains
the acceptance boundary.

## Source compatibility v1.0.16 — selectable two-click/drag SWAP input

Redux 1.7.4 directly declares `Dot.OnMouseDown`, `Dot.OnMouseUp`,
`firstTouchPosition`, `finalTouchPosition`, `IsValidSwipe`, `MovePieces`, and
the drag-specific turn-timer pause/resume path. The product now exposes
`Board input` in the Preferences tab with `two_click` and `drag`. Existing
preference files without the field migrate to the requested `drag` experiment;
the selected value is validated, persisted, snapshotted at Start/Resume and
forwarded through Desktop controller -> FarmRun -> combat executor.

Drag uses only foreground normal Windows mouse input. It presses at the exact
first tile centre, traverses six bounded points for 0.35 seconds normally
(adaptive up to 1.5 seconds after lag evidence), and releases at the exact
second centre. Window/PID/geometry/focus changes fail closed and LEFTUP is
guaranteed after any emitted LEFTDOWN. Card and UI actions are unchanged.
Action telemetry distinguishes `inputMode`, `dragDurationSeconds` and
`dragSteps`. Source verification: **780/780 PASS**; live drag acceptance is
pending.

## Source compatibility v1.0.17 — quick-flick drag correction

FarmRun `1e9097b2276948a7bdf7c78cc77281fa` live-rejected the initial drag:
the exact legal adjacent centres were emitted over 0.35 seconds/six steps, but
there was no server response, local move sequence stayed zero, and the first
gem remained selected. The Cpp2IL `Dot.OnMouseDown`/`OnMouseUp` body confirms
that swipe validity is based on press/release displacement against
`swipeResit`, not elapsed drag time.

Drag now performs the operator-confirmed gesture shape: a fixed 0.10-second
three-move flick ending 0.35 cell beyond the second centre, still inside the
target cell and Board rectangle. Adaptive lag evidence continues to pace
`two_click`, but never stretches a drag. `dragOvershootPixels` is included in
SWAP telemetry; all foreground/window/geometry guards and unconditional
LEFTUP cleanup remain active. Offline verification is **782/782 PASS**;
fresh live drag acceptance remains required.

## Source compatibility v1.0.18 — calculable safe-resource boundary

Run `67bb91cf613345a6ba1b806cd834bb57` proved the `two_click` path itself was
healthy (five acknowledged SWAPs), but exposed a policy defect. Turn 11's Rage
candidate was `calculable=false`, introduced three UNKNOWN refill cells, and
still carried `safe=true`; live play showed its collapse forming a Sword
opportunity for the boss. A top-board outcome with unknown refill cannot be
made safe by the absence of a Sword in one bounded hypothetical check.

Normal safe-resource candidates now require a calculable direct clear at
screen row 3 or lower in addition to the existing direct/indirect Sword reply,
UNKNOWN and collapse-support gates. Sword priority and mandatory minimum-risk
fallback behavior are unchanged. Every policy event now stores the exact 8x8
screen-oriented board plus all compact legal-candidate evaluations, preventing
managed-object reclamation from erasing the evidence needed for replay.
The UNKNOWN gate now also covers the operator-reconstructed one-row collapse:
when a refill slot appears beside a known Sword, the simulator tests moving
that existing Sword into the slot, because a non-Sword refill can expose a
match-3 even when treating the refill itself as Sword would auto-clear. The
exact topology is locked by regression coverage. Offline verification is
**785/785 PASS**; fresh live acceptance remains required.

## Source compatibility v1.0.19 — duplicate local-turn full scan removed

The same run's PASS handoff explains why a nominal 14-second turn reached
policy with one second left. A 6.35-second PASS scan had already decoded and
offered the exact current-match board for `srvSeq=19`. When direct runtime
subsequently sampled local turn 9 at 13 seconds with ACK 19, the monitor failed
to recognize that prevalidated but not-yet-ACK-attested provider snapshot and
performed a redundant 7.56-second broad heap scan. Provider stability work
then consumed the remaining margin.

Provider diagnostics now expose per-batch transport/runtime-heap attestation.
Those exact sequences suppress only duplicate heap discovery; they do not
bypass the provider's independent exact-ACK, latest-board, stability,
actionability or lifecycle gates. Unattested candidates remain excluded.
Future `pass_message_scan` events include scan reason, region count and bytes.
Offline verification is **786/786 PASS**; fresh live timing acceptance remains
required.

## Source compatibility v1.0.20 — owner-first card cache and bounded transport refresh

The current `reverse/redux_compat` declarations confirm the direct read-only
ownership roots used by the provider: `Board.selectedCards +0x318`,
`Board.cardsInHand +0x320`, `CardUI.cardData/board/active` at
`+0x20/+0x30/+0x38`, `MatchService.PendingCombat +0x188`, and
`BoardWsApplier._pendingBatches +0x50`. They do not provide a direct singleton
for CardUI or BoardWsApplier, so no pointer or owner was guessed.

The mandatory opening local turn now performs no optional card-list or card-UI
discovery. It remains reserved for the authoritative opening board and SWAP.
On the immediately following boss turn, the provider first reads the two
current Board-owned lists, decodes each immutable `CardData` once per combat,
and scans the exact ordinary-card and Fusion GameObject allocation envelopes
separately. Only a failed owner lookup can enter the rotating <=8 MiB and then
8--16 MiB compatibility fallbacks. The former first-boss-turn process-wide
CardUI/FusionUI scan has been removed.

Once a CardUI is resolved, each poll revalidates only its current Board/Active
ownership, Unity native/Button pointers, interactable bit, used/pending fields
and current participant resources. Card strings, costs and conditions come
from the per-combat immutable CardData cache. A proven current selected-card
list with no Attack card suppresses pointless Attack UI retries; unknown or
conflicting lobby evidence keeps discovery enabled. Fusion success clears the
obsolete Fusion wrapper, re-reads exact strip cardinality/order and reopens
bounded ordinary-card discovery only if the cached wrapper no longer validates.

Periodic transport maintenance no longer performs a broad heap traversal based
only on a timer. It scans learned allocator neighbours on an opponent turn;
full scans remain limited to explicit force, loss of every live learned region,
or one exact unresolved ACK-gap escalation. Board publication still requires
the existing exact ACK, latest-board, ownership, stability, lifecycle and
actionability gates. Offline verification is **788/788 PASS**; a fresh live run
must confirm the expected boss-turn cache discovery and local-turn latency.

## Source compatibility v1.0.21 — direct card authority and match energy accounting

The five-match live run
`logs/farm_runs/3b5672d3e1be4a7193c15c6d84ad3710` confirmed that board acquisition
and SWAP timing are now fast and stable. It also isolated the remaining card
delay: turns with 210--371 mana repeatedly logged
`STEP_1_EVOLVE: live FusionCardUI is not proven interactable`, even though the
same snapshots already proved one selected Attack `CardData`, two
`cardsInHand` entries, Fusion slot 0, Attack slot 1, `FusionEnabled=true`, an
unused selected pet, and the exact 160 Fusion cost. One match did not resolve
an Attack `CardUI` wrapper at all. This was a wrapper-discovery bottleneck, not
a policy-order defect.

After the opening board-only local turn, the common standard-pet path now uses
the current Board-owned `selectedCards +0x318` and `cardsInHand +0x320` lists,
immutable `CardData`, and direct MatchService Fusion fields as the action
authority. If a live CardUI/FusionCardUI exists it remains preferred and its
dynamic Button state wins. If it is absent, exact list order/cardinality and a
standard strip without a pet-specific skill can authorize the known slot; the
foreground controller must still capture the client and prove the current
card tile immediately before a normal click. Direct ordinary-card fallback is
limited to `cooldownTurns == 0`; other cooldowns remain fail-closed. The former
owner/bounded/extended wrapper scans are skipped when this direct strip is
already exact, while opening-turn board priority is unchanged.

Farm telemetry already deduplicated observations by exact
`(session, TurnNumber, LOCAL/BOSS)`. That local count is now explicitly stored
as `energyUsed` for every attempt, emitted as `match_turn_energy_counted`, and
shown in the Control tab per completed match (latest eight) with the run total.
EVOLVE plus SWAP in one local turn counts once. Offline verification is
**793/793 PASS**; live acceptance should confirm that turn 2+ evolves before
Sword/SWAP whenever mana and Fusion conditions allow, and that the displayed
per-match energy matches the game flow.

## Source compatibility v1.0.22 — live current turn and CAST telemetry repair

FarmRun `logs/farm_runs/2f363b504c6742acacc882e3707e2acf`
completed 5/5 STRONG, CONSISTENT wins in five attempts. It had zero technical
abort, recovery, safe-stop, provider read error, DTO rejection, stale/latest
ambiguity, opening rejection, or terminal-result conflict. Local turn/energy
counts were 19, 14, 9, 11 and 22, total 75 (average 15). EVOLVE ran nine times:
four successes and five server-confirmed/timeout failures. All extended card,
Fusion and owner wrapper scans remained zero on the direct standard strip.

Seven CAST inputs were sent. The prior summary recorded zero accepted because
the direct CardData authority intentionally has no dynamic CardUI wrapper.
Five nonterminal CASTs nevertheless have exact evidence in the log: player
mana fell by the runtime 160 cost and the next authoritative turn belonged to
the boss. Acceptance now recognizes this dual proof only for
`BOARD_SELECTED_CARDDATA_CARD_STRIP`; mana or turn alone, an unexpected cost,
or a different authority still remains unconfirmed. This changes telemetry and
idle-reset correlation, not the physical click or policy order.

The Control tab now separates completed-match energy, current-match local
turn/energy, and total energy onto three lines. Current progress is projected
once per already-deduplicated game-owned TurnNumber and performs no additional
RAM scan, capture, solver evaluation or input. Full offline verification is
**796/796 PASS**. A subsequent live run is needed only to confirm the new UI
projection and repaired `castAccepted` counter; the underlying five-match farm
run itself already completed cleanly.

## Source compatibility v1.0.23 — fast-turn observer hotfix

The first live start on v1.0.22, FarmRun
`logs/farm_runs/1e5ec6948f734889b29654122f0ecb17`, proved the opening
64/64 board and sent one opening SWAP, then stopped with
`FARM_RUN_INTERNAL_INVARIANT`. The exact exception was
`TurnTransitionTracker.observe_runtime() got an unexpected keyword argument
'progress_observer'`. This was a local callback-routing regression introduced
by live turn projection, not a game, board, solver, lifecycle, or input-layout
failure.

The fast MatchService path now routes status projection through the same
deduplicated turn-counter helper as normal polling and leaves
`TurnTransitionTracker.observe_runtime` unchanged. A dedicated regression test
executes this exact helper boundary. Source version is `v1.0.23`; full offline
verification is **797/797 PASS**. A fresh live start is required to confirm the
hotfix past the opening action.

## Phase 3A.1 — Pet Skill/QTE reverse closure (2026-09-04)

Phase 3A.1 is **PASS STRONG**. No
BASIC policy, FarmRunner, UI, packaging or production input was changed; the new
observer remains strictly read-only.

Native 1.7.4 evidence proves the CardUI Dot-QTE family, current-match server
sequence/window, Arrow+WASD bindings, Enter+Space one-shot confirm, progress,
elapsed-time calculation, Perfect predicate, result classifier and automatic
dot-destruction path. The first live attempt then corrected ownership: source
`Active.playerPets` remains Silas/petId 2306 without a skill after in-combat
evolution, while the Legendary runtime card materializes separately. Current
ownership therefore starts at exact `CardUI.ActiveDotSkillCard.cardData` and still
requires current MatchId, lifecycle epoch, Board, Active, local actor, server
challenge and a proven inactive edge.

Retry `phase3a1_pet_qte_20260904_000854.jsonl` identified `Huyền Thoại 7`,
cardId 7, `ATTACK_LEGEND_`, level 14, conditionUse 200, raw mana/power cost 0/0,
zero cooldown, needPerfection false, eatPerfect/Good/Bad 0/20/12 and multiplier
1.8. Six QTEs were observed; five current generations completed with correct 7.
Arrow/WASD and Space/Enter both worked. A current `MATCH_SKILL_USE_RES` arrived
without QTE-specific echo fields. Nó gợi ý non-consuming nhưng stable-board
resource sample cũ không đủ đóng effective cost.

Two observer defects found by this retry are fixed. `instance_null` now records
the QTE inactive edge and clears the prior generation. Response correlation now
supports 1.7.4's generic envelope using unique completed generation, exact MatchId,
bounded server timestamp and explicit reject/success fields where present. It also
reads fresh participant resources without waiting for a stable board.

Final live `phase3a1_pet_qte_20260904_003250.jsonl` closed one exact current QTE:
server sequence equals all seven recorded presses, correct/index is 7/7, elapsed
3.151977 seconds is inside `[3.000,3.300]`, and native prediction, RAM timing text
and operator visual result all equal `PERFECT!`. The current no-reject response was
correlated by MatchId/generation/timestamp. Direct mana/power changed 274/215 to
74/15, proving this card's effective cost is `conditionUse=200` mana plus
`power=200` nộ despite raw `manaCost/powerCost=0/0`. Turn 33 remained local, so
the skill is non-consuming.

The actual family is automatic dot destruction with no manual row/dot targeting;
the operator observed many Sword gems consumed. Exact server-resolved dot count is
not echoed and remains UNKNOWN, so `PERFECT = max Sword` is not claimed. The prior
late GOOD-vs-BAD recollection is retained as historical uncertainty but does not
block a controller that targets the authoritative Perfect interval. Focused tests
are **22/22 PASS**, full regression **819/819 PASS**, compileall/diff check and
read-only smoke pass. Phase 3B.1 may now be designed without guessing.

## Phase 3B.1 — Production Shadow QTE Observer (2026-09-04)

Phase 3B.1 is **PASS STRONG**. Production read-only primitives now expose an
immutable `PetSkillCapability` and `QteSnapshot` without adding any gameplay
input. Current skill discovery requires exact CombatSessionKey, Board/Active,
runtime CardData and validated current CardUI/Button evidence. Ambiguous,
metadata-only, stale and unknown candidates remain non-current.

Live B1-B5 observed four manual QTEs across MatchIds `M_631e9914` and
`M_c2a5fef6`. All 28 expected directions matched all 28 recorded manual presses;
runtime results were one GOOD and three PERFECT with zero completion mismatch.
Three same-match generations remained independent and the next MatchId reset the
generation. The runtime Perfect window was `[3.000,3.300]` in all four samples;
the computed `3.150` midpoint remained diagnostic only. Generic 1.7.4
`MATCH_SKILL_USE_RES` was correlated to the current completed generation by exact
MatchId and bounded server timestamp; it did not echo a server timing result, so
that field correctly remains UNKNOWN.

The production live sample corrects the turn interpretation recorded in Phase
3A.1 while preserving its immediate cost evidence. For this exact
`ATTACK_LEGEND_` fixture, `conditionUse=200` is consumed Mana and `power=200` is
consumed Rage; raw `manaCost/powerCost` remain `0/0`. The immediate Phase 3A.1
sample `274/215 -> 74/15` proves gross delta `-200/-200`. A later Phase 3B.1
sample read `262/250 -> 62/250` only after the skill had automatically eaten the
board, so its net Rage delta is confounded by absorbed Rage gems/cascade and is
classified `AMBIGUOUS`, not as evidence that Rage is unconsumed.

The user confirmed that after Space the skill itself automatically eats the board
and no manual SWAP is needed. That later sample changed from local turn 41 to boss
turn 42, so Huyền Thoại 7 consumes the turn. The earlier turn-33 sample was read
before the automatic board effect/turn edge completed and no longer defines turn
semantics.

The response scanner now checks provider-learned ChatMessageDTO regions before a
bounded full fallback, preventing short-lived skill responses from being lost.
Retained `CardUI.timingText` from a preceding generation is ignored until the
current QTE itself is finished. Exact destroyed-gem/Sword count remains UNKNOWN;
family/target mode are `AUTOMATIC_DOT_DESTRUCTION / AUTOMATIC`.

An optional second live fixture observed `Spectre / petId 2227 / METAL` evolving
to `Huyền Thoại 2 / cardId 2 / ATTACK_LEGEND`. Its runtime fields and immediate
delta prove `200 Mana + 150 Rage` cost (`387/246 -> 187/96`); a 7/7 QTE at 3.091
seconds resolved PERFECT. Exact damage/final turn semantics remain UNKNOWN and
HT2 is not integrated into policy.

Focused verification is **74/74 PASS**, full regression **871/871 PASS**,
compileall and diff check pass. Automated Pet Skill clicks, directions,
Space/Enter, process writes, direct gameplay calls and network manipulation are
all zero. ManaPriority and the accepted BASIC gameplay path are unchanged. See
[Phase 3B.1 report](phase3b1_report.md) and
[runbook](phase3b1_runbook.md). Nominal next phase is Phase 3B.2, but it is not
started automatically.

## Phase 3B.2 — Automated QTE Direction Sequence (2026-09-04)

Phase 3B.2 is **PASS STRONG**. A dedicated
one-generation diagnostic harness now exposes only `UP/DOWN/LEFT/RIGHT` through
normal foreground-gated Windows input. It begins disarmed, requires an explicit
`--arm-next` plus a proven inactive QTE baseline, binds the exact current
MatchId/session/actor/card/turn/generation, sends one logical direction, and
requires exact read-only `currentIndex`, `correctCount` and press-list progress
before another direction can be authorized. Missing acknowledgement never
retries; any stale identity, foreground/window change, abort or lifecycle loss
disarms the generation.

Pet Skill card click and Space/Enter remain manual and have no representation in
the public direction executor. The shared controller lease excludes FarmRunner
and other Pokiguard input owners. BASIC policy, ManaPriority, card/resource
strategy and the accepted HT7/HT2 runtime cost resolver are unchanged. Offline
verification is **39/39 focused**, **141/141 combined QTE/input/stats** and
**912/912 full regression**, with compileall and diff check passing.

Native evidence from 1.7.4 proves `CardUI.GetDirectionFromInput` uses legacy
`UnityEngine.Input.GetKeyDown` for Arrow/WASD pairs. The matching normal Windows
legacy key path completed three explicitly armed live generations across two
MatchIds: **21/21 sent directions received authoritative RAM ACK**, with zero
wrong, skipped, duplicate, stale, unconfirmed or blind-retry input. Completion
times were 1.330--1.407 seconds against runtime Perfect start 3.000 seconds,
leaving 1.593--1.670 seconds headroom. Manual Space results were one PERFECT and
two GOOD. Pet Skill card clicks and Space/Enter remain fully manual and their
automated counts are zero. See the [Phase 3B.2 report](phase3b2_report.md) and
[live runbook](phase3b2_runbook.md).

## Phase 2 b2 ops-only ACK repair — chưa chốt, live test 1 PASS (2026-09-11)

FarmRun `4ea0b9f50cd54dc08d3bfdb984fd1f95` bị game xử lý như bỏ ba
lượt liên tiếp ở local turn 9/11/13. Đây không phải policy chọn PASS: log không
có `policy_decision` ở ba lượt đó và toàn run có `auto_pass_started=0`,
`pass_required=0`, `policy_no_safe_move=0`. Bốn input trước đó đều được ACK.
Provider đã dừng trước policy vì ACK tăng `21 -> 24 -> 26 -> 28` trong khi full
board DTO cuối cùng giữ sequence 21.

Reverse b2 xác minh `HandleResEnvelope` có thể apply combat `ops` và ACK response
mà không kèm full 8x8 board. Giả định cũ “highest ACK phải có full-board DTO cùng
sequence” vì vậy sai với b2. ACK vẫn bền và đúng vai trò render watermark.

Provider hiện ưu tiên exact DTO như cũ. Khi latest ACK thiếu DTO, nó đọc trực
tiếp đúng 64 Dot hiện hành qua
`Board.allDots -> GameObject native components -> managed Dot`. Mỗi object,
component, class, Board owner, coordinate, `PoolTag`, multiplier và motion flag
được kiểm tra hai lần; ACK HashSet, Board flags, queue/render/pending/in-flight
và toàn bộ allDots cũng phải bất biến. Đường này không heap scan, không gọi hàm
game và không nới bất kỳ actionability gate nào. Unit test mới bao phủ board
đủ 64 ô, Dot đang chuyển động và mutation giữa hai sample.

Live run `2f9116700bac4331b5830ab438983229` hoàn thành một trận setting
mặc định với kết quả **WIN / STRONG / UI-memory CONSISTENT**. Cả 8 local turn
đều có hành động tiêu thụ lượt, formal PASS bằng 0. Native current-board path
đọc 5 lần, accept 5, reject 0; không có read error, DTO rejection, stale hoặc
ambiguous publication. Đây là live proof đầu tiên rằng ops-only ACK không còn
làm policy bị đói bàn rồi hết giờ.

Trận này gửi ba EVOLVE ở turn 7/9/11 với mana trước lần lượt 180/150/120 và
runtime cost 120. Cả ba nhận exact current-match `MATCH_FUSION_RES
success=false`, `LocalFusionUsed` vẫn false, và mana sau phản hồi giảm đúng
120 thành 60/30/0. Vì vậy click/request và điều kiện `mana >= 120` đều đúng;
game xử lý ba lần tiến hóa thất bại theo cơ chế xác suất. `evolve_success=0`,
không có Pet Skill sau tiến hóa. Sau mỗi failure tool đọc fresh state rồi SWAP
trong cùng lượt như policy quy định.

Phase 2 vẫn chưa được chốt và không có commit/push/version bump. Một live run
đã xác nhận sửa lỗi bỏ lượt; quyết định cần thêm soak hay chốt phase thuộc bước
review tiếp theo.

## Phase 2 b2 multi-match opening preflight repair — chờ live soak (2026-09-11)

FarmRun `a588b67a29834419a9e8b351cfbed926` chạy target 5 / attempts 8. Trận 1
WIN / STRONG / CONSISTENT, tiến hóa thành công và formal PASS bằng 0. Trận 2
vào đúng session mới nhưng local turn đầu hết giờ; lượt local kế tiếp SWAP mana
được ACK, sau đó người dùng F9.

Đây không phải policy chọn PASS và cũng không phải provider thiếu bàn. Policy
đã chọn Sword an toàn lúc còn 13 giây. Preflight sau đó hủy cùng nước 41 lần
với `CLOCK_PAUSED/FX` đến hết lượt. Vòng chính dùng current duplicate state đã
unpause, còn opening preflight lấy `provider.last_published_state` đóng băng từ
MATCH_START lúc game vẫn đang pause trước khi đồng hồ bắt đầu.

Preflight nay dùng chính current provider state rồi mới refresh exact
MatchService identity/turn/timer. Board MATCH_START vẫn được cache, không thêm
scan; actionability của game vẫn được giữ và không click trong khoảng pause thật.
Offline regression là **1165/1165 PASS**. Cần live multi-match soak trước khi
chốt Phase 2; không commit/push/version bump. Xem
[báo cáo sự cố](phase2_b2_multi_match_opening_incident.md).

## Phase 2 b2 PASS_WAIT lock repair — chờ live soak (2026-09-12)

FarmRun `dcd4bc3c6d55430abee17139c4257e67` thắng bốn attempt đầu. Attempt 5
chọn một formal PASS hợp lệ ở turn 13 nhưng sau đó `PASS_WAIT` giữ khóa qua
turn 15 và 17 của local; hai lượt ấy không hề chạy policy hay gửi input, rồi
game đưa người chơi về lobby. Match 4 thực tế đã WIN; UI `Completed 4/5` là số
trận hoàn thành trước attempt lỗi.

Nguyên nhân là dispatcher callback mới trả observation không heap scan với
`scan_performed=false`, trong khi coordinator cũ chỉ công nhận heap scan là
một mẫu AFK hoàn chỉnh. Nếu payload AFK ngắn bị lỡ, coordinator không thể thoát
dù MatchService đã quay lại lượt local. Đây không phải board/solver/ACK failure:
attempt lỗi có sáu SWAP trước đó đều ACK và toàn run có 0 provider read/DTO/
stale/ambiguous error.

Production B5 nay công nhận cả dispatcher sample và bounded scan. Sau hai mẫu
ở lượt local kế tiếp mà AFK vẫn không tương quan, nó kết thúc trạng thái chờ,
giữ numeric idle là UNKNOWN và bắt buộc SWAP/CAST để cắt chuỗi zero-input.
Không có AFK không được diễn giải thành idle 0/1/2. Các stage acceptance khác
vẫn fail closed như cũ. Focused regression **122/122 PASS**, full regression
**1167/1167 PASS**. Phase 2 vẫn chưa chốt; cần live target 5 / attempts 8 để
xác nhận. Xem [báo cáo sự cố](phase2_b2_pass_wait_lock_incident.md).

## Phase 2 b2 missed EVOLVE response repair — chờ live soak (2026-09-12)

FarmRun `71526bd08c114d02b42a90129d60c2b1` thắng hai attempt đầu; attempt 3
được F9 sau khi người dùng thấy tool bỏ kiếm ở local turn thứ 6, game turn 11.
Toàn run có formal PASS bằng 0 và provider có 0 read/DTO/stale/ambiguous error.

Ở turn lỗi policy chọn EVOLVE lúc còn 13 giây, mana 210 và runtime cost 120.
Khoảng một giây sau input, exact MatchService state đã ghi bền vững
`LocalFusionLastAttemptTurn=11`, `LocalFusionLockedThisTurn=true` và
`LocalFusionUsed=false`, nhưng không giữ được transient `MATCH_FUSION_RES`.
Controller cũ chỉ nhận durable success, nên tiếp tục chờ response thất bại bị
hụt đến gần hết lượt và không chạy lại policy cho nước Sword.

Controller nay nhận một last-attempt mới đúng source turn, current-turn lock và
`used=false` là terminal `EVOLVE_FAILED`, đúng với native `HandleFusionRes`.
Sau settle trình bày 3.5 giây, nó đọc fresh board và tiếp tục cùng-turn policy;
không retry EVOLVE, không đoán idle state. Focused regression **108/108 PASS**,
full regression **1168/1168 PASS**. Phase 2 vẫn chưa chốt; cần live multi-match
soak xác nhận. Xem
[báo cáo sự cố](phase2_b2_evolve_response_miss_incident.md).

## Phase 2 b2 cross-match raw batch repair — chờ live soak (2026-09-12)

FarmRun `ff774dfb07134ca68789f46a25aed264` thắng bốn trận đầu. Attempt 5 bị F9
sau một Sword SWAP đã gửi nhưng không được game nhận. Formal PASS toàn run bằng
0 và provider không có read/DTO/stale/ambiguous error.

Evidence xác nhận board chéo trận: attempt 4 kết thúc ở `srvSeq=26` với hash
`9b5ad414...febe` và policy Sword `(5,0)<->(5,1)`. Attempt 5 sau đó dùng đúng
sequence, đúng hash và đúng move ở turn 13. Nguồn duy nhất là standalone
`RuntimeSequenceMonitor.WsCombatBatch`; object không có MatchId/Board owner/
transport witness nhưng được ACK 26 của trận mới cấp quyền nhầm. Click vì vậy
dựa trên board cũ và không tạo swap trên board thật.

Raw heap batch nay không được ACK-attest hoặc vào eligible set nếu thiếu exact
current-session witness. Nó chỉ còn telemetry; latest ACK thiếu DTO sẽ dùng
bounded current `Board.allDots` fallback hoặc fail closed. Provider-focused
regression **68/68 PASS**, full regression **1169/1169 PASS**. Phase 2 vẫn chưa
chốt; cần live multi-match soak. Xem
[báo cáo sự cố](phase2_b2_cross_match_heap_batch_incident.md).

## Phase 2 b2 post-Fusion Attack-slot repair — chờ live soak (2026-09-12)

FarmRun `f6af5b106e2949b7990ec52c2648dc7a` thắng ba attempt đầu. Attempt 4,
MatchId `M_721352fb`, tiến hóa thành công ở turn 13 nhưng không CAST lần nào.
Từ turn 15, game vẫn có ba selected CardUI chuẩn và native hand bốn ô, nhưng
pet hiện tại không xuất bản `FusionSkillCardData` pointer. Provider cũ buộc
layout thẻ thường phụ thuộc vào pet-skill identity nên xóa slot của Chưởng.

Ở turn 25 boss đã còn 23.124 HP, mana 560 và Chưởng cost 160; policy vẫn loại
Chưởng chỉ vì `uiLocated=false`. Sau nhiều SWAP, turn 35/37 tạo hai formal PASS
khi board không có safe move dù Chưởng vẫn hợp lệ trên giao diện. Turn Sword
trong ảnh cuối không bị bỏ: policy gửi Sword lúc `19:45:07.493Z`; F9 đến sau
khi game chuyển turn.

Provider nay tách hai capability: exact native CardUI rectangles của toàn bộ
`selectedCards` đủ cấp slot cho thẻ thường; pet skill vẫn fail closed riêng nếu
identity/slot của nó chưa được chứng minh. Dynamic CardUI gates và visual
preflight trước click vẫn giữ nguyên. Focused regression **111/111 PASS** và
bốn suite liên quan **206/206 PASS**; full regression **1172/1172 PASS**.
Phase 2 vẫn chưa chốt; cần live soak để xác nhận post-EVOLVE finisher CAST. Xem
[báo cáo sự cố](phase2_b2_post_fusion_attack_card_slot_incident.md).

## Detached empty-room → general hub recovery — offline PASS (2026-09-21)

Run `de3987ec515c4f7db3993990f0a5bc77` completed 44/50 wins, then the normal
close of a proven owner-free Chinh Phuc room shell returned to the general game
lobby instead of the island map. Attempt 45 never started; the old route timed
out because it recognized only the map and leave-confirm outcomes.

FarmRunner now recognizes the general hub only from two stable exact
`ManagerQuangTruong`/Button/native-geometry samples, sends one normal Chinh
Phuc click, then reuses the existing cached group/pet, PlayerPrefs panel and
hunt-order proof to select the immutable session target. The new capability is
single-use and requires the prior shell exit; generic `LOBBY_OTHER` cannot
authorize it. Focused verification is **102/102 PASS** and full regression is
**1363/1363 PASS**. Live recurrence remains pending. See
[general hub re-entry report](general_hub_chinh_phuc_reentry_report.md).

## Empty-room run 48 — b4 hub/map repair (2026-09-21)

Run `81fa84f56c7a45a7b6d2c0e7721309d7` completed 48/50, with 48 wins and no
loss/unknown/technical abort. Attempt 48 then reached a detached empty-room
shell; FarmRunner sent its one allowed `X`, landed in the owner-free general
hub, but stopped `RETURN_LOBBY_TIMEOUT` before opening Chinh Phuc.

Read-only live probing proved that the exact `ManagerQuangTruong.btnChinhPhuc`
was present and valid. Its idle bob changed only native TRS translation by
about 0.29 px during each ownership walk, which the byte-exact geometry fence
misclassified as a busy layout. The hub-only reader now permits at most 1 px of
translation jitter while ownership, active state, rotation, scale, Canvas and
two-sample rectangle agreement stay strict.

The b4 reverse also proved that `ManagerChinhPhuc.<>c__DisplayClass41_0`
inserted `islandLockMsg`, shifting `petId` to `+0x28` and manager ownership to
`+0x38`. The exact map resolver now uses the complete b4 `0x40`-byte closure.
Island selection remains session-target driven: cached `GroupDTO/PetEnemyDTO`
maps the pinned `pet_id` to its own group/index/name. No Dragon-Island constant
or fixed Starburst group is used. Focused regression is **110/110 PASS** and
full regression is **1366/1366 PASS**. Live recurrence follows.
