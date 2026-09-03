# Phase 3B.1 — Runbook live Production Shadow QTE

Observer Phase 3B.1 **chỉ đọc memory**. Nó không click thẻ Pet Skill, không gửi
phím hướng/WASD, không nhấn Space/Enter, không đánh board và không gọi method hay
network của game. Toàn bộ thao tác Pet Skill/QTE trong bài test này do người dùng
thực hiện bằng tay.

## Chuẩn bị

1. Đưa game về đúng boss lobby và chọn pet thường có thể tiến hóa thành
   `Huyền Thoại 7`.
2. Không bật Desktop FarmRunner/auto farm trong cùng bài test để không trộn hai
   nguồn thao tác.
3. Chạy từ `D:\PokiguardToolV2`:

```powershell
python tools/pet_qte_observer.py --watch --qtes 3 --timeout 1800
```

Observer phải được mở từ lobby để lấy baseline inactive sạch. Dòng xác nhận đúng:

```text
Phase 3B.1 production shadow observer READ-ONLY
NO INPUT: perform every Pet Skill/QTE action manually.
```

## B1 — Capability và live CardUI

Vào trận bằng tay, đánh lượt đầu rồi tích đủ tài nguyên và tiến hóa thành
`Huyền Thoại 7`. Khi thẻ skill sáng, chờ khoảng một giây trước lần bấm đầu để
observer có cơ hội ghi capability nếu live CardUI đã xuất hiện.

Nếu `Active.playerPets` vẫn ghi pet nguồn `Silas / petId 2306`, đây là trạng thái
đã được chứng minh của game, không phải lỗi. Identity skill sau tiến hóa phải lấy
từ exact current `CardUI/CardData`, không được đổi tên pet nguồn thành pet huyền
thoại bằng suy đoán.

## B2/B3 — Ba QTE hoàn toàn thủ công

Thực hiện ít nhất ba activation tự nhiên nếu tài nguyên cho phép:

1. đọc dãy trên game và nhập đúng bằng phím mũi tên, xác nhận Space;
2. đọc dãy và nhập đúng bằng WASD, xác nhận Enter;
3. dùng cách thuận tay, cố xác nhận trong vùng Perfect như bình thường.

Không cố tạo BAD và không spam confirm. Observer chỉ dự đoán shadow và ghi log;
không chờ/sleep tới midpoint, không gửi bất kỳ phím nào. Với mỗi QTE, sequence
server và `qtePresses` cuối sẽ được so sánh toàn bộ nên không phụ thuộc việc poll
có nhìn thấy từng frame trung gian hay không.

## B4/B5 — Generation, tài nguyên và lượt

- Cần ít nhất hai generation khác nhau; ba QTE trong cùng trận là tốt nhất.
- Ít nhất một skill không nên kết thúc trận. Sau khi xác nhận, chờ vài giây trước
  thao tác kế tiếp để observer đọc Mana/Rage và lượt sau response.
- Với `Huyền Thoại 7`, `conditionUse=200` là Mana bị tiêu hao còn `power=200`
  là ngưỡng Nộ tối thiểu, không phải Nộ cost. Pet Skill tự phá board/cascade sau
  confirm, nên net Nộ/HP có thể đổi do chính các gem được ăn.
- Không đi thêm nước sau confirm. Chờ khoảng 6 giây để observer bắt response,
  automatic board effect và turn edge trước khi thao tác tiếp.
- Generic `MATCH_SKILL_USE_RES` của Pokiguard 1.7.4 có thể không echo
  `timingResult`. Khi đó response correlation vẫn có thể current, nhưng trường
  `server_resolved_result` phải để UNKNOWN; kết quả runtime được đọc riêng từ
  `CardUI.timingText`.

Observer tự dừng sau ba QTE server-correlated. Nếu trận kết thúc sớm, có thể vào
trận tiếp theo bằng tay; MatchId mới phải tạo session/generation độc lập. Pet
Skill fixture hiện tại tự xử lý board sau Space và đã được live quan sát là một
action tiêu hao lượt; không gửi thêm board input sau QTE.

## Báo lại

Khi observer dừng, chỉ cần nhắn:

```text
Đã xong Phase 3B.1 live.
QTE 1: cách nhập ..., kết quả nhìn thấy ...
QTE 2: cách nhập ..., kết quả nhìn thấy ...
QTE 3: cách nhập ..., kết quả nhìn thấy ...
Hiện đang ở ...
```

Không cần tự tìm file log. File có dạng
`logs/phase3b1_qte_shadow_YYYYMMDD_HHMMSS.jsonl`.

## Dừng/fail closed

- Nếu game mất kết nối, sequence hiển thị không khớp hoặc observer báo lỗi, không
  spam phím; dừng observer bằng `Ctrl+C` và báo trạng thái.
- Không chạy FarmRunner song song.
- Không sửa game, không cấp quyền ghi process, không hook/inject.
