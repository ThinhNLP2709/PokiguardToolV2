# Một lớp suy luận hỗ trợ chung — 02/11/2026

> **03/11/2026: phần định vị UI/model bên dưới là snapshot cũ.**
> Contract hiện hành tại [STRATEGY_ALIGNMENT](STRATEGY_ALIGNMENT.md): chọn
> Cơ bản/Suy luận ở Tùy chọn, AI chỉ cài đặt liên quan. Native PASS không gửi
> input, giữ full BASIC fallback reserve và luật PASS đọc từ game/owner cũ;
> không có hard cap mới. Skill vẫn cần timing hiện hành. Receipt f669b126… không đổi nguồn/phạm vi.


> Cập nhật sau khi đóng offline: lỗi nhận thưởng132/550 đã được sửa riêng tại
> [báo cáo02/11](../postmatch_transparency_fix_20261102.md). Source hiện401file
> 513e0104…, khác snapshot f669b126… trong báo cáo dưới. Draft chưa activate
> của source cũ phải được cập nhật sau kiểm offline successor; không dùng nó
> để tự mở native trên source mới, không ghi lại raw receipt cũ.

Yêu cầu chốt: người dùng chọn **lối chơi và cấu hình một lần tại Tùy chọn**.
Tab AI chỉ bật/tắt suy luận và đặt budget. Không có bộ chọn AI A/B/C hoặc
AI riêng cho từng màu viên. Lối chơi định hướng mục tiêu/trọng số; ngưỡng
chiến thuật là tham khảo. Ownership, nguồn skill, cost, cooldown, quyền PASS,
Stop và an toàn input vẫn bắt buộc.

## Đã triển khai trong source

Một luồng dùng chung: packet có sẵn → BASIC incumbent → common problem →
worker → kiểm lại ở host → ROOT/FRESH/FINAL hiện có → executor hiện có.
Không thêm một lần đọc game/chụp ảnh hoặc một executor khác. AI có thể giữ
nguyên BASIC; không có chỉ tiêu bắt buộc đổi nước. Lỗi/thiếu model/quá hạn
không tự dừng farm, và không cấp quyền gửi lại action đã bắt đầu.

- UI nhận intent ở cả 7 lối chơi. `ui_reasoning_scope_reason` cũ chỉ còn dùng
  kiểm hồ sơ Shield lịch sử; UI mới dùng `ui_reasoning_intent_reason`.
- Session chung được nối qua setup sẵn có của FarmRunner và Dinosaur runner.
  Khủng long vẫn theo rule vào trận có sẵn và dừng khi xác nhận thắng.
- Demon dùng `demon_target_gem` hiện tại cho Khiên/Máu/Mana/Hút/Nộ. Tất cả
  dùng xác nhận của người dùng về cùng phép quét vuông góc; không suy tên
  pet hoặc hiệu ứng đang trang bị chỉ từ tên cấu hình.
- 30 Mana/20 Nộ mỗi đơn vị hiệu dụng được ghi nguồn `USER_DECLARATION`.
  Đủ 100 Nộ đang có, hoặc đủ từ **Nộ đã biết nằm trong chính vùng quét**, có
  thể giảm mục tiêu danh nghĩa một Kiếm. Tính x2/x3, giữ sàn hai ô Kiếm thật
  của model cũ. Nộ ở nơi khác/UNKNOWN không được cộng. Có thể tắt model này
  bằng override nội bộ; không thêm setting AI theo từng pet.
- Quy tắc giảm Kiếm là tham khảo chiến thuật do user cung cấp, **không phải
  kill certificate** hay công thức damage/gain-order đã xác minh ở server.
  Refill, damage, cascade passive tiếp theo và boss skill còn UNKNOWN.

## Chứng cứ input thuộc họ hành động, không phải menu AI theo lối chơi

`reasoning_common_native` nạp hồ sơ timing từ file tại setup. Hồ sơ phải khớp
source/build/host hiện tại, có qualification và raw BASIC control đã pin SHA.
Loader tính lại H/I từ timestamp, nguồn đầy đủ, sent/ACK join và watermark;
không nhận một số reserve tùy ý do worker khai.

Hiện đường native chung mới có hợp đồng timing cho **swap foreground,
two-click, 1280×640**, trong miền random đã đo. Cấu hình chiến thuật được
đóng băng theo phiên; đổi mục tiêu không dùng lại offer của turn/cấu hình cũ.
Timing swap có thể dùng cho cùng primitive ở các mục tiêu khác nhau; không
đòi người dùng chọn hay live riêng một AI cho từng viên.

Skill và PASS có mặt trong chooser chung và đã kiểm legality/model offline,
nhưng khi chưa có timing hiện hành của họ action đó thì không tự cấp quyền
native cho chúng. BASIC vẫn quyết định chúng. QTE giữ nguyên. Coop thiếu model
phản hồi đồng đội nên native chung giữ BASIC với lý do riêng. UI intent vẫn
có thể lưu; trạng thái phải nói rõ thiếu chứng cứ, không hiện đã chạy AI.

Hồ sơ timing là **operational projection với mẫu nhỏ**, không phải chặn trên
tuổi dữ liệu server, animation hay lịch chạy Windows. Monitor dùng shared
guard hiện có và chỉ ngắt AI khi vượt projection. Hồ sơ source không được
tự nâng thành nghiệm thu EXE đóng gói.

## Kiểm offline đã kết thúc

[Receipt](artifacts/common_ai_assistant_20261101/closure.json),
[qualification](artifacts/common_ai_assistant_20261101/qualification/qualification.json),
[test log](artifacts/common_ai_assistant_20261101/focused_tests_final.log).

- **339 test liên quan PASS**, 20 module; không gọi đây là toàn bộ suite lịch sử.
- 42 trace tắt AI khớp hành vi BASIC B14 trước thay đổi; chỉ chuẩn hóa đồng hồ
  trong tên artifact. Không bỏ action/reason/ACK để tạo parity.
- 7 style qua seam controller giả lập, 5 target Demon qua cùng worker/host;
  5 boundary case kiểm stale/pending/Stop/PID thật chưa có authority.
  Các ca model thiếu giữ BASIC, không được gọi là nghiệm thu native 7 style.
- 100 bộ ROOT/FRESH/FINAL: p50 0.6193 ms, p95 1.0782 ms, max 1.2209 ms.
  Đây là chi phí checkpoint giả lập, **không phải thời gian toàn bộ suy luận**.
  Ghi đủ 300 checkpoint, không mất log, worker/writer đóng sạch; 14 gate PASS.
- Test thêm việc nạp raw proof, pin source/build/host/cap, từ chối sửa raw/ACK,
  giữ timing chưa đo ở BASIC, handover hai worker qua session thật và nối
  Dinosaur vào cùng session. Native surface trong các test đều là fake.
- Source 400 file, SHA `f669b126fbce1bd2410620f4ead003c2076c6e426c2250000ed13a0a13d48024`.
  So với baseline trước đợt này: 13 file đổi, 4 file thêm; 383 file cũ giữ đúng
  byte. Bộ đọc memory, solver/BASIC, input, QTE, ACK và vòng farm giữ byte.
  File desktop controller chỉ thay setup nối session, đã kiểm đường fallback.

Hai fixture cũ được sửa ở dữ liệu test: raw request cũ thiếu trường random mới;
test loader Shield lịch sử giờ dùng source view lịch sử cô lập. Không sửa raw
chứng cứ hoặc nới guard production để làm test PASS. Các lần chạy lỗi ban đầu
vẫn giữ tại thư mục artifact.

## Điểm chốt trực tiếp, không mở chuỗi P mới

Phần offline của đợt này đã xong. Chưa tạo request/claim, chưa cài profile, chưa
mở tool/game hoặc gửi input. ZIP 1.3.0 B14 giữ nguyên SHA `a9a190ba…`.

Đề xuất **một trường hợp đại diện, tối đa 6 attempt mới**: 3 BASIC có collector,
rồi tối đa 3 REASONING cùng Solo Lieyun77 + Demon Aegis thường, ăn Khiên,
4 Kiếm hiệu dụng và giữ đồ/random. Không tự tăng cap để tìm override hoặc đủ
WIN. Các control cần ít nhất một swap được ACK để nối sample timing; thiếu mẫu
thì báo đúng giới hạn, không bịa số hoặc tự đánh thêm.

Lý do cần BASIC mới: 3 trận tương thích B14 trước rebuild chỉ có log thường,
không bật collector H/I. Không thể lấy chúng làm timing proof. Các proof B12
và draft Sagui cũ không được relabel. Không yêu cầu chiến dịch riêng cho cả
5 target có cùng geometry đã xác nhận.

Draft chuẩn bị, chưa có quyền chạy:
`artifacts/common_ai_assistant_20261101/common_basic_draft.json`.

Khi user chuẩn bị phòng và chốt cap, dùng `prepare_common_control activate`
và gate một Start hiện có cho 3 BASIC. Export bằng `tools/basic_calibration.py`,
đọc raw và dùng `tools/prepare_common_runtime.py` để tạo bundle timing chung.
Tool này không tự cài profile hoặc Start. Chỉ dùng profile cùng source đã
đóng băng, cùng transport và cap tối đa 3 cho nửa REASONING. Sau đó kết luận
kỹ thuật đúng bằng raw log; không tuyên bố hiệu quả tốt hơn từ vài trận thắng.
