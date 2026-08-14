# Phase 2B.5 memory board hardening

Status: **PASS STRONG** on the two-match runtime acceptance from 2026-08-12.
The implementation remains read-only and stops before Phase 2C.

## Production board source

The production GemType/multiplier source is a validated
`WsCombatBatch.board : BoardCellDTO[][]` at `+0x38`. Its ordering value is
`WsCombatBatch.srvSeq : Int64` at `+0x10`.

A heap batch is publishable only when its identity was not present in the
pre-combat lobby baseline and its `srvSeq` is present in the current
`MatchService._ackedSeqs : HashSet<Int64>` at `+0x180`. Cpp2IL native evidence
shows:

- `SendAnimAck` ignores non-positive/already-seen sequences, inserts `srvSeq`
  into `_ackedSeqs`, bounds the set around 64 entries, and sends that exact
  sequence to the server.
- `ApplyMatchInitFromMessage` clears `_ackedSeqs` while initializing every new
  match.

This gives an externally readable, match-reset currentness witness. The heap
scan is still bounded to readable private writable regions and validates the
exact `WsCombatBatch` class and full DTO structure; an arbitrary class-pointer
hit is never accepted.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:317`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `SendAnimAck` ISIL steps 18-52 and `ApplyMatchInitFromMessage` steps 425-430
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/WsCombatBatch.cs:3-10`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs`

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
3. The candidate is absent from the lobby/session baseline and its sequence is
   in the current match-reset ACK set.
4. The candidate is the highest ACKed sequence. Multiple hashes for that
   sequence are rejected.
5. Exactly 64 DTO cells decode; all `(row,col)` coordinates are unique and
   complete in `0..7`; all six tags map exactly; all multipliers are in
   `{1,2,3,4}`.
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

Dot is **optional audit telemetry**, not a production GemType dependency.
`Board.allDots` stores `GameObject` references, not direct `Dot` references, and
`Dot` has no managed tag/type field. Phase 2B's bounded anchor experiment found
at most 58/64 components and could not guarantee complete coverage without
undocumented Unity native traversal or an expensive broader scan.

The final acceptance intentionally did not run Dot anchor scans
(`dot_anchor_scans=0`, `dot_complete_polls=0`). All 48 states remained complete
64/64 through DTO. This confirms that making Dot mandatory would add an
unreliable hidden dependency and is unnecessary for production board decoding.

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
