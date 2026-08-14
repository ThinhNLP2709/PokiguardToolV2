# Phase 2C.2A.3 controlled runtime runbook

## Safety

Watcher: `tools/lifecycle_idle_watch.py`.

- read-only process rights only;
- no click, keyboard, game method, packet or memory write;
- never intentionally PASS a third consecutive time;
- first local turn must be a normal action, never PASS.

The watcher should start while `lifecycle=LOBBY` and may run hidden throughout
combat. One scenario per match is preferred so provenance is unambiguous.

## S1 — SWAP reset

1. Enter a match and make a normal SWAP on the first local turn.
2. At a convenient later point, let two consecutive local turns expire:
   `PASS`, `PASS`.
3. On the next local turn, make one unmistakable SWAP. Do not risk a third PASS.
4. Later, intentionally PASS exactly once.
5. After that warning, resume normal moves or leave safely.

Acceptance target: the new authoritative warning is `1/3`. The watcher must
associate the local `MATCH_MOVE_RES` response and subsequent lower idle value
inside the same ACTIVE session.

## S2 — CAST reset

1. Enter another match and act normally on the first turn.
2. Play normally until a scanned ATTACK card is usable and mana is at least its
   runtime `condition_use` (observed cost is 160; do not hard-code card ID).
3. Perform `PASS`, `PASS`, then CAST on the mandatory-action turn.
4. Later, intentionally PASS once, then resume normal play.

Acceptance target: local `MATCH_CARD_USE_RES`, consumed turn/mana evidence, and
the next authoritative warning `1/3` in the same ACTIVE session.

## S3 — EVOLVE semantics, no third-pass risk

1. Enter another match and act normally on the first turn.
2. Play until EVOLVE is available with enough mana.
3. Establish only one idle warning (`1/3`).
4. On the next local turn use EVOLVE, then intentionally do no board move. This
   is at most the second consecutive PASS.
5. On the following local turn perform a mandatory SWAP or CAST immediately.

If EVOLVE visibly fails or the server response is `success=false`, perform a
mandatory SWAP in that same turn when possible. The attempt is rejected evidence,
not EVOLVE reset evidence, and S3 must be retried in another match.

Because fusion may fail repeatedly, each retry cycle must independently be:
accepted SWAP to clear risk, exactly one authoritative `1/3`, then one EVOLVE
attempt. On failure, SWAP in the same turn and restart the cycle. Only a
`success=true` attempt following that cycle may be used for EVOLVE reset
classification.

Interpretation:

- warning `2/3` after EVOLVE-only turn: EVOLVE did not reset idle;
- warning `1/3`: reset strongly supported;
- if an additional SWAP/CAST occurs in the same interval: EVOLVE reset remains
  `RESET_UNKNOWN` because the evidence is confounded.

## After the three matches

Return to boss lobby/map and report only: `đã xong S1/S2/S3`. The JSONL log is
already flushed after every event, so no terminal interaction is needed.
