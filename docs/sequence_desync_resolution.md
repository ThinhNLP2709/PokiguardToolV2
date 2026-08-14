# Sequence desync resolution

Status: Stage A implementation and captured-log replay PASS. The current
combat session is treated as terminal; no protocol repair is attempted.

## Exact detection sources

The detector accepts only these strong observations:

| Runtime observation | Classification |
|---|---|
| message type `FORCE_RESYNC` | `FORCE_RESYNC` |
| `MATCH_REJECT` with structured `rejectReason=FORCE_RESYNC` | `FORCE_RESYNC` |
| `MATCH_REJECT` with a sequence gap reason/code | `MATCH_REJECT_SEQ_GAP` |
| `MATCH_REJECT` with a sequence duplicate reason/code | `MATCH_REJECT_SEQ_DUPLICATE` |
| more than one of the above in a session | `MULTIPLE` |

Cpp2IL declares `ChatMessageDTO.rejectReason` as `System.String` at instance
offset `0x100` in
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs`. That field is
the primary reject evidence. A declared code in `matchPayload` takes precedence
when present. Free-text payload matching is used only when neither structured
source exists. An unrelated `MATCH_REJECT`, such as card cooldown or mana
failure, does not set sequence desync.

`MatchService.cs` independently declares `_localSeqNum` at `0xB0`,
`_ackedSeqs` at `0x180`, and `LastMoveSeqNum` at `0x1D0`; these are telemetry,
not writable repair targets. Cpp2IL also names `HandleMatchReject`,
`HandleMatchResync`, and `RequestResync`, but their presence does not authorize
or justify direct invocation.

## Session semantics

`SequenceDesyncState.terminal_for_session` is sticky. Silence, a new turn,
board changes, timer changes, or an accepted-looking local animation cannot
clear it. Clearing requires both:

1. hardened lifecycle evidence that the old local combat session ended; and
2. a different, clean session key/match ID accepted by the memory provider.

A stale message for an old match is ignored. A new key presented before the
old session was invalidated is also rejected rather than clearing the guard.

## Actionability and pending input

`GateReason.SEQUENCE_DESYNC` is evaluated before all normal lifecycle, solver,
PASS, fallback, card, Fusion and SWAP paths. The production single-step
controller also checks the desync guard before ACK waiting and decision code.

If the first signal arrives with a proposal or sent action pending:

- the proposal is discarded;
- the action lock is released immediately with
  `REJECTED_SEQUENCE_DESYNC`;
- its action identity stays consumed, so there is no retry;
- the normal ACK timeout is not awaited;
- the idle cache is not changed and no intentional PASS is recorded.

## Three different terminal/strategy conditions

| Condition | Meaning | Handling |
|---|---|---|
| `legalMoveCount == 0` | `DEAD_BOARD` | technical `DEAD_BOARD_NO_REFRESH` recovery candidate |
| sequence reject/force resync, legal count may be positive | `SEQUENCE_DESYNC` | terminal session; confirmed UI recovery only |
| `legalMoveCount > 0 && safeMoveCount == 0` | `POLICY_NO_SAFE_MOVE` | BASIC PASS/mandatory-action problem, not technical recovery |

Sequence desync outranks the board categories because valid moves are no longer
accepted by the server. Timer values remain telemetry only; no deadline
fallback is sent after detection.

## Captured incident replay

Fixture: `reference/sequence_desync_m714b231e.jsonl`, selected verbatim semantic
records from
`logs/phase2c2a31_fusion_retry_20260813_021626.jsonl`.

Replay command:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\replay_sequence_desync.py
```

Result:

```text
detected=true
source=MULTIPLE
first_seen_at=2026-08-12T19:40:00.357Z
match_id=M_714b231e
terminal_for_session=true
reject_kind=SEQ_GAP_OR_DUPLICATE
```

The fixture proves FORCE_RESYNC, repeated gap/duplicate rejection, legal moves
at turns 33/35, and authoritative idle 1/3 then 2/3. It does not contain the
server's expected client sequence. Therefore root telemetry reports observed
values but leaves `expected`, computed `gap`, and computed `duplicate` UNKNOWN;
the server's structured reason remains the classification evidence.

## First-detection artifact

Both the read-only diagnostic watcher and production single-step controller
write exactly one directory per detected session under `logs/sequence_desync/`:

```text
<timestamp>_<match>/
    state.json
    board.json
    screenshot.png
    recent_events.json
```

The 50-event ring includes sent moves, ACKs, local/server/current sequences,
`LastMoveSeqNum`, force-resync/reject messages, turn and lifecycle changes.
Fusion state/attempt count is correlated, while `causalityClaim` remains null.

## Safety boundary

No `_localSeqNum` write, WriteProcessMemory, fake ACK, packet send/replay,
RequestResync call, SendMove call, WebSocket call, injection, hook, or binary
patch exists in this implementation.

