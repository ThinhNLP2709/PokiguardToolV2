# ROADMAP FOR CHATGPT — HIGH-LEVEL ONLY

This file is NOT a Codex implementation prompt.

Its purpose is to tell ChatGPT what kinds of phases remain so ChatGPT can generate the detailed next prompt after reviewing evidence.

Current baseline checkpoint: **2D.5 PASS STRONG**

---

## 2D.6 — Long-Running Farm Operations + Graceful Control

Goal category:

- stop-after-current-match;
- durable historical checkpoint;
- explicit safe resume from BOSS_LOBBY;
- longer bounded soak;
- no infinite mode.

Expected evidence before advancing:

- graceful stop live-proven;
- checkpoint/resume live-proven;
- longer bounded soak;
- no extra entry after stop/target;
- no stale accounting/state leak.

---

## 2E.1 — Desktop Control UI MVP

Goal category:

- desktop UI shell;
- backend control-plane abstraction;
- config/status display;
- UI responsiveness;
- zero-input read-only live smoke.

Do NOT require full UI-driven farm yet.

---

## 2E.2 — UI ↔ FarmRunner Live Integration

Goal category:

- Start from UI;
- Stop After Current Match from UI;
- Emergency Stop from UI;
- checkpoint Resume from UI;
- bounded live farming through UI.

---

## 2E.3 — UI Hardening + Operator UX

Goal category:

- lifecycle-aware control gating;
- safe close/shutdown;
- preferences;
- error UX;
- bounded logs;
- long UI-driven soak;
- no orphan controller.

---

## 2F.1 — Standalone Windows Packaging

Goal category:

- reproducible Windows packaged app;
- no developer CLI required;
- safe writable config/log/checkpoint paths;
- packaged UI and short live run;
- no writes to game installation.

---

## 2F.2 — Release Candidate + Final Acceptance

Goal category:

- packaged final bounded acceptance;
- graceful stop/resume;
- emergency stop;
- final docs;
- release manifest/hash;
- clean Git release/tag;
- declare project complete for BASIC scope only if all final evidence passes.

---

## IF SOMETHING FAILS

Do NOT blindly advance.

ChatGPT should create a narrow remediation phase/stage, for example:

```text
2E.2-R1 — Fix orphan controller on UI close
```

or:

```text
2F.1-R1 — Remove source-repo path dependency from packaged build
```

Then return to roadmap only after the blocker is accepted.
