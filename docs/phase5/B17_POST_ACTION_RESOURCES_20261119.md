# Suy luận: tài nguyên sau nước ta và nguy cơ bị Hút

19/11/2026. Shared adviser đã bổ sung một kịch bản có điều kiện: lượng
Mana/Nộ từ các viên biết chắc được ăn trong SWAP có thể trở thành tài
nguyên cho boss Hút ở lượt sau. Trước đó nguy cơ này chỉ dùng số dư trước
nước ta, nên có thể đánh giá thấp việc vừa tích tài nguyên rồi để boss Hút.

Không có dự đoán số dư ròng của server. Kịch bản giữ riêng reference trước
nước và gross known gain, chặn ở sức chứa. Khi cùng nước có kiếm, thứ tự
tiêu Nộ chưa biết nên giữ reference Nộ; skill cũng giữ số dư reference.
Refill, cascade chưa biết, lượng/thứ tự chuyển tài nguyên tiếp tục là UNKNOWN.
Không cộng các cực đại lấy từ những phản hồi boss khác nhau thành một nước.

## Danh tính và kiểm offline

- Trước sửa: `450abb97abde1be489dc32aef8c31c8a7753ea82be39795332142dea3052e673`.
- Source chạy 205 test và 613 replay:
  `f0fbe43bdc11c6fdad657a2e6d35d430bfeb999ed2a62cef968b15318314e0e4`.
- `main` hiện tại:
  `666d13bc00c5fbfdf4140ccd5ff9722b1680bcd8e569eddd8f825219674cef3f`.
  Các commit compatibility/updater đã có làm đổi fingerprint toàn source;
  module tactics và các test suy luận của đợt này giữ nguyên byte. Qualification
  được chạy lại riêng trên source main, mọi gate PASS, worker/writer đã đóng,
  303 record không mất. Đây là kiểm tổng hợp, không là nghiệm thu native.

57 kiểm tra tập trung và 205 kiểm tra liên quan PASS. 11 test mới kiểm gain,
trần tài nguyên, thiếu conversion, PASS, skill, Nộ khi tấn công, thứ tự reply,
summary và các ví dụ native. Không chạy lại toàn suite; 5 test fixture bàn
lịch sử bị thiếu ở đợt trước vẫn là giới hạn riêng, không gọi toàn suite xanh.

Paired replay 613 trạng thái duy nhất (584 archive,21 B16,8 B17) đổi17 lựa
chọn: Demon5, Cẩn trọng3, Khủng long4, Cơ bản4, tích tài nguyên1. Tất cả
đề xuất hợp lệ/thuộc owner; cùng giới hạn8 root,32 scenario,18000 node.
Hai ca chạm node cap ở cả trước/sau; không dùng kết quả này như tối ưu toàn
cục. Galaxy/Mega trong corpus không đổi nước; không suy ra UI Galaxy đã
được nâng cấp hoặc nghiệm thu. Replay không phải holdout độc lập hay nhãn thắng.

Rà6 khoảng native cũ, có ví dụ Mana30 +3×30 =120 khớp số dư quan sát sau.
Các khoảng có Hút/refill/tấn công không cho phép biến gross gain thành dự
đoán ròng;4 khoảng giữ thứ tự tiêu Nộ UNKNOWN. Fixture tách `problem` trước
hành động khỏi `retrospective`, không đưa giá trị quan sát tương lai vào adviser.

## Kiểm trực tiếp source main

Đã công bố giới hạn mới tối đa1 BASIC +1 Suy luận, tách6 trận cũ đã đóng.
Chỉ dùng timing/profile mới cùng source,host,B17; không rebind hồ sơ cũ.
Room mới `Coop_310394`, Priest131/Demon Aegis560, Khiên/4 kiếm, không tiến
hóa/nội tại. Account chỉ là alias hash; full gear UNKNOWN. Kết quả và cap
được ghi riêng trong `live/closure.json` và `reasoning/closure.json`.

| Kiểm | BASIC | Suy luận |
|---|---:|---:|
| Kết quả | WIN/nhận thưởng/về phòng | WIN/nhận thưởng/về phòng |
| Nước gửi / SWAP ACK | 11/10 | 6/5 |
| Nước cuối chuyển terminal, loại khỏi mẫu ACK | 1 | 1 |
| Safe stop / recovery / PASS | 0/0/0 | 0/0/0 |
| Khoảng boss có before/after bind được | 7 | 5 |

BASIC có10 mẫu timing hợp lệ tạo profile mới, source/build/host khớp.
Suy luận6 quyết định có18 ROOT/FRESH/FINAL hợp lệ và khớp nước thực gửi;
5 override gồm4 SWAP ACK và1 nước cuối chuyển terminal.37 diagnostic record
được ghi đủ,0 mất/lỗi,worker1/1 reaped. Log candidate summary có12 context
known-gain, trong đó1 candidate có thay đổi risk do tài nguyên; đây là bằng
chứng nhánh mới được tính thật, không chứng minh candidate đó tốt hơn.

Source giữ nguyên cả hai trận, main preferences giữ nguyên. Tổng8 trận đã
đóng tính cả6 trận lịch sử, cap mới2/2 dùng hết. ToolPID16540 đang dừng1/1,
game ở đúng lobby Priest; không tự chạy thêm. Hai bàn khác nhau nên số lượt
11 và6 không là phép so sánh hiệu quả hay tỷ lệ thắng.
[Closure và kiểm cuối](artifacts/b17_post_action_resources_20261118/closure.json).

Local `main` đã fast-forward từ ancestor cũ tới commit `3a0df30d…`, giữ
code đang có; ref `backup/main-before-continue-20261119` giữ vị trí main cũ.
Không push remote hoặc xóa feature branch.

## Phạm vi còn mở

Ước lượng net Mana/Nộ sau attack/transfer và coverage refill vẫn cần nguồn
đúng trước/sau. Damage/heal skill, khắc hệ/buff/crit và skill sent-ACK chưa
đủ để fit. Nhánh học outcome/value/ranker tiếp tục xếp sau các mục dữ liệu
cũ; không dùng WIN gán mọi nước là tối ưu. Đợt này không đổi BASIC, PASS,
input, skill guard hoặc version, không huấn luyện hay build phát hành.

[Artifact và script tái kiểm](artifacts/b17_post_action_resources_20261118/),
[paired summary](artifacts/b17_post_action_resources_20261118/paired_summary.json),
[native retrospective](artifacts/b17_post_action_resources_20261118/native_review.json),
[qualification trên main](artifacts/b17_post_action_resources_20261118/qualification_main_20261119/qualification.json).
