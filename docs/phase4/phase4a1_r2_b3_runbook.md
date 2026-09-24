# Phase 4A.1-R2 B3 — One Board Swap Runbook

## Chuẩn bị

1. Đóng Tool V2/FarmRunner.
2. Về boss lobby nhưng chưa cần vào trận.
3. Chạy probe B3 đã prearm:

```powershell
python tools/foreground_lease_board_probe.py --prearmed \
  --artifacts logs/phase4a1_r2/b3_<timestamp>
```

4. Khi script báo đã arm, user nhấn Bắt đầu và vào trận. Không cần tự đưa game
   xuống nền: game vẫn được ghim nhìn thấy trên cùng.
5. User có thể giữ game active hoặc tiếp tục dùng ứng dụng khác. Khi có nước hợp
   lệ, probe nhường chuột tối đa 0,75 giây rồi tạm chiếm chuột/focus. Bàn phím
   không làm hủy mouse action; probe chỉ chờ nếu nút chuột vật lý đang được giữ.

## Hành vi kỳ vọng

- Probe ghim game topmost nhưng chờ khi game còn foreground.
- Provider được khởi tạo từ boss lobby như FarmRunner cũ để giữ opening/first
  local turn; chạy probe khi đã ở trong trận bị từ chối.
- Chỉ chọn nước khi có fresh local actionable turn và còn ít nhất 7 giây.
- Không đợi user ngừng di chuột vô hạn: courtesy window là 0,75 giây; đang giữ
  nút chuột thì chưa takeover.
- Lease lấy foreground, chờ 0,40 giây, gửi đúng một two-click swap bằng executor
  hiện tại, rồi trả focus/cursor.
- Lease thử lấy focus tối đa ba lần trong giới hạn. Ngay trước executor, nó thử
  `BlockInput`; nếu Windows từ chối thì dùng cursor-confinement và chuyển điểm
  khóa theo từng cursor move của executor. Guard được lấy trước focus settle,
  giữ trong action và luôn nhả trước focus restore.
- Probe dừng ngay khi exact turn/sequence/last-move ACK hoặc timeout.
- Không retry và không chơi lượt thứ hai.

## Kết quả đạt

`B3 ACCEPTED` đòi đồng thời:

- lease `COMPLETE`;
- swap executor `SENT`;
- match ID giữ nguyên;
- turn và local move sequence tăng đúng một;
- lượt chuyển sang đối phương;
- last-move coordinates khớp exact proposal;
- focus/cursor release sạch;
- topmost được gỡ khi script kết thúc.

Attempt đầu `b3_live_20260924` không gửi input: idle guard cũ chờ 6,219 giây
làm proposal stale. B3 retry dùng remediation trên và vẫn chỉ được gửi một
swap, không tự retry.

Retry 4 prove game nhận swap nhưng fail policy vì helper cũ chỉ poll khi game
không active, làm mất lượt local đầu. Helper đã tách điều kiện cho foreground
lease; retry kế tiếp phải tạo proposal và action ngay lượt local đầu.

Retry 6 gửi zero input vì Windows từ chối `BlockInput`. Retry kế tiếp dùng
cursor-confinement fallback đã được test; log bắt buộc phải ghi `mode` là
`BLOCK_INPUT` hoặc `CURSOR_CONFINE`, sau đó release thành công.

Retry 7 prove cursor guard và exact swap ACK, nhưng vẫn chỉ đi ở local turn 3.
Retry kế tiếp arm dispatcher transport từ lobby và chỉ được phép gửi input khi
snapshot authoritative `MATCH_START` publish đúng first local turn. Nếu opening
đã trôi qua thì probe phải dừng zero-input.

Retry 8 đã bắt/publish đúng turn 1 nhưng game không nhận two-click; local move
sequence giữ 0. Đây là lỗi wrapper Phase 4 vì foreground production cũ vẫn ổn.
Retry kế tiếp giữ cursor guard và endpoint thứ hai thêm 0,20 giây sau mouse-up,
sau đó mới restore. Executor/solver/policy production không đổi.

Retry 9 `logs/phase4a1_r2/b3_retry9_20260924` đã `ACCEPTED`: opening turn 1,
sequence `0 -> 1`, exact inverted-row coordinates, turn chuyển sang boss,
cursor guard/focus/cursor/topmost đều release sạch. B3 đã đóng `PASS STRONG`;
không chạy thêm B3.

Sau khi probe dừng, user tự thoát trận. Không để game tự qua ba lượt bỏ.
