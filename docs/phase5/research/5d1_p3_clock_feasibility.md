# P3 — Clock feasibility trên read contract hiện có

**P4 erratum 2026-10-12:** bảng offset/body Cpp2IL bên dưới là historical
pre-b6. Current b6 đã được kiểm trực tiếp, raw `+0x190`, anchors
`+0x1C8/+0x1CC`; provider dùng đúng b6. Native U vẫn UNKNOWN. Xem
[P4 report](../reports/5d1_p4_report.md) cho current binding và next P5;
không dùng bản P3 này để suy RVA/field current build.

Ngày 2026-10-12. **U UNKNOWN; không có native calibration/activation.**
Đọc trực tiếp reverse và provider, không attach game. Đây là kết luận về nguồn
đang được tool đọc, không phải phép đo độ trễ của mạng hoặc Unity.

| Nguồn | Điều xác minh được | Điều chưa xác minh |
|---|---|---|
| `MatchService.txt:4290` getter / `:4300` setter | `TurnTimeRemainingSec` là field Int32 `+0x118` | Không có guarantee cập nhật mỗi frame |
| `:15695` HandleMatchTimerTick | Đọc payload remaining với fallback field cũ, rồi ApplyTimingFields | Tick cadence, tuổi message, upper bound khi tick bị trễ/mất |
| `:5160`, ISIL :5306–:5359 ApplyTimingFields | `turnRemainingMs` không âm mới cập nhật anchor float, `HasServerClock`; anchor Unity unscaledTime; field integer lấy phép chia ms/1000 | Không tự bound transport age hoặc quan hệ clock host/Unity |
| `:4940` ServerTurnRemainingSec | Anchor trừ elapsed Unity khi không pause/FX hold; clamp vào duration | Provider hiện không gọi getter và không đọc current Unity clock |
| `UnityEngine.CoreModule/UnityEngine/Time.txt`, get_unscaledTime | Wrapper resolve rồi gọi native icall qua cache function pointer | Cache là địa chỉ **hàm**, không phải địa chỉ biến time để đọc |
| `memory_board_provider.py:_read_turn_timer`, `idle_state_watch.py:read_match_runtime` | Tool đọc raw integer field trong các lần read đã có | Không có bound anchor age; clock pause/FX semantics chưa gắn vào observation |

Không tìm được trong các body đã xem một finite upper bound cho tuổi tick.
Điều này **không khẳng định mọi game code đều đã được duyệt**. Nhưng đủ để bác
bỏ suy luận “integer seconds nên U tối đa 1 giây”: quantization chỉ là một
thành phần; raw value có thể giữ nguyên khi message không cập nhật. Double-read
cùng field chỉ chứng minh ổn định tại thời điểm đọc, không chứng minh mới.

`get_ServerTurnRemainingSec` mô tả countdown của client; ngay cả tái dựng được
getter cũng chưa tự chứng minh server nhận action trước deadline. Còn phải tách
anchor age, transport age, alignment host/Unity, read span và quantization.
Không lấy startup host của tool làm mốc Unity và không gọi native getter trong
process game. Các static disassembly addresses không là runtime pointers.

Loader hiện bắt buộc báo cáo clock được pin riêng, có phép cộng năm upper
bounds hữu hạn và file/line/hash evidence. Đây là **kiểm tra cấu trúc và binding
của một proof đã review**, không phải chương trình tự chứng minh số đo vật lý.
Fixture ghi rõ SYNTHETIC chỉ kiểm schema. Hiện không có proof native được review.

Đúng một procedure cần tiếp theo: [P4 clock evidence](../prompts/5D1_P4_CLOCK_AGE_EVIDENCE.md).
Trước khi procedure đó tìm được nguồn khả thi, **không yêu cầu chơi 3–5 trận để
điền U**. BASIC timing chỉ đo execution interval R và không chữa được clock age.

Evidence file SHA được ghi trong `artifacts/5d1_activation_readiness_v1/clock_sources.json`.
