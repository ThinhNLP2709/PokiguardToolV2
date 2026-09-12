# Phase 3C.0 implementation and evidence report

Status: **PASS STRONG — live retry 5 conclusive; durable Legend latch corrected**

## Entry evidence

The user accepted the repaired default Phase 2 profile after FarmRun
`cddb3de3caef45dd8042d07cc28aab62` completed 5/5:

- five attempts, five wins, five strong and consistent terminal results;
- 50 SWAP sent / 46 acknowledged / four safely aborted on state change;
- five CAST sent / four accepted / zero rejected;
- six evolution attempts / four successes / two explicit failures;
- one policy PASS in the entire run;
- zero technical recovery, zero safe stop and final `BOSS_LOBBY`;
- `result_accounting_consistent=true` and
  `attempt_accounting_consistent=true`.

This closes the reopened default Phase 2 compatibility retest and authorizes
the next separately bounded phase.

## Reverse result

The 1.7.4-b2 declaration proves:

- `Board.isUsingLegendCard : bool` at `+0x391`;
- `Board.isUsingMega : bool` at `+0x398`;
- `Board.isMega2PanelOpen : bool` at `+0x129`;
- `Board.isMega1PanelOpen : bool` at `+0x470`;
- `CardUI.SetLegendMultiplier(float)` at RVA `0x6D0370`.

Cpp2IL output for this b2 directory contains declarations/RVAs but no method
body proving when `isUsingLegendCard` is cleared. Live retry 5 supplies the
missing runtime evidence: the field remains true after the QTE, through the
boss turn and into the next settled local turn.

## Implementation

`BattleState` carries the four exact native flags as telemetry. Normal,
non-board Fusion and QTE control publications populate them from the already
accepted read-only `BoardObservation`.

`Phase3c0RuntimeHook` reuses the accepted one-shot Phase 3B.3 executor. After
runtime `PERFECT`, it keeps the observer alive but sends zero further gameplay
input. It requires a proven inactive-QTE edge and a fresh full provider state
sampled after acceptance. The classifier evaluates the real Phase 2 gate and
a copy with only the Legend contributor removed; the copy is never published
or executed.

Retry 5 proved that `isUsingLegendCard` is a durable latch rather than an
ordinary-board modal blocker. The production `board_modal_open` aggregate now
contains only `isUsingMega`, Mega1 panel and Mega2 panel. Exact Legend telemetry
is retained. Presentation, cascade, clock, turn, lifecycle, board-state and all
other actionability checks are unchanged.

The explicit audit CLI authority is `--c0-continuation-audit`. It is mutually
exclusive with the existing one-shot and B4 modes. Starting inside combat is
rejected; the normal boss-lobby baseline remains mandatory.

## Offline verification

- correction-focused provider/actionability/continuation tests: **103/103 PASS**;
- full regression: **1189/1189 PASS**;
- `compileall`: PASS;
- `git diff --check`: PASS.

The focused runtime test proves one card click and one Space through the
accepted primitive, continued observation after `PERFECT`, isolation of a
Legend-only modal block, and no input-count increase during the post-Perfect
audit.

## Live B1

The audit series is complete. No FarmRunner Pet Skill integration, version
bump, packaging or push has been made.

### B1a — valid Perfect, terminal before continuation sample

Match `M_008ec67b`, source turn 47 used the `NORMAL -> LEGENDARY` path and
current Huyền Thoại 7 card. The harness observed 260 Mana / 250 Rage, emitted
one card click, confirmed 7/7 directions, sent one Space at 3.1857 seconds
inside the 3.0--3.3 Perfect window and read current runtime `PERFECT`.

The boss had 49,620 / 84,180 HP immediately before the skill. The skill ended
the match about 0.48 seconds after Perfect, so current Board/session ownership
disappeared before a proven-null QTE edge and fresh same-turn board could be
published. The audit correctly stopped inconclusive with
`POST_PERFECT_CONTEXT_INVALIDATED:ACTIVE_COMBAT_OWNERSHIP_INVALID`; it emitted
zero post-Perfect gameplay input.

The control sample at Perfect read `isUsingLegendCard=false`. This is useful
partial evidence that the field is not unconditionally latched through QTE
completion in this path, but terminal cleanup prevents it from proving normal
same-turn board actionability. Retry must preserve substantially more boss HP
by avoiding Sword/default attack while collecting the 120 evolution Mana and
the Huyền Thoại 7 skill requirement of 200 Mana / 200 Rage.

### B1 retry 1 — second valid Perfect, terminal again

Match `M_db2929ab`, source turn 19 reached Huyền Thoại 7 with 330 Mana /
250 Rage. The boss still had 69,276 / 84,180 HP before the skill. The harness
again emitted one card click, confirmed 7/7 directions and sent one Space at
3.1729 seconds inside the 3.0--3.3 window. Runtime returned `PERFECT` and the
exact control sample again read `isUsingLegendCard=false`.

The skill also killed this boss, invalidating combat ownership about 0.60
seconds after Perfect and before a fresh same-turn board. The result is a
second valid terminal-path sample, still inconclusive for same-turn
continuation. Post-Perfect gameplay input remained zero. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry1.jsonl`.

The next retry must use a boss with materially more than 84,180 maximum HP.
The current harness is stopped while the operator changes boss rooms so that
the next observer starts from the required exact lobby baseline.

### B1 retry 2 — valid Perfect exposed a post-Perfect observer defect

Match `M_2ce69ae9`, source turn 53 used Huyền Thoại 7 against the higher-HP
boss. Immediately before the skill the boss had 248,555 / 509,272 HP; the
player had 518 Mana / 250 Rage. The harness emitted one card click, confirmed
7/7 directions, sent one Space at 3.154079 seconds inside the 3.0--3.3 window,
and read current runtime `PERFECT`. The last exact QTE sample still showed the
boss at 248,555 HP, so the audit stop 0.246 seconds later was not evidence that
this skill killed the boss.

The stop exposed an audit routing defect. Immediately after the accepted
result, it called the normal full provider before first retaining the exact
control owner. A temporary `Board`/`Active` gap during the Legend animation
therefore invalidated the provider lifecycle epoch and the audit stopped at
the first gap with
`POST_PERFECT_CONTEXT_INVALIDATED:ACTIVE_COMBAT_OWNERSHIP_INVALID`. The skill
itself remained a valid one-click, one-Space Perfect and post-Perfect gameplay
input remained zero. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry2_high_hp_boss.jsonl`.

The corrected route checks `poll_qte_control(expected_session)` before any
full-board poll. If `Board`/`Active` is temporarily absent, it records a
bounded ownership gap and performs no full poll or input. Only after the exact
control owner returns may the normal provider publish a fresh board. Four new
tests cover gap retention, fail-closed timeout, control-before-full ordering
and the recovered full-board path. Full regression is 1183/1183 PASS;
`compileall` and diff check pass.

Retry 3 waited 30 minutes in the read-only-proven boss lobby, timed out with
no match, no action and no input. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry3_transient_fix.jsonl`.

### B1 retry 4 — Perfect valid; Pet Skill advances to the boss turn

Match `M_6c640335`, source turn 23 used Huyền Thoại 7 with 300 Mana / 210
Rage. The harness emitted one card click, confirmed 7/7 directions with no
wrong, missing, duplicate, stale, unconfirmed or blind-retry input, and sent
one Space at 3.152554 seconds inside the 3.0--3.3 Perfect window. Current
CardUI runtime returned `PERFECT`.

The corrected control-first route remained in the same lifecycle/session;
there was no post-Perfect ownership invalidation. A proven-null QTE edge was
observed 1.216 seconds after Perfect. At that point the exact runtime had
already advanced from local source turn 23 to boss turn 24. Full-provider
polls were short and continuous (normally 31--297 ms), but publication stayed
closed under `presentation_busy_or_batch_pending` until the effect settled.
The first stable board at turn 24 had `isUsingLegendCard=true`, all three other
known modal flags false, and the boss owned the turn. Therefore the run proves
that this Pet Skill consumes/ends the source turn; it cannot prove a same-turn
board continuation. Post-Perfect gameplay input remained zero. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry4_transient_fix.jsonl`.

The audit now treats the boss turn as an intermediate read-only state and
continues to the next local turn. It can conclude either that the unchanged
Phase 2 gate is actionable there or that it is blocked only by the retained
Legend flag. The bounded wait is 60 seconds. Three new tests cover boss-turn
retention and both next-local-turn outcomes; Phase 3C.0 is 14/14 and the full
suite is 1186/1186 PASS, with compileall and diff check passing.

### B1 retry 5 — conclusive next-local-turn evidence

Match `M_d5a467a1`, source turn 17 used Huyền Thoại 7 with 245 Mana / 250
Rage. The accepted action emitted one card click, confirmed all 7/7 directions
and sent one Space at 3.152790 seconds inside the runtime Perfect window.
Wrong, missing, duplicate, stale, unconfirmed and blind-retry direction counts
were all zero; current runtime returned `PERFECT`.

The audit observed the intervening boss turn 18 and then local turn 19. During
the turn-introduction pause, ordinary presentation and clock gates correctly
remained closed. At `2026-09-12T08:30:26.207Z`, the next local board was ready,
settled, current and otherwise actionable: `isUsingMega=false`, both Mega panels
were closed, presentation was idle, clock was running and
`clientMoveAllowed=true`. Only `isUsingLegendCard=true` remained. The real
aggregate returned `MODAL_OPEN`; the telemetry-only counterfactual that removed
only that contributor returned `PASS`. Verdict:
`NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH`, conclusive true.

Post-Perfect gameplay input was zero. The harness stopped normally after the
conclusion. Artifact:
`logs/phase3c0_legend_card_continuation_20260912_live_b1_retry5_next_local_turn.jsonl`.

This closes Phase 3C.0. The evidence also confirms that this Pet Skill consumes
the source turn. Integrating Pet Skill into BASIC/FarmRunner belongs to the
separate Phase 3C.1 scope.

## Closeout

The user accepted the completed live run and explicitly authorized the phase
commit on 2026-09-12. Phase 3C.0 is closed at **PASS STRONG**. The commit also
captures the accumulated 1.7.4-b2 Phase 2 compatibility repairs that passed the
accepted 5/5 default-profile run. There is no release tag, package, version bump
or remote push in this closeout. The final task response supplies the resulting
commit SHA.
