# 5D.1-P8 — Corrected passive observation, một trận chơi tay

2026-10-14 (Asia/Saigon). **LOCAL_OBSERVATION_ONLY / PARTIAL D1.**
Parent [P7](5d1_p7_report.md). Đã đóng đúng một native window; không repeat.
Observer đã đọc được các field hợp lệ trên game thật. Chưa có bằng chứng về
tuổi dữ liệu server, native R/cohort hoặc điều kiện bật REASONING input.

## Thực thi

Người dùng kích hoạt: “chạy đi, tôi đang ở phòng boss chưa bắt đầu, chúng ta
đánh 1 trận”. Một query Win32_Process theo đúng tên trả về duy nhất PID **3572**,
path `D:\pc\PetPuzzle-1.7.4.exe`, creation local
`2026-10-14T02:51:35.120033+07:00`. Không tái dùng PID25808 của P6.
Người dùng xác nhận tool đã tắt, tự Bắt đầu và báo “Đã vào trận, bàn cờ đã hiện”.
Sau đó mới chạy CLI với explicit PID và review P7 đã đóng băng.

Preflight file-only kiểm đúng source279, game b6, host clock và output chưa
tồn tại. Native command tự kiểm lại binding trước attach và sau collection.
Không sửa source, chuẩn bị lại review, điều khiển game, chụp ảnh hoặc chạy farm.
User chơi tay tối đa một trận; window không chứng minh kết quả/kết thúc trận.

| Toàn bộ window | Kết quả |
|---|---|
| Attempts / valid / invalid / dropped | **551 / 551 / 0 / 0** |
| Verdict / stop reason | LOCAL_OBSERVATION_ONLY / WINDOW_CAP |
| Collection span / command wall | 60.0087815s / 60.7235578s |
| Sample read span min / median / max | 1.8562 / 2.3614 / 5.0874ms |
| Khoảng từ cuối sample đến đầu sample kế, min / median / max | 102.2023 / 106.51825 / 109.9452ms |
| RPM / requested / returned | 16,530 / 220,200B / 220,200B |
| Clock subset trong tổng trên | 1,102RPM / 52,896B |
| VirtualQueryEx | 6,612, tất cả OK |
| OpenProcess / module snapshots / CloseHandle | 1 / 2 / 3 |
| GetProcessTimes / GetExitCodeProcess | 1,105 / 1,105 |
| ModuleFirst / ModuleNext | 2 / 216 tổng hai pass |
| Export | FILE_WRITTEN, 3,001,738/3,001,738B; durable=false |
| Final process-lifetime/module/source/build binding | Checked=true |

Đã kiểm **mọi row**, không chỉ sample đầu/cuối: index0–550 liên tục; counters
khớp reads/bytes; mọi read đủ byte; mỗi sample30RPM/12VQ, bytes dưới cap1336B;
identity A/B và clock A/B bằng nhau, không failure diagnostics hoặc drift.
Toàn bộ samples bắt đầu/kết thúc trước admission deadline60s, sample cuối kết
thúc ở59.932086s. Collector trở lại vòng kiểm window sau deadline khoảng8.8ms;
đây không phải hard wall-clock guarantee của OS. Command wall còn gồm setup,
hashing, final checks và export. Không gọi max5.0874ms là future latency bound.

551 là số samples thực thu trong window có khoảng chờ sau mỗi sample,
không phải600samples rồi mất49. Ledger đầy đủ, không catch-up/retry/resume.
Ba CloseHandle tương ứng process handle và hai module snapshots; final binding
và inventory cho thấy cleanup hoàn thành trong lần chạy này.

## Kết quả về đồng hồ

Một match/root được giữ suốt window, hai current-player hashes, turn5–14,
duration14s. Không đọc player ownership nên không gán hash nào là người/boss.

| Quan sát local | Kết quả |
|---|---|
| HasServerClock | true trong551samples |
| ClockPaused | true390 / false161samples |
| FX reset sentinel -1 | 434samples |
| FX không âm | 117samples, active vẫn UNKNOWN |
| Anchor changes / raw integer changes | 71 / 28 |
| Anchor đổi, cùng turn/player/raw/local remain | 43 lần;36lần chỉ anchor đổi |
| Raw integer range | 11–14s |
| Raw = floor(local remain-at-anchor) | Đúng551/551samples của window này |

P7 đã xử lý được **FX=-1 trên native data**, đồng thời thu được trạng thái FX
không âm và paused/unpaused. Không có invalid clock field nên diagnostics lỗi
vẫn chỉ qualified offline. Kết quả không giải mã ngược giá trị lỗi P6; actual
failing field/value của P6 tiếp tục UNKNOWN và output P6 giữ nguyên.

Các ví dụ có index và host bracket trong `clock_changes.json`:

- Row0→1: anchor369.456604→370.457184 trong khoảng hai sample cách nhau khoảng
  108ms, còn raw14/remain14/paused=true/FX=-1 không đổi. Không thể coi anchor
  là current Unity time của mỗi lần đọc hoặc suy host/Unity epoch từ nó.
- Row261→262: cùng turn9/raw12/remain12.2849998; FX đổi -1→401.9193115,
  anchor đổi398.4689026→398.9193115, paused vẫn true. Đây là một local
  transition phù hợp với cơ chế FX/reanchor đã reverse, chưa chứng minh causal
  event hoặc server tick. Không có current Unity clock để quyết định hold-active.
- Row294→295: raw12→11, paused true→false, FX về -1; local remain đổi
  12.2849998→11.3310003. Việc pause/FX và integer timer có thể giữ/đổi khác nhau
  cần được giữ trong semantics, không thay bằng một countdown liên tục tự đoán.

Host brackets chỉ giới hạn thời điểm tool quan sát local values giữa các
sample. Chúng không là server emission/receipt brackets. 43 lần anchor đổi khi
cùng lượt/raw/remain và source evidence P4 bác cách dùng “anchor vừa đổi” làm
chứng nhận tick mới. Không xác định được cause của từng transition chỉ từ năm
field. Raw=floor(remain) trong window phù hợp với phần integer conversion đã
reverse; không phải một invariant cho mọi future state hoặc bound tuổi raw.

## Binding và preservation

Source279 fingerprint:
`b7fbeba620868937c309d0edf2097dbe75037423ccca78bd25ef927a6c42203a`.
Review SHA:
`29729cde74c90a260b379dc1fcdc45d2af8138282942b944f1b1c59a2c7da515`.
Observation SHA:
`263ff27395426680780aed8d5f8d9a1210dcae2fc000d593ec9fc621e7fa48be`.
HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, appv1.2.5/package unchanged.

Artifacts: `artifacts/5d1_corrected_passive_observation_v1/`; preparation và
raw command receipt ở `artifacts/5d1_corrected_passive_p8_preflight_20261014_v1/`.
`analysis.json` giữ all-row checks/counters; `clock_changes.json` giữ mọi71
local transitions. Native observation.json không bị rewrite. Before docs được
archive để giữ chain của historical external-doc hashes.

Final file checks bảo toàn279Python sources,530parent artifact files, bốn game
files, AGENTS, symbol/board docs và HEAD. Không thêm source, chạy lại gameplay
suite/soak, build/version/Git mutation. Zero game input/capture/network; không
thêm native read sau window để bổ sung evidence.

Preferences có hash drift sau collection: trước `7eab8b19…fb0`, sau
`f7d04afc…3d0c`; saved_at/mtime20:02:42UTC, sau khi native command kết thúc
19:58:46UTC. Không claim file này byte-preserved. Preflight chỉ giữ hash nên
exact config diff UNKNOWN; không so payload với một snapshot lịch sử khác rồi
gán đó là config trước P8. Observer không đọc hoặc ghi preferences; agent không
ghi file này và không hoàn nguyên cài đặt người vận hành. Writer thực tế
UNKNOWN. Snapshot/metadata ở `preferences_after_snapshot.json` và
`preferences_observation.json`; drift này không làm đổi pin source/game/review
hoặc native data đã thu. Các giờ UTC chỉ để đối chiếu metadata, user date vẫn
2026-10-14 theo Asia/Saigon.

## Return gate và đúng một next

`native_U_ms:null`, transport age và host/Unity alignment UNKNOWN;
`input_authority:false`, production activation=false. A/B equality không là
atomicity/freshness proof. Native R/cohort chưa đo; D1/D2/promotion chưa đạt.
Production BASIC, shadowOFF và UI gate giữ nguyên. Không cần thêm trận cho P8.

P8 đã trả lời mục tiêu local observation. Thu thêm cùng kiểu samples không
tự tạo được một hard upper bound về delivery age. Vướng mắc kế tiếp là chọn
contract timing có thể thực thi trong scope read/flow hiện có; đây là thiết
kế riêng, chưa phải lệnh nới gate.

| Hạng mục | Hiện tại, giữ nguyên | Hướng đề xuất cần chốt ở P9 |
|---|---|---|
| Thẩm quyền deadline | Loader đòi finite reviewed native U; UNKNOWN chặn REASONING input | Opt-in pilot với operational timing assumptions tách khỏi hard proof; U vẫn UNKNOWN |
| Budget | Các bound đã được prove mới cấp quyền wait/input | Lập budget bảo thủ trên snapshot/host elapsed hiện có và reserve của đúng cohort; chưa có số đủ chứng cứ thì capability pending |
| Freshness | Không suy mới từ raw/anchor | Không dùng P8 để cấp tick receipt; khai báo rõ residual stale-message risk |
| Flow | Existing reads/preflight/input/ACK | Giữ nguyên, không gắn observer vào farm, không thêm poll/read/capture |
| Lỗi/thiếu evidence | BASIC theo existing validity gates | BASIC giữ nguyên; không gửi fallback sau khi đã input hoặc bypass state invalid |
| Triển khai | BASIC/shadowOFF/UI gated | Chỉ sau user chốt concrete contract và milestone triển khai riêng; P9 không tự sửa production |

Exactly one next:
**[5D.1-P9 — offline timing contract decision package](../prompts/5D1_P9_OPERATIONAL_TIMING_CONTRACT_PROPOSAL.md)**,
SELECTED ONLY / NOT EXECUTED / NOT ACTIVATED. Không cần mở game; chưa native R
calibration, thêm observation window, input hoặc D1/D2. **STOP P8.**
