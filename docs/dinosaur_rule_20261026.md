# Khủng long: chờ lượt sau, thắng thì dừng ngay — 26/10/2026

Người dùng chốt rule: tự vào trận rồi cho tool đọc; nếu không đủ giờ thì chờ
lượt sau, tiếp tục chơi đến khi thắng; không cần chờ kết trận/màn thưởng.
Rule này thay giới hạn cũ chỉ cho lượt mở đầu0/1 được chờ. Bản sửa native
continuity trước đó vẫn được giữ nguyên.

## Hành vi hiện tại

1. Start ghim đúng PID/match hiện tại, dùng cùng policy Đơn giản. Khi chưa có
   board đủ bằng chứng, tiếp tục đọc; bỏ timeout khởi động mặc định35giây.
2. Mọi lượt local chưa gửi input tiêu lượt mà hết thời gian đều tiếp tục chờ.
   Số input ở các lượt trước và cảnh báo idle không làm nhánh này tự Stop.
   Mỗi lượt lỡ được log một lần bằng `dinosaur_missed_turn_wait_next_turn`.
3. Sang lượt mới phải dùng board mới, action identity mới, preflight và input
   thường. Không phát input quá giờ, không dùng lại plan cũ, không tạo PASS/ACK.
   Input đã gửi/chưa rõ kết quả vẫn dùng cơ chế tương quan ACK/timeout hiện có.
4. Với WIN mạnh và đúng session, dừng input ngay, giải phóng session/controller;
   ghi `DINOSAUR_WIN_CONFIRMED`/`DINOSAUR_CURRENT_WIN`. Chấp nhận winner của
   `MATCH_GAME_OVER` hoặc cặp HP kết thúc hợp lệ qua classifier hiện có.
   Không dự đoán thắng từ damage, không coi UNKNOWN/LOSS/conflict là WIN.
5. Không đợi scene chuyển POSTMATCH, reward animation, click Đồng ý hay lobby.
   Terminal event trong lúc chờ fast turn được đưa về đường xử lý đầy đủ ngay,
   thay vì chờ hết fast-transition timeout.
6. Bỏ hạn mức200input riêng của runner: max-total-input-actions0 chỉ được
   phép với profile Dinosaur. Các profile khác vẫn giữ validator50–1000.
   F9/Stop, sai PID/match và các guard thao tác chưa rõ vẫn giữ nguyên. Không
   tự tạo trận tiếp theo khi trận đã ghim kết thúc.

Pending input lúc nhận WIN được đóng với kết quả chưa tương quan, không tự
ghi một ACK thành công. Ledger hoàn thành nhờ terminal WIN mạnh đúng phiên.
Runner có validator riêng cho early WIN: cleared session, no pending, safety
counters0 và terminal proof hợp lệ. Không tạo bản ghi POSTMATCH giả để qua
validator farm chung; validator boss farm không đổi.

## Scope và test

Chỉ3runtime files thay đổi: `dinosaur_session.py`, `tools/dinosaur_run.py`,
`tools/basic_auto_bot.py`; cùng2test/fixture files. Không đổi provider/native
anchors, solver, input executor, random, QTE hoặc luồng farm boss.

-31test Dinosaur PASS, gồm9case mới: đi một nước→lỡ lượt sau→đi tiếp,
  early winner trong scene ACTIVE, terminal HP pair, không fake ACK khi thắng
  lúc còn pending, nhận WIN thật qua runner/ledger mà không có postmatch record,
  từ chối terminal yếu/sai phiên/conflict, default wait không timeout35giây,
  và input ceiling0 chỉ cho Dinosaur.
-529test liên quan PASS: core provider/ACK, cả12case native-continuity vừa
  sửa, lifecycle/terminal, actionability/guards, idle/pass/recovery, BASIC,
  desktop/preferences/config, input randomization và farm ledger/storage.
  [Kết quả](artifacts/dinosaur_rule_20261026/regression.json),
  [log](artifacts/dinosaur_rule_20261026/regression.log).
-362Python files compile/AST PASS;357file Python cũ giữ nguyên bytes.
  Không chạy lại full repository hoặc tuyên bố mọi historical source pin đã
  xanh. Không rebind calibration/timing của Phase5.

Source trước `7f7820695c6c3af74ce046687d83b9068a0792615d43d34ac49cb5c6c4bd3fa6`;
sau `b17b12a8069a16b69ee1209e0a6886ab308bdd240c7c0c6393731391502410ac`.
[Scope/manifest](artifacts/dinosaur_rule_20261026/verification.json),
[diff riêng tác vụ](artifacts/dinosaur_rule_20261026/task.diff).

Chưa đọc/input game trong tác vụ này, chưa live lại và chưa build ZIP mới.
Khi người dùng đã vào trận, cần phiên source mới để test rule hiện tại.
