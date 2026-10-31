# 5D.1 — Pilot SIMPLE và CAREFUL

Ngày 2026-10-16. Runbook của [prompt chính](../prompts/5D1_SIMPLE_CAREFUL_PILOT.md).
[Report hiện tại](../reports/5d1_report.md) quyết định entry gate. Không tạo P mới.
Lượt offline không mở game/UI, không tạo live request, claim hoặc Start.

## Mục tiêu

Kiểm worker đưa ra lựa chọn hợp lệ hoặc giữ BASIC, rồi đi qua đúng flow
read → quyết định → fresh/final preflight → input → ACK → kết trận → phòng boss.
Không bắt buộc đổi nước so với BASIC. Completed retention có rationale là hợp lệ;
toàn bộ attempts chỉ timeout/veto chưa chứng minh selection hoạt động.
Không dùng vài trận để kết luận tăng win-rate.

Scope: SIMPLE/CAREFUL, Solo, pet thường → tiến hóa thường, Attack,
foreground/two_click, input parameters cũ. Skill/card/EVOLVE/QTE vẫn do BASIC
xử lý. Planner chỉ đề xuất ordinary SWAP trong capability. R2, Demon, Mega,
Skill Rush và Coop chưa được mở bởi bước này.

## Chuẩn bị cần người dùng

1. Đóng tool cũ. Tự mở game và vào phòng boss Solo, chưa bấm Bắt đầu trong game.
2. Chọn boss đánh được bằng BASIC với pet thường/tiến hóa thường, trang bị Attack.
   Giữ boss, pet, thẻ và setting chiến thuật trong mỗi cohort. Starburst lv73 /
   Phoenix là lựa chọn đã có BASIC smoke lịch sử; chưa mặc định trạng thái hiện tại.
3. Báo tên boss và pet. Agent đối chiếu bằng lệnh/state/log của flow được phép;
   người dùng không cần lấy PID. Không computer-use điều khiển game.

Agent chuẩn bị source UI và private session preferences; không build, không thay
preferences farm thường. Đầu tiên SIMPLE/BASIC, AI và shadow OFF, target3/cap3.
Người dùng bấm Bắt đầu trong TOOL sau khi cấu hình được đối chiếu.

## Thứ tự và cap

| Arm | Profile | Attempts tối đa | Mục đích |
|---|---|---:|---|
| A | SIMPLE | 3 BASIC | Control + H/I native của source hiện tại |
| B | SIMPLE | 3 REASONING | Pilot selection/fallback, calibration từ A |
| A | CAREFUL | 3 BASIC | Control + H/I của đúng profile |
| B | CAREFUL | 3 REASONING | Pilot selection/fallback, calibration từ A |

Tổng cap12, gồm failed entry/abort/invalid. Không chạy bù hoặc đổi boss để tìm
override. Không chuyển arm giữa trận. P11/P15/P19 giữ nguyên lịch sử, không cộng
vào bằng chứng source mới. Pilot kỹ thuật theo arm liên tiếp, không phải AB/BA
hoặc thử nghiệm efficacy. Mỗi arm target3/cap3 và có one-shot request riêng.

Control phục vụ đồng thời baseline cùng source và native reserve. Cách tính
reserve, root250/final100, guard250, margin100, budget và input parameters khóa
trước trận. Reserve được dẫn xuất đúng công thức sau control, không tune theo
thắng/thua. H/I là sample maxima mô tả, không future bound. U/transport/host–Unity
alignment vẫn UNKNOWN theo operational contract đã chốt.

## Chuẩn bị file và mở UI tại thời điểm live

Dùng tools/prepare_d1_pilot.py controls với preferences hiện có, game executable,
boss-ID/name được xác minh, profile simple hoặc careful và file output mới trong
V2. Tool chỉ tạo request BASIC cap3, không attach, claim hoặc Start. Chỉ tạo khi
người dùng sẵn game, tránh expiry hết trước lúc test.

Mở tools/desktop_ui.py với --basic-calibration-request, SHA256 ngoài request,
--preferences và --artifacts mới. Existing calibration activation dùng private
preferences; agent không auto-Start. Giữ cấu hình và loadout trong cả arm.

Sau control dùng prepare_d1_pilot.py package với request, timing directory,
FarmRun directory và qualification của đúng profile. Package kiểm source/host/
build/config, all-attempt ledger, sent/ACK hoặc strong terminal proof, raw clocks
và writer watermarks. Opening chưa có thẻ và read vượt policy không là full anchor;
complete return vẫn giữ trong reserve để không thấp giả tạo.

Package trả draft chưa activated. Agent kiểm raw rồi lập independent bounded
activation trước khi mở reasoning UI. Request pin source/host/build, calibration,
qualification/profile, policy/config, run-ID mới, expiry và cap3. Draft hoặc cost
FAIL không tạo authority. Loader kiểm lại trước Start; one-shot claim ngăn reset
cap bằng restart/resume. Không dùng calibration SIMPLE cho CAREFUL.

## Evidence, dừng và đóng prompt

Giữ từng attempt: FarmRunId/MatchId/session, arm/profile/source/config, W/L/UNKNOWN,
failed entry/abort, elapsed, energy hoặc tool-turn proxy có nhãn, sent/ACK,
return-to-boss-lobby, rationale/UNKNOWN, retention/override/fallback/breaker,
writer loss và Stop. Không thêm memory/screenshot để thu nghiên cứu. Timing BASIC
không chứng minh latency override; reasoning arm kiểm monitor/preflight của nó.

Dừng khi user Stop, drift, wrong-turn/stale/duplicate, ownership/ACK conflict,
input sau Stop, flow regression hoặc mất essential diagnostics. Không inject fault
trong game. Thiếu coverage sau cap ghi NOT_OBSERVED/PARTIAL, không tự thêm trận/P.
Lỗi AI trước dispatch dùng BASIC còn hợp lệ và log riêng; không gửi BASIC thay thế
sau input. Invalid game state vẫn fail closed theo flow accepted.

Đóng kết quả riêng từng profile. Zero critical failure và đủ technical gates mới
chốt 5D.1, chọn 5D.2 rồi dừng. Nếu lỗi, nêu evidence/cause cụ thể và xử lý trong
5D.1, không tự kéo dài roadmap. Bú win là nhánh phụ chỉ khi người dùng báo lỗi.

## Current shared guard update2026-10-16

SIMPLE arms đã dùng6attempts; giữ reduced exposure như report. CAREFUL arms còn
3+3. Source308BA4856 đã qualifiedactual shared guard32/32 mỗi profile.
Khi package fresh CAREFUL controls, draft vẫn unarmed. Khi lập activation phải
pin `component_guard_policy=SHARED_HOST_GUARD_V1` trong request và independent
activation review, dùng qualification có cùng policy trong tất cả pipeline raw.
Thiếu mode pin bị loader từ chối. SIMPLE old basis chỉ dùng reviewed boundary
package, không thay raw.source_sha256 hoặc dùng lại old request/claim.


## Original12 closure2026-10-16

Original12 complete. CAREFUL BASIC3/REASONING3 allWIN,13reasoning jobs
completed/retained,0fault;SIMPLE post-fix liveNOT_OBSERVED. D1PARTIAL,nextD1.
Targeted SIMPLE3 plan đã chuẩn bị file-only/verified native-boundary/cost,
chưaactivated. Cần user yêu cầu riêng trước claim/Start/extraattempt;
không thêm BASIC controls/P hoặc mở rộngcap tự động.
[Current report](../reports/5d1_report.md),
[targeted plan](../artifacts/5d1_main_pilot_20261016_v1/simple_postfix_targeted_plan.json).


## Final targeted closure2026-10-16

User-authorized targeted SIMPLE3 hoàn tất3/3WIN,33completed retention jobs,
153durable records,36swap joins/33ACK/3terminal proofs,0worker/timing faults.
D1PASS STRONG scoped technicalR1/retention SIMPLE–CAREFUL;positiveguard debit,
acceptedoverride/emergency cases cònNOT_OBSERVED live,không tự chạy thêm.
Next5D.2,chưa thực thi. [Final report](../reports/5d1_report.md).
