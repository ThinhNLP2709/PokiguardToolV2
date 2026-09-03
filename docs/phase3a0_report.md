# Phase 3A.0 — Source Maintenance Baseline

## Result

**PASS STRONG** on 2026-09-03 (Asia/Saigon).

Repository truth superseded the prompt's historical `v1.0.1` label: the
accepted source is `v1.0.23`, which includes the original maintenance work and
the subsequent fail-closed compatibility repairs for Pokiguard 1.7.4. The
accepted packaged release remains `v1.0.0+15`; this phase did not rebuild or
tag a package and did not implement Pet Skill/QTE automation.

Base commit before the accumulated source-maintenance work:
`4249f6178f53cc0d4498ae1c755d862491a3a428`.

## Maintenance scope

- EVOLVE and standard Attack CAST retain their visual validation regions but
  click at normalized Y `0.824` rather than `0.836`.
- Normal result confirmation removed the redundant fixed five-second wait.
  It still requires authoritative POSTMATCH, stable high-confidence modal
  evidence, a fresh lifecycle/foreground preflight and exactly one click.
- BASIC move simulation audits direct opponent Sword replies and non-Sword
  replies whose deterministic collapse/cascade collects Sword. UNKNOWN cannot
  prove safety. Unique adverse-Sword defer and dangerous Sword-hold behavior
  remain bounded and deterministic.
- Pokiguard 1.7.4 compatibility uses an exact configured executable path,
  verified metadata/runtime layouts, separate board/card/lobby viewport
  transforms, direct standard-card ownership after the opening turn, and
  bounded read-only discovery fallbacks.
- The Control tab reports per-match local turns/energy, current-match local
  turn progress and total energy from already-deduplicated turn observations;
  it adds no memory scan or capture.

## Offline verification

Focused maintenance suite:

```text
python -m unittest -v tests.test_win32_input tests.test_postmatch_ui \
  tests.test_board_simulator tests.test_basic_policy \
  tests.test_autonomous_control
Ran 186 tests
OK
```

Canonical full suite:

```text
python -m unittest discover -s tests -p "test_*.py" -v
Ran 797 tests
OK
```

`python -m compileall -q src tools tests`: **PASS**.

`git diff --check`: **PASS** (Git emitted only line-ending conversion
warnings, not whitespace errors).

The focused fixtures cover both card controls at Y `0.824`, current and legacy
postmatch layouts, stable modal requirements, direct/indirect Sword reply
evaluation, UNKNOWN handling, unique adverse-Sword defer, Sword-hold, and
PASS/mandatory-action regressions.

## Live bounded run

Accepted FarmRun: `8f7be1b715644b008431060baab72eef`.

```text
configured completed target:  5
completed / attempts:         5 / 5
WIN / LOSS / UNKNOWN:         5 / 0 / 0
result consistency:           5 CONSISTENT, 0 conflict, 0 incomplete
technical abort / recovery:   0 / 0
safe stops:                   0
gameplay inputs:              87
stop reason:                  FARM_TARGET_COMPLETED
final lifecycle:              BOSS_LOBBY
extra attempt after target:   absent
controller:                   STOPPED, exit 0
```

The five terminal snapshots are STRONG memory-backed WINs with boss HP zero.
Result and attempt accounting are both consistent. No unexplained UNKNOWN was
created.

Local turns/energy were:

```text
match 1: 19
match 2: 23
match 3: 17
match 4: 17
match 5: 23
total:   99
average: 19.8
```

## Card click evidence

All thirteen card inputs used the shared normalized click Y `0.824` in a
1280x640 client. Fusion occupied standard strip slot 0 at X `0.471`; Attack
card ID `4`, cost `160`, occupied slot 1 at X `0.529`. Every click retained a
fresh current-tile visual proof.

```text
EVOLVE attempts / success / failure: 5 / 3 / 2
CAST sent / accepted / rejected:     8 / 7 / 0
wrong card:                           0
misclick / partial:                   0 / 0
duplicate / stale card click:         0 / 0
wrong-turn / boss-turn card input:    0 / 0
```

Seven nonterminal CASTs have exact direct proof: local mana decreased by the
runtime cost 160 and the next authoritative turn belonged to the boss. The
eighth CAST reduced boss HP to zero and combat ended before a nonterminal ACK
could be recorded; it is an expected `ACTION_ABORTED_STATE_CHANGED`, not a
rejection or safety failure.

## Postmatch evidence

All five matches emitted one and only one `POSTMATCH_CONFIRM`. Every memory
result and UI result agreed as `WIN / Thắng`, and every confirmation returned
to the exact Starburst boss lobby.

```text
terminal -> confirm seconds: 2.390, 2.393, 2.456, 2.384, 2.396
minimum / maximum:           2.384 / 2.456
average:                     2.403
premature confirm:           0
duplicate confirm:           0
wrong-modal confirm:         0
final lobby success:         5 / 5
```

The artifact does not emit a separate first-ready timestamp. Stable UI audit
and actual input share the same event boundary (within log timestamp
resolution), while the terminal-to-click distribution above proves the old
fixed five-second delay is absent.

## Sword safety

Seventy-four live SWAP decisions were audited.

```text
ordinary safe + known direct Sword reply:   0
ordinary safe + known indirect Sword reply: 0
UNKNOWN used as favorable proof:            0
maximum direct replies observed:             2
maximum effective known reply observed:      3
live unique-adverse-Sword:                   NOT_OBSERVED
live Sword-hold:                             NOT_OBSERVED
```

Attempt 2 turn 5 naturally exposed two known direct opponent Sword replies;
the selected Sword action was correctly labelled dangerous (`safe=false`). No
selected live action had an indirect reply. The indirect cascade and rare
exception branches remain proven by deterministic focused tests; no game board
was manufactured.

## Safety and scope

All FarmRun critical counters are zero: duplicate gameplay/lobby/recovery/
postmatch input, wrong target/turn, opponent-turn input, stale action/session,
gameplay in lobby/postmatch/after stop, result double count and result
conflict. Combat summaries also report zero action timeout, expired action,
misclick, partial input, dead board, sequence desync, too-late action, local
deadline stop, wrong third PASS and mandatory-reset UNKNOWN.

Four terminal SWAPs and one terminal CAST ended with lifecycle-abort evidence
because each combat finished before the ordinary nonterminal acknowledgement
boundary. All were final-state transitions; none was rejected or retried.

Natural technical recovery was `NOT_OBSERVED`. No recovery was forced.

The implementation and live run preserve the approved safety boundary:
external read-only process memory plus normal foreground Windows input only;
no memory write, injection, direct game method call, packet manipulation or
game-file modification.

## Acceptance

Phase 3A.0 is accepted **PASS STRONG**. No additional live match is required
for this phase. The next roadmap phase is **Phase 3A.1 — Pet Skill / QTE
Reverse Closure**, which is **NOT IMPLEMENTED** here.
