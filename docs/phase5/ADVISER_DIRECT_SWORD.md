# Adviser: ăn Kiếm trực tiếp khi có lợi — 04/11/2026

Người dùng nêu tình huống chơi tay: boss gần chết, bản thân còn ít HP, Nộ
trên 100, có nước khoảng 7 Kiếm nhưng không có viên mục tiêu để kích hoạt
nội tại Demon. Adviser phải so cơ hội tấn công với tiếp tục setup/bỏ lượt;
không coi viên mục tiêu hoặc ngưỡng đã cài là con đường thắng duy nhất.
Boss người dùng chọn tiếp là Lion Star; chưa mở thêm live trong đợt sửa này.

## Nguyên nhân đã xác định trong code

`reasoning_common_planner._features` trước sửa lấy điểm D của Demon từ
`passive_swords`, rồi **trừ** `ordinary_swords/8`. Nước ăn 7 Kiếm trực tiếp
không kích hoạt nội tại vì vậy nhận D = -0.875. Đây là thiên lệch cấu trúc
đối với đường tấn công thông thường, không phải kết luận từ công thức damage.

Không có snapshot đúng lượt chơi tay của người dùng. Ca tái hiện là giả lập
có ghi nguồn rõ: HP boss 10k/200k, HP ta 20k/100k, Nộ 120, Kiếm hiệu dụng
2+2+3, không có viên mục tiêu. Trước sửa nước 7 Kiếm bị xếp dưới một nước
setup tài nguyên; sau sửa nó được chọn. Không khẳng định log cũ đã tái hiện
đúng một lần PASS thực tế của người dùng.

## Thay đổi có giới hạn

- Kiếm trực tiếp và Kiếm trong vùng quét đều nhận điểm tấn công từ ledger
  hiệu dụng hiện có; không trừ điểm chỉ vì đó là ăn Kiếm thông thường.
- Trọng số cơ hội tấn công thay đổi theo Nộ hiện tại, HP boss còn lại và
  mức thiếu HP của ta. Đây là ưu tiên chiến thuật, không là lượng damage,
  xác suất thắng hoặc chứng nhận kill. Thiếu HP boss thì không tự có điểm
  “boss gần chết”. Không thêm điều kiện cứng “có 7 Kiếm thì bắt buộc ăn”.
- Phản hồi boss, tài nguyên hữu ích, UNKNOWN và setup vẫn tham gia so sánh.
  Test đối chứng giữ nước ít Kiếm hơn khi nó giảm phản công tốt hơn.
- Bú win giữ mục tiêu riêng. Không sửa bộ chọn BASIC, luật PASS/count/reset
  đọc từ game, worker transport, deadline, provider, input, QTE hoặc vòng farm.

387 test liên quan PASS, gồm kiểm worker thật và host ROOT/FRESH/FINAL bằng
bề mặt native giả lập. Ca không có target kiểm cả năm viên và hai hướng;
transpose vẫn chịu gravity hướng xuống nên không giả định các cascade đối
xứng hoặc ép chọn cùng một nước khi nước khác có lợi hơn.

[Test log](artifacts/adviser_direct_sword_20261104/final_tests.log),
[trước sửa](artifacts/adviser_direct_sword_20261104/before_regression.json),
[sau sửa](artifacts/adviser_direct_sword_20261104/after_regression.json),
[qualification](artifacts/adviser_direct_sword_20261104/qualification/qualification.json),
[source/receipt](artifacts/adviser_direct_sword_20261104/closure.json).

Kết quả live SkyPinkRain trước đó thuộc source 518805f4…, giữ nguyên phạm vi
lịch sử. Đợt sửa hiện tại chưa phát input/live hoặc build lại. Raw 14 ACK đo
trên Highsion không bị đổi nhãn source để tự mở suy luận trên source mới.

## Live preparation 2026-11-04

Prepared one REASONING attempt against Lion Star lv105 using the current source and private session preferences. The original 14 Highsion nonterminal ACK timing records remain byte-identical and retain their original source identity; only the reviewed scorer/outside-combat deltas and file-only setup tools are permitted by the timing projection. Current selector qualification passed all 14 gates (100 triples, max 1.5612 ms); 41 native-admission, B14 audit and strategy tests passed. No new gameplay reads, clicks, PASS policy, QTE or combat timing primitives changed. Profile load succeeded before launch. This is readiness for a bounded live test, not a completed live acceptance. Evidence: `artifacts/adviser_timing_reuse_20261104/`; session: `artifacts/adviser_lionstar_reasoning_1_20261104_235426/`.

## Kết quả live kiểm ngày 05/11/2026

Lion Star lv105: thắng 1/1, 7 lượt/năng lượng, nhận thưởng và về phòng. 7 quyết định hoàn thành (86.251–217.118 ms): 4 giữ BASIC, 3 đổi; cả 7 khớp input thật và 21 ROOT/FRESH/FINAL hợp lệ. Hai lần đổi ở lượt cá nhân 3 và 5 là Kiếm trực tiếp, ledger dự kiến 3 Kiếm, đều có SWAP_ACKNOWLEDGED. Lượt cuối kết bằng WIN/boss HP0 trước ACK thường; không ghi nhận PASS, timeout input hoặc AI fault/late/log loss. Không suy ra tối ưu toàn cục hay tiết kiệm hơn BASIC từ một trận.

Có lỗi riêng sau khi về phòng: checkpoint COMPLETED ghi thành công lúc 00:00:27.348 (05/11, +07), lần ghi kết thúc kế tiếp 10 ms sau bị WinError5 khi atomic replace. Vì thế raw runner giữ SAFE_STOP/NOT_PROVEN và exit2, không gọi toàn phiên clean PASS. Chưa xác định process/handle nào chặn; không đoán là antivirus hay game. Không sửa raw log hoặc runtime trong lần review này. [Receipt](artifacts/adviser_lionstar_reasoning_1_20261104_235426/result.json).
