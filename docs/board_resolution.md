# Board instance resolution — Phase 1

## Current b12 compatibility — 2026-10-26

The b12 profile atomically replaces the b10 fingerprint,39 TypeInfo RVAs and
the Component.gameObject cache/unmarshal anchor.257 production field
candidates, co-op/dispatcher nested layouts,28 library layouts and17 native
UnityPlayer signatures match the previous contract. No solver, controller,
input pacing, QTE, ACK, random settings or gameplay flow was changed.
[Migration evidence](artifacts/game_1_7_4_b12_20261026/constant_migration.json).

Board geometry received a separate native review. Existing MatchHudV2
constants are equal to b10; additions concern affix/team HUD widgets.
MatchHudV2.SolveBoard `0x5FDC80..0x5FDD60` and
Board.GetCellBaseWorldPosition `0x13828B0..0x1382C90` match the preserved
1.7.4.9 instruction sequences after relocation normalization,52/215
instructions respectively, including floating constants/internal branches.
This is narrower than whole MatchHudV2.Layout equivalence: Layout gained
HUD elements, so current pixel mapping still needs an actual b12 combat frame
and an acknowledged swap. Historical64centres/112swaps/four-profile fixtures
are not new live acceptance. Keep calibration and configured centre jitter;
no verified evidence justifies changing gem pitch or random bounds.
[Geometry review](artifacts/game_1_7_4_b12_20261026/geometry_evidence.json).

Readonly desktop status recognized Lieyun77 host room on b12 in3consistent
samples. The exact manager-owned Start button passed native ownership and
active checks; its live normalized rect was
`(0.7162037,0.8351852,0.9106481,0.9037037)`, root aspect2.0,
interactable/groupsAllow true. This rect is evidence only, never a new fixed
click coordinate. No screenshot/input/game method call was performed.
[Readonly evidence](artifacts/game_1_7_4_b12_20261026/readonly_status.json).
Combat board/ACK, card/QTE, result/return, health popup and re-entry remain
NOT_OBSERVED in this migration. [Full report](petpuzzle_b12_compatibility_report.md).

## b10 x2 audit — 2026-10-22

Multiplier field layouts remain Dot+0x88/BoardCellDTO+0x20. Actual logged
M_86c91873/turn7 contains Swordx2; pure replay computes3physical/4effective for
two Health triggers. Source9fa67d8… BASIC filters physical count>=4, explaining
its SETUP choice. This is an eligibility-rule issue, not evidence of a changed
reader field. [Audit and limits](multiplier_b10_review_20261022.md).
User-authorized BASIC fix now uses weighted Sword totals with a2-cell floor;
[159 offline tests PASS](demon_effective_sword_fix_20261022.md). Reader unchanged.

## Current b10 compatibility — 2026-10-22

Source now resolves Board/Active/MatchService and supporting roots through
b10 TypeInfo values; GameAssembly SHA256
`9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777`.
256 mapped read-field candidates keep their1.7.4.9 offsets. The native Unity
ownership bridge cache moved to0x3F72288, unmarshal proof to0x191413F;
all15 UnityPlayer layout signatures stay valid. Ordinary provider, solver,
lifecycle,ACK,QTE,Stop and action ordering are byte-exact to the pre-b10 source.

Board input mapping and +-10% centre jitter are unchanged. Existing tests
cover64 centres/112swaps/four size profiles against the original1.7.4.9 frame;
these are historical fixtures, not live b10 board-coordinate evidence.
The b10 ChinhPhucArenaHud changes concern map badge/title/sweep placement;
no board-geometry change is inferred from those field names alone.

Readonly attachment recognized a guest ChinhPhuc room (Pharapo432) and verified
the native bridge without input. Board/swaps/result/return/re-entry still
require bounded B1/B2 live acceptance; unseen skill/QTE paths stay unclaimed.
No E1 request/claim was created and no old timing calibration is rebound.
See [b10 report](petpuzzle_b10_compatibility_report.md).


## 1.7.4.9 board-to-input calibration correction — 2026-10-21

Live B1 `e84738476d4e4b88a15bc5fcfa5d4f89`, match `M_51626dbc`, exposed a
missed compatibility boundary: board **identity/content** resolved correctly,
but normal input still used b6's approximately 50.25 px grid. Policy selected
SWAP `(screen row 0,col 1)->(1,1)`, not PASS. Saved click `(520,96)` landed in
row 1 of the new grid; no response/ACK arrived for that turn. The operator
subsequently stopped with F9. This is not evidence of a solver PASS or crash.

Verified native 1.7.4.9 layout:

- `MatchHudV2.Build` RVA `0x59EFA0` saves `_S0 +0xD0` from board rect width
  times absolute local scale; sets Board frame gap `+0xC8` to 2.
- `MatchHudV2.Layout` RVA `0x5A3590` recomputes size/position; it uses an
  `S0*1.17` cap and available-space constraints. There is no universal literal
  "60 screen pixels" in the reverse metadata.
- `Board.ComputeEvenGridCellLayout` RVA `0x12D96B0` divides the grid **content**
  rectangle width/height by Board width/height (both 8), after frame/padding.
- `Board.GetCellBaseWorldPosition` RVA `0x12DB830`, even-grid branch
  `0x12DBA71..0x12DBAA4`, uses `origin+(col+0.5,row+0.5)*cell`, then transforms
  from local space. Runtime row increases upward; provider still flips once.

The original 1280x640 **client-only** opening capture establishes the pixel
conversion: first screen-cell centre approximately `(430.5,59.5)`, pitch
approximately `59.75 px` in both axes. Independent annotations of all eight
rows/columns have 2 px raster tolerance. These are measured pixel calibration
values, not guessed native offsets or native world-unit sizes. The retired
Board's cached local pitch `40.6529274` is forensic supporting evidence only:
its native object is destroyed, so it cannot authorize current input.

Production calibration/default BoardCalibration now share those values,
normalized by `1279/639` for the existing `(client dimension-1)` input formula.
The production controller fallback refers to the same defaults. Supported
window profiles all preserve 2:1 aspect. No extra memory read, capture, polling,
game call or input gesture was added. Endpoint jitter is independently bounded
to **±10% of each cell width/height**, approximately ±5.975 px at 1280x640.
Actual live acceptance after correction remains pending.

Evidence and test logs:
[mapping correction](artifacts/game_1_7_4_9_20261020/board_mapping_fix_20261021/),
[original frame/annotations](../tests/fixtures/petpuzzle_1_7_4_9/combat_geometry.json).

## 1.7.4.9 build boundary — 2026-10-20/21

Current read-only profile now targets GameAssembly SHA-256
`4A8925CEBBCC9004A4954DAD8F04CADF01CF759FF418F84528053552E0CF156B`.
Board/Active TypeInfo RVAs are `0x03D5E848 / 0x03D5E850`. Native getter
still proves `Il2CppClass.static_fields +0x98`; Board static instance offset
and consumed Board/Active instance fields are unchanged in the new export.

MatchService ownership/ACK fields moved: Players `+0x118`, localSeq `+0x120`,
pending/in-flight/ackedSeqs `+0x210/+0x218/+0x220`, current player `+0x48`,
turn/timer `+0x50/+0x1A0`, matchOver `+0x253`. ChatMessageDTO identity and
preparsed board are now type `+0x40`, MatchId `+0x100`, preBoard/ready
`+0x4A8/+0x4B0`. Dispatcher message closure is now 321_0, not b6's 291_0.

Opening/DTO/native ownership, canonical board validation and ACK requirements
are unchanged; no new heap scan, poll/capture sequence or direct game method
was added. Component icall cache/unmarshal were migrated and passed bounded
readonly native signature verification on PID 14892. No Board instance was
present outside combat, so this is not evidence of a live 64-cell board.

Historical b6 live acceptance and Phase 5 calibration do not grant authority
on this binary. See [compatibility report](petpuzzle_1_7_4_9_compatibility_report.md)
for independent B1/B2 and remaining unknowns.

## First-turn native opening fallback — 2026-10-04

Run `f3e21495f84245b38e8e7d25a9e3a0a9` proved that a clean entry could bind
the new Board session while the short-lived `MATCH_START` Newtonsoft object
was still absent from the bounded transport scan. The provider stayed in
`awaiting_match_start_opening_dto` for more than 20 seconds, emitted zero
gameplay inputs, and therefore let the server consume the first turn. This was
an entry handoff delay, not a BASIC/Demon/Mega policy `PASS` decision.

`MATCH_START` remains the preferred opening source. During the pristine local
opening only, the provider may now fall back to its already verified bounded
`Board.allDots -> GameObject.components -> Dot.PoolTag` reader when all of the
following remain true: current session and local turn 0/1, local move sequence
zero, no previous move, exactly one idle `BoardWsApplier` owner, 64 unique
Dots, no pending/in-flight batch, Board ready with no cascade/UI processing,
and an unchanged `MatchService._ackedSeqs` set across the complete read. The
entry gate requires two stable provider confirmations, a complete valid board,
more than four seconds on the authoritative turn timer, and the exact
ACK-attested native source before gameplay handoff. If any proof is absent,
the provider still returns to the transport sampler and sends no input; broad
ACK heap scanning remains excluded from this opening window.

## B4 board-cell coordinates versus card click pixels — 2026-09-22

`MATCH_MOVE_REQ` carries integer board-cell coordinates (`fromCol/fromRow`,
`toCol/toRow`); it is not evidence of screen-pixel click logging. Ordinary
card-use transport carries `cardId` and optional `cardTarget`. Skill target
hints may contain `row`, `col`, `isOn`, and final skill requests may contain
`selectedRows`/`selectedDots`; these describe gameplay targets. No screen-pixel
click payload was found in the inspected card handlers/builders. Backend
retention and other collection paths remain **UNKNOWN**.

Evidence: [card input/transport audit](card_click_b4_transport.md). This finding
does not alter board ownership, reader behavior, or input execution.

## QTE / Audition V3 b4 input-state boundary — 2026-09-22

Static native audit confirms that direction progress is evaluated in the client
while accepted direction strings are accumulated in the host's `qtePresses`
(`CardUI +0x498`, `CardUIPVP +0x158`, recording cap 64). AuditionStage's
`PressCallback +0x28` is bound to that host recording method. The skill
coroutine later copies the list into `MATCH_SKILL_USE_REQ`; local progress
must therefore not be interpreted as evidence that the server receives no
direction data.

For V3, `TapCallback +0x30` records host timing and conditionally emits a
separate `MATCH_QTE_TAP`. Local grade/progress alone does not prove server
acceptance or the resulting combat state. The reverse proves the outgoing
data path, while backend validation remains **UNKNOWN**. This audit adds no
memory provider, input automation, or new runtime ownership assumption.

Evidence: [QTE input transport report](audition_qte_b4_input_transport.md),
b4 declarations, `il2cpp.h` interface slots, and hash-matched native bodies.

## Pokiguard 1.7.4-b4 default-board addendum — 2026-09-14

The ownership model is unchanged, but every TypeInfo root moved:

```text
GameAssembly.base + 0x33558A0 -> Board Il2CppClass -> static_fields +0x10 -> Board*
GameAssembly.base + 0x3355698 -> Active Il2CppClass -> static_fields +0x00 -> Active* -> board +0x38
GameAssembly.base + 0x3350170 -> ManagerMatch Il2CppClass -> static_fields +0x00 -> ManagerMatch* -> active +0x130 -> board +0x38
```

`Board` and the default combat/transport fields retain their b3 offsets. `Dot`
adds two input fields at `+0xF0/+0xF4`; the stable rendered-board tail is now
`_squashing +0xFC`, `PoolTag +0x100`, and `RenderHidden +0x131`. The earlier
motion fields remain `_isFalling +0xB0` and `isPredictionSwap +0xE0`.
`BoardWsApplier.SpawnDotByTag` RVA `0x00360350` reaches the `PoolTag` setter at
RVA `0x002B4AF0`, whose exact native store is `[Dot+0x100]`.

The native ownership bridge uses the b4 GameAssembly cache at `+0x355F678`;
the resolved Unity function remains `UnityPlayer+0x1067390` because the
UnityPlayer hash did not change. Full evidence is in
[pokiguard_1.7.4_b4_compatibility_report.md](pokiguard_1.7.4_b4_compatibility_report.md).
A zero-input lobby probe resolved the b4 Board/Active/Manager/provider class
roots without read errors. Their instances were correctly null in
`LOBBY_OTHER`. Live match `M_91a4747a` subsequently accepted three complete
Board-owned 64-Dot reads, retained 64 cached Dot objects, and recorded zero
native-board rejection. This confirms the b4 Dot mapping.

That attempt still missed the immutable opening because entry did not start
the 1 ms dispatcher sampler until gameplay handoff. Entry now arms the sampler
immediately before Start in a bounded new-match mode. Only a complete raw
MATCH_START with a nonempty MatchId different from the lobby baseline may be
retained; a compacted raw board may recover only through the same callback's
class-checked `ChatMessageDTO.preBoard`. The snapshot is accepted only after
the real Board session binds to the same MatchId. The first-turn and source
requirements remain unchanged.

Post-repair match `M_64611df6` retained MATCH_START before Board construction,
accepted its exact 64 cells at local sequence 0 with 14 seconds remaining, and
used it for an acknowledged turn-1 SWAP. Across the full winning match, native
`Board.allDots` fallback accepted 18/18 complete reads with zero rejection.
The run returned to `BOSS_LOBBY` with no provider read, DTO, stale, ambiguous or
sequence-desync error. Artifact:
`logs/b4_compatibility/20260914_011130_basic_live_retest/a6d3f398cd0b4cb4bb009ead46d83601/`.

## Cân Đẩu Vân 1.7.4-b3 state authority — 2026-09-13

The mini game's declared state is `CanDauVanPanel._state +0x188` ->
`CanDauVanState.player +0x48` -> `CanDauVanPlayer.pos +0x28` and
`rollSeq +0x2C`. This is a separate declared state model from the match-3
`Board.allDots` model. Live root resolution and instance lifetime remain
**UNKNOWN**; no reader or automation adapter was implemented.

The native roll flow sends the current sequence through
`CanDauVanApi.Roll`, receives `CanDauVanRollResult`, then reads `dice +0x20`,
`toPos +0x30` and `path +0x38` to render movement. `TryPlay` waits for both
`_diceDone +0x1B1` and `_pendingRoll +0x1B8`. `CanDauVanState.ApplyRoll`
copies the returned destination into player position. If the response path is
missing, the UI builds an animation path between the returned endpoints.

Conclusion: **HIGH confidence that the server supplies the effective roll
result**. Client animation completion does not select the result. Backend RNG
and fairness are **UNKNOWN**. Evidence and exact RVAs are recorded in
[can_dau_van_roll_authority.md](can_dau_van_roll_authority.md) and
[the native audit](../reference/can_dau_van_1.7.4_b3_native.txt).

## Current 1.7.4-b2 addendum — 2026-09-07

The ownership strategy is unchanged, but current build anchors must be used:

1. `GameAssembly.base + 0x2DA5890 -> Board Il2CppClass -> static_fields +0x10 -> Board*`;
2. `GameAssembly.base + 0x2D96E60 -> Active Il2CppClass -> static_fields +0x00 -> Active* -> board +0x38`;
3. `GameAssembly.base + 0x2D947D0 -> ManagerMatch Il2CppClass -> static_fields +0x00 -> ManagerMatch* -> active +0x130 -> board +0x38`.

`Il2CppClass.static_fields` remains runtime-verified at `+0x98`. The Board
back-reference/cycle checks remain mandatory, and Board can legitimately be
null in the boss lobby. A live read-only b2 smoke observed exactly that lobby
condition while still resolving MatchService and ChatService and proving the
clean ChinhPhuc room. No absolute runtime pointer is persisted.

Evidence: `reverse/reverse_1.7.4-b2/cs/Assembly-CSharp/Board.cs`,
`Active.cs`, `ManagerMatch.cs`, and exact TypeInfo mappings in
`reverse/reverse_1.7.4-b2/il2cpp.json`. Confidence: **HIGH/CONFIRMED**.

### Phase 2 transport-board repair — 2026-09-11

The dispatcher callback has two independently declared views of one server
message: raw `json` at closure `+0x18` and deserialized `ChatMessageDTO` at
closure `+0x20`. In b2, `ChatService.OnWebSocketMessage` invokes
`MatchPayloadPreparser.Prepare` before enqueue. Its `PrepareBoard` result is a
typed `BoardCellDTO[8][8]` at `ChatMessageDTO.preBoard +0x3C8`, guarded by
`preBoardReady +0x3D0`; the legacy `matchPayload +0xC8` need not retain a
readable `board/srvSeq` pair. The transport tap tries the immutable raw shape,
then the same exact DTO's `preBoard`, and finally the legacy DTO payload. The
b2 path combines raw `type/matchId/matchPayload.srvSeq` authority with a
class-checked 64-cell typed board whose owner fields remain identical before
and after the read.

A generally healthy dispatcher is not proof that every short-lived callback
was sampled. If `MatchService._ackedSeqs` advances but no retained board has
that exact sequence, the controller permits one read-only recovery for that
exact `(matchId, turn, ACK)`. Run
`logs/farm_runs/bef23282eac3461bb6ca629e36f63537` proves why it must remain
strictly bounded: eleven full scans each traversed 1.28--1.31 GiB and took
7.02--7.18 seconds, starving callback capture and creating more gaps. Active
combat now forbids the full escalation and rotates through at most 64 MiB of
lobby-learned regions. It neither fabricates a sequence nor modifies/replays
network data.

Run `logs/farm_runs/c756bbc90fc64366802c7df3ade5f4ba` later proved an exact
sequence-14 callback can evade even a healthy 1 ms dispatcher tap. The tap now
samples two additional typed roots at the same cadence: current-match
`MatchService.PendingCombat +0x1A8` and the already provider-validated
`BoardWsApplier._pendingBatches +0x60`. PendingCombat must keep the same pointer
and MatchId across the batch read. A BoardWs queue capture must keep the same
class, Board owner, bootstrapped MatchId, queue address, version and contents
across the read. Both paths decode the exact `WsCombatBatch` class and complete
64-cell board, and neither becomes publishable before its exact ACK is present.

The b2 ACK itself is not a short-lived callback object. Native `SendAnimAck`
(RVA `0x399300`) inserts every positive unseen sequence into
`MatchService._ackedSeqs +0x1B8`. It clears the set only on new-match
initialization or after the count exceeds 64; the rollover immediately re-adds
the current sequence. `AckStuckGuard.MoveNext` (RVA `0x3A2DF0`) also sends a
still-missing ACK after its server-derived guard interval, or 9 seconds when no
deadline is supplied. The external reader samples the HashSet header twice and
rejects that poll if count, last-index or version changes, so a concurrent
clear/re-add cannot produce a torn accepted snapshot.

ACK is still only a render watermark. A standalone heap-scanned
`WsCombatBatch` contains no MatchId, and a later match can reuse the same
numeric sequence while that old managed object remains allocated. Therefore a
raw RuntimeSequenceMonitor batch is diagnostic unless the exact identity is
also reached through a current Board owner or current-match transport DTO. It
cannot suppress the current 64-Dot fallback merely because its sequence appears
in `_ackedSeqs`.

The same `c756bbc90fc64366802c7df3ade5f4ba` log saw ACK 14 at
`08:56:17.953Z`, again at `08:56:18.107Z`, then ACK 16 from
`08:56:32.833Z` through `08:56:34.858Z`; ACK became unavailable only after
the combat session ended. The missed item in that incident was the transient
sequence-14 board/callback, not its ACK.

Run `logs/farm_runs/4ea0b9f50cd54dc08d3bfdb984fd1f95` exposed the remaining
b2 semantic error. Local turns 9, 11 and 13 produced no `policy_decision` and
no input while durable ACK advanced `21 -> 24 -> 26 -> 28`. The last complete
transport board was sequence 21, and it had been captured on the intervening
boss turn. All four earlier inputs were acknowledged; counters were
`auto_pass_started=0`, `pass_required=0` and `policy_no_safe_move=0`. The three
game timeouts were therefore provider starvation, not policy-selected PASS.

Native b2 `MatchService.HandleResEnvelope` (RVA `0x396A70`) parses and applies
an `ops` list, creates `PendingCombat` when available, and acknowledges the
response after its work renders. `SendAnimAck` does not require the response to
carry a complete replacement board. Consequently, `max(_ackedSeqs)` is a
render watermark; it is not a promise that a `WsCombatBatch.board` with the
same sequence remains discoverable.

The Phase 2 repair keeps exact DTO capture as the preferred path and adds a
bounded current-render fallback:

1. require one exact current `BoardWsApplier`, empty pending queue, render idle,
   null `PendingCombat`, zero in-flight batches and stable Board flags;
2. read the already verified 8x8 `Board.allDots : GameObject[,]` references;
3. for each of the 64 GameObjects, verify native/managed roundtrip, active state,
   component owner and exactly one managed component with the b2 Dot class;
4. read `Dot.column +0x20`, `row +0x24`, `_board +0x48`, `multiplier +0x88`,
   motion flags `+0xB0/+0xE0/+0xF4`, `PoolTag +0xF8`, and `RenderHidden +0x129`;
5. on the b2 build, require 64 unique coordinates, six known tags and
   multipliers 1..4 (the current b5 domain is recorded below), then
   repeat every ownership/identity read and the ACK HashSet read;
6. publish the resulting board at the unchanged highest ACK watermark only
   after the existing whole-provider stability confirmation.

`BoardWsApplier.SpawnDotByTag` (RVA `0x358A30`) is the native link between the
server tag and this rendered representation: it resolves the prefab/component,
writes the tag to `Dot.PoolTag`, and writes current coordinate and multiplier
fields. This path makes no engine call and scans no heap.

Live run `2f9116700bac4331b5830ab438983229` then completed all eight local
turns and won. The direct rendered-board path performed five reads and accepted
all five with zero rejection. The run recorded zero policy PASS, zero provider
read error, zero DTO rejection, zero stale/ambiguous publication and no local
turn starvation. This is the first live acceptance of the b2 fallback; Phase 2
remains unclosed pending user review.

Exact reverse anchors: `ChatService.__c__DisplayClass275_0` TypeInfo
`0x2D97A60`; `ChatMessageDTO` TypeInfo `0x2DAD0B0`; `WsCombatBatch` TypeInfo
`0x2DEB350`, with `srvSeq +0x10` and `board +0x38`. Confidence is
**CONFIRMED** for layouts and **HIGH** for the bounded recovery interpretation;
live validation of the expanded end-to-end capture path is pending.

## Phase 3B.3 addendum (2026-09-04): Board-owned new skill UI

The accepted Board singleton resolution is unchanged. A newly verified child
chain is `Board.cardsInHand -> GameObject -> native components -> even scripting
handle -> managed CardUI`, checked against current Board/Active/CardData/Button.
See [native card evidence](phase3b3_native_card_evidence.md) for exact build,
RVAs, offsets, roundtrip checks and UNKNOWNs. This replaces allocation-neighbor
scanning for the post-evolution skill; it does not assume a fixed card order.

> **Phase 1.5 update (2026-08-11):** The external anchor blocker described in
> this original Phase 1 document is now resolved for the current hashed game
> build. Cpp2IL ISIL proves the Board, Active, and ManagerMatch type-info slot
> RVAs and the `Il2CppClass + 0xB8 -> static_fields` access. Treat the older
> `UNKNOWN`/"no RVA" statements below as historical Phase 1 status. Current
> evidence and live results are in
> [`static_singleton_resolution.md`](static_singleton_resolution.md).

## Kết luận ngắn

`Board` **có singleton**. Cpp2IL xác minh:

```text
Board.<Instance>k__BackingField : Board   static-fields offset 0x10
Board.Instance                 : Board   public static getter/private setter
```

Ngoài ra có hai ownership chain trực tiếp:

```text
Active.Instance -> Active.board (instance offset 0x38) -> Board
ManagerMatch.Instance -> ManagerMatch.active (0x130)
                      -> Active.board (0x38) -> Board
```

`BoardWsApplier` cũng giữ `Board board` ở instance offset `0x20`, nhưng bản thân component
này chưa có source object/singleton để external reader bắt đầu chain.

Không có evidence cho một absolute address hoặc module RVA trỏ trực tiếp tới các singleton.
Các static field offsets dưới đây là offsets bên trong class static-fields storage, không
phải `GameAssemblyBase + offset`.

## Strategy A — Board singleton

- **Source object:** `Il2CppClass` của global type `Board`, assembly `Assembly-CSharp`.
- **Field chain:** `Board Il2CppClass -> static_fields -> +0x10 -> Board*`.
- **Evidence:**
  - `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:929`
  - property `Board.Instance` ở `Board.cs:1164` (line có thể dịch nhẹ nếu output được tạo lại).
- **Stability:** logic singleton rất ngắn và độc lập scene-owner chain; Board object vẫn có
  thể null ngoài combat hoặc bị thay khi scene load.
- **Khả năng xác minh:** dễ nhất sau khi resolve được `Il2CppClass/static_fields`; hiện external
  reader chưa có anchor đó.
- **Confidence:** HIGH cho ownership; UNKNOWN cho external pointer resolution.
- **Xếp hạng:** 1.

Điều cấm: không đọc `GameAssemblyBase + 0x10`. `0x10` chỉ có nghĩa sau khi đã có đúng
`Board` static-fields storage.

## Strategy B — Active singleton giữ Board

- **Source object:** `Il2CppClass` của global type `Active`.
- **Field chain:** `Active Il2CppClass -> static_fields -> +0x0 -> Active* -> +0x38 -> Board*`.
- **Evidence:**
  - `Active.<Instance>k__BackingField` tại
    `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Active.cs:502`
  - `Active.board : Board` tại `Active.cs:514`
  - reverse reference `Board.active : Active` tại `Board.cs:1016`.
- **Stability:** tốt trong combat; thêm một dereference nhưng cho phép cross-check cycle
  `candidateBoard.active == candidateActive`.
- **Khả năng xác minh:** tốt hơn Strategy A về cross-validation, nhưng vẫn cần resolve
  `Active Il2CppClass/static_fields` trước.
- **Confidence:** HIGH cho chain; UNKNOWN cho external static anchor.
- **Xếp hạng:** 2.

## Strategy C — ManagerMatch singleton -> Active -> Board

- **Source object:** `Il2CppClass` của global type `ManagerMatch`.
- **Field chain:** `ManagerMatch static_fields -> +0x0 -> ManagerMatch* -> +0x130 -> Active*
  -> +0x38 -> Board*`.
- **Evidence:**
  - `ManagerMatch.Instance : ManagerMatch` static field tại
    `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerMatch.cs:261`
  - `ManagerMatch.active : Active` tại `ManagerMatch.cs:309`
  - `Active.board : Board` tại `Active.cs:514`.
- **Stability:** phụ thuộc lifecycle của ManagerMatch và Active, chain dài hơn Strategy B.
- **Khả năng xác minh:** có thêm `ManagerMatch.isBossBattle` offset `0x138` và cycle
  `Board.active`, nhưng thêm dereference/race khi scene đổi.
- **Confidence:** HIGH cho declared chain; UNKNOWN cho initialization timing và external
  static anchor.
- **Xếp hạng:** 3.

## Candidate phụ — BoardWsApplier component

- **Source object:** một instance `BoardWsApplier` trong scene — hiện UNKNOWN.
- **Field chain:** `BoardWsApplier* -> +0x20 -> Board*`.
- **Evidence:** `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs:759`.
- **Stability:** field chain ngắn sau khi có component, nhưng không có singleton/static owner
  xác minh cho component.
- **Confidence:** HIGH cho field, LOW cho khả năng dùng làm external starting strategy.
- **Xếp hạng:** không xếp vào top 3 vì thiếu source object.

`MatchService` có singleton và match dimensions/turn state, nhưng không có direct `Board`
field trong declaration Cpp2IL. Không suy ra ownership chỉ vì nó xử lý snapshot/resync.

## Validation bắt buộc trước mọi dereference sâu

Một candidate chỉ được coi là Board khi tất cả điều kiện có evidence đều đạt:

1. từng address trong chain nằm trong committed readable memory;
2. `Board.width` tại `+0x88` bằng 8;
3. `Board.height` tại `+0x8C` bằng 8;
4. `Board.allDots` tại `+0x140` non-null và là managed `GameObject[,]` hợp lệ;
5. nếu đọc được Dot component: `0 <= Dot.row < 8`, `0 <= Dot.column < 8`, multiplier hợp
   lệ; đối chiếu đủ 64 tọa độ duy nhất;
6. cross-check `Board.active` (`+0x158`) với owner `Active` nếu dùng Strategy B/C;
7. chỉ publish state khi `isCascadeRunning == false`, `isBoardReady == true`, dimensions và
   tag mapping đều hợp lệ; nếu không thì fail closed/fallback CV.

Phase 1 chưa biết chắc layout native của rectangular IL2CPP array hoặc cách external-only
resolve Unity `GameObject -> Dot component -> tag`, nên chưa implement reader.

## Anchor blocker và ASLR

ASLR làm runtime base thay đổi mỗi launch. Một strategy external hợp lệ cuối cùng phải bắt
đầu từ một anchor được xác minh theo dạng:

```text
GameAssembly runtime base + verified RVA
  -> verified metadata/class structure
  -> Il2CppClass.static_fields
  -> singleton field offset
```

Cpp2IL output hiện không cung cấp verified native RVA cho class metadata registration hoặc
target method. Vì vậy không có `GameAssemblyBase + RVA` nào được ghi/hard-code ở Phase 1.

## Đề xuất bước kế tiếp (chưa triển khai)

1. Offline resolve `Il2CppClass`/metadata registration cho metadata 31.1 bằng artifact
   matching đúng Unity 6000 build, rồi kiểm chứng lại bằng nhiều launch. Đây là đường ngắn
   nhất để dùng Strategy A/B mà vẫn read-only.
2. Nếu static class anchor offline không đủ tin cậy, làm read-only targeted inspection quanh
   verified registration/global references từ disassembly; không scan toàn RAM và không
   nhận candidate nếu thiếu full validation/cross-check A↔B.
3. Nếu external static resolution vẫn không ổn định, dừng Level A và xin review trước khi
   chuyển sang IL2CPP bridge read-only ở phase sau. Bridge có thể resolve class/field theo
   runtime API, nhưng không thuộc Phase 1.

## Pokiguard 1.7.4-b5 board addendum — 2026-09-28

The b5 GameAssembly hash is
`E2A2457128B4F412EAE302AC5314350F0C18529C12716B4EBDB36281D923F9E9`.
The three existing read-only Board owners remain valid with migrated TypeInfo
RVAs:

```text
GameAssembly.base + 0x369C9A0 -> Board Il2CppClass -> static_fields +0x10 -> Board*
GameAssembly.base + 0x369C898 -> Active Il2CppClass -> static_fields +0x00 -> Active* -> board +0x38
GameAssembly.base + 0x3697630 -> ManagerMatch Il2CppClass -> static_fields +0x00 -> ManagerMatch* -> active +0x130 -> board +0x38
```

Board dimensions, `allDots`, `active`, cascade, current state, processing UI,
game-over and result-title offsets are unchanged. Removing `HOTTURN` and
`SUBHOTTURN` shifted only the late readiness block:

| Field | b4 | b5 |
|---|---:|---:|
| `isBoardReady` | `+0x398` | `+0x390` |
| `isUsingLegendCard` | `+0x399` | `+0x391` |
| `isUsingMega` | `+0x3A0` | `+0x398` |
| `isResuming` | `+0x3B8` | `+0x3B0` |
| `isMega1PanelOpen` | `+0x478` | `+0x470` |

The b5 reader applies these offsets together with the exact hash gate. It does
not enable the b4 hash with the b5 layout.

The b5 multiplier domain is `1..7`. This is verified by two independent
sources: immutable `MATCH_MOVE_RES` JSON in FarmRun
`e746727a66bc4f7589e416b1abaacf8e` contains x5, x6 and x7 cells, and native
`DotMultiplierRoll.Roll` at RVA `0x00C6D960` iterates tiers 7 down to 2 while
`PermilleAt` at RVA `0x00C6DB40` accepts tiers 2 through 7. Tiers 5..7 become
eligible only from turn 20, which is why the older x1..x4 validator passed
short matches but rejected every board at local turns 21, 23 and 25 in that
run. Both the transport DTO decoder and rendered-Dot fallback now require
exact integer multipliers in `1..7`; any value outside this range still fails
closed.

Native ownership of the rendered Dot/GameObject graph uses the b5
`Component.get_gameObject` cache at `GameAssembly+0x38AA280` and the b5
managed/native unmarshal signature at `GameAssembly+0x136097F`. The resolved
UnityPlayer function remains `UnityPlayer+0x1067390`.

## PetPuzzle 1.7.4-b6 board addendum — 2026-10-01

The b6 GameAssembly SHA-256 is
`72D10A43FBFDAB705E2DB7CACA1CC2B998B0B8581D56946DC545D87C720EC063`.
The three board owners migrate to these module-relative RVAs:

```text
GameAssembly.base + 0x36C9F88 -> Board Il2CppClass -> static_fields +0x10 -> Board*
GameAssembly.base + 0x36C9E70 -> Active Il2CppClass -> static_fields +0x00 -> Active* -> board +0x38
GameAssembly.base + 0x36C6148 -> ManagerMatch Il2CppClass -> static_fields +0x00 -> ManagerMatch* -> active +0x130 -> board +0x38
```

Exact b5/b6 DiffableCs comparison confirms the Board fields consumed by the
reader are unchanged: dimensions, allDots, Active owner, cascade/current
state, destroyed-this-turn, UI/mega/game-over/readiness flags and result title.
The multiplier domain remains exact integer `1..7`.

Native Dot/GameObject ownership now uses the b6 GameAssembly cache at
`+0x038D7AE8` and unmarshal code at `+0x0138561F`. The installed
`UnityPlayer.dll` is unchanged, and the bridge resolved read-only in the live
b6 process. A lobby-screen probe cannot initialize scene-owned Board/Dot
classes; authoritative 64-cell board publication remains part of bounded B1
live acceptance rather than being inferred from a null lobby singleton.

### b6 main-Mega + Evolution card-strip correction — 2026-10-03

Live run `42ffa806daf043f59e21649f8a95e6a0` had `selectedCards=0`,
`cardsInHand=2`, one validated `MEGA_ICARUS` `CardUI`, and an unused normal-pet
Evolution candidate with runtime cost 120. The previous Fusion heap scan never
resolved the visible Evolution wrapper, so every turn failed closed at shared
policy step 1 despite sufficient Mana.

The provider now follows the already-verified
`Board.cardsInHand -> GameObject -> native components -> managed wrapper`
chain for Evolution as well as Pet Skill. It accepts Evolution only when one
exact current-hand `FusionCardUI` passes class, selected-pet identity,
Button/native owner and stable slot checks. The policy order is unchanged:
Evolution is non-consuming, forces a fresh state read, and a ready Mega skill
may still be used on that same local turn.

### b6 intermittent non-matching SWAP hardening — 2026-10-07

FarmRun `d2db2ce9c6974f2ba5b2003c13fcb397`, attempt 61, proves six legal
policy swaps were physically sent while only one produced the exact
MatchService local-sequence/last-move acknowledgement. The rejected inputs
used valid cell-centre coordinates; their two-click spacing reached
`1.67..2.84s`. Reverse evidence in b6 `Dot.cs` gives the client tap-selection
timeout as `3.5s`, so degraded pacing plus scheduler/render delay can expire
the first selected cell before the second click.

FarmRun `f80dce141b994d20b281a485867c9e3d`, attempt 38, is a distinct policy
case: all eight sent swaps received exact acknowledgements, then Demon Aegis
returned `DEMON_AEGIS_SWORD_ONLY_BLOCKED` on the mandatory turn where the only
legal move consumed Sword. This was not a board-coordinate failure.

The hardened path now:

- caps randomized two-click spacing at `1.85s` and resets degraded pacing at
  each combat boundary;
- does not classify a match-ending pending SWAP as delivery degradation;
- prefers the exact ACK-matched `MATCH_MOVE_RES` board over a conflicting
  presentation-time `Board.allDots` sample, retaining the latter as fallback;
- enters bounded technical recovery on the first physically sent SWAP whose
  local move sequence does not advance before the response/ACK timeout; and
- uses the least-consuming Sword move only as Demon Aegis' mandatory final
  fallback, preventing a third consecutive idle.

### b6 long-run native tag-address reuse correction — 2026-10-08

The later VM evidence narrows the remaining non-matching SWAP to a provider
identity defect rather than solver legality. The visible board showed Health at
screen `(row=5,col=5)` and Shield at `(row=6,col=5)`, while V2 physically sent
that adjacent swap even though it made no match. The downloaded Desktop UI log
does not contain the per-turn board payload, but the same failure class in
FarmRun `d2db2ce9c6974f2ba5b2003c13fcb397` published a native-Dot board and selected
a solver-legal move that the rendered game did not accept. Inter-click times
alone cannot explain this: both accepted and rejected samples overlap the same
timing range.

The native reader had retained a process-lifetime cache keyed only by the
managed `Dot.PoolTag` string address. These tag strings originate in transient
combat DTOs. Once an old string becomes unreachable, IL2CPP may reuse that
address for another tag; a process-lifetime pointer cache then returns the old
gem identity even though the current Dot and screen carry the new one. This is
exactly capable of producing a match on V2's reconstructed board and a
non-match at the same coordinates in the game.

The repair scopes pointer-to-tag caching to one stable 64-Dot ownership walk.
It also independently decodes the exact current
`BoardWsApplier._prefabByTag +0x50` dictionary and requires, for every cell:

```text
normalize(Dot.PoolTag) -> _prefabByTag value == Dot.originalPrefab +0xD8
```

The dictionary and all 64 Dot identity samples are read again before the board
may be published. A recycled tag address is therefore decoded again; a partial
or contradictory rendered identity fails closed before policy or input. The
regression suite explicitly reuses one former tag address for a different tag
between consecutive board reads and verifies that the second board receives
the new identity. Full validation passes 1,734 tests.

### Chinh Phuc display metadata correction — 2026-10-09

Read-only b6 evidence resolves Khế Ước / Liên Minh / Liên Minh II to server
group IDs `18/20/25`, live list indices `16/17/18`, and serialized island
controls `17/18/19`. The server group ID must not be treated as a panel or
Button array index. Existing navigation already uses the verified live
index; only display metadata was corrected.

The current catalog exposes 19 islands and 178 unique bosses. Rivan resolves
to pet `2534`, group `20`, index `17`, order `6`, display level `392`.
The user's reported Rivan room was joined as a guest, so it does not satisfy
the existing local-host lobby/Start guard. That guard and all board reads,
captures, action sequencing and combat policies remain unchanged.

See [the evidence and validation report](chinh_phuc_boss_data_update_20261009.md)
and [the reference catalog](data/chinh_phuc_boss_catalog_b6_20261009.json).
The catalog is reference data and cannot authorize runtime navigation or input.

## Guest boss-room entry for Bú win + Coop — 2026-10-10

The 2026-10-09 Rivan diagnosis above described the then-existing host-only
entry restriction. Guest room support is now explicit for Bú win + Coop.
Boss identity still comes from the exact room DTO or verified current-room
properties; no boss-name whitelist or screen title is used as authority.

Ready and Start share `ManagerRoom.ButtonStart`. Existing native geometry,
visual signature and fresh preflight checks remain in use. An Idle/not-ready
guest may click once and wait for the host's new Match ID/session; readiness
alone never publishes a combat board. The wait adds a read-only room/owner
check and never a second Ready click. See b6 RoomStartState evidence in
`docs/il2cpp_symbols.md` and `docs/bu_win_guest_room_20261010.md`.

FarmRun binds the initial Room ID/owner and requires them again after
postmatch. Coop room ejection/technical failure stops without solo map reentry.
Combat lifecycle remains driven by its existing MatchHost/scene/Board and
MatchService terminal signals, not by local HP. Local death suppresses Bú win
actions while existing terminal/postmatch readers continue. Solo result
classification and memory/capture/input ordering in combat remain unchanged.

## Login state versus board authority — 2026-10-10

B6 login response contains token/sessionKey/rememberToken and the native
successful-login pipeline stores AuthToken for API bearer authentication.
See `docs/login_token_research_20261010.md` and the corresponding symbols
addendum. This finding adds no runtime reader or input behavior. A token's
presence does not establish a current boss room, Match ID, combat ownership
or board freshness; existing room/lifecycle/session evidence remains required.

## Standalone login request example — 2026-10-10

`docs/examples/login_b6.curl.txt` reconstructs the b6 password-login JSON
request from verified reverse/native evidence. It is a manual Postman example,
not part of the automation runtime. No request was sent and no gameplay or
board/lifecycle/input flow was changed. Authentication response fields alone
still do not authorize a combat action or prove a fresh board.

## Device label inspection — 2026-10-10

A one-off read of the running client's LoginDevice._name confirmed its cached
login deviceName. The symbol/root and concatenation evidence are recorded in
`docs/il2cpp_symbols.md`. This read adds no runtime behavior or board authority
and invokes no game code; room/combat/input flows are unchanged.

## Phase 5 timing observation limit — 2026-10-12

The accepted provider `_read_turn_timer` and final `read_match_runtime` read
`MatchService.TurnTimeRemainingSec` as an Int32. Existing reverse proves server
message handlers update it and separately anchor a smooth Unity countdown;
the provider does not reconstruct that smooth countdown. Stable repeated raw
values do not establish tick freshness. Current Unity clock location, transport
age and host alignment remain UNKNOWN. No new game read/capture/pointer path was
added in P3. Timing export measures the existing final read through executor
return upper bound; it cannot produce a native clock uncertainty authority.

## Renamed-product prefs and postmatch room recovery — 2026-10-10

The selected PetPuzzle-1.7.4 installation's `app.info` identifies both Unity
company and product as `Pet Puzzle`. PlayerPrefs therefore comes from
`HKCU\Software\Pet Puzzle\Pet Puzzle`, not the populated legacy Pokiguard key.
The reader now resolves this identity from the attached executable's data
directory and reports missing metadata or keys without mixing products.

Registry selection is advisory for detached-room exit. Exact stale enemy ID,
absent room/combat ownership, current map manager/panel when loaded, and the
existing visual/freshness checks authorize navigation. ACTIVE/UNKNOWN cannot
authorize recovery. After result confirmation, a settled general hub is also
a missing boss room; the existing hub/map route returns to the pinned boss
without counting another match. A direct postmatch hub click additionally
requires a recorded result-confirm click and current hub/control proof.
See `docs/petpuzzle_room_reentry_fix_20261010.md` for the VM fixture, tests and
package acceptance scope. Gameplay board resolution and input stay unchanged.

## Phase 5 P4 — b6 clock boundary correction, 2026-10-12

P4 rebinds timing evidence to current GameAssembly b6 by direct file disassembly.
Current raw timer is `MatchService+0x190`, already used by the accepted provider;
the older Cpp2IL `+0x118` countdown table is historical. Current smooth anchors
are `+0x1C8/+0x1CC`, pause `+0x1BD`, FX hold `+0x1E8`. Anchor can be changed by
local FX as well as server timing. Stable integer or anchor is not a freshness
receipt, and last WebSocket ping RTT does not bound a different timer message.

No board/provider/input/ACK/recovery code, memory reads or captures changed.
Native Unity time/host alignment/transport bounds remain UNKNOWN. A standalone
passive diagnostic contract is proposed in
`docs/phase5/research/5d1_p4_clock_evidence_and_observation.md`, outside production
farm reads, not implemented/activated here. It does not confer deadline/input
authority or enable REASONING. P4 report/ledger bind fields to exact build/files.

## Bú win postmatch presentation boundary — 2026-10-12

Run `810139fceb784f94b033aa37c2e26714`, match `M_956cc760`, proves that
terminal ownership and visible presentation can differ: at 23:15:02.663
Vietnam time the provider reports POSTMATCH with MATCH_GAME_OVER, while the
first saved postmatch frame still shows a teammate's skill announcement. The
last frame at the old 30s timeout shows the victory banner/gift without a
confirm label. Existing result detection correctly rejects both frames.

Current b6 native code sets MatchService._matchOver before checking
IsPresentationBusy and can defer the result event for up to 30 unscaled
seconds. Preserve terminal classification and the gameplay input prohibition;
do not reclassify these retained animation frames as actionable combat.
The FarmRun Bú win/Coop confirmation adapter now has a one-time 30s
presentation allowance in addition to its configured result UI budget.
It revalidates POSTMATCH/session before using the allowance and retains the
three-frame label/position proof and immediate pre-click validation.
The absolute deadline never resets on changing images. Solo timeout remains
unchanged. This is postmatch waiting only; board resolution and gameplay
policy/provider/input order remain unchanged.

See `docs/bu_win_postmatch_animation_20261012.md` and
`docs/artifacts/bu_win_postmatch_animation_20261012/`. Main Phase 5 remains at
its existing milestone; historical P3/P4 source pins are historical evidence,
not acceptance of this newer FarmRun adapter.

## P6 standalone observer validation gap — 2026-10-14

One user-operated native diagnostic window on b6 produced one invalid sample,
0 useful clock samples. All15RPM returned their requested204bytes; root/identity
yielded turn3, duration14, raw remaining14. The first48B clock block was read
successfully, then the standalone decoder rejected INVALID_CLOCK_FLOAT before
reading B. This is not evidence of a board/provider failure or finite timer age.

Read-only current-file bytes prove `_localFxHoldUntilUnscaled +0x1E8` is reset
to float32 -1.0 at ClearLocalFxHold RVA0x417A40 and ApplyTimingFields RVA0x417D51.
P5's diagnostic parser incorrectly excludes this valid sentinel. The actual
native failing field/value were not exported, so a causal attribution to -1
in that sample remains unproven. Preserve the failed ledger and correct the
diagnostic parser/field-level errors offline before considering a new window.

No gameplay source/offset/ownership/scan/capture/input/ACK flow changed; no new
native reads after the single window. `native_U_ms:null`, transport age UNKNOWN,
input_authority false. See `docs/phase5/reports/5d1_p6_report.md` and its artifacts.


## 2026-10-22 — Outside-combat health reminder geometry

New `play_reminder.py` walks the exact PlayReminder-owned `_board` to its only
Button, checks Canvas.enabled (not GameObject active), then uses existing
NativeCardUiReader/Unity UI viewport mapping. Show animates scale, so require
stable native geometry before the visual sanity and fresh input preflight.
No change to board/gem centers, random 10% offsets, scan order, solver or QTE.
After closing, reread the room/map and use the existing immutable-target router.

Moving boss/island/Chinh Phuc controls alone does not require pixel-coordinate
updates: the primary route uses their runtime Button geometry and DTO/ID
association. Changed hierarchy/data association/artwork still needs verification.
See [health reminder report](play_reminder_20261022.md); actual modal click/return
live test remains outstanding, while supplied-image/native-fixture tests pass.

Follow-up from the user's four map screenshots: the conquest island list is
vertically scrollable. Current island selection has no scroll/drag step and
does not prove ScrollRect viewport clipping; off-Canvas target geometry is
rejected, so navigation can time out when the required island is out of view.
The health-reminder patch does not close this gap. Exact content/viewport
ownership must be audited before adding bounded normal-input scrolling and
fresh visible-target proofs. See the follow-up section in the same report.

## Modal/AFK incident — 2026-10-23, investigation only

Farm6b1a3c58… completed95WIN then stopped in match96 before its second SWAP:
legacy image guard reported LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK.
Game later logged KICKED reason=AFK; UI reached general lobby02:45:30 local.
No terminal/reward or automated leave input belongs to match96. No guard frame
was retained, so real leave modal vs image false positive remains UNKNOWN.
PlayReminder handler had no events in this run; stopped FarmRunner does not
dismiss subsequent modals. b10 reminder scheduling repeats with remote
health.reminderMin override; display370 is total online minutes, not an exact
interval certificate. See [pinned investigation](health_reminder_incident_20261023.md).

Follow-up2026-10-24: [visual guard repair](leave_modal_guard_fix_20261024.md)
requires filled button bodies and interior labels on both orange candidates;
two orange patches alone cannot pause. Existing captures remain in the same
order. A blocking frame now persists as bounded failure evidence even when
routine images are off; no new capture/read/input or automatic SAFE_STOP resume.
Known true modal remains recognized. Original incident's missing frame stays
UNKNOWN; synthetic reconstruction of its static board did not reproduce it.
