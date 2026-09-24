# Phase 4A.1 — Live Probe Runbook

Tài liệu này áp dụng cho harness độc lập ở
`tools/background_mouse_probe.py`. Harness chưa được nối vào Desktop UI,
policy hoặc FarmRunner.

## 1. Phạm vi đã triển khai

- `B1`: attach/read-only, exact PID/HWND/title/client geometry, exact target và
  hai visual proof liên tiếp của nút Start; mặc định zero input.
- `B2`: đúng một background single click vào Start sau explicit arm; ACK là
  fresh `MATCH_START` session và stable production-ready 64-cell opening.
- `B3`: đúng một background two-click adjacent swap; ACK là exact turn + local
  move sequence + `LastMove` coordinates + opponent owner.
- `B4`: đúng một background drag/flick trên local turn mới; ACK giống B3.

Mỗi lần chạy giữ cooperative automation-controller lease. Harness dừng nếu có
controller khác đang hoạt động.

## 2. Chuẩn bị chung

1. Dùng game b4 đã được profile hiện tại chấp nhận.
2. Vào đúng Chinh Phục boss lobby, chọn đúng boss/pet và để nút Start hiện rõ.
3. Game phải visible, không minimized và không resize trong probe.
4. Đưa cửa sổ Codex/terminal nhỏ lên foreground nhưng không che nút Start hoặc
   bàn cờ. Không đặt một cửa sổ full-screen đè lên game.
5. Không tự click game trong khi harness đang chờ ACK.
6. `F9` dừng khẩn cấp. Sau khi harness nhận Stop, input mới bị khóa. Nếu DOWN
   đã queue thì chỉ còn một UP cleanup bắt buộc.

## 3. B1 — zero-input attach

Chạy từ thư mục gốc:

```powershell
python tools\background_mouse_probe.py --boss-id 1289
```

Không có `--live-sequence` thì harness không có đường phát input. Kết quả đạt
khi:

- exact room/target/Start proof ổn định;
- game nonforeground xuyên suốt;
- system cursor đầu/cuối không đổi;
- `inputCounts` đều bằng 0.

Nếu đang ở game lobby, sai boss lobby, game foreground, minimized, resize hoặc
Start bị cửa sổ khác che, B1 là `NOT_RUN/STOPPED` và zero input.

## 4. B2–B4 — bounded live sequence

Sau khi B1 riêng đạt, trở lại boss lobby và chạy:

```powershell
python tools\background_mouse_probe.py --boss-id 1289 --live-sequence
```

Harness vẫn chạy B1 trước. Sau đó nó yêu cầu các câu arm chính xác:

```text
ARM B2
ARM B3
ARM B4
```

Ý nghĩa:

- `ARM B2`: queue tối đa `MOVE/DOWN`, giữ DOWN 25 ms như V1 Beta, rồi `UP` tại
  Start đã được runtime + visual proof; không tự retry nếu không có opening
  ACK.
- `ARM B3`: cấp quyền trước cho đúng một future local turn; harness chỉ queue
  hai sequence `MOVE/DOWN/UP` sau khi đã chốt fresh proposal và final direct
  preflight; không retry nếu partial hoặc unconfirmed.
- `ARM B4`: cấp quyền trước cho một local turn mới; sau fresh proposal harness
  queue `MOVE`, `DOWN`, các held `MOVE`, một
  held overshoot `MOVE`, rồi `UP` cleanup.

Nhập `STOP`, nhấn `Ctrl+C` trước arm, hoặc nhấn `F9` để không chạy stage đó.
Không nhập arm khi game đã foreground, đổi kích thước, đổi room/session hoặc
không còn đúng local turn.

## 5. Board-only fallback sau B2

Nếu B2 không tạo được match, B3/B4 được kiểm tra độc lập bằng:

```powershell
python tools\background_mouse_probe.py --boss-id 1289 --board-sequence
```

Route này vẫn attach từ exact lobby và chạy B1 trước. Sau `ARM B3`, người dùng
tự click Start rồi đưa Codex/terminal lên foreground. Harness ghi manual Start
là `backgroundCapabilityClaim=false`, chờ exact opening, sau đó mới gửi một
background B3 proposal đã preflight. Nhờ vậy kết quả board transport không bị
gộp với single-click B2.

Sau khi B3 đã có kết luận riêng, B4 chạy ở một fresh manual-entry session bằng:

```powershell
python tools\background_mouse_probe.py --boss-id 1289 --board-sequence --board-primitive drag
```

Run này chỉ chấp nhận `ARM B4`, không gửi two-click trước drag và không tái dùng
session/proposal B3.

### Nhịp vận hành live chuẩn

Để người dùng quan sát game và tránh phản ứng chậm khi gần ngưỡng ba lượt bỏ:

1. người dùng yêu cầu chạy một stage cụ thể;
2. agent start và arm script đúng một lần;
3. người dùng tự vào trận, đưa game xuống background và quan sát;
4. agent không poll terminal trong khi trận đang chạy;
5. nếu chưa có action sau số lượt đã thống nhất, người dùng tự thoát; nếu action
   đã xảy ra thì chỉ quan sát 1–2 action rồi tự thoát;
6. sau khi người dùng báo đã thoát, agent mới đọc `summary.json` và
   `events.jsonl`.

Harness chạy độc lập nên polling terminal không điều khiển thời điểm phát input,
nhưng nhịp trên cho người dùng quyền kiểm soát luật ba lượt bỏ rõ ràng hơn.

## 6. Artifact và cách đọc

Mặc định artifact nằm ở:

```text
logs/phase4a1/probe_YYYYMMDD_HHMMSS/
```

Mỗi run chứa:

- `summary.json`: kết quả B1–B4, số input sequence, source commit, game hash,
  PID/HWND/title/geometry, capability board tạm thời;
- `events.jsonl`: pre-state, mỗi Win32 message, client coordinate, packed
  `lParam`, monotonic timestamp, foreground HWND, queue return, ACK polls và
  post-state;
- `b1_start_proof.png`: proof của Start khi B1 đạt.

`PostMessageW=true` chỉ là `QUEUED`. Kết quả chỉ là `ACCEPTED` khi ACK memory
khớp exact action. Hết deadline mà không có ACK là `UNCONFIRMED`; harness không
retry.

## 7. Kết quả hiện tại

- Offline transport tests: pass.
- Full regression gần nhất trước remediation hold: pass 1.402 tests.
- Ba attempt chuẩn bị B1 đã dừng zero-input:
  - attempt 1: game foreground, zero input;
  - attempt 2: lỗi console encoding, zero input; đã sửa UTF-8;
  - attempt 3: runtime ở `GAME_LOBBY`, không phải exact boss lobby, zero input.

Sau đó B1 đã `ACCEPTED` với zero input. B2 run đầu tiên
queue đủ ba message và giữ game nonforeground/cursor unchanged nhưng
`UNCONFIRMED`: lifecycle ở lobby suốt 45 giây. Đối chiếu V1 sau run cho thấy
harness đã thiếu bounded 25 ms hold giữa DOWN/UP, nên run đó chỉ bác bỏ pulse
tức thời và không được dùng để kết luận về V1 candidate. Hold đã được khôi phục;
mọi lần chạy lại phải là remediation run có arm mới, không auto-retry.

Kết quả chính thức:

- B1: `ACCEPTED`, zero input;
- B2 có hold: `UNCONFIRMED`, ba message queued nhưng không có entry ACK;
- B3 two-click: `UNCONFIRMED`, sáu message queued nhưng turn/sequence/last-move
  không đổi;
- B4 drag: `UNCONFIRMED`, bảy message queued gồm `UP` cleanup nhưng
  turn/sequence/last-move không đổi;
- mọi run hợp lệ giữ game nonforeground, không di chuyển system cursor và không
  retry input unconfirmed.

Phase 4A.1 kết luận `BLOCKED`. Không chạy 4A.2 hoặc tích hợp production nếu chưa
có một transport hypothesis mới có bằng chứng.
