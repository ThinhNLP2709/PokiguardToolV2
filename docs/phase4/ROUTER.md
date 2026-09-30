# Phase 4 Result Router

Router này chọn prompt tiếp theo từ báo cáo thực tế. Không chọn theo kỳ vọng.

## Classification

```text
PASS STRONG
  Tất cả offline/live/safety/docs/Git evidence bắt buộc của phase đã đạt.

PASS
  Logic chính đúng nhưng còn một closure nhỏ hoặc live evidence bắt buộc chưa
  đủ mạnh. Không advance roadmap.

PARTIAL
  Chưa hoàn thành chính phase hiện tại. Tiếp tục cùng prompt hoặc tạo Rn.

BLOCKED
  Transport/capability không hoạt động hoặc thiếu một quyết định/evidence không
  thể tự suy ra. Dùng nhánh thay thế nếu bảng dưới có định nghĩa.

FAIL
  Có regression/safety violation. Remediation bắt buộc trước mọi advance.
```

## Decision table

| Current phase/result | Điều kiện thêm | Next prompt |
|---|---|---|
| 4A.0 PASS STRONG | audit hoàn chỉnh | `4A1_BACKGROUND_MOUSE_LIVE_PROBE.md` |
| 4A.0 khác PASS STRONG | — | cùng 4A.0 hoặc `REMEDIATION_TEMPLATE.md` |
| 4A.1 PASS STRONG | single-click + ít nhất một board transport accepted | `4A2_BACKGROUND_QTE_KEYBOARD_LIVE_PROBE.md` |
| 4A.1 BLOCKED | mọi mouse transport REJECTED/UNCONFIRMED | STOP hoặc 4A.1-Rn nếu có giả thuyết mới có bằng chứng |
| 4A.2 PASS STRONG | arrows + Space accepted | đặt capability `FULL_BACKGROUND_CAPABLE`; next `4B1_INPUT_MODE_CONTRACT_BACKEND.md` |
| 4A.2 PASS STRONG | keyboard background được kiểm tra đầy đủ và kết luận rejected/unsupported; foreground QTE baseline sạch | đặt branch `HYBRID_REQUIRED`; next `4B1_INPUT_MODE_CONTRACT_BACKEND.md` |
| 4A.2-R1 PASS STRONG | pinned foreground Start/board/card/QTE lease accepted; true background unsupported | đặt branch `PINNED_FOREGROUND_EXISTING_INPUT_LEASE`; next `4B1_PINNED_FOREGROUND_LEASE_CONTRACT_BACKEND.md` |
| 4A.2 khác PASS STRONG | evidence còn thiếu hoặc có safety failure | giữ 4A.2, remediation hoặc STOP; không tiến 4B.1 |
| 4B.1 PASS STRONG | selected branch là pinned foreground lease | `4B2_PINNED_FOREGROUND_BOARD_INTEGRATION.md` |
| 4B.2 PASS STRONG | pinned board ACK live sạch | `4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md` |
| 4B.3 PASS STRONG | selected branch là pinned foreground lease | `4B4P_PINNED_FOREGROUND_QTE_INTEGRATION.md` |
| 4B.3 PASS STRONG | single-click domains sạch | nếu full capability: `4B4F_FULL_BACKGROUND_QTE_INTEGRATION.md`; nếu hybrid: `4B4H_HYBRID_QTE_FOREGROUND_HANDOFF.md` |
| 4B.4P PASS STRONG | pinned full Pet Skill action sạch | `4C1_PINNED_FOREGROUND_DESKTOP_FARMRUNNER_INTEGRATION.md` |
| 4B.4F PASS STRONG | full background QTE/Perfect accepted | `4C1_DESKTOP_FARMRUNNER_INTEGRATION.md` |
| 4B.4F không PASS STRONG | keyboard path không ổn nhưng mouse ổn | remediation; chỉ chuyển `4B4H...` sau một closure PASS STRONG kết luận Full không còn hợp lệ |
| 4B.4H PASS STRONG | bounded handoff sạch | `4C1_DESKTOP_FARMRUNNER_INTEGRATION.md` |
| 4C.1 PASS STRONG | UI/Farm config/live sạch | `4C2_NAVIGATION_REENTRY_CLOSURE.md` |
| 4C.2 PASS STRONG | native hoặc handoff route accepted | `4D1_BOUNDED_AB_ACCEPTANCE.md` |
| 4D.1 PASS STRONG | cả A và B hợp lệ | `4D2_BACKGROUND_RELIABILITY_SOAK.md` |
| 4D.2 PASS STRONG | soak đúng target, zero critical violation | `4E1_PACKAGED_BACKGROUND_BETA_ACCEPTANCE.md` |
| 4C.1 PASS STRONG | selected branch là pinned foreground lease | `4C2_PINNED_FOREGROUND_NAVIGATION_REENTRY.md` |
| 4C.2 PASS STRONG | selected branch là pinned foreground lease | `4D1_PINNED_FOREGROUND_AB_ACCEPTANCE.md` |
| 4D.1 PASS STRONG | selected branch là pinned foreground lease | `4D2_PINNED_FOREGROUND_RELIABILITY_SOAK.md` |
| 4D.2 PASS STRONG | selected branch là pinned foreground lease | `4E1_PACKAGED_PINNED_FOREGROUND_BETA_ACCEPTANCE.md` |
| 4E.1 PASS STRONG | artifact/hash/live acceptance/Git complete | ROADMAP COMPLETE; STOP |

## Quy tắc branch

### Full background

Chỉ chọn khi live evidence prove cả:

- mouse/card transport;
- QTE directions với per-direction RAM ACK;
- Space với server/runtime Perfect result;
- không có foreground takeover.

### Hybrid

Chọn khi mouse nền hoạt động nhưng keyboard QTE không hoạt động hoặc không đủ
bằng chứng. Handoff phải được user nhìn thấy trong UI/config và telemetry.

### Combat-only background

Nếu navigation/re-entry không thể chạy nền an toàn, 4C.2 có thể chấp nhận route
foreground handoff. Không được quảng bá là `full background`.

## Remediation naming

Chọn phase nhỏ nhất:

```text
4A.1-R1 — <transport evidence gap>
4B.2-R1 — <board ACK regression>
4B.4F-R1 — <QTE stale/delivery issue>
4C.2-R1 — <re-entry proof issue>
```

Remediation phải ghi rõ return gate. Sau khi đạt `PASS STRONG`, router quay lại
dòng của phase cha thay vì tự nhảy xa hơn.

## Trách nhiệm cập nhật

Phase report phải dùng `HANDOFF_TEMPLATE.md`. Agent sau khi review phải cập nhật
`STATUS.md` và chỉ ra chính xác prompt kế tiếp. Nếu evidence mâu thuẫn, repository
log mới nhất thắng, nhưng mâu thuẫn phải được ghi ra chứ không chọn kết quả có
lợi hơn.

## Kết quả router hiện tại

Phase 4A.1 ngày 2026-09-23 là `BLOCKED`: background Start single click,
two-click swap và drag swap đều `UNCONFIRMED` dù toàn bộ `PostMessageW` được
queue. Router chọn `STOP`. Không mở 4A.2; chỉ tạo 4A.1-Rn nếu có transport
hypothesis mới kèm bằng chứng, không lặp lại cùng posted-message sequence.

Nghiên cứu 4A.1-R1 đã loại các biến thể cùng WindowProc/message path, native
Win32 button/UI Automation và hidden desktop. Hai route còn lại không phải
same-desktop background transport: `ISOLATED_FOREGROUND_RUNTIME` trong VM/máy
thứ hai, hoặc `BOUNDED_FOREGROUND_LEASE` có đổi focus. Cần quyết định của người
dùng trước khi tạo prompt triển khai cho một trong hai route.

Người dùng đã chọn `BOUNDED_FOREGROUND_LEASE`. Phase 4A.1-R2 hiện có offline
harness; live B1 và B2 đã pass. Hai B3 attempt đầu gửi zero input. Retry 4 đã
được game nhận với exact inverted-row coordinates và sequence tăng, nhưng fail
policy vì helper PostMessage cũ bỏ polling khi game đang active nên mất lượt
local đầu. Remediation poll cả foreground, chờ ACK transition, retry focus bounded
và khóa input vật lý chỉ trong executor cũ. Retry 6 xác nhận Windows từ chối
`BlockInput` và gửi zero input; remediation kế tiếp giữ global lock làm lựa chọn
đầu rồi fallback sang cursor-confinement theo từng click point, có restore bắt
buộc trước khi trả focus.
Retry 7 đã prove fallback này với exact coordinate/sequence/turn ACK và release
sạch, nhưng vẫn fail policy vì hành động ở local turn 3. Retry kế tiếp dùng
dispatcher opening transport hiện có của FarmRunner và hard-gate
`is_first_local_turn`; thấy opening muộn thì zero-input.
Retry 8 đã prove authoritative opening ở turn 1 nhưng two-click của wrapper
không tăng local sequence. Foreground production cũ vẫn là baseline accepted;
không sửa solver/policy/executor. Remediation chỉ giữ Phase-4 cursor guard và
endpoint thứ hai 0,20 giây sau mouse-up trước khi restore.
Retry 9 đã nhận exact first-turn sequence/coordinate/turn ACK và release sạch.
Phase 4A.1-R2 đạt `PASS STRONG`; capability phải được gọi rõ là
`PINNED_FOREGROUND_LEASE`, không đổi thành `FULL_BACKGROUND_CAPABLE`.

Router chuyển sang `4A2_R1_PINNED_FOREGROUND_QTE_LEASE_PROBE.md` để prove
directions + Space bằng bounded foreground lease. Chỉ sau QTE live ACK mới tạo
mode/backend production và nối FarmRunner.

4A.2-R1 offline đã triển khai session lease bao trọn hành động Pet Skill cũ,
với `BlockInput` hoặc fallback `CURSOR_CONFINE+KEYBOARD_HOOK`; baseline QTE,
executor và policy không đổi. B1 zero-input đã `PASS STRONG`. B2 full existing
action đạt `PERFECT`, nhưng run đầu giữ chuột đến terminal result. Refinement đã
đổi lease thành mouse-only cho card click rồi keyboard-only ngay khi QTE bind;
offline 1466 tests pass. B2 retry đã prove mouse release trước hướng đầu tiên,
7/7 ACK và runtime `PERFECT`. Route
directions-only đã được xóa trước B2: cả B2 và B3 phải chạy nguyên click thẻ →
directions → Space/Perfect bằng executor cũ. B3 thêm điều kiện lấy foreground
từ ứng dụng khác; trả focus là best effort, còn cursor/guard/topmost cleanup là
bắt buộc. B3 attempt 1 đã lấy focus từ Comet và đạt `PERFECT`; Windows từ chối
single-shot focus restore nên restore đã được đổi sang retry bounded ba lần/
0,75 giây. B3 retry kế tiếp là sample không hợp lệ với zero input: harness đã
consume one-shot lease khi exact card còn `interactable=false`, rồi trả
`ALREADY_CONSUMED` khi tài nguyên đủ. Probe nay chỉ acquire sau exact-card
actionability gate; offline 1470 tests pass. B3 valid retry sau fix đã lấy
foreground từ Comet, chạy nguyên action cũ với 1 card click, 7/7 direction ACK,
1 Space và runtime `PERFECT`; mouse/keyboard guard, cursor, focus và topmost đều
release sạch. Phase 4A.2-R1 đạt `PASS STRONG`.

Router chọn capability `PINNED_FOREGROUND_EXISTING_INPUT_LEASE`. Đây là game
visible/topmost với foreground takeover ngắn quanh input cũ, không phải true
background/minimized transport. Prompt kế tiếp là
`4B1_PINNED_FOREGROUND_LEASE_CONTRACT_BACKEND.md`; các prompt production sau đó
phải dùng nhánh pinned foreground tương ứng và không claim background.

Phase 4B.1 đã promote đúng implementation live-proven vào package production,
thêm immutable mode/domain/authority/telemetry contract và giữ default
`FOREGROUND`. Probe modules chỉ còn là compatibility shim trỏ tới production
classes. Zero FarmRunner/UI call site đổi mode; 151 focused và 1481 full tests
pass. Router chuyển sang `4B2_PINNED_FOREGROUND_BOARD_INTEGRATION.md`.

Phase 4B.2 đã nối duy nhất production board SWAP vào mouse lease. Nhánh
foreground giữ executor cũ; nhánh Beta pin exact HWND, cho phép input-free
board preparation khi app khác giữ focus, reread direct runtime sau acquire,
xin FarmRunner permit tại input boundary và dùng proposal/mapping/executor/ACK
cũ. B1 foreground đạt 5/5 ACK. B2 Beta cuối đạt 3/3 ACK, trong đó hai lease lấy
focus từ HWND ngoài game rồi trả focus/cursor và nhả guard sạch; mọi critical
safety counter bằng 0. Same-thread emergency poll deadlock và legacy
pre-lease foreground gate phát hiện ở các attempt trước đã có regression.
Latest full suite 1498/1498 pass. Phase 4B.2 đạt `PASS STRONG`; router chuyển
sang `4B3_PINNED_FOREGROUND_UI_CARD_INTEGRATION.md`.

Phase 4B.3 đã nối các domain Start, exact lobby card, result confirm và cleanup
vào production pinned lease; live full match sạch và 1514/1514 tests pass.
Router chuyển sang `4B4P_PINNED_FOREGROUND_QTE_INTEGRATION.md`.

Phase 4B.4P đã nối nguyên Pet Skill action cũ vào QTE child lease. Sau
remediation initial observer binding, 1526/1526 tests pass và ba production
live actions độc lập đều đạt đúng 1 card click, 7/7 direction RAM ACK, 1 Space,
runtime `PERFECT`, immediate kill và cleanup guard/focus/cursor sạch. Phase
4B.4P đạt `PASS STRONG`; router chuyển sang
`4C1_PINNED_FOREGROUND_DESKTOP_FARMRUNNER_INTEGRATION.md`.

Phase 4C.1 đã nối mode Beta xuyên suốt Desktop UI, config, FarmRunner,
checkpoint/resume và mọi production input domain. Sau remediation rebase thuần
origin giữa action và giữ focus trong post-click Unity settle, full suite đạt
1537/1537. Live B1 foreground, B2 Beta có reposition, B3 soak 3 trận và B4
graceful stop đều sạch; B4 dừng đúng 1/3 ở boss lobby và phát đúng một entry.
Phase 4C.1 đạt `PASS STRONG`; router chuyển sang
`4C2_PINNED_FOREGROUND_NAVIGATION_REENTRY.md`.

Phase 4C.2 đạt `PASS STRONG`. Run `f591da152cbe47dd9b7ef501f9c079a8`
hoàn tất `3/3 WIN` và tạo đúng hai production re-entry cycle sạch. Cả hai chọn
Starburst bằng native `panelButtons[pet_index]` RectTransform, fresh post-focus
proof, đúng một click, room/opening ACK và zero critical event. Full suite
`1575/1575` pass; router chuyển sang
`4D1_PINNED_FOREGROUND_AB_ACCEPTANCE.md`.
