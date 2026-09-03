# Phase 3A.1 — Runbook quan sát Pet Skill/QTE bằng tay

Observer **chỉ đọc RAM**. Nó không click thẻ, không nhấn hướng, không nhấn Space,
không đánh board và không gọi method/network của game.

**Trạng thái:** acceptance đã hoàn tất **PASS STRONG**. Các bước dưới đây chỉ để
replay diagnostics nếu một build game sau này cần xác minh lại; không cần chạy lại
cho Phase 3A.1 hiện tại.

## Final closure retry sau live 20260904_000854 — COMPLETED

B1/B2 và phần lớn B3/B4 đã có evidence. Retry cuối chỉ cần **một QTE tự nhiên** để
observer mới đọc trực tiếp chữ `PERFECT!/GOOD!/BAD` từ Unity Text và tự correlate
generic `MATCH_SKILL_USE_RES` của bản 1.7.4. Không cố tạo BAD và không cần lặp ba
kiểu phím nữa.

Lệnh đã dùng từ boss lobby:

```powershell
python tools/pet_qte_observer.py --watch --qtes 1 --timeout 1800
```

Kết quả `phase3a1_pet_qte_20260904_003250.jsonl`: observer ghi `qte_closed` và tự
dừng; native prediction, raw RAM text và visual operator đều `PERFECT!`. Resource
delta là mana/power `-200/-200`, turn vẫn thuộc local. Không cần repeat.

## Chuẩn bị

1. Dùng pet Legendary cần nghiên cứu làm pet chính và vào đúng **boss lobby**.
2. Không nhấn `Start` trên tool farm; lần test này chơi hoàn toàn bằng tay để tránh
   hai controller cùng có quyền thao tác.
3. Giữ game mở. Observer đọc memory nên game không bắt buộc foreground, nhưng khi
   làm QTE bạn phải tự đưa game lên foreground.
4. Mở PowerShell tại `D:\PokiguardToolV2` và chạy:

```powershell
python tools/pet_qte_observer.py --watch --qtes 3
```

Chờ thấy:

```text
Phase 3A.1 observer READ-ONLY
NO INPUT: perform every Pet Skill/QTE action manually.
```

Mặc định observer phải khởi động từ lobby để có inactive baseline. Không dùng
`--allow-combat-start` cho acceptance chính.

## B1 — Xác định pet và card

1. Vào một trận bằng tay. Pet nguồn có thể là pet thường và chưa có skill.
2. Chơi tay để tích tài nguyên rồi tiến hóa pet Legendary cần quan sát. Observer
   tiếp tục theo dõi khi `Active.playerPets` vẫn là pet nguồn và phải ghi thẻ
   Legendary ngay khi card runtime xuất hiện sau tiến hóa.
3. Không cần cố đạt con số 200 Mana/150 Power nếu
   card runtime cho con số khác.
4. Sau khi thẻ skill sáng, chờ khoảng một giây rồi mới bấm Pet Skill lần đầu để
   observer có một snapshot identity trước QTE.

Observer sẽ ghi `evolved_skill_card_available` hoặc `active_qte_skill_identity`
gồm exact runtime `skillCardId`, full `CardData`, mana/power hiện tại và source
pet nếu có. Source pet không có skill là hợp lệ và không chặn quan sát.

## B2/B3 — QTE thủ công

Ưu tiên ba activation tự nhiên; nếu quá tốn tài nguyên thì 1–2 trace chất lượng
cao vẫn dùng được.

- QTE 1: nhập đúng chuỗi hiển thị bằng **các phím mũi tên**, confirm bằng **Space**.
- QTE 2: nhập đúng chuỗi bằng **W/A/S/D**, confirm bằng **Enter**.
- QTE 3: dùng cách thuận tay, cố confirm tại vùng PERFECT như chơi bình thường.

Không cố tạo BAD. Không spam confirm. Mỗi QTE chỉ confirm một lần. Nếu skill kết
thúc trận, ghi nhớ trường hợp đó vì terminal có thể che transition lượt bình thường.

Observer sẽ ghi từng thay đổi `currentIndex`, `correctCount`, `qtePresses`, timer,
sequence server và kết quả dự đoán. Sau confirm nó mới quét DTO response; việc quét
này có thể tạo một khoảng im lặng ngắn nhưng không gửi input.

## B4 — Resource và lượt

Ít nhất một activation nên **không kết thúc trận**. Sau skill:

1. Không bấm thêm ngay trong vài giây để observer bắt resource/turn after-state.
2. Quan sát xem quyền đi chuyển sang boss hay bạn vẫn được đi; chỉ báo lại điều bạn
   thực sự thấy.
3. Tiếp tục chơi tay hoặc kết thúc an toàn.

Khi đủ số QTE correlated, observer tự dừng. Nếu chỉ làm được ít hơn, nhấn
`Ctrl+C`; log vẫn được flush theo từng event.

## Thông tin cần báo lại

Sau test, nhắn theo mẫu ngắn:

```text
Đã xong Phase 3A.1 live.
QTE 1: Arrow + Space, kết quả thấy trên game = ...
QTE 2: WASD + Enter, kết quả thấy trên game = ...
QTE 3: ..., kết quả = ...
Skill có/không kết thúc trận; sau skill lượt thuộc về ...
Hiện đang ở ...
```

Không cần tự tìm log; observer in đường dẫn `phase3a1_pet_qte_*.jsonl`, tôi sẽ đọc
và đối chiếu.

## Dừng/fail closed

- Nếu game mất kết nối, QTE không xuất hiện, sequence nhìn không khớp hoặc observer
  báo lỗi: không cố spam phím; dừng bằng `Ctrl+C` rồi báo trạng thái.
- Không bật auto farm trong cùng acceptance này.
- Không sửa `pc`, không attach quyền ghi, không chạy tool injection/hook.
