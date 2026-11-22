# Demon — kiểm trực tiếp lịch sử reader mới

Đã tự chạy và đóng **1 BASIC + 1 Suy luận**, cap2/2, tổng ledger21.
Hai trận đều WIN, nhận thưởng và về đúng phòng;0 safe stop, recovery,
PASS hoặc lỗi input. Source giữ nguyên suốt hai pha:
`7a6503d4c93cc7f0e5d552cd03604d445253ea06e58636d056b0df9dcb6bb13a`.
Không đổi gameplay, train, build, rebind timing cũ hoặc mở thêm lượt thử.

## Phạm vi phiên

B17, Solo Priest lv131/ID1845, Demon Aegis thường ID560, ăn Khiên,
ngưỡng4 Kiếm hiệu dụng, không tiến hóa; room `Coop_863866`.
Account alias/pet/boss được kiểm read-only; computer-use đóng hai popup
nhắc sức khỏe ngoài trận, vào phòng, đóng UI cũ và bấm Bắt đầu từng pha.
Launcher không tự start. Ordinary preferences giữ nguyên.

Thông số quan sát ở nước đầu hai pha khớp: ta HP tối đa109491, Mana2771,
Nộ250, Attack1819; boss581505/540/250/766. Full gear UNKNOWN, không tuyên
bố đã đối chiếu toàn bộ trang bị. Không mở rộng nghiệm thu sang target
khác Khiên, Mega, Galaxy hoặc input family khác.

| Pha | Match / run | Kết quả |
|---|---|---|
| BASIC | `M_d9edcf8b` / `24c18af947c44b528ae0c8f90ee0ac1e` | WIN,8 lượt ta/7 boss,7 ACK +1 terminal |
| Suy luận | `M_1d67187c` / `45cf6013b7be444eaf3903351bf214ea` | WIN,5 lượt ta/4 boss,4 ACK +1 terminal |

Qualification mới14 gate PASS. BASIC có8 timing record,7 ACK đủ điều
kiện; profile riêng đúng source/build/host, max1 R, không cài vào prefs
thường. R có5 decision/15 checkpoint hợp lệ, replay5/5,4 nước cùng BASIC
và1 nước khác;31 diagnostic record ghi đủ, worker1/1 reaped. Summary lớn
nhất11851/12000 byte. Nước cuối mỗi pha kết thúc bằng terminal boss HP0,
không được tính thành ACK thông thường. ToolPID16112 đã dừng đủ1/1 và
đã quan sát UI hoàn tất. Cap hiện tại không còn lượt.

Số lượt8 và5 thuộc hai bàn khác nhau; không dùng chúng, WIN, override
count hoặc utility nội bộ làm nhãn Suy luận tốt hơn.

## Lịch sử mới đã giữ được gì

| Metadata native | BASIC | Suy luận |
|---|---:|---:|
| Completed reads | 59008 | 37653 |
| Lỗi đọc đã đếm / lỗi giữ riêng | 7/7 | 3/3 |
| Root membership giữ riêng | 152 | 99 |
| Event bị đẩy khỏi ring128 cũ | 239 | 117 |
| Event giữ thêm trước phần ring cũ còn lại | 102 | 50 |
| Bị bỏ khỏi hai nhóm giữ riêng | 0 | 0 |

Tổng giữ thêm152 mốc trước legacy tail; metadata mới không fault, không
thấy shared-DTO case. Các nhóm giữ riêng chưa chạm giới hạn256 root/32
error trong phiên này; nhánh vượt giới hạn đã được kiểm synthetic.
Đây là nghiệm thu có phạm vi cho metadata và binding, không phải lịch sử
liên tục mọi read hoặc chứng nhận thu đủ response server.

Giữ22 observation có reader binding, gồm21 typed response được chuẩn
hóa đầy đủ và1 UNAVAILABLE. R đủ typed effect cho4/4 ACK. BASIC thiếu ở
3/7 ACK: response4 có `COMBAT_STEPS_ABSENT`, response8/24 không có scoped
observation. Không normalization loss hoặc capture/trace fault. Các root
trong cửa sổ gửi–ACK đã giữ được vẫn không có content identity để gán
chắc chắn cho response thiếu; nguyên nhân hai khoảng không quan sát được
vẫn UNKNOWN. Không khôi phục hoặc tự điền effect.

## Một nước thực đáp ứng chủ trương Demon

Lượt3 R, snapshot `13f840ab…`: ta HP81993/109491, Mana180, Nộ85;
boss HP465204/581505, Mana180, Nộ5, Khiên0. Cùng bàn/facts/cài đặt:

| Phần tính được trước hành động | BASIC | Suy luận |
|---|---:|---:|
| Kiếm | 0 | 2 |
| Nộ | 3 | 3 |
| Hút | 3 | 5 |
| Mana | 0 | 4 |
| Máu / Khiên | 0/0 | 5/5 |
| Ô refill chưa biết | 6 | 24 |

Suy luận chọn quét nội tại thay nước Nộ/Hút của BASIC. Projection R là
first wave có điều kiện theo geometry đã khai báo, projection BASIC có
known cascades; độ phủ và24 ô refill khiến bộ đối chiếu xếp
`INSUFFICIENT_DATA`, không gán nhãn hơn hẳn. Khả năng boss ăn Kiếm đã biết
đều0; không suy thành an toàn sau refill.

Nước được chọn có exact sent–ACK, immutable response8 và published
endpoint cùng session. Kết quả thực của riêng nhánh này:

- Boss HP465204→388806, giảm **76398**; response ghi DAMAGE76398,
  `full_power=true`, không bị censored bởi kill.
- Ta HP81993→86359, tăng ròng4366; log có HEAL4548 và một STAT_CHANGE
  HP−182, chưa gán cơ chế cho khoản−182.
- Mana180→300, Khiên0→4548; boss Nộ5→0.
- Nộ ta được ghi theo thứ tự85→145→150→50: +60, +5 và−100 FULL_POWER.
  Số dư cuối giảm35 dù thu được Nộ trong đợt quét.

Đây là mẫu thực hữu ích của2 Kiếm cùng tài nguyên trong một đợt quét,
không phải công thức damage, luật thứ tự Nộ chung hoặc outcome của nhánh
BASIC giả định. Chưa fit model hoặc đưa after-values trở lại decision.

## Phần offline còn mở

BASIC có một queue event UNAVAILABLE không mang sequence/raw hash khi
`evidence=null`. Summary metadata giữ một candidate tương ứng response4,
cùng lý do COMBAT_STEPS_ABSENT và gần thời điểm decode. Event chính chưa
có khóa exact để exporter tự gắn; hiện normalizer giữ fail-closed và loại
cả7 boss interval BASIC. R giữ được4 boss interval; audit tài nguyên giữ
7 khoảng/32 delta exact và20 lastStat khớp endpoint. Không sửa source
hoặc override exporter giữa hai pha để lấy thêm số liệu.

Việc kế tiếp: offline giữ/ghép identity của bản ghi UNAVAILABLE để chỉ
loại đúng phạm vi có chứng cứ, rồi khai thác net resource và mẫu quét
Demon đã bind. Giữ response thiếu là UNKNOWN; chưa cần mở thêm cap để
bù việc exporter. Mega/Galaxy tiếp tục hoãn.

[Đóng cap2/2](artifacts/demon_retention_native_20261120/closure.json) ·
[Lịch sử giữ riêng](artifacts/demon_retention_native_20261120/protected_history_review.json) ·
[Cặp cùng bàn và outcome thực](artifacts/demon_retention_native_20261120/selected_outcome_review.json) ·
[Bản ghi UNAVAILABLE chưa có identity](artifacts/demon_retention_native_20261120/basic_unscoped_outcome_review.json).
