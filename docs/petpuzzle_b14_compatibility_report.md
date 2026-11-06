# Pet Puzzle B14 — cập nhật tương thích, 01/11/2026

## B2 vòng lặp 3 BASIC PASS — 01/11/2026

User đã yêu cầu và chạy3BASIC. Run73391a59… trên sourcea330e839…:3attempt/
3WIN,3fresh MatchId,3entry/3Đồng ý/3return đúng Coop_179572/Lieyun77,
safety counters0, technical abort0, kết thúc FARM_TARGET_COMPLETED. Cài đặt
thực tế Demon Farm ăn Khiên/4Kiếm/Solo/pet thường/nội tại/không tiến hóa,
AI tắt; source không đổi trong phiên. B1 retest trước đó đã pass1vòng.
[Acceptance đầy đủ](artifacts/game_1_7_4_b14_loss_20261101/b2_acceptance.json).

Chốt **PASS vòng BASIC ở cohort đã kiểm**, chưa build. Màn thua mới đã có
ảnh/offline89tests; cả3trận live đều thắng nên click thua live chưa quan sát.
Re-entry cưỡng bức (recovery inputs0), card/QTE và AI/common reasoning không
thuộc acceptance này. Không dùng kết quả này để rebind timing/proof Phase5.
Các mục bên dưới giữ lịch sử migration và lần B1 phát hiện/sửa lỗi UI.


## B1 retest PASS; thêm màn Thua — 01/11/2026

Phiên1BASIC mới b87f39b5… đã1WIN, tự Đồng ý1lần và về đúng phòng Lieyun77;
stop FARM_TARGET_COMPLETED, safety/technical abort0. User bổ sung ảnh màn
Thua B14; đã thêm nhận diện và89tests PASS. Click thua live chưa quan sát;
phiên3BASIC tiếp theo chờ user sẵn sàng, chưa mở. [Report](petpuzzle_b14_loss_ui_20261101.md).
Source/proof của mỗi lượt giữ riêng; không relabel calibration hoặc AI acceptance.


## Cập nhật B1 và sửa nhận diện kết quả — 21:47, 01/11/2026

B1 đã dùng1attempt, WIN/STRONG, entry/opening và swap ACK có evidence. Vòng
chưa PASS vì dừng `POSTMATCH_UI_AMBIGUOUS`:30mẫu/30.484s không nhận khung
thưởng B14 hẹp/trong suốt, chưa click Đồng ý. Đã thêm variant nhận diện đúng
màn thắng B14,81tests PASS; cần1BASIC kiểm lại confirm/return khi user sẵn sàng.
[Nguyên nhân, sửa và giới hạn](petpuzzle_b14_postmatch_fix_20261101.md).
Các mục bên dưới là snapshot offline trước B1; source hiện tại xem verification
của bản sửa, không relabel source/live proof cũ.


## Phạm vi và kết luận

Đã chuyển profile đọc sang **B14 / metadata 111 / Unity 6000.7.0b7** bằng
Il2CppDumper. Đây là nhánh thích ứng theo yêu cầu người dùng; phần AI chung /
Demon Sagui tạm giữ. Chưa mở tool, chưa phát input, chưa build hoặc đổi version.
ZIP 1.3.0 đã phát hành được giữ nguyên.

Offline tập trung **407 test PASS**. Provider thật đã attach chỉ đọc PID25808,
nhận đúng `LOBBY_OTHER / CHINH_PHUC_MAP` trong ba mẫu liên tiếp, không có lỗi.
Native Canvas/map geometry và managed/native roundtrip đã kiểm ở scene này.
Combat board, swap/ACK, card/QTE, result/return và thao tác tắt popup vẫn cần
live có giới hạn. Không dùng kết quả B12 làm acceptance cho B14.

**Full regression:** 161 module / 2.852 test đã chạy trong các process tách
biệt. Sau khi sửa đúng hai fixture module bounds và chạy lại54 test observer,
full run còn247 failures +27 errors:229 records tái hiện với snapshot388 file
trước task,44 thuộc các kỳ vọng profile1.7.4.9/b10/b12 đã được B14 thay thế,
1case async-receipt có targeted repeat PASS ở cả current và pre-task source.
Case đó cũng từng xuất hiện rồi repeat PASS trong audit B12; không sửa runtime
để ép test timing xanh. Repeat hợp lệ chạy bằng file có main guard cho Windows
multiprocessing; lần thử qua stdin không spawn được worker được loại khỏi evidence.
Không còn record chưa phân loại. Bộ lịch sử **chưa xanh toàn bộ**; không nới
source/calibration gate hoặc sửa acceptance cũ để che các failure này.
`regression_classification.json` giữ initial run270fail/31error, bản replay
và lần retest fixture riêng.

## Nguồn và identity

- Reverse mới: `reverse/reverse_1.7.4-b14/{dump.cs,script.json,il2cpp.h,DummyDll}`.
  Có17.421 declaration;16 compiler-generated private implementation types có
  tên field `null` trùng nhau, đánh dấu opaque/UNKNOWN, không dùng làm layout.
- Reverse đối chiếu: `reverse/reverse_1.7.4-b12`, Inspector format.
- Game thật `D:\pc` chỉ đọc. Launcher/process `PetPuzzle-1.7.4.exe`, app.info
  `Pet Puzzle / Pet Puzzle`. Không thay game file, registry hoặc PlayerPrefs.
- Snapshot trước task gồm388 Python files, fingerprint
  `499efbfc347c052532590998b73ea1419bc82d6ab371fbf16ffa19e800a36583`.
  Đây là working tree có AI chung chưa commit, không phải git HEAD.

| File | SHA-256 | Bytes |
|---|---|---:|
| GameAssembly.dll | `33df13da565808a41d8268dafdf5702d736fc8fcb889515e57bda475528d2152` | 75.612.160 |
| UnityPlayer.dll | `2584be0698de516d555042c682d11a266fa3c143fa5e1194976e7608833eba90` | 39.913.384 |
| PetPuzzle-1.7.4.exe | `a2cbff9327ac828b79c9f971af6b487755ef9697cc1885e8eaebea7957b8caba` | 575.488 |
| global-metadata.dat | `f2b1bf831cde8ace261b3c840c49e030b309dd5e6b10185d0dcc75c3b9bb3d30` | Trong static audit |

GameAssembly PE x64, preferred base `0x180000000`, SizeOfImage `0x4ADC000`,
timestamp1793478908. UnityPlayer SizeOfImage `0x2731000`, timestamp1793199818;
Unity6000.7.0b7, revision74fb57f88838. Metadata magic`0xFAB11BAF`, version111.
Các địa chỉ bên dưới là **module RVA hoặc object-relative offsets**, không
phải absolute address cố định theo ASLR.

## Managed profile

Đối chiếu39 TypeInfo theo exact export name/signature; không cộng một delta
chung.257 field candidates được ghép bằng owner + tên field;51 field dịch
offset, kiểu dữ liệu giữ nguyên sau khi kiểm spelling của hai exporter.
Backing-field `<...>k__BackingField`, nullable, nested owner và UI.Text được
đối chiếu riêng; không xóa namespace tùy ý. Co-op PlayerStats và PVP tách biệt.

| Thành phần | Thay đổi chính |
|---|---|
| Board/Active/MatchService | roots `0x429DA00 / 0x429DA08 / 0x4265908` |
| ManagerRoom / PlayReminder | roots `0x4265820 / 0x42A9C18` |
| Co-op / PVP PlayerStats | `0x421DB18` / `0x4226D30` |
| CardUI | thêm `_domainUsesLocal +0x44`; các field sử dụng sau đó dịch+8 |
| MatchService | thêm ready-users event và LastMatchStartMsg; ACK/in-flight/QTE/last-move/deferred-winner dịch theo từng tên field |
| ChatService | thêm rejoin event; disconnect/reconnect/connecting dịch+8 |
| Dispatcher callback | `<>c__DisplayClass321_0` → `324_0`, root`0x425BF60`; capture layout giữ nguyên |
| Read spans | CardUI`0x89`; server QTE`0x2E8`; full CardUI QTE`0x4AA` |

Native `OnWebSocketMessage` tham chiếu exact closure324; callback đọc self/json/
message+`0x10/0x18/0x20`. Queue/List/PendingAction giữ shape. Board197fields,
Dot, BoardCellDTO, room managers, map pet-click closure41 và PlayReminder
không có layout move. `Dot.multiplier +0x88`, DTO.multiplier+`0x20` giữ nguyên;
native `Board.GetDotMultiplier` vẫn đọc Dot+`0x88`. Không sửa luật Kiếm hiệu dụng.

28 library layouts đã review. Bốn open generic exports không chứng minh ABI
bằng offset0: dùng **closed C++ fields** và x64 packing cho List<PendingAction>,
Queue<PendingAction>, Dictionary<string,object>, HashSet<long>. Entry stride24,
Slot<long> stride16; Array.length+`0x18`, data+`0x20`; String.length+`0x10`,
UTF16+`0x14`; Nullable<int> hasValue/value+`0/4`.
Selectable.s_Selectables đổi array→List, Active thêm static cosmetic/event
fields; reader không dùng các field này.104 enum cũ được so sánh; giá trị cũ
giữ nguyên. Chỉ thêm PetTier.Demon=4 và BackdropAnimTable.Kind.Arcane=5, không
thuộc enum-domain của các reader đang dùng.

## Native Unity và UI

UnityPlayer không còn byte-identical với B12; đã tìm lại native methods từ
**cached icall pointer được đọc trong tiến trình**, join về exact managed
wrapper và bytes trên đĩa. Không invoke getter/engine method hoặc ép init.

- Component.gameObject wrapper`0x34B7110` load/store cache`0x44DA7F8`, native
  Unity`0x1197500`, tail tới Unmarshal`0x1B52D20`. Signature24bytes tại
  `0x1B52D4C`: `f6c301740d488bcbe847446ffe488bd8eb03488b1b4885db`.
  Unmarshal có thêm call trước tag check; chỉ giữ decoder với fences đã chứng
  minh, không khẳng định toàn hàm không đổi.
-16 native anchors được rederive: component storage/stride/owner, managed
  handle, active, rect/dirty, transform parent/children/access/TRS, rootCanvas
  và renderMode. Class.static_fields vẫn`+0x98`: native singleton getters và
 27 readable runtime classes cùng xác nhận. Generic Dumper header gợi`+0xB8`
  **không phải live ABI** và không được áp dụng.
- **TransformData.localTRS array chuyển`+0x20 → +0x18`**. Transform access+`0x40`,
  index+8, stride48; quaternion/scale trong TRS vẫn`+0x10/+0x20`. Chỉ thay hai
  lookup vào array; pending-job/dirty/roundtrip/freshness fences giữ nguyên.
- Popup sức khỏe: Behaviour.enabled thunk chuyển`0x114430 → 0xFDFF0`, Canvas
  virtual getter`0xCD630 → 0xD5590`. Slot`+0xC8`, enabled byte`+0x30` và getter
  code giữ nguyên. Đã xác minh bằng readonly icall cache + actual map Canvas
  vtable + binary bytes. PlayReminder chưa tạo Canvas trong lần đọc hiện tại;
  chưa claim popup có thể dismiss live. IsOpen/Hide native vẫn đi qua Canvas
  enabled; nhận diện popup không phụ thuộc số phút.

Map có ba island Buttons đang visible được đọc geometry thành công; các nút
ngoài viewport bị validator loại đúng. Không suy ra tọa độ click từ một RVA
hoặc cố định lại vị trí đảo/boss.

## Board geometry và timing

Native `MatchHudV2.SolveBoard` và `Board.GetCellBaseWorldPosition` khớp52/215
instruction sau normalization với B12, gồm float constants và internal branch.
Normalization bỏ relocation/external call target, **không chứng minh toàn HUD**.
HUD đổi OD80→54, timer font/size và thêm timer-gap/ping/pity widgets. Vì vậy
giữ calibration và jitter người dùng, cần frame bàn8×8 + actual ACK mới xác
nhận mapping B14. Fixtures64tâm/112swaps/bốn profile chỉ là regression offline.

Không sửa solver, BASIC, reasoning/common planner, input executor, thứ tự đọc
memory/chụp ảnh, random, QTE input hoặc lifecycle/recovery policy.11 source
modules chỉ đổi profile constants, read spans và native indirection. AST scope
test bỏ đúng các constant đã review, hai TRS lookup và một thunk lookup; các
runtime files còn lại trong snapshot byte-exact.

Metadata probe hỗ trợ header111; đây không cấp authority cho build bất kỳ.
Allowlist chỉ chứa exact B14 GameAssembly. Calibration/timing/source pins cũ
không được rebind; yêu cầu Sagui draft trước migration đã lỗi thời.

## Evidence và kiểm tra

Evidence local tại `docs/artifacts/game_1_7_4_b14_20261101/` (ignored):

- `before_source.json`, `before/`, `static_audit.json`, `constant_migration.json`.
- `native_evidence_v2.json`, `candidate_readonly_probe_behaviour.json`,
  `canvas_enabled_readonly.json`, `popup_semantics.json`.
- `semantic_evidence_v3.json`, `supplemental_layouts.json`.
- `readonly_status_final.json`, `focused_result.json`,
  `compile_release_check.json`; full/baseline regression và classification.

Helpers `tools/reverse_exports.py`, `audit_dumper_update.py`,
`audit_dumper_native.py`, `audit_dumper_semantics.py`, `probe_dumper_candidates.py`
không phải runtime action path. Tests mới pin export identity, actual binary,
field moves/read spans, closed ABI, native caches, parser ambiguity và exact
scope. Fixture resolver và clock observer được nâng đúng SizeOfImage B14; vẫn test reject anchor
ngoài module. Test pin B12/b10 lịch sử không bị nới để ép xanh.

Production fingerprint230files:
`93d100a748bf0533c2419f44b89f2b4ae07c736b00f7d1e75c70044c5923a41c`.
Chỉ17 existing Python files đổi (11profile modules,6test fixtures);5audit helpers
và1test module mới.394 Python files compile. ZIP1.3.0 SHA vẫn
`130a899d19b9b784678649a3acb9d5cfdfb6c262e2d883c68390664e40893b98`.
Read-only access chỉ QUERY_INFORMATION|VM_READ (`0x410`), không screenshot/input,
remote call, network hoặc ghi game.

## Bước live còn lại

Sau khi offline review xong: người dùng vào phòng Solo Lieyun77, Demon Aegis
thường ăn Khiên, ngưỡng4Kiếm hiệu dụng, giữ đồ và tắt tool cũ; chưa bấm Start
trong game. B1 tối đa1BASIC kiểm room/Start, board, swap/ACK, result/return.
Sau khi log B1 sạch mới chốt B2 tối đa3trận với re-entry. Card/QTE hoặc popup
không phát sinh trong cohort phải ghi NOT_OBSERVED, không tự cộng thêm trận.
Đây là acceptance thích ứng B14, không tiêu cap E1 hoặc Sagui và không bật AI
chung bằng các proof cũ.
