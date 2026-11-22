# Rà lỗi tỷ lệ sát thương và sửa capture event dài — 21/11/2026

Đã sửa việc một response có quá128 operation làm mất luôn combatSteps hợp
lệ. Hai lỗi dự báo đã được giải thích bằng dữ liệu TRAIN/TEST đang có:
weighted median chọn tỷ lệ của một response có crit, trong nhóm còn có tỷ
lệ bị chia cho số Kiếm prefix nhỏ hơn số Kiếm báo lại sau cả chuỗi. Không
sửa nhãn hoặc thay weights để làm đẹp hai TEST đã xem.

Source mới `19ed3f1af15b9db8227abeedb06e2c0da477bcb916557a0b1b8bfaec3766d56b`,
500 Python:5 file cũ sửa,493 file cũ giữ nguyên,2 file test thêm. Planner,
solver,thao tác input,quy tắc PASS và code mô hình v1 không đổi. Không attach
game,chạy thêm trận,mở cap hoặc build. Tổng lượt nghiên cứu đã đóng vẫn38.

## Bản sửa event dài

`combatSteps` và `ops` là hai phần độc lập trong cùng response. Trước đây
`_swap_operations` ném OPERATION_LIMIT khi thấy176ops,làm hỏng toàn bộ
capture dù combatSteps hợp lệ. Nay:

- Vẫn kiểm match/sequence/actor,server reject,kiểu/order/limit128 bước và
  budget32KiB như trước.
- Danh sách ops quá128 không được duyệt kể cả prefix;swap/resource operations
  để `null`,kèm `operation_projection.status=OMITTED`,count176,limit128,
  `complete=false`. Không xuất `[]` như thể đã đọc hết và không tăng limit.
- CombatSteps hợp lệ được giữ. Phần crit/HP operation cũng ghi OMITTED vì
  quá giới hạn duyệt;không đọc đuôi hoặc thêm memory query.
- Normalizer kiểm metadata omission,giữ lý do khi export và không coi phần
  operation thiếu là đủ để gán hiệu ứng hoặc quyết định của boss.
- Ops sai kiểu trong miền đang xét,combatSteps sai,step quá dài,byte quá lớn
  hoặc danh tính sai vẫn fail closed cho evidence. Board/input không bị đổi.

Fixture176ops chuyển INVALID/OPERATION_LIMIT thành CAPTURED với operation
OMITTED. Fixture là synthetic;raw JSON của gap native cũ không còn nên
**chưa hồi phục response cũ**,chưa xác minh nhánh mới trên event dài thật.
[Đối chiếu trước/sau](artifacts/damage_long_event_fix_20261121/synthetic_long_event.json).

## Hai dự báo sai

Cả hai TEST `M_3801761d` dùng cùng ba hàng TRAIN sau:

| TRAIN | Kiếm prefix biết trước | Tổng Sword tag báo lại | DAMAGE component | Tỷ lệ chia prefix | Dấu hiệu |
|---|---:|---:|---:|---:|---|
| `M_c2dac07a`,turn11 | 8 | 8 | 305.592 | 38.199 | crit absent,có FULL_POWER |
| `M_e318c30a`,turn7 | 3 | 3 | 171.896 | 57.298,67 | BOSS_HP có crit=true |
| `M_0b87559f`,turn7 | 3 | 7 | 267.393 | 89.131 | 3 DESTROY,tổng tag không khớp prefix |

Weighted median đã chọn57.298,67. Nhân6 Kiếm dự343.792 thay vì component
ghi152.796;nhân4 dự229.194,67 thay vì152.796. Mẫu cuối chia toàn bộ component
cho3 dù response báo7 Sword;phép chia267.393/7=38.199 giải thích được mức
nhiễu số học,không chứng nhận damage của riêng từng wave hoặc sửa target.
Các tag sau response cũng không tự chứng nhận đơn vị multiplier/trình tự
refill. Crit cùng response giữ nguyên step-attribution UNKNOWN.

Đã thêm `ratio_support` vào công cụ review offline:giữ riêng prefix/post
tags,descriptive ratio,crit membership và cờ multi-DESTROY. Ghi rõ không
thiết lập hệ số sát thương nhân quả,không thêm feature trước nước,không sửa
target. Absent crit vẫn UNKNOWN,không thànhfalse. Toàn49 action/24 target
được rà,7 recorded target có cờ mismatch Sword hoặc crit=true.
[Các witness và cờ](artifacts/damage_long_event_fix_20261121/ratio_failure_findings.json).

Rà ordered resources trên6 trận có73 interval riêng biệt:224 delta khớp
báo cáo,14 cap/floor pattern,17 FULL_POWER updates. Không có unexplained
delta trong các interval đủ dữ liệu;129 resource không có STAT update giữ
riêng. Đây là quan sát sau hành động,không biến thành luật nộ mỗi viên hay
ngưỡng server. Không trộn index của combatSteps vàops.
[Bằng chứng thứ tự](artifacts/damage_long_event_fix_20261121/ordered_resource_review.json).

## Kiểm chứng và điểm chốt

- 302 test khác nhau PASS trong308 lần chạy;11 test mới cho event dài và
  ratio-support. Đã kiểm board export3 loại response,không có target query
  thêm,các phần resource/PASS/normalization downstream đều đạt.
- 31 fixture cũ trả toàn bộ capture giống hệt;84 typed response native cũ
  normalize giống hệt. Hai dataset TRAIN/TEST đóng băng giữ nguyên.
- 64 forecast v1 tái hiện nguyên,both model artifacts giữ SHA cũ. Không fit
  model mới trên native data hoặc điều chỉnh policy theo9 target TEST.
- 1.624 pin checks input/evidence đạt;5 active file được sửa có before-copy
  đúng SHA. Source,raw,profile và caps của các bài cũ vẫn giữ lịch sử riêng.

[Audit](artifacts/damage_long_event_fix_20261121/audit.json),
[test inventory](artifacts/damage_long_event_fix_20261121/test_inventory.json).

Hai lỗi reference không phải lỗi nước đi live:predictor v1 vẫn ngoài
gameplay,guarded vốn đã abstain cả hai;abstention không gây SAFE_STOP.
Chưa có model mới tốt hơn. Đã chốt yêu cầu cho lần thiết kế tiếp:không coi
toàn bộ component/prefix là hệ số sạch,cần xử lý hiệu ứng chưa quy thuộc
và biến thiên crit bằng bất định rõ ràng. Không đưa tổng tag/crit sau nước
vào request để giả vờ biết trước. Hai TEST hiện đã xem chỉ còn dùng làm
DEVELOPMENT cho nghiên cứu mới,không tái dùng để tuyên bố holdout tốt.

Mốc offline này đóng. Source mới chưa native;profile/qualification source25a
không được rebound sang19ed. Khi mở một bài live mới phải tạo đúng profile
cho source mới và cap riêng;không mở lại6 lượt đã hết. GUI26832 là phiên
25a đã dừng2/2 ở bài trước,không phải chứng nhận bản sửa. Chưa build.
