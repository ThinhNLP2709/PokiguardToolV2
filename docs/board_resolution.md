# Board instance resolution — Phase 1

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
