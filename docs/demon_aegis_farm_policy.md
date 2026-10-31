# Demon Farm

## BASIC hiện tại — Kiếm hiệu dụng, 2026-10-22

Sau khi người dùng xác nhận, ngưỡng Kiếm của BASIC tính **tổng multiplier** trong
vùng phá, không dùng số ô làm ngưỡng nữa. Setting4 nhận x2+x1+x1 hoặc x3+x1;
vẫn cần tối thiểu2ô Kiếm thực tế. Xếp hạng và forecast setup cùng dùng tổng
hiệu dụng trước số ô. Áp dụng cả5 Viên mục tiêu. Không đổi reader/flow/input.
[Bản sửa và159 tests PASS](demon_effective_sword_fix_20261022.md).
Các mô tả ngưỡng vật lý bên dưới là lịch sử trước bản sửa này.

## Cập nhật 2026-10-22 — Viên mục tiêu

Tên hiển thị đổi thành **Demon Farm**; ID cấu hình `demon_aegis_farm` giữ nguyên
để đọc được tùy chọn và checkpoint cũ. Thêm dropdown **Viên mục tiêu:** chỉ hiện
khi chọn Demon Farm, gồm **Khiên, Máu, Mana, Hút, Nộ**, không có Kiếm.
Mặc định là **Khiên**; file cũ thiếu trường `demon_target_gem` cũng dùng Khiên.

Loại viên đã chọn thay Khiên trong nhận diện chuỗi kích hoạt, vùng phá ngang/dọc,
dự báo kích hoạt lượt kế tiếp và ưu tiên giữ viên để setup. Vùng phá vẫn dùng
cùng quy tắc hình học hiện có, không tự suy đoán nội tại từ tên pet. Ngưỡng Kiếm,
phân biệt Kiếm vật lý/multiplier, ưu tiên sinh tồn và PASS bắt buộc giữ nguyên.
Khiên/Máu vẫn là tài nguyên sinh tồn dù chọn loại viên kích hoạt khác.

Trường này được lưu, nạp lại, chuyển tới FarmRunner/policy và khóa cùng cấu hình
khi đang chạy. Không đổi thứ tự đọc memory, chụp ảnh, input, QTE hoặc hậu trận.
Nhánh shadow/replay nhận loại viên đã chọn. Certificate REASONING D3 đã đo riêng
với Demon Aegis/Khiên không được dùng cho loại viên khác; khi không có authority
phù hợp vẫn giữ BASIC. Live mặc định Khiên đã WIN2/2 trên Lieyun77, có setup và
lượt kế tiếp; bốn target khác chưa live. Chưa build package mới.

Các phần dưới là hồ sơ lịch sử khi chỉ hỗ trợ Khiên; không mở rộng kết luận live
đó sang bốn lựa chọn mới. Chi tiết: [báo cáo thay đổi](demon_target_gem_update_20261022.md).

## Phạm vi cấu hình

- Lối chơi: `Demon Aegis Farm`.
- Pet của tôi: `Pet thường` (cố định).
- Tiến hóa: `Không tiến hóa` (cố định).
- Thẻ sát thương: `Nội tại pet` (chỉ khả dụng trong lối chơi này).
- Điều kiện: `Kiếm đủ`, so sánh bao hàm `>=`, mặc định `3`.

Tool chưa có một trường tên pet chính ổn định tại biên policy của mọi lượt. Vì
vậy bản đầu chưa khóa tên `Demon Aegis`; cấu hình pet và hành vi nội tại vẫn bị
khóa chặt. Không suy đoán tên pet từ boss hoặc thẻ skill.

## Mô hình nội tại

Tọa độ board trong code là zero-based `(row, col)`:

- match Khiên theo hàng ngang: mỗi Khiên trong chuỗi quét trọn cột của nó;
- match Khiên theo cột dọc: mỗi Khiên trong chuỗi quét trọn hàng của nó;
- match hình chữ thập áp dụng hợp của cả hai vùng và không đếm trùng giao điểm;
- ô `UNKNOWN` không được tính là Kiếm;
- điều kiện dùng số **ô Kiếm vật lý** trong vùng quét;
- multiplier x2..x7 được cộng riêng vào `sword_effective` để xếp hạng sát
  thương, không làm một ô Kiếm biến thành nhiều ô cho điều kiện `>= 3`.

## Thứ tự quyết định

1. Nếu có match Khiên quét ít nhất ngưỡng Kiếm, chọn nước có nhiều ô Kiếm bị
   quét nhất; `sword_effective` là tie-break tiếp theo.
2. Nếu chưa có nước đạt ngưỡng, chọn nước không ăn Kiếm và không kích hoạt Khiên
   sớm để tạo một match Khiên tốt ở lượt kế tiếp. Solver kiểm tra hình học một
   lượt nhìn trước trên kết quả đã mô phỏng.
3. Ưu tiên nước an toàn. Khi không có nước an toàn và HP trên 30%, cho phép nước
   setup để lại cơ hội Kiếm cho boss, theo đúng phạm vi rủi ro của chiến thuật.
4. Khi HP thấp hoặc chưa rõ, ưu tiên Khiên/Máu. PASS chỉ là lựa chọn cuối cùng
   và chỉ dùng khi trạng thái pass do game sở hữu xác nhận chưa chạm giới hạn hai
   lượt liên tiếp.
5. Không bao giờ chọn nước có match Kiếm hoặc cascade Kiếm do swap thông thường.
   Kiếm dùng để gây sát thương phải nằm trong vùng quét của nội tại.

`Nội tại pet` không đi qua luồng click thẻ hoặc QTE. Quyết định cuối cùng luôn là
một swap bàn cờ thông thường và tiếp tục dùng input executor hiện có.

## Xác nhận live

### B1 — một trận

- Run `ed5c55615cb64c1888693d19f93631c3`: **1/1 thắng**.
- Nhánh `DEMON_AEGIS_PASSIVE_FIRE` ăn 3 Khiên, vùng nội tại chứa 6 Kiếm và
  kết thúc boss ngay lượt đầu.
- Tiêu hao 1 năng lượng; không dùng thẻ, QTE, tiến hóa hoặc PASS.

### B2 — năm trận liên tục

- Run `e4b09940aa9a4f40baf8a8db54a119b9`: **5/5 thắng**, 5 kết quả đều có
  bằng chứng `STRONG` và nhất quán với giao diện hậu trận.
- Tổng 8 lượt/năng lượng: `1, 2, 1, 1, 3`; không có technical abort,
  recovery, safe stop hoặc PASS.
- Ba trận kích hoạt nội tại ngay lượt đầu. Hai trận còn lại bao phủ
  `DEMON_AEGIS_SETUP_RISK_ACCEPTED`; trận cuối đồng thời bao phủ
  `DEMON_AEGIS_SETUP` trước khi kích hoạt nội tại.
- Số Kiếm vật lý trong vùng phá tại năm nước kết liễu lần lượt là
  `3, 4, 4, 4, 3`, đều thỏa điều kiện bao hàm `>= 3`.
- Không quyết định nào trực tiếp match/cascade Kiếm. Telemetry an toàn ghi nhận
  0 click trùng, click sai, input thiếu, sai lượt, stale action, input ở lượt
  boss, hậu trận hoặc ngoài chiến đấu.

Kết quả B1 và B2 chấp nhận lối chơi cho phạm vi live ban đầu. Việc xác minh tên
pet vẫn để mở cho tới khi runtime cung cấp danh tính pet chính ổn định.

## Phase 5A.2 REASONING — đặc tả bổ sung, chưa triển khai

Các thứ tự/ngưỡng trên mô tả BASIC tại thời điểm report. Default3 Kiếm vật lý
không đổi; người dùng đang dùng setting4 là cấu hình cá nhân. Accepted b6
[addendum](board_resolution.md) sau đó có mandatory least-consuming Sword
fallback để tránh third idle; không dùng câu “không bao giờ” ở report cũ để
xóa fallback đó. Bước5A.2 không sửa BASIC hoặc khẳng định regression runtime.

REASONING được cân nhắc3 Kiếm khi đủ Nộ theo calibration đúng account/context,
gồm ví dụ3 Kiếm+5 viên Nộ x1 trong vùng sweep (Nộ20/viên, Mana30/viên theo
khai báo người dùng). Physical/effective/point gain tách riêng. Joint-burst
calibration có dependency effect order; không universal damage formula hoặc
rule cứng thay4 bằng3. Match Khiên vẫn quét cột/hàng theo orientation, action
vẫn ordinary SWAP qua executor cũ, không click thẻ/QTE.

Setup phải được đánh giá sau reply boss. Nominal Sword-first/max effective
Sword là working model từ khai báo người dùng, giữ mọi tie và secondary
priority UNKNOWN. Chừa Kiếm làm mồi có thể giúp giữ Khiên cho ta; boss damage,
tie phá Khiên và refill uncertainty phải vào comparison. Chỉ thực thi root,
fresh turn replan. Không credit Khiên chỉ vì nó tồn tại trước lượt boss.

Chi tiết: [5A.2 features/utility](phase5/specs/5a2_features_utility_and_profiles.md),
[D01–D09/O01–O09 design cases](phase5/specs/5a2_scenario_matrix.md).
Narrow live calibration/contested setup giao5D.3; chưa test/live ở bước này.

### 5D.3 — xác nhận người dùng ngày2026-10-18

Boss được chọn làLieyun lv77;pet của người chơi vẫnDemon Aegis thường.
Tài khoản hiện tại dùng BASIC4ôKiếm vì ATK thấp. Người dùng xác nhận nhánh
REASONING3ôKiếm+đủ100Nộ,ví dụ5viênNộx1 thực sự nằm trong vùng phá khả dụng.
Account khác đang đủ sát thương ở3có thể có certificate2Kiếm+đủNộ trong
scope riêng. Không certificate kết liễu dưới2ôKiếm vật lý theo yêu cầu user;
multiplier không thay physical count. Đây là calibration/yêu cầu thiết kế,
chưa là native verification hoặc thay đổi BASIC trong báo cáo này.

Chính vẫn là setup qua lượt boss,retained Shield,bait và HP/resource/risk
trade-off;không thay planner bằng một rule“3+5”. Xem
[spec cập nhật](phase5/specs/5a2_features_utility_and_profiles.md),
[5D.3 report](phase5/reports/5d3_report.md).


## Phase 5D.3 minimum opt-in — 2026-10-18

BASIC và default đếm ô Kiếm vật lý ở trên giữ nguyên. Nhánh REASONING source-only
hiện có minimum model riêng của account/Lieyun77/loadout/static stats:
3physicalSword với preexistingRage>=100; hoặc effectiveSword>=4, floor2physical.
Multiplier được tính trong effective, không đổi số physical. MộtSwordx4/x7
không được nhận certificate. Đây là USER_CALIBRATED, không damage formula.
Không suy ngưỡng setting-minus-one hoặc mượn certificate cho account khác.

Replay native board và fake controller/input/ACK đã qua offline; phần native
REASONING3 còn PENDING, chưa request/claim/Start. Không claim thông minh setup/
bait hoặc same-burst order từ minimum scope. Chi tiết và trạng thái cập nhật tại
[5D.3report](phase5/reports/5d3_report.md).


### Native D3 control+reasoning closure — 2026-10-18

3BASIC+3REASONING đãđóng6/6attempt,6WIN. Nhánhminimum3physicalSwordvới
preexistingRage150 đãthaynướcHútcủaBASICtạiM_f0d27218/turn5,vàsameturn
terminalbossHP0/WIN. Cóexactsent,khôngACKriêngchoterminalswap;khôngderive
formula hoặcclaimexact100native. Nhánheffective4below4physical đãPASSreplay
nativeboards,nhưng0qualifyingcandidate trongREASONING3 nênNOT_OBSERVEDlive.
BASIC/default/flowunchanged;khôngtăngcapđểépcoverage. [D3gate](phase5/artifacts/5d3_lieyun_reasoning3_live_20261018_024336/gate_decision.json).
