# Phase 2C.1 actionability signals

## Current 1.7.4-b2 correction — 2026-09-11

This section supersedes the historical field offsets later in this document.
The current default-gameplay repair remains Phase 2 and awaits live retest.

| Signal | Exact b2 source | Gate behavior |
|---|---|---|
| Render ACK | `MatchService._ackedSeqs +0x1B8` | selected `srvSeq` must be current and ACK-attested |
| Board move state | `Board.active +0x168`, `currentState +0x78`, `hasDestroyedThisTurn +0x125`, `isProcessingUI +0x1E0`, `isGameOver +0x2E0` | reproduce the corresponding native move checks |
| Start/clock gate | `HasServerClock +0x164`, `ClockPaused +0x165`, `ClockPauseReason +0x168` | paused/start gate blocks input |
| Turn timer | `TurnDurationSec +0x44`, `TurnTimeRemainingSec +0x138` | exact integer server tick; missing/invalid fails closed |
| Connection/recovery | `ChatService isConnected +0x28`, explicit disconnect `+0x2D4`, reconnect coroutine `+0x2D8`, connecting `+0x2E4`; `MatchService` resync `+0x1F0` | unavailable/disconnected/recovering blocks input |
| Presentation batches | `MatchService._inFlightBatches +0x1B0` | positive value gives `PRESENTATION_BUSY` |
| New turn announcement | `TurnAnnouncer` TypeInfo RVA `0x2DDAE68` -> static fields -> `_blocking +0x80` | true gives `PRESENTATION_BUSY` and `client_move_allowed=false` |
| Board modal/action flags | Mega-2 `+0x129`, Mega `+0x398`, resume `+0x3B0`, Mega-1 `+0x470` | active Mega/modal/action transition blocks normal board input |
| Legend telemetry | Legend `+0x391` | retained for Pet Skill/QTE state; does not alone block a settled ordinary board |

Reverse b2 declares `_blockDeadline +0x84` and `HARD_BLOCK_SEC=3`. Native
`Board.IsPlayerAllowedToMove` calls `TurnAnnouncer.get_IsBlockingInput` at RVA
`0x3D3870`. The external provider reads the static `_blocking` bool only. The
game Runner clears it after the deadline, so this may conservatively block one
extra frame but cannot open input early. No fixed wait is guessed.

An ACK can advance for an ops-only combat response that has no replacement
8x8 board DTO. In that case the provider reads the current rendered board by
the exact bounded chain `Board.allDots -> GameObject native components -> Dot`.
All 64 Dot components must have the exact Dot class, current Board owner,
unique coordinates, known `PoolTag`, valid multiplier and no motion/render flag.
The entire chain and ACK HashSet are sampled twice. A missing/unstable result is
state unavailability; it never becomes a policy PASS.

### Phase 3C.0 exact modal telemetry and durable-latch correction — 2026-09-12

`BattleState` exposes the four exact b2 flags:

- `board_is_using_legend_card` from `Board +0x391`;
- `board_is_using_mega` from `Board +0x398`;
- `board_is_mega1_panel_open` from `Board +0x470`;
- `board_is_mega2_panel_open` from `Board +0x129`.

Live retry 5, match `M_d5a467a1`, proved that `isUsingLegendCard` remains true
through the boss turn and into the next settled local turn after a runtime
Perfect. On local turn 19, all three Mega/modal flags were false and every
other gate passed; the former aggregate returned `MODAL_OPEN`, while removing
only the Legend contributor returned `PASS`.

The production `board_modal_open` aggregate therefore contains Mega execution,
Mega1 panel and Mega2 panel only. Exact Legend state remains available as
telemetry and for the dedicated Pet Skill/QTE control path. Presentation,
cascade, clock, turn, lifecycle and board-state gates continue to block input
during the actual Legend animation. See [phase3c0_report.md](phase3c0_report.md).

## Phase 2C.2A.4 terminal override

`SEQUENCE_DESYNC` is now evaluated before every gameplay permission below. A
positive `SequenceDesyncState.terminal_for_session` blocks solver, PASS,
fallback, card, Fusion and SWAP for the rest of that combat session. It is not
an intentional PASS and does not mutate authoritative idle state. See
`docs/sequence_desync_resolution.md`.

This document records every signal used to authorize one normal Windows
two-click board swap.  The controller fails closed: a missing or inconsistent
required signal produces a non-actionable `GateReason`.

Offsets below this correction are retained as historical Phase 2C.1 evidence.
Runtime objects are resolved through verified IL2CPP static/type-info chains
using `GameAssembly.dll base + RVA`; no absolute ASLR-dependent address is
stored.

## Current snapshot and session

| Requirement | Runtime source | Authorization rule | Evidence/confidence |
|---|---|---|---|
| Combat exists | resolved `Board.Instance` and current `(epoch, Board*, matchId)` session key | Board must exist and the snapshot session must equal the provider's current session | Phase 2B.5 runtime lifecycle; HIGH |
| Production board | preferred `WsCombatBatch.board : BoardCellDTO[][]`; b2 ops-only fallback `Board.allDots -> GameObject -> Dot` | exactly 64 unique coordinates, exact known tags, multipliers in x1..x4; direct fallback additionally requires exact component/Board ownership and settled Dot flags | `memory_board_hardening.md`; HIGH, first live run 5/5 accepted |
| Current/acknowledged | `MatchService._ackedSeqs : HashSet<Int64>` at b2 `+0x1B8` | selected sequence must equal the highest stable ACK watermark; the board may be a same-sequence DTO or the double-sampled rendered Dot board after that ACK | b2 `HandleResEnvelope`/`SendAnimAck`; HIGH, first live run passed |
| Stable/rendered | `BoardWsApplier` owner/queue/render state, `Board.allDots` reference-array stability, identical DTO/hash confirmation twice | publisher must label the state stable, ready and non-cascade | Phase 2B.5 acceptance; PASS STRONG |

`ActionabilityGate` also requires a valid 64-character SHA-256 `boardHash`,
`BoardState.production_ready`, `acknowledged=True`, `latest=True`, and an
`_ackedSeqs` source witness.

## Game's own move-permission signals

Native `Board.IsPlayerAllowedToMove()` is the strongest direct authorization
evidence. Its Cpp2IL ISIL body returns true only when all of these conditions
hold:

- `Board.isGameOver` at `+0x2A8` is false;
- `Board.active` at `+0x158` exists;
- `MatchService.Instance` exists and `CurrentMatchId` at `+0x20` is nonempty;
- `MatchService.IsStartGatePaused` is false;
- `MatchService.IsLocalTurn()` is true;
- `Board.isProcessingUI` at `+0x1D0` is false;
- `Board.hasDestroyedThisTurn` at `+0x125` is false;
- `Board.currentState : GameState` at `+0x78` equals `GameState.move` (1).

The provider reproduces those checks as `BattleState.client_move_allowed`.
The centralized gate still checks their individual source fields so logs state
the exact rejection reason.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:945,1005,1034,1063,1441`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`, method
  `Board.IsPlayerAllowedToMove`

Confidence: HIGH, direct native method body plus declared offsets.

## Local-turn ownership

`MatchService.IsLocalTurn()` does not hard-code actor 1. It reads
`ChatService.Instance.username` at `ChatService+0x30` and compares it with
`MatchService.CurrentTurnPlayer` at `MatchService+0x38` using
`StringComparison.OrdinalIgnoreCase`.

Phase 2C.1 reproduces that exact comparison with Unicode `casefold()`:

- missing ChatService, username, or current-turn player -> `TURN_UNKNOWN`;
- unequal values -> `NOT_LOCAL_TURN`;
- equal values -> `is_local_turn=True`.

The local actor number decoded from the proven solo `Active.PlayerStats` layout
is telemetry/stats ownership only; it is not the turn-authorization source.

Evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatService.cs:149-151`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:1280`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`, method
  `MatchService.IsLocalTurn`

Confidence: HIGH, direct native method body.

## Alive, end-state and modal signals

| Signal | Exact source | Gate behavior | Confidence |
|---|---|---|---|
| Player alive | decoded local `Active.PlayerStats.currentHP/maxHP` | unknown/invalid stats fail closed; HP <= 0 -> `PLAYER_DEAD` | runtime-proven in Phase 2B, HIGH |
| Boss alive | decoded boss `Active.PlayerStats.currentHP/maxHP` | unknown/invalid stats fail closed; HP <= 0 -> `BOSS_DEAD` | runtime-proven in Phase 2B, HIGH |
| Board game over | `Board.isGameOver : Boolean` `+0x2A8` | true -> `GAME_OVER`; missing -> `END_STATE_UNKNOWN` | CONFIRMED field; native move check |
| Match game over | `MatchService._matchOver : Boolean` `+0x1B2` | true -> `MATCH_OVER` | `HandleMatchGameOver` writes it before result presentation; HIGH |
| Deferred result | `MatchService._hasDeferredGameOver : Boolean` `+0x228` | true -> `GAME_ENDING` | CONFIRMED field and native result flow; HIGH |
| Mega-2 panel | `Board.isMega2PanelOpen : Boolean` `+0x129` | true -> `MODAL_OPEN` | CONFIRMED |
| Mega-1/Fusion panel | `Board.isMega1PanelOpen : Boolean` `+0x408` | true -> `MODAL_OPEN` | CONFIRMED |
| Legend card in progress | `Board.isUsingLegendCard : Boolean` `+0x349` | true -> `MODAL_OPEN` | CONFIRMED |
| Mega/Fusion in progress | `Board.isUsingMega : Boolean` `+0x350` | true -> `MODAL_OPEN` | CONFIRMED |
| Room resume | `Board.isResuming : Boolean` `+0x368` | true -> `RECONNECTING` | CONFIRMED |

The generic active state of every unrelated Unity UI GameObject has not been
resolved externally. That remains **UNKNOWN** and is not guessed. The known
Board modal/action flags, game-over flags, death stats, current-state check,
renderer-idle check and disappearance of `Board.Instance` jointly block input
during the evidenced combat-result transitions.

## Connection, resync and clock

| Signal | Exact source | Gate behavior |
|---|---|---|
| Connected | `ChatService.isConnected : Boolean` `+0x28` | false -> `DISCONNECTED`; unavailable -> `CONNECTION_UNKNOWN` |
| Explicit disconnect | `ChatService._explicitDisconnect : Boolean` `+0x286` | true -> `RECONNECTING` |
| Reconnect coroutine | `ChatService._reconnectCoroutine : Coroutine` `+0x288` | non-null canonical pointer -> `RECONNECTING` |
| Connecting | `ChatService._connecting : Boolean` `+0x294` | true -> `RECONNECTING` |
| Match resync | `MatchService._resyncCoroutine : Coroutine` `+0x1B8` | non-null canonical pointer -> `RECONNECTING` |
| Presentation batches | `MatchService._inFlightBatches : Int32` `+0x178` | positive -> `PRESENTATION_BUSY` |
| Server clock | `HasServerClock +0x128`, `ClockPaused +0x129`, `ClockPauseReason +0x130` | paused clock/start gate -> `CLOCK_PAUSED` |

All object/string/coroutine pointers are validated as canonical readable user
pointers before use. The stable provider read requires action signals before
and after DTO/render inspection to be identical.

For post-click acknowledgement, `MatchService._ackedSeqs.highest` is consumed
directly even while the provider correctly withholds an unstable/rendering
`GameState`. A value greater than the action's source `srvSeq` releases the
input lock. The next solver proposal still waits for the normal fully stable,
ACK-attested board publication; only lock acknowledgement uses this earlier
transition witness.

## Foreground and window geometry

The input boundary stores the initial Pokiguard HWND, PID and client size. It
rechecks HWND ownership, visibility, non-minimized status, fixed client size,
client-to-screen geometry and `GetForegroundWindow()`:

- while gating;
- during F8 revalidation;
- before each click;
- after moving the cursor and before each mouse-down.

It never calls `SetForegroundWindow`, `ShowWindow`, or window restore APIs.
Focus loss before click 1 sends no click. Focus loss after click 1 produces
`PARTIAL_INPUT`, omits click 2, consumes the action identity, and emergency
pauses the controller.

## Fail-closed ordering

The deterministic evaluation order is implemented in
`src/pokiguard_v2/actionability.py`. Board/session/currentness and stability are
checked before solver eligibility; ownership, alive/end/modal, connection and
client move permission follow; input lock, auto-pause, window validity and
foreground are checked last. The solver and input executor are never called to
authorize a state the gate rejected.
