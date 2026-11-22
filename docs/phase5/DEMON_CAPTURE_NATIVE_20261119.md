# Demon — kiểm trực tiếp chỉ mục capture, 19/11/2026

Hoàn tất đúng **1 BASIC + 1 Suy luận** trên source
`b3ab48cea3da7ae0751912004650608eebabb10e75e292902ba4ed5e2042a546`.
Cả hai WIN, tự nhận thưởng và về đúng lobby; không safe stop, technical
recovery hoặc lỗi input. Chỉ mục metadata hoạt động trên dữ liệu thực.
**Vẫn còn một response hiệu ứng chưa được thu**, không tuyên bố đã sửa
đầy đủ vấn đề coverage hoặc đã cải thiện chất lượng chơi trong đợt này.

**Bổ sung sau khi đóng phiên:** đã sửa riêng exporter offline để giữ8 boss
interval và15 resource interval R bị loại nhầm vì hai UNAVAILABLE có board
scope hợp lệ. Source sau sửa là `86c22524…`; mọi runtime file giữ nguyên,
không đổi native proof/profile source `b3ab48ce…`. Các con số exporter phía
dưới là kết quả được archive tại lúc đóng phiên, không bị ghi đè.
[Bản sửa offline và giới hạn](DEMON_UNAVAILABLE_SCOPE_20261119.md).

## Phạm vi phiên mới

Solo Priest lv131/ID1845, room `Coop_300394`, Demon Aegis thường ID560,
ăn Khiên, ngưỡng danh nghĩa 4 Kiếm hiệu dụng, không tiến hóa, passive.
Build B17 GameAssembly SHA
`bb456547ac1df7f5b036c3d738496e9c375b977a309547a80b7e7dd87b411bc7`.
Account alias và loadout được kiểm trong prepared files. Chữ ký stat đầu
hai trận khớp: ta maxHP109491/Mana2771/Nộ250/ATK1819; boss
maxHP581505/Mana540/Nộ250/ATK766. Full gear vẫn UNKNOWN.

Giữ nguyên các khoảng random và tọa độ tối đa10%. Đã dùng computer use
đóng popup sức khỏe trong lobby, đóng tool cũ đã hoàn tất, mở/chạy hai UI
cách ly và kiểm kết thúc. Không sửa ordinary preferences hoặc game files.
UI cuối PID1688 dừng1/1; game PID14372 ở đúng phòng, không modal chặn.

Cap mới2/2 đã dùng và đóng; 15 lượt trước giữ nguyên, tổng ledger17.
Không tái mở cap cũ. Source và toàn bộ file mã nguồn giữ nguyên trong phiên.

## Vận hành và kiểm quyết định

| Mục | BASIC | Suy luận |
|---|---:|---:|
| Match | `M_29c474a7` | `M_3354d4e8` |
| Lượt ta / boss | 7 / 6 | 10 / 9 |
| SWAP gửi / ACK | 7 / 6 | 8 / 7 |
| Nước terminal chuyển state trước ACK | 1 | 1 |
| PASS chủ động được server xác nhận | 0 | 2 |
| Safe stop / recovery | 0 / 0 | 0 / 0 |

Hai nước terminal có HP boss0 và UI WIN phù hợp; không gọi đó là bỏ nước.
Không so 7 với10 lượt của hai bàn khác nhau để đánh giá hơn kém.

Qualification mới đúng source/host đủ14 gate PASS. BASIC mới tạo6 mẫu
SWAP sent/ACK hợp lệ cho profile riêng, không rebind profile cũ. Profile
chỉ có họ input SWAP, tối đa1 trận R. PASS vẫn qua guard hiện có, không
thêm quyền input hoặc đổi luật game.

R có10 decision, khớp10/10 replay hiện tại và hành vi thực:8 SWAP có24
ROOT/FRESH/FINAL;2 PASS có4 ROOT/FINAL đúng đường chờ hiện có. Cả59 record
AI được ghi đủ, không mất/fault; worker1/1 reaped, summary max11366/12000 B.
Bảy hành vi khác BASIC:5 SWAP đều ACK,2 PASS đều được server xác nhận.
Không có nhánh prefix-floor thực thi ở corpus mới; bằng chứng prefix đã
chọn ở phiên trước vẫn thuộc source `1bd824c2…` và match cũ.

Script review ban đầu kế thừa giả định PASS=0 từ trận trước. Đã sửa riêng
script bằng chứng để bind PASS theo session/match/turn/sequence/board hash,
decision và receipt thực tế; không sửa controller hoặc log gốc. Không gán
FRESH giả cho PASS hoặc ghi PASS thành một lần gửi input.

## Hai PASS có bằng chứng từ game

Ở lượt15 và17, `MATCH_AFK_WARN` xác nhận idle1/3 rồi2/3, authoritative,
fresh và có turn-end. Không gửi gameplay input trong lúc chờ. Sau đó lượt19
tool đi SWAP, không có lượt bỏ thứ ba; `wrongThirdPassCount=thirdPassCount=0`.

Cùng bàn trước hai lần PASS, ta Nộ250/250, HP khoảng75% rồi72%; mô hình đã
biết không có nước kiếm trên bàn. BASIC chọn4 Nộ hiệu dụng; R chọn giữ bàn,
không tự nhận thêm giá trị khi Nộ đã đầy. **Đánh đổi:** nhường boss cơ hội
lấy tài nguyên, không lấy thêm Mana/Máu và không làm mới bàn. Không chứng
nhận PASS tối ưu hoặc dùng kết quả WIN để gán nhãn tốt cho nó. Vẫn giữ
game-state làm nguồn quyết định được bỏ lượt, không thêm giới hạn cứng.

## Capture: đã phân biệt được hai tình huống

| Mục | BASIC | Suy luận |
|---|---:|---:|
| Metadata theo response | 12 | 19 |
| Typed CAPTURED được giữ / chuẩn hóa | 12 / 12 | 17 / 17 |
| UNAVAILABLE có lý do cụ thể | 0 | 2 |
| Nước ACK có typed response | 5 / 6 | 7 / 7 |
| Lỗi/drop/conflict chỉ mục | 0 / 0 / 0 | 0 / 0 / 0 |
| Offer qua board / drain qua queue | 8 / 4 | 12 / 7 |

Mọi typed response giữ được đều có metadata đúng raw SHA và dấu delivery;
normalizer không làm mất identity nào. Chỉ mục không phát sinh read-error
counter; toàn bộ mục giữ được là immutable JSON.

**Khoảng trống BASIC:** lượt5, source10 → published12 có ACK và state sau,
nhưng không có observation theo response12, không có typed capture hoặc
rejection tương ứng. Đã loại được giả thuyết chỉ mất ở bước export/normalize
trong ca này. Chưa chứng minh callback hoàn toàn không tồn tại, bị dọn lúc
nào, hoặc sampler bỏ qua ở bước nào; nguyên nhân chính xác vẫn UNKNOWN.
Không suy nguyên nhân mới sang ba gap của match cũ, không khôi phục effect.

**Hai response của PASS:** seq32/37 được đọc JSON thành công, board-parsed
và offer đầy đủ, nhưng raw envelope không có `combatSteps`. Chỉ mục ghi rõ
`UNAVAILABLE/COMBAT_STEPS_ABSENT`. Đây là trường hợp khác với một response
không được quan sát; không bịa effect0 hoặc biến board thành chuỗi hiệu ứng.

Exporter boss intervals hiện còn bảo thủ: hai UNAVAILABLE không có identity
trong chính outcome record khiến8 khoảng R bị loại cùng1 khoảng không có
exact boss swap. Chỉ mục mới có sequence32/37 riêng, nhưng chưa tự dùng
thay effect hoặc tự thu hẹp exclusion khi chưa kiểm đường bind. Vì vậy giữ
6 boss interval BASIC/0 R theo exporter hiện tại, không nhận vơ9 interval.
Resource audit giữ10 khoảng/35 update:34 exact+1 cap/floor,23 endpoint khớp;
không dùng gross gains làm net hoặc fit công thức damage/Nộ.

## So sánh trên cùng bàn

Đã kiểm cả7 cặp override:3 TRADEOFF,4 INSUFFICIENT_DATA, không nhãn optimal.
Ví dụ lượt1: BASIC lấy3 Hút, để lại phản công4 Kiếm trong phần bàn đã biết;
R lấy3 Kiếm, phần phản công biết còn0 Kiếm. Cost là bỏ3 Hút và cho boss
cơ hội lấy Hút thay thế. Refill và sát thương vẫn UNKNOWN.

Lượt3: thay3 Hút bằng quét2 Kiếm+2 Nộ+7 Khiên+5 Máu+8 Hút theo geometry
đã khai báo; ô refill chưa biết tăng3→24, chưa thể gọi lợi thế toàn bộ tương
lai. Các cặp còn lại giữ đủ benefits/costs/unknowns trong feature review.
Không đưa refill hoặc state sau thật vào phép chọn nước giả định.

**Bước tiếp theo offline:** rà đường ownership/lifetime của callback và
điều kiện lọc root để tìm bằng chứng cho response chưa được quan sát; đồng
thời kiểm phạm vi exclusion của `COMBAT_STEPS_ABSENT` bằng metadata có sẵn.
Không tăng reads, nới giới hạn hoặc sửa nhịp sampler chỉ vì suy đoán. Không
cần chạy thêm trận trước bước rà offline này. Demon tiếp tục ưu tiên;
Mega/Galaxy hoãn, không train/build trong phiên.

[Closure và input SHA](artifacts/demon_capture_native_20261119/closure.json) ·
[Chỉ mục/ACK coverage](artifacts/demon_capture_native_20261119/capture_coverage.json) ·
[Cặp cùng bàn và resource audit](artifacts/demon_capture_native_20261119/feature_review.json) ·
[PASS/decision receipt](artifacts/demon_capture_native_20261119/reasoning/closure.json) ·
[Qualification](artifacts/demon_capture_native_20261119/qualification/qualification.json).
