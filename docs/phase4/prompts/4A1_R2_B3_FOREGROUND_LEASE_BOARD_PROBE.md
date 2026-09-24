# Phase 4A.1-R2 B3 — Foreground Lease Board Probe

## Điều kiện vào

- B1 topmost zero-input: PASS.
- B2 Start click lease: PASS với fresh ACTIVE lifecycle ACK.
- Production/FarmRunner chưa tích hợp.

## Mục tiêu

Trong một trận do user tự vào, ghim game topmost, chờ đúng local actionable
turn và gửi đúng một swap bằng `BoundedForegroundLease` cùng
foreground executor hiện có. Chỉ chấp nhận khi runtime chứng minh exact:

- cùng match ID;
- turn tăng đúng một;
- local move sequence tăng đúng một;
- lượt chuyển sang đối phương;
- last-move coordinates đúng cặp đã gửi.

## Ràng buộc

- Một arm, một swap, không retry.
- Game visible, không minimized hoặc resize.
- User vào trận bằng tay trước khi chạy probe.
- Game luôn được ghim nhìn thấy; không yêu cầu user tự đưa game xuống nền.
- Cho user tiếp tục dùng máy; nhường chuột tối đa 0,75 giây. Bàn phím không làm
  hủy mouse action; chỉ chờ khi nút chuột vật lý đang được giữ.
- Chấp nhận game đang active hoặc focus đang ở ứng dụng khác; chỉ restore focus
  khi probe thực sự đã lấy focus từ một ứng dụng khác.
- Không được bỏ polling/proposal chỉ vì game đang active; phải xử lý lượt local
  đầu tiên.
- Focus acquisition retry bounded tối đa ba lần. Action dùng executor cũ dưới
  physical-input lock; lock thất bại thì zero action và mọi exit đều unlock.
- Acquire physical-input lock ngay sau focus, trước settle/final preflight;
  exclusive lock thay thế post-focus user-takeover abort.
- Khởi tạo provider từ exact boss lobby giống FarmRunner cũ để sở hữu opening
  transition và first local turn; không tạo provider giữa trận.
- Dừng trước input nếu còn dưới minimum turn time hoặc policy gate không actionable.
- Không chạy qua giới hạn hai lượt bỏ.
- Ghim phải được gỡ trong `finally`.
- Chưa nối FarmRunner ngay cả khi B3 pass.

## Return gate

`PASS STRONG` khi B3 exact SWAP ACK, focus/cursor và exclusive-input release
sạch, không bỏ lượt local đầu và toàn bộ test pass. Khi đó tích hợp transport
vào FarmRunner/executor cũ theo mode
`PINNED_FOREGROUND_LEASE`; không gọi đây là true background.
