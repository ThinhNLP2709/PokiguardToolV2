# Phase 4 Roadmap — Background Input Beta

Roadmap này mô tả các proof boundary. Nó không cho phép triển khai tất cả phase
trong một lượt. Prompt thật nằm trong `prompts/` và được chọn qua `ROUTER.md`.

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

## 4B.1 — Input Mode Contract + Backend

Mục tiêu: tạo contract production cho foreground/background/hybrid, backend
typed theo đúng input vocabulary, fail-closed status và capability validation.
Chưa nối autonomous gameplay.

Default vẫn là `FOREGROUND`. Unsupported combinations phải bị reject khi Save
hoặc Start, không tự fallback âm thầm.

## 4B.2 — Background Board Swap Integration

Mục tiêu: nối duy nhất board transport đã được 4A.1 prove vào actionability và
FarmRun permit. ACK hiện tại vẫn là nguồn acceptance. Không đổi solver/policy.

Nếu chỉ two-click được prove, background mode phải khóa về two-click một cách
hiển thị rõ; drag vẫn giữ cho foreground.

## 4B.3 — Background UI/Card Integration

Mục tiêu: nối các single-click domain đã được prove: Start, validated card,
result confirm và các UI domain được liệt kê rõ. Mỗi domain phải có fresh proof
và post-state ACK riêng. Không bao gồm QTE keyboard.

## 4B.4F — Full Background QTE Integration

Nhánh chỉ tồn tại khi 4A.2 đạt `PASS STRONG` cho arrows và Space. Nối Pet Skill
controller với background keyboard transport nhưng giữ nguyên ownership,
per-direction ACK, Perfect proof, Emergency Stop và no-retry invariants.

## 4B.4H — Hybrid QTE Foreground Handoff

Nhánh dùng khi mouse nền hoạt động nhưng keyboard nền không được prove. Board và
mouse chạy nền; QTE được thực hiện qua bounded foreground handoff. UI phải nói
rõ game sẽ được đưa lên trước khi skill bắt đầu. Không gọi nhánh này là full
background.

## 4C.1 — Desktop UI ↔ FarmRunner Integration

Mục tiêu: thêm option user-facing Beta, immutable run config, validation và
runtime status. Không thay đổi default foreground. Chỉ expose capability đã
accepted trong `STATUS.md`.

## 4C.2 — Navigation / Re-entry Background Closure

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

## 4D.1 — Bounded Foreground vs Background A/B Acceptance

Mục tiêu: chạy cùng config/game build qua một mẫu foreground và một mẫu
background/hybrid. Đo input acceptance, ACK latency, focus takeover, result và
critical counters. Đây là correctness comparison, không phải tuyên bố né phát
hiện hay tối ưu server behavior.

## 4D.2 — Background Reliability Soak

Mục tiêu: bounded soak (mặc định đề xuất 25 completed matches, điều chỉnh theo
evidence). Có các khoảng game không foreground theo kịch bản đã accepted. Không
test minimized nếu capability vẫn unsupported.

## 4E.1 — Packaged Background Beta Acceptance

Mục tiêu: build package dưới repository `build/`, self-check/offline smoke,
packaged foreground regression, packaged background/hybrid live smoke, stop/
resume/recovery phù hợp, hash/manifest/docs và release checkpoint.

Version/tag không fix cứng trong roadmap. Dùng repository/user decision tại
thời điểm release.

## Remediation

Mọi regression hoặc evidence gap tạo phase nhỏ `4X.Y-Rn` từ
`prompts/REMEDIATION_TEMPLATE.md`. Sau remediation phải quay lại đúng advance
gate cũ; không nhảy qua phase mới.
