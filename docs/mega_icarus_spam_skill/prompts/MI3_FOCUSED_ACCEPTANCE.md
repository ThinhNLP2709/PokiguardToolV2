# MI.3 — Mega Icarus Focused Acceptance

Validate **MI.3 ONLY**. Người dùng tự điều khiển game/UI theo từng bài; agent
chỉ mở tool khi được yêu cầu, hướng dẫn và đọc log sau khi user báo đã xong.

## Entry gate

MI.1 và MI.2 `PASS STRONG`; cùng source tree và full suite sạch. Đọc hai report
và không dùng log cũ của Skill Rush/Demon làm bằng chứng Mega Icarus.

## B1 — UI/config

Chọn `Mega Icarus (Spam Skill)` và xác nhận mặc định:

- `Mega / Không tiến hóa`;
- `Thẻ skill của pet`;
- `Hành động skill: Không có`;
- `Kiếm đủ >= 10`.

Save, đóng/mở tool, xác nhận persistence. Kiểm tra thêm UI matrix:

- Mega chỉ chọn None/Normal evolution;
- Normal buộc Mega evolution;
- damage/action không đổi được sang mode khác.

B1 không Start game.

## B2 — một trận default Mega/None

Người dùng vào đúng boss lobby rồi Start một trận. Không thao tác combat.
Log phải chứng minh:

- resource requirements lấy từ live card, không từ default hard-code;
- trước fire, condition selected là Sword và `sealEffective >= 10`, có tính
  hệ số x2/x3;
- gem ngoài seal không được cộng;
- setup không tự ăn Kiếm; ưu tiên nước không để boss ăn Kiếm, nếu không có thì
  giảm lượng Kiếm hiệu dụng boss có thể ăn xuống thấp nhất;
- đúng một card click;
- zero Arrow, zero Space, zero QTE wait/attempt;
- action được xác nhận bằng fresh turn/resource/card/combat transition;
- nếu boss sống, policy quay lại resource/setup và có thể fire lần hai;
- không default-Attack/Sword finisher;
- không stale/duplicate/wrong-turn/postmatch input.

Một kết quả thắng/thua hợp lệ đều được chấp nhận cho logic vì mục tiêu là boss
mới; kết quả trận không thay thế các invariant trên.

## B3 — route Normal -> Mega evolution

Chạy một trận với `Pet thường / Tiến hóa pet Mega` nếu loadout thật sẵn có.
Xác nhận evolution ưu tiên trước, fresh reread, rồi click-only Mega skill đúng
source. Nếu tài khoản chưa có loadout cần thiết, ghi `NOT_OBSERVED` và dùng test
deterministic MI.2; không giả lập thành live PASS.

Không cần live riêng cho `Mega / Tiến hóa pet thường` nếu B1 validation và
offline evolution/source tests đã pass; chỉ chạy khi evidence B2/B3 phát hiện
vấn đề nguồn skill.

## Acceptance

- B1 pass;
- B2 pass toàn bộ invariants click-only/Kết Ấn;
- B3 pass hoặc `NOT_OBSERVED` có lý do và offline proof tương ứng;
- targeted analyzer/tests và full suite vẫn pass sau mọi remediation;
- không có regression V2/V3, Skill Rush hoặc Demon Aegis;
- tạo `mi3_report.md`, cập nhật STATUS thành `MINI-PLAN COMPLETE`.

## Explicit exclusions

Không test target nhiều trận, re-entry, empty room, stop/resume, emergency stop,
pinned foreground A/B, performance, package hoặc release. Đó là vận hành tool,
không thuộc acceptance của lối chơi này.

Sau `PASS STRONG`, STOP và chờ user yêu cầu chốt/commit/push.
