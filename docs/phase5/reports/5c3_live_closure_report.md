# 5C.3 — Live technical parity closure

Ngày: **2026-10-11 (Asia/Saigon)**. Batch đã kết thúc; không mở thêm trận.

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5C.3 live closure / 5C.4 offline / BASELINE_LIVE_OPTIONAL
RESULT: PASS STRONG — SCOPED DEMON SWAP TECHNICAL SMOKE
EFFICACY: NOT_TESTED
SOURCE VERSION: v1.2.5 source; package unchanged
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
SOURCE FINGERPRINT: 81a71fed954e1d95829c13f760cd9d31cb3f844b174eee27cf135e27ab28b92a
RUNTIME / TEST SOURCE CHANGES IN THIS CLOSURE: NONE
LIVE INPUT AUTHORITY: BASIC ONLY; OPERATOR STARTED EACH SLOT
BUILD / VERSION / COMMIT / PUSH / TAG: NONE
NEXT: 5D.1 — SELECTED ONLY; NOT_EXECUTED, LIVE NOT_ACTIVATED
STOP: C3 SIX-ATTEMPT CAP REACHED
```

Đóng gate live technical smoke của C3 trong phạm vi SWAP Demon Farm. Đây
không phải acceptance của REASONING chọn nước, skill/QTE, mọi PlayStyle hoặc
toàn bộ ứng dụng. C4 offline đã hoàn thành; D1 được chọn làm bước kế tiếp,
vẫn cần preparation/capability/calibration và activation riêng trước pilot.

## Batch và provenance

Người dùng yêu cầu chuẩn bị live, đóng tool cũ, vào phòng boss và tự bấm Start
từng lượt. Source UI dùng hai preset riêng, mỗi Start **1 trận / tối đa 1
attempt**; không auto-start/resume. Thứ tự cố định BASIC, SHADOW, BASIC,
SHADOW, BASIC, SHADOW; cap6 kể cả lỗi/abort, không chạy bù. Không thêm read,
capture, game API, fault injection hoặc công cụ điều khiển game.

Boss **Lieyun / 1436 / cấp77 / Thập nhị tinh**, Solo, Demon Farm, Normal,
None, Pet Passive, Kiếm đủ4; foreground/two-click, 1280×640, Audition V3.
Shadow budget4000ms là processing cap, không phải input reserve. BASIC vẫn
chọn và phát tất cả nước đi. Khung đã khai báo 22:08:18–23:08:18; actual runs
22:10:19–22:36:20. Operator review/idle giữa lượt không tính active elapsed.

- [Frozen batch manifest](../artifacts/5c3_live_closure_preparation_v1/live_batch_manifest.json).
- [Ledger 6 attempts](../artifacts/5c3_live_closure_preparation_v1/live_attempt_ledger.json).
- [Machine-readable result, hashes và cohort observations](../artifacts/5c3_live_closure_preparation_v1/live_closure_result.json).
- [Source manifest: 260 files](../artifacts/5c3_live_closure_preparation_v1/source_manifest.json).
- [Historical C3 report trước closure, byte-preserved](../artifacts/5c3_live_closure_preparation_v1/before_closure_docs/reports/5c3_report.md).

GameAssembly SHA256 supported b6:
`72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063`.
Bound full config IDs giữ nguyên qua cả ba lượt của mỗi arm:

```text
BASIC  6596bbcdd8ed53585bbb4892966b1908c967243a032ae4bcab6635566aa1ec4b
SHADOW f3f446238dbb6fab172d029e23c13e596fe4117d78aeb7248750fee959f58b3c
```

Shadow ID có trong actual AI status/log. BASIC ID được tái dựng từ UI config
và target đã pin trong checkpoint; disabled AI không publish config ID. Idle
UI draft giữ target null theo thiết kế. Preset tự save timestamp/chuẩn hóa
game location tại Start; semantic config không đổi. Preparation hashes mô tả
bản trước autosave; không dùng chúng để giả rằng file mutable giữ nguyên byte.
File preferences farm thường của người dùng vẫn nguyên SHA256 ban đầu.

## Kết quả từng lượt

| Slot | Arm | MatchId | Kết quả | Local / boss turns | Năng lượng ghi nhận | Swap ACK |
|---|---|---|---|---|---|---|
| 1 | BASIC | M_bc8e3f32 | WIN | 1 / 0 | 1 | 0 |
| 2 | SHADOW | M_e8cda5fb | WIN | 1 / 0 | 1 | 0 |
| 3 | BASIC | M_7740dafb | WIN | 1 / 0 | 1 | 0 |
| 4 | SHADOW | M_e669709d | WIN | 4 / 3 | 4 | 3 |
| 5 | BASIC | M_0183e2ec | WIN | 1 / 0 | 1 | 0 |
| 6 | SHADOW | M_2124b482 | WIN | 1 / 0 | 1 | 0 |

MatchIds đã đối chiếu với ledger. FarmRunId và hash từng common/UI/AI log
nằm trong ledger và các slot reviews.
Tổng **6 attempts, 6 completed, 6 WIN, 0 loss/UNKNOWN/abort/recovery; 9 local
turns, 3 boss turns, 9 swap, 6 entry và 6 result-confirm inputs**. Mọi run về
BOSS_LOBBY và dừng FARM_TARGET_COMPLETED; single controller max1, no orphan
poller khi đóng UI. Năng lượng9 là distinct local server-turn count của tool;
người dùng độc lập xác nhận lượt1 tốn1, không đo delta balance cả batch.

Ba BASIC tốn3 và ba shadow tốn6 theo count trên. Board khác nhau, một trận
shadow có4 lượt; không coi chênh lệch này là overhead hoặc hiệu quả gameplay.
Run elapsed tổng185.995s (BASIC74.632s; shadow111.363s), tính farm creation đến
controller terminal update, gồm entry/combat/result; không phải paired timing.

## Flow, worker và diagnostics

Critical counters trong cả common controller và FarmRun đều0: duplicate,
wrong-turn/opponent-turn, stale, after-stop/postmatch gameplay, wrong-target,
partial input, response timeout, sequence desync và result double-count/conflict.
Có3 explicit swap ACK ở lượt4. Sáu nước kết liễu đang pending kết thúc bằng
ACTION_ABORTED_STATE_CHANGED / COMBAT_LIFECYCLE_ENDED; strong terminal HP/UI
WIN nhất quán. Không diễn giải terminal cancellation thành ACK thành công.

Ba shadow tạo **6 jobs, 6 completed, 6 processes reaped**, zero faults/late/
stale-discard/log-drop. Mỗi dispatch được ghép exact identity với common
action_sent và baseline candidate tương ứng; **6/6 giữ BASIC, 0 replacement**.
Planner trả UNSUPPORTED_MODEL_OR_LEGALITY_CONTEXT vì model/legality chưa bound;
đây là observed retain-baseline, không phải adaptive proposal đã accepted.

Separate sink có24 records:6 decision,6 dispatch,6 outcome,3 health và3 final
summaries. Native writer watermarks hợp lệ, zero eligible drop/fail/discard;
record summary không tính vào watermark trước chính nó. Worker có input
authority false; nhãn OFFLINE_ONLY trong worker summary không đổi bằng chứng
live BASIC ở common log. UI accounting_valid vẫn false khi đóng dù native
watermarks valid: giữ display limitation này, chưa sửa hoặc suy thành log loss.

## Cohort và giới hạn bằng chứng

Final audit phát hiện RoomDTO.petId=587 ở lượt1,560 ở lượt2–6. Trường này được
reader hiện tại đọc tại +0x34, khớp RoomDTO trong reverse sẵn có; không là
binding pet thực chiến có freshness proof. Người dùng xác nhận sau batch:
“lúc vào phòng thì pet khác, nhưng xuyên suốt 6 ván là 1 pet”. Opening player
và boss stats của cả6 trận giống hoàn toàn; username hash/boss/room cũng giữ.

Vì vậy không dùng RoomDTO.petId đơn lẻ để kết luận đã đổi pet trong6 trận.
Giữ raw587→560, operator confirmation có nhãn retrospective và actual combat
pet identity UNKNOWN; nguyên nhân/thời điểm đồng bộ DTO chưa được chứng minh.
Card sources ở lobby cũng không đồng nhất; accepted board-only path không
phát card-selection action. Không nâng các quan sát này thành effect/model
calibration hoặc independently verified exact loadout identity.

| Gate / coverage | Kết luận |
|---|---|
| C3 offline parity/fault/SLO + C4 current-source integration | PASS trong scope của các report lịch sử; không chạy lại hoặc relabel soak |
| Current source/config binding,3 OFF +3 SHADOW,cap/time/order | PASS; 260 files và frozen IDs được kiểm lại |
| Live ordinary SWAP,ACK,pending,end/result/lobby/target Stop | PASS scoped technical smoke; zero observed critical regression |
| Worker isolation,baseline retain,dispatch correlation,durable log | PASS cho6 jobs và24 records |
| Independent live memory/capture boundary traces | NOT_OBSERVED; source/offline seam proof, không thêm instrumentation |
| Skill/QTE/CAST/EVOLVE/PASS,room-error re-entry | NOT_OBSERVED |
| User emergency Stop,live faults/timeout/deadline | NOT_OBSERVED; prior offline evidence giữ nhãn offline |
| Live CPU/RAM/critical-path overhead/full-app soak | NOT_MEASURED; historical qualification không biến thành current live measurement |
| R1 selected override,R2,boss/refill/effect/damage model,efficacy | NOT_TESTED / NOT_ACCEPTED |

Các module reasoning đã có trong C3 V3 vẫn byte-equal với source đang chạy;
compatibility hashes nằm trong result. C4 qualification/full regression2006
gắn đúng fingerprint260 hiện tại. Hai bằng chứng này không re-certify historical
whole-app soak, UI timing hoặc performance của mọi action family.

## Handoff

Đã đủ bounded C3 live smoke theo prompt, với cases chưa xảy ra giữ nguyên
NOT_OBSERVED. Không thử thêm để đủ coverage, không claim win-rate hay superiority.
Production REASONING/UI selector vẫn gated, BASIC default; farm preferences
thường không bị bật shadow. Không sửa code, build, version hoặc Git.

Exactly one next: **[5D.1](../prompts/5D1_SIMPLE_CAREFUL_PILOT.md)**, selected
only. Cần chốt capability/model/reserve phù hợp và activation riêng; chưa đổi
profile, mở pilot hoặc phát reasoning input. **STOP tại C3.**
