# Phase 3D.1-R1 Runbook — Generic Pet-Skill Fire Condition

## Fixed source and operator boundary

Use source version `v1.0.49` through `run_tool.bat` and the normal Desktop UI.
The user owns all game and Desktop UI interaction. Do not provide manual combat
input or change policy, input timing or QTE behavior between benchmark blocks.

Use Starburst `1289` from its proven `BOSS_LOBBY`. The revised offline gate is
green: Skill Rush policy 63/63 and final full regression 1,354/1,354. The historical
randomized-input suite remains 18/18 in five consecutive runs.

This runbook is complete. Accepted refreshed blocks are Mode A FarmRun
`fb3fddffb1f14442b31f92c473edc56e` (10/10 WIN) and Mode B FarmRun
`ee83bac8f35241c7a08afdff048632e2` (10/10 WIN, 10/10 PERFECT immediate
skill kills). The canonical manifest and generated JSON/Markdown analysis are
under `docs/artifacts/phase3d1_r1_*`.

## Accepted R1 live block

The existing FarmRun `401e5153c44b437f8abc3698b383c981` is accepted as 5/5
and is not repeated. It proves the route and QTE historically, but its strict
threshold does not prove the current inclusive exact-10 boundary:

| Setting | Value |
|---|---|
| Lối chơi | `Chịu đấm ăn xôi` |
| Pet của tôi | `Huyền thoại` |
| Tiến hóa | `Không tiến hóa` |
| Thẻ sát thương | `Thẻ skill của pet` |
| Điều kiện ra skill | `Kiếm đủ` |
| Giá trị | `10` |
| Semantics | inclusive current known effective Sword value `>= 10`; x1–x4 count |
| Audition | `V3` |
| Board input | `Two Click` |

All five first skills fired at Sword 11 with valid resources and PERFECT QTE.

## Block 2 — refreshed Mode A

Proceed only after the user has opened Starburst `1289` boss lobby. Close any
previous tool session, open the same checkout and select:

| Setting | Value |
|---|---|
| Lối chơi | `simple` |
| Độ thông minh | `BASIC` |
| Pet của tôi | `Pet thường` |
| Tiến hóa | `Tiến hóa pet thường` |
| Thẻ sát thương | `Thẻ chưởng mặc định` |
| Board input | `Two Click` |
| Target matches | `10` |
| Max attempts | `15` |

`Điều kiện ra skill`, Audition and Audition help must be hidden. Their saved Pet
Skill values require no operator input and have zero effect on Mode A. Start
once and finish exactly ten valid matches. Mode A must record zero Pet Skill and
zero `SKILL_RUSH_*` branch leakage.

## Block 3 — refreshed Mode B

After Mode A passes, close and reopen the tool from the same source and boss:

| Setting | Value |
|---|---|
| Lối chơi | `Chịu đấm ăn xôi` |
| Độ thông minh | `BASIC` |
| Pet của tôi | `Huyền thoại` |
| Tiến hóa | `Không tiến hóa` |
| Thẻ sát thương | `Thẻ skill của pet` |
| Điều kiện ra skill | `Kiếm đủ` |
| Giá trị | `10` |
| Audition | `V3` |
| Board input | `Two Click` |
| Target matches | `10` |
| Max attempts | `15` |

Every normal Pet Skill must satisfy runtime costs and current known effective
Sword value `>= 10`; every accepted QTE must be PERFECT. Evolve and pre-first-skill Attack
stay zero. Intentional strategic Sword consumption before the first skill stays
zero. The accepted post-skill finisher is allowed only on a later local turn
when fresh boss HP ratio is `<=30%`. End at exactly ten completed matches in
a proven boss lobby with a stopped controller.

Every selected pre-first-skill SWAP must record `knownSwordConsumed=0`, at every
Rage value. During resource collection, safe missing Mana/Rage progress is
preferred. If no safe progress exists and player HP is above 30%, select the
best Sword-preserving missing-resource move even when `safe=false`; this
Mana/Rage objective precedes Drain, Shield and turnover. If no missing-resource
move exists, use Drain, Shield and turnover in that order. At or below 30%, or
when HP is unknown, safe Shield/Health survival may precede unsafe resource
progress. If PASS is used, it must come from
authoritative idle and remain within the two-pass budget. When idle is
`PASS_FORBIDDEN_MANDATORY_ACTION`, the selected move must remain non-Sword and
minimize reply risk. `SKILL_RUSH_ONLY_SWORD_MOVES` is a valid fail-closed stop
if every legal move consumes Sword; it is not an accepted completed match.

For count-based setup, `SwordRisk.safe` remains a hard boundary whenever a safe
preserving action exists, and the selected move must also preserve the
configured condition GemType. When no safe preserving setup move exists, an authoritative
`SKILL_RUSH_SETUP_PASS` is expected while allowed; the mandatory fallback must
remain non-Sword and preserve the condition gem. A fail-closed
`SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES` is not an accepted completed match.

Do not replace the canonical Mode B condition with one of the five optional
conditions. Their deterministic offline coverage is sufficient.

## Offline analysis

Record FarmRun IDs in `docs/artifacts/phase3d1_r1_manifest.json` in this order:
`R1_REMEDIATION`, `A_DEFAULT`, `B_PET_SKILL`. The canonical Mode-B spec records:

```text
pet_skill_fire_condition = sword_count
pet_skill_fire_value = 10
pet_skill_fire_semantics = known_gem_effective_count >= pet_skill_fire_value
```

Run:

```powershell
$env:PYTHONPATH = "src"
python tools/phase3d1_r1_benchmark.py `
  --manifest docs/artifacts/phase3d1_r1_manifest.json `
  --logs-root logs/farm_runs `
  --output docs/artifacts/phase3d1_r1_analysis.json `
  --markdown-output docs/artifacts/phase3d1_r1_analysis.md
```

Historical R1 Sword fields may be read as derived compatibility metadata. New
manifest/config identity is generic. Do not modify or pool historical
`docs/artifacts/phase3d1_*` datasets.

## Final verification and closeout

Both live blocks and refreshed artifacts passed. The final closeout commands are:

```powershell
$env:PYTHONPATH = "src"
python -m unittest tests.test_phase3d1_r1_benchmark tests.test_phase3c3_skill_rush_policy tests.test_phase3d1_benchmark -v
python -m unittest discover -s tests -v
1..5 | ForEach-Object { python -m unittest tests.test_win32_input -v }
python -m compileall -q src tools tests
git diff --check
```

Stage only R1-owned code, tests, docs and refreshed artifacts. Preserve the
unrelated user-owned files listed in `AGENTS.md` and the report. Commit and push
once, verify `HEAD == origin/main`, then stop. Do not start Phase 3D.2, run the
25-match soak, package or tag.
