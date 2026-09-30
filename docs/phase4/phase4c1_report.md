# Phase 4C.1 — Desktop UI ↔ FarmRunner Pinned Foreground Integration

## Trạng thái

`PASS STRONG`

Entry gate 4B.2, 4B.3 và 4B.4P đều đã `PASS STRONG`.

## Phạm vi đã triển khai

- Desktop UI cung cấp đúng hai chế độ:
  - `Tiền cảnh (mặc định)`;
  - `Ghim game để tự chơi khi dùng máy — Beta`.
- UI ghi rõ mode Beta giữ game luôn hiển thị/topmost, không hỗ trợ thu nhỏ;
  tool có thể tạm giữ chuột quanh click/swap và khóa bàn phím trong QTE;
  việc trả focus là best effort.
- Mode được chuyển bằng typed `InputDeliveryMode`, đi từ preference/UI qua
  `DesktopConfig`, controller CLI adapter, FarmRunner và mọi delivery domain
  đã tích hợp ở 4B.2–4B.4P.
- Config đang chạy được khóa ngay khi Start/Resume được chấp nhận. Combobox mode
  không thể sửa trong lúc controller còn active.
- Checkpoint schema nâng lên `pokiguard.farm_checkpoint.v3` và lưu
  `input_delivery_mode` như immutable run intent.
- Checkpoint v1/v2 không có field mới vẫn đọc được và mặc định an toàn về
  foreground; file lịch sử không bị tự ghi lại.
- Resume bằng mode khác checkpoint bị từ chối rõ bằng
  `CHECKPOINT_INPUT_DELIVERY_MODE_MISMATCH`, trước khi tạo runner hoặc gửi input.
- Lệnh `Nạp tùy chọn từ checkpoint` phục hồi cả gameplay profile, limits và mode,
  nhưng không tự Resume.
- Trạng thái lượt chạy và checkpoint hiển thị mode hiện tại bằng nhãn tiếng Việt.
- Permit, ACK, stop, counters, target/attempt/no-extra-entry và solver/policy cũ
  không bị thay đổi trong phase này.

## Kết quả offline

- Nhóm UI/config/checkpoint/resume/import: **200/200 PASS**.
- Full regression ban đầu: **1532/1532 PASS**.
- Sau hardening cho phép đổi vị trí cửa sổ giữa các action:
  **1536/1536 PASS**.
- Sau hardening focus trong post-click Unity settle:
  **1537/1537 PASS**.
- `python -m compileall -q src tools tests`: **PASS**.
- `git diff --check`: **PASS**.

Regression mới bao phủ Beta checkpoint round-trip, migration v2 về foreground,
resume đúng/sai mode hai chiều, zero runner khi mismatch, explicit checkpoint
import, khóa combobox trong run và nội dung UI Beta.

## Live acceptance còn lại

Chỉ chạy qua `run_tool.bat`, theo từng bài và đọc log sau khi user báo xong:

1. B1: một trận `Tiền cảnh (mặc định)`;
2. B2: một trận `Ghim game để tự chơi khi dùng máy — Beta`, chuyển sang ứng
   dụng khác sau khi Start;
3. nếu B2 sạch, B3: 3–5 trận Beta cùng cấu hình;
4. B4: yêu cầu `Dừng sau trận hiện tại` trong một run Beta và xác nhận không có
   entry thừa, cleanup/unpin sạch.

Navigation/re-entry hiếm chưa được mở rộng trong 4C.1. Minimized vẫn
`UNSUPPORTED`.

## Live B1 — Foreground PASS

Run `29dfb9ba1abf4113a30ae85c84237bfb`, match `M_f5a22ee1`:

- snapshot và checkpoint v3 đều lưu `input_delivery_mode=foreground`;
- hoàn thành 1/1 trong 1 attempt, `WIN` strong/consistent và trở lại đúng boss
  lobby;
- 6/6 swap được ACK, 0 rejected/aborted, 0 pass;
- Pet Skill dùng đúng 1 card click, 7/7 direction RAM ACK, đúng 1 Space tại
  `3.152s`, runtime `PERFECT`, rồi hạ boss ngay;
- 0 technical abort/recovery/safe-stop và mọi FarmRun safety counter bằng 0;
- không có pinned session event trong foreground baseline, đúng phân tách mode.

Tiến độ live: **B1 PASS**; chờ B2 Beta.

## Live B2 — lần đầu phát hiện geometry quá nghiêm

Run `7f402e992837470ab4936b763dee45ea` đã ghim đúng game và hoàn thành
swap đầu tiên. Trước action kế tiếp, cửa sổ vẫn cùng HWND/PID/title và cùng
kích thước `1280x640`, nhưng origin đổi từ `(454,141)` sang `(253,31)`.
Binding cũ so sánh toàn bộ `ClientGeometry`, vì vậy `arm()` trả
`WINDOW_CHANGED` và FarmRunner dừng an toàn bằng `FARM_RUN_INTERNAL_INVARIANT`.
Không có input thứ hai được gửi.

Remediation chỉ cho phép rebase tại ranh giới trước action khi thay đổi thuần
`left/top`. Session đọc lại và xác nhận cùng HWND/PID/title, cửa sổ còn hiển
thị, không minimize và giữ nguyên width/height; sau đó cập nhật đồng thời
binding của pin, ánh xạ tọa độ và lease kế tiếp. Resize, đổi identity/title,
minimize hoặc geometry đổi khi lease/QTE đang chạy vẫn fail closed. Event
`pinned_window_origin_rebased` ghi delta và thời gian đọc geometry.

## Live B2 retry — PASS STRONG

Run `4bbfbe018e5b4a40b8611fe109d994fb`, match `M_a26cba9b`:

- mode/checkpoint đúng `pinned_foreground_lease_beta`;
- cửa sổ được kéo giữa hai action từ `(253,31)` sang `(556,306)`, giữ nguyên
  `1280x640`; event `pinned_window_origin_rebased` ghi delta `(303,275)` và
  thời gian đọc/xác nhận geometry `0.721 ms`;
- hoàn thành 1/1, `WIN` strong/consistent, trở lại đúng boss lobby;
- 7/7 swap được ACK, 0 rejected/aborted và 0 pass;
- toàn bộ 9 mouse lease (entry, 7 swap, postmatch) đều `COMPLETE`; các lần
  chuyển sang ứng dụng ngoài game đều lấy/trả focus và cursor sạch;
- Pet Skill dùng đúng 1 card click, 7/7 direction ACK, đúng 1 Space tại
  `3.166s`, runtime `PERFECT`; QTE lease trả mouse/keyboard/focus sạch;
- 0 technical abort/recovery/safe-stop; pin được gỡ bằng `UNPINNED` sau khi
  hoàn thành target.

## Live B3 — Beta soak PASS STRONG

Run `4e5f067ad4ef4e64ac228ee7077f599c` hoàn thành đủ 3/3 trận trong 3
attempt, thắng 3, kết quả memory/UI đều strong và consistent:

- 28/28 swap được ACK; 0 rejected/aborted, 0 pass;
- mỗi trận có đúng 1 Pet Skill: 1 card click, 7/7 direction ACK, 1 Space,
  runtime `PERFECT` tại lần lượt `3.153s`, `3.150s`, `3.184s`;
- cả 3 skill đều hạ boss ngay; 0 misclick, partial input, wrong-turn input,
  stale action hoặc response timeout;
- 34/34 mouse lease và 3/3 QTE lease đều `COMPLETE`;
- 0 technical abort/recovery/exit; hoàn thành ở đúng boss lobby và unpin sạch.

Tiến độ live: **B1/B2/B3 PASS STRONG; chờ B4 graceful stop**.

## Pre-B4 continuation — không tính acceptance

Run `f79e940649ea41ca80e40bcb636703f1` không ghi nhận yêu cầu
`Dừng sau trận hiện tại`. Trận 1 thắng sạch với 7/7 swap ACK và Pet Skill
`PERFECT`, sau đó FarmRunner đúng cấu hình target 3 đã thử entry trận 2.

Click Start trận 2 được gửi đúng tọa độ, nhưng trong khoảng post-click settle
foreground đổi từ game HWND `28905098` sang một cửa sổ khác `47318778`.
Lease ghi `USER_TAKEOVER_DURING_ACTION`; không có combat session mới và entry
dừng fail-closed bằng `ENTRY_TIMEOUT_NEW_SESSION`. Run kết thúc `SAFE_STOP`
tại 1/3, không blind retry.

Remediation giữ và kiểm tra focus theo nhịp tối đa 25 ms trong đúng khoảng
post-action settle 0.2 giây khi exclusive input guard còn active. Nếu một ứng
dụng giành focus trong khoảng Unity cần sample click, lease dùng đường
`ensure_foreground_for_guarded_input` đã có để lấy lại game; hết settle thì
guard vẫn được nhả theo cleanup cũ. Ngoài lease không có focus reclaim.

B4 graceful-stop vẫn **PENDING** vì run này không có stop request.

## Live B4 retry — graceful stop PASS STRONG

Run `6def36b251bc4810b0bf5a263946589d`, match `M_f167c73f`:

- yêu cầu graceful stop được nhận khi FarmRunner đang `COMBAT_ACTIVE`;
- trận hiện tại vẫn hoàn thành bình thường: 7/7 swap ACK, 0 pass, 0 input
  reject/abort;
- Pet Skill dùng đúng 1 card click, 7/7 direction ACK, 1 Space tại `3.200s`,
  runtime `PERFECT` và immediate kill;
- trở về đúng boss lobby rồi kết thúc `STOPPED_GRACEFULLY` tại 1/3;
- chỉ có đúng một `BOSS_START` lease trong toàn run, chứng minh không có entry
  hoặc input thừa cho trận 2;
- 9/9 mouse lease và 1/1 QTE lease đều `COMPLETE`; cleanup/unpin sạch;
- 0 technical abort/recovery/exit, misclick, partial, wrong-turn, stale hoặc
  response timeout.

## Kết luận

Phase 4C.1 đạt **PASS STRONG**. UI/config/checkpoint giữ đúng mode immutable;
foreground baseline, Beta reposition, Beta soak và graceful stop đều có live
evidence sạch. Router chuyển sang
`prompts/4C2_PINNED_FOREGROUND_NAVIGATION_REENTRY.md`.

## Router

Phase đã chốt `PASS STRONG`. Prompt kế tiếp là
`4C2_PINNED_FOREGROUND_NAVIGATION_REENTRY.md`.
