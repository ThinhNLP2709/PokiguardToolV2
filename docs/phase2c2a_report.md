# Phase 2C.2A report — BASIC policy engine

## Result

Phase 2C.2A is implemented in shadow-only form. It formalizes the requested
configuration/actions, exhaustively simulates the current 64 cells without
inventing refills, evaluates Sword exposure, applies the BASIC rules in order,
and emits a full `DecisionTrace`.

No autonomous execution was added. In particular, this phase does not click
Evolution, Attack, swaps, PASS, or exit controls.

## Screenshot regression

The supplied screenshot was transcribed into
`reference/phase2c2a_basic_policy_fixture.json` with its SHA-256 and visible
combat resources. Coordinates are zero-based screen rows in code and preserve
the user's one-based example.

The critical swap is:

```text
user:    (row 7, col 6) SHIELD <-> (row 7, col 7) RAGE
V2:      (6,5) <-> (6,6)
direct:  Rage effective 3
cascade: Rage effective 7 + Sword effective 6
total:   Rage 10 + Sword 6, one known cascade round
```

The same board has naive direct Sword moves worth 5, 5, and 3 effective Sword.
The STEP 2 ranker selects the indirect `(6,5)<->(6,6)` result.

## Consecutive PASS evidence

Cpp2IL proves `MATCH_AFK_WARN.matchPayload` keys `idleCount` and `threshold`
(default 3). `MatchService.HandleMatchAfkWarn` immediately raises
`OnAfkWarn(username,idleCount,threshold)` and stores neither integer.
`BoardWsApplier.HandleAfkWarn` only displays the warning. Chat history does not
retain this event branch.

Accordingly:

- `BattleState.consecutive_passes = None`;
- threshold 3 is recorded, but without a source-backed count;
- STEP 6 returns `NONE/GAME_OWNED_SKIP_STATE_UNKNOWN` when PASS would otherwise
  be considered;
- the old V1/session local counter is not used by BASIC policy.

## Timer

The memory provider now publishes the latest integer server countdown tick
from `MatchService +0x118` and duration from `+0x44`. It intentionally labels
the source `MatchService.server_tick`; no smooth countdown is fabricated from
an unproven Unity clock.

## Policy ambiguity

The user did not define a priority for intermediate boss Mana/Rage states. A
non-mandatory state with safe legal moves but no exact branch returns
`NONE/BASIC_INTERMEDIATE_FALLBACK_UNDEFINED`. A first turn or proven two-pass
state still uses the explicit mandatory least-dangerous rule.

## Tests

`python -m unittest discover -s tests -v` passes **90/90** tests. New regression
coverage includes:

- screenshot indirect Sword cascade and multiplier preservation;
- all known results vs explicit UNKNOWN refill cells;
- generalized gapped Sword region;
- exhaustive zero-legal-move board;
- EVOLVE reread contract and ATTACK-priority evolution disable;
- CAST threshold/reserve;
- game-owned PASS known/unknown handling;
- mandatory first/two-pass action;
- timer safety gate and unimplemented REASONING mode.

## Shadow command

From a game lobby, with no other memory probe running:

```powershell
python tools\basic_policy_shadow.py --watch --play-style simple --mana-priority evolution --matches 1
```

Alternative mana priority:

```powershell
python tools\basic_policy_shadow.py --watch --play-style careful --mana-priority attack --matches 1
```

The startup banner and every JSONL decision state `SHADOW_NO_INPUT` /
`noInput=true`. Stop with `Ctrl+C`; no F8/F9 controller is installed by this
tool.

### Runtime smoke check on 2026-08-12

The read-only process check attached to PID 6284 (x64), resolved
`GameAssembly.dll` at runtime base `0x00007FFB46330000`, size `0x03D2B000`
(64,139,264 bytes), and verified a 64-byte `ReadProcessMemory` sample.

An eight-second BASIC shadow smoke run then observed `board_absent/lobby` for
23 polls, built the lobby baseline once, and ended with zero provider read
errors. No combat occurred during this short check, so it correctly produced
zero gameplay decisions. The audit is in `logs/phase2c2a_smoke.jsonl`; a live
combat decision run remains the next manual validation step.

## Remaining blockers before autonomous execution

1. Resolve a durable game-owned consecutive-pass value or keep PASS disabled.
2. User must define the intermediate boss-resource fallback (or approve the
   current `NONE`).
3. Implement and validate separate safe executors for EVOLVE/CAST/EXIT only in
   a later explicitly approved phase. Phase 2C.2A stops before that work.
