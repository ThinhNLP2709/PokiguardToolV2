# Phase 4C.2 — Pinned Foreground Navigation/Re-entry Closure

## Trạng thái

`PASS STRONG`

Entry gate Phase 4C.1: `PASS STRONG`.

## Route được đóng

Nhánh Beta dùng nguyên route re-entry động đã có:

```text
postmatch / room rỗng
  -> X phòng cũ
  -> confirm rời phòng (nếu có)
  -> bản đồ Chinh Phục trực tiếp
     hoặc game lobby -> Chinh Phục
  -> đảo/pet được resolve từ runtime + config của farm session
  -> đúng phòng boss
  -> Start bằng delivery domain đã accepted ở 4B.3
```

Không có tên đảo, group, hunt order hoặc pet ID nào mới bị fix cứng. Target
được đối chiếu bằng cached GroupDTO/PetEnemyDTO, ManagerChinhPhuc/panel index
hiện hành, pet ID của farm session và quan hệ
`OnReceived: listPetEnemy[i] -> panelButtons[i]`. Tọa độ chọn boss là tâm native
RectTransform của cell Button đó; badge hunt-order là control thông tin riêng
và không còn tham gia route navigation. PlayerPrefs chỉ còn là authority dự
phòng khi runtime cũ chưa đọc được cặp manager/panel này.

## Thay đổi production

- `PinnedForegroundMouseSession` được truyền xuyên qua map-return và
  room-ejection recovery.
- Các transition `room shell exit`, `leave confirm`, `mở Chinh Phục` và
  `chọn target boss` dùng `InputDeliveryDomain.NAVIGATION_RECOVERY`.
- Giữa các action, Beta không yêu cầu game đang giữ foreground; game vẫn phải
  là đúng HWND/PID/kích thước và còn được pin topmost. Foreground mode giữ
  nguyên gate cũ.
- Ngay sau bounded acquire, mỗi click reread runtime để chứng minh
  control/target chưa đổi. Nút X/confirm riêng vẫn dùng fresh client proof;
  chọn boss dùng hai mẫu native Button/RectTransform ổn định và không chụp ảnh.
  Chỉ sau fresh proof mới reserve permit và gửi đúng một click.
- Nếu proof sau acquire stale, target/control đổi, pin/topmost mất, geometry
  không hợp lệ, emergency stop hoặc cleanup lease không `COMPLETE`, route dừng
  fail-closed và không retry click mù.
- ACK sau click vẫn là state transition cũ: modal/map/hub/room runtime và
  opening/session ACK. Không dùng trạng thái `SendInput` thành công làm ACK.
- Cursor park chỉ còn dùng trước proof của stale room-shell, nằm trong một mouse
  lease riêng và không tiêu FarmRun click permit. Nhánh native target không cần
  park cursor hoặc ảnh chụp.

## Replay/offline evidence

Replay mới bao phủ:

1. `WORLD_BOSS_LIST -> exact dynamic target -> boss room` trong khi app khác
   giữ focus giữa các action;
2. `DETACHED_ROOM_SHELL -> X -> general hub -> Chinh Phuc -> dynamic target ->
   boss room`;
3. leave-confirm modal dùng fresh post-focus proof;
4. hub control đổi ngay sau acquire: gửi 0 click và không tiêu permit;
5. mọi navigation lease dùng đúng typed domain và action identity chứa
   farm-run/attempt/pet cùng group/hunt-order khi chọn target;
6. foreground path cũ và các replay re-entry trước đây vẫn pass.

Kết quả xác minh:

- `test_farm_run.py`: **75/75 PASS**;
- full repository: **1541/1541 PASS**;
- `python -m compileall -q src tools tests`: **PASS**;
- `git diff --check` trên file thay đổi: **PASS**.

## Live acceptance còn lại

Chạy bằng `run_tool.bat`, chọn mode
`Ghim game để tự chơi khi dùng máy — Beta`. Không theo dõi live; chỉ đọc log
sau khi user báo kịch bản đã kết thúc.

Cần ít nhất hai cycle mà production thực sự phát hiện đã rời phòng, lấy lại
foreground theo lease, chọn lại đúng target động, trở về đúng phòng boss và
Start được trận kế tiếp. Với nhánh hiếm không xuất hiện tự nhiên (confirm modal
hoặc rơi tận game lobby), ghi `NOT_OBSERVED`; replay đầy đủ ở trên là evidence
bắt buộc thay thế, không được dựng claim live.

Mỗi cycle phải có:

- navigation lease `COMPLETE`, fresh post-focus preflight accepted;
- đúng một permit/click cho mỗi transition thực sự xuất hiện;
- đúng pet/group/hunt-order của farm session;
- room và opening/session mới được ACK;
- zero wrong target, duplicate click, stale proof, partial input, extra entry;
- cursor/guard/focus cleanup sạch và pin được gỡ khi run dừng.

Chỉ sau hai cycle sạch mới đổi kết quả thành `PASS STRONG` và chuyển sang
`prompts/4D1_PINNED_FOREGROUND_AB_ACCEPTANCE.md`.

## Live soak bổ sung — chưa đóng re-entry gate

Ngày 2026-09-27, production Beta với client `960x480` hoàn tất chuỗi nối tiếp:

- checkpoint đầu dừng an toàn ở 33/50 do một native-card geometry fence tạm
  thời trước input;
- remediation chỉ cho phép re-arm trong cùng QTE lease khi card click và Space
  đều bằng 0; mọi lỗi sau input vẫn terminal;
- resume hoàn tất đủ `50/50 WIN`, `0 LOSS`, target `COMPLETED`;
- full regression sau remediation: `1548/1548 PASS`;
- 17 trận sau resume không tái diễn
  `PINNED_QTE_ZERO_INPUT_LEASE_CONSUMED`, không có `WINDOW_CHANGED` hay lỗi
  geometry thẻ;
- cả 50 trận đều đi qua `normal_return_boss_lobby`; số production re-entry
  cycle được quan sát vẫn là `0/2`.

Kết quả này là reliability evidence mạnh cho profile cửa sổ và QTE lease,
nhưng không thay thế live acceptance gate của 4C.2. Phase vẫn
`OFFLINE PASS — LIVE PENDING`.

## Live re-entry attempt 1 — fail, remediation offline pass

Run `6d0186333f20438eaf8d6d0935c87d15` hoàn tất trận đầu bằng chứng mạnh:
`WIN`, checkpoint `1/5`, rồi người vận hành nhấn X ngay sau ACK kết trận. Runtime
đọc đúng màn hình đã chuyển sang `CHINH_PHUC_ISLAND` và
`clean_for_chinh_phuc_map=true`, nhưng vẫn còn `ManagerRoom.roomData` cùng
`ButtonStart` cũ. Code đã coi các field stale này là
`DETACHED_ROOM_SHELL_CANDIDATE`, chờ tìm nút X của phòng trong 90 giây rồi
dừng an toàn với `RETURN_LOBBY_TIMEOUT`. Không có click navigation sai.

Remediation:

- panel đảo sạch, lifecycle lobby và không còn room owner nay được phân loại
  riêng là `CHINH_PHUC_MAP_CANDIDATE`, ưu tiên hơn roomData stale;
- route này scan target động và chứng minh badge bằng hai frame rồi chọn đúng
  boss trực tiếp; không gửi thêm room-shell X;
- trạng thái desktop được publish ngay tại `MATCH_ACCOUNTED`, nên số trận đã
  ghi checkpoint không còn hiển thị trễ trong khi re-entry đang chạy;
- regression mới mô phỏng đúng shape live: đảo sạch + stale roomData + không
  có room-shell control; kết quả chỉ một target-select, không có shell-exit;
- nhóm farm cycle/run: `114/114 PASS`; full repository: `1549/1549 PASS`;
  compileall và diff check: PASS.

Đây là cycle fail rồi được sửa, chưa được tính vào yêu cầu hai cycle live sạch.
Gate re-entry vẫn `0/2` cho tới khi chạy retry production.

## Live re-entry attempt 2 — đúng nhánh, target proof bị loại và đã sửa

Run `7335ce37dddd4e18b34f79eb4a5ff561` xác nhận remediation attempt 1 hoạt
động: sau khi người vận hành nhấn X, tool nhận đúng
`CHINH_PHUC_MAP_CANDIDATE`, `CHINH_PHUC_ISLAND`, lifecycle lobby và owner-free
map. Trận đã được account `1/5 WIN`. Tool không gửi navigation click nào rồi
dừng an toàn vì `discover_chinh_phuc_map_target(...)` trả `null`.

Probe read-only trên đúng màn hình dừng chứng minh hai nguyên nhân cụ thể:

- closure Starburst `1289` cùng `ManagerChinhPhuc` nằm trong một private
  writable allocation 16 MiB; giới hạn fallback 8 MiB đã loại allocation này;
- runtime hiện hành báo manager `2647914532096`, active panel `5`, target group
  `5`, hunt order `8`, trong khi PlayerPrefs vẫn giữ pet `650`, group `0` và
  không có active panel. Đây là registry stale sau đường X, không phải trạng
  thái của bản đồ đang hiển thị.

Remediation thứ hai:

- khi snapshot bản đồ có manager + active panel, resolver chỉ quét đúng OS
  allocation chứa manager, tối đa 16 MiB; closure bắt buộc trỏ lại đúng manager;
- cached target group phải bằng live active panel; pet ID, Button native,
  interactable/groups-allow, lock state và badge hai frame vẫn được giữ;
- PlayerPrefs stale được lưu trong telemetry nhưng không còn phủ quyết cặp
  manager/panel hiện hành; đường fallback cũ vẫn giữ nguyên khi hai field live
  chưa có;
- atomic preflight và post-focus preflight cùng đối chiếu manager, panel,
  Button managed/native và target identity; nhánh shell/hub cũng dùng resolver
  có runtime hint khi bản đồ đã xuất hiện.

Probe live sau sửa nhận đúng Starburst `1289`, group `5`, hunt order `8`,
`clean=true`, scan đúng 1 allocation 16 MiB trong khoảng `0,58 s`. Regression
bao phủ PlayerPrefs stale, manager mismatch, panel mismatch và direct-map có
stale room data. Full repository: `1552/1552 PASS`.

Attempt 2 là một cycle fail rồi được sửa nên chưa tính acceptance. Gate re-entry
vẫn `0/2`; cần restart tool để nạp source mới rồi chạy retry production.

## Live re-entry attempt 3 — target đúng nhưng kẹt ở transient map

Run `92ceb87f66cf426ca03538f2281a7170` hoàn tất `2/5 WIN`. Sau trận thứ hai,
tool nhận đúng `CHINH_PHUC_MAP_CANDIDATE`. Mẫu runtime đầu tiên xuất hiện giữa
quá trình Unity chuyển layer:

```text
branch=CHINH_PHUC_MAP
manager_chinh_phuc=2647171221504
chinh_phuc_panel_main_active=false
chinh_phuc_active_panel_index=null
```

Do cặp manager/panel chưa hoàn chỉnh, helper đã rơi về legacy scan thay vì đợi
panel. Scan 672 region / 432.292.351 byte mất gần hết cửa sổ 8 giây. Nó vẫn tìm
đúng Starburst `1289`, group 5, hunt order 8 và `clean=true`, nhưng chỉ có một
mẫu nên gate hai mẫu ổn định dừng an toàn. Sau khi tool dừng, probe trên cùng
màn hình đọc được `CHINH_PHUC_ISLAND`, `panel_main_active=true`, active panel
5: game đã hoàn tất chuyển sang Đảo Rồng.

Remediation:

- manager có nhưng panel còn `null` được coi là transition chưa hoàn tất;
  không chạy fallback scan rộng và không gửi input;
- loop chờ cặp manager/panel hoàn chỉnh, sau đó dùng scan neo 16 MiB và yêu cầu
  hai target sample ổn định như trước;
- cửa sổ chờ target runtime tăng từ 8 lên tối đa 15 giây, vẫn nằm trong return
  timeout hữu hạn;
- regression mô phỏng đúng chuỗi `CHINH_PHUC_MAP/panel=null ->
  CHINH_PHUC_ISLAND/panel=5`; mẫu đầu gửi 0 scan/click, ba lần discovery sau
  đều nhận runtime hints chính xác.

Focused re-entry suite: `125/125 PASS`; full repository: `1553/1553 PASS`.
Attempt 3 chưa tính acceptance; gate vẫn `0/2` và cần retry sau khi restart UI.

## Live re-entry attempt 4 — island data load vượt cửa sổ 15 giây

Run `ce410cb985e54bb682c05185ce2d0d7d` hoàn tất `1/5 WIN`. Sau X, tool đọc
đúng owner-free `CHINH_PHUC_MAP` và giữ nguyên zero-input. Trong cả 15 mẫu của
cửa sổ chờ, manager `2638189859840` đã có nhưng `panel_main_active=false` và
`active_panel_index=null`; đúng theo remediation attempt 3, không có legacy
scan rộng, target scan hay navigation click nào. Tool dừng vì timeout nội bộ
15 giây. Probe read-only sau khi dừng đọc cùng manager với
`CHINH_PHUC_ISLAND`, `panel_main_active=true`, active panel 5 và metadata
Starburst/Đảo Rồng chính xác.

Như vậy lần dừng này không phải nhận sai đảo hoặc target. Data/panel của game
có thể hoàn tất sau hơn 15 giây. Cửa sổ target-runtime nay dùng toàn bộ
`return_lobby_timeout` đã cấu hình, vẫn chặn cứng ở tối đa 120 giây. Trong lúc
cặp manager/panel chưa hoàn chỉnh, tool chỉ poll owner/lifecycle, ghi event
`chinh_phuc_map_runtime_transition_wait` khi shape đổi, gửi 0 input và chạy 0
memory scan. Khi panel 5 xuất hiện mới bắt đầu hai anchored scan và visual
proof hiện có.

Focused suite giữ `125/125 PASS`; full repository `1553/1553 PASS`, compileall
và diff check PASS. Attempt 4 chưa tính acceptance; gate vẫn `0/2`.

## Live re-entry attempt 5 — room hợp lệ biến mất trước atomic Start preflight

Run `3b73a0379c8a487b8b21f31639166720` hoàn tất `1/5 WIN`. Sau khi tool bấm
ACK kết trận, `_wait_boss_lobby` quan sát hai frame phòng Starburst sạch và
FarmRun chuyển sang `ENTRY_READY`. Người vận hành bấm X trong khoảng giữa
proof đó và atomic preflight của Boss Start. Preflight đọc lại runtime, phát
hiện phòng đã đổi và trả `ENTRY_PREFLIGHT_RUNTIME_CHANGED`; `entryClicks=0`,
`entryRetryClicks=0`, không có input Start. FarmRunner cũ coi mọi kết quả entry
khác PASS là `OPENING_ACCEPTANCE_INVARIANT_FAILED`, nên dừng toàn run trước khi
router bản đồ có cơ hội chạy.

Remediation:

- `ENTRY_PREFLIGHT_RUNTIME_CHANGED` trước khi reserve/send Start được phân loại
  là navigation transition zero-input, không phải match failure;
- state machine quay `ENTRY_READY -> WAIT_BOSS_LOBBY`, rồi dùng lại bounded
  lobby/map router và toàn bộ manager/panel, target, visual và post-focus proof
  hiện có;
- nếu đã có permit/input, hoặc route không thuộc controlled re-entry, hệ thống
  vẫn fail closed như trước;
- match/attempt không tăng; artifact entry cũ được giữ và mỗi preflight retry
  dùng thư mục riêng, không ghi đè bằng chứng;
- cùng một attempt chỉ được reroute tối đa ba lần, tránh loop vô hạn khi runtime
  liên tục đổi;
- collision thư mục ngoài đúng reroute vẫn là invariant error, không bị che bởi
  `exist_ok` rộng.

Regression mới chứng minh reroute không tăng attempt, không ghi lobby input,
không tăng safety counter và có thể trở lại `RESOLVE_TARGET`. FarmRun/BossEntry
`101/101 PASS`; full repository `1555/1555 PASS`; compileall và diff check
PASS. Attempt 5 là cycle fail rồi
được sửa, chưa tính acceptance; gate vẫn `0/2`.

## Live re-entry attempt 6 — map hiện hành không còn runtime Button closure

Run `c17380ce70d1476d8719061f10e4ec2e` hoàn tất `2/5 WIN`, tổng 12 năng
lượng. Sau trận thứ hai game về đúng màn hình Đảo Rồng và tool giữ trạng thái
`RETURNING_TO_LOBBY`. Đây không phải vòng treo vô hạn: runtime wait chạy đủ 90
giây, thực hiện 101 probe/101 scan, gửi 0 navigation click rồi dừng an toàn với
`RETURN_LOBBY_TIMEOUT`.

Snapshot và probe read-only trên màn hình lỗi cùng xác nhận:

```text
branch=CHINH_PHUC_ISLAND; lifecycle=lobby; owner-free=true
ManagerChinhPhuc=1556498524416; active_panel_index=5
cached target=Starburst/1289; group_index=5; pet_index=7; hunt_order=8
boss_display_level=73; locked=false; island=Đảo rồng
```

Scan allocation của manager thấy 481 managed Button và 297 closure lịch sử,
nhưng không có closure Starburst thuộc manager hiện hành; các Button lịch sử đã
bị Unity hủy có native pointer bằng 0. Mảng Button trực tiếp của manager vẫn có
native pointer sống nhưng không chứa runtime listener. Vì resolver cũ bắt buộc
phải có `DisplayClass41_0` hiện hành nên cả 101 lần đều trả `null`, mặc dù
manager, active panel và cached server data không đổi.

Remediation:

- closure Button sống vẫn là proof ưu tiên khi Unity còn publish nó;
- khi không có closure target sống, resolver được phép dùng đúng
  `ManagerChinhPhuc` hiện hành + active panel + target duy nhất trong
  `cachedPetData`; pet phải thuộc đúng panel và `locked=false`;
- Button lịch sử có native pointer null không được coi là mâu thuẫn; một closure
  target còn sống nhưng trỏ manager khác, không interactable hoặc không hợp lệ
  vẫn chặn fallback và fail closed;
- nhánh manager-cache không tự tạo tọa độ: hunt order 8 vẫn phải có đúng một
  badge được nhận diện ở hai frame ổn định; atomic preflight và post-focus
  preflight đọc lại manager, panel, cached pet, lifecycle, owner và badge trước
  khi reserve đúng một click bình thường;
- `proof_source` được đưa vào so sánh ổn định để target không thể đổi âm thầm
  giữa closure proof và manager-cache proof.

Focused map/FarmRunner suite: `92/92 PASS`; full repository:
`1558/1558 PASS`; compileall và diff check PASS. Attempt 6 là cycle fail rồi
được sửa, chưa tính acceptance; gate re-entry vẫn `0/2`.

## Live re-entry attempt 7 — runtime đổi trong pinned Start preflight bị mất nguyên nhân

Run `be8e9632296b4047aa187e24961c85cb` hoàn tất trận đầu `WIN`, checkpoint
`1/5`, rồi ACK kết trận trở về đúng phòng Starburst. Entry kế tiếp đã resolve
đúng room, target và nút Start. Trong khoảng quét chuẩn bị transport bên trong
pinned mouse lease, game chuyển khỏi room sang boss map. Post-focus preflight
đọc lại runtime và chặn action đúng cách:

```text
status=STALE_ACTION
reason=post-focus preflight rejected before input
action_attempted=false
click=null
entryClicks=0
entryRetryClicks=0
```

Lớp pinned lease cố ý chuẩn hóa callback bị từ chối thành `STALE_ACTION`, nhưng
Boss Entry cũ làm mất nguyên nhân `ENTRY_PREFLIGHT_RUNTIME_CHANGED` và trả
`FARM_ENTRY_CAPABILITY_DENIED`. Vì vậy nhánh zero-input navigation reroute của
attempt 5 không được kích hoạt và run dừng
`OPENING_ACCEPTANCE_INVARIANT_FAILED` ngay trên boss map.

Remediation:

- post-focus callback nay ghi lại nguyên nhân cụ thể trước khi trả `false`;
- chỉ `STALE_ACTION` có `action_attempted=false`, `click=null` và không có lỗi
  lease mới được mang nguyên nhân đó qua biên pinned lease;
- runtime/room đổi được trả lại đúng `ENTRY_PREFLIGHT_RUNTIME_CHANGED`, nên
  FarmRunner dùng bounded lobby/map router hiện có mà không tăng attempt hay
  gửi Start click;
- lỗi geometry/lease, transport, input capability, emergency stop và trường
  hợp action đã bắt đầu vẫn terminal như trước;
- log `entry_stopped` nay giữ `postFocusPreflightReason` và
  `actionAttempted` để phân biệt race màn hình với lỗi input.

Focused Boss Entry/FarmRunner: `104/104 PASS`; full repository:
`1560/1560 PASS`; compileall và diff check PASS. Attempt 7 là cycle fail rồi
được sửa, chưa tính acceptance; gate re-entry vẫn `0/2`.

## b5 island-status prerequisite repair

Sau migration b5, probe chỉ đọc ngay trên Đảo Rồng xác nhận graph hiện hành
đầy đủ (`panelChinhPhuc=true`, `panelMain=true`, active panel index `5`) nhưng
desktop/router vẫn nhận nhánh rỗng. Nguyên nhân là classifier cũ bắt buộc
`UIPanelManager.openOrder.Count == 0` cho mọi surface Chinh Phục; đảo detail
thực tế có đúng một dynamic panel nên tự bị loại thành `LOBBY_OTHER`.

Classifier nay phân biệt hai proof hợp lệ: map có zero dynamic panel, hoặc đảo
có đúng một dynamic panel kèm `panelMain` active và một active island index duy
nhất. Trạng thái thiếu/mơ hồ vẫn fail closed. Probe lại trên cùng màn hình trả
`CHINH_PHUC_ISLAND`, tên `Đảo rồng`, không gửi input. Full repository:
`1572/1572 PASS`. Đây là prerequisite fix; gate live re-entry 4C.2 vẫn `0/2`.

## Live re-entry attempt 8 — Boss Entry giữ room cũ và UI suy diễn sai surface

Run `bbf847711d504a4d823f8367f6212496` hoàn tất trận đầu `WIN`, checkpoint
`1/3`. Sau ACK, FarmRunner quan sát phòng Starburst sạch và resolve target cho
attempt kế tiếp. Người vận hành bấm X ngay sau đó. Log Boss Entry ghi đúng quá
trình chuyển đổi, không có input Start:

```text
19:03:31.492  CHINH_PHUC_ROOM / Starburst resolved
19:03:31.590  Start visual proof chưa ổn định
19:03:31.770  owner-free transition
19:03:31.950  CHINH_PHUC_ISLAND / active panel 5
19:06:31.305  ENTRY_TIMEOUT_BOSS_LOBBY
```

Nguyên nhân là vòng `LOCATE_ENTER_BUTTON` đã khóa room cũ nhưng khi room biến
mất lại quay về vòng chờ lobby chung. Nó đợi hết 180 giây thay vì trả biến cố
navigation cho FarmRunner. Đồng thời desktop control plane không đọc runtime
sống khi controller active; nó ánh xạ máy trạng thái `RESOLVE_TARGET` thành
`BOSS_LOBBY`, khiến UI tiếp tục hiện phòng Starburst dù bộ đọc độc lập đã nhận
đúng Đảo Rồng.

Remediation:

- sau khi exact room/target/button được resolve, vòng visual-proof kiểm tra lại
  room context ở mỗi sample;
- nếu room, target, button hoặc surface đổi trước input, Boss Entry trả ngay
  `ENTRY_PREFLIGHT_RUNTIME_CHANGED` với zero input;
- FarmRunner dùng nhánh navigation reroute hiện có để tìm lại target trên đảo,
  không tăng attempt và không biến transition thành entry timeout;
- desktop UI đọc runtime sống tại các boundary
  `WAIT_INITIAL_BOSS_LOBBY/RESOLVE_TARGET/WAIT_BOSS_LOBBY`; trong combat vẫn dùng
  projection nhẹ của controller để tránh quét board kép.

Focused Boss Entry/Desktop/FarmRunner: `129/129 PASS`; full repository:
`1576/1576 PASS`; compileall PASS. Attempt 8 chưa tính acceptance; gate re-entry
vẫn `0/2` và cần restart source UI trước live retry.

## Sửa tọa độ chọn boss trên bản đồ — badge 8 không phải hitbox vào phòng

Log run `d3f1ce2dbfac4399865ea841cd80967a` chứng minh target bộ nhớ đã đúng
Starburst (`petId=1289`, `pet_index=7`, thứ tự 8), nhưng executor lại lấy tâm
badge thứ tự làm tọa độ `(1020, 522)`. Click này chỉ mở bảng thông tin boss nên
không thể vào phòng.

Reverse b5 xác nhận `ManagerChinhPhuc.OnReceived` ghép
`listPetEnemy[i]` với `buttons[i]`. Badge được tạo ở layer riêng sau đó và
`EnsureOrderBadgeTap` gắn callback mở `HuntBossInfoTip`; nó không phải cell
Button mở phòng. Route re-entry nay đọc trực tiếp Button thứ 8 trong panel Đảo
rồng, kiểm tra ownership/trạng thái/geometry rồi click tâm RectTransform của
Button đó. Nhánh này không chụp màn hình và không dùng badge để suy ra tọa độ.

Test hồi quy có cả badge button được tạo sau cell buttons, bảo đảm pet index 7
vẫn chọn cell Button thứ 8 và không chọn badge. Focused suite sau sửa:
`129/129 PASS`; full repository `1575/1575 PASS`; compileall và diff check
PASS. Đây là baseline trước live run cuối được ghi ngay dưới đây.

## Live acceptance cuối — 2/2 re-entry sạch

Run `f591da152cbe47dd9b7ef501f9c079a8` hoàn tất đúng mục tiêu `3/3`, cả ba
trận đều `WIN`, `3 attempts`, không technical recovery/abort/exit và dừng bằng
`FARM_TARGET_COMPLETED` / `COMPLETED`.

Giữa ba trận có đúng hai production re-entry cycle. Cả hai cycle đều ghi:

- target `petId=1289`, `pet_index=7`, `hunt_order=8`, active group/panel `5`;
- `proof_source=panel_button_index` và hai frame runtime ổn định;
- cùng native Button RectTransform
  `(0.084394, 0.589951, 0.228305, 0.856292)`;
- click đúng tâm cell Button `(0.156350, 0.723122)`, `clickStatus=SENT`;
- post-focus preflight accepted, vào đúng phòng Starburst và nhận opening/session
  mới cho trận kế tiếp;
- zero wrong target, stale/duplicate/partial input, reject, timeout hoặc error;
- pinned session cleanup hoàn tất sau target match thứ ba.

Kết luận gate live `2/2 PASS`; Phase 4C.2 đạt `PASS STRONG`. Router chuyển sang
`prompts/4D1_PINNED_FOREGROUND_AB_ACCEPTANCE.md`; không triển khai A/B trong
phase này.
