# B17 Priest — bàn trước/sau nước boss và Suy luận

18/11/2026. Nối tiếp [4 BASIC ban đầu](B17_PRIEST_OUTCOME_LIVE_20261118.md),
giữ Demon Aegis thường ăn Khiên/4 Kiếm hiệu dụng, Priest lv131 ID1845,
room `Coop_911927`, cùng account alias và đồ do user giữ nguyên. Nhóm Mega
khác sẽ dùng acc/pet/boss riêng; không dùng hệ số damage chéo giữa nhóm.

## Thay đổi có phạm vi

Source95288bff… → **b1b718fb1e5bf12664e12044e1ebaab84505391b09056b19cad2be746ee9f622**.
Chỉ4 file code/test thay đổi: module optional `combat_board_evidence`, các
điểm log trong `basic_auto_bot`, normalizer boss offline và test mới.

- Giữ64 ô native, tag, multiplier, hash của snapshot transport/current-owner
  đã được provider nhận. `accepted` ở bước offer chưa là ACK hoặc bàn hiện tại.
- Ghi thêm trạng thái Solo mà provider **đã publish**: trận/epoch/Board,
  seq/turn, chủ lượt, bàn màn hình, HP/Mana/Nộ/Khiên của ta/boss và nguồn.
  Yêu cầu stable/latest/ACK, board ready, không cascade/UI busy/modal/resync.
- Identity người chơi được hash, không thêm đọc process, offset hoặc scan.
  Bộ ghi dùng tối đa256 trạng thái duy nhất/controller, báo thiếu khi chạm cap;
  không đổi policy, timing/input primitive, PASS hoặc admission của provider.
- Normalizer chỉ ghép khoảng có before thuộc BOSS và after thuộc local,
  cùng match/epoch/Board/account alias, turn kế tiếp và seq khớp response.
  Một SWAP được giữ và không có action khác/input ta xen giữa. Nhiều nguồn
  xung đột hoặc thiếu before/after thì UNKNOWN. Không giả định srvSeq tăng1.
- `preBoard` trong DTO là dữ liệu đã preparse, **không** tự coi là bàn trước
  nước boss. Không lấy LastMove của ta, collapse hoặc refill giả làm before.

Các khoảng quan sát không chứng minh complete server coverage, chính sách
boss phổ quát hay nước tối ưu. Training/calibration vẫn false. Normalizer
observation chung và Demon cũ giữ nguyên; không gán quyền input từ log.

## Offline

246 test liên quan PASS, gồm90 test evidence/normalizer/tap ở lượt kiểm đầu.
Provider baseline, dispatcher roots, common capture/selection và BASIC policy
đã kiểm. Đây không là tuyên bố full suite repo sạch. AST4 file parse được;
manifest trước/sau chứng minh phạm vi thay đổi, không sửa historical proof.

Replay đúng4 raw log có SHA từ closure cũ:0 boss interval có before/after,
21 boss SWAP thiếu published boundaries,2 batch boss không đúng1 SWAP.
Không tự hồi dựng hoặc tạo nhãn học từ các log đó.

Qualification Suy luận dùng source hiện tại đã freeze, real local worker/writer,
100 triple ROOT/FRESH/FINAL:14 gate PASS, triple max1,2616ms,300 checkpoint
record không mất. Runner copy từ đợt B16 chỉ đổi hằng nhận diện **source mới
được freeze cho lần đo mới**; không sửa pin/profile/proof cũ. Đây là smoke
synthetic, không phải population bound hoặc5000 native samples.

## BASIC mới — cap1 đã đóng

Match `M_db5ccb58`, farm `7fc496db2d784571abad5818db6e5e50`: WIN STRONG,
8 lượt ta/7 lượt boss,7 ACK+1 terminal. Nhận thưởng/về đúng phòng.
0 safe stop, recovery, PASS hoặc vi phạm safety counter. Source không đổi.

Thu14 published states (7 BOSS+7 LOCAL),8 retained64-cell boards và **7/7
boss response nối được before/after**,0 invalid/unbound trong exporter boss.
14 typed effect batch,40 effect; không coi đó là complete action coverage.
8 timing record/7 sent-ACK samples hợp lệ; writer đóng/flushed/0 loss.

Đối chiếu với solver hiện có:7/7 SWAP boss nằm trong tập legal trên before
board thực. Có2 cơ hội kiếm tính được mà boss chọn đúng known-Sword maximum:
turn8 lấy3 kiếm qua cascade biết trước, turn12 lấy6 kiếm trực tiếp.5 before
board khác không có nước kiếm biết trước. Đây là2 cơ hội trong1 trận, không
chứng minh boss luôn greedy hoặc không có passive/refill ngoài mô phỏng.

## Suy luận mới

Đã chuẩn bị riêng cap1 bằng profile mới từ7 timing samples ở source/B17/host
hiện tại và qualification ở trên. `CommonNativeAuthority` load hợp lệ; chỉ
swap family, Solo, foreground/two_click, random0–1s/0–1,5s và tọa độ10%.
Profile/private preferences nằm trong data root riêng, không cài đè profile
hoặc preferences chính và không gắn lại native proof B16.

Match `M_56feba93`, farm `9c8e857a3c9045328b57ebeabdfc9c90`: **WIN STRONG**,
8 lượt ta/7 lượt boss,7 ACK+1 terminal; nhận thưởng/về Priest,0 safe stop,
technical recovery, PASS hoặc safety violation. Cap1 đóng, không chạy lại.

8 snapshot/8 decision;24 receipt ROOT/FRESH/FINAL đều `VALID_COMPLETED_COMMON`.
Tất cả8 action gửi khớp đúng đề xuất hoặc baseline mà decision đã giữ;
**5 nước đổi so với BASIC**, gồm4 ACK và1 nước kết trận.49 record chẩn đoán
đã ghi/flushed,0 loss/fault/late/reject;1 worker tạo và reap được. Không chỉ
nhìn nhãn UI để gọi là Suy luận: đã nối source/session/turn/seq/board/hash
và target nước thực tế. Nhãn tạm `UI_REASONING_COHORT_CHANGED` khi lượt boss
vẫn có thể xuất hiện theo vấn đề UI đã ghi trong backlog; không là safe stop
hoặc phủ nhận8 decision receipt vừa kiểm.

R ghi14 published states và9 retained boards, nối6 boss response với bàn
trước/sau; boss có7 lượt nên **không** gọi đó là bao phủ toàn bộ action.
Gộp2 trận source b1b7 có13 khoảng boss quan sát có nguồn. Cả BASIC và R đều
8 lượt trong2 bàn khác nhau: chỉ là kiểm chức năng có nguồn, chưa chứng minh
win rate/tốc độ/nước tối ưu hoặc adviser đã tự học. Damage/skill/refill,
complete effect coverage và đầy đủ gear/buff/khắc hệ vẫn chưa kiểm.

Tổng18/11 trong nhóm B17 Priest:5 BASIC+1 R=6 trận,6 WIN; cap4 cũ và2 cap1
mới đều đã đóng. Không trộn timing source95288 cũ với sourceb1b7 mới.

## Bằng chứng

- [Audit và phạm vi source](artifacts/b17_boss_board_evidence_20261118/audit.json)
- [Replay4 log cũ](artifacts/b17_boss_board_evidence_20261118/historical_review.json)
- [Qualification hiện tại](artifacts/b17_boss_board_evidence_20261118/qualification/qualification.json)
- [Closure BASIC1](artifacts/b17_boss_board_evidence_20261118/live/closure.json)
- [Before/after boss](artifacts/b17_boss_board_evidence_20261118/live/boss_intervals.json)
- [Đối chiếu nước boss](artifacts/b17_boss_board_evidence_20261118/live/boss_choice_review.json)
- [Closure và joins Suy luận](artifacts/b17_boss_board_evidence_20261118/reasoning/closure.json)
- [Khoảng boss trong R](artifacts/b17_boss_board_evidence_20261118/reasoning/boss_intervals.json)

Không build, bump version, commit hoặc fit model trong mốc này. Việc tiếp
theo là dùng các khoảng có nguồn để kiểm sai số threat/reply của adviser và
định lượng effect theo nhóm; refill chưa được suy ra đầy đủ. Không cần user
đổi boss để phân tích các dữ liệu vừa thu. Game ở Priest và tool đã dừng1/1.
