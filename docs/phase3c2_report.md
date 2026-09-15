# Phase 3C.2 — Desktop UI ↔ FarmRunner Pet-Skill Integration

Status: **PASS STRONG**

Phase 3C.2 base commit:
`2237d1f657b97ad13e4b2eb0fb71f5535b3aa795`.

Source version: `1.0.47`.

## Scope

The normal Desktop path supports exactly:

`LEGENDARY / NONE / PET_SKILL / BASIC`.

Audition V3 remains the default and Audition V2 remains optional. The default
`NORMAL / NORMAL / DEFAULT_ATTACK / BASIC` and no-evolution default-Attack
profile remain supported. Evolved, Mega, evolution-target skill and ambiguous
multi-source Pet Skill profiles remain blocked.

The user clarified that a future two-source loadout must expose distinct
main-pet and evolution-pet skill choices inside **Thẻ sát thương**. That
two-source design is outside this phase; the current unique-source compatibility
value remains sufficient for the exact Phase 3C.2 profile.

## Desktop integration

Repository audit found that the accepted Phase 3C.1 source had already joined
the required path: Desktop draft → immutable `DesktopConfig` → single-owner
`DesktopFarmControllerManager` → normal `tools.farm_run` → BASIC policy →
`PetSkillAction`. Phase 3C.2 locks that behavior with profile-specific tests
and acceptance telemetry; it does not add another controller, executor or
policy implementation.

Start and Resume use the canonical `farm_policy_supported` gate. The exact
profile is runnable; unsupported and multiple-source profiles remain blocked.
After Start, controls are disabled and programmatic draft drift is overwritten
from the pinned immutable config. The production adapter forwards
`legendary`, `none`, `pet_skill`, `basic` and default `audition_v3` without a
ManaPriority or default-Attack conversion.

Graceful and Emergency actions retain the existing shared control edges.
Emergency revokes the same input authority consumed by FarmRunner and
PetSkillAction. Checkpoints persist only `GameplayConfig` intent and counters;
they do not persist ActionId, CardUI, QTE generation, sequence, timing window
or input lease.

## Offline verification

- final Phase 3C.2 focused set: **158/158 PASS**;
- dedicated Audition V3 set: **9/9 PASS**;
- Audition V2 preference/config/controller compatibility: **3/3 PASS**; no V2
  live run was required;
- complete regression: **1236/1236 PASS**;
- `python -m compileall -q src tools tests`: PASS;
- `git diff --check`: PASS.

Coverage added for a real Desktop Start freezing the exact Pet Skill profile,
one production FarmRunner adapter receiving the exact profile and V3 default,
single-controller rejection of duplicate Start, and Pet Skill checkpoint
round-trip with fresh runtime discovery.

## Live acceptance

Live operation is reserved for the user. No Codex-driven live run is accepted
as Phase 3C.2 evidence. The required incremental stages are in
[phase3c2_runbook.md](phase3c2_runbook.md).

B1 status: **PASS**. The user selected the exact
`Huyền thoại / Không tiến hóa / Thẻ skill của pet / BASIC / audition_v3`
profile through the normal Desktop UI. Canonical validation reported the
configuration supported and enabled Start; this configuration-only gate sent
zero gameplay input.

The first user-operated B2 candidate, farm run
`aa38f8cc703b402e81b7dfdde6543022`, won one match and stopped at the exact
target with all FarmRunner safety counters at zero. It is not accepted as B2:
the Pet Skill action clicked once and obtained authoritative ACKs for all seven
directions, but sent no Space and ended
`ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS`. The exact reader diagnostic was
`AuditionStage changed during read` at the Perfect-zone transition.

The V3 native model already proves `AuditionStage._wasPerfect` is a live UI
highlight updated by `TickBar` while the stage is untapped. It is now excluded
from the reader's stable ownership/progress signature, like the live QTE clock.
Tap state, tap elapsed, owner, challenge, cursor, duration and grade remain in
the torn-read guard. Dedicated tests cover an accepted highlight transition
and a rejected tap transition.

The repaired user-operated B2 retry is accepted from farm run
`97ba42e804794bd8bb136ad3c64707af`, match `M_20733f02`:

- exact `legendary / none / pet_skill / basic / audition_v3` config;
- one attempt, one completed match, one STRONG/CONSISTENT win and final
  `BOSS_LOBBY` with `FARM_TARGET_COMPLETED`;
- one Pet Skill card click, seven of seven directions authoritatively
  confirmed, zero wrong/skipped/duplicate/stale/unconfirmed directions;
- one Space at QTE elapsed `3.186 s` inside the `3.0..3.3 s` Perfect window;
- runtime result `SUCCESS_PERFECT / CURRENT_GENERATION_RUNTIME_PERFECT`;
- zero default casts, evolution attempts, passes, technical aborts and all
  FarmRunner safety counters zero.

B2 status: **PASS**. B3 through B6 are accepted below.

The first user-operated B3 candidate is farm run
`8cccd2b11b944e3c97f487040e575d58`. Its gameplay portion is clean:

- exact target `5`, max attempts `8`; exactly five attempts and five completed
  STRONG/CONSISTENT wins, with five entry clicks and no sixth attempt;
- 43 SWAPs sent, 41 acknowledged and two safely aborted on state change;
- three naturally actionable Pet Skills, all `SUCCESS_PERFECT`, with 21/21
  directions confirmed, three in-window Space presses, and zero wrong,
  skipped, duplicate, stale or unconfirmed directions;
- the other two bosses died before policy selected a Pet Skill;
- zero default casts, evolution attempts, passes, technical aborts, result
  conflicts and every FarmRunner safety counter zero.

After result accounting for match five, the server removed the live room and
left Unity on an empty detached room shell. The exact-room waiter returned
`DETACHED_ROOM_SHELL_CANDIDATE`; the existing map-return route ran but current
runtime target discovery was `null`. It therefore sent no shell/map input and
ended `SAFE_STOP / RETURN_LOBBY_TIMEOUT`, final lifecycle `UNKNOWN`. This is
the required fail-closed behavior for insufficient target proof, but it does
not satisfy the Phase 3C.2 B3 requirement that the same five-match run finish
at proven `BOSS_LOBBY / controller STOPPED`.

B3 gameplay: **PASS**. B3 final-lifecycle gate: **NOT PROVEN — RETRY REQUIRED**.

The next user-operated B3 retry is farm run
`b4a4270d8b6340c6a542ac8e0d0c132b`. It reproduced the same server teardown
after match two and stopped at 2/5:

- two attempts, two completed STRONG/CONSISTENT wins;
- 15 SWAPs sent and acknowledged, two naturally actionable Pet Skills and
  both `SUCCESS_PERFECT`;
- zero casts, evolution attempts, passes, technical aborts, result conflicts
  and every FarmRunner safety counter zero;
- postmatch detection again returned `DETACHED_ROOM_SHELL_CANDIDATE` with the
  exact stale Starburst room, no combat session and no room owner;
- `discover_chinh_phuc_map_target(1289)` returned `null`, so the old route
  rejected before reserving any shell-exit or target-select input and ended
  `SAFE_STOP / RETURN_LOBBY_TIMEOUT`.

Two independent live failures establish the new server ordering: room
ownership and the island-map Button closures can disappear while Unity still
renders the exact detached room shell. Re-entry is now split into two bounded
proof stages. Stage one permits one shell-close click only after an atomic
reread of the exact owner-free stale Starburst room and two stable room-shell
frames; absent map objects are accepted only for this exit step. Stage two
still requires a unique clean Button closure, matching cached
GroupDTO/PetEnemyDTO/PlayerPrefs data, the runtime-derived hunt-order badge in
two stable frames, and an atomic identity reread before selecting the target.
Wrong pet, active combat ownership, dirty runtime data and runtime identity
changes all fail closed. A leave-confirm modal, when present, receives the
same runtime reread before its one permitted click.

The third user-operated B3 candidate is farm run
`3363fd3ea1cc49b19d43ba4937541adc`. It again reached two clean wins before
the server produced the detached shell. This run proves the first repair did
authorize and send exactly one shell-close input:

- 2/5 STRONG/CONSISTENT wins, 25 SWAPs sent, 24 acknowledged, two Pet Skills
  both `SUCCESS_PERFECT`, and every safety counter zero;
- the captured `1280x640` frame contains one exact lower-center Start control
  and one top-left circular X at normalized point `(0.08828125, 0.07890625)`;
- `BOSS_ROOM_SHELL_EXIT` was reserved once and the normal X click reported
  `SENT`; no shell-confirm or boss-target click was sent;
- the following settle loop emitted
  `chinh_phuc_room_shell_transition_rejected` in the same millisecond. Its
  only loop guard was `process.is_running()`, so no post-click frame was read;
- two known-empty pre-shell map scans also delayed the X click by roughly 105
  seconds after detached-shell classification.

The re-entry flow now skips every map-object scan while the exact detached
shell is still open. It closes the shell after the existing atomic stale-room
and two-frame visual proof, then checks the bound HWND/PID/geometry directly
during the post-click transition instead of allowing one diagnostic process
sample to skip the loop. A leave modal is detected and confirmed before any
expensive scan. On a direct map transition, the clean target runtime returned
by discovery is carried forward so it is not scanned a second time merely to
locate the same badge. The final atomic runtime reread remains mandatory before
the boss-target click.

The updated repair is offline-clean at **1236/1236** tests plus compileall and
diff checks.

The accepted user-operated B3 run is
`feff9bffa0794632a655cc9dc6bc7b6b`:

- immutable config was exactly
  `legendary / none / pet_skill / basic / audition_v3` against Starburst
  `1289`, with target `5` and max attempts `8`;
- exactly five attempts produced five completed STRONG/CONSISTENT wins,
  five entry inputs and five postmatch confirmations; there was no sixth
  attempt;
- 55 SWAPs were sent, 54 were acknowledged, none were rejected and one was
  safely aborted when the terminal state changed;
- four naturally actionable Pet Skills completed as `SUCCESS_PERFECT`; the
  fifth boss died before the skill became actionable;
- the four successful actions used exactly four card clicks, 28/28 confirmed
  directions and four Space presses inside the Perfect window;
- wrong, skipped, duplicate, stale and unconfirmed directions were all zero;
  blind retries, duplicate/out-of-window Space and same-source follow-up were
  all zero;
- one initial capability preflight in match one rejected before input, then a
  fresh current capability completed Perfect; it produced zero clicks, keys
  or Space and is retained as safe fail-closed telemetry;
- default Attack CAST, EVOLVE and PASS were all zero; wrong-turn, stale,
  duplicate, partial, postmatch, lobby and after-combat gameplay inputs were
  all zero;
- technical aborts, recoveries, exits, safe stops, result conflicts and UI
  error events were zero; maximum simultaneous controllers was one;
- final state was `FARM_RUN_COMPLETE / FARM_TARGET_COMPLETED`, exit code `0`,
  proven `BOSS_LOBBY`, controller `STOPPED`.

This accepted run did not encounter the server's detached room shell. Per the
user's scope decision, a future recurrence and re-entry validation belong to a
separate follow-up scope and do not keep Phase 3C.2 B3 open.

B3 status: **PASS**. B4 through B6 are accepted below.

The user-operated graceful-stop B4 run is
`8c0b3a53985a4e6db04254de6562624b`, match `M_87234dab`:

- Desktop immutable config was exactly
  `legendary / none / pet_skill / basic / audition_v3`, target `3`, max
  attempts `5` against Starburst `1289`;
- `request_graceful_stop` was accepted once at
  `2026-09-14T19:49:50.898Z`, during the first active match;
- the first match continued to normal postmatch and produced one
  STRONG/CONSISTENT win; policy did not naturally reach Pet Skill readiness
  before the boss died;
- FarmRunner sent one boss-entry input, 20 SWAPs, one postmatch confirmation
  and no second boss entry or second attempt;
- final run and checkpoint state were
  `FARM_RUN_COMPLETE / STOPPED_GRACEFULLY`, with one completed match and
  `BOSS_LOBBY / STOPPED`, exit code `0`;
- no CAST, EVOLVE, PASS, technical abort/recovery, result conflict, UI error,
  wrong-turn, stale, duplicate, partial or after-combat input occurred.

B4 status: **PASS**. The Desktop UI was later closed normally while idle;
its summary records zero UI errors, zero worker Tk writes, poller dead after
close and game process untouched. The final B6 acceptance after B5 is recorded
below.

The first B5 candidate, farm run
`e4fbbb16840348a3bf5a80e8da438bf7`, is **NOT B5 EVIDENCE**. Its immutable
Desktop/checkpoint config remained
`legendary / none / pet_skill / basic / audition_v3`, while the live loadout
no longer exposed that Pet Skill capability. The backend therefore stopped
fail-closed on the first local turn with
`PET_SKILL_CAPABILITY_UNAVAILABLE / COMBAT_SAFE_STOP`: zero gameplay inputs,
zero completed matches and no PetSkillAction. The game subsequently returned
to proven `BOSS_LOBBY` with the controller stopped. No policy or input failure
occurred, but B5 must be rerun after explicitly selecting the default profile
in the Desktop UI before Start.

The accepted user-operated B5 retry is farm run
`15a10dc9bbf34626958b0f4ccec41ebd`, match `M_b9673a27`:

- immutable config was exactly
  `normal / normal / default_attack / basic / audition_v3`, target `1`, max
  attempts `2` against Starburst `1289`;
- exactly one attempt produced one completed STRONG/CONSISTENT win, one entry
  input and one postmatch confirmation, with no extra match;
- nine SWAPs were sent and all nine were acknowledged;
- default BASIC proposed and sent one ordinary Attack card; the match ended in
  a win before a separate acceptance/rejection event was retained, and no
  same-turn SWAP followed the cast;
- Pet Skill proposals, attempts, card clicks and QTE inputs were all zero;
- EVOLVE and PASS were zero; every gameplay safety counter and UI error event
  was zero;
- final state is `FARM_RUN_COMPLETE / FARM_TARGET_COMPLETED`, exit code `0`,
  proven `BOSS_LOBBY`, controller `STOPPED`.

B5 status: **PASS**. B6 is accepted below.

The user then closed the idle Desktop UI normally. Artifact
`logs/desktop_ui/20260915_172841/summary.json` records:

- final runtime `BOSS_LOBBY`, controller `STOPPED`, FarmRunner complete and no
  active match/session;
- `ui_idle_close_requested` → `ui_shutdown_started` → `poller_stopped` →
  `ui_closed` → `desktop_ui_process_finished`;
- poller alive after close `false`, worker-thread Tk writes `0`, handled UI
  errors `0`, unhandled UI-thread exceptions `0`, unexpected error `null`;
- the Desktop/FarmRunner/PetSkill worker processes were absent after close;
  the exact game process remained running and untouched.

B6 status: **PASS**.

## Closeout classification

Phase 3C.2 is **PASS STRONG**. B1 through B6 passed through the normal
user-operated Desktop path. The accepted Pet Skill profile is now a normal
supported mode, the default BASIC profile remains supported, all live safety
counters are clean, and the final Desktop shutdown leaves only the game.

Known `NOT_OBSERVED` items remain HT2 full live, non-terminal next-local after
Pet Skill, recovery during a Pet Skill farm, other skill families, performance
advantage and energy saving. The accepted B3 did not encounter detached-room
re-entry; any future recurrence is a separate follow-up scope by user decision.

No package, tag, performance comparison or 25-match soak has been performed.
