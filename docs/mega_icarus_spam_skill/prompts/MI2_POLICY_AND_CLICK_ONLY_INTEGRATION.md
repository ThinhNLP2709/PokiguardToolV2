# MI.2 — Mega Icarus Policy + Click-only Skill Integration

Implement and validate **MI.2 ONLY**.

## Entry gate

MI.1 phải `PASS STRONG`. Đọc README/STATUS/ROUTER, MI.1 report, policy Skill
Rush hiện tại, Pet Skill action executor và các test liên quan. Không suy đoán
runtime cost hoặc QTE từ ảnh.

## Goal

Tái sử dụng policy `Chịu đấm ăn xôi` với condition chỉ trong Kết Ấn và thêm
đường thực thi thẻ click-only, không làm thay đổi Skill Rush V2/V3 hiện có.

## Policy contract

1. Evolution vẫn là nhánh đầu tiên:
   - `Normal + Mega evolution`: tích đủ mana, evolve, đọc lại state, rồi dùng
     Mega skill source;
   - `Mega + Normal evolution`: evolve theo cấu hình nhưng Mega main skill vẫn
     là skill source;
   - `Mega + None`: không evolve.
2. Dùng resource requirement live. `required_rage = 0` không được biến thành
   thiếu Nộ giả.
3. Resource stage tái sử dụng thứ tự đã accepted:
   Mana/Nộ đang thiếu -> Hút -> Khiên -> safe turnover -> bounded risk/PASS.
   Giữ cấm tự ăn Kiếm trước skill và giới hạn PASS hiện có.
4. Count condition dùng effective count trong 30 ô Kết Ấn; x2/x3 được cộng đầy
   đủ. Gem cùng loại ngoài mask không có credit.
5. Setup không tự ăn Kiếm. Nếu có nước không để boss ăn Kiếm thì chỉ chọn trong
   nhóm đó, rồi tối đa hóa effective count trong Kết Ấn. Nếu mọi nước đều có
   rủi ro, giảm lượng Kiếm hiệu dụng boss có thể ăn trước, sau đó mới xét tiến
   độ Kết Ấn và các tie-break khác. Không dùng global gem count để fire/setup.
6. Khi resource + condition + CardUI cùng ready, trả `PET_SKILL` ngay; không
   chen một swap bảo toàn.
7. Nếu boss sống sau skill, quay lại chu kỳ resource/setup/skill. Không dùng
   default-Attack hoặc Sword finisher của Skill Rush cũ.
8. Log riêng `MEGA_ICARUS_*`: resource, setup, fire; ghi selected condition,
   seal physical/effective count, threshold, live resource costs và source.

Ưu tiên refactor helper dùng chung có tham số scope; không copy toàn bộ Skill
Rush thành một khối thứ hai. Test Skill Rush cũ phải chứng minh không đổi.

## Click-only action contract

- giữ exact card/session/turn/geometry/actionability preflight;
- click card tối đa một lần;
- không acquire/run direction assist; không gửi Arrow/Space;
- không chờ QTE generation;
- sau click chờ fresh authoritative transition: combat kết thúc, source turn
  chuyển, resources/card/actionability thay đổi nhất quán hoặc post-skill state
  đã được controller hiện có chấp nhận;
- success identity riêng, ví dụ `SUCCESS_NO_ACTION`, với telemetry
  `cardClicks=1`, `directions=0`, `space=0`;
- timeout/ambiguity sau click là unconfirmed fail-closed và không retry cùng
  source turn;
- lease Beta nếu dùng chỉ giữ mouse qua card click; không khóa keyboard/QTE;
- V2/V3 action path giữ nguyên bit-for-bit về hành vi.

## Tests

### Policy

- thiếu Mana nhưng Rage đủ; thiếu Rage nhưng Mana đủ; `required_rage=0`;
- Mana/Nộ progress thắng Hút/Khiên; hết progress thì Hút thắng Khiên;
- 10 gem global nhưng 9 trong seal không fire;
- effective count trong seal đạt 10 fire ngay, gồm hệ số x2/x3;
- setup tăng count trong seal thắng nước chỉ tăng ngoài seal;
- setup an toàn không chừa nước Kiếm cho boss thắng setup gain cao nhưng rủi ro;
- khi không có nước an toàn, setup chọn lượng Kiếm hiệu dụng boss ăn ít nhất;
- không tự ăn Kiếm; risk/PASS vẫn bounded;
- cả ba loadout hợp lệ đi đúng evolution/source route;
- skill thứ nhất không kill -> resource/setup/skill lần hai;
- không rò post-skill finisher cũ.

### Action

- một click, zero direction, zero Space, zero QTE wait;
- confirmed resource/turn/card transition -> success;
- combat end sau click -> success;
- stale/wrong card/session/turn/geometry -> zero input;
- click đã gửi nhưng transition timeout -> no retry/unconfirmed;
- stop/shutdown cleanup;
- V2/V3 regression giữ nguyên.

Chạy targeted tests, full unittest suite, compileall và `git diff --check`.

## Out of scope

- navigation, re-entry, stop UX, pin/window lease redesign;
- benchmark/soak/package/build;
- generic support cho mọi Mega pet;
- sửa BASIC/Demon/Skill Rush ngoài refactor có regression proof;
- commit/push.

## PASS STRONG

- offline policy/action contract pass;
- full suite sạch;
- tạo `mi2_report.md`, cập nhật STATUS sang MI.3;
- STOP, không tự live test hoặc bắt đầu MI.3.
