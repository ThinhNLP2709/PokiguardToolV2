# P7 — Observer đã sửa, runbook cho future P8

2026-10-14. **PREPARED_NOT_ACTIVATED.** [Report](../reports/5d1_p7_report.md).
P7 chỉ offline; lệnh native dưới đây chưa chạy. P6 window lỗi giữ nguyên, không
resume. P8 là một window mới với source sửa và review riêng, chưa được kích hoạt.

## Review đóng băng

- Review: `artifacts/5d1_observer_sentinel_diagnostics_v1/prepared/review.json`.
- SHA256: `29729cde74c90a260b379dc1fcdc45d2af8138282942b944f1b1c59a2c7da515`.
- Source279 fingerprint:
  `b7fbeba620868937c309d0edf2097dbe75037423ccca78bd25ef927a6c42203a`.
- Observation schema `5d1.p7.passive_clock.v2`; field diagnostics
  `5d1.p7.clock_fields.v1`; supplementary inventory ở
  `artifacts/5d1_observer_sentinel_diagnostics_v1/diagnostics_contract.json`.
- Exact b6 game hashes/host clock, limits/read/OS/output inventory trong review.
  P5/P6 manifests là historical và không được gán lại cho source mới.

Read contract/caps/Stop/cleanup giữ như [P5 runbook](5d1_p5_passive_observer_runbook.md):
30RPM/1336B +12VQ/sample, clock2RPM/96B; ≤600samples/≤10Hz, một60s admission
window, span50ms, no catch-up/retry/resume. Root/string/lifetime/setup/final/file
IO inventory vẫn đầy đủ; không gọi96B là tổng chi phí.8MiB exclusive post-collection
export, no disk during reads. OS call/file IO không có preemption/hard latency bound.

FX=-1 ghi RESET_SENTINEL; FX active/current Unity/server tick age vẫn UNKNOWN.
Error diagnosis chỉ năm fields cũ, finite value hoặc null/classification/bits.
Không thêm block/raw padding, pointers, reason/event strings hay account data.
Partial/Stop không decode prefix; mismatch giữ source A/B/phase để kiểm tra.

## Chuẩn bị future window

User kích hoạt P8 và dừng auto/farm. Người dùng tự mở game/room và bắt đầu tối
đa1trận chơi tay. PID phải hiện hành, không dùng PID25808 lịch sử. Do người dùng
đã nhờ lấy PID, có thể lấy một query Win32_Process của đúng tên/path khi đã
chuẩn bị; nếu không unique đúng install thì dừng, không đoán hoặc đổi target.
Không computer-use click/capture. Chỉ chạy sau khi người dùng báo bàn cờ đã hiện.

Mục tiêu vẫn phân biệt raw/anchor/paused/FX/read span. Không cần cố tạo tình
huống hoặc thêm trận. Source/build/clock mismatch thì giữ lỗi để review; không
re-prepare ngầm. Output dưới đây phải chưa tồn tại, không xóa để retry.

## Lệnh reviewable, chưa chạy

PID được xác nhận trước rồi gán `$observerGamePid`; native command nhận explicit
PID. Trong PowerShell, sau activation/preparation P8:

```powershell
& 'C:\Users\Admin\AppData\Local\Programs\Python\Python311\python.exe' `
  'D:\PokiguardToolV2\tools\passive_clock_observer.py' `
  --native --activate-passive-window --pid $observerGamePid `
  --review-manifest 'D:\PokiguardToolV2\docs\phase5\artifacts\5d1_observer_sentinel_diagnostics_v1\prepared\review.json' `
  --review-sha256 '29729cde74c90a260b379dc1fcdc45d2af8138282942b944f1b1c59a2c7da515' `
  --out 'D:\PokiguardToolV2\docs\phase5\artifacts\5d1_corrected_passive_observation_v1'
```

Ctrl+C tại terminal đặt Stop, không gửi input vào game. Stop/drift/error/cap
kết thúc ngay khi API trả lại; không tự repeat. Đóng handle rồi export. Giữ
partial/failed output/stdout receipt; FILE_WRITTEN không là PASS hoặc durable.

## Return gate

Phân tích mọi attempt/field diagnosis/paired A/B/inventory/loss/cleanup/source
và final binding. Valid local sample vẫn không là finite U, tick receipt, atomic
snapshot hoặc proof transport alignment. FX reset sentinel không là freshness.
Kết quả LOCAL_OBSERVATION_ONLY/INCONCLUSIVE, U/transport/alignment null và input
authority false. Không tạo AI activation, native R calibration hoặc reasoning
input. Sau P8 chọn đúng một bước theo evidence rồi STOP; không kéo dài để tìm PASS.
