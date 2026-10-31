# PetPuzzle 1.7.4.9 — nhánh cập nhật tương thích

Ngày bắt đầu: 2026-10-20; kiểm tra tiếp sang 2026-10-21, Asia/Saigon.

Trạng thái: **B1 WIN 1/1 / B2 WIN 3/3 / ĐÃ ĐÓNG GÓI v1.2.6**.
Đây là nhánh phụ cập nhật game. Không mở thêm bước hoặc thay trạng thái Phase 5.

## 1. Danh tính và nguyên nhân phải cập nhật

Tên launcher vẫn là `PetPuzzle-1.7.4.exe`, dù người dùng cung cấp reverse
`reverse/reverse_1.7.4.9`. Tên EXE không đủ phân biệt hai build.

| File đọc trong `D:/pc` | Bytes | SHA-256 |
|---|---:|---|
| GameAssembly.dll | 69,642,240 | `4a8925cebbcc9004a4954dad8f04cadf01cf759ff418f84528053552e0cf156b` |
| UnityPlayer.dll | 38,201,768 | `bb93aa060395c4ace3561b4ceafe06cfaebd5dfb883c451058b9ccb74b50b6d2` |
| PetPuzzle-1.7.4.exe | 575,488 | `32ef7bdac0ffecd45d8f50dc4a715cf9585fefa5299ffc9207cd92a84a005929` |
| global-metadata.dat | 14,641,864 | `12a42d6ec99fe791997d466fe9b913da6dda0c9f09125c64c44a74a403c65226` |

GameAssembly: x64, timestamp `0x6AD7190A`, preferred base `0x180000000`,
SizeOfImage `0x04528000`. Metadata magic/version `0xFAB11BAF / 110`.
`app.info` vẫn ghi company/product `Pet Puzzle / Pet Puzzle`.
UnityPlayer và launcher giống byte với b6; GameAssembly và metadata đã đổi.
Toàn bộ file game chỉ được đọc.

Ảnh người dùng cung cấp chứng minh đổi màu/vị trí Start, đồ họa sảnh/bản đồ,
và modal thắng. Đối chiếu reverse còn chứng minh nhiều field memory dịch vị
trí. Do đó chỉ thay template hoặc thêm hash mới vào bảng địa chỉ cũ là sai.

Provenance và baseline trước thay đổi nằm trong
[thư mục bằng chứng](artifacts/game_1_7_4_9_20261020/). Baseline bao gồm toàn bộ
340 file Python có sẵn và git status ban đầu, giữ được các thay đổi dở dang
từ trước phiên này.

## 2. Migration đã thực hiện

### 2.1. Bảng đọc cùng một build

- 38 TypeInfo được chuyển theo tên symbol, kiểu C++ và .NET type;
  không cộng một delta chung. Một closure đổi tên phải lần riêng bằng native.
- 62 field offset thay đổi được đối chiếu bằng identity field và kiểu dữ liệu.
- Cập nhật thêm 3 read-size và vị trí block đồng hồ của observer.
- Chỉ allowlist GameAssembly mới. Binary b6 bị từ chối bởi source này, vì
  không được dùng chung hai hash với một bảng địa chỉ.

| Thành phần | Thay đổi quan trọng |
|---|---|
| MatchService | Turn `+0x50`, current player `+0x48`, timer `+0x1A0`, ACK set `+0x220`, Players `+0x118`; Fusion, QTE, pending/terminal/clock cùng được chuyển |
| ChatMessageDTO | type `+0x40`, MatchId `+0x100`, preBoard/ready `+0x4A8/+0x4B0`; kết quả QTE đổi theo field tương ứng |
| ChatService | explicitDisconnect/reconnect/connecting `+0x33D/+0x340/+0x34C` |
| CardData | cooldown `+0x94`, needPerfection `+0x98`, chất lượng `+0x9C/+0xA0/+0xA4`; read-size `0xA8` |
| ManagerQuangTruong | `_managerBoss +0x3E8` |
| Dispatcher | closure `ChatService.__c__DisplayClass321_0`, message/json vẫn `+0x20/+0x18` |

Chi tiết từng symbol và field:
[static_audit.json](artifacts/game_1_7_4_9_20261020/static_audit.json),
[adopted_layout.json](artifacts/game_1_7_4_9_20261020/adopted_layout.json).

Co-op `Active.PlayerStats` là `0x03CF4F98`; PVP là `0x03D4A6C0`, không lẫn
hai class. `Active`, `CardUI`, `RoomCoopV2Refs`, `RoomStartState` giữ layout
các field đang đọc. Các layout String/Delegate, List/Dictionary/Queue/HashSet,
Newtonsoft và Unity UI sử dụng ở đây đã được so với b6.
AuditionStage thêm `_lastTickFrame/+0x168`, `_lastTickAt/+0x16C` ở cuối;
field QTE mà tool đọc vẫn giữ vị trí. Xem
[library_layouts.json](artifacts/game_1_7_4_9_20261020/library_layouts.json).

### 2.2. Native bridge

`Component.get_gameObject` mới ở RVA `0x30CE030`: load tại `0x30CE06F` và
store tại `0x30CE08C` cùng chứng minh icall cache RVA `0x03F6BF30`.
Tên icall trong binary là
`UnityEngine.Component::get_gameObject_Injected(System.IntPtr)`.

Unmarshal prefix có đúng một hit, trong
`UnityEngine.Object.MarshalledUnityObject.Unmarshal`, được wrapper trên gọi:
RVA `0x190E53F`, bytes
`4885db7433f6c301740d488bcbe88fd790fe488bd8eb03488b1b`.
Static-fields `+0x98` được xác nhận lại từ native getter `Active.Instance`.
Không gọi các method này trong process game.

Toàn bộ chữ ký UnityPlayer cũ vẫn được kiểm trong constructor, không bỏ
signature gate. Native evidence:
[native_evidence.txt](artifacts/game_1_7_4_9_20261020/native_evidence.txt).

### 2.3. Giao diện

**Boss lobby / Start:** khung nút vẫn lấy từ đúng
`ManagerRoom.ButtonStart` và `RoomStartState`. Ảnh Start màu đỏ mới qua được
visual sanity check có sẵn khi cấp đúng rectangle. Không thêm tọa độ Start
ảnh chụp vào production; không đổi Ready/Start/Cancel semantics.

**Chinh Phục / đảo / boss:** panel, group/pet data và Button vẫn được ghép
theo runtime ownership. Native `ManagerChinhPhuc.OnReceived` mới tiếp tục
lấy `GetComponentsInChildren<Button>` trước khi tạo badge overlay; closure
pet click vẫn giữ field identity. Vì vậy không đổi sang click số thứ tự,
icon dấu chấm than hoặc tọa độ đảo trong ảnh. Native RectTransform xử lý
vị trí mới. Cần live kiểm việc chọn đúng boss/đảo và re-entry.

**Màn thắng:** detector cũ từ chối ảnh mới. Thêm variant blue/gold arena:
panel lớn, 4 góc vàng, 2 cánh sáng, đúng một nút xanh và label đã hiện.
Giữ điều kiện POSTMATCH, 2 frame ổn định và normal input ở caller cũ.
Không có click khi chưa xuất hiện chữ trên nút trong test mutation.
Native `MatchResultArenaTheme.Apply` dùng `btn_green`; banner win/lose/end
là các asset khác nhau. Ảnh thực chỉ có WIN, do đó LOSS/aborted/compact
không được nhận vơ là đã kiểm chứng.

5 PNG fixture là bản sao nguyên byte ảnh anh gửi, có
[provenance](../tests/fixtures/petpuzzle_1_7_4_9/provenance.json).
Các tọa độ annotation trong test chỉ là dữ liệu fixture, không phải
tọa độ input production. Scale ảnh không được tính là live mới.

## 3. Phạm vi giữ nguyên

Trong migration ban đầu, không thay solver, PlayStyle, thuật toán suy luận, controller quyết định,
thứ tự scan/capture/input, QTE executor, ACK policy, Stop hoặc farm state
machine. File provider/input/farm cũ giữ nguyên byte so với baseline phiên
này; thay đổi runtime nằm ở bảng đọc và thêm một variant visual result.
Không build/release hoặc tự mở tool.

Sau B1, người dùng yêu cầu sửa riêng kích thước/tâm viên. Bổ sung thay đổi
`runtime_calibration.py`, `win32_input.py` và 4 fallback geometry trong
`basic_auto_bot.py`; không đổi logic quyết định, thứ tự đọc/chụp/input,
gesture/timing, ACK, QTE, Stop hoặc flow farm. Phần sửa bổ sung có baseline,
manifest và test riêng, không ghi đè baseline migration ban đầu.

E1 đã chuẩn bị trước đó gắn source `7235ddc7...` và GameAssembly b6. Source
và binary hiện nay khác nên draft đó **không còn đủ authority để chạy**.
Không rebind, activate hoặc sửa bằng chứng/trạng thái Phase 5 ở nhánh phụ
này. Sau khi compatibility live pass, luồng chính cần requalify riêng.

## 4. Kiểm chứng và giới hạn

- 10 test mới dùng ảnh WIN thật và scale 800/960/1120/1280, 4 màn khác,
  thiếu panel/cánh/góc/nút/label, 2 nút gây nhập nhằng, Start đỏ và X sảnh.
- Lượt focused tiếp theo: 407 test, còn 1 kỳ vọng offset trong test đồng hồ;
  đã sửa `0x1C8/0x1CC` thành `0x1D8/0x1DC`, không nới validator.
- Full regression chạy **2.550 test / 737,274 giây**: 2.543 qua; 7 lỗi
  đều ở pin hash nguồn lịch sử, không có lỗi functional reader/input/farm.
  Đã sửa fixture lịch sử bằng cách pin chính xác cả successor mới và
  predecessor đã lưu; không nới production source/build gate. Test can thiệp
  current file, saved file hoặc manifest đều bị từ chối.
- Lượt kiểm lại đầu **71/71 PASS / 61,794 giây**, gồm cả 7 case thất bại.
  Sau đó bổ sung context guard và kiểm 72 case: 71 qua, 1 testcase kiểm
  nhầm controller AST thay vì full source binding. Controller vốn không
  đổi nên AST sub-audit qua là đúng. Sửa testcase để kiểm full source guard.
- Kiểm chốt **12/12 PASS / 51,843 giây**, gồm 10 test mới và việc full
  source guard mặc định tiếp tục từ chối lịch sử trên source mới, kể cả sau
  khi unit-test context đã thoát. Các case observer/D4 còn lại đã qua ở
  lượt 72 (chỉ fail testcase kiểm nhầm vừa nêu).
  Không chạy lại toàn suite sau sửa fixture test cuối; giữ nguyên log full
  thất bại, không tuyên bố một full run xanh chưa thực hiện. Các thay đổi
  sau full run chỉ thuộc fixture test và tài liệu.
- Read-only probe PID 14892, access `0x410`: native signatures PASS,
  MatchService/ChatService resolve, lifecycle lobby, không có read error.
  Board/Active/ManagerMatch instance null ngoài trận là hợp lệ. Không có
  input, screenshot, process method invocation hoặc network request.
- Probe đọc thấy chưa join room và 1 dynamic panel: classification
  `LOBBY_OTHER` fail closed. `_managerBoss` null không chứng minh lỗi nhận
  diện; không sửa dựa trên suy đoán về màn đang mở.
- Preferences thường giữ SHA `cfb792f1ad78e73a984b96bde1fd1536afbc6a7b920da7675f12e25ec66abb06`.

Log ban đầu thất bại được giữ lại. Nhiều test cũ tạo bytearray b6 nên phải
migrate fixture; thay expectation b6 thành mới chỉ khi reverse chứng minh.
Không dùng kết quả test giả để tuyên bố đã chơi được trên game mới.

Log: [full regression](artifacts/game_1_7_4_9_20261020/full_regression.log),
[context guard](artifacts/game_1_7_4_9_20261020/final_rechecks_context_guard.log),
[kiểm chốt](artifacts/game_1_7_4_9_20261020/final_qualification_boundary.log),
[phạm vi thay đổi](artifacts/game_1_7_4_9_20261020/scope_review.json).
Manifest rewind chỉ bật trong context unit-test tường minh. Các script
qualification vốn import chung helper vẫn mặc định kiểm source hiện tại;
không tự rewind hoặc nhận calibration cũ. Test riêng kiểm full source
binding tiếp tục bị từ chối (controller AST riêng vẫn có thể qua vì không
đổi controller). Không chỉnh artifact lịch sử trong
`docs/phase5`.

## 5. Điểm dừng live cần người dùng

### B1 ngày 2026-10-21: nguyên nhân đã xác định và bản sửa tọa độ

Run `e84738476d4e4b88a15bc5fcfa5d4f89`, match `M_51626dbc`: entry và opening
đọc đúng; policy chọn SWAP, đã gửi 2 click ở turn 1 nhưng không có ACK.
Người dùng F9 lúc 00:23:37, completed 0/1. Không tính là một trận live PASS.

Nguyên nhân cụ thể là calibration b6 còn sót: grid input khoảng 50.25 px/ô,
tâm ô đầu khoảng `(463,104)`; HUD mới có pitch khoảng 59.75 px/ô, tâm đầu
khoảng `(430.5,59.5)` ở client 1280x640. Nước đầu cần `(0,1)->(1,1)` nhưng
click `(520,96)->(507,156)`: hàng đầu đã lệch sang hàng 1, sau đó sang hàng 2.
Không phải policy chủ động bỏ lượt. Một nước sau có ACK không chứng minh
calibration cũ đúng cho toàn bộ bàn.

Reverse xác nhận layout động của `MatchHudV2` và công thức chia content rect
thành 8x8; ảnh opening gốc dùng để quy đổi ra pixel. Không có một hằng "60 px"
chung cho mọi viewport. Bản sửa chỉ dành profile 2:1 đang hỗ trợ, giữ công thức
client/screen có sẵn. Đã sửa random ±20% đang có trong source về đúng yêu cầu
**±10% chiều ngang/dọc một ô quanh tâm**, khoảng ±6 px tại 1280x640.

Đã thêm replay offline từ ảnh/log thật và kiểm toàn bộ 112 cặp swap, 4 profile,
cả cửa sổ ở monitor tọa độ âm. Log vòng đầu 55 test có 2 kỳ vọng geometry b6
thất bại; giữ lại log, chuyển hai test lịch sử dùng calibration b6 tường minh,
thêm test mới độc lập cho 1.7.4.9. Lượt kiểm cuối **104/104 PASS**, gồm mapping,
foreground/drag/Stop, input delivery/pinned board/pinned skill và farm hooks.
Lượt hồi quy bổ sung **42/42 PASS** kiểm desktop farm controller, controller
thực với fake input/ACK, Stop/fallback suy luận và các pin ancestry lịch sử.
Tổng hai lượt cuối **146 test PASS**; production source/build gate vẫn từ
chối calibration lịch sử trên binary/source mới.
Chưa chạy lại full suite sau sửa này; không dùng kết quả scale/replay làm live.

Chi tiết: [board resolution](board_resolution.md),
[bằng chứng bản sửa](artifacts/game_1_7_4_9_20261020/board_mapping_fix_20261021/).
Tool đang dừng; chưa tự mở phiên mới hoặc phát input để kiểm lại.

### B1 kiểm lại sau sửa: PASS trong phạm vi một trận

Run `a43e62c03f454c339762022928f292a8`, match `M_2148673f`, cùng Lieyun lv77,
Demon Aegis, Demon Farm BASIC, 4 Kiếm, client 1280x640 foreground/two_click.
WIN 1/1; 3 lượt người chơi, 3 năng lượng; dừng đúng `FARM_TARGET_COMPLETED`.

- 3 SWAP: turn 1 và 3 có `SWAP_ACKNOWLEDGED`; nước turn 5 kết thúc bằng
  lifecycle chuyển POSTMATCH, boss HP=0 và UI Thắng, confidence STRONG. Không
  ghi nhầm nước cuối là ACK riêng khi log chỉ chứng minh kết quả trận.
- Cả 6 điểm click khớp calibration mới, sai lệch tâm đo được tối đa 5 px và
  trong ±10% ô (có tính lượng tử hóa pixel). Không timeout action, click sai,
  input trùng/sai lượt, provider read error hoặc technical recovery.
- Bộ combat có `postmatch_observation_timeout=1s` khi hết quyền gameplay;
  đây là kết thúc quan sát để trả về farm owner (`basic_auto_bot.py:6597`),
  không phải stop lỗi. Farm owner tiếp tục đợi modal, thấy nút sau 1.906s,
  xác nhận ổn định sau 3.312s, phát đúng 1 postmatch click.
- Memory WIN và UI WIN nhất quán. Sau Đồng ý, room đúng Lieyun có Start
  interactable, lifecycle BOSS_LOBBY; run hoàn thành, không unexpected error.

Review: [review.json](artifacts/game_1_7_4_9_20261020/live_b1_mapping_retry_20261021_004730/review.json).
Người dùng cho phép tiếp 3 trận; đã đóng UI 1/1 khi STOPPED và mở phiên riêng
`live_b2_mapping_3matches_20261021_005206`, target/attempt limit đều 3, cùng
config, diagnostics bật; chưa tự Start/Resume. UI mới đã nhận Lieyun lv77,
BOSS_LOBBY, IDLE, 0 input. Không đổi source runtime hoặc Phase 5.

### B2: hoàn thành 3/3, đã nâng nhãn và build v1.2.6

Run `17034e22362d44fbad349040e29a07dd` có ba MatchId riêng:
`M_37ae8775`, `M_92995188`, `M_776b0abe`; cả ba WIN, lần lượt 5/5/1 lượt
người chơi. 11 swap, 8 ACK riêng; ba nước kết thúc trận có STRONG WIN khi
chuyển lifecycle, không được ghi nhầm thành ACK. Xác nhận thưởng và về đúng
phòng đủ 3 lần, dừng `FARM_TARGET_COMPLETED`, technical abort/recovery=0.

Không action timeout, misclick, duplicate hoặc wrong-turn input. Có đúng một
snapshot ACK HashSet đang thay đổi giữa lúc đọc ở trận 2, bị guard từ chối;
sau 0.803 giây có `stable_ack_attested_dto`. Read-error metric cộng dồn là
0/1/1 ở ba summary, không phải hai sự cố riêng. Không nới guard hoặc sửa code.

Người dùng yêu cầu build **v1.2.6** sau phiên này. Thay đổi production so với
source đã live chỉ là nhãn version; package self-check không phát input.
Xem [release report](v1.2.6_release_report.md) và
[B2 review](artifacts/release_v1_2_6_20261021/b2_review.json).

### Live còn lại (ngoài phạm vi B1/B2 đã hoàn thành)

Sau khi hồi quy đóng: người dùng dừng tool cũ, vào phòng boss solo từng farm
ổn, chưa Start. B1 tối đa 1 trận để kiểm entry, opening, ACK, nút Đồng ý
thật và return đúng phòng. B2 tối đa 3 trận tiếp để kiểm fresh MatchId và
vòng lặp. Nếu cần kiểm re-entry, người dùng chủ động chuẩn bị màn đảo/boss
map; không chủ động gây lỗi room hoặc phát input chưa được thống nhất.

LOSS/aborted, compact result, QTE và các đảo chưa quan sát được ghi pending
theo đúng bằng chứng còn thiếu; không bắt chạy hết mọi boss. Không tăng
soak khi có mismatch.

## 6. Các lần update sau

Theo [runbook cập nhật](game_update_compatibility_runbook.md). Tool mới
[audit_game_update.py](../tools/audit_game_update.py) tạo candidate diff từ
file Inspector và binary, không attach hoặc tự patch source. Chạy trước
khi migrate, khi source còn ứng với `--old`. Mỗi candidate vẫn phải kiểm
identity/ownership và native; script không cấp authority cho build mới.

Phân tích quét tool nằm trong
[báo cáo detection riêng](petpuzzle_1_7_4_9_detection_audit.md).
