# Mega Kết Ấn và Galaxy — rà checkpoint ngày 23/11/2026

**G4 bổ sung cuối 24/11 đã chốt:** [Argilpus 3/3 WIN](GALAXY_G4_NATIVE_REASONING3_20261124.md),
9 SWAP gửi, 6 ACK thường và 3 terminal không ACK. Chín cặp G4 BASIC/R
replay có 2 đổi/7 giữ, không chừa Kiếm đã biết; native facts khớp 9/9.
G1/G3/G4 đã đủ mỗi nhóm ba trận. G4 vẫn là schema riêng vì common profile
chưa hỗ trợ; không alias hoặc cấp common-rollout acceptance từ ba WIN.

**G3 bổ sung cuối 24/11:** [Argilpus 3/3 WIN, 22 SWAP/ACK](GALAXY_G3_NATIVE_REASONING3_20261124.md).
Ba context đọc đúng pha runtime 1/3; hai response ghi cost 200/200 và
hoàn 250 Mana, một response thiếu. Cả ba skill đầu kết liễu nên pha 2/3
chưa quan sát. So cùng bàn có 11 đổi/11 giữ resource BASIC, chưa có nhãn
tối ưu. Còn G4 ba trận trước bàn giao; không mở lại cap G1/G3 để săn mẫu.

**G1 bổ sung ba trận cuối 24/11:** [Genbu 3/3 WIN, 21 SWAP/ACK](GALAXY_G1_NATIVE_REASONING3_20261124.md).
Ba context skill, hai response; chưa có cast thứ tư, phase runtime chưa
công bố, chỉ có estimate pha 1 theo opening/history. Trận Nightsilver
LOSS/F9 trước giữ riêng. Còn ba trận G3 và ba trận G4 theo yêu cầu mới
trước khi chốt gói bàn giao; G2 giữ cohort đã chốt.

**G2 Suy luận sau BASIC 24/11:** [đã chốt một trận trên Genbu](GALAXY_G2_NATIVE_REASONING1_20261124.md),
16 SWAP/ACK, ba response có thứ tự, 7 nước đổi/9 giữ so resource BASIC
trên cùng bàn. G2 chính không tiến hóa đạt bài kỹ thuật; phần common
worker, G1/G3, tiến hóa và nhánh cứu nguy/chờ skill chưa được nghiệm thu.

**G2 cuối 24/11:** [BASIC mới trên Genbu lv161](GALAXY_G2_NATIVE_BASIC1_20261124.md)
đã hoàn tất 1 WIN, 18 SWAP/ACK, ba context thẻ hiện hành và một response
effect; hai response thiếu giữ UNKNOWN. Chuẩn bị một phiên Suy luận G2
riêng, chưa Start; không cấp common-worker acceptance cho nhánh per-pet.

**Cập nhật tiếp 24/11 — T-Rex:** [một trận Suy luận Archon → T-Rex](MEGA_TREX_REASONING1_NATIVE_20261124.md)
đã WIN, 23 SWAP/ACK, 6 nước R đổi/4 giữ BASIC trong 10 cặp native;
13 fallback read span vẫn có ACK. Một skill kết liễu ghi đúng ấn T-Rex
30 ô, chi phí 200 Mana/200 Nộ và effect có thứ tự; terminal card binding
vẫn UNBOUND, chưa kiểm nước sau skill hoặc cứu nguy. Bước tiếp là Galaxy
G1/G2/G3 theo account sẵn có, không lặp T-Rex chỉ để tăng bộ đếm.

**Cập nhật sau live 24/11:** [5 trận Icarus Suy luận đã chốt](MEGA_ICARUS_REASONING5_NATIVE_20261124.md)
trên source `ace28cad…`: 5 WIN, 115 SWAP/ACK, 14 skill; ghép 88 cặp native
cùng bàn, 60 nước đổi có đánh đổi và 28 nước giữ BASIC. 27 SWAP fallback
do read span đều có ACK. Phạm vi thường → Icarus/No.11 lv185; các phần
"chưa live hiện tại" dưới đây mô tả thời điểm rà ban đầu. Bước tiếp là
T-Rex có mục tiêu rồi Galaxy, không lặp Icarus để tăng số lượng.

Phạm vi: theo yêu cầu quay lại các việc còn mở sau khi chốt Demon. Đối
chiếu tại commit `5c887b77` trên main. Đợt này chỉ rà tài liệu/code và ghi
checklist; không sửa runtime, mở tool, thêm trận, build hoặc commit.
Plan canonical Opus đã giao agent khác; checklist này cung cấp đầu vào về
skill và bằng chứng, không khởi động một lõi AI khác song song.

**Đã rà log offline tiếp theo:** [inventory skill Mega/Galaxy](ACTIVE_SKILL_INVENTORY_20261123.md).
131 join cast Mega, 117 endpoint tài nguyên; chưa có combatSteps để quy
effect/damage. Không cần chơi thêm chỉ để tăng số lượng.

**Cập nhật 24/11:** đã có bộ offline cho
[Icarus mới](ICARUS_COMMON_CORE_EVIDENCE_20261124.md) và
[T-Rex từ log cũ](TREX_COMMON_CORE_EVIDENCE_20261124.md).
Hai bộ giữ cohort/evidence scope riêng; chưa rollout lõi mới hoặc mở lại live.

**Galaxy offline cũng đã đóng ngày 24/11:**
[42 case và các giới hạn](GALAXY_COMMON_CORE_EVIDENCE_20261124.md).
[Rà lịch sử live và bài cần tiếp](MEGA_GALAXY_LIVE_READINESS_20261124.md)
phân biệt 2 Icarus R lịch sử với 3 BASIC collector mới; chưa mở live mới.

## Những mốc đã đạt vẫn giữ đóng

- Demon adviser: checkpoint `72604edf`, tổng 42 lượt của nhánh đã đóng.
  Chưa có damage predictor đạt kiểm định không làm mốc gameplay mở lại.
- G4: checkpoint `46d77a57`, người dùng chốt riêng; v1.3.7 đã build.
  G4 là skill tự động theo combo, không chứng nhận Galaxy G1/G2/G3 dùng thẻ.
- Mega Icarus MI.1–MI.3 đã hoàn tất chức năng trong phạm vi lịch sử.
  5D.4 cũng có 2 trận R WIN, 42 SWAP/ACK và 4 skill click-only;
  có một lần dùng skill ở 5 Kiếm trong ấn dù setting là 6. Giữ kết quả
  kỹ thuật này, không yêu cầu làm lại mini-plan. Nó không chứng minh tối ưu
  chiến thuật, cứu nguy hoặc nghiệm thu source/build/route T-Rex hiện tại.

Nguồn: [MI status](../mega_icarus_spam_skill/STATUS.md),
[5D.4 closure](reports/5d4_report.md),
[Demon integration](../main_integration_20261122.md),
[G4 checkpoint](G4_CHECKPOINT_20261123.md).

## Tình trạng từng nhóm

| Nhóm | Đã có trong source/bằng chứng | Chưa chốt cho suy luận hiện tại |
|---|---|---|
| Mega Kết Ấn Icarus/T-Rex | Registry đọc loại thẻ hiện hành; hai hình ấn riêng 30 ô; đếm viên hiệu dụng; kiểm tài nguyên; cấu hình Tự bảo vệ Không/30%/10%; giữ luồng tiến hóa và fresh reread | Liên kết skill với phản hồi thực; so thời điểm ra skill/tích tài nguyên/ăn Kiếm/bảo vệ trên cùng bàn; kiểm các route/thẻ và nhánh cứu nguy có phạm vi hiện hành |
| G1 Risky | Nhận đúng loại thẻ; chi phí Mana + Nộ; các khả năng ngẫu nhiên; chu kỳ thứ tư từ pha runtime hoặc lịch sử đầy đủ có nhãn | Xác nhận pha thật và vòng thứ tư sau nâng cấp; không coi hồi tài nguyên hoặc kết quả RNG là bảo đảm |
| G2 Glank | Tính Khiên theo multiplier; giữ Khiên khi tích tài nguyên; setup tối đa một lượt có kiểm phản hồi boss; đủ điều kiện thì cân nhắc bảo vệ | Kiểm trực tiếp chiến thuật mới; liên kết chi phí/skill/effect; thời hạn buff/giáp đang chạy và sát thương thực chưa được xác minh |
| G3 Dragon Knight | Decoder pha đúng owner/card/session; phân biệt vòng 1–2–3; cân nhắc tài nguyên vòng sau, không ứng trước phần hồi | Xác nhận đủ vòng pha trên game sau nâng cấp; sát thương tích trong ấn, thời hạn chống Hút và hiệu ứng từng pha chưa được đo đủ |

Hai hình ấn đã được giải mã lại trong audit B17 và khớp production; không
cần nghiên cứu lại geometry từ đầu. Icarus có cờ khả năng hồi máu; không
gán hồi máu Icarus cho T-Rex, cũng chưa có công thức lượng hồi.

Nguồn: [Mega design](MEGA_SEAL_RESEARCH_DESIGN_20261107.md),
[B17 compatibility](../petpuzzle_b17_compatibility_report.md),
[Galaxy G1/G2/G3](../galaxy_pet_reasoning_20261116.md),
[G2 review](../galaxy_glank_reasoning.md).

## Khoảng trống dùng chung cần xử lý trước

1. **Nối skill với kết quả game.** `tools/normalize_action_outcomes.py`
   hiện chỉ chứng nhận SWAP sent/ACK; phản hồi skill còn mang lý do
   `CARD_SKILL_SENT_ACK_BINDING_NOT_VERIFIED`. Audit tài nguyên 19/11 có
   0 mẫu native đủ nối chi phí thẻ hiện hành với skill và số dư sau skill
   **trong corpus được audit**. Điều này không có nghĩa chưa từng có log
   skill: Galaxy cũ đã có 1 skill G1, 4 skill G2, 1 skill G3; Mega cũng có
   các lần cast lịch sử. Cần tận dụng các log đó trước khi xin thêm trận.
2. **Tách chức năng với chất lượng quyết định.** So BASIC/R trên cùng
   snapshot và cấu hình: tài nguyên ròng, viên trong ấn/Khiên giữ lại,
   cơ hội Kiếm/Hút của boss, skill sẵn sàng và phần UNKNOWN. Ví dụ Mega
   T-Rex `M_896e1cb4`/113 đã có lợi thế cấu trúc giảm cơ hội Hút boss;
   chưa đủ gọi là thắng phản thực tế hoặc tối ưu toàn bộ trận.
3. **Kiểm nguồn pha và route hiện hành.** Galaxy 15–16/11 đã có replay và
   test nhưng báo cáo ghi chưa live chiến thuật/decoder pha mới. Ba trận
   Galaxy cũ có UI chọn R nhưng `selection_authority=false`, thực tế về
   BASIC; không tính thành nghiệm thu R mới. Phạm vi lịch sử Icarus cũng
   không tự mở rộng sang T-Rex hoặc mọi route tiến hóa.
4. **Giữ ranh giới kiến trúc với agent phụ trách plan.** UI Galaxy hiện
   dùng `GalaxyReasoningSession` riêng; các profile còn lại dùng loader
   authority. Profile Galaxy trong common replay không chứng minh UI đã
   dùng common worker. Hợp nhất core, skill fire/hold, arbitration tiến
   hóa và rollout thuộc U6/U8/U10/U11 của plan canonical.

Nguồn: [resource audit](NET_RESOURCE_READINESS_AUDIT_20261119.md),
[same-state audit](OFFLINE_SAME_STATE_AUDIT_20261119.md),
[backlog](RESEARCH_BACKLOG_20261118.md),
[canonical plan](../opus/opus-reasoning-upgrade-plan.md).

## Thứ tự tiếp theo đề nghị

1. Offline lập inventory log **Mega trước, Galaxy sau**: giữ source/build,
   thẻ/pha/route, cấu hình bảo vệ, dispatch và kết quả thật; phân biệt log
   đủ nối với log thiếu trường. Không dùng closure Demon làm mẫu skill.
2. Tái hiện đường nối skill bằng các log đủ nguồn, ghi rõ cost/owner/phase/
   session/sequence/after và trường còn thiếu. Thiếu binding thì giữ UNKNOWN,
   không nối chỉ vì hai sự kiện gần thời gian nhau.
3. Xuất bộ replay cùng bàn cho các tình huống skill/tiến hóa/bảo vệ. Đưa
   fixture và kết quả cho agent core; không đổi trọng số để ép R khác BASIC.
4. Sau khi xác định thiếu hụt mà offline không bù được, mới mở bài live
   riêng cho đúng pet/route/tình huống. Một câu hỏi, tiêu chí đạt và giới hạn
   lượt rõ ràng; không lặp trận thắng quá nhanh để tăng số mẫu. Game quyết
   định quyền PASS; không thay rule đang hoạt động để săn dữ liệu.

**Anh chưa cần đổi account, pet hay vào trận trong đợt rà này.** Bước kế
tiếp có thể làm offline là inventory và binding skill cũ. Ước lượng định
lượng damage/heal là phần nâng tiếp có kiểm định, không phải điều kiện
bắt buộc để triển khai chiến thuật dựa trên cơ chế đã biết.
