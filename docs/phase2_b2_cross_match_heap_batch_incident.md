# Phase 2 b2 — board trận trước lọt vào lượt hiện tại qua raw heap batch

Ngày điều tra và sửa offline: 2026-09-12. Phase 2 vẫn chưa chốt. Không commit,
push hay tăng version trong lần sửa này.

## Kết quả run

FarmRun `ff774dfb07134ca68789f46a25aed264` hoàn thành bốn trận đầu với kết quả
WIN / STRONG / CONSISTENT và formal PASS bằng 0. Attempt 5, MatchId
`M_7a17c9b5`, được người dùng F9 sau khi quan sát tool bỏ kiếm. Attempt này có
8 local turn, 7 SWAP sent, 6 ACK và không có EVOLVE/CAST/PASS.

Provider không báo read error, DTO rejection, stale publication hay ambiguous
latest. Những bộ đếm này không phát hiện được lỗi vì object cũ vẫn đúng class,
đủ 64 ô và có sequence trùng ACK hiện tại.

## Bằng chứng chéo trận

Attempt 4, MatchId `M_20dd0d75`, kết thúc ở game turn 13, `srvSeq=26`, với
board hash:

`9b5ad41443f8542c32dbce9623853798c20ebd87fac292231338cf1d7df9febe`

Policy trận 4 chọn Sword `(5,0)<->(5,1)` từ board này, rồi trận kết thúc WIN.

Trong attempt 5, RuntimeSequenceMonitor tìm một standalone `WsCombatBatch` ở
địa chỉ khác nhưng có đúng `srvSeq=26` và đúng hash trên. Khi ACK trận 5 tăng
đến 26, provider cũ thêm object đó vào `_ack_attested` dù nó không có MatchId,
không thuộc current Board owner và không đến từ current-match transport. Tại
turn 13 của attempt 5, solver vì vậy nhận lại nguyên board trận 4, chọn lại đúng
Sword `(5,0)<->(5,1)` và gửi hai click. Board thật trên màn hình khác nên game
không nhận swap; response hết hạn và lượt chuyển sang boss.

Hai policy record ở hai lifecycle khác nhau có cùng toàn bộ bộ ba
`(srvSeq=26, boardHash, move)`. Đây là bằng chứng trực tiếp cho reuse chéo trận,
không phải solver bỏ ưu tiên Sword hay click đúng bị mất ACK.

## Nguyên nhân

`WsCombatBatch` chỉ chứa `srvSeq` và board; nó không chứa MatchId. Sequence bắt
đầu lại ở mỗi combat. Lobby baseline đầu run không thể liệt kê mọi managed
object còn tồn tại được phát hiện muộn trong những vùng scan học lại. Do đó điều
kiện “đủ cấu trúc + không có trong baseline + sequence nằm trong ACK hiện tại”
không chứng minh currentness cho raw heap batch.

Đường current-match ChatMessageDTO không có lỗi này vì decoder kiểm tra MatchId.
Đường `MatchService.PendingCombat` và `BoardWsApplier._pendingBatches` cũng có
owner/session checks. Đường 64 Dot được ràng buộc trực tiếp với current
`Board.Instance`.

## Sửa chữa

Raw `RuntimeSequenceMonitor.WsCombatBatch` nay chỉ là telemetry/chẩn đoán. ACK
không cấp quyền cho nó nếu exact identity chưa được một current Board owner hoặc
current-match transport DTO chứng thực độc lập. Cùng điều kiện được kiểm tra lại
khi tạo danh sách eligible để tránh một raw identity đã lọt vào cache cũ.

Khi latest ACK không có DTO/owner hiện hành, raw heap batch không còn làm
`have_highest=true`; provider đi tiếp qua fallback 64 Dot thuộc current Board,
với toàn bộ kiểm tra component, coordinate, PoolTag, motion, queue, presentation
và ACK ổn định đã có. Solver chỉ nhận board hiện tại hoặc không nhận board; nó
không còn nhận board chéo trận.

## Xác minh offline

- `tests.test_memory_provider_baseline`: **68/68 PASS**.
- Full regression: **1169/1169 PASS**.
- Test mới xác nhận raw heap identity không có current-session witness bị từ
  chối dù numeric ACK trùng; exact transport/current witness vẫn được phép.
- Compile và diff checks được chạy lại trước khi nạp UI.

Cần live multi-match soak lại. Tiêu chí trực tiếp là không có board hash từ một
lifecycle trước xuất hiện trong policy của lifecycle mới qua source
`RuntimeSequenceMonitor.WsCombatBatch+MatchService._ackedSeqs`. Latest ACK thiếu
DTO phải dùng current Dot board hoặc fail closed, và mọi Sword click phải nhận
ACK hoặc có log current-board đầy đủ để điều tra input riêng.
