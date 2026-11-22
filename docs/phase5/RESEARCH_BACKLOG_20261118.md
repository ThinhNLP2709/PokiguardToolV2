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

**22/11/2026 — Chốt bài R/UI riêng; không kéo dài nhánh Demon để săn số mẫu.**
HighsionR1 source1d83 WIN/vềlobby,9decision/26receipt đúng,replay9/9,0safe.
5override cùngbàn=4insufficient/1tradeoff. Sửa stateNone UI thành WAITING_STATE
trên0a86 sau nativeclosure;48test/14gate offlinePASS,không đổi gameplay/gate.
Tổng42/còn0,tool đóng. UI/uncertainty/sameboard3bước offline đã làm xong;
damagepredictor chưađủ,bằng chứng sinh tồn thiếu,không thêmHighsion giốngcũ.
Source0a86 không nhận nativeprofile1d83. [Chi tiết](HIGHSION_REASONING_UI_VALIDATION_20261122.md).

**22/11/2026 — Scout có điều kiện đã thực hiện,không kéo dài để đủ số.**
CU hoạt động sau restartDesktop;Highsion165 user chọn được tự chạy BASIC1.
WIN/vềphòng,0safe/recovery,minHP39,22%,24typed đủ11ACK. Không đạt tình
huống áp lực định trước nên R1 không mở;pilotmax2 đóng tại1,tổng41/còn0.
Source508 BASIC native có phạm vi,không nghiệm thu R hoặc predictor.
Cần áp lực thực tế mới cho nghiên cứu sinh tồn,không chỉ boss nhiềuHP.
Mốc gameplay Demon vẫn đóng,không săn thêm trên Highsion theo cap cũ.
[Báo cáo](HIGHSION_PRESSURE_SCOUT_20261122.md).

**22/11/2026 — Ba việc offline chốt xong,không kéo dài mốc gameplay Demon.**
UI phân biệt timer/profile/config;uncertainty offline không gán kill/stop;
replay169 board giữ lợi ích/chi phí cùng trạng thái. Fixed damage reference
chưa phân xử được cặp nào bằng khoảng tách nhau,không fit/tuning mới.
13 test mới/14 gate đạt;287/288 related đạt,1 assertionAST cũ và nhóm
legacy F1 ghi riêng,không giảm gate. Source1d83/508 chưa native.35 trận
same stats/initial state,HP≤30% chỉ9/311;không chơi thêm Priest để săn.
Thêm live chỉ pilotmax2 boss>131 có áp lực;BASIC không sinh điều kiện mới
thì đóng tại1. CUinit OSerror3,game vẫnPriest,chưa mở bất kỳ cap/profile
hoặc input mới,tổng40 còn0. Cần đổi boss và CU hoạt động/cú bấm khi user
tiếp tục. [Kết quả](ADVISER_UNCERTAINTY_OFFLINE_20261122.md).

**22/11/2026 — Bài source505/test2 đã hoàn tất,không cần thêm trận ở mốc này.**
2/2 WIN/về phòng,0 safe stop;R11 decision replay/32 gate đủ,1 gamePASS.
7 override cùng bàn:1 conditional advantage/3 tradeoff/3 insufficient.
Model freeze trước TEST:7 target,V2 chỉ hòa6 chung và bỏ1,không deploy/
tuning.39 typed đủ normalization;3 ACK gap giữ UNKNOWN/COMBAT_STEPS_ABSENT.
>128ops chưa gặp tự nhiên,không săn thêm bằng cap cũ.1.624 pin nguyên,
tổng40/còn0,UI27604 STOPPED1/1. Kế tiếp offline rà nhãn COHORT_CHANGED
(matches còn kiểm timer,không có bằng chứng đổi đồ),thiết kế uncertainty
từ dữ liệu mới trước thử predictor khác. [Báo cáo](DAMAGE_REUSE_NATIVE_20261122.md).

**21/11/2026 — Kiểm pipeline/provenance và transfer hypothesis đã làm nốt offline.**
289/289 sample raw exact,14 dataset/33 trận/119 target;325 test/14 gate PASS,
sourcef7b/505,503 cũ nguyên. Gộp context chỉ trong namespace nghiên cứu riêng,
không xác nhận loadout/phân phối tương đương.141 model qua47 fold;V2 đạt
93 target khi bỏ source nhưng kém baseline trên93 chung,không deploy/tuning.
Ba model freeze trên toàn dữ liệu cũ trước native mới tối đa2 BASIC1+R1.
0 trận mới/tổng38 cũ đóng. Game không room ID,đã hỏi user vào lại phòng;
chưa mở request/profile/GUI mới. Không cần thêm biến thể trên dữ liệu TEST
đã xem. [Kết quả và phần còn lại](DAMAGE_DATA_REUSE_CLOSEOUT_20261121.md).

**21/11/2026 — Component V2 đã triển khai/chấm,chưa đủ để vào gameplay.**
Sourcef1d/503,3 thêm/500 cũ nguyên. Exact số Kiếm+raw amount thay ratio;
latent crit/refill giữ nguyên,không post feature.34 fold/102 artifact pin
trước,33 match/289 action/119 target đã xem. V2 reference14 soV1 61:
3 tốt/1 xấu/10 hòa trên14,mất47 target/gồm30 V1 sai0;guarded2 so13,hòa2.
Chưa thắng baseline,không tuning/deploy.314 test PASS,34 poisonrefit giữ
610 forecast,control1.024 đúng bản cũ.0 trận/input,tổng38/còn0. Support thiếu
nhóm2/4/5/6 Kiếm,không đủ để tự gộp nguồn. Việc cũ kế tiếp:kiểm tương thích
pipeline/provenance và phần latent cần chứng cứ,trước khi lập bài TRAIN/
TEST mới. Không lặp thêm biến thể trên TEST đã xem;Demon vẫn trước Mega/GLX.
[Báo cáo](DAMAGE_COMPONENT_V2_20261121.md).

**21/11/2026 — Đã xử lý offline event176ops và nguồn nhiễu tỷ lệ.**
Source19ed/500,302 test riêng PASS. Long ops không còn làm mất combatSteps
hợp lệ,ops vẫn OMITTED trên128/không duyệt prefix;32KiB/step128 giữ nguyên.
49 action/24 target rà:median chọn57.298,67 từ response crit=true;nhóm còn
mẫu prefix3/tag7 ratio89.131. Đã thêm ratio_support,các hệ số chỉ mô tả,
không fit mới/đổi nhãn/đổi feature hoặc deploy.73 interval resource có224
delta exact/14 cap-floor,không đủ chứng nhận công thức. 84 normalize/64
forecast/frozen model giữ nguyên.0 trận mới,tổng38/còn0. Mốc offline đóng;
source sửa cần native mới khi được mở bài riêng. Thiết kế predictor sau
phải xử lý component chưa quy thuộc/crit bất định,tránh lấy post tags làm
input;không tuning v1 trên TEST đã xem. Value/ranker và Mega/Galaxy giữ thứ
tự cũ. [Bằng chứng](DAMAGE_RATIO_AND_LONG_EVENT_FIX_20261121.md).

**21/11/2026 — Đã thu đúng max6 TRAIN4/TEST2,không cần thêm trận ngay.**
Source25a/498 giữ nguyên.6 WIN/về phòng,0 safe stop/recovery. Freeze models
trước2 TEST;conditional reference9/9 MAE33.818,07 so baseline12.596,22,
7 hòa/2 xấu/0 tốt. Guarded1/9 so3/9,1 chung hòa. Giữ predictor ngoài game.
44 decision replay đủ/26 override cùng bàn có đánh đổi hoặc thiếu dữ liệu,
không dùng win/turn để gán nhãn.84 typed/43 ACK có2 gap:UNKNOWN và176ops
vượt128.5 wire crit=true có bằng chứng,không là feature trước nước hoặc
attribution từng DAMAGE.6/6 đóng,tổng38,còn0;UI26832 dừng2/2. Việc cũ kế
tiếp:rà các tỷ lệ TRAIN lệch nhau theo thứ tự Nộ/Hút/Khiên và refill UNKNOWN,
thiết kế capture event dài có budget;chốt policy v2 trước TEST mới,không
tuning v1 trên2 TEST đã xem. Value/ranker vẫn xếp sau,ưu tiên Demon trước.
[Bằng chứng và giới hạn](DAMAGE_CONDITIONAL_NATIVE_20261121.md).

**21/11/2026 — Conditional predictor v1 offline đã làm,chưa chứng minh gain.**
Source `25a991ea…`/498 Python,495 cũ nguyên.27 fold model/13 cohort/95 target:
reference39 vs41 cũ,37 hòa/1 tốt/1 xấu;guarded4 vs15,4 hòa. Ít dữ liệu cùng
scope/context khiến giảm coverage,không coi là model tốt hơn.239 test PASS,
poison giữ480 forecast. Không nạp model,thay gameplay hoặc tuning sau metric.
0 trận mới,tổng32 đóng/còn0;native d699/profiles/caps nguyên. Đã pin đề xuất
thu6 lượt mới cùng source/cohort rồi validation sau weights,chưa mở. Không
săn crit hoặc gộp khác source để đủ mẫu. [Kết quả](DAMAGE_CONDITIONAL_MODEL_20261121.md).

**21/11/2026 — Đã xử lý8 target/4 chuỗi mới và mô tả cơ chế trước nước.**
Source `33997e9c…`,495 Python,492 cũ nguyên/3 thêm. Tách3 kênh Kiếm và ngữ
cảnh Nộ/Hút;không dự đoán chắc fullPower/crit hoặc refill.254 action kiểm,
4 known Sword cascade từ first-wave0;222 test PASS/poison254 giữ descriptor.
R13 3 Kiếm biết trước,không đưa7 Máu tag sau nước vào input. Baseline cũ
2 fold còn sai/reference7/8 MAE7735,57,guarded2/8 MAE670,25;không tuning,
sửa nhãn hoặc deploy.0 trận mới,tổng32 đóng/còn0;native d699/cap/profile/
prefs cũ nguyên. Bước tiếp theo model có điều kiện theo cơ chế/Nộ và split
đóng trước;chưa mở thêm trận để săn crit. [Kết quả](DAMAGE_MULTITURN_REVIEW_20261121.md).

**21/11/2026 — Đã đóng native operation logger:1 BASIC +1 R d699.**
Hai WIN/về phòng,0 safe stop/recovery/PASS;source492 nguyên.52 context/230
operation hợp lệ,crit đều ABSENT,không suy false.14 decision replay14/14,
6 override cùng bàn (1 lợi ích cơ học có điều kiện/3 đánh đổi/2 thiếu dữ liệu).
16 timing BASIC mới/profile R mới;cap2/2 đóng,tổng32,còn0,UI17788 dừng.
Đã pin31 SWAP/8 DAMAGE target/4 đa DESTROY;4 ACK gap không scoped observation,
không mất normalize. Chưa fit/deploy model. Kế tiếp offline xem8 target và
đa đợt phá mới,không thêm trận ngẫu nhiên để săn crit. [Báo cáo](DAMAGE_OPERATION_NATIVE_20261121.md).

**21/11/2026 — Đã khai thác hết phần offline hiện có của damage Demon.**
Source `d699a5ac…`,492 Python;26 primary log/223 action/93 ACK DAMAGE target.
25 fold giữ policy cũ theo từng cohort;guarded còn sai lớn nên không deploy.
Đã audit Khiên/thứ tự/đa DESTROY và kiểm support trước nước;không đổi label
theo after-state. B17 client đọc crit trong BOSS_HP/STAT_CHANGE,legacy không
giữ. Đã thêm metadata tùy chọn từ JSON đang đọc,không thêm process query,
giữ core/effect/player context/PASS;210 test PASS,31 fixture đối chiếu cũ.
0 trận mới,tổng30 đóng,còn0. Phần tiếp theo cần native response logger mới;
plan tối đa1 BASIC +1 R đã pin,chưa mở cap/claim/tool. Không thể hồi phục
legacy crit hoặc actual refill bằng fit thêm;value/ranker và Mega/Galaxy
vẫn xếp sau Demon. [Kết quả và data blocker](DAMAGE_OFFLINE_CLOSEOUT_20261121.md).

**21/11/2026 — Đã thử predictor component offline,2 fold ngoài trận học.**
Source `df80f926…` (489 Python) thêm3 file,486 file cũ nguyên byte. Fit2
artifact khám phá từ2 trận đã xem,không gọi holdout độc lập. Reference chấm
6/8 component,MAE127,67;guarded chỉ1/8,MAE0 trên1 mẫu không chứng nhận tốt.
Nhóm trực tiếp/quét Demon tách riêng,ít nhất3 mẫu;không nới miền theo metric.
198 test PASS;poison nhãn VALIDATION giữ nguyên tham số và forecast18/18
cho cả mode. Model/forecast được pin trước scoring offline.2 lỗi383 trùng
BLOCK383 ngay trước DAMAGE,không xác minh công thức và không lấy after
BLOCK làm feature. Tỷ lệ/miền hiện là baseline nghiên cứu,chưa dùng live.
Đây có fit cục bộ;value/ranker chưa train.0 trận/input/attach/build mới,
tổng30,còn0. Native c509/profile/prefs/cap cũ nguyên;UI không kiểm lại.
Mốc baseline đóng;tiếp theo rà tách khiên/thứ tự effect từ log đang có,
chưa cần chơi thêm hoặc đổi cách đánh.
[Kết quả, độ phủ và giới hạn](DAMAGE_BASELINE_20261121.md).

**21/11/2026 — Đã xong offline bộ mẫu trước nước và chuẩn sai số component.**
Source `07cceab0…` (486 Python) chỉ thêm3 file,483 file cũ nguyên byte;không
đưa module mới vào gameplay. Dataset pin2 trận mới nhất:18 SWAP=16 ACK+2
chưa ACK;8 recorded DAMAGE component,5 không ghi DAMAGE,3 thiếu typed
response. Không điền0;PASS1 giữ riêng.18 pre-input request giữ nguyên khi
bỏ hết future response/state hoặc đổi nhãn;gộp7 bản sao vẫn18 action.
Solver geometry cũ dùng cho nước trực tiếp/5 target/x1–x7.184 test PASS.
Khung có MAE/RMSE/bias/p95/interval coverage/MAE theo trận,tách build/
account/cấu hình/chữ ký stats;chặn trùng bàn qua split và holdout đã xem.
Chưa có forecast thật nên metric=null,không fit/nạp model.0 trận/input/
attach/train/build mới;tổng30,còn0. Native c509 giữ lịch sử;whole-source
mới chưa live,prefs/profile/cap cũ nguyên. UI23260 dừng ở mốc trước,không
kiểm lại offline. Mốc dataset/protocol đóng;baseline thử nghiệm còn mở,
học value/ranker vẫn xếp sau phần cũ. Chưa cần chơi thêm.
[Dataset, chuẩn đánh giá và giới hạn](DAMAGE_DATASET_PROTOCOL_20261121.md).

**21/11/2026 — Đã đóng1 BASIC +1 R,thu ngữ cảnh response trên source c509.**
Hai WIN/nhận thưởng/về Priest131,0 safe stop/recovery;source483 Python giữ
nguyên. Cap2/2 đóng,tổng30,còn0.14 gate PASS,6 timing BASIC mới;R12 decision/
35 checkpoint,replay12/12,72 event đủ,worker1/1 reaped.1 PASS đúng idle1/
threshold3 do game xác nhận,không đổi rule.30 context playersStateDelta,
23 field,đều actor ta.28/28 khớp8 stats published cùng sequence;13/13 khác
pre-input,nên không dùng làm feature trước nước/tại từng effect.28 typed,
13/16 ACK có effect;3 gap không điền lại.7 override cùng bàn=4 TRADEOFF/
3 INSUFFICIENT_DATA,không lấy WIN/số lượt làm nhãn. Profile/prefs/cap cũ
nguyên,0 train/build. Tool23260 dừng1/1,đúng lobby. Nhãn UI cohort tạm thời
được ghi riêng;12 decision có receipt hợp lệ,không xác nhận đổi pet/boss.
Mốc này đóng;tiếp theo offline bộ mẫu trước nước/chuẩn kiểm sai số,không
mở thêm trận ngẫu nhiên hoặc nạp model khi chưa đủ chứng cứ.
[Kết quả và giới hạn](RESPONSE_CONTEXT_NATIVE_20261121.md).

**21/11/2026 — Đã hoàn tất thu/nghép ngữ cảnh pet từ đúng response, offline.**
Source `c50977f8…` (483 Python) thêm context từ JSON đã đọc; không thêm
memory query. Phân biệt players/full với playersStateDelta; giữ thiếu/null
và hash actor. Ghép exact response/ACK, không lấy probe mở đầu dùng cho cả
trận, không biến after-state thành pre-action/effect-time. Context lỗi/quá
4KB không làm mất effect; tổng payload giữ32KB.169 test PASS;27 fixture giữ
core projection/effect;130 log/533 observation giữ normalization cũ. Log cũ
có0 context mới, không backfill.479 file Python cũ nguyên byte, gameplay
không đổi.0 trận/input/train/build mới;tổng28,còn0. Native gần nhất source28
giữ lịch sử; source hiện tại chưa kiểm native. Profile/cap/prefs cũ nguyên.
UI14420 dừng1/1 là quan sát trước,không kiểm lại offline. Mốc này đóng;
chưa đủ phase/context/crit/buff/holdout để nạp mô hình damage vào adviser.
[Bản sửa, bằng chứng và phần còn thiếu](RESPONSE_CONTEXT_BINDING_20261121.md).

**21/11/2026 — Đã đóng1 BASIC +1 R source28,logger mới có proof native.**
Cả hai WIN/nhận thưởng/về Priest131,0 safe stop/recovery/PASS. Cap2/2 đóng,
tổng28,còn0.6 timing BASIC mới,R6 decision/18 checkpoint/replay6/6,worker
1/1 reaped.4 mẫu gọn thu Máu khớp replay (6 candidate,2 omitted);1 candidate
P nhánh Máu được chọn ở lượt7,trùng BASIC,HEAL7276 chỉ là outcome nhánh thực.
Summary max11915/12000;4 override=2 TRADEOFF/2 INSUFFICIENT_DATA.
FullPower85 step:75 ABSENT/10 VALUE,không suy absence=false.23 typed,
10/11 ACK có effect;BASIC response4 không cung cấp combatSteps (thiếu/null).
Một context mở đầu R đọc được pet560/METAL/lv12,ATK pet=stats1819;weakness
1.22/1.75,equip[25×5] chưa có semantics. DTO type-info unavailable giữ UNKNOWN;
boss/crit/buff/effect-time/full gear chưa đủ. Không fit model hoặc mở thêm
trận. Source480 Python nguyên,ordinary prefs/proof/cap cũ giữ nguyên.
Tool14420 dừng1/1,đúng phòng. Các lỗi setup0 trận/input được giữ riêng.
[Kết quả và giới hạn](DEMON_CONTEXT_NATIVE_20261121.md).

**Đã chốt offline dữ liệu/ngữ cảnh damage của Demon; cần runtime để đi tiếp.**
Source `28fa103c…` thêm fullPower key-presence từ JSON đã
đọc,giữ32768 byte;thiếu metadata không làm mất effect hợp lệ. Gộp bản sao
không xung đột nếu chỉ khác độ phủ metadata. Không đổi reader/planner/PASS.
154 test PASS;24 fixture giữ status/effect,128 file giữ normalization cũ.
Sau loại trùng:263 quan sát ta/39 trận lịch sử,227 exact ACK,136 quét đầu,
158 DAMAGE component (136 legacy true/22 thiếu-null UNKNOWN).39 trận lịch
sử không phải39 lượt mới; tổng mốc vẫn26,còn0. Chưa đủ context/holdout để
fit. Các field pet/element/equip đã chỉ ra trong reverse nhưng ownership/
crit/buff/formula chưa xác minh;không thêm đọc bộ nhớ hoặc điền dữ liệu.
**Phần offline này đóng. Kế tiếp:** đối chiếu runtime có kiểm soát cho
context và logger mới,không cần farm hàng loạt ngay. Native proof/profile
source61 giữ nguyên;source mới chưa native.0 trận/input/train/build.
[Bản sửa và điều còn thiếu](DEMON_DAMAGE_CONTEXT_20261120.md).

**20/11/2026 — Đã bổ sung log gọn cho nhánh thu Máu Demon, chỉ offline.**
Source `b0b524b1…` giữ tối đa1 mẫu nhánh đã chấm dù candidate đầy đủ bị
lược; có bộ đếm omitted/count-only, giới hạn512 byte trong summary12000.
Giữ nguyên score/nước chọn/BASIC/PASS/input và attribution BASIC/proposal.
41 test tập trung PASS; replay672/672 giữ decision/score,16 trạng thái giữ
mẫu mới,summary max11990/12000.6 lỗi của kiểm archive
được tái hiện trước thay đổi; không tuyên bố cả suite xanh.
Mẫu hiếm r1 lượt3 giữ đúng4 Máu và P=[0.184039…,1],chỉ là replay logger mới,
không phải bound worker đã ghi native. Mốc offline đóng,0 trận mới;tổng26,
cap còn0. Proof/profile/UI source61 giữ lịch sử; source mới chưa kiểm live.
**Kế tiếp:** kiểm ghi log thật khi có mốc live riêng,không mở cap tự động
hoặc chạy ngẫu nhiên để tìm lại bàn. Chưa train/build; Mega/Galaxy hoãn.
[Bản sửa log và kiểm chứng](DEMON_HEALTH_BRANCH_LOG_20261120.md).

**20/11/2026 — Đã đóng3 R bổ sung, tổng26; tìm được bàn hiếm qua replay.**
Ba WIN/nhận thưởng/về đúng Priest131,0 safe stop/recovery/PASS,worker3/3
reaped. Source477 Python giữ61bead5b;24 decision/72 checkpoint,replay24/24,
11 khác BASIC cùng bàn (7 TRADEOFF/4 INSUFFICIENT_DATA),không lấy WIN/số
lượt làm nhãn. Cap3/3 đóng,còn0,không ép nước hoặc đổi gameplay.
Summary không có witness; full replay có1 candidate r1 lượt3:HP79265/109491,
4 Máu,cascade chưa rõ,P trước[0,1]→[0.184039…,1]. Cùng stage/node/count
native/replay nhưng8 evaluated chỉ2 published,candidate không được chọn.
Giữ NATIVE_FRAME_OFFLINE_REPLAY_ONLY,không nâng thành bound worker đã ghi.
42 typed,19/21 ACK có effect;2 gap UNKNOWN,không điền dữ liệu.37 resource
interval (17 LOCAL/20 BOSS). ToolPID29932 dừng1/1,đúng lobby;ordinary prefs/
hồ sơ/cap cũ nguyên,không train/build. **Kế tiếp offline:** giữ witness
nhánh gọn trong diagnostic12KB;không chạy tiếp ngẫu nhiên để tìm lại bàn.
Mega/Galaxy hoãn.
[Ba trận, mẫu hiếm và giới hạn chứng cứ](DEMON_HEALTH_WITNESS_20261120.md).

**20/11/2026 — Đã đóng kiểm native source61:1 BASIC +1 R, cap2/2, tổng23.**
Hai WIN/nhận thưởng/về đúng Priest131,0 safe stop/recovery/PASS/input fault;
source477 file Python giữ `61bead5b…`. Qualification14 gate PASS, BASIC13 ACK
timing mới; R5 decision/15 checkpoint/replay5/5,2 nước khác BASIC cùng bàn,
worker1/1 reaped,summary11623/12000 byte. Không dùng14 so với5 lượt/WIN để
xếp chất lượng. Lượt7: cùng7 Hút, R quét thêm3 Kiếm hiệu dụng (2 vật lý),
6 Mana,2 Nộ,8 Khiên,4 Máu; nhánh thực ghi114597 DAMAGE/3638 HEAL. Refills
6→24 ô và boss có thể ăn3 Hút, nên giữ INSUFFICIENT_DATA cho so toàn bộ.
Nhánh Health prefix mới không có witness trong5 summary; các quét chọn
đều residual=false. Chưa nghiệm thu native nhánh này, không chạy bù.
Đã thấy UNAVAILABLE response4 giữ exact identity;32 typed chuẩn hóa32/32,
2/17 ACK thiếu effect: BASIC4 vắng steps,R12 không scoped observation/cause
UNKNOWN. Có16 boss-board/30 resource interval (14 LOCAL+16 BOSS),không giả
effect. Proof/profile cũ giữ nguyên; profile mới max1 từ BASIC mới,không cài
prefs thường. ToolPID8792 dừng1/1,game ở đúng lobby. Cap còn0,không train/
build. **Kế tiếp offline:** dùng net-resource/cặp cùng bàn đã bind; giữ các
khoảng thiếu và damage/crit context UNKNOWN. Mega/Galaxy hoãn.
[Phiên kiểm, evidence và giới hạn](DEMON_HEALTH_NATIVE_20261120.md).

**20/11/2026 — Offline đã chốt rà Nộ và sửa giá trị thu Máu đợt quét Demon.**
Source `61bead5b…` chỉ đổi `_score`, thêm8 test;475 file Python cũ còn lại
nguyên byte. Quét đầu có Máu và HP ta thiếu giữ proxy cơ hội thu Máu làm
sàn P; không chứng nhận lượng hồi/sống sót hoặc thêm sàn Khiên/Hút. Đủ HP,
HP chưa biết, geometry chưa xác minh và lối khác giữ cách cũ. R/T/B vẫn
UNKNOWN khi residual chưa rõ; không đổi BASIC/PASS/owner/input/collector.
121 test PASS; replay648 trạng thái (192 Demon/456 lối khác),16 trạng thái
có candidate giữ thêm sàn thu Máu,0 lựa chọn đổi;456 lối khác giữ toàn bộ
score/decision,648 node count giữ nguyên,summary max11990/12000 byte.
Nộ:39 DAMAGE component có36 true/3 None;27 update FULL_POWER đều−100 trong
tập này,9 hành động true không giữ update tiêu nộ tương ứng. Không suy
cost/ngưỡng/formula từ cờ. B17 client chỉ deserialize combatSteps; wire
absence/null cũ không khôi phục được. Nước mở đầu R có adviser-source/sent/
ACK/published-after exact, giữ tầng riêng,không chèn vào67 mẫu cũ.
0 attach/input/trận/train/build; tổng21,cap còn0. Proof/profile7a giữ nguyên,
source61 chưa native. **Phần offline này đóng. Kế tiếp:** mốc live riêng có
control BASIC mới rồi R để kiểm source mới; trước khi fit damage còn cần
key-presence và gear/buff/crit context/trận độc lập. Không mở cap hoặc
rebind tự động. Mega/Galaxy hoãn.
[Bản sửa, bằng chứng và giới hạn](DEMON_HEALTH_AND_POWER_REVIEW_20261120.md).

**20/11/2026 — Đã rà độ phủ Demon, chưa cần chạy bù các mẫu2/3/4 Kiếm.**
18 resource interval mới là7 LOCAL+11 BOSS, trong7 LOCAL có6 quét. Rà thêm
log B17 cùng nhóm danh nghĩa lấy60 LOCAL/23 quét; tổng67 LOCAL/29 quét,
14 trận. Giữ lịch sử riêng vì chưa chứng minh toàn bộ gear/buff/crit giống
nhau. Mỗi ô2/3/4 Kiếm ở hai nhóm nộ đã có ví dụ; chưa đủ để fit damage.
DAMAGE flags36 true/3 None, không có false tường minh; None không là false.
Chưa có LOCAL bắt đầu đầy HP/Mana hoặc boss nộ0, HP thấp/gần chết còn ít.
Source476 file Python giữ `f595bdb5…`;0 attach/input/trận/train/build, tổng21,
cap còn0. Native proof/profile7a giữ nguyên; f595 metadata chưa native.
**Kế tiếp offline:** kiểm presence/order fullPower, rồi exact provenance biên
mở đầu/kết trận; sau đó mới chốt tình huống live cần thu. Không ép nước hoặc
đổi PASS để lấp ô, không dùng WIN/số lượt làm nhãn. Mega/Galaxy tiếp tục hoãn.
[Bảng độ phủ, khoảng thiếu và kế hoạch](DEMON_EVIDENCE_COVERAGE_20261120.md).

**20/11/2026 — Offline đã sửa identity của UNAVAILABLE và lấy lại scope.**
Source `f595bdb5…` thêm response identity cho non-captured sau match/sequence/
raw-SHA fence, giữ evidence null; queue đánh dấu delivery đúng. Exporter
nhận identity mới hoặc đối chiếu duy nhất toàn bộ capture index của log cũ,
không dùng thời gian gần nhất. Metadata thiếu/trùng/conflict vẫn fail-closed.
154 test PASS;72 projection fixture giữ classification/effects, AST chỉ đổi
metadata;472 file source khác nguyên byte, gồm reader/BASIC/adviser/PASS/input.
Replay123 combat: chỉ1 file thêm7 boss interval, không mất interval/exclusion
cũ. BASIC lấy lại7 boss +11 resource; cả case có11 boss/18 resource interval,
21 typed response vẫn21,1 UNAVAILABLE vẫn thiếu. Ba effect thiếu không được
khôi phục.78 delta exact,2 cap/floor,51 lastStat khớp endpoint; chưa fit model.
0 attach/input/trận mới/train/build; cap trước đóng2/2, tổng21. Native proof/
profile7a giữ nguyên; source mới chưa native metadata. **Việc scope offline
đã đóng. Kế tiếp:** dùng dữ liệu net-resource/quét Demon đã bind để nghiên
cứu, không cần mở cap bù; Mega/Galaxy hoãn.
[Bản sửa, điều kiện và replay](UNAVAILABLE_RESPONSE_IDENTITY_20261120.md).

**20/11/2026 — Native retention đã đóng1 BASIC +1 R, cap2/2, tổng21.**
Source `7a6503d4…` giữ nguyên. Hai WIN/nhận thưởng/về phòng,0 safe stop/
recovery/PASS; BASIC7 ACK timing mới, R5 decision/15 checkpoint, replay5/5,
worker1/1 reaped. Nhóm riêng giữ152/99 root và7/3 error, không omitted/fault;
giữ thêm102+50 mốc trước legacy tail. Đây là scoped metadata proof, không
phải lịch sử liên tục hoặc thu đủ response. R đủ effect4/4 ACK; BASIC còn
3/7 thiếu (1 UNAVAILABLE,2 không observation), không tự điền dữ liệu.
Một nước cùng bàn đổi sang quét2 Kiếm cùng tài nguyên: thực gây76398 dame,
+120 Mana,+4548 Khiên,+4366 HP ròng; nhánh BASIC giả định chưa có outcome,
projection khác horizon/refill24 ô, không gán nhãn tốt hơn hoặc formula.
BASIC có UNAVAILABLE thiếu response identity khiến7 boss interval bị loại;
R giữ4 interval. **Kế tiếp offline:** giữ/ghép identity của UNAVAILABLE đúng
scope rồi khai thác net-resource Demon. Không mở cap bù. Ordinary prefs/
profile cũ giữ nguyên, không train/build; toolPID16112 đã dừng1/1.
[Báo cáo và outcome đã bind](DEMON_RETENTION_NATIVE_20261120.md).

**20/11/2026 — Offline đã giữ riêng lịch sử root và lỗi đọc.**
Source `7a6503d4…` chỉ đổi metadata module và test;473 file source khác giữ
nguyên byte, gồm protocol/tap/BASIC/adviser/PASS/input. Ring128 cũ giữ
nguyên; thêm256 root event (128 đầu+128 gần nhất),32 error event (16+16),
counters observed/omitted rõ ràng, snapshot cached.94 test PASS;9 trace
synthetic khớp mọi field cũ; fixture cùng19 RPM query. Replay chỉ phần
native tail còn giữ, không khôi phục491/90 event hoặc4 effect thiếu.
Benchmark fake-memory p50 41,4→41,5µs, p95 56,8→56,1µs; chưa timing native.
Source mới **chưa native**; proof/profile1909 vẫn giữ pin cũ, không rebind.
Đợt này0 attach/input/trận mới/train/build; cap trước đóng2/2, tổng19.
UI lịch sử thuộc source1909, không chứng nhận source mới trên đĩa.
**Mốc kế tiếp:** kiểm Demon bằng control/timing mới đúng source trong
phiên live riêng; chưa chuẩn bị hoặc mở cap mới. Mega/Galaxy hoãn.
[Bản sửa, kiểm chứng và giới hạn](READER_TRACE_RETENTION_20261120.md).

**20/11/2026 — Đã đóng BASIC1 + Suy luận1, cap2/2, tổng19.**
Source `1909d77a…` giữ nguyên suốt hai pha. Hai WIN/nhận thưởng/về lobby,
0 safe stop/recovery/PASS; R5 decision/15 checkpoint, replay5/5, worker1/1
reaped. Một nước khác BASIC:3 Nộ thay3 Hút, giảm khả năng boss ăn Khiên
nhưng tăng khả năng ăn Hút trên phần bàn đã biết — TRADEOFF, chưa chứng
minh tốt hơn. Không lấy13 so với5 lượt hoặc WIN để xếp chất lượng.
Giữ29 typed response/binding, chuẩn hóa29/29;4/16 ACK thiếu effect. Ring
BASIC/R đẩy491/90 event; một gap R còn trong cửa sổ retained, ROOT_SET/EMPTY
không đủ gắn sequence hoặc chốt nguyên nhân. Không fault/alias native,
không tạo effect giả. ToolPID18516 STOPPED1/1, UI đọc đúng Priest1845.
Ordinary prefs giữ nguyên, không build/train/rebind; không còn cap live.
**Kế tiếp offline:** giữ lịch sử reader quan trọng có giới hạn, không đổi
cadence/gameplay/PASS; tiếp tục Demon trước, Mega/Galaxy hoãn.
[Báo cáo, cặp cùng bàn và giới hạn](DEMON_READER_TRACE_NATIVE_20261120.md).

**Lịch sử setup trước BASIC — 19/11/2026.**
Source `1909d77a…`: lịch sử bounded128 event/8 root/16 alias, UTC+monotonic,
lỗi/gap đọc có thời điểm; token callback/DTO/JSON theo phiên và exact-instance
binding sang observation/raw SHA. Không ghi disk trong polling, không thêm
RPM hoặc đổi protocol/fence/cadence/adviser/BASIC/PASS/input.86 test PASS,
14 qualification gate PASS; benchmark là fake-memory, chưa native acceptance.
Đã thấy UI READY tại Priest131/Demon Aegis Khiên, room300394, target1/attempt1,
PID6228. Case mới dự kiến1 BASIC+1 R, đã dùng0/2;17 lượt cũ vẫn đóng. Chưa
chuẩn bị profile R vì phải dùng BASIC mới; không rebind/build/train. Ordinary
prefs giữ nguyên. **Kế tiếp:** chạy BASIC đã chuẩn bị, kiểm ACK/timing/trace,
rồi mới chuẩn bị tối đa1 R. Không tuyên bố nguyên nhân gap cũ đã được chốt.
[Setup, log path và quy trình](READER_TRACE_SETUP_20261119.md).

**19/11/2026 — Đã rà offline callback/collector và sửa lỗi gộp root có điều kiện.**
Reverse/native B17 xác minh JSON/DTO thuộc closure328 và drain bị clear sau
xử lý. Reader cũ gộp theo DTO pointer, tái hiện2 ca che JSON của callback
khác; đã đổi key thành closure+DTO+JSON. Callback trùng qua queue/drain vẫn
chỉ giữ1. 65 test PASS;9 differential replay giữ query/fence/limits/cadence.
Chỉ đổi reader+test; tap/adviser/BASIC/PASS/input giữ nguyên byte. Source mới
`d88e909f…` chưa native; không rebind proof/profile source `b3ab48ce…`.
Log BASIC/R đã thấy9/13 DTO offer riêng biệt, không có closure/per-read root
membership của phần thiếu: chưa chứng minh alias gây gap BASIC12 hoặc3 gap
cũ. Không khôi phục effect. Đợt này0 attach/live/input/train/build, tổng17
lượt trước giữ nguyên, cap đều đóng. UI/game không được kiểm lại đợt này.
**Mốc kế tiếp:** kiểm native reader mới trên Demon với cap mới riêng; không
xem một phiên đủ log là chứng minh nguyên nhân gap cũ. Mega/Galaxy hoãn.
[Bản sửa, reverse và giới hạn](COLLECTOR_ROOT_AUDIT_20261119.md).

**19/11/2026 — Đã đóng phiên kiểm capture Demon mới và sửa scope offline.**
Source `b3ab48ce…`:1 BASIC +1 R đều WIN/nhận thưởng/về đúng Priest131,
0 safe stop/recovery. R10 decision/28 receipt đúng đường SWAP/PASS, replay
10/10;7 override gồm5 SWAP ACK và2 PASS được game xác nhận1/3 rồi2/3,
không bỏ lượt thứ ba. Metadata31 mục không fault/drop/conflict; typed29/29
qua chuẩn hóa. R đủ7/7 ACK có effect; BASIC còn thiếu1/6, response12 không
có scoped observation, nguyên nhân cụ thể UNKNOWN. Cap mới2/2 đóng, tổng17.
Sau đó chỉ sửa exporter offline: accepted-board UNAVAILABLE có scope đúng
không chặn interval khác. Giữ lại8 boss interval và15 resource interval R,
không tạo effect;67 test PASS. Source hiện tại `86c22524…`, runtime/src và
adviser/input giữ nguyên byte; native proof/profile vẫn pin `b3ab48ce…`.
Không train/build/rebind. ToolPID1688 dừng1/1; game ở lobby đúng phòng.
**Kế tiếp offline:** audit ownership/lifetime và điều kiện lọc root của
collector; chưa tăng reads/cadence hoặc tự mở thêm cap. Mega/Galaxy hoãn.
[Phiên live và cặp cùng bàn](DEMON_CAPTURE_NATIVE_20261119.md) ·
[Bản sửa lọc dữ liệu](DEMON_UNAVAILABLE_SCOPE_20261119.md).

**19/11/2026 — Đã kiểm offline ba khoảng trống typed effects của Demon.**
14/14 capture gốc được chuẩn hóa đầy đủ; thiếu seq12/20/32 đã xảy ra trước
normalizer. Cả ba nước đều ACK/published state; tám board-shape rejection
khác vẫn giữ được effects, không giải thích ba khoảng trống. Nguyên nhân
cụ thể còn UNKNOWN do log cũ thiếu chỉ mục capture. Đã bổ sung metadata
bounded theo sequence về đọc JSON/projection/delivery, không thêm reads
hoặc đổi adviser/BASIC/PASS/input. 89 test PASS, AST đường cũ giữ nguyên
sau khi bỏ hooks. Source mới `b3ab48ce…` chưa native; proof cũ thuộc `1bd824c2…`.
0 trận mới/train/build/rebind; cap cũ2/2 đã đóng, tổng nhóm15 giữ nguyên.
**Kế tiếp:** thu Demon mới để kiểm chỉ mục và xác định nguyên nhân nếu gap
lặp lại; chưa khẳng định đã khôi phục/fix mất effect. Mega/Galaxy hoãn.
[Bằng chứng và phạm vi](DEMON_CAPTURE_DIAGNOSTICS_20261119.md).

**19/11/2026 — Demon prefix đã kiểm native source `1bd824c2…`.** Một BASIC
và một R đều WIN/nhận thưởng/về room, không safe stop/recovery/PASS. Timing
BASIC mới6 ACK; R9 decision/27 receipt hợp lệ, sáu override ACK và một nước
prefix thực chọn. Đã đối chiếu cùng bàn, không gán hiệu quả theo số lượt.
Cap mới2/2 đóng, tổng nhóm15. Source/main prefs giữ nguyên, không train/build.
**Việc cũ kế tiếp trên Demon:** trace typed effects thiếu ở3 nước ACK R
seq12/20/32; board/state/action đầy đủ nhưng chưa giữ được immutable typed
effect tương ứng. Kiểm đường thu offline trước, không tự điền effect hoặc
gán nguyên nhân operation limit/shape khi chưa đủ bằng chứng. Mega/GLX hoãn.
[Coverage và bằng chứng](DEMON_PREFIX_NATIVE_20261119.md).

**Ưu tiên user đã điều chỉnh: tiếp tục Demon trước; Mega/Galaxy để sau.**
Active skill binding vẫn nằm trong backlog, không là điều kiện để làm
Demon passive. Source `1bd824c2…` đã giữ lower bound kiếm/goal của đợt quét
đầu khi có residual; R/P/T tiếp tục UNKNOWN. 80 test PASS, paired 643;
4 lựa chọn Demon đổi, 456 mẫu lối khác giữ nguyên, không thêm node cap.
**Việc kế tiếp:** kiểm Demon source mới và đối chiếu cùng bàn, sau đó mới
quay lại yêu cầu dữ liệu skill chủ động khi triển khai Mega/Galaxy.
[Bằng chứng và tradeoff](DEMON_PREFIX_FLOOR_20261119.md).

**19/11/2026 — Đã kiểm tiếp net Mana/Nộ và skill readiness.** 65 published
interval, 197 update, 140 lastStat khớp endpoint; gross không bằng net ở
nhiều nước có đủ before/ACK/after. Kiểm 643 snapshot không thấy mâu thuẫn
logic; 24 bộ costs đầy đủ là synthetic, chưa có native active-skill binding.
Source `cbccf8c4…` chỉ thêm tool/test; 55 test PASS, không đổi gameplay.
**Việc cũ tiếp theo:** chuẩn bị ghép skill sent/card ID/effective costs/
outcome/endpoint bằng log owner hiện có; normalizer mới xác minh SWAP ACK.
Chưa đưa −100 Nộ hoặc ngưỡng FULL_POWER thành công thức chung, chưa fit
model hoặc đề xuất chạy Mega khi đường thu dữ liệu còn thiếu.
[Bằng chứng](NET_RESOURCE_READINESS_AUDIT_20261119.md).

**19/11/2026 — Đã xử lý việc offline tiếp theo.** Exporter giữ lại đúng 8
boss interval trước batch lỗi; capture gốc vẫn thiếu. Bộ đối chiếu hiện
ghi cả tài nguyên phản công boss, không chỉ Kiếm: 643 snapshot/cấu hình,
619 bàn; 402 đánh đổi, 56 chưa đủ mô hình, 4 lợi thế cơ học có điều kiện,
181 cùng nước. Review ba ca nhiều lượt chưa chứng minh bug định giá.
Source `6a5f2c6b…`, 125 test PASS, không đổi gameplay hoặc chạy thêm trận.
**Tiếp theo:** kiểm tác động tài nguyên ròng/điều kiện skill bằng ordered
trace đã có, không tự fit damage hoặc dùng refill quan sát cho nhánh giả
định. [Bằng chứng và phạm vi](OFFLINE_SAME_STATE_AUDIT_20261119.md).

**Tiêu chí chất lượng đã chốt:** so sánh BASIC/Suy luận tại **cùng snapshot**,
cùng trạng thái trận và cài đặt. Số lượt giữa hai ván, WIN, override count,
receipt hoặc utility nội bộ không là bằng chứng chất lượng. Đã đối chiếu đủ
5 cặp khác BASIC của trận mới; có lợi thế cơ học và các đánh đổi riêng,
không gán cả 5 là tốt hơn. [Bảng và chuẩn báo cáo](SAME_STATE_DECISION_REVIEW_20261119.md).

**19/11/2026 — Native source `17c35c7e…` đã đóng 1 BASIC + 1 Suy luận.**
Priest131/Demon Aegis ăn Khiên: hai WIN, 9 và 10 nước, nhận thưởng/về room
Coop_300394; 0 safe stop/recovery/PASS. Tám mẫu timing BASIC mới cùng source
cho profile riêng. R có 10 decision/30 receipt hợp lệ, năm override đều ACK;
61 log đủ, worker 1/1 reaped, summary max 11.793 byte. Nhánh refill mới chạy
ở một candidate không chọn; không khẳng định tác động nhân quả hoặc hiệu quả.
BASIC có một optional outcome INVALID/OPERATION_SHAPE_OR_LIMIT; timing và
chơi không bị ảnh hưởng, nhưng exporter loại cả tám boss interval trong file.
R có 19 CAPTURED/0 invalid, tám boss interval bind được. Cap mới 2/2 đóng,
tổng ledger 13 trận; tool PID 27924 dừng. Không build/train/rebind/source edit.
[Báo cáo, capture gap và phạm vi](REFILL_RISK_NATIVE_20261119.md).

**19/11/2026 — Offline: adviser đã xét hazard kiếm sau lấp bàn.**
Source `17c35c7e…` tái sử dụng hazard có sẵn trong solver để mở rộng T có điều
kiện; không cộng lợi ích refill hoặc đổi BASIC/PASS/input/reader. Audit trận
14 nước tái hiện đủ 11 override, reconciles 26/26 Mana/Nộ endpoint; gross gain
không là net balance. Paired 633 trạng thái đổi 95 SWAP hợp lệ, cap 2 → 2.
Bản chốt kiểm lại đủ 633 quyết định/điểm số, log max 11.990/12.000 byte và
112 test PASS. Trong trận vừa rồi chỉ hai lựa chọn replay ở lượt 15/17 đổi;
chưa có outcome thực của các nước thay thế. Native thắng 14 nước bên dưới
thuộc source e48 cũ. 0 live/train/build/rebind, không đổi prefs hoặc mở tool.
[Báo cáo, giới hạn và bằng chứng](ADVISER_REFILL_RISK_20261119.md).

**19/11/2026 — Suy luận source `e48e94d3…` đã kiểm trực tiếp.**
Một trận Solo/Priest131/Demon Aegis ăn Khiên: WIN sau 14 nước, nhận thưởng
và về đúng lobby; 0 safe stop/recovery/PASS. Có 14 decision, 42 receipt hợp lệ,
11 nước khác BASIC; tất cả action gửi khớp decision. Log đủ 85 record,
worker 1/1 reaped. Collector nhận 25 batch hợp lệ, 111 STAT_CHANGE/32 DESTROY.
Nhánh thứ tự tiêu Nộ UNKNOWN chạy ở 10 retained candidate, không cộng chắc
bonus mở skill. Profile riêng dùng 7 timing BASIC mới cùng source/build/host;
qualification 14 gate PASS, không rebind profile cũ. Cap mới 1/1 đóng, tổng
nhóm 11 trận. Tool PID 19252 dừng; không đổi source/prefs, train hoặc build.
[Báo cáo và phạm vi](B17_RAGE_REASONING_LIVE_20261119.md).

**19/11/2026 — Đã kiểm Nộ theo vai trò và bổ sung ordered trace.**
Trong 13 khoảng ta gây DAMAGE, boss không tăng Nộ ngoài flow đã ghi;
10 khoảng không có Hút/POWER flow. Chưa chốt quy tắc 5 Nộ/kiếm vật lý.
Collector giữ STAT_CHANGE/DESTROY đã đối chiếu reverse, không đổi adviser,
BASIC, input hoặc PASS so với source `de63bc05…`. Phiên đầu thắng sau
13 nước nhưng 23 capture lỗi định dạng DESTROY; đã sửa và kiểm 87 test PASS.
Phiên sau thắng sau 8 nước, giữ đủ 13 capture hợp lệ: 66 STAT_CHANGE,
21 DESTROY, 30 POWER update. Có +5 và FULL_POWER −100 riêng biệt trong log;
chưa dùng làm công thức toàn cục. Source `e48e94d3…`; đã đóng đủ 2/2 BASIC,
tổng nhóm 10 trận. Tool PID 6084 dừng 1/1 ở Priest cấp 131/room 310394.
Chưa kiểm REASONING trên source mới, train, build hoặc rebind profile.
[Báo cáo](B17_RAGE_ROLES_AND_TRACE_20261119.md).


**19/11/2026 — Offline mới nhất: source de63bc05… sửa chắc quá mức về tích Nộ.**
Audit25 khoảng boss/12 SWAP ta: trong9 nước kiếm kèm Nộ,8 gross Nộ khác
số dư sau thực;50 kiểm Mana khớp lượng báo,50 Nộ còn residual. Không fit
mức tiêu Nộ hoặc tick cố định. Shared R dùng khoảng stockpile, không cộng
chắc bonus mở skill sau nước kiếm cần Nộ; giữ upside, điểm burst/kiếm và
quyền skill/PASS/input.219 test PASS;619 replay/20 SWAP→SWAP đổi hợp lệ,
node cap2→2;613 before parity exact.0 live/train/build, native666 bên dưới
thuộc source trước; profile không rebind. [Báo cáo](B17_RESOURCE_BALANCE_REVIEW_20261119.md).

Bổ sung user về Nộ:25 khoảng boss cho17 ca không mất HP→+5,6 ca DAMAGE
flag null→+20,2 ca DAMAGE full_power true→+35 sau khi tách flow/Hút.2 ca
BLOCK-only vẫn+5. Chỉ là liên hệ post-hoc cho người chơi phòng thủ trong
cohort này; chưa áp dụng số tick/hit hoặc đối xứng boss vào runtime.
[Chi tiết](B17_RESOURCE_BALANCE_REVIEW_20261119.md#bổ-sung-sau-quan-sát-của-user-nộ-khi-đổi-lượt-và-nhận-đòn).


**19/11/2026 — Đã trở về `main`, thêm kịch bản tài nguyên sau nước ta.**
Shared adviser xét Mana/Nộ thu được từ SWAP đã biết trước phản hồi Hút của
boss; giữ riêng reference/gross gain và UNKNOWN cho refill/transfer/thứ tự
Nộ khi tấn công/skill.205 test PASS,613 paired replay/17 đổi hợp lệ. Module
adviser/test giữ nguyên byte từ sourcef0fb; qualification chạy lại trên main
source666d13bc… mọi gate PASS. Không đổi BASIC/PASS/input hoặc train/build.
[Phạm vi, bằng chứng và live mới](B17_POST_ACTION_RESOURCES_20261119.md).

**Native main đã đóng:**1 BASIC11 nước +1 Suy luận6 nước,2 WIN/nhận
thưởng/về đúng Priest131.0 safe stop/recovery/PASS.10 mẫu timing mới;
R6 quyết định/18 receipt hợp lệ,5 override (4 ACK+1 terminal),37 record0 mất,
worker1/1 reaped. Thêm12 boss interval có nguồn; cap2/2 đóng, tổng8 trận
B17 đã đóng ở các source/cohort riêng. ToolPID16540 stopped1/1. Đây là kiểm
chức năng cùng source666, không là hiệu quả thống kê hoặc live gói ZIP.


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
| 2 | Ước lượng damage/heal có phạm vi và khoảng sai số | **Offline V1/V2 + replay/transfer và TEST2 mới đã làm;chưa chứng minh gain.**TEST7 target,V2 hòa baseline6 chung nhưng bỏ1.325 test/14 gate và source505 native BASIC1/R1 đã đạt;không deploy. [Mốc mới](DAMAGE_REUSE_NATIVE_20261122.md). Heal/hiệu chuẩn còn mở | Tổng40 lượt đã đóng,còn0. Không thêm trận để đóng mốc;rà UI status và thiết kế uncertainty offline trước thử tiếp. Không tuning TEST đã xem,coi missing crit=false hoặc rebind profile/cap |
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
