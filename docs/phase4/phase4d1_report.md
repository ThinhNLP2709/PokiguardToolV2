# Phase 4D.1 — Foreground vs Pinned Foreground Beta A/B

Result hiện tại: **PASS STRONG**

Entry gate Phase 4C.2: `PASS STRONG`.

## Phạm vi

So sánh correctness/reliability trên cùng source, game build, boss và gameplay
configuration:

- A: foreground mặc định;
- B: pinned foreground lease Beta;
- 5 completed matches mỗi nhánh, tối đa 8 attempts;
- A chạy trước B;
- đây không phải benchmark hiệu năng hoặc năng lượng.

## Offline implementation

- `src/pokiguard_v2/phase4d1_benchmark.py`: analyzer chỉ đọc run/checkpoint/event
  và combat artifact;
- `tools/phase4d1_benchmark.py`: prepare/assign/analyze CLI;
- `tests/test_phase4d1_benchmark.py`: gate controlled pair, mode/config mismatch,
  extra attempt, lease cleanup, foreground lease leakage, pending run và source
  drift;
- [manifest](artifacts/phase4d1_manifest.json): source fingerprint, game hash,
  exact config, order và focus schedule;
- [live runbook](phase4d1_live_runbook.md): kịch bản B1/B2.

Analyzer ghi:

- completed/attempt/W/L/U và final controller/lifecycle;
- queued/sent/ACK/unconfirmed theo input domain;
- ACK latency khi artifact có hai đầu timestamp;
- critical stale/duplicate/partial/wrong-turn/lifecycle counters;
- mouse/QTE lease count, takeover count, duration, cursor/focus/guard cleanup;
- technical abort/recovery/exit/safe stop;
- source/game fingerprint validation.

## Frozen evidence

- app: `v1.1.0`;
- source commit: `e6463040cee82d155c33d285893a73d70432637f`;
- source workspace fingerprint:
  `8f60fdfa60fc56703d59ea9018cb2942c4bec4291ade621a3d76f6d2e01fbeb3`;
- game executable SHA-256:
  `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887`;
- GameAssembly SHA-256:
  `E2A2457128B4F412EAE302AC5314350F0C18529C12716B4EBDB36281D923F9E9`.

## Offline validation

- focused tests: `9/9 PASS`;
- full suite: `1591/1591 PASS`;
- `compileall`: PASS;
- `git diff --check`: PASS (chỉ có cảnh báo line ending của working tree);
- analyzer smoke trên run 4C.2 `f591da152cbe47dd9b7ef501f9c079a8`:
  accepted `3/3`, 22 mouse leases, 3 QTE leases, zero unconfirmed input và zero
  critical counter. Run này chỉ là smoke vì target của 4D.1 là 5, không được dùng
  thay B live.

## Live checkpoint

| Arm | FarmRunId | Result |
|---|---|---|
| A_FOREGROUND | `a32e8eb15136456ca9231cb29934e3da` | PASS — 5/5 WIN, đúng foreground |
| B_PINNED_FOREGROUND_BETA | `ee17b4a58a14430ba1d394620edb7d26` | PASS — 5/5 WIN, 35 focus takeovers, cleanup sạch |

Không chuyển 4D.2 cho tới khi analyzer tạo `PASS_STRONG` từ đúng hai FarmRunId.

## Long-run prerequisite finding — dừng sau 87 trận tại Đảo Rồng

Run `1b9e7ed38ab340a9a00c14f010f54d43` hoàn tất `87/87`, đều WIN, rồi
safe-stop khi chuẩn bị attempt 88. Artifact thực tế cấu hình target `200`, tối đa
`250` attempts. Không có crash, technical abort/recovery/exit hoặc exhausted
attempt; stop reason là `OPENING_ACCEPTANCE_INVARIANT_FAILED` bắt nguồn từ
`ENTRY_PREFLIGHT_BUTTON_CHANGED`.

Timeline cho thấy detector vừa resolve phòng Starburst và nút Bắt đầu, nhưng
trong pinned focus lease phòng chuyển về Đảo Rồng. Final preflight phát hiện nút
đã đổi/biến mất và từ chối action đúng fail-closed: `entryClicks=0`,
`entryRetryClicks=0`, `gameplayInputs=0`. FarmRunner trước đó chỉ định tuyến lại
khi nhận `ENTRY_PREFLIGHT_RUNTIME_CHANGED`; cùng một navigation race được báo
bằng `ENTRY_PREFLIGHT_BUTTON_CHANGED` nên bị nâng thành terminal safe-stop.

Remediation chỉ mở rộng nhánh định tuyến lại đã có cho hai stop reason trên khi
và chỉ khi cả ba bộ đếm input đều bằng 0. FarmRunner đọc lại lifecycle, chọn lại
target native trên bản đồ nếu cần rồi thử entry lại; mỗi pending attempt vẫn bị
giới hạn tối đa ba lần. Mọi trường hợp đã phát input hoặc reason khác tiếp tục
fail-closed.

Không được ưu tiên panel Đảo toàn cục: live idle check cho thấy panel này vẫn
active bên dưới overlay phòng boss thật. Phân loại bình thường tiếp tục ưu tiên
exact room; chỉ zero-input `ENTRY_PREFLIGHT_*_CHANGED` mới kích hoạt bounded
navigation reroute. Trong lượt reroute, BossEntry tiếp tục theo dõi runtime cũ
cho tới khi nó bị thu hồi rồi trả map transition cho FarmRunner.

Validation sau sửa: FarmRunner `80/80 PASS`; Boss Entry `29/29 PASS`; full suite
`1584/1584 PASS`; `compileall` và `git diff --check` PASS. Đây là prerequisite
fix trước live A/B, không được dùng run 87 trận làm evidence cho arm A hoặc B.

## Live re-entry regression — lần thứ hai dừng tại Đảo Rồng

Run `536821eb1aca4c88b60cc0b6e972b363` chứng minh lần re-entry đầu tiên sau khi
người dùng đóng phòng đã chọn đúng Starburst và vào attempt 2. Sau attempt 2,
runtime tiếp tục tìm đúng boss, đúng `ManagerChinhPhuc`, panel 5 và native Button
geometry ổn định hai mẫu. Tuy nhiên lần đọc duy nhất trong post-focus preflight
trả `freshRuntime=null`; lease từ chối trước input và FarmRunner safe-stop với
`RETURN_LOBBY_TIMEOUT`. Không có click sai được gửi.

Post-focus target preflight nay cho phép tối đa bốn lần đọc khi và chỉ khi target
graph tạm thời chưa tồn tại, visible surface vẫn là owner-free Chinh Phuc island
và chưa có combat session. Boss khác, target graph khác, sai manager/panel hoặc
session mới vẫn fail-closed ngay. Test regression mô phỏng chuỗi
`target, target, target, null, target` và xác nhận đúng một target click được gửi.

Cùng run này còn cho thấy desktop làm rơi metadata mục tiêu lúc chuyển từ room
sang combat: controller projection giữ lifecycle/match ID nhưng kế thừa một live
transition không còn RoomDTO. Control plane nay cache metadata chỉ từ exact
`CHINH_PHUC_ROOM`, đối chiếu boss ID với target đã khóa trong active config, rồi
hiển thị lại trong entry/combat/postmatch. Cache không che trạng thái đảo thật ở
các lobby boundary.

Validation sau hai sửa đổi: focused desktop/FarmRunner `101/101 PASS`; full suite
`1585/1585 PASS`; `compileall` và `git diff --check` PASS.

## Live focus collision — dừng trước nước đầu tiên

Run `2a20e71bd1aa476a851311ab3e89a91f` vào đúng combat Starburst và desktop đã
giữ đúng `Starburst LV73 - Đảo rồng`. Nước đầu được quyết định hợp lệ, nhưng sau
khi lease lấy focus game, foreground chuyển sang cửa sổ ChatGPT trong khoảng
settle 0,5 giây. Delivery trả `USER_TAKEOVER_DURING_ACTION`, `action_attempted`
false, không có click/gameplay permit/input nào được gửi. Logic cũ vẫn auto-pause
toàn FarmRun với `FARM_GAMEPLAY_AUTO_PAUSED`.

Mouse session nay coi đúng trường hợp zero-input này là va chạm focus có thể thử
lại hữu hạn trong cùng action identity. Mỗi lần thử vẫn lấy exclusive guard và
chạy lại preflight; tổng cộng tối đa ba lần. Action không được nhân đôi. Mọi
trường hợp đã attempt input, preflight stale, cửa sổ đổi, stop request hoặc hết
giới hạn tiếp tục trả lỗi fail-closed cho controller.

## Live b5 multiplier regression — trận 3 bị loại sau ba lượt không có board

Run `e746727a66bc4f7589e416b1abaacf8e` thắng hai trận đầu. Ở attempt 3,
MatchId `M_9003ad94`, tool đã gửi và nhận ACK cho 10/10 SWAP đến hết local turn
19. Tại local turn 21, 23 và 25 không có `policy_decision`, PASS hay input nào;
`lastAcceptedSeq` đứng ở 40 trong khi ACK tiến 42 → 46 → 51. Vì vậy đây không
phải policy lạm dụng bỏ lượt mà là provider không xuất bản được board.

Immutable `MATCH_MOVE_RES` chỉ ra nguyên nhân trực tiếp: seq 20 chứa multiplier
x7 và x5; seq 21 chứa x6. Decoder transport báo `invalid_multipliers`, còn live
Dot fallback báo `Dot multiplier is outside supported domain` tổng cộng 92 lần.
Validator cũ chỉ chấp nhận x1..x4. Reverse b5 xác nhận
`DotMultiplierRoll.Roll` tại RVA `0x00C6D960` duyệt tier 7 xuống 2,
`PermilleAt` tại RVA `0x00C6DB40` chấp nhận tier 2..7 và x5..x7 bắt đầu có thể
xuất hiện từ turn 20.

Domain multiplier production được gom về một nguồn x1..x7 và dùng chung cho
state model, DTO/JSON decoder, rendered-Dot fallback cùng các tool evidence.
Giới hạn cấu hình đếm hiệu dụng tăng từ 256 lên 448 (`64 * 7`). Ngoài domain
này vẫn fail closed; diagnostic boxed integer nay ghi rõ giá trị int32/int64 và
range mong đợi.

Regression mới chứng minh transport board và native Dot board đều nhận đủ
x1..x7; x8 vẫn bị từ chối. Focused multiplier/state/provider tests `75/75
PASS`; full suite `1589/1589 PASS`; `compileall` và `git diff --check` PASS.
Run lỗi này không được gán vào arm A/B. Manifest đã được làm mới với source
fingerprint `3f52ee675395b420605ff5762ed342626d49e523e633e4c05e4dcb659c66a925`.

## Live multiplier retry — PASS, nhưng không hợp lệ cho B1 do sai mode

FarmRun `ce84a3f15c8645ab9da2177f3d826e96` hoàn thành sạch 5/5 WIN trong 5
attempt, 40/40 SWAP ACK, 5/5 Pet Skill PERFECT, zero UNKNOWN, zero critical
counter và kết thúc `FARM_TARGET_COMPLETED` tại `BOSS_LOBBY`. Attempt 5 kéo tới
turn 25, board đã xuất bản chứa x5 và x7; toàn run có 60 native Dot board được
chấp nhận, 0 native Dot rejection và 0 multiplier rejection. Vì vậy remediation
x1..x7 đạt live PASS.

Checkpoint và `farm_run_started` đều ghi
`input_delivery_mode=pinned_foreground_lease_beta`. Run có 50 mouse lease, 5
QTE lease, pinned session mở/đóng sạch và 0 focus takeover. Nó không thể gán
cho B1/A_FOREGROUND; cũng không được dùng làm B2 chính thức vì đã chạy trước A
và chưa thực hiện lịch chuyển focus của B2. Bước kế tiếp khi đó là chạy lại B1
bằng đúng mode `foreground`.

## B1 A_FOREGROUND — PASS trên source trước remediation

FarmRun `974763bccc784a9887df25f12f84759c` khớp source fingerprint và hai game
hash đã đóng băng. Cấu hình/checkpoint đúng `input_delivery_mode=foreground`,
đúng Starburst 1289 và toàn bộ gameplay config của manifest.

Run hoàn thành đúng 5/5 WIN trong 5 attempts, có 27/27 SWAP ACK, 5/5 Pet Skill
PERFECT và 5/5 postmatch confirm. Không có UNKNOWN, technical recovery, PASS,
unconfirmed input hay critical counter. Telemetry không có mouse/QTE lease,
pinned session hoặc focus takeover. Controller kết thúc
`FARM_TARGET_COMPLETED` tại `BOSS_LOBBY`. Run này đã được bind ở manifest cũ.
Sau remediation QTE, fingerprint thay đổi nên run vẫn được giữ làm lịch sử live sạch
nhưng không còn là arm A của phép so sánh same-source hiện tại.



## B2 lần 1 — dừng do va chạm focus trong acquire QTE

FarmRun `f4c666ca160d4ed9b6514bfe20f91a85`, MatchId `M_5e88dd7f`, chạy đúng
`pinned_foreground_lease_beta`. Tool đã đi 7 SWAP và nhận 7/7 ACK. Ở turn 15,
policy chọn Pet Skill hợp lệ với Mana/Nộ `224/250` và 12 kiếm hiệu dụng.

QTE lease được arm, nhưng cửa sổ khác lấy lại foreground trong khoảng settle
0,2 giây sau khi game vừa được focus và input guard đã được giữ. Acquire trả
`STALE_ACTION`, controller dừng bằng `PINNED_QTE_ZERO_INPUT_LEASE_CONSUMED`.
Card click, hướng và Space đều bằng 0; guard/cursor/focus được dọn sạch. Vì vậy
đây là lỗi transport Phase 4 khi người dùng đang dùng cửa sổ khác, không phải
policy gameplay, board read hay QTE sau input.

Remediation cho phép tối đa ba lần takeover trên **cùng action identity** khi và
chỉ khi lần vừa rồi chưa phát input, exact window/binding còn nguyên, stop chưa
được yêu cầu, preflight vẫn current, guard từng active và cleanup hoàn tất. Mỗi
lần thử lại đều chạy lại courtesy wait, binding/preflight, focus và guard. Nếu
state/window/preflight đổi, guard lỗi, cleanup không hoàn tất hoặc đã phát input
thì tiếp tục fail-closed và không retry.

Regression mới mô phỏng đúng một lần foreground bị cướp trong settle rồi thành
công ở lần chiếm thứ hai; regression đối chứng xác nhận final preflight stale
không được retry. Focused QTE/pinned tests `43/43 PASS`; full suite
`1591/1591 PASS`; `compileall` và `git diff --check` PASS.

Vì production source đã đổi, manifest A/B được chuẩn bị lại với fingerprint
`8f60fdfa60fc56703d59ea9018cb2942c4bec4291ade621a3d76f6d2e01fbeb3`. Run A cũ `974763bccc784a9887df25f12f84759c` vẫn là bằng chứng live
sạch của source trước remediation nhưng không còn được bind vào phép so sánh
same-source. Run B lỗi không được bind. Tại thời điểm remediation, hai arm trở
lại PENDING; các run sạch cuối cùng được ghi ở phần kết luận bên dưới.


## B_PINNED_FOREGROUND_BETA sau remediation — PASS

FarmRun `ee17b4a58a14430ba1d394620edb7d26` khớp source fingerprint
`8f60fdfa60fc56703d59ea9018cb2942c4bec4291ade621a3d76f6d2e01fbeb3`, hai
game hash, boss Starburst 1289 và toàn bộ gameplay config của manifest. Run dùng
đúng `pinned_foreground_lease_beta`.

Run hoàn thành đúng 5/5 WIN trong 5 attempts, không có extra attempt, UNKNOWN,
technical abort/recovery/exit hay safe-stop. Input/ACK gồm 5/5 BOSS_ENTRY,
27/27 GAMEPLAY_SWAP, 5/5 GAMEPLAY_PET_SKILL PERFECT và 5/5 POSTMATCH_CONFIRM.
Tất cả critical counters, PASS và unconfirmed input đều bằng 0.

Transport ghi 37 mouse leases và 5 QTE leases; 35 action thực sự lấy focus từ
cửa sổ khác. Tất cả 37 mouse lease phục hồi cursor/focus, không ghi nhận user
cursor movement; cả 5 QTE lease đều release guard/focus/cursor sạch. Pinned
session start/close đúng 1/1 và kết thúc UNPINNED tại `BOSS_LOBBY`.

Run B đạt acceptance riêng và đã được bind vào manifest. Nó được thực hiện trước
A mới sau remediation; điều này được ghi rõ thay vì che lịch sử. Vì source và
gameplay không thay đổi giữa hai arm, khi đó bước còn thiếu là chạy A foreground
trên đúng fingerprint hiện tại. A sau đó đã sạch và analyzer đã chấp nhận cặp;
không cần lặp lại B.


## A_FOREGROUND mới và kết luận A/B — PASS STRONG

FarmRun A `a32e8eb15136456ca9231cb29934e3da` chạy đúng `foreground`, cùng source
fingerprint, game build, boss và gameplay config với B. Run hoàn thành đúng 5/5
WIN trong 5 attempts: 5/5 BOSS_ENTRY, 33/33 GAMEPLAY_SWAP, 5/5 Pet Skill
PERFECT và 5/5 POSTMATCH_CONFIRM. Không có lease Beta, focus takeover,
unconfirmed input, UNKNOWN, technical recovery hay critical counter.

Analyzer ghép A với B `ee17b4a58a14430ba1d394620edb7d26` và trả
`PASS_STRONG`: tổng cộng 10/10 WIN trong đúng 10 attempts; mọi input đã gửi đều
có authoritative ACK; cả hai kết thúc `FARM_TARGET_COMPLETED` tại `BOSS_LOBBY`.
B có 35 focus takeovers trong 37 mouse leases và 5 QTE leases, toàn bộ cleanup
cursor/focus/guard và unpin sạch. Acceptance failures: none.

Machine-readable evidence:

- [analysis JSON](artifacts/phase4d1_analysis.json)
- [analysis Markdown](artifacts/phase4d1_analysis.md)
- [frozen manifest](artifacts/phase4d1_manifest.json)

Gate 4D.1 đã đóng `PASS STRONG`; router chuyển sang
`prompts/4D2_PINNED_FOREGROUND_RELIABILITY_SOAK.md`.
