# 5D.1-P20 — Admission coverage review OFFLINE

**SELECTED ONLY / NOT EXECUTED.** Đây là một bước review, không phải lệnh chạy
batch mới. Parent [P19 report](../reports/5d1_p19_report.md),
[P19 audit](../artifacts/5d1_successor_p19_20261015_v1/closure/audit.json),
[P17 contract](../research/5d1_p17_source_timing_rebind_contract.md).
Đọc AGENTS, STATUS, ROUTER, EXECUTION_CONTRACT, capability và P15–P19.
Stop ở milestone này.

## Mục tiêu và entry

P19 đạt3/3 WIN, flow và successor diagnostics PASS SCOPED,30/30 SWAP timing đủ,
8 completed normal retentions,0 faults. Nhưng19/30 SWAP bị root read-span veto,
và combat2 không submit job nào. Phân biệt thiếu admission thực sự với log loss,
worker fault và completed retention trước khi mở rộng technical acceptance.

Kiểm P19 closure/raw manifests và P18 frozen source294
`b673eab28dfcb1c5d32116d264789b7e5d8b2d9bdc7a2df7dfc469012e2740a9`;
host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Không dùng request/claim P19 để resume hoặc mở thêm attempt. Hai P19 requests
đã consumed; phiên pre-entry0 game attempts được giữ riêng với retry3TOTAL.

## Phạm vi

**FILE-ONLY / NO IMPLEMENTATION / NO LIVE.** Không cần user mở game.
Không mở/đóng/điều khiển UI hoặc game, attach/read memory, capture ảnh, input,
observer mới, tests/benchmark/soak mới hoặc fault injection live.
Không source/test/tool/build/version/Git/game-file/ordinary-preference changes.
Review đọc source/reverse/evidence hiện có; output chỉ docs và review artifacts.

1. Đối chiếu full30 SWAP timing records,3 superseded timings,8 decisions và
   final watermarks. Lập bảng theo match/turn/root timestamps/read span,
   admission reason/worker outcome/pacing/preflight/action/ACK. Tách3 opening
   cards[] fallbacks,19 root-span vetoes,8 completed retentions. Bridge/poll
   counters không được dùng làm số lượt. Giữ2 pre-input state changes và
   3 terminal-no-ACK; không suy `user_state_changes` là thao tác người dùng.

2. Trace đúng timestamp boundaries trong frozen production code: root poll
   bắt đầu/kết thúc ở đâu, span bao gồm công việc nào, timer/source identity
   được lấy lúc nào, fresh/final checks được gắn label thế nào. Đối chiếu P15
   và P11 với provenance riêng. Không coi native board sub-read hoặc một field
   timer mới hơn là chứng minh toàn snapshot coherent/fresh.

3. Tìm bằng chứng sẵn có giải thích spans120–158ms ở P19 và biến đổi giữa
   combats, gồm cumulative metrics/cache/card/fusion/transport paths nếu có.
   Chỉ khẳng định causal finding khi source và raw evidence đủ. Không có
   breakdown thì ghi UNKNOWN; không đổ cho planner22–44ms, người dùng, CPU,
   screenshot hoặc memory reader chỉ từ tương quan.

4. Chốt hướng nhỏ nhất: lỗi boundary/accounting có thể sửa offline; hoặc
   reviewed admission contract cần thay đổi có lý do; hoặc giữ policy100ms
   và công bố scope fallback/coverage hạn chế. Mỗi lựa chọn phải nêu điều kiện
   chứng minh source coherence, timing reserve và rollback. Không tự nới100ms,
   dùng snapshot bị veto/cached proposal, reset t0/deadline, giảm guard/margin
   hoặc thêm read/capture/poll để tăng số lượt suy luận. Native U vẫn UNKNOWN.

5. Nếu cần implementation, chỉ viết đề xuất và acceptance cases có thể kiểm
   offline ở bước sau; không implement trong P20. Nếu cần evidence mới, nêu
   một câu hỏi cụ thể và vì sao raw hiện có chưa đủ, không tự chạy live.
   Completed retention luôn hợp lệ; không đặt quota đổi nước hoặc quota win.
   Giữ flow BASIC/read/capture/action/input/ACK/room/Stop và AI-only fallback.

## Đầu ra và STOP

Viết `reports/5d1_p20_report.md`, bảng evidence machine-readable, source-boundary
map, UNKNOWN ledger và quyết định review có provenance/hash. Acceptance/proposal
không tự cấp live authority; nếu có draft thì accepted=false và không run/claim.
Kiểm parent/source/host/preferences/claims/game-file preservation theo scope
file-only; mọi log idle append được tách khỏi immutable combat archive.

Update STATUS/README/ROUTER/capability và chọn **exactly one** prompt kế từ bằng
chứng: targeted offline implementation, targeted evidence preparation hoặc
scoped D1 readiness gate. Không tự thực thi prompt đó. Chưa CAREFUL/Demon/Mega,
general SIMPLE acceptance, batch cap12/D2 hoặc đóng Phase5. **STOP P20.**
