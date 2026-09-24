# Phase 4A.2-R1 — Pinned Foreground Existing-Input Lease Live Runbook

Phase này không tạo QTE hay tuyến input mới. Probe chỉ ghim game visible/topmost
và bọc nguyên hành động Pet Skill hiện có bằng một lease tạm thời. Click thẻ,
chuỗi hướng, delay hiện có, Space/Perfect, ACK và policy đều dùng lại executor
cũ. Lease chỉ giữ chuột đến khi click thẻ tạo QTE hợp lệ; trong QTE, chuột đã
được trả và chỉ keyboard còn bị khóa.

Mỗi bài bắt đầu từ boss lobby, Tool V2/FarmRunner phải đóng. User tự chơi bàn
để tích tài nguyên. `F9` luôn được giữ làm Emergency Stop; mỗi invocation chỉ
chạy một stage và không tự retry.

## B1 — quan sát QTE hiện tại, zero input — PASS STRONG

```powershell
python tools/foreground_qte_lease_probe.py --stage B1 --prearmed `
  --artifacts logs/phase4a2_r1/b1_<timestamp>
```

User tự nhấn thẻ và tự hoàn tất QTE. B1 ngày 2026-09-24 đã bind đúng QTE hiện
tại ở turn 11, generation 1, sequence 7 hướng và Perfect window 3.0–3.3 giây.
Probe gửi zero card click, zero direction và zero Space. Lỗi ghi log chỉ xảy ra
sau khi evidence đã lưu; code cleanup đã được sửa và topmost được gỡ sạch.

## B2 — toàn bộ hành động Pet Skill cũ trong lease

```powershell
python tools/foreground_qte_lease_probe.py --stage B2 --prearmed `
  --artifacts logs/phase4a2_r1/b2_<timestamp>
```

User tự vào trận và tự đi bàn để tích tài nguyên, nhưng không nhấn thẻ skill.
Khi policy cũ cho phép ra skill, probe lấy một lease xuyên suốt rồi để nguyên
executor cũ thực hiện: click thẻ → đọc QTE hiện tại → nhấn từng hướng và chờ ACK
→ nhấn đúng một Space trong Perfect window → xác nhận runtime `PERFECT`.

B2 chứng minh nguyên tuyến cũ vẫn hoạt động khi game được ghim. B2 không yêu cầu
một ứng dụng khác đang giữ foreground trước lúc action bắt đầu.

Run đầu ngày 2026-09-24 đã đạt `PERFECT`, nhưng giữ cursor confinement đến cuối
QTE. B2 retry sau refinement đã `PASS STRONG`: event
`foreground_qte_mouse_released_for_keyboard` xuất hiện 110 ms trước hướng đầu
tiên, mouse được trả và keyboard hook vẫn giữ đủ 7 hướng + Space.

## B3 — cùng hành động cũ, có takeover và trả focus best effort

```powershell
python tools/foreground_qte_lease_probe.py --stage B3 --prearmed `
  --artifacts logs/phase4a2_r1/b3_<timestamp>
```

User tự vào trận và tích tài nguyên như B2, không nhấn thẻ skill. Trước khi thẻ
đủ điều kiện, user đưa focus sang ứng dụng khác nhưng vẫn để cửa sổ game được
ghim và nhìn thấy. Khi action sẵn sàng, lease tạm lấy foreground/input authority,
executor cũ chạy trọn hành động Pet Skill, rồi lease thử trả focus về đúng cửa
sổ trước đó. Nếu Windows không cho trả focus, run vẫn có thể đạt khi cursor,
keyboard/mouse guard và topmost đều được trả sạch.

B3 chỉ đạt khi full action cũ thành công, foreground trước acquire không phải
game, mouse được trả trước hướng đầu tiên, cursor/guard/topmost được release
sạch. `focus_restored` là telemetry best effort, không phải hard gate.

B3 valid retry ngày 2026-09-24 đã `PASS STRONG`: foreground trước acquire là
Comet, 1 card click, 7/7 direction ACK, 1 Space, runtime `PERFECT`; mouse được
trả lúc QTE bind và toàn bộ guard/cursor/focus/topmost cleanup sạch. Artifact:
`logs/phase4a2_r1/b3_valid_retry_20260924_212722/`.

Probe không được acquire lease chỉ vì tài nguyên đã đủ. Exact current card phải
có button hợp lệ, `interactable=true`, chưa dùng trong match/turn, không pending
và không phải placeholder. Sample có zero input vì lease bị consume trước gate
này là `INVALID SAMPLE`, không được tính là gameplay failure hay B3 acceptance.

## Safety/acceptance chung

- Game không được minimized hoặc resize.
- Trước QTE, guard giữ chuột cho đúng một card click bằng `BLOCK_INPUT` hoặc
  `CURSOR_CONFINE`.
- Ngay khi QTE được bind, guard phải chuyển sang `KEYBOARD_HOOK`, tháo mouse
  guard và trả cursor trước hướng đầu tiên.
- Keyboard hook cho injected direction/Space và physical `F9` đi qua, chỉ chặn
  physical key khác trong thời gian QTE.
- Final release không được kéo cursor về vị trí cũ lần nữa sau khi user đã di
  chuyển chuột trong QTE.
- Guard, cursor và topmost phải release sạch trong mọi kết quả; focus restore là
  best effort và phải được ghi telemetry trung thực.
- Không retry input khi thiếu ACK.
- B2 và B3 đều chạy cùng `Phase3b3RuntimeHook` và `PetSkillActionExecutor` cũ;
  không có route directions-only hay Space thủ công.
- Mỗi live stage cần user báo sẵn sàng riêng.
