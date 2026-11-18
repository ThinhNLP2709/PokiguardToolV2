# Adviser B16 — kiểm trực tiếp ngày 18/11/2026

**CLOSED — PASS trong phạm vi phiên source này.** User giao tự xử lý phần
còn lại, chỉ dùng computer use khi cần. Phiên đã chốt tối đa 3 BASIC + 3
REASONING, dùng hết 6 lượt thử, không mở thêm trận.

## Kết quả

Solo Lion Star lv105, Demon Aegis thường, không tiến hóa, nội tại ăn Khiên,
ngưỡng 4 Kiếm hiệu dụng, game B16. Nguồn code giữ nguyên trong cả hai nhánh:
`836a5e095ee41125708277a4abcda4da4c19368fbd5fc73fff3eff0674a66005`.

| Đo | BASIC | REASONING |
|---|---:|---:|
| Lượt thử / hoàn tất / thắng | 3 / 3 / 3 | 3 / 3 / 3 |
| Lượt của mình | 7 + 6 + 10 = 23 | 6 + 6 + 6 = 18 |
| SWAP có ACK trước khi kết trận | 20 | 15 |
| SWAP cuối có chuyển trạng thái kết trận | 3 | 3 |
| Technical abort / recovery / safe stop | 0 / 0 / 0 | 0 / 0 / 0 |
| Bỏ lượt / lỗi đọc provider | 0 / 0 | 0 / 0 |
| Nhận thưởng và về phòng bình thường | 3 | 3 |

Các SWAP cuối chuyển sang màn kết quả là terminal exclusions đã có trong
accounting, không phải lỗi kỹ thuật. Provider có chờ trạng thái ổn định trong
animation; không gộp các lần chờ này thành lượt bị bỏ.

Hai nhóm có bàn random khác nhau và chỉ 3 trận mỗi nhóm. 23 so với 18 lượt
là mô tả mẫu, chưa chứng minh tăng tỷ lệ thắng hoặc tiết kiệm năng lượng
tài khoản. Chỉ số năng lượng trên UI được suy từ lượt, không phải account delta.

## Suy luận đã thực sự điều khiển nước đi

- 18 snapshot đầu vào nguyên vẹn, 18 quyết định, 18 chuỗi ROOT/FRESH/FINAL
  đều hợp lệ. Đối chiếu match/sequence/turn/board/critical hash với input gửi.
- 11 đề xuất khác BASIC được gửi đúng; cả 11 có ACK game. 7 quyết định giữ
  BASIC. Không có source join lỗi hoặc đề xuất bị gán nhầm hành động.
- 16 quyết định hoàn tất nhìn trước; 2 quyết định hoàn tất đánh giá một bước
  khi một nhánh tương lai chưa mô hình hóa được. Đây không phải hết thời
  gian, lỗi hoặc lý do dừng farm. [Phân tích sau phiên](ADVISER_BOUNDED_FUTURE_20261118.md).
- Ví dụ trận `M_64c8a4f8`, lượt 1: BASIC định ăn Hút khi boss không có Mana;
  adviser đổi sang ăn trực tiếp 3 Kiếm, đồng thời giảm lượng Kiếm boss có thể
  ăn ngay trên các ô đã biết từ 3 xuống 0. Input thực tế khớp và có ACK.
  Không suy ra bảo đảm damage/kill hoặc dự đoán viên rơi từ ví dụ này.
- 111/111 record đã ghi và flush; không mất log. 18 job hoàn tất, 3 worker
  đã reap, cả 3 bridge và writer đã đóng sạch; không fault/late/stale.

## Hiệu chuẩn và giới hạn authority

20 SWAP BASIC có ACK mới trên đúng source đã tạo profile riêng cho phiên.
Không tái sử dụng timing game/source cũ. BASIC input sample p50 1862,329ms,
max 2482,477ms; đây là thống kê mẫu, không phải bound của toàn bộ runtime.

Qualifier gốc có policy baseline/fixture lịch sử. Runner **chỉ trong artifact**
được review cho baseline BASIC vừa thu của đúng source hiện tại, yêu cầu
zero source delta, cùng 3 AST delta của fixture đã liệt kê trong review.
14/14 gate được chạy và PASS; không sửa runtime hoặc tự đặt kết quả gate.
Receipt giữ phạm vi synthetic, không được dùng riêng thay bằng chứng live.

Profile được nạp qua CommonNativeAuthority ở data root riêng cho thử nghiệm.
Receipt live ở dưới đóng bằng chứng technical smoke cho đúng cohort này;
không sửa cờ `installed:false` / `live_acceptance:false` trong artifact
chuẩn bị ban đầu, không cài profile vào dữ liệu người dùng mặc định.
`native_U` và bound end-to-end vẫn UNKNOWN. Chưa nghiệm thu mọi lối chơi,
pet/skill, máy khác hoặc ZIP 1.3.6 đã phát hành trước thay đổi source này.

## Dữ liệu giữ lại và điểm dừng

Thu thêm 18 snapshot adviser tái hiện được. Normalizer tạo 9 quan sát damage
mỗi nhánh; 3 BASIC và 5 REASONING vượt các điều kiện quan sát hiện có.
Các mẫu còn lại bị loại/censor theo ledger/context/terminal. Chưa fit công
thức damage, không xem 8 quan sát này là 8 mẫu độc lập đủ huấn luyện.

Game đã được kiểm lại bằng read-only provider và computer use: vẫn ở phòng
Lion Star lv105, room `Coop_601898`. Tool mở ở trạng thái hoàn tất 3/3,
không còn worker gameplay. Cấu hình chính của user và source hash giữ nguyên.
Không build, bump version hoặc tự chạy thêm trận.

- [Receipt tổng và manifest](artifacts/b16_adviser_control3_20261118_075759/live_closure.json)
- [BASIC export](artifacts/b16_adviser_control3_20261118_075759/basic_export.json)
- [Đối chiếu adviser → input → ACK](artifacts/b16_adviser_control3_20261118_075759/reasoning3/native_join_review.json)
- [Snapshot mới](artifacts/b16_adviser_control3_20261118_075759/reasoning3/snapshots.json)
- [Review qualifier](artifacts/b16_adviser_control3_20261118_075759/qualification_review.json)

Bước offline tiếp theo có thể dùng 18 snapshot này bổ sung bộ replay có
provenance và phân tích các tình huống chọn Kiếm trực tiếp. Mọi thay đổi
source sau checkpoint làm profile timing của phiên này không còn khớp;
không relabel bằng chứng đã đóng hoặc tự điều chỉnh trọng số để tạo khác biệt.
