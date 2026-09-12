# Phase 2B.5 memory board hardening

Status: **PASS STRONG** on the two-match runtime acceptance from 2026-08-12.
The implementation remains read-only and stops before Phase 2C.

## Production board source

The preferred production GemType/multiplier source is a validated
`WsCombatBatch.board : BoardCellDTO[][]` at `+0x38`. Its ordering value is
`WsCombatBatch.srvSeq : Int64` at `+0x10`. Pokiguard 1.7.4-b2 can also ACK a
combat response containing incremental `ops` without a complete replacement
board DTO. When no DTO exists at the latest ACK, the production fallback is the
complete current rendered board reached through the exact bounded ownership
chain `Board.allDots -> GameObject native components -> managed Dot`.

A raw heap-scanned `WsCombatBatch` is never publishable by sequence/ACK alone.
The object has no MatchId and its `srvSeq` can collide after the next combat
restarts sequence numbering. It becomes eligible only when the exact same
identity is independently tied to the current Board owner or a current-match
transport DTO. Current transport/owner snapshots still require their `srvSeq`
in `MatchService._ackedSeqs : HashSet<Int64>` at b2 offset `+0x1B8`. Cpp2IL and
the installed native body show:

- `SendAnimAck` ignores non-positive/already-seen sequences, inserts `srvSeq`
  into `_ackedSeqs`, and sends that exact sequence to the server. When the
  count becomes greater than 64, it clears the set and immediately re-adds
  the current sequence, so the newest ACK remains observable.
- `ApplyMatchInitFromMessage` clears `_ackedSeqs` while initializing every new
  match.
- If rendering does not acknowledge a work-bearing batch normally,
  `AckStuckGuard` waits the server-derived guard interval (or 9 seconds when
  absent) and calls `SendAnimAck` if the sequence is still missing.

This gives an externally readable, match-reset presentation watermark. It does
not attach a MatchId to an otherwise unbound heap object and does not prove that
every ACK has a same-sequence full-board DTO. The heap scan remains diagnostic
and validates the exact `WsCombatBatch` class and full DTO structure; an
arbitrary class-pointer hit is never accepted. The rendered fallback performs
no heap scan and accepts only all 64 exact Board-owned Dot components under an
unchanged ACK set.

Evidence:

- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/MatchService.cs`
- installed b2 `GameAssembly.dll`: `SendAnimAck` RVA `0x399300`,
  `AckStuckGuard.MoveNext` RVA `0x3A2DF0`, and
  `ApplyMatchInitFromMessage` RVA `0x392F50`
- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/WsCombatBatch.cs`
- `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/BoardCellDTO.cs`

## Why transient ownership is not the production source

`MatchService.PendingCombat` and `BoardWsApplier._pendingBatches` are consumed
inside the render flow. Three complete exploratory lifecycles with 2.1-2.5 s
scans, followed by a 0-16 ms fast-poll run, observed zero owner-held batches.
The successful two-match acceptance likewise recorded
`owner_batches_seen=0` while resolving 48 ACK-attested states. Therefore the
transient references are valid flow evidence but are not observable reliably
enough to be the external currentness source.

The live `BoardWsApplier` is still mandatory as a presentation-stability gate:
its `board +0x20` must equal current `Board.Instance`, its
`_bootstrappedMatchId +0x30` must equal `MatchService.CurrentMatchId`, and its
renderer/queue must be idle before and after the candidate check.

## CombatSessionKey and stale-state prevention

`CombatSessionKey = (lifecycle_epoch, Board.Instance, CurrentMatchId)`.

- The first valid Board plus non-empty match ID starts a new local epoch.
- A changed Board pointer or changed match ID starts another epoch.
- Board loss clears tracked batches, ACK attestations, accepted sequence/hash,
  publish keys, object-address caches, Dot/Card candidates, and stability state.
- A full lobby scan fingerprints all complete old batches before the next
  combat. Those identities are excluded from that session.
- `srvSeq` is ordering evidence only inside the session key. Publication
  requires a strictly newer sequence. A lower sequence is stale; the same
  sequence with a different hash is ambiguous and fails closed.

The acceptance proved this across two matches: session 1 ended at `srvSeq=101`,
while session 2 safely began at `srvSeq=5` with a different match ID and Board
pointer. No state from session 1 was reused (`stale_skips=0`,
`ambiguous_latest_skips=0`).

## Exact DTO acceptance gates

A snapshot is published only when all of these checks pass:

1. `Board.Instance` resolves as an 8x8 board and its `Active` cross-checks hold.
2. `CurrentMatchId` is non-empty and the `CombatSessionKey` is current.
3. The candidate is absent from the lobby/session baseline, its sequence is in
   the current match-reset ACK set, and it is bound to the current match through
   transport MatchId, exact Board owner, or the current rendered Dot board. A
   raw `RuntimeSequenceMonitor.WsCombatBatch` cannot satisfy this gate alone.
4. The candidate is the highest ACKed sequence. Multiple hashes for that
   sequence are rejected unless the complete current rendered Dot board
   resolves the conflict through exact current-Board ownership.
5. Exactly 64 cells decode; all `(row,col)` coordinates are unique and complete
   in `0..7`; all six tags map exactly; all multipliers are in `{1,2,3,4}`.
   A rendered fallback additionally validates every GameObject/component
   roundtrip, Dot class, current Board owner, `PoolTag`, and settled flags.
6. The current BoardWsApplier is uniquely Board/match-owned and idle; its queue
   is empty; `PendingCombat` is null; the selected batch is not queued.
7. `Board.isReady` is true, `Board.isCascadeRunning` is false, the same Board
   and match ID survive the second read, and the verified 64-reference
   `allDots` array is unchanged.
8. The exact `(session, sequence, hash, allDots references)` passes two
   consecutive confirmations.
9. Duplicate snapshots are suppressed and publication requires a strictly
   increasing `srvSeq` within the session.

Every failed gate returns a named provider reason. Invalid memory, malformed
arrays, unknown tags, duplicate/missing coordinates, and conflicting sequence
hashes fail closed.

## Dot classification

The older allocation scan remains optional audit telemetry. It found at most
58/64 Dot candidates because `Board.allDots` stores GameObject references and
the scan did not follow Unity component ownership. b2 supplies the previously
missing exact link: `Dot.PoolTag +0xF8`, with native
`BoardWsApplier.SpawnDotByTag` (RVA `0x358A30`) writing the incoming server tag
to that field while also assigning column, row and multiplier.

The provider now walks each current GameObject's signature-gated native
component list. It requires exactly one component whose managed wrapper has the
exact Dot class, roundtrips to that native component, points back to the current
Board, and remains byte-for-byte stable across a second sample. `_isFalling`,
`isPredictionSwap`, `_squashing` and `RenderHidden` must all be false. The
current ACK HashSet is also unchanged before/after the complete 64-Dot walk.

This direct path is used only when b2 has acknowledged an ops-only response and
no full DTO exists at the latest ACK. Same-sequence DTO remains preferred.
Offline validation is complete. Live run
`2f9116700bac4331b5830ab438983229` accepted 5/5 direct Dot-board reads with
zero rejection and completed all eight local turns without PASS or board
starvation. Phase 2 closure remains pending user review.

## Coordinate boundary and shadow solver

Runtime rows are bottom-origin; V1 solver/screenshot rows are top-origin:

`screenRow = 7 - runtimeRow`

The conversion occurs exactly once when building provider-neutral
`BoardState`. Audit JSON retains both coordinate systems for all 64 cells and
both endpoints of every shadow move. The overlay and V1 input geometry consume
screen coordinates only. The watcher calls the unchanged V1 solver in shadow
mode and has no click/input path.

## Runtime acceptance result

Primary evidence log:
`logs/phase2b5_ack_acceptance_20260812_101533.jsonl`.

| Item | Session 1 | Session 2 | Total |
|---|---:|---:|---:|
| Match ID | `M_b8d05886` | `M_9c4568a8` | 2 lifecycles |
| Board instance | `0x000002877F168540` | `0x0000028624181540` | distinct |
| Accepted snapshots | 21 | 27 | **48** |
| Accepted sequence range | 11-101 | 5-98 | strictly increasing/session |
| Unique accepted hashes | 21 | 27 | **48** |
| Solver moves / skips | 19 / 2 | 18 / 9 | **37 / 11** |
| Maximum consecutive skips | 2 | 2 | **2** |

Structural audit over all 48 snapshots:

- 3,072/3,072 cells decoded; every board was exactly 64 complete unique cells.
- Gem counts: shield 589, rage 570, mana 549, health 499, drain 462, sword 403.
- Multiplier counts: x1 2,517; x2 291; x3 122; x4 142.
- All 48 sources were exactly
  `MatchService._ackedSeqs+postLobbyHeap`.
- All 37 moves had the exact inverse coordinate transformation; 11 decisions
  were explicit shadow skips. No session exceeded two consecutive skips.
- 48 PNG overlays plus 48 JSON audit files were created.
- Metrics: 3,735 polls, 189 bounded scans, 92 server transitions,
  48 publications, 1,014 duplicates suppressed, zero stale skips, zero
  ambiguous-latest skips, zero DTO rejections, and zero read errors.

Twenty selected human-visible boards across both sessions were manually
compared against their overlays: grid placement, gem labels, multipliers and
top/bottom orientation matched 20/20. Some accepted images contain a translucent
three-idle-turn warning; two final-state images are substantially obscured by
end-of-battle UI. Those are screenshot-audit legibility limits, not a measured
memory/coordinate mismatch, and the obscured pair is not counted in the 20/20.

## Remaining boundary before Phase 2C

- Board reading itself has passed Phase 2B.5 strongly.
- An input phase must add a separate actionability gate (combat active, local
  turn, boss/player alive, no modal/end state) before any normal input is
  considered. The board provider can correctly publish the latest rendered
  board while an end-of-battle modal is visible.
- The V1 solver's two-consecutive-skip ceiling must remain enforced at the
  eventual executor boundary because the game removes an idle player after
  three turns. The shadow run never exceeded two.
- Dot completeness remains unresolved by design and is not a blocker for the
  ACK-attested DTO production source.

No Phase 2C input, process write, injection, direct game method call, or network
manipulation was implemented.
