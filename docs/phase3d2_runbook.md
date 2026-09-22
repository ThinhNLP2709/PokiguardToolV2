# Phase 3D.2 Runbook — 25-Match Pet-Skill Reliability Soak

## Frozen source and operator boundary

This runbook was executed successfully on source
`5b620987320b4132c33ab7d1acc269901e7431b3`, application `v1.0.49`. The user
owned all game and Desktop UI interaction. No manual combat input was supplied.

Before Start, verify one Desktop UI, no active FarmRunner/controller and the
exact Starburst `1289` `BOSS_LOBBY`. Use the normal `run_tool.bat` launcher.

## Immutable configuration

| Setting | Value |
|---|---|
| Lối chơi | `Chịu đấm ăn xôi` |
| Độ thông minh | `BASIC` |
| Pet của tôi | `Huyền thoại` |
| Tiến hóa | `Không tiến hóa` |
| Thẻ sát thương | `Thẻ skill của pet` |
| Điều kiện ra skill | `Kiếm đủ` |
| Giá trị | `10` |
| Fire semantics | known effective Sword value `>= 10` |
| Audition | `audition_v3` |
| Board input | `two_click` |
| Target matches | `25` |
| Max attempts | `35` |

Press **Validate & Save Preferences**, verify the saved config, then press
**Start** exactly once. Start pins Starburst and freezes the accepted config.
Do not change Preferences or source and do not send manual combat input while
the run is active.

## Live execution

The accepted FarmRun is `cdc37e234ec54b8f9c54bc718b92c636`. Reporting
boundaries at 5/10/15/20 were observational only; the run remained one
continuous FarmRun. Stop immediately on stale QTE/card input, wrong direction,
GOOD/BAD, wrong-turn input, duplicate controller or any other critical safety
violation. Do not hot-fix and continue the same dataset.

The run completed 25/25 WIN in exactly 25 attempts. It stopped with
`FARM_TARGET_COMPLETED` in `BOSS_LOBBY`; no attempt 26 was created.

## Evidence audit

For every attempt, correlate:

1. `match_entry_result` and its fresh MatchId/session;
2. `pet_skill_action_proposed` with runtime resources and effective Sword
   value;
3. `pet_skill_dispatch_result` and the QTE action identity;
4. all direction records and the one Space confirm;
5. `terminal_result_captured`;
6. `postmatch_ui_audit`;
7. `normal_return_boss_lobby`.

Use `UNKNOWN` or `NOT_OBSERVED` where the logs do not contain stronger
evidence. In this run, server timing echo and natural technical recovery were
`NOT_OBSERVED`; authoritative runtime PERFECT and deterministic recovery tests
were available.

## Offline verification

Run from the repository root:

```powershell
$env:PYTHONPATH = "src;tests"
python -m unittest tests.test_pet_skill_action tests.test_pet_qte_observer tests.test_qte_control_poll tests.test_qte_direction_assist tests.test_audition_v3 tests.test_acked_sequences tests.test_sequence_desync tests.test_action_control tests.test_combat_lifecycle tests.test_autonomous_control tests.test_pet_configuration tests.test_pet_configuration_ui tests.test_desktop_preferences tests.test_farm_checkpoint tests.test_farm_run tests.test_postmatch_ui tests.test_terminal_result tests.test_technical_recovery tests.test_recovery_ui tests.test_native_card_ui tests.test_phase3d1_r1_benchmark tests.test_phase3c3_skill_rush_policy
1..5 | ForEach-Object { python -m unittest tests.test_win32_input }
python -m unittest discover -s tests
python -m compileall -q src tools tests
git diff --check
```

Final results are focused `694/694`, randomized input `18/18 × 5/5`, and full
regression `1366/1366`, with compileall and diff check passing.

## Closeout

Generate and audit:

- `docs/artifacts/phase3d2_soak_analysis.json`
- `docs/artifacts/phase3d2_soak_analysis.md`
- `docs/phase3d2_report.md`

Update only current-state/decision records and phase-owned artifacts. Preserve
unrelated user files and `AGENTS.md`. Commit and push the focused Phase 3D.2
closeout, verify `HEAD == origin/main`, and stop. Do not package, tag or begin
Phase 3E.1.
