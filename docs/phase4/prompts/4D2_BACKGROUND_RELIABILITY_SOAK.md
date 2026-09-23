# Phase 4D.2 — Background Reliability Soak

Implement and validate **Phase 4D.2 ONLY**.

Entry gate: 4D.1 `PASS STRONG`, no unresolved remediation.

## 1. Goal

Chạy bounded long-run acceptance cho đúng background/hybrid branch đã accepted.
Đề xuất target mặc định 25 completed matches với attempt margin hữu hạn.

Không thay production code trước run trừ khi preflight phát hiện regression. Nếu
code đổi sau khi soak bắt đầu, sample cũ không còn là acceptance của build mới.

## 2. Preflight

Record:

- exact source commit/version/game hash;
- immutable config/input mode;
- package/source launcher (source ở phase này);
- focus/cover plan;
- target/attempt limit;
- no competing controller;
- current clean boss lobby.

User controls Windows/game and starts the run. Agent monitors logs; không dùng
computer-use.

## 3. Soak invariants

```text
wins + losses + unknown == completed
completed == configured target
attempts <= max attempts
no extra attempt after target
```

Critical zero:

- wrong HWND/PID;
- wrong-turn/boss-turn input;
- partial input without safe stop;
- duplicate/stale input;
- unconfirmed input retry;
- stale card/QTE after MatchId change;
- direction/Space after Stop ACK;
- unexpected foreground takeover;
- cursor movement from background mouse path;
- terminal conflict;
- orphan controller/poller.

Minimized is outside scope unless STATUS explicitly says supported.

## 4. Natural recovery

Recovery/re-entry may occur naturally. Do not fabricate server/room failure.
If absent, record `NOT_OBSERVED` and rely on accepted deterministic replay.

Any natural route must use fresh board/card/QTE/target proof.

## 5. Analysis

Generate machine-readable manifest/analysis plus Markdown summary:

- per-match result/input/focus/recovery;
- ACK latency distribution;
- mode/domain counts;
- focus handoff distribution for Hybrid;
- exact stop reason/final lifecycle;
- critical counter aggregate.

Run final focused/full/compileall/diff-check against exact accepted source.

## 6. PASS STRONG

Exact target completed, accounting consistent, no critical violation, no extra
attempt, final controller stopped and lifecycle expected, artifacts complete,
STATUS/router -> 4E.1.

## 7. Explicit stop

STOP after soak report/checkpoint. Do not package in the same phase.
