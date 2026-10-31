# 5D.1-P9 — Hoàn thiện đề xuất timing, offline

2026-10-14 (Asia/Saigon). **OFFLINE PROPOSAL COMPLETE / USER DECISION PENDING /
PARTIAL D1.** Người dùng đã quay lại luồng chính sau side fixes. P8 đóng,
không mở lại observation; thực hiện đúng [prompt P9](../prompts/5D1_P9_OPERATIONAL_TIMING_CONTRACT_PROPOSAL.md).

Đã hoàn thiện [một operational timing contract](../research/5d1_p9_operational_timing_contract.md)
để người dùng review. Chưa áp dụng contract, sửa runtime hoặc bật AI input.
Chưa cần mở game/chạy live.

## Kết luận

Finite native U vẫn UNKNOWN: local clock samples không chứng minh tuổi dữ liệu
server. Strict loader hiện tại đúng khi từ chối thiếu proof; không dùng P8 để
manufacture proof hoặc hạ gate âm thầm.

Có thể tiến hành pilot hữu hạn theo operational projection nếu người dùng
chấp nhận residual late-action risk. Phương án cụ thể giữ BASIC trước, cùng
snapshot cho worker, absolute budget từ observation-start, return sớm/Stop,
zero extra reads và existing fresh/final/input/ACK flow. Tạo type/loader/context
operational riêng, không sửa nghĩa finite-U authority cũ.

Rà source phát hiện reserve hiện mới đo final-preflight→executor-return,
thiếu đoạn decision-exit→final-preflight. Proposal bao cả đoạn này, selector
overhead, full commanded wait ceiling của BASIC fallback và additive guards.
H/I/overhead/read-span thresholds còn PENDING; không suy từ fixture hoặc P8.
Không hard-code một reserve1–2s. Future BASIC-only calibration default3/max5
TOTAL attempts chỉ đo operational envelope; không prove server-clock bound.

## Trace source hiện hành

[Ledger](../artifacts/5d1_operational_timing_proposal_v1/source_gate_ledger.json)
có31gates/13files, exact line ranges, SHA256 và source excerpts. Phân biệt
software predicate đã hiện hữu với physical assumption chưa chứng minh:

| Đường hiện có | Finding |
|---|---|
| Provider timer + observation | Raw integer có range validation; host timestamp bao existing poll; không tick receipt age |
| BASIC/worker/wait | BASIC trước; same immutable state/incumbent; event wait≤5ms requested; current configured cap read-end+B |
| Deadline/authority | Strict native loader finite5-component U; provenance/source/build/config/model/witness pin; default4s/cap6s |
| Selector/fresh/final | Exact binding, legal one-step robust interval proxy, same existing checkpoints; expired proposal không input |
| Executor/ACK | `reasoned=True` chỉ valid receipt bỏ optional random; base pacing/foreground giữ; ACK từ actual send, không second-input fallback |
| Collector/calibration | Timing bắt đầu tại final preflight; BASIC-only claim/cap/expiry có sẵn; chưa đo native R |
| UI/fault isolation | REASONING vẫn gated; optional factory lỗi→BASIC; worker breaker persistent/3consecutive/5of20; logs có caps |

Comment “integer timer conservative” trong pacer không là bằng chứng transport.
5ms event wait,250ms guard,100ms margin và command sleep ceiling không là OS/
server guarantee. Source279 reviews của P7/P8 vẫn giữ historical scope; không
rebind sang current source280 sau hai side fixes.

## Decision package đã chuẩn bị

Proposal có before/after, tên/units/provenance và công thức deadline/reserve;
schema/type/context mới cần triển khai; invalidation/breaker/fallback/rollback;
all-attempt telemetry; offline/live acceptance và finite future calibration.
Mục9 liệt kê chính xác doc/code gates cần đổi ở milestone kế nếu chấp nhận.

Chỉ có một recommended contract. Alternative khi user không chấp nhận là giữ
strict/BASIC và dừng nhánh operational timing, không thêm research/live batches
để tìm finite U từ dữ liệu không thể chứng minh điều đó.

User decision cần chốt: cho phép **offline implementation/readiness** của
operational opt-in, biết có thể hụt lượt do server/timer/OS delay chưa bound;
giữ BASIC mặc định và mọi input/state/owner gate hiện có. Quyết định này chưa
kích hoạt calibration/D1 input hoặc UI REASONING đại trà. P2 budget consent
không tự cấp sự chấp thuận cho assumption timing mới.

## Bảo toàn và verification

Artifact root:
[5d1_operational_timing_proposal_v1](../artifacts/5d1_operational_timing_proposal_v1/before_snapshot.json).
Before-doc bytes và actual operator preferences bytes được lưu riêng trước
khi cập nhật pointer. Không ghi lại preferences thật.

- Source280/280 Python files giữ byte; fingerprint
  `4260c002196135ca9eebaff9180d428976d83d518746993d812182cff15713c6`.
- 1,982parent artifact files của Phase5 + hai side fixes giữ byte và file set;
  observation P8 SHA `263ff27395426680780aed8d5f8d9a1210dcae2fc000d593ec9fc621e7fa48be` giữ nguyên.
- Bốn game files b6 giữ SHA; game installation chỉ đọc file để đối chiếu.
- Operator preferences SHA
  `f7d04afc49112093b1d5c1a82693fdbe53dc4b6ff8f9960c83725872b2aa3d0c` giữ nguyên.
- HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29` giữ nguyên; package/version không đổi.
-0process query/attach/native read/capture/input/network/test/soak/build/Git mutation.

File-only verification kiểm source/artifact/game/preferences/HEAD,31source
excerpts/hashes và local links. Không chạy gameplay tests cho docs-only step,
không relabel kết quả tests trước thành acceptance của proposal.
Chi tiết: [verification](../artifacts/5d1_operational_timing_proposal_v1/verification_final.json),
[manifest](../artifacts/5d1_operational_timing_proposal_v1/artifact_manifest.json).

## Next duy nhất — quyết định của người dùng

**USER DECISION PENDING** trên proposal mục1. Chưa chọn/triển khai code hoặc
live batch kế tiếp. Khi chấp nhận: một milestone offline implementation/readiness
đúng mục9, chưa game. Khi không chấp nhận: giữ strict/BASIC. **STOP P9.**
