# Phase 2 b2 — sự cố bỏ lượt mở đầu ở trận kế tiếp

Ngày điều tra: 2026-09-11. Phase 2 vẫn chưa chốt. Không commit, push hay tăng
version trong lần sửa này.

## Phạm vi và kết quả run

FarmRun `a588b67a29834419a9e8b351cfbed926` dùng cấu hình mặc định, target 5
trận và tối đa 8 attempt.

- Attempt 1, MatchId `M_dccb5ba6`: WIN / STRONG / CONSISTENT, 13 local turn,
  12 SWAP đã gửi, 11 SWAP được ACK, 2 lần thử EVOLVE và 1 EVOLVE_SUCCESS.
  `local_max_hp=116830` ở terminal snapshot xác nhận pet đã tiến hóa. Formal
  PASS bằng 0.
- Attempt 2, MatchId `M_e4cde0a4`: người dùng F9 ở local turn thứ ba. Tool gửi
  1 SWAP và nhận ACK, sau đó gửi 1 EVOLVE đang chờ kết quả lúc dừng. Formal
  PASS vẫn bằng 0. Lượt mở đầu bị game xử lý như bỏ lượt vì tool không gửi input.
- Toàn run không có provider read error, DTO rejection, stale publication,
  ambiguous latest state, sequence desync hay gameplay input sai session/turn.

## Bằng chứng lỗi

Opening trận 2 được nhận lúc `16:41:12.905Z` với đúng session
`lifecycle_epoch=2`, Board `2025870116160`, MatchId `M_e4cde0a4` và đủ 64 ô.
Tại `16:41:12.928Z`, actionability đúng khi chặn input vì game còn báo
`ClockPaused=true`, reason `FX`.

Đến `16:41:13.096Z`, provider đã đọc một current duplicate state. Lúc
`16:41:13.233Z`, actionability vòng chính đã mở và policy chọn nước Sword an
toàn `(0,0)<->(1,0)` khi đồng hồ còn 13 giây. Vì vậy solver, policy, bàn cờ và
khả năng tìm nước đều hoạt động.

Ngay sau đó, preflight tại `16:41:13.239Z` trả
`ACTION_ABORTED_STATE_CHANGED / CLOCK_PAUSED / FX`. Chuỗi này lặp 41 lần; timer
trong policy giảm `13 -> 12 -> 10 -> 9 -> 7 -> 5 -> 4 -> 2 -> 1`, nhưng không
có `action_sent`. Turn đổi lúc `16:41:26Z`.

Nguyên nhân nằm ở `tools/basic_auto_bot.py`: vòng chính dùng `poll.state`, tức
mẫu hiện tại dù board key là duplicate. Preflight mở trận lại dựng state từ
`provider.last_published_state`. Property này cố ý giữ publication MATCH_START
đầu tiên và vì vậy còn giữ cờ `ClockPaused=FX` tại thời điểm trước khi đồng hồ
bắt đầu. Direct MatchService refresh chỉ thay turn, owner, timer và move
sequence; nó không thay battle actionability fields. Do đó preflight luôn nhìn
cờ dừng cũ dù vòng chính vừa xác nhận cờ hiện tại đã tắt.

Reverse b2 xác nhận đây là field có thật của game:
`MatchService.ClockPaused +0x165`, `ClockPauseReason +0x168`,
`_startGateSeen +0x178`; `ApplyTimingFields` cập nhật các field này từ timing
payload. Tool không được bỏ qua chúng vì cơ chế b2 có khoảng chờ thật trước khi
đồng hồ bắt đầu.

## Sửa chữa

Preflight mở trận nay lấy chính `state` vừa được provider đọc ở vòng hiện tại,
sau đó direct MatchService refresh lại exact MatchId, turn, local owner, timer
và pristine move sequence như trước. Immutable 64-cell MATCH_START board vẫn
được tái sử dụng nên không thêm heap scan. Mọi gate `ClockPaused`, start gate,
presentation, Board state, connection, foreground, session và action identity
vẫn được giữ nguyên.

Sửa này chỉ loại bỏ battle envelope cũ giữa hai lần đọc; nó không nới policy,
không ép SWAP khi game còn pause và không tạo PASS. Test hồi quy dựng đúng tình
huống: publication cũ có `ClockPaused=FX`, current duplicate đã unpause, rồi
xác nhận opening preflight giữ current dynamic gate và qua ActionabilityGate.

## Xác minh offline

- Ba test opening handoff/preflight liên quan: 3/3 PASS.
- `tests.test_autonomous_control`: 105/105 PASS.
- Toàn bộ `python -m unittest discover -s tests -p 'test_*.py' -q`:
  **1165/1165 PASS**.

Cần live soak nhiều trận liên tục để xác nhận timing thực tế. Tiêu chí tối
thiểu: trận 2 trở đi không có chuỗi `policy_decision` rồi
`ACTION_ABORTED_STATE_CHANGED/CLOCK_PAUSED` cho cùng opening source sau khi
vòng chính đã actionable; local turn đầu phải có một consuming action và formal
PASS vẫn bằng 0.
