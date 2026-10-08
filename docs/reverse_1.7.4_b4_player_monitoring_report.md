# Pokiguard 1.7.4-b4 — Player monitoring evidence

Ngày rà soát: 2026-09-15
Phạm vi: đọc tĩnh reverse b4 và binary game đang cài; không chạy game, không bắt
gói tin, không sửa client, không thay đổi PokiguardToolV2.

## Kết luận phục vụ quyết định

Reverse b4 không cho thấy một bộ dò autoplay riêng ở client, cơ chế quét process
đang chạy, ghi toàn bộ thao tác chuột, chụp màn hình hoặc gửi một luồng raw-click
lên server. Tuy nhiên server không cần theo dõi desktop liên tục để nhận biết mẫu
chơi tự động. Client gửi đủ sự kiện có ngữ nghĩa và thời gian để server tự phân
tích theo account, thiết bị, trận, lượt và chuỗi hành động.

Không thể dùng reverse client để kết luận nguyên nhân account clone bị khóa. Luật,
ngưỡng, lịch sử và quyết định khóa nằm phía server. Có thể xác nhận client nhận mã
`ACCOUNT_LOCKED`, nhưng không có phần code client giải thích vì sao server phát mã
này.

Vì vậy Phase 3D.1 live benchmark nên tiếp tục tạm dừng trên account có giá trị.
Offline analyzer vẫn có thể dùng. Nếu tiếp tục live, phạm vi phù hợp là account test
được phép, mẫu nhỏ có người giám sát và không điều chỉnh nhịp input nhằm né cơ chế
phát hiện.

## Bằng chứng đã xác nhận

### 1. Server nhận nước đi và thời điểm client phát nước đi

`ChatMessageDTO` có các field sau:

- `matchId`, `seqNum`;
- `clientMonoMs`;
- `fromCol`, `fromRow`, `toCol`, `toRow`.

Native body của `ChatService.SendMatchMove` gọi
`ClockDriftMonitor.Sample()`, tạo `MATCH_MOVE_REQ`, gọi
`ClockDriftMonitor.MonoMs()` rồi ghi kết quả vào `clientMonoMs` trước khi serialize
WebSocket message. Do đó server nhận một dấu thời gian đơn điệu của client cho mỗi
nước SWAP hợp lệ, ngoài thời điểm server tự nhận request.

`clientMonoMs` cũng được gắn vào `MATCH_ANIM_DONE`. Server vì thế có thể đối chiếu
thời điểm phát nước đi, lúc client báo render/animation hoàn thành và các mốc thời
gian của chính server.

Xref native trong b4 cho `ClockDriftMonitor.MonoMs()` chỉ ra hai caller thuộc
gameplay transport:

1. `ChatService.SendMatchMove`;
2. `ChatService.SendMatchAnimDone`.

Không thấy `clientMonoMs` được gắn trực tiếp vào Card Use hay Skill Use. Các request
đó vẫn có thời điểm đến server và dữ liệu chuyên biệt riêng.

### 2. QTE gửi dữ liệu thời gian chi tiết

`MATCH_QTE_TAP` gửi `elapsedMs` và `challengeId`. `MATCH_SKILL_USE_REQ` có thể gửi:

- `qtePresses`;
- `qteElapsedMs`;
- `qteChallengeId`;
- `correctDotCount`, `timingResult`, `dotsToDestroy`;
- hàng/ô đã chọn đối với skill cần chọn mục tiêu.

Server có thể chấm QTE và kiểm tra tính hợp lệ hoàn toàn từ các dữ liệu này. Không
cần nhận raw keyboard event để biết chuỗi bấm, kết quả và thời gian QTE.

### 3. Client báo trạng thái đối chiếu sau nước đi

Các message và field sau tồn tại trong b4:

- `MATCH_SHADOW_REPORT`;
- `shadowDamage`;
- `shadowBossHpAfter`;
- `shadowPlayerHpAfter`.

`MatchService.SendMove` lưu nước đi và sequence mới, sau đó gọi
`FlushShadowReportForLastMove` cho sequence trước. Native body của hàm flush lấy
`MatchFeatureFlags.ShadowReportEvery`, kiểm tra sequence theo modulo và gửi shadow
report khi tới chu kỳ. Giá trị mặc định trong b4 là `5`; remote config
`perf.shadowReport/every` hoặc dev preference có thể thay đổi trong khoảng được
client giới hạn.

Đây là kiểm tra nhất quán damage/HP và desync. Nó phù hợp với việc phát hiện sửa
stats, gửi request trực tiếp sai trạng thái hoặc client tính khác server. Nó không
tự chứng minh có bộ phân loại autoplay.

### 4. Client và server theo dõi AFK theo lượt

Server gửi `MATCH_AFK_WARN`. Payload được client đọc gồm:

- `idleCount`;
- `threshold` với fallback client là `3`;
- `forfeit`;
- `mode`.

Client tách callback cảnh báo và callback bị loại. Như vậy số lượt không có hành
động hợp lệ được server giữ và quyết định. Đây chính là lý do server có thể loại
người chơi sau ba lượt AFK mà không cần quan sát chuột.

### 5. Kéo dài có cặp pause/resume riêng

`Dot` giữ `s_mouseDownAt` và ngưỡng `DRAG_PAUSE_MIN_HOLD_SEC = 0.3f`. Native body
của `Dot.TickGlobal` chỉ phát `MATCH_DRAG_PAUSE` sau khi giữ đủ ngưỡng và con trỏ
đã đi qua swipe resistance; khi kết thúc có `MATCH_DRAG_RESUME` nếu pause đã được
phát.

Cấu hình hiện tại của PokiguardToolV2 dùng board input `DRAG`, mặc định `0.10`
giây, ba bước và overshoot `0.35` ô. Với đường mặc định này, một SWAP bình thường
ngắn hơn ngưỡng pause của game, nên server thường không nhận cặp drag pause/resume
cho SWAP đó. Server vẫn nhận `MATCH_MOVE_REQ` cùng `clientMonoMs` lúc thả chuột.
Điều này không tạo cơ sở để coi input tự động là không quan sát được.

### 6. Perf probe gửi thống kê tổng hợp theo trận

`MatchPerfProbe` có runtime initializer và gửi `/api/client-perf`. `ProbeEnabled`
dùng PlayerPrefs `ff_PerfProbe` với mặc định `1`, rồi đi qua remote flag
`perf.probe`; tức client-side default là bật nhưng server có thể điều khiển bằng
remote config.

Payload đã khai báo gồm:

- `device`, `os`, `gpu`, `memMb`, device tier và client version;
- `matchId`, số frame, p50/p95/p99 và max frame time;
- hitch count, GC count/allocation và RTT p50;
- thời gian enter/exit;
- số turn, `avgTurnRoundTripMs`, `avgRenderMs`;
- `clockDriftPct`.

Giới hạn tĩnh gồm tối thiểu 60 giây giữa hai lần gửi, tối thiểu 30 frame và gửi
sau khi thoát trận 5 giây. Đây là telemetry hiệu năng tổng hợp, không phải danh
sách từng click. Dù vậy match ID, timing và thông tin môi trường có thể được ghép
với lịch sử server.

### 7. Account được gắn với thông tin thiết bị khi đăng nhập

`LoginRequest` và `TokenLoginRequest` gửi `deviceId`, `deviceName`, `version` và
`platform`. `LoginDevice` dùng `deviceUniqueIdentifier`/PlayerPrefs `DeviceId` theo
các string literal trong binary. Server có thể liên hệ nhiều account với cùng
device ID. Reverse không cho biết server có dùng liên hệ đó trong quyết định khóa
hay không.

### 8. Error reporter không chứa dữ liệu input

`ClientErrorReporter` tự bootstrap và có endpoint `/api/client-log`. Payload gồm
level, message, stack, scene và version; giới hạn 15 report/session và tối thiểu 5
giây giữa hai lần gửi. Không thấy tọa độ chuột, click interval hay ảnh màn hình
trong payload của reporter.

## Điều không tìm thấy trong b4

Rà các type/method/string của `Assembly-CSharp`, toàn bộ `MATCH_*` literal, REST
endpoint và PE import của binary đang cài không thấy:

- class hoặc endpoint có tên BotDetector, AutoClickDetector, MacroDetector hay
  AntiCheatService;
- message riêng cho raw mouse down/up, mouse path, click count hoặc nguồn input;
- tự động chụp màn hình rồi upload;
- native plugin chống cheat riêng;
- import trong `GameAssembly.dll` để liệt kê process/window, mở process khác, đọc
  process khác hoặc cài Windows input hook.

`GameAssembly.dll` có import `IsDebuggerPresent`, nhưng đây cũng là API runtime
IL2CPP/.NET thường dùng. Không có xref hoặc string app-specific trong bộ bằng chứng
này để gán nó cho cơ chế chống autoplay, nên phải giữ kết luận là UNKNOWN.

Không tìm thấy không đồng nghĩa chắc chắn không tồn tại. API có thể được resolve
động hoặc logic có thể nằm hoàn toàn ở server. Tuy nhiên không có bằng chứng client
b4 hiện tại cho việc quét process/tool hoặc stream raw input.

## So sánh b2, b3 và b4

| Cơ chế | b2 | b3 | b4 |
|---|---:|---:|---:|
| Shadow damage/HP report | Có | Có | Có |
| Chu kỳ shadow remote-configurable | Có | Có | Có |
| QTE elapsed/challenge/presses | Có | Có | Có |
| Perf probe và client log | Có | Có | Có |
| `clientMonoMs` trong gameplay DTO | Không | Có | Có |
| Move và anim ACK gắn `clientMonoMs` | Không xác nhận ở b2 | Có | Có |

Các declaration và string liên quan monitoring giữa b3 và b4 giữ nguyên về mặt
ngữ nghĩa; chỉ RVA dịch chuyển. Thay đổi đáng kể tìm thấy trong `ChatService` b4 là
auth probe sau nhiều lần reconnect và overload `LeaveRoom(roomId)`, không phải bộ
dò autoplay mới.

## Server có thể suy ra gì

Các điểm dưới đây là **suy luận từ dữ liệu đã xác nhận**, không phải rule ban lấy
được từ server:

- thời gian từ mở lượt đến request đầu tiên và phân bố thời gian đó qua nhiều lượt;
- nhịp giữa các move, card, QTE, animation ACK và kết thúc lượt;
- chuỗi tọa độ nước đi, sequence, tỷ lệ request bị reject và các trạng thái bất khả
  thi;
- mức độ đều hoặc lặp lại của hành vi qua nhiều trận;
- chuỗi QTE, thời gian QTE và tỷ lệ PERFECT;
- thời lượng session, số trận liên tiếp, AFK và re-entry;
- nhiều account dùng cùng device ID hoặc môi trường phần cứng giống nhau;
- khác biệt giữa server state và shadow state của client.

Một request được tạo từ thao tác Windows bình thường đi qua đúng client path nên
payload không có cờ nói chuột thật hay chuột mô phỏng. Điều đó chỉ loại bỏ một tín
hiệu trực tiếp; nó không loại bỏ phân tích hành vi phía server.

## Những điểm vẫn UNKNOWN

- rule, ngưỡng, mô hình hoặc thời gian lưu dữ liệu phía server;
- server có dùng `clientMonoMs`, perf payload hay device association để khóa account
  hay chỉ dùng cho vận hành/debug;
- remote config hiện tại của `perf.probe` và `perf.shadowReport/every`;
- nguyên nhân cụ thể của account clone bị khóa;
- tool mà account clone đã dùng có gửi request trực tiếp, sửa memory, chạy 24/7,
  tạo QTE bất thường hay chỉ dùng foreground input.

## Nguồn kiểm chứng

- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ChatMessageDTO.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ChatService.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/MatchService.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/MatchFeatureFlags.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/MatchPerfProbe.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ClockDriftMonitor.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/ClientErrorReporter.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/Dot.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/LoginRequest.cs`
- `reverse/reverse_1.7.4-b4/cs/Assembly-CSharp/TokenLoginRequest.cs`
- native bodies tại RVA b4 đã ghi trong các declaration trên;
- installed `D:/pc/GameAssembly.dll`, SHA-256
  `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6`;
- `src/pokiguard_v2/pet_configuration.py` và
  `src/pokiguard_v2/win32_input.py` để đối chiếu input path hiện tại.
