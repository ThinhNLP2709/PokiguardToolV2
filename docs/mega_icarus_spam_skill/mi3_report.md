# MI.3 — Mega Icarus focused acceptance report

Ngày kiểm tra: 2026-10-02
Kết quả: **PASS STRONG — MINI-PLAN COMPLETE**

## B1 — UI/config

- Mặc định của lối chơi được xác nhận là
  `Mega / Không tiến hóa / Thẻ skill của pet / Không có / Kiếm đủ / 10`.
- Save và mở lại giữ đúng cấu hình.
- Ma trận UI chỉ cho phép ba loadout hợp lệ của Mega Icarus; damage card và
  hành động skill không đổi sang mode khác.

## B2 — Mega / Không tiến hóa

Live retry `73c817c6f6bd4ad298fb2b47c9748ffa`, match `M_b11eb7b6`:

- WIN trong 10 lượt/năng lượng;
- dùng chi phí của thẻ live;
- setup Kết Ấn tăng từ 4 lên 8 rồi 10 Kiếm hiệu dụng và fire ngay khi đạt
  ngưỡng;
- đúng 1 click thẻ, 0 Arrow, 0 Space và không có QTE attempt;
- combat terminal xác nhận skill giết boss ngay;
- không có stale, duplicate, wrong-turn hoặc postmatch gameplay input.

Remediation từ B2 đã bổ sung durable seal floor, so sánh PASS với nước setup
và ưu tiên turnover trong Kết Ấn. Chi tiết và replay nằm trong
`mi3_b2_optimization_report.md`.

## B3 — Pet thường / Tiến hóa pet Mega

Farm run `148448d6edb1470eb39806df412221cd`, match `M_30504037`:

- profile authoritative đúng
  `normal / mega / pet_skill`, `audition_mode=none`;
- WIN, 17 lượt/năng lượng, 15 swap, 1 PASS và 1 Pet Skill;
- tiến hóa luôn được ưu tiên khi đủ 120 Mana. Ba lần đầu game trả
  `EVOLVE_FAILED`; mỗi lần tool chờ settle 3,5 giây, bắt buộc đọc state mới và
  tích lại Mana trước lần thử kế tiếp. Lần thứ tư trả `EVOLVE_SUCCESS`;
- tiến hóa không tiêu lượt. Sau thành công ở source turn 15, fresh reread nhận
  đúng `skillSource=EVOLUTION_TARGET`, `skillFamily=MEGA_ICARUS_CLICK_ONLY`,
  `skillCardId=22` và chi phí live mới `200 Mana / 150 Nộ`;
- policy tiếp tục tích đúng phần tài nguyên còn thiếu rồi setup Kết Ấn;
- fire ở source turn 33 với 5 ô Kiếm trong Kết Ấn có tổng hiệu dụng 10,
  đúng ngưỡng cấu hình `>= 10`. Tổng toàn bàn khi đó là 13 ô/24 hiệu dụng,
  nhưng readiness chỉ dùng 30 ô Kết Ấn;
- executor gửi đúng 1 card click, 0 Arrow và 0 Space. Presentation chuyển
  trạng thái trước khi post-click QTE probe đọc được nên action ban đầu được
  giữ ở trạng thái uncertain; terminal resolver sau đó xác nhận
  `COMBAT_TERMINAL`, `immediateSkillKill=true`, boss HP về 0 và không retry
  click;
- không có input sai lượt, duplicate, stale, lobby/postmatch gameplay input
  hoặc technical abort.

Ba `EVOLVE_FAILED` là kết quả authoritative của từng lần tiến hóa trong game,
không phải click mù: mỗi lần có source turn riêng, đủ Mana trước click, Mana bị
game tiêu, settle hoàn tất và policy chỉ hành động tiếp trên state mới.

## Verification

- Mega Icarus policy: **19/19 PASS**.
- Targeted board simulator/policy regression: **103/103 PASS**.
- Full unittest discovery sau remediation cuối: **1.674/1.674 PASS**.
- `py_compile`: **PASS**.
- `git diff --check`: **PASS**.
- B1, B2 và B3 đều có bằng chứng đúng phạm vi; MI.3 đạt `PASS STRONG`.

## Live bổ sung — boss mạnh và cooldown một lượt

Farm run `d17059c75e384777827c8a6082d2347a`, match `M_fa43023d`:

- WIN sau 26 lượt local; Mega Icarus được click 8 lần vì boss sống qua nhiều
  skill;
- các source turn fire là `21, 25, 31, 35, 39, 43, 47, 51`;
- khoảng cách giữa hai lần fire liên tiếp là `4, 6, 4, 4, 4, 4, 4` theo turn
  toàn trận. Vì local turn tăng cách 2, mọi cặp fire đều có ít nhất một local
  turn ở giữa để countdown;
- các local turn ngay sau skill (`23, 27, 33, 37, 41, 45, 49`) đều đi
  swap/resource/setup, không click skill;
- source turn 35 có hai lần policy/dispatch vì preflight đầu trả 0 card click;
  lần thứ hai mới gửi đúng 1 click, nên không có double click;
- tổng cộng 8 card click, 0 Arrow và 0 Space. Lần cuối kết thúc combat với
  boss HP bằng 0.

Run này xác nhận policy tôn trọng countdown một lượt của thẻ: card chỉ được
fire lại sau khi đã đi qua một local turn trung gian và capability live trở
lại actionable.

Mini-plan Mega Icarus hoàn tất. Không build, package, commit hoặc push trong
MI.3; các thao tác chốt repository chờ yêu cầu riêng của người dùng.
