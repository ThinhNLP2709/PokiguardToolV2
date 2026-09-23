# Phase 4B.4H — Hybrid QTE Foreground Handoff

Implement and validate **Phase 4B.4H ONLY**.

Entry gate:

- background mouse/card path PASS STRONG;
- 4A.2 concluded `HYBRID_REQUIRED`, hoặc full keyboard branch bị rejected và
  report/router explicitly chuyển sang hybrid;
- 4B.3 PASS STRONG.

## 1. Exact goal

Board và proven mouse domains tiếp tục chạy nền. Khi current validated Pet Skill
được chọn, controller thực hiện một bounded exact-PID foreground handoff trước
click/QTE input, dùng QTE path foreground đã accepted, rồi kết thúc handoff an
toàn. Không gọi đây là full background.

## 2. Handoff contract

- capture foreground HWND trước handoff chỉ để telemetry/optional restore;
- revalidate exact game PID/HWND/session/card/actionability;
- restore/foreground game bằng existing safe backend;
- reread all state after focus; pre-focus proof không authorize input;
- execute existing foreground card/QTE/Space path;
- no new focus handoff after stop ACK;
- optional return to prior app only if HWND still valid and operation is safe;
- nếu return focus fails, leave game foreground; không click/keypress vào app
  khác;
- UI/log phải ghi focus takeover reason/duration/result.

Không synthesize background key khi evidence nói hybrid.

## 3. Tests

Cover:

- exact PID focus restore;
- foreground app changes/disappears;
- fresh reread after handoff;
- stop before/during QTE;
- focus loss mid-QTE;
- optional focus return success/failure;
- no input to prior/unknown HWND;
- foreground baseline and background board unchanged.

Run focused/full/compileall/diff-check.

## 4. Live — user controls game

Run 3 Pet Skill actions:

- begin while another app is foreground;
- observe exactly one bounded game handoff per skill action;
- exact directions/Space/PERFECT via accepted foreground path;
- no unexpected repeated focus steal;
- focus return behavior logged honestly;
- zero stale/duplicate/wrong input.

## 5. PASS STRONG and routing

Require 3/3 clean handoffs/actions, clear user-visible semantics and no claim of
full background. Then STATUS/router -> 4C.1.

## 6. Do not implement

Desktop preference, navigation/re-entry handoff, policy changes, soak/package.

## 7. Explicit stop

STOP after hybrid action report/checkpoint.
