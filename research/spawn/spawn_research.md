# Spawn research: các viên gem mới được sinh ra như thế nào?

Ngày hoàn tất: 2026-08-11  
Branch: `research/spawn`  
Phạm vi: research-only; không sửa Phase 2A, không sửa `PokiguardAuto`, không sửa/chạy can thiệp game.

## Executive result

**Classification: MODEL A — SERVER GENERATED (HIGH confidence).**

Với boss match WebSocket, server response cung cấp exact tag cho từng gem mới trong:

```text
MATCH_MOVE_RES
  -> ChatMessageDTO.matchPayload["ops"]
  -> MatchOpDTO(type="SPAWN").data["tag"]
  -> BoardWsApplier.ApplySpawn(op)
  -> SpawnDotByTag(col,row,tag,multiplier,true)
  -> lookup Board.dots prefab
  -> Object.Instantiate
  -> Board.allDots[col,row]
```

Cùng response còn có final board tại `matchPayload["board"]`, được parse thành `WsCombatBatch.board : BoardCellDTO[][]`; mỗi cell có `tag`. Client dùng snapshot này để verify/repair board sau khi áp dụng ops.

**Client không có exact future gem tag trước move theo data path đã chứng minh. Client có tag sau khi nhận `MATCH_MOVE_RES`, có thể trước animation refill.**

**Khả năng predict bằng read-only client data:**

- trước move/T0: **NO**;
- sau server response nhưng trước render/T1: **YES để quan sát quyết định đã nhận**, không phải prediction;
- thuật toán sinh phía server: **UNKNOWN**.

## Trả lời 15 câu hỏi

### 1. Exact spawn pipeline là gì?

```text
Player swap
  -> Dot.RequestSwap(...)
  -> MatchService.SendMove(...)
  -> WsMatchClient.SendMove(...)
  -> ChatService.SendMatchMove(...)
  -> WebSocket "MATCH_MOVE_REQ"

Server response
  -> WebSocket "MATCH_MOVE_RES"
  -> ChatService.OnWebSocketMessage(...)
  -> MatchService.HandleMatchMoveRes(message)
  -> MatchService.HandleResEnvelope(message,"MOVE")
  -> MatchService.ParseOps(matchPayload["ops"])
  -> MatchService.ParseCombatBatch(message)
  -> BoardWsApplier.HandleOpsApplied(ops)
  -> _pendingBatches.Enqueue((ops,combat,fx))
  -> ApplyOpsSequential -> ApplyOpsInner
  -> apply server-ordered SWAP / DESTROY / FALL / SPAWN
  -> ApplySpawn reads col,row,tag,multiplier
  -> SpawnDotByTag finds prefab and instantiates it
  -> wait for fall settle
  -> VerifyBoardAgainstServer(combat.board)
```

`ApplyOpsInner` không tự solve/refill; nó thực thi list ops theo thứ tự server đã gửi. Evidence: `Assembly-CSharp`, `BoardWsApplier_NestedType__ApplyOpsInner_d__49.MoveNext`, `BoardWsApplier_NestedType__ApplyOp_d__51.MoveNext`. Confidence: **HIGH**.

### 2. Method nào nhận quyết định cuối cùng về gem tag?

**`BoardWsApplier.ApplySpawn(MatchOpDTO op)`** là method client nhận tag quyết định cuối cùng ở cấp SPAWN op. Nó lấy `op.data["tag"]` rồi gọi:

```csharp
SpawnDotByTag(col, row, tag, multiplier, true)
```

`SpawnDotByTag` là consumer chọn prefab vật lý; nó không quyết định tag.

Evidence:

- assembly/type: `Assembly-CSharp!BoardWsApplier`;
- exact signature: `private void ApplySpawn(MatchOpDTO op)`;
- source: `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt:10001`;
- original token `0x06000BE9`, RVA `0x7409F0`;
- confidence: **HIGH**.

### 3. Tag originate từ đâu?

Tag originate từ **network response payload**:

```text
ChatMessageDTO.matchPayload +0xC8
  ["ops"] -> List<MatchOpDTO>
  MatchOpDTO.type +0x10 == "SPAWN"
  MatchOpDTO.data +0x18
    ["tag"] -> exact string consumed by ApplySpawn
```

Alternate corroborating source trong cùng response:

```text
MatchService.PendingCombat +0x170
  -> WsCombatBatch.board +0x38
  -> BoardCellDTO.tag +0x18
```

Literal `"MATCH_MOVE_RES"` được dispatch trong `ChatService_NestedType___c__DisplayClass240_0.txt:2246`; literal `"ops"` ở `MatchService.txt:17885`; literal `"tag"` ở `BoardWsApplier.txt:10220`. Confidence: **HIGH**.

### 4. Server hay client quyết định?

**Server cung cấp exact quyết định cuối cùng cho client.** Đây là MODEL A.

Client chỉ parse tag, lookup prefab và render. Static client reverse không thể nói server tự random, lấy từ server-side queue hay tính theo rule nào. Vì vậy “server decides” ở đây là kết luận về client/server contract, không phải khẳng định thuật toán server nội bộ. Confidence: **HIGH cho contract; UNKNOWN cho server algorithm**.

### 5. Có Random/RNG trên spawn path không?

**NO.** Không có call Random/RNG trong path:

```text
MATCH_MOVE_RES -> ParseOps -> ApplySpawn -> SpawnDotByTag
```

`Board.RefillBoardNonDeterministic()` có `UnityEngine.Random.Range` để chọn `Board.dots` và multiplier, nhưng `Board.RefillBoard()` không đi vào fallback này khi WebSocket gameplay active và `CurrentMatchId` tồn tại. `MatchService.get_UseWsGameplay()` luôn trả `true` trong build này.

Evidence:

- `Board.RefillBoard()`: token `0x06001C49`, RVA `0x5AB560`;
- `Board.RefillBoardNonDeterministic()`: token `0x06001C4A`, RVA `0x5AAFD0`;
- `MatchService.get_UseWsGameplay()`: RVA `0x457060`, native body trả `1`;
- confidence: **HIGH**.

### 6. Có seed không?

**NO operative seed trên boss spawn path.**

- không có payload key `randomSeed`, `boardSeed`, `spawnSeed`, `matchSeed` trên path;
- `MatchSeed.GenerateNew()` là no-op;
- `MatchSeed.Current` luôn trả `0`;
- `BoardPVP.lastRefillSeed` thuộc PVP type khác, không có call/data edge sang boss path;
- `Random.InitState` ở Card UI/PVP không nằm trên spawn path.

Server-side seed, nếu có, là **UNKNOWN**. Confidence: **HIGH cho client path**.

### 7. Có upcoming queue không?

**Không tìm thấy queue chứa future tags trước move.**

`BoardWsApplier._pendingBatches +0x50` có exact type:

```text
Queue<(List<MatchOpDTO>, WsCombatBatch, IEnumerator)>
```

nhưng chỉ được enqueue trong `HandleOpsApplied` sau khi response đã parse. Nó là **post-response render queue**, không phải pre-generated gem queue.

`MatchService.PendingCombat +0x170` cũng là transient post-response snapshot và bị clear bởi `ConsumePendingCombat()`. Confidence: **HIGH**.

### 8. `Board.dots +0x70` có vai trò gì?

**Prefab catalog.** Exact type `UnityEngine.GameObject[]`.

`FindDotPrefabByTag(tag)` duyệt array, match `GameObject.tag` hoặc fallback prefab name. `SpawnDotByTag` instantiate prefab tìm được và gắn reference vào `Dot.originalPrefab +0xD8`. Local non-WS fallback cũng random index từ array này.

Nó không phải live board, pool hay future queue. Live grid là `Board.allDots +0x140`.

Native code không hard-code array length; exact runtime size/order phụ thuộc Unity serialized data. Existing reverse string/docs phù hợp sáu prefab tags, nhưng population cụ thể chưa runtime-read trong research này. Confidence: **HIGH về role, MEDIUM về serialized size/order**.

### 9. Có Dot ngoài row 0..7 không?

**Không có logical off-board Dot trên network spawn path.**

`ApplySpawn` yêu cầu `InBounds(col,row)`. `SpawnDotByTag` ghi logical `Dot.row` bằng row hợp lệ rồi lập tức ghi object vào `Board.allDots[col,row]`.

Khi `fallFromAbove=true`, chỉ transform/world-Y bắt đầu ở phía trên board cho animation; logical row vẫn là target 0..7. Đây không phải MODEL E. Confidence: **HIGH**.

### 10. Có object pool không?

**Không có gem object pool trên path đã trace.**

`SpawnDotByTag` gọi `UnityEngine.Object.Instantiate`. Object cũ xung đột có thể bị destroy. `Board.dots` chứa prefab references, không phải inactive instances. `Board._destroyEntryPool +0x3F0` là pool UI destroy-summary, không phải Dot/gem. Confidence: **HIGH**.

### 11. Client biết gem mới ở thời điểm nào?

**Chỉ sau server response, nhưng có thể trước animation.**

| Mốc | Exact tag ở client? | Evidence |
|---|---|---|
| Trước move (T0) | **NO evidence / không có source trên path** | không queue, seed, RNG state hay hidden Dot |
| Move đã gửi, response chưa tới | **NO** | request chỉ chứa coordinates/seq |
| `MATCH_MOVE_RES` đã deserialize, trước render (T1) | **YES** | `MatchOpDTO.data["tag"]`, `_pendingBatches`; final `BoardCellDTO.tag` |
| Sau spawn (T2) | **YES** | instantiated prefab/live `allDots` |

### 12. Có thể predict future gems chỉ bằng READ-ONLY client data không?

**NO đối với exact gems trước move.**

Không có chứng minh rằng exact tag hoặc đủ seed/state để tính tag tồn tại trong client ở T0. Sau response, read-only observation có thể thấy tag trước animation, nhưng đó là đọc kết quả server vừa gửi chứ không phải prediction.

Nói ngắn gọn:

```text
Pre-move prediction:                 NO
Post-response/pre-animation observe: YES
Server-generation algorithm:         UNKNOWN
```

### 13. Nếu YES hoặc CONDITIONAL, source cần đọc là gì?

Không có source pre-move nên không có thiết kế predictor.

Chỉ để mô tả evidence post-response, các transient source là:

- `List<MatchOpDTO>`: mỗi `SPAWN.data["tag"]`;
- `BoardWsApplier._pendingBatches +0x50` sau `HandleOpsApplied`;
- `MatchService.PendingCombat +0x170 -> WsCombatBatch.board +0x38 -> BoardCellDTO.tag +0x18`, trước khi `ConsumePendingCombat()` clear field.

Các source này không được implement thành cheat/solver/watcher trong research branch.

### 14. UNKNOWN / blocker

1. Server dùng RNG, seed, queue hay rule nào để chọn gem: **UNKNOWN**.
2. Server pre-generates trước move hay generate lúc xử lý move: **UNKNOWN**.
3. Distribution/weight và quy tắc tránh match phía server: **UNKNOWN**.
4. Exact packet capture/wire sample chưa có; schema được chứng minh từ client deserializer và literal consumers.
5. Exact serialized order/length của `Board.dots` trong một runtime instance chưa được đo ở research branch.
6. Micro-timing giữa network arrival, main-thread dispatch và enqueue chưa đo runtime; code ordering đã rõ.

Không blocker nào ở trên làm thay đổi classification phía client.

### 15. Toàn bộ file research đã tạo

1. `research/spawn/spawn_static_analysis.md`
2. `research/spawn/spawn_research.md`

Không tạo runtime tool và không tạo file nào dưới `research/spawn/tools/`.

## Method/RVA evidence index

| Type.method | Exact signature tóm tắt | Token | RVA | Confidence |
|---|---|---:|---:|---|
| `Dot.RequestSwap` | `void (int,int,int,int)` | `0x06001E4D` | `0x5DC610` | HIGH |
| `MatchService.SendMove` | `void (int,int,int,int)` | `0x06000EDF` | `0x4A51D0` | HIGH |
| `WsMatchClient.SendMove` | `void (string,int,int,int,int,long)` | `0x06001031` | `0x4D4600` | HIGH |
| `ChatService.SendMatchMove` | `void (string,int,int,int,int,long)` | `0x06000DA2` | `0x4907F0` | HIGH |
| `ChatService.OnWebSocketMessage` | `void (object,MessageEventArgs)` | `0x06000D70` | `0x48E730` | HIGH |
| `MatchService.HandleMatchMoveRes` | `void (ChatMessageDTO)` | `0x06000EFA` | `0x4A1BD0` | HIGH |
| `MatchService.HandleResEnvelope` | `void (ChatMessageDTO,string)` | `0x06000F01` | `0x4A2AB0` | HIGH |
| `MatchService.ParseOps` | `List<MatchOpDTO> (Dictionary<string,object>)` | `0x06000F14` | `0x4A3B20` | HIGH |
| `MatchService.ParseCombatBatch` | `WsCombatBatch (ChatMessageDTO)` | `0x06000EB3` | `0x4A3070` | HIGH |
| `BoardWsApplier.HandleOpsApplied` | `void (List<MatchOpDTO>)` | `0x06000BD6` | `0x744CF0` | HIGH |
| `BoardWsApplier.ApplyOpsSequential` | `IEnumerator (List<MatchOpDTO>,WsCombatBatch)` | `0x06000BD9` | `0x740690` | HIGH |
| `BoardWsApplier.ApplyOpsInner` | `IEnumerator (List<MatchOpDTO>)` | `0x06000BE0` | `0x740600` | HIGH |
| `BoardWsApplier.ApplyFall` | `void (MatchOpDTO)` | `0x06000BE8` | `0x73FE80` | HIGH |
| `BoardWsApplier.ApplySpawn` | `void (MatchOpDTO)` | `0x06000BE9` | `0x7409F0` | HIGH |
| `BoardWsApplier.SpawnDotByTag` | `void (int,int,string,int,bool)` | `0x06000BD3` | `0x7479C0` | HIGH |
| `BoardWsApplier.FindDotPrefabByTag` | `GameObject (string)` | `0x06000BD1` | `0x742DA0` | HIGH |
| `BoardWsApplier.VerifyBoardAgainstServer` | `int (BoardCellDTO[][])` | `0x06000BE7` | `0x748D50` | HIGH |
| `Board.RefillBoard` | `void ()` | `0x06001C49` | `0x5AB560` | HIGH |
| `Board.RefillBoardNonDeterministic` | `void ()` | `0x06001C4A` | `0x5AAFD0` | HIGH |

Các RVA là build-specific và phải cộng module base ở runtime; không hard-code absolute address.

## Quyết định không chạy Phase S2

Không thực hiện runtime observation. Lý do: Phase S1 đã chứng minh đủ cả ba điểm cần phân loại:

1. exact tag đi vào từ response payload;
2. client RNG fallback bị gate khỏi active boss match;
3. tag chỉ xuất hiện ở client containers sau khi response đã parse.

Runtime watcher chỉ có thể xác nhận timing/serialized asset cụ thể, không cần thiết để trả lời nguồn quyết định tag. Việc dừng ở static phase cũng giữ đúng yêu cầu “runtime chỉ làm nếu static chưa đủ kết luận”.

## Tài liệu chi tiết

Toàn bộ call/data-flow, DTO schema, RNG/seed/queue/hidden-row/object-pool audit và primary source list nằm trong `spawn_static_analysis.md` cùng thư mục.

