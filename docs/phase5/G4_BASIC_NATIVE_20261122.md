# G4 BASIC — kiểm trực tiếp đầu tiên, 22/11/2026

Account G4, Galaxy Shadow Sword cấp14; Solo Raijin cấp518, phòng
`Coop_165037`. Source `32531478385b93083959fb962f6c277fde5f6cbc1803187cafeb55fb11dbec56`.
User báo đã vào phòng và chọn G4. Phiên mới giới hạn1 trận Cơ bản; không mở
lại42 lượt Demon đã đóng. Suy luận chưa chạy live trong bài này.

Kết quả chức năng đạt:1/1 hoàn thành, game xác nhận **LOSS**, tool xử lý màn
thua và trở lại đúng phòng. Có11 SWAP gửi/11 ACK, không PASS, không cast hoặc
tiến hóa, không safe stop, không lỗi đọc, không hồi phục kỹ thuật. FarmRunner
dừng `FARM_TARGET_COMPLETED`; controller con dừng `COMBAT_LIFECYCLE_ENDED`.
`postmatch_observation_timeout` của controller con không làm hỏng luồng kết
trận: controller farm cha nhận kết quả LOSS từ memory và UI, bấm xác nhận và
về lobby. Không suy thua là do thiếu HP từ snapshot cuối: snapshot có thể
đứng trước hiệu ứng cuối của boss; bằng chứng kết quả là `MATCH_GAME_OVER`
với winner=`__BOSS__` và UI “Thua”.

Đã có witness hệ số trên bàn native: lượt21, **3 ô →12 viên hiệu dụng →mốc12**,
không có cascade trong nước này. Lượt17 có6 ô →12 hiệu dụng, gồm4 trực tiếp
và8 từ cascade. Bản log giữ riêng số ô và tổng hệ số. Quan sát này chứng minh
tool đọc/tính/chọn theo hệ số trong runtime; chưa chứng minh công thức sát
thương, mức hút máu hoặc mọi hiệu ứng G4 được quy thuộc đầy đủ trong log steps.
Pet ID đọc được2859 được đối chiếu với lựa chọn G4 của user và tên pet trên
màn hình; chưa thêm vào registry tự nhận pet hoặc thẻ skill chủ động.

Replay11 bàn trước nước đi khớp chính xác11/11 quyết định BASIC. Suy luận
offline trên cùng bàn và cùng thông số chọn khác4/11 nước:

| Lượt | BASIC | Suy luận | Đánh đổi quan sát được |
|---|---|---|---|
| 3 | 6 hiệu dụng, chừa phản hồi3 Kiếm | 3 hiệu dụng, phản hồi0 Kiếm đã biết | Bớt combo dưới mốc để giảm Kiếm cho boss; không có điểm setup do quá nhiều tie |
| 11 | 4 hiệu dụng, phản hồi3 Kiếm | 3 hiệu dụng, phản hồi0 Kiếm đã biết | Cùng đánh đổi về combo dưới mốc và phản hồi Kiếm |
| 13, HP27,35% | 7 hiệu dụng, phản hồi4 Kiếm | 4 Máu hiệu dụng, phản hồi0 Kiếm đã biết | Nhánh PROTECT lấy Máu và giảm Kiếm chừa lại |
| 19, HP26,30% | 8 hiệu dụng | 7 hiệu dụng | Cả hai dưới mốc9, không chừa phản hồi Kiếm đã biết; nhánh áp lực đổi xếp hạng rủi ro |

Đây là so sánh đặc tính nước đi trên cùng trạng thái, không là kết quả
counterfactual hoặc bằng chứng Suy luận chắc thắng. Không đưa refill thực tế
vào đầu vào replay; node cap1800 giữ nguyên, tắt đồng hồ thời gian thật chỉ
trong replay để tái hiện đầy đủ phần bounded setup. Bước live Suy luận cần
phiên giới hạn riêng; chưa tự mở thêm trận.

[Biên bản và hash log](artifacts/g4_native_20261122/closure.json),
[đối chiếu11 bàn](artifacts/g4_native_20261122/same_board_comparison.json).

Không sửa production code trong bài live, không thay source/profile, không
build, commit hoặc push. Tool được để ở trạng thái hoàn thành; chưa khởi
động lượt tiếp theo.
