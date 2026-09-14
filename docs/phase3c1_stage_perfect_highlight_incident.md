# Phase 3C.1 — Audition V3 live Perfect-highlight incident

Date: 2026-09-14

## Result

Farm run `17e9a8761c6e477ca8fee7436d4b2924`, match `M_d5c84deb`, reached
local turn 19 with Huyền Thoại 7 actionable at Mana/Rage `283/242`. The action
clicked the card once and bound one current V3 generation of seven arrows.

All seven inputs were sent and authoritatively confirmed in order:

`LEFT, RIGHT, RIGHT, RIGHT, LEFT, RIGHT, RIGHT`.

The direction phase completed at QTE elapsed `1.217 s`, leaving `1.783 s`
before the `3.000..3.300 s` Perfect window. The action selected `3.150 s` as
its Space target. It then sent no Space because the V3 reader rejected the
otherwise coherent sample at elapsed `3.054240 s`:

```text
cursor=7/7, correct=7, tapped=False, tapElapsedMs=0,
hostTapElapsedMs=-1, wasPerfect=True, grade=None
```

## Native evidence

Read-only b4 disassembly proves that `AuditionStage._wasPerfect +0x158` is a
live UI-zone flag, not a completed result:

- `AuditionStage.TickBar` (RVA `0xBD1E20`) compares
  `_qteElapsed * 1000` against `AuditionChallenge.PerfectStartMs +0x24` and
  `PerfectEndMs +0x28`;
- the flag is true only while the clock is inside that window and the stage is
  still untapped, then `TickBar` writes it to `AuditionStage +0x158`;
- `AuditionStage.TapBar` (RVA `0xBD0580`) separately sets `Tapped +0x19` and
  `TapElapsedMs +0x1C` when Space is received;
- `AuditionStage.ShowResult` (RVA `0xBD3170`) writes the result grade later to
  `_grade +0x168`.

Therefore `Tapped=false`, `_wasPerfect=true`, and `_grade=null` is the exact
normal state while waiting inside the Perfect window before Space.

## Repair

The reader no longer requires a live `_wasPerfect` highlight to have a result
grade. It still validates `_wasPerfect` as an IL2CPP boolean and retains it in
scalar diagnostics. Result text continues to come only from `_grade`, while
tap completion continues to come only from `Tapped` and the two equal bounded
tap-elapsed fields.

The new regression reproduces the live pre-Space tuple and proves it remains a
valid unfinished QTE. Dedicated Audition V3 verification is **7/7 PASS** and
the complete regression is **1220/1220 PASS**. Live B1 remains open until a
retry proves one Space, authoritative Perfect, and clean match completion.
