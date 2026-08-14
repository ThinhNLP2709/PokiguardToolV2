# Phase 2B report — memory integration / shadow mode

Phase 2B is stopped before Phase 2C. The implementation is read-only and no
V2 input path was enabled. Runtime evidence is mixed: solver/stats/cards/Fusion
worked in a complete lifecycle, but stable Dot resolution is not reliable
across fresh provider runs and the >=20 CV comparison target was not met.

## Acceptance summary

| Criterion | Result | Evidence |
|---|---|---|
| PASS 1: stable current 8x8, 64 GemTypes + 64 multipliers | **PARTIAL / BLOCKED** | 13 states passed every gate in `phase2b_acceptance_v3.jsonl`; later fresh runs could not recover 64 current Dots reliably. |
| PASS 2: memory state feeds existing V1 solver without CV board | **PASS** | 13 post-orientation decisions in the strongest run; adapter imports the exact V1 solver. |
| PASS 3: multiple consecutive shadow decisions | **PASS for captured lifecycle** | 13 unique decision keys; stale/unstable candidates were skipped, no crash or duplicate decision emitted. |
| PASS 4: >=20 memory-vs-CV boards | **FAIL** | Only 5 full CV boards after orientation correction; 0 exact boards. |
| PASS 5: cards + Fusion in unified state | **PASS** | Attack-card use/turn transitions and Fusion `false -> true` captured. |
| Strong full-lifecycle pass | **PARTIAL** | Lobby -> combat -> 13 stable states -> solver/card/Fusion -> boss HP 0 -> lobby, but provider convergence was late and CV target failed. |

## 1. Production `GameState` structure

`src/pokiguard_v2/state.py` defines immutable provider-neutral models:

- `CellState(row, col, gem, multiplier)` and exact `BoardState[8][8]`;
- `BattleState` with Board instance, server sequence, turn, current-turn name,
  stable flag, raw board hash, and source list;
- `ParticipantState` for player/boss stats;
- enumerated `CardState[]` and `FusionState`;
- `GameState` with `LOBBY`, `COMBAT`, or `UNKNOWN` phase.

Runtime rows are bottom-origin. Only the solver boundary applies
`screenRow = 7 - runtimeRow`; raw DTO hashes and DTO-to-Dot validation retain
runtime coordinates.

## 2. `MemoryBoardStateProvider`

`src/pokiguard_v2/memory_board_provider.py` implements the read-only provider.
It resolves build-relative IL2CPP type-info/singleton chains and uses only
`PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`.

It combines:

- current `Board.Instance`, `Active`, and `MatchService`;
- validated `WsCombatBatch` candidates;
- `BoardWsApplier._pendingBatches` and `MatchService.PendingCombat` when live;
- exact 64 DTO tags/multipliers;
- current live Dot class/Board/coordinate/multiplier validation;
- player stats, equipped cards, and Fusion state.

The final code unions the original <=8 MiB bounded Dot scan with an
`allDots`-anchored allocation-region scan. This union keeps all strict
validators but has **not** received a successful post-change runtime
acceptance; it remains blocked.

## 3. Latest/stable snapshot selection

Selection and publication rules are:

1. require an accepted current 8x8 `Board.Instance`;
2. exclude lobby, retired, and first-observed lifecycle batch identities;
3. accept only complete 64-coordinate DTOs with known tags and multipliers
   in `{1,2,3,4}`;
4. choose the highest sequence; reject same-sequence conflicting hashes and
   sequence regression;
5. require Board ready/non-cascading before and after the read;
6. require unchanged 64-element `allDots` array;
7. require 64 unique current-Board Dots and exact DTO/Dot multiplier equality;
8. require the same `(Board,srvSeq,hash)` twice consecutively;
9. deduplicate emitted states by `(Board.Instance,srvSeq,boardHash)`.

No stale or partially validated board is converted to `GameState`.

## 4. Multiplier representation

Raw values are retained exactly: `1=x1`, `2=x2`, `3=x3`, `4=x4`. The V2 board
stores multiplier per cell and the V1 adapter constructs V1's parallel token
and multiplier boards. Multiplier is never silently discarded.

## 5. Existing V1 multiplier support

V1 already separates matched cell count from effective collected resources.
The adapter reuses that logic. The regression fixture containing Sword
`x1+x4+x1` produces effective Sword value `6`, proving the x4 value reaches
the existing evaluator without a solver rewrite.

## 6. Solver adapter

`src/pokiguard_v2/v1_solver_adapter.py` imports the exact read-only files under
`D:/PokiguardAuto/pokiguard_auto`, builds the existing `CombatContext`, and
calls the existing `decide_turn()` / `evaluate_moves()` functions. It does not
copy or fork gameplay logic and does not import V1's executor.

Memory stats take precedence. CV contributes optional non-board hints only
when a memory field has no source. The solver board always comes from memory.

## 7. Player stats

The native-proven `ObfuscatedInt.Value` decoder reads:

- current/max HP;
- current/max Mana;
- current/max Power (rage/nộ);
- attack;
- shield.

The strongest runtime capture exactly matched the user's visible final player
HP `32563/105228`; boss HP was `0/84180`. During successful evolution,
player max HP changed `83385 -> 105228`.

Unresolved/fail-closed cases:

- local ownership in co-op (multiple non-boss actors) remains `None`;
- no proven local username anchor exists for authorizing the current turn;
- missing/invalid stats are `None`, never invented as zero.

## 8. Card state model

The provider enumerates actual current-Board/current-Active card UI objects;
there is no hard-coded ID-4-only reader. Runtime observed:

- ID 1, `Hồi mana`, type `MANA`, value 101;
- ID 2, `Hồi nộ`, type `POWER`, value 50;
- ID 4, `Tấn công`, type `ATTACK`, value 6280, condition 160.

All three exposed both interactable states. Attack exposed
`hasUsedThisTurn=false/true` and `lastTurnUsed=-1,33,35,37,39`.

## 9. Fusion state model

Captured fields include available, used, per-turn lock, last attempt turn,
Mana cost, stat bonus, selected pet IDs, and optional skill-card data.

Runtime transitions proved:

- `used: false -> true`;
- available/locked toggles;
- Mana cost `160`;
- stat bonus `70%`;
- the corresponding max-HP increase described above.

## 10. Memory versus CV comparison

The best post-orientation run (`phase2b_acceptance_v3.jsonl`) produced:

| Metric | Result |
|---|---:|
| full 64-cell CV boards | 5 |
| cells compared | 320 |
| GemType matches | 279 |
| GemType mismatches | 41 |
| unknowns in partial observations | 88 |
| multipliers compared | 320 |
| multiplier matches | 312 |
| multiplier mismatches | 8 |
| exact accepted boards | 0 |

The >=20-board target and preferred 64/64 GemType accuracy were **not met**.
Mismatches were logged unchanged. No CV value corrected or filled a memory
board. Pre-poll temporal audit was implemented later, but the subsequent Dot
resolution failure produced no publishable memory state with which to test it.

## 11. Shadow decision count

Historical development captures emitted 24 decisions total (`3 + 8 + 13`),
all with unique dedup keys. The strongest orientation-correct full lifecycle
emitted 13 consecutive decisions. The final anchor-only validation emitted
zero and therefore is not counted as a success.

## 12. Duplicate/stale behavior

- duplicate decision keys emitted: `0`;
- stale candidates were skipped, never published;
- the completed early summary recorded `duplicate_skips=5`, `stale_skips=0`;
- the final failed anchor summary recorded `duplicate_skips=0`,
  `stale_skips=0`, `unstable_skips=301`, and `read_errors=0`;
- intermediate status logs include duplicate/stale transitions, but those are
  gate outcomes rather than emitted solver decisions.

## 13. Card/Fusion transitions

In the strongest run the logger captured 33 card transitions and 5 Fusion
transitions. It observed Attack interactability/use/last-turn changes and
Fusion availability, lock, and successful-use changes. V2 did not click them;
the user performed the actions.

## 14. Blockers before V2 may control input

1. **Current Dot resolution is not restart-stable.** The original bounded
   scan can converge late; anchor-only validation reached at most 58/64 and
   then lost candidates during fall/spawn. The final union implementation is
   unverified at runtime.
2. **CV acceptance failed.** Only 5 full comparisons were obtained after the
   row-orientation fix, versus the target of at least 20, and none was exact.
3. **Turn authorization is incomplete.** Solo participant ownership is proven
   for captured matches, but co-op/local username and authoritative local-turn
   identity are unresolved.

Therefore V2 input remains disabled. Recommended next evidence work, not
implemented here: resolve a stable GameObject/component owner chain for Dot;
find a manager-maintained Dot collection; or prove a non-scan current render
anchor from Unity/Cpp2IL internals. No whole-RAM scan should be added.

## 15. Files created/modified

Phase 2B code/docs/tests:

- `docs/phase2b_report.md`
- `docs/v1_solver_contract.md`
- `docs/player_stats_resolution.md`
- `docs/shadow_mode.md`
- `docs/board_data_sources.md`
- `docs/card_state_detection.md`
- `docs/il2cpp_symbols.md`
- `src/pokiguard_v2/__init__.py`
- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/live_state.py`
- `src/pokiguard_v2/memory_scan.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/obfuscated_int.py`
- `src/pokiguard_v2/player_stats.py`
- `src/pokiguard_v2/combat_cards.py`
- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/v1_solver_adapter.py`
- `src/pokiguard_v2/v1_cv_validation.py`
- `tools/shadow_bot.py`
- `tools/live_cell_state_watch.py`
- `tests/test_state_model.py`
- `tests/test_live_state.py`
- `tests/test_il2cpp_layout.py`
- `tests/test_combat_cards.py`
- `tests/test_obfuscated_int.py`
- `tests/test_player_stats.py`
- `tests/test_v1_solver_adapter.py`
- `tests/test_v1_cv_validation.py`

Principal Phase 2B evidence logs:

- `logs/phase2b_acceptance_20260812.jsonl` and `_v2.jsonl` plus stdout/stderr;
- `logs/phase2b_acceptance_final.jsonl` plus stdout/stderr;
- `logs/phase2b_acceptance_v2.jsonl` through `_v5.jsonl` plus stdout/stderr;
- `logs/phase2b_anchor_acceptance_v6.jsonl` plus stdout/stderr;
- `logs/phase2b_shadow_smoke.jsonl`;
- `logs/phase2b_shadow_smoke_global.jsonl`;
- `logs/phase2b_direct_dots_lobby_smoke.jsonl`;
- `logs/phase2b_learned_regions_lobby_smoke.jsonl`;
- `logs/runtime_board_watch_20260812_022129.jsonl`;
- `logs/runtime_board_watch_20260812_022953.jsonl`.

No file under `D:/PokiguardAuto` or `D:/pc` was modified.

## 16. Tests

Final local verification:

- `python -m unittest discover -s tests -q`: **48/48 PASS**;
- `python -m compileall -q src tools tests`: **PASS**;
- runtime process rights: query + read only;
- final anchor validation: one complete lifecycle, zero read errors, zero input,
  but zero publishable states due incomplete Dot resolution.

Phase 2B ends here. Phase 2C is not started.
