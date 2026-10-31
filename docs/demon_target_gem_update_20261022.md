# Demon Farm — Viên mục tiêu, 2026-10-22

Cập nhật sau báo cáo này: người dùng yêu cầu BASIC dùng ngưỡng **Kiếm hiệu dụng**.
[Bản sửa riêng](demon_effective_sword_fix_20261022.md) thay quy tắc số ô trước đó.
Parity với policy cũ trong báo cáo này chỉ áp dụng source9fa67d8…, không áp dụng
cho source966bd63… đã đổi có chủ đích điều kiện/xếp hạng Demon.

Theo yêu cầu người dùng: đổi tên hiển thị Demon Aegis Farm thành Demon Farm và
thay loại viên kích hoạt cố định Khiên bằng dropdown riêng cho lối chơi Demon.

- Lựa chọn: Khiên / Máu / Mana / Hút / Nộ; không có Kiếm hoặc UNKNOWN.
- Mặc định Khiên. ID `demon_aegis_farm` giữ nguyên, thêm `demon_target_gem` với
  giá trị `shield`, `health`, `mana`, `drain`, `rage`.
- Tùy chọn và checkpoint cũ thiếu trường mới được đọc là Khiên; giá trị không
  hợp lệ bị từ chối. Không tăng schema vì đây là trường bổ sung có mặc định.
- Dropdown chỉ hiện với Demon Farm; bị khóa khi chạy và giữ lựa chọn khi đổi
  sang lối chơi khác rồi quay lại. Đổi target không sửa cấu hình Nội tại pet.
- Cấu hình đi qua Desktop → CLI FarmRunner → combat → PolicyConfig; được ghi
  cùng checkpoint/cấu hình log. Không đổi executor hoặc thêm thao tác trong game.

Geometry nhận loại viên mới cho cả nhận diện match ngang/dọc và forecast setup.
Quy tắc quét vuông góc, hợp vùng chữ thập, UNKNOWN, số Kiếm vật lý, multiplier,
ngưỡng Kiếm BASIC, ưu tiên an toàn và mandatory fallback giữ nguyên.
Loại viên kích hoạt độc lập với việc ưu tiên Khiên/Máu để sinh tồn.

Generic shadow planner/replay dùng cùng lựa chọn. D3 live certificate cũ chỉ có
bằng chứng cho Khiên/Demon Aegis, nên từ chối target khác và giữ BASIC theo cơ
chế fallback sẵn có. Không rebind calibration hay chứng nhận kết liễu cho pet
khác. E1 vẫn ở cùng milestone; phiên B1 b10 thuộc source trước thay đổi này.

Baseline source347file:
`b338383abe567d474c849ec157e0ad12338ccf07f2cb21d638b175004958fc77`.
Lưu nguyên bản tại [before](artifacts/demon_target_gem_20261022/before/),
[manifest](artifacts/demon_target_gem_20261022/before_source.json).
Historical test view chọn snapshot có pin hash; default runtime/source admission
vẫn dùng code hiện tại, không mượn authority lịch sử.

Kiểm chứng offline hoàn tất: bộ hồi quy535 ca đã chạy; các lỗi so sánh schema/
metadata lịch sử được sửa trong fixture test, giữ decoder runtime nghiêm ngặt.
Sau sửa,76 ca liên quan PASS; kiểm tra cuối78 ca giao diện, adapter, projection
và b10 PASS. Không tuyên bố đã chạy lại toàn bộ suite. Đối chiếu18 tình huống
với policy trước sửa cho cùng action/move/branch khi mặc định Khiên. Toàn bộ
src/tools/tests parse được;11 file flow/reader/input/QTE/ACK/recovery giữ nguyên.
AST controller/combat/farm adapter chỉ khác phần chuyển cấu hình mới.

Source348file cuối:
`9fa67d8d3bca0cf9527104f0f7bedea0ec3b2183270e615eabaa7f5570ef8d80`.
Chi tiết: [verification.json](artifacts/demon_target_gem_20261022/verification.json),
[flow proof](artifacts/demon_target_gem_20261022/flow_ast_proof.json),
[scope](artifacts/demon_target_gem_20261022/scope_check.json).
## Live theo yêu cầu: mục tiêu2 trận

Người dùng yêu cầu mở tool mới và tự bấm Start. Phiên
`live2_20261022_012759`, farm `adf2890a002a49ca9b34194511eb6dfb`:
**WIN2/2**, Lieyun77, Demon Farm BASIC, ngưỡng4, target **Khiên**, AI/shadow OFF.
Entry2, swap3, ACK1, terminal swap2; confirm2, kết quả2/2 CONSISTENT;
0 read error/timeout/recovery/technical abort/input-safety violation.
Trận2 có SETUP rồi PASSIVE_FIRE, bao phủ bàn cờ lượt sau và chuyển trận bình thường.
Về BOSS_LOBBY, dừng FARM_TARGET_COMPLETED, exit0. Chưa có live cho target khác;
không gộp vào E1, không mở thêm trận. Chưa build package.
[Closure và raw đã pin](artifacts/demon_target_gem_20261022/live2_20261022_012759/closure.json).

Lệnh mở đầu gặp lỗi tzdata của Python host và mở nhầm đường dẫn tùy chọn;
phiên nhầm đã đóng,0 Start/0 farm. Sau đó mở phiên đúng với cap2 đã kiểm tra.
Đây là lỗi lệnh launch bên ngoài ứng dụng, không sửa gameplay để xử lý nó.
