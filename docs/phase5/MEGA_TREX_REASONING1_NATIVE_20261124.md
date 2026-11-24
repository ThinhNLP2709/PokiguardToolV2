# Mega T-Rex — chốt một trận Suy luận ngày 24/11/2026

## Phạm vi đã kiểm

Run `6dacc3a3bc1d4490a3c75da2598af5ad`, match `M_cbd51e2a`, account mới,
Archon thường → Mega T-Rex, Solo No.11 lv185, đủ điều kiện skill, Tự bảo
vệ dưới 30%. Source vẫn là
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.
User Start phiên đã mở, không tạo thêm lượt thử trong đợt đọc log này.

**WIN 1/1**, nhận thưởng, về BOSS_LOBBY, `FARM_TARGET_COMPLETED`.
23 SWAP/23 ACK; 6 lần tiến hóa gồm 5 thất bại và 1 thành công; một skill
T-Rex kết liễu, không PASS. Không technical abort/recovery, wrong-turn,
duplicate, misclick, partial input, wrong-third-PASS hoặc deadline safe stop.
Một worker đã thu hồi; writer ghi đủ 101/101 bản ghi, mất 0.

Hồ sơ dùng lại là timing SWAP cùng source/game/host/transport đã được
loader xác minh, không phải mô hình damage/heal từ account Icarus. Không
đo thêm BASIC hoặc đổi nhãn nghiệm thu Icarus thành T-Rex.

## So quyết định trên cùng bàn

10 quyết định native đã ghép đủ snapshot, ROOT/FRESH/FINAL, nước thực gửi
và ACK: **6 nước đổi so với BASIC, 4 nước giữ nguyên**. Cả 6 nước đổi là
TRADEOFF; không tạo nhãn tối ưu hoặc nhãn huấn luyện từ WIN.

| Lượt game | BASIC trên bàn đó | Suy luận thực gửi | Cơ hội Kiếm tối đa đã biết của boss |
|---|---|---|---|
| 13 | 5 Mana hiệu dụng | 6 Kiếm + 4 Máu hiệu dụng | 9 → 0 |
| 29 | 8 Mana hiệu dụng | 3 Kiếm + 6 Nộ hiệu dụng | 3 → 0 |
| 41 | 11 Khiên hiệu dụng | 10 Kiếm hiệu dụng | 8 → 0 |

Suy luận có bằng chứng cân nhắc Kiếm và bảo vệ thay vì luôn tích Mana.
Ba nước trên vẫn đánh đổi Mana/Khiên và chưa biết refill. Cơ hội Kiếm bằng
0 trên phần bàn biết được không bảo đảm boss không có Kiếm sau refill.
Các nước khác cũng có chi phí: lượt 35 đổi 4 Mana lấy 7 Máu; lượt 39 đổi
5 Mana + 3 Khiên lấy 7 Hút, giảm một nguy cơ Kiếm do refill có điều kiện.
Không coi mọi thay đổi là cải thiện toàn cục.

13 SWAP còn lại dùng BASIC do read span vượt gate 100 ms
(102.5824–177.5019 ms). Cả 13 có ACK, không bỏ lượt và không dừng tool.
Giữ gate; chưa quy nguyên nhân gốc cho reader/game/UI từ khoảng đo này.
10 quyết định worker dùng R1 hoàn tất khi future chưa hoàn tất; không coi
đó là search nhiều bước đã chứng minh tối ưu. Skill/tiến hóa/PASS vẫn giữ
quyền quyết định của luồng đang chạy.

## Bằng chứng skill mới

Fresh context trước dispatch khớp board đã công bố, owner, tài nguyên và
thẻ hiện hành `MEGA_TREX_CLICK_ONLY`. Nguồn trước dùng có 270 Mana, 250 Nộ;
chi phí hiện hành 200/200. Giữ context trước click tách khỏi kết quả sau.

Phản hồi giữ được 7 effect có thứ tự và 12 resource operation:

- Hai khoản trừ trước DESTROY khớp **200 Mana + 200 Nộ**.
- Vùng DESTROY đầu gồm **30 ô đúng registry T-Rex**, khác hình Icarus.
  Có thêm một DESTROY 3 ô; không gán tag/multiplier chưa được wire liên kết.
- Ledger có 9 phép số học raw khớp, 1 cap pattern. Bốn endpoint HP/Mana/
  Nộ/Khiên khớp player context của phản hồi.
- Batch báo DAMAGE 2.760.052 khi boss trước dùng còn 1.687.896 HP. Đây là
  số báo trong batch kết trận; không suy thành công thức damage riêng của
  thẻ hoặc dùng HP mất thực tế để đo chính xác damage vượt máu còn lại.
- Có HEAL 98.406 và LIFESTEAL 138.003; chỉ phần sau có operation label
  `FUSION_LIFESTEAL`. Giữ riêng, không chứng minh T-Rex có hồi máu nội tại
  bằng việc thấy HP tăng trong batch phá viên có Máu.

**Phản hồi terminal vẫn UNBOUND:** wire không chứa card ID, post-card
terminal không đủ client-window anchor. 0 strict wire-card match, 0
conditional client-window match. Geometry/cost khớp không nâng thành bằng
chứng card ID chắc chắn. Chưa có nước sau skill khi boss còn sống, skill
lặp lại hoặc nhánh cứu nguy thực. Không fit damage/heal model.

## Artifact và kiểm tra

- [Closure](artifacts/trex_reasoning1_20261124_200614/review/closure.json).
- [10 cặp native cùng bàn và 13 fallback](artifacts/trex_reasoning1_20261124_200614/review/same_board_native_cases.json).
- [Fresh context, board và skill receipt](artifacts/trex_reasoning1_20261124_200614/review/native_skill_receipts.json).
- [Verification](artifacts/trex_reasoning1_20261124_200614/review/verification.json): kiểm hash 7 file raw, source giữ nguyên, chiếu lại đủ 10 cặp và receipt khớp.
- [Fixture gọn đủ 10 case + một skill](../../tests/fixtures/trex_native_reasoning1_20261124/cases.json), không phải holdout độc lập hoặc nhãn nước tốt nhất.

Đã đạt bài kỹ thuật giới hạn Archon → T-Rex trên boss này; không mở rộng
sang mọi Mega, route Mega chính → pet thường hoặc toàn bộ Galaxy. Không
sửa gameplay, build, commit, push hoặc tự mở trận mới khi closeout.

## Bước tiếp

Không cần lặp boss này chỉ để tăng số trận. Đã có dữ liệu native mới để
bổ sung regression lõi chung cùng [5 trận Icarus](MEGA_ICARUS_REASONING5_NATIVE_20261124.md).
Tiếp theo là Galaxy G1/G2/G3 theo account có sẵn; ưu tiên G2 để kiểm
collector và skill không phá bàn trước khi kiểm nhánh suy luận thực chạy.

Nếu sau này kiểm skill lặp lại/cứu nguy T-Rex thì chọn boss trụ được skill
mà pet vẫn sống đủ tích tài nguyên, đặt giả thuyết/cap riêng. Không yêu cầu
live lặp để tìm card ID mà client không công bố, không dùng G4 thay G1/G2/G3.
