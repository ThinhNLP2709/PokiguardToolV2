# 5C.2 — AI settings và immutable run intent

Ngày 2026-10-10. Phạm vi **OFFLINE_UI**, parent [5C.1](../reports/5c1_report.md).
Không cấp quyền chọn nước cho REASONING và không kích hoạt live batch.

## Giao diện và mặc định

Tab **AI** nằm sau Tùy chọn. Cơ bản vẫn là chế độ chọn nước duy nhất.
Control “Suy luận chọn nước (chưa mở)” bị khóa, backend vẫn từ chối
`Intelligence.REASONING`; thay StringVar/preferences không thể mở selection.

| Cài đặt | Mặc định / giới hạn | Ý nghĩa |
|---|---|---|
| Chẩn đoán shadow thử nghiệm | Tắt | Quan sát publication đã có; BASIC vẫn chọn và phát action |
| Ngân sách tối đa | 4000 ms; integer 50–6000 | Trần xử lý từ receipt của publication, không thêm delay trước action |
| Diagnostics | Đi cùng shadow | Separate sink theo hard caps C1; không bật worker khi shadow tắt |
| Cấu hình khi đang chạy | Khóa | Đổi sau khi controller đã dừng; giữ semantics Start/Resume hiện có |

Budget rỗng, số thực, Unicode digits, bool hoặc ngoài range bị từ chối, không
âm thầm tăng/cắt giá trị. Budget nhỏ có thể bị skip vì không đủ slice.
Đây chưa phải actual game timer/input reserve đã hiệu chỉnh; C3/C4 nhận gate đó.

Status hiển thị reason/fallback code, đề xuất shadow, quyền chọn nước BASIC,
override chưa áp dụng, written/dropped/queued/fault/unsupported/rate-limit.
Không gọi score là xác suất thắng. Counters là watermark của **lần quan sát
combat hiện tại**, không là tổng run hoặc chứng nhận accounting cuối cùng.
`accounting_valid=False`; các tầng có thể thay đổi giữa các lần đọc watermark.
Status cuối run giữ mẫu gần nhất và đổi trạng thái STOPPED, không chờ drain.

## Preferences và checkpoint

- Preferences save dùng `pokiguard.desktop_preferences.v3`, đọc cả v1/v2/v3.
- AI block: `pokiguard.ai_settings.v1`, `shadow_enabled`, `budget_ms`.
- Thiếu AI block dùng literal defaults tắt/4000, kể cả caller cung cấp defaults
  có shadow bật; không tự ghi file khi load.
- AI block invalid chỉ reset AI và báo `PREFERENCE_AI_INVALID`; valid PlayStyle,
  input mode, loadout và tactical settings vẫn được giữ theo migration cũ.
- Lưu AI riêng chỉ thay block AI trong draft đã accepted. Không áp window size,
  không đọc game, không áp các trường gameplay đang chỉnh dở.
- GameplayConfig/PolicyConfig và schema/validation checkpoint không thêm AI.
  Resume giữ canonical gameplay/target/input validation; AI settings hiện tại
  được freeze cho invocation mới, không lấy runtime authority từ preferences.

## Version mapping và vòng đời

`DesktopConfig` và `AISettings` là frozen dataclass. Control plane khóa update
khi manager active, giữ nguyên target pinning và launch boundary hiện có.

Khi shadow bật, background controller tạo `RunShadowSession` từ accepted config:

```text
pokiguard.ai_run_intent.v1
  + full DesktopConfig canonical copy
  -> config_json (immutable string)
  -> SHA-256 config_id
```

Full copy bao gồm PlayStyle/loadout/tactical settings, AI, input mode, window
profile, limits và target đã pin; không ghi đè giá trị chiến thuật bằng proposal.
Snapshot planner vẫn clone PolicyConfig BASIC hiện có tại setup C1. Versions
thêm `ai_run_intent=v1`, `run_config_sha256=config_id`; private run UUID/observation
serial phân biệt các combat. Gameplay publication giữ session/match/turn/board
binding cũ. Config hash là intent mapping, không là final-preflight certificate.

Tại đúng hai combat invocations đã có (normal và recovered one-action), optional
session chuẩn bị adapter. Không có session thì gọi BASIC với arguments cũ.
Factory/prepare failure trả None và báo degraded; không retry/wait trên action.
Sink dùng cùng `farm_runs/reasoning/`, global ownership ledger C1 từ chối observer
mới nếu cleanup trước chưa xong. Không tạo writer/directory riêng cho từng match
để tránh nhân retention allocation theo số trận.

`RunShadowSession.stop()` chỉ signal. Observer C1 sở hữu bounded asynchronous
cleanup, không join/drain trên Tk/FarmRunner/Stop. Không thêm pause/resume flow.
Bú win/Coop shadow **UNSUPPORTED**: báo `COOP_SHADOW_NOT_ACCEPTED`, không tạo
worker, BASIC Coop giữ nguyên. Các profile solo có thể quan sát SWAP; source
skill/thẻ, runtime model/legality/timing thiếu vẫn UNKNOWN/unsupported như C1.

## Đường status và lỗi

Callback optional chạy trên observer thread đang có, tối đa một publication
status/giây và một final status. Không gọi callback từ `observe_line`/log writer
của BASIC. Đây là update từ vòng observer hiện có; không thêm provider/capture
hoặc game polling loop.

Status dùng phase `AI_STATUS` qua callback observer FarmRunner/Desktop hiện có.
Manager try-lock, copy immutable primitives; bỏ status stale generation/old
combat/inactive controller hoặc đòi selection authority. Lock busy trả ngay,
observer có thể thử lại ở window tiếp theo. Listener fault chỉ mất status;
BASIC và separate diagnostics tiếp tục. UI render từ cached control snapshot
với timer/poller cũ; không chờ worker. Desktop poll log hiện có đã serialize
controller snapshot, nên lưu được setup/degraded status mà không thêm sink.

Reasoning log C1 giữ 1 job/s, 8 events/128 KiB/s, tổng queue 512 records/8 MiB,
rotation 10 MiB ×10 files, 7 ngày. Callback không enqueue thêm AI diagnostic
record; không dùng gameplay writer làm AI sink. Written chỉ lấy ACKed writer
counter; drop gồm publication/relay/encoding-enqueue/write-discard losses,
không cộng lại sink enqueue rejection đã được adapter đếm.

## Ranh giới bằng chứng

Source audit bảo toàn combat controller, solver/provider/input/ACK/QTE code;
FarmRunner AST khớp trước C2 sau khi loại optional forwarding branches.
Offline tests kiểm UI Tk thật với provider unavailable, process logger thật với
synthetic publication, faults và immutable Start/Resume. Không attach game.

C1 admission/CPU evidence vẫn có phạm vi C1 và hard rate caps, không được gọi là
benchmark toàn app của C2. Full flow parity, status callback/resource overhead,
deadline/reserves và bounded baseline live là **5C.3**, selection là **5C.4**,
profile gameplay acceptance là **5D**. Không claim sửa được boss ăn Khiên live,
ưu thế gameplay hoặc packaged acceptance từ bước này.
