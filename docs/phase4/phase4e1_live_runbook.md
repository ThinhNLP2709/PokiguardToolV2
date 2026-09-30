# Phase 4E.1 — Packaged Pinned Foreground Beta Acceptance Runbook

Ngày chuẩn bị: 2026-09-30 (Asia/Saigon).

## Artifact bị khóa

Tất cả bài live phải dùng đúng artifact này; không rebuild giữa các bài:

```text
Version: v1.1.0
ZIP: D:\PokiguardToolV2\build\v1.1.0\PokiguardToolV2-v1.1.0-win-x64.zip
SHA-256: ba0f9f010bd1581beaf9123a8e751948c0b7d0d25c6c553101c3ccbac97153c5
ZIP bytes: 14,134,497
Bundle files: 994
Bundle bytes: 30,420,169
EXE bytes: 4,176,976
```

Artifact source:

```text
Base commit: e6463040cee82d155c33d285893a73d70432637f
Production source fingerprint:
23b7fcc5411fb3645527357de68ad5fd15ea20c483e346b8d40853398782d815
```

Fingerprint chứa remediation recovery của sự cố long-run
`94e0d6932b104a759c31a83f08563aca` và remediation stdout/stderr cho EXE
windowed. Phase 4D.2 vẫn là baseline chức năng trước remediation; B1–B6 phải
chạy lại trên hash artifact mới này.

## Biên vận hành

- Game do người dùng mở và đưa vào phòng boss.
- Mode Beta giữ game visible/topmost, không hỗ trợ minimized.
- Tool có thể tạm chiếm foreground và khóa input trong lease có giới hạn.
- Không gọi mode Beta là background hoặc minimized.
- Mỗi bài dùng data root riêng, trừ cặp checkpoint/resume cố ý dùng chung.
- Sau mỗi bài Codex chỉ đọc log sau khi người dùng báo đã xong.

## B1 — Foreground mặc định, một trận

1. Người dùng vào đúng boss lobby.
2. Chọn `Tiền cảnh (mặc định)`.
3. Cấu hình Pet Skill đã accepted, target `1`, max attempts `3`.
4. Lưu rồi Start; không đổi cửa sổ trong lúc chạy.
5. Chờ tool hoàn thành và về boss lobby.

Yêu cầu: 1/1 completed, zero safety violation, không tự Start/Resume, QTE nếu
phát sinh phải ACK sạch.

## B2 — Beta một trận + Pet Skill QTE

1. Chọn `Ghim game để tự chơi khi dùng máy — Beta`.
2. Target `1`, max attempts `3`, giữ profile Pet Skill/Audition v3 đã accepted.
3. Lưu rồi Start. Có thể dùng ứng dụng khác nhưng không minimize/resize game.
4. Chờ một trận hoàn thành.

Yêu cầu: pin/unpin đúng một phiên, Pet Skill nếu phát sinh có 1 click thẻ,
7/7 direction ACK, 1 Space, PERFECT; full guard và cleanup sạch.

## B3 — Beta bounded multi-match + navigation/re-entry

1. Giữ Beta, target `3`, max attempts `5`.
2. Start từ boss lobby.
3. Sau khi trận 1 đã được tính và tool vừa về boss lobby, người dùng nhấn `X`
   để ra đảo đúng một lần.
4. Không thao tác thêm; để tool tự vào lại boss room và hoàn thành 3/3.

Yêu cầu: 3 completed, không có attempt dư, native boss-cell re-entry đúng target,
fresh room/opening ACK và zero critical counter.

## B4 — Graceful stop + checkpoint/resume

1. Data root mới; Beta, target `3`, max attempts `5`.
2. Start và nhấn `Dừng sau trận hiện tại` trong trận đầu.
3. Chờ trận đó kết thúc, tool về boss lobby và dừng graceful.
4. Đóng tool bình thường.
5. Mở lại cùng EXE với đúng data root này; không sửa checkpoint.
6. Nhấn `Tiếp tục từ checkpoint`, chờ tổng lịch sử đạt 3/3.

Yêu cầu: checkpoint canonical resumable, continuation đúng FarmRun gốc, ba
MatchId duy nhất, không double-count và dừng tại boss lobby.

## B5 — Emergency stop

1. Data root mới; Beta, target `3`, max attempts `5`.
2. Start từ boss lobby.
3. Khi combat đang active, nhấn `Dừng khẩn cấp — Ngay lập tức` một lần.
4. Sau ACK không thao tác tool nữa; người dùng tự đưa game về boss lobby nếu cần.

Yêu cầu: controller dừng, UI responsive, không có input/new match/result giả sau
emergency ACK, mọi mouse/keyboard guard được nhả.

## B6 — Final shutdown và write audit

Đóng packaged UI bình thường. Kiểm tra:

- tool process/poller/controller đều dừng;
- game vẫn chạy;
- ZIP và extracted bundle không đổi;
- source repository, game install và thư mục cạnh EXE không có runtime write;
- dữ liệu mutable chỉ nằm trong các data root acceptance.

Phase 4E.1 chỉ `PASS STRONG` khi B1–B6 đều sạch trên cùng SHA-256 phía trên.
