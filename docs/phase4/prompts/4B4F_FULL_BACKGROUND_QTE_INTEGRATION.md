# Phase 4B.4F — Full Background QTE Integration

Implement and validate **Phase 4B.4F ONLY**.

Entry gate:

- 4A.2 = `FULL_BACKGROUND_CAPABLE` with PASS STRONG;
- 4B.3 PASS STRONG;
- capability matrix confirms background card, every direction and Space.

Nếu bất kỳ gate nào thiếu, không dùng prompt này; route sang 4B.4H hoặc
remediation.

## 1. Exact goal

Nối proven background keyboard transport vào Pet Skill controller hiện tại mà
không thay ownership, QTE state machine, Perfect timing hay policy.

## 2. Mandatory invariants

- exact current MatchId/session/card/QTE generation;
- direction vocabulary closed;
- one direction, then authoritative `currentIndex/correctCount` ACK;
- no next direction before ACK;
- no retry of uncertain direction;
- Space only after complete sequence and proven current Perfect interval;
- one Space, server/runtime timingResult correlation;
- Emergency Stop ACK prevents all new card/direction/Space input;
- lifecycle/session/focus-mode change invalidates pending action;
- background path never moves cursor or steals foreground;
- foreground Pet Skill behavior remains unchanged.

## 3. Tests

Cover full state machine for both foreground/background:

- every direction accepted;
- missing/wrong/delayed ACK;
- stale QTE/session;
- duplicate direction/Space;
- timing drift;
- terminal-after-Space edge;
- Emergency Stop at every boundary;
- background mode capability validation;
- telemetry records actual delivery mode.

Run focused, full regression, compileall, diff-check.

## 4. Live — user controls game

Run 3 clean Pet Skill actions, preferably across at least two matches:

- game not foreground throughout card/directions/Space;
- every direction ACK exact;
- Space exactly once;
- tested result PERFECT;
- zero stale/duplicate/wrong input;
- zero cursor/focus takeover.

If one action fails, stop and inspect; do not continue accumulating samples.

## 5. PASS STRONG and routing

Require 3/3 clean background Pet Skill actions and all safety/test evidence.
Then STATUS/router -> 4C.1.

GOOD/BAD, missing ACK, unexpected focus or unconfirmed server result blocks PASS
STRONG and creates 4B.4F-Rn.

## 6. Do not implement

Desktop option, navigation/re-entry, policy changes, soak hoặc package.

## 7. Explicit stop

STOP after integration/live report/checkpoint.
