# Kiến trúc PokiguardAuto V1

## Phạm vi khảo sát

Nguồn V1 được đọc từ `D:\PokiguardAuto` và chỉ dùng làm tham chiếu. Không file nào trong
thư mục đó bị sửa. Các file chính:

- `pokiguard_auto/__main__.py`, `launcher.py`, `pokiguard_auto/ui.py`
- `pokiguard_auto/models.py`, `pokiguard_auto/solver.py`
- `pokiguard_auto/vision.py`, `pokiguard_auto/template_matcher.py`
- `pokiguard_auto/win32.py`, `pokiguard_auto/engine.py`
- các test trong `D:\PokiguardAuto\tests`

## Entrypoint và lifecycle

Hai entrypoint source và launcher đều gọi `pokiguard_auto.ui.run_app()`:

```text
python -m pokiguard_auto / launcher.py
  -> ui.run_app()
  -> PokiguardAutoUI
  -> AutoFarmEngine(project_dir, callback)
  -> AutoFarmEngine.start()
  -> thread daemon PokiguardAutoEngine chạy AutoFarmEngine._run()
```

`PokiguardAutoUI._start()` tạo config override rồi gọi `engine.start()`. Engine tìm cửa sổ
có title chứa `PokiguardOnlines`, focus cửa sổ, tạo `WindowCapture`, sau đó chạy loop cho
đến khi Stop/F8/lỗi.

Evidence:

- `D:\PokiguardAuto\pokiguard_auto\__main__.py:1`
- `D:\PokiguardAuto\launcher.py:1`
- `D:\PokiguardAuto\pokiguard_auto\ui.py:321`
- `D:\PokiguardAuto\pokiguard_auto\engine.py:366`
- `D:\PokiguardAuto\pokiguard_auto\engine.py:3958`

## Board và gem representation

V1 dùng model bất biến, 0-based:

```python
class Token(str, Enum):
    SWORD = "sword"
    MANA = "mana"
    RAGE = "rage"
    SHIELD = "shield"
    HEALTH = "health"
    DRAIN = "drain"
    UNKNOWN = "unknown"

Board = tuple[tuple[Token, ...], ...]
MultiplierBoard = tuple[tuple[int, ...], ...]
Cell = tuple[int, int]  # (row, col)
```

Board hợp lệ cho deep solver là 8 hàng x 8 cột và không chứa `UNKNOWN`. Vision có thể trả
`partial_board` chứa `UNKNOWN`, nhưng nhánh này chỉ được dùng cho local match certificate;
không được đưa vào cascade/opponent projection sâu.

Tên `HEALTH` phải được giữ ở adapter V2 (không đổi thành `HEAL`) để tương thích trực tiếp
với solver V1. Multiplier là một board song song, mặc định mỗi ô có giá trị 1.

Evidence: `D:\PokiguardAuto\pokiguard_auto\models.py:8-46` và
`D:\PokiguardAuto\pokiguard_auto\vision.py:1300-1450`.

## Vision, window và board locator

`WindowCapture.grab()` dùng `mss` để capture đúng client rectangle lấy qua
`GetClientRect` + `ClientToScreen`; frame BGRA được chuyển thành BGR.

`VisionAnalyzer.analyze()` thực hiện:

1. nhận dạng 64 gem bằng HSV hoặc template matching;
2. đọc multiplier board;
3. đo board-edge, banner/skip overlay, turn marker, timer, HP/resource/card state;
4. phân loại `ScreenState` và trả `ScreenObservation`.

Board locator hiện tại không tìm hình chữ nhật động. Nó dùng geometry chuẩn hóa theo toàn
client window:

```text
first center = (x=0.360, y=0.150)
step         = (x=0.0410, y=0.0760)
center(r,c)  = first + (c*step_x, r*step_y)
```

Các giá trị này có thể override bởi `config.json`. Cùng một `BoardGeometry` được dùng cho
cả recognition và click nên calibration không bị lệch giữa hai path.

Evidence:

- `D:\PokiguardAuto\pokiguard_auto\win32.py:58-112`
- `D:\PokiguardAuto\pokiguard_auto\vision.py:14-27`
- `D:\PokiguardAuto\pokiguard_auto\vision.py:373-477`
- `D:\PokiguardAuto\pokiguard_auto\vision.py:1300-1450`
- `D:\PokiguardAuto\pokiguard_auto\engine.py:223-249`

## Solver entrypoint và Move

Entrypoint policy đầy đủ là:

```python
decide_turn(
    board: Board,
    context: CombatContext,
    consecutive_skips: int,
    blocked: set[tuple[Cell, Cell]] | None,
    multipliers: MultiplierBoard | None,
    ...
) -> TurnDecision
```

`decide_turn()` gọi `evaluate_moves()` ở mode mặc định hoặc `evaluate_moves_ai()` ở mode
AI, rồi áp policy Sword/safety/resource/skip. `evaluate_moves()` là solver entry thấp hơn
khi caller chỉ cần danh sách candidate.

Move không có class riêng chỉ chứa hai tọa độ. Representation thực tế là
`MoveEvaluation`:

- `first`, `second`: hai `Cell` 0-based, luôn kề ngang/dọc;
- `score`, `collected`, `cascade_count`, `longest_match`, `opponent_threat`, `reason`;
- các metric an toàn Sword như `opponent_swords`, `sword_drop_risk`,
  `refill_sword_risk`, `leaves_sword_for_boss`, `vertical_sword_hazard`.

`TurnDecision` chứa `action` (`move` hoặc `skip`), `reason`, optional `move` và
`SkipProjection`.

Evidence:

- `D:\PokiguardAuto\pokiguard_auto\models.py:49-144`
- `D:\PokiguardAuto\pokiguard_auto\solver.py:1066`
- `D:\PokiguardAuto\pokiguard_auto\solver.py:1324`
- `D:\PokiguardAuto\pokiguard_auto\solver.py:1957`

## Evaluation/scoring

Solver enumerate 112 cặp kề nhau (56 ngang + 56 dọc), bỏ swap hai token giống nhau,
`UNKNOWN`, blocked swap, và swap không tạo match xuyên qua một trong hai endpoint.

Resolver:

- tìm run ngang/dọc dài >=3;
- cộng multiplier của từng ô vào `collected`;
- collapse theo cột và resolve deterministic cascade;
- bonus shape: 4-in-row `+8`, 5-in-row `+18`, mỗi ô giao ngang/dọc `+12`;
- mỗi cascade sau cascade đầu `+10`.

Điểm base của một candidate:

```text
score = resource_score
      + shape_bonus
      + cascade_bonus
      - (opponent_threat * 0.18 + opponent_swords * 11)
      - sword_drop_risk penalty
      - (leaves_sword_for_boss * 120 + vertical_sword_hazard * 45)
      + lower-board position bonus
```

`resource_score` dùng weight động theo `CombatContext`. Base nổi bật: Sword 10.5 cộng
rage/boss-low bonus; Rage 7.0 cộng rage bonus; Mana thay đổi theo trạng thái evolution,
attack và finishing; Health/Shield tăng mạnh khi HP thấp; Drain được phân loại `useful`,
`defensive`, hoặc `useless`.

Quan trọng: quyết định cuối không đơn giản là `max(score)`. Policy ưu tiên cứng Sword,
veto move để lại Sword chắc chắn cho boss khi còn lựa chọn sạch, áp safe mode khi HP thấp,
xếp resource theo ngữ cảnh, và chỉ skip qua các guard riêng.

Evidence: `D:\PokiguardAuto\pokiguard_auto\solver.py:41-265`,
`D:\PokiguardAuto\pokiguard_auto\solver.py:596-710`,
`D:\PokiguardAuto\pokiguard_auto\solver.py:1066-1202`, và
`D:\PokiguardAuto\pokiguard_auto\solver.py:1629-1955`.

## Executor flow

V1 không drag. Nó chọn hai gem bằng hai click tuần tự:

```text
MoveEvaluation(first, second)
  -> cell_to_normalized(first/second, configured BoardGeometry)
  -> click endpoint 1
  -> chờ click_delay_seconds (default 0.14s)
  -> click endpoint 2
  -> _PendingMove
  -> đợi visual acknowledgement / bounce / turn transition
```

Foreground mode kiểm tra cửa sổ vẫn foreground, dùng `SetCursorPos` và hai
`mouse_event(LEFTDOWN/LEFTUP)`. Background mode dùng `PostMessageW` với
`WM_MOUSEMOVE`, `WM_LBUTTONDOWN`, `WM_LBUTTONUP`. Mỗi endpoint được fail-closed; nếu click
thứ hai chưa gửi được, engine giữ latch và chỉ retry endpoint thứ hai.

Evidence:

- `D:\PokiguardAuto\pokiguard_auto\vision.py:1568`
- `D:\PokiguardAuto\pokiguard_auto\win32.py:114-159`
- `D:\PokiguardAuto\pokiguard_auto\engine.py:1632-1846`

## Auto-loop/state machine

Mỗi tick `_run()`:

```text
find/focus window
  -> capture client
  -> VisionAnalyzer.analyze
  -> debounce ScreenState transition
  -> remember board snapshots
  -> WAITING_ROOM: click Start sau stability delay
     RESULT: click Close sau stability delay
     BATTLE: update turn/banner/timer, validate board, solve, plan/click
  -> save debug/status
```

Battle path có các gate quan trọng: đúng lượt người chơi, overlay sạch, board consensus ổn
định, local certificate còn đúng trên capture độc lập trước click, không có pending move,
và game foreground nếu dùng foreground input. Sau click, engine không coi move thành công
chỉ vì đã gửi input; nó đợi evidence clear/board change và turn owner.

`AutoFarmEngine` đang gắn chặt acquisition (capture/CV), screen state, tactical cards,
solver policy, retry và executor trong một class lớn. Vì vậy không nên copy nguyên engine
vào V2 rồi sửa trực tiếp.

## Reuse/adapt cho V2

| Module V1 | Hướng V2 | Lý do |
|---|---|---|
| `models.py` (`Token`, `Board`, `MultiplierBoard`, `CombatContext`, `MoveEvaluation`) | Reuse trực tiếp | Đây là contract solver hiện tại. |
| `solver.py` | Reuse trực tiếp, không rewrite | Không phụ thuộc OpenCV/Win32; input là board/context thuần. |
| `win32.py` input + geometry | Reuse hoặc bọc adapter | Executor đã có safety gate và hỗ trợ resize qua normalized geometry. |
| `WindowCapture`, `VisionAnalyzer` | Giữ làm `CvBoardStateProvider`/fallback | Recognition đã có temporal validation và overlay logic hữu ích. |
| `engine.py` | Cần tách adapter/orchestrator | Hiện gọi `vision.analyze()` trực tiếp và trộn acquisition với policy/executor. |
| `ui.py` | Chỉ adapt khi tích hợp | UI khởi tạo `AutoFarmEngine` trực tiếp. |

Boundary đề xuất cho V2:

```text
BoardStateProvider.read() -> V2 GameState
  -> adapter board sang V1 Token/Board + CombatContext
  -> V1 decide_turn()
  -> V1-compatible click executor
```

Không tạo một `Move` V2 cạnh tranh với `MoveEvaluation`. Adapter chỉ cần bảo toàn tọa độ
0-based `(row, col)` và các string value của `Token`. CV vẫn cần cho screen/lobby/result,
turn-overlay và làm fallback ngay cả khi 64 gem đã chuyển sang memory provider.
