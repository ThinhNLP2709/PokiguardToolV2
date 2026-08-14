# Phase 2C.2A.3.1 report

Status: implementation, tests, lobby smoke and normal-combat board diagnostics
PASS. Fusion produced strong mana/at-response evidence; hardened correlation,
idle and same-turn post-success SWAP still need one more runtime acceptance.
Autonomous execution remains disabled.

## Delivered

1. Exact dead-board gate requiring ACTIVE/local/stable/current/64 valid cells
   and zero exhaustive legal swaps.
2. Exhaustive analysis of all 112 adjacent pairs through the existing
   production board simulator.
3. Separate raw legality, safe/dangerous classification and BASIC policy.
4. Full 64-cell local-turn JSONL diagnostics including both coordinate systems,
   multipliers, hashes, stats, cards, Fusion, idle and timing.
5. Automatic zero/low-move artifacts with deterministic offline replay and
   best-effort screenshot audit.
6. Distinct no-move, late attempt and timeout-rejection classifications.
7. Every Fusion attempt correlated with before/response/after snapshots,
   drop reason, mana/turn/timer/idle and live UI interactability.
8. Fail-closed future retry semantics: server response plus a fresh unlocked,
   unused and genuinely interactable UI state. No automatic click was added.
9. Required BASIC `NONE`/`PASS` observability for Sword, Rage, Mana, Health,
   Cast, Drain and Shield. Intermediate boss-resource behavior is unchanged.

## Fusion conclusions before new combat acceptance

- Repeated failure does not set `fusion.used`; it locks the current attempt turn.
- A new proposal may occur on a later actionable turn; it is not permanently
  marked attempted.
- Turn 49 success set `fusion.used=true`.
- Failure/success mana delta, exact turn consumption, timer behavior and idle
  reset remain UNKNOWN where the old log did not preserve an uncontaminated
  before/after pair.
- Same-turn post-success SWAP has partial prior evidence and is a target for the
  new watcher, not an autonomous action.

## Tests

`python -m unittest discover -s tests -v` passes 138 tests after this phase's
new coverage. New tests cover:

- exhaustive legality and safety separation;
- exact dead-board gating;
- 64-cell coordinate preservation and tamper rejection;
- artifact/replay determinism;
- all deadline classifications;
- policy why-not logging;
- Fusion failure/success/retry/idle/confounder behavior;
- dependency-free PNG encoding;
- BASIC stop/retry proposal semantics.

## Runtime acceptance command

Run only from a known lobby:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\combat_diagnostic_watch.py --watch --matches 1
```

The tool is read-only and performs no SWAP, CAST, EVOLVE, PASS or EXIT. It should
be running before the manual match starts. Acceptance requires full board and
legality data for every accepted stable local-turn identity. Strong dead-board
acceptance additionally requires a naturally occurring `legalMoveCount <= 2`
artifact.

Lobby smoke evidence: `logs/phase2c2a31_lobby_smoke.jsonl`. The watcher attached
to x64 PID 2184, classified the scene as lobby, completed 35 polls plus one
baseline scan, and stopped with zero read errors or retained Fusion attempts.

## First normal-combat acceptance

Evidence: `logs/phase2c2a31_acceptance_20260812_231345.jsonl`, match
`M_2c027c0d`, manual win.

- watcher stopped automatically and cleanly at postmatch;
- 12/12 provider-published stable local boards contained 64 cells and all 112
  adjacent-pair results;
- legal count range was 5..19; no dead/near-dead artifact was expected;
- three boards had legal moves but zero safe moves, confirming legality/policy
  separation in real combat;
- 11 detected manual swaps were accepted; no timeout rejection was recorded;
- failure on turn 7 cost 160 mana, left `fusion.used=false`, and an accepted
  same-turn SWAP followed at six seconds;
- success on turn 23 cost 160 mana, set `fusion.used=true`, preserved the local
  turn at response, and raised max HP from 83,385 to 105,228;
- the turn-23 timer expired without a SWAP, so same-turn post-success action
  acceptance remains untested;
- no clean authoritative idle pair followed either attempt, so S3 is UNKNOWN.

The run also revealed transient ordering/reuse behavior in ChatMessageDTO:
response visibility can precede the durable attempt field, and a reused object
can momentarily retain `MATCH_FUSION_RES` without an exact success payload. The
tracker was hardened after this run to merge the former and reject the latter
from semantic correlation while retaining the raw server-message log.

## Remaining blockers

- No current full-board record exists for the old turn-51 stall, so it cannot
  retrospectively be called a dead board.
- One more manual combat run is required to validate the hardened one-record-
  per-attempt correlator after the second run exposed response-before-transition
  while `LastAttemptTurn` still held the previous positive turn. The tracker
  now attributes that provisional response to the live local turn. The second
  run did validate FusionUI toggling true before attempts, false while locked,
  and true again when actionable.
- Fusion idle reset S3 remains UNKNOWN unless a clean authoritative payload
  pair appears without a SWAP/CAST confounder.
- An exact zero-legal-move board remains naturally unobserved; the read-only
  phase does not force one. The near-dead (`legal=1`) artifact path is now
  runtime-confirmed.

## Low-board/sequence-desync strong acceptance

Match `M_714b231e` produced the reported game bug. The diagnostic system passed
its strong acceptance target:

- full turn-33 artifact with board JSON/text, analysis and screenshot;
- deterministic replay: `legal=1`, `safe=0`, `dangerous=1`, `dead=false`;
- the sole legal move was actually attempted at nine seconds remaining;
- server rejected it with `SeqNum gap/duplicate — resync needed`;
- turn 35 still had three legal moves and a legal attempted move was rejected
  repeatedly for the same reason;
- idle warnings progressed to 1/3 and 2/3 because the rejected moves did not
  count, then lifecycle returned to lobby.

This is a client/server local move-sequence desynchronization, not a dead board,
policy refusal or deadline miss. `MOVE_REJECTED_SEQUENCE_DESYNC` is now an
explicit diagnostic classification. No resync packet, network modification or
automatic exit was added.

## Safety boundary

No automatic swap/card/Fusion/pass/exit, memory write, injection, direct game
method, packet modification or binary change was introduced.
