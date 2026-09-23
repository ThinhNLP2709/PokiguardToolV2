# Phase 4C.1 — Desktop UI ↔ FarmRunner Background Integration

Implement and validate **Phase 4C.1 ONLY**.

Entry gate: 4B.2, 4B.3 và đúng một nhánh 4B.4F/4B.4H đều `PASS STRONG`.

## 1. Exact goal

Expose capability đã accepted qua Desktop UI, preferences và immutable FarmRun
config. Chạy một bounded source-live farm nhỏ. Không mở navigation/re-entry
scope chưa được 4C.2 đóng.

## 2. UI/product behavior

Thêm user-facing input mode phù hợp capability:

```text
Tiền cảnh (mặc định)
Click nền — Beta
Click nền lai — QTE đưa game lên trước   [chỉ branch Hybrid]
```

Không hiển thị `Full background` nếu capability matrix không Full.

UI phải nói rõ:

- game phải mở và không minimized;
- domain nào chạy nền;
- QTE/navigation có đưa game lên trước hay không;
- unsupported board input mode/config;
- mode bị khóa khi run active.

Preferences cũ migrate foreground. Save/Start reject impossible combination rõ
ràng; không silent fallback.

## 3. FarmRunner integration

- delivery mode immutable trong run/checkpoint;
- resume validates capability/version/mode;
- permit gates dùng delivery authority theo domain, không global foreground skip;
- foreground mode behavior/counters unchanged;
- background/hybrid telemetry ở run/match/action level;
- graceful/emergency stop work at every pending transport boundary;
- no extra attempt after target;
- unsupported re-entry boundary stops with an explicit reason until 4C.2.

## 4. Tests

Cover UI labels/save/load/migration/locking, run/checkpoint/resume, capability
matrix, domain gates, stop behavior, foreground regression and package imports.

Run focused, full regression, compileall, diff-check.

## 5. Live — user controls game

Source `run_tool`, exact accepted boss lobby.

Stages:

1. B1 foreground/default one completed match;
2. B2 background/hybrid one completed match;
3. B3 background/hybrid bounded 3–5 completed matches only if B2 clean;
4. one graceful stop boundary;
5. verify UI/runtime status and final controller state.

Do not force empty-room/re-entry. If it occurs naturally and current route is not
yet supported, a clean explicit stop is acceptable and recorded for 4C.2.

## 6. PASS STRONG

- default mode unchanged;
- background mode selectable only when valid;
- bounded target/accounting correct;
- zero wrong/stale/duplicate/partial input;
- exact mode telemetry;
- expected focus behavior only;
- controller/UI clean final state;
- STATUS/router -> 4C.2.

## 7. Do not implement

New navigation proof, long soak, package or unrelated gameplay/policy changes.

## 8. Explicit stop

STOP after source UI/FarmRunner report/checkpoint.
