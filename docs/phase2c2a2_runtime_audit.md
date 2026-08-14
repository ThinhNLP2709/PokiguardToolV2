# Phase 2C.2A.2 runtime audit

## Scope and evidence

The primary evidence is
`logs/phase2c2a2_acceptance_20260812_165616.jsonl`. It contains one complete
manual match (`M_ee5f7068`, ended at `2026-08-12T10:08:19.846Z`) and early
lifecycle evidence for `M_3d5b93e3`. Supplemental evidence is in
`logs/phase2c2a2_recovery_20260812_171537.jsonl`.

Both collectors were external read-only observers. No autonomous input,
process write, method call, injection or network manipulation was used.

## Acceptance results

1. **Exact first-turn signal:** `MatchService.CurrentTurnPlayer` equals
   `ChatService.username` using case-insensitive comparison, and
   `MatchService.TurnNumber` is 0 or 1. Board appearance is not part of it.
2. **First-turn acceptance:** PASS. Match `M_3d5b93e3` captured turn 1,
   `current=happi`, `local=happi` at `10:08:49.625Z`, before stable publication.
   The first stable board arrived at turn 3, `srvSeq=7`, at `10:09:00.169Z`.
3. **CardUI resolution:** stable. Every transition exposed the same three
   current Board/Active-owned cards. The attack card in this loadout was
   dynamically identified as ID 4, `Tấn công`, `ATTACK`.
   `condition_use=160`; the separate declared `mana_cost` was zero.
4. **CAST transitions:** turn 27 Mana 353 -> 193 and turn 35 Mana 333 -> 173.
   The attack card changed interactable true -> false,
   `hasUsedThisTurn` false -> true, pending stayed false, and
   `lastTurnUsed` became the current turn.
5. **CAST consumes turn:** confirmed. `MATCH_CARD_USE_RES` plus durable
   CardUI/Mana change was followed by local 27 -> boss 28 and local 35 -> boss
   36. The response had no explicit success boolean, so acceptance uses
   multi-signal correlation.
6. **Authoritative idle sources:** direct `MATCH_AFK_WARN` and nested
   `MATCH_TURN_END.matchPayload.afkWarn`, decoded from `ChatMessageDTO`.
7. **Observed values:** local `happi` count 1/3 and 2/3. No count zero and no
   usable idle-message `seqNum` were observed.
8. **SWAP reset:** strong but not packet-exact. After count 1, accepted SWAP
   activity occurred and a later warning returned to count 1 instead of 2.
   Multiple intervening SWAPs and no reset payload prevent isolating one SWAP.
9. **CAST reset:** not confirmed. The accepted turn-35 CAST occurred at fresh
   nested 2/3 and consumed the turn, but no reset/count-zero event followed
   before a later SWAP.
10. **EVOLVE reset:** not observed independently. Successful Fusion at turn 21
    (`MATCH_FUSION_RES success=true`, Mana cost 160) was followed by a SWAP in
    the same local turn. EVOLVE being non-consuming is runtime-confirmed by
    that same-turn SWAP, but reset ownership is confounded.
11. **PASS readiness:** conditionally resolvable but not end-to-end
    production-ready. Only an exact fresh nested turn-end idle payload for the
    current local turn maps count 1/3 to `PASS_ALLOWED` and 2/3 to
    `PASS_FORBIDDEN_MANDATORY_ACTION`. Direct/stale/missing/reset states are
    `UNKNOWN`; autonomous PASS remains disabled.
12. **Actual move logging:** good. The complete match recorded 12
    `LastMoveSeqNum` changes, seq 3..14, with from/to row/column and local seq.
    Server response/ACK/board change is still required to call a request
    accepted.
13. **Intermediate boss resources:** not redefined. Intermediate Mana/Rage
    cases remain `UNDEFINED/NONE` unless an earlier user-defined priority
    applies.
14. **Remaining blockers:** no durable client field for current idle count; no
    count-zero/reset event; CAST and EVOLVE reset semantics incomplete; the
    transient idle cache is not connected to the production provider;
    autonomous input is intentionally out of scope.
15. **Changed source/docs/tests:** listed in the final phase handoff.
16. **Tests:** 104/104 pass, including server-cache freshness, conditional
    readiness, first-turn policy and watcher parsers.

## Verdict

PASS A, B and C pass. PASS D is partial: SWAP reset has strong behavioral
evidence, CAST/EVOLVE reset remains unresolved. PASS STRONG is not reached for
general autonomous PASS, so fail-closed behavior remains mandatory.
