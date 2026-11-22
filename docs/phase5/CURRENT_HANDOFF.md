# Bàn giao suy luận — source hiện tại và UI lịch sử

**22/11/2026 — User chốt Demon, commit và ghép updater/migration.**
Checkpoint `72604edf` giữ toàn bộ mốc Demon hiện tại. Nhánh self-service tại
`3a0df30d` đã là tổ tiên main; không có commit khác cần merge. Phần tích hợp
chỉ docs/CI/tests:375 test offline PASS,240 module migration được giữ với
overlay9 file Demon đã review/231 nguyên. AST diagnostic witness pin exact,
production src/tools nguyên từ checkpoint. Không đổi version hoặc mở live;
profile/source cũ không rebind. [Biên bản](../main_integration_20261122.md).

**22/11/2026 — R Highsion1/1 đã đóng; lỗi nhãn chờ UI đã sửa offline.**
User yêu cầu tiếp tục; bài mới max1 tách scout cũ,11 timing BASIC cùng source
tạo profile max1 mới. Source1d83 WIN/vềCoop_389316,0safe/recovery;9 decision
replay9/9,26receipt đủ,1PASS game idle1/ngưỡng3,third0,worker/writer sạch.
5 override cùng bàn=4insufficient/1tradeoff,không claim gain theo số WIN.
Sau đóng native,source0a86/508 chỉ2UI+1test đổi,505 còn lại nguyên:stateNone
giờ WAITING_STATE thay DEGRADED;expiry/config precedence giữ.48 test liên quan
và14gate synthetic PASS/300receipt;không rebind profile/native1d sang0a86.
Tool đã đóng,còn0/tổng42;không thêm Highsion săn pressure,minpreHP41,42%.
2/7ACK thiếu typed giữ unknown,không deploy damage/build. Ba bước offline
đã xong;Demon gameplay không mở lại chỉ để đủ mẫu. [Báo cáo](HIGHSION_REASONING_UI_VALIDATION_20261122.md).

**22/11/2026 — CU đã khôi phục; Highsion165 scout đóng tại BASIC1.**
User restart Desktop,chọn Highsion165/ID1651,giữ Demon560. Sky khởi tạo,
đọc app và tự bấm Start tool1 lần thành công;FarmRunner gửi input thường.
Source1d83/508 nguyên. MatchM_acf5df66 WIN/vềCoop_389316,0 safe/recovery,
12swap/11ACK,11timing,24typed normalize đủ/11ACK đủ typed. BossmaxHP1067059,
minselfHP42946/109491=39,22%,terminal53860. Không pressure witness dưới30
hoặc scarcity rõ;đóng pilotmax2 sau1,đóng1 lượt dự phòng chưa dùng,còn0.
Không mở R/profile/target khác,tổng41 cũ+scout đã đóng. CU không còn bị
OSerror3. BASIC source508 native đã kiểm có phạm vi,R/UI timer fix chưa
native. ToolPID37256 STOPPED1/1 đúng phòng,nútStart khóa do request đã
dùng xong,không phải lỗi stop giữa trận. Không build/train/đổi scorer.
[Kết quả và điều kiện dừng thu](HIGHSION_PRESSURE_SCOUT_20261122.md).

**22/11/2026 — Ba bước offline theo yêu cầu đã xong; không lặp Priest để thu thêm.**
Source1d8349dc/508:503 cũ nguyên,2 UI sửa/3 file thêm. UI tách thiếu timer,
profile hết hạn,config đổi;không sửa admission/input/PASS hoặc fault bridge.
Uncertainty API offline giữ crit/Khiên/Nộ/refill chưa biết,không chứng nhận
kill/tự dừng hoặc nhập model vào gameplay. Replay169 frame/17 file:78 cùng
BASIC,91 khác=2 conditional advantage/49 tradeoff/40 thiếu;không claim gain.
163 cặp SWAP:baseline có59 reference/51 guarded,V2 50/29,các khoảng đều
chồng nhau;652 poison giữassessment,0 refit. 35 trận/311swap cùng một stats
khởi đầu;chỉ9 nước HP≤30%. Không thêm Priest131. Pilot đề xuất max2 với
boss>131 tạo áp lực,giữ pet/đồ;BASIC không có tình huống mới thì dừng tại1.
CU init vẫn OSerror3,0 input;game vẫn roomCoop_353375/Demon560/Priest1845.
Chưa mở request/profile/cap/trận mới,tổng40 cũ đóng/còn0.13 test mới PASS,
287/288 related PASS;1 AST fixture cũ lỗi với runner/test nguyên,5 legacy
ProfileReview cùng lỗi F1 trước/sau UI.14 gate mới PASS;source508 chưa native,
không rebind hồ sơ505. Không build. [Báo cáo](ADVISER_UNCERTAINTY_OFFLINE_20261122.md).

**22/11/2026 — Đã đóng native max2: BASIC1 + R1 trên source505.**
Sourcef7b giữ nguyên505 Python.2 WIN/nhận thưởng/về Priest131 roomCoop_353375,
0 safe stop/recovery/abort.11 timing BASIC tạo profile R mới/max1;R11 decision
replay11/11,32 checkpoint đủ,1 PASS game xác nhận/third0,worker1/1 reap.
7 override cùng bàn:1 lợi thế cơ học có điều kiện/3 tradeoff/3 thiếu dữ liệu.
22 swap/20 ACK,39 typed normalize đủ;17/20 ACK có typed,3 gap giữ nguyên
(BASIC COMBAT_STEPS_ABSENT;R2 gap không scoped observation).1 wirecrit=true,
189 absent không suy false;maxpayload9904/32768,không positive >128ops.
TEST2 sau freeze3 models:7 target,V2 chỉ6 chung hòa baseline MAE127,67,
bỏ1 target;guarded3 hòa/bỏ3. Không claim gain/refit/deploy.1.624 pin cũ
nguyên,tổng40/còn0,cap2/2 đóng;UI27604 mở nhưng STOPPED1/1 đúng lobby.
UI có51 snapshot COHORT_CHANGED chưa chứng minh đổi đồ;11 action/32 gate
thực thi hợp lệ,cần rà riêng nhãn/timer,không phải safe stop. Không cần
thêm trận để chốt mốc. [Báo cáo](DAMAGE_REUSE_NATIVE_20261122.md).

**21/11/2026 — Tái sử dụng dữ liệu đã rà xong offline; chờ phòng để kiểm source mới.**
Source `f7ba1ec6…`/505 Python: 503 cũ nguyên, thêm tool audit + 11 test.
289/289 sample từ raw khớp toàn bộ,14 dataset/33 match/119 target/58 snapshot.
325 test và14 gate mới PASS,không thay timing/profile native. Transfer là
giả thuyết offline riêng: bỏ source14 + bỏ match33 fold,141 model bị schema
production từ chối;47 poison refit giữ1.156 forecast. V2 reference93/119,
nhưng trên93 chung baseline MAE14.953,73 vsV2 18.317,65 (5 tốt/9 xấu/79 hòa).
Không claim gain,không deploy/tuning. Ba model khóa trên289 action trước
TEST mới. Dự kiến max2 BASIC1+R1;38 lượt cũ vẫn đóng,0 mới. Game PID32112
không còn room ID hợp lệ;đã hỏi user vào lại Priest131/Demon560 ăn Khiên.
Chưa có request/profile/GUI hoặc input mới. CU kernel OS error3 còn là lỗi
đã xác nhận,không lách qua helper nhập chuột. Cần tạo BASIC request sau
phòng clean,rồi timing/profile R mới. [Báo cáo](DAMAGE_DATA_REUSE_CLOSEOUT_20261121.md).

**21/11/2026 — V2 raw component đã làm và chấm offline,chưa đạt để deploy.**
Source `f1d59907…`/503 Python,500 cũ nguyên/3 thêm. V2 học component amount
ở đúng số Kiếm quét/trực tiếp/cascade,không rescale ratio;3 bàn khác nhau,
1 láng giềng/bàn,crit/refill vẫn latent. Policy/plan pin trước34 fold/102
artifact,tất cả đã xem.33 match/289 action/119 target,không gộp MAE cohort.
V2 reference14 vsV1 61/baseline63;14 chung soV1=3 tốt/1 xấu/10 hòa,nhưng
mất47 target/gồm30 V1 sai0. Guarded2 vs13/30,2 hòa. Native6 trên12 chung:
V2 MAE22.776,25,V1 24.559,39,baseline18.097,08;coverage còn thấp,không claim
gain.314 test PASS,34 poison refit giữ610 forecast,1.024 control forecast
tái hiện.0 trận/input/attach/build,tổng38/còn0;source503 chưa native,model
không import vào gameplay. Nhóm2/4/5/6 Kiếm thiếu bàn TRAIN;không tự trộn
source/cohort. Kế tiếp kiểm tương thích pipeline/provenance trước bài thu
và TEST mới,không tuning V2 trên target đã xem.
[Kết quả và giới hạn](DAMAGE_COMPONENT_V2_20261121.md).

**21/11/2026 — Đã sửa capture event dài và rà xong lỗi tỷ lệ offline.**
Source `19ed3f1a…`/500 Python:5 file sửa,493 cũ nguyên,2 test thêm. Ops>128
được OMITTED cả danh sách,giữ combatSteps hợp lệ;scan128/step128/32KiB và
input/board/PASS không đổi. 302 test riêng PASS,31 capture legacy giống hệt,
84 typed normalize và64 forecast cũ nguyên. Rà49 action:nhóm3 láng giềng
có1 response crit=true,tỷ lệ57.298,67 được chọn;1 mẫu biết3 Sword nhưng
response báo7,ratio89.131 bị nhiễu bởi phần chưa quy thuộc. Đã thêm cờ
ratio_support offline,không sửa nhãn/fit lại/nạp model hoặc claim tốt hơn.
73 resource interval/224 delta exact/14 cap-floor chỉ là quan sát sau nước.
Raw176ops cũ không còn,chưa hồi phục gap hoặc native nhánh sửa.0 trận mới,
tổng38/còn0;source mới chưa native,không rebound profile25a. UI26832 dừng
2/2 là phiên cũ. [Bản sửa và bằng chứng](DAMAGE_RATIO_AND_LONG_EVENT_FIX_20261121.md).

**21/11/2026 — Đã đóng bài6 trận: TRAIN4 rồi TEST2 sau freeze.**
Source `25a991ea…`/498 Python nguyên byte;BASIC1+R3 TRAIN rồi khóa baseline
và conditional trước khi mở2 R TEST,cùng cohort Priest/Demon560 ăn Khiên.
6 WIN/nhận thưởng/về phòng,0 safe stop/recovery/abort.44 decision replay đủ,
130 checkpoint,5 worker reaped;26 override cùng bàn=16 TRADEOFF/10 thiếu
dữ liệu,không lấy số lượt hoặc thắng làm chứng minh chất lượng.2 PASS do
game xác nhận,third pass0.9 target TEST:reference conditional MAE33.818,07
so baseline12.596,22;7 hòa/2 xấu/0 tốt. Guarded1/9 so3/9,1 chung hòa.
Chưa đạt,không deploy/tuning;forecast offline sau trận,không claim prospective.
84 typed normalize đủ;2/43 ACK thiếu typed:1 UNKNOWN,1 event176ops bị
limit128.5 wire crit=true đã giữ,423 absent không suy false.1.173 pin cũ
nguyên. Cap6/6 đóng,tổng38/còn0;UI26832 dừng2/2 đúng lobby,GUI còn mở.
Kế tiếp offline rà tỷ lệ khác nhau/thứ tự Nộ-Hút-Khiên/refill chưa biết và
thiết kế capture event dài trong ngân sách,không chơi thêm ở mốc này.
[Kết quả và bàn giao](DAMAGE_CONDITIONAL_NATIVE_20261121.md).

**21/11/2026 — Conditional damage v1 offline xong,chưa chứng minh tốt hơn.**
Source `25a991ea…`,498 Python,495 cũ nguyên/3 thêm. Model học tỷ lệ cục bộ
từ3 hàng gần nhất và13 chiều trước nước,tách cơ chế Kiếm;không dùng wire
fullPower/crit làm input hoặc cài công thức server. Ít nhất3 bàn TRAIN,
giữ empirical interval và abstention;không có import vào gameplay/SAFE_STOP.
Policy+13 cohort/fold pin trước fit,27 model/27 trận/95 target đã xem.
Reference39/95 vs41 cũ,trên39 chung=37 hòa/1 tốt/1 xấu;guarded4/95 vs15,
4 chung đều hòa. Native2 trận mới nhất point/MAE bằng baseline. Không
tuning để làm đẹp.239 test PASS,27 audit refit giữ parameters/480 forecast.
0 trận/input/attach/build mới,tổng32 đóng,còn0;d699/profile/prefs/cap cũ
nguyên. Source498 chưa native,UI17788 chỉ là quan sát dừng cũ. Model không
deploy. Thiếu context Nộ thấp/known Sword cascade cùng source/cấu hình.
Đề xuất TRAIN1 BASIC+3 R,rồi tối đa2 TEST sau đóng weights đã chuẩn bị,
chưa mở cap/profile/claim. [Kết quả và bài thu](DAMAGE_CONDITIONAL_MODEL_20261121.md).

**21/11/2026 — Đã phân tích8 target/4 chuỗi và thêm mô tả cơ chế offline.**
Source `33997e9c…` (495 Python) chỉ thêm3 file,492 cũ nguyên byte. Tách Kiếm
quét/trực tiếp/known cascade;Nộ trước/gross Nộ/Hút và continuation chưa biết
giữ riêng,không suy fullPower/crit/damage. R13 ghép3 Nộ có3 Kiếm cascade đã
biết từ bàn trước;không lấy7 Máu tag sau response làm feature. Rà254 action
(31 mới+223 lịch sử),4 action first-wave0 có known Sword;1 later passive
giữ UNKNOWN.222 test PASS;poison future254/254 không đổi request/descriptor.
Chạy2 fold baseline cũ giữ policy:reference7/8 MAE7735,57;guarded2/8 MAE670,25.
Không sửa weights/target/forecast,nạp model hoặc thay nước live. Native
d699 và profile/cap/prefs/raw cũ nguyên;whole-source495 chưa native.0 trận/
input/attach/build mới,tổng32 đóng,còn0. UI17788 dừng1/1 là lần kiểm trước,
không kiểm lại. Mốc này đóng;tiếp theo predictor có điều kiện theo cơ chế
và Nộ,bất định về Hút/Khiên/refill/crit;chưa cần săn crit bằng trận thêm.
[Kết quả và giới hạn](DAMAGE_MULTITURN_REVIEW_20261121.md).

**21/11/2026 — Đã kiểm native d699: BASIC1 +R1; cap2/2 đóng.**
Cả hai WIN/nhận thưởng/về Priest131,0 safe stop/recovery/PASS. Source492
Python giữ nguyên;14 gate PASS,16 timing BASIC mới tạo profile R mới/max1.
R14 decision/42 checkpoint,replay14/14,85 event đủ,worker1/1 reaped.
52 operation context/230 operation hợp lệ,tất cả crit ABSENT,không suy false;
max tổng payload8586/32768.25 context ghép ACK;29 ACK có25 typed,4 gap
không scoped observation,cause UNKNOWN,không mất normalization.6 override
cùng bàn=1 CONDITIONAL_MECHANICAL_ADVANTAGE/3 TRADEOFF/2 INSUFFICIENT_DATA.
Dataset mới31 SWAP/8 DAMAGE target/4 đa DESTROY đã pin,không fit/deploy model.
Các profile/prefs/cap cũ nguyên,cap mới2/2 đóng,tổng32,còn0. UI17788 dừng1/1,
đúng lobby;hai nút Start do user bấm vì computer-use OS error3 sau retry.
Mốc logger native đóng;chưa có crit bool hoặc công thức damage. Kế tiếp
offline phân tích8 target/đa đợt phá mới,không chạy thêm ngẫu nhiên săn crit.
[Kết quả và giới hạn](DAMAGE_OPERATION_NATIVE_20261121.md).

**21/11/2026 — Đã làm hết phần offline có thể kiểm chứng; cần response mới.**
Source `d699a5ac…` (492 Python):488 file cũ nguyên byte,1 capture sửa và3
file thêm. Đã rà26 log chính đã đóng/13 cohort:223 SWAP,197 ACK,93 recorded
DAMAGE targets;40 ACK thiếu typed,64 không ghi DAMAGE,không điền0.25 fold
giữ policy cũ theo từng cohort,reference34/87,guarded13/87;cohort reader_trace
có2 guarded forecast sai lớn,MAE181.771. Không dùng model này để chọn nước.
Khiên/thứ tự/multidestroy đã audit;không sửa nhãn theo after-effect. Reverse
B17 xác minh client đọc crit từ BOSS_HP/STAT_CHANGE;log cũ bỏ trường này.
Đã thêm capture tùy chọn từ JSON đang đọc,phân biệt absent/null/bool,same
response/hash/order,32record/4KB và tổng32KiB;không thêm memory query.
210 test PASS,31 fixture giữ core cũ,28 observation c509 normalize nguyên.
Planner/input/PASS/profile/prefs/cap giữ nguyên;source logger mới chưa native.
0 trận/input/attach/build mới;tổng30 đã đóng,còn0. UI23260/c509 chỉ là quan
sát lịch sử,không kiểm lại. Đã pin plan đề xuất1 BASIC +1 R trên Priest131,
Demon560 ăn Khiên/4 Kiếm hiệu dụng/đồ giữ nguyên;chưa mở cap/claim/tool mới.
Không săn crit bằng trận thêm hoặc coi2 trận là đủ nghiệm thu damage model.
[Kết quả và chỗ cần dữ liệu mới](DAMAGE_OFFLINE_CLOSEOUT_20261121.md),
[plan chưa mở](artifacts/damage_offline_closeout_20261121/next_collection_plan.json).
Các mục bên dưới giữ lịch sử của từng source,không thay cho trạng thái mới này.

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

**19/11/2026 — Native Demon source `1bd824c2…` đã đóng 1 BASIC + 1 R.**
Priest131/Demon Aegis thường ăn Khiên, room300394: hai WIN/nhận thưởng/về
lobby; 0 safe stop/recovery/PASS. BASIC7 timing record, 6 ACK đủ tạo profile
mới đúng source/build/host. R9 decision/27 checkpoint hợp lệ, 6 override
đều ACK; log55 đủ, worker1/1 reaped, summary max11.752 B. Prefix floor hiện
ở một candidate thực chọn; paired trước/sau cùng snapshot lượt9 đổi từ
4 Máu sang quét3 Kiếm cùng tài nguyên, giữ rõ cost/UNKNOWN. Không chứng
minh tối ưu hoặc dùng số lượt hai ván để xếp hơn kém. Typed captures13+14
không lỗi, nhưng thiếu response hiệu ứng của3 nước ACK R (seq12/20/32),
gồm lượt9; gameplay vẫn đủ ACK/published state. Cap2/2 đóng, tổng nhóm15.
ToolPID28296 đang dừng1/1; main prefs/source giữ nguyên, không build/train.
**Tiếp theo:** offline kiểm coverage typed effects của Demon, Mega/GLX hoãn.
[Báo cáo và phạm vi nghiệm thu](DEMON_PREFIX_NATIVE_20261119.md).

**Ưu tiên user mới nhất: hoàn thiện Demon trước; Mega/Galaxy để sau.**
Không để thiếu dữ liệu skill chủ động chặn tiếp tục Demon passive.

**19/11/2026 — Demon giữ được phần kiếm/goal đã biết của đợt quét đầu.**
Source `1bd824c2…` chỉ đổi `_score`: khi có residual, F/D giữ lower bound
của prefix theo geometry đã khai báo, không nâng R/P/T hoặc chứng nhận
damage/kill. 80 test PASS; paired 643 (187 Demon, 456 lối khác). Đổi 4 SWAP
Demon trên cùng bàn; các cặp vẫn giữ đánh đổi/UNKNOWN, không là nhãn tốt hơn.
456 decision/score của lối khác giữ nguyên; cap 2→2, summary max 11.990 B.
BASIC/PASS/input/owner/reader/weights giữ nguyên; 0 live/train/build/rebind.
**Kế tiếp:** kiểm source mới trên Demon, ghi tradeoff cùng trạng thái và
timing đúng source; nhánh active skill Mega/GLX hoãn theo yêu cầu user.
[Bản sửa, hai cặp native và phạm vi](DEMON_PREFIX_FLOOR_20261119.md).

**19/11/2026 — Đã kiểm số dư ròng và độ phủ dữ liệu skill.** Chỉ thêm tool/
test offline, source `cbccf8c4…`; mọi file mã nguồn có trước giữ nguyên byte so với
`6a5f2c6b…`. 72 response B17, 65 khoảng published trước–sau, 197 update
Mana/Nộ: 179 exact + 18 cap/floor; cả 140 lastStat khớp endpoint. Gross
known gains chỉ khớp Mana 16/22, Nộ 9/22. Kiểm 643 snapshot: 24 mẫu đủ
costs là synthetic; 0 native active-skill cost/action/outcome binding được
chốt trong corpus. 55 test PASS, không thêm formula/đổi adviser/live/build.
**Kế tiếp:** chuẩn bị offline liên kết skill sent/card/cost/outcome trước
khi đề xuất thu Mega mới; skill sent/ACK hiện chưa được normalizer xác minh.
Không lấy affordability làm quyền bấm skill hoặc tái dùng cap live cũ.
[Báo cáo, dữ liệu và giới hạn](NET_RESOURCE_READINESS_AUDIT_20261119.md).

**19/11/2026 — Offline đã đóng: sửa phạm vi loại log và đối chiếu cùng bàn.**
Source `6a5f2c6b…`: giữ lại đúng 8 boss interval trước batch lỗi cuối trận;
batch đó vẫn INVALID/UNKNOWN, không sửa log gốc. Collector tách shape/limit
bằng metadata nhỏ, không nới giới hạn. Đã đối chiếu 643 snapshot/cấu hình
trên 619 bàn: 181 cùng nước, 402 có đánh đổi, 56 thiếu mô hình, 4 lợi thế cơ
học có điều kiện. Ba ca nhiều lượt lấy ít viên hơn có lý do counterplay/
thế ấn, chưa chứng minh bug định giá. 125 test PASS, đủ 643 action khớp bản
trước; adviser/BASIC/PASS/input/reader giữ nguyên byte. 0 live/train/build.
Native source `17c35c7e…` không được rebind sang source mới; profile cũ giữ
nguyên. Bước kế tiếp: audit tác động tài nguyên ròng/điều kiện skill từ
ordered trace có sẵn, giữ UNKNOWN nơi thiếu bằng chứng.
[Báo cáo, ca cụ thể và công cụ đối chiếu](OFFLINE_SAME_STATE_AUDIT_20261119.md).

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

**18/11/2026 — Offline mới nhất: source450abb97… sửa định giá Hút Mana/Nộ.**
Audit13 khoảng B17 phát hiện adviser chỉ xét Mana dù raw STEAL có cả POWER.
Shared tactics giờ xét từng Mana/Nộ, max-single-resource, thiếu số dư→unknown;
không đổi BASIC/input/PASS/skill guard. Summary thêm nguồn giới hạn. Paired
613 replay/83 đổi,tất cả swap→swap hợp lệ;222/227 test PASS,5 lỗi fixture cũ
tái hiện trên tactics trước sửa.0 live/train/build. Sourceb1b7 đã live
BASIC1+R1 theo mốc dưới **không** là live của450a; không rebind profile cũ.
[Báo cáo và việc còn mở](B17_REPLY_DRAIN_REVIEW_20261118.md).

**18/11/2026 — Mốc mới nhất: B17 boss before/after + R1 đã đóng.**
Sourceb1b718fb… chỉ thêm optional board/state logging và offline normalizer,
246 test PASS. Priest131/DemonShield: thêm1 BASIC8 lượt+1 R8 lượt,2 WIN
STRONG/confirm/return,0 safe stop/recovery/PASS. Có13 khoảng boss với bàn
trước/sau thực. R8 decision/24 ROOT-FRESH-FINAL hợp lệ;5 override thực gửi
(4 ACK+1 terminal),49 diagnostic0 loss,worker1/1 reaped. Profile mới dùng7
timing samples BASIC cùng source/B17/host; không rebind B16/95288. Các cap
đóng, tổng nhóm6 trận (5 BASIC+1 R),không tự restart hoặc tăng cap. Game
Priest/room911927, toolPID15904 stopped1/1. Chưa fit/build/skill;2 trận mới
khác board, không kết luận R nhanh hơn. [Báo cáo](B17_BOSS_BOARD_AND_REASONING_20261118.md).

**18/11/2026 — B17 Priest/Demon BASIC CLOSED:** source hiện tại95288bff…
giữ nguyên trong4 trận mới (1 thăm dò+3 tiếp theo),4 WIN STRONG/confirm/return,
28 lượt ta,24 ACK+4 terminal,0 PASS/safe stop/technical recovery.51 outcome,
166 effect;28 op của ta khớp nước gửi,21 op trong batch boss;22 STEAL đã có
POWER/MANA.17 observation Demon/10 usable nhưng0 calibration-eligible.
Game ở Priest131/room911927, tool dừng3/3. Cap4 đóng. Chưa REASONING B17,
profile/skill/train/build. Acc/boss/pet mỗi nhóm giữ riêng; full gear và
boss pre-board còn UNKNOWN. [Báo cáo](B17_PRIEST_OUTCOME_LIVE_20261118.md).

**Mốc offline trước live B17:** source923813c6… thêm
optional evidence stealType/ops SWAP, exporter observation chung và test.
137 batch/397 effect đã chuẩn hóa;186 test PASS;35 observation Demon cũ
giống hệt.11/11 power mismatch có pattern chạm trần. Chưa fit model,
đổi gameplay hoặc build/live. [Báo cáo](COMMON_ACTION_OUTCOMES_20261118.md).
Learned outcome/value/ranker đã xếp sau việc cũ. Skill binding/damage/heal
và boss action/refill còn cần dữ liệu có nguồn; không dùng WIN làm nhãn
tối ưu cho mọi nước. [Backlog hiện tại](RESEARCH_BACKLOG_20261118.md).

**Mốc live trước đó:** source9b4a2109… đã qua live có giới hạn
3 BASIC +3 REASONING trên B16/Lion Star105/Demon Aegis ăn Khiên,6WIN. Hai
nhánh bounded-unknown đã thực sự chạy,21 quyết định/63 receipt hợp lệ,
129 record không mất,3worker reaped. Chưa build source này hoặc suy ra
nghiệm thu mọi style/pet/ZIP. [Live report](BOUNDED_FUTURE_NATIVE_20261118.md).

Hướng hiện tại sau khi rà temp: nối tiếp nhánh dữ liệu effect/damage còn mở,
giữ model học trong backlog; không làm lại tactical planner đã áp dụng.
[Backlog và thứ tự](RESEARCH_BACKLOG_20261118.md), [STATUS](STATUS.md).
Các cap live đã đóng; dữ liệu thiếu ở skill/boss action chưa được bù bằng
giả định. Phần dưới giữ nguyên danh tính bàn giao UI01/11, là lịch sử của
checkpoint cũ, không phải trạng thái source hoặc lệnh chạy hiện tại.

## Bàn giao UI01/11/2026 — lịch sử

**Checkpoint1.3.0 ngày01/11/2026:** [báo cáo và artifact](../v1.3.0_release_report.md).
Scope hiện tại giữ nguyên; [AI chung và mọi targetDemon](NEXT_REASONING_SCOPE.md)
là yêu cầu phần tiếp theo, chưa triển khai. Bảng dưới giữ danh tính bản UI live gốc.

Ngày01/11/2026. **Task UI đã CLOSED PASS trong scope đã kiểm**.
Roadmap Phase5 đã đóng; không có prompt hoặc trận live bắt buộc còn thiếu.
Chưa đổi version/phát hành sau nghiệm thu UI. Hướng công việc tiếp theo đang
chờ user chọn, không tự mở model, lối chơi hoặc batch mới.

## Bản UI live gốc

| Mục | Danh tính |
|---|---|
| Version trên bản thử |1.2.10; khác release1.2.10 cũ và ZIP F1 |
| Thư mục EXE |`D:/PokiguardToolV2/build/ui-reasoning-20261031-final/dist/PokiguardToolV2/` |
| EXE SHA256 |`2969293466f5e8b8f0dcca593cdc837ae694633dcfddcf97fb635fecd3243f51` |
| ZIP |`D:/PokiguardToolV2/build/ui-reasoning-20261031-final/PokiguardToolV2-v1.2.10-win-x64.zip` |
| ZIP SHA256 |`fcf29a1ab2c0b32e4398307e92e12879d5ac559325125ede4fbfef006a9d3c26` |
| Source375Pythonfiles |`4d07f02ed2f1817c1d87557f6ea837caea19dcce6a4e4a81f554f7b7089c2a49` |
| Kết quả UI live |1BASIC+1UI-R,2WIN/confirm/về phòng;6Rcompleted retention,31AIrecords/0loss,1workerreaped |

[Báo cáo UI](ui_reasoning_delivery_20261031.md),
[closure có raw refs](artifacts/ui_reasoning_delivery_20261031/live_closure.json),
[kiểm cuối](artifacts/ui_reasoning_delivery_20261031/final_live_verification.json).
Hai trận có bàn cờ khác nhau; không dùng số lượt1và6 để kết luận R tốt/kém hơn.
Đổi nước so với BASIC không là điều kiện để suy luận hoạt động hợp lệ.

## Phạm vi được bật

Demon Farm, ăn Khiên, Solo/Lieyun77, pet thường/không tiến hóa/nội tại,
4Kiếm hiệu dụng, cùng account/đồ/stats/gameb12/host đã kiểm; tiền cảnh,
hai lần nhấp,1280×640. Budget thực dùng tối đa4000ms, còn trừ reserve/margin.

BASIC là mặc định khi chưa có lựa chọn đã lưu. UI nhớ lựa chọn user đã lưu;
khi intent R bật nhưng thiếu/sai profile hoặc lỗi AI, farm tiếp tục bằng BASIC
hợp lệ và hiện lý do. Các chốt an toàn state/input cũ vẫn giữ nguyên.
Không mở target gem khác, boss/account/host khác, HT7/Mega/Coop/DinosaurR,
skill/PASS/model/R2 từ nghiệm thu UI này.

## Profile và cách mở đúng bản thử

Profile là dữ liệu riêng **ngoài ZIP**, ở:
`docs/phase5/artifacts/ui_reasoning_delivery_20261031/live_final_data/preferences/reasoning_acceptance/acceptance.json`.
DataRoot của phiên đã kiểm là:
`D:/PokiguardToolV2/docs/phase5/artifacts/ui_reasoning_delivery_20261031/live_final_data`.

Profile pin cả source/EXE/đường EXE/game/host/cohort; không chép profile này sang
máy/đường EXE/binary khác rồi coi là đã được nghiệm thu. ZIP riêng lẻ không
chứa hồ sơ account hoặc tự bật quyền chọn nước R. Chạy với dataRoot thường
không có profile thì dùng BASIC và báo lý do; đây là fallback đã thiết kế.
Thay đường EXE hoặc build/version cần chuẩn bị profile tương ứng và kiểm đúng
phần thay đổi, không sửa hash để ép hồ sơ cũ qua gate.

Không dùng lại request/claim/cap F1/E2 đã đóng. Hai lượt kiểm UI mới cũng đã
dùng đủ; agent không tự thêm trận. Tool chỉ farm khi user tự Start theo giới
hạn user chọn, không có auto-start/auto-resume mới.

Trong AI, chọn Suy luận Demon Farm—Khiên rồi Lưu cấu hình AI để dùng ở lần
Start/Tiếp tục sau. Muốn tắt, đợi phiên dừng, chọn Cơ bản, tắt shadow nếu không
cần và lưu AI. Không cần đóng/mở tool chỉ để đổi intent khi controller đã dừng.

## Log và rollback

- Trận: `logs/farm_runs/<farm_run_id>/`, gồm run/checkpoint/combat.
- AI: `logs/farm_runs/reasoning/ui_<id>/`; session.json nối về farm run,
  watermarks.json xác nhận drain/reap; correlation`<UIrun>:<combatIndex>`.
- UI: `logs/desktop_ui/<session>/`; phân biệt intent đã lưu với trạng thái R
  thực sự completed hoặc fallback.
- [Rollback](ROLLBACK.md) giữ9ZIP cũ, không đè release bằng bản thử.

22test UI mới PASS,100cycles qualification và134modules+entry parity đã kiểm.
Bộ hồi quy rộng có các lỗi lịch sử đã đối chiếu, không gọi toàn bộ suite xanh.
Sharedguard không hết/aggregate reserve không vượt trong live;3soft flags
controller-tail được giữ trong log và report. NativeU/actualenergy cònUNKNOWN,
efficacyINCONCLUSIVE. Các hạn chế này không được đổi thành kết luận đã hỗ trợ.
