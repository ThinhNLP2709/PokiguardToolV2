# Phase 3C.1 — Audition V3 live runbook

## 1. Offline gate

From `D:\PokiguardToolV2`:

```powershell
$env:PYTHONPATH = "src;."
python -m unittest discover -s tests
python -m compileall -q src tools tests
git diff --check
```

Current result: **1222/1222 PASS**, dedicated Audition V3 tests **7/7 PASS**,
compileall and diff check PASS.

## 2. Configuration

Use the exact live profile:

```text
Main pet:       LEGENDARY
Evolution:     NONE
Damage card:   PET_SKILL
Intelligence:  BASIC
Audition:      audition_v3 (two directions, default)
```

The operator equips the pet and enters the intended Chinh Phuc boss room.
FarmRunner reads the exact room pet ID/name; old IDs in reports are not reused
as authority. The game must stay in the foreground after Start.

Preferences also expose `audition_v2` for the previous four-direction UI. Use
it only when intentionally testing a legacy server/UI generation.

## 3. Live B1 — one fresh match

Replace `<CURRENT_ROOM_PET_ID>` with the exact ID from the live room:

```powershell
$env:PYTHONPATH = "src;."
python tools/farm_run.py `
  --stage-d5-b1-terminal `
  --boss-id <CURRENT_ROOM_PET_ID> `
  --main-pet legendary `
  --evolution-target none `
  --damage-card pet_skill `
  --audition-mode audition_v3 `
  --reset-evidence src/pokiguard_v2/resources/reset_capabilities.json `
  --artifacts logs/phase3c1_live_v3_b1 `
  --no-beep
```

Do not manually act during combat while FarmRunner owns input.

B1 passes when the artifact proves all of these:

- exactly one fresh MatchId and one completed match;
- at least one accepted Pet Skill with V3 `LR` ownership;
- every sent direction is acknowledged against the current Expected list;
- exactly one Space for the bound generation and authoritative runtime Perfect;
- ordinary Attack CAST and EVOLVE are both zero;
- no wrong/stale/duplicate QTE or gameplay input;
- result is WIN or LOSS with terminal evidence and final `BOSS_LOBBY`.

If the card is clicked but the V3 generation cannot be proved, the action must
stop without retrying the card or sending a direction/Space.

## 4. Follow-up

Live B1 is accepted from FarmRun `6bcf4d8efa9a4e129cc32aa492a17b6a`, MatchId
`M_8ba50c47`: `1/1 WIN`, one runtime Perfect, one postmatch confirmation, final
`BOSS_LOBBY`, and all safety counters zero.

Fresh B2 is accepted from FarmRun `360e3ef223fc4f5eba5ca93d1cd2d490`,
MatchId `M_031645fd`: `1/1 WIN`, one fresh-generation runtime Perfect, one
postmatch confirmation, final `BOSS_LOBBY`, and all safety counters zero.

B1+B2 therefore prove two fresh MatchIds, two successful V3 Pet Skills, two
Perfects, no old CardUI/QTE reuse, no EVOLVE or ordinary CAST, no same-source
turn follow-up, and no safety violation. Phase 3C.1 live acceptance is complete.
A separate `audition_v2` match remains optional compatibility evidence.

After the live runs, confirm no Python FarmRunner/PetSkill process remains,
audit `run.json`, `events.jsonl`, each `combat.jsonl` and Pet Skill logs, then
update [phase3c1_report.md](phase3c1_report.md).
