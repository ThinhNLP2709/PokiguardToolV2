# Phase 3A.0 Source Maintenance Runbook

This runbook reproduces the accepted source-maintenance validation. It does
not build a new package and does not authorize Pet Skill/QTE automation,
memory writes, injection, direct Unity gameplay calls or network manipulation.

## Prerequisites

- Windows x64 and CPython x64.
- Pokiguard 1.7.4 opened manually.
- The Settings tab contains the exact full path to the current game EXE.
- The user manually enters the exact boss lobby before Start.
- Use the normal BASIC configuration and source launcher `run_tool.bat`.

## Offline validation

From the repository root:

```powershell
$env:PYTHONPATH = "src;."
python -m unittest -v tests.test_win32_input tests.test_postmatch_ui tests.test_board_simulator tests.test_basic_policy tests.test_autonomous_control
python -m unittest discover -s tests -p "test_*.py" -v
python -m compileall -q src tools tests
git diff --check
```

Require every test and compile check to pass. `git diff --check` may print
line-ending conversion warnings but must report no whitespace error.

## Live validation

1. From an exact boss lobby, configure 3--5 completed matches and sufficient
   finite attempts.
2. Click Start once and do not manipulate the game or tool while active.
3. Let the runner stop naturally at the configured completed target.
4. Inspect `run.json`, `events.jsonl` and each `matches/attempt_*/combat.jsonl`.

Require:

- completed results equal the configured target;
- `wins + losses + unknown == completed_matches`;
- no extra attempt after target and no unexplained UNKNOWN;
- final `FARM_TARGET_COMPLETED / BOSS_LOBBY`, controller stopped;
- exact authoritative terminal/UI consistency;
- one postmatch confirm per completed match, never before authoritative
  POSTMATCH and stable modal proof;
- zero wrong-turn, boss-turn, stale, duplicate, misclick and partial input;
- zero result double count/conflict and zero gameplay input in lobby/postmatch;
- every card action has current identity, slot, tile proof, geometry and Y
  `0.824` telemetry;
- preferably at least one natural EVOLVE and CAST; do not force them;
- no ordinary safe-labelled SWAP with a known direct or indirect opponent
  Sword reply and no UNKNOWN used as favorable proof.

Natural unique-adverse-Sword, Sword-hold and technical recovery are useful but
not mandatory. Record absent branches exactly as `NOT_OBSERVED`; do not create
game state to force them.

## Finalization

Update `docs/CURRENT_STATE.md`, `README.md` and the Phase 3A.0 report with the
actual evidence. Rerun all offline checks after documentation or narrow fixes.
Review every path, commit only project source/docs/tests/reverse evidence, push
the accepted commit, then require:

```powershell
git rev-parse HEAD
git rev-parse origin/main
git status --short
```

`HEAD` and `origin/main` must match and the worktree must be clean. Do not
create or move a packaged release tag. Stop before Phase 3A.1.
