# Phase 2C.2A.2 — authoritative idle, first turn and CAST acceptance

## Current status

The targeted manual run is complete. Runtime acceptance result:

- **PASS A / first turn: PASS.** Raw runtime state captured local turn 1 before
  the production-stable board was available.
- **PASS B / CAST: PASS (strong).** Two manual attack-card uses were correlated
  from CardUI before state through server response, Mana `-160`, durable card
  state and a turn transition.
- **PASS C / idle: PASS.** Server payloads exposed local `idleCount` 1 and 2
  with `threshold` 3.
- **PASS D / reset: PARTIAL.** Accepted SWAP activity reset a streak, but no
  count-zero payload was emitted. CAST prevented a third consecutive idle
  action but its reset value was not exposed. Successful EVOLVE was followed
  by a same-turn SWAP, so its reset semantics remain confounded.
- **PASS STRONG / autonomous PASS: NO.** A fresh nested
  `MATCH_TURN_END.afkWarn` can conditionally produce `PASS_ALLOWED` or
  `PASS_FORBIDDEN_MANDATORY_ACTION`, but reset/count zero is unavailable and
  this transient cache is not yet a production state-provider input.

No autonomous input is present. Production PASS remains disabled/fail-closed.

## Exact idle message lifecycle

Both idle sources use `ChatMessageDTO` (`Assembly-CSharp`, global namespace):

- `matchId : string +0xB0`;
- `seqNum : Nullable<long> +0xB8`;
- `matchPayload : Dictionary<string,object> +0xC8`;
- direct `MATCH_AFK_WARN` uses top-level `username +0x18` plus
  `matchPayload.idleCount/threshold`;
- `MATCH_TURN_END` may carry `matchPayload.afkWarn`, converted/read as a
  `JObject` with `username`, `idleCount`, and `threshold`.

The receive path is:

```text
websocket callback
  -> ChatService.OnWebSocketMessage
  -> deserialize ChatMessageDTO into closure.message +0x20
  -> UnityMainThreadDispatcher.Enqueue(Action)
  -> closure dispatch by message.type
  -> WsMatchClient event
  -> MatchService handler
  -> OnAfkWarn(username, idleCount, threshold)
  -> BoardWsApplier notice only
```

`UnityMainThreadDispatcher.Enqueue` locks and appends to a `Queue<Action>`;
`Update` drains that queue and invokes the actions. This proves client queue
order for enqueued actions, but not undocumented server generation rules.

For `MATCH_TURN_END`, `HandleMatchTurnEnd` first writes
`CurrentTurnPlayer`, `TurnNumber`, timer and state deltas, then handles optional
`afkWarn`, then raises `OnTurnEnd`. For direct `MATCH_AFK_WARN`,
`HandleMatchAfkWarn` verifies current `matchId` and `_matchOver == false`.

Both handlers only raise `OnAfkWarn` when `idleCount > 0`. Direct AFK defaults
missing count to 0 and threshold to 3; nested turn-end similarly defaults a
missing threshold to 3. These defaults prove handler behavior, not that the
server sent those values.

### Runtime answers and remaining UNKNOWNs

- The observed flow emitted warnings at both `idleCount=1` and `idleCount=2`;
  every observed threshold was 3.
- No observed idle/turn-end message carried a usable `seqNum`.
- No `idleCount=0` was observed. The client callback would suppress zero even
  if it were present in a handled payload.
- A later count of 1 after accepted SWAP activity proves that SWAP activity
  reset a prior streak, but the exact resetting SWAP/reset message cannot be
  isolated because more than one SWAP occurred in that interval.
- CAST reset remains unconfirmed: the second CAST was performed at 2/3 and
  consumed the turn without a kick, but no later zero/count-one payload was
  observed before a SWAP.
- EVOLVE reset remains unconfirmed: successful EVOLVE and a SWAP occurred in
  the same local turn.
- Absence of `afkWarn` still has no proven semantic meaning.

Absence is therefore never treated as count zero or as a reset.

## Lifetime and provenance

The DTO is held by the `OnWebSocketMessage` closure until its queued callback
runs. No persistent `MatchService` field or chat-history branch retains idle
count. A managed heap hit is authoritative evidence that the server payload
existed, but reachability/currentness after the callback is not implied.

`GameOwnedIdleCache` stores only exact received values. It is scoped to the
current Board/match identity, preserves message type, optional message
`seqNum`, optional payload turn, server timestamp and local observation time,
and never increments/decrements. A move, turn, card, or Fusion transition only
marks the previous event as `CURRENT_STATE_UNPROVEN`; it does not manufacture a
reset value.

`pass_readiness()` maps only a fresh nested `MATCH_TURN_END.afkWarn` whose
username, session and `source_turn` exactly match the current local turn.
Positive counts below `threshold - 1` produce `PASS_ALLOWED`; count
`threshold - 1` produces `PASS_FORBIDDEN_MANDATORY_ACTION`. Direct
`MATCH_AFK_WARN`, stale events, session/turn mismatches, and missing/reset state
remain `UNKNOWN`.

This conditional resolver does not make autonomous PASS production-ready: no
production provider currently feeds the transient cache into `BattleState`,
and a clean/reset count cannot be recovered from absence.

## Earlier first-turn instrumentation

`idle_state_watch.py` now records the following independently of policy
publication:

1. Board instance appearance;
2. `MatchService.CurrentMatchId` appearance;
3. raw `TurnNumber`, `CurrentTurnPlayer`, and `ChatService.username`;
4. first structurally valid `WsCombatBatch`;
5. first ACK-attested batch and highest `_ackedSeqs` value;
6. first stable production publication.

The candidate first-turn signal remains exactly:

```text
CurrentTurnPlayer equals ChatService.username (OrdinalIgnoreCase semantics)
AND TurnNumber in {0, 1}
```

Board appearance alone never sets the flag. The production stable-board gate
is unchanged. Match `M_3d5b93e3` captured this signal at
`2026-08-12T10:08:49.625Z`: turn 1, current player `happi`, local username
`happi`, while `productionStableAtObservation=false`. The first stable board
was published only at turn 3, `10:09:00.169Z` (`srvSeq=7`).

`BattleState.is_first_local_turn` now implements exactly this accepted rule,
and BASIC treats it as mandatory so the fallback PASS branch cannot win.

## CAST instrumentation

The watcher uses `MemoryBoardStateProvider` CardUI discovery and logs every
current Board/Active-owned card without hard-coding ID 4:

- card/data identity, name, `elementTypeCard`, and `skillType`;
- game-computed `interactable`;
- mana/power cost and cooldown;
- `hasUsedThisTurn`, `lastTurnUsed`, pending/placeholder state;
- current decoded local-player mana.

It also scans current-match `MATCH_CARD_USE_RES`, `MATCH_SKILL_USE_RES`, and
`MATCH_SKILL_CAST` DTOs. An explicit `success/accepted` is labeled explicit;
an explicit reject is labeled rejected; a response without either is retained
as response evidence requiring CardUI/mana/turn correlation. Optimistic CardUI
state alone is not relabeled server-authoritative.

The complete run resolved three current Board/Active-owned cards on every
CardUI transition without hard-coding an ID. The attack card observed in this
loadout was ID 4, name `Tấn công`, element `ATTACK`, with
`condition_use=160`; its separate declared `mana_cost` field was zero.

Two accepted manual CAST transitions were captured:

| Turn | Before | Server response | After | Turn result |
|---|---|---|---|---|
| 27 | Mana 353, interactable, unused, `lastTurnUsed=-1` | `MATCH_CARD_USE_RES` at `10:06:47.413Z` | Mana 193, non-interactable, used, `lastTurnUsed=27` | local 27 -> boss 28 |
| 35 | Mana 333, interactable, unused, `lastTurnUsed=27` | `MATCH_CARD_USE_RES` at `10:07:48.057Z` | Mana 173, non-interactable, used, `lastTurnUsed=35` | local 35 -> boss 36 |

The response payload did not expose an explicit success boolean, so acceptance
uses the correlated server response, exact Mana delta, durable CardUI state and
turn transition—not response presence alone. On the next local turn the card
became interactable/unused again without rolling back `lastTurnUsed`.

## Actual move logging

Every `LastMoveSeqNum` transition records the exact current fields:

- `LastMoveFromCol`;
- `LastMoveFromRow`;
- `LastMoveToCol`;
- `LastMoveToRow`;
- `LastMoveSeqNum` and `_localSeqNum`;
- observed turn/current player/highest ACK.

This proves the client request. Server acceptance still requires response or
ACK/board-transition correlation during audit.

The completed match recorded 12 exact `LastMoveSeqNum` transitions (3 through
14), each with all four coordinates and `_localSeqNum`. Together with
`MATCH_MOVE_RES`/ACK and board transitions, this is sufficient for manual-move
audit; the raw `LastMove*` fields alone remain request evidence.

## Acceptance evidence

Primary complete log:

```powershell
logs\phase2c2a2_acceptance_20260812_165616.jsonl
```

It contains complete match `M_ee5f7068` and the start of `M_3d5b93e3`,
including accepted first-turn evidence. Supplemental read-only evidence is in
`logs\phase2c2a2_recovery_20260812_171537.jsonl`.

The watcher used only `PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`; it did
not click, send a game method, write process memory, inject, or manipulate
network traffic.

## Policy boundary

The intermediate boss Mana/Rage cases remain `UNDEFINED/NONE`; this acceptance
watcher did not add or infer any priority for them. `BasicPolicyEngine` changed
only to consume the accepted authoritative first-turn property. The phase stops
before autonomous behavior.
