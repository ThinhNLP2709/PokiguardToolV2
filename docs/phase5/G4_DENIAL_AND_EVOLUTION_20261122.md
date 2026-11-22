# G4 — sửa ưu tiên Kiếm và thêm hai route tiến hóa

User xác nhận trận thua vì boss mạnh đánh chết, đồng thời yêu cầu G4 đánh từ
nền BASIC, kiếm combo kích hoạt nội tại nhưng tránh chừa Kiếm cho boss.

Đối chiếu11 bàn trước nước đi của trận Raijin518 `M_babb86a4` cho thấy lỗi
chiến thuật rõ ràng:6 nước BASIC G4 cũ chừa phản hồi3–4 Kiếm dù cùng bàn có
nước chừa0 Kiếm đã biết. Tại lượt1, tool chọn9 combo/chừa3 Kiếm, bỏ qua nước
ăn3 Kiếm, tổng6 combo/chừa0 Kiếm. Tại lượt3 và11, nó còn ưu tiên combo chưa
đủ mốc9 hơn việc giảm phản hồi Kiếm. Nhánh Suy luận cũ vẫn mắc ưu tiên này ở
3/11 bàn khi chưa vào nhánh bảo vệ. Đây là lỗi xếp hạng của G4; luồng gửi nước
và nhận ACK trong trận vẫn11/11, không safe stop hoặc bỏ lượt.

Sức mạnh boss và lựa chọn nước cùng ảnh hưởng khả năng thắng. Không quy toàn
bộ trận thua cho6 quyết định này hoặc suy HP chắc chắn giữ được nếu đổi nước:
bàn sau khi đi khác sẽ có refill và phản hồi khác. Snapshot cuối có thể đứng
trước đòn cuối của boss; kết quả LOSS được xác nhận bởi game/UI và user.

## Cách chọn nước mới

1. Dùng solver hiện có duyệt nước hợp lệ và phản hồi Kiếm trực tiếp/cascade.
2. Lọc nhóm có phản hồi Kiếm hiệu dụng nhỏ nhất. Nếu có nước chừa0 thì combo,
   hồi máu và setup đều chỉ được chọn trong nhóm này. Nếu mọi nước chừa Kiếm,
   vẫn chọn mức ít nhất rồi đánh; không dừng tool vì rủi ro.
3. Trong nhóm đó, nếu đủ mốc nội tại, chọn mốc cao nhất9–13. Cùng mốc xét Kiếm
   của ta, máu cần ăn và các rủi ro còn lại. Vẫn cộng x1…x7 và cascade.
4. Chưa có mốc thì ưu tiên nước ăn Kiếm bằng chính `_sword_rank` của BASIC.
   Không lấy combo6–8 của viên khác để bỏ qua nước Kiếm phù hợp. Nếu không có
   Kiếm, tiếp tục chọn tài nguyên/combo; trước khi có G4, ưu tiên Mana cho tiến hóa.
5. Suy luận thêm nhánh hồi máu/nội tại hút máu theo HP/Nộ thực tế và setup có
   giới hạn. Setup không được bỏ qua nước Kiếm hiện tại hoặc chừa thêm Kiếm
   đã biết cho boss. Không dùng mô hình damage chưa được xác minh để đánh cược
   một combo sẽ kết liễu hoặc cứu sống chắc chắn.

“0 Kiếm” ở đây là phần bàn xác định được, không là cam kết về viên mới do
server refill hoặc boss dùng skill. Không đổi luật PASS, input, timer, ACK,
memory reader hoặc solver match/collapse.

## Route và UI

| Pet chính | Tiến hóa | Trạng thái nội tại |
|---|---|---|
| G4/Galaxy | Không | Có từ đầu |
| G4/Galaxy | Pet thường | Có từ đầu; tiến hóa bổ sung chỉ số |
| Pet thường | Galaxy G4 | Đánh Kiếm/Mana trước; chỉ tính nội tại sau `FusionState.used=True` |

Dùng Step1 tiến hóa sẵn có: phải đọc được pet tiến hóa đã chọn, khả năng bấm,
slot và chi phí Mana dương từ game; đủ điều kiện mới đề xuất EVOLVE bằng input
bình thường. Thành công phải đọc lại state trước khi chọn nước tiếp. Không
đoán chi phí, không gán chỉ số cộng thêm, không coi lần thử thất bại là đã có G4.
Vẫn cần chọn đúng pet thường/G4 trong game; cài đặt chỉ mô tả route.

Đã bỏ cả dòng **Kích hoạt nội tại**, dropdown và ô ngưỡng khỏi UI G4. Nội tại
là mặc định của lối chơi. Giá trị `auto_combo` được giữ nội bộ để tương thích
preferences/checkpoint cũ. Đổi sang lối chơi khác khôi phục trường của lối đó.

Với Raijin518 hiện tại, đề xuất **G4 + Suy luận, G4 chính + tiến hóa pet thường**
để bổ sung chỉ số từ pet người dùng chọn và giảm cơ hội Kiếm cho boss. Chưa có
dữ liệu so hai route trên cùng cấu hình, nên không tuyên bố route nào chắc
thắng hoặc cộng được bao nhiêu HP/ATK. Route pet thường →G4 cũng sẵn sàng kiểm.

## Kiểm chứng

- Cùng11 bàn native trước nước đi: BASIC cũ chừa Kiếm ở6 bàn, R cũ ở3 bàn;
  source mới chọn0 phản hồi Kiếm đã biết trên cả11 bàn ở cả hai chế độ.
  Các cơ hội nội tại không chừa Kiếm ở lượt15/17/21 vẫn được giữ.
- 31 test G4, gồm regression trận thua, x1…x7/cascade, all-risky vẫn đi,
  hai route tiến hóa, thiếu cost/fusion, trước/sau thành công, không cast thẻ
  chủ động, UI ẩn trường mặc định và khôi phục trường của style khác.
- **406 test CI offline PASS**, **142 test liên quan PASS**. 243 tình huống
  style cũ so main vẫn giống nhau, chỉ loại trường chẩn đoán mới `g4_combo=None`.
- Không mở thêm trận, không build/version/commit/push. Đã đóng sạch cửa sổ thử
  cũ để tránh dùng lẫn source; game không bị đóng. Hai route mới và source
  sửa ưu tiên chưa được kiểm live.

[Trước sửa](artifacts/g4_denial_routes_20261122/before_audit.json),
[cùng bàn sau sửa](artifacts/g4_denial_routes_20261122/after_audit.json),
[kiểm tra/source](artifacts/g4_denial_routes_20261122/verification.json).
