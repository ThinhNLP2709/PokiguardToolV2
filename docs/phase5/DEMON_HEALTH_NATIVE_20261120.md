# Demon — đã kiểm source mới bằng1 BASIC và1 Suy luận

Đã tự mở tool, chạy và đóng đúng **2/2 lượt thử mới** theo yêu cầu. Hai trận
đều WIN, nhận thưởng và về đúng phòng Priest;0 safe stop/recovery/PASS hoặc
lỗi input. Tổng lịch sử23 lượt, cap mới còn0. Không mở thêm trận, build,
train hoặc rebind hồ sơ cũ.

Source `61bead5bf7a1fd8651e4d8b2b129e2b2c9c5d0db71559b25b6a27b1c129c596b`
giữ nguyên477 file Python suốt phiên. B17, Solo Priest cấp131/ID1845,
Demon Aegis thường560, ăn Khiên, ngưỡng4 Kiếm hiệu dụng, không tiến hóa;
room `Coop_802270`. Stats danh nghĩa hai pha khớp: ta109491 HP/2771 Mana/
250 Nộ/1819 Attack; boss581505/540/250/766. Full gear vẫn UNKNOWN.

Computer use chỉ tắt2 popup sức khỏe, vào đúng target đã xác minh read-only,
đóng UI hoàn tất trước đó và bấm Start trên UI từng pha. Không tự đi nước
trong game. Request/profile/log nằm riêng; ordinary preferences giữ nguyên.
Game và tool cuối phiên ở phòng boss, toolPID8792 đã dừng đủ1/1.

| Pha | Match / run | Kết quả kiểm |
|---|---|---|
| BASIC | `M_6e56d820` / `d6925b1b03b44dea9dde97146cb92eb3` | WIN,14 lượt ta/13 boss,13 ACK +1 terminal |
| Suy luận | `M_ddc2a1d4` / `803695a3d7d04b7c94af3fb31f89ad98` | WIN,5 lượt ta/4 boss,4 ACK +1 terminal |

Hai bàn khác nhau: **không dùng14 so với5 lượt, WIN hoặc số override để
kết luận Suy luận hiệu quả hơn**.

## Chức năng đã kiểm và giới hạn

Qualification đúng source mới qua14 gate;100 triple synthetic lớn nhất
1,3794ms, không phải timing native. BASIC mới có13 ACK timing hợp lệ.
Profile R riêng max1 được dựng từ đúng control đó, không cài vào prefs
thường. R có5 decision/15 checkpoint, replay5/5 đúng actual action,2 nước
khác BASIC trên cùng snapshot; worker1/1 reaped, diagnostic31 record không
mất/fault. Summary lớn nhất11623/12000 byte.

Nhánh response identity mới đã được quan sát trực tiếp: BASIC response4
UNAVAILABLE/COMBAT_STEPS_ABSENT vẫn giữ match/sequence/raw-SHA và không có
effect giả. Exporter giữ đúng phạm vi; cả case có16 boss-board interval và
30 khoảng tài nguyên (14 LOCAL+16 BOSS), không loại cả phiên vì một response
thiếu steps. Đây là native proof có phạm vi cho identity; không chứng minh
thu đủ mọi response hoặc đầy đủ mọi effect của server.

**Nhánh Health prefix mới chưa được quan sát trong các summary đã ghi**:
0 candidate trong5 snapshot có reason `DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY`.
Các nước quét được chọn đều có `unresolved_local_effect=false`, nên không
cần sàn P mới dành cho residual chưa rõ. Không tuyên bố nhánh đó đã được
nghiệm thu native;8 test mới và replay offline vẫn là bằng chứng của nó.
Không chạy thêm tự động chỉ để cố làm nhánh này xuất hiện.

## Hai nước khác BASIC trên cùng bàn

Các lượng viên dưới đây là hiệu dụng theo phần bàn mô hình được, không là
tài nguyên ròng hoặc công thức damage.

- **Lượt1:** BASIC chọn3 Hút. R quét được4 Hút cùng3 Mana,5 Nộ,7 Khiên,
  5 Máu, không Kiếm. Nhánh thực ghi HEAL4548 và POWER+100. Adviser có thể
  chọn nước chuẩn bị tài nguyên dù setting tham chiếu4 Kiếm; không cố bỏ
  lượt chỉ vì chưa có đòn quét Kiếm. Phần refill chưa biết tăng3→24 ô.
- **Lượt7:** trước nước ta84616/109491 HP, Nộ155; boss467157 HP. BASIC
  chọn7 Hút. R giữ cùng7 Hút, thêm3 Kiếm hiệu dụng (2 viên vật lý),6 Mana,
  2 Nộ,8 Khiên,4 Máu. Nhánh được chơi có exact ACK/typed response16 và hai
  published endpoint; ghi DAMAGE114597, HEAL3638, POWER155→195→95 với
  update−100 nhãn FULL_POWER. Các amount này là kết quả đã ghi, không tự
  gọi HEAL là số HP tăng ròng hoặc biến chúng thành formula.

Ở lượt7, refill chưa biết6→24 ô và có thể để boss ăn3 Hút ở một phản hồi
đã biết. Không ghép maxima tài nguyên của nhiều phản hồi thành một đòn
boss. Cả hai cặp vẫn được bộ so sánh xếp INSUFFICIENT_DATA vì khác horizon/
refill; outcome của nhánh BASIC giả định không được quan sát. Giữ lợi ích
đã biết và đánh đổi rõ ràng, không tạo nhãn tối ưu hoặc label training.

## Chất lượng capture

Giữ32 typed response, chuẩn hóa32/32; thiếu effect ở2/17 ACK:

- BASIC lượt1/response4: đã quan sát JSON nhưng `combatSteps` vắng; có
  response identity mới hợp lệ. Giữ UNAVAILABLE, không biến thành0 damage.
- R lượt5/response12: không có scoped observation. Có ACK và published
  state; nguyên nhân cụ thể vẫn UNKNOWN, không chứng minh callback vắng.

Không index conflict/capture fault hoặc normalization loss. Reader giữ
251/91 root event và6/4 error event trong hai nhóm bảo vệ, không omitted;
có thêm210/42 event trước legacy tail. Lịch sử không liên tục mọi read và
không được dùng để gán nội dung cho response chưa quan sát.

## Điểm chốt

Đã kiểm chức năng SWAP/adviser/identity trên source mới trong đúng nhóm
Demon ăn Khiên này. Chưa chứng nhận độ ổn định dài hạn, tất cả target,
nhánh Health prefix chưa xuất hiện hoặc mô hình damage có hiệu chuẩn.
Tiếp tục offline từ dữ liệu net-resource và hai cặp cùng bàn đã bind;
giữ phần thiếu UNKNOWN. Mega/Galaxy hoãn; không mở cap bù hoặc thay PASS.

[Đóng cap](artifacts/demon_health_native_20261120/closure.json) ·
[Cặp cùng bàn](artifacts/demon_health_native_20261120/feature_review.json) ·
[Outcome nhánh thực](artifacts/demon_health_native_20261120/selected_outcome_review.json) ·
[Kiểm nhánh Health/identity](artifacts/demon_health_native_20261120/health_feature_review.json) ·
[Coverage](artifacts/demon_health_native_20261120/capture_coverage.json) ·
[Kiểm cuối](artifacts/demon_health_native_20261120/final_verification.json).
