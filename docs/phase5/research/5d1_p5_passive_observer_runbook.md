# P5 — Runbook observer clock riêng

2026-10-13. **PREPARED / NOT ACTIVATED.** Không chạy các lệnh native bên dưới
trong P5. [Report](../reports/5d1_p5_report.md),
[review cuối](../artifacts/5d1_passive_clock_preparation_v1/prepared_final/review.json).

## Mục đích và giới hạn

Quan sát một cửa sổ chơi tay, tối đa một trận, để phân biệt:

1. Raw timer giữ nguyên trong khi anchor đổi, hoặc cả hai đổi cùng lúc.
2. Anchor đổi khi paused/FX field cũng đổi. Không gán thay đổi cho server tick;
   chưa có current Unity clock để xác định FX hold đang active.
3. Read span, lỗi/partial read, identity drift và mức đầy đủ của ledger.

Mọi kết quả chỉ LOCAL_OBSERVATION_ONLY hoặc INCONCLUSIVE. `native_U_ms`,
transport age và host/Unity alignment vẫn null. Không dùng max/p99 quan sát
làm upper bound của tick tương lai. Không tạo activation artifact cho AI.

## Source/build/read contract đóng băng

- Source279 fingerprint:
  `16374f8c05c7f1f47c318dfc9b884928e1b0a8dff440bc7f8f5bb0f0d3688149`.
- Review SHA256:
  `f54ec2f1d868316f9850df062dbe92472ef7c6f53fc2e637698773da210e2465`.
- Exact source files, bốn game files b6, host clock, limits và read allowlist
  nằm trong review. GameAssembly SHA `72d10a43…ec063`; phiên bản app v1.2.5.
- Chỉ mở PID người dùng chỉ định, quyền `0x410 = QUERY_INFORMATION | VM_READ`.
  PID + creation FILETIME từ cùng handle + module/install path được pin.
  Không tìm process theo tên, không đổi target, không retry snapshot.
- Mỗi identity dùng resolver singleton hiện có: type-info slot, static-fields
  và instance (3×8B); hai string pointers, header/class/data string cap128;
  turn/duration/raw timer. Match/player xuất SHA256, không xuất chuỗi gốc.
- Hai identity và hai clock blocks `MatchService+0x1BC`, mỗi block48B. Chỉ decode
  bool+0x1BC/+0x1BD, float32+0x1C8/+0x1CC/+0x1E8. Không decode/dereference/export
  padding, reason string hoặc event pointer nằm trong block.
- Mỗi mẫu tối đa30RPM/1336B và12VirtualQueryEx. Clock incremental2RPM/96B;
  phần identity/root là28RPM/1240B. 600 mẫu tối đa18000RPM/801600B, trong đó
  clock57600B/1200RPM; tối đa7200queries. Không có ACK/ChatService/board scans.
- Setup/final mỗi lần một module snapshot, tối đa512entry; 1CreateSnapshot,
  1ModuleFirst, ≤512ModuleNext, 1CloseHandle/pass. Process handle mở/đóng một lần;
  architecture helper ≤2OS calls. GetProcessTimes/GetExitCodeProcess mỗi loại
  tối đa1203calls: setup1 + collector pin1 +2/sample +final1.
- Native VQ chỉ chấp nhận một region chứa toàn span; không quét sang region khác.
  Source/game file hash IO trước/sau collection được ghi riêng, không tính vào
  96B hoặc RPM. File hash + module path không chứng minh toàn mapped image.

## Điều kiện trước future window

P6 phải được người dùng kích hoạt riêng. Đóng tool auto/farm trước; giữ game để
người dùng chơi tay. Chưa mở R calibration hoặc reasoning pilot. PID lấy thủ
công từ Task Manager của đúng PetPuzzle-1.7.4, không dùng PID từ run cũ.

Review phải còn khớp source/build/clock. Không re-prepare một manifest mới để
lách mismatch; quay lại review nếu source/game thay đổi. Thư mục output phải
chưa tồn tại. Một lần chạy, không resume, không lặp để tìm PASS hoặc đủ mẫu.

Người dùng tự vào trận đã chuẩn bị, bắt đầu observer khi match đang tồn tại,
chơi tay tối đa một trận. Observer không mở phòng, click, chụp ảnh hoặc farm.
Không cần cố tạo FX/pause hoặc tiêu thêm trận nếu tình huống không xuất hiện.

## Lệnh đã chuẩn bị — chưa chạy

Chỉ dùng sau activation P6. Trong PowerShell trên máy source hiện tại:

```powershell
$observerGamePid = [int](Read-Host 'PID PetPuzzle-1.7.4 tu Task Manager')
& 'C:\Users\Admin\AppData\Local\Programs\Python\Python311\python.exe' `
  'D:\PokiguardToolV2\tools\passive_clock_observer.py' `
  --native --activate-passive-window --pid $observerGamePid `
  --review-manifest 'D:\PokiguardToolV2\docs\phase5\artifacts\5d1_passive_clock_preparation_v1\prepared_final\review.json' `
  --review-sha256 'f54ec2f1d868316f9850df062dbe92472ef7c6f53fc2e637698773da210e2465' `
  --out 'D:\PokiguardToolV2\docs\phase5\artifacts\5d1_passive_clock_observation_v1'
```

Flag activation chỉ dành cho diagnostic read-only này, không bật REASONING.
PID người dùng nhập là giá trị runtime, không có absolute address hard-code.

## Stop và return gate

≤10Hz, tối đa600samples, admission window60s; không catch-up sau sample chậm.
Mỗi sample có read-span threshold50ms; đây là operational rejection threshold,
không là bound tuổi tick. Ctrl+C tại terminal đặt Stop; kiểm trước/sau mỗi RPM,
query và giữa các đoạn chờ tối đa20ms. Không có hotkey/input gửi vào game.

OS call đang chạy không preempt được: một RPM/API bị stall có thể trả sau
deadline/Stop. Tool từ chối sample và không phát thêm read khi call trả lại.
Không tuyên bố hard wall-clock return ≤60s hay native Stop latency đã đo.
Đóng handle trước khi export; file IO sau collection có thể bị stall riêng.

A/B mismatch (kể cả padding), nonfinite/invalid bool, missing anchor, read error,
process/source/match drift hoặc span cap kết thúc ngay, không retry sample.
Turn/player/raw timer thay giữa A/B làm sample invalid; thay giữa các sample
được ghi rõ trong cùng match. A/B bằng không chứng minh atomicity, ABA hay freshness.
Final module/source check thất bại hoặc bị Stop thì INCONCLUSIVE, giữ ledger.

Output `observation.json` exclusive, ≤8MiB, tối đa600record buffered. Có mọi
attempt kể cả partial/error, RPM/query inventory, bracket, source/clock binding,
counter/status loss và export receipt. Không ghi disk trong collection. Lỗi
setup giữ `failure.json` nếu đã claim thư mục; disk/export lỗi vẫn có stdout
status. FILE_WRITTEN không đồng nghĩa durable/fsync. Không xóa output để chạy lại.

P6 đọc đủ mọi sample/counter, kiểm hash/receipt và các hypothesis trên. Thiếu
useful samples hoặc transport proof thì INCONCLUSIVE/UNKNOWN; không tự thêm
window, trận, field, native Unity chain hoặc kích hoạt input. Giữ BASIC và UI gate.
