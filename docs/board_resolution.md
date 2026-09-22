# Board instance resolution — Phase 1

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
5. require 64 unique coordinates, six known tags and multipliers 1..4, then
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
