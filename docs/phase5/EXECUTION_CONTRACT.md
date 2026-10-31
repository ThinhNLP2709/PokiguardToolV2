# Phase 5 — Hợp đồng chung cho mọi prompt

Ngày chốt yêu cầu đầu vào: **2026-10-09**. File này phải được đọc cùng từng
prompt. Chỉ dẫn trực tiếp mới nhất của người dùng có ưu tiên cao nhất.

## 1. Giữ nền v1.2.4

Baseline lúc tạo bộ prompt:
- source version: v1.2.4;
- HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29;
- report: [v1.2.4](../v1.2.4_release_report.md);
- operational soak do người vận hành xác nhận; không suy thêm win-rate/coverage;
- Bú win: offline complete, live pending.

Khi thực thi sau này phải ghi version/HEAD thực tế; không reset/checkout cưỡng
bức về baseline này. Nếu nguồn đã thay đổi, giải thích khác biệt và bảo toàn
accepted behavior. Không sửa BASIC để làm kết quả REASONING đẹp hơn.

## 2. REASONING là phần bổ sung quyết định

Khái niệm duy nhất:
```text
snapshot đã có + PlayStyle + cấu hình + baseline decision
    -> đề xuất REASONING hoặc fallback baseline
    -> đường preflight / action / ACK hiện có
```

Đây là sơ đồ boundary, không phải một thứ tự memory reader mới.
Không thay solver đã làm việc; tái sử dụng primitive phù hợp.

**Làm rõ trực tiếp từ người dùng ngày2026-10-15 (P14):** suy luận tìm lựa chọn
tốt nhất theo dữ liệu và mục tiêu hiện có. Nước đó có thể trùng BASIC; đây là
kết quả bình thường, không là lỗi và không cần cố tạo khác biệt. Không đặt quota
hoặc phần trăm bắt buộc đổi nước. Kiểm thử nhánh đổi nước chỉ kiểm chứng kỹ thuật
khi có proposal hợp lệ; không là yêu cầu mọi lượt/trận phải override hoặc chứng
minh global optimum. Phân biệt completed retention với timeout/error fallback.

Phân biệt:
- **Hard:** identity/ownership, actual costs, cooldown/actionability, legal
  action, nguồn skill, capability đã được prove, turn/PASS legality,
  input authority, pending action và deadline an toàn.
- **Objective:** mục tiêu PlayStyle, chế độ pet/loadout đã chọn, mục đích farm
  hoặc team win. Không tự chuyển sang PlayStyle khác.
- **Soft:** ngưỡng ra skill/setup, giữ Sword, ưu tiên tài nguyên, thứ tự
  heuristic và trọng số chiến thuật. REASONING được cân nhắc lại theo tình thế.

Một ngưỡng Kết Ấn không được buộc Mega Icarus tiếp tục setup khi action khác
hợp lệ có căn cứ bảo vệ tốt hơn. Ngược lại, “sinh tồn” không được biến thành
cấm UNKNOWN hoặc một rule HP chung cho mọi PlayStyle. Không hứa tìm global
optimum hay xác suất thắng khi mô hình chưa đủ.

**Làm rõ trực tiếp của người dùng tại 5D.2, ngày 2026-10-16:** suy luận không
chỉ chọn nước ăn viên. Nó phải so sánh có nên dùng skill, dùng vào lúc nào,
hay nên bỏ lượt khi PASS hợp lệ. Ngưỡng chiến thuật chỉ là tham khảo. Khi chọn
skill, nguồn/cost/cooldown/actionability/turn vẫn bắt buộc; khi chọn PASS,
quyền PASS và giới hạn bỏ lượt hiện có vẫn bắt buộc. Sau quyết định, executor,
QTE, source-turn fence, ACK và chờ lượt tiếp theo giữ như cũ. Acceptance chỉ
xếp hạng SWAP không được gọi là đã hoàn tất đầy đủ profile có skill/PASS.

BASIC tắt REASONING phải giữ nguyên quyết định và behavior accepted. Các
tactical override chỉ tồn tại trong nhánh REASONING, có reason, evidence và
fallback. Không ghi đè cài đặt của người dùng khi planner chọn khác gợi ý.
Default của preferences cũ/mới vẫn BASIC trong Phase 5. PROMOTE chỉ có nghĩa
REASONING đủ bằng chứng để người dùng opt-in trong scope đã prove; không tự bật
AI hoặc chuyển default của người đang dùng v1.2.4.

5A.2 làm rõ cùng nguyên tắc cho mọi profile: actual resource/effect context
có thể cho chọn dưới count setting; setup phải còn tiếp cận được sau boss.
User calibration Nộ20/Mana30 và Demon3+5 có scope/provenance, không full damage
formula. Nominal Sword-first giữ ties, chừa Sword làm mồi phải tính threat/
fragility. Xem [spec 5A.2](specs/5a2_features_utility_and_profiles.md).

## 3. Flow không đổi

Không thay hoặc reorder:
- lifecycle/entry/room/result/re-entry và FarmRunner;
- memory polling, provider ownership, scan/recovery và thứ tự đọc state;
- screenshot frequency/order, visual proof và coordinate mapping;
- swap/card/skill/QTE executor, mandatory pacing, input transport/foreground lease;
- ACK, pending ownership, retries, stop/emergency, pause/resume/checkpoint.

Planner dùng immutable copy từ state đã được flow hiện có cung cấp.
Không gọi provider, đọc process, capture screen, executor hoặc input từ worker.
Không thêm memory poll, reread hoặc capture để chờ planner.

**Làm rõ theo quyết định trực tiếp của người dùng ngày 2026-10-12 (P2):**
khi opt-in suy luận, controller tính BASIC trước rồi cung cấp cùng immutable
state và incumbent cho worker. Được chờ kết quả trong decision budget còn an
toàn, trả sớm khi xong; kiểm emergency Stop bằng event/hotkey hiện có mỗi lát
ngắn. Deadline lấy từ thời điểm observation ban đầu, trừ input reserve, sai số
timer và return margin; không reset và không cố chờ tới một số giây cố định.
Timeout/lỗi giữ BASIC; checkpoint fresh/final và ACK hiện có vẫn quyết định input.
Đây thay thế lệnh cấm mọi vòng chờ planner trước P2; shadow/BASIC không chờ.

Người dùng cũng yêu cầu nước suy luận xong thì đi ngay: riêng ordinary foreground
SWAP có receipt hợp lệ bỏ random reaction và random jitter giữa hai click.
Giữ adaptive pacing cơ sở, cursor settle, mouse hold, hai click và foreground/
Stop gates. BASIC/fallback giữ random cũ. Không rút reserve xuống1–2s bằng phỏng
đoán; muốn đổi bound phải có measurement của đúng cohort/transport.

REASONING được tiêu tốn compute budget trong decision slice hiện có khi bật;
4–6 giây là trần cấu hình, không phải delay được thêm cố định. Shadow không
chờ kết quả trước khi baseline tiếp tục. Tắt REASONING không khởi tạo worker
hoặc thêm read/capture/log nặng vào hot path BASIC.

Final preflight dùng checkpoint/read hiện có. Nếu cần read/capture mới hoặc
thay flow để làm một feature hoạt động, feature đó chưa thuộc Phase 5 này:
ghi UNKNOWN, fallback, hoặc đề xuất scope riêng cho người dùng; không tự làm.

**Operational contract đã được người dùng chốt ngày2026-10-14:**
“cứ triển khai tôi sẽ nghe theo ý bạn” — [accepted decision](artifacts/5d1_operational_timing_v1/accepted_decision.json)
pin [P9 proposal](research/5d1_p9_operational_timing_contract.md), triển khai
[offline P10](reports/5d1_p10_report.md). Đây là nhánh opt-in riêng, raw timer
trừ host elapsed là operational projection, U/transport/alignment vẫn UNKNOWN.
Budget tính từ observation-start; reserve bao controller tail + final input +
selector allowance + full BASIC commanded wait ceiling +guard≥250ms; margin≥100ms.
Không dùng U=0 hoặc nới strict finite-U loader. Late server receipt/OS/pause/FX
vẫn có thể làm hụt lượt; không gọi sample maximum là future hard bound.

Activation còn cần independent bounded request, native BASIC-only all-attempt
calibration/ACK/watermarks, source/build/host/config/cohort/expiry/cap và one-shot
claim. Acceptance offline không bật live hoặc UI REASONING. Timing lỗi chỉ tắt
AI; BASIC còn hợp lệ giữ flow/input cũ. Operational extra veto tại final chỉ áp
cho reasoned receipt; no second-input fallback. Native H/I/R/read-span threshold
còn PENDING, không tạo authority từ numbers thiếu chứng cứ. BASIC/shadowOFF là
mặc định; writer durability/cleanup thuộc background owner, Stop chỉ signal.

**Quyết định gom luồng của người dùng ngày 2026-10-16:** phần thiếu của prompt
chính được hoàn thành chung offline; không tự tạo chuỗi P tiếp theo. 5D.1 dùng
current-source native controls của từng profile rồi mới bật reasoning trong
cùng cap12 theo runbook. Cost/source/host validation không thay native proof;
native sample maxima không được gọi là future bound. Hoàn tất offline chỉ dừng
ở evidence cần live. Các P trước đó được giữ như lịch sử, không reset hoặc đổi
FAIL thành PASS để tiếp tục.

## 4. Fallback và cô lập lỗi

Baseline decision phải sẵn sàng trước khi nhận đề xuất. Có lỗi planner,
timeout, unsupported evidence, malformed result, worker exit, queue full hoặc
log sink lỗi thì fallback nhanh, không pause/stop/recover game chỉ vì AI lỗi.
Có thể disable REASONING cho phần còn lại của run bằng circuit breaker.

Fallback chỉ dùng baseline còn hợp lệ tại existing preflight. Source đổi thì
loại proposal và tuân thủ flow đọc/đánh giá lại hiện có. State invalid vẫn fail
closed như v1.2.4; không gọi fallback để bypass gate.

Đã gửi input thì không gửi baseline thay thế. Uncertain ACK thuộc owner/recovery
hiện tại, không thuộc planner. Lỗi suy luận không được tính thành PASS giả,
reset idle, đổi srvSeq, retry skill hoặc thêm input.

Stop/emergency không chờ planner hoặc logging drain vô hạn. Cleanup worker
không giữ mouse/keyboard/foreground authority và không tạo orphan controller.

## 5. Log có giới hạn và không làm chậm action

Ưu tiên diagnostics riêng: reasoning decision, override, fallback, exception,
deadline, worker lifecycle, dropped/aggregated records. Có source/job/action
identity, profile/config version và timestamp để nối với log gameplay.

Ưu tiên dùng buffering/writer hiện có hoặc enqueue không chờ. Separate
reasoning.jsonl chỉ bật nếu so với shared sink không làm chậm đường action trong
độ phân giải/tolerance đã chốt trước phép đo. Chưa prove hoặc không đạt, giữ event
namespace trong log chung và filter/export sang view riêng. Không ghi đôi toàn
bộ trace để chỉ tạo hai file.

Bound queue, rate-limit lỗi lặp, bounded retention; không lưu ảnh mới. Exception
đầu tiên giữ thông tin chẩn đoán, lỗi lặp có count/summary. Queue/disk failure
không block fallback; mất diagnostics phải hiện counter/status, không claim
“logged” nếu record chưa được ghi. Chốt SLO ở 5A.3, đo ở 5B.4/5C.3/5E.2/5F.1.

[5A.3 telemetry/deadline/SLO](specs/5a3_telemetry_deadline_acceptance.md) và
[bounded live protocols](specs/5a3_bounded_live_protocols.md) đã chốt spec:
absolute budget4s/cap6s bị rút theo timer/reserve, bounded counters/queue/breaker,
caps/all-attempt metrics/CI/margins. Numerical targets vẫn PROPOSED; B4/C3 phải
calibrate/map accepted family gates trước live. Không lấy doc PASS làm runtime
acceptance, không tự mở batch hoặc kéo dài để tìm case/PASS.

## 6. Bằng chứng và thử nghiệm

Không đoán offset/RVA/pointer chain, damage, refill hoặc boss policy.
Không lấy score gap làm confidence probability. Model/scenario prediction
không được trộn với observed outcome. Không gán kết quả trận cho candidate
chưa được chọn.

R1 có thể dùng risk proxy có nhãn và override chiến thuật với bằng chứng giới
hạn. Không buộc chờ một damage model hoàn hảo; cũng không gọi proxy là chứng
minh lethal/safe. R2/model chỉ được dùng trong phạm vi kiểm chứng.

Chỉ chạy meaningful focused tests ở bước component; full regression ở boundary
tích hợp/acceptance/package và khi regression thực tế yêu cầu. Docs-only không
chạy gameplay/test harness. Live chỉ trong bounded protocol được kích hoạt
riêng; người dùng chuẩn bị/điều khiển game, không computer-use tự chơi.

## 7. Entry/exit, Git và STOP

Mỗi bước đọc AGENTS, STATUS, ROUTER, contract này, prompt và report cha. Inspect
status/HEAD trước thay đổi để bảo toàn unrelated work; chỉ đọc code liên quan
khi bước thực thi cho phép. Không chạy prompt sau chỉ vì prompt hiện tại pass.

Prompt generation/review không phải lệnh triển khai. Trạng thái thực tế theo
STATUS/report từng bước; 5A.1–5A.3 đã định nghĩa contract/feature/acceptance spec, chưa runtime implementation.
5A chỉ docs; 5B code offline; 5C integration opt-in;
5D trở đi mới cho REASONING input theo live gate.

Không tự commit/push/tag/release/version bump; không build trước 5F.1.
Report trung thực UNKNOWN/NOT_OBSERVED/INCONCLUSIVE. Update STATUS/router và
dừng đúng milestone; chỉ chọn next prompt, không thực thi nó.

Do không tự commit, HEAD có thể giữ nguyên qua nhiều step: report phải kèm
worktree/source fingerprint và changed-file manifest để map evidence tới đúng
code thực tế, không dùng HEAD đơn lẻ như bằng chứng source không đổi.

## D1 shared guard refinement2026-10-16

Explicit opt-in shared host guard chỉ thay post-return AI breaker. Base component
flags giữ; positive excess H+I cùng tiêu một250ms pool,aggregate reserve giữ.
Không duplicate250 cho mỗi component. Invalid time/guardexhaust/aggregate vẫn
AI-only fault,no replay. Legacy policyNone nguyên hash/behavior. Source boundary
review chỉ reuse exact c707BASIC H/I facts ngoài changedmonitor/setup code,
không relabel raw hoặc thay current source/host/fresh cost/activation gates.
