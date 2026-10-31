# 5D.1-P6 — Một cửa sổ native passive observation

2026-10-14 (Asia/Saigon). **INCONCLUSIVE / OBSERVER VALIDATION GAP / PARTIAL D1.**
Parent [P5](5d1_p5_report.md). Đã chạy đúng một lần, không repeat hoặc thêm trận.
Source/gameplay giữ nguyên; native_U_ms vẫn null, input_authority false.

## Thực thi và kết quả

Người dùng yêu cầu tiếp tục, mở đúng PetPuzzle ở D:\pc và nhờ lấy PID. Một query
Win32_Process theo tên exe tìm PID25808, path chính xác D:\pc\PetPuzzle-1.7.4.exe.
Người dùng xác nhận auto/farm đã dừng, ở boss room; sau đó tự bấm Bắt đầu và báo
“Đã vào trận, bàn cờ đã hiện”. Observer mới được chạy với explicit PID và final
review SHA của P5. Không điều khiển UI, screenshot hoặc phát input game.

Binding/source279/build/clock đã qua preflight; native command verify lại trước
attach và final source/module/process-lifetime check PASS. Command exit0 có
nghĩa export thành công, **không phải clock observation PASS**.

| Chỉ số toàn bộ window | Kết quả |
|---|---|
| Attempts / valid / invalid / dropped | 1 / 0 / 1 / 0 |
| Lý do dừng | INVALID_CLOCK_FLOAT |
| Read span mẫu / collection span | 3.4238ms / 3.5638ms |
| RPM / requested / returned | 15 / 204B / 204B, mọi read đủ byte |
| Identity A | 14RPM/156B, turn3/duration14/raw timer14 |
| Clock A | 1RPM/48B, đọc thành công nhưng decode bị từ chối |
| Identity B / clock B | Chưa đọc; dừng ngay sau lỗi A |
| VQ | 6, mọi kiểm tra readability OK |
| OpenProcess / module snapshots / CloseHandle | 1 / 2 / 3, đã cleanup |
| GetProcessTimes / GetExitCodeProcess | 4 / 4 |
| ModuleFirst / ModuleNext | 2 / 216 tổng hai pass |
| Export | FILE_WRITTEN, 4129/4129B, không claim durable/fsync |

Ledger complete với tất cả attempts, không mất record. Không vượt cap, retry,
catch-up, hoặc tự chạy window thứ hai. 3.4ms chỉ là bracket của một sample lỗi,
không là native latency bound, distribution, timer age hoặc reserve calibration.

Các hypothesis raw-vs-anchor, paused/FX và tick update đều **NOT_OBSERVED**:
không có valid clock sample, không có paired A/B. Parser không export field/value
khi float bị từ chối, do đó exact failing field/value trong sample là UNKNOWN.
Không còn raw block để offline replay chính sample này.

## Thiếu sót observer đã chứng minh bằng file

Đối chiếu lại bytes của đúng GameAssembly b6 SHA `72d10a43…ec063`:

- ClearLocalFxHold RVA0x417A40 lưu bits `0xBF800000` vào +0x1E8.
- ApplyTimingFields RVA0x417D51 cũng lưu giá trị đó ở nhánh not-paused.
- Bits này là float32 **-1.0**, một giá trị reset FX hold hợp lệ do game ghi.

P5 decoder đang buộc cả remain/anchor/FX không âm. Nó loại cả sentinel -1 hợp lệ;
đây là thiếu sót của utility chuẩn bị ở P5, không phải bằng chứng gameplay lỗi.
Một counterexample synthetic dùng chính sentinel verified và các field khác
synthetic cho kết quả INVALID_CLOCK_FLOAT. Label/provenance giữ rõ trong artifact.

**Không khẳng định -1 gây lỗi ở native sample vừa thu:** mẫu không giữ giá trị
từng field. Sentinel là defect độc lập đã prove và là candidate explanation,
không phải causal fact của window. Không đọc lại process để điền evidence thiếu,
không nới mọi giá trị âm hoặc đổi deadline gate để cho PASS.

Verified finding đã ghi `docs/il2cpp_symbols.md`, `docs/board_resolution.md`.
Không sửa parser trong milestone observation này; bước sửa phải offline riêng.

## Evidence, binding và preservation

Native output `artifacts/5d1_passive_clock_observation_v1/observation.json`.
`execution_receipt.json` giữ user-operated scope/command/export; `analysis.json`
tổng hợp mọi sample/counter; `fx_sentinel_file_evidence.json` giữ exact bytes/RVA/
file offsets; `sentinel_counterexample.json` là synthetic, không replay native.
Preflight/operator setup ở `artifacts/5d1_passive_clock_p6_preflight_20261014_v1/`.

Source279 fingerprint vẫn
`16374f8c05c7f1f47c318dfc9b884928e1b0a8dff440bc7f8f5bb0f0d3688149`;
review SHA `f54ec2f1d868316f9850df062dbe92472ef7c6f53fc2e637698773da210e2465`.
HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, appv1.2.5/package unchanged.
GameAssembly runtime base/PID/lifetime chỉ là snapshot trong ledger, không
hard-code vào reader. File hash/module path không prove toàn mapped image/ABA.

Không sửa Python sources, game files hoặc preferences; historical P5 artifact
files và P3/P4 evidence giữ nguyên. P5 root status/router/capability trước khi
advance đã archive ở preflight before_docs, giữ chain cho các external-doc hashes.
Không chạy lại full suite/soak; không build/version/Git mutation. Source/runtime
hash-preservation và export/inventory checks ở `verification_final.json`.

## Return gate

P6 đã kết thúc với INCONCLUSIVE. Transport age, host/Unity alignment, finite
native U, native R/cohort và D1 acceptance vẫn thiếu. BASIC/shadowOFF/UI gate
giữ nguyên. Người dùng không cần thêm trận hoặc giữ game mở cho bước sửa offline.

Exactly one next:
**[5D.1-P7 — offline FX sentinel/parser diagnostics correction](../prompts/5D1_P7_OBSERVER_SENTINEL_AND_DIAGNOSTICS_OFFLINE.md)**,
SELECTED ONLY / NOT EXECUTED. Chưa kích hoạt window mới, R calibration hoặc D1/D2.
**STOP P6.**
