# Phase 4A.1-R2 — Pinned Foreground Lease Runbook

## Trạng thái hiện tại

Offline harness đã sẵn sàng. Production/FarmRunner chưa thay đổi. Probe chỉ
ghim cửa sổ và, khi được arm, thử đúng một click Bắt đầu bằng foreground input.

## Chuẩn bị

1. Chạy source bằng môi trường dự án, không dùng bản build.
2. Mở game tại đúng phòng chờ boss, chọn đúng boss và bảo đảm nút Bắt đầu khả dụng.
3. Giữ client game ở kích thước canonical hiện tại. Có thể đặt cửa sổ ở góc màn hình.
4. Sau khi probe bắt đầu, chuyển focus sang terminal/trình duyệt. Game vẫn nổi do `TOPMOST`.
5. Không gõ hoặc di chuyển chuột trong khoảng nửa giây ngay sau khi arm B2.

## B1 — zero input

```powershell
python tools/foreground_lease_probe.py --boss-name "<tên boss>" \
  --artifacts logs/phase4a1_r2/b1_<timestamp>
```

Kỳ vọng:

- game được ghim nhưng không tự lấy foreground;
- `B1 ACCEPTED`;
- probe không gọi foreground/cursor/click/keyboard; cursor vẫn có thể đổi do
  người dùng tiếp tục sử dụng chuột;
- khi script kết thúc, cờ topmost được gỡ.

## B2 — một click Bắt đầu

Chạy cùng probe với `--live-start`. Sau khi B1 pass, nhập chính xác
`ARM B2-LEASE` trong terminal. Lệnh khởi chạy có thể dùng `--prearmed` khi chính
việc chạy lệnh đã là thao tác arm rõ ràng của operator.

```powershell
python tools/foreground_lease_probe.py --boss-name "<tên boss>" \
  --live-start --artifacts logs/phase4a1_r2/b2_<timestamp>
```

Kỳ vọng quan sát:

- sau arm, game lấy foreground trong khoảng ngắn;
- probe chờ `0,40 s` để Unity ổn định foreground, di chuyển cursor tới nút,
  chờ thêm `0,25 s` để UI nhận hover rồi mới click;
- đúng nút Bắt đầu được click;
- focus và cursor quay về cửa sổ/vị trí trước đó nếu user không can thiệp;
- game vào trận;
- log báo `B2 ACCEPTED` và `authoritativeAck=true`;
- không có retry.

## Khi có xung đột với người dùng

- Nếu user vẫn gõ/click, lease chờ tối đa 8 giây rồi dừng `USER_BUSY_TIMEOUT`.
- Nếu Windows từ chối direct `SetForegroundWindow`, probe thử đúng một bounded
  `AttachThreadInput` handoff và luôn detach trước khi tiếp tục.
- Nếu user đổi focus trong lúc action, tool không kéo focus quay về cửa sổ cũ.
- Nếu user di chuyển cursor khỏi điểm cuối của tool, tool không snap cursor về.
- Đây là shared desktop nên người dùng nên tránh thao tác trong lease ngắn. Việc
  gõ/search giữa các lượt vẫn được phép.

## Artifact

Mỗi run lưu tại thư mục được truyền qua `--artifacts`:

```text
summary.json
events.jsonl
b1_start_proof.png
```

Không kết luận từ `SetForegroundWindow=true` hoặc click result riêng lẻ. B2 chỉ
đạt khi runtime có fresh session/opening ACK.

## Dừng

Nhấn F9. Nếu chưa bắt đầu action, probe dừng với zero input. Probe luôn cố gỡ
`TOPMOST` khi thoát, kể cả khi có exception.
