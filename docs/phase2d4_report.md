# Phase 2D.4 — Bounded Continuous Farming + Recovery Resume

Date: **2026-08-16 (Asia/Saigon)**

Result: **PASS STRONG**

Accepted invariants:

```text
PHASE2D4_RECOVERY_RESUME_PROVEN
PHASE2D4_BOUNDED_FARM_PROVEN
```

Phase 2D.4 stops here. Infinite farming, process restart, repeated unbounded
recovery, target rotation, and Phase 2D.5 are not implemented.

## Architecture

```text
FarmRun + hard limits + single controller lease
  -> exact BOSS_LOBBY / target resolution
  -> BossEntry normal foreground input
  -> fresh MatchId + CombatSessionKey + hardened 64/64 opening
  -> full-state reread + ActionabilityGate + accepted BASIC controller
  -> normal POSTMATCH confirmation and exact lobby reacquisition
  -> next bounded attempt, or stop before another entry

SEQUENCE_DESYNC / DEAD_BOARD_NO_REFRESH
  -> gameplay capability locked
  -> shared TechnicalRecoveryCoordinator
  -> << / stable Đồng ý / exact lobby / exact target / re-entry
  -> distinct session + fresh opening
  -> discard old proposal and reread full GameState
  -> accepted BASIC action
```

`FarmRun` owns progression and all entry/gameplay/postmatch/recovery accounting.
Single-use capabilities own each input domain. `AutomationControllerLease`
prevents two automation controllers from owning input simultaneously. F9 is a
terminal emergency stop; F7 is intentionally disabled because safe farm-level
resume semantics have not been accepted.

All game-state access remains external/read-only. Gameplay, lobby, postmatch,
and recovery actions use normal foreground Windows input. No game-memory write,
direct game method, injection, packet manipulation, or sequence repair exists.

## Stage A — Offline/Replay

Both recovery-resume paths passed with zero actual Windows inputs:

| Case | Artifact | Result |
|---|---|---|
| Captured `SEQUENCE_DESYNC` | `logs/farm_runs/stage_a_sequence_desync_1786812454800/` | PASS |
| Deterministic zero-legal dead board | `logs/farm_runs/stage_a_dead_board_fixture_1786812454813/` | PASS |

Natural live dead board remains `NOT_OBSERVED`.

## Stage B1 — Live Recovery Resume

Artifact:
`logs/farm_runs/fc396e1d55dc455390e752e57eb927b2/run.json`

| Evidence | Observed value |
|---|---|
| Stage result | PASS |
| Failed/test-only MatchId | `M_a62e5f2f` |
| Failed session | epoch 1, Board `1979632775168` |
| Recovered MatchId | `M_c52277e6` |
| Recovered session | epoch 2, Board `1973722742784` |
| Recovery inputs | 3: exit 1, confirm 1, re-entry 1 |
| Recovered opening | 64 cells, 64 unique coordinates, known gems/multipliers, fresh DTO, stable x2 |
| Opening source | `ChatMessageDTO.MATCH_START.matchPayload.board` |
| Opening board hash | `170c044ab9d2b60f9b42b19087d7cb0e10cdb395189e1cc54ce0cf86e99eb3a5` |
| First local baseline | turn 1, local sequence 0, timer 10 s |
| First decision | safe SWAP `(2,6) <-> (2,7)`, `STEP_3_RAGE` |
| Terminal result | `SWAP_ACKNOWLEDGED` |
| Terminal evidence | exact local sequence + exact last move + opponent turn |
| Consuming action cap | exactly 1 |
| Final invariant | `PHASE2D4_RECOVERY_RESUME_PROVEN` |

Freshness was proven by different MatchId, lifecycle epoch, Board.Instance,
opening board hash, clean local sequence, and absence of a pending old action.
The recovered action was recomputed after a full recovered-state handoff; no
failed-session proposal was reused.

Stage B1 accounting: attempts 2, completed 0, technical aborts 1, technical
recoveries 1, gameplay inputs 1, initial lobby inputs 1, recovery inputs 3.
Every run-level safety counter is zero.

## Stage B2 — Live Bounded Farm

Artifact:
`logs/farm_runs/8a5ad3f5d02b4871b0baf1a22935a422/run.json`

Configuration:

```text
target: Starburst, ID 1289
target_completed_matches = 3
max_technical_recoveries = 1
max_match_attempts = 5
```

Run result:

| Metric | Value |
|---|---:|
| Match attempts | 3 |
| Completed matches | 3 |
| Audited wins | 3 |
| Audited losses | 0 |
| Technical aborts | 0 |
| Technical recoveries | 0 |
| Safe stops | 0 |
| Gameplay inputs | 48 |
| Lobby entry inputs | 3 |
| Postmatch confirmation inputs | 3 |
| Recovery inputs | 0 |
| Normal postmatch transitions | 3 |
| Entries after a completed match | 2 |
| Entry #4 | 0 |
| Stop reason | `FARM_TARGET_COMPLETED` |
| Final location | exact `BOSS_LOBBY` |
| Final invariant | `PHASE2D4_BOUNDED_FARM_PROVEN` |

Per-match telemetry:

| # | MatchId | Session | Local/Boss turns | SWAP sent/ACK/reject | CAST sent/accepted/reject | EVOLVE attempts/fail/success | PASS | Postmatch |
|---:|---|---|---:|---:|---:|---:|---:|---|
| 1 | `M_580f715d` | epoch 1, Board `1979642337920` | 13/12 | 12/11/0 | 0/0/0 | 1/1/0 | 1 | yes |
| 2 | `M_f65ccf9a` | epoch 2, Board `1979642335232` | 16/13 | 13/12/0 | 0/0/0 | 1/0/1 | 3 | yes |
| 3 | `M_733304b5` | epoch 3, Board `1979628482560` | 22/19 | 18/17/0 | 1/1/0 | 2/1/1 | 2 | yes |
| **Total** | **3 unique** | **3 unique** | **51/44** | **43/40/0** | **1/1/0** | **4/2/2** | **6** | **3** |

The three final unacknowledged SWAPs overlapped authoritative match end and
were terminated as `ACTION_ABORTED_STATE_CHANGED`; none was retried. PASS sent
zero Windows input. Match 2 captured authoritative `idle 1 -> idle 2 ->
mandatory SWAP ACK -> idle 1`, proving the production reset boundary during
the bounded run.

No natural `SEQUENCE_DESYNC` or `DEAD_BOARD_NO_REFRESH` occurred in B2, so
`NATURAL_TECHNICAL_FAILURE = NOT_OBSERVED`. This is acceptable because Stage
B1 separately proves the live recovery-resume boundary.

## Outcome Telemetry Audit

The immutable live `run.json` records every per-match result as `UNKNOWN` and
therefore its raw summary contains `wins=0, losses=0`. This was a telemetry bug,
not a combat-completion ambiguity: all three attempts have authoritative
`ACTIVE -> POSTMATCH -> BOSS_LOBBY`, stable postmatch confirmation, and normal
completion accounting.

Each attempt retained three stable result frames. The first frame from each
attempt independently shows `THẮNG`, a living local player, and boss HP
`0/84180`:

- `matches/attempt_001/postmatch_result_frame_1.png`
- `matches/attempt_002/postmatch_result_frame_1.png`
- `matches/attempt_003/postmatch_result_frame_1.png`

Thus the audited outcome is **3 wins / 0 losses**. Screenshots are used only to
resolve the WIN/LOSS subtype; authoritative lifecycle and memory-backed farm
state remain the completion source of truth.

Root cause: on entry to POSTMATCH, `MemoryBoardStateProvider` cleared the
Board/Active ownership cache before publishing terminal PlayerStats. The BASIC
controller then classified the pre-lethal ACTIVE snapshot. The provider now
captures terminal `Active.PlayerStats` before lifecycle cleanup, and the
controller prefers that POSTMATCH state. Missing or ambiguous terminal stats
still yield `ENDED_RESULT_UNKNOWN`; no outcome is invented. The original live
artifact remains unchanged.

## Safety

All Stage B2 counters are zero:

```text
duplicate gameplay input        0
duplicate lobby entry           0
duplicate recovery exit         0
duplicate recovery confirm      0
duplicate recovery re-entry     0
wrong target                    0
wrong-turn input                0
opponent-turn input             0
stale action                    0
stale session confusion         0
postmatch gameplay input        0
lobby gameplay input            0
input after farm stop           0
```

The runner stopped after lobby reacquisition for match 3 and did not reserve
or send entry #4.

## Limit Behavior

- Recovery limit: offline test proves a second distinct technical failure after
  one successful recovery stops with `RECOVERY_LIMIT_REACHED` before another
  exit/re-entry input.
- Match-attempt limit: offline test proves the limit blocks another entry before
  input.
- Target boundary: offline and live evidence prove completion 3 stops at lobby
  with exactly three lobby entries.
- Session uniqueness: repeated MatchId or ambiguous session fails closed with
  `SESSION_REUSE_AMBIGUOUS`.
- Input after terminal stop is denied and counted.
- Natural limit exhaustion was not triggered in B2.

## Verification

Verified on 2026-08-16:

```text
PYTHONPATH=src python -m unittest discover -s tests -v
Ran 389 tests
OK

python -m compileall -q src tools tests
PASS

git diff --check
PASS
```

## Remaining Before Phase 2D.5

- Re-observe the new memory-backed terminal WIN/LOSS classification in the next
  explicitly approved bounded run; Phase 2D.4's immutable artifact necessarily
  retains the pre-fix raw `UNKNOWN/0/0` fields.
- Natural live sequence desync and zero-legal dead-board recovery remain
  `NOT_OBSERVED`.
- F7 farm-level pause/resume remains disabled.
- Process/app relaunch, internet recovery, repeated recovery budgets, long soak,
  infinite farming, and target rotation remain outside accepted scope.
