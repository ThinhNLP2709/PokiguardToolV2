# Phase 3C.2 — User-operated live runbook

All live mouse/keyboard operation belongs to the user. Codex may read and audit
the resulting logs after each stage but must not open, configure, Start, Stop
or close the Desktop UI unless the user explicitly requests that action.

## Offline gate

Current source result:

- final Phase 3C.2 focused tests: **158/158 PASS**;
- dedicated Audition V3 tests: **9/9 PASS**;
- Audition V2 config/preferences/controller compatibility: **3/3 PASS**;
- full regression: **1236/1236 PASS**;
- compileall: PASS;
- diff check: PASS;
- source version: `v1.0.47`.

## B1 — configuration check

From the boss lobby, open `run_tool.bat`, then select:

```text
Pet của tôi: Huyền thoại
Tiến hóa: Không tiến hóa
Thẻ sát thương: Thẻ skill của pet
Intelligence: basic
Audition: audition_v3
```

Do not select `Huyền thoại + Tiến hóa pet huyền thoại`; that is a future
two-skill-source profile and is outside Phase 3C.2.

Confirm that Start is enabled and the status says the configuration is
supported. B1 itself sends no gameplay input.

Accepted: **PASS**. The exact profile validated as supported through the
normal Desktop UI and the configuration-only check sent zero gameplay input.

## B2 — one Desktop Pet Skill match

Set:

```text
Target matches: 1
Max attempts: 2
```

Press **Start** once. Do not manually swap, click a skill card, press QTE keys,
press Space or confirm the result. Wait until the tool reports STOPPED and the
game returns to `BOSS_LOBBY`, then tell Codex that B2 finished so its artifacts
can be audited before B3.

Acceptance requires exactly one completed match, at least one Pet Skill,
Perfect for every skill, zero EVOLVE/default Attack, no QTE/gameplay safety
violation and no second match.

Accepted: **PASS**, farm run `97ba42e804794bd8bb136ad3c64707af`, one
completed win, one `SUCCESS_PERFECT`, 7/7 confirmed directions, one in-window
Space, no extra match, final `BOSS_LOBBY / STOPPED`.

## B3 — five completed matches

Run only after B2 is audited clean. Set target `5` and max attempts `8`, then
press Start once and provide no manual combat assistance. Wait for STOPPED at
`BOSS_LOBBY` and ask Codex to audit the run.

Accepted: **PASS**, farm run `feff9bffa0794632a655cc9dc6bc7b6b`, exactly
5/5 wins and four `SUCCESS_PERFECT` Pet Skills. This run did not require
re-entry; a future detached-room re-entry issue is tracked as separate scope.

## B4 — graceful stop

Run only after B3 passes. Set a target greater than one. During the first
active match press **Stop After Current Match** once. The current match must
finish and return to `BOSS_LOBBY`; the tool must not enter the next match.

Accepted: **PASS**, farm run `8c0b3a53985a4e6db04254de6562624b`,
one accepted graceful-stop command, one completed win, no second entry, final
`BOSS_LOBBY / STOPPED`.

## B5 — default regression

Select `Pet thường / Tiến hóa pet thường / Thẻ chưởng mặc định / BASIC`, set
target `1`, and run one match. PetSkillAction must remain zero and the final
state must be STOPPED at `BOSS_LOBBY`.

The Desktop UI used for B4 has since been closed normally. Reopen
`run_tool.bat` before this user-operated B5 stage.

Accepted: **PASS**, farm run `15a10dc9bbf34626958b0f4ccec41ebd`, one
completed win under the exact default profile, PetSkillAction zero, no extra
match, final `BOSS_LOBBY / STOPPED`.

## B6 — clean shutdown

After the controller has stopped, close the Desktop UI normally. The game may
remain open. Codex will verify that no UI, poller, FarmRunner or PetSkill worker
remains.

Accepted: **PASS** from Desktop artifact `20260915_172841`. The UI and poller
stopped cleanly, worker Tk writes and UI errors were zero, no automation worker
remained, and the game process remained running.
