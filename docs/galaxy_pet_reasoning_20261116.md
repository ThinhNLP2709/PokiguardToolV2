# Suy luận theo từng Galaxy — 16/11/2026

## Nhận đúng pet và mô tả skill

Nhận pet từ **type của CardUI đang sở hữu trong đúng session**, không dựa vào
dropdown `main_pet=galaxy` hoặc pet ID cố định:

| Pet | Type đã xác minh | Cơ chế được đưa vào chiến thuật |
| --- | --- | --- |
| G1 Galaxy Risky | `GALAXY_RICKY` | Bài ngẫu nhiên, chu kỳ lần thứ tư gây x2 |
| G2 Galaxy Glank | `GALAXY_2` | Giữ khiên có hệ số nhân, cân nhắc bảo vệ/setup đã triển khai |
| G3 Galaxy Dragon Knight | `GALAXY_DRAGON_KNIGHT` | Chuỗi 1→2→3 và phần hồi tài nguyên khác nhau |

Ảnh người dùng cung cấp được đối chiếu toàn văn với `PetUserDTO.cardDTO`
trong hai log skill của `M_0faec392` và `M_fefb8547`. Phần G3 bị khuất trong
ảnh đã được đọc đủ từ log. Văn bản và hash log nguồn được giữ ở
`tests/fixtures/galaxy_profiles_20261116/descriptions.json`.

## G1 Risky

- Đủ chi phí thật và CardUI actionable thì ra skill ngay.
- Ghi rõ ba khả năng: Xanh hồi 500 mana; Đỏ hồi 200 nộ và hút máu theo 5%
  sát thương; Vàng gây tê liệt một lượt. Không giả định xác suất bằng nhau,
  không biết trước lá bài và không ghi nhận hồi máu/tê liệt bảo đảm.
- Nhận lần thứ tư từ phase hiện hành nếu game có công bố đúng card/max=4.
  Khi không có, chỉ ước lượng chu kỳ từ lịch sử skill của tool nếu đã quan
  sát đầu trận, nguồn thẻ không đổi và lịch sử đúng session. Ghi rõ đây là
  `TOOL_HISTORY_ESTIMATE_FROM_OBSERVED_OPENING`, không phải bộ đếm server.
- Lần thứ tư đã được nhận diện có thể ưu tiên tích tài nguyên thêm một mức
  khi HP trên 40% (thường là trên 50%), chưa chạm ngưỡng Tự bảo vệ và áp lực
  kiếm danh nghĩa của nước đó dưới 15% HP hiện tại. Đây là tham chiếu chiến
  thuật, không chứng minh nước đó không thể chết hoặc skill sẽ kết liễu.
- Giữ nộ cho skill; khi skill chưa sẵn sàng vẫn áp dụng Health/Shield/Drain
  theo lựa chọn Tự bảo vệ. Kiếm chỉ được mở khi nộ bằng đúng 0.

## G3 Dragon Knight

| Chiêu | Mô tả đã đọc | Hồi sau skill theo mô tả | Ưu tiên khi tích tài nguyên |
| --- | --- | --- | --- |
| 1 | ×170, đặt ấn ghi sát thương chính mình gây; chặn hút 2 lượt | 250 mana | Thường ưu tiên nộ cho vòng tiếp |
| 2 | ×125 và vọng 30% sát thương ấn, tiếp tục ghi ấn | 150 nộ | Thường ưu tiên mana cho vòng tiếp |
| 3 | ×100 và nổ 42% sát thương ấn | 150 mana + 50 nộ | Cân bằng hai thiếu hụt, thường thiếu nộ hơn |

Nước nào hoàn tất chi phí **skill hiện tại** vẫn được ưu tiên trước. Chỉ khi
hai nước tích tài nguyên ngang nhau, phần hồi theo pha được dùng để so sánh
nút thắt mana/nộ của vòng tiếp theo. Mọi dự báo đều là điều kiện “tiêu chi
phí rồi hồi theo mô tả”, không cộng trước vào tài nguyên hiện hành. Đủ là ra
skill, không chờ kiếm/khiên hoặc cố bơm sát thương vào ấn bằng nước ăn kiếm.

`stored_mark_damage` và thời hạn chặn hút thật vẫn UNKNOWN. Không lấy chênh
lệch HP boss làm sát thương ấn của riêng mình; không coi buff 2 lượt là còn
hiệu lực chỉ vì đã bấm chiêu 1. Không dùng ×170/125/100 để suy ra sát thương
HP hoặc chứng nhận kill khi chưa biết đầy đủ công thức server.

## Đọc pha có nguồn xác minh

Reverse B15 và native `MatchService.TryGetLocalSkillPhase` (RVA `0xACE810`)
xác nhận `MatchService.Players +0x118` là map username → `MatchPlayerSnapshotDTO`:

| Trường DTO | Offset |
| --- | --- |
| `actorNumber` | `+0x18` |
| `skillPhaseNext` | `+0x15C` |
| `skillPhaseMax` | `+0x17C` |
| `skillPhaseCardId` | `+0x180` |

G3 `DragonKnightPhaseBar.LateUpdate` (RVA `0x996720`) cũng đọc phase/max
từ map này. Chỉ đọc bộ nhớ, không gọi các method trên. Layout đối chiếu file
B15 SHA-256 `18bc4398635afaaaa3f4eb5d9a2c35554cfd81a5595b1875cbe449beba777bea`.

Decoder dùng map ownership hiện có, yêu cầu đúng username/actor/card ID,
kiểm header/root map và đọc lặp lại DTO. Provider kiểm lại Board/Active,
MatchService, match/turn/current player/session sau đọc. Không dùng giá trị
clamp mặc định của UI để đoán pha 1. Card ID không khớp, dữ liệu đổi hoặc
pha ngoài khoảng: không công bố pha. Dữ liệu pha bị lỗi không làm mất các
kiểm chi phí/permission độc lập của skill hiện hành; chỉ bỏ dự báo theo pha.

Runtime phase đúng card/max=3 hoặc 4 được ưu tiên hơn lịch sử tool. Nếu thiếu
cả runtime phase và lịch sử đầy đủ, pha UNKNOWN, không nhận phần hồi nào là
bảo đảm để xếp hạng vòng sau. Đổi pet giữa trận không dùng chung bộ đếm.

## Triển khai và kiểm chứng

- `galaxy_profiles.py`: khai báo G1/G2/G3 cùng nguồn nhận diện.
- `galaxy_cycle.py`: so sánh tài nguyên G1/G3, pha và mức tin cậy lịch sử.
- `galaxy_skill_phase.py`: decoder read-only; capability mang phase hiện hành.
- Basic giữ nguyên khi tắt Suy luận. G2 giữ các quy tắc đã triển khai; chỉ
  thêm nhãn nhận diện. UI thông báo Suy luận Galaxy có nhánh riêng G1/G2/G3.
- Vẫn dùng solver, fresh preflight, turn/timer, chuột/lease, ACK và click-only
  hiện có. Không thêm game input, network hay game-method invocation mới.

**638 kiểm thử đạt**: nhóm hồi quy 636 ca và thêm hai ca controller. Các ca
mới kiểm nguồn thẻ, G1 ngẫu nhiên/lần thứ tư, G3 ba pha, không ứng tài nguyên
hồi, dữ liệu pha sai/stale, ownership đổi trong lúc đọc, pha đổi ở fresh
reread làm hủy nước cũ, rồi input và ACK bình thường. Hai snapshot G1/G3
đã thắng trước đó vẫn chọn PET_SKILL ngay khi ready. G2 tiếp tục qua replay.

Log và native disassembly:
`temp/galaxy_pet_reasoning_20261116/`. Chưa kiểm thử trận live mới hoặc xác
nhận runtime phase trên trận thật sau sửa. Đây là nâng cấp source, không tạo
gói EXE mới; cần mở lại tool để nạp code. Các kiểm thử proof lịch sử đã lỗi
từ trước không được sửa hoặc bỏ chốt calibration trong đợt này.
