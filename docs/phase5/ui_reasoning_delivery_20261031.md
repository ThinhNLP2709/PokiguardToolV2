# Bật/tắt suy luận trong UI — phạm vi người dùng đã chọn

31/10/2026, sau closeout F2. Người dùng chọn: “Hoàn thiện bật/tắt suy luận
trong UI, trước mắt chỉ Demon Farm ăn Khiên đã nghiệm thu (đề xuất)”.
Đây là công việc tiếp theo có yêu cầu riêng, không mở lại cap/batch F1/E2,
không sinh chuỗi P và không tự release/version/model.

**01/11/2026 — CLOSED PASS SCOPED UI.** Đã hoàn tất offline và đúng2lượt thử
mới do user tự Start:1BASIC+1UI-R,2WIN/confirm/về phòng. Suy luận thực sự
completed6lượt và giữ BASIC ở cả6,31AIrecords/0loss,1workerreaped.
Task bật/tắt UI đã hoàn thành trong scope đã pin, không còn live bắt buộc.
[Closure và raw refs](artifacts/ui_reasoning_delivery_20261031/live_closure.json).
Giữ v1.2.10, chưa phát hành. Các mục chuẩn bị/pending bên dưới là lịch sử
thực hiện; kết quả cuối ở mục cuối tài liệu.

## Hướng triển khai đã xác định

- Dùng một AI intent `reasoning_enabled` trong AISettings/preferences, mặc định
  false. GameplayConfig/Intelligence.BASIC của engine vẫn giữ nguyên; không mở
  placeholder Intelligence.REASONING trực tiếp hoặc sửa solver/FarmRunner.
- UI radio suy luận ghi/lấy intent thật; chỉ bật lựa chọn cho cấu hình
  DemonShield/Solo/normal/none/passive/4effectiveSword/foreground/two_click đã
  có evidence. Cấu hình khác hoặc thiếu/mismatch profile dùng BASIC và báo lý do.
- Đường normal Start tạo session R từ local reviewed acceptance profile ở
  writable dataRoot, không từ consumed/expired F1 operational request. Native
  calibration/witness/stats/source/build/host binding vẫn bắt buộc; closedF1
  chỉ là provenance, không reset claims hoặc đổi source label cho raw logs.
- Profile hiện vẫn current account/Lieyun77/Shield4/floor2. Không mở arbitrary
  account/boss/targets, R2, model, skill/PASS/Coop/Dinosaur. Runtime witness guard
  dùng state đã có; không thêm đọc memory/capture để xác nhận.
- Reuse exact OperationalPilotAuthority, PilotSelectionBridge,
  SwapTimingCollector và preflight hiện có. Không đổi planner/model/executor.
- Session UI giữ tối đa1bridge/worker hiện tại, dùng bounded shared diagnostic
  sink cho cả run, background reaping/flush và bounded history. Không giữ mảng
  toàn bộ bridges/sinks như pilot cap2/20 khi user farm200+matches.
- Publish actual R status/counters lên AIStatus; lỗi setup/log/worker/timing chỉ
  tắt R và tiếp tục BASIC hợp lệ. BASIC/shadowOFF không tạo R resources.
- Stop chỉ signal; no join/flush trên controller/action thread; cleanup thuộc
  background owner, successor chưa sạch thì BASIC cho combat tiếp, không chờ.

## Kết quả offline cuối — mốc trước live

UI đã lưu/nạp intent bật/tắt riêng; chỉ cho chọn R khi cấu hình phù hợp.
Đường Start thông thường dùng profile ngoài EXE, không cần cờ lab/pilot.
Không đủ điều kiện thì chạy đúng BASIC FarmRunner và hiện lý do trên AI.
R có thể giữ nước BASIC; không bắt buộc override. Cấu hình đang chạy khóa như cũ.

| Kiểm chứng | Kết quả và evidence |
|---|---|
| UI/prefs/default, cấu hình không hỗ trợ, profile mất/sai/tamper, game/host/core mismatch | 22 test mới PASS, [log cuối](artifacts/ui_reasoning_delivery_20261031/final_ui_tests.log) |
| 200 trận mô phỏng | Tối đa1bridge hoạt động, giữ32receipt cuối,200worker giả được thu hồi; không giữ mảng toàn bộ workers |
| 2 trận mô phỏng với worker/collector/writer thật | 2completed,2workers reaped,0wrongProducer/0loss; mã correlation riêng `<UIrun>:<combatIndex>` |
| BASIC khi AI tắt/lỗi và Stop | Cùng arguments FarmRunner với BASIC; không chờ join/flush trong Stop; lỗi hiển thị không dừng farm |
| Hồi quy rộng |269tests;8failure/error events thuộc4test IDs đã có trong F1,0new failure IDs. Không tuyên bố toàn bộ suite xanh. [Đối chiếu](artifacts/ui_reasoning_delivery_20261031/regression_audit.json) |
| Selector trên source cuối |100cycles ×6nhánh PASS, max7.3658ms; real worker roundtrip/writer0loss. [Qualification](artifacts/ui_reasoning_delivery_20261031/selector_allowance.json) |
| Bản EXE cuối |134modules+entry khớp source optimize1, đủ3UI modules, ZIP không chứa profile private. [Package audit](artifacts/ui_reasoning_delivery_20261031/package_audit.json) |
| Probe trong EXE cuối |Warm jobs, crash/corrupt/hang fallback, Stop/reap, writer failure/rotation/queue PASS, không attach/capture/input game. [Probe](artifacts/ui_reasoning_delivery_20261031/final_probe_data/logs/startup/packaged_reasoning_self_check.json) |
| Profile cho bản EXE cuối |Native F1/E2 gốc vẫn kiểm lại, current gameb12/host/source/package khớp; reserve5914.1519ms + return margin100ms, budget≤4000ms. [Review](artifacts/ui_reasoning_delivery_20261031/live_final_data/preferences/reasoning_acceptance/offline_review.json) |

Chỉ5file Python cũ thay đổi: settings, UI, control plane, controller setup và
decoder calibration. Decoder chỉ cho phép thiếu field `reasoning_enabled`
khi giá trị mặc định false trong hồ sơ cũ; giữ nguyên dữ liệu gốc, canonical
validation khác, source/build/host/cohort và các claim. Solver/planner/reader/
capture/input/QTE/ACK/recovery và controller gameplay không đổi byte so với F1.
[Source review](artifacts/ui_reasoning_delivery_20261031/source_review.json)
kiểm đủ các file cũ và9rollbackZIPs vẫn nguyên.

Source cuối375Pythonfiles:
`4d07f02ed2f1817c1d87557f6ea837caea19dcce6a4e4a81f554f7b7089c2a49`.
EXE `2969293466f5e8b8f0dcca593cdc837ae694633dcfddcf97fb635fecd3243f51`.
ZIP thử `fcf29a1ab2c0b32e4398307e92e12879d5ac559325125ede4fbfef006a9d3c26`,
ở `build/ui-reasoning-20261031-final/`; giữ v1.2.10, chưa phát hành.
Hai candidate trước ở thư mục riêng chỉ là evidence phát triển, không dùng
profile/source của chúng để bật bản cuối.

Đây vẫn là operational projection dựa trên mẫu native, không phải chứng minh
bound cho server age/U hoặc mọi pause/scheduling. NativeU/actualenergy vẫn
UNKNOWN, efficacy không đổi từ INCONCLUSIVE. Chưa mở tài khoản/đồ/boss khác,
các target gem khác, HT7/Mega/Coop/DinosaurR, skill/PASS/R2/model mới.

## Bước còn lại cần người dùng chuẩn bị game

Đã chốt tối đa **2 lượt thử mới**:1BASIC (R tắt), sau đó1R bật/lưu bằng UI,
Solo/Lieyun77/Demon Aegis thường ăn Khiên/4Kiếm hiệu dụng và giữ nguyên đồ.
Mỗi lần Start target=attemptCap=1; user tự bấm Start, không tự mở trận/game.
Ban đầu chưa chạy trận nào; hiện cả2 đã hoàn tất ở cập nhật bên dưới, cap đã hết.
Cap/claim F1/E2 đã hết không được dùng lại.

Cần kiểm đường normal UI mới thực sự Start→combat→confirm→boss lobby, BASIC
off không có workerR, UI-on có completed selection hoặc lý do fallback rõ,
logs0loss/workerreaped và lưu lựa chọn qua phiên. Completed retention là PASS
đường thực thi, không cần ép override. Nếu scope không khớp phải báo BASIC,
không giả kết quả R hoặc tự nới calibration.

[Chuẩn bị](artifacts/ui_reasoning_delivery_20261031/live_preparation.json):
`live_final_data/` chứa profile riêng và preferences BASIC/OFF, budget4000,
target1/attempt1, đúng đường game. User đã xác nhận sẵn sàng và cap mới2lượt;
đã mở normal UI bản cuối (PID15804), gamePID21964. Tại mốc mở:0attempts.
Snapshot lúc mở nhận game nhưng `LOBBY_OTHER`, không room/boss; chờ user vào lại
phòng trước Start. [Room precheck](artifacts/ui_reasoning_delivery_20261031/room_precheck.json),
[xác nhận/mở phiên](artifacts/ui_reasoning_delivery_20261031/live_authorization.json).
Không thêm auto-start/auto-resume; chưa phát input game tại mốc mở phiên.

### Live UI — BASIC đầu tiên đã hoàn tất

User báo “đã xong”. [Review BASIC1](artifacts/ui_reasoning_delivery_20261031/basic1_review.json):
farm`66ec3c16d55545f49dabc253a03c597f`,1attempt/1WIN,1localturn,
1SWAP/0ACK/1strong terminal exclusion (boss chết, pending đã hủy theo lifecycle).
Đã confirm thưởng và về BOSS_LOBBY, Stop đúng FARM_TARGET_COMPLETED;
0read/safety/timeout/technical abort/recovery. BASIC/OFF không tạo thư mục logR.
Stats hiện tại `[109491,2771,250,1819]` khớp calibration. Còn đúng1lượt thử R;
giữ nguyên tool/phòng/đồ, user bật và lưu bằng tabAI trước Start tiếp theo.

### Live UI — REASONING hoàn tất và đóng task 01/11/2026

User đã chọn/lưu `reasoning_enabled=true`, shadowfalse, budget4000 bằng UI,
rồi tự Start generation2 trong cùng tool. Preferences đã đọc lại thành công;
UI đã hiển thị trạng thái R có quyền chọn. Không dùng hidden pilot flags hay
request/claim F1/E2. Farm`5d90cbb418224e0085f45953ab393371`,
match`M_855cc9a7`:1attempt/1WIN,6localturns/5bossturns,
6SWAP=5ACK+1strongterminal exclusion,1confirm/return, Stop đúng mục tiêu.

| Kiểm chứng live cuối | Kết quả |
|---|---|
| R thực sự tính và chọn |6unique jobs COMPLETED;18ROOT/FRESH/FINAL đều VALID_COMPLETED_R1_RETENTION;0override là hợp lệ, không phải lỗi/timeout fallback |
| Nước thực gửi |6timing/source identity khớp6native action_sent;5ACK và1lifecycle end có strong WIN/pending cleared |
| Thời gian tính |31.1661–72.2189ms; cả6COMPLETED trước deadline, không worker late/fault |
| Log/cleanup |31/31records durable,0loss/queued/wrongproducer;1process/1reaped, bridge/writer closed/healthy |
| An toàn/flow |0read/input-safety/action-timeout/technicalabort/recovery/PASS; có nhận thưởng và về BOSS_LOBBY |
| Component guard |3controller-tail soft flags, cao nhất158.3072ms so với limit134.7600ms; debit tối đa23.5472ms trong sharedguard250ms, còn226.4528ms;0guard exhaustion/aggregate reserve overrun/component fault |
| Postmatch observer |Mỗi trận có1event `postmatch_observation_timeout` của cửa sổ quan sát1s sau lifecycle end; cả2có strong terminal trước cleanup và FarmRunner đã confirm/return, không phải action-response timeout hoặc dừng farm |
| Cap |2/2consumed,2WIN;0remaining, không tự thêm trận |

[Live closure](artifacts/ui_reasoning_delivery_20261031/live_closure.json) có
SHA các raw run/checkpoint/combat/AI logs, bản chụp UI events và preferences
tại closeout. Các file source375/EXE/ZIP vẫn đúng hash đã kiểm,9rollbackZIPs
vẫn nguyên; không sửa runtime sau live hoặc gán kết quả này sang ZIP F1 cũ.

Task UI hoàn tất. BASIC vẫn là default cho preferences mới/cũ thiếu intent;
lựa chọn user đã lưu được nhớ lại. Profile thiếu/sai hoặc lỗi AI giữ BASIC
hợp lệ. Chưa phát hành hay mở rộng cohort/lối chơi; chưa chứng minh R hiệu quả
hơn BASIC. Hai trận có bàn cờ khác nhau nên không suy luận từ1turn BASIC so với
6turn R về chất lượng hoặc năng lượng. NativeU/actualenergy vẫn UNKNOWN.

Baseline source trước đổi:
`f0aeab76e40ffc12fa11692702119d181bc8e869ae44033f7624ec80d1a8018b`.
Backups/evidence tại `artifacts/ui_reasoning_delivery_20261031/`.
