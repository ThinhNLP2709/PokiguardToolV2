# Bú win — dừng ở đầu trận và ảnh chẩn đoán cuối trận

Ngày 2026-10-11, Asia/Saigon. Người dùng yêu cầu kiểm tra lần dừng mới nhất,
sửa lỗi và bật lưu ảnh đúng điểm lỗi. Đây là nhánh phụ Bú win; không thực hiện
5C.4, không bật reasoning selection, không chạy game/input live hoặc build.

## Nguyên nhân đã xác định

Run `6f6dfb8fa9dc43788a301c3ef9e2c0d5`, 13:54:38–13:54:53:

- Bú win / Coop, phòng khách `Coop_805615`, boss Rivan 2534.
- Tool nhấn Sẵn sàng đúng một lần; chủ phòng bắt đầu match `M_ed25a555`.
- Provider công bố MATCH_START nguyên vẹn, ổn định hai mẫu, 64 ô đủ tọa độ,
  gem/multiplier hợp lệ, cùng session/match, localMoveSequence=0.
- Server turn=1 thuộc đồng đội; `isLocalTurn=false`, `isFirstLocalTurn=false`.
- `tools/boss_entry.py` yêu cầu `is_first_local_turn is True` cho mọi opening.
  Vì vậy dừng `OPENING_ACCEPTANCE_INVARIANT_FAILED` trước khi bàn giao combat.
  Không có `combat.jsonl`, gameplayInputs=0, completedMatches=0.

Nguồn: [entry log](../logs/farm_runs/6f6dfb8fa9dc43788a301c3ef9e2c0d5/matches/attempt_001/entry/entry.jsonl),
[entry summary](../logs/farm_runs/6f6dfb8fa9dc43788a301c3ef9e2c0d5/matches/attempt_001/entry/entry.json).
Fixture hồi quy giữ nguyên 64 ô và các trường battle; chỉ ẩn tên tài khoản,
kèm SHA-256 của log gốc tại
`tests/fixtures/bu_win_coop_foreign_opening_20261011.json`.

Đây là lỗi khác với lần 13:41:39 ở run
`bec10a25fbb84b5a9ed76c5b96fd85a9`: lần đó đã đi hai nước, chờ đồng đội sau
khi chết, rồi dừng vì không chứng minh được bảng thưởng trong 30 giây / 59 mẫu.
Log cũ không lưu PNG nên hình dạng giao diện và thời điểm nút Đồng ý xuất hiện
vẫn UNKNOWN. Xem [báo cáo lần trước](bu_win_postmatch_review_20261011.md).

## Sửa trong phạm vi có bằng chứng

Opening Coop có thể bàn giao sang bộ quan sát combat khi turn 1 thuộc actor
khác, chỉ với MATCH_START mới, đủ nguồn/64 ô/hash/session/sequence/stability như
cũ. `firstLocalTurn`, `isLocalTurn` và `turnNumber` truyền đúng giá trị quan sát;
không giả lập lượt của mình. Timer của actor khác không cấp quyền đi nước.

FarmRun chỉ nhận nhánh này ở cấu hình Coop hợp lệ (hiện chỉ Bú win), không
áp dụng cho Solo, recovered opening hoặc test-only recovery. BASIC và
ActionabilityGate giữ nguyên: chưa đúng lượt, board chưa MOVE hoặc client
không cho đi thì không phát gameplay. Khi có fresh local turn, dùng đường
đi nước sẵn có. Không đổi solver, normal input, ACK/QTE, thứ tự đọc memory
hay capture trong đường chạy bình thường.

## Ảnh và lý do phân biệt lỗi

Không bật lại việc ghi PNG thường xuyên. Ảnh lỗi được ghi cả khi setting
diagnostic images đang OFF, dùng writer riêng cho bằng chứng ngoại lệ:

- Opening invariant thất bại: tối đa một ảnh
  `matches/attempt_NNN/entry/opening_invariant_failure.png`, chỉ khi cửa sổ
  đúng binding đang foreground; trạng thái memory vẫn nằm trong entry log.
- Chờ bảng thưởng hết hạn hoặc fresh preflight từ chối nút:
  `matches/attempt_NNN/postmatch_wait_frame_first.png`,
  `postmatch_wait_frame_last.png` và `postmatch_failure.json`.
- Hai ảnh postmatch dùng lại pixel đã capture, không thêm provider poll,
  capture hay input. JSON giữ tối đa ba kết quả locator gần nhất, kích thước,
  transform, banner/button candidate counts và bước thiếu label/anchor.
- Lỗi ghi ảnh/JSON được ghi rõ và không thay nguyên nhân dừng ban đầu.
  Ảnh chỉ được encode/ghi ở nhánh lỗi; giữ thêm một frame đầu trong RAM
  trong thời gian chờ postmatch. Không thêm ghi đĩa ở nhánh bình thường khi
  diagnostic images OFF.

Locator giữ nguyên mọi ngưỡng, ROI, label proof và điều kiện click. Có thêm
`wideReason` để lỗi nhận diện layout rộng không bị che bởi reason của layout
legacy. Chưa đủ bằng chứng để thay tọa độ, nới nhận diện hoặc tăng timeout
cho lần dừng cuối trận cũ.

Gốc thư mục: `D:\PokiguardToolV2\logs\farm_runs\<run_id>\`.

## Kiểm chứng và ranh giới nghiệm thu

35 kiểm tra tập trung ban đầu PASS; 200 kiểm tra mở rộng PASS (105.265s),
gồm entry, FarmCycle/FarmRun và parity/fault/Stop của reasoning. Bổ sung một
test fresh preflight thất bại PASS. Full regression **1979/1979 PASS** trong
195.454s, gồm 13 ca hồi quy mới. Kết quả tại
[full_suite.txt](artifacts/bu_win_runtime_fix_20261011/full_suite.txt).
Lượt full đầu có một import error vì lệnh chạy thiếu `tests` trong PYTHONPATH
(`test_action_control` dùng import bare `test_actionability`). Log 1974 tests /
1 import error được giữ ở `full_suite_import_failure.txt`; chạy lại cùng source
với `PYTHONPATH=src;tests`, không sửa test/runtime để né lỗi import. Lệnh PASS:

```powershell
$env:PYTHONPATH='src;tests'
$env:PYTHONIOENCODING='utf-8'
python -m unittest discover -s tests -t . -q
```

Các ca mới kiểm tra dữ liệu lỗi thực, Solo không nhận opening của actor khác,
Coop không đi trước lượt, lượt local mới vẫn có SWAP, các nguồn/session/ô/
stability thiếu đều bị từ chối; ảnh first/last đúng pixel ngay cả khi PNG
thường OFF; không thêm input/poll ở timeout; lỗi lưu trữ không che nguyên
nhân; fresh preflight thất bại lưu đúng frame bị từ chối.

Trước/sau của sáu runtime files và source audit được lưu tại
[artifacts](artifacts/bu_win_runtime_fix_20261011/). Source audit pin SHA-256
trước/sau chính xác cho sáu runtime files; các nguồn C3 còn lại vẫn đối chiếu
baseline và remediation AI cũ. Không bỏ qua toàn bộ file khi kiểm tra.

**Evidence 5C.3 V3 vẫn thuộc snapshot cũ**, không tự áp 142 gates/latency/soak
cũ lên source vừa sửa. Bản sửa này có regression riêng; live opening và
postmatch cần test lại. Con trỏ Phase 5 vẫn 5C.4 OFFLINE ONLY, chưa thực hiện.

UI lần lỗi đang chạy source (`frozen=false`, installRoot/dataRoot là workspace).
Đóng rồi mở lại UI trước khi test để load code mới. Có thể test Bú win 2 trận
trong phòng người khác: chờ chủ phòng bắt đầu, chờ tới lượt mình, chết thì
chờ đồng đội, xác nhận thưởng và về đúng phòng để tiếp tục. Nếu dừng, giữ
nguyên run folder mới để đối chiếu entry/postmatch bằng các file trên.
Source version vẫn v1.2.5; package EXE/ZIP chưa build lại.
