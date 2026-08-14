# V1 solver contract used by Phase 2B

Scope: `D:/PokiguardAuto` was inspected read-only. Phase 2B imports the existing
`pokiguard_auto.models` and `pokiguard_auto.solver` modules in place. It does
not copy, fork, or edit the solver.

## Exact entrypoints

The full pure decision entrypoint is:

```python
decide_turn(
    board: Board,
    context: CombatContext,
    consecutive_skips: int,
    blocked: set[tuple[Cell, Cell]] | None = None,
    multipliers: MultiplierBoard | None = None,
    max_consecutive_skips: int = 2,
    allow_skip: bool = True,
    skip_min_player_hp: float = 0.40,
    skip_bad_board_score: float = 26.0,
    many_swords_threshold: int = 14,
    aggressive_finish_hp: float = 0.25,
    solver_mode: str = "default",
    ai_time_budget_ms: int = 900,
    ai_candidates: int = 10,
    ai_rollouts: int = 6,
    refill_risk_samples: int = 4,
    max_safe_boss_swords: int = 3,
    opening_required: bool = False,
    late_game_skip_allowed: bool = False,
) -> TurnDecision
```

The lower entrypoint is `evaluate_moves(board, context, blocked, multipliers,
refill_risk_samples) -> list[MoveEvaluation]`. Evidence:
`D:/PokiguardAuto/pokiguard_auto/solver.py:1064` and `:1954`.

`Board` is `tuple[tuple[Token,...],...]`; `MultiplierBoard` is a separate
parallel `tuple[tuple[int,...],...]`. `Token` values exactly equal V2's
`GemType` values. Coordinates and moves are zero-based `(row,col)`. Evidence:
`D:/PokiguardAuto/pokiguard_auto/models.py:8-43`.

## Input classification

Classification required by Phase 2B:

- **A**: available from the V2 read-only memory path.
- **B**: still supplied by V1/CV during shadow validation.
- **C**: no proven Phase 2B source.
- **D**: not consumed by the pure move solver (it may still matter to orchestration).

| Input/fact | Class | Exact use and Phase 2B source |
|---|---|---|
| 64 `Token` values | A | `WsCombatBatch.board -> BoardCellDTO.tag`, accepted only after current Dot/render convergence. |
| 64 multiplier values | A | `BoardCellDTO.multiplier`, exactly cross-checked against `Dot.multiplier`; adapter passes the complete parallel matrix. |
| Player HP ratio | A/B | `Active.PlayerStats.currentHP/maxHP` now has a native-evidenced decoder. If local ownership is ambiguous in co-op, optional V1 CV ratio is the fallback. |
| Enemy/boss HP ratio | A/B | Actor 99 is the declared WS boss. CV remains fallback if the stats list cannot be safely decoded. |
| Player Mana | A/B | Decoded `currentMana`; adapter preserves V1's current `/160` normalization. CV exact rail value is fallback. |
| Player Rage/Power | A/B | Decoded `currentPower`; adapter preserves V1's `/100` normalization. CV exact rail value is fallback. |
| Enemy Mana/Rage | A/B | Decoded boss actor state when present; otherwise V1 CV rail values. These inputs change Drain and opponent weights. |
| Shield | D | V1 `CombatContext` has no shield field; it is retained in V2 `ParticipantState` for future policy. |
| Max Mana/Power | D | Needed to report state, but V1 deliberately uses fixed 160/100 scales rather than these maxima. |
| `evolution_available` | A/B | Conservative memory candidate from Fusion enabled/not-used/not-locked; V1 visible card state remains an optional shadow hint. Memory availability is not permission to click. |
| `evolution_used` | A | `MatchService.LocalFusionUsed`, server-success response semantics. |
| `attack_available` | A/B | Any current Board/Active-owned attack-type `CardUI` with `Button.m_Interactable`; CV glow is fallback only. No card ID is hard-coded. |
| Battle strategy and weight thresholds | A | Read from V1 `config.json`, not duplicated defaults unless a key is absent. |
| Finishing-phase absolute HP thresholds | B | V1 obtains `<10k`/`<30k` from CV. Phase 2B can use a decoded ratio but does not invent an absolute threshold when ownership/stats are unavailable. |
| `consecutive_skips` | C | V1 engine session state. Shadow keeps its own hypothetical count; it is not claimed to equal the simultaneously running V1 controller. |
| `blocked` bounced/phantom moves | C | V1 engine derives this from click acknowledgement/CV history. Shadow passes an empty set and logs decisions only. |
| opening-player-turn latch | C | V1 engine session state. Shadow treats its first published state as opening for fail-safe no-skip behavior. |
| smart-skip player-turn count | C | V1 engine counts player turns. Shadow counts its own unique published memory states. |
| current turn owner | D/C | Pure `decide_turn` does not consume it. `MatchService.CurrentTurnPlayer` is A, but mapping that username to the local account externally is C, so V2 is not authorized to act. |
| turn number / `srvSeq` | D | Not used for scoring. Both are A and are used for lifecycle/dedup/stale rejection. |
| CV board | D | Never passed to the Phase 2B solver. CV is an independent comparison oracle only. |

## Multiplier behavior already present in V1

V1 swaps a multiplier with its gem, carries it through deterministic collapse,
sets refill values to 1, and adds `max(1,multiplier)` to the collected resource.
It also uses multiplier-weighted Sword values in hard-priority and risk policy.

The existing V1 unit test at
`D:/PokiguardAuto/tests/test_solver.py:551` proves that a boosted Sword moved by
swap increases `collected`. The V2 adapter test extends that boundary with x4:
a three-Sword match containing x1+x4+x1 reports effective collected Sword 6.

Thus V1 already distinguishes:

- match membership/cell count, used by match and shape rules;
- effective collected resource, stored in `MoveEvaluation.collected` and
  multiplier-weighted.

Phase 2B does not change or reinterpret the game's multiplier formula.

## Card/Fusion policy boundary

V1 has card tactics, but they are private methods and temporal latches inside
the large `AutoFarmEngine`, not a pure solver entrypoint. They depend on two
clean CV frames, exact HP thresholds, turn/banner gates, evolution animation
signatures, skip history, pending clicks, and card arming state. Calling those
methods from a separate shadow process would require recreating hidden engine
state and would not be the "same" policy.

Phase 2B therefore reuses the pure V1 gem decision exactly and exposes only the
action vocabulary `SWAP`, `USE_CARD`, `FUSION`, `NONE` for cards. It logs which
actions are possible from memory, but does not select or click a card. Extracting
V1 card policy into a shared pure module is a later, reviewed task.

## Adapter limitations that matter before control

`V1SolverAdapter` is suitable for shadow comparison, not input authorization:

1. it imports the exact V1 solver path and passes memory board/multipliers;
2. it uses decoded memory stats when local ownership is unambiguous and CV hints
   otherwise;
3. it cannot reproduce V1's bounced-move blocklist or exact skip/session latches;
4. it does not claim to reproduce V1's engine-level card-first action order.

