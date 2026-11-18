# Nhánh Suy luận Galaxy Glank (G2)

## Log và thẻ được đối chiếu

Ba lượt người dùng chạy ngày 15/11/2026 trên Jasper (`boss_id=2372`):

| Pet | Element hiện hành | Match | Kết quả |
| --- | --- | --- | --- |
| G1 Galaxy Risky | `GALAXY_RICKY` | `M_0faec392` | WIN; một skill ở lượt 17 |
| G2 Galaxy Glank | `GALAXY_2` | `M_c543da74` | LOSS; bốn skill ở lượt 13/27/47/59 |
| G3 Galaxy Dragon Knight | `GALAXY_DRAGON_KNIGHT` | `M_fefb8547` | WIN; một skill ở lượt 13 |

G2 đã dispatch thành công cả bốn lần, với giá trị khiên lần lượt
14/11/10/9 ô, tương đương **17/12/12/17 điểm khiên có hệ số nhân**.
Lượt 3 cũ ăn thêm 3 ô khiên khi tích tài nguyên; lượt 11 ăn 5 ô khiên.
Lượt 61 và 65 ăn kiếm khi vẫn còn 55 và 50 nộ. Kết quả cuối là LOSS dù
snapshot local HP cuối chưa về 0; không kết luận nguyên nhân kết thúc là chết.
Bàn ở các lượt sau phụ thuộc các nước cũ; replay dưới đây không là kết quả
của một trận phản thực tế đã thắng.

UI log `logs/desktop_ui/20261115_232637/events.jsonl` cho thấy AI báo
`UI_REASONING_COMMON_CALIBRATION_REQUIRED` và `selection_authority=false`.
Vì vậy lựa chọn Suy luận trước đó thực tế rơi về BASIC, không có lượt so sánh
của common worker trong ba trận trên.

Ảnh thẻ người dùng cung cấp xác nhận G2 tiêu 200 mana/200 nộ, hồi 100 mana,
giảm 50% sát thương cho đội trong 3 lượt; sát thương 30.000 × khiên trên bàn
và không phá viên. Nội tại nêu giáp 30% HP tối đa mỗi lượt thứ ba. Chỉ số
chi phí khi thực thi vẫn lấy từ CardUI hiện hành, không hard-code 200.
Thời hạn hiệu ứng đang chạy, nội tại đang chạy, hệ số sát thương server và
các tương tác boss chưa được giải mã; chúng được ghi UNKNOWN, không cộng
giáp/hồi máu giả vào kết quả mô phỏng.

## Giá trị khiên và cơ chế client

Reverse B15: `CardPhotonSync.<WsRunGalaxySkill>d__12.MoveNext` tại
`0x2D3DB0` gọi `Board.ShowGalaxyScanFx` (`0x15243B0`) tại `0x2D4183`,
với literal `tim Dot`. Hàm scan đọc `Dot.multiplier +0x88` tại `0x15246BA`,
cộng `max(1, multiplier)` tại `0x15246CF`, trả tổng tại `0x1524837`.
Vì vậy đánh giá khiên phải giữ cả số ô và tổng hệ số nhân. Scan là hiệu ứng
client; nó không chứng minh công thức sát thương cuối của server.

RVA ở trên được đọc từ Cpp2IL/Il2CppDumper B15 và đối chiếu file game
SHA-256 `18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea`.
Chỉ đọc file, không gọi các hàm này. Disassembly nằm tại
`temp/galaxy_g2_review_20261115/`.

## Hành vi mới

- Chỉ bật khi chọn Suy luận trong profile Galaxy. Chỉ áp dụng chiến thuật mới
  khi thẻ hiện hành được xác minh đúng `GALAXY_2`; không suy ra pet từ tên
  cấu hình, không dùng card ID cố định. G1/G3 và Galaxy Cơ bản giữ hành vi cũ.
- Ưu tiên mana/nộ thiếu, giữ khiên có hệ số cao nếu có nước tài nguyên thay
  thế. Khi phải phòng thủ theo Tự bảo vệ vẫn cho phép dùng Health/Shield/Drain.
- Không ăn kiếm khi nộ lớn hơn 0. Nộ bằng đúng 0 mới mở lựa chọn kiếm; nộ
  UNKNOWN không được coi là 0. Nếu chỉ còn kiếm khi có nộ: chỉ PASS khi game
  chứng minh được phép; nếu không, dừng đề xuất input.
- Skill đủ chi phí/actionable: dùng mốc chiến thuật **16 điểm khiên có nhân**
  làm tham chiếu chất lượng, không phải điều kiện bấm thẻ hay công thức tối ưu.
  HP thấp/UNKNOWN hoặc áp lực kiếm đáng kể thì ra skill để bảo vệ ngay.
  Boss ở dưới sát thương danh nghĩa cũng ưu tiên skill, không chứng nhận kill.
- Khi ít khiên và HP còn ổn, so sánh tối đa 8 nước không ăn kiếm/khiên,
  rồi duyệt tất cả 112 swap boss đã biết cho từng nước. Chỉ chờ nếu có nước
  Sword-safe và giữ được giá trị khiên qua mọi phản hồi boss đã mô phỏng.
  Không có nước giữ được thì đánh ngay. Không tự sinh refill hay cộng giá trị
  cho khiên chưa xuất hiện.
- Chỉ chờ tối đa một lượt local được quan sát trong mỗi chu kỳ skill. Reread
  cùng lượt không tăng số lượt chờ. Chỉ lịch sử skill thành công của đúng
  session hoặc session mới mới mở lại một chu kỳ chờ.
- Skill tiếp tục là một click, không QTE/phá bàn; mọi đề xuất vẫn đi qua
  fresh state, turn/timer, foreground, input lease và ACK hiện có.

`GalaxyReasoningSession` nối lựa chọn UI đến nhánh chiến thuật nhỏ chạy tại
các checkpoint policy hiện có. Đây không phải bật common worker thiếu
calibration: không tạo authority/chứng nhận timing giả, không đổi loader hay
gates của common worker. UI hiển thị rõ “Suy luận Galaxy: G2 cân nhắc khiên
và bảo vệ; G1/G3 đủ là ra skill”. Cờ chỉ sống trong run đã bật, không thay
schema cấu hình/lưu trữ. Tắt Suy luận quay lại policy cũ.

## Kiểm chứng và giới hạn

Fixture `tests/fixtures/galaxy_glank_20261115/replay.json` chứa 35 trạng thái
G2 và hai trạng thái skill G1/G3, kèm hash log nguồn. Đã loại username và
con trỏ tiến trình. Kiểm thử bao gồm không tiêu nộ bằng kiếm, giữ hệ số
khiên, chờ có giới hạn, reset chu kỳ đúng session, bảo vệ, giữ hành vi G1/G3,
UI → tùy chọn run và controller → fresh checks → một SWAP bình thường → ACK.

Kết quả: **429 test hồi quy đạt**; sau bổ sung chốt trạng thái UNKNOWN,
nhóm Galaxy/G2 chạy lại **33/33 đạt** (19 G2 và 14 Galaxy cũ). Trên 35 bàn
G2 được so sánh độc lập, không có đề xuất SWAP ăn kiếm khi còn nộ. Lượt
3/29/37/39/49 có nước mới giữ được khiên mà nước cũ đã tiêu; lượt 61/65
chọn nước không ăn kiếm. Lượt 27 chuyển sang một nước setup giữ nguyên
12 điểm khiên qua mọi phản hồi boss đã biết. Lượt 47/59 vẫn ra skill để
bảo vệ. Đo riêng trên máy này, lượt quyết định lâu nhất trong lần replay
là 93,234 ms; đây không phải chứng nhận timing/input mới.

Kết quả replay chi tiết: `temp/galaxy_g2_review_20261115/replay_comparison.json`.
Log test: `temp/galaxy_g2_review_20261115/regression_tests.log`.

Chưa chạy trận live mới hoặc khẳng định G2 sẽ thắng Jasper. Bản sửa là source;
không phát hành EXE và không tự mở tool/start trận. Các test lịch sử
`test_reasoning_ui_delivery.ProfileReviewTests` đã lỗi do thiếu proof F1 BASIC2
trước sửa; đã tái chạy bằng module lưu trước sửa và xác nhận cùng lỗi.
