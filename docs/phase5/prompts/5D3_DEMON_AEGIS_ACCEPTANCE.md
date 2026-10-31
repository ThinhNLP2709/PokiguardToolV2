# 5D.3 — Acceptance Demon Aegis

> **Kết quả cuối minimum — 2026-10-18: PASS STRONG scoped.** Phiên bổ sung20 đã đóng20/20WIN, native ca3physical/effective4/x2/Rage30 đã được chọn và thắng cùng lượt. [Gate hiện tại](../artifacts/5d3_multiplier20_20261018/gate_decision.json). Cùng với ca3Kiếm/Rage150 trước đó, hai minimum đã đủ. Setup/bait/R2 và same-burst order chưa accepted. Tổng29/29,remaining0; next5D.4 chỉ được chọn, chưa thực thi. Mọi đoạn pending/preparation/PARTIAL bên dưới là lịch sử trước closure này.


> **Cập nhật mới nhất:** người dùng yêu cầu thêm tối đa 20 trận để tìm Kiếm x2 và đã xác nhận sẵn sàng. [Runbook](../artifacts/5d3_multiplier20_20261018/RUNBOOK.md). Phiên mới đã mở, đang chờ Start bằng tay; 9 trận cũ giữ nguyên. Các giới hạn 3/6/9 và trạng thái “không còn lượt” bên dưới là lịch sử trước yêu cầu mới, không cấp thêm lượt ngoài cap20. Chưa nghiệm thu multiplier live hoặc chuyển 5D.4.


**Trạng thái mới nhất2026-10-18:**main6vàsupplemental3đềuđãđóng,tổng9/9WIN.
Batchbổsung có12completedretentions,0candidate ca multiplier phùhợp;case vẫn
NOT_OBSERVEDnative/PASSoffline. [Gate hiện tại](../artifacts/5d3_multiplier_targeted_live_20261018_031504/gate_decision.json).
Khôngmởthêmbatchđểépcoverage;remaining0,khôngcodefix/offline remediation được
chỉra,khôngtựmiễngate/advance5D.4. Các trạng tháipreparationbêndưới làlịchsử.


**Cập nhật sau live2026-10-18:**3BASIC+3REASONING đãđóngđủcap6,6WIN.
Native3Kiếm/Rage150 đãselected/sentvàsame-turnterminalWIN;caeffect4below4physical
PASSoffline nhưng khôngxuấthiện trong3REASONING. [Gate](../artifacts/5d3_lieyun_reasoning3_live_20261018_024336/gate_decision.json).
CurrentmainPARTIALduynhấtcoverage multipliernative;remainingattempt0,khôngtự
restart/giahạn/thêmP/codefixhoặcadvance5D.4. Những đoạnreadiness bên dưới làlịchsử.


Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Chốt phạm vi hiện tại theo người dùng — 2026-10-18

BASIC3 đã đóng3WIN,local turns2/8/2. [Closure](../artifacts/5d3_lieyun_basic3_live_20261018_021056/closure.json).
User trực tiếp chốt mức tối thiểu: **3physicalSword + preexistingRage>=100**,
hoặc **effectiveSword>=4 có tính multiplier**. [Nguyên văn](../artifacts/5d3_demon_reasoning_20261018/operator_minimum_clarification.json).
Minimum scope riêng account/Lieyun77/loadout/static stats; sàn2physicalSword,
không1Swordx4,không rule setting-minus-one,không chứng minh damage formula.
Setup/bait là mục tiêu bổ sung; không buộc phải đạt toàn bộ expanded cases mới
đáp ứng mức tối thiểu của user. Phần chưa prove vẫn unsupported/NOT_OBSERVED.

Offline đã xong với [verification](../artifacts/5d3_demon_reasoning_20261018/verification.json).
Next duy nhất là tối đa3REASONING còn lại trong tổngcap6, khi user chuẩn bị và
kích hoạt riêng theo [runbook mới](../artifacts/5d3_demon_reasoning_20261018/RUNBOOK.md).
Không có request/claim REASONING hiện tại. BASIC/flow unchanged. Các entry/prep
records bên dưới là lịch sử của cùng prompt, không phải trạng thái live mới.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [demon_aegis_farm_policy.md](../../demon_aegis_farm_policy.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md), D01–D09/O01–O09.
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. Common core/gates trước đủ; Demon Aegis passive/effect evidence scoped, unsupported giữ baseline.

Acceptance Demon Aegis có passive-aware comparison, không nhầm resource tally với effect damage.

Entry record2026-10-18:[5D.2closed scopedHT7](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/gate_decision.json),
common/native execution unchanged during that batch. This supplies prior-step
technical closure,not Demon model/calibration/input authority. D3BASIC3preparation is OFFLINE_READY;Lieyun1436/lv77 cohort selected,livePENDING,
notactivated. Own Demon scope/offline review and bounded cohort are required
before any live request;do not reuse DarkQueen/HT7request,claim or resources.

Current preparation2026-10-18:[report](../reports/5d3_report.md),
[verification](../artifacts/5d3_demon_acceptance_20261018/verification.json),[runbook](../artifacts/5d3_demon_acceptance_20261018/RUNBOOK.md).
Same5D.3:Lieyun1436/lv77 selected with Demon Aegis normal/passive/setting4;next3BASICcontrol using new explicit
protocol;no game/tool/request/claim started. Planned3REASONING remain unactivated
until own native review/model/selector/reserve are complete. Totalcap6noextension.

## Thực hiện trong phạm vi

1. Map passive-supported scope từ canonical/evidence manifest; không suy formula từ tên field. Ghi shield/Sword/residual board transitions nào model biết và phần UNKNOWN.

2. Offline scenarios cho passive opportunity, setup stability, boss reply, HP/resource context và same-settings adaptive choice. Bao gồm setting4 vs scoped3+5/existing Rage, insufficient Rage, physical/effective distinction, same-burst ordering, boss eats Shield, max-Sword tie phá setup và Sword bait healthy/lowHP. Effect thiếu essential evidence fallback, không hard-code combo hoặc đòi full damage model cho mọi R1 override. Làm rõ2026-10-18:Lieyun1436/lv77,current account setting4→3Sword+100Rage;5Ragex1 phải thực sự consume được trong vùng quét. Other-account setting3→2Sword+đủRage cần own scope. Sàn2physicalSword cho sufficiency certificate;không nội suy setting-minus-one hoặc transplant certificate. Thêm variants/negative controls trước D3reasoning admission;chưa gọi variants mới đã test.

3. Live activated default BASIC3+REASONING3 attempts, tổng cap6, fixed loadout/boss/input mode/source/config. Không force thêm match để có passive.

4. Đo decision/override/fallback, passive event attribution và board progress; tách observed HP delta khỏi predicted value và unrelated boss effects. Narrow calibration kiểm conversion/applicability/order/sufficiency theo đúng account/boss/loadout; ghi predicted vs actual boss reply/retained Shield. Case chưa gặp ghi NOT_OBSERVED; đủ case khác không tự prove joint3+5 hoặc bait.

5. Verify no read/capture/action/QTE/ACK/lifecycle change; stop batch khi critical regression. Không sửa gameplay/passive accepted ở bước acceptance.

6. Required passive case chưa quan sát thì PARTIAL/NOT_OBSERVED với targeted evidence plan; đủ boundary evidence nhưng model unsupported thì chỉ đóng baseline scope, không claim Demon REASONING accepted. Setup sau boss/retained Shield/bait/multifactor là mục tiêu chính theo user;combo ít Kiếm hơn là nhánh hỗ trợ. Các trận1turn chỉ chứng minh opening/fire thuộc scope,không thay contested-setup acceptance;không tăng cap hoặc đổi boss giữa batch để ép case.

## Live gate chung

Live chỉ khi người dùng yêu cầu chạy batch của bước này và chuẩn bị game theo
protocol. Nếu đang yêu cầu docs/offline hoặc chưa sẵn game: chuẩn bị runbook,
ghi live PENDING và STOP. Không computer-use tự điều khiển game, không extra
memory reads/captures, không retry vô hạn. Dừng ngay khi Stop/user abort,
wrong-turn/stale/duplicate input, ownership/ACK conflict hoặc flow regression.
Không inject fault có nguy cơ phát input sai trong live.

## Gate bắt buộc

- Passive model dùng đúng scope; UNKNOWN không được tính favorable.
- Adaptive rationale giữ profile intent; no generic shield/Sword score substituted for unsupported damage.
- Zero critical regression và baseline fallback proof; efficacy chờ E1.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Demon scoped model/decision observations + bounded pilot report.
- Updated capability accepted/unsupported and exact missing evidence.
- Report `docs/phase5/reports/5d3_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5D.4](5D4_MEGA_ICARUS_ADAPTIVE_SURVIVAL_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
