# Bú win Coop — dừng 1/6 tại bước xác nhận kết quả

Ngày 2026-10-11, Asia/Saigon. Chỉ rà log và source; không sửa runtime, không
attach/read game, chụp màn hình mới, phát input, chạy farm, build hoặc đổi version.
Đây là nhánh phụ Bú win; không chuyển milestone hoặc sửa tài liệu acceptance Phase 5.

## Kết luận có bằng chứng

Run `bec10a25fbb84b5a9ed76c5b96fd85a9`, boss Rivan `2534`, phòng khách
`Coop_805615`, match `M_ab1ff7b3`, Bú win + Coop, BASIC, AI OFF.
FarmRunner dừng với **POSTMATCH_UI_AMBIGUOUS** sau khi bộ nhận diện kết quả
không tạo được proof ổn định trong 30 giây/59 samples. Tổng postmatch input = 0;
không có permit hoặc click Đồng ý được phát.

[Farm events](../logs/farm_runs/bec10a25fbb84b5a9ed76c5b96fd85a9/events.jsonl:21),
[run summary](../logs/farm_runs/bec10a25fbb84b5a9ed76c5b96fd85a9/run.json),
[combat log](../logs/farm_runs/bec10a25fbb84b5a9ed76c5b96fd85a9/matches/attempt_001/combat.jsonl:456).

| Giờ Việt Nam | Bằng chứng |
|---|---|
| 13:36:38 | Bắt đầu mục tiêu 6 trận; đúng Rivan, guest room |
| 13:37:08 | Entry accepted, một lobby input; combat handoff hợp lệ |
| 13:37:30 / 13:37:58 | Hai SWAP Bú win được ACK đúng identity |
| 13:41:08 | Nhận `MATCH_GAME_OVER`, winner `__PLAYERS__`, lifecycle POSTMATCH |
| 13:41:09 | Combat controller bàn giao bình thường; `acceptedNormalEnd=true`; checkpoint tăng completed lên 1 |
| 13:41:09–13:41:39 | FarmRunner tìm proof màn kết quả trong 30 giây, 59 samples |
| 13:41:39 | SAFE_STOP: `POSTMATCH_UI_AMBIGUOUS`; không click Đồng ý |

Detail nguyên văn ở farm event 12:

```text
postmatch modal not stable within 30.0s; samples=59;
last=expected_exactly_one_large_blue_result_panel
```

Combat log có `postmatch_observation_timeout` 1 giây: đây là điểm combat
controller trả quyền cho FarmRunner xử lý UI. Summary được FarmRunner chấp nhận
là normal end. Lần SAFE_STOP toàn run nằm sau cửa sổ xác nhận 30 giây.
`completed_matches=1` được tính lúc terminal accounting, trước xác nhận UI;
`target_completed_matches=6`. Do đó 1/6 vẫn có thể hiện dù chưa nhận quà/về phòng.

Không có yêu cầu F6/F9, unexpected exception hoặc provider read error trong
run summary. UI log tiếp tục quan sát POSTMATCH sau khi controller dừng.
Khoảng 13:42 có room/ReadyWait rồi match mới; không có autonomous input mới
của run đã dừng. Log không xác định ai thao tác sau SAFE_STOP.

## Giới hạn: chưa chốt được điều kiện pixel gây hụt

[_confirm_postmatch](../tools/farm_run.py:1026) dùng locator rồi yêu cầu ba frame
ổn định trước khi reserve input. [Locator](../src/pokiguard_v2/postmatch_ui.py:202)
thử layout wide 1.7.4 (banner cam + nút xanh + nhãn gần trắng), sau đó thử layout
cũ (panel xanh lớn + nút cam). Nhánh wide trả `None` khi bất kỳ gate nào không đạt;
reason cuối trong log thuộc nhánh fallback. Vì vậy thông báo panel xanh lớn
không chứng minh giao diện thật phải có panel xanh hoặc chỉ màu panel bị sai.

Run không có PNG postmatch và không lưu metrics từng sample. [Desktop launcher](../tools/desktop_ui.py:169)
mặc định giữ ảnh trong RAM, chỉ lưu PNG khi source run bật
`--save-diagnostic-images`; [ordinary PNG writer](../src/pokiguard_v2/win32_screenshot.py:107)
bỏ ghi khi policy tắt. Không thể replay đúng 59 captures đã mất.

Người dùng phản hồi không nhớ rõ thời điểm nút xuất hiện, có cảm giác tool dừng
ngay khi kết ván. Phản hồi này không đủ phân biệt nút đã hiện nhưng detector hụt,
reward/UI hiện sau timeout, hay capture/layout khác mẫu. Timestamp xác nhận
FarmRunner thực sự chờ 30 giây sau accounting.

Đã chốt điểm gây dừng và nhánh code. Exact visual root cause vẫn UNKNOWN;
không nới detector, tăng timeout hoặc click tọa độ cố định dựa trên suy đoán.
Trước khi sửa cần ảnh kết quả của đúng tình huống và replay detector trên ảnh đó,
kèm các controls không có nút/đang animation/nhiều nút. Có thể dùng source
diagnostic opt-in sẵn có cho một lần test có giới hạn; chưa chạy trong lần rà này.

## Kết quả đội còn UNKNOWN — vấn đề riêng

Terminal payload winner là `__PLAYERS__`, HP local 0; boss HP lưu lại 11.062.475
thuộc snapshot cuối của local actor. [result_from_winner](../src/pokiguard_v2/terminal_result.py:25)
hiện nhận local username hoặc `BOSS`/`__BOSS__`, nên giá trị này giữ UNKNOWN.
Coop không dùng local chết làm thua. Không dùng HP boss cũ để bác kết quả đội.
Run ghi `unknown_results=1`, wins/losses đều 0.

UNKNOWN không phải điều kiện gây SAFE_STOP này: `_confirm_postmatch` cho phép
UI result chưa biết nếu visual/lifecycle proof hợp lệ. Lần này thất bại trước
reserve input. Muốn bổ sung mapping winner đội phải kiểm chứng semantics/scope
riêng, không tự suy WIN từ tên sentinel trong báo cáo này.

## Source và handoff

Bốn file liên quan (FarmRunner, locator, screenshot persistence, terminal
classifier) hiện byte-identical với source manifest C3 V3. Log launcher xác nhận
chạy source, `frozen=false`, data root `D:\PokiguardToolV2`.
[Evidence/hash](bu_win_postmatch_review_20261011_evidence.json).
Không chạy tests vì chưa đổi code; chỉ đọc và đối chiếu log/source.
Phase 5 tiếp tục giữ đúng milestone trước đó; remediation Bú win chưa triển khai.
