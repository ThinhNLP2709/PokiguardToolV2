# 5D.1 — Shared host guard review

Ngày 2026-10-16. Sửa trong prompt chính5D.1; không tạo P mới.
Current status: OFFLINE COMPLETE /14TARGETED +51AFFECTED PASS /32COST GATES PER PROFILE PASS.

## Lỗi được quan sát

SIMPLE reasoning batch3/3WIN, về boss lobby3lần, zero safety counters.
Nhưng chỉ1job completed,1retention; AI tắt từ lượt3 trận đầu. Callback đầu:
TIMING_CONTROLLER_TAIL. Raw H306.0019ms > Hbudget303.2799ms, excess2.722ms;
I1438.1892ms; H+I1744.1911ms < R6753.3322ms. Worker không lỗi.
DIAGNOSTIC_DISABLED là bridge bị timing breaker tắt, không writer mất log.
23records durable/zero loss; timing chỉ2returns trước breaker, không giả complete
coverage46/53 như BASIC. Ba trận còn trong run đều tính cap kể cả reduced exposure.

Known trigger: per-component envelope áp sample maxima + selector allowance
thành ngưỡng tắt AI, không sử dụng G250 của aggregate. H chia các đoạn234.7012 /
71.0155 /0.2852ms; chưa biết nguyên nhân OS/GC/allocator cụ thể gây thêm2.722ms.
Không gọi máy chậm, GC hoặc lỗi planner là nguyên nhân đã chứng minh.

## Policy mới, explicit opt-in

POST_RETURN_COMPONENTS_V1 vẫn ghi base flags. Thêm field authority/request/
activation/qualification `component_guard_policy=SHARED_HOST_GUARD_V1`.
Legacy fieldNone giữ đúng fault behavior và authority identity lịch sử.

Hbase = Hnative_max + selector_cost
Ibase = Inative_max + full_BASIC_command_wait
R = max(existing floor, Hbase + Ibase + G), G=250ms giữ nguyên
EH = max(0,H-Hbase), EI = max(0,I-Ibase)

AI fault nếu timestamps invalid, aggregate>R hoặc EH+EI>G.
Không cho H và I mỗi bên250ms; positive excess dùng chung một pool.
Không bù excess bằng unused allowance của component khác. Base flags vẫn ghi
để tracking dù chưa hết guard. Ví dụ thực tế dùng2.722/250ms, còn247.278ms.

Giữ root250/final100, budget4s, return margin100, reserve formula, max10ms
qualification, pacing/random rules, source/turn/legality gates, ACK/Stop/room.
Post-return fault không phát input thay thế; quá shared guard vẫn disable AI và
BASIC tiếp tục theo accepted flow. Không thêm read/capture/poll hoặc game write.
Policy này sửa độ nhạy của breaker, không chứng minh future timer/OS bound.

## Native source binding

BASIC controls mang origin c707... đúng raw. Không đổi chúng thành observation
của source mới. `basic_boundary_review.v1` chỉ chấp nhận source delta chính xác:
OperationalAuthority optional policy/identity, post-return monitor, setup-only
native/cost validator; controller/provider/input và timestamp methods byte/AST
exact. Hai helper mới chỉ setup hoặc post-return opt-in. Native H/I vẫn lấy từ
origin, current full source/host và fresh actual-mode qualification bắt buộc.

Raw hashes, native request/source manifest/ledger/witness/ACK/terminal/watermarks
được kiểm như cũ. Bỏ boundary review hoặc đổi input timing/source ngoài whitelist
bị từ chối. Không rebind P11/P15/P19 hoặc tăng Hbasis bằng failed reasoning sample.

## Verification và live gate

14targeted tests PASS: raw failure replay, guardexact/+1ns, one-pool/no-double
credit, invalid clock, unchanged legacy behavior/identity, independently pinned
mode/cost, actual old BASIC raw lineage, real controller + real session fault
callback trên Simple/Careful:1input/1ACK, no replay, worker cleanup.
Full regression và one qualification/profile đang chờ source cuối.

Original batch consumed6/12: Simple BASIC3, Simple REASONING3. Không chạy bù,
không reset claim/breaker để gọi current exposure là PASS. Careful còn3BASIC+
3REASONING chưa kích hoạt. SIMPLE post-fix live NOT_OBSERVED; D1 chưa chốt.
Nếu cần thêm Simple live sau cap, phải là bounded request mới được user yêu cầu,
không tự tăng original cap hoặc sinh chuỗi P.
