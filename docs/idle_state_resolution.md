# Phase 2C.2A.1 — authoritative idle/PASS state

## Kết luận

Trạng thái PASS/idle liên tiếp **chưa production-ready**. Server là source of
truth và gửi `idleCount`/`threshold`, nhưng build client hiện tại không lưu hai
giá trị này trong một field bền vững đã được chứng minh. Policy phải tiếp tục
để `consecutive_passes=None`, không phát PASS, và fail closed với
`GAME_OWNED_SKIP_STATE_UNKNOWN`.

Không có local counter nào được thêm vào đường quyết định gameplay.

## Data flow đã xác minh

```text
server websocket
  -> ChatService.OnWebSocketMessage
  -> ChatMessageDTO
  -> MATCH_TURN_END hoặc MATCH_AFK_WARN dispatch
  -> WsMatchClient event
  -> MatchService.HandleMatchTurnEnd / HandleMatchAfkWarn
  -> OnAfkWarn(username, idleCount, threshold)
  -> BoardWsApplier.HandleAfkWarn
  -> chỉ hiện GameNotice cho local username
```

Evidence:

- `ChatMessageDTO.matchId +0xB0`, `matchPayload +0xC8`:
  `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs`.
- Websocket dispatcher có nhánh literal `MATCH_AFK_WARN` và
  `MATCH_TURN_END`:
  `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService_NestedType___c__DisplayClass240_0.txt:2720`
  và `:3286`.
- `MatchService.HandleMatchTurnEnd` cập nhật `CurrentTurnPlayer +0x38`,
  `TurnNumber +0x40`, timer/stats, rồi đọc object tùy chọn `afkWarn` và các key
  `username`, `idleCount`, `threshold`:
  `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt:15119-15552`.
- `MatchService.HandleMatchAfkWarn` kiểm tra đúng `matchId`, bỏ qua sau
  `_matchOver`, đọc `idleCount` (default 0) và `threshold` (default 3), chỉ raise
  event khi `idleCount > 0`:
  `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt:15565-15693`.
- `OnAfkWarn` chỉ là delegate backing field tại `MatchService +0xF8`; không có
  backing field cho hai integer:
  `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchService.cs:267-355`.
- `BoardWsApplier.HandleAfkWarn` so sánh `username` với
  `ChatService.Username` bằng OrdinalIgnoreCase và chỉ gọi `GameNotice.Show`.
  Native body không ghi state và không kick:
  `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt:17405-17557`.
  Chuỗi UI dùng chính `idleCount/threshold` và nói đủ `threshold` lượt liên
  tiếp sẽ bị loại.

## Ý nghĩa đã biết và UNKNOWN

| Câu hỏi | Kết quả | Evidence/confidence |
|---|---|---|
| `idleCount` thuộc ai? | Thuộc `username` trong cùng `afkWarn`; UI chỉ hiện khi username là local user. | CONFIRMED client data flow |
| Khi nào tăng? | Server gửi count dương cùng AFK warning/turn-end. Điều kiện server nội bộ không nằm trong client dump. | PARTIAL |
| Threshold | Handler dùng payload, default 3 nếu thiếu. | HIGH static; runtime của ván audit NOT OBSERVED |
| Reset sau SWAP | UNKNOWN | Không có idle event trong log ván audit |
| Reset sau CAST | UNKNOWN | Không có idle event/card response trong log ván audit |
| Reset sau EVOLVE | UNKNOWN | EVOLVE được chứng minh không phải consuming action trong policy/client flow, nhưng reset phía server chưa quan sát |
| Persistent MatchService field | Không có field đã chứng minh. | HIGH |
| Client kick logic | Không thấy; client chỉ nhận warning/player-left/game-over và hiển thị. Quyết định loại là server-owned. | HIGH |

`WsPlayerStateDTO.passed +0x40` không được chấp nhận: type này thuộc room/player
properties và không có evidence nối tới combat `MATCH_AFK_WARN`.
`Board.requestPass +0x2C8` cũng bị loại: `Board.Start` đọc cấu hình
`PlayerPrefs.GetInt("requestPass", 5)`; nó không phải consecutive idle count.

## Vì sao không dùng heap residue làm production state

`ChatMessageDTO` là object transient. Closure
`ChatService+<>c__DisplayClass240_0` giữ DTO cho đến khi callback trên Unity main
thread chạy, sau đó không có root bền vững đã chứng minh. Managed heap có thể
còn bytes/class pointer sau khi object không còn reachable; address hoặc nội
dung đó không đủ làm “latest authoritative state”. `messageHistory` chỉ giữ
chat/team message theo native dispatch branches, không giữ AFK message.

Một AFK message đã bắt được vẫn là bằng chứng authoritative cho **thời điểm
event**, nhưng không tự chứng minh count hiện tại sau một SWAP/CAST vì server có
thể reset mà không gửi `idleCount=0`.

## Read-only watcher

`tools/idle_state_watch.py` được tạo để lấy evidence cho một ván sau:

```powershell
python tools\idle_state_watch.py --watch --matches 1
```

Watcher:

- chỉ mở process với quyền read-only qua hạ tầng attach hiện tại;
- lọc `ChatMessageDTO` bằng class pointer, current `matchId` và event type;
- log direct `MATCH_AFK_WARN.idleCount/threshold` khi parse được;
- log `LastMove*`, Fusion và CardUI transition để ghép timeline;
- không click, không gọi method game, không ghi process/network;
- không duy trì `consecutive_pass += 1` và không publish count cho policy.

`ChatMessageDTO` TypeInfo slot RVA `0x350F660` được xác định từ nhiều native
body của `ChatService`: mỗi body initialize preferred VA `0x18350F660` ngay
trước `typeof(ChatMessageDTO)` / allocation, ví dụ
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService.txt:18197-18217`.

Watcher đọc cả direct `MATCH_AFK_WARN.matchPayload` và nested
`MATCH_TURN_END.matchPayload["afkWarn"]`. Nested parser dùng exact Cpp2IL
layout `JObject._properties +0x58`,
`JPropertyKeyedCollection._dictionary +0x18`, `JProperty._content +0x58`,
`JPropertyList._token +0x10`, `JValue._value +0x38`; mọi count/string đều có
bounds/layout gate. Heap candidates không vượt qua class, current-match và
layout gates bị bỏ. Watcher là evidence collector, chưa phải production
provider.

## Acceptance

Status: **BLOCKED cho PASS / PARTIAL cho BASIC non-PASS**.

Để resolve hoàn toàn cần một capture có ít nhất:

1. authoritative event count 1 và 2 cho local username;
2. sau đó SWAP được server accept và event kế tiếp chứng minh reset;
3. tương tự CAST;
4. EVOLVE riêng, rồi timeout, để chứng minh EVOLVE không reset;
5. threshold thực từ payload.

Không yêu cầu user thực hiện các case này trong Phase 2C.2A.1; watcher đã sẵn
sàng cho lần test có chủ đích sau khi user review.

## Phase 2C.2A.2 instrumentation addendum

The server-owned cache and expanded acceptance timeline are documented in
`docs/phase2c2a2_acceptance.md`. The implementation caches only exact payload
values and never performs local count arithmetic.

The targeted runtime run observed local values 1/3 and 2/3. A fresh nested
`MATCH_TURN_END.afkWarn` for the exact current local turn may therefore map to
`PASS_ALLOWED` or `PASS_FORBIDDEN_MANDATORY_ACTION`. Direct AFK messages,
stale/absent state and any state after an action without a reset payload remain
`UNKNOWN`.

This does not lift the production block: count zero/reset was never exposed,
CAST and EVOLVE reset semantics are unresolved, and the transient cache is not
connected to `BattleState`. Autonomous PASS remains disabled. Full evidence is
in `docs/phase2c2a2_runtime_audit.md`.

## Phase 2C.2A.3 reset model and lifecycle scoping

`GameOwnedIdleState` now carries `status`, freshness and one of four reset
classifications:

```text
RESET_CONFIRMED_EXPLICIT
RESET_CONFIRMED_BY_SERVER_SEQUENCE
RESET_STRONGLY_INFERRED
RESET_UNKNOWN
```

Rules:

- only `observe_server_payload()` may replace `idle_count`/`threshold`;
- accepted SWAP/CAST/EVOLVE responses never increment, decrement or zero the
  value; they make the cached observation stale while waiting for the next
  authoritative payload;
- literal server `idleCount=0` is `RESET_CONFIRMED_EXPLICIT`;
- lower next authoritative count after an accepted local action, with ordered
  response/event server sequences, is `RESET_CONFIRMED_BY_SERVER_SEQUENCE`;
- the same decrease without packet sequence is
  `RESET_STRONGLY_INFERRED`, preserving action/timestamp/turn provenance;
- everything else remains `RESET_UNKNOWN`.

The cache is scoped to the full combat session key and is discarded—not merely
aged—when lifecycle leaves ACTIVE, Board is lost, match ID changes, postmatch
begins, lobby is entered, or a new session begins. `pass_readiness()` also
requires an ACTIVE lifecycle. UNKNOWN always disables PASS.

Static reverse review confirms that `MATCH_MOVE_RES` and
`MATCH_CARD_USE_RES` enter `HandleResEnvelope("MOVE"/"CARD_USE")`, which checks
current match ID, parses ops, applies state delta and parses the combat batch.
`MATCH_REJECT` is handled separately. No client field/event explicitly named
idle reset or an observed zero payload was found.

Current evidence classification before the controlled S1/S2/S3 capture:

| Action | Classification | Reason |
|---|---|---|
| SWAP | `RESET_STRONGLY_INFERRED` (historical aggregate only) | warnings returned to `1/3` after gameplay activity, but the old capture did not isolate one exact PASS-PASS-SWAP-PASS chain |
| CAST | `RESET_STRONGLY_INFERRED` | controlled `M_2ab08386` observed `2/3`, local `MATCH_CARD_USE_RES` without reject, then the next intentional PASS at `1/3`; no explicit zero/idle sequence field |
| EVOLVE | `RESET_UNKNOWN` | `M_1aaa7be0` eventually returned `MATCH_FUSION_RES success=true` with `fusion.used=true`, but intervening SWAPs and absence of a later authoritative idle payload leave reset unproven |

Stage B5 retry 2 (`M_35b2ee04`) independently reproduced the absence of an
idle payload after successful EVOLVE: local turn 25 expired with zero further
input, boss turn 26 and local turn 27 followed, and neither
`MATCH_AFK_WARN` nor nested `afkWarn` correlated to turn 25. This does not prove
an idle reset and does not authorize a local count. It does prove that the
EVOLVE-touched remainder cannot be processed by `PASS_WAIT`, whose contract
correctly requires an authoritative AFK payload. The executor now uses a
separate zero-input `EVOLVE-only turn` transition and leaves EVOLVE reset
classification `RESET_UNKNOWN`.

Stage B5 retry 3 (`M_f8cd2d73`) extends the same finding to rejection. The
client sent EVOLVE on local turn 13, received exact
`MATCH_FUSION_RES success=false`, sent no subsequent input, and returned to
local turn 15 without a correlated AFK payload. Therefore the executor treats
both terminal EVOLVE outcomes as turn activity for execution control. This
still does not establish an idle reset or change any numeric idle value.

At that Phase 2C.2A.3 checkpoint, PASS was still **not production-ready**. The
watcher and controlled runbook were `tools/lifecycle_idle_watch.py` and
`docs/phase2c2a3_runbook.md`; later Phase 2C.2C evidence enabled the bounded
authoritative PASS coordinator.

## Phase 2C.2A.3.1 Fusion correlation

`tools/combat_diagnostic_watch.py` now records authoritative idle before and
after every correlated Fusion response. A lower uncontaminated value is
`CONFIRMED`, a higher uncontaminated value is `NO_RESET`, and equal/missing or
SWAP/CAST-confounded evidence remains `UNKNOWN`. It never mutates the
game-owned cache. This instrumentation does not change the current EVOLVE
classification: S3 remains `RESET_UNKNOWN` until a new clean runtime pair is
captured.
