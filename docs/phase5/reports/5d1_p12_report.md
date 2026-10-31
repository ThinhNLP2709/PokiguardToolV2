# 5D.1-P12 — Native calibration binding review, offline

2026-10-15 (Asia/Saigon). **OFFLINE REVIEW COMPLETE / IMPLEMENTATION PENDING / PARTIAL D1.**
[Prompt P12](../prompts/5D1_P12_NATIVE_CALIBRATION_BINDING_REVIEW_OFFLINE.md),
parent [P11](5d1_p11_report.md). Scope chỉ file-only review/proposal; chưa sửa
runtime, chạy test/benchmark, tạo authority hoặc kích hoạt live.

## Kết luận

Đã xác định `cards=[]` tại ba nước mở đầu do **opening board action priority**
trong reader hiện có, được cả source và diagnostics xác nhận. Session reset
xóa card cache; reader cố ý bỏ optional CardUI discovery ở local turn0/1 chưa đi
để bảo vệ thời gian nước đầu. Cả3combat logs line5 ghi priority này, preentry có
Attack64647/card4 nhưng live card list chưa quan sát; line20 đã validate current
hand và xuất hiện đúng Attack. `runtime_witness` chép observed cards như loadout
identity nên equality v1 coi hai representation thành mixed witness.

Đây không là bằng chứng người dùng gỡ thẻ. Không cần sửa hoặc thêm read/capture
vào opening flow. Không suy art mismatch, actual pet effects, mana/damage formula
hoặc EVOLVE failure cause. [22source traces + compatibility ledger](../artifacts/5d1_native_binding_p12_v1/source_compatibility_ledger.json)
pin file SHA, lines và excerpts; [inventory](../artifacts/5d1_native_binding_p12_v1/accepted_data_inventory.json)
pin59files, exact native/entry/combat/timing refs và mọi joins.

## Evidence có thể dùng lại

| Raw evidence | Số lượng | Phạm vi dùng lại đề xuất |
|---|---:|---|
| Full observed Attack + ordinary ACK | 20 | Anchor cho đúng full observed witness |
| Opening deferred, cards[], ACK | 3 | Giữ host timing; ngoài scope suy luận |
| Complete host return + terminal, không ordinary ACK | 3 | Giữ host timing và matched terminal evidence |
| Superseded decision,4EVOLVE attempts | 4 | Giữ ledger; không SWAP interval/không duration0 |

Cả26SWAP intervals và30records giữ nguyên.3attempts/3WIN, all-attempt ledger,
zero-loss writer watermarks và hai failed Issylt openings trước đó được bảo toàn.
Không loại failure hoặc đổi ACK labels để có PASS. Legacy export v1 vẫn nguyên
lỗi `MISSING_OR_MIXED_RUNTIME_WITNESS`. Legacy operational loader còn đòi ACK cho
mọi completed row, nên chỉ sửa mixed witness/source SHA cũng chưa đủ; cần review
classification của3terminal rows trong schema mới, không bỏ chúng khỏi raw data.

Hmax164.429ms/Imax2972.325ms/full-tailmax3132.4282ms vẫn lấy từ cả26physical
returns; không tính maxima chỉ trên20anchors. Native U/transport/alignment
UNKNOWN, exact first-click timestamp NOT_MEASURED.20anchors không là effect
model calibration hoặc guarantee thắng/safe.

## Một correction proposal đã hoàn thiện

[Contract đề xuất](../research/5d1_p12_native_calibration_binding_contract.md)
chốt một operational review sidecar v2, giữ raw export/errors/source SHA và
mọi record; verifier dựng lại coverage/classification/joins từ pinned bytes.
Full observed witness là scope duy nhất cho future R1 SWAP; snapshot thiếu thẻ
hoặc witness khác giữ BASIC. Không sửa runtime witness hoặc exact equality,
không đưa lobby card vào state để lấp UNKNOWN, không thêm chờ hoặc đổi PlayStyle.

Giữ native source284 và target source tương lai riêng, exact dependency review
và bounded byte-exact archive mapping. Legacy v1/strict finite-U loader vẫn
reject thiếu proof. Missing/partial data, unexpected group, source/host/card/
cost/fusion/account/boss mismatch đều fail closed. Reserve gồm maxH/maxI của
cả26+fresh selector allowance+3060mscommand ceiling+guard≥250ms, floor3000ms,
margin≥100ms.6456.6823ms vẫn chỉ reference dùng old allowance, không authority.

Đề xuất100ms là operational read-span veto threshold cho scope này, **chưa áp
dụng**, không native latency/clock bound; P11 rootmax49.7245ms/finalmax4.9305ms.
Source đã có root/final consumer cho threshold. BASIC validity/flow giữ nguyên.

## Source/benchmark và return gate

Current284 source vẫn fingerprint
`bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f`.
So P10:280existing files giữ byte,3entry/UI/controller files đổi và1newtest.
8files trong runtime qualification manifest P10 còn exact; benchmark methods
chưa đổi, nhưng overall source pin và historical source-audit layer không còn
đủ để publish current allowance. Không relabel9.9283ms, không gọi full2179tests
cũ là acceptance mới. Đã lưu exact3diffs và AST-node changes.

P13 cần exact rewind layer của entry side fix, final source freeze, fresh4path+
disabled benchmark theo thresholds P10, pipeline/Stop/bounded stress và full
regression ở boundary integration. Native timing reuse chỉ có điều kiện: path
đo H/I/read/input giữ nguyên theo dependency review. Nếu không chứng minh được,
giữ INCONCLUSIVE, không tự farm thêm.

[26planned cases](../artifacts/5d1_native_binding_p12_v1/implementation_case_plan.json)
bao raw integrity/unknown/full-witness scope/terminal/partial/maxima/watermark/
source/legacy reject/activation/cap/expiry/Stop/parity và qualification. Static
review thấy mismatch khi có old active job cần negative test cho signal fallback
nhanh; chưa gọi đây là lỗi live đã reproduce, chưa sửa bridge trong P12.

## Bảo toàn

284/284Python sources giữ bytes. Parent artifacts và59data pins được kiểm lại
ở [final verification](../artifacts/5d1_native_binding_p12_v1/verification_final.json).
Game4files chỉ đọc để hash; HEAD/preferences/package/version giữ, không restore.
Source UI P11 đã mở từ trước có log snapshot tiếp tục append; before prefix được
lưu riêng, theo dõi append thay vì gọi file đang chạy là immutable evidence.
P12 không tạo process/game lookup/attach/read/capture/input/network/worker/test/
benchmark/soak mới; không build/version/Git mutation. Existing P11 app polling
không được biến thành native observation mới cho P12 hoặc đem cấp AI authority.

## Next duy nhất

[P13 — offline implementation/qualification](../prompts/5D1_P13_CALIBRATION_REVIEW_IMPLEMENTATION_OFFLINE.md)
**SELECTED ONLY / NOT EXECUTED**. Không cần mở game hoặc thêm trận để xử lý các
binding gaps đã xác định. P12 review hoàn tất, native reserve/AI activation còn
pending; BASIC/shadowOFF/UI gate giữ, chưa D1draft12/D2. **STOP P12.**
