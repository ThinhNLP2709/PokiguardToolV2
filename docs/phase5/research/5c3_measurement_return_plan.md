# 5C.3 — Return gate cho phép đo tích hợp

Parent: [5C.3](../reports/5c3_report.md). Mode OFFLINE, không live/input.
Return gate offline đã đóng: **PASS_OFFLINE_LIVE_PENDING**, 1966regression,
142required gates và30min integrated stream. [Protocol V2 và post-fix result V3](5c3_qualification_protocol_v2.md).
Next **[5C.4 OFFLINE ONLY](../prompts/5C4_GUARDED_SELECTION_AND_EXISTING_PREFLIGHT.md)**,
selected/not executed. Không sửa BASIC. C3 live closure bắt buộc trước D1.

## Historical V1 evidence và giới hạn — trước V2

248 Python sources của C2 byte-preserved. Full controller Stop chạy với native
surfaces bị chặn, 100 cặp disabled/shadow; thêm một Stop với worker treo thực.
180 worker fault trials và preflight/source/pending/duplicate compositions.
Không có bằng chứng mới về lỗi gameplay. Live vẫn chưa chạy.

Benchmark C3 đo cả `_decision_fields` → JSON codec → gameplay writer/flush →
optional admission, gồm native AI writer và manager status callback. 3×10,000
pairs/mode, 1,000warmup/run/mode, giữ toàn bộ raw. 4/12 nhóm không đạt gate.
Đây là **burst/overload probe**, không phải healthy combat throughput:

- Sáu profile dùng chung config SIMPLE trong một adapter. Các profile khác có
  conflict được từ chối; baseline bytes vẫn giữ. Runtime thật khóa một profile
  cho một combat. Không dùng probe này để qualify healthy workload sáu profile.
- SIMPLE/CAREFUL là SWAP; bốn fixture còn lại là NONE. Chưa đại diện đầy đủ
  CAST/PASS/PET_SKILL/EVOLVE của từng profile.
- Gameplay sink là deterministic digest sink; native AI disk sink là thật.
  Chưa đo tương tác với actual gameplay append/flush backend.
- Disabled control và mode dùng cùng hàm, cùng state và writer class mà vẫn
  có paired spike9.819ms. Đây là dấu hiệu nhiễu phép đo/scheduling; không đủ
  để quy nguyên nhân cho AI. Không xóa spike hoặc lặp benchmark đến khi PASS.
- Shadow CAREFUL p95=1.0211ms ở run1, limit1ms; run2 shadow max10.2197ms và
  sink_fault max10.1486ms, limit10ms. Không làm tròn xuống để đạt gate.

## Historical return tasks — đã thực hiện ở V2/V3

1. Giữ frozen raw/protocol/source hiện tại. Predeclare protocol bổ sung với
   lý do sửa tính đại diện, không coi đó là retry thay kết quả cũ. Chạy null
   control để đánh giá nhiễu; nếu null control không đủ phân giải gate thì kết
   luận NOT_QUALIFIED thay vì quy latency cho runtime.
2. Dùng từng immutable config/profile trong combat/session riêng, chỉ một
   factory-owned adapter tại một thời điểm; dùng state/source thay đổi hợp lệ.
   Tách healthy cadence khỏi overload/fault. Thu action families từ fixture/log
   đã có, đánh dấu unsupported đúng scope; không thêm memory read/capture.
3. Đo toàn phần host mới ở actual accepted common writer boundary, cả native
   capped separate và shared namespace/filter nếu cần. Ghi thời gian publish,
   dispatch/preflight/Stop ở seams offline sẵn có; không thêm production loop.
   Với positive SWAP/ACK cần actual controller harness có provider/window/input
   fakes, không biến component composition thành full-controller execution.
4. Giữ targets A3/B4, 3runs×10,000/mode +1,000warmup/run, nearest-rank từng run/
   family, raw max và quantile differences. Chỉ thay target khi có quyết định
   và lý do riêng; không âm thầm nới gate vì máy có scheduling spike.
5. Sau latency qualification, chạy 30min healthy integrated resource stream
   sau warmup; own/known child PIDs, disabled control, host CPU normalization,
   first/last5min medians, queue/private-memory caps và zero eligible critical
   log loss. Không lấy B4 component soak làm C3 whole-integration resource PASS.
6. Bổ sung fault variants còn thiếu ở exact integrated boundary, ≥30 trials/
   variant; giữ Stop100 và B4 cancellation/reap bounds. Dùng native logger faults
   khi kiểm sink, phân biệt cooperative cancel, startup timeout và late reply.
7. Nếu tìm ra lỗi runtime cụ thể: tạo remediation đúng parent, thay đổi tối
   thiểu trong V2 và regression phù hợp. Chưa có nguyên nhân thì chưa sửa flow,
   reader, input executor hoặc BASIC. Chỉ rerun phần bị ảnh hưởng với source mới.

Return gate đã đạt offline ở V3 sau rotation fix: parity/fault/added-software latency/resource và regression →
PASS_OFFLINE_LIVE_PENDING; lúc đó mới cho C4 offline. C3 live closure bắt buộc
trước D1. Nếu vẫn thiếu thì giữ C3 PARTIAL và mô tả đúng giới hạn.

## Live runbook — batch 2026-10-11 đã hoàn thành

Kế hoạch bên dưới đã được kích hoạt khi user chuẩn bị phòng và tự vận hành
game. [Live report](../reports/5c3_live_closure_report.md), [frozen manifest](../artifacts/5c3_live_closure_preparation_v1/live_batch_manifest.json)
và [result](../artifacts/5c3_live_closure_preparation_v1/live_closure_result.json):
3 OFF +3 SHADOW,6/6 WIN,9 local turns/tool-count energy,3 ACK,6/6 jobs retain
BASIC/6 reaped/24 AI records; no observed critical regression. PASS STRONG
scoped ordinary SWAP technical smoke, không efficacy hoặc whole-app performance
acceptance. Cap6 đã hết, test UIs đã đóng; không tự chạy thêm để lấp coverage.
C4 offline đã hoàn thành trước batch; exactly one next D1 selected only,
NOT_EXECUTED/LIVE NOT_ACTIVATED. Phần “next C4 selected” phía trên là lịch sử.

Chỉ thực hiện sau offline gate và người dùng yêu cầu batch, chuẩn bị game ở
boss lobby hợp lệ. Chọn một solo profile có baseline/loadout/boss rõ, giữ input
mode và PlayStyle settings đang accepted. Freeze source/config/hash trước batch.

Thứ tự dự kiến OFF, SHADOW, OFF, SHADOW, OFF, SHADOW; cap6 attempts kể cả abort/
technical failures, không bù attempt. Mỗi mode3 attempts, cả hai phát BASIC.
Người dùng vận hành game; agent không tự computer-use hoặc inject fault live.

Đọc evidence sẵn có trong common/AI logs: memory/capture sequence, exact actual
dispatch, ACK/pending, skill/QTE, lease, Stop, end-match và re-entry. Không extra
reads/captures để lấp missingness. Trường hợp không xảy ra ghi NOT_OBSERVED.
Dừng batch ngay khi user Stop, duplicate/stale/wrong-turn/after-Stop input,
ownership/ACK conflict, baseline flow regression hoặc AI ảnh hưởng baseline.
Không retry để đạt đủ số hoặc suy win-rate từ6 attempts.

| Live evidence | Trạng thái |
|---|---|
| Disabled3 / shadow3 attempts | COMPLETED — 6 attempts,6 WIN,cap reached |
| Memory/capture/action/ACK order | 9 SWAP/3 ACK observed; independent read/capture boundary traces NOT_OBSERVED; no extra instrumentation |
| Actual skill/QTE/card/input lease | Skill/QTE/card/lease-specific cases NOT_OBSERVED; ordinary foreground/two-click owner preserved |
| Navigation/result/lobby/re-entry | Six result confirmations and boss-lobby returns; room-error re-entry NOT_OBSERVED |
| Live Stop/fallback/deadline | Target-complete Stop6; retain BASIC6 unsupported-context jobs; user emergency/fault/deadline cases NOT_OBSERVED |
| Live overhead / efficacy | NOT_MEASURED / NOT_TESTED; historical offline evidence retains its own scope |
