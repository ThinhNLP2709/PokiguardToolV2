# Phase 4A.2-R1 — Pinned Foreground Existing-Input Lease Report

## Kết quả hiện tại

```text
RESULT: PASS STRONG — B1/B2/B3 ACCEPTED
PRODUCTION INTEGRATION: NO
BASELINE GAMEPLAY/QTE/INPUT CHANGED: NO
```

## Phạm vi đúng

Phase 4A.2 không tạo QTE, executor hay kiểu input mới. Mục tiêu duy nhất là bọc
toàn bộ hành động Pet Skill đang dùng bằng một session lease:

1. pin đúng cửa sổ game visible/topmost;
2. khi action cũ sẵn sàng, tạm lấy foreground và mouse authority để click thẻ;
3. để nguyên executor cũ click thẻ, nhấn chuỗi hướng với timing hiện có và nhấn
   Space/Perfect;
4. ngay khi QTE được bind, trả mouse/cursor và chỉ khóa keyboard cho hướng +
   Space;
5. release keyboard guard, trả cursor và thử trả focus cho user theo best effort.

`tools/foreground_qte_lease_transport.py` triển khai session lease theo đúng
PID/HWND/title/client geometry. Nếu native `BlockInput` không được cấp,
`NativeQteLeaseBackend` kết hợp cursor confinement đã live-prove ở 4A.1-R2 với
low-level keyboard guard. Guard cho injected input của executor và physical
`F9` đi qua, chặn physical keyboard khác chỉ trong lease.

`tools/foreground_qte_lease_probe.py` có ba stage:

- B1: quan sát QTE hiện tại với zero input;
- B2: chạy toàn bộ hành động Pet Skill cũ khi game được ghim;
- B3: chạy lại chính hành động đó khi ứng dụng khác đang foreground, rồi chứng
  minh focus được trả đúng cửa sổ cũ.

Thiết kế directions-only trước đó đã được xóa trước khi live B2. Không sửa
`src/pokiguard_v2/qte_direction_assist.py`,
`src/pokiguard_v2/pet_skill_action.py`, policy, random delay hoặc production
FarmRunner.

## Verification offline

Baseline trước khi chỉnh lại stage:

```text
Focused QTE/Pet Skill/Phase-4 lease tests: 144 PASS
Full regression: 1460 PASS
Native keyboard guard acquire/release smoke: PASS, zero input
```

Sau khi bỏ route directions-only, test acceptance kiểm tra trực tiếp:

- B2 chấp nhận full action cũ và lease release sạch;
- B3 chỉ chấp nhận khi lease lấy focus từ một cửa sổ khác và trả lại thành công;
- full action cũ fail thì stage fail.

Kết quả sau khi bỏ route trung gian:

```text
Focused lease/QTE/input tests: 239/239 PASS
Full regression: 1462/1462 PASS
compileall: PASS
git diff --check: PASS
```

## Live B1 — PASS STRONG

Artifact: `logs/phase4a2_r1/b1_20260924/`

- match `M_526ad84c`, turn 11, skill card 7;
- QTE generation 1 hiện tại, 7 hướng;
- Perfect window 3.0–3.3 giây;
- input count: card 0, direction 0, Space 0;
- ownership `BOUND_CURRENT`, evidence `CURRENT`.

Sau khi evidence được lưu, outer cleanup thử ghi vào JSONL đã đóng nên process
trả exit code 1. Đây là lỗi cleanup của harness, không phải lỗi QTE/input. Topmost
đã được gỡ thủ công với zero input; `stop()` sau đó được làm idempotent và
cleanup không còn bỏ qua unpin nếu logger đã đóng. `post_review.json` phân loại
B1 là `PASS_STRONG`.

## Live gate còn lại

### B2 — PASS STRONG trước refinement

Artifact: `logs/phase4a2_r1/b2_20260924_201538/`

- full executor cũ chạy từ click thẻ đến `PERFECT`;
- input count: 1 card click, 7 directions, 1 Space;
- cả 7/7 hướng `AUTHORITATIVELY_CONFIRMED`;
- zero wrong/skip/duplicate/stale/unconfirmed/blind retry;
- Space tại 3.184 giây, nằm trong Perfect window 3.0–3.3 giây;
- runtime result `PERFECT`;
- lease dùng `CURSOR_CONFINE+KEYBOARD_HOOK` và release sạch guard, focus,
  cursor, topmost;
- không có production integration hoặc automatic retry.

B2 chứng minh việc pin/lease không thay đổi tuyến Pet Skill cũ. Tuy nhiên, run
này giữ `CURSOR_CONFINE` suốt 10,657 giây đến terminal result. Theo yêu cầu mới,
đó là phạm vi giữ chuột rộng hơn cần thiết nên không còn đóng gate B2 cuối cùng.

## Mouse-release refinement

Lease mới chia quyền input theo đúng hai giai đoạn nhưng không đổi executor:

- trước QTE: `BLOCK_INPUT` hoặc `CURSOR_CONFINE` chỉ để bảo vệ card click;
- sau khi current QTE bind: cài `KEYBOARD_HOOK`, tháo mouse guard và trả cursor
  trước hướng đầu tiên;
- final release chỉ gỡ keyboard/focus và không kéo lại cursor nếu user đã di
  chuyển chuột trong QTE;
- nếu chuyển guard hoặc trả cursor thất bại, action fail closed trước direction.

Verification sau refinement:

```text
Focused lease/QTE/input tests: 244/244 PASS
Full regression: 1467/1467 PASS
```

### B2 mouse-release retry — PASS STRONG

Artifact: `logs/phase4a2_r1/b2_mouse_release_retry_20260924_204513/`

- guard lúc card click: `CURSOR_CONFINE`;
- current QTE bind lúc `13:46:52.339Z`;
- mouse guard được tháo, cursor trả và keyboard guard active lúc
  `13:46:52.340Z`;
- hướng đầu tiên chỉ được gửi lúc `13:46:52.450Z`, sau mouse release 110 ms;
- 1 card click, 7/7 directions confirmed, 1 Space, runtime `PERFECT`;
- zero wrong/skip/duplicate/stale/unconfirmed/blind retry;
- final guard/focus/topmost release sạch;
- B3 có hard gate chờ foreground thực sự thuộc ứng dụng khác trước khi consume
  lease, nên không thể vô tình chạy sample handoff khi user chưa chuyển focus.

Live evidence xác nhận chuột không còn bị giữ trong QTE. Code và test cũng xác
nhận final release không kéo cursor về lần hai sau khi user đã di chuyển nó.

Vì foreground trước acquire của run đầu đã là game, takeover/restore từ ứng
dụng khác vẫn là gate riêng của B3.

Run này đã mở gate B3 nhưng chưa tạo production mode/backend hoặc nối Desktop
UI/FarmRunner; phần đó thuộc 4B.1 trở đi.

### B3 attempt 1 — action PASS, focus restore chưa thành công

Artifact: `logs/phase4a2_r1/b3_focus_handoff_20260924_205201/`

- foreground trước acquire là Comet `HWND 460730`, khác game;
- lease lấy game foreground thành công;
- full action cũ đạt 1 card click, 7/7 directions, 1 Space và `PERFECT`;
- mouse release/keyboard guard/cursor/topmost cleanup sạch;
- Windows từ chối lần gọi trả focus duy nhất, nên `focus_restored=false` và B3
  đúng quy tắc bị `NOT_ACCEPTED`.

HWND Comet vẫn tồn tại và hợp lệ. Remediation đổi focus restore sang tối đa ba
lần trong deadline 0,75 giây, cùng nguyên tắc tôn trọng nếu user đã chọn một
cửa sổ thứ ba. Theo acceptance đã thống nhất sau run này, trả focus là best
effort; B3 bắt buộc trả cursor, tháo toàn bộ guard/topmost và hoàn tất action cũ,
nhưng không fail chỉ vì Windows từ chối trả focus. Không đổi QTE, executor hay
input gameplay.

### B3 best-effort retry — INVALID SAMPLE, zero input

Artifact: `logs/phase4a2_r1/b3_best_effort_focus_retry_20260924_211102/`

Run này không phải một gameplay/QTE failure:

- lease bị lấy lúc đúng thẻ còn `interactable=false`;
- lease bị release sau khi action preflight chưa thể click, nhưng one-shot state
  đã bị consume;
- các vòng sau trả `ALREADY_CONSUMED`, kể cả khi mana/rage đã đủ;
- operator dừng run; input count là 0 card, 0 direction, 0 Space;
- topmost được gỡ sạch và không có input gameplay nào cần đánh giá.

Phân loại: `ZERO_INPUT_HARNESS_LEASE_CONSUMED_BEFORE_CARD_ACTIONABLE`. Đây là
lỗi orchestration của probe, không phải policy, resource condition hay executor
cũ. Probe đã được chặn để chỉ acquire khi exact current card có button hợp lệ,
`interactable=true`, chưa dùng, không pending và không phải placeholder. Executor
vẫn chạy preflight độc lập lần nữa sau acquire và trước click.

Verification sau fix:

```text
Focused QTE lease tests: 25/25 PASS
Focused lease/QTE/input tests: 247/247 PASS
Full regression: 1470/1470 PASS
compileall: PASS
git diff --check: PASS
```

B3 vẫn cần một live sample hợp lệ. Không tự động chạy lại; bắt đầu từ boss lobby
và chỉ consume lease sau khi thẻ thực sự actionable.

Attempt `b3_card_actionable_fix_retry_20260924_212343` dừng ở preflight vì
`Board.Instance` vẫn tồn tại trước khi provider có thể lấy ownership từ lobby.
Harness gửi zero input, chưa tạo lease và đã gỡ topmost sạch. Attempt này được
phân loại `INVALID_PRECONDITION`, không phải B3/gameplay failure.

### B3 valid retry — PASS STRONG

Artifact: `logs/phase4a2_r1/b3_valid_retry_20260924_212722/`

- foreground trước acquire là Comet `HWND 460730`, khác game;
- exact current card chỉ cho acquire sau khi `interactable=true`;
- full executor cũ gửi đúng 1 card click;
- QTE generation 1 có chuỗi `RIGHT RIGHT RIGHT LEFT LEFT LEFT RIGHT`;
- 7/7 hướng có `currentIndex/correctCount` ACK, zero wrong/skip/duplicate/
  stale/unconfirmed/blind retry;
- mouse được trả ngay khi current QTE bind, keyboard guard tiếp tục bảo vệ QTE;
- đúng 1 Space tại 3,202 giây trong Perfect window 3,0–3,3 giây;
- runtime xác nhận `PERFECT`;
- guard, cursor và topmost release sạch; focus cũng được trả về Comet ngay lần
  thử đầu tiên.

B3 đạt acceptance đã thống nhất. Phase 4A.2-R1 đạt `PASS STRONG` với capability
`PINNED_FOREGROUND_EXISTING_INPUT_LEASE`: game luôn visible/topmost, mỗi action
dùng tuyến input cũ dưới một lease có giới hạn. Đây không phải true-background
transport và không được quảng bá là background/minimized operation.

## Router decision

Prompt production cũ dựa trên `PostMessage/background` không còn khớp bằng
chứng. Router chuyển sang
`prompts/4B1_PINNED_FOREGROUND_LEASE_CONTRACT_BACKEND.md`. Các prompt tiếp theo
đã có nhánh pinned foreground riêng cho board, UI/card, QTE, Desktop/FarmRunner,
navigation, A/B, soak và package. Phase 4A.2 không commit/push vì user chưa yêu
cầu chốt.
