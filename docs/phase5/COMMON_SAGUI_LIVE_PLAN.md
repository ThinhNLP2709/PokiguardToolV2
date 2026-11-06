> **Kế hoạch lịch sử, đã thay thế ngày 02/11/2026.** Không activate draft Sagui
> source499efb… bên dưới. User xác nhận cùng geometry và yêu cầu AI chung, nên
> không bắt live riêng từng target. Case đại diện và draft đúng source hiện tại
> nằm ở [COMMON_AI_ASSISTANT](COMMON_AI_ASSISTANT.md), tối đa 3 BASIC + 3 R
> mới nếu user sẵn sàng; chưa có request/claim/activation.

# Kiểm Demon Sagui ăn Máu — bản nháp, chưa chạy

## Tạm giữ vì cập nhật B14 — 01/11/2026

**PAUSED_FOR_B14_COMPATIBILITY — DRAFT_OBSOLETE.** User yêu cầu cập nhật game
trước. Draft fingerprint/build trước B14 không còn dùng để activate. Giữ nguyên
artifact để truy vết; chưa tạo request/claim và live mới vẫn0. Chỉ chuẩn bị draft
mới sau B14 acceptance và khi quay lại cohort; không relabel timing/proof cũ.
[Report thích ứng](../petpuzzle_b14_compatibility_report.md).


01/11/2026. Yêu cầu chính vẫn là AI chung; đây là trường hợp kiểm đầu tiên cho
target mới sau khi user xác nhận cả 5 viên có chung cơ chế quét vuông góc.
Không mở chuỗi P mới. Xem [trạng thái chung](COMMON_REASONING.md).

## Cấu hình dự kiến

| Mục | Giá trị |
|---|---|
| Pet | Demon Sagui, ăn Máu — user cung cấp; ID runtime chưa quan sát |
| Boss đề xuất | Lieyun lv77, dùng lại phòng của các phép thử trước |
| Lối chơi | Demon Farm, Solo, pet thường, không tiến hóa, nội tại pet |
| Viên mục tiêu | Máu |
| Mục tiêu Kiếm | 4 Kiếm hiệu dụng, tính x2/x3; đây là mục tiêu cấu hình |
| Input | Foreground, two-click, kích thước gốc 1280×640 |
| Giữ ổn định | Pet, đồ, boss và cài đặt random trong cả trường hợp |

## Giới hạn và trình tự

Đề xuất tối đa **6 lượt thử mới** cho trường hợp này: **3 BASIC**, rồi tối đa
**3 REASONING** sau khi đọc dữ liệu và hoàn tất review runtime riêng. Ba lượt
BASIC được tính theo attempt, không tự đánh thêm để tìm đủ WIN hoặc đủ mẫu.
Nếu cần thay cấu hình hoặc thêm trận, phải chốt lại với người dùng; không tự
mở rộng cap hay dùng lại các request đã đóng.

BASIC cần đối chiếu pet/target mới, số Kiếm hiệu dụng trong vùng quét và
thời điểm input/ACK/terminal bằng collector hiện có. Đây là cohort mới ngoài
Shield đã nghiệm thu; không đo lại chỉ vì đổi nhãn phiên bản. Không gọi một
trận thắng là chứng minh mọi damage/refill hoặc mọi counterfactual.

Phần REASONING kiểm cùng BASIC incumbent, deadline/fallback, cơ chế dùng Máu
để quét và đánh giá sau phản hồi boss khi model tính được. Không bắt buộc chọn
nước khác BASIC. Skill/QTE không thuộc trường hợp passive này; không sửa flow
hoặc đọc thêm memory/ảnh để phục vụ planner.

## Chuẩn bị đã có

- `tools/prepare_common_control.py prepare` tạo draft đầy đủ cấu hình, source
  fingerprint và cap; chỉ đọc preferences đang lưu, không ghi đè chúng.
- Draft local cuối: `artifacts/common_reasoning_20261101/sagui_health_basic_draft_verified.json`.
- Chỉ sau khi user chốt phòng/pet/cap mới dùng `activate` để tạo request BASIC
  với hash build/host/source/expiry hiện tại. Gate `BasicCalibrationActivation`
  hiện có kiểm request và chỉ claim khi người dùng nhấn Bắt đầu trong tool.
- UI test dùng preferences riêng cho session, không tự Start, không tự bật R.
  Draft không phải acceptance, không cấp quyền native cho common planner.

Trạng thái: **WAITING_FOR_OPERATOR_COHORT_AND_LIVE_PREPARATION**.
Chưa mở game/tool, chưa tạo request/claim, chưa phát input; live mới **0**.
