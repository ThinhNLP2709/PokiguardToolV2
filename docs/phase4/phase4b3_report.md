# Phase 4B.3 — Pinned Foreground UI/Card Integration

## Trạng thái

`PASS STRONG`

Entry gate: Phase 4B.2 `PASS STRONG`.

## Phạm vi đã nối

- một phiên pin exact PID/HWND dùng chung cho toàn bộ FarmRunner Beta;
- Boss Start và một retry có giới hạn;
- chọn Attack card ở boss lobby khi cấu hình yêu cầu;
- EVOLVE và default CAST;
- xác nhận màn hình kết quả sau trận;
- Exit và Confirm của technical recovery;
- SWAP tiếp tục dùng cùng phiên pin, không tạo pin chồng;
- Pet Skill QTE chưa đổi, thuộc Phase 4B.4P.

Foreground vẫn là mode mặc định. Beta chỉ hoạt động khi source selector đặt
`pinned_foreground_lease_beta`.

## Invariant

- pin thuộc FarmRunner và chỉ được gỡ một lần khi run kết thúc;
- mỗi action identity chỉ được cấp một mouse lease;
- trước lease chỉ dùng proof hiện có và kiểm tra ownership nhẹ; riêng cold
  transport-prime của Boss Start chạy trong post-focus preflight sau khi lease
  đã giữ chuột, rồi mới đọc lại exact room/button;
- sau khi lấy foreground phải đọc lại lifecycle/session/card/button/slot và
  visual control trước click;
- capability/permit production chỉ reserve khi exact game đang foreground
  bên trong lease;
- một click cho một permit; kết quả không chắc chắn không được click lại;
- chuột và khóa input luôn được release; trả focus là best effort;
- cleanup không chứng minh được sau input thì fail closed;
- đường foreground cũ và QTE không bị thay đổi.

## Kết quả offline

- `python -m compileall -q src tools tests`: PASS.
- `python -m unittest discover -s tests -p "test_*.py"`: 1514/1514 PASS.
- `git diff --check`: PASS.
- Test mới chứng minh shared mouse session chấp nhận riêng từng mouse domain,
  từ chối QTE keyboard domain, chống reuse identity, stale post-focus gửi zero
  input, và postmatch Beta reread sau focus rồi chỉ click đúng một lần.

Live B1 ban đầu đã chứng minh pin được tạo trước khi entry, nhưng Start gửi zero
input vì callback run-scoped gọi nhầm API `AutoHotkeyEdges` trên đối tượng
`HotkeyEdges`. Callback hiện dùng poll-only F9 latch chung, có regression cho
short F9 edge và không còn phụ thuộc method chỉ tồn tại trong combat.

Live run `f285271a18cf4a7cb2a0290d1dc51e32` phát hiện một khoảng hở khác: cold
transport scan mất `5.404s` trong khi game đã pin nhưng chuột chưa được giữ;
client dịch từ `(608,163)` sang `(457,68)` và exact lease từ chối bằng
`WINDOW_CHANGED` trước mọi input. Transport-prime hiện được hoãn vào
post-focus preflight của chính Boss Start lease. Trong thời gian scan, chuột đã
được giữ; sau scan tool đọc lại lifecycle, exact room và Start button rồi mới
cho phép một click. Arm rejection cũng được ghi thành structured entry stop
thay vì rơi ra `FARM_RUN_INTERNAL_INVARIANT`.

Live retry `2885393770a94eed87f5084a0079f775` xác nhận remediation hoạt động:

- exact Start lease `COMPLETE`, cold transport scan `5.065s` có
  `guardedByEntryLease=true`, một Start click và fresh opening ACK của
  `M_6bbb0dc4`;
- 11 SWAP sent, 10 ACK; action cuối abort đúng lúc boss chết, zero rejected;
- terminal memory `WIN/STRONG`, UI `WIN`, consistency `CONSISTENT`;
- post-focus result-confirm chấp nhận tọa độ detector thực
  `0.4984375` so với proof average `0.4984374999999999`, click một lần và lease
  `COMPLETE`;
- trở về đúng `BOSS_LOBBY`, target hoàn thành `1/1`, unpin sạch, zero
  exception/wrong click/duplicate.

Run này không phát sinh EVOLVE/default CAST/lobby-card action vì cấu hình dùng
Pet Skill và action card không đủ điều kiện. Vì vậy Start + board + postmatch đã
PASS LIVE, còn gate "ít nhất một card/control phù hợp cấu hình" vẫn PENDING.

Live card run `92af0765632d4709b330969d7b1044c5` đóng gate còn lại:

- cấu hình immutable là `legendary / none / default_attack`;
- exact Attack card `dataId=64647`, `cardId=4`, slot `3` được nhận diện;
- `LOBBY_ATTACK_CARD` lease acquire, một click sent, post-state xác nhận
  `preentryCardSelectionClicks=1`, `preentryAttackCardCount=1` và identity
  `[[64647,4,"ATTACK"]]`;
- Start lease tiếp theo `COMPLETE`, fresh opening `M_565539dc`;
- 9 SWAP sent, 8 ACK; action cuối abort đúng lúc boss chết;
- terminal `WIN/STRONG`, target `1/1`, final lifecycle `BOSS_LOBBY`, unpin sạch;
- zero cast trong combat là đúng bằng chứng: policy không đề xuất CAST trước khi
  boss chết; live gate yêu cầu ít nhất một card/control, và lobby-card action đã
  được ACK trực tiếp.

## Live acceptance

Một bounded run cần chứng minh trong khi app khác giữ focus:

1. Boss Start vào đúng phòng và không double click: **PASS**.
2. Ít nhất một EVOLVE/default CAST hoặc lobby-card selection đúng cấu hình:
   **PASS** bằng exact lobby Attack-card selection.
3. SWAP vẫn nhận ACK bình thường: **PASS**.
4. Result confirm về đúng boss lobby: **PASS**.
5. Zero wrong click, partial input, duplicate, stale input và input sau stop:
   **PASS**.
6. Run kết thúc thì unpin sạch: **PASS**.

Kết luận: Phase 4B.3 `PASS STRONG`. Next prompt:
`prompts/4B4P_PINNED_FOREGROUND_QTE_INTEGRATION.md`.
