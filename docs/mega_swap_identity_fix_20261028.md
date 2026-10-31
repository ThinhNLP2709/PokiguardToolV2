# Mega Icarus: dừng nhầm vì metadata skill trên nước SWAP — 2026-10-28

Đã xác định và sửa nguyên nhân dừng phiên `a925e7b4a95e4edfb983cd1c834cd0be`
ở 1/10. Đây là BASIC Mega Icarus, Solo, Javan IV → Mega, ngưỡng 6 Kiếm,
boss Lienor ID2217. REASONING/shadow tắt. Không mở rộng Phase 5 trong tác vụ này.

## Chuỗi sự kiện được log chứng minh

Giờ bên dưới là Asia/Saigon, UTC+7, ngày 28/10/2026.

| Thời điểm | Bằng chứng |
|---|---|
| 22:48:26 | Trận đầu `M_1939f356` WIN STRONG, UI Thắng nhất quán; xác nhận thưởng/về phòng bình thường. |
| 22:48:34 | Bắt đầu trận hai `M_ed8a0ab0`. |
| 23:05:20.224 | SWAP cuối đã gửi tại turn141; sau đó nhận ACK. |
| 23:05:32.995 | Turn143: BASIC chọn `MEGA_ICARUS_SURVIVAL_HEALTH`, SWAP `(2,5)→(3,5)`; HP khoảng18.2%, Nộ75. |
| 23:05:33.176 | Fresh reread vẫn chọn chính SWAP đó. Capability skill chuyển NO_CAPABILITY → CURRENT, skill_card_id null →22, cost200Mana/150Nộ. Guard hủy nước chưa gửi với `POLICY_CHANGED_ON_FRESH_REREAD`. |
| 23:05:33.567 | Vòng kế tiếp cùng source bị `NONDETERMINISTIC_POLICY_FOR_SAME_SOURCE`; tự AUTO_PAUSED rồi `FARM_GAMEPLAY_AUTO_PAUSED`. |
| 23:05:34.512 | UI ghi STOPPED/COMBAT_SAFE_STOP, hoàn thành1, lần thử2; game vẫn ACTIVE_COMBAT. |
| 23:06:28.794 | UI lần đầu ghi LOBBY_OTHER, sau khi controller đã dừng khoảng55giây. |

Combat log: [attempt2](../logs/farm_runs/a925e7b4a95e4edfb983cd1c834cd0be/matches/attempt_002/combat.jsonl:2718).
UI: [stop trước, ra phòng sau](../logs/desktop_ui/20261028_222615/events.jsonl:1176).
Checkpoint và run.json giữ nguyên 1WIN/2attempts/SAFE_STOP, không xóa hoặc đổi kết quả.

Tool dừng trước khi game ra phòng. Combat collector đã kết thúc ngay lúc
AUTO_PAUSED nên không ghi các AFK event sau đó; việc bỏ3lượt/bị đá là người dùng
báo, exact server disconnect reason chưa có bằng chứng. Không quy stop cho
mất phòng trước, popup, timeout, hết10trận hoặc suy luận. Trận hai trước stop
đã gửi62SWAP/62ACK và8skill; không có pending SWAP thất lạc.

## Nguyên nhân và sửa

PolicyDecision dùng skill fields cho cả thông tin giải thích SWAP fallback.
Hai phép so sánh trong controller lại coi những fields đó là input target
của mọi action. Vì vậy SWAP không đổi nhưng metadata skill mới có cũng bị
coi là đổi policy, rồi nondeterministic ở vòng kế tiếp. Log native cho thấy
skill vẫn thiếu75Nộ; không có đề xuất chuyển từ SWAP sang skill tại turn143.

Sửa đúng hai boundary trong `tools/basic_auto_bot.py`: dùng action/target từ
`AutonomousActionIdentity.from_decision` đã có. SWAP so hai ô; CAST so card;
PET_SKILL vẫn so session/card; EVOLVE giữ target tiến hóa/attempt hiện có.
Giữ metadata skill trong policy/log. Không bỏ guard, không thực thi nước cũ
khi policy thực sự đổi, không retry input đã gửi.

BASIC policy/solver/provider/read/capture/executor/QTE/ACK/deadline/Stop/recovery
giữ nguyên bytes. Controller ngoài hai boundary được kiểm AST-exact; không có
thêm read, capture, sleep hay input. Không tự re-entry từ một combat đang pause.

## Kiểm chứng

- 9 regression PASS: cùng bàn cờ/multiplier và tài nguyên của incident, giữ
  diagnostics; actual skill/card/session/CAST/SWAP target changes vẫn phân biệt;
  foreign-session skill không được chọn; controller vẫn hủy trước input khi
  fresh policy thực sự đổi từ SWAP sang skill.
- Dùng controller nguyên bản trước sửa: hai regression capability xuất hiện/mất
  đều FAIL, tái hiện đủ `POLICY_CHANGED_ON_FRESH_REREAD` →
  `NONDETERMINISTIC_POLICY_FOR_SAME_SOURCE`, input0.
- Sau sửa, hai ca đó đều gửi đúng1SWAP/1ACK qua controller thật với native/input
  giả; không attach hay input game. Fixture sửa1dòng để truyền đúng audition
  config Mega; không thay runtime config.
- Chạy467tests liên quan. Có2test methods lịch sử trượt, tổng6failure events:
  hash/source audit cũ và5subcases full-log parity thiếu metadata random mới.
  Controller trước sửa cũng tái hiện đúng6events đó. Không sửa/bỏ assertion
  lịch sử để gọi toàn suite PASS; không có failure mới của bản sửa.
- 363AST/compile PASS. Chỉ1runtime file +1test fixture đổi; thêm1test file;
  360Python files cũ còn lại byte-exact.

Evidence: [verification](artifacts/mega_swap_identity_20261028/verification.json),
[before regression](artifacts/mega_swap_identity_20261028/before_final_regression.log),
[after regression](artifacts/mega_swap_identity_20261028/after_final_regression.log),
[related tests](artifacts/mega_swap_identity_20261028/focused_tests.log),
[raw manifest](artifacts/mega_swap_identity_20261028/raw_manifest.json),
[runtime diff](artifacts/mega_swap_identity_20261028/runtime_changes.diff).

## Phạm vi bàn giao

Đã sửa source, chưa live lại, chưa nâng version hoặc build ZIP mới. ZIP1.2.10
giữ SHA7249a3e5… và chưa chứa bản sửa này. Tool nguồn đang mở từ22:26 đã load
controller cũ; cần phiên tool mới để nạp sửa. Không đóng/mở hay Start phiên
đang chạy trong tác vụ này; không điều khiển game và không thay checkpoint.
