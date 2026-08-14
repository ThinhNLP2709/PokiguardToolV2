# Phase 2A.5 report

Run date: 2026-08-11 (UTC log timestamps; local timezone Asia/Saigon).
Target access was external read-only with only process-query and VM-read rights.

## 1. Final realtime board source

The source is `WsCombatBatch.board : BoardCellDTO[][]` at server sequence
`srvSeq`, correlated with the rendered `Board.Instance.allDots`/`Dot` state.
The accepted final state was `srvSeq=75`, turn `35`, Board
`0x000001B07D0F5A80`.

The primary direct owner chain (`MatchService.PendingCombat` then
`BoardWsApplier._pendingBatches`) is too short-lived to be sampled reliably.
The watcher therefore uses a bounded writable `MEM_PRIVATE` candidate scan, but
only after validating exact class, full 8x8 DTO shape, tags, multipliers and
the current Board lifecycle.

## 2. Latest/current determination

The watcher started in the lobby and found zero retained valid batches. It
then accepted only batch identities first seen after a new `Board.Instance`
appeared. Currentness is supported by:

- exclusion from the lobby baseline;
- first sighting within the current Board lifecycle;
- monotonically increasing `srvSeq`;
- nine distinct canonical state transitions;
- convergence of the final DTO to the current rendered Dots.

## 3. Sequence and timestamp evidence

The capture recorded sequence values `9, 31, 44, 49, 53, 63, 71, 73, 75`
from `16:53:59.989Z` through `16:57:23.416Z`. Every sequence had a different
SHA-256 over sorted `(row,col,tag,multiplierRaw)`. This is not repeated access
to one stale post-match object.

## 4. 64 live GemType

**PASS.** The accepted snapshot has 64 cells, all 64 unique coordinates, six
exact Vietnamese tag mappings, and zero `UNKNOWN` gems.

## 5. Observed raw multiplier values

Live combat observed raw values `1, 2, 3, 4`. The final stable distribution
was `1:46, 2:10, 3:7, 4:1`.

Earlier live distributions demonstrate growth over the match: sequence 9 had
`1:64`; sequence 31 had `1:58,2:4,3:2`; sequence 53 first included value 4.

## 6. Exact runtime-to-UI mapping

**PASS:** `1 = normal/x1`, `2 = x2`, `3 = x3`, `4 = x4`.

Evidence combines the native DTO-to-Dot/text flow, exact DTO/Dot equality in
the final board, V1's supplied x2/x3/x4 screenshot tests, and the user's visual
confirmation that this live match contained all three badge types.

## 7. DTO multiplier versus Dot multiplier

The accepted state converged twice consecutively at:

- matches: `64`
- mismatches: `0`
- missing Dot: `0`
- ambiguous coordinates: `0`

Across earlier transitions, the bounded scan often found only a partial Dot
set. Transient mismatches were real and rejected; for example sequence 71 had
DTO `(6,4)=1` while the rendered Dot was still `3`, with three Dots missing and
the `allDots` array changing. Interpretation: authoritative DTO state can lead
the animated/rendered board.

## 8. Stable-state criteria

A state is published only when all conditions hold twice consecutively:

- the same current `Board.Instance` remains active and is exactly 8x8;
- `isBoardReady` is true before and after the scan;
- `isCascadeRunning` is false before and after the scan;
- `allDots` elements are unchanged across the scan;
- DTO has 64 unique coordinates, 64 known gems and only raw multipliers 1..4;
- exactly 64 unique current-Board Dots are found;
- every DTO multiplier equals its coordinate's Dot multiplier;
- canonical hash and `srvSeq` are unchanged for both confirmations.

## 9. Full accepted 8x8 board

Rows are `0..7`, columns are left to right. `GEMxN` includes multiplier.

```text
MANAx1   DRAINx1  RAGEx1    HEALTHx1 SWORDx1  HEALTHx1 DRAINx1  MANAx1
SHIELDx1 RAGEx1   SHIELDx1  HEALTHx2 RAGEx3   DRAINx1  SHIELDx1 RAGEx1
RAGEx1   HEALTHx1 SWORDx1   RAGEx1   SHIELDx3 RAGEx1   MANAx1   DRAINx1
SWORDx1  SHIELDx1 SWORDx1   MANAx3   SHIELDx3 HEALTHx3 SWORDx1  SWORDx1
DRAINx1  RAGEx1   HEALTHx1  SWORDx2  MANAx1   SWORDx2  HEALTHx1 DRAINx2
SHIELDx1 SHIELDx1 HEALTHx2  SWORDx2  RAGEx3   SHIELDx1 MANAx1   SHIELDx1
DRAINx1  DRAINx1  RAGEx3    HEALTHx1 SHIELDx2 SWORDx1  MANAx2   MANAx1
RAGEx1   HEALTHx1 MANAx1    HEALTHx4 SWORDx2  DRAINx1  DRAINx1  HEALTHx2
```

## 10. V1 solver multiplier support

V1 already has a separate `MultiplierBoard`. It swaps multipliers together
with gems, carries them through collapse/refill simulation, counts
`max(1,multiplier)` in match value, and includes multiplier-aware risk/scoring.
V2 only needs to adapt `BoardState.board` plus `BoardState.multipliers` into
that existing boundary; the solver does not need rewriting.

## 11. Remaining blockers

- The bounded scan did not recover all 64 rendered Dots on every transition;
  it reached 64 only near the final state. This affects publication latency,
  not DTO decoding correctness.
- `MatchService.PendingCombat` and the BoardWs queue were normally empty at
  sampling time. A less scan-dependent current-batch anchor remains desirable.
- The watcher process ended after the successful JSON write because the
  Windows console could not encode the Unicode arrow in one status line. The
  source is fixed to ASCII; the valid accepted JSON event was not lost.
- Direct authoritative `BoardWsApplier.ApplyCardUse` operation capture remains
  unverified; the durable no-rollback CardUI result is currently used as the
  strong accepted-state signal for the attack card.

## 12. Files created or modified in Phase 2A.5

Created:

- `docs/multiplier_flow.md`
- `docs/card_state_detection.md`
- `docs/phase2a5_report.md`
- `src/pokiguard_v2/live_state.py`
- `src/pokiguard_v2/combat_cards.py`
- `tools/live_cell_state_watch.py`
- `tests/test_live_state.py`
- `tests/test_combat_cards.py`

Modified:

- `docs/board_data_sources.md`
- `docs/il2cpp_symbols.md`
- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/memory_scan.py`
- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/__init__.py`
- `tests/test_il2cpp_layout.py`
- `tests/test_state_model.py`

Runtime artifacts:

- `logs/phase2a5_smoke.jsonl`
- `logs/live_cell_state_20260811_235015.jsonl`
- `logs/live_cell_state_20260812_001627.jsonl`
- matching stdout/stderr logs.

No file under `D:/PokiguardAuto` or `D:/pc` was modified by this work.

## 13. Tests

`python -m compileall -q src tools tests`: PASS.

`python -m unittest discover -s tests -v`: **34/34 PASS**.

## 14. Requested card detection addendum

The new read-only watcher can detect both cards:

- Evolution/Fusion success: direct `MatchService.LocalFusionUsed +0x60`, set
  only by the successful Fusion response path.
- Attack card/Chưởng availability: exact current Board/Active-owned `CardUI`,
  `CardData.elementTypeCard`, and the game-refreshed `Button.m_Interactable`.

Attack-card used flags are optimistic until a reject rollback is excluded, so
the log intentionally calls this `combat_card_use_observed`, not
server-confirmed. See `docs/card_state_detection.md` for the evidence and live
acceptance results.

The second live run completed this acceptance:

- one direct `fusion_success` at turn 21, persistent through turn 49;
- attack card ID 4 (`ATTACK`) was identified and became interactable;
- durable no-rollback uses were observed at turns 37, 39, 45, and 49;
- watcher ended cleanly with 37 distinct board hashes and six stable publishes.

Therefore both requested card-state detectors pass Phase 2A.5. Direct
authoritative operation capture for ordinary cards is a remaining refinement,
not a blocker for detecting availability or accepted client state.
