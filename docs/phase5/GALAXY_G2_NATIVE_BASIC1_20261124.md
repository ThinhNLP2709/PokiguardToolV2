# G2 — chốt BASIC collector và chuẩn bị Suy luận ngày 24/11/2026

**Cập nhật sau phiên kế tiếp:** [Suy luận G2 đã hoàn tất 1/1](GALAXY_G2_NATIVE_REASONING1_20261124.md),
16 SWAP/ACK, ba response skill; so cùng bàn có 7 nước đổi và 9 nước giữ
BASIC resource replay. Giữ hai response BASIC thiếu trong corpus này,
không dùng response của trận R điền ngược vào log BASIC.

## BASIC đã hoàn tất

Run `f208dbf50cc5498cb2826efb84d03263`, match `M_950bd329`, Galaxy Glank
chính, không tiến hóa, Solo Genbu lv161, đủ điều kiện skill, Tự bảo vệ dưới
30%. Source `ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.

WIN 1/1, nhận thưởng, về BOSS_LOBBY, `FARM_TARGET_COMPLETED`.
18 SWAP/18 ACK, 3 skill tại lượt 13/29/41, không tiến hóa/PASS, không
technical abort/recovery hoặc lỗi input sai lượt/trùng/misclick/partial.
Có một đề xuất bị hủy **trước input** do policy đổi ở fresh reread; sau đó
controller vẫn hoàn thành, không safe stop hoặc coi hủy đó là skill đã gửi.

`galaxyReasoningEnabled=false` xác minh đây là BASIC. Không dùng WIN hoặc
3 skill làm bằng chứng Suy luận, không quy số lượt thành chất lượng.

## Dữ liệu đã có và phần thiếu

Cả ba lần dùng có fresh context, board đã công bố, thẻ G2 hiện hành và
chi phí từ CardUI **200 Mana/200 Nộ**; Khiên hiệu dụng trước skill lần lượt
14/11/14. Đã chuyển ba context thành CommonProblem offline, giữ skill là
hiệu ứng opaque (`cleared=null`), không giả mask rỗng hay damage 0.

Log chứa **một phản hồi skill có thứ tự**, tại lượt 29, sequence 64:

- DAMAGE báo 363.000; HP boss 796.278 → 433.278 trong cùng phản hồi.
- Operation trừ 200 Nộ, trừ 200 Mana, sau đó cộng 100 Mana. Ledger ba
  phép số học khớp; bốn endpoint HP/Mana/Nộ/Khiên khớp player context.
- Không có DESTROY/SWAP operation trong phản hồi được giữ. Không suy từ
  đó rằng đã quan sát đầy đủ mọi thay đổi bàn, buff hoặc giáp.
- Skill có 11 Khiên hiệu dụng trước click. Một mẫu không đủ suy công
  thức damage chung hoặc nguyên nhân khác mô tả danh nghĩa 30.000/viên.

Phản hồi không có card ID, primitive post-state vẫn là trạng thái cũ nên
không đủ client-window anchor: giữ **UNBOUND**, 0 strict wire-card match,
0 conditional client-window match. Ba khoản cost/refund trên là số báo
trong phản hồi và phép số học theo context, không phải server action echo.

**Hai skill còn lại chưa có ordered response được lưu.** Ba checkpoint
retained ngay sau primitive đều ghi 0; phản hồi lượt 29 được normal drain
ghi sau checkpoint khoảng 1,175 giây. Không kết luận skill không chạy từ
checkpoint 0, không suy effect của lượt 13/41 từ HP ở lượt sau. Log không
đủ xác định nguyên nhân gốc hai phản hồi thiếu. Không tuyên bố collector
đã có coverage đầy đủ và không lặp BASIC chỉ để hi vọng bù các file thiếu.

Trường kiểm cost trước DESTROY của generic receipt giữ UNKNOWN vì Galaxy
không có DESTROY trong phản hồi này; đây không phải chứng cứ chưa trừ phí.
Các raw operation và ledger được giữ riêng. Không sửa generic receipt hoặc
đổi scope chứng minh để làm đẹp bộ đếm.

## Bằng chứng đã lưu

- [Closure](artifacts/g2_capture_basic1_20261124_205259/review/closure.json).
- [Ba CommonProblem và một receipt](artifacts/g2_capture_basic1_20261124_205259/review/evidence_pack.json).
- [Binding audit](artifacts/g2_capture_basic1_20261124_205259/review/skill_bindings.json).
- [Verification](artifacts/g2_capture_basic1_20261124_205259/review/verification.json): 8 file raw kiểm hash, ba CommonProblem roundtrip, receipt tính lại khớp, source không đổi.
- [Fixture regression](../../tests/fixtures/g2_native_basic1_20261124/cases.json), không nhãn chất lượng hoặc holdout độc lập.

## Phiên tiếp đã chuẩn bị, chưa Start

Tối đa **một trận Suy luận G2**, giữ route, boss và settings. Mục tiêu là
kiểm `GalaxyReasoningSession` thật sự cấp `galaxy_reasoning=true`, thẻ
hiện hành được xác minh `GALAXY_2`, nhánh giữ Khiên/tích tài nguyên/cân
nhắc dùng skill có trace, normal input có ACK và không safe stop.

Nhánh UI này là chiến thuật Galaxy riêng, **không phải common worker**.
Không cài timing profile Mega để giả cấp authority chung, không nạp mẫu
damage 363.000 hoặc phần refund từ kết quả vừa thu thành dự đoán mới.
Các dữ liệu BASIC đã đủ kiểm nền input/card/context và có một ví dụ effect;
phần effect còn thiếu giữ riêng, không chặn bài kiểm chiến thuật hiện có.

So BASIC/R trên cùng pre-input state và lịch sử hợp lệ khi log cho phép;
không gọi so hai ván ngẫu nhiên là phản thực tế trên cùng bàn. Không dùng
trạng thái sau trận làm input của đề xuất thay thế. Không tự tăng cap.
Đầu mối phiên chuẩn bị: `logs/latest_g2_reasoning1.json`.
