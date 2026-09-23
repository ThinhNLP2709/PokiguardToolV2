# Phase 4B.2 — Background Board Swap Integration

Implement and validate **Phase 4B.2 ONLY**.

Entry gate: 4B.1 `PASS STRONG`. Chỉ board primitive có status `ACCEPTED` trong
4A.1 mới được nối production.

## 1. Exact goal

Cho phép BASIC board SWAP dùng transport nền đã proven, qua đúng actionability,
FarmRun permit và board ACK hiện có. Không thay solver, policy, scoring, PASS,
card hoặc QTE.

## 2. Required behavior

- foreground mode giữ nguyên đường hiện tại;
- background mode không yêu cầu foreground nhưng vẫn yêu cầu exact PID/HWND,
  geometry, active combat, local turn, timer/actionability và current session;
- minimized vẫn reject;
- covered-window chỉ được claim nếu live stage thực sự cover game;
- nếu only `TWO_CLICK_ONLY`, background mode phải reject drag rõ ràng;
- `PostMessage` queued chưa hoàn tất action;
- current board/sequence/turn transition là ACK;
- unconfirmed swap không được blind retry hoặc chuyển proposal khác trong cùng
  uncertain action;
- partial two-click/drag ghi safety event và fail closed;
- no policy-specific special case để làm test dễ pass.

## 3. Tests/replay

Cover foreground/background matrix và:

- permit with foreground false only for accepted background mode;
- same call rejected in foreground mode;
- wrong PID/session/turn/geometry;
- message queued but no ACK;
- authoritative ACK;
- partial input;
- stop between endpoints;
- no duplicate after delayed ACK;
- existing AFK/PASS/swap timeout behavior;
- solver output unchanged for same board.

Run focused, full regression, compileall, diff-check.

## 4. Live — user controls game

Use source tool/harness, not package. User prepares boss lobby/combat and decides
when to bring another window foreground.

Stages:

1. foreground regression: at least one acknowledged swap;
2. background mode: 1–3 acknowledged swaps over fresh local turns;
3. one covered-game interval if 4A.1 evidence says supported;
4. graceful/emergency stop check with zero input after ACK.

Do not run full farm or Pet Skill acceptance here.

## 5. PASS STRONG

- every attempted background swap has exact outcome classification;
- accepted swaps have authoritative ACK;
- zero wrong-turn/duplicate/stale/partial-unhandled input;
- foreground regression clean;
- no cursor movement/focus takeover in background path;
- logs/replay/report complete;
- STATUS/router -> 4B.3.

## 6. Do not implement

Single UI/card background click, QTE, Desktop option, navigation/re-entry,
package or policy changes.

## 7. Explicit stop

STOP after board integration acceptance/report/checkpoint.
