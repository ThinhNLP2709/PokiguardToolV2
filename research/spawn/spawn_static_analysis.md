# Static reverse analysis: pipeline sinh gem mới

Ngày nghiên cứu: 2026-08-11  
Phạm vi: boss match WebSocket, Windows x64, Unity IL2CPP.  
Phương pháp: chỉ đọc output Cpp2IL trong `reverse/` và tài liệu hiện có trong `docs/`; không chạy game, không đọc runtime, không thay đổi game hay Phase 2A.

## Kết luận tĩnh

**Phân loại: MODEL A — SERVER GENERATED (confidence: HIGH).**

Trong đường boss match đang hoạt động, client không chọn tag gem mới. Server trả `MATCH_MOVE_RES`; `MatchService` parse `matchPayload["ops"]` thành `List<MatchOpDTO>`. Mỗi op `SPAWN` chứa `data["col"]`, `data["row"]`, `data["tag"]`, và tùy chọn `data["multiplier"]`. `BoardWsApplier.ApplySpawn` đọc nguyên tag đó rồi truyền vào `SpawnDotByTag`, nơi tag chỉ được dùng để tìm prefab trong `Board.dots` và instantiate một GameObject.

Không có `Random`, seed, queue gem tương lai hay hidden logical row trên data path này. `Board.RefillBoardNonDeterministic` có client RNG, nhưng `Board.RefillBoard` không gọi nó khi WebSocket match đang active và có `CurrentMatchId`.

Điều static reverse **không** cho biết là thuật toán nội bộ trên server: server có thể dùng RNG, queue hoặc seed của riêng server. Kết luận “server generated” ở đây có nghĩa chính xác là **server là nguồn cung cấp quyết định tag cuối cùng cho client**.

## Chuẩn evidence và quy ước

- `HIGH`: native ISIL thể hiện trực tiếp literal key, field access và call chain.
- `MEDIUM`: được hỗ trợ bởi declaration/call search đầy đủ, nhưng còn phụ thuộc asset/runtime serialization.
- `LOW`: chỉ là khả năng hoặc suy luận loại trừ.
- RVA bên dưới thuộc đúng build đã reverse, là RVA tương đối với `GameAssembly.dll`; không phải địa chỉ tuyệt đối qua ASLR.
- Assembly của các type gameplay bên dưới là `Assembly-CSharp`, namespace global trừ khi ghi khác.

## Flow dựa trên evidence

```text
Dot.RequestSwap(fromCol, fromRow, toCol, toRow)
  [Dot.txt; RVA 0x5DC610]
      |
      v
MatchService.SendMove(...) -> WsMatchClient.SendMove(...)
      -> ChatService.SendMatchMove(...)
      -> WebSocket message type "MATCH_MOVE_REQ"
  [MatchService.txt; WsMatchClient.txt; ChatService.txt]
      |
      | server xử lý move (logic nội bộ server không có trong client dump)
      v
ChatService.OnWebSocketMessage(...)
      -> dispatch literal "MATCH_MOVE_RES"
  [ChatService.txt;
   ChatService_NestedType___c__DisplayClass240_0.txt:2246]
      |
      v
MatchService.HandleMatchMoveRes(ChatMessageDTO)
      -> HandleResEnvelope(message, "MOVE")
      -> ParseOps(message.matchPayload["ops"])
  [MatchService.txt; RVA 0x4A1BD0 / 0x4A2AB0 / 0x4A3B20]
      |
      | List<MatchOpDTO>, trong đó SPAWN.data["tag"]
      v
BoardWsApplier.HandleOpsApplied(List<MatchOpDTO>)
      -> _pendingBatches.Enqueue((ops, combat, fx))
      -> ApplyOpsSequential -> ApplyOpsInner
  [BoardWsApplier.txt; RVA 0x744CF0 / 0x740690 / 0x740600]
      |
      | giữ nguyên thứ tự ops do server gửi
      +--> SWAP   -> ApplySwap(...)
      +--> DESTROY-> ApplyDestroySequenced(...)
      +--> FALL   -> ApplyFall(op.data[col, fromRow, toRow])
      `--> SPAWN  -> ApplySpawn(op)
                         |
                         | col, row, tag, multiplier lấy từ op.data
                         v
                    SpawnDotByTag(col,row,tag,multiplier,true)
                         |
                         | FindDotPrefabByTag(tag) tra Board.dots
                         v
                    UnityEngine.Object.Instantiate(prefab,...)
                         -> Dot.column / Dot.row / multiplier / originalPrefab
                         -> Board.allDots[col,row]
  [BoardWsApplier.txt:3742,4104,10001; RVA 0x742DA0 / 0x7479C0 / 0x7409F0]
      |
      v
VerifyBoardAgainstServer(WsCombatBatch.board)
  [mỗi BoardCellDTO cũng có tag; RVA 0x748D50]
```

Flow trên không suy từ tên method. Các cạnh quan trọng đều có native call hoặc event subscription trong ISIL.

## 1. Đường gửi move và nhận response

### Gửi move

| Type/method | Exact signature | Evidence | Confidence |
|---|---|---|---|
| `Dot.RequestSwap` | `void RequestSwap(int fromCol, int fromRow, int toCol, int toRow)` | Khi WS mode active, gọi `MatchService.SendMove`. `Dot.txt:1156`; token `0x06001E4D`, RVA `0x5DC610`. | HIGH |
| `MatchService.SendMove` | `void SendMove(int fromCol, int fromRow, int toCol, int toRow)` | Kiểm tra match id, tăng `_localSeqNum`, lưu last move, gọi `WsMatchClient.SendMove`. `MatchService.txt:10437`; token `0x06000EDF`, RVA `0x4A51D0`. | HIGH |
| `WsMatchClient.SendMove` | `void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum)` | Forward sang `ChatService.SendMatchMove`. `WsMatchClient.txt:5790`; token `0x06001031`, RVA `0x4D4600`. | HIGH |
| `ChatService.SendMatchMove` | `void SendMatchMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum)` | Tạo `ChatMessageDTO` type `MATCH_MOVE_REQ` và gửi qua WebSocket. `ChatService.txt:24459`; token `0x06000DA2`, RVA `0x4907F0`. | HIGH |

### Nhận response

`ChatService.OnWebSocketMessage(object sender, MessageEventArgs e)` deserializes message và đưa việc dispatch về main thread (`ChatService.txt:16906`; token `0x06000D70`, RVA `0x48E730`). Display-class dispatch có literal chính xác `"MATCH_MOVE_RES"` tại:

- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService_NestedType___c__DisplayClass240_0.txt:2246`.

`WsMatchClient.Subscribe()` đăng ký handler nhận event move response (`WsMatchClient.txt:4968`; token `0x0600102D`, RVA `0x4D4870`). `MatchService.HandleMatchMoveRes(ChatMessageDTO m)` sau đó gọi `HandleResEnvelope(m, "MOVE")` (`MatchService.txt:13592`; token `0x06000EFA`, RVA `0x4A1BD0`). Confidence: **HIGH**.

## 2. DTO và nguồn gốc của tag

### Transport DTO

`ChatMessageDTO` có các field liên quan:

| Field | Type | Offset |
|---|---|---:|
| `type` | `string` | `+0x30` |
| `matchId` | `string` | `+0xB0` |
| `seqNum` | `long` | `+0xB8` |
| `matchPayload` | `Dictionary<string, object>` | `+0xC8` |

Source: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs`.

`MatchService.HandleResEnvelope(ChatMessageDTO m, string kind)`:

1. xác minh `m.matchId` với current match;
2. gọi `ParseOps(m.matchPayload)`;
3. apply state delta;
4. gọi `ParseCombatBatch(m)`;
5. lưu combat batch vào `PendingCombat`;
6. phát `OnOpsApplied(List<MatchOpDTO>)`.

Source: `MatchService.txt:14685`; token `0x06000F01`, RVA `0x4A2AB0`. Confidence: **HIGH**.

### Operation DTO

`MatchService.ParseOps(Dictionary<string,object> payload)` dùng literal key `"ops"` và Newtonsoft `JToken.ToObject` để tạo `List<MatchOpDTO>` (`MatchService.txt:17743`, literal tại `:17885`; token `0x06000F14`, RVA `0x4A3B20`).

`MatchOpDTO` có đúng:

| Field | Type | Offset |
|---|---|---:|
| `type` | `string` | `+0x10` |
| `data` | `Dictionary<string, object>` | `+0x18` |

Source: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchOpDTO.cs`.

Từ các literal key và field access, wire shape có thể reconstruct chính xác ở mức schema như sau. Đây là schema chứng minh bằng deserializer/consumer, **không phải packet capture**:

```json
{
  "type": "MATCH_MOVE_RES",
  "matchPayload": {
    "ops": [
      {
        "type": "SPAWN",
        "data": {
          "col": 0,
          "row": 0,
          "tag": "<exact server tag>",
          "multiplier": 1
        }
      }
    ]
  }
}
```

`col`, `row`, `tag`, `multiplier` literals xuất hiện trực tiếp trong `BoardWsApplier.ApplySpawn` tại `BoardWsApplier.txt:10203`, `:10208`, `:10220`, `:10252`. Confidence: **HIGH**.

### Final-board DTO trong cùng response

`MatchService.ParseCombatBatch(ChatMessageDTO m)` cũng parse các key `srvSeq`, `actorUsername`, `totalDamageDisplay`, `combatSteps`, `destroyedByTag`, và `board`. Key `board` được chuyển thành `BoardCellDTO[][]` rồi lưu tại `WsCombatBatch.board +0x38` (`MatchService.txt:5874`, key tại `:6440`; token `0x06000EB3`, RVA `0x4A3070`).

`BoardCellDTO` có đúng:

| Field | Type | Offset |
|---|---|---:|
| `col` | `int` | `+0x10` |
| `row` | `int` | `+0x14` |
| `tag` | `string` | `+0x18` |
| `multiplier` | `int` | `+0x20` |

Source: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs` và `WsCombatBatch.cs`.

Sau khi ops đã render và fall settle, `ApplyOpsSequential` gọi `VerifyBoardAgainstServer(combat.board)`. Nếu cell local sai, method này cũng gọi `SpawnDotByTag` bằng `BoardCellDTO.tag` và multiplier từ server snapshot. Vì vậy response có hai nguồn server-side đồng thuận:

- op delta `SPAWN.data.tag` để animate;
- final `WsCombatBatch.board[*][*].tag` để verify/repair.

Confidence: **HIGH**.

## 3. Thứ tự SWAP / DESTROY / FALL / SPAWN

`BoardWsApplier.TrySubscribe()` đăng ký `MatchService.OnOpsApplied`; `HandleOpsApplied(List<MatchOpDTO>)` gọi `ConsumePendingCombat()` và enqueue tuple `(ops, combat, fx)` vào:

```text
BoardWsApplier._pendingBatches
type   Queue<(List<MatchOpDTO>, WsCombatBatch, IEnumerator)>
offset +0x50
```

Sources:

- declaration: `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs:766`;
- `TrySubscribe`: token `0x06000BC5`, RVA `0x747F90`;
- `HandleOpsApplied`: `BoardWsApplier.txt:4962`, token `0x06000BD6`, RVA `0x744CF0`;
- `MatchService.ConsumePendingCombat()`: token `0x06000EB2`, RVA `0x4A0EC0`; nó đọc rồi clear `PendingCombat +0x170`.

Coroutine state machine `BoardWsApplier_NestedType__ApplyOpsInner_d__49.txt` duyệt `List<MatchOpDTO>` theo index, giữ nguyên thứ tự server gửi. Nó gom các op liên tiếp có type `FALL` hoặc `SPAWN`, gọi `ApplyFallOrSpawn`, rồi chờ fall settle; op khác đi qua `ApplyOp`, nơi các literal type `SWAP`, `DESTROY`, `FALL`, `SPAWN` dispatch tới method tương ứng.

Do đó pipeline client chính xác là:

```text
server-ordered ops
  -> SWAP
  -> DESTROY/remove
  -> FALL existing cells
  -> SPAWN exact tagged cells
  -> wait fall settle
  -> verify against server final board
```

Nếu một response có ordering khác, client vẫn theo ordering trong list; client không tự tính lại chuỗi op. Confidence: **HIGH**.

## 4. `ApplyFall`

Exact signature:

```csharp
private void ApplyFall(MatchOpDTO op)
```

Token `0x06000BE8`, RVA `0x73FE80`, source `BoardWsApplier.txt:9683`.

Method đọc `op.data["col"]`, `op.data["fromRow"]`, `op.data["toRow"]`, lấy GameObject hiện có từ `Board.allDots[col,fromRow]`, chuyển reference sang `[col,toRow]`, cập nhật `Dot.column/row` và đánh dấu falling. Không có tag lookup, spawn decision hay RNG. Confidence: **HIGH**.

## 5. `ApplySpawn`

Exact signature:

```csharp
private void ApplySpawn(MatchOpDTO op)
```

Token `0x06000BE9`, RVA `0x7409F0`, source `BoardWsApplier.txt:10001`.

Data flow native:

```text
col        = ReadInt(op.data, "col", 0)
row        = ReadInt(op.data, "row", 0)
tagObject  = op.data.TryGetValue("tag", out value)
tag        = value.ToString()
multiplier = max(1, ReadInt(op.data, "multiplier", 1))

if !InBounds(col,row): return/error
if string.IsNullOrEmpty(tag): return/error
if allDots[col,row] already exists: destroy it
SpawnDotByTag(col,row,tag,multiplier,true)
```

Không có bất kỳ call `Random`, seed lookup, queue pop hay tag generation nào. `ApplySpawn` là method client đầu tiên **nhận quyết định tag cuối cùng ở cấp op**. Confidence: **HIGH**.

## 6. `SpawnDotByTag`

Exact signature:

```csharp
private void SpawnDotByTag(
    int col,
    int row,
    string tag,
    int multiplier,
    bool fallFromAbove = false)
```

Token `0x06000BD3`, RVA `0x7479C0`, source `BoardWsApplier.txt:4104`.

Callers đã chứng minh:

- `ApplySpawn(MatchOpDTO)` — per-move op;
- `LoadBoardFromSnapshotCore(...)` — match start/resync board snapshot;
- `VerifyBoardAgainstServer(BoardCellDTO[][])` — repair cell mismatch.

Method gọi `FindDotPrefabByTag(tag)`, instantiate prefab, lấy component `Dot`, rồi ghi:

- `Dot.column +0x20 = col`;
- `Dot.row +0x24 = row`;
- `Dot.multiplier +0x88 = multiplier`;
- `Dot.originalPrefab +0xD8 = selected prefab`;
- `Board.allDots[col,row] = new GameObject`.

Nếu `fallFromAbove=true`, transform được đặt ở world-Y phía trên target trước khi rơi. Điều này không đổi logical row. Không có RNG. Confidence: **HIGH**.

### `FindDotPrefabByTag`

Exact signature:

```csharp
private GameObject FindDotPrefabByTag(string tag)
```

Token `0x06000BD1`, RVA `0x742DA0`, source `BoardWsApplier.txt:3742`.

Method duyệt `Board.dots`, thử match `GameObject.tag`; nếu tag không có trong TagManager thì fallback so `Object.name` không phân biệt hoa/thường. String cảnh báo native liệt kê sáu tag prefab `do/tim/trang/vang/xanh/xanhduong`. Nó **lookup** prefab bằng tag đã có; không tạo hoặc randomize tag.

## 7. Board snapshot ban đầu và resync

`HandleMatchStart`/`HandleMatchResync` đi qua bootstrap/resync rồi `LoadBoardFromSnapshot(Dictionary<string,object>)` và coroutine core. Core đọc payload key `"board"`, chuyển JArray thành `BoardCellDTO[][]`, duyệt nested array và gọi:

```text
SpawnDotByTag(colIndex, rowIndex, cell.tag, cell.multiplier, false)
```

RVAs:

| Method | Token | RVA |
|---|---:|---:|
| `LoadBoardFromSnapshot` | `0x06000BCD` | `0x746260` |
| `LoadBoardFromSnapshotCore` | `0x06000BCE` | `0x7461D0` |
| `HandleMatchStart` | `0x06000BC8` | `0x7448E0` |
| `HandleMatchResync` | `0x06000BCA` | `0x744710` |

Điều này bổ sung bằng chứng rằng server payload là source của tag cả khi khởi tạo, resync và refill sau move. Confidence: **HIGH**.

## 8. Audit RNG và seed

### Trên boss WebSocket spawn path

Không tìm thấy call tới:

- `UnityEngine.Random.Range`, `.value`, `.state`, `.InitState`;
- `System.Random.Next`, `.NextDouble`;
- custom RNG/seed generator;

trong `BoardWsApplier`, `MatchService`, `WsMatchClient`, `ChatService` move-result path hoặc `Dot.RequestSwap`. Không có key `randomSeed`, `boardSeed`, `spawnSeed`, `matchSeed` trên payload path. Confidence cho “không có RNG trên path đã trace”: **HIGH**.

### Local fallback có RNG nhưng không dùng trong active match

`Board.RefillBoard()` (token `0x06001C49`, RVA `0x5AB560`, `Board.txt:28665`) gọi `MatchService.get_UseWsGameplay()`. Getter này luôn trả `true` (`MatchService.txt:94`, RVA `0x457060`). Khi `MatchService.Instance` tồn tại và `CurrentMatchId` không rỗng, `RefillBoard()` return; chỉ khi không có active WS match mới tail-call `RefillBoardNonDeterministic()`.

`Board.RefillBoardNonDeterministic()` (token `0x06001C4A`, RVA `0x5AAFD0`, `Board.txt:28831`) có:

- integer `UnityEngine.Random.Range(0, dots.Length)` để chọn prefab, retry tránh match;
- float `UnityEngine.Random.Range(...)` để quyết định multiplier.

Đây là **client local/non-WS fallback**, không nằm trên boss server-authoritative path. Việc game có RNG ở method này không phải bằng chứng cho MODEL B.

### Các seed finding khác

- `MatchSeed.GenerateNew()` là no-op; `MatchSeed.Current` luôn trả `0`. Source: `MatchSeed.txt` và `MatchSeed.cs`. Không có caller liên quan.
- `BoardPVP.lastRefillSeed +0x314` thuộc type/path PVP khác và không có native reference chứng minh trên boss path.
- `ObfuscatedInt._rng` phục vụ obfuscation stat, không cấp tag gem.
- `Random.InitState` tìm thấy trong `CardUI`/`CardUIPVP`, không có call edge sang spawn pipeline.

Kết luận seed: **không có operative seed trên boss spawn path**. Confidence: **HIGH cho client path**, UNKNOWN cho implementation nội bộ server.

## 9. Audit pre-generated queue

Không tìm thấy field/method phù hợp `nextDot`, `nextDots`, `nextGem`, `nextGems`, `spawnQueue`, `pendingSpawn`, `future`, `upcoming`, `preview`, `refill buffer` trong các owner type của đường boss spawn.

Hai container dễ gây nhầm:

1. `BoardWsApplier._pendingBatches +0x50`: queue render chứa `ops` và `combat` **sau khi `MATCH_MOVE_RES` đã được parse**. Nó có thể giữ exact future-on-screen tags ở T1 trước animation, nhưng không tồn tại như queue gem tương lai ở T0 trước move.
2. `MatchService.PendingCombat +0x170`: `WsCombatBatch` tạm thời sau response; `ConsumePendingCombat()` đọc rồi clear. `WsCombatBatch.board +0x38` có final tag grid, nhưng cũng chỉ sau response.

Các coroutine locals giữ `List<MatchOpDTO>` trong lúc render cũng chỉ là lifetime tạm của response. Không có bằng chứng collection persistent chứa upcoming tags trước move. Confidence: **HIGH cho các container đã trace; MEDIUM cho kết luận loại trừ tuyệt đối mọi asset/runtime object không được code tham chiếu**.

## 10. Vai trò `Board.dots +0x70`

Declaration:

```text
Board.dots : UnityEngine.GameObject[] @ +0x70
```

Evidence vai trò:

- `FindDotPrefabByTag` duyệt array và so tag/name để tìm prefab;
- `SpawnDotByTag` instantiate element được chọn và lưu element đó vào `Dot.originalPrefab`;
- local fallback `RefillBoardNonDeterministic` chọn random index từ cùng array.

Do đó `Board.dots` là **catalog prefab choices**, không phải:

- current board (`Board.allDots +0x140` mới là live grid);
- object pool;
- upcoming queue;
- danh sách Dot đã spawn.

Native search không tìm thấy runtime writer vào `Board +0x70`; field public này nhiều khả năng được Unity serialize từ scene/prefab. String TagManager và docs hiện có chỉ ra sáu prefab/tag choice, nhưng exact runtime array length/order không được hard-code trong method: code luôn dùng `dots.Length`. Confidence: **HIGH về purpose; MEDIUM về population/size vì phụ thuộc serialized asset**.

## 11. Hidden row / off-screen Dot

Per-move `ApplySpawn` gọi `InBounds(col,row)` trước khi spawn. `SpawnDotByTag` ghi ngay logical `Dot.column/row` bằng coordinate hợp lệ và đặt object vào `Board.allDots[col,row]`.

Khi `fallFromAbove=true`, method chỉ tính **world-space transform Y** phía trên target dựa trên board height/row spacing, rồi `MarkFalling`. Không tạo `Dot.row=-1`, `row=height` hay một slot logical ngoài 8x8.

`ApplyFall` cũng làm việc với indices in-bounds `fromRow`/`toRow`. Không có persistent hidden `Dot` được kéo vào board; GameObject mới được `Object.Instantiate` đúng lúc `SpawnDotByTag` chạy.

Kết luận: không có MODEL E trên đường boss refill. Có animation bắt đầu ngoài vùng nhìn, nhưng không có hidden logical row/future object. Confidence: **HIGH**.

## 12. Object pool

Không có `dotPool`, `gemPool`, `inactiveDots`, `cachedDots`, recycle/reuse collection trên core path. `SpawnDotByTag` gọi `UnityEngine.Object.Instantiate`; `ApplySpawn` destroy object xung đột nếu cell đã có. Field `Board._destroyEntryPool +0x3F0` là pool GameObject cho UI/list thống kê destroy, không phải gem.

`Board.dots` chứa prefab references, không chứa các object instance để reuse. Kết luận: **không có gem object pool trên path đã trace**. Confidence: **HIGH**.

## 13. T0 / T1 / T2 và vị trí dữ liệu

| Thời điểm | Client có exact tag mới? | Vị trí chứng minh được |
|---|---|---|
| T0: board stable, trước move | **Không có evidence; đường thực thi không có source tag/seed/queue để tính** | Không tìm thấy candidate persistent nào trên spawn path |
| T1a: move đã gửi, response chưa đến | **Không** theo client data path đã trace | Chỉ có last-move coordinate/seq; chưa có ops |
| T1b: `MATCH_MOVE_RES` đã deserialize, animation chưa áp dụng | **Có** | `MatchOpDTO.data["tag"]` trong `List<MatchOpDTO>` / `_pendingBatches +0x50`; và `PendingCombat -> WsCombatBatch.board -> BoardCellDTO.tag` trước khi consume |
| T2: spawn đã render | **Có** | prefab identity/tag ở GameObject và live `Board.allDots[col,row]` |

Vì vậy câu chính xác là: client biết tag mới **sau server response nhưng có thể trước animation/refill hoàn tất**. Nó không biết tag exact trước khi gửi move theo bất kỳ state đã tìm thấy nào.

## 14. Classification và khả năng predict

### Classification

**MODEL A — SERVER GENERATED.**

Các model bị loại trên client boss path:

- MODEL B client RNG: bị loại; RNG chỉ ở local fallback không active.
- MODEL C seeded deterministic: bị loại; không có operative seed/generator trên path.
- MODEL D pre-generated queue: không tìm thấy; `_pendingBatches` là post-response render queue.
- MODEL E hidden row: bị loại; chỉ có visual world position above board.
- MODEL F hybrid: không có evidence.

### Read-only prediction

**NO — không thể predict exact future gems tại T0 chỉ bằng read-only client data đã chứng minh.**

**YES, nhưng chỉ post-response**: sau khi `MATCH_MOVE_RES` vào RAM và trước khi animation hoàn tất, reader có thể về mặt lý thuyết thấy tag trong ops/final-board DTO. Điều này là quan sát một quyết định đã nhận từ server, không phải dự đoán trước move.

## 15. Static unknowns và blocker

1. Thuật toán server chọn tag: RNG, weighted distribution, queue hay seed nội bộ server — **UNKNOWN**; client dump không chứa server code.
2. Server có precompute tag trước khi nhận move hay chỉ tạo khi xử lý move — **UNKNOWN**; điều đã chứng minh là client chỉ nhận nó trong response.
3. Exact packet sample ngoài đời chưa capture. Schema được reconstruct từ literal deserializer/consumer với confidence HIGH, nhưng không phải wire log.
4. Exact serialized length/order của `Board.dots` tại runtime chưa được đọc trong research branch; purpose đã xác minh, asset configuration cụ thể vẫn phụ thuộc runtime/serialized scene.
5. Không chứng minh được một object hoàn toàn không được code tham chiếu có chứa dữ liệu trùng hợp; không có call edge nào từ loại object như vậy sang spawn decision.

Các unknown này không ngăn classification phía client và không cần runtime observation để trả lời câu hỏi “client biết exact future gem trước move hay không” theo data path thực tế.

## 16. Primary evidence files

- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier_NestedType__ApplyOpsInner_d__49.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier_NestedType__ApplyOp_d__51.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchService.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/WsMatchClient.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ChatService_NestedType___c__DisplayClass240_0.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Dot.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchSeed.txt`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ChatMessageDTO.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchOpDTO.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardCellDTO.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/WsCombatBatch.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardWsApplier.cs`
- `docs/board_data_sources.md` và `docs/il2cpp_array_layout.md` dùng làm đối chứng; không sửa.
