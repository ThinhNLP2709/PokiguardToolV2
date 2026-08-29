# Phase 2F.2 — Release Candidate + Final Acceptance

## Result

**PASS STRONG — BASIC SCOPE COMPLETE** on 2026-08-29 (Asia/Saigon).

All offline, packaged-live and shutdown acceptance stages B1-B6 passed against
the same Release Candidate binary. The pre-existing untracked
`docs/pokiguard_pet_skill_qte_reverse_report.md` was first preserved
byte-for-byte in separate documentation commit `c2f4242e` after explicit user
authorization. It was not mixed into the RC artifact or runtime graph. This
resolved the Git-hygiene boundary without deleting or silently ignoring data.

Base and artifact source commit:
`1dd53340e20ca405c0bf446682b3fcbf823afe62`.

## Release Candidate

```text
version:              v1.0.0+15
packaging:            PyInstaller 6.22.0 / CPython 3.11.9 x64
format:               portable one-folder Windows x64 ZIP
filename:             PokiguardToolV2-v1.0.0+15-win-x64.zip
archive size:         13,609,921 bytes
SHA-256:              e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69
bundle files:         994
bundle size:          29,894,977 bytes
executable size:      3,651,784 bytes
artifact source:      1dd53340e20ca405c0bf446682b3fcbf823afe62
release commit:       recorded in the release manifest
release tag:          v1.0.0+15
```

The clean build ran from the accepted source commit and used
`packaging/PokiguardToolV2.spec`. The archive was extracted outside the source
repository and game installation, launched from a different working directory,
with `PYTHONPATH` absent and fresh application data. The packaged self-check,
offline UI smoke and game-absent smoke all exited 0.

The first B2 operator launch used an unnecessarily deep isolated data root.
The Codex AppContainer added its own redirection prefix, producing a 266-character
PNG evidence path and a Windows `FileNotFoundError`. The expected directory did
exist; the path exceeded the legacy Windows path limit. The run safe-stopped
before entry. No product code changed. The same RC artifact was rerun with a
short isolated LocalAppData root whose expected capture path was 152 characters;
all final live stages below use that artifact and boundary.

## B1 — packaged release smoke

Game-absent packaged launch:

```text
game detected / attached:     false / false
lifecycle:                    UNAVAILABLE
provider reason:              attach_failed
Start / Resume:               0 / 0
gameplay / boss-entry input:  0 / 0
render ticks:                 10
UI errors:                    0
poller alive after close:     false
exit code:                    0
```

Read-only attach after the user manually launched the game and entered the
exact boss room:

```text
game PID / architecture:      6968 / x64
lifecycle:                    BOSS_LOBBY
target:                       Starburst / 1289
Start / Resume:               0 / 0
unexpected input:             0
render ticks:                 25
UI errors:                    0
controller / poller stopped:  true / true
game remained running:        true
```

## B2 — final packaged bounded farm

Accepted FarmRun: `e113cf4a037949f68bcebc1d086a311d`.

```text
configured target / attempts: 10 / 16
completed / attempts used:    10 / 12
WIN / LOSS / UNKNOWN:         10 / 0 / 0
terminal confidence:          10 STRONG
memory/UI consistency:        10 CONSISTENT, 0 conflict/incomplete
technical abort/recovery:     2 / 2
stop reason:                  FARM_TARGET_COMPLETED
final lifecycle:              BOSS_LOBBY
attempt after target:         absent
controller:                   STOPPED, exit 0
```

Attempt 8 was a correctly excluded
`ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT`: the untouched session had already
advanced to turn 3 with local move sequence 0. Recovery invalidated it and
accepted a distinct pristine opening. Attempt 10 was a proven
`DEAD_BOARD_NO_REFRESH`; the second independent one-shot recovery also returned
to exact Starburst 1289 and accepted a distinct pristine opening. Neither abort
was counted as a completed UNKNOWN.

One transient provider read error occurred during attempt 7. That attempt still
ended in a memory-backed STRONG WIN with boss HP 0 and a consistent `Thắng` UI
audit. DTO rejection, stale skip, ambiguous-latest skip, result conflict and
unexplained UNKNOWN totals were all zero.

All FarmRun critical safety counters were zero: duplicate gameplay/lobby/
recovery/postmatch input, wrong target/turn, opponent-turn input, stale action/
session, gameplay in lobby/postmatch/after stop, result double count and result
conflict. Desktop controller evidence recorded one maximum simultaneous
controller and no duplicate/stale/wrong-run command violation.

## B3 — packaged Graceful Stop

Accepted FarmRun: `f7936c6c94f24c30b693065062202cfb`.

The packaged UI accepted `GRACEFUL_STOP_ACCEPTED` during `ACTIVE_COMBAT` for
match `M_6ff4f689`. The runner completed that one current match as a
STRONG/CONSISTENT WIN, confirmed postmatch, returned to exact `BOSS_LOBBY` and
stopped `STOPPED_GRACEFULLY`. It created no attempt 2 and recorded zero boss
entry after the request. Controller exit was 0 and every FarmRun safety counter
was zero.

Operator-timing retries that reached their finite target before a graceful
command were not used as acceptance evidence. One separate empty run failed
closed at `FOREGROUND_LOST` with zero attempts/input before the accepted run.

## B4 — packaged checkpoint Resume

Partial FarmRun: `6f604d50505d4148abb32e3d457bf614`.

```text
configured target / attempts: 5 / 8
historical completion:        1 WIN
boundary:                     STOPPED_GRACEFULLY / BOSS_LOBBY
checkpoint schema:            pokiguard.farm_checkpoint.v1
canonical validator:          allowed, remaining=4
executable gameplay state:    not persisted
```

The packaged UI closed normally. The same packaged EXE restarted against the
same application-data root, discovered the checkpoint and accepted Resume via
the UI without manual artifact edits.

Continuation FarmRun: `8876e53d4a6948388de421e5a9bd9382`, with
`continuation_of=6f604d50505d4148abb32e3d457bf614`.

```text
final completed / attempts:   5 / 5
WIN / LOSS / UNKNOWN:         5 / 0 / 0
new entries after Resume:     4
unique historical MatchIds:   5
double count / conflict:      0 / 0
extra attempt after target:   absent
stop reason / lifecycle:      FARM_TARGET_COMPLETED / BOSS_LOBBY
```

## B5 — packaged Emergency Stop

FarmRun: `e2c6919c29d4482a8d2f4cc3c9d37585`.

The UI accepted one Emergency Stop during `ACTIVE_COMBAT` for match
`M_020adbf3` at `2026-08-29T15:19:42.793Z`. One lobby entry and one gameplay
operation had started before the ACK. After the ACK:

```text
authorized input operations:  0
gameplay input:                0
boss entry:                    0
postmatch input:               0
recovery input:                0
new match:                     0
fabricated result:             0
controller:                    STOPPED, exit 0
checkpoint:                    non-resumable emergency SAFE_STOP
game lifecycle:                ACTIVE_COMBAT
```

Remaining in combat is expected: Emergency Stop revokes automation authority;
it does not exit or recover the game.

## B6 — final shutdown

The idle packaged UI was closed normally after B5.

```text
controller alive:              0
poller alive:                  0
PokiguardToolV2 process:       0
handled/unhandled UI errors:   0 / 0
game process:                  still running, PID 6968
```

The final UI summary retained the B5 controller as `STOPPED`, exit 0, with
`autonomous_inputs_after_emergency_ack=0`.

## Write-location audit

Pre/post hashes of all critical game files were identical:

```text
Pokiguard.exe        8a157ed48add3ac19e41ab1796338f85badfac3f1d44a9b64b04a7a88d4bf875
GameAssembly.dll     5a993b8aef2371f6053aa46c692592ce32ff8418071e85357541f7fb504d58b3
UnityPlayer.dll      34b546a31b94758666aa814b37c9f0aaabe25909a9c6d23e53ab8ed1d18090a7
global-metadata.dat  c9ec5627aa074066190bcf1e6f1f592a9c7dfd0adcdd2a5b1f4b4b7df5216085
```

```text
game-install runtime writes:          0
source-repository runtime writes:     0
packaged-directory runtime writes:    0
archive mutation:                     0
application-owned runtime writes:     isolated LocalAppData roots only
```

The final archive remains 13,609,921 bytes with the recorded SHA-256. Before
Phase 2F.2 documentation was written, Git status contained exactly the one
pre-existing untracked QTE report in addition to deliberate phase files; its
later preservation did not change the artifact.

## Final validation

```text
focused release tests:  14/14 PASS
full regression:        740/740 PASS
compileall:             PASS
git diff --check:       PASS
```

The artifact contains the same runtime/package code tested live. Phase 2F.2
adds only final documentation and the machine-readable manifest after live
acceptance, so no rebuild is required.

Release manifest: `release/phase2f2_manifest.json`.

## Safety boundary and unsupported scope

The accepted binary remains external/read-only and requests only
`PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`. All gameplay uses normal
foreground Windows input. There are no game-memory writes, injection, hooks,
direct Unity gameplay calls, packet manipulation or game-file modification.

Unsupported remains explicit: REASONING, infinite/unbounded farming,
automatic game launch/restart, login automation, multi-target rotation, memory
writes and network manipulation.

## Git resolution and final conclusion

```text
prior file:         docs/pokiguard_pet_skill_qte_reverse_report.md
content modified:   NO
preservation SHA:   28333381379084d886b7e783bc36174e0f11036c2977bf0f5bfa6a645f35beb8
preservation commit:c2f4242e
release tag:        v1.0.0+15
```

The mandatory Git-hygiene and clean release/tag criteria are satisfied.
Therefore:

```text
Phase 2F.2 result:       PASS STRONG
BASIC SCOPE COMPLETE:   YES
REASONING:              UNDEFINED / UNSUPPORTED
```
