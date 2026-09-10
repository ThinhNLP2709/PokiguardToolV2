# Phase 3A.2 — kiểm tra hai lượt test thủ công, v1.0.45

Ngày 2026-09-11 (Asia/Saigon). Phạm vi: sửa việc nhận bàn của BASIC trên
1.7.4-b2; không mở Phase mới, không tích hợp Pet Skill, không chạy trận mới.
Trạng thái: **offline PASS; chờ người dùng test live lại**.

## Bằng chứng từ hai lượt đã dừng

Nguồn: `logs/farm_runs/<runId>/matches/attempt_001/combat.jsonl` và `run.json`.

| Run | Bàn có quyết định được lưu | SWAP được ACK | PASS chủ động |
|---|---:|---:|---:|
| `e7ce18c0c69d49bba346db1a24a5582f` | 5 | 4/4 | 1 |
| `f9bbaca69b1a4edd969690dfa84c9a00` | 9 | 9/9 | 0 |

**Bug 1 — chi phí 120:** cả hai run đều đọc `FusionManaCost=120` từ
MatchService. Policy và preflight đã dùng chi phí runtime, không cố định 160.
Thêm regression ở Mana 119/120/159: từ 120 đủ điều kiện chi phí, còn các gate
tiến hóa khác vẫn bắt buộc. Test này không khẳng định đủ Mana là luôn bấm ngay.

**Bug 2 — lượt tự trôi:** run thứ hai không gửi PASS. Có 16 lượt local được
quan sát nhưng chỉ 9 bàn được xuất bản; `unstable_skips=60`. Provider bị giữ ở
`awaiting_direct_owner_batch_capture` / `latest_acked_batch_not_resolved`.
Các lượt 7/9, 13/15, 25/27 không có quyết định; bảo vệ idle sau đó can thiệp
ở lượt 11/17/29. Một lần `LOCAL_TURN_ACK_GAP_FULL_ESCALATION` đọc
1,024,510,382 bytes trong 6.3165 giây. Không phải policy cố tình bỏ tài nguyên
để chạm giới hạn hai lượt.

**Bug 3 — bỏ kiếm:** chạy lại simulator trên 14 bàn đã lưu. Cả 4 bàn có
nước ăn kiếm đều ghi `STEP_2_SWORD`: run đầu lượt 1/5 (x3); run sau lượt 3
(x3) và 17 (x5). 10 bàn còn lại không có nước ăn kiếm do simulator tìm thấy.
Fixture không chứa thông tin tài khoản nằm ở
`reference/phase3a2_manual_board_audit.json`; regression bảo vệ ưu tiên kiếm.
Không có đủ bàn/screenshot ở những lượt bị trôi để kết luận chính xác lượt
người dùng thấy bỏ kiếm. Không lấy các bàn cũ làm bằng chứng rằng đã đọc đúng
bàn màn hình ở lượt bị mất.

## Sửa code và giới hạn kết luận

1. `read_match_payload_board_snapshot` hiểu hai nguồn game thực sự dùng:
   `ChatMessageDTO.preBoard` khi ready và có con trỏ, hoặc JSON board.
   Native `MatchService.ParseCombatBatch` dùng `payload.srvSeq` trước;
   thiếu key mới lấy `ChatMessageDTO.seqNum`. Reader giờ hỗ trợ cả hai.
   Nguồn preBoard bắt buộc exact class, match/type/payload hiện tại, 64 ô hợp
   lệ và đọc lại identity/root/sequence để loại mẫu đổi giữa lúc đọc.
   Exact render ACK và mọi gate của provider vẫn giữ nguyên.
2. Bộ theo dõi gap trước đây chỉ so `message.server_sequence` (seqNum) với
   ACK. Khi payload có srvSeq mới nhưng seqNum vẫn là bộ đếm client, nó quét
   toàn heap dù đã tìm thấy message cần đọc trong vùng nhỏ. Đổi so sánh sang
   cùng thứ tự srvSeq/seqNum như game. Test xác nhận chỉ một scan với
   seqNum=3, payload.srvSeq=44 và ACK=44. Trường hợp thiếu board thật vẫn
   được phép thực hiện fallback có giới hạn như trước.
3. Log thành công có `boardSource`; log từ chối có seqNum và danh sách các
   trường scalar đã đọc để phân biệt thiếu sequence/board ở lần test tới.

Hai điểm thiếu hỗ trợ/lỗi so sequence được xác nhận bằng code và native b2.
Log cũ gộp lỗi thành `payload lacks board/srvSeq`, không lưu preBoard hay
danh sách key tại thời điểm lỗi. Các DTO từ run đã hết lifetime khi kiểm tra
lại; không khẳng định mọi ACK bị thiếu đều do cùng một nguyên nhân. Hiệu quả
trên các lượt trôi cần được xác nhận bằng lần test live mới.

## Khoảng chờ đầu lượt trong b2

GameAssembly SHA256 đọc lại từ file cài đặt:
`7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`.
Reverse hiện tại xác nhận `ClockPaused +0x165`, `ClockPauseReason +0x168`,
`TurnTimeRemainingSec +0x138`, `LastAnnounceHoldMs +0x13C` và
`_inFlightBatches +0x1B0`. Reader đã dùng offset b2 cho các gate đang hoạt động.

Run thứ hai lượt 11 ghi `CLOCK_PAUSED`, reason `FX`, rồi quyết định sau khi
đồng hồ mở lại trên cùng srvSeq=22. Code không đánh dấu đã hành động khi gate
đang chặn; lần poll sau vẫn đánh giá lại. Thêm test pause FX/START_GATE rồi
resume cùng bàn. Không thêm thời gian ngủ cố định hoặc bấm thẻ khi đang chờ.
Chưa xác minh thời lượng hiệu ứng mới trong mọi trạng thái; giữ UNKNOWN.

Chi tiết native ở `il2cpp_symbols.md` và `board_resolution.md`.
Artifact đọc/disassembly ở `logs/phase3a2_bugfix_native/`.

## Kiểm chứng và test lại

Focused regression: **277 PASS**. Full regression: **1134 tests PASS**
(17.731s). Các lỗi và stall in ra trong
log test là nhánh giả lập có chủ đích; kết quả cuối unittest là OK.
`compileall` và `git diff --check` PASS.
Không có gameplay input trong lượt sửa này. Game/V1 không bị chỉnh sửa.
Kiểm tra process cuối: game còn chạy; không còn Python UI/controller/harness.

1. Đóng cửa sổ source UI cũ khi controller đã dừng; mở lại bằng `run_tool.bat`.
   Kiểm tra tiêu đề **v1.0.45**; bản executable RC cũ chưa được rebuild.
2. Giữ cấu hình BASIC đang dùng: Pet thường / Tiến hóa pet thường / Thẻ
   chưởng mặc định. Target matches **1**, Max attempts **1**.
3. Vào đúng phòng boss, Start một lần. Theo dõi đoạn chờ đầu lượt: tool phải
   chờ hiệu ứng/clock mở rồi đọc và xử lý. F9 nếu tiếp tục trôi lượt bất thường.
4. Sau STOPPED kiểm tra log mới: `boardSource`, scan elapsed/bytes, số local
   turns so với quyết định, `policyStep`, chi phí/Mana runtime. Nếu lại thấy
   bỏ kiếm, lưu số lượt hoặc thời điểm; không cần sửa/tắt gate an toàn.

Hai run cũ là bằng chứng chẩn đoán, không phải acceptance của v1.0.45.
