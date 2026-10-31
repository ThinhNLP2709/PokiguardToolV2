# Bàn giao hiện tại — UI suy luận Demon Farm ăn Khiên

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
