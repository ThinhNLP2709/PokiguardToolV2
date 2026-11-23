# swe-3-reasoning-upgrade — Nâng cấp AI suy luận thành AI match-3 thực thụ

**Tác giả:** SWE-2 Max (Devin) — mọi tài liệu của task này đặt dưới `docs/swe-2/`.
**Trạng thái:** PLAN — chưa triển khai. Chờ user duyệt từng phase.
**Ngày audit baseline:** 2026-11-23.

---

## 1. Mục tiêu

Nâng cấp hệ suy luận `reasoning_common_*` hiện có thành một engine đánh giá
tình huống hai phía (ta + địch) cho **mọi lối chơi** — đồng đều, không ưu
tiên style nào trước (quyết định của user), gồm Bú win coop — và một vòng
học offline **do owner kiểm soát hoàn toàn**.

Cụ thể theo yêu cầu user:

1. Đánh giá "tình hình nước đi của cả ta và địch": tài nguyên/HP/skill hai bên
   trước khi chọn nước — thay cho proxy cấu trúc thuần túy hiện nay.
2. Với boss khó (từ Đảo Cổ Đại trở đi, có skill riêng): nếu tài nguyên boss ít
   thì cân nhắc hút để giữ nó "đói" skill; nếu boss nhiều tài nguyên thì việc
   hút ít hiệu quả → đi nước khác. Đây là mô hình **denial** bên cạnh **theft**
   hiện có.
3. Suy luận nhiều trường hợp khác để chọn: nước swap thường, thu tài nguyên,
   hút, khiên/heal, ra skill khi cần, tiến hóa ngay hay chưa, tấn công/cast,
   PASS khi hợp lệ.
4. Nạp data để học hỏi — nhưng **có kiểm soát**: người chơi khác chỉ upload
   log để owner train offline; **AI không tự phát triển trong quá trình dùng
   tool**. Model học xong đóng băng, ký số, ship như artifact có phiên bản.
5. Kênh đóng góp: **cả hai theo giai đoạn** (quyết định của user) — export
   bundle thủ công trước; upload tự động thiết kế sau khi có backend.
6. Hướng học: **agent đề xuất** (quyết định của user) — đề xuất tại §5.

## 2. Baseline đầy đủ (audit repo)

### 2.1 Đã có — tái dùng, không viết lại

| Thành phần | File / vị trí | Vai trò hiện tại |
|---|---|---|
| Chooser chung | `src/pokiguard_v2/reasoning_common_planner.py` | Chấm mọi root swap + `EffectChoice` (pet_skill / cast / pass) bằng feature F/R/D/P/H/B/T/X/L/E interval-bounded; lookahead root → toàn bộ boss reply đã biết → setup floor; `CommonLimits` cap `duration_ms=4000`, `roots=8`, `scenarios=32`, `nodes=18000` |
| Problem / facts | `reasoning_common_problem.py`, `reasoning_common_evidence.py` | `CommonProblem` bất biến từ packet controller: board, baseline BASIC, facts (stats hai bên, conversion, requirements, evolution), effects hợp lệ |
| Boss knowledge | `boss_threat.py` + `docs/boss_skill_knowledge.md` | "Ancient Island+ boss tự bơm Mana/Nộ, có thể cast/heal" = possible; mọi tham số cụ thể (cost, cooldown, damage, đảo, skill ID) UNKNOWN; `current_boss_scope` luôn UNKNOWN; `protection_requested` heuristic |
| Drain | `reasoning_common_tactics.py` | `_drain_fills` / `_reply_risk`: drain chỉ là **theft** — giá trị ∝ tài nguyên boss đang giữ × mức ta đầy; chưa có denial |
| Simulator | `board_simulator.py` | Deterministic match/collapse/cascade, sword-reply, sword-hold |
| Solver V1 | `v1_solver_adapter.py` + `docs/v1_solver_contract.md` | `decide_turn(...)` nguyên vẹn — incumbent/fallback |
| Policy | `basic_policy.py` (~4k dòng) | BASIC incumbent; 9 profiles: simple, careful, dinosaur, skill_rush, demon_aegis_farm, mega_icarus_spam_skill, galaxy, bu_win, galaxy_shadow_sword |
| Capture / replay | `reasoning_common_capture.py`, `tools/extract_common_snapshots.py`, `reasoning_replay.py` | Snapshot tư vấn chính xác replay offline; 619 replay / 633 paired hiện có |
| Runner / gate | `reasoning_runner.py`, `reasoning_common_selection.py`, `reasoning_common_native.py` | Job deadline, host verify lại, admission fail-closed, BASIC fallback khi timeout/lỗi |
| Shadow / settings | `reasoning_shadow.py`, `reasoning_settings.py`, `reasoning_galaxy.py` | Shadow observe không input; AI settings budget/shadow/reasoning toggles |
| Learning research | `damage_baseline.py`, `damage_conditional*.py`, `damage_evaluation.py`, `damage_uncertainty.py`, `tools/run_*`, `tools/audit_*` | Dataset protocol (split theo match/account, fold, pin, poison test) — **chưa deploy model nào** |
| Dataset | `docs/phase5/datasets/` | `5b1_verification.json`, `5b3_synthetic_boards_v1.json`, `demon_historical_v1.jsonl`, `replay_events_v1.jsonl`, `synthetic_mechanics_v1.jsonl`, manifest + README |
| Log user ngoài | `logs/farm_runs/`, `docs/external_user_log_review_20261024.md` | Đã từng nhận + review log user gửi thủ công |
| Updater | `src/pokiguard_v2/updater/`, `scripts/create_update_manifest.py` | Manifest ký số, GitHub Releases — kênh phân phối sẵn có cho brain pack |
| Test | `tests/` (~218 file, 429 CI tests PASS ngày 23/11) | Nhiều test reasoning: planner, runner, capture, replay, threat, policy |

### 2.2 Còn thiếu — đúng các gap user yêu cầu

1. **Boss model = snapshot chung.** Không có registry per-boss (đảo, skill,
   ngưỡng Mana/Nộ, cooldown, heal, damage). Boss identity: `ParticipantState`
   chỉ có `actor_number` + stats (`hp/mana/power/attack/shield`), không có
   tên/ID — key khả dụng là farm target đã cấu hình + stats fingerprint.
2. **Drain chỉ có theft.** Chưa có denial_value (giữ boss dưới ngưỡng
   skill-ready). Boss reply chỉ gồm swap đã biết — skill boss / board-effect
   boss chưa là nhánh lookahead.
3. **EVOLVE, fire-vs-hold skill chưa được chấm tình huống.** EVOLVE do owner
   Step-1 cố định; skill theo điều kiện cứng từng profile (skill_rush,
   mega_icarus). Chưa có quyết định "tiến hóa ngay hay đợi" / "ra skill bây
   giờ hay giữ".
4. **Lookahead ~1.5 ply.** Chưa chấm best-response của ta sau từng nhánh boss
   reply; chưa mô hình hóa boss resource transition (tự bơm → vượt ngưỡng).
5. **Không có pipeline học.** Không dataset chuẩn mới, không trainer, không
   brain-pack format, không loader runtime, không owner gate, không export/
   import log đóng góp.
6. **Chưa có verdict giải thích.** Decision có diagnostics nhưng không có
   nhãn tình huống cấp cao ("boss sắp cast", "hút đáng", "nên giữ skill").

### 2.3 Vấn đề mở đã biết (không thuộc scope fix, nhưng dataset cần capture)

- `POSTMATCH_UI_AMBIGUOUS` sau trận G4 thua no-evolution.
- Raijin loss: boss HP tăng lớn + damage event cuối có nguồn/thứ tự UNKNOWN.
- Damage/effect model chưa đầy đủ; thiếu holdout độc lập cho learned ranker.

## 3. Nguyên tắc bắt buộc (giữ nguyên từ AGENTS.md / DECISIONS.md / policy docs)

- Không WriteProcessMemory / injection / patch / `MatchService.SendMove` /
  `RequestSwap` / packet / `enableAutoMove`. Input = Windows input thường.
- External memory read-only; `PokiguardAuto` và `pc` read-only.
- BASIC giữ incumbent/fallback; AI propose-only, không sở hữu input, pending,
  ACK, recovery, QTE. Timeout/lỗi worker/log → BASIC còn hợp lệ.
- UNKNOWN ≠ 0; UNKNOWN không phải bằng chứng an toàn. Không suy cost/cooldown/
  damage/refill/đảo/skill khi thiếu chứng cứ.
- PASS là game-authoritative; không counter cục bộ tạo quyền PASS.
- Không tự train sau trận / theo thắng-thua; không online update; learned
  artifact phải versioned, provenance-bound, operator-approved.
- Capability gate (ownership/actionability/QTE/freshness/turn/lease) độc lập
  với utility — điểm cao không cấp quyền.
- Scratch ở `temp/reasoning/`; test dùng `reasoning_temp_root()`; bằng chứng
  lâu dài ở `docs/`; dừng đúng milestone.
- Live test chỉ khi user duyệt: cap nhỏ, source pin, receipts; số trận thắng
  không tự là bằng chứng chất lượng.

## 4. Kiến trúc đích

```
game state (read-only)
  -> packet controller / providers (giữ nguyên)
  -> CommonProblem v2 (facts + boss_knowledge + effects + evolve candidate)
  -> Situation engine v2
       boss_knowledge registry ─┐
       drain denial model       ├-> verdict tags (giải thích được)
       damage/abstain sub-model ┘
  -> plan_common (bounded 2-ply, WEIGHTS structural | brain pack)
  -> capability gates (giữ nguyên, độc lập utility)
  -> proposal -> host verify -> input owner (giữ nguyên)
  -> BASIC fallback (luôn trong tập ứng viên)

Offline (owner only):
  own logs + contribution bundles -> build_situation_dataset
    -> learning/ trainers -> eval holdout -> sign -> brain pack
    -> bundle release / updater -> runtime verify+pin
```

## 5. Hướng học đề xuất (agent's proposal)

Không chọn end-to-end policy network: vi phạm explainability, khó fail-closed,
không tận dụng được solver/simulator đã kiểm chứng. Đề xuất **tiered**:

1. **Tier 1 — calibrated weights + fitted sub-models** (S3): học trọng số
   utility per profile + ngưỡng skill boss + drain denial + damage predictor
   từ dataset. Toàn bộ output vẫn interval-bounded, provenance-labelled,
   abstain khi thiếu support → chooser vẫn giải thích được, deterministic,
   fail closed về structural weights.
2. **Tier 2 — learned value/ranker** (sau khi Tier 1 có data đủ): model xếp
   hạng root/leaf state sâu hơn, dùng làm tie-break hoặc leaf evaluator cho
   lookahead — vẫn trong chooser có giải thích. Chỉ promote khi thắng
   reference+guarded trên holdout đóng băng.
3. Không bao giờ: self-modifying runtime, RL online, black-box chooser thay
   thế hoàn toàn.

## 6. Các phase chi tiết

### S0 — Baseline & scaffolding (docs-only)

**Mục tiêu:** chốt baseline, đặt nền tài liệu.

Tasks:
- [ ] Chốt baseline: `git log -1`, `git status` sạch, số test PASS
      (`python -m unittest discover -s tests`), trạng thái CURRENT_STATE/README.
- [ ] Tạo `docs/swe-2/` + `README.md` index.
- [ ] Viết file plan này (`swe-3-reasoning-upgrade.md`) — canonical.
- [ ] `swe-3-knowledge-audit.md`: bảng KNOWN/UNKNOWN theo khả năng (boss skill
      per-đảo, drain, damage, refill, evolve cost, skill timing, boss reply,
      coop) map → module code + bằng chứng docs. Đây là "source of truth"
      mọi phase sau phải update.

Checklist nghiệm thu: docs đầy đủ; **không** file runtime nào thay đổi.
Live test: không.

### S1 — Situation engine v2 (đánh giá hai phía)

**Mục tiêu:** intelligence core — mọi profile dùng chung, chỉ khác intent/
weights. Schema `pokiguard.reasoning.common_problem.v2` tương thích đọc v1.

Tasks:

1. **`boss_knowledge.py` + `docs/data/boss_knowledge.json`** — registry
   per-boss:
   - Key: farm target đã cấu hình (`lieyun1436`, …) + stats fingerprint
     (max_hp/mana/power/attack).
   - Fields: `island_tier`, `skill_present`, `mana_threshold`,
     `rage_threshold`, `heal_possible`, `cooldown_estimate`,
     `self_charge_rate`, `drain_resist` — UNKNOWN khi chưa chứng minh.
   - `provenance` per field: USER_DECLARATION | REVERSE | LEARNED | UNKNOWN.
   - Entry default = model chung hiện có (Ancient+ self-charge/cast/heal
     possible). Boss lạ → `GENERIC_ADVANCED`, không đoán.
   - `boss_threat.assess_boss_threat` nâng cấp nhận entry matched:
     `current_boss_scope` → `MATCHED_<key>` / `GENERIC_ADVANCED` / `UNKNOWN`.
2. **Drain = theft + denial** trong `reasoning_common_tactics.py`:
   - Giữ theft hiện có.
   - `denial_value(boss_resource, threshold, self_charge)`: cao khi boss dưới
     ngưỡng và hút giữ nó dưới ngưỡng ≥1 lượt; ~0 khi boss đã trên ngưỡng
     hoặc self-charge bù ngay; UNKNOWN khi threshold chưa có.
   - Áp vào feature P (resource/pressure) + reply risk đối xứng (Drain reply
     của boss lên ta theo ngưỡng skill của ta).
3. **Ứng viên EVOLVE + fire-vs-hold skill**:
   - `evolve` thành `EffectChoice` (functional, không tiêu lượt): value =
     lợi ích tiến hóa (stats/heal nếu verified) − cost Mana (runtime, không
     hardcode 120) − cửa sổ nguy hiểm boss. Vẫn qua owner gate hiện có —
     chỉ *đề xuất*.
   - Skill: khi eligibility đạt, chooser so "fire now" vs "hold" qua
     expected terminal/survival; thiếu model → giữ hành vi điều kiện hiện có.
   - Cast/attack: cost từ runtime card data (không hardcode 160).
4. **Lookahead 2-ply bounded**:
   - `_future_setup` → `_future_continuation`: mỗi boss reply (nominal +
     stress + nhánh skill nếu registry có `skill_present`) → chấm
     best-response hợp lệ của ta trên residual board → aggregate
     worst/nominal; floor UNKNOWN giữ nguyên.
   - Adaptive depth: 2-ply đầy chỉ cho top-K roots trong budget; node/time
     caps hiện hữu không đổi (nodes≤18000, duration≤4000ms; production slice
     ~45%); hết budget → dùng kết quả 1-ply đã hoàn tất.
   - Boss resource transition trong reply: tự bơm theo `self_charge_rate`
     (UNKNOWN → nhánh cả hai khả năng, bounded).
5. **`reasoning_situation.py`** — verdict tags read-only kèm evidence:
   `BOSS_SKILL_LIKELY`, `DRAIN_WORTH`, `EVOLVE_WINDOW`, `SKILL_NOW`,
   `HOLD_SKILL`, `SURVIVAL_RISK`, `BOSS_REPLY_DANGER`, `RESOURCE_RACE`.
   Ghi vào `CommonDecision.diagnostics` để UI/log giải thích "tại sao".
6. **Invariant**: UNKNOWN không cộng điểm; BASIC luôn trong tập ứng viên;
   bu_win giữ objective B (team) — boss model áp dụng nhưng không biến
   thành solo-survival; galaxy_shadow_sword giữ Sword priority đã pin.

Files:
- Mới: `boss_knowledge.py`, `reasoning_situation.py`,
  `docs/data/boss_knowledge.json`, `tests/test_boss_knowledge.py`,
  `tests/test_reasoning_situation.py`, `tests/test_drain_denial.py`,
  `tests/test_evolve_choice.py`, `tests/test_lookahead_2ply.py`.
- Sửa: `boss_threat.py`, `reasoning_common_tactics.py`,
  `reasoning_common_evidence.py`, `reasoning_common_planner.py`,
  `reasoning_common_problem.py`, `reasoning_common_selection.py`,
  `reasoning_common_capture.py` (schema v2), tests liên quan.

Checklist nghiệm thu S1:
- [ ] Registry load + match boss đúng/sai fingerprint; boss lạ → generic.
- [ ] Denial value đúng đặc tả: dưới ngưỡng > 0, trên ngưỡng ≈ 0, threshold
      UNKNOWN → UNKNOWN (không suy).
- [ ] EVOLVE/skill candidate xuất hiện + gated đúng; không vượt owner gate.
- [ ] 2-ply trong caps; budget hết → degraded gracefully về 1-ply.
- [ ] Verdict tags có mặt trong diagnostics; UNKNOWN-labelled khi cần.
- [ ] Toàn bộ test cũ PASS; replay parity incumbent khi feature tắt.

Verification: unit tests; replay trên snapshot đã capture (9 bàn Raijin,
dataset damage, 619 replay); latency p95/p99 trong budget.
Live test: **không** (offline thuần).

### S2 — Dataset & đóng góp dữ liệu

**Mục tiêu:** log → dataset chuẩn; kênh user đóng góp.

Tasks:
- [ ] Event `reasoning.situation.v2`: snapshot + verdict tags + action gửi +
      join outcome (win/loss, HP/resource delta khi quan sát được — tái dùng
      `combat_outcome_evidence`); bounded payload; mất log không ảnh hưởng
      gameplay.
- [ ] `tools/export_contribution.py` + nút **"Đóng góp dữ liệu"** trên UI:
      bundle `pokiguard.contribution.v1` — snapshots, outcome events, manifest
      (tool version, source sha, `account_sha256`, record counts). Loại trừ:
      username, token, đường dẫn cá nhân, screenshot. Giới hạn dung lượng.
      User tự gửi file. (Upload tự động: chỉ thiết kế spec ở S6 khi có
      backend — phase này không viết code mạng.)
- [ ] `tools/import_contribution.py` (owner-side): validate schema, sanitize,
      dedup, quarantine record lỗi; `provenance=EXTERNAL_USER_<anon_sha>`;
      log ngoài chỉ vào TRAIN sau audit — không tự tin.
- [ ] `tools/build_situation_dataset.py`: record chuẩn (pre-action features,
      action taken, post-action delta, match outcome); split theo
      match/account theo `DAMAGE_DATASET_PROTOCOL`; manifest + holdout
      freeze; lưu `temp/reasoning/` hoặc `docs/phase5/datasets/` tùy quy mô.

Checklist:
- [ ] Export → import roundtrip PASS trên log mình + log user ngoài mẫu.
- [ ] Test quét PII: bundle không chứa username/token/path cá nhân.
- [ ] Split đúng protocol: không rò rỉ match/account giữa TRAIN/TEST.
- [ ] Malformed/poisoned bundle bị quarantine, không crash.

Live test: không.

### S3 — Owner learning pipeline (offline, chỉ máy owner)

**Mục tiêu:** dataset → brain pack ký số.

Tasks:
- [ ] Package `src/pokiguard_v2/learning/` (runtime UI **không** import):
  - `weights_fit.py`: calibrate WEIGHTS per profile (miền giới hạn,
    monotone khi cần, giữ interval semantics + provenance).
  - `boss_skill_fit.py`: ngưỡng Mana/Nộ skill, heal, cooldown, self-charge
    theo boss key + coverage/support labels.
  - `drain_fit.py`: hiệu quả denial/theft theo bucket tài nguyên boss.
  - `damage_fit.py`: tiếp tục nhánh `damage_*` → predictor deployable
    (giữ abstention).
- [ ] Brain pack `pokiguard.brain.v1`: manifest (version, created_at,
      dataset sha256, scope: profiles/game-build/account nếu có, signature)
      + weights + boss entries + predictor params; validate chặt khi nạp;
      sai scope → fail closed.
- [ ] Ký: private key ngoài repo/release (chỉ owner); runtime verify bằng
      public key nhúng; pack không ký chỉ nạp ở owner mode.
- [ ] `tools/evaluate_brain.py`: replay holdout đóng băng; so reference +
      guarded vs weights hiện hành; promotion checklist doc — không tune
      trên TEST đã xem (giữ convention).

Checklist:
- [ ] Fit trên fixture nhỏ tái hiện được; poison/pin test giữ convention.
- [ ] Pack đúng/sai chữ ký/sai scope → loader phản ứng đúng.
- [ ] Eval tái hiện deterministic; metrics gồm: decision agreement, regret
      vs oracle/reference, survival, action success, resource efficiency,
      boss-damage risk, calibration, fallback rate, latency — không chỉ
      win-rate.

Live test: không.

### S4 — Runtime integration (nạp brain, không tự học)

**Mục tiêu:** runtime dùng artifact đã duyệt; bảo đảm không-tự-học ở mức code.

Tasks:
- [ ] `reasoning_brain.py`: nạp pack từ `resources/brain/` (bundled) hoặc
      `data_root/owner_brain/` (owner override); verify signature + scope +
      version; pin version theo FarmRun; lỗi → WEIGHTS cấu trúc.
- [ ] Planner integration: pack hợp lệ → weights per profile thay mặc định;
      sub-models vào `facts` (boss model → threat, drain → denial, damage →
      D); mọi thứ interval-bounded + provenance.
- [ ] **Không-tự-học**: runtime không có write-path nào cho learning;
      capture giữ observation-only; audit test (AST/import-graph scan) chứng
      minh runtime không import `learning/` hay gọi API fit.
- [ ] Owner gate: `data_root/owner_brain/` + owner key file (tạo thủ công,
      không ship); UI tab AI hiển thị brain version (read-only) + nút
      "Đóng góp dữ liệu" (S2); toggle `Suy luận nâng cao` (default OFF tới
      khi S5 nghiệm thu); giữ `reasoning_enabled`/shadow hiện có.
- [ ] Phân phối: pack bundle trong ZIP; pack mới qua updater ký số hiện có
      (mở rộng manifest `pokiguard.package_build.v1` + `resources/brain/`) —
      thiết kế + test offline phase này, kích hoạt sau duyệt.

Files:
- Mới: `reasoning_brain.py`, `resources/brain/`, `tools/sign_brain_pack.py`,
  `tests/test_reasoning_brain.py`, `tests/test_no_self_learning.py`.
- Sửa: `reasoning_common_*` (loader hooks), `reasoning_settings.py`,
  `desktop_ui.py` / `desktop_preferences.py`, `scripts/create_package_build.py`
  (bundle brain nếu cần).

Checklist:
- [ ] Loader: hợp lệ/sai chữ ký/sai scope/hết hạn → đúng hướng, fail closed.
- [ ] Replay parity weights↔brain; absent brain → structural path nguyên.
- [ ] Frozen build đóng gói `resources/brain/` đúng.
- [ ] Audit không-tự-học PASS.
- [ ] UI: toggle + version hiển thị + nút đóng góp hoạt động.

Live test: không (chỉ offline packaging test).

### S5 — Shadow, live validation & rollout

**Mục tiêu:** chứng minh trên thật trước khi mở quyền.

Tasks:
- [ ] Shadow A/B: adviser v2(+brain) vs incumbent trên cùng snapshot —
      replay trước, rồi shadow observe không input; report decision-diff có
      giải thích verdict tags.
- [ ] **Live pilot (chỉ khi user duyệt, convention cap):** per nhóm profile
      cap 1–3 trận, source pin, receipts đầy đủ; mỗi pilot một report
      `docs/swe-2/`. Ma trận tối thiểu: mỗi style × boss scope (generic vs
      matched) × action class (swap/drain/skill/evolve/pass) × brain version.
      Ancient Island+ bắt buộc có ít nhất một pilot matched-boss.
- [ ] Acceptance gates: safety zero (không vi phạm read/input/timeout/PASS);
      quyết định review trên replay; win-rate không là bằng chứng duy nhất.
- [ ] Rollout: bật `Suy luận nâng cao` cho scope nghiệm thu; rollback =
      brain/weights trước; update CURRENT_STATE/DECISIONS/README.

Checklist:
- [ ] Shadow diff report đầy đủ verdict + reason.
- [ ] Pilot receipts đủ; zero safety violation trước khi xét chất lượng.
- [ ] Rollback path thử nghiệm (tắt toggle / gỡ pack → BASIC+structural).

### S6 — Vòng train định kỳ (standing process)

- Triage contribution bundles (S2) → rebuild dataset → retrain (S3) → eval →
  sign → release brain mới qua updater/Release; changelog per pack.
- Thiết kế kênh upload tự động (spec) khi có backend — user chọn "theo giai
  đoạn", phase này chỉ spec, không code mạng.
- Update `swe-3-knowledge-audit.md` mỗi lần UNKNOWN → KNOWN.

## 7. Files tổng hợp

**Mới:**
- `docs/swe-2/*` (plan này, README, audit, phase reports)
- `docs/data/boss_knowledge.json`
- `src/pokiguard_v2/boss_knowledge.py`
- `src/pokiguard_v2/reasoning_situation.py`
- `src/pokiguard_v2/reasoning_brain.py`
- `src/pokiguard_v2/learning/{__init__,weights_fit,boss_skill_fit,drain_fit,damage_fit}.py`
- `tools/{export_contribution,import_contribution,build_situation_dataset,evaluate_brain,sign_brain_pack}.py`
- `resources/brain/`
- `tests/test_{boss_knowledge,reasoning_situation,drain_denial,evolve_choice,lookahead_2ply,reasoning_brain,no_self_learning,contribution_*}.py`

**Sửa:**
- `boss_threat.py`, `reasoning_common_{tactics,evidence,planner,problem,selection,capture}.py`
- `reasoning_settings.py`, `desktop_ui.py`, `desktop_preferences.py`
- `scripts/create_package_build.py` (bundle brain)
- `docs/{CURRENT_STATE,DECISIONS}.md` khi rollout

## 8. Verification tổng

- [ ] `python -m unittest discover -s tests` — PASS toàn bộ mỗi phase
      (baseline: 429 CI tests ngày 23/11).
- [ ] Replay parity: incumbent không đổi khi brain absent/tắt.
- [ ] Planner latency trong budget hiện hữu (worker ≤1.8s/≤45% slice;
      G4 ≤250ms).
- [ ] Audit: runtime không import `learning/`, không write-path training.
- [ ] Bundle đóng góp: schema đúng, không PII, quarantine đúng.
- [ ] Brain pack: verify chữ ký/scope/version; fail closed đúng hướng.
- [ ] Live pilot (S5): chỉ sau duyệt user; safety zero; receipts đủ.

## 9. Rủi ro & cân nhắc

- **Boss identity mờ**: snapshot chỉ có stats + farm target → registry khóa
  theo target + fingerprint; boss lạ → generic Ancient-Island model; không
  đoán đảo/skill.
- **Bú win coop**: objective team khác — boss model áp dụng nhưng giữ ranh
  giới objective B đã chốt; không biến thành solo-survival.
- **Explainability vs học**: mọi artifact học phải giữ interval semantics +
  provenance + abstention; không nạp model mờ không giải thích được.
- **Không-tự-học**: đảm bảo mức code (không API) + audit test, không chỉ
  bằng cài đặt UI.
- **Phạm vi lớn**: phase độc lập, dừng đúng milestone; S0–S4 offline thuần;
  S5 cần máy + game của user.
- **Lịch sử damage research**: tái dùng protocol/fold; không train lại trên
  TEST đã xem; predictor chỉ deploy khi thắng baseline trên holdout đóng
  băng theo convention.
- **Game update**: fields reverse có thể đổi — registry/pack pin theo
  game-build scope; scope lệch → fail closed về structural (không crash).

## 10. Thứ tự đề xuất & điểm dừng

S0 → S1 → S2 → S3 → S4 → S5 → S6. Mỗi phase kết thúc bằng report
`docs/swe-2/swe-3-phase-SN-*.md` + checklist ticked; user duyệt trước khi
sang phase có live test. Không implementation nào bắt đầu trước duyệt plan.
