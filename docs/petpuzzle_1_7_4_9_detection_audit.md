# PetPuzzle 1.7.4.9 — kiểm tra thông tin “quét tool auto”

Phạm vi: reverse người dùng cung cấp và đọc file GameAssembly mới đúng hash
`4a8925cebbcc9004a4954dad8f04cadf01cf759ff418f84528053552e0cf156b`.
Không gọi API game, không test né phát hiện, không thay clock/input pacing,
không ẩn process hoặc sửa cơ chế bảo vệ của client.

## Kết luận có thể rút ra

**Chưa tìm được bằng chứng trong phần client đã kiểm rằng bản này mới thêm
quét danh sách process/cửa sổ hoặc nhận diện riêng PokiguardToolV2.**
Đã xác nhận cơ chế kiểm đồng hồ, đối chiếu số liệu combat và nhận verdict
từ server. Các tên/contract này đã tồn tại ở b6. Không thể suy từ đó rằng
server không phát hiện auto hoặc tool được bảo đảm không bị phát hiện.

| Cơ chế | Bằng chứng trực tiếp | Ý nghĩa với tool |
|---|---|---|
| SpeedGuard | BeginMatch được gọi từ ApplyMatchInitFromMessage; Runner.Update → SampleWall/ApplyCompensation; NoteServerNow dùng mốc server | Kiểm tiến độ đồng hồ game so UTC và mốc server, không phải đọc tên tool |
| Verdict server | HandleMatchSpeedHack đọc payload `ratio/action`, chuyển OnServerVerdict | Server có thể yêu cầu lock; policy server và trạng thái remote flags hiện tại UNKNOWN |
| Khóa tương tác | Xref native get_Locked từ Dot.CanInteract, MatchSpeed.Active/Toggle và nút speed | Khi game khóa, normal click cũng chịu gate của game; việc đọc memory không tự vượt gate |
| Shadow report | FlushShadowReportForLastMove → ChatService.SendMatchShadowReport | Client gửi seq/damage/HP để đối chiếu; đây là report của game, không phải log AI của V2 |
| AntiCheat Tracking | Field HP/mana/damage trong Active/ActivePVP, flag hackDetected trong MatchRewardData | Các field đã có ở b6; metadata không chứng minh mọi nhánh validator đều bật |
| IsDebuggerPresent | Có import và direct IAT reference trong vùng native runtime | Import đơn lẻ không chứng minh quét auto; owner của các call này chưa được định danh đầy đủ |

## Native đã lần như thế nào

Tất cả địa chỉ dưới đây là RVA, không phải địa chỉ runtime cố định:

- `MatchService.ApplyMatchInitFromMessage`: gọi `SpeedGuard.BeginMatch`;
  `MatchService.HandleMatchSpeedHack` ở `0x8F6380` gọi OnServerVerdict.
- `SpeedGuard.SampleWall` ở `0xDC0E60`: đọc `DateTime.UtcNow` và icall
  `UnityEngine.Time::get_realtimeSinceStartupAsDouble()`, dùng các anchor
  để so sánh rồi Evaluate. `NoteServerNow` có nhánh so mốc server/local.
- `SpeedGuard.ApplyCompensation` ở `0xDC14D0`: có gọi `Time.set_timeScale`.
  Đó là hành vi client game, không phải hành vi V2.
- `SpeedGuard.Locked` sử dụng remote flag `match.speedGuardLock`.
  Khả năng bật/tắt từ xa không cho biết cấu hình đang áp dụng cho tài khoản.
- `MatchService.FlushShadowReportForLastMove` ở `0x8F3EC0`, sender ở
  `0x8D75C0`, envelope `MATCH_SHADOW_REPORT`; sender nhận matchId, seq,
  clientDamage, clientBossHpAfter, clientPlayerHpAfter.
- Xref đã xác nhận call/jmp theo instruction boundary, không chỉ tìm một
  chuỗi byte tình cờ:
  [speedguard_callers.json](artifacts/game_1_7_4_9_20261020/speedguard_callers.json).
  `Dot.CanInteract` kiểm boolean trả về rồi nhảy khỏi đường tương tác khi
  bị khóa: [gate native](artifacts/game_1_7_4_9_20261020/lock_input_evidence.txt).

Native có chú giải string/type/call và script tái tạo:
[native_evidence.txt](artifacts/game_1_7_4_9_20261020/native_evidence.txt),
[native_audit.py](artifacts/game_1_7_4_9_20261020/native_audit.py).
Không công bố ngưỡng hoặc cách thay dữ liệu để né kiểm tra.

## Điểm mới không được đánh đồng với quét auto

`AuditionStage` thêm `_lastTickFrame/+0x168` và `_lastTickAt/+0x16C`.
Native Tick đọc frameCount/unscaledTime và dùng hai field trong gate cập
nhật QTE. Đây là thay đổi bookkeeping/frame của QTE; không thấy process
scan hoặc gửi một nhãn “tool detected” trong các handler Tick/PressDir/TapBar
đã kiểm. Không xem điều này là bằng chứng grading server giữ nguyên.
QTE executor của tool không đổi, calibration cũ không tự được chấp nhận cho
binary mới.

Các class `Poki.Security.Pin*` mới thuộc PIN/giao diện bảo mật tài khoản.
Tên namespace Security không đủ để kết luận đó là anti-bot.

## Phạm vi tìm kiếm âm tính và hạn chế

[security_summary.json](artifacts/game_1_7_4_9_20261020/security_summary.json)
ghi 1.921 file C# ứng dụng đã rà các tên API process/window/hook, injected
input flag, custom DllImport và anti-bot/autoclick. Không có hit cho nhóm
keyword đó. SpeedGuard/Runner có cùng danh sách field/method khai báo với
b6; so sánh này không chứng minh bytecode và remote policy hoàn toàn giống.

Chưa chứng minh: mọi đường gọi gián tiếp/dynamic import, native module khác,
điều kiện backend, telemetry phân tích hành vi, tiêu chí phạt tài khoản và
phản ứng khi một tài khoản bị đánh dấu. Không có backend source hoặc live
verdict để trả lời các phần đó. Không phát request thăm dò hoặc tạo hành vi
bất thường để thử ngưỡng.

## Đánh giá ảnh hưởng

V2 hiện dùng read-only memory và normal input; không sửa clock, damage, HP
hoặc payload. **Suy luận từ cơ chế đã thấy:** những thao tác đó không trực
tiếp tạo ra sửa đổi đồng hồ/chỉ số mà SpeedGuard/shadow report đang kiểm.
Điều này không loại trừ phát hiện hành vi ở server. Các request gameplay
còn có sequence/thời gian và dữ liệu QTE để server đánh giá theo policy mà
reverse client không cho biết đầy đủ.

Nếu gặp lock/verdict thực tế, cần lấy đúng log/lifecycle hiện tượng để phân
biệt lỗi UI, timeout và phán quyết game. Không khắc phục bằng bypass hoặc
làm mờ bằng chứng. Nhánh compatibility hiện không sửa bất cứ cơ chế phát
hiện nào.
