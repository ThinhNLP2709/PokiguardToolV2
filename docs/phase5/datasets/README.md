# 5B.1 — Offline snapshot/replay dataset

Closure: **2026-10-09**, OFFLINE ONLY. [Report](../reports/5b1_report.md).
Entry: [A2 schema/features](../specs/5a2_features_utility_and_profiles.md),
[A3 diagnostics](../specs/5a3_telemetry_deadline_acceptance.md) và
[Demon incident review](../research/demon_shield_setup_incident_review.md).

B1 tạo codec và dữ liệu kiểm chứng cơ học; chưa planner/utility/boss policy,
worker/log sink, UI hoặc production adapter. Không import/wire FarmRunner,
provider hoặc executor mới. Không game attach/input/read/capture; BASIC v1.2.4
và các primitive hiện có không sửa.

## Implementation map theo repo thực

| File | Trách nhiệm / reuse |
|---|---|
| [reasoning_snapshot.py](../../../src/pokiguard_v2/reasoning_snapshot.py) | Frozen DTO SourceIdentity/SourceRecord/RunIntent/Action/Evidence/Snapshot/Candidate; canonical JSON, strict schema và content IDs |
| [reasoning_replay.py](../../../src/pokiguard_v2/reasoning_replay.py) | File dataset loader, chosen-action/source binding, same-session observation links, mechanical replay qua existing evaluate_all_moves/evaluate_demon_aegis_move |
| [reasoning_telemetry.py](../../../src/pokiguard_v2/reasoning_telemetry.py) | Bounded offline event codec; decision summary giữ baseline, no proposal/selection; chưa queue/writer/counters |
| [replay_reasoning.py](../../../tools/replay_reasoning.py) | Explicit file-only import/replay CLI, export giới hạn trong dataset directory, refuse overwrite |
| [test_reasoning_offline.py](../../../tests/test_reasoning_offline.py) | Schema/identity/immutability/attribution/corruption/split/bounds/incident controls |
| Existing BoardState/GemType/SwapMove + simulator/Demon | Reuse trực tiếp; không đổi core, solver priorities hoặc BASIC |

Không thêm import/export vào package init, Desktop UI/controller hoặc policy.
Existing package initialization giữ nguyên; new components chỉ được import
khi gọi offline CLI/tests trực tiếp.

## Manifest và data

[manifest.json](manifest.json) là input chuẩn cho loader:
- [demon_historical_v1.jsonl](demon_historical_v1.jsonl):26 records,3 matches
  có nguyên chuỗi10/12/4 local decisions, split development, tier H.
- [synthetic_mechanics_v1.jsonl](synthetic_mechanics_v1.jsonl):1 mechanics-only
  record trên screenshot board fixture cũ, context/identity synthetic, tier S,
  split regression. Không phải một trận live hoặc BASIC engine decision.
- [replay_events_v1.jsonl](replay_events_v1.jsonl):27 compact offline decision
  records; output dẫn xuất, không runtime telemetry hay counterfactual labels.
- [5b1_verification.json](5b1_verification.json): source/data hashes và closure evidence.

Historical inputs:3 combat files được hash-bind trong manifest; importer xác
minh nguyên chuỗi theo archive và10/10 archived boards/identity/source line.
Không copy raw screenshots, usernames, runtime pointers hoặc toàn bộ trace.
Raw logs trong logs/ ignored chỉ cần khi regenerate; replay/tests mặc định dùng
normalized data + checked-in incident archive/reference fixture.

Mỗi record có snapshot, chosen action_sent binding, terminal evidence và boss
action evidence. SourceRecord.line là1-based JSONL line; record_sha256 hash
decoded UTF-8 line content bỏ line ending. Với fixture JSON nhiều dòng,
line1 là đầu record và record_sha256 hash toàn bộ file. file_sha256 luôn hash
raw file bytes. board_hash nguồn khác snapshot_id content hash; không thay
provider hash bằng digest tự suy.

Session label derive từ run+published lifecycle epoch+MatchId, không lưu
board pointer. Actor number published được giữ; controller generation/account/
monotonic clock thiếu thì UNKNOWN/MISSING, không fake0 hoặc coi srvSeq là MatchId.
Baseline endpoints canonical để nhận diện swap, không coordinate/input script.
Native ActionId không có trong archive được giữ MISSING; candidate ID derive
không giả là executor ActionId.

Config chỉ chứa settings đã archive (Demon Sword3), partial/version/model scope
ghi rõ. Historical runtime binary/game build/full settings không đủ binding,
không gán HEAD hiện tại ngược thành source executable. Calibration20/30,
same-burst damage order, actual card costs/PASS/Stop/pending authority chưa được
validate từ dataset này; không dựa vào nó để phát action.

## Kết quả thực thi B1

Command:

```powershell
python tools/replay_reasoning.py replay docs/phase5/datasets/manifest.json
$env:PYTHONPATH = 'D:\PokiguardToolV2\src'
python -m unittest tests.test_reasoning_offline tests.test_board_simulator tests.test_demon_aegis_farm
```

- 27/27 root replay MATCH, trong đó26 historical +1 synthetic mechanics.
- 26/26 historical ordinary resource references khớp.
- 23/23 applicable pre-boss forecasts khớp;3 historical fire N/A +1 synthetic N/A.
- 23 same-session next-observation links; không link across match/actor/turn cũ.
- 10/10 archived snapshots khớp normalized boards/source hashes.
- 49/49 focused tests PASS:22 B1 mới +19 simulator +8 Demon hiện có.
Không chạy full suite/build/game/live; test duration không là latency SLO proof.

Regeneration chỉ khi yêu cầu tạo dataset mới, output directory chưa có files
cùng tên:

```powershell
python tools/replay_reasoning.py import-incident --archive docs/phase5/research/artifacts/demon_shield_incident_evidence_20261009.json --output-dir docs/phase5/datasets/new_export
```

CLI từ chối malformed/hash mismatch/duplicate continuation/split leak/inspected
holdout/tier mismatch/path escape; không tự sửa hay skip records để có PASS.
Tối đa512 records/32MiB dataset,512KiB input record; telemetry decision16KiB,
other event32KiB. Nonfinite/duplicate JSON keys/unknown schema reject.
Oversize là error có lý do, không truncate hỏng JSON hoặc phát input fallback.
Runtime fallback/log queue/error isolation thuộc B4/C, không codec này.

## Mechanical vs observed vs unavailable

Candidate schema v1 hiện có source/action membership, known ordinary physical/
effective tallies, round-local clear coordinates, UNKNOWN exposure và Demon
matched/sweep-union Sword geometry. Đây là DERIVED_SOLVER/CONDITIONAL_MODEL,
không actual damage hoặc boss reply. Không cộng ordinary totals với passive
aggregate vì original-cell/effect-order ledger chưa đủ joint support.
Point conversion, utility, post-boss setup/refinement/certificates giữ MISSING;
B2/B3 bổ sung đúng scope, không gán0.

Replay chỉ so root đã ghi và reference của nó; không rerun full BASIC engine.
Unknown observed gem/multiplier → UNSUPPORTED,0 compute pairs, không invent refill.
Opaque/non-SWAP baseline → UNSUPPORTED, không score0 hoặc tạo proposal.

action_sent chứng minh input attempt được record, không tự là ACK/terminal proof.
Terminal trong dataset này MISSING; tool chưa parse/claim all-match WIN/LOSS.
Outcome API chỉ cho observed chosen candidate; alternative luôn missing.
Next observation link chứng minh fresh later state cùng session, không cause
attribution cho boss/specific damage. Legacy last_move owner LOCAL_ROOT ở23
bound return records; boss action cả27 records MISSING.

## Coverage và handoff

| Requirement | B1 evidence / phần còn thiếu |
|---|---|
| DSI01–DSI03 repeated/independent lost forecast | Full actual root chains và next-state candidates; M_7d274339 3→5,13→15 và các match độc lập giữ identity/provenance |
| DSI04 retained controls | 17→19 giữ4 và M_632f0563 5→7 còn3; test không biến forecast change thành failure |
| DSI05 semantic progress | Full timeline, self/boss HP/resources/shield và policy steps cho decisions-before-first-passive; chưa implement planner history utility/loop policy |
| DSI06 source-owner missingness |23 local-root coordinate owner checks, no fake observed boss swap |
| DSI07 alternatives/bait | All known legal root candidates + unavailable counterfactual outcome/post-boss model; chưa chọn winner hoặc validate bait |
|50 A2 design cases | Chưa utility/refinement execution; chuyển B2/B3 theo owner trong matrix |
| Six profiles | Historical chỉ Demon; SIMPLE synthetic mechanics, các profile khác chưa efficacy/flow coverage |
| Independent holdout |0;3 matches đã inspected development, không validation/live trial |
| Production parity/latency/fallback |NOT_MEASURED/NOT_IMPLEMENTED; B4/C3/C4/D/E/F gates còn nguyên |

No superiority/win-rate/energy/throughput claim. BASIC default và runtime
REASONING placeholder giữ nguyên. **Next5B.2 khi được yêu cầu; STOP ở5B.1.**
