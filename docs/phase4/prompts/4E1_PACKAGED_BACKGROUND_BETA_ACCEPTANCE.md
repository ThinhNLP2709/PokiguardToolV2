# Phase 4E.1 — Packaged Background Beta Acceptance

Implement and validate **Phase 4E.1 ONLY**.

Entry gate: 4D.2 `PASS STRONG`, exact accepted source commit and no unresolved
Phase 4 remediation.

## 1. Goal

Build and accept a portable Windows package containing the accepted Phase 4
scope. Version/tag comes from current repository/user decision; không hard-code
roadmap version.

Build output bắt buộc nằm dưới:

```text
D:\PokiguardToolV2\build\<version>\
```

## 2. Pre-build

- inspect Git/status/upstream and preserve unrelated user files;
- run focused background/input/UI/FarmRunner/package tests;
- full regression;
- compileall;
- diff-check;
- verify canonical version/title/labels;
- verify PyInstaller spec bundles required modules only;
- do not include logs, reverse dumps, credentials or user preferences.

## 3. Build/offline package checks

- clean PyInstaller work/dist under repo build root;
- deterministic ZIP;
- packaging self-check with fresh data root;
- offline UI smoke;
- old preferences migration to foreground;
- new background/hybrid preference round-trip;
- no automatic Start/Resume;
- no writes beside EXE, source repo or game install.

## 4. Packaged live stages — user controls game

Use one unchanged artifact for all stages:

1. foreground default smoke;
2. background/hybrid one-match smoke;
3. small bounded multi-match run;
4. Pet Skill QTE branch if supported;
5. graceful stop;
6. emergency stop at a relevant pending boundary;
7. checkpoint/resume;
8. navigation/re-entry branch;
9. final clean shutdown.

Do not rebuild between stages. A fix requires a new artifact/hash and rerun of
affected acceptance.

## 5. Release evidence

Record:

- source/release commit;
- package path/size/SHA-256;
- PyInstaller/Python/platform;
- self-check/offline/live run IDs;
- capability branch and user-facing limitations;
- source/package/game write audit;
- final controller/process state;
- release manifest/docs/tag/push state.

## 6. PASS STRONG

All offline and packaged live stages clean, default foreground preserved,
background semantics honest, zero critical input violation, no artifact drift,
hash/manifest/docs/Git release state complete.

Tag/publish only when current workflow/user authorization says release is
chốt; otherwise leave the fully built, reviewable artifact and report pending
final release action.

## 7. Explicit stop

After PASS STRONG, set Phase 4 roadmap complete and STOP. Do not begin another
feature roadmap.
