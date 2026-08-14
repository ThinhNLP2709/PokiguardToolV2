# Phase 2D.1 live runbook

Phase 2D.1 performs at most one normal UI `Bắt Đầu` click and stops at the fresh
64/64 opening board. It never plays the first turn.

## Beeps and hotkeys

- one high beep: Stage A is ready; visually verify the configured target and
  press `F8` once;
- two rising beeps: new session + opening board accepted; tool has stopped;
- three low beeps: blocked/stopped; no blind retry;
- `F9`: emergency stop at any time.

## Preparation

1. Open the exact ChinhPhuc pet-boss room for the target.
2. Stay on the room screen that visibly shows the target and `Bắt Đầu`.
3. Keep Pokiguard in the foreground and do not cover it with another window.
4. Do not press `Bắt Đầu` manually while the tool is running.
5. After it enters combat, do not make a board/card action; acceptance should
   stop within a few seconds, well before the 14-second turn expires.

The verified current farm target can be configured by exact ID:

```powershell
python tools\boss_entry.py --inspect-only --boss-id 1289
```

The tool has no target default. Name mode is also exact:

```powershell
python tools\boss_entry.py --inspect-only --boss-name Starburst
```

## Offline/live inspection (zero input)

Run inspection first. Expected terminal text is:

```text
INSPECT READY: exact target + Start button proven; no input sent.
```

If the current WS room is gone while old `roomData` remains, expected behavior
is `LOBBY_OTHER`/timeout with zero click. Re-enter the pet-boss room normally;
do not work around the gate.

## Stage A — confirmed one-shot

```powershell
python tools\boss_entry.py --stage-a --boss-id 1289
```

1. Wait for one high beep and `READY_TO_ENTER`.
2. Visually verify the correct target and `Bắt Đầu`.
3. Press `F8` once.
4. Do not touch the game.
5. Expected: one normal click, entering combat, new match/session, fresh 64/64
   opening, two rising beeps, then stop.

If any three-low-tone stop occurs, leave the artifact untouched and report the
exact result. Do not press F8 a second time.

## Stage B — automatic one-shot

Run only after a clean Stage A PASS:

```powershell
python tools\boss_entry.py --stage-b --boss-id 1289
```

Keep the correct room foreground. The tool performs the same proof and exactly
one automatic entry click, then stops at opening readiness. It does not play.

## Artifacts

Every run creates:

```text
logs/boss_entry/<timestamp>/
  entry.jsonl
  entry.json
  lobby_before.png       (only after foreground proof)
  entry_button.png       (only after second stable proof)
  combat_opening.png     (when foreground capture succeeds)
```

Key success events:

```text
boss_lobby_detected
target_candidates
target_resolved
target_selected
fight_button_detected
entry_input_sent
entering_combat
new_match_detected
new_session_confirmed
opening_board_ready
entry_acceptance_complete
```

Stop after Phase 2D.1. Do not launch the B5 combat controller in this run.

