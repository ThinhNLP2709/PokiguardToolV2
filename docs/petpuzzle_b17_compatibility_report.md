# Pet Puzzle 1.7.4 B17 — migration, 18/11/2026

**Bổ sung sau migration:** đã chạy riêng1 B1+3 B2 BASIC trên Demon Aegis/
Khiên/Priest131,4 WIN STRONG,24 SWAP ACK+4 terminal, nhận thưởng và về phòng.
Source95288bff… giữ nguyên. Native chỉ trong scope này; card/QTE, REASONING,
mọi pet/profile và full CV vẫn chưa được nghiệm thu bởi4 trận đó.
[Báo cáo native và dữ liệu](phase5/B17_PRIEST_OUTCOME_LIVE_20261118.md).

Source đã chuyển B16 → B17 bằng exact exported symbols. Phần migration
bên dưới lưu kiểm offline/read-only room/map; tại mốc migration đó combat
B1/B2 chưa được thực hiện. Kết quả native sau đó nằm ở phần bổ sung phía trên.
Không gửi input, gọi method game, ghi process/game/PlayerPrefs hoặc build release.
Các thay đổi chưa commit trước migration được giữ trong snapshot và bảo toàn.

## Build identity và provenance

Install `D:\pc`; launcher/process `PetPuzzle-1.7.4.exe`; window `Pet Puzzle`;
data directory `PetPuzzle-1.7.4_Data`. `app.info` tiếp tục ghi company/product
`Pet Puzzle` / `Pet Puzzle`, nên registry owner là
`HKCU\Software\Pet Puzzle\Pet Puzzle` theo nội dung app.info.

| File | Bytes | SHA-256 |
| --- | ---: | --- |
| GameAssembly.dll | 77059072 | `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7` |
| UnityPlayer.dll | 39913384 | `2584be0698de516d555042c682d11a266fa3c143fa5e1194976e7608833eba90` |
| PetPuzzle-1.7.4.exe | 575488 | `a2cbff9327ac828b79c9f971af6b487755ef9697cc1885e8eaebea7957b8caba` |
| global-metadata.dat | 15046176 | `afa6f51223c98ccd6643cf6236449e6ce92d7feff41b721a34b17755d1fea617` |

Launcher/UnityPlayer trùng B16; GameAssembly và metadata thay đổi. PE đều AMD64.
GameAssembly preferred base `0x180000000`, SizeOfImage `0x4C3E000`, timestamp
`1794973082`. Metadata magic/version `0xFAB11BAF` / **111**. Chi tiết cả ba PE
và hash reverse trong [static audit](artifacts/game_1_7_4_b17_20261118/static_audit_verified.json).

Reverse `reverse/reverse_1.7.4-b17` do người dùng cung cấp, định dạng Il2CppDumper.
Version/câu lệnh/thời điểm exporter: **UNKNOWN**; không suy từ mtime hoặc tên thư
mục. Liên kết build được kiểm bằng native symbols, loaded header, core wrapper
bytes và initialized TypeInfo. Baseline là reverse B16, snapshot source thực tế
ngay trước migration và [report B16](petpuzzle_b16_compatibility_report.md).
B16 đã có offline/room/map proof, vẫn chưa được coi là PASS STRONG toàn trận.

## Contract delta

**42 constants trong 7 runtime module** thay đổi: hash, 39 TypeInfo, cache
Component và Unmarshal signature. Chỉ B17 hash được allowlist; B16 bị từ chối.
Các TypeInfo có **16 giá trị delta khác nhau**: từng symbol được ghép độc lập,
không dùng phép cộng delta chung.

- **289 field bindings** giữ nguyên tên, kiểu, offset và static ownership.
- **43 layout selected** và mọi type chung có field đọc được đều khớp B16;
  17.682 type chung, không có field delta trong nhóm so được.
- **2.414** closed generic/nullable/value-tuple header contracts, tám closed ABI,
  sáu opening JSON layouts và **1.722 enum** giữ nguyên.
- Board/lifecycle, transport/ACK, dispatcher list/queue/closure, cell/card/pet,
  FusionCardUI, co-op/PVP stats, Audition/QTE, boss room/map đều nằm trong audit.
- WebSocket closure vẫn **328_0**, `json +0x18`, `message +0x20`.
  ChatService reconnect offsets vẫn `+0x34D/+0x350/+0x35C`; opening
  `preBoard +0x4C0` / ready `+0x4C8`; QTE challenge `+0x1C0`, span `0x1D0`.
- Co-op `Active.PlayerStats` TypeInfo `0x43C0080` tách khỏi PVP `0x436EC00`.

Ba compiler type của CombatPowerFx đổi số khai báo: display closure 37→38,
Fetch 37→38, Run 63→64. Metadata thêm `FusionPetPanelController.get_Active`,
`IsInteractiveHost`, `CombatPowerFx.PushRoomRefresh`; các body mới được lưu
riêng. Không lấy tên method làm bằng chứng backend/gameplay policy. Không mở
mode/pet mới hoặc thay solver, scoring, input pacing/jitter, gameplay policy.
16 opaque PrivateImplementationDetails export vẫn **UNKNOWN**, không dùng làm
layout authority.

## Native và semantics

Component wrapper `0x35E7AA0` đọc/ghi cùng RIP-relative cache **`0x4630EE0`**,
tham chiếu đúng icall literal và tail-jump tới named Unmarshal. Unique signature
tại **`0x1C7201C`**:
`f6c301740d488bcbe8f7945dfe488bd8eb03488b1b4885db`.
Native singleton getters giữ `Il2CppClass.static_fields +0x98`; không dùng generic
Dumper header để suy ABI.

Các core anchor khớp B16 trong phạm vi normalization. Thêm 26 native body
card/room/phase/seal đều khớp cấu trúc lệnh **và symbolic references** của B16.
Hai `.cctor` seal Icarus/T-Rex giải mã lại đủ 30 ô, khớp production.
Normalization không chứng minh tương đương toàn bộ native code, floating/RIP
data hoặc backend policy ngoài phạm vi lưu bằng chứng.

Probe query/read-only kiểm exact installed/loaded GameAssembly path, header,
SizeOfImage và ba wrapper 64-byte; UnityPlayer MZ/header, 16 native signatures,
Unmarshal bytes, enabled thunk/getter và **445 cached icall** trùng 96 byte với
file. Cache Component trỏ UnityPlayer RVA `0x1197500`. Tại phòng có 28/39 class
đã initialize nhận đúng; 11 combat root còn encoded/chưa initialize được giữ
đúng trạng thái ngoài scene, không ép initialize. Hai manager sảnh/phòng qua
managed/native/GameObject ownership roundtrip.

## Room, map và fixtures

Ba mẫu production nhận `BOSS_LOBBY`, host local, `Coop_659255`, **Lion Star ID
1473, display lv105, Bóng đêm**. Cần phân biệt `enemy_pet_level` thô trong room
đang là 0 với display level 105 lấy từ metadata game và label thật; không tự
suy server combat level từ các giá trị này. Map DTO raw level 11 cũng là trường
riêng, không thay thế display level.

Start là đúng ManagerRoom/V2-bound Button, phase Idle, active/interactable,
CanvasGroup cho phép tương tác; ba geometry giống nhau. Rect chuẩn hóa
`(0.70463, 0.83056, 0.92222, 0.90833)`, root 2:1. Ảnh client 1280×640 hiện rõ
**Bắt Đầu**, locator confidence **0,99**. Invite/reminder sạch và đóng. Dùng đúng
production bounded nested-Canvas proof, không nới validator.

Ba lần đọc map tìm đúng pet 1473 ở index 4, qua
`ManagerChinhPhuc.OnReceived panelButtons[pet_index]`. Callback trên chính
Button cũng giữ ID 1473 và đúng manager; method pointer match exact exported
`ManagerChinhPhuc.<>c__DisplayClass41_0.<OnReceived>b__0`. Delegate method_ptr và
m_target được đối chiếu field layout. Tâm chuẩn hóa khoảng
`(0.423187, 0.399495)`, tức **(542, 256)** trên 1280×640. Badge số 5 không làm
authority và không có click re-entry trong phiên.

Sảnh chính GAME_LOBBY và fixture hub B17: **UNKNOWN/chưa xác minh đúng scene**. Lần đọc mới nhất vẫn là bản đồ Bóng đêm (LOBBY_OTHER/CHINH_PHUC_ISLAND), không coi đó là GAME_LOBBY.

Ảnh thật có provenance, original capture và client crop từ queried Win32/DWM
bounds trong [fixtures B17](../tests/fixtures/petpuzzle_b17_20261118/provenance.json).
Giữ rõ foreground được query sau capture; các mẫu đó không tự cấp quyền input.
Foreground vẫn phải được xác nhận ngay lúc live preflight. Các cảnh chụp chỉ
chứng minh một profile thật 1280×640; scale fixture không tính là live profile.

SolveBoard/GetCellBaseWorldPosition và HUD constants khớp B16 trong phạm vi đã
so. Default/fallback/calibration cùng jitter ±10% và pacing giữ nguyên.
Kiểm 64 tâm, 112 swap, mép bàn/bốn profile 2:1 vẫn là replay offline từ ảnh
combat lịch sử. **B17 board→pixel, move/ACK, card/QTE thực và WIN/LOSS/result
vẫn UNKNOWN** tới B1/B2; không gắn lại timing/calibration live B14/B15/B16.

## Verification

- Snapshot trước migration: source/tools/tests Python, AGENTS, runbook, hai
  tài liệu evidence, report B16 và Git status. Source logic ngoài constants
  được kiểm bằng AST và hash snapshot.
- **160 test tập trung pass**, gồm 12 test B17 và fixture room/map hiện tại; [log](artifacts/game_1_7_4_b17_20261118/focused_final.log).
- Compile **245** file, import 10 module liên quan pass.
- Trước migration: **184 module, 3.144 test, 40 failure, 339 error**.
- Sau migration: **185 module, 3.156 test, 39 failure, 339 error**; full suite
  chưa xanh. Không có test ID lỗi mới. 323 bản ghi đã lỗi trước và 55 bản ghi
  thiếu raw log lịch sử; [classification](artifacts/game_1_7_4_b17_20261118/regression_classification.json).
  Một B16 runtime-preservation failure không còn áp dụng vì B16 không phải
  profile active; không coi đây là sửa lỗi runtime. Hai captured-fixture test
  B16 tiếp tục chạy. Tất cả 12 test B17 pass trong full suite.
- Audit được chạy lại từ snapshot B16 sau migration và JSON kết quả khớp hoàn toàn.
- B16 runtime assertions chỉ chạy khi B16 là profile active; captured B16
  fixture tests tiếp tục chạy độc lập. B17 có test pin exact hash, RVA, field,
  native bytes và preservation riêng. Không nới admission/calibration gate.

[Static audit](artifacts/game_1_7_4_b17_20261118/static_audit_verified.json),
[native semantics/seals](artifacts/game_1_7_4_b17_20261118/runtime_contracts.json),
[loaded native](artifacts/game_1_7_4_b17_20261118/readonly_native_verified.json),
[room](artifacts/game_1_7_4_b17_20261118/readonly_room_verified.json),
[map](artifacts/game_1_7_4_b17_20261118/readonly_map_verified.json),
[independent map callback](artifacts/game_1_7_4_b17_20261118/map_listener_verification.json).

## Acceptance tiếp theo

**B1 một trận:** foreground đúng game; đúng room/boss; một entry click; opening
8×8, participant và 64 tâm ô khớp ảnh client thật; một swap có ACK; card/QTE nếu
phát sinh; result rồi về phòng/map đúng boss. Lưu combat/WIN/LOSS hoặc aborted
fixture có provenance. Có mismatch phải dừng và quay lại evidence tương ứng.

**B2 ba trận sau B1 pass:** fresh MatchId/ownership, không duplicate input,
không vi phạm Pass policy, postmatch/re-entry đúng. Chỉ tăng soak sau PASS STRONG.
Hồ sơ Suy luận/timing phải requalify cho đúng build/source B17. Milestone này
chỉ cập nhật source/evidence; chưa đóng gói EXE mới hoặc tự mở desktop tool.


## Đóng gói tiếp theo — 18/11/2026

Đã tạo [v1.3.6 / B17 portable](v1.3.6_b17_release_report.md) từ source hiện tại,
bao gồm sửa adviser sau milestone migration. Gói qua CRC/source-bytecode và hai
frozen self-check; source/ZIP mới chưa live. Bằng chứng live cũ giữ đúng scope
ban đầu. Report migration bên trên phản ánh milestone trước khi đóng gói;
receipt package nằm trong báo cáo release mới.
