# Phase 3C.1 — Audition V3 CardUI elapsed sentinel incident

Date: 2026-09-14

## Result

Farm run `7f8cf5fc45484cb394017fa5900a49a1`, match `M_885acd58`, reached local
turn 33 with Huyền Thoại 7 actionable at Mana/Rage `244/250`. The tool clicked
the Pet Skill card exactly once, then emitted zero direction keys and zero
Space. The action failed closed as `ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS`.

The previous `ServerQteReverseFrom=-1` repair worked: this run contains no
`server_qte_challenge_read_rejected` event. The rejection moved to the active
stage and reported `AuditionStage scalar/result state is inconsistent`.

## Native evidence

The b4 declaration places `CardUI._auditionV3ElapsedMs` at `+0xE4`.
Read-only disassembly of the installed b4 `GameAssembly.dll` proves the field
uses an independent sentinel:

- `CardUI..ctor` (RVA `0xABBEC0`) writes `0xFFFFFFFF` to `CardUI +0xE4`;
- `CardUI.HandleDotSkillSequence.MoveNext` (RVA `0xADC090`) writes
  `0xFFFFFFFF` to `CardUI +0xE4` when initializing the QTE;
- `CardUI.CurrentQteElapsedMs` (RVA `0xAA9AA0`) tests the field against zero.
  When it is negative, the game derives elapsed milliseconds from the live
  duration/slider clock; when it is nonnegative, the game returns the field;
- `CardUI.IAuditionHost.OnAuditionTap` (RVA `0xA939A0`) writes the actual tap
  elapsed milliseconds to `CardUI +0xE4`.

`AuditionStage.Tick` (RVA `0xBD0840`) independently stores the live QTE clock
at `AuditionStage +0x14C`. This is the tool's authoritative pre-tap clock.

Therefore exact `CardUI._auditionV3ElapsedMs == -1` means that Space has not
been tapped yet. It is normal active-QTE state, not corrupt memory.

## Repair

The V3 reader now requires the exact native relationship:

- before tap: host elapsed must be exactly `-1`, and the tool uses
  `AuditionStage._qteElapsed`;
- after tap: host elapsed must be bounded and exactly equal to
  `AuditionStage.TapElapsedMs`;
- `-2` and every other pre-tap value remain invalid.

Scalar rejection diagnostics now include the complete bounded scalar snapshot,
so another game change identifies the failing field in the artifact instead of
collapsing all failures into one generic message.

The dedicated regression accepts native pre-tap `-1`, rejects `-2`, and keeps
the tapped-state equality check. Current full verification is **1220/1220
PASS**; dedicated Audition V3 verification is **7/7 PASS**. Live B1 remains open until
a retry proves Left/Right input, one Space, authoritative Perfect, and a clean
completed match.
