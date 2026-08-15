# Phase 2D.2 runbook — one bounded farm cycle

## Current status

**Phase 2D.2 is PASS STRONG.** Live attempt `20260815_205707` completed the
bounded cycle with no user interaction: one full B5 combat, exactly one proven
`POSTMATCH_UI` click, exact lobby reacquisition, entry #2, and a hard stop at
opening #2 with zero combat-2 gameplay input. The current regression baseline
is 348/348.

The acceptance retry required the user not to click the result modal and to
leave Pokiguard foreground. The implementation did not add a blind/fixed-
coordinate click: its one-click postmatch action required exact context,
ownership, foreground, multi-frame stability, and the resulting
POSTMATCH-to-BOSS_LOBBY transition proof.

Attempt `20260815_204412` completed that evidence collection: POSTMATCH and the
WIN result modal persisted for 60 seconds with no user input. The sole `Đồng ý`
control was identical across two captured frames. The validated locator and
single-use farm capability are now implemented; baseline 343/343 passes.

Attempt `20260815_205707` live-accepted that implementation. The controller sent
one click only after authoritative POSTMATCH and three stable frames, then
proved exact `BOSS_LOBBY` before entry #2. This runbook is retained for
reproduction; no further Phase 2D.2 retry is required.

The bounded cycle is exactly:

```text
BOSS_LOBBY
-> entry #1
-> new session #1 / stable opening 64/64
-> one full B5 BASIC combat
-> authoritative combat end/postmatch
-> three stable result frames / one `Đồng ý` click
-> stable BOSS_LOBBY
-> entry #2
-> different session #2 / stable opening 64/64
-> HARD STOP
```

Combat #2 is never handed to BASIC. There is no third entry, automatic
technical recovery, retry loop, or continuous farming. The sole automatic
postmatch action is the accepted context-owned `Đồng ý` click.

For a user-visible one-combat demonstration that must stop after returning to
the exact boss lobby, use `--run-single-cycle`. It shares the accepted entry,
B5 combat, POSTMATCH, foreground, and one-click capability guards, but records
`SINGLE_CYCLE_RETURNED_LOBBY_PROVEN` and cannot reserve entry #2.
The user-approved live profile uses an exact four-second local-turn safety
floor: 5+ seconds may proceed through normal actionability/input revalidation;
4 seconds or less safe-stops.

Live demonstration `20260815_214234` accepted this mode: visible `THẮNG`, one
stable result click, exact BOSS_LOBBY return, hard stop, no entry #2, and final
classification `SINGLE_CYCLE_RETURNED_LOBBY_PROVEN`.

## Step 1 — offline verification

From `D:\PokiguardToolV2`:

```powershell
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
```

Current audited baseline: `348/348 PASS`.

## Step 2 — user/game preparation

Before smoke:

1. Open Pokiguard and enter/select the pet boss lobby target used for this
   acceptance run (currently Starburst 1289).
2. Keep the game in that lobby; do not enter a fight.
3. Stop any old bot/controller terminal.
4. The smoke itself does not require the game to remain foreground because it
   sends no input, but live acceptance will require foreground continuously.

## Step 3 — read-only smoke

Run only:

```powershell
python tools/farm_cycle.py --read-only-smoke --boss-id 1289
```

Required result:

```text
lobbyState=BOSS_LOBBY
targetResolution=TARGET_RESOLVED
reason=BOSS_LOBBY_READY
stableFrames=2
staleCombatOwnership=0
otherCooperatingController=0
inputs=0
```

Any other result is a failed precondition. Do not use automation to force the
state. Report the exact output before continuing.

## Step 4 — stop and request explicit approval

After smoke passes, do not start the cycle automatically. Wait for an explicit
instruction in the current conversation.

Live preconditions are:

- exact pet `BOSS_LOBBY` for the configured acceptance target (currently
  Starburst 1289);
- Pokiguard foreground and kept foreground;
- no manual entry, board move, or card use;
- no other automation controller;
- F9 reserved for emergency stop.

## Live command — run only after explicit approval

```powershell
python tools/farm_cycle.py --run-cycle --boss-id 1289 --reset-evidence logs/phase2c2c_reset_capabilities.json
```

The command has bounded timeouts, a high gameplay safety ceiling, exactly two
entry capabilities, and exactly one B5 gameplay capability. It owns one
process/provider/monitor/executor and stops immediately at opening #2.

## Expected user behavior during live acceptance

- Do not click, play, use cards, enter, tab away, or run another controller.
- F9 is the emergency stop and is polled during entry, combat, and outer lobby
  waits.
- If the controller safe-stops, do not resume it manually. Report the sounds,
  visible state, and artifact path.
- After the automatic hard stop at opening #2, the user may handle combat #2
  manually only after the controller has printed its final stop message.

## Safe-stop conditions

The cycle does not attempt entry #2 after any combat safety stop, including:

- sequence desync;
- dead board;
- authoritative PASS uncertainty;
- undefined/no-safe gameplay policy;
- foreground loss;
- zero-click or partial-input failure;
- action/combat timeout;
- unresolved postmatch;
- target missing, ambiguous, or unavailable;
- old session/cache ownership not cleared;
- session #2 not proven different.

Postmatch state discovery remains read-only; the accepted output is one normal
foreground Windows click. If the result/reward button cannot be proven exact
and stable, the correct result is `POSTMATCH_UI_AMBIGUOUS`/safe stop.

## Acceptance artifact

Each live attempt writes a unique directory under:

```text
logs/boss_farm_cycle/YYYYMMDD_HHMMSS/
```

The final `summary.json` contains the cycle identity, state/event ledger,
entry/session/opening summaries, complete B5 summary, domain action counts,
actual Windows-input counts, final invariants, and exact stop reason.

`CURRENT_STATE.md` records the accepted live result. Do not update
`DECISIONS.md` unless the user approves a new gameplay/product rule.
