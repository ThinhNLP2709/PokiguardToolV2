# 5A.1 — Baseline v1.2.4 và hợp đồng REASONING

Ngày: **2026-10-09 (Asia/Saigon)**.
Trạng thái: **SPEC_DEFINED — DOCS ONLY**.
Được thực hiện theo yêu cầu “Tiến hạnh 5a1 đi”; không bao gồm 5A.2 hoặc code.

## 1. Hiệu lực và baseline

Chỉ dẫn người dùng mới nhất và [AGENTS](../../../AGENTS.md) có ưu tiên cao nhất.
Đây là contract sản phẩm cho phần REASONING sẽ được triển khai; không phải mô
tả một planner đã chạy. [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md) áp dụng
chung; [DECISIONS](../../DECISIONS.md) và
[reasoning_gameplay_policy](../../reasoning_gameplay_policy.md) dẫn về contract này.

| Mục | Bằng chứng / phạm vi |
|---|---|
| Source baseline | v1.2.4; HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29` |
| Branch lúc 5A.1 | `codex/phase3a2-board-repair`; không đổi branch/checkout |
| Worktree vào bước | Không tracked diff; các untracked đều dưới docs, giữ nguyên unrelated work |
| Vận hành accepted | [Release v1.2.4](../../v1.2.4_release_report.md): operator xác nhận 600 + 200 ván không dừng giữa đường |
| Giới hạn bằng chứng | Release không có bộ run artifact tương ứng; không suy win-rate hoặc mọi profile đã covered |
| Bú win | Offline complete, baseline Coop live pending; REASONING Coop chưa accepted |
| REASONING runtime hiện tại | Chưa triển khai; placeholder được ghi `NONE / REASONING_NOT_IMPLEMENTED` trong BASIC policy docs |
| Runtime/live ở 5A.1 | Không sửa, attach, inspect process, chạy tool/test harness hoặc gửi input |

BASIC của PlayStyle là baseline quyết định, không chỉ SIMPLE. Không đổi BASIC,
hotfix sinh tồn, settings/default/loadout hay luồng vận hành để làm REASONING
trông tốt hơn. Preferences cũ/mới vẫn BASIC mặc định. REASONING được opt-in ở
bước tích hợp/acceptance tương ứng; PROMOTE chỉ là acceptance theo scope.

## 2. Ý nghĩa REASONING

REASONING phải so sánh lựa chọn theo tình thế, giữ mục tiêu PlayStyle, dùng
settings chiến thuật làm thông tin tham khảo. Nó có thể chọn khác heuristic
hoặc ngưỡng setup/fire khi có lý do và bằng chứng phù hợp.

Bốn nghĩa vụ: nhận diện tình thế; so sánh với BASIC; nêu phản hồi/rủi ro còn tính
được và phần UNKNOWN; tự giới hạn bằng deadline/fallback. Một tổng điểm cố định
hoặc một rule HP mới đơn lẻ chưa đáp ứng mục tiêu thích ứng này.

```text
state đã được flow hiện tại cung cấp + immutable run config
    -> BASIC decision sẵn có
    -> pure REASONING proposal / retain BASIC
    -> existing final preflight + input authority
    -> existing executor / ACK / lifecycle
```

Đây là sơ đồ boundary; không phải thứ tự đọc memory mới. Pure planner không có
quyền đọc process, gọi provider, chụp ảnh, lấy lease hoặc gửi input.

## 3. Hard validity, mục tiêu và chiến thuật tham khảo

| Loại | Nội dung | REASONING được làm gì |
|---|---|---|
| Hard — identity/state | Session, actor/local owner, turn/sequence, board/mapping, freshness, stable/actionable state | Không override; sai/UNKNOWN essential thì theo fail-closed gate hiện có |
| Hard — input authority | Controller generation, Stop, pending action, single-use permit, foreground/lease | Không acquire từ worker hoặc tạo đường phát input khác |
| Hard — action legality | SWAP legal, actual cost/resource, cooldown/actionability, đúng card/skill source/family | Không lấy utility/settings làm chứng minh hợp lệ |
| Hard — PASS/activity | First local turn, authoritative PASS restriction, consuming-action obligation | Không PASS giả, không tự reset/count idle; không coi EVOLVE alone là proven consuming reset |
| Hard — execution/transition | Shared Evolution contract, card/QTE/click-only semantics, source-turn closure, continuation/ACK | Giữ nhánh/gate và executor đang accepted; không chèn action/retry/skip bước |
| Hard — timing | Existing action-family preflight floor, deadline, reserve cho input/ACK | Không nới gate để dùng thêm compute hoặc cố gửi nước “ít tệ nhất” khi hết giờ |
| Objective / run intent | PlayStyle, pet/evolution target, damage-card/source, input mode, mục đích farm/team win | Không tự đổi profile/loadout hoặc bật feature người dùng chưa chọn |
| Soft — fire/setup | Gem/seal target, threshold ra skill, stockpile, setup progress, khoảng cách/geometry ưu tiên | So sánh lại theo tình thế, không khóa candidate chỉ vì chưa đạt target |
| Soft — risk/resources | Giữ Sword/setup gem, ưu tiên Mana/Nộ/Máu/Hút/Khiên, thứ tự emergency chiến thuật, weights | Đánh đổi có evidence trong mục tiêu profile; ghi reason/assumptions |
| Soft — BASIC ranking | Sword-first, safe pool, tuple priority và tactical HP thresholds | Không là điều kiện hard chung cho REASONING; không relabel risky thành safe |

“Đủ chi phí runtime” và “đủ gem theo setting” là hai điều khác nhau. Có thể
override target gem; không thể override chi phí hoặc actionability. Chi phí Nộ
bằng 0 nếu capability hợp lệ cho phép vẫn là giá trị thật, không phải missing.
Không tự hard-code cost theo rarity hoặc suy cost từ net resource delta.

Setting bất biến trong run không có nghĩa action bị cố định: planner đọc cùng
setting, nhưng có thể chọn khác khi HP/resource/boss/uncertainty khác. Override
không ghi lại preferences/checkpoint và không chuyển PlayStyle.

Các quy tắc được gọi “mandatory fire” trong BASIC phải phân loại theo nội dung:
actual obligation/game/executor là hard; heuristic chiến thuật vẫn soft.
Quyền sử dụng một action/family chưa prove không được tạo chỉ bằng contract này.

## 4. Mục tiêu các PlayStyle

Đây là identity/objective boundary; feature/weights chi tiết thuộc 5A.2.

| Profile | Mục tiêu tham chiếu | Ví dụ được thích ứng / giới hạn |
|---|---|---|
| SIMPLE | Thắng và dùng tài nguyên/lượt hiệu quả | Có thể cân nhắc bảo vệ thay Sword-first khi có căn cứ |
| CAREFUL | Thắng, nhạy rủi ro hơn theo tình thế | Không biến mọi UNKNOWN thành cấm tuyệt đối; HP thấp không tự prove lethal |
| Chịu đấm ăn xôi | Chu kỳ chi phí/setup/skill/continuation phục vụ thắng | Fire/setup/Sword lock advisory; cost/source/turn closure hard |
| Demon Aegis | Tận dụng passive theo mục tiêu farm | Effect/passive chưa biết không được thay bằng giả định damage từ gem count |
| Mega Icarus | Chu kỳ skill, bảo vệ/hồi phục và thắng | Không buộc chờ seal target hoặc HP <=30% mới cân nhắc action bảo vệ |
| Bú win | Team win; local death có thể là chiến thuật trung gian | Không áp auto-survival solo; local death giữ team-wait/lifecycle cũ; Coop gate riêng |

## 5. Manifest flow và chủ sở hữu được bảo toàn

Manifest ở mức tài liệu, dựa trên release/canonical/phase reports; 5A.1 không
audit call graph hoặc đo từng read. Trình tự/gate cụ thể của từng nhánh đang
accepted ở v1.2.4 là chuẩn; bảng không hợp nhất các nhánh thành reader mới.

| Boundary hiện có | Owner tiếp tục giữ | Bất biến của Phase 5 |
|---|---|---|
| Start/Resume, immutable run intent, limits/checkpoint | Desktop/controller và FarmRunner | Không thêm lifecycle, tự resume combat hoặc mutate settings |
| Lobby/room/entry/opening | FarmRunner + entry/lifecycle owners | Target/room/session/Ready/Start ordering, opening gates không đổi |
| Read-only memory/transport/board publication | Provider, dispatcher/retained batches, controller hiện có | Giữ polling/read order, ownership, freshness/ACK rules, bounded capture recovery; planner chỉ consume snapshot |
| Card discovery và skill capability | Existing card/capability owners | Không move discovery vào board capture, không thêm scan/read để feed planner |
| Screen/visual/geometry | Existing capture/mapping/UI proof owners | Giữ capture order/frequency/conditions, coordinate plan và image evidence policy |
| Shared Evolution và state sau transition | Existing policy/controller/action owner | Giữ gate/priority và fresh-state handoff hiện có; không thêm vòng đọc của AI |
| PlayStyle consuming decision | BASIC baseline + future reasoning adapter | Đây là seam thay proposal khi opt-in; không thay các boundary bên ngoài |
| Final preflight/permit/lease | Existing action/controller + selected input-delivery path | Candidate khác BASIC vẫn kiểm actual validity; không so heuristic BASIC để veto mọi override |
| SWAP/card/Pet Skill | Existing executor/pacer/QTE or click-only family | Giữ two-click/drag mode đã chọn, click order, QTE ACK/Space, leases/cleanup |
| Pending/ACK/unconfirmed | Existing action owner/controller | Planner không ACK thay, retry hoặc gửi baseline sau physical input |
| Postmatch/accounting/re-entry/recovery | FarmRunner/lifecycle/terminal owners | Result/energy/attempt accounting và no-extra-entry giữ nguyên |
| Stop/emergency/cleanup | Existing controller authority/guards | Không chờ AI/log drain vô hạn; không worker giữ input authority |

Bằng chứng boundary:
- [BASIC policy](../../basic_gameplay_policy.md): proposal-only, runtime gates,
  simulator, turn/energy và after-input fencing.
- [DECISIONS](../../DECISIONS.md): local actor, final preflight, card authority,
  authoritative PASS và technical recovery.
- [Phase 4B.2](../../phase4/phase4b2_report.md): executor/ACK và pinned lease.
- [Phase 4C.1](../../phase4/phase4c1_report.md): UI/config/controller/run ownership.
- [MI.2](../../mega_icarus_spam_skill/mi2_report.md): Mega click-only, no Arrow/Space.
- [v1.2.4 release](../../v1.2.4_release_report.md): later long-run hardening và
  captures còn dùng trong bộ nhớ dù thường không ghi PNG.

Không dùng report Phase 4/MI cũ để hạ version hoặc áp lại scan/pacing đã superseded.
Không tắt screenshot vì hiểu nhầm “không ghi PNG” là “không cần capture”.
CV fallback hiện có vẫn được giữ.

## 6. Contract proposal và existing preflight

Đây là nội dung tối thiểu, chưa chốt DTO/enum/file API (5A.2/B1 sẽ chốt):

- BASIC incumbent và source identity/config version tương ứng.
- Proposal hoặc retain-baseline disposition, action identity và evidence scope.
- Lý do khác BASIC/settings, assumptions/UNKNOWN và phần đánh giá đã hoàn tất.
- Job identity, timing/deadline và fallback/error disposition để tracking.

Baseline phải có trước khi proposal được dùng. Không tạo baseline từ state mới
bằng read riêng của AI; tái sử dụng decision của flow hiện có.

Preflight hiện có xác thực proposal theo source/action/ownership/timing thật,
không yêu cầu action reasoning phải trùng action BASIC. Thay board/session/
turn/config hoặc pending ownership thì discard proposal. Chỉ baseline còn hợp
lệ mới được dùng; không gắn baseline cũ vào board mới.

Không thêm reread/poll/sleep hoặc planner rerun loop để “làm proposal fresh”.
Existing controller xử lý state đổi theo flow đang có. Sau transition thật,
lập kế hoạch lại từ snapshot mới mà flow hiện có cung cấp.

## 7. Fallback và phân loại lỗi

| Tình huống | Disposition | Owner và điều cấm |
|---|---|---|
| Disabled/BASIC | BASIC hiện có, không worker/model/log nặng | Không đổi quyết định hoặc nhịp baseline |
| Shadow | BASIC luôn chọn/phát action; proposal chỉ diagnostics | Không chờ worker hoặc log trước dispatch |
| Lỗi planner/worker/IPC, malformed result, queue full | Trước dispatch: dùng baseline còn hợp lệ | Không pause/stop/recover game chỉ vì reasoning lỗi |
| Essential evidence/model unsupported hoặc proposal chưa phân biệt được tốt hơn | Retain baseline hợp lệ | Không đoán effect hoặc tự bật capability |
| Deadline tới, chưa có completed proposal trả đúng hạn | Baseline còn hợp lệ và đủ existing input reserve | Late result bị bỏ; không xuất partial candidate |
| Search trả sớm do work cap, trước hard deadline | Chỉ completed proposal qua gate hoặc baseline | Work cap không là quyền vượt deadline |
| Source/state đổi | Discard proposal, dùng existing controller/preflight flow | Không blind dispatch baseline cũ hoặc thêm vòng đọc |
| State/identity/turn/action invalid | Existing fail-closed behavior | Fallback không bypass hard gate; NONE/stop theo baseline contract nếu cần |
| Đã có physical input, ACK chưa rõ | Giữ pending action/ACK/recovery owner cũ | Không gửi baseline thay thế, không retry AI hoặc reset PASS |
| Log sink lỗi | Trước dispatch: baseline/degrade reasoning; sau dispatch: diagnostic degradation cho quyết định sau | Không sửa outcome/action đã gửi; không input bù, không block |
| Stop/emergency | Existing Stop authority thắng; hủy/ignore job | Không chờ worker/log drain vô hạn, không orphan/input after Stop |

Fallback là disposition quyết định, không phải một action mới. Baseline có thể
là SWAP/card/PASS/NONE/technical proposal theo contract hiện tại. AI error không
được biến thành PASS giả, đổi sequence, reset idle hoặc technical-recovery trigger.

Circuit breaker được disable reasoning trong run sau lỗi lặp; không mutate
PlayStyle/settings, không tự bật lại liên tục gây log storm. Threshold/cooldown
cụ thể của breaker thuộc A3/B4, chưa chốt ở A1.

## 8. Deadline và error logging

4s default/6s hard cap là budget thiết kế cho decision slice khi opt-in, không
phải delay cố định hoặc quyền luôn lấy đủ 6s. Existing timer/input floor và
reserve của action family vẫn thắng. Opening thiếu budget được dùng BASIC ngay.
A3 chốt phép tính/reserve/SLO; B4/C3/F1 phải đo end-to-end và tail latency.

Log cần nối source/job/action/run/config/profile với:
decision/override, fallback reason, exception, deadline, worker lifecycle và
written/dropped/aggregated diagnostics. Exception đầu đủ chi tiết, lỗi lặp có
rate-limit/count; không duplicate full trace và không lưu ảnh mới.

Ưu tiên tái sử dụng buffering/writer hiện có, bounded enqueue không chờ.
Separate reasoning sink chỉ bật sau khi so với shared namespace chứng minh
không làm chậm action trong tolerance/độ phân giải đã freeze trước phép đo.
Chưa có bằng chứng hoặc không đạt → common events + filter/export riêng.
Queue/disk failure không block baseline/Stop; diagnostics mất có counter/status.

Ở A1: sink/process/thread, overhead, queue/retention sizes, circuit-breaker
threshold và latency SLO đều **NOT_SELECTED / NOT_MEASURED**, giao A3/B4.
Không coi contract “nonblocking” là proof implementation đã nonblocking.

## 9. Ví dụ chấp nhận contract

Các ví dụ là expected design behavior, không phải test/live mới ở A1.

| Case | Tình thế | Expected contract |
|---|---|---|
| M1 — incident thật | [Hotfix](../../mega_icarus_spam_skill/mi3_survival_hotfix_report.md): HP9,46%, seal5 < setting6, cost/card ready; nước Sword có 0 known Sword reply | Không loại Sword/protection/early skill chỉ vì giữ setup hoặc seal chưa đạt; so với BASIC hotfix làm incumbent. Không mặc định heal tốt hơn nước Sword đã có evidence |
| M2 — trước ngưỡng HP | Giả lập cùng setting6/seal5, HP35%, resource/card ready, setup phơi reply trong khi candidate khác giảm known threat | Phương án khác phải được cân nhắc dù HP >30% và seal chưa đạt; chỉ override khi evidence/utility đủ, không tạo HP if mới làm khóa duy nhất |
| M3 — đang khỏe | Giả lập cùng setting, HP cao, known threat thấp, useful safe setup progress | Giữ mục tiêu chu kỳ Mega; setup có thể tốt nhất, không dùng skill/tiêu Sword tùy tiện chỉ vì có quyền override |
| M4 — actual cost thiếu | Target gem đạt hoặc emergency, nhưng thiếu cost/source/actionability | Không dùng skill; baseline legal/UNKNOWN handling, không override hard validity |
| M5 — uncertainty | HP/effect critical UNKNOWN hoặc refill chưa quan sát | Không gán HP0/100%, damage/heal/refill có lợi; dùng scoped proxy có nhãn nếu đủ hoặc retain baseline |
| M6 — stale/late | Proposal dựa trên turn/board cũ hoặc về sau hard deadline | Bỏ proposal; baseline phải còn hợp lệ tại existing preflight, nếu không theo current controller flow |
| M7 — after-input | Worker/log lỗi sau click, ACK đang chờ | Không gửi nước BASIC thứ hai; giữ owner và recovery hiện có |
| M8 — Coop | Bú win local death, teammate còn chơi | Không áp survival/recovery solo; giữ team-wait; không mở Coop reasoning từ evidence solo |

Case M1 dùng số liệu lịch sử, không khẳng định có thể tránh chết chắc chắn.
M2/M3 chưa là fixture/snapshot và chưa chứng minh được ranking; A2 phải chuyển
thành scenario specification, B2/D4 mới kiểm chứng trong phạm vi cho phép.

## 10. UNKNOWN và phần giao bước sau

| Chưa biết/chưa chốt | Xử lý bắt buộc | Bước tiếp nhận |
|---|---|---|
| Feature schema, weights, adaptation/comparator | Không tự hard-code từ bảng nghiên cứu; mục tiêu/constraint ở A1 là chuẩn | 5A.2 |
| Damage/heal/passive numeric, boss policy, refill distribution | Scoped proxy/conditional/UNKNOWN; essential thiếu thì baseline | 5A.2/B3; không buộc full world model |
| Exact reserves/SLO, timer predicate của từng family | Giữ gate runtime accepted; không chọn lại inclusive/strict từ docs cũ | 5A.3, đo B4/C3/F1 |
| Một số tài liệu cũ khác wording về timer floor | Ghi khác biệt: BASIC policy nói inclusive, DECISIONS final SWAP nói strictly above. A1 không audit hoặc nới gate; calibration sau phải map đúng family/source | 5A.3 trước live gate |
| Separate sink / worker isolation / queue / breaker | Chưa chọn; shared filtered diagnostics là fallback thiết kế, implementation chưa có | 5A.3/B4 |
| Flow parity khi có code reasoning | Chưa đo, chưa live-accept bằng tài liệu này | 5C.3/C4, E2/F1 |
| Bú win baseline Coop | Live pending; không biến contract thành profile acceptance | 5D.5 |
| Gameplay improvement / win probability | NOT_MEASURED; replay/shadow không chứng minh counterfactual win-rate | 5E.1 |
| Learned model | Optional, chưa chọn; không tự train sau trận | Nhánh5L khi được yêu cầu |

Chưa có đủ model không có nghĩa phải làm mọi UNKNOWN thành hard ban. R1 được
dùng bounded simulation/risk proxy có nhãn để so phương án; không hứa global
optimum, lethal/safe certainty hoặc no-loss guarantee.

## 11. Exit 5A.1

Contract phải có hard/objective/soft table, flow-owner manifest, fallback trước/
sau dispatch, logging/deadline boundaries và Mega healthy/urgent cases.
Canonical phải phân biệt **defined product intent** với **unimplemented runtime**.

5A.1 chỉ cập nhật docs/report/status/router. Không runtime/config/test changes,
test harness/live/build, commit/push/tag/version bump. Đủ gate → next
[5A.2](../prompts/5A2_ADAPTIVE_PLAYSTYLE_AND_FEATURE_SPEC.md), rồi STOP.
