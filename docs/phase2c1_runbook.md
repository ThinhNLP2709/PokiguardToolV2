# Phase 2C.1 single-step runbook

Phase 2C.1 sends only a normal two-click board swap after an explicit F8. It
does not use V1 CV, memory writes, injection, direct game calls, network calls,
cards, or Fusion.

## Before starting

1. Close the V1 automation process. The V1 source folder remains unchanged and
   is imported only for its solver/config.
2. Put Pokiguard in the boss lobby, before entering the combat room.
3. Resize/move the game now if desired. Do not resize it after the controller
   starts.
4. Start the controller, then bring Pokiguard to the foreground **before**
   entering combat. This is important because two distinct local-turn states
   rejected for lack of foreground trigger the two-skip safety pause.

Use the V1 virtual environment because it already contains the solver's Python
dependencies:

```powershell
& 'D:\PokiguardAuto\.venv\Scripts\python.exe' `
  'D:\PokiguardToolV2\tools\single_step_bot.py' `
  --single-step --max-actions 20
```

The new controller code and logs remain entirely in `PokiguardToolV2`; the V1
folder is not written.

## During combat

- Wait for the board to settle and for the short **ready beep**, then press
  **F8 once** for one proposed move.
- F8 causes a fresh memory read. Input is sent only if session, `srvSeq`,
  `boardHash`, solver move, all gates and coordinates still match.
- After exactly two clicks, input locks until a new sequence/hash/turn/state is
  observed or the seven-second acknowledgement timeout expires.
- Press F8 again only for the next stable proposal. Pressing it during boss
  turn, cascade, modal, a lock, or without a current proposal sends no click.
- After manually opening/using a card or Fusion, earlier F8 presses are ignored;
  wait for presentation to finish and for the next ready beep.
- Press **F9** at any time for emergency stop. `Ctrl+C` also stops when the
  console has focus.
- Do not intentionally leave three turns idle; this controller is single-step,
  so every safe player action still requires one F8.

The controller stops after the final `--max-actions` action has an ACK or clear
timeout. Use F9 earlier if anything looks wrong.

## Dry-run

Dry-run exercises attach, provider, gate, solver, F8 revalidation and pixel
calculation, but never calls an input API:

```powershell
& 'D:\PokiguardAuto\.venv\Scripts\python.exe' `
  'D:\PokiguardToolV2\tools\single_step_bot.py' `
  --dry-run --timeout 120
```

In dry-run, F8 marks the current proposal as prepared without clicking. Make a
manual move to produce a new source state if another dry-run proposal is
needed.

## Evidence log

The default log is `logs/phase2c1_YYYYMMDD_HHMMSS.jsonl`. Important events are
`proposal`, `proposal_expired`, `action_sent`, `action_acknowledged`,
`action_timeout`, `action_skipped`, `auto_pause`, `cards_read_only`,
`fusion_read_only`, and `controller_summary`.

An action identity is `(sessionKey, sourceSrvSeq, sourceBoardHash, from, to)`
and is consumed at most once, including an input failure or timeout. There is
no automatic retry of the same identity.
