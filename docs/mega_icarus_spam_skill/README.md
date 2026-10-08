# Mini-plan — Mega Icarus (Spam Skill)

Trạng thái: **MINI-PLAN COMPLETE — MI.3 PASS STRONG**.

Đây là một mini-feature độc lập sau Phase 4, không mở một phase roadmap mới.
Mỗi prompt chỉ được chạy khi prompt trước đạt `PASS STRONG`. Không build,
package, tag hoặc kiểm tra các luồng vận hành FarmRunner như re-entry, stop,
pinned foreground hay soak dài trong mini-plan này.

## Mục tiêu

Thêm lối chơi `Mega Icarus (Spam Skill)` để đánh và thu phục boss mới bằng
việc lặp lại đúng chu kỳ:

1. tích đúng Mana/Nộ mà **thẻ live** yêu cầu;
2. nếu chưa có nước tiến tài nguyên thì ưu tiên Hút rồi Khiên để bảo vệ tài
   nguyên, giữ nguyên logic đã chấp nhận của `Chịu đấm ăn xôi`;
3. setup đủ điều kiện đã chọn **bên trong vùng Kết Ấn**;
4. click thẻ đúng một lần; skill này không có Audition/QTE;
5. nếu boss còn sống, quay lại bước 1 thay vì dùng nhánh finisher của Skill
   Rush cũ.

Không hard-code chi phí `200 Mana / 150 Nộ`. Đó là dữ liệu của Mega Icarus
hiện tại; policy phải dùng `required_mana` và `required_rage` đọc từ capability
live. Một thẻ Mega có `required_rage = 0` phải được xem là đủ khi Mana đạt yêu
cầu.

## Cấu hình cố định và hợp lệ

- Lối chơi: `Mega Icarus (Spam Skill)`.
- Pet của tôi:
  - `Mega` + `Không tiến hóa` hoặc `Tiến hóa pet thường`;
  - `Pet thường` chỉ hợp lệ với `Tiến hóa pet Mega`.
- Mặc định khi chọn lối chơi: `Mega / Không tiến hóa`.
- Thẻ sát thương: `Thẻ skill của pet`, cố định.
- Hành động skill: `Không có`, cố định.
- Điều kiện ra skill: giữ toàn bộ lựa chọn hiện có; mặc định `Kiếm đủ`, giá trị
  mặc định `10`.
- `Đủ mana skill` dùng readiness thực tế của thẻ và không cần điều kiện board.
- Các điều kiện đếm gem dùng so sánh bao hàm `>=` và chỉ đếm trong Kết Ấn.

`Mega` và `Tiến hóa pet Mega` chỉ được mở cho profile này trong mini-feature.
Không nới `SUPPORTED_MAIN_PETS`/`SUPPORTED_EVOLUTIONS` theo cách vô tình làm
các lối chơi cũ chấp nhận Mega.

## Hành động skill `Không có`

Giữ field persistence hiện tại `audition_mode` để tương thích checkpoint, nhưng
bổ sung một identity rõ ràng cho `Không có`. Ở mode này:

- vẫn cần CardUI/actionability/geometry/session/turn preflight hiện có;
- gửi đúng một click thẻ;
- gửi **0** phím hướng và **0** Space;
- không chờ QTE generation;
- chờ bằng chứng authoritative rằng card/turn/resources/combat đã chuyển trạng
  thái rồi mới cho phép hành động tiếp;
- nếu đã gửi click nhưng chưa xác nhận được kết quả thì fail closed và không
  click lại mù trong cùng source turn.

V2/V3 và executor QTE hiện tại phải giữ nguyên hành vi.

## Mặt nạ Kết Ấn

Danh sách người dùng cung cấp là `(cột:dòng)`, one-based. Ảnh xác nhận đúng 30
ô và không có ô ở dòng 8.

| Dòng | Cột one-based | `(row, col)` zero-based trong code |
|---:|---|---|
| 1 | 5 | `(0,4)` |
| 2 | 3, 4, 6 | `(1,2) (1,3) (1,5)` |
| 3 | 1, 3, 5, 6, 7 | `(2,0) (2,2) (2,4) (2,5) (2,6)` |
| 4 | 2, 3, 4, 5, 6, 7, 8 | `(3,1)..(3,7)` |
| 5 | 3, 4, 5, 6, 7 | `(4,2)..(4,6)` |
| 6 | 2, 3, 4, 5, 6 | `(5,1)..(5,5)` |
| 7 | 2, 3, 4, 6 | `(6,1) (6,2) (6,3) (6,5)` |

Canonical zero-based constant:

```text
((0,4),
 (1,2),(1,3),(1,5),
 (2,0),(2,2),(2,4),(2,5),(2,6),
 (3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),
 (4,2),(4,3),(4,4),(4,5),(4,6),
 (5,1),(5,2),(5,3),(5,4),(5,5),
 (6,1),(6,2),(6,3),(6,5))
```

Ngưỡng `10` dùng tổng **giá trị hiệu dụng** của gem đã chọn trong 30 ô. Viên
x2/x3 đã có trên board được cộng đúng hệ số; gem ngoài vùng và `UNKNOWN` không
được tính.

## Tái sử dụng Skill Rush

Không sao chép nguyên khối policy. Tách hoặc tham số hóa phần dùng chung của
`Chịu đấm ăn xôi`, giữ nguyên các invariant đã live-proven:

- tiến hóa hợp lệ luôn được xét trước và sau thành công phải đọc lại state;
- khi thiếu tài nguyên: Mana/Nộ cần thiết trước, sau đó Hút, Khiên, rồi nước
  an toàn/ít rủi ro; Hút được dùng vừa để có cơ hội hút tài nguyên vừa để không
  chừa Hút cho boss;
- không tự ăn Kiếm trước skill;
- PASS là cuối cùng và không bao giờ vượt giới hạn hai lượt liên tiếp;
- khi tài nguyên đủ nhưng điều kiện Kết Ấn chưa đủ, không tự ăn Kiếm và ưu tiên
  nước không để boss ăn Kiếm; trong nhóm an toàn tối đa hóa effective count
  **trong mặt nạ**, rồi ưu tiên nước tạo nhiều chuyển động/refill trong Kết Ấn;
- một nước vừa đưa Kết Ấn lên ngưỡng chỉ được xem là setup bền khi lượng Kiếm
  hiệu dụng vẫn đạt ngưỡng sau phản hồi Kiếm xấu nhất đã chứng minh của boss;
- nếu không có nước an toàn, so sánh nước rủi ro tốt nhất với việc giữ nguyên
  bàn và PASS. PASS chỉ thắng khi bảo toàn nhiều Kiếm hiệu dụng trong Kết Ấn
  hơn; nếu bàn hiện tại đã chừa Kiếm và một swap phá/giảm được nước đó thì vẫn
  phải swap. Trạng thái game-owned tiếp tục chặn lượt PASS thứ ba;
- khi condition và card cùng ready, click skill ngay, không đi thêm một swap;
- sau skill chưa kết thúc trận, reset về chu kỳ tích tài nguyên/setup tiếp theo;
  không kế thừa nhánh default-Attack/Sword finisher của Skill Rush.

## Phạm vi test

Mini-plan kiểm tra cấu hình, hình học Kết Ấn, policy và click-only action. Live
chỉ dùng để xác nhận một click thẻ Mega thật sự kích hoạt skill không QTE và
chu kỳ lặp nếu boss sống. Không kiểm tra navigation, re-entry, stop, window
lease, package, benchmark hoặc soak dài.

## Trình tự prompt

1. [MI.1 — Config + Kết Ấn contract](prompts/MI1_CONFIG_AND_SEAL_CONTRACT.md)
2. [MI.2 — Policy + click-only integration](prompts/MI2_POLICY_AND_CLICK_ONLY_INTEGRATION.md)
3. [MI.3 — Focused acceptance](prompts/MI3_FOCUSED_ACCEPTANCE.md)

Router và con trỏ hiện tại nằm trong [ROUTER.md](ROUTER.md) và
[STATUS.md](STATUS.md).
