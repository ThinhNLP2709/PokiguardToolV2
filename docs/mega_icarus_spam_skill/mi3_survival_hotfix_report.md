# Mega Icarus — survival hotfix

Ngày kiểm tra: 2026-10-03
Nguồn lỗi: Farm run `36df492c89354c5c964451c34489d515`, match
`M_8becb84c`, source turn 77.

## Bằng chứng lỗi

- Người chơi còn `20.729/219.152 HP` (**9,46%**).
- Boss còn `298 Mana`.
- Mega Icarus đã đủ `3292 Mana / 177 Nộ` so với chi phí live
  `200 Mana / 150 Nộ`, và CardUI đang actionable.
- Kết Ấn chỉ có `5` Kiếm hiệu dụng, thấp hơn cấu hình `6`, nên nhánh fire
  bình thường chưa hợp lệ.
- Bàn có nhiều nước Kiếm hợp lệ. Nước tốt nhất ăn `4` ô, `5` Kiếm hiệu dụng
  và để lại `0` nước Kiếm đáp trả cho boss.
- Policy cũ cấm tự ăn Kiếm tuyệt đối trong setup, chọn một nước Mana và để lại
  `4` nước Kiếm trực tiếp cùng `2` nước Kiếm gián tiếp cho boss. Người chơi
  chết ngay sau đó.

## Rule sinh tồn mới

Rule chỉ áp dụng cho `Mega Icarus (Spam Skill)` khi HP đã biết và
`HP / maxHP <= 30%`. Nhánh tiến hóa dùng chung vẫn chạy trước nhánh này.

Thứ tự bắt buộc:

1. Nếu có bất kỳ nước ăn Kiếm nào, ăn nước Kiếm tốt nhất theo tiêu chí hiện
   có: tránh nước Kiếm đáp trả, lấy nhiều Kiếm hiệu dụng, rồi mới xét combo và
   rủi ro.
2. Nếu không có nước Kiếm, boss có Mana `> 0`, và có nước Máu, ăn Máu.
3. Nếu hai nhánh trên không dùng được, skill đã đủ chi phí live và CardUI đang
   actionable, click Mega Icarus ngay để hồi máu; bước này bỏ qua ngưỡng Kết
   Ấn nhưng không bỏ qua chi phí hoặc cooldown/actionability.
4. Nếu skill chưa thể dùng, policy tiếp tục qua luồng tài nguyên/setup hiện có.

Telemetry mới:

- `MEGA_ICARUS_SURVIVAL_SWORD`
- `MEGA_ICARUS_SURVIVAL_HEALTH`
- `MEGA_ICARUS_SURVIVAL_SKILL`
- fire trigger `MEGA_ICARUS_SURVIVAL_HEAL`

## Verification

- Replay nguyên bàn source turn 77 chọn đúng nước Kiếm sinh tồn, ăn `5` Kiếm
  hiệu dụng và để lại `0` nước Kiếm đáp trả.
- Test thứ tự Kiếm -> Máu khi boss có Mana -> skill hồi máu: PASS.
- Test boss không có Mana bỏ qua Máu và dùng skill: PASS.
- Test tiến hóa vẫn đứng trước nhánh sinh tồn: PASS.
- Mega Icarus targeted suite: **24/24 PASS**.
- Skill Rush regression suite: **65/65 PASS**.
- Full unittest discovery: **1.688/1.688 PASS**.
- `compileall` và `git diff --check`: **PASS**.
- Package `v1.2.0` đã rebuild và self-check production graph: **PASS**.
- SHA-256 package:
  `aafe434c1ca78d7f78b5641cb2f84a182fc3761dcfd4260e44ebda2ac2311039`.
