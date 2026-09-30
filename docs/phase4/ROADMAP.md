# Phase 4 Roadmap — Pinned Foreground Input Beta

Roadmap này mô tả các proof boundary. Nó không cho phép triển khai tất cả phase
trong một lượt. Prompt thật nằm trong `prompts/` và được chọn qua `ROUTER.md`.

True-background `PostMessageW` đã không tạo authoritative board/session ACK.
Nhánh được chọn từ evidence là `PINNED_FOREGROUND_EXISTING_INPUT_LEASE`: game
visible/topmost, executor cũ lấy foreground/input authority trong khoảng ngắn
rồi cleanup. Các mục background bên dưới là lịch sử audit; production roadmap
hiện tại dùng các prompt `*_PINNED_FOREGROUND_*`.

## 4A.0 — Background Input Transport Audit

Mục tiêu: đóng bản đồ tĩnh của mọi input domain, foreground gate, ACK và visual
dependency. Đối chiếu V1 Beta với V2 và game build hiện tại. Không gửi live
input và không nối production.

Advance gate:

- exact call-site/capability matrix;
- đề xuất transport/harness cho mouse click, two-click, drag, arrows, Space;
- xác định rõ state ACK cho từng input;
- test plan không spam/retry mù;
- `PASS STRONG` report.

## 4A.1 — Isolated Background Mouse Live Proof

Mục tiêu: dùng harness tách biệt để prove từng mouse primitive trên đúng game
build: single click, two-click swap và drag. Game không foreground nhưng không
minimized. Production FarmRunner chưa được nối.

Advance gate tối thiểu:

- ít nhất một background single click có authoritative state transition;
- ít nhất một board transport được server/runtime ACK;
- unconfirmed input dừng sạch, không duplicate;
- kết luận riêng cho two-click và drag.

Nếu mọi mouse transport đều bị Unity từ chối, Phase 4 background integration bị
`BLOCKED`; dùng remediation chỉ khi có một giả thuyết mới có bằng chứng.

## 4A.2 — Isolated Background QTE Keyboard Live Proof

Mục tiêu: kiểm tra arrows và Space khi game không foreground, với current
session/card/QTE identity và RAM ACK sau từng phím. Không nối policy/FarmRunner.

Hai kết quả hợp lệ:

```text
FULL_BACKGROUND_CAPABLE
  arrows + Space đều accepted và ACK

HYBRID_REQUIRED
  mouse nền accepted nhưng keyboard nền không đủ bằng chứng hoặc bị từ chối
```

Không được gọi `PostMessage` success là QTE success.

## 4B.1 — Pinned Foreground Lease Contract + Backend

Mục tiêu: tạo contract production cho foreground và pinned foreground lease,
backend typed theo đúng input vocabulary, fail-closed status và capability
validation. Chưa nối autonomous gameplay.

Default vẫn là `FOREGROUND`. Unsupported combinations phải bị reject khi Save
hoặc Start, không tự fallback âm thầm.

## 4B.2 — Pinned Foreground Board Swap Integration

Mục tiêu: bọc board executor cũ bằng bounded mouse lease sau đúng actionability
và FarmRun permit. ACK hiện tại vẫn là nguồn acceptance. Không đổi solver/policy.

Nếu chỉ two-click được prove, background mode phải khóa về two-click một cách
hiển thị rõ; drag vẫn giữ cho foreground.

Trạng thái hiện tại: production SWAP integration và offline regression đã hoàn
tất; chờ foreground B1 và pinned Beta B2 live acceptance. Chưa advance 4B.3.

## 4B.3 — Pinned Foreground UI/Card Integration

Mục tiêu: nối các single-click domain đã được prove: Start, validated card,
result confirm và các UI domain được liệt kê rõ. Mỗi domain phải có fresh proof
và post-state ACK riêng. Không bao gồm QTE keyboard.

Trạng thái: `PASS STRONG`. Live accepted cho exact Boss Start, lobby Attack-card
selection, board continuation, result confirm, return boss lobby và clean
unpin. Báo cáo: `phase4b3_report.md`.

## 4B.4F — Full Background QTE Integration

Nhánh chỉ tồn tại khi 4A.2 đạt `PASS STRONG` cho arrows và Space. Nối Pet Skill
controller với background keyboard transport nhưng giữ nguyên ownership,
per-direction ACK, Perfect proof, Emergency Stop và no-retry invariants.

## 4B.4H — Hybrid QTE Foreground Handoff

Nhánh dùng khi mouse nền hoạt động nhưng keyboard nền không được prove. Board và
mouse chạy nền; QTE được thực hiện qua bounded foreground handoff. UI phải nói
rõ game sẽ được đưa lên trước khi skill bắt đầu. Không gọi nhánh này là full
background.

## 4B.4P — Pinned Foreground QTE Integration

Mục tiêu: nối nguyên Pet Skill action cũ vào split mouse/keyboard lease đã live
prove. Không tạo input route, QTE hay timing mới.

Trạng thái: `PASS STRONG — LIVE 3/3 PASS`; production call-site đã nối,
1526 tests pass. Initial embedded-observer match binding đã được phân biệt với
match change thật. Ba action độc lập đều đạt 1 card click, 7/7 direction ACK,
1 Space, runtime PERFECT, immediate kill và cleanup sạch. Router chuyển sang
`4C1_PINNED_FOREGROUND_DESKTOP_FARMRUNNER_INTEGRATION.md`.

## 4C.1 — Desktop UI ↔ FarmRunner Integration

Mục tiêu: thêm option user-facing Beta, immutable run config, validation và
runtime status. Không thay đổi default foreground. Chỉ expose capability đã
accepted trong `STATUS.md`.

Trạng thái: `PASS STRONG`. Hai mode đã đi xuyên suốt
UI/config/FarmRunner/checkpoint/resume; checkpoint v1/v2 mặc định foreground và
resume sai mode fail closed. Full regression 1537/1537 pass. B1 foreground,
B2 Beta/reposition, B3 3-match Beta soak và B4 graceful stop đều có live
evidence sạch; không có entry thừa. Advance gate sang 4C.2 đã mở.

## 4C.2 — Navigation / Re-entry Pinned Foreground Closure

Mục tiêu: đóng các dependency screen-DC của entry, map, empty-room exit và
re-entry. Chọn một trong hai nhánh dựa trên evidence:

```text
NATIVE_BACKGROUND_ROUTE
  đủ memory/native UI proof để không cần foreground visual capture

FOREGROUND_NAVIGATION_HANDOFF
  combat nền; navigation đưa game lên trước theo bounded contract
```

Không được hạ visual threshold hoặc click theo stale coordinates để đạt full
background giả.

Trạng thái: `PASS STRONG`. Production Beta dùng bounded foreground lease cho
room-shell exit/confirm, mở Chinh Phục và chọn target động. Target boss được
neo vào live ManagerChinhPhuc + active panel, quan hệ
`listPetEnemy[i] -> panelButtons[i]` và native RectTransform; badge thứ tự không
được dùng làm tọa độ. Room/runtime đổi trước input được đưa lại qua bounded
router với zero input. Replay các nhánh hiếm sạch, full suite `1575/1575` pass.
Run `f591da152cbe47dd9b7ef501f9c079a8` hoàn tất `3/3 WIN` với đúng hai production
re-entry cycle; cả hai có hai mẫu native target ổn định, fresh post-focus proof,
đúng một target click, room/opening ACK và zero critical event. Gate `2/2 PASS`;
advance sang 4D.1.

## 4D.1 — Bounded Foreground vs Pinned Foreground A/B Acceptance

Mục tiêu: chạy cùng config/game build qua một mẫu foreground và một mẫu
background/hybrid. Đo input acceptance, ACK latency, focus takeover, result và
critical counters. Đây là correctness comparison, không phải tuyên bố né phát
hiện hay tối ưu server behavior.

Trạng thái: `PASS STRONG`. A foreground và B pinned foreground Beta đều hoàn
thành 5/5 trên cùng source/build/config; tổng 10/10 WIN, đúng 10 attempts, zero
critical counter và toàn bộ input có ACK. Evidence nằm trong
`artifacts/phase4d1_analysis.json`; router đã chuyển 4D.2.

## 4D.2 — Pinned Foreground Reliability Soak

Mục tiêu: bounded soak (mặc định đề xuất 25 completed matches, điều chỉnh theo
evidence). Có các khoảng game không foreground theo kịch bản đã accepted. Không
test minimized nếu capability vẫn unsupported.

Trạng thái: `REMEDIATION OFFLINE PASS — LIVE RETRY PENDING`. Live attempt 1
hoàn thành 25/25 nhưng attempt 14 mất foreground sau khi mouse được trả trong
keyboard-only QTE nên không gửi Space; tổng `26` skill input chỉ có `25`
PERFECT. Reclaim focus không đạt live, vì vậy production lease được đổi sang giữ
cả mouse và keyboard guard suốt card + directions + Space/Audition, chỉ release
ở terminal/stop/failure. Analyzer v2 phân biệt safe pre-input policy reread với
expired physical input. Full repository `1610/1610 PASS`; manifest mới đã đóng
băng source/game/config cho mode pinned Beta, target `25`, tối đa `30` attempts.
B0 full-guard run `34b4905056234d5fb0be819190201869` đã PASS STRONG với
`CURSOR_CONFINE+KEYBOARD_HOOK`, 7/7 direction ACK, một Space, PERFECT và cleanup
sạch. Official retry `018e125ba3e0442dba800f3bfd44d3af` tiếp tục đạt 25/25
WIN với 25/25 Pet Skill PERFECT, 153/153 swap ACK, full guard và cleanup sạch,
zero effective critical/safety counter. Analyzer v2 trả `PASS_STRONG`; router
đã advance sang 4E.1.

## 4E.1 — Packaged Pinned Foreground Beta Acceptance

Mục tiêu: build package dưới repository `build/`, self-check/offline smoke,
packaged foreground regression, packaged background/hybrid live smoke, stop/
resume/recovery phù hợp, hash/manifest/docs và release checkpoint.

Version/tag không fix cứng trong roadmap. Dùng repository/user decision tại
thời điểm release.

Trạng thái: `PASS STRONG`. Artifact v1.1.0 SHA-256
`ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5`
đã vượt B1–B6: foreground, Beta/QTE, bounded multi-match + re-entry,
graceful checkpoint/resume, emergency stop và shutdown/write audit. Bundle
khớp byte-for-byte với ZIP; source/game hash giữ nguyên. Commit/tag/push/release
chờ yêu cầu chốt riêng của người dùng. Phase 4 acceptance roadmap hoàn tất.

## Remediation

Mọi regression hoặc evidence gap tạo phase nhỏ `4X.Y-Rn` từ
`prompts/REMEDIATION_TEMPLATE.md`. Sau remediation phải quay lại đúng advance
gate cũ; không nhảy qua phase mới.
