# Phase 3B.2 — Runbook live automated QTE directions

Tool chỉ tự nhấn **bốn phím hướng** của một QTE đã bind. Bạn vẫn tự click thẻ
Pet Skill và tự nhấn **Space**. Không bật Desktop UI/FarmRunner trong bài test.

Live B1--B4 ngày 2026-09-04 đã PASS STRONG với 3/3 generation, 21/21 hướng
được RAM xác nhận và không có wrong/duplicate/stale/unconfirmed input. Runbook
này được giữ cho regression/reproduction; mỗi lệnh vẫn chỉ arm một generation.

## B1 — Một QTE

1. Đóng Desktop FarmRunner/tool auto nếu đang chạy.
2. Chọn pet thường tương thích với `Huyền Thoại 7`, đứng ở đúng boss lobby.
3. Mở PowerShell tại `D:\PokiguardToolV2` và chạy:

```powershell
python tools/qte_direction_assist.py --arm-next --timeout 1800
```

4. Tự vào trận và tự chơi lượt đầu/tích tài nguyên/tiến hóa. Tool sẽ lấy inactive
   baseline trong combat rồi báo:

```text
ARMED: manually click the Pet Skill card when ready; do not press directions.
```

5. Khi thẻ Pet Skill sáng, **bạn tự click thẻ đúng một lần**.
6. Không nhấn Arrow/WASD. Tool sẽ gửi từng hướng và chỉ gửi hướng kế tiếp sau khi
   RAM chứng minh hướng trước đã được game nhận.
7. Khi thấy tool/sequence đã hoàn tất:

```text
DIRECTIONS COMPLETE: assist DISARMED. Press Space manually ...
```

   bạn tự nhấn Space ở timing mong muốn. Tool tuyệt đối không nhấn Space.
8. Chờ observer bắt response và tự dừng. Có thể tiếp tục/kết thúc trận bằng tay.

Nếu tool báo `INPUT_SENT_UNCONFIRMED`, mất foreground hoặc disarm vì identity,
không spam phím. Hoàn tất QTE bằng tay nếu game còn cho phép và báo lại exact
message.

## B2/B3 — Hai generation tiếp theo

Mỗi lệnh `--arm-next` chỉ cấp quyền cho một generation. Cần tổng ít nhất ba QTE
thành công.

Cách acceptance sạch nhất là về boss lobby rồi chạy lại cùng lệnh cho mỗi QTE.
Nếu muốn lấy generation tiếp theo ngay trong cùng combat, chỉ chạy lệnh mới khi
QTE trước đã đóng và Pet Skill đang inactive:

```powershell
python tools/qte_direction_assist.py --arm-next --allow-combat-start --timeout 900
```

Đây vẫn là một explicit re-arm mới. Không chạy hai process assist cùng lúc;
shared controller lease sẽ từ chối process thứ hai.

## Thông tin cần báo

Sau mỗi lần chỉ cần nhắn:

```text
Đã xong B1/B2 QTE số ...
Chuỗi hiển thị trên game: ...
Tool nhập đúng/sai: ...
Kết quả sau khi tôi tự nhấn Space: PERFECT/GOOD/BAD
Hiện đang ở: ...
```

Log nằm trong `logs/phase3b2_qte_direction_*.jsonl`; không cần tự tìm file.

## Dừng an toàn

- Ctrl+C: disarm và dừng harness; sau acknowledgement không có phím mới.
- Alt-Tab/mất foreground: direction sắp gửi bị chặn và assist disarm.
- Đổi MatchId/session/card/generation/turn hoặc QTE đọc mơ hồ: gửi 0 phím tiếp.
- Không nhấn Start trong Desktop UI/FarmRunner song song.
- Không sửa game, không cấp quyền ghi process, không hook/inject/network call.
