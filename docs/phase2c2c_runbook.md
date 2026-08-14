# Phase 2C.2C authoritative PASS runbook

Status: implementation, offline regression, and ordered live acceptance
P0 -> P1 -> P2 -> P3 complete. Do not retry Stage B3 from this runbook.

## Safety boundary

- Start every tool in the game lobby, never by attaching mid-combat.
- P0 is read-only and sends no input.
- P1/P2/P3 may send only the existing validated EVOLVE/SWAP/CAST input plus a
  PASS whose executor is deliberately empty.
- PASS means waiting out the local turn. It never clicks the board/card and
  never calls a game/network method.
- F7 pauses/resumes outside PASS_WAIT. F7 during PASS_WAIT aborts that PASS.
- F9 stops immediately. F10 remains the user-confirmed recovery step only.
- Automatic exit, recovery and re-entry remain disabled.

## P0 - reset evidence

Start in lobby:

```powershell
python tools/authoritative_pass_probe.py --watch --matches 3
```

Controlled SWAP scenario:

1. Play the first local turn; first-turn PASS is forbidden.
2. Intentionally idle one later local turn and wait for authoritative `1/N`.
3. On the next local turn, make one valid SWAP.
4. Intentionally idle the following local turn; expect `1/N`, not `2/N`.
5. Repeat steps 3-4 once to obtain two distinct ordered proofs.

The probe writes `logs/phase2c2c_reset_capabilities.json` only if two ordered
SWAP proofs reach `RESET_CONFIRMED_BY_SERVER_SEQUENCE` (or explicit reset).
`RESET_STRONGLY_INFERRED` is logged but cannot enable production PASS. CAST is
recorded if an opportunity occurs, but it remains unavailable as a reset
baseline until it independently meets the same evidence threshold.

## P1 - one autonomous PASS

Run only after inspecting a clean P0 capability file:

```powershell
python tools/basic_auto_bot.py --watch --pass-acceptance-stage P1 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json
```

Expected: an accepted certified consuming action establishes a non-numeric
`RESET_BASELINE_CONFIRMED`; when BASIC later selects Step 6, the controller
enters PASS_WAIT, sends zero gameplay input, observes authoritative `1/N`, logs
`PASS_CONFIRMED_IDLE_1`, then stops/pauses. It must not make a second PASS.

## P2 - two autonomous PASSes

Run only after P1 is clean:

```powershell
python tools/basic_auto_bot.py --watch --pass-acceptance-stage P2 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json
```

If normal BASIC play does not naturally produce two consecutive PASS choices
before combat ends, use the explicit acceptance-only trigger:

```powershell
python tools/basic_auto_bot.py --watch --pass-acceptance-stage P2 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json `
  --acceptance-force-pass-after-actions 5
```

The trigger is disabled by default and is rejected outside P2/P3. It waits for
five server-accepted consuming actions, then overrides BASIC only while the
authoritative idle gate permits PASS. It does not bypass first-turn,
mandatory-action, lifecycle, actionability, session, or sequence-desync gates.

Expected: if policy still requires PASS on the next local turn, `1/N` permits
one more PASS, authoritative `2/N` is recorded, and the controller stops before
a third PASS. Any unexpected count or missing warning is
`PASS_STATE_UNCONFIRMED` and fails closed.

## P3 - mandatory consuming reset

Run only after P2 is clean:

```powershell
python tools/basic_auto_bot.py --watch --pass-acceptance-stage P3 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json
```

Expected cycle:

```text
RESET_BASELINE_CONFIRMED
  -> PASS_CONFIRMED_IDLE_1
  -> PASS_CONFIRMED_IDLE_2
  -> PASS_FORBIDDEN_MANDATORY_ACTION
  -> accepted SWAP or CAST
  -> RESET_BASELINE_CONFIRMED (only if that action kind is certified)
  -> later policy-selected PASS
  -> PASS_CONFIRMED_IDLE_1
  -> acceptance stop
```

Normal BASIC priorities still run before the least-dangerous fallback. If no
safe/strategic consuming action exists, the existing deterministic mandatory
rank minimizes Sword danger and uses defensive Shield tie-breaking; it never
chooses randomly. A CAST whose reset capability is still UNKNOWN may execute,
but P3 then stops fail-closed instead of treating it as a reset.

## Terminal PASS results

Every PASS_WAIT ends with exactly one of:

- `PASS_CONFIRMED_IDLE_1`
- `PASS_CONFIRMED_IDLE_2`
- `PASS_STATE_UNCONFIRMED`
- `PASS_ABORTED_STATE_CHANGED`
- `PASS_ABORTED_USER_ACTION`
- `PASS_ABORTED_COMBAT_END`
- `SEQUENCE_DESYNC`

DEAD_BOARD remains `DEAD_BOARD_NO_REFRESH -> RECOVERY_REQUIRED`; it is never
converted into a PASS loop.
