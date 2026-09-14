# Phase 3C.1 — BASIC Pet-Skill Policy + FarmRunner Backend Integration

Status: **PASS STRONG**

Phase 3C.1 base commit:
`9ba2abd951f0982a4c262578f734e6cddd89ec0e`.

## Scope

The enabled Pet Skill profile is deliberately narrow:

`LEGENDARY / NONE / PET_SKILL / BASIC`.

Audition V3 is the default QTE mode. It follows the current b4 `LR` protocol
and accepts only Left, Right and Space through the existing bounded foreground
input boundary. Audition V2 remains available as the explicit
`audition_v2` four-direction compatibility option in Preferences and CLI.
One action is bound to exactly one generation; the observer never mixes V2
and V3 fields.

All game-state access remains read only. This phase adds no process write,
injection, IL2CPP invocation, direct game call or network manipulation.

## Policy and FarmRunner integration

`PET_SKILL` is a distinct turn-consuming action. The exact profile disables
EVOLVE and every ordinary Attack CAST. A proposal requires one current-session,
unique, actionable capability in the supported automatic-dot family, with
current runtime Mana/Rage costs. Unknown, stale, ambiguous or unsupported
state returns `NONE`.

If the skill is not ready, Sword remains first. The resource branch considers
only deterministic Sword-safe Mana/Rage gains toward current deficits. Health,
Drain, Shield, PASS and mandatory-action handling retain their established
order.

One serialized `PetSkillFarmDispatcher` maps a fresh policy proposal to one
`run_embedded_policy_action`. Card click, directions and Space share the
FarmRunner gameplay permit. A rejection before physical input releases the
permit and requires a fresh read. Any result after the card click closes the
source turn and forbids fallback or blind retry. A runtime Perfect then waits
for an authoritative boss turn, terminal state or a fresh later local turn.
Pending QTE state is never persisted in a checkpoint.

Desktop configuration, saved Preferences, FarmRunner argv, the embedded BASIC
controller, the Pet Skill action and the shadow observer now carry the same
`audition_mode`. Desktop Start/Resume accepts only the exact Pet Skill profile
above; multi-source and other unfinished Pet Skill profiles continue to fail
closed.

## Audition V3 runtime evidence

The b4 reverse declares a separate `PokiGuard.Audition` system. The reader
binds all of the following before a direction can be sent:

- current `AuditionStage.Active` and its exact `CardUI.ActiveDotSkillCard` host;
- current Board, Active, actor, card and MatchId/session ownership;
- exact server layout `LR` and positive challenge ID;
- equal server/display timing windows, reverse index, Great threshold and
  multipliers;
- the game-built `AuditionChallenge.Expected` list, rather than recomputing
  reversal from `Display`;
- stable stage cursor/correct count, press history and elapsed clocks.

Only `nutLeft` and `nutRight` are valid in V3. A class, owner, list, timing,
clock or stable-reread mismatch revokes the action. V2 retains its former
CardUI observer and four-direction key set behind `audition_v2`.

## Offline verification

- complete regression: **1222/1222 PASS**;
- dedicated Audition V3 reader/tracker tests: **7/7 PASS**;
- configuration/UI/checkpoint/QTE focused set: **91/91 PASS**;
- `python -m compileall -q src tools tests`: PASS;
- `git diff --check`: PASS;
- source version: `1.0.46`.

Coverage includes default V3 selection, V2 preference persistence and CLI
forwarding, exact profile gates, game-built Expected-list use, V2/V3 generation
separation, dynamic challenge length, tapped Perfect state, non-LR rejection,
current b4 QTE-result DTO offsets, single-owner dispatch, zero/after-input
semantics and the full Phase 2 default regression.

## Live status

Live B1 has reached the Pet Skill card in two bounded attempts, but still needs
a clean retry. Run `4ccd4bf95ce04cd0a9f30705b1af13db` exposed an internal
telemetry error: the resource-progress event read `skill_card_id` from
`DecisionTrace` instead of its owning `PolicyDecision`. The runner stopped
safely after two gameplay inputs. That field ownership is corrected and covered
by a live-telemetry regression.

Run `f740e9c51fb845d7a9fe2c8ea1de5a6b`, match `M_295cb4ba`, then reached turn
19 with Mana/Rage `237/250` and clicked Huyền Thoại 7 exactly once. It emitted
zero direction keys and zero Space because the server challenge reader rejected
the runtime value `ServerQteReverseFrom = -1`. Read-only post-stop memory showed
an otherwise coherent b4 window (`5000`, `3000..3300` Perfect), Great `150`,
and multipliers `1.5/1.2/0.8`. Native `AuditionChallenge.FromService` at RVA
`0xBD7EF0` initializes `ReverseFrom` to `-1`, preserves that sentinel, and skips
reversal whenever it is negative. The reader now accepts the exact `-1`
no-reverse sentinel while continuing to reject other negative values. See
[phase3c1_audition_v3_reverse_sentinel_incident.md](phase3c1_audition_v3_reverse_sentinel_incident.md).

Run `7f8cf5fc45484cb394017fa5900a49a1`, match `M_885acd58`, proved the server
challenge repair: no challenge read was rejected. The card was clicked once,
but zero directions and zero Space followed because the stage reader rejected
the normal pre-tap value `CardUI._auditionV3ElapsedMs = -1`. Native b4 code
sets this exact sentinel in both the CardUI constructor and each QTE startup;
`CurrentQteElapsedMs` derives time from the live clock while it is negative,
and `OnAuditionTap` replaces it with the tap time. The reader now accepts exact
`-1` only before tap and requires bounded stage/host equality after tap. See
[phase3c1_cardui_elapsed_sentinel_incident.md](phase3c1_cardui_elapsed_sentinel_incident.md).

Run `17e9a8761c6e477ca8fee7436d4b2924`, match `M_d5c84deb`, then proved the
direction path: all seven `LEFT/RIGHT` inputs were authoritatively confirmed,
with zero wrong, skipped or duplicate directions. The action completed them at
QTE elapsed `1.217 s` and waited for the `3.000..3.300 s` Perfect window. At
`3.054240 s`, the reader rejected `Tapped=false`, `_wasPerfect=true`, and
`_grade=null`, so it sent no Space. Native `TickBar` proves `_wasPerfect` is
the live in-zone highlight before tap; `ShowResult` writes `_grade` only after
grading. That false relationship is removed and covered by regression. See
[phase3c1_stage_perfect_highlight_incident.md](phase3c1_stage_perfect_highlight_incident.md).

Run `b77eb786333345418e379777bf78cddd`, match `M_79773863`, live-proved the
complete V3 action. The tool clicked the card once, sent and authoritatively
confirmed all seven expected Left/Right inputs, sent Space once at `3.185 s`
inside the `3.000..3.300 s` Perfect window, and received runtime `PERFECT`.
There were zero wrong, skipped, duplicate, stale or unconfirmed directions and
zero gameplay safety violations. The skill killed Starburst in one use;
read-only terminal evidence captured boss HP `0`, local HP `38134`, UI text
`Thắng`, result `WIN`, and confidence `STRONG` before cleanup.

FarmRunner nevertheless stopped at the result screen because its adapter
accepted only the older `FULL_MATCH_PASS` and `B5_PASS_STRONG` classifications.
The Phase 3C.1 controller correctly returned `FULL_COMBAT_COMPLETED`, so the
adapter rejected a proven safe completion before result confirmation. The
validator now accepts that exact success classification while retaining all
terminal, session-cleared, pending-action, postmatch and zero-safety checks;
`FULL_COMBAT_COMPLETED_WITH_SAFETY_FINDING` remains rejected. The captured live
log now replays as `POSTMATCH_RESULT_UI_REQUIRED`. See
[phase3c1_full_combat_classification_incident.md](phase3c1_full_combat_classification_incident.md).

Live B1 requires the operator to equip the Legendary main pet, choose no
evolution target, and enter the intended Chinh Phuc boss room. The accepted
command and audit criteria are in [phase3c1_runbook.md](phase3c1_runbook.md).
Corrected run `6bcf4d8efa9a4e129cc32aa492a17b6a`, match `M_8ba50c47`, completes
Live B1. It recorded `1/1 WIN`, ten acknowledged SWAPs, one Pet Skill proposal,
one runtime Perfect, zero EVOLVE, zero ordinary CAST and zero PASS. The fresh
V3 sequence was `RIGHT, RIGHT, RIGHT, RIGHT, RIGHT, LEFT, LEFT`; all seven
directions were confirmed with zero wrong/skipped/duplicate/stale/unconfirmed
input. Space was sent exactly once at `3.168 s`, only `0.018 s` from the target.
FarmRunner accepted `FULL_COMBAT_COMPLETED`, captured a strong terminal WIN,
confirmed the result UI once, proved memory/UI consistency, and returned to the
exact Starburst `BOSS_LOBBY` through two stable frames. All FarmRunner safety
counters are zero and no worker remains.

A direct B2 launch `898893e819c145cda964315071a83391` did not enter combat
because the game window was never foreground. It ended with `ENTRY_TIMEOUT`,
zero entry clicks, zero attempts and zero gameplay inputs, so it is operational
telemetry rather than B2 evidence.

Fresh B2 FarmRun `360e3ef223fc4f5eba5ca93d1cd2d490`, MatchId `M_031645fd`,
then completed `1/1 WIN` and returned to the exact Starburst `BOSS_LOBBY`.
This session used a new Board instance and fresh CardUI/QTE generation. The
policy chose six acknowledged SWAPs, including three logged Sword-safe Rage
progress moves while Mana was already sufficient: missing Rage `200`, `120`,
then `30`, with zero readiness credit assigned to Mana. At turn 13, current
Mana/Rage `210/230` satisfied the runtime HT7 `200/200` requirements and the
policy proposed one Pet Skill.

The B2 QTE clicked the card once, read the fresh seven-direction sequence
`LEFT, RIGHT, RIGHT, RIGHT, RIGHT, LEFT, LEFT`, and authoritatively confirmed
all seven inputs. Wrong, skipped, duplicate, stale, unconfirmed and blind-retry
counts were all zero. Directions completed at `1.284 s`; Space was sent once at
`3.168 s`, `0.018 s` from the `3.150 s` target and inside the
`3.000..3.300 s` Perfect window. Runtime result was `PERFECT`, the skill killed
the boss, and no same-source-turn follow-up occurred. FarmRunner captured boss
HP `0`, a strong WIN, consistent `Thắng` UI, one postmatch confirmation, and
returned to `BOSS_LOBBY`. Every gameplay and FarmRunner safety counter is zero.

Across accepted B1+B2 there are two completed fresh MatchIds, two Pet Skill
successes, two runtime Perfects, two single Space presses, `16/16` acknowledged
SWAPs, zero EVOLVE, zero ordinary CAST, zero PASS, zero old CardUI/QTE reuse,
zero same-source-turn follow-up, zero extra attempt, and consistent `2/2 WIN`
accounting. Both skills naturally terminated their matches, so a post-skill
next-local-turn continuation is `NOT_OBSERVED`; Phase 3C.0 already proves that
Legend-latch boundary.

The separate default BASIC smoke was not repeated. The immediately preceding
b4 compatibility run `a6d3f398cd0b4cb4bb009ead46d83601` already completed a
strong default `NORMAL / NORMAL / DEFAULT_ATTACK` `1/1 WIN` on the same exact
b4 runtime, and the complete regression covers profile isolation. No package,
tag, five-match UI soak, performance comparison or 25-match soak was run.
