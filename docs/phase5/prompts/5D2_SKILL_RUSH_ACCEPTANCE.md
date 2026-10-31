# 5D.2 — Acceptance Chịu đấm ăn xôi

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [basic_gameplay_policy.md](../../basic_gameplay_policy.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. 5D.1 kỹ thuật đã đóng cho scope đủ; core/common flow sạch; Skill Rush capability đủ.

Acceptance Chịu đấm ăn xôi: thích ứng giữa thiếu chi phí/setup/skill/continuation mà không sửa execution.

Làm rõ trực tiếp ngày 2026-10-16: tập quyết định phải bao gồm SWAP, PET_SKILL
và PASS khi hợp lệ. Suy luận chọn có nên dùng skill/bỏ lượt và thời điểm, không
chỉ xếp hạng swap. QTE và executor giữ nguyên. Thiếu mô hình hiệu ứng để so
sánh một action phải giữ missingness/retention; không coi baseline chưa chấm
được là điểm 0, không dùng lý do thiếu model để tuyên bố đã hoàn tất profile.

Batch ban đầu: Starburst 73 + Huyền thoại 7 theo user; BASIC3 trước để thu
native timing/capability/skill/continuation, rồi REASONING3 sau own gates.
Tổng cap6, mọi entry lỗi/abort vẫn tính. Không thêm trận để ép gặp skill/PASS.

Trạng thái cập nhật **2026-10-18: PASS STRONG, scoped HT7**.
Starburst10/10 closed;targeted DarkQueen110case3/3closed=1BASIC+2REASONING.
Native REASONING2:2WIN,24SWAP/24ACK,5Perfect,2completed-reasoning nonterminal
skill continuation chains,3legal PASS waits(2serverconfirmed/1UNKNOWN then
mandatory consuming reset). Native6effectiveSword<setting7skill override and
6completedretentions prove settings advisory without an override quota.
12mandatory gates passed;source32241dd/flow/QTE/owners unchanged.
[Gate decision](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/gate_decision.json),[closure](../artifacts/5d2_darkqueen_reasoning2_live_20261018_0126/closure.json).
PASS27idlecount remainsUNKNOWN;existing owner forbids thirdPASS and confirms
reset. No efficacy/globalotherpet/damage/refill claim,BASIC staysdefault.
No additionalD2live or request reuse. Next5D.3 only after user requests it;
this prompt is completed in declared scope,not authorization to rerun a batch.

## Thực hiện trong phạm vi

1. Chuẩn bị paired incident replays cho thiếu resource, ready skill, setup bị phá bởi boss reply, survival trade-off và continuation. Tactical Sword lock/fire threshold là advisory; actual cost/source/cooldown/PASS là hard.

2. Chạy focused offline profile cases trước live. Card/effect không đủ scope giữ baseline action contract, không invent heal/damage.

3. Live activated default BASIC3+REASONING3 attempts, tổng cap6 cả invalid/abort, cùng boss/loadout/config/input mode; không mở thêm để bắt skill.

4. Đánh giá time-to-cost/setup, actual skill dispatch/ACK/QTE và post-skill consuming action theo path cũ. Planner được đổi ưu tiên khi tình thế có căn cứ, không đổi card/QTE click sequence.

5. Trace why override settings/baseline, assumption scope và fallback. Cost already sufficient không nhận readiness credit vô hạn.

6. Ghi NOT_OBSERVED cho skill/continuation/emergency chưa xảy ra; required evidence thiếu thì PARTIAL hoặc targeted evidence có cap, không PASS chỉ vì thắng3 trận.

7. Chỉ đóng profile nếu gate trong A3 được prove; BASIC default giữ, không promote profile khác.

## Live gate chung

Live chỉ khi người dùng yêu cầu chạy batch của bước này và chuẩn bị game theo
protocol. Nếu đang yêu cầu docs/offline hoặc chưa sẵn game: chuẩn bị runbook,
ghi live PENDING và STOP. Không computer-use tự điều khiển game, không extra
memory reads/captures, không retry vô hạn. Dừng ngay khi Stop/user abort,
wrong-turn/stale/duplicate input, ownership/ACK conflict hoặc flow regression.
Không inject fault có nguy cơ phát input sai trong live.

## Gate bắt buộc

- Profile identity và actual validity giữ; tactical setting không đóng băng reasoning.
- Skill/continuation evidence rõ, zero duplicated/stale/input-after-stop/flow regression.
- No live outcome assigned to unchosen candidates; small sample technical only.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Skill Rush scenario + bounded live evidence và limitations.
- Updated profile capability, fallback reasons và action/ACK correlation.
- Report `docs/phase5/reports/5d2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5D.3](5D3_DEMON_AEGIS_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
