# Phase 4C.2 — Navigation and Re-entry Background Closure

Implement and validate **Phase 4C.2 ONLY**.

Entry gate: 4C.1 `PASS STRONG`.

## 1. Exact goal

Đóng route sau match/empty room/game lobby/map/island/boss room cho background
mode mà không dùng stale/occluded screen evidence.

Chọn đúng một accepted product route:

```text
NATIVE_BACKGROUND_ROUTE
FOREGROUND_NAVIGATION_HANDOFF
```

Nếu evidence chỉ đủ cho một số transition, capability phải ghi domain-specific;
không gắn nhãn full background cho toàn cycle.

## 2. Audit before code

Liệt kê từng transition và proof hiện dùng:

- postmatch -> boss lobby;
- empty room -> close;
- close -> boss map hoặc game lobby;
- game lobby -> Chinh Phuc;
- map -> current island;
- island -> current boss;
- boss room -> Start.

Đánh dấu memory/native vs screen-DC visual. Chụp desktop bị che không được coi là
proof của game UI.

## 3. Native route requirements

Chỉ dùng khi exact current UI/runtime identity, group/island/boss target và click
geometry được read-only prove. Không đoán từ cached pet ID/card position.

Mỗi click có fresh preflight + post-state ACK. Unknown/stale target stops.

## 4. Foreground handoff requirements

Nếu native proof không đủ:

- foreground exact game HWND trước visual capture;
- reread/capture after focus;
- use current accepted navigation visual proof;
- bounded click;
- log focus duration/reason;
- optional safe focus return;
- no claim of full background.

Không giảm visual threshold để pass khi bị che.

## 5. Tests

Replay/fakes cover every transition, both possible branches where relevant,
wrong island/boss, stale cache, covered invalid screenshot, game lobby vs boss
map distinction, empty-room variants, stop/recovery/checkpoint and no extra entry.

Run focused/full/compileall/diff-check.

## 6. Live — user controls game

Use a bounded run large enough to observe normal postmatch re-entry. Natural
empty-room/game-lobby recovery is useful but must not be fabricated.

Require:

- at least two complete cycles into a next match;
- exact island/boss target preserved;
- expected focus behavior per chosen route;
- zero stale/wrong navigation click;
- no extra attempt;
- natural rare branches recorded `NOT_OBSERVED` if absent and replay-tested.

## 7. PASS STRONG

Chosen route is explicit, live normal cycle clean, rare branches replay-covered,
foreground label honest, all tests/safety clean, STATUS/router -> 4D.1.

## 8. Explicit stop

STOP after navigation/re-entry report/checkpoint. No A/B/soak/package.
