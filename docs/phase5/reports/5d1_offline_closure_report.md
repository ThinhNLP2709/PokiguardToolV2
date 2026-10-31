# 5D.1 — Hoàn thiện toàn bộ phần offline

Ngày 2026-10-16. **OFFLINE COMPLETE / CURRENT LIVE PENDING**.
Parent/return: [prompt chính](../prompts/5D1_SIMPLE_CAREFUL_PILOT.md),
[report chính](5d1_report.md), [runbook](../research/5d1_pilot_runbook.md).
User yêu cầu gom phần thiếu vào một lượt, không tiếp tục sinh P.

## Thiếu sót đã xử lý và lý do

| Phần thiếu | Evidence trước sửa | Kết quả hiện tại |
|---|---|---|
| Native binding sau source changes | P27 review giữ H pending; P11/P15/P19 là nguồn khác | New current-native schema đòi raw cùng source/profile, không rebind mẫu cũ |
| CAREFUL trong launcher | Legacy check_launch_config chỉ SIMPLE + Starburst1289 | New protocol cho đúng SIMPLE/CAREFUL, boss explicit/current native witness; legacy guard giữ |
| Offline/current source package | Draft cha là scope P18 cũ | File-only controls/package tool, current raw/cost pins; draft false, activation independent |
| Source serialization cost | Existing collector dùng jsonable/asdict deep-copy immutable AutonomousSource | Uncached typed projection, fresh fields/hash; generic fallback khi shape/type unsupported |
| Roadmap phân mảnh | STATUS/ROUTER/index còn trỏ P29, nhiều current pointers lịch sử | Main D1 routing/report/runbook thống nhất; history chuyển tới archived bytes |

Current native validator kiểm source manifest/host/build, full config/policy,
equipped Attack, run/session/FarmRun/attempt ledger, raw sequence/watermarks,
input parameters/clock/derived intervals/source identity, sent/result order,
ACK hoặc strong terminal snapshot cùng session/turn/srv_seq + summary. Opening
cards[] chỉ giữ chi phí, không cấp full anchor. Read policy root250/final100
không bỏ native BASIC returns khỏi maxima. Calibration SIMPLE không cấp CAREFUL.

## Source và bảo toàn flow

Final source305 files:6 old files changed,4 new,295 old exact.
Fingerprint `c707890f44be01215f93876987c11f66fe4b19ad7b4ddefc33aeeb7d4e6b723f`; host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
[Freeze](../artifacts/5d1_offline_closeout_v1/source_freeze_final.json), [diff](../artifacts/5d1_offline_closeout_v1/source_changes_frozen.diff).

Ba runtime functions cũ thay đổi: load_operational_authority,
OperationalPilotLaunch.__init__, SwapTimingCollector.start. Các method khác
trong những file này giữ AST; BASIC/policy/controller/provider/executor/pacing/
ACK/room/Stop toàn file byte-exact. New helper chỉ được import khi opt-in
operational monitor + config-projection policy; BASIC/non-monitor giữ generic path.
No hash/witness reuse, no game read/capture, no new action/input owner.

Qualification tool thêm explicit profile + source policy marker, không đổi32
gate thresholds/call counts. Tests giữ historical source views, v4/P27 loader
vẫn reject source mới. Không đổi source sau final freeze/qualification.

## Candidate và diagnostic: không suy diễn nguyên nhân

97 parity cases PASS: exact JSON/exception, nested alias, mutation, unknown
shape/type/subclass/scalars/nonfinite. Candidate function AST exact khi tích hợp.
One actual validated component A/B run12,000raw/10,000measured theo block đã khóa:
legacy p50/p95/max0.0174/0.0284/0.7278ms; candidate0.0042/0.0060/0.1108ms.
4 paired median benefits0.0131/0.0132/0.0133/0.0134ms, vượt tiêu chí≥0.005ms.
[Proof](../artifacts/5d1_offline_closeout_v1/source_projection_proof.json), [component cost](../artifacts/5d1_offline_closeout_v1/source_projection_cost.json).
Đây là benefit component, không proof về tail cũ hay toàn pipeline.

One diagnostic37.703s không tái hiện≥10ms, max durable measured2.9621ms.
108,000 pipeline spans +18,000 empty spans; stage/parent/residual/GC raw được
kiểm độc lập. Original receipt COMPLETE mô tả loop, **integrity PARTIAL_RETENTION**:
prefix extracted trước chỗ qualifier ghi stop_raw, nên Stop1000 chạy nhưng
không durable;61,000/62,000 intended records. Admission observer không được
inject nên prefix GC phase vẫn mang fallback label; không quy GC theo admission.
[Recomputation](../artifacts/5d1_offline_closeout_v1/diagnostic_recomputation.json) giữ rõ hai gap, không dùng
diagnostic làm qualification. Không đo lại diagnostic để tìm PASS.

P21/P27 raw tails11.8417/10.4014ms và FAIL31/32 giữ nguyên. Exact causal field,
GC/OS/scheduler explanation vẫn UNKNOWN. Current qualification PASS chỉ thuộc
source hiện tại, không đổi kết quả lịch sử.

## Verification cuối

Full regression **2,355/2,355 PASS**,533.710s, gồm12 new D1 tests.
Controller fixtures dùng actual isolated CPU worker với native fakes cho cả
hai profile; normal và AI serializer fault giữ đúng read/input/ACK, một input
và một ACK. Loader/launch/config/raw tampering/failed costs/missing approval,
cross-profile cost và terminal proof controls được kiểm.
[Full log](../artifacts/5d1_offline_closeout_v1/full_regression_final.log), [verification](../artifacts/5d1_offline_closeout_v1/final_verification.json).

| Profile | Gates | Pipeline p50 / p95 / p99 / max (ms) | Raw / measured |
|---|---|---|---|
| SIMPLE | 32/32 PASS | 0.2170 / 0.4125 / 0.6004 / 6.7110 | 61,000 / 51,000 |
| CAREFUL | 32/32 PASS | 0.2222 / 0.4108 / 0.5802 / 5.4725 | 61,000 / 51,000 |

Hai qualification tuần tự, mỗi profile một invocation,60s stress, raw:
checkpoint30,000 + admission24,000 + pipeline6,000 + Stop1,000 =61,000;
measured51,000. Actual validated projection/monitor/root policy path, full raw
SHA and recomputation, original absolute pipeline max10ms unchanged. Stress là
receipt-only, không per-cycle trace hoặc whole-app/native guarantee.

## Attempts, corrections và historical preservation

Focused fixture failures ban đầu (enum/loadout/source pin/Attack witness) được
giữ ở focused01–04, đã sửa và focused05–07 PASS. Component preflight đầu tạo
attempt marker rồi lỗi trước measurement vì chưa freeze;0raw values, giữ
preflight_failure receipt. Chỉ một actual validated A/B measurement sau proof.

First broad regression bị chủ động dừng khi source review thấy draft mới còn
supplement7 của P18; không có test FAIL làm nguyên nhân dừng. Đã sửa metadata,
new test xác nhận supplement0/no stale missing16 claim. Final regression trên
source đúng mới là kết quả2355PASS. Source-audit receipt lần đầu dùng nhầm tên
biến output; log lỗi giữ nguyên, corrected final freeze không thay runtime bytes.

8,969 parent artifacts,6 old claims,4 game files,
HEAD và idle UI prefix đều giữ nguyên. Preferences hiện tại drift Mega→Demon
với saved_at19:46:01UTC, actor UNKNOWN; không có agent write/restore. Giữ actual
config và [drift receipt](../artifacts/5d1_offline_closeout_v1/preferences_drift.json), không restore snapshot đầu.
Qualification dùng frozen config riêng nên không bị đổi theo ordinary prefs.
Verifier đầu dùng nhầm default preferences path và dừng trước receipt; đã đối
chiếu đúng source preferences filename, không sửa runtime hoặc đo lại.
Không game attach/
capture/input/network/UI launch/live request/new claim/build/version/Git write.
Idle stream append nếu có được tách riêng khỏi native evidence.

## Return gate duy nhất

Chờ người dùng mở phòng Solo phù hợp BASIC, pet thường/tiến hóa thường + Attack,
chưa Start trong game; đối chiếu boss/pet rồi chuẩn bị SIMPLE BASIC3. Các controls
và reasoning arms nằm trong cùng cap12 của main D1. Native H/I/R vẫn PENDING,
U/transport/alignment UNKNOWN. Không fake acceptance hoặc tạo thêm batch/P.
Đủ live technical gates mới chốt5D.1 và chọn5D.2; E1/E2/F1 vẫn là gate riêng.
