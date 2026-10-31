# Mega Icarus — dừng khi không đọc được skill và trở về phòng boss

2026-10-14 (Asia/Saigon). Side fix theo yêu cầu trực tiếp; Phase 5 tạm dừng ở
P8 đã đóng, P9 chưa chạy. Chưa có live acceptance của bản sửa này.

## Nguyên nhân log chứng minh

Run `29f43e69e1e24fb886b927ade722dd07`, boss Small Blue2346, mục tiêu7trận,
match `M_edcd5822`. AI BASIC, shadowOFF. Mốc dưới đây theo Asia/Saigon:

| Thời điểm | Evidence |
|---|---|
| 03:02:42 | Bắt đầu farm; cấu hình `mega / none / pet_skill`, Mega Icarus |
| 03:02:52 | Vào trận, opening đủ64ô, current local turn1 |
| 03:02:53–55 | 10lần warmup skill, vẫn `PET_SKILL_CAPABILITY_UNAVAILABLE` |
| 03:02:55.649 | Policy NONE tại `STEP_1_PET_SKILL`; timer11s;17legal/17safe moves |
| 03:02:55.733 | Combat controller dừng; chưa gửi SWAP/CAST/EVOLVE/Pet Skill/PASS |
| 03:02:55.747 | Farm SAFE_STOP `COMBAT_SAFE_STOP`, detail thiếu capability skill |
| 03:03:49.767 | Desktop lần đầu quan sát sảnh game, controller đã STOPPED |
| 03:05:59 | Process exit; xảy ra sau lỗi ban đầu, không là nguyên nhân dừng |

**Tool dừng vì không có capability skill hợp lệ của session hiện tại.**
Không phải hết timer, hết nước đi, thiếu RAM, mất process hoặc suy luận lỗi.
Run có0gameplay inputs,0PASS,0recovery inputs. Tool chưa gửi thao tác thoát
game trong lần này. Việc game tiếp tục mất lượt rồi về sảnh sau khi controller
đã dừng phù hợp với bỏ lượt do không có input; log không giữ từng auto-PASS để
xác nhận độc lập con số3người dùng thấy. Không gọi3lượt đó là tool chủ động PASS.

## Vì sao thiếu skill: giới hạn evidence

Các lần Mega Icarus thành công gần đây trong log local dùng
`normal / mega / pet_skill`; lần này dùng `mega / none / pet_skill`.
Room ghi localPetId2524. Reference catalog b6 ghi ID2524 là **JavIV**, trong khi
fusion selection trong diagnostics là pet2257. Reference catalog là snapshot
server cũ, không tự cấp authority hoặc chứng minh toàn bộ skill/loadout của
người dùng ở lần hiện tại. Đây là dấu hiệu cần đối chiếu pet/config, chưa đủ
để tự đổi cài đặt hoặc kết luận một native offset/geometry sai.

Refresh skill đã có từ baseline trước Phase 5 và có đường native hand riêng,
bypass opening-board priority. Vì vậy diagnostics `opening_board_action_priority`
và0extended scans **không tự chứng minh skill refresh bị bỏ qua**. Không sửa
thứ tự reader hoặc mở heap scan chỉ từ các counters này.

Log cũ chỉ giữ blocker chung, không giữ `_native_card_reason` sau các refresh.
Không biết nguyên nhân sâu là skill không hiện trong hand, card bị validator
loại, geometry tạm không ổn định hay cấu hình không khớp. Không gán một giả
thuyết thành nguyên nhân chắc chắn. Đã hỏi người dùng tên pet và bản tool;
chưa nhận trả lời tại thời điểm ghi báo cáo.

## Thiếu sót đã sửa

Nhánh thiếu capability/actionability sau warmup2s trước đây vào `auto_pause`,
FarmRunner dừng ngay trong trận, không đi qua recovery trở về phòng boss.
Đây là lỗi xử lý thất bại của tool, độc lập với lý do skill bị thiếu.

Bản sửa source:

- Ghi capability status/source/reason và cached native discovery reason trong
  warmup/terminal log; không thêm process read hoặc scan để ghi diagnostics.
- Solo farm có profile Pet Skill, thiếu capability/actionability sau warmup,
  current ACTIVE local session có board hợp lệ, không pending action: dispatch
  `PET_SKILL_CONTROL_UNAVAILABLE`, khóa gameplay và bàn giao existing recovery.
- Tái dùng normal Exit/confirm, xác minh đúng phòng boss và clear old session.
  Sau đó **dừng tại phòng boss**, giữ lỗi thật, không mở trận mới để thử lại cùng
  cấu hình chưa có skill. Nếu đường thoát bị game đẩy ra map/sảnh, tái dùng
  exact-boss room restoration rồi dừng trước Start.
- Hạch toán là technical abort/exit, không tính hoàn thành/thắng/thua, không giả
  F6 hoặc graceful stop. Emergency Stop vẫn ưu tiên và không cleanup input sau
  Stop; không bypass unknown/wrong session/foreground/locator/recovery guards.
- Coop/Bú win giữ đường cũ, không tự thoát phòng người khác từ fault mới này.

Không đổi thuật toán setup/sinh tồn/skill Mega Icarus, điều kiện Kết Ấn, chi
phí, BASIC/shadow, provider/capture/input/ACK ở luồng bình thường. Các thao tác
recovery chỉ phát sinh trên nhánh lỗi đã được xác minh; không hứa mọi lỗi đều
có thể thoát khi state/window/locator không còn đủ bằng chứng.

## Kiểm chứng và binding

Artifacts: `docs/artifacts/mega_icarus_skill_stop_20261014/`. `before.json`
pin279sources,1,912Phase5artifact files và9log files. `evidence/` giữ bản sao
log, `before/` giữ exact code trước sửa, `after_runtime_manifest.json` pin năm
runtime files mới và scope AST. Historical Phase5 evidence không bị rebound.

Focused recovery/farm/checkpoint tests: **202PASS**; reasoning regression:
**69PASS**. Test mới chạy actual combat loop qua NONE/warmup/handoff bằng
native fakes,0gameplay input; kiểm session/turn/pending/transient rejection,
ledger exit/confirm, cấm reentry và không giả kết quả.

Full discovery **2,152tests trong241.026s**:2,151PASS,1FAIL ở source-audit
harness. Test cố tình giả lập controller bytes đổi; helper mới đã reject đúng
nhưng ném AssertionError thay vì trả `pass_ast=false` theo API cũ của auditor.
Đã sửa riêng auditor để trả gate=false, giữ test nguyên và không nới hash gate.
Rerun **43tests PASS trong18.394s**, gồm test vừa lỗi, reasoning selection,
Bú win và fault-return. Không đổi runtime sau full run, không rerun toàn bộ
suite sau sửa harness. Không ghi full run đầu thành2,152/2,152PASS.

Final source/artifact preservation và exact hashes ở `verification_final.json`.
Root docs tại closure P8 được archive ở `before_docs/`; STATUS đã đổi banner
pause trước khi archive nên được phục dựng và kiểm **exact SHA** với manifest
P8, không chỉ coi text tương đương. Các artifact Phase5 gốc giữ nguyên.

Source-only, chưa build/version/EXE mới, không điều khiển game hoặc chạy live
trong bước sửa. Review P7/P8 vẫn là historical pin của source trước sửa; không
dùng lại để chạy native window mới hoặc tự bật REASONING. Cần đối chiếu pet
thực tế/config và, nếu còn lỗi khi cấu hình đúng, một test mới với diagnostics
đã bổ sung để xác định chính xác lỗi reader. Phase5 P9 vẫn tạm dừng.
