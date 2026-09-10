# Phase 3A.2 — Runbook cấu hình Pet và capability

**Cập nhật 2026-09-11:** source v1.0.45 có bản sửa đọc bàn/sequence sau hai
lượt test thủ công. Dùng [hướng dẫn test lại](phase3a2_manual_bugfix.md), mục
cuối. Số liệu v1.0.44 dưới đây là acceptance lịch sử, không phải live acceptance
của bản sửa. Full regression hiện tại: **1134 PASS**.

Runbook này tái hiện đúng phạm vi cấu hình. Nó không chạy Pet Skill, không equip
pet, không đổi Fusion target và không sửa gameplay policy.

## 1. Offline

Từ `D:\PokiguardToolV2`:

```powershell
$env:PYTHONPATH = "src;."
python -m unittest -v tests.test_pet_configuration tests.test_pet_configuration_ui tests.test_desktop_preferences tests.test_farm_checkpoint tests.test_desktop_control_plane tests.test_desktop_farm_controller tests.test_desktop_ui_hardening tests.test_farm_run tests.test_farm_run_cli_d6 tests.test_basic_policy tests.test_replay_basic_policy tests.test_pet_skill_shadow tests.test_pet_skill_action tests.test_pet_skill_b4
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
```

Expected ở commit Phase 3A.2: focused `377 PASS`, full `1121 PASS`, compileall
và diff check PASS.

## 2. B1 — UI/config smoke

Game có thể mở sẵn. Lệnh chỉ mở source UI, không auto-Start/Resume:

```powershell
$env:PYTHONPATH = "src;."
python tools/desktop_ui.py `
  --artifacts logs/phase3a2_live_b1 `
  --preferences logs/phase3a2_live_preferences.json
```

Trong tab Preferences, kiểm tra:

1. Không có `ManaPriority`.
2. Default là Pet thường / Tiến hóa pet thường / Thẻ chưởng mặc định.
3. Pet tiến hóa và Mega hiện nhưng disabled.
4. Tiến hóa pet tiến hóa và Tiến hóa pet Mega hiện nhưng disabled.
5. Pet Skill disabled với `NORMAL/NORMAL`, enabled với
   `LEGENDARY/NONE` hoặc `NORMAL/LEGENDARY`.
6. Nếu đang chọn Pet Skill rồi bỏ hết nguồn skill, Damage tự về Default Attack.

Đặt `LEGENDARY / NONE / PET_SKILL`, Validate & Save, đóng bình thường rồi mở
lại cùng file preferences. Cấu hình phải phục hồi và không tự Start/Resume.

## 3. B2 — gate profile Pet Skill

Giữ `LEGENDARY / NONE / PET_SKILL`. Start và Resume phải disabled, notice phải
nói gameplay integration chưa có. Nếu command callback được gọi trực tiếp,
control plane và controller manager vẫn phải từ chối trước foreground handoff,
worker, boss entry hay input. Tất cả bộ đếm B2 phải bằng 0.

## 4. B3 — một match BASIC mặc định

Chỉ dùng khi được yêu cầu live lại từ boss lobby chính xác. Không biến thành
soak và không dùng Pet Skill:

1. Đặt `NORMAL / NORMAL / DEFAULT_ATTACK`.
2. Đặt Target matches `1`, Max attempts `1`.
3. Xác nhận game executable đúng và game đang ở `BOSS_LOBBY`.
4. Nhấn Start đúng một lần; không thao tác game trong lúc controller sở hữu
   input.
5. Chờ controller `STOPPED`, rồi kiểm tra `run.json` và `combat.jsonl`.

Một acceptance mạnh cần đúng một completion, không attempt 2, accounting nhất
quán, không `PetSkillAction`, final `BOSS_LOBBY`. Nếu terminal không chứng minh
được, giữ nguyên `UNKNOWN`/safe stop; không suy ra WIN từ việc pet mạnh hoặc từ
màn hình chính.

Mẫu ngày 2026-09-10 đã dùng hết đúng một attempt và kết thúc
`COMBAT_TERMINAL_UNPROVEN`; không tự chạy lại chỉ để đổi phân loại.

## 5. B4 — shutdown

Chỉ đóng Desktop UI sau khi controller đã dừng. Xác nhận controller, poller và
Python Desktop process đều không còn. Game có thể giữ chạy. Không để lại Pet
Skill harness.

## 6. Resume và migration audit

- Preferences v1 `evolution` phải hiển thị `NORMAL/NORMAL/DEFAULT_ATTACK`.
- Preferences v1 `attack` phải hiển thị `NORMAL/NONE/DEFAULT_ATTACK`.
- Nút **Load Checkpoint Preferences** chỉ tải draft; Resume là lệnh riêng.
- Checkpoint v1 có lịch sử nhưng không có startup artifact đồng nhất phải báo
  `CHECKPOINT_PROFILE_UNKNOWN`.
- Checkpoint profile Pet Skill được đọc/hiển thị nhưng không được chạy qua
  BASIC cũ.

## 7. Dừng phạm vi

Sau Phase 3A.2, không thêm Pet Skill vào BasicPolicy/FarmRunner, không thêm
planner Mana/Rage và không đoán reset semantics của
`Board.isUsingLegendCard`. Bước kế tiếp cần prompt riêng cho Phase 3C.0.
