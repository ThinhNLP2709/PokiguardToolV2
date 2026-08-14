# PokiguardToolV2 — Phase 2A report

Date: 2026-08-11. Scope remained external read-only. No solver/input integration,
target method call, memory write, injection, hook, patch, or network manipulation
was performed.

## 1. `allDots` exact runtime layout

Cpp2IL native evidence and runtime agree:

```text
Board + 0x140 -> GameObject[,] allDots
allDots + 0x10 -> bounds
allDots + 0x18 -> max_length = 64
allDots + 0x20 -> first GameObject reference
bounds + 0x00 -> first dimension length = 8
bounds + 0x10 -> second dimension length = 8
index = col * second_dimension_length + row
```

Observed `allDots=0x000001AF1C6FD2A0`, bounds
`0x000001AF1C6FD4C0`, raw bounds qwords `[8,0,8,0]`, zero lower bounds and
padding. Full raw header is in `docs/il2cpp_array_layout.md`.

## 2. Bounds and max length

- dimensions: `8 × 8`
- lower bounds: `(0,0)`
- max length: `64`
- result: verified, fail-closed decoder accepted

## 3. GameObject elements

All 64 slots were readable, non-null, and unique. Native index order is
column-major with row as the second dimension: `col*8+row`. The observer presents
cells in normal row/column order by applying that proven transform.

## 4. Dot layout

The complete instance layout through `+0xEC`, original field tokens, and native
method RVAs are recorded in `docs/il2cpp_symbols.md`. Fields directly used:

- `column +0x20`
- `row +0x24`
- `_board +0x48`
- `multiplier +0x88`
- `originalPrefab +0xD8`
- inherited `UnityEngine.Object.m_CachedPtr +0x10` as a live-object signal only

There is no managed tag/type/color/enum field on `Dot`.

## 5. Dot scanner result

First combat Board: `0x000001B07C71F000`.

- scanned 1,200 committed readable regions once;
- read 3,365,642,757 bytes; 13 chunks became unreadable during the scan;
- found 183 aligned occurrences of `Board*`;
- validated 56 active exact-class Dot objects;
- 56 unique coordinates, no duplicates;
- missing `(row,col)`: `(1,6)`, `(2,5)`, `(2,6)`, `(3,5)`, `(4,5)`,
  `(5,5)`, `(5,7)`, `(7,4)`;
- six distinct `originalPrefab` identities were present among the 56.

This is a near-complete PASS 2, not a claim of 64. The array changed all 64
GameObject references 135 ms after validation completed, which is strong evidence
of a temporal race between a 14-second full scan and board replacement. No
missing pointer was guessed.

## 6. `allDots` GameObject ↔ Dot relationship

`GameObject*` is not equal to `Dot*`. Native `SpawnDotByTag` proves that it gets
the Dot component from an instantiated GameObject, writes the same `(col,row)` to
Dot, then stores the owner GameObject into `allDots[col,row]`. Phase 2A correlates
the two sets by that native-proven coordinate relation only. It does not traverse
undocumented Unity native object layout.

## 7. Best gem-type source

Best source: `WsCombatBatch.board -> BoardCellDTO[][] -> BoardCellDTO.tag`.

One post-match scan found 22 class-pointer hits but only one object passed all
structural checks. It contained 64 unique cells and exact strings:
`do Dot`, `tim Dot`, `trang Dot`, `vang Dot`, `xanh Dot`, `xanhduong Dot`.
All 64 mapped exactly to V1's six gem semantics. Unknown strings remain null.

`Dot.originalPrefab` remains the best persistent fallback identity source, but
its mapping requires same-board correlation. The DTO recovered after the later
match did not correlate one-to-one with the earlier Dot snapshot. Its exact
match ownership is not independently linked, so no cross-match identity mapping
is accepted.

## 8. Sample decoded board

The validated batch at `srvSeq=98` decoded to:

```text
MANA   SHIELD MANA   SHIELD SWORD  SHIELD HEALTH HEALTH
DRAIN  RAGE   SWORD  DRAIN  SHIELD MANA   SHIELD MANA
MANA   HEALTH MANA   HEALTH RAGE   SWORD  SWORD  RAGE
SWORD  SWORD  RAGE   SHIELD SHIELD RAGE   DRAIN  RAGE
SWORD  DRAIN  HEALTH HEALTH DRAIN  SHIELD HEALTH MANA
HEALTH DRAIN  SHIELD SWORD  HEALTH SHIELD DRAIN  DRAIN
RAGE   HEALTH SHIELD DRAIN  MANA   HEALTH HEALTH SWORD
DRAIN  SWORD  MANA   SWORD  MANA   MANA   DRAIN  RAGE
```

This is an authoritative server-batch snapshot, but it was recovered post-match.
It is not labeled as a live current board after every move.

## 9. Blockers / UNKNOWNs

1. A single full-memory scan did not freeze the game state and yielded 56/64 live
   Dot objects before a wholesale board replacement.
2. `WsCombatBatch.board` is temporary. A reliable low-latency live pointer owner
   for the latest batch has not been proven.
3. After `ApplySwap/Fall/Spawn`, continuous synchronization between the latest DTO
   snapshot and `allDots` remains UNKNOWN.
4. External `GameObject -> Dot` or tag/name native traversal remains deliberately
   unimplemented without documented native evidence.

## 10. Files created or modified in Phase 2A

Created:

- `docs/board_data_sources.md`
- `docs/il2cpp_array_layout.md`
- `docs/phase2a_report.md`
- `src/pokiguard_v2/il2cpp_layout.py`
- `src/pokiguard_v2/memory_scan.py`
- `tools/runtime_common.py`
- `tools/all_dots_probe.py`
- `tools/dot_candidate_watch.py`
- `tools/board_memory_watch.py`
- `tools/combat_batch_probe.py`
- `tests/test_il2cpp_layout.py`
- runtime logs `logs/phase2a_live_20260811.*` and
  `logs/phase2a_postmatch_batch_scan_20260811.json`

Modified:

- `docs/il2cpp_symbols.md`
- `src/pokiguard_v2/il2cpp_external.py`

No file in `D:/PokiguardAuto` or `D:/pc` was modified.

## 11. Tests and pass level

`python -m unittest discover -s tests -v`: **24/24 passed**.

- PASS 1 (`allDots` layout and 64 elements): **PASS STRONG**
- PASS 2 (Dot set): **NEAR PASS**, 56/64 active unique coordinates
- PASS 3 (external direct tag source): **PASS**
- Strong live current 8x8 reconstruction without CV: **NOT YET CLAIMED**;
  full 64 decoding is proven for a post-match server batch, not continuously for
  the current rendered board.

Phase 2A stops here for review. Solver and input remain untouched.
