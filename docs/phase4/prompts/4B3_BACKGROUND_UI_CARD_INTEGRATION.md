# Phase 4B.3 — Background UI and Card Integration

Implement and validate **Phase 4B.3 ONLY**.

Entry gate: 4B.2 `PASS STRONG` và 4A.1 background single click accepted.

## 1. Exact goal

Nối background single-click transport vào từng UI/card domain được xác định rõ,
không dùng một generic bypass.

Candidate domains:

```text
Boss Start / approved retry
lobby card select
EVOLVE
default CAST
Pet Skill card trigger only (không QTE keyboard)
postmatch result confirm
room-shell exit/confirm nếu precondition đã đủ
```

Chỉ domain có fresh identity/proof và post-state ACK mới được bật. Domain chưa đủ
proof giữ foreground-only và được ghi rõ.

## 2. Safety contract

- exact PID/HWND/current lifecycle/session;
- current CardUI/Button/CardData identity cho card;
- current slot geometry, not stale fixed index;
- no click on ambiguous/placeholder/non-interactable card;
- result click requires authoritative POSTMATCH/stable modal;
- Start/retry keeps existing attempt budget and no-extra-entry invariant;
- queue success != accepted;
- one click per permit;
- no reclick while outcome uncertain;
- foreground behavior unchanged.

Pet Skill trigger stage kết thúc khi fresh QTE appears; không gửi directions hoặc
Space trong phase này.

## 3. Tests

Per-domain tests cho:

- allowed mode/domain;
- wrong lifecycle/session/identity;
- stale CardUI/button;
- no post-state ACK;
- delayed ACK without duplicate;
- stop after queue/before ACK;
- result/entry accounting;
- current foreground regression.

Run focused, full regression, compileall, diff-check.

## 4. Live — user controls game

Tối thiểu prove tự nhiên/bounded:

- one background Start with new-session evidence;
- one background validated card click phù hợp config;
- one background postmatch confirm trở lại exact lobby;
- nếu Pet Skill trigger được test: QTE fresh appears, zero direction/Space tool input;
- game non-foreground during each tested input;
- zero cursor movement/focus takeover.

Không force EVOLVE/CAST/Pet Skill branch nếu loadout không cung cấp; ghi
`NOT_OBSERVED`, nhưng PASS STRONG cần ít nhất một production card domain live.

## 5. Routing

Sau PASS STRONG:

- `FULL_BACKGROUND_CAPABLE` -> 4B.4F;
- `HYBRID_REQUIRED` -> 4B.4H.

Safety failure -> 4B.3-Rn.

## 6. Do not implement

QTE keyboard, Desktop preference, full FarmRunner background loop, navigation/
re-entry closure hoặc package.

## 7. Explicit stop

STOP sau report/checkpoint và update STATUS.
