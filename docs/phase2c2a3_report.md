# Phase 2C.2A.3 report

Status: **lifecycle STRONG; controlled SWAP and CAST reset accepted; an accepted
EVOLVE is now observed but its idle-reset capture is INCONCLUSIVE; autonomous
input remains disabled**.

## 1. Exact local combat lifecycle signals

The gate reads `MatchHost.State`, `MatchHost.CurrentRig`, loader loading and
unloading flags, `HubSuspendManager.IsSuspended`, Board/Active/ManagerMatch
singletons and their ownership cycle, current match ID, Board ready and local
end flags. Exact offsets/RVAs and sources are in
`docs/combat_lifecycle_resolution.md`.

## 2. Why `M_6630bd6e` existed after exit

`UNKNOWN`; the old watcher lacked rig/Hub/loader evidence. The log actually
shows prior Board/match destruction followed 2.107 seconds later by a different
Board pointer and a new match at turn 1. It is not evidence of one continuing
hidden match and is most consistent with a distinct local match lifecycle.

## 3. ACTIVE versus STALE_SERVER_MATCH

ACTIVE requires Host Running, live CurrentRig, loader idle, Hub suspended,
complete consistent local combat objects, non-empty match ID, ready Board and no
end flags. STALE requires a match ID while Host is Idle and rig/Hub/Board/Active/
Manager are all locally absent. Any partial disagreement is UNKNOWN.

## 4. CombatSessionKey

`(lifecycle_epoch, Board.Instance, matchId)`. It is issued only in ACTIVE and
invalidated on the first non-ACTIVE sample. A new ACTIVE lifecycle increments
the epoch.

## 5. Runtime idle values

Still exactly `1/3` and `2/3` for local `happi`, from direct
`MATCH_AFK_WARN` and nested `MATCH_TURN_END.afkWarn` in Phase 2C.2A.2 logs.

## 6–8. Reset classification

- SWAP: `RESET_STRONGLY_INFERRED`, now confirmed by controlled S1 in
  `M_63941904`: authoritative `1/3 -> 2/3`, accepted local SWAP, then the next
  intentional PASS returned to authoritative `1/3`.
- CAST: `RESET_STRONGLY_INFERRED`, confirmed by controlled S2 final in
  `M_2ab08386`: authoritative `1/3 -> 2/3`, local
  `MATCH_CARD_USE_RES` without reject, then the next intentional PASS returned
  to authoritative `1/3`.
- EVOLVE: `RESET_UNKNOWN`. S3 retry `M_1aaa7be0` eventually produced exact
  `MATCH_FUSION_RES success=true` and `fusion.used=true`, but accepted SWAPs
  occurred after the last authoritative `1/3` and no new authoritative idle
  payload arrived after EVOLVE before exit. The reset result is therefore
  unproven rather than negative.

## 9. Explicit zero

No `idleCount=0` has been observed. The model reserves
`RESET_CONFIRMED_EXPLICIT` only for a literal authoritative zero/reset payload.

## 10. PASS production readiness

No. Fresh exact `1/3` and `2/3` mappings exist, but controlled reset semantics
are incomplete and the policy remains autonomous-PASS disabled. UNKNOWN fails
closed.

## 11. Cache freshness

Only authoritative payloads replace counts. Accepted local activity makes the
cache stale without changing the count. Lifecycle exit, Board loss, match ID or
session change, lobby and postmatch clear it immediately.

## 12. First turn

The proven signal is unchanged:

```text
CurrentTurnPlayer == ChatService.username (OrdinalIgnoreCase)
AND TurnNumber in {0,1}
```

It returns UNKNOWN outside ACTIVE, so a stale/hidden MatchService cannot create
a first-turn action at lobby.

## 13. Hidden/stale match actionability

No. `ActionabilityGate` now rejects LOBBY, ENTERING, LEAVING, POSTMATCH,
STALE_SERVER_MATCH and LIFECYCLE_UNKNOWN before the normal board/input checks.

## 14. Tests

`python -m unittest discover -s tests -v`: **119/119 passed**.

New coverage includes ACTIVE conjunction, entering/leaving/postmatch priority,
stale server match, immediate session invalidation/new epoch, cache clearing,
explicit/sequence/inferred reset classes, no local count arithmetic, and every
lifecycle-specific actionability rejection.

Runtime smoke capture at lobby also passed:
`logs/lifecycle_idle_watch_20260812_174531.jsonl`.

## 15. Files changed

Created:

- `src/pokiguard_v2/combat_lifecycle.py`
- `tools/lifecycle_idle_watch.py`
- `tests/test_combat_lifecycle.py`
- `tests/test_lifecycle_idle_watch.py`
- `docs/combat_lifecycle_resolution.md`
- `docs/phase2c2a3_runbook.md`
- `docs/phase2c2a3_report.md`

Modified:

- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/actionability.py`
- `src/pokiguard_v2/game_owned_idle.py`
- `tools/replay_basic_policy.py`
- `tests/test_actionability.py`
- `tests/test_basic_policy.py`
- `tests/test_game_owned_idle.py`
- `docs/idle_state_resolution.md`

Generated runtime evidence:

- `logs/lifecycle_idle_watch_20260812_174531.jsonl`
- `logs/phase2c2a3_controlled_20260812_174933.jsonl` (controlled watcher,
  PID 5844, running from a confirmed LOBBY start for S1/S2/S3)
- `logs/phase2c2a3_watcher_20260812_174933.out.log`
- `logs/phase2c2a3_watcher_20260812_174933.err.log`
- `logs/phase2c2a3_s2_final_s3_20260812_222215.jsonl` (controlled S2 success
  followed by rejected S3 attempt; watcher exited normally with zero-byte error
  log)
- `logs/phase2c2a3_s3_retry_20260812_223632.jsonl` (multiple rejected fusion
  attempts, one accepted EVOLVE, then a turn/board stall and user exit; watcher
  exited normally with zero-byte error log)

### Rejected S3 attempt

Session `epoch=2|board=0x0000015EEF085540|match=M_cf6a627e` established an
authoritative local `1/3`. On turn 13, the client fusion state changed from
available to locked with `last_attempt_turn=13`, but the exact server response
was `MATCH_FUSION_RES success=false`. No accepted EVOLVE activity was recorded.
The next authoritative `2/3` payload was not observed before the mandatory SWAP
on turn 15. This run therefore proves rejection handling only; it does not prove
whether a successful EVOLVE resets idle.

### S3 retry with accepted EVOLVE and board stall

Session `epoch=1|board=0x0000015EB9E3C540|match=M_1aaa7be0` observed repeated
fusion attempts. Five exact local server responses were retained: four
`MATCH_FUSION_RES success=false` responses (turns 25, 33, 39 and 43) and one
success. At turn 49 the client changed to
`fusion.used=true` and the server response was exactly
`MATCH_FUSION_RES success=true`, classified as accepted local `evolve`.

This is not reset evidence: accepted SWAPs occurred after the last authoritative
`1/3`, and no authoritative idle payload followed the successful EVOLVE. Boss
turn 50 completed, local turn 51 began, and server sequence remained at `111`
until the user exited to lobby. Lifecycle remained ACTIVE until that exit, so
there was no observed ownership/session loss beforehand. This watcher does not
persist the 64-cell board snapshot or legal-move count; consequently the exact
board failure (dead board, unstable snapshot, or presentation/input fault)
cannot be reconstructed from this log and remains UNKNOWN.

Read-only inspection of the game `Player.log` found no exception, board
ownership loss, shuffle/dead-board message, or board verification failure in
this interval. It did record the user's final board interaction being rejected
by `Dot.CanInteract` because `turnTimeRemainingSec <= 1`. This explains that
specific rejected click, but does not establish why the board had appeared
broken earlier.

## 16. Remaining blockers

1. EVOLVE idle behavior remains unknown until S3 captures a known current idle
   count, `MATCH_FUSION_RES success=true`, and the following authoritative idle
   event without an intervening SWAP/CAST.
2. The turn-51 board stall in `M_1aaa7be0` lacks a persisted 64-cell snapshot,
   so its board-level cause is UNKNOWN.
3. POSTMATCH still needs an explicit end-of-match transition capture. The S1
   capture did validate LOBBY -> STALE_SERVER_MATCH -> ENTERING -> ACTIVE ->
   LOBBY on a user-initiated exit.

Intermediate boss-resource policy remains unchanged (`UNDEFINED/NONE` between
the two existing thresholds). Work stops before autonomous input.
