# Dead-board resolution

Phase 2C.2A.4 now handles the independently proven sequence failure as
`SEQUENCE_DESYNC`; it must never enter `DEAD_BOARD_NO_REFRESH` merely because
the rendered board stops responding. See `docs/sequence_desync_resolution.md`.

Status: instrumentation, lobby smoke and normal-combat acceptance pass; a
naturally occurring low/dead-board artifact remains pending.

## Production definition

V2 sets `deadBoard=true` only when all of these facts are present in one
snapshot:

```text
combat lifecycle == ACTIVE
isLocalTurn == true
board is stable, acknowledged and latest
isBoardReady == true
isCascadeRunning == false
exactly 64 production-valid cells
exhaustive legalMatchProducingMoves == 0
```

If any gate is missing, `deadBoard` is `null` rather than false. Visual
appearance, a BASIC `NONE`/`PASS`, or a board on which every legal move is
dangerous never establishes a dead board.

Implementation: `src/pokiguard_v2/board_diagnostics.py`.

## Exhaustive legality

The diagnostic path calls the existing production
`board_simulator.evaluate_all_moves`. The simulator considers all 56 horizontal
and 56 vertical adjacent pairs. A pair is raw game-legal when the swapped board
creates at least one match; policy preference is not involved.

Each stable local-turn diagnostic records:

- `totalAdjacentSwaps=112`;
- `legalMoveCount` and `illegalNoMatchSwaps`;
- every legal move with screen/runtime coordinates, direct clears,
  deterministic cascade rounds, resources, danger and unknown exposure;
- `safeMoveCount` and `dangerousMoveCount` over only the legal set;
- BASIC decision and its independent policy trace.

Therefore `legal=7, safe=0` is a live but dangerous board, while `legal=0` is a
dead-board candidate subject to the runtime gates above.

## Stable-board log

`tools/combat_diagnostic_watch.py` starts from lobby and has no input path. For
each accepted stable local-turn state identity it writes one
`stable_local_board_diagnostic` JSONL event containing:

- session, match, sequence, turn, current player and `Board.Instance`;
- provider board hash plus an independent SHA-256 diagnostic hash;
- board readiness/cascade state and turn timer;
- player, boss, cards, Fusion and authoritative idle state;
- all 64 cells with runtime and screen coordinates, exact `GemType` and
  multiplier;
- all legality/safety/policy fields described above;
- state, decision and remaining-time timestamps.

The provider remains the source of truth. A screenshot is audit material only.

## Low-board artifacts

When the raw legal count is at most two, the watcher creates a unique directory
under `logs/dead_board/`:

```text
<timestamp>_<event>_seq<srvSeq>_<hash>/
    board.json
    board.txt
    analysis.json
    screenshot.png       # best effort; may be absent with a recorded reason
```

The event is `dead_board` for zero legal moves and
`low_legal_move_count` for one or two. `board.json` uses schema
`pokiguard.dead_board.v1`, contains the complete `GameState`, and repeats every
cell's runtime/screen coordinates, gem and multiplier. The loader rejects wrong
schema, missing/duplicate cells, invalid gems/multipliers, or inconsistent row
mapping.

`analysis.json` stores session/match/sequence/turn, both hashes, timer,
lifecycle, stats, idle, all legal moves and the policy observation. Screenshot
failure does not discard the memory-derived artifact.

## Deterministic replay

Run:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\replay_board_state.py <board.json>
```

The replay reconstructs the validated `GameState`, reruns the same production
simulator and BASIC engine, and outputs legal moves, direct/cascade results,
danger and policy. It never attaches to or inputs into the game.

## Timer classification

Timer outcomes are independent of board legality:

| Classification | Meaning |
|---|---|
| `NO_LEGAL_MOVE` | exhaustive count is exactly zero |
| `MOVE_NOT_ATTEMPTED_TOO_LATE` | legal moves exist, no attempt, remaining <= 1 |
| `MOVE_ATTEMPTED_TOO_LATE` | legal moves exist and an attempt was observed at remaining <= 1 |
| `MOVE_REJECTED_TIMEOUT` | server rejection text explicitly indicates time/deadline |
| `MOVE_REJECTED_SEQUENCE_DESYNC` | server reports `SeqNum` gap/duplicate or demands resync |
| `MOVE_REJECTED_OTHER` | rejected for another or unknown reason |
| `MOVE_ACCEPTED` | response accepted the detected move |

The `<=1` boundary is diagnostic evidence from the last Phase 2C.2A.3 run, not
an autonomous deadline policy. Future runtime evidence can refine it.

## Acceptance state

- Unit/offline replay: PASS.
- Lobby smoke: PASS on 2026-08-12, PID 2184, x64, 35 read-only polls, one lobby
  baseline scan, zero read errors; evidence
  `logs/phase2c2a31_lobby_smoke.jsonl`.
- Normal combat full-board logging: PASS in match `M_2c027c0d`; evidence
  `logs/phase2c2a31_acceptance_20260812_231345.jsonl`. The watcher published 12
  stable local-turn identities and every diagnostic contained exactly 64 cells,
  `totalAdjacentSwaps=112`, hashes, timer, stats, legal/safe/danger counts and
  policy. All 11 detected manual swaps were server-accepted.
- The observed legal range was 5..19. Turns 3, 17 and 27 had respectively
  `legal/safe/dangerous = 14/0/14`, `11/0/11`, and `19/0/19`, directly proving
  that zero safe moves is not a dead board. Every accepted state had
  `deadBoard=false`.
- Strong low-board artifact/replay: PASS in the later `M_714b231e` incident
  documented below. An exact naturally occurring zero-legal-move board remains
  unobserved.

## Sequence-desync incident `M_714b231e`

The next manual match produced the user's visible "board will not move" failure,
but exhaustive memory evidence proves it was **not** a dead board:

- 15 stable local-turn diagnostics, every one with 64 cells and 112-pair scan;
- turn 33 / server sequence 76 had exactly one legal move and zero safe moves;
- the watcher saved a complete low-board artifact, screenshot and analysis;
- offline replay reproduced exactly the same hash, one legal move and BASIC
  `PASS` decision;
- turn 35 had three legal moves, again with zero safe moves.

Artifact:
`logs/dead_board/20260813_024015_931_low_legal_move_count_seq76_bdcfa99bd748/`.
The only turn-33 legal move was screen `(2,2) <-> (2,3)` (zero-based), or the
visible third row/third and fourth columns. It creates a vertical three-Mana
clear at screen column 3 with effective multiplier total six. The user attempted
that exact runtime move `(5,2) <-> (5,3)` with nine seconds remaining. The
server rejected it:

```text
MATCH_REJECT
SeqNum gap/duplicate — resync needed
```

At turn 35, the user also attempted the simulator-legal runtime
`(5,3) <-> (5,4)` move. It and repeated attempts were rejected for the same
sequence reason at remaining 9, 6, 3 and 2 seconds. This excludes timeout,
coordinate error and no-legal-move as the cause.

The incident began at turn 31 with `FORCE_RESYNC`, followed by numbered
gap/duplicate rejects. The client did not recover its local move sequence;
authoritative idle reached 1/3 then 2/3 despite valid manual attempts, and the
session returned to lobby. Production classification is therefore
`MOVE_REJECTED_SEQUENCE_DESYNC` / client-server sequence desynchronization.

This phase does not repair or bypass the network protocol. A future controller
must fail closed on the first such rejection, stop sending normal input, retain
the artifact, and only propose a normal UI exit/re-entry after explicit approval.
