# 5D.1-P26 — PolicyConfig serialization candidate proof, offline

2026-10-16 (Asia/Saigon). **PARITY PASS / COMPONENT BENEFIT PASS SCOPED /
NOT INTEGRATED / PARTIAL D1.**
[Prompt](../prompts/5D1_P26_POLICY_CONFIG_SERIALIZATION_PROOF_OFFLINE.md),
[parent P25](5d1_p25_report.md),
[decision](../artifacts/5d1_config_serialization_proof_p26_v1/decision.json).

## Kết quả

Candidate chuyển cấu hình sang JSON đã qua **118 parity cases**, **7 guard
validation cases** và một cost experiment đủ **12,000raw samples**,
exit0/0.8109072s dưới cap60s. Đạt toàn bộ tiêu chí đã chốt trước measurement.
Đủ bằng chứng đề xuất tích hợp hẹp vào collector ở bước sau.

**Chưa sửa src/tools/tests hoặc runtime.** P21 vẫn31/32qualificationFAIL
với sample2789=11.8417ms >max10ms. Component experiment không thay full
pipeline qualification, không xác định nguyên nhân mẫu cũ và không tạo
accepted allowance/reserve/live authority.

## Candidate và parity

[Candidate](../artifacts/5d1_config_serialization_proof_p26_v1/harness/config_projection_candidate.py)
chỉ chạy trên exact PolicyConfig có đúng18field names và known scalar/Enum/
None values. Mỗi lần gọi đọc lại tất cả fields và tạo dict mới; không giữ
config/JSON/digest từ lượt trước. Unknown type/schema/subclass đi original
generic jsonable. Canonical JSON/digest vẫn là hàm hiện tại, không bỏ validation.

Đã kiểm [118cases](../artifacts/5d1_config_serialization_proof_p26_v1/parity_proof.json):

- Tất cả relevant Enum values, legacy mana/None, từng18fields và numeric/
  bool/boundary/Unicode values; exact canonical text, UTF-8 hash và digest.
- Nonfinite, oversize, unsupported list/dict/set/custom enum/int subclass,
  subclass/new shape, generic object và deepcopy exception; cùng outcome/
  exception type/message với legacy.10cases gọi generic fallback thật.
- Config replacement từng18fields đổi digest đúng như legacy, đổi lại base
  không bị cache. Forced change trên cùng local fixture object cũng được
  đọc lại; đây là fake test, không sửa cấu hình tool.
- Dict kết quả tách rời; sửa output không sửa input hoặc output lần sau.
  Shared `board_diagnostics.jsonable` giữ nguyên, candidate không được truyền
  vào collector/authority/solver hoặc production process.

Malformed fixtures chỉ kiểm serializer semantics, không chứng minh cấu hình
đó hợp lệ để chơi hoặc bypass config validator. Benchmark corpus là **67
unique valid configs** được revalidate qua PolicyConfig constructor, loại
forced/fallback/error fixtures. Corpus có cả giá trị intelligence để kiểm
serialize; không tạo worker hoặc đổi real settings.

Guard/host helpers được copy exact AST từ P24 vào artifact riêng; actual
host capture trước guard/project imports, durable attempt trước preflight.
[Guard proof](../artifacts/5d1_config_serialization_proof_p26_v1/guard_validation.json)
kiểm native/input/network/worker/solver stubs, host/source/freeze tamper,
failed-preflight consumption và retry rejection, fake60s cap/indices/calls.
Không dùng clocks thật để đo performance trong validation.

## Component-cost experiment

[Frozen protocol](../artifacts/5d1_config_serialization_proof_p26_v1/protocol.json),
[manifest](../artifacts/5d1_config_serialization_proof_p26_v1/frozen_manifest.json),
[recomputation](../artifacts/5d1_config_serialization_proof_p26_v1/component_recomputation.json).
Một attempt duy nhất, không retry hoặc chỉnh candidate/criterion sau data.

Đo nguyên expression A=`digest(jsonable(config))`,
B=`digest(project_config(config))`. Cùng frozen corpus/config theo index;
fixed blocks A/B/B/A/A/B/B/A,1500samples/block. Mỗi mode6000raw,
1000warmup +5000measured, không warmup lại mỗi block. IO/format/custom
validation ngoài timer; giữ toàn bộ warmup và outliers.

| Projection + digest | p50 | p95 | p99 | Max |
|---|---:|---:|---:|---:|
| Legacy A | 0.0781ms | 0.1157ms | 0.1808ms | 5.9308ms |
| Candidate B | 0.0246ms | 0.0394ms | 0.0544ms | 0.1788ms |

P50 giảm khoảng68.5% **của component này**; không phải whole-turn/game
speedup. Four index-matched block-pair median A−B:
**0.0533 /0.0535 /0.0534 /0.0533ms**, đều≥0.010ms đã chốt trước.
Candidate aggregate p95≤legacy p95, toàn measured/raw digest parity PASS.
Các pair tuần tự, deterministic; không gọi là randomized hoặc simultaneous.

Recompute đủ12,000records/2000warmups/10,000measured: exact indices, schedule,
config identities, clocks và output hashes. [Tail windows](../artifacts/5d1_config_serialization_proof_p26_v1/tail_windows.json)
giữ toàn raw≥1ms và top10 mỗi mode. Legacy max5.9308ms không bị loại hoặc
quy thành OS/GC noise. Không đo CPU vì empirical15.625ms ticks ở P24 không
đủ cho component này; GC không force/disable, không đổi priority/affinity.

## Giới hạn và bước kế

[Integration proposal](../artifacts/5d1_config_serialization_proof_p26_v1/integration_proposal.json)
accepted=false/implemented=false: tái dùng đúng candidate đã prove tại
config projection của reviewed successor operational collector; inline ở
vị trí digest argument hiện có. Giữ argument order, current state/config,
witness/source hashes, timestamp boundaries, monitor, root metadata,
encode/enqueue, faults, BASIC fallback và no-second-input.

Legacy/no-authority/v2/v3 generic path phải giữ output/exception semantics;
không sửa global jsonable hoặc BASIC/reader/controller/executor. Cần exact
source successor review riêng; v4/current297 review không được repin để
grandfather code mới. Sau integration mới có meaningful regression, source
freeze và đúng một qualification của actual new source, giữ đủ32gate meanings
và max10ms. Nếu không đạt thì giữ failure, không rerun tìm PASS.

[UNKNOWN ledger](../artifacts/5d1_config_serialization_proof_p26_v1/unknown_ledger.json)
giữ whole-pipeline benefit, historical tail cause, native timing/source binding
và future accepted S/R pending/null. Component improvement không chứng minh
tail đã được sửa, không giảm reserve/guard/margin hoặc bỏ native review.
Native U/transport/alignment vẫn null; root250/final100 opt-in chưa live.

## Preservation và STOP

P25 manifest17artifacts/7docs, P24 artifacts38/archived docs và P21 failed
qualification/full2316PASS footer được verified; không chạy tests cũ.
Source297 vẫn `bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`,
host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Parent7,720artifacts/6claims/current prefs/game4files/HEAD được bảo toàn;
P23 external UI closure/settings giữ làm baseline, không native evidence mới.
[Final preservation](../artifacts/5d1_config_serialization_proof_p26_v1/verification_final.json).

Chỉ artifact candidate/harness/proofs/component raw và docs mới. Không game
attach/read/capture/input, UI/observer/worker/network, source/runtime/flow/
model/weights/input pacing/ACK/Stop change, preferences/claims/build/version/
Git writes hoặc full pipeline/qualification/soak rerun. Native API import
DPI vẫn bị Python stub chặn; guards restore sau isolated process. BASIC
retention là bình thường, không quota đổi nước.

Next duy nhất **[P27 collector integration OFFLINE](../prompts/5D1_P27_COLLECTOR_CONFIG_PROJECTION_INTEGRATION_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game; không resume P19/general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc Phase5 completion. **STOP P26.**
