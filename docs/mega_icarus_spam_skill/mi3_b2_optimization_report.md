# MI.3 B2 — Setup optimization remediation

Trạng thái: **LIVE B2 RETRY PASS**

## Bằng chứng live

- Farm run: `dda74f4f66064188bc94649757a3d74a`.
- Match: `M_cc8e389e`.
- Kết quả: WIN, 27 lượt/năng lượng, 26 swap, 1 skill, 0 PASS.
- Tài nguyên đã đủ ở lượt local thứ 7 (`210 Mana / 222 Nộ`), sau đó mất 20
  lượt setup mới fire.
- Ở source turn 43, nước cũ đưa Kết Ấn từ 7 lên 10 hiệu dụng nhưng mở một
  phản hồi Kiếm x5 cho boss; lượt kế tiếp chỉ còn 6. Bàn trước swap không có
  nước Kiếm đã biết, nên PASS bảo toàn tốt hơn.

## Remediation

- Mô phỏng từng phản hồi Kiếm đã biết của boss trên result board và tính
  `sealEffectiveAfterWorstBossReply`.
- Đánh giá riêng baseline nếu PASS trên bàn hiện tại: `passSealFloor`,
  `passBossSwordMax`, `passBossSwordReplies`.
- Chỉ PASS khi baseline giữ nguyên bàn tốt hơn nước setup rủi ro tốt nhất và
  game-owned idle state xác nhận PASS hợp lệ.
- Nếu bàn hiện tại đã có nước Kiếm, swap phá hoặc giảm thiệt hại vẫn được chọn.
- Không cho phép PASS thứ ba; lúc đó dùng nước bắt buộc tốt nhất.
- Trong các nước setup an toàn tương đương, ưu tiên chuyển động và clear trong
  30 ô Kết Ấn để tăng cơ hội refill hữu ích.
- Nước chạm ngưỡng được ưu tiên đặc biệt khi vẫn đạt ngưỡng sau phản hồi xấu
  nhất của boss (`DURABLE_THRESHOLD`).

## Replay trận lỗi

- Source turn 13: giữ SWAP; PASS có floor 3, swap có floor 4.
- Source turn 19: giữ SWAP; nước hiện tại của boss có thể lấy x5, swap giảm
  xuống x4 và giữ floor cao hơn.
- Source turn 31: đổi thành PASS vì swap chỉ thêm rủi ro refill chưa biết mà
  không tăng floor.
- Source turn 43: đổi thành PASS; pass floor 7, swap cũ floor 6 sau phản hồi x5.
- Source turn 51: vẫn SWAP; tạo 12 Kiếm hiệu dụng bền vững và fire lượt sau.

Replay chỉ chứng minh quyết định policy trên các snapshot cũ; không suy diễn
thành kết quả live mới vì refill và lựa chọn của boss có thể khác.

## Verification

- Mega Icarus policy: 18/18 PASS.
- Board simulator + Mega Icarus + Skill Rush regression: 102/102 PASS.
- Full unittest discovery: 1.674/1.674 PASS after the safe-setup remediation.
- `py_compile`: PASS.
- `git diff --check`: PASS.
- Replay benchmark 20 snapshot setup thật, gồm solver và ranking mới: trung bình
  16,00 ms, median 14,53 ms, cao nhất 32,82 ms; không tạo độ trễ cấp giây.

## Live gate còn lại

Live retry `73c817c6f6bd4ad298fb2b47c9748ffa` / `M_b11eb7b6`:

- WIN trong 10 lượt/năng lượng và 126,235 giây;
- đủ tài nguyên ở lượt local thứ 5, sau đó toàn bộ setup được chứng minh
  Sword-safe với `sealEffectiveAfterWorstBossReply == sealEffectiveAfter`;
- từ 4 effective tăng lên 8 rồi 10; fire ngay đầu lượt đạt 10;
- đúng 1 card click, 0 Arrow, 0 Space, không QTE attempt;
- boss 219.468 HP trước click và kết thúc ở 0 HP;
- 0 PASS vì không snapshot nào cần đánh đổi giữa PASS và setup rủi ro;
- không stale/duplicate gameplay input; source turn được đóng bằng combat
  terminal và `immediateSkillKill=true`.

Nhánh click-only ghi nhận post-click control rejection khi presentation đã
busy, nhưng source turn được terminal resolver xác nhận là skill kill; không có
input fallback hoặc retry và không ảnh hưởng kết quả.

Live repeat `62140c1dd21d4c888e0ed2baee57d4c2` / `M_c65b6f1a` không phải B3:
profile vẫn là `Mega / Không tiến hóa / Pet Skill`, `skillSource=MAIN_PET` và
không có evolution attempt. Trận thắng trong 17 năng lượng. Source turn 11
phát hiện một khoảng hở còn lại: setup được gắn `SWORD_SAFE` nhưng làm seal
floor giảm từ 7 xuống 6 trong khi PASS giữ nguyên 7 và không chừa nước Kiếm.
So sánh PASS đã được mở rộng cho mọi non-Sword setup; nếu floor bằng nhau thì
swap turnover vẫn được ưu tiên, còn PASS chỉ thắng khi bảo toàn floor tốt hơn.

Sau remediation safe-setup: Mega Icarus policy 19/19 và targeted
policy/simulator 103/103 PASS.
