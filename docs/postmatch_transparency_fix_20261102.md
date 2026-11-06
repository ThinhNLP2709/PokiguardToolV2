# Dừng ở 132/550: nhận diện bảng thưởng B14 bán trong suốt

Trạng thái: **đã sửa source, 193 kiểm tra offline PASS; chưa live lại/build lại**.

## Nguyên nhân đã tái hiện

Run `f7d1226f5ea247088ccbde68c96b1381`, attempt132, match `M_4c5241e2`.
Log combat chuyển POSTMATCH vì `local_match_end_flag` lúc 18:32:28.542Z ngày
01/11 (01:32:28.542 ngày02/11 theo giờ Việt Nam). Farm ghi WIN, tổng132WIN,
0technical abort,131lần xác nhận thưởng; lần132 chưa có input Đồng ý.

Owner nhận thưởng kiểm26mẫu trong30.609giây, không có proof3frame ổn định,
rồi dừng `POSTMATCH_UI_AMBIGUOUS` lúc khoảng01:33:00 giờ Việt Nam.
Ảnh đầu còn animation/chưa có nút; ảnh cuối đã có nút Đồng ý và đầy đủ khung
kết quả. Chỉ có hai ảnh được lưu; không suy rằng cả26mẫu đều đã có nút.

Ảnh cuối tái hiện lỗi với đúng source trước sửa:

| Điều kiện cụm xanh B14 cũ | Đo trên ảnh lỗi | Kết quả |
|---|---:|---|
| Diện tích tối thiểu12% viewport |81,409pixel =9.9376% | Không đạt |
| Chiều rộng tối đa62% viewport |796pixel =62.1875% | Không đạt |

Panel bán trong suốt khiến board/phần thưởng/nền phía sau thay đổi các mảng
màu xanh; màu xanh của scenery ngoài khung còn nối vào cụm panel. Vì vậy
`arenaPanelCandidates=0` dù hình dạng khung, huy hiệu thắng và nút đã rõ.
Không có bằng chứng quy lỗi riêng cho vé x2; đây là điều kiện màu phụ thuộc
ảnh nền. Các counter sai lượt/input trùng/stale/result conflict đều0.

## Sửa trong phạm vi nhận diện ảnh

- Riêng B14: giới hạn tìm cụm xanh trong khung đã biết(.22,.29,.78,.98),
  tách scenery bên ngoài, giảm diện tích xanh tối thiểu12% xuống8% viewport.
- Giữ điều kiện kích thước panel, cả4góc vàng, hai cánh thắng hoặc crest thua,
  một nút xanh có chữ sẵn sàng và vị trí nút trong khung kết quả.
- Thêm số pixel/ngưỡng/chiều rộng/chiều cao của cụm xanh vào diagnostics.
- Giữ lifecycle POSTMATCH,3frame ổn định, fresh preflight, click đúng1lần,
  timeout và flow input/memory/farm. ROI/ngưỡng của các layout cũ giữ nguyên.

Ảnh lỗi sau sửa cho đúng điểm(.5,.834375). Ảnh animation đầu vẫn bị từ chối.
Replay qua owner `_confirm_postmatch` chờ frame sẵn sàng rồi gửi đúng1input
giả. Đây là offline replay, không phải xác nhận đã click thành công trên game.

## Kiểm chứng và ranh giới

**193test/9module PASS**, gồm bộ nhận diện cũ/mới, thắng/thua, bootstrap/
re-entry, terminal accounting, farm và audit B14. Bổ sung9test từ capture thật:
tái hiện trước/sau, resize4profile, bắt buộc corner/header/label/panel, nhiều
nút, scenery ngoài khung, animation và owner một click.

[Test log](artifacts/postmatch_transparency_20261102/tests.log),
[receipt/manifest/đo pixel](artifacts/postmatch_transparency_20261102/closure.json),
[fixture và hash chain](../tests/fixtures/petpuzzle_b14_result_20261102_transparency/provenance.json).
Raw capture/log và provenance thắng/thua trước đây không bị ghi đè.

Trong đợt này chỉ runtime `postmatch_ui.py` đổi; hai test audit theo successor
hash rõ ràng và thêm một test regression. 397file source cũ còn lại giữ byte.
Source mới401file SHA `513e010428216e5c448629f5f1ea95b7699e006d3651e95cd4dc77640967745d`.
ZIP1.3.0 vẫn SHA `a9a190ba…`; phiên/binary đã mở không tự nhận sửa source.
Không mở tool, không click game, không Resume hoặc tạo trận mới.

Hồ sơ AI chung f669b126… và draft chưa activate vẫn là proof của source cũ;
chưa có native mới để mất cap. Trước khi quay lại live AI cần cập nhật kiểm
offline/draft theo successor này; không relabel raw proof hoặc tự thêm trận.
