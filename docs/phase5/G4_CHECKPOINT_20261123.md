# Chốt G4 — checkpoint local ngày23/11/2026

Người dùng đã kiểm và yêu cầu chốt G4, commit toàn bộ thay đổi, **chưa push**.
Checkpoint này đóng công việc gameplay G4 hiện tại; không mở thêm live, không
nâng version hoặc build. Bản portable đang phát hành chưa được thay bằng source
mới trong checkpoint này.

## Phạm vi đã chốt

- Lối chơi riêng **G4 Combo (Shadow Sword)**, hỗ trợ Cơ bản và Suy luận.
- Nội tại đếm tổng viên hiệu dụng x1…x7 trong một nước, gồm cascade. Mốc9–13
  theo mô tả; không cần bấm thẻ, không gán Mana/Nộ như chi phí cast.
- Không tiến hóa: tìm combo nội tại, bảo vệ và giảm Kiếm chừa cho boss. Không
  bắt buộc ưu tiên Kiếm nếu nước khác phù hợp mục tiêu hơn.
- Pet thường→G4 và G4→pet thường: ưu tiên Mana và tiến hóa theo cấu hình;
  sau thành công quay lại mục tiêu combo. G4 ở slot tiến hóa chỉ được tính nội
  tại sau khi game xác nhận tiến hóa thành công.
- Ẩn điều kiện kích hoạt nội tại vì đây là lối chơi dành riêng cho G4.
- Kiến thức skill/tự bơm Mana/Nộ của boss được dùng chung cho bộ Suy luận,
  gồm G1/G2/G3/G4 và8 profile common. Không coi0 Kiếm là chứng minh an toàn.

## Kiểm offline và live

Source được kiểm: `4214675b494b9e789022e186e656c7a6d1bbae34a1b4522112feb9366df987fb`,
513 Python files. 429 focused CI tests PASS;88 targeted tests PASS (có phần
trùng với CI).216 ca BASIC lịch sử exact parity;27 ca Galaxy R chỉ thêm
diagnostic, hành động giữ nguyên. Xem [báo cáo chung](SHARED_BOSS_THREAT_20261123.md).

Sau khi tool được mở, người dùng tự khởi tạo3 run độc lập, mỗi run1 trận.
Hai run sau đổi cấu hình tiến hóa trong UI; không gán cả3 thành bài không
tiến hóa chỉ vì tên thư mục chứa `no_evolution`.

| Cấu hình thực tế | Run / match | Kết quả |
|---|---|---|
| G4, không tiến hóa | `ebb3ac75b13a4c5fa3f1706cd303ee28` / `M_e34ec8b6` | LOSS;9SWAP/9ACK; combat kết thúc đúng lifecycle; lỗi màn sau trận ghi bên dưới |
| Pet thường→G4 | `6a9c7553991a4b449db6f16f2875577d` / `M_bd08f1d0` | WIN1/1, nhận thưởng/về lobby;4 lần tiến hóa gồm3 thất bại+1 thành công |
| G4→pet thường | `df91014d95a04ad3aa025409b219e991` / `M_67fe861c` | WIN1/1, nhận thưởng/về lobby; tiến hóa thành công1/1 |

Cả3 gặp Raijin, boss có maxHP40.655.221 ở snapshot đầu. Hai route tiến hóa
đổi goal từ EVOLUTION sang PASSIVE_COMBO sau thành công. Route pet thường→G4
đổi passive_active từfalse sangtrue; route G4 chính giữtrue. Đây là bằng chứng
chức năng trong các run đã thu, không là chứng minh tối ưu hoặc tỉ lệ thắng
trên mọi boss/pet/trang bị.

Hai trận WIN ghi lần lượt22SWAP/21ACK và21SWAP/20ACK; mỗi trận có1 swap bị hủy
do lifecycle kết thúc. Không đổi những số này thành tuyên bố toàn bộ swap ACK.
Không có PASS, timeout ACK, recovery hoặc policy_no_safe_move trong3 trận.

## Lỗi còn mở ngoài gameplay G4

Run không tiến hóa hoàn thành trận LOSS nhưng farm dừng tại WAIT_BOSS_LOBBY
với **POSTMATCH_UI_AMBIGUOUS**. Sau30 giây/31 mẫu, bộ nhận diện không tìm được
duy nhất panel kết quả hoặc banner/nút xác nhận phù hợp. Đây là lỗi luồng nhận
diện sau trận còn cần xử lý riêng; không phải quyết định G4 ngừng đánh giữa
trận, và không được ghi checkpoint này là đã sửa xong lỗi đó.

Hai trận tiến hóa không gặp lỗi này và kết thúc FARM_TARGET_COMPLETED. Tổng
G4 hiện có5 trận hoàn thành trên các source lịch sử:2WIN/3LOSS.42 trận Demon
đã đóng giữ nguyên. Không có live/run đang hoạt động; không tự mở thêm bài test.

Các log/ảnh và manifest hash được giữ local theo `.gitignore` tại
`docs/phase5/artifacts/g4_no_evolution_shared_threat_20261123/closure_user_checkpoint.json`.
Source, tests, fixtures tối thiểu và tài liệu được commit; không ép đưa thư mục
runtime, build hoặc scratch vào Git. Các nghiệm thu source cũ giữ đúng phạm vi.
