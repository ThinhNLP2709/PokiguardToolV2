# Board data sources — Phase 2A

> Phase 2B.5 hardening: a heap-scanned `WsCombatBatch` alone is not a production
> candidate. See `docs/memory_board_hardening.md`. Publication requires that the
> batch was absent from the lobby baseline and that its `srvSeq` is present in
> the current match-reset `MatchService._ackedSeqs` set. A Board/match-ID-matched
> idle `BoardWsApplier` and stable `Board.allDots` remain presentation gates.
> Dot is independent telemetry, not a mandatory source.

## Evidence standard

This inventory separates a persistent live board from payload objects and
coroutine locals. A declaration alone proves type and offset; lifetime/currentness
is recorded separately. No source below is treated as current merely because a
string search found the word `board`.

## Ranked sources

| Rank | Owner type | Field/property | Declared type | Offset | Lifetime | Current board state? | Direct tag? | Confidence |
|---:|---|---|---|---:|---|---|---|---|
| 1 | `Board` | `allDots` | `UnityEngine.GameObject[,]` (Cpp2IL renders `GameObject[2]`) | `+0x140` | Persistent for the combat `Board.Instance` lifecycle | Yes, live visual grid | No | HIGH |
| 2 | `WsCombatBatch` | `board` | `BoardCellDTO[][]` | `+0x38` | Temporary batch/snapshot object | Yes at the server sequence represented by the batch; not guaranteed to remain the latest live grid | **Yes**: `BoardCellDTO.tag` | HIGH for contents, MEDIUM/LOW for currentness after moves |
| 3 | `MatchService` | `<PendingCombat>k__BackingField` | `WsCombatBatch` | `+0x170` | Transient | Only until consumed | Indirectly through batch | HIGH |
| 4 | `BoardWsApplier` | `_pendingBatches` | `Queue<ValueTuple<List<MatchOpDTO>, WsCombatBatch, IEnumerator>>` | `+0x50` | Temporary render queue | Batch may describe a point in the operation stream | Indirectly through queued batch | HIGH declaration; LOW as stable external anchor |
| 5 | `ChatMessageDTO` | `matchPayload` | `Dictionary<String,Object>` | `+0xC8` | Temporary transport DTO | Snapshot/operation payload only | Serialized board may contain tag | HIGH declaration; LOW as stable external anchor |
| 6 | `Dot` | `originalPrefab` | `UnityEngine.GameObject` | `+0xD8` | Persistent for a live Dot | Stable identity clue, not a board collection | No string/enum tag | HIGH |
| 7 | `Board` | `dots` | `UnityEngine.GameObject[]` | `+0x70` | Persistent component field | No; it is the six prefab choices | Tag belongs to prefab GameObject | HIGH |

## Direct DTO shape

`BoardCellDTO` has exactly:

| Field | Type | Offset |
|---|---|---:|
| `col` | `System.Int32` | `+0x10` |
| `row` | `System.Int32` | `+0x14` |
| `tag` | `System.String` | `+0x18` |
| `multiplier` | `System.Int32` | `+0x20` |

### Runtime coordinates versus solver coordinates

Phase 2B live CV audit established that DTO/Dot `row` is bottom-origin, while
PokiguardAuto V1 and its mouse executor use screen rows with row 0 at the top.
For three complete CV captures, unchanged coordinates matched only 9/64, 8/64,
and 12/64 cells; applying only `screenRow = 7 - runtimeRow` matched 54/64,
61/64, and 61/64. The residual differences occurred across a capture-time
board transition.

V2 therefore preserves runtime `(row,col)` for DTO hashes and DTO-to-Dot
validation, then flips only the row when constructing provider-neutral
`BoardState` for V1. Columns are unchanged.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs`
- original field tokens `0x040009B1` through `0x040009B4` in the attributed
  Cpp2IL assembly.

## Why `WsCombatBatch.board` is useful but not persistent

`MatchService.ParseCombatBatch` constructs `WsCombatBatch` and converts the
payload's `"board"` token to `BoardCellDTO[][]`, then stores it at batch `+0x38`.
The recovered `MatchService` field `PendingCombat` is at `+0x170`, but native
`ConsumePendingCombat()` reads that field and clears it to `NULL`. Therefore the
field cannot be the primary persistent board anchor. Phase 2A.5 polls it as the
highest-confidence transient observation only.

The Phase 2A observer may find still-live batch objects in one bounded heap scan.
It validates all 64 DTOs, coordinates, bounded UTF-16 tags, and selects the
greatest validated `srvSeq`. The log explicitly retains this limitation: the
batch is not independently linked back to `Board.Instance`, so after operations
it may be a historical snapshot. A decoded tag is authoritative for that batch,
not automatically for a later `allDots` state.

Phase 2A.5 removes the post-match ambiguity by inventorying all validated batch
identities while still in the lobby. It accepts only a new identity first seen
after a new `Board.Instance` lifecycle begins, then requires repeated
hash/sequence transitions and rendered-Dot convergence. The fallback scan is
limited to writable `MEM_PRIVATE` regions no larger than 8 MiB; it is not a
whole-RAM pointer scan.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/WsCombatBatch.cs:10`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:315`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`,
  `ParseCombatBatch` and `ConsumePendingCombat`.
- `WsCombatBatch` type-info global slot: preferred VA `0x1835354A0`, build RVA
  `0x35354A0`, observed in the native allocation path.

## `BoardWsApplier` flow

- `HandleMatchStart` / `HandleMatchResync` supply payloads to
  `LoadBoardFromSnapshot`.
- `LoadBoardFromSnapshotCore` is a coroutine. Its state-machine field retains the
  payload dictionary while running; its local `BoardCellDTO[][]` is not a declared
  persistent owner field.
- It loops the DTO board and calls `SpawnDotByTag`.
- `SpawnDotByTag` selects a prefab, instantiates a GameObject, gets its `Dot`
  component, writes `Dot.column`, `Dot.row`, `Dot.originalPrefab`, optional
  multiplier, and the GameObject into `Board.allDots`.
- `VerifyBoardAgainstServer(BoardCellDTO[][])` compares DTO `tag` and multiplier
  with the rendered objects and replaces a mismatched cell through
  `SpawnDotByTag`.
- `BoardWsApplier` has no singleton. Its type-info global slot is build RVA
  `0x3508D40`; Phase 2A.5 identifies the live component only when its exact
  runtime class and `board +0x20 == Board.Instance` both validate. Its
  `_pendingBatches +0x50` queue is decoded only after runtime validation of the
  array/capacity/head/tail/size invariants.

Native method evidence for the current hashed build:

| Method | Original token | RVA |
|---|---:|---:|
| `HandleMatchStart` | `0x06000BC8` | `0x7448E0` |
| `HandleMatchResync` | `0x06000BCA` | `0x744710` |
| `LoadBoardFromSnapshot` | `0x06000BCD` | `0x746260` |
| `LoadBoardFromSnapshotCore` | `0x06000BCE` | `0x7461D0` |
| `FindDotPrefabByTag` | `0x06000BD1` | `0x742DA0` |
| `SpawnDotByTag` | `0x06000BD3` | `0x7479C0` |
| `ApplySwap` | `0x06000BE4` | `0x741DA0` |
| `VerifyBoardAgainstServer` | `0x06000BE7` | `0x748D50` |
| `ApplyFall` | `0x06000BE8` | `0x73FE80` |
| `ApplySpawn` | `0x06000BE9` | `0x7409F0` |

Primary evidence files:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs:754-958`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs:28`

## Gem type source decision

The best Phase 2A source is a validated `BoardCellDTO.tag` from
`WsCombatBatch.board`. `Dot` has no managed tag/type field. Its best persistent
identity field is `originalPrefab`, but identity-to-gem correlation requires
multiple boards and an independent label source.

Native `FindDotPrefabByTag` shows the game recognizes the Vietnamese color tag
set `do/tim/trang/vang/xanh/xanhduong`; live DTO strings were observed with the
exact suffix form `"do Dot"`, `"tim Dot"`, etc. V1 independently classifies
red/purple/neutral/yellow/green/blue as `RAGE/SHIELD/DRAIN/SWORD/HEALTH/MANA`.
The observer maps only these six exact normalized tags. Any other or absent tag
is logged with `gem: null`; it performs no fuzzy inference.

Unity `GameObject.tag`/name traversal is not implemented. Native game methods are
not called, and undocumented Unity native object layout is not guessed.

## Runtime result — 2026-08-11

After the second user-played match initialized the batch type metadata, the
one-shot read-only `tools/combat_batch_probe.py` scan produced
`logs/phase2a_postmatch_batch_scan_20260811.json`:

| Item | Result |
|---|---|
| committed readable regions | `1167` |
| bytes read | `3,416,039,976` |
| failed chunks | `0` |
| aligned `WsCombatBatch Il2CppClass*` hits | `22` |
| structurally valid batches | `1` |
| batch object | `0x000001B047D9CAF0` |
| `srvSeq` | `98` |
| `board` array | `0x000001AFC3417150` |
| validated cells / unique coordinates | `64 / 64` |
| bounded UTF-16 tags | `64 / 64` |
| exact tag-to-gem mappings | `64 / 64` |

Tag counts were: `do Dot=8`, `tim Dot=11`, `trang Dot=11`, `vang Dot=11`,
`xanh Dot=12`, `xanhduong Dot=11`.

This proves the external DTO/tag decoder (Phase 2A PASS 3). It does **not** prove
that this post-match batch is the current rendered board after every operation:
the batch has no independently verified reference back to `Board.Instance`, and
was captured after the Board lifecycle ended. The source is authoritative for
the server sequence represented by `srvSeq=98`; continuous currentness remains
an explicit Phase 2B question.
