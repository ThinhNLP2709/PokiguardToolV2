# Pet Puzzle 1.7.4 B16 — compatibility migration, 17/11/2026

Profile source đã chuyển B15 → B16 theo exact symbols; chưa phải PASS STRONG
trong trận. Attach production đọc đúng phòng Lieyun và bản đồ Thập nhị tinh.
Không gửi input, gọi method game, ghi process/game/PlayerPrefs hoặc build release.

## Danh tính build và provenance

Install: `D:\pc`. Launcher/process: `PetPuzzle-1.7.4.exe`. Window title đọc từ
Computer Use: `Pet Puzzle`; client thật 1280×640. Data directory:
`PetPuzzle-1.7.4_Data`. `app.info` ghi company **Pet Puzzle**, product **Pet Puzzle**;
registry owner tương ứng là `HKCU\Software\Pet Puzzle\Pet Puzzle`.

| File | Bytes | SHA-256 |
| --- | ---: | --- |
| GameAssembly.dll | 77056000 | `c69c95c4c6bd0cbc28181033ccd2a974e085f47055f123627e0b3a33e1595f3a` |
| UnityPlayer.dll | 39913384 | `2584be0698de516d555042c682d11a266fa3c143fa5e1194976e7608833eba90` |
| PetPuzzle-1.7.4.exe | 575488 | `a2cbff9327ac828b79c9f971af6b487755ef9697cc1885e8eaebea7957b8caba` |
| global-metadata.dat | 15045920 | `d632171b82c699c4f7a2f69463e88eee4f3814fbcdaa24805aab10de204a718f` |

Launcher và UnityPlayer trùng B15. PE đều AMD64; GameAssembly preferred base
`0x180000000`, SizeOfImage `0x4C3D000`, timestamp `1794755310`. Các PE còn lại
và metadata magic/version được lưu trong [audit](artifacts/game_1_7_4_b16_20261117/static_audit_verified.json).
Metadata magic `0xFAB11BAF`, version **111**.

Reverse mới là `reverse/reverse_1.7.4-b16` do người dùng cung cấp, gồm Dumper
`dump.cs`, `script.json`, `il2cpp.h`, DummyDll. Version/câu lệnh/thời điểm chạy
exporter: **UNKNOWN**, không suy ra từ mtime. Liên kết với binary hiện tại được
kiểm bằng named native wrappers, module header, live bytes và TypeInfo identities.
Baseline là [report B15](petpuzzle_b15_compatibility_report.md), reverse B15 và
snapshot source thực tế ngay trước migration; không dùng source đã patch để
nhận diện constants cũ. B15 có bằng chứng BASIC/re-entry; báo cáo cũ vẫn để mở
một số acceptance ACK/QTE/result, không được coi là toàn bộ đã PASS STRONG.

## Delta áp dụng và contract đã so

Đổi **45 constants trong 7 runtime module**: 39 TypeInfo, ba managed offset,
hai native anchor, một allowlist hash. Hash B15 bị từ chối. Không dùng delta RVA
chung; từng slot được ghép exact exported name/signature, gồm closed generic,
JSON, co-op/PVP và compiler closure.

| Managed field | B15 | B16 |
| --- | --- | --- |
| ChatService._explicitDisconnect | `+0x345` | `+0x34D` |
| ChatService._reconnectCoroutine | `+0x348` | `+0x350` |
| ChatService._connecting | `+0x354` | `+0x35C` |

289 consumed field bindings được kiểm tên, kiểu, offset và static owner; ba
field trên thay đổi. Source đọc các cờ này riêng lẻ, không có fixed read span
cũ cần nới. Full export diff gồm 17.336 type chung, 44 type có field delta và
1.718 enum không đổi. 16 `<PrivateImplementationDetails>` có tên field opaque
được ghi UNKNOWN; không dùng làm pointer/layout authority.

Board/Dot/Active/ManagerMatch, lifecycle statics, MatchService, ChatMessageDTO,
WsCombatBatch, BoardWsApplier, dispatcher PendingAction/list/queue, CardUI,
FusionCardUI, co-op Active.PlayerStats, PetUserDTO, CardData, Audition/QTE,
room/map và opening JSON đều được đối chiếu. Tám closed ABI được tính lại và
2.384 khai báo generic/nullable/value tuple có nội dung header giữ nguyên;
không dùng generic Il2CppClass header để suy static_fields ABI.

`ChatService.OnWebSocketMessage` dùng closure **328_0** thay **324_0**. Handler
tham chiếu đúng TypeInfo mới; closure vẫn giữ `json +0x18`, `message +0x20`.
Native callback chuẩn hóa khớp B15. `preBoard +0x4C0`, ready `+0x4C8`, QTE
challenge `+0x1C0`, span `0x1D0`, multiplier và sentinel/domain giữ nguyên.
Co-op PlayerStats TypeInfo `0x43BF050`, tách khỏi PVP `0x436DC38`.

Các bổ sung đáng chú ý: `Board.isGuildWarBattle +0x30C`,
`Active.SuppressAttackerSwing` và nhóm GuildWar/GalaxyNew/VIP/UI mới.
`MatchPlayerSnapshotDTO` thêm `gx*`/`cyc*` sau phần skill-phase reader đang đọc;
các field `skillPhaseNext/Max/CardId` vẫn `+0x15C/+0x17C/+0x180` và có native
load proof từ `TryGetLocalSkillPhase` B16 tại `0xB93FE0`.
Semantics riêng của chế độ/pet mới: **UNKNOWN, chưa qualified**; migration không
mở thêm mode hoặc sửa solver/policy. Các bảng seal Icarus/T-Rex được giải mã lại
từ hai `.cctor` B16, khớp đủ 30 ô với B15 và production.

## Native bridge, UI và tọa độ

`Component.get_gameObject` B16 ở `0x35E6E00`: RIP load/store cùng trỏ cache
`0x462FF20`; wrapper nhảy tới exact named Unmarshal. Unique signature tại
`0x1C7137C`: `f6c301740d488bcbe897a15dfe488bd8eb03488b1b4885db`.
Native getters tiếp tục chứng minh `Il2CppClass.static_fields +0x98`.

Probe query/read-only xác minh loaded module header/size/core method bytes,
UnityPlayer MZ/header, 16 runtime byte signatures và **445 cached icall** trùng
96 byte với file UnityPlayer. Cache Component trỏ UnityPlayer RVA `0x1197500`.
Hai manager sảnh/phòng qua managed → native → managed và GameObject ownership.
28/39 class đã initialize ở phòng được nhận đúng; 11 root combat còn encoded
hoặc chưa initialize là trạng thái ngoài scene, không ép initialize.

Ba lần đọc production cho `BOSS_LOBBY`, room `Coop_496928`, host local, boss
1436/Lieyun lv77, đảo Thập nhị tinh. Start là đúng Button thuộc ManagerRoom/V2
refs, interactable/CanvasGroup hợp lệ, phase Idle, không mở flow/loading.
Rect `(0.70463, 0.83056, 0.92222, 0.90833)`, root aspect 2:1, ổn định ba mẫu.
Ảnh client cho đúng nút Bắt Đầu, locator confidence 0,99. Invite/reminder sạch.
Probe dùng cùng `allow_nested_fullscreen_canvas=True` và geometry fences của
production; strict/default Canvas walk bị từ chối, không nới validator.
Fixture phòng có vùng chat che bên trái; vùng boss/Start dùng đối chiếu hiện rõ.

Ba lần đọc map xác minh boss ID 1436, ô số 5 qua graph
`ManagerChinhPhuc.OnReceived panelButtons[pet_index]`, không lấy badge số 5
làm authority. Tâm Button `(0.6839475, 0.4056069)`, khoảng `(875, 260)` trên
1280×640, khớp vị trí Lieyun trong ảnh map thật. Phân biệt raw pet level 11 với
display level 77; room dùng level 77. Không click kiểm re-entry trong phiên này.

`MatchHudV2.SolveBoard`, `Board.GetCellBaseWorldPosition` và HUD constants khớp
B15 trong phạm vi đã so; native normalization bỏ đích external call nên không
phải chứng minh toàn bộ HUD tương đương. Default/fallback/calibration, jitter
±10% và pacing không thay đổi. Các test 64 tâm/112 swap trên bốn profile 2:1
dùng ảnh lịch sử vẫn là kiểm offline; **B16 board→pixel và move/ACK trong trận
còn UNKNOWN**, không gắn lại timing/calibration evidence B14/B15 cho B16.

## Verification

- Snapshot source/tests, hai tài liệu evidence chính và Git status trước migration trong `before/`.
- 159 test tập trung pass sau khi thêm fixture B16; [log](artifacts/game_1_7_4_b16_20261117/focused_final.log).
- Compile 239 file và import 10 module liên quan pass;
  [kết quả](artifacts/game_1_7_4_b16_20261117/compile_import_checks.json).
- Hồi quy trước migration: 175 module, 3.037 test, 49 failure, 309 error.
- Hồi quy sau migration: **176 module, 3.046 test, 40 failure, 339 error**;
  full suite **chưa xanh**. 324 bản ghi lỗi có cùng test ID đã lỗi trước migration;
  55 bản ghi thiếu raw log lịch sử. Cả 26 test ID lỗi mới đều thiếu file trong
  `logs/farm_runs`; không có lỗi mới chưa phân loại. Chi tiết:
  [classification](artifacts/game_1_7_4_b16_20261117/regression_classification.json).
- AGENTS và 17 test/helper đã được chỉnh đồng thời sau snapshot, trước lần hồi
  quy sau migration; các thay đổi đó được giữ nguyên. Bốn run log lịch sử không
  còn khả dụng giữa hai lần chạy; người/thao tác xóa **UNKNOWN**. Vì dữ liệu và
  tests nền có đổi, không coi chênh lệch tổng số lỗi là phép so A/B thuần code.
  [Workspace provenance](artifacts/game_1_7_4_b16_20261117/concurrent_workspace_changes.json).
- Module B16 có 11 test pass riêng, gồm hai test fixture thêm sau khi child của
  full suite đã chạy; bộ tập trung 159 test cuối đã bao gồm chúng. Các gate
  source/build/timing được giữ nguyên; không tái gắn bằng chứng live cũ.
- Audit từ snapshot cũ được tái chạy bằng helper Dumper→Dumper mới và JSON kết
  quả trùng hoàn toàn với bản đã dùng để migrate.

[Fixture thật và provenance](../tests/fixtures/petpuzzle_b16_20261117/provenance.json).

[Static audit](artifacts/game_1_7_4_b16_20261117/static_audit_verified.json),
[extra native/seal proof](artifacts/game_1_7_4_b16_20261117/runtime_contracts.json),
[read-only native](artifacts/game_1_7_4_b16_20261117/readonly_native_verified.json),
[room](artifacts/game_1_7_4_b16_20261117/readonly_room_verified.json),
[map](artifacts/game_1_7_4_b16_20261117/readonly_map_verified.json).

## Live acceptance còn lại

**B1 — một trận:** người dùng chọn phòng đúng boss, dùng source đã migrate;
xác minh một entry click, opening 8×8/64 tâm ô đúng, đúng participant, một swap
có ACK, card/QTE nếu phát sinh, result rồi về phòng/bản đồ và chọn lại đúng boss.
Lưu client-only combat/WIN/LOSS hoặc aborted fixture có provenance khi có.

**B2 — ba trận, chỉ sau B1 pass:** MatchId mới mỗi trận, một input mỗi quyết định,
ownership mới, không duplicate input hoặc vi phạm Pass policy, result/re-entry
đúng. Chỉ sau PASS STRONG mới tăng soak. Sai state/geometry/ACK phải dừng và bổ
sung evidence; hồ sơ Suy luận/timing cũ phải requalify cho đúng build/source mới.
Chưa build release hoặc tự mở desktop tool trong milestone này.
