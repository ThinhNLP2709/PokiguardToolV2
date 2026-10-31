# Hướng dẫn AI/suy luận sau Phase 5

Chốt31/10/2026. [Phạm vi nghiệm thu](FINAL_REPORT.md), [rollback](ROLLBACK.md).
Tool vẫn mặc định **Cơ bản/BASIC**. Theo yêu cầu mới sau closeout, bản thử UI
cho phép chọn **Suy luận Demon Farm — Khiên (thử nghiệm)** trong tab AI.
Đường UI mới đã PASS offline và2trận live ngày01/11/2026 đúng scope; không thay đổi
kết luận hoặc quyền chạy của ZIP F1 đã đóng.

## Chọn chế độ đúng

| Lựa chọn | Tác dụng hiện tại |
|---|---|
| Cơ bản | Dùng lối chơi/cài đặt hiện có, không khởi tạo worker suy luận khi shadow tắt |
| Bật chẩn đoán shadow thử nghiệm | Tính/ghi chẩn đoán song song trong scope được cho phép; nước thực tế vẫn BASIC. Không phải nút bật suy luận điều khiển |
| Suy luận Demon Farm — Khiên (bản thử UI mới) | Cho chọn khi cấu hình đúng scope; chỉ hoạt động với profile local đã kiểm cho đúng bản tool/game/host/account/đồ. Thiếu hoặc không khớp thì dùng BASIC và hiện lý do |
| Phiên suy luận có kiểm soát | Chỉ chạy khi mở tool bằng hồ sơ đúng binary/game/host/account/loadout và giới hạn đã duyệt |

Shadow mặc định tắt; F1 nghiệm thu với shadow tắt. Việc UI cho tick shadow
không tự chứng minh profile/game đang dùng đã được nghiệm thu. Coop/Bú win và
Khủng long không được mở suy luận/shadow từ nghiệm thu Solo.

## Bật hoặc tắt suy luận trong bản thử UI mới

1. Chọn Demon Farm, pet thường, không tiến hóa, nội tại ăn Khiên, ngưỡng
   4 Kiếm hiệu dụng; Solo/Lieyun77, hai lần nhấp, tiền cảnh, 1280×640.
   Giữ account/đồ/stats đã dùng khi nghiệm thu.
2. Trong AI, chọn **Suy luận Demon Farm — Khiên (thử nghiệm)** rồi **Lưu cấu
   hình AI**. Shadow tự tắt. Budget được lưu, tối đa dùng 4000ms trong scope
   này; vẫn trừ thời gian dự phòng cho input. Bấm Bắt đầu trong tool như cũ.
3. Đọc trạng thái AI: sẵn sàng/đang tính hoặc lý do dùng Cơ bản. Nút radio
   được chọn không đồng nghĩa lượt đó được AI chọn nước. AI có thể giữ nguyên
   nước BASIC; không cần đổi nước để được tính là hoạt động.
4. Muốn tắt, dừng phiên hiện tại, chọn **Cơ bản** và lưu AI. Phiên đang chạy
   khóa cấu hình; lần Start/Tiếp tục tiếp theo dùng lựa chọn mới.

Profile nghiệm thu được chuẩn bị ngoài EXE/ZIP tại
`<dataRoot>/preferences/reasoning_acceptance/acceptance.json`; không tái dùng
request/claim F1. Cấu hình không hỗ trợ hoặc lỗi/timeout AI giữ BASIC hợp lệ,
không tự dừng farm. Khi pointer/game/input không hợp lệ, các chốt an toàn cũ
vẫn có hiệu lực. Log AI riêng tại `logs/farm_runs/reasoning/ui_<id>/`, nối
`session.json` với farm run và xem `watermarks.json` sau đóng tài nguyên.

## Dùng BASIC

1. Mở tool thông thường, chọn lối chơi, pet/loadout, boss và mục tiêu farm như
   trước. Giữ **Cơ bản**, tắt shadow nếu không cần chẩn đoán.
2. Trong tab AI, **Lưu cấu hình AI** để lưu các trường AI. Việc này không tự
   Start trận. Preferences cũ thiếu AI được bổ sung mặc định an toàn.
3. Bấm Bắt đầu trong tool theo flow của mode đã chọn. Phase5 không đổi room,
   thứ tự đọc memory/chụp ảnh, input, QTE, ACK hoặc recovery.

## Phiên suy luận đã nghiệm thu

Package F1 lịch sử chỉ có lab scope: Solo/Lieyun77/Demon Aegis thường, không tiến
hóa, nội tại ăn Khiên, setting4Kiếm hiệu dụng, cùng account/đồ/stats đã pin;
foreground/hai lần nhấp/1280×640, budget4000ms. Hồ sơ còn ràng buộc hash EXE,
game build, host, hạn sử dụng và cap. Không đổi các trường đó trong một phiên
đã khóa; tool phải từ chối hồ sơ không khớp.

F1 đã dùng hết4attempts và đóng. Không mở lại request/claim hoặc sửa cap/nonce
để dùng tiếp; đây không phải hồ sơ farm vô hạn. UI mới dùng profile thẩm định
riêng đã kiểm, không tái kích hoạt request F1. Bật UI không mở account/đồ/boss/
game/host khác scope đã pin. [Kết quả UI](ui_reasoning_delivery_20261031.md).

Khi một phiên hợp lệ được chuẩn bị, người dùng giữ đúng phòng/pet/đồ rồi tự
bấm **Bắt đầu trong TOOL** một lần. Tool chuẩn bị nước BASIC trước và xét cùng
dữ liệu bằng suy luận. Nước suy luận có thể trùng BASIC, hoàn toàn bình thường.
Không đổi cài đặt chỉ để ép tool chọn nước khác.

## Hiểu cài đặt và ngân sách

- Với Demon Farm, trường **Viên mục tiêu** chọn Khiên/Máu/Mana/Hút/Nộ; setting
  BASIC này không tự mở suy luận cho các viên khác. F1 chỉ nghiệm thu Khiên.
- Ngưỡng Kiếm/setup/ra skill là mục tiêu tham khảo khi R có đủ bằng chứng trong
  đúng profile. Nó không cho phép dùng skill thiếu Mana/Nộ, sai nguồn, cooldown,
  sai lượt hoặc PASS trái luật.
- “Kiếm hiệu dụng” tính hệ số của viên:1Kiếmx2 tương ứng2đơn vị Kiếm. Số ô
  Kiếm thực tế vẫn được giữ riêng; không tự suy mọi account có thể dùng ít hơn.
- UI chấp nhận budget50–6000ms, mặc định4000ms. Đây là trần tính, không phải
  thời gian chờ thêm cố định. Phiên F1 chỉ nghiệm thu4000ms; tăng trường UI
  không nới deadline hoặc authority của hồ sơ đó.
- Tool còn trừ phần thời gian dành cho preflight/input và margin. Không đủ
  thời gian, lỗi worker hoặc thiếu bằng chứng thì dùng BASIC còn hợp lệ.
- Receipt suy luận hợp lệ không cộng random reaction/jitter giữa hai click;
  pacing cơ sở, cursor settle, mouse hold và kiểm Stop vẫn giữ. BASIC/fallback
  giữ random theo cấu hình hiện có.

Không có cam kết tìm tối ưu toàn cục, không chết, hoặc tiết kiệm năng lượng
hơn BASIC. Kết quả hiệu quả cuối Phase5 vẫn INCONCLUSIVE.

## Tắt suy luận/shadow

Khi đang chạy, dùng **Dừng sau trận hiện tại** nếu muốn kết thúc bình thường;
dùng **Dừng khẩn cấp** khi cần ngừng ngay. Đợi controller ngừng và cleanup hoàn
tất. Sau đó mở tool bình thường không kèm hồ sơ lab, chọn Cơ bản, bỏ tick shadow
và lưu AI. Không cần xóa log, request, claim hay chỉnh file game để tắt AI.

Fallback trước input không bỏ qua gate an toàn. Nếu input đã gửi, tool không
gửi lại nước BASIC thay thế; pending/ACK/recovery cũ xử lý kết quả. Vì vậy dừng
do mất game/foreground/sai state phải được phân tích như lỗi flow/input riêng,
không mặc định quy cho suy luận.

## Xem log và gửi phản hồi

| Nơi lưu | Dùng để tìm |
|---|---|
| `logs/farm_runs/<farm_run_id>/` | Trận, attempts, nước thực gửi, ACK, terminal, Stop/recovery; xem run.json/checkpoint.json và combat.jsonl của từng attempt |
| `logs/desktop_ui/<session>/` | Trạng thái giao diện, Start/Stop/lifecycle/target, events.jsonl và summary.json |
| `packaged_acceptance/` hoặc `operational_pilot/` trong UI session | Phiên lab, job/selection/timing, worker và watermarks.json |
| `logs/startup/` | Lỗi khởi động/path/instance hoặc từ chối hồ sơ |

Package thông thường dùng `%LOCALAPPDATA%/PokiguardToolV2/logs/`.
Source run thường dùng `D:/PokiguardToolV2/logs/`; dataRoot tùy chỉnh có thể đổi
nơi lưu. Riêng F1 đã đóng ở
`D:/PokiguardToolV2/docs/phase5/artifacts/5f1_packaged_20261031/live_data/logs/`.

Khi gặp bỏ lượt/dừng bất thường, giữ toàn bộ thư mục farm run và UI session
tương ứng; ghi giờ xảy ra, số trận, boss/pet/lối chơi và có đổi focus/game hay
không. Không chỉ gửi một dòng AI hoặc ảnh trạng thái dừng. Không xóa evidence
trước khi đối chiếu input/ACK/terminal.

Để lọc suy luận, dùng `event_type` bắt đầu `reasoning.` và nối theo `run_id`,
`job_id`, match/turn/source/board hash. `reasoning.decision` là kết quả tính;
`reasoning.selection` gồm ROOT/FRESH/FINAL nên nhiều dòng không có nghĩa nhiều
nước đi. `reasoning.swap_timing` đối chiếu thời gian; input thực nằm ở combat log.
`RETAIN_BASELINE` sau COMPLETED khác với lỗi/timeout hoặc NO_COMPLETED_PROPOSAL.

Trong phiên lab, UI có thể vẫn báo OFF/SHADOW_DISABLED cho cài đặt shadow thông
thường. Kiểm receipts/worker counters/log operational của phiên để biết R có
thực sự chạy, không dựa riêng nhãn đó.

Trong watermarks/stats, chú ý `eligible/enqueued/written`, dropped/failed/
discarded, `flushed/closed`, collector disabled và worker faults/late/reaped.
Mất dòng hoặc thiếu receipt không được diễn giải thành thành công. Rotation có
giới hạn làm mất file quá cũ theo retention, khác với mất record trong phiên.
Không hứa toàn bộ log giữ vĩnh viễn hoặc tổng mọi thư mục chỉ có một quota.

| Nhóm lý do | Cách hiểu |
|---|---|
| Completed retention | Đã xét xong, giữ BASIC; không phải lỗi |
| Missing/unsupported/source changed/expired/late | Không dùng proposal; state hợp lệ thì baseline/preflight hiện có quyết định |
| Worker/log/timing fault, breaker | Suy luận có thể bị tắt cho phiên; tra lỗi riêng, không gửi lại action đã dispatch |
| Foreground/process/ownership/state/ACK fault | Gate vận hành; tra combat/farm/UI cùng thời điểm, giữ fail-closed |

Không đổi tên log cũ, xóa claim, tăng timeout hoặc tắt safety gate để che nguyên
nhân. [Final report](FINAL_REPORT.md) liệt kê các giới hạn chưa được nghiệm thu.
