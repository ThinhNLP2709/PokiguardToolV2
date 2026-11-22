# Đóng kiểm logger và ngữ cảnh Demon — 21/11/2026

Đã hoàn thành đúng1 BASIC +1 Suy luận; cả hai WIN/nhận thưởng/về phòng
Priest131,0 safe stop/recovery/PASS. Cap mới2/2 đóng,còn0;tổng28 lượt thử.
Source28fa103c giữ480 Python nguyên byte;không sửa gameplay,train hoặc build.
Đây là kiểm chức năng/ghi dữ liệu,không chứng minh chất lượng bằng WIN hoặc
số lượt. Source/game/account alias/pet/boss giữ cùng phạm vi đã chuẩn bị.

## Trận và dữ liệu thực

| Mục | BASIC | Suy luận |
|---|---|---|
| Match | M_954b0aaa | M_457d5061 |
| Lượt ta/boss | 7/6 | 6/5 |
| Kết thúc bình thường | WIN/nhận thưởng/về phòng | WIN/nhận thưởng/về phòng |
| ACK swap thường | 6 | 5 |
| Typed response cho ACK | 5 | 5 |

BASIC có6 mẫu timing mới đủ exact sent/ACK; hồ sơ R mới max1 tạo từ đúng
các mẫu này và14 gate qualification hiện tại PASS. Không rebind proof,
profile hoặc mở cap cũ. Tool UI báo targetLevel131,khớp khai báo người dùng;
RoomDTO/room Properties giữ enemyPetLevel0. Không dùng0 làm cấp boss hoặc
coi khai báo131 là kết quả decode cấp tại đúng effect; identity boss1845
và stats chiến đấu được giữ riêng. Worker R6 decision/18 checkpoint,6/6 replay cùng
nước và search shape;worker1/1 reaped,37 event diagnostic được ghi đủ.
Lệnh cuối R được hủy khi trạng thái đã kết trận,không phải lượt bị bỏ.

23 typed observation,20 resource interval gồm9 LOCAL+11 BOSS. BASIC lượt1,
source2→response4 có immutable JSON được đọc và đưa qua queue nhưng
combatSteps không cung cấp (thiếu/null): UNAVAILABLE. Không gọi đó là0
damage hoặc khôi phục effect; chưa biết vì sao wire không cung cấp steps.
Không có mất identity trong normalization. R có5/5 ACK đủ typed response;
điều này không chứng minh toàn bộ effect server đều được thu.

## Hai logger mới đã được kiểm trực tiếp

85 step đã giữ presence fullPower:75 ABSENT/10 VALUE. Riêng DAMAGE ta→boss
có9 true và1 ABSENT/None. Chưa thấy false hoặc null tường minh,không biến
absence thành false hoặc suy chi phí/ngưỡng nộ.

Worker thực đã ghi4 mẫu gọn nhánh thu Máu,đại diện6 candidate đã chấm,
2 mẫu còn lại được ghi omitted. Cả4 mẫu khớp ID/action/P/HP/Máu với replay
cùng snapshot;summary lớn nhất11915/12000 byte. Đây là bằng chứng native
thật trên source28,không phải thêm field mới vào log lịch sử.

Lượt7 còn có candidate được chọn với P reason
DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY trong bản ghi đầy đủ. Nước(5,0)→(5,1)
giữ2 Máu hiệu dụng đợt quét đầu,P=[0.11277639258021206,1]. Nó trùng nước
BASIC: chứng minh nhánh đã được chấm/chọn,không chứng minh nhánh mới làm
đổi quyết định. Sent/ACK/response16 khớp exact;HEAL ghi7276,DAMAGE190995.
Đó là kết quả của nhánh thực đã chơi,không phải lượng hồi/damage đã được
adviser dự đoán. Không chia amount cho số viên đợt đầu để fit hệ số cả hành
động khi refill/chuỗi effect còn chưa rõ.

4 nước khác BASIC trên cùng pre-action state:2 TRADEOFF,2 INSUFFICIENT_DATA.
Giữ lợi ích/chi phí/unknown từng chiều,không gán nhãn tối ưu hoặc suy BASIC
sẽ thua. Không dùng4 override hay số lượt ít hơn làm bằng chứng tốt hơn.

## Ngữ cảnh pet đọc được và giới hạn

Một phép đọc riêng ngoài controller/preflight đã lấy được mẫu mở đầu R,
seq0/turn1;fence account/match/sequence/Active/actor-map và class đều qua.
Actor local1 có Active.PlayerStats.petData ID560,METAL,cấp12. Công trong
pet và stats chiến đấu đều1819;pet HP64407/Mana2571,stats chiến đấu có
maxHP109491/maxMana2771. Không cộng lại hai giá trị attack như hai nguồn
riêng. user-pet ID0 là giá trị DTO đọc được,không là chứng minh inventory ID.

Active.weakness=1.75,PetUserDTO.weaknessValue=1.22 và equipCounter đọc
[25,25,25,25,25]. Chưa xác minh ý nghĩa/công thức/chỉ mục từng hệ hoặc thứ
tự buff;không cộng/nhân các số này vào damage. Full gear/crit/buff và
context đúng lúc mỗi effect vẫn UNKNOWN. Mẫu riêng này không được gắn giả
vào từng response damage hoặc đưa vào model.

MatchPlayerSnapshotDTO type-info chưa được khởi tạo;probe không buộc khởi
tạo hoặc giải mã object khi thiếu class proof. Phần DTO giữ UNKNOWN. Một
probe boss bổ sung chạy sau khi combat đã hết bị từ chối NOT_ACTIVE_COMBAT;
không đọc stale boss/pet. Chưa có boss-element context mới từ phép đọc này.
Probe mất khoảng110.76ms riêng,không phải thời gian preflight hay qualification
của reader mới. Nó chưa được nối vào đường đọc production;reader cũ nguyên.
Low-level local_stats.is_local=null được giữ nguyên;ownership trong mẫu
nằm ở local_actor1 đã bind qua MatchService.Players và Active.playerStatsMap.

## Chuẩn bị lỗi đã được giữ lại

Computer-use lỗi kernel assets qua retry/reset. Trước GUI thật,các lệnh API
start thử gặp:target bị loại khi load preference,sai API snapshot trong
script giám sát,rồi Windows focus bị từ chối. Các slot basic/basic_control
đều0 trận và0 input FarmRunner,không có run.json;hai claim đã tạo được
retire riêng,không reset/tái dùng. Trước khi chuyển UI đã đọc lại đúng
phòng sạch,match_id=null. Đây là lỗi điều phối phép kiểm,không là lỗi giữa
trận của gameplay. Sau đó người dùng bấm Start trực tiếp ở hai GUI mới.

GUI BASIC idle/đã flush watermark trước khi đóng process. GUI R14420 hiện
dừng1/1,đúng lobby;không chạy thêm. Ordinary preferences nguyên. Game/pc
không bị ghi,patch hoặc gọi trực tiếp method/network.

## Điểm chốt

Đã kiểm xong fullPower presence,log gọn thu Máu và lấy được một mẫu pet
runtime có phạm vi. Không cần thêm trận chỉ để kiểm lại các logger này.
Mô hình damage/heal vẫn chưa đủ điều kiện:crit/buff/boss-element/effect-time
và holdout độc lập còn thiếu. Giữ các phần đó UNKNOWN;chưa train/nạp model
hoặc mở rộng Mega/Galaxy. Bước sau là thiết kế cách giữ context đã xác minh
cùng đúng nguồn hành động,không mặc định lấy nguyên mẫu mở đầu cho cả trận.

[Đóng phiên](artifacts/demon_context_native_20261121/closure.json) ·
[Same-state và witness native](artifacts/demon_context_native_20261121/feature_review.json) ·
[Context thực](artifacts/demon_context_native_20261121/reasoning/runtime_context.json) ·
[Kiểm cuối](artifacts/demon_context_native_20261121/final_verification.json).
