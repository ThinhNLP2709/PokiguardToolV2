# G2 — chốt Suy luận và so cùng bàn ngày 24/11/2026

## Kết quả kỹ thuật

Run `d475136cd56e4952bf66024e56c6b321`, match `M_cb26762e`, Galaxy Glank
chính, không tiến hóa, Solo Genbu lv161, đủ điều kiện skill, Tự bảo vệ dưới
30%. Source giữ nguyên
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.

**WIN 1/1**, 16 SWAP/16 ACK, 3 skill tại lượt 9/27/37, nhận thưởng và về
BOSS_LOBBY, `FARM_TARGET_COMPLETED`. Không technical abort/recovery, sai
lượt, duplicate, misclick, partial input, deadline safe stop hoặc PASS.
Có một đề xuất bị hủy trước input do fresh policy đổi; controller vẫn
hoàn tất bình thường. Không coi lần hủy đó là input sai hoặc safe stop.

Session ghi `GALAXY_PER_PET_TACTICS`, controller có
`galaxyReasoningEnabled=true`; toàn bộ 16 SWAP có trace `GALAXY_G2_*`.
Đây là nhánh chiến thuật G2 hiện có, **không phải common worker**. AI UI
observation/writer count bằng 0 của nhánh này không chứng minh R chưa chạy;
phải kiểm session, cờ controller và quyết định có ACK.

19 lượt local so với 21 lượt của BASIC chỉ là số mô tả. Không dùng khác
biệt số lượt hoặc hai WIN làm chứng minh Suy luận tốt hơn.

## BASIC và nước R thực gửi trên cùng bàn

Log nhánh G2 không ghi proposal BASIC cạnh proposal R như common worker.
Để tránh giả thành native baseline, bộ so được ghi rõ là **replay nhánh
chọn tài nguyên của BASIC**, so với nước R thực gửi/ACK trên cùng board,
stats, chi phí và cấu hình. Không gọi lại R planner để thay nước đã live.

Nhánh resource được trích nguyên AST production; chỉ đổi phần serialize
return cho công cụ offline. Không giả CardUI pointer, không cấp runtime
gate. Trước khi so đã kiểm nhánh này khớp **18/18 SWAP native của trận
BASIC trước**. Cả 16 trạng thái R thiếu tài nguyên skill, không tiến hóa,
không thẻ Attack thay thế và HP trên ngưỡng bảo vệ; quyền input đã được
native controller xử lý, không replay lại như một authorization mới.
Cho phép/không cho phép PASS đều trả cùng một SWAP trong các case này.

Kết quả: **7 nước khác BASIC resource replay, 9 nước giữ nguyên**. Cả 7
khác biệt là TRADEOFF, không tạo nhãn nước tốt nhất hoặc training label.

| Lượt | BASIC resource replay | R thực gửi | Khiên hiệu dụng còn lại đã biết: BASIC / R |
|---|---|---|---|
| 11 | 4 Nộ | 3 Mana | 13 / 13 |
| 17 | 5 Hút | 4 Máu + 3 Hút | 14 / 14 |
| 19 | 5 Hút | 4 Máu | 16 / 16 |
| 21 | 4 Khiên | 3 Mana | **15 / 19** |
| 23 | 5 Hút | 9 Mana | 21 / 21 |
| 25 | 8 Nộ | 4 Nộ | 17 / 17 |
| 31 | 5 Hút | 9 Máu | 19 / 19 |

Đơn vị bảng là viên hiệu dụng. Lượt 21 có bằng chứng giữ Khiên để dành
giá trị skill, đánh đổi giáp nhận ngay. Các nước khác thể hiện đổi ưu tiên
tài nguyên/hồi phục, không tự chứng minh lợi ích ròng. Không nước nào làm
giảm Khiên còn lại đã biết so với BASIC resource replay trong cohort này.
Không có SWAP R ăn Kiếm khi Nộ khác 0. Cơ hội Kiếm đã biết của boss không
giảm so với BASIC trong các cặp này; không tuyên bố R loại bỏ mọi Kiếm boss.
Refill, damage thay thế và kết quả toàn trận phản thực tế vẫn UNKNOWN.

## Ba phản hồi skill có nguồn

Đã ghép ba fresh context trước dispatch với board đã công bố và giữ riêng
ba phản hồi có thứ tự trong cửa sổ log duy nhất. Phản hồi thứ ba nằm trong
`dispatcher_board_snapshot_offered.combatOutcome`, không phải chỉ trong
`dispatcher_combat_outcome`; không bỏ sót khi chỉ lọc một loại event.

| Lượt | Khiên hiệu dụng trước dùng | DAMAGE báo | BLOCK báo | Hồi Mana báo |
|---|---:|---:|---:|---:|
| 9 | 16 | 528.000 | 0 | 100 |
| 27 | 17 | 561.000 | 0 | 100 |
| 37 | 18 | 591.390 | 2.610 | 100 |

Cả ba phản hồi trừ 200 Mana/200 Nộ theo raw operation trước khi cộng lại
100 Mana. Ledger có tổng 10 phép số học khớp; bốn endpoint HP/Mana/Nộ/Khiên
khớp ở mỗi phản hồi. Phản hồi cuối báo HP boss bằng 0, giữ BLOCK riêng
khỏi DAMAGE; không gọi DAMAGE là lượng HP thực mất nếu có overkill.
Không có DESTROY/SWAP operation trong ba phản hồi được lưu, không đồng
nghĩa quan sát đủ mọi hiệu ứng/buff hoặc chứng minh toàn bộ bàn bất biến.

Các mẫu cùng account/boss này phù hợp 33.000 cho mỗi Khiên hiệu dụng khi
cộng riêng BLOCK và DAMAGE; mẫu BASIC 11 Khiên/363.000 cũng phù hợp.
Đây là quan sát có scope và card binding chưa chắc chắn, **không phải
công thức damage chung** hoặc lý do thay mô tả danh nghĩa trong gameplay.
Chưa tách được hệ số theo level, boss, buff hay các điều kiện khác.

Cả ba response thiếu card ID, primitive trả post-state cũ nên vẫn
**UNBOUND**; 0 strict wire-card match, 0 conditional client-card window.
Không nâng binding nhờ cost hoặc con số damage khớp. Mỗi checkpoint
retained ngay sau primitive vẫn ghi 0, nhưng normal drain/board export đã
lưu đủ ba response sau đó. Không dùng checkpoint 0 làm chứng cứ skill lỗi.

## Artifact và kiểm lại

- [Final closure](artifacts/g2_reasoning1_20261124_211023/review/final_closure.json).
- [16 cặp cùng bàn, parity BASIC 18 nước](artifacts/g2_reasoning1_20261124_211023/review/same_board_comparison.json).
- [Ba pre-state và ba skill receipt](artifacts/g2_reasoning1_20261124_211023/review/evidence_pack.json).
- [Kiểm receipt và source](artifacts/g2_reasoning1_20261124_211023/review/verification.json), [kiểm so cùng bàn](artifacts/g2_reasoning1_20261124_211023/review/comparison_verification.json).
- [Fixture skill](../../tests/fixtures/g2_native_reasoning1_20261124/cases.json), [fixture SWAP](../../tests/fixtures/g2_native_reasoning1_20261124/swaps.json): không holdout độc lập hoặc nhãn chất lượng.

Đã kiểm hash 8 file raw, roundtrip ba CommonProblem skill + 16 cặp SWAP,
receipt tính lại khớp. Chỉ thêm dữ liệu/docs/scratch dưới temp/reasoning;
không sửa production code, weights, reader, input, PASS, build hoặc version.

## Điểm chốt

Đạt bài kỹ thuật giới hạn **G2 chính, không tiến hóa, Genbu lv161** và có
bằng chứng cơ học giữ Khiên trên cùng bàn. Không mở rộng sang mọi Galaxy,
G1/G3, route có tiến hóa, setup chờ skill, cứu nguy HP thấp hay rollout
common worker. Không fit/promote damage/heal model hoặc tự tăng cap live.

Đã có dữ liệu đủ để tiếp tục bàn giao offline cho lõi chung; không cần lặp
Genbu chỉ để tăng số trận. G1/G3 cần bài riêng theo account sẵn có khi quay
lại kiểm pha; không dùng G4 thay cho các Galaxy dùng thẻ.
