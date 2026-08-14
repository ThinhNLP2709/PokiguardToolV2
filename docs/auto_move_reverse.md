# Reverse `enableAutoMove` — `Board` và `BoardPVP`

Ngày phân tích: 2026-08-12  
Build `GameAssembly.dll` SHA-256: `5A993B8AEF2371F6053AA46C692592CE32FF8418071E85357541F7FB504D58B3`  
Phạm vi: static Cpp2IL + native disassembly; không chạy game, không gọi method runtime, không patch, không ghi memory.

## Legend

- **CONFIRMED_FROM_NATIVE**: được thấy trực tiếp trong native disassembly/ISIL của build trên.
- **INFERRED**: suy luận có kiểm soát từ nhiều bằng chứng native, nhưng không có một instruction đơn lẻ biểu diễn toàn bộ kết luận.
- **UNKNOWN**: build client này không cung cấp đủ bằng chứng.

## Kết luận chính

**CONFIRMED_FROM_NATIVE:** Trong build này **không tồn tại native execution path bắt đầu bằng việc đọc `enableAutoMove`** ở cả `Board` và `BoardPVP`.

- `Board.LateUpdate()` và `BoardPVP.LateUpdate()` chỉ xử lý layout/scale của `DotsArea`; không đọc bất kỳ field auto-move nào.
- Không native method nào đọc `Board.enableAutoMove` hoặc `BoardPVP.enableAutoMove`.
- Không native method nào đọc `Board.lastAutoMoveTime` hoặc `BoardPVP.lastAutoMoveTime`.
- Reader duy nhất liên quan ba field là `Active.PinCascadeAttacker()`, đọc `Board.isAutoMoveInProgress`; nó chỉ quyết định attribution của cascade, không tạo/chấm/execute move.
- Không method nào đọc `BoardPVP.isAutoMoveInProgress`.
- `CalculateVangPriorityScore`, `CheckValidMove`, `IsTrapMove`, `CalculateTrapPotential`, `CalculateTotalMultiplierGain`, `CalculateIndirectVangDestruction`, `CalculatePotentialVangDotDestruction`, và `CalculateVangWithMultiplier` đều còn native body nhưng **không có native caller/xref** trong `Assembly-CSharp` đối với cả `Board` và `BoardPVP`.

**INFERRED:** Đây là một **dead/orphaned auto-move surface**: fields, cooldown constant và scoring helpers còn sót lại, nhưng orchestration loop đã bị loại khỏi compiled build hoặc không được nối vào execution graph.

**UNKNOWN:** Logic auto-move có thể từng tồn tại trong source version khác hay không. Static analysis chỉ kết luận cho đúng binary/hash nêu trên.

## 1. Field layout

Assembly: `Assembly-CSharp`, global namespace.

| Type | Field | Type | Offset | Native reader trong build |
|---|---|---|---:|---|
| `Board` | `enableAutoMove` | `bool` | `+0x1B8` | **Không có** |
| `Board` | `isAutoMoveInProgress` | `bool` | `+0x1D1` | `Active.PinCascadeAttacker()` |
| `Board` | `lastAutoMoveTime` | `float` | `+0x2CC` | **Không có** |
| `BoardPVP` | `enableAutoMove` | `bool` | `+0x188` | **Không có** |
| `BoardPVP` | `isAutoMoveInProgress` | `bool` | `+0x1A1` | **Không có** |
| `BoardPVP` | `lastAutoMoveTime` | `float` | `+0x264` | **Không có** |

Declarations:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:1031`, `:1035`, `:1069`;
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardPVP.cs:843`, `:847`, `:874`.

Cả hai type còn khai báo compile-time constant:

```csharp
internal const float AUTO_MOVE_COOLDOWN = 1.5f;
```

và `SwapDirections : int[][]`. Declaration không chứng minh chúng được dùng bởi một auto loop.

## 2. Phương pháp xref native

**CONFIRMED_FROM_NATIVE:** Việc enumerate reader được làm theo ba lớp:

1. kiểm tra toàn bộ method bodies của `Board`, `BoardPVP` và nested state-machine types cho exact field displacement;
2. scan toàn bộ `Assembly-CSharp` native ISIL/disassembly cho cùng displacement, sau đó xác minh provenance của object base;
3. scan direct native call targets theo VA/RVA cho các helper candidate/scoring/execution.

Kết quả exact operand quan trọng:

```text
Board +0x1B8: chỉ thấy write
Board +0x1D1: reset writes; một external read từ Active.PinCascadeAttacker
Board +0x2CC: chỉ thấy write

BoardPVP +0x188: chỉ thấy write
BoardPVP +0x1A1: chỉ thấy write
BoardPVP +0x264: chỉ thấy write
```

Các access có cùng numeric displacement trên type không liên quan đã được loại bằng object/type provenance; một offset trùng nhau không phải field xref.

Unity serialization/reflection có thể đọc public serialized field mà không sinh direct field operand trong gameplay code. Điều đó không tạo một native auto-move call graph và không được tính là gameplay reader.

## 3. Tất cả native readers của các field

### `Board.enableAutoMove +0x1B8`

**CONFIRMED_FROM_NATIVE: không có reader.**

Những instruction đã xác minh chỉ là write, ví dụ:

- `Board..ctor()` ghi `true`;
- `Board.LeaveMatchMidGame()` ghi `false`;
- `Board+<HandleNetworkError>d__247.MoveNext()` ghi `false`;
- `Board+<ShowGameResultIntegrated>d__287.MoveNext()` ghi `false`;
- `BossAI.ShowBossTimeoutPopup()` và `BossAI.FreezeBoardOnTimeout()` ghi `false`.

Không có `cmp/test/movzx/load` dùng value này để branch sang validation/candidate/scoring.

### `Board.isAutoMoveInProgress +0x1D1`

**CONFIRMED_FROM_NATIVE: đúng một reader.**

```text
Assembly-CSharp!Active.PinCascadeAttacker()
token 0x06001AF8
RVA   0x567870
```

Source: `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt:789`.

Native flow liên quan:

```text
board = Board.Instance
if (board != null &&
    !board.isAutoMoveInProgress &&
    !Active.<another cascade flag> &&
    board.playerMovedThisTurn)
{
    cascadeAttacker = Active.get_CurrentTurnPlayerActorNumber();
    cascadeAttackerPinned = false;
}
else
{
    cascadeAttackerPinned = true / retain previous actor;
}
```

Phần tên của các `Active` private fields ở trên được mô tả theo hành vi; exact offsets là `Active +0x324`, `+0x23C`, `+0x240`. Điều đã xác nhận trực tiếp là branch `cmp byte ptr [Board+0x1D1],0`.

`Board.OnTurnStartNotify(int)` và `TurnManager.HandleWsTurnEnd()` reset field về `false`. Không tìm thấy writer ghi `true` trong build.

**INFERRED:** Field này từng được thiết kế để ngăn cascade do auto move bị attribution như input người chơi, nhưng auto executor tương ứng không còn nối vào build.

### `Board.lastAutoMoveTime +0x2CC`

**CONFIRMED_FROM_NATIVE: không có reader.**

- `Board..ctor()` không có instruction ghi explicit vào `+0x2CC`.
- Native writer duy nhất tìm được là `Board.OnTurnStartNotify(int)`, ghi `Time.time`.
- Không có `Time.time - lastAutoMoveTime`, compare với `1.5f`, hay load nào từ `+0x2CC`.

Vì vậy `AUTO_MOVE_COOLDOWN = 1.5f` không tham gia một compiled auto-move gate.

### Ba field của `BoardPVP`

**CONFIRMED_FROM_NATIVE:**

- `BoardPVP.enableAutoMove +0x188`: không reader; constructor ghi `true`, các exit/error/result paths ghi `false`.
- `BoardPVP.isAutoMoveInProgress +0x1A1`: không reader; `OnTurnStartNotify` reset `false`.
- `BoardPVP.lastAutoMoveTime +0x264`: không reader; `OnTurnStartNotify` ghi `Time.time`.

Không có `ActivePVP` method tương đương đọc `BoardPVP.isAutoMoveInProgress` trong dump này.

## 4. `Board.LateUpdate`

```text
exact signature: private void LateUpdate()
token:           0x06001C05
RVA:             0x5A85F0
native length:   0x28F
source:          Board.txt:8685
```

**CONFIRMED_FROM_NATIVE:** Pseudocode:

```csharp
void LateUpdate()
{
    if (!HasExplicitDotsParent())
        EnsureRuntimeDotsParent();

    RectTransform shell = asRectTransform(
        HasExplicitDotsParent() ? dotsParent : runtimeDotsParent);

    if (shell != null)
    {
        Vector2 size = shell.rect.size;
        float delta = distance(size, _lastDotsShellRectSize);
        float threshold = max(constant, min(shell.rect.width,
                                             shell.rect.height) * constant);

        if (delta > threshold &&
            Time.unscaledTime - _lastCanvasForceUnscaledTime >=
                MinSecondsBetweenCanvasForceRebuild)
        {
            Canvas.ForceUpdateCanvases();
            _lastDotsShellRectSize = size;
            _lastCanvasForceUnscaledTime = Time.unscaledTime;
            invalidate cached layout/mask state;
        }
    }

    UpdateDotsPlayfieldLayout();

    if (useEvenSpacingFromDotsArea &&
        autoScaleDotsToFitGridCells &&
        !useSlotPositions)
    {
        ApplyDotScaleToFitGridCells();
    }
}
```

Field checks cuối method là `Board +0xC0`, `+0xCD`, `+0x94`. Không có read `+0x1B8`, `+0x1D1`, hay `+0x2CC`; không call auto helper nào.

## 5. `BoardPVP.LateUpdate`

```text
exact signature: private void LateUpdate()
token:           0x060002CB
RVA:             0x58D9E0
native length:   0x28C
source:          BoardPVP.txt:1261
```

**CONFIRMED_FROM_NATIVE:** Logic tương đương `Board.LateUpdate`, với layout offsets của `BoardPVP`:

```text
dotsParent/runtimeDotsParent       +0xC0 / +0xC8
_lastDotsShellRectSize             +0xFC / +0x100
_lastCanvasForceUnscaledTime       +0x104
useEvenSpacingFromDotsArea         +0xA8
autoScaleDotsToFitGridCells        +0xB5
useSlotPositions                   +0x7C
```

Nó gọi `BoardPVP.UpdateDotsPlayfieldLayout()` và có thể gọi `ApplyDotScaleToFitGridCells()`. Không đọc ba field auto-move và không gọi candidate/scoring/execution helper.

## 6. Call graph thực tế: không có auto-move root

### Graph được yêu cầu

**CONFIRMED_FROM_NATIVE:** Không thể dựng một positive graph kiểu:

```text
enableAutoMove check
  -> turn validation
  -> board stability
  -> cooldown
  -> candidate generation
  -> scoring
  -> swap execution
```

vì node đầu tiên — **native read/check `enableAutoMove` — không tồn tại**.

Graph chính xác của compiled build là:

```text
Board.enableAutoMove / BoardPVP.enableAutoMove
                 |
                 X  no native read/xref
                 |
                 +--X IsPlayerAllowedToMove
                 +--X CheckBoardStable
                 +--X CheckValidMove / candidate loop
                 +--X CalculateVangPriorityScore
                 `--X ExecuteSwapToNeighbor / RequestSwap / SendMove
```

### Các helper rời rạc còn tồn tại

| Stage dự kiến | Native method còn tồn tại | Xref thực tế | Status |
|---|---|---|---|
| Turn validation | `Board.IsPlayerAllowedToMove()` / PVP | Được `Dot.CanInteract`, Card/CardUI paths gọi cho input/skill | **CONFIRMED_FROM_NATIVE: không từ auto** |
| Board stability | `CheckBoardStable()` | Được post-fill stability coroutine gọi | **CONFIRMED_FROM_NATIVE: không từ auto** |
| Cooldown | constant `1.5f`, `lastAutoMoveTime` | Không reader của time field | **CONFIRMED_FROM_NATIVE: inactive** |
| Candidate validation | `CheckValidMove(...)` | Không native caller | **CONFIRMED_FROM_NATIVE: orphaned** |
| Candidate subroutine | `CheckChain(...)` | Chỉ được `CheckValidMove` gọi | **CONFIRMED_FROM_NATIVE: unreachable từ auto root** |
| Trap/metric helpers | `IsTrapMove`, `CalculateTrapPotential`, `Calculate*Gain/Destruction` | Không native caller | **CONFIRMED_FROM_NATIVE: orphaned** |
| Move scoring | `CalculateVangPriorityScore(...)` | Không native caller | **CONFIRMED_FROM_NATIVE: orphaned** |
| Final auto swap | không có caller/source Dot từ Board/PVP | Không tồn tại | **UNKNOWN as historical design; absent in this build** |

### Turn-validation helper độc lập

`Board.IsPlayerAllowedToMove()` (RVA `0x5A8040`) và PVP counterpart (RVA `0x58D430`) yêu cầu, ở mức native:

```text
!isGameOver
active != null
MatchService.Instance != null
CurrentMatchId non-empty
!MatchService.IsStartGatePaused
MatchService.IsLocalTurn
!isProcessingUI
!hasDestroyedThisTurn
currentState == move
```

**CONFIRMED_FROM_NATIVE:** Helper này không đọc `enableAutoMove`, `isAutoMoveInProgress` hoặc `lastAutoMoveTime`.

### Board-stability helper độc lập

`CheckBoardStable()` duyệt toàn bộ `allDots`; trả `false` nếu cell null/missing hoặc `Dot.isMathched +0x38` đang là `true`, ngược lại `true`. Nó không kiểm tra `_isFalling +0xB0` trong method này và không đọc auto fields. Native RVAs:

- `Board.CheckBoardStable`: `0x59C550`;
- `BoardPVP.CheckBoardStable`: `0x583700`.

## 7. `CalculateVangPriorityScore`

Exact signatures giống nhau:

```csharp
public float CalculateVangPriorityScore(
    GameObject dot,
    int targetX,
    int targetY,
    int chainLength,
    bool isComplexChain,
    string tag,
    bool isTrap,
    int trapPotential,
    int multiplierValue,
    int totalMultiplierGain,
    int vangDestroyed,
    int vangWithMultiplier);
```

| Type | Token | RVA | Length | Source |
|---|---:|---:|---:|---|
| `Board` | `0x06001C2D` | `0x59B9D0` | `0x2AA` | `Board.txt:17748` |
| `BoardPVP` | `0x0600030D` | `0x582B90` | `0x2AA` | `BoardPVP.txt:15926` |

**CONFIRMED_FROM_NATIVE:** Hai native bodies có cùng control flow và constants. `dot`, `targetX`, `targetY` không được dùng trong scoring body.

### Exact constants từ `GameAssembly.dll/.rdata`

| Meaning | Value | Build RVA |
|---|---:|---:|
| tag `"xanh Dot"` | `80` | `0x2A50494` |
| tag `"trang Dot"` | `60` | `0x2A4FC00` |
| tag `"xanhduong Dot"` | `40` | `0x2A4FEC4` |
| tag `"do Dot"` | `15` | `0x2A501E4` |
| tag `"tim Dot"` | `10` | `0x2A4FBE0` |
| complex-chain multiplier | `2.5` | `0x2A4FBCC` |
| chain-length factor | `10` | `0x2A4FBE0` |
| trap-potential factor | `50` | `0x2A5047C` |
| trap base bonus | `300` | `0x2A4FEE8` |
| multiplier value `2` bonus | `150` | `0x2A4FC18` |
| multiplier value `3` bonus | `250` | `0x2A4FEE4` |
| multiplier value `>=4` bonus | `400` | `0x2A506FC` |
| total multiplier gain factor | `80` | `0x2A50494` |
| each vàng destroyed | `2000` | `0x2A50704` |
| base bonus khi có vàng destroyed | `10000` | `0x2A50710` |
| vàng-with-multiplier `2` bonus | `1500` | `0x2A50700` |
| vàng-with-multiplier `3` bonus | `3000` | `0x2A50708` |
| vàng-with-multiplier `>=4` bonus | `5000` | `0x2A5070C` |
| exactly 4 vàng destroyed bonus | `1000` | `0x2A4FEF0` |
| `>=5` vàng destroyed bonus | `2000` | `0x2A50704` |

### Pseudocode chính xác

```csharp
float CalculateVangPriorityScore(...)
{
    if (vangDestroyed > 0)
    {
        float score = 10_000f + 2_000f * vangDestroyed;

        if (vangWithMultiplier >= 4)
            score += 5_000f;
        else if (vangWithMultiplier >= 3)
            score += 3_000f;
        else if (vangWithMultiplier >= 2)
            score += 1_500f;

        if (vangDestroyed >= 5)
            score += 2_000f;
        else if (vangDestroyed >= 4)
            score += 1_000f;

        return score;
    }

    float score = tag switch
    {
        "xanh Dot"      => 80f,
        "trang Dot"     => 60f,
        "xanhduong Dot" => 40f,
        "do Dot"        => 15f,
        "tim Dot"       => 10f,
        _                => 0f
    };

    if (isComplexChain)
        score *= 2.5f;

    score += 10f * chainLength;

    if (isTrap)
        score += 300f + 50f * trapPotential;

    if (multiplierValue >= 4)
        score += 400f;
    else if (multiplierValue >= 3)
        score += 250f;
    else if (multiplierValue >= 2)
        score += 150f;

    score += 80f * totalMultiplierGain;
    return score;
}
```

**CONFIRMED_FROM_NATIVE:** Khi `vangDestroyed > 0`, method bỏ qua tag weight, complex-chain, chain length, trap, `multiplierValue` và `totalMultiplierGain`; chỉ dùng `vangDestroyed` và `vangWithMultiplier`.

**CONFIRMED_FROM_NATIVE:** Không có native xref/caller tới method scoring ở cả hai type. Công thức trên tồn tại nhưng không chứng minh một move selector đang dùng nó.

## 8. Function cuối thực hiện move

### Auto-move

**CONFIRMED_FROM_NATIVE:** Không có final auto-move function trong compiled call graph, vì không có auto root/candidate/scoring caller.

Do đó không thể gán chính xác “auto cuối cùng gọi `RequestSwap` hay `ExecuteSwapToNeighbor`” cho build này. Câu trả lời đúng là:

```text
Final auto executor: ABSENT / UNKNOWN historical implementation
```

### Interactive move path hiện hữu

Để phân biệt với auto logic, native input path thực tế là:

```text
Dot.MovePieces()                 (swipe)
    or
Dot.AttemptTapSelectOrSwap()     (tap-select)
        |
        v
Dot.ExecuteSwapToNeighbor(targetCol,targetRow)
        |
        | validates Board/BoardPVP, turn/input state,
        | adjacency, target Dot; sets visual swap targets
        v
MatchService.SendMove(fromCol,fromRow,toCol,toRow)  [WS mode]
```

Native evidence:

| Method | Token | RVA | Finding |
|---|---:|---:|---|
| `Dot.MovePieces` | `0x06001E63` | `0x5DBEC0` | calls `ExecuteSwapToNeighbor` |
| `Dot.AttemptTapSelectOrSwap` | `0x06001E66` | `0x5DA920` | tail-jumps to `ExecuteSwapToNeighbor` |
| `Dot.ExecuteSwapToNeighbor` | `0x06001E64` | `0x5DB6E0` | directly calls `MatchService.SendMove` in WS mode |
| `Dot.RequestSwap` | `0x06001E4D` | `0x5DC610` | separately calls `MatchService.SendMove`, nhưng có zero native caller |
| `MatchService.SendMove` | `0x06000EDF` | `0x4A51D0` | final client request construction/forwarding stage |

**CONFIRMED_FROM_NATIVE:** `ExecuteSwapToNeighbor` không gọi `RequestSwap`; nó gọi `MatchService.SendMove` trực tiếp. `RequestSwap` là wrapper orphaned trong static xref của build này.

## 9. Final classification

| Question | Result | Classification |
|---|---|---|
| `LateUpdate` có check `enableAutoMove`? | Không, cả Board và PVP | **CONFIRMED_FROM_NATIVE** |
| Có method khác check `enableAutoMove`? | Không có direct native reader | **CONFIRMED_FROM_NATIVE** |
| Có cooldown active? | Không; `lastAutoMoveTime` không được đọc | **CONFIRMED_FROM_NATIVE** |
| Có candidate generator nối với enable flag? | Không | **CONFIRMED_FROM_NATIVE** |
| Scoring formula có native body? | Có, công thức đã recover đầy đủ | **CONFIRMED_FROM_NATIVE** |
| Scoring được gọi? | Không có native caller | **CONFIRMED_FROM_NATIVE** |
| Có final auto swap call? | Không có trong compiled graph | **CONFIRMED_FROM_NATIVE** về absence; historical design **UNKNOWN** |
| Vì sao fields/helpers còn tồn tại? | Có khả năng feature đã bị bỏ/strip khỏi orchestration | **INFERRED** |

## 10. UNKNOWN và giới hạn

1. Source revision nào từng chứa auto orchestration, nếu có: **UNKNOWN**.
2. Một build khác có thể có `Update/LateUpdate` khác: **UNKNOWN**; kết luận build-specific.
3. Unity inspector có thể serialize giá trị `enableAutoMove`; vì không có gameplay reader, giá trị đó không tạo execution path trong build này.
4. Dynamic reflection có thể đọc field về mặt kỹ thuật, nhưng không tìm thấy string/reflection call nối sang auto helpers; không có evidence cho gameplay use.
5. Không chạy runtime để quan sát, đúng yêu cầu static-only.

## 11. Primary evidence

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/BoardPVP.cs`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardPVP.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/TurnManager.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Dot.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board_NestedType__HandleNetworkError_d__247.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board_NestedType__ShowGameResultIntegrated_d__287.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardPVP_NestedType__HandleNetworkError_d__225.txt`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardPVP_NestedType__ShowGameResultIntegrated_d__262.txt`
- read-only `.rdata` extraction từ `D:\pc\GameAssembly.dll` để resolve float constants.
