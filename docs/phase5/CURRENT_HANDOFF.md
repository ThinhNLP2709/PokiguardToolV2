# Bàn giao suy luận — source hiện tại và UI lịch sử

**18/11/2026 — Offline mới nhất: source450abb97… sửa định giá Hút Mana/Nộ.**
Audit13 khoảng B17 phát hiện adviser chỉ xét Mana dù raw STEAL có cả POWER.
Shared tactics giờ xét từng Mana/Nộ, max-single-resource, thiếu số dư→unknown;
không đổi BASIC/input/PASS/skill guard. Summary thêm nguồn giới hạn. Paired
613 replay/83 đổi,tất cả swap→swap hợp lệ;222/227 test PASS,5 lỗi fixture cũ
tái hiện trên tactics trước sửa.0 live/train/build. Sourceb1b7 đã live
BASIC1+R1 theo mốc dưới **không** là live của450a; không rebind profile cũ.
[Báo cáo và việc còn mở](B17_REPLY_DRAIN_REVIEW_20261118.md).

**18/11/2026 — Mốc mới nhất: B17 boss before/after + R1 đã đóng.**
Sourceb1b718fb… chỉ thêm optional board/state logging và offline normalizer,
246 test PASS. Priest131/DemonShield: thêm1 BASIC8 lượt+1 R8 lượt,2 WIN
STRONG/confirm/return,0 safe stop/recovery/PASS. Có13 khoảng boss với bàn
trước/sau thực. R8 decision/24 ROOT-FRESH-FINAL hợp lệ;5 override thực gửi
(4 ACK+1 terminal),49 diagnostic0 loss,worker1/1 reaped. Profile mới dùng7
timing samples BASIC cùng source/B17/host; không rebind B16/95288. Các cap
đóng, tổng nhóm6 trận (5 BASIC+1 R),không tự restart hoặc tăng cap. Game
Priest/room911927, toolPID15904 stopped1/1. Chưa fit/build/skill;2 trận mới
khác board, không kết luận R nhanh hơn. [Báo cáo](B17_BOSS_BOARD_AND_REASONING_20261118.md).

**18/11/2026 — B17 Priest/Demon BASIC CLOSED:** source hiện tại95288bff…
giữ nguyên trong4 trận mới (1 thăm dò+3 tiếp theo),4 WIN STRONG/confirm/return,
28 lượt ta,24 ACK+4 terminal,0 PASS/safe stop/technical recovery.51 outcome,
166 effect;28 op của ta khớp nước gửi,21 op trong batch boss;22 STEAL đã có
POWER/MANA.17 observation Demon/10 usable nhưng0 calibration-eligible.
Game ở Priest131/room911927, tool dừng3/3. Cap4 đóng. Chưa REASONING B17,
profile/skill/train/build. Acc/boss/pet mỗi nhóm giữ riêng; full gear và
boss pre-board còn UNKNOWN. [Báo cáo](B17_PRIEST_OUTCOME_LIVE_20261118.md).

**Mốc offline trước live B17:** source923813c6… thêm
optional evidence stealType/ops SWAP, exporter observation chung và test.
137 batch/397 effect đã chuẩn hóa;186 test PASS;35 observation Demon cũ
giống hệt.11/11 power mismatch có pattern chạm trần. Chưa fit model,
đổi gameplay hoặc build/live. [Báo cáo](COMMON_ACTION_OUTCOMES_20261118.md).
Learned outcome/value/ranker đã xếp sau việc cũ. Skill binding/damage/heal
và boss action/refill còn cần dữ liệu có nguồn; không dùng WIN làm nhãn
tối ưu cho mọi nước. [Backlog hiện tại](RESEARCH_BACKLOG_20261118.md).

**Mốc live trước đó:** source9b4a2109… đã qua live có giới hạn
3 BASIC +3 REASONING trên B16/Lion Star105/Demon Aegis ăn Khiên,6WIN. Hai
nhánh bounded-unknown đã thực sự chạy,21 quyết định/63 receipt hợp lệ,
129 record không mất,3worker reaped. Chưa build source này hoặc suy ra
nghiệm thu mọi style/pet/ZIP. [Live report](BOUNDED_FUTURE_NATIVE_20261118.md).

Hướng hiện tại sau khi rà temp: nối tiếp nhánh dữ liệu effect/damage còn mở,
giữ model học trong backlog; không làm lại tactical planner đã áp dụng.
[Backlog và thứ tự](RESEARCH_BACKLOG_20261118.md), [STATUS](STATUS.md).
Các cap live đã đóng; dữ liệu thiếu ở skill/boss action chưa được bù bằng
giả định. Phần dưới giữ nguyên danh tính bàn giao UI01/11, là lịch sử của
checkpoint cũ, không phải trạng thái source hoặc lệnh chạy hiện tại.

## Bàn giao UI01/11/2026 — lịch sử

**Checkpoint1.3.0 ngày01/11/2026:** [báo cáo và artifact](../v1.3.0_release_report.md).
Scope hiện tại giữ nguyên; [AI chung và mọi targetDemon](NEXT_REASONING_SCOPE.md)
là yêu cầu phần tiếp theo, chưa triển khai. Bảng dưới giữ danh tính bản UI live gốc.

Ngày01/11/2026. **Task UI đã CLOSED PASS trong scope đã kiểm**.
Roadmap Phase5 đã đóng; không có prompt hoặc trận live bắt buộc còn thiếu.
Chưa đổi version/phát hành sau nghiệm thu UI. Hướng công việc tiếp theo đang
chờ user chọn, không tự mở model, lối chơi hoặc batch mới.

## Bản UI live gốc

| Mục | Danh tính |
|---|---|
| Version trên bản thử |1.2.10; khác release1.2.10 cũ và ZIP F1 |
| Thư mục EXE |`D:/PokiguardToolV2/build/ui-reasoning-20261031-final/dist/PokiguardToolV2/` |
| EXE SHA256 |`2969293466f5e8b8f0dcca593cdc837ae694633dcfddcf97fb635fecd3243f51` |
| ZIP |`D:/PokiguardToolV2/build/ui-reasoning-20261031-final/PokiguardToolV2-v1.2.10-win-x64.zip` |
| ZIP SHA256 |`fcf29a1ab2c0b32e4398307e92e12879d5ac559325125ede4fbfef006a9d3c26` |
| Source375Pythonfiles |`4d07f02ed2f1817c1d87557f6ea837caea19dcce6a4e4a81f554f7b7089c2a49` |
| Kết quả UI live |1BASIC+1UI-R,2WIN/confirm/về phòng;6Rcompleted retention,31AIrecords/0loss,1workerreaped |

[Báo cáo UI](ui_reasoning_delivery_20261031.md),
[closure có raw refs](artifacts/ui_reasoning_delivery_20261031/live_closure.json),
[kiểm cuối](artifacts/ui_reasoning_delivery_20261031/final_live_verification.json).
Hai trận có bàn cờ khác nhau; không dùng số lượt1và6 để kết luận R tốt/kém hơn.
Đổi nước so với BASIC không là điều kiện để suy luận hoạt động hợp lệ.

## Phạm vi được bật

Demon Farm, ăn Khiên, Solo/Lieyun77, pet thường/không tiến hóa/nội tại,
4Kiếm hiệu dụng, cùng account/đồ/stats/gameb12/host đã kiểm; tiền cảnh,
hai lần nhấp,1280×640. Budget thực dùng tối đa4000ms, còn trừ reserve/margin.

BASIC là mặc định khi chưa có lựa chọn đã lưu. UI nhớ lựa chọn user đã lưu;
khi intent R bật nhưng thiếu/sai profile hoặc lỗi AI, farm tiếp tục bằng BASIC
hợp lệ và hiện lý do. Các chốt an toàn state/input cũ vẫn giữ nguyên.
Không mở target gem khác, boss/account/host khác, HT7/Mega/Coop/DinosaurR,
skill/PASS/model/R2 từ nghiệm thu UI này.

## Profile và cách mở đúng bản thử

Profile là dữ liệu riêng **ngoài ZIP**, ở:
`docs/phase5/artifacts/ui_reasoning_delivery_20261031/live_final_data/preferences/reasoning_acceptance/acceptance.json`.
DataRoot của phiên đã kiểm là:
`D:/PokiguardToolV2/docs/phase5/artifacts/ui_reasoning_delivery_20261031/live_final_data`.

Profile pin cả source/EXE/đường EXE/game/host/cohort; không chép profile này sang
máy/đường EXE/binary khác rồi coi là đã được nghiệm thu. ZIP riêng lẻ không
chứa hồ sơ account hoặc tự bật quyền chọn nước R. Chạy với dataRoot thường
không có profile thì dùng BASIC và báo lý do; đây là fallback đã thiết kế.
Thay đường EXE hoặc build/version cần chuẩn bị profile tương ứng và kiểm đúng
phần thay đổi, không sửa hash để ép hồ sơ cũ qua gate.

Không dùng lại request/claim/cap F1/E2 đã đóng. Hai lượt kiểm UI mới cũng đã
dùng đủ; agent không tự thêm trận. Tool chỉ farm khi user tự Start theo giới
hạn user chọn, không có auto-start/auto-resume mới.

Trong AI, chọn Suy luận Demon Farm—Khiên rồi Lưu cấu hình AI để dùng ở lần
Start/Tiếp tục sau. Muốn tắt, đợi phiên dừng, chọn Cơ bản, tắt shadow nếu không
cần và lưu AI. Không cần đóng/mở tool chỉ để đổi intent khi controller đã dừng.

## Log và rollback

- Trận: `logs/farm_runs/<farm_run_id>/`, gồm run/checkpoint/combat.
- AI: `logs/farm_runs/reasoning/ui_<id>/`; session.json nối về farm run,
  watermarks.json xác nhận drain/reap; correlation`<UIrun>:<combatIndex>`.
- UI: `logs/desktop_ui/<session>/`; phân biệt intent đã lưu với trạng thái R
  thực sự completed hoặc fallback.
- [Rollback](ROLLBACK.md) giữ9ZIP cũ, không đè release bằng bản thử.

22test UI mới PASS,100cycles qualification và134modules+entry parity đã kiểm.
Bộ hồi quy rộng có các lỗi lịch sử đã đối chiếu, không gọi toàn bộ suite xanh.
Sharedguard không hết/aggregate reserve không vượt trong live;3soft flags
controller-tail được giữ trong log và report. NativeU/actualenergy cònUNKNOWN,
efficacyINCONCLUSIVE. Các hạn chế này không được đổi thành kết luận đã hỗ trợ.
