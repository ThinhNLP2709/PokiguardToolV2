# Rà lại nghiên cứu suy luận trong temp — 18/11/2026

**Kết luận: chưa hết việc cũ.** Phần nâng tactical planner đã được đưa vào
source; nhánh mô hình damage/effect/học từ log còn mở. Đề xuất mô hình học
kết quả hành động là phần nối tiếp của nhánh này, không cần khởi động lại
nghiên cứu từ đầu hoặc chờ mọi mục cần live mới làm dữ liệu offline.

Đợt rà soát chỉ đọc file, đối chiếu code và tạo index/coverage report. Source
vẫn `9b4a21096f4efccc630039b790508f5f0a296bbd4cc0e4d9661b94fa7c36cb27`;
không đổi runtime, fit model, mở tool, chạy thêm trận hoặc build.

## Các nghiên cứu đã được sử dụng

| Nơi giữ bản làm việc | Đối chiếu với source/bằng chứng | Trạng thái |
|---|---|---|
| `temp/reasoning/adviser_multiturn_20261117/` | `_future_setup`, test setup sensitivity và báo cáo [17/11](ADVISER_SETUP_SENSITIVITY_20261117.md) | Đã áp dụng cách kiểm độ vững setup qua các phản hồi boss |
| `temp/reasoning/adviser_reply_risk_20261118/` | T risk interval, `reasoning_common_capture.py`, extractor snapshot, [reply-risk report](ADVISER_REPLY_RISK_20261118.md) | Đã áp dụng; replay và bằng chứng cần giữ đã archive trong docs |
| `temp/reasoning/adviser_zero_setup_20261118/` | `plan_common`, test bounded future, [offline report](ADVISER_BOUNDED_FUTURE_20261118.md), [live mới](BOUNDED_FUTURE_NATIVE_20261118.md) | Bản cuối đã áp dụng và kiểm live. `bounded_planner.py` là prototype cũ, không phải một module đang chờ merge |
| `temp/reasoning/combat_outcomes_20261117/` | Thư mục hiện rỗng; collector/parser/audit nằm trong source và [báo cáo permanent](COMBAT_OUTCOME_EVIDENCE_20261117.md) | Đường thu và audit đã làm; mô hình dự đoán chưa làm |
| `temp/galaxy_review_20261115/`, `galaxy_g2_review_20261115/`, `galaxy_pet_reasoning_20261116/` | [Galaxy](../galaxy_review_20261115.md), [G2](../galaxy_glank_reasoning.md), [G1/G2/G3](../galaxy_pet_reasoning_20261116.md), các module `galaxy_*` và `reasoning_galaxy.py` | Chiến thuật/decoder đã triển khai offline; không phải model tự học. Cần giữ giới hạn live theo từng báo cáo |
| `temp/galaxy_b15_audit/`, `temp/mega_seal_audit_summary.json` và disassembly | [Thiết kế Mega Kết Ấn](MEGA_SEAL_RESEARCH_DESIGN_20261107.md), registry Icarus/T-Rex và classifier hiện tại | Hình ấn/cơ chế đã dùng. Damage/heal định lượng vẫn là nhánh riêng |

Các bản `before`, script compare/probe và log cũ được giữ để tái hiện nghiên
cứu; việc chúng còn ở temp không đồng nghĩa code chưa được dùng. Không chép
prototype vào runtime chỉ dựa vào ngày/file name. Không xóa file trong đợt này.

`legacy-20261026/` có29 thư mục,9178 file, khoảng528,6MB: chủ yếu source/fixture/
manifest/capture phục vụ đối chiếu trước/sau. 40 Markdown chỉ có3 nội dung
khác nhau theo SHA: P9 contract, P17 timing addendum, P20 root-admission
proposal. Chữ PENDING trong bản sao đó thuộc mốc14–15/10; xem closeout trong
[STATUS](STATUS.md), không tự mở lại P/cap cũ. Điều này không biến global
native_U hoặc phạm vi unsupported thành đã được giải quyết.

Các thư mục dependency, build/package smoke và kiểm nhập chuột ở `temp/`
không là các nghiên cứu học chiến thuật đang chờ triển khai.

## Việc cũ vẫn chưa hoàn thành

**Offline mới nhất450abb97…:** đã đánh giá13 boss interval,3 cơ hội kiếm
known-max; R6 khoảng chỉ3 swap nằm trong tập reply partial và2 bàn có known
cells dịch tiếp sau refill. Không chứng minh universal boss/refill model.
Đã sửa gap Hút chỉ xét Mana: raw POWER/MANA và B17 display path xác nhận2
loại; shared tactics xét cả2 với unknown/maximum một tài nguyên.613 paired
replay/83 đổi hợp lệ,222 PASS/5 lỗi fixture cũ. Không live source mới hoặc
fit formula. Phần còn mở ưu tiên số dư sau nước ta/refill coverage và amount/
after semantics; không train bằng nhãn WIN. [Report](B17_REPLY_DRAIN_REVIEW_20261118.md).

**Mới nhất — nối bàn boss đã có native:** sourceb1b718fb… thêm optional
retained64-cell board + published-state logs,246 test PASS. Thêm1 BASIC+1 R
Priest/DemonShield,2 WIN/0 safe stop/recovery/PASS;13 khoảng boss có before/
after thực,0 training label. R8 quyết định/24 receipt đúng,5 override gửi.
Đã đủ nguồn để bắt đầu đánh giá reply-risk trên các khoảng này; chưa đủ
phổ quát hóa boss policy/refill/damage.7/7 boss move BASIC hợp lệ trên
before board;2 cơ hội kiếm đều chọn known-max (3cascade/6direct). R6 khoảng
không là mọi7 lượt boss. Cap4+1+1 đóng;không thu tiếp vì thiếu metadata cũ.
[Report](B17_BOSS_BOARD_AND_REASONING_20261118.md).

**Bổ sung live B17 sau khi user chuẩn bị Priest131:** đã thu riêng4 trận
Demon Aegis/Khiên cùng acc,4 WIN,28 lượt ta,51 outcome/166 effect.28 local
SWAP ops khớp đúng nước gửi,21 boss SWAP ops được giữ,22 STEAL có loại
POWER/MANA. Bây giờ đã có tọa độ boss trong cohort mới, còn thiếu board
trước nước boss có nguồn xác nhận để học policy.17 Demon observation/10
usable/0 calibration-eligible. Không pool với B16 hoặc acc/boss khác, không
tăng cap4 đã đóng. [Báo cáo](B17_PRIEST_OUTCOME_LIVE_20261118.md).

**Tiến độ sau lượt xử lý việc cũ18/11:** phần chuẩn hóa observation chung
đã làm, gồm137 batch/397 effect;186 test liên quan PASS.11/11 mẫu Nộ lệch
ledger có pattern chạm trần, nhưng eligibility cũ giữ nguyên. Đã xác minh
đường ops SWAP B16 và thêm lưu optional ops/stealType; chưa có capture mới
để gán nước boss. Chi tiết và phần còn mở ở
[báo cáo dữ liệu chung](COMMON_ACTION_OUTCOMES_20261118.md).

| Ưu tiên | Việc | Làm offline được gì ngay | Điều chưa đủ |
|---|---|---|---|
| 1 | Dữ liệu kết quả hành động dùng chung | **DONE ở mức observation:** normalizer chung giữ typed effects mọi response đã thu; nối sent/ACK cho SWAP, tách HP/block/heal/Mana/Nộ, cap/censor/unknown | Skill/card sent-ACK binding chưa kiểm; hiện0 skill trong2 cohort.0 mẫu calibration-eligible; chưa gọi observation là model |
| 2 | Ước lượng damage/heal có phạm vi và khoảng sai số | Xây predictor interface, baseline thử nghiệm, kiểm sai số theo nhóm trận/build/loadout tách riêng; chỉ fit phần có dữ liệu đủ | Chưa có công thức server, context khắc hệ/buff/crit đầy đủ hoặc đủ mẫu skill. `demon_damage_reference` hiện là estimate khai báo có điều kiện, không phải model học |
| 3 | Mô hình boss và refill | **DONE nguồn native có phạm vi:** optional logging mới đã kiểm1 BASIC+1 R,13 boss interval có published before/after và op. Có thể kiểm độ nhạy reply-risk trên board thật | Không complete action/refill coverage;13 khoảng cùng pet/boss/acc chưa là universal policy. `last_move` vẫn thuộc nước ta; không tối ưu/train label |
| 4 | Học giá trị thế trận/xếp hạng nước | Chuẩn bị split theo trận/session/build, mục tiêu theo lối chơi/cài đặt, bộ đánh giá và nhánh thử nghiệm offline | Chưa có nhãn cho những nước không đi. Không dùng WIN của một trận để gán mọi nước trong đó là tối ưu; không tự train lại scorer trên chính kết quả của nó |
| Sau đó | Kiểm model và skill trong trận dài | Chuẩn bị matrix và đúng bài kiểm từ các thiếu hụt dữ liệu trên | Native9b4 mới chỉ kiểm Demon ăn Khiên/Lion Star105. Các cap6 đã đóng, không tự dùng lại cho Mega/Galaxy/Coop |

Đây là những hướng đã có trong [nghiên cứu 5A.0](phase5a0_research_completion_plan.md)
(học từ log, R2, optional learned model) và nhánh damage riêng của Mega Kết
Ấn. Đợt này không khôi phục roadmap20 bước đã đóng hoặc tạo chuỗi P mới.

**Galaxy là điểm cần phân biệt:** `create_ui_reasoning_session` hiện đưa
Galaxy sang `GalaxyReasoningSession` với chiến thuật riêng G1/G2/G3, không
qua common worker đã hiệu chuẩn. Common planner có profile Galaxy trong
replay không chứng minh UI Galaxy dùng cùng worker. Bộ dữ liệu/effect model
chung có thể phục vụ cả hai; hợp nhất runtime là việc riêng sau khi kiểm
capability/skill, không thay nhánh đang hoạt động chỉ để đồng nhất tên.

## Kiểm lại dữ liệu có thể dùng

Đợt audit nối đúng file của hai cohort B16 đã đóng, tổng12 trận gồm6 BASIC
và6 REASONING. Kiểm SHA run theo closure, không quét lẫn các bản sao trong
profile timing. Có81 quyết định,137 batch outcome duy nhất, không conflict.

- 35 quan sát Demon được normalizer tạo;16 là `usable_observation`, nhưng
  cả35 vẫn có `calibration_eligible=false`. Không cộng thành16 mẫu đã được
  phép dùng để dự đoán damage trong game.
- 38 action-response bị normalizer loại với `NOT_A_KNOWN_DEMON_ACTIVATION`.
  Đây là khoảng trống chuẩn hóa đòn thường/hiệu ứng khác, không phải bằng
  chứng các nước đó không gây damage hoặc không có ích.
- 7 trường hợp thiếu response;11 quan sát có power ledger chưa khớp ở
  normalizer cũ. Đã đối chiếu:11/11 có pattern chạm trần trong raw after.
  Chưa chứng minh công thức/độ đầy đủ; giữ nguyên eligibility và35 output
  cũ. Các lý do có chồng nhau.
- 63 batch của boss có hiệu ứng nhưng0 tọa độ wire move. Chưa đủ dataset
  để học chính sách chọn nước boss từ các batch này.
- Hai cohort này có0 skill dispatch. Mẫu damage Demon không kiểm chứng
  hồi máu hoặc sát thương skill Mega/Galaxy.
- Có605 đầu vào replay =584 corpus đã giữ +21 snapshot mới. Đây là trạng
  thái để hồi quy/đối chiếu, không phải605 trận hoặc605 nhãn nước tối ưu.
  Chúng đã được xem khi nghiên cứu, không gọi là holdout độc lập.

[Inventory, source anchors và dữ liệu có SHA](artifacts/research_backlog_audit_20261118/audit.json).
Script audit chỉ đọc file, không fit, attach hoặc phát input.

## Thứ tự chốt cho phần tiếp theo

**Chỉ đạo mới18/11:** ghi đề xuất model học vào danh sách trước, xử lý các
việc cũ còn mở trước rồi mới tính phần học. Nhánh model học kết quả hành
động, value/ranker học từ kinh nghiệm và mở rộng tìm kiếm bằng model học
được xếp **QUEUED_AFTER_OLD_WORK**; chưa training, chưa thay scorer/live.

Đã xử lý offline phần observation chung và nguồn ops static. Chỉ module
optional evidence có thêm trường; luồng đọc/solver/input giữ nguyên. Chưa
fit mô hình định lượng vì thiếu skill/context và không có mẫu đủ hiệu
chuẩn. Source hiện tại923813c6… khác live9b4 bởi phần evidence/tool/test;
không rebind proof/profile cũ. Các cap đã đóng.

1. **DONE observation:** exporter chung và audit12 log; phần skill binding
   còn mở, chưa gán skill output vào một action khi chưa đủ nguồn.
2. **DONE static/cap audit:** đã tìm nguồn ops và phân loại11 ledger Nộ;
   boss-beforeboard/refill/context vẫn thiếu capture. Không đoán bù dữ liệu.
3. Khi có tập đủ nguồn, thử predictor nhỏ và đo sai số trên split đã chốt;
   chỉ cân nhắc cho adviser dùng model khi đạt kiểm định tương ứng.

Các việc độc lập cần ghi lại:3 lỗi historical projection của suite vẫn còn,
nhãn UI `COHORT_CHANGED` có lúc không phản ánh các receipt input hợp lệ,
và4 ca trong bộ584 chạm node cap. Chúng không phải các nghiên cứu ML chưa
merge và không được xử lý bằng nới admission, tăng budget hoặc bỏ guard.
Có thể sửa có phạm vi riêng, không buộc nhánh dữ liệu chung chờ tất cả.

Scratch mới vẫn dưới `temp/reasoning/`; bằng chứng cần giữ đặt trong docs.
Chưa tự bắt đầu training hoặc đổi lựa chọn gameplay trong lượt xử lý này.
