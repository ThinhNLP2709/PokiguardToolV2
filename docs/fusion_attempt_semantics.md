# Fusion attempt semantics

Status: read-only correlation implemented; failure/success resource and turn
semantics captured in match `M_2c027c0d`; clean idle and same-turn
post-success SWAP acceptance remain pending.

## Static evidence

Cpp2IL provides the following exact client fields:

| Type/member | Declared type | Offset | Meaning used by V2 |
|---|---:|---:|---|
| `MatchService.LocalFusionUsed` | `Boolean` | `+0x60` | durable successful-use flag |
| `MatchService.LocalFusionLastAttemptTurn` | `Int32` | `+0x64` | durable attempt identity/turn lock |
| `MatchService.LocalFusionDropReason` | `String` | `+0x80` | client-side failure/drop reason when present |
| `FusionCardUI._btn` | `Button` | `+0x58` | actual UI Button |
| `FusionCardUI._nextRefreshAt` | `Single` | `+0x60` | UI refresh scheduling state; not treated as a retry deadline |
| `FusionCardUI._boundPetId` | `Int64` | `+0x68` | selected UI pet identity |

`MatchService.get_LocalFusionLockedThisTurn()` is true exactly when the positive
last-attempt turn equals `TurnNumber`. Native `FusionCardUI.RefreshState` calls
that getter, and V2 separately validates the live Button and reads its exact
`m_Interactable` field. Evidence sources:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs`;
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/FusionCardUI.cs`;
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/FusionCardUI.txt`.

The FusionCardUI type-info slot RVA `0x35332A0` comes from the class's own
`RefreshState` metadata initializer in this build. It is resolved as
`GameAssembly base + RVA`; no ASLR-dependent absolute address is stored.

## Attempt correlation

`src/pokiguard_v2/fusion_diagnostics.py` creates an attempt when
`LocalFusionLastAttemptTurn` changes. A `LocalFusionUsed false -> true`
transition is additional success evidence. Every `MATCH_FUSION_RES` is then
correlated with:

- before/request/after snapshots;
- mana, current player, turn, remaining timer and authoritative idle;
- Fusion used/locked/drop-reason state;
- response success/reason/code and message identity;
- live Fusion Button interactability;
- later actionable state and any SWAP/CAST confounder.

The closest snapshot captured with the response is frozen. Later resource
gains, SWAPs or CASTs cannot change the recorded mana delta or turn result.

## Current evidence matrix

| Question | Current answer | Confidence/evidence |
|---|---|---|
| Does failure mark Fusion complete? | No. `LocalFusionUsed` remains false. | runtime-confirmed in Phase 2C.2A.3 |
| Can failure be retried immediately in the same turn? | No on the observed client path: last attempt locks that turn and the UI must become interactable. | high; static getter/UI path plus runtime lock transitions |
| Can BASIC propose it again later? | Yes, only after a response and a fresh actionable snapshot, while unused and mana is sufficient. | implemented/tested proposal behavior; execution remains disabled |
| Does failure cost mana? | Yes in the accepted turn-7 sample: `210 -> 50`, exactly `-160`. | runtime-confirmed, one sample |
| Does failure consume the turn? | No in the accepted turn-7 sample. The response was false, the local turn remained 7, and a SWAP was server-accepted in that same turn at 6 seconds. | runtime-confirmed, one sample |
| Does failure reset idle? | UNKNOWN. | no uncontaminated authoritative before/after pair |
| Does success set `fusion.used`? | Yes. | Turn-23 response `success=true` plus durable `used=true` in `M_2c027c0d`; also seen previously at turn 49 |
| Does success cost exactly 160 mana? | Yes in the accepted turn-23 sample: `225 -> 65`. | runtime-confirmed, one sample |
| Is success non-turn-consuming? | It did not immediately consume the turn: response arrived on local turn 23, `fusion.used=true`, with about 8 seconds remaining. | strong at-response evidence |
| Can a same-turn SWAP follow success? | Not tested in this match: turn 23 expired and the next accepted SWAP was turn 25. Prior evidence remains partial. | pending strong capture |
| Does success reset idle? | UNKNOWN. | S3 was confounded by SWAP and no later authoritative idle payload |

The same success was independently reflected in participant state: after turn
23 the local maximum HP changed from `83,385` to `105,228`. This supports the
server response and durable `fusion.used=true` even though the user did not
visually recognize the evolution during play.

Neither observed attempt reset the visible turn timer: the failed attempt
progressed approximately 10 to 9 seconds, and the successful attempt
approximately 9 to 8 seconds. This is evidence that Fusion preserves the
current deadline, not evidence for a separate cooldown duration.

Runtime exposed two forms of the same ordering edge: `MATCH_FUSION_RES` can
become visible one poll before the first `LocalFusionLastAttemptTurn`, or while
that field still holds the previous positive turn. The tracker attributes such
a provisional local response to the live local turn, merges it with the
subsequent matching durable transition, retains the exact response snapshot
plus the settled after snapshot, and ignores malformed reused Fusion DTOs with
no exact success boolean or proven local actor. A further match is required to
acceptance-test the final positive-previous-turn hardening.

The `M_714b231e` run also validated the UI signal itself: the single validated
FusionCardUI Button was `interactable=true` before attempts, false while the
turn lock was active, and became true again with a later unused/unlocked state.
Historical `retryAllowed=true` is now retained even after a later attempt or
success instead of being overwritten.

`TURN_CHANGED` in a record is an observation at response time, not automatically
proof that Fusion consumed the turn: scanner delay or another action may have
intervened. The activity/confounder list must be considered.

## Retry contract for future execution

No executor exists in this phase. The formal gate for a later retry is:

```text
MATCH_FUSION_RES received with a known result
AND Fusion is enabled
AND fusion.used == false
AND LocalFusionLockedThisTurn == false
AND exactly one validated live FusionCardUI exists
AND its real Button.m_Interactable == true
AND the normal combat actionability gate passes
AND mana >= actual/configured cost
```

This deliberately does not invent a millisecond cooldown from
`_nextRefreshAt`. An absent/ambiguous UI object, pending response or locked turn
fails closed. A successful attempt permanently stops future EVOLVE proposals;
insufficient mana or actionability also stops the current proposal.

## Idle classification

For failure and success independently, the tracker reports
`CONFIRMED`, `NO_RESET`, or `UNKNOWN`:

- a lower authoritative count after an uncontaminated attempt confirms reset;
- a higher count after an uncontaminated attempt supports no reset;
- equal count, missing/stale payload, or intervening SWAP/CAST remains UNKNOWN.

V2 never changes the game-owned idle counter locally. S3 remains independent
from dead-board acceptance and currently remains UNKNOWN.
