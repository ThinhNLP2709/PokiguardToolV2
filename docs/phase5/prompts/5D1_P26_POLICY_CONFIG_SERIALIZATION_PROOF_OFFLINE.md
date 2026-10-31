# 5D.1-P26 — Proof candidate serialize PolicyConfig, offline

**SELECTED ONLY / NOT EXECUTED.** Chưa cần mở game.
Đọc AGENTS, STATUS/ROUTER/capability, EXECUTION_CONTRACT,
[P25 report](../reports/5d1_p25_report.md),
[decision](../artifacts/5d1_pipeline_slo_review_p25_v1/decision.json),
[remediation proposal](../artifacts/5d1_pipeline_slo_review_p25_v1/remediation_proposal.json),
provenance/accounting ledgers và original P21/P24 evidence.

## Entry và mục tiêu

P25 xác minh max10ms là intentional absolute telemetry gate từP3, giữ ở
P12/P13/P18/current verifier. P21 vẫn31/32FAIL với index2789=11.8417ms.
P24 diagnostic không reproduce, không thay qualification. Nguyên nhân tail
UNKNOWN; không có rationale đổi SLO hoặc bỏ safety guards.

Chỉ kiểm giả thuyết nhỏ: exact PolicyConfig JSON projection có tránh generic
dataclass `asdict` deepcopy mà giữ nguyên bytes/digest/error semantics không,
và lợi ích component có đủ rõ để đề xuất integration sau này không.
Chưa gọi candidate là tail fix hoặc cache cấu hình của lượt trước.

## Scope

Candidate/proof harness/tests/raw chỉ dưới **artifact directory P26 mới**,
và docs/receipts. Không sửa src/tools/tests, global jsonable, production
collector/solver/BASIC, qualifier/verifier/model/source gates. Không attach/
read game/capture/input, UI/observer/worker launch, network, preferences/
claims/game files writes, build/version/Git. Không rerun full regression,
full collector diagnostic, qualification hoặc soak. Stop đúng P26.

## Công việc

1. Verify P25/P24 manifests/current source297 bab0145d…/host, existing P21
   failure/full2316PASS từ files; snapshot parents/claims6/current prefs/
   game4static hashes/HEAD/old UI prefix. Không restore P23 external settings.

2. Dựng pure candidate có thể dùng sau này riêng trong collector. Chỉ exact
   PolicyConfig shape và known scalar/Enum/None đi fast projection. Lấy đủ
   actual dataclass fields, unwrap Enum theo đường cũ; unsupported/new field
   types hoặc subclass dùng existing generic conversion. Không silent omission,
   ép kiểu numeric/string, cache digest hoặc giữ mutable reference.
   `canonical_json/digest` và exception validation giữ nguyên.

   Runtime source byte-preserved; không monkeypatch current production process
   hoặc shared `board_diagnostics.jsonable`. Candidate function được gọi trực
   tiếp trong harness trên fake configs, không truyền vào authority/collector.

3. Freeze deterministic parity corpus trước measurement, gồm từng18fields,
   all relevant Enum values, None/legacy mana, numeric/bool/boundary values,
   nonfinite/unsupported/fallback/subclass/new-shape cases và config replacement.
   Lập exact expected JSON/canonical bytes/digest hoặc exception từ legacy
   hiện tại. Không tự weaken legacy exceptions hoặc dữ liệu để candidate PASS.
   Config khác phải đổi digest đúng như legacy; không cache qua lần gọi.

   Có guard/fake validation cho no game/input/network/worker, pre-guard actual
   host capture, source/host/freeze tamper, durable attempt trước preflight,
   failed binding không tạo claim/raw và không retry. Tái dùng pattern P24
   đã sửa host; ghi harness SHA riêng, không sửa P24 artifacts.

4. Chỉ khi parity/guard proof PASS: freeze candidate/harness/corpus/protocol,
   một exclusive attempt cap60s, đúng12,000raw component records:
   A6000 legacy `digest(jsonable(config))`, B6000
   `digest(candidate_projection(config))`. Fixed blocks
   `A1500,B1500,B1500,A1500,A1500,B1500,B1500,A1500`; mỗi mode indices0..5999,
   warmup0..999, same per-mode index dùng cùng corpus config. Đọc file/format
   log/custom validation ngoài timer. Không loại warmup/outlier hoặc reset
   mỗi block, đổi threshold, affinity/priority/tắt GC, repeat-until-PASS.

   Lưu absolute perf timestamps/wall ns, config identity/index, output digest/
   parity result, counts/faults/cleanup và partial records nếu timeout/error.
   Không bắt buộc CPU dưới một ms từ GetThreadTimes vốn đã chứng minh quantized;
   nếu ghi CPU thì giữ limitation. Đây là component experiment, không giả
   lập whole-pipeline/native/qualification bằng số nhỏ hơn10ms.

5. Recompute all raw/quantiles/block-pair differences. Tiêu chí đã chốt trước
   data để chọn implementation proposal: toàn parity PASS, cả4index-matched
   block median(A−B)≥0.010ms, candidate aggregate p95≤legacy aggregate p95.
   Giữ raw max cả hai; không gọi sequence pairs là simultaneous/randomized.
   Nếu không đủ: NOT_PROVEN/INCONCLUSIVE, không đổi tiêu chí, thử candidate
   khác hoặc rerun trong P26. Nếu đủ: chỉ proposal cho collector integration
   sau này; chưa sửa source, source verifier hoặc chạy fresh qualification.

## Output và STOP

Viết `reports/5d1_p26_report.md`, candidate/harness/corpus manifests,
equivalence/guard proof, predeclared protocol/attempt/claim/raw hoặc lý do
không đo, recomputation/UNKNOWN/decision và final preservation.
P21 failure/max10ms giữ; candidate pass không accepted S/R/live authority.
Native U/transport/alignment null; strict/legacy/root250/final100/one-t0/
deadline/budget/guard/margin/source/witness/ACK/Stop/no-second-input giữ;
normal BASIC retention, không quota override.

Update STATUS/README/ROUTER/capability/index; chọn **exactly one next prompt**,
không tự thực thi. Không mở game/pilot hoặc resume P19/general SIMPLE/
CAREFUL/Demon/Mega/D1cap12/D2/Phase5 completion. **STOP P26.**
