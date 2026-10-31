# BASIC SWAP timing — runbook có giới hạn, chưa kích hoạt

Ngày 2026-10-12. **SOFTWARE PREPARED / NATIVE CLOCK UNKNOWN / NOT ACTIVATED.**
P3 không chạy game. Chỉ dùng sau clock procedure xác nhận phép đo có ích và có
kích hoạt live riêng. Đây không phải quyền dùng REASONING hoặc chạy D1 pilot.

Freeze một account, boss, pet/loadout, source, GameAssembly, launcher, cấu hình
và input cohort. SOLO, BASIC Simple hoặc Careful, shadow OFF, foreground,
two_click. Giữ config và pacing/random của BASIC. Account/pet label do operator
cung cấp; runtime witness là bằng chứng cấu trúc, chưa là pet/effect authority.
Không suy native efficacy hoặc damage model từ tên cohort.

Giới hạn mặc định **3 TOTAL attempts**, hard max5 chỉ nếu request ghi5 trước
batch. Không bù lượt lỗi/thua/abort. Một Start; không Resume/restart cùng
request, kể cả Stop sớm. Source request hết hạn tối đa2giờ; không persist opt-in
hoặc ghi đè preferences thường. Không dùng package v1.2.5 cho hook source này.

Khi được kích hoạt riêng, chuẩn bị config preferences bản riêng và game path
đã chọn đúng; chưa chạy các lệnh này trong P3:

```powershell
$env:PYTHONPATH='src;tests'
$py='C:\Users\Admin\AppData\Local\Programs\Python\Python311\python.exe'
& $py tools/basic_calibration.py create --preferences '<CONFIG_COPY.json>' --game '<EXACT_GAME_EXE>' --boss-id '<VERIFIED_ID>' --boss-name '<EXACT_NAME>' --cohort '<ACCOUNT/BOSS/PET/LOADOUT>' --profile simple --cap 3 --out '<V2_LOGS_REQUEST.json>'
```

Creator hash current src/tools/tests và read-only GameAssembly/launcher; không
nhận caller tự nhập build/source SHA. Request SHA in ra phải pin khi mở source
UI. Chọn executable đã bind trong Settings, giữ cùng boss/config; click Start
thủ công qua đường đang có. Không auto Start hoặc extra read/capture/input:

```powershell
& $py tools/desktop_ui.py --basic-calibration-request '<V2_LOGS_REQUEST.json>' --basic-calibration-sha256 '<PRINTED_SHA>' --artifacts '<NEW_UI_ARTIFACT_DIR>'
```

Claim lưu theo run ID tại `logs/basic_calibration_claims`, nên copy/đổi tên file
request cũng không reset cap. Không xóa claim để chạy bù.
Request thiếu/sai: không tạo timing worker, vẫn BASIC và ghi CALIBRATION_REJECTED.
Không bấm Start để đo khi thấy rejection; một phiên đã claim bị chặn Start/Resume
lại, tránh reset cap. Mọi settings write của explicit session đi vào scratch
preferences trong artifact. Claim lỗi setup vẫn tiêu thụ request; không tự retry.

Stop ngay khi wrong turn/stale/duplicate/after-Stop input; flow/read/capture khác;
cohort drift; essential telemetry loss; hoặc cap/window đã đủ. Expiry kiểm ở setup
và Start, **không thêm timer interrupt làm thay đổi trận đang chạy**. Operator
phải Stop nếu hết cửa sổ giữa trận; attempt cap vẫn do FarmRun cũ thực thi.

Sau run và khi writer đã đóng, file-only export:

```powershell
& $py tools/basic_calibration.py export --request '<REQUEST.json>' --request-sha256 '<SHA>' --timing-directory '<UI_ARTIFACT_DIR>\basic_calibration' --farm-directory '<EXACT_FARM_RUN_DIR>' --out '<NEW_EXPORT.json>'
```

`session.json` bind calibration ID với FarmRun ID/path/config/cap. `watermarks.json`
ghi flush/cleanup/accounting qua một finalizer có giới hạn ngoài caller Stop;
thiếu receipt, dropped/failed/discarded hoặc thiếu timing cho SWAP_SENT đều là
evidence chưa đủ. Chờ finalizer đóng trước export, không flush/join trong action.
Giữ nguyên
run.json/events/combat/AI JSONL, hash mỗi input. Timing bắt đầu trước final read
đã có; read_end, validation_end, executor_return là host monotonic. End là upper
bound sau click2, không exact click timestamp; ACK ở ngoài execution duration.
Hook bắt đầu trước final read của controller, trước khi gọi `send_swap`; interval
bao gồm reaction random và inter-click random/pacing BASIC hiện có trong executor.
Join full AutonomousSource với action_sent và SWAP_ACKNOWLEDGED; thiếu/ambiguous
không nhận mẫu, không ghép chỉ bằng turn hoặc tên boss. Stop/exception/1click/
preflight rejection vẫn giữ raw, không tạo completed duration.

Export giữ **tất cả attempts**, kể cả LOSS/UNKNOWN, local-turn cost và status.
Local turns chỉ là tool energy proxy, không là account energy delta. Thiếu final
ledger/partial run ghi lỗi; không chế tạo cost hoặc acceptance. N/p50/p95/p99/max
là nearest-rank empirical/descriptive; N nhỏ không bảo đảm population p99.
R candidate = max(accepted floor,1000ms,descriptive p99+250ms), chỉ để review;
không tự promote. U luôn UNKNOWN trong export. Không tạo authority tự động,
không dùng synthetic U150/R2000, không tăng attempts để tìm kết quả đạt.
