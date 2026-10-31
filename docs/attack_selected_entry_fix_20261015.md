# Attack đã chọn nhưng entry dừng — sửa ngày 2026-10-15

User yêu cầu sửa ngay rồi test lại P11. Hai run Issylt dừng trước trận được giữ
nguyên:88040078137b4d7cb241e2e315188f1b và8371e0e3a3f44219be371a3a07338235.
Run sau chứng minh Attack ALREADY_SELECTED nhưng visual Toggle thất bại15s.

Nguyên nhân chặn đã prove: `_ensure_required_attack_card` bắt artwork proof
ngay cả khi không cần click Toggle. Nguồn ảnh gây warmRatio0 còn UNKNOWN;
không kết luận game đổi art/coordinate. Tắt lưu PNG chỉ ngừng write_png_rgb,
capture và recognition vẫn chạy. Paired policy test và exact before-function
replay giữ trong [reproduction](artifacts/attack_selected_entry_fix_20261015/reproduction_before_after.json):
old STOP15.2s, new selected runtime verified sau3s; native IO/input đều mocked.

Sửa chỉ nhánh ALREADY_SELECTED: giữ existing3s settle/capture cadence rồi
existing atomic runtime read xác nhận cùng phòng/boss/card identity và no active
combat trước Start. Không click Toggle hoặc yêu cầu artwork cho thao tác không
phát. Start vẫn có visual/runtime preflight riêng; gameplay/CardUI/ACK không đổi.
Nếu selection thay đổi thì STOP, không tự chọn lại. Nhánh cần click Toggle vẫn
đòi đủ2visual frames, đúng identity/geometry/foreground và preflight hiện có.

Thêm2failure PNG tối đa từ buffers đã chụp khi Toggle proof thất bại; không capture
mới, không lưu routine PNG trong healthy farm. Disk failure không thay stop reason.
Controller chuyển nested entry stopReason sang last_stop_detail; UI giữ trạng
thái ĐÃ DỪNG và giải thích tiếng Việt, log hiển thị cause trước runtime summary.
Không modal/input/UI automation.

**102/102 focused tests PASS**, gồm6new cases và entry/layout/lobby selection/
controller/UI/screenshot regression; final4.715s. Initial failed run giữ nguyên:
phát hiện selected→deselected fallthrough cần chặn trước reserve và test cleanup
chưa close log; đã sửa và final run PASS. Full suite không rerun cho scoped fix;
P10 full2179 giữ historical scope, không re-certify source mới từ acceptance cũ.

[Source successor](artifacts/attack_selected_entry_fix_20261015/successor_source_manifest.json):
284files, đổi đúng3runtime files `tools/boss_entry.py`, desktop_farm_controller.py,
desktop_ui.py; thêm1testfile. Fingerprint
`bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f`.
Source solver/reader/executor/PNG policy/reasoning/timing giữ nguyên. Không build,
version bump/Git mutation/game writes. Native fix acceptance còn cần live.

User yêu cầu riêng một batch mới3ván Starburst73/Phoenix sau fix. Request Issylt
fixed cap1 chưa claim/zero starts được supersede, không reset old claims hoặc xóa
failed runs. [Package Starburst](phase5/artifacts/5d1_basic_reserve_p11_starburst_20261015_v1/prepared_package.json)
SIMPLE/SOLO/BASIC/normal-normal/default_attack/foreground-two_click, AI/shadowOFF,
target3/max3TOTAL; source UI mở bằng lệnh, chờ user manual Start. Pet name do user
xác nhận, không suy effects. Cùng P11, native H/I/R pending, U UNKNOWN; không AI
input/D1draft12/D2. Không computer-use điều khiển máy.

Live follow-up đã đóng: [P11 report](phase5/reports/5d1_p11_report.md),
Starburst73/Phoenix3/3WIN, corrected selected branch observed3entries dù artwork
proof false; Start3/Toggle0,3confirm/3normal returns/target Stop. Source284 frozen.
Native reserve vẫn INCONCLUSIVE vì timing provenance, không AI activation.
