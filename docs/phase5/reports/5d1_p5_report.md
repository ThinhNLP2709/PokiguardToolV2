# 5D.1-P5 — Passive clock observer chuẩn bị offline

2026-10-13. **PASS STRONG trong phạm vi software offline / PARTIAL D1.**
Observer và runbook đã sẵn sàng để review; native observation **NOT ACTIVATED**.
Parent [P4](5d1_p4_report.md), [runbook](../research/5d1_p5_passive_observer_runbook.md).

## Kết quả

Thêm một utility standalone, không tích hợp vào farm/provider/controller:

- `src/pokiguard_v2/passive_clock_observer.py`: decode năm field b6; immutable
  binding; identity/read ledger; cap/rate/Stop; export chỉ sau collection.
- `tools/passive_clock_observer.py`: offline prepare và future explicit-PID
  adapter có activation riêng, đúng read/query rights, bounded module walk,
  lifetime/module/source/build/clock binding; không native-auto-run.
- `tests/test_passive_clock_observer.py`: **39 tests PASS**, 0.656s lượt cuối.

Đã thực sự chạy duy nhất `--prepare`: hash local source/game files và tạo
review; không enumerate/attach game, đọc process thật, chụp ảnh hay phát input.
Các đường native trong tests/qualification dùng fake cho TẤT CẢ OS APIs,
RPM, VQ, module snapshot và process lifetime; không suy thành native acceptance.

## Reader và chi phí

Không reuse nguyên `read_match_runtime`: hàm đó còn đọc ACK và ChatService,
vượt projection cần thiết. Reuse resolver singleton, verified offsets và
string/int/pointer decoders; không rewrite provider. Không reuse attach_target
hoặc enumerate_modules vì discovery/module loop không có cap phù hợp observer.
Adapter riêng nhận explicit PID, module walk≤512entry/snapshot, một lần,
không retries. VQ một region, có typed HANDLE cleanup cho x64.

Năm clock fields vẫn đúng evidence P4; hai raw blocks48B chỉ decode allowlist.
Identity gồm PID/creation FILETIME từ cùng handle, module, MatchService pointer,
match/player hash, turn/duration/raw timer, source/build digest. Strings có
header20B và **một class-validation read8B mỗi string**, đã tính vào inventory.

| Phần | Max RPM/mẫu | Max byte/mẫu |
|---|---:|---:|
| Hai root/identity projections | 28 | 1240 |
| Clock A/B | 2 | 96 |
| Tổng | 30 | 1336 |

600samples:18000RPM/801600B, trong đó clock1200RPM/57600B; ≤7200VQ.
Setup/final/lifetime/architecture APIs và local file hash IO được inventory
riêng trong review/runbook; không quảng cáo96B là toàn chi phí.

≤10Hz, no catch-up, một admission window60s/600samples, operational span50ms,
chờ Stop từng lát≤20ms. Không có guarantee preempt OS call hoặc hard native
wall-clock duration. File IO chỉ sau collection, export≤8MiB/exclusive; loss,
partial/error/failed setup có status, không claim durable logging.

## Kiểm chứng

39 focused cases kiểm exact offsets/types/float32 ULP, A/B/padding mismatch,
missing anchor, paused/FX ambiguity, nonfinite, source/build/PID/lifetime/module/
match/turn/player/raw-timer drift, partial read/query failure, read/span/window/
rate/log caps, Stop ở sáu RPM boundaries và trước setup, no catch-up, log loss,
exclusive/partial/disk export, native gating và full CLI qua fake native APIs.
Final binding/handle cleanup, wrong install, snapshot failure/no retry,
oversized module inventory, modified manifest và no resume đều được kiểm.

Qualification giữ một ledger **600 mẫu synthetic worst-case**, đủ18000RPM và
801600B, no loss; pause/FX fixture và full CLI/adapter trace có nhãn fakes rõ.
`qualification.json` đạt mọi gate software công bố. Các lượt test21/30/37/39
trước đó và review v1 vẫn giữ; final review đã regenerate sau bổ sung typed
CloseHandle ABI, không ghi đè snapshot cũ. Fixture core giữ nguyên byte qua
điều chỉnh ABI của adapter; final adapter trace đã chạy lại bằng fakes.

Không chạy lại full gameplay suite/30min soak: utility độc lập và **276/276
Python sources tại entry giữ nguyên byte**, chỉ thêm ba file, tổng279. Không
dùng historical2088 full tests của nhánh phụ để certify utility mới.

## Binding và bảo toàn

HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, source appv1.2.5/package unchanged.
Source279 fingerprint:
`16374f8c05c7f1f47c318dfc9b884928e1b0a8dff440bc7f8f5bb0f0d3688149`.
Final review SHA:
`f54ec2f1d868316f9850df062dbe92472ef7c6f53fc2e637698773da210e2465`.

Entry source đã có các side corrections Bú win tới13/10; P4 source275 và các
acceptance cũ vẫn là historical snapshots, không rebind. 465parent P3/P4 files,
hai side-fix artifact manifests, AGENTS, bốn game files và ordinary preferences
được hash-preserved. Exact inventories/verification trong
`artifacts/5d1_passive_clock_preparation_v1/`.

## Giới hạn và bước kế

`native_U_ms:null`, transport_age và host/Unity alignment UNKNOWN; A/B equal
không là atomic/freshness proof, anchor đổi có thể do FX. Không đọc unverified
Unity native candidate, SpeedGuard/RTT/payload hoặc thêm reader vào flow BASIC.
Observation chỉ LOCAL_OBSERVATION_ONLY/INCONCLUSIVE, không cấp activation AI.
Native module/file checks cũng không loại ABA hoặc chứng minh toàn mapped image.

Native observations0, tool input0, farm attempts0, no build/version/Git mutation.
BASIC/shadowOFF và UI REASONING gate giữ nguyên. **Chưa cần mở game trong P5.**

Exactly one next:
**[5D.1-P6 — bounded passive observation](../prompts/5D1_P6_BOUNDED_PASSIVE_CLOCK_OBSERVATION.md)**,
SELECTED ONLY / NOT EXECUTED / NOT ACTIVATED. Cửa sổ riêng phải được người dùng
kích hoạt và chuẩn bị PID/trận chơi tay; chưa native R calibration/D1/D2.
**STOP P5.**
