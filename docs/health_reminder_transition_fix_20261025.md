# Dừng nhầm HEALTH_REMINDER_BLOCKED sau trận71 — 2026-10-25

Đã sửa trong source. **769/769 bài regression PASS**, gồm4 ca mới. Chưa build
hoặc xác nhận live bản sửa. Soak200 nguồn cũ bị gián đoạn ở71/200, chưa PASS.

## Nguyên nhân có log xác nhận

Run`d1b1d9fe3b4c48f4b1e50e939d0c8bad`, source48b73af8…:

| Giờ Việt Nam25/10 | Sự kiện |
| --- | --- |
| 01:23:46.557 | Trận71 WIN, completed71/200 |
| 01:23:50.119 | Click nhận thưởng SENT |
| 01:23:50.521 | UI đọc lifecycle LEAVING_COMBAT, MatchHost RELEASING4 |
| 01:23:50.659 | Handler popup đọc lỗi `static instance class does not match type-info`, lập tức SAFE_STOP/HEALTH_REMINDER_BLOCKED |
| 01:23:55.534 | UI đã đọc phòng BOSS_LOBBY; controller đã STOPPED |

Đây là lỗi vị trí áp dụng handler. `_wait_boss_lobby` gọi outside-modal handler
ngay cả khi lobby snapshot còn UNKNOWN/LEAVING_COMBAT. Handler đọc singleton
PlayReminder trước khi kiểm outside-combat. Lỗi pointer/class trong lúc unload
Hub không được vào nhánh chờ2 giây (vì chưa đủ outside proof), rồi bị coi là
popup ambiguous và làm dừng phiên. Snapshot cùng lúc còn có một WorldBoss
static class mismatch và RoomCoopV2 chưa khởi tạo, phù hợp giai đoạn chuyển cảnh.

Không có event phát hiện popup/click Đã hiểu hoặc ảnh popup, nên không gọi đây
là lỗi đóng popup thật. Probe read-only sau sự cố cùng game PID9300 trả
PlayReminder clean/closed và đúng phòng Lieyun1436; không phát input.

71trận đều WIN,198local turns/198SWAP,0PASS.127SWAP có ACK,71kết bằng terminal
WIN; không gán terminal exclusion thành input lỗi. Mọi counter safety đều0,
không technical abort/recovery,1provider read error. Không dừng giữa trận71.

## Thay đổi

Handler kiểm eligibility từ snapshot/owner hiện có **trước khi đọc popup**.
Nếu còn trong trận/chuyển cảnh/owner tồn tại hoặc outside proof chưa đủ, trả
`DEFERRED`: không đọc popup static, chụp ảnh, focus hoặc input. Waiter hiện có
tiếp tục kiểm lifecycle/deadline/F9 và đọc lại phòng ở poll kế tiếp; không thêm
sleep/poll/capture vào flow. Run đã dừng trả BLOCKED, không đọc/input.

Khi đã có outside proof hợp lệ, giữ mọi kiểm chứng native/visual và giới hạn
retry/click cũ. Popup thật vẫn đóng một lần rồi reread router; lỗi native kéo
dài trong lobby đủ điều kiện vẫn fail closed. Không coi DEFERRED là ABSENT và
không dùng nó làm quyền input. Chỉ thay1 runtime function, không đổi offsets,
GameAssembly fingerprint, gameplay, QTE, executor, checkpoint hoặc version.

## Kiểm chứng

- Fixture nguyên snapshot lúc lỗi attempt71.
- Replay waiter LEAVING_COMBAT → lobby clean → ready: không đọc singleton lúc
  unload, không false Stop, không phát click khi không có popup.
- Replay chuyển cảnh → popup thật: handler vẫn gửi đúng1 acknowledgment trước
  ready. Các lifecycle chưa đủ proof/owner/read errors không cấp input.
- Run đã STOPPED không đọc/chụp/input. Các ca persistent dirty proof, geometry
  thay đổi, F9, một click không đóng, pinned và target re-entry vẫn qua.

[Incident/hash/timeline](artifacts/health_reminder_transition_fix_20261025/incident_evidence.json),
[verification](artifacts/health_reminder_transition_fix_20261025/verification.json),
[diff riêng](artifacts/health_reminder_transition_fix_20261025/owned_source.diff).
769tests PASS trong48,460s;357Python AST parse PASS.355/357file Python cũ
giữ nguyên; đổi `tools/farm_run.py`, `tests/test_play_reminder.py`, thêm JSON
fixture. Source:
`ffe076ad3e24c4e0c6d41435d45f18f0c7e578835131baca3e5b9ead95b020b5`.

Phiên source đang mở đã import code cũ, cần mở mới để áp dụng. Checkpoint
SAFE_STOP/HEALTH_REMINDER_BLOCKED hiện không nằm trong contract Resume, nên
không sửa/đổi nhãn checkpoint để ép Resume. Giữ nguyên71trận và nguyên nhân
dừng trong log. Muốn xác nhận một soak200 ổn định trên cùng source sau fix
thì cần phiên200mới; không gộp71trận source cũ để chứng nhận source mới.
