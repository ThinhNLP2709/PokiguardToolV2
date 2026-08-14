# Pokiguard IL2CPP Memory/Bridge Research Guide

> Mục tiêu của tài liệu này: bàn giao toàn bộ hướng nghiên cứu hiện tại cho Codex để tiếp tục xây dựng phiên bản bot **đọc state trực tiếp từ game**, trong khi **giữ nguyên solver/logic farm Python hiện có**.
>
> Phạm vi khuyến nghị ban đầu: **read-only đối với memory/game state**, không sửa HP, damage, reward, fragment, không giả packet. Việc thực hiện nước đi vẫn đi qua input bình thường để game tự xử lý luồng mạng/server.

---

## 1. Bối cảnh project

Game:

- Process/exe: `Pokiguard.exe`
- Window title quan sát được: `PokiguardOnlines`
- Game dựng bằng Unity, build Windows x64.
- Gameplay match-3 8x8.
- Bot Python hiện tại đã chạy ổn bằng:
  - capture màn hình;
  - OpenCV/cv2 template matching;
  - solver logic riêng;
  - thực hiện kéo chuột.

Mục tiêu mới:

- Không bỏ solver Python đã có.
- Thử thay lớp `Screen/CV -> BoardState` bằng `Game memory -> BoardState`.
- Nếu external memory read không đủ ổn định để tìm object IL2CPP, nâng lên bridge DLL chạy trong process.
- Solver vẫn là solver của chúng ta; tuyệt đối không dựa vào `enableAutoMove` của game.

---

## 2. Data gameplay đã chốt

Board là 8x8.

Các loại gem:

```text
SWORD  = Kiếm, màu vàng, hình kiếm
MANA   = Mana, xanh dương, hình sấm sét
RAGE   = Nộ, đỏ, hình lửa
SHIELD = Khiên, tím, hình khiên
HEAL   = Máu, xanh lá, hình trái tim
DRAIN  = Hút, xám/bạc, hình âm dương
```

Test case đã có:

- Ảnh trước: `base.png`
- Ảnh sau: `update.png`
- Người chơi swap:
  - row 5, col 6 = SHIELD
  - row 5, col 7 = DRAIN
- Sau swap tạo hai match đồng thời:
  - SHIELD x3
  - DRAIN x3

Đánh số row/col từ 1 trong mô tả UI; code nội bộ nên chuẩn hóa thành 0-based và chỉ convert ở boundary.

---

## 3. Những gì đã xác minh từ file người dùng cung cấp

### 3.1 Unity version

Từ `Player.log`:

```text
Initialize engine version: 6000.0.26f1
```

=> Unity version:

```text
6000.0.26f1
```

### 3.2 Client version

Từ `Player.log`:

```text
[AppVersionGate] mode=NONE client=1.7.1 latest=1.7.1 min= channel=prod
```

=> client hiện quan sát được:

```text
1.7.1
channel=prod
```

### 3.3 Boss match dùng server-authoritative state

Log có:

```text
[BossItem] WS gameplay — StartMatch (server-authoritative boss session)
```

Ngoài ra khi client/MATCH_PREP và server lệch HP boss, log ghi rõ giữ số server:

```text
server maxHP=9999999 ...
MATCH_PREP maxHP=16999998 ...
GIỮ SỐ SERVER
```

Kết luận kỹ thuật:

- Không thiết kế tool dựa trên sửa `BossHp`, reward, fragment hoặc damage trong client.
- Mục tiêu an toàn/ổn định hơn là:
  1. đọc state;
  2. chọn nước hợp lệ;
  3. để client gửi nước theo flow bình thường;
  4. server vẫn authoritative.

### 3.4 Các class/runtime name lộ trực tiếp trong log

Đã nhìn thấy trong `Player.log`:

```text
ManagerBoss
BossItem
BossRoomBridge
ManagerMatch
Active
UIUpdateManager
Board
BoardWsApplier
MatchService
```

Các handler đáng chú ý:

```text
BoardWsApplier:HandleMatchResync
MatchService:HandleMatchResync

BoardWsApplier:HandleMatchStart
MatchService:HandleMatchStart
```

### 3.5 `global-metadata.dat`

Đã đọc header trực tiếp:

```text
Magic:            0xFAB11BAF
Metadata version: 31
Size:             14,576,856 bytes
```

16 byte đầu:

```text
AF 1B B1 FA 1F 00 00 00 00 01 00 00 28 91 02 00
```

`0x1F = 31`.

### 3.6 `GameAssembly.dll`

Đã xác minh:

```text
PE32+
Windows DLL
x86-64
```

GameAssembly export các IL2CPP API, trong đó đã xác minh có:

```text
il2cpp_class_from_name
il2cpp_domain_get
il2cpp_domain_get_assemblies
il2cpp_field_get_offset
il2cpp_runtime_invoke
il2cpp_thread_attach
```

Điều này rất hữu ích nếu sau này dùng **internal bridge DLL**, vì code chạy trong process có thể resolve và gọi các IL2CPP export trực tiếp.

### 3.7 Các string quan trọng đã thấy trong metadata

Đã tìm trực tiếp trong `global-metadata.dat`:

```text
Board
BoardWsApplier
MatchService
PlayerStats
BoardCellDTO

allDots
dots

enableAutoMove
isAutoMoveInProgress
lastAutoMoveTime
AUTO_MOVE_COOLDOWN

CheckValidMove
WouldCreateMatch
HasValidMoves
SimulateMatchesAfterMove

RequestSwap
SendMove

LoadBoardFromSnapshot
ApplySwap
ApplyFall
ApplySpawn
VerifyBoardAgainstServer

BoardWidth
BoardHeight
CurrentTurnPlayer
TurnNumber

BossHp
BossHpMax

LastMoveFromCol
LastMoveFromRow
LastMoveToCol
LastMoveToRow
LastMoveSeqNum

currentHP
maxHP
currentMana
maxMana
currentPower
maxPower
shield
```

**Quan trọng:** việc string tồn tại trong metadata là xác minh chắc chắn. Tuy nhiên quan hệ chính xác kiểu:

```text
Board.allDots
PlayerStats.currentHP
MatchService.SendMove
```

cần được Cpp2IL/dummy DLL hoặc metadata parser reconstruct lại trước khi code production dựa vào chúng.

Không giả định ownership/offset chỉ từ string search.

---

# 4. Kiến trúc khuyến nghị

Vì solver Python hiện tại đã ổn, **không rewrite solver sang C#** ở thời điểm này.

Kiến trúc nên là:

```text
┌──────────────────────────────┐
│ Existing Python Bot          │
│                              │
│ Solver / strategy / UI       │
│ đã chạy ổn                   │
└──────────────┬───────────────┘
               │
               │ IBoardStateProvider
               ▼
       ┌───────────────────┐
       │ Provider A        │
       │ CV/OpenCV         │  <- fallback hiện tại
       └───────────────────┘

               HOẶC

       ┌───────────────────┐
       │ Provider B        │
       │ External Memory   │  <- phase đầu
       └───────────────────┘

               HOẶC

       ┌───────────────────┐
       │ Provider C        │
       │ IL2CPP Bridge DLL │  <- phase sau nếu cần
       └───────────────────┘
```

Interface logic:

```python
class BoardStateProvider:
    def read(self) -> "GameState":
        ...
```

Ví dụ model:

```python
from dataclasses import dataclass
from enum import IntEnum


class GemType(IntEnum):
    UNKNOWN = 0
    SWORD = 1
    MANA = 2
    RAGE = 3
    SHIELD = 4
    HEAL = 5
    DRAIN = 6


@dataclass
class GameState:
    board: list[list[GemType]]
    my_hp: int | None = None
    my_max_hp: int | None = None
    mana: int | None = None
    max_mana: int | None = None
    rage: int | None = None
    max_rage: int | None = None
    shield: int | None = None
    current_turn: int | None = None
    turn_number: int | None = None
    board_stable: bool | None = None
```

Solver không được biết state đến từ CV hay memory:

```python
state = provider.read()
best_move = solver.find_best_move(state)
executor.execute(best_move)
```

---

# 5. Phương án can thiệp game

Có 3 mức. Nên đi lần lượt.

---

## Level A — External read-only memory reader

### Mục tiêu

Process riêng:

```text
python.exe
   │
   ├─ find Pokiguard.exe
   ├─ OpenProcess(...)
   ├─ locate GameAssembly.dll base
   ├─ ReadProcessMemory(...)
   └─ deserialize board/state
```

Không inject DLL.

Không `WriteProcessMemory`.

Không gọi network function.

### Windows API cần dùng

```text
OpenProcess
ReadProcessMemory
CloseHandle

CreateToolhelp32Snapshot
Process32First/Next       (nếu cần PID)
Module32First/Next        (để lấy module base)
```

Hoặc PID lấy bằng `psutil`, module enumeration vẫn có thể dùng WinAPI.

Access tối thiểu:

```text
PROCESS_QUERY_INFORMATION
PROCESS_VM_READ
```

Không xin `PROCESS_ALL_ACCESS` nếu không cần.

### Python

Có thể làm hoàn toàn bằng `ctypes` built-in.

Không bắt buộc `pymem`.

Skeleton:

```python
import ctypes
from ctypes import wintypes

kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)

PROCESS_VM_READ = 0x0010
PROCESS_QUERY_INFORMATION = 0x0400

kernel32.OpenProcess.argtypes = [
    wintypes.DWORD,
    wintypes.BOOL,
    wintypes.DWORD,
]
kernel32.OpenProcess.restype = wintypes.HANDLE

kernel32.ReadProcessMemory.argtypes = [
    wintypes.HANDLE,
    wintypes.LPCVOID,
    wintypes.LPVOID,
    ctypes.c_size_t,
    ctypes.POINTER(ctypes.c_size_t),
]
kernel32.ReadProcessMemory.restype = wintypes.BOOL
```

Helper:

```python
def read_bytes(handle, address: int, size: int) -> bytes:
    buf = (ctypes.c_ubyte * size)()
    read = ctypes.c_size_t()

    ok = kernel32.ReadProcessMemory(
        handle,
        ctypes.c_void_p(address),
        buf,
        size,
        ctypes.byref(read),
    )

    if not ok:
        raise ctypes.WinError(ctypes.get_last_error())

    return bytes(buf[:read.value])
```

### Milestone A1

Codex phải tạo:

```text
tools/
  memory_probe.py
```

Output mong muốn:

```text
Pokiguard.exe found
PID: 12345
Architecture: x64

GameAssembly.dll
Base: 0x00007FFA........
Size: 0x........
```

### Milestone A2

Đọc thử byte ở một vùng readable trong `GameAssembly.dll` và xác nhận `ReadProcessMemory` hoạt động.

Không scan toàn RAM ngay.

### Hạn chế lớn của Level A

IL2CPP object như `Board` không nhất thiết có một pointer tĩnh đơn giản.

External process **không thể chỉ lấy địa chỉ export `il2cpp_domain_get` rồi gọi như local function**. Function đó nằm trong address space của process game.

Muốn invoke IL2CPP API trực tiếp thì cần code chạy trong process (Level B), hoặc một kỹ thuật remote-call phức tạp mà project này không cần ở phase đầu.

Vì vậy Level A chỉ hiệu quả nếu Cpp2IL/reverse engineering cho ta được:

- static field location;
- singleton pointer;
- RVA/pointer chain;
- hoặc native structure có thể resolve ổn định.

---

# 6. Offline reverse bằng Cpp2IL

Đây là bước nên làm **trước khi scan memory mù**.

Game folder:

```text
D:\pc\
├─ Pokiguard.exe
├─ GameAssembly.dll
├─ UnityPlayer.dll
└─ Pokiguard_Data\
   └─ il2cpp_data\
      └─ Metadata\
         └─ global-metadata.dat
```

Cpp2IL hỗ trợ Windows Unity game qua `--game-path` và có support metadata v31/recent Unity trong các release mới.

### Chạy

Đầu tiên:

```powershell
Cpp2IL-Win.exe --list-output-formats
```

Sau đó thử:

```powershell
Cpp2IL-Win.exe `
  --game-path="D:\pc" `
  --exe-name=Pokiguard `
  --output-as=dummydll `
  --output-to="D:\poki_reverse\cpp2il_out"
```

Nếu CLI/version đang dùng đặt tên output format khác, dùng output name chính xác từ `--list-output-formats`.

### Codex cần tìm trong output

Ưu tiên:

```text
Board
BoardCellDTO
Dot
BoardWsApplier
MatchService
PlayerStats
Active
ManagerMatch
```

Search các member:

```text
allDots
dots
width
height
currentState

column
row
tag
multiplier

CurrentTurnPlayer
TurnNumber

currentHP
maxHP
currentMana
maxMana
currentPower
maxPower
shield

SendMove
RequestSwap
LoadBoardFromSnapshot
```

### Deliverable reverse

Codex tạo file:

```text
docs/il2cpp_symbols.md
```

Mỗi item phải ghi:

```text
Type:
Namespace:
Assembly:
Member:
Kind: field/method/property
Static?: yes/no
Field type:
Field offset:
Method RVA:
Evidence source:
Confidence:
```

Ví dụ:

```text
Type: Board
Assembly: Assembly-CSharp
Member: allDots
Kind: field
Static: no
Field type: ...
Field offset: 0x??
Confidence: confirmed-by-cpp2il
```

Không được điền offset bằng đoán.

---

# 7. Cách tìm `Board` instance cho external reader

Đây là bài toán chính của Level A.

Thứ tự nghiên cứu:

### Strategy A — singleton/static field

Tìm trong dummy output:

```text
Board.Instance
Board.instance
Board._instance
ManagerMatch.board
Active.board
...
```

Nếu có static pointer ổn định:

```text
GameAssembly base
  + RVA static data / metadata mapping
  -> Il2CppClass
  -> static_fields
  -> Board*
```

Cần xác nhận exact layout cho Unity/IL2CPP version đang dùng.

### Strategy B — owner object

Nếu `Board` được giữ bởi `ManagerMatch`, `MatchService`, scene controller hoặc singleton khác:

```text
Singleton -> field -> Board*
```

Ưu tiên pointer chain ngắn và có validation.

### Strategy C — native pattern/RVA

Nếu Cpp2IL cho native method RVA của function liên quan đến board, có thể disassemble để tìm global/static pointer được method sử dụng.

Không hard-code absolute address:

```text
SAI:
0x7FFA12345678

ĐÚNG:
GameAssemblyBase + RVA
```

ASLR làm module base thay đổi giữa mỗi run.

### Validation bắt buộc

Một `Board*` candidate chỉ được accept nếu:

```text
width == 8
height == 8
```

và grid chứa đúng ~64 object/pointer hợp lệ.

Nếu có `row`, `column`, `tag`, phải thỏa:

```text
0 <= row < 8
0 <= col < 8
```

Không dereference chain vô hạn.

Mỗi pointer phải được validate readable trước khi đọc tiếp.

---

# 8. Level B — Internal IL2CPP read-only bridge

Nếu external memory reader không tìm `Board` ổn định, chuyển sang bridge.

### Kiến trúc

```text
Pokiguard.exe
└─ PokiBridge.dll      <- C++ x64, chạy trong process
      │
      ├─ resolve il2cpp_* exports
      ├─ attach thread
      ├─ resolve Assembly-CSharp
      ├─ resolve Board / fields
      ├─ serialize GameState
      └─ Named Pipe / localhost IPC
                 │
                 ▼
            Python bot
                 │
                 ▼
              Solver
```

### Vì sao bridge dễ hơn external ở IL2CPP

Code nằm cùng process nên có thể:

```cpp
GetModuleHandleW(L"GameAssembly.dll")
GetProcAddress(..., "il2cpp_domain_get")
GetProcAddress(..., "il2cpp_class_from_name")
GetProcAddress(..., "il2cpp_field_get_offset")
...
```

Sau đó dùng IL2CPP runtime API để resolve type/member theo tên thay vì pointer chain mù.

### API đã xác minh export

Ít nhất có:

```text
il2cpp_domain_get
il2cpp_domain_get_assemblies
il2cpp_class_from_name
il2cpp_field_get_offset
il2cpp_runtime_invoke
il2cpp_thread_attach
```

Bridge phase đầu chỉ đọc state.

### IPC

Khuyến nghị:

```text
Windows Named Pipe
```

Ví dụ pipe:

```text
\\.\pipe\PokiBridge
```

Protocol đơn giản:

Request:

```json
{"cmd":"get_state"}
```

Response:

```json
{
  "ok": true,
  "board": [
    [1,5,5,2,6,3,4,3]
  ],
  "my_hp": 60351,
  "my_max_hp": 83385,
  "mana": 0,
  "max_mana": 1563,
  "rage": 0,
  "max_rage": 250,
  "turn": 1,
  "turn_number": 14
}
```

Python chỉ cần provider:

```python
class Il2CppBridgeProvider(BoardStateProvider):
    def read(self) -> GameState:
        return pipe_client.get_state()
```

### Không đặt solver trong DLL

DLL chỉ làm:

```text
game state -> DTO
```

Solver vẫn Python.

Điều này giúp:

- debug dễ;
- ít crash game hơn;
- giữ logic hiện tại;
- có thể fallback CV ngay.

---

# 9. DLL injection

Chỉ làm sau khi Level A chứng minh cần Level B.

Không cần anti-cheat bypass, manual mapping, stealth injection, driver/kernel hoặc hide module.

Mục tiêu duy nhất:

```text
load PokiBridge.dll vào Pokiguard.exe
```

Cho prototype nội bộ có thể dùng một loader/injector đơn giản hoặc tự viết loader thông thường.

Không triển khai:

```text
kernel driver
manual-map stealth
anti-cheat bypass
thread hiding
module unlinking
packet hook để fake reward
```

Nếu game bắt đầu có anti-cheat hoặc block injection, dừng nhánh này và quay về external/CV thay vì tìm cách bypass.

---

# 10. Thực hiện nước đi

Ở phase đầu **không gọi trực tiếp `MatchService.SendMove`**.

Giữ executor hiện tại:

```text
Python solver
   -> best move
   -> map row/col to pixel
   -> SendInput / mouse drag
   -> game tự RequestSwap
   -> game tự gửi WebSocket
   -> server xử lý
```

Lý do:

- server authoritative;
- tránh tự quản seq number;
- tránh gọi sai game thread;
- tránh race với board animation;
- giảm khả năng desync/crash.

Sau khi state reader ổn định mới cân nhắc nghiên cứu direct-call như một nhánh riêng.

---

# 11. Resize game

Yêu cầu đã chốt:

- game có thể resize trước khi bot start;
- sau khi bot chạy thì user không resize nữa.

Nếu board đọc từ memory:

- resize không ảnh hưởng đọc 8x8 state.
- resize chỉ ảnh hưởng `MoveExecutor` vì vẫn kéo chuột.

Do đó giữ một module nhỏ:

```text
BoardScreenLocator
```

Chỉ chạy khi Start/recalibrate.

Output:

```python
@dataclass
class BoardScreenRect:
    x: int
    y: int
    width: int
    height: int
```

Convert:

```python
def cell_center(rect, row, col):
    cell_w = rect.width / 8.0
    cell_h = rect.height / 8.0

    x = rect.x + (col + 0.5) * cell_w
    y = rect.y + (row + 0.5) * cell_h
    return round(x), round(y)
```

Lưu ý:

- `row`, `col` ở đây là 0-based.
- Screen locator có thể reuse logic CV hiện tại.
- Không cần nhận dạng từng gem nữa.

---

# 12. State consistency / chống đọc lúc animation

Memory reader vẫn phải tránh đọc board giữa cascade.

Ưu tiên tìm field/state tương tự:

```text
currentState
isCascadeRunning
```

Nếu chưa resolve được, dùng snapshot stability:

```text
read board A
sleep 50-100ms
read board B

if A == B:
    stable
else:
    wait
```

Không gửi move khi:

```text
current_turn != player
board unstable
match not ready
game not focused/visible (nếu SendInput cần)
```

---

# 13. Fallback architecture

Không xóa CV provider.

Runtime nên cho phép:

```text
state_provider = memory
fallback_provider = cv
```

Nếu:

```text
memory read error
pointer invalid
unexpected board dimensions
unknown tag ratio too high
```

thì:

```text
pause auto
hoặc fallback CV
```

Không tiếp tục gửi move từ corrupted state.

---

# 14. Logging bắt buộc

Log một vòng:

```text
[MEM] PID=...
[MEM] GameAssemblyBase=...
[STATE] source=memory board=8x8 stable=true
[STATE] hp=... mana=... rage=...
[SOLVER] from=(r,c) to=(r,c) score=...
[INPUT] drag ...
[WAIT] awaiting stable board
```

Khi pointer invalid:

```text
[MEM][ERROR]
address=0x...
stage=Board.allDots
win32_error=...
```

Không swallow exception.

---

# 15. Cấu trúc repo đề xuất

Giữ code hiện tại, thêm:

```text
project/
├─ bot/
│  ├─ solver/
│  │  └─ ... existing ...
│  ├─ state/
│  │  ├─ base.py
│  │  ├─ cv_provider.py
│  │  ├─ memory_provider.py
│  │  └─ bridge_provider.py
│  ├─ input/
│  │  └─ executor.py
│  └─ main.py
│
├─ tools/
│  ├─ memory_probe.py
│  ├─ module_probe.py
│  └─ metadata_probe.py
│
├─ native/
│  └─ PokiBridge/
│     ├─ CMakeLists.txt
│     ├─ src/
│     └─ include/
│
├─ reverse/
│  └─ cpp2il_out/       # gitignore
│
├─ docs/
│  ├─ il2cpp_symbols.md
│  └─ pokiguard_il2cpp_guide.md
│
└─ tests/
   └─ test_known_move.py
```

---

# 16. Việc Codex nên làm ngay — thứ tự cụ thể

## Task 1 — Không đụng solver

Đọc repo Python hiện tại.

Xác định:

```text
Board representation
Move representation
Solver entrypoint
Current executor
```

Tạo adapter/interface nếu code hiện tại đang gắn trực tiếp với CV.

Không rewrite thuật toán.

## Task 2 — Metadata probe

Tạo:

```text
tools/metadata_probe.py
```

Input default:

```text
D:\pc\Pokiguard_Data\il2cpp_data\Metadata\global-metadata.dat
```

Output:

```text
magic
metadata version
file size
presence of target strings
```

Expected:

```text
magic=0xFAB11BAF
version=31
```

## Task 3 — External attach probe

Tạo:

```text
tools/memory_probe.py
```

Yêu cầu:

- chỉ Windows;
- assert Python 64-bit;
- find `Pokiguard.exe`;
- open với read/query access;
- tìm base `GameAssembly.dll`;
- in PID/base;
- close handle sạch.

Chưa scan board.

## Task 4 — Run Cpp2IL

Run `--list-output-formats`.

Dump game.

Tạo `docs/il2cpp_symbols.md`.

Không code offset cho đến khi dump xác minh.

## Task 5 — Resolve board ownership

Tìm:

```text
Board singleton/static owner
allDots/dots exact type
Dot/BoardCell exact fields
tag representation
width/height
```

Output cần có:

```text
Board instance resolution strategy
field offsets
validation rules
```

## Task 6 — Memory BoardStateProvider

Chỉ khi Task 5 có đủ evidence.

Implement:

```python
MemoryBoardStateProvider.read()
```

Output GameState chuẩn hóa về enum của solver hiện tại.

## Task 7 — Compare memory với CV

Trong cùng một frame/stable board:

```text
CV board
MEM board
```

Print diff.

Chỉ coi memory provider ổn khi nhiều board liên tiếp khớp.

## Task 8 — Auto loop

Khi memory state đã đúng:

```text
memory state
-> existing solver
-> existing input executor
```

Không direct-call game function ở milestone này.

## Task 9 — Bridge nếu external thất bại

Chỉ tạo C++ bridge nếu không resolve `Board` ổn định bằng Level A.

Bridge chỉ expose read state.

---

# 17. Test acceptance criteria

## Memory probe

```text
PASS:
- detect process
- GameAssembly base hợp lệ
- không cần admin nếu process cùng integrity
- không crash game
```

## Board reader

```text
PASS:
- dimensions = 8x8
- 64 cells
- mỗi cell map đúng 1/6 gem
- board memory khớp CV trong >= 20 stable snapshots
```

## Solver integration

Dùng case:

```text
base.png
swap r5c6 <-> r5c7
```

Solver vẫn phải nhận diện được move tốt theo logic hiện có.

## Farm loop

```text
PASS:
- không gửi move khi board đang rơi
- không gửi move ngoài lượt
- không spam duplicate move
- không desync sau nhiều lượt
```

---

# 18. Cài đặt cần thiết

## Bắt buộc ngay bây giờ

Nếu tiếp tục theo **Python external read-only**:

```text
Không cần cài .NET.
Không cần cài Visual Studio.
```

Cần:

```text
Python x64
```

Kiểm tra:

```powershell
python -c "import struct; print(struct.calcsize('P') * 8)"
```

Expected:

```text
64
```

`ctypes` đã có sẵn trong Python.

Nếu code hiện tại đã chạy OpenCV thì môi trường Python hiện tại gần như đủ.

## Khuyến nghị để reverse

### Cpp2IL

Tải Windows x64 release/build của Cpp2IL.

Mục tiêu chỉ là dump/reconstruct metadata + native information.

Không cần build Cpp2IL source nếu dùng binary release.

### ILSpy — optional

Dùng để mở dummy DLL nếu muốn xem type/field/method trực quan.

Codex không bắt buộc cần GUI này nếu có thể parse/search output bằng script.

## Chỉ cần khi làm internal bridge

Cài:

```text
Visual Studio 2022 Build Tools
Desktop development with C++
MSVC x64 toolchain
Windows 10/11 SDK
```

CMake optional nếu project bridge dùng CMake.

Không cần Unity Editor.

Không cần cài đúng Unity `6000.0.26f1` chỉ để đọc memory/IL2CPP.

## .NET

Không bắt buộc nếu host vẫn là Python + bridge C++.

Chỉ cài .NET SDK nếu Codex quyết định viết một helper/tool bằng C#.

---

# 19. Những thứ không cần cài ở giai đoạn này

```text
Unity Editor                       không cần
Cheat Engine                       không cần
Python OpenCV mới                  không cần nếu bản hiện tại đang chạy
.NET SDK                           không cần cho Python-first
kernel driver                      không
anti-cheat bypass tools            không
packet interception/proxy          không
```

---

# 20. Lưu ý quyền Windows

`ReadProcessMemory` cần process handle có `PROCESS_VM_READ`.

Nếu game/tool chạy cùng integrity level thì thường không cần admin.

`SendInput` chịu giới hạn integrity/UIPI. Nếu game chạy `Run as administrator` còn bot không chạy admin, input có thể không vào được.

Quy tắc:

```text
game normal      -> bot normal
game admin       -> bot có thể cần admin tương ứng
```

Không yêu cầu admin mặc định nếu không cần.

---

# 21. Nguyên tắc kỹ thuật cho Codex

1. Không hard-code absolute runtime address.
2. Base + RVA phải tính lại mỗi launch vì ASLR.
3. Không `WriteProcessMemory` ở phase read-state.
4. Không giả packet/reward.
5. Không gọi direct `SendMove` cho milestone đầu.
6. Không dựa vào `enableAutoMove`.
7. Solver hiện tại là source of truth cho chọn move.
8. Board memory phải được cross-check với CV trước khi tự động hóa.
9. Pointer invalid => stop/fallback, không cố dereference.
10. Mọi offset phải có source/evidence trong `docs/il2cpp_symbols.md`.

---

# 22. Prompt ngắn có thể đưa thẳng cho Codex

```text
Đọc docs/pokiguard_il2cpp_guide.md trước.

Project hiện đã có bot Python match-3 chạy ổn bằng OpenCV và solver riêng.
KHÔNG rewrite solver, KHÔNG dùng auto logic của game.

Mục tiêu phase hiện tại:
1. thêm abstraction BoardStateProvider;
2. giữ CvBoardStateProvider hiện tại;
3. viết tools/metadata_probe.py để verify global-metadata magic/version;
4. viết tools/memory_probe.py dùng ctypes trên Windows x64:
   - tìm Pokiguard.exe
   - OpenProcess chỉ QUERY + VM_READ
   - tìm GameAssembly.dll base
   - log PID/base
   - không WriteProcessMemory
5. chuẩn bị workflow Cpp2IL để reconstruct chính xác Board/allDots/Dot/MatchService;
6. tạo docs/il2cpp_symbols.md, mọi offset phải có evidence;
7. chỉ sau khi xác minh pointer chain mới implement MemoryBoardStateProvider;
8. so sánh board từ memory với board từ CV ít nhất 20 stable snapshots;
9. executor vẫn dùng input bình thường; chưa gọi MatchService.SendMove trực tiếp.

Game facts:
- Unity 6000.0.26f1
- IL2CPP metadata v31
- GameAssembly x64
- server-authoritative boss session
- metadata có các strings Board, BoardWsApplier, MatchService, PlayerStats,
  BoardCellDTO, allDots, dots, SendMove, RequestSwap, LoadBoardFromSnapshot, v.v.

Ưu tiên code nhỏ, test được từng milestone, log rõ và fail-safe.
```

---

# 23. Kết luận kiến trúc

Hướng tối ưu với code hiện tại:

```text
PHASE 1
Python hiện tại
+ ctypes external memory reader
+ Cpp2IL offline reverse
+ existing solver
+ existing mouse executor
```

Nếu resolve được Board:

```text
CV chỉ còn fallback/calibration
```

Nếu không resolve được Board ổn định:

```text
PHASE 2
C++ x64 PokiBridge.dll
-> IL2CPP API
-> Named Pipe
-> Python solver
```

Không cần rewrite project sang C# chỉ để thử memory-based automation.
