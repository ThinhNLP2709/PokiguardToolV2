# Demon Farm — lỗi cấu hình Mega Icarus sau khi đổi lối chơi

2026-10-14 (Asia/Saigon). **FIXED OFFLINE / SOURCE ONLY.**

## Nguyên nhân đã xác minh

Mega Icarus và Bú win dùng `audition_mode=none` (Hành động skill: Không có).
Callback `_play_style_changed` chuyển sang Demon Farm đã đặt Pet thường,
Không tiến hóa, Nội tại pet, Kiếm đủ và ngưỡng mặc định, nhưng **quên chuẩn hóa
audition_mode**. Hàng Hành động skill bị ẩn với Nội tại pet; giá trị `none`
vẫn nằm trong StringVar và vẫn được `_draft_fields` gửi vào canonical model.

`GameplayConfig.__post_init__` từ chối `none` ngoài Mega Icarus/Bú win với
`NO_ACTION_REQUIRES_MEGA_ICARUS`. Callback bắt ValueError rồi return, nên UI
đang hiển thị Demon Farm nhưng config đã chấp nhận trong control plane vẫn
là lối trước đó. Save/Start đọc lại draft cũng bị từ chối.

Đổi qua Cơ bản/Chậm mà chắc chạy nhánh chuẩn hóa khác, đặt audition về V3;
vì vậy chuyển sang Demon sau đó lại hợp lệ. Lỗi phụ thuộc trạng thái trước
đó, không phải ngẫu nhiên. Log `logs/desktop_ui/20261013_224529/events.jsonl`
line10/14 ghi đúng `NO_ACTION_REQUIRES_MEGA_ICARUS`; line17 lưu Careful/V3
thành công. Log cũ không giữ raw draft bị từ chối nên không tự gán style Demon
cho hai event đó. Actual Tk callback regression đã tái hiện trực tiếp nguyên
nhân và workaround mà người dùng mô tả, không cần game.

## Sửa

Chỉ sửa runtime tại `DesktopApplication._play_style_changed`: trong nhánh
Demon, nếu audition hiện là `NO_ACTION` thì đặt về `V3_TWO_DIRECTION` cùng
transaction guarded đang cập nhật các field khác. V2/V3 hợp lệ được giữ nguyên.

Không nới validator để cho Demon dùng `NO_ACTION`, không tự đổi PlayStyle khi
Start, không cần lưu Cơ bản làm bước trung gian. Thuật toán chơi, memory,
screenshot, input/ACK, room/recovery, worker và AI gates giữ nguyên. Không sửa
file preferences thật của người dùng; Save/load test dùng thư mục tạm.

## Kiểm chứng

Thêm4meaningful tests vào `test_pet_configuration_ui.py`, dùng actual Tk
StringVars/traces/widgets, canonical control plane/preferences và fake farm
runner. Root window withdrawn; không attach/capture/input hoặc chơi game:

- Mega→Demon trực tiếp: draft/control-plane cùng Demon, save/load giữ đúng
  config, Start bàn giao đúng Demon cho fake runner, không qua Cơ bản.
- Bú win→Demon: bỏ `none` cũ và trở lại Solo/Nội tại pet hợp lệ.
- Mega↔Demon ba vòng: visible style và committed config luôn khớp.
- V2 hợp lệ trước Demon được giữ, không bị đổi thành V3 vô cớ.

Trước sửa:3tests đầu FAIL với5failed assertions/subtests, cùng lỗi
`NO_ACTION_REQUIRES_MEGA_ICARUS`. Sau sửa: **93/93 UI/config/preferences/
control-plane/hardening tests PASS trong8.431s**. Không live test hoặc build/
version/EXE mới; không rerun toàn bộ gameplay suite cho normalization UI này.

Source compatibility: lượt đầu7tests có5PASS/2FAIL vì historical gate cũng
pin test UI cũ, ngoài runtime UI. Đã pin riêng cả runtime UI và4test additions,
giữ exact before bytes và superseded manifest/helper. Rerun **2/2 affected
source-binding tests PASS trong0.970s**, gồm future-controller-mutation test
không đổi. Không nới gate hoặc rebind historical acceptance. Runtime không
đổi thêm sau93tests; thay đổi tiếp theo chỉ ở audit fixture/metadata.

Artifacts: `docs/artifacts/demon_style_switch_20261014/`. Before/after source,
reproduction, test logs, AST scope, exact hashes và preservation được giữ.
Runtime chỉ một method UI đổi; các method/test cũ giữ AST. Các artifact Phase5
và Mega skill fault patch trước đó giữ nguyên. Phase5 tiếp tục tạm dừng;
P9 chưa chạy. Bản sửa không tự kết luận lại nguyên nhân sâu của lỗi thiếu
skill ở run trước, vì log cũ vẫn thiếu native discovery reason.
