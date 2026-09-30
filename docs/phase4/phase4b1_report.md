# Phase 4B.1 — Pinned Foreground Lease Contract + Backend Report

## Result

```text
RESULT: PASS STRONG
SELECTED MODE: PINNED_FOREGROUND_LEASE_BETA
DEFAULT MODE: FOREGROUND
PRODUCTION CALL-SITE INTEGRATION: NO
FARMRUNNER/UI BEHAVIOR CHANGED: NO
```

## Scope completed

- added `pokiguard_v2.input_delivery` with immutable typed mode, domain,
  lease-kind, exact-window authority, capability and telemetry models;
- old/missing config maps to `FOREGROUND`; unknown schema/mode is rejected and
  never silently falls back;
- promoted the exact mouse and QTE lease implementations proven in Phase 4A
  from probe-only modules into `src/pokiguard_v2/` production modules;
- converted the old `tools/` lease modules to compatibility shims, so probes
  and production imports use the same classes rather than duplicated logic;
- made `ExactWindowBinding` production-owned and immutable with PID/HWND/title/
  client-size validation;
- added package hidden imports for the three new production modules;
- exported the contract types through the package boundary.

No FarmRunner permit, actionability gate, solver, policy, input timing, Desktop
UI, preferences or autonomous call site selects the Beta mode in this phase.

## Contract

`FOREGROUND` remains the default and requires the game to be foreground at the
input boundary. `PINNED_FOREGROUND_LEASE_BETA` requires an exact visible,
non-minimized pinned window and may perform a bounded foreground takeover.
Board/UI actions use a mouse lease. Pet Skill uses the split lease already
live-proven: mouse through card click, then keyboard-only after current QTE bind.

Both modes keep authoritative ACK outside transport success. The telemetry
envelope records mode/domain/action, exact binding, client points, timestamps,
expected ACK, foreground state and cleanup result without raw memory.

## Verification

```text
Focused 4B.1 + adjacent config/controller/package tests: 151/151 PASS
Full regression: 1481/1481 PASS
compileall: PASS
git diff --check: PASS
```

The apparent `ERROR`/usage lines printed by the full suite are intentional
negative-path fixtures; unittest finished `OK`.

## Safety and packaging

- minimized, wrong PID/HWND/title/geometry and stale bindings retain fail-closed
  behavior from the accepted lease implementation;
- cursor/guard/topmost cleanup remains mandatory; focus restore stays best
  effort and is logged;
- probe tests now exercise production classes through identity-equal shims;
- the package spec explicitly includes the contract and both lease backends;
- no live test is required because 4B.1 adds no input call site and the promoted
  implementations are byte-for-behavior the same classes accepted in 4A.1-R2
  and 4A.2-R1.

## Router decision

Phase 4B.1 reaches `PASS STRONG`. The next prompt is
`prompts/4B2_PINNED_FOREGROUND_BOARD_INTEGRATION.md`. Phase 4B.2 may wire only
board SWAP through the mouse lease; card/QTE/UI integration remains out of
scope until their later phases.
