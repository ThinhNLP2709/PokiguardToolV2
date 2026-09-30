# Phase 4B.4P — Pinned Foreground Pet-Skill/QTE Integration

## Trạng thái

`PASS STRONG — OFFLINE PASS + LIVE 3/3 PASS`

Entry gate: Phase 4B.3 `PASS STRONG`; Phase 4A.2-R1 full QTE lease live
proof accepted.

## Phạm vi đã nối

- production `PetSkillActionExecutor` cũ chạy nguyên vẹn trong QTE lease đã
  prove ở 4A.2-R1;
- exact FarmRunner/PID/HWND/topmost session được dùng chung, không tạo pin
  chồng và không gỡ pin giữa trận;
- exact current Pet Skill card phải còn actionable trước khi lease acquire;
- sau khi foreground acquire, FarmRunner gameplay permit mới được reserve và
  whole-hand/card geometry được đọc lại trước đúng một card click;
- fresh current QTE generation là ACK duy nhất để chuyển từ mouse guard sang
  keyboard-only guard và trả cursor trước direction đầu tiên;
- direction pacing, random/delay hiện có, per-direction RAM ACK, no retry và
  one-shot Space/Perfect giữ nguyên;
- stop, unreadable state, focus/binding loss, observer stall và terminal result
  đều đi qua cleanup lease;
- zero-input lease đã tiêu thụ không được thử lại mù cùng proposal; cleanup
  không chứng minh được sau card click thì fail closed;
- foreground mode mặc định giữ nguyên.

Run-scoped topmost pin vẫn thuộc FarmRunner và chỉ được gỡ khi bounded run kết
thúc. QTE child lease chỉ giữ mouse qua card click, sau đó chỉ giữ keyboard đến
khi action terminal; focus restore là best effort.

## Kết quả offline

- `python -m unittest discover -s tests -p "test_*.py" -q`: **1526/1526 PASS**.
- Nhóm Pet Skill/FarmRunner/QTE: **245/245 PASS**.
- Nhóm pinned board/QTE production mới: **20/20 PASS**.
- `python -m compileall -q src tools tests`: **PASS**.
- `git diff --check`: **PASS**.

Regression mới kiểm tra thẻ chưa actionable không acquire, typed QTE lease chỉ
được arm một lần, permit được reserve sau foreground, fresh-QTE guard
transition, focus/binding loss, stop và cleanup fail-closed. Regression bổ sung
kiểm tra observer gắn giữa trận chỉ chấp nhận lần bind đầu tiên khi `match_id`
khớp chính xác session FarmRunner; match lạ hoặc lần đổi match thật vẫn dừng.

## Live attempt 1 — không tính acceptance

Run `6ab15068ea654cb9975f04e86ad3981a` dừng an toàn trước mọi input ở turn 19.
Policy đã đủ 270 mana, 225 nộ và 11 kiếm hiệu dụng so với ngưỡng 7, sau đó tạo
QTE lease nhưng chưa acquire, chưa click thẻ và chưa nhấn phím.

Nguyên nhân là observer được gắn giữa trận với `previous_match_id=None`; lần đọc
đầu tiên từ `None` sang đúng match đang chạy bị hiểu nhầm thành `MATCH_CHANGED`.
Đã sửa bootstrap để đúng match đã được FarmRunner bind chỉ khởi tạo observer.
Match lạ ngay lần đầu và mọi thay đổi sau đó vẫn invalidate fail-closed. Vì
không có full action nên lần này không được tính vào yêu cầu live 3/3.

## Tiêu chí live acceptance

User chạy production FarmRunner bằng mode
`pinned_foreground_lease_beta`, từ một ứng dụng khác đang foreground. Cần tối
thiểu 3/3 full Pet Skill actions:

- mỗi action đúng một card click;
- đủ mọi direction và mọi direction có RAM ACK;
- đúng một Space;
- current runtime đạt `PERFECT`;
- mouse trả trước direction đầu tiên;
- zero wrong/skip/duplicate/stale/unconfirmed/blind retry;
- keyboard/cursor guard release sạch, pin gỡ sạch khi run kết thúc.

Production call-site đã có 3/3 live action độc lập đạt toàn bộ tiêu chí.

## Live action 1 — PASS

Run `f6bfeb958d2b44499829c522e4994caa`, match `M_28b90938`, turn 13:

- bootstrap nhận đúng session hiện tại với `expectedInitialBinding=true`;
- QTE lease acquire `ACTIVE`, đúng PID/HWND và card id 7;
- đúng một card click;
- sequence `RIGHT LEFT RIGHT LEFT LEFT LEFT RIGHT`: **7 sent / 7 RAM ACK**;
- zero wrong, skipped, duplicate, stale, unconfirmed và blind retry;
- mouse guard được nhả khi current QTE đã bind, keyboard guard tiếp tục giữ;
- đúng một Space tại elapsed `3.184s`, nằm trong PERFECT `3.0–3.3s`;
- CardUI runtime xác nhận `PERFECT`;
- full lease release `COMPLETE`, keyboard/mouse guard, cursor và focus đều trả;
- skill hạ boss ngay, kết quả `WIN` strong/consistent, 7 lượt năng lượng;
- run hoàn tất 1/1, trở lại boss lobby, không pass và không safety violation.

Sau live action 1, tiến độ là **1/3 full Pet Skill actions PASS**.

## Live action 2 — PASS

Run `03f6f449efd845e7b9aa09969d341cd2`, match `M_a1a2a7b5`, turn 11:

- bootstrap đúng session với `expectedInitialBinding=true`;
- foreground được chuyển từ ứng dụng ngoài sang đúng game HWND, QTE lease
  acquire `ACTIVE`;
- đúng một card click;
- sequence `LEFT RIGHT RIGHT LEFT LEFT RIGHT LEFT`: **7 sent / 7 RAM ACK** và
  khớp hoàn toàn recorded presses;
- zero wrong, skipped, duplicate, stale, unconfirmed và blind retry;
- mouse release `COMPLETE`, cursor được trả và keyboard guard còn active;
- đúng một Space tại elapsed `3.151s`, trong PERFECT `3.0–3.3s`;
- CardUI runtime xác nhận `PERFECT`;
- full lease release `COMPLETE`, guard, focus và cursor đều trả sạch;
- skill hạ boss ngay, `WIN` strong, 6 lượt năng lượng, 0 pass;
- zero misclick, partial input, wrong-turn, stale action và input sai lifecycle.

Sau live action 2, tiến độ là **2/3 full Pet Skill actions PASS**.

## Live action 3 — PASS

Run `4c287b6a5aba472287e819af396bed03`, match `M_85012ebb`, turn 13:

- bootstrap đúng session với `expectedInitialBinding=true`;
- foreground chuyển từ ứng dụng ngoài sang đúng game HWND, QTE lease acquire
  `ACTIVE`;
- đúng một card click;
- sequence `LEFT LEFT RIGHT RIGHT LEFT LEFT LEFT`: **7 sent / 7 RAM ACK** và
  khớp hoàn toàn recorded presses;
- zero wrong, skipped, duplicate, stale, unconfirmed và blind retry;
- mouse release `COMPLETE`, cursor được trả và keyboard guard còn active;
- đúng một Space tại elapsed `3.184s`, trong PERFECT `3.0–3.3s`;
- CardUI runtime xác nhận `PERFECT`;
- full lease release `COMPLETE`, guard, focus và cursor đều trả sạch;
- skill hạ boss ngay, `WIN` strong, 7 lượt năng lượng, 0 pass;
- zero misclick, partial input, wrong-turn, stale action và input sai lifecycle.

## Kết luận

Ba action production độc lập đều đạt một card click, 7/7 direction ACK, một
Space, runtime PERFECT, immediate kill và cleanup sạch. Không có wrong, skip,
duplicate, stale, unconfirmed, blind retry hoặc safety violation. Phase 4B.4P
đạt **PASS STRONG**. Theo router, prompt kế tiếp là
`4C1_PINNED_FOREGROUND_DESKTOP_FARMRUNNER_INTEGRATION.md`.
