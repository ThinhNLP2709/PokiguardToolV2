# Chuẩn hóa quan sát combat — 18/11/2026

Đã đối chiếu hai trận BASIC đã lưu, không chạy thêm trận hoặc gắn vào game.
`tools/normalize_combat_observations.py` dùng lại geometry Demon và bộ đếm
multiplier hiện có. Đầu ra là quan sát các nước đã đi, chưa phải model damage.

## Kết quả native

| Boss/lượt nguồn | Kiếm thật | Kiếm hiệu dụng | Server ghi | Damage vào HP | Bị khiên chặn | Nộ trước + cộng trước damage → sau |
|---|---:|---:|---:|---:|---:|---|
| Lion Star105/9 |4|5|5|164256|870|75 +100 →175|
| Lion Star105/11 |6|7|7|227493|3451|110 +120 →230|

Cả sáu loại viên của mỗi vùng quét đều khớp ledger **hiệu dụng** ở first wave,
không khớp ledger số ô thật. Có x2 Kiếm ở cả hai, x3 Mana và x4 Máu ở mẫu sau.
Đây là bằng chứng trên hai nước Demon ăn Khiên B16, chưa suy rộng wire semantics
cho mọi pet, card hoặc wave. Không cộng tín dụng từ viên refill chưa biết.

Hai mẫu có ACK đúng identity, giảm HP và từng bước giảm khiên đều khớp.
`POWER` xuất hiện trước `DAMAGE`, nhưng `fullPower=true` ở Nộ175/230 trên
max250 **không chứng minh một ngưỡng kích hoạt chung**. `dmgSrc` vẫn null.

Tổng HP damage + BLOCK lần lượt165126 và230944; chia cho5/7 Kiếm hiệu dụng
ra33025,2 và32992. Đây chỉ là tỷ số mô tả hai quan sát, không được cài thành
hằng số damage/Kiếm, khoảng dự đoán hay lời hứa kết liễu. Chưa xác minh đủ
pet/loadout, khắc hệ, crit/buff, đầy đủ hiệu ứng của action hoặc sai số ngoài mẫu.

Lieyun77 có batch damage127330 nhưng HP trước82224, HP sau0 và không có SWAP
ACK vì kết trận. Giữ record để kiểm collector, loại khỏi mẫu so sánh không
terminal; không lấy HP bị cắt ở0 để học damage. Lion Star còn5 nước không
kích hoạt Demon và1 nước cuối thiếu outcome; ghi rõ lý do, không bù bằng WIN.

## Attribution và ranh giới

- Chỉ ghép một response duy nhất trong cửa sổ giữa hai `action_sent`, đúng
  match/actor và khoảng srvSeq; ACK phải trùng toàn bộ action identity.
  Không có echo tọa độ wire ở các record native này, nên không gọi đây là
  xác nhận tọa độ từ chính response. Hash bàn cờ nguồn chỉ đối chiếu giữa
  hai trường đã ghi, không tái tạo hash raw tag từ gem đã chuẩn hóa.
- Duplicate giống nhau không tăng mẫu. Callback xung đột, sequence đảo,
  không ACK, sai ledger, thiếu HP/after/index, terminal và loại viên không
  biết không được tạo tỷ số dùng so sánh.
- HP của lượt ta kế tiếp không thay cho `after.HP` cùng batch: ở trận này
  HP boss đã đổi trong khoảng lượt boss mà các step đã thu chưa giải thích đủ.
- `usable_observation` chỉ cho phép so sánh **cùng batch** theo các kiểm tra
  trên; mọi record vẫn `calibration_eligible=false`, `input_authority=false`.
  Không thay scorer, BASIC, PASS, QTE, reader, executor hay farm.

## Kiểm chứng và tái chạy

[Đầu ra với SHA từng combat/line](artifacts/combat_normalization_20261118/observations.json):
3 record,2 dùng được cho so sánh không terminal,1 bị censor;6 nước còn lại
có lý do loại. Fixture test đã thay actor/match/pointer, không giả rằng hash
payload gốc còn chứng thực bản fixture đã sửa.

85 kiểm tra liên quan PASS, gồm18 kiểm tra chuẩn hóa mới, collector, geometry,
5 viên mục tiêu, multiplier và adviser setup.
[Log](artifacts/combat_normalization_20261118/focused_tests.log).

```powershell
python -B tools/normalize_combat_observations.py --combat <combat.jsonl> --out temp/reasoning/normalized-new.json
python -B -m unittest tests.test_combat_observation_normalization
```

Tool không overwrite output đã có. Phần này chỉ thêm công cụ phân tích/test;
ZIP1.3.6 cũ chưa có collector và chưa được build lại. Bước tiếp theo có thể
làm offline là đánh giá chất lượng lựa chọn của adviser trên các trạng thái
đã lưu; chưa dùng hai tỷ số trên để sửa score hoặc gỡ gate damage.
