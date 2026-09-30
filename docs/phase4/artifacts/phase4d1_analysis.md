# Phase 4D.1 — Foreground vs Pinned Foreground Beta A/B

Result: **PASS_STRONG**

| Metric | A foreground | B pinned foreground Beta |
|---|---:|---:|
| FarmRunId | a32e8eb15136456ca9231cb29934e3da | ee17b4a58a14430ba1d394620edb7d26 |
| Completed | 5 | 5 |
| Attempts | 5 | 5 |
| W/L/U | 5/0/0 | 5/0/0 |
| Technical recoveries | 0 | 0 |
| Critical counter total | 0 | 0 |
| Focus takeovers | 0 | 35 |
| Mouse lease duration total (s) | 0.0 | 85.686 |
| QTE lease duration total (s) | 0.0 | 27.327 |
| Final lifecycle | BOSS_LOBBY | BOSS_LOBBY |

## Input/ACK by domain

| Domain | A sent/ACK/unconfirmed | B sent/ACK/unconfirmed |
|---|---:|---:|
| BOSS_ENTRY | 5/5/0 | 5/5/0 |
| GAMEPLAY_PET_SKILL | 5/5/0 | 5/5/0 |
| GAMEPLAY_SWAP | 33/33/0 | 27/27/0 |
| POSTMATCH_CONFIRM | 5/5/0 | 5/5/0 |

## Acceptance failures

- None
