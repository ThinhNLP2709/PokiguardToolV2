# Phase 3C.1 — Audition V3 `ReverseFrom=-1` live incident

Date: 2026-09-14

## Result

Farm run `f740e9c51fb845d7a9fe2c8ea1de5a6b`, match `M_295cb4ba`, reached local
turn 19 with Huyền Thoại 7 actionable at Mana/Rage `237/250`. The tool clicked
the Pet Skill card exactly once. It sent zero direction keys and zero Space,
then failed closed with `ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS`.

The Pet Skill artifact contains 18 identical
`server_qte_challenge_read_rejected` events. The rejected field was
`MatchService.ServerQteReverseFrom = -1`; the reader incorrectly required a
nonnegative value.

## Evidence

Read-only memory after Stop retained these coherent b4 server values:

- duration: `5000 ms`;
- Perfect window: `3000..3300 ms`;
- Good windows: `2500..3000 ms` and `3300..4200 ms`;
- `ReverseFrom = -1`;
- Great: `150 ms`;
- multipliers: approximately `1.5 / 1.2 / 0.8`.

The b4 declaration places the field at `MatchService +0x2B0` and
`AuditionChallenge +0x3C`. Read-only disassembly of
`AuditionChallenge.FromService` (`GameAssembly` RVA `0xBD7EF0`) shows:

- the new challenge starts with `ReverseFrom = -1`;
- the server value at `+0x2B0` is copied to challenge `+0x3C`;
- a value at or beyond `Display.Count` is reset to `-1`;
- the reversal loop calls `Opposite` only when `ReverseFrom >= 0`.

Therefore `-1` is a game-owned no-reverse sentinel, not corrupt state.

## Repair

`read_server_qte_challenge` now accepts `ReverseFrom == -1` or the previously
bounded nonnegative range. It rejects `-2` and other invalid negative values.
Its diagnostics now identify `reverseFrom` and `greatMs` separately.

The regression constructs a complete server challenge with `ReverseFrom=-1`,
proves it is accepted, then changes only that field to `-2` and proves the
reader fails closed. Full verification is **1218/1218 PASS**; compileall and
`git diff --check` pass. Live B1 remains open until a retry proves directions,
Space, authoritative Perfect and a clean completed match.
