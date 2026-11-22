# Demon — ba trận bổ sung và độ phủ log của nhánh thu Máu

20/11/2026. Đã chạy đúng3/3 trận Suy luận bổ sung, từng trận giới hạn1 lần
thử và kiểm log trước trận tiếp. Cả ba WIN/nhận thưởng/về đúng phòng Priest;
0 safe stop/recovery/PASS, worker3/3 reaped. Cap mới còn0, tổng lịch sử26.
Không ép nước, đổi boss/pet/đồ/cài đặt hoặc sửa runtime để tạo tình huống.

Source477 file Python giữ nguyên `61bead5bf7a1fd8651e4d8b2b129e2b2c9c5d0db71559b25b6a27b1c129c596b`.
B17, Priest131/1845, Demon Aegis thường560 ăn Khiên, tham chiếu4 Kiếm hiệu
dụng, không tiến hóa, room `Coop_802270`. Dùng lại control13 ACK timing và
qualification14 gate **đúng cùng source/build/host** của phiên vừa đóng;
tạo profile mới max1 riêng cho từng phase, không sửa/rebind hồ sơ hoặc cap cũ.
Ordinary preferences nguyên; toolPID29932 đã quan sát dừng1/1 ở đúng lobby.

| Phase | Match | Kết quả | Decision / replay khớp | Khác BASIC cùng bàn |
|---|---|---|---:|---:|
| r1 | `M_cd186533` | WIN | 6 /6 | 0 |
| r2 | `M_0b5c5e04` | WIN | 10 /10 | 7 |
| r3 | `M_1cdd5763` | WIN | 8 /8 | 4 |

24 decision/72 checkpoint đúng đường SWAP, replay24/24;11 lựa chọn khác
BASIC được giữ cùng input trước hành động:7 TRADEOFF,4 INSUFFICIENT_DATA.
Không lấy số lượt/WIN/override làm nhãn chất lượng hoặc xác suất thắng.

## Đã gặp điều kiện cần kiểm, nhưng không có bound ghi trực tiếp

Kiểm chỉ các candidate trong summary thấy0 witness Health prefix. Rà thêm
toàn bộ scores bằng replay trên24 snapshot thật tìm được1 candidate:

- r1 lượt3, snapshot `2df7b3a8…`; HP ta79265/109491, quét có4 Máu hiệu dụng,
  geometry `CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY`, continuation chưa rõ.
- Candidate swap `(1,6)↔(1,7)`; trước sửa P `[0,1]`/UNKNOWN, sau sửa giữ
  `[0.18403947965281775,1]` cho cơ hội thu Máu theo HP thiếu. Không phải
  lượng HP hồi, sàn HP sau nước hoặc xác suất sống sót.
- Các feature khác giữ nguyên khi đối chiếu `_score` trước/sau. Candidate
  này không được chọn; nước thực là `(2,3)↔(2,4)`. Không có outcome thực của
  candidate thay thế để gán nhãn tốt hơn.

Native và replay cùng stage LOOKAHEAD_COMPLETE,3621 node,8 candidate được
đánh giá; cả24 snapshot khớp stage/node/count. Tuy vậy summary ở frame này
chỉ giữ2 candidate, không có candidate trên. `reasoning_runner._decision_summary`
chọn baseline/proposal và một số score đầu; còn lược candidate khi cần để
giữ12KB. Vì vậy không thể lấy việc summary không có witness để kết luận
bàn thật chưa xuất hiện điều kiện đó.

**Tầng chứng cứ: NATIVE_FRAME_OFFLINE_REPLAY_ONLY.** Đã có input game thật
và replay khớp để kiểm logic; chưa có chính bound của candidate này được
worker ghi trực tiếp. Giữ native acceptance của nhánh cụ thể là false,
không nâng replay thành witness trực tiếp. Đây là giới hạn độ phủ diagnostic,
không có bằng chứng gameplay lỗi ở các trận này.

## Dữ liệu giữ thêm

42 typed response,21 SWAP ACK trong đó19 có typed response bind đúng;
thiếu ở r2 lượt1/source2 và r3 lượt9/source18, nguyên nhân cụ thể UNKNOWN.
Không tự điền effect hoặc coi vắng capture là0 damage. Có37 khoảng tài
nguyên đủ published endpoint (17 LOCAL+20 BOSS):136 kiểm delta exact,4
mẫu cap/floor,89 lastStat khớp endpoint. Không biến chúng thành công thức.

Đã lưu cả snapshot/candidate hiếm để tái hiện, không cần tiếp tục đánh
ngẫu nhiên chỉ để tìm lại bàn này. Bước offline hợp lý tiếp theo là xem
cách giữ một witness nhánh ngắn trong diagnostic mà vẫn giữ budget và các
candidate bắt buộc, trước khi cần kiểm trực tiếp nữa. Đợt này không đổi
runtime, fit/train/build hoặc bật thêm lượt ngoài cap. Mega/Galaxy còn hoãn.

[Đóng cap](artifacts/demon_health_witness_20261120/closure.json) ·
[Độ phủ summary so với replay](artifacts/demon_health_witness_20261120/visibility_review.json) ·
[Snapshot và bound trước/sau](artifacts/demon_health_witness_20261120/derived_candidate_witness.json) ·
[Capture ACK](artifacts/demon_health_witness_20261120/capture_totals.json) ·
[Kiểm cuối](artifacts/demon_health_witness_20261120/final_verification.json).
