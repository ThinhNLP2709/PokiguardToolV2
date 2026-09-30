# Phase 4B.2 — Pinned Foreground Board Integration Report

## Current result

```text
RESULT: PASS STRONG
DEFAULT FOREGROUND MODE: REGRESSION CLEAN
BETA PRODUCTION BOARD CALL SITE: INTEGRATED
LIVE FOREGROUND SAMPLE: PASS
LIVE PINNED SWAP ACK SAMPLE: PASS — 3/3 ACK; 2 EXTERNAL-FOCUS TAKEOVERS
NEXT PROMPT: prompts/4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md
```

Phase 4B.2 đạt `PASS STRONG`. Foreground B1 và pinned Beta B2 đều có exact
production SWAP ACK cùng zero critical safety violation.

## Scope implemented

- thêm production `PinnedForegroundBoardSession`, chỉ nhận typed
  `BOARD_SWAP`/mouse lease trong mode `PINNED_FOREGROUND_LEASE_BETA`;
- pin exact PID/HWND/title/client geometry trong suốt combat controller và
  unpin bằng context cleanup;
- giữ executor, coordinate plan, swap pacer, solver, policy và ACK cũ;
- nhánh foreground vẫn dùng trực tiếp executor cũ, không qua lease;
- nhánh Beta chỉ xin FarmRunner gameplay permit sau khi game đã lấy foreground;
- direct runtime được đọc lại nhiều lần, gồm lần sau focus acquire, để xác nhận
  match, turn, local player, local move sequence và timer;
- mỗi action identity chỉ được cấp một lease; rejected/uncertain/partial không
  được blind retry;
- stop giữa hai click cấm endpoint thứ hai; stop trong drag luôn nhả LEFTUP;
- cleanup guard/cursor/focus được ghi log; sent input có cleanup không hoàn tất
  sẽ đóng action identity và safe-stop;
- package graph đã thêm module board integration. Desktop UI/FarmRunner mode
  selection vẫn để Phase 4C.1; 4B.2 live dùng source-selected controller flag.

Card, EVOLVE, PASS, Pet Skill/QTE, navigation, result confirm và re-entry không
được chuyển sang lease trong phase này.

## Offline verification

```text
Latest focused delivery/input/board/lease tests: 66/66 PASS
Latest full regression: 1498/1498 PASS
compileall: PASS
git diff --check: PASS
```

Focused tests cover typed mode/domain, exact binding, stale post-focus
preflight, wrong geometry, stop-before-input, stop between endpoints, drag
cleanup, partial input, single-use identity, FarmRunner foreground permit and
the existing exact SWAP ACK/no-ACK state machine. The full policy/solver suite
remains unchanged and passes.

The apparent `ERROR` and argparse usage lines emitted by the full suite are
intentional negative-path fixtures; unittest ended with `OK`.

Before live B1, the source also received the evidence-driven empty-room
re-entry repair documented in
`../general_hub_chinh_phuc_reentry_report.md`. It does not alter board input
delivery: it restores postmatch lobby classification when Board has already
been destroyed and accepts the positively proven island panel beneath a stale
room shell. The resulting full suite remains clean.

## B1 live foreground regression

Accepted run: `39dbd430a6694a8dbb8f37696fbfa0df`, match
`M_3684eff6`.

```text
inputDeliveryMode=foreground
pinnedBoardSessionActive=false
completed=1/1; result=WIN; confidence=STRONG
swap_sent=5; swap_acknowledged=5; swap_rejected=0
first ACK=EXACT_MATCHSERVICE_LOCAL_SEQUENCE_LAST_MOVE_AND_OPPONENT_TURN
duplicate=0; misclick=0; partial=0; wrongTurn=0; stale=0
bossTurnInput=0; postmatchInput=0; lobbyInput=0; inputAfterCombat=0
return=BOSS_LOBBY_READY; final=FARM_TARGET_COMPLETED
```

The foreground path stayed on the old direct executor (`boardLease=null`) and
completed normally. This satisfies B1 without using any Beta lease behavior.

For B2, FarmRunner now accepts a source-only environment selector named
`POKIGUARD_PHASE4B2_INPUT_DELIVERY_MODE`. Its default remains `foreground`;
the only Beta value is `pinned_foreground_lease_beta`. Invalid values fail
before FarmRunner receives input authority. The selector is intentionally not
stored in Desktop preferences and is not exposed in the UI; that product
integration remains Phase 4C.1.

## Required live acceptance

### B1 — foreground regression

- run the existing foreground path;
- user enters the match normally;
- observe at least one accepted production SWAP;
- require current session/turn ACK and zero critical safety counters.

### B2 — pinned foreground Beta

- start from boss lobby with the source-selected Beta controller;
- keep another application foreground when the local turn becomes actionable;
- observe 1–3 production SWAPs;
- each swap must show one lease, exact proposal/coordinate/turn sequence ACK,
  no duplicate/unconfirmed retry, and clean mouse/cursor/focus/topmost cleanup;
- user exits/stops after the bounded sample.

Only after B1 and B2 pass may this report become `PASS STRONG` and route to
`prompts/4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md`.

## B2 attempt 1 — fail before first click, remediated

Run `6f20f150e3de4c1eb276a29cea88b043`, match `M_ccb5869c`, reached a valid
first-turn SWAP proposal `(5,2)->(6,2)`. The exact window was pinned, the
foreground lease and `CURSOR_CONFINE` guard were acquired, then the trace ended
at `foreground_lease_action_begin`. There was no click, action-end, guard
release or board ACK. The user observed two skipped turns and the Desktop UI
became unresponsive when Emergency Stop was pressed.

The failure was a same-thread lock recursion in `FarmControlHotkeyEdges`:

1. `execute_if_authorized()` held the authority lock around the atomic input;
2. the Beta executor called its `stop_requested` boundary before click 1;
3. that boundary polled the same FarmRunner authority and tried to acquire the
   same non-reentrant lock;
4. the worker deadlocked before input, while the UI Emergency Stop command also
   waited on that lock.

The authority lock is now reentrant for its owning input thread. Cross-thread
serialization is preserved, so an external Emergency Stop still cannot permit
a later input operation. A regression test requires an accepted atomic input
to poll its own emergency authority and finish within one second. Additional
`pinned_board_swap_stage` breadcrumbs now distinguish callback entry, permit
resolution, atomic gate entry and return.

Post-fix verification:

```text
Focused input/board/lease tests: 54/54 PASS
Full regression: 1497/1497 PASS
git diff --check: PASS
```

The hung tool process was terminated, the cursor guard was explicitly released
and the game window was unpinned. B2 remains pending because the fix has not yet
produced a live SWAP ACK.

## B2 attempt 2 — first SWAP ACK, external-focus gate exposed

Run `3d99b850e5e0427c85eead09c2cc714f`, match `M_9542e4ea`, proves the deadlock
repair works. The first-turn proposal `(4,6)->(5,6)` traversed all new stage
breadcrumbs, sent exactly two clicks, released `CURSOR_CONFINE`, restored the
cursor and received
`EXACT_MATCHSERVICE_LOCAL_SEQUENCE_LAST_MOVE_AND_OPPONENT_TURN` ACK.

That first lease recorded `gameAlreadyForeground=true`, matching the user's
observation that the game still owned focus. After the user focused another
application, the next local-turn preparation was rejected by the legacy
`ActionabilityGate` as `GAME_NOT_FOREGROUND` before a board lease could be
armed. The server emitted `MATCH_AFK_WARN idleCount=1`. The sample was stopped
and the game unpinned before a third idle turn.

The integration now treats foreground differently at the two correct
boundaries:

- foreground mode is unchanged and still fails closed when the game lacks
  focus;
- Beta may perform input-free board/policy preparation without foreground;
- only an already-selected SWAP receives that fresh-gate exception;
- the bounded lease must still acquire the exact game HWND, rerun exact
  session/turn/timer preflight and obtain the normal SWAP ACK before success;
- PASS, cards, EVOLVE and other actions not integrated in 4B.2 retain their
  existing foreground checks.

Post-fix verification is now:

```text
Focused delivery/input/board/lease tests: 66/66 PASS
Full regression: 1498/1498 PASS
Default input-delivery mode: foreground
Beta activation: explicit source-only environment selector
```

## B2 accepted live sample

Accepted run: `51ae7795cd754e5f86624472334517a0`, match `M_5f0b8e57`.
The user kept the game foreground for entry, then moved focus to other
applications and stopped with F9 after three local actions as required by the
bounded script.

```text
inputDeliveryMode=pinned_foreground_lease_beta
swap_sent=3; swap_acknowledged=3; swap_rejected=0
lease COMPLETE=3/3; guard release=3/3; cursor restore=3/3
external foreground takeover=2/3
foregroundBefore=1840700,395616,21627218
foregroundGame=1840700,1840700,1840700
focus restored=3/3
ACK=EXACT_MATCHSERVICE_LOCAL_SEQUENCE_LAST_MOVE_AND_OPPONENT_TURN (3/3)
duplicate=0; misclick=0; partial=0; wrongTurn=0; stale=0
bossTurnInput=0; postmatchInput=0; lobbyInput=0; inputAfterCombat=0
blind retry=0; input after F9 acknowledgement=0
pin cleanup=UNPINNED
```

The first action proves the same-foreground route remains valid. Actions two
and three prove the intended behavior: another HWND owned foreground before
the lease, the exact game HWND acquired focus for the bounded two-click SWAP,
then the prior HWND and cursor were restored. All three server acknowledgments
matched the exact local sequence, last-move coordinates and opponent-turn
transition. The run ended `SAFE_STOP/F9_EMERGENCY_STOP` by test design rather
than by a gameplay or transport failure.

Phase 4B.2 therefore routes to
`prompts/4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md`.
