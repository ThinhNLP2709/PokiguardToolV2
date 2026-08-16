# Phase 2D.5 — Terminal Result Fidelity + Extended Bounded Farm Soak

Date: **2026-08-16 (Asia/Saigon)**

Result: **PASS STRONG**

Accepted invariants:

```text
PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN
PHASE2D5_EXTENDED_SOAK_PROVEN
RESULT_ACCOUNTING_CONSISTENT
```

Phase 2D.5 stops here. Infinite farming, process relaunch, target rotation,
unbounded recovery, and Phase 2D.6 are not implemented.

## Acceptance report

1. **Overall Phase 2D.5 result:** PASS STRONG. Live B1 proved terminal-result
   fidelity; live B2 completed the exact extended bounded target and stopped
   at the boss lobby.
2. **Phase 2D.4 checkpoint:**
   `f87eb9ec5f2e794de635a1d4dbe63375371a142c`.
3. **Root cause confirmed:** Phase 2D.4 cleared Board/Active ownership before
   terminal PlayerStats were published to the result classifier. The old
   artifact therefore retained normal completion but classified the subtype as
   UNKNOWN.
4. **Terminal snapshot architecture:** immutable, session-bound
   `TerminalCombatSnapshot` stores MatchId/session/epoch, timestamp, turn,
   srvSeq, board hash, actor identities, HP pairs, proven terminal event/winner,
   result/confidence/provenance, UI audit, and pre-cleanup status. It is frozen
   audit evidence, never live gameplay ownership.
5. **Capture timing:** the provider captures POSTMATCH PlayerStats and any
   reverse-proven deferred winner during `ACTIVE -> POSTMATCH`, before
   `_clear_lifecycle()` invalidates Board/Active/session caches. The controller
   can also freeze a correlated `MATCH_GAME_OVER` observation. Cleanup occurs
   only after the frozen snapshot is merged.
6. **Evidence hierarchy:** exact `MATCH_GAME_OVER` winner and an unambiguous
   terminal HP pair are primary memory/lifecycle evidence. Strong requires
   attribution before cleanup. Missing or conflicting evidence is UNKNOWN or
   PARTIAL. Exact `Thắng`/`Thua` UI text is secondary audit only and never
   overwrites memory truth.
7. **B1 FarmRunId:** `4f1608ed395e44e8886244587a5bb9b0`.
8. **B1 MatchId:** `M_d8d290a1`.
9. **B1 terminal local HP:** `64900/105228`.
10. **B1 terminal boss HP:** `0/84180`.
11. **B1 memory/lifecycle result:** WIN.
12. **B1 confidence/provenance:** STRONG; `Active.PlayerStats.local`,
    `Active.PlayerStats.boss`, `ACTIVE_TO_POSTMATCH_PRE_CLEANUP`, and
    `TERMINAL_HP_PAIR`.
13. **B1 postmatch UI:** `Thắng -> WIN`.
14. **B1 consistency:** CONSISTENT; accounting `completed=1, wins=1,
    losses=0, unknown=0`.
15. **`PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN`:** PASS.
16. **B2 FarmRunId:** `b63cd48b836c4aa6bb8f7092c06776aa`.
17. **B2 bounds:** `target_completed_matches=10`,
    `max_technical_recoveries=2`, `max_match_attempts=14`.
18. **B2 match attempts:** 10.
19. **B2 completed matches:** 10.
20. **B2 wins:** 10.
21. **B2 losses:** 0.
22. **B2 unknown results:** 0.
23. **B2 per-match results:** all ten unique sessions were WIN/STRONG with
    consistent WIN UI audit:

    | Attempt | MatchId | Result | Local HP | Boss HP | UI | Duration (s) |
    |---:|---|---|---:|---:|---|---:|
    | 1 | `M_9f88f5d9` | WIN/STRONG | 66129 | 0 | WIN/CONSISTENT | 221.256 |
    | 2 | `M_10d6fc4e` | WIN/STRONG | 42676 | 0 | WIN/CONSISTENT | 326.957 |
    | 3 | `M_4a1f13c8` | WIN/STRONG | 70843 | 0 | WIN/CONSISTENT | 320.903 |
    | 4 | `M_59873b8a` | WIN/STRONG | 81779 | 0 | WIN/CONSISTENT | 156.989 |
    | 5 | `M_22698394` | WIN/STRONG | 42994 | 0 | WIN/CONSISTENT | 435.610 |
    | 6 | `M_eb35b596` | WIN/STRONG | 53206 | 0 | WIN/CONSISTENT | 118.999 |
    | 7 | `M_278f3c7d` | WIN/STRONG | 37324 | 0 | WIN/CONSISTENT | 181.457 |
    | 8 | `M_2bacbf10` | WIN/STRONG | 26504 | 0 | WIN/CONSISTENT | 259.599 |
    | 9 | `M_d11e51b2` | WIN/STRONG | 22087 | 0 | WIN/CONSISTENT | 372.488 |
    | 10 | `M_2fcbd380` | WIN/STRONG | 58287 | 0 | WIN/CONSISTENT | 223.402 |

24. **Memory/UI consistent:** 10.
25. **Memory incomplete:** 0.
26. **Result conflicts:** 0.
27. **Technical aborts:** 0.
28. **Technical recoveries:** 0 in the accepted B2 artifact. The configured
    two-recovery boundary and independent per-invocation accounting are covered
    offline; they were not needed in this successful soak.
29. **Natural technical-failure coverage:** NOT_OBSERVED. No natural
    `SEQUENCE_DESYNC` or exact `DEAD_BOARD_NO_REFRESH` occurred in accepted B2;
    the recovery-resume boundary remains live-proven by Phase 2D.4.
30. **SWAP:** 166 sent, 157 acknowledged, 0 rejected, 9 ended as
    `ACTION_ABORTED_STATE_CHANGED` at authoritative lifecycle completion; none
    was retried.
31. **CAST:** 7 sent, 6 accepted, 0 rejected. One sent action ended with the
    combat lifecycle rather than being misclassified as accepted/rejected.
32. **EVOLVE:** 15 attempts, 6 success, 9 failed.
33. **PASS:** 25 policy executions, 25 capability records, **0 Windows inputs**.
    Server-owned idle/reset rules remained authoritative; no local numeric idle
    counter was introduced.
34. **Provider read health:** read errors 0, DTO rejections 0, opening snapshot
    rejections 0. There were 1025 expected unstable-state skips while boards
    were animating/transitioning; these were rejected publication attempts, not
    invalid accepted boards.
35. **Stale/session ambiguity:** stale skips 0, ambiguous-latest skips 0,
    stale-session confusion 0; 10 unique MatchIds and no attempt 11 directory.
36. **Duplicate/wrong-turn/opponent-turn:** duplicate gameplay 0, duplicate
    entry 0, duplicate postmatch confirm 0, duplicate recovery inputs 0,
    wrong target 0, wrong-turn input 0, opponent-turn input 0, stale action 0.
37. **Lobby/postmatch gameplay input:** lobby gameplay 0; postmatch gameplay 0.
38. **Input after stop:** 0. The final event is `farm_target_completed`; no
    later event, entry permit, or attempt 11 exists.
39. **Final stop:** `FARM_TARGET_COMPLETED`, final state
    `FARM_RUN_COMPLETE`, current MatchId/session cleared, exact boss lobby.
40. **Soak duration:** 2753.934 seconds (45m 53.934s); average match duration
    261.766s; longest 435.610s.
41. **`PHASE2D5_EXTENDED_SOAK_PROVEN`:** PASS.
42. **Full regression:** 409/409 PASS.
43. **compileall:** PASS for `src`, `tools`, and `tests`.
44. **`git diff --check`:** PASS.
45. **Files created/modified:**

    ```text
    docs/CURRENT_STATE.md
    docs/il2cpp_symbols.md
    docs/phase2d5_report.md                 (new)
    docs/phase2d5_runbook.md                (new)
    src/pokiguard_v2/farm_run.py
    src/pokiguard_v2/game_owned_idle.py
    src/pokiguard_v2/il2cpp_external.py
    src/pokiguard_v2/memory_board_provider.py
    src/pokiguard_v2/state.py
    src/pokiguard_v2/terminal_result.py      (new)
    tests/test_farm_run.py
    tests/test_game_owned_idle.py
    tests/test_terminal_result.py            (new)
    tools/basic_auto_bot.py
    tools/farm_run.py
    tools/idle_state_watch.py
    ```

46. **CURRENT_STATE:** updated to make Phase 2D.5 PASS STRONG the canonical
    technical handoff, including B1/B2 artifacts, accepted bounds, current
    regression baseline, limitations, and no approved next phase.
47. **DECISIONS:** unchanged. Phase 2D.5 made technical fidelity and bounded-run
    changes only; it did not change user gameplay/product rules.
48. **Git:** Phase 2D.4 base was already committed and pushed. Phase 2D.5 is
    committed separately as `Complete Phase 2D.5 terminal result fidelity and
    bounded soak` and pushed to `main` after final validation. The final commit
    hash is recorded in the handoff/final response.
49. **Remaining blockers before future 2D.6:** Phase 2D.6 has not been approved
    or implemented. Infinite/daemon farming, app/game relaunch, watchdogs,
    rotation across bosses, persistent production profiles/statistics, and
    graceful stop-after-current-match remain out of scope. Natural live
    technical-failure coverage remains NOT_OBSERVED, and generic unrelated
    modal traversal plus direct WorldBoss-card entry remain UNKNOWN/unaccepted.

## Artifact locations

```text
Stage B1: logs/farm_runs/4f1608ed395e44e8886244587a5bb9b0/run.json
Stage B2: logs/farm_runs/b63cd48b836c4aa6bb8f7092c06776aa/run.json
```

Both artifacts report `memoryWrites=false`, `directGameCalls=false`, and
`networkManipulation=false`. All state access remained external/read-only; all
actions used normal foreground Windows input.
