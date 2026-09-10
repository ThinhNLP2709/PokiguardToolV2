# Phase 3A.2 — Pet Configuration + Capability Model

**Maintenance 2026-09-11:** source v1.0.45 sửa hỗ trợ đọc bàn b2 và so sánh
sequence sau hai run người dùng test. **277 focused / 1134 full PASS**, chưa
chạy lại live. Xem [báo cáo bugfix](phase3a2_manual_bugfix.md). Acceptance
v1.0.44 bên dưới được giữ nguyên như lịch sử.

**Kết quả:** **PASS**, không xếp `PASS STRONG` vì mẫu live B3 không thu được
bằng chứng terminal và không trở về `BOSS_LOBBY`.

**Base:** `832e834742a48c2241a6efefd1fb580f2ee2b8f8`

**Source version:** `v1.0.44`

**Phase commit:** commit chứa tài liệu này; Git receipt nằm trong báo cáo cuối.

## Mô hình cấu hình

`GameplayConfig` là giá trị immutable mô tả ý định của operator. Desktop,
preferences, checkpoint, Resume và CLI dùng cùng các enum ổn định:

| Trường | Giá trị được hỗ trợ | Hiển thị nhưng khóa | Mặc định |
|---|---|---|---|
| `MainPetType` | `NORMAL`, `LEGENDARY` | `EVOLVED`, `MEGA` | `NORMAL` |
| `EvolutionTarget` | `NONE`, `NORMAL`, `LEGENDARY` | `EVOLVED`, `MEGA` | `NORMAL` |
| `DamageCardMode` | `DEFAULT_ATTACK`, `PET_SKILL` khi có nguồn | — | `DEFAULT_ATTACK` |

UI dùng đúng nhãn **Pet của tôi**, **Tiến hóa**, **Thẻ sát thương**. Setting
`ManaPriority` không còn trong `DesktopConfig`, preferences mới hoặc giao diện.
Adapter `legacy_basic_policy` chỉ là cầu nối nội bộ tạm thời cho hai profile đã
được chứng minh:

- `NORMAL / NORMAL / DEFAULT_ATTACK` → BASIC `EVOLUTION` cũ;
- `NORMAL / NONE / DEFAULT_ATTACK` → BASIC `ATTACK` cũ.

Mọi profile khác bị chặn trước khi tạo worker, chuyển foreground hoặc gọi
FarmRunner. Không có fallback ngầm từ Pet Skill sang Attack. Adapter được đánh
dấu để gỡ ở Phase 3C.1; `BasicPolicyEngine` không thay đổi trong phase này.

## Capability và tính hợp lệ

`PetLoadoutCapability` giữ danh sách `skill_sources`, số nguồn và trạng thái có
cấu trúc. Đây là ý định loadout, tách biệt với `PetSkillCapability` runtime.

| Main pet / Evolution | Nguồn skill | Trạng thái |
|---|---|---|
| `NORMAL / NONE` | không có | `NO_SKILL` |
| `NORMAL / NORMAL` | không có | `NO_SKILL` |
| `NORMAL / LEGENDARY` | `EVOLUTION_TARGET` | `EVOLUTION_TARGET_SKILL` |
| `LEGENDARY / NONE` | `MAIN_PET` | `MAIN_PET_SKILL` |
| `LEGENDARY / NORMAL` | `MAIN_PET` | `MAIN_PET_SKILL` |
| `LEGENDARY / LEGENDARY` | `MAIN_PET`, `EVOLUTION_TARGET` | `MULTIPLE_SKILL_SOURCES` |

Pet Skill chỉ bật khi danh sách nguồn không rỗng. Nếu operator đang chọn Pet
Skill rồi đổi sang profile không có nguồn, UI chuẩn hóa về `DEFAULT_ATTACK`.
Trường hợp nhiều nguồn giữ nguyên cả hai candidate và chặn với
`PET_SKILL_SOURCE_SELECTION_UNDEFINED`; không nguồn nào được tự chọn.

`EVOLVED` và `MEGA` tạo capability `UNKNOWN` và không thể trở thành cấu hình
hoạt động qua UI. Phase này không equip pet, chọn Fusion target, mở inventory,
hoặc điều khiển Pet Skill.

## Preferences và checkpoint

Preferences mới dùng schema `pokiguard.desktop_preferences.v2`. Migration từ
v1 là tường minh:

- `mana_priority=evolution` → `NORMAL / NORMAL / DEFAULT_ATTACK`;
- `mana_priority=attack` → `NORMAL / NONE / DEFAULT_ATTACK`.

Sau khi lưu lại, file chỉ chứa ba trường mới. Migration idempotent; new-schema
fields thắng stale legacy fields; enum hỏng, legacy value lạ và tổ hợp Pet
Skill không có nguồn đều fail closed về safe defaults kèm warning. Live B1 đã
lưu và mở lại `LEGENDARY / NONE / PET_SKILL` mà không Start hoặc Resume.

Checkpoint mới dùng `pokiguard.farm_checkpoint.v2` và giữ nguyên immutable
`gameplay_config`. Loader vẫn đọc v1. Nếu v1 có lịch sử trận, cấu hình chỉ được
khôi phục khi sibling `run.json` và từng `combat.jsonl` cùng FarmRun/MatchId cho
một startup profile duy nhất. Thiếu hoặc mâu thuẫn bằng chứng trả
`CHECKPOINT_PROFILE_UNKNOWN`; không đoán rarity hoặc Pet Skill. Lịch sử kết
quả, MatchId, action aggregate và Emergency/completed semantics không bị sửa.

Nút **Load Checkpoint Preferences** chỉ đưa cấu hình/limits vào draft khi idle;
Resume vẫn là thao tác riêng. Test Tk thật chứng minh checkpoint Pet Skill được
hiển thị nhưng không auto-Resume và Start vẫn khóa; checkpoint ATTACK v1 hiển
thị thành `NORMAL / NONE / DEFAULT_ATTACK`.

## Kiểm thử offline

- focused config/checkpoint/Desktop/BASIC/Pet Skill: **377 PASS**;
- full regression: **1121 PASS** trong 16.701 giây;
- `compileall`: PASS;
- `git diff --check`: PASS.

Hồi quy giữ nguyên fixture HT7 `200/200`, HT2 `200/150`, closed-loop direction,
exactly-one Space, current-generation runtime PERFECT và B4 generation
isolation. Không có diff trong `basic_policy.py` hoặc `pet_skill_action.py`.

## Live B1 — UI và round trip

Source UI `v1.0.44` được mở cạnh game 1.7.4. Quan sát trực tiếp xác nhận:

- ba trường mới và default đúng;
- `ManaPriority` không còn;
- các lựa chọn EVOLVED/MEGA hiện rõ nhưng không chọn được;
- Pet Skill bật/tắt động và normalize đúng;
- `LEGENDARY / NONE / PET_SKILL` lưu, đóng, mở lại đúng;
- không auto-start, không auto-resume.

Artifact: `logs/phase3a2_live_b1/summary.json` và
`logs/phase3a2_live_preferences.json`. B1 có controller/FarmRunner/boss-entry/
gameplay input đều bằng 0, poller start đúng 1, UI/thread error bằng 0. Trường
schema preferences trong summary cũ là chuỗi hiển thị hard-code v1; file thật
là v2 và chuỗi summary đã được sửa dùng hằng schema canonical.

## Live B2 — gate profile tương lai

Profile `LEGENDARY / NONE / PET_SKILL` được lưu hợp lệ. UI hiển thị
`PET_SKILL_POLICY_NOT_IMPLEMENTED`, Start và Resume disabled. Thử callback qua
biên command vẫn bị từ chối trước worker.

| Bộ đếm | Giá trị |
|---|---:|
| controller starts | 0 |
| FarmRunner starts | 0 |
| boss entry | 0 |
| PetSkillAction starts | 0 |
| mouse/keyboard gameplay input | 0 |

## Live B3 — một profile BASIC mặc định

Đã khôi phục `NORMAL / NORMAL / DEFAULT_ATTACK`, đặt target completion `1` và
max attempts `1`, rồi chạy đúng một attempt với Seadra 1430.

- FarmRunId: `cb131ac223ef46d9911688ea30f762f9`;
- MatchId: `M_9dbded02`;
- attempts: `1`, không có attempt 2;
- local/boss turns: `3/1`;
- policy branches: `MANA=1`, `SWORD=1`;
- input: boss entry `1`, SWAP `2`, EVOLVE `0`, CAST `0`, PASS `0`;
- PetSkillAction/card click/QTE/Space: `0`;
- memory write/direct call/network manipulation: `false`.

Match objects biến mất lúc `08:58:12.807Z`; cả memory terminal result và
postmatch UI result đều `UNKNOWN`. Game chuyển thẳng sang màn hình chính
(`LOBBY_OTHER`) thay vì trở về phòng boss. FarmRunner chờ bounded 90 giây rồi
dừng fail closed với `COMBAT_TERMINAL_UNPROVEN`, `COMBAT_SAFE_STOP`, exit 2.
Kết quả không được đoán hoặc cộng: completed/win/loss/unknown đều `0`,
`result_accounting_consistent=true`, controller `STOPPED`.

Artifact chính:
`logs/farm_runs/cb131ac223ef46d9911688ea30f762f9/run.json` và
`matches/attempt_001/combat.jsonl`. Mẫu này chứng minh cấu hình mặc định đi qua
policy BASIC cũ, không gọi Pet Skill và không tạo attempt thừa. Nó không chứng
minh một completion hoặc final `BOSS_LOBBY`, nên Phase 3A.2 không được xếp
`PASS STRONG`. Không chạy trận thứ hai để tránh mở rộng acceptance đã giới hạn.

## Shutdown và giới hạn tiếp theo

Sau controller stop, Desktop UI đóng bình thường: poller alive `0`, UI/Python
Desktop process alive `0`; game PID 26312 được giữ chạy theo yêu cầu. Không có
Pet Skill harness/controller còn lại.

`Board.isUsingLegendCard` full-game reset semantics vẫn **UNKNOWN** và phải
được audit trước khi kết hợp Pet Skill liên tục với board policy. Phase an toàn
tiếp theo, chỉ khi có prompt riêng, là **Phase 3C.0 — Legend-Card Busy-State +
Same-Turn Continuation Audit**.
