# 5D.5 — Coop Bú win: CLOSED_BASELINE_ONLY

Ngày **2026-10-19**, Asia/Saigon. Bước có điều kiện đã đóng theo mục 6 của
[prompt chính](../prompts/5D5_CONDITIONAL_COOP_BU_WIN_ACCEPTANCE.md).
**Giữ Bú win BASIC; REASONING Coop và shadow Coop chưa được hỗ trợ.**
Đây không phải nghiệm thu live Coop hoặc tuyên bố Bú win hiện bị lỗi.

| Trường | Kết quả |
|---|---|
| Step / parent / mode | 5D.5 / [5D.4](5d4_report.md) / CONDITIONAL_LIVE, chỉ thực hiện review offline |
| Result | **CLOSED_BASELINE_ONLY** |
| Baseline | Giữ BASIC; **BASELINE_LIVE_PENDING** trên current source |
| Suy luận Coop | **UNSUPPORTED_REASONING**; shadow trả `COOP_SHADOW_NOT_ACCEPTED` |
| Efficacy | NOT_APPLICABLE; không có cohort so sánh Coop |
| Source version | 1.2.5; không build hoặc đổi version |
| HEAD / branch | `c646acfa5e895732bbdade553f9d7bd61171cd29` / `codex/phase3a2-board-repair` |
| Source fingerprint | `aeab13c20e003ada3d24a0afbc8c32cbc2f28661f45b1a7a80b34814699efe57` |
| Changed runtime/test files | **0**; 337 Python files trong src/tools/tests byte-exact |
| Live batch | Chưa kích hoạt/chuẩn bị cho 5D.5; **0 attempt mới**, không mở hoặc thao tác game/tool |
| Next | **5E.1 SELECTED ONLY / NOT EXECUTED**, chỉ profile/cohort Solo đã accepted riêng |

## Cơ sở đóng phạm vi

[Release v1.2.4](../../v1.2.4_release_report.md) ghi Bú win mới hoàn tất offline,
chưa có live acceptance. Baseline riêng này không được suy từ Solo hoặc số trận
soak của các lối khác. 5D.4 đã đóng scoped technical gate và sửa kiểm tra PASS
sau STOP; kết quả đó không cấp authority hoặc timing calibration cho Coop.

Đã rà 59 thư mục hiện có trong `logs/farm_runs`: 58 thư mục farm và một nơi
lưu log reasoning chung. Có 3 phiên với combat config xác nhận `bu_win/coop`,
51 phiên mang config khác, một lỗi entry Coop được đối chiếu báo cáo cũ và
3 phiên chỉ có entry, không đủ dữ liệu xác định mode. Không đoán mode theo tên boss.

| Phiên lịch sử | Legacy attempts / completed | W / L / UNKNOWN | Kết thúc |
|---|---:|---:|---|
| `810139fceb784f94b033aa37c2e26714` | 1 / 1 | 0 / 0 / 1 | SAFE_STOP, POSTMATCH_UI_AMBIGUOUS |
| `abf8415a1b06405883bafb4368e6dce7` | 5 / 4 | 0 / 0 / 4 | SAFE_STOP, COMBAT_SAFE_STOP; attempt5 POLICY_NO_SAFE_MOVE |
| `bec10a25fbb84b5a9ed76c5b96fd85a9` | 1 / 1 | 0 / 0 / 1 | SAFE_STOP, POSTMATCH_UI_AMBIGUOUS |

Đây là dữ liệu lịch sử, **không phải batch D5 mới**. Tổng 7 legacy attempts,
6 completed/6 UNKNOWN không có nghĩa 6 trận thua. Phiên `abf…` có 4 UI WIN,
4 xác nhận thưởng và đã về lobby để vào trận kế; terminal accounting vẫn ghi
UNKNOWN/PARTIAL/MEMORY_INCOMPLETE, local HP0 và winner `__PLAYERS__`.
Giữ riêng bằng chứng UI/team và strict result, không sửa log thành 4 strict WIN.

Lỗi entry guest Rivan `6f6…` được báo cáo ở
[sửa ngày 11/10](../../bu_win_runtime_fix_20261011.md). Legacy run ghi 0 attempts;
giá trị cũ được giữ nguyên, nhưng entry failure phải tính attempt trong mọi batch
mới. Ba lỗi entry chưa rõ mode và thư mục reasoning không bị gán thành Coop.
[Inventory](../artifacts/5d5_coop_scope_review_20261019/historical_coop_inventory.json),
[phân loại bổ sung](../artifacts/5d5_coop_scope_review_20261019/inventory_review.json).

[Sửa chờ animation ngày 12/10](../../bu_win_postmatch_animation_20261012.md) đã có
bằng chứng nhận thưởng muộn trong 4 trận của `abf…`: hai lần Đồng ý ổn định ở
32.609s và 33.062s. Phiên này sau đó dừng do solo Sword-risk guard chặn
`BU_WIN_FEED_BOSS`. [Sửa guard ngày 13/10](../../bu_win_no_safe_move_20261013.md)
đã có replay/actual-controller fake I/O; các log trên không chứng minh live sau
bản sửa đó. Không tìm thấy current controlled Coop cohort trong phạm vi log đã rà.

## Vì sao chưa bật suy luận Coop

| Điều kiện | Bằng chứng hiện tại | Kết luận |
|---|---|---|
| Giữ mục tiêu chừa Kiếm cho boss | Planner offline dùng `FEED_BOSS_SWORD_AND_TURNOVER`, Sword-opportunity/turnover proxy; test HP1 và HP100 không đảo mục tiêu thành solo survival | Có software/proxy evidence; không là dự báo team WIN |
| Snapshot cho Coop | `snapshot_from_state` hiện tạo self/boss observations; chưa xuất teammate/turn-order/team-result context được nghiệm thu cho planner | Không dùng snapshot Solo làm Coop model |
| Authority và timing | `OperationalPilotSession` bắt buộc game_mode SOLO; capability allowlist không có bu_win; chưa có Coop-specific accepted authority/calibration | Không dùng timing, cost hoặc loadout witness của Solo để mở Coop |
| Shadow | `RunShadowSession.prepare` trả UNSUPPORTED trước adapter/worker factory khi profile bu_win | Giữ chốt hiện có |
| Quyền lượt, chết local, chờ team, nhận thưởng | Baseline có implementation/test và một phần log lịch sử; chưa có current D5 clean baseline batch | BASELINE_LIVE_PENDING |
| Ghép proposal vào guard hiện có | Miễn Sword-risk của BASIC chỉ dành exact `BU_WIN_FEED_BOSS` SWAP có move; không tự áp cho nhánh reasoning chung | Không mở allowlist để né guard hoặc làm sai objective |

Nguồn đã đối chiếu: [shadow gate](../../../src/pokiguard_v2/reasoning_settings.py:109),
[selection capability](../../../src/pokiguard_v2/reasoning_selection.py:88),
[SOLO launch gate](../../../src/pokiguard_v2/reasoning_operational.py:465),
[snapshot](../../../src/pokiguard_v2/reasoning_pilot.py:33),
[team proxy](../../../src/pokiguard_v2/reasoning_planner.py:360),
[regression Bú win](../../../tests/test_bu_win_no_safe_move.py:32).
Code hashes được pin trong offline review. Không suy rằng raw GameState hoàn toàn
không có đồng đội; giới hạn ở đây là contract/snapshot/authority suy luận hiện dùng.

Một batch chơi BASIC mới chỉ có thể bổ sung baseline evidence; nó không tự giải
quyết thiếu contract Coop của planner. Vì essential context và authority chưa
accepted, mục 6 cho phép đóng CLOSED_BASELINE_ONLY; không cần mở game để hoàn tất
**việc đóng có điều kiện này**. Muốn nghiệm thu REASONING Coop về sau phải mở lại
phạm vi có chủ đích, không coi đó là phần đã pass của Phase 5.

## Kiểm chứng và bảo toàn

**105 tests PASS trong 52.306s**, chạy các module có sẵn:

- `tests.test_bu_win`, `tests.test_bu_win_guest_room`, `tests.test_bu_win_runtime_fix`.
- `tests.test_bu_win_no_safe_move`, `tests.test_reasoning_settings`, `tests.test_reasoning_planner`.

Phạm vi gồm ready-toggle/guest opening, local-death/team wait, bàn lỗi 4/7,
Sword-risk exception đúng nhánh, controller với fake normal input/ACK,
freshness/turn/deadline/Stop vẫn chặn input, config Bú win hợp lệ dù shadow
unsupported, không tạo Coop shadow worker, và team objective không bị solo
survival hoặc solo damage skill chi phối. [Test log](../artifacts/5d5_coop_scope_review_20261019/tests.log).
Không dùng fake I/O như bằng chứng thao tác hoặc thắng trong game thật.

337 Python files không đổi; preferences thường và 5 file bằng chứng parent
giữ SHA. Kiểm thêm 26 cặp raw D4 original/archive và 41 file log Bú win lịch sử
được giữ riêng. Native D4 vẫn source `f04e452…`; current sau PASS fix vẫn
`aeab13c…`, không gán lại dữ liệu lịch sử cho source mới.

Không thay flow, reader/capture order, solver/BASIC, executor/QTE, ACK/pending,
farm/room/re-entry, Start/Stop hoặc logging runtime. Không tạo production request,
claim hay worker Coop. Native overhead/CPU/RAM và current Coop critical counters
**NOT_MEASURED**, không ghi bằng 0 dựa trên việc chưa live. Không build, version
bump, commit/push/tag/release; không đụng dữ liệu game hoặc workspace tham chiếu.

[Audit](../artifacts/5d5_coop_scope_review_20261019/offline_review.json),
[gate](../artifacts/5d5_coop_scope_review_20261019/gate_decision.json),
[manifest log gốc](../artifacts/5d5_coop_scope_review_20261019/historical_raw_manifest.json).
Chạy lại file-only audit bằng `python -B docs/phase5/artifacts/5d5_coop_scope_review_20261019/audit.py`.

## Gate và bàn giao

| Gate | Trạng thái |
|---|---|
| Không suy Coop accepted từ Solo | SATISFIED |
| Giữ BASIC, không mở capability thiếu essential evidence | SATISFIED |
| Team intent riêng, không đảo dấu solo survival để quảng bá reasoning | SATISFIED trong review/test; native reasoning unsupported |
| Core/runtime regression do bước này | Không đổi code; focused regression PASS |
| Current Coop baseline live | PENDING, chưa chạy trong 5D.5 |
| Coop reasoning/shadow live | UNSUPPORTED / NOT EXECUTED |
| Conditional closure theo mục 6 | **CLOSED_BASELINE_ONLY** |

STATUS, README, ROUTER, PROMPT_INDEX, ROADMAP và capability manifest đã cập nhật.
**Exactly one next: [5E.1](../prompts/5E1_BOUNDED_GAMEPLAY_COMPARISON.md), chưa thực thi.**
E1 chỉ được dùng profile/cohort Solo có technical acceptance tương ứng và phải
freeze comparison protocol/source/config trước live; không cộng log Coop này vào
denominator hoặc claim efficacy. Bú win BASIC tiếp tục là nhánh đang giữ nguyên,
các lỗi người dùng báo có thể xử lý song song theo scope cụ thể.

[Deferred Coop runbook](../artifacts/5d5_coop_scope_review_20261019/RUNBOOK.md) không
là activation. Dừng tại 5D.5; không sinh thêm P hoặc tự chạy bước kế tiếp.
