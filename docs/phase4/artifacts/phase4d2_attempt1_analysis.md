# Phase 4D.2 — Pinned Foreground Reliability Soak

Result: **FAIL**

- FarmRunId: `ae93a3c6e18942898af20790a12685db`
- Mode: `pinned_foreground_lease_beta`
- Completed/attempts: `25/25`
- W/L/U: `25/0/0`
- Final: `FARM_TARGET_COMPLETED` / `BOSS_LOBBY`
- Focus takeovers: `222`; QTE: `26`
- Natural recovery: `NOT_OBSERVED`; map re-entry `0`; technical `0`

## Per-match evidence

| # | Result | Turns local/boss | Swap sent/ACK | Skill PERFECT | Mouse/QTE lease | Focus takeover |
|---:|---|---:|---:|---:|---:|---:|
| 1 | WIN | 4/3 | 3/3 | 1 | 3/1 | 4 |
| 2 | WIN | 7/6 | 6/6 | 1 | 6/1 | 7 |
| 3 | WIN | 6/5 | 5/5 | 1 | 5/1 | 6 |
| 4 | WIN | 10/9 | 9/9 | 1 | 9/1 | 10 |
| 5 | WIN | 5/4 | 4/4 | 1 | 4/1 | 5 |
| 6 | WIN | 5/4 | 4/4 | 1 | 4/1 | 5 |
| 7 | WIN | 6/5 | 5/5 | 1 | 5/1 | 6 |
| 8 | WIN | 7/6 | 6/6 | 1 | 6/1 | 7 |
| 9 | WIN | 10/9 | 9/9 | 1 | 9/1 | 10 |
| 10 | WIN | 7/6 | 6/6 | 1 | 6/1 | 7 |
| 11 | WIN | 9/8 | 8/8 | 1 | 8/1 | 9 |
| 12 | WIN | 9/8 | 8/8 | 1 | 8/1 | 9 |
| 13 | WIN | 8/7 | 7/7 | 1 | 7/1 | 8 |
| 14 | WIN | 9/8 | 7/7 | 1 | 7/2 | 9 |
| 15 | WIN | 8/7 | 7/7 | 1 | 7/1 | 8 |
| 16 | WIN | 6/5 | 5/5 | 1 | 5/1 | 6 |
| 17 | WIN | 6/5 | 5/5 | 1 | 5/1 | 6 |
| 18 | WIN | 5/4 | 4/4 | 1 | 4/1 | 5 |
| 19 | WIN | 5/4 | 4/4 | 1 | 4/1 | 5 |
| 20 | WIN | 7/6 | 6/6 | 1 | 6/1 | 7 |
| 21 | WIN | 8/7 | 7/7 | 1 | 7/1 | 8 |
| 22 | WIN | 6/5 | 5/5 | 1 | 5/1 | 6 |
| 23 | WIN | 8/7 | 7/7 | 1 | 7/1 | 8 |
| 24 | WIN | 7/6 | 6/6 | 1 | 6/1 | 7 |
| 25 | WIN | 5/4 | 4/4 | 1 | 4/1 | 5 |

## Input/ACK by domain

| Domain | Sent | ACK | Unconfirmed |
|---|---:|---:|---:|
| BOSS_ENTRY | 25 | 25 | 0 |
| GAMEPLAY_PET_SKILL | 26 | 25 | 1 |
| GAMEPLAY_SWAP | 147 | 147 | 0 |
| POSTMATCH_CONFIRM | 25 | 25 | 0 |

## Acceptance failures

- configured maximum attempts differs from manifest
- critical combat counter is non-zero
- sent input lacks authoritative ACK
