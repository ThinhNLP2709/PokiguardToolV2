# Phase 4A.1-R2 — Pinned Foreground Lease Probe

## Mục tiêu

Kiểm chứng một phương án cùng desktop sau khi `PostMessageW` không tạo ACK:

1. ghim đúng cửa sổ game bằng `HWND_TOPMOST` + `SWP_NOACTIVATE`;
2. để người dùng tiếp tục dùng cửa sổ khác giữa các hành động;
3. khi có hành động đã được policy quyết định, chờ một khoảng user-idle ngắn;
4. chiếm foreground/chuột trong một lease có giới hạn;
5. gửi đúng một hành động bằng đường foreground input đã được chấp nhận;
6. trả focus và chuột có điều kiện;
7. xác nhận kết quả qua read-only runtime ACK.

Đây là `PINNED_FOREGROUND_LEASE`, không phải background input. Không sửa
FarmRunner hoặc Desktop UI trong phase probe này.

## Giới hạn triển khai

- Chỉ thêm harness trong `tools/`, test và tài liệu Phase 4.
- Không dùng `BlockInput`.
- Không gửi `PostMessageW`, memory write, injection hoặc direct game method.
- Không thu nhỏ/resize cửa sổ game trong probe; giữ client geometry đã bind.
- Mỗi lần arm chỉ cho đúng một hành động, không retry tự động.
- F9 phải dừng trước hành động nếu lease chưa phát input.

## Bài test

### B1 — Pin và quan sát, zero input

- Bind exact PID/HWND/title/client geometry.
- Gọi `SetWindowPos(HWND_TOPMOST, SWP_NOMOVE|SWP_NOSIZE|SWP_NOACTIVATE)`.
- Game phải visible, không minimized và không foreground.
- Chứng minh đúng boss, đúng target, đúng nút Bắt đầu bằng runtime + hai ảnh.
- Không có lời gọi foreground/cursor/click/keyboard từ probe. Con trỏ được phép
  đổi do người dùng vẫn có quyền sử dụng chuột trong B1.

### B2 — Một lease cho nút Bắt đầu

- User hoặc lệnh khởi chạy phải arm rõ ràng.
- Chờ `GetLastInputInfo >= 450 ms` và không có phím/nút chuột đang giữ.
- Revalidate binding và lobby preflight.
- Lưu foreground HWND và cursor.
- Foreground game, revalidate lần cuối, click đúng điểm Bắt đầu đã prove.
- Nếu game vẫn giữ foreground và cursor vẫn ở điểm do tool đặt, trả lại cả hai.
- Nếu user đã đổi focus/cursor, không ghi đè thao tác của user.
- Kết quả chỉ `ACCEPTED` khi có fresh session/opening ACK.

## Gate

`PASS STRONG` chỉ khi B1 và B2 đều accepted, nút Bắt đầu có authoritative ACK,
không input ngoài arm, focus/cursor được trả hoặc được bỏ qua đúng vì user đã
take over, và artifact đầy đủ. Khi pass, tạo remediation kế tiếp để prove một
board swap bằng lease trước khi tích hợp production.

Nếu B2 không có ACK, focus không lấy được hoặc hành động bị stale thì giữ phase
ở `BLOCKED/PARTIAL`; không nối FarmRunner.
