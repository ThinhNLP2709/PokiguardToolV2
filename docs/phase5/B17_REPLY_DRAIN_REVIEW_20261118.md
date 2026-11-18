# B17 — đối chiếu nước boss và sửa định giá Hút Mana/Nộ

18/11/2026. **Hoàn thành offline, chưa live code mới.** Phân tích đúng13
khoảng boss đã đóng trên Priest131/Demon Aegis ăn Khiên; không đánh thêm,
đổi pet/acc/boss, build, commit hoặc fit model.

## Kết luận có bằng chứng

Trên bàn **thực trước nước boss**, cả13 SWAP quan sát đều hợp lệ. Có3 cơ
hội kiếm biết trước và cả3 lần boss chọn known-Sword maximum (3,6,5 kiếm).
Đây là3 cơ hội trong2 trận cùng nhóm, chưa chứng minh chính sách mọi boss.

6 khoảng trong trận R nối được với đúng snapshot adviser trước nước ta:
chỉ3 tọa độ boss nằm trong tập reply của bàn mô phỏng còn UNKNOWN;2 bàn
thực có ô đã biết tiếp tục đổi vị trí sau refill/cascade. Có trường hợp
known-reply Sword maximum là0 nhưng trên bàn thực boss lấy5 kiếm. Đây là
giới hạn của dự đoán first-wave/no-refill, không đủ bằng chứng để quy là
sai ánh xạ bàn hoặc bù bằng các viên rơi giả. T interval hiện mô tả độ nhạy
chính sách **trên phần bàn biết trước**, không là khoảng bảo đảm cho bàn
sau toàn bộ refill. Không nới hay gọi đó là prediction chính xác.

Đã tìm được lỗi rõ hơn: `evaluate_context` chỉ dùng Mana khi định giá Hút,
trong khi2 log mới có12 STEAL,6 POWER và6 MANA. Có2 boss POWER STEAL nằm
trong các khoảng có before/after. Vì vậy Mana thấp hoặc bằng0 không đủ để
coi Hút vô hại khi Nộ còn nhiều; boss Mana0 vẫn có thể còn Nộ để lấy/bảo vệ.

Reverse B17 xác nhận client giữ phân loại riêng: `Active.StealTypeOf` ở
RVA0x158C3A0 so sánh POWER→No,HP→Mau,các giá trị còn lại đi nhánh Mana;
`BuildWsOutputsByTag` RVA0x158C580 nối STEAL với `trang Dot`, đọc
`WsCombatStepDTO.stealType +0x30` và gọi helper đó. Không dùng nhánh fallback
để đoán một wire type thiếu. HP branch không chứng minh mọi viên Hút sẽ
steal HP; HP-steal vẫn ngoài mô hình này.

## Sửa có phạm vi

Source **b1b718fb… → 450abb97abde1be489dc32aef8c31c8a7753ea82be39795332142dea3052e673**.

- Nguy cơ reply Hút xét cả Mana và Nộ của ta; giá trị bảo vệ của nước Hút
  xét cả hai tài nguyên boss. Nộ dùng reference cài đặt và capacity hiện tại.
- Lấy **maximum của một tài nguyên** như proxy bảo thủ; không cộng thành hai
  lần hút đồng thời, không đoán server chọn loại nào hoặc hút được bao nhiêu.
- Thiếu số dư/capacity cần thiết thì đi qua cơ chế unknown feature hiện có;
  không được nhận điểm0 như một trạng thái đã biết là an toàn.
- Mana-only giữ nguyên công thức cũ khi nhánh Nộ bằng0. Cả hai số dư bằng0
  không tạo thêm lợi ích Hút. Quy tắc phase/skill/PASS, BASIC policy, bộ đọc,
  solver, quyền input và giới hạn tìm kiếm giữ nguyên.
- Worker summary giữ `drain_resources` gồm hai exposure, cách tổng hợp và
  selection/amount UNKNOWN. Vẫn trong budget12KB; không gửi input từ worker.

Chỉ2 file runtime thay đổi: `reasoning_common_tactics.py` và một trường
summary trong `reasoning_runner.py`;3 file test đổi/thêm và fixture2 case
native. Byte check bỏ đúng dòng summary mới thì runner khớp SHA trước sửa.
Không sửa normalizer outcome hoặc gán raw `after` cho bên nhận/bên mất:
published delta có thể gồm turn regen/bước khác, chưa là công thức transfer.

## Kiểm chứng

13 test mới kiểm Nộ-only/Mana-only/zero/unknown,5 target Demon,8 profile,
3 family, settings/capacity, rủi ro khi chừa Hút và summary. Regression Mega
giữ witness setup đầy đủ, nhưng không khóa một tọa độ cũ khi nước khác có
6 kiếm kèm Hút/Máu được định giá cao hơn. Không sửa owner/native risk guard.

Đợt kiểm rộng chạy227 test: **222 PASS,0 assertion failure,5 lỗi thiếu cùng
file board lịch sử** trong `test_reasoning_full_actions`. Đã tái hiện5 lỗi
đó bằng tactics trước thay đổi; lỗi xảy ra trước bước tính điểm, không tự
tạo fixture hoặc đổi guard để báo xanh.92 test của lượt focused trước cũng
PASS. Đây không phải full-repository CI xanh.

Paired replay **613 trạng thái duy nhất** =584 corpus cũ+21 B16 native+8 B17
native. Cùng planner,8 root/32 scenario/18000 node và deterministic clock;
chỉ thay tactics trước/sau. **83 lựa chọn đổi, tất cả swap→swap**, đều hợp lệ
hoặc thuộc tập hành động owner đã cấp. Bù Win0/7 thay đổi. Node-cap fallback
4→2,không có ca cap mới hoặc tăng budget. Đây không là613 trận, holdout độc
lập, đo latency native hoặc chứng minh83 lựa chọn mới thắng tốt hơn.

Trên cùng actual-before board/balances, cả5 tình huống có Hút thay đổi thành
phần risk Hút; tổng threat tăng ở4 tình huống,1 tình huống vốn đã clip1.
Trong8 snapshot B17, replay đổi1 lựa chọn; nước mới chưa được gửi trong game.
Không đưa after board/outcome vào snapshot để chọn nước, không dùng WIN
làm nhãn nước tối ưu hoặc fit hệ số damage/heal từ nhóm khác.

Galaxy có8 case replay đổi ở scorer chung, nhưng UI Galaxy hiện vẫn có
`GalaxyReasoningSession` riêng; đây chưa là nghiệm thu hoặc hợp nhất luồng đó.

## Điểm chốt

Source mới đã sửa thiếu sót về Hút Nộ trong adviser chung. Live6 trận B17 cũ
vẫn thuộc source95288/b1b7 đã đóng; không gọi đó là live cho450a. Profile
native cũ giữ nguyên và chưa được gắn lại cho source mới. Trước khi kiểm live
lại phải tạo qualification/control phù hợp; không reset hoặc tăng cap cũ.

Còn mở: ảnh hưởng refill/cascade và số dư sau nước ta; server transfer amount/
after ownership; damage/heal có điều kiện theo từng pet/boss/acc và skill.
Các mục đó cần giữ nguồn/unknown đúng phạm vi, không suy rộng từ3 cơ hội kiếm.
Learned outcome/value/ranker vẫn sau các việc cũ, chưa training. Chưa cần
user đổi boss chỉ để phân tích tiếp dữ liệu hiện có.

- [Verification và source manifests](artifacts/b17_reply_drain_20261118/verification.json)
- [13 khoảng native và đối chiếu adviser](artifacts/b17_reply_drain_20261118/analysis_initial.json)
- [Effect/risk review](artifacts/b17_reply_drain_20261118/effect_review.json)
- [Reverse static có SHA](artifacts/b17_reply_drain_20261118/b17_steal_static.json)
- [Paired replay summary](artifacts/b17_reply_drain_20261118/paired_summary.json)
- [Test log](artifacts/b17_reply_drain_20261118/final_tests.log),
  [5 lỗi fixture có sẵn](artifacts/b17_reply_drain_20261118/inherited_failures.json)
