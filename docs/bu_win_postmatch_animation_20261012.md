# Bú win dừng 1/13: kết trận đến trước phần hiển thị của client

## Kết luận từ lần test

Run `810139fceb784f94b033aa37c2e26714`, match `M_956cc760`, ngày 12/10/2026,
Bú win/Coop trong phòng người khác. Hai nước của tài khoản đều SENT/ACK;
sau khi HP local về 0, tool vẫn chờ đồng đội đúng. Lỗi xảy ra ở bước xác
nhận kết quả, chưa phát input Đồng ý.

Thời gian dưới đây theo giờ Việt Nam:

| Mốc | Bằng chứng |
|---|---|
| 23:15:02.663 | Provider chuyển POSTMATCH, `local_match_end_flag`, terminal event MATCH_GAME_OVER, winner `__PLAYERS__` |
| 23:15:03.749–03.752 | Bàn giao sang FarmRun/chờ UI; đã đếm 1/13 |
| Frame đầu | Client còn hiển thị thông báo kỹ năng Galaxy Ricky của đồng đội; chưa có bảng kết quả |
| 23:15:34.117 | SAFE_STOP POSTMATCH_UI_AMBIGUOUS, sau 30.203s và 55 mẫu ảnh |
| Frame cuối | Banner Thắng và hộp quà, chưa có nút Đồng ý; labelPixels=0, mức yêu cầu 206 |

Hai ảnh gốc tại
`logs/farm_runs/810139fceb784f94b033aa37c2e26714/matches/attempt_001/`
là `postmatch_wait_frame_first.png` và `postmatch_wait_frame_last.png`.
JSON `postmatch_failure.json` giữ các lý do nhận diện. Replay hai ảnh qua
locator hiện tại tiếp tục từ chối đúng, không cấp điểm click giả từ nền xanh.

**Nguyên nhân đã xác định:** giới hạn 30s của tool bắt đầu từ trạng thái kết
trận, trùng với khoảng client còn phát hiệu ứng chiến đấu đã nhận. Đến lúc
bảng Thắng/hộp quà xuất hiện, budget xác nhận của tool đã cạn. Không có
bằng chứng hộp quà tự chạy chậm 30s. Không có ảnh sau timeout nên thời điểm
Đồng ý thực sự xuất hiện trong lần này vẫn UNKNOWN.

Người dùng cho biết người kéo dùng x4. Log không xuất tốc độ trận, vì vậy
chưa xác nhận riêng x4 gây ra độ trễ; hiện tượng terminal đến trước phần
hiển thị đã được xác nhận độc lập với giả thuyết đó.

## Kiểm chứng reverse hiện tại

Đọc file GameAssembly b6 và declarations tương ứng; không attach game.
`HandleMatchGameOver` đặt `_matchOver = true` tại RVA `0x4247F4`, trước
kiểm tra `IsPresentationBusy` tại `0x4248EE`. Khi bận, nó giữ deferred
winner và hoãn result event qua `FlushGameOverWhenPresentationDone`.
Coroutine có giới hạn `GameOverRenderWaitMaxSec=30f`, tích lũy bằng
`Time.unscaledDeltaTime`. Đây là thời gian thực không tự rút xuống còn
7.5s chỉ vì người kéo dùng x4.

`Board` tách ShowGameResultIntegrated, DisplayCoopReward và ShowBtnGetWithAnim.
GetRewardRevealTotalSeconds trả `0.35 + (itemCount-1)*0.12` khi có item;
điều này phù hợp nhận xét animation mở quà ngắn. Nó không chứng minh được
giới hạn của cả pipeline nhận thưởng. Chi tiết field/RVA đã ghi vào
`docs/il2cpp_symbols.md`; dữ liệu byte/constants ở artifact.

Provider hiện coi một trong các cờ board_game_over/match_over/deferred_game_over
là terminal khi vẫn còn local rig. Giữ ranh giới này để ngừng đi nước ngay
khi đã kết trận. Chuyển ngược ACTIVE để đợi animation sẽ cấp sai quyền gameplay.

## Sửa trong phạm vi Bú win

Chỉ thay adapter chờ postmatch trong `tools/farm_run.py`:

- Bú win/Coop có thêm allowance hiển thị 30s một lần ngoài UI budget hiện tại.
  Mặc định tổng giới hạn 60s; UI budget custom 3–60s vẫn giữ validation cũ.
  Allowance là lựa chọn vận hành dựa trên render wait của game, không phải
  lời khẳng định mọi trường hợp game sẽ hiện nút trước 60s.
- Khi vượt UI budget ban đầu, đọc lại provider một lần: vẫn phải POSTMATCH
  và session không thay đổi nếu ban đầu có session. Đổi ownership/UNKNOWN
  thì dừng có bằng chứng, không dùng allowance để cấp quyền click.
- Nút đã hiện thì dùng cửa sổ chứng minh ổn định, tối đa UI budget kể từ
  lần đầu thấy nút và luôn bị chặn bởi deadline tuyệt đối ban đầu.
  Nhấp nháy/mất nút/ảnh thay đổi không reset thời gian. Xong sớm thì click sớm.
- Vẫn cần ba frame đúng label/vị trí, final provider/fresh frame trong pinned
  lease, đúng cửa sổ foreground và normal input. Stop vẫn được kiểm mỗi vòng.
- Không đổi policy chừa kiếm/chờ chết, entry/sẵn sàng, gameplay memory/capture
  sequence, luật kết trận, thứ tự input hoặc đường về lobby. Solo dùng timeout cũ.

Log `postmatch_confirm_wait` ghi STARTED, PRESENTATION_GRACE khi thật sự cần,
CONFIRM_VISIBLE và CONFIRM_STABLE hoặc FAILED/OWNERSHIP_CHANGED; giữ stage
PRESENTATION_PENDING, RESULT_REVEAL_PENDING hay STABILIZING_CONFIRM, elapsed
và deadline. Không log từng frame. Khi lỗi, metadata có waitContext và vẫn
lưu tối đa hai frame gốc dù diagnostic images OFF. Nhánh bình thường không
thêm encode/ghi PNG khi setting này OFF.

## Kiểm chứng và trạng thái giao bản

132 kiểm tra tập trung PASS: Bú win, FarmRun và result locator. Có 11 ca hồi
quy mới cho pending skill quá 30s rồi quà/nút hiện, tiếp tục 1/13 qua đúng
lobby, healthy poll/click counts, cap tuyệt đối, nút nhấp nháy, nút hiện sát
deadline, capture chậm, Stop, game đóng, ownership/session đổi, timeout Solo
và source binding tiếp tục từ chối sửa FarmRun chưa được kiểm chứng.
Lượt đầu có một assertion test kỳ vọng ENTRY_READY ngay sau lobby, trong khi
flow hiện tại đi qua RESOLVE_TARGET; sửa test để kiểm cả hai bước đúng flow.
Không đổi runtime navigation để chiều assertion. Log lượt đầu được giữ riêng.

Lượt full đầu chạy 2081 tests trong 253.381s: 2078 PASS, 3 FAIL đều tại
so sánh hash FarmRun với snapshot D1-P3. Đây là guard phát hiện thay đổi nguồn,
không phải ba lỗi hành vi. Giữ nguyên mọi manifest P3/P4. Thêm binding riêng
`after_runtime_manifest.json` trong artifact nhánh phụ, pin chính xác một file
runtime mới và kiểm bản trước vẫn khớp P3. Fixture kiểm tương thích bổ sung
chuỗi này, không bỏ kiểm tra cả file hoặc cho phép hash bất kỳ. Có test tiêm
thay đổi nguồn để xác nhận guard vẫn fail. 27 kiểm tra source binding/Bú win
PASS sau cập nhật. Toàn bộ diff của fixture và bản trước/sau được lưu riêng.

Full regression cuối **2082/2082 PASS** trong **250.860s**, log tại
[full_suite.txt](artifacts/bu_win_postmatch_animation_20261012/full_suite.txt).
Audit cuối **18/18 PASS** tại
[verification.json](artifacts/bu_win_postmatch_animation_20261012/verification.json):
275 source files giữ nguyên inventory, chỉ một runtime file và hai test files
thay đổi; toàn bộ AST ngoài các hàm postmatch/help/logging được giữ nguyên.
Trong `_run_live`, delta duy nhất là thêm callback ghi log cho lời gọi
`_confirm_postmatch`. GameAssembly, reverse, STATUS Phase 5 và log/ảnh gốc
giữ nguyên hash. `before/`, `after/`, `changes.patch`, source/runtime manifests
và artifact manifest giữ bản kiểm chứng độc lập cho lần sửa này.
Source version giữ v1.2.5, chưa build EXE/ZIP và chưa chạy farm/live test.
Đóng/mở lại UI chạy source trước lần test Bú win kế tiếp. Kết quả offline
không thay thế xác nhận live đã qua được nhiều trận.

Main Phase 5 không chuyển step hay bật reasoning vì bản sửa nhánh phụ này.
Snapshot P3/P4 vẫn là lịch sử đúng nguồn cũ; không tái sử dụng acceptance
275-file source fingerprint cũ để tuyên bố adapter mới đã được Phase 5 nghiệm thu.
