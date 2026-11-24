# G3 — chốt ba trận Suy luận trên Argilpus ngày 24/11/2026

## Kết quả và phạm vi

Run `80c268d3184b4d9eb71c59c928e90799`, Galaxy Dragon Knight G3 chính,
không tiến hóa, Solo Argilpus lv170, đủ điều kiện skill, Tự bảo vệ dưới 30%.
Source `ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`
giữ nguyên. Người dùng chọn phòng/pet và bấm Start; không dùng Computer Use.

**3/3 WIN**, 22 SWAP/22 ACK và ba skill, nhận thưởng và về BOSS_LOBBY,
`FARM_TARGET_COMPLETED`. Không technical abort/recovery, safe stop, input
sai lượt/trùng/misclick/partial, deadline safe stop, tiến hóa hoặc PASS.
Không mở thêm trận khi chốt dữ liệu.

| Match | SWAP/ACK | Skill tại lượt | Fresh context | Ordered response |
|---|---:|---:|---:|---:|
| `M_f1fd2a2f` | 7/7 | 15 | Đã kiểm | 1 |
| `M_4e825e33` | 6/6 | 13 | Đã kiểm | 1 |
| `M_9157a0aa` | 9/9 | 21 | Đã kiểm | Chưa lưu được |

Ba controller ghi `galaxyReasoningEnabled=true`; 22 SWAP có trace
`GALAXY_G3_*`, source identity và ACK tương ứng. Đây là nhánh Galaxy per-pet,
không phải common worker. Không dùng riêng setting `intelligence=basic`
hoặc bộ đếm writer UI bằng 0 để kết luận chỉ chạy BASIC.

## So cùng bàn

So cả 22 nước thực gửi với **replay nhánh resource production BASIC**.
Giữ nguyên AST nhánh/ranking, đã kiểm khớp 18/18 SWAP native trong cohort
G2 BASIC cùng source. Đây không phải native BASIC proposal và không chạy
lại toàn bộ input gate. Không dựng CardUI pointer hoặc giả quyền runtime.
Mỗi case thiếu tài nguyên skill, không tiến hóa/thẻ Attack thay thế, trên
ngưỡng bảo vệ; quyền PASS true/false đều trả cùng SWAP.

**11 nước đổi, 11 giữ**: mười TRADEOFF và một
`NO_KNOWN_MECHANICAL_SEPARATION`. Có bốn case giữ nhiều Khiên hiệu dụng
đã biết hơn trên bàn, không case giảm lượng này. Chỉ số đó không đồng
nghĩa nhận nhiều Khiên bảo vệ hoặc lợi ích thuần cho skill G3.

Ví dụ `M_9157a0aa` lượt 19: BASIC resource replay lấy 3 Mana + 3 Nộ +
10 Máu hiệu dụng; R lấy 6 Mana để đáp ứng thiếu hụt hiện tại. Cả hai không
để cơ hội Kiếm phản đòn đã biết. Đây là đánh đổi tốc độ tích Mana với tài
nguyên khác, không phải chứng minh phương án BASIC sẽ thắng chậm hơn.

Không SWAP R ăn Kiếm khi Nộ khác 0 trong cohort này. Known Sword reply
bằng BASIC ở cả 22 cặp, kể cả các bàn còn cơ hội Kiếm cho boss. Không
kết luận R đã loại mọi Kiếm đối thủ hoặc chơi tối ưu từ ba WIN. Refill,
sát thương tương lai, outcome thay thế và quality label giữ UNKNOWN.

## Skill và pha đọc từ game

Ba fresh context kiểm đúng `GALAXY_DRAGON_KNIGHT`, cost hiện hành
200 Mana/200 Nộ, board/stat/source trước dispatch. **Runtime thực công bố
pha next=1, maximum=3**, nguồn
`MatchService.Players.local.skillPhaseNext/Max/CardId`; planner ghi
`CURRENT_RUNTIME_CARD_PHASE`, không phải suy pha từ số lần tool bấm.

Tất cả trận kết thúc ngay sau skill đầu tiên. Chưa có pha 2/3, vòng lặp,
ấn tích lũy, thời hạn chống hút hoặc hành động sau skill. Không mở thêm
trận cùng boss chỉ để tăng bộ đếm; các khoảng trống được giữ trong bàn giao.
Mô tả pha 1 hoàn 250 Mana là kiến thức điều kiện; trace trước input ghi
`current_cost_credit_from_refund=0`, `refill_credit=0`. Không ứng trước
tài nguyên tương lai để chứng nhận đủ cost hiện tại.

Hai ordered response đã lưu đều báo:

- POWER -200, MANA -200 rồi MANA +250; sáu phép số học raw khớp tổng cộng,
  bốn endpoint local khớp mỗi response.
- DAMAGE 4.515.866, giữ nguyên nhãn server `damage_source=BOARD_DOT`.
  Boss còn 850.451/848.796 HP trước skill; số damage báo vượt HP còn lại
  không phải HP mất thực, không là công thức dùng chung.

Response trận thứ ba thiếu giữ UNKNOWN. Hai response có nguồn match/actor/
sequence nhưng thiếu wire card ID và terminal client anchor: **UNBOUND**,
0 strict wire-card, 0 conditional client-window match. Cost/refund khớp
không tự nâng binding. Skill giữ opaque (`cleared=null`, support UNKNOWN),
không biến thành mask rỗng hoặc damage 0 trong CommonProblem. Generic
receipt cost-before-DESTROY giữ UNKNOWN vì Galaxy không có DESTROY; raw
ledger phía trên mới là bằng chứng phép trừ và hoàn tài nguyên.

## Khoảng trống thứ tự lượt

Trận `M_9157a0aa` ghi boss lượt 16 tại 15:46:19.384Z, boss lượt 18 tại
15:46:21.513Z; response seq35 là hành động boss. Không có snapshot local
actionable lượt 17 được lưu, cũng không có PASS/deadline stop tương ứng.
Nguyên nhân game bỏ qua số lượt này UNKNOWN; không gán thành tool bỏ
lượt hoặc khẳng định đã chứng minh toàn bộ chuỗi lượt không có khoảng trống.
Các nước thực gửi vẫn có ACK, tool tiếp tục lượt 19 và kết liễu ở lượt 21.

## Artifact và điểm dừng

- [Closure](artifacts/g3_reasoning3_20261124_221447/review/closure.json),
  [ba pre-state và hai receipt](artifacts/g3_reasoning3_20261124_221447/review/evidence_pack.json).
- [22 cặp cùng bàn](artifacts/g3_reasoning3_20261124_221447/review/same_board_comparison.json),
  [kiểm so cùng bàn](artifacts/g3_reasoning3_20261124_221447/review/comparison_verification.json).
- [Verification](artifacts/g3_reasoning3_20261124_221447/review/verification.json):
  10 raw files kiểm hash, ba CommonProblem và hai receipt roundtrip khớp;
  source không đổi. Không tạo training/optimal label hoặc fit damage model.
- [Fixture skill](../../tests/fixtures/g3_native_reasoning3_20261124/cases.json),
  [fixture SWAP](../../tests/fixtures/g3_native_reasoning3_20261124/swaps.json).
- [Kế hoạch thu trước bàn giao](mega_galaxy_handoff_20261124/collection_plan.json).

Đủ ba trận G3 theo yêu cầu bổ sung. G1 đã đủ ba trận riêng; G2 giữ mốc
một trận Suy luận đã chốt. Còn G4 ba trận sau khi người dùng chọn pet/account.
Không tự tăng cap, mở trận mới, sửa runtime, build, commit hoặc push ở bước này.
