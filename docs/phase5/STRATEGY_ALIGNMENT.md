# Suy luận theo tình hình trận đấu và lối chơi — 03/11/2026

> Cập nhật04/11: [ADVISER_DIRECT_SWORD](ADVISER_DIRECT_SWORD.md) sửa thiên lệch
> trừ điểm Kiếm thường của Demon và bổ sung trọng số cơ hội tấn công theo
> HP/Nộ. Không thêm ngưỡng7Kiếm, không đổi PASS/input/flow. Chứng cứ source và
> live cũ giữ nguyên phạm vi; bảnsửa này mới kiểm offline.


Đây là contract hiện hành theo yêu cầu người dùng ngày 03/11, thay cho phần
định vị UI và giới hạn model trong COMMON_AI_ASSISTANT trước đó. Các receipt,
cap và kết quả live cũ giữ nguyên phạm vi lịch sử; không chuyển chúng thành
chứng cứ cho source mới.

## Quyền chọn và cách quyết định

**Tùy chọn là tab chính:** chọn Lối chơi, Độ thông minh (Cơ bản/Suy luận) và
cấu hình lối chơi. **AI chỉ có thiết lập liên quan:** budget, shadow và chẩn
đoán. Không có bộ chọn AI A/B/C hoặc một AI khác cho mỗi viên mục tiêu.
Lưu budget tại AI không âm thầm lưu thay đổi lối chơi/độ thông minh còn nháp.

Một lần đọc trạng thái hiện có tạo BASIC incumbent trước. Cùng packet đó vào
worker suy luận có deadline; host kiểm lại đề xuất ở các checkpoint hiện có.
Suy luận được giữ nguyên BASIC. Lỗi, thiếu model hoặc quá hạn giữ BASIC, ghi
lý do trong diagnostics suy luận. Không đổi thứ tự đọc, chụp ảnh, farm, input,
ACK, QTE hoặc thêm lần đọc game để chờ planner.

Mục tiêu là nước có ích nhất theo lối chơi, không phải nhiều viên nhất hay
phải đổi nước so với BASIC. Ngưỡng chiến thuật là tham khảo. Cost thực,
cooldown, nguồn skill, ownership, thời gian còn lại và giới hạn PASS vẫn là
điều kiện bắt buộc. Không dùng thiếu thông tin như chứng cứ an toàn.

## Model chung đã bổ sung offline

Scorer dùng HP/Mana/Nộ hiện có của cả người chơi và đối thủ, sức chứa, khiên,
ATK, vùng tác động, x2/x3, phản hồi boss còn tính được và mục tiêu lối chơi.
Các chuyển đổi 30 Mana/20 Nộ là khai báo của người dùng; không phải công thức
sát thương đã xác minh. Mana/Nộ đã đủ mục tiêu không tiếp tục nhận điểm tích
tài nguyên. Máu chỉ có lợi ích hồi khi đang thiếu; Khiên/Hút xét nhu cầu và
tài nguyên đối thủ. Không biến proxy thành dự báo chắc chắn sống/thắng.

| Lối chơi | Chủ trương được thể hiện trong chooser chung |
|---|---|
| Đơn giản/Cẩn trọng | So lợi ích Kiếm với phản hồi boss, tài nguyên hữu ích và cơ hội tiếp theo. Nước ít Kiếm hơn có thể tốt hơn nếu giảm Kiếm cho boss. Cẩn trọng tăng trọng số bảo vệ/rủi ro. |
| Khủng long | Cùng mục tiêu chiến thuật như Đơn giản. Giữ nguyên bắt đầu trong trận và dừng theo tín hiệu thắng hiện có. Không gán chính sách boss Sword-first cho đối thủ không phải boss. |
| Chịu đấm ăn xôi | Tích theo cost skill thực, khả năng ra skill và dự trữ cho chu kỳ sau; Khiên/Hút và phá cơ hội đối thủ tham gia chấm điểm. Setting không phải điều kiện cứng duy nhất. |
| Demon Farm | Dùng viên mục tiêu trong cấu hình cho cả Khiên/Máu/Mana/Hút/Nộ với cùng geometry đã được người dùng xác nhận; xét Kiếm hiệu dụng, Nộ trong vùng quét, boss reply và setup. Ưu tiên mục tiêu danh nghĩa vừa đủ khi có model phù hợp. |
| Mega Icarus | Khi cần tiến hóa, ưu tiên Mana theo cost FusionState hiện có; giữ quyền tiến hóa ở owner cũ. Sau tiến hóa xét chi phí, chu kỳ skill, lợi ích hồi máu khi thiếu HP và cơ hội tấn công, có thể đề xuất skill dưới ngưỡng Kiếm. Lượng hồi cụ thể vẫn UNKNOWN. |

Các ví dụ “đủ Nộ thì ăn Mana, đủ Mana thì hồi máu” là ưu tiên theo nhu cầu,
không phải chuỗi if/else bắt buộc. Nước đang tạo lợi thế Kiếm hoặc chặn boss
vẫn có thể tốt hơn. PASS chỉ là một ứng viên khi không có nước đủ hữu ích và
owner cho phép; HP dư không tự động buộc bỏ lượt.

Boss Sword-first là giả thuyết có nguồn từ người dùng: giữ mọi nhánh cùng
mức Kiếm hiệu dụng cao nhất. Lookahead có giới hạn xét cơ hội sau phản hồi
boss còn tính được. Refill chưa biết, boss skill và thứ tự hiệu ứng chưa biết
không được dựng thành đường dụ boss chắc chắn.

## Bỏ lượt: game và owner hiện có quyết định

Người dùng xác nhận được bỏ hai lượt liên tiếp; lượt thứ ba dẫn đến thua.
Adviser chỉ được đề xuất PASS khi bộ kiểm tra đang hoạt động của tool cho
phép, dựa trên count/threshold/status và bằng chứng reset đọc từ game. Không
đặt thêm hard cap, không tự đếm hoặc tự quyết định reset ngoài cơ chế này.
Với threshold 3 hiện có: count 0/1 cho phép, count 2 chặn. Thiếu bằng chứng
thì không được tự coi là count 0; giữ nguyên guard lượt đầu và kiểm fresh.

Hard cap vừa thử trong đợt này đã hoàn nguyên theo yêu cầu người dùng. Hàm
`pass_evidence` giữ nguyên logic trước đợt chỉnh adviser; 21 kiểm tra owner và
evidence đã chạy lại PASS. [Receipt hoàn nguyên](artifacts/strategy_alignment_20261103/rejected_hard_cap.json).

PASS không gửi input, nên admission giữ cùng toàn bộ reserve đã đo của swap
BASIC để còn đường fallback; không cần bịa thời gian click riêng cho PASS.
Điều này không thay đổi PASS_WAIT hoặc cách game xác nhận bỏ lượt.

## Demon: điều đã tính được và dữ liệu còn thiếu

Đường model cũ vẫn có tham chiếu giảm một Kiếm khi đủ 100 Nộ, và giới hạn
hai ô Kiếm thật của phạm vi cũ. Đó là mục tiêu danh nghĩa, không chứng minh
boss sẽ chết. Không cộng Nộ nằm ngoài vùng quét hoặc trong UNKNOWN.

Đã thêm contract estimate tùy chọn cho câu “2 Kiếm + full Nộ khoảng 100k khi
khắc hệ”: gắn account, session, chữ ký chỉ số hai bên và xác nhận khắc hệ.
Khi có đúng ngữ cảnh, HP boss có thể cho mục tiêu 2/3/4 hoặc nhiều Kiếm hơn,
thay vì lúc nào cũng bám ngưỡng 4 hay luôn trừ một. Mốc 100k chỉ là ví dụ
estimate có điều kiện; không cài làm hằng số mặc định cho mọi tài khoản.
Không có kill certificate, chưa chứng minh tuyến tính damage hoặc thứ tự
tăng Nộ rồi gây damage trong game.

**Packet hiện chưa công bố khắc hệ/damage đủ để tự áp dụng estimate này.**
Test worker/host chọn 2 Kiếm dùng dữ liệu giả lập đầy đủ; chưa phải kết quả
native. Không gọi yêu cầu đánh giá đủ damage mọi tài khoản là đã hoàn thành.

Reverse B14 đã xác minh tĩnh `Active.PlayerStats.weakness +0x98` và getter
liên quan. Span đọc hiện có đã chứa byte đó, nhưng state chưa xuất trường.
Chưa quan sát giá trị runtime và chưa chứng minh công thức sát thương server.
[Chứng cứ](artifacts/strategy_alignment_20261103/weakness_static_evidence.json),
[symbols](../il2cpp_symbols.md), [resolution](../board_resolution.md).

## Kiểm chứng và điểm chốt

Kết quả source hiện hành và danh sách file nằm trong
[closure](artifacts/strategy_alignment_20261103/closure.json),
[test log](artifacts/strategy_alignment_20261103/final_tests_pass.log),
[qualification](artifacts/strategy_alignment_20261103/qualification_final/qualification.json).
Các bề mặt native trong kiểm thử đều giả lập. Không mở tool/game, không phát
input, không dùng thêm năng lượng hoặc build lại ZIP trong đợt này.

366 test liên quan PASS; thêm 15 test authoritative PASS hiện có PASS (6 test
evidence đã kiểm lại cùng lượt). Kiểm gồm nhu cầu tài nguyên, denial Kiếm,
quyền PASS/reset từ game, Mana tiến hóa,
cost skill, Mega hồi máu, cấu hình ngoài Sword, năm viên Demon, x2/x3, worker
và host, UI Save/lock, BASIC parity và fallback. Qualification có 42 trace
BASIC, 7 seam lối chơi, 5 target và 300 checkpoint ghi đủ. Số đo checkpoint
giả lập không phải tổng latency suy luận hoặc bảo đảm timing trên máy thật.

Phạm vi tiếp tục chỉ là adviser; không mở chuỗi P hay campaign mới. Các giới
hạn hiện biết của đề xuất, chưa tự mở công việc/provider/live:

1. Khắc hệ/damage chưa đủ dữ liệu runtime để tự đánh giá chắc chắn đủ damage.
   Không suy công thức từ tên field hoặc đưa estimate của một account sang
   account khác.
2. Đề xuất skill đã có model offline, nhưng chưa có timing native hiện hành
   để tự đổi thời điểm dùng skill. BASIC tiếp tục xử lý skill trong khi thiếu
   bằng chứng này; QTE giữ nguyên. Không phát sinh test riêng theo từng màu.

Coop/Bú win vẫn giữ intent riêng và cần model đồng đội; mục tiêu thắng/farm
chung không được ghi đè chủ trương đã chọn. Các live cap cũ vẫn CLOSED.
