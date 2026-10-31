# Phân tích hai lần dừng farm trên máy ảo — 2026-10-10

Phạm vi: đọc bộ log người dùng cung cấp tại `C:\Users\Admin\Downloads\log`, đối chiếu source bản phát hành v1.2.4 (`c646acfa`) và source hiện tại. Không sửa runtime, cấu hình, registry hoặc game; không chạy input, không build lại tool.

**Cập nhật sau điều tra:** người dùng đã yêu cầu triển khai sửa lần 1 và bổ sung re-entry hậu trận. Kết quả sửa source/kiểm thử/gói máy ảo được ghi riêng tại [báo cáo sửa PlayerPrefs và re-entry](petpuzzle_room_reentry_fix_20261010.md). Nội dung dưới đây giữ nguyên phạm vi và bằng chứng tại thời điểm điều tra; “chưa sửa code” mô tả lượt điều tra đó.

## 1. Kết luận và mức độ xác nhận

| Trường hợp | Kết quả | Kết luận từ bằng chứng |
| --- | --- | --- |
| Lần 1: room lỗi, còn boss nhưng mất nhân vật/thông tin | 50/200, 50 WIN | **Đã xác định nguyên nhân tool dừng:** nhánh thoát room lỗi yêu cầu `PlayerPrefs.SelectedPetId == 1436`, trong khi đọc registry thất bại và giá trị là `null`. Nút thoát đã được nhận ra ở hai ảnh; tool từ chối trước khi click. |
| Lần 2: theo người dùng, đứng tại phòng boss có nhân vật | 114/200, 114 WIN | **Chưa đủ bằng chứng xác định nguyên nhân đứng ban đầu.** Lý do dừng cuối log là `TARGET_PROCESS_EXITED`; người dùng xác nhận đã đóng/mở lại game sau khi thấy tool đứng. Vì vậy không dùng việc game thoát làm nguyên nhân ban đầu. Khoảng chờ cuối bị ngắt sau 13,786 giây, ngắn hơn tất cả 162 lần chờ trở về phòng thành công trong cùng bộ log. |

Cả hai farm run dùng **Demon Aegis Farm / Solo / BASIC**, mục tiêu Lieyun `1436`, giới hạn 200 trận và 250 attempts. Không phải run Bú win hoặc reasoning. Không có dấu hiệu hết mục tiêu, hết attempts hay hết ngân sách technical recovery: mỗi run có 0 technical recoveries và 0 technical aborts.

Mã ngoài cùng `RETURN_LOBBY_TIMEOUT` không đủ để chẩn đoán. Source hiện tại tại [tools/farm_run.py](/D:/PokiguardToolV2/tools/farm_run.py:5522) gom các kết quả trả về phòng không thành công vào mã này, kể cả bị từ chối route và mất tiến trình. Không được hiểu cả hai trường hợp là hết 90 giây chờ.

## 2. Bộ log và cách đọc thời gian

- `4bf54d3fa8f046239a141ec1448c4d3a`: farm lần 1, 50 attempts/50 completed.
- `62001bc838cf4584a3946b291f8101ee`: farm lần 2, 114 attempts/114 completed.
- `20261009_202109`: Desktop UI chứa cả hai farm run, 4.906 dòng events.
- `20261010_005547`: phiên UI mở lại, **không có farm run mới**; generation 0, starts 0. Không tính đây là một lần farm dừng thứ ba.

Timestamp trong JSON là UTC. Các bảng dưới đã cộng 7 giờ để trình bày theo giờ Việt Nam.

Các bản sao `farm_state_event` ở cuối `events.jsonl` được ghi dồn khi kết thúc run. Để xác định thời điểm xảy ra sự kiện nội bộ, dùng `run.json.snapshot.events[].timestamp`; không dùng thời điểm ghi dồn. Ví dụ sự kiện từ chối thoát room lần 1 xảy ra 14:46:02.734Z, được ghi vào JSONL lúc 14:46:03.080Z.

## 3. Lần 1: chặn thoát room lỗi vì phụ thuộc PlayerPrefs

### 3.1. Chuỗi sự kiện

Nguồn chính: [events lần 1](/C:/Users/Admin/Downloads/log/4bf54d3fa8f046239a141ec1448c4d3a/events.jsonl:348) và [run lần 1](/C:/Users/Admin/Downloads/log/4bf54d3fa8f046239a141ec1448c4d3a/run.json:1).

| Giờ Việt Nam ngày 09/10 | Bằng chứng |
| --- | --- |
| 21:43:57.877 | Attempt 49 trở về `BOSS_LOBBY_READY`; room `Coop_638684`, chủ phòng đúng tài khoản, boss Lieyun 1436, `clean=true`. |
| 21:44:08.928 | Attempt 50 vào trận thành công. |
| 21:45:18.581–18.602 | Trận 50 kết thúc, kết quả WIN được chụp và checkpoint ghi completed=50. |
| 21:45:22.813 | `POSTMATCH_CONFIRM` gửi thành công. |
| 21:45:23.194 | Memory WIN và UI “Thắng” nhất quán. |
| 21:46:01.209 | Chờ phòng trả về `CHINH_PHUC_MAP_CANDIDATE`, `ready=false`. |
| 21:46:02.734 | `chinh_phuc_room_shell_exit_rejected`, reason `atomic detached-room runtime proof changed`. |
| 21:46:02.738 | Route trả về `null`, không có shell-exit input. |
| Khoảng 21:46:03 | Run chuyển `SAFE_STOP / RETURN_LOBBY_TIMEOUT`, detail `CHINH_PHUC_MAP_CANDIDATE`; UI sau đó xác nhận STOPPED. Game vẫn được đọc với PID 8568. |

### 3.2. Tool thực sự thấy gì

Snapshot cuối có trạng thái room đã mất ownership nhưng còn dữ liệu/UI cũ:

- `current_room_id=null`, `current_room_type=null`, `owner_username=null`, `is_host=false`.
- `room_data` và `enemy_pet_id=1436`, `enemy_pet_name=Lieyun` còn tồn tại.
- Không có combat owner; lifecycle `lobby`, không còn board/rig/match ID.
- Panel Chinh Phục vẫn active, active island index 6. Vì vậy classifier báo `LOBBY_OTHER / CHINH_PHUC_ISLAND`.
- Runtime target boss 1436 được xác nhận ở **hai mẫu**, `clean=true`, proof `panel_button_index`, có Button geometry hợp lệ.
- **Cả hai mẫu ảnh đều tìm thấy nút thoát**, cùng tọa độ chuẩn hóa `(0.966796875, 0.05859375)`, confidence khoảng 0,978. Dấu hiệu nút Start của room cũng được nhận ra.
- PlayerPrefs: mọi trường selection là `null`, reason `PlayerPrefs read failed: [WinError 2] The system cannot find the file specified`, source `Software\Pokiguard\PokiguardOnlines`.

Các dấu hiệu này phù hợp với room lỗi người dùng mô tả. Bộ log không kèm PNG nên không xác minh độc lập toàn bộ hình ảnh hoặc vì sao game tạo ra room lỗi.

### 3.3. Điều kiện nào làm recovery thất bại

[Hàm kiểm tra thoát shell](/D:/PokiguardToolV2/tools/farm_run.py:1828) kiểm tra room mất owner, boss đúng mục tiêu và target runtime sạch. Khi có `first_map_target`, hàm còn yêu cầu:

```python
prefs = getattr(target, "prefs", None)
if getattr(prefs, "selected_pet_id", None) != pet_id:
    return False
```

Trong log: `selected_pet_id=None`, `pet_id=1436`. Điều kiện này **chắc chắn trả về False**, dù target từ memory đã `clean=true` và nút thoát đã được chứng minh bằng ảnh. Caller ghi lỗi chung “atomic ... proof changed”, trả `None`, sau đó farm loop dừng. Reason này không chỉ ra trường dữ liệu thực sự thất bại.

Đã đối chiếu nguyên hàm ở Git HEAD bản phát hành v1.2.4: điều kiện này có sẵn trong bản phát hành, không do thay đổi Bú win mới trong working tree.

Đã đánh giá độc lập **chỉ các hàm điều kiện thuần túy của bản phát hành** với dữ liệu JSON, không attach game, không gửi input:

| Dữ liệu trong Python | Kết quả |
| --- | --- |
| Room shape và target đúng như log; `selected_pet_id=None` | Map-backed room predicate True; shell-exit proof False. |
| Giữ nguyên dữ liệu, chỉ đặt `selected_pet_id=1436` trong đối tượng Python tạm | Shell-exit proof True. |

Thao tác thứ hai là kiểm tra giả định trên dữ liệu trong bộ nhớ của script phân tích, không phải sửa PlayerPrefs/game/tool.

**Nguyên nhân vận hành đã chốt:** recovery phụ thuộc một selection từ registry không đọc được; route từ chối thoát room lỗi và không tiếp tục re-entry. Chưa xác định nguyên nhân phía game/server tạo ra room lỗi ban đầu.

### 3.4. Bằng chứng bổ sung: đường dẫn PlayerPrefs cũ

Tool hard-code đường dẫn `Software\Pokiguard\PokiguardOnlines` tại [chinh_phuc_map.py](/D:/PokiguardToolV2/src/pokiguard_v2/chinh_phuc_map.py:99), đọc qua HKCU tại dòng 303.

Đọc **chỉ đọc** game đang cài trên máy chính:

- [app.info](/D:/pc/PetPuzzle-1.7.4_Data/app.info:1) có hai dòng `Pet Puzzle`, `Pet Puzzle`.
- Registry máy chính có cả `Software\Pokiguard\PokiguardOnlines` và `Software\Pet Puzzle\Pet Puzzle`.
- Chỉ đọc bốn trường selection, không đọc token/password: khóa cũ chứa SelectedPetId **650**, group index **0**; khóa mới chứa SelectedPetId **2534**, group index **16** tại thời điểm kiểm tra.

Unity lưu PlayerPrefs của Windows Standalone theo company/product trong HKCU. Do đó metadata bản game hiện tại tương ứng nhánh `Software\Pet Puzzle\Pet Puzzle`. [Unity PlayerPrefs documentation](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/PlayerPrefs.html)

Đây là bằng chứng đường dẫn tool đang dùng không khớp metadata game hiện tại trên máy chính. Máy chính còn khóa cũ có thể che khuất vấn đề bằng dữ liệu cũ; máy ảo báo không có khóa cũ nên selection thành null. **Chưa có app.info hoặc registry export của máy ảo** để xác nhận nhánh mới trên chính máy ảo; không biến suy luận này thành một phép đo đã thực hiện ở máy ảo.

### 3.5. Rà lại thiếu sót khi đổi tên game — 2026-10-10

Người dùng xác nhận tên chính thức đã đổi sang Pet Puzzle. Rà source và báo cáo tương thích cho thấy migration đã cập nhật tên launcher/process và window title, nhưng không cập nhật `PLAYER_PREFS_PATH`. [Báo cáo b6](/D:/PokiguardToolV2/docs/petpuzzle_1.7.4_b6_compatibility_report.md:25) trước đó khẳng định client vẫn sở hữu nhánh registry Pokiguard cũ; khẳng định này đã được đính chính bằng metadata game và đối chiếu hai nhánh registry. Việc khóa cũ tồn tại trên máy đã từng chạy Pokiguard không chứng minh nó đang được Pet Puzzle sử dụng.

Có hai thiếu sót của tool:

1. **Đường dẫn registry không gắn với company/product của bản game đang dùng.** Trên VM, mở nhánh cũ thất bại ngay tại `OpenKey`, trước khi đọc `SelectedPetId`; lỗi WinError 2 không phải lỗi hash tên value hoặc lỗi ép kiểu đọc cả key trong PowerShell ở trao đổi đăng nhập trước đó.
2. **Nhánh thoát room lỗi còn coi selection từ registry là điều kiện bắt buộc**, dù map discovery và `_map_target_matches_lobby` đã có nhánh dùng manager/panel runtime hiện tại. Do đó target `clean=true` ở bước discovery vẫn bị loại ở bước shell exit chỉ vì PlayerPrefs thiếu/cũ. Đây là sự không nhất quán giữa hai bước xác minh.

Hướng sửa cần được đánh giá sau khi được yêu cầu triển khai: resolve PlayerPrefs từ metadata company/product của đúng game installation; hỗ trợ nhánh legacy có kiểm soát và không trộn selection giữa các sản phẩm; phân biệt PlayerPrefs chưa có, cũ và mâu thuẫn; giữ kiểm tra boss/room ownership/lifecycle/visual trước input, đồng thời thống nhất giá trị chứng minh của runtime với nhánh shell-exit. Chỉ đổi đường dẫn chưa tự giải quyết mọi trường hợp prefs chưa được lưu hoặc stale.

Chưa sửa production code hoặc registry. Nguyên nhân phía game tạo room lỗi vẫn chưa xác định và không được quy cho lỗi registry của tool.

## 4. Lần 2: game bị đóng sau khi người dùng thấy đứng

Nguồn: [events lần 2](/C:/Users/Admin/Downloads/log/62001bc838cf4584a3946b291f8101ee/events.jsonl:793), [UI cuối phiên](/C:/Users/Admin/Downloads/log/20261009_202109/events.jsonl:4896), cùng xác nhận trực tiếp của người dùng: **“Tôi đã đóng/mở lại game vì thấy tool đứng.”**

| Giờ Việt Nam ngày 10/10 | Bằng chứng |
| --- | --- |
| 00:53:38.151 | Attempt 113 trả về `BOSS_LOBBY_READY`, room `Coop_175047`, đúng chủ phòng/boss, `clean=true`. |
| 00:53:41.479 | Input vào attempt 114 gửi thành công. |
| 00:53:46.578 | Entry 114 PASS, có fresh session `M_88136763`. |
| 00:54:00.421–00.478 | WIN/STRONG: boss HP=0, local HP=72019; completed=114. |
| 00:54:02.224 | UI snapshot `POSTMATCH`, controller RUNNING, `WAIT_BOSS_LOBBY / MATCH_ACCOUNTED`. |
| 00:54:02.944 | `POSTMATCH_CONFIRM` gửi thành công. |
| 00:54:03.330 | Memory WIN và UI WIN nhất quán. |
| 00:54:13.419 | UI ghi yêu cầu mở hộp chọn cách đóng tool; controller vẫn RUNNING. |
| 00:54:16.977 | Snapshot tiếp theo không đọc được các địa chỉ TypeInfo của room/ws/world; chưa có snapshot chứng minh room 114 sẵn sàng. |
| 00:54:17.116–17.117 | Lobby wait trả `TARGET_PROCESS_EXITED`; run chuyển SAFE_STOP, mã ngoài cùng `RETURN_LOBBY_TIMEOUT`. |
| 00:54:18.156 | Lệnh dừng khẩn cấp rồi đóng tool được acknowledge, **sau** sự kiện farm safe stop. |
| 00:54:18.982 | UI `DETACHED / process_exited`, PID không còn được cung cấp. |
| 00:55:48.198 | Phiên UI mở lại đọc game PID **1984**, khác PID **8568** trước đó; không có farm start/resume mới. |

**Không kết luận game crash:** người dùng đã xác nhận tự đóng/mở game. `TARGET_PROCESS_EXITED` giải thích điểm kết thúc bản ghi, không giải thích lý do người dùng thấy đứng trước đó. Lệnh emergency cũng đến sau farm safe stop nên không phải trigger của safe stop đã ghi.

### 4.1. So sánh độ trễ cùng máy ảo

Đo khoảng từ `postmatch_ui_audit` đến `normal_return_boss_lobby` cho các lần `BOSS_LOBBY_READY`:

| Farm run | Số lần thành công | Nhỏ nhất | Median | Lớn nhất |
| --- | ---: | ---: | ---: | ---: |
| Lần 1 | 49 | 30,215 giây | 35,574 giây | 41,441 giây |
| Lần 2 | 113 | 31,437 giây | 36,149 giây | 45,056 giây |
| Gộp | 162 | 30,215 giây | 35,952 giây | 45,056 giây |

Lần cuối bị ngắt sau **13,786 giây** tính cùng mốc. Từ click confirm đến sự kiện ngắt là **14,172 giây**. Không lần thành công nào trong bộ log nhanh dưới 14 giây.

Các UI snapshot cũng có khoảng im lặng dài ở ranh giới hậu trận: 167 khoảng giữa hai snapshot vượt 10 giây trong phiên UI; nhiều khoảng POSTMATCH → BOSS_LOBBY dài khoảng 34–43 giây. Khoảng cuối POSTMATCH → snapshot lỗi là 14,753 giây.

Số liệu cho thấy tool thường mất hàng chục giây mới công bố phòng sẵn sàng trên máy ảo. Nó **không chứng minh** lần 114 chắc chắn sẽ tự tiếp tục nếu để nguyên; cũng **không chứng minh** lần 114 đã treo vĩnh viễn khi người dùng đóng game.

### 4.2. Nhánh xử lý có thể tạo khoảng im lặng dài

Source có công việc đồng bộ trước khi publish lobby:

1. Khi combat lifecycle được xóa, [memory_board_provider.py](/D:/PokiguardToolV2/src/pokiguard_v2/memory_board_provider.py:2611) đặt `_needs_lobby_baseline=True`.
2. Khi Board đã mất và lifecycle về lobby, [poll()](/D:/PokiguardToolV2/src/pokiguard_v2/memory_board_provider.py:3560) gọi `_refresh_lobby_baseline()` trước khi trả quan sát lobby.
3. [Baseline refresh](/D:/PokiguardToolV2/src/pokiguard_v2/memory_board_provider.py:1673) gọi `_scan(..., force_full=True)` trên toàn bộ tập private writable regions đủ điều kiện; đây không phải một lần đọc vài field room.
4. Desktop observer và farm wait đều đi qua provider polling.

Counter trong combat summary 113 có `lobby_baseline_scans=113`, summary 114 có `lobby_baseline_scans=114`, xác nhận baseline được tạo lặp theo vòng đời trận. Summary được ghi **trước** lần chờ lobby cuối, không chứa thời gian thực hiện baseline cuối.

Đây là ứng viên cần đo thời gian để giải thích việc đứng có nhân vật trong phòng. **Log hiện không có thời gian bắt đầu/kết thúc từng baseline scan hoặc từng bước đọc lobby**, nên chưa thể gán chính xác toàn bộ 30–45 giây cho scan, game loading, hay cạnh tranh CPU trên VM. Không sửa hoặc bỏ baseline chỉ dựa trên tương quan này; baseline đang phục vụ chặn dữ liệu combat cũ.

### 4.3. Các trường không chứng minh trạng thái hiện tại

- `checkpoint.last_safe_lifecycle=BOSS_LOBBY` không xác nhận room cuối đã sẵn sàng. [Hàm tạo checkpoint](/D:/PokiguardToolV2/src/pokiguard_v2/farm_run.py:650) ghi trường này cố định. Phải đối chiếu runtime snapshot và `BOSS_LOBBY_READY` đúng attempt.
- `status=STOPPED` trong combat summary 114 thuộc controller trận đã kết thúc bình thường, kèm `POSTMATCH_RESULT_UI_REQUIRED`. Farm controller vẫn RUNNING sau đó; không dùng status này làm bằng chứng farm dừng sớm trong combat.
- `RuntimeTarget.is_running()` tại [runtime_common.py](/D:/PokiguardToolV2/tools/runtime_common.py:87) trả False cả khi GetExitCodeProcess thất bại hoặc khi exit code khác STILL_ACTIVE. Log không ghi exit code/GetLastError. Trong trường hợp này xác nhận người dùng đóng/mở game và PID mới giúp giải thích sự kiện cuối, nhưng bản thân tên reason chưa đủ làm bằng chứng game crash.

## 5. Phần đã loại trừ và phần còn thiếu

Đã loại trừ bằng log: đạt mục tiêu 200 trận; hết 250 attempts; hết technical recoveries; thua trận cuối; xung đột kết quả WIN/LOSS; lỗi reasoning; lỗi Bú win; thiếu nhận diện boss Lieyun; exception nội bộ FarmRunner. Cả hai `run.json` có `unexpectedError=null`; UI có 0 handled UI errors và 0 unhandled UI thread exceptions.

Chưa xác định: nguyên nhân game tạo room lỗi lần 1; nguyên nhân khoảng đứng ban đầu lần 2; thời lượng thực tế của từng công đoạn baseline/lobby read; đường dẫn PlayerPrefs của bản game trên chính VM. Không có crash dump, Player.log hoặc ảnh trong bộ log được cung cấp.

Để xác minh lần 2 mà chưa sửa code: khi tái hiện, ghi thời điểm đã nhìn thấy nhân vật/phòng và thời điểm tool ngừng tiến triển, giữ nguyên game/tool ít nhất một chu kỳ chờ lobby mặc định 90 giây nếu có thể, rồi lấy cả farm log và Desktop UI log. Nếu tool tự dừng thì lấy log trước khi đóng/mở game. Quan sát này sẽ phân biệt chờ lâu nhưng tự tiếp tục với đứng thực sự; vẫn cần telemetry thời gian từng bước nếu muốn chốt hàm gây chậm.

## 6. Trạng thái công việc

Chỉ hoàn thành điều tra và báo cáo. Không sửa code, không chạy farm thử, không đổi flow đọc memory/chụp ảnh/input, không sửa game hoặc registry. Phase 5B.3 vẫn tạm dừng.
