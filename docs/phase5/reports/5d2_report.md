# 5D.2 — Chịu đấm ăn xôi

Ngày **2026-10-18**. **5D.2 PASS STRONG — scoped Huyền thoại 7; next 5D.3**.

Đã đóng [batch DarkQueen110 REASONING2](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/closure.json): **2/2attempt,2WIN**,24SWAP/24ACK,5skillPerfect; nhận quà2lần,vềBOSS_LOBBY,dừng FARM_TARGET_COMPLETED. Zero observed critical/read/DTO/technical-abort/recovery; request đã consumed,remaining0. DarkQueen case tổng3attempt=1BASIC+2REASONING; ledger Starburst10/10 giữ nguyên.

Suy luận hoàn tất30jobs:18SWAP overrides,1skill override,3PASS selections,6completed BASIC retentions;2đề xuất bị native guard giữ lại BASIC. Có skill khi **6effectiveSword<setting7**,đủ cost200Mana/200Rage; có2chuỗi skill→boss→fresh reasoning SWAP/ACK. PASS25/31 được server xác nhận;PASS27 thiếu AFK payload,không suy count2: existing owner bắt buộc SWAP29/ACK/reset trước khi cho PASS tiếp. Không có third-PASS hoặc input trong PASS wait. [Gate decision](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/gate_decision.json).

Scope accepted là technical opt-in cho SkillRush/HT7card7/pet2035/account/boss/input/build đã pin,conditionalPerfect/first-wave. BASIC vẫn default; QTE/reader/capture/input/ACK/farm không đổi. Source322`41dd8b30…` giữ nguyên suốt live; offline459/459tests và worker/setup qualification đã đóng.151records durable/0loss,2workers reaped; worker compute median75.583ms,max150.484ms. Không claim efficacy,damage/heal/refill/boss-skill model hoặc latency tương lai;PASS27counter và actual account energy vẫnUNKNOWN.

**Không cần thêm live5D.2.** Next đúng một prompt: [5D.3 — Demon Aegis](../prompts/5D3_DEMON_AEGIS_ACCEPTANCE.md),chưa triển khai/chưa activate liveD3. Không thêmP/build/version/Git/release. [Báo cáo](5d2_report.md).

Các mục phía dưới giữ lịch sử theo source/batch; mục final cuối báo cáo là quyết định hiện tại.

## Phạm vi và cấu hình

User yêu cầu suy luận quyết định **SWAP / PET_SKILL / PASS**, gồm thời điểm
nên dùng skill hoặc chờ. QTE/executor/ACK/đóng lượt vẫn như cũ. Ngưỡng chiến
thuật là tham khảo; actual cost/source/cooldown/actionability và PASS legality
là bắt buộc. Chỉ xếp hạng swap không hoàn tất acceptance profile này.

Cohort được user chọn: **Starburst73 + Huyền thoại7**, Solo. User sửa ngưỡng
trước first Start từ10 xuống **7 effective Sword units**, tính cả x2/x3.
Pet runtime là Alacclipse2035, skill card7, familyAUTOMATIC_DOT_DESTRUCTION;
cost runtime200Mana/200Rage, cooldown0. Không hard-code cost từ fixture.
BASIC giữ setting7 cố định; REASONING xem đó là tham khảo, không mặc định7 là
chứng minh lethal. PetLegendary/noEvolution/PetSkill/AuditionV3/foreground/
two_click. Ordinary preferences không ghi đè; private session config riêng.

## BASIC control đã hoàn tất

FarmRun `b5833c49aba64eada60773f2a25098e5`, request
`e657dbc73c79e4efbc8cdc5989537c0c3784216b8a836ded8d6a17352abd2a05`.
Source310 `dd2e7ea238d386448b08a50539333c44e9b73ff8c000b5cf57a8eb32d748fee6`.

| Attempt | MatchId | Result | Local turns | SWAP/ACK | Skill |
|---|---|---|---:|---|---|
|1|M_fd767aa9|WIN|7|6/6|SUCCESS_PERFECT atturn13|
|2|M_a68a8434|WIN|6|5/5|SUCCESS_PERFECT atturn11|
|3|M_aa522bf7|WIN|7|6/6|SUCCESS_PERFECT atturn13|

3/3completed/WIN,0technicalabort/recovery,0observed critical safety counters,
3normal boss-lobby returns, finalFARM_TARGET_COMPLETED. Active elapsed321.498s.
20localturns chỉ là toolproxy;account energy debitUNKNOWN. Không claim efficacy.
17SWAP sent/17ACK;17timing returns,23events durable,0loss/disabled.
SWAP Hmax297.855ms/Imax2828.7185ms;không gọi maxima là future bound.

Cả3skill:1cardclick,1Space,7/7directionsconfirmed,0wrong/duplicate/stale/
skipped/unconfirmed/blindretry. Mỗi skill thành công đều dẫn tới COMBAT_TERMINAL;
source turn được đóng, không có same-turn fallback input. PASS và later local
turn sau skill **NOT_OBSERVED**; không thêm trận để cố gặp chúng.
[Closure+raw hashes](../artifacts/5d2_skill_rush_v1/basic_control/closure.json).

Original batchcap6 đã dùng3 BASIC;3REASONING chưa chạy, vẫn được giữ riêng.
Không reset claim, không relabel các trận BASIC thành suy luận.

## HT7 model theo xác nhận trực tiếp của user

Perfect ăn toàn bộ **SWORD/RAGE/HEALTH** trên bàn;setting7 là effective Sword
units. [Calibration scope](../artifacts/5d2_skill_rush_v1/ht7_user_effect_scope.json)
được ghi USER_CALIBRATED, conditionalPerfect/first-wave, boundaccount/pet2035/
card7/session. Không suy GOOD/BAD, damageHP, sốHP hồi, cascade/refill, thứ tự
cost/gain hoặc post-skill balance. Ba WIN không chứng minh damage formula,
không chứng minh mọi board có7Kiếm đều lethal. Raw timing metadataeatPerfect0
không được diễn giải thành sốgem bị phá vì field semantics chưa chứng minh.

## Lịch sử component offline sau control

Ở mốc component trước khi tích hợp, thêm pure immutable
`reasoning_action_candidates.py`; kết quả tích hợp hiện tại ở mục cuối:
- enumerate SWAP, skill và PASS, giữ cả reason của action bị loại;
- skill availability không bị khóa bởi tactical count setting, nhưng thiếu
  cost/nguồn/cooldown/card actionability hoặc sai session vẫn bị loại;
- PASS phải có authoritative status/counter/source, không opening/mandatory;
- pending hoặc source turn vừa skill chưa đóng chặn cả ba nhóm;
- giữ UNKNOWN khi chưa có comparison effect; action không chấm được không
  bị coi là utility0 để ép action khác thắng;
- conditionalHT7 first-wave geometry từ đúng account/pet/card/session, tách
  physical/effective; không forecast outcome cho action chưa chọn.

Các pure fixtures có resource thiếu/đủ,setting9/10,correct/foreign history,
HP-sensitive synthetic effects và opaque baseline retention:
[paired replay](../artifacts/5d2_skill_rush_v1/paired_cases.json).
Chúng là SYNTHETIC_SPEC, không nâng thành native skill efficacy proof.

**259/259 focused tests PASS** trên source313 tại mốc này, gồm policy/capability,
QTE/dispatch/continuation, pure action evidence, optional timing, collector,
D1 native/regression. [Final log](../artifacts/5d2_skill_rush_v1/final_regression.log).
Đây không phải full repo suite. Failed logs trước đó giữ nguyên: lỗi enum,
fixture thiếu account/source identity/derived property, mock clock chưa đủ
lần và deque-vs-list expectation đã sửa trong test; không che runtime failure.

## Native timing gap — nguyên nhân xác định

Lúc chuẩn bị BASIC3, tôi chỉ bật timing SWAP và bỏ sót span của primitive skill.
Log skill đang dùng `time.monotonic`/GetTickCount64; swap reasoning timing dùng
`time.perf_counter_ns`/QueryPerformanceCounter. Không có recorded clockalignment
cho các span đó. Vì vậy không thể lấy timestamps khác clock ghép thành H/I
của skill. [Clock gap](../artifacts/5d2_skill_rush_v1/skill_clock_gap.json).
Đây là thiếu sót phép đo; không phải QTE lỗi hoặc tool dừng giữa trận.

Đã bổ sung BASIC-only optional timing trước/sau **nguyên lời gọi
run_embedded_policy_action hiện có**, cùng QPC clock với decision exit. Nó đo
wholeprimitive return như endpoint uppercompletion; không giả đã đo firstclick.
Không thêm game read/capture/input, không sửa QTE/click/key/lease/turn owner.
AST test bỏ đúng2optional timing blocks khôi phục toàn bộ controller cũ;
QTE code files byte-exact. Sink lỗi chỉ disable measurement, không gửi lại input.

Source313 của đợt timing probe, giữ nguyên như evidence lịch sử:
`2a25b750572eaaf1c8d28ee6101cfbc9066c9cfc56a4834e35e676b4003c202f`.
[Source map/delta](../artifacts/5d2_skill_rush_v1/action_source_freeze.json).
Original control dd2 không relabel thành current source. D1 ba4856 acceptance
vẫn là lịch sử scope cũ. HEAD giữc646acfa5e895732bbdade553f9d7bd61171cd29.
V1/game read-only,package1.2.5 unchanged;không build/version/Git write.

## Đã hoàn tất 1 trận BASIC đo timing skill

User chấp thuận riêng bằng “oke vậy mở tool để chạy”, sau đó tự bấm Start và
báo “đã bấm”. Phiên UI PID11088, FarmRun `e21d1b979ae343848ce70f8492e0ddd8`,
match `M_d92437d6`, source313 `2a25b750…` giữ nguyên từ lúc chuẩn bị tới đóng log.
Đúng Starburst73/HT7/7 effective Kiếm, BASIC/shadow OFF, cap1. Request đã claim;
không reset/restart hay thêm retry. Đây là trận đo riêng, không đổi original cap6.

Kết quả: **1/1 WIN**, 11 lượt local (proxy, account energy debit UNKNOWN),
10 SWAP/10 ACK, 0 technical abort/recovery và tất cả critical safety counters0.
Skill lượt21 có đúng1 card click, đủ7/7 hướng,1 Space, SUCCESS_PERFECT.
Sau skill là COMBAT_TERMINAL, không có same-source follow-up input. Có1 lần
xác nhận phần thưởng và trở về BOSS_LOBBY; tool dừng vì FARM_TARGET_COMPLETED.
Opening proposal bị state-change veto trước input rồi được xét lại; không
phải mất ACK. `postmatch_observation_timeout` là handoff từ combat sang farm,
sau đó farm xác nhận thưởng/về phòng bình thường, không phải technical abort.

| Khoảng đo cùng `perf_counter_ns` | Mẫu skill đã quan sát |
|---|---:|
| Decision exit → primitive start | 142.9096 ms |
| Toàn bộ primitive skill → return | 4688.1916 ms |
| Decision exit → primitive return | 4831.1012 ms |

Interval khớp match/turn/card/source hash với native dispatch/result, thứ tự
timestamp hợp lệ, `complete_interval_bound=true`. Endpoint là **toàn bộ primitive
trả về**, gồm QTE hiện có; exact first click vẫn NOT_MEASURED. Đây là1 mẫu quan
sát, không phải bảo đảm latency tương lai hay authority để dùng deadline chưa
review. Không trộn clock của BASIC3 cũ. SWAP mới Hmax291.9761ms/Imax2965.6073ms.

12 timing records:10SWAP +1 superseded decision +1skill; writer flushed/closed,
0loss, collector không bị disable. PASS/later local turn sau skill vẫn
NOT_OBSERVED. Không thêm trận để cố gặp. Ordinary preferences và D1 parent
acceptance giữ nguyên hash; không sửa runtime code/QTE trong lần đo này.

[Closure và hash raw evidence](../artifacts/5d2_skill_rush_v1/skill_timing_probe_proposal/closure.json),
[ledger riêng cap1](../artifacts/5d2_skill_rush_v1/skill_timing_probe_proposal/attempt_ledger.json),
[analysis tái lập](../artifacts/5d2_skill_rush_v1/skill_timing_probe_proposal/closeout_probe.py).
Proposal/preview PREPARED_NOT_ACTIVATED được giữ nguyên như snapshot trước
approval; trạng thái thực tế hiện tại được ghi ở closure/ledger/active_session.

## Tích hợp full-action offline đã hoàn tất — 2026-10-17

Source hiện tại **319 file Python**, fingerprint
`215ca4e62b31eaeec2cd57499608090147bd41ca313a8199c22eb52140a7178c`.
[Source freeze](../artifacts/5d2_skill_rush_v1/offline_completion_v1/source_freeze.json),
[verification](../artifacts/5d2_skill_rush_v1/offline_completion_v1/verification.json).
Worker cô lập nhận cùng snapshot hiện có và so sánh toàn bộ SWAP hợp lệ cùng
PET_SKILL/PASS đủ điều kiện. Không thêm lần đọc game/chụp ảnh để chờ suy luận.

Setting 7 Kiếm vẫn là baseline của Chịu đấm ăn xôi; planner có thể chọn skill
trước/sau ngưỡng nếu utility có căn cứ. Actual cost/cost source, đúng pet/card/
session, cooldown, actionability, quyền PASS và source turn vẫn là hard gates.
Mana30/Nộ20 và HT7 Perfect chỉ dùng trong scope đã ghi USER_CALIBRATED. Resource
đã đủ không tiếp tục nhận credit tích vô hạn. HP hiện tại thay đổi trọng số
pressure; Sword/Health/Shield là opportunity proxy, không phải damage/heal HP.

Perfect model chỉ first-wave Sword/Rage/Health. Sword gốc bị phá có threat
proxy0, nhưng threat sau refill/boss skill vẫn UNKNOWN và refill exposure vẫn
bị phạt. Không dự báo outcome WIN/lethal/survival cho action chưa chọn. Action
thiếu essential model không được chấm0 để ép action khác thắng. Fixture synthetic
đã chứng minh có thể chọn PET_SKILL khi ngưỡng advisory chưa đạt, và giữ đúng
PET_SKILL của BASIC khi đó là lựa chọn tốt nhất; không có quota phải đổi nước.

Snapshot/worker reply được bind source/config/account/capability/history;
validator dựng lại action evidence và tính lại kết quả trước khi nhận proposal.
Completed retention hợp lệ có receipt, nên SWAP trùng BASIC sau khi suy luận
hoàn tất cũng không cộng thêm random delay. Error/timeout/opaque comparison
giữ BASIC hợp lệ, gồm random path cũ. Đổi source/action family hoặc capability
ở preflight sẽ hủy quyết định chưa phát input và quay lại vòng hiện có; không
đưa action vào sai executor. Sau dispatch giữ fence cũ, không second input.

Controller chỉ có các seam optional dành riêng D2. AST bỏ đúng các seam đó
khôi phục controller trước tích hợp; input/QTE/executor files byte-exact.
Stop vẫn kiểm trong decision budget, không chờ worker cleanup trước Stop ACK.
D2 có loader/native review riêng; không dùng acceptance D1 làm authority D2.
27 SWAP và4 skill native được kiểm đối chiếu lại với log primitive, source/
cost/ownership, loss và các batch gốc; không relabel origin source310/source313.

## Kiểm chứng và reserve của gói cuối

- Broad regression **504/504 PASS** trên source `2e75b8c6…`.
- Sau sửa completed retention/context validation, focused **153/153 PASS**
  trên source `a01ae986…`. Các số này không được cộng thành unique test count.
- Delta duy nhất sau focused là thêm `import math` bị thiếu ở setup-only loader;
  exact delta đã kiểm. Final source `215ca4e6…` qua setup preview và qualification.
- Final qualification **100 cycles, 4 lanes** SWAP/PET_SKILL/PASS/completed
  retention; measured selector overhead max **6.2624ms**, 0 log loss, actual
  isolated worker roundtrip và durable writer. Đây là host cost offline,
  không phải native override latency hoặc proof hiệu quả gameplay.

[Test lineage/logs](../artifacts/5d2_skill_rush_v1/offline_completion_v1/verification.json),
[qualification](../artifacts/5d2_skill_rush_v1/offline_completion_v1/pilot_package_ready/selector_allowance.json),
[setup preview](../artifacts/5d2_skill_rush_v1/offline_completion_v1/preview_final.json).
Các failed logs trước fix vẫn giữ nguyên trong artifact, không xóa khỏi lineage.

| Reserve component | ms | Scope |
|---|---:|---|
| Controller tail H | 297.855 | Native observed max |
| Whole skill primitive I | 4688.1916 | Một native skill sample, gồm QTE |
| Selector extra | 6.2624 | Final source, 100 offline cycles |
| Full BASIC wait ceiling | 3120 | Giữ đủ thời gian fallback theo path cũ |
| Shared host guard | 250 | Một pool dùng chung, không nhân đôi |
| Tổng | **8362.309** | Thêm return margin100ms |

Compute budget tối đa4s từ observation start, bị rút theo timer/reserve; không
chờ cố định4s, hoàn tất thì trả sớm. Reserve bảo thủ dùng whole skill primitive
cho các family, giữ khả năng fallback. First click, native transport age/U,
OS stall và latency tương lai không được chứng minh từ sample maxima. Live
monitor ghi vi phạm và ngắt nhánh AI; không replay input đã phát.

## Lịch sử trước batch REASONING3 v1

Gói duy nhất dùng cho live là
[pilot_package_ready](../artifacts/5d2_skill_rush_v1/offline_completion_v1/pilot_package_ready/draft.json):
**OFFLINE_PREPARED_NOT_ACTIVATED**, chưa tạo request/claim, chưa mở UI hay phát
live input trong bước hoàn tất offline này. Các draft cũ giữ như lịch sử.
[Runbook live](../artifacts/5d2_skill_rush_v1/offline_completion_v1/LIVE_RUNBOOK.md).

Original batch vẫn3BASIC completed/0REASONING, còn3REASONING reserved; tính cả
probe riêng đã dùng4 trận, tổng tối đa được chấp thuận7. Không thêm BASIC,
không tự retry request consumed, invalid/abort vẫn tính trong cap3 còn lại.
Phiên probe PID11088 đã đóng; cần user chuẩn bị lại Starburst73/HT7/thẻ Attack,
đứng ở boss lobby trước khi kích hoạt phiên mới. User tự Start trong TOOL.

Live cần đối chiếu proposal/retention/fallback với action thực, ACK/QTE, deadline,
flow thưởng/về boss lobby và counters. PASS, skill hoặc continuation không gặp
thì ghi NOT_OBSERVED, không thêm trận để ép gặp và không PASS chỉ vì thắng3.
Damage/heal/refill/boss policy chưa prove vẫn UNKNOWN. Ordinary preferences,
parent D1 acceptance và package1.2.5 giữ nguyên; chưa build/version/Git write.

**D2 vẫn PARTIAL; offline complete, next là REASONING3 live của chính 5D.2.
Chưa sang D3, không sinh P mới.**


## Lịch sử mở phiên REASONING3 v1

User xác nhận đã vào phòng boss. Request riêng được activated sau xác nhận,
UI PID36668; log OPERATIONAL_PILOT_PREPARED, không rejection. Poller hiện có
nhận BOSS_LOBBY/Starburst1289/lv73, game PID38520, controller IDLE và0 starts.
Chưa claim/attempt/input; user tự bấm Bắt đầu trong TOOL. Ordinary preferences
không ghi đè. [Active session](../artifacts/5d2_skill_rush_v1/offline_completion_v1/pilot_package_ready/active_session.json),
[Ready evidence](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/ready.json).

## Kết quả batch REASONING đã được kích hoạt

FarmRun `f60fc7f4d1c04d098e59ad9bc9af2e33`, request
`700ccb5dcefbc4b4074906533602cf55c828f083dc449f810cfa7cb8d424b19d`,
source319 `215ca4e6…` (v1), kết thúc `FARM_TARGET_COMPLETED` và BOSS_LOBBY.

| Attempt | Match | Kết quả | Lượt local proxy | SWAP/ACK | Skill |
|---|---|---|---:|---|---|
|1|M_b4c2cf16|WIN|5|4/4|Perfect, turn9|
|2|M_373f67c9|WIN|8|7/7|Perfect, turn15|
|3|M_d42597cd|WIN|6|5/5|Perfect, turn11|

3/3 WIN,16 SWAP/16 ACK,3 skill Perfect: mỗi skill1 card click/1 Space/7 hướng
confirmed,0wrong/skipped/duplicate/stale/unconfirmed/blind retry.0technical
abort/recovery,3normal postmatch,3xác nhận thưởng, trở về boss lobby.19localturn
là proxy, account energy debit UNKNOWN. [Closure/raw hashes](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/closure.json).

Tuy nhiên chỉ4 quyết định REASONING ở trận1(turn1/3/5/7), đều SWAP khác BASIC
và qua ROOT/FRESH/FINAL rồi dispatch/ACK. Khi BASIC chọn skill ở turn9,
background adapter báo `baseline not legally represented` và bị disable.
Skill turn9 cùng cả trận2–3 chạy BASIC. Không relabel hai trận sau thành
REASONING thành công. Skill/PASS comparison của v1 chưa có native acceptance.
Writer25/25 durable,0loss; watermark healthy=false do bridge exception,
`FINALIZER_UNCONFIRMED` là lỗi downstream của unhealthy bridge, không phải
25 records bị mất hoặc QTE/gameplay hỏng.

**Original cap6 đã dùng6, probe riêng1 đã dùng1: tổng7/7, không còn reserved
attempt.** [Combined ledger](../artifacts/5d2_skill_rush_v1/combined_attempt_ledger.json)
nối hash ledger BASIC gốc, không sửa bytes của ledger/probe closure lịch sử.
Không reset request/claim, không tự chạy thêm trận.

## Nguyên nhân đã tái hiện và sửa offline

`tools/basic_auto_bot.py:_current_pet_skill_capability` chủ đích gọi provider
với `source_pet=None`; capability vẫn có đúng current session/card7/CardUI/
Button/cost/actionability nhưng `pet_id` và `source_pet_skill_card_id` là None.
Trong v1, action evidence lại bắt buộc source pet skill ID bằng card ID, và
model bắt buộc Pet ID2035. Cả4 worker summaries đã ghi skill excluded vì
`SKILL_SOURCE_OR_FAMILY_UNSUPPORTED`; khi baseline đổi sang PET_SKILL thì
không còn eligible baseline và ném exception. Fixture v1 đã tự thêm Pet ID vào
capability nên bỏ sót đúng hình dạng của production helper. Đây là lỗi adapter/
fixture của suy luận, không phải game thiếu Mana/Nộ, skill/QTE hoặc cost decode.

[Tái hiện trước sửa](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/reproduced_before_fix.json)
giữ source_pet=None, current card7 đủ200/200: BASIC chọn PET_SKILL nhưng v1
loại skill và ném đúng exception. Replay gộp policy state với capability của
primitive muộn hơn294ms không phải exact failed root packet; không dùng replay
đó để khẳng định mọi field tại root. Nguyên nhân trên được xác định bằng call
chain production helper→provider và cùng error/reason tái hiện offline.

Sửa v2 `5d2.ht7_full_actions.v2` chỉ trong reasoning adapter/planner/request
preparation/tests. Không sửa production helper, provider, controller loop,
QTE/executor/ACK hoặc thêm game read/capture. Request phải khai rõ source policy
`CURRENT_OWNED_HT7_CARD_WITH_OPTIONAL_PET_V1`. Model vẫn USER_CALIBRATED và
conditionalPerfect, bound account + actual current owned card7/family tự động;
nguồn calibration là pet2035/card7. Runtime Pet ID không được cung cấp thì
ghi **UNKNOWN_NOT_PUBLISHED_BY_DECISION_PATH**, không tự gán2035 từ lịch sử.

Card-only binding chỉ nhận exact current session, ownership, CardData/CardUI/
Button addresses hợp lệ, source CARD_UI_BUTTON, card7 khớp skill7 và đúng family/
target mode. Metadata pet hiện diện nhưng khác/conflict vẫn reject; costsource/
chi phí/cooldown/actionability/current resources/owner/PASS vẫn hard gates.
Đây là correction binding cho card HT7 hiện có, không mở model sang card khác.

Thiếu comparison evidence của baseline được ghi `reasoning.preparation_fallback`
với family/reason và trả BASIC qua preflight cũ cho source/job đó; không giết
bridge chỉ vì expected missingness. Malformed worker/source/state và faults
khác vẫn theo fail-closed/circuit breaker hiện có. Không sửa/nhả fence sau input.
Test mới dùng chính production helper với fake provider thay vì tự thêm Pet ID,
và có missing/foreign-source negatives. Kiểm chứng offline đã chốt bên dưới;
native v2 acceptance chưa có. Không sang D3.


## Audit bổ sung của batch v1

Writer25/25 và0loss chỉ là phạm vi writer đã nhận. Collector sequence6 nhưng
raw durable timing chỉ1..5; sequence6 sau bridge fault chưa được xác nhận durable.
Không gọi toàn bộ diagnostics loss-free và không dùng batch lỗi làm native skill
timing authority. [Audit](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/closure_audit.json).

Phiên UI chỉ ghi private session_preferences (2 lần); ordinary preferences có
Demon Farm/450 matches được lưu lúc18:40:24Z, sau UI probe đóng18:32:50Z. Không
quy kết writer của thay đổi sau đó; giữ nguyên cài đặt hiện tại, không restore
file từ snapshot cũ. D1 acceptance vẫn exact hash. [Boundary proof](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/runtime_boundary.json).

## Chốt sửa offline — chỉ còn live của chính 5D.2

Source cuối **319 file Python**:
`f9b1b15efe264e9bf5275dfb1f0235bff7a57db593d06b03e05e149b28bb50e6`.
[Verification/lineage](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/verification.json),
[source freeze](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/final_source_freeze.json),
[replay sau sửa](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/reproduced_after_fix.json).
158 file Python thuộc controller/provider/solver/policy/QTE/executor/ACK/farm và
các phần ngoài reasoning/test/setup helper giữ nguyên bytes so với trước sửa.

| Kiểm chứng | Kết quả và scope |
|---|---|
| Focused01 |99 tests;24 full-action mới pass,1 historical manifest stale fail trước cập nhật review|
| Regression02 |Harness stdin bị Windows spawn lỗi `<stdin>`, gián đoạn; không dùng làm acceptance|
| Regression03 |620 tests/29 modules:617 pass,3 fail; source `8fb26e63…`|
| Fixture correction |Chỉ2 test files đổi sau broad; production code byte-exact|
| Affected04 |76/76 PASS: config projection, root policy, operational lifecycle, D2 native|
| Final qualification |100 cycles/4 lanes;50 capability như production không Pet ID,50 có metadata;max5.7434ms,0loss|
| Setup preview |PASS trong temporary synthetic request, không claim/worker/UI/reader/input; bản thực vẫn draft|

Ba fail broad: oracle legacy identity chưa loại optional `action_profile=None`;
hai healthy-retirement tests dừng ngay khi worker chưa READY nên không đặt rõ
prerequisite của expiry/cap gate.10 standalone repetitions không tái hiện hai
cleanup failures; không quy kết chắc chắn nguyên nhân OS/runtime từ đó. Fixture
healthy-close nay đợi READY tại test owner rồi mới retire; các test Stop/race/
unhealthy cleanup vẫn giữ. Không tăng startup/cleanup/deadline của runtime để
cho test pass. Chạy lại toàn bộ4 nhóm bị ảnh hưởng76/76. Không claim một lượt
620/620 trên source cuối; production code đã qua617 broad cases không đổi sau
đó và các assertion/fixture bị ảnh hưởng được kiểm lại đầy đủ.

Qualification cuối có actual isolated worker roundtrip với capability thiếu
Pet ID, completed retention receipt và durable writer; đây vẫn là software/
host-cost proof, không native gameplay efficacy. Selector max5.7434ms,
reserve **8361.790ms** (H297.855 + I4688.1916 + BASIC wait3120 + selector5.7434
và shared host guard250), thêm return margin100ms. Compute cap4s rút theo timer.
Không gọi sample maxima là future guarantee, không dùng faulted v1 skill timing.

[Gói sửa đã chuẩn bị](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/pilot_package_remediation/draft.json)
là **OFFLINE_PREPARED_REMEDIATION_NOT_AUTHORIZED**, source cuối đã qualify và
[setup preview](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/preview_package.json)
PASS. Chưa tạo actual request/activation/claim, chưa mở UI mới hoặc live input
sau sửa. Original cap7 đã hết; đề xuất **một batch mới3 attempts**, total10 chỉ
khi user trực tiếp chấp thuận, không tự coi đây là3 reserved cũ.

Lý do cần live:3 skill trước do BASIC thực thi và successor AI đã disabled;
offline không thay thế proof native skill comparison/retention và3-combat
succession trên source sửa. Giữ Starburst73/HT7/thẻ Attack/7 effective Kiếm,
private source session, manual TOOL Start. [Runbook](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/RUNBOOK.md).
PASS/continuation không gặp thì NOT_OBSERVED, không thêm trận để ép gặp.
**Offline complete; chờ user kích hoạt batch mới. D2 vẫn PARTIAL, chưa D3.**

## Mở phiên kiểm chứng sau sửa — 2026-10-17 12:34 Asia/Saigon

User đã xác nhận phòng Starburst73 và yêu cầu mở tool; đã activate đúng source319 `f9b1b15e…`, request `d9e68bfa…`, run `64286049315d487a856fdab8acdcb717`. Batch mới tối đa3 attempts, combined cap10 với7 đã dùng; không tái sử dụng request cũ. UI PID20984 nhận đúng boss1289 lv73, healthOK, BOSS_LOBBY/IDLE, starts0. Chờ user chọn Huyền thoại7/Alacclipse với thẻ Attack rồi bấm TOOL Start. Lobby Pet ID chưa được xác minh. Chưa có kết quả acceptance sau sửa. [Active session](../artifacts/5d2_skill_rush_v1/reasoning_live_20261017_011558/offline_remediation/pilot_package_remediation/active_session.json).

## Batch v2 — dừng tại native policy guard, 2026-10-17

Request `d9e68bfa…`, farm `a9d656b75dd34da1bdeb3fdaf53a513c`, source319 `f9b1b15e…`. User Start05:45:36.998Z; run dừng05:50:38.597Z (12:45–12:50 Asia/Saigon). Hai attempts đã bắt đầu, chỉ trận1 có WIN terminal; trận2 chưa chứng minh terminal, trận3 NOT_STARTED. Không gộp thành2 thắng hoặc3 AI accepted. Run finalLifecycle UNKNOWN; UI sau stop còn ACTIVE_COMBAT. UI đóng sạch05:57:30.161Z; poller cuối thấy general lobby, không quy thay đổi này cho tool sau khi controller đã dừng.

| Attempt | Match | Local-turn proxy | SWAP/ACK | Skill / terminal |
|---|---|---:|---:|---|
|1|M_0c925ebd|10|9/9|turn19 completed retention → Perfect → WIN, normal reward/boss-lobby return|
|2|M_9f4fe4aa|12|11/11|turn23 POLICY_NO_SAFE_MOVE, no input for that proposal; terminal UNKNOWN|
|3|NOT_STARTED|—|—|NOT_STARTED|

22 worker jobs completed,2 workers/reaped2;21 selected actions join ROOT/FRESH/FINAL and actual dispatch (20SWAP +1skill). Job cuối turn23 chỉ ROOT rồi bị guard chặn,0dispatch. Không coi ROOT là actual input. Có14 USE_CANDIDATE proposals tổng cộng, trong đó1 bị guard chặn;8 completed retentions gồm1skill. Không quota khác BASIC. Có2 transient ACTION_ABORTED_STATE_CHANGED trước input, không xóa khỏi evidence. Provider read errors2; không phải chuỗi gây stop này. Critical wrong-turn/stale/duplicate/input-after-stop counters0, worker fault0, operational timing fault0. 117/117 writer records durable, timing sequences1..25 đầy đủ;2 bridges/writers closed healthy, session first_fault null. Shared guard observed max debit19.636ms, không exhausted. Không suy future latency guarantee.

HT7 actual primitive nhận pet2035/Alacclipse,card7,cost200Mana/200Nộ,CARD_UI_BUTTON;1click/1Space/7directions confirmed,wrong/skipped/duplicate/stale/unconfirmed/blind-retry0, runtimePerfect. Decision path vẫn không publish PetID và giữ UNKNOWN; không thêm read để lấp trường đó. Skill là terminal nên later-local-after-skill và PASS live NOT_OBSERVED. Native card description hỗ trợ hiệu ứng Perfect ăn toàn bộ Sword/Health/Rage; chưa dùng mô tả làm formula damage/heal/refill hoặc gán outcome cho action không chọn.

Nguyên nhân cụ thể: lượt23 còn10 legal swaps, safe_move_count0. BASIC chọn move(2,4)→(2,5), nhánh `SKILL_RUSH_RESOURCE_RISK_ACCEPTED`; worker đề xuất(5,4)→(6,4). Adapter đổi trace sang `REASONING_D2_SWAP`. `_must_pause_for_no_safe_move` chỉ miễn dừng cho các nhánh BASIC được chỉ định; nhãn mới mất contract này và controller auto-pause→FarmRunner safe-stop. Timer còn13s, không crash/timeout/QTE hay log-loss. Artifact pause tự gọi policy không kèm capability nên hiển thị NONE/PET_SKILL_CAPABILITY_UNAVAILABLE; đó không phải incumbent của live job. Replay dùng exact board/stats/cards và capability tái dựng từ native shape, ghi DERIVED chứ không gọi exact root capture. Nó khôi phục đúng baseline move đã log và kiểm soát chỉ đổi nhãn cũng tạo pause.

[Closure](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/closure.json), [audit](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/closure_audit.json), [reproduction](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/reproduced_before_fix.json).

Sửa cùngD2: retention trả lại nguyên object BASIC + valid receipt; proposal được kiểm bằng chính pure guard đang có, với counts/first-turn từ analysis đã tính trong flow. Nếu guard từ chối proposal, selector log `D2_NATIVE_POLICY_GUARD_RETAIN_BASIC`, trả nguyên BASIC và không receipt; random/fresh/final/ACK cũ tiếp tục. Không cấp quyền bằng tên nhánh giả, không mở miễn trừ mới trong guard. Exception của callback qua fallback/fuse cũ. Chỉ thêm binding callback trong optional seam hiện có; strip5D2 blocks vẫn khôi phục exact prior controller AST, native guard AST exact, BASIC/QTE/executor bytes unchanged. Source319 `b6f4b536…`;314 files byte-exact so với source live. [Proof](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/boundary_proof.json).

Focused01:29 tests có25PASS/4fixtureerrors do replay thiếu timer source; sửa fixture theo timer đã lưu, không bỏ assert. Focused02:29/29PASS. **Regression03:524/524 PASS,18 modules,369.825s, cùng source319 `b6f4b536…`**; gồm real controller/native guard, Skill Rush/BASIC/PASS/QTE/selection/preflight/Stop/source/fault/lifecycle. Dòng fatal-test/PREFLIGHT_REJECTED trong log là expected synthetic negative controls; unittest kết thúc OK. Không cộng29 focused vào524. Sau regression, own qualification100cycles/4lanes PASS,max5.6185ms,50 production-style capability(noPetID)/50petmetadata,0loss,real isolated worker và durable writer. Real native guard callback nằm trong cost lanes. Thêm100 cycles cho chính fallback từ incident: max1.7989ms,0enqueue loss. Source không đổi sau regression. Sample maxima là host software evidence, chưa native post-fix latency guarantee. [Verification](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/verification.json). Chưa có live authority cho source sửa; không re-use consumed request.

Cap ledger gốc giữ byte-exact. Tổng7 trước +2 batch này =9/10, còn1 NOT_STARTED. Không tự tạo thêm3 attempts hoặc kéo dài để bắt PASS/continuation. [Ledger](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/attempt_ledger.json). **Offline remediation complete; D2 vẫn PARTIAL, còn native kiểm chứng source sửa guard. STOP, không advanceD3 hoặc auto restart. Chuẩn bị tiếp phải tôn trọng1 attempt chưa dùng; gói reserved-one riêng đã chuẩn bị và setup-preview PASS; chưa actual request/UI/input.**

## Chốt gói1 attempt chưa bắt đầu — source cuối06427d06

Để giữ tổng cap10, bổ sung setup-only D2 cap1: cùng frozen cohort, target=max_attempts=1; loader bắt buộc remaining-review có exact closure `a9d656…` và ledger9/10, remaining1, request cũ consumed. Cap0/2/4, ledger đổi cap/used/remaining/consumed bị reject. D1 vẫn cap3. Common launch đòi total cap trùng frozen config; không đổi FarmRunner hoặc hot decision/input flow. Actual request/claim của source064 chưa tạo.

Sau broad524 trênb6f, chỉ3 files đổi: D2 setup loader, common setup launch validation và test native cap1. Selector/controller/guard/QTE bytes không đổi sau broad. Final **96/96 affected tests PASS,80.754s**, own final qualification100cycles/4lanes max**5.4978ms**,0loss, real worker/writer; setup preview trên temporary synthetic copy PASS, không claim/UI/reader/input, temporary request đã xóa. Không gọi final là một lần524/524 mới hoặc cộng chồng96. [Final source](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/final_source_freeze.json), [final boundary](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/final_boundary_proof.json), [verification](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/verification.json).

**OFFLINE COMPLETE / RESERVED1 READY / LIVE PENDING**. Chờ user chuẩn bị lại Starburst73/HT7/Attack; manual TOOL Start cho1 slot chưa dùng. [Runbook](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/RUNBOOK.md). Không thêm budget, chưaD3, không build/version/Git/release.

## Mở phiên reserved-one — 2026-10-17 15:35 Asia/Saigon

User xác nhận đã vào phòng boss. Activated source064 request `9f311968…`, run `5e057b976fdc4a809ee24ca3e7024867`; UI PID11356 nhận Starburst1289 lv73,BOSS_LOBBY/IDLE,healthOK,starts0. Target/max attempts1, manual TOOL Start; combined9/10 trước khi Start. Current pet chưa được xác minh độc lập trong lobby; user giữ HT7/Alacclipse và Attack. [Active session](../artifacts/5d2_skill_rush_v1/reasoning_remediation_live_20261017_123439/offline_guard_remediation/pilot_package_reserved_one/active_session.json). Chưa có kết quả mới.

## Reserved-one closeout — source064, 2026-10-17

Parent: native guard remediation của chính5D.2. Mode BOUNDED_LIVE, user xác nhận phòng rồi tự Start. Request run `5e057b976fdc4a809ee24ca3e7024867`, SHA `9f311968e117a2d399228ccf52cf60d900542a0353e5d9328ce394ad9d952a19`; source319 `06427d06608640ec1575b3bb2997ce18393b7651209785496bd0bc7bed0b874f`; farm `f593d047fe144a3c8f78cd28576eac8b`, match `M_95c35910`. Start08:36:27.571Z, bounded run152.707s, actual match106.388s; Asia/Saigon15:36–15:39. Solo Starburst1289/lv73, HT7Alacclipse2035/card7/Attack,7effectiveSword,fore/two_click,AuditionV3,4s budget. Source/config/input/QTE không đổi trong live. Initial room metadata vẫn không dùng làm proof pet identity; primitive current pet/card/cost xác nhận2035/7/200Mana/200Nộ.

**Batch technical PASS trong scope quan sát:**1attempt/1completed/1WIN,7SWAP/7ACK,8local-turn proxy; actual account energy debit UNKNOWN.1 normal reward confirm và normal returnBOSS_LOBBY, dừng `FARM_TARGET_COMPLETED`, stagePASS/PHASE2E2_UI_BOUNDED_COMPLETED;0abort/recovery/read-error/DTO rejection. Provider unstable skips316 là sample rejected theo flow cũ, không coi là input hay fault.

7worker jobs submitted/completed/published,1worker/reaped1,0fault/late/rejected/stale/logdrop.5SWAP overrides ở turn3/5/7/9/13; swap retentionturn11 và skill retentionturn15, tất cả7 jobs join independently ROOT/FRESH/FINAL và đúng1actual dispatch. Initialturn1 dùng BASIC fallback `COHORT_OR_CONFIG_CHANGED`, giữ original pacing; không tính thành AI-completed. Có1 `BASIC_INCUMBENT_CHANGED` checkpoint bị từ chối trước khi dùng offer, không blind retry hoặc second input. Không ACTION_ABORTED_STATE_CHANGED trong combat action_result của trận này. Completed retention có receipt và giữ nguyên native trace: swapturn11 nhãn BASIC, skillturn15 `STEP_1_PET_SKILL`.

Skillturn15 qua same native source/cost/owner/QTE preflight:1cardclick,1Space,7directions sent/confirmed;wrong/skipped/duplicate/stale/unconfirmed/blind-retry0;runtimeSUCCESS_PERFECT. `pet_skill_turn_resolved=COMBAT_TERMINAL`, immediateSkillKilltrue, không same-source followup. Vì terminal, post-skill later-local consuming action NOT_OBSERVED; PASS count0/NOT_OBSERVED. Không suy efficacy, damage formula hoặc result cho các nước không chọn từ1WIN.

41/41 separate reasoning records written/flushed/closed,0loss,watermarkhealthy;9 timing events sequence1..9 đầy đủ, collector drop0,sessionfirst_faultnull. Critical duplicate/wrongturn/stale/input-after-stop/postmatch-gameplay counters đều0. Worker compute7samples median41.8877ms,max57.111ms; completed decision waits7samples median151.9197ms,max193.8073ms, trả sớm theo budget. Observed Hmax278.3733ms; SWAP executor return max2380.0206ms gồm initialBASIC pacing; whole skill primitive4699.838ms. Shared guard maxdebit0, không timing/component/aggregate fault. NativeU/transportage/exactfirstclick vẫnUNKNOWN/NOT_MEASURED; đây là sample maxima, không future guarantee.

Native `D2_NATIVE_POLICY_GUARD_RETAIN_BASIC` conflict không xuất hiện, safe-count0 incident chưa lặp lại; không gọi exact case live validated. Exact saved-board derived replay với real worker/validator/unchanged guard và100fallback software cycles đã prove đường quay vềBASIC; scoped native run saufix sạch bổ sung integration evidence. Source/card binding fault cũ không tái diễn ở full skill comparison/retention. Chưa gọi mọi guard/error/PASS branch đã quan sát live.

[Closure và raw hashes](../artifacts/5d2_skill_rush_v1/reasoning_reserved_one_live_20261017_153458/closure.json), [independent join/log audit](../artifacts/5d2_skill_rush_v1/reasoning_reserved_one_live_20261017_153458/closure_audit.json), [all-attempt successor ledger](../artifacts/5d2_skill_rush_v1/reasoning_reserved_one_live_20261017_153458/attempt_ledger.json). Original ledgers/failed batch logs giữ nguyên; total7historical+2v2+1reserved=10/10, còn0, không bỏ trận terminalUNKNOWN để làm mẫu đẹp. Không pool các source làm efficacy comparison, không claim3 clean final-source reasoning matches.

**Gates:** native observed SWAP override/retention, PET_SKILL retention/QTE/terminal-postmatch/Stop/cap/source/diagnostics PASS trong phạm vi đó. Conditional Perfect model vẫn partial/refill/boss/damage unsupported. Legal PASS và nonterminal post-skill local continuation chưa có native evidence bắt buộc cho full profile; full5D.2 vẫnPARTIAL. Technical remediation batch đã đóng, tiếp theo cùng5D.2 là scope/missing-evidence closeout theo router, chưaD3. Budget đã hết: không tự thêm batch, không ép gặp case. Không code/build/version/Git/release trong lượt live này.

## 5D.2 — PASS authority remediation và targeted DarkQueen110, 2026-10-17

Parent vẫn là prompt5D.2. User yêu cầu bước tiếp theo; rà offline scope/missing
evidence trước, không mở thêm P hoặc kéo dài Starburst. Sau khi được hỏi về
boss đủ lâu để quan sát continuation, user chọn **DarkQueen lv110, đảo Bóng Đêm**.
Catalog reverse đã ghi **pet_id1170, group9/Bóng đêm, display_level110**; chưa
đọc process/memory để xác nhận phòng/pet hiện tại trong lượt này.

**Phát hiện và sửa một lỗi adapter có căn cứ.** Native cache xác nhận
`RESET_BASELINE_CONFIRMED` sau consuming action với reset capability production-ready;
mapper cố ý xuất count/thresholdNone và source`accepted_consuming_reset_baseline`.
BASIC và native PASS coordinator đã hiểu permission này. D2 lại buộc cả reset
và exact-server statuses có numeric count/threshold, vì vậy loại PASS ở đúng
production view. Test cũ dùng resetcount0/threshold3 nên bỏ sót sự khác biệt.
Bảy native idle-readiness của trận`f593d047…` có can_pass_nowtrue, numeric pair
UNKNOWN; saved policy trace khớp view này. Đây là proof mismatch admission,
không chứng minh PASS lẽ ra phải được chọn hoặc đã phát. [Native fields](../artifacts/5d2_pass_authority_closeout_20261017/native_pass_authority.json).

Test mới đi qua **GameOwnedIdleCache + apply_idle_readiness_to_state thật**,
seeded capabilities/activities có nhãn synthetic; trước sửa thất bại cho cả
SWAP và CAST. Một test khác chứng minh context_hash cũ không đổi khi quyền PASS
đổi trên cùng board/source. [Before reproduction](../artifacts/5d2_pass_authority_closeout_20261017/reproduced_before_fix.log).

D2 hiện nhận reset view có source/proof/production confidence đúng và numeric
pairNone; không tạo idleCount0. Exact server counter vẫn cần đủ pair và dưới
mandatory limit. Opening/mandatory/UNKNOWN/missing-proof/unproven-confidence/
foreign-session/coordinator-off đều bị từ chối. Full-action context hash bind
PASS view; validator và ROOT/FRESH/FINAL còn đối chiếu actual current state với
published packet để stale packet không che mất thay đổi. Context/proof đổi
thì giữ BASIC, không receipt, không disable/fault chỉ vì một job thiếu authority.
Native cache, PASS owner/coordinator, BASIC policy, controller/read/capture order,
executor, ACK, QTE, farm/recovery và version **byte-exact** so với source064.

**Source319 mới`635d6e4c0a3fb5fd210a859cdab926a2ef9a38a4e72419b7a146487abdab781e`.**
Chỉ3production files đổi: action evidence, full-action context/validator,
selection D2 check;3test/fixture files đổi.313source files còn lại byte-exact.
Stripping đúng một D2 proof guard/import trả selector AST bằng predecessor;
stripping optional D2 seams vẫn trả controller AST bằng native legacy. Historical
audit helper pin exact successor và saved predecessor; không sửa historical
runtime_boundary hay bỏ SHA assertions. [Boundary](../artifacts/5d2_pass_authority_closeout_20261017/runtime_boundary.json).

**Final regression431/431 PASS,16modules,132.369s trên cùng source635d.** Bao gồm
action evidence/full worker comparison, source/proof/fresh/final/Stop/fallback,
native D2 setup, BASIC Skill Rush/PASS/idle/coordinator/ACK, skill dispatcher và
historical/core controls. Synthetic`fatal-test` là negative control, không phải
test failure. Intermediate341-run có340PASS/1historical hash failure vì selector
vừa đổi; thêm exact predecessor/successor fixture binding rồi final431 đạt.
Không cộng focused46/340/intermediate341 vào431 để tăng N. [Final log](../artifacts/5d2_pass_authority_closeout_20261017/regression_verified.log).

Own qualification100cycles ×4lanes (SWAP,skill,PASS,retention),real isolated
worker và durable separate writer PASS,0loss, observed selector max**10.4707ms**
dưới gate30ms. Fixture giờ dùng actual non-numeric cache mapping thay vì giả
resetcounter0. Có50card-only current native shape/50pet-metadata shapes. Cost
lane injection chỉ phục vụ đo overhead, không phải natural utility choice hay
native PASS dispatch; sample max không bảo đảm future latency. [Verification](../artifacts/5d2_pass_authority_closeout_20261017/verification.json).

**Rà toàn bộ93skill files:**9exactHT7pet2035/card7, đều SUCCESS_PERFECT và terminal;
0nonterminal HT7 continuation.84files còn lại card22;58có later consuming ACK
sau local return nhưng không được chuyển thành HT7 calibration. Không thiếu
log HT7 đã có; cohort hiện tại thực sự chưa sinh tình huống cần quan sát.
[Scope audit](../artifacts/5d2_pass_authority_closeout_20261017/skill_scope_audit.json).

**Chuẩn bị concrete targeted BASIC1, chưa live.** [DarkQueen draft](../artifacts/5d2_pass_authority_closeout_20261017/darkqueen_basic1/setup_preview.json)
đã file-only setup preview PASS;3config-drift controls bị reject, no claim/UI/
Start/worker/game IO. RequestSHA`527b416a081032d290985ae13419d33b553698b61fb3a260ecbe1b0d89116852`,
run`bcddf2dd095e41e9a5b2bc587f142078`; expires_at ghi trong request. Cấu hình
SOLO/SkillRush/BASIC, Huyền thoại7/không tiến hóa/PetSkill,7effectiveSword,
AuditionV3,foreground/two_click,shadowoff,target=maxattempt1. Đây là phép thu
timing/skill/continuation trên **boss mới**, chưa cấp reasoning authority cho
cohort này và chưa chuyển Starburst calibration sang DarkQueen. Người dùng tự
vào phòng và tự Start; trước khi mở phiên cần họ xác nhận sẵn sàng/yêu cầu chạy
đúng1attempt. Nếu request hết hạn trước firstStart phải prepare/review bản mới,
không tái dùng consumed request để reset budget. Không tự gia hạn/farm thêm.

Ledger Starburst10/10/remaining0 giữ đúng SHA; preferences thường cũng giữ SHA
`cfb792f1…`, không đổi setting DemonFarm người dùng đã lưu. Request DarkQueen là
draft riêng, không diễn giải thành remaining slot của cap10. Native post-fix
PASS và HT7 later-local continuation vẫn NOT_OBSERVED; full profile**PARTIAL**.
Next cùng5D.2: targeted DarkQueen BASIC1 khi user sẵn sàng; sau raw proof mới
review scope/calibration/gate cho REASONING, không tự kích hoạt arm tiếp theo.
Không code/build/version/Git/release thêm; chỉ3production files remediation nêu trên.

## DarkQueen110 targeted BASIC1 — phiên mở 2026-10-17 16:31 Asia/Saigon

User xác nhận phòng. Đã đóng đúng tool cũ PID11356 sau khi native log chứng minh STOPPED/inactive; không đóng game. Mở toolPID1896,gamePID38520,source635d/request527b/runbcdd,cap1BASIC. Fresh UI snapshot nhận DarkQueen1170/lv110/BóngĐêm,BOSS_LOBBY/healthOK/IDLE,starts0. No CALIBRATION_REJECTED/error; user tự Start, chưa claim/input. Giữ HT7/Attack/7effectiveSword,AuditionV3; chưa độc lập xác minh pet trong lobby. Ledger cũ10/10 và ordinary preferences giữ nguyên. [Active session](../artifacts/5d2_darkqueen_basic1_live_20261017_1630/active_session.json). Chưa có kết quả mới; không autoStart/retry hoặc mở REASONING.

## DarkQueen110 targeted BASIC1 — closure và HT7 continuation proof

Parent5D.2,targeted1BASIC do user xác nhận phòng và tự Start; không thêm P.
Source319`635d6e4c0a3fb5fd210a859cdab926a2ef9a38a4e72419b7a146487abdab781e`,
requestSHA`527b416a081032d290985ae13419d33b553698b61fb3a260ecbe1b0d89116852`,
run`bcddf2dd095e41e9a5b2bc587f142078`,farm`cdd797131ecb4f2dad761d44eed74794`,
match`M_a6165d21`. DarkQueen1170/lv110/BóngĐêm,HT7Alacclipse2035/card7,
Attack equipped,7effectiveSword,SOLO/BASIC,AI/shadowoff,AuditionV3,
foreground/two_click. Current room và primitive đều xác nhận pet2035; actual
cost200Mana/200Nộ. Không đổi code/source/config/input/QTE trong live.

**Targeted BASIC technical PASS**,1attempt/1completed/1WIN,normal confirm1,
returnBOSS_LOBBY,stopFARM_TARGET_COMPLETED. Run279.592s,actual match226.440s,
16local-turn proxy; actual account energy debit UNKNOWN. Native critical
counters đều0,0technicalabort/recovery/providerreaderror/DTOrejection;
690unstable provider skips là sample rejected, không phải phát input lỗi.
Terminal memory bossHP0/localHP47369,UI thắng,STRONG/CONSISTENT.

Đã có evidence bắt buộc trước đây chưa quan sát: **3nonterminal HT7 Perfect
continuation chains**: skillturn15→opponent16→local17→SWAP_ACK;
skill19→opponent20→local21→SWAP_ACK;skill27→opponent28→local29→SWAP_ACK.
Mỗi chain giữ exact session/MatchId/source turn; native policy history ở
later local ghi lần lượt1/2/3successful skills. Không có same-source followup,
unconfirmed skill resolution hoặc input fallback sau skill. Mỗi skill1click/
1Space/7directions sent+confirmed;wrong/skipped/duplicate/stale/unconfirmed/
blind-retry0. Đây là actual BASIC/native continuation, không phải derived
replay, và không tự biến thành REASONING/PASS proof hay damage/refill model.

**SWAP accounting ghi đúng13sent/12ACK**,không gọi13ACK. Openingturn1 có1
state-change rejection trước dispatch rồi fresh BASIC đi được. Finalturn31
đã phát input nhưng pending bị clear với ACTION_ABORTED_STATE_CHANGED,
reasonCOMBAT_LIFECYCLE_ENDED khi combat chuyển terminal; ACK/effect của swap
đó UNKNOWN, không retry/ACK invented. Native action_aborted_due_lifecycle1,
expired_actions1 được giữ nguyên trong raw counters; action_response_timeouts
vàlocal_turn_deadline_safe_stops0. StagePASS/normal terminal/postmatch chứng
minh target stop; không che pending abort dưới tuyên bố mọi action đã ACK.
Inner controller postmatch_observation_timeout là handoff observation sau
terminal; FarmRunner vẫn account WIN,confirm và return bình thường.

**17/17 timing records durable**,event_seq1..17 đầy đủ:1decision timing,
13swap timing,3skill timing;flush/close true,collector disabledfalse/drop0,
writer loss0. Skill primitive N3/max4717.924ms,swap executor returnN13/
max2805.002ms gồm BASIC pacing. NativeU/transportage/exactfirstclick vẫn
UNKNOWN; sample maxima không bảo đảm future latency và chưa cấp authority
cho reasoning trên cohort mới. Không đánh giá efficacy từ1WIN.

[Reproducible audit và raw hashes](../artifacts/5d2_darkqueen_basic1_live_20261017_1630/closure.json),
[audit script](../artifacts/5d2_darkqueen_basic1_live_20261017_1630/audit.py),
[targeted ledger](../artifacts/5d2_darkqueen_basic1_live_20261017_1630/attempt_ledger.json).
Targeted1/1/remaining0 đã consumed,không restart/extend. Starburst cap10/10
giữ nguyên SHA2fb31092…;ordinary preferences SHA cfb792f1… và source635d
byte-exact. Tool để mở ở STOPPED/1of1; chưa mở thêm phiên.

**Full5D.2 vẫnPARTIAL.** Missing native HT7 continuation đã được khép cho
BASIC scope. Native REASONING/PASS sau sửa chưa quan sát; DarkQueen calibrated
comparison/setup authority chưa review/activate. Next cùng5D.2: gom toàn bộ
offline review/preparation cho cohort này trước live request riêng có cap,
không tự chạy thêm game hoặc advance5D.3. Chưa build/version/Git/release.

## DarkQueen REASONING2 — complete offline preparation

User yêu cầu “vậy chuẩn bị đi”; modeOFFLINE_PREPARATION_ONLY,cùng5D.2,không
actual live activation hoặc P mới. Gói target DarkQueen1170/lv110/BóngĐêm,
HT7/2035/card7,Attack,SOLO,7effectiveSword,AuditionV3,foreground/two_click.
Đề xuất2REASONING attempts,failedentry/abort tính cap; BASIC1 đã dùng →
targeted case3total. Không lấy2slot từ Starburst10/10,không reset oldclaims.

Legacy D2 setup chỉ nhận Starburst/control3+probe1. Thêm narrow schema
`pokiguard.reasoning.d2_darkqueen_targeted.v1`,chỉ nhận boss1170/cap2 với own
BASIC1source635d và current-session/card/cost/QTE/continuation/ledger proof.
Đọc lại toàn bộ17timing rows/13swap spans/3skills/1superseded decision,
native source/host/build/witness/budget;12ordinarySWAP_ACK được dùng calibration.
Finalpendingturn31 chỉ được loại khi exact COMBAT_LIFECYCLE_ENDED + terminal
HP/result/counter/identity khớp; unknownACK không bị đổi thành successfulACK.
Remove ordinaryACK,missing chain,foreign pet/cost/witness,dropped log đều reject.

Only source delta:1existing setup loader đổi và3setup/tool/test files thêm;
318existing source files byte-exact. Strip đúng2explicit target dispatches
trả full legacy loaderAST exact. Planner,selection,worker,PASS cache/owner,
BASIC,controller/read/capture/input/QTE/ACK/FarmRunner/recovery/UI/version giữ
byte-exact so với source635d. [Boundary](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/package/runtime_boundary.json).

Final source322 **41dd8b30a899b8cf69b7a5aab1dba7b948dae29c4011fbf2b77826c142c65933**. **Final regression459/459 PASS,
151.852s,18modules**,gồm new verifier,native/operational setup,
worker/fullactions/selection/source/fresh/final/Stop,SkillRush/BASIC/PASS/QTE
dispatch và historical/core controls. Synthetic fatal-test là negative
control,kết quả cuốiOK. Focused24 và initial broad459 là subset/history,
không cộng dồn thành N mới. [Final log](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/regression_final.log).

Public setup preview đầu bị chặn vì builder ghi scopeOFFLINE_PREPARATION_ONLY
trong decision record; common loader đòi OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY.
Sửa đúng metadata literal trong builder,không nới common gate; giữ package/log
ban đầu riêng rồi chạy lại full final tests và own qualification. Đây là
offline fixture/package rejection,không có actual request/claim/UI/input.

Own final100cycles/4costlanes max**6.5455ms**,0loss,
real isolatedworker và durable writer PASS. Public OperationalPilotLaunch
preview PASS trên temporary package;2real worker roundtrips trên synthetic
boards với đúng reviewed structural witness,history0/1 đều có eligible
SWAP/PET_SKILL/PASS và completed receipt qua ROOT/FRESH/FINAL. Retention hợp lệ,
không force quota. Rehashed casebudget/closedledger/qualification,wrongboss/
config/cap/profile,missing independent activation,requestSHA drift bị reject.
Temporary synthetic request đã xóa; actual package vẫn draft/acceptedfalse,
khôngrequest/activation/claim/UI/game-reader/nativeinput. [Preview](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/preview.json).

Native Hmax304.4332ms,Imax4717.924ms,12ACKswaps+3skills=15reserve samples,
rootreadmax147.3031ms. Reserve**8398.9027ms** gồm ownselector,
full BASIC commandedwait3120ms và sharedguard250ms;returnmargin100ms,
root250/final100ms,decisionbudgetmax4000ms,t0based/earlyreturn. U/transportage/
exactfirstclick UNKNOWN,sample maxima không future hardbound. Không tạo
damage/heal/refill/boss-policy model mới hoặc đánh giá efficacy.

[Draft](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/package/draft.json),
[verification](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/verification.json),
[runbook](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/RUNBOOK.md).
Old Starburst ledger và ordinary preferences exactSHA giữ nguyên. Full5D.2
**PARTIAL/livepending**. Chờ user sẵn phòng và yêu cầu bounded2 để activate
fresh; user tự TOOLStart. Không tự mởgame/tool,trận mới,arm khác,D3 hoặc
build/version/Git/release. Missing evidence sau cap ghi NOT_OBSERVED,không
farm thêm để ép skill/PASS/override.


## 2026-10-18 — DarkQueen REASONING2 activated; awaiting operator Start

Ngày **2026-10-18**. **5D.2 PARTIAL — DARKQUEEN REASONING2 READY; AWAITING MANUAL TOOL START**.

Đã kích hoạt request mới và mở [phiên REASONING2](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/active_session.json): DarkQueen1170/lv110, Huyền thoại7/Attack, ngưỡng7Kiếm hiệu dụng, tối đa2attempt (kể cả failed entry/abort), target2completed. Normal UI poller nhận đúng BOSS_LOBBY/healthOK/PID36392; controllerIDLE, starts0/input0, chưa claim. Người dùng tự bấm **Bắt đầu trong TOOL** một lần; chưa có kết quả live. UI BASIC là incumbent; request độc lập cấp nhánh REASONING và fallback BASIC theo contract.

Source322`41dd8b30…`, cấu hình/build/host và public launch gate đã kiểm lại đúng gói offline:459/459 tests PASS,100cycles/4lanes và public loader/2real-worker previews PASS. [Verification](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/verification.json), [runbook](../artifacts/5d2_darkqueen_reasoning_preparation_20261017/RUNBOOK.md). Không đổi source trong live; không thêm reader/capture/input; giữ QTE và flow cũ. Preferences thường, Starburst10/10 và DarkQueenBASIC1/1 giữ nguyên.

Tiếp tục chính [5D.2](../prompts/5D2_SKILL_RUSH_ACCEPTANCE.md): theo dõi logs của batch này, join actual decisions/dispatch/ACK/skill continuation và PASS legality. Không ép override/skill/PASS, không tự mở thêm attempt hoặc restart; thiếu mandatory evidence vẫn PARTIAL/NOT_OBSERVED. ChưaD3/build/version/release. [Báo cáo](5d2_report.md).

Request SHA `7f33ed80f99ab7f2093e1b602972ca7c4cc37455062498f2125d25ca7d576b3d`; run `f4e1ca62965b43e79a84fdf6dd198aea`; tool PID30088. Fresh expiry2h/cap2; no automatic Start/claim/restart. Native room check from existing UI poller only; current pet not independently re-read before Start. Existing entry/capability/primitive owners enforce the reviewed witness.


## 2026-10-18 — Final 5D.2 technical acceptance and STOP

**RESULT: PASS STRONG, scoped HT7. EFFICACY: NOT_ESTABLISHED.**
STEP/PARENT:5D.2SkillRush;MODE:BOUNDED_LIVE targeted missing-evidence case,
not a new P or new phase. Initial DarkQueen BASIC1 is closed; this REASONING2
consumes the remaining allocation of that distinct3attempt case. Original
Starburst10/10 stays closed; no unused/restart authority survives this batch.

### Source, activation and entry

App/sourcev1.2.5,game1.7.4;HEAD`c646acfa5e895732bbdade553f9d7bd61171cd29`,
branch`codex/phase3a2-board-repair`. Source322SHA
`41dd8b30a899b8cf69b7a5aab1dba7b948dae29c4011fbf2b77826c142c65933`
and source manifest,host/game/exe pins verified unchanged at closure.
User said“đã vào phòng boss”,then manually Start in TOOL and“đã bấm”.
No agent Start,additional game observer,source changes or config changes.

Request`f4e1ca62965b43e79a84fdf6dd198aea`,SHA
`7f33ed80f99ab7f2093e1b602972ca7c4cc37455062498f2125d25ca7d576b3d`;
FarmRun`f7355253aacb4ab19385db999e4ec26e`;fresh claim remains consumed.
DarkQueen1170/lv110/BóngĐêm,HT7/Alacclipse2035/card7,Attack,Solo,
legendary/none/pet_skill,7effectiveSword,AuditionV3,foreground/two_click,
budget4000ms. UI BASIC is incumbent;independent request grants D2 reasoning.
Ordinary preferences and protected old ledgers stay exactSHA;private session
preferences only. Before Start normal UI poller verified boss room/healthOK,
controllerIDLE/starts0;no extra reader to determine pet. All5actual skill
primitives independently verify pet2035/card7/current session/actual cost.

### All-attempt ledger and outcomes

| Attempt | Match | W/L/U | Local-turn proxy | SWAP sent/ACK | Perfect | PASS waits/results | Normal return |
|---|---|---|---:|---|---:|---|---|
|1|M_6276d8b7|WIN|9|8/8|1|0|Yes|
|2|M_c7fc6a5c|WIN|23|16/16|4|3:2confirmed,1UNKNOWN|Yes|

Cap2,started2,completed2,W2/L0/U0,abort0,recovery0,remaining0.
Full active run486.800s;combat durations117.555s/350.199s.32localturns are a
proxy only;actual account energy debit/energy-per-WIN UNKNOWN. This is one
sequential session,not independent efficacy clusters or same-board paired
counterfactuals. Neither WIN count nor proxy score supports superiority.
2postmatch confirms,terminalHP/UIconsistent,finalBOSS_LOBBY,
FARM_TARGET_COMPLETED,UISTOPPED/FINISHED. No third match/restart authorized.

### Decisions and dispatch attribution

30submitted/completed worker jobs,0fault/late/rejected/stale-discard/logdrop;
2processes reaped. Worker proposals are separate from actual dispatch:
18SWAP overrides,1PET_SKILL override,3PASS overrides,6completedretentions
(2SWAP+4PET_SKILL),2nativeguardvetoes retaining BASIC. All30join exact match,
turn,srvSeq,boardHash/action and existing native dispatch/owner.
For28completed selections,SWAP/skill have ROOT/FRESH/FINAL;PASS has ROOT/FINAL
then native PASS owner revalidation,not a fabricated FRESH read. The2guard
vetoes happen atROOT,discard reasoning receipt and preserve incumbent/pacing.

Each opening turn falls back BASIC before a job is submitted with recorded
COHORT_OR_CONFIG_CHANGED:current opening card witness lacks reviewed Attack;
later settled owned state binds successfully.2coverage fallbacks,no worker
crash/deadline fault,not called completed reasoning agreements.

Native advisory example:attempt2turn9 has6effectiveSword(setting7),210Mana/
250Rage with actual200/200cost. Reasoning selects PET_SKILL,Perfect succeeds,
then boss10/local11;native guard vetoes the new SWAP proposal and BASIC SWAP
is ACKed. Thus skill override and safe fallback are both observed without
claiming that6Sword is lethal. Other4skills are completed BASIC agreements,
not forced overrides.

### Continuation, PASS and safety

Actual skill→boss→later-local consuming SWAP/ACK chains:
9→10→11(history1,nativeguard/BASIC);17→18→19(history2,completedreasoning);
41→42→43(history3,completedreasoning). Two other skills close terminal.
All5skills:1cardclick+1Space,7/7directionsconfirmed;0wrong/skipped/duplicate/
stale/unconfirmed/blindretry. Same-source followup0,pendingNone at closure.

PASS eligible in29of30worker comparisons. Actual waits25/27/31 use current
source/pass proof and existing owner with gameplayInputsDuringWait0.
25and31have exact MATCH_AFK_WARN idle1/threshold3 confirmations.27has server
turn end but no correlated AFK payload:PASS_STATE_UNCONFIRMED;idle count2 is
UNKNOWN,not synthesized. Existing mandatory owner forbids thirdPASS,SWAP29
is ACKed and accepted consuming reset is confirmed before PASS31. This is
observed conservative handling,not proof that missing AFK messages are fixed.
No new live batch is needed to force another warning or emergency case.

All farm critical counters0;combat duplicate/misclick/partial/wrongTurn/stale/
bossTurn/inputAfterCombat0. Provider read errors/DTO rejection0;1316unstable
samples are normal rejected presentations,not accepted stale actions.
No unexpected error,technicalabort/recovery,response timeout/deadline stop,
thirdPASS,fake idle increment or same-source retry. LowHP emergency live
NOT_OBSERVED;offline controls remain labelled offline. No native execution,
reader/capture order,input/QTE/ACK/PASS/lifecycle/farm logic changed in batch.

### Diagnostics, cost and limits

151durable events=43+108,all writer counts match raw files,0drop/write loss,
both flush/close healthy;32timing records account24SWAP+5skill+3unsent decision
closures:combat0has9records(sequence1–9),combat1has23(sequence10–32). The3SUPERSEDED_BEFORE_PREFLIGHT spans
belong to zero-input PASS decision lifetimes;not missing SWAP ACKs or sent
actions. Worker and collector sequence namespaces are separate,not flattened
into a false globally unique event_seq. All30worker decisions and all
actual dispatch joins are kept in raw closure;no unchosen outcome labels.

Worker computeN30:median75.58315ms,max150.484ms,min32.3824ms.
Controller-tailN29:median202.5159ms,max249.3348ms.
SWAPexecutor-returnN24:median654.43455ms,max2652.6272ms;
whole skill primitiveN5:median4713.4381ms,max4756.2436ms.
Shared component guard exhausted0;no operational/component/reserve fault.
These are sample maxima,not future latency bounds. NativeU/transportage/
host–Unityalignment,exactfirstinput and relativeCPU/memory overhead unknown.

### Gates and routing

All12[mandatory gates](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/gate_decision.json)PASS within declared scope.
Offline source41dd459/459tests,100cycles/4lanes and public loader/real-worker
previews remain valid;no runtime edit during live means no new regression
suite or rebuilt artifact is needed for this docs-only closeout. Audit scripts
operate on existing files only;source/host/build and protectedSHA rechecked.

Accepted technical scope:SkillRush,account/pet2035/card7,current source/build/
input,conditional USER_CALIBRATED Perfect first-wave Sword/Rage/Health.
Unsupported:otherpet/card/boss authority without own gates,GOOD/BAD effect,
damage/healHP/refill distribution,boss-skill policy,cost/gain ordering and
post-skill balance predictions. R2not promoted,BASIC remains default.
Efficacy/reliability/package promotion still require E/F gates.

Exactly one next:[5D.3](../prompts/5D3_DEMON_AEGIS_ACCEPTANCE.md).
**STOP at completed5D.2.** No moreD2live,no extraP,source edit,build/version,
Git write/release or automaticD3/live activation.

[Closure](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/closure.json),[all-attempt ledger](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/attempt_ledger.json),
[gate decision](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/gate_decision.json),[source/closeout verification](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/closeout_verification.json).
