# Opus — Kế hoạch hợp nhất nâng cấp AI Suy luận match-3 (canonical)

> Tác giả: **Opus** (Devin). Cập nhật 23/11/2026 (Asia/Saigon).
> Đây là **plan canonical**, hợp nhất bản Opus đầu tiên (cùng file này) với plan SWE-2
> [`docs/swe-2/swe-3-reasoning-upgrade.md`](../swe-2/swe-3-reasoning-upgrade.md) sau khi đối
> chiếu code hiện tại. File SWE-2 giữ nguyên làm tham khảo, không bị sửa.
> Trạng thái: **ĐỀ XUẤT — chưa triển khai.** Không đổi runtime, không chạy live, không
> build/version/commit/push. Mỗi phase dừng ở điểm dừng ghi rõ và chờ user duyệt.

## 0. Thứ bậc nguồn

[AGENTS.md](../../AGENTS.md) → [DECISIONS.md](../DECISIONS.md) →
[CURRENT_STATE.md](../CURRENT_STATE.md) → plan này → báo cáo từng phase. Plan không ghi đè
DECISIONS. Luật chơi mới (vd hoãn tiến hóa, Hút theo hiệu lực chặn skill) chỉ có hiệu lực sau
khi user duyệt nguyên văn và được ghi vào DECISIONS.md (Agent Non-Invention Rule).

## 1. Mục tiêu và chỉ đạo đã chốt

### 1.1 Yêu cầu gốc (23/11/2026)

1. Suy luận thành AI match-3 thực thụ: đánh giá tình hình nước đi của **cả ta và boss**.
2. Boss từ **Đảo Cổ Đại** trở đi có skill riêng, tự bơm Mana/Nộ: cân nhắc Hút khi Hút thực sự
   làm boss khó dùng skill hơn; khi Hút không đổi được khả năng đó thì đi nước khác.
3. Chọn nước chính xác hơn, ra skill khi cần, quyết định tiến hóa ngay hay chưa.
4. Học từ dữ liệu **do owner kiểm soát**; người chơi khác chỉ gửi log; AI không tự học khi chạy.

### 1.2 Quyết định đã chốt

| # | Nội dung | Quyết định |
|---|---|---|
| Q1 | Kênh gửi log | Xuất file thủ công trước; upload tự động sau khi pipeline ổn định |
| Q2 | Giao model | Phát hành **cùng bản tool**; không kênh model riêng |
| Q3 | Thứ tự rollout | Lõi chung cho mọi lối chơi; live rollout theo nhóm, ưu tiên **G4/Galaxy** rồi **Mega/Chịu đấm ăn xôi** |
| Q4 | Nhớ trong trận | **Không**: mỗi quyết định chỉ dùng trạng thái hiện tại + tri thức offline đã đóng băng |
| Q5 | Kiến trúc | **Một lõi suy luận chung**: mở rộng `reasoning_common_*`, tận dụng worker, replay và kiểm đề xuất; không tạo engine thứ hai |
| Q6 | Học | Hai tầng: Tier 1 hiệu chỉnh trọng số/model nhỏ trước; Tier 2 ranker/value model chỉ khi đủ bằng chứng |
| Q7 | Kiểm soát model | Owner duyệt; version/scope/provenance rõ; pin theo phiên; kiểm chữ ký; audit runtime không import/gọi trainer |
| Q8 | UI | Tab chính chọn Lối chơi và Cơ bản/Suy luận như hiện tại; tab AI chỉ chứa cài đặt liên quan |
| Q9 | Coop/Bú win | Thuộc phạm vi nhưng có mục tiêu đội và nghiệm thu riêng, rollout sau cùng |
| Q10 | Hút | Giá trị chặn = chênh lệch khả năng boss dùng skill giữa có Hút và không Hút, gồm tự bơm; không mặc định "trên ngưỡng thì vô ích"; thiếu chứng cứ = UNKNOWN; không tự gán xác suất |
| Q11 | Runtime | Đo ngân sách thực tế trước khi đổi runtime; giữ owner, deadline, PASS, QTE, ACK, BASIC fallback |
| Q12 | Dừng tool | Thiếu model hoặc không có nước an toàn **không** được tạo lý do dừng mới |
| Q13 | Sau trận | `POSTMATCH_UI_AMBIGUOUS` không còn là bug/blocker của plan này: ảnh thua đã được EXE 1.3.7 nhận đúng, lần dừng cũ chưa chứng minh là bug. Giữ nguyên cơ chế kiểm tra sau trận trong code |

Hệ quả Q4: lõi là hàm thuần của snapshot (deterministic). Context BASIC sẵn có
(`SkillRushMatchContext`, ước lượng chu kỳ G1) giữ hành vi cũ; Suy luận không thêm bộ nhớ trận.

### 1.3 Thành công đo được

- Mỗi lượt xét mọi hành động hợp lệ (112 cặp swap, skill, chưởng, tiến hóa, PASS khi owner cho
  phép), mô phỏng nước ta → cascade đã biết → kịch bản refill → lượt boss (tự bơm, skill/hồi,
  nước boss) → phản ứng tốt nhất của ta, rồi chấm thế trận nhiều lượt theo mục tiêu lối chơi.
- Thắng hoặc hòa BASIC trên bench **cùng bàn** theo KPI đăng ký trước; không thoái lui an toàn.
- Mỗi quyết định có nhãn tình huống + lý do tiếng Việt + phần UNKNOWN.
- Không hứa thắng mọi boss hay tối ưu toàn cục.

### 1.4 Ngoài phạm vi

WriteProcessMemory, inject, hook, remote thread, patch game, gọi method gameplay, `RequestSwap`,
`MatchService.SendMove`, `enableAutoMove`, can thiệp packet, sửa HP/damage/reward; học online/RL;
policy network thay chooser; đổi BASIC hoặc mặc định BASIC.

## 2. Bất biến (hard)

- `pc`/`PokiguardAuto` chỉ đọc; bộ nhớ chỉ đọc; offset/RVA mới phải có bằng chứng Cpp2IL ghi ở
  `docs/il2cpp_symbols.md`; chưa chứng minh = UNKNOWN; không địa chỉ tuyệt đối.
- Flow giữ nguyên: thứ tự poll/capture, provider ownership, executor/QTE/ACK/pending/recovery,
  lease, Stop. Không thêm read/capture để chờ AI.
- BASIC tính trước và luôn là ứng viên; lỗi/hết giờ/thiếu model/không hỗ trợ → BASIC còn hợp lệ
  trước dispatch; sau input không gửi nước thay thế.
- Capability gate (ownership/cost/cooldown/actionability/turn/PASS/timer sàn 1s) độc lập utility.
- UNKNOWN ≠ 0 và không là bằng chứng an toàn. Xác suất chỉ được dùng khi là tần suất thực
  nghiệm có số mẫu trong model đã duyệt; còn lại dùng kịch bản biên hoặc UNKNOWN.
- Suy luận không thêm lý do dừng tool; fail-closed sẵn có của BASIC/state giữ nguyên.
- Runtime không học, không ghi model, không import trainer.
- File tạm ở `temp/reasoning/`; test dùng `tests.reasoning_test_paths.reasoning_temp_root()`.

## 3. Đối chiếu code hiện tại (baseline 23/11/2026)

### 3.1 Source

| Mục | Giá trị |
|---|---|
| Commit | `main` @ `1ae8cb56f4a2…` (v1.3.7, đã push); game profile B17 |
| Fingerprint phát hành | `bf0642d7…` (513 Python, [v1.3.7 report](../v1.3.7_release_report.md)) |
| Quy mô | 175 `.py` trong `src/`, 223 file test; `scripts/ci_offline.py` 24 module, 429 test PASS |
| Deps client | capstone, pefile, cryptography → inference runtime pure Python |
| Ký số sẵn có | Ed25519: updater `PokiguardToolV2.application-update.v1`, catalog `PokiguardV2.compatibility.catalog.v1` |

### 3.2 Lõi suy luận hiện có (đã kiểm trong code)

| Module | Hiện trạng | Hệ quả cho plan |
|---|---|---|
| `reasoning_common_problem.py` | `PROFILES` 8 style (chưa có `galaxy_shadow_sword`); `EffectChoice` chỉ `pet_skill/cast/pass` | Schema v2 cần G4 và family `evolve` |
| `reasoning_common_planner.py` | Feature F/R/D/P/H/B/T/X/L/E, `WEIGHTS` theo style (Bú win dùng B); `CommonLimits` 4000 ms/8 root/32 kịch bản/18000 node; đổi nước khi `best.low − base.high ≥ 0,05`; `_future_setup` ≈1,5 ply; BASIC chọn EVOLVE → `COMMON_BASELINE_EXISTING_ACTION_OWNER` | Mở rộng thành 2-ply + đánh giá nhiều lượt trong cùng cap |
| `reasoning_common_tactics.py` | Hút = theft (`_drain_fills`: tài nguyên boss × mức đầy của ta); `_reply_risk` có Hút của boss vào ta | Thêm denial có/không Hút |
| `boss_threat.py` | Cờ chung tự bơm/cast/hồi; `current_boss_scope=UNKNOWN` | Nối boss identity + registry |
| `reasoning_common_selection.py` | Worker cách ly, host tính lại `plan_common` và đòi tái lập (kiểm đề xuất), ROOT/FRESH/FINAL; `apply_common_action` chỉ ánh xạ `swap/pet_skill/pass`; `galaxy_strategy_allows` chỉ cho SWAP→SWAP | Giữ làm đường chính; cần phân xử EVOLVE/CAST/giữ skill (U6a) |
| `reasoning_common_native.py::load_common_authority` | Chặn bản đóng gói (`UI_REASONING_COMMON_PACKAGE_PENDING`), chặn Coop (`UI_REASONING_TEAM_MODEL_PENDING`), profile `common.json` gắn source/host/game EXE | Khách dùng EXE chưa chạy được worker → cần admission mới dựa số đo |
| `reasoning_galaxy.py` + `basic_policy.py` | G4/Galaxy chạy đồng bộ trong policy, ngân sách 1..250 ms (validate ở `reasoning_swap_timing.py`) | Đường Suy luận duy nhất chạy trong EXE hiện tại; sẽ chuyển dần sang lõi chung |
| Capture/replay | `reasoning_common_capture.py`, `tools/extract_common_snapshots.py`, `compare_same_state_decisions.py`, `replay_reasoning.py` | Nền cho bench cùng bàn |
| Evidence | `combat_outcome_evidence.py` có SWAP/STAT_CHANGE/DESTROY, chưa SPAWN; `combat_player_context.py` whitelist chưa có cooldown/stack/drop/pity | Thu thêm từ JSON đã đọc |
| Identity | `ParticipantState` không có petId; boss ID đã pin trong config (`normalized_boss_id`); đảo/level qua `chinh_phuc_map.read_chinh_phuc_target_metadata` | Key boss = petId đã pin + đảo; stats fingerprint chỉ kiểm chéo |
| Research | `damage_*` + dataset protocol chống leakage, chưa deploy | Tái dùng protocol |

### 3.3 Dữ liệu và hiệu năng

- `logs/farm_runs/`: 401 `combat.jsonl` (~106 MB, chủ yếu Demon build cũ); `docs/**/artifacts/`
  (local): 163 `combat.jsonl` (~194 MB, B15–B17 có typed outcome, SWAP op, khoảng boss).
- Boss policy: 13 khoảng B17, 3/3 cơ hội Kiếm boss chọn max-Sword — chưa đủ kết luận chung.
- Refill do server sinh, không đoán trước được ([spawn research](../../research/spawn/spawn_research.md)).
- Micro-benchmark tổng hợp: `_resolve_known_reply` ~16,7 µs/lần; `evaluate_all_moves` ~35 ms/bàn.
  Chưa phải số native; U1 đo có hệ thống.

## 4. Kiến trúc hợp nhất

### 4.1 Một lõi, nhiều cách host

```text
GameState (read-only, poll cũ) ─► BASIC incumbent (như cũ)
          │
          ▼
CommonProblem v2 = board + facts hai bên + boss identity + effects hợp lệ (+ evolve)
          │        + model pack đã pin cho phiên
          ▼
Situation (nhãn + chứng cứ) ─► plan_common v2: root → kịch bản refill → lượt boss
          (tự bơm/skill/hồi + nước boss) → phản ứng tốt nhất của ta → chấm thế trận nhiều lượt
          ▼
Đề xuất + lý do ─► host kiểm lại (tái lập) ─► capability gate ─► preflight/executor/QTE/ACK cũ
          └─ lỗi/hết giờ/thiếu model ─► BASIC
```

- Host: worker cách ly hiện có là đường chính. Đường đồng bộ G4/Galaxy giữ nguyên tới khi lõi
  chung đạt bench cùng bàn của style đó, rồi gọi lõi chung (không giữ hai logic song song lâu dài).
- Admission cho bản đóng gói/khách chỉ thiết kế sau khi đo ngân sách (U1→U8).

### 4.2 Thành phần mới gắn vào lõi

| Module | Nguồn ý tưởng | Vai trò |
|---|---|---|
| `boss_knowledge.py` | SWE-2 + Opus | Registry theo boss petId/đảo, provenance từng field, fallback theo tầng đảo |
| `reasoning_situation.py` | SWE-2 | Nhãn `BOSS_SKILL_LIKELY`, `DRAIN_WORTH`, `EVOLVE_WINDOW`, `SKILL_NOW`, `HOLD_SKILL`, `SURVIVAL_RISK`, `BOSS_REPLY_DANGER`, `RESOURCE_RACE` + lý do tiếng Việt |
| `reasoning_effects.py` | Opus | Viên/skill → Mana/Nộ/Khiên/Máu/Hút/sát thương dạng khoảng, có abstain |
| `reasoning_refill.py` | Opus | Kịch bản refill seed theo snapshot; trước khi có dữ liệu chỉ là biên/hazard, không phân phối tự đặt |
| Denial trong `reasoning_common_tactics.py` | Cả hai, đã sửa | Có/không Hút (§4.3) |
| `_future_continuation` trong planner | SWE-2 + Opus | 2-ply có ngân sách + đánh giá đua HP/tài nguyên nhiều lượt |
| `reasoning_model.py` | SWE-2 (brain loader) | Nạp model pack, kiểm chữ ký/scope/version, pin theo FarmRun |
| `tools/reasoning_lab/` | SWE-2 (learning/) | Trainer chỉ cho owner, nằm ngoài package runtime |

### 4.3 Hút: định nghĩa bắt buộc

1. Với mỗi nhánh X (ứng viên có Hút hoặc không), dựng khoảng tài nguyên boss trước khi boss
   quyết định skill, theo từng loại tài nguyên (Mana, Nộ):
   - sau nước ta: `A_X = max(0, M − h_X)`, với `h_X ∈ [h_min, h_max]` (0 nếu X không Hút);
   - trước skill: `R_X = min(cap, A_X + c + g_X)`, với tự bơm `c ∈ [c_min, c_max]` và viên boss
     ăn được trên bàn sau X là `g_X ∈ [g_min, g_max]` (riêng từng nhánh vì bàn khác nhau);
   - `R_min = min(cap, max(0, M − h_max) + c_min + g_min)`,
     `R_max = min(cap, max(0, M − h_min) + c_max + g_max)`.
   Thứ tự Hút/tự bơm/ăn viên/chạm trần chưa biết → lấy biên bao mọi thứ tự; nếu thứ tự làm đổi
   kết luận gần sàn/trần thì xếp `PARTIAL` hoặc `UNKNOWN`.
2. So với ngưỡng `T ∈ [T_min, T_max]` từ registry: `READY` nếu `R_min ≥ T_max`; `NOT_READY` nếu
   `R_max < T_min`; còn lại `PARTIAL`; thiếu dữ kiện → `UNKNOWN`. Skill cần cả Mana và Nộ thì
   gộp theo AND; Hút lấy Mana hay Nộ chưa rõ → mỗi loại một kịch bản.
3. **Giá trị chặn = chênh lệch** giữa nhánh có Hút và nhánh không Hút tốt nhất:
   - `READY → NOT_READY` → chặn chắc chắn trong mô hình;
   - `READY → PARTIAL` hoặc `PARTIAL → NOT_READY` → chặn một phần, ghi khoảng;
   - không đổi lượt tới nhưng làm chậm lần cast sau (số lượt tới khi đủ ngưỡng) → có giá trị nếu
     biết lượng tiêu khi cast; không biết → UNKNOWN;
   - thiếu ngưỡng/tự bơm/lượng Hút → UNKNOWN, không cộng, không trừ.
4. Boss đang trên ngưỡng **không** mặc định Hút vô ích: Hút vẫn có thể kéo xuống dưới ngưỡng.
5. Theft hiện có giữ làm thành phần riêng; rủi ro boss Hút tài nguyên ta tính đối xứng.
6. Không có xác suất nếu model pack chưa có tần suất thực nghiệm có số mẫu.

### 4.4 Model pack và kiểm soát của owner

- Đặt tại `src/pokiguard_v2/resources/reasoning_model/` (pack JSON + chữ ký + model card),
  build/ký/phát hành cùng tool qua pipeline hiện có (Q2). Không kênh tải riêng.
- Manifest `pokiguard.reasoning.model_pack.v1`: `pack_id`, version, ngày, `engine_compat`,
  scope (game build, style, boss/đảo), `dataset_manifest_sha256`, `trainer_source_sha256`,
  metrics, phê duyệt owner (ngày, SHA báo cáo duyệt).
- Chữ ký Ed25519 domain riêng `PokiguardToolV2.reasoning-model.v1`; khóa riêng ngoài repo
  (chỉ owner); public key pin trong resources.
- Runtime: kiểm chữ ký/schema/scope/compat khi Start; pin `pack_id`+SHA cho cả FarmRun, ghi vào
  run metadata và từng quyết định. Không hợp lệ/không có → trọng số cấu trúc hiện tại, hiện lý
  do, **không dừng tool**.
- Thử model ứng viên: chỉ chạy source trên máy owner; bản đóng gói chỉ nạp pack đã bundle.
- Audit không tự học: test import-graph/AST chứng minh runtime không import `tools/reasoning_lab`
  hay gọi API fit; không đường ghi model; packaging test chứng minh trainer không vào bundle.

### 4.5 Hai tầng học

- **Tier 1:** hiệu chỉnh trọng số theo style (miền giới hạn), entry boss (ngưỡng, tự bơm, hồi,
  trigger), lượng Hút theo stealType, quantile hiệu ứng/sát thương, prior refill, logit nhỏ cho
  nước boss. Tất cả có khoảng, số mẫu, abstain.
- **Tier 2:** learned ranker/value model làm leaf evaluator/tie-break, chỉ mở khi Tier 1 đã phát
  hành, dữ liệu đạt ngưỡng ghi trước, và thắng reference + guarded trên holdout đóng băng.
- Không bao giờ: RL online, runtime tự sửa, policy network thay chooser.

### 4.6 Vòng dữ liệu

```text
Tool người chơi ─(bấm xuất, đồng ý)─► gói .zip ẩn danh ─(gửi thủ công; sau này tự động)─► Inbox
Inbox ─► tools/reasoning_lab: ingest/cách ly/loại trùng ─► chuẩn hóa ─► dataset bất biến
      ─► Tier 1/2 offline ─► holdout + bench cùng bàn ─► báo cáo ─► OWNER DUYỆT
      ─► ký pack ─► commit ─► build/release tool ─► người chơi cập nhật
```

### 4.7 UI

- Tab chính: Lối chơi + Cơ bản/Suy luận (giữ nguyên).
- Tab AI: ngân sách, chẩn đoán/shadow, phiên bản model (chỉ đọc), nút xuất dữ liệu đóng góp.
  Không có bộ chọn AI/engine hay toggle "nâng cao".

## 5. Quy ước phase, live và chất lượng

- Phase `U0…U17`. Mỗi phase: phụ thuộc, deliverable, tiêu chí đo được, điểm dừng. Báo cáo
  `docs/opus/reports/Ux_report.md` theo [HANDOFF_TEMPLATE](../phase5/HANDOFF_TEMPLATE.md);
  `docs/opus/STATUS.md` giữ con trỏ. Không tự chạy phase sau.
- **Live chỉ khi có câu hỏi bằng chứng mới mà offline không trả lời được.** Manifest ghi trước:
  câu hỏi, vì sao offline không đủ, source/pack SHA, style/pet/đồ/boss/account alias, cap, thứ
  tự, stop rule, KPI ([5A.3](../phase5/specs/5a3_bounded_live_protocols.md)).
- Không lặp batch cùng source/cohort/câu hỏi. Đổi source không đụng phạm vi đã live → dùng parity
  offline, không live lại.
- User tự vào phòng và bấm Start. Mỗi lần vào trận tiêu cap kể cả lỗi; không chạy bù; đổi
  source/pack/config giữa batch → dừng, không gộp. Dừng ngay khi vi phạm an toàn input.
- Mức live: L0 capture (1–2 BASIC) · L1 chức năng (1 BASIC + 1–2 R) · L2 áp lực boss Đảo Cổ
  Đại+ (≤3 R) · L3 so sánh (10/arm, tối đa 20) · L4 đóng gói (1 BASIC + 1 R) · LC thu dữ liệu
  BASIC (chỉ khi thiếu độ phủ đã ghi trước).
- Chất lượng: so cùng snapshot là chính (lợi thế cơ học có điều kiện / đánh đổi / thiếu dữ
  liệu); WIN/số lượt chỉ là KPI cohort, không là nhãn từng nước; không gộp cohort.

## 6. Lộ trình phase

```text
U0 ─► U1 ─► U2 ─► U3 ───────────────┐
       │     └──────► U4 ─► U5 ─► U6  │
       │              └──► U7         │
       └────────────► U8 (cần U5,U7) ─► U10 G4/Galaxy ─► U11 Mega/HT7 ─► U12 Demon/khác ─► U13 Coop
                                         ▲
                              U9 Tier 1 ─┘ (cần U3,U5,U7)
U14 so sánh (theo nhóm) ─► U15 phát hành ─► U16 Tier 2 (khi đủ bằng chứng) ─► U17 vòng định kỳ
```

### U0 — Chốt tài liệu và quyết định (docs)
- **Phụ thuộc:** không.
- **Deliverable:** plan này; `docs/opus/STATUS.md`; `docs/opus/knowledge_audit.md` (bảng
  KNOWN/UNKNOWN theo năng lực ↔ module ↔ bằng chứng); bản nháp mục DECISIONS (Q1–Q13); catalog
  tình huống v2 (Phụ lục B).
- **Tiêu chí:** 0 file runtime đổi; user duyệt plan + catalog.
- **Dừng:** D-U0.

### U1 — Bench cùng bàn và đo ngân sách thực tế (offline)
- **Phụ thuộc:** U0.
- **Deliverable:** corpus snapshot trước nước từ log hiện có (tái dùng `extract_common_snapshots.py`,
  `decode_snapshot_event`, state evidence B17) + manifest SHA; runner chạy BASIC/R1/G4 trên corpus
  (tái dùng `compare_same_state_decisions.py`, `replay_reasoning.py`); bảng KPI baseline; bảng
  thời gian: `turn_time_remaining_seconds` lúc quyết định, H/I từ `reasoning.swap_timing`, worker
  round-trip từ receipt, latency `plan_common` theo bàn, node usage; micro-benchmark 1–2 máy.
- **Tiêu chí:** corpus chạy 2 lần cùng SHA; runner deterministic 100%; p50/p95/p99/max có số mẫu;
  đề xuất envelope ngân sách với công thức reserve; 0 file runtime đổi.
- **Dừng:** D-U1 (KPI + envelope).

### U2 — Thu dữ liệu v2 (chỉ evidence)
- **Phụ thuộc:** U1.
- **Deliverable:** projection `SPAWN/FALL/DESTROY` có thứ tự (≤128 op, ≤32 KiB); key mới trong
  player context (`skillCooldownCardId`, `skillCooldownLeft`, `cardCooldownLeft`, `skillStacks`,
  `skillStackMax`, `skillStackPct`, `skillPhase*`, `dotDropPct`, `luckyDotTag`, `luckPct`,
  `fusionPityFails`, `fusionPityPercent`, `fusionLastAttemptTurn`, `level`) khi có mặt, thiếu =
  ABSENT; boss identity (petId đã pin, tên, đảo, level) vào run metadata và facts; normalizer sự
  kiện boss (`BOSS_SKILL_SUSPECTED` + bằng chứng thô); báo cáo reverse B17 (Phụ lục D).
- **Tiêu chí:** 0 RPM/scan/capture mới (đếm bằng fake memory); parity quyết định/trace 100% trên
  corpus U1 + 216 ca BASIC + 243 tình huống style cũ; lỗi projection chỉ mất evidence.
- **Live L0:** cap 2 BASIC (1 boss thường + 1 boss Đảo Cổ Đại+). Câu hỏi: trường mới có xuất hiện
  đúng trong JSON thật không.
- **Dừng:** D-U2 (gồm quyết định có cần đọc bộ nhớ mới không; mặc định không).

### U3 — Xuất/nhập dữ liệu đóng góp (thủ công)
- **Phụ thuộc:** U2.
- **Deliverable:** nút xuất trong tab AI (chỉ khi controller rảnh) tạo
  `pokiguard.reasoning.contribution.v1` (manifest, SHA từng file, contributor ID ngẫu nhiên, đồng
  ý); ẩn danh (không ảnh, hash tên, bỏ đường dẫn cá nhân, không preferences/khóa); tool owner
  `ingest/normalize/audit/freeze` trong `tools/reasoning_lab/`; kho ngoài repo.
- **Tiêu chí:** roundtrip trên log owner + mẫu log ngoài; quét PII 0 phát hiện; gói hỏng/giả bị
  cách ly 100% không làm hỏng kho; split theo [DAMAGE_DATASET_PROTOCOL](../phase5/DAMAGE_DATASET_PROTOCOL_20261121.md); không code mạng.
- **Live:** không cần trận; owner xuất từ run thật rồi nhập Lab.
- **Dừng:** D-U3 (văn bản đồng ý, nội dung gói, nơi lưu kho).

### U4 — Lõi chung v2: schema, boss knowledge, situation (offline, mặc định tắt)
- **Phụ thuộc:** U1 (U2 nếu dùng identity mới).
- **Deliverable:** `common_problem.v2` đọc được v1; thêm `galaxy_shadow_sword`; facts boss
  identity; `boss_knowledge.py` (entry chung theo khai báo user, không số tự bịa); nhãn situation
  + lý do tiếng Việt.
- **Tiêu chí:** tính năng mới tắt → quyết định/điểm trùng 100% với v1 trên corpus; nhãn có chứng
  cứ hoặc UNKNOWN; ci_offline + test liên quan PASS.
- **Dừng:** gate kỹ thuật (báo cáo), không cần live.

### U5 — Hút có/không, hiệu ứng, refill, nhiều lượt (offline)
- **Phụ thuộc:** U4.
- **Deliverable:** denial §4.3; `reasoning_effects.py`; `reasoning_refill.py` (biên/hazard,
  chưa phân phối); `_future_continuation` 2-ply trong cap hiện có, hết ngân sách dùng kết quả đã
  hoàn tất; chấm đua HP/tài nguyên nhiều lượt; kiểm lethal hai chiều với abstain.
- **Tiêu chí:** test Hút đủ các lớp: dưới ngưỡng giữ được dưới; trên ngưỡng nhưng Hút kéo xuống;
  chặn một phần (vd 550/500, Hút 100, tự bơm 0–100 → `PARTIAL`); vẫn đủ ngưỡng ở mọi kịch bản;
  chậm lần cast sau; sàn 0; trần tài nguyên; viên boss ăn khác nhau giữa hai nhánh; ngưỡng dạng
  khoảng; thứ tự đổi kết luận → `PARTIAL/UNKNOWN`; thiếu dữ kiện → UNKNOWN. Không có số xác suất
  khi pack chưa có tần suất. Catalog tình huống PASS; p95 latency trong envelope U1; level dở
  không được chọn; tắt → parity 100%.
- **Dừng:** D-U5 — user xem mẫu so cùng bàn (gồm 9 bàn Raijin, bàn G4/Mega).

### U6 — Skill ngay/giữ và thời điểm tiến hóa (offline)

Khoảng trống cho tính năng sắp làm, không phải bug của 1.3.7: `plan_common` giữ nguyên
incumbent khi BASIC chọn EVOLVE; `apply_common_action` chỉ ánh xạ `swap/pet_skill/pass`;
`galaxy_strategy_allows` chỉ cho đổi SWAP→SWAP nên chặn "ra skill → giữ skill".

**U6a — Đường phân xử và kiểm quyền tới host**
- **Phụ thuộc:** U4.
- **Deliverable:**
  - Quyết định hai phần: phần chức năng (`EVOLVE_NOW` / `DEFER_EVOLVE` / không áp dụng) và phần
    tiêu lượt (`SWAP` / `CAST` / `PET_SKILL` / `PASS`).
  - Mở rộng `apply_common_action`: ánh xạ `evolve` → `PolicyAction.EVOLVE` qua owner tiến hóa
    hiện có, `cast` → `PolicyAction.CAST`; ca hoãn tiến hóa thay incumbent EVOLVE bằng hành động
    tiêu lượt do lõi chọn, kèm reason code.
  - Bảng chuyển `(incumbent BASIC → đề xuất)` theo từng lối chơi, mỗi cặp ghi bằng chứng bắt buộc
    (vd `PET_SKILL → SWAP` cho "giữ skill", `EVOLVE → SWAP` cho "hoãn tiến hóa"). Cặp không có
    trong bảng → giữ BASIC. `galaxy_strategy_allows` chỉ được nới qua bảng này, không nới ngầm.
  - Giữ: EVOLVE không tiêu lượt; sau kết quả EVOLVE đọc lại toàn bộ state rồi quyết định hành động
    tiêu lượt mới; ở 2/3 idle vẫn bắt buộc SWAP/CAST; gate Fusion (cost runtime, actionable, chưa
    dùng, chưa khóa lượt, sàn timer) giữ nguyên; source-turn sau PET_SKILL và QTE giữ nguyên.
  - Host tính lại phải tái lập cả hai phần quyết định; ROOT/FRESH/FINAL và final preflight cũ áp
    cho mọi đề xuất mới.
- **Tiêu chí:** test phủ 100% cặp trong bảng và ca ngoài bảng → BASIC; family không có ánh xạ →
  BASIC có lý do; tắt Suy luận → BASIC byte-exact (gồm Bước 1 tiến hóa); fault injection → BASIC.
- **Dừng:** gate kỹ thuật (báo cáo).

**U6b — Logic thời điểm skill và tiến hóa**
- **Phụ thuộc:** U5, U6a + mục DECISIONS về hoãn tiến hóa/giữ skill được duyệt.
- **Deliverable:** family `evolve` trong EffectChoice v2; so "bắn skill ngay" vs "giữ" và "tiến
  hóa ngay" vs "hoãn" bằng đánh giá nhiều lượt; chi phí luôn từ runtime; `fusionPityPercent` chỉ
  dùng khi U2 xác minh.
- **Tiêu chí:** mọi đề xuất đi qua bảng chuyển U6a; không vượt owner gate; same-state review các
  ca hoãn tiến hóa/giữ skill; parity khi tắt.
- **Dừng:** D-U6.

### U7 — Model pack, chữ ký, pin, audit không tự học (offline)
- **Phụ thuộc:** U4.
- **Deliverable:** `reasoning_model.py`; pack v0 = trọng số cấu trúc hiện tại + khai báo user (đã
  ký); tool ký của owner; hiện phiên bản ở tab AI; test packaging chứa pack, không chứa trainer.
- **Tiêu chí:** chữ ký đúng/sai, scope sai, compat sai → đúng hướng; không pack → hành vi hiện tại
  100%; audit import-graph PASS; pack pin không đổi suốt FarmRun.
- **Dừng:** D-U7 (quy trình quản lý khóa owner).

### U8 — Admission và host theo số đo
- **Phụ thuộc:** U1, U5, U7.
- **Deliverable:** phương án admission chọn từ số đo U1 cho bản đóng gói (vd envelope phát hành +
  tự kiểm thời gian trong phiên trước khi cho chọn nước; hoặc lát đồng bộ có giới hạn cho style
  đang đồng bộ); adapter G4/Galaxy gọi lõi chung khi đạt bench. Giữ owner/deadline/PASS/QTE/ACK.
- **Tiêu chí:** fault injection (timeout, worker chết, pack hỏng) 100% → BASIC có lý do; 0 read/
  capture mới; latency trong envelope; 0 lý do dừng mới.
- **Live L1:** nhóm G4/Galaxy 1 BASIC + 1–2 R. Câu hỏi: admission + lõi chạy đúng ngân sách và
  fallback đúng trong lượt thật.
- **Dừng:** D-U8.

### U9 — Tier 1 học (owner, offline)
- **Phụ thuộc:** U3 (dữ liệu), U5, U7.
- **Deliverable:** fit trọng số, entry boss, lượng Hút, quantile hiệu ứng, prior refill, logit nước
  boss; model card; pack v1 ứng viên.
- **Tiêu chí:** mỗi model ≥ prior trên holdout đóng băng, không thì giữ prior/UNKNOWN; poison test
  giữ forecast; không leak; bench cùng bàn pack v1 ≥ pack v0.
- **Live LC:** chỉ khi báo cáo chỉ ra khoảng thiếu cụ thể.
- **Dừng:** D-U9 (owner duyệt pack v1).

### U10 — Rollout nhóm 1: G4/Galaxy
- **Phụ thuộc:** U8 (U9 nếu có pack v1).
- **Live L2:** ≤3 R trên boss Đảo Cổ Đại+ với tiêu chí áp lực ghi trước.
- **Tiêu chí:** 0 vi phạm an toàn; 0 safe stop do AI; mọi fallback có lý do; same-state review
  100% ca khác BASIC.
- **Dừng:** D-U10.

### U11 — Rollout nhóm 2: Mega/Chịu đấm ăn xôi
- **Phụ thuộc:** U6, U8.
- **Live:** L1 rồi L2 cùng quy tắc; thêm tiêu chí PERFECT/QTE không giảm, không bấm skill khi
  không actionable, không vi phạm PASS.
- **Dừng:** D-U11.

### U12 — Rollout nhóm 3–4: Demon; Đơn giản/Cẩn thận/Khủng long
- **Phụ thuộc:** U8. Replay trước; live chỉ cho câu hỏi mới.
- **Dừng:** D-U12.

### U13 — Coop/Bú win
- **Phụ thuộc:** U8 + model đội.
- **Deliverable:** mục tiêu đội (feature B), không biến thành solo-survival; admission Coop riêng
  (hiện bị chặn `UI_REASONING_TEAM_MODEL_PENDING`); baseline Coop live riêng.
- **Dừng:** D-U13 (nghiệm thu riêng).

### U14 — So sánh hiệu quả theo nhóm
- **Phụ thuộc:** nhóm tương ứng đã qua U10–U13.
- **Live L3:** xen kẽ BASIC/R theo manifest; KPI U1; khoảng tin cậy.
- **Tiêu chí:** verdict PROMOTE / INCONCLUSIVE / NO_PROMOTION; BASIC vẫn mặc định.
- **Dừng:** D-U14.

### U15 — Phát hành cùng tool
- **Phụ thuộc:** U14 hoặc quyết định user.
- **Deliverable:** pack đã ký trong resources; version bump khi user yêu cầu; CI; Draft Release;
  user Publish; L4 1 BASIC + 1 R trên ZIP.
- **Dừng:** D-U15.

### U16 — Tier 2 (ranker/value)
- **Phụ thuộc:** U15 đã có Tier 1 + ngưỡng dữ liệu ghi trước.
- **Tiêu chí:** thắng reference + guarded trên holdout đóng băng và same-state review; vẫn trong
  chooser có giải thích.
- **Dừng:** D-U16.

### U17 — Vòng huấn luyện định kỳ và upload tự động
- **Phụ thuộc:** U3, U15.
- **Deliverable:** runbook thu → nhập → audit → freeze → train → so pack hiện hành (không thoái lui)
  → duyệt → release; upload tự động khi user chọn nhà cung cấp (opt-in, chạy nền khi rảnh, không
  giữ khóa ghi chung trong client).
- **Dừng:** chạy trọn một chu kỳ thử; D-U17.

## 7. Giữ / bổ sung / loại bỏ

### 7.1 Từ plan Opus đầu tiên

| | Nội dung | Lý do |
|---|---|---|
| Giữ | Bench cùng bàn, KPI, timing study | Tiêu chí chất lượng đã chốt của dự án |
| Giữ | Thu SPAWN, player context, boss identity; reverse leads B17 | Cần cho refill, skill boss, tiến hóa |
| Giữ | Mô hình hiệu ứng, đánh giá đua HP nhiều lượt, lethal hai chiều | Đánh giá cả ta và boss |
| Giữ | Xuất gói + Lab owner, quy tắc batch live | Q1, kiểm soát của owner |
| Bổ sung | Một lõi chung, model pack có chữ ký/pin/audit, hai tầng học, nhóm Coop, admission theo số đo | Q5–Q11 |
| Loại | Package engine riêng `src/pokiguard_v2/opus/` | Trùng chức năng `reasoning_common_*` |
| Loại | Đường đồng bộ làm mặc định, trần 300 ms đặt trước | Phải đo trước (Q11); worker có kiểm đề xuất mạnh hơn |
| Loại | Xác suất minh họa và "vượt xa ngưỡng → Hút ≈ 0" | Trái Q10 |
| Loại | `POSTMATCH_UI_AMBIGUOUS` là tiền đề/rủi ro | Q13 |
| Loại | "Bú win ngoài phạm vi" | Q9 |

### 7.2 Từ plan SWE-2

| | Nội dung | Lý do |
|---|---|---|
| Giữ | Mở rộng `reasoning_common_*`, schema v2 đọc v1, boss registry có provenance, nhãn situation | Một lõi, giải thích được |
| Giữ | EVOLVE là EffectChoice, skill fire/hold, `_future_continuation` 2-ply suy giảm êm | Đúng lỗ hổng đã kiểm trong code |
| Giữ | Brain pack (đổi tên model pack), chữ ký/scope/pin, audit không tự học, export/import đóng góp, knowledge audit, metric eval rộng | Q7, Q1 |
| Bổ sung | Identity từ petId đã pin + đảo; SPAWN/refill; bench cùng bàn làm acceptance chính; đo ngân sách + admission bản đóng gói | Code hiện chặn package/Coop; fingerprint không đủ định danh |
| Điều chỉnh | Trainer chuyển từ `src/pokiguard_v2/learning/` sang `tools/reasoning_lab/` | Ngăn import vào runtime về mặt cấu trúc |
| Điều chỉnh | Pack phát hành cùng tool, thử ứng viên bằng source của owner | Q2; bỏ owner override trong bản khách |
| Điều chỉnh | "Đồng đều mọi style" → lõi chung, rollout theo nhóm | Q3 |
| Điều chỉnh | "unittest discover PASS toàn bộ" → ci_offline + test liên quan PASS, full run phân loại lỗi có sẵn, 0 lỗi mới | Repo có lỗi fixture lịch sử đã ghi nhận |
| Loại | denial ≈ 0 khi boss trên ngưỡng | Trái Q10 |
| Loại | Toggle "Suy luận nâng cao" ở tab AI | Trái Q8 |
| Loại | Ma trận live style × scope × action × version | Lặp live không tạo bằng chứng mới |
| Loại | `POSTMATCH_UI_AMBIGUOUS` trong vấn đề mở | Q13 |

## 8. Kiểm thử

- Unit (registry, situation, denial, effects, refill, planner v2, loader, export), scenario theo
  catalog, parity khi tắt (corpus U1, 216 BASIC, 243 style cũ), deterministic, fuzz, perf theo
  envelope, fault injection, integration (không thêm read/capture), audit không tự học, packaging.
- Thêm module mới vào `scripts/ci_offline.py`; full discover ở biên tích hợp, phân loại lỗi cũ.

## 9. Rủi ro

| Rủi ro | Giảm thiểu |
|---|---|
| Python chậm | Tái dùng kết quả BASIC, cache theo snapshot, cap/anytime; envelope từ U1 |
| Admission bản đóng gói phức tạp | Quyết định theo số đo U1/U8; mặc định vẫn BASIC |
| Dữ liệu boss ít | Prior theo tầng đảo, abstain, không gộp cohort |
| Log giả/đầu độc | Audit nhất quán, cách ly, holdout tin cậy của owner |
| Game update đổi schema | Scope theo game build, sai scope → cấu trúc hiện tại |
| Mất khóa ký | Quy trình sao lưu khóa ở U7 |
| Quyền riêng tư | Ẩn danh, đồng ý, không ảnh mặc định |
| Kỳ vọng thắng mọi boss | Báo cáo theo cohort; boss có thể áp đảo cấu hình |

## 10. Sổ quyết định

| Mã | Nội dung |
|---|---|
| D-U0 | Duyệt plan canonical, catalog, nháp DECISIONS |
| D-U1 | KPI + envelope ngân sách |
| D-U2 | Kết quả capture; có/không đọc bộ nhớ mới |
| D-U3 | Văn bản đồng ý, nội dung gói, nơi lưu kho |
| D-U5 | Mẫu quyết định Hút/nhiều lượt |
| D-U6 | Bảng chuyển U6a; hoãn tiến hóa, skill fire/hold |
| D-U7 | Quản lý khóa ký owner |
| D-U8 | Phương án admission |
| D-U9 | Duyệt pack v1 |
| D-U10…U14 | Live và verdict từng nhóm |
| D-U15 | Phát hành |
| D-U16 | Mở Tier 2 |
| D-U17 | Upload tự động, nhà cung cấp |

## Phụ lục A — Hút có/không (minh họa phép so, không phải tri thức game)

Ký hiệu theo §4.3: boss hiện có `M`; Hút `[h_min, h_max]`; tự bơm `[c_min, c_max]`; viên boss
ăn được `[g_min, g_max]` (riêng từng nhánh); trần `cap`; ngưỡng `T`. Mỗi nhánh có
`R_min = min(cap, max(0, M − h_max) + c_min + g_min)` và
`R_max = min(cap, max(0, M − h_min) + c_max + g_max)` (nhánh không Hút có `h = 0`).

| Ca | Nhánh không Hút | Nhánh có Hút | Kết luận |
|---|---|---|---|
| 1 | `R_min ≥ T` | `R_max < T` | Chặn lượt tới ở mọi kịch bản |
| 2 | `R_min ≥ T` | `R_min < T ≤ R_max` | Chặn một phần, ghi khoảng |
| 3 | `R_min ≥ T` | `R_min ≥ T` | Không chặn lượt tới; xét lần cast sau nếu biết lượng tiêu |
| 4 | `R_max < T` | `R_max < T` | Hút không đổi lượt tới; chỉ còn theft/horizon |
| 5 | thiếu `T`, `h`, `c` hoặc `g` | — | UNKNOWN, dùng proxy hiện có, không cộng/trừ |

Ví dụ kiểm toán (số minh họa): `M = 550`, `T = 500`, Hút đúng 100, tự bơm 0–100, `g = 0`.
Không Hút: 550–650 → `READY`. Có Hút: 450–550 → `PARTIAL` (ca 2), dù boss đang trên ngưỡng.

Hút có thể lấy Mana hoặc Nộ (cách server chọn chưa rõ): mỗi loại là một kịch bản riêng; skill boss
có thể cần Mana và/hoặc Nộ theo registry (gộp AND).

## Phụ lục B — Catalog tình huống v2 (dự thảo, duyệt ở U0)

| Mã | Tình huống | Kỳ vọng |
|---|---|---|
| S01 | Có hành động kết liễu chắc trong mô hình | Kết liễu |
| S02 | Boss có thể kết liễu ta lượt tới | Phòng thủ hoặc kết liễu trước nếu được |
| S03 | Hút đổi boss từ đủ sang chưa đủ ngưỡng | Ưu tiên Hút theo mức chặn |
| S04 | Hút không đổi khả năng skill lượt tới | Không cộng điểm chặn; xét theft/horizon và nước khác |
| S05 | Thiếu ngưỡng/tự bơm/lượng Hút | UNKNOWN, không suy |
| S06 | Boss sắp vào ngưỡng hồi máu | Tránh đánh lẻ vào vùng hồi khi chưa đủ burst |
| S07 | Skill ta sẵn sàng | So bắn ngay vs giữ, gồm phản hồi boss |
| S08 | Bắn skill xong boss có burst chết người | Cân nhắc phòng trước nếu skill không kết liễu |
| S09 | Tiến hóa ngay vs giữ Mana | Theo giá trị, cần D-U6 |
| S10 | Tài nguyên đầy | Không ăn chỉ vì tài nguyên đó |
| S11 | Ta giữ nhiều Mana/Nộ, boss có nước Hút | Giảm Hút cho boss |
| S12 | Mọi nước đều chừa Kiếm | Chừa ít nhất, vẫn đi nước, không dừng |
| S13 | Nước mở cột sâu | Hazard sau refill |
| S14 | Setup lượt sau | Chỉ tính phần còn sau phản hồi boss |
| S15 | PASS | Chỉ khi owner cho phép; lượt đầu/2-3 theo luật cũ |
| S16 | G4 | Mốc combo vs bảo vệ vs route tiến hóa |
| S17 | Galaxy G1/G3 | Theo pha runtime |
| S18 | Mega | Ấn vs bảo vệ/hồi máu |
| S19 | HT7 | Giữ Kiếm cho skill vs sống sót |
| S20 | Boss có Khiên lớn | Xét hấp thụ nếu dữ liệu cho thấy |
| S21 | Boss máu thấp + đủ Mana chưởng | Giữ finisher BASIC, R chỉ so sánh |
| S22 | Bú win | Mục tiêu đội, không solo-survival |
| S23 | Thiếu model hoặc không có nước an toàn | Dùng BASIC/nước rủi ro thấp nhất hợp lệ, không dừng |

## Phụ lục C — Schema dự thảo

- `pokiguard.reasoning.contribution.v1`: `schema, created_utc, tool_version, source_sha256,
  game_build_sha256, model_pack_sha256, contributor_id, consent, redaction, files[{path,sha256,bytes}],
  matches[{match_id_hash,style,boss_pet_id,island,result}]`.
- `pokiguard.reasoning.model_pack.v1`: `manifest{pack_id,version,created_utc,engine_compat,
  scope{game_builds,styles,bosses},dataset_manifest_sha256,trainer_source_sha256,metrics,approval}`,
  `payload{weights,boss_entries,drain,effects,refill,boss_move}`, `signature{key_id,value}`.
  Mỗi giá trị có `support ∈ {UNKNOWN, HEURISTIC, USER_DECLARED, EMPIRICAL_VALIDATED,
  VERIFIED_FOR_SCOPE}` và số mẫu.

## Phụ lục D — Đầu mối reverse B17 (chưa dùng runtime)

- `MatchPlayerSnapshotDTO` (TypeDefIndex 631): `fusionLastAttemptTurn +0xDC`, `fusionPityFails +0x128`,
  `fusionPityPercent +0x12C`, `skillCooldownCardId +0x140`, `skillCooldownLeft +0x144`,
  `cardCooldownLeft +0x148`, `skillStacks +0x150`, `skillStackMax +0x154`, `skillStackPct +0x158`,
  `skillPhaseNext +0x15C`, `skillPhaseMax +0x17C`, `skillPhaseCardId +0x180`, `dotDropPct +0x1B8`,
  `luckyDotTag +0x1C0`, `luckPct +0x1C8`. Ưu tiên lấy qua key JSON đã đọc.
- `WsCombatStepDTO` (633): `kind/source/target/amount/stealType/dmgSrc/fullPower/after/idx`.
- `PetLibDTO` (2183): `skillCardId +0x14`, `elementType +0x20`, `weaknessValue +0x50`, `effects +0x68`.
- `BossAI.CountBossSetupPotential(string[,])` RVA `0xBC6D80` (công dụng UNKNOWN).
- Refill: op `SPAWN` trong `matchPayload.ops`.
- Tất cả là khai báo tĩnh; nghĩa runtime UNKNOWN tới khi U2 xác minh.

## Phụ lục E — Ánh xạ phase cũ

| Opus v1 | SWE-2 | Plan hợp nhất |
|---|---|---|
| O0 | S0 | U0 |
| O1 | — | U1 |
| O2 | (S2 phần capture) | U2 |
| O3 | S2 | U3 |
| O4 | S1 | U4–U6 |
| O5 | S3 | U9 (Tier 1), U16 (Tier 2) |
| O6–O7 | S4–S5 | U7, U8, U10–U13 |
| O8 | S5 | U14 |
| O9 | S6 | U15, U17 |
