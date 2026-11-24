# G1 — chốt ba trận Suy luận trên Genbu ngày 24/11/2026

## Kết quả và phạm vi

Run `b75e18b43cd94e9cb14d7da94fe1109d`, Galaxy Risky G1 chính, không tiến
hóa, Solo Genbu lv161, đủ điều kiện skill, Tự bảo vệ dưới 30%. Source
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7` giữ nguyên.

**3/3 WIN**, 21 SWAP/21 ACK, ba skill, nhận thưởng và về BOSS_LOBBY,
`FARM_TARGET_COMPLETED`. Không technical abort/recovery, sai lượt, input
trùng/misclick/partial, deadline safe stop hoặc PASS. Có một đề xuất đổi
ở fresh reread trước input; controller tiếp tục bình thường.

| Match | SWAP/ACK | Skill | Trạng thái trước skill | Ordered response |
|---|---:|---:|---:|---:|
| `M_50670e26` | 6/6 | 1 | Đã kiểm | Chưa lưu được |
| `M_28911553` | 7/7 | 1 | Đã kiểm | 1 |
| `M_a0eed95e` | 8/8 | 1 | Đã kiểm | 1 |

Session là `GALAXY_PER_PET_TACTICS`; ba controller ghi
`galaxyReasoningEnabled=true`, 21 SWAP có trace `GALAXY_G1_*` và ACK.
Không phải common worker; không dùng bộ đếm writer UI bằng 0 của nhánh
per-pet để kết luận chỉ chạy BASIC.

## So cùng bàn

So cả 21 nước thực gửi với **replay nhánh resource production BASIC**,
giữ phân biệt với native BASIC proposal. Reuse nguyên AST nhánh/ranking,
đã đối chiếu khớp 18/18 SWAP trong cohort G2 BASIC trên cùng source; không
gọi lại R để thay quyết định đã live. Cả 21 case thiếu tài nguyên skill,
không tiến hóa/thẻ Attack thay thế và trên ngưỡng bảo vệ. Quyền PASS true
hoặc false đều cho cùng kết quả; không giả input gate/CardUI pointer.

**7 nước khác, 14 nước giữ BASIC resource replay.** Trong bảy nước đổi:
sáu TRADEOFF và một `REVIEW_IMMEDIATE_COST_WITHOUT_MEASURED_GAIN`.
Case cần rà là `M_50670e26` lượt 3: cả hai lấy 3 Mana; nhánh R để cơ hội
Nộ hiệu dụng đã biết của boss 4 thay vì 3, chưa có lợi ích đo được ở các
chiều hiện tại. Giữ làm regression cần xem xét, không tự gán nhãn thua,
không sửa weights chỉ từ một bàn hoặc suy thắng phản thực tế.

Không SWAP R ăn Kiếm khi Nộ khác 0. Các nước đổi còn lại có đánh đổi về
Máu/Hút/Khiên/tài nguyên; số WIN và lượt 7/8/9 không chứng minh R tối ưu.
Refill, lượng tài nguyên ròng và outcome của phương án thay thế UNKNOWN.

## Skill, pha và RNG

Ba fresh context xác minh thẻ `GALAXY_RICKY`, chi phí hiện hành 200
Mana/200 Nộ và board/stat trước dispatch. Mỗi trận chỉ có **một lần dùng
skill rồi kết liễu**, nên không quan sát lần thứ tư/gấp đôi trong cùng trận.

Card runtime không công bố pha trong corpus này: phase next/max đều null,
source `UNKNOWN:phase_not_published_for_current_card`. Planner ghi pha 1
theo `TOOL_HISTORY_ESTIMATE_FROM_OBSERVED_OPENING`, không đổi thành chứng
nhận pha runtime. RNG trước input vẫn UNKNOWN, guaranteed refund bằng 0.
Không cộng hồi 500 Mana/200 Nộ hoặc stun/heal ngẫu nhiên vào khả năng dùng.

Hai response đã lưu có thứ tự, đều terminal:

- `M_28911553`: DAMAGE báo 2.603.418; raw operation trừ 200 Nộ/200 Mana.
- `M_a0eed95e`: DAMAGE báo 3.905.129, trừ 200 Nộ/200 Mana rồi cộng 500
  Mana. Phần hồi tương thích mô tả lá Xanh, chưa đủ chứng minh nhãn màu
  wire, tần suất RNG hoặc dự đoán lần tiếp theo.

Ledger tổng năm phép số học khớp; bốn endpoint local khớp mỗi response.
Giữ nguyên `damage_source=BOARD_DOT` do server báo, không đổi nhãn thành
pure pet skill damage. Boss còn khoảng 0,69 triệu HP trước dùng; damage
báo vượt HP còn lại không phải lượng HP mất thực hoặc công thức tổng quát.
Một response thiếu giữ UNKNOWN, không suy effect từ HP terminal.

Cả hai response thiếu card ID và terminal client anchor: **UNBOUND**,
0 strict wire-card và 0 conditional client-window match. Không nâng binding
nhờ chi phí/tài nguyên khớp. Chưa fit damage, RNG, heal hoặc buff model.

## Trận Nightsilver trước giữ riêng

Run `8a219e63520142d693ea1fd609f22c28` có 1 trận LOSS trên Nightsilver lv316,
17 SWAP/ACK và một skill, nhánh Galaxy R thực bật; phiên được người dùng
dừng bằng F9. Ledger và hash gốc được giữ, không đổi thành Genbu hoặc xóa
để làm đẹp 3/3. Đã kiểm ledger/controller; phần skill/phase của cohort này
vẫn chờ audit đầy đủ, không là điều kiện mở lại ba trận Genbu đã hoàn tất.

## Artifact và điểm dừng

- [Closure](artifacts/g1_genbu_reasoning3_20261124_215826/review/closure.json),
  [ba pre-state và hai receipt](artifacts/g1_genbu_reasoning3_20261124_215826/review/evidence_pack.json).
- [21 cặp cùng bàn](artifacts/g1_genbu_reasoning3_20261124_215826/review/same_board_comparison.json),
  [kiểm so cùng bàn](artifacts/g1_genbu_reasoning3_20261124_215826/review/comparison_verification.json).
- [Verification](artifacts/g1_genbu_reasoning3_20261124_215826/review/verification.json): 12 file raw kiểm hash,
  ba CommonProblem skill roundtrip, hai receipt tính lại khớp; source không đổi.
- [Fixture skill](../../tests/fixtures/g1_native_reasoning3_20261124/cases.json),
  [fixture SWAP](../../tests/fixtures/g1_native_reasoning3_20261124/swaps.json); không training/optimal label.
- [Kế hoạch thu trước bàn giao](mega_galaxy_handoff_20261124/collection_plan.json).

Đủ **ba trận G1** theo yêu cầu bổ sung; phase thứ tư/RNG/buff còn giới hạn
nêu trên, không tự tăng cap để săn mẫu. Còn G3 và G4, mỗi nhóm ba trận,
trước khi chốt gói bàn giao. User tự chọn pet/boss và bấm Start; không dùng
Computer Use. Không sửa runtime, build, commit hoặc push ở bước này.
