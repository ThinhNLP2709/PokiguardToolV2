# Multiplier data flow (Phase 2A.5)

Scope: `GameAssembly.dll` SHA-256
`5A993B8AEF2371F6053AA46C692592CE32FF8418071E85357541F7FB504D58B3`.
All target access used for runtime validation is external and read-only.

## Declared storage

| Assembly | Type | Member | Declared type | Instance offset | Evidence | Confidence |
|---|---|---|---|---:|---|---|
| Assembly-CSharp | `BoardCellDTO` | `multiplier` | `System.Int32` | `+0x20` | `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs:8` | CONFIRMED |
| Assembly-CSharp | `Dot` | `multiplier` | `System.Int32` | `+0x88` | `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Dot.cs:37` | CONFIRMED |

These are separate values at different lifecycle stages. Equality is not
assumed; Phase 2A.5 logs both for the same `(row,col)`.

## Initial snapshot flow

The generated body of
`BoardWsApplier+<LoadBoardFromSnapshotCore>d__21.MoveNext()` converts payload
key `"board"` to `BoardCellDTO[][]`. In the nested loops it loads:

- `cell + 0x18` as the tag argument;
- `cell + 0x20` as the multiplier stack argument;
- the loop indices as row/column;
- then calls `BoardWsApplier.SpawnDotByTag`.

The exact ISIL evidence is
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier_NestedType__LoadBoardFromSnapshotCore_d__21.txt:552-582`.
The public coroutine factories have RVAs `LoadBoardFromSnapshot = 0x746260`
and `LoadBoardFromSnapshotCore = 0x7461D0`; the actual loop is in the generated
state-machine body.

```text
payload["board"]
  -> BoardCellDTO[][]
  -> cell.tag (+0x18), cell.multiplier (+0x20)
  -> SpawnDotByTag(col, row, tag, multiplier, false)
```

`HandleMatchStart` (RVA `0x7448E0`) and `HandleMatchResync` (RVA `0x744710`)
route their snapshot payload into this loader. The owner/lifecycle evidence is
in `BoardWsApplier.txt`; no persistent DTO collection field exists on `Board`.

## Dot creation and default

`Dot..ctor()` writes integer `1` to `this + 0x88` before calling the base
constructor. Evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Dot.txt:7712-7778` (ISIL operation
`Move [rcx+136], 1`). This proves the rendered Dot default in this build.

`SpawnDotByTag` (RVA `0x7479C0`) then:

1. selects and instantiates the prefab;
2. obtains its `Dot` component;
3. writes `originalPrefab +0xD8`, `column +0x20`, and `row +0x24`;
4. if the incoming multiplier is greater than 1, writes it to `Dot +0x88` and
   calls the board's multiplier-text creation path;
5. stores the owning GameObject in `Board.allDots[col,row]`.

Evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt`, method
`SpawnDotByTag`, especially the compare/write around disassembly
`cmp r8d,1; mov [rbx+88h],r8d` and ISIL operations 166-177.

Therefore the supported static flow is:

```text
server DTO multiplier
  -> SpawnDotByTag multiplier argument
  -> default Dot.multiplier = 1
  -> if argument > 1: Dot.multiplier = argument + multiplier UI text
```

## Incremental operation flow

### `ApplySpawn` — RVA `0x7409F0`

`ApplySpawn` reads `op.data["multiplier"]` with default `1`, clamps the result
to at least `1`, and passes it to `SpawnDotByTag`. Evidence:
`BoardWsApplier.txt:10001-10320`, ISIL operations 81-96 and 147-154.

```text
op.data["multiplier"] (missing -> 1)
  -> max(1, raw)
  -> SpawnDotByTag(...)
  -> Dot.multiplier
```

### `ApplyFall` — RVA `0x73FE80`

`ApplyFall` removes one existing GameObject reference from its old `allDots`
coordinate, inserts the same GameObject at the new row, and calls
`UpdateDotPos`/`Dot.MarkFalling`. It does not write `Dot +0x88`. Thus a
multiplier moves with its Dot. Evidence: `BoardWsApplier.txt:9683-9994`.

### `ApplySwap` — RVA `0x741DA0`

`ApplySwap` exchanges two existing GameObject references in `allDots` and calls
`UpdateDotPos` for both. It does not write `Dot +0x88`. Thus multipliers move
with their gems. Evidence: `BoardWsApplier.txt:8633-8870`.

### `VerifyBoardAgainstServer` — RVA `0x748D50`

For each DTO/rendered coordinate, verification compares tags and compares
`max(1, Dot.multiplier)` with `max(1, BoardCellDTO.multiplier)`. A mismatch
destroys/replaces that rendered cell through `SpawnDotByTag`, passing the DTO
multiplier. Evidence: `BoardWsApplier.txt:9165-9623`, ISIL operations 139-203.

The normalization means the verifier treats raw DTO `0` and rendered default
`1` as semantically equal. It does **not** prove that the server actually emits
zero. Runtime raw values therefore remain logged without normalization.

## Batch ownership and temporal ordering

`MatchService.HandleResEnvelope` parses operations, applies the state delta,
calls `ParseCombatBatch`, writes the resulting batch to instance field
`PendingCombat +0x170`, reads `WsCombatBatch.srvSeq +0x10`, and invokes the
consumer event. Evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt:14796-14888`.

`BoardWsApplier` consumes and clears `PendingCombat`, then enqueues a tuple
containing the batch in `_pendingBatches +0x50`; `_renderRunning +0x58` controls
the drain coroutine. Evidence:
`BoardWsApplier.cs:766-767`, `BoardWsApplier.txt:5176-5275`, and
`MatchService.txt:5821-5872`.

Consequently the DTO batch can lead the rendered Dots during animation. A
solver-safe publication cannot be based on DTO validity alone.

## Runtime observations before live acceptance

The retained Phase 2A post-match batch at `srvSeq=98` contained:

| Raw value | Cells |
|---:|---:|
| 1 | 46 |
| 2 | 9 |
| 3 | 4 |
| 4 | 5 |

Source: `logs/phase2a_postmatch_batch_scan_20260811.json`. This proves storage
of all values `1..4`, but not current-match ownership by itself.

V1 independently recognizes visible x2/x3/x4 badges and represents absence as
1. Its supplied screenshot test asserts exact values 2, 3, and 4 at visible
badge coordinates (`D:/PokiguardAuto/tests/test_vision_samples.py:859-884`).
This is UI validation reference only; CV is not the V2 production source.

The final runtime mapping and DTO↔Dot totals are filled from the Phase 2A.5
live JSONL capture and reported in `docs/phase2a5_report.md`.

## Phase 2A.5 live acceptance (2026-08-11)

`logs/live_cell_state_20260811_235015.jsonl` was started in the lobby, where
the batch baseline contained zero candidates. During the next combat it saw
nine distinct new server states with strictly increasing sequence values:
`9, 31, 44, 49, 53, 63, 71, 73, 75`. Their canonical hashes all differed.

The final accepted state (`srvSeq=75`, turn `35`) contained exactly 64 DTOs and
the following raw distribution:

| Raw value | Cells |
|---:|---:|
| 1 | 46 |
| 2 | 10 |
| 3 | 7 |
| 4 | 1 |

The rendered board converged twice consecutively to 64 unique `Dot`
coordinates with `64 matches / 0 mismatches / 0 missing`. Static creation code
passes the raw integer to both `Dot.multiplier` and the multiplier-text path;
the supplied V1 visual samples independently label visible badges x2/x3/x4;
and the user confirmed this live match visibly contained all three. The
accepted mapping is therefore:

| Runtime raw | UI/game meaning |
|---:|---|
| 1 | normal / x1 |
| 2 | x2 |
| 3 | x3 |
| 4 | x4 |

Transient DTO/Dot mismatches were also observed before convergence, including
`srvSeq=71` where DTO `(6,4)` was `1` while the rendered Dot was still `3`.
Those samples were never published. This confirms the server snapshot can lead
the rendered board and justifies the two-consecutive-confirmation gate.
