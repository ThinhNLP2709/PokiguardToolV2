# Phase 2B shadow-mode runbook

## Safety model

`tools/shadow_bot.py` opens `Pokiguard.exe` with only:

```text
PROCESS_QUERY_INFORMATION | PROCESS_VM_READ
```

It does not import an executor, focus the window, move the cursor, send mouse
messages, invoke a game method, or write target memory. V1 remains the only
controller.

## Complete runtime validation

1. Leave the game in the lobby after it has initialized at least once.
2. From `D:/PokiguardToolV2`, run:

   ```powershell
   python tools/shadow_bot.py --watch
   ```

   If the current Python does not contain V1's `cv2`/`mss`, the tool replaces
   its own process with `D:/PokiguardAuto/.venv/Scripts/python.exe`. This reads
   the existing V1 environment and does not modify it.
3. Start PokiguardAuto V1 from source and press its normal Start button.
4. Let V1 play. Do not leave the game idle: V2 intentionally cannot protect
   against the three-idle-turn rule because it sends no input.
5. After combat returns to lobby, shadow exits and writes
   `logs/shadow_<timestamp>.jsonl`.

For the Phase 2B acceptance sample, keep the observer alive across combat
lifecycles until at least 20 independent full-board audits have completed:

```powershell
python tools/shadow_bot.py --watch --matches 0 --min-comparisons 20
```

It exits only at a later `board_lost` boundary after the comparison target is
met. `--matches N` can instead require a fixed minimum number of complete
combat lifecycles; both targets must be met when both are non-zero.

For a memory-only diagnostic without CV comparison:

```powershell
python tools/shadow_bot.py --watch --no-cv-validation
```

That mode cannot satisfy the >=20 memory-vs-CV acceptance by itself.

## Publication and comparison

A decision row is emitted only for a unique
`(Board.Instance,srvSeq,boardHash)` whose 64 DTO cells and 64 live Dots agree
twice consecutively while the Board remains ready, non-cascading, and its
`allDots` array is unchanged across each scan. `Board.allDots` is a
`GameObject[,]`, not a `Dot[,]`; V2 therefore continues to locate the attached
Dot components by their validated `Dot+0x48 -> current Board` fingerprint.
The ordinary Dot candidate scan remains limited to private writable regions of
at most 8 MiB. Dot discovery additionally uses the 64 current `allDots` GameObject
references as allocation anchors: it scans only the exact private writable
regions containing those objects/cached validated Dots. Each anchor region is
capped at 128 MiB and their combined size at 256 MiB; exceeding either limit
returns no candidates. This reaches large Unity GC segments without expanding
into a whole-process pointer scan. Concrete object addresses never survive a
lifecycle.

The final provider unions both candidate sources before strict validation.
Anchor-only runtime validation did not recover all 64 Dots, so the anchor is a
supplement rather than a replacement for the earlier bounded scan.

The optional CV observer can retain a frame immediately before a memory poll
and capture more frames after a state is published. These images are considered
only after memory independently passes every gate. V1 CV therefore acts as an
audit oracle and is never used to fill, correct, or construct a memory board.
A mismatch is logged as-is. If the live capture is partial, V2 may count V1's
own structured `debug/boards` artifact
only when it says `source=full unknown=0`, was written after the shadow session
started, parses as exactly 8x8, and all 64 GemTypes equal the memory snapshot.
That artifact contains no multiplier plane, so multiplier verification remains
the independent 64/64 DTO-to-live-Dot gate and is not mislabeled as CV output.

Important JSONL events:

- `lifecycle`: lobby / board found / board lost;
- `card_transition`, `fusion_transition`: observed memory changes;
- `shadow_decision`: full cells, cards, Fusion, solver result and CV diff;
- `shadow_summary`: decision/dedup/stale counts and aggregate comparison totals.
