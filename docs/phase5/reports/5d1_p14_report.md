# 5D.1-P14 — Operational launch readiness, offline

2026-10-15 (Asia/Saigon). **PASS SCOPED OFFLINE / PILOT NOT ACTIVATED / PARTIAL D1.**
Parent [P13](5d1_p13_report.md), [prompt](../prompts/5D1_P14_OPERATIONAL_PILOT_LAUNCH_READINESS_OFFLINE.md).
User đã yêu cầu tiếp tục và làm rõ suy luận không phải luôn đổi nước so BASIC.
Source version **1.2.5**, HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`.
Không build/version/Git mutation. Efficacy **NOT_APPLICABLE**.

## Quyết định và kết quả

Đã ghi [clarification trong contract](../EXECUTION_CONTRACT.md): suy luận đánh
giá lựa chọn tốt nhất theo dữ liệu/mục tiêu hiện có. Giữ nguyên nước BASIC là
kết quả bình thường; không quota hoặc tỷ lệ bắt buộc đổi nước. Completed
`RETAIN_BASELINE` được phân biệt với timeout/error/unsupported. Không sửa planner,
model/weights, BASIC hoặc evidence để ép khác biệt; không hứa global optimum.

Đường source-only request riêng đã nối vào desktop launcher bằng flags ẩn
`--operational-pilot-request` + `--operational-pilot-sha256`. Không flag thì
BASIC/default path giữ. Không mở UI REASONING đại trà.

[OperationalPilotLaunch](../../../src/pokiguard_v2/reasoning_operational_launch.py)
chỉ setup/file validation: request SHA, source/host/build/executable, full
config/policy, exact P11 witness, independent activation review, expiry/cap và
existing consumed claim. Preview không tạo worker/claim. Manual Start đi qua
existing manager gate, tạo đúng một OperationalPilotSession và exclusive claim;
factory chỉ giao session một lần. Existing FarmRunner/bind/Stop/cleanup giữ.
Không restart/resume/reset consumed cap. Lỗi setup request tường minh bị từ chối
trước runtime/Tk, ghi `OPERATIONAL_PILOT_REJECTED`; log được đóng khi từ chối.

Private session preferences áp dụng cả success/rejection, không ghi ordinary
preferences. Đã test binding vào factory/calibration_gate hiện có, không thêm
controller/game loop hoặc đọc memory/capture/input để chờ suy luận.

## Setup policy correction

Native P11/combat controller dùng `minimum_action_time=1`; session setup trước
đó so `basic_policy_config(config)` với default minimum-turn3. Hai canonical
policy hash khác nhau, làm request calibrated1 bị từ chối ở Start dù actual
gameplay đúng. [Before/after binding](../artifacts/5d1_operational_launch_p14_v1/policy_binding_before_after.json):

```text
old setup default: 19e787fba91ee5b7e2a1187d0cd5fda9f7b5d9d0a45bdea90fbb5572abb4c0fd
native / new setup: dca44f74a20cf801f4cae08732e084ddcf2d51ed249ddd602b13cea6d4188a9f
```

Sửa duy nhất setup policy validation: nhận canonical controller policy1, đồng
thời giữ legacy canonical policy check. New launch gate bắt buộc exact policy1.
Không đổi PolicyConfig defaults hoặc controller minimum-action-time/gameplay.
Native runtime witness/equality/deadline/strict finite-U loader giữ nguyên.

## Draft và provenance

[Draft builder](../../../tools/prepare_operational_pilot.py) là file-only,
không có lệnh accept/activate. Recompute raw qualification summaries/CPU/pipeline/
Stop/source pins và thresholds trước khi xuất allowance; không chỉ tin PASS flag.
Bounded paths/output tách input, không overwrite package cũ.

[Draft cuối](../artifacts/5d1_operational_launch_p14_v1/pilot_draft/pilot_draft.json)
ghi accepted=false/live_acceptance=false/override_quota=null/run_id=null/
expires_at=null/claim_created=false. Có request template, config và refs cụ thể,
nhưng không là request live. Real launch gate đã được kiểm sẽ reject chính draft
này trước game callback. Không tạo accepted live review hoặc claim thật.

Scope duy nhất: same P11 account, SIMPLE/SOLO/Starburst1289lv73/Phoenix-user-declared,
normal→normal/default_attack, foreground/two_click, target3/max3TOTAL attempts.
Native structural fusion/card witness giữ; cards[]/mismatch giữ BASIC, không
read/chờ thêm. Full observed Attack witness không là proof effect/damage/name pet.

Native source284 `bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f`,
base P13 source287 `3fb6430aff31ceac4224b0bdbcb012352b84b6fcbcae68a0d1fb1b6384591fe3`,
final P14 source290
`10cc39c2e323cb697c0dea4c04b5c541ce4eee0b22342283996c54700126c62a`
được giữ riêng trong [compatibility chain](../artifacts/5d1_operational_launch_p14_v1/review_final/source_compatibility.json).
Không relabel source hoặc dùng lại old allowance. Exact successor whitelist
chỉ5setup/export/audit files và3new files; operational module chỉ được đổi đúng
policy-validation bytes. Một test sửa runtime stop trong chính file setup quen
thuộc vẫn bị reject, không generic method exemption.

Original v1 export/errors/raw30rows/3attempts/20ACK anchors/26host intervals,
3terminal-no-ACK/4EVOLVE decisions,22archived files và3consumed claims giữ nguyên.
Reserve vẫn từ cả26returns; legacy v1 và strict finite-U không được nới.

## Final checks trên source frozen

**15new tests PASS; full regression 2,226/2,226 PASS trong341.373s**,
[raw log](../artifacts/5d1_operational_launch_p14_v1/tests_full_final.log).
Cases gồm preview không resource, policy1 real session claim, independent
approval, cap/expiry/config/policy/resume, source/host/build/selected file drift,
request tamper, consumed claim/no restart, failed bind giữ BASIC/claim, invalid
request trước native/Tk, default flags, private preferences/factory wiring,
raw qualification tamper và draft không activation. Native surfaces/factory
được fake rõ; accepted review trong tests chỉ ở temp root, không live authority.

[Fresh qualification](../artifacts/5d1_operational_launch_p14_v1/qualification_final/qualification.json):
**23/23gates PASS**. Reuse qualifier code/schema version P13 nhưng phép đo mới
pin **current P14 source10cc39…**, không dùng acceptance P13 cho source mới.
1,000warmup +5,000measured/path; raw checkpoint/pipeline/Stop/source files giữ.

| Three checkpoints, ms | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| disabled | 0.0002 | 0.0002 | 0.0003 | 0.0015 |
| completed | 0.6809 | 1.1085 | 1.5044 | 9.0786 |
| timeout | 0.6749 | 0.9931 | 1.3987 | 1.9644 |
| error | 0.0428 | 0.0590 | 0.1088 | 0.3272 |
| fallback | 0.2836 | 0.4045 | 0.6591 | 1.2637 |

Giữ thresholds p50≤1.5/p95≤3/p99≤9/max≤30ms. Added mean CPU0.721875ms
so disabled, dưới1.5ms/three checkpoints. Host pipeline p50/p95/p99/max
0.2321/0.3637/0.5693/5.9319ms, dưới0.5/1/3/10ms.1,000Stop max0.0421ms,
worker reaped.60.00056s stress/150,297cycles/max1record/traced peak9,429B.
5disabled traces normal/pending/stale/wrong-turn/Stop và optional controller
AST exact. Không sửa source giữa full run/qualification, không nới threshold
hoặc lặp benchmark để tìm PASS.

Completed worker chọn `BASELINE_TOP_IN_TOTAL_ORDER` và giữ BASIC tại cả3checks.
**Đây là normal reasoning outcome**, không failure hoặc quota thiếu. Nhánh
accepted override có synthetic software tests sẵn trong suite, latency nhánh
đó chưa đo riêng trên native cohort. Không claim latency branch đó, efficacy,
whole-app/native/VM soak; bounded pilot review phải công bố limitation.

Development test bắt lỗi log chưa close ở early rejection; đã sửa trước freeze,
raw failure giữ tại development_tests_02. Không game run bị ảnh hưởng.

## Reserve, preservation và next

Fresh current-source allowance max9.0786ms. Hmax164.429ms/Imax2972.325ms,
command3060ms/guard250ms cho **R_op descriptive6455.8326ms**, floor3000ms,
margin100ms/read-span policy100ms. Native U/transport/alignment null;
first exact click NOT_MEASURED, sample max không future hard bound.

282/287parent sources giữ byte;5changed +3new, [source manifest](../artifacts/5d1_operational_launch_p14_v1/final_test_source_manifest.json),
[exact diffs](../artifacts/5d1_operational_launch_p14_v1/source_diffs/). Reader,
BASIC/solver, combat controller/desktop manager, entry correction, screenshots,
executor/random/pacing/input/ACK/room/recovery, selector/planner/pilot runtime và
strict finite-U giữ byte. Chỉ setup thêm launch gate, dùng existing hooks.

[Final verification](../artifacts/5d1_operational_launch_p14_v1/verification_final.json):
3,049parent artifact files/59native pins/4game files/HEAD/preferences giữ;
final290sources frozen. Existing UI log prefix giữ,0append trong P14.0agent
game query/attach/read/capture/input/network, không UI/game/observer launch,
không build/version/Git mutation/real preference write. BASIC/shadowOFF giữ.

Next duy nhất **[P15 bounded SIMPLE operational pilot](../prompts/5D1_P15_BOUNDED_SIMPLE_OPERATIONAL_PILOT.md)**,
SELECTED ONLY/NOT PREPARED/NOT ACTIVATED. [Runbook](../runbooks/5d1_p14_operational_pilot_launch.md)
đã có thao tác/cohort/cap và request checks. Bước sau cần user chuẩn bị đúng
phòng/loadout, kích hoạt một bounded request mới và manual Start; P14 không
thực thi live. Chưa D1cap12/CAREFUL/Demon/Mega/D2. **STOP P14.**
