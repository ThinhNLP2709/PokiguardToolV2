# Galaxy — rà soát ngày 15/11/2026

Phạm vi: Galaxy chính, không tiến hóa, thẻ skill của pet; phản hồi người dùng
về Jasper level 244. Nhánh Pet thường → Galaxy vẫn giữ ưu tiên tiến hóa trước
skill. Chỉ sửa PokiguardToolV2 và đọc tiến trình với quyền query/read.

## Nguyên nhân

1. Trong log `logs/farm_runs/78a948f88e2747669f1e7d5d2dcad46f/matches/attempt_001/combat.jsonl`,
   cả 9 quyết định của `M_ac467ce3` đều có `skill_capability_status=NO_CAPABILITY`,
   `required_mana/required_rage=null` và `cardCount=0`. Tool đi nhánh
   `STEP_2_SWORD` hoặc `STEP_5_*`; không có lần dispatch skill.
2. Đọc riêng trận `M_29bac730` do người dùng tự mở thấy đúng CardUI hiện hành,
   một thẻ `3347 / GALAXY_DRAGON_KNIGHT`, chi phí 200 mana + 200 nộ.
   `read_card_data` lấy nhầm cooldown từ `+0x88`, chính là con trỏ petElement;
   kết quả `-836433376` gây `CardData cooldown is implausible`.
   Reverse B15 xác nhận cooldown ở `+0x94`, giá trị đọc thực tế là 0.
3. Nhánh Galaxy trước đây chỉ ưu tiên mana/nộ khi có nước an toàn. Nếu không
   có hoặc không đọc được thẻ, nó rơi về logic cơ bản. Ngưỡng bảo vệ của Mega
   chưa được áp dụng cho Galaxy và control này bị ẩn trên UI.

Không có bằng chứng log cho thấy nhánh Bú win đã chạy trong trận này.

## Hành vi sau sửa

- Đọc cooldown bằng hằng offset đã xác minh; giữ kiểm tra phạm vi cooldown.
- Dùng chung nhánh tích tài nguyên và ra skill đang dùng cho Mega kết ấn,
  thay vì duy trì một nhánh Galaxy rút gọn. Giữ kiếm khi tích skill; ưu tiên
  mana/nộ đang thiếu và áp dụng cùng thứ tự hỗ trợ, chấp nhận rủi ro, PASS.
- Thiếu thẻ: thử đọc lại trong khoảng chờ hiện có, ghi chẩn đoán, không bấm
  skill và không tự đặt chi phí. Quyết định bàn vẫn theo nhánh Galaxy.
- Hiện Tự bảo vệ cho Galaxy và dùng cùng ba giá trị cấu hình/lưu trữ với Mega.
- Đủ mana/nộ, đúng thẻ hiện hành và actionable: ra skill trước bàn cờ,
  không phụ thuộc số kiếm hay số viên. Skill Galaxy sẵn sàng vẫn ưu tiên
  ở HP thấp; không giả định nó hồi máu như Icarus.
- Suy luận được phép chọn nước tích tài nguyên khác nhưng không đổi sang
  ăn kiếm, bỏ ưu tiên tài nguyên, tăng từ nước an toàn sang nước rủi ro,
  hoặc thay quyết định skill/bảo vệ. Chốt nằm tại common selection trước input.
- Theo xác nhận của người dùng, Galaxy ở cấu hình này gây sát thương mà không
  phá bàn: không dùng mask Mega hoặc suy diễn lượng sát thương. Đường click-only
  và xác nhận từ trạng thái/turn/resource mới được giữ lại.

## Giới hạn kiểm chứng

14 ca trong `tests/test_galaxy.py` đều đạt, bao gồm so sánh nước chọn với
Mega dùng điều kiện đủ tài nguyên, tích mana/nộ có rủi ro, không ăn kiếm
khi có tài nguyên thay thế, ba ngưỡng bảo vệ và biên 10%/30%, skill sẵn
sàng ở HP thấp, thẻ không sẵn sàng, Suy luận, đổi thẻ trước click và bàn
không đổi sau skill. Test bộ đọc tái hiện con trỏ petElement khác rỗng;
cooldown âm/quá giới hạn tiếp tục bị loại. UI kiểm lưu cả ba mức cho Galaxy.

Nhóm hồi quy mở rộng: 25 module, 669 test thật, 667 đạt và 2 lỗi có sẵn
trong `test_reasoning_config_projection`: pin lịch sử của
`reasoning_operational.py` không khớp và kiểm đếm cũ 118 trong khi dữ liệu
hiện có 120 ca. Cả hai được chạy lại với module trước sửa và lỗi y hệt.
Nhóm planner `tests.test_reasoning_common` có thêm 12/12 đạt, tổng 679 ca đạt.
Lệnh đầu gõ nhầm tên module planner không tồn tại; đã sửa sang tên thật trên.
Log kiểm nằm trong `temp/galaxy_review_20261115/`. Kiểm tra whitespace cho
các file thay đổi trong đợt này không báo lỗi.

Đã đọc thẻ và trường raw trực tiếp trong trận, không gửi input. Trận đã kết
thúc trước lần đọc lại sau sửa; không tuyên bố đã bấm thành công skill trong
game hoặc đã thắng Jasper 244. Không sửa game, V1, bộ nhập phím/chuột hay
giao thức mạng. Bản sửa nằm trong source, không tạo gói EXE mới.

Một test có sẵn về Mega phục hồi lỗi thẻ,
`test_pet_skill_fault_return.PetSkillFaultReturnTests.test_real_combat_loop_hands_fault_to_room_recovery_without_gameplay`,
lỗi do fixture `gameplay_capability` không có `reserve`. Chạy lại với các
module nguyên trạng trước đợt sửa vẫn lỗi y hệt; không mở rộng phạm vi để
đổi hành vi phục hồi Mega trong đợt Galaxy này.
