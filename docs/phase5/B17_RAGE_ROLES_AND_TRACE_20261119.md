# Nộ theo vai trò và log STAT_CHANGE/DESTROY — 19/11/2026

Đã kiểm riêng giả thuyết boss nhận đòn không tăng Nộ và người chơi nhận
khoảng 5 Nộ mỗi kiếm boss đánh. Chưa đưa công thức Nộ cố định vào adviser.

## Dữ liệu trước thay đổi

Có 21 khoảng nước ta với SWAP ACK, response và published endpoint khớp
match/epoch/Board/sequence/turn. Trong 13 khoảng có DAMAGE HP lên boss,
HP mất khớp lượng báo và Nộ boss không tăng ngoài POWER/STEAL đã ghi.
Có 10/13 khoảng không có POWER flow/Hút để che phần tăng đó. Tám khoảng
không DAMAGE cũng có residual Nộ boss bằng 0. Đây là bằng chứng cho nhóm
Priest cấp 131/Demon Aegis hiện tại, chưa đại diện cho mọi boss/pet/mode.

Trong 25 khoảng boss cũ, tám khoảng có DAMAGE lên ta. Giả thuyết
`+5 cơ sở +5 × tổng kiếm hiệu dụng báo trên wire` chỉ khớp 1/8. Kết quả
không xác nhận hoặc bác bỏ quy tắc theo **kiếm vật lý**: wire count,
multiplier x2 và cascade khác nhau. Có ca ba ô kiếm biết trước/11 đơn vị,
residual Nộ 20; ca bốn ô biết trước/năm đơn vị cũng residual 20. Mô hình
bàn trước nước chưa tái hiện đầy đủ kiếm sinh thêm do refill.

Quan sát cũ gồm 17 ca +5, sáu ca +20 và hai ca +35 vẫn được giữ. Gán 15/30
cho mỗi đòn hoặc full_power là giải thích sau sự kiện, chưa là công thức
server đã xác minh. `full_power=null` không có nghĩa là false.
54 observation cũ chuẩn hóa giống hệt sau khi bỏ đúng ba trường optional
trace mới; binding SWAP/ACK và diễn giải raw after giữ nguyên.
[Đối chiếu vai trò và số kiếm](artifacts/b17_rage_roles_20261119/roles_review.json).

## Bằng chứng reverse

Đúng DLL B17 SHA `bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`:

- `ApplyOp.MoveNext`, RVA `0xB2E9B0`, có nhánh STAT_CHANGE; gọi
  `ApplyStatChange`, RVA `0xB17460`, tại `0xB2F759`.
- `ApplyStatChange` đọc targetUsername/statType/delta/newValue, gọi
  `MatchService.ApplyServerStat`, RVA `0xB99E30`, với newValue tại `0xB17823`.
- `ApplyDestroySequenced.MoveNext`, RVA `0xB2AC70`, đọc positions[i][0/1]
  theo col,row và kiểm InBounds. Ý nghĩa phần tử đuôi còn UNKNOWN.
- HandleTurnStartInternal và SyncStatsFromWsSnapshot chưa chứng minh
  công thức tick/spend/reward chung của server.

RVA chỉ dùng đối chiếu tĩnh. Không thêm offset, chain, memory read hoặc
lời gọi method game. [Hash và assembly](artifacts/b17_rage_roles_20261119/static_resources.json).

## Collector và kiểm trực tiếp

Collector giữ STAT_CHANGE với target đã hash, stat/delta/newValue/reason/
source và index gốc; DESTROY giữ hai tọa độ đầu khi hợp lệ. Số thiếu là
null, không dùng fallback 0 của client. Không suy Sword/tag/multiplier từ
số tọa độ hoặc phần tử đuôi. Layout chưa biết được đánh dấu UNKNOWN, vẫn
giữ các combat step/stat update hợp lệ.

Hai trận BASIC được công bố và đóng riêng, mỗi phiên tối đa một trận.
Đã dùng hết 2/2; tổng lịch sử nhóm 10 trận, không reset cap cũ.

| Phiên | Source | Kết quả game | Kết quả collector |
|---|---|---|---|
| Đầu | `239a00c1…` | Thắng sau 13 nước, nhận thưởng/về phòng; 0 safe stop/recovery | 23 record bị từ chối với DESTROY_POSITIONS_DOMAIN; capture chưa đạt |
| Sau sửa | `e48e94d3…` | Thắng sau 8 nước, nhận thưởng/về phòng; 0 safe stop/recovery | 13 CAPTURED, 0 invalid; 66 STAT_CHANGE và 21 DESTROY |

Native cho thấy entry DESTROY dài ba phần tử; client dùng hai phần tử đầu.
Bản sửa giữ prefix đã xác minh và đánh dấu đuôi UNKNOWN. **87 test PASS**:
12 test mới ban đầu, hai test bổ sung sau lỗi native. Log 85 test bản đầu
được giữ riêng. Kiểm nullable/zero, coordinate order, redaction, input bất
biến, malformed/unknown, giới hạn 32 KB và tap vẫn cấp bàn 64 ô khi diagnostic
lỗi. Kiểm tap không thêm memory read.

So với source `de63bc05…`, chỉ production `combat_outcome_evidence.py` và
offline normalizer thay đổi; adviser, BASIC, input, PASS, reader và policy
giữ nguyên từng byte. Source hiện tại:
`e48e94d3302b95fd2b9d0c37ed7815bc50d23f0ffc9439bec1dbb4defffb5561`.
Chưa kiểm REASONING trên source mới, build hoặc rebind profile.

## Điều thấy trực tiếp trong trace mới

Có 30 POWER update: 13 bước delta +5, ba bước reason=FULL_POWER/delta −100.
Mười hai chuỗi trong cùng response khớp phép cộng delta; một chuỗi có dấu
hiệu chạm trần. Response seq 21 đặt Nộ ở 250, nhận +5 nhưng vẫn ở 250,
rồi trừ 100 với nhãn FULL_POWER xuống 150. Đây là thứ tự update client
nhận, chưa chứng minh thứ tự tính toán bên trong server.

Response seq 15 của boss không có SWAP/DESTROY được ghi, destroyedByTag
là null, nhưng có trừ Mana 160/Nộ 100, DAMAGE HP và update +30 Nộ cho ta
rồi +5. Nguồn skill/card cụ thể vẫn UNKNOWN vì không có cardId/skillCardId.
Cần tách loại đòn trước khi áp dụng quy tắc theo kiếm.

Tọa độ đã giữ chưa đủ tái hiện mọi cascade: còn thiếu full fall/spawn/
convert context và nghĩa phần tử đuôi. Không đưa 5/15/30 hoặc −100 thành
quy tắc dự đoán toàn cục. Điều kiện skill vẫn dùng tài nguyên thực từ game.
[Trace native có index và raw hash](artifacts/b17_rage_roles_20261119/trace_review.json).

Tool PID 6084 dừng ở 1/1, game ở Priest cấp 131/Coop_310394. Cài đặt người
dùng giữ nguyên. Tiếp theo kiểm phạm vi có thể ước lượng Nộ sau nước theo
vai trò, loại đòn, trần và transfer. Chưa train outcome/value/ranker hoặc
lấy WIN làm nhãn nước đi tối ưu.
[Verification và closure](artifacts/b17_rage_roles_20261119/verification.json).
