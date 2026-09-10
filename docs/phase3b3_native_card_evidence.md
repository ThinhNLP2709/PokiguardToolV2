# Phase 3B.3 remediation — new CardUI after evolution

## B4 latched flag addendum — 2026-09-10 / v1.0.43

**Confirmed blocker, not insufficient resources.** B4 log
`logs/phase3b3_pet_skill_action_20260910_020559_b4_two_same_match_v1042.jsonl`
records first current PERFECT at 02:12:00.666 ICT, a proven null
`ActiveDotSkillCard` edge at 02:12:01.807, then later ready local turns with
`CURRENT_PET_SKILL_CAPABILITY_MISSING`. At turn 43 (02:12:33.162), authoritative
resources are **360 Mana / 250 Rage**; at turn 49 they are **620 / 250**.
Native refresh keeps returning `suspended_during_skill_execution` and no cards.
That return path is reached only when the current `Board.is_using_legend_card`
read is true. Therefore this flag stayed true beyond the first QTE and cannot
by itself prove that the QTE is still active. The B4 inactive/later-turn gate
did advance; it was discovery that hid the card from the final input preflight.

Read-only native evidence for the installed GameAssembly SHA256
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`:

| Assembly / namespace / type / member | Kind / declared type | Offset or RVA | Evidence / confidence |
|---|---|---|---|
| Assembly-CSharp / global / Board / isUsingLegendCard | instance field / System.Boolean | +0x391 | `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/Board.cs:193`; CONFIRMED |
| Assembly-CSharp / global / CardUI / board | instance field / Board | +0x30 | `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/CardUI.cs:23`; CONFIRMED |
| Assembly-CSharp / global / CardUI / SetLegendMultiplier | instance method / void(float multiplier) | 0x6D0370..0x6D0430 | `CardUI.cs:1131`; CONFIRMED range; native body HIGH |
| Assembly-CSharp / global / CardUI._HandleDotSkillSequence_d__280 / MoveNext | instance method / System.Boolean() | 0x6F4BB0..0x6F6790 | `CardUI.cs:671`; CONFIRMED range; native cleanup HIGH |

`SetLegendMultiplier`: RVA 0x6D03CF loads `CardUI.board` from `[rbx+0x30]`,
0x6D03D8 writes byte `[rax+0x391]=1`. The coroutine's 0x6F5C4E clears its
CardUI active flag at +0x158 and 0x6F5C58 calls HideDotSkillUI (0x6C8E30).
No direct +0x391 access occurs in that coroutine's declared native range;
the only direct +0x391 access found in inspected Board/CardUI method ranges
is the setter above. This does **not** prove no other game type/bulk operation
ever resets the field. Exact full-game reset semantics remain UNKNOWN.

v1.0.43 removes ONLY the fast `refresh_pet_skill_cards` early return based on
this flag. Native hand ownership/Button/CardData validation still occurs on
every discovery. Discovery is not input authority: current inactive QTE,
resource/turn/CardUI/Button/geometry/foreground and B4 readiness gates remain.
No cached old card is substituted, no game flag is written, no new offsets,
full scan, timing change or callback wait. The general board-policy/modal path
is unchanged in this bounded fix; its legacy legend-flag semantics must not be
assumed suitable for future continuous Pet Skill integration without an audit.

## Current 1.7.4-b2 native addendum — 2026-09-07

The historical C67-build values below are superseded for the installed b2
build. Fresh managed declarations now place `Board.cardContainer` at `+0x328`
and `Board.cardsInHand` at `+0x348`. Current runtime-byte validation resolves
the initialized `Component.get_gameObject_Injected` cache through
`GameAssembly + 0x302CEE8` to the same verified UnityPlayer function RVA
`0x1067390`. All 15 Unity native signatures listed by the production reader
match the live module.

The even scripting-handle unmarshal layout is now signature-gated at
`GameAssembly + 0xBB7CF4` by exact bytes
`33 D2 48 8B CB F6 C3 01 74 0A E8 9D C4 AD 00 48 8B D8 EB 08 E8 53 01 82 FF 48 8B 18`.
No native method is invoked. Evidence source:
`reverse/reverse_1.7.4-b2` plus read-only bytes from the exact allowlisted
GameAssembly/UnityPlayer pair. The ownership/roundtrip invariants below remain
unchanged; only build-specific anchors were replaced.

Date: 2026-09-04. Scope: Pokiguard 1.7.4 / redux_compat, external READ ONLY.
Status: native-code evidence + offline regression; corrected full live B1 is
still NOT OBSERVED. No target method was called to resolve these pointers.

## Corrected conclusion

The skill is a NEW CardUI/GameObject created after evolution. It is not the
FusionCardUI displaying different artwork. `cardsInHand` count alone cannot
tell whether Fusion remains visible, is hidden, or changes position. A previous
4-slot baseline cannot authorize clicking the skill at the old Fusion slot.

Six B1 harnesses did not click. Earlier manual QTEs are not full-auto successes:

- `logs/phase3b3_pet_skill_action_20260904_173754.jsonl`
- `logs/phase3b3_pet_skill_action_20260904_180105.jsonl`
- `logs/phase3b3_pet_skill_action_20260904_183955.jsonl`
- `logs/phase3b3_pet_skill_action_20260904_185520.jsonl`
- `logs/phase3b3_pet_skill_action_20260904_210747.jsonl`
- `logs/phase3b3_pet_skill_action_20260904_213919.jsonl`

The first remediation added Board's allocation to a bounded scan. That worked
for ONE allocation arrangement, not all arrangements. The scanner's limited
coverage and three ordinary-owner attempts could miss a new skill wrapper.

During retry 3 (`M_83acee9f`, PID 26456), read-only investigation found BEFORE
manual activation:

| Object | Observed address (historical evidence only) |
|---|---|
| Board | `0x23B72DC0000` |
| Active | `0x23A4FA00A80` |
| MatchService | `0x239D5E90A80` |
| LocalFusionSkillCard / HT7 CardData | `0x23A4F01AF20` |
| Skill CardUI | `0x23B7FC91540` |
| Skill Button | `0x239DAF6CAA0` |
| Native skill GameObject | `0x23A70419E00` |
| Native skill CardUI component | `0x23A08B8AF80` |

The CardUI had exact class, Board, Active, native pointer, CardData and Button.
HT7 data was id 7 / `ATTACK_LEGEND_`, conditionUse=200, power=200. CardUI was
in a 69,632-byte committed region at `0x23B7FC83000`, AllocationBase
`0x23B7F870000`, outside the chosen Board/GameObject anchor regions. This
proves a discovery miss, not that the card did not exist or required activation.
All addresses became stale after combat and must NEVER be used for input.

In the same observation five separate native RectTransforms had increasing
anchored X, approximately 44.965, 94.965, 144.965, 194.965, 244.965. That
contradicts assuming a fixed four-slot replacement layout. These coordinates
alone were diagnostic, not click authority.

## Game-owned creation evidence

Assembly `Assembly-CSharp`, global namespace, instance methods on `Board`.
Source: `reverse/redux_compat/cs/Assembly-CSharp/Board.cs` plus disassembly of
the corresponding RVA in the installed, read-only `D:/pc/GameAssembly.dll`.
Confidence: HIGH, build-specific.

| Member | Exact kind/type | Offset or RVA | Native evidence |
|---|---|---|---|
| cardPrefab | instance `UnityEngine.GameObject` field | `+0x2F8` | used by AddFusionSkillCard |
| cardContainer | instance `UnityEngine.Transform` field | `+0x300` | parent passed to Instantiate |
| selectedCards | instance `List<CardData>` field | `+0x318` | ordinary selected data, not skill position |
| cardsInHand | instance `List<GameObject>` field | `+0x320` | owns newly instantiated skill GO |
| AddFusionSkillCard | instance method | `0x57E520` | Instantiate at `57E65C..57E671`; FindWiredSkillCardUI/AdoptSharedSkillRefs at `57E7F9..57E811`; SetCardData at `57E816..57E81F`; List.Add at `57E824..57E83A` |
| EnsureFusionCards | instance method | `0x5890C0` | if MatchService+78 exists, calls AddFusionSkillCard at `589523..589534` |
| RemoveFusionCard | instance method | `0x592470` | separate List.Remove + Destroy; not called by AddFusionSkillCard |

`CardUI.cs`: `cardData +0x20`, `btn +0x28`, `board +0x30`, `active +0x38`;
`SetCardData` RVA `0x5BA2B0`, `AdoptSharedSkillRefs` RVA `0x5AF180`.
`FusionCardUI.cs` is a distinct component; its existence is not skill identity.

## Native Unity ownership: verified, not managed Cpp2IL offsets

UnityPlayer SHA-256:
`bb93aa060395c4ace3561b4ceafe06cfaebd5dfb883c451058b9ccb74b50b6d2`.
The reader gates these accesses on exact machine-code signatures. A signature
mismatch stops the native path; it does not try nearby offsets.

The named managed bindings below are in
`reverse/redux_compat/cs/UnityEngine.CoreModule/UnityEngine/`.
Their GameAssembly injected stubs resolve native internal calls. The initialized
Component.get_gameObject cache at GA+`0x2E6C1F8` pointed to UnityPlayer+
`0x1067390`. Other inspected stubs corroborated the same runtime module base.
No absolute runtime module address is stored in production.

| Native fact | Native offset/shape | Evidence RVA in UnityPlayer | Confidence |
|---|---|---|---|
| Component owner GO | component `+0x28` | `1067396: mov rbx,[rcx+28]` (Component.get_gameObject) | HIGH |
| GO components | storage `+0x28`, count `+0x38`, 16-byte entries, native pointer at entry+8 | `1068897..10688D2` (GameObject.GetComponentFastPath) | HIGH |
| GO Transform | first component | `1069C46..1069C54` (GameObject.get_transform) | HIGH |
| Native scripting handle | native object `+0x20` | `10688D2`; managed conversion below | HIGH |
| activeInHierarchy cached state | GO `+0x4F`; 0=false, 1=true; FF needs engine recomputation | `179BE86..179BE93` via get_activeInHierarchy | HIGH |
| Transform parent | native transform `+0x70` | `1440E2E` (GetSiblingIndex) | HIGH |
| Parent's children | array `+0x50`, count int32 `+0x60`, pointer stride 8 | `1440E4E..1440E75` | HIGH |
| Cached RectTransform rect | float4 `+0xC0`; dirty flag `+0xF9` | `1078CAD..1078CD5` (get_rect) | HIGH |
| Transform access handle | `+0x40` -> `{data*, index:int32}` | `1078FA0..1078FEA` (get_localPosition) | HIGH |
| Local TRS | data+20 -> array, index*48; position +0, quaternion +10, scale +20 | `1078FD8..1079004`, `107922E`, `107934E` | HIGH |
| Pending transform job | data+0 non-null requires engine wait; reader rejects it | `1078FA7..1078FD5` | HIGH |
| Root Canvas mode | native Canvas+38; parent Canvas+308 | `B5AB16..B5AB56`; Canvas.cs in UnityEngine.UIModule | HIGH |

GameAssembly `UnmarshalUnityObject<T>` RVA `0xA3DA70` tests handle bit 0:
even = read the pointed-to managed object (`A3DAA8..A3DAB0`); odd = another
resolver. The external reader implements ONLY the observed even form and
validates `managed+0x10 == original native`. It never invokes the odd-handle
resolver or creates missing managed wrappers.

Read-only runtime verification succeeded for this handle roundtrip on current
native Unity objects, and all compiled signature checks passed. The active
root Canvas probe returned rectangle `(0,0,1,1)`, aspect 2.0; cold probe time
was 53.56 ms. This is NOT a full combat-hand latency benchmark or live B1 pass.

## Retry 4: actual combat Canvas boundary (fixed)

The latest log (`210747`, `M_bfb931a0`) rejected the hand with
`native_card_ui: non-RectTransform geometry`, before the user's manual skill.
Direct read-only trace showed this hierarchy, from current skill to scene:

```text
RectTransform 0x2385BD77200  skill
  -> 0x23A08748700          Board.cardContainer
  -> 0x23A00D97500
  -> 0x23A00D9C700          nested Canvas 0x2385ADFA400
  -> 0x23A00D9F200
  -> 0x23A00D98300          ROOT Canvas 0x2385ADF9C00
  -> 0x23A0AC99A80          plain UnityEngine.Transform (scene parent)
```

Nested Canvas raw mode is 2, but its `+0x308` points to the root Canvas.
The root's `+0x308` is NULL and mode is 1. Native `Canvas.get_renderMode`
at UnityPlayer+`0xB631F0` follows parent Canvas links to the effective root.
Thus neither the nested raw mode nor the root's non-NULL Transform parent
justifies rejecting this screen-space hierarchy. The old NULL-Transform-parent
assumption was wrong. Reader now stops at the root Canvas, before scene parent
or camera/world TRS. Root rect was
`(-448.0903015,-224.0451508,896.1806030,448.0903015)` (aspect 2.0).

After correction, one direct read of all five live card rectangles completed
in 177.02 ms (cold sample, not a broad performance guarantee). HT7 CardUI
`0x23B7F915540`, Button `0x23B8087DEE0`, id 7 / ATTACK_LEGEND_, exact current
Board/Active/native ownership all validated. Its normalized viewport rect was
`(0.5865379147,0.7698431177,0.6432758262,0.9173616877)`; the other four
rectangles were distinct and adjacent. All five GOs were active; this includes
Fusion, so no replacement-slot assumption is valid here either.

All addresses/rectangles above are historical diagnostic samples only, never
runtime constants. The Button was non-interactable after manual activation;
no input was authorized or sent by the probe. The subsequent production shadow
probe ran after the match-end flag; provider returned `local_match_end_flag`
without entering native discovery. A new pre-activation combat test is still
required. Regression fixture reconstructs these six RectTransform levels,
nested/root Canvas and plain scene parent with synthetic addresses.

## Implemented boundary

`Board.cardsInHand -> exact GO -> components -> even scripting handle ->`
`managed CardUI -> existing class/Board/Active/CardData/Button validator`.

- Max 16 owned cards / 64 components per object / 16 ancestors, no RAM-region
  scanner for the post-Fusion skill. Previous ordinary-card scan attempts do
  not exhaust this direct path.
- All hand GOs must be children of CURRENT Board.cardContainer. Component/GO
  and managed/native links are checked both ways. The exact Button must belong
  to the same GO as the exact CardUI.
- Visibility uses activeInHierarchy, not list count or FusionUsed alone.
- Card rectangles are projected through current axis-aligned local TRS to
  the root RectTransform. Root must contain one screen-space Canvas, and its
  aspect must match the accepted current gameplay viewport. World-space,
  rotated, dirty, job-pending, overlapping or changing layouts fail closed.
- Slots are diagnostic order of current non-overlapping rectangles. Skill click
  is computed INSIDE its actual rectangle, never from slot index/card ID.
- Final preflight repeats ownership, CardUI/Button usability and geometry;
  screenshot is only the existing foreground tile sanity check, not discovery.
- Native geometry work is suspended while Board reports a skill in execution;
  the accepted QTE direction/Perfect loop does not need card geometry then.
- Ordinary first-turn Board/solver priority and no-Pet-Skill BASIC policy remain.

## Remaining live validation

Retry 5 (`M_cf7e3c5a`, game PID 26436) additionally proved production CURRENT
HT7 discovery, Button interactability and geometry BEFORE activation. It did
not click because geometry/capture exceeded the existing 350 ms sample-age
guard. Read-only profiling and the latency correction are documented in the
[phase report](phase3b3_report.md). Common Canvas paths now live only for one
hand read; all existing geometry fences are retained and paths cleared on the
next read. No new field offset, RVA or absolute pointer was introduced.

The corrected reader resolves the post-evolution hand; still need automatic B1:
exact card click -> fresh QTE -> all directions -> one Space -> correlated
PERFECT -> fresh post-state. Until then B1/B2/B3/B4 remain pending, and no
PASS/PASS STRONG, commit, release or packaging claim is authorized.

## Retry 10 — intermittent Transform job fence (2026-09-05)

Log `phase3b3_pet_skill_action_20260905_003531.jsonl`: exact HT7 discovered,
760 Mana / 250 Rage, but final geometry preflight returned no proof and zero
input. The old action event omitted the underlying geometry exception; exact
final cause is UNKNOWN. Earlier rows repeatedly show geometry busy/read changes.

Read-only probe on current combat hand: first 12/12 reads succeeded; next
48 reads had 42 success / 6 rejections (2 pending jobs, 1 read change, 3 walk
changes). Captured changes were at shared Transform data+0, e.g. zero ->
`0x0000321300000705` -> later zero. These are historical opaque job values,
not runtime pointers/constants. The same native getter evidence above at
UnityPlayer 0x1078FA7..0x1078FD5 checks/waits on that field; external reads
must reject a busy sample, never wait by calling the engine.

Reader now raises a typed transient error for dirty/busy/changing geometry.
Invalid Transform index and invalid ownership/layout remain non-transient.
The action geometry boundary permits one full fresh reread (max 2 reads),
retaining every fence and the original 350 ms total sample-age guard. Slots
are read from the new validated hand, not required from a prior provider poll.
New log fields retain attempt count and actual final reason. No native offset
or RVA changed, and no unknown geometry is used for input. Tests **101/101
focused, 1017/1017 full PASS**. Post-fix read-only check found no current Board;
live accepted card/QTE/full result on this retry path remains pending.
