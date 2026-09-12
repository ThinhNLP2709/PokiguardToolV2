# Phase 3C.0 — Legend-card busy state and same-turn continuation audit

## Scope

This phase measures one unresolved boundary before Pet Skill can be combined
with normal board policy. It does not integrate Pet Skill into FarmRunner and
does not change the Phase 2 actionability gate. Live retry 4 proved that the
skill advances from the source local turn to the boss turn before the board is
actionable, so the audit now continues through that boss turn and checks the
next local turn as well as any same-turn state that may appear.

The accepted Phase 3B.3 primitive may execute exactly one current Pet Skill.
After current-generation CardUI runtime `PERFECT`, the harness sends no more
gameplay input. It keeps the read-only observer alive long enough to sample:

- the exact combat session, local actor and source turn;
- the proven-null `CardUI.ActiveDotSkillCard` edge;
- a fresh full provider publication after `PERFECT`;
- `Board.isUsingLegendCard`, `isUsingMega`, both Mega panel flags and the
  existing aggregate `board_modal_open`;
- the real Phase 2 `ActionabilityGate` result;
- a counterfactual gate result with only the Legend contributor removed.

The counterfactual is telemetry only. It never authorizes input and never
changes the state used by FarmRunner.

## Live B1 procedure

1. Start in the Starburst boss room with a Pet Skill-capable pet/profile.
2. Start the dedicated harness with:

   `python tools/pet_skill_action.py --c0-continuation-audit --timeout 1800 --continuation-timeout 60`

3. Enter one match and play/evolve manually until the Pet Skill card is
   current, usable and has enough Mana/Power.
4. The harness performs exactly one Pet Skill action: one card click, its
   current QTE directions, then one Space in the accepted Perfect window.
5. Do not make a board move after the skill. The harness observes the automatic
   boss turn and stops after a conclusive next-local-turn sample, or fails
   closed after the bounded timeout/session change.

After runtime Perfect, a temporary `Board`/`Active` gap is retained as missing
evidence only. The harness checks the exact control owner before a full-board
poll and waits within the continuation timeout. It never uses the gap as a
playable state and emits no post-Perfect input.

No Mana/Rage consumable is used. FarmRunner/BASIC must not run concurrently.

## Conclusive outcomes

- `SAME_TURN_ACTIONABLE`: the native Legend flag cleared and the unchanged
  Phase 2 gate accepted the fresh same-turn board.
- `SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH`: the exact Legend flag remained
  true, all other known modal contributors were false, the real gate returned
  `MODAL_OPEN`, and the same state passed when only that one contributor was
  removed for read-only comparison.
- `NEXT_LOCAL_TURN_ACTIONABLE`: the skill consumed the source turn and the
  unchanged Phase 2 gate accepted the next fresh local-turn board.
- `NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH`: the next fresh local-turn
  board was blocked only by the still-set Legend flag.

A boss turn after the skill is an intermediate observation. A session change,
turn regression or timeout before the next local-turn sample is inconclusive.
It does not justify changing the gate.

## Stop boundary

The live B1 run is complete after one conclusive same-turn or next-local-turn
outcome. Phase 3C.0 then uses that evidence to decide the smallest production
correction. It does not start
a second skill, issue a SWAP/CAST/PASS, enter another match, package, commit or
push.
