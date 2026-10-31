# PetPuzzle1.7.4-b12 compatibility — 2026-10-26

Follow-up: BASIC1 đã ghi WIN và result UI nhất quán, nhưng return/re-entry dừng
vì FOREGROUND_LOST sau thưởng, chưa full B1 acceptance. Cùng ngày có sửa riêng
provider Khủng long; các hash/scope phía dưới là snapshot trước sửa này.
[Log BASIC1 và bản sửa Dino](dinosaur_native_board_fix_20261026.md).

Đã cập nhật source theo reverse b12, thay đồng bộ profile b10. Probe chỉ đọc
đã nhận đúng phòng Lieyun77 và nút Start của game đang chạy. Chưa gửi input,
chưa chạy trận live, chưa build lại ZIP1.2.9. Không thể kết luận farm ổn định
chỉ từ kiểm tra offline/phòng chờ.

## Build identity và phạm vi

Reverse: `reverse/reverse_1.7.4-b12`, so với `reverse_1.7.4-b10`.
Source trước tác vụ:360Python files, fingerprint
`a7b4de25a93732192ba8372e9dd29133cae52b03c6c8375e1a7a9fec062e9632`.
Bản sao đầy đủ Python trước tác vụ được giữ trong artifact `before/`.

| File trong `D:\pc` | Bytes | SHA256 |
|---|---:|---|
| GameAssembly.dll | 70,144,000 | `51eaeff77252e7119647a590c534196093b36e752115b500672f24da758f1064` |
| UnityPlayer.dll | 38,201,768 | `bb93aa060395c4ace3561b4ceafe06cfaebd5dfb883c451058b9ccb74b50b6d2` |
| PetPuzzle-1.7.4.exe | 575,488 | `32ef7bdac0ffecd45d8f50dc4a715cf9585fefa5299ffc9207cd92a84a005929` |
| global-metadata.dat | 14,709,140 | `69c0881d51078ca9cdbac92637175f96163c806357da7c3d0fd61648281cd8c5` |

GameAssembly PE machine0x8664, timestamp1792956183, preferred base0x180000000,
SizeOfImage73,015,296. Preferred base chỉ là dữ kiện file; runtime vẫn resolve
base module theo ASLR. Metadata magic0xFAB11BAF/version110. Launcher và
UnityPlayer byte-identical với b10. Company/product từ `app.info` vẫn là
Pet Puzzle/Pet Puzzle; không đổi discovery/registry theo tên folder.
[Danh tính và audit](artifacts/game_1_7_4_b12_20261026/static_audit.json).

## Thay đổi có bằng chứng

-39/39 TypeInfo có match exact symbol/type/.NET identity, không cộng một delta
  chung. Bao gồm board/lifecycle/transport, room/map, card/pet/QTE, Newtonsoft
  opening JSON và PlayReminder. Không có root unresolved trong reverse.
-257 mapped managed field candidates giữ nguyên tên, kiểu và offset.28 library
  layouts, nested co-op Active.PlayerStats và ChatService closure cũng bằng
  b10. Co-op PlayerStats0x3D6E4A0 khác PvP0x3D746C8.
-101 enum có sẵn giữ nguyên domain;3enum mới thuộc quest/PIN. RoomStart
  Phase0–3/Action0–4 không đổi. Không suy ra semantics toàn bộ method không đổi
  chỉ từ việc field/enum bằng nhau.
-Native Component.gameObject cache đổi0x3F72288→0x3FE1650; load/store cùng trỏ
  địa chỉ mới. Unmarshal signature chuyển0x191413F→0x19740BF và cập nhật đủ
  26byte. Wrapper/tail/export đều đối chiếu installed binary.17/17 native
  UnityPlayer signature match. Active/Board getter vẫn dùng static_fields+0x98.
-Dot.multiplier+0x88/BoardCellDTO.multiplier+0x20 không đổi;
  Board.GetDotMultiplier b12 vẫn có load+0x88. Giữ cách đếm Kiếm hiệu dụng và
  cấu hình Viên mục tiêu hiện tại.

Game thêm/sửa field ở26 top-level types, trong đó có MatchHudV2,
MatchResultArenaTheme, RoomCoopFit/RoomSlotView và BoardWsApplier. Các field
production đang đọc không đổi; không coi toàn bộ UI/flow game là byte-identical.
[Native/layout evidence](artifacts/game_1_7_4_b12_20261026/native_layout_evidence.json),
[enum và native field loads](artifacts/game_1_7_4_b12_20261026/semantic_evidence.json).

Chỉ7runtime modules thay đổi constant/docstring:
`boss_lobby_runtime.py`, `chinh_phuc_map.py`, `il2cpp_external.py`,
`opening_snapshot.py`, `play_reminder.py`, `native_card_ui.py`, `game_location.py`.
AST sau khi mask các constant được duyệt bằng AST trước tác vụ. Các file
src/tools khác giữ nguyên bytes. Không đổi solver, lối chơi, thứ tự đọc,
executor, QTE, random hoặc cơ chế Khủng long. Allowlist chỉ chấp nhận b12 với
đúng bảng RVA b12; không trộn hash b10 với layout mới.
[Migration và hash từng file](artifacts/game_1_7_4_b12_20261026/constant_migration.json).

## Geometry và giới hạn suy luận từ reverse

Existing MatchHudV2 constants bằng b10. Các constant mới liên quan affix/team
HUD. So native có giới hạn: SolveBoard52instruction và
GetCellBaseWorldPosition215instruction bằng evidence1.7.4.9 sau normalize
relocation/call target ngoài hàm; so cả float và branch nội bộ. Whole Layout
có bổ sung HUD nên chưa có bằng chứng mọi pixel giữ nguyên.

Giữ board calibration/jitter hiện tại, không đổi size theo phỏng đoán. Các test
64tâm ô/112swap/4size dựa ảnh1.7.4.9 là regression fixture lịch sử. B12 cần
ảnh bàn thật và swap có ACK để xác nhận mapping hiện tại.
[Geometry evidence](artifacts/game_1_7_4_b12_20261026/geometry_evidence.json).

## Readonly runtime

Game PID17288, executable đúng `D:\pc\PetPuzzle-1.7.4.exe`, x64.
Resolve39slots:28initialized và đọc được đúng class identity,11chưa initialize ở scene phòng chờ; không ép
khởi tạo class bằng gọi game. Native bridge signature validation PASS.
Ba sample bằng desktop provider hiện tại đều trả:

- `BOSS_LOBBY`, branch `CHINH_PHUC_ROOM`, room `Coop_408665`, host=true.
- Lieyun ID1436, level77, đảo Thập nhị tinh, error=null, không MatchId trong lobby.
- Manager-owned Start Button có managed/native ownership roundtrip hợp lệ,
  active=true, interactable=true, groupsAllow=true, root aspect2.0.
  Normalized rect `(0.7162037,0.8351852,0.9106481,0.9037037)` chỉ ghi làm
  evidence, không hardcode thành tọa độ click.

Chỉ quyền QUERY_INFORMATION/VM_READ. Không screenshot, không input, không
gọi method game, không đọc token/credential.
[Root probe](artifacts/game_1_7_4_b12_20261026/readonly_probe.json),
[status/Start geometry](artifacts/game_1_7_4_b12_20261026/readonly_status.json).

## Verification và việc còn lại

Focused suite289tests PASS, gồm profile/hash mới,39TypeInfos,257fields,
native bridge, reminder, Dinosaur, memory provider, lobby, opening, map,
recovery, board mapping, desktop runtime và packaging.
[Kết quả](artifacts/game_1_7_4_b12_20261026/focused_result.json),
[log](artifacts/game_1_7_4_b12_20261026/focused_tests.log).

Full regression hoàn tất147/147module,2683test methods/cases được chạy:
198failure +26error events, tương ứng54test/setup IDs sau gộp subtest.
**Full suite chưa xanh**. Đã replay các case lỗi ở23module bằng đủ360file
Python trước tác vụ; mỗi process xác minh bytes khớp manifest trước khi chạy.
Phân loại224failure/error events:

| Nhóm | Events | Bằng chứng |
|---|---:|---|
| Fixture kiểm profile1.7.4.9/b10 đã bị b12 thay thế | 168 | Pass trên source trước tác vụ, fail do pin/hash/RVA cũ; b12 có test độc lập39TypeInfos/257fields/native |
| Tái hiện trên source trước migration | 55 | Các source pin, canonical config cũ thiếu input_randomization, và lỗi suy luận có sẵn |
| Test receipt bất đồng bộ M08 | 1 | Lỗi trong lượt full đầu; chạy riêng PASS; chạy lại nguyên47test module trên source hiện tại PASS, trên source trước tác vụ cũng PASS |

Trong nhóm có sẵn, `reasoning_refinement.py` còn caller `_passive_geometry`
thiếu tham số `target_gem`, khiến setup của refinement evaluator lỗi. Replay
trước migration tái hiện đúng TypeError; file này giữ nguyên bytes trong tác
vụ. Đây là lỗi thật của nhánh refinement cũ, không được gộp thành lỗi fixture
hay tuyên bố đã sửa. Cần xử lý khi quay lại luồng suy luận; migration này không
sửa policy/refinement hoặc nới fallback. Test worker/diagnostic runner27cases
đều PASS trong harness đúng, bao gồm các đường lỗi/fallback hiện tại.

Không quy lỗi M08 cho build mới và cũng không coi một lần rerun PASS là chứng
minh race đã sửa; nguyên nhân chính xác của failure bất đồng bộ vẫn UNKNOWN.
Full suite lần đầu được giữ nguyên kết quả, không sửa thành PASS sau rerun.
Không nới source/calibration gate hoặc rebind timing b10 thành b12 để ép xanh.

[Full result](artifacts/game_1_7_4_b12_20261026/isolated_full_v2_result.json),
[phân loại từng failure](artifacts/game_1_7_4_b12_20261026/regression_classification.json),
[replay baseline](artifacts/game_1_7_4_b12_20261026/baseline_failed/),
[47test rerun hiện tại](artifacts/game_1_7_4_b12_20261026/timing_review_repeat.log).

Các lượt harness trước `isolated_full_v2` chỉ để chẩn đoán. Harness ban đầu
thiếu main guard cho process con Windows nên gây thêm lỗi spawn/wait; đã sửa
harness và chạy lại toàn147module. Không sửa runtime để khắc phục lỗi harness.
Lượt discovery dùng chung process trước đó không có summary hoàn chỉnh, không
được tính là full PASS hoặc bằng chứng crash game.

Compile/AST361file PASS;350file Python cũ byte-identical, chỉ7runtime constant
files +3test current-profile đổi và1test b12 mới. Source hiện tại:
`447d3cf526e748c0451e52c53b892ac8eddfc9bbad4fb6705aa114b5e0f3803f`.
ZIP1.2.9 giữ đúng SHA cũ
`9da47aa30b41731f4fc503f99cc7161f1df8ad577e64f9b021a546127ed481b6`.
[Scope/compile/package verification](artifacts/game_1_7_4_b12_20261026/scope_verification.json).

Live acceptance chưa thực hiện: B1 tối đa1trận BASIC xác nhận Start, board,
swap/ACK, thưởng và về phòng; sau đó B2 tối đa3trận kiểm fresh match, return và
re-entry. Card/QTE/health popup chỉ chốt khi thực sự quan sát được. Chưa có
evidence đủ để xác nhận soak dài hoặc bật suy luận theo timing cũ.

Bản ZIPv1.2.9 đã giao trước đó giữ nguyên, chứa profile b10; thay source không
làm ZIP đó tự tương thích b12. Chưa nâng version/build khi chưa được yêu cầu.
