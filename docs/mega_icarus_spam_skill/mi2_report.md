# MI.2 — Mega Icarus policy + click-only report

Ngày kiểm tra: 2026-10-01
Kết quả: **PASS STRONG**

## Policy đã nối

- Ba loadout hợp lệ giữ nhánh tiến hóa ở đầu policy:
  - `Mega / Không tiến hóa` dùng skill của pet chính;
  - `Mega / Tiến hóa pet thường` tiến hóa trước, rồi vẫn dùng skill Mega của
    pet chính;
  - `Pet thường / Tiến hóa pet Mega` tiến hóa trước, đọc lại state và dùng
    skill Mega của pet tiến hóa.
- Chi phí Mana/Nộ lấy từ capability live. `required_rage = 0` là một chi phí
  hợp lệ và không tạo thiếu Nộ giả.
- Chu kỳ tài nguyên tái sử dụng thứ tự đã chấp nhận của `Chịu đấm ăn xôi`:
  Mana/Nộ còn thiếu, Hút, Khiên, nước chuyển bàn an toàn, rồi mới tới rủi ro
  giới hạn hoặc PASS. Policy vẫn không chủ động ăn Kiếm và PASS vẫn bị chặn ở
  giới hạn lượt hiện có.
- Điều kiện đếm gem chỉ dùng effective count trong đúng 30 ô Kết Ấn. Gem ngoài
  vùng không được cộng; hệ số x2/x3 đóng góp đầy đủ vào readiness.
- Khi chưa đủ điều kiện, setup không tự ăn Kiếm. Nước không để boss ăn Kiếm
  được ưu tiên trước; trong nhóm đó policy tối đa hóa effective count trong
  Kết Ấn. Nếu mọi nước đều có rủi ro, policy giảm lượng Kiếm hiệu dụng boss có
  thể ăn trước rồi mới xét tiến độ Kết Ấn và các tie-break còn lại.
- Khi tài nguyên, điều kiện và CardUI đều sẵn sàng, policy trả
  `MEGA_ICARUS_FIRE` ngay. Nếu boss còn sống, policy quay lại chu kỳ tài
  nguyên/setup/skill và không đi vào nhánh Sword/default-Attack finisher của
  Skill Rush.
- Log riêng `mega_icarus_resource`, `mega_icarus_setup` và
  `mega_icarus_fire` mang condition, phạm vi Kết Ấn, physical/effective count,
  threshold, chi phí/tài nguyên live, nguồn skill và nước được chọn.

## Action click-only

- Bổ sung family `MEGA_ICARUS_CLICK_ONLY` và kết quả riêng
  `SUCCESS_NO_ACTION`.
- Executor giữ nguyên preflight session/turn/card/geometry/actionability, click
  đúng một lần rồi chuyển thẳng sang đọc post-state.
- Mode `Không có` không arm direction assist, không gửi Arrow/Space và không
  chờ QTE generation.
- Success chỉ được xác nhận bởi post-state fresh có combat kết thúc hoặc chuyển
  trạng thái authoritative ở board/turn/resource/card/actionability. Timeout
  sau click trả unconfirmed fail-closed có `NO_RETRY`.
- Telemetry kết quả ghi `card_clicks=1`, `direction_presses=0`,
  `space_presses=0`.
- Ở transport Beta, mouse lease chỉ được giữ tới lúc click thẻ được gửi rồi
  nhả; không chuyển sang keyboard/QTE guard. Luồng Audition V2/V3 vẫn dùng
  state machine cũ.

## Bằng chứng test

- Regression mục tiêu policy/config/action/UI/pinned input: **208/208 PASS**.
- Full unittest discovery: **1.653/1.653 PASS**.
- `python -m compileall -q src tools tests`: **PASS**.
- `git diff --check`: **PASS**.

Không mở/đóng tool, không điều khiển game, không live test, build, package,
commit hoặc push trong MI.2. Phiên farm đang chạy của người dùng không bị tác
động. Live acceptance tiếp theo thuộc MI.3.

## MI.3 remediation — 2026-10-02

Live B2 đầu tiên phát hiện contract physical count và thứ tự setup cũ không
đúng yêu cầu thực tế. Log `3c22a7ff766a45e3be8da5248b9759a7` chứng minh ở
nhiều lượt `sealEffective >= 10` nhưng policy vẫn tiếp tục swap, đồng thời nhánh
Mega setup đã bỏ qua pool `sword_risk.safe`. Contract và implementation phía
trên đã được cập nhật theo effective count và bảo vệ Kiếm khỏi lượt boss; B2
cần retry trước khi MI.3 được chấp nhận.
