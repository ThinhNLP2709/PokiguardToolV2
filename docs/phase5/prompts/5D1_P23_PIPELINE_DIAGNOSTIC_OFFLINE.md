# 5D.1-P23 — Chẩn đoán collector pipeline bằng dữ liệu giả, offline

**SELECTED ONLY / NOT EXECUTED.** Một milestone offline; chưa cần mở game.
Đọc AGENTS, STATUS, ROUTER, EXECUTION_CONTRACT, capability,
[P22 report](../reports/5d1_p22_report.md),
[boundary map](../artifacts/5d1_pipeline_tail_review_p22_v1/pipeline_boundary_map.json),
[measurement proposal](../artifacts/5d1_pipeline_tail_review_p22_v1/diagnostic_measurement_proposal.json),
[UNKNOWN ledger](../artifacts/5d1_pipeline_tail_review_p22_v1/unknown_ledger.json).

## Entry và mục tiêu

P21 source297 `bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`
giữ functional regression2316PASS nhưng qualification31/32FAIL: pipeline
index2789=11.8417ms >max10ms. Original failure và raw phải giữ nguyên.
P22 đã kiểm lại61,000raw/51,000measured, chưa đo mới hoặc xác định nguyên nhân.

Root metadata setup ở ngoài timer; payload copy/encode ở trong. Pipeline
AST và collector ngoài `__init__` giữ P18. Có3critical hashes nhưng chưa biết
cost. Cần cùng-sample wall/CPU/stage evidence và payload-only control; chưa
có căn cứ sửa gameplay, cache guards hoặc nâng SLO.

## Scope

Chỉ standalone fake-only diagnostic harness dưới **artifact directory P23
mới** và docs/receipts. Pin SHA harness riêng, không dùng runtime fingerprint
đơn lẻ thay cho harness provenance. **Không sửa src/tools/tests**, production
collector, qualifier, loader/verifier, model/weights/BASIC hoặc source gates.
Không attach/read game, capture/input, UI/observer/worker launch, native/API/
network calls, preferences/claims/game-file writes, build/version/Git.

Không rerun qualification/tests/soak cũ để tìm PASS. New harness validation
chỉ dùng fake clocks/sinks, kiểm đúng boundaries/raw coverage trước invocation.
Không chạy full regression cho thay đổi docs/harness biệt lập không đổi runtime.
Không sửa source để làm diagnostic dễ PASS.

## Công việc

1. Verify P22/P21 manifests, source297/host, original failed raw và P21 full
   regression footer từ file. Snapshot parent artifacts/6claims/ordinary
   prefs/4static game hashes/HEAD và idle UI prefix. Host/source khác thì
   ghi mismatch, không giả binding hoặc chạy phép đo theo source cũ.

2. Dựng harness gọi **actual current SwapTimingCollector** theo sequence
   P21 `qualify_reasoning_operational.py:193–202`, synthetic `native_state`,
   config/PARAMS/authority giống P21 và root250/final100. Không gọi qualifier,
   solver, PilotSelectionBridge, input executor hoặc provider. MemorySink mới
   mỗi sample. Setup/authority identity/sink allocation ngoài timer; raw IO
   và post-timer validation ngoài timer, giống boundary gốc.

   Chặn native entry points fail-closed trong process harness; guards phải
   có receipt và fake validation. Không monkeypatch production process hoặc
   game. Wrap current methods trong process riêng cho profile, restore trong
   finally; code byte và guards gốc giữ nguyên.

3. Freeze harness/protocol trước **đúng một diagnostic invocation**, cap120s,
   không retries hoặc run-until-outlier/PASS. Total19,000records:

   - A current control6,000; B metadata-omitted control6,000. Fixed blocks
     `A1500,B1500,B1500,A1500,A1500,B1500,B1500,A1500`.
     Chỉ B bỏ field root policy khỏi collector's payload metadata cache,
     ngoài timer, sau construction. Không đổi immutable authority, identity,
     config/witness/source hash, monitor hoặc enqueue. B chỉ là synthetic
     counterfactual **không hợp lệ để dùng cho live/calibration/qualification**.
   - Profile current6,000 sau A/B, giữ metadata và GC mặc định.
   - Empty instrumentation1,000 sau profile để quan sát overhead clock/wrapper;
     giữ toàn bộ, không gọi đây là pipeline dataset.
   - Từng pipeline mode có index0..5999, warmup0..999 và5,000measured. Không
     warmup lại mỗi block, đổi số mẫu, trim, pool, subtract overhead lấy PASS
     hoặc đảo schedule sau khi xem data. Không đổi affinity/priority/tắt GC.

4. Lưu nguyên raw: mode/index/warmup, absolute host begin/end, wall ns,
   same-sample thread/process CPU endpoints, event bytes/count, collector
   fault và validation/cleanup receipts. CPU endpoints nằm ngoài wall markers
   và enclosure/clock overhead phải được mô tả. Record actual clock info;
   coarse/zero CPU values không được diễn giải như precise zero CPU cost.

   Profile các top-level observe/decision/checkpoints/caller-hash/start/
   preflight/finish; nested critical hash/monitor/encode/enqueue có parent IDs
   và inclusive spans. Không cộng trùng nested durations hoặc serialize/
   format log bên trong timed interval. GC callback trace chỉ trong profile,
   bounded buffer, timestamps/overlaps; không force/disable GC. Chênh wall/CPU
   hoặc overlap chưa tự chứng minh OS descheduling hay GC là nguyên nhân.
   Nếu không thể thu field an toàn, giữ UNKNOWN, report limitation; không
   silently đổi protocol. Timeout/fault phải persist partial raw và cleanup,
   không resume để bù số mẫu.

5. Đối chiếu exact call coverage và all raw, report p50/p95/p99/max theo
   nearest rank, stage/CPU distributions, raw windows của mọi mẫu lớn,
   A/B block differences và instrumentation overhead riêng. Original max10ms
   vẫn nguyên; diagnostic không có qualification `pass_all=true` hoặc
   allowance/reserve accepted dù toàn mẫu mới dưới10ms.

   Nếu có stage cost và paired evidence đủ thì chọn đúng một targeted offline
   remediation proposal bảo toàn guards. Nếu không reproduce hoặc thiếu
   causal evidence thì ghi INCONCLUSIVE/UNKNOWN, không quy original sample
   thành noise. Future profile không hồi tố được lịch sử index2789.
   Không tự sửa runtime, đổi SLO, chạy fresh qualification hoặc mở pilot trong P23.

## Output và STOP

Viết `reports/5d1_p23_report.md`, harness/protocol/source manifests, fake
validation receipt, single-invocation raw + trace/overhead/timeout/cleanup,
recomputation/UNKNOWN/decision và final preservation. Protocol/report giữ
accepted/live/input/production activation=false; future accepted S/R null.
Native U/transport/alignment null, strict finite-U/root250/final100 và
one-t0/deadline/budget/guard/margin/Stop/ACK giữ. Retain BASIC bình thường,
không quota đổi nước. Không dùng P18 PASS hoặc P21 descriptive S24.4372/
R6772.1419 làm accepted allowance.

Update STATUS/README/ROUTER/capability/index. Chọn **exactly one next prompt**
từ evidence; không tự thực thi nó. Không resume P19, activate pilot mới,
general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc Phase5 completion.
**STOP P23.**
